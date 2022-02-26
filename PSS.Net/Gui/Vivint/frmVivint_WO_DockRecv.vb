Option Explicit On 

Imports PSS.Data.Buisness
Imports System.Text

Namespace Gui.VV
    Public Class frmVivint_WO_DockRecv
        Inherits System.Windows.Forms.Form

        Private _iCust_ID As Integer = 0
        Private dtModel As DataTable
        'Private _iLoc_ID As Integer = 0
        Private _strScreenName As String = ""
        Private _objVivint As PSS.Data.Buisness.VV.Vivint
        Private _objVivint_WoDockRecv As PSS.Data.Buisness.VV.Vivint_WO_DockRecv
        
        Private _iUserID As Integer = PSS.Core.Global.ApplicationUser.IDuser
        Private _strUser As String = PSS.Core.Global.ApplicationUser.User
        Private dtWo As New DataTable()
        Private wrtyContain As Boolean = False
        Private onlyOnce As Integer = 0

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strScreenName As String, ByVal iCust_ID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._iCust_ID = iCust_ID
            Me._strScreenName = strScreenName
            Me._objVivint = New PSS.Data.Buisness.VV.Vivint()
            Me._objVivint_WoDockRecv = New PSS.Data.Buisness.VV.Vivint_WO_DockRecv()

        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                Try
                    Me._objVivint = Nothing
                    Me._objVivint_WoDockRecv = Nothing
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
        Friend WithEvents lblProductType As System.Windows.Forms.Label
        Friend WithEvents lblLocation As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtPO As System.Windows.Forms.TextBox
        Friend WithEvents cboProType As C1.Win.C1List.C1Combo
        Friend WithEvents cboLocation As C1.Win.C1List.C1Combo
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents txtQty As System.Windows.Forms.TextBox
        Friend WithEvents btnCreateWO As System.Windows.Forms.Button
        Friend WithEvents btnCls As System.Windows.Forms.Button
        Friend WithEvents btnReceive As System.Windows.Forms.Button
        Friend WithEvents dgvWODetail As System.Windows.Forms.DataGrid
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents cmbModel As C1.Win.C1List.C1Combo
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
        Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents btnRec As System.Windows.Forms.Button
        Friend WithEvents txtReceivePO As System.Windows.Forms.TextBox
        Friend WithEvents dbDisplay As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents cmbWarranty As C1.Win.C1List.C1Combo
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents txtBinLoc As System.Windows.Forms.TextBox
        Friend WithEvents Label8 As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmVivint_WO_DockRecv))
            Me.lblProductType = New System.Windows.Forms.Label()
            Me.txtPO = New System.Windows.Forms.TextBox()
            Me.lblLocation = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.cboProType = New C1.Win.C1List.C1Combo()
            Me.cboLocation = New C1.Win.C1List.C1Combo()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.txtQty = New System.Windows.Forms.TextBox()
            Me.btnCreateWO = New System.Windows.Forms.Button()
            Me.btnCls = New System.Windows.Forms.Button()
            Me.btnReceive = New System.Windows.Forms.Button()
            Me.dgvWODetail = New System.Windows.Forms.DataGrid()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.cmbModel = New C1.Win.C1List.C1Combo()
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.TabPage1 = New System.Windows.Forms.TabPage()
            Me.txtBinLoc = New System.Windows.Forms.TextBox()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.cmbWarranty = New C1.Win.C1List.C1Combo()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.TabPage2 = New System.Windows.Forms.TabPage()
            Me.dbDisplay = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnRec = New System.Windows.Forms.Button()
            Me.txtReceivePO = New System.Windows.Forms.TextBox()
            Me.Label6 = New System.Windows.Forms.Label()
            CType(Me.cboProType, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboLocation, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dgvWODetail, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cmbModel, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControl1.SuspendLayout()
            Me.TabPage1.SuspendLayout()
            CType(Me.cmbWarranty, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabPage2.SuspendLayout()
            CType(Me.dbDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblProductType
            '
            Me.lblProductType.BackColor = System.Drawing.Color.Transparent
            Me.lblProductType.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblProductType.ForeColor = System.Drawing.Color.Black
            Me.lblProductType.Location = New System.Drawing.Point(-8, 72)
            Me.lblProductType.Name = "lblProductType"
            Me.lblProductType.Size = New System.Drawing.Size(128, 21)
            Me.lblProductType.TabIndex = 161
            Me.lblProductType.Text = "Product Type:"
            Me.lblProductType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtPO
            '
            Me.txtPO.BackColor = System.Drawing.Color.White
            Me.txtPO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPO.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPO.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtPO.Location = New System.Drawing.Point(128, 152)
            Me.txtPO.Name = "txtPO"
            Me.txtPO.Size = New System.Drawing.Size(240, 22)
            Me.txtPO.TabIndex = 162
            Me.txtPO.Text = ""
            '
            'lblLocation
            '
            Me.lblLocation.BackColor = System.Drawing.Color.Transparent
            Me.lblLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblLocation.ForeColor = System.Drawing.Color.Black
            Me.lblLocation.Location = New System.Drawing.Point(120, 8)
            Me.lblLocation.Name = "lblLocation"
            Me.lblLocation.Size = New System.Drawing.Size(200, 24)
            Me.lblLocation.TabIndex = 166
            Me.lblLocation.Text = "Vivint - Create WO:"
            Me.lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Black
            Me.Label1.Location = New System.Drawing.Point(-8, 112)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(128, 21)
            Me.Label1.TabIndex = 167
            Me.Label1.Text = "Location:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboProType
            '
            Me.cboProType.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboProType.Caption = ""
            Me.cboProType.CaptionHeight = 17
            Me.cboProType.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboProType.ColumnCaptionHeight = 17
            Me.cboProType.ColumnFooterHeight = 17
            Me.cboProType.ContentHeight = 15
            Me.cboProType.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboProType.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboProType.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboProType.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboProType.EditorHeight = 15
            Me.cboProType.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboProType.ItemHeight = 15
            Me.cboProType.Location = New System.Drawing.Point(128, 72)
            Me.cboProType.MatchEntryTimeout = CType(2000, Long)
            Me.cboProType.MaxDropDownItems = CType(5, Short)
            Me.cboProType.MaxLength = 32767
            Me.cboProType.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboProType.Name = "cboProType"
            Me.cboProType.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboProType.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboProType.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboProType.Size = New System.Drawing.Size(240, 21)
            Me.cboProType.TabIndex = 168
            Me.cboProType.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            Me.cboLocation.Location = New System.Drawing.Point(128, 112)
            Me.cboLocation.MatchEntryTimeout = CType(2000, Long)
            Me.cboLocation.MaxDropDownItems = CType(5, Short)
            Me.cboLocation.MaxLength = 32767
            Me.cboLocation.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboLocation.Name = "cboLocation"
            Me.cboLocation.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboLocation.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboLocation.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboLocation.Size = New System.Drawing.Size(240, 21)
            Me.cboLocation.TabIndex = 169
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
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.Black
            Me.Label2.Location = New System.Drawing.Point(-8, 192)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(128, 21)
            Me.Label2.TabIndex = 171
            Me.Label2.Text = "Model:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.Black
            Me.Label3.Location = New System.Drawing.Point(-8, 152)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(128, 21)
            Me.Label3.TabIndex = 170
            Me.Label3.Text = "PO/WO:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.Black
            Me.Label4.Location = New System.Drawing.Point(-8, 272)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(128, 21)
            Me.Label4.TabIndex = 172
            Me.Label4.Text = "Qty:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtQty
            '
            Me.txtQty.BackColor = System.Drawing.Color.White
            Me.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtQty.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtQty.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtQty.Location = New System.Drawing.Point(128, 272)
            Me.txtQty.Name = "txtQty"
            Me.txtQty.Size = New System.Drawing.Size(240, 22)
            Me.txtQty.TabIndex = 174
            Me.txtQty.Text = ""
            '
            'btnCreateWO
            '
            Me.btnCreateWO.BackColor = System.Drawing.Color.ForestGreen
            Me.btnCreateWO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCreateWO.Location = New System.Drawing.Point(288, 384)
            Me.btnCreateWO.Name = "btnCreateWO"
            Me.btnCreateWO.Size = New System.Drawing.Size(168, 56)
            Me.btnCreateWO.TabIndex = 175
            Me.btnCreateWO.Text = "Create Work Order"
            '
            'btnCls
            '
            Me.btnCls.BackColor = System.Drawing.Color.Gold
            Me.btnCls.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCls.Location = New System.Drawing.Point(136, 384)
            Me.btnCls.Name = "btnCls"
            Me.btnCls.Size = New System.Drawing.Size(120, 56)
            Me.btnCls.TabIndex = 176
            Me.btnCls.Text = "Clear"
            '
            'btnReceive
            '
            Me.btnReceive.BackColor = System.Drawing.Color.LightSlateGray
            Me.btnReceive.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReceive.Location = New System.Drawing.Point(392, 264)
            Me.btnReceive.Name = "btnReceive"
            Me.btnReceive.Size = New System.Drawing.Size(104, 40)
            Me.btnReceive.TabIndex = 177
            Me.btnReceive.Text = "Receive"
            '
            'dgvWODetail
            '
            Me.dgvWODetail.DataMember = ""
            Me.dgvWODetail.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.dgvWODetail.Location = New System.Drawing.Point(512, 72)
            Me.dgvWODetail.Name = "dgvWODetail"
            Me.dgvWODetail.Size = New System.Drawing.Size(288, 112)
            Me.dgvWODetail.TabIndex = 178
            '
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.Transparent
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.Black
            Me.Label5.Location = New System.Drawing.Point(528, 48)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(200, 24)
            Me.Label5.TabIndex = 179
            Me.Label5.Text = "WO Order Detail"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbModel
            '
            Me.cmbModel.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cmbModel.Caption = ""
            Me.cmbModel.CaptionHeight = 17
            Me.cmbModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cmbModel.ColumnCaptionHeight = 17
            Me.cmbModel.ColumnFooterHeight = 17
            Me.cmbModel.ContentHeight = 15
            Me.cmbModel.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cmbModel.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cmbModel.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmbModel.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cmbModel.EditorHeight = 15
            Me.cmbModel.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cmbModel.ItemHeight = 15
            Me.cmbModel.Location = New System.Drawing.Point(128, 192)
            Me.cmbModel.MatchEntryTimeout = CType(2000, Long)
            Me.cmbModel.MaxDropDownItems = CType(5, Short)
            Me.cmbModel.MaxLength = 32767
            Me.cmbModel.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cmbModel.Name = "cmbModel"
            Me.cmbModel.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cmbModel.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cmbModel.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cmbModel.Size = New System.Drawing.Size(240, 21)
            Me.cmbModel.TabIndex = 180
            Me.cmbModel.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'TabControl1
            '
            Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabPage1, Me.TabPage2})
            Me.TabControl1.Location = New System.Drawing.Point(8, 8)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(864, 512)
            Me.TabControl1.TabIndex = 181
            '
            'TabPage1
            '
            Me.TabPage1.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtBinLoc, Me.Label8, Me.cmbWarranty, Me.Label7, Me.lblLocation, Me.txtQty, Me.cmbModel, Me.txtPO, Me.btnCreateWO, Me.Label1, Me.btnCls, Me.lblProductType, Me.Label2, Me.cboProType, Me.Label3, Me.cboLocation, Me.Label4, Me.btnReceive, Me.dgvWODetail, Me.Label5})
            Me.TabPage1.Location = New System.Drawing.Point(4, 22)
            Me.TabPage1.Name = "TabPage1"
            Me.TabPage1.Size = New System.Drawing.Size(856, 486)
            Me.TabPage1.TabIndex = 0
            Me.TabPage1.Text = "Create WO"
            '
            'txtBinLoc
            '
            Me.txtBinLoc.BackColor = System.Drawing.Color.White
            Me.txtBinLoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtBinLoc.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtBinLoc.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtBinLoc.Location = New System.Drawing.Point(128, 312)
            Me.txtBinLoc.Name = "txtBinLoc"
            Me.txtBinLoc.Size = New System.Drawing.Size(240, 22)
            Me.txtBinLoc.TabIndex = 186
            Me.txtBinLoc.Text = ""
            '
            'Label8
            '
            Me.Label8.BackColor = System.Drawing.Color.Transparent
            Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.Black
            Me.Label8.Location = New System.Drawing.Point(0, 312)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(128, 21)
            Me.Label8.TabIndex = 185
            Me.Label8.Text = "Bin Location:"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbWarranty
            '
            Me.cmbWarranty.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cmbWarranty.Caption = ""
            Me.cmbWarranty.CaptionHeight = 17
            Me.cmbWarranty.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cmbWarranty.ColumnCaptionHeight = 17
            Me.cmbWarranty.ColumnFooterHeight = 17
            Me.cmbWarranty.ContentHeight = 15
            Me.cmbWarranty.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cmbWarranty.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cmbWarranty.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmbWarranty.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cmbWarranty.EditorHeight = 15
            Me.cmbWarranty.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.cmbWarranty.ItemHeight = 15
            Me.cmbWarranty.Location = New System.Drawing.Point(128, 232)
            Me.cmbWarranty.MatchEntryTimeout = CType(2000, Long)
            Me.cmbWarranty.MaxDropDownItems = CType(5, Short)
            Me.cmbWarranty.MaxLength = 32767
            Me.cmbWarranty.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cmbWarranty.Name = "cmbWarranty"
            Me.cmbWarranty.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cmbWarranty.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cmbWarranty.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cmbWarranty.Size = New System.Drawing.Size(240, 21)
            Me.cmbWarranty.TabIndex = 184
            Me.cmbWarranty.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label7
            '
            Me.Label7.BackColor = System.Drawing.Color.Transparent
            Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.Black
            Me.Label7.Location = New System.Drawing.Point(0, 232)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(128, 21)
            Me.Label7.TabIndex = 181
            Me.Label7.Text = "Warranty:"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'TabPage2
            '
            Me.TabPage2.BackColor = System.Drawing.Color.RoyalBlue
            Me.TabPage2.Controls.AddRange(New System.Windows.Forms.Control() {Me.dbDisplay, Me.btnRec, Me.txtReceivePO, Me.Label6})
            Me.TabPage2.Location = New System.Drawing.Point(4, 22)
            Me.TabPage2.Name = "TabPage2"
            Me.TabPage2.Size = New System.Drawing.Size(856, 486)
            Me.TabPage2.TabIndex = 1
            Me.TabPage2.Text = "Dock Receive"
            '
            'dbDisplay
            '
            Me.dbDisplay.AllowColMove = False
            Me.dbDisplay.AllowColSelect = False
            Me.dbDisplay.AllowFilter = False
            Me.dbDisplay.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
            Me.dbDisplay.AllowSort = False
            Me.dbDisplay.AllowUpdateOnBlur = False
            Me.dbDisplay.CaptionHeight = 19
            Me.dbDisplay.CollapseColor = System.Drawing.Color.Transparent
            Me.dbDisplay.ExpandColor = System.Drawing.Color.Transparent
            Me.dbDisplay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dbDisplay.ForeColor = System.Drawing.Color.Transparent
            Me.dbDisplay.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbDisplay.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.dbDisplay.Location = New System.Drawing.Point(120, 112)
            Me.dbDisplay.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.dbDisplay.Name = "dbDisplay"
            Me.dbDisplay.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbDisplay.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbDisplay.PreviewInfo.ZoomFactor = 75
            Me.dbDisplay.RowHeight = 20
            Me.dbDisplay.Size = New System.Drawing.Size(448, 304)
            Me.dbDisplay.TabIndex = 181
            Me.dbDisplay.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:SteelBlue;}Sele" & _
            "cted{ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Whi" & _
            "te;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Center;ForeCo" & _
            "lor:White;}Style9{}Normal{Font:Microsoft Sans Serif, 8.25pt, style=Bold;BackColo" & _
            "r:LightSteelBlue;ForeColor:White;AlignVert:Center;}HighlightRow{ForeColor:Highli" & _
            "ghtText;BackColor:Highlight;}Style12{}OddRow{BackColor:Teal;}RecordSelector{Alig" & _
            "nImage:Center;ForeColor:White;}Style13{}Heading{Wrap:True;Font:Microsoft Sans Se" & _
            "rif, 8.25pt, style=Bold;AlignHorz:Center;AlignVert:Center;Border:Raised,,1, 1, 1" & _
            ", 1;ForeColor:Blue;BackColor:Control;}Style8{}Style10{AlignHorz:Near;}Style11{}S" & _
            "tyle14{}Style15{}Style16{}Style17{}Style1{}</Data></Styles><Splits><C1.Win.C1Tru" & _
            "eDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""False"" Name="""" AllowRowSi" & _
            "zing=""None"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" " & _
            "MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Ver" & _
            "ticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>300</Height><CaptionStyle" & _
            " parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><Even" & _
            "RowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""S" & _
            "tyle13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" " & _
            "me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle p" & _
            "arent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" " & _
            "/><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""Record" & _
            "Selector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style p" & _
            "arent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 444, 300</ClientRect><BorderSide>" & _
            "0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView><" & _
            "/Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""H" & _
            "eading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Capt" & _
            "ion"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Select" & _
            "ed"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightR" & _
            "ow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /" & _
            "><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""Filter" & _
            "Bar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSpl" & _
            "its><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</Defau" & _
            "ltRecSelWidth><ClientArea>0, 0, 444, 300</ClientArea><PrintPageHeaderStyle paren" & _
            "t="""" me=""Style16"" /><PrintPageFooterStyle parent="""" me=""Style17"" /></Blob>"
            '
            'btnRec
            '
            Me.btnRec.BackColor = System.Drawing.Color.LightSlateGray
            Me.btnRec.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRec.Location = New System.Drawing.Point(296, 440)
            Me.btnRec.Name = "btnRec"
            Me.btnRec.Size = New System.Drawing.Size(104, 40)
            Me.btnRec.TabIndex = 180
            Me.btnRec.Text = "Receive"
            '
            'txtReceivePO
            '
            Me.txtReceivePO.BackColor = System.Drawing.Color.White
            Me.txtReceivePO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtReceivePO.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtReceivePO.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtReceivePO.Location = New System.Drawing.Point(208, 72)
            Me.txtReceivePO.Name = "txtReceivePO"
            Me.txtReceivePO.Size = New System.Drawing.Size(240, 22)
            Me.txtReceivePO.TabIndex = 171
            Me.txtReceivePO.Text = ""
            '
            'Label6
            '
            Me.Label6.BackColor = System.Drawing.Color.Transparent
            Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.Black
            Me.Label6.Location = New System.Drawing.Point(72, 72)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(128, 21)
            Me.Label6.TabIndex = 172
            Me.Label6.Text = "PO/WO:"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'frmVivint_WO_DockRecv
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SlateBlue
            Me.ClientSize = New System.Drawing.Size(880, 534)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1})
            Me.Name = "frmVivint_WO_DockRecv"
            Me.Text = "frmVivint_WO_DockRecv"
            CType(Me.cboProType, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboLocation, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dgvWODetail, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cmbModel, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControl1.ResumeLayout(False)
            Me.TabPage1.ResumeLayout(False)
            CType(Me.cmbWarranty, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabPage2.ResumeLayout(False)
            CType(Me.dbDisplay, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmVivint_WO_DockRecv_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load


            Dim strCustLoc As String = ""
            Dim dtLoc, dtProd, dtWarranty, dtLoc_Seed As DataTable
            Dim iLoc_ID As Integer = 0

            Dim dtDOA As DataTable

            dtWo.Columns.Add("Model", GetType(String))
            dtWo.Columns.Add("Qty", GetType(Integer))
            dtWo.Columns.Add("WO", GetType(String))
            dtWo.Columns.Add("Product Type", GetType(String))
            dtWo.Columns.Add("Location", GetType(String))
            dtWo.Columns.Add("Warranty", GetType(String))
            dtWo.Columns.Add("binloc", GetType(String))


            dtProd = Me._objVivint_WoDockRecv.GetVivintProduct(True)
            Misc.PopulateC1DropDownList(Me.cboProType, dtProd, "prod_desc", "prod_id")
            cboProType.SelectedIndex = 0

            ' this is becoming empty.i'm trying to select the first index by default

            dtModel = Me._objVivint_WoDockRecv.GetVivintModel(True)
            Misc.PopulateC1DropDownList(Me.cmbModel, dtModel, "model_desc", "model_id")
            cmbModel.SelectedIndex = 0

            dtLoc = Me._objVivint_WoDockRecv.GetVivintLocations(_objVivint.Vivint_CUSTOMER_ID, True)
            Misc.PopulateC1DropDownList(Me.cboLocation, dtLoc, "Loc_Name", "Loc_ID")
            cboLocation.SelectedIndex = 0

            Dim _objWarranty As New PSS.Data.Buisness.VV.Vivint()
            dtWarranty = _objWarranty.getWarrantyTypeData()
            Misc.PopulateC1DropDownList(Me.cmbWarranty, dtWarranty, "Wrty_Desc", "Wrty_ID")
            cmbWarranty.SelectedIndex = 0

        End Sub

        Private Sub btnReceive_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReceive.Click




            If txtQty.Text <> String.Empty And txtPO.Text <> String.Empty And cmbModel.Text <> String.Empty And cboLocation.Text <> String.Empty And cboProType.Text <> String.Empty Then
                Dim R As DataRow = dtWo.NewRow
                R("Model") = cmbModel.Text
                R("Qty") = txtQty.Text
                R("WO") = txtPO.Text
                R("Product Type") = cboProType.Text
                R("Location") = cboLocation.Text
                If cmbWarranty.Text = "OUT OF WARRANTY" Then
                    R("warranty") = 0
                ElseIf cmbWarranty.Text = "IN WARRANTY" Then
                    R("warranty") = 1
                ElseIf cmbWarranty.Text = "NO WARRANTY" Then
                    R("warranty") = 2
                End If

                R("binloc") = txtBinLoc.Text

                If dtWo.Rows.Count = 0 Then
                    dtWo.Rows.Add(R)
                    dgvWODetail.DataSource = dtWo
                Else
                  
                    If cmbWarranty.Visible = True And wrtyContain = True Then
                        MessageBox.Show("You can't mix those items", "Warranty Issues", MessageBoxButtons.OK)
                        Exit Sub
                    ElseIf cmbWarranty.Visible = False And wrtyContain = False Then
                        MessageBox.Show("You can't mix those items", "Warranty Issues", MessageBoxButtons.OK)
                        Exit Sub
                    Else

                        dtWo.Rows.Add(R)
                        dgvWODetail.DataSource = dtWo
                    End If

                End If
              
                clearFields()


            Else
                MessageBox.Show("Please fill all fields before procedding", "Empty Fields", MessageBoxButtons.OK)
                Exit Sub

            End If


        End Sub

        Private Sub clearFields()

            cmbModel.SelectedIndex = -1
            txtQty.Text = String.Empty
            cmbWarranty.SelectedIndex = -1
            txtBinLoc.Text = String.Empty


        End Sub

        Private Sub clearAllFields()

            cmbModel.SelectedIndex = -1
            txtQty.Text = String.Empty
            txtPO.Text = String.Empty
            cboProType.SelectedIndex = -1
            cboLocation.SelectedIndex = -1
            cmbWarranty.SelectedIndex = -1
            txtBinLoc.Text = String.Empty

        End Sub

        Private Sub btnCreateWO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCreateWO.Click
            Try

                Dim myNum As Integer = 1
                Dim rw As DataRow

                If (dtWo.Rows.Count = 0) Then
                    MessageBox.Show("Nothing To Do", "Empty work order", MessageBoxButtons.OK)
                    Exit Sub
                End If
                Dim warType As String = String.Empty
                Dim todDate As String = String.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now)
                Dim todDate1 As String = String.Format("{0:yyyyMMdd}", DateTime.Now)
                Dim totQua As Integer = Convert.ToInt32(dtWo.Compute("SUM(Qty)", String.Empty))


                Dim gpId As Integer = Me._objVivint.Vivint_Group_ID


                Dim woId As Integer = Me._objVivint_WoDockRecv.saveVivintWO(True, txtPO.Text, todDate, totQua, 0, cboLocation.SelectedValue, cboProType.SelectedValue, todDate1, 0, gpId)

                'Dim dtId As DataTable = Me._objVivint_WoDockRecv.GetLastInsertedId("production.tworkorder")

                For Each rw In dtWo.Rows

                    If rw.Item(5) = "0" Then
                        warType = "OW"
                    ElseIf rw.Item(5) = "1" Then
                        warType = "IW"
                    ElseIf rw.Item(5) = "2" Then
                        warType = "NW"
                    End If
                    Dim myNumString As String = myNum.ToString("0000")
                    Dim modId As DataRow() = dtModel.Select("model_desc='" & rw.Item(0) & "'")
                    Dim boxId As String = "VV" & todDate1 & "" & warType & "" & myNumString

                    Dim check As Integer = Me._objVivint_WoDockRecv.saveVivintBoxId(True, rw.Item(5), boxId, CStr(modId(0).Item(0)), woId, CInt(rw.Item(1)), rw.Item(6))
                    myNum += 1

                Next
                dbDisplay.DataSource = Nothing
                dtWo.Rows.Clear()
                wrtyContain = False
                onlyOnce = 0
            Catch ex As Exception
                Throw ex
            End Try




        End Sub

        Private Sub btnCls_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCls.Click
            clearAllFields()
        End Sub







        Private Sub btnRec_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRec.Click

            Dim i, j, check As Integer
            Dim woId As String = String.Empty
            Dim closedOrders As Integer = 0


            Dim dt As New DataTable()

            dt.Columns.Add("boxId", GetType(String))
            dt.Columns.Add("ModelId", GetType(String))
            dt.Columns.Add("Qty", GetType(Integer))

            If txtReceivePO.Text = String.Empty Or dbDisplay.RowCount = 0 Then
                Exit Sub
            End If


            For i = 0 To dbDisplay.RowCount - 1
                'For j = 0 To dbDisplay.Columns.Count - 1
                MessageBox.Show(dbDisplay.Item(i, 3))

                If dbDisplay.Item(i, 3) = False Or CStr(dbDisplay.Item(i, 2)).Trim = String.Empty Then


                ElseIf CInt(dbDisplay.Item(i, 1)) < CInt(dbDisplay.Item(i, 2)) Then
                    MessageBox.Show("Quantity Recieved can't be more than total Quantity", "Quantity", MessageBoxButtons.OK)

                ElseIf dbDisplay.Item(i, 3) = True And CStr(dbDisplay.Item(i, 2)).Trim <> String.Empty And CInt(dbDisplay.Item(i, 1)) >= CInt(dbDisplay.Item(i, 2)) And CInt(dbDisplay.Item(i, 2)) > 0 Then
                    check = Me._objVivint_WoDockRecv.updateWoDetails(dbDisplay.Item(i, 5), dbDisplay.Item(i, 4), dbDisplay.Item(i, 2))
                    closedOrders += 1
                    woId = dbDisplay.Item(i, 5)
                    Dim row As String() = New String() {txtPO.Text, dbDisplay.Item(i, 0), dbDisplay.Item(i, 2)}
                    dt.Rows.Add(row)

                End If

                'Next
            Next

            If closedOrders > 0 Then

                check = Me._objVivint_WoDockRecv.updateTWorkOrder(woId)

                'Print the pallett

                PSS.Data.Production.Shipping.PrintVivintBoxLabel(dt)

            End If


           


        End Sub

        Private Sub txtReceivePO_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtReceivePO.Enter


        End Sub

        Private Sub txtReceivePO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtReceivePO.KeyPress
            If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then


                Dim rw As DataRow
                Dim modDt As New DataTable()

                modDt.Columns.Add("Model", GetType(String))
                modDt.Columns.Add("Tot Qty", GetType(Integer))
                modDt.Columns.Add("Rec Qty", GetType(Integer))
                modDt.Columns.Add("Received", GetType(Boolean))
                modDt.Columns.Add("ModelId", GetType(String))
                modDt.Columns.Add("woId", GetType(String))


                If txtReceivePO.Text = String.Empty Then

                Else
                    Dim dt As DataTable = Me._objVivint_WoDockRecv.getPoDetails(txtReceivePO.Text)
                    For Each rw In dt.Rows
                        Dim row As String() = New String() {rw.Item(0), rw.Item(1), rw.Item(2), False, rw.Item(3), rw.Item(4)}
                        modDt.Rows.Add(row)
                    Next
                    dbDisplay.DataSource = modDt
                    'dbDisplay.Columns(4).

                End If

            End If
        End Sub

        Private Sub cmbModel_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbModel.SelectedValueChanged

            Dim dtWarranty As DataTable = Me._objVivint_WoDockRecv.GetVivintNoWarranty
            Dim rw As DataRow
            Dim modWar, modId As String

            If dtWarranty.Rows.Count > 0 Then

                For Each rw In dtWarranty.Rows

                    modWar = rw.Item(0)

                Next

                Dim words() = modWar.Split(","c)
                For Each modId In words
                    If modId = cmbModel.SelectedValue Then
                        'cmbWarranty.Enabled = False
                        cmbWarranty.Visible = False
                        Label7.Visible = False
                        cmbWarranty.Text = "NO WARRANTY"
                    Else
                        ' cmbWarranty.Enabled = True
                        cmbWarranty.Visible = True
                        Label7.Visible = True
                    End If
                Next

            End If

            If cmbWarranty.Visible = False And onlyOnce = 1 Then
                wrtyContain = True
                onlyOnce += 1
            ElseIf cmbWarranty.Visible = True And onlyOnce = 1 Then
                wrtyContain = False
                onlyOnce += 1
            End If
            onlyOnce += 1

        End Sub
    End Class
End Namespace