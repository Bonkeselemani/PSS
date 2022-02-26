Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.Technician

    Public Class frmCollectRepairFailCodes
        Inherits System.Windows.Forms.Form

        Public _iSymCodeID As Integer = 0
        Public _iRepCodeID As Integer = 0
        Public _iFailcodeID As Integer = 0
        Public _booCancel As Boolean = True
        Private _strCSN As String = ""
        Private _iSjugID, _iSoftVerID As Integer
        Private _iManufID As Integer = 0
        Private _iModelID As Integer = 0
        Private _iProdID As Integer = 0
        Private _iBillcodeID As Integer = 0
        Private _iDeviceID As Integer = 0
        Private _strIMEI As String = ""
        Private _iRepairLevel As Integer = 0
        Private _booReplacePart, _booReflow As Boolean
        Private _strPartNumber As String = ""

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal iManufID As Integer, _
                       ByVal iModelID As Integer, _
                       ByVal iProdID As Integer, _
                       ByVal iBillcodeID As Integer, _
                       ByVal booReplacePart As Boolean, _
                       ByVal booReflow As Boolean, _
                       ByVal iDeviceID As Integer, _
                       ByVal strIMEI As String, _
                       Optional ByVal iRepairLevel As Integer = 0, _
                       Optional ByVal strPartNumber As String = "")
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _iManufID = iManufID
            _iModelID = iModelID
            _iProdID = iProdID
            _booReplacePart = booReplacePart
            _booReflow = booReflow
            _iBillcodeID = iBillcodeID
            _strPartNumber = strPartNumber
            Me._iDeviceID = iDeviceID
            _strIMEI = strIMEI
            Me._iRepairLevel = iRepairLevel
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
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents cboFailCodes As C1.Win.C1List.C1Combo
        Friend WithEvents cboRepairCodes As C1.Win.C1List.C1Combo
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents btnOK As System.Windows.Forms.Button
        Friend WithEvents grbFailCoderepCode As System.Windows.Forms.GroupBox
        Friend WithEvents grbESNCSN As System.Windows.Forms.GroupBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents btnChangeESN As System.Windows.Forms.Button
        Friend WithEvents txtESN As System.Windows.Forms.TextBox
        Friend WithEvents gbMData As System.Windows.Forms.GroupBox
        Friend WithEvents cboSofVer As C1.Win.C1List.C1Combo
        Friend WithEvents cboSjugNo As C1.Win.C1List.C1Combo
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents btnEditSjugSoft As System.Windows.Forms.Button
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents cboSymtomCodes As C1.Win.C1List.C1Combo
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCollectRepairFailCodes))
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.grbFailCoderepCode = New System.Windows.Forms.GroupBox()
            Me.cboSymtomCodes = New C1.Win.C1List.C1Combo()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.cboFailCodes = New C1.Win.C1List.C1Combo()
            Me.cboRepairCodes = New C1.Win.C1List.C1Combo()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.btnOK = New System.Windows.Forms.Button()
            Me.grbESNCSN = New System.Windows.Forms.GroupBox()
            Me.txtESN = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.btnChangeESN = New System.Windows.Forms.Button()
            Me.gbMData = New System.Windows.Forms.GroupBox()
            Me.btnEditSjugSoft = New System.Windows.Forms.Button()
            Me.cboSofVer = New C1.Win.C1List.C1Combo()
            Me.cboSjugNo = New C1.Win.C1List.C1Combo()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.grbFailCoderepCode.SuspendLayout()
            CType(Me.cboSymtomCodes, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboFailCodes, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboRepairCodes, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grbESNCSN.SuspendLayout()
            Me.gbMData.SuspendLayout()
            CType(Me.cboSofVer, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboSjugNo, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'btnCancel
            '
            Me.btnCancel.BackColor = System.Drawing.Color.Green
            Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCancel.ForeColor = System.Drawing.Color.White
            Me.btnCancel.Location = New System.Drawing.Point(456, 272)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(56, 24)
            Me.btnCancel.TabIndex = 4
            Me.btnCancel.Text = "Cancel"
            '
            'grbFailCoderepCode
            '
            Me.grbFailCoderepCode.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboSymtomCodes, Me.Label4, Me.cboFailCodes, Me.cboRepairCodes, Me.Label12, Me.Label10})
            Me.grbFailCoderepCode.Location = New System.Drawing.Point(8, 152)
            Me.grbFailCoderepCode.Name = "grbFailCoderepCode"
            Me.grbFailCoderepCode.Size = New System.Drawing.Size(512, 112)
            Me.grbFailCoderepCode.TabIndex = 2
            Me.grbFailCoderepCode.TabStop = False
            '
            'cboSymtomCodes
            '
            Me.cboSymtomCodes.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboSymtomCodes.AutoCompletion = True
            Me.cboSymtomCodes.AutoDropDown = True
            Me.cboSymtomCodes.AutoSelect = True
            Me.cboSymtomCodes.Caption = ""
            Me.cboSymtomCodes.CaptionHeight = 17
            Me.cboSymtomCodes.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboSymtomCodes.ColumnCaptionHeight = 17
            Me.cboSymtomCodes.ColumnFooterHeight = 17
            Me.cboSymtomCodes.ColumnHeaders = False
            Me.cboSymtomCodes.ContentHeight = 15
            Me.cboSymtomCodes.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboSymtomCodes.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboSymtomCodes.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboSymtomCodes.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboSymtomCodes.EditorHeight = 15
            Me.cboSymtomCodes.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboSymtomCodes.ItemHeight = 15
            Me.cboSymtomCodes.Location = New System.Drawing.Point(128, 16)
            Me.cboSymtomCodes.MatchEntryTimeout = CType(2000, Long)
            Me.cboSymtomCodes.MaxDropDownItems = CType(10, Short)
            Me.cboSymtomCodes.MaxLength = 32767
            Me.cboSymtomCodes.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboSymtomCodes.Name = "cboSymtomCodes"
            Me.cboSymtomCodes.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboSymtomCodes.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboSymtomCodes.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboSymtomCodes.Size = New System.Drawing.Size(360, 21)
            Me.cboSymtomCodes.TabIndex = 1
            Me.cboSymtomCodes.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(16, 16)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(104, 17)
            Me.Label4.TabIndex = 91
            Me.Label4.Text = "Symptom Code:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboFailCodes
            '
            Me.cboFailCodes.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboFailCodes.AutoCompletion = True
            Me.cboFailCodes.AutoDropDown = True
            Me.cboFailCodes.AutoSelect = True
            Me.cboFailCodes.Caption = ""
            Me.cboFailCodes.CaptionHeight = 17
            Me.cboFailCodes.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboFailCodes.ColumnCaptionHeight = 17
            Me.cboFailCodes.ColumnFooterHeight = 17
            Me.cboFailCodes.ColumnHeaders = False
            Me.cboFailCodes.ContentHeight = 15
            Me.cboFailCodes.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboFailCodes.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboFailCodes.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboFailCodes.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboFailCodes.EditorHeight = 15
            Me.cboFailCodes.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboFailCodes.ItemHeight = 15
            Me.cboFailCodes.Location = New System.Drawing.Point(128, 80)
            Me.cboFailCodes.MatchEntryTimeout = CType(2000, Long)
            Me.cboFailCodes.MaxDropDownItems = CType(10, Short)
            Me.cboFailCodes.MaxLength = 32767
            Me.cboFailCodes.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboFailCodes.Name = "cboFailCodes"
            Me.cboFailCodes.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboFailCodes.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboFailCodes.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboFailCodes.Size = New System.Drawing.Size(360, 21)
            Me.cboFailCodes.TabIndex = 3
            Me.cboFailCodes.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'cboRepairCodes
            '
            Me.cboRepairCodes.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboRepairCodes.AutoCompletion = True
            Me.cboRepairCodes.AutoDropDown = True
            Me.cboRepairCodes.AutoSelect = True
            Me.cboRepairCodes.Caption = ""
            Me.cboRepairCodes.CaptionHeight = 17
            Me.cboRepairCodes.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboRepairCodes.ColumnCaptionHeight = 17
            Me.cboRepairCodes.ColumnFooterHeight = 17
            Me.cboRepairCodes.ColumnHeaders = False
            Me.cboRepairCodes.ContentHeight = 15
            Me.cboRepairCodes.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboRepairCodes.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboRepairCodes.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboRepairCodes.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboRepairCodes.EditorHeight = 15
            Me.cboRepairCodes.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboRepairCodes.ItemHeight = 15
            Me.cboRepairCodes.Location = New System.Drawing.Point(128, 48)
            Me.cboRepairCodes.MatchEntryTimeout = CType(2000, Long)
            Me.cboRepairCodes.MaxDropDownItems = CType(10, Short)
            Me.cboRepairCodes.MaxLength = 32767
            Me.cboRepairCodes.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboRepairCodes.Name = "cboRepairCodes"
            Me.cboRepairCodes.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboRepairCodes.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboRepairCodes.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboRepairCodes.Size = New System.Drawing.Size(360, 21)
            Me.cboRepairCodes.TabIndex = 2
            Me.cboRepairCodes.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label12
            '
            Me.Label12.BackColor = System.Drawing.Color.Transparent
            Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label12.ForeColor = System.Drawing.Color.White
            Me.Label12.Location = New System.Drawing.Point(32, 80)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(88, 16)
            Me.Label12.TabIndex = 89
            Me.Label12.Text = "Fail Code:"
            Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label10
            '
            Me.Label10.BackColor = System.Drawing.Color.Transparent
            Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.White
            Me.Label10.Location = New System.Drawing.Point(32, 48)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(88, 16)
            Me.Label10.TabIndex = 87
            Me.Label10.Text = "Repair Code:"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnOK
            '
            Me.btnOK.BackColor = System.Drawing.Color.Green
            Me.btnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnOK.ForeColor = System.Drawing.Color.White
            Me.btnOK.Location = New System.Drawing.Point(376, 272)
            Me.btnOK.Name = "btnOK"
            Me.btnOK.Size = New System.Drawing.Size(56, 24)
            Me.btnOK.TabIndex = 3
            Me.btnOK.Text = "OK"
            '
            'grbESNCSN
            '
            Me.grbESNCSN.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtESN, Me.Label2, Me.btnChangeESN})
            Me.grbESNCSN.Location = New System.Drawing.Point(8, 0)
            Me.grbESNCSN.Name = "grbESNCSN"
            Me.grbESNCSN.Size = New System.Drawing.Size(512, 48)
            Me.grbESNCSN.TabIndex = 1
            Me.grbESNCSN.TabStop = False
            Me.grbESNCSN.Visible = False
            '
            'txtESN
            '
            Me.txtESN.Location = New System.Drawing.Point(128, 18)
            Me.txtESN.Name = "txtESN"
            Me.txtESN.Size = New System.Drawing.Size(256, 20)
            Me.txtESN.TabIndex = 88
            Me.txtESN.Text = ""
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(40, 18)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(88, 16)
            Me.Label2.TabIndex = 87
            Me.Label2.Text = "ESN/CSN:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnChangeESN
            '
            Me.btnChangeESN.BackColor = System.Drawing.Color.LightSlateGray
            Me.btnChangeESN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnChangeESN.ForeColor = System.Drawing.Color.White
            Me.btnChangeESN.Location = New System.Drawing.Point(416, 16)
            Me.btnChangeESN.Name = "btnChangeESN"
            Me.btnChangeESN.Size = New System.Drawing.Size(72, 24)
            Me.btnChangeESN.TabIndex = 5
            Me.btnChangeESN.Text = "Edit ESN"
            Me.btnChangeESN.Visible = False
            '
            'gbMData
            '
            Me.gbMData.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnEditSjugSoft, Me.cboSofVer, Me.cboSjugNo, Me.Label1, Me.Label3})
            Me.gbMData.Location = New System.Drawing.Point(8, 52)
            Me.gbMData.Name = "gbMData"
            Me.gbMData.Size = New System.Drawing.Size(512, 96)
            Me.gbMData.TabIndex = 5
            Me.gbMData.TabStop = False
            Me.gbMData.Visible = False
            '
            'btnEditSjugSoft
            '
            Me.btnEditSjugSoft.BackColor = System.Drawing.Color.LightSlateGray
            Me.btnEditSjugSoft.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnEditSjugSoft.ForeColor = System.Drawing.Color.White
            Me.btnEditSjugSoft.Location = New System.Drawing.Point(416, 36)
            Me.btnEditSjugSoft.Name = "btnEditSjugSoft"
            Me.btnEditSjugSoft.Size = New System.Drawing.Size(72, 24)
            Me.btnEditSjugSoft.TabIndex = 94
            Me.btnEditSjugSoft.Text = "Edit"
            '
            'cboSofVer
            '
            Me.cboSofVer.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboSofVer.AutoCompletion = True
            Me.cboSofVer.AutoDropDown = True
            Me.cboSofVer.AutoSelect = True
            Me.cboSofVer.Caption = ""
            Me.cboSofVer.CaptionHeight = 17
            Me.cboSofVer.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboSofVer.ColumnCaptionHeight = 17
            Me.cboSofVer.ColumnFooterHeight = 17
            Me.cboSofVer.ColumnHeaders = False
            Me.cboSofVer.ContentHeight = 15
            Me.cboSofVer.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboSofVer.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboSofVer.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboSofVer.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboSofVer.EditorHeight = 15
            Me.cboSofVer.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.cboSofVer.ItemHeight = 15
            Me.cboSofVer.Location = New System.Drawing.Point(128, 56)
            Me.cboSofVer.MatchEntryTimeout = CType(2000, Long)
            Me.cboSofVer.MaxDropDownItems = CType(10, Short)
            Me.cboSofVer.MaxLength = 32767
            Me.cboSofVer.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboSofVer.Name = "cboSofVer"
            Me.cboSofVer.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboSofVer.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboSofVer.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboSofVer.Size = New System.Drawing.Size(256, 21)
            Me.cboSofVer.TabIndex = 91
            Me.cboSofVer.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'cboSjugNo
            '
            Me.cboSjugNo.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboSjugNo.AutoCompletion = True
            Me.cboSjugNo.AutoDropDown = True
            Me.cboSjugNo.AutoSelect = True
            Me.cboSjugNo.Caption = ""
            Me.cboSjugNo.CaptionHeight = 17
            Me.cboSjugNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboSjugNo.ColumnCaptionHeight = 17
            Me.cboSjugNo.ColumnFooterHeight = 17
            Me.cboSjugNo.ColumnHeaders = False
            Me.cboSjugNo.ContentHeight = 15
            Me.cboSjugNo.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboSjugNo.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboSjugNo.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboSjugNo.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboSjugNo.EditorHeight = 15
            Me.cboSjugNo.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.cboSjugNo.ItemHeight = 15
            Me.cboSjugNo.Location = New System.Drawing.Point(128, 20)
            Me.cboSjugNo.MatchEntryTimeout = CType(2000, Long)
            Me.cboSjugNo.MaxDropDownItems = CType(10, Short)
            Me.cboSjugNo.MaxLength = 32767
            Me.cboSjugNo.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboSjugNo.Name = "cboSjugNo"
            Me.cboSjugNo.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboSjugNo.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboSjugNo.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboSjugNo.Size = New System.Drawing.Size(256, 21)
            Me.cboSjugNo.TabIndex = 90
            Me.cboSjugNo.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(0, 56)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(128, 16)
            Me.Label1.TabIndex = 93
            Me.Label1.Text = "Software Version:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(40, 21)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(88, 16)
            Me.Label3.TabIndex = 92
            Me.Label3.Text = "SJUG #:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'frmCollectRepairFailCodes
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(574, 308)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.gbMData, Me.grbESNCSN, Me.btnOK, Me.btnCancel, Me.grbFailCoderepCode})
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "frmCollectRepairFailCodes"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Collect Repair Codes and Fail Codes"
            Me.grbFailCoderepCode.ResumeLayout(False)
            CType(Me.cboSymtomCodes, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboFailCodes, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboRepairCodes, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grbESNCSN.ResumeLayout(False)
            Me.gbMData.ResumeLayout(False)
            CType(Me.cboSofVer, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboSjugNo, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '******************************************************************
        Private Sub frmCollectRepairFailCodes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt, dtMatGrpWrty As DataTable
            Dim strRepairType As String = ""
            Dim objMClaim As PSS.Data.Buisness.WarrantyClaim.MClaim
            Dim strSjugNo, strSoftVersion As String
            Dim strRepairShortDesc As String = ""
            Dim iRepairID As Integer = 0
            Dim filteredDT() As DataRow

            Try
                Me.CenterToScreen()

                If Me._iProdID = 0 Then
                    MessageBox.Show("Product ID is missing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me._iManufID = 0 Then
                    MessageBox.Show("Manufacture ID is missing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else

                    '***************************
                    'Populate Symtom codes
                    '***************************
                    dt = WarrantyClaim.FailCodesRepairCodes.GetAllActiveSymtomCodeList(Me._iManufID, Me._iProdID, True)
                    Misc.PopulateC1DropDownList(Me.cboSymtomCodes, dt, "Comp_Desc", "Comp_ID")
                    If dt.Rows.Count = 2 Then Me.cboSymtomCodes.SelectedValue = dt.Rows(0)(0) Else cboSymtomCodes.SelectedValue = 0

                    '***************************
                    'Populate Repair codes
                    '***************************
                    If Me._booReplacePart = True Then
                        strRepairType = "P"
                    ElseIf Me._booReflow = True Then
                        strRepairType = "S"
                    End If

                    Me.cboRepairCodes.Enabled = True
                    dt = WarrantyClaim.FailCodesRepairCodes.GetRepairCodeList(Me._iManufID, Me._iProdID, _iRepairLevel, strRepairType, Me._iRepCodeID, True, True)
                    Misc.PopulateC1DropDownList(Me.cboRepairCodes, dt, "Repair_LDesc", "Repair_ID")
                    If dt.Rows.Count = 2 Then
                        Me.cboRepairCodes.SelectedValue = dt.Rows(0)(0)
                    ElseIf Me._iManufID = 201 Then
                        dtMatGrpWrty = WarrantyClaim.FailCodesRepairCodes.GetMaterialGroupWrtyForPartNumber(Me._strPartNumber)
                        If dtMatGrpWrty.Rows.Count = 1 AndAlso Not dtMatGrpWrty.Rows(0).IsNull("MatGrp_WrtyClaim") _
                           AndAlso Not Trim(dtMatGrpWrty.Rows(0).Item("MatGrp_WrtyClaim")) = "" Then
                            strRepairShortDesc = dtMatGrpWrty.Rows(0).Item("MatGrp_WrtyClaim")
                            filteredDT = dt.Select("Repair_SDesc='" & strRepairShortDesc.Replace("'", "''") & "'")
                            If filteredDT.Length = 1 Then
                                iRepairID = filteredDT(0).Item("Repair_ID")
                                cboRepairCodes.SelectedValue = iRepairID
                                Me.cboRepairCodes.Enabled = False
                            Else
                                cboRepairCodes.SelectedValue = 0
                            End If
                        Else
                            cboRepairCodes.SelectedValue = 0
                        End If
                    Else
                        cboRepairCodes.SelectedValue = 0
                    End If


                    '***************************
                    'Populate Fail codes
                    '***************************
                    If Me._iManufID = 64 Then
                        dt = WarrantyClaim.FailCodesRepairCodes.GetAllActiveFailCodeList(Me._iManufID, Me._iProdID, True)
                    Else
                        dt = WarrantyClaim.FailCodesRepairCodes.GetFailCodeListFromBillcodeMap(Me._iManufID, Me._iBillcodeID, True)
                        Me.cboSymtomCodes.Enabled = False
                    End If
                    Misc.PopulateC1DropDownList(Me.cboFailCodes, dt, "FailDesc", "Fail_ID")
                    If dt.Rows.Count = 2 Then Me.cboFailCodes.SelectedValue = dt.Rows(0)(0) Else cboFailCodes.SelectedValue = 0

                    '***************************
                    'Motorola
                    '***************************
                    If Me._iManufID = 1 Or Me._iManufID = 21 Then
                        _iSjugID = 0 : _iSoftVerID = 0 : strSjugNo = "" : strSoftVersion = ""
                        objMClaim = New PSS.Data.Buisness.WarrantyClaim.MClaim()

                        '******************************
                        'Get Cellopt Data
                        '******************************
                        dt = Nothing
                        dt = WarrantyClaim.FailCodesRepairCodes.GetCelloptData(Me._iDeviceID)

                        If dt.Rows.Count > 0 Then If Not IsDBNull(dt.Rows(0)("CellOpt_CSN")) Then Me._strCSN = dt.Rows(0)("CellOpt_CSN").ToString.Trim.ToUpper
                        If dt.Rows.Count > 0 AndAlso Me._iManufID = 1 Then
                            If Not IsDBNull(dt.Rows(0)("CellOpt_SugIn")) Then strSjugNo = dt.Rows(0)("CellOpt_SugIn")
                            If Not IsDBNull(dt.Rows(0)("CellOpt_SoftVerIN")) Then strSoftVersion = dt.Rows(0)("CellOpt_SoftVerIN")
                        End If

                        If Me._iManufID = 1 Then
                            Me.gbMData.Visible = True
                            '***************************
                            'Populate SJUG #
                            '***************************
                            dt = Nothing
                            dt = objMClaim.GetMotoSUGNumbers(_iModelID, 1, )
                            Misc.PopulateC1DropDownList(Me.cboSjugNo, dt, "LensSUG_text", "LensSUG_ID")
                            If strSjugNo.Trim.Length > 0 Then
                                If dt.Select("LensSUG_text = '" & strSjugNo & "'").Length > 0 Then Me._iSjugID = dt.Select("LensSUG_text = '" & strSjugNo & "'")(0)("LensSUG_ID")
                                Me.cboSjugNo.Enabled = False
                            End If
                            Me.cboSjugNo.SelectedValue = Me._iSjugID
                            '***************************
                            'Populate Software Version 
                            '***************************
                            dt = Nothing
                            dt = objMClaim.GetMotoSoftwareVersion(_iModelID, 1, )
                            Misc.PopulateC1DropDownList(Me.cboSofVer, dt, "sv_SoftwareVersion", "sv_ID")
                            If strSoftVersion.Trim.Length > 0 Then
                                If dt.Select("sv_SoftwareVersion = '" & strSoftVersion & "'").Length > 0 Then Me._iSoftVerID = dt.Select("sv_SoftwareVersion = '" & strSoftVersion & "'")(0)("sv_ID")
                                Me.cboSofVer.Enabled = False
                            End If
                            Me.cboSofVer.SelectedValue = Me._iSoftVerID
                        End If


                        '***********************
                        'CDMA type
                        '***********************
                        If (Me._strIMEI.Trim.Length > 17) Then
                            Me.grbESNCSN.Visible = True
                            If Me._strCSN.Trim.Length > 0 Then
                                Me.txtESN.Text = Me._strCSN.ToUpper
                                Me.txtESN.Enabled = False
                                Me.btnChangeESN.Visible = True
                            End If
                        End If

                        '***********************
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmCollectRepairFailCodes_Load", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '******************************************************************
        Private Sub cboRepairFailCodes_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRepairCodes.KeyUp, cboFailCodes.KeyUp
            Dim i As Integer
            Try
                If e.KeyCode = Keys.Enter Then
                    If sender.name = "cboRepairCodes" Then
                        Me.cboFailCodes.SelectAll()
                        Me.cboFailCodes.Focus()
                    ElseIf sender.name = "cboFailCodes" Then
                        If Me.ProcessRepFailCode() = True Then Me.Close()
                        'Me.btnOK.Focus()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboRepairCodes_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '******************************************************************
        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Try
                Me._booCancel = True
                Me._iFailcodeID = 0 : Me._iRepCodeID = 0

                Me.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnCancel_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '******************************************************************
        Private Function ProcessRepFailCode() As Boolean
            Dim booResult As Boolean = False

            Try
                If Me._iManufID = 64 AndAlso (IsNothing(Me.cboSymtomCodes.SelectedValue) OrElse Me.cboSymtomCodes.SelectedValue = 0) Then
                    MessageBox.Show("Please enter Symtom Code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboSymtomCodes.SelectAll() : Me.cboSymtomCodes.Focus()
                ElseIf IsNothing(Me.cboRepairCodes.SelectedValue) Then
                    MessageBox.Show("Please enter Repair Code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboRepairCodes.SelectAll()
                    Me.cboRepairCodes.Focus()
                ElseIf IsNothing(Me.cboFailCodes.SelectedValue) Then
                    MessageBox.Show("Please enter Fail Code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboFailCodes.SelectAll()
                    Me.cboFailCodes.Focus()
                ElseIf Me.cboRepairCodes.SelectedValue = 0 Then
                    MessageBox.Show("Please enter Repair Code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboRepairCodes.SelectAll()
                    Me.cboRepairCodes.Focus()
                ElseIf Me.cboFailCodes.SelectedValue = 0 Then
                    MessageBox.Show("Please enter Fail Code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboFailCodes.SelectAll()
                    Me.cboFailCodes.Focus()
                Else
                    If Me.cboRepairCodes.DataSource.Table.Select("Repair_LDesc = '" & Me.cboRepairCodes.Text & "'").length = 0 Then
                        MessageBox.Show("Please enter a valid Repair Code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.cboRepairCodes.SelectAll()
                        Me.cboRepairCodes.Focus()
                        Exit Function
                    End If
                    If Me.cboFailCodes.DataSource.Table.Select("FailDesc = '" & Me.cboFailCodes.Text & "'").length = 0 Then
                        MessageBox.Show("Please enter a valid Fail code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.cboFailCodes.SelectAll()
                        Me.cboFailCodes.Focus()
                        Exit Function
                    End If

                    'Check Warranty
                    Me._booCancel = False
                    If Me._iManufID = 64 Then Me._iSymCodeID = Me.cboSymtomCodes.SelectedValue.ToString
                    Me._iRepCodeID = Me.cboRepairCodes.SelectedValue.ToString
                    Me._iFailcodeID = Me.cboFailCodes.SelectedValue.ToString
                    booResult = True
                End If

                Return booResult
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
            Dim i As Integer = 0

            Try
                '*****************************************
                'cellopt data
                '*****************************************
                If Me._iManufID = 1 Or Me._iManufID = 21 Then
                    If Me._iManufID = 1 AndAlso Me.cboSjugNo.SelectedValue = 0 Then
                        MessageBox.Show("Please select SJUG #.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.cboSjugNo.SelectAll() : Me.cboSjugNo.Focus() : Exit Sub
                    ElseIf Me._iManufID = 1 AndAlso Me.cboSofVer.SelectedValue = 0 Then
                        MessageBox.Show("Please select software version.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.cboSofVer.SelectAll() : Me.cboSofVer.Focus() : Exit Sub
                    ElseIf Me._iManufID = 1 AndAlso Me._strIMEI.Trim.Length > 17 AndAlso Me.txtESN.Text.Trim.Length <> 8 Then
                        MessageBox.Show("Invalid ESN. ESN number must be 8 character of alphanumeric.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtESN.SelectAll() : Me.txtESN.Focus() : Exit Sub
                    ElseIf Me._iManufID = 21 AndAlso Me._strIMEI.Trim.Length > 17 AndAlso Me.txtESN.Text.Trim.ToUpper.StartsWith("A00000") = False Then
                        MessageBox.Show("Please enter valid ESN. Must start with A00000", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtESN.SelectAll() : Me.txtESN.Focus() : Exit Sub
                    Else
                        'validate ESN #
                        If Me._strIMEI.Trim.Length > 17 Then
                            For i = 1 To Me.txtESN.Text.Trim.Length
                                If Char.IsLetterOrDigit(Mid(Me.txtESN.Text.Trim, i, 1)) = False Then
                                    MessageBox.Show("Invalid ESN. ESN must be alphanumeric.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                    Me.txtESN.SelectAll() : Me.txtESN.Focus() : Exit Sub
                                End If
                            Next i
                        End If

                        'Update ESN
                        i = 0
                        If Me._iManufID = 1 Then
                            If Me._strCSN.Trim.ToUpper <> Me.txtESN.Text.Trim.ToUpper Or Me._iSjugID <> Me.cboSjugNo.SelectedValue Or Me._iSoftVerID <> Me.cboSofVer.SelectedValue Then
                                i = WarrantyClaim.FailCodesRepairCodes.UpdateCelloptData(Me._iDeviceID, Me.txtESN.Text.Trim.ToUpper, Me.cboSjugNo.DataSource.Table.Select("LensSUG_ID = " & Me.cboSjugNo.SelectedValue)(0)("LensSUG_text"), Me.cboSofVer.DataSource.Table.Select("sv_ID = " & Me.cboSofVer.SelectedValue)(0)("sv_SoftwareVersion"))
                                If i = 0 Then Throw New Exception("System has failed to update ESN.")
                            End If
                        ElseIf Me._iManufID = 21 AndAlso Me._strIMEI.Trim.Length > 17 AndAlso Me._strCSN.Trim.ToUpper <> Me.txtESN.Text.Trim.ToUpper Then
                            i = WarrantyClaim.FailCodesRepairCodes.UpdateCelloptData(Me._iDeviceID, Me.txtESN.Text.Trim.ToUpper, "", "")
                            If i = 0 Then Throw New Exception("System has failed to update ESN.")
                        End If
                    End If
                End If
                '*****************************************
                If ProcessRepFailCode() = True Then
                    Me.Close()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnOK_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '******************************************************************
        Private Sub btnChangeESNCSN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeESN.Click
            Me.txtESN.Enabled = True
            Me.txtESN.SelectAll()
            Me.txtESN.Focus()
        End Sub

        '******************************************************************
        Private Sub btnEditSjugSoft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditSjugSoft.Click
            Me.cboSjugNo.Enabled = True
            Me.cboSofVer.Enabled = True
            Me.cboSjugNo.SelectAll()
            Me.cboSjugNo.Focus()
        End Sub

        '******************************************************************

      
    End Class
End Namespace