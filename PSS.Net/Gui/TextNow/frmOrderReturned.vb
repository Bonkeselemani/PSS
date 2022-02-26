Option Explicit On 

Imports PSS.Data.Buisness

Public Class frmOrderReturned
    Inherits System.Windows.Forms.Form
    Private _iMenuCustID As Integer = 0
    Private _iLocID As Integer = 0
    Private _objTN As TN
    Private _UserID As Integer = PSS.Core.Global.ApplicationUser.IDuser
    Private _dtOrderHeader, _dtOrderProductDetails As DataTable

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal iCust_ID As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me._objTN = New TN()
        Me._iMenuCustID = iCust_ID
        Me._iLocID = Me._objTN.LOCID

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
    Friend WithEvents btnSetOrderReturned As System.Windows.Forms.Button
    Friend WithEvents lblOrderID As System.Windows.Forms.Label
    Friend WithEvents tdgData1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents txtSN As System.Windows.Forms.TextBox
    Friend WithEvents lblSN As System.Windows.Forms.Label
    Friend WithEvents txtTrackingNo As System.Windows.Forms.TextBox
    Friend WithEvents chkBoxTrim As System.Windows.Forms.CheckBox
    Friend WithEvents lstICCID As System.Windows.Forms.ListBox
    Friend WithEvents txtReturnQty As System.Windows.Forms.TextBox
    Friend WithEvents lblOrderQty As System.Windows.Forms.Label
    Friend WithEvents txtShippedQty As System.Windows.Forms.TextBox
    Friend WithEvents lblShipQty As System.Windows.Forms.Label
    Friend WithEvents tdgData0 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtOrderQty As System.Windows.Forms.TextBox
    Friend WithEvents txtOrderNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmOrderReturned))
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSetOrderReturned = New System.Windows.Forms.Button()
        Me.lblOrderID = New System.Windows.Forms.Label()
        Me.txtTrackingNo = New System.Windows.Forms.TextBox()
        Me.txtSN = New System.Windows.Forms.TextBox()
        Me.lblSN = New System.Windows.Forms.Label()
        Me.tdgData1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.chkBoxTrim = New System.Windows.Forms.CheckBox()
        Me.lstICCID = New System.Windows.Forms.ListBox()
        Me.txtReturnQty = New System.Windows.Forms.TextBox()
        Me.lblOrderQty = New System.Windows.Forms.Label()
        Me.txtShippedQty = New System.Windows.Forms.TextBox()
        Me.lblShipQty = New System.Windows.Forms.Label()
        Me.tdgData0 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtOrderQty = New System.Windows.Forms.TextBox()
        Me.txtOrderNo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdgData0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(496, 72)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(168, 48)
        Me.btnCancel.TabIndex = 180
        Me.btnCancel.Text = "Cancel/Close"
        '
        'btnSetOrderReturned
        '
        Me.btnSetOrderReturned.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetOrderReturned.Location = New System.Drawing.Point(496, 128)
        Me.btnSetOrderReturned.Name = "btnSetOrderReturned"
        Me.btnSetOrderReturned.Size = New System.Drawing.Size(168, 48)
        Me.btnSetOrderReturned.TabIndex = 179
        Me.btnSetOrderReturned.Text = "Yes"
        '
        'lblOrderID
        '
        Me.lblOrderID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrderID.Location = New System.Drawing.Point(616, 32)
        Me.lblOrderID.Name = "lblOrderID"
        Me.lblOrderID.Size = New System.Drawing.Size(56, 32)
        Me.lblOrderID.TabIndex = 2
        Me.lblOrderID.Text = "USPS Tracking No:"
        Me.lblOrderID.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lblOrderID.Visible = False
        '
        'txtTrackingNo
        '
        Me.txtTrackingNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTrackingNo.Location = New System.Drawing.Point(624, 8)
        Me.txtTrackingNo.Name = "txtTrackingNo"
        Me.txtTrackingNo.Size = New System.Drawing.Size(24, 22)
        Me.txtTrackingNo.TabIndex = 3
        Me.txtTrackingNo.Text = ""
        Me.txtTrackingNo.Visible = False
        '
        'txtSN
        '
        Me.txtSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSN.Location = New System.Drawing.Point(184, 48)
        Me.txtSN.Name = "txtSN"
        Me.txtSN.Size = New System.Drawing.Size(296, 22)
        Me.txtSN.TabIndex = 5
        Me.txtSN.Text = ""
        '
        'lblSN
        '
        Me.lblSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSN.Location = New System.Drawing.Point(72, 48)
        Me.lblSN.Name = "lblSN"
        Me.lblSN.Size = New System.Drawing.Size(104, 32)
        Me.lblSN.TabIndex = 4
        Me.lblSN.Text = "SN (ICCID):"
        Me.lblSN.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'tdgData1
        '
        Me.tdgData1.AllowArrows = False
        Me.tdgData1.AllowColMove = False
        Me.tdgData1.AllowColSelect = False
        Me.tdgData1.AllowFilter = False
        Me.tdgData1.AllowRowSelect = False
        Me.tdgData1.AllowSort = False
        Me.tdgData1.AllowUpdate = False
        Me.tdgData1.AlternatingRows = True
        Me.tdgData1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.tdgData1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tdgData1.Caption = "Shipped Product Details"
        Me.tdgData1.FetchRowStyles = True
        Me.tdgData1.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Flat
        Me.tdgData1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tdgData1.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdgData1.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.tdgData1.Location = New System.Drawing.Point(8, 264)
        Me.tdgData1.Name = "tdgData1"
        Me.tdgData1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdgData1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdgData1.PreviewInfo.ZoomFactor = 75
        Me.tdgData1.RowSubDividerColor = System.Drawing.Color.LightBlue
        Me.tdgData1.Size = New System.Drawing.Size(680, 200)
        Me.tdgData1.TabIndex = 177
        Me.tdgData1.Text = "C1TrueDBGrid1"
        Me.tdgData1.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Al" & _
        "iceBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive{" & _
        "ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Capt" & _
        "ion{AlignHorz:Center;ForeColor:Navy;BackColor:LightSteelBlue;}Style1{}Normal{Fon" & _
        "t:Arial, 8.25pt;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style" & _
        "14{}OddRow{}RecordSelector{AlignImage:Center;}Style15{}Heading{Wrap:True;BackCol" & _
        "or:LightSteelBlue;Border:Flat,ControlDark,1, 1, 1, 1;ForeColor:ControlText;Align" & _
        "Vert:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style9{}" & _
        "</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" Allo" & _
        "wColSelect=""False"" AllowRowSelect=""False"" Name="""" AlternatingRowStyle=""True"" Cap" & _
        "tionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyles=" & _
        """True"" FilterBorderStyle=""Flat"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWi" & _
        "dth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><" & _
        "Height>183</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle par" & _
        "ent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterB" & _
        "arStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style" & _
        "3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me" & _
        "=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyl" & _
        "e parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><Re" & _
        "cordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""" & _
        "Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 17, " & _
        "680, 183</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle>" & _
        "</C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Norma" & _
        "l"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /" & _
        "><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" />" & _
        "<Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Sty" & _
        "le parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><St" & _
        "yle parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" />" & _
        "<Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></N" & _
        "amedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Lay" & _
        "out><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 680, 200</Clien" & _
        "tArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle paren" & _
        "t="""" me=""Style15"" /></Blob>"
        '
        'chkBoxTrim
        '
        Me.chkBoxTrim.Location = New System.Drawing.Point(648, 8)
        Me.chkBoxTrim.Name = "chkBoxTrim"
        Me.chkBoxTrim.Size = New System.Drawing.Size(46, 24)
        Me.chkBoxTrim.TabIndex = 178
        Me.chkBoxTrim.Text = "Take off prefix 8 digits "
        Me.chkBoxTrim.Visible = False
        '
        'lstICCID
        '
        Me.lstICCID.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstICCID.Location = New System.Drawing.Point(184, 72)
        Me.lstICCID.Name = "lstICCID"
        Me.lstICCID.Size = New System.Drawing.Size(296, 108)
        Me.lstICCID.TabIndex = 181
        '
        'txtReturnQty
        '
        Me.txtReturnQty.BackColor = System.Drawing.Color.Black
        Me.txtReturnQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReturnQty.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReturnQty.ForeColor = System.Drawing.Color.Aquamarine
        Me.txtReturnQty.Location = New System.Drawing.Point(128, 88)
        Me.txtReturnQty.Name = "txtReturnQty"
        Me.txtReturnQty.ReadOnly = True
        Me.txtReturnQty.Size = New System.Drawing.Size(48, 23)
        Me.txtReturnQty.TabIndex = 183
        Me.txtReturnQty.Text = "0"
        Me.txtReturnQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblOrderQty
        '
        Me.lblOrderQty.BackColor = System.Drawing.Color.Transparent
        Me.lblOrderQty.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrderQty.ForeColor = System.Drawing.Color.Black
        Me.lblOrderQty.Location = New System.Drawing.Point(48, 88)
        Me.lblOrderQty.Name = "lblOrderQty"
        Me.lblOrderQty.Size = New System.Drawing.Size(80, 21)
        Me.lblOrderQty.TabIndex = 184
        Me.lblOrderQty.Text = "Return Qty"
        Me.lblOrderQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtShippedQty
        '
        Me.txtShippedQty.BackColor = System.Drawing.Color.Black
        Me.txtShippedQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShippedQty.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShippedQty.ForeColor = System.Drawing.Color.Aquamarine
        Me.txtShippedQty.Location = New System.Drawing.Point(128, 120)
        Me.txtShippedQty.Name = "txtShippedQty"
        Me.txtShippedQty.ReadOnly = True
        Me.txtShippedQty.Size = New System.Drawing.Size(48, 23)
        Me.txtShippedQty.TabIndex = 185
        Me.txtShippedQty.Text = "0"
        Me.txtShippedQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblShipQty
        '
        Me.lblShipQty.BackColor = System.Drawing.Color.Transparent
        Me.lblShipQty.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShipQty.ForeColor = System.Drawing.Color.Black
        Me.lblShipQty.Location = New System.Drawing.Point(56, 120)
        Me.lblShipQty.Name = "lblShipQty"
        Me.lblShipQty.Size = New System.Drawing.Size(72, 21)
        Me.lblShipQty.TabIndex = 186
        Me.lblShipQty.Text = "Shipped Qty"
        Me.lblShipQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tdgData0
        '
        Me.tdgData0.AllowArrows = False
        Me.tdgData0.AllowColMove = False
        Me.tdgData0.AllowColSelect = False
        Me.tdgData0.AllowFilter = False
        Me.tdgData0.AllowRowSelect = False
        Me.tdgData0.AllowSort = False
        Me.tdgData0.AllowUpdate = False
        Me.tdgData0.AlternatingRows = True
        Me.tdgData0.BackColor = System.Drawing.Color.LightSteelBlue
        Me.tdgData0.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tdgData0.Caption = "Order Header"
        Me.tdgData0.CaptionHeight = 0
        Me.tdgData0.FetchRowStyles = True
        Me.tdgData0.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Flat
        Me.tdgData0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tdgData0.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdgData0.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
        Me.tdgData0.Location = New System.Drawing.Point(8, 195)
        Me.tdgData0.Name = "tdgData0"
        Me.tdgData0.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdgData0.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdgData0.PreviewInfo.ZoomFactor = 75
        Me.tdgData0.RowSubDividerColor = System.Drawing.Color.LightBlue
        Me.tdgData0.Size = New System.Drawing.Size(680, 61)
        Me.tdgData0.TabIndex = 187
        Me.tdgData0.Text = "C1TrueDBGrid1"
        Me.tdgData0.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Al" & _
        "iceBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive{" & _
        "ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Capt" & _
        "ion{AlignHorz:Center;ForeColor:Navy;BackColor:LightSteelBlue;}Style9{}Normal{Fon" & _
        "t:Arial, 8.25pt;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style" & _
        "12{}OddRow{}RecordSelector{AlignImage:Center;}Style13{}Heading{Wrap:True;AlignVe" & _
        "rt:Center;Border:Flat,ControlDark,1, 1, 1, 1;ForeColor:ControlText;BackColor:Lig" & _
        "htSteelBlue;}Style8{}Style10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style1{}" & _
        "</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" Allo" & _
        "wColSelect=""False"" AllowRowSelect=""False"" Name="""" AlternatingRowStyle=""True"" Cap" & _
        "tionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyles=" & _
        """True"" FilterBorderStyle=""Flat"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWi" & _
        "dth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><" & _
        "Height>61</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle pare" & _
        "nt=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBa" & _
        "rStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3" & _
        """ /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=" & _
        """Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle" & _
        " parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><Rec" & _
        "ordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""S" & _
        "elected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 68" & _
        "0, 61</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C" & _
        "1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" " & _
        "/><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><S" & _
        "tyle parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><St" & _
        "yle parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style " & _
        "parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style" & _
        " parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><St" & _
        "yle parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></Name" & _
        "dStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout" & _
        "><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 680, 61</ClientAre" & _
        "a><PrintPageHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle parent=""""" & _
        " me=""Style15"" /></Blob>"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(56, 152)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 21)
        Me.Label1.TabIndex = 189
        Me.Label1.Text = "Order Qty"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtOrderQty
        '
        Me.txtOrderQty.BackColor = System.Drawing.Color.Black
        Me.txtOrderQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOrderQty.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrderQty.ForeColor = System.Drawing.Color.Aquamarine
        Me.txtOrderQty.Location = New System.Drawing.Point(128, 152)
        Me.txtOrderQty.Name = "txtOrderQty"
        Me.txtOrderQty.ReadOnly = True
        Me.txtOrderQty.Size = New System.Drawing.Size(48, 23)
        Me.txtOrderQty.TabIndex = 188
        Me.txtOrderQty.Text = "0"
        Me.txtOrderQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtOrderNo
        '
        Me.txtOrderNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrderNo.Location = New System.Drawing.Point(184, 24)
        Me.txtOrderNo.Name = "txtOrderNo"
        Me.txtOrderNo.Size = New System.Drawing.Size(296, 22)
        Me.txtOrderNo.TabIndex = 0
        Me.txtOrderNo.Text = ""
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(64, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 16)
        Me.Label2.TabIndex = 190
        Me.Label2.Text = "Ref/OrderNo:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'frmOrderReturned
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(712, 478)
        Me.ControlBox = False
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtOrderNo, Me.Label2, Me.Label1, Me.txtOrderQty, Me.tdgData0, Me.txtReturnQty, Me.lblOrderQty, Me.lblShipQty, Me.lstICCID, Me.chkBoxTrim, Me.tdgData1, Me.txtSN, Me.lblSN, Me.txtTrackingNo, Me.lblOrderID, Me.btnSetOrderReturned, Me.btnCancel, Me.txtShippedQty})
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOrderReturned"
        Me.Text = "Set Order Returned"
        CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdgData0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmOrderReturned_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            PSS.Core.Highlight.SetHighLight(Me)
            Me.chkBoxTrim.Checked = True
            Me.tdgData1.Visible = False
            Me.CenterToParent()

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "frmOrderReturned_Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            'Me.txtTrackingNo.SelectAll() : Me.txtTrackingNo.Focus()
            Me.txtOrderNo.SelectAll() : Me.txtOrderNo.Focus()
        End Try
    End Sub


    'OLD Way 
    'Private Sub txtTrackingNo_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTrackingNo.KeyUp
    '    Try
    '        If e.KeyCode = Keys.Enter AndAlso Me.txtTrackingNo.Text.Trim.Length > 0 Then

    '            Me.txtSN.SelectAll() : Me.txtSN.Focus()
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.ToString, "txtTrackingNo_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
    '    End Try
    'End Sub

    Private Sub txtTrackingNo_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTrackingNo.KeyUp
        Dim strTrackingNo As String = ""

        Try

            If e.KeyCode = Keys.Enter AndAlso Me.txtTrackingNo.Text.Trim.Length > 0 Then
                strTrackingNo = Me.txtTrackingNo.Text.Trim
                If strTrackingNo.Length > 8 And Me.chkBoxTrim.Checked Then
                    strTrackingNo = Microsoft.VisualBasic.Right(strTrackingNo, strTrackingNo.Length - 8)
                    Me.ProcessBulkOrderForTrackingNo(strTrackingNo)
                    'ElseIf strTrackingNo.Length <= 8 And Me.chkBoxTrim.Checked Then
                    '    strTrackingNo = ""
                ElseIf Not Me.chkBoxTrim.Checked Then
                    Me.ProcessBulkOrderForTrackingNo(strTrackingNo)
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtTrackingNo_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub txtOrderNo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOrderNo.KeyUp
        Dim strOrderNo As String = ""

        Try
            If e.KeyCode = Keys.Enter AndAlso Me.txtOrderNo.Text.Trim.Length > 0 Then
                strOrderNo = Me.txtOrderNo.Text.Trim
                Me.ProcessBulkOrderForOrderNo(strOrderNo)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtOrderNo_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub ProcessBulkOrderForTrackingNo(ByVal strTrackingNo As String)
        Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
        Dim iSoHeaderID As Integer = 0
        Dim iOrderQty As Integer = 0
        Dim iShippedQty As Integer = 0

        Try
            Me.txtSN.Enabled = False : Me.txtTrackingNo.Enabled = True

            Me._dtOrderHeader = Me._objTN.GetShippedBulkOrderHeaderData(Me._iMenuCustID, strTrackingNo)

            If Me._dtOrderHeader.Rows.Count = 0 Then
                MessageBox.Show("Can't find the shipped order for this tracking number: " & strTrackingNo, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtTrackingNo.SelectAll() : Me.txtTrackingNo.Focus()
            ElseIf Me._dtOrderHeader.Rows.Count > 1 Then
                MessageBox.Show("Depulicated orders are found for this tracking number: " & strTrackingNo, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtTrackingNo.SelectAll() : Me.txtTrackingNo.Focus()
            ElseIf Me._dtOrderHeader.Rows(0).IsNull("Ship Date") OrElse Trim(Me._dtOrderHeader.Rows(0).Item("Ship Date")).ToString.Length = 0 Then
                MessageBox.Show("This order is not shipped. Can't process.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtTrackingNo.SelectAll() : Me.txtTrackingNo.Focus()
            ElseIf Not Me._dtOrderHeader.Rows(0).Item("OrderReturned") = 0 Then
                MessageBox.Show("This order has been set as returned.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtTrackingNo.SelectAll() : Me.txtTrackingNo.Focus()
            Else
                With Me.tdgData0
                    .DataSource = Me._dtOrderHeader.DefaultView

                    For Each dbgc In .Splits(0).DisplayColumns
                        dbgc.Locked = True
                        dbgc.AutoSize()
                    Next dbgc

                    'Col 0 width
                    .Splits(0).DisplayColumns("OrderReturned").Width = 0
                    .Splits(0).DisplayColumns("InvalidOrder").Width = 0
                    .Splits(0).DisplayColumns("WorkOrderID").Width = 0
                    .Splits(0).DisplayColumns("SOHeaderID").Width = 0
                    .Splits(0).DisplayColumns("OrderStatusID").Width = 0
                End With
                iSoHeaderID = Me._dtOrderHeader.Rows(0).Item("SoHeaderID")

                Me._dtOrderProductDetails = Me._objTN.GetShippedBulkOrderProductDetailsData(iSoHeaderID)

                If Me._dtOrderProductDetails.Rows.Count = 0 Then
                    MessageBox.Show("Can't find the shipped product details data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtTrackingNo.SelectAll() : Me.txtTrackingNo.Focus()
                Else
                    iShippedQty = Me._dtOrderProductDetails.Rows.Count
                    iOrderQty = Me._objTN.GetBulkOrderTotalQty(iSoHeaderID)
                    With Me.tdgData1
                        .DataSource = Me._dtOrderProductDetails.DefaultView

                        For Each dbgc In .Splits(0).DisplayColumns
                            dbgc.Locked = True
                            dbgc.AutoSize()
                        Next dbgc

                        'Col 0 width
                        .Splits(0).DisplayColumns("Sku_ID").Width = 0
                        .Splits(0).DisplayColumns("SoDetailsID").Width = 0
                        .Splits(0).DisplayColumns("SoHeaderID").Width = 0
                        .Splits(0).DisplayColumns("Device_ID").Width = 0
                        .Splits(0).DisplayColumns("WI_ID").Width = 0
                        .Splits(0).DisplayColumns("insert_decode_id").Width = 0
                    End With
                    Me.tdgData0.Visible = True : Me.tdgData1.Visible = True : Me.txtTrackingNo.Enabled = False
                    Me.txtOrderQty.Text = iOrderQty : Me.txtShippedQty.Text = iShippedQty
                    Me.txtOrderQty.BackColor = Color.Black : Me.txtShippedQty.BackColor = Color.Black
                    If Not iShippedQty = iOrderQty Then
                        Me.txtOrderQty.BackColor = Color.Red : Me.txtShippedQty.BackColor = Color.Red
                        MessageBox.Show("There are discrepancy between the order qty and shipped qty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Me.txtSN.Enabled = True : Me.txtSN.SelectAll() : Me.txtSN.Focus()
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "ProcessOrderForTrackingNo", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub ProcessBulkOrderForOrderNo(ByVal strOrderNo As String)
        Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
        Dim iSoHeaderID As Integer = 0
        Dim iOrderQty As Integer = 0
        Dim iShippedQty As Integer = 0

        Try
            Me.txtSN.Enabled = False : Me.txtOrderNo.Enabled = True

            Me._dtOrderHeader = Me._objTN.GetShippedBulkOrderHeaderData(Me._iMenuCustID, "", strOrderNo)

            If Me._dtOrderHeader.Rows.Count = 0 Then
                MessageBox.Show("Can't find this order: " & strOrderNo, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.txtOrderNo.SelectAll() : Me.txtOrderNo.Focus()
            ElseIf Me._dtOrderHeader.Rows.Count > 1 Then
                MessageBox.Show("Depulicated orders are found for this order: " & strOrderNo, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.txtOrderNo.SelectAll() : Me.txtOrderNo.Focus()
            ElseIf Me._dtOrderHeader.Rows(0).IsNull("Ship Date") OrElse Trim(Me._dtOrderHeader.Rows(0).Item("Ship Date")).ToString.Length = 0 Then
                MessageBox.Show("This order is not shipped. Can't process.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.txtOrderNo.SelectAll() : Me.txtOrderNo.Focus()
            ElseIf Not Me._dtOrderHeader.Rows(0).Item("OrderReturned") = 0 Then
                MessageBox.Show("This order has been set as returned. Can't process it again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.txtOrderNo.SelectAll() : Me.txtOrderNo.Focus()
            Else
                With Me.tdgData0
                    .DataSource = Me._dtOrderHeader.DefaultView

                    For Each dbgc In .Splits(0).DisplayColumns
                        dbgc.Locked = True
                        dbgc.AutoSize()
                    Next dbgc

                    'Col 0 width
                    .Splits(0).DisplayColumns("OrderReturned").Width = 0
                    .Splits(0).DisplayColumns("InvalidOrder").Width = 0
                    .Splits(0).DisplayColumns("WorkOrderID").Width = 0
                    .Splits(0).DisplayColumns("SOHeaderID").Width = 0
                    .Splits(0).DisplayColumns("OrderStatusID").Width = 0
                End With
                iSoHeaderID = Me._dtOrderHeader.Rows(0).Item("SoHeaderID")

                Me._dtOrderProductDetails = Me._objTN.GetShippedBulkOrderProductDetailsData(iSoHeaderID)

                If Me._dtOrderProductDetails.Rows.Count = 0 Then
                    MessageBox.Show("Can't find the shipped product details data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtOrderNo.SelectAll() : Me.txtOrderNo.Focus()
                Else
                    iShippedQty = Me._dtOrderProductDetails.Rows.Count
                    iOrderQty = Me._objTN.GetBulkOrderTotalQty(iSoHeaderID)
                    With Me.tdgData1
                        .DataSource = Me._dtOrderProductDetails.DefaultView

                        For Each dbgc In .Splits(0).DisplayColumns
                            dbgc.Locked = True
                            dbgc.AutoSize()
                        Next dbgc

                        'Col 0 width
                        .Splits(0).DisplayColumns("Sku_ID").Width = 0
                        .Splits(0).DisplayColumns("SoDetailsID").Width = 0
                        .Splits(0).DisplayColumns("SoHeaderID").Width = 0
                        .Splits(0).DisplayColumns("Device_ID").Width = 0
                        .Splits(0).DisplayColumns("WI_ID").Width = 0
                        .Splits(0).DisplayColumns("insert_decode_id").Width = 0
                    End With
                    Me.tdgData0.Visible = True : Me.tdgData1.Visible = True : Me.txtOrderNo.Enabled = False
                    Me.txtOrderQty.Text = iOrderQty : Me.txtShippedQty.Text = iShippedQty
                    Me.txtOrderQty.BackColor = Color.Black : Me.txtShippedQty.BackColor = Color.Black
                    If Not iShippedQty = iOrderQty Then
                        Me.txtOrderQty.BackColor = Color.Red : Me.txtShippedQty.BackColor = Color.Red
                        MessageBox.Show("There are discrepancy between the order qty and shipped qty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Me.txtSN.Enabled = True : Me.txtSN.SelectAll() : Me.txtSN.Focus()
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "ProcessOrderForOrderNo", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub txtSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyUp
        Dim strSN As String = ""
        Dim row As DataRow
        Dim bFoundSN As Boolean = False

        Try
            If e.KeyCode = Keys.Enter AndAlso Me.txtSN.Text.Trim.Length > 0 Then
                If Me.txtReturnQty.Text > 0 AndAlso Me.lstICCID.Items.Count > 0 AndAlso Me.txtReturnQty.Text = Me.lstICCID.Items.Count _
                   AndAlso Me.txtReturnQty.Text = Me.txtShippedQty.Text Then
                    MessageBox.Show("Return card(s) are fulfilled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtSN.Text = "" : Me.txtSN.SelectAll() : Me.txtSN.Focus()
                    Exit Sub
                End If

                strSN = Me.txtSN.Text.Trim
                If Me.lstICCID.Items.Contains(strSN) Then
                    MessageBox.Show("Already scanned this card. Try another.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtSN.SelectAll() : Me.txtSN.Focus()
                    Exit Sub
                End If

                For Each row In Me._dtOrderProductDetails.Rows
                    If Trim(row("Shipped SN")).ToUpper = strSN.ToUpper Then
                        bFoundSN = True : Exit For
                    End If
                Next

                If bFoundSN Then
                    Me.lstICCID.Items.Add(strSN)
                    Me.txtReturnQty.Text = Me.lstICCID.Items.Count
                    Me.txtSN.Text = "" : Me.txtSN.SelectAll() : Me.txtSN.Focus()
                Else
                    MessageBox.Show("This card doesn't belong to this order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtSN.SelectAll() : Me.txtSN.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, " txtSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub btnSetOrderReturned_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetOrderReturned.Click
        Dim i As Integer = 0
        Dim iSoHeaderID As Integer = 0
        'Dim strTrackingNo As String = ""
        Dim strOrderNo As String = ""
        Dim strSNs As String = ""
        Dim strInput As String = ""

        Try
            If Me.txtReturnQty.Text > 0 AndAlso Me.txtShippedQty.Text > 0 AndAlso Me.txtOrderQty.Text > 0 AndAlso Me.lstICCID.Items.Count > 0 _
               AndAlso Me.txtReturnQty.Text = Me.txtShippedQty.Text AndAlso Me.txtShippedQty.Text = Me.txtOrderQty.Text _
               AndAlso Me.lstICCID.Items.Count = Me._dtOrderProductDetails.Rows.Count Then

                iSoHeaderID = Me._dtOrderHeader.Rows(0).Item("SoHeaderID")
                'strTrackingNo = Me.txtTrackingNo.Text.Trim
                strOrderNo = Me.txtOrderNo.Text.Trim
                For i = 0 To Me.lstICCID.Items.Count - 1
                    If strSNs.Trim.Length = 0 Then
                        strSNs = Me.lstICCID.Items.Item(i)
                    Else
                        strSNs &= " " & Me.lstICCID.Items.Item(i)
                    End If
                    If strSNs.Trim.Length > 100 Then Exit For
                Next
                'strInput = strTrackingNo & " " & strSNs
                strInput = strOrderNo & " " & strSNs
                If strInput.Trim.Length >= 100 Then
                    strInput = strInput.Substring(0, 95) & " ..."
                End If

                i = 0
                i = Me._objTN.UpdateOrderReturnedData(iSoHeaderID, strInput, Me._UserID, Format(Now, "yyyy-MM-dd HH:mm:ss"))
                If i > 0 Then
                    Me._dtOrderProductDetails = Nothing : Me._dtOrderHeader = Nothing
                    Me.tdgData0.DataSource = Nothing : Me.tdgData1.DataSource = Nothing
                    Me.lstICCID.Items.Clear()
                    Me.txtOrderQty.Text = 0 : Me.txtShippedQty.Text = 0 : Me.txtReturnQty.Text = 0
                    'Me.txtTrackingNo.Enabled = True : Me.txtTrackingNo.Text = "" : Me.txtSN.Text = ""
                    Me.txtOrderNo.Enabled = True : Me.txtOrderNo.Text = "" : Me.txtSN.Text = ""
                    MessageBox.Show("Successfully updated!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                Else
                    MessageBox.Show("Failed to update! Try again", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    'Me.txtTrackingNo.SelectAll() : Me.txtTrackingNo.Focus()
                    Me.txtOrderNo.SelectAll() : Me.txtOrderNo.Focus()
                End If
            Else
                MessageBox.Show("Not ready. Can't process it.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.txtSN.SelectAll() : Me.txtSN.Focus()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, " btnSetOrderReturned_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub btnSetOrderReturned_Click_OldWay(ByVal sender As System.Object, ByVal e As System.EventArgs) ' Handles btnSetOrderReturned.Click
        Dim strTrackingNo As String = ""
        Dim strSN As String = ""
        Dim dtOrder, dtSN As DataTable
        Dim iSoDetailsID As Integer = 0
        Dim strMsg As String = ""
        Dim i As Integer = 0
        Dim iSoHeaderID As Integer = 0

        Try
            strTrackingNo = Me.txtTrackingNo.Text.Trim
            If strTrackingNo.Length > 8 And Me.chkBoxTrim.Checked Then
                strTrackingNo = Microsoft.VisualBasic.Right(strTrackingNo, strTrackingNo.Length - 8)
            ElseIf strTrackingNo.Length <= 8 And Me.chkBoxTrim.Checked Then
                strTrackingNo = ""
            End If
            'MessageBox.Show("Enter the tracking number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            'Exit Sub

            strSN = Me.txtSN.Text.Trim

            If Not strTrackingNo.Length > 0 Then
                MessageBox.Show("Enter the tracking number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtTrackingNo.SelectAll() : Me.txtTrackingNo.Focus()
            ElseIf Not strSN.Length > 0 Then
                MessageBox.Show("Enter SN (ICCID).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtSN.SelectAll() : Me.txtSN.Focus()
            Else
                dtOrder = Me._objTN.GetSaleOrderData(Me._iMenuCustID, strTrackingNo)

                If Not dtOrder.Rows.Count > 0 Then
                    MessageBox.Show("Can't find the tracking number: " & strTrackingNo, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtTrackingNo.SelectAll() : Me.txtTrackingNo.Focus()
                ElseIf dtOrder.Rows.Count > 1 Then
                    MessageBox.Show("Duplicated tracking number: " & strTrackingNo, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtTrackingNo.SelectAll() : Me.txtTrackingNo.Focus()
                ElseIf dtOrder.Rows(0).IsNull("ShipDate") OrElse Trim(dtOrder.Rows(0).Item("ShipDate")).ToString.Length = 0 Then   '=1
                    MessageBox.Show("This order is not shipped. Can't process.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtTrackingNo.SelectAll() : Me.txtTrackingNo.Focus()
                ElseIf Not dtOrder.Rows(0).Item("OrderReturned") = 0 Then
                    MessageBox.Show("This order has been set as returned.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtTrackingNo.SelectAll() : Me.txtTrackingNo.Focus()
                Else 'ok
                    iSoDetailsID = dtOrder.Rows(0).Item("SoDetailsID")
                    iSoHeaderID = dtOrder.Rows(0).Item("SoHeaderID")
                    dtSN = Me._objTN.GetSaleOrderSN(iSoDetailsID)

                    If Not dtSN.Rows.Count > 0 Then
                        MessageBox.Show("Can't find SN (ICCID) or not shipped.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtSN.SelectAll() : Me.txtSN.Focus()
                    ElseIf dtSN.Rows.Count > 1 Then
                        MessageBox.Show("Duplicated SN (ICCID).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtSN.SelectAll() : Me.txtSN.Focus()
                    ElseIf dtSN.Rows(0).IsNull("Serial") AndAlso Trim(dtSN.Rows(0).Item("Serial")).ToString.Length = 0 Then '=1
                        MessageBox.Show("No SN (ICCID).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtSN.SelectAll() : Me.txtSN.Focus()
                    Else ' check match
                        If Not strSN.ToUpper = Trim(dtSN.Rows(0).Item("Serial")).ToString.ToUpper Then
                            MessageBox.Show("No matched SN (ICCID). The system shows the shipped SN (ICCID) for this order is '" & Trim(dtSN.Rows(0).Item("Serial")).ToString & "'", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtSN.SelectAll() : Me.txtSN.Focus()
                        Else 'ready to update
                            i = Me._objTN.UpdateOrderReturnedData(iSoHeaderID, strTrackingNo & " " & strSN, Me._UserID, Format(Now, "yyyy-MM-dd HH:mm:ss"))
                            If i > 0 Then
                                Me.txtTrackingNo.Text = "" : Me.txtSN.Text = ""
                                MessageBox.Show("Successfully updated!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                'Me.DialogResult = Windows.Forms.DialogResult.Yes
                                Me.Close()
                            Else
                                MessageBox.Show("Failed to update! Try again", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.txtTrackingNo.SelectAll() : Me.txtTrackingNo.Focus()
                            End If
                        End If
                    End If
                End If
            End If

            'Dim strOrderID As String = ""
            'Dim strSN As String = ""
            'Dim dtOrder, dtSN As DataTable
            'Dim iSoDetailsID As Integer = 0
            'Dim strMsg As String = ""
            'Dim i As Integer = 0

            'Try
            '    strOrderID = Me.txtOrderID.Text.Trim
            '    strSN = Me.txtSN.Text.Trim

            '    If Not strOrderID.Length > 0 Then
            '        MessageBox.Show("Enter order ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '        Me.txtOrderID.SelectAll() : Me.txtOrderID.Focus()
            '    ElseIf Not strSN.Length > 0 Then
            '        MessageBox.Show("Enter SN (ICCID).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '        Me.txtSN.SelectAll() : Me.txtSN.Focus()
            '    Else
            '        dtOrder = Me._objTN.GetSaleOrderData(Me._iMenuCustID, strOrderID)

            '        If Not dtOrder.Rows.Count > 0 Then
            '            MessageBox.Show("Can't find the order ID: " & strOrderID, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '            Me.txtOrderID.SelectAll() : Me.txtOrderID.Focus()
            '        ElseIf dtOrder.Rows.Count > 1 Then
            '            MessageBox.Show("Duplicated order ID: " & strOrderID, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '            Me.txtOrderID.SelectAll() : Me.txtOrderID.Focus()
            '        ElseIf dtOrder.Rows(0).IsNull("ShipDate") OrElse Trim(dtOrder.Rows(0).Item("ShipDate")).ToString.Length = 0 Then   '=1
            '            MessageBox.Show("This order is not shipped.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '            Me.txtOrderID.SelectAll() : Me.txtOrderID.Focus()
            '        ElseIf Not dtOrder.Rows(0).Item("OrderReturned") = 0 Then
            '            MessageBox.Show("This order has been set as returned.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '            Me.txtOrderID.SelectAll() : Me.txtOrderID.Focus()
            '        Else 'ok
            '            iSoDetailsID = dtOrder.Rows(0).Item("SoDetailsID")
            '            dtSN = Me._objTN.GetSaleOrderSN(iSoDetailsID)

            '            If Not dtSN.Rows.Count > 0 Then
            '                MessageBox.Show("Can't find SN (ICCID) or not shipped.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '                Me.txtSN.SelectAll() : Me.txtSN.Focus()
            '            ElseIf dtSN.Rows.Count > 1 Then
            '                MessageBox.Show("Duplicated SN (ICCID).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '                Me.txtSN.SelectAll() : Me.txtSN.Focus()
            '            ElseIf dtSN.Rows(0).IsNull("Serial") AndAlso Trim(dtSN.Rows(0).Item("Serial")).ToString.Length = 0 Then '=1
            '                MessageBox.Show("No SN (ICCID).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '                Me.txtSN.SelectAll() : Me.txtSN.Focus()
            '            Else ' check match
            '                If Not strSN.ToUpper = Trim(dtSN.Rows(0).Item("Serial")).ToString.ToUpper Then
            '                    MessageBox.Show("No matched SN (ICCID). The system shows the shipped SN (ICCID) for this order is '" & Trim(dtSN.Rows(0).Item("Serial")).ToString & "'", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '                    Me.txtSN.SelectAll() : Me.txtSN.Focus()
            '                Else 'ready to update
            '                    i = Me._objTN.UpdateOrderReturnedData(dtOrder.Rows(0).Item("SoHeaderID"), strOrderID & " " & strSN, Me._UserID, Format(Now, "yyyy-MM-dd HH:mm:ss"))
            '                    If i > 0 Then
            '                        Me.txtOrderID.Text = "" : Me.txtSN.Text = ""
            '                        MessageBox.Show("Successfully updated!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '                        'Me.DialogResult = Windows.Forms.DialogResult.Yes
            '                        Me.Close()
            '                    Else
            '                        MessageBox.Show("Failed to update! Try again", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '                        Me.txtOrderID.SelectAll() : Me.txtOrderID.Focus()
            '                    End If
            '                End If
            '            End If
            '        End If
            '   End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnSetOrderReturned_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Try
            'Me.txtTrackingNo.Text = "" : Me.txtSN.Text = ""
            Me.txtOrderNo.Text = "" : Me.txtSN.Text = ""
            'Me.Hide()' 
            ' Me.Close()
            ' Me.DialogResult = Windows.Forms.DialogResult.No
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnCancel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub


    'Private Sub frmOrderReturned_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
    '    If Not Me.DialogResult = Windows.Forms.DialogResult.Yes Then
    '        e.Cancel = False
    '    Else
    '        e.Cancel = True
    '    End If
    'End Sub



End Class
