Imports PSS.Core
Imports PSS.Data
Imports PSS.Rules
Imports PSS.Core.[Global]
Imports System.IO
Imports C1.Win

Namespace Gui.Billing

    Public Class BillingWin
        Inherits System.Windows.Forms.Form

        Private _iCust_ID As Integer = 0
        Private _iDevice_ID As Integer = 0
        Private _objBusinessMisc As PSS.Data.Buisness.Misc
        Private _objDeviceBilling As PSS.Data.Buisness.DeviceBilling

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._objBusinessMisc = New PSS.Data.Buisness.Misc()
            Me._objDeviceBilling = New PSS.Data.Buisness.DeviceBilling()

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
        Friend WithEvents lblDate As System.Windows.Forms.Label
        Friend WithEvents grpChangeSerial As System.Windows.Forms.GroupBox
        Friend WithEvents txtChangeSerial As System.Windows.Forms.TextBox
        Friend WithEvents btnSerialChngAccept As System.Windows.Forms.Button
        Friend WithEvents dbgParts As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lblPart As System.Windows.Forms.Label
        Friend WithEvents txtPart As System.Windows.Forms.TextBox
        Friend WithEvents lblDevice As System.Windows.Forms.Label
        Friend WithEvents txtDevice As System.Windows.Forms.TextBox
        Friend WithEvents lblTray As System.Windows.Forms.Label
        Friend WithEvents txtTray As System.Windows.Forms.TextBox
        Friend WithEvents grpInput As System.Windows.Forms.GroupBox
        Friend WithEvents grpTrayInfo As System.Windows.Forms.GroupBox
        Friend WithEvents lblCountTitle As System.Windows.Forms.Label
        Friend WithEvents lblCustTitle As System.Windows.Forms.Label
        Friend WithEvents lblCust As System.Windows.Forms.Label
        Friend WithEvents grpKey As System.Windows.Forms.GroupBox
        Friend WithEvents dbgDevices As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lblKeyEnter As System.Windows.Forms.Label
        Friend WithEvents lblKeyF12 As System.Windows.Forms.Label
        Friend WithEvents lblKeyF9 As System.Windows.Forms.Label
        Friend WithEvents lblCount As System.Windows.Forms.Label
        Friend WithEvents grpPrint As System.Windows.Forms.GroupBox
        Friend WithEvents btnPrintDevice As System.Windows.Forms.Button
        Friend WithEvents btnPrintTray As System.Windows.Forms.Button
        Friend WithEvents lblEndUser As System.Windows.Forms.Label
        Friend WithEvents btnClearAllParts As System.Windows.Forms.Button
        Friend WithEvents btnPrintCreditCardRpt As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(BillingWin))
            Me.dbgDevices = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.lblDate = New System.Windows.Forms.Label()
            Me.grpChangeSerial = New System.Windows.Forms.GroupBox()
            Me.btnSerialChngAccept = New System.Windows.Forms.Button()
            Me.txtChangeSerial = New System.Windows.Forms.TextBox()
            Me.grpInput = New System.Windows.Forms.GroupBox()
            Me.btnClearAllParts = New System.Windows.Forms.Button()
            Me.dbgParts = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.lblPart = New System.Windows.Forms.Label()
            Me.txtPart = New System.Windows.Forms.TextBox()
            Me.lblDevice = New System.Windows.Forms.Label()
            Me.txtDevice = New System.Windows.Forms.TextBox()
            Me.lblTray = New System.Windows.Forms.Label()
            Me.txtTray = New System.Windows.Forms.TextBox()
            Me.grpTrayInfo = New System.Windows.Forms.GroupBox()
            Me.lblCount = New System.Windows.Forms.Label()
            Me.lblCountTitle = New System.Windows.Forms.Label()
            Me.lblCustTitle = New System.Windows.Forms.Label()
            Me.lblCust = New System.Windows.Forms.Label()
            Me.grpKey = New System.Windows.Forms.GroupBox()
            Me.lblKeyF9 = New System.Windows.Forms.Label()
            Me.lblKeyF12 = New System.Windows.Forms.Label()
            Me.lblKeyEnter = New System.Windows.Forms.Label()
            Me.grpPrint = New System.Windows.Forms.GroupBox()
            Me.btnPrintTray = New System.Windows.Forms.Button()
            Me.btnPrintDevice = New System.Windows.Forms.Button()
            Me.lblEndUser = New System.Windows.Forms.Label()
            Me.btnPrintCreditCardRpt = New System.Windows.Forms.Button()
            CType(Me.dbgDevices, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grpChangeSerial.SuspendLayout()
            Me.grpInput.SuspendLayout()
            CType(Me.dbgParts, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grpTrayInfo.SuspendLayout()
            Me.grpKey.SuspendLayout()
            Me.grpPrint.SuspendLayout()
            Me.SuspendLayout()
            '
            'dbgDevices
            '
            Me.dbgDevices.AllowColMove = False
            Me.dbgDevices.AllowColSelect = False
            Me.dbgDevices.AllowDelete = True
            Me.dbgDevices.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
            Me.dbgDevices.AllowUpdate = False
            Me.dbgDevices.AlternatingRows = True
            Me.dbgDevices.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgDevices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.dbgDevices.Caption = "Tray Devices"
            Me.dbgDevices.CaptionHeight = 17
            Me.dbgDevices.DirectionAfterEnter = C1.Win.C1TrueDBGrid.DirectionAfterEnterEnum.MoveDown
            Me.dbgDevices.EditDropDown = False
            Me.dbgDevices.ExtendRightColumn = True
            Me.dbgDevices.FetchRowStyles = True
            Me.dbgDevices.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgDevices.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dbgDevices.Location = New System.Drawing.Point(208, 16)
            Me.dbgDevices.Name = "dbgDevices"
            Me.dbgDevices.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgDevices.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgDevices.PreviewInfo.ZoomFactor = 75
            Me.dbgDevices.RowHeight = 15
            Me.dbgDevices.Size = New System.Drawing.Size(376, 472)
            Me.dbgDevices.SpringMode = True
            Me.dbgDevices.TabIndex = 8
            Me.dbgDevices.TabStop = False
            Me.dbgDevices.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Style11{}Style12{}FilterBar{}Style5{}Style4{}Style7{}Style6{}EvenRow{Ba" & _
            "ckColor:Ivory;}Selected{ForeColor:Black;BackColor:Yellow;}Heading{Wrap:True;Lock" & _
            "ed:True;AlignHorz:Center;BackColor:Beige;Border:Raised,,1, 1, 1, 1;ForeColor:Con" & _
            "trolText;AlignVert:Center;}Inactive{ForeColor:InactiveCaptionText;BackColor:Inac" & _
            "tiveCaption;}Footer{}Caption{AlignHorz:Center;Border:Flat,Black,0, 0, 0, 1;BackC" & _
            "olor:Beige;}Editor{}Normal{Font:Verdana, 8.25pt;AlignHorz:Center;AlignVert:Cente" & _
            "r;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style1{}OddRow{}Rec" & _
            "ordSelector{AlignImage:Center;}Style15{}Style9{}Style8{}Style3{}Style2{}Style14{" & _
            "}Style13{}Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}" & _
            "Style10{AlignHorz:Near;}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView A" & _
            "llowColMove=""False"" AllowColSelect=""False"" Name="""" AllowRowSizing=""None"" AllowHo" & _
            "rizontalSizing=""False"" AllowVerticalSizing=""False"" AlternatingRowStyle=""True"" Ca" & _
            "ptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" ExtendRightCol" & _
            "umn=""True"" FetchRowStyles=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorW" & _
            "idth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1"" " & _
            "SpringMode=""True""><Height>452</Height><CaptionStyle parent=""Style2"" me=""Style10""" & _
            " /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=" & _
            """Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent" & _
            "=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle " & _
            "parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Styl" & _
            "e7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow" & _
            """ me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><Sel" & _
            "ectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" />" & _
            "<ClientRect>0, 17, 374, 452</ClientRect><BorderSide>0</BorderSide><BorderStyle>S" & _
            "unken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style " & _
            "parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Hea" & _
            "ding"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Headin" & _
            "g"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal""" & _
            " me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal""" & _
            " me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=" & _
            """RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Captio" & _
            "n"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplit" & _
            "s><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientAre" & _
            "a>0, 0, 374, 470</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><Pri" & _
            "ntPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'lblDate
            '
            Me.lblDate.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.lblDate.BackColor = System.Drawing.Color.Beige
            Me.lblDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblDate.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDate.Location = New System.Drawing.Point(600, 16)
            Me.lblDate.Name = "lblDate"
            Me.lblDate.Size = New System.Drawing.Size(176, 24)
            Me.lblDate.TabIndex = 11
            Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'grpChangeSerial
            '
            Me.grpChangeSerial.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.grpChangeSerial.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnSerialChngAccept, Me.txtChangeSerial})
            Me.grpChangeSerial.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.grpChangeSerial.Location = New System.Drawing.Point(600, 168)
            Me.grpChangeSerial.Name = "grpChangeSerial"
            Me.grpChangeSerial.Size = New System.Drawing.Size(176, 80)
            Me.grpChangeSerial.TabIndex = 15
            Me.grpChangeSerial.TabStop = False
            Me.grpChangeSerial.Text = "Change Serial"
            Me.grpChangeSerial.Visible = False
            '
            'btnSerialChngAccept
            '
            Me.btnSerialChngAccept.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.btnSerialChngAccept.Location = New System.Drawing.Point(8, 48)
            Me.btnSerialChngAccept.Name = "btnSerialChngAccept"
            Me.btnSerialChngAccept.Size = New System.Drawing.Size(160, 24)
            Me.btnSerialChngAccept.TabIndex = 1
            Me.btnSerialChngAccept.TabStop = False
            Me.btnSerialChngAccept.Text = "Accept"
            '
            'txtChangeSerial
            '
            Me.txtChangeSerial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtChangeSerial.Location = New System.Drawing.Point(8, 24)
            Me.txtChangeSerial.Name = "txtChangeSerial"
            Me.txtChangeSerial.Size = New System.Drawing.Size(160, 21)
            Me.txtChangeSerial.TabIndex = 2
            Me.txtChangeSerial.Text = ""
            Me.txtChangeSerial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'grpInput
            '
            Me.grpInput.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.grpInput.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnClearAllParts, Me.dbgParts, Me.lblPart, Me.txtPart, Me.lblDevice, Me.txtDevice, Me.lblTray, Me.txtTray})
            Me.grpInput.Location = New System.Drawing.Point(8, 8)
            Me.grpInput.Name = "grpInput"
            Me.grpInput.Size = New System.Drawing.Size(184, 480)
            Me.grpInput.TabIndex = 0
            Me.grpInput.TabStop = False
            Me.grpInput.Text = "Billing Input"
            '
            'btnClearAllParts
            '
            Me.btnClearAllParts.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.btnClearAllParts.BackColor = System.Drawing.Color.Red
            Me.btnClearAllParts.ForeColor = System.Drawing.Color.White
            Me.btnClearAllParts.Location = New System.Drawing.Point(8, 448)
            Me.btnClearAllParts.Name = "btnClearAllParts"
            Me.btnClearAllParts.Size = New System.Drawing.Size(160, 24)
            Me.btnClearAllParts.TabIndex = 29
            Me.btnClearAllParts.TabStop = False
            Me.btnClearAllParts.Text = "Clear All Parts"
            '
            'dbgParts
            '
            Me.dbgParts.AllowColMove = False
            Me.dbgParts.AllowColSelect = False
            Me.dbgParts.AllowDelete = True
            Me.dbgParts.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
            Me.dbgParts.AllowUpdate = False
            Me.dbgParts.AlternatingRows = True
            Me.dbgParts.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgParts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.dbgParts.Caption = "Device Parts"
            Me.dbgParts.CaptionHeight = 17
            Me.dbgParts.Cursor = System.Windows.Forms.Cursors.Default
            Me.dbgParts.DirectionAfterEnter = C1.Win.C1TrueDBGrid.DirectionAfterEnterEnum.MoveDown
            Me.dbgParts.EditDropDown = False
            Me.dbgParts.ExtendRightColumn = True
            Me.dbgParts.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgParts.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.dbgParts.Location = New System.Drawing.Point(8, 168)
            Me.dbgParts.Name = "dbgParts"
            Me.dbgParts.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgParts.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgParts.PreviewInfo.ZoomFactor = 75
            Me.dbgParts.RowHeight = 15
            Me.dbgParts.Size = New System.Drawing.Size(160, 272)
            Me.dbgParts.SpringMode = True
            Me.dbgParts.TabIndex = 3
            Me.dbgParts.TabStop = False
            Me.dbgParts.Text = "Device Parts"
            Me.dbgParts.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;}Style27{}Normal{Font:Verdana, 8.25pt;AlignHor" & _
            "z:Center;AlignVert:Center;}Selected{ForeColor:Black;BackColor:Yellow;}Editor{}St" & _
            "yle14{}Style15{}Style10{AlignHorz:Near;}Style11{}OddRow{}Style13{}Style12{}Style" & _
            "31{}Style29{}Style28{}HighlightRow{ForeColor:HighlightText;BackColor:Yellow;}Sty" & _
            "le26{}RecordSelector{AlignImage:Center;BackColor:Beige;}Footer{}Inactive{ForeCol" & _
            "or:InactiveCaptionText;BackColor:InactiveCaption;}EvenRow{BackColor:Ivory;}Headi" & _
            "ng{Wrap:True;Locked:True;AlignHorz:Center;BackColor:Beige;Border:Flat,Black,0, 1" & _
            ", 0, 1;ForeColor:ControlText;AlignVert:Center;}FilterBar{}Style4{}Style9{}Style8" & _
            "{}Style5{}Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}" & _
            "Style7{}Style6{}Style1{}Style30{}Style3{}Style2{}</Data></Styles><Splits><C1.Win" & _
            ".C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""False"" Name="""" Allo" & _
            "wRowSizing=""None"" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHei" & _
            "ght=""17"" ColumnFooterHeight=""17"" ExtendRightColumn=""True"" MarqueeStyle=""DottedCe" & _
            "llBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" H" & _
            "orizontalScrollGroup=""1"" SpringMode=""True""><Height>253</Height><CaptionStyle par" & _
            "ent=""Heading"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style2"" /><EvenRow" & _
            "Style parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Styl" & _
            "e31"" /><FooterStyle parent=""Footer"" me=""Style4"" /><GroupStyle parent=""Group"" me=" & _
            """Style12"" /><HeadingStyle parent=""Heading"" me=""Style3"" /><HighLightRowStyle pare" & _
            "nt=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style6"" /><" & _
            "OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSel" & _
            "ector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><Style pare" & _
            "nt=""Normal"" me=""Style1"" /><ClientRect>0, 17, 158, 253</ClientRect><BorderSide>0<" & _
            "/BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></S" & _
            "plits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Hea" & _
            "ding"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Captio" & _
            "n"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected" & _
            """ /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow" & _
            """ /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><" & _
            "Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBa" & _
            "r"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplit" & _
            "s><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</Default" & _
            "RecSelWidth><ClientArea>0, 0, 158, 270</ClientArea><PrintPageHeaderStyle parent=" & _
            """"" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'lblPart
            '
            Me.lblPart.Location = New System.Drawing.Point(8, 104)
            Me.lblPart.Name = "lblPart"
            Me.lblPart.Size = New System.Drawing.Size(120, 16)
            Me.lblPart.TabIndex = 28
            Me.lblPart.Text = "Enter Part:"
            '
            'txtPart
            '
            Me.txtPart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPart.Location = New System.Drawing.Point(8, 120)
            Me.txtPart.Name = "txtPart"
            Me.txtPart.Size = New System.Drawing.Size(160, 21)
            Me.txtPart.TabIndex = 3
            Me.txtPart.Text = ""
            Me.txtPart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'lblDevice
            '
            Me.lblDevice.Location = New System.Drawing.Point(8, 64)
            Me.lblDevice.Name = "lblDevice"
            Me.lblDevice.Size = New System.Drawing.Size(120, 16)
            Me.lblDevice.TabIndex = 26
            Me.lblDevice.Text = "Enter Device:"
            '
            'txtDevice
            '
            Me.txtDevice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDevice.Location = New System.Drawing.Point(8, 80)
            Me.txtDevice.MaxLength = 50
            Me.txtDevice.Name = "txtDevice"
            Me.txtDevice.Size = New System.Drawing.Size(160, 21)
            Me.txtDevice.TabIndex = 1
            Me.txtDevice.Text = ""
            Me.txtDevice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            Me.txtDevice.WordWrap = False
            '
            'lblTray
            '
            Me.lblTray.Location = New System.Drawing.Point(8, 24)
            Me.lblTray.Name = "lblTray"
            Me.lblTray.Size = New System.Drawing.Size(120, 16)
            Me.lblTray.TabIndex = 24
            Me.lblTray.Text = "Enter Tray:"
            '
            'txtTray
            '
            Me.txtTray.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtTray.Location = New System.Drawing.Point(8, 40)
            Me.txtTray.Name = "txtTray"
            Me.txtTray.Size = New System.Drawing.Size(160, 21)
            Me.txtTray.TabIndex = 0
            Me.txtTray.Text = ""
            Me.txtTray.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'grpTrayInfo
            '
            Me.grpTrayInfo.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.grpTrayInfo.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblCount, Me.lblCountTitle, Me.lblCustTitle, Me.lblCust})
            Me.grpTrayInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.grpTrayInfo.Location = New System.Drawing.Point(600, 48)
            Me.grpTrayInfo.Name = "grpTrayInfo"
            Me.grpTrayInfo.Size = New System.Drawing.Size(176, 112)
            Me.grpTrayInfo.TabIndex = 24
            Me.grpTrayInfo.TabStop = False
            Me.grpTrayInfo.Text = "Tray Info"
            '
            'lblCount
            '
            Me.lblCount.BackColor = System.Drawing.Color.Beige
            Me.lblCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblCount.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCount.Location = New System.Drawing.Point(64, 72)
            Me.lblCount.Name = "lblCount"
            Me.lblCount.Size = New System.Drawing.Size(104, 24)
            Me.lblCount.TabIndex = 17
            Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblCountTitle
            '
            Me.lblCountTitle.Location = New System.Drawing.Point(8, 80)
            Me.lblCountTitle.Name = "lblCountTitle"
            Me.lblCountTitle.Size = New System.Drawing.Size(48, 16)
            Me.lblCountTitle.TabIndex = 18
            Me.lblCountTitle.Text = "Count:"
            '
            'lblCustTitle
            '
            Me.lblCustTitle.Location = New System.Drawing.Point(8, 24)
            Me.lblCustTitle.Name = "lblCustTitle"
            Me.lblCustTitle.Size = New System.Drawing.Size(120, 16)
            Me.lblCustTitle.TabIndex = 16
            Me.lblCustTitle.Text = "Customer"
            '
            'lblCust
            '
            Me.lblCust.BackColor = System.Drawing.Color.Beige
            Me.lblCust.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblCust.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblCust.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCust.Location = New System.Drawing.Point(8, 40)
            Me.lblCust.Name = "lblCust"
            Me.lblCust.Size = New System.Drawing.Size(160, 24)
            Me.lblCust.TabIndex = 15
            Me.lblCust.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'grpKey
            '
            Me.grpKey.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.grpKey.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblKeyF9, Me.lblKeyF12, Me.lblKeyEnter})
            Me.grpKey.Location = New System.Drawing.Point(600, 408)
            Me.grpKey.Name = "grpKey"
            Me.grpKey.Size = New System.Drawing.Size(176, 80)
            Me.grpKey.TabIndex = 25
            Me.grpKey.TabStop = False
            Me.grpKey.Text = "Key"
            '
            'lblKeyF9
            '
            Me.lblKeyF9.Location = New System.Drawing.Point(8, 56)
            Me.lblKeyF9.Name = "lblKeyF9"
            Me.lblKeyF9.Size = New System.Drawing.Size(128, 16)
            Me.lblKeyF9.TabIndex = 2
            Me.lblKeyF9.Text = "F9 : New Tray"
            '
            'lblKeyF12
            '
            Me.lblKeyF12.Location = New System.Drawing.Point(8, 40)
            Me.lblKeyF12.Name = "lblKeyF12"
            Me.lblKeyF12.Size = New System.Drawing.Size(120, 16)
            Me.lblKeyF12.TabIndex = 1
            Me.lblKeyF12.Text = "F12 : New Device"
            '
            'lblKeyEnter
            '
            Me.lblKeyEnter.Location = New System.Drawing.Point(8, 24)
            Me.lblKeyEnter.Name = "lblKeyEnter"
            Me.lblKeyEnter.Size = New System.Drawing.Size(136, 16)
            Me.lblKeyEnter.TabIndex = 0
            Me.lblKeyEnter.Text = "Enter : Submit Info"
            '
            'grpPrint
            '
            Me.grpPrint.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.grpPrint.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnPrintCreditCardRpt, Me.btnPrintTray, Me.btnPrintDevice})
            Me.grpPrint.Location = New System.Drawing.Point(600, 288)
            Me.grpPrint.Name = "grpPrint"
            Me.grpPrint.Size = New System.Drawing.Size(176, 120)
            Me.grpPrint.TabIndex = 26
            Me.grpPrint.TabStop = False
            Me.grpPrint.Text = "Print End User"
            '
            'btnPrintTray
            '
            Me.btnPrintTray.Enabled = False
            Me.btnPrintTray.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.btnPrintTray.Location = New System.Drawing.Point(8, 56)
            Me.btnPrintTray.Name = "btnPrintTray"
            Me.btnPrintTray.Size = New System.Drawing.Size(160, 24)
            Me.btnPrintTray.TabIndex = 1
            Me.btnPrintTray.TabStop = False
            Me.btnPrintTray.Text = "Print Current Tray"
            '
            'btnPrintDevice
            '
            Me.btnPrintDevice.Enabled = False
            Me.btnPrintDevice.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.btnPrintDevice.Location = New System.Drawing.Point(8, 24)
            Me.btnPrintDevice.Name = "btnPrintDevice"
            Me.btnPrintDevice.Size = New System.Drawing.Size(160, 24)
            Me.btnPrintDevice.TabIndex = 0
            Me.btnPrintDevice.TabStop = False
            Me.btnPrintDevice.Text = "Print Current Device"
            '
            'lblEndUser
            '
            Me.lblEndUser.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.lblEndUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblEndUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblEndUser.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblEndUser.ForeColor = System.Drawing.Color.White
            Me.lblEndUser.Location = New System.Drawing.Point(600, 256)
            Me.lblEndUser.Name = "lblEndUser"
            Me.lblEndUser.Size = New System.Drawing.Size(176, 24)
            Me.lblEndUser.TabIndex = 27
            Me.lblEndUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnPrintCreditCardRpt
            '
            Me.btnPrintCreditCardRpt.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.btnPrintCreditCardRpt.Location = New System.Drawing.Point(8, 88)
            Me.btnPrintCreditCardRpt.Name = "btnPrintCreditCardRpt"
            Me.btnPrintCreditCardRpt.Size = New System.Drawing.Size(160, 24)
            Me.btnPrintCreditCardRpt.TabIndex = 2
            Me.btnPrintCreditCardRpt.TabStop = False
            Me.btnPrintCreditCardRpt.Text = "Print Credit Card Report"
            '
            'BillingWin
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
            Me.ClientSize = New System.Drawing.Size(782, 493)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblEndUser, Me.grpPrint, Me.grpKey, Me.grpTrayInfo, Me.grpInput, Me.grpChangeSerial, Me.lblDate, Me.dbgDevices})
            Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Name = "BillingWin"
            Me.Text = "BillingWin"
            CType(Me.dbgDevices, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grpChangeSerial.ResumeLayout(False)
            Me.grpInput.ResumeLayout(False)
            CType(Me.dbgParts, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grpTrayInfo.ResumeLayout(False)
            Me.grpKey.ResumeLayout(False)
            Me.grpPrint.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private _dtTray As DataTable = Nothing
        Private _objDevice As Device = Nothing
        Private _dtBillcodes As DataTable = Buisness.DeviceBilling.GetBillCodes
        Private _booPrintOnF9 As Boolean = False

        Private _strBinLoc As String
        Private _strUserName As String = PSS.Core.[Global].ApplicationUser.User
        Private _iUserID As Integer = PSS.Core.[Global].ApplicationUser.IDuser

        '**************************************************************
        Private Sub BillingWin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim xCount As Integer
            Dim r As DataRow

            Try
                MainWin.StatusBar.SetStatusText("Opening Billing (Loading Billing Data)")
                MainWin.StatusBar.SetStatusText("Ready")
                Highlight.SetHighLight(Me)
                lblDate.Text = Now.Date
                txtTray.Focus()

                Me._strBinLoc = getBinLoc()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '**************************************************************
        Private Function VerifyCreditCardUser() As Boolean
            Dim booVerifyCreditCardUser As Boolean = True
            Dim dt As DataTable
            Dim r As DataRow
            Dim ibStr As String
            Dim fStr As String

            Try
                dt = PSS.Data.Buisness.DeviceBilling.GetPayID(Trim(Me.txtTray.Text))

                If dt.Rows.Count > 0 Then
                    r = dt.Rows(0)
                    If Trim(r("Pay_ID")) = 2 Then
                        ibStr = InputBox("Please enter Credit Card Password Authentication:", "Password")
                        fStr = UCase(ibStr)
                        If Trim(fStr) = "AE4V3" Then
                            booVerifyCreditCardUser = True
                        Else
                            booVerifyCreditCardUser = False
                            MsgBox("You do not have permission to bill a Credit Card Customer. Please foreward this to Crystal Few", MsgBoxStyle.Critical)
                            txtTray.Text = ""
                            txtTray.Focus()
                        End If
                    End If
                End If

                Return booVerifyCreditCardUser
            Catch ex As Exception
                Throw ex
            Finally
                r = Nothing
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Function

        '**************************************************************
        Private Sub HotKeysF9(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtTray.KeyDown, txtDevice.KeyDown, txtPart.KeyDown

            If e.KeyCode = Keys.F9 AndAlso Len(Trim(txtTray.Text)) > 0 Then

                Try
                    If Len(Trim(txtDevice.Text)) > 0 Then
                        UpdateBilling()
                    End If

                    If Me._booPrintOnF9 = True Then
                        Me._objDevice.Print(Trim(txtTray.Text))
                    End If

                    Me.dbgParts.DataSource = Nothing
                    Me.dbgDevices.DataSource = Nothing

                    Me._booPrintOnF9 = False
                    LockPrint(False)

                    Me.lblCount.Text = 0
                    Me.lblCust.Text = ""

                    txtTray.Text = ""
                    txtDevice.Text = ""
                    txtPart.Text = ""
                    txtTray.Focus()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString, "HotKeyF9_KeyUpEvent", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Finally
                    If Not IsNothing(Me._objDevice) Then
                        Me._objDevice.Dispose()
                        Me._objDevice = Nothing
                    End If
                End Try
            End If
        End Sub

        '**************************************************************
        Private Sub HotKeysF12(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtTray.KeyDown, txtDevice.KeyDown, txtPart.KeyDown
            If (e.KeyCode = Keys.F12 Or e.KeyCode = Keys.F2) AndAlso Len(Trim(txtTray.Text)) > 0 Then

                Try
                    If Len(Trim(txtDevice.Text)) > 0 Then
                        UpdateBilling()

                        Me.dbgParts.DataSource = Nothing
                        
                        If Me._booPrintOnF9 = True Then
                            Me.btnPrintDevice.Enabled = False
                        End If

                        Me.lblCust.Text = ""

                        txtPart.Text = ""
                        txtDevice.Text = ""
                        txtDevice.Focus()
                    End If

                Catch ex As Exception
                    MessageBox.Show(ex.ToString, "HotKeyF12_KeyUpEvent", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Finally
                    If Not IsNothing(Me._objDevice) Then
                        Me._objDevice.Dispose()
                        Me._objDevice = Nothing
                    End If
                End Try
            End If
        End Sub

        '**************************************************************
        Private Sub UpdateBilling()
            Dim drArr As DataRow()

            Try 'here in case there is not refrence to _device
                Me._objDevice.Update()

                'If Me._iCust_ID = 14 And Me._objDevice.Parts.Rows.Count > 0 Then
                '    Me._objDeviceBilling.AddRecrystaledLaborChrgForAMCust(Me._iDevice_ID)
                'End If

                drArr = Me._dtTray.Select("Device_ID = " & Me._objDevice.ID)

                If Me._objDevice.Parts.Rows.Count = 0 Then
                    drArr(0)("Device_DateBill") = DBNull.Value
                Else
                    drArr(0)("Device_DateBill") = PSS.Data.Buisness.Generic.MySQLServerDateTime(1)
                End If

            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Information, "Error")
            Finally
                drArr = Nothing
                Me._objDevice.Dispose()
            End Try
        End Sub

        '**************************************************************
        Private Sub LoadTray(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtTray.KeyDown
            Dim i As Integer = 0
            Dim dtDeviceInTray As DataTable

            If e.KeyCode = Keys.Enter Then

                Try
                    If IsNumeric(txtTray.Text) Then

                        If VerifyCreditCardUser() = False Then Exit Sub


                        '*********************************************************
                        'Check if the Tray has been scanned in at the end of line
                        '*********************************************************
                        i = Me._objBusinessMisc.CheckTray(txtTray.Text)
                        If i = 0 Then
                            Throw New Exception("This tray is not scanned in at the end of line. Send it back to where it came from for scanning.")
                        End If

                        '*********************************************************
                        dtDeviceInTray = PSS.Data.Buisness.DeviceBilling.GetDeviceTrayByID(txtTray.Text)
                        If dtDeviceInTray.Rows.Count = 0 Then
                            MsgBox("This is not a valid tray.", MsgBoxStyle.Information, "Error")

                            Me.dbgDevices.DataSource = Nothing
                            Me._dtTray = Nothing

                            Me.lblCount.Text = 0
                            Me.txtTray.Text = ""
                        Else
                            Me._dtTray = dtDeviceInTray

                            Me.dbgDevices.DataSource = Me._dtTray.DefaultView
                            Me.lblCount.Text = Me._dtTray.Rows.Count

                            DoDeviceFields()
                            txtDevice.Focus()
                        End If
                    Else
                        Throw New Exception("A tray number is all numeric. please enter a valid tray.")
                    End If

                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Billing")
                Finally
                    If Not IsNothing(dtDeviceInTray) Then
                        dtDeviceInTray.Dispose()
                        dtDeviceInTray = Nothing
                    End If
                End Try
            End If
        End Sub

        '**************************************************************
        Private Sub LoadDevice(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtDevice.KeyDown
            Dim drArrDevice As DataRow()
            Dim i As Integer = 0

            If e.KeyCode = Keys.Enter Then

                Try
                    drArrDevice = Me._dtTray.Select("Device_SN = '" & UCase(txtDevice.Text) & "'")
                    Me._objDevice = New Device(drArrDevice(0)("Device_ID"))
                    Me.dbgParts.DataSource = Me._objDevice.DefaultView

                    DoPartsFields()

                    For i = 0 To _dtTray.Rows.Count - 1
                        'If _tray.Rows(i)("Device_SN") = UCase(txtDevice.Text) Then
                        If Me._dtTray.Rows(i)("Device_SN") = Trim(UCase(txtDevice.Text)) Then 'Craig Haney change 3-3-04
                            Exit For
                        End If
                    Next i

                    Me.dbgDevices.MoveRelative(0, i)
                    'Me.dbgDevices.Row = i
                    Me.lblCust.Text = Me._objDevice.Customer

                    '//Added by Asif
                    Me._iCust_ID = Me._objDevice.CustID
                    Me._iDevice_ID = Me._objDevice.ID

                    If Me._objDevice.EndUser = True Then LockPrint(True)

                    txtDevice.Text = UCase(txtDevice.Text)
                    txtPart.Focus()

                Catch ex As Exception
                    MsgBox("This is not a valid billable device.", MsgBoxStyle.Information, "Error")
                    Me._objDevice = Nothing
                    Me.dbgParts.DataSource = Nothing
                    LockPrint(False)
                    Me.lblCust.Text = ""
                    txtDevice.Text = ""
                End Try
            End If
        End Sub

        '**************************************************************
        Private Sub AddPart(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtPart.KeyDown
            Dim iModel_ID As Integer = 0

            If e.KeyCode = Keys.Enter Then
                If IsNumeric(txtPart.Text) Then

                    'Dim blnSetPart As Boolean = setPartTransaction(Me._objDevice.ID, txtPart.Text, 1, _iUserID, Me._strBinLoc, 1, 0)

                    Try
                        ''*************************************************
                        ''Added by Lan on 02/29/2008
                        ''contingent billing
                        ''*************************************************
                        'iModel_ID = CInt(Me.dbgDevices.Columns("Model_ID").Text)
                        'If (Me._iCust_ID = 14 And (iModel_ID = 2 Or iModel_ID = 7)) or (Me._iCust_ID = 1545 And iModel_ID = 14 ) Then
                        '    If Trim(txtPart.Text) = 20 Then     'Recrystaled(service)
                        '        Me._objDevice.AddPart(21)
                        '    ElseIf Trim(txtPart.Text) = 21 Then 'Crystal Used(part)
                        '        Me._objDevice.AddPart(20)
                        '    End If
                        'End If
                        ''*************************************************
                        Me._objDevice.AddPart(Trim(txtPart.Text))

                        '*************************************************
                        '//Added by Asif
                        If (Me._iCust_ID = 1 Or Me._iCust_ID = 14) And (CInt(Trim(txtPart.Text)) = 25 Or CInt(Trim(txtPart.Text)) = 89) Then  'Metrocall DBR devices
                            ShowDBRReasonScreen()
                        End If
                        '*************************************************
                        '//Craig D. Haney March 29, 2005 - START
                        '//This is new to write to the tparttransaction table

                        'Get tdevicebillID value and add records to tpartcodes
                        Dim tDBillID As New PSS.Data.Production.tdevicebill()
                        Dim dtBillID As DataTable = tDBillID.GetDataTableByDeviceBillCode(Me._objDevice.ID, Trim(txtPart.Text))
                        Dim devBillID As Int32
                        Dim xCount As Integer
                        Dim r As DataRow
                        For xCount = 0 To dtBillID.Rows.Count - 1
                            r = dtBillID.Rows(xCount)
                            devBillID = r("DBill_ID")
                            Exit For
                        Next


                        Dim tmpShift As Integer
                        tmpShift = PSS.Core.[Global].ApplicationUser.IDShift
                        Me._iUserID = PSS.Core.[Global].ApplicationUser.IDuser

                        '                        Dim blnSetPart As Boolean = setPartTransaction(_device.ID, txtPart.Text, 1, tmpID, tmpBinLoc, 1, devBillID)
                        Try
                            dtBillID.Dispose()
                            dtBillID = Nothing
                        Catch ex As Exception
                        End Try
                        'Dim blnSetPart As Boolean = setPartTransaction(_device.ID, txtPart.Text, 1, tmpID, tmpBinLoc, 1)
                        '//This is new to write to the tparttransaction table
                        '//Craig D. Haney March 29, 2005 - END

                    Catch ex As Exception
                        MsgBox(ex.Message.ToString, MsgBoxStyle.Exclamation, "Error")
                    End Try

                    txtPart.Text = ""
                End If
            End If
        End Sub

        '**************************************************************
        Private Sub dbgParts_UnboundColumnFetch(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.UnboundColumnFetchEventArgs) Handles dbgParts.UnboundColumnFetch
            If e.Col = 8 Then
                e.Value = Me._objDevice.Parts.Rows(e.Row)(4)
            End If
        End Sub

        '**************************************************************
        Private Sub LockPrint(ByVal booUnLock As Boolean)
            Try
                If booUnLock = True Then
                    Me._booPrintOnF9 = True
                    Me.btnPrintDevice.Enabled = Not Me.btnPrintDevice.Enabled
                    Me.btnPrintTray.Enabled = Not Me.btnPrintTray.Enabled
                Else
                    Me._booPrintOnF9 = False
                    Me.btnPrintDevice.Enabled = False
                    Me.btnPrintTray.Enabled = False
                End If

                If Me._booPrintOnF9 = False Then
                    Me.lblEndUser.BackColor = System.Drawing.SystemColors.Control
                    Me.lblEndUser.Text = ""
                Else
                    Me.lblEndUser.BackColor = System.Drawing.Color.Red
                    Me.lblEndUser.Text = "End User"
                End If

            Catch ex As Exception   ' here in case an invalid id is sent
                Throw ex
            End Try
        End Sub

        '**************************************************************
        Private Sub DoPartsFields()
            Me.dbgParts.Splits(0).DisplayColumns(0).Visible = False
            Me.dbgParts.Splits(0).DisplayColumns(1).Visible = False
            Me.dbgParts.Splits(0).DisplayColumns(2).Visible = False
            Me.dbgParts.Splits(0).DisplayColumns(3).Visible = False
            Me.dbgParts.Columns(4).Caption = "Code"
            Me.dbgParts.Splits(0).DisplayColumns(4).Width = 30
            Me.dbgParts.Splits(0).DisplayColumns(5).Visible = False
            Me.dbgParts.Splits(0).DisplayColumns(6).Visible = False
            Me.dbgParts.Splits(0).DisplayColumns(7).Visible = False

            'Craig D Haney October 8 2004
            'Me.dbgParts.Splits(0).DisplayColumns(8).Visible = False
            'Dim dc As New C1.Win.C1TrueDBGrid.C1DataColumn()
            'Me.dbgParts.Columns.Insert(9, dc)
            'Me.dbgParts.Splits(0).DisplayColumns(9).Visible = True
            'Me.dbgParts.Columns(9).Caption = "Desc"
            'Craig D Haney October 8 2004

            'Me.dbgParts.Splits(0).DisplayColumns(8).Visible = True
            Dim dc As New C1.Win.C1TrueDBGrid.C1DataColumn()
            Me.dbgParts.Columns.Insert(8, dc)
            Me.dbgParts.Splits(0).DisplayColumns(8).Visible = True
            Me.dbgParts.Columns(8).Caption = "Desc"


            Dim r As DataRow, v As C1.Win.C1TrueDBGrid.ValueItem
            For Each r In Me._dtBillcodes.Rows
                v = New C1.Win.C1TrueDBGrid.ValueItem(r("BillCode_ID"), r("BillCode_Desc"))
                Me.dbgParts.Columns(8).ValueItems.Values.Add(v)
            Next
            Me.dbgParts.Columns(8).ValueItems.Translate = True
        End Sub

        '**************************************************************
        Private Sub DoDeviceFields()
            Me.dbgDevices.Splits(0).DisplayColumns(0).Visible = False
            Me.dbgDevices.Splits(0).DisplayColumns(1).Width = 30
            Me.dbgDevices.Columns(2).Caption = "Serial"
            Me.dbgDevices.Columns(3).Caption = "Old Serial"
            Me.dbgDevices.Columns(4).Caption = "Date Billed"
        End Sub

        '**************************************************************
        'Private Sub btnSerialChngAccept_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSerialChngAccept.Click
        '    ChangeSerial()
        'End Sub

        'Private Sub SerialChng(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtChangeSerial.KeyDown
        '    If e.KeyCode = Keys.Enter Then
        '        If Len(Trim(Me.txtChangeSerial.Text)) Then
        '            Try
        '                ChangeSerial()
        '            Catch ex As Exception
        '                '// here in case they dont scan a device first
        '            End Try
        '        Else
        '            MsgBox("You must enter a serial in order to change a serial.")
        '        End If
        '    ElseIf e.KeyCode = Keys.Escape Then
        '        Me.txtChangeSerial.Text = ""
        '        Me.txtPart.Focus()
        '    End If
        'End Sub

        'Private Sub ChangeSerial()
        '    Dim __device As DataRow()
        '    If Len(Me.txtChangeSerial.Text) <> 0 Then
        '        __device = _tray.Select("Device_SN = '" & Trim(UCase(Me.txtChangeSerial.Text)) & "'")
        '    Else
        '        MsgBox("You must first scan a device in order to change the serial.", MsgBoxStyle.Information, "Error")
        '        Exit Sub
        '    End If

        '    If __device.Length > 0 Then
        '        MsgBox("This serial is ALREADY in use by another device in this tray.", MsgBoxStyle.Information, "Error")
        '        Me.txtChangeSerial.Text = ""
        '        Me.txtChangeSerial.Focus()
        '    Else
        '        __device = _tray.Select("Device_SN = '" & Me.txtDevice.Text & "'")
        '        If IsDBNull(__device(0)("Device_OldSN")) Then
        '            __device(0)("Device_OldSN") = Me.txtDevice.Text
        '        End If
        '        __device(0)("Device_SN") = Trim(UCase(Me.txtChangeSerial.Text))
        '        Buisness.DeviceBilling.ChangeSerial(__device(0)("Device_ID"), Trim(UCase(Me.txtChangeSerial.Text)), _
        '                                                                                Me.txtDevice.Text)
        '        __device = Nothing
        '        Me.txtDevice.Text = Trim(UCase(Me.txtChangeSerial.Text))
        '        Me.txtChangeSerial.Text = ""
        '        LoadDevice(Me, New KeyEventArgs(Keys.KeyCode.Enter))
        '    End If
        'End Sub

        '**************************************************************
        Private Sub dbgParts_BeforeDelete(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles dbgParts.BeforeDelete
            Dim iPartID As Integer = CInt(dbgParts.Columns(4).Text)
            Dim iModel_ID As Integer = CInt(Me.dbgDevices.Columns("Model_ID").Text)

            Try
                ''***************************
                ''Added by Lan on 02/29/2008
                ''contengient billing
                ''***************************
                'If ( Me._iCust_ID = 14 And (iModel_ID = 2 Or iModel_ID = 7)) or ( Me._iCust_ID = 1545 And iModel_ID = 14 )  Then
                '    If iPartID = 20 Then        'Recrystaled(service)
                '        Me._objDevice.DeletePart(21)
                '    ElseIf iPartID = 21 Then    'Crystal Used(part)
                '        Me._objDevice.DeletePart(20)
                '    End If
                'End If
                ''***************************
                Me._objDevice.DeletePart(iPartID)

                Me.txtPart.Focus()
                e.Cancel = True ' we cancel the delete because the part is actually being deleted manually due to TrueDBG issues.

                '*************************************************
                '//Added by Asif
                If (Me._iCust_ID = 1 Or Me._iCust_ID = 14) And (iPartID = 25 Or iPartID = 89) Then   'Metrocall DBR devices
                    DeleteDBRReason()
                    Me._objDeviceBilling.UnShipMessDBR(Me._iDevice_ID)
                End If
                '*************************************************

            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Information, "Error")
            End Try
        End Sub

        '**************************************************************
        Private Sub btnClearAllParts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearAllParts.Click
            Dim iPartID As Integer
            Dim iPartTotal As Integer

            Try
                If Trim(Me.txtDevice.Text) <> "" Then
                    If MessageBox.Show("Are you sure you want to remove all parts from this device """ & Trim(Me.txtDevice.Text) & """?", "Remove All Parts", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                        Exit Sub
                    End If

                    iPartTotal = dbgParts.RowCount

                    While iPartTotal > 0
                        iPartID = CInt(dbgParts.Item(0)(4))
                        Me._objDevice.DeletePart(iPartID)

                        '*************************************************
                        '//Added by Asif
                        If (Me._iCust_ID = 1 Or Me._iCust_ID = 14) And (iPartID = 25 Or iPartID = 89) Then   'Metrocall DBR devices
                            DeleteDBRReason()
                            Me._objDeviceBilling.UnShipMessDBR(Me._iDevice_ID)
                        End If
                        '*************************************************
                        iPartTotal = dbgParts.RowCount
                    End While
                End If

            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Information, "Error")
            Finally
                Me.txtPart.Focus()
            End Try
        End Sub

        '**************************************************************
        Private Sub btnPrintDevice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintDevice.Click
            Try
                Me._objDevice.Print()
                Me.txtPart.Focus()
            Catch ex As Exception
                MsgBox("You must first scan a device in order to print it." & vbCrLf & "Tech:" & ex.Message.ToString, MsgBoxStyle.Information, "Error")
            End Try
        End Sub

        '**************************************************************
        Private Sub btnPrintTray_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintTray.Click
            Try
                Me._objDevice.Print(Trim(Me.txtTray.Text))
                Me.txtPart.Focus()
            Catch ex As Exception
                MsgBox("You must first scan a device in order to print the tray it is in." & vbCrLf & "Tech:" & ex.Message.ToString, MsgBoxStyle.Information, "Error")
            End Try
        End Sub

        '**************************************************************
        Private Sub dbgDevices_FetchRowStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles dbgDevices.FetchRowStyle
            If Not Me._dtTray Is Nothing Then
                If IsDBNull(Me._dtTray.Rows(e.Row)("Device_DateBill")) = False Then
                    e.CellStyle.BackColor = Color.LightBlue
                End If
            End If
        End Sub

        '**************************************************************
        Private Sub dbgDevices_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles dbgDevices.RowColChange
            Try
                Me.txtDevice.Text = Me.dbgDevices.Columns(2).Text
                Me.LoadDevice(Me, New KeyEventArgs(Keys.Enter))
            Catch ex As Exception

            End Try
        End Sub

        '**************************************************************
        '*************************************************
        '//Added by Asif
        'This provides a window to the user to select 
        'the DBR reason for METROCALL customer only
        '*************************************************
        Private Sub ShowDBRReasonScreen()
            Dim objDBR As New frmDBRReason()
            Dim i As Integer = 0
            Try
                'If iCust_ID = 1 Then
                With objDBR
                    .CustID = Me._iCust_ID
                    .DeviceID = Me._iDevice_ID
                    .ShowDialog()
                    'Update the DB with the selected DBR reason
                    i = .UPD
                End With
                'End If
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(objDBR) Then
                    objDBR.Dispose()
                    objDBR = Nothing
                End If

            End Try
        End Sub

        '**************************************************************
        Private Sub DeleteDBRReason()
            Dim objDBR As New frmDBRReason()
            Dim i As Integer = 0

            Try
                With objDBR
                    .CustID = Me._iCust_ID
                    .DeviceID = Me._iDevice_ID
                    i = .DeleteDBRCode()
                End With

            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(objDBR) Then
                    objDBR.Dispose()
                    objDBR = Nothing
                End If
            End Try
        End Sub

        '**************************************************************
        Private Function getBinLoc() As String
            Dim filename As String = "C:\Documents and Settings\All Users\BinLoc.txt"
            Dim objReader As StreamReader

            Try
                If File.Exists(filename) Then
                    objReader = New StreamReader(filename)
                    getBinLoc = objReader.ReadToEnd
                Else
                    getBinLoc = "NO BIN"
                End If

                Return getBinLoc
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(objReader) Then
                    objReader.Close()
                End If
            End Try
        End Function

        '**************************************************************
        Private Function setPartTransaction(ByVal tDeviceID As Long, ByVal tBillCodeID As Integer, ByVal tProdID As Integer, ByVal tUserID As Integer, ByVal tBinLoc As String, ByVal tTransAmount As Integer, ByVal tDbillID As Int32) As Boolean

            Dim tmpShift As Integer
            tmpShift = PSS.Core.[Global].ApplicationUser.IDShift
            Dim tmpEmployee As String
            tmpEmployee = PSS.Core.[Global].ApplicationUser.NumberEmp

            Dim tmpMachineName As String = System.Net.Dns.GetHostName
            If IsDBNull("tmpmachinename") = True Then tmpMachineName = ""
            If Len(Trim(tmpMachineName)) = 0 Then tmpMachineName = ""

            Dim tmpWorkDate As String = PSS.Core.[Global].ApplicationUser.Workdate
            If Len(Trim(tmpWorkDate)) < 1 Then
                MsgBox("Your user configuration is incorrect/incomplete. Please contact your direct lead to resolve this problem. Your login will not function until this is resolved.", MsgBoxStyle.Critical, "User Setup Error")
                End
            End If


            setPartTransaction = False
            If tDeviceID > 0 And tBillCodeID > 0 And tProdID > 0 And tUserID > -1 And Len(Trim(tBinLoc)) > 0 Then

                Dim tDate As String = Gui.Receiving.FormatDate(Now)

                ''*******************************
                '''Added on 06/11/2009
                '''For unbill unit, use CC ID where the part get bill
                ''*******************************
                Dim iCC_ID As Integer = PSS.Data.Buisness.Generic.GetMachineCostCenterID()
                If tTransAmount > 0 Then
                    Dim iLastBillCCID = PSS.Data.Buisness.Generic.GetLastBillCCID(tDeviceID, tBillCodeID)
                    If iLastBillCCID > 0 Then iCC_ID = iLastBillCCID
                End If
                '*******************************

                Dim strSQL As String = "INSERT INTO tparttransaction (Device_ID, BillCode_ID, Prod_ID, User_ID, Date_Rec, BinLoc, Trans_Amount, DBill_id, Shift_ID_Trans, EmployeeNo, WorkDate, MachineName, New, cc_id) " & _
                "VALUES (" & tDeviceID & ", " & tBillCodeID & ", " & tProdID & ", " & tUserID & ", '" & tDate & "', '" & tUserID & "', " & tTransAmount & ", " & tDbillID & ", " & tmpShift & ", '" & tmpEmployee & "', '" & tmpWorkDate & "', '" & tmpMachineName & "', " & IIf(tTransAmount = 1, "1", "2") & ", " & iCC_ID & ")"

                Dim blnSuccess As Boolean = PSS.Data.Production.Joins.OrderEntryUpdateDelete(strSQL)

                If blnSuccess = True Then
                    setPartTransaction = True
                Else
                    setPartTransaction = False
                End If
            End If

            Return setPartTransaction
        End Function

        '**************************************************************
        Protected Overrides Sub Finalize()
            Me._objBusinessMisc = Nothing
            _objDeviceBilling = Nothing
            MyBase.Finalize()
        End Sub

        '**************************************************************
        Private Sub btnPrintCreditCardRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintCreditCardRpt.Click
            Dim strTray_ID As String = ""

            Try
                strTray_ID = Trim(InputBox("Enter Tray ID:", "Tray ID"))

                If strTray_ID = "" Then
                    Exit Sub
                End If

                If IsNumeric(strTray_ID) = False Then
                    MessageBox.Show("Invalid Tray ID.", "Reprint Credit Card Report", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                End If

                Device.Print(CInt(strTray_ID.Trim))
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Reprint Credit Card Report", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try

        End Sub

        '**************************************************************

    End Class
End Namespace

