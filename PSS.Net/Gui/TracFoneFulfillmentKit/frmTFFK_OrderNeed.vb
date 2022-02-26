
Option Explicit On 

Imports PSS.Data.Buisness
Imports System.Text

Namespace Gui.TracFoneFulfillmentKit
    Public Class frmTFFK_OrderNeed
        Inherits System.Windows.Forms.Form

        Private _dt As DataTable

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal dt As DataTable)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._dt = dt
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
        Friend WithEvents lblTotalItemQtyVal As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents tdgData1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lblItemCount As System.Windows.Forms.Label
        Friend WithEvents lblItemCountVal As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTFFK_OrderNeed))
            Me.lblItemCountVal = New System.Windows.Forms.Label()
            Me.lblTotalItemQtyVal = New System.Windows.Forms.Label()
            Me.lblItemCount = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.tdgData1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblItemCountVal
            '
            Me.lblItemCountVal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblItemCountVal.ForeColor = System.Drawing.Color.Navy
            Me.lblItemCountVal.Location = New System.Drawing.Point(88, 416)
            Me.lblItemCountVal.Name = "lblItemCountVal"
            Me.lblItemCountVal.Size = New System.Drawing.Size(72, 16)
            Me.lblItemCountVal.TabIndex = 167
            Me.lblItemCountVal.Text = "0"
            '
            'lblTotalItemQtyVal
            '
            Me.lblTotalItemQtyVal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTotalItemQtyVal.ForeColor = System.Drawing.Color.Navy
            Me.lblTotalItemQtyVal.Location = New System.Drawing.Point(272, 416)
            Me.lblTotalItemQtyVal.Name = "lblTotalItemQtyVal"
            Me.lblTotalItemQtyVal.Size = New System.Drawing.Size(96, 16)
            Me.lblTotalItemQtyVal.TabIndex = 166
            Me.lblTotalItemQtyVal.Text = "0"
            '
            'lblItemCount
            '
            Me.lblItemCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblItemCount.ForeColor = System.Drawing.Color.Navy
            Me.lblItemCount.Location = New System.Drawing.Point(0, 416)
            Me.lblItemCount.Name = "lblItemCount"
            Me.lblItemCount.Size = New System.Drawing.Size(96, 16)
            Me.lblItemCount.TabIndex = 165
            Me.lblItemCount.Text = "Item Count:"
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Navy
            Me.Label1.Location = New System.Drawing.Point(200, 416)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(72, 16)
            Me.Label1.TabIndex = 164
            Me.Label1.Text = "Total Qty:"
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
            Me.tdgData1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgData1.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgData1.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.tdgData1.Name = "tdgData1"
            Me.tdgData1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgData1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgData1.PreviewInfo.ZoomFactor = 75
            Me.tdgData1.RowHeight = 15
            Me.tdgData1.Size = New System.Drawing.Size(352, 408)
            Me.tdgData1.TabIndex = 163
            Me.tdgData1.Text = "C1TrueDBGrid1"
            Me.tdgData1.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Style9{}Normal{Font:Microsoft Sans Serif, 9pt;}HighlightR" & _
            "ow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddRow{}RecordSelector{" & _
            "AlignImage:Center;}Style13{}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1," & _
            " 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{AlignHorz:Near" & _
            ";}Style11{}Style14{}Style15{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGri" & _
            "d.MergeView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionH" & _
            "eight=""17"" ColumnFooterHeight=""17"" FetchRowStyles=""True"" FilterBar=""True"" Marque" & _
            "eStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalS" & _
            "crollGroup=""1"" HorizontalScrollGroup=""1""><Height>406</Height><CaptionStyle paren" & _
            "t=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowSty" & _
            "le parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13" & _
            """ /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""St" & _
            "yle12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=" & _
            """HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><Odd" & _
            "RowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelect" & _
            "or"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=" & _
            """Normal"" me=""Style1"" /><ClientRect>0, 0, 350, 406</ClientRect><BorderSide>0</Bor" & _
            "derSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Split" & _
            "s><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading" & _
            """ /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /" & _
            "><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" />" & _
            "<Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" />" & _
            "<Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Styl" & _
            "e parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /" & _
            "><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><h" & _
            "orzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecS" & _
            "elWidth><ClientArea>0, 0, 350, 406</ClientArea><PrintPageHeaderStyle parent="""" m" & _
            "e=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'frmTFFK_OrderNeed
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.White
            Me.ClientSize = New System.Drawing.Size(352, 446)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblItemCountVal, Me.lblTotalItemQtyVal, Me.lblItemCount, Me.Label1, Me.tdgData1})
            Me.Name = "frmTFFK_OrderNeed"
            Me.Text = "Item Need for Open Orders"
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmTFFK_OrderNeed_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn

            Try
                Me.CenterToParent()

                If Me._dt.Rows.Count > 0 Then
                    With Me.tdgData1
                        .DataSource = Me._dt.DefaultView

                        For Each dbgc In .Splits(0).DisplayColumns
                            dbgc.Locked = True
                            dbgc.AutoSize()
                        Next dbgc

                        .Splits(0).DisplayColumns("Model_ID").Visible = False
                    End With
                    Me.lblTotalItemQtyVal.Text = Me._dt.Compute("Sum([Item Qty])", "")
                    Me.lblItemCountVal.Text = Me._dt.Rows.Count
                Else
                    MessageBox.Show("No skid data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

            Catch ex As Exception

                MessageBox.Show(ex.ToString, "frmTFFK_OrderNeed_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Finally
                '    Generic.DisposeDT(dt)
            End Try
        End Sub
    End Class
end namespace