Option Explicit On 

Imports PSS.Data.Buisness
Imports System.Text
Imports System.Data

Namespace Gui.TracFoneFulfillmentKit
    Public Class frmTFFK_Receiving_Finish
        Inherits System.Windows.Forms.Form

        Private _dtSelectedItemSNs As DataTable
        Private _dtSkid As DataTable
        Private _bRawMaterial_One_Item As Boolean = False

        Private _strSelectedPO As String = ""
        Private _strSelectedItem As String = ""
        Private _iMaxBoxNum As Integer = PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK._iWHRecvMaxQtyPerBox
        Public _bReceived As Boolean = False
        Public _iRecvWR_ID As Integer = 0
        Public _iReceivedQty As Integer = 0

        Private _objTFFKRec As PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK_Receiving
        Private _UserID As Integer = PSS.Core.Global.ApplicationUser.IDuser

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strSelectedPO As String, ByVal strSelectedItem As String, _
                       ByVal dtSelectedItemSNs As DataTable, ByVal bRawMaterial_One_Item As Boolean)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._dtSelectedItemSNs = dtSelectedItemSNs
            Me._strSelectedPO = strSelectedPO
            Me._strSelectedItem = strSelectedItem
            Me._bRawMaterial_One_Item = bRawMaterial_One_Item
            Me._objTFFKRec = New PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK_Receiving()

        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                Try
                    Me._objTFFKRec = Nothing
                    Me._dtSelectedItemSNs = Nothing
                    Me._strSelectedPO = ""
                    Me._strSelectedItem = ""
                Catch ex As Exception
                End Try

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
        Friend WithEvents lblPO As System.Windows.Forms.Label
        Friend WithEvents lblItem As System.Windows.Forms.Label
        Friend WithEvents lblTotalQty As System.Windows.Forms.Label
        Friend WithEvents lblOrderQty As System.Windows.Forms.Label
        Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents btnClose As System.Windows.Forms.Button
        Friend WithEvents btnReceiveSNs As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTFFK_Receiving_Finish))
            Me.tdgData1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.lblPO = New System.Windows.Forms.Label()
            Me.lblItem = New System.Windows.Forms.Label()
            Me.lblTotalQty = New System.Windows.Forms.Label()
            Me.lblOrderQty = New System.Windows.Forms.Label()
            Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.btnClose = New System.Windows.Forms.Button()
            Me.btnReceiveSNs = New System.Windows.Forms.Button()
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'tdgData1
            '
            Me.tdgData1.AllowArrows = False
            Me.tdgData1.AllowColMove = False
            Me.tdgData1.AllowColSelect = False
            Me.tdgData1.AllowFilter = False
            Me.tdgData1.AllowSort = False
            Me.tdgData1.AllowUpdate = False
            Me.tdgData1.AlternatingRows = True
            Me.tdgData1.BackColor = System.Drawing.Color.GhostWhite
            Me.tdgData1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tdgData1.CaptionHeight = 17
            Me.tdgData1.FetchRowStyles = True
            Me.tdgData1.FilterBar = True
            Me.tdgData1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgData1.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgData1.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.tdgData1.Location = New System.Drawing.Point(8, 64)
            Me.tdgData1.Name = "tdgData1"
            Me.tdgData1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgData1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgData1.PreviewInfo.ZoomFactor = 75
            Me.tdgData1.RowHeight = 20
            Me.tdgData1.Size = New System.Drawing.Size(296, 184)
            Me.tdgData1.TabIndex = 143
            Me.tdgData1.Text = "C1TrueDBGrid1"
            Me.tdgData1.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Style9{}Normal{Font:Tahoma, 12pt;}HighlightRow{ForeColor:" & _
            "HighlightText;BackColor:Highlight;}Style12{}OddRow{}RecordSelector{AlignImage:Ce" & _
            "nter;}Style13{}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;Fore" & _
            "Color:ControlText;BackColor:Control;}Style8{}Style10{AlignHorz:Near;}Style11{}St" & _
            "yle14{}Style15{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView A" & _
            "llowColMove=""False"" AllowColSelect=""False"" Name="""" AlternatingRowStyle=""True"" Ca" & _
            "ptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyles" & _
            "=""True"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17" & _
            """ DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>" & _
            "182</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Ed" & _
            "itor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle" & _
            " parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><G" & _
            "roupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style" & _
            "2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle paren" & _
            "t=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSel" & _
            "ectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selecte" & _
            "d"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 294, 182" & _
            "</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win" & _
            ".C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><St" & _
            "yle parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style " & _
            "parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style p" & _
            "arent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style paren" & _
            "t=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style pare" & _
            "nt=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style p" & _
            "arent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyl" & _
            "es><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Def" & _
            "aultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 294, 182</ClientArea><P" & _
            "rintPageHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=" & _
            """Style15"" /></Blob>"
            '
            'lblPO
            '
            Me.lblPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPO.ForeColor = System.Drawing.Color.DimGray
            Me.lblPO.Location = New System.Drawing.Point(16, 8)
            Me.lblPO.Name = "lblPO"
            Me.lblPO.Size = New System.Drawing.Size(136, 24)
            Me.lblPO.TabIndex = 146
            '
            'lblItem
            '
            Me.lblItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblItem.ForeColor = System.Drawing.Color.DimGray
            Me.lblItem.Location = New System.Drawing.Point(16, 32)
            Me.lblItem.Name = "lblItem"
            Me.lblItem.Size = New System.Drawing.Size(256, 24)
            Me.lblItem.TabIndex = 147
            '
            'lblTotalQty
            '
            Me.lblTotalQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTotalQty.ForeColor = System.Drawing.Color.White
            Me.lblTotalQty.Location = New System.Drawing.Point(112, 272)
            Me.lblTotalQty.Name = "lblTotalQty"
            Me.lblTotalQty.Size = New System.Drawing.Size(64, 16)
            Me.lblTotalQty.TabIndex = 148
            Me.lblTotalQty.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            Me.ToolTip1.SetToolTip(Me.lblTotalQty, "Total Skid Qty")
            '
            'lblOrderQty
            '
            Me.lblOrderQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblOrderQty.ForeColor = System.Drawing.Color.White
            Me.lblOrderQty.Location = New System.Drawing.Point(112, 248)
            Me.lblOrderQty.Name = "lblOrderQty"
            Me.lblOrderQty.Size = New System.Drawing.Size(64, 16)
            Me.lblOrderQty.TabIndex = 149
            Me.ToolTip1.SetToolTip(Me.lblOrderQty, "Order Item Qty")
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.Location = New System.Drawing.Point(8, 248)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(104, 24)
            Me.Label1.TabIndex = 150
            Me.Label1.Text = "Order Item Qty:"
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.Location = New System.Drawing.Point(8, 272)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(104, 24)
            Me.Label2.TabIndex = 151
            Me.Label2.Text = "Skid Total Qty:"
            '
            'btnClose
            '
            Me.btnClose.BackColor = System.Drawing.SystemColors.ActiveBorder
            Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClose.Location = New System.Drawing.Point(184, 320)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(112, 48)
            Me.btnClose.TabIndex = 145
            Me.btnClose.Text = "Close"
            '
            'btnReceiveSNs
            '
            Me.btnReceiveSNs.BackColor = System.Drawing.SystemColors.ActiveBorder
            Me.btnReceiveSNs.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReceiveSNs.Location = New System.Drawing.Point(184, 264)
            Me.btnReceiveSNs.Name = "btnReceiveSNs"
            Me.btnReceiveSNs.Size = New System.Drawing.Size(112, 48)
            Me.btnReceiveSNs.TabIndex = 144
            Me.btnReceiveSNs.Text = "Print Label"
            '
            'frmTFFK_Receiving_Finish
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(8, 19)
            Me.BackColor = System.Drawing.Color.LightSteelBlue
            Me.ClientSize = New System.Drawing.Size(320, 398)
            Me.ControlBox = False
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label2, Me.Label1, Me.lblOrderQty, Me.lblTotalQty, Me.lblItem, Me.lblPO, Me.btnClose, Me.btnReceiveSNs, Me.tdgData1})
            Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.MaximizeBox = False
            Me.Name = "frmTFFK_Receiving_Finish"
            Me.Text = "Print Pallet Label"
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmTFFK_Receiving_Finish_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                Me.CenterToParent()
                PSS.Core.Highlight.SetHighLight(Me)
                Me.tdgData1.FilterBar = False

                Me.lblItem.Text = Me._strSelectedItem
                Me.lblPO.Text = Me._strSelectedPO

                If Me._bRawMaterial_One_Item Then
                    Me.lblOrderQty.Text = Convert.ToInt32(Me._dtSelectedItemSNs.Rows(0).Item("Order_Qty"))
                Else
                    Me.lblOrderQty.Text = Me._dtSelectedItemSNs.Rows.Count
                End If

                Me.SetBeginSkidData()
                Me.BindDataToSkidGrid(Me._dtSkid)

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmTFFK_Receiving_Finish_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Finally
                '    Generic.DisposeDT(dt)
            End Try
        End Sub

        Private Sub BindDataToSkidGrid(ByVal dt As DataTable)
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn

            Try
                If dt.Rows.Count > 0 Then
                    With Me.tdgData1
                        .DataSource = dt.DefaultView

                        For Each dbgc In .Splits(0).DisplayColumns
                            dbgc.Locked = True
                            dbgc.AutoSize()
                        Next dbgc
                        .Splits(0).DisplayColumns("Skid").Width = 60
                        .Splits(0).DisplayColumns("Qty").Width = 120
                        .Splits(0).DisplayColumns("Qty").Button = True
                        .Splits(0).DisplayColumns("Qty").ButtonAlways = True
                        .Splits(0).DisplayColumns("Item").Width = 0
                        .Splits(0).DisplayColumns("OrderNo").Width = 0
                        .Splits(0).DisplayColumns("BoxName").Width = 0
                        .Splits(0).DisplayColumns("wb_ID").Width = 0
                    End With
                    Me.lblTotalQty.Text = dt.Compute("Sum(Qty)", "")
                Else
                    MessageBox.Show("No skid data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "BindDataToSkidGrid", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub SetBeginSkidData()
            Dim iBoxNum As Integer = 0
            Dim iIntNum As Integer = 0
            Dim iModNum As Integer = 0
            Dim rowNew As DataRow
            Dim i As Integer = 0

            Try
                Me._dtSkid = Me._objTFFKRec.GetOrderItemsSkidTableDef
                Me._dtSkid.Rows.Clear()

                If Me._bRawMaterial_One_Item Then
                    rowNew = Me._dtSkid.NewRow
                    rowNew("Skid") = 1
                    rowNew("Qty") = Convert.ToInt32(Me._dtSelectedItemSNs.Rows(0).Item("Order_Qty"))
                    rowNew("Item") = Me._strSelectedItem
                    rowNew("OrderNo") = Me._strSelectedPO
                    Me._dtSkid.Rows.Add(rowNew)

                    Exit Sub
                End If

                iIntNum = Me._dtSelectedItemSNs.Rows.Count \ Me._iMaxBoxNum
                iModNum = Me._dtSelectedItemSNs.Rows.Count Mod Me._iMaxBoxNum
                If iIntNum = 0 AndAlso iModNum > 0 Then '1 partial box
                    rowNew = Me._dtSkid.NewRow
                    rowNew("Skid") = 1
                    rowNew("Qty") = iModNum
                    rowNew("Item") = Me._strSelectedItem
                    rowNew("OrderNo") = Me._strSelectedPO
                    Me._dtSkid.Rows.Add(rowNew)
                ElseIf iIntNum > 0 AndAlso iModNum = 0 Then '>1 full box
                    For i = 1 To iIntNum
                        rowNew = Me._dtSkid.NewRow
                        rowNew("Skid") = i
                        rowNew("Qty") = Me._iMaxBoxNum
                        rowNew("Item") = Me._strSelectedItem
                        rowNew("OrderNo") = Me._strSelectedPO
                        Me._dtSkid.Rows.Add(rowNew)
                    Next
                ElseIf iIntNum > 0 AndAlso iModNum > 0 Then '>1 full box plus a partial box
                    For i = 1 To iIntNum
                        rowNew = Me._dtSkid.NewRow
                        rowNew("Skid") = i
                        rowNew("Qty") = Me._iMaxBoxNum
                        rowNew("Item") = Me._strSelectedItem
                        rowNew("OrderNo") = Me._strSelectedPO
                        Me._dtSkid.Rows.Add(rowNew)
                    Next
                    rowNew = Me._dtSkid.NewRow
                    rowNew("Skid") = iIntNum + 1
                    rowNew("Qty") = iModNum
                    rowNew("Item") = Me._strSelectedItem
                    rowNew("OrderNo") = Me._strSelectedPO
                    Me._dtSkid.Rows.Add(rowNew)
                Else
                    MessageBox.Show("Can't create skid box(s).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "SetBeginSkidData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub tdgData1_ButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdgData1.ButtonClick
            Dim rIdx As Integer = 0
            Dim cIdx As Integer = 0
            Dim iQty As Integer = 0
            Dim strQty As String = ""
            Dim iSkid As Integer = 0
            Dim row As DataRow

            Try
                rIdx = Me.tdgData1.Row : cIdx = e.ColIndex
                iQty = Me.tdgData1.Columns("qty").CellText(rIdx)
                iSkid = Me.tdgData1.Columns("Skid").CellText(rIdx)

                strQty = InputBox("Enter a number:", "Enter number", iQty.ToString)
                If IsNumeric(strQty) Then
                    iQty = Convert.ToInt16(strQty)

                    If Me._bRawMaterial_One_Item Then
                        For Each row In Me._dtSkid.Rows
                            If row("Skid") = iSkid Then
                                row.BeginEdit()
                                row("Qty") = iQty
                                row.AcceptChanges()
                                Exit For
                            End If
                        Next
                        Me.BindDataToSkidGrid(Me._dtSkid)
                    Else
                        If iQty > 0 AndAlso iQty <= Me._iMaxBoxNum Then
                            For Each row In Me._dtSkid.Rows
                                If row("Skid") = iSkid Then
                                    row.BeginEdit()
                                    row("Qty") = iQty
                                    row.AcceptChanges()
                                    Exit For
                                End If
                            Next
                            Me.BindDataToSkidGrid(Me._dtSkid)
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "tdgData1_ButtonClick", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnReceiveSNs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReceiveSNs.Click
            Dim objTFMisc As Data.Buisness.TracFone.clsMisc
            Dim row, row2 As DataRow
            Dim strPrefixBoxName As String = "TR"
            Dim strBoxStage As String = "FK Received"
            Dim iFuncrep As Integer = 10
            Dim iOrder_ID As Integer = 0
            Dim iModel_ID As Integer = 0
            Dim dtBox As DataTable
            Dim strSNs As String = ""
            Dim strWB_IDs As String = ""
            Dim strBoxName As String = ""
            Dim strModel_Desc As String = ""
            Dim strErrMsg As String = ""

            Dim iQty As Integer = 0
            Dim strTFPoNo As String = "" '"436542-18"
            Dim strMfgPoNo As String = "" ' "768978"
            Dim strReceiptDate = Format(Now, "MM/dd/yyyy")
            Dim strReceiptDateTime_mySQL = Format(Now, "yyyy-MM-dd HH:mm:ss")

            ' Dim strReceiptNo As String = "1234567699"
            Dim iCopyNumber As Integer = PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK._iWHRecvBoxLabelCopiesNumber
            Try
                If Me.lblOrderQty.Text = Me.lblTotalQty.Text OrElse Me._bRawMaterial_One_Item Then

                    objTFMisc = New Data.Buisness.TracFone.clsMisc()
                    Try
                        iModel_ID = Convert.ToInt32(Me._dtSelectedItemSNs.Rows(0).Item("Model_ID"))
                        iOrder_ID = Convert.ToInt32(Me._dtSelectedItemSNs.Rows(0).Item("Order_ID"))
                    Catch ex As Exception
                    End Try

                    'Create box for each skid and print box label
                    For Each row In Me._dtSkid.Rows
                        iQty = row("Qty")
                        dtBox = Me._objTFFKRec.CreateWHRecvBoxID(iModel_ID, iOrder_ID, iFuncrep, iQty, strPrefixBoxName, strBoxStage)
                        If dtBox.Rows.Count = 1 Then
                            'strBoxName = dtBox.Rows(0).Item("BoxID")
                            'strModel_Desc = Me._strSelectedItem
                            ''Print label
                            'Me._objTFFKRec.PrintWarehouseFKRecBoxID(strBoxName, strModel_Desc, iQty, strTFPoNo, strMfgPoNo, strReceiptDate, strReceiptNo, iCopyNumber)

                            If strWB_IDs.Trim.Length = 0 Then
                                strWB_IDs = dtBox.Rows(0).Item("wb_ID").ToString
                            Else
                                strWB_IDs &= "," & dtBox.Rows(0).Item("wb_ID").ToString
                            End If
                        Else
                            MessageBox.Show("Invalid box data. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        End If
                    Next
                    dtBox = Me._objTFFKRec.GetSkidBoxes(strWB_IDs)
                    If Not dtBox.Rows.Count = Me._dtSkid.Rows.Count Then
                        MessageBox.Show("Incorrect skid-box data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If

                    'Receive devices and Print labels
                    strErrMsg = ""
                    If Me._objTFFKRec.ReceiveDevices(Me._dtSelectedItemSNs, Me._strSelectedPO, Convert.ToInt32(Me._dtSelectedItemSNs.Rows(0).Item("WO_ID")), _
                                                     Convert.ToInt32(Me._dtSelectedItemSNs.Rows(0).Item("Loc_ID")), iModel_ID, Me._UserID, _
                                                     strWB_IDs, strReceiptDateTime_mySQL, Me._iRecvWR_ID, strErrMsg) = True Then

                        'Print labels
                        strTFPoNo = Me.lblPO.Text : strMfgPoNo = ""

                        For Each row In dtBox.Rows
                            iQty = 0 : strBoxName = ""
                            strBoxName = Trim(row("BoxID")).ToString
                            Try
                                iQty = Convert.ToInt32(row("Qty"))
                            Catch ex As Exception
                            End Try
                            strModel_Desc = Me._strSelectedItem
                            Me._objTFFKRec.PrintWarehouseFKRecBoxID(strBoxName, strModel_Desc, iQty, strTFPoNo, strMfgPoNo, strReceiptDate, Me._iRecvWR_ID.ToString, iCopyNumber)
                        Next

                        Me._bReceived = True
                        Me._iReceivedQty = Convert.ToInt32(Me.lblTotalQty.Text)
                        objTFMisc = Nothing
                    Else
                        MessageBox.Show("Failed to receive. " & Environment.NewLine & strErrMsg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnReceiveSNs_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Try
                If Me._bReceived Then
                    Me.Close()
                Else
                    Dim result As DialogResult = MessageBox.Show("Do you want to close without receiving?", _
                                               "Warning", _
                                               MessageBoxButtons.YesNo, _
                                               MessageBoxIcon.Question)
                    If result = DialogResult.Yes Then
                        Me.Close()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnClose_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class
End Namespace