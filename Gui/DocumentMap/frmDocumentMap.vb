Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.Document

    Public Class frmDocumentMap
        Inherits System.Windows.Forms.Form

        Private _objDocMap As PSS.Data.Buisness.Document.DocumentMap
        Private _bLoading As Boolean = True

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _objDocMap = New PSS.Data.Buisness.Document.DocumentMap()
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If

                _objDocMap = Nothing
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents cboStation As C1.Win.C1List.C1Combo
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents btnView As System.Windows.Forms.Button
        Friend WithEvents cboModel As C1.Win.C1List.C1Combo
        Friend WithEvents cboDocName As C1.Win.C1List.C1Combo
        Friend WithEvents AxAcroPDF1 As AxAcroPDFLib.AxAcroPDF
        Friend WithEvents lblInstruction As System.Windows.Forms.Label
        Friend WithEvents cboDept As C1.Win.C1List.C1Combo
        Friend WithEvents Label4 As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmDocumentMap))
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.cboDept = New C1.Win.C1List.C1Combo()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.lblInstruction = New System.Windows.Forms.Label()
            Me.btnView = New System.Windows.Forms.Button()
            Me.cboDocName = New C1.Win.C1List.C1Combo()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.cboModel = New C1.Win.C1List.C1Combo()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.cboStation = New C1.Win.C1List.C1Combo()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.AxAcroPDF1 = New AxAcroPDFLib.AxAcroPDF()
            Me.GroupBox1.SuspendLayout()
            CType(Me.cboDept, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboDocName, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboModel, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboStation, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.AxAcroPDF1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboDept, Me.Label4, Me.lblInstruction, Me.btnView, Me.cboDocName, Me.Label2, Me.cboModel, Me.Label1, Me.cboStation, Me.Label5})
            Me.GroupBox1.Location = New System.Drawing.Point(8, 0)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(632, 176)
            Me.GroupBox1.TabIndex = 0
            Me.GroupBox1.TabStop = False
            '
            'cboDept
            '
            Me.cboDept.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboDept.AutoCompletion = True
            Me.cboDept.AutoDropDown = True
            Me.cboDept.AutoSelect = True
            Me.cboDept.Caption = ""
            Me.cboDept.CaptionHeight = 17
            Me.cboDept.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboDept.ColumnCaptionHeight = 17
            Me.cboDept.ColumnFooterHeight = 17
            Me.cboDept.ColumnHeaders = False
            Me.cboDept.ContentHeight = 15
            Me.cboDept.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboDept.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboDept.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboDept.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboDept.EditorHeight = 15
            Me.cboDept.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboDept.ItemHeight = 15
            Me.cboDept.Location = New System.Drawing.Point(8, 56)
            Me.cboDept.MatchEntryTimeout = CType(2000, Long)
            Me.cboDept.MaxDropDownItems = CType(10, Short)
            Me.cboDept.MaxLength = 32767
            Me.cboDept.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboDept.Name = "cboDept"
            Me.cboDept.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboDept.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboDept.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboDept.Size = New System.Drawing.Size(232, 21)
            Me.cboDept.TabIndex = 93
            Me.cboDept.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(8, 40)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(112, 16)
            Me.Label4.TabIndex = 94
            Me.Label4.Text = "Department :"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblInstruction
            '
            Me.lblInstruction.BackColor = System.Drawing.Color.Transparent
            Me.lblInstruction.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, (System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblInstruction.ForeColor = System.Drawing.Color.Lime
            Me.lblInstruction.Location = New System.Drawing.Point(8, 8)
            Me.lblInstruction.Name = "lblInstruction"
            Me.lblInstruction.Size = New System.Drawing.Size(600, 24)
            Me.lblInstruction.TabIndex = 90
            Me.lblInstruction.Text = "Please select the following items and press enter after each item."
            Me.lblInstruction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnView
            '
            Me.btnView.BackColor = System.Drawing.Color.Green
            Me.btnView.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnView.ForeColor = System.Drawing.Color.White
            Me.btnView.Location = New System.Drawing.Point(504, 104)
            Me.btnView.Name = "btnView"
            Me.btnView.Size = New System.Drawing.Size(104, 40)
            Me.btnView.TabIndex = 4
            Me.btnView.Text = "View"
            '
            'cboDocName
            '
            Me.cboDocName.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboDocName.AutoCompletion = True
            Me.cboDocName.AutoDropDown = True
            Me.cboDocName.AutoSelect = True
            Me.cboDocName.Caption = ""
            Me.cboDocName.CaptionHeight = 17
            Me.cboDocName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboDocName.ColumnCaptionHeight = 17
            Me.cboDocName.ColumnFooterHeight = 17
            Me.cboDocName.ColumnHeaders = False
            Me.cboDocName.ContentHeight = 15
            Me.cboDocName.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboDocName.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboDocName.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboDocName.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboDocName.EditorHeight = 15
            Me.cboDocName.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboDocName.ItemHeight = 15
            Me.cboDocName.Location = New System.Drawing.Point(256, 120)
            Me.cboDocName.MatchEntryTimeout = CType(2000, Long)
            Me.cboDocName.MaxDropDownItems = CType(10, Short)
            Me.cboDocName.MaxLength = 32767
            Me.cboDocName.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboDocName.Name = "cboDocName"
            Me.cboDocName.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboDocName.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboDocName.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboDocName.Size = New System.Drawing.Size(232, 21)
            Me.cboDocName.TabIndex = 3
            Me.cboDocName.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(256, 104)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(144, 16)
            Me.Label2.TabIndex = 89
            Me.Label2.Text = "Document Name :"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
            Me.cboModel.ContentHeight = 15
            Me.cboModel.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboModel.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboModel.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboModel.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboModel.EditorHeight = 15
            Me.cboModel.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboModel.ItemHeight = 15
            Me.cboModel.Location = New System.Drawing.Point(8, 120)
            Me.cboModel.MatchEntryTimeout = CType(2000, Long)
            Me.cboModel.MaxDropDownItems = CType(10, Short)
            Me.cboModel.MaxLength = 32767
            Me.cboModel.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboModel.Name = "cboModel"
            Me.cboModel.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboModel.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboModel.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboModel.Size = New System.Drawing.Size(232, 21)
            Me.cboModel.TabIndex = 2
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
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(8, 104)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(104, 16)
            Me.Label1.TabIndex = 87
            Me.Label1.Text = "Model :"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cboStation
            '
            Me.cboStation.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboStation.AutoCompletion = True
            Me.cboStation.AutoDropDown = True
            Me.cboStation.AutoSelect = True
            Me.cboStation.Caption = ""
            Me.cboStation.CaptionHeight = 17
            Me.cboStation.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboStation.ColumnCaptionHeight = 17
            Me.cboStation.ColumnFooterHeight = 17
            Me.cboStation.ColumnHeaders = False
            Me.cboStation.ContentHeight = 15
            Me.cboStation.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboStation.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboStation.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboStation.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboStation.EditorHeight = 15
            Me.cboStation.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.cboStation.ItemHeight = 15
            Me.cboStation.Location = New System.Drawing.Point(256, 56)
            Me.cboStation.MatchEntryTimeout = CType(2000, Long)
            Me.cboStation.MaxDropDownItems = CType(10, Short)
            Me.cboStation.MaxLength = 32767
            Me.cboStation.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboStation.Name = "cboStation"
            Me.cboStation.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboStation.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboStation.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboStation.Size = New System.Drawing.Size(232, 21)
            Me.cboStation.TabIndex = 1
            Me.cboStation.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.Transparent
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.White
            Me.Label5.Location = New System.Drawing.Point(256, 40)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(56, 16)
            Me.Label5.TabIndex = 85
            Me.Label5.Text = "Station :"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'AxAcroPDF1
            '
            Me.AxAcroPDF1.Enabled = True
            Me.AxAcroPDF1.Location = New System.Drawing.Point(8, 264)
            Me.AxAcroPDF1.Name = "AxAcroPDF1"
            Me.AxAcroPDF1.OcxState = CType(resources.GetObject("AxAcroPDF1.OcxState"), System.Windows.Forms.AxHost.State)
            Me.AxAcroPDF1.Size = New System.Drawing.Size(640, 200)
            Me.AxAcroPDF1.TabIndex = 1
            Me.AxAcroPDF1.Visible = False
            '
            'frmDocumentMap
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(688, 485)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox1, Me.AxAcroPDF1})
            Me.Name = "frmDocumentMap"
            Me.Text = "frmDocumentMap"
            Me.GroupBox1.ResumeLayout(False)
            CType(Me.cboDept, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboDocName, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboModel, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboStation, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.AxAcroPDF1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '******************************************************************
        Private Sub frmDocumentMap_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable
            Try
                'PSS.Core.Highlight.SetHighLight(Me)

                '*********************************
                'Department
                '*********************************
                dt = Me._objDocMap.GetDepartment()
                Misc.PopulateC1DropDownList(Me.cboDept, dt, "DepartmentDesc", "DepartmentID")
                Me.cboDept.SelectedValue = 0
                Me.cboDept.Focus()


            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmDocumentMap_Load", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt)
                Me._bLoading = False
                btnView.Enabled = False
                Me.cboStation.Enabled = False
                Me.cboModel.Enabled = False
                Me.cboDocName.Enabled = False

            End Try
        End Sub

        '******************************************************************
        Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
            Dim strDocPathFile As String = ""

            Try
                If Me.cboStation.SelectedValue > 0 AndAlso Me.cboModel.SelectedValue > 0 AndAlso Me.cboDocName.SelectedValue > 0 Then
                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor
                    strDocPathFile = Me._objDocMap.GetDocMapFilePathAndName(Me.cboStation.Text.Trim, Me.cboModel.Text, Me.cboDocName.Text)
                    ''strDocPathFile = "c:\W-7.5-585-045 AssemblyDisassembly Work Instruction – LG420.pdf"
                    'Me.AxAcroPDF1.setShowToolbar(False)
                    'AxAcroPDF1.Visible = True
                    'AxAcroPDF1.LoadFile(strDocPathFile)

                    If IO.File.Exists(strDocPathFile) = False Then
                        MessageBox.Show("File does not exist." & Environment.NewLine & strDocPathFile, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        System.Diagnostics.Process.Start(strDocPathFile)
                    End If

                    Me.Enabled = True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnView_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Sub

        '******************************************************************
        Private Sub cboStation_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboStation.KeyDown, cboModel.KeyDown
            Dim dt As DataTable
            Try
                If e.KeyCode = Keys.Enter Then
                    If sender.name = "cboStation" Then
                        If Me.cboStation.SelectedValue > 0 Then
                            '*********************************
                            'Model/General
                            '*********************************
                            dt = Me._objDocMap.GetDocMapModel(Me.cboDept.SelectedValue, Me.cboStation.Text)
                            Me.cboModel.ClearItems()
                            Misc.PopulateC1DropDownList(Me.cboModel, dt, "ModelGeneral", "id")
                            Me.cboModel.SelectedValue = 0
                            If Me.cboStation.ListCount > 1 Then
                                Me.cboModel.Enabled = True
                                Me.cboModel.Focus()
                            Else
                                Me.cboModel.Enabled = False
                            End If

                        End If
                    ElseIf sender.name = "cboModel" Then
                        If Me.cboStation.SelectedValue > 0 AndAlso Me.cboModel.SelectedValue > 0 Then
                            '*********************************
                            'Document Main
                            '*********************************
                            dt = Me._objDocMap.GetDocMapDocName(Me.cboDept.SelectedValue, Me.cboStation.Text, Me.cboModel.Text)
                            Me.cboDocName.ClearItems()
                            Misc.PopulateC1DropDownList(Me.cboDocName, dt, "dm_Name", "id")
                            Me.cboDocName.SelectedValue = 0
                            '*********************************

                            If Me.cboDocName.ListCount > 1 Then
                                Me.cboDocName.Enabled = True
                                Me.cboDocName.Focus()
                            Else
                                Me.cboDocName.Enabled = False
                            End If


                        End If
                    End If
                ElseIf sender.name = "cboStation" Then
                    Me.AxAcroPDF1.Visible = False
                    Me.cboModel.DataSource = Nothing
                    Me.cboDocName.DataSource = Nothing
                    Me.cboModel.Text = ""
                    Me.cboDocName.Text = ""
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboStation_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt)
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Sub

        Private Sub cboDept_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDept.SelectedValueChanged
            If Me._bLoading Then Exit Sub

            Dim dt As DataTable
            Try
                If Me.cboDept.SelectedValue > 0 Then
                    '*********************************
                    'Station
                    '*********************************
                    dt = Me._objDocMap.GetDocMapStation(Me.cboDept.SelectedValue)
                    Me.cboStation.ClearItems()
                    Misc.PopulateC1DropDownList(Me.cboStation, dt, "StationType", "id")
                    Me.cboStation.SelectedValue = 0

                    If Me.cboStation.ListCount > 1 Then
                        Me.cboStation.Enabled = True
                        Me.cboStation.Focus()
                    Else
                        Me.cboStation.Enabled = False
                    End If


                Else
                    Me.cboStation.Enabled = False

                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmDocumentMap_Load", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt)
                Me.cboModel.Enabled = False
                Me.cboDocName.Enabled = False
                btnView.Enabled = False
            End Try
        End Sub

        Private Sub cboStation_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboStation.SelectedValueChanged
            If Me._bLoading Then Exit Sub

            Dim dt As DataTable
            Try
                If Me.cboStation.SelectedValue > 0 Then
                    '*********************************
                    'Model/General
                    '*********************************
                    dt = Me._objDocMap.GetDocMapModel(Me.cboDept.SelectedValue, Me.cboStation.Text)
                    Me.cboModel.ClearItems()
                    Misc.PopulateC1DropDownList(Me.cboModel, dt, "ModelGeneral", "id")
                    Me.cboModel.SelectedValue = 0
                    '*********************************
                    'Me.cboDocName.DataSource = Nothing
                    'Me.cboDocName.Text = ""
                    If Me.cboStation.ListCount > 1 Then
                        Me.cboModel.Enabled = True
                        Me.cboModel.Focus()
                    Else
                        Me.cboModel.Enabled = False
                    End If


                Else
                    Me.cboModel.Enabled = False
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmDocumentMap_Load", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt)
                Me.cboDocName.Enabled = False
                btnView.Enabled = False
            End Try
        End Sub


        '******************************************************************

        Private Sub cboModel_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboModel.SelectedValueChanged
            If Me._bLoading Then Exit Sub

            Dim dt As DataTable
            Try
                If Me.cboModel.SelectedValue > 0 Then

                    '*********************************
                    'Document Name
                    '*********************************
                    dt = Me._objDocMap.GetDocMapDocName(Me.cboDept.SelectedValue, Me.cboStation.Text, Me.cboModel.Text)
                    Me.cboDocName.ClearItems()
                    Misc.PopulateC1DropDownList(Me.cboDocName, dt, "dm_Name", "id")
                    Me.cboDocName.SelectedValue = 0
                    '*********************************

                    If Me.cboDocName.ListCount > 1 Then
                        Me.cboDocName.Enabled = True
                        Me.cboDocName.Focus()
                    Else
                        Me.cboDocName.Enabled = False
                    End If

                Else
                    Me.cboDocName.Enabled = False
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmDocumentMap_Load", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt)
                btnView.Enabled = False
            End Try
        End Sub

        Private Sub cboDocName_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDocName.SelectedValueChanged
            If Me._bLoading Then Exit Sub

            Dim dt As DataTable
            Try
                If Me.cboDocName.SelectedValue > 0 Then

                    '*********************************
                    ' View Button
                    '*********************************
                    btnView.Enabled = True
                    btnView.Focus()

                Else
                    btnView.Enabled = False
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmDocumentMap_Load", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub


    End Class
End Namespace