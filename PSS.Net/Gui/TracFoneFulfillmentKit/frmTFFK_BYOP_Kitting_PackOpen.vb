Option Explicit On 

Imports System
Imports PSS.Data.Buisness
Imports System.Text

Namespace Gui.TracFoneFulfillmentKit
    Public Class frmTFFK_BYOP_Kitting_PackOpen
        Inherits System.Windows.Forms.Form

        Private _dtOpenWorkorder As DataTable
        Private _strWorkStation As String = ""
        Private _dtSelectedOpenWorkOrder As New DataTable()
        Private _objBYOP_Kitting As PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK_BYOP_Kitting
        Private _bCancelled As Boolean = False

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal dtOpenWorkOrder As DataTable, ByVal strWorkStation As String)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._dtOpenWorkorder = dtOpenWorkOrder
            Me._dtSelectedOpenWorkOrder = dtOpenWorkOrder.Clone
            Me._strWorkStation = strWorkStation
            Me._objBYOP_Kitting = New PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK_BYOP_Kitting()
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                Try
                    Me._objBYOP_Kitting = Nothing
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
        Friend WithEvents btnSelectOrder As System.Windows.Forms.Button
        Friend WithEvents btnClose As System.Windows.Forms.Button
        Friend WithEvents lblTitile As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTFFK_BYOP_Kitting_PackOpen))
            Me.tdgData1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnSelectOrder = New System.Windows.Forms.Button()
            Me.btnClose = New System.Windows.Forms.Button()
            Me.lblTitile = New System.Windows.Forms.Label()
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
            Me.tdgData1.Location = New System.Drawing.Point(8, 48)
            Me.tdgData1.Name = "tdgData1"
            Me.tdgData1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgData1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgData1.PreviewInfo.ZoomFactor = 75
            Me.tdgData1.RowHeight = 15
            Me.tdgData1.Size = New System.Drawing.Size(656, 184)
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
            """1"" HorizontalScrollGroup=""1""><Height>182</Height><CaptionStyle parent=""Style2"" " & _
            "me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""" & _
            "EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><Footer" & _
            "Style parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><H" & _
            "eadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightR" & _
            "ow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle pa" & _
            "rent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Sty" & _
            "le11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me" & _
            "=""Style1"" /><ClientRect>0, 0, 654, 182</ClientRect><BorderSide>0</BorderSide><Bo" & _
            "rderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedSty" & _
            "les><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style " & _
            "parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style par" & _
            "ent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style pare" & _
            "nt=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style pare" & _
            "nt=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""H" & _
            "eading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style par" & _
            "ent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1" & _
            "</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><Cl" & _
            "ientArea>0, 0, 654, 182</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14""" & _
            " /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'btnSelectOrder
            '
            Me.btnSelectOrder.BackColor = System.Drawing.Color.Wheat
            Me.btnSelectOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSelectOrder.Location = New System.Drawing.Point(392, 8)
            Me.btnSelectOrder.Name = "btnSelectOrder"
            Me.btnSelectOrder.Size = New System.Drawing.Size(144, 38)
            Me.btnSelectOrder.TabIndex = 143
            Me.btnSelectOrder.Text = "Select Order"
            '
            'btnClose
            '
            Me.btnClose.BackColor = System.Drawing.Color.Wheat
            Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClose.Location = New System.Drawing.Point(552, 8)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(112, 38)
            Me.btnClose.TabIndex = 144
            Me.btnClose.Text = "Cancel"
            '
            'lblTitile
            '
            Me.lblTitile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTitile.ForeColor = System.Drawing.SystemColors.ControlDarkDark
            Me.lblTitile.Location = New System.Drawing.Point(8, 30)
            Me.lblTitile.Name = "lblTitile"
            Me.lblTitile.Size = New System.Drawing.Size(376, 24)
            Me.lblTitile.TabIndex = 145
            Me.lblTitile.Text = "Open Work Order List"
            '
            'frmTFFK_BYOP_Kitting_PackOpen
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.Beige
            Me.ClientSize = New System.Drawing.Size(672, 246)
            Me.ControlBox = False
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.tdgData1, Me.btnClose, Me.btnSelectOrder, Me.lblTitile})
            Me.Name = "frmTFFK_BYOP_Kitting_PackOpen"
            Me.Text = "Select Open Work Order"
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Public ReadOnly Property getSelectedOpenWorkOrder() As DataTable
            Get
                Return Me._dtSelectedOpenWorkOrder
            End Get
        End Property

        Public ReadOnly Property bIsCancelled() As Boolean
            Get
                Return Me._bCancelled
            End Get
        End Property

        Private Sub frmTFFK_BYOP_Kitting_PackOpen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn

            Try
                Me.CenterToScreen()
                Me.lblTitile.Text = Me.lblTitile.Text & " for Workstation: " & Me._strWorkStation
                With Me.tdgData1
                    .DataSource = Me._dtOpenWorkorder.DefaultView

                    For Each dbgc In .Splits(0).DisplayColumns
                        dbgc.Locked = True
                        dbgc.AutoSize()
                    Next dbgc
                    .Splits(0).DisplayColumns("Pack_WO_ID").Width = 0
                    .Splits(0).DisplayColumns("KMSet_ID").Width = 0
                    .Splits(0).DisplayColumns("Master_Model_ID").Width = 0
                End With

                'Row, Kitting_Setup, Master_Items, WorkStation, WIP_No, Target_Qty, Qty, User, DateTime_Pack, Pack_WO_ID, KMSet_ID
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub frmTFFK_BYOP_Kitting_PackOpen_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Me._bCancelled = True
            Me.Close()
        End Sub

        Private Sub btnSelectOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectOrder.Click
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
            Dim iRow As Integer = 0
            Dim strS As String = ""
            Dim iPack_WO_ID As Integer = 0
            Dim iSelected
            Dim row As DataRow
            Dim dtSelectedPackData As DataTable

            'Row, Kitting_Setup, Master_Items, WorkStation, WIP_No, Target_Qty, Qty, User, DateTime_Pack, Pack_WO_ID, KMSet_ID, Master_Model_ID
            'KP_ID, Pack_WO_ID, UPC, Model_ID, WR_ID, Qty, UserID, DateTime_Pack
            Try
                With Me.tdgData1
                    If .SelectedRows.Count = 1 Then
                        For Each iRow In .SelectedRows 'must be one row
                            iPack_WO_ID = Convert.ToInt32(.Columns("Pack_WO_ID").CellText(iRow))
                            Exit For
                        Next
                        For Each row In Me._dtOpenWorkorder.Rows
                            If iPack_WO_ID = Convert.ToInt32(row("Pack_WO_ID")) Then
                                dtSelectedPackData = Me._objBYOP_Kitting.getKittedPackData(iPack_WO_ID)
                                If dtSelectedPackData.Rows.Count > 0 AndAlso Convert.ToInt32(row("Master_Model_ID")) = Convert.ToInt32(dtSelectedPackData.Rows(0).Item("Model_ID")) Then
                                    Me._dtSelectedOpenWorkOrder.ImportRow(row)
                                    Me._bCancelled = False
                                    Me.Close()
                                ElseIf dtSelectedPackData.Rows.Count > 0 AndAlso Convert.ToInt32(row("Master_Model_ID")) <> Convert.ToInt32(dtSelectedPackData.Rows(0).Item("Model_ID")) Then
                                    MessageBox.Show("Master item of setup info does match it of kitted pack(s) data. See IT.", "Pack Screen", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Else
                                    MessageBox.Show("No kitted pack data. See IT.", "Pack Screen", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                End If
                            End If
                        Next
                    Else
                        MessageBox.Show("Please select one row.", "Pack Screen", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End With

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub btnSelectOrder_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class
End Namespace