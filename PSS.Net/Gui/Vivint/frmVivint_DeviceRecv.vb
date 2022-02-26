
Option Explicit On 

Imports PSS.Data.Buisness
Imports System.Text

Namespace Gui.VV
    Public Class frmVivint_DeviceRecv
        Inherits System.Windows.Forms.Form

        Private _iCust_ID As Integer = 0
        'Private _iLoc_ID As Integer = 0
        Private _strScreenName As String = ""
        Private _strRptName As String = ""
        Private _dtReceivedDevices As DataTable
        Private _iWb_ID As Integer = 0
        Private _iWO_ID As Integer = 0
        Private _strWO As String = ""
        Private _iWrty As Integer = 0
        Private _strModel As String = ""
        Private _objVivint As PSS.Data.Buisness.VV.Vivint
        Private _objVivint_DeviceRecv As PSS.Data.Buisness.VV.Vivint_DeviceRecv

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
            Me._objVivint_DeviceRecv = New PSS.Data.Buisness.VV.Vivint_DeviceRecv()
            Me._dtReceivedDevices = Me._objVivint_DeviceRecv.getReceivedDevicesDef
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                Try
                    Me._objVivint = Nothing
                    Me._objVivint_DeviceRecv = Nothing
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
        Friend WithEvents lblCustomer As System.Windows.Forms.Label
        Friend WithEvents cboCustomer As C1.Win.C1List.C1Combo
        Friend WithEvents lblLocation As System.Windows.Forms.Label
        Friend WithEvents cboLocation As C1.Win.C1List.C1Combo
        Friend WithEvents lblDockWO As System.Windows.Forms.Label
        Friend WithEvents cboDockWO As C1.Win.C1List.C1Combo
        Friend WithEvents txtSN As System.Windows.Forms.TextBox
        Friend WithEvents lblBoxName As System.Windows.Forms.Label
        Friend WithEvents lbllblBoxName As System.Windows.Forms.Label
        Friend WithEvents lblModel As System.Windows.Forms.Label
        Friend WithEvents lbllblOrderQty As System.Windows.Forms.Label
        Friend WithEvents lblOrderQty As System.Windows.Forms.Label
        Friend WithEvents lbllblRecvQty As System.Windows.Forms.Label
        Friend WithEvents lblRecvQty As System.Windows.Forms.Label
        Friend WithEvents lbllblWHLocation As System.Windows.Forms.Label
        Friend WithEvents lblWHLocation As System.Windows.Forms.Label
        Friend WithEvents pnlBoxInfo As System.Windows.Forms.Panel
        Friend WithEvents lbllblWarranty As System.Windows.Forms.Label
        Friend WithEvents lblWarranty As System.Windows.Forms.Label
        Friend WithEvents txtResetWHLocation As System.Windows.Forms.TextBox
        Friend WithEvents lblDeviceQty As System.Windows.Forms.Label
        Friend WithEvents lbllblDeviceQty As System.Windows.Forms.Label
        Friend WithEvents lblSN As System.Windows.Forms.Label
        Friend WithEvents grpBoxInfo As System.Windows.Forms.GroupBox
        Friend WithEvents grpReceiving As System.Windows.Forms.GroupBox
        Friend WithEvents btnCloseBox As System.Windows.Forms.Button
        Friend WithEvents btnRemoveAllSNs As System.Windows.Forms.Button
        Friend WithEvents btnRemoveSN As System.Windows.Forms.Button
        Friend WithEvents cboModel As C1.Win.C1List.C1Combo
        Friend WithEvents btnLoadWoBoxData As System.Windows.Forms.Button
        Friend WithEvents lbllblDiscrpQty As System.Windows.Forms.Label
        Friend WithEvents lblDiscrpQty As System.Windows.Forms.Label
        Friend WithEvents lblResetWHLocation As System.Windows.Forms.Label
        Friend WithEvents tdgDevices As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents Receiving As System.Windows.Forms.TabPage
        Friend WithEvents Pattern As System.Windows.Forms.TabPage
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents btnUpdate As System.Windows.Forms.Button
        Friend WithEvents btnAdd As System.Windows.Forms.Button
        Friend WithEvents dgPatternSN As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents cboCustomerPatt As C1.Win.C1List.C1Combo
        Friend WithEvents cboModelPatt As C1.Win.C1List.C1Combo
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents txtSNPattern As System.Windows.Forms.TextBox
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmVivint_DeviceRecv))
            Me.lblCustomer = New System.Windows.Forms.Label()
            Me.cboCustomer = New C1.Win.C1List.C1Combo()
            Me.lblLocation = New System.Windows.Forms.Label()
            Me.cboLocation = New C1.Win.C1List.C1Combo()
            Me.lblDockWO = New System.Windows.Forms.Label()
            Me.cboDockWO = New C1.Win.C1List.C1Combo()
            Me.txtSN = New System.Windows.Forms.TextBox()
            Me.txtResetWHLocation = New System.Windows.Forms.TextBox()
            Me.lblBoxName = New System.Windows.Forms.Label()
            Me.lbllblBoxName = New System.Windows.Forms.Label()
            Me.lblModel = New System.Windows.Forms.Label()
            Me.cboModel = New C1.Win.C1List.C1Combo()
            Me.lbllblOrderQty = New System.Windows.Forms.Label()
            Me.lblOrderQty = New System.Windows.Forms.Label()
            Me.lbllblRecvQty = New System.Windows.Forms.Label()
            Me.lblRecvQty = New System.Windows.Forms.Label()
            Me.lbllblDiscrpQty = New System.Windows.Forms.Label()
            Me.lblDiscrpQty = New System.Windows.Forms.Label()
            Me.lbllblWHLocation = New System.Windows.Forms.Label()
            Me.lblWHLocation = New System.Windows.Forms.Label()
            Me.pnlBoxInfo = New System.Windows.Forms.Panel()
            Me.lbllblWarranty = New System.Windows.Forms.Label()
            Me.lblWarranty = New System.Windows.Forms.Label()
            Me.lblDeviceQty = New System.Windows.Forms.Label()
            Me.lbllblDeviceQty = New System.Windows.Forms.Label()
            Me.lblSN = New System.Windows.Forms.Label()
            Me.lblResetWHLocation = New System.Windows.Forms.Label()
            Me.grpBoxInfo = New System.Windows.Forms.GroupBox()
            Me.btnLoadWoBoxData = New System.Windows.Forms.Button()
            Me.grpReceiving = New System.Windows.Forms.GroupBox()
            Me.btnCloseBox = New System.Windows.Forms.Button()
            Me.btnRemoveAllSNs = New System.Windows.Forms.Button()
            Me.btnRemoveSN = New System.Windows.Forms.Button()
            Me.tdgDevices = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.Receiving = New System.Windows.Forms.TabPage()
            Me.Pattern = New System.Windows.Forms.TabPage()
            Me.dgPatternSN = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnAdd = New System.Windows.Forms.Button()
            Me.btnUpdate = New System.Windows.Forms.Button()
            Me.txtSNPattern = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.cboCustomerPatt = New C1.Win.C1List.C1Combo()
            Me.cboModelPatt = New C1.Win.C1List.C1Combo()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.TextBox1 = New System.Windows.Forms.TextBox()
            Me.Label5 = New System.Windows.Forms.Label()
            CType(Me.cboCustomer, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboLocation, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboDockWO, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboModel, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlBoxInfo.SuspendLayout()
            Me.grpBoxInfo.SuspendLayout()
            Me.grpReceiving.SuspendLayout()
            CType(Me.tdgDevices, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControl1.SuspendLayout()
            Me.Receiving.SuspendLayout()
            Me.Pattern.SuspendLayout()
            CType(Me.dgPatternSN, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboCustomerPatt, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboModelPatt, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox1.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblCustomer
            '
            Me.lblCustomer.BackColor = System.Drawing.Color.Transparent
            Me.lblCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCustomer.ForeColor = System.Drawing.Color.Black
            Me.lblCustomer.Location = New System.Drawing.Point(16, 24)
            Me.lblCustomer.Name = "lblCustomer"
            Me.lblCustomer.Size = New System.Drawing.Size(72, 21)
            Me.lblCustomer.TabIndex = 174
            Me.lblCustomer.Text = "Customer:"
            Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            Me.cboCustomer.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboCustomer.ItemHeight = 15
            Me.cboCustomer.Location = New System.Drawing.Point(96, 24)
            Me.cboCustomer.MatchEntryTimeout = CType(2000, Long)
            Me.cboCustomer.MaxDropDownItems = CType(5, Short)
            Me.cboCustomer.MaxLength = 32767
            Me.cboCustomer.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCustomer.Name = "cboCustomer"
            Me.cboCustomer.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCustomer.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCustomer.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCustomer.Size = New System.Drawing.Size(240, 21)
            Me.cboCustomer.TabIndex = 173
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
            Me.lblLocation.ForeColor = System.Drawing.Color.Black
            Me.lblLocation.Location = New System.Drawing.Point(16, 56)
            Me.lblLocation.Name = "lblLocation"
            Me.lblLocation.Size = New System.Drawing.Size(72, 21)
            Me.lblLocation.TabIndex = 172
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
            Me.cboLocation.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboLocation.ItemHeight = 15
            Me.cboLocation.Location = New System.Drawing.Point(96, 56)
            Me.cboLocation.MatchEntryTimeout = CType(2000, Long)
            Me.cboLocation.MaxDropDownItems = CType(5, Short)
            Me.cboLocation.MaxLength = 32767
            Me.cboLocation.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboLocation.Name = "cboLocation"
            Me.cboLocation.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboLocation.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboLocation.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboLocation.Size = New System.Drawing.Size(240, 21)
            Me.cboLocation.TabIndex = 171
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
            'lblDockWO
            '
            Me.lblDockWO.BackColor = System.Drawing.Color.Transparent
            Me.lblDockWO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDockWO.ForeColor = System.Drawing.Color.Black
            Me.lblDockWO.Location = New System.Drawing.Point(16, 88)
            Me.lblDockWO.Name = "lblDockWO"
            Me.lblDockWO.Size = New System.Drawing.Size(72, 21)
            Me.lblDockWO.TabIndex = 176
            Me.lblDockWO.Text = "Dock WO:"
            Me.lblDockWO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboDockWO
            '
            Me.cboDockWO.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboDockWO.Caption = ""
            Me.cboDockWO.CaptionHeight = 17
            Me.cboDockWO.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboDockWO.ColumnCaptionHeight = 17
            Me.cboDockWO.ColumnFooterHeight = 17
            Me.cboDockWO.ContentHeight = 15
            Me.cboDockWO.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboDockWO.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboDockWO.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboDockWO.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboDockWO.EditorHeight = 15
            Me.cboDockWO.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboDockWO.ItemHeight = 15
            Me.cboDockWO.Location = New System.Drawing.Point(96, 88)
            Me.cboDockWO.MatchEntryTimeout = CType(2000, Long)
            Me.cboDockWO.MaxDropDownItems = CType(5, Short)
            Me.cboDockWO.MaxLength = 32767
            Me.cboDockWO.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboDockWO.Name = "cboDockWO"
            Me.cboDockWO.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboDockWO.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboDockWO.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboDockWO.Size = New System.Drawing.Size(240, 21)
            Me.cboDockWO.TabIndex = 175
            Me.cboDockWO.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            Me.txtSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtSN.Location = New System.Drawing.Point(48, 80)
            Me.txtSN.Name = "txtSN"
            Me.txtSN.Size = New System.Drawing.Size(272, 22)
            Me.txtSN.TabIndex = 177
            Me.txtSN.Text = ""
            '
            'txtResetWHLocation
            '
            Me.txtResetWHLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtResetWHLocation.Location = New System.Drawing.Point(200, 48)
            Me.txtResetWHLocation.Name = "txtResetWHLocation"
            Me.txtResetWHLocation.Size = New System.Drawing.Size(120, 22)
            Me.txtResetWHLocation.TabIndex = 179
            Me.txtResetWHLocation.Text = ""
            '
            'lblBoxName
            '
            Me.lblBoxName.BackColor = System.Drawing.Color.Transparent
            Me.lblBoxName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBoxName.ForeColor = System.Drawing.Color.Black
            Me.lblBoxName.Location = New System.Drawing.Point(88, 136)
            Me.lblBoxName.Name = "lblBoxName"
            Me.lblBoxName.Size = New System.Drawing.Size(232, 21)
            Me.lblBoxName.TabIndex = 182
            Me.lblBoxName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lbllblBoxName
            '
            Me.lbllblBoxName.BackColor = System.Drawing.Color.Transparent
            Me.lbllblBoxName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbllblBoxName.ForeColor = System.Drawing.Color.Black
            Me.lbllblBoxName.Location = New System.Drawing.Point(8, 136)
            Me.lbllblBoxName.Name = "lbllblBoxName"
            Me.lbllblBoxName.Size = New System.Drawing.Size(80, 21)
            Me.lbllblBoxName.TabIndex = 183
            Me.lbllblBoxName.Text = "Box Name:"
            Me.lbllblBoxName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblModel
            '
            Me.lblModel.BackColor = System.Drawing.Color.Transparent
            Me.lblModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblModel.ForeColor = System.Drawing.Color.Black
            Me.lblModel.Location = New System.Drawing.Point(-8, 120)
            Me.lblModel.Name = "lblModel"
            Me.lblModel.Size = New System.Drawing.Size(96, 21)
            Me.lblModel.TabIndex = 185
            Me.lblModel.Text = "Model:"
            Me.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            Me.cboModel.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.cboModel.ItemHeight = 15
            Me.cboModel.Location = New System.Drawing.Point(96, 120)
            Me.cboModel.MatchEntryTimeout = CType(2000, Long)
            Me.cboModel.MaxDropDownItems = CType(5, Short)
            Me.cboModel.MaxLength = 32767
            Me.cboModel.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboModel.Name = "cboModel"
            Me.cboModel.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboModel.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboModel.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboModel.Size = New System.Drawing.Size(240, 21)
            Me.cboModel.TabIndex = 186
            Me.cboModel.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'lbllblOrderQty
            '
            Me.lbllblOrderQty.BackColor = System.Drawing.Color.Transparent
            Me.lbllblOrderQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbllblOrderQty.ForeColor = System.Drawing.Color.Black
            Me.lbllblOrderQty.Location = New System.Drawing.Point(24, 8)
            Me.lbllblOrderQty.Name = "lbllblOrderQty"
            Me.lbllblOrderQty.Size = New System.Drawing.Size(104, 21)
            Me.lbllblOrderQty.TabIndex = 188
            Me.lbllblOrderQty.Text = "WO Order Qty:"
            Me.lbllblOrderQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblOrderQty
            '
            Me.lblOrderQty.BackColor = System.Drawing.Color.Transparent
            Me.lblOrderQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblOrderQty.ForeColor = System.Drawing.Color.Black
            Me.lblOrderQty.Location = New System.Drawing.Point(144, 8)
            Me.lblOrderQty.Name = "lblOrderQty"
            Me.lblOrderQty.Size = New System.Drawing.Size(120, 21)
            Me.lblOrderQty.TabIndex = 187
            Me.lblOrderQty.Text = "0"
            Me.lblOrderQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lbllblRecvQty
            '
            Me.lbllblRecvQty.BackColor = System.Drawing.Color.Transparent
            Me.lbllblRecvQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbllblRecvQty.ForeColor = System.Drawing.Color.Black
            Me.lbllblRecvQty.Location = New System.Drawing.Point(24, 32)
            Me.lbllblRecvQty.Name = "lbllblRecvQty"
            Me.lbllblRecvQty.Size = New System.Drawing.Size(104, 21)
            Me.lbllblRecvQty.TabIndex = 190
            Me.lbllblRecvQty.Text = "WO Recv. Qty:"
            Me.lbllblRecvQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblRecvQty
            '
            Me.lblRecvQty.BackColor = System.Drawing.Color.Transparent
            Me.lblRecvQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRecvQty.ForeColor = System.Drawing.Color.Black
            Me.lblRecvQty.Location = New System.Drawing.Point(144, 32)
            Me.lblRecvQty.Name = "lblRecvQty"
            Me.lblRecvQty.Size = New System.Drawing.Size(120, 21)
            Me.lblRecvQty.TabIndex = 189
            Me.lblRecvQty.Text = "0"
            Me.lblRecvQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lbllblDiscrpQty
            '
            Me.lbllblDiscrpQty.BackColor = System.Drawing.Color.Transparent
            Me.lbllblDiscrpQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbllblDiscrpQty.ForeColor = System.Drawing.Color.Black
            Me.lbllblDiscrpQty.Location = New System.Drawing.Point(16, 56)
            Me.lbllblDiscrpQty.Name = "lbllblDiscrpQty"
            Me.lbllblDiscrpQty.Size = New System.Drawing.Size(112, 21)
            Me.lbllblDiscrpQty.TabIndex = 192
            Me.lbllblDiscrpQty.Text = "WO Discrp. Qty:"
            Me.lbllblDiscrpQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDiscrpQty
            '
            Me.lblDiscrpQty.BackColor = System.Drawing.Color.Transparent
            Me.lblDiscrpQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDiscrpQty.ForeColor = System.Drawing.Color.Black
            Me.lblDiscrpQty.Location = New System.Drawing.Point(144, 56)
            Me.lblDiscrpQty.Name = "lblDiscrpQty"
            Me.lblDiscrpQty.Size = New System.Drawing.Size(120, 21)
            Me.lblDiscrpQty.TabIndex = 191
            Me.lblDiscrpQty.Text = "0"
            Me.lblDiscrpQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lbllblWHLocation
            '
            Me.lbllblWHLocation.BackColor = System.Drawing.Color.Transparent
            Me.lbllblWHLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbllblWHLocation.ForeColor = System.Drawing.Color.Black
            Me.lbllblWHLocation.Location = New System.Drawing.Point(8, 80)
            Me.lbllblWHLocation.Name = "lbllblWHLocation"
            Me.lbllblWHLocation.Size = New System.Drawing.Size(120, 21)
            Me.lbllblWHLocation.TabIndex = 194
            Me.lbllblWHLocation.Text = "WH Bin Location:"
            Me.lbllblWHLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblWHLocation
            '
            Me.lblWHLocation.BackColor = System.Drawing.Color.Transparent
            Me.lblWHLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWHLocation.ForeColor = System.Drawing.Color.Black
            Me.lblWHLocation.Location = New System.Drawing.Point(128, 80)
            Me.lblWHLocation.Name = "lblWHLocation"
            Me.lblWHLocation.Size = New System.Drawing.Size(192, 21)
            Me.lblWHLocation.TabIndex = 193
            Me.lblWHLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'pnlBoxInfo
            '
            Me.pnlBoxInfo.Controls.AddRange(New System.Windows.Forms.Control() {Me.lbllblWarranty, Me.lblWarranty, Me.lblRecvQty, Me.lbllblDiscrpQty, Me.lbllblWHLocation, Me.lblDiscrpQty, Me.lblWHLocation, Me.lblOrderQty, Me.lbllblRecvQty, Me.lbllblOrderQty, Me.lbllblBoxName, Me.lblBoxName})
            Me.pnlBoxInfo.Location = New System.Drawing.Point(368, 16)
            Me.pnlBoxInfo.Name = "pnlBoxInfo"
            Me.pnlBoxInfo.Size = New System.Drawing.Size(336, 160)
            Me.pnlBoxInfo.TabIndex = 195
            '
            'lbllblWarranty
            '
            Me.lbllblWarranty.BackColor = System.Drawing.Color.Transparent
            Me.lbllblWarranty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbllblWarranty.ForeColor = System.Drawing.Color.Black
            Me.lbllblWarranty.Location = New System.Drawing.Point(8, 104)
            Me.lbllblWarranty.Name = "lbllblWarranty"
            Me.lbllblWarranty.Size = New System.Drawing.Size(120, 21)
            Me.lbllblWarranty.TabIndex = 196
            Me.lbllblWarranty.Text = "Warranty:"
            Me.lbllblWarranty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblWarranty
            '
            Me.lblWarranty.BackColor = System.Drawing.Color.Transparent
            Me.lblWarranty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWarranty.ForeColor = System.Drawing.Color.Black
            Me.lblWarranty.Location = New System.Drawing.Point(128, 104)
            Me.lblWarranty.Name = "lblWarranty"
            Me.lblWarranty.Size = New System.Drawing.Size(184, 21)
            Me.lblWarranty.TabIndex = 195
            Me.lblWarranty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblDeviceQty
            '
            Me.lblDeviceQty.BackColor = System.Drawing.Color.Transparent
            Me.lblDeviceQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblDeviceQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDeviceQty.ForeColor = System.Drawing.Color.DarkBlue
            Me.lblDeviceQty.Location = New System.Drawing.Point(200, 24)
            Me.lblDeviceQty.Name = "lblDeviceQty"
            Me.lblDeviceQty.Size = New System.Drawing.Size(120, 24)
            Me.lblDeviceQty.TabIndex = 198
            Me.lblDeviceQty.Text = "0"
            Me.lblDeviceQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lbllblDeviceQty
            '
            Me.lbllblDeviceQty.BackColor = System.Drawing.Color.Transparent
            Me.lbllblDeviceQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbllblDeviceQty.ForeColor = System.Drawing.Color.Navy
            Me.lbllblDeviceQty.Location = New System.Drawing.Point(24, 24)
            Me.lbllblDeviceQty.Name = "lbllblDeviceQty"
            Me.lbllblDeviceQty.Size = New System.Drawing.Size(168, 16)
            Me.lbllblDeviceQty.TabIndex = 197
            Me.lbllblDeviceQty.Text = "Device Qty Received:"
            Me.lbllblDeviceQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblSN
            '
            Me.lblSN.BackColor = System.Drawing.Color.Transparent
            Me.lblSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSN.ForeColor = System.Drawing.Color.Black
            Me.lblSN.Location = New System.Drawing.Point(8, 80)
            Me.lblSN.Name = "lblSN"
            Me.lblSN.Size = New System.Drawing.Size(40, 21)
            Me.lblSN.TabIndex = 199
            Me.lblSN.Text = "SN:"
            Me.lblSN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblResetWHLocation
            '
            Me.lblResetWHLocation.BackColor = System.Drawing.Color.Transparent
            Me.lblResetWHLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblResetWHLocation.ForeColor = System.Drawing.Color.Black
            Me.lblResetWHLocation.Location = New System.Drawing.Point(24, 48)
            Me.lblResetWHLocation.Name = "lblResetWHLocation"
            Me.lblResetWHLocation.Size = New System.Drawing.Size(168, 21)
            Me.lblResetWHLocation.TabIndex = 200
            Me.lblResetWHLocation.Text = "Reset WH Bin Location:"
            Me.lblResetWHLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'grpBoxInfo
            '
            Me.grpBoxInfo.BackColor = System.Drawing.Color.LightSteelBlue
            Me.grpBoxInfo.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnLoadWoBoxData, Me.pnlBoxInfo, Me.lblModel, Me.lblDockWO, Me.cboDockWO, Me.lblLocation, Me.lblCustomer, Me.cboLocation, Me.cboCustomer, Me.cboModel})
            Me.grpBoxInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grpBoxInfo.Location = New System.Drawing.Point(8, 8)
            Me.grpBoxInfo.Name = "grpBoxInfo"
            Me.grpBoxInfo.Size = New System.Drawing.Size(720, 200)
            Me.grpBoxInfo.TabIndex = 201
            Me.grpBoxInfo.TabStop = False
            Me.grpBoxInfo.Text = "WO Box Info"
            '
            'btnLoadWoBoxData
            '
            Me.btnLoadWoBoxData.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnLoadWoBoxData.ForeColor = System.Drawing.Color.Navy
            Me.btnLoadWoBoxData.Location = New System.Drawing.Point(120, 152)
            Me.btnLoadWoBoxData.Name = "btnLoadWoBoxData"
            Me.btnLoadWoBoxData.Size = New System.Drawing.Size(168, 40)
            Me.btnLoadWoBoxData.TabIndex = 196
            Me.btnLoadWoBoxData.Text = "Load WO Data"
            '
            'grpReceiving
            '
            Me.grpReceiving.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCloseBox, Me.btnRemoveAllSNs, Me.btnRemoveSN, Me.tdgDevices, Me.lblSN, Me.txtSN, Me.txtResetWHLocation, Me.lblDeviceQty, Me.lbllblDeviceQty, Me.lblResetWHLocation})
            Me.grpReceiving.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grpReceiving.Location = New System.Drawing.Point(8, 216)
            Me.grpReceiving.Name = "grpReceiving"
            Me.grpReceiving.Size = New System.Drawing.Size(720, 424)
            Me.grpReceiving.TabIndex = 202
            Me.grpReceiving.TabStop = False
            Me.grpReceiving.Text = "Device Receiving"
            '
            'btnCloseBox
            '
            Me.btnCloseBox.BackColor = System.Drawing.Color.Green
            Me.btnCloseBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCloseBox.ForeColor = System.Drawing.Color.White
            Me.btnCloseBox.Location = New System.Drawing.Point(344, 232)
            Me.btnCloseBox.Name = "btnCloseBox"
            Me.btnCloseBox.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnCloseBox.Size = New System.Drawing.Size(216, 48)
            Me.btnCloseBox.TabIndex = 202
            Me.btnCloseBox.Text = "CLOSE DEVICE RECEIVING"
            '
            'btnRemoveAllSNs
            '
            Me.btnRemoveAllSNs.BackColor = System.Drawing.Color.Red
            Me.btnRemoveAllSNs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveAllSNs.ForeColor = System.Drawing.Color.White
            Me.btnRemoveAllSNs.Location = New System.Drawing.Point(344, 168)
            Me.btnRemoveAllSNs.Name = "btnRemoveAllSNs"
            Me.btnRemoveAllSNs.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRemoveAllSNs.Size = New System.Drawing.Size(216, 30)
            Me.btnRemoveAllSNs.TabIndex = 204
            Me.btnRemoveAllSNs.Text = "REMOVE ALL SNs"
            '
            'btnRemoveSN
            '
            Me.btnRemoveSN.BackColor = System.Drawing.Color.Red
            Me.btnRemoveSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveSN.ForeColor = System.Drawing.Color.White
            Me.btnRemoveSN.Location = New System.Drawing.Point(344, 112)
            Me.btnRemoveSN.Name = "btnRemoveSN"
            Me.btnRemoveSN.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRemoveSN.Size = New System.Drawing.Size(216, 30)
            Me.btnRemoveSN.TabIndex = 203
            Me.btnRemoveSN.Text = "REMOVE SN"
            '
            'tdgDevices
            '
            Me.tdgDevices.AllowFilter = False
            Me.tdgDevices.AllowSort = False
            Me.tdgDevices.AllowUpdate = False
            Me.tdgDevices.AlternatingRows = True
            Me.tdgDevices.BackColor = System.Drawing.Color.GhostWhite
            Me.tdgDevices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tdgDevices.CaptionHeight = 17
            Me.tdgDevices.FetchRowStyles = True
            Me.tdgDevices.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgDevices.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgDevices.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.tdgDevices.Location = New System.Drawing.Point(24, 112)
            Me.tdgDevices.Name = "tdgDevices"
            Me.tdgDevices.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgDevices.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgDevices.PreviewInfo.ZoomFactor = 75
            Me.tdgDevices.RowHeight = 15
            Me.tdgDevices.Size = New System.Drawing.Size(296, 288)
            Me.tdgDevices.TabIndex = 201
            Me.tdgDevices.Text = "C1TrueDBGrid1"
            Me.tdgDevices.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            "ColumnFooterHeight=""17"" FetchRowStyles=""True"" MarqueeStyle=""DottedCellBorder"" Re" & _
            "cordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScr" & _
            "ollGroup=""1""><Height>286</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><E" & _
            "ditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Styl" & _
            "e8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Foo" & _
            "ter"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle paren" & _
            "t=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /" & _
            "><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=" & _
            """Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><Selected" & _
            "Style parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><Clie" & _
            "ntRect>0, 0, 294, 286</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken<" & _
            "/BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent" & _
            "="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" " & _
            "me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=" & _
            """Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""E" & _
            "ditor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""E" & _
            "venRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""Recor" & _
            "dSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=" & _
            """Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Lay" & _
            "out>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 29" & _
            "4, 286</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><PrintPageFoot" & _
            "erStyle parent="""" me=""Style15"" /></Blob>"
            '
            'TabControl1
            '
            Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Receiving, Me.Pattern})
            Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(752, 678)
            Me.TabControl1.TabIndex = 203
            '
            'Receiving
            '
            Me.Receiving.Controls.AddRange(New System.Windows.Forms.Control() {Me.grpBoxInfo, Me.grpReceiving})
            Me.Receiving.Location = New System.Drawing.Point(4, 22)
            Me.Receiving.Name = "Receiving"
            Me.Receiving.Size = New System.Drawing.Size(744, 652)
            Me.Receiving.TabIndex = 0
            Me.Receiving.Text = "Receiving "
            '
            'Pattern
            '
            Me.Pattern.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox1, Me.cboModelPatt, Me.cboCustomerPatt, Me.dgPatternSN, Me.btnAdd, Me.btnUpdate, Me.Label2, Me.Label1})
            Me.Pattern.Location = New System.Drawing.Point(4, 22)
            Me.Pattern.Name = "Pattern"
            Me.Pattern.Size = New System.Drawing.Size(744, 652)
            Me.Pattern.TabIndex = 1
            Me.Pattern.Text = "SN Pattern Data"
            '
            'dgPatternSN
            '
            Me.dgPatternSN.AllowDrag = True
            Me.dgPatternSN.FilterBar = True
            Me.dgPatternSN.GroupByCaption = "Drag a column header here to group by that column"
            Me.dgPatternSN.Images.Add(CType(resources.GetObject("resource.Images5"), System.Drawing.Bitmap))
            Me.dgPatternSN.Location = New System.Drawing.Point(16, 248)
            Me.dgPatternSN.Name = "dgPatternSN"
            Me.dgPatternSN.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dgPatternSN.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dgPatternSN.PreviewInfo.ZoomFactor = 75
            Me.dgPatternSN.Size = New System.Drawing.Size(704, 392)
            Me.dgPatternSN.TabIndex = 8
            Me.dgPatternSN.Text = "C1TrueDBGrid1"
            Me.dgPatternSN.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Style1{}Normal{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}St" & _
            "yle12{}OddRow{}RecordSelector{AlignImage:Center;}Style13{}Heading{Wrap:True;Back" & _
            "Color:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}" & _
            "Style8{}Style10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style9{}</Data></Styl" & _
            "es><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" CaptionHeight=""17"" ColumnCapti" & _
            "onHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellB" & _
            "order"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" Hori" & _
            "zontalScrollGroup=""1""><Height>388</Height><CaptionStyle parent=""Style2"" me=""Styl" & _
            "e10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow""" & _
            " me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle pa" & _
            "rent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingSt" & _
            "yle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""" & _
            "Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""Od" & _
            "dRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" />" & _
            "<SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1" & _
            """ /><ClientRect>0, 0, 700, 388</ClientRect><BorderSide>0</BorderSide><BorderStyl" & _
            "e>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Sty" & _
            "le parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""" & _
            "Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Hea" & _
            "ding"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Norm" & _
            "al"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Norm" & _
            "al"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" " & _
            "me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Cap" & _
            "tion"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSp" & _
            "lits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea" & _
            ">0, 0, 700, 388</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><Prin" & _
            "tPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'btnAdd
            '
            Me.btnAdd.Location = New System.Drawing.Point(352, 40)
            Me.btnAdd.Name = "btnAdd"
            Me.btnAdd.Size = New System.Drawing.Size(168, 23)
            Me.btnAdd.TabIndex = 7
            Me.btnAdd.Text = "Add"
            '
            'btnUpdate
            '
            Me.btnUpdate.Location = New System.Drawing.Point(352, 72)
            Me.btnUpdate.Name = "btnUpdate"
            Me.btnUpdate.Size = New System.Drawing.Size(168, 23)
            Me.btnUpdate.TabIndex = 6
            Me.btnUpdate.Text = "Update"
            '
            'txtSNPattern
            '
            Me.txtSNPattern.Location = New System.Drawing.Point(16, 48)
            Me.txtSNPattern.Name = "txtSNPattern"
            Me.txtSNPattern.Size = New System.Drawing.Size(72, 20)
            Me.txtSNPattern.TabIndex = 5
            Me.txtSNPattern.Text = ""
            '
            'Label3
            '
            Me.Label3.Location = New System.Drawing.Point(16, 24)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(64, 23)
            Me.Label3.TabIndex = 2
            Me.Label3.Text = "Prefix"
            '
            'Label2
            '
            Me.Label2.Location = New System.Drawing.Point(16, 80)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(64, 23)
            Me.Label2.TabIndex = 1
            Me.Label2.Text = "Model"
            '
            'Label1
            '
            Me.Label1.Location = New System.Drawing.Point(16, 48)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(64, 23)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Customer "
            '
            'cboCustomerPatt
            '
            Me.cboCustomerPatt.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboCustomerPatt.Caption = ""
            Me.cboCustomerPatt.CaptionHeight = 17
            Me.cboCustomerPatt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboCustomerPatt.ColumnCaptionHeight = 17
            Me.cboCustomerPatt.ColumnFooterHeight = 17
            Me.cboCustomerPatt.ContentHeight = 15
            Me.cboCustomerPatt.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboCustomerPatt.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboCustomerPatt.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCustomerPatt.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboCustomerPatt.EditorHeight = 15
            Me.cboCustomerPatt.Images.Add(CType(resources.GetObject("resource.Images6"), System.Drawing.Bitmap))
            Me.cboCustomerPatt.ItemHeight = 15
            Me.cboCustomerPatt.Location = New System.Drawing.Point(88, 48)
            Me.cboCustomerPatt.MatchEntryTimeout = CType(2000, Long)
            Me.cboCustomerPatt.MaxDropDownItems = CType(5, Short)
            Me.cboCustomerPatt.MaxLength = 32767
            Me.cboCustomerPatt.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCustomerPatt.Name = "cboCustomerPatt"
            Me.cboCustomerPatt.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCustomerPatt.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCustomerPatt.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCustomerPatt.Size = New System.Drawing.Size(240, 21)
            Me.cboCustomerPatt.TabIndex = 174
            Me.cboCustomerPatt.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'cboModelPatt
            '
            Me.cboModelPatt.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboModelPatt.Caption = ""
            Me.cboModelPatt.CaptionHeight = 17
            Me.cboModelPatt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboModelPatt.ColumnCaptionHeight = 17
            Me.cboModelPatt.ColumnFooterHeight = 17
            Me.cboModelPatt.ContentHeight = 15
            Me.cboModelPatt.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboModelPatt.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboModelPatt.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboModelPatt.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboModelPatt.EditorHeight = 15
            Me.cboModelPatt.Images.Add(CType(resources.GetObject("resource.Images7"), System.Drawing.Bitmap))
            Me.cboModelPatt.ItemHeight = 15
            Me.cboModelPatt.Location = New System.Drawing.Point(88, 80)
            Me.cboModelPatt.MatchEntryTimeout = CType(2000, Long)
            Me.cboModelPatt.MaxDropDownItems = CType(5, Short)
            Me.cboModelPatt.MaxLength = 32767
            Me.cboModelPatt.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboModelPatt.Name = "cboModelPatt"
            Me.cboModelPatt.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboModelPatt.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboModelPatt.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboModelPatt.Size = New System.Drawing.Size(240, 21)
            Me.cboModelPatt.TabIndex = 187
            Me.cboModelPatt.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            Me.Label4.ForeColor = System.Drawing.Color.Red
            Me.Label4.Location = New System.Drawing.Point(8, 80)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(296, 32)
            Me.Label4.TabIndex = 188
            Me.Label4.Text = "Description : Serial Number Pattern, for example, KWxxxxxxx. X represents charact" & _
            "ers after KW"
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label5, Me.TextBox1, Me.Label4, Me.txtSNPattern, Me.Label3})
            Me.GroupBox1.Location = New System.Drawing.Point(16, 120)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(416, 120)
            Me.GroupBox1.TabIndex = 189
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Serial Number Pattern"
            '
            'TextBox1
            '
            Me.TextBox1.Location = New System.Drawing.Point(96, 48)
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.Size = New System.Drawing.Size(152, 20)
            Me.TextBox1.TabIndex = 190
            Me.TextBox1.Text = ""
            '
            'Label5
            '
            Me.Label5.Location = New System.Drawing.Point(96, 24)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(152, 23)
            Me.Label5.TabIndex = 191
            Me.Label5.Text = "Character after the Prefix"
            '
            'frmVivint_DeviceRecv
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.Lavender
            Me.ClientSize = New System.Drawing.Size(752, 678)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1})
            Me.Name = "frmVivint_DeviceRecv"
            Me.Text = "frmVivint_DeviceRecv"
            CType(Me.cboCustomer, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboLocation, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboDockWO, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboModel, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlBoxInfo.ResumeLayout(False)
            Me.grpBoxInfo.ResumeLayout(False)
            Me.grpReceiving.ResumeLayout(False)
            CType(Me.tdgDevices, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControl1.ResumeLayout(False)
            Me.Receiving.ResumeLayout(False)
            Me.Pattern.ResumeLayout(False)
            CType(Me.dgPatternSN, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboCustomerPatt, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboModelPatt, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmVivint_DeviceRecv_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable, dtLoc As DataTable
            Dim dtModelPatt

            Dim iLoc_ID As Integer = 0
            Dim iModel_ID As Integer

            Try
                PSS.Core.Highlight.SetHighLight(Me)

                Me.TabControl1.TabPages.RemoveAt(1)

                Me.txtSN.Text = ""
                Me.lblResetWHLocation.Visible = False : Me.txtResetWHLocation.Visible = False 'turn off now 
                Me.btnRemoveSN.Visible = False : Me.btnRemoveAllSNs.Visible = False
                Me.grpReceiving.Enabled = False


                'Populate customer
                dt = Generic.GetCustomers(True, )
                Misc.PopulateC1DropDownList(Me.cboCustomer, dt, "Cust_Name1", "Cust_ID")
                '  Misc.PopulateC1DropDownList(Me.cboCustomerPatt, dt, "Cust_Name1", "Cust_ID")
                Me.cboCustomer.SelectedValue = Me._iCust_ID
                Me.cboCustomerPatt.SelectedValue = Me._iCust_ID
                If Me.cboCustomer.SelectedValue > 0 Then Me.cboCustomer.Enabled = False
                If Me.cboCustomerPatt.SelectedValue > 0 Then Me.cboCustomerPatt.Enabled = False
                'Location
                dtLoc = Generic.GetLocations(True, Me._iCust_ID)
                Misc.PopulateC1DropDownList(Me.cboLocation, dtLoc, "Loc_Name", "Loc_ID")
                If dtLoc.Rows.Count = 2 Then
                    iLoc_ID = dtLoc.Rows(0).Item("Loc_ID")
                    Me.cboLocation.SelectedValue = iLoc_ID
                    Me.cboDockWO.Focus()
                Else
                    Me.cboLocation.SelectedValue = 0
                    Me.cboLocation.Focus()
                End If

                'dtModelPatt = Me._objVivint_DeviceRecv.GetVivintModels(Me._iCust_ID, True)
                'Misc.PopulateC1DropDownList(Me.cboModelPatt, dtModelPatt, "Model_Desc", "Model_id")
                'If dtModelPatt.Rows.Count = 2 Then
                '    iModel_ID = dtModelPatt.Rows(0).Item("Model_Desc")
                '    Me.cboModelPatt.SelectedValue = iModel_ID
                'Else
                '    Me.cboModelPatt.SelectedValue = 0
                'End If
                ' Me.txtSN.Text = "" : Me.txtSN.SelectAll() : Me.txtSN.Focus()
                ' getSNPattern()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally '
                Generic.DisposeDT(dt)
            End Try
        End Sub

        Private Sub cboLocation_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLocation.SelectedValueChanged
            Dim dtWO As DataTable

            Try
                If Me.cboLocation.SelectedValue > 0 Then
                    dtWO = Me._objVivint_DeviceRecv.getOpenWODockBoxOrders(Me._iCust_ID, Me.cboLocation.SelectedValue, True)

                    Misc.PopulateC1DropDownList(Me.cboDockWO, dtWO, "WO_CustWO", "WO_ID")
                    Me.cboDockWO.SelectedValue = 0
                Else
                    ' MessageBox.Show("Please selet a location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    ' Me.cboLocation.Focus()
                End If

            Catch ex As Exception
                ' MessageBox.Show(ex.ToString, "cboLocation_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub cboDockWO_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDockWO.SelectedValueChanged
            Dim dtModel As DataTable

            Try
                If Me.cboDockWO.SelectedValue > 0 Then
                    dtModel = Me._objVivint_DeviceRecv.getOpenWODockBoxOrderModels(Me._iCust_ID, Me.cboLocation.SelectedValue, Me.cboDockWO.SelectedValue, True)

                    Misc.PopulateC1DropDownList(Me.cboModel, dtModel, "Model_Desc", "Model_ID")
                    Me.cboModel.SelectedValue = 0
                Else
                    ' Me.cboDockWO.Focus()
                    ' MessageBox.Show("Please selet a WO.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                End If

            Catch ex As Exception
                ' MessageBox.Show(ex.ToString, "cboLocation_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnLoadWoBoxData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLoadWoBoxData.Click
            Dim dt As DataTable
            Dim iwb_ID As Integer = 0

            Try
                'WO_ID, WO_CustWO, WO_Date, WO_Quantity, WO_RAQnty, WO_Discrepancy, Loc_ID, Prod_ID, Group_ID, Sku_ID, WO_Closed, OrderType_ID
                ', wb_id, BoxID, FuncRep, WrtyExpedite, WarrantyFlag, Model_ID, Order_Qty, Recv_Qty, Diff_Qty, Order_ID, Closed, WHLocation
                ', BoxStage, Cust_ID, Cust_Name1, Model_Desc
                iwb_ID = Me.cboModel.DataSource.Table.Select("Model_ID = " & Me.cboModel.SelectedValue)(0)("wb_id")
                If Me.cboLocation.SelectedValue > 0 AndAlso Me.cboDockWO.SelectedValue > 0 AndAlso Me.cboModel.SelectedValue > 0 Then
                    dt = Me._objVivint_DeviceRecv.getOpenWODockBoxDetailData(Me._iCust_ID, Me.cboLocation.SelectedValue, iwb_ID)
                    Me.BindBoxData(dt)
                    Me.grpBoxInfo.Enabled = False : Me.grpReceiving.Enabled = True
                    Me.txtSN.Text = "" : Me.txtSN.SelectAll() : Me.txtSN.Focus()
                Else
                    MessageBox.Show("Please selet a WO.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnLoadWoBoxData_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub BindBoxData(ByVal dt As DataTable)
            Dim row As DataRow
            Dim row2 As DataRow
            Dim dtWrty As DataTable
            'Dim iWrty As Integer = 0

            Try
                'WO_ID, WO_CustWO, WO_Date, WO_Quantity, WO_RAQnty, WO_Discrepancy, Loc_ID, Prod_ID, Group_ID, Sku_ID, WO_Closed, OrderType_ID
                ', wb_id, BoxID, FuncRep, WrtyExpedite, WarrantyFlag, Model_ID, Order_Qty, Recv_Qty, Diff_Qty, Order_ID, Closed, WHLocation
                ', BoxStage, Cust_ID, Cust_Name1, Model_Desc
                For Each row In dt.Rows 'should be 1 row
                    Me._iWb_ID = Convert.ToInt32(row("wb_id"))
                    Me._iWO_ID = Convert.ToInt32(row("WO_ID"))
                    Me._strWO = row("WO_CustWO")
                    Me._strModel = row("Model_Desc")

                    Me.lblOrderQty.Text = row("Order_Qty")
                    Me.lblRecvQty.Text = row("Recv_Qty")
                    Me.lblDiscrpQty.Text = row("Diff_Qty")
                    Me.lblWHLocation.Text = row("WHLocation")
                    If Not row.IsNull("WarrantyFlag") Then
                        Me._iWrty = Convert.ToInt32(row("WarrantyFlag"))
                        dtWrty = Me._objVivint.getWarrantyTypeData 'Wrty_ID, Wrty_Desc, BoxNamePart
                        For Each row2 In dtWrty.Rows
                            If Me._iWrty = Convert.ToInt32(row2("Wrty_ID")) Then
                                Me.lblWarranty.Text = row2("Wrty_Desc") : Exit For
                            End If
                        Next
                    Else
                        Me.lblWarranty.Text = ""
                    End If
                    Me.lblBoxName.Text = row("BoxID")
                    Exit For
                Next

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "BindBoxData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub txtSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyUp
            Try
                If e.KeyCode = Keys.Enter Then
                    If Me.txtSN.Text.Trim.Length > 0 Then
                        Me.ProcessSN()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub ProcessSN()
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
            Dim strSN As String = ""
            Dim iDevice_ID As Integer = 0
            Dim iDeviceAutoWrty As Integer = 0
            Dim strDeviceAutoWrty_Desc As String = ""
            Dim i As Integer = 0
            Dim strDateTime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
            Dim dReceivingDate As Date = Now.Date
            Dim bSuccessed As Boolean = False
            Dim dtDuplicate, dtRequested As DataTable
            Dim iShift_ID As Integer = PSS.Core.ApplicationUser.IDShift
            Dim strWorkDate As String = Generic.GetWorkDate(iShift_ID)
            Dim iTray_ID As Integer = 0
            Dim strTrayMemo As String = "Vivint Device Receiving"
            Dim dtWrty As DataTable
            Dim strManufTime As String = "", strWrtyExpirationTime As String = ""
            Dim bIsDeviceAutoWrty As Boolean = False
            Dim row As DataRow

            Try
                strSN = Me.txtSN.Text.Trim

                'Remove prefix as define if any
                Me.txtSN.Text = Me._objVivint.RemovePrefixSN(strSN, Me.cboCustomer.SelectedValue, Me.cboLocation.SelectedValue, Me.cboModel.SelectedValue)

                strSN = Me.txtSN.Text.Trim

                If Not strSN.Length > 0 Then
                    MessageBox.Show("Please enter a valid SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtSN.SelectAll() : Me.txtSN.Focus() : Exit Sub
                End If


                If Me._dtReceivedDevices.Rows.Count > 0 AndAlso IsSNinTheList(Me._dtReceivedDevices, strSN) Then
                    MessageBox.Show("This SN '" & strSN & "' already in the list.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtSN.SelectAll() : Me.txtSN.Focus() : Exit Sub
                ElseIf IsReceivedUnshipped(Me.cboLocation.SelectedValue, strSN) Then
                    MessageBox.Show("This SN '" & strSN & "' has already be received in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtSN.SelectAll() : Me.txtSN.Focus() : Exit Sub
                ElseIf Me._dtReceivedDevices.Rows.Count >= Convert.ToInt32(Me.lblOrderQty.Text) Then
                    If MsgBox("Device qty received are more than order qty. Do you want to receive more?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        Me.txtSN.SelectAll() : Me.txtSN.Focus() : Exit Sub
                    End If
                End If
                Dim iCount As Integer = 0
                dtDuplicate = Me._objVivint_DeviceRecv.checkDevicesDuplicate(Me.cboLocation.SelectedValue, strSN)
                dtRequested = Me._objVivint_DeviceRecv.checkDevicesRequested(Me.cboLocation.SelectedValue, strSN)
                If dtDuplicate.Rows.Count > 0 Then
                    If dtRequested.Rows.Count = 0 Then
                        MessageBox.Show("This SN '" & strSN & "' Exists in the System and not yet Shipped out", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txtSN.SelectAll() : Me.txtSN.Focus() : Exit Sub
                    End If
                    For iCount = 0 To dtRequested.Rows.Count - 1
                        Dim strTempRequest As String = Convert.ToString(dtRequested.Rows(iCount)("Po_requested"))
                        If strTempRequest <> "1" Then
                            MessageBox.Show("This SN '" & strSN & "' Exists in the System and not yet Shipped out", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.txtSN.SelectAll() : Me.txtSN.Focus() : Exit Sub
                        End If
                    Next
                End If

                If Me._objVivint_DeviceRecv.IsModelDeviceAutomaticWrty(Me.cboModel.SelectedValue) Then
                    'Wrty_Status Wrty_Status_Desc: 0 = OUT OF WARRANTY; 1 = IN WARRANTY
                    'IsSuccessful: Yes=successful, No=false
                    Dim strTmpS As String = ""
                    dtWrty = Me._objVivint_DeviceRecv.getVivintChiconyWrtyData(strSN, dReceivingDate)
                    For Each row In dtWrty.Rows 'must be 1 row
                        If Not row.IsNull("IsSuccessful") AndAlso Convert.ToString(row("IsSuccessful")).Trim.ToUpper = "Yes".ToUpper Then
                            iDeviceAutoWrty = Convert.ToInt32(row("Wrty_Status"))
                            strDeviceAutoWrty_Desc = Convert.ToString(row("Wrty_Status_Desc")).Trim
                            strManufTime = Convert.ToString(row("Manuf_YrWk")).Trim
                            strWrtyExpirationTime = Convert.ToString(row("Wrty_YrWk")).Trim
                            bIsDeviceAutoWrty = True
                        Else
                            strTmpS = Convert.ToString(row("ErrMsg")).Trim
                            MessageBox.Show(strTmpS & ". Failed to pass wrty decoding.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.txtSN.SelectAll() : Me.txtSN.Focus() : Exit Sub
                        End If
                        Exit For
                    Next
                End If

                'Ready to be received
                iTray_ID = Me._objVivint_DeviceRecv.getTrayID(Me._iUserID, Me._strUser, Me._iWO_ID, strTrayMemo)

                If bIsDeviceAutoWrty Then
                    bSuccessed = Me._objVivint_DeviceRecv.ReceiveDeviceIntoSystem(Me._iCust_ID, Me.cboLocation.SelectedValue, Me._strWO, Me._iWO_ID, Me.cboModel.SelectedValue, _
                                                                                  strSN, "", strDateTime, strWorkDate, Me._strModel, iShift_ID, iTray_ID, Me._iWb_ID, _
                                                                                  iDeviceAutoWrty, strDeviceAutoWrty_Desc, iDevice_ID, strManufTime, strWrtyExpirationTime)
                Else
                    bSuccessed = Me._objVivint_DeviceRecv.ReceiveDeviceIntoSystem(Me._iCust_ID, Me.cboLocation.SelectedValue, Me._strWO, Me._iWO_ID, Me.cboModel.SelectedValue, _
                                                                                  strSN, "", strDateTime, strWorkDate, Me._strModel, iShift_ID, iTray_ID, Me._iWb_ID, _
                                                                                  Me._iWrty, Me.lblWarranty.Text.Trim, iDevice_ID, "", "")
                End If
                If bSuccessed Then
                    Dim rowNew As DataRow 'Device_SN, Device_ID
                    Dim j As Integer = 0

                    rowNew = Me._dtReceivedDevices.NewRow
                    rowNew("Device_SN") = strSN : rowNew("Device_ID") = iDevice_ID
                    Me._dtReceivedDevices.Rows.Add(rowNew)

                    'Bind device data
                    With Me.tdgDevices
                        .DataSource = Me._dtReceivedDevices.DefaultView

                        For Each dbgc In .Splits(0).DisplayColumns
                            dbgc.Locked = True
                            dbgc.AutoSize()
                            j += 1
                            If j > 1 Then dbgc.Visible = False
                        Next dbgc
                        '.Splits(0).DisplayColumns("device_id").Width = 0
                    End With
                    Me.lblDeviceQty.Text = Me._dtReceivedDevices.Rows.Count
                    Me.txtSN.Text = "" : Me.txtSN.SelectAll() : Me.txtSN.Focus() : Exit Sub

                Else
                    MessageBox.Show("Failed to receive this device. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtSN.SelectAll() : Me.txtSN.Focus() : Exit Sub
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Finally
                Me.Cursor = Cursors.Default
                'dt = Nothing : dtModel = Nothing
            End Try
        End Sub

        Private Function IsSNinTheList(ByVal dt As DataTable, ByVal strSN As String) As Boolean
            Dim row As DataRow
            Dim bRet As Boolean = False
            Dim strS As String = ""

            For Each row In dt.Rows
                If Not row.IsNull("Device_SN") Then
                    strS = row("Device_SN")
                    If strS.Trim.ToUpper = strSN.Trim.ToUpper Then
                        bRet = True
                        Exit For
                    End If
                End If
            Next

            Return bRet

        End Function
        'Private Sub getSNPattern()
        '    dgPatternSN.DataSource = Me._objVivint_DeviceRecv.getSNPattern()
        'End Sub

        Private Function IsReceivedUnshipped(ByVal iLoc_ID As Integer, ByVal strSN As String) As Boolean
            Dim dt As DataTable

            Try
                dt = Me._objVivint_DeviceRecv.getReceivedUnshipped(iLoc_ID, strSN)
                If dt.Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "IsReceivedUnshipped", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Function


        Private Sub btnCloseBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseBox.Click
            Dim i As Integer = 0
            Try
                i = Me._objVivint_DeviceRecv.CloseReceivingBox(Me._iWb_ID)

                ResetControls()
                Me.grpBoxInfo.Enabled = True : Me.grpReceiving.Enabled = False
                Me.cboLocation.Focus()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnCloseBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub ResetControls()
            Try
                Me._dtReceivedDevices.Rows.Clear()
                Me.txtSN.Text = ""
                Me._iWb_ID = 0
                Me._iWO_ID = 0
                Me._strWO = ""
                Me._strModel = ""
                Me._iWrty = 0

                Me.lblOrderQty.Text = 0
                Me.lblRecvQty.Text = 0
                Me.lblDiscrpQty.Text = 0
                Me.lblWHLocation.Text = ""
                Me.lblWarranty.Text = ""
                Me.lblBoxName.Text = ""

                Me.cboDockWO.ClearItems()
                Me.cboModel.ClearItems()

                Me.tdgDevices.DataSource = Nothing

                Dim dtWO As DataTable
                If Me.cboLocation.SelectedValue > 0 Then
                    dtWO = Me._objVivint_DeviceRecv.getOpenWODockBoxOrders(Me._iCust_ID, Me.cboLocation.SelectedValue, True)
                    Misc.PopulateC1DropDownList(Me.cboDockWO, dtWO, "WO_CustWO", "WO_ID")
                    Me.cboDockWO.SelectedValue = 0
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ResetControls", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        'Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        '    Dim iLoc_ID As Integer = 0
        '    Dim iModel_ID As Integer = 0
        '    Dim iType_ID As Integer = 0
        '    Dim strSW_Version As String = ""
        '    Try

        '        If IsNothing(Me.cboCustomerPatt.SelectedValue) OrElse Me.cboCustomerPatt.SelectedValue = 0 Then
        '            MessageBox.Show("Please select Customer .", "Create pattern", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '            Me.cboLocation.Focus()
        '        ElseIf IsNothing(Me.cboModelPatt.SelectedValue) OrElse Me.cboModelPatt.SelectedValue = 0 Then
        '            MessageBox.Show("Please select model.", "Create pattern", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '            Me.cboModel.Focus()
        '        ElseIf IsNothing(Me.txtSNPattern.Text) Then
        '            MessageBox.Show("Please enter the SN Pattern.", "Create pattern", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '            Me.txtSNPattern.Focus()
        '        Else
        '            Me._objVivint_DeviceRecv.CreateSNPattern(Me.cboCustomerPatt.SelectedValue, Me.cboModelPatt.SelectedValue, _
        '                                                              Me.txtSNPattern.Text, Me._iUserID)

        '        End If

        '    Catch ex As Exception
        '        MessageBox.Show(ex.ToString, "btnCreateBoxID_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End Try
        'End Sub



        'Private Sub dgPatternSN_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgPatternSN.MouseUp
        '    Me.txtSNPattern.Text = Me.dgPatternSN.Columns("Box Name").Value.ToString
        'End Sub
    End Class
End Namespace