Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.AIG
    Public Class frmRepPartPickTicket
        Inherits System.Windows.Forms.Form

        Private _strScreenName As String
        Private _iMenuCustID As Integer
        Private _iMenuLocID As Integer
        Private _objAIG As PSS.Data.Buisness.AIG

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strScreenName As String, ByVal iCustID As Integer, ByVal iLocID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _strScreenName = strScreenName
            _iMenuCustID = iCustID
            _iMenuLocID = iLocID
            _objAIG = New PSS.Data.Buisness.AIG()

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
        Friend WithEvents lblClaimNo As System.Windows.Forms.Label
        Friend WithEvents btnPrint As System.Windows.Forms.Button
        Friend WithEvents btnReprint As System.Windows.Forms.Button
        Friend WithEvents txtClaimNo As System.Windows.Forms.TextBox
        Friend WithEvents dbgNeedPartList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmRepPartPickTicket))
            Me.lblClaimNo = New System.Windows.Forms.Label()
            Me.btnPrint = New System.Windows.Forms.Button()
            Me.btnReprint = New System.Windows.Forms.Button()
            Me.txtClaimNo = New System.Windows.Forms.TextBox()
            Me.dbgNeedPartList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            CType(Me.dbgNeedPartList, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblClaimNo
            '
            Me.lblClaimNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblClaimNo.Location = New System.Drawing.Point(24, 24)
            Me.lblClaimNo.Name = "lblClaimNo"
            Me.lblClaimNo.Size = New System.Drawing.Size(104, 23)
            Me.lblClaimNo.TabIndex = 135
            Me.lblClaimNo.Text = "Claim #:"
            '
            'btnPrint
            '
            Me.btnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPrint.ForeColor = System.Drawing.Color.DarkBlue
            Me.btnPrint.Location = New System.Drawing.Point(40, 384)
            Me.btnPrint.Name = "btnPrint"
            Me.btnPrint.Size = New System.Drawing.Size(264, 48)
            Me.btnPrint.TabIndex = 131
            Me.btnPrint.Text = "Print Part Pick Ticket"
            '
            'btnReprint
            '
            Me.btnReprint.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprint.ForeColor = System.Drawing.Color.Navy
            Me.btnReprint.Location = New System.Drawing.Point(328, 384)
            Me.btnReprint.Name = "btnReprint"
            Me.btnReprint.Size = New System.Drawing.Size(296, 48)
            Me.btnReprint.TabIndex = 132
            Me.btnReprint.Text = "Reprint Part Pick Ticket"
            '
            'txtClaimNo
            '
            Me.txtClaimNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtClaimNo.Location = New System.Drawing.Point(24, 48)
            Me.txtClaimNo.Name = "txtClaimNo"
            Me.txtClaimNo.Size = New System.Drawing.Size(240, 21)
            Me.txtClaimNo.TabIndex = 133
            Me.txtClaimNo.Text = ""
            '
            'dbgNeedPartList
            '
            Me.dbgNeedPartList.AllowFilter = False
            Me.dbgNeedPartList.AllowSort = False
            Me.dbgNeedPartList.AllowUpdate = False
            Me.dbgNeedPartList.AllowUpdateOnBlur = False
            Me.dbgNeedPartList.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgNeedPartList.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgNeedPartList.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dbgNeedPartList.Location = New System.Drawing.Point(24, 80)
            Me.dbgNeedPartList.Name = "dbgNeedPartList"
            Me.dbgNeedPartList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgNeedPartList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgNeedPartList.PreviewInfo.ZoomFactor = 75
            Me.dbgNeedPartList.Size = New System.Drawing.Size(752, 280)
            Me.dbgNeedPartList.TabIndex = 136
            Me.dbgNeedPartList.Text = "C1TrueDBGrid1"
            Me.dbgNeedPartList.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{BackColor:WhiteSmoke;}Footer{}C" & _
            "aption{AlignHorz:Center;}Style1{}Normal{BackColor:LightSteelBlue;}HighlightRow{F" & _
            "oreColor:HighlightText;BackColor:Highlight;}Style14{}OddRow{}RecordSelector{Alig" & _
            "nImage:Center;}Style15{}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1," & _
            " 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}St" & _
            "yle11{}Style12{}Style13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.Me" & _
            "rgeView Name="""" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""" & _
            "17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17""" & _
            " VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>276</Height><CaptionS" & _
            "tyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><" & _
            "EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" m" & _
            "e=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Gro" & _
            "up"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowSty" & _
            "le parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Styl" & _
            "e4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""Re" & _
            "cordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Sty" & _
            "le parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 748, 276</ClientRect><BorderS" & _
            "ide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeVi" & _
            "ew></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" m" & _
            "e=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""" & _
            "Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Se" & _
            "lected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""Highli" & _
            "ghtRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRo" & _
            "w"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""Fi" & _
            "lterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</ver" & _
            "tSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</D" & _
            "efaultRecSelWidth><ClientArea>0, 0, 748, 276</ClientArea><PrintPageHeaderStyle p" & _
            "arent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'frmRepPartPickTicket
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(800, 446)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.dbgNeedPartList, Me.txtClaimNo, Me.btnReprint, Me.btnPrint, Me.lblClaimNo})
            Me.Name = "frmRepPartPickTicket"
            Me.Text = "frmRepPartPickTicket"
            CType(Me.dbgNeedPartList, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '******************************************************************************************************
        Private Sub txtClaimNo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtClaimNo.KeyUp

            Try

                If e.KeyCode = Keys.Enter AndAlso Me.txtClaimNo.Text.Trim.Length > 0 Then
                    BindPartData()
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtClaimNo_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub BindPartData()
            Dim dt As New DataTable(), row As DataRow

            Try
                Me.dbgNeedPartList.DataSource = Nothing
                dt = Me._objAIG.GetPartsPickTicketData(Me.txtClaimNo.Text.Trim, Me._iMenuCustID)
                If dt.Rows.Count > 0 Then
                    Me.dbgNeedPartList.DataSource = dt
                    With Me.dbgNeedPartList
                        .Splits(0).DisplayColumns("Prod_DT").Width = 0
                        .Splits(0).DisplayColumns("LineNo").Width = 0 : .Splits(0).DisplayColumns("EstimatedPrice").Width = 0
                        .Splits(0).DisplayColumns("EstimatedPartCost").Width = 0 : .Splits(0).DisplayColumns("Device Owner").Width = 0
                        .Splits(0).DisplayColumns("RMACreatedDT").Width = 0 : .Splits(0).DisplayColumns("DeviceRecvDT").Width = 0
                        .Splits(0).DisplayColumns("Tel").Width = 0 : .Splits(0).DisplayColumns("Email").Width = 0
                        .Splits(0).DisplayColumns("WO_ID").Width = 0 : .Splits(0).DisplayColumns("EW_ID").Width = 0
                        .Splits(0).DisplayColumns("Device_ID").Width = 0 : .Splits(0).DisplayColumns("PN_ID").Width = 0
                    End With
                Else
                    MessageBox.Show("Claim '" & Me.txtClaimNo.Text.Trim & "' has no part or doesn't exit.", "BindPartData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "BindPartData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************************************************
        Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
            'Only print those part rows with 'In Cage'
            Dim filteredRows() As DataRow, dt, dtFinal As DataTable
            Dim row As DataRow
            Dim arrPN_IDs As New ArrayList()
            Dim strWrkDate As String

            Try
                With Me.dbgNeedPartList
                    If .RowCount > 0 Then
                        dt = .DataSource
                        filteredRows = dt.Select("Part_Status = '" & Me._objAIG.enumPartPickStatus.In_Cage.ToString.Replace("_", " ") & "'")
                        dtFinal = dt.Clone
                        For Each row In filteredRows
                            dtFinal.ImportRow(row)
                            arrPN_IDs.Add(row("PN_ID"))
                        Next
                        If dtFinal.Rows.Count > 0 Then
                            strWrkDate = Generic.GetWorkDate(PSS.Core.ApplicationUser.IDShift)
                            Me._objAIG.UpdatePartsPickData(arrPN_IDs, strWrkDate, PSS.Core.ApplicationUser.IDuser)     'Update pick data
                            Me._objAIG.Print_RepairedPartPickTicket(dtFinal, 1) 'Print 
                            BindPartData()
                        Else
                            MessageBox.Show("No part to pick, so nothing to print.", "btnPrint_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        End If
                    Else
                        MessageBox.Show("No part to pick, so nothing to print.", "btnPrint_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                End With
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnPrint_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                dt = Nothing : dtFinal = Nothing
            End Try
        End Sub

        '******************************************************************************************************
        Private Sub btnReprint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReprint.Click
            'Only print those part rows with 'In Production', i.e, already picked
            Dim filteredRows() As DataRow, dt, dtFinal As DataTable
            Dim row As DataRow

            Try
                With Me.dbgNeedPartList
                    If .RowCount > 0 Then
                        dt = .DataSource
                        filteredRows = dt.Select("Part_Status = '" & Me._objAIG.enumPartPickStatus.In_Production.ToString.Replace("_", " ") & "'")
                        dtFinal = dt.Clone
                        For Each row In filteredRows
                            dtFinal.ImportRow(row)
                        Next
                        If dtFinal.Rows.Count > 0 Then
                            Me._objAIG.Print_RepairedPartPickTicket(dtFinal, 1)
                        Else
                            MessageBox.Show("No part in production, so nothing to reprint.", "btnPrint_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        End If
                    Else
                        MessageBox.Show("No part in production, so nothing to reprint.", "btnPrint_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                End With
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnReprint_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                dtFinal = Nothing
            End Try
        End Sub
    End Class
End Namespace