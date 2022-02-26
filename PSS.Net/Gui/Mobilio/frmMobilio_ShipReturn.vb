Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui
    Public Class frmMobilio_ShipReturn
        Inherits System.Windows.Forms.Form

        Private _iMenuCustID As Integer = 0
        Private _objMShip As Mobilio_Shipping
        Private _iActionID As Integer = 0

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal iCustID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _iMenuCustID = iCustID
            _objMShip = New Mobilio_Shipping()
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
        Friend WithEvents btnSelectOrder As System.Windows.Forms.Button
        Friend WithEvents btnClearSelection As System.Windows.Forms.Button
        Friend WithEvents txtDeviceID As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents pnlShipDevice As System.Windows.Forms.Panel
        Friend WithEvents lstDeviceIDs As System.Windows.Forms.ListBox
        Friend WithEvents btnShip As System.Windows.Forms.Button
        Friend WithEvents lblScanQty As System.Windows.Forms.Label
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents btnRemoveAll As System.Windows.Forms.Button
        Friend WithEvents btnRemoveOne As System.Windows.Forms.Button
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents txtTrackingNo As System.Windows.Forms.TextBox
        Friend WithEvents dgReadyToReturnOrders As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lblReturnQty As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents btnRefreshOrders As System.Windows.Forms.Button
        Friend WithEvents lblPO As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMobilio_ShipReturn))
            Me.dgReadyToReturnOrders = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnSelectOrder = New System.Windows.Forms.Button()
            Me.btnClearSelection = New System.Windows.Forms.Button()
            Me.btnRefreshOrders = New System.Windows.Forms.Button()
            Me.txtDeviceID = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.pnlShipDevice = New System.Windows.Forms.Panel()
            Me.lblReturnQty = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.txtTrackingNo = New System.Windows.Forms.TextBox()
            Me.btnRemoveAll = New System.Windows.Forms.Button()
            Me.btnRemoveOne = New System.Windows.Forms.Button()
            Me.lblScanQty = New System.Windows.Forms.Label()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.btnShip = New System.Windows.Forms.Button()
            Me.lstDeviceIDs = New System.Windows.Forms.ListBox()
            Me.lblPO = New System.Windows.Forms.Label()
            CType(Me.dgReadyToReturnOrders, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlShipDevice.SuspendLayout()
            Me.SuspendLayout()
            '
            'dgReadyToReturnOrders
            '
            Me.dgReadyToReturnOrders.AllowUpdate = False
            Me.dgReadyToReturnOrders.AlternatingRows = True
            Me.dgReadyToReturnOrders.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dgReadyToReturnOrders.FilterBar = True
            Me.dgReadyToReturnOrders.GroupByCaption = "Drag a column header here to group by that column"
            Me.dgReadyToReturnOrders.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dgReadyToReturnOrders.Location = New System.Drawing.Point(8, 8)
            Me.dgReadyToReturnOrders.Name = "dgReadyToReturnOrders"
            Me.dgReadyToReturnOrders.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dgReadyToReturnOrders.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dgReadyToReturnOrders.PreviewInfo.ZoomFactor = 75
            Me.dgReadyToReturnOrders.Size = New System.Drawing.Size(864, 256)
            Me.dgReadyToReturnOrders.TabIndex = 5
            Me.dgReadyToReturnOrders.TabStop = False
            Me.dgReadyToReturnOrders.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;}Normal{BackColor:SteelBlue;}Selected{ForeColo" & _
            "r:HighlightText;BackColor:Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{" & _
            "}Style16{}Style17{}Style10{AlignHorz:Near;}Style11{}OddRow{BackColor:LightSteelB" & _
            "lue;}Style13{}Style12{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;" & _
            "}RecordSelector{AlignImage:Center;}Footer{}Style21{}Style20{}Inactive{ForeColor:" & _
            "InactiveCaptionText;BackColor:InactiveCaption;}EvenRow{BackColor:NavajoWhite;}He" & _
            "ading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlTex" & _
            "t;AlignVert:Center;}FilterBar{Font:Microsoft Sans Serif, 9.75pt, style=Bold;Fore" & _
            "Color:Red;BackColor:White;}Style4{}Style9{}Style8{}Style5{}Group{AlignVert:Cente" & _
            "r;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style7{}Style6{}Style1{}Style3{" & _
            "}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" Alternat" & _
            "ingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeigh" & _
            "t=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17""" & _
            " DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>2" & _
            "52</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 860, 252<" & _
            "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
            "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
            "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
            "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
            "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
            "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
            "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
            "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
            "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 860, 252</ClientArea><Pr" & _
            "intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
            "Style21"" /></Blob>"
            '
            'btnSelectOrder
            '
            Me.btnSelectOrder.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.btnSelectOrder.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(192, Byte), CType(0, Byte))
            Me.btnSelectOrder.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSelectOrder.Location = New System.Drawing.Point(248, 272)
            Me.btnSelectOrder.Name = "btnSelectOrder"
            Me.btnSelectOrder.Size = New System.Drawing.Size(152, 23)
            Me.btnSelectOrder.TabIndex = 8
            Me.btnSelectOrder.TabStop = False
            Me.btnSelectOrder.Text = "Select Order To Ship"
            '
            'btnClearSelection
            '
            Me.btnClearSelection.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.btnClearSelection.BackColor = System.Drawing.Color.SteelBlue
            Me.btnClearSelection.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClearSelection.ForeColor = System.Drawing.Color.White
            Me.btnClearSelection.Location = New System.Drawing.Point(160, 272)
            Me.btnClearSelection.Name = "btnClearSelection"
            Me.btnClearSelection.Size = New System.Drawing.Size(56, 23)
            Me.btnClearSelection.TabIndex = 6
            Me.btnClearSelection.TabStop = False
            Me.btnClearSelection.Text = "Clear"
            '
            'btnRefreshOrders
            '
            Me.btnRefreshOrders.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.btnRefreshOrders.BackColor = System.Drawing.Color.SteelBlue
            Me.btnRefreshOrders.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRefreshOrders.ForeColor = System.Drawing.Color.White
            Me.btnRefreshOrders.Location = New System.Drawing.Point(8, 272)
            Me.btnRefreshOrders.Name = "btnRefreshOrders"
            Me.btnRefreshOrders.Size = New System.Drawing.Size(120, 23)
            Me.btnRefreshOrders.TabIndex = 7
            Me.btnRefreshOrders.TabStop = False
            Me.btnRefreshOrders.Text = "Refresh List"
            '
            'txtDeviceID
            '
            Me.txtDeviceID.BackColor = System.Drawing.Color.White
            Me.txtDeviceID.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDeviceID.Location = New System.Drawing.Point(112, 8)
            Me.txtDeviceID.MaxLength = 25
            Me.txtDeviceID.Name = "txtDeviceID"
            Me.txtDeviceID.Size = New System.Drawing.Size(216, 21)
            Me.txtDeviceID.TabIndex = 0
            Me.txtDeviceID.Text = ""
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Black
            Me.Label1.Location = New System.Drawing.Point(24, 8)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(80, 21)
            Me.Label1.TabIndex = 222
            Me.Label1.Text = "Device ID:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'pnlShipDevice
            '
            Me.pnlShipDevice.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.pnlShipDevice.BackColor = System.Drawing.Color.LightSteelBlue
            Me.pnlShipDevice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlShipDevice.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblPO, Me.lblReturnQty, Me.Label4, Me.Label2, Me.txtTrackingNo, Me.btnRemoveAll, Me.btnRemoveOne, Me.lblScanQty, Me.Label9, Me.btnShip, Me.lstDeviceIDs, Me.Label1, Me.txtDeviceID})
            Me.pnlShipDevice.Location = New System.Drawing.Point(8, 312)
            Me.pnlShipDevice.Name = "pnlShipDevice"
            Me.pnlShipDevice.Size = New System.Drawing.Size(864, 192)
            Me.pnlShipDevice.TabIndex = 223
            Me.pnlShipDevice.Visible = False
            '
            'lblReturnQty
            '
            Me.lblReturnQty.BackColor = System.Drawing.Color.Black
            Me.lblReturnQty.Font = New System.Drawing.Font("Tahoma", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblReturnQty.ForeColor = System.Drawing.Color.Lime
            Me.lblReturnQty.Location = New System.Drawing.Point(16, 56)
            Me.lblReturnQty.Name = "lblReturnQty"
            Me.lblReturnQty.Size = New System.Drawing.Size(72, 40)
            Me.lblReturnQty.TabIndex = 232
            Me.lblReturnQty.Text = "0"
            Me.lblReturnQty.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.Black
            Me.Label4.Location = New System.Drawing.Point(16, 32)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(72, 21)
            Me.Label4.TabIndex = 231
            Me.Label4.Text = "Return Qty"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.Black
            Me.Label2.Location = New System.Drawing.Point(352, 136)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(80, 21)
            Me.Label2.TabIndex = 230
            Me.Label2.Text = "Tracking #:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtTrackingNo
            '
            Me.txtTrackingNo.BackColor = System.Drawing.Color.White
            Me.txtTrackingNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtTrackingNo.Location = New System.Drawing.Point(440, 136)
            Me.txtTrackingNo.MaxLength = 25
            Me.txtTrackingNo.Name = "txtTrackingNo"
            Me.txtTrackingNo.Size = New System.Drawing.Size(216, 21)
            Me.txtTrackingNo.TabIndex = 1
            Me.txtTrackingNo.Text = ""
            '
            'btnRemoveAll
            '
            Me.btnRemoveAll.BackColor = System.Drawing.Color.Red
            Me.btnRemoveAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveAll.ForeColor = System.Drawing.Color.White
            Me.btnRemoveAll.Location = New System.Drawing.Point(504, 72)
            Me.btnRemoveAll.Name = "btnRemoveAll"
            Me.btnRemoveAll.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRemoveAll.Size = New System.Drawing.Size(112, 24)
            Me.btnRemoveAll.TabIndex = 228
            Me.btnRemoveAll.Text = "REMOVE ALL"
            '
            'btnRemoveOne
            '
            Me.btnRemoveOne.BackColor = System.Drawing.Color.Red
            Me.btnRemoveOne.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveOne.ForeColor = System.Drawing.Color.White
            Me.btnRemoveOne.Location = New System.Drawing.Point(360, 72)
            Me.btnRemoveOne.Name = "btnRemoveOne"
            Me.btnRemoveOne.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRemoveOne.Size = New System.Drawing.Size(112, 24)
            Me.btnRemoveOne.TabIndex = 227
            Me.btnRemoveOne.Text = "REMOVE ONE"
            '
            'lblScanQty
            '
            Me.lblScanQty.BackColor = System.Drawing.Color.Black
            Me.lblScanQty.Font = New System.Drawing.Font("Tahoma", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblScanQty.ForeColor = System.Drawing.Color.Lime
            Me.lblScanQty.Location = New System.Drawing.Point(16, 128)
            Me.lblScanQty.Name = "lblScanQty"
            Me.lblScanQty.Size = New System.Drawing.Size(72, 40)
            Me.lblScanQty.TabIndex = 226
            Me.lblScanQty.Text = "0"
            Me.lblScanQty.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'Label9
            '
            Me.Label9.BackColor = System.Drawing.Color.Transparent
            Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.Black
            Me.Label9.Location = New System.Drawing.Point(16, 104)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(72, 21)
            Me.Label9.TabIndex = 225
            Me.Label9.Text = "Scan Qty"
            Me.Label9.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'btnShip
            '
            Me.btnShip.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(192, Byte), CType(0, Byte))
            Me.btnShip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnShip.Location = New System.Drawing.Point(680, 136)
            Me.btnShip.Name = "btnShip"
            Me.btnShip.Size = New System.Drawing.Size(112, 21)
            Me.btnShip.TabIndex = 224
            Me.btnShip.TabStop = False
            Me.btnShip.Text = "Ship"
            '
            'lstDeviceIDs
            '
            Me.lstDeviceIDs.Location = New System.Drawing.Point(112, 40)
            Me.lstDeviceIDs.Name = "lstDeviceIDs"
            Me.lstDeviceIDs.Size = New System.Drawing.Size(216, 121)
            Me.lstDeviceIDs.TabIndex = 223
            Me.lstDeviceIDs.TabStop = False
            '
            'lblPO
            '
            Me.lblPO.BackColor = System.Drawing.Color.Black
            Me.lblPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPO.ForeColor = System.Drawing.Color.Lime
            Me.lblPO.Location = New System.Drawing.Point(360, 8)
            Me.lblPO.Name = "lblPO"
            Me.lblPO.Size = New System.Drawing.Size(256, 32)
            Me.lblPO.TabIndex = 233
            Me.lblPO.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'frmMobilio_ShipReturn
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(880, 518)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlShipDevice, Me.btnSelectOrder, Me.btnClearSelection, Me.btnRefreshOrders, Me.dgReadyToReturnOrders})
            Me.Name = "frmMobilio_ShipReturn"
            Me.Text = "frmMobilio_ShipReturn"
            CType(Me.dgReadyToReturnOrders, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlShipDevice.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        '***********************************************************************************************************************************
        Private Sub frmMobilio_ShipReturn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                LoadOpenOrderToReturn()
                PSS.Core.Highlight.SetHighLight(Me)

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Sub LoadOpenOrderToReturn()
            Dim dt As DataTable
            Dim i As Integer

            Try
                dt = Me._objMShip.GetReadyToReturnOrders(Me._iMenuCustID, )
                With Me.dgReadyToReturnOrders
                    .DataSource = Nothing
                    .DataSource = dt.DefaultView
                    For i = 0 To .Columns.Count - 1
                        If .Columns(i).Caption = "PO" Then
                            .Splits(0).DisplayColumns(i).Width = 100
                        ElseIf .Columns(i).Caption = "Qty" Then
                            .Splits(0).DisplayColumns(i).Width = 40
                        ElseIf .Columns(i).Caption = "Shipment Trans ID" OrElse .Columns(i).Caption = "Order Rec Date" OrElse .Columns(i).Caption = "Completed Item Rec Date" Then
                            .Splits(0).DisplayColumns(i).Width = 120
                        ElseIf .Columns(i).Caption = "Name" Then
                            .Splits(0).DisplayColumns(i).Width = 120
                        ElseIf .Columns(i).Caption = "Address" Then
                            .Splits(0).DisplayColumns(i).Width = 150
                        ElseIf .Columns(i).Caption = "City" Then
                            .Splits(0).DisplayColumns(i).Width = 70
                        ElseIf .Columns(i).Caption = "State" Then
                            .Splits(0).DisplayColumns(i).Width = 60
                        ElseIf .Columns(i).Caption = "Zip" Then
                            .Splits(0).DisplayColumns(i).Width = 50
                        Else
                            .Splits(0).DisplayColumns(i).Visible = False
                        End If
                    Next i
                End With
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Sub btnRefreshOrders_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshOrders.Click
            Try
                btnClearSelection_Click(Nothing, Nothing)
                LoadOpenOrderToReturn()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Sub btnClearSelection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearSelection.Click
            Try
                _iActionID = 0
                Me.dgReadyToReturnOrders.Enabled = True
                Me.lblReturnQty.Text = ""
                Me.lblScanQty.Text = ""
                Me.txtDeviceID.Text = ""
                Me.txtTrackingNo.Text = ""
                Me.lstDeviceIDs.Items.Clear()
                Me.pnlShipDevice.Visible = False

                Me.lblPO.Text = ""

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Sub btnSelectOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectOrder.Click
            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                ProcessReturnOrder()
                Me.dgReadyToReturnOrders.Enabled = False
                Me.pnlShipDevice.Visible = True

                Me.Enabled = True : Me.txtDeviceID.SelectAll() : Me.txtDeviceID.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnSelectOrder_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Sub ProcessReturnOrder()
            Try
                If Me.dgReadyToReturnOrders.RowCount > 0 AndAlso Me.dgReadyToReturnOrders.Columns.Count > 0 Then
                    If Me.dgReadyToReturnOrders.Columns("mb_OrderID").CellValue(Me.dgReadyToReturnOrders.Row) > 0 Then
                        If Not IsDBNull(Me.dgReadyToReturnOrders.Columns("Qty").CellValue(Me.dgReadyToReturnOrders.Row)) Then Me.lblReturnQty.Text = Me.dgReadyToReturnOrders.Columns("Qty").CellValue(Me.dgReadyToReturnOrders.Row) Else Me.lblReturnQty.Text = "0"
                        Me.lblPO.Text = Me.dgReadyToReturnOrders.Columns("PO").CellValue(Me.dgReadyToReturnOrders.Row)
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Sub txtDeviceID_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDeviceID.KeyUp
            Try
                If e.KeyValue = Keys.Enter AndAlso Me.txtDeviceID.Text.Trim.Length > 0 Then
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                    If Me.lstDeviceIDs.Items.IndexOf(Me.txtDeviceID.Text.Trim.ToUpper) >= 0 Then
                        MessageBox.Show("Device is already listed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.Enabled = True : Me.txtDeviceID.SelectAll() : Me.txtDeviceID.Focus()
                    ElseIf Me.lblReturnQty.Text.Trim.Length > 0 AndAlso Me.lstDeviceIDs.Items.Count >= CInt(Me.lblReturnQty.Text) Then
                        MessageBox.Show("You have reached the return quantity.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.Enabled = True : Me.txtDeviceID.SelectAll() : Me.txtDeviceID.Focus()
                    ElseIf ProcessDeviceID(CInt(txtDeviceID.Text)) = True Then
                        Me.lstDeviceIDs.Items.Add(Me.txtDeviceID.Text) : Me.lblScanQty.Text = Me.lstDeviceIDs.Items.Count
                        Me.Enabled = True : Me.txtDeviceID.Text = "" : Me.txtDeviceID.Focus()
                    Else
                        Me.Enabled = True : Me.txtDeviceID.SelectAll() : Me.txtDeviceID.Focus()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "txtDeviceID_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Function ProcessDeviceID(ByVal iDeviceID As Integer) As Boolean
            Dim dt As DataTable
            Dim objRec As New MobilioRec()
            Dim iOrderID As Integer = 0

            Try
                'Get order id
                If Me.dgReadyToReturnOrders.Columns("mb_OrderID").CellValue(Me.dgReadyToReturnOrders.Row).ToString.Trim.Length = 0 Then Throw New Exception("System can't define order id.")
                iOrderID = CInt(Me.dgReadyToReturnOrders.Columns("mb_OrderID").CellValue(Me.dgReadyToReturnOrders.Row))
                If iOrderID = 0 Then Throw New Exception("System can't define order id.")

                'validate quantity
                If Me.lstDeviceIDs.Items.Count > CInt(Me.lblReturnQty.Text) Then Throw New Exception("You have reached return quantity.")

                'get device's data and do validation
                dt = objRec.GetDeviceData(iDeviceID)
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("Device ID does not existed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dt.Rows.Count > 1 Then
                    MessageBox.Show("Duplicate device ID. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf CInt(dt.Rows(0)("mb_OrderID_Inbound")) <> iOrderID Then
                    MessageBox.Show("Device ID does not belong to order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dt.Rows(0)("Status").ToString.Trim.ToLower <> "return" Then
                    MessageBox.Show("Status of device id '" & dt.Rows(0)("DeviceID") & "' is '" & dt.Rows(0)("Status").ToString.Trim & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf CInt(dt.Rows(0)("mb_Pallet_ID")) > 0 Then
                    MessageBox.Show("Device has already assigned to a pallet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Not IsDBNull(dt.Rows(0)("ShippedDate")) Then
                    MessageBox.Show("Device is already been shipped.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf IsDBNull(dt.Rows(0)("mb_MP_ID")) Or Not dt.Rows(0)("mb_MP_ID") > 0 Then
                    MessageBox.Show("Device has no master pack ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    Me._iActionID = CInt(dt.Rows(0)("action_id"))
                    Return True
                End If
            Catch ex As Exception
                Throw New Exception("ProcessDeviceID():" & ex.Message)
            Finally
                objRec = Nothing : Generic.DisposeDT(dt)
            End Try
        End Function

        '***********************************************************************************************************************************
        Private Sub btnRemoveOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveOne.Click
            Dim strDeviceID As String = ""

            Try
                If Me.lstDeviceIDs.Items.Count = 0 Then Exit Sub

                strDeviceID = InputBox("Enter Device ID:", "Device ID").Trim
                If strDeviceID = "" Then Exit Sub

                If Me.lstDeviceIDs.Items.IndexOf(strDeviceID) >= 0 Then
                    Me.lstDeviceIDs.Items.RemoveAt(Me.lstDeviceIDs.Items.IndexOf(strDeviceID))
                    Me.lblScanQty.Text = Me.lstDeviceIDs.Items.Count
                Else
                    MessageBox.Show("Device was not listed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

                Me.txtDeviceID.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Remove Item", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Sub btnRemoveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveAll.Click
            Try
                If Me.lstDeviceIDs.Items.Count = 0 Then Exit Sub

                If MessageBox.Show("Are you sure you want to remove all items in list box?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub

                Me.lstDeviceIDs.Items.Clear() : Me.lstDeviceIDs.Refresh()
                Me.lblScanQty.Text = Me.lstDeviceIDs.Items.Count

                Me.txtDeviceID.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Remove Item", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Sub btnShip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShip.Click
            Dim strDeviceIDs As String = ""
            Dim iOrderID As Integer = 0, i As Integer = 0

            Try
                If Me.dgReadyToReturnOrders.RowCount = 0 Then
                    Exit Sub
                ElseIf Me.lstDeviceIDs.Items.Count = 0 Then
                    Exit Sub
                ElseIf Me.txtTrackingNo.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter tracking #.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.lstDeviceIDs.Items.Count <> CInt(Me.lblReturnQty.Text) Then
                    MessageBox.Show("Quantity does not match. Please verify it.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.RunBilling(strDeviceIDs) = False Then
                    Exit Sub
                Else
                    iOrderID = Me.dgReadyToReturnOrders.Columns("mb_OrderID").CellValue(Me.dgReadyToReturnOrders.Row)

                    i = Me._objMShip.ShipReturnOrder(Me._iMenuCustID, strDeviceIDs, iOrderID, Core.ApplicationUser.IDuser, Me._iActionID, Me.lstDeviceIDs.Items.Count, Me.txtTrackingNo.Text.Trim.ToUpper)
                    If i > 0 Then
                        Me.btnClearSelection_Click(Nothing, Nothing)
                        Me.LoadOpenOrderToReturn()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnShip_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Function RunBilling(ByRef strDeviceIDs As String) As Boolean
            Dim dtFees As DataTable
            Dim drFee As DataRow
            Dim objSortPutAway As New Mobilio_PutAway_FinishedGoods()
            Dim strTemp As String = ""
            Dim i As Integer

            Try
                RunBilling = False
                dtFees = objSortPutAway.GetServiceFees()
                If dtFees.Rows.Count = 0 Then
                    MessageBox.Show("Can't find any service fee.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dtFees.Select("fee_desc = 'Pick/Ship - Individual'").Length = 0 Then
                    MessageBox.Show("Service fee for 'Pick/Ship - Individual' is missing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    drFee = dtFees.Select("fee_desc = 'Pick/Ship - Individual'")(0)

                    For i = 0 To Me.lstDeviceIDs.Items.Count - 1
                        If Me.ProcessDeviceID(CInt(Me.lstDeviceIDs.Items.Item(i))) = False Then Return False

                        If Gui.frmMobilio_PutAwayTote.AddServiceFee(drFee, CInt(Me.lstDeviceIDs.Items.Item(i)), strTemp) = False Then Return False

                        If strDeviceIDs.Trim.Length > 0 Then strDeviceIDs &= ", "
                        strDeviceIDs &= Me.lstDeviceIDs.Items.Item(i)
                    Next i

                    RunBilling = True
                End If

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dtFees) : objSortPutAway = Nothing
            End Try
        End Function

        '***********************************************************************************************************************************

    End Class
End Namespace