Option Explicit On 

Imports PSS.Data.Buisness
Imports System.Text

Namespace Gui.TracFoneFulfillmentKit
    Public Class frmTFFK_Receiving
        Inherits System.Windows.Forms.Form
        'Dim dtPO As New DataTable()
        'Dim dtSN As New DataTable()

        Private _dtPO As DataTable
        Private _dtSN As DataTable
        Private _dtSelectedItemSN As DataTable

        Private _objTFFKRec As PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK_Receiving
        Private _iSpotCheckNum As Integer = 1
        Private _bCheckSpotPassed As Boolean = False
        Private _strSelectedItem As String = ""
        Private _iReceivedQty As Integer = 0

        ' Private _bIsPhone As Boolean = False
        Private _bIsRawMaterial_One_Item As Boolean = False

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._objTFFKRec = New PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK_Receiving()
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            Me._objTFFKRec = Nothing
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
        Friend WithEvents tdgData1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents txtPONumber As System.Windows.Forms.TextBox
        Friend WithEvents lblPO As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents lstSpotCheck As System.Windows.Forms.ListBox
        Friend WithEvents btnPost As System.Windows.Forms.Button
        Friend WithEvents btnClose As System.Windows.Forms.Button
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents btnSelectWO As System.Windows.Forms.Button
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents txtSN As System.Windows.Forms.TextBox
        Friend WithEvents Button1 As System.Windows.Forms.Button
        Friend WithEvents Button2 As System.Windows.Forms.Button
        Friend WithEvents Button3 As System.Windows.Forms.Button
        Friend WithEvents Button4 As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTFFK_Receiving))
            Me.tdgData1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.txtPONumber = New System.Windows.Forms.TextBox()
            Me.lblPO = New System.Windows.Forms.Label()
            Me.lstSpotCheck = New System.Windows.Forms.ListBox()
            Me.txtSN = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.btnPost = New System.Windows.Forms.Button()
            Me.btnClose = New System.Windows.Forms.Button()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.btnSelectWO = New System.Windows.Forms.Button()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Button1 = New System.Windows.Forms.Button()
            Me.Button2 = New System.Windows.Forms.Button()
            Me.Button3 = New System.Windows.Forms.Button()
            Me.Button4 = New System.Windows.Forms.Button()
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'tdgData1
            '
            Me.tdgData1.AllowUpdate = False
            Me.tdgData1.AlternatingRows = True
            Me.tdgData1.BackColor = System.Drawing.Color.GhostWhite
            Me.tdgData1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tdgData1.CaptionHeight = 17
            Me.tdgData1.FetchRowStyles = True
            Me.tdgData1.FilterBar = True
            Me.tdgData1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgData1.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgData1.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.tdgData1.Location = New System.Drawing.Point(8, 96)
            Me.tdgData1.Name = "tdgData1"
            Me.tdgData1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgData1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgData1.PreviewInfo.ZoomFactor = 75
            Me.tdgData1.RowHeight = 20
            Me.tdgData1.Size = New System.Drawing.Size(600, 152)
            Me.tdgData1.TabIndex = 142
            Me.tdgData1.Text = "C1TrueDBGrid1"
            Me.tdgData1.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Style9{}Normal{Font:Microsoft Sans Serif, 12pt;}Highlight" & _
            "Row{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddRow{}RecordSelector" & _
            "{AlignImage:Center;}Style13{}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1" & _
            ", 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{AlignHorz:Nea" & _
            "r;}Style11{}Style14{}Style15{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGr" & _
            "id.MergeView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaption" & _
            "Height=""17"" ColumnFooterHeight=""17"" FetchRowStyles=""True"" FilterBar=""True"" Marqu" & _
            "eeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Vertical" & _
            "ScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>150</Height><CaptionStyle pare" & _
            "nt=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowSt" & _
            "yle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style1" & _
            "3"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""S" & _
            "tyle12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent" & _
            "=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><Od" & _
            "dRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelec" & _
            "tor"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent" & _
            "=""Normal"" me=""Style1"" /><ClientRect>0, 0, 598, 150</ClientRect><BorderSide>0</Bo" & _
            "rderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Spli" & _
            "ts><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Headin" & _
            "g"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" " & _
            "/><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /" & _
            "><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /" & _
            "><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Sty" & _
            "le parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" " & _
            "/><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><" & _
            "horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRec" & _
            "SelWidth><ClientArea>0, 0, 598, 150</ClientArea><PrintPageHeaderStyle parent="""" " & _
            "me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'txtPONumber
            '
            Me.txtPONumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPONumber.Location = New System.Drawing.Point(48, 56)
            Me.txtPONumber.Name = "txtPONumber"
            Me.txtPONumber.Size = New System.Drawing.Size(168, 26)
            Me.txtPONumber.TabIndex = 0
            Me.txtPONumber.Text = ""
            '
            'lblPO
            '
            Me.lblPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPO.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.lblPO.Location = New System.Drawing.Point(0, 56)
            Me.lblPO.Name = "lblPO"
            Me.lblPO.Size = New System.Drawing.Size(40, 23)
            Me.lblPO.TabIndex = 145
            Me.lblPO.Text = "PO#: "
            '
            'lstSpotCheck
            '
            Me.lstSpotCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lstSpotCheck.ItemHeight = 20
            Me.lstSpotCheck.Location = New System.Drawing.Point(8, 332)
            Me.lstSpotCheck.Name = "lstSpotCheck"
            Me.lstSpotCheck.Size = New System.Drawing.Size(392, 84)
            Me.lstSpotCheck.TabIndex = 146
            '
            'txtSN
            '
            Me.txtSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtSN.Location = New System.Drawing.Point(8, 304)
            Me.txtSN.Name = "txtSN"
            Me.txtSN.Size = New System.Drawing.Size(392, 26)
            Me.txtSN.TabIndex = 147
            Me.txtSN.Text = ""
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(8, 280)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(152, 23)
            Me.Label1.TabIndex = 148
            Me.Label1.Text = "Scan (Spot Check)"
            '
            'btnPost
            '
            Me.btnPost.BackColor = System.Drawing.Color.Green
            Me.btnPost.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPost.Location = New System.Drawing.Point(440, 320)
            Me.btnPost.Name = "btnPost"
            Me.btnPost.Size = New System.Drawing.Size(168, 64)
            Me.btnPost.TabIndex = 149
            Me.btnPost.Text = "Post"
            '
            'btnClose
            '
            Me.btnClose.BackColor = System.Drawing.SystemColors.ActiveBorder
            Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClose.Location = New System.Drawing.Point(440, 392)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(168, 56)
            Me.btnClose.TabIndex = 150
            Me.btnClose.Text = "Close"
            Me.btnClose.Visible = False
            '
            'btnClear
            '
            Me.btnClear.BackColor = System.Drawing.Color.Green
            Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClear.ForeColor = System.Drawing.Color.White
            Me.btnClear.Location = New System.Drawing.Point(536, 56)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(64, 32)
            Me.btnClear.TabIndex = 155
            Me.btnClear.Text = "Clear"
            '
            'btnSelectWO
            '
            Me.btnSelectWO.BackColor = System.Drawing.Color.Green
            Me.btnSelectWO.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSelectWO.ForeColor = System.Drawing.Color.White
            Me.btnSelectWO.Location = New System.Drawing.Point(336, 56)
            Me.btnSelectWO.Name = "btnSelectWO"
            Me.btnSelectWO.Size = New System.Drawing.Size(192, 32)
            Me.btnSelectWO.TabIndex = 154
            Me.btnSelectWO.Text = "Select Item to Process"
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.Location = New System.Drawing.Point(0, 8)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(288, 32)
            Me.Label2.TabIndex = 156
            Me.Label2.Text = "Fulfillment Receiving"
            '
            'Button1
            '
            Me.Button1.Location = New System.Drawing.Point(384, 16)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(64, 24)
            Me.Button1.TabIndex = 157
            Me.Button1.Text = "Button1"
            Me.Button1.Visible = False
            '
            'Button2
            '
            Me.Button2.Location = New System.Drawing.Point(456, 16)
            Me.Button2.Name = "Button2"
            Me.Button2.Size = New System.Drawing.Size(64, 24)
            Me.Button2.TabIndex = 158
            Me.Button2.Text = "Button2"
            Me.Button2.Visible = False
            '
            'Button3
            '
            Me.Button3.Location = New System.Drawing.Point(544, 16)
            Me.Button3.Name = "Button3"
            Me.Button3.Size = New System.Drawing.Size(64, 24)
            Me.Button3.TabIndex = 159
            Me.Button3.Text = "Button3"
            Me.Button3.Visible = False
            '
            'Button4
            '
            Me.Button4.Location = New System.Drawing.Point(552, 280)
            Me.Button4.Name = "Button4"
            Me.Button4.Size = New System.Drawing.Size(64, 24)
            Me.Button4.TabIndex = 160
            Me.Button4.Text = "Button4"
            Me.Button4.Visible = False
            '
            'frmTFFK_Receiving
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(672, 494)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button4, Me.Button3, Me.Button2, Me.Button1, Me.Label2, Me.btnClear, Me.btnSelectWO, Me.btnClose, Me.btnPost, Me.Label1, Me.txtSN, Me.lstSpotCheck, Me.lblPO, Me.txtPONumber, Me.tdgData1})
            Me.ForeColor = System.Drawing.Color.Black
            Me.Name = "frmTFFK_Receiving"
            Me.Text = "Fulfillment Receiving"
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region


        Private Sub frmTFFK_Receiving_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Try
                PSS.Core.Highlight.SetHighLight(Me)
                ResetAllControls()
                Me.txtPONumber.SelectAll() : Me.txtPONumber.Focus()


                Exit Sub

                'dtSN.Columns.Add("SN", Type.GetType("System.String"))

                'dtPO.Columns.Add("PO #", Type.GetType("System.String"))
                'dtPO.Columns.Add("Item", Type.GetType("System.String"))
                'dtPO.Columns.Add("Order Qty", Type.GetType("System.Int64"))
                'dtPO.Columns.Add("Rec Qty", Type.GetType("System.Int64"))
                'dtPO.Columns.Add("Status", Type.GetType("System.String"))
                'dtPO.Columns("PO #").DefaultValue = 0

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmTFFK_Receiving_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Finally
                '    Generic.DisposeDT(dt)
            End Try
        End Sub

        Private Sub ResetAllControls()
            Try
                Me.txtPONumber.Enabled = True
                Me.btnSelectWO.Enabled = False
                Me.btnClear.Enabled = False
                Me.btnPost.Enabled = False
                Me.txtSN.Enabled = False
                Me.lstSpotCheck.Enabled = False
                Me.txtPONumber.Text = ""
                Me.txtSN.Text = ""
                Me.tdgData1.DataSource = Nothing
                Me.lstSpotCheck.Items.Clear()
                Me._bCheckSpotPassed = False
                Me._strSelectedItem = ""
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ResetAllControls", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub txtPONumber_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPONumber.KeyUp
            Try
                If e.KeyCode = Keys.Enter AndAlso Me.txtPONumber.Text.Trim.Length > 0 Then

                    Me.ProcessOrder()
                    'tdgData1.DataSource = LoadPO()
                    'tdgData1.Refresh()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtPONumber_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub ProcessOrder()
            Dim strOrderNo As String = ""
            'Dim arrLstOrderNo As New ArrayList()
            'Dim row, rowNew As DataRow

            Try
                strOrderNo = Me.txtPONumber.Text.Trim
                If strOrderNo.Trim.Length = 0 Then
                    MessageBox.Show("Please enter PO #.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtPONumber.SelectAll() : Me.txtPONumber.Focus()
                    Exit Sub
                End If

                Me._dtPO = Me._objTFFKRec.GetOpenOrder(strOrderNo)
                Me._dtSN = Me._objTFFKRec.GetOpenOrderDetails(strOrderNo)
                If Not Me._dtPO.Rows.Count > 0 Then
                    MessageBox.Show("Can't find PO '" & strOrderNo & "' in the system or it is closed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtPONumber.SelectAll() : Me.txtPONumber.Focus()
                ElseIf Not Me._dtSN.Rows.Count > 0 Then
                    MessageBox.Show("No item detail data, See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtPONumber.SelectAll() : Me.txtPONumber.Focus()
                Else

                    BindDataToPONumberGrid(Me._dtPO)
                    'If Me._dtPO.Rows.Count = 1 Then
                    '    Me.tdgData1.se()
                    'End If
                    Me.txtPONumber.ReadOnly = True
                    Me.btnSelectWO.Enabled = True
                    Me.tdgData1.Focus()

                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ProcessOrder", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub BindDataToPONumberGrid(ByVal dt As DataTable)
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn

            Try
                If dt.Rows.Count > 0 Then
                    With Me.tdgData1
                        .DataSource = dt.DefaultView

                        For Each dbgc In .Splits(0).DisplayColumns
                            dbgc.Locked = True
                            dbgc.AutoSize()
                        Next dbgc
                        '.Splits(0).DisplayColumns("SoDetailsID").Width = 0
                        '.Splits(0).DisplayColumns("Sku_ID").Width = 0
                        '.Splits(0).DisplayColumns("LineItemNumber").Width = 0
                        '.Splits(0).DisplayColumns("sku_type_decode_id").Width = 0
                        '.Splits(0).DisplayColumns("sku_insert_decode_id").Width = 0
                    End With
                Else
                    MessageBox.Show("No order product detail data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "BindDataToPONumberGrid", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub btnSelectWO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectWO.Click
            Me.ProcessSelectedWO()
            'testWO()
        End Sub

        Private Sub ProcessSelectedWO()
            Dim strSelectedItem As String = ""
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
            Dim iRow As Integer = 0
            Dim row As DataRow
            Dim foundRows() As DataRow

            Try
                Me.tdgData1.Enabled = True
                Me._bIsRawMaterial_One_Item = False


                With Me.tdgData1
                    For Each iRow In .SelectedRows 'must be one row
                        If Trim(.Columns("Status").CellValue(iRow)).ToString.ToUpper = "Closed".ToUpper Then
                            MessageBox.Show("Devices for this item '" & .Columns("Status").CellValue(iRow).ToString & "' has be received.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If
                        strSelectedItem = .Columns("item").CellText(iRow)

                        If .Columns("Class").CellText(iRow).ToString.Trim.ToUpper = "Raw Material".ToUpper _
                           AndAlso Convert.ToInt32(.Columns("EDI856_Qty").CellText(iRow).ToString) = 1 Then
                            Me._bIsRawMaterial_One_Item = True
                        End If
                        Exit For
                    Next
                End With


                If Not tdgData1.SelectedRows.Count = 1 Then
                    MessageBox.Show("Please select a row to process.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    strSelectedItem = strSelectedItem.Replace("'", "''")
                    foundRows = Me._dtSN.Select("[Item]='" & strSelectedItem & "'")

                    If foundRows.Length = 0 Then
                        MessageBox.Show("Failed to get item detail data for item '" & strSelectedItem & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Me._dtSelectedItemSN = Me._dtSN.Clone
                        For Each row In foundRows
                            Me._dtSelectedItemSN.ImportRow(row)
                        Next

                        If Not Me._bIsRawMaterial_One_Item Then
                            Me._strSelectedItem = strSelectedItem
                            Me.tdgData1.Enabled = False
                            Me.btnSelectWO.Enabled = False
                            Me.btnClear.Enabled = True
                            Me._bCheckSpotPassed = True
                            Me.txtSN.Enabled = True
                            Me.txtSN.SelectAll() : Me.txtSN.Focus()
                        Else
                            Me._strSelectedItem = strSelectedItem
                            Me.tdgData1.Enabled = False
                            Me.btnSelectWO.Enabled = False
                            Me.btnClear.Enabled = True
                            Me._bCheckSpotPassed = False
                            Me.txtSN.Enabled = False
                            Me.btnPost.Enabled = True : Me.btnPost.Focus()
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ProcessSelectedWO", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub


        'Private Sub testWO()
        '    Dim po As String = ""
        '    Dim item As String = ""
        '    Dim drSN1 As DataRow = dtSN.NewRow
        '    Dim drSN2 As DataRow = dtSN.NewRow
        '    Dim drSN3 As DataRow = dtSN.NewRow
        '    Dim drSN4 As DataRow = dtSN.NewRow
        '    Dim drSN5 As DataRow = dtSN.NewRow
        '    Dim drSN6 As DataRow = dtSN.NewRow
        '    Dim drSN7 As DataRow = dtSN.NewRow
        '    Dim drSN8 As DataRow = dtSN.NewRow

        '    po = tdgData1.Columns("PO #").Value.ToString

        '    item = tdgData1.Columns("Item").Value.ToString

        '    If tdgData1.SelectedRows.Count <= 0 Then
        '        MessageBox.Show("A row must be selected to be processed. Please select a row to continue.")
        '    Else
        '        If po = "70123457" And item = "TFSAS327VCPAP7" Then
        '            drSN1("SN") = "354308085095759"
        '            dtSN.Rows.Add(drSN1)

        '            drSN2("SN") = "354308083382811"
        '            dtSN.Rows.Add(drSN2)

        '            drSN3("SN") = "354308085684248"
        '            dtSN.Rows.Add(drSN3)

        '            drSN4("SN") = "354308084222321"
        '            dtSN.Rows.Add(drSN4)

        '            drSN5("SN") = "354308084797868"
        '            dtSN.Rows.Add(drSN5)

        '            drSN6("SN") = "354308085159308"
        '            dtSN.Rows.Add(drSN6)

        '            drSN7("SN") = "354308084798676"
        '            dtSN.Rows.Add(drSN7)

        '            drSN8("SN") = "354308085232162"
        '            dtSN.Rows.Add(drSN8)

        '            txtPONumber.Enabled = False
        '            tdgData1.Enabled = False
        '            txtSN.Select()

        '        ElseIf po = "70123458" And item = "TFSAS727VCPAP6" Then
        '            drSN1("SN") = "354727085866457"
        '            dtSN.Rows.Add(drSN1)

        '            drSN2("SN") = "354727084600832"
        '            dtSN.Rows.Add(drSN2)

        '            drSN3("SN") = "354727085974533"
        '            dtSN.Rows.Add(drSN3)

        '            drSN4("SN") = "354727081705154"
        '            dtSN.Rows.Add(drSN4)

        '            drSN5("SN") = "354727085768554"
        '            dtSN.Rows.Add(drSN5)

        '            drSN6("SN") = "354727085698454"
        '            dtSN.Rows.Add(drSN6)

        '            txtPONumber.Enabled = False
        '            tdgData1.Enabled = False
        '            txtSN.Select()

        '        Else
        '            MessageBox.Show("Cannot find the PO # entered. Please check the PO # and try again.")
        '        End If
        '    End If
        'End Sub

        Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
            Me.ClearRestart()
        End Sub

        Private Sub ClearRestart()
            Try
                Me.txtPONumber.Text = ""
                Me.txtSN.Text = ""
                Me.tdgData1.DataSource = Nothing
                Me._bCheckSpotPassed = True
                Me._dtPO.Rows.Clear()
                Me._dtSN.Rows.Clear()
                Me.txtSN.Enabled = False
                Me._dtSelectedItemSN.Rows.Clear()
                Me._strSelectedItem = ""
                Me.lstSpotCheck.Items.Clear()
                Me.txtPONumber.Enabled = True
                Me.tdgData1.Enabled = True
                Me.btnPost.Enabled = False
                Me.txtPONumber.Enabled = True
                Me.txtPONumber.ReadOnly = False
                Me.txtPONumber.SelectAll()
                Me.txtPONumber.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ClearRestart", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub
        Private Sub txtSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyUp
            Dim row As DataRow

            If e.KeyCode = Keys.Enter AndAlso Me.txtSN.Text.Trim.Length > 0 Then
                Me.ProcessSpotCheck()

                'For Each row In dtSN.Rows
                '    If row("SN") = txtSN.Text Then
                '        If lstSpotCheck.Items.Contains(txtSN.Text) = True Then
                '            MessageBox.Show("SN already exists in box.")
                '        Else
                '            Me.lstSpotCheck.Items.Add(txtSN.Text)
                '            txtSN.Text = ""
                '        End If
                '    End If
                'Next
                'If txtSN.Text.Length > 0 Then
                '    MessageBox.Show("SN does not exist in PO #: " & txtPONumber.Text & ". Please check the SN and try again.")
                '    txtSN.Text = ""
                'End If
            End If
        End Sub

        Private Sub ProcessSpotCheck()
            Dim row As DataRow
            Dim strSN As String = ""
            ' Dim bSN_Failled As Boolean = False
            Dim bIsFound As Boolean = False

            Try
                If Not Me._dtSelectedItemSN.Rows.Count > 0 Then
                    MessageBox.Show("No data for the selected item", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                strSN = Me.txtSN.Text.Trim
                Me.btnPost.Enabled = False
                bIsFound = False

                If strSN.Length > 0 AndAlso Me._bCheckSpotPassed = True Then
                    For Each row In Me._dtSelectedItemSN.Rows
                        If Trim(row("SN")) = strSN Then
                            If lstSpotCheck.Items.Contains(strSN) = True Then
                                MessageBox.Show("SN already scanned and checked.")
                                bIsFound = True : Exit For
                            Else
                                Me.lstSpotCheck.Items.Add(strSN)
                                txtSN.Text = "" : Me.txtSN.SelectAll() : Me.txtSN.Focus()
                                bIsFound = True : Exit For
                            End If
                        End If
                    Next
                    If bIsFound = False Then
                        MessageBox.Show("Invalid SN. CheckSpot failed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me._bCheckSpotPassed = False
                    End If

                    If Me.lstSpotCheck.Items.Count >= Me._iSpotCheckNum AndAlso Me._bCheckSpotPassed = True Then   ' AndAlso bSN_Failled = False Then
                        Me.btnPost.Enabled = True : Me.btnPost.Focus()
                    End If

                ElseIf strSN.Length > 0 AndAlso Me._bCheckSpotPassed = False Then
                    MessageBox.Show("At least one SN failed in spotcheck. Stop!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    MessageBox.Show("Please enter/scan a SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ProcessSpotCheck", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub


        Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPost.Click
            'Dim row As DataRow
            Dim rIdx As Integer = 0
            Me.btnClose.Visible = False
            If lstSpotCheck.Items.Count >= Me._iSpotCheckNum OrElse Me._bIsRawMaterial_One_Item Then
                Dim frmReceiving As New frmTFFK_Receiving_Finish(Me.txtPONumber.Text, Me._strSelectedItem, Me._dtSelectedItemSN, Me._bIsRawMaterial_One_Item)

                'Upon posting we want to popup the finish form to confirm the skid split.
                frmReceiving.ShowDialog(Me)


                '' Show testDialog as a modal dialog and determine if DialogResult = OK.
                'If frmReceiving.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                '    ' Read the contents of testDialog's TextBox.
                '    MessageBox.Show("OK")
                'Else
                '    MessageBox.Show("Cancelled")
                'End If
                ' Show testDialog as a modal dialog and determine if DialogResult = OK.
                If frmReceiving._bReceived AndAlso frmReceiving._iRecvWR_ID > 0 AndAlso frmReceiving._iReceivedQty > 0 Then
                    ' Read the contents of testDialog's TextBox.
                    ' MessageBox.Show("OK")
                    rIdx = Me.tdgData1.Row
                    Me.tdgData1.Columns("Rec_Qty").Text = Me._dtSelectedItemSN.Rows.Count
                    Me.tdgData1.Columns("Recv_WR_ID").Text = frmReceiving._iRecvWR_ID
                    Me.tdgData1.Columns("Status").Text = "Closed" 'closed for this item, the row selected to receive

                    'Close the wholeorder as needed
                    'If Me._dtPO.Rows.Count = 1 Then
                    '    Me.tdgData1.Enabled = True
                    '    'Close the whole order
                    'ElseIf Me._dtPO.Rows.Count > 1 Then
                    '    Dim iRow As Integer = 0
                    '    For iRow = 0 To Me.tdgData1.RowCount - 1
                    '        Me.tdgData1.Columns("Status").CellValue(iRow).ToString()
                    '        iRow += 1
                    '    Next
                    'End If

                    Dim iRow As Integer
                    For iRow = 0 To Me.tdgData1.RowCount - 1 '1 selected row
                        If Not Me.tdgData1.Columns("Status").CellValue(iRow).ToString.ToUpper = "Closed".ToUpper Then
                            Me._objTFFKRec.CloseWorkorder(Convert.ToInt32(Me.tdgData1.Columns("WO_ID").CellValue(0)), frmReceiving._iReceivedQty)
                            Me.tdgData1.Enabled = True
                            Me.ClearRestart()
                            Exit For
                        Else ' under or over received
                            Me._iReceivedQty = frmReceiving._iReceivedQty
                            Me.btnClose.Visible = True : Me.btnClose.Enabled = True
                            If Me.btnPost.Enabled = True Then Me.btnPost.Enabled = False
                            MessageBox.Show("Receiving partial box. Please may close it manually by clicking button Close", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.btnClose.Focus()
                            Exit For
                        End If
                    Next


                ElseIf frmReceiving._bReceived AndAlso Not frmReceiving._iRecvWR_ID > 0 Then
                    MessageBox.Show("Receiving exception happens. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    MessageBox.Show("Cancelled")
                End If

                frmReceiving.Dispose()
            Else
                MessageBox.Show("Please scan at least one device to verify the correct PO #.")
            End If
        End Sub


        'Public Function LoadPO() As DataTable
        '    Dim drPO As DataRow = dtPO.NewRow

        '    If txtPONumber.Text = "70123457" Then
        '        drPO("PO #") = "70123457"
        '        drPO("Item") = "TFSAS327VCPAP7"
        '        drPO("Order Qty") = 1100
        '        drPO("Rec Qty") = 8
        '        drPO("Status") = "Open"
        '        dtPO.Rows.Add(drPO)
        '    ElseIf txtPONumber.Text = "70123458" Then
        '        drPO("PO #") = "70123458"
        '        drPO("Item") = "TFSAS727VCPAP6"
        '        drPO("Order Qty") = 1200
        '        drPO("Rec Qty") = 6
        '        drPO("Status") = "Open"
        '        dtPO.Rows.Add(drPO)
        '    Else
        '        MessageBox.Show("Cannot find the PO # entered. Please check the PO # and try again.")
        '    End If

        '    Return dtPO

        'End Function

        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
            Dim dt As DataTable
            dt = Me._objTFFKRec.getTestData
            Me.tdgData1.DataSource = dt
        End Sub

        Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

            MessageBox.Show(Me._objTFFKRec.InertTestData)

        End Sub
        Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

            MessageBox.Show(Me._objTFFKRec.UpdateTestData)
        End Sub

        Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
            'MessageBox.Show(Me._objTFFKRec.InertTestDataGetLastInsertKey)
            'MessageBox.Show(Me._objTFFKRec.InertTestDataGetLastInsertKey2)
            'MessageBox.Show(Me._objTFFKRec.InertTestDataGetLastInsertKey3)
        End Sub


        Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Try
                Dim iRow As Integer
                For iRow = 0 To Me.tdgData1.RowCount - 1 '1 selected row
                    Me._objTFFKRec.CloseWorkorder(Convert.ToInt32(Me.tdgData1.Columns("WO_ID").CellValue(0)), Me._iReceivedQty)
                    Me.tdgData1.Enabled = True
                    Me.btnClose.Visible = False
                    Me.ClearRestart()
                Next
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnClose_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub
    End Class
End Namespace