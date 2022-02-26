Option Explicit On 
Imports PDF417Lib
Imports PSS.Data.Buisness
Imports System.Text

Namespace Gui.Vinsmart
    Public Class frmVinsmart_SpecialKit
        Inherits System.Windows.Forms.Form
        Private _iMenuCustID As Integer = 0
        Private _iMenuLocID As Integer = 0
        Private _strScreenName As String = ""
        Private _dtKitting As DataTable
        Private _strKittedSession As String = ""

        Private _objVinsmart As PSS.Data.Buisness.Vinsmart.Vinsmart
        Private _objVinsmart_SP As PSS.Data.Buisness.Vinsmart.Vinsmart_SpecialProject
        Private _objVinsmart_SPKit As PSS.Data.Buisness.Vinsmart.Vinsmart_SpecialKit
        Private _objVinsmart_BoxShip As PSS.Data.Buisness.Vinsmart.Vinsmart_BoxShip

        Private _strUserName As String = PSS.Core.Global.ApplicationUser.User
        Private _iUserID As Integer = PSS.Core.Global.ApplicationUser.IDuser
        Private _iShiftID As Integer = PSS.Core.Global.ApplicationUser.IDShift
        Private _strWorkDate As String = PSS.Core.Global.ApplicationUser.Workdate
        Private strAccount As String = "6K202Project"
        Private iLoc_ID As Integer = 0
        Private iCust_ID As Integer = 0

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal iCust_ID As Integer, ByVal iLoc_ID As Integer, ByVal strScreenName As String)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._iMenuCustID = iCust_ID
            Me._iMenuLocID = iLoc_ID
            Me._strScreenName = strScreenName

            Me._objVinsmart = New PSS.Data.Buisness.Vinsmart.Vinsmart()
            Me._objVinsmart_SP = New PSS.Data.Buisness.Vinsmart.Vinsmart_SpecialProject()
            Me._objVinsmart_SPKit = New PSS.Data.Buisness.Vinsmart.Vinsmart_SpecialKit()
            Me._objVinsmart_BoxShip = New PSS.Data.Buisness.Vinsmart.Vinsmart_BoxShip()
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                Try
                    Me._objVinsmart = Nothing
                    Me._objVinsmart_SP = Nothing
                    Me._objVinsmart_BoxShip = Nothing
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
        Friend WithEvents btnClearEntry As System.Windows.Forms.Button
        Friend WithEvents lblAccount As System.Windows.Forms.Label
        Friend WithEvents cboAccount As C1.Win.C1List.C1Combo
        Friend WithEvents rbtByICCID As System.Windows.Forms.RadioButton
        Friend WithEvents rbtByIMEI As System.Windows.Forms.RadioButton
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents txtDeviceIMEI As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents cboModel As C1.Win.C1List.C1Combo
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents cboCustomer As C1.Win.C1List.C1Combo
        Friend WithEvents lblLocation As System.Windows.Forms.Label
        Friend WithEvents cboLocation As C1.Win.C1List.C1Combo
        Friend WithEvents btnDelAll As System.Windows.Forms.Button
        Friend WithEvents btnDelOne As System.Windows.Forms.Button
        Friend WithEvents tdgIMEI_ICCID As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents txtSIMCardICCID As System.Windows.Forms.TextBox
        Friend WithEvents lblKittedQty As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmVinsmart_SpecialKit))
            Me.btnClearEntry = New System.Windows.Forms.Button()
            Me.lblAccount = New System.Windows.Forms.Label()
            Me.cboAccount = New C1.Win.C1List.C1Combo()
            Me.rbtByICCID = New System.Windows.Forms.RadioButton()
            Me.rbtByIMEI = New System.Windows.Forms.RadioButton()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.txtDeviceIMEI = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.cboModel = New C1.Win.C1List.C1Combo()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.cboCustomer = New C1.Win.C1List.C1Combo()
            Me.lblLocation = New System.Windows.Forms.Label()
            Me.cboLocation = New C1.Win.C1List.C1Combo()
            Me.btnDelAll = New System.Windows.Forms.Button()
            Me.btnDelOne = New System.Windows.Forms.Button()
            Me.tdgIMEI_ICCID = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.txtSIMCardICCID = New System.Windows.Forms.TextBox()
            Me.lblKittedQty = New System.Windows.Forms.Label()
            CType(Me.cboAccount, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboModel, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboCustomer, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboLocation, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.tdgIMEI_ICCID, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'btnClearEntry
            '
            Me.btnClearEntry.ForeColor = System.Drawing.Color.White
            Me.btnClearEntry.Location = New System.Drawing.Point(412, 87)
            Me.btnClearEntry.Name = "btnClearEntry"
            Me.btnClearEntry.Size = New System.Drawing.Size(72, 22)
            Me.btnClearEntry.TabIndex = 217
            Me.btnClearEntry.Text = "Clear Entry"
            '
            'lblAccount
            '
            Me.lblAccount.BackColor = System.Drawing.Color.Transparent
            Me.lblAccount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblAccount.ForeColor = System.Drawing.Color.White
            Me.lblAccount.Location = New System.Drawing.Point(412, 47)
            Me.lblAccount.Name = "lblAccount"
            Me.lblAccount.Size = New System.Drawing.Size(72, 21)
            Me.lblAccount.TabIndex = 216
            Me.lblAccount.Text = "Account:"
            Me.lblAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboAccount
            '
            Me.cboAccount.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboAccount.Caption = ""
            Me.cboAccount.CaptionHeight = 17
            Me.cboAccount.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboAccount.ColumnCaptionHeight = 17
            Me.cboAccount.ColumnFooterHeight = 17
            Me.cboAccount.ContentHeight = 15
            Me.cboAccount.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboAccount.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboAccount.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboAccount.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboAccount.EditorHeight = 15
            Me.cboAccount.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboAccount.ItemHeight = 15
            Me.cboAccount.Location = New System.Drawing.Point(492, 47)
            Me.cboAccount.MatchEntryTimeout = CType(2000, Long)
            Me.cboAccount.MaxDropDownItems = CType(5, Short)
            Me.cboAccount.MaxLength = 32767
            Me.cboAccount.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboAccount.Name = "cboAccount"
            Me.cboAccount.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboAccount.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboAccount.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboAccount.Size = New System.Drawing.Size(240, 21)
            Me.cboAccount.TabIndex = 215
            Me.cboAccount.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'rbtByICCID
            '
            Me.rbtByICCID.ForeColor = System.Drawing.Color.White
            Me.rbtByICCID.Location = New System.Drawing.Point(556, 199)
            Me.rbtByICCID.Name = "rbtByICCID"
            Me.rbtByICCID.Size = New System.Drawing.Size(136, 16)
            Me.rbtByICCID.TabIndex = 214
            Me.rbtByICCID.Text = "By ICCID"
            '
            'rbtByIMEI
            '
            Me.rbtByIMEI.ForeColor = System.Drawing.Color.White
            Me.rbtByIMEI.Location = New System.Drawing.Point(556, 175)
            Me.rbtByIMEI.Name = "rbtByIMEI"
            Me.rbtByIMEI.Size = New System.Drawing.Size(136, 16)
            Me.rbtByIMEI.TabIndex = 213
            Me.rbtByIMEI.Text = "By IMEI"
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(20, 111)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(136, 21)
            Me.Label4.TabIndex = 211
            Me.Label4.Text = "SIM Card ICCID:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtDeviceIMEI
            '
            Me.txtDeviceIMEI.BackColor = System.Drawing.Color.White
            Me.txtDeviceIMEI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDeviceIMEI.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDeviceIMEI.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtDeviceIMEI.Location = New System.Drawing.Point(156, 87)
            Me.txtDeviceIMEI.Name = "txtDeviceIMEI"
            Me.txtDeviceIMEI.Size = New System.Drawing.Size(240, 22)
            Me.txtDeviceIMEI.TabIndex = 209
            Me.txtDeviceIMEI.Text = ""
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(20, 87)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(136, 21)
            Me.Label3.TabIndex = 210
            Me.Label3.Text = "Device IMEI:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(52, 47)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(104, 21)
            Me.Label2.TabIndex = 208
            Me.Label2.Text = "Model (Sku):"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            Me.cboModel.Location = New System.Drawing.Point(156, 47)
            Me.cboModel.MatchEntryTimeout = CType(2000, Long)
            Me.cboModel.MaxDropDownItems = CType(5, Short)
            Me.cboModel.MaxLength = 32767
            Me.cboModel.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboModel.Name = "cboModel"
            Me.cboModel.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboModel.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboModel.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboModel.Size = New System.Drawing.Size(240, 21)
            Me.cboModel.TabIndex = 207
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
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(76, 15)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(72, 21)
            Me.Label1.TabIndex = 206
            Me.Label1.Text = "Customer:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            Me.cboCustomer.Location = New System.Drawing.Point(156, 15)
            Me.cboCustomer.MatchEntryTimeout = CType(2000, Long)
            Me.cboCustomer.MaxDropDownItems = CType(5, Short)
            Me.cboCustomer.MaxLength = 32767
            Me.cboCustomer.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCustomer.Name = "cboCustomer"
            Me.cboCustomer.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCustomer.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCustomer.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCustomer.Size = New System.Drawing.Size(240, 21)
            Me.cboCustomer.TabIndex = 205
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
            'lblLocation
            '
            Me.lblLocation.BackColor = System.Drawing.Color.Transparent
            Me.lblLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblLocation.ForeColor = System.Drawing.Color.White
            Me.lblLocation.Location = New System.Drawing.Point(412, 15)
            Me.lblLocation.Name = "lblLocation"
            Me.lblLocation.Size = New System.Drawing.Size(72, 21)
            Me.lblLocation.TabIndex = 204
            Me.lblLocation.Text = "Location:"
            Me.lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            Me.cboLocation.Location = New System.Drawing.Point(492, 15)
            Me.cboLocation.MatchEntryTimeout = CType(2000, Long)
            Me.cboLocation.MaxDropDownItems = CType(5, Short)
            Me.cboLocation.MaxLength = 32767
            Me.cboLocation.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboLocation.Name = "cboLocation"
            Me.cboLocation.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboLocation.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboLocation.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboLocation.Size = New System.Drawing.Size(240, 21)
            Me.cboLocation.TabIndex = 203
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
            'btnDelAll
            '
            Me.btnDelAll.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnDelAll.ForeColor = System.Drawing.Color.White
            Me.btnDelAll.Location = New System.Drawing.Point(540, 231)
            Me.btnDelAll.Name = "btnDelAll"
            Me.btnDelAll.Size = New System.Drawing.Size(152, 32)
            Me.btnDelAll.TabIndex = 202
            Me.btnDelAll.TabStop = False
            Me.btnDelAll.Text = "Undo All"
            '
            'btnDelOne
            '
            Me.btnDelOne.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnDelOne.ForeColor = System.Drawing.Color.White
            Me.btnDelOne.Location = New System.Drawing.Point(540, 135)
            Me.btnDelOne.Name = "btnDelOne"
            Me.btnDelOne.Size = New System.Drawing.Size(152, 32)
            Me.btnDelOne.TabIndex = 201
            Me.btnDelOne.TabStop = False
            Me.btnDelOne.Text = "Undo One"
            '
            'tdgIMEI_ICCID
            '
            Me.tdgIMEI_ICCID.AllowColMove = False
            Me.tdgIMEI_ICCID.AllowColSelect = False
            Me.tdgIMEI_ICCID.AllowFilter = False
            Me.tdgIMEI_ICCID.AllowSort = False
            Me.tdgIMEI_ICCID.AllowUpdate = False
            Me.tdgIMEI_ICCID.AlternatingRows = True
            Me.tdgIMEI_ICCID.BackColor = System.Drawing.Color.GhostWhite
            Me.tdgIMEI_ICCID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tdgIMEI_ICCID.CaptionHeight = 17
            Me.tdgIMEI_ICCID.FetchRowStyles = True
            Me.tdgIMEI_ICCID.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgIMEI_ICCID.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgIMEI_ICCID.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.tdgIMEI_ICCID.Location = New System.Drawing.Point(52, 135)
            Me.tdgIMEI_ICCID.Name = "tdgIMEI_ICCID"
            Me.tdgIMEI_ICCID.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgIMEI_ICCID.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgIMEI_ICCID.PreviewInfo.ZoomFactor = 75
            Me.tdgIMEI_ICCID.RowHeight = 15
            Me.tdgIMEI_ICCID.Size = New System.Drawing.Size(480, 488)
            Me.tdgIMEI_ICCID.TabIndex = 200
            Me.tdgIMEI_ICCID.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Style9{}Normal{Font:Tahoma, 8.25pt;}HighlightRow{ForeColo" & _
            "r:HighlightText;BackColor:Highlight;}Style12{}OddRow{}RecordSelector{AlignImage:" & _
            "Center;}Style13{}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;Fo" & _
            "reColor:ControlText;BackColor:Control;}Style8{}Style10{AlignHorz:Near;}Style11{}" & _
            "Style14{}Style15{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView" & _
            " AllowColMove=""False"" AllowColSelect=""False"" Name="""" AlternatingRowStyle=""True"" " & _
            "CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyl" & _
            "es=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidt" & _
            "h=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>486</Height><Ca" & _
            "ptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style" & _
            "5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""Filter" & _
            "Bar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle paren" & _
            "t=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLight" & _
            "RowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me" & _
            "=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle pare" & _
            "nt=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" " & _
            "/><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 478, 486</ClientRect><B" & _
            "orderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.M" & _
            "ergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Nor" & _
            "mal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading" & _
            """ me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" " & _
            "me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""" & _
            "HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=" & _
            """OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" " & _
            "me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>" & _
            "1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth" & _
            ">17</DefaultRecSelWidth><ClientArea>0, 0, 478, 486</ClientArea><PrintPageHeaderS" & _
            "tyle parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></B" & _
            "lob>"
            '
            'txtSIMCardICCID
            '
            Me.txtSIMCardICCID.BackColor = System.Drawing.Color.White
            Me.txtSIMCardICCID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSIMCardICCID.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtSIMCardICCID.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtSIMCardICCID.Location = New System.Drawing.Point(156, 111)
            Me.txtSIMCardICCID.Name = "txtSIMCardICCID"
            Me.txtSIMCardICCID.Size = New System.Drawing.Size(240, 22)
            Me.txtSIMCardICCID.TabIndex = 199
            Me.txtSIMCardICCID.Text = ""
            '
            'lblKittedQty
            '
            Me.lblKittedQty.BackColor = System.Drawing.Color.Transparent
            Me.lblKittedQty.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblKittedQty.ForeColor = System.Drawing.Color.Black
            Me.lblKittedQty.Location = New System.Drawing.Point(412, 115)
            Me.lblKittedQty.Name = "lblKittedQty"
            Me.lblKittedQty.Size = New System.Drawing.Size(120, 21)
            Me.lblKittedQty.TabIndex = 212
            Me.lblKittedQty.Text = "0"
            Me.lblKittedQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'frmVinsmart_SpecialKit
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(752, 638)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnClearEntry, Me.lblAccount, Me.cboAccount, Me.rbtByICCID, Me.rbtByIMEI, Me.Label4, Me.txtDeviceIMEI, Me.Label3, Me.Label2, Me.cboModel, Me.Label1, Me.cboCustomer, Me.lblLocation, Me.cboLocation, Me.btnDelAll, Me.btnDelOne, Me.tdgIMEI_ICCID, Me.txtSIMCardICCID, Me.lblKittedQty})
            Me.Name = "frmVinsmart_SpecialKit"
            Me.Text = "frmVinsmart_SpecialKit"
            CType(Me.cboAccount, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboModel, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboCustomer, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboLocation, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.tdgIMEI_ICCID, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmVinsmart_SpecialKit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Dim strCustLoc As String = ""
            Dim dtLoc, dtCust, dtAcct As DataTable

            Dim dtModel, dtModel_Seed As DataTable
            Dim dtDOA As DataTable

            Try
                PSS.Core.Highlight.SetHighLight(Me)


                'Initialize dt table
                Me._dtKitting = Me._objVinsmart_SPKit.GetKitDatatableDef
                Me.rbtByIMEI.Checked = True

                dtCust = Generic.GetCustomers(True, )
                Misc.PopulateC1DropDownList(Me.cboCustomer, dtCust, "Cust_Name1", "Cust_ID")
                Me.cboCustomer.SelectedValue = Me._iMenuCustID
                If Me.cboCustomer.SelectedValue > 0 Then Me.cboCustomer.Enabled = False



                'Loc info
                dtLoc = Me._objVinsmart_BoxShip.GetVinsmartLocations(Me._iMenuCustID, False)
                Misc.PopulateC1DropDownList(Me.cboLocation, dtLoc, "Loc_Name", "Loc_ID")
                Me.cboLocation.SelectedValue = Me._iMenuLocID
                If Me.cboLocation.SelectedValue > 0 Then Me.cboLocation.Enabled = False

                iLoc_ID = cboLocation.SelectedValue
                iCust_ID = cboCustomer.SelectedValue

                'Account number (Project)
                dtAcct = _objVinsmart_SP.GetVinsmartAccounts(iCust_ID, iLoc_ID)
                Misc.PopulateC1DropDownList(Me.cboAccount, dtAcct, "Account", "Account")
                strAccount = Me.cboAccount.SelectedValue

                'Model info
                dtModel = Me._objVinsmart.getVinsmartModels(Me._iMenuCustID, True)
                Misc.PopulateC1DropDownList(Me.cboModel, dtModel, "Model_Desc", "Model_ID")
                Me.cboModel.SelectedValue = 0


            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmVinsmart_SpecialKit_Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub txtDeviceIMEI_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDeviceIMEI.KeyUp
            Try
                If e.KeyCode = Keys.Enter Then
                    If Me.txtDeviceIMEI.Text.Length > 0 AndAlso Me.txtSIMCardICCID.Text.Length = 0 Then
                        If _objVinsmart_SP.ValidateImeiNumber(iCust_ID, iLoc_ID, cboAccount.SelectedValue, txtDeviceIMEI.Text) = False Then
                            MessageBox.Show(String.Concat("IMEI number: ", txtDeviceIMEI.Text, " was not found."), "Invalid IMEI Number", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            txtDeviceIMEI.Text = String.Empty
                            txtDeviceIMEI.Focus()
                        End If
                    End If

                    If Me.txtDeviceIMEI.Text.Trim.Length > 0 AndAlso Me.txtSIMCardICCID.Text.Trim.Length > 0 Then
                        Me.ProcessKit()
                    ElseIf Me.txtDeviceIMEI.Text.Trim.Length > 0 AndAlso Not Me.txtSIMCardICCID.Text.Trim.Length > 0 Then
                        Me.txtSIMCardICCID.SelectAll() : Me.txtSIMCardICCID.Text = "" : Me.txtSIMCardICCID.Focus()
                    Else
                        Me.txtDeviceIMEI.SelectAll() : Me.txtDeviceIMEI.Text = "" : Me.txtDeviceIMEI.Focus()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtDeviceIMEI_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub txtSIMCardICCID_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSIMCardICCID.KeyUp
            Try
                If e.KeyCode = Keys.Enter Then
                    If Me.txtDeviceIMEI.Text.Trim.Length > 0 AndAlso Me.txtSIMCardICCID.Text.Trim.Length > 0 Then
                        Me.ProcessKit()
                    ElseIf Me.txtSIMCardICCID.Text.Trim.Length > 0 AndAlso Not Me.txtDeviceIMEI.Text.Trim.Length > 0 Then
                        Me.txtDeviceIMEI.SelectAll() : Me.txtDeviceIMEI.Text = "" : Me.txtDeviceIMEI.Focus()
                    Else
                        Me.txtSIMCardICCID.SelectAll() : Me.txtSIMCardICCID.Text = "" : Me.txtSIMCardICCID.Focus()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtSIMCardICCID_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub ProcessKit()
            Dim strIMEI As String = ""
            Dim strICCID As String = ""
            Dim iModel_ID As Integer = 0
            Dim strModel As String = ""
            Dim dtDevice As DataTable
            Dim dtSIMCard As DataTable
            Dim strKitted_DateTime As String = ""
            Dim rowNew, row As DataRow
            Dim i As Integer = 0, k As Integer = 0

            Try

                If Not (Me.txtDeviceIMEI.Text.Trim.Length > 0 AndAlso Me.txtSIMCardICCID.Text.Trim.Length > 0) Then Exit Sub

                If Not Me.cboCustomer.SelectedValue > 0 Then MessageBox.Show("Customer is not selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Me.cboCustomer.Focus() : Exit Sub
                If Not Me.cboLocation.SelectedValue > 0 Then MessageBox.Show("Location is not selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Me.cboLocation.Focus() : Exit Sub
                If Not Me.cboModel.SelectedValue > 0 Then MessageBox.Show("Model is not selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Me.cboModel.Focus() : Exit Sub

                strIMEI = Me.txtDeviceIMEI.Text.Trim : strICCID = Me.txtSIMCardICCID.Text.Trim

                If Me.IMEI_AlreadyScanned(strIMEI) Then
                    MessageBox.Show("The device '" & strIMEI & "' already scanned.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtDeviceIMEI.SelectAll() : Me.txtDeviceIMEI.Focus()
                    Exit Sub
                End If

                If Me.ICCID_AlreadyScanned(strICCID) Then
                    MessageBox.Show("The SIM card '" & strICCID & "' already scanned.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Me.cboModel.Focus()
                    Me.txtSIMCardICCID.SelectAll() : Me.txtSIMCardICCID.Focus()
                    Exit Sub
                End If

                iModel_ID = Me.cboModel.SelectedValue
                strModel = Convert.ToString(Me.cboModel.DataSource.Table.Select("Model_ID = " & Me.cboModel.SelectedValue)(0)("Model_Desc"))

                'Cust_ID, Loc_ID, EW_ID, Device_ID, Model_ID, wb_id, BoxID, WI_ID, IMEI, Model_Desc, Item_Sku, Account
                dtDevice = Me._objVinsmart_SPKit.GetDeviceData(Me.cboCustomer.SelectedValue, Me.cboLocation.SelectedValue, strAccount, strIMEI)

                'WI_ID, WO_ID, WR_ID, WO_CustWO, WO_Date, WO_Quantity, Device_ID, ICCID, Kitted
                dtSIMCard = Me._objVinsmart_SPKit.GetSIMCardData(Me.cboCustomer.SelectedValue, Me.cboLocation.SelectedValue, strICCID)

                If Not dtDevice.Rows.Count > 0 Then
                    MessageBox.Show("Can't find the device '" & strIMEI & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtDeviceIMEI.SelectAll() : Me.txtDeviceIMEI.Focus()
                ElseIf dtDevice.Rows.Count > 1 Then
                    MessageBox.Show("Duplicate device '" & strIMEI & "'. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtDeviceIMEI.SelectAll() : Me.txtDeviceIMEI.Focus()
                ElseIf dtDevice.Rows(0).Item("WI_ID") > 0 Then
                    MessageBox.Show("The device '" & strIMEI & "' is already kitted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtDeviceIMEI.SelectAll() : Me.txtDeviceIMEI.Focus()
                ElseIf Not iModel_ID = dtDevice.Rows(0).Item("Model_ID") Then
                    MessageBox.Show("Not the same device model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtDeviceIMEI.SelectAll() : Me.txtDeviceIMEI.Focus()
                ElseIf Not dtSIMCard.Rows.Count > 0 Then
                    MessageBox.Show("Can't find the SIM card '" & strICCID & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtSIMCardICCID.SelectAll() : Me.txtSIMCardICCID.Focus()
                ElseIf dtSIMCard.Rows.Count > 1 Then
                    MessageBox.Show("Duplicate SIM card '" & strICCID & "'. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf dtSIMCard.Rows(0).Item("Kitted") > 0 Then
                    MessageBox.Show("This SIM card '" & strICCID & "' is already kitted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtSIMCardICCID.SelectAll() : Me.txtSIMCardICCID.Focus()
                ElseIf Not Me._objVinsmart_SP.IsPretestPassed(dtDevice.Rows(0).Item("Device_ID")) Then
                    MessageBox.Show("The device '" & strIMEI & "' either failed in pretest or has no pretest data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtDeviceIMEI.SelectAll() : Me.txtDeviceIMEI.Focus()
                Else 'Ready to kit
                    If Me._dtKitting.Rows.Count = 0 Then Me._strKittedSession = "Kitted_" & Format(Now, "yyyyMMddHHmmss")
                    strKitted_DateTime = Format(Now, "yyyy-MM-dd HH:mm:ss")
                    'RecNo,Model, IMEI, ICCID, Device_ID, Model_ID, WI_ID, EW_ID
                    rowNew = Me._dtKitting.NewRow
                    rowNew("Model") = dtDevice.Rows(0).Item("Model_Desc")
                    rowNew("IMEI") = strIMEI
                    rowNew("ICCID") = strICCID
                    rowNew("Device_ID") = dtDevice.Rows(0).Item("Device_ID")
                    rowNew("Model_ID") = dtDevice.Rows(0).Item("Model_ID")
                    rowNew("WI_ID") = dtSIMCard.Rows(0).Item("WI_ID")
                    rowNew("EW_ID") = dtDevice.Rows(0).Item("EW_ID")
                    Me._dtKitting.Rows.Add(rowNew)

                    k = 0
                    For Each row In Me._dtKitting.Rows
                        k += 1
                        row.BeginEdit() : row("RecNo") = k : row.AcceptChanges()
                    Next

                    i = Me._objVinsmart_SPKit.UpdateKittedItems(dtDevice.Rows(0).Item("EW_ID"), dtSIMCard.Rows(0).Item("WI_ID"), Me._strKittedSession, strKitted_DateTime, Me._iUserID)

                    If i > 1 Then
                        Me.BindKittedData()
                        Me.lblKittedQty.Text = "Kitted Qty: " & Me._dtKitting.Rows.Count.ToString
                        Me.cboModel.Enabled = False

                        Me.txtSIMCardICCID.SelectAll() : Me.txtSIMCardICCID.Text = ""
                        Me.txtDeviceIMEI.SelectAll() : Me.txtDeviceIMEI.Text = "" : Me.txtDeviceIMEI.Focus()
                    Else
                        MessageBox.Show("Not updated! See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtDeviceIMEI.SelectAll() : Me.txtDeviceIMEI.Focus()
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Function IMEI_AlreadyScanned(ByVal strIMEI As String) As Boolean
            Dim bRet As Boolean = False
            Dim row As DataRow

            Try
                For Each row In Me._dtKitting.Rows
                    If Convert.ToString(row("IMEI")).Trim.ToUpper = strIMEI.Trim.ToString Then
                        bRet = True : Exit For
                    End If
                Next

                Return bRet

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "BindKittedData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Function

        Private Function ICCID_AlreadyScanned(ByVal strICCID As String) As Boolean
            Dim bRet As Boolean = False
            Dim row As DataRow

            Try
                For Each row In Me._dtKitting.Rows
                    If Convert.ToString(row("ICCID")).Trim.ToUpper = strICCID.Trim.ToString Then
                        bRet = True : Exit For
                    End If
                Next

                Return bRet

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "BindKittedData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Function

        Private Sub BindKittedData()
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
            Dim i As Integer = 0
            Dim row As DataRow

            'RecNo,Model, IMEI, ICCID, Device_ID, Model_ID, WI_ID, EW_ID
            Try

                'Bind received data
                With Me.tdgIMEI_ICCID
                    .DataSource = Me._dtKitting.DefaultView

                    For Each dbgc In .Splits(0).DisplayColumns
                        dbgc.Locked = True
                        dbgc.AutoSize()
                    Next dbgc

                    .Splits(0).DisplayColumns("Device_ID").Width = 0
                    .Splits(0).DisplayColumns("Model_ID").Width = 0
                    .Splits(0).DisplayColumns("WI_ID").Width = 0
                    .Splits(0).DisplayColumns("EW_ID").Width = 0
                End With
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "BindKittedData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnDelOne_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelOne.Click
            Dim strIMEI As String = ""
            Dim strICCID As String = ""
            Dim iEW_ID As Integer = 0
            Dim iWI_ID As Integer = 0
            Dim row As DataRow
            Dim i As Integer = 0
            Dim k As Integer = 0

            'RecNo,Model, IMEI, ICCID, Device_ID, Model_ID, WI_ID, EW_ID
            Try

                If Me.rbtByIMEI.Checked Then
                    strIMEI = InputBox("Enter Device IMEI:", "IMEI").Trim()
                    If strIMEI.Length = 0 Then Throw New Exception("Please enter a device IMEI if you want to undo it.")

                    i = 0
                    For Each row In Me._dtKitting.Rows
                        If Convert.ToString(row("IMEI")).Trim.ToUpper = strIMEI.ToUpper Then
                            iEW_ID = Convert.ToInt32(row("EW_ID"))
                            iWI_ID = Convert.ToInt32(row("WI_ID"))
                            Me._dtKitting.Rows.RemoveAt(i)
                            Exit For
                        End If
                        i += 1
                    Next
                    Me._dtKitting.AcceptChanges()
                    Me.ReOrderDatatable(Me._dtKitting)

                    If iEW_ID > 0 AndAlso iWI_ID > 0 Then
                        k = Me._objVinsmart_SPKit.UndoKittedItems(iEW_ID.ToString, iWI_ID.ToString)
                        Me.BindKittedData()
                        Me.lblKittedQty.Text = "Kitted Qty: " & Me._dtKitting.Rows.Count.ToString
                    ElseIf Not (iEW_ID > 0 AndAlso iWI_ID > 0) Then
                        MessageBox.Show("Invalid EW_ID or WI_ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        MessageBox.Show("Not find '" & strIMEI & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                ElseIf Me.rbtByICCID.Checked Then
                    strICCID = InputBox("Enter SIM card ICCID:", "ICCID").Trim()
                    If strICCID.Length = 0 Then Throw New Exception("Please enter a device ICCID if you want to undo it.")

                    i = 0
                    For Each row In Me._dtKitting.Rows
                        If Convert.ToString(row("ICCID")).Trim.ToUpper = strICCID.ToUpper Then
                            iEW_ID = Convert.ToInt32(row("EW_ID"))
                            iWI_ID = Convert.ToInt32(row("WI_ID"))
                            Me._dtKitting.Rows.RemoveAt(i)
                            Exit For
                        End If
                        i += 1
                    Next
                    Me._dtKitting.AcceptChanges()
                    Me.ReOrderDatatable(Me._dtKitting)

                    If iEW_ID > 0 AndAlso iWI_ID > 0 Then
                        k = Me._objVinsmart_SPKit.UndoKittedItems(iEW_ID.ToString, iWI_ID.ToString)
                        Me.BindKittedData()
                        Me.lblKittedQty.Text = "Kitted Qty: " & Me._dtKitting.Rows.Count.ToString
                    ElseIf Not (iEW_ID > 0 AndAlso iWI_ID > 0) Then
                        MessageBox.Show("Invalid EW_ID or WI_ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        MessageBox.Show("Not find '" & strICCID & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                Else
                    Throw New Exception("you must select either By IMEI or By ICCID option.")
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnDelOne_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnDelAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelAll.Click
            Dim strEW_IDs As String = ""
            Dim strWI_IDs As String = ""
            Dim iEW_ID As String = ""
            Dim iWI_ID As String = ""
            Dim row As DataRow
            Dim i As Integer = 0
            Dim k As Integer = 0

            Try
                If Not Me._dtKitting.Rows.Count > 0 Then Exit Sub

                For Each row In Me._dtKitting.Rows
                    iEW_ID = Convert.ToInt32(row("EW_ID"))
                    iWI_ID = Convert.ToInt32(row("WI_ID"))
                    If strEW_IDs.Trim.Length = 0 Then
                        strEW_IDs = iEW_ID.ToString
                        strWI_IDs = iWI_ID.ToString
                    Else
                        strEW_IDs &= "," & iEW_ID.ToString
                        strWI_IDs &= "," & iWI_ID.ToString
                    End If
                Next

                k = Me._objVinsmart_SPKit.UndoKittedItems(strEW_IDs, strWI_IDs)

                Me._dtKitting.Rows.Clear() : Me.lblKittedQty.Text = "Kitted Qty: " & Me._dtKitting.Rows.Count.ToString
                Me.tdgIMEI_ICCID.DataSource = Nothing

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnDelAll_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub ReOrderDatatable(ByRef dt As DataTable)
            Dim i As Integer = 0
            Dim row As DataRow

            Try
                For Each row In dt.Rows
                    i += 1
                    row.BeginEdit() : row("RecNo") = i : row.AcceptChanges()
                Next

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ReordderDT", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Sub

        Private Sub rbtByIMEI_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtByIMEI.CheckedChanged
            Try
                If Me.rbtByIMEI.Checked Then
                    Me.rbtByIMEI.ForeColor = Color.Blue
                Else
                    Me.rbtByIMEI.ForeColor = Color.White
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "rbtByIMEI_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub rbtByICCID_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtByICCID.CheckedChanged
            Try
                If Me.rbtByICCID.Checked Then
                    Me.rbtByICCID.ForeColor = Color.Blue
                Else
                    Me.rbtByICCID.ForeColor = Color.White
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "rbtByICCID_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub cboAccount_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAccount.SelectedValueChanged
            strAccount = cboAccount.SelectedValue
            txtDeviceIMEI.Focus()
        End Sub

        Private Sub btnClearEntry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearEntry.Click
            txtDeviceIMEI.Text = String.Empty
            txtSIMCardICCID.Text = String.Empty
        End Sub


    End Class
End Namespace