Option Explicit On 

Imports PSS.Data
Imports PSS.Core

Namespace Gui.Nespresso

    Public Class frmManageRecycleModel
        Inherits System.Windows.Forms.Form
        Private _objNespresso As New PSS.Data.Buisness.Nespresso.Nespresso()

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call

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
        Friend WithEvents dbgRecycleModel As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btRecycle As System.Windows.Forms.Button
        Friend WithEvents btNotRecycle As System.Windows.Forms.Button
        Friend WithEvents lblTittle As System.Windows.Forms.Label
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmManageRecycleModel))
            Me.dbgRecycleModel = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.lblTittle = New System.Windows.Forms.Label()
            Me.btRecycle = New System.Windows.Forms.Button()
            Me.btNotRecycle = New System.Windows.Forms.Button()
            Me.Panel1 = New System.Windows.Forms.Panel()
            CType(Me.dbgRecycleModel, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'dbgRecycleModel
            '
            Me.dbgRecycleModel.AllowUpdate = False
            Me.dbgRecycleModel.AlternatingRows = True
            Me.dbgRecycleModel.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgRecycleModel.Caption = "Nespresso Models"
            Me.dbgRecycleModel.CaptionHeight = 17
            Me.dbgRecycleModel.FilterBar = True
            Me.dbgRecycleModel.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgRecycleModel.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dbgRecycleModel.Location = New System.Drawing.Point(24, 8)
            Me.dbgRecycleModel.Name = "dbgRecycleModel"
            Me.dbgRecycleModel.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgRecycleModel.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgRecycleModel.PreviewInfo.ZoomFactor = 75
            Me.dbgRecycleModel.RowHeight = 15
            Me.dbgRecycleModel.Size = New System.Drawing.Size(360, 320)
            Me.dbgRecycleModel.TabIndex = 10
            Me.dbgRecycleModel.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{Font:Tahoma, 12pt, style=Bold;AlignHorz:Center;ForeColor:Purple" & _
            ";BackColor:Control;}Normal{Font:Tahoma, 9.75pt, style=Bold;BackColor:SteelBlue;}" & _
            "Selected{ForeColor:HighlightText;BackColor:Highlight;}Editor{}Style18{}Style19{}" & _
            "Style14{}Style15{}Style16{}Style17{}Style10{AlignHorz:Near;}Style11{}OddRow{Back" & _
            "Color:LightSteelBlue;}Style13{}Style12{}HighlightRow{ForeColor:HighlightText;Bac" & _
            "kColor:Highlight;}RecordSelector{AlignImage:Center;}Footer{}Style21{}Style20{}In" & _
            "active{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}EvenRow{BackColo" & _
            "r:NavajoWhite;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;For" & _
            "eColor:ControlText;AlignVert:Center;}FilterBar{Font:Microsoft Sans Serif, 9.75pt" & _
            ", style=Bold;ForeColor:Red;BackColor:White;}Style4{}Style9{}Style8{}Style5{}Grou" & _
            "p{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style7{}Style6" & _
            "{}Style1{}Style3{}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView" & _
            " Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" " & _
            "ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordS" & _
            "electorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGr" & _
            "oup=""1""><Height>292</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><Editor" & _
            "Style parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /" & _
            "><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" " & _
            "me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""He" & _
            "ading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><Ina" & _
            "ctiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Styl" & _
            "e9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle" & _
            " parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRec" & _
            "t>0, 17, 356, 292</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</Bor" & _
            "derStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" " & _
            "me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""" & _
            "Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Ina" & _
            "ctive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Edito" & _
            "r"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenR" & _
            "ow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSel" & _
            "ector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Gro" & _
            "up"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>" & _
            "None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 356, 3" & _
            "16</ClientArea><PrintPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterSt" & _
            "yle parent="""" me=""Style21"" /></Blob>"
            '
            'lblTittle
            '
            Me.lblTittle.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.lblTittle.BackColor = System.Drawing.Color.Black
            Me.lblTittle.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTittle.ForeColor = System.Drawing.Color.Yellow
            Me.lblTittle.Name = "lblTittle"
            Me.lblTittle.Size = New System.Drawing.Size(800, 45)
            Me.lblTittle.TabIndex = 11
            Me.lblTittle.Text = "Manage Nespresso Recycle Models"
            Me.lblTittle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btRecycle
            '
            Me.btRecycle.BackColor = System.Drawing.SystemColors.Desktop
            Me.btRecycle.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btRecycle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
            Me.btRecycle.Location = New System.Drawing.Point(256, 336)
            Me.btRecycle.Name = "btRecycle"
            Me.btRecycle.Size = New System.Drawing.Size(128, 32)
            Me.btRecycle.TabIndex = 12
            Me.btRecycle.Text = "Recycle"
            '
            'btNotRecycle
            '
            Me.btNotRecycle.BackColor = System.Drawing.Color.Olive
            Me.btNotRecycle.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btNotRecycle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
            Me.btNotRecycle.Location = New System.Drawing.Point(24, 336)
            Me.btNotRecycle.Name = "btNotRecycle"
            Me.btNotRecycle.Size = New System.Drawing.Size(128, 32)
            Me.btNotRecycle.TabIndex = 13
            Me.btNotRecycle.Text = "Not Recycle"
            '
            'Panel1
            '
            Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.dbgRecycleModel, Me.btRecycle, Me.btNotRecycle})
            Me.Panel1.Location = New System.Drawing.Point(8, 64)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(408, 376)
            Me.Panel1.TabIndex = 14
            '
            'frmManageRecycleModel
            '
            Me.AutoScale = False
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(792, 466)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel1, Me.lblTittle})
            Me.Name = "frmManageRecycleModel"
            Me.Text = "frmManageRecycleModel"
            CType(Me.dbgRecycleModel, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmManageRecycleModel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable

            Try
                PSS.Core.Highlight.SetHighLight(Me)
                PopulateRecycleModel()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmManageRecycleModel_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try

        End Sub

        Private Sub PopulateRecycleModel()
            Dim dt As DataTable
            Try
                Me.dbgRecycleModel.DataSource = Nothing
                dt = Me._objNespresso.GetRecycleModels()
                With Me.dbgRecycleModel
                    .DataSource = dt.DefaultView
                    .Splits(0).DisplayColumns("Model_ID").Width = 75
                    .Splits(0).DisplayColumns("Model Description").Width = 200
                    .Splits(0).DisplayColumns("Recycle").Width = 50

                End With
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "PopulateDeptDocDBG", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        Private Sub btSetRecycle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRecycle.Click, btNotRecycle.Click
            Dim strData As String
            Dim i, iRow As Integer
            Dim modelid As Integer

            Try
                If Me.dbgRecycleModel.SelectedRows.Count > 0 Then
                    'loop through each selected row
                    For Each iRow In Me.dbgRecycleModel.SelectedRows
                        modelid = Me.dbgRecycleModel.Columns(0).CellValue(iRow)
                        If sender.name = "btRecycle" Then
                            i = _objNespresso.UpdateRecycleModels(modelid, 1)
                        ElseIf sender.name = "btNotRecycle" Then
                            i = _objNespresso.UpdateRecycleModels(modelid, 0)
                        End If
                    Next iRow
                    PopulateRecycleModel()
                Else
                    MessageBox.Show("Please select rows to update.", "Selected Row Required ", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "btSetRecycle_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try


        End Sub
    End Class
End Namespace