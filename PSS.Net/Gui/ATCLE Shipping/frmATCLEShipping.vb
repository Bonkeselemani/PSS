
Namespace ATCLEShipping
    Public Class frmATCLEShipping
        Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call

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

        Friend WithEvents lblCompany As System.Windows.Forms.Label
        Friend WithEvents lblAddress As System.Windows.Forms.Label
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents cboLocation As System.Windows.Forms.ComboBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents lblDate As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents lblCount As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents lblNoOfDevToShip As System.Windows.Forms.Label
        Friend WithEvents grdRMAInfo As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents txtDevice As System.Windows.Forms.TextBox
        Friend WithEvents lstDevices As System.Windows.Forms.ListBox
        Friend WithEvents Button1 As System.Windows.Forms.Button
        Friend WithEvents chkCloseOverPack As System.Windows.Forms.CheckBox
        Friend WithEvents btnRpt As System.Windows.Forms.Button
        Friend WithEvents btnReprint As System.Windows.Forms.Button
        Friend WithEvents btnPrint As System.Windows.Forms.Button
        Friend WithEvents btnClear As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmATCLEShipping))
            Dim GridLines1 As C1.Win.C1TrueDBGrid.Util.GridLines = New C1.Win.C1TrueDBGrid.Util.GridLines()
            Me.lblCompany = New System.Windows.Forms.Label()
            Me.lblAddress = New System.Windows.Forms.Label()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.cboLocation = New System.Windows.Forms.ComboBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.lblDate = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.lblCount = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.lblNoOfDevToShip = New System.Windows.Forms.Label()
            Me.grdRMAInfo = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.txtDevice = New System.Windows.Forms.TextBox()
            Me.lstDevices = New System.Windows.Forms.ListBox()
            Me.Button1 = New System.Windows.Forms.Button()
            Me.btnRpt = New System.Windows.Forms.Button()
            Me.btnReprint = New System.Windows.Forms.Button()
            Me.btnPrint = New System.Windows.Forms.Button()
            Me.chkCloseOverPack = New System.Windows.Forms.CheckBox()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.Panel1.SuspendLayout()
            CType(Me.grdRMAInfo, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblCompany
            '
            Me.lblCompany.Font = New System.Drawing.Font("Arial", 14.0!)
            Me.lblCompany.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblCompany.Location = New System.Drawing.Point(8, 12)
            Me.lblCompany.Name = "lblCompany"
            Me.lblCompany.Size = New System.Drawing.Size(427, 21)
            Me.lblCompany.TabIndex = 64
            Me.lblCompany.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblAddress
            '
            Me.lblAddress.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
            Me.lblAddress.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblAddress.Location = New System.Drawing.Point(8, 36)
            Me.lblAddress.Name = "lblAddress"
            Me.lblAddress.Size = New System.Drawing.Size(428, 48)
            Me.lblAddress.TabIndex = 65
            Me.lblAddress.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'Panel1
            '
            Me.Panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.Panel1.BackColor = System.Drawing.Color.Transparent
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboLocation, Me.Label5})
            Me.Panel1.Location = New System.Drawing.Point(464, 8)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(400, 34)
            Me.Panel1.TabIndex = 66
            '
            'cboLocation
            '
            Me.cboLocation.BackColor = System.Drawing.Color.Khaki
            Me.cboLocation.Font = New System.Drawing.Font("Verdana", 8.25!)
            Me.cboLocation.Location = New System.Drawing.Point(79, 4)
            Me.cboLocation.Name = "cboLocation"
            Me.cboLocation.Size = New System.Drawing.Size(307, 21)
            Me.cboLocation.TabIndex = 53
            '
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.Transparent
            Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label5.Location = New System.Drawing.Point(8, 8)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(72, 16)
            Me.Label5.TabIndex = 52
            Me.Label5.Text = "Location:"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label1
            '
            Me.Label1.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
            Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label1.Location = New System.Drawing.Point(544, 68)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(46, 16)
            Me.Label1.TabIndex = 67
            Me.Label1.Text = "Date: "
            '
            'lblDate
            '
            Me.lblDate.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.lblDate.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
            Me.lblDate.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblDate.Location = New System.Drawing.Point(584, 68)
            Me.lblDate.Name = "lblDate"
            Me.lblDate.Size = New System.Drawing.Size(184, 16)
            Me.lblDate.TabIndex = 68
            '
            'Label2
            '
            Me.Label2.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
            Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label2.Location = New System.Drawing.Point(702, 105)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(96, 16)
            Me.Label2.TabIndex = 69
            Me.Label2.Text = "Count"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblCount
            '
            Me.lblCount.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.lblCount.BackColor = System.Drawing.Color.Transparent
            Me.lblCount.Font = New System.Drawing.Font("Verdana", 30.0!)
            Me.lblCount.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblCount.Location = New System.Drawing.Point(712, 121)
            Me.lblCount.Name = "lblCount"
            Me.lblCount.Size = New System.Drawing.Size(80, 47)
            Me.lblCount.TabIndex = 70
            Me.lblCount.Text = "0"
            Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label3
            '
            Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
            Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label3.Location = New System.Drawing.Point(49, 156)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(459, 16)
            Me.Label3.TabIndex = 71
            Me.Label3.Text = "No. of devices billed and yet to be shipped for the selected SKU:"
            '
            'lblNoOfDevToShip
            '
            Me.lblNoOfDevToShip.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold)
            Me.lblNoOfDevToShip.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblNoOfDevToShip.Location = New System.Drawing.Point(475, 155)
            Me.lblNoOfDevToShip.Name = "lblNoOfDevToShip"
            Me.lblNoOfDevToShip.Size = New System.Drawing.Size(72, 16)
            Me.lblNoOfDevToShip.TabIndex = 72
            '
            'grdRMAInfo
            '
            Me.grdRMAInfo.AllowColMove = False
            Me.grdRMAInfo.AllowFilter = True
            Me.grdRMAInfo.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows
            Me.grdRMAInfo.AllowSort = True
            Me.grdRMAInfo.AllowUpdate = False
            Me.grdRMAInfo.AllowUpdateOnBlur = False
            Me.grdRMAInfo.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.grdRMAInfo.BackColor = System.Drawing.Color.Khaki
            Me.grdRMAInfo.CaptionHeight = 18
            Me.grdRMAInfo.CollapseColor = System.Drawing.Color.Black
            Me.grdRMAInfo.DataChanged = False
            Me.grdRMAInfo.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.grdRMAInfo.ExpandColor = System.Drawing.Color.Black
            Me.grdRMAInfo.GroupByCaption = "Drag a column header here to group by that column"
            Me.grdRMAInfo.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.grdRMAInfo.Location = New System.Drawing.Point(50, 178)
            Me.grdRMAInfo.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
            Me.grdRMAInfo.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.grdRMAInfo.Name = "grdRMAInfo"
            Me.grdRMAInfo.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.grdRMAInfo.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.grdRMAInfo.PreviewInfo.ZoomFactor = 75
            Me.grdRMAInfo.PrintInfo.ShowOptionsDialog = False
            Me.grdRMAInfo.RecordSelectorWidth = 16
            GridLines1.Color = System.Drawing.Color.DarkGray
            GridLines1.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single
            Me.grdRMAInfo.RowDivider = GridLines1
            Me.grdRMAInfo.RowHeight = 15
            Me.grdRMAInfo.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.grdRMAInfo.ScrollTips = False
            Me.grdRMAInfo.Size = New System.Drawing.Size(612, 244)
            Me.grdRMAInfo.TabIndex = 73
            Me.grdRMAInfo.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Normal{Font:Verdana, 8.25pt;BackColor:Khaki;}HighlightRow{ForeColor:Highligh" & _
            "tText;BackColor:Highlight;}Style1{}OddRow{}RecordSelector{AlignImage:Center;}Hea" & _
            "ding{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;" & _
            "BackColor:Control;}Style8{}Style10{AlignHorz:Near;}Style11{}Style12{}Style13{}St" & _
            "yle9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False" & _
            """ Name="""" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" Ma" & _
            "rqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefRecSelWidth=""16"" Verti" & _
            "calScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 608, 240</ClientR" & _
            "ect><BorderSide>0</BorderSide><CaptionStyle parent=""Style2"" me=""Style10"" /><Edit" & _
            "orStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8""" & _
            " /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer" & _
            """ me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""" & _
            "Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><I" & _
            "nactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""St" & _
            "yle9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedSty" & _
            "le parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win" & _
            ".C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><St" & _
            "yle parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style " & _
            "parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style p" & _
            "arent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style paren" & _
            "t=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style pare" & _
            "nt=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style p" & _
            "arent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyl" & _
            "es><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Def" & _
            "aultRecSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 608, 240</ClientArea></" & _
            "Blob>"
            '
            'txtDevice
            '
            Me.txtDevice.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.txtDevice.BackColor = System.Drawing.Color.Khaki
            Me.txtDevice.Font = New System.Drawing.Font("Verdana", 8.25!)
            Me.txtDevice.Location = New System.Drawing.Point(672, 177)
            Me.txtDevice.Name = "txtDevice"
            Me.txtDevice.Size = New System.Drawing.Size(157, 21)
            Me.txtDevice.TabIndex = 74
            Me.txtDevice.Text = ""
            '
            'lstDevices
            '
            Me.lstDevices.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.lstDevices.BackColor = System.Drawing.Color.Khaki
            Me.lstDevices.Font = New System.Drawing.Font("Verdana", 8.25!)
            Me.lstDevices.Location = New System.Drawing.Point(672, 199)
            Me.lstDevices.Name = "lstDevices"
            Me.lstDevices.Size = New System.Drawing.Size(157, 225)
            Me.lstDevices.TabIndex = 75
            '
            'Button1
            '
            Me.Button1.Location = New System.Drawing.Point(16, 434)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(56, 40)
            Me.Button1.TabIndex = 76
            Me.Button1.Text = "Button1"
            Me.Button1.Visible = False
            '
            'btnRpt
            '
            Me.btnRpt.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnRpt.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold)
            Me.btnRpt.Location = New System.Drawing.Point(318, 462)
            Me.btnRpt.Name = "btnRpt"
            Me.btnRpt.Size = New System.Drawing.Size(240, 32)
            Me.btnRpt.TabIndex = 77
            Me.btnRpt.Text = "Show Devices to be Shipped"
            '
            'btnReprint
            '
            Me.btnReprint.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnReprint.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold)
            Me.btnReprint.Location = New System.Drawing.Point(567, 462)
            Me.btnReprint.Name = "btnReprint"
            Me.btnReprint.Size = New System.Drawing.Size(96, 32)
            Me.btnReprint.TabIndex = 78
            Me.btnReprint.Text = "Reprint"
            '
            'btnPrint
            '
            Me.btnPrint.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold)
            Me.btnPrint.Location = New System.Drawing.Point(672, 462)
            Me.btnPrint.Name = "btnPrint"
            Me.btnPrint.Size = New System.Drawing.Size(157, 32)
            Me.btnPrint.TabIndex = 79
            Me.btnPrint.Text = "Print"
            '
            'chkCloseOverPack
            '
            Me.chkCloseOverPack.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.chkCloseOverPack.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
            Me.chkCloseOverPack.ForeColor = System.Drawing.SystemColors.ControlText
            Me.chkCloseOverPack.Location = New System.Drawing.Point(672, 430)
            Me.chkCloseOverPack.Name = "chkCloseOverPack"
            Me.chkCloseOverPack.Size = New System.Drawing.Size(168, 24)
            Me.chkCloseOverPack.TabIndex = 81
            Me.chkCloseOverPack.Text = "Force Close Overpack"
            '
            'btnClear
            '
            Me.btnClear.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnClear.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold)
            Me.btnClear.Location = New System.Drawing.Point(840, 222)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(24, 168)
            Me.btnClear.TabIndex = 82
            Me.btnClear.Text = "CLEAR"
            '
            'frmATCLEShipping
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.DarkKhaki
            Me.ClientSize = New System.Drawing.Size(880, 501)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnClear, Me.chkCloseOverPack, Me.btnPrint, Me.btnReprint, Me.btnRpt, Me.Button1, Me.lstDevices, Me.txtDevice, Me.grdRMAInfo, Me.lblNoOfDevToShip, Me.Label3, Me.lblCount, Me.Label2, Me.lblDate, Me.Label1, Me.Panel1, Me.lblAddress, Me.lblCompany})
            Me.Name = "frmATCLEShipping"
            Me.Text = "frmATCLEShipping"
            Me.Panel1.ResumeLayout(False)
            CType(Me.grdRMAInfo, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

    End Class
End Namespace