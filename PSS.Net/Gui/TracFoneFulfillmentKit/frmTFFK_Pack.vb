Option Explicit On 

Imports PSS.Data.Buisness
Imports System.Text
Imports PSS.Data.Buisness.Security
Imports PSS.Core.Global
Imports System.IO

Namespace Gui.TracFoneFulfillmentKit

    Public Class frmTFFK_Pack
        Inherits System.Windows.Forms.Form

        Private _dtPackData As DataTable
        Private _dtScanSNs As DataTable
        'Private _dtOrderModelItemsQty As DataTable

        Private _dtValidateSNs As DataTable
        Private _dtPackSN As DataTable


        Private _strTracking As String
        Private _dtItems As DataTable
        Private _strOrderNo As String = ""
        Private _iOrderTypeID As Integer = 0
        Private _iShipID As Integer = 0
        Private _iSoHeaderID As Integer = 0
        Private _palletQty As Integer = 0
        Private _weight As Integer = 0
        Private _deviceQty As Integer = 0
        Private _iSelectedRowID As Integer = 0
        Private _iDefaultTrackingLength As Integer = 12
        Private _strSelectedTrackNo As String = ""

        Private _objPack As PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK_Pack
        Private _objPickPackShip As PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK_PickPackShip
        Private _BaseClass As PSS.Data.BaseClasses.CollectTrackingLog

        Private _UserID As Integer = PSS.Core.Global.ApplicationUser.IDuser
        Private _strEmpID As String = PSS.Core.Global.ApplicationUser.NumberEmp
        Private _strUser As String = PSS.Core.Global.ApplicationUser.User
        Private _strComputerName As String = ""


#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._objPack = New PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK_Pack()
            Me._objPickPackShip = New PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK_PickPackShip()
            Me._BaseClass = New PSS.Data.BaseClasses.CollectTrackingLog()

            Me._strComputerName = Me._BaseClass.GetComputerName
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                Try
                    Me._objPack = Nothing
                    Me._objPickPackShip = Nothing
                    Me._BaseClass = Nothing
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
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents btnComplete As System.Windows.Forms.Button
        Friend WithEvents txtPackStation As System.Windows.Forms.TextBox
        Friend WithEvents txtPacker As System.Windows.Forms.TextBox
        Friend WithEvents txtOrderNo As System.Windows.Forms.TextBox
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents txtScan As System.Windows.Forms.TextBox
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents lstScan As System.Windows.Forms.ListBox
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents txtCustomer As System.Windows.Forms.TextBox
        Friend WithEvents txtCustomerNo As System.Windows.Forms.TextBox
        Friend WithEvents tdgData1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents btnDelOne As System.Windows.Forms.Button
        Friend WithEvents btnDelAll As System.Windows.Forms.Button
        Friend WithEvents btnReprint As System.Windows.Forms.Button
        Friend WithEvents txtPSSINo As System.Windows.Forms.TextBox
        Friend WithEvents lblTN As System.Windows.Forms.Label
        Friend WithEvents txtPickRun As System.Windows.Forms.TextBox
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents lblPSSINo As System.Windows.Forms.Label
        Friend WithEvents btnOverride As System.Windows.Forms.Button
        Friend WithEvents pnlBox As System.Windows.Forms.Panel
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents txtSelectedBox As System.Windows.Forms.TextBox
        Friend WithEvents txtTracking As System.Windows.Forms.TextBox
        Friend WithEvents lblRow As System.Windows.Forms.Label
        Friend WithEvents lbllbltrack1 As System.Windows.Forms.Label
        Friend WithEvents lbllblTrack2 As System.Windows.Forms.Label
        Friend WithEvents txtHowManyLastDigits As System.Windows.Forms.TextBox
        Friend WithEvents btnProcessBox As System.Windows.Forms.Button
        Friend WithEvents lbllblRow As System.Windows.Forms.Label
        Friend WithEvents txtOrderQty As System.Windows.Forms.TextBox
        Friend WithEvents txtShipQty As System.Windows.Forms.TextBox
        Friend WithEvents btnCopy2Clipboard As System.Windows.Forms.Button
        Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTFFK_Pack))
            Me.Label4 = New System.Windows.Forms.Label()
            Me.txtPackStation = New System.Windows.Forms.TextBox()
            Me.btnComplete = New System.Windows.Forms.Button()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtPacker = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.txtOrderNo = New System.Windows.Forms.TextBox()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.txtShipQty = New System.Windows.Forms.TextBox()
            Me.txtOrderQty = New System.Windows.Forms.TextBox()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.txtScan = New System.Windows.Forms.TextBox()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.lstScan = New System.Windows.Forms.ListBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.txtCustomer = New System.Windows.Forms.TextBox()
            Me.txtCustomerNo = New System.Windows.Forms.TextBox()
            Me.tdgData1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.btnDelOne = New System.Windows.Forms.Button()
            Me.btnDelAll = New System.Windows.Forms.Button()
            Me.btnReprint = New System.Windows.Forms.Button()
            Me.lblPSSINo = New System.Windows.Forms.Label()
            Me.txtPSSINo = New System.Windows.Forms.TextBox()
            Me.lblTN = New System.Windows.Forms.Label()
            Me.txtPickRun = New System.Windows.Forms.TextBox()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.btnOverride = New System.Windows.Forms.Button()
            Me.pnlBox = New System.Windows.Forms.Panel()
            Me.btnProcessBox = New System.Windows.Forms.Button()
            Me.txtHowManyLastDigits = New System.Windows.Forms.TextBox()
            Me.lbllblTrack2 = New System.Windows.Forms.Label()
            Me.lbllbltrack1 = New System.Windows.Forms.Label()
            Me.txtTracking = New System.Windows.Forms.TextBox()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.txtSelectedBox = New System.Windows.Forms.TextBox()
            Me.lblRow = New System.Windows.Forms.Label()
            Me.lbllblRow = New System.Windows.Forms.Label()
            Me.btnCopy2Clipboard = New System.Windows.Forms.Button()
            Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlBox.SuspendLayout()
            Me.SuspendLayout()
            '
            'Label4
            '
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.Label4.Location = New System.Drawing.Point(8, 32)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(112, 23)
            Me.Label4.TabIndex = 169
            Me.Label4.Text = "Pack Station:"
            '
            'txtPackStation
            '
            Me.txtPackStation.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPackStation.Location = New System.Drawing.Point(128, 32)
            Me.txtPackStation.Name = "txtPackStation"
            Me.txtPackStation.ReadOnly = True
            Me.txtPackStation.Size = New System.Drawing.Size(168, 26)
            Me.txtPackStation.TabIndex = 168
            Me.txtPackStation.TabStop = False
            Me.txtPackStation.Text = ""
            '
            'btnComplete
            '
            Me.btnComplete.BackColor = System.Drawing.Color.Green
            Me.btnComplete.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnComplete.ForeColor = System.Drawing.Color.White
            Me.btnComplete.Location = New System.Drawing.Point(760, 232)
            Me.btnComplete.Name = "btnComplete"
            Me.btnComplete.Size = New System.Drawing.Size(96, 48)
            Me.btnComplete.TabIndex = 167
            Me.btnComplete.Text = "Complete"
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.Label1.Location = New System.Drawing.Point(376, 0)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(64, 23)
            Me.Label1.TabIndex = 173
            Me.Label1.Text = "Packer:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'txtPacker
            '
            Me.txtPacker.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPacker.Location = New System.Drawing.Point(440, 0)
            Me.txtPacker.Name = "txtPacker"
            Me.txtPacker.ReadOnly = True
            Me.txtPacker.Size = New System.Drawing.Size(120, 26)
            Me.txtPacker.TabIndex = 172
            Me.txtPacker.TabStop = False
            Me.txtPacker.Text = ""
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(120, 32)
            Me.Label2.TabIndex = 174
            Me.Label2.Text = "Packing"
            '
            'Label3
            '
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.Label3.Location = New System.Drawing.Point(8, 64)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(112, 23)
            Me.Label3.TabIndex = 176
            Me.Label3.Text = "Pick Run #:"
            '
            'Label5
            '
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.Label5.Location = New System.Drawing.Point(8, 96)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(104, 23)
            Me.Label5.TabIndex = 178
            Me.Label5.Text = "Order #:"
            '
            'txtOrderNo
            '
            Me.txtOrderNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtOrderNo.Location = New System.Drawing.Point(128, 96)
            Me.txtOrderNo.Name = "txtOrderNo"
            Me.txtOrderNo.ReadOnly = True
            Me.txtOrderNo.Size = New System.Drawing.Size(168, 26)
            Me.txtOrderNo.TabIndex = 177
            Me.txtOrderNo.Text = ""
            '
            'Label7
            '
            Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.Label7.Location = New System.Drawing.Point(272, 176)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(56, 23)
            Me.Label7.TabIndex = 181
            Me.Label7.Text = "Ship Qty"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'txtShipQty
            '
            Me.txtShipQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtShipQty.Location = New System.Drawing.Point(336, 176)
            Me.txtShipQty.Name = "txtShipQty"
            Me.txtShipQty.ReadOnly = True
            Me.txtShipQty.Size = New System.Drawing.Size(48, 22)
            Me.txtShipQty.TabIndex = 180
            Me.txtShipQty.Text = "0"
            Me.txtShipQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'txtOrderQty
            '
            Me.txtOrderQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtOrderQty.Location = New System.Drawing.Point(216, 176)
            Me.txtOrderQty.Name = "txtOrderQty"
            Me.txtOrderQty.ReadOnly = True
            Me.txtOrderQty.Size = New System.Drawing.Size(48, 22)
            Me.txtOrderQty.TabIndex = 182
            Me.txtOrderQty.Text = "0"
            Me.txtOrderQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'Label8
            '
            Me.Label8.BackColor = System.Drawing.Color.SteelBlue
            Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.Label8.Location = New System.Drawing.Point(144, 176)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(64, 23)
            Me.Label8.TabIndex = 183
            Me.Label8.Text = "Order Qty"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'txtScan
            '
            Me.txtScan.BackColor = System.Drawing.Color.White
            Me.txtScan.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtScan.Location = New System.Drawing.Point(552, 200)
            Me.txtScan.Name = "txtScan"
            Me.txtScan.Size = New System.Drawing.Size(168, 26)
            Me.txtScan.TabIndex = 184
            Me.txtScan.Text = ""
            '
            'Label9
            '
            Me.Label9.BackColor = System.Drawing.Color.SteelBlue
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.Label9.Location = New System.Drawing.Point(552, 181)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(80, 23)
            Me.Label9.TabIndex = 185
            Me.Label9.Text = "IMEI Scan:"
            '
            'lstScan
            '
            Me.lstScan.Location = New System.Drawing.Point(552, 224)
            Me.lstScan.Name = "lstScan"
            Me.lstScan.Size = New System.Drawing.Size(168, 329)
            Me.lstScan.TabIndex = 186
            '
            'Label10
            '
            Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.Label10.Location = New System.Drawing.Point(360, 32)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(80, 23)
            Me.Label10.TabIndex = 187
            Me.Label10.Text = "Customer:"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'Label11
            '
            Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label11.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.Label11.Location = New System.Drawing.Point(560, 0)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(96, 23)
            Me.Label11.TabIndex = 188
            Me.Label11.Text = "Customer #:"
            Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'txtCustomer
            '
            Me.txtCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtCustomer.Location = New System.Drawing.Point(440, 32)
            Me.txtCustomer.Name = "txtCustomer"
            Me.txtCustomer.ReadOnly = True
            Me.txtCustomer.Size = New System.Drawing.Size(296, 26)
            Me.txtCustomer.TabIndex = 190
            Me.txtCustomer.Text = ""
            '
            'txtCustomerNo
            '
            Me.txtCustomerNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtCustomerNo.Location = New System.Drawing.Point(656, 0)
            Me.txtCustomerNo.Name = "txtCustomerNo"
            Me.txtCustomerNo.ReadOnly = True
            Me.txtCustomerNo.Size = New System.Drawing.Size(80, 26)
            Me.txtCustomerNo.TabIndex = 191
            Me.txtCustomerNo.Text = ""
            '
            'tdgData1
            '
            Me.tdgData1.AllowColSelect = False
            Me.tdgData1.AllowFilter = False
            Me.tdgData1.AllowSort = False
            Me.tdgData1.AlternatingRows = True
            Me.tdgData1.BackColor = System.Drawing.Color.GhostWhite
            Me.tdgData1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tdgData1.CaptionHeight = 17
            Me.tdgData1.FetchRowStyles = True
            Me.tdgData1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgData1.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgData1.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.tdgData1.Location = New System.Drawing.Point(8, 200)
            Me.tdgData1.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Simple
            Me.tdgData1.Name = "tdgData1"
            Me.tdgData1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgData1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgData1.PreviewInfo.ZoomFactor = 75
            Me.tdgData1.RowHeight = 20
            Me.tdgData1.Size = New System.Drawing.Size(536, 360)
            Me.tdgData1.TabIndex = 192
            Me.tdgData1.Text = "C1TrueDBGrid1"
            Me.tdgData1.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Style1{}Normal{Font:Microsoft Sans Serif, 9.75pt;}Highlig" & _
            "htRow{ForeColor:HighlightText;BackColor:Highlight;}Style14{}OddRow{}RecordSelect" & _
            "or{AlignImage:Center;}Style15{}Heading{Wrap:True;BackColor:Control;Border:Raised" & _
            ",,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}Style10{AlignHorz:N" & _
            "ear;}Style11{}Style12{}Style13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDB" & _
            "Grid.MergeView AllowColSelect=""False"" Name="""" AlternatingRowStyle=""True"" Caption" & _
            "Height=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyles=""Tru" & _
            "e"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" " & _
            "VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>358</Height><CaptionSt" & _
            "yle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><E" & _
            "venRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me" & _
            "=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Grou" & _
            "p"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyl" & _
            "e parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style" & _
            "4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""Rec" & _
            "ordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Styl" & _
            "e parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 534, 358</ClientRect><BorderSi" & _
            "de>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeVie" & _
            "w></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me" & _
            "=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""C" & _
            "aption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Sel" & _
            "ected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""Highlig" & _
            "htRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow" & _
            """ /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""Fil" & _
            "terBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vert" & _
            "Splits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</De" & _
            "faultRecSelWidth><ClientArea>0, 0, 534, 358</ClientArea><PrintPageHeaderStyle pa" & _
            "rent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'Label6
            '
            Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.Label6.Location = New System.Drawing.Point(8, 182)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(128, 20)
            Me.Label6.TabIndex = 193
            Me.Label6.Text = "List of Order Details"
            '
            'btnDelOne
            '
            Me.btnDelOne.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnDelOne.ForeColor = System.Drawing.Color.White
            Me.btnDelOne.Location = New System.Drawing.Point(760, 320)
            Me.btnDelOne.Name = "btnDelOne"
            Me.btnDelOne.Size = New System.Drawing.Size(96, 40)
            Me.btnDelOne.TabIndex = 194
            Me.btnDelOne.Text = "Remove One"
            Me.btnDelOne.Visible = False
            '
            'btnDelAll
            '
            Me.btnDelAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnDelAll.ForeColor = System.Drawing.Color.White
            Me.btnDelAll.Location = New System.Drawing.Point(760, 368)
            Me.btnDelAll.Name = "btnDelAll"
            Me.btnDelAll.Size = New System.Drawing.Size(96, 40)
            Me.btnDelAll.TabIndex = 195
            Me.btnDelAll.Text = "Remove All"
            Me.btnDelAll.Visible = False
            '
            'btnReprint
            '
            Me.btnReprint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprint.ForeColor = System.Drawing.Color.White
            Me.btnReprint.Location = New System.Drawing.Point(760, 416)
            Me.btnReprint.Name = "btnReprint"
            Me.btnReprint.Size = New System.Drawing.Size(96, 40)
            Me.btnReprint.TabIndex = 196
            Me.btnReprint.Text = "Reprint Packing List"
            Me.btnReprint.Visible = False
            '
            'lblPSSINo
            '
            Me.lblPSSINo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPSSINo.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.lblPSSINo.Location = New System.Drawing.Point(8, 128)
            Me.lblPSSINo.Name = "lblPSSINo"
            Me.lblPSSINo.Size = New System.Drawing.Size(112, 23)
            Me.lblPSSINo.TabIndex = 198
            Me.lblPSSINo.Text = "PSSI Box #:"
            '
            'txtPSSINo
            '
            Me.txtPSSINo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPSSINo.Location = New System.Drawing.Point(128, 128)
            Me.txtPSSINo.Name = "txtPSSINo"
            Me.txtPSSINo.Size = New System.Drawing.Size(168, 26)
            Me.txtPSSINo.TabIndex = 1
            Me.txtPSSINo.Text = ""
            '
            'lblTN
            '
            Me.lblTN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTN.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.lblTN.Location = New System.Drawing.Point(8, 48)
            Me.lblTN.Name = "lblTN"
            Me.lblTN.Size = New System.Drawing.Size(136, 23)
            Me.lblTN.TabIndex = 200
            Me.lblTN.Text = "Scan Tracking #:"
            Me.lblTN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblTN.Visible = False
            '
            'txtPickRun
            '
            Me.txtPickRun.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPickRun.Location = New System.Drawing.Point(128, 64)
            Me.txtPickRun.Name = "txtPickRun"
            Me.txtPickRun.ReadOnly = True
            Me.txtPickRun.Size = New System.Drawing.Size(168, 26)
            Me.txtPickRun.TabIndex = 201
            Me.txtPickRun.TabStop = False
            Me.txtPickRun.Text = ""
            '
            'btnClear
            '
            Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClear.ForeColor = System.Drawing.Color.White
            Me.btnClear.Location = New System.Drawing.Point(760, 464)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(96, 40)
            Me.btnClear.TabIndex = 202
            Me.btnClear.Text = "Clear"
            '
            'btnOverride
            '
            Me.btnOverride.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnOverride.ForeColor = System.Drawing.Color.White
            Me.btnOverride.Location = New System.Drawing.Point(824, 24)
            Me.btnOverride.Name = "btnOverride"
            Me.btnOverride.Size = New System.Drawing.Size(32, 40)
            Me.btnOverride.TabIndex = 203
            Me.btnOverride.Text = "Tracking Override"
            Me.btnOverride.Visible = False
            '
            'pnlBox
            '
            Me.pnlBox.BackColor = System.Drawing.Color.SteelBlue
            Me.pnlBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnlBox.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnProcessBox, Me.txtHowManyLastDigits, Me.lbllblTrack2, Me.lbllbltrack1, Me.txtTracking, Me.Label12, Me.txtSelectedBox, Me.lblTN, Me.lblRow, Me.lbllblRow})
            Me.pnlBox.Location = New System.Drawing.Point(360, 64)
            Me.pnlBox.Name = "pnlBox"
            Me.pnlBox.Size = New System.Drawing.Size(384, 104)
            Me.pnlBox.TabIndex = 204
            '
            'btnProcessBox
            '
            Me.btnProcessBox.ForeColor = System.Drawing.Color.White
            Me.btnProcessBox.Location = New System.Drawing.Point(313, 24)
            Me.btnProcessBox.Name = "btnProcessBox"
            Me.btnProcessBox.Size = New System.Drawing.Size(48, 48)
            Me.btnProcessBox.TabIndex = 209
            Me.btnProcessBox.Text = "OK"
            '
            'txtHowManyLastDigits
            '
            Me.txtHowManyLastDigits.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtHowManyLastDigits.Location = New System.Drawing.Point(176, 72)
            Me.txtHowManyLastDigits.Name = "txtHowManyLastDigits"
            Me.txtHowManyLastDigits.Size = New System.Drawing.Size(20, 22)
            Me.txtHowManyLastDigits.TabIndex = 208
            Me.txtHowManyLastDigits.Text = ""
            '
            'lbllblTrack2
            '
            Me.lbllblTrack2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbllblTrack2.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.lbllblTrack2.Location = New System.Drawing.Point(200, 72)
            Me.lbllblTrack2.Name = "lbllblTrack2"
            Me.lbllblTrack2.Size = New System.Drawing.Size(40, 23)
            Me.lbllblTrack2.TabIndex = 207
            Me.lbllblTrack2.Text = "digits"
            Me.lbllblTrack2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lbllbltrack1
            '
            Me.lbllbltrack1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbllbltrack1.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.lbllbltrack1.Location = New System.Drawing.Point(144, 72)
            Me.lbllbltrack1.Name = "lbllbltrack1"
            Me.lbllbltrack1.Size = New System.Drawing.Size(32, 23)
            Me.lbllbltrack1.TabIndex = 206
            Me.lbllbltrack1.Text = "Last"
            Me.lbllbltrack1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtTracking
            '
            Me.txtTracking.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtTracking.Location = New System.Drawing.Point(144, 48)
            Me.txtTracking.Name = "txtTracking"
            Me.txtTracking.Size = New System.Drawing.Size(168, 22)
            Me.txtTracking.TabIndex = 203
            Me.txtTracking.Text = ""
            '
            'Label12
            '
            Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label12.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.Label12.Location = New System.Drawing.Point(32, 24)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(112, 23)
            Me.Label12.TabIndex = 202
            Me.Label12.Text = "PSSI Box #:"
            Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtSelectedBox
            '
            Me.txtSelectedBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtSelectedBox.Location = New System.Drawing.Point(144, 24)
            Me.txtSelectedBox.Name = "txtSelectedBox"
            Me.txtSelectedBox.Size = New System.Drawing.Size(168, 26)
            Me.txtSelectedBox.TabIndex = 201
            Me.txtSelectedBox.Text = ""
            '
            'lblRow
            '
            Me.lblRow.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRow.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.lblRow.Location = New System.Drawing.Point(176, 2)
            Me.lblRow.Name = "lblRow"
            Me.lblRow.Size = New System.Drawing.Size(32, 23)
            Me.lblRow.TabIndex = 205
            Me.lblRow.Text = "0"
            Me.lblRow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lbllblRow
            '
            Me.lbllblRow.BackColor = System.Drawing.Color.SteelBlue
            Me.lbllblRow.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbllblRow.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.lbllblRow.Location = New System.Drawing.Point(138, 2)
            Me.lbllblRow.Name = "lbllblRow"
            Me.lbllblRow.Size = New System.Drawing.Size(32, 23)
            Me.lbllblRow.TabIndex = 204
            Me.lbllblRow.Text = "Row"
            Me.lbllblRow.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnCopy2Clipboard
            '
            Me.btnCopy2Clipboard.BackColor = System.Drawing.SystemColors.Control
            Me.btnCopy2Clipboard.Image = CType(resources.GetObject("btnCopy2Clipboard.Image"), System.Drawing.Bitmap)
            Me.btnCopy2Clipboard.Location = New System.Drawing.Point(720, 224)
            Me.btnCopy2Clipboard.Name = "btnCopy2Clipboard"
            Me.btnCopy2Clipboard.Size = New System.Drawing.Size(25, 22)
            Me.btnCopy2Clipboard.TabIndex = 205
            Me.ToolTip1.SetToolTip(Me.btnCopy2Clipboard, "Copy filled SN data to clipboard")
            '
            'frmTFFK_Pack
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(880, 582)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCopy2Clipboard, Me.pnlBox, Me.btnOverride, Me.btnClear, Me.txtPickRun, Me.lblPSSINo, Me.txtPSSINo, Me.btnReprint, Me.btnDelAll, Me.btnDelOne, Me.tdgData1, Me.txtCustomerNo, Me.txtCustomer, Me.Label11, Me.Label10, Me.lstScan, Me.txtScan, Me.Label8, Me.txtOrderQty, Me.Label7, Me.txtShipQty, Me.Label5, Me.txtOrderNo, Me.Label3, Me.Label2, Me.Label1, Me.txtPacker, Me.Label4, Me.txtPackStation, Me.btnComplete, Me.Label6, Me.Label9})
            Me.Name = "frmTFFK_Pack"
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlBox.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmTFFK_Pack_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                PSS.Core.Highlight.SetHighLight(Me)
                ClearUI()
                Me.tdgData1.FetchRowStyles = True

                If Me._strComputerName.Trim.Length > 0 Then
                    Me.txtPackStation.Text = Me._strComputerName
                    Me.txtPacker.Text = Trim(ApplicationUser.User)

                    'Datatable for storing the scanned SNs
                    Me._dtScanSNs = Me._objPack.getScanSNsDataTableDef

                    'define device table
                    'Me._dtScanSNs = New DataTable()
                    'PSS.Data.Buisness.Generic.AddNewColumnToDataTable(Me._dtScanSNs, "SN", "System.String", "")
                    'PSS.Data.Buisness.Generic.AddNewColumnToDataTable(Me._dtScanSNs, "WI_ID", "System.Int64", "0")
                    'PSS.Data.Buisness.Generic.AddNewColumnToDataTable(Me._dtScanSNs, "Device_ID", "System.Int64", "0")
                    'PSS.Data.Buisness.Generic.AddNewColumnToDataTable(Me._dtScanSNs, "PartNum", "System.String", "")
                    'PSS.Data.Buisness.Generic.AddNewColumnToDataTable(Me._dtScanSNs, "SoDetailsID", "System.Int64", "0")


                    Me.txtPSSINo.Focus()

                Else
                    MessageBox.Show("Computer name is not defined. See IT.", "frmTFFK_Pack_Load", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, " frmTFFK_Pack_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub ClearUI()
            If Not IsNothing(Me._dtPackData) Then
                _dtPackData.Clear()
            End If
            If Not IsNothing(_dtPackSN) Then
                _dtPackSN.Clear()
            End If
            If Not IsNothing(_dtScanSNs) Then
                _dtScanSNs.Clear()
            End If
            Me.tdgData1.DataSource = Nothing

            Me.pnlBox.Visible = False
            Me.btnComplete.Enabled = False

            Me.txtScan.Text = String.Empty
            Me.txtScan.Enabled = False
            Me.txtOrderQty.Text = 0
            Me.txtOrderQty.ReadOnly = True
            Me.txtShipQty.Text = 0
            Me.txtShipQty.ReadOnly = True
            Me.txtPickRun.Text = String.Empty
            Me.txtPickRun.ReadOnly = True
            Me.txtCustomer.Text = String.Empty
            Me.txtCustomer.ReadOnly = True
            Me.txtCustomerNo.Text = String.Empty
            Me.txtCustomerNo.ReadOnly = True
            Me.txtOrderNo.Text = String.Empty
            Me.txtOrderNo.ReadOnly = True

            Me.txtPSSINo.Text = String.Empty
            Me.txtPSSINo.ReadOnly = False
            Me.txtPSSINo.Enabled = True

        End Sub

        Private Sub RestartUI()
            'If Not IsNothing(Me._dtPackData) Then
            '    _dtPackData.Clear()
            'End If
            'If Not IsNothing(_dtPackSN) Then
            '    _dtPackSN.Clear()
            'End If
            'If Not IsNothing(_dtScanSNs) Then
            '    _dtScanSNs.Clear()
            'End If
            'Me.tdgData1.Refresh()
            'Me.txtScan.Text = String.Empty
            'Me.txtScan.ReadOnly = True
            ''Me.lstScan.Items.Clear()
            'Me.lblTN.Visible = False
            'Me.txtTracking.Visible = False
            'Me.txtTracking.Text = String.Empty
            'Me.txtTotal.Text = 0
            'Me.txtPackStation.Text = String.Empty
            'Me.txtPacker.Text = String.Empty
            'Me.txtPSSINo.Text = String.Empty
            'Me.txtOrderNo.Text = String.Empty
            'Me.txtCustomerNo.Text = String.Empty
            'Me.txtPickRun.Text = String.Empty
            'Me.txtCustomer.Text = String.Empty
            'Me.txtCustomerNo.Text = String.Empty
            'Me.txtQty.Text = String.Empty
            ''Me.txtScan.ReadOnly = True
            'Me.txtScan.Text = String.Empty
            'Me.btnComplete.Enabled = False
            'Me.txtOrderNo.ReadOnly = True
            'Me.txtPSSINo.ReadOnly = False
            'Me.txtPackStation.Text = "Pack01"
            'Me.txtPacker.Text = Trim(ApplicationUser.User)
            'Me._dtScanSNs = New DataTable()
            'Me.txtPSSINo.Focus()
        End Sub

        'Private Sub txtOrderNo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOrderNo.KeyUp
        '    Dim sum As Integer
        '    Dim orderNo As String

        '    If e.KeyCode = Keys.Enter AndAlso Me.txtOrderNo.Text.Trim.Length > 0 Then
        '        Try
        '            ClearUI()

        '            orderNo = Me.txtOrderNo.Text

        '            Me._dtPackData = Me._objPack.getPackOrder(orderNo)

        '            If Not IsNothing(_dtPackData) Then
        '                If Me._dtPackData.Rows.Count > 0 Then
        '                    Me.txtPSSINo.Text = Me._dtPackData.Rows(0)("BoxLabel").ToString
        '                    Me._strOrderNo = Convert.ToInt32(txtOrderNo.Text)
        '                    Me._iSoHeaderID = Convert.ToInt32(Me._dtPackData.Rows(0)("SoheaderID"))
        '                    Me._iShipID = Convert.ToInt32(Me._dtPackData.Rows(0)("ShipCarrierID"))
        '                    Me.txtPickRun.Text = Me._dtPackData.Rows(0)("PickRunNo").ToString
        '                    sum = Convert.ToInt32(Me._dtPackData.Compute("Sum([Order Qty])", String.Empty))
        '                    Me.txtQty.Text = sum.ToString
        '                Else
        '                    MessageBox.Show("Order Number is not found.", "OrderNo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                End If

        '                Me.BindPackData(Me._dtPackData)
        '                Me.txtOrderNo.ReadOnly = True
        '                Me.txtPSSINo.ReadOnly = True
        '                If Not IsNothing(_dtPackData) AndAlso _dtPackData.Rows.Count > 0 Then
        '                    tdgData1_RowColChange(Nothing, Nothing)
        '                End If
        '            End If

        '        Catch ex As Exception
        '            MessageBox.Show(ex.ToString, " txtOrderNo_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        End Try
        '    End If
        'End Sub

        Private Function getRowID(ByVal dt As DataTable, ByVal strBox As String) As Integer
            Dim iRow As Integer = 0
            Dim row As DataRow

            Try
                For Each row In dt.Rows
                    If Convert.ToString(row("BoxLabel")).Trim.ToUpper = strBox.Trim.ToUpper Then
                        iRow = Convert.ToInt32(row("Row"))
                        Exit For
                    End If
                Next

                Return iRow
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "getRowID", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Function

        Private Sub txtPSSINo_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPSSINo.KeyUp
            Dim sum As Integer
            Dim strBoxID As String
            Dim bIsOrderClosed As Boolean = False
            Dim bIsOrderLocked As Boolean = False
            Dim strLockedPCName As String = ""
            Dim scanedTrackingNumber As String = ""
            Dim strLabelTrack As String = ""
            Dim row As DataRow
            Dim iModelID As String = ""
            Dim strItem As String = ""
            Dim dtOrderModelItemsQty As DataTable
            Dim dtTmp As DataTable
            Dim iQtyTmp As Integer = 0

            If e.KeyCode = Keys.Enter AndAlso Me.txtPSSINo.Text.Trim.Length > 0 Then
                Try
                    Me.tdgData1.DataSource = Nothing
                    Me.pnlBox.Visible = False : Me.txtScan.Enabled = False

                    strBoxID = txtPSSINo.Text
                    Me._strOrderNo = Me._objPack.getOrderNumber(strBoxID, Me._iOrderTypeID, bIsOrderClosed, bIsOrderLocked, strLockedPCName)

                    'Validate order
                    If Not Me._strOrderNo.Trim.Length > 0 Then
                        MessageBox.Show("Order Number is not found for this PSSI number '" & strBoxID & "'.", "Pack Screen", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txtPSSINo.SelectAll() : Me.txtPSSINo.Focus() : Exit Sub
                    End If
                    If bIsOrderClosed Then
                        MessageBox.Show("Order is closed.", "Pack Screen", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txtPSSINo.SelectAll() : Me.txtPSSINo.Focus() : Exit Sub
                    End If
                    If Not Me._iOrderTypeID > 0 Then
                        MessageBox.Show("Invalid OrderType_ID.", "Pack Screen", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txtPSSINo.SelectAll() : Me.txtPSSINo.Focus() : Exit Sub
                    End If
                    If bIsOrderLocked AndAlso Not strLockedPCName.Trim.ToUpper = Me._strComputerName.Trim.ToUpper Then
                        MessageBox.Show("This order is locked by computer '" & strLockedPCName & "'.", "Pack Screen", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txtPSSINo.SelectAll() : Me.txtPSSINo.Focus() : Exit Sub
                    End If

                    'get order data
                    Me._dtPackData = Me._objPack.getOpenOrderData(Me._strOrderNo, Me._iOrderTypeID)

                    'Validate order data
                    If Not Me._dtPackData.Rows.Count > 0 Then
                        MessageBox.Show("Can't find data for this order '" & Me._strOrderNo & "'.", "Pack Screen", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txtPSSINo.SelectAll() : Me.txtPSSINo.Focus() : Exit Sub
                    End If

                    'Validate order items and In-Pick items (including all available WH receipt items associated with In-Pick) . 
                    dtOrderModelItemsQty = Me._objPack.getOrderModelItemsQty(Me._dtPackData)
                    If Not dtOrderModelItemsQty.Rows.Count > 0 Then
                        MessageBox.Show("Invalid total qty per item of the order (Datatable: _dtOrderModelItemsQty).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txtPSSINo.SelectAll() : Me.txtPSSINo.Focus() : Exit Sub
                    End If

                    For Each row In dtOrderModelItemsQty.Rows
                        strItem = Convert.ToString(row("ItemName"))
                        iModelID = Convert.ToInt32(row("Model_ID"))
                        iQtyTmp = Convert.ToInt32(row("qty"))
                        dtTmp = Me._objPack.getInPickSNsData(iModelID.ToString)
                        If Not dtTmp.Rows.Count >= iQtyTmp Then
                            MessageBox.Show("No enough Item " & strItem & ": Qty ordered (" & iQtyTmp.ToString & ") vs Qty (" & dtTmp.Rows.Count & ") of In-Pick assocaited with the WH Receipt", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.txtPSSINo.SelectAll() : Me.txtPSSINo.Focus() : Exit Sub
                        End If
                    Next

                    'After the first scan, lock the order by PC name
                    Me._objPack.UpdateSoHeader_Lock(Me._strComputerName, Convert.ToInt32(Me._dtPackData.Rows(0).Item("SoHeaderID")))


                    'Ready to populate data
                    Me.txtOrderNo.Text = Me._strOrderNo
                    Me._iSoHeaderID = Convert.ToInt32(Me._dtPackData.Rows(0)("SoheaderID"))
                    Me._iShipID = Convert.ToInt32(Me._dtPackData.Rows(0)("ShipCarrierID"))
                    Me.txtPickRun.Text = Me._dtPackData.Rows(0)("PickRunNo").ToString
                    Me.txtCustomer.Text = Me._dtPackData.Rows(0)("Customer").ToString
                    Me.txtCustomerNo.Text = Me._dtPackData.Rows(0)("CustomerNo").ToString
                    sum = Convert.ToInt32(Me._dtPackData.Compute("Sum([Qty])", String.Empty))
                    Me.txtOrderQty.Text = sum.ToString

                    If Me._iOrderTypeID = 1 Then 'Non Bulk
                        Me.txtPSSINo.Visible = False : Me.lblPSSINo.Visible = False
                        Me._iSelectedRowID = getRowID(Me._dtPackData, strBoxID)
                        Me.txtSelectedBox.Text = strBoxID : Me.txtSelectedBox.Enabled = False
                        Me.lblRow.Text = Me._iSelectedRowID.ToString

                        If Convert.ToInt32(Me._dtPackData.Select("Row = " & Me._iSelectedRowID)(0)("TrackNoLength")) > 0 Then
                            Me.txtHowManyLastDigits.Text = Convert.ToInt32(Me._dtPackData.Select("Row = " & Me._iSelectedRowID)(0)("TrackNoLength"))
                            Me._strSelectedTrackNo = Convert.ToString(Me._dtPackData.Select("Row = " & Me._iSelectedRowID)(0)("TrackingNo"))
                        Else
                            Me._strSelectedTrackNo = ""
                            Me.txtHowManyLastDigits.Text = Me._iDefaultTrackingLength
                        End If

                        Me.pnlBox.Visible = True : Me.txtTracking.SelectAll() : Me.txtTracking.Focus()

                        Me.BindPackData(Me._dtPackData)
                    ElseIf Me._iOrderTypeID = 2 Then 'Bulk
                        Me.pnlBox.Visible = False : Me.txtScan.Enabled = True
                        Me.txtPSSINo.Enabled = False : Me.txtPSSINo.Visible = True
                        Me.lblPSSINo.Visible = True
                        Me.txtScan.SelectAll() : Me.txtScan.Focus()

                        Me.BindPackData(Me._dtPackData)
                    Else
                        MessageBox.Show("Invalid OrderType_ID " & Me._iOrderTypeID.ToString & ".", "Pack Screen", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If


                    'scanedTrackingNumber = InputBox("Scan label tracking number ", "Tracking Number", , , )
                    'strLabelTrack = scanedTrackingNumber.Substring(scanedTrackingNumber.Trim.Length - 12)

                    'If (strLabelTrack <> Me._strTracking) Then
                    '    MsgBox("Incorrect tracking number" & vbCrLf & "Scan another Tracking number", MsgBoxStyle.Exclamation)
                    '    txtPSSINo.Focus()
                    '    Exit Sub
                    'End If


                    'Me.txtPSSINo.ReadOnly = True

                    'If Not IsNothing(_dtPackData) AndAlso _dtPackData.Rows.Count > 0 Then
                    '    tdgData1_RowColChange(Nothing, Nothing)
                    'End If


                Catch ex As Exception
                    MessageBox.Show(ex.ToString, " txtOrderNo_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Sub

        Private Sub btnProcessBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcessBox.Click
            Dim iLen As Integer = 0
            Dim strTrackNo As String = ""
            Dim strBox As String = ""
            Dim row As DataRow

            Try

                If Not Me.txtSelectedBox.Text.Trim.Length > 0 Then
                    MessageBox.Show("Enter a PSSI Box #.", "Box Process", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtSelectedBox.SelectAll() : Me.txtSelectedBox.Focus()
                    Exit Sub
                ElseIf Me.txtSelectedBox.Text.Trim.Length > 0 Then
                    Dim bHasTheBox As Boolean = False
                    For Each row In Me._dtPackData.Rows
                        If Convert.ToInt32(row("ShipQty")) = 0 _
                           AndAlso Convert.ToString(row("BoxLabel")).Trim.ToUpper = Me.txtSelectedBox.Text.Trim.ToUpper Then
                            bHasTheBox = True : Exit For
                        End If
                    Next
                    If Not bHasTheBox Then
                        MessageBox.Show("Invalid PSSI Box # or the box has been filled.", "Box Process", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txtSelectedBox.SelectAll() : Me.txtSelectedBox.Focus()
                        Exit Sub
                    End If
                End If

                If Not Me.txtTracking.Text.Trim.Length > 0 Then
                    MessageBox.Show("Scan or enter a tracking number for this box.", "Box Process", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtTracking.SelectAll() : Me.txtTracking.Focus()
                Else
                    If Not Me._iSelectedRowID > 0 Then
                        Me._iSelectedRowID = getRowID(Me._dtPackData, Me.txtSelectedBox.Text.Trim)
                        Me._strSelectedTrackNo = Convert.ToString(Me._dtPackData.Select("Row = " & Me._iSelectedRowID)(0)("TrackingNo"))
                        Me.lblRow.Text = Me._iSelectedRowID.ToString
                    End If

                    If Me._strSelectedTrackNo.Trim.Length > 0 Then 'DB has track numner
                        iLen = Me._strSelectedTrackNo.Trim.Length
                        Me.txtHowManyLastDigits.Text = iLen.ToString
                        If Me.txtTracking.Text.Trim.Length > iLen Then
                            strTrackNo = Me.txtTracking.Text.Trim.Substring(Me.txtTracking.Text.Trim.Length - iLen)
                        Else
                            strTrackNo = Me.txtTracking.Text.Trim
                        End If
                        Me.txtTracking.Text = strTrackNo
                        If Me._strSelectedTrackNo.Trim.ToUpper = strTrackNo.Trim.ToUpper Then 'Track numners match
                            Me.txtScan.Enabled = True : Me.txtHowManyLastDigits.Enabled = False
                            Me.txtSelectedBox.Enabled = False : Me.txtTracking.Enabled = False
                            Me.btnProcessBox.Enabled = False
                            Me.txtScan.SelectAll() : Me.txtScan.Focus()
                        Else 'Track numners don't match
                            MessageBox.Show("Invalid tracking number.", "Box Process", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.txtTracking.SelectAll() : Me.txtTracking.Focus()
                        End If
                    ElseIf Not Me._strSelectedTrackNo.Trim.Length > 0 Then 'DB doesn't have track numner
                        Dim i As Integer = 0
                        Dim strType As String = "Standard"

                        strBox = Me.txtSelectedBox.Text.Trim
                        iLen = Convert.ToInt32(Me.txtHowManyLastDigits.Text)
                        'Me.txtHowManyLastDigits.Text = iLen.ToString
                        If Me.txtTracking.Text.Trim.Length > iLen Then
                            strTrackNo = Me.txtTracking.Text.Trim.Substring(Me.txtTracking.Text.Trim.Length - iLen)
                        Else
                            strTrackNo = Me.txtTracking.Text.Trim
                        End If
                        Me.txtTracking.Text = strTrackNo

                        Dim result As DialogResult = MessageBox.Show("Database has no tracking number." & Environment.NewLine & _
                             "You scanned/entered this tracking number '" & strTrackNo & "'." & Environment.NewLine & _
                             "Please confirm to save by click 'Yes' button.", _
                             "Tracking number", MessageBoxButtons.YesNo)
                        If (result = DialogResult.Yes) Then
                            'Update data here
                            i = Me._objPack.InsertUpdateTrackingNumber(strBox, strTrackNo, strType)
                            For Each row In Me._dtPackData.Rows
                                If Convert.ToInt32(row("Row")) = Me._iSelectedRowID Then
                                    row.BeginEdit() : row("TrackingNo") = strTrackNo
                                    row.AcceptChanges()
                                End If
                            Next
                            Me.txtScan.Enabled = True : Me.txtHowManyLastDigits.Enabled = False
                            Me.txtSelectedBox.Enabled = False : Me.txtTracking.Enabled = False
                            Me.btnProcessBox.Enabled = False
                            Me.txtScan.SelectAll() : Me.txtScan.Focus()
                        Else
                            MessageBox.Show("You cancelled. Try again..", "Box Process", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.txtTracking.SelectAll() : Me.txtTracking.Focus()
                        End If
                    End If
                End If

            Catch ex As Exception
                Me.txtSelectedBox.Enabled = True : Me.txtTracking.Enabled = True
                Me.btnProcessBox.Enabled = True : Me.txtHowManyLastDigits.Enabled = True
                Me.lblRow.Text = 0
                MessageBox.Show(ex.ToString, " btnProcessBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub BindPackData(ByVal dt As DataTable)
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
            Dim i As Integer = 0

            Try
                If dt.Rows.Count > 0 Then
                    With Me.tdgData1
                        .DataSource = dt.DefaultView

                        For Each dbgc In .Splits(0).DisplayColumns
                            dbgc.Locked = True
                            dbgc.AutoSize()
                        Next dbgc

                        'Row, BoxLabel, ItemName, Qty, ShipQty, TrackingNo, ItemQty, OrderQty, LineNo, PickRunNo, OrderNo, PackLocked, 
                        'PackLockedPC(, Customer, CustomerNo, SoheaderID, ModelID, SoDetailsID, ShipCarrierID, ShipPackageWeight, 
                        'CustomerAdditionalName1, CustomerAddress1, CustomerAddress2, CustomerCity, CustomerState, CustomerPostalCode)
                        For i = 6 To dt.Columns.Count - 1
                            .Splits(0).DisplayColumns(i).Visible = False
                        Next
                        'Me.tdgData1.Columns.RemoveAt(Me.tdgData1.Columns.IndexOf(Me.tdgData1.Columns("PickRunNo")))
                        '.Splits(0).DisplayColumns("SOHeaderID").Visible = False
                        'If dt.Rows(0)("CustomerNo") <> PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK.Meijer_CUSTOMER_ID Then
                        '    .Splits(0).DisplayColumns("BoxLabel").Visible = False
                        'End If
                        '.Splits(0).DisplayColumns("Part Number").Width = 0

                    End With

                    If Me._iShipID <> 10 Then
                        Me.lblTN.Visible = True
                        Me.txtTracking.Visible = True
                        Me.txtTracking.ReadOnly = False
                    Else
                        Me.txtScan.ReadOnly = False
                        Me.txtScan.Focus()
                    End If

                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "BindPackData", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        'Private Sub tdgData1_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdgData1.RowColChange
        '    Dim partNum As String = ""

        '    Try
        '        If Not Me._dtPackSN Is Nothing Then
        '            Me._dtPackSN.Clear()
        '        End If

        '        If Not IsNothing(Me.tdgData1.DataSource) AndAlso Not Me.tdgData1.RowCount <= 0 AndAlso Not IsNothing(Me.tdgData1.Columns("Part Number").Value) Then
        '            partNum = Me.tdgData1.Columns("Part Number").Value.ToString()
        '             If partNum.Trim.Length > 0 Then Me._dtPackSN = Me._objPack.getSNData(partNum)

        '            'If Me._dtPackData.Rows(0)("CustomerNo") = PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK.Meijer_CUSTOMER_ID Then
        '            '    Me.txtPSSINo.Text = Me.tdgData1.Columns("BoxLabel").Value.ToString()
        '            '    Me.txtTracking.Text = Me.tdgData1.Columns("TrackingNo").Value.ToString()
        '            'End If

        '        End If
        '    Catch ex As Exception
        '        MessageBox.Show(ex.ToString, "tdgData1", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        '    End Try
        'End Sub

        'Private Sub txtTracking_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        '    Try
        '        If (txtTracking.Text = _strTracking) Then
        '            txtScan.Enabled = True
        '            txtScan.ReadOnly = False
        '            txtScan.Focus()
        '        ElseIf (_strTracking = Nothing) Then
        '            btnOverride.Visible = True
        '            txtTracking.Visible = True
        '            txtTracking.ReadOnly = False
        '            btnOverride.Enabled = True
        '        ElseIf (txtTracking.Text <> _strTracking) Then
        '            MessageBox.Show("Tracking Numbers don't match. Please contact IT.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        End If

        '    Catch ex As Exception
        '        MessageBox.Show(ex.ToString, " txtTracking_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End Try
        'End Sub

        Private Sub txtSelectedBox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSelectedBox.KeyUp
            Try
                If e.KeyCode = Keys.Enter AndAlso Me.txtSelectedBox.Text.Trim.Length > 0 Then
                    Me.txtTracking.SelectAll() : Me.txtTracking.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtSelectedBox_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub txtTracking_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTracking.KeyUp
            Try
                If e.KeyCode = Keys.Enter AndAlso Me.txtTracking.Text.Trim.Length > 0 Then
                    Me.btnProcessBox.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtTracking_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub txtScan_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtScan.KeyUp
            Dim row As DataRow
            Dim iRow As Integer = 0
            Dim qty As Integer = 0
            Dim strSN As String = ""
            Dim strItem As String = ""
            Dim iModel_ID As Integer = 0

            Dim bBoxCompleted As Boolean = False
            Dim bItemFilledBySN As Boolean = False

            Dim strOrderModelIDs As String = ""

            Dim partNo As String = ""
            Dim orderQty As Integer = 0
            Dim packQty As Integer = 0

            Dim dtInPickItemSN As DataTable

            Try
                strSN = txtScan.Text.Trim
                If e.KeyCode = Keys.Enter AndAlso strSN.Length > 0 AndAlso Not IsNothing(Me.tdgData1.DataSource) _
                  AndAlso Me.tdgData1.RowCount > 0 Then

                    'If Not strSN.Length > 0 Then
                    '    MessageBox.Show("Please enter/scan a SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    '    txtScan.SelectAll() : txtScan.Focus() : Exit Sub
                    'End If

                    If Not Me._dtPackData.Rows.Count = Me.tdgData1.RowCount Then
                        MessageBox.Show("Data grid and data table don't match. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txtScan.SelectAll() : Me.txtScan.Focus() : Exit Sub
                    End If

                    'Check dup in the scanned list
                    If Me._dtScanSNs.Rows.Count > 0 Then
                        For Each row In Me._dtScanSNs.Rows
                            If Convert.ToString(row("SN")).Trim.ToUpper = strSN.ToUpper Then
                                MessageBox.Show("Duplicate SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Me.txtScan.SelectAll() : Me.txtScan.Focus() : Exit Sub
                            End If
                        Next
                    End If

                    'Go
                    If Me._iOrderTypeID = 1 Then 'Non Bulk
                        If Not Me.txtSelectedBox.Text.Trim.Length > 0 Then
                            MessageBox.Show("Enter PSSI Box #.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.txtSelectedBox.Enabled = True : Me.btnProcessBox.Enabled = True
                            Me.txtSelectedBox.SelectAll() : Me.txtSelectedBox.Focus()
                            Exit Sub
                        ElseIf Not Me.txtTracking.Text.Trim.Length > 0 Then
                            MessageBox.Show("Scan/enter tracking #.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.txtTracking.Enabled = True : Me.btnProcessBox.Enabled = True
                            Me.txtTracking.SelectAll() : Me.txtTracking.Focus()
                            Exit Sub
                        End If

                        iModel_ID = Convert.ToInt32(Me._dtPackData.Select("Row = " & Me._iSelectedRowID)(0)("Model_ID"))
                        dtInPickItemSN = Me._objPack.getInPickSNsData(iModel_ID.ToString, "", strSN)

                        If Not dtInPickItemSN.Rows.Count > 0 Then
                            MessageBox.Show("Not available In-Pick SNs assocaited with the WH Receipt or the item isn't correct model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.txtScan.SelectAll() : Me.txtScan.Focus() : Exit Sub
                        ElseIf dtInPickItemSN.Rows.Count > 1 Then
                            MessageBox.Show("Found duplicate In-Pick SNs assocaited with the WH Receipt.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.txtScan.SelectAll() : Me.txtScan.Focus() : Exit Sub
                        End If
                        'SN, Item, Model_ID, SoDetailsID, PSSI_Boxlabel_Name, Device_ID, WI_ID, Row
                        For Each row In dtInPickItemSN.Rows 'Must be 1 row
                            row.BeginEdit()
                            row("SoDetailsID") = Convert.ToInt32(Me._dtPackData.Select("Row = " & Me._iSelectedRowID)(0)("SoDetailsID"))
                            row("PSSI_Boxlabel_Name") = Convert.ToString(Me._dtPackData.Select("Row = " & Me._iSelectedRowID)(0)("BoxLabel"))
                            row("row") = Me._iSelectedRowID
                            row.AcceptChanges()
                            Me._dtScanSNs.ImportRow(row)
                            Exit For
                        Next

                        'Bind scanned data
                        Me.lstScan.DataSource = Me._dtScanSNs
                        Me.lstScan.DisplayMember = "SN"


                        For Each row In Me._dtPackData.Rows
                            If Convert.ToInt32(row("Row")) = Me._iSelectedRowID Then
                                row.BeginEdit()
                                row("ShipQty") = Convert.ToInt32(row("ShipQty")) + 1
                                row.AcceptChanges()
                                Exit For
                            End If
                        Next

                        Me.txtShipQty.Text = Me._dtPackData.Compute("SUM(ShipQty)", "")

                        'Check finish a box   
                        bBoxCompleted = False
                        For Each row In Me._dtPackData.Rows
                            If Convert.ToInt32(row("Row")) = Me._iSelectedRowID _
                               AndAlso Convert.ToInt32(row("Qty")) = Convert.ToInt32(row("ShipQty")) Then
                                Me.txtTracking.Text = "" : Me.lblRow.Text = 0
                                Me._strSelectedTrackNo = "" : Me._iSelectedRowID = 0
                                Me.txtSelectedBox.Text = ""
                                Me.txtScan.Text = "" : Me.txtScan.Enabled = False
                                Me.txtSelectedBox.Enabled = True
                                Me.txtTracking.Enabled = True
                                Me.pnlBox.Enabled = True
                                Me.btnProcessBox.Enabled = True
                                Me.txtHowManyLastDigits.Enabled = True
                                bBoxCompleted = True
                                Me.txtSelectedBox.SelectAll() : Me.txtSelectedBox.Focus()
                                Exit For 'this box has been fulfilled
                            End If
                        Next

                        'Check finish the order 
                        If Not bBoxCompleted Then 'continue to fill the box
                            Me.txtScan.Text = "" : Me.txtScan.SelectAll() : Me.txtScan.Focus()
                        ElseIf Convert.ToInt32(Me._dtPackData.Compute("SUM(Qty)", "")) = Convert.ToInt32(Me._dtPackData.Compute("SUM(ShipQty)", "")) _
                               AndAlso Convert.ToInt32(Me.txtOrderQty.Text) = Convert.ToInt32(Me.txtShipQty.Text) Then 'box fulfilled, check order finish
                            Me.pnlBox.Enabled = False
                            Me.btnComplete.Enabled = True
                            Me.btnComplete.Focus()
                        End If
                    ElseIf Me._iOrderTypeID = 2 Then 'Bulk
                        strOrderModelIDs = "" : Me.btnComplete.Enabled = False
                        For Each row In Me._dtPackData.Rows
                            If strOrderModelIDs.Trim.Length = 0 Then
                                strOrderModelIDs = Convert.ToString(row("Model_ID"))
                            Else
                                strOrderModelIDs &= "," & Convert.ToString(row("Model_ID"))
                            End If
                        Next

                        dtInPickItemSN = Me._objPack.getInPickSNsData(strOrderModelIDs, "", strSN)

                        If Not dtInPickItemSN.Rows.Count > 0 Then
                            MessageBox.Show("Not available In-Pick SNs assocaited with the WH Receipt or the item isn't correct model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.txtScan.SelectAll() : Me.txtScan.Focus() : Exit Sub
                        ElseIf dtInPickItemSN.Rows.Count > 1 Then
                            MessageBox.Show("Found duplicate In-Pick SNs assocaited with the WH Receipt.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.txtScan.SelectAll() : Me.txtScan.Focus() : Exit Sub
                        End If

                        'SN, Item, Model_ID, SoDetailsID, PSSI_Boxlabel_Name, Device_ID, WI_ID, Row
                        For Each row In dtInPickItemSN.Rows 'Must be 1 row
                            iModel_ID = Convert.ToInt32(row("Model_ID")) 'Model_ID for the scanned SN
                            Exit For
                        Next

                        Me._iSelectedRowID = 0 : bItemFilledBySN = False
                        For Each row In Me._dtPackData.Rows
                            'find unfilled row
                            If Not Convert.ToInt32(row("Qty")) = Convert.ToInt32(row("ShipQty")) _
                               AndAlso Convert.ToInt32(row("Model_ID")) = iModel_ID Then
                                Me._iSelectedRowID = Convert.ToInt32(row("Row"))
                                row.BeginEdit()
                                row("ShipQty") = Convert.ToInt32(row("ShipQty")) + 1
                                row.AcceptChanges()
                                bItemFilledBySN = True
                                Exit For
                            End If
                        Next

                        If Not bItemFilledBySN Then
                            MessageBox.Show("Can't fill an item by the SN (SN model may be diiferent from the order item). See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.txtScan.SelectAll() : Me.txtScan.Focus() : Exit Sub
                        End If

                        For Each row In dtInPickItemSN.Rows 'Must be 1 row
                            row.BeginEdit()
                            row("SoDetailsID") = Convert.ToInt32(Me._dtPackData.Select("Row = " & Me._iSelectedRowID)(0)("SoDetailsID"))
                            row("PSSI_Boxlabel_Name") = Convert.ToString(Me._dtPackData.Select("Row = " & Me._iSelectedRowID)(0)("BoxLabel"))
                            row("row") = Me._iSelectedRowID
                            row.AcceptChanges()
                            Me._dtScanSNs.ImportRow(row)
                            Exit For
                        Next

                        'Bind scanned data
                        Me.lstScan.DataSource = Me._dtScanSNs
                        Me.lstScan.DisplayMember = "SN"

                        'update total ship Qty 
                        Me.txtShipQty.Text = Me._dtPackData.Compute("SUM(ShipQty)", "")

                        If Convert.ToInt32(Me._dtPackData.Compute("SUM(Qty)", "")) = Convert.ToInt32(Me._dtPackData.Compute("SUM(ShipQty)", "")) _
                           AndAlso Convert.ToInt32(Me.txtOrderQty.Text) = Convert.ToInt32(Me.txtShipQty.Text) Then 'fulfilled, check order finish
                            Me.txtScan.Text = "" : Me.txtScan.Enabled = False
                            Me.btnComplete.Enabled = True
                            Me.btnComplete.Focus()
                        Else
                            Me.txtScan.Text = "" : Me.txtScan.Enabled = True
                            Me.txtScan.SelectAll() : Me.txtScan.Focus()
                        End If



                        ' iRow = Me.tdgData1.Row


                        Exit Sub


                        ''Me._objPack.getSNData(partNum)
                        'If IsNothing(Me._dtPackSN) OrElse Me._dtPackSN.Rows.Count = 0 Then
                        '    'Check if SN is available
                        '    MessageBox.Show("This unit has not been placed in a pick location", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        '    Exit Sub
                        'Else
                        '    'Check quantity 
                        '    If Me._dtScanSNs.Select("PartNum = '" + Me.tdgData1.Columns("Part Number").Value.ToString() + "'").Length >= System.Convert.ToInt32(Me.tdgData1.Columns("Order Qty").Value) Then
                        '        MessageBox.Show("You have reached the quanity. Please select different part number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        '        Me.txtScan.Text = String.Empty
                        '    ElseIf Me._dtPackSN.Select("SN = '" + strSN + "'").Length > 1 Then
                        '        MessageBox.Show("SN existed more than one in database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        '        Me.txtScan.Text = String.Empty
                        '        Me.txtScan.Focus()
                        '    ElseIf Me._dtPackSN.Select("SN = '" + strSN + "'").Length = 0 Then
                        '        MessageBox.Show("SN either does not exist or does not belong to the selected part number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        '        Me.txtScan.Text = String.Empty
                        '        Me.txtScan.Focus()
                        '    Else
                        '        row = Me._dtPackSN.Select("SN = '" + strSN + "'")(0)
                        '        'MsgBox("here")
                        '        '*****************************
                        '        'Check for duplicate in list
                        '        '*****************************
                        '        If Me._dtScanSNs.Select("SN = '" + strSN + "'").Length > 0 Then
                        '            MsgBox("This serial number is already listed.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "SN Listed")
                        '            If Me.txtScan.Text.Trim.Length > 0 Then
                        '                Me.txtScan.SelectAll()
                        '                Me.txtScan.Focus()
                        '                Exit Sub
                        '            End If
                        '        Else
                        '            Dim R1 As DataRow = Me._dtScanSNs.NewRow
                        '            R1("SN") = strSN
                        '            R1("PartNum") = row("Part Number")
                        '            R1("Device_ID") = Convert.ToInt32(row("Device_ID").ToString)
                        '            R1("WI_ID") = row("WI_ID")
                        '            R1("SoDetailsID") = Convert.ToInt32(Me.tdgData1.Columns("SoDetailsID").CellText(iRow))
                        '            partNo = row("Part Number").ToString
                        '            Me._dtScanSNs.Rows.Add(R1)
                        '            Me._dtScanSNs.AcceptChanges()

                        '            Me.txtScan.Text = String.Empty
                        '            Me.txtShipQty.Text = Me._dtScanSNs.Rows.Count

                        '            'iRow = Me.tdgData1.Row
                        '            qty = Convert.ToInt32(Me.tdgData1.Columns("Pack Qty").CellText(iRow))
                        '            qty = qty + 1
                        '            Me.tdgData1.Columns("Pack Qty").Value = qty.ToString
                        '            Me.tdgData1.Refresh()

                        '            orderQty = Convert.ToInt32(Me.tdgData1.Columns("Order Qty").CellText(iRow))
                        '            packQty = Convert.ToInt32(Me.tdgData1.Columns("Pack Qty").CellText(iRow))

                        '            If orderQty = packQty Then
                        '                validateSN(partNo)
                        '            End If


                        '        End If


                        '        ''If Me.txtTracking.Text = "" And Me._iShipID <> 10 Then
                        '        'If Me._iShipID <> 10 Then
                        '        '    MessageBox.Show("This unit does not have a tracking number. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        '        'End If

                        '        'Enable/Disable Complete button
                        '        If Me.lstScan.Items.Count = CInt(Me.txtShipQty.Text) Then
                        '            Me.btnComplete.Enabled = True : Me.btnComplete.Focus()
                        '        Else
                        '            Me.btnComplete.Enabled = False
                        '            Me.txtScan.Text = String.Empty
                        '            Me.txtScan.Focus()
                        '        End If
                        '    End If
                        'End If
                    End If 'order has line item
                End If 'Enter key
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtScan_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub btnOverride_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOverride.Click
            txtScan.Enabled = True
            txtScan.ReadOnly = False
            txtScan.Focus()
        End Sub

        Private Sub btnComplete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComplete.Click
            Dim i As Integer = 0, j As Integer = 0, k As Integer = 0, l As Integer = 0
            Dim boolUpd As Integer = 0
            Dim strWorkStation As String = PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK._strShipWorkstation
            Dim strDateTime As String = Format(Now, "yyyyMMddHHmmss")
            Dim dtLabel As DataTable = New DataTable()
            Dim bulkOrder As New frmTFFK_BulkOrder()
            Dim fileBOLLoc As String = "P:\Dept\FedEx\BOL.IN"
            Dim bol As String = ""
            Dim fs As FileStream = Nothing
            Dim sw As StreamWriter = Nothing
            Dim strMsg As String = ""
            Dim row As DataRow
            Dim strPSSI_BoxName As String = ""
            Dim strBolTrackingNo As String = ""

            Try

                CopyToClipBoardAnsSaveToFile()

                If Not Me._dtPackData.Rows.Count > 0 OrElse Not Me._dtScanSNs.Rows.Count > 0 _
                   OrElse Not Convert.ToInt32(Me.txtOrderQty.Text) = Convert.ToInt32(Me.txtShipQty.Text) _
                   OrElse Not Convert.ToInt32(Me.txtOrderQty.Text) = Me._dtScanSNs.Rows.Count Then
                    MessageBox.Show("No data or no enough data to close. Please contact IT.", "Close Order", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                For Each row In Me._dtScanSNs.Rows
                    For i = 0 To Me._dtScanSNs.Columns.Count - 1
                        If row.IsNull(0) OrElse Convert.ToString(row(0)).Trim.Length = 0 Then
                            MessageBox.Show("No enough data to close. Please contact IT.", "Close Order", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If
                    Next
                Next
                i = 0

                If Me._iOrderTypeID = 1 Then 'Non Bulk order
                    'do nothing specifically 
                Else 'bulk
                    If (Me.txtCustomerNo.Text = PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK.Meijer_CUSTOMER_ID _
                        OrElse Me.txtCustomerNo.Text = PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK.Freds_CUSTOMER_ID) _
                        AndAlso (Me._iShipID = 10 OrElse Me._iShipID = PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK._iSaiaCarrierLTLShipMethodID) Then
                        bulkOrder.ShowDialog()
                        Me._palletQty = Integer.Parse(bulkOrder.txtPalletsNo.Text)
                        Me._weight = Integer.Parse(bulkOrder.txtWeight.Text) * 100
                        Me._deviceQty = Integer.Parse(bulkOrder.txtDevicesNo.Text)

                        'Generate BOL file
                        bol = Me._objPickPackShip.Build_BOL_Text(Me._weight, Me._palletQty, Me._deviceQty, Me._strOrderNo, Me._dtPackData.Rows(0)("Customer").ToString, Me._dtPackData.Rows(0)("CustomerAdditionalName1").ToString, Me._dtPackData.Rows(0)("CustomerAddress1").ToString, Me._dtPackData.Rows(0)("CustomerCity").ToString, Me._dtPackData.Rows(0)("CustomerState").ToString, Me._dtPackData.Rows(0)("CustomerPostalCode").ToString, Me._dtPackData.Rows(0)("OrderQty"), Me._dtPackData.Rows(0)("ShipPackageWeight"))

                        If (Not File.Exists(fileBOLLoc)) Then
                            fs = File.Create(fileBOLLoc)
                            fs.Close()
                            sw = New StreamWriter(fileBOLLoc)
                            sw.Write(bol)
                            sw.Close()
                        End If
                    End If

                    'Dim frmV As New frmView(dtBoxLabel)
                    'PSSI_Boxlabel_Name

                    strPSSI_BoxName = Convert.ToString(Me._dtScanSNs.Rows(0).Item("PSSI_Boxlabel_Name"))

                    'write 2 text files (Labels) (Meijer Bulk, and Fred's Bulk)
                    If Me.txtCustomerNo.Text = PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK.Meijer_CUSTOMER_ID.ToString() _
                       AndAlso (Me._iShipID = PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK._iMeijerBulkCarrierShipMethodID.ToString() _
                                OrElse Me._iShipID = PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK._iSaiaCarrierLTLShipMethodID) Then 'Meijer
                        Dim fm As New frmCollectBolTrackingNo(strPSSI_BoxName)
                        fm.ShowDialog()
                        fm.Dispose()
                        CreateGTN14File()
                    ElseIf Me.txtCustomerNo.Text = PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK.Freds_CUSTOMER_ID.ToString() Then 'Freds
                        Dim fm As New frmCollectBolTrackingNo(strPSSI_BoxName)
                        fm.ShowDialog()
                        strBolTrackingNo = fm._strBOL
                        fm.Dispose()
                        CreateSSC18File(strBolTrackingNo)
                    End If
                End If

                'Close order
                strMsg = ""
                j = Me._objPack.UpdateItemsDevicesWorkOrder(Convert.ToInt32(Me._dtPackData.Rows(0).Item("WO_ID")), strWorkStation, Me._dtScanSNs, strMsg)
                If strMsg.Trim.Length > 0 Then
                    MessageBox.Show(strMsg & ". Failed to close. Please contact IT.", "Close Order", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.btnComplete.Enabled = False
                    Exit Sub
                End If
                i = Me._objPickPackShip.UpdateFulfillmentOrderWorkstation(Me._iSoHeaderID, strWorkStation, Me._UserID, strDateTime, 3)
                If i = 0 Then
                    MessageBox.Show("Failed to close the order. Please contact IT.", "Close Order", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.btnComplete.Enabled = False
                    Exit Sub
                End If

                'j = Me._objPack.UpdatetCelloptWorkstation(Me._dtScanSNs, strWorkstation, strDateTime)
                'l = Me._objPack.UpdatetWorkorder(Me._dtPackData.Rows(0)("OrderNo"))
                Me.ClearUI()

                'update the PackLockedPC and PackLocked in soHeader table
                'Dim z As Integer = Me._objPack.UpdateSoHeader_removeLock(Me._dtPackData.Rows(0)("SOHeaderID").ToString())



            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnComplete", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub validateSN(ByVal partNum As String)
            Dim row As DataRow
            Dim sn As DataRow
            Dim boolFound As Boolean = False
            Dim serialno As String = ""

            Try
                Me._dtValidateSNs = Me._objPack.getItemData(partNum)

                If Not IsNothing(Me._dtScanSNs) Then
                    For Each row In Me._dtScanSNs.Rows
                        For Each sn In Me._dtValidateSNs.Rows
                            If sn.Item("SN") = row.Item("SN") Then
                                boolFound = True
                                Exit For
                            Else
                                serialno = row.Item("SN")
                            End If
                        Next
                        If boolFound = False Then
                            MessageBox.Show("SN: " & serialno & " is not found in order. Please contact IT.", "ValidateSN", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            txtScan.Enabled = False
                            serialno = ""
                        End If
                        boolFound = False
                    Next
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ValidateSN", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub CreateGTN14File()
            Dim dtShipData As DataTable
            Dim row As DataRow
            Dim strGTN14 As String = String.Empty
            Dim datetime As String = Format(Now, "yyyyMM-dd HH:mm:ss")
            Dim iGTN14Qty As Integer = 0
            Dim strUPC As String = ""
            Dim i As Integer = 0
            Dim pad As Char = "0"c
            Dim strItemDesc As String = ""
            Dim strItem As String = ""

            'dtShipData = Me._objPickPackShip.getOrderForShipData(Me._iSoHeaderID)
            strGTN14 = "1-Ship_To_Company,2-Ship_To_Attention,3-Ship_To_Address_1,4-Ship_To_Address_2,5-Ship_To_City,6-Ship_To_State\Provence,7-Zip COde, 8-Purchase Order,9-Pack Size,10-Item Number,11-Item Description,12-UPC Number" & vbCrLf
            'strGTN14 = strGTN14 + "MEIJERS,DF 801,S County Road 25A,,TIPP CITY,OH,45371,208763633,3,TWSAS327VC3PWP,TW SAMSUNG S327VL CDMA HANDSET,0061696021042"

            'For Each row In dtShipData.Rows 'each order
            '    strGTN14 = strGTN14 & _dtPackData.Rows(0)("Customer").ToString() + "," & _dtPackData.Rows(0)("CustomerAdditionalName1").ToString() & "," _
            '                        & _dtPackData.Rows(0)("CustomerAddress1").ToString() & "," & _dtPackData.Rows(0)("CustomerAddress2").ToString() & "," _
            '                        & _dtPackData.Rows(0)("CustomerCity").ToString() + "," & _dtPackData.Rows(0)("CustomerState").ToString() & "," _
            '                        & _dtPackData.Rows(0)("CustomerPostalCode").ToString() & "," & _dtPackData.Rows(0)("OrderNo").ToString() & "," _
            '                        & "3,TWSAS327VC3PWP,TW SAMSUNG S327VL CDMA HANDSET,0061696021042" & vbCrLf
            'Next

            For Each row In Me._dtPackData.Rows 'each row (i.e., each item or SKU)
                iGTN14Qty = Convert.ToInt32(row("GTN14_Qty"))
                strUPC = Convert.ToString(row("UPC"))
                If strUPC.Trim.Length >= 13 Then
                    strUPC = Microsoft.VisualBasic.Right(strUPC, 13)
                Else
                    strUPC = strUPC.PadLeft(13, pad)
                End If
                strItem = Convert.ToString(row("ItemName")).Trim
                strItemDesc = Convert.ToString(row("ItemDesc")).Trim
                strUPC &= PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK.GetCheckSumDigit(strUPC).ToString

                If iGTN14Qty > 0 Then
                    For i = 1 To iGTN14Qty
                        strGTN14 = strGTN14 & row("Customer").ToString() + "," & row("CustomerAdditionalName1").ToString() & "," _
                                            & row("CustomerAddress1").ToString() & "," & row("CustomerAddress2").ToString() & "," _
                                            & row("CustomerCity").ToString() + "," & row("CustomerState").ToString() & "," _
                                            & row("CustomerPostalCode").ToString() & "," & row("ClientCustomerOrder").ToString() & "," _
                                            & "3," & strItem & "," & strItemDesc & "," & strUPC & vbCrLf
                    Next
                End If
            Next

            Dim fs As New System.IO.FileStream("\\PHQ-FILE\Public\Dept\BarTender\Integrations\GTIN14\gtin14.txt", System.IO.FileMode.Create, System.IO.FileAccess.Write)
            Dim file As New System.IO.StreamWriter(fs)
            file.WriteLine(strGTN14)
            file.Close()
        End Sub

        Private Sub CreateSSC18File(ByVal strBol As String)
            Dim strSSCC18 As String = String.Empty
            Dim datetime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
            Dim iSSCC_Part As Integer = 0

            Dim strPreFix As String = "10616960" 'Lenth of 8 digits
            Dim strUCC As String = ""

            strUCC = Me._objPack.getSSCC18Part(iSSCC_Part)  'Length of 9 digits
            strUCC = strPreFix & strUCC '17 digits
            strUCC &= PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK.GetCheckSumDigit(strUCC).ToString 'add a checksum digit, total 18 digits

            If iSSCC_Part > 0 Then Me._objPack.UpdateSSCC18Full(iSSCC_Part, strUCC) 'update to keep SSCC18 

            strSSCC18 = "1-Company,2-Address Line 1, 3-Address Line 2, 4-City, 5-State, 6-Zip, 7- Bol Number,8-UCC Number,9-PO Number" & vbCrLf
            strSSCC18 = strSSCC18 & _dtPackData.Rows(0)("Customer").ToString() & "," & _dtPackData.Rows(0)("CustomerAddress1").ToString() & "," _
                       & _dtPackData.Rows(0)("CustomerAddress2").ToString() & "," & _dtPackData.Rows(0)("CustomerCity").ToString() & "," _
                       & _dtPackData.Rows(0)("CustomerState").ToString() & "," & _dtPackData.Rows(0)("CustomerPostalCode").ToString() & "," _
                       & strBol & "," & strUCC & "," & _dtPackData.Rows(0)("ClientCustomerOrder").ToString()

            Dim fs As New System.IO.FileStream("\\PHQ-FILE\Public\Dept\BarTender\Integrations\SCC18\scc18.txt", System.IO.FileMode.Create, System.IO.FileAccess.Write)
            Dim file As New System.IO.StreamWriter(fs)
            file.Write(strSSCC18)
            file.Close()
        End Sub

        Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
            RestartUI()
        End Sub



        'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        '    'Dim z As Integer = Me._objPack.UpdateSoHeader_removeLock(Me._dtPackData.Rows(0)("SOHeaderID").ToString())



        'End Sub



        Private Sub btnCopy2Clipboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopy2Clipboard.Click
            Try
                CopyToClipBoardAnsSaveToFile()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, " btnCopy2Clipboard_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub CopyToClipBoardAnsSaveToFile()
            Dim row As DataRow
            Dim col As DataColumn
            Dim strRes As String = ""
            Dim strS As String = ""
            Dim i As Integer = 0
            Dim j As Integer = 0
            Dim strSeparater As String = ";"

            Dim strPathFile As String = ""
            Dim strPSSNET_User As String = PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK.RemoveAllSpaces(Me._strUser, False).Replace("'", "")

            Try
                '(1) send order no to clipboard==========================================================
                For Each col In Me._dtScanSNs.Columns
                    If strS.Trim.Length = 0 Then
                        strS = col.ColumnName
                    Else
                        strS &= strSeparater & col.ColumnName
                    End If
                Next
                strRes = strS & Environment.NewLine 'Header
                strS = ""
                For i = 0 To Me._dtScanSNs.Rows.Count - 1
                    strS = ""
                    For j = 0 To Me._dtScanSNs.Columns.Count - 1
                        If strS.Trim.Length = 0 Then
                            strS = Me._dtScanSNs.Rows(i).Item(j)
                        Else
                            strS &= strSeparater & Me._dtScanSNs.Rows(i).Item(j)
                        End If
                    Next
                    strRes &= strS & Environment.NewLine
                Next
                System.Windows.Forms.Clipboard.SetDataObject(strRes, False)

                '(2) Save file======================================================================
                Try
                    'Dim path As String = "c:\temp\MyTest.txt"
                    strPathFile = PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK._LogFilePath & "\TFFK_" & Me._strComputerName
                    '& Format(Now, "yyyyMMddHHmmss") & ".txt"
                    If strPSSNET_User.Trim.Length > 0 Then strPathFile &= "_" & strPSSNET_User.Trim
                    strPathFile &= "_" & Format(Now, "yyyyMMddHHmmss") & ".txt"

                    Try
                        ' Create or overwrite the file.
                        Dim fs As FileStream = File.Create(strPathFile)
                        ' Add text to the file.
                        Dim info As Byte() = New UTF8Encoding(True).GetBytes(strRes)
                        fs.Write(info, 0, info.Length)
                        fs.Close()
                    Catch ex As Exception ' if above path file includes invalid chararter, try this:
                        strPathFile = PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK._LogFilePath & "\TFFK_" & Format(Now, "yyyyMMddHHmmss") & ".txt"
                        ' Create or overwrite the file.
                        Dim fs As FileStream = File.Create(strPathFile)
                        ' Add text to the file.
                        Dim info As Byte() = New UTF8Encoding(True).GetBytes(strRes)
                        fs.Write(info, 0, info.Length)
                        fs.Close()
                    End Try
                Catch ex As Exception
                End Try
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CopyToClipBoard", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub txtHowManyLastDigits_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHowManyLastDigits.KeyPress
            'Allow to enter integer only
            Try
                If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
                    'MessageBox.Show("Please enter numbers only")
                    e.Handled = True
                End If
            Catch ex As Exception
                Me.txtHowManyLastDigits.Text = Me._iDefaultTrackingLength
            End Try
        End Sub


        Private Sub tdgData1_FetchCellStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs) Handles tdgData1.FetchCellStyle
            Dim iShipQty As Integer = 0
            Try
                iShipQty = CInt(Me.tdgData1.Columns("ShipQty").CellText(e.Row))
                If iShipQty > 0 Then
                    e.CellStyle.ForeColor = Color.Blue 'Purple
                    'e.CellStyle.Font.Style.Bold = FontStyle.Bold
                End If
                ' e.CellStyle.BackColor = Color.Yellow
            Catch ex As Exception
            End Try
        End Sub


    End Class
End Namespace
