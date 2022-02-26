Imports PSS.Core
Imports PSS.Data

Namespace Gui.codes

    Public Class LaborLvl
        Inherits System.Windows.Forms.Form

        Private xCount As Integer
        Private dtLaborLvl, dtManufacturer, dtProduct, dtDisplay As DataTable
        Private r As DataRow

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
        Friend WithEvents displayGrid As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnNew As System.Windows.Forms.Button
        Friend WithEvents grpRecord As System.Windows.Forms.GroupBox
        Friend WithEvents txtID As System.Windows.Forms.TextBox
        Friend WithEvents btnDeleteRecord As System.Windows.Forms.Button
        Friend WithEvents btnAddRecord As System.Windows.Forms.Button
        Friend WithEvents txtLongDesc As System.Windows.Forms.TextBox
        Friend WithEvents lblDescription As System.Windows.Forms.Label
        Friend WithEvents btnCancelRecord As System.Windows.Forms.Button
        Friend WithEvents lblLaborLvl As System.Windows.Forms.Label
        Friend WithEvents cboLaborLvl As System.Windows.Forms.ComboBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(LaborLvl))
            Dim GridLines1 As C1.Win.C1TrueDBGrid.Util.GridLines = New C1.Win.C1TrueDBGrid.Util.GridLines()
            Me.displayGrid = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnNew = New System.Windows.Forms.Button()
            Me.grpRecord = New System.Windows.Forms.GroupBox()
            Me.txtID = New System.Windows.Forms.TextBox()
            Me.btnDeleteRecord = New System.Windows.Forms.Button()
            Me.btnAddRecord = New System.Windows.Forms.Button()
            Me.txtLongDesc = New System.Windows.Forms.TextBox()
            Me.lblDescription = New System.Windows.Forms.Label()
            Me.btnCancelRecord = New System.Windows.Forms.Button()
            Me.lblLaborLvl = New System.Windows.Forms.Label()
            Me.cboLaborLvl = New System.Windows.Forms.ComboBox()
            CType(Me.displayGrid, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grpRecord.SuspendLayout()
            Me.SuspendLayout()
            '
            'displayGrid
            '
            Me.displayGrid.AllowFilter = True
            Me.displayGrid.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows
            Me.displayGrid.AllowSort = True
            Me.displayGrid.AlternatingRows = True
            Me.displayGrid.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.displayGrid.CaptionHeight = 17
            Me.displayGrid.CollapseColor = System.Drawing.Color.Black
            Me.displayGrid.DataChanged = False
            'Me.displayGrid.DeadAreaBackColor = System.Drawing.Color.Empty
            'Commented out by Asif on 10/16/2006
            Me.displayGrid.BackColor = System.Drawing.Color.Empty

            Me.displayGrid.ExpandColor = System.Drawing.Color.Black
            Me.displayGrid.GroupByCaption = "Drag a column header here to group by that column"
            Me.displayGrid.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.displayGrid.Location = New System.Drawing.Point(328, 83)
            Me.displayGrid.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
            Me.displayGrid.Name = "displayGrid"
            Me.displayGrid.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.displayGrid.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.displayGrid.PreviewInfo.ZoomFactor = 75
            Me.displayGrid.PrintInfo.ShowOptionsDialog = False
            Me.displayGrid.RecordSelectorWidth = 16
            GridLines1.Color = System.Drawing.Color.DarkGray
            GridLines1.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single
            Me.displayGrid.RowDivider = GridLines1
            Me.displayGrid.RowHeight = 15
            Me.displayGrid.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.displayGrid.ScrollTips = False
            Me.displayGrid.Size = New System.Drawing.Size(312, 352)
            Me.displayGrid.TabIndex = 17
            Me.displayGrid.Text = "C1TrueDBGrid1"
            Me.displayGrid.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Normal{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style9{}Od" & _
            "dRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:True;AlignVert:Center;Borde" & _
            "r:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{Al" & _
            "ignHorz:Near;}Style11{}Style12{}Style13{}Style1{}</Data></Styles><Splits><C1.Win" & _
            ".C1TrueDBGrid.MergeView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" Co" & _
            "lumnCaptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" R" & _
            "ecordSelectorWidth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalSc" & _
            "rollGroup=""1""><ClientRect>0, 0, 308, 348</ClientRect><BorderSide>0</BorderSide><" & _
            "CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Sty" & _
            "le5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""Filt" & _
            "erBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle par" & _
            "ent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLig" & _
            "htRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" " & _
            "me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle pa" & _
            "rent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6" & _
            """ /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1TrueDBGrid.MergeView></Split" & _
            "s><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading" & _
            """ /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /" & _
            "><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" />" & _
            "<Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" />" & _
            "<Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Styl" & _
            "e parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /" & _
            "><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><h" & _
            "orzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>16</DefaultRecS" & _
            "elWidth><ClientArea>0, 0, 308, 348</ClientArea></Blob>"
            '
            'btnNew
            '
            Me.btnNew.Location = New System.Drawing.Point(224, 113)
            Me.btnNew.Name = "btnNew"
            Me.btnNew.Size = New System.Drawing.Size(88, 23)
            Me.btnNew.TabIndex = 15
            Me.btnNew.Text = "NEW"
            '
            'grpRecord
            '
            Me.grpRecord.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtID, Me.btnDeleteRecord, Me.btnAddRecord, Me.txtLongDesc, Me.lblDescription, Me.btnCancelRecord})
            Me.grpRecord.Location = New System.Drawing.Point(32, 169)
            Me.grpRecord.Name = "grpRecord"
            Me.grpRecord.Size = New System.Drawing.Size(280, 264)
            Me.grpRecord.TabIndex = 16
            Me.grpRecord.TabStop = False
            Me.grpRecord.Text = "Add/ Update/ Delete"
            '
            'txtID
            '
            Me.txtID.BackColor = System.Drawing.Color.SteelBlue
            Me.txtID.ForeColor = System.Drawing.Color.White
            Me.txtID.Location = New System.Drawing.Point(216, 16)
            Me.txtID.Name = "txtID"
            Me.txtID.Size = New System.Drawing.Size(56, 20)
            Me.txtID.TabIndex = 99
            Me.txtID.TabStop = False
            Me.txtID.Text = ""
            Me.txtID.Visible = False
            '
            'btnDeleteRecord
            '
            Me.btnDeleteRecord.Location = New System.Drawing.Point(112, 224)
            Me.btnDeleteRecord.Name = "btnDeleteRecord"
            Me.btnDeleteRecord.Size = New System.Drawing.Size(72, 23)
            Me.btnDeleteRecord.TabIndex = 8
            Me.btnDeleteRecord.Text = "DELETE"
            '
            'btnAddRecord
            '
            Me.btnAddRecord.Location = New System.Drawing.Point(16, 224)
            Me.btnAddRecord.Name = "btnAddRecord"
            Me.btnAddRecord.Size = New System.Drawing.Size(88, 23)
            Me.btnAddRecord.TabIndex = 7
            Me.btnAddRecord.Text = "ADD/UPDATE"
            '
            'txtLongDesc
            '
            Me.txtLongDesc.Location = New System.Drawing.Point(16, 64)
            Me.txtLongDesc.Name = "txtLongDesc"
            Me.txtLongDesc.Size = New System.Drawing.Size(256, 20)
            Me.txtLongDesc.TabIndex = 4
            Me.txtLongDesc.Text = ""
            '
            'lblDescription
            '
            Me.lblDescription.Location = New System.Drawing.Point(16, 48)
            Me.lblDescription.Name = "lblDescription"
            Me.lblDescription.Size = New System.Drawing.Size(100, 16)
            Me.lblDescription.TabIndex = 0
            Me.lblDescription.Text = "Description:"
            '
            'btnCancelRecord
            '
            Me.btnCancelRecord.Location = New System.Drawing.Point(192, 224)
            Me.btnCancelRecord.Name = "btnCancelRecord"
            Me.btnCancelRecord.Size = New System.Drawing.Size(72, 23)
            Me.btnCancelRecord.TabIndex = 9
            Me.btnCancelRecord.Text = "CANCEL"
            '
            'lblLaborLvl
            '
            Me.lblLaborLvl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblLaborLvl.Location = New System.Drawing.Point(24, 57)
            Me.lblLaborLvl.Name = "lblLaborLvl"
            Me.lblLaborLvl.Size = New System.Drawing.Size(100, 16)
            Me.lblLaborLvl.TabIndex = 13
            Me.lblLaborLvl.Text = "LABOR LEVEL:"
            '
            'cboLaborLvl
            '
            Me.cboLaborLvl.Location = New System.Drawing.Point(24, 81)
            Me.cboLaborLvl.Name = "cboLaborLvl"
            Me.cboLaborLvl.Size = New System.Drawing.Size(288, 21)
            Me.cboLaborLvl.TabIndex = 14
            '
            'LaborLvl
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(736, 493)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.displayGrid, Me.btnNew, Me.grpRecord, Me.lblLaborLvl, Me.cboLaborLvl})
            Me.Name = "LaborLvl"
            Me.Text = "Labor Level"
            CType(Me.displayGrid, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grpRecord.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub LaborLvl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            hideModification()
            populateLaborLvl()
            getLaborLvlDisplay()

        End Sub

        Private Sub hideModification()
            Me.grpRecord.Visible = False
        End Sub

        Private Sub showModification()
            Me.grpRecord.Visible = True
        End Sub

        Private Sub getLaborLvlDisplay()

            Dim ctlLaborLvlDisplay As New PSS.Data.Production.llaborlvl()
            dtDisplay = ctlLaborLvlDisplay.LaborLvlList
            ctlLaborLvlDisplay = Nothing
            displayGrid.DataSource = dtDisplay
            displayGrid.Columns(0).Caption = "ID"
            displayGrid.Columns(1).Caption = "Description"

        End Sub


        Private Sub getLaborLvl()

            Dim ctlLaborLvl As New PSS.Data.Production.llaborlvl()
            dtLaborLvl = ctlLaborLvl.LaborLvlList
            ctlLaborLvl = Nothing

        End Sub


        Private Sub populateLaborLvl()

            Try
                Me.cboLaborLvl.Items.Clear()
            Catch exp As Exception
            End Try

            getLaborLvl()
            For xCount = 0 To dtLaborLvl.Rows.Count - 1
                '//add items to combobox
                r = dtLaborLvl.Rows(xCount)
                Me.cboLaborLvl.Items.Add(r("LaborLvl_Desc"))
            Next

        End Sub

        Private Sub clearFields()

            Me.txtLongDesc.Text = ""
            'Me.cboManuf.Text = ""
            'Me.cboProd.Text = ""
            Me.txtID.Text = ""
            Me.cboLaborLvl.Text = ""

        End Sub

        Private Sub cboLaborLvl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLaborLvl.SelectedIndexChanged

            showModification()
            getRecordForEditing()
            btnDeleteRecord.Visible = True

        End Sub

        Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click

            showModification()
            clearFields()
            Me.btnDeleteRecord.Visible = False
            txtLongDesc.Focus()

        End Sub

        Private Sub btnCancelRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelRecord.Click

            clearFields()
            hideModification()

        End Sub

        Private Sub getRecordForEditing()


            Dim tmpManufID As Int32 = 0
            Dim tmpManufStr As String
            Dim tmpProdID As Int32 = 0
            Dim tmpProdStr As String

            For xCount = 0 To dtLaborLvl.Rows.Count - 1
                r = dtLaborLvl.Rows(xCount)
                If Trim(r("LaborLvl_Desc")) = Trim(cboLaborLvl.Text) Then
                    '//populate data to form
                    Me.txtLongDesc.Text = r("LaborLvl_Desc")
                    Me.txtID.Text = r("LaborLvl_ID")
                    Exit For
                End If
            Next

        End Sub


        Private Function verifyData() As String

            verifyData = ""

            If Len(Trim(Me.txtLongDesc.Text)) < 1 Then
                verifyData += "No Long Description Defined." & vbCrLf
            End If

        End Function


        Private Sub btnAddRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddRecord.Click

            Dim blnInsert As Boolean = False    '//Update
            Dim verData As String = verifyData()

            If Len(Trim(verData)) > 0 Then
                MsgBox(verData & "Update/Insert has been cancelled.", MsgBoxStyle.OKOnly, "ERROR")
                populateLaborLvl()
                getLaborLvlDisplay()
                Exit Sub
            End If

            '//Determine if it is an update or insert
            If Len(Trim(Me.txtID.Text)) < 1 Then
                blnInsert = True    '//Insert
            End If

            Dim strSQL As String
            Dim ManufID As Int32 = 0
            Dim ProdID As Int32 = 0



            Dim ctlProcedure As New PSS.Data.Production.Joins()
            Dim blnRun As Boolean

            If blnInsert = True Then
                strSQL = "INSERT INTO llaborlvl ( LaborLvl_Desc) VALUES ('" & txtLongDesc.Text & "')"
                blnRun = ctlProcedure.OrderEntryUpdateDelete(strSQL)
            Else
                If Len(Trim(txtID.Text)) > 0 Then
                    strSQL = "UPDATE llaborlvl set LaborLvl_Desc = '" & txtLongDesc.Text & "' WHERE LaborLvl_ID = " & txtID.Text
                    blnRun = ctlProcedure.OrderEntryUpdateDelete(strSQL)
                Else
                    MsgBox("Error occurred while updating. Update Cancelled.", MsgBoxStyle.OKOnly, "ERROR")
                    populateLaborLvl()
                    Exit Sub
                End If
            End If

            populateLaborLvl()
            getLaborLvlDisplay()
            hideModification()

        End Sub

        Private Sub btnDeleteRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteRecord.Click

            Dim blnRun As Boolean
            Dim strSQL As String
            Dim Response As String

            If Len(Trim(txtID.Text)) > 0 Then
                If IsNumeric(Trim(txtID.Text)) = True Then

                    Response = MsgBox("You are about to delete this Labor Level Code. Continue?", MsgBoxStyle.YesNo, "Confirm Delete")
                    Select Case Response
                        Case vbYes
                            Dim ctlProcedure As New PSS.Data.Production.Joins()
                            strSQL = "DELETE FROM llaborlvl WHERE LaborLvl_ID = " & Trim(txtID.Text)
                            blnRun = ctlProcedure.OrderEntryUpdateDelete(strSQL)
                            populateLaborLvl()
                            getLaborLvlDisplay()
                            hideModification()
                            Me.cboLaborLvl.Text = ""

                            If blnRun = False Then
                                MsgBox("There was an error deleting this record.", MsgBoxStyle.OKOnly, "ERROR")
                                populateLaborLvl()
                                getLaborLvlDisplay()
                                Exit Sub
                            End If
                        Case vbNo
                            MsgBox("Delete cancelled at user request.", MsgBoxStyle.OKOnly, "CANCELLED")
                            populateLaborLvl()
                            getLaborLvlDisplay()
                            Exit Sub
                    End Select

                End If
            End If

        End Sub

        Private Sub displayGrid_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles displayGrid.RowColChange

            cboLaborLvl.Text = Me.displayGrid.Columns(1).Text
            getRecordForEditing()

        End Sub


        Private Sub displayGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles displayGrid.Click

        End Sub
    End Class

End Namespace
