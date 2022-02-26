Option Explicit On 
Imports PSS.Data.Buisness
Imports PSS.Core.Global

Namespace Gui.AdminFunctions

    Public Class frmChangeModel
        Inherits System.Windows.Forms.Form

        Private _booPopulateData As Boolean = False
        Private _iDeviceID As Integer = 0
        Private _iCurrentModelID As Integer = 0

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call

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
        Friend WithEvents cboProdID As C1.Win.C1List.C1Combo
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents cboLocations As C1.Win.C1List.C1Combo
        Friend WithEvents cboCustomers As C1.Win.C1List.C1Combo
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents lblModel As System.Windows.Forms.Label
        Friend WithEvents btnChangeModel As System.Windows.Forms.Button
        Friend WithEvents txtSN As System.Windows.Forms.TextBox
        Friend WithEvents cboNewModel As C1.Win.C1List.C1Combo
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmChangeModel))
            Me.cboProdID = New C1.Win.C1List.C1Combo()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.cboLocations = New C1.Win.C1List.C1Combo()
            Me.cboCustomers = New C1.Win.C1List.C1Combo()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.cboNewModel = New C1.Win.C1List.C1Combo()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.lblModel = New System.Windows.Forms.Label()
            Me.btnChangeModel = New System.Windows.Forms.Button()
            Me.txtSN = New System.Windows.Forms.TextBox()
            CType(Me.cboProdID, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboLocations, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboNewModel, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'cboProdID
            '
            Me.cboProdID.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboProdID.Caption = ""
            Me.cboProdID.CaptionHeight = 17
            Me.cboProdID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboProdID.ColumnCaptionHeight = 17
            Me.cboProdID.ColumnFooterHeight = 17
            Me.cboProdID.ContentHeight = 15
            Me.cboProdID.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboProdID.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboProdID.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboProdID.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboProdID.EditorHeight = 15
            Me.cboProdID.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboProdID.ItemHeight = 15
            Me.cboProdID.Location = New System.Drawing.Point(146, 23)
            Me.cboProdID.MatchEntryTimeout = CType(2000, Long)
            Me.cboProdID.MaxDropDownItems = CType(5, Short)
            Me.cboProdID.MaxLength = 32767
            Me.cboProdID.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboProdID.Name = "cboProdID"
            Me.cboProdID.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboProdID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboProdID.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboProdID.Size = New System.Drawing.Size(291, 21)
            Me.cboProdID.TabIndex = 1
            Me.cboProdID.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            "aultRecSelWidth>16</DefaultRecSelWidth></Blob>"
            '
            'Label6
            '
            Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.White
            Me.Label6.Location = New System.Drawing.Point(51, 23)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(95, 19)
            Me.Label6.TabIndex = 30
            Me.Label6.Text = "Product Type:"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboLocations
            '
            Me.cboLocations.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboLocations.Caption = ""
            Me.cboLocations.CaptionHeight = 17
            Me.cboLocations.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboLocations.ColumnCaptionHeight = 17
            Me.cboLocations.ColumnFooterHeight = 17
            Me.cboLocations.ContentHeight = 15
            Me.cboLocations.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboLocations.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboLocations.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboLocations.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboLocations.EditorHeight = 15
            Me.cboLocations.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboLocations.ItemHeight = 15
            Me.cboLocations.Location = New System.Drawing.Point(146, 98)
            Me.cboLocations.MatchEntryTimeout = CType(2000, Long)
            Me.cboLocations.MaxDropDownItems = CType(5, Short)
            Me.cboLocations.MaxLength = 32767
            Me.cboLocations.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboLocations.Name = "cboLocations"
            Me.cboLocations.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboLocations.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboLocations.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboLocations.Size = New System.Drawing.Size(291, 21)
            Me.cboLocations.TabIndex = 3
            Me.cboLocations.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            "aultRecSelWidth>16</DefaultRecSelWidth></Blob>"
            '
            'cboCustomers
            '
            Me.cboCustomers.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboCustomers.Caption = ""
            Me.cboCustomers.CaptionHeight = 17
            Me.cboCustomers.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboCustomers.ColumnCaptionHeight = 17
            Me.cboCustomers.ColumnFooterHeight = 17
            Me.cboCustomers.ContentHeight = 15
            Me.cboCustomers.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboCustomers.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboCustomers.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCustomers.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboCustomers.EditorHeight = 15
            Me.cboCustomers.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboCustomers.ItemHeight = 15
            Me.cboCustomers.Location = New System.Drawing.Point(146, 61)
            Me.cboCustomers.MatchEntryTimeout = CType(2000, Long)
            Me.cboCustomers.MaxDropDownItems = CType(5, Short)
            Me.cboCustomers.MaxLength = 32767
            Me.cboCustomers.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCustomers.Name = "cboCustomers"
            Me.cboCustomers.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCustomers.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCustomers.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCustomers.Size = New System.Drawing.Size(291, 21)
            Me.cboCustomers.TabIndex = 2
            Me.cboCustomers.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            "aultRecSelWidth>16</DefaultRecSelWidth></Blob>"
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(51, 98)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(66, 19)
            Me.Label2.TabIndex = 29
            Me.Label2.Text = "Location:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(51, 61)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(73, 19)
            Me.Label1.TabIndex = 28
            Me.Label1.Text = "Customer:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboNewModel
            '
            Me.cboNewModel.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboNewModel.Caption = ""
            Me.cboNewModel.CaptionHeight = 17
            Me.cboNewModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboNewModel.ColumnCaptionHeight = 17
            Me.cboNewModel.ColumnFooterHeight = 17
            Me.cboNewModel.ContentHeight = 15
            Me.cboNewModel.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboNewModel.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboNewModel.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboNewModel.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboNewModel.EditorHeight = 15
            Me.cboNewModel.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.cboNewModel.ItemHeight = 15
            Me.cboNewModel.Location = New System.Drawing.Point(146, 227)
            Me.cboNewModel.MatchEntryTimeout = CType(2000, Long)
            Me.cboNewModel.MaxDropDownItems = CType(5, Short)
            Me.cboNewModel.MaxLength = 32767
            Me.cboNewModel.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboNewModel.Name = "cboNewModel"
            Me.cboNewModel.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboNewModel.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboNewModel.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboNewModel.Size = New System.Drawing.Size(291, 21)
            Me.cboNewModel.TabIndex = 5
            Me.cboNewModel.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            "aultRecSelWidth>16</DefaultRecSelWidth></Blob>"
            '
            'Label4
            '
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(44, 139)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(95, 30)
            Me.Label4.TabIndex = 33
            Me.Label4.Text = "Serial Number:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label5
            '
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.White
            Me.Label5.Location = New System.Drawing.Point(51, 182)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(81, 30)
            Me.Label5.TabIndex = 35
            Me.Label5.Text = "Model:"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label3
            '
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(37, 227)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(95, 19)
            Me.Label3.TabIndex = 37
            Me.Label3.Text = "New Model:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblModel
            '
            Me.lblModel.BackColor = System.Drawing.Color.White
            Me.lblModel.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblModel.Location = New System.Drawing.Point(146, 189)
            Me.lblModel.Name = "lblModel"
            Me.lblModel.Size = New System.Drawing.Size(292, 23)
            Me.lblModel.TabIndex = 38
            Me.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnChangeModel
            '
            Me.btnChangeModel.BackColor = System.Drawing.Color.Green
            Me.btnChangeModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnChangeModel.ForeColor = System.Drawing.Color.White
            Me.btnChangeModel.Location = New System.Drawing.Point(146, 273)
            Me.btnChangeModel.Name = "btnChangeModel"
            Me.btnChangeModel.Size = New System.Drawing.Size(292, 21)
            Me.btnChangeModel.TabIndex = 6
            Me.btnChangeModel.Text = "Change Model"
            '
            'txtSN
            '
            Me.txtSN.Location = New System.Drawing.Point(146, 144)
            Me.txtSN.Name = "txtSN"
            Me.txtSN.Size = New System.Drawing.Size(292, 20)
            Me.txtSN.TabIndex = 4
            Me.txtSN.Text = ""
            '
            'frmChangeModel
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(496, 325)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtSN, Me.btnChangeModel, Me.lblModel, Me.Label3, Me.Label5, Me.Label4, Me.cboNewModel, Me.cboProdID, Me.Label6, Me.cboLocations, Me.cboCustomers, Me.Label2, Me.Label1})
            Me.Name = "frmChangeModel"
            Me.Text = "frmChangeModel"
            CType(Me.cboProdID, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboLocations, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboNewModel, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmChangeModel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable

            Try
                'Populate product type
                dt = Generic.GetProducts(True)
                Misc.PopulateC1DropDownList(Me.cboProdID, dt, "Prod_Desc", "Prod_ID")
                Me.cboProdID.SelectedValue = 0

                PSS.Core.Highlight.SetHighLight(Me)

                Me.cboProdID.Focus()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "FormLoad", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '********************************************************************************
        Private Sub cboProdID_cboCustomers_cboLocations_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboProdID.Enter, cboCustomers.Enter, cboLocations.Enter
            Try
                If sender.name = "cboProdID" Then
                    Me.cboProdID.SelectAll()
                ElseIf sender.name = "cboCustomers" Then
                    Me.cboCustomers.SelectAll()
                ElseIf sender.name = "cboLocations" Then
                    Me.cboLocations.SelectAll()
                ElseIf sender.name = "cboLocations" Then
                    Me.cboLocations.SelectAll()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "EnterEvent", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '********************************************************************************
        Private Sub cbos_RowChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboProdID.RowChange, cboCustomers.RowChange, cboLocations.RowChange
            Dim dt As DataTable

            Try
                If _booPopulateData = False Then
                    If sender.name = "cboProdID" Then
                        If Not IsNothing(Me.cboCustomers.DataSource) Then
                            Me.cboCustomers.DataSource = Nothing
                            Me.cboCustomers.Text = ""
                        End If
                        If Not IsNothing(Me.cboLocations.DataSource) Then
                            Me.cboLocations.DataSource = Nothing
                            Me.cboLocations.Text = ""
                        End If
                        Me.txtSN.Text = "" : Me.lblModel.Text = ""
                        Me._iDeviceID = 0 : Me._iCurrentModelID = 0
                        If Not IsNothing(Me.cboNewModel.DataSource) Then
                            Me.cboNewModel.DataSource = Nothing
                            Me.cboNewModel.Text = ""
                        End If

                        If Me.cboProdID.SelectedValue > 0 Then
                            Me.PopulateCustomerList()
                            Me.PopulateModelList()
                        End If
                    ElseIf sender.name = "cboCustomers" Then
                        If Not IsNothing(Me.cboLocations.DataSource) Then
                            Me.cboLocations.DataSource = Nothing
                            Me.cboLocations.Text = ""
                        End If
                        Me.txtSN.Text = "" : Me.lblModel.Text = ""
                        Me._iDeviceID = 0 : Me._iCurrentModelID = 0
                        If Me.cboCustomers.SelectedValue > 0 Then Me.PopulateLocationList()
                    ElseIf sender.name = "cboLocations" Then
                        Me.txtSN.Text = "" : Me.lblModel.Text = ""
                        Me._iDeviceID = 0 : Me._iCurrentModelID = 0
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cbos_RowChange", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '**************************************************************************
        Private Sub PopulateCustomerList()
            Dim dt As DataTable

            Try
                _booPopulateData = True
                dt = Generic.GetCustomers(True, Me.cboProdID.SelectedValue)
                Misc.PopulateC1DropDownList(Me.cboCustomers, dt, "Cust_Name1", "Cust_ID")
                If dt.Rows.Count = 2 Then
                    Me.cboCustomers.SelectedValue = dt.Rows(0)("Cust_ID")
                    Me.PopulateLocationList()
                End If
            Catch ex As Exception
                Throw ex
            Finally
                _booPopulateData = False
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '**************************************************************************
        Private Sub PopulateLocationList()
            Dim dt As DataTable

            Try
                _booPopulateData = True
                dt = Generic.GetLocations(True, Me.cboCustomers.SelectedValue)
                Misc.PopulateC1DropDownList(Me.cboLocations, dt, "Loc_Name", "Loc_ID")
                If dt.Rows.Count = 2 Then
                    Me.cboLocations.SelectedValue = dt.Rows(0)("Loc_ID")
                Else
                End If
            Catch ex As Exception
                Throw ex
            Finally
                _booPopulateData = False
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '**************************************************************************
        Private Sub PopulateModelList()
            Dim dt As DataTable

            Try
                _booPopulateData = True
                dt = Generic.GetModels(True, Me.cboProdID.SelectedValue, , )
                Misc.PopulateC1DropDownList(Me.cboNewModel, dt, "Model_desc", "Model_id")

                Me.cboLocations.SelectedValue = 0

            Catch ex As Exception
                Throw ex
            Finally
                _booPopulateData = False
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '********************************************************************************
        Private Sub txtSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyUp
            Dim booProcessSN As Boolean = False
            Try
                If e.KeyCode = Keys.Enter Then
                    Me._iDeviceID = 0 : Me._iCurrentModelID = 0
                    If Me.txtSN.Text.Trim.Length > 0 Then
                        booProcessSN = Me.ProcessSN()

                        If booProcessSN = True Then
                            Me.cboNewModel.SelectAll() : Me.cboNewModel.Focus()
                        Else
                            Me.txtSN.SelectAll() : Me.txtSN.Focus()
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '********************************************************************************
        Private Function ProcessSN() As Boolean
            Dim dt As DataTable

            Try
                If Me.cboProdID.SelectedValue = 0 Then
                    MessageBox.Show("Please select product type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.cboProdID.SelectAll()
                    Me.cboProdID.Focus()
                ElseIf Me.cboCustomers.SelectedValue = 0 Then
                    MessageBox.Show("Please select customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.cboCustomers.SelectAll()
                    Me.cboCustomers.Focus()
                ElseIf Me.cboLocations.SelectedValue = 0 Then
                    MessageBox.Show("Please select location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.cboLocations.SelectAll()
                    Me.cboLocations.Focus()
                ElseIf Me.txtSN.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.txtSN.SelectAll()
                    Me.txtSN.Focus()
                Else
                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor

                    dt = Generic.GetDeviceInfoInWIP(Me.txtSN.Text.Trim, Me.cboCustomers.SelectedValue, Me.cboLocations.SelectedValue)
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("Device does not exist in WIP.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ElseIf dt.Rows.Count > 1 Then
                        MessageBox.Show("Device existed more than one today.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ElseIf Not IsDBNull(dt.Rows(0)("Pallett_ID")) AndAlso CInt(dt.Rows(0)("Pallett_ID")) > 0 Then
                        MessageBox.Show("Device has assigned to a pallett.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ElseIf Not IsDBNull(dt.Rows(0)("Ship_ID")) AndAlso CInt(dt.Rows(0)("Ship_ID")) > 0 Then
                        MessageBox.Show("Device has assigned to a Ship Manifest.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ElseIf Generic.IsDeviceHadParts(CInt(dt.Rows(0)("Device_ID"))) = True Then
                        MessageBox.Show("Please remove all part(s).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        Me._iCurrentModelID = dt.Rows(0)("Model_ID") : Me._iDeviceID = dt.Rows(0)("Device_ID") : Me.lblModel.Text = dt.Rows(0)("Model_Desc").ToString
                        Return True
                    End If
                End If 'Validation
            Catch ex As Exception
                Throw ex
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Function

        '********************************************************************************
        Private Sub btnChangeModel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeModel.Click
            Dim i As Integer = 0

            Try
                If Me.txtSN.Text.Trim.Length = 0 Then
                    Exit Sub
                ElseIf Me._iCurrentModelID = 0 Then
                    MessageBox.Show("Model ID is missing for this device.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.txtSN.SelectAll() : Me.txtSN.Focus()
                ElseIf Me._iDeviceID = 0 Then
                    MessageBox.Show("Model ID is missing for this device.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.txtSN.SelectAll() : Me.txtSN.Focus()
                ElseIf Me.cboNewModel.SelectedValue = 0 Then
                    MessageBox.Show("Please select new model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.cboNewModel.SelectAll() : Me.cboNewModel.Focus()
                ElseIf Me._iCurrentModelID = Me.cboNewModel.SelectedValue Then
                    MessageBox.Show("This device has the same model with new model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.cboNewModel.SelectAll() : Me.cboNewModel.Focus()
                Else
                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor

                    i = Generic.ChangeModel(Me._iDeviceID, Me._iCurrentModelID, Me.cboNewModel.SelectedValue, PSS.Core.ApplicationUser.IDuser)

                    If i > 0 Then
                        Me.Enabled = True
                        Me._iCurrentModelID = 0 : Me._iDeviceID = 0
                        Me.txtSN.Text = "" : Me.lblModel.Text = ""
                        Me.txtSN.Focus()
                    End If
                End If 'Validation
            Catch ex As Exception
                Throw ex
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        '********************************************************************************

    End Class
End Namespace