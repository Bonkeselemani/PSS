Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.TracFone

    Public Class frmManifestBERBoxes
        Inherits System.Windows.Forms.Form

        Private _strScreenName As String = ""
        Private _objWH As PSS.Data.Buisness.TracFone.Warehouse
        Private _dtBoxes As DataTable

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strScreenName As String)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _strScreenName = strScreenName
            _objWH = New PSS.Data.Buisness.TracFone.Warehouse()
            _dtBoxes = New DataTable()
            _dtBoxes.Columns.Add("Pallett_ID", System.Type.GetType("System.Int32"))
            _dtBoxes.Columns.Add("Box", System.Type.GetType("System.String"))
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If

                _objWH = Nothing
                Generic.DisposeDT(_dtBoxes)
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents cboShipTo As C1.Win.C1List.C1Combo
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents tpgManifest As System.Windows.Forms.TabPage
        Friend WithEvents tpgCertificate As System.Windows.Forms.TabPage
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents lblCount As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents btnCreateManifest As System.Windows.Forms.Button
        Friend WithEvents lstBoxes As System.Windows.Forms.ListBox
        Friend WithEvents dgBCBoxes As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents txtBoxName As System.Windows.Forms.TextBox
        Friend WithEvents btnRemoveAll As System.Windows.Forms.Button
        Friend WithEvents btnRemoveOne As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmManifestBERBoxes))
            Me.cboShipTo = New C1.Win.C1List.C1Combo()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.tpgManifest = New System.Windows.Forms.TabPage()
            Me.dgBCBoxes = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnCreateManifest = New System.Windows.Forms.Button()
            Me.btnRemoveAll = New System.Windows.Forms.Button()
            Me.btnRemoveOne = New System.Windows.Forms.Button()
            Me.lblCount = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtBoxName = New System.Windows.Forms.TextBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.lstBoxes = New System.Windows.Forms.ListBox()
            Me.tpgCertificate = New System.Windows.Forms.TabPage()
            CType(Me.cboShipTo, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControl1.SuspendLayout()
            Me.tpgManifest.SuspendLayout()
            CType(Me.dgBCBoxes, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'cboShipTo
            '
            Me.cboShipTo.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboShipTo.AutoCompletion = True
            Me.cboShipTo.AutoDropDown = True
            Me.cboShipTo.AutoSelect = True
            Me.cboShipTo.Caption = ""
            Me.cboShipTo.CaptionHeight = 17
            Me.cboShipTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboShipTo.ColumnCaptionHeight = 17
            Me.cboShipTo.ColumnFooterHeight = 17
            Me.cboShipTo.ColumnHeaders = False
            Me.cboShipTo.ContentHeight = 15
            Me.cboShipTo.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboShipTo.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboShipTo.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboShipTo.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboShipTo.EditorHeight = 15
            Me.cboShipTo.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboShipTo.ItemHeight = 15
            Me.cboShipTo.Location = New System.Drawing.Point(16, 28)
            Me.cboShipTo.MatchEntryTimeout = CType(2000, Long)
            Me.cboShipTo.MaxDropDownItems = CType(10, Short)
            Me.cboShipTo.MaxLength = 32767
            Me.cboShipTo.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboShipTo.Name = "cboShipTo"
            Me.cboShipTo.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboShipTo.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboShipTo.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboShipTo.Size = New System.Drawing.Size(320, 21)
            Me.cboShipTo.TabIndex = 84
            Me.cboShipTo.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:HotTrack;}Style3{}Inactive{ForeColor:InactiveCaptionText;Bac" & _
            "kColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{F" & _
            "oreColor:HighlightText;BackColor:Highlight;}Style1{}OddRow{}RecordSelector{Align" & _
            "Image:Center;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;Fore" & _
            "Color:ControlText;AlignVert:Center;}Style8{}Style10{}Style11{}Style9{AlignHorz:N" & _
            "ear;}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" N" & _
            "ame=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=" & _
            """17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 15" & _
            "6</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HSc" & _
            "rollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style9" & _
            """ /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" me" & _
            "=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Head" & _
            "ing"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inact" & _
            "iveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style8" & _
            """ /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle p" & _
            "arent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1L" & _
            "ist.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style pare" & _
            "nt=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""" & _
            "Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""N" & _
            "ormal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=" & _
            """Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Head" & _
            "ing"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><v" & _
            "ertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Defa" & _
            "ultRecSelWidth>16</DefaultRecSelWidth></Blob>"
            '
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.Transparent
            Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.White
            Me.Label5.Location = New System.Drawing.Point(16, 12)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(130, 16)
            Me.Label5.TabIndex = 85
            Me.Label5.Text = "Ship To :"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'TabControl1
            '
            Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpgManifest, Me.tpgCertificate})
            Me.TabControl1.Location = New System.Drawing.Point(8, 8)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(744, 520)
            Me.TabControl1.TabIndex = 86
            '
            'tpgManifest
            '
            Me.tpgManifest.BackColor = System.Drawing.Color.SteelBlue
            Me.tpgManifest.Controls.AddRange(New System.Windows.Forms.Control() {Me.dgBCBoxes, Me.btnCreateManifest, Me.btnRemoveAll, Me.btnRemoveOne, Me.lblCount, Me.Label3, Me.txtBoxName, Me.Label10, Me.lstBoxes, Me.Label5, Me.cboShipTo})
            Me.tpgManifest.Location = New System.Drawing.Point(4, 22)
            Me.tpgManifest.Name = "tpgManifest"
            Me.tpgManifest.Size = New System.Drawing.Size(736, 494)
            Me.tpgManifest.TabIndex = 0
            Me.tpgManifest.Text = "Manifest"
            '
            'dgBCBoxes
            '
            Me.dgBCBoxes.AllowColMove = False
            Me.dgBCBoxes.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
            Me.dgBCBoxes.AllowUpdate = False
            Me.dgBCBoxes.AllowUpdateOnBlur = False
            Me.dgBCBoxes.AlternatingRows = True
            Me.dgBCBoxes.CaptionHeight = 19
            Me.dgBCBoxes.CollapseColor = System.Drawing.Color.White
            Me.dgBCBoxes.ExpandColor = System.Drawing.Color.White
            Me.dgBCBoxes.FilterBar = True
            Me.dgBCBoxes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dgBCBoxes.ForeColor = System.Drawing.Color.White
            Me.dgBCBoxes.GroupByCaption = "Drag a column header here to group by that column"
            Me.dgBCBoxes.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.dgBCBoxes.Location = New System.Drawing.Point(368, 16)
            Me.dgBCBoxes.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Simple
            Me.dgBCBoxes.Name = "dgBCBoxes"
            Me.dgBCBoxes.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dgBCBoxes.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dgBCBoxes.PreviewInfo.ZoomFactor = 75
            Me.dgBCBoxes.RowHeight = 20
            Me.dgBCBoxes.Size = New System.Drawing.Size(352, 448)
            Me.dgBCBoxes.TabIndex = 108
            Me.dgBCBoxes.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Font:Tahoma, 8.25pt;ForeC" & _
            "olor:Black;BackColor:AliceBlue;}Selected{ForeColor:HighlightText;BackColor:Highl" & _
            "ight;}Style3{}Inactive{ForeColor:White;BackColor:InactiveCaption;}FilterBar{Font" & _
            ":Microsoft Sans Serif, 8.25pt;ForeColor:Black;BackColor:White;}Footer{Font:Tahom" & _
            "a, 8.25pt, style=Bold, Italic;AlignHorz:Far;}Caption{AlignHorz:Center;ForeColor:" & _
            "MidnightBlue;}Style1{}Normal{Font:Microsoft Sans Serif, 8.25pt, style=Bold;Align" & _
            "Vert:Center;ForeColor:White;BackColor:LightSteelBlue;}HighlightRow{ForeColor:Hig" & _
            "hlightText;BackColor:Highlight;}Style14{}OddRow{Font:Tahoma, 8.25pt;ForeColor:Bl" & _
            "ack;BackColor:LightBlue;}RecordSelector{ForeColor:White;AlignImage:Center;}Style" & _
            "15{}Heading{Wrap:True;Font:Tahoma, 8.25pt, style=Bold;AlignHorz:Center;BackColor" & _
            ":LightSteelBlue;Border:Raised,,1, 1, 1, 1;ForeColor:DarkBlue;AlignVert:Center;}S" & _
            "tyle8{}Style10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style16{}Style17{}Styl" & _
            "e9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" " & _
            "Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""True"" CaptionHeight=""17"" Colu" & _
            "mnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""Dott" & _
            "edCellBorder"" RecordSelectorWidth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""" & _
            "1"" HorizontalScrollGroup=""1""><Height>444</Height><CaptionStyle parent=""Style2"" m" & _
            "e=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""E" & _
            "venRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterS" & _
            "tyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><He" & _
            "adingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRo" & _
            "w"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle par" & _
            "ent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Styl" & _
            "e11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=" & _
            """Style1"" /><ClientRect>0, 0, 348, 444</ClientRect><BorderSide>0</BorderSide><Bor" & _
            "derStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyl" & _
            "es><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style p" & _
            "arent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style pare" & _
            "nt=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style paren" & _
            "t=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style paren" & _
            "t=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""He" & _
            "ading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style pare" & _
            "nt=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1<" & _
            "/horzSplits><Layout>None</Layout><DefaultRecSelWidth>16</DefaultRecSelWidth><Cli" & _
            "entArea>0, 0, 348, 444</ClientArea><PrintPageHeaderStyle parent="""" me=""Style16"" " & _
            "/><PrintPageFooterStyle parent="""" me=""Style17"" /></Blob>"
            '
            'btnCreateManifest
            '
            Me.btnCreateManifest.BackColor = System.Drawing.Color.Green
            Me.btnCreateManifest.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCreateManifest.ForeColor = System.Drawing.Color.White
            Me.btnCreateManifest.Location = New System.Drawing.Point(216, 432)
            Me.btnCreateManifest.Name = "btnCreateManifest"
            Me.btnCreateManifest.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnCreateManifest.Size = New System.Drawing.Size(112, 30)
            Me.btnCreateManifest.TabIndex = 107
            Me.btnCreateManifest.Text = "Create Manifest"
            '
            'btnRemoveAll
            '
            Me.btnRemoveAll.BackColor = System.Drawing.Color.Red
            Me.btnRemoveAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveAll.ForeColor = System.Drawing.Color.White
            Me.btnRemoveAll.Location = New System.Drawing.Point(216, 232)
            Me.btnRemoveAll.Name = "btnRemoveAll"
            Me.btnRemoveAll.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRemoveAll.Size = New System.Drawing.Size(112, 30)
            Me.btnRemoveAll.TabIndex = 104
            Me.btnRemoveAll.Text = "REMOVE ALL"
            '
            'btnRemoveOne
            '
            Me.btnRemoveOne.BackColor = System.Drawing.Color.Red
            Me.btnRemoveOne.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveOne.ForeColor = System.Drawing.Color.White
            Me.btnRemoveOne.Location = New System.Drawing.Point(216, 176)
            Me.btnRemoveOne.Name = "btnRemoveOne"
            Me.btnRemoveOne.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRemoveOne.Size = New System.Drawing.Size(112, 30)
            Me.btnRemoveOne.TabIndex = 103
            Me.btnRemoveOne.Text = "REMOVE ONE"
            '
            'lblCount
            '
            Me.lblCount.BackColor = System.Drawing.Color.Black
            Me.lblCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCount.ForeColor = System.Drawing.Color.Lime
            Me.lblCount.Location = New System.Drawing.Point(224, 104)
            Me.lblCount.Name = "lblCount"
            Me.lblCount.Size = New System.Drawing.Size(96, 43)
            Me.lblCount.TabIndex = 106
            Me.lblCount.Text = "0"
            Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(224, 88)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(96, 16)
            Me.Label3.TabIndex = 105
            Me.Label3.Text = "Box Count"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'txtBoxName
            '
            Me.txtBoxName.Location = New System.Drawing.Point(16, 72)
            Me.txtBoxName.Name = "txtBoxName"
            Me.txtBoxName.Size = New System.Drawing.Size(176, 20)
            Me.txtBoxName.TabIndex = 100
            Me.txtBoxName.Text = ""
            '
            'Label10
            '
            Me.Label10.BackColor = System.Drawing.Color.Transparent
            Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.White
            Me.Label10.Location = New System.Drawing.Point(16, 56)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(176, 16)
            Me.Label10.TabIndex = 102
            Me.Label10.Text = "Box Number:"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lstBoxes
            '
            Me.lstBoxes.Location = New System.Drawing.Point(16, 96)
            Me.lstBoxes.Name = "lstBoxes"
            Me.lstBoxes.Size = New System.Drawing.Size(176, 368)
            Me.lstBoxes.TabIndex = 101
            '
            'tpgCertificate
            '
            Me.tpgCertificate.BackColor = System.Drawing.Color.LightSteelBlue
            Me.tpgCertificate.Location = New System.Drawing.Point(4, 22)
            Me.tpgCertificate.Name = "tpgCertificate"
            Me.tpgCertificate.Size = New System.Drawing.Size(736, 494)
            Me.tpgCertificate.TabIndex = 1
            Me.tpgCertificate.Text = "Certificate"
            '
            'frmManifestBERBoxes
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(768, 549)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1})
            Me.Name = "frmManifestBERBoxes"
            Me.Text = "frmProcessBER"
            CType(Me.cboShipTo, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControl1.ResumeLayout(False)
            Me.tpgManifest.ResumeLayout(False)
            CType(Me.dgBCBoxes, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '********************************************************************
        Private Sub frmManifestBERBoxes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable

            Try
                '******************************************
                'populate data to dropdown list controls
                '******************************************
                dt = Me._objWH.GetDiposeShipToAddress(PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, True)
                Misc.PopulateC1DropDownList(Me.cboShipTo, dt, "ShipTo_Name", "ShipTo_ID")
                Me.cboShipTo.SelectedValue = 0

                Me.PopulateReadyToBeManifestBERBoxes()

                Me.lstBoxes.DataSource = Me._dtBoxes.DefaultView
                Me.lstBoxes.ValueMember = _dtBoxes.Columns("Pallett_ID").ToString
                Me.lstBoxes.DisplayMember = _dtBoxes.Columns("Box").ToString

                '******************************************
                Me.cboShipTo.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "FormLoad", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '********************************************************************
        Private Sub PopulateReadyToBeManifestBERBoxes()
            Dim dt As DataTable
            Dim _boxQty As Decimal = 0
            Dim _stationQty As Decimal = 0
            Try
                dt = Me._objWH.GetReadyToManifestBERBoxes(PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID)
                With Me.dgBCBoxes
                    .DataSource = dt.DefaultView
                    .Splits(0).DisplayColumns("Box").Width = 150
                    .Splits(0).DisplayColumns("Box Qty").Width = 70
                    .Splits(0).DisplayColumns("Station Qty").Width = 85
                    .Splits(0).DisplayColumns("Pallett_ID").Visible = False
                    '.Splits(0).DisplayColumns("Station Qty").Visible = False
                    .ColumnFooters = True
                    .Columns("Box").FooterText = dt.Rows.Count
                    If dt.Rows.Count > 0 Then
                        _boxQty = dt.Compute("Sum([Box Qty])", "")
                        _stationQty = dt.Compute("Sum([Station Qty])", "")
                    End If
                    .Columns("Box Qty").FooterText = _boxQty
                    .Columns("Station Qty").FooterText = _stationQty
                End With
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "PopulateReadyToBeManifestBERBoxes", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '********************************************************************
        Private Sub dgBCBoxes_AfterFilter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles dgBCBoxes.AfterFilter
            Dim i, iBoxCnt, iBoxQty, iStationQty As Integer

            Try
                i = 0 : iBoxCnt = 0 : iBoxQty = 0 : iStationQty = 0

                'Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                With Me.dgBCBoxes

                    For i = 0 To .RowCount - 1
                        iBoxCnt += 1
                        iBoxQty += CInt(.Columns("Box Qty").CellValue(i))
                        iStationQty += CInt(.Columns("Station Qty").CellValue(i))
                    Next i

                    .Columns("Box").FooterText = Format(iBoxCnt, "#,##0").ToString
                    .Columns("Box Qty").FooterText = Format(iBoxQty, "#,##0").ToString
                    .Columns("Station Qty").FooterText = Format(iStationQty, "#,##0").ToString
                End With

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dgBCBoxes_AfterFilter", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                'Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '********************************************************************
        Private Sub txtBoxName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBoxName.KeyUp
            Dim dt As DataTable
            Dim R1 As DataRow

            Try
                If e.KeyCode = Keys.Enter Then
                    If Me.txtBoxName.Text.Trim.Length = 0 Then Exit Sub

                    dt = Me._objWH.GetReadyToManifestBERBoxInfo(Me.txtBoxName.Text.Trim, PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID)

                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("Box does not exist.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.txtBoxName.SelectAll() : Me.txtBoxName.Focus()
                    ElseIf dt.Rows.Count > 1 Then
                        MessageBox.Show("Box has multiple workstation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.txtBoxName.SelectAll() : Me.txtBoxName.Focus()
                    ElseIf dt.Rows(0)("Pallet_ShipType") <> 1 Then
                        MessageBox.Show("Box is not BER.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.txtBoxName.SelectAll() : Me.txtBoxName.Focus()
                    ElseIf IsDBNull(dt.Rows(0)("Pallett_ShipDate")) Then
                        MessageBox.Show("Box has not yet completed by the line.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.txtBoxName.SelectAll() : Me.txtBoxName.Focus()
                    ElseIf Not IsDBNull(dt.Rows(0)("pkslip_ID")) Then
                        MessageBox.Show("Box has been manifest (# " & dt.Rows(0)("pkslip_ID") & ").", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.txtBoxName.SelectAll() : Me.txtBoxName.Focus()
                        'ElseIf Me._objWH.IsBoxBeenToTearDown(dt.Rows(0)("Pallett_ID")) = False Then
                        '    MessageBox.Show("Box has not been to teardown.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        '    Me.txtBoxName.SelectAll() : Me.txtBoxName.Focus()
                    ElseIf Misc.ValidateFrStationOfScreenInWorkFlow(Me._strScreenName, dt.Rows(0)("WorkStation").ToString.Trim, PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, 0) = False Then
                        Me.txtBoxName.Text = "" : Me.txtBoxName.Focus()
                    ElseIf _dtBoxes.Select("Box = '" & Me.txtBoxName.Text.Trim & "'").Length > 0 Then
                        MessageBox.Show("Box has already scanned.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.txtBoxName.SelectAll() : Me.txtBoxName.Focus()
                    Else
                        Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                        R1 = Me._dtBoxes.NewRow()
                        R1("Pallett_ID") = dt.Rows(0)("Pallett_ID")
                        R1("Box") = dt.Rows(0)("Box")
                        Me._dtBoxes.Rows.Add(R1)
                        Me._dtBoxes.AcceptChanges()
                        Me.lblCount.Text = Me._dtBoxes.Rows.Count
                        Me.txtBoxName.Text = ""
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtBoxName_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                Generic.DisposeDT(dt)
                R1 = Nothing
            End Try
        End Sub

        '********************************************************************
        Private Sub btnRemoveSN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveOne.Click
            Dim strBoxName As String = ""
            Dim R1() As DataRow
            Dim i As Integer

            Try
                strBoxName = InputBox("Enter box name:").Trim.ToUpper
                If strBoxName.Trim.Length = 0 Then Exit Sub

                If Me._dtBoxes.Select("Box = '" & strBoxName & "'").Length = 0 Then
                    MessageBox.Show("Box is not listed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Else
                    R1 = _dtBoxes.Select("Box = '" & strBoxName & "'")
                    For i = 0 To R1.Length - 1
                        _dtBoxes.Rows.Remove(R1(i))
                    Next i

                    _dtBoxes.AcceptChanges()
                    Me.lstBoxes.Refresh()
                    Me.lblCount.Text = Me._dtBoxes.Rows.Count
                    Me.txtBoxName.Text = ""
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtBoxName_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                R1 = Nothing
            End Try
        End Sub

        '********************************************************************
        Private Sub btnRemoveAllSNs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveAll.Click
            Try
                If MessageBox.Show("Are you sure you want to remove all boxes in list?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub
                _dtBoxes.Clear()
                _dtBoxes.AcceptChanges()
                Me.lstBoxes.Refresh()
                Me.lblCount.Text = Me._dtBoxes.Rows.Count
                Me.txtBoxName.Text = ""
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtBoxName_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************
        Private Sub btnCreateManifest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateManifest.Click
            Dim strPalletIDs As String = ""
            Dim R1 As DataRow
            Dim dtData As DataTable

            Try
                If Me._dtBoxes.Rows.Count = 0 Then
                    MessageBox.Show("List is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Else
                    If MessageBox.Show("Are you sure you want to create manifest?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub

                    For Each R1 In Me._dtBoxes.Rows
                        If strPalletIDs.Length > 0 Then strPalletIDs &= ", "
                        strPalletIDs &= R1("Pallett_ID")
                    Next R1

                    dtData = Me._objWH.GetBoxData(strPalletIDs)
                    If dtData.Select("Pallet_ShipType <> 1").Length > 0 Then
                        MessageBox.Show("Box # " & dtData.Select("Pallet_ShipType <> 1")(0)("Pallett_Name") & " is not BER.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    ElseIf dtData.Select("Pallett_ShipDate = ''").Length > 0 Then
                        MessageBox.Show("Box # " & dtData.Select("Pallett_ShipDate = ''")(0)("Pallett_Name") & " is not completed by the line.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    ElseIf dtData.Select("pkslip_ID > 0").Length > 0 Then
                        MessageBox.Show("Box # " & dtData.Select("pkslip_ID > 0")(0)("Pallett_Name") & " has already processed at this screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Else
                        Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                        Me._objWH.CreateBERManifest(strPalletIDs, PSS.Core.ApplicationUser.IDuser, _strScreenName, Me.Name)
                        _dtBoxes.Clear()
                        _dtBoxes.AcceptChanges()
                        Me.lstBoxes.Refresh()
                        Me.lblCount.Text = Me._dtBoxes.Rows.Count
                        Me.txtBoxName.Text = ""
                        Me.PopulateReadyToBeManifestBERBoxes()
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtBoxName_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                Generic.DisposeDT(dtData)
            End Try
        End Sub

        '********************************************************************


    End Class
End Namespace