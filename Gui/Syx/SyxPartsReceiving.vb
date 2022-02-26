Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui

    Public Class SyxPartsReceiving
        Inherits System.Windows.Forms.Form

        Private _objSyxRec As PSS.Data.Buisness.SyxReceivingShipping
        Private _objSyx As PSS.Data.Buisness.Syx
        Private _booLoadData As Boolean = False

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _objSyxRec = New PSS.Data.Buisness.SyxReceivingShipping()
            _objSyx = New PSS.Data.Buisness.Syx()
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
        Friend WithEvents txtPONumber As System.Windows.Forms.TextBox
        Friend WithEvents Label_PONumber As System.Windows.Forms.Label
        Friend WithEvents Label_POQty As System.Windows.Forms.Label
        Friend WithEvents txtPOQty As System.Windows.Forms.TextBox
        Friend WithEvents btnSubmit As System.Windows.Forms.Button
        Friend WithEvents Label_PartQty As System.Windows.Forms.Label
        Friend WithEvents Label_PartName As System.Windows.Forms.Label
        Friend WithEvents txtPartQty As System.Windows.Forms.TextBox
        Friend WithEvents txtPartName As System.Windows.Forms.TextBox
        Friend WithEvents tc_PartRec As System.Windows.Forms.TabControl
        Friend WithEvents tpPartRec As System.Windows.Forms.TabPage
        Friend WithEvents tpPartUpdate As System.Windows.Forms.TabPage
        Friend WithEvents Label_PartRecTittle As System.Windows.Forms.Label
        Friend WithEvents Panel_PartReceiving As System.Windows.Forms.Panel
        Friend WithEvents Panel_PartUpdate As System.Windows.Forms.Panel
        Friend WithEvents Label_PartUpdateTittle As System.Windows.Forms.Label
        Friend WithEvents dbgReceivedParts As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SyxPartsReceiving))
            Me.Panel_PartReceiving = New System.Windows.Forms.Panel()
            Me.btnSubmit = New System.Windows.Forms.Button()
            Me.Label_PartQty = New System.Windows.Forms.Label()
            Me.txtPartQty = New System.Windows.Forms.TextBox()
            Me.Label_PartName = New System.Windows.Forms.Label()
            Me.txtPartName = New System.Windows.Forms.TextBox()
            Me.Label_POQty = New System.Windows.Forms.Label()
            Me.txtPOQty = New System.Windows.Forms.TextBox()
            Me.Label_PartRecTittle = New System.Windows.Forms.Label()
            Me.Label_PONumber = New System.Windows.Forms.Label()
            Me.txtPONumber = New System.Windows.Forms.TextBox()
            Me.tc_PartRec = New System.Windows.Forms.TabControl()
            Me.tpPartRec = New System.Windows.Forms.TabPage()
            Me.tpPartUpdate = New System.Windows.Forms.TabPage()
            Me.Label_PartUpdateTittle = New System.Windows.Forms.Label()
            Me.Panel_PartUpdate = New System.Windows.Forms.Panel()
            Me.dbgReceivedParts = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Panel_PartReceiving.SuspendLayout()
            Me.tc_PartRec.SuspendLayout()
            Me.tpPartRec.SuspendLayout()
            Me.tpPartUpdate.SuspendLayout()
            CType(Me.dbgReceivedParts, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'Panel_PartReceiving
            '
            Me.Panel_PartReceiving.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(255, Byte))
            Me.Panel_PartReceiving.Controls.AddRange(New System.Windows.Forms.Control() {Me.dbgReceivedParts, Me.btnSubmit, Me.Label_PartQty, Me.txtPartQty, Me.Label_PartName, Me.txtPartName, Me.Label_POQty, Me.txtPOQty, Me.Label_PartRecTittle, Me.Label_PONumber, Me.txtPONumber})
            Me.Panel_PartReceiving.ForeColor = System.Drawing.Color.Green
            Me.Panel_PartReceiving.Location = New System.Drawing.Point(16, 16)
            Me.Panel_PartReceiving.Name = "Panel_PartReceiving"
            Me.Panel_PartReceiving.Size = New System.Drawing.Size(704, 392)
            Me.Panel_PartReceiving.TabIndex = 0
            '
            'btnSubmit
            '
            Me.btnSubmit.BackColor = System.Drawing.Color.Green
            Me.btnSubmit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSubmit.ForeColor = System.Drawing.Color.White
            Me.btnSubmit.Location = New System.Drawing.Point(176, 168)
            Me.btnSubmit.Name = "btnSubmit"
            Me.btnSubmit.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnSubmit.Size = New System.Drawing.Size(128, 30)
            Me.btnSubmit.TabIndex = 9
            Me.btnSubmit.Text = "Submit"
            '
            'Label_PartQty
            '
            Me.Label_PartQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_PartQty.ForeColor = System.Drawing.Color.White
            Me.Label_PartQty.Location = New System.Drawing.Point(16, 136)
            Me.Label_PartQty.Name = "Label_PartQty"
            Me.Label_PartQty.Size = New System.Drawing.Size(72, 23)
            Me.Label_PartQty.TabIndex = 8
            Me.Label_PartQty.Text = "Part Qty :"
            Me.Label_PartQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtPartQty
            '
            Me.txtPartQty.Location = New System.Drawing.Point(96, 136)
            Me.txtPartQty.Name = "txtPartQty"
            Me.txtPartQty.Size = New System.Drawing.Size(208, 20)
            Me.txtPartQty.TabIndex = 7
            Me.txtPartQty.Text = ""
            '
            'Label_PartName
            '
            Me.Label_PartName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_PartName.ForeColor = System.Drawing.Color.White
            Me.Label_PartName.Location = New System.Drawing.Point(16, 104)
            Me.Label_PartName.Name = "Label_PartName"
            Me.Label_PartName.Size = New System.Drawing.Size(72, 23)
            Me.Label_PartName.TabIndex = 6
            Me.Label_PartName.Text = "Part Name :"
            Me.Label_PartName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtPartName
            '
            Me.txtPartName.Location = New System.Drawing.Point(96, 104)
            Me.txtPartName.Name = "txtPartName"
            Me.txtPartName.Size = New System.Drawing.Size(208, 20)
            Me.txtPartName.TabIndex = 5
            Me.txtPartName.Text = ""
            '
            'Label_POQty
            '
            Me.Label_POQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_POQty.ForeColor = System.Drawing.Color.White
            Me.Label_POQty.Location = New System.Drawing.Point(16, 72)
            Me.Label_POQty.Name = "Label_POQty"
            Me.Label_POQty.Size = New System.Drawing.Size(72, 23)
            Me.Label_POQty.TabIndex = 4
            Me.Label_POQty.Text = "PO Qty :"
            Me.Label_POQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtPOQty
            '
            Me.txtPOQty.Location = New System.Drawing.Point(96, 72)
            Me.txtPOQty.Name = "txtPOQty"
            Me.txtPOQty.Size = New System.Drawing.Size(208, 20)
            Me.txtPOQty.TabIndex = 3
            Me.txtPOQty.Text = ""
            '
            'Label_PartRecTittle
            '
            Me.Label_PartRecTittle.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(255, Byte))
            Me.Label_PartRecTittle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_PartRecTittle.ForeColor = System.Drawing.Color.White
            Me.Label_PartRecTittle.Location = New System.Drawing.Point(8, 8)
            Me.Label_PartRecTittle.Name = "Label_PartRecTittle"
            Me.Label_PartRecTittle.Size = New System.Drawing.Size(688, 24)
            Me.Label_PartRecTittle.TabIndex = 2
            Me.Label_PartRecTittle.Text = "Syx Parts Receiving"
            Me.Label_PartRecTittle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label_PONumber
            '
            Me.Label_PONumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_PONumber.ForeColor = System.Drawing.Color.White
            Me.Label_PONumber.Location = New System.Drawing.Point(8, 40)
            Me.Label_PONumber.Name = "Label_PONumber"
            Me.Label_PONumber.Size = New System.Drawing.Size(80, 23)
            Me.Label_PONumber.TabIndex = 1
            Me.Label_PONumber.Text = "PO Number :"
            Me.Label_PONumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtPONumber
            '
            Me.txtPONumber.Location = New System.Drawing.Point(96, 40)
            Me.txtPONumber.Name = "txtPONumber"
            Me.txtPONumber.Size = New System.Drawing.Size(208, 20)
            Me.txtPONumber.TabIndex = 0
            Me.txtPONumber.Text = ""
            '
            'tc_PartRec
            '
            Me.tc_PartRec.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpPartRec, Me.tpPartUpdate})
            Me.tc_PartRec.Location = New System.Drawing.Point(8, 16)
            Me.tc_PartRec.Name = "tc_PartRec"
            Me.tc_PartRec.SelectedIndex = 0
            Me.tc_PartRec.Size = New System.Drawing.Size(736, 456)
            Me.tc_PartRec.TabIndex = 1
            '
            'tpPartRec
            '
            Me.tpPartRec.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(255, Byte))
            Me.tpPartRec.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel_PartReceiving})
            Me.tpPartRec.Location = New System.Drawing.Point(4, 22)
            Me.tpPartRec.Name = "tpPartRec"
            Me.tpPartRec.Size = New System.Drawing.Size(728, 430)
            Me.tpPartRec.TabIndex = 0
            Me.tpPartRec.Text = "Part Receiving"
            '
            'tpPartUpdate
            '
            Me.tpPartUpdate.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(128, Byte))
            Me.tpPartUpdate.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label_PartUpdateTittle, Me.Panel_PartUpdate})
            Me.tpPartUpdate.Location = New System.Drawing.Point(4, 22)
            Me.tpPartUpdate.Name = "tpPartUpdate"
            Me.tpPartUpdate.Size = New System.Drawing.Size(728, 430)
            Me.tpPartUpdate.TabIndex = 1
            Me.tpPartUpdate.Text = "Part Update"
            '
            'Label_PartUpdateTittle
            '
            Me.Label_PartUpdateTittle.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(128, Byte))
            Me.Label_PartUpdateTittle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_PartUpdateTittle.ForeColor = System.Drawing.Color.White
            Me.Label_PartUpdateTittle.Location = New System.Drawing.Point(24, 24)
            Me.Label_PartUpdateTittle.Name = "Label_PartUpdateTittle"
            Me.Label_PartUpdateTittle.Size = New System.Drawing.Size(680, 40)
            Me.Label_PartUpdateTittle.TabIndex = 3
            Me.Label_PartUpdateTittle.Text = "Syx Parts Update is under construction"
            Me.Label_PartUpdateTittle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Panel_PartUpdate
            '
            Me.Panel_PartUpdate.Location = New System.Drawing.Point(24, 104)
            Me.Panel_PartUpdate.Name = "Panel_PartUpdate"
            Me.Panel_PartUpdate.Size = New System.Drawing.Size(680, 288)
            Me.Panel_PartUpdate.TabIndex = 0
            '
            'dbgReceivedParts
            '
            Me.dbgReceivedParts.AllowColMove = False
            Me.dbgReceivedParts.AllowColSelect = False
            Me.dbgReceivedParts.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
            Me.dbgReceivedParts.AllowSort = False
            Me.dbgReceivedParts.AllowUpdate = False
            Me.dbgReceivedParts.AllowUpdateOnBlur = False
            Me.dbgReceivedParts.AlternatingRows = True
            Me.dbgReceivedParts.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgReceivedParts.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
            Me.dbgReceivedParts.Caption = "Received Parts"
            Me.dbgReceivedParts.CaptionHeight = 19
            Me.dbgReceivedParts.CollapseColor = System.Drawing.Color.White
            Me.dbgReceivedParts.ExpandColor = System.Drawing.Color.White
            Me.dbgReceivedParts.FilterBar = True
            Me.dbgReceivedParts.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dbgReceivedParts.ForeColor = System.Drawing.Color.White
            Me.dbgReceivedParts.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgReceivedParts.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dbgReceivedParts.Location = New System.Drawing.Point(312, 40)
            Me.dbgReceivedParts.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.dbgReceivedParts.Name = "dbgReceivedParts"
            Me.dbgReceivedParts.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgReceivedParts.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgReceivedParts.PreviewInfo.ZoomFactor = 75
            Me.dbgReceivedParts.RowHeight = 20
            Me.dbgReceivedParts.Size = New System.Drawing.Size(384, 336)
            Me.dbgReceivedParts.TabIndex = 26
            Me.dbgReceivedParts.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:SteelBlue;}Sele" & _
            "cted{ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Whi" & _
            "te;BackColor:InactiveCaption;}FilterBar{Font:Microsoft Sans Serif, 6.75pt, style" & _
            "=Bold;ForeColor:Black;BackColor:White;}Footer{}Caption{AlignHorz:Center;ForeColo" & _
            "r:White;BackColor:SteelBlue;}Style9{}Normal{Font:Microsoft Sans Serif, 8.25pt, s" & _
            "tyle=Bold;BackColor:LightSteelBlue;ForeColor:White;AlignVert:Center;}HighlightRo" & _
            "w{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddRow{ForeColor:Black;B" & _
            "ackColor:LightSteelBlue;}RecordSelector{AlignImage:Center;ForeColor:White;}Style" & _
            "13{}Heading{Wrap:True;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Ce" & _
            "nter;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:Blue;BackColor:Control" & _
            ";}Style8{}Style10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style16{}Style17{}S" & _
            "tyle1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""Fals" & _
            "e"" AllowColSelect=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""Tru" & _
            "e"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar" & _
            "=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=" & _
            """17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>313</Height><Capt" & _
            "ionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5""" & _
            " /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBa" & _
            "r"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=" & _
            """Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRo" & _
            "wStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""" & _
            "Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent" & _
            "=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" />" & _
            "<Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 19, 380, 313</ClientRect><Bo" & _
            "rderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.Me" & _
            "rgeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Norm" & _
            "al"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading""" & _
            " me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" m" & _
            "e=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""H" & _
            "ighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""" & _
            "OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" m" & _
            "e=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1" & _
            "</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>" & _
            "17</DefaultRecSelWidth><ClientArea>0, 0, 380, 332</ClientArea><PrintPageHeaderSt" & _
            "yle parent="""" me=""Style16"" /><PrintPageFooterStyle parent="""" me=""Style17"" /></Bl" & _
            "ob>"
            '
            'SyxPartsReceiving
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(768, 494)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.tc_PartRec})
            Me.Name = "SyxPartsReceiving"
            Me.Text = "Syx Parts Receiving"
            Me.Panel_PartReceiving.ResumeLayout(False)
            Me.tc_PartRec.ResumeLayout(False)
            Me.tpPartRec.ResumeLayout(False)
            Me.tpPartUpdate.ResumeLayout(False)
            CType(Me.dbgReceivedParts, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region




        '****************************************************************************************************
        Private Sub SyxPartsReceiving_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Me.txtPONumber.Focus()
            Me.btnSubmit.Visible = False
        End Sub

        '****************************************************************************************************

        Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click

            Me._objSyx.InsertSyxParts(Me.txtPONumber.Text, Me.txtPOQty.Text, Me.txtPartName.Text, Me.txtPartQty.Text)
            Me.LoadPartsInfo(Me.txtPONumber.Text)
            Me.txtPartName.Text = ""
            Me.txtPartQty.Text = ""
            Me.txtPartName.Focus()
            Me.btnSubmit.Visible = False

        End Sub

        '****************************************************************************************************
        Private Sub TextBox_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPONumber.KeyUp, txtPOQty.KeyUp, txtPartQty.KeyUp, txtPartName.KeyUp


            Try

                If e.KeyCode = Keys.Enter And sender.name = "txtPONumber" Then

                    Me.txtPONumber.Text = Me.txtPONumber.Text.Trim.ToUpper
                    If Me.txtPONumber.Text <> "" Then
                        Me.txtPOQty.SelectAll() : Me.txtPOQty.Focus()
                    Else
                        MessageBox.Show("The Please enter PO number ...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If

                ElseIf e.KeyCode = Keys.Enter And sender.name = "txtPOQty" Then

                    If Me.txtPOQty.Text = "" Then
                        MessageBox.Show("Please enter PO quantity...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf IsNumeric(Me.txtPOQty.Text) = True AndAlso CInt(Me.txtPOQty.Text) > 0 Then
                        Me.txtPartName.SelectAll() : Me.txtPartName.Focus()
                    Else
                        MessageBox.Show("The PO quantity entered: " & Me.txtPOQty.Text & " is invalid ! Please enter a number greater than zero...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtPOQty.Text = ""
                        Me.txtPOQty.Focus()
                    End If
                ElseIf e.KeyCode = Keys.Enter And sender.name = "txtPartName" Then

                    Me.txtPartName.Text = Me.txtPartName.Text.Trim.ToUpper
                    If Me.txtPartName.Text <> "" Then
                        Me.txtPartQty.SelectAll() : Me.txtPartQty.Focus()
                    Else
                        MessageBox.Show("The Please enter part name ...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If

                ElseIf e.KeyCode = Keys.Enter And sender.name = "txtPartQty" Then

                    If Me.txtPartQty.Text = "" Then
                        MessageBox.Show("Please enter part quantity...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf IsNumeric(Me.txtPartQty.Text) = True AndAlso CInt(Me.txtPartQty.Text) > 0 Then
                        Me.btnSubmit.Focus()
                    Else
                        MessageBox.Show("The part quantity entered: " & Me.txtPartQty.Text & " is invalid ! Please enter a number greater than zero...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtPartQty.Text = ""
                        Me.txtPartQty.Focus()
                    End If

                End If

                'Made Submit button visible
                If Me.txtPONumber.Text <> "" And Me.txtPOQty.Text <> "" And Me.txtPartName.Text <> "" And Me.txtPartQty.Text <> "" Then
                    If IsNumeric(Me.txtPOQty.Text) = True And IsNumeric(Me.txtPartQty.Text) = True Then
                        Me.btnSubmit.Visible = True
                    Else
                        Me.btnSubmit.Visible = False
                    End If

                Else
                    Me.btnSubmit.Visible = False
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "TextBox_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try


        End Sub
        '*************************************************************************************************************
        Private Sub LoadPartsInfo(ByVal PO_Number As String)
            Dim dt As DataTable
            Dim i As Integer
            Try

                dt = Me._objSyx.GetPartsInfoByPO(PO_Number)
                If dt.Rows.Count > 0 Then
                    With Me.dbgReceivedParts
                        .DataSource = Nothing
                        .DataSource = dt.DefaultView

                        For i = 0 To dt.Columns.Count - 1
                            'Make some columns invisible
                            .Splits(0).DisplayColumns(i).Visible = False
                        Next i
                        .Splits(0).DisplayColumns("PO_Number").Width = 70
                        .Splits(0).DisplayColumns("PO_Qty").Width = 50
                        .Splits(0).DisplayColumns("Part_Name").Width = 150
                        .Splits(0).DisplayColumns("Part_Qty").Width = 50

                        .Splits(0).DisplayColumns("PO_Number").Visible = True
                        .Splits(0).DisplayColumns("PO_Qty").Visible = True
                        .Splits(0).DisplayColumns("Part_Name").Visible = True
                        .Splits(0).DisplayColumns("Part_Qty").Visible = True

                    End With
                    Me.dbgReceivedParts.Visible = True
                Else
                    Me.dbgReceivedParts.Visible = False
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "LoadPartsInfo", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '****************************************************************************************************


    End Class

End Namespace


