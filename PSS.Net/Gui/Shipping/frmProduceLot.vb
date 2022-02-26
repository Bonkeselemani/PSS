Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui
    Public Class frmProduceLot
        Inherits System.Windows.Forms.Form

        Private _strScreenName As String = ""
        Private _iMenuCustID As Integer = 0
        Private _iMenuLocID As Integer = 0
        Private _objShip As PSS.Data.Production.Shipping
        Private _iFileCheckDone As Integer = 0
        Private _iPalletShipType As Integer = 0
        Private _iLocID As Integer = 0

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strScreenName As String, ByVal iCustID As Integer, ByVal iLocID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _strScreenName = strScreenName
            _iMenuCustID = iCustID
            _iMenuLocID = iLocID
            _objShip = New PSS.Data.Production.Shipping()
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
        Friend WithEvents btnSelectBox As System.Windows.Forms.Button
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents PanelList As System.Windows.Forms.Panel
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents lstBER As System.Windows.Forms.ListBox
        Friend WithEvents lstRegular As System.Windows.Forms.ListBox
        Friend WithEvents lstWrongModel As System.Windows.Forms.ListBox
        Friend WithEvents btnShip As System.Windows.Forms.Button
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents lstBERParts As System.Windows.Forms.ListBox
        Friend WithEvents btnFileCheck As System.Windows.Forms.Button
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents dbgPallets As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lblCnt As System.Windows.Forms.Label
        Friend WithEvents lblPallet As System.Windows.Forms.Label
        Friend WithEvents lblScreenName As System.Windows.Forms.Label
        Friend WithEvents pnlRecycle As System.Windows.Forms.Panel
        Friend WithEvents lstRecycle As System.Windows.Forms.ListBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmProduceLot))
            Me.btnSelectBox = New System.Windows.Forms.Button()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.PanelList = New System.Windows.Forms.Panel()
            Me.lstBER = New System.Windows.Forms.ListBox()
            Me.lstRegular = New System.Windows.Forms.ListBox()
            Me.lstWrongModel = New System.Windows.Forms.ListBox()
            Me.btnShip = New System.Windows.Forms.Button()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.lstBERParts = New System.Windows.Forms.ListBox()
            Me.btnFileCheck = New System.Windows.Forms.Button()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.pnlRecycle = New System.Windows.Forms.Panel()
            Me.lstRecycle = New System.Windows.Forms.ListBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.dbgPallets = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.lblCnt = New System.Windows.Forms.Label()
            Me.lblPallet = New System.Windows.Forms.Label()
            Me.lblScreenName = New System.Windows.Forms.Label()
            Me.PanelList.SuspendLayout()
            Me.pnlRecycle.SuspendLayout()
            CType(Me.dbgPallets, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'btnSelectBox
            '
            Me.btnSelectBox.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnSelectBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSelectBox.ForeColor = System.Drawing.Color.Blue
            Me.btnSelectBox.Location = New System.Drawing.Point(656, 72)
            Me.btnSelectBox.Name = "btnSelectBox"
            Me.btnSelectBox.Size = New System.Drawing.Size(160, 32)
            Me.btnSelectBox.TabIndex = 98
            Me.btnSelectBox.Text = "SELECT BOX"
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Black
            Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Lime
            Me.Label1.Location = New System.Drawing.Point(720, 0)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(96, 18)
            Me.Label1.TabIndex = 97
            Me.Label1.Text = "COUNT"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'PanelList
            '
            Me.PanelList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.PanelList.Controls.AddRange(New System.Windows.Forms.Control() {Me.lstBER, Me.lstRegular, Me.lstWrongModel, Me.btnShip, Me.Label2, Me.Label3, Me.Label12, Me.btnClear, Me.lstBERParts, Me.btnFileCheck, Me.Label11, Me.pnlRecycle})
            Me.PanelList.Location = New System.Drawing.Point(0, 224)
            Me.PanelList.Name = "PanelList"
            Me.PanelList.Size = New System.Drawing.Size(824, 296)
            Me.PanelList.TabIndex = 92
            Me.PanelList.Visible = False
            '
            'lstBER
            '
            Me.lstBER.Location = New System.Drawing.Point(152, 32)
            Me.lstBER.Name = "lstBER"
            Me.lstBER.Size = New System.Drawing.Size(120, 212)
            Me.lstBER.TabIndex = 2
            '
            'lstRegular
            '
            Me.lstRegular.Location = New System.Drawing.Point(8, 32)
            Me.lstRegular.Name = "lstRegular"
            Me.lstRegular.Size = New System.Drawing.Size(120, 212)
            Me.lstRegular.TabIndex = 1
            '
            'lstWrongModel
            '
            Me.lstWrongModel.Location = New System.Drawing.Point(440, 32)
            Me.lstWrongModel.Name = "lstWrongModel"
            Me.lstWrongModel.Size = New System.Drawing.Size(120, 212)
            Me.lstWrongModel.TabIndex = 4
            '
            'btnShip
            '
            Me.btnShip.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnShip.Enabled = False
            Me.btnShip.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnShip.ForeColor = System.Drawing.Color.Blue
            Me.btnShip.Location = New System.Drawing.Point(600, 256)
            Me.btnShip.Name = "btnShip"
            Me.btnShip.Size = New System.Drawing.Size(200, 32)
            Me.btnShip.TabIndex = 9
            Me.btnShip.Text = "PRODUCE"
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
            'Label3
            '
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(152, 16)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(108, 16)
            Me.Label3.TabIndex = 5
            Me.Label3.Text = "RUR/BER Units:"
            '
            'Label12
            '
            Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label12.ForeColor = System.Drawing.Color.White
            Me.Label12.Location = New System.Drawing.Point(296, 0)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(120, 32)
            Me.Label12.TabIndex = 55
            Me.Label12.Text = "BER/RUR Units with Parts:"
            '
            'btnClear
            '
            Me.btnClear.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClear.ForeColor = System.Drawing.Color.Black
            Me.btnClear.Location = New System.Drawing.Point(464, 256)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(120, 32)
            Me.btnClear.TabIndex = 7
            Me.btnClear.Text = "Clear"
            '
            'lstBERParts
            '
            Me.lstBERParts.Location = New System.Drawing.Point(296, 32)
            Me.lstBERParts.Name = "lstBERParts"
            Me.lstBERParts.Size = New System.Drawing.Size(120, 212)
            Me.lstBERParts.TabIndex = 3
            '
            'btnFileCheck
            '
            Me.btnFileCheck.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnFileCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnFileCheck.ForeColor = System.Drawing.Color.Black
            Me.btnFileCheck.Location = New System.Drawing.Point(8, 256)
            Me.btnFileCheck.Name = "btnFileCheck"
            Me.btnFileCheck.Size = New System.Drawing.Size(440, 32)
            Me.btnFileCheck.TabIndex = 6
            Me.btnFileCheck.Text = "LOT CHECK (DO I HAVE THE RIGHT LOT AND RIGHT SNs?)"
            '
            'Label11
            '
            Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label11.ForeColor = System.Drawing.Color.White
            Me.Label11.Location = New System.Drawing.Point(440, 16)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(113, 21)
            Me.Label11.TabIndex = 53
            Me.Label11.Text = "Wrong Model:"
            '
            'pnlRecycle
            '
            Me.pnlRecycle.Controls.AddRange(New System.Windows.Forms.Control() {Me.lstRecycle, Me.Label4})
            Me.pnlRecycle.Location = New System.Drawing.Point(576, 0)
            Me.pnlRecycle.Name = "pnlRecycle"
            Me.pnlRecycle.Size = New System.Drawing.Size(136, 248)
            Me.pnlRecycle.TabIndex = 99
            '
            'lstRecycle
            '
            Me.lstRecycle.Location = New System.Drawing.Point(8, 32)
            Me.lstRecycle.Name = "lstRecycle"
            Me.lstRecycle.Size = New System.Drawing.Size(120, 212)
            Me.lstRecycle.TabIndex = 61
            '
            'Label4
            '
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(8, 8)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(113, 21)
            Me.Label4.TabIndex = 62
            Me.Label4.Text = "Recycle:"
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
            Me.dbgPallets.Caption = "Boxes to be Produce"
            Me.dbgPallets.CaptionHeight = 17
            Me.dbgPallets.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dbgPallets.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgPallets.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dbgPallets.Location = New System.Drawing.Point(0, 53)
            Me.dbgPallets.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.dbgPallets.Name = "dbgPallets"
            Me.dbgPallets.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgPallets.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgPallets.PreviewInfo.ZoomFactor = 75
            Me.dbgPallets.RowHeight = 20
            Me.dbgPallets.Size = New System.Drawing.Size(640, 170)
            Me.dbgPallets.TabIndex = 93
            Me.dbgPallets.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{Font:Tahoma, 8" & _
            ".25pt, style=Bold;AlignHorz:Center;ForeColor:Green;BackColor:LightSteelBlue;}Sty" & _
            "le1{}Normal{Font:Microsoft Sans Serif, 8.25pt;AlignVert:Center;BackColor:LightSt" & _
            "eelBlue;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style14{}OddR" & _
            "ow{BackColor:LightSteelBlue;}RecordSelector{AlignImage:Center;}Style15{}Heading{" & _
            "Wrap:True;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;AlignVe" & _
            "rt:Center;Border:Raised,,1, 1, 1, 1;ForeColor:White;BackColor:SteelBlue;}Style8{" & _
            "}Style10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style9{}</Data></Styles><Spl" & _
            "its><C1.Win.C1TrueDBGrid.MergeView HBarHeight=""24"" AllowColMove=""False"" AllowCol" & _
            "Select=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""True"" CaptionH" & _
            "eight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""Dotted" & _
            "CellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1""" & _
            " HorizontalScrollGroup=""1""><Height>148</Height><CaptionStyle parent=""Style2"" me=" & _
            """Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""Eve" & _
            "nRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterSty" & _
            "le parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><Head" & _
            "ingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow""" & _
            " me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle paren" & _
            "t=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style1" & _
            "1"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""S" & _
            "tyle1"" /><ClientRect>0, 17, 636, 148</ClientRect><BorderSide>0</BorderSide><Bord" & _
            "erStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyle" & _
            "s><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style pa" & _
            "rent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style paren" & _
            "t=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent" & _
            "=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent" & _
            "=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Hea" & _
            "ding"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style paren" & _
            "t=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</" & _
            "horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><Clie" & _
            "ntArea>0, 0, 636, 166</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /" & _
            "><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'lblCnt
            '
            Me.lblCnt.BackColor = System.Drawing.Color.Black
            Me.lblCnt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblCnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCnt.ForeColor = System.Drawing.Color.Lime
            Me.lblCnt.Location = New System.Drawing.Point(720, 16)
            Me.lblCnt.Name = "lblCnt"
            Me.lblCnt.Size = New System.Drawing.Size(96, 36)
            Me.lblCnt.TabIndex = 95
            Me.lblCnt.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'lblPallet
            '
            Me.lblPallet.BackColor = System.Drawing.Color.Black
            Me.lblPallet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPallet.ForeColor = System.Drawing.Color.Lime
            Me.lblPallet.Location = New System.Drawing.Point(328, 0)
            Me.lblPallet.Name = "lblPallet"
            Me.lblPallet.Size = New System.Drawing.Size(392, 53)
            Me.lblPallet.TabIndex = 96
            Me.lblPallet.Tag = "0"
            Me.lblPallet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblScreenName
            '
            Me.lblScreenName.BackColor = System.Drawing.Color.Black
            Me.lblScreenName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblScreenName.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblScreenName.ForeColor = System.Drawing.Color.Yellow
            Me.lblScreenName.Name = "lblScreenName"
            Me.lblScreenName.Size = New System.Drawing.Size(336, 53)
            Me.lblScreenName.TabIndex = 94
            Me.lblScreenName.Text = "PRODUCE BOXES"
            Me.lblScreenName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'frmProduceLot
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(832, 542)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnSelectBox, Me.Label1, Me.PanelList, Me.dbgPallets, Me.lblCnt, Me.lblPallet, Me.lblScreenName})
            Me.Name = "frmProduceLot"
            Me.Text = "frmProduceLot"
            Me.PanelList.ResumeLayout(False)
            Me.pnlRecycle.ResumeLayout(False)
            CType(Me.dbgPallets, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '*************************************************************************************************************
        Private Sub frmProduceLot_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                Me.lblScreenName.Text = Me._strScreenName

                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                'Populate open pallet
                Me.PopulateReadyToProducePallets()

                '******************************************
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "FormLoad", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '*************************************************************************************************************
        Public Sub PopulateReadyToProducePallets()
            Dim dt As DataTable
            Dim i As Integer = 0

            Try
                dt = _objShip.GetAvailablePallets(False, Me._iMenuLocID, Me._iMenuCustID, 1, , , , )
                dt.Columns("Pallett_Name").ColumnName = "Lot Name"
                dt.Columns("Model_Desc").ColumnName = "Model"
                dt.Columns("Pallettype_LDesc").ColumnName = "Lot Type"
                dt.Columns("Pallett_QTY").ColumnName = "Lot Qty"
                dt.AcceptChanges()

                With Me.dbgPallets
                    .DataSource = dt.DefaultView

                    For i = 0 To dt.Columns.Count - 1
                        .Splits(0).DisplayColumns(i).Visible = False
                    Next i

                    .Splits(0).DisplayColumns("Lot Name").Visible = True
                    .Splits(0).DisplayColumns("Model").Visible = True
                    .Splits(0).DisplayColumns("Lot Type").Visible = True
                    .Splits(0).DisplayColumns("Lot Qty").Visible = True
                End With

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub btnSelectBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectBox.Click
            Try
                If Me.dbgPallets.RowCount = 0 Or Me.dbgPallets.Columns.Count = 0 Then
                    Exit Sub
                ElseIf Convert.ToInt32(Me.dbgPallets.Columns("Pallett_ID").CellValue(Me.dbgPallets.Row)) = 0 Then
                    MessageBox.Show("Lot ID is missing for selected row.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    Me.ProcessPallet()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnSelectBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub ProcessPallet()
            Dim i As Integer
            Dim R1, drException() As DataRow
            Dim dt As DataTable

            Try
                If Me.dbgPallets.RowCount = 0 Or Me.dbgPallets.Columns.Count = 0 Then
                    Exit Sub
                ElseIf Convert.ToInt32(Me.dbgPallets.Columns("Pallett_ID").CellValue(Me.dbgPallets.Row)) = 0 Then
                    MessageBox.Show("Pallet ID is missing for selected row.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    Me.ClearListControls() : Me.PanelList.Visible = True

                    Me.BackColor = System.Drawing.Color.SteelBlue : System.Windows.Forms.Application.DoEvents()

                    '************************************************
                    'Check OOBA 
                    '************************************************
                    If Me.dbgPallets.Columns("AQL_QCResult_ID").Value = 2 Then
                        MessageBox.Show("This lot has been failed at OBA-AQL.", "AQL Check", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If

                    '************************************************
                    _iFileCheckDone = 0 : i = 0
                    '************************************************
                    'Step 1 :: Extract IMEI numbers from the database
                    '************************************************
                    dt = Me._objShip.GetDeviceSNs(Convert.ToInt32(Me.dbgPallets.Columns("Pallett_ID").CellValue(Me.dbgPallets.Row)))

                    '************************************************
                    'Check Lot quantity
                    '************************************************
                    If Me._iMenuCustID = 2463 And Me.dbgPallets.Columns("Pallettype_SDesc").CellValue(Me.dbgPallets.Row) = "CYL" Then
                        'Hung Nguyen August 2nd,2011 
                        'Update total quantity for Nespresso Recycle Pallet,
                        ' since the total quantity is unknown when creating recycle pallet from Nespresso Receiving screen 
                        Me.dbgPallets.Columns("Lot Qty").Value = dt.Rows.Count
                        Me._objShip.UpdatePalletQuantity(Convert.ToInt32(Me.dbgPallets.Columns("Pallett_ID").CellValue(Me.dbgPallets.Row)), dt.Rows.Count)
                    ElseIf dt.Rows.Count <> Convert.ToInt32(Me.dbgPallets.Columns("Lot Qty").CellValue(Me.dbgPallets.Row)) Then
                        MessageBox.Show("Lot quantity and device count does not match.", "Qty Check", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If

                    ''************************************************
                    ''Check Model 
                    ''************************************************
                    'If Convert.ToInt32(Me.dbgPallets.Columns("Model_ID").CellValue(Me.dbgPallets.Row)) > 0 Then
                    '    drException = dt.Select("Model_ID <> " & Convert.ToInt32(Me.dbgPallets.Columns("Model_ID").CellValue(Me.dbgPallets.Row)))
                    '    If drException.Length > 0 Then
                    '        MessageBox.Show("Wrong model.", "Model Check", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    '        For i = 0 To drException.Length - 1
                    '            Me.lstWrongModel.Items.Add(drException("Device_SN"))
                    '        Next i
                    '        Exit Sub
                    '    End If
                    'End If

                    '************************************************
                    'Parts check
                    '************************************************
                    If (Convert.ToInt32(Me.dbgPallets.Columns("Pallet_ShipType").CellValue(Me.dbgPallets.Row)) > 0 OrElse Me.dbgPallets.Columns("NoPartAllow").CellValue(Me.dbgPallets.Row) > 0) AndAlso Me.CheckBERRURWithParts(Convert.ToInt32(Me.dbgPallets.Columns("Pallett_ID").CellValue(Me.dbgPallets.Row))) = False Then
                        MessageBox.Show("Lot has device with parts.", "Part Check", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If

                    '************************************************
                    'Populate device into list
                    '************************************************
                    Me.PopulateDeviceToList(dt)
                    Me.lblCnt.Text = dt.Rows.Count
                    Me.lblPallet.Text = Me.dbgPallets.Columns("Lot Name").CellValue(Me.dbgPallets.Row)
                    Me.lblPallet.Tag = Convert.ToInt32(Me.dbgPallets.Columns("Pallett_ID").CellValue(Me.dbgPallets.Row))
                    Me._iPalletShipType = Convert.ToInt32(Me.dbgPallets.Columns("Pallet_ShipType").CellValue(Me.dbgPallets.Row))
                    Me._iLocID = Convert.ToInt32(Me.dbgPallets.Columns("Loc_ID").CellValue(Me.dbgPallets.Row))
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
                R1 = Nothing
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub ClearListControls()
            Try
                Me.lstRegular.Items.Clear()
                Me.lstBER.Items.Clear()
                Me.lstBERParts.Items.Clear()
                Me.lstWrongModel.Items.Clear()
                Me.lstRecycle.Items.Clear()
                Me.lblCnt.Text = ""
                Me.lblPallet.Text = "" : Me.lblPallet.Tag = 0
                Me.PanelList.Visible = False
                Me.btnShip.Enabled = False
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*************************************************************************************************************
        Public Function PopulateDeviceToList(ByVal dt As DataTable) As Integer
            Dim i As Integer = 0

            Try
                For i = 0 To dt.Rows.Count - 1
                    If Me._iMenuCustID = 2463 And Me.dbgPallets.Columns("Pallettype_SDesc").CellValue(Me.dbgPallets.Row) = "CYL" Then
                        Me.lstRecycle.Items.Add(dt.Rows(i)("Device_SN"))
                    ElseIf Convert.ToInt32(Me.dbgPallets.Columns("Pallet_ShipType").CellValue(Me.dbgPallets.Row)) = 0 Then
                        Me.lstRegular.Items.Add(dt.Rows(i)("Device_SN"))
                    ElseIf Convert.ToInt32(Me.dbgPallets.Columns("Pallet_ShipType").CellValue(Me.dbgPallets.Row)) = 1 Then
                        Me.lstBER.Items.Add(dt.Rows(i)("Device_SN"))
                    ElseIf Convert.ToInt32(Me.dbgPallets.Columns("Pallet_ShipType").CellValue(Me.dbgPallets.Row)) = 3 Then
                        Me.lstRecycle.Items.Add(dt.Rows(i)("Device_SN"))
                    Else
                        Throw New Exception("System can't define ship type.")
                    End If
                Next i
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '*************************************************************************************************************
        Public Function CheckBERRURWithParts(ByVal iPalletID As Integer) As Boolean
            Dim R1 As DataRow
            Dim dt As DataTable

            Try
                dt = Me._objShip.GetDeviceWithPartsOnPallet(iPalletID)
                If dt.Rows.Count > 0 Then
                    For Each R1 In dt.Rows
                        Me.lstBERParts.Items.Add(R1("Device_SN"))
                    Next R1
                    Return False
                Else
                    Return True
                End If
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '*************************************************************************************************************
        Private Sub btnFileCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFileCheck.Click
            Dim strSN As String = ""
            Dim iSNIndex As Integer = -1

            Try
                If Convert.ToInt32(Me.lblPallet.Tag) = 0 OrElse Me.lblPallet.Text.Trim.Length = 0 Then
                    MessageBox.Show("No lot has been selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    strSN = InputBox("Enter SN:").Trim
                    If strSN.Length = 0 Then
                        Exit Sub
                    Else
                        If Me._iMenuCustID = 2463 And Me.dbgPallets.Columns("Pallettype_SDesc").CellValue(Me.dbgPallets.Row) = "CYL" Then 'Nespresso Recycle
                            If Me.lstRecycle.Items.Count = 0 Then MessageBox.Show("The Nespresso Recycle list is empty.", "Information", MessageBoxButtons.OK)
                            iSNIndex = Me.lstRecycle.Items.IndexOf(strSN)
                        ElseIf Me._iPalletShipType = 0 Then
                            If Me.lstRegular.Items.Count = 0 Then MessageBox.Show("The list is empty.", "Information", MessageBoxButtons.OK)
                            iSNIndex = Me.lstRegular.Items.IndexOf(strSN)
                        ElseIf Me._iPalletShipType = 1 Then
                            If Me.lstBER.Items.Count = 0 Then MessageBox.Show("The list is empty.", "Information", MessageBoxButtons.OK)
                            iSNIndex = Me.lstBER.Items.IndexOf(strSN)
                        ElseIf Me._iPalletShipType = 3 Then
                            If Me.lstRecycle.Items.Count = 0 Then MessageBox.Show("The list is empty.", "Information", MessageBoxButtons.OK)
                            iSNIndex = Me.lstRecycle.Items.IndexOf(strSN)
                        Else
                            Throw New Exception("System can't define ship type.")
                        End If

                        If iSNIndex < 0 Then
                            MessageBox.Show("SN is not matched.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me._iFileCheckDone = 0 : Me.BackColor = Color.Red
                        Else
                            Me._iFileCheckDone = 2
                            Me.btnShip.Enabled = True
                        End If
                    End If 'check input sn
                End If 'check if pallet is selected

            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnFileCheck_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
            Try
                Me.ClearListControls()
                Me.lblCnt.Text = ""
                Me.lblPallet.Text = ""
                Me.lblPallet.Tag = 0
                Me._iFileCheckDone = 0
                Me._iPalletShipType = 0
                Me._iLocID = 0
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnClear_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub btnShip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShip.Click
            Dim iHoldStatus, iProdID, i As Integer

            Try
                If DoValidation() = False Then
                    Exit Sub
                ElseIf Me._iFileCheckDone = 0 Then
                    MessageBox.Show("Lot check has not been done.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.btnShip.Enabled = False : Exit Sub
                ElseIf Me._iFileCheckDone = 1 Then
                    MessageBox.Show("Fail lot check.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.btnShip.Enabled = False : Exit Sub
                End If

                iHoldStatus = 0 : iProdID = 0 : i = 0
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                iProdID = Me._objShip.GetProdIDOfPallet(Convert.ToInt32(Me.lblPallet.Tag))

                '******************************************************
                'Bulk SHIP now.
                '******************************************************
                i = Me._objShip.BulkShip(iHoldStatus, Convert.ToInt32(Me.lblPallet.Tag), Convert.ToInt32(Me.lblCnt.Text), Me._iPalletShipType, PSS.Core.ApplicationUser.User, iProdID, PSS.Core.ApplicationUser.IDShift, Me._iLocID, , )

                '***********************************************
                btnClear_Click(Nothing, Nothing)
                Me.PopulateReadyToProducePallets()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '*************************************************************************************************************
        Private Function DoValidation() As Boolean
            Try
                '***************************
                If Convert.ToInt32(Me.lblPallet.Tag) = 0 OrElse Me.lblPallet.Text.Trim.Length = 0 Then
                    MessageBox.Show("Lot is not selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                ElseIf Convert.ToInt32(Me.lblCnt.Text) = 0 Then
                    MessageBox.Show("Lot is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.BackColor = System.Drawing.Color.Red : System.Windows.Forms.Application.DoEvents()
                    Return False
                Else
                    If Me._iMenuCustID = 2463 And Me.dbgPallets.Columns("Pallettype_SDesc").CellValue(Me.dbgPallets.Row) = "CYL" Then 'Nespresso Recycle
                        If Me.lstRegular.Items.Count > 0 Then
                            Me.BackColor = System.Drawing.Color.Red : System.Windows.Forms.Application.DoEvents()
                            MessageBox.Show("You are trying to ship Recycle devices with REFURBISHED/Repair devices. Not allowed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Return False
                        ElseIf Me.lstBER.Items.Count > 0 Then
                            Me.BackColor = System.Drawing.Color.Red : System.Windows.Forms.Application.DoEvents()
                            MessageBox.Show("You are trying to ship Recycle devices with BER/RUR devices. Not allowed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Return False
                        End If
                    ElseIf Me._iPalletShipType = 0 Then    'REGULAR
                        If Me.lstBER.Items.Count > 0 Then
                            Me.BackColor = System.Drawing.Color.Red : System.Windows.Forms.Application.DoEvents()
                            MessageBox.Show("You are trying to ship BER/RUR devices with REFURBISHED/Repair devices. Not allowed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Return False
                        ElseIf Me.lstRecycle.Items.Count > 0 Then
                            Me.BackColor = System.Drawing.Color.Red : System.Windows.Forms.Application.DoEvents()
                            MessageBox.Show("You are trying to ship REFURBISHED/Repair devices with Recycle devices. Not allowed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Return False
                        End If
                    ElseIf _iPalletShipType = 1 Then  'BER/Failed/Return
                        If Me.lstRegular.Items.Count > 0 Then
                            Me.BackColor = System.Drawing.Color.Red : System.Windows.Forms.Application.DoEvents()
                            MessageBox.Show("You are trying to ship BER/RUR devices with REFURBISHED/Repair devices. Not allowed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Return False
                        ElseIf Me.lstRecycle.Items.Count > 0 Then
                            Me.BackColor = System.Drawing.Color.Red : System.Windows.Forms.Application.DoEvents()
                            MessageBox.Show("You are trying to ship BER/RUR devices with Recycle devices. Not allowed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Return False
                        End If
                    ElseIf _iPalletShipType = 3 Then  'BER/Failed/Return
                        If Me.lstRegular.Items.Count > 0 Then
                            Me.BackColor = System.Drawing.Color.Red : System.Windows.Forms.Application.DoEvents()
                            MessageBox.Show("You are trying to ship Recycle devices with REFURBISHED/Repair devices. Not allowed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Return False
                        ElseIf Me.lstBER.Items.Count > 0 Then
                            Me.BackColor = System.Drawing.Color.Red : System.Windows.Forms.Application.DoEvents()
                            MessageBox.Show("You are trying to ship Recycle devices with BER/RUR devices. Not allowed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Return False
                        End If
                    Else
                        MessageBox.Show("Ship Type' not determined.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return False
                    End If
                    '***************************
                    'Discrepancies
                    '***************************
                    If Me.lstBERParts.Items.Count > 0 Then
                        Me.BackColor = System.Drawing.Color.Red : System.Windows.Forms.Application.DoEvents()
                        MessageBox.Show("Devices with parts existed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return False
                    ElseIf Me.lstWrongModel.Items.Count > 0 Then
                        Me.BackColor = System.Drawing.Color.Red : System.Windows.Forms.Application.DoEvents()
                        MessageBox.Show("Wrong model existed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return False
                    End If
                End If

                Return True
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************************************************

    End Class
End Namespace