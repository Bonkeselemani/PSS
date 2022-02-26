Imports System

Namespace Gui.Search

    Public Class CellSearchWin
        Inherits System.Windows.Forms.Form

        Private strSQL As String


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
        Friend WithEvents gridData As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents grpOptions As System.Windows.Forms.GroupBox
        Friend WithEvents rbALL As System.Windows.Forms.RadioButton
        Friend WithEvents rbWIP As System.Windows.Forms.RadioButton
        Friend WithEvents txtDate As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents btnQuery As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CellSearchWin))
            Dim GridLines1 As C1.Win.C1TrueDBGrid.Util.GridLines = New C1.Win.C1TrueDBGrid.Util.GridLines()
            Me.gridData = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.grpOptions = New System.Windows.Forms.GroupBox()
            Me.rbWIP = New System.Windows.Forms.RadioButton()
            Me.rbALL = New System.Windows.Forms.RadioButton()
            Me.txtDate = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.btnQuery = New System.Windows.Forms.Button()
            CType(Me.gridData, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grpOptions.SuspendLayout()
            Me.SuspendLayout()
            '
            'gridData
            '
            Me.gridData.AllowFilter = True
            Me.gridData.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows
            Me.gridData.AllowSort = True
            Me.gridData.AlternatingRows = True
            Me.gridData.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.gridData.CaptionHeight = 17
            Me.gridData.CollapseColor = System.Drawing.Color.Black
            Me.gridData.DataChanged = False
            Me.gridData.BackColor = System.Drawing.Color.Empty
            Me.gridData.ExpandColor = System.Drawing.Color.Black
            Me.gridData.FilterBar = True
            Me.gridData.GroupByCaption = "Drag a column header here to group by that column"
            Me.gridData.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.gridData.Location = New System.Drawing.Point(16, 72)
            Me.gridData.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
            Me.gridData.Name = "gridData"
            Me.gridData.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.gridData.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.gridData.PreviewInfo.ZoomFactor = 75
            Me.gridData.PrintInfo.ShowOptionsDialog = False
            Me.gridData.RecordSelectorWidth = 16
            GridLines1.Color = System.Drawing.Color.DarkGray
            GridLines1.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single
            Me.gridData.RowDivider = GridLines1
            Me.gridData.RowHeight = 15
            Me.gridData.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.gridData.ScrollTips = False
            Me.gridData.Size = New System.Drawing.Size(728, 312)
            Me.gridData.TabIndex = 17
            Me.gridData.Text = "C1TrueDBGrid1"
            Me.gridData.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Style11{}Style12{}Style13{}Style5{}Style4{}Style7{}Style6{}EvenRow{Back" & _
            "Color:Aqua;}Selected{ForeColor:HighlightText;BackColor:Highlight;}Heading{Wrap:T" & _
            "rue;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:C" & _
            "ontrol;}Inactive{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}Filter" & _
            "Bar{}OddRow{}Footer{}Caption{AlignHorz:Center;}Normal{}Style10{AlignHorz:Near;}H" & _
            "ighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Editor{}RecordSelector{" & _
            "AlignImage:Center;}Style9{}Style8{}Style3{}Style2{}Group{BackColor:ControlDark;B" & _
            "order:None,,0, 0, 0, 0;AlignVert:Center;}Style1{}</Data></Styles><Splits><C1.Win" & _
            ".C1TrueDBGrid.MergeView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" Co" & _
            "lumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""Do" & _
            "ttedCellBorder"" RecordSelectorWidth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup" & _
            "=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 724, 308</ClientRect><BorderSid" & _
            "e>0</BorderSide><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent" & _
            "=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarS" & _
            "tyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" " & _
            "/><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""S" & _
            "tyle2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle p" & _
            "arent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><Recor" & _
            "dSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Sel" & _
            "ected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1TrueDBGrid." & _
            "MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""No" & _
            "rmal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Headin" & _
            "g"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal""" & _
            " me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=" & _
            """HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me" & _
            "=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal""" & _
            " me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits" & _
            ">1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><DefaultRecSel" & _
            "Width>16</DefaultRecSelWidth><ClientArea>0, 0, 724, 308</ClientArea></Blob>"
            '
            'grpOptions
            '
            Me.grpOptions.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.grpOptions.Controls.AddRange(New System.Windows.Forms.Control() {Me.rbWIP, Me.rbALL})
            Me.grpOptions.Location = New System.Drawing.Point(584, 8)
            Me.grpOptions.Name = "grpOptions"
            Me.grpOptions.Size = New System.Drawing.Size(160, 56)
            Me.grpOptions.TabIndex = 18
            Me.grpOptions.TabStop = False
            Me.grpOptions.Text = "Filter"
            '
            'rbWIP
            '
            Me.rbWIP.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.rbWIP.Enabled = False
            Me.rbWIP.Location = New System.Drawing.Point(96, 24)
            Me.rbWIP.Name = "rbWIP"
            Me.rbWIP.Size = New System.Drawing.Size(56, 24)
            Me.rbWIP.TabIndex = 1
            Me.rbWIP.Text = "WIP"
            '
            'rbALL
            '
            Me.rbALL.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.rbALL.Location = New System.Drawing.Point(32, 24)
            Me.rbALL.Name = "rbALL"
            Me.rbALL.Size = New System.Drawing.Size(56, 24)
            Me.rbALL.TabIndex = 0
            Me.rbALL.Text = "All"
            '
            'txtDate
            '
            Me.txtDate.Location = New System.Drawing.Point(64, 36)
            Me.txtDate.Name = "txtDate"
            Me.txtDate.TabIndex = 19
            Me.txtDate.Text = ""
            '
            'Label1
            '
            Me.Label1.Location = New System.Drawing.Point(24, 40)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(40, 16)
            Me.Label1.TabIndex = 20
            Me.Label1.Text = "Date:"
            '
            'btnQuery
            '
            Me.btnQuery.Location = New System.Drawing.Point(168, 36)
            Me.btnQuery.Name = "btnQuery"
            Me.btnQuery.Size = New System.Drawing.Size(75, 20)
            Me.btnQuery.TabIndex = 21
            Me.btnQuery.Text = "Query"
            '
            'CellSearchWin
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(760, 397)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnQuery, Me.Label1, Me.txtDate, Me.grpOptions, Me.gridData})
            Me.Name = "CellSearchWin"
            Me.Text = "CellSearchWin"
            CType(Me.gridData, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grpOptions.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub CellSearchWin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            Me.gridData.Visible = False
            Me.grpOptions.Visible = False

            If Len(Trim(txtDate.Text)) < 1 Then txtDate.Text = "2005-01-01"

            rbALL.Checked = True

            Cursor.Current = System.Windows.Forms.Cursors.Default

        End Sub


        Private Sub clearGrid()

            Try
                gridData.DataSource = Nothing
            Catch ex As Exception
            End Try

        End Sub

        Private Sub populateGridALL()

            grpOptions.Focus()

            'Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            Me.gridData.Visible = False
            Me.grpOptions.Visible = False

            'clearGrid()


            'strSQL = "SELECT " & _
            '    "tdevice.device_sn as 'Serial Number', tdevice.device_oldsn as 'OLD Serial Number', tdevice.tray_id as 'Tray', tdevice.device_datebill as 'Date Billed', tdevice.device_dateship as 'Date Shipped', tlocation.loc_name as 'Location', " & _
            '    "tdevice.wo_id as 'Workorder', tdevice.ship_id As 'Ship ID', tdevice.Pallett_ID as 'Pallett ID', tmodel.model_desc as 'Model', tsku.sku_number as 'SKU', tcellopt.cellopt_fname as 'Name', " & _
            '    "lcodesdetail.dcode_sdesc as 'APC', cellopt_datecode as 'Date Code', cellopt_courier as 'Courier', cellopt_transceiver as 'Transceiver', cellopt_imei as 'IMEI', " & _
            '    "cellopt_outimei as 'IMEI(out)', cellopt_csn as 'CSN', cellopt_outcsn as 'CSN(out)', cellopt_csn_dec as 'CSN(decimal)', cellopt_MSN as 'MSN', " & _
            '    "cellopt_outmsn as 'MSN(out)', cellopt_softverin as 'Software IN', cellopt_softverout as 'Software OUT' " & _
            '    "FROM " & _
            '    "(((((tdevice INNER JOIN tcellopt ON tdevice.device_id = tcellopt.device_id) " & _
            '    "INNER JOIN tmodel ON tdevice.model_id = tmodel.model_id) " & _
            '    "LEFT OUTER JOIN tsku ON tdevice.sku_id = tsku.sku_ID) " & _
            '    "INNER JOIN lcodesdetail ON tcellopt.cellopt_APC = lcodesdetail.dcode_id) " & _
            '    "INNER JOIN tlocation ON tdevice.loc_id = tlocation.loc_id) " & _
            '    "ORDER BY tdevice.device_sn"

            strSQL = "SELECT " & _
                "tdevice.device_sn as 'Serial Number', tdevice.device_oldsn as 'OLD Serial Number', tdevice.tray_id as 'Tray', tdevice.device_datebill as 'Date Billed', tdevice.device_dateship as 'Date Shipped', tlocation.loc_name as 'Location', " & _
                "tdevice.wo_id as 'Workorder', tdevice.ship_id As 'Ship ID', tdevice.Pallett_ID as 'Pallett ID', tmodel.model_desc as 'Model', tsku.sku_number as 'SKU', tcellopt.cellopt_fname as 'Name', " & _
                "cellopt_datecode as 'Date Code', cellopt_courier as 'Courier', cellopt_transceiver as 'Transceiver', cellopt_imei as 'IMEI', " & _
                "cellopt_outimei as 'IMEI(out)', cellopt_csn as 'CSN', cellopt_outcsn as 'CSN(out)', cellopt_csn_dec as 'CSN(decimal)', cellopt_MSN as 'MSN', " & _
                "cellopt_outmsn as 'MSN(out)', cellopt_softverin as 'Software IN', cellopt_softverout as 'Software OUT' " & _
                "FROM " & _
                "((((tdevice INNER JOIN tcellopt ON tdevice.device_id = tcellopt.device_id) " & _
                "INNER JOIN tmodel ON tdevice.model_id = tmodel.model_id) " & _
                "LEFT OUTER JOIN tsku ON tdevice.sku_id = tsku.sku_ID) " & _
                "INNER JOIN tlocation ON tdevice.loc_id = tlocation.loc_id) " & _
                "WHERE tdevice.device_daterec > '" & txtDate.Text & " 00:00:00' " & _
                "ORDER BY tdevice.device_sn"


            Dim dtAll As DataTable = PSS.Data.Production.Joins.OrderEntrySelect(strSQL)
            gridData.DataSource = dtAll

            Me.gridData.Visible = True
            Me.grpOptions.Visible = True

            'Cursor.Current = System.Windows.Forms.Cursors.Default

        End Sub

        Private Sub populateGridWIP()

            grpOptions.Focus()

            'Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            Me.gridData.Visible = False
            Me.grpOptions.Visible = False

            'clearGrid()

            strSQL = "SELECT " & _
                "tdevice.device_sn as 'Serial Number', tdevice.device_oldsn as 'OLD Serial Number', tdevice.tray_id as 'Tray',tdevice.device_datebill as 'Date Billed', tdevice.device_dateship as 'Date Shipped', tlocation.loc_name as 'Location', " & _
                "tdevice.wo_id as 'Workorder', tdevice.ship_id As 'Ship ID', tmodel.model_desc as 'Model', tsku.sku_number as 'SKU', tcellopt.cellopt_fname as 'Name', " & _
                "lcodesdetail.dcode_sdesc as 'APC', cellopt_datecode as 'Date Code', cellopt_courier as 'Courier', cellopt_transceiver as 'Transceiver', cellopt_imei as 'IMEI', " & _
                "cellopt_outimei as 'IMEI(out)', cellopt_csn as 'CSN', cellopt_outcsn as 'CSN(out)', cellopt_csn_dec as 'CSN(decimal)', cellopt_MSN as 'MSN', " & _
                "cellopt_outmsn as 'MSN(out)', cellopt_softverin as 'Software IN', cellopt_softverout as 'Software OUT' " & _
                "FROM " & _
                "(((((tdevice INNER JOIN tcellopt ON tdevice.device_id = tcellopt.device_id) " & _
                "INNER JOIN tmodel ON tdevice.model_id = tmodel.model_id) " & _
                "LEFT OUTER JOIN tsku ON tdevice.sku_id = tsku.sku_ID) " & _
                "INNER JOIN lcodesdetail ON tcellopt.cellopt_APC = lcodesdetail.dcode_id) " & _
                "INNER JOIN tlocation ON tdevice.loc_id = tlocation.loc_id) " & _
                "WHERE " & _
                "tdevice.device_dateship is null " & _
                "ORDER BY tdevice.device_sn"

            Dim dtWIP As DataTable = PSS.Data.Production.Joins.OrderEntrySelect(strSQL)
            System.Windows.Forms.Application.DoEvents()


            System.Windows.Forms.Application.DoEvents()

            gridData.DataSource = dtWIP


            Me.gridData.Visible = True
            Me.grpOptions.Visible = True

            'Cursor.Current = System.Windows.Forms.Cursors.Default

        End Sub

        Private Sub rbALL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbALL.CheckedChanged

            If rbALL.Checked = True Then
                populateGridALL()
            Else
                populateGridWIP()
            End If

        End Sub

        Private Sub rbWIP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbWIP.CheckedChanged

            If rbWIP.Checked = True Then
                populateGridWIP()
            Else
                populateGridALL()
            End If

        End Sub

        Private Sub btnTechReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        End Sub

        Private Sub grpTechReport_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

        End Sub

        Private Sub btnQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuery.Click

            populateGridALL()

        End Sub

    End Class

End Namespace
