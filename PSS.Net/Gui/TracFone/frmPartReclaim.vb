Option Explicit On 

Imports PSS.Data
Imports PSS.Core
Imports PSS.Rules

Namespace Gui
    Public Class frmPartReclaim
        Inherits System.Windows.Forms.Form
        Private Const btnWidth = 120
        Private Const btnHeight = 50

        Private _iMenuCustID As Integer
        Private _iMenuLocID As Integer
        Private _strScreenName As String = ""
        Private _objTFMisc As PSS.Data.Buisness.TracFone.clsMisc
        Private _objNewTech As PSS.Data.Buisness.NewTech
        Private _drDevInfo As DataRow
        Private _dtReclaim As DataTable
        Private _device As Device = Nothing

        Private origFrmWidth As Integer

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal iCustID As Integer, ByVal iLocID As Integer, ByVal strScreenName As String)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _iMenuCustID = iCustID
            _strScreenName = strScreenName
            _iMenuLocID = iLocID

            _objTFMisc = New PSS.Data.Buisness.TracFone.clsMisc()
            _objNewTech = New PSS.Data.Buisness.NewTech()
        End Sub


        Public Sub New(ByVal iCustID As Integer, ByVal iLocID As Integer, ByVal strScreenName As String, ByVal sn As String)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _iMenuCustID = iCustID
            _strScreenName = strScreenName
            _iMenuLocID = iLocID

            _objTFMisc = New PSS.Data.Buisness.TracFone.clsMisc()
            _objNewTech = New PSS.Data.Buisness.NewTech()
            txtSerial.Text = sn
            SendKeys.Send("{ENTER}")
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
        Friend WithEvents btnComplete As System.Windows.Forms.Button
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents tabMain As System.Windows.Forms.TabControl
        Friend WithEvents pnlNeededRVParts As System.Windows.Forms.Panel
        Friend WithEvents txtSerial As System.Windows.Forms.TextBox
        Friend WithEvents lblDeviceSN As System.Windows.Forms.Label
        Friend WithEvents tpReclaimParts As System.Windows.Forms.TabPage
        Friend WithEvents lblPartNo As System.Windows.Forms.Label
        Friend WithEvents lblMaxInv As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents lblBinQty As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents lblReclaimQty As System.Windows.Forms.Label
        Friend WithEvents dgPartsQty As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPartReclaim))
            Me.btnComplete = New System.Windows.Forms.Button()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.tabMain = New System.Windows.Forms.TabControl()
            Me.tpReclaimParts = New System.Windows.Forms.TabPage()
            Me.pnlNeededRVParts = New System.Windows.Forms.Panel()
            Me.txtSerial = New System.Windows.Forms.TextBox()
            Me.lblDeviceSN = New System.Windows.Forms.Label()
            Me.lblPartNo = New System.Windows.Forms.Label()
            Me.lblMaxInv = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.lblBinQty = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.lblReclaimQty = New System.Windows.Forms.Label()
            Me.dgPartsQty = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.tabMain.SuspendLayout()
            Me.tpReclaimParts.SuspendLayout()
            CType(Me.dgPartsQty, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'btnComplete
            '
            Me.btnComplete.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnComplete.BackColor = System.Drawing.Color.Green
            Me.btnComplete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnComplete.ForeColor = System.Drawing.Color.White
            Me.btnComplete.Location = New System.Drawing.Point(784, 24)
            Me.btnComplete.Name = "btnComplete"
            Me.btnComplete.Size = New System.Drawing.Size(112, 22)
            Me.btnComplete.TabIndex = 129
            Me.btnComplete.Text = "Complete Device"
            Me.btnComplete.Visible = False
            '
            'btnClear
            '
            Me.btnClear.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClear.ForeColor = System.Drawing.Color.White
            Me.btnClear.Location = New System.Drawing.Point(912, 24)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(64, 22)
            Me.btnClear.TabIndex = 128
            Me.btnClear.Text = "&Clear"
            '
            'tabMain
            '
            Me.tabMain.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.tabMain.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpReclaimParts})
            Me.tabMain.Location = New System.Drawing.Point(8, 56)
            Me.tabMain.Name = "tabMain"
            Me.tabMain.SelectedIndex = 0
            Me.tabMain.Size = New System.Drawing.Size(976, 472)
            Me.tabMain.TabIndex = 127
            '
            'tpReclaimParts
            '
            Me.tpReclaimParts.Controls.AddRange(New System.Windows.Forms.Control() {Me.dgPartsQty, Me.pnlNeededRVParts})
            Me.tpReclaimParts.Location = New System.Drawing.Point(4, 22)
            Me.tpReclaimParts.Name = "tpReclaimParts"
            Me.tpReclaimParts.Size = New System.Drawing.Size(968, 446)
            Me.tpReclaimParts.TabIndex = 4
            Me.tpReclaimParts.Text = "Reclaim Part(s)"
            Me.tpReclaimParts.Visible = False
            '
            'pnlNeededRVParts
            '
            Me.pnlNeededRVParts.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.pnlNeededRVParts.AutoScroll = True
            Me.pnlNeededRVParts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlNeededRVParts.Location = New System.Drawing.Point(8, 11)
            Me.pnlNeededRVParts.Name = "pnlNeededRVParts"
            Me.pnlNeededRVParts.Size = New System.Drawing.Size(528, 341)
            Me.pnlNeededRVParts.TabIndex = 111
            '
            'txtSerial
            '
            Me.txtSerial.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
            Me.txtSerial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSerial.Location = New System.Drawing.Point(104, 24)
            Me.txtSerial.Name = "txtSerial"
            Me.txtSerial.Size = New System.Drawing.Size(176, 20)
            Me.txtSerial.TabIndex = 125
            Me.txtSerial.Text = ""
            '
            'lblDeviceSN
            '
            Me.lblDeviceSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDeviceSN.ForeColor = System.Drawing.Color.White
            Me.lblDeviceSN.Location = New System.Drawing.Point(8, 24)
            Me.lblDeviceSN.Name = "lblDeviceSN"
            Me.lblDeviceSN.Size = New System.Drawing.Size(88, 16)
            Me.lblDeviceSN.TabIndex = 126
            Me.lblDeviceSN.Text = "Serial Number:"
            Me.lblDeviceSN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblPartNo
            '
            Me.lblPartNo.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.lblPartNo.BackColor = System.Drawing.Color.Black
            Me.lblPartNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPartNo.ForeColor = System.Drawing.Color.Lime
            Me.lblPartNo.Location = New System.Drawing.Point(536, 24)
            Me.lblPartNo.Name = "lblPartNo"
            Me.lblPartNo.Size = New System.Drawing.Size(240, 24)
            Me.lblPartNo.TabIndex = 130
            Me.lblPartNo.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'lblMaxInv
            '
            Me.lblMaxInv.BackColor = System.Drawing.Color.Black
            Me.lblMaxInv.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblMaxInv.ForeColor = System.Drawing.Color.Lime
            Me.lblMaxInv.Location = New System.Drawing.Point(424, 24)
            Me.lblMaxInv.Name = "lblMaxInv"
            Me.lblMaxInv.Size = New System.Drawing.Size(48, 24)
            Me.lblMaxInv.TabIndex = 131
            Me.lblMaxInv.Text = "0"
            Me.lblMaxInv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(421, 8)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(56, 16)
            Me.Label2.TabIndex = 132
            Me.Label2.Text = "Max Inv:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(360, 8)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(48, 16)
            Me.Label1.TabIndex = 134
            Me.Label1.Text = "Cage"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'lblBinQty
            '
            Me.lblBinQty.BackColor = System.Drawing.Color.Black
            Me.lblBinQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBinQty.ForeColor = System.Drawing.Color.Lime
            Me.lblBinQty.Location = New System.Drawing.Point(360, 24)
            Me.lblBinQty.Name = "lblBinQty"
            Me.lblBinQty.Size = New System.Drawing.Size(48, 24)
            Me.lblBinQty.TabIndex = 133
            Me.lblBinQty.Text = "0"
            Me.lblBinQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label3
            '
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(297, 8)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(56, 16)
            Me.Label3.TabIndex = 136
            Me.Label3.Text = "Reclaim"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'lblReclaimQty
            '
            Me.lblReclaimQty.BackColor = System.Drawing.Color.Black
            Me.lblReclaimQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblReclaimQty.ForeColor = System.Drawing.Color.Lime
            Me.lblReclaimQty.Location = New System.Drawing.Point(304, 24)
            Me.lblReclaimQty.Name = "lblReclaimQty"
            Me.lblReclaimQty.Size = New System.Drawing.Size(48, 24)
            Me.lblReclaimQty.TabIndex = 135
            Me.lblReclaimQty.Text = "0"
            Me.lblReclaimQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'dgPartsQty
            '
            Me.dgPartsQty.AllowUpdate = False
            Me.dgPartsQty.AlternatingRows = True
            Me.dgPartsQty.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dgPartsQty.FilterBar = True
            Me.dgPartsQty.GroupByCaption = "Drag a column header here to group by that column"
            Me.dgPartsQty.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dgPartsQty.Location = New System.Drawing.Point(552, 8)
            Me.dgPartsQty.Name = "dgPartsQty"
            Me.dgPartsQty.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dgPartsQty.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dgPartsQty.PreviewInfo.ZoomFactor = 75
            Me.dgPartsQty.Size = New System.Drawing.Size(400, 344)
            Me.dgPartsQty.TabIndex = 112
            Me.dgPartsQty.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;}Normal{BackColor:SteelBlue;}Selected{ForeColo" & _
            "r:HighlightText;BackColor:Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{" & _
            "}Style16{}Style17{}Style10{AlignHorz:Near;}Style11{}OddRow{BackColor:LightSteelB" & _
            "lue;}Style13{}Style12{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;" & _
            "}RecordSelector{AlignImage:Center;}Footer{}Style21{}Style20{}Inactive{ForeColor:" & _
            "InactiveCaptionText;BackColor:InactiveCaption;}EvenRow{BackColor:NavajoWhite;}He" & _
            "ading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText" & _
            ";BackColor:Control;}FilterBar{Font:Microsoft Sans Serif, 9.75pt, style=Bold;Fore" & _
            "Color:Red;BackColor:White;}Style4{}Style9{}Style8{}Style5{}Group{BackColor:Contr" & _
            "olDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style7{}Style6{}Style1{}Style3{" & _
            "}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" Alternat" & _
            "ingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeigh" & _
            "t=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17""" & _
            " DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>3" & _
            "40</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 396, 340<" & _
            "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
            "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
            "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
            "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
            "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
            "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
            "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
            "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
            "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 396, 340</ClientArea><Pr" & _
            "intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
            "Style21"" /></Blob>"
            '
            'frmPartReclaim
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(992, 550)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label3, Me.lblReclaimQty, Me.Label1, Me.lblBinQty, Me.Label2, Me.lblMaxInv, Me.lblPartNo, Me.btnComplete, Me.btnClear, Me.tabMain, Me.txtSerial, Me.lblDeviceSN})
            Me.Name = "frmPartReclaim"
            Me.Text = "frmPartReclaim"
            Me.tabMain.ResumeLayout(False)
            Me.tpReclaimParts.ResumeLayout(False)
            CType(Me.dgPartsQty, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '**********************************************************************************************************************
        Private Sub frmPartReclaim_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                origFrmWidth = Me.Width
                txtSerial.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmPartReclaim_Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '**********************************************************************************************************************
        Private Sub txtSerial_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSerial.KeyDown
            If e.KeyValue = 13 AndAlso Me.txtSerial.Text.Trim.Length > 0 Then
                Me.ProcessSN()
            End If
        End Sub

        '**********************************************************************************************************************
        Private Sub ProcessSN()
            Dim strDeviceSN As String = ""
            Dim dt As DataTable
            Dim booValidate As Boolean = True

            Try
                '******************************
                'Clear controls and variables
                '******************************
                strDeviceSN = Me.txtSerial.Text.Trim.ToUpper
                Me.btnClear_Click(Nothing, Nothing)
                Me.txtSerial.Text = strDeviceSN
                '******************************
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                dt = Me._objNewTech.GetReclaimDevice(Me._iMenuLocID, txtSerial.Text)

                If dt.Rows.Count = 0 Then
                    MessageBox.Show("SN/IMEI does not exist in the system or already has a pallet assigned to it.", "information", MessageBoxButtons.OK)
                    Me.txtSerial.SelectAll() : Me.txtSerial.Focus() : Exit Sub
                ElseIf dt.Rows.Count > 1 Then
                    MessageBox.Show("SN/IMEI existed more than one in the system. Please contact your lead or supervisor.", "information", MessageBoxButtons.OK)
                    Me.txtSerial.SelectAll() : Me.txtSerial.Focus() : Exit Sub
                End If

                If Me._iMenuCustID = Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID Then
                    If Me.ValidateDevice_Tracfone(dt) = False Then
                        Me.Enabled = True : Me.txtSerial.SelectAll() : Me.txtSerial.Focus() : Exit Sub
                    End If
                ElseIf Me._iMenuCustID = Data.Buisness.NI.CUSTOMERID Then
                    If Me.ValidateDevice_NI(dt) = False Then
                        Me.Enabled = True : Me.txtSerial.SelectAll() : Me.txtSerial.Focus()
                    End If
                Else
                    If Me.ValidateDevice(dt) = False Then
                        Me.Enabled = True : Me.txtSerial.SelectAll() : Me.txtSerial.Focus()
                    End If
                End If

                Me._drDevInfo = dt.Rows(0)
                LoadDevice(CInt(Me._drDevInfo("Device_ID")))
                _dtReclaim = Me._objNewTech.GetReclaimParts(CInt(Me._drDevInfo("Device_ID")))
                LoadBillCodes()

                Me.LoadPartQty(CInt(Me._drDevInfo("Device_ID")), 0)
                Me.HighLightSelectedButtons()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "SN KeyDownEvent", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.btnClear_Click(Nothing, Nothing)
            Finally
                Cursor.Current = Cursors.Default : Me.Enabled = True
                Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '**********************************************************************************************************************
        Private Function ValidateDevice_Tracfone(ByVal dt As DataTable) As Boolean
            Dim objTFMisc As New Buisness.TracFone.clsMisc()

            Try
                ValidateDevice_Tracfone = True

                If Misc.ValidateFrStationOfScreenInWorkFlow(Me._strScreenName, dt.Rows(0)("WorkStation").ToString, Me._iMenuCustID, 0, False) = False Then
                    Return False
                ElseIf Buisness.Generic.GetMaxBillRule(CInt(dt.Rows(0)("Device_ID"))) <= 0 Then
                    MessageBox.Show("Device does not mark as RUR/BER.", "information", MessageBoxButtons.OK)
                    Return False
                End If

            Catch ex As Exception
                Throw ex
            Finally
                objTFMisc = Nothing
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '**********************************************************************************************************************
        Private Function ValidateDevice_NI(ByVal dt As DataTable) As Boolean
            Dim drNotInWip As DataRow()
            Dim i As Integer

            Try
                ValidateDevice_NI = True

                If PSS.Data.Buisness.NI.GetRepairType(dt.Rows(0)("WO_ID"))(1) = "repairthisunit" Then
                    MessageBox.Show("Can't reclaim part on 'repairthisunit' repair type.", "information", MessageBoxButtons.OK)
                    Return False
                End If

            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '**********************************************************************************************************************
        Private Function ValidateDevice(ByVal dt As DataTable) As Boolean
            Dim drNotInWip As DataRow()
            Dim i As Integer

            Try
                ValidateDevice = True

                If Buisness.Generic.GetMaxBillRule(CInt(dt.Rows(0)("Device_ID"))) <= 0 Then
                    MessageBox.Show("Device does not mark as RUR/BER.", "information", MessageBoxButtons.OK)
                    Return False
                End If

            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '**********************************************************************************************************************
        Private Sub LoadPartQty(ByVal iDeviceID As Integer, ByVal iBillcodeID As Integer)
            Dim dt As DataTable
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn

            Try
                dt = Me._objNewTech.GetPartQty(iDeviceID)
                With Me.dgPartsQty
                    .DataSource = dt.DefaultView

                    For Each dbgc In .Splits(0).DisplayColumns
                        dbgc.Locked = True
                        dbgc.AutoSize()
                    Next dbgc

                    .Splits(0).DisplayColumns("CagePlusReclaim").Visible = False
                    .Splits(0).DisplayColumns("Billcode_ID").Visible = False
                End With

                If iBillcodeID > 0 Then
                    If dt.Select("Billcode_ID = " & iBillcodeID).Length > 0 Then Me.lblBinQty.Text = dt.Select("Billcode_ID = " & iBillcodeID)(0)("Cage") Else Me.lblBinQty.Text = "0"
                    If dt.Select("Billcode_ID = " & iBillcodeID).Length > 0 Then Me.lblReclaimQty.Text = dt.Select("Billcode_ID = " & iBillcodeID)(0)("Re-claim") Else Me.lblReclaimQty.Text = "0"
                    If Me.lblMaxInv.Text.Trim.Length > 0 AndAlso CInt(Me.lblMaxInv.Text) > 0 AndAlso (CInt(Me.lblBinQty.Text) + CInt(Me.lblReclaimQty.Text)) >= CInt(Me.lblMaxInv.Text) Then
                        Me.lblReclaimQty.BackColor = Color.Red
                    Else
                        Me.lblReclaimQty.BackColor = Color.Black
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '**********************************************************************************************************************
        Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
            Try
                Me.txtSerial.Enabled = True : txtSerial.Text = ""
                Me.lblPartNo.Text = ""

                Me.pnlNeededRVParts.Controls.Clear()
                tabMain.Visible = True

                _drDevInfo = Nothing
                PSS.Data.Buisness.Generic.DisposeDT(Me._dtReclaim)
                If Not IsNothing(Me._device) Then
                    Me._device.Dispose() : Me._device = Nothing
                End If

                Me.lblReclaimQty.Text = "0" : Me.lblReclaimQty.BackColor = Color.Black
                Me.lblBinQty.Text = "0"
                Me.lblMaxInv.Text = "0"

                Me.dgPartsQty.DataSource = Nothing

                txtSerial.Focus()
                Me.txtSerial.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnClear_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***************************************************************************************************
        Private Sub LoadDevice(ByVal iDeviceID As Integer)
            Try
                _device = Nothing
                _device = New Device(iDeviceID)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '**********************************************************************************************************************
        Private Sub LoadBillCodes()
            Dim dt As DataTable
            Dim objBD As Buisness.DeviceBilling

            Try
                objBD = New Buisness.DeviceBilling()

                dt = objBD.GetPartBillcodes(Me._iMenuCustID, Me._drDevInfo("Model_ID"), 5, , 1)

                createBillingButtons(dt, Me.pnlNeededRVParts)
                System.Windows.Forms.Application.DoEvents()

            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(objBD) Then objBD = Nothing
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '**********************************************************************************************************************
        Private Sub createBillingButtons(ByVal dt As DataTable, ByRef pnlButtons As Windows.Forms.Panel)
            Const vBuffer As Integer = 5
            Const hBuffer As Integer = 5
            Dim btnLeft As Int32 = 5
            Dim btnTop As Int32 = 5

            Dim r As DataRow
            Dim colLength As Integer = 6
            Dim cBill() As Button
            Dim x As Integer = 0, pnlLeft As Integer, pnlWidth As Integer, colCount As Integer

            Try
                '*************************************
                'Create need buttons
                '*************************************
                colCount = 0
                pnlLeft = pnlButtons.Left
                pnlWidth = tabMain.Width - 48

                ReDim cBill(dt.Rows.Count)

                btnLeft = hBuffer
                btnTop = vBuffer

                For x = 0 To dt.Rows.Count - 1
                    r = dt.Rows(x)
                    cBill(x) = New System.Windows.Forms.Button()
                    With cBill(x)
                        .Text = r("BillCode_DESC")
                        .Size = New Size(btnWidth, btnHeight)
                        colCount += 1
                        .Location = New Point(btnLeft, btnTop)
                        .Visible = True
                        .BackColor = Color.LightGray

                        .Tag = r("BillCode_ID")
                        .Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                        AddHandler .Click, AddressOf Me.billingClick_Reclaim
                    End With

                    If colCount > colLength Then
                        btnLeft = btnLeft + btnWidth + 5
                        btnTop = vBuffer
                        colCount = 0
                    Else
                        btnTop = btnTop + btnHeight + 5
                    End If
                Next

                pnlButtons.Controls.AddRange(cBill)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CreateBillingButtons", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                r = Nothing
                cBill = Nothing
            End Try
        End Sub

        '**********************************************************************************************************************
        Private Sub billingClick_Reclaim(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim iRVPart, iConsignedPart As Integer
            Dim drBOMPart As DataRow
            Dim action As String = "", strRegPart As String = ""
            Dim booRVPart As Boolean = False
            Dim decRegPrice As Decimal = 0

            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                iRVPart = 0 : iConsignedPart = 0

                '//Determine action to be performed
                action = "add"
                If Me._dtReclaim.Select("Billcode_ID = " & CInt(sender.tag.ToString)).Length > 0 Then action = "remove"

                '*********************************
                'Define Adding Part #
                '*********************************
                If action = "add" AndAlso Me._device.BillableBillcodes.Select("Billcode_ID = " & CInt(sender.tag.ToString)).Length = 0 Then
                    MessageBox.Show("Billcode ID is missing in billable list. Please refresh the screen.", _
                        "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                Else
                    drBOMPart = Me._device.BillableBillcodes.Select("Billcode_ID = " & CInt(sender.tag.ToString))(0)
                    iRVPart = Me._device.BillableBillcodes.Select("Billcode_ID = " & CInt(sender.tag.ToString))(0)("RVFlag")
                    If iRVPart = 1 Then booRVPart = True
                    iConsignedPart = Me._device.BillableBillcodes.Select("Billcode_ID = " & _
                        CInt(sender.tag.ToString))(0)("PSPrice_ConsignedPart")
                End If

                If booRVPart = False Then
                    MessageBox.Show("None RV part should not listed in this tab. Please contact your suppervisor.", _
                        "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                '//March 24, 2006
                Me.Enabled = False

                If action = "remove" Then   '//turn off
                    Me._objNewTech.DeleteDeviceBillReclaim(CInt(Me._drDevInfo("Device_ID")), Trim(sender.tag.ToString))
                Else    '//turn on
                    strRegPart = drBOMPart("PSPrice_Number").ToString.ToUpper.Replace("_RV", "")
                    decRegPrice = Me._objNewTech.GetPartStdCost(strRegPart)

                    Me._objNewTech.InsertIntoDeviceBillReclaim(CInt(Me._drDevInfo("Device_ID")), _
                        decRegPrice, CDec(drBOMPart("PSPrice_AvgCost")), _
                        CDec(drBOMPart("PSPrice_StndCost")), CInt(drBOMPart("Billcode_ID")), _
                        drBOMPart("PSPrice_Number").ToString.Trim, Core.ApplicationUser.IDuser)
                    Me.lblPartNo.Text = drBOMPart("Billcode_Desc") & " : " & drBOMPart("PSPrice_Number")
                End If

                '*******************************
                LoadPartQty(CInt(Me._drDevInfo("Device_ID")), CInt(sender.tag.ToString))
                Me.lblMaxInv.Text = drBOMPart("MaxInventory").ToString

                Me._dtReclaim = Me._objNewTech.GetReclaimParts(CInt(Me._drDevInfo("Device_ID")))

                ' ADD OR REMOVE BER AND RECLAIM IF NEEDED.
                'Dim _hasBer As Boolean
                Dim _hasReclaim As Boolean
                '_hasBer = _device.Parts.Select("Billcode_id=2325").Length > 0
                _hasReclaim = _device.Parts.Select("Billcode_id=2823").Length > 0
                If _dtReclaim.Rows.Count > 0 Then
                    'If Not _hasBer Then
                    '    _device.AddPart(2325)
                    'End If
                    If Not _hasReclaim Then
                        _device.AddPart(2823)
                        _device.Update()
                    End If
                Else
                    If _hasReclaim Then
                        _device.DeletePart(2823)
                        _device.Update()
                    End If
                End If
                Me.HighLightSelectedButtons()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "billingClick_Reclaim", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                '********************************
                'Reset fail and repair code ID
                '********************************
                If Not IsNothing(Me._device) Then
                    Me._device.FailID = 0 : Me._device.RepairID = 0 : Me._device.ComplainID = 0
                End If
                '********************************
            End Try
        End Sub

        '**********************************************************************************************************************
        Private Sub HighLightSelectedButtons()
            Dim i As Integer = 0
            Dim dt As DataTable

            Try
                dt = Me.dgPartsQty.DataSource.Table

                'pnlNeededRvParts
                For i = 0 To Me.pnlNeededRVParts.Controls.Count - 1
                    If Me._dtReclaim.Select("Billcode_ID = " & Me.pnlNeededRVParts.Controls(i).Tag).Length > 0 Then
                        Me.pnlNeededRVParts.Controls(i).ForeColor = Color.Blue
                    Else
                        Me.pnlNeededRVParts.Controls(i).ForeColor = Color.Black
                    End If

                    If dt.Select("Billcode_ID = " & Me.pnlNeededRVParts.Controls(i).Tag & " AND MaxInventory > 0 AND CagePlusReclaim >= MaxInventory ").Length > 0 Then Me.pnlNeededRVParts.Controls(i).BackColor = Color.Red Else Me.pnlNeededRVParts.Controls(i).BackColor = Color.LightGray
                Next i

            Catch ex As Exception
                Throw ex
            Finally
                dt = Nothing
            End Try
        End Sub

        '**********************************************************************************************************************

    End Class
End Namespace