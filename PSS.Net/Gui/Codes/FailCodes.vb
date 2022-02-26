Imports PSS.Core
Imports PSS.Data

Namespace Gui.codes

    Public Class FailCodes
        Inherits System.Windows.Forms.Form

        Private xCount As Integer
        Private dtFailCodes, dtManufacturer, dtProduct, dtDisplay As DataTable
        Private r As DataRow
        Private intMCodeID As Int32

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
        Friend WithEvents btnNew As System.Windows.Forms.Button
        Friend WithEvents grpRecord As System.Windows.Forms.GroupBox
        Friend WithEvents txtID As System.Windows.Forms.TextBox
        Friend WithEvents btnDeleteRecord As System.Windows.Forms.Button
        Friend WithEvents btnAddRecord As System.Windows.Forms.Button
        Friend WithEvents txtLongDesc As System.Windows.Forms.TextBox
        Friend WithEvents txtShortDesc As System.Windows.Forms.TextBox
        Friend WithEvents lblDescription As System.Windows.Forms.Label
        Friend WithEvents cboProd As System.Windows.Forms.ComboBox
        Friend WithEvents cboManuf As System.Windows.Forms.ComboBox
        Friend WithEvents lblProd As System.Windows.Forms.Label
        Friend WithEvents lblManuf As System.Windows.Forms.Label
        Friend WithEvents lblLong As System.Windows.Forms.Label
        Friend WithEvents lblShort As System.Windows.Forms.Label
        Friend WithEvents btnCancelRecord As System.Windows.Forms.Button
        Friend WithEvents lblFailCodess As System.Windows.Forms.Label
        Friend WithEvents cboFailCodes As System.Windows.Forms.ComboBox
        Friend WithEvents displayGrid As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FailCodes))
            Dim GridLines1 As C1.Win.C1TrueDBGrid.Util.GridLines = New C1.Win.C1TrueDBGrid.Util.GridLines()
            Me.btnNew = New System.Windows.Forms.Button()
            Me.grpRecord = New System.Windows.Forms.GroupBox()
            Me.txtID = New System.Windows.Forms.TextBox()
            Me.btnDeleteRecord = New System.Windows.Forms.Button()
            Me.btnAddRecord = New System.Windows.Forms.Button()
            Me.txtLongDesc = New System.Windows.Forms.TextBox()
            Me.txtShortDesc = New System.Windows.Forms.TextBox()
            Me.lblDescription = New System.Windows.Forms.Label()
            Me.cboProd = New System.Windows.Forms.ComboBox()
            Me.cboManuf = New System.Windows.Forms.ComboBox()
            Me.lblProd = New System.Windows.Forms.Label()
            Me.lblManuf = New System.Windows.Forms.Label()
            Me.lblLong = New System.Windows.Forms.Label()
            Me.lblShort = New System.Windows.Forms.Label()
            Me.btnCancelRecord = New System.Windows.Forms.Button()
            Me.lblFailCodess = New System.Windows.Forms.Label()
            Me.cboFailCodes = New System.Windows.Forms.ComboBox()
            Me.displayGrid = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.grpRecord.SuspendLayout()
            CType(Me.displayGrid, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'btnNew
            '
            Me.btnNew.Location = New System.Drawing.Point(224, 102)
            Me.btnNew.Name = "btnNew"
            Me.btnNew.Size = New System.Drawing.Size(88, 23)
            Me.btnNew.TabIndex = 10
            Me.btnNew.Text = "NEW"
            '
            'grpRecord
            '
            Me.grpRecord.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtID, Me.btnDeleteRecord, Me.btnAddRecord, Me.txtLongDesc, Me.txtShortDesc, Me.lblDescription, Me.cboProd, Me.cboManuf, Me.lblProd, Me.lblManuf, Me.lblLong, Me.lblShort, Me.btnCancelRecord})
            Me.grpRecord.Location = New System.Drawing.Point(32, 158)
            Me.grpRecord.Name = "grpRecord"
            Me.grpRecord.Size = New System.Drawing.Size(280, 264)
            Me.grpRecord.TabIndex = 11
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
            Me.txtLongDesc.Location = New System.Drawing.Point(64, 96)
            Me.txtLongDesc.Name = "txtLongDesc"
            Me.txtLongDesc.Size = New System.Drawing.Size(200, 20)
            Me.txtLongDesc.TabIndex = 4
            Me.txtLongDesc.Text = ""
            '
            'txtShortDesc
            '
            Me.txtShortDesc.Location = New System.Drawing.Point(64, 72)
            Me.txtShortDesc.Name = "txtShortDesc"
            Me.txtShortDesc.Size = New System.Drawing.Size(56, 20)
            Me.txtShortDesc.TabIndex = 3
            Me.txtShortDesc.Text = ""
            '
            'lblDescription
            '
            Me.lblDescription.Location = New System.Drawing.Point(16, 48)
            Me.lblDescription.Name = "lblDescription"
            Me.lblDescription.Size = New System.Drawing.Size(100, 16)
            Me.lblDescription.TabIndex = 0
            Me.lblDescription.Text = "Description:"
            '
            'cboProd
            '
            Me.cboProd.Location = New System.Drawing.Point(88, 184)
            Me.cboProd.Name = "cboProd"
            Me.cboProd.Size = New System.Drawing.Size(168, 21)
            Me.cboProd.TabIndex = 6
            '
            'cboManuf
            '
            Me.cboManuf.Location = New System.Drawing.Point(88, 160)
            Me.cboManuf.Name = "cboManuf"
            Me.cboManuf.Size = New System.Drawing.Size(168, 21)
            Me.cboManuf.TabIndex = 5
            '
            'lblProd
            '
            Me.lblProd.Location = New System.Drawing.Point(32, 184)
            Me.lblProd.Name = "lblProd"
            Me.lblProd.Size = New System.Drawing.Size(56, 16)
            Me.lblProd.TabIndex = 0
            Me.lblProd.Text = "Product:"
            '
            'lblManuf
            '
            Me.lblManuf.Location = New System.Drawing.Point(8, 160)
            Me.lblManuf.Name = "lblManuf"
            Me.lblManuf.Size = New System.Drawing.Size(80, 16)
            Me.lblManuf.TabIndex = 0
            Me.lblManuf.Text = "Manufacturer:"
            '
            'lblLong
            '
            Me.lblLong.Location = New System.Drawing.Point(16, 96)
            Me.lblLong.Name = "lblLong"
            Me.lblLong.Size = New System.Drawing.Size(40, 16)
            Me.lblLong.TabIndex = 0
            Me.lblLong.Text = "Long:"
            '
            'lblShort
            '
            Me.lblShort.Location = New System.Drawing.Point(16, 72)
            Me.lblShort.Name = "lblShort"
            Me.lblShort.Size = New System.Drawing.Size(40, 16)
            Me.lblShort.TabIndex = 0
            Me.lblShort.Text = "Short:"
            '
            'btnCancelRecord
            '
            Me.btnCancelRecord.Location = New System.Drawing.Point(192, 224)
            Me.btnCancelRecord.Name = "btnCancelRecord"
            Me.btnCancelRecord.Size = New System.Drawing.Size(72, 23)
            Me.btnCancelRecord.TabIndex = 9
            Me.btnCancelRecord.Text = "CANCEL"
            '
            'lblFailCodess
            '
            Me.lblFailCodess.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblFailCodess.Location = New System.Drawing.Point(24, 46)
            Me.lblFailCodess.Name = "lblFailCodess"
            Me.lblFailCodess.Size = New System.Drawing.Size(100, 16)
            Me.lblFailCodess.TabIndex = 7
            Me.lblFailCodess.Text = "FAIL CODES:"
            '
            'cboFailCodes
            '
            Me.cboFailCodes.Location = New System.Drawing.Point(24, 70)
            Me.cboFailCodes.Name = "cboFailCodes"
            Me.cboFailCodes.Size = New System.Drawing.Size(288, 21)
            Me.cboFailCodes.TabIndex = 9
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
            Me.displayGrid.Location = New System.Drawing.Point(328, 72)
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
            Me.displayGrid.TabIndex = 12
            Me.displayGrid.Text = "C1TrueDBGrid1"
            Me.displayGrid.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Normal{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style1{}Od" & _
            "dRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:True;BackColor:Control;Bord" & _
            "er:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}Style10{Al" & _
            "ignHorz:Near;}Style11{}Style12{}Style13{}Style9{}</Data></Styles><Splits><C1.Win" & _
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
            'FailCodes
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(656, 469)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.displayGrid, Me.btnNew, Me.grpRecord, Me.lblFailCodess, Me.cboFailCodes})
            Me.Name = "FailCodes"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "FailCodes"
            Me.grpRecord.ResumeLayout(False)
            CType(Me.displayGrid, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub FailCodes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            hideModification()
            populateFailCodes()
            populateManufacturer()
            populateProduct()
            getMCodeID()
            getFailCodeDisplay()

        End Sub

        Private Sub hideModification()
            Me.grpRecord.Visible = False
        End Sub

        Private Sub showModification()
            Me.grpRecord.Visible = True
        End Sub

        Private Sub getMCodeID()
            '// NEW Get the correct Mcode_ID for the section
            Dim dtMC As New PSS.Data.Production.lcodesmater()
            Dim dtMCode As DataTable = dtMC.GetMCodeID("Failure")
            Dim r As DataRow
            For xCount = 0 To dtMCode.Rows.Count - 1
                r = dtMCode.Rows(xCount)
                intMCodeID = r("MCode_ID")
                Exit For
            Next

        End Sub

        Private Sub getFailCodeDisplay()

            Dim ctlFailCodesDisplay As New PSS.Data.Production.Joins()
            dtDisplay = ctlFailCodesDisplay.FailCodeDisplay(intmcodeid)
            ctlFailCodesDisplay = Nothing
            displayGrid.DataSource = dtDisplay
            displayGrid.Columns(0).Caption = "Description"
            displayGrid.Columns(1).Caption = "Manufacturer"
            displayGrid.Columns(2).Caption = "Product"

        End Sub


        Private Sub getFailCodes()

            Dim ctlFailCodes As New PSS.Data.Production.lfailcodes()
            dtFailCodes = ctlFailCodes.FailCodeList
            ctlFailCodes = Nothing

        End Sub

        Private Sub getManufacturer()

            Dim ctlManufacturer As New PSS.Data.Production.lmanuf()
            dtManufacturer = ctlManufacturer.ManufacturerList
            ctlManufacturer = Nothing

        End Sub

        Private Sub populateManufacturer()

            getManufacturer()
            For xCount = 0 To dtManufacturer.Rows.Count - 1
                '//add items to combobox
                r = dtManufacturer.Rows(xCount)
                Me.cboManuf.Items.Add(r("Manuf_Desc"))
            Next

        End Sub

        Private Sub getProduct()

            Dim ctlProduct As New PSS.Data.Production.lproduct()
            dtProduct = ctlProduct.ProductList
            ctlProduct = Nothing

        End Sub

        Private Sub populateProduct()

            getProduct()
            For xCount = 0 To dtProduct.Rows.Count - 1
                '//add items to combobox
                r = dtProduct.Rows(xCount)
                Me.cboProd.Items.Add(r("Prod_Desc"))
            Next

        End Sub

        Private Sub populateFailCodes()

            Try
                Me.cboFailCodes.Items.Clear()
            Catch exp As Exception
            End Try

            getFailCodes()
            For xCount = 0 To dtFailCodes.Rows.Count - 1
                '//add items to combobox
                r = dtFailCodes.Rows(xCount)
                Me.cboFailCodes.Items.Add(r("Fail_LDesc"))
            Next

        End Sub

        Private Sub clearFields()

            Me.txtShortDesc.Text = ""
            Me.txtLongDesc.Text = ""
            'Me.cboManuf.Text = ""
            'Me.cboProd.Text = ""
            Me.txtID.Text = ""
            Me.cboFailCodes.Text = ""

        End Sub

        Private Sub cboFailCodes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFailCodes.SelectedIndexChanged

            showModification()
            getRecordForEditing()
            btnDeleteRecord.Visible = True

        End Sub

        Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click

            showModification()
            clearFields()
            Me.btnDeleteRecord.Visible = False
            txtShortDesc.Focus()

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

            For xCount = 0 To dtFailCodes.Rows.Count - 1
                r = dtFailCodes.Rows(xCount)
                If Trim(r("Fail_LDesc")) = Trim(cboFailCodes.Text) Then
                    '//populate data to form
                    Me.txtShortDesc.Text = r("Fail_SDesc")
                    Me.txtLongDesc.Text = r("Fail_LDesc")
                    Me.txtID.Text = r("Fail_ID")
                    tmpManufID = r("Manuf_ID")
                    tmpProdID = r("Prod_ID")
                    Exit For
                End If
            Next

            For xCount = 0 To dtManufacturer.Rows.Count - 1
                r = dtManufacturer.Rows(xCount)
                If Trim(r("Manuf_ID")) = Trim(tmpManufID) Then
                    tmpManufStr = Trim(r("Manuf_Desc"))
                    Exit For
                End If
            Next

            For xCount = 0 To Me.cboManuf.Items.Count - 1
                If Trim(cboManuf.Items(xCount)) = Trim(tmpManufStr) Then
                    cboManuf.SelectedIndex = xCount
                End If
            Next

            For xCount = 0 To dtProduct.Rows.Count - 1
                r = dtProduct.Rows(xCount)
                If Trim(r("Prod_ID")) = Trim(tmpProdID) Then
                    tmpProdStr = Trim(r("Prod_Desc"))
                    Exit For
                End If
            Next

            For xCount = 0 To Me.cboProd.Items.Count - 1
                If Trim(cboProd.Items(xCount)) = Trim(tmpProdStr) Then
                    cboProd.SelectedIndex = xCount
                End If
            Next


        End Sub


        Private Function verifyData() As String

            verifyData = ""

            If Len(Trim(Me.txtShortDesc.Text)) < 1 Then
                verifyData += "No Short Description Defined." & vbCrLf
            End If
            If Len(Trim(Me.txtLongDesc.Text)) < 1 Then
                verifyData += "No Long Description Defined." & vbCrLf
            End If
            If Len(Trim(Me.cboManuf.Text)) < 1 Then
                verifyData += "No Manufactuer Assigned." & vbCrLf
            End If
            If Len(Trim(Me.cboProd.Text)) < 1 Then
                verifyData += "No Product Assigned." & vbCrLf
            End If

        End Function


        Private Sub btnAddRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddRecord.Click

            Dim blnInsert As Boolean = False    '//Update
            Dim verData As String = verifyData()

            If Len(Trim(verData)) > 0 Then
                MsgBox(verData & "Update/Insert has been cancelled.", MsgBoxStyle.OKOnly, "ERROR")
                populateFailCodes()
                getFailCodeDisplay()
                Exit Sub
            End If

            '//Determine if it is an update or insert
            If Len(Trim(Me.txtID.Text)) < 1 Then
                blnInsert = True    '//Insert
            End If

            Dim strSQL As String
            Dim ManufID As Int32 = 0
            Dim ProdID As Int32 = 0

            '//Get Manufacture ID value
            For xCount = 0 To Me.dtManufacturer.Rows.Count - 1
                r = dtManufacturer.Rows(xCount)
                If Trim(r("Manuf_Desc")) = Trim(Me.cboManuf.Text) Then
                    ManufID = r("Manuf_ID")
                End If
            Next

            '//Get Product ID value
            For xCount = 0 To Me.dtProduct.Rows.Count - 1
                r = dtProduct.Rows(xCount)
                If Trim(r("Prod_Desc")) = Trim(Me.cboProd.Text) Then
                    ProdID = r("Prod_ID")
                End If
            Next

            If ManufID = 0 Or ProdID = 0 Then
                MsgBox("The ID values could not be assigned. Save Cancelled.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

            Dim ctlProcedure As New PSS.Data.Production.Joins()
            Dim blnRun As Boolean

            If blnInsert = True Then
                'strSQL = "INSERT INTO lfailcodes (Fail_SDesc, Fail_LDesc, Manuf_ID, Prod_ID) VALUES ('" & txtShortDesc.Text & "', '" & txtLongDesc.Text & "', " & ManufID & ", " & ProdID & ")"
                strSQL = "INSERT INTO lcodesdetail (Dcode_SDesc, Dcode_LDesc, Manuf_ID, Prod_ID, Mcode_ID) VALUES ('" & txtShortDesc.Text & "', '" & txtLongDesc.Text & "', " & ManufID & ", " & ProdID & ", " & intMCodeID & ")"
                blnRun = ctlProcedure.OrderEntryUpdateDelete(strSQL)
            Else
                If Len(Trim(txtID.Text)) > 0 Then
                    'strSQL = "UPDATE lfailcodes set Fail_SDesc = '" & txtShortDesc.Text & "', Fail_LDesc = '" & txtLongDesc.Text & "', manuf_ID = " & ManufID & ", prod_ID = " & ProdID & " WHERE Fail_ID = " & txtID.Text
                    strSQL = "UPDATE lcodesdetail set DCode_SDesc = '" & txtShortDesc.Text & "', DCode_LDesc = '" & txtLongDesc.Text & "', manuf_ID = " & ManufID & ", prod_ID = " & ProdID & " WHERE DCode_ID = " & txtID.Text
                    blnRun = ctlProcedure.OrderEntryUpdateDelete(strSQL)
                Else
                    MsgBox("Error occurred while updating. Update Cancelled.", MsgBoxStyle.OKOnly, "ERROR")
                    populateFailCodes()
                    Exit Sub
                End If
            End If

            populateFailCodes()
            getFailCodeDisplay()
            hideModification()

        End Sub

        Private Sub btnDeleteRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteRecord.Click

            Dim blnRun As Boolean
            Dim strSQL As String
            Dim Response As String

            If Len(Trim(txtID.Text)) > 0 Then
                If IsNumeric(Trim(txtID.Text)) = True Then

                    Response = MsgBox("You are about to delete this Fail Code. Continue?", MsgBoxStyle.YesNo, "Confirm Delete")
                    Select Case Response
                        Case vbYes
                            Dim ctlProcedure As New PSS.Data.Production.Joins()
                            'strSQL = "DELETE FROM lfailcodes WHERE Fail_ID = " & Trim(txtID.Text)
                            strSQL = "DELETE FROM lcodesdetail WHERE Dcode_ID = " & Trim(txtID.Text)
                            blnRun = ctlProcedure.OrderEntryUpdateDelete(strSQL)
                            populateFailCodes()
                            getFailCodeDisplay()
                            hideModification()
                            Me.cboFailCodes.Text = ""

                            If blnRun = False Then
                                MsgBox("There was an error deleting this record.", MsgBoxStyle.OKOnly, "ERROR")
                                populateFailCodes()
                                getFailCodeDisplay()
                                Exit Sub
                            End If
                        Case vbNo
                            MsgBox("Delete cancelled at user request.", MsgBoxStyle.OKOnly, "CANCELLED")
                            populateFailCodes()
                            getFailCodeDisplay()
                            Exit Sub
                    End Select

                End If
            End If

        End Sub

        Private Sub displayGrid_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles displayGrid.RowColChange

            cboFailCodes.Text = Me.displayGrid.Columns(0).Text
            getRecordForEditing()

        End Sub

        Private Sub displayGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles displayGrid.Click

        End Sub
    End Class

End Namespace
