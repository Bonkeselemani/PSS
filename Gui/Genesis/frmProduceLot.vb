Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.Genesis
    Public Class frmProduceLot
        Inherits System.Windows.Forms.Form

        Private _objShip As PSS.Data.Buisness.Genesis.Shipping
        Private _objBulkShip As BulkShipping
        Private _booPopDataToCombo As Boolean = False
        Private _iFileCheckDone As Integer = 0

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _objShip = New PSS.Data.Buisness.Genesis.Shipping()
            _objBulkShip = New BulkShipping()
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
        Friend WithEvents lstRegular As System.Windows.Forms.ListBox
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents lstWrongModel As System.Windows.Forms.ListBox
        Friend WithEvents btnShip As System.Windows.Forms.Button
        Friend WithEvents lstDetail As System.Windows.Forms.ListBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents btnFileCheck As System.Windows.Forms.Button
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents dbgPallets As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents lblScreenName As System.Windows.Forms.Label
        Friend WithEvents lstWrongOrder As System.Windows.Forms.ListBox
        Friend WithEvents btnSelectLot As System.Windows.Forms.Button
        Friend WithEvents lblPalletQty As System.Windows.Forms.Label
        Friend WithEvents lblPalletName As System.Windows.Forms.Label
        Friend WithEvents PanelLists As System.Windows.Forms.Panel
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmProduceLot))
            Me.PanelLists = New System.Windows.Forms.Panel()
            Me.lstRegular = New System.Windows.Forms.ListBox()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.lstWrongModel = New System.Windows.Forms.ListBox()
            Me.btnShip = New System.Windows.Forms.Button()
            Me.lstDetail = New System.Windows.Forms.ListBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.lstWrongOrder = New System.Windows.Forms.ListBox()
            Me.btnFileCheck = New System.Windows.Forms.Button()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.dbgPallets = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.lblPalletQty = New System.Windows.Forms.Label()
            Me.lblPalletName = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.lblScreenName = New System.Windows.Forms.Label()
            Me.btnSelectLot = New System.Windows.Forms.Button()
            Me.PanelLists.SuspendLayout()
            CType(Me.dbgPallets, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'PanelLists
            '
            Me.PanelLists.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.PanelLists.Controls.AddRange(New System.Windows.Forms.Control() {Me.lstRegular, Me.Label9, Me.lstWrongModel, Me.btnShip, Me.lstDetail, Me.Label2, Me.Label12, Me.btnClear, Me.lstWrongOrder, Me.btnFileCheck, Me.Label11})
            Me.PanelLists.Location = New System.Drawing.Point(2, 272)
            Me.PanelLists.Name = "PanelLists"
            Me.PanelLists.Size = New System.Drawing.Size(830, 320)
            Me.PanelLists.TabIndex = 84
            Me.PanelLists.Visible = False
            '
            'lstRegular
            '
            Me.lstRegular.Location = New System.Drawing.Point(8, 32)
            Me.lstRegular.Name = "lstRegular"
            Me.lstRegular.Size = New System.Drawing.Size(160, 238)
            Me.lstRegular.TabIndex = 1
            '
            'Label9
            '
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.Gold
            Me.Label9.Location = New System.Drawing.Point(536, 16)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(130, 16)
            Me.Label9.TabIndex = 60
            Me.Label9.Text = "DETAIL:"
            '
            'lstWrongModel
            '
            Me.lstWrongModel.Location = New System.Drawing.Point(360, 32)
            Me.lstWrongModel.Name = "lstWrongModel"
            Me.lstWrongModel.Size = New System.Drawing.Size(160, 238)
            Me.lstWrongModel.TabIndex = 4
            '
            'btnShip
            '
            Me.btnShip.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnShip.Enabled = False
            Me.btnShip.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnShip.ForeColor = System.Drawing.Color.Blue
            Me.btnShip.Location = New System.Drawing.Point(600, 280)
            Me.btnShip.Name = "btnShip"
            Me.btnShip.Size = New System.Drawing.Size(200, 32)
            Me.btnShip.TabIndex = 9
            Me.btnShip.Text = "PRODUCE"
            '
            'lstDetail
            '
            Me.lstDetail.BackColor = System.Drawing.Color.PaleGoldenrod
            Me.lstDetail.Location = New System.Drawing.Point(536, 32)
            Me.lstDetail.Name = "lstDetail"
            Me.lstDetail.Size = New System.Drawing.Size(160, 238)
            Me.lstDetail.TabIndex = 5
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(8, 16)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(116, 18)
            Me.Label2.TabIndex = 4
            Me.Label2.Text = "Regular Units:"
            '
            'Label12
            '
            Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label12.ForeColor = System.Drawing.Color.White
            Me.Label12.Location = New System.Drawing.Point(184, 0)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(120, 32)
            Me.Label12.TabIndex = 55
            Me.Label12.Text = "Wrong Order:"
            Me.Label12.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'btnClear
            '
            Me.btnClear.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClear.ForeColor = System.Drawing.Color.Black
            Me.btnClear.Location = New System.Drawing.Point(464, 280)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(120, 32)
            Me.btnClear.TabIndex = 7
            Me.btnClear.Text = "Clear"
            '
            'lstWrongOrder
            '
            Me.lstWrongOrder.Location = New System.Drawing.Point(184, 32)
            Me.lstWrongOrder.Name = "lstWrongOrder"
            Me.lstWrongOrder.Size = New System.Drawing.Size(160, 238)
            Me.lstWrongOrder.TabIndex = 3
            '
            'btnFileCheck
            '
            Me.btnFileCheck.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnFileCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnFileCheck.ForeColor = System.Drawing.Color.Black
            Me.btnFileCheck.Location = New System.Drawing.Point(8, 280)
            Me.btnFileCheck.Name = "btnFileCheck"
            Me.btnFileCheck.Size = New System.Drawing.Size(440, 32)
            Me.btnFileCheck.TabIndex = 6
            Me.btnFileCheck.Text = "LOT CHECK (DO I HAVE THE RIGHT LOT AND RIGHT SNs?)"
            '
            'Label11
            '
            Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label11.ForeColor = System.Drawing.Color.White
            Me.Label11.Location = New System.Drawing.Point(360, 16)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(113, 21)
            Me.Label11.TabIndex = 53
            Me.Label11.Text = "Wrong Model:"
            '
            'dbgPallets
            '
            Me.dbgPallets.AllowColMove = False
            Me.dbgPallets.AllowColSelect = False
            Me.dbgPallets.AllowFilter = False
            Me.dbgPallets.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
            Me.dbgPallets.AllowUpdate = False
            Me.dbgPallets.AllowUpdateOnBlur = False
            Me.dbgPallets.AlternatingRows = True
            Me.dbgPallets.Caption = "Lots to be Produce"
            Me.dbgPallets.CaptionHeight = 17
            Me.dbgPallets.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dbgPallets.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgPallets.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dbgPallets.Location = New System.Drawing.Point(2, 55)
            Me.dbgPallets.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.dbgPallets.Name = "dbgPallets"
            Me.dbgPallets.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgPallets.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgPallets.PreviewInfo.ZoomFactor = 75
            Me.dbgPallets.RowHeight = 20
            Me.dbgPallets.Size = New System.Drawing.Size(830, 217)
            Me.dbgPallets.TabIndex = 85
            Me.dbgPallets.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{Font:Tahoma, 8" & _
            ".25pt, style=Bold;AlignHorz:Center;ForeColor:Green;BackColor:LightSteelBlue;}Sty" & _
            "le9{}Normal{Font:Microsoft Sans Serif, 8.25pt;BackColor:LightSteelBlue;AlignVert" & _
            ":Center;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddR" & _
            "ow{BackColor:LightSteelBlue;}RecordSelector{AlignImage:Center;}Style13{}Heading{" & _
            "Wrap:True;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;BackCol" & _
            "or:SteelBlue;Border:Raised,,1, 1, 1, 1;ForeColor:White;AlignVert:Center;}Style8{" & _
            "}Style10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style1{}</Data></Styles><Spl" & _
            "its><C1.Win.C1TrueDBGrid.MergeView HBarHeight=""24"" AllowColMove=""False"" AllowCol" & _
            "Select=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""True"" CaptionH" & _
            "eight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""Dotted" & _
            "CellBorder"" RecordSelectorWidth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1""" & _
            " HorizontalScrollGroup=""1""><Height>196</Height><CaptionStyle parent=""Style2"" me=" & _
            """Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""Eve" & _
            "nRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterSty" & _
            "le parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><Head" & _
            "ingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow""" & _
            " me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle paren" & _
            "t=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style1" & _
            "1"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""S" & _
            "tyle1"" /><ClientRect>0, 17, 826, 196</ClientRect><BorderSide>0</BorderSide><Bord" & _
            "erStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyle" & _
            "s><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style pa" & _
            "rent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style paren" & _
            "t=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent" & _
            "=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent" & _
            "=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Hea" & _
            "ding"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style paren" & _
            "t=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</" & _
            "horzSplits><Layout>None</Layout><DefaultRecSelWidth>16</DefaultRecSelWidth><Clie" & _
            "ntArea>0, 0, 826, 213</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /" & _
            "><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'lblPalletQty
            '
            Me.lblPalletQty.BackColor = System.Drawing.Color.Black
            Me.lblPalletQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblPalletQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPalletQty.ForeColor = System.Drawing.Color.Lime
            Me.lblPalletQty.Location = New System.Drawing.Point(832, 18)
            Me.lblPalletQty.Name = "lblPalletQty"
            Me.lblPalletQty.Size = New System.Drawing.Size(104, 36)
            Me.lblPalletQty.TabIndex = 88
            Me.lblPalletQty.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'lblPalletName
            '
            Me.lblPalletName.BackColor = System.Drawing.Color.Black
            Me.lblPalletName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblPalletName.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPalletName.ForeColor = System.Drawing.Color.Lime
            Me.lblPalletName.Location = New System.Drawing.Point(416, 1)
            Me.lblPalletName.Name = "lblPalletName"
            Me.lblPalletName.Size = New System.Drawing.Size(416, 53)
            Me.lblPalletName.TabIndex = 90
            Me.lblPalletName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Black
            Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Lime
            Me.Label1.Location = New System.Drawing.Point(832, 2)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(104, 18)
            Me.Label1.TabIndex = 89
            Me.Label1.Text = "COUNT"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'lblScreenName
            '
            Me.lblScreenName.BackColor = System.Drawing.Color.Black
            Me.lblScreenName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblScreenName.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblScreenName.ForeColor = System.Drawing.Color.Yellow
            Me.lblScreenName.Location = New System.Drawing.Point(2, 1)
            Me.lblScreenName.Name = "lblScreenName"
            Me.lblScreenName.Size = New System.Drawing.Size(414, 53)
            Me.lblScreenName.TabIndex = 87
            Me.lblScreenName.Text = "GENESIS PRODUCE LOTS"
            Me.lblScreenName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnSelectLot
            '
            Me.btnSelectLot.BackColor = System.Drawing.Color.Green
            Me.btnSelectLot.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSelectLot.ForeColor = System.Drawing.Color.White
            Me.btnSelectLot.Location = New System.Drawing.Point(848, 72)
            Me.btnSelectLot.Name = "btnSelectLot"
            Me.btnSelectLot.Size = New System.Drawing.Size(88, 80)
            Me.btnSelectLot.TabIndex = 4
            Me.btnSelectLot.Text = "SELECT LOT TO BE PRODUCE"
            '
            'frmProduceLot
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(944, 613)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.PanelLists, Me.dbgPallets, Me.lblPalletQty, Me.lblPalletName, Me.Label1, Me.lblScreenName, Me.btnSelectLot})
            Me.Name = "frmProduceLot"
            Me.Text = "frmProduceLot"
            Me.PanelLists.ResumeLayout(False)
            CType(Me.dbgPallets, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '********************************************************************************************************
        Private Sub frmProduceLot_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                PSS.Core.Highlight.SetHighLight(Me)

                '*********************************
                'Load Open Order & Box Type
                '*********************************
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                Me.LoadOpenLots()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "FormLoad", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                Me._booPopDataToCombo = False
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub LoadOpenLots()
            Dim dt As DataTable
            Dim i As Integer = 0

            Try
                Me._booPopDataToCombo = True : ClearLotSelection()

                dt = Me._objShip.GetOpenToProducePallets(SharedFunctions.intGenesisLocID)
                With Me.dbgPallets
                    .DataSource = dt.DefaultView
                    For i = 0 To dt.Columns.Count - 1
                        .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        .Splits(0).DisplayColumns(i).Visible = False
                    Next i

                    .Splits(0).DisplayColumns("Order #").Visible = True
                    .Splits(0).DisplayColumns("Lot Name").Visible = True
                    .Splits(0).DisplayColumns("Model").Visible = True
                    .Splits(0).DisplayColumns("Quantity").Visible = True

                    .Splits(0).DisplayColumns("Order #").Width = 70
                    .Splits(0).DisplayColumns("Lot Name").Width = 150
                    .Splits(0).DisplayColumns("Model").Width = 200
                    .Splits(0).DisplayColumns("Quantity").Width = 55
                End With
                _booPopDataToCombo = False

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmRec_Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                _booPopDataToCombo = False
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub ClearLotSelection()
            Dim dt1 As DataTable

            Try
                Me._iFileCheckDone = 0
                If Not IsNothing(Me.dbgPallets.DataSource) Then dt1 = Me.dbgPallets.DataSource.Table
                Me.dbgPallets.DataSource = Nothing : Me.lstRegular.DataSource = Nothing
                ClearPanelLists()
                Me._objBulkShip.iLoc_ID = 0
                Me._objBulkShip.iBulkShipped = 0
                Me._objBulkShip.iShipType = 0
                Me._objBulkShip.iPallet_ID = 0
                Me._objBulkShip.iCust_ID = 0
                Generic.DisposeDT(Me._objBulkShip.dtWO)
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt1)
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub ClearPanelLists()
            Dim dt1 As DataTable

            Try
                If Not IsNothing(Me.lstRegular.DataSource) Then dt1 = Me.lstRegular.DataSource.Table
                Me.lstWrongOrder.Items.Clear() : Me.lstWrongOrder.Refresh()
                Me.lstWrongModel.Items.Clear() : Me.lstWrongModel.Refresh()
                Me.lstDetail.Items.Clear() : Me.lstDetail.Refresh()
                Me.lblPalletName.Text = "" : Me.lblPalletQty.Text = ""
                Me.PanelLists.Visible = False
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt1)
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub btnSelectLot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectLot.Click
            Dim drPalletInfo, drException As DataRow()
            Dim strPalletName As String
            Dim dcColNew As DataColumn
            Dim i As Integer = 0

            Try
                Me.ClearPanelLists()

                If Me.dbgPallets.RowCount = 0 Or Me.dbgPallets.Columns.Count = 0 Then Exit Sub

                strPalletName = InputBox("Enter Lot Name:", "Select Lot").Trim

                If strPalletName.Trim.Length = 0 Then
                    Exit Sub
                ElseIf Me.dbgPallets.DataSource.Table.Select("[Lot Name] = '" & strPalletName & "'").length = 0 Then
                    MessageBox.Show("Lot name is not listed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    drPalletInfo = Me.dbgPallets.DataSource.Table.Select("[Lot Name] = '" & strPalletName & "'")
                    If drPalletInfo.Length > 1 Then
                        MessageBox.Show("More than one lot name is listed. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        '************************************************
                        'Step 1 :: Extract SN numbers from the excel file
                        '************************************************
                        Generic.DisposeDT(Me._objBulkShip.dtExcelSNs)
                        Me._objBulkShip.dtExcelSNs = Me._objShip.ExtractSNs(drPalletInfo(0)("pallett_id"))
                        If Me._objBulkShip.dtExcelSNs.Rows.Count <> drPalletInfo(0)("Quantity") Then
                            MessageBox.Show("Lot quantity does not match system count.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            '*******************************************************
                            '(A) Model Validation
                            '*******************************************************
                            drException = Me._objBulkShip.dtExcelSNs.Select("Model_ID <> " & drPalletInfo(0)("Model_ID"))
                            For i = 0 To drException.Length - 1
                                Me.lstWrongModel.Items.Add(drException(i)("Device_SN"))
                            Next i

                            '*******************************************************
                            '(B) WO Validation
                            '*******************************************************
                            drException = Me._objBulkShip.dtExcelSNs.Select("WO_ID <> " & drPalletInfo(0)("WO_ID"))
                            For i = 0 To drException.Length - 1
                                Me.lstWrongModel.Items.Add(drException(i)("Device_SN"))
                            Next i

                            Me.lstRegular.DataSource = Me._objBulkShip.dtExcelSNs.DefaultView
                            Me.lstRegular.ValueMember = Me._objBulkShip.dtExcelSNs.Columns("Device_ID").ToString
                            Me.lstRegular.DisplayMember = Me._objBulkShip.dtExcelSNs.Columns("Device_SN").ToString
                            '#############################################################
                            Me.PanelLists.Visible = True
                            Me.lblPalletName.Text = strPalletName
                            Me.lblPalletQty.Text = Me._objBulkShip.dtExcelSNs.Rows.Count
                            _iFileCheckDone = 0

                            If Me.lstWrongOrder.Items.Count = 0 AndAlso Me.lstWrongModel.Items.Count = 0 AndAlso Me.lstDetail.Items.Count = 0 Then
                                '***********************************************
                                'objBulkShip variables
                                Me._objBulkShip.iLoc_ID = drPalletInfo(0)("Loc_ID")
                                Me._objBulkShip.iBulkShipped = 1
                                Me._objBulkShip.iShipType = drPalletInfo(0)("Pallet_ShipType")
                                'Me._objBulkShip.strFilePath = strFilePath
                                Me._objBulkShip.iPallet_ID = drPalletInfo(0)("pallett_id")
                                'Me._objBulkShip.iGroup_ID = Me._drPalletInfo("group_id")
                                Me._objBulkShip.strWorkDt = Generic.GetWorkDate(PSS.Core.ApplicationUser.IDShift)
                                Me._objBulkShip.iShiftID = PSS.Core.ApplicationUser.IDShift
                                Me._objBulkShip.struser = PSS.Core.ApplicationUser.User
                                Me._objBulkShip.iCust_ID = drPalletInfo(0)("Cust_ID")

                                '***********************************************
                                'Add WO_ID column to dtWO datatable
                                '***********************************************
                                Generic.DisposeDT(Me._objBulkShip.dtWO)
                                Me._objBulkShip.dtWO = New DataTable() '("WO")
                                dcColNew = New DataColumn("WO_ID")
                                dcColNew.DataType = System.Type.GetType("System.Int32")
                                Me._objBulkShip.dtWO.Columns.Add(dcColNew)
                            End If 'Check no exception occour
                        End If 'Pallet Qty and device count Qty
                    End If 'no duplicate
                End If 'input pallet name is listed
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnSelectLot_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                If Not IsNothing(dcColNew) Then
                    dcColNew.Dispose()
                    dcColNew = Nothing
                End If
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub btnFileCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFileCheck.Click
            Dim strSN As String = ""
            Dim iMatch As Integer = 0

            Try
                If Me.lstWrongOrder.Items.Count > 0 Then
                    MessageBox.Show("There are " & Me.lstWrongModel.Items.Count & " device with wrong order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.lstWrongModel.Items.Count > 0 Then
                    MessageBox.Show("There are " & Me.lstWrongModel.Items.Count & " device with wrong model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.lstDetail.Items.Count > 0 Then
                    MessageBox.Show("Some problems occurred in this lot. Please refers to detail list for more information.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    strSN = InputBox("Please scan in a 'Serial Number' for lot check.", "S/N").Trim.ToUpper

                    If strSN.Length > 0 Then

                        Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                        '0 - Lot Check not done
                        '1 - Done but SN not in list
                        '2 - Right Lot.
                        If _objBulkShip.dtExcelSNs.Select("Device_SN = '" & strSN & "'").Length > 0 Then iMatch = 1

                        If iMatch = 1 Then
                            _iFileCheckDone = 2
                            Me.BackColor = System.Drawing.Color.SteelBlue
                            System.Windows.Forms.Application.DoEvents()
                            MessageBox.Show("Serial Number exists in the lot.", "File Check", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.btnShip.Enabled = True
                        ElseIf iMatch = 0 Then
                            _iFileCheckDone = 1
                            Me.BackColor = System.Drawing.Color.Red
                            System.Windows.Forms.Application.DoEvents()
                            MessageBox.Show("STOP! Serial Number does not exist in the lot.", "File Check", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.btnShip.Enabled = False
                        End If
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnFileCheck_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                ClearLotSelection()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnClear_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub btnShip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShip.Click
            Const iAssemblyBillcode As Integer = 1900
            Dim i As Integer = 0
            Dim iHoldStatus As Integer = 0
            Dim objDevice As Rules.Device
            Dim R1 As DataRow

            Try
                '*****************************************************
                'Make sure a file has been selected and FILE CHECK done
                Me.btnShip.Enabled = False
                If _iFileCheckDone = 0 Then
                    MessageBox.Show("Lot check has not been done.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf _iFileCheckDone = 1 Then
                    Me.BackColor = System.Drawing.Color.Red
                    System.Windows.Forms.Application.DoEvents()
                    MessageBox.Show("Serial Number you have scanned in to do 'Lot Check' did not exist in the lot.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me._objBulkShip.iPallet_ID = 0 Then
                    MessageBox.Show("Lot is not defined.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    '******************************************************
                    'AUTO-BILL Assembly Billcodes
                    '******************************************************
                    For Each R1 In Me._objBulkShip.dtExcelSNs.Rows
                        objDevice = New Rules.Device(R1("Device_ID"))
                        If Generic.IsBillcodeExisted(Convert.ToInt32(R1("Device_ID")), iAssemblyBillcode) = False Then objDevice.AddPart(iAssemblyBillcode)
                        If Not IsNothing(objDevice) Then
                            objDevice.Dispose() : objDevice = Nothing
                        End If
                    Next R1
                    '******************************************************
                    'Bulk SHIP now.
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    i = _objBulkShip.BulkShip(False, iHoldStatus, Me.lstRegular.Items.Count, 0, 0)

                    ''******************************************************
                    Me.LoadOpenLots()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Ship Boxs", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        '********************************************************************************************************

    End Class
End Namespace