Option Explicit On 

Imports PSS.Data
Imports PSS.Core

Public Class frmAquisModelSetup
    Inherits System.Windows.Forms.Form
    Private _objMess As New PSS.Data.Buisness.Messaging()
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
    Friend WithEvents lblTittle As System.Windows.Forms.Label
    Friend WithEvents dbgModel As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnActive As System.Windows.Forms.Button
    Friend WithEvents btnClip As System.Windows.Forms.Button
    Friend WithEvents btnHolster As System.Windows.Forms.Button
    Friend WithEvents btnEOL As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAquisModelSetup))
        Me.lblTittle = New System.Windows.Forms.Label()
        Me.dbgModel = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btnClip = New System.Windows.Forms.Button()
        Me.btnHolster = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnEOL = New System.Windows.Forms.Button()
        Me.btnActive = New System.Windows.Forms.Button()
        CType(Me.dbgModel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTittle
        '
        Me.lblTittle.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblTittle.BackColor = System.Drawing.Color.Black
        Me.lblTittle.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTittle.ForeColor = System.Drawing.Color.Yellow
        Me.lblTittle.Location = New System.Drawing.Point(-232, 0)
        Me.lblTittle.Name = "lblTittle"
        Me.lblTittle.Size = New System.Drawing.Size(1268, 45)
        Me.lblTittle.TabIndex = 12
        Me.lblTittle.Text = "Aquis Models Setup"
        Me.lblTittle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dbgModel
        '
        Me.dbgModel.AllowUpdate = False
        Me.dbgModel.AlternatingRows = True
        Me.dbgModel.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.dbgModel.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.dbgModel.Caption = "Models"
        Me.dbgModel.CaptionHeight = 17
        Me.dbgModel.FilterBar = True
        Me.dbgModel.GroupByCaption = "Drag a column header here to group by that column"
        Me.dbgModel.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.dbgModel.Location = New System.Drawing.Point(24, 8)
        Me.dbgModel.Name = "dbgModel"
        Me.dbgModel.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgModel.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgModel.PreviewInfo.ZoomFactor = 75
        Me.dbgModel.RowHeight = 15
        Me.dbgModel.Size = New System.Drawing.Size(352, 360)
        Me.dbgModel.TabIndex = 13
        Me.dbgModel.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Caption{Font:Tahoma, 12pt, style=Bold;AlignHorz:Center;ForeColor:Purple" & _
        ";BackColor:Control;}Normal{Font:Tahoma, 9.75pt, style=Bold;BackColor:SteelBlue;}" & _
        "Selected{ForeColor:HighlightText;BackColor:Highlight;}Editor{}Style18{}Style19{}" & _
        "Style14{}Style15{}Style16{}Style17{}Style10{AlignHorz:Near;}Style11{}OddRow{Back" & _
        "Color:LightSteelBlue;}Style13{}Style12{}HighlightRow{ForeColor:HighlightText;Bac" & _
        "kColor:Highlight;}RecordSelector{AlignImage:Center;}Footer{}Style21{}Style20{}In" & _
        "active{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}EvenRow{BackColo" & _
        "r:NavajoWhite;}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;Fore" & _
        "Color:ControlText;BackColor:Control;}FilterBar{Font:Microsoft Sans Serif, 9.75pt" & _
        ", style=Bold;ForeColor:Red;BackColor:White;}Style4{}Style9{}Style8{}Style5{}Grou" & _
        "p{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style7{}Style6" & _
        "{}Style1{}Style3{}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView" & _
        " Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" " & _
        "ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordS" & _
        "electorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGr" & _
        "oup=""1""><Height>339</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><Editor" & _
        "Style parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /" & _
        "><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" " & _
        "me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""He" & _
        "ading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><Ina" & _
        "ctiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Styl" & _
        "e9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle" & _
        " parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRec" & _
        "t>0, 17, 348, 339</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</Bor" & _
        "derStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" " & _
        "me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""" & _
        "Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Ina" & _
        "ctive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Edito" & _
        "r"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenR" & _
        "ow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSel" & _
        "ector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Gro" & _
        "up"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>" & _
        "None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 348, 3" & _
        "56</ClientArea><PrintPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterSt" & _
        "yle parent="""" me=""Style21"" /></Blob>"
        '
        'btnClip
        '
        Me.btnClip.BackColor = System.Drawing.SystemColors.Desktop
        Me.btnClip.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClip.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnClip.Location = New System.Drawing.Point(584, 56)
        Me.btnClip.Name = "btnClip"
        Me.btnClip.Size = New System.Drawing.Size(128, 32)
        Me.btnClip.TabIndex = 14
        Me.btnClip.Text = "Clip"
        '
        'btnHolster
        '
        Me.btnHolster.BackColor = System.Drawing.Color.Olive
        Me.btnHolster.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHolster.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnHolster.Location = New System.Drawing.Point(400, 56)
        Me.btnHolster.Name = "btnHolster"
        Me.btnHolster.Size = New System.Drawing.Size(128, 32)
        Me.btnHolster.TabIndex = 15
        Me.btnHolster.Text = "Holster"
        '
        'Panel1
        '
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnEOL, Me.btnActive, Me.dbgModel, Me.btnHolster, Me.btnClip})
        Me.Panel1.Location = New System.Drawing.Point(8, 48)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(736, 376)
        Me.Panel1.TabIndex = 16
        '
        'btnEOL
        '
        Me.btnEOL.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(0, Byte))
        Me.btnEOL.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEOL.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnEOL.Location = New System.Drawing.Point(400, 200)
        Me.btnEOL.Name = "btnEOL"
        Me.btnEOL.Size = New System.Drawing.Size(128, 32)
        Me.btnEOL.TabIndex = 17
        Me.btnEOL.Text = "End Of Life"
        '
        'btnActive
        '
        Me.btnActive.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(192, Byte), CType(0, Byte))
        Me.btnActive.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActive.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnActive.Location = New System.Drawing.Point(584, 200)
        Me.btnActive.Name = "btnActive"
        Me.btnActive.Size = New System.Drawing.Size(128, 32)
        Me.btnActive.TabIndex = 16
        Me.btnActive.Text = "Active"
        '
        'frmAquisModelSetup
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(760, 478)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel1, Me.lblTittle})
        Me.Name = "frmAquisModelSetup"
        Me.Text = "frmAquisModelSetup"
        CType(Me.dbgModel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmAquisModelCriteria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim dt As DataTable

        Try
            PSS.Core.Highlight.SetHighLight(Me)
            PopulateModel()

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "frmManageRecycleModel_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)
        End Try
    End Sub
    '******************************************************************

    Private Sub PopulateModel()
        Dim dt As DataTable
        Try
            Me.dbgModel.DataSource = Nothing
            dt = Me._objMess.GetModelsCriteria()
            With Me.dbgModel
                .DataSource = dt.DefaultView
                .Splits(0).DisplayColumns("Model_ID").Width = 50
                .Splits(0).DisplayColumns("Model Description").Width = 125
                .Splits(0).DisplayColumns("Holder").Width = 60
                .Splits(0).DisplayColumns("EndOfLife").Width = 60

                '.Splits(0).DisplayColumns("Model_ID").Visible = False
            End With
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "PopulateModel", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)
        End Try
    End Sub
    '******************************************************************

    Private Sub btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHolster.Click, btnClip.Click, btnEOL.Click, btnActive.Click
        Dim strData As String
        Dim i, iRow As Integer
        Dim modelid As Integer

        Try
            If Me.dbgModel.SelectedRows.Count > 0 Then
                'loop through each selected row
                For Each iRow In Me.dbgModel.SelectedRows
                    modelid = Me.dbgModel.Columns(0).CellValue(iRow)
                    If sender.name = "btnHolster" Then
                        i = Me._objMess.UpdateModelHolder(_objMess.Aquis_Cust_ID, modelid, 3340)
                    ElseIf sender.name = "btnClip" Then
                        i = Me._objMess.UpdateModelHolder(_objMess.Aquis_Cust_ID, modelid, 3341)
                    ElseIf sender.name = "btnEOL" Then
                        i = Me._objMess.UpdateModelEndOfLife(_objMess.Aquis_Cust_ID, modelid, 1)
                    ElseIf sender.name = "btnActive" Then
                        i = Me._objMess.UpdateModelEndOfLife(_objMess.Aquis_Cust_ID, modelid, 0)
                    End If
                Next iRow
                PopulateModel()
            Else
                MessageBox.Show("Please select rows to update.", "Selected Row Required ", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "bt_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try

    End Sub
    '******************************************************************

End Class
