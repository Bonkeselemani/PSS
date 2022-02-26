Option Explicit On 

Imports PSS.Data.Buisness
Imports System.Text

Namespace Gui.TracFoneFulfillmentKit
    Public Class frmTFFK_Pick
        Inherits System.Windows.Forms.Form

        Private _dtPickData As DataTable
        Private _objPickPackShip As PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK_PickPackShip
        Private _objTFFK As PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK
        'Private _iSelectedRecID As Integer = 0
        Private _strPickID As String = ""
        Private _strOrderNo As String = ""
        ' Private _iSelectedSoHeaderID As Integer = 0
        Private _UserID As Integer = PSS.Core.Global.ApplicationUser.IDuser
        Private _strEmpID As String = PSS.Core.Global.ApplicationUser.NumberEmp
        Private _strUser As String = PSS.Core.Global.ApplicationUser.User

        Private _strSoHeaderIDs As String = ""
        Private _iHowManyOrders As Integer = 0
        Private _iShipCarrier_ID As Integer = 0

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._objPickPackShip = New PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK_PickPackShip()
            Me._objTFFK = New PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK()
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                Try
                    Me._objPickPackShip = Nothing
                    Me._objTFFK = Nothing
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
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents lblPO As System.Windows.Forms.Label
        Friend WithEvents txtPONumber As System.Windows.Forms.TextBox
        Friend WithEvents tdgData1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents btnGo As System.Windows.Forms.Button
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents btnRefresh As System.Windows.Forms.Button
        Friend WithEvents txtUser As System.Windows.Forms.TextBox
        Friend WithEvents txtEmpID As System.Windows.Forms.TextBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTFFK_Pick))
            Me.Label2 = New System.Windows.Forms.Label()
            Me.btnGo = New System.Windows.Forms.Button()
            Me.lblPO = New System.Windows.Forms.Label()
            Me.txtPONumber = New System.Windows.Forms.TextBox()
            Me.tdgData1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.TextBox1 = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtUser = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.txtEmpID = New System.Windows.Forms.TextBox()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.btnRefresh = New System.Windows.Forms.Button()
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'btnGo
            '
            Me.btnGo.BackColor = System.Drawing.Color.Green
            Me.btnGo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnGo.ForeColor = System.Drawing.Color.White
            Me.btnGo.Location = New System.Drawing.Point(656, 104)
            Me.btnGo.Name = "btnGo"
            Me.btnGo.Size = New System.Drawing.Size(128, 64)
            Me.btnGo.TabIndex = 161
            Me.btnGo.Text = "Print"
            '
            'lblPO
            '
            Me.lblPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPO.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.lblPO.Location = New System.Drawing.Point(8, 32)
            Me.lblPO.Name = "lblPO"
            Me.lblPO.Size = New System.Drawing.Size(112, 23)
            Me.lblPO.TabIndex = 159
            Me.lblPO.Text = "Printer Station"
            '
            'txtPONumber
            '
            Me.txtPONumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPONumber.Location = New System.Drawing.Point(126, 32)
            Me.txtPONumber.Name = "txtPONumber"
            Me.txtPONumber.Size = New System.Drawing.Size(168, 26)
            Me.txtPONumber.TabIndex = 157
            Me.txtPONumber.Text = "P1"
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
            Me.tdgData1.Location = New System.Drawing.Point(0, 168)
            Me.tdgData1.Name = "tdgData1"
            Me.tdgData1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgData1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgData1.PreviewInfo.ZoomFactor = 75
            Me.tdgData1.RowHeight = 20
            Me.tdgData1.Size = New System.Drawing.Size(784, 352)
            Me.tdgData1.TabIndex = 158
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
            "ScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>350</Height><CaptionStyle pare" & _
            "nt=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowSt" & _
            "yle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style1" & _
            "3"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""S" & _
            "tyle12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent" & _
            "=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><Od" & _
            "dRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelec" & _
            "tor"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent" & _
            "=""Normal"" me=""Style1"" /><ClientRect>0, 0, 782, 350</ClientRect><BorderSide>0</Bo" & _
            "rderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Spli" & _
            "ts><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Headin" & _
            "g"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" " & _
            "/><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /" & _
            "><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /" & _
            "><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Sty" & _
            "le parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" " & _
            "/><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><" & _
            "horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRec" & _
            "SelWidth><ClientArea>0, 0, 782, 350</ClientArea><PrintPageHeaderStyle parent="""" " & _
            "me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.Label1.Location = New System.Drawing.Point(8, 64)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(112, 23)
            Me.Label1.TabIndex = 164
            Me.Label1.Text = "Printer EE"
            '
            'TextBox1
            '
            Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.TextBox1.Location = New System.Drawing.Point(126, 64)
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.Size = New System.Drawing.Size(168, 26)
            Me.TextBox1.TabIndex = 163
            Me.TextBox1.Text = ""
            '
            'Label3
            '
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.Label3.Location = New System.Drawing.Point(368, 64)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(112, 23)
            Me.Label3.TabIndex = 168
            Me.Label3.Text = "Picker Name"
            '
            'txtUser
            '
            Me.txtUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtUser.Location = New System.Drawing.Point(488, 64)
            Me.txtUser.Name = "txtUser"
            Me.txtUser.ReadOnly = True
            Me.txtUser.Size = New System.Drawing.Size(168, 26)
            Me.txtUser.TabIndex = 167
            Me.txtUser.Text = "Tom"
            '
            'Label4
            '
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.Label4.Location = New System.Drawing.Point(368, 32)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(112, 23)
            Me.Label4.TabIndex = 166
            Me.Label4.Text = "Picker ID"
            '
            'txtEmpID
            '
            Me.txtEmpID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtEmpID.Location = New System.Drawing.Point(488, 24)
            Me.txtEmpID.Name = "txtEmpID"
            Me.txtEmpID.ReadOnly = True
            Me.txtEmpID.Size = New System.Drawing.Size(168, 26)
            Me.txtEmpID.TabIndex = 165
            Me.txtEmpID.Text = "1234"
            '
            'btnClear
            '
            Me.btnClear.BackColor = System.Drawing.Color.SteelBlue
            Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClear.ForeColor = System.Drawing.Color.White
            Me.btnClear.Location = New System.Drawing.Point(176, 128)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(104, 40)
            Me.btnClear.TabIndex = 169
            Me.btnClear.Text = "Clear"
            '
            'btnRefresh
            '
            Me.btnRefresh.BackColor = System.Drawing.Color.SteelBlue
            Me.btnRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRefresh.ForeColor = System.Drawing.Color.White
            Me.btnRefresh.Location = New System.Drawing.Point(0, 128)
            Me.btnRefresh.Name = "btnRefresh"
            Me.btnRefresh.Size = New System.Drawing.Size(160, 40)
            Me.btnRefresh.TabIndex = 170
            Me.btnRefresh.Text = "Refresh Data"
            '
            'frmTFFK_Pick
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(792, 542)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRefresh, Me.btnClear, Me.Label3, Me.txtUser, Me.Label4, Me.txtEmpID, Me.Label1, Me.TextBox1, Me.Label2, Me.btnGo, Me.lblPO, Me.txtPONumber, Me.tdgData1})
            Me.Name = "frmTFFK_Pick"
            Me.Text = "frmTFFK_Pick"
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region
        Private Sub frmTFFK_Pick_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                PSS.Core.Highlight.SetHighLight(Me)

                Me.txtEmpID.Text = Me._strEmpID
                Me.txtUser.Text = Me._strUser

                Me.UpdateWeight()

                'Me._dtPickData = Me._objPickPackShip.getPickData
                'Me.BindPickData(Me._dtPickData)
                Me.RefreshData()


            Catch ex As Exception
                MessageBox.Show(ex.ToString, " frmTFFK_Pick_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Finally
                '    Cursor.Current = Cursors.Default
            End Try
        End Sub

        Private Sub UpdateWeight()
            Dim dt As DataTable
            Dim i As Integer = 0

            Try
                dt = Me._objPickPackShip.getOpenOrderAndWeightData

                i = Me._objPickPackShip.UpdateOrderTotalWeight(dt)

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "UpdateWeight", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub



        Private Sub BindPickData(ByVal dt As DataTable)
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
            Dim col As DataColumn
            Dim i As Integer = 0

            Try
                If dt.Rows.Count > 0 Then
                    With Me.tdgData1
                        .DataSource = dt.DefaultView

                        For Each dbgc In .Splits(0).DisplayColumns
                            dbgc.Locked = True
                            dbgc.AutoSize()
                        Next dbgc

                        For Each col In dt.Columns
                            i += 1
                            If i > 7 Then .Splits(0).DisplayColumns(col.ColumnName).Width = 0
                        Next
                        '.Splits(0).DisplayColumns("Cust_ID").Width = 0
                        '.Splits(0).DisplayColumns("Loc_ID").Width = 0
                        '.Splits(0).DisplayColumns("SoHeaderID").Width = 0
                        '.Splits(0).DisplayColumns("RecID").Width = 0
                        '.Splits(0).DisplayColumns("sku_insert_decode_id").Width = 0

                        .ColumnFooters = True
                        .Columns("PickID").FooterText = "Total (" & dt.Rows.Count.ToString & ")"
                        .Splits(0).DisplayColumns("PickID").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                        Me.CalculateFooter()
                    End With
                Else
                    MessageBox.Show("No order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "BindPickData", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub CalculateFooter()
            Dim i As Integer
            Dim sum1, sum2 As Double
            Try
                For i = 0 To Me.tdgData1.Splits(0).Rows.Count - 1
                    sum1 += Me.tdgData1.Columns("No. Order").CellValue(i)
                    sum2 += Me.tdgData1.Columns("No. Item").CellValue(i)
                Next
                Me.tdgData1.Columns("No. Order").FooterText = sum1
                Me.tdgData1.Columns("No. Item").FooterText = sum2

            Catch ex As Exception
                MessageBox.Show(ex.ToString, " CalculateFooter", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub ProcessPickData()

            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
            Dim iRow As Integer = 0
            Dim row, row2 As DataRow
            'Dim foundRows() As DataRow
            Dim dtPickSlip, dtBoxLabel, dtPackingSlipBoxLabel As DataTable
            Dim i As Integer = 0, k As Integer = 0
            'Dim dtTmp As DataTable
            Dim strWorkstation As String = Me._objTFFK._strPackWorkstation
            Dim strDateTime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
            Dim iCustID As Integer = 0
            Dim iOrderItemCount As Integer = 0
            Dim dtShipData As DataTable
            Dim dtOrderDetails As DataTable
            Dim iOrderItemQty As Integer = 0
            Dim iHowManyBoxes As Integer = 0
            Dim strBoxLabelDatetime As String = ""
            Dim strLabel As String = ""
            Dim strQuotMark As String = """"
            Dim strFedExServiceType As String = ""
            Dim strErrMsg As String = ""
            Dim iShipOrderType_ID As Integer = 0
            Dim strClientCustomerOrder As String = ""


            Try

                'With Me.tdgData1
                '    For Each iRow In .SelectedRows 'must be one row
                '        If Trim(.Columns("Status").CellValue(iRow)).ToString.ToUpper = "Closed".ToUpper Then
                '            MessageBox.Show("Devices for this item '" & .Columns("Status").CellValue(iRow).ToString & "' has be received.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '            Exit Sub
                '        End If
                '        strSelectedItem = .Columns("item").CellText(iRow)
                '        Exit For
                '    Next
                'End With
                If Not Me._dtPickData.Rows.Count > 0 Then Exit Sub

                Cursor.Current = Cursors.WaitCursor

                If Not tdgData1.SelectedRows.Count = 1 Then
                    MessageBox.Show("Please select a row to process.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    For Each iRow In Me.tdgData1.SelectedRows 'must be one row
                        Me._strPickID = Trim(Me.tdgData1.Columns("PickID").CellValue(iRow)).ToString
                        Me._strOrderNo = Trim(Me.tdgData1.Columns("OrderNumbers").CellValue(iRow)).ToString
                        'Me._iSelectedRecID = Convert.ToInt32(Me.tdgData1.Columns("RecID").CellValue(iRow))
                        'Me._iSelectedSoHeaderID = Convert.ToInt32(Me.tdgData1.Columns("SoHeaderID").CellValue(iRow))

                        Me._strSoHeaderIDs = Trim(Me.tdgData1.Columns("SoHeaderIDs").CellValue(iRow)).ToString
                        Me._iHowManyOrders = Convert.ToInt32(Me.tdgData1.Columns("No. Order").CellValue(iRow))
                        Me._iShipCarrier_ID = Convert.ToInt32(Me.tdgData1.Columns("ShipCarrier_ID").CellValue(iRow))
                        iCustID = Convert.ToInt32(Me.tdgData1.Columns("Cust_ID").CellValue(iRow))
                        iOrderItemCount = Convert.ToInt32(Me.tdgData1.Columns("No. Item").CellValue(iRow))

                    Next

                    Me.tdgData1.Enabled = False

                    dtShipData = Me._objPickPackShip.getOrderForShipData(Me._strSoHeaderIDs)

                    'Dim frmV As New frmView(dtShipData)
                    'frmV.Show()
                    'Exit Sub

                    strBoxLabelDatetime = Format(Now, "yyyy-MM-dd HH:mm:ss")

                    If iCustID = PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK.Meijer_CUSTOMER_ID Then 'Meijer----------------------------------------------------------------------
                        strLabel = ""
                        If Me._objPickPackShip.IsFedExForNonBulk(Me._iShipCarrier_ID) Then 'Meijer Non Bulk FexEx  ship method
                            iShipOrderType_ID = 1 'Regular 
                            strFedExServiceType = Me._objPickPackShip.getFedExServiceType(Me._iShipCarrier_ID)  ' "92"

                            If strFedExServiceType.Trim.Length = 0 Then
                                MessageBox.Show("Can't find Service Type Code for this FedEx ship method.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Exit Sub
                            End If

                            For Each row In dtShipData.Rows 'each order
                                Dim L_strMsg As String = ""
                                Dim bBoxCreated As Boolean = False
                                If Not Me._objPickPackShip.AreMeijerNonBulkOrderDataValid(Convert.ToInt32(row("SoHeaderID")), _
                                       PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK._iPerBoxItemNumber, iOrderItemQty, L_strMsg) Then
                                    MessageBox.Show(L_strMsg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                    Exit Sub
                                End If

                                iHowManyBoxes = PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK.ComputeGroups(iOrderItemQty, PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK._iPerBoxItemNumber)
                                dtBoxLabel = Me._objPickPackShip.getBoxLabelNames_MeijerNonBulk(iHowManyBoxes, _
                                              Convert.ToInt32(row("SoHeaderID")), Me._UserID, strBoxLabelDatetime, bBoxCreated)
                                If Not bBoxCreated Then
                                    MessageBox.Show("Failed to create boxes or partial boxes are created.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                    Exit Sub
                                End If

                                'Dim frmV As New frmView(dtBoxLabel)
                                'frmV.Show()
                                'PSSI_label_ID, PSSI_Boxlabel_Name, BoxQty, BoxWeightRoundUp, BoxWeight, SoHeaderID, IsCompleted, User_ID, UpdateDateTime
                                For Each row2 In dtBoxLabel.Rows 'each box
                                    strLabel &= "0,"
                                    strLabel &= strQuotMark & PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK.FedEx_TransactionCode & strQuotMark
                                    strLabel &= "1," & strQuotMark & Convert.ToString(row2("PSSI_Boxlabel_Name")) & strQuotMark
                                    'strLabel &= "11," & strQuotMark & PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK.FedEx_Company & strQuotMark
                                    strLabel &= "12," & strQuotMark & Convert.ToString(row("CustomerName")) & strQuotMark
                                    strLabel &= "13," & strQuotMark & Convert.ToString(row("CustomerAddress1")) & strQuotMark
                                    If Not row.IsNull("Address2") AndAlso Convert.ToString(row("Address2")).Trim.Length > 0 Then
                                        strLabel &= "14," & strQuotMark & Convert.ToString(row("Address2")) & strQuotMark
                                    End If
                                    strLabel &= "15," & strQuotMark & Convert.ToString(row("CustomerCity")) & strQuotMark
                                    strLabel &= "16," & strQuotMark & Convert.ToString(row("CustomerState")) & strQuotMark
                                    strLabel &= "17," & strQuotMark & Convert.ToString(row("CustomerPostalCode")) & strQuotMark
                                    If Not row.IsNull("CustomerPhone") AndAlso Convert.ToString(row("CustomerPhone")).Trim.Length > 0 Then
                                        strLabel &= "18," & strQuotMark & Convert.ToString(row("CustomerPhone")) & strQuotMark
                                    Else
                                        strLabel &= "18,""9999999999" & strQuotMark ' & Convert.ToString(row("CustomerPhone")) & strQuotMark
                                    End If
                                    strLabel &= "21," & strQuotMark & Convert.ToString(row2("BoxWeightRoundUp")) & strQuotMark
                                    strLabel &= "23," & strQuotMark & PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK.FedEx_PayType & strQuotMark
                                    strLabel &= "25," & strQuotMark & Convert.ToString(row2("PSSI_Boxlabel_Name")) & strQuotMark
                                    strLabel &= "50," & strQuotMark & PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK.FedEx_RecipientCountry & strQuotMark
                                    strLabel &= "75," & strQuotMark & PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK.FedEx_WeightUnit & strQuotMark
                                    strLabel &= "117," & strQuotMark & PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK.FedEx_SenderCountry & strQuotMark
                                    strLabel &= "187," & strQuotMark & PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK.FedEx_LabelFormat & strQuotMark
                                    strLabel &= "440," & strQuotMark & PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK.FedEx_ResidentialDeliveryFlag & strQuotMark
                                    strLabel &= "537," & strQuotMark & PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK.FedEx_Printer & strQuotMark
                                    strLabel &= "1273," & strQuotMark & PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK.FedEx_PackingType & strQuotMark
                                    strLabel &= "1274," & strQuotMark & strFedExServiceType & strQuotMark
                                    strLabel &= "3003," & strQuotMark & Convert.ToString(row2("PSSI_Boxlabel_Name")) & strQuotMark

                                    dtPackingSlipBoxLabel = Me._objPickPackShip.getPackingSlipDataByBox_MeijerNonBulk(Convert.ToString(row2("PSSI_Boxlabel_Name")))
                                    strClientCustomerOrder = Convert.ToString(dtPackingSlipBoxLabel.Rows(0).Item("OrderNo"))

                                    strLabel &= "3056," & strQuotMark & strClientCustomerOrder & strQuotMark
                                    strLabel &= "99,""""" & Environment.NewLine

                                    'Print pack slip per box
                                    i = Me._objPickPackShip.PrintPackingLabel(dtPackingSlipBoxLabel, 1)
                                Next 'each box
                            Next 'each order

                            'Print FedEx ship label
                            strErrMsg = ""
                            PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK.CreateTextFile("\\phq-file\Public\Dept\FedEx\TRANS_" & Format(Now, "yyyyMMddHHmmss") & ".IN", _
                                                                                         strLabel, strErrMsg)
                            If strErrMsg.Trim.Length > 0 Then
                                MessageBox.Show(strErrMsg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                        ElseIf Me._iShipCarrier_ID = 10 _
                               OrElse Me._iShipCarrier_ID = PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK._iSaiaCarrierLTLShipMethodID Then 'Meijer Bulk: FedEx Freight (FEDFR) or Saia LTL Frieght (SLTLFR) 
                            iShipOrderType_ID = 2 'Bulk
                            For Each row In dtShipData.Rows 'each order
                                iOrderItemQty = Me._objPickPackShip.getOrderItemTotalCount(Convert.ToInt32(row("SoHeaderID")))
                                iHowManyBoxes = 1 'Bulk always 1
                                dtBoxLabel = Me._objPickPackShip.getBoxLabelNames_Bulk(iHowManyBoxes, Convert.ToInt32(row("SoHeaderID")), Me._UserID, strBoxLabelDatetime)
                                For Each row2 In dtBoxLabel.Rows 'each box, bulk has only 1 box
                                    'Print pack slip per box (1 for each order in the pick run)
                                    dtPackingSlipBoxLabel = Me._objPickPackShip.getPackingSlipDataByBox_Bulk(Convert.ToString(row2("PSSI_Boxlabel_Name")))
                                    i = Me._objPickPackShip.PrintPackingLabel(dtPackingSlipBoxLabel, 1)
                                Next
                            Next
                        Else
                            MessageBox.Show("Invalid ship method.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If 'Not Bulk

                    ElseIf iCustID = PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK.Freds_CUSTOMER_ID Then 'Fred's Always Bulk==============================================================
                        'Fedex freight or Saia LTL Freight
                        If Me._iShipCarrier_ID = PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK._iFredsBulkCarrierShipMethodID _
                           OrElse Me._iShipCarrier_ID = PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK._iSaiaCarrierLTLShipMethodID Then
                            'Always Bulk
                            iShipOrderType_ID = 2 'Bulk
                            For Each row In dtShipData.Rows 'each order
                                iOrderItemQty = Me._objPickPackShip.getOrderItemTotalCount(Convert.ToInt32(row("SoHeaderID")))
                                iHowManyBoxes = 1 'Bulk always 1
                                dtBoxLabel = Me._objPickPackShip.getBoxLabelNames_Bulk(iHowManyBoxes, Convert.ToInt32(row("SoHeaderID")), Me._UserID, strBoxLabelDatetime)
                                For Each row2 In dtBoxLabel.Rows 'each box, bulk has only 1 box
                                    'Print pack slip per box (1 for each order in the pick run)  
                                    dtPackingSlipBoxLabel = Me._objPickPackShip.getPackingSlipDataByBox_Bulk(Convert.ToString(row2("PSSI_Boxlabel_Name")))
                                    i = Me._objPickPackShip.PrintPackingLabel(dtPackingSlipBoxLabel, 1)
                                Next
                            Next
                        Else
                            MessageBox.Show("Invalid ship method. Fred's always use FedEx Freight (FEDFR) or Saia LTL Freight (SLTLFR).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If
                    ElseIf iCustID = PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK.Frys_CUSTOMER_ID Then 'FRY'S+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                        If Me._iShipCarrier_ID = 1 Then 'UPS Ground (UPGR)   
                            iShipOrderType_ID = 2 'Treat as Bulk
                            strLabel = "1-Ship_To_Name,2-Ship_To_Phone_Number,3-Ship_To_Company,4-Ship_To_Attention,5-Ship_To_Address_1,6-Ship_To_Address_2,7-Ship_To_City,8-Ship_To_State\Provence,9-Ship_To_Postal_Code,10-Ship_To_Country,11-Country_Code,12-Class_Of_Service,13-Reference_Number,14-Package_Weight, 15-UPS Account #, 16-Customer PO  Number, "
                            strLabel &= Environment.NewLine
                            strQuotMark = ""

                            For Each row In dtShipData.Rows 'each order in the pickrun
                                iOrderItemQty = Me._objPickPackShip.getOrderItemTotalCount(Convert.ToInt32(row("SoHeaderID")))
                                iHowManyBoxes = 1 'Bulk always 1
                                dtBoxLabel = Me._objPickPackShip.getBoxLabelNames_Bulk(iHowManyBoxes, Convert.ToInt32(row("SoHeaderID")), Me._UserID, strBoxLabelDatetime)

                                For Each row2 In dtBoxLabel.Rows 'each box, bulk has only 1 box, should 1 row
                                    strLabel &= strQuotMark & Convert.ToString(row("CustomerName")) & strQuotMark & "," '1
                                    If Not row.IsNull("CustomerPhone") AndAlso Convert.ToString(row("CustomerPhone")).Trim.Length > 0 Then '2
                                        strLabel &= strQuotMark & Convert.ToString(row("CustomerPhone")) & strQuotMark & ","
                                    Else
                                        strLabel &= strQuotMark & "" & strQuotMark & ","
                                    End If

                                    strLabel &= strQuotMark & Me._objPickPackShip.getCustomterName(iCustID) & strQuotMark & "," '3
                                    strLabel &= strQuotMark & "" & strQuotMark & "," '4
                                    strLabel &= strQuotMark & Convert.ToString(row("CustomerAddress1")) & strQuotMark & "," '5
                                    If Not row.IsNull("Address2") AndAlso Convert.ToString(row("Address2")).Trim.Length > 0 Then '6
                                        strLabel &= strQuotMark & Convert.ToString(row("Address2")) & strQuotMark & ","
                                    Else
                                        strLabel &= strQuotMark & "" & strQuotMark & ","
                                    End If
                                    strLabel &= strQuotMark & Convert.ToString(row("CustomerCity")) & strQuotMark & "," '7
                                    strLabel &= strQuotMark & Convert.ToString(row("CustomerState")) & strQuotMark & "," '8
                                    strLabel &= strQuotMark & Convert.ToString(row("CustomerPostalCode")) & strQuotMark & "," '9
                                    strLabel &= strQuotMark & "United States" & strQuotMark & "," '10
                                    strLabel &= strQuotMark & "840" & strQuotMark & "," '11
                                    strLabel &= strQuotMark & "03" & strQuotMark & "," '12
                                    strLabel &= strQuotMark & Convert.ToString(row("SoHeaderID")).PadLeft(10, "0") & strQuotMark & ","  '13 - Reference_Number
                                    strLabel &= strQuotMark & Convert.ToString(row2("BoxWeightRoundUp")) & strQuotMark & ","  '14 - Package Weight
                                    strLabel &= strQuotMark & PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK.PSSI_UPS_Account & strQuotMark & "," '15 UPS Account
                                    strLabel &= strQuotMark & Convert.ToString(row("ClientCustomerOrder")) & strQuotMark & Environment.NewLine   '16  Customer PO Number

                                    'dtPackingSlipBoxLabel = Me._objPickPackShip.getPackingSlipDataByBox(Convert.ToString(row2("PSSI_Boxlabel_Name")))
                                    dtPackingSlipBoxLabel = Me._objPickPackShip.getPackingSlipDataByBox_Bulk(Convert.ToString(row2("PSSI_Boxlabel_Name")))
                                    i = Me._objPickPackShip.PrintPackingLabel(dtPackingSlipBoxLabel, 1)
                                Next
                            Next

                            'Print UPS Groun Label
                            strErrMsg = ""
                            PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK.CreateTextFile("\\phq-file\Public\Dept\BarTender\Integrations\UPSGND\UPSGROUND_" & Format(Now, "yyyyMMddHHmmss") & ".txt", _
                                                                                         strLabel, strErrMsg)

                            If strErrMsg.Trim.Length > 0 Then
                                MessageBox.Show(strErrMsg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                        ElseIf Me._objPickPackShip.IsFedExForNonBulk(Me._iShipCarrier_ID) Then 'FexEx  carriers

                            strFedExServiceType = Me._objPickPackShip.getFedExServiceType(Me._iShipCarrier_ID)  ' "92"
                            If strFedExServiceType.Trim.Length = 0 Then
                                MessageBox.Show("Can't find Service Type Code for this FedEx ship method.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Exit Sub
                            End If

                            strLabel = ""
                            iShipOrderType_ID = 2 'Treat As Bulk
                            For Each row In dtShipData.Rows 'each order
                                iOrderItemQty = Me._objPickPackShip.getOrderItemTotalCount(Convert.ToInt32(row("SoHeaderID")))
                                iHowManyBoxes = PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK.ComputeGroups(iOrderItemQty, PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK._iPerBoxItemNumber)
                                dtBoxLabel = Me._objPickPackShip.getBoxLabelNames(iHowManyBoxes, Convert.ToInt32(row("SoHeaderID")), Me._UserID, strBoxLabelDatetime)
                                'Dim frmV As New frmView(dtBoxLabel)
                                'frmV.Show()
                                'PSSI_label_ID, PSSI_Boxlabel_Name, BoxQty, BoxWeightRoundUp, BoxWeight, SoHeaderID, IsCompleted, User_ID, UpdateDateTime
                                For Each row2 In dtBoxLabel.Rows 'each box
                                    strLabel &= "0,"
                                    strLabel &= strQuotMark & PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK.FedEx_TransactionCode & strQuotMark
                                    strLabel &= "1," & strQuotMark & Convert.ToString(row2("PSSI_Boxlabel_Name")) & strQuotMark
                                    'strLabel &= "11," & strQuotMark & PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK.FedEx_Company & strQuotMark
                                    strLabel &= "12," & strQuotMark & Convert.ToString(row("CustomerName")) & strQuotMark
                                    strLabel &= "13," & strQuotMark & Convert.ToString(row("CustomerAddress1")) & strQuotMark
                                    If Not row.IsNull("Address2") AndAlso Convert.ToString(row("Address2")).Trim.Length > 0 Then
                                        strLabel &= "14," & strQuotMark & Convert.ToString(row("Address2")) & strQuotMark
                                    End If
                                    strLabel &= "15," & strQuotMark & Convert.ToString(row("CustomerCity")) & strQuotMark
                                    strLabel &= "16," & strQuotMark & Convert.ToString(row("CustomerState")) & strQuotMark
                                    strLabel &= "17," & strQuotMark & Convert.ToString(row("CustomerPostalCode")) & strQuotMark
                                    If Not row.IsNull("CustomerPhone") AndAlso Convert.ToString(row("CustomerPhone")).Trim.Length > 0 Then
                                        strLabel &= "18," & strQuotMark & Convert.ToString(row("CustomerPhone")) & strQuotMark
                                    Else
                                        strLabel &= "18,""9999999999" & strQuotMark ' & Convert.ToString(row("CustomerPhone")) & strQuotMark
                                    End If
                                    strLabel &= "21," & strQuotMark & Convert.ToString(row2("BoxWeightRoundUp")) & strQuotMark
                                    strLabel &= "23," & strQuotMark & PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK.FedEx_PayType & strQuotMark
                                    strLabel &= "25," & strQuotMark & Convert.ToString(row2("PSSI_Boxlabel_Name")) & strQuotMark
                                    strLabel &= "50," & strQuotMark & PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK.FedEx_RecipientCountry & strQuotMark
                                    strLabel &= "75," & strQuotMark & PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK.FedEx_WeightUnit & strQuotMark
                                    strLabel &= "117," & strQuotMark & PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK.FedEx_SenderCountry & strQuotMark
                                    strLabel &= "187," & strQuotMark & PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK.FedEx_LabelFormat & strQuotMark
                                    strLabel &= "440," & strQuotMark & PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK.FedEx_ResidentialDeliveryFlag & strQuotMark
                                    strLabel &= "537," & strQuotMark & PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK.FedEx_Printer & strQuotMark
                                    strLabel &= "1273," & strQuotMark & PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK.FedEx_PackingType & strQuotMark
                                    strLabel &= "1274," & strQuotMark & strFedExServiceType & strQuotMark

                                    strLabel &= "3003," & strQuotMark & Convert.ToString(row2("PSSI_Boxlabel_Name")) & strQuotMark

                                    'dtPackingSlipBoxLabel = Me._objPickPackShip.getPackingSlipDataByBox(Convert.ToString(row2("PSSI_Boxlabel_Name")))
                                    dtPackingSlipBoxLabel = Me._objPickPackShip.getPackingSlipDataByBox_Bulk(Convert.ToString(row2("PSSI_Boxlabel_Name")))

                                    strClientCustomerOrder = Convert.ToString(dtPackingSlipBoxLabel.Rows(0).Item("OrderNo"))

                                    strLabel &= "3056," & strQuotMark & strClientCustomerOrder & strQuotMark
                                    strLabel &= "99,""""" & Environment.NewLine

                                    'Print pack slip per box
                                    'dtPackingSlipBoxLabel = Me._objPickPackShip.getPackingSlipDataByBox(Convert.ToString(row2("PSSI_Boxlabel_Name")))
                                    i = Me._objPickPackShip.PrintPackingLabel(dtPackingSlipBoxLabel, 1)
                                Next 'each box
                            Next 'each order

                            'Print FedEx ship label
                            strErrMsg = ""
                            PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK.CreateTextFile("\\phq-file\Public\Dept\FedEx\TRANS_" & Format(Now, "yyyyMMddHHmmss") & ".IN", _
                                                               strLabel, strErrMsg)
                            If strErrMsg.Trim.Length > 0 Then
                                MessageBox.Show(strErrMsg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If
                        Else
                            MessageBox.Show("Not defined for this carrier.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If
                    Else
                        MessageBox.Show("This customer is not defined in the system", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If


                    'Print pick slip
                    dtPickSlip = Me._objPickPackShip.getPickTicketData(Me._iHowManyOrders, Me._strSoHeaderIDs, Me._strPickID)
                    i = Me._objPickPackShip.PrintPickTicket(dtPickSlip, 1)

                    'Update workstation for close the pick, move it to Pack for each order  in the selected group
                    For Each row In dtShipData.Rows
                        i = Me._objPickPackShip.UpdatePickRunData(Me._strSoHeaderIDs, _
                                                                  strWorkstation, Me._UserID, Format(Now, "yyyy-MM-dd HH:mm:ss"), _
                                                                  iShipOrderType_ID, Me._strPickID)
                    Next

                    If i > 0 Then
                        'Reload 
                        Me.RefreshData()
                    Else
                        MessageBox.Show("Failed to update. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.tdgData1.Enabled = True
                        Me.tdgData1.Focus()
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ProcessPickData", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo.Click
            'Dim dtLabel As DataTable
            'Dim i As Integer = 0, k As Integer = 0
            'Dim dtTmp As DataTable
            'Dim row As DataRow

            Try

              

                Me.ProcessPickData()

                'If Not tdgData1.SelectedRows.Count = 1 Then
                '    MessageBox.Show("Please select a row to process.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'Else
                '    dtLabel = Me._objPickPackShip.getPickTicketData(Me._iSelectedRecID)
                '    i = Me._objPickPackShip.PrintPickTicket(dtLabel, 1)
                '    dtTmp = Me._dtPickData.Clone
                '    For Each row In Me._dtPickData.Rows
                '        k = Convert.ToInt32(row("RecID"))
                '        If Not k = Me._iSelectedRecID Then
                '            dtTmp.ImportRow(row)
                '        End If
                '    Next
                '    Me._dtPickData.Rows.Clear()
                '    Me._dtPickData = dtTmp.Copy
                '    Me.BindPickData(Me._dtPickData)
                '    Me.tdgData1.Enabled = True
                '    Me.tdgData1.Focus()
                'End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ProcessPickData", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub



      

        Private Sub ClearData()
            Try
                Me.tdgData1.DataSource = Nothing
                Me.btnRefresh.Enabled = True
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ClearData", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub


        Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
            Me.ClearData()
        End Sub

        Private Sub RefreshData()
            ' Dim dt As DataTable
            Dim row As DataRow
            Dim i As Integer = 0, j As Integer = 0
            Dim dtPickIDs As DataTable

            Try
                j = Me._objPickPackShip.ComputeShipMethodAndGetPickData

                Me._dtPickData = Me._objPickPackShip.getPickData
                '
                If Me._dtPickData.Rows.Count > 0 Then
                    dtPickIDs = Me._objPickPackShip.getPickIDs(Me._dtPickData.Rows.Count, Me._UserID, Format(Now, "yyyy-MM-dd HH:mm:ss"))

                    If dtPickIDs.Rows.Count = Me._dtPickData.Rows.Count Then
                        For Each row In Me._dtPickData.Rows
                            row.BeginEdit()
                            row("PickIDKey") = dtPickIDs.Rows(i).Item("PickRun_ID")
                            row("PickID") = dtPickIDs.Rows(i).Item("PickRun_Name")
                            row.AcceptChanges()
                            i += 1
                        Next

                        Me.BindPickData(Me._dtPickData)
                        Me.tdgData1.Refresh()
                        Me.tdgData1.Enabled = True
                        Me.tdgData1.Focus()
                    Else
                        MessageBox.Show("Pick ID missing or exceptional issue!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "RefreshData", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub


        Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
            Me.RefreshData()
        End Sub
    End Class
End Namespace