Option Explicit On 

Imports PSS.Data.Buisness
Imports System.Text

Public Class frmTNSelectAndLockOrders
    Inherits System.Windows.Forms.Form

    Private _iMenuCustID As Integer = 0

    Private _UserID As Integer = PSS.Core.Global.ApplicationUser.IDuser
    Private _objTN As TN

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal iCust_ID As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me._iMenuCustID = iCust_ID
        Me._objTN = New TN()

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            Try
                Me._objTN = Nothing
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
    Friend WithEvents btnCopyAll As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents btnCopySelected As System.Windows.Forms.Button
    Friend WithEvents lblCountMsg As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTNSelectAndLockOrders))
        Me.tdgData1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btnCopyAll = New System.Windows.Forms.Button()
        Me.btnCopySelected = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.lblCountMsg = New System.Windows.Forms.Label()
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
        Me.tdgData1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tdgData1.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdgData1.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.tdgData1.Location = New System.Drawing.Point(16, 60)
        Me.tdgData1.Name = "tdgData1"
        Me.tdgData1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdgData1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdgData1.PreviewInfo.ZoomFactor = 75
        Me.tdgData1.RowHeight = 15
        Me.tdgData1.Size = New System.Drawing.Size(1112, 496)
        Me.tdgData1.TabIndex = 142
        Me.tdgData1.Text = "C1TrueDBGrid1"
        Me.tdgData1.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
        "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
        "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
        "tion{AlignHorz:Center;}Style1{}Normal{Font:Tahoma, 8.25pt;}HighlightRow{ForeColo" & _
        "r:HighlightText;BackColor:Highlight;}Style14{}OddRow{}RecordSelector{AlignImage:" & _
        "Center;}Style15{}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;F" & _
        "oreColor:ControlText;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}" & _
        "Style12{}Style13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView" & _
        " Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" " & _
        "ColumnFooterHeight=""17"" FetchRowStyles=""True"" FilterBar=""True"" MarqueeStyle=""Dot" & _
        "tedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=" & _
        """1"" HorizontalScrollGroup=""1""><Height>494</Height><CaptionStyle parent=""Style2"" " & _
        "me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""" & _
        "EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><Footer" & _
        "Style parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><H" & _
        "eadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightR" & _
        "ow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle pa" & _
        "rent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Sty" & _
        "le11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me" & _
        "=""Style1"" /><ClientRect>0, 0, 1110, 494</ClientRect><BorderSide>0</BorderSide><B" & _
        "orderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedSt" & _
        "yles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style" & _
        " parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style pa" & _
        "rent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style par" & _
        "ent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style par" & _
        "ent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""" & _
        "Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style pa" & _
        "rent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>" & _
        "1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><C" & _
        "lientArea>0, 0, 1110, 494</ClientArea><PrintPageHeaderStyle parent="""" me=""Style1" & _
        "4"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
        '
        'btnCopyAll
        '
        Me.btnCopyAll.BackColor = System.Drawing.Color.MediumBlue
        Me.btnCopyAll.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopyAll.ForeColor = System.Drawing.Color.White
        Me.btnCopyAll.Location = New System.Drawing.Point(472, 8)
        Me.btnCopyAll.Name = "btnCopyAll"
        Me.btnCopyAll.Size = New System.Drawing.Size(176, 32)
        Me.btnCopyAll.TabIndex = 152
        Me.btnCopyAll.TabStop = False
        Me.btnCopyAll.Text = "Get/Lock All Orders"
        '
        'btnCopySelected
        '
        Me.btnCopySelected.BackColor = System.Drawing.Color.MediumBlue
        Me.btnCopySelected.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopySelected.ForeColor = System.Drawing.Color.White
        Me.btnCopySelected.Location = New System.Drawing.Point(240, 8)
        Me.btnCopySelected.Name = "btnCopySelected"
        Me.btnCopySelected.Size = New System.Drawing.Size(224, 32)
        Me.btnCopySelected.TabIndex = 153
        Me.btnCopySelected.TabStop = False
        Me.btnCopySelected.Text = "Get/Lock Selected Orders"
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.Green
        Me.btnRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.ForeColor = System.Drawing.Color.White
        Me.btnRefresh.Location = New System.Drawing.Point(16, 8)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(208, 32)
        Me.btnRefresh.TabIndex = 154
        Me.btnRefresh.Text = "Refresh Open Order List"
        '
        'lblCountMsg
        '
        Me.lblCountMsg.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCountMsg.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblCountMsg.Location = New System.Drawing.Point(16, 42)
        Me.lblCountMsg.Name = "lblCountMsg"
        Me.lblCountMsg.Size = New System.Drawing.Size(440, 24)
        Me.lblCountMsg.TabIndex = 155
        '
        'frmTNSelectAndLockOrders
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightYellow
        Me.ClientSize = New System.Drawing.Size(1144, 574)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRefresh, Me.btnCopySelected, Me.btnCopyAll, Me.tdgData1, Me.lblCountMsg})
        Me.Name = "frmTNSelectAndLockOrders"
        Me.Text = "Select And Lock Orders"
        CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmTNSelectAndLockOrders_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetOpenOrderData()
    End Sub

    Private Sub GetOpenOrderData()
        Dim dt As DataTable
        Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn

        Try
            Cursor.Current = Cursors.WaitCursor

            Me.tdgData1.DataSource = Nothing
            Me.tdgData1.Visible = False : Me.lblCountMsg.Visible = False
            Me.lblCountMsg.Text = "Total: 0    Locked: 0"

            dt = Me._objTN.GetTNOpenOrder(Me._iMenuCustID, 0)

            With Me.tdgData1
                .DataSource = dt.DefaultView

                For Each dbgc In .Splits(0).DisplayColumns
                    dbgc.Locked = True
                    dbgc.AutoSize()
                Next dbgc

                .Splits(0).DisplayColumns("Sku").Width = 80
                .Splits(0).DisplayColumns("Sku_Part_Nr").Width = 80
                .Splits(0).DisplayColumns("Sku Type").Width = 80
                .Splits(0).DisplayColumns("Insert PN").Width = 80

                'Col 0 width
                .Splits(0).DisplayColumns("OutboundTrackingNumber").Width = 0
                .Splits(0).DisplayColumns("TransactionDatetime").Width = 0
                .Splits(0).DisplayColumns("TransactionID").Width = 0
                .Splits(0).DisplayColumns("SOHeaderID").Width = 0
                '.Splits(0).DisplayColumns("SODetailsID").Width = 0
                .Splits(0).DisplayColumns("WO_ID").Width = 0
                .Splits(0).DisplayColumns("Co_ID").Width = 0
                '.Splits(0).DisplayColumns("coi_id").Width = 0
                .Splits(0).DisplayColumns("Sku_ID").Width = 0
                .Splits(0).DisplayColumns("sku_type_decode_id").Width = 0
                .Splits(0).DisplayColumns("sku_insert_decode_id").Width = 0

            End With

            If dt.Rows.Count > 0 Then
                Dim LockedRows() As DataRow = dt.Select("Locked='Yes'")
                Me.lblCountMsg.Text = "Total: " & dt.Rows.Count.ToString & "    Locked: " & LockedRows.Length.ToString
            End If

            Me.tdgData1.Visible = True
            Me.lblCountMsg.Visible = True

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "GetOpenOrderData", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor.Current = Cursors.Default
            Generic.DisposeDT(dt)
        End Try
    End Sub

    Private Sub btnCopyAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCopyAll.Click
        Try
            GetAllRowsAndLock()

        Catch ex As Exception
            MessageBox.Show(ex.ToString, " btnCopyAll_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCopySelected_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCopySelected.Click
        Try
            'Misc.CopySelectedRowsData(Me.tdgData1)
            GetSelectedRowsAndLock()

        Catch ex As Exception
            MessageBox.Show(ex.ToString, " btnCopyAll_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub GetSelectedRowsAndLock()
        Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
        Dim iRow As Integer = 0
        Dim iSoHeaderID As Integer = 0
        Dim iAlreadyLockedOrders As Integer = 0
        Dim iSelectedOrders As Integer = 0

        Dim strAlreadyLockedOrders As String = ""

        Dim row As DataRow
        Dim strDateTime As String = Format(Now(), "yyyy-MM-dd HH:mm:ss")

        Try
            If Not Me.tdgData1.SelectedRows.Count > 0 Then
                MessageBox.Show("Please select rows.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            'Order No
            With Me.tdgData1
                For Each iRow In .SelectedRows 'should be one row

                    If IsDBNull(.Columns("SoHeaderID").CellText(iRow)) OrElse .Columns("SoHeaderID").CellText(iRow).ToString.Trim.Length = 0 Then
                        MessageBox.Show("No SoheaderID. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    Else
                        iSoHeaderID = .Columns("SoHeaderID").CellText(iRow)
                        If Me._objTN.IsOrderLocked(iSoHeaderID) Then
                            iAlreadyLockedOrders += 1
                            If iAlreadyLockedOrders = 1 Then strAlreadyLockedOrders &= .Columns("Order No").CellText(iRow) Else strAlreadyLockedOrders &= ", " & .Columns("Order No").CellText(iRow)
                            If strAlreadyLockedOrders.Trim.Length > 100 Then strAlreadyLockedOrders = strAlreadyLockedOrders.Substring(0, 100) & " ..."
                        Else
                            Me._objTN.UpdatelockOrder(iSoHeaderID, Me._UserID, strDateTime)
                        End If

                    End If
                    iSelectedOrders += 1
                Next
            End With

            'Display msg if soem orders are already locked, but you selected.
            If iAlreadyLockedOrders > 0 Then
                MessageBox.Show((iSelectedOrders - iAlreadyLockedOrders).ToString & " of " & iSelectedOrders.ToString & " updated. " & Environment.NewLine & iAlreadyLockedOrders.ToString & " orders (" & strAlreadyLockedOrders & ") locked already.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            'Refresh open order list
            GetOpenOrderData()

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Sub GetSelectedRowsAndLock", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GetAllRowsAndLock()
        Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
        Dim iRow As Integer = 0
        Dim iSoHeaderID As Integer = 0
        Dim iAlreadyLockedOrders As Integer = 0
        Dim iSelectedOrders As Integer = 0

        Dim strAlreadyLockedOrders As String = ""

        Dim row As DataRow
        Dim strDateTime As String = Format(Now(), "yyyy-MM-dd HH:mm:ss")

        Try

            If Not Me.tdgData1.RowCount > 0 Then Exit Sub

            Dim strPrompt As String = "Do you want to select all unlocked orders? "
            If Not MessageBox.Show(strPrompt, "TextNow Order Selection", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Exit Sub
            End If


            With Me.tdgData1
                For iRow = 0 To .RowCount - 1
                    If IsDBNull(.Columns("SoHeaderID").CellText(iRow)) OrElse .Columns("SoHeaderID").CellText(iRow).ToString.Trim.Length = 0 Then
                        MessageBox.Show("No SoheaderID. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    Else
                        iSoHeaderID = .Columns("SoHeaderID").CellText(iRow)
                        If Me._objTN.IsOrderLocked(iSoHeaderID) Then
                            iAlreadyLockedOrders += 1
                            If iAlreadyLockedOrders = 1 Then strAlreadyLockedOrders &= .Columns("Order No").CellText(iRow) Else strAlreadyLockedOrders &= ", " & .Columns("Order No").CellText(iRow)
                            If strAlreadyLockedOrders.Trim.Length > 100 Then strAlreadyLockedOrders = strAlreadyLockedOrders.Substring(0, 100) & " ..."
                        Else
                            Me._objTN.UpdatelockOrder(iSoHeaderID, Me._UserID, strDateTime)
                        End If

                    End If
                    iSelectedOrders += 1
                Next
            End With

            'Display msg if soem orders are already locked, but you selected.
            If iAlreadyLockedOrders > 0 Then
                MessageBox.Show((iSelectedOrders - iAlreadyLockedOrders).ToString & " updated. " & Environment.NewLine & iAlreadyLockedOrders.ToString & " orders (" & strAlreadyLockedOrders & ") locked already.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            'Refresh open order list
            GetOpenOrderData()

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Sub GetSelectedRowsAndLock", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Try
            GetOpenOrderData()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Sub GetSelectedRowsAndLock", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
End Class
