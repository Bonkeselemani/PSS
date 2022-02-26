Option Explicit On 

Imports System.IO

Namespace Gui.DriveCam
    Public Class frmDCShipBox
        Inherits System.Windows.Forms.Form

        Private _objDC As PSS.Data.Buisness.DriveCam
        Private _objBulkShip As PSS.Data.Buisness.BulkShipping

        Private iMachineCCGroup As Integer = 0
        Private iPallett_ID As Integer = 0
        Private strPalletName As String = ""
        Private iShipType As Integer = 0
        Private strShipTypeDesc As String = ""
        Private strSKULength As String = ""
        Private iModel_ID As Integer = 0
        Private iFileCheckDone As Integer = 0
        Private iHoldStatus As Integer = 0
        Private iGroup_ID As Integer = 0
        Private iCustID As Integer = 0
        Private iLocID As Integer = 0
        Private iFlg As Integer = 0

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _objDC = New PSS.Data.Buisness.DriveCam()
            _objBulkShip = New PSS.Data.Buisness.BulkShipping()
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
        Friend WithEvents PanelList As System.Windows.Forms.Panel
        Friend WithEvents lstRUR As System.Windows.Forms.ListBox
        Friend WithEvents lstRegular As System.Windows.Forms.ListBox
        Friend WithEvents cmdShip As System.Windows.Forms.Button
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents cmdClear As System.Windows.Forms.Button
        Friend WithEvents lstRURRTMParts As System.Windows.Forms.ListBox
        Friend WithEvents cmdFileCheck As System.Windows.Forms.Button
        Friend WithEvents lblGridCaption As System.Windows.Forms.Label
        Friend WithEvents lblCnt As System.Windows.Forms.Label
        Friend WithEvents lbl As System.Windows.Forms.Label
        Friend WithEvents grdPallets As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents cmdReprintPalletLabel As System.Windows.Forms.Button
        Friend WithEvents btnPrintManifestRpt As System.Windows.Forms.Button
        Friend WithEvents lblPallet As System.Windows.Forms.Label
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents btnRecreateReport As System.Windows.Forms.Button
        Friend WithEvents chkPrintManifestReport As System.Windows.Forms.CheckBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmDCShipBox))
            Me.PanelList = New System.Windows.Forms.Panel()
            Me.lstRUR = New System.Windows.Forms.ListBox()
            Me.lstRegular = New System.Windows.Forms.ListBox()
            Me.cmdShip = New System.Windows.Forms.Button()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.cmdClear = New System.Windows.Forms.Button()
            Me.lstRURRTMParts = New System.Windows.Forms.ListBox()
            Me.cmdFileCheck = New System.Windows.Forms.Button()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.chkPrintManifestReport = New System.Windows.Forms.CheckBox()
            Me.lblGridCaption = New System.Windows.Forms.Label()
            Me.lblCnt = New System.Windows.Forms.Label()
            Me.lbl = New System.Windows.Forms.Label()
            Me.grdPallets = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.cmdReprintPalletLabel = New System.Windows.Forms.Button()
            Me.btnPrintManifestRpt = New System.Windows.Forms.Button()
            Me.lblPallet = New System.Windows.Forms.Label()
            Me.btnRecreateReport = New System.Windows.Forms.Button()
            Me.PanelList.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            CType(Me.grdPallets, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'PanelList
            '
            Me.PanelList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.PanelList.Controls.AddRange(New System.Windows.Forms.Control() {Me.lstRUR, Me.lstRegular, Me.cmdShip, Me.Label1, Me.Label2, Me.Label12, Me.cmdClear, Me.lstRURRTMParts, Me.cmdFileCheck, Me.GroupBox2})
            Me.PanelList.Location = New System.Drawing.Point(1, 248)
            Me.PanelList.Name = "PanelList"
            Me.PanelList.Size = New System.Drawing.Size(703, 288)
            Me.PanelList.TabIndex = 84
            Me.PanelList.Visible = False
            '
            'lstRUR
            '
            Me.lstRUR.Location = New System.Drawing.Point(144, 40)
            Me.lstRUR.Name = "lstRUR"
            Me.lstRUR.Size = New System.Drawing.Size(128, 186)
            Me.lstRUR.TabIndex = 4
            '
            'lstRegular
            '
            Me.lstRegular.Location = New System.Drawing.Point(7, 40)
            Me.lstRegular.Name = "lstRegular"
            Me.lstRegular.Size = New System.Drawing.Size(129, 186)
            Me.lstRegular.TabIndex = 5
            '
            'cmdShip
            '
            Me.cmdShip.BackColor = System.Drawing.Color.LightSteelBlue
            Me.cmdShip.Enabled = False
            Me.cmdShip.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdShip.ForeColor = System.Drawing.Color.Blue
            Me.cmdShip.Location = New System.Drawing.Point(440, 240)
            Me.cmdShip.Name = "cmdShip"
            Me.cmdShip.Size = New System.Drawing.Size(248, 34)
            Me.cmdShip.TabIndex = 1
            Me.cmdShip.Text = "SHIP"
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(12, 24)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(99, 16)
            Me.Label1.TabIndex = 4
            Me.Label1.Text = "Regular Units:"
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(144, 24)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(92, 16)
            Me.Label2.TabIndex = 5
            Me.Label2.Text = "RUR Units:"
            '
            'Label12
            '
            Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label12.ForeColor = System.Drawing.Color.White
            Me.Label12.Location = New System.Drawing.Point(280, 8)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(120, 29)
            Me.Label12.TabIndex = 55
            Me.Label12.Text = "RUR Units with Parts:"
            '
            'cmdClear
            '
            Me.cmdClear.BackColor = System.Drawing.Color.LightSteelBlue
            Me.cmdClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdClear.ForeColor = System.Drawing.Color.Black
            Me.cmdClear.Location = New System.Drawing.Point(8, 240)
            Me.cmdClear.Name = "cmdClear"
            Me.cmdClear.Size = New System.Drawing.Size(80, 34)
            Me.cmdClear.TabIndex = 2
            Me.cmdClear.Text = "Clear"
            '
            'lstRURRTMParts
            '
            Me.lstRURRTMParts.Location = New System.Drawing.Point(280, 40)
            Me.lstRURRTMParts.Name = "lstRURRTMParts"
            Me.lstRURRTMParts.Size = New System.Drawing.Size(128, 186)
            Me.lstRURRTMParts.TabIndex = 6
            '
            'cmdFileCheck
            '
            Me.cmdFileCheck.BackColor = System.Drawing.Color.LightSteelBlue
            Me.cmdFileCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdFileCheck.ForeColor = System.Drawing.Color.Black
            Me.cmdFileCheck.Location = New System.Drawing.Point(104, 240)
            Me.cmdFileCheck.Name = "cmdFileCheck"
            Me.cmdFileCheck.Size = New System.Drawing.Size(320, 34)
            Me.cmdFileCheck.TabIndex = 0
            Me.cmdFileCheck.Text = "FILE CHECK (DO I HAVE THE RIGHT BOX?)"
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkPrintManifestReport})
            Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox2.ForeColor = System.Drawing.Color.White
            Me.GroupBox2.Location = New System.Drawing.Point(440, 168)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(248, 54)
            Me.GroupBox2.TabIndex = 83
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Option"
            '
            'chkPrintManifestReport
            '
            Me.chkPrintManifestReport.Checked = True
            Me.chkPrintManifestReport.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkPrintManifestReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkPrintManifestReport.ForeColor = System.Drawing.Color.White
            Me.chkPrintManifestReport.Location = New System.Drawing.Point(16, 22)
            Me.chkPrintManifestReport.Name = "chkPrintManifestReport"
            Me.chkPrintManifestReport.Size = New System.Drawing.Size(208, 24)
            Me.chkPrintManifestReport.TabIndex = 0
            Me.chkPrintManifestReport.Text = "PRINT MANIFEST REPORT"
            '
            'lblGridCaption
            '
            Me.lblGridCaption.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblGridCaption.ForeColor = System.Drawing.Color.White
            Me.lblGridCaption.Location = New System.Drawing.Point(2, 56)
            Me.lblGridCaption.Name = "lblGridCaption"
            Me.lblGridCaption.Size = New System.Drawing.Size(280, 16)
            Me.lblGridCaption.TabIndex = 88
            Me.lblGridCaption.Text = "Boxs to be Completed:"
            '
            'lblCnt
            '
            Me.lblCnt.BackColor = System.Drawing.Color.Black
            Me.lblCnt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblCnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCnt.ForeColor = System.Drawing.Color.Lime
            Me.lblCnt.Location = New System.Drawing.Point(624, 16)
            Me.lblCnt.Name = "lblCnt"
            Me.lblCnt.Size = New System.Drawing.Size(78, 40)
            Me.lblCnt.TabIndex = 86
            Me.lblCnt.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'lbl
            '
            Me.lbl.BackColor = System.Drawing.Color.Black
            Me.lbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbl.ForeColor = System.Drawing.Color.Yellow
            Me.lbl.Location = New System.Drawing.Point(1, 0)
            Me.lbl.Name = "lbl"
            Me.lbl.Size = New System.Drawing.Size(359, 56)
            Me.lbl.TabIndex = 85
            Me.lbl.Text = "DRIVECAM SHIP BOX"
            Me.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'grdPallets
            '
            Me.grdPallets.AllowColMove = False
            Me.grdPallets.AllowColSelect = False
            Me.grdPallets.AllowFilter = False
            Me.grdPallets.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
            Me.grdPallets.AllowUpdate = False
            Me.grdPallets.AllowUpdateOnBlur = False
            Me.grdPallets.AlternatingRows = True
            Me.grdPallets.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grdPallets.GroupByCaption = "Drag a column header here to group by that column"
            Me.grdPallets.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.grdPallets.Location = New System.Drawing.Point(1, 72)
            Me.grdPallets.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.grdPallets.Name = "grdPallets"
            Me.grdPallets.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.grdPallets.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.grdPallets.PreviewInfo.ZoomFactor = 75
            Me.grdPallets.RowHeight = 20
            Me.grdPallets.Size = New System.Drawing.Size(359, 170)
            Me.grdPallets.TabIndex = 82
            Me.grdPallets.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Style9{}Normal{Font:Microsoft Sans Serif, 8.25pt;BackColor:LightSteelBlue;Al" & _
            "ignVert:Center;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style1" & _
            "2{}OddRow{BackColor:LightSteelBlue;}RecordSelector{AlignImage:Center;}Style13{}H" & _
            "eading{Wrap:True;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;" & _
            "BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Cent" & _
            "er;}Style8{}Style10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style1{}</Data></" & _
            "Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelec" & _
            "t=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""True"" CaptionHeight" & _
            "=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellB" & _
            "order"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" Hori" & _
            "zontalScrollGroup=""1""><Height>166</Height><CaptionStyle parent=""Style2"" me=""Styl" & _
            "e10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow""" & _
            " me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle pa" & _
            "rent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingSt" & _
            "yle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""" & _
            "Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""Od" & _
            "dRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" />" & _
            "<SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1" & _
            """ /><ClientRect>0, 0, 355, 166</ClientRect><BorderSide>0</BorderSide><BorderStyl" & _
            "e>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Sty" & _
            "le parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""" & _
            "Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Hea" & _
            "ding"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Norm" & _
            "al"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Norm" & _
            "al"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" " & _
            "me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Cap" & _
            "tion"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSp" & _
            "lits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea" & _
            ">0, 0, 355, 166</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><Prin" & _
            "tPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'Label6
            '
            Me.Label6.BackColor = System.Drawing.Color.Black
            Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.White
            Me.Label6.Location = New System.Drawing.Point(624, 0)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(78, 16)
            Me.Label6.TabIndex = 87
            Me.Label6.Text = "COUNT"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'cmdReprintPalletLabel
            '
            Me.cmdReprintPalletLabel.BackColor = System.Drawing.Color.LightSteelBlue
            Me.cmdReprintPalletLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdReprintPalletLabel.ForeColor = System.Drawing.Color.Black
            Me.cmdReprintPalletLabel.Location = New System.Drawing.Point(393, 73)
            Me.cmdReprintPalletLabel.Name = "cmdReprintPalletLabel"
            Me.cmdReprintPalletLabel.Size = New System.Drawing.Size(311, 24)
            Me.cmdReprintPalletLabel.TabIndex = 90
            Me.cmdReprintPalletLabel.Text = "REPRINT BOX LABEL"
            '
            'btnPrintManifestRpt
            '
            Me.btnPrintManifestRpt.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnPrintManifestRpt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPrintManifestRpt.ForeColor = System.Drawing.Color.Black
            Me.btnPrintManifestRpt.Location = New System.Drawing.Point(393, 128)
            Me.btnPrintManifestRpt.Name = "btnPrintManifestRpt"
            Me.btnPrintManifestRpt.Size = New System.Drawing.Size(311, 24)
            Me.btnPrintManifestRpt.TabIndex = 91
            Me.btnPrintManifestRpt.Text = "RePrint Excel Manifest Report"
            '
            'lblPallet
            '
            Me.lblPallet.BackColor = System.Drawing.Color.Black
            Me.lblPallet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPallet.ForeColor = System.Drawing.Color.Lime
            Me.lblPallet.Location = New System.Drawing.Point(360, 0)
            Me.lblPallet.Name = "lblPallet"
            Me.lblPallet.Size = New System.Drawing.Size(256, 56)
            Me.lblPallet.TabIndex = 89
            Me.lblPallet.Text = "84DC090812N002"
            Me.lblPallet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnRecreateReport
            '
            Me.btnRecreateReport.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnRecreateReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRecreateReport.ForeColor = System.Drawing.Color.Black
            Me.btnRecreateReport.Location = New System.Drawing.Point(392, 176)
            Me.btnRecreateReport.Name = "btnRecreateReport"
            Me.btnRecreateReport.Size = New System.Drawing.Size(311, 24)
            Me.btnRecreateReport.TabIndex = 92
            Me.btnRecreateReport.Text = "Re-create Excel Manifest Report"
            '
            'frmDCShipBox
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(752, 541)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRecreateReport, Me.PanelList, Me.lblGridCaption, Me.lblCnt, Me.lbl, Me.grdPallets, Me.Label6, Me.cmdReprintPalletLabel, Me.btnPrintManifestRpt, Me.lblPallet})
            Me.Name = "frmDCShipBox"
            Me.Text = "frmDCShipBox"
            Me.PanelList.ResumeLayout(False)
            Me.GroupBox2.ResumeLayout(False)
            CType(Me.grdPallets, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '*****************************************************************
        Protected Overrides Sub Finalize()
            _objDC = Nothing
            _objBulkShip = Nothing
            MyBase.Finalize()
        End Sub

        '*****************************************************************
        Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
            ClearControls()
        End Sub

        '*****************************************************************
        Private Sub ClearListControls()
            Me.lstRegular.Items.Clear()
            Me.lstRUR.Items.Clear()
            Me.lstRURRTMParts.Items.Clear()
            Me.lblCnt.Text = ""
            Me.lblPallet.Text = ""
        End Sub

        '*****************************************************************
        Private Sub ClearControls()
            iPallett_ID = 0
            strPalletName = ""
            iShipType = 0
            Me.strShipTypeDesc = ""
            strSKULength = ""
            iModel_ID = 0
            iFileCheckDone = 0
            iHoldStatus = 0
            iGroup_ID = 0
            iCustID = 0
            iLocID = 0
            iFlg = 0

            Me.PanelList.Visible = False

            Me.BackColor = System.Drawing.Color.SteelBlue
            System.Windows.Forms.Application.DoEvents()

            '*********************
            'objBulkShip Variables
            Me._objBulkShip.iLoc_ID = 0
            Me._objBulkShip.iBulkShipped = 0
            Me._objBulkShip.iShipType = 0
            Me._objBulkShip.strFilePath = ""
            Me._objBulkShip.iPallet_ID = 0

            If Not IsNothing(_objBulkShip.dtExcelSNs) Then
                _objBulkShip.dtExcelSNs.Dispose()
                _objBulkShip.dtExcelSNs = Nothing
            End If
            If Not IsNothing(_objBulkShip.dtWO) Then
                _objBulkShip.dtWO.Dispose()
                _objBulkShip.dtWO = Nothing
            End If
            '*********************
        End Sub

        '*****************************************************************
        Private Sub frmMessProdShip_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                Me.iMachineCCGroup = PSS.Data.Buisness.Generic.GetMachineCostCenterGrpID()
                If Me.iMachineCCGroup = 0 Then
                    Throw New Exception("Machine is not mapped to any group.")
                End If

                Me._objBulkShip.iShiftID = PSS.Core.ApplicationUser.IDShift
                Me._objBulkShip.struser = PSS.Core.ApplicationUser.User

                LoadPallets()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Form_Load()", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '******************************************************************
        Private Sub LoadPallets()
            Dim dtPallets As DataTable

            Try
                ClearControls()
                dtPallets = Me._objBulkShip.GetPalletsReadyToBeShipped(iHoldStatus, iMachineCCGroup)
                Me.grdPallets.ClearFields()
                Me.grdPallets.DataSource = dtPallets.DefaultView
                SetPalletGridProperties()
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dtPallets) Then
                    dtPallets.Dispose()
                    dtPallets = Nothing
                End If
            End Try
        End Sub

        '******************************************************************
        Private Sub SetPalletGridProperties()
            Dim iNumOfColumns As Integer = Me.grdPallets.Columns.Count
            Dim i As Integer


            With Me.grdPallets
                'Heading style (Horizontal Alignment to Center)
                For i = 0 To (iNumOfColumns - 1)
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Next

                'Set individual column data horizontal alignment
                .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns(3).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns(4).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                'Set Column Widths
                .Splits(0).DisplayColumns(1).Width = 140
                .Splits(0).DisplayColumns(2).Width = 45
                .Splits(0).DisplayColumns(3).Width = 69
                .Splits(0).DisplayColumns(4).Width = 81

                'Make some columns invisible
                .Splits(0).DisplayColumns(0).Visible = False
                .Splits(0).DisplayColumns(5).Visible = False
                .Splits(0).DisplayColumns(6).Visible = False
                .Splits(0).DisplayColumns(7).Visible = False
                .Splits(0).DisplayColumns(8).Visible = False

            End With
        End Sub

        '******************************************************************
        Private Sub grdPallets_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdPallets.Click
            iFlg = 1
        End Sub

        '******************************************************************
        Private Sub grdPallets_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles grdPallets.RowColChange
            If iFlg = 0 Then
                Exit Sub
            End If
            If Me.grdPallets.Columns.Count = 0 OrElse Me.grdPallets.RowCount = 0 Then
                Exit Sub
            End If
            ProcessPallet()
        End Sub

        '******************************************************************
        Private Sub ProcessPallet()
            Dim iExcelNum As Integer = 0
            Dim iPSSNum As Integer = 0
            Dim R1 As DataRow
            Dim i As Integer = 0
            Dim strFilePath As String = ""

            Try
                Cursor.Current = Cursors.WaitCursor
                Me.BackColor = System.Drawing.Color.SteelBlue
                System.Windows.Forms.Application.DoEvents()

                ClearListControls()
                Me.PanelList.Visible = True
                '************************************************
                'Retrieve Grid info
                '************************************************
                iPallett_ID = Me.grdPallets.Columns("pallett_id").Value
                strPalletName = Trim(Me.grdPallets.Columns("Pallet").Value.ToString)
                iLocID = Me.grdPallets.Columns("Loc_ID").Value
                iModel_ID = Me.grdPallets.Columns("Model_ID").Value
                iShipType = Me.grdPallets.Columns("Pallet_ShipType").Value
                strSKULength = Trim(Me.grdPallets.Columns("SKU Length").Value.ToString)
                iGroup_ID = Me.grdPallets.Columns("group_id").Value
                strShipTypeDesc = Me.grdPallets.Columns("Ship Type").Value
                iCustID = Me.grdPallets.Columns("Cust_ID").Value
                If iCustID = 2266 Then
                    strFilePath = PSS.Data.Buisness.DriveCam.VeoliaTrans_MANIFEST_DIR
                ElseIf iCustID = 2279 Then  'Greater Houston Transportation Co
                    strFilePath = "P:\Dept\Greater Houston Transportation\Pallet Packing List\"
                Else
                    strFilePath = PSS.Data.Buisness.DriveCam.MANIFEST_DIR
                End If
                If strFilePath.Trim.Length = 0 Then Throw New Exception("Box manifest file path missing (Cust_ID in tpallett needs to be updated).")

                '************************************************
                'Check if the excel file exists
                '************************************************
                strFilePath = strFilePath & strPalletName & ".xls"
                If Not File.Exists(strFilePath) Then
                    Throw New Exception("Excel manifest was not found in '" & strFilePath & "'")
                End If
                '************************************************
                Me.lblPallet.Text = strPalletName
                '*********************
                'objBulkShip variables
                Me._objBulkShip.iLoc_ID = iLocID
                Me._objBulkShip.iBulkShipped = 1
                Me._objBulkShip.iShipType = iShipType
                Me._objBulkShip.strFilePath = strFilePath
                Me._objBulkShip.iPallet_ID = iPallett_ID
                Me._objBulkShip.iGroup_ID = iGroup_ID
                Me._objBulkShip.iShiftID = PSS.Core.ApplicationUser.IDShift
                Me._objBulkShip.struser = PSS.Core.ApplicationUser.User
                Me._objBulkShip.iCust_ID = iCustID
                '*********************
                iFileCheckDone = 0
                '************************************************
                'Step 1 :: Extract SN numbers from the excel file
                '************************************************
                iExcelNum = _objBulkShip.ExtractSNsFrExcelRpt("SN", )
                If iExcelNum > 0 Then

                    '#############################################################
                    ''' STEP2 ::
                    '''Obtain and set validation data.
                    ''' Broken down in to pieces as far as getting data is concerned 
                    ''' because not all customers need all these validations.
                    ''' This will be easier to brach out the code.
                    '#############################################################

                    '***********************************************************
                    '(A) :: Get Model
                    '***********************************************************
                    '***********************************************
                    'Add WO_ID column to dtWO datatable
                    '***********************************************
                    If Not IsNothing(Me._objBulkShip.dtWO) Then
                        Me._objBulkShip.dtWO.Clear()
                    Else
                        Me._objBulkShip.dtWO = New DataTable() '("WO")
                        PSS.Data.Buisness.Generic.AddNewColumnToDataTable(Me._objBulkShip.dtWO, "WO_ID", "System.Int32", )
                    End If
                    iPSSNum = 0
                    For Each R1 In _objBulkShip.dtExcelSNs.Rows
                        iPSSNum += _objBulkShip.ChechkModel(R1, R1("SN"))
                    Next R1
                    If iExcelNum <> iPSSNum Then
                        Throw New Exception("cmdSelectFile_Click.GetModel:: Records from excel file don't have same number of records from PSS Database.")
                    End If

                    '***********************************************************
                    '(C) :: Get Billcoderule
                    '***********************************************************
                    iPSSNum = 0
                    For Each R1 In _objBulkShip.dtExcelSNs.Rows
                        iPSSNum += _objBulkShip.CheckBillcodeRule(R1, Trim(R1("SN")), True)
                        'Check AQL Pass
                        If R1("BillCode_Rule") = 0 AndAlso Me._objDC.IsAQLPassed(R1("device_ID")) = False Then Throw New Exception("Serial number (" & Trim(R1("SN")) & ") has not been passed at AQL.")
                    Next R1
                    If iExcelNum <> iPSSNum Then
                        Throw New Exception("cmdSelectFile_Click.GetBillcodeRule:: Records from excel file don't have same number of records from PSS Database.")
                    Else
                        Me.lblCnt.Text = iPSSNum
                    End If

                    '*******************************************************
                    For Each R1 In _objBulkShip.dtExcelSNs.Rows
                        '*******************************************************
                        '(C) Display Device by BILLCODERULE
                        '*******************************************************
                        If R1("Billcode_rule") = 1 Or R1("Billcode_rule") = 2 Then 'RUR/DBR
                            Me.lstRUR.Items.Add(Trim(R1("SN")))
                        ElseIf R1("Billcode_rule") = 0 Then 'Regular
                            Me.lstRegular.Items.Add(Trim(R1("SN")))
                        End If
                    Next R1
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Finally
                R1 = Nothing
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        '******************************************************************
        Private Sub cmdFileCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFileCheck.Click
            Dim strSN As String = ""
            Dim R1 As DataRow
            Dim iMatch As Integer = 0

            Try
                If Not IsNothing(_objBulkShip.dtExcelSNs) Then
                    strSN = InputBox("Please scan in a 'Serial Number' to make sure you have selected the right file.").Trim.ToUpper
                    If strSN <> "" Then
                        For Each R1 In _objBulkShip.dtExcelSNs.Rows
                            If strSN = Trim(R1("SN")).ToUpper Then
                                iMatch = 1
                                Exit For
                            End If
                        Next R1
                    End If
                    '0 - File Check not done
                    '1 - DOne but SN not in file
                    '2 - Right file.
                    If iMatch = 1 Then
                        iFileCheckDone = 2
                        Me.BackColor = System.Drawing.Color.SteelBlue
                        System.Windows.Forms.Application.DoEvents()
                        MessageBox.Show("Serial Number exists in the file.", "File Check", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Me.cmdShip.Enabled = True
                    ElseIf iMatch = 0 Then
                        iFileCheckDone = 1
                        Me.BackColor = System.Drawing.Color.Red
                        System.Windows.Forms.Application.DoEvents()
                        MessageBox.Show("STOP! Serial Number does not exist in the file.", "File Check", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Me.cmdShip.Enabled = False
                    End If
                End If

            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            Finally
                R1 = Nothing
            End Try
        End Sub

        '******************************************************************
        Private Sub cmdShip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShip.Click
            Dim i As Integer = 0
            Dim iPrintCopies As Integer = 2
            Dim booPrintRpt As Boolean = True

            Try
                '*****************************************************
                'Make sure a file has been selected and FILE CHECK done
                Me.cmdShip.Enabled = False
                If iFileCheckDone = 0 Then
                    Throw New Exception("File check has not been done.")
                ElseIf iFileCheckDone = 1 Then
                    Me.BackColor = System.Drawing.Color.Red
                    System.Windows.Forms.Application.DoEvents()
                    Throw New Exception("Serial Number you have scanned in to do 'File Check' did not exist in the file.")
                End If

                '******************************************************
                'Bulk SHIP now.
                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                i = _objBulkShip.BulkShip(Me.chkPrintManifestReport.Checked, iHoldStatus, CInt(Me.lblCnt.Text), , 0)

                ''print license plate
                'Generic.PrintPalletLicensePlate(Me.strPalletName, Me.iModel_ID, Me.strShipTypeDesc, Me.lblCnt.Text, iPrintCopies)
                ''******************************************************

                ClearControls()
                LoadPallets()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Ship Boxs", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        '******************************************************************
        Private Sub cmdReprintPalletLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReprintPalletLabel.Click
            Dim str_pallett As String = ""
            Dim dtPallettInfo As DataTable
            Dim strPalletType As String = ""
            Dim iPalletQty As Integer = 0
            Dim R1 As DataRow
            Dim objMisc As PSS.Data.Buisness.Misc

            Try
                str_pallett = InputBox("Enter Box Name.", "Reprint Box Label")
                If str_pallett = "" Then
                    Throw New Exception("Please enter a Box Name if you want to reprint the box label.")
                End If

                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor
                objMisc = New PSS.Data.Buisness.Misc()

                dtPallettInfo = objMisc.GetPalletInfo_ByPallettName(str_pallett)
                If dtPallettInfo.Rows.Count = 0 Then
                    MessageBox.Show("Box Name was not defined in system.", "Reprint Box Label", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Exit Sub
                ElseIf dtPallettInfo.Rows.Count > 1 Then
                    MessageBox.Show("Box Name existed twice in the system.", "Reprint Box Label", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Exit Sub
                Else
                    R1 = dtPallettInfo.Rows(0)

                    If R1("Pallett_ReadyToShipFlg") = 0 Then
                        MessageBox.Show("Box is still open.", "Information", MessageBoxButtons.OK)
                        Exit Sub
                    End If

                    If Not IsDBNull(R1("Pallett_QTY")) Then iPalletQty = R1("Pallett_QTY")

                    If Not IsDBNull(R1("Cust_ID")) Then
                        PSS.Data.Production.Shipping.PrintBoxLabel(str_pallett)
                        '_objMisc.PrintPalletDeviceCountRpt(R1("Pallett_ID"), R1("Cust_ID"), 1)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Reprint Box Label.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                objMisc = Nothing
                R1 = Nothing
                If Not IsNothing(dtPallettInfo) Then
                    dtPallettInfo.Dispose()
                    dtPallettInfo = Nothing
                End If
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        '******************************************************************
        Private Sub btnPrintManifestRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintManifestRpt.Click
            Dim strBoxName, strManifestDir As String
            Dim objMisc As PSS.Data.Buisness.Misc
            Dim dtPallettInfo As DataTable

            Try
                strBoxName = "" : strManifestDir = ""
                strBoxName = InputBox("Enter Box Name.", "Reprint Box Label")
                If strBoxName = "" Then
                    MessageBox.Show("Please enter a Box Name if you want to reprint manifest report", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                objMisc = New PSS.Data.Buisness.Misc()
                dtPallettInfo = objMisc.GetPalletInfo_ByPallettName(strBoxName)
                If dtPallettInfo.Rows.Count = 0 Then
                    MessageBox.Show("Box does not exist in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                If dtPallettInfo.Rows(0)("Cust_ID") = 2266 Then
                    strManifestDir = Me._objDC.VeoliaTrans_MANIFEST_DIR
                ElseIf dtPallettInfo.Rows(0)("Cust_ID") = 2279 Then
                    strManifestDir = "P:\Dept\Greater Houston Transportation\Pallet Packing List\"
                Else
                    strManifestDir = Me._objDC.MANIFEST_DIR
                End If

                If File.Exists(strManifestDir & strBoxName & ".xls") = False Then
                    Throw New Exception("Report does not exist '" & PSS.Data.Buisness.DriveCam.MANIFEST_DIR & strBoxName & ".xls" & "'.")
                Else
                    Me._objBulkShip.PrintExcelFile(strManifestDir & strBoxName & ".xls")
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Reprint Box Manifest", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                PSS.Data.Buisness.Generic.DisposeDT(dtPallettInfo)
                objMisc = Nothing
            End Try
        End Sub

        '*****************************************************************
        Private Sub btnRecreateReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecreateReport.Click
            Dim strBoxName, strManifestDir As String
            Dim dtPallettInfo As DataTable
            Dim objMisc As PSS.Data.Buisness.Misc

            Try
                strBoxName = "" : strManifestDir = ""
                strBoxName = InputBox("Enter Box Name.", "Re-create Manifest Report")
                If strBoxName = "" Then
                    Throw New Exception("Please enter a Box Name if you want to re-create manifest report.")
                End If

                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor
                objMisc = New PSS.Data.Buisness.Misc()

                dtPallettInfo = objMisc.GetPalletInfo_ByPallettName(strBoxName)
                If dtPallettInfo.Rows.Count = 0 Then
                    MessageBox.Show("Box Name was not defined in system.", "Reprint Box Label", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Exit Sub
                ElseIf dtPallettInfo.Rows.Count > 1 Then
                    MessageBox.Show("Box Name existed twice in the system.", "Reprint Box Label", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Exit Sub
                ElseIf dtPallettInfo.Rows(0)("Pallett_ReadyToShipFlg") = 0 Then
                    MessageBox.Show("Box is still open.", "Information", MessageBoxButtons.OK)
                    Exit Sub
                ElseIf Not IsDBNull(dtPallettInfo.Rows(0)("Pallet_Invalid")) AndAlso dtPallettInfo.Rows(0)("Pallet_Invalid") > 0 Then
                    MessageBox.Show("Box has been deleted.", "Information", MessageBoxButtons.OK)
                    Exit Sub
                Else
                    If dtPallettInfo.Rows(0)("Cust_ID") = 2266 Then
                        strManifestDir = Me._objDC.VeoliaTrans_MANIFEST_DIR
                    ElseIf dtPallettInfo.Rows(0)("Cust_ID") = 2279 Then
                        strManifestDir = "P:\Dept\Greater Houston Transportation\Pallet Packing List\"
                    Else
                        strManifestDir = Me._objDC.MANIFEST_DIR
                    End If
                    objMisc.CreateDriveCamExcelFile(dtPallettInfo.Rows(0)("Pallett_ID"), dtPallettInfo.Rows(0)("Pallett_Name"), strManifestDir)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRecreateReport_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                PSS.Data.Buisness.Generic.DisposeDT(dtPallettInfo)
                objMisc = Nothing
            End Try
        End Sub

        '******************************************************************

    End Class
End Namespace