Option Explicit On 

Imports PSS.Data.Buisness
Imports System.Text

Namespace Gui.TracFone
    Public Class frmTriagedBox
        Inherits System.Windows.Forms.Form

        Private _strScreenName As String = ""
        Private _iMenuCust_ID As Integer = 0
        Private _objTFTriagedBox As PSS.Data.Buisness.TracFone.TFTestBuildTriagedBox
        Private _objTFTri As PSS.Data.Buisness.TracFone.Receive
        Private _TriageNTF_BillOcde_ID As Integer = 4334
        Private _TriageCOS_BillOcde_ID As Integer = 4335
        Private _TriageFUN_BillOcde_ID As Integer = 4336
        Private _UserID As Integer = PSS.Core.Global.ApplicationUser.IDuser
        Private _TriageBill_PartNum As String = "S0"
        Private _MaxBoxNumber As Integer = 90

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strScreenName As String, ByVal iCust_ID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _objTFTri = New PSS.Data.Buisness.TracFone.Receive()

            'Add any initialization after the InitializeComponent() call
            Me._strScreenName = strScreenName
            Me._iMenuCust_ID = iCust_ID
            Me._objTFTriagedBox = New PSS.Data.Buisness.TracFone.TFTestBuildTriagedBox()

        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If

                Me._objTFTriagedBox = Nothing

            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        Friend WithEvents cboDisposition As C1.Win.C1List.C1Combo
        Friend WithEvents lblMdl As System.Windows.Forms.Label
        Friend WithEvents lblDisp As System.Windows.Forms.Label
        Friend WithEvents txtBoxName As System.Windows.Forms.TextBox
        Friend WithEvents lblBx As System.Windows.Forms.Label
        Friend WithEvents lblIMEI As System.Windows.Forms.Label
        Friend WithEvents lblCount As System.Windows.Forms.Label
        Friend WithEvents cboModel As C1.Win.C1List.C1Combo
        Friend WithEvents btnRemoveDevice As System.Windows.Forms.Button
        Friend WithEvents btnReprintLabel As System.Windows.Forms.Button
        Friend WithEvents btnReopenBox As System.Windows.Forms.Button
        Friend WithEvents btnCompleteBox As System.Windows.Forms.Button
        Friend WithEvents txtSN As System.Windows.Forms.TextBox
        Friend WithEvents lstSN As System.Windows.Forms.ListBox
        Friend WithEvents btnRemoveAllDevices As System.Windows.Forms.Button
        Friend WithEvents lblBoxModelLabel As System.Windows.Forms.Label
        Friend WithEvents lblBoxModel As System.Windows.Forms.Label
        Friend WithEvents lblBoxModelID As System.Windows.Forms.Label
        Friend WithEvents lblSN As System.Windows.Forms.Label
        Friend WithEvents lblBoxID As System.Windows.Forms.Label
        Friend WithEvents pnlMaster As System.Windows.Forms.Panel
        Friend WithEvents tdgOpenBoxes As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lblOpenBox As System.Windows.Forms.Label
        Friend WithEvents btnSelectBox As System.Windows.Forms.Button
        Friend WithEvents btnClose As System.Windows.Forms.Button
        Friend WithEvents pnlOpenBox As System.Windows.Forms.Panel
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTriagedBox))
            Me.cboDisposition = New C1.Win.C1List.C1Combo()
            Me.lblMdl = New System.Windows.Forms.Label()
            Me.lblDisp = New System.Windows.Forms.Label()
            Me.txtSN = New System.Windows.Forms.TextBox()
            Me.lstSN = New System.Windows.Forms.ListBox()
            Me.txtBoxName = New System.Windows.Forms.TextBox()
            Me.lblBx = New System.Windows.Forms.Label()
            Me.lblIMEI = New System.Windows.Forms.Label()
            Me.lblCount = New System.Windows.Forms.Label()
            Me.btnRemoveDevice = New System.Windows.Forms.Button()
            Me.btnReprintLabel = New System.Windows.Forms.Button()
            Me.btnReopenBox = New System.Windows.Forms.Button()
            Me.btnCompleteBox = New System.Windows.Forms.Button()
            Me.cboModel = New C1.Win.C1List.C1Combo()
            Me.btnRemoveAllDevices = New System.Windows.Forms.Button()
            Me.lblBoxModelLabel = New System.Windows.Forms.Label()
            Me.lblBoxModel = New System.Windows.Forms.Label()
            Me.lblBoxModelID = New System.Windows.Forms.Label()
            Me.lblSN = New System.Windows.Forms.Label()
            Me.lblBoxID = New System.Windows.Forms.Label()
            Me.pnlMaster = New System.Windows.Forms.Panel()
            Me.pnlOpenBox = New System.Windows.Forms.Panel()
            Me.btnClose = New System.Windows.Forms.Button()
            Me.btnSelectBox = New System.Windows.Forms.Button()
            Me.lblOpenBox = New System.Windows.Forms.Label()
            Me.tdgOpenBoxes = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            CType(Me.cboDisposition, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboModel, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlMaster.SuspendLayout()
            Me.pnlOpenBox.SuspendLayout()
            CType(Me.tdgOpenBoxes, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'cboDisposition
            '
            Me.cboDisposition.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboDisposition.AutoCompletion = True
            Me.cboDisposition.AutoDropDown = True
            Me.cboDisposition.AutoSelect = True
            Me.cboDisposition.Caption = ""
            Me.cboDisposition.CaptionHeight = 17
            Me.cboDisposition.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboDisposition.ColumnCaptionHeight = 17
            Me.cboDisposition.ColumnFooterHeight = 17
            Me.cboDisposition.ColumnHeaders = False
            Me.cboDisposition.ContentHeight = 21
            Me.cboDisposition.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboDisposition.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboDisposition.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboDisposition.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboDisposition.EditorHeight = 21
            Me.cboDisposition.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboDisposition.ItemHeight = 15
            Me.cboDisposition.Location = New System.Drawing.Point(176, 56)
            Me.cboDisposition.MatchEntryTimeout = CType(2000, Long)
            Me.cboDisposition.MaxDropDownItems = CType(10, Short)
            Me.cboDisposition.MaxLength = 32767
            Me.cboDisposition.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboDisposition.Name = "cboDisposition"
            Me.cboDisposition.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboDisposition.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboDisposition.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboDisposition.Size = New System.Drawing.Size(136, 27)
            Me.cboDisposition.TabIndex = 2
            Me.cboDisposition.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:HotTrack;}Style3{}Inactive{ForeColor:InactiveCaptionText;Bac" & _
            "kColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{F" & _
            "oreColor:HighlightText;BackColor:Highlight;}Style9{AlignHorz:Near;}OddRow{}Recor" & _
            "dSelector{AlignImage:Center;}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1" & _
            ", 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{}Style11{}Sty" & _
            "le1{}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" N" & _
            "ame=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=" & _
            """17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 15" & _
            "6</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HSc" & _
            "rollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style9" & _
            """ /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" me" & _
            "=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Head" & _
            "ing"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inact" & _
            "iveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style8" & _
            """ /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle p" & _
            "arent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1L" & _
            "ist.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style pare" & _
            "nt=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""" & _
            "Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""N" & _
            "ormal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=" & _
            """Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Head" & _
            "ing"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><v" & _
            "ertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth></Blob>"
            '
            'lblMdl
            '
            Me.lblMdl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblMdl.Location = New System.Drawing.Point(80, 16)
            Me.lblMdl.Name = "lblMdl"
            Me.lblMdl.Size = New System.Drawing.Size(56, 23)
            Me.lblMdl.TabIndex = 11
            Me.lblMdl.Text = "Model:"
            Me.lblMdl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblDisp
            '
            Me.lblDisp.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDisp.Location = New System.Drawing.Point(80, 56)
            Me.lblDisp.Name = "lblDisp"
            Me.lblDisp.Size = New System.Drawing.Size(88, 23)
            Me.lblDisp.TabIndex = 12
            Me.lblDisp.Text = "Dispostion:"
            Me.lblDisp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtSN
            '
            Me.txtSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtSN.Location = New System.Drawing.Point(80, 96)
            Me.txtSN.Name = "txtSN"
            Me.txtSN.Size = New System.Drawing.Size(232, 26)
            Me.txtSN.TabIndex = 4
            Me.txtSN.Text = ""
            '
            'lstSN
            '
            Me.lstSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lstSN.ItemHeight = 16
            Me.lstSN.Location = New System.Drawing.Point(80, 128)
            Me.lstSN.Name = "lstSN"
            Me.lstSN.Size = New System.Drawing.Size(232, 324)
            Me.lstSN.TabIndex = 5
            '
            'txtBoxName
            '
            Me.txtBoxName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtBoxName.Location = New System.Drawing.Point(424, 16)
            Me.txtBoxName.Name = "txtBoxName"
            Me.txtBoxName.ReadOnly = True
            Me.txtBoxName.Size = New System.Drawing.Size(184, 26)
            Me.txtBoxName.TabIndex = 3
            Me.txtBoxName.Text = ""
            '
            'lblBx
            '
            Me.lblBx.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBx.Location = New System.Drawing.Point(328, 16)
            Me.lblBx.Name = "lblBx"
            Me.lblBx.Size = New System.Drawing.Size(88, 23)
            Me.lblBx.TabIndex = 13
            Me.lblBx.Text = "Box Name:"
            Me.lblBx.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblIMEI
            '
            Me.lblIMEI.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblIMEI.Location = New System.Drawing.Point(328, 112)
            Me.lblIMEI.Name = "lblIMEI"
            Me.lblIMEI.Size = New System.Drawing.Size(96, 23)
            Me.lblIMEI.TabIndex = 14
            Me.lblIMEI.Text = "IMEI Count:"
            Me.lblIMEI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblCount
            '
            Me.lblCount.BackColor = System.Drawing.SystemColors.ControlText
            Me.lblCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCount.ForeColor = System.Drawing.Color.White
            Me.lblCount.Location = New System.Drawing.Point(432, 104)
            Me.lblCount.Name = "lblCount"
            Me.lblCount.Size = New System.Drawing.Size(64, 40)
            Me.lblCount.TabIndex = 10
            Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnRemoveDevice
            '
            Me.btnRemoveDevice.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveDevice.Location = New System.Drawing.Point(336, 168)
            Me.btnRemoveDevice.Name = "btnRemoveDevice"
            Me.btnRemoveDevice.Size = New System.Drawing.Size(192, 40)
            Me.btnRemoveDevice.TabIndex = 6
            Me.btnRemoveDevice.Text = "Remove Device"
            '
            'btnReprintLabel
            '
            Me.btnReprintLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprintLabel.Location = New System.Drawing.Point(336, 280)
            Me.btnReprintLabel.Name = "btnReprintLabel"
            Me.btnReprintLabel.Size = New System.Drawing.Size(192, 40)
            Me.btnReprintLabel.TabIndex = 7
            Me.btnReprintLabel.Text = "Re-Print Label"
            '
            'btnReopenBox
            '
            Me.btnReopenBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReopenBox.Location = New System.Drawing.Point(336, 328)
            Me.btnReopenBox.Name = "btnReopenBox"
            Me.btnReopenBox.Size = New System.Drawing.Size(192, 40)
            Me.btnReopenBox.TabIndex = 8
            Me.btnReopenBox.Text = "Re-Open Box"
            '
            'btnCompleteBox
            '
            Me.btnCompleteBox.BackColor = System.Drawing.Color.DarkGreen
            Me.btnCompleteBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCompleteBox.ForeColor = System.Drawing.Color.White
            Me.btnCompleteBox.Location = New System.Drawing.Point(336, 392)
            Me.btnCompleteBox.Name = "btnCompleteBox"
            Me.btnCompleteBox.Size = New System.Drawing.Size(200, 48)
            Me.btnCompleteBox.TabIndex = 9
            Me.btnCompleteBox.Text = "Complete Box"
            '
            'cboModel
            '
            Me.cboModel.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboModel.AutoCompletion = True
            Me.cboModel.AutoDropDown = True
            Me.cboModel.AutoSelect = True
            Me.cboModel.Caption = ""
            Me.cboModel.CaptionHeight = 17
            Me.cboModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboModel.ColumnCaptionHeight = 17
            Me.cboModel.ColumnFooterHeight = 17
            Me.cboModel.ColumnHeaders = False
            Me.cboModel.ContentHeight = 21
            Me.cboModel.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboModel.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboModel.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboModel.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboModel.EditorHeight = 21
            Me.cboModel.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboModel.ItemHeight = 15
            Me.cboModel.Location = New System.Drawing.Point(144, 16)
            Me.cboModel.MatchEntryTimeout = CType(2000, Long)
            Me.cboModel.MaxDropDownItems = CType(10, Short)
            Me.cboModel.MaxLength = 32767
            Me.cboModel.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboModel.Name = "cboModel"
            Me.cboModel.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboModel.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboModel.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboModel.Size = New System.Drawing.Size(168, 27)
            Me.cboModel.TabIndex = 1
            Me.cboModel.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:HotTrack;}Style3{}Inactive{ForeColor:InactiveCaptionText;Bac" & _
            "kColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{F" & _
            "oreColor:HighlightText;BackColor:Highlight;}Style1{}OddRow{}RecordSelector{Align" & _
            "Image:Center;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;Fore" & _
            "Color:ControlText;AlignVert:Center;}Style8{}Style10{}Style11{}Style9{AlignHorz:N" & _
            "ear;}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" N" & _
            "ame=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=" & _
            """17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 15" & _
            "6</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HSc" & _
            "rollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style9" & _
            """ /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" me" & _
            "=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Head" & _
            "ing"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inact" & _
            "iveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style8" & _
            """ /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle p" & _
            "arent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1L" & _
            "ist.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style pare" & _
            "nt=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""" & _
            "Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""N" & _
            "ormal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=" & _
            """Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Head" & _
            "ing"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><v" & _
            "ertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth></Blob>"
            '
            'btnRemoveAllDevices
            '
            Me.btnRemoveAllDevices.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveAllDevices.Location = New System.Drawing.Point(336, 216)
            Me.btnRemoveAllDevices.Name = "btnRemoveAllDevices"
            Me.btnRemoveAllDevices.Size = New System.Drawing.Size(192, 37)
            Me.btnRemoveAllDevices.TabIndex = 15
            Me.btnRemoveAllDevices.Text = "Remove All Devices"
            '
            'lblBoxModelLabel
            '
            Me.lblBoxModelLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBoxModelLabel.Location = New System.Drawing.Point(328, 48)
            Me.lblBoxModelLabel.Name = "lblBoxModelLabel"
            Me.lblBoxModelLabel.Size = New System.Drawing.Size(88, 23)
            Me.lblBoxModelLabel.TabIndex = 16
            Me.lblBoxModelLabel.Text = "Box Model:"
            Me.lblBoxModelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblBoxModel
            '
            Me.lblBoxModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBoxModel.Location = New System.Drawing.Point(424, 48)
            Me.lblBoxModel.Name = "lblBoxModel"
            Me.lblBoxModel.Size = New System.Drawing.Size(184, 23)
            Me.lblBoxModel.TabIndex = 17
            Me.lblBoxModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblBoxModelID
            '
            Me.lblBoxModelID.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBoxModelID.ForeColor = System.Drawing.Color.Thistle
            Me.lblBoxModelID.Location = New System.Drawing.Point(424, 72)
            Me.lblBoxModelID.Name = "lblBoxModelID"
            Me.lblBoxModelID.Size = New System.Drawing.Size(32, 16)
            Me.lblBoxModelID.TabIndex = 18
            '
            'lblSN
            '
            Me.lblSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSN.Location = New System.Drawing.Point(24, 96)
            Me.lblSN.Name = "lblSN"
            Me.lblSN.Size = New System.Drawing.Size(56, 23)
            Me.lblSN.TabIndex = 19
            Me.lblSN.Text = "IMEI:"
            Me.lblSN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblBoxID
            '
            Me.lblBoxID.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBoxID.ForeColor = System.Drawing.Color.Thistle
            Me.lblBoxID.Location = New System.Drawing.Point(608, 24)
            Me.lblBoxID.Name = "lblBoxID"
            Me.lblBoxID.Size = New System.Drawing.Size(48, 16)
            Me.lblBoxID.TabIndex = 20
            '
            'pnlMaster
            '
            Me.pnlMaster.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtSN, Me.lblBoxModelID, Me.btnRemoveDevice, Me.lblSN, Me.lblBoxID, Me.cboDisposition, Me.btnReopenBox, Me.cboModel, Me.txtBoxName, Me.btnRemoveAllDevices, Me.lstSN, Me.lblBx, Me.lblMdl, Me.lblIMEI, Me.lblBoxModelLabel, Me.lblDisp, Me.lblCount, Me.btnCompleteBox, Me.btnReprintLabel, Me.lblBoxModel})
            Me.pnlMaster.Location = New System.Drawing.Point(8, 8)
            Me.pnlMaster.Name = "pnlMaster"
            Me.pnlMaster.Size = New System.Drawing.Size(664, 464)
            Me.pnlMaster.TabIndex = 21
            '
            'pnlOpenBox
            '
            Me.pnlOpenBox.BackColor = System.Drawing.Color.LightSteelBlue
            Me.pnlOpenBox.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnClose, Me.btnSelectBox, Me.lblOpenBox, Me.tdgOpenBoxes})
            Me.pnlOpenBox.Location = New System.Drawing.Point(8, 480)
            Me.pnlOpenBox.Name = "pnlOpenBox"
            Me.pnlOpenBox.Size = New System.Drawing.Size(656, 176)
            Me.pnlOpenBox.TabIndex = 22
            '
            'btnClose
            '
            Me.btnClose.BackColor = System.Drawing.Color.DarkSlateGray
            Me.btnClose.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClose.ForeColor = System.Drawing.Color.White
            Me.btnClose.Location = New System.Drawing.Point(504, 6)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(128, 32)
            Me.btnClose.TabIndex = 152
            Me.btnClose.Text = "Close/Skip"
            '
            'btnSelectBox
            '
            Me.btnSelectBox.BackColor = System.Drawing.Color.DarkSlateGray
            Me.btnSelectBox.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSelectBox.ForeColor = System.Drawing.Color.White
            Me.btnSelectBox.Location = New System.Drawing.Point(120, 6)
            Me.btnSelectBox.Name = "btnSelectBox"
            Me.btnSelectBox.Size = New System.Drawing.Size(136, 32)
            Me.btnSelectBox.TabIndex = 151
            Me.btnSelectBox.Text = "Select Box"
            '
            'lblOpenBox
            '
            Me.lblOpenBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblOpenBox.ForeColor = System.Drawing.Color.Blue
            Me.lblOpenBox.Location = New System.Drawing.Point(8, 6)
            Me.lblOpenBox.Name = "lblOpenBox"
            Me.lblOpenBox.Size = New System.Drawing.Size(104, 24)
            Me.lblOpenBox.TabIndex = 143
            Me.lblOpenBox.Text = "Open Box"
            '
            'tdgOpenBoxes
            '
            Me.tdgOpenBoxes.AllowUpdate = False
            Me.tdgOpenBoxes.AlternatingRows = True
            Me.tdgOpenBoxes.BackColor = System.Drawing.Color.GhostWhite
            Me.tdgOpenBoxes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tdgOpenBoxes.CaptionHeight = 17
            Me.tdgOpenBoxes.FetchRowStyles = True
            Me.tdgOpenBoxes.FilterBar = True
            Me.tdgOpenBoxes.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgOpenBoxes.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgOpenBoxes.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.tdgOpenBoxes.Location = New System.Drawing.Point(10, 40)
            Me.tdgOpenBoxes.Name = "tdgOpenBoxes"
            Me.tdgOpenBoxes.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgOpenBoxes.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgOpenBoxes.PreviewInfo.ZoomFactor = 75
            Me.tdgOpenBoxes.RowHeight = 15
            Me.tdgOpenBoxes.Size = New System.Drawing.Size(622, 120)
            Me.tdgOpenBoxes.TabIndex = 142
            Me.tdgOpenBoxes.Text = "C1TrueDBGrid1"
            Me.tdgOpenBoxes.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Style1{}Normal{Font:Tahoma, 8.25pt;}HighlightRow{ForeColo" & _
            "r:HighlightText;BackColor:Highlight;}Style14{}OddRow{}RecordSelector{AlignImage:" & _
            "Center;}Style15{}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;F" & _
            "oreColor:ControlText;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}" & _
            "Style12{}Style13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView" & _
            " Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" " & _
            "ColumnFooterHeight=""17"" FetchRowStyles=""True"" FilterBar=""True"" MarqueeStyle=""Dot" & _
            "tedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=" & _
            """1"" HorizontalScrollGroup=""1""><Height>118</Height><CaptionStyle parent=""Style2"" " & _
            "me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""" & _
            "EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><Footer" & _
            "Style parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><H" & _
            "eadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightR" & _
            "ow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle pa" & _
            "rent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Sty" & _
            "le11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me" & _
            "=""Style1"" /><ClientRect>0, 0, 620, 118</ClientRect><BorderSide>0</BorderSide><Bo" & _
            "rderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedSty" & _
            "les><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style " & _
            "parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style par" & _
            "ent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style pare" & _
            "nt=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style pare" & _
            "nt=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""H" & _
            "eading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style par" & _
            "ent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1" & _
            "</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><Cl" & _
            "ientArea>0, 0, 620, 118</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14""" & _
            " /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'frmTriagedBox
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.Lavender
            Me.ClientSize = New System.Drawing.Size(696, 502)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlOpenBox, Me.pnlMaster})
            Me.Name = "frmTriagedBox"
            Me.Text = "frmTriagedBox"
            CType(Me.cboDisposition, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboModel, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlMaster.ResumeLayout(False)
            Me.pnlOpenBox.ResumeLayout(False)
            CType(Me.tdgOpenBoxes, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region
        '******************************************************************
        Private Sub frmTriagedBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dtModel, dtDisposition, dtOpenboxes As DataTable
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn

            Try
                Me.lblCount.Text = "0"
                Me.pnlMaster.Enabled = True
                Me.pnlOpenBox.Visible = False
                Me.btnReopenBox.Visible = False

                PSS.Core.Highlight.SetHighLight(Me)

                'Get Tracfone Model list
                dtModel = Me._objTFTriagedBox.GetTracfoneCosmeticModels(True)
                Misc.PopulateC1DropDownList(Me.cboModel, dtModel, "Model_Desc", "Model_ID")
                Me.cboModel.SelectedValue = 0
                Me.cboModel.Focus()

                'Get Tracfone Disposition list
                dtDisposition = Me._objTFTri.GetTracfoneDispostions(True)
                Misc.PopulateC1DropDownList(Me.cboDisposition, dtDisposition, "Disposition", "Disp_ID")
                Me.cboDisposition.SelectedValue = 0

                'Load Open Boxes if any
                dtOpenboxes = Me._objTFTriagedBox.GetOpenBoxes
                If dtOpenboxes.Rows.Count > 0 Then
                    Me.pnlMaster.Visible = False
                    Me.pnlOpenBox.Visible = True
                    Me.pnlOpenBox.Top = Me.Height / 2 - Me.pnlOpenBox.Height / 2
                    Me.pnlOpenBox.Left = Me.Width / 2 - Me.pnlOpenBox.Width / 2
                    Me.tdgOpenBoxes.DataSource = dtOpenboxes.DefaultView
                    With Me.tdgOpenBoxes
                        For Each dbgc In .Splits(0).DisplayColumns
                            dbgc.Locked = True
                            dbgc.AutoSize()
                        Next dbgc
                        .Splits(0).DisplayColumns("WB_ID").Width = 0
                    End With
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmTriagedBox_Load", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '******************************************************************
        Private Sub GetCorrectModelForBox(ByVal sender As Object, ByVal e As System.EventArgs) _
                    Handles cboModel.Change, cboDisposition.Change, cboModel.Click, cboDisposition.Click, cboModel.Leave, cboDisposition.Leave
            Dim dtModels As DataTable
            Dim strModel As String = ""
            Dim iModel_ID As Integer = 0

            Try
                Me.lblBoxModel.Text = "" : Me.lblBoxModelID.Text = ""

                If cboModel.SelectedValue > 0 AndAlso cboDisposition.SelectedValue > 0 Then
                    Select Case cboDisposition.SelectedValue
                        Case 3 'FUN
                            'strModel = cboModel.SelectedText.Trim & "_FUN" 'cboModel.SelectedText does not work always
                            strModel = Me.cboModel.DataSource.Table.Select("Model_ID = " & Me.cboModel.SelectedValue)(0)("Model_Desc")
                            strModel &= "_FUN"
                            dtModels = Me._objTFTriagedBox.GetTracfoneAllModelsOrOneModel(False, strModel)
                            If dtModels.Rows.Count = 1 Then
                                iModel_ID = dtModels.Rows(0).Item("Model_ID")
                                Me.lblBoxModel.Text = strModel
                                Me.lblBoxModelID.Text = iModel_ID
                            ElseIf dtModels.Rows.Count > 1 Then
                                MessageBox.Show("Found a duplicate model '" & strModel & "'", "Model", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Else
                                MessageBox.Show("Can't find model '" & strModel & "'", "Model", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            End If
                        Case 4 'COS
                            'strModel = cboModel.SelectedText 'cboModel.SelectedText does not work always
                            strModel = Me.cboModel.DataSource.Table.Select("Model_ID = " & Me.cboModel.SelectedValue)(0)("Model_Desc")
                            iModel_ID = cboModel.SelectedValue
                            Me.lblBoxModel.Text = strModel
                            Me.lblBoxModelID.Text = iModel_ID
                        Case 5 'NTF
                            'strModel = cboModel.SelectedText.Trim & "X" 'cboModel.SelectedText does not work always
                            strModel = Me.cboModel.DataSource.Table.Select("Model_ID = " & Me.cboModel.SelectedValue)(0)("Model_Desc")
                            strModel &= "X"
                            dtModels = Me._objTFTriagedBox.GetTracfoneAllModelsOrOneModel(False, strModel)
                            If dtModels.Rows.Count = 1 Then
                                iModel_ID = dtModels.Rows(0).Item("Model_ID")
                                Me.lblBoxModel.Text = strModel
                                Me.lblBoxModelID.Text = iModel_ID
                            ElseIf dtModels.Rows.Count > 1 Then
                                MessageBox.Show("Found a duplicate model '" & strModel & "'", "Model", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Else
                                MessageBox.Show("Can't find model '" & strModel & "'", "Model", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            End If
                    End Select
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub


        '******************************************************************
        Private Sub txtSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyUp
            Dim model As String = ""
            Dim iModel As Integer = 0
            Dim disposition As String = ""
            Dim iDisp As Integer = 0
            Dim serialNum As String = ""
            Dim imei As Integer = 0
            Dim boxID As String = ""
            Dim dt As DataTable

            Try
                If e.KeyCode = Keys.Enter AndAlso Me.txtSN.Text.Trim.Length > 0 Then
                    ProcessSN()
                End If


                'If cboModel.SelectedIndex > 0 Then
                '    If cboDisposition.SelectedIndex > 0 Then
                '        'validate SN
                '        model = cboModel.SelectedText.ToString
                '        iModel = cboModel.SelectedValue
                '        disposition = cboDisposition.SelectedText.ToString
                '        iDisp = cboDisposition.SelectedValue
                '        serialNum = txtSN.Text.ToString
                '        imei = CInt(Me.lblCount.Text.ToString)

                '        If Me._objTFTri.validateSN(serialNum, model, disposition) = True Then
                '            lstSN.Items.Add(serialNum)
                '            imei = imei + 1
                '            lblCount.Text = imei.ToString
                '            txtSN.Clear()

                '            If Me.txtBoxName.Text.Length = 0 Then
                '                'Gnerate Box Name
                '                dt = Me._objTFTri.CreateTriagedBoxID(iModel, iDisp)
                '                boxID = dt.Rows(0)("BoxID").ToString.Trim
                '                txtBoxName.Text = boxID
                '            End If
                '        Else
                '            MessageBox.Show("The device does not match the model or disposition of this box.", "Serial Number", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                '        End If

                '    Else
                '        MessageBox.Show("A disposition must be selected to add a device.", "Serial Number", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                '    End If

                'Else
                '    MessageBox.Show("A model must be selected to add a device.", "Serial Number", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                'End If


            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '******************************************************************
        Private Sub ProcessSN()
            Dim dtTriagedDevice As DataTable
            Dim strSN As String = Me.txtSN.Text.Trim
            Dim i As Integer = 0
            Dim dtBox As DataTable
            Dim iDevice_ID As Integer = 0
            Dim strWorkstation As String = ""
            Dim objModelManuf As PSS.Data.Buisness.ModManuf
            Dim objTFMisc As Data.Buisness.TracFone.clsMisc
            Dim strMsg As String = ""
            Dim iTriage_BillCode_ID As Integer = 0


            Try
                If Not Me.cboModel.SelectedValue > 0 Then
                    MessageBox.Show("A model must be selected.", "Build Triage Box", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.cboModel.Focus()
                ElseIf Not Me.cboDisposition.SelectedValue > 0 Then
                    MessageBox.Show("A disposition must be selected.", "Build Triage Box", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.cboDisposition.Focus()
                ElseIf Me.lblBoxModel.Text.Trim.Length = 0 Then
                    MessageBox.Show("No box model.", "Build Triage Box", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ElseIf Me.lblBoxModelID.Text.Trim.Length = 0 Then
                    MessageBox.Show("No box model_ID.", "Build Triage Box", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ElseIf Not CInt(Me.lblBoxModelID.Text) > 0 Then
                    MessageBox.Show("Invalid model_ID.", "Build Triage Box", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ElseIf Not strSN.Length > 0 Then
                    MessageBox.Show("No IMEI SN.", "Build Triage Box", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtSN.SelectAll() : Me.txtSN.Focus()
                Else

                    If CInt(Me.lblCount.Text) >= Me._MaxBoxNumber Then
                        MessageBox.Show("Reach the max device number " & Me._MaxBoxNumber & " in the box. Can't add.", "Build Triage Box", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Me.txtSN.Text = "" : Me.txtSN.SelectAll() : Me.txtSN.Focus()
                        Exit Sub
                    End If

                    'Check dup SN in the list
                    For i = 0 To Me.lstSN.Items.Count - 1
                        'If Me.lstSN.Items(i).ToString.Trim.ToUpper = strSN.Trim.ToUpper Then 'not work
                        If CType(Me.lstSN.Items(i), DataRowView).Item("Device_SN").ToString().Trim.ToUpper = strSN.Trim.ToUpper Then
                            MsgBox("This device is already scanned in. Try another one.", MsgBoxStyle.Information, "Build Triage Box")
                            Me.txtSN.SelectAll() : Me.txtSN.Focus()
                            Exit Sub
                        End If
                    Next

                    'Get device data
                    dtTriagedDevice = Me._objTFTriagedBox.GetTriagedDevice(strSN)
                    If dtTriagedDevice.Rows.Count = 0 Then
                        MessageBox.Show("Can't find this triaged device '" & strSN & "'.", "Build Triage Box", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Me.txtSN.SelectAll() : Me.txtSN.Focus()
                    ElseIf dtTriagedDevice.Rows.Count > 1 Then
                        MessageBox.Show("Found a duplicate triaged device '" & strSN & "'. See IT.", "Build Triage Box", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Me.txtSN.SelectAll() : Me.txtSN.Focus()
                    ElseIf Not dtTriagedDevice.Rows(0).Item("IsValidWorkstation") = "Yes" Then
                        MessageBox.Show("Not a triaged device.", "Build Triage Box", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Me.txtSN.SelectAll() : Me.txtSN.Focus()
                    ElseIf Not dtTriagedDevice.Rows(0).Item("IsModelMatched") = "Yes" Then
                        MessageBox.Show("Triaged model doesn't match device model. See IT.", "Build Triage Box", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    ElseIf Not dtTriagedDevice.Rows(0).Item("Model_ID") = Me.lblBoxModelID.Text Then
                        MessageBox.Show("The device is not the model '" & Me.lblBoxModel.Text & "'. Can't add.", "Build Triage Box", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    ElseIf Not dtTriagedDevice.Rows(0).Item("BoxType") = Me.cboDisposition.DataSource.Table.Select("Disp_ID = " & Me.cboDisposition.SelectedValue)(0)("Disposition") Then
                        MessageBox.Show("Device doesn't belong to this disposition '" & Me.cboDisposition.DataSource.Table.Select("Disp_ID = " & Me.cboDisposition.SelectedValue)(0)("Disposition") & "'.", "Build Triage Box", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Me.txtSN.SelectAll() : Me.txtSN.Focus()
                    Else

                        'First SN scan, no box defined yet, so create the box
                        If Me.lstSN.Items.Count = 0 AndAlso Me.txtBoxName.Text.Trim.Length = 0 Then
                            dtBox = Me._objTFTriagedBox.CreateTriagedBoxID(Me.lblBoxModelID.Text, dtTriagedDevice.Rows(0).Item("FuncRep"), dtTriagedDevice.Rows(0).Item("PrefixBoxName"), "Triage Box")
                            If dtBox.Rows.Count = 0 Then
                                MessageBox.Show("No box data. Failed to create new box. See IT.", "Build Triage Box", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                Exit Sub
                            ElseIf dtBox.Rows.Count > 1 Then
                                MessageBox.Show("Duplicate box name. See IT.", "Build Triage Box", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                Exit Sub
                            Else
                                Me.txtBoxName.Text = dtBox.Rows(0).Item("BoxID")
                                Me.lblBoxID.Text = dtBox.Rows(0).Item("wb_ID")
                            End If
                        End If

                        'Ready to prcoess SN------------------------------------------------------
                        objModelManuf = New PSS.Data.Buisness.ModManuf()
                        objTFMisc = New Data.Buisness.TracFone.clsMisc()

                        'Get correct workstation
                        If cboDisposition.SelectedValue = 3 Then   'FUN
                            strWorkstation = "BER SCREEN"
                        Else
                            If objModelManuf.IsKillSwitchModel(dtTriagedDevice.Rows(0).Item("Model_ID")) AndAlso cboDisposition.SelectedValue = 4 Then   'COS
                                strWorkstation = "SW SCREEN"
                            ElseIf objTFMisc.IsBuffable(dtTriagedDevice.Rows(0).Item("Model_ID")) Then
                                strWorkstation = "PRE-BUFF"
                            Else
                                strWorkstation = "WH-WIP"
                            End If
                        End If
                        If cboDisposition.SelectedValue = 5 Then  'NTF
                            strWorkstation = "FQA"
                        End If

                        'Update 
                        strMsg = ""
                        iDevice_ID = dtTriagedDevice.Rows(0).Item("Device_ID")
                        If Me._objTFTriagedBox.UpdateTriagedBoxDevice(iDevice_ID, strSN, strWorkstation, Me.lblBoxID.Text, Me.txtBoxName.Text, dtTriagedDevice.Rows(0).Item("FuncRep"), strMsg) Then
                            'add labor charge for triaged device=========================================================
                            'Get correct billcode_ID
                            Select Case cboDisposition.SelectedValue
                                Case 3 'FUN
                                    iTriage_BillCode_ID = Me._TriageFUN_BillOcde_ID
                                Case 4 'COS
                                    iTriage_BillCode_ID = Me._TriageCOS_BillOcde_ID
                                Case 5 'NTF
                                    iTriage_BillCode_ID = Me._TriageNTF_BillOcde_ID
                            End Select

                            Dim objTFBilling As New PSS.Data.Buisness.TracFone.TFBillingData()
                            Dim vReceivingLaborCharge As Single = objTFBilling.getAdditionalLaborCharge(PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, iTriage_BillCode_ID)
                            i = objTFBilling.InsertUpdateAddionalCharges(iDevice_ID, iTriage_BillCode_ID, vReceivingLaborCharge, _
                                                                         Me._TriageBill_PartNum, Format(Now, "yyyy-MM-dd HH:mm:ss"), Me._UserID)
                            If i = 1 Then 'sucessed
                                BindDeviceData(Me.lblBoxID.Text)
                                Me.cboDisposition.Enabled = False : Me.cboModel.Enabled = False
                                Me.txtSN.Text = "" : Me.txtSN.SelectAll() : Me.txtSN.Focus()
                            Else
                                MessageBox.Show("Failed to add labor charge. " & Environment.NewLine & strMsg & Environment.NewLine & "Don't process it and see IT..", "Build Triage Box", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            End If
                        Else
                            MessageBox.Show("Failed to update this device '" & strSN & "'." & Environment.NewLine & strMsg & Environment.NewLine & "Don't process it and see IT.", "Build Triage Box", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        End If
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '******************************************************************
        Private Sub BindDeviceData(ByVal iWB_ID As Integer)
            Dim dt As DataTable

            Try
                Me.lstSN.DataSource = Nothing
                dt = Me._objTFTriagedBox.GetBoxedDevices(iWB_ID)
                Me.lstSN.DataSource = dt.DefaultView
                Me.lstSN.ValueMember = dt.Columns("device_id").ToString
                Me.lstSN.DisplayMember = dt.Columns("device_sn").ToString

                Me.lblCount.Text = Me.lstSN.Items.Count

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "BindDeviceData", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '******************************************************************
        Private Sub PopulateSelectedBox()
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
            Dim iRow As Integer = 0
            Dim iWB_ID As Integer = 0
            Dim iBox_Model_ID As Integer = 0
            Dim iDisposition_ID As Integer = 0
            Dim strBoxName As String = ""
            Dim strBox_Model As String = ""
            Dim strCombo_COS_Model As String = ""
            Dim iCombo_COS_Model_ID As Integer = 0
            Dim strStatus As String = ""

            Try

                With Me.tdgOpenBoxes
                    For Each iRow In .SelectedRows
                        strStatus = .Columns("Status").CellText(iRow)
                        If Not strStatus.Trim.ToUpper = "Valid".ToUpper Then
                            MessageBox.Show("Not a valid box.", "Open Box", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If

                        'Ready to go----------------------------------------------------------------------------------------
                        strBoxName = .Columns("Box_Name").CellText(iRow)
                        iWB_ID = .Columns("WB_ID").CellText(iRow)
                        iBox_Model_ID = .Columns("Model_ID").CellText(iRow)
                        strBox_Model = .Columns("Box_Model").CellText(iRow)
                        iDisposition_ID = .Columns("Disp_ID").CellText(iRow)

                        Select Case iDisposition_ID
                            Case 2, 3 'FUN
                                strCombo_COS_Model = strBox_Model.Trim.Substring(0, strBox_Model.Trim.Length - "_FUN".Length)
                            Case 4 'COS
                                strCombo_COS_Model = strBox_Model.Trim
                            Case 5 'NTF
                                strCombo_COS_Model = strBox_Model.Trim.Substring(0, strBox_Model.Trim.Length - "X".Length)
                        End Select

                        iCombo_COS_Model_ID = Me.cboModel.DataSource.Table.Select("Model_Desc = '" & strCombo_COS_Model & "'")(0)("Model_ID")

                        If iCombo_COS_Model_ID > 0 Then
                            Me.cboDisposition.SelectedValue = 0
                            Me.cboModel.SelectedValue = 0
                            If iDisposition_ID = 2 Then iDisposition_ID = 3 'SOF is treated as FUN
                            Me.cboDisposition.SelectedValue = iDisposition_ID
                            Me.cboModel.SelectedValue = iCombo_COS_Model_ID

                            If Me.lblBoxModel.Text = strBox_Model AndAlso Me.lblBoxModelID.Text = iBox_Model_ID Then
                                Me.txtBoxName.Text = strBoxName
                                Me.lblBoxID.Text = iWB_ID
                                Me.BindDeviceData(iWB_ID)
                                Me._objTFTriagedBox.ResetBoxOpen(iWB_ID)
                                Me.cboModel.Enabled = False
                                Me.cboDisposition.Enabled = False
                                Me.pnlMaster.Visible = True : Me.pnlOpenBox.Visible = False
                                Me.txtSN.SelectAll() : Me.txtSN.Focus()
                            Else
                                MessageBox.Show("Failed to load box data. Don't process it and see IT.", "Open Box", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            End If
                        Else
                            MessageBox.Show("Failed to load box data. Don't process it and see IT.", "Open Box", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        End If


                        'send order no to clipboard
                        'System.Windows.Forms.Clipboard.SetDataObject(strBoxName , False)
                        Exit For
                    Next
                End With



            Catch ex As Exception
                MessageBox.Show(ex.ToString, "PopulateSelectOrderToFill", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Finally
                '    Generic.DisposeDT(dt)
            End Try

        End Sub

        '******************************************************************
        Private Sub btnRemoveDevice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveDevice.Click
            Dim message, title, defaultValue As String
            Dim strSN As String = ""
            Dim row As DataRow
            Dim iSODetails_ID As Integer = 0
            Dim i As Integer = 0
            Dim iDevice_ID As Integer = 0
            Dim strMsg As String = ""
            Dim iBillCode_ID As Integer = 0

            Try
                If Me.lstSN.Items.Count > 0 Then
                    message = "Enter/scan a device IMEI:"
                    title = "IMEI"
                    defaultValue = ""
                    ' Display message, title, and default value.
                    strSN = InputBox(message, title, defaultValue)
                End If

                If strSN.Trim.Length > 0 Then
                    For i = 0 To Me.lstSN.Items.Count - 1
                        If CType(Me.lstSN.Items(i), DataRowView).Item("Device_SN").ToString().Trim.ToUpper = strSN.Trim.ToUpper Then
                            iDevice_ID = CType(Me.lstSN.Items(i), DataRowView).Item("Device_ID")
                            Select Case cboDisposition.SelectedValue
                                Case 3 'FUN
                                    iBillCode_ID = Me._TriageFUN_BillOcde_ID
                                Case 4 'COS
                                    iBillCode_ID = Me._TriageCOS_BillOcde_ID
                                Case 5 'NTF
                                    iBillCode_ID = Me._TriageNTF_BillOcde_ID
                            End Select

                            If Me._objTFTriagedBox.UndoDevicesFromTriagedBox(iDevice_ID.ToString, iBillCode_ID, strMsg) Then
                                Me.BindDeviceData(Me.lblBoxID.Text)
                                Me.txtSN.SelectAll() : Me.txtSN.Focus()
                            Else
                                MessageBox.Show(strMsg, " btnRemoveDevice_Click", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                            Exit Sub
                        End If
                    Next
                    MessageBox.Show("Not found. Deleted nothing.", " btnRemoveDevice_Click", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, " btnRemoveDevice_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************
        Private Sub btnRemoveAllDevices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveAllDevices.Click
            Dim row As DataRow
            Dim iSODetails_ID As Integer = 0
            Dim i As Integer = 0
            Dim strDevice_IDs As String = ""
            Dim strMsg As String = ""
            Dim iBillCode_ID As Integer = 0

            Try
                If Not Me.lstSN.Items.Count > 0 Then Exit Sub

                Dim result As Integer = MessageBox.Show("Do you want to remove (undo) all devices?", "Undo all devics from the box", MessageBoxButtons.YesNo)
                If result = DialogResult.Yes Then
                    For i = 0 To Me.lstSN.Items.Count - 1
                        If strDevice_IDs.Trim.Length = 0 Then
                            strDevice_IDs = CType(Me.lstSN.Items(i), DataRowView).Item("Device_ID").ToString().Trim()
                        Else
                            strDevice_IDs &= "," & CType(Me.lstSN.Items(i), DataRowView).Item("Device_ID").ToString().Trim()
                        End If
                    Next
                    If strDevice_IDs.Length > 0 Then
                        Select Case cboDisposition.SelectedValue
                            Case 3 'FUN
                                iBillCode_ID = Me._TriageFUN_BillOcde_ID
                            Case 4 'COS
                                iBillCode_ID = Me._TriageCOS_BillOcde_ID
                            Case 5 'NTF
                                iBillCode_ID = Me._TriageNTF_BillOcde_ID
                        End Select

                        If Me._objTFTriagedBox.UndoDevicesFromTriagedBox(strDevice_IDs, iBillCode_ID, strMsg) Then
                            Me.BindDeviceData(Me.lblBoxID.Text)
                            Me.txtSN.SelectAll() : Me.txtSN.Focus()
                        Else
                            MessageBox.Show(strMsg, "btnRemoveAllDevices_Click", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Else
                        MessageBox.Show("Can't find device_IDs.", "btnRemoveAllDevices_Click", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRemoveAllDevices_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************
        Private Sub btnReprintLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprintLabel.Click
            Dim strBoxName As String = ""
            Dim dt As DataTable

            Try
                strBoxName = InputBox("Enter Box Name:").Trim

                If strBoxName.Length = 0 Then Exit Sub

                dt = Me._objTFTriagedBox.GetCompletedTriageBoxBeforeClose(0, strBoxName)
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("Can't find the box data.", "btnCompleteBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    If dt.Rows(0).Item("Closed") = 0 Then
                        MessageBox.Show("The box is open. No label print.", "btnCompleteBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        Me._objTFTriagedBox.RePrintTriageBox(dt.Rows(0).Item("WB_ID"), dt.Rows(0).Item("WH_Box_Name"), _
                                                                    dt.Rows(0).Item("Triaged_Model"), dt.Rows.Count, dt.Rows(0).Item("BoxType"), "OW")
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboBoxType_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '******************************************************************
        Private Sub btnReopenBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReopenBox.Click
            Dim strBoxName As String = ""
            Dim dtBox As DataTable
            Dim IsOpenBox As Boolean = False
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn

            Try
                If Me.lstSN.Items.Count > 0 Then
                    MessageBox.Show("Can't re-open a box when device listbox has devices.", "btnCompleteBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    strBoxName = InputBox("Enter Box Name:").Trim
                    If strBoxName.Length = 0 Then Exit Sub

                    'Load Box   
                    dtBox = Me._objTFTriagedBox.GetReopenTriageBox(strBoxName, IsOpenBox)

                    If dtBox.Rows.Count > 0 Then
                        If Not IsOpenBox Then 'Box is closed
                            Dim result As Integer = MessageBox.Show("This box has been closed. Do you want to open it?", "Re-open box", MessageBoxButtons.YesNo)
                            If result = DialogResult.Yes Then
                                Me.pnlMaster.Visible = False
                                Me.pnlOpenBox.Visible = True
                                Me.pnlOpenBox.Top = Me.Height / 2 - Me.pnlOpenBox.Height / 2
                                Me.pnlOpenBox.Left = Me.Width / 2 - Me.pnlOpenBox.Width / 2
                                Me.tdgOpenBoxes.DataSource = dtBox.DefaultView
                                With Me.tdgOpenBoxes
                                    For Each dbgc In .Splits(0).DisplayColumns
                                        dbgc.Locked = True
                                        dbgc.AutoSize()
                                    Next dbgc
                                    .Splits(0).DisplayColumns("WB_ID").Width = 0
                                End With
                            End If
                        Else 'open box
                            Me.pnlMaster.Visible = False
                            Me.pnlOpenBox.Visible = True
                            Me.pnlOpenBox.Top = Me.Height / 2 - Me.pnlOpenBox.Height / 2
                            Me.pnlOpenBox.Left = Me.Width / 2 - Me.pnlOpenBox.Width / 2
                            Me.tdgOpenBoxes.DataSource = dtBox.DefaultView
                            With Me.tdgOpenBoxes
                                For Each dbgc In .Splits(0).DisplayColumns
                                    dbgc.Locked = True
                                    dbgc.AutoSize()
                                Next dbgc
                                .Splits(0).DisplayColumns("WB_ID").Width = 0
                            End With
                        End If
                    Else
                        MessageBox.Show("Can't found this box '" & strBoxName & "' in the system.", "btnCompleteBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnReopenBox", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '******************************************************************
        Private Sub btnCompleteBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompleteBox.Click
            Dim strBoxName As String = ""
            Dim funcRep As Integer = 0
            Dim model As String = ""
            Dim dt As DataTable

            Try
                If lstSN.Items.Count > 0 Then
                    dt = Me._objTFTriagedBox.GetCompletedTriageBoxBeforeClose(Me.lblBoxID.Text, "")
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("Can't find the box data. See IT.", "btnCompleteBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ElseIf Not dt.Rows.Count = Me.lblCount.Text Then
                        MessageBox.Show("Device count in system does not match the IMEI count.", "btnCompleteBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ElseIf Not lstSN.Items.Count = Me.lblCount.Text Then
                        MessageBox.Show("Device count in listbox does not match the IMEI count.", "btnCompleteBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        Me._objTFTriagedBox.CloseAndPrintTriageBox(Me.lblBoxID.Text, Me.txtBoxName.Text, Me.lblBoxModel.Text, Me.lblCount.Text, dt.Rows(0).Item("BoxType"), "OW")
                        Me.txtBoxName.Text = ""
                        Me.lblBoxID.Text = 0
                        Me.lblBoxModel.Text = ""
                        Me.txtSN.Text = ""
                        Me.lblBoxModelID.Text = 0
                        Me.lstSN.DataSource = Nothing
                        Me.lstSN.Items.Clear()
                        Me.lblCount.Text = 0
                        Me.cboModel.Enabled = True
                        Me.cboDisposition.Enabled = True
                        Me.cboDisposition.SelectedValue = 0
                        Me.cboDisposition.Focus()
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnCompleteBox", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '******************************************************************
        Private Sub btnSelectBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectBox.Click
            Me.PopulateSelectedBox()
        End Sub

        '******************************************************************
        Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Try
                Me.pnlOpenBox.Visible = False
                Me.pnlMaster.Visible = True

            Catch ex As Exception
                MessageBox.Show(ex.ToString, " btnClose_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub


    End Class
End Namespace