Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.NativeInstruments
    Public Class frmNIWipTransfer
        Inherits System.Windows.Forms.Form

        Private _strScreenName As String = ""

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strScreenName As String)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _strScreenName = strScreenName
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
        Friend WithEvents tpWipTransf As System.Windows.Forms.TabPage
        Friend WithEvents dgWipSummary As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents txtManufSN As System.Windows.Forms.TextBox
        Friend WithEvents btnGo As System.Windows.Forms.Button
        Friend WithEvents lblWipTransfName As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents btnResetCounter As System.Windows.Forms.Button
        Friend WithEvents lblScanQty As System.Windows.Forms.Label
        Friend WithEvents tpWipData As System.Windows.Forms.TabPage
        Friend WithEvents lblDisplayWipData As System.Windows.Forms.Label
        Friend WithEvents btnRefreshWipData As System.Windows.Forms.Button
        Friend WithEvents tpgWip As System.Windows.Forms.TabControl
        Friend WithEvents dgWipDetails As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmNIWipTransfer))
            Me.tpgWip = New System.Windows.Forms.TabControl()
            Me.tpWipTransf = New System.Windows.Forms.TabPage()
            Me.btnResetCounter = New System.Windows.Forms.Button()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.lblScanQty = New System.Windows.Forms.Label()
            Me.btnGo = New System.Windows.Forms.Button()
            Me.lblWipTransfName = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.txtManufSN = New System.Windows.Forms.TextBox()
            Me.tpWipData = New System.Windows.Forms.TabPage()
            Me.btnRefreshWipData = New System.Windows.Forms.Button()
            Me.dgWipDetails = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.lblDisplayWipData = New System.Windows.Forms.Label()
            Me.dgWipSummary = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.tpgWip.SuspendLayout()
            Me.tpWipTransf.SuspendLayout()
            Me.tpWipData.SuspendLayout()
            CType(Me.dgWipDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dgWipSummary, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'tpgWip
            '
            Me.tpgWip.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.tpgWip.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpWipTransf, Me.tpWipData})
            Me.tpgWip.Location = New System.Drawing.Point(16, 8)
            Me.tpgWip.Name = "tpgWip"
            Me.tpgWip.SelectedIndex = 0
            Me.tpgWip.Size = New System.Drawing.Size(696, 544)
            Me.tpgWip.TabIndex = 0
            '
            'tpWipTransf
            '
            Me.tpWipTransf.BackColor = System.Drawing.Color.SteelBlue
            Me.tpWipTransf.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnResetCounter, Me.Label7, Me.lblScanQty, Me.btnGo, Me.lblWipTransfName, Me.Label6, Me.txtManufSN})
            Me.tpWipTransf.Location = New System.Drawing.Point(4, 22)
            Me.tpWipTransf.Name = "tpWipTransf"
            Me.tpWipTransf.Size = New System.Drawing.Size(688, 518)
            Me.tpWipTransf.TabIndex = 0
            Me.tpWipTransf.Text = "WIP Transfer"
            '
            'btnResetCounter
            '
            Me.btnResetCounter.BackColor = System.Drawing.Color.SteelBlue
            Me.btnResetCounter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnResetCounter.ForeColor = System.Drawing.Color.White
            Me.btnResetCounter.Location = New System.Drawing.Point(216, 168)
            Me.btnResetCounter.Name = "btnResetCounter"
            Me.btnResetCounter.Size = New System.Drawing.Size(80, 40)
            Me.btnResetCounter.TabIndex = 238
            Me.btnResetCounter.Text = "Reset Counter"
            '
            'Label7
            '
            Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.White
            Me.Label7.Location = New System.Drawing.Point(104, 152)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(88, 16)
            Me.Label7.TabIndex = 237
            Me.Label7.Text = "Scan Qty :"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'lblScanQty
            '
            Me.lblScanQty.BackColor = System.Drawing.Color.Black
            Me.lblScanQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblScanQty.Font = New System.Drawing.Font("Tahoma", 24.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblScanQty.ForeColor = System.Drawing.Color.Green
            Me.lblScanQty.Location = New System.Drawing.Point(104, 168)
            Me.lblScanQty.Name = "lblScanQty"
            Me.lblScanQty.Size = New System.Drawing.Size(88, 40)
            Me.lblScanQty.TabIndex = 236
            Me.lblScanQty.Tag = "0"
            Me.lblScanQty.Text = "0"
            Me.lblScanQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnGo
            '
            Me.btnGo.BackColor = System.Drawing.Color.Green
            Me.btnGo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnGo.ForeColor = System.Drawing.Color.White
            Me.btnGo.Location = New System.Drawing.Point(328, 93)
            Me.btnGo.Name = "btnGo"
            Me.btnGo.Size = New System.Drawing.Size(48, 23)
            Me.btnGo.TabIndex = 232
            Me.btnGo.Text = "Go"
            '
            'lblWipTransfName
            '
            Me.lblWipTransfName.BackColor = System.Drawing.Color.Black
            Me.lblWipTransfName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblWipTransfName.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWipTransfName.ForeColor = System.Drawing.Color.Lime
            Me.lblWipTransfName.Location = New System.Drawing.Point(16, 24)
            Me.lblWipTransfName.Name = "lblWipTransfName"
            Me.lblWipTransfName.Size = New System.Drawing.Size(504, 32)
            Me.lblWipTransfName.TabIndex = 231
            Me.lblWipTransfName.Tag = "0"
            Me.lblWipTransfName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label6
            '
            Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.White
            Me.Label6.Location = New System.Drawing.Point(16, 96)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(80, 16)
            Me.Label6.TabIndex = 230
            Me.Label6.Text = "Manuf S/N :"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtManufSN
            '
            Me.txtManufSN.Location = New System.Drawing.Point(104, 93)
            Me.txtManufSN.MaxLength = 30
            Me.txtManufSN.Name = "txtManufSN"
            Me.txtManufSN.Size = New System.Drawing.Size(192, 20)
            Me.txtManufSN.TabIndex = 229
            Me.txtManufSN.Text = ""
            '
            'tpWipData
            '
            Me.tpWipData.BackColor = System.Drawing.Color.LightSteelBlue
            Me.tpWipData.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRefreshWipData, Me.dgWipDetails, Me.lblDisplayWipData, Me.dgWipSummary})
            Me.tpWipData.Location = New System.Drawing.Point(4, 22)
            Me.tpWipData.Name = "tpWipData"
            Me.tpWipData.Size = New System.Drawing.Size(688, 518)
            Me.tpWipData.TabIndex = 1
            Me.tpWipData.Text = "Wip Data"
            '
            'btnRefreshWipData
            '
            Me.btnRefreshWipData.BackColor = System.Drawing.Color.SteelBlue
            Me.btnRefreshWipData.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRefreshWipData.ForeColor = System.Drawing.Color.White
            Me.btnRefreshWipData.Location = New System.Drawing.Point(320, 8)
            Me.btnRefreshWipData.Name = "btnRefreshWipData"
            Me.btnRefreshWipData.Size = New System.Drawing.Size(144, 23)
            Me.btnRefreshWipData.TabIndex = 15
            Me.btnRefreshWipData.Text = "Refresh"
            '
            'dgWipDetails
            '
            Me.dgWipDetails.AllowUpdate = False
            Me.dgWipDetails.AlternatingRows = True
            Me.dgWipDetails.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dgWipDetails.FilterBar = True
            Me.dgWipDetails.GroupByCaption = "Drag a column header here to group by that column"
            Me.dgWipDetails.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dgWipDetails.Location = New System.Drawing.Point(8, 48)
            Me.dgWipDetails.Name = "dgWipDetails"
            Me.dgWipDetails.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dgWipDetails.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dgWipDetails.PreviewInfo.ZoomFactor = 75
            Me.dgWipDetails.Size = New System.Drawing.Size(664, 440)
            Me.dgWipDetails.TabIndex = 14
            Me.dgWipDetails.Visible = False
            Me.dgWipDetails.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            " DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>4" & _
            "36</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 660, 436<" & _
            "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
            "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
            "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
            "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
            "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
            "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
            "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
            "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
            "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 660, 436</ClientArea><Pr" & _
            "intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
            "Style21"" /></Blob>"
            '
            'lblDisplayWipData
            '
            Me.lblDisplayWipData.BackColor = System.Drawing.Color.Green
            Me.lblDisplayWipData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblDisplayWipData.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDisplayWipData.ForeColor = System.Drawing.Color.White
            Me.lblDisplayWipData.Location = New System.Drawing.Point(488, 8)
            Me.lblDisplayWipData.Name = "lblDisplayWipData"
            Me.lblDisplayWipData.Size = New System.Drawing.Size(184, 24)
            Me.lblDisplayWipData.TabIndex = 13
            Me.lblDisplayWipData.Text = "SHOW WIP DETAILS"
            Me.lblDisplayWipData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'dgWipSummary
            '
            Me.dgWipSummary.AllowUpdate = False
            Me.dgWipSummary.AlternatingRows = True
            Me.dgWipSummary.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dgWipSummary.FilterBar = True
            Me.dgWipSummary.GroupByCaption = "Drag a column header here to group by that column"
            Me.dgWipSummary.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.dgWipSummary.Location = New System.Drawing.Point(8, 40)
            Me.dgWipSummary.Name = "dgWipSummary"
            Me.dgWipSummary.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dgWipSummary.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dgWipSummary.PreviewInfo.ZoomFactor = 75
            Me.dgWipSummary.Size = New System.Drawing.Size(664, 440)
            Me.dgWipSummary.TabIndex = 12
            Me.dgWipSummary.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            " DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>4" & _
            "36</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 660, 436<" & _
            "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
            "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
            "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
            "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
            "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
            "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
            "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
            "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
            "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 660, 436</ClientArea><Pr" & _
            "intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
            "Style21"" /></Blob>"
            '
            'frmNIWipTransfer
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(744, 582)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpgWip})
            Me.Name = "frmNIWipTransfer"
            Me.Text = "frmNIWipTransfer"
            Me.tpgWip.ResumeLayout(False)
            Me.tpWipTransf.ResumeLayout(False)
            Me.tpWipData.ResumeLayout(False)
            CType(Me.dgWipDetails, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dgWipSummary, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '************************************************************************
        Private Sub frmNIWipTransfer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                Me.lblWipTransfName.Text = _strScreenName
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '************************************************************************

#Region "Wip Transfer"
        '************************************************************************
        Private Sub tpWipTransf_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpWipTransf.VisibleChanged
            Try
                Me.txtManufSN.SelectAll() : Me.txtManufSN.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "tpWipTransf_VisibleChanged", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '************************************************************************
        Private Sub txtManufSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtManufSN.KeyUp
            Try
                If e.KeyCode = Keys.Enter AndAlso Me.txtManufSN.Text.Trim.Length > 0 Then
                    Me.ProcessSN()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "txtManufSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '************************************************************************
        Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo.Click
            Try
                If Me.txtManufSN.Text.Trim.Length > 0 Then
                    Me.ProcessSN()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnGo_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '************************************************************************
        Private Sub ProcessSN()
            Dim dt, dtModelCriteria As DataTable
            Dim objNIRec As New NIRec()
            Dim booInProd As Boolean = False
            Dim strWorkStation, strSoftKeyCode As String
            Dim i, iDeviceID, iTrayID As Integer
            Dim dteReceiptDate As DateTime

            Try
                strWorkStation = "" : strSoftKeyCode = ""
                dt = Generic.GetDeviceInfoInWIP(Me.txtManufSN.Text.Trim, NI.CUSTOMERID, NI.LOCID, True)
                If dt.Rows.Count > 1 Then
                    MessageBox.Show("Duplicate S/N in WIP. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtManufSN.SelectAll() : Me.txtManufSN.Focus() : Exit Sub
                ElseIf dt.Rows.Count > 0 Then
                    booInProd = True
                    If dt.Rows(0)("WorkStation").ToString.Trim.Length = 0 Then
                        MessageBox.Show("S/N does not exist.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtManufSN.SelectAll() : Me.txtManufSN.Focus() : Exit Sub
                    ElseIf dt.Rows(0)("WorkStation").ToString.Trim.ToUpper <> "WAREHOUSE" Then
                        MessageBox.Show("Can't process unit from """ & dt.Rows(0)("WorkStation").ToString.Trim & """ workstation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtManufSN.SelectAll() : Me.txtManufSN.Focus() : Exit Sub
                    End If
                End If

                If booInProd = False Then
                    dt = objNIRec.GetOpenWHSNItem(NI.CUSTOMERID, Me.txtManufSN.Text.Trim)
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("S/N does not exist.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtManufSN.SelectAll() : Me.txtManufSN.Focus() : Exit Sub
                    ElseIf dt.Rows.Count > 1 Then
                        MessageBox.Show("Duplicate S/N in warehouse. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtManufSN.SelectAll() : Me.txtManufSN.Focus() : Exit Sub
                    ElseIf dt.Rows(0)("DevConditionID").ToString <> "3855" Then
                        MessageBox.Show("This is a good device.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtManufSN.SelectAll() : Me.txtManufSN.Focus() : Exit Sub
                    End If
                    iTrayID = Generic.GetTrayID(Convert.ToInt32(dt.Rows(0)("WO_ID")))
                    If iTrayID = 0 Then Throw New Exception("Tray ID is missing.")
                End If

                strWorkStation = Generic.GetNextWorkStationInWFP(Me._strScreenName, 0, NI.CUSTOMERID, , )
                If strWorkStation.Trim.Length = 0 Then
                    MessageBox.Show("Screen is not define in work flow process.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtManufSN.SelectAll() : Me.txtManufSN.Focus() : Exit Sub
                End If

                Dim objModManuf As New ModManuf()
                dtModelCriteria = objModManuf.GetModelCriteria(NI.CUSTOMERID, dt.Rows(0)("Model_ID"))
                If dtModelCriteria.Rows.Count = 0 Then
                    MessageBox.Show("Missing Model criteria.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtManufSN.SelectAll() : Me.txtManufSN.Focus() : Exit Sub
                ElseIf dtModelCriteria.Rows(0)("EndOfLife").ToString = "1" AndAlso MessageBox.Show("This is an inactive model. Are you sure you want to move this device to production?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Me.txtManufSN.SelectAll() : Me.txtManufSN.Focus() : Exit Sub
                End If

                If booInProd = True Then
                    i = Generic.SetTcelloptWorkStationForDevice(strWorkStation, Convert.ToInt32(dt.Rows(0)("Device_ID")), Core.ApplicationUser.IDuser, Me._strScreenName, Me.Name, , , , , , )
                    If i = 0 Then
                        MessageBox.Show("System has failed to transfer device to " & strWorkStation & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtManufSN.SelectAll() : Me.txtManufSN.Focus() : Exit Sub
                    Else
                        Me.txtManufSN.Text = "" : Me.lblScanQty.Text = Convert.ToInt16(Me.lblScanQty.Text) + 1
                    End If
                Else
                    If Not IsDBNull(dt.Rows(0)("SoftKeyCode")) Then strSoftKeyCode = dt.Rows(0)("SoftKeyCode").ToString.Trim
                    'Receive into 
                    dteReceiptDate = Convert.ToDateTime(dt.Rows(0)("Date_Received"))
                    iDeviceID = objNIRec.ReceiveDeviceIntoWIP(Convert.ToInt32(dt.Rows(0)("WO_ID")), iTrayID, Convert.ToInt32(dt.Rows(0)("Model_ID")), Me.txtManufSN.Text.Trim.ToUpper, PSS.Core.ApplicationUser.IDShift, PSS.Core.ApplicationUser.IDuser, PSS.Core.ApplicationUser.User, 0, strWorkStation, dteReceiptDate, False, strSoftKeyCode)
                    If iDeviceID > 0 Then
                        Dim objAquisProdRec As New AquisProdRec()
                        i = objAquisProdRec.UpdateDeviceIDOfITem(Convert.ToInt32(dt.Rows(0)("WI_ID")), iDeviceID)
                        If i = 0 Then
                            MessageBox.Show("System has failed to update device ID in warehouse item.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtManufSN.SelectAll() : Me.txtManufSN.Focus() : Exit Sub
                        Else
                            Me.txtManufSN.Text = "" : Me.lblScanQty.Text = Convert.ToInt16(Me.lblScanQty.Text) + 1
                        End If
                        objAquisProdRec = Nothing
                    Else
                        MessageBox.Show("System has failed to write device into tdevice.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtManufSN.SelectAll() : Me.txtManufSN.Focus() : Exit Sub
                    End If
                End If

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt) : Generic.DisposeDT(dtModelCriteria)
                objNIRec = Nothing
            End Try
        End Sub

        '************************************************************************
        Private Sub btnResetCounter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetCounter.Click
            Me.lblScanQty.Text = "0"
        End Sub

        '************************************************************************

#End Region

#Region "Wip Data"

        '************************************************************************
        Private Sub tpWipSummary_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tpWipData.VisibleChanged
            Try
                If tpWipData.Visible = True AndAlso Me.dgWipSummary.Columns.Count = 0 AndAlso Me.dgWipDetails.Columns.Count = 0 Then
                    LoadWipData()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "tpWipSummary_VisibleChanged", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '************************************************************************
        Private Sub LoadWipData()
            Dim ds As DataSet
            Dim objNIReport As NIReports

            Try
                objNIReport = New NIReports()
                ds = objNIReport.GetWIPData(True)
                With Me.dgWipSummary
                    .DataSource = ds.Tables("Summary").DefaultView
                    .Caption = "WIP Summary"
                End With

                With Me.dgWipDetails
                    .DataSource = ds.Tables("Details").DefaultView
                    .Caption = "WIP Details"
                End With
            Catch ex As Exception
                Throw ex
            Finally
                objNIReport = Nothing
                Generic.DisposeDS(ds)
            End Try
        End Sub

        '************************************************************************
        Private Sub dgWipSummary_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgWipSummary.MouseDown
            Try
                Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = DirectCast(sender, C1.Win.C1TrueDBGrid.C1TrueDBGrid)

                If dbg.RowCount = 0 Then Return

                If e.Button = MouseButtons.Right Then
                    Dim ctmCopyData As New ContextMenu()
                    Dim objCopyAll As New MenuItem()
                    Dim objCopySelected As New MenuItem()
                    Dim objExportToExcel As New MenuItem()

                    objCopyAll.Text = "Copy all."
                    objCopySelected.Text = "Copy selected rows."
                    objExportToExcel.Text = "Export data to Excel."

                    ctmCopyData.MenuItems.Add(objCopyAll)
                    ctmCopyData.MenuItems.Add(objCopySelected)
                    ctmCopyData.MenuItems.Add(objExportToExcel)

                    RemoveHandler objCopyAll.Click, AddressOf CMenuCopyAllData_Summ
                    AddHandler objCopyAll.Click, AddressOf CMenuCopyAllData_Summ
                    RemoveHandler objCopySelected.Click, AddressOf CMenuCopySelectedData_Summ
                    AddHandler objCopySelected.Click, AddressOf CMenuCopySelectedData_Summ
                    RemoveHandler objExportToExcel.Click, AddressOf CMenuExportToExcel_Summ
                    AddHandler objExportToExcel.Click, AddressOf CMenuExportToExcel_Summ

                    dbg.ContextMenu = ctmCopyData
                    dbg.ContextMenu.Show(dbg, New Point(e.X, e.Y))
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgEEInfo_MouseDown", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '************************************************************************
        Private Sub CMenuCopyAllData_Summ(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                Misc.CopyAllData(Me.dgWipSummary)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CMenuCopyData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '************************************************************************
        Private Sub CMenuCopySelectedData_Summ(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                Misc.CopySelectedRowsData(Me.dgWipSummary)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CMenuCopySelectedData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '************************************************************************
        Private Sub CMenuExportToExcel_Summ(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim objFD As New SaveFileDialog()
            Dim strFileName As String = ""
            Try
                objFD.ShowDialog()
                strFileName = objFD.FileName()
                If strFileName.Trim.Length = 0 Then
                    Exit Sub
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    Me.dgWipSummary.ExportToExcel(strFileName & ".xls")
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CMenuExportToExcel_Summ", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Finally
                objFD = Nothing
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '************************************************************************
        Private Sub dgWipDetails_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgWipDetails.MouseDown
            Try
                Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = DirectCast(sender, C1.Win.C1TrueDBGrid.C1TrueDBGrid)

                If dbg.RowCount = 0 Then Return

                If e.Button = MouseButtons.Right Then
                    Dim ctmCopyData As New ContextMenu()
                    Dim objCopyAll As New MenuItem()
                    Dim objCopySelected As New MenuItem()
                    Dim objExportToExcel As New MenuItem()

                    objCopyAll.Text = "Copy all data to the clipboard."
                    objCopySelected.Text = "Copy selected rows to the clipboard."
                    objExportToExcel.Text = "Export data to Excel."

                    ctmCopyData.MenuItems.Add(objCopyAll)
                    ctmCopyData.MenuItems.Add(objCopySelected)
                    ctmCopyData.MenuItems.Add(objExportToExcel)

                    RemoveHandler objCopyAll.Click, AddressOf CMenuCopyAllData_Details
                    AddHandler objCopyAll.Click, AddressOf CMenuCopyAllData_Details
                    RemoveHandler objCopySelected.Click, AddressOf CMenuCopySelectedData_Details
                    AddHandler objCopySelected.Click, AddressOf CMenuCopySelectedData_Details
                    RemoveHandler objExportToExcel.Click, AddressOf CMenuExportToExcel_Details
                    AddHandler objExportToExcel.Click, AddressOf CMenuExportToExcel_Details

                    dbg.ContextMenu = ctmCopyData
                    dbg.ContextMenu.Show(dbg, New Point(e.X, e.Y))
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgEEInfo_MouseDown", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '************************************************************************
        Private Sub CMenuCopyAllData_Details(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                Misc.CopyAllData(Me.dgWipDetails)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CMenuCopyData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '************************************************************************
        Private Sub CMenuCopySelectedData_Details(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                Misc.CopySelectedRowsData(Me.dgWipDetails)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CMenuCopySelectedData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '************************************************************************
        Private Sub CMenuExportToExcel_Details(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim objFD As New SaveFileDialog()
            Dim strFileName As String = ""
            Try
                objFD.ShowDialog()
                strFileName = objFD.FileName()
                If strFileName.Trim.Length = 0 Then
                    Exit Sub
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    Me.dgWipDetails.ExportToExcel(strFileName & ".xls")
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CMenuExportToExcel_Details", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Finally
                objFD = Nothing
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '************************************************************************
        Private Sub btnRefreshWipData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRefreshWipData.Click
            Try
                LoadWipData()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnRefreshWipData_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '************************************************************************
        Private Sub lblDisplayWipData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblDisplayWipData.Click
            Try
                If Me.lblDisplayWipData.Text = "SHOW WIP DETAILS" Then
                    Me.lblDisplayWipData.Text = "SHOW WIP SUMMARY"
                    Me.dgWipDetails.Visible = True
                    Me.dgWipSummary.Visible = False
                Else
                    Me.lblDisplayWipData.Text = "SHOW WIP DETAILS"
                    Me.dgWipDetails.Visible = False
                    Me.dgWipSummary.Visible = True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnRefreshWipData_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '************************************************************************

#End Region


        
        
    End Class
End Namespace