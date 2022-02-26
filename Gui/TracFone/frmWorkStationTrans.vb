Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.TracFone

    Public Class frmWorkStationTrans
        Inherits System.Windows.Forms.Form

        Private _strScreenName As String = ""
        Private _objTFMisc As PSS.Data.Buisness.TracFone.clsMisc
        Private _booValidBoxData As Boolean = False
        Private _iPalletID As Integer

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strScreenName As String)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _strScreenName = strScreenName
            _objTFMisc = New PSS.Data.Buisness.TracFone.clsMisc()
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If

                _objTFMisc = Nothing
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        Friend WithEvents lblBoxQty As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents btnTransfer As System.Windows.Forms.Button
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents lblModel As System.Windows.Forms.Label
        Friend WithEvents txtBoxID As System.Windows.Forms.TextBox
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents lblScanTotal As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents dbgData As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnGo As System.Windows.Forms.Button
        Friend WithEvents txtIMEI As System.Windows.Forms.TextBox
        Friend WithEvents grbTransfer As System.Windows.Forms.GroupBox
        Friend WithEvents grbSearch As System.Windows.Forms.GroupBox
        Friend WithEvents pnlTransfToLoc As System.Windows.Forms.Panel
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents cboTranfToLoc As System.Windows.Forms.ComboBox
        Friend WithEvents rbtnBoxID As System.Windows.Forms.RadioButton
        Friend WithEvents rbtnSN As System.Windows.Forms.RadioButton
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmWorkStationTrans))
            Me.txtBoxID = New System.Windows.Forms.TextBox()
            Me.grbTransfer = New System.Windows.Forms.GroupBox()
            Me.rbtnBoxID = New System.Windows.Forms.RadioButton()
            Me.pnlTransfToLoc = New System.Windows.Forms.Panel()
            Me.cboTranfToLoc = New System.Windows.Forms.ComboBox()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.lblScanTotal = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.btnTransfer = New System.Windows.Forms.Button()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.lblBoxQty = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.lblModel = New System.Windows.Forms.Label()
            Me.rbtnSN = New System.Windows.Forms.RadioButton()
            Me.grbSearch = New System.Windows.Forms.GroupBox()
            Me.btnGo = New System.Windows.Forms.Button()
            Me.dbgData = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.txtIMEI = New System.Windows.Forms.TextBox()
            Me.grbTransfer.SuspendLayout()
            Me.pnlTransfToLoc.SuspendLayout()
            Me.Panel2.SuspendLayout()
            Me.Panel1.SuspendLayout()
            Me.grbSearch.SuspendLayout()
            CType(Me.dbgData, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'txtBoxID
            '
            Me.txtBoxID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtBoxID.Location = New System.Drawing.Point(88, 84)
            Me.txtBoxID.MaxLength = 20
            Me.txtBoxID.Name = "txtBoxID"
            Me.txtBoxID.Size = New System.Drawing.Size(299, 22)
            Me.txtBoxID.TabIndex = 1
            Me.txtBoxID.Text = ""
            '
            'grbTransfer
            '
            Me.grbTransfer.Controls.AddRange(New System.Windows.Forms.Control() {Me.rbtnBoxID, Me.pnlTransfToLoc, Me.Panel2, Me.btnCancel, Me.btnTransfer, Me.txtBoxID, Me.Panel1, Me.rbtnSN})
            Me.grbTransfer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grbTransfer.ForeColor = System.Drawing.Color.White
            Me.grbTransfer.Location = New System.Drawing.Point(8, 0)
            Me.grbTransfer.Name = "grbTransfer"
            Me.grbTransfer.Size = New System.Drawing.Size(544, 256)
            Me.grbTransfer.TabIndex = 1
            Me.grbTransfer.TabStop = False
            Me.grbTransfer.Text = "Transfer Box "
            Me.grbTransfer.Visible = False
            '
            'rbtnBoxID
            '
            Me.rbtnBoxID.Enabled = False
            Me.rbtnBoxID.Location = New System.Drawing.Point(8, 71)
            Me.rbtnBoxID.Name = "rbtnBoxID"
            Me.rbtnBoxID.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.rbtnBoxID.Size = New System.Drawing.Size(72, 24)
            Me.rbtnBoxID.TabIndex = 146
            Me.rbtnBoxID.Text = "Box ID"
            '
            'pnlTransfToLoc
            '
            Me.pnlTransfToLoc.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboTranfToLoc, Me.Label7})
            Me.pnlTransfToLoc.Location = New System.Drawing.Point(8, 24)
            Me.pnlTransfToLoc.Name = "pnlTransfToLoc"
            Me.pnlTransfToLoc.Size = New System.Drawing.Size(392, 40)
            Me.pnlTransfToLoc.TabIndex = 145
            Me.pnlTransfToLoc.Visible = False
            '
            'cboTranfToLoc
            '
            Me.cboTranfToLoc.Items.AddRange(New Object() {"PRE-BILL", "PRETEST"})
            Me.cboTranfToLoc.Location = New System.Drawing.Point(80, 8)
            Me.cboTranfToLoc.Name = "cboTranfToLoc"
            Me.cboTranfToLoc.Size = New System.Drawing.Size(304, 24)
            Me.cboTranfToLoc.TabIndex = 138
            '
            'Label7
            '
            Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.White
            Me.Label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label7.Location = New System.Drawing.Point(8, 8)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(64, 16)
            Me.Label7.TabIndex = 137
            Me.Label7.Text = "Location:"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Panel2
            '
            Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblScanTotal, Me.Label3})
            Me.Panel2.Location = New System.Drawing.Point(416, 32)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(120, 72)
            Me.Panel2.TabIndex = 144
            '
            'lblScanTotal
            '
            Me.lblScanTotal.BackColor = System.Drawing.Color.Black
            Me.lblScanTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblScanTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblScanTotal.ForeColor = System.Drawing.Color.Lime
            Me.lblScanTotal.Location = New System.Drawing.Point(8, 24)
            Me.lblScanTotal.Name = "lblScanTotal"
            Me.lblScanTotal.Size = New System.Drawing.Size(96, 48)
            Me.lblScanTotal.TabIndex = 142
            Me.lblScanTotal.Text = "0"
            Me.lblScanTotal.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Black
            Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.Lime
            Me.Label3.Location = New System.Drawing.Point(8, 8)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(96, 18)
            Me.Label3.TabIndex = 143
            Me.Label3.Text = "SCAN TOTAL"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'btnCancel
            '
            Me.btnCancel.Location = New System.Drawing.Point(272, 216)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(112, 24)
            Me.btnCancel.TabIndex = 3
            Me.btnCancel.Text = "Clear"
            '
            'btnTransfer
            '
            Me.btnTransfer.BackColor = System.Drawing.Color.Green
            Me.btnTransfer.Location = New System.Drawing.Point(88, 216)
            Me.btnTransfer.Name = "btnTransfer"
            Me.btnTransfer.Size = New System.Drawing.Size(120, 24)
            Me.btnTransfer.TabIndex = 2
            Me.btnTransfer.Text = "Transfer"
            '
            'Panel1
            '
            Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label2, Me.lblBoxQty, Me.Label1, Me.lblModel})
            Me.Panel1.Location = New System.Drawing.Point(24, 128)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(376, 80)
            Me.Panel1.TabIndex = 2
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label2.Location = New System.Drawing.Point(8, 48)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(48, 16)
            Me.Label2.TabIndex = 141
            Me.Label2.Text = "Model:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblBoxQty
            '
            Me.lblBoxQty.BackColor = System.Drawing.Color.White
            Me.lblBoxQty.ForeColor = System.Drawing.Color.Black
            Me.lblBoxQty.Location = New System.Drawing.Point(64, 8)
            Me.lblBoxQty.Name = "lblBoxQty"
            Me.lblBoxQty.Size = New System.Drawing.Size(299, 22)
            Me.lblBoxQty.TabIndex = 136
            Me.lblBoxQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label1.Location = New System.Drawing.Point(8, 8)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(48, 16)
            Me.Label1.TabIndex = 137
            Me.Label1.Text = "Qty:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblModel
            '
            Me.lblModel.BackColor = System.Drawing.Color.White
            Me.lblModel.ForeColor = System.Drawing.Color.Black
            Me.lblModel.Location = New System.Drawing.Point(64, 48)
            Me.lblModel.Name = "lblModel"
            Me.lblModel.Size = New System.Drawing.Size(299, 22)
            Me.lblModel.TabIndex = 140
            Me.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'rbtnSN
            '
            Me.rbtnSN.Enabled = False
            Me.rbtnSN.Location = New System.Drawing.Point(16, 97)
            Me.rbtnSN.Name = "rbtnSN"
            Me.rbtnSN.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.rbtnSN.Size = New System.Drawing.Size(64, 24)
            Me.rbtnSN.TabIndex = 147
            Me.rbtnSN.Text = "IMEI"
            '
            'grbSearch
            '
            Me.grbSearch.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.grbSearch.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnGo, Me.dbgData, Me.Label4, Me.txtIMEI})
            Me.grbSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grbSearch.ForeColor = System.Drawing.Color.White
            Me.grbSearch.Location = New System.Drawing.Point(8, 272)
            Me.grbSearch.Name = "grbSearch"
            Me.grbSearch.Size = New System.Drawing.Size(536, 248)
            Me.grbSearch.TabIndex = 2
            Me.grbSearch.TabStop = False
            Me.grbSearch.Text = "Search Warehouse Receiving Information"
            Me.grbSearch.Visible = False
            '
            'btnGo
            '
            Me.btnGo.BackColor = System.Drawing.Color.Green
            Me.btnGo.Location = New System.Drawing.Point(232, 48)
            Me.btnGo.Name = "btnGo"
            Me.btnGo.Size = New System.Drawing.Size(40, 24)
            Me.btnGo.TabIndex = 139
            Me.btnGo.Text = "Go"
            '
            'dbgData
            '
            Me.dbgData.AllowUpdate = False
            Me.dbgData.AlternatingRows = True
            Me.dbgData.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgData.FilterBar = True
            Me.dbgData.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgData.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dbgData.Location = New System.Drawing.Point(8, 80)
            Me.dbgData.Name = "dbgData"
            Me.dbgData.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgData.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgData.PreviewInfo.ZoomFactor = 75
            Me.dbgData.RowHeight = 15
            Me.dbgData.Size = New System.Drawing.Size(520, 158)
            Me.dbgData.TabIndex = 138
            Me.dbgData.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;" & _
            "BackColor:LightSteelBlue;}Normal{Font:Microsoft Sans Serif, 12pt, style=Bold;Bac" & _
            "kColor:SteelBlue;}Selected{ForeColor:HighlightText;BackColor:Highlight;}Editor{}" & _
            "Style18{}Style19{}Style14{}Style15{}Style16{}Style17{}Style10{AlignHorz:Near;}St" & _
            "yle11{}OddRow{Font:Microsoft Sans Serif, 8.25pt, style=Bold;BackColor:LightSteel" & _
            "Blue;}Style13{}Style12{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight" & _
            ";}RecordSelector{AlignImage:Center;}Footer{}Style21{}Style20{}Inactive{ForeColor" & _
            ":InactiveCaptionText;BackColor:InactiveCaption;}EvenRow{Font:Microsoft Sans Seri" & _
            "f, 8.25pt, style=Bold;BackColor:NavajoWhite;}Heading{Wrap:True;Font:Microsoft Sa" & _
            "ns Serif, 8.25pt, style=Bold;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeCol" & _
            "or:ControlText;AlignVert:Center;}FilterBar{Font:Microsoft Sans Serif, 9.75pt, st" & _
            "yle=Bold;ForeColor:Red;BackColor:White;}Style4{}Style9{}Style8{}Style5{}Group{Al" & _
            "ignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style7{}Style6{}St" & _
            "yle1{}Style3{}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Nam" & _
            "e="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" Colu" & _
            "mnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelec" & _
            "torWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=" & _
            """1""><Height>154</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyl" & _
            "e parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><Fi" & _
            "lterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""" & _
            "Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Headin" & _
            "g"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><Inactiv" & _
            "eStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" " & _
            "/><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle par" & _
            "ent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0," & _
            " 0, 516, 154</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderSt" & _
            "yle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""N" & _
            "ormal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Foote" & _
            "r"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive" & _
            """ /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" />" & _
            "<Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /" & _
            "><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector" & _
            """ /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /" & _
            "></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None<" & _
            "/Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 516, 154</C" & _
            "lientArea><PrintPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle p" & _
            "arent="""" me=""Style21"" /></Blob>"
            '
            'Label4
            '
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label4.Location = New System.Drawing.Point(8, 32)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(81, 16)
            Me.Label4.TabIndex = 137
            Me.Label4.Text = "IMEI/MEID:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtIMEI
            '
            Me.txtIMEI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtIMEI.Location = New System.Drawing.Point(8, 48)
            Me.txtIMEI.MaxLength = 20
            Me.txtIMEI.Name = "txtIMEI"
            Me.txtIMEI.Size = New System.Drawing.Size(208, 22)
            Me.txtIMEI.TabIndex = 136
            Me.txtIMEI.Text = ""
            '
            'frmWorkStationTrans
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(560, 550)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.grbSearch, Me.grbTransfer})
            Me.Name = "frmWorkStationTrans"
            Me.Text = "frmWorkStationTrans"
            Me.grbTransfer.ResumeLayout(False)
            Me.pnlTransfToLoc.ResumeLayout(False)
            Me.Panel2.ResumeLayout(False)
            Me.Panel1.ResumeLayout(False)
            Me.grbSearch.ResumeLayout(False)
            CType(Me.dbgData, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '******************************************************************
        Private Sub frmWorkStationTrans_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                If Me._strScreenName = "To Staging" Or Me._strScreenName = "To Pretest" _
                   Or Me._strScreenName = "To Prebill" Or Me._strScreenName = "To RF1" _
                   Or Me._strScreenName = "To WH-RB" Or Me._strScreenName = "To WH-WIP" _
                   Or Me._strScreenName = "To Teardown" Or Me._strScreenName = "To BER" _
                   Or Me._strScreenName = "To BER Complete" Or Me._strScreenName = "To BER Screen" _
                   Or Me._strScreenName = "To Obsolete" Or Me._strScreenName = "To Production Hold" Then
                    Me.grbTransfer.Text = Me.grbTransfer.Text & Me._strScreenName
                    Me.Panel2.Visible = False
                    Me.rbtnSN.Checked = False : Me.rbtnBoxID.Checked = True
                ElseIf Me._strScreenName = "Remove From Fail and AWAP" Then
                    Me.grbTransfer.Text = "Transfer Device To "
                    Me.Panel1.Visible = False
                    Me.Panel2.Visible = True
                    Me.rbtnSN.Checked = True : Me.rbtnBoxID.Checked = False 'Me.lblBoxName.Text = "IMEI/MEID:"
                    Me.pnlTransfToLoc.Visible = True
                Else
                    Me.grbTransfer.Text = "Transfer Device " & Me._strScreenName
                    Me.Panel1.Visible = False
                    Me.Panel2.Visible = True
                    If Me._strScreenName = "To QUARANTINE" Then
                        Me.rbtnSN.Checked = False : Me.rbtnBoxID.Enabled = True : Me.rbtnSN.Enabled = True
                    Else
                        Me.rbtnSN.Checked = True ' Me.lblBoxName.Text = "IMEI/MEID:"
                    End If
                End If

                If _strScreenName = "Search Warehouse Receive Information" Then
                    Me.grbSearch.Visible = True : Me.grbSearch.Location = New System.Drawing.Point(8, 0)
                    Me.txtIMEI.Focus()
                Else
                    Me.grbTransfer.Visible = True
                    Me.txtBoxID.Focus()
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmWorkStationTrans_Load", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '******************************************************************
        Private Sub txtBoxID_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBoxID.KeyUp
            Try
                If e.KeyCode = Keys.Enter AndAlso Me.txtBoxID.Text.Trim.Length > 0 Then
                    If Me._strScreenName = "To Staging" Or Me._strScreenName = "To Pretest" Or Me._strScreenName = "To Prebill" Or Me._strScreenName = "To RF1" _
                       Or Me._strScreenName = "To Obsolete" Or Me._strScreenName = "To Production Hold" Then
                        Me.ProcessBox_Staging_Pretest_Prebill_Obsolete_ProdHold()
                    ElseIf Me._strScreenName = "To WH-RB" Then
                        Me.ProcessBox_CageRB()
                    ElseIf Me._strScreenName = "To WH-WIP" Then
                        Me.ProcessBox_WHWIP()
                    ElseIf Me._strScreenName.StartsWith("To Functional Fail") = True Or Me._strScreenName.StartsWith("To AWAP") = True Then
                        Me.ProcessBox_FuncFailUnits()
                    ElseIf Me._strScreenName = "Remove From Fail and AWAP" Then
                        Me.ProcessRemoveUnitFrFailBucket()
                    ElseIf Me._strScreenName = "To Teardown" Or Me._strScreenName = "To BER" Or Me._strScreenName = "To BER Complete" Then
                        Me.ProcessBox_BER()
                    ElseIf Me._strScreenName = "To BER Screen" Then
                        Me.ProcessBox_BERScreen()
                    ElseIf Me._strScreenName = "To QUARANTINE" Or Me._strScreenName = "To AWAP" Or Me._strScreenName = "To Engineering" Then
                        If Me._strScreenName = "To QUARANTINE" AndAlso Me.rbtnBoxID.Checked = True Then ProcessBox_Quarantine() Else Me.ProcessTo_Quantine_AWAP_Engineering()
                    Else
                        MessageBox.Show("System has failed to define function.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtBoxID_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '******************************************************************
        Private Function ProcessBox_Staging_Pretest_Prebill_Obsolete_ProdHold()
            Dim dt As DataTable

            Try
                dt = Me._objTFMisc.GetBoxStationCount(Me.txtBoxID.Text)

                If dt.Rows.Count = 0 Then
                    MessageBox.Show("This Box ID does not exist.", "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                ElseIf (dt.Rows.Count > 1) Then
                    MessageBox.Show("This Box ID has units of multiple workstation or multiple model.", "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                ElseIf dt.Rows(0)("Closed").ToString = "0" Then
                    MessageBox.Show("Box is still open.", "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                Else
                    If dt.Rows(0)("WorkStation").ToString.Trim.Length = 0 Then
                        MessageBox.Show("This Box does not belong to any workstation.", "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                    ElseIf Misc.ValidateFrStationOfScreenInWorkFlow(Me._strScreenName, dt.Rows(0)("WorkStation").ToString.Trim, PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, 0) = False Then
                        Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                    Else
                        If Not IsDBNull(dt.Compute("SUM(cnt)", "")) Then Me.lblBoxQty.Text = dt.Compute("SUM(cnt)", "")
                        Me.lblModel.Text = dt.Rows(0)("VN_ItemNo")
                        Me._booValidBoxData = True
                    End If
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Private Function ProcessBox_Quarantine()
            Dim dt As DataTable

            Try
                dt = Me._objTFMisc.GetBoxStationCount(Me.txtBoxID.Text)

                If dt.Rows.Count = 0 Then
                    MessageBox.Show("This Box ID does not exist.", "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                ElseIf (dt.Rows.Count > 1) Then
                    MessageBox.Show("This Box ID has units of multiple workstation or multiple model.", "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                ElseIf dt.Rows(0)("Closed").ToString = "0" Then
                    MessageBox.Show("Box is still open.", "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                ElseIf Me._strScreenName.Trim.Length = 0 Then
                    MessageBox.Show("Screen name is missing.", "Validate Work Flow", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dt.Rows(0)("WorkStation").ToString.Trim.Length = 0 Then
                    MessageBox.Show("This Box does not belong to any workstation.", "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                ElseIf dt.Rows(0)("WorkStation").ToString.Trim <> "WH-WIP" Then
                    MessageBox.Show("Box must be from 'WH-WIP' workstation.", "Validate WorkStation", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                Else
                    If Not IsDBNull(dt.Compute("SUM(cnt)", "")) Then Me.lblBoxQty.Text = dt.Compute("SUM(cnt)", "")
                    Me.lblModel.Text = dt.Rows(0)("VN_ItemNo")
                    Me._booValidBoxData = True
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Private Function ProcessBox_FuncFailUnits()
            Dim dt, dtParts As DataTable
            Dim R1 As DataRow
            Dim i As Integer = 0
            Dim strCurrentStation As String = ""
            Dim objDevice As Rules.Device

            Try
                dt = Generic.GetDeviceInfoInWIP(Me.txtBoxID.Text.Trim, PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID)

                If dt.Rows.Count = 0 Then
                    MessageBox.Show("This device does not exist or already shipped.", "ProcessBox_FuncFailUnits", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                ElseIf (dt.Rows.Count > 1) Then
                    MessageBox.Show("This device's duplicated. Please contact IT.", "ProcessBox_FuncFailUnits", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                ElseIf IsDBNull(dt.Rows(0)("WorkStation")) OrElse dt.Rows(0)("WorkStation").ToString.Trim.Length = 0 Then
                    MessageBox.Show("This device does not belongs to any workstation.", "ProcessBox_FuncFailUnits", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                ElseIf Not IsDBNull(dt.Rows(0)("Pallett_ID")) Then
                    MessageBox.Show("This device's already assigned to a ship box.", "ProcessBox_FuncFailUnits", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                ElseIf Misc.ValidateFrStationOfScreenInWorkFlow(Me._strScreenName, dt.Rows(0)("WorkStation").ToString.Trim, PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, 0) = False Then
                    Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus() : Exit Function
                Else
                    If Me._strScreenName.Trim.StartsWith("To Functional Fail") = True Then
                        ''Delete all parts
                        'dtParts = Me._objTFMisc.GetPartsOfDevice(CInt(dt.Rows(0)("Device_ID")))
                        'If dtParts.Rows.Count > 0 Then
                        '    objDevice = New Rules.Device(CInt(dt.Rows(0)("Device_ID")))
                        '    For Each R1 In dtParts.Rows
                        '        objDevice.DeletePart(R1("Billcode_ID"))
                        '    Next R1
                        '    objDevice.Update()
                        'End If

                        'Change Model to _FUN
                        Me._objTFMisc.ChangeToFuncModel(dt.Rows(0)("Device_ID"), dt.Rows(0)("Model_Desc"), dt.Rows(0)("Model_ID"))

                        i = Generic.SetTcelloptWorkStationForDevice(Mid(Me._strScreenName.ToUpper, 4), dt.Rows(0)("Device_ID"), )
                    ElseIf Me._strScreenName.Trim.StartsWith("To QUARANTINE") = True Then
                        i = Generic.SetTcelloptWorkStationForDevice(Mid(Me._strScreenName.ToUpper, 4), dt.Rows(0)("Device_ID"), )
                    Else
                        i = Generic.SetTcelloptWorkStationForDevice(Mid(Me._strScreenName.ToUpper, 4), dt.Rows(0)("Device_ID"), 6)
                    End If

                    If i = 0 Then MessageBox.Show("Failed to transfer. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                    Me.lblScanTotal.Text = CInt(Me.lblScanTotal.Text) + 1
                    Me.txtBoxID.Text = ""
                    Me.txtBoxID.Focus()
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
                Generic.DisposeDT(dtParts)
                If Not IsNothing(objDevice) Then
                    objDevice.Dispose()
                    objDevice = Nothing
                End If
                R1 = Nothing
            End Try
        End Function

        '******************************************************************
        Private Function ProcessBox_CageRB()
            Dim dt As DataTable

            Try
                dt = Me._objTFMisc.GetShipBoxStationCount(Me.txtBoxID.Text.Trim)

                If dt.Rows.Count = 0 Then
                    MessageBox.Show("This Box ID does not exist.", "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                ElseIf dt.Rows.Count > 1 Then
                    MessageBox.Show("Box has multiple workstation.", "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                ElseIf dt.Rows(0)("WorkStation").ToString.Trim.Length = 0 Then
                    MessageBox.Show("This Box does not belong to any workstation.", "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                ElseIf Misc.ValidateFrStationOfScreenInWorkFlow(Me._strScreenName, dt.Rows(0)("WorkStation").ToString.Trim, PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, 0) = False Then
                    Me.txtBoxID.Text = "" : Me.txtBoxID.Focus() : Exit Function
                Else
                    If IsDBNull(dt.Rows(0)("Pallett_ShipDate")) Then
                        MessageBox.Show("This Box has not completed at production line.", "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                    Else
                        Me._iPalletID = dt.Rows(0)("Pallett_ID")
                        Me._booValidBoxData = True
                        Me.lblBoxQty.Text = dt.Rows(0)("Pallett_QTY")
                        Me.lblModel.Text = dt.Rows(0)("cust_OutgoingSku")
                    End If
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Private Function ProcessBox_WHWIP() As String
            Dim dt, dtAcceptedWrkStation As DataTable
            Dim strAcceptedStation As String = ""
            Dim i As Integer

            Try
                dt = Me._objTFMisc.GetBoxStationCount(Me.txtBoxID.Text)

                If dt.Rows.Count = 0 Then
                    MessageBox.Show("This Box ID does not exist.", "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                ElseIf dt.Select("WorkStation = 'PRODUCTION STAGING'").Length > 0 AndAlso dt.Rows.Count > 1 Then
                    MessageBox.Show("This Box has multiple workstation.", "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                ElseIf dt.Rows(0)("WorkStation").ToString.Trim.Length = 0 Then
                    MessageBox.Show("This Box does not belong to any workstation.", "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                    'ElseIf Misc.ValidateFrStationOfScreenInWorkFlow(Me._strScreenName, dt.Rows(0)("WorkStation").ToString.Trim, PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, 0) = False Then
                    '    Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                Else
                    Dim strSelStationArr(), strSelStation As String
                    strAcceptedStation = Generic.GetAcceptedWorkStationInWorkFlow(Me._strScreenName, PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, )
                    strSelStationArr = strAcceptedStation.Split("|")
                    strSelStation = ""
                    For i = 0 To strSelStationArr.Length - 1
                        If strSelStationArr(i).ToString.Trim.Length > 0 Then
                            If strSelStation.Trim.Length > 0 Then strSelStation &= " or "
                            strSelStation &= "WorkStation = '" & strSelStationArr(i) & "'"
                        End If
                    Next i

                    If Not IsDBNull(dt.Compute("Sum(cnt)", strSelStation)) Then Me.lblBoxQty.Text = dt.Compute("Sum(cnt)", strSelStation) Else Me.lblBoxQty.Text = "0"
                    Me.lblModel.Text = dt.Rows(0)("VN_ItemNo")
                    Me._booValidBoxData = True
                End If

                Return strAcceptedStation
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt) : Generic.DisposeDT(dtAcceptedWrkStation)
            End Try
        End Function

        '******************************************************************
        Private Function ProcessRemoveUnitFrFailBucket() As Integer
            Dim dt As DataTable
            Dim strBucket As String = "" 'current workstation
            Dim iDeviceID, iWipOwner, i As Integer

            Try
                If Me.cboTranfToLoc.SelectedIndex < 0 Then
                    MessageBox.Show("Please select transfer to location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtBoxID.SelectAll() : Me.cboTranfToLoc.Focus() : Exit Function
                End If

                dt = Generic.GetDeviceInfoInWIP(Me.txtBoxID.Text, PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID)
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("IMEI does not exist or does not belong to Tracfone.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                ElseIf dt.Rows.Count > 1 Then
                    MessageBox.Show("IMEI open more than one. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                Else
                    iDeviceID = 0 : iWipOwner = 0
                    strBucket = dt.Rows(0)("WorkStation")
                    If strBucket <> "QUARANTINE" AndAlso strBucket <> "BER HOLD" AndAlso strBucket <> "FUNCTIONAL FAIL BS" AndAlso strBucket <> "FUNCTIONAL FAIL CP" AndAlso strBucket <> "FUNCTIONAL FAIL TF" AndAlso strBucket <> "AWAP" Then
                        MessageBox.Show("This IMEI belongs to " & strBucket.ToUpper & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                    ElseIf MessageBox.Show("Are you sure you want to move this unit from " & strBucket.ToUpper & " to " & Me.cboTranfToLoc.Text.ToUpper & "?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No Then
                        Me.txtBoxID.SelectAll()
                        Exit Function
                    Else
                        If strBucket = "AWAP" Then iWipOwner = 1
                        iDeviceID = dt.Rows(0)("Device_ID")
                        i = Generic.SetTcelloptWorkStationForDevice(Me.cboTranfToLoc.Text, iDeviceID, )
                        i += Generic.ResetCostCenter(iDeviceID)

                        If i > 0 Then
                            Me.txtBoxID.Text = "" : Me.txtBoxID.Focus() : Me.lblScanTotal.Text = CInt(Me.lblScanTotal.Text) + 1
                            'MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                End If

                Return iDeviceID
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Private Sub ProcessBox_BER()
            Dim dt As DataTable

            Try
                dt = Me._objTFMisc.GetShipBoxStationCount(Me.txtBoxID.Text.Trim)

                If dt.Rows.Count = 0 Then
                    MessageBox.Show("This Box ID does not exist.", "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                ElseIf dt.Rows.Count > 1 Then
                    MessageBox.Show("Box has multiple workstation.", "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                ElseIf dt.Rows(0)("WorkStation").ToString.Trim.Length = 0 Then
                    MessageBox.Show("This Box does not belong to any workstation.", "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                ElseIf Misc.ValidateFrStationOfScreenInWorkFlow(Me._strScreenName, dt.Rows(0)("WorkStation").ToString.Trim, PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, 0) = False Then
                    Me.txtBoxID.Text = "" : Me.txtBoxID.Focus() : Exit Sub
                Else
                    If IsDBNull(dt.Rows(0)("Pallett_ShipDate")) Then
                        MessageBox.Show("This Box has not completed at production line.", "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                    Else
                        Me._iPalletID = dt.Rows(0)("Pallett_ID")
                        Me._booValidBoxData = True
                        Me.lblBoxQty.Text = dt.Rows(0)("Pallett_QTY")
                        Me.lblModel.Text = dt.Rows(0)("cust_OutgoingSku")
                    End If
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '******************************************************************
        Private Function ProcessBox_BERScreen()
            Dim dt As DataTable
            Dim strCurrentStation As String = ""

            Try
                dt = Me._objTFMisc.GetWHBox(Me.txtBoxID.Text.Trim)

                If dt.Rows.Count = 0 Then
                    MessageBox.Show("This Box ID does not exist.", "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                ElseIf dt.Rows.Count > 1 Then
                    MessageBox.Show("Box name has multiple records. Please contact IT.", "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                ElseIf dt.Rows(0)("Closed").ToString = "0" Then
                    MessageBox.Show("Box is open.", "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                ElseIf dt.Rows(0)("FuncRep").ToString = "0" Then
                    MessageBox.Show("Box is not function repair.", "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                Else
                    dt = Me._objTFMisc.GetBoxStationCount(Me.txtBoxID.Text)
                    If dt.Rows.Count > 1 Then
                        MessageBox.Show("This Box has multiple workstation.", "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                    ElseIf dt.Rows(0)("WorkStation").ToString.Trim.Length = 0 Then
                        MessageBox.Show("This Box does not belong to any workstation.", "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                    ElseIf Misc.ValidateFrStationOfScreenInWorkFlow(Me._strScreenName, dt.Rows(0)("WorkStation").ToString.Trim, PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, 0) = False Then
                        Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                    Else
                        Me.lblBoxQty.Text = dt.Rows(0)("cnt")
                        Me.lblModel.Text = dt.Rows(0)("Model_Desc")
                        Me._booValidBoxData = True
                        strCurrentStation = dt.Rows(0)("WorkStation")
                    End If
                End If
                Return strCurrentStation
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Private Function ProcessTo_Quantine_AWAP_Engineering()
            Dim dt As DataTable
            Dim iDeviceID, i, iWipOwner As Integer
            Dim strNextStation As String = ""

            Try
                dt = Generic.GetDeviceInfoInWIP(Me.txtBoxID.Text, PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID)
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("IMEI does not exist or does not belong to Tracfone.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                ElseIf dt.Rows.Count > 1 Then
                    MessageBox.Show("IMEI open more than one. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                ElseIf dt.Rows(0)("WorkStation").ToString.Trim.Length = 0 Then
                    MessageBox.Show("This device does not belong to any workstation.", "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                ElseIf Not IsDBNull(dt.Rows(0)("Pallett_ID")) Then
                    MessageBox.Show("Device has box assigned.", "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                ElseIf Misc.ValidateFrStationOfScreenInWorkFlow(Me._strScreenName, dt.Rows(0)("WorkStation").ToString.Trim, PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, 0) = False Then
                    Me.txtBoxID.Text = "" : Me.txtBoxID.Focus() : Exit Function
                Else
                    If Me._strScreenName = "To AWAP" Then iWipOwner = 6 Else iWipOwner = 0
                    iDeviceID = 0 : iDeviceID = dt.Rows(0)("Device_ID")
                    strNextStation = Generic.GetNextWorkStationInWFP(_strScreenName, 0, Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, )
                    i = Generic.SetTcelloptWorkStationForDevice(strNextStation, iDeviceID, iWipOwner)

                    If i > 0 Then
                        Me.txtBoxID.Text = "" : Me.txtBoxID.Focus() : Me.lblScanTotal.Text = CInt(Me.lblScanTotal.Text) + 1
                    End If
                End If

                Return iDeviceID
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Private Sub ResetVariablesAndCtrls()
            Me._iPalletID = 0
            Me._booValidBoxData = False
            Me.txtBoxID.Text = ""
            Me.lblBoxQty.Text = ""
            Me.lblModel.Text = ""
            Me.lblScanTotal.Text = "0"
            Me.txtBoxID.Focus()
        End Sub

        '*****************************************************************
        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Try
                Me.ResetVariablesAndCtrls()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnCancel_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*****************************************************************
        Private Sub btnTransfer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransfer.Click
            Dim i As Integer = 0
            Dim strNextStation As String = ""

            Try
                If Me.txtBoxID.Text.Trim.Length > 0 Then
                    If Me._strScreenName = "To Staging" Or Me._strScreenName = "To Pretest" Or Me._strScreenName = "To Prebill" Or Me._strScreenName = "To RF1" _
                       Or Me._strScreenName = "To Obsolete" Or Me._strScreenName = "To Production Hold" Then
                        Me.ProcessBox_Staging_Pretest_Prebill_Obsolete_ProdHold()

                        If Me.rbtnBoxID.Checked = True AndAlso (Me.lblBoxQty.Text = "0" OrElse Me.lblBoxQty.Text = "") Then
                            MessageBox.Show("Box is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Me.txtBoxID.SelectAll() : Me.txtBoxID.Focus() : Exit Sub
                        End If

                        If Me._booValidBoxData = True Then
                            strNextStation = Generic.GetNextWorkStationInWFP(_strScreenName, 0, Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, )
                            If strNextStation.Trim.Length = 0 Then
                                MessageBox.Show("Workstation is missing in work flow. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Else
                                i = Me._objTFMisc.PushWBBoxToWorkArea(Me.txtBoxID.Text.Trim, strNextStation)
                                If i > 0 Then
                                    MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                    Me.ResetVariablesAndCtrls()
                                    Me.txtBoxID.Focus()
                                End If
                            End If
                        Else
                            MessageBox.Show("Box ID does not pass validation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        End If
                    ElseIf Me._strScreenName = "To WH-RB" Then
                        Me.ProcessBox_CageRB()

                        If Me.rbtnBoxID.Checked = True AndAlso (Me.lblBoxQty.Text = "0" OrElse Me.lblBoxQty.Text = "") Then
                            MessageBox.Show("Box is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Me.txtBoxID.SelectAll() : Me.txtBoxID.Focus() : Exit Sub
                        End If

                        If Me._booValidBoxData = True AndAlso Me._iPalletID > 0 Then
                            strNextStation = Generic.GetNextWorkStationInWFP(_strScreenName, 0, Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, )
                            If strNextStation.Trim.Length = 0 Then
                                MessageBox.Show("Workstation is missing in work flow. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Else
                                i = Me._objTFMisc.PushShipBoxToNextStation(Me._iPalletID, strNextStation)
                                If i > 0 Then
                                    MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                    Me.ResetVariablesAndCtrls()
                                    Me.txtBoxID.Focus()
                                End If
                            End If
                        Else
                            MessageBox.Show("Box ID does not pass validation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        End If
                    ElseIf Me._strScreenName.Trim.StartsWith("To Functional Fail") = True Or Me._strScreenName.StartsWith("To BER HOLD") = True Or Me._strScreenName.StartsWith("To AWAP") = True Then
                        Me.ProcessBox_FuncFailUnits()
                    ElseIf Me._strScreenName = "To WH-WIP" Then
                        Dim strAcceptedStation = Me.ProcessBox_WHWIP()

                        If Me.lblBoxQty.Text = "0" OrElse Me.lblBoxQty.Text = "" Then
                            MessageBox.Show("Box is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Me.txtBoxID.SelectAll() : Me.txtBoxID.Focus() : Exit Sub
                        End If

                        If Me._booValidBoxData = True Then
                            strNextStation = Generic.GetNextWorkStationInWFP(_strScreenName, 0, Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, )
                            If strNextStation.Trim.Length = 0 Then
                                MessageBox.Show("Workstation is missing in work flow. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Else
                                i = Me._objTFMisc.PushWBBoxToWHWIP(Me.txtBoxID.Text.Trim, strNextStation, strAcceptedStation)
                                If i > 0 Then
                                    MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                    Me.ResetVariablesAndCtrls()
                                    Me.txtBoxID.Focus()
                                End If
                            End If
                        Else
                            MessageBox.Show("Box ID does not pass validation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        End If
                    ElseIf Me._strScreenName = "Remove From Fail and AWAP" Then
                        Me.ProcessRemoveUnitFrFailBucket()
                    ElseIf Me._strScreenName = "To Teardown" Or Me._strScreenName = "To BER" Or Me._strScreenName = "To BER Complete" Then
                        '***********************************************
                        'BER: 
                        '***********************************************
                        Me.ProcessBox_BER()
                        If Me._booValidBoxData = True Then
                            strNextStation = Generic.GetNextWorkStationInWFP(_strScreenName, 0, Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, )
                            If strNextStation.Trim.Length = 0 Then
                                MessageBox.Show("Workstation is missing in work flow. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Else
                                i = Me._objTFMisc.PushShipBoxToNextStation(Me._iPalletID, strNextStation)
                                If i > 0 Then
                                    If Me._strScreenName = "To BER" Then Me._objTFMisc.CreateBERInvoiceTransaction(Me._iPalletID)

                                    MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                    Me.ResetVariablesAndCtrls()
                                    Me.txtBoxID.Focus()
                                End If
                            End If
                        Else
                            MessageBox.Show("Box ID does not pass validation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        End If
                        '***********************************************
                    ElseIf Me._strScreenName = "To QUARANTINE" Then
                        Me.ProcessBox_Quarantine()
                        If Me._booValidBoxData = True Then
                            strNextStation = Generic.GetNextWorkStationInWFP(_strScreenName, 0, Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, )
                            If strNextStation.Trim.Length = 0 Then
                                MessageBox.Show("Workstation is missing in work flow. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Else
                                i = Me._objTFMisc.PushWBBoxToWorkArea(Me.txtBoxID.Text.Trim, strNextStation)
                                If i > 0 Then
                                    MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                    Me.ResetVariablesAndCtrls()
                                    Me.txtBoxID.Focus()
                                End If
                            End If
                        Else
                            MessageBox.Show("Box ID does not pass validation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        End If
                    ElseIf Me._strScreenName = "To BER Screen" Then
                        Me.ProcessBox_BERScreen()
                        If Me._booValidBoxData = True Then
                            strNextStation = Generic.GetNextWorkStationInWFP(_strScreenName, 0, Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, )
                            If strNextStation.Trim.Length = 0 Then
                                MessageBox.Show("Workstation is missing in work flow. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Else
                                i = Me._objTFMisc.PushWBBoxToWorkArea(Me.txtBoxID.Text.Trim, strNextStation)
                                If i > 0 Then
                                    MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                    Me.ResetVariablesAndCtrls()
                                    Me.txtBoxID.Focus()
                                End If
                            End If
                        Else
                            MessageBox.Show("Box ID does not pass validation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        End If
                    Else
                        MessageBox.Show("This screen's not available.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                Else
                    MessageBox.Show("Please enter box name to transfer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnTransfer_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*****************************************************************
        Private Sub txtIMEI_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIMEI.KeyUp
            Try
                If e.KeyCode = Keys.Enter AndAlso Me.txtIMEI.Text.Trim.Length > 0 Then
                    PopulateDeptDocDBG()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtIMEI_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*****************************************************************
        Private Sub btnGo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGo.Click
            Try
                If Me.txtIMEI.Text.Trim.Length > 0 Then
                    PopulateDeptDocDBG()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnGo_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '********************************************************************
        Public Sub PopulateDeptDocDBG()
            Dim dt As DataTable
            Try
                Me.dbgData.DataSource = Nothing
                If Me.txtIMEI.Text <> "" Then
                    dt = Me._objTFMisc.GetDeviceBoxID(Me.txtIMEI.Text)
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("This unit does not exist.", "PopulateDeptDocDBG", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                    With Me.dbgData
                        .DataSource = dt.DefaultView
                        SetGridGroupModelProperties()
                    End With
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "PopulateDeptDocDBG", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '********************************************************************
        Private Sub SetGridGroupModelProperties()
            Dim iNumOfColumns As Integer = Me.dbgData.Columns.Count
            Dim i As Integer

            With Me.dbgData
                'Heading style (Horizontal Alignment to Center)
                For i = 0 To (iNumOfColumns - 1)
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    .Splits(0).DisplayColumns(i).Visible = True
                Next
                'header forecolor
                .Splits(0).DisplayColumns(0).HeadingStyle.ForeColor = .ForeColor.Black
                .Splits(0).DisplayColumns(1).HeadingStyle.ForeColor = .ForeColor.Black
                .Splits(0).DisplayColumns(2).HeadingStyle.ForeColor = .ForeColor.Black

                'Body Forecolor
                .Splits(0).DisplayColumns(0).Style.ForeColor = .ForeColor.Black
                .Splits(0).DisplayColumns(1).Style.ForeColor = .ForeColor.Black
                .Splits(0).DisplayColumns(2).Style.ForeColor = .ForeColor.Black

                'Set Column Widths
                .Splits(0).DisplayColumns("Order#").Width = 120
                .Splits(0).DisplayColumns("Box ID").Width = 120
                .Splits(0).DisplayColumns("Manuf Date").Width = 130
                .Splits(0).DisplayColumns("Current Station").Width = 150

                .AlternatingRows = True
            End With
        End Sub

        '********************************************************************
        Private Sub rbtnBoxID_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtnBoxID.CheckedChanged
            If Me.rbtnBoxID.Enabled = True Then
                If Me.rbtnBoxID.Checked = True Then
                    Me.Panel1.Visible = True
                Else
                    Me.Panel1.Visible = False
                End If
                lblBoxQty.Text = "" : lblModel.Text = ""
                Me.txtBoxID.SelectAll() : Me.txtBoxID.Focus()
            End If
        End Sub

        '********************************************************************

    End Class
End Namespace