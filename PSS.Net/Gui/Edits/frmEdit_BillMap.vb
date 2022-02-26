
Namespace Gui.Edit_BillMap

    Public Class frmEdit_BillMap

        Inherits System.Windows.Forms.Form

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
        Friend WithEvents lblCustoemr As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents grpEdit As System.Windows.Forms.GroupBox
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents btnSave As System.Windows.Forms.Button
        Friend WithEvents MainGrid As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents cboProblemFound As PSS.Gui.Controls.ComboBox
        Friend WithEvents cboModel As PSS.Gui.Controls.ComboBox
        Friend WithEvents cboFailure As PSS.Gui.Controls.ComboBox
        Friend WithEvents cboReferenceDesignator As PSS.Gui.Controls.ComboBox
        Friend WithEvents cboRepairAction As PSS.Gui.Controls.ComboBox
        Friend WithEvents cboTransaction As PSS.Gui.Controls.ComboBox
        Friend WithEvents cboBillCodes As PSS.Gui.Controls.ComboBox
        Friend WithEvents cboCustomer As PSS.Gui.Controls.ComboBox
        Friend WithEvents cboManufacturer As PSS.Gui.Controls.ComboBox
        Friend WithEvents btnGetData As System.Windows.Forms.Button
        Friend WithEvents txtRefDesNumber As System.Windows.Forms.TextBox
        Friend WithEvents chkInactive As System.Windows.Forms.CheckBox
        Friend WithEvents chkShowInactive As System.Windows.Forms.CheckBox
        Friend WithEvents cmdAutoMapServices As System.Windows.Forms.Button
        Friend WithEvents cmdDelAutoMapServices As System.Windows.Forms.Button
        Friend WithEvents btnGetUnMapBillCodes As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmEdit_BillMap))
            Me.lblCustoemr = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.cboCustomer = New PSS.Gui.Controls.ComboBox()
            Me.cboManufacturer = New PSS.Gui.Controls.ComboBox()
            Me.cboModel = New PSS.Gui.Controls.ComboBox()
            Me.grpEdit = New System.Windows.Forms.GroupBox()
            Me.cmdDelAutoMapServices = New System.Windows.Forms.Button()
            Me.chkInactive = New System.Windows.Forms.CheckBox()
            Me.btnSave = New System.Windows.Forms.Button()
            Me.cboTransaction = New PSS.Gui.Controls.ComboBox()
            Me.cboFailure = New PSS.Gui.Controls.ComboBox()
            Me.cboReferenceDesignator = New PSS.Gui.Controls.ComboBox()
            Me.cboRepairAction = New PSS.Gui.Controls.ComboBox()
            Me.cboProblemFound = New PSS.Gui.Controls.ComboBox()
            Me.cboBillCodes = New PSS.Gui.Controls.ComboBox()
            Me.txtRefDesNumber = New System.Windows.Forms.TextBox()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.cmdAutoMapServices = New System.Windows.Forms.Button()
            Me.MainGrid = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnGetData = New System.Windows.Forms.Button()
            Me.chkShowInactive = New System.Windows.Forms.CheckBox()
            Me.btnGetUnMapBillCodes = New System.Windows.Forms.Button()
            Me.grpEdit.SuspendLayout()
            CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblCustoemr
            '
            Me.lblCustoemr.Location = New System.Drawing.Point(8, 8)
            Me.lblCustoemr.Name = "lblCustoemr"
            Me.lblCustoemr.Size = New System.Drawing.Size(56, 16)
            Me.lblCustoemr.TabIndex = 0
            Me.lblCustoemr.Text = "Customer:"
            Me.lblCustoemr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label1
            '
            Me.Label1.Location = New System.Drawing.Point(209, 8)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(80, 16)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Manufacturer:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label2
            '
            Me.Label2.Location = New System.Drawing.Point(385, 8)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(48, 16)
            Me.Label2.TabIndex = 0
            Me.Label2.Text = "Model:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboCustomer
            '
            Me.cboCustomer.AutoComplete = True
            Me.cboCustomer.Location = New System.Drawing.Point(8, 24)
            Me.cboCustomer.Name = "cboCustomer"
            Me.cboCustomer.Size = New System.Drawing.Size(192, 21)
            Me.cboCustomer.TabIndex = 18
            '
            'cboManufacturer
            '
            Me.cboManufacturer.AutoComplete = True
            Me.cboManufacturer.Location = New System.Drawing.Point(217, 24)
            Me.cboManufacturer.Name = "cboManufacturer"
            Me.cboManufacturer.Size = New System.Drawing.Size(168, 21)
            Me.cboManufacturer.TabIndex = 19
            '
            'cboModel
            '
            Me.cboModel.AutoComplete = True
            Me.cboModel.Location = New System.Drawing.Point(401, 24)
            Me.cboModel.Name = "cboModel"
            Me.cboModel.Size = New System.Drawing.Size(112, 21)
            Me.cboModel.TabIndex = 20
            '
            'grpEdit
            '
            Me.grpEdit.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.grpEdit.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdDelAutoMapServices, Me.chkInactive, Me.btnSave, Me.cboTransaction, Me.cboFailure, Me.cboReferenceDesignator, Me.cboRepairAction, Me.cboProblemFound, Me.cboBillCodes, Me.txtRefDesNumber, Me.Label9, Me.Label8, Me.Label7, Me.Label6, Me.Label5, Me.Label4, Me.Label3, Me.cmdAutoMapServices})
            Me.grpEdit.Location = New System.Drawing.Point(8, 336)
            Me.grpEdit.Name = "grpEdit"
            Me.grpEdit.Size = New System.Drawing.Size(856, 168)
            Me.grpEdit.TabIndex = 27
            Me.grpEdit.TabStop = False
            Me.grpEdit.Text = "Edit/Input"
            '
            'cmdDelAutoMapServices
            '
            Me.cmdDelAutoMapServices.BackColor = System.Drawing.Color.Red
            Me.cmdDelAutoMapServices.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdDelAutoMapServices.ForeColor = System.Drawing.Color.White
            Me.cmdDelAutoMapServices.Location = New System.Drawing.Point(720, 96)
            Me.cmdDelAutoMapServices.Name = "cmdDelAutoMapServices"
            Me.cmdDelAutoMapServices.Size = New System.Drawing.Size(128, 64)
            Me.cmdDelAutoMapServices.TabIndex = 45
            Me.cmdDelAutoMapServices.Text = "DELETE ALL AUTO MAPPED SERVICES FOR THE SELECTED MODEL"
            '
            'chkInactive
            '
            Me.chkInactive.Location = New System.Drawing.Point(496, 72)
            Me.chkInactive.Name = "chkInactive"
            Me.chkInactive.TabIndex = 42
            Me.chkInactive.Text = "Inactive"
            '
            'btnSave
            '
            Me.btnSave.Location = New System.Drawing.Point(496, 104)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(192, 40)
            Me.btnSave.TabIndex = 43
            Me.btnSave.Text = "SAVE/EDIT"
            '
            'cboTransaction
            '
            Me.cboTransaction.AutoComplete = True
            Me.cboTransaction.Location = New System.Drawing.Point(112, 120)
            Me.cboTransaction.Name = "cboTransaction"
            Me.cboTransaction.Size = New System.Drawing.Size(240, 21)
            Me.cboTransaction.TabIndex = 39
            '
            'cboFailure
            '
            Me.cboFailure.AutoComplete = True
            Me.cboFailure.Location = New System.Drawing.Point(112, 96)
            Me.cboFailure.Name = "cboFailure"
            Me.cboFailure.Size = New System.Drawing.Size(240, 21)
            Me.cboFailure.TabIndex = 38
            '
            'cboReferenceDesignator
            '
            Me.cboReferenceDesignator.AutoComplete = True
            Me.cboReferenceDesignator.Location = New System.Drawing.Point(496, 24)
            Me.cboReferenceDesignator.Name = "cboReferenceDesignator"
            Me.cboReferenceDesignator.Size = New System.Drawing.Size(192, 21)
            Me.cboReferenceDesignator.TabIndex = 40
            '
            'cboRepairAction
            '
            Me.cboRepairAction.AutoComplete = True
            Me.cboRepairAction.Location = New System.Drawing.Point(112, 72)
            Me.cboRepairAction.Name = "cboRepairAction"
            Me.cboRepairAction.Size = New System.Drawing.Size(240, 21)
            Me.cboRepairAction.TabIndex = 37
            '
            'cboProblemFound
            '
            Me.cboProblemFound.AutoComplete = True
            Me.cboProblemFound.Location = New System.Drawing.Point(112, 48)
            Me.cboProblemFound.Name = "cboProblemFound"
            Me.cboProblemFound.Size = New System.Drawing.Size(240, 21)
            Me.cboProblemFound.TabIndex = 36
            '
            'cboBillCodes
            '
            Me.cboBillCodes.AutoComplete = True
            Me.cboBillCodes.Location = New System.Drawing.Point(112, 24)
            Me.cboBillCodes.Name = "cboBillCodes"
            Me.cboBillCodes.Size = New System.Drawing.Size(240, 21)
            Me.cboBillCodes.TabIndex = 35
            '
            'txtRefDesNumber
            '
            Me.txtRefDesNumber.Location = New System.Drawing.Point(496, 48)
            Me.txtRefDesNumber.Name = "txtRefDesNumber"
            Me.txtRefDesNumber.Size = New System.Drawing.Size(192, 20)
            Me.txtRefDesNumber.TabIndex = 41
            Me.txtRefDesNumber.Text = ""
            '
            'Label9
            '
            Me.Label9.Location = New System.Drawing.Point(32, 120)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(72, 16)
            Me.Label9.TabIndex = 33
            Me.Label9.Text = "Transaction:"
            Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label8
            '
            Me.Label8.Location = New System.Drawing.Point(16, 96)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(88, 16)
            Me.Label8.TabIndex = 32
            Me.Label8.Text = "Failure:"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label7
            '
            Me.Label7.Location = New System.Drawing.Point(360, 48)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(128, 16)
            Me.Label7.TabIndex = 31
            Me.Label7.Text = "Reference Designator #:"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label6
            '
            Me.Label6.Location = New System.Drawing.Point(360, 24)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(128, 16)
            Me.Label6.TabIndex = 30
            Me.Label6.Text = "Reference Designator:"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label5
            '
            Me.Label5.Location = New System.Drawing.Point(16, 72)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(88, 16)
            Me.Label5.TabIndex = 29
            Me.Label5.Text = "Repair Action:"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label4
            '
            Me.Label4.Location = New System.Drawing.Point(16, 48)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(88, 16)
            Me.Label4.TabIndex = 28
            Me.Label4.Text = "Problem Found:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label3
            '
            Me.Label3.Location = New System.Drawing.Point(16, 24)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(88, 16)
            Me.Label3.TabIndex = 27
            Me.Label3.Text = "BillCode:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmdAutoMapServices
            '
            Me.cmdAutoMapServices.BackColor = System.Drawing.Color.SteelBlue
            Me.cmdAutoMapServices.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdAutoMapServices.ForeColor = System.Drawing.Color.White
            Me.cmdAutoMapServices.Location = New System.Drawing.Point(720, 16)
            Me.cmdAutoMapServices.Name = "cmdAutoMapServices"
            Me.cmdAutoMapServices.Size = New System.Drawing.Size(128, 64)
            Me.cmdAutoMapServices.TabIndex = 44
            Me.cmdAutoMapServices.Text = "AUTO MAP SERVICES FOR THE SELECTED MODEL"
            '
            'MainGrid
            '
            Me.MainGrid.AllowColMove = False
            Me.MainGrid.AllowColSelect = False
            Me.MainGrid.AllowDelete = True
            Me.MainGrid.AllowFilter = False
            Me.MainGrid.AllowUpdate = False
            Me.MainGrid.AlternatingRows = True
            Me.MainGrid.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.MainGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.MainGrid.CaptionHeight = 17
            Me.MainGrid.GroupByCaption = "Drag a column header here to group by that column"
            Me.MainGrid.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.MainGrid.Location = New System.Drawing.Point(8, 56)
            Me.MainGrid.Name = "MainGrid"
            Me.MainGrid.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.MainGrid.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.MainGrid.PreviewInfo.ZoomFactor = 75
            Me.MainGrid.RowHeight = 15
            Me.MainGrid.Size = New System.Drawing.Size(856, 280)
            Me.MainGrid.TabIndex = 37
            Me.MainGrid.Text = "C1TrueDBGrid1"
            Me.MainGrid.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Style11{}Style12{}Style13{}Style5{}Style4{}Style7{}Style6{}Style1{}Sele" & _
            "cted{ForeColor:HighlightText;BackColor:Highlight;}Heading{Wrap:True;AlignVert:Ce" & _
            "nter;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Editor{}Normal{Font:Verdana, 8.25pt;}Style10{AlignHorz:Ne" & _
            "ar;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}EvenRow{BackColor:" & _
            "Aqua;}OddRow{}RecordSelector{AlignImage:Center;}Style8{}Style3{}Style2{}Style14{" & _
            "}Style15{}Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}" & _
            "Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""Fal" & _
            "se"" AllowColSelect=""False"" Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17""" & _
            " ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder" & _
            """ RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" Horizonta" & _
            "lScrollGroup=""1""><Height>278</Height><CaptionStyle parent=""Style2"" me=""Style10"" " & _
            "/><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""" & _
            "Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=" & _
            """Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle p" & _
            "arent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style" & _
            "7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow""" & _
            " me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><Sele" & _
            "ctedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><" & _
            "ClientRect>0, 0, 854, 278</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sun" & _
            "ken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style pa" & _
            "rent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Headi" & _
            "ng"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading""" & _
            " me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" m" & _
            "e=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" m" & _
            "e=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""R" & _
            "ecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption""" & _
            " me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits>" & _
            "<Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>" & _
            "0, 0, 854, 278</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><Print" & _
            "PageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'btnGetData
            '
            Me.btnGetData.Location = New System.Drawing.Point(616, 16)
            Me.btnGetData.Name = "btnGetData"
            Me.btnGetData.Size = New System.Drawing.Size(64, 32)
            Me.btnGetData.TabIndex = 38
            Me.btnGetData.Text = "GET DATA"
            '
            'chkShowInactive
            '
            Me.chkShowInactive.Location = New System.Drawing.Point(536, 16)
            Me.chkShowInactive.Name = "chkShowInactive"
            Me.chkShowInactive.Size = New System.Drawing.Size(64, 32)
            Me.chkShowInactive.TabIndex = 43
            Me.chkShowInactive.Text = "Show Inactive"
            '
            'btnGetUnMapBillCodes
            '
            Me.btnGetUnMapBillCodes.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnGetUnMapBillCodes.BackColor = System.Drawing.Color.SteelBlue
            Me.btnGetUnMapBillCodes.ForeColor = System.Drawing.Color.White
            Me.btnGetUnMapBillCodes.Location = New System.Drawing.Point(776, 16)
            Me.btnGetUnMapBillCodes.Name = "btnGetUnMapBillCodes"
            Me.btnGetUnMapBillCodes.Size = New System.Drawing.Size(88, 32)
            Me.btnGetUnMapBillCodes.TabIndex = 45
            Me.btnGetUnMapBillCodes.Text = "GET UN-MAP BILLCODES"
            '
            'frmEdit_BillMap
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(880, 509)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnGetUnMapBillCodes, Me.btnGetData, Me.MainGrid, Me.grpEdit, Me.cboModel, Me.cboManufacturer, Me.cboCustomer, Me.Label2, Me.Label1, Me.lblCustoemr, Me.chkShowInactive})
            Me.Name = "frmEdit_BillMap"
            Me.Text = "frmEdit_BillMap"
            Me.grpEdit.ResumeLayout(False)
            CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private dsPSS As PSS.Data.Production.Joins

        Private strSQL As String
        Private dtMainDataGrid As DataTable = makeMainDataGrid()
        Private dtProblemFound, _
                dtRepairAction, _
                dtRefDes, _
                dtFailure, _
                dtTransaction, _
                dtBillCodes As DataTable

        Private mGridLow, mGridHigh As Integer
        Private vMouseDown As Integer = 0


        Private Sub frmEdit_BillMap_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            dtProblemFound = load_lcodesdetail_ComboBox(9, 1, cboProblemFound)
            dtRepairAction = load_lcodesdetail_ComboBox(3, 1, cboRepairAction)
            dtRefDes = load_lcodesdetail_ComboBox(11, 1, cboReferenceDesignator)
            dtFailure = load_lcodesdetail_ComboBox(4, 1, cboFailure)
            dtTransaction = load_lcodesdetail_ComboBox(8, 1, cboTransaction)
            load_generic_ComboBox(cboBillCodes, "Select billcode_id as tdID, billcode_desc as tdText FROM lbillcodes ORDER BY billcode_desc")
            load_generic_ComboBox(cboCustomer, "Select cust_id as tdID, cust_name1 as tdText FROM tcustomer WHERE cust_name2 IS NULL ORDER BY cust_name1")
            load_generic_ComboBox(cboManufacturer, "Select manuf_id as tdID, manuf_desc as tdText FROM lmanuf ORDER BY manuf_desc")

            'mGridHigh = grpEdit.Top + grpEdit.Height + 10
            'MainGrid.Height = mGridHigh

            makeMainDataGrid()
            clearBoxes()
            DisableBoxes()




        End Sub

        Private Function load_lcodesdetail_ComboBox(ByVal mM1 As Integer, ByVal mM2 As Integer, ByVal mCtl As Control) As DataTable
            Dim dt As DataTable = Me.get_lcodesdetail_datatable(mM1, mM2)
            CType(mCtl, System.Windows.Forms.ComboBox).DataSource = dt
            CType(mCtl, System.Windows.Forms.ComboBox).DisplayMember = dt.Columns("tdText").ToString
            CType(mCtl, System.Windows.Forms.ComboBox).ValueMember = dt.Columns("tdID").ToString
            Return dt
        End Function

        Private Sub load_generic_ComboBox(ByVal mCtl As Control, ByVal strSQL As String)
            Dim dt As DataTable = dsPSS.OrderEntrySelect(strSQL)
            CType(mCtl, System.Windows.Forms.ComboBox).DataSource = dt
            CType(mCtl, System.Windows.Forms.ComboBox).DisplayMember = dt.Columns("tdText").ToString
            CType(mCtl, System.Windows.Forms.ComboBox).ValueMember = dt.Columns("tdID").ToString
        End Sub

        Private Sub load_generic_BillCodes(ByVal vModel As Long)
            strSQL = "SELECT lbillcodes.billcode_id as tdID, lbillcodes.billcode_desc as tdText FROM lbillcodes INNER JOIN tpsmap on lbillcodes.billcode_id = tpsmap.billcode_id WHERE tpsmap.model_id = " & vModel & " ORDER BY lbillcodes.billcode_desc"
            dtBillCodes = dsPSS.OrderEntrySelect(strSQL)
        End Sub



        Private Function get_lcodesdetail_datatable(ByVal vM1 As Integer, ByVal vM2 As Integer) As DataTable

            Dim dsSource As PSS.Data.Production.Joins
            Dim dtSource As DataTable
            Dim dt As New DataTable("TableData")

            Dim dcID As New DataColumn("tdID")
            dt.Columns.Add(dcID)
            Dim dcText As New DataColumn("tdText")
            dt.Columns.Add(dcText)

            strSQL = "select dcode_sdesc, dcode_ldesc, dcode_id from lcodesdetail " & _
                     "where mcode_id = " & vM1 & " and dcode_inactive = 0 and manuf_id = " & vM2 & " " & _
                     "order by dcode_sdesc, dcode_ldesc"
            dtSource = dsSource.OrderEntrySelect(strSQL)

            Dim xCount As Integer = 0
            Dim r, dr1 As DataRow

            For xCount = 0 To dtSource.Rows.Count - 1
                r = dtSource.Rows(xCount)

                dr1 = dt.NewRow
                dr1("tdID") = r("dcode_id").ToString
                dr1("tdText") = "(" & r("dcode_sdesc") & ") " & r("dcode_ldesc")
                dt.Rows.Add(dr1)
            Next

            Return dt

        End Function


        Private Sub GetMainData()

            Dim tmpDT As DataTable
            Dim i As Integer = 0

            tmpDT = getDS(cboCustomer.SelectedValue, cboModel.SelectedValue)
            BuildTranslatedData(tmpDT)
            System.Windows.Forms.Application.DoEvents()
            MainGrid.DataSource = dtMainDataGrid

            MainGrid.Splits(0).DisplayColumns(0).Visible = False
            MainGrid.Splits(0).DisplayColumns(1).Visible = False
            MainGrid.Splits(0).DisplayColumns(2).Visible = False

            MainGrid.Splits(0).DisplayColumns(3).Width = 50
            MainGrid.Splits(0).DisplayColumns(4).Width = 200
            MainGrid.Splits(0).DisplayColumns(5).Width = 220
            MainGrid.Splits(0).DisplayColumns(6).Width = 220
            MainGrid.Splits(0).DisplayColumns(7).Width = 200
            MainGrid.Splits(0).DisplayColumns(8).Width = 90
            MainGrid.Splits(0).DisplayColumns(9).Width = 200
            MainGrid.Splits(0).DisplayColumns(10).Width = 200

            '***********************************************
            'Lan added on 2007-07-12
            'Heading style (Horizontal Alignment to Center)
            '***********************************************
            For i = 0 To (Me.MainGrid.Columns.Count - 1)
                MainGrid.Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Next
            '***********************************************

        End Sub


        Private Function getDS(ByVal vCustID As Long, ByVal vModelID As Long) As DataTable

            If chkShowInactive.Checked = False Then
                strSQL = "SELECT * FROM tbillmap WHERE Cust_ID = " & vCustID & " AND Model_ID = " & vModelID & " AND BMap_Inactive = 0 ORDER BY BillCode_ID"
                MainGrid.ForeColor = Color.Black
            Else
                strSQL = "SELECT * FROM tbillmap WHERE Cust_ID = " & vCustID & " AND Model_ID = " & vModelID & " AND BMap_Inactive > 0 ORDER BY BillCode_ID"
                MainGrid.ForeColor = Color.Red
            End If

            Return dsPSS.OrderEntrySelect(strSQL)
        End Function


        Private Sub BuildTranslatedData(ByVal vdt As DataTable)

            Dim xcount As Integer = 0
            Dim r, dr1 As DataRow

            For xcount = 0 To vdt.Rows.Count - 1
                r = vdt.Rows(xcount)

                dr1 = dtMainDataGrid.NewRow
                dr1("ID") = r("BMap_ID").ToString
                dr1("Customer ID") = r("Cust_ID")
                dr1("Model ID") = r("Model_ID")

                If IsDBNull(r("BillCode_ID")) = False Then dr1("BillCode") = r("BillCode_ID")
                If IsDBNull(r("BillCode_ID")) = False Then dr1("BillCode Description") = TranslateID(r("BillCode_ID"), dtBillCodes)
                If IsDBNull(r("BMap_ProblemFound")) = False Then dr1("Problem Found") = TranslateID(r("BMap_ProblemFound"), dtProblemFound)
                If IsDBNull(r("BMap_RepairAction")) = False Then dr1("Repair Action") = TranslateID(r("BMap_RepairAction"), dtRepairAction)
                If IsDBNull(r("BMap_RefDes")) = False Then dr1("Reference Designator") = TranslateID(r("BMap_RefDes"), dtRefDes)
                If IsDBNull(r("BMap_RefDesNumb")) = False Then dr1("Ref Des Number") = r("BMap_RefDesNumb")
                If IsDBNull(r("BMap_Failure")) = False Then dr1("Failure") = TranslateID(r("BMap_Failure"), dtFailure)
                If IsDBNull(r("BMap_Transaction")) = False Then dr1("Transaction") = TranslateID(r("BMap_Transaction"), dtTransaction)
                If r("BMap_Inactive") = 0 Then
                    dr1("Inactive") = "NO"
                Else
                    dr1("Inactive") = "YES"
                End If

                dtMainDataGrid.Rows.Add(dr1)

            Next

        End Sub




        Private Sub cboManufacturer_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboManufacturer.SelectionChangeCommitted
            dtMainDataGrid.Clear()
            'load_generic_ComboBox(cboModel, "Select model_id as tdID, model_desc as tdText FROM tmodel WHERE manuf_id = " & cboManufacturer.SelectedValue & " AND prod_id = 2 ORDER BY model_desc")
            load_generic_ComboBox(cboModel, "Select model_id as tdID, model_desc as tdText FROM tmodel WHERE manuf_id = " & cboManufacturer.SelectedValue & " ORDER BY model_desc")
        End Sub

        Private Function makeMainDataGrid() As DataTable
            Dim dt As New DataTable("MainData")

            Dim dcID As New DataColumn("ID")
            dt.Columns.Add(dcID)
            Dim dcCust_ID As New DataColumn("Customer ID")
            dt.Columns.Add(dcCust_ID)
            Dim dcModel_ID As New DataColumn("Model ID")
            dt.Columns.Add(dcModel_ID)
            Dim dcBillCode_ID As New DataColumn("BillCode")
            dt.Columns.Add(dcBillCode_ID)
            Dim dcBillCode_Desc As New DataColumn("BillCode Description")
            dt.Columns.Add(dcBillCode_Desc)
            Dim dcProblemFound As New DataColumn("Problem Found")
            dt.Columns.Add(dcProblemFound)
            Dim dcRepairAction As New DataColumn("Repair Action")
            dt.Columns.Add(dcRepairAction)
            Dim dcRefDes As New DataColumn("Reference Designator")
            dt.Columns.Add(dcRefDes)
            Dim dcRefDesNum As New DataColumn("Ref Des Number")
            dt.Columns.Add(dcRefDesNum)
            Dim dcFailure As New DataColumn("Failure")
            dt.Columns.Add(dcFailure)
            Dim dcTransaction As New DataColumn("Transaction")
            dt.Columns.Add(dcTransaction)
            Dim dcInactive As New DataColumn("Inactive")
            dt.Columns.Add(dcInactive)

            dtMainDataGrid = dt

        End Function


        Private Function TranslateID(ByVal vID As Long, ByVal vdt As DataTable) As String
            Dim xcount As Integer = 0
            Dim r As DataRow
            For xcount = 0 To vdt.Rows.Count - 1
                r = vdt.Rows(xcount)
                If r("tdID") = vID Then
                    Return r("tdText")
                End If
            Next
        End Function

        Private Function TranslateString(ByVal vString As String, ByVal vdt As DataTable) As Long
            Dim xcount As Integer = 0
            Dim r As DataRow
            For xcount = 0 To vdt.Rows.Count - 1
                r = vdt.Rows(xcount)
                If r("tdText") = vString Then
                    Return r("tdID")
                End If
            Next
            MsgBox("No Value Found for " & vString)
        End Function


        Private Sub getData()

            dtMainDataGrid.Clear()

            If cboCustomer.SelectedValue > 0 And cboModel.SelectedValue > 0 Then
                load_generic_BillCodes(cboModel.SelectedValue)
                cboBillCodes.DataSource = dtBillCodes

                If cboCustomer.SelectedValue > 0 And cboModel.SelectedValue > 0 Then
                    load_generic_BillCodes(cboModel.SelectedValue)
                    GetMainData()
                Else
                    MsgBox("The data can not be obtained. Please try again.")
                End If

                clearBoxes()
                EnableBoxes()
            End If

        End Sub


        Private Sub btnGetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetData.Click

            getData()

        End Sub

        Private Sub MainGrid_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MainGrid.MouseUp

            If vMouseDown = MainGrid.Columns(3).Value Then
                'Exit Sub
            End If

            EnableBoxes()
            clearBoxes()

            Me.cboRemoveHighlightBackground(cboBillCodes)
            Me.cboRemoveHighlightBackground(cboProblemFound)
            Me.cboRemoveHighlightBackground(cboRepairAction)
            Me.cboRemoveHighlightBackground(cboReferenceDesignator)
            Me.cboRemoveHighlightBackground(cboFailure)
            Me.cboRemoveHighlightBackground(cboTransaction)
            Me.txtRemoveHighlightBackground(txtRefDesNumber)

            Dim xCount As Integer = 0

            'Dim strMsg As String = MainGrid.Columns(0).Value & vbCrLf & _
            'MainGrid.Columns(1).Value & vbCrLf & _
            'MainGrid.Columns(2).Value & vbCrLf & _
            'MainGrid.Columns(3).Value & vbCrLf & _
            'MainGrid.Columns(4).Value & vbCrLf & _
            'MainGrid.Columns(5).Value & vbCrLf & _
            'MainGrid.Columns(6).Value & vbCrLf & _
            'MainGrid.Columns(7).Value & vbCrLf & _
            'MainGrid.Columns(8).Value & vbCrLf & _
            'MainGrid.Columns(9).Value & vbCrLf
            'MsgBox(strMsg)
            Dim valueBillCode As String = MainGrid.Columns(4).Value

            '//Populate combo boxes with data values from grid
            If IsDBNull(MainGrid.Columns(3).Value) = False Then
                cboBillCodes.SelectedIndex = 0
                cboBillCodes.SelectedValue = TranslateString(MainGrid.Columns(4).Value, dtBillCodes)
                'cboBillCodes.Enabled = False
            Else
                cboHighlightBackground(cboBillCodes)
            End If

            If IsDBNull(MainGrid.Columns(5).Value) = False Then
                cboProblemFound.SelectedIndex = 0
                cboProblemFound.SelectedValue = TranslateString(MainGrid.Columns(5).Value, dtProblemFound)
            Else
                cboHighlightBackground(cboProblemFound)
            End If
            If IsDBNull(MainGrid.Columns(6).Value) = False Then
                cboRepairAction.SelectedIndex = 0
                cboRepairAction.SelectedValue = TranslateString(MainGrid.Columns(6).Value, dtRepairAction)
            Else
                cboHighlightBackground(cboRepairAction)
            End If

            If IsDBNull(MainGrid.Columns(7).Value) = False Then
                cboReferenceDesignator.SelectedIndex = 0
                cboReferenceDesignator.SelectedValue = TranslateString(MainGrid.Columns(7).Value, dtRefDes)
            Else
                cboHighlightBackground(cboReferenceDesignator)
            End If

            If IsDBNull(MainGrid.Columns(8).Value) = False Then
                txtRefDesNumber.Text = MainGrid.Columns(8).Value
            Else
                txtHighlightBackground(txtRefDesNumber)
            End If
            If IsDBNull(MainGrid.Columns(9).Value) = False Then
                cboFailure.SelectedIndex = 0
                cboFailure.SelectedValue = TranslateString(MainGrid.Columns(9).Value, dtFailure)
            Else
                cboHighlightBackground(cboFailure)
            End If

            If IsDBNull(MainGrid.Columns(10).Value) = False Then
                cboTransaction.SelectedIndex = 0
                cboTransaction.SelectedValue = TranslateString(MainGrid.Columns(10).Value, dtTransaction)
            Else
                cboHighlightBackground(cboTransaction)
            End If

            If IsDBNull(MainGrid.Columns(11).Value) = False Then
                If MainGrid.Columns(11).Value = "NO" Then
                    chkInactive.Checked = False
                Else
                    chkInactive.Checked = True
                End If
            End If

            btnGetData.Focus()

        End Sub


        Private Sub clearBoxes()
            cboBillCodes.Text = ""
            cboProblemFound.Text = ""
            cboRepairAction.Text = ""
            cboReferenceDesignator.Text = ""
            txtRefDesNumber.Text = ""
            cboFailure.Text = ""
            cboTransaction.Text = ""
            chkInactive.Checked = False
        End Sub

        Private Sub DisableBoxes()
            cboBillCodes.Enabled = False
            cboProblemFound.Enabled = False
            cboRepairAction.Enabled = False
            cboReferenceDesignator.Enabled = False
            txtRefDesNumber.Enabled = False
            cboFailure.Enabled = False
            cboTransaction.Enabled = False
            chkInactive.Enabled = False
        End Sub

        Private Sub EnableBoxes()
            cboBillCodes.Enabled = True
            cboProblemFound.Enabled = True
            cboRepairAction.Enabled = True
            cboReferenceDesignator.Enabled = True
            txtRefDesNumber.Enabled = True
            cboFailure.Enabled = True
            cboTransaction.Enabled = True
            chkInactive.Enabled = True
        End Sub

        Private Sub cboHighlightBackground(ByVal mctl As Control)
            CType(mctl, System.Windows.Forms.ComboBox).BackColor = Color.Yellow
        End Sub

        Private Sub txtHighlightBackground(ByVal mctl As Control)
            CType(mctl, System.Windows.Forms.TextBox).BackColor = Color.Yellow
        End Sub

        Private Sub cboRemoveHighlightBackground(ByVal mctl As Control)
            CType(mctl, System.Windows.Forms.ComboBox).BackColor = Color.White
        End Sub

        Private Sub txtRemoveHighlightBackground(ByVal mctl As Control)
            CType(mctl, System.Windows.Forms.TextBox).BackColor = Color.White
        End Sub


        Private Sub InsertRecord(ByVal lngBillcode As Long, ByVal lngProblemFound As Long, ByVal lngRepairAction As Long, ByVal lngFailure As Long, ByVal lngReferenceDesignator As Long, ByVal lngTransaction As Long, ByVal lngCustomer As Long, ByVal lngModel As Long)

            strSQL = ""
            Dim strSQLfields, strSQLvalues As String

            If IsDBNull(lngBillcode) = False Then
                strSQLfields += "BillCode_ID"
                strSQLvalues += lngBillcode
            End If
            If IsDBNull(lngCustomer) = False Then
                strSQLfields += ", Cust_ID"
                strSQLvalues += "," & lngCustomer
            End If
            If IsDBNull(lngModel) = False Then
                strSQLfields += ", Model_ID"
                strSQLvalues += "," & lngModel
            End If
            If IsDBNull(lngProblemFound) = False Then
                strSQLfields += ", BMap_ProblemFound"
                strSQLvalues += "," & lngProblemFound
            End If
            If IsDBNull(lngRepairAction) = False Then
                strSQLfields += ", BMap_RepairAction"
                strSQLvalues += "," & lngRepairAction
            End If
            If IsDBNull(lngReferenceDesignator) = False Then
                strSQLfields += ", BMap_RefDes"
                strSQLvalues += "," & lngReferenceDesignator
            End If
            If IsDBNull(lngFailure) = False Then
                strSQLfields += ", BMap_Failure"
                strSQLvalues += "," & lngFailure
            End If
            If IsDBNull(lngTransaction) = False Then
                strSQLfields += ", BMap_Transaction"
                strSQLvalues += "," & lngTransaction
            End If
            If Len(Trim(txtRefDesNumber.Text)) > 0 Then
                strSQLfields += ", BMap_RefDesNumb"
                strSQLvalues += ",'" & Trim(txtRefDesNumber.Text) & "'"
            End If
            If chkInactive.Checked = False Then
                strSQLfields += ", BMap_Inactive"
                strSQLvalues += ",0"
            Else
                strSQLfields += ", BMap_Inactive"
                strSQLvalues += ",1"
            End If

            strSQL = "INSERT INTO tbillmap (" & strSQLfields & ") VALUES (" & strSQLvalues & ")"
            Dim blnRecordNEW As Boolean = dsPSS.OrderEntryUpdateDelete(strSQL)

            dtMainDataGrid.Clear()
            getData()
            'cboBillCodes.Enabled = True
            MainGrid.Focus()
            'DisableBoxes()

        End Sub


        Private Sub UpdateRecord(ByVal lngBillcode As Long, ByVal lngProblemFound As Long, ByVal lngRepairAction As Long, ByVal lngFailure As Long, ByVal lngReferenceDesignator As Long, ByVal lngTransaction As Long, ByVal lngCustomer As Long, ByVal lngModel As Long)
            strSQL = ""
            Dim strSQLedit As String

            'If IsDBNull(lngProblemFound) = False Then
            'strSQLedit += "BMap_ProblemFound = " & lngProblemFound
            'End If
            'If IsDBNull(lngRepairAction) = False Then
            'strSQLedit += ", BMap_RepairAction = " & lngRepairAction
            'End If
            'If IsDBNull(lngReferenceDesignator) = False Then
            'strSQLedit += ", BMap_RefDes = " & lngReferenceDesignator
            'End If
            'If IsDBNull(lngFailure) = False Then
            'strSQLedit += ", BMap_Failure = " & lngFailure
            'End If
            'If IsDBNull(lngTransaction) = False Then
            'strSQLedit += ", BMap_Transaction = " & lngTransaction
            'End If
            'If Len(Trim(txtRefDesNumber.Text)) > 0 Then
            'strSQLedit += ", BMap_RefDesNumb = " & Trim(txtRefDesNumber.Text)
            'End If
            'If chkInactive.Checked = False Then
            'strSQLedit += ", BMap_Inactive = 0"
            'Else
            strSQLedit += "BMap_Inactive = 1"
            'End If

            strSQL = "UPDATE tbillmap SET " & strSQLedit & " WHERE Cust_ID = " & lngCustomer & " AND Model_ID = " & lngModel & " AND BillCode_ID = " & lngBillcode
            Dim blnRecordUPDATE As Boolean = dsPSS.OrderEntryUpdateDelete(strSQL)

            'dtMainDataGrid.Clear()
            'getData()
            'cboBillCodes.Enabled = True
            'MainGrid.Focus()
            'DisableBoxes()

        End Sub


        Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

            Dim valueStatus As Integer = 0

            Dim vBC As Integer = TranslateString(cboBillCodes.Text, dtBillCodes)
            Dim x As Integer = 0
            Dim r As DataRow

            Dim blnDup As Boolean = True
            Dim dtDup As DataTable
            Dim y As Integer
            Dim rDup As DataRow

            For x = 0 To dtMainDataGrid.Rows.Count - 1
                r = dtMainDataGrid.Rows(x)
                If r("BillCode") = vBC Then
                    valueStatus = 1
                    Exit For
                End If
            Next

            '//Make sure all fields are entered
            Dim lngBillcode, _
            lngProblemFound, _
            lngRepairAction, _
            lngFailure, _
            lngReferenceDesignator, _
            lngTransaction, _
            lngCustomer, _
            lngModel As Long
            Try
                lngBillcode = Me.TranslateString(cboBillCodes.Text, dtBillCodes)
                lngProblemFound = TranslateString(cboProblemFound.Text, dtProblemFound)
                lngRepairAction = TranslateString(cboRepairAction.Text, dtRepairAction)
                lngFailure = TranslateString(cboFailure.Text, dtFailure)
                lngReferenceDesignator = TranslateString(cboReferenceDesignator.Text, dtRefDes)
                lngTransaction = TranslateString(cboTransaction.Text, dtTransaction)
                lngCustomer = cboCustomer.SelectedValue
                lngModel = cboModel.SelectedValue
            Catch ex As Exception
                MsgBox(ex.ToString)
                btnSave.Focus()
                Exit Sub
            End Try



            '//if vStatus = NEW then INSERT
            If valueStatus = 0 Then
                InsertRecord(lngBillcode, lngProblemFound, lngRepairAction, lngFailure, lngReferenceDesignator, lngTransaction, lngCustomer, lngModel)
            ElseIf valueStatus = 1 Then

                '//check for duplicate
                '//Check to see if duplicate
                dtDup = dsPSS.OrderEntrySelect("SELECT * FROM tbillmap WHERE Cust_ID = " & lngCustomer & " AND Model_ID = " & lngModel & " AND BillCode_ID = " & lngBillcode & " AND BMap_Inactive = 1 ORDER BY BMap_ID Desc")
                If dtDup.Rows.Count > 0 Then
                    For y = 0 To dtDup.Rows.Count - 1
                        r = dtDup.Rows(y)
                        If r("BillCode_ID") <> TranslateString(cboBillCodes.Text, dtBillCodes) Then blnDup = False
                        If r("BMap_ProblemFound") <> TranslateString(cboProblemFound.Text, dtProblemFound) Then blnDup = False
                        If r("BMap_RepairAction") <> TranslateString(cboRepairAction.Text, dtRepairAction) Then blnDup = False
                        If r("BMap_Failure") <> TranslateString(cboFailure.Text, dtFailure) Then blnDup = False
                        If r("BMap_RefDes") <> TranslateString(cboReferenceDesignator.Text, dtRefDes) Then blnDup = False
                        If IsDBNull(r("BMap_Transaction")) = True And Len(Trim(cboTransaction.Text)) > 0 Then blnDup = False
                        Try
                            If r("BMap_Transaction") <> TranslateString(cboTransaction.Text, dtTransaction) Then blnDup = False
                        Catch ex As Exception

                        End Try
                        If r("Cust_ID") <> cboCustomer.SelectedValue Then blnDup = False
                        If r("Model_ID") <> cboModel.SelectedValue Then blnDup = False
                        Try
                            If r("BMap_RefDesNumb") <> txtRefDesNumber.Text Then blnDup = False
                        Catch ex As Exception
                        End Try
                    Next

                    If blnDup = True Then
                        MsgBox("This is a duplicate record. The edit will not continue.")
                        Exit Sub
                    End If
                End If

                UpdateRecord(lngBillcode, lngProblemFound, lngRepairAction, lngFailure, lngReferenceDesignator, lngTransaction, lngCustomer, lngModel)
                System.Windows.Forms.Application.DoEvents()
                InsertRecord(lngBillcode, lngProblemFound, lngRepairAction, lngFailure, lngReferenceDesignator, lngTransaction, lngCustomer, lngModel)
                System.Windows.Forms.Application.DoEvents()
            End If

            Me.cboRemoveHighlightBackground(cboBillCodes)
            Me.cboRemoveHighlightBackground(cboProblemFound)
            Me.cboRemoveHighlightBackground(cboRepairAction)
            Me.cboRemoveHighlightBackground(cboReferenceDesignator)
            Me.cboRemoveHighlightBackground(cboFailure)
            Me.cboRemoveHighlightBackground(cboTransaction)
            Me.txtRemoveHighlightBackground(txtRefDesNumber)


            clearBoxes()

            Me.MainGrid.Select()

            'btnGetData.Focus()
            'Me.MainGrid.Focus()

        End Sub


        Private Function saveRecord()

            '//First make sure valid values for all entries
            If Len(Trim(cboCustomer.SelectedValue)) < 1 Then
                Exit Function
            End If

            If Len(Trim(cboModel.SelectedValue)) < 1 Then
                Exit Function
            End If

            If Len(Trim(cboBillCodes.SelectedValue)) < 1 Then
                cboBillCodes.Focus()
                Exit Function
            End If

            If Len(Trim(cboProblemFound.SelectedValue)) < 1 Then
                cboProblemFound.Focus()
                Exit Function
            End If

            If Len(Trim(cboRepairAction.SelectedValue)) < 1 Then
                cboRepairAction.Focus()
                Exit Function
            End If

            If Len(Trim(cboReferenceDesignator.SelectedValue)) < 1 Then
                cboReferenceDesignator.Focus()
                Exit Function
            End If

            If Len(Trim(cboFailure.SelectedValue)) < 1 Then
                cboFailure.Focus()
                Exit Function
            End If

            If Len(Trim(cboTransaction.SelectedValue)) < 1 Then
                cboTransaction.Focus()
                Exit Function
            End If

            '//Create field string
            Dim strField As String = "(BMap_ProblemFound, BMap_RepairAction, BMap_RefDes, BMap_RefDesNumb, BMap_Failure, " & _
                                     "BMap_Transaction, Cust_ID, Model_ID, BillCode_ID)"
            Dim strValues As String = "(" & cboProblemFound.SelectedValue & ", " & cboRepairAction.SelectedValue & ", " & _
                                      cboReferenceDesignator.SelectedValue & ", '" & txtRefDesNumber.Text & "', " & _
                                      cboFailure.SelectedValue & ", " & cboTransaction.SelectedValue & ", " & _
                                      cboCustomer.SelectedValue & ", " & cboModel.SelectedValue & ", " & _
                                      cboBillCodes.SelectedValue & ")"

        End Function




        Private Sub cboCustomer_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustomer.SelectionChangeCommitted
            dtMainDataGrid.Clear()
            getData()
        End Sub

        Private Sub cboModel_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboModel.SelectionChangeCommitted
            dtMainDataGrid.Clear()
            getData()
        End Sub

        Private Sub DeleteEntry()

            Dim lngCustomer As Long = cboCustomer.SelectedValue
            Dim lngModel As Long = cboModel.SelectedValue
            Dim lngBillCode As Long = TranslateString(cboBillCodes.Text, dtBillCodes)

            If lngCustomer > 0 And lngModel > 0 And lngBillCode > 0 Then
                '//Verify that this selects 1 record
                Dim dtSelect As DataTable = dsPSS.OrderEntrySelect("SELECT * FROM tbillmap WHERE Cust_ID = " & lngCustomer & " AND Model_ID = " & lngModel & " AND BillCode_ID = " & lngBillCode)
                If dtSelect.Rows.Count > 0 And dtSelect.Rows.Count < 2 Then
                    '//Perorm record delete
                    strSQL = "DELETE FROM tbillmap WHERE Cust_ID = " & lngCustomer & " AND Model_ID = " & lngModel & " AND BillCode_ID = " & lngBillCode
                    Dim blnDelete As Boolean = dsPSS.OrderEntryUpdateDelete(strSQL)
                    If blnDelete = False Then
                        MsgBox("The record could not be deleted. Please contact IT.")
                    End If
                Else
                    MsgBox("A distinct record could not be determined for deletion. Please contact IT.")
                End If
            Else
                MsgBox("A distinct record could not be determined for deletion. Please contact IT.")
            End If

            dtMainDataGrid.Clear()
            getData()
            btnGetData.Focus()
            'MainGrid.Focus()

            Me.cboRemoveHighlightBackground(cboBillCodes)
            Me.cboRemoveHighlightBackground(cboProblemFound)
            Me.cboRemoveHighlightBackground(cboRepairAction)
            Me.cboRemoveHighlightBackground(cboReferenceDesignator)
            Me.cboRemoveHighlightBackground(cboFailure)
            Me.cboRemoveHighlightBackground(cboTransaction)
            Me.txtRemoveHighlightBackground(txtRefDesNumber)

        End Sub





        Private Sub MainGrid_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MainGrid.MouseDown
            Try
                If MainGrid.RowCount > 0 Then
                    vMouseDown = MainGrid.Columns(3).Value
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub


        Private Sub cboModel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboModel.SelectedIndexChanged

        End Sub

        Private Sub chkShowInactive_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShowInactive.CheckedChanged
            If chkShowInactive.Checked = False Then
                btnSave.Enabled = True
            Else
                btnSave.Enabled = False
            End If
            dtMainDataGrid.Clear()
            getData()
        End Sub

        Private Sub grpEdit_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grpEdit.Enter

        End Sub

        Private Sub MainGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainGrid.Click

        End Sub

        '*******************************************************************
        'Added by Lan on 03/16/07
        'Take all services billcode in lbillcodes for selected model and 
        ' get data on the latest entry in tbillmap of the same billcode and 
        ' insert in to tbillmap for that selected model and customer
        Private Sub cmdAutoMapServices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAutoMapServices.Click
            Dim i As Integer = 0
            Dim objBillMapCheck As New PSS.Data.Buisness.BillMapCheck()

            Try
                'First make sure valid values for all entries
                If Len(Trim(cboCustomer.SelectedValue)) < 1 Then
                    MessageBox.Show("Please select customer.", "Map Service Billcodes", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                If Len(Trim(cboModel.SelectedValue)) < 1 Then
                    MessageBox.Show("Please select model.", "Map Service Billcodes", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                If MessageBox.Show("Are you sure you want to auto-map the services for the selected model?", "Map Service Billcodes", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Exit Sub
                End If

                i = objBillMapCheck.AutoMapServices(Me.cboCustomer.SelectedValue, Me.cboModel.SelectedValue)

                'If i = 0 Then
                '    MessageBox.Show("No similar bill code found for this model.")
                'End If
                dtMainDataGrid.Clear()
                getData()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Auto Map Services", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                objBillMapCheck = Nothing
            End Try
        End Sub

        '********************************************************************
        'Added by Lan on 03/16/07
        Private Sub cmdDelAutoMapServices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelAutoMapServices.Click
            Dim i As Integer = 0
            Dim objBillMapCheck As New PSS.Data.Buisness.BillMapCheck()

            Try
                'First make sure valid values for all entries
                If Len(Trim(cboCustomer.SelectedValue)) < 1 Then
                    MessageBox.Show("Please select customer.", "Auto Map Services", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                If Len(Trim(cboModel.SelectedValue)) < 1 Then
                    MessageBox.Show("Please select model.", "Auto Map Services", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                If MessageBox.Show("Are you sure you want to delete the services for the selected model?", "Delete Service Billcodes", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Exit Sub
                End If


                i = objBillMapCheck.DelAutoMapServices(Me.cboCustomer.SelectedValue, Me.cboModel.SelectedValue)

                dtMainDataGrid.Clear()
                getData()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Auto Map Services", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                objBillMapCheck = Nothing
            End Try
        End Sub

        '********************************************************************
        'Added by Lan on 08/13/07
        Private Sub btnGetUnMapBillCodes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetUnMapBillCodes.Click
            Dim i As Integer = 0
            Dim objBillMapCheck As New PSS.Data.Buisness.BillMapCheck()

            Try
                'First make sure valid values for all entries
                If Len(Trim(cboCustomer.SelectedValue)) < 1 Then
                    MessageBox.Show("Please select customer.", "Auto Map Services", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                i = objBillMapCheck.GetUnMapBillcodes(Me.cboCustomer.SelectedValue)

                If i = 0 Then
                    MessageBox.Show("No un-map billcode.", "Get Un-Map Billcodes", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Auto Map Services", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                objBillMapCheck = Nothing
            End Try
        End Sub

        '********************************************************************

    End Class

End Namespace
