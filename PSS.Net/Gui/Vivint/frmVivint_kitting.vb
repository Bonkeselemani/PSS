
Option Explicit On 

Imports PSS.Data.Buisness
Imports System.Text

Namespace Gui.VV
    Public Class frmVivint_kitting
        Inherits System.Windows.Forms.Form

        Private _iCust_ID As Integer = 0
        Private iLoc_ID As Integer = 0
        Private billCode_ID As Integer = 0
        Private dtRep As New DataTable()
        Private kittingLimitbillcode As Integer = 0
        Private _strScreenName As String = ""
        Private _strRptName As String = ""
        Private _objVivint As PSS.Data.Buisness.VV.Vivint
        Private _objVivint_Kitting As PSS.Data.Buisness.VV.Vivint_Kitting
        Private dtNClaimed As New DataTable()
        Private dtClaimed As New DataTable()
        Private dtSN As New DataTable()
        Private _iUserID As Integer = PSS.Core.Global.ApplicationUser.IDuser
        Private _strUser As String = PSS.Core.Global.ApplicationUser.User

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strScreenName As String, ByVal iCust_ID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._iCust_ID = iCust_ID
            Me._strScreenName = strScreenName
            Me._objVivint = New PSS.Data.Buisness.VV.Vivint()
            Me._objVivint_Kitting = New PSS.Data.Buisness.VV.Vivint_Kitting()
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                Try
                    Me._objVivint = Nothing
                    Me._objVivint_Kitting = Nothing
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
        Friend WithEvents lbl As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents cmdPrint As System.Windows.Forms.Button
        Friend WithEvents cboSN As C1.Win.C1List.C1Combo
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents lblLocation As System.Windows.Forms.Label
        Friend WithEvents lblCustomer As System.Windows.Forms.Label
        Friend WithEvents cboLocation As C1.Win.C1List.C1Combo
        Friend WithEvents cboCustomer As C1.Win.C1List.C1Combo
        Friend WithEvents txtSN As System.Windows.Forms.TextBox
        Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
        Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
        Friend WithEvents tdgNClaimed As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents tdgClaimed As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmVivint_kitting))
            Me.lbl = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.CheckBox2 = New System.Windows.Forms.CheckBox()
            Me.cmdPrint = New System.Windows.Forms.Button()
            Me.cboSN = New C1.Win.C1List.C1Combo()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.CheckBox1 = New System.Windows.Forms.CheckBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.lblLocation = New System.Windows.Forms.Label()
            Me.lblCustomer = New System.Windows.Forms.Label()
            Me.cboLocation = New C1.Win.C1List.C1Combo()
            Me.cboCustomer = New C1.Win.C1List.C1Combo()
            Me.txtSN = New System.Windows.Forms.TextBox()
            Me.tdgNClaimed = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.tdgClaimed = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.GroupBox2.SuspendLayout()
            CType(Me.cboSN, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox1.SuspendLayout()
            CType(Me.cboLocation, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboCustomer, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.tdgNClaimed, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.tdgClaimed, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lbl
            '
            Me.lbl.BackColor = System.Drawing.Color.Black
            Me.lbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbl.ForeColor = System.Drawing.Color.Yellow
            Me.lbl.Location = New System.Drawing.Point(152, 0)
            Me.lbl.Name = "lbl"
            Me.lbl.Size = New System.Drawing.Size(383, 65)
            Me.lbl.TabIndex = 85
            Me.lbl.Text = "Vivint Kitting"
            Me.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label6
            '
            Me.Label6.BackColor = System.Drawing.Color.Transparent
            Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.Black
            Me.Label6.Location = New System.Drawing.Point(104, 80)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(128, 21)
            Me.Label6.TabIndex = 174
            Me.Label6.Text = "Kitting Job:"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label6.Visible = False
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.CheckBox2, Me.tdgClaimed})
            Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox2.ForeColor = System.Drawing.Color.White
            Me.GroupBox2.Location = New System.Drawing.Point(376, 208)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(336, 280)
            Me.GroupBox2.TabIndex = 175
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Re-Claimed"
            Me.GroupBox2.Visible = False
            '
            'CheckBox2
            '
            Me.CheckBox2.Location = New System.Drawing.Point(32, 16)
            Me.CheckBox2.Name = "CheckBox2"
            Me.CheckBox2.TabIndex = 181
            Me.CheckBox2.Text = "select All"
            '
            'cmdPrint
            '
            Me.cmdPrint.BackColor = System.Drawing.Color.LightSteelBlue
            Me.cmdPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdPrint.ForeColor = System.Drawing.Color.Blue
            Me.cmdPrint.Location = New System.Drawing.Point(232, 504)
            Me.cmdPrint.Name = "cmdPrint"
            Me.cmdPrint.Size = New System.Drawing.Size(224, 40)
            Me.cmdPrint.TabIndex = 176
            Me.cmdPrint.Text = "Print"
            Me.cmdPrint.Visible = False
            '
            'cboSN
            '
            Me.cboSN.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboSN.Caption = ""
            Me.cboSN.CaptionHeight = 17
            Me.cboSN.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboSN.ColumnCaptionHeight = 17
            Me.cboSN.ColumnFooterHeight = 17
            Me.cboSN.ContentHeight = 15
            Me.cboSN.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboSN.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboSN.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboSN.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboSN.EditorHeight = 15
            Me.cboSN.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboSN.ItemHeight = 15
            Me.cboSN.Location = New System.Drawing.Point(240, 80)
            Me.cboSN.MatchEntryTimeout = CType(2000, Long)
            Me.cboSN.MaxDropDownItems = CType(5, Short)
            Me.cboSN.MaxLength = 32767
            Me.cboSN.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboSN.Name = "cboSN"
            Me.cboSN.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboSN.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboSN.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboSN.Size = New System.Drawing.Size(264, 21)
            Me.cboSN.TabIndex = 177
            Me.cboSN.Visible = False
            Me.cboSN.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'GroupBox1
            '
            Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.CheckBox1, Me.tdgNClaimed})
            Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox1.ForeColor = System.Drawing.Color.White
            Me.GroupBox1.Location = New System.Drawing.Point(24, 208)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(336, 280)
            Me.GroupBox1.TabIndex = 176
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "New"
            Me.GroupBox1.Visible = False
            '
            'CheckBox1
            '
            Me.CheckBox1.Location = New System.Drawing.Point(40, 16)
            Me.CheckBox1.Name = "CheckBox1"
            Me.CheckBox1.TabIndex = 180
            Me.CheckBox1.Text = "select All"
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Black
            Me.Label1.Location = New System.Drawing.Point(104, 176)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(128, 21)
            Me.Label1.TabIndex = 178
            Me.Label1.Text = "SN:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblLocation
            '
            Me.lblLocation.BackColor = System.Drawing.Color.Transparent
            Me.lblLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblLocation.ForeColor = System.Drawing.Color.Black
            Me.lblLocation.Location = New System.Drawing.Point(160, 144)
            Me.lblLocation.Name = "lblLocation"
            Me.lblLocation.Size = New System.Drawing.Size(72, 21)
            Me.lblLocation.TabIndex = 180
            Me.lblLocation.Text = "Location:"
            Me.lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCustomer
            '
            Me.lblCustomer.BackColor = System.Drawing.Color.Transparent
            Me.lblCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCustomer.ForeColor = System.Drawing.Color.Black
            Me.lblCustomer.Location = New System.Drawing.Point(160, 112)
            Me.lblCustomer.Name = "lblCustomer"
            Me.lblCustomer.Size = New System.Drawing.Size(72, 21)
            Me.lblCustomer.TabIndex = 182
            Me.lblCustomer.Text = "Customer:"
            Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            Me.cboLocation.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboLocation.ItemHeight = 15
            Me.cboLocation.Location = New System.Drawing.Point(240, 144)
            Me.cboLocation.MatchEntryTimeout = CType(2000, Long)
            Me.cboLocation.MaxDropDownItems = CType(5, Short)
            Me.cboLocation.MaxLength = 32767
            Me.cboLocation.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboLocation.Name = "cboLocation"
            Me.cboLocation.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboLocation.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboLocation.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboLocation.Size = New System.Drawing.Size(264, 21)
            Me.cboLocation.TabIndex = 179
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
            'cboCustomer
            '
            Me.cboCustomer.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboCustomer.Caption = ""
            Me.cboCustomer.CaptionHeight = 17
            Me.cboCustomer.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboCustomer.ColumnCaptionHeight = 17
            Me.cboCustomer.ColumnFooterHeight = 17
            Me.cboCustomer.ContentHeight = 15
            Me.cboCustomer.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboCustomer.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboCustomer.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCustomer.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboCustomer.EditorHeight = 15
            Me.cboCustomer.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboCustomer.ItemHeight = 15
            Me.cboCustomer.Location = New System.Drawing.Point(240, 112)
            Me.cboCustomer.MatchEntryTimeout = CType(2000, Long)
            Me.cboCustomer.MaxDropDownItems = CType(5, Short)
            Me.cboCustomer.MaxLength = 32767
            Me.cboCustomer.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCustomer.Name = "cboCustomer"
            Me.cboCustomer.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCustomer.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCustomer.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCustomer.Size = New System.Drawing.Size(264, 21)
            Me.cboCustomer.TabIndex = 181
            Me.cboCustomer.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'txtSN
            '
            Me.txtSN.BackColor = System.Drawing.Color.White
            Me.txtSN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSN.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtSN.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtSN.Location = New System.Drawing.Point(240, 176)
            Me.txtSN.Name = "txtSN"
            Me.txtSN.Size = New System.Drawing.Size(264, 22)
            Me.txtSN.TabIndex = 183
            Me.txtSN.Text = ""
            '
            'tdgNClaimed
            '
            Me.tdgNClaimed.AllowColMove = False
            Me.tdgNClaimed.AllowColSelect = False
            Me.tdgNClaimed.AllowFilter = False
            Me.tdgNClaimed.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
            Me.tdgNClaimed.AllowSort = False
            Me.tdgNClaimed.AllowUpdateOnBlur = False
            Me.tdgNClaimed.CaptionHeight = 19
            Me.tdgNClaimed.CollapseColor = System.Drawing.Color.Transparent
            Me.tdgNClaimed.ExpandColor = System.Drawing.Color.Transparent
            Me.tdgNClaimed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgNClaimed.ForeColor = System.Drawing.Color.Transparent
            Me.tdgNClaimed.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgNClaimed.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.tdgNClaimed.Location = New System.Drawing.Point(8, 48)
            Me.tdgNClaimed.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.tdgNClaimed.Name = "tdgNClaimed"
            Me.tdgNClaimed.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgNClaimed.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgNClaimed.PreviewInfo.ZoomFactor = 75
            Me.tdgNClaimed.RowHeight = 20
            Me.tdgNClaimed.Size = New System.Drawing.Size(320, 224)
            Me.tdgNClaimed.TabIndex = 184
            Me.tdgNClaimed.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            "ticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>220</Height><CaptionStyle" & _
            " parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><Even" & _
            "RowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""S" & _
            "tyle13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" " & _
            "me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle p" & _
            "arent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" " & _
            "/><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""Record" & _
            "Selector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style p" & _
            "arent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 316, 220</ClientRect><BorderSide>" & _
            "0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView><" & _
            "/Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""H" & _
            "eading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Capt" & _
            "ion"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Select" & _
            "ed"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightR" & _
            "ow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /" & _
            "><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""Filter" & _
            "Bar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSpl" & _
            "its><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</Defau" & _
            "ltRecSelWidth><ClientArea>0, 0, 316, 220</ClientArea><PrintPageHeaderStyle paren" & _
            "t="""" me=""Style16"" /><PrintPageFooterStyle parent="""" me=""Style17"" /></Blob>"
            '
            'tdgClaimed
            '
            Me.tdgClaimed.AllowColMove = False
            Me.tdgClaimed.AllowColSelect = False
            Me.tdgClaimed.AllowFilter = False
            Me.tdgClaimed.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
            Me.tdgClaimed.AllowSort = False
            Me.tdgClaimed.AllowUpdateOnBlur = False
            Me.tdgClaimed.CaptionHeight = 19
            Me.tdgClaimed.CollapseColor = System.Drawing.Color.Transparent
            Me.tdgClaimed.ExpandColor = System.Drawing.Color.Transparent
            Me.tdgClaimed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgClaimed.ForeColor = System.Drawing.Color.Transparent
            Me.tdgClaimed.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgClaimed.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.tdgClaimed.Location = New System.Drawing.Point(8, 48)
            Me.tdgClaimed.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.tdgClaimed.Name = "tdgClaimed"
            Me.tdgClaimed.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgClaimed.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgClaimed.PreviewInfo.ZoomFactor = 75
            Me.tdgClaimed.RowHeight = 20
            Me.tdgClaimed.Size = New System.Drawing.Size(320, 224)
            Me.tdgClaimed.TabIndex = 184
            Me.tdgClaimed.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            "ticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>220</Height><CaptionStyle" & _
            " parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><Even" & _
            "RowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""S" & _
            "tyle13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" " & _
            "me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle p" & _
            "arent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" " & _
            "/><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""Record" & _
            "Selector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style p" & _
            "arent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 316, 220</ClientRect><BorderSide>" & _
            "0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView><" & _
            "/Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""H" & _
            "eading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Capt" & _
            "ion"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Select" & _
            "ed"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightR" & _
            "ow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /" & _
            "><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""Filter" & _
            "Bar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSpl" & _
            "its><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</Defau" & _
            "ltRecSelWidth><ClientArea>0, 0, 316, 220</ClientArea><PrintPageHeaderStyle paren" & _
            "t="""" me=""Style16"" /><PrintPageFooterStyle parent="""" me=""Style17"" /></Blob>"
            '
            'frmVivint_kitting
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(736, 574)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtSN, Me.lblLocation, Me.lblCustomer, Me.cboLocation, Me.cboCustomer, Me.Label1, Me.cboSN, Me.cmdPrint, Me.GroupBox2, Me.Label6, Me.lbl, Me.GroupBox1})
            Me.Name = "frmVivint_kitting"
            Me.Text = "frmVivint_kitting"
            Me.GroupBox2.ResumeLayout(False)
            CType(Me.cboSN, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox1.ResumeLayout(False)
            CType(Me.cboLocation, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboCustomer, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.tdgNClaimed, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.tdgClaimed, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region


        'Private Sub txtSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyUp
        '    If e.KeyCode = Keys.Enter Then

        '    End If
        'End Sub


        Private Sub txtSN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyUp
            If e.KeyCode = Keys.Enter Then

                If Me._iCust_ID > 0 AndAlso txtSN.Text.Trim.Length > 0 Then
                    Dim strSN As String = txtSN.Text.Trim
                    Dim objVivint As New PSS.Data.Buisness.VV.Vivint()
                    Me.txtSN.Text = objVivint.RemovePrefixSN(strSN, Me._iCust_ID)
                    objVivint = Nothing
                End If

                If Me.txtSN.Text.Trim.Length > 0 AndAlso Me.txtSN.Text <> String.Empty Then
                    _objVivint_Kitting = New PSS.Data.Buisness.VV.Vivint_Kitting()
                    _iCust_ID = _objVivint.Vivint_CUSTOMER_ID
                    dtSN = Me._objVivint_Kitting.checkSN(txtSN.Text)
                    If dtSN.Rows.Count > 0 Then
                        Dim ktStUpDt As DataTable = Me._objVivint_Kitting.GetBOMData(dtSN.Rows(0).Item(0), _iCust_ID)
                        Dim r As DataRow


                        CheckBox1.Checked = False
                        dtClaimed.Rows.Clear()
                        dtNClaimed.Rows.Clear()

                        For Each r In ktStUpDt.Rows
                            Dim model_desc As String = r.Item("Model_desc")
                            Dim chkRv As String = r.Item("Component_Type")
                            If chkRv = "Part_RV" Then
                                Dim row As String() = New String() {False, r.Item("Model_desc"), r.Item("PSPrice_Desc"), r.Item("PSPrice_Number")}
                                dtClaimed.Rows.Add(row)
                                GroupBox2.Visible = True
                            Else
                                Dim row1 As String() = New String() {False, r.Item("Model_desc"), r.Item("PSPrice_Desc"), r.Item("PSPrice_Number")}
                                dtNClaimed.Rows.Add(row1)
                                GroupBox1.Visible = True
                            End If


                        Next
                        If GroupBox1.Visible Then
                            tdgNClaimed.DataSource = dtNClaimed
                        End If
                        If GroupBox2.Visible Then
                            tdgClaimed.DataSource = dtClaimed
                        End If
                        cmdPrint.Visible = True

                    Else
                        MessageBox.Show("The device can't be kitted", "Kitting", MessageBoxButtons.OK)
                        Exit Sub
                    End If



                End If

            End If
        End Sub



        Private Sub frmVivint_kitting_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load


            Dim dt As New DataTable()
            Dim dtLoc As New DataTable()
            '_objVivint_Kitting = New PSS.Data.Buisness.VV.Vivint_Kitting()
            'dt = Me._objVivint_Kitting.getVivintKitting
            'Misc.PopulateC1DropDownList(Me.cboSN, dt, "Kitting_SetUp", "master_model_id")

            'Populate customer
            dt = Generic.GetCustomers(True, )
            Misc.PopulateC1DropDownList(Me.cboCustomer, dt, "Cust_Name1", "Cust_ID")
            Me.cboCustomer.SelectedValue = Me._iCust_ID
            If Me.cboCustomer.SelectedValue > 0 Then Me.cboCustomer.Enabled = False

            'Location
            dtLoc = Generic.GetLocations(True, Me._iCust_ID)
            Misc.PopulateC1DropDownList(Me.cboLocation, dtLoc, "Loc_Name", "Loc_ID")
            If dtLoc.Rows.Count = 2 Then
                iLoc_ID = dtLoc.Rows(0).Item("Loc_ID")
                Me.cboLocation.SelectedValue = iLoc_ID

            Else
                Me.cboLocation.SelectedValue = 0
                Me.cboLocation.Focus()
            End If

            dtClaimed.Columns.Add("Selected?", GetType(Boolean))
            dtClaimed.Columns.Add("Model_desc", GetType(String))
            dtClaimed.Columns.Add("PSPRice_Desc", GetType(String))
            dtClaimed.Columns.Add("PSPrice_Number", GetType(String))


            dtNClaimed.Columns.Add("Selected?", GetType(Boolean))
            dtNClaimed.Columns.Add("Model_desc", GetType(String))
            dtNClaimed.Columns.Add("PSPRice_Desc", GetType(String))
            dtNClaimed.Columns.Add("PSPrice_Number", GetType(String))


            dtRep.Columns.Add("sn", GetType(String))
            dtRep.Columns.Add("snBk", GetType(String))
            dtRep.Columns.Add("devDesc", GetType(String))
            dtRep.Columns.Add("sku", GetType(String))
            dtRep.Columns.Add("skuBk", GetType(String))

        End Sub




        Private Sub cmdPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdPrint.Click

            Dim r As Integer = 0
            Dim psPrice As String = String.Empty
            Dim partCharge As Double = 0.0
            Dim FontEncoder As New IDAutomation.NetAssembly.FontEncoder()
            _objVivint_Kitting = New PSS.Data.Buisness.VV.Vivint_Kitting()
            Dim saved As Boolean = False
            Dim totalCharge As Double = 0.0
            Dim todDate As String = String.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now)
            _iCust_ID = _objVivint.Vivint_CUSTOMER_ID
            billCode_ID = _objVivint.Vivint_Kitting_BillCode_ID
            kittingLimitbillcode = _objVivint.Vivint_KittingLimit_BillCode_ID
            Dim deviceId As String = dtSN.Rows(0).Item(1)
            dtRep.Rows.Clear()
            Dim dtBom As DataTable = Me._objVivint_Kitting.GetBOMData(dtSN.Rows(0).Item(0), _iCust_ID)
            Dim labourCharge As DataTable = Me._objVivint_Kitting.kittingCharges(_iCust_ID, billCode_ID)
            Dim kittingLimit As DataTable = Me._objVivint_Kitting.kittingLimitCharges(_iCust_ID, kittingLimitbillcode, dtSN.Rows(0).Item(0))
            If IsDBNull(dtSN.Rows(0).Item(2)) Then
                MessageBox.Show("The device labour Charge can't be found. Contact IT.", "Not Kittable", MessageBoxButtons.OK)
                Exit Sub
            End If
            If IsDBNull(dtSN.Rows(0).Item(3)) Then
                partCharge = 0.0
            Else
                Dim rowcount As Int16 = dtSN.Rows.Count
                partCharge = dtSN.Rows(0).Item(3)
            End If
            If labourCharge.Rows.Count > 0 Then
                totalCharge = labourCharge.Rows(0).Item(0) + dtSN.Rows(0).Item(2) + partCharge
            Else
                MessageBox.Show("The device labour Charge can't be found. Contact IT.", "Not Kittable", MessageBoxButtons.OK)
                Exit Sub
            End If

            If labourCharge.Rows.Count > 0 And kittingLimit.Rows.Count > 0 Then
            Else
                MessageBox.Show("Labour charges doesn't exist for this device", "Not Kittable", MessageBoxButtons.OK)
                Exit Sub
            End If
            If totalCharge > kittingLimit.Rows(0).Item(0) Then
                MessageBox.Show("This Item can't be kitted", "Not Kittable", MessageBoxButtons.OK)
                Exit Sub
            End If


            'check if the device was kitted before


            Dim checkKit As DataTable = Me._objVivint_Kitting.checkKittedDevice(deviceId)
            If checkKit.Rows.Count > 0 Then
                Dim result As DialogResult = MessageBox.Show("The device has already been kitted" & vbNewLine & "do you want to print it again?", "Not Kittable", MessageBoxButtons.YesNo)
                If result = DialogResult.Yes Then
                    Dim dt As DataTable = Me._objVivint_Kitting.modelName(dtBom.Rows(0).Item(3))
                    Dim sku As String = dt.Rows(0).Item("shippedmodel")
                    psPrice = tdgNClaimed.Item(r, 3)
                    Dim dtPrice As DataTable = Me._objVivint_Kitting.getPrice(psPrice)
                    Dim row As String() = New String() {txtSN.Text, Me.IDAutomation_QRFontEncoder(txtSN.Text), dtBom.Rows(0).Item(11), sku, Me.IDAutomation_QRFontEncoder(sku)}
                    dtRep.Rows.Add(row)
                    PSS.Data.Production.Shipping.PrintVivintKittedLabel(dtRep)
                End If
                Exit Sub
            End If


            If GroupBox1.Visible Then

                For r = 0 To tdgNClaimed.RowCount - 1
                    If tdgNClaimed.Item(r, 0) = True Then
                        psPrice = tdgNClaimed.Item(r, 3)

                        Dim dtPrice As DataTable = Me._objVivint_Kitting.getPrice(psPrice)

                        'First save to tdevice_kitting
                        If saved = False And kittingLimit.Rows(0).Item(0) >= totalCharge Then
                            Dim savedN As Integer = Me._objVivint_Kitting.saveKitting(dtBom.Rows(0).Item(0), deviceId, labourCharge.Rows(0).Item(0), 0, _iUserID, todDate)
                            'strQR_Data_BarCode = Me.IDAutomation_QRFontEncoder(txtPO.Text)
                            Dim dt As DataTable = Me._objVivint_Kitting.modelName(dtBom.Rows(0).Item(3))
                            Dim sku As String = dt.Rows(0).Item("shippedmodel")
                            Dim row As String() = New String() {txtSN.Text, Me.IDAutomation_QRFontEncoder(txtSN.Text), dtBom.Rows(0).Item(11), sku, Me.IDAutomation_QRFontEncoder(sku)}
                            dtRep.Rows.Add(row)
                            saved = True

                        End If
                        If saved Then

                            Dim savedNKB As Integer = Me._objVivint_Kitting.saveKittingBill(deviceId, 0, dtPrice.Rows(0).Item(0), dtPrice.Rows(0).Item(1), dtBom.Rows(0).Item(0), billCode_ID, dtPrice.Rows(0).Item(2), labourCharge.Rows(0).Item(0), 0)



                        End If

                        'First save to tdevice_KittingBill



                    End If
                Next

            End If

            If GroupBox2.Visible Then
                r = 0
                For r = 0 To tdgClaimed.RowCount - 1
                    If tdgClaimed.Item(r, 0) = True Then

                        psPrice = tdgClaimed.Item(r, 3)

                        Dim dtPrice As DataTable = Me._objVivint_Kitting.getPrice(psPrice)

                        'First save to tdevice_kitting
                        If saved = False And kittingLimit.Rows(0).Item(0) >= totalCharge Then
                            Dim savedN As Integer = Me._objVivint_Kitting.saveKitting(dtBom.Rows(0).Item(0), deviceId, labourCharge.Rows(0).Item(0), 0, _iUserID, todDate)
                            'strQR_Data_BarCode = Me.IDAutomation_QRFontEncoder(txtPO.Text)
                            Dim dt As DataTable = Me._objVivint_Kitting.modelName(dtBom.Rows(0).Item(3))
                            Dim sku As String = dt.Rows(0).Item("shippedmodel")
                            Dim row As String() = New String() {txtSN.Text, Me.IDAutomation_QRFontEncoder(txtSN.Text), dtBom.Rows(0).Item(11), sku, Me.IDAutomation_QRFontEncoder(sku)}
                            dtRep.Rows.Add(row)
                            saved = True

                        End If
                        If saved Then

                            Dim savedNKB As Integer = Me._objVivint_Kitting.saveKittingBill(deviceId, 0, dtPrice.Rows(0).Item(0), dtPrice.Rows(0).Item(1), dtBom.Rows(0).Item(0), billCode_ID, dtPrice.Rows(0).Item(2), labourCharge.Rows(0).Item(0), 0)



                        End If

                        'First save to 

                    End If
                Next



            End If

            'Print LabEL
            If saved Then
                PSS.Data.Production.Shipping.PrintVivintKittedLabel(dtRep)
                'Reset all selected 
                For r = 0 To tdgNClaimed.RowCount - 1
                    tdgNClaimed.Item(r, 0) = False
                Next
                For r = 0 To tdgClaimed.RowCount - 1
                    tdgClaimed.Item(r, 0) = False
                Next
                txtSN.Text = String.Empty
                txtSN.Focus()
            End If

        End Sub


        Private Function reprint(ByVal dtprice As DataTable) As Boolean


        End Function

        Private Function IDAutomation_QRFontEncoder(ByVal DataToEncode As String) As String
            Dim ProcTilde As Integer
            ProcTilde = 1 'If = 1 the Tilde will be processed | http://www.idautomation.com/barcode-faq/2d/qr-code/#Control_Characters
            Dim EncMode As Integer
            EncMode = 0 '0=Binary | 1=0nly numbers and uppercase letters | 2=Numbers only
            Dim ErrorCorrectionLevel As Integer
            ErrorCorrectionLevel = 0 '0=15% | 1=30% | 2=7% | 3-25% | http://www.idautomation.com/barcode-faq/2d/qr-code/#Encoding_Modes
            Dim Version As Integer
            Version = 0 '0=Automatic | http://www.idautomation.com/barcode-faq/2d/qr-code/#Symbol_Version
            'Format the data to the QRCode Font by calling the Com DLL:
            Dim QRFontEncoder As QRCODELib.QRCode ' QRCode
            QRFontEncoder = New QRCODELib.QRCode() ' QRCode()
            QRFontEncoder.FontEncode(DataToEncode, ProcTilde, EncMode, Version, ErrorCorrectionLevel, IDAutomation_QRFontEncoder)
            QRFontEncoder = Nothing
        End Function
        Private Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
            Dim r As Integer = 0
            If CheckBox1.Checked Then

                For r = 0 To tdgNClaimed.RowCount - 1

                    tdgNClaimed.Item(r, 0) = True



                Next
            Else
                For r = 0 To tdgNClaimed.RowCount - 1
                    tdgNClaimed.Item(r, 0) = False
                Next
            End If
        End Sub



        Private Sub CheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged


            Dim r As Integer = 0
            If CheckBox2.Checked Then

                For r = 0 To tdgClaimed.RowCount - 1

                    tdgClaimed.Item(r, 0) = True



                Next
            Else
                For r = 0 To tdgClaimed.RowCount - 1

                    tdgClaimed.Item(r, 0) = False


                Next
            End If

        End Sub

        Private Sub tdgNClaimed_Change(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdgNClaimed.Change
            Dim r As Integer = 0
            Dim td As Integer = 0
            For td = 0 To tdgNClaimed.RowCount - 1
                For r = 0 To tdgClaimed.RowCount - 1
                    If tdgNClaimed.Item(td, 3) = tdgClaimed.Item(r, 3) And tdgClaimed.Item(r, 0) = True And tdgNClaimed.Item(td, 0) = True Then
                        MessageBox.Show("you can't select similar items from new and reclaimed group", "items", MessageBoxButtons.OK)
                        tdgClaimed.Item(r, 0) = False
                    End If



                Next
            Next
        End Sub

        Private Sub tdgClaimed_Change(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdgClaimed.Change
            Dim r As Integer = 0
            Dim td As Integer = 0
            For td = 0 To tdgNClaimed.RowCount - 1
                For r = 0 To tdgClaimed.RowCount - 1
                    If tdgNClaimed.Item(td, 3) = tdgClaimed.Item(r, 3) And tdgClaimed.Item(r, 0) = True And tdgNClaimed.Item(td, 0) = True Then
                        MessageBox.Show("you can't select similar items from new and reclaimed group", "items", MessageBoxButtons.OK)
                        tdgClaimed.Item(r, 0) = False
                    End If



                Next
            Next
        End Sub

    End Class
End Namespace