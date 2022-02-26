Imports CrystalDecisions.CrystalReports.Engine
Imports System
Imports System.GC
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports PSS.Core
Imports PSS.Rules
Imports PSS.Core.[Global]


Namespace Gui.Receiving

    Public Class frmFileRec
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
        Friend WithEvents txtRMA As System.Windows.Forms.TextBox
        Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
        Friend WithEvents btnReceive As System.Windows.Forms.Button
        Friend WithEvents lstNarrative As System.Windows.Forms.ListBox
        Friend WithEvents lbl3 As System.Windows.Forms.Label
        Friend WithEvents lbl2 As System.Windows.Forms.Label
        Friend WithEvents lbl1 As System.Windows.Forms.Label
        Friend WithEvents lbl4 As System.Windows.Forms.Label
        Friend WithEvents cboManufacturer As PSS.Gui.Controls.ComboBox
        Friend WithEvents cboModel As PSS.Gui.Controls.ComboBox
        Friend WithEvents MainGrid As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents chkProgramming As System.Windows.Forms.CheckBox
        Friend WithEvents chkFluffBuff As System.Windows.Forms.CheckBox
        Friend WithEvents chkCosmetic As System.Windows.Forms.CheckBox
        Friend WithEvents chkPrint As System.Windows.Forms.CheckBox
        Friend WithEvents cboReceive As System.Windows.Forms.ComboBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents chkTesting As System.Windows.Forms.CheckBox
        Friend WithEvents chkVerifySku As System.Windows.Forms.CheckBox
        Friend WithEvents lblCustomer As System.Windows.Forms.Label
        Friend WithEvents cboCustomer As PSS.Gui.Controls.ComboBox
        Friend WithEvents lblPO As System.Windows.Forms.Label
        Friend WithEvents txtPO As System.Windows.Forms.TextBox
        Friend WithEvents lblGroup As System.Windows.Forms.Label
        Friend WithEvents cboGroup As System.Windows.Forms.ComboBox
        Friend WithEvents chkInsulator As System.Windows.Forms.CheckBox
        Friend WithEvents btnRevByFile As System.Windows.Forms.Button
        Friend WithEvents chkReject As System.Windows.Forms.CheckBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmFileRec))
            Me.lbl3 = New System.Windows.Forms.Label()
            Me.lbl2 = New System.Windows.Forms.Label()
            Me.lbl1 = New System.Windows.Forms.Label()
            Me.txtRMA = New System.Windows.Forms.TextBox()
            Me.txtQuantity = New System.Windows.Forms.TextBox()
            Me.lbl4 = New System.Windows.Forms.Label()
            Me.btnReceive = New System.Windows.Forms.Button()
            Me.lstNarrative = New System.Windows.Forms.ListBox()
            Me.cboManufacturer = New PSS.Gui.Controls.ComboBox()
            Me.cboModel = New PSS.Gui.Controls.ComboBox()
            Me.MainGrid = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.chkProgramming = New System.Windows.Forms.CheckBox()
            Me.chkFluffBuff = New System.Windows.Forms.CheckBox()
            Me.chkCosmetic = New System.Windows.Forms.CheckBox()
            Me.chkPrint = New System.Windows.Forms.CheckBox()
            Me.cboReceive = New System.Windows.Forms.ComboBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.chkTesting = New System.Windows.Forms.CheckBox()
            Me.chkVerifySku = New System.Windows.Forms.CheckBox()
            Me.lblCustomer = New System.Windows.Forms.Label()
            Me.cboCustomer = New PSS.Gui.Controls.ComboBox()
            Me.lblPO = New System.Windows.Forms.Label()
            Me.txtPO = New System.Windows.Forms.TextBox()
            Me.lblGroup = New System.Windows.Forms.Label()
            Me.cboGroup = New System.Windows.Forms.ComboBox()
            Me.chkInsulator = New System.Windows.Forms.CheckBox()
            Me.btnRevByFile = New System.Windows.Forms.Button()
            Me.chkReject = New System.Windows.Forms.CheckBox()
            CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lbl3
            '
            Me.lbl3.Location = New System.Drawing.Point(64, 120)
            Me.lbl3.Name = "lbl3"
            Me.lbl3.Size = New System.Drawing.Size(48, 16)
            Me.lbl3.TabIndex = 0
            Me.lbl3.Text = "RMA:"
            Me.lbl3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lbl2
            '
            Me.lbl2.Location = New System.Drawing.Point(64, 96)
            Me.lbl2.Name = "lbl2"
            Me.lbl2.Size = New System.Drawing.Size(48, 16)
            Me.lbl2.TabIndex = 1
            Me.lbl2.Text = "Model:"
            Me.lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lbl1
            '
            Me.lbl1.Location = New System.Drawing.Point(32, 72)
            Me.lbl1.Name = "lbl1"
            Me.lbl1.Size = New System.Drawing.Size(80, 16)
            Me.lbl1.TabIndex = 3
            Me.lbl1.Text = "Manufacturer:"
            Me.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtRMA
            '
            Me.txtRMA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtRMA.Location = New System.Drawing.Point(120, 112)
            Me.txtRMA.Name = "txtRMA"
            Me.txtRMA.Size = New System.Drawing.Size(144, 20)
            Me.txtRMA.TabIndex = 4
            Me.txtRMA.Text = ""
            '
            'txtQuantity
            '
            Me.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtQuantity.Location = New System.Drawing.Point(120, 136)
            Me.txtQuantity.Name = "txtQuantity"
            Me.txtQuantity.Size = New System.Drawing.Size(64, 20)
            Me.txtQuantity.TabIndex = 5
            Me.txtQuantity.Text = ""
            '
            'lbl4
            '
            Me.lbl4.Location = New System.Drawing.Point(56, 144)
            Me.lbl4.Name = "lbl4"
            Me.lbl4.Size = New System.Drawing.Size(56, 16)
            Me.lbl4.TabIndex = 6
            Me.lbl4.Text = "Quantity:"
            Me.lbl4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnReceive
            '
            Me.btnReceive.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnReceive.Location = New System.Drawing.Point(32, 384)
            Me.btnReceive.Name = "btnReceive"
            Me.btnReceive.Size = New System.Drawing.Size(232, 24)
            Me.btnReceive.TabIndex = 17
            Me.btnReceive.Text = "Receive by Warehouse Receive"
            '
            'lstNarrative
            '
            Me.lstNarrative.BackColor = System.Drawing.SystemColors.Control
            Me.lstNarrative.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lstNarrative.Location = New System.Drawing.Point(32, 416)
            Me.lstNarrative.Name = "lstNarrative"
            Me.lstNarrative.Size = New System.Drawing.Size(232, 15)
            Me.lstNarrative.TabIndex = 0
            Me.lstNarrative.TabStop = False
            '
            'cboManufacturer
            '
            Me.cboManufacturer.AutoComplete = True
            Me.cboManufacturer.Location = New System.Drawing.Point(120, 64)
            Me.cboManufacturer.Name = "cboManufacturer"
            Me.cboManufacturer.Size = New System.Drawing.Size(144, 21)
            Me.cboManufacturer.TabIndex = 2
            '
            'cboModel
            '
            Me.cboModel.AutoComplete = True
            Me.cboModel.Location = New System.Drawing.Point(120, 88)
            Me.cboModel.Name = "cboModel"
            Me.cboModel.Size = New System.Drawing.Size(144, 21)
            Me.cboModel.TabIndex = 3
            '
            'MainGrid
            '
            Me.MainGrid.AllowColMove = False
            Me.MainGrid.AllowColSelect = False
            Me.MainGrid.AllowDelete = True
            Me.MainGrid.AllowFilter = False
            Me.MainGrid.AllowSort = False
            Me.MainGrid.AllowUpdate = False
            Me.MainGrid.AlternatingRows = True
            Me.MainGrid.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.MainGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.MainGrid.CaptionHeight = 17
            Me.MainGrid.GroupByCaption = "Drag a column header here to group by that column"
            Me.MainGrid.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.MainGrid.Location = New System.Drawing.Point(272, 8)
            Me.MainGrid.Name = "MainGrid"
            Me.MainGrid.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.MainGrid.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.MainGrid.PreviewInfo.ZoomFactor = 75
            Me.MainGrid.RowHeight = 15
            Me.MainGrid.Size = New System.Drawing.Size(472, 416)
            Me.MainGrid.TabIndex = 117
            Me.MainGrid.Text = "C1TrueDBGrid1"
            Me.MainGrid.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Style11{}Style12{}Style13{}Style5{}Style4{}Style7{}Style6{}Style1{}Sele" & _
            "cted{ForeColor:HighlightText;BackColor:Highlight;}Heading{Wrap:True;BackColor:Co" & _
            "ntrol;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}OddRow{}Foo" & _
            "ter{}Caption{AlignHorz:Center;}Normal{Font:Verdana, 8.25pt;}HighlightRow{ForeCol" & _
            "or:HighlightText;BackColor:Highlight;}EvenRow{BackColor:Aqua;}Editor{}RecordSele" & _
            "ctor{AlignImage:Center;}Style9{}Style8{}Style3{}Style2{}Style14{}Style15{}Group{" & _
            "AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style10{AlignHor" & _
            "z:Near;}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""Fal" & _
            "se"" AllowColSelect=""False"" Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17""" & _
            " ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder" & _
            """ RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" Horizonta" & _
            "lScrollGroup=""1""><Height>414</Height><CaptionStyle parent=""Style2"" me=""Style10"" " & _
            "/><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""" & _
            "Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=" & _
            """Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle p" & _
            "arent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style" & _
            "7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow""" & _
            " me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><Sele" & _
            "ctedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><" & _
            "ClientRect>0, 0, 470, 414</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sun" & _
            "ken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style pa" & _
            "rent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Headi" & _
            "ng"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading""" & _
            " me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" m" & _
            "e=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" m" & _
            "e=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""R" & _
            "ecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption""" & _
            " me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits>" & _
            "<Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>" & _
            "0, 0, 470, 414</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><Print" & _
            "PageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.SteelBlue
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(32, 232)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(232, 96)
            Me.Label1.TabIndex = 118
            Me.Label1.Text = "AutoBill"
            '
            'chkProgramming
            '
            Me.chkProgramming.BackColor = System.Drawing.Color.SteelBlue
            Me.chkProgramming.ForeColor = System.Drawing.Color.White
            Me.chkProgramming.Location = New System.Drawing.Point(112, 240)
            Me.chkProgramming.Name = "chkProgramming"
            Me.chkProgramming.Size = New System.Drawing.Size(104, 16)
            Me.chkProgramming.TabIndex = 9
            Me.chkProgramming.Text = "Programming"
            '
            'chkFluffBuff
            '
            Me.chkFluffBuff.BackColor = System.Drawing.Color.SteelBlue
            Me.chkFluffBuff.ForeColor = System.Drawing.Color.White
            Me.chkFluffBuff.Location = New System.Drawing.Point(112, 256)
            Me.chkFluffBuff.Name = "chkFluffBuff"
            Me.chkFluffBuff.Size = New System.Drawing.Size(104, 16)
            Me.chkFluffBuff.TabIndex = 10
            Me.chkFluffBuff.Text = "Fluff and Buff"
            '
            'chkCosmetic
            '
            Me.chkCosmetic.BackColor = System.Drawing.Color.SteelBlue
            Me.chkCosmetic.Enabled = False
            Me.chkCosmetic.ForeColor = System.Drawing.Color.White
            Me.chkCosmetic.Location = New System.Drawing.Point(112, 272)
            Me.chkCosmetic.Name = "chkCosmetic"
            Me.chkCosmetic.Size = New System.Drawing.Size(104, 16)
            Me.chkCosmetic.TabIndex = 11
            Me.chkCosmetic.Text = "Cosmetic"
            '
            'chkPrint
            '
            Me.chkPrint.Location = New System.Drawing.Point(112, 344)
            Me.chkPrint.Name = "chkPrint"
            Me.chkPrint.Size = New System.Drawing.Size(96, 16)
            Me.chkPrint.TabIndex = 15
            Me.chkPrint.Text = "Print Traveller"
            '
            'cboReceive
            '
            Me.cboReceive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboReceive.Items.AddRange(New Object() {"Flashing", "Level 1.5 Repair"})
            Me.cboReceive.Location = New System.Drawing.Point(120, 160)
            Me.cboReceive.Name = "cboReceive"
            Me.cboReceive.Size = New System.Drawing.Size(144, 21)
            Me.cboReceive.TabIndex = 6
            '
            'Label2
            '
            Me.Label2.Location = New System.Drawing.Point(24, 168)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(88, 16)
            Me.Label2.TabIndex = 120
            Me.Label2.Text = "Receive Type:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkTesting
            '
            Me.chkTesting.BackColor = System.Drawing.Color.SteelBlue
            Me.chkTesting.ForeColor = System.Drawing.Color.White
            Me.chkTesting.Location = New System.Drawing.Point(112, 288)
            Me.chkTesting.Name = "chkTesting"
            Me.chkTesting.Size = New System.Drawing.Size(104, 16)
            Me.chkTesting.TabIndex = 12
            Me.chkTesting.Text = "Testing"
            '
            'chkVerifySku
            '
            Me.chkVerifySku.Location = New System.Drawing.Point(112, 328)
            Me.chkVerifySku.Name = "chkVerifySku"
            Me.chkVerifySku.Size = New System.Drawing.Size(96, 16)
            Me.chkVerifySku.TabIndex = 14
            Me.chkVerifySku.Text = "Verify SKU"
            '
            'lblCustomer
            '
            Me.lblCustomer.Location = New System.Drawing.Point(40, 48)
            Me.lblCustomer.Name = "lblCustomer"
            Me.lblCustomer.Size = New System.Drawing.Size(80, 16)
            Me.lblCustomer.TabIndex = 121
            Me.lblCustomer.Text = "Customer:"
            Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboCustomer
            '
            Me.cboCustomer.AutoComplete = True
            Me.cboCustomer.Location = New System.Drawing.Point(120, 40)
            Me.cboCustomer.Name = "cboCustomer"
            Me.cboCustomer.Size = New System.Drawing.Size(144, 21)
            Me.cboCustomer.TabIndex = 1
            '
            'lblPO
            '
            Me.lblPO.Location = New System.Drawing.Point(24, 184)
            Me.lblPO.Name = "lblPO"
            Me.lblPO.Size = New System.Drawing.Size(88, 16)
            Me.lblPO.TabIndex = 122
            Me.lblPO.Text = "PO:"
            Me.lblPO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtPO
            '
            Me.txtPO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPO.Location = New System.Drawing.Point(120, 184)
            Me.txtPO.Name = "txtPO"
            Me.txtPO.Size = New System.Drawing.Size(64, 20)
            Me.txtPO.TabIndex = 7
            Me.txtPO.Text = ""
            '
            'lblGroup
            '
            Me.lblGroup.Location = New System.Drawing.Point(24, 208)
            Me.lblGroup.Name = "lblGroup"
            Me.lblGroup.Size = New System.Drawing.Size(88, 16)
            Me.lblGroup.TabIndex = 124
            Me.lblGroup.Text = "Group:"
            Me.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblGroup.Visible = False
            '
            'cboGroup
            '
            Me.cboGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboGroup.Items.AddRange(New Object() {"Flashing", "Level 1.5 Repair"})
            Me.cboGroup.Location = New System.Drawing.Point(120, 208)
            Me.cboGroup.Name = "cboGroup"
            Me.cboGroup.Size = New System.Drawing.Size(144, 21)
            Me.cboGroup.TabIndex = 8
            Me.cboGroup.Visible = False
            '
            'chkInsulator
            '
            Me.chkInsulator.BackColor = System.Drawing.Color.SteelBlue
            Me.chkInsulator.ForeColor = System.Drawing.Color.White
            Me.chkInsulator.Location = New System.Drawing.Point(112, 304)
            Me.chkInsulator.Name = "chkInsulator"
            Me.chkInsulator.Size = New System.Drawing.Size(104, 16)
            Me.chkInsulator.TabIndex = 13
            Me.chkInsulator.Text = "Insulator Tape"
            '
            'btnRevByFile
            '
            Me.btnRevByFile.Enabled = False
            Me.btnRevByFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnRevByFile.Location = New System.Drawing.Point(32, 8)
            Me.btnRevByFile.Name = "btnRevByFile"
            Me.btnRevByFile.Size = New System.Drawing.Size(232, 24)
            Me.btnRevByFile.TabIndex = 18
            Me.btnRevByFile.Text = "Receive by File"
            '
            'chkReject
            '
            Me.chkReject.Location = New System.Drawing.Point(112, 360)
            Me.chkReject.Name = "chkReject"
            Me.chkReject.Size = New System.Drawing.Size(72, 16)
            Me.chkReject.TabIndex = 16
            Me.chkReject.Text = "Reject"
            '
            'frmFileRec
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(752, 445)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkReject, Me.btnRevByFile, Me.chkInsulator, Me.lblGroup, Me.cboGroup, Me.txtPO, Me.lblPO, Me.cboCustomer, Me.lblCustomer, Me.chkVerifySku, Me.chkTesting, Me.Label2, Me.cboReceive, Me.chkPrint, Me.chkCosmetic, Me.chkFluffBuff, Me.chkProgramming, Me.Label1, Me.MainGrid, Me.cboModel, Me.cboManufacturer, Me.lstNarrative, Me.btnReceive, Me.txtQuantity, Me.lbl4, Me.txtRMA, Me.lbl1, Me.lbl2, Me.lbl3})
            Me.Name = "frmFileRec"
            Me.Text = "Receiving From File Source"
            CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private dtManuf, dtModel, dtCustomer, dtGroup As DataTable
        Private dtSource As New PSS.Data.Production.Joins()

        Private mManufacturer, mModel As Long
        '        Private mCustomer As Long = 2019
        Private mCustomer As Long = 0
        Private strSQL As String
        Private dtGridMain, dataGrid As DataTable


        Private mSerialNumber As String
        Private mSerialID As Int32
        Private _lTrayID As Long
        Private mWO As Long
        Private mSKU As Long
        Private mLocation As Long = 0
        Private mCount As Integer

        Private recUser As String = PSS.Core.[Global].ApplicationUser.User
        Private DeviceType As Integer = 2
        Private RecType As Integer = 1

        Private _device As Device = Nothing
        Private _tray As DataTable = Nothing
        Private blnAutoBill As Boolean
        Private intBillCode As Int32
        Private wipOwner As Integer
        Private wipOwnerParent As Integer

        Private vBillCode As Integer

        Private shortLOW, shortHIGH, longLOW, longHIGH As Integer

        Private iprod_id As Integer = 0

        Private Sub frmFileRec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            '*********************11/13/2006 by Lan
            'Checking for correct mapped of this computer
            Dim iParentGroupID As Integer = PSS.Core.[Global].ApplicationUser.GroupID
            Dim objWarehouse As PSS.Data.Buisness.Warehouse
            objWarehouse = New PSS.Data.Buisness.Warehouse()

            If Not objWarehouse.CheckCompMap(iParentGroupID) Then
                MessageBox.Show("This Computer is not mapped to right Group. Receiving can not be done.")
                Me.Close()
            End If
            If Not IsNothing(objWarehouse) Then
                objWarehouse = Nothing
            End If
            '****************************************

            mManufacturer = 0
            mModel = 0
            _lTrayID = 0
            mWO = 0
            mSKU = 0
            mCount = 0
            populateCustomers()
            populateManufacturers()
            populateGroups()
            dataGrid = CreateGridDT()
            MainGrid.DataSource = dataGrid

            chkProgramming.Checked = True
            chkPrint.Checked = True

            cboReceive.Text = "Flashing"

            cboManufacturer.Focus()
            cboManufacturer.Text = ""

        End Sub

        Private Sub populateCustomers()

            strSQL = "SELECT * FROM tcustomer WHERE Cust_ID IN (2019,2058,2206,2219) ORDER BY Cust_Name1"

            dtCustomer = dtSource.OrderEntrySelect(strSQL)
            cboCustomer.DataSource = dtCustomer
            cboCustomer.DisplayMember = dtCustomer.Columns("Cust_Name1").ToString
            cboCustomer.ValueMember = dtCustomer.Columns("Cust_ID").ToString
            cboCustomer.Text = ""

        End Sub


        Private Sub populateManufacturers()

            strSQL = "SELECT * FROM lmanuf ORDER BY Manuf_Desc"

            dtManuf = dtSource.OrderEntrySelect(strSQL)
            cboManufacturer.DataSource = dtManuf
            cboManufacturer.DisplayMember = dtManuf.Columns("Manuf_Desc").ToString
            cboManufacturer.ValueMember = dtManuf.Columns("Manuf_ID").ToString
            cboManufacturer.Text = ""

        End Sub


        Private Sub populateGroups()

            strSQL = "SELECT * FROM lgroups WHERE Group_RecType = 2 ORDER BY Group_Desc"

            dtGroup = dtSource.OrderEntrySelect(strSQL)
            cboGroup.DataSource = dtGroup
            cboGroup.DisplayMember = dtGroup.Columns("Group_Desc").ToString
            cboGroup.ValueMember = dtGroup.Columns("Group_ID").ToString
            cboGroup.Text = ""

        End Sub

        Private Sub populateModels()

            strSQL = "SELECT * FROM tmodel WHERE Manuf_ID = " & mManufacturer & " AND Prod_ID IN (2,5) ORDER BY Model_Desc"

            dtModel = dtSource.OrderEntrySelect(strSQL)

            '********************************************
            'lan add empty row into datatable 11/07/2006
            dtModel.LoadDataRow(New Object() {"0", "-- SELECT --"}, False)
            '********************************************

            cboModel.DataSource = dtModel
            cboModel.DisplayMember = dtModel.Columns("Model_Desc").ToString
            cboModel.ValueMember = dtModel.Columns("Model_ID").ToString
            cboModel.Text = ""

        End Sub


        Private Sub cboManufacturer_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboManufacturer.SelectedValueChanged
            Try
                mManufacturer = cboManufacturer.SelectedValue
                populateModels()
            Catch EX As Exception
            End Try
        End Sub


        Private Sub btnReceive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReceive.Click
            Me.Enabled = False

            Dim iModelID As Integer
            Dim ProdGrpCheck As New PSS.Data.Buisness.ProdGrpCheck()

            wipOwner = 0 '//New August 31, 2006
            wipOwnerParent = 0 '//New August 31, 2006

            txtRMA.Text = UCase(txtRMA.Text)
            System.Windows.Forms.Application.DoEvents()

            '//This section is to determine if the workorder name has reserved values {}
            Dim blnWOname As Boolean = True
            Dim strWOcheck As String
            Dim mCount As Integer = 1

            For mCount = 1 To Len(txtRMA.Text)
                strWOcheck = Mid$(Trim(txtRMA.Text), mCount, 1)
                If strWOcheck = "{" Or strWOcheck = "}" Then
                    blnWOname = False
                    Exit For
                End If
            Next
            If blnWOname = False Then
                MsgBox("The workorder name can not contain the values {,}", MsgBoxStyle.OKOnly, "Change Name")
                Me.Enabled = True
                Exit Sub
            End If
            '//This section is to determine if the workorder name has reserved values {}

            mCustomer = cboCustomer.SelectedValue

            '//This is a hard assign for locations based on customer
            '//SHOULD BE REMOVED
            If mCustomer = 2058 Then
                mLocation = 2579
            ElseIf mCustomer = 2019 Then
                mLocation = 2540
            ElseIf mCustomer = 2206 Then
                mLocation = 2730
            ElseIf mCustomer = 2219 Then
                mLocation = 2743
            End If

            '//Check to see if receive type is defined
            If Len(Trim(cboReceive.Text)) < 1 Then
                MsgBox("Please choose a receive type", MsgBoxStyle.OKOnly)
                Me.Enabled = True
                Exit Sub
            End If

            '//Should not be needed - March 31, 2006
            Try
                txtRMA.Text = UCase(txtRMA.Text)
            Catch ex As Exception
            End Try
            '//Should not be needed - March 31, 2006

            Dim blnCheck1 As Boolean = False

            Try
                '//Verify data has been selected before continuing
                If Len(Trim(cboCustomer.Text)) > 0 And mCustomer > 0 Then
                    If Len(Trim(cboManufacturer.Text)) > 0 And mManufacturer > 0 Then
                        If Len(Trim(cboModel.Text)) > 0 And mModel > 0 Then
                            If Len(Trim(txtRMA.Text)) > 0 Then
                                If CInt(txtQuantity.Text) > 0 Then
                                    'If Len(Trim(cboGroup.Text)) > 0 Then
                                    blnCheck1 = True
                                    'End If
                                End If
                            End If
                        End If
                    End If
                End If

            Catch ex As Exception
            End Try

            System.Windows.Forms.Application.DoEvents()
            If blnCheck1 = False Then
                MsgBox("File Receiving can not activate - not all data is supplied or the ID values are  corrupt")
                cboManufacturer.Focus()
                Me.Enabled = True
                Exit Sub
            End If
            '//Verify data has been selected before continuing

            '//If a PO is defined then get the appropriate information
            Dim vPO As Integer
            If Len(Trim(txtPO.Text)) > 0 Then
                Try
                    vPO = CInt(txtPO.Text) '//All PO values should be numeric
                    Dim dsPO As PSS.Data.Production.Joins
                    Dim dtPO As DataTable = dsPO.OrderEntrySelect("SELECT * FROM tpurchaseorder WHERE PO_ID = " & vPO)

                    If dtPO.Rows.Count < 1 Then '//This identifies that the PO number does not exists in tpurchaseorder
                        MsgBox("The PO value is invalid. Can not continue.", MsgBoxStyle.OKOnly, "ERROR")
                        Me.Enabled = True
                        Exit Sub
                    End If
                Catch ex As Exception
                    '//This will catch if the po defined is not numeric
                    MsgBox("The PO value is invalid. Can not continue.", MsgBoxStyle.OKOnly, "ERROR")
                    Me.Enabled = True
                    Exit Sub
                End Try
            End If
            '//If a PO is defined then get the appropriate information


            '//This will get the records from warehouse receive to verify data
            Dim dtCheck As DataTable
            Dim dsCheck As PSS.Data.Production.Joins
            Dim mSQL As String
            'mSQL = "SELECT WHP_BinLocation as BinLocation, WHR_Box_SN as PieceIdentifier, WHP_PartNumber as PartNumber, WHR_WIPOwner FROM " & _
            '            "twarehousepallet inner join twarehousereceive on twarehousepallet.WHPallet_ID = twarehousereceive.whpallet_id " & _
            '            "inner join twarehousepalletload on " & _
            '            "(twarehousepallet.WHPallet_ID = twarehousepalletload.WHPallet_ID " & _
            '            "AND twarehousereceive.WHR_Box_SN = twarehousepalletload.WHP_PieceIdentifier) " & _
            '            "WHERE twarehousepallet.WHPallet_Number = '" & UCase(Trim(txtRMA.Text)) & "' " & _
            '            "AND twarehousereceive.WHR_Result = 0"
            '//October 18, 2006

            'Added by Lan 01/31/2006 11:02 AM. Lan added cust_id and model_id in select clause that will use to validate user input
            mSQL = "SELECT WHP_BinLocation as BinLocation, WHR_Dev_SN as PieceIdentifier, WHP_PartNumber as PartNumber, WHR_WIPOwner, cust_id, model_id FROM " & _
                        "twarehousepallet inner join twarehousereceive on twarehousepallet.WHPallet_ID = twarehousereceive.whpallet_id " & _
                        "inner join twarehousepalletload on " & _
                        "twarehousepallet.WHPallet_ID = twarehousepalletload.WHPallet_ID " & _
                        "AND twarehousepalletload.whp_PieceIdentifier = twarehousereceive.whr_dev_sn " & _
                        "WHERE twarehousepallet.WHPallet_Number = '" & UCase(Trim(txtRMA.Text)) & "' " & _
                        "AND twarehousereceive.WHR_Result = 0 " & _
                        "and twarehousepallet.WHPalletClosed = 1"       'Added by Lan 12/21/2006 10:44 AM 



            dtCheck = dsCheck.OrderEntrySelect(mSQL)

            '***********************************************************
            ' Added by Yuri 21-Jun-2007
            ' Check ProdGrp_ID for NULL value.
            If dtCheck.Rows.Count > 0 Then
                If Not IsDBNull(dtCheck.Rows(0)("model_id")) Then
                    iModelID = CInt(dtCheck.Rows(0)("model_id"))

                    If Not ProdGrpCheck.CheckProdGrpID(iModelID) Then
                        Exit Sub
                    End If
                End If
            End If
            '***********************************************************

            'Added by Lan 12/21/2006 10:44 AM 
            If dtCheck.Rows.Count = 0 Then
                MsgBox("Pallet is either not closed or does not exist.")
                Me.Enabled = True
                Exit Sub
            End If

            ''Added by Lan on 01/31/2006 11:02 AM. Validate Customer
            If Not IsDBNull(dtCheck.Rows(0)("cust_id")) Then
                If dtCheck.Rows(0)("cust_id") <> Me.cboCustomer.SelectedValue Then
                    MessageBox.Show("This pallet was dock received with a different customer than you have selected. Please check it again. ", "Validate Customer", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.Enabled = True
                    Exit Sub
                End If
            End If

            ''Added by Lan on 01/31/2006 11:02 AM. Validate Model
            If Not IsDBNull(dtCheck.Rows(0)("model_id")) Then
                If dtCheck.Rows(0)("model_id") <> Me.cboModel.SelectedValue Then
                    MessageBox.Show("This pallet was dock received with a different model than you have selected. Please check it again. ", "Validate Customer", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.Enabled = True
                    Exit Sub
                End If
            End If

            '//Get WIP_Owner from first record
            Dim rOwner As DataRow = dtCheck.Rows(0)
            wipOwner = rOwner("WHR_WIPOwner")
            If wipOwner = 5 Then wipOwnerParent = 2
            If wipOwner = 11 Then wipOwnerParent = 3
            If wipOwner = 14 Then wipOwnerParent = 14
            '//Get WIP_Owner from first record

            '//September 29, 2006
            If wipOwner = 0 Then
                MsgBox("The WIP Owner assignment can not be determined. This file can not be inserted.")
                Me.Enabled = True
                Exit Sub
            End If
            '//September 29, 2006

            '//This will get the records from warehouse receive to verify data

            Dim sConnectionstring As String
            Dim objConn As New OleDbConnection()
            Dim objCmdSelect As New OleDbCommand()
            Dim objAdapter1 As New OleDbDataAdapter()
            Dim dt As New DataTable()
            Dim objDataset1 As New DataSet()
            Dim xCount As Integer = 0
            Dim r As DataRow
            Dim vResponse As String

            Dim strFile As String

            '//Assigned location of file
            'strFile = Dir("R:\ATCLE\ATCLE_DataFiles\" & Trim(txtRMA.Text) & ".xls")

            'Do Until Len(strFile) < 1

            '//Create a datatable of all values from the assigned file
            '//Modified October 4, 2006
            'sConnectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=R:\ATCLE\ATCLE_DataFiles\" & strFile & ";Extended Properties=Excel 8.0;"
            'objConn.ConnectionString = sConnectionstring
            'objConn.Open()
            'objCmdSelect.CommandText = ("SELECT * FROM [McHugh Export$]") '
            'objCmdSelect.Connection = objConn
            'objAdapter1.SelectCommand = objCmdSelect
            'objAdapter1.Fill(dt)
            'objAdapter1.Fill(objDataset1, "XLData")

            Dim dtemp As DataTable = PSS.Data.Production.Joins.OrderEntrySelect("SELECT WHPallet_ID FROM twarehousepallet WHERE twarehousepallet.whPallet_Number = '" & txtRMA.Text & "'")
            Dim rTemp As DataRow = dtemp.Rows(0)

            strSQL = "select whp_binlocation , whp_loadnumber , " & _
            "whp_PartNumber, whp_PieceIdentifier, " & _
            "twarehousereceive.whr_devcondition as mBillCode from " & _
            "twarehousepalletload INNER JOIN twarehousereceive on twarehousepalletload.whpallet_id = twarehousereceive.whpallet_id " & _
            "AND twarehousepalletload.whp_PieceIdentifier = twarehousereceive.whr_dev_sn " & _
            "WHERE twarehousepalletload.whPallet_ID = " & rTemp("Whpallet_ID")

            dt = PSS.Data.Production.Joins.OrderEntrySelect(strSQL)
            '//Modified October 4, 2006

            '//Get a listing off all skus for this workorder load
            '//SKU size (LONG AND SHORT) matter
            Dim dtSKUS As New DataTable()
            'objCmdSelect.CommandText = ("SELECT [Part Number], COUNT([Part Number]) as dcount FROM [McHugh Export$] GROUP BY [Part Number]")
            'objCmdSelect.Connection = objConn
            'objAdapter1.SelectCommand = objCmdSelect
            'objAdapter1.Fill(dtSKUS)

            '//New October 4, 2006
            dtSKUS = PSS.Data.Production.Joins.OrderEntrySelect("SELECT WHP_PartNumber, COUNT(WHP_PartNumber) as dcount FROM twarehousepallet INNER JOIN twarehousepalletload ON twarehousepallet.WHPallet_ID = twarehousepalletload.WHPallet_ID WHERE twarehousepallet.WHPallet_Number = '" & txtRMA.Text & "' GROUP BY WHP_PartNumber")
            '//New October 4, 2006

            Dim mSku As String
            Dim x As Integer

            '//Get the range sizes from the database - tskudescription
            Dim ds As PSS.Data.Production.Joins
            Dim dtshort As DataTable = ds.OrderEntrySelect("SELECT * FROM tskudescription WHERE SKUDESC_ID = 1")
            r = dtshort.Rows(0)
            shortLOW = r("skuDESC_Length_LOW")
            shortHIGH = r("skuDESC_Length_HIGH")
            System.Windows.Forms.Application.DoEvents()
            dtshort = Nothing
            Dim dtlong As DataTable = ds.OrderEntrySelect("SELECT * FROM tskudescription WHERE SKUDESC_ID = 2")
            r = dtlong.Rows(0)
            longLOW = r("skuDESC_Length_LOW")
            longHIGH = r("skuDESC_Length_HIGH")
            System.Windows.Forms.Application.DoEvents()
            dtlong = Nothing
            '//Get the range sizes from the database - tskudescription

            Dim blnWOSHORT, blnWOLONG As Boolean
            blnWOSHORT = False
            blnWOLONG = False


            If mCustomer = 2219 Then '//Upper section useed for Gamestop
                blnWOSHORT = True
                blnWOLONG = False
            Else
                Try
                    For x = 0 To dtSKUS.Rows.Count - 1
                        r = dtSKUS.Rows(x)
                        If Len(Trim(r("WHP_PartNumber"))) >= longLOW And Len(Trim(r("WHP_PartNumber"))) <= longHIGH Then
                            blnWOLONG = True
                        ElseIf Len(Trim(r("WHP_PartNumber"))) >= shortLOW And Len(Trim(r("WHP_PartNumber"))) <= shortHIGH Then
                            blnWOSHORT = True
                        End If
                    Next
                Catch ex As Exception
                    'MsgBox(ex.ToString)
                    MsgBox("Can not load this file - empty rows.", MsgBoxStyle.OKOnly, "ERROR")
                    Me.Enabled = True
                    Exit Sub
                End Try
            End If

            Dim WOname As String

            '********************************************
            'added by Lan on 02/19/2007 
            'check if wo exist
            '********************************************
            Dim objMisc As New PSS.Data.Production.Misc()
            Dim dt1 As DataTable
            Dim i As Integer = 0
            '********************************************

            If mCustomer = 2219 Then
                '//Verify that workorders are available for processing
                If blnWOSHORT = True Then
                    WOname = Trim(txtRMA.Text)
                    mWO = 0
                    Try
                        Dim dtWO As DataTable = PSS.Data.Production.tworkorder.GetCustWObyName(WOname)
                        Dim rWO As DataRow = dtWO.Rows(0)
                        mWO = rWO("WO_ID")
                    Catch ex As Exception
                    End Try
                    If mWO > 0 Then
                        ''MsgBox("This Workorder is already being used.", MsgBoxStyle.OKOnly, "ERROR")
                        ''Exit Sub

                        '********************************************
                        'added by Lan on 02/19/2007 
                        'check if wo exist
                        '********************************************
                        Try
                            objMisc._SQL = "select count(*) as cnt from tdevice where wo_id = " & mWO & ";"
                            dt1 = objMisc.GetDataTable
                            If dt1.Rows(0)("cnt") > 0 Then
                                MsgBox("This Workorder is already being used with " & dt1.Rows(0)("cnt") & " devices.", MsgBoxStyle.OKOnly, "ERROR")
                                Me.Enabled = True
                                Exit Sub
                            Else
                                'objMisc._SQL = "delete from tworkorder where wo_id = " & mWO & ";"
                                'i = objMisc.ExecuteNonQuery
                                Me.RenameWO(mWO, WOname)
                                mWO = 0
                            End If

                        Catch ex As Exception
                            MessageBox.Show("Check WO ERR::: " & ex.tostring, "Check Work Order", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            Me.Enabled = True
                            Exit Sub
                        Finally
                            If Not IsNothing(dt1) Then
                                dt1.Dispose()
                                dt1 = Nothing
                            End If
                        End Try
                        '********************************************

                    End If
                End If
                If blnWOLONG = True Then
                    WOname = Trim(txtRMA.Text)
                    mWO = 0
                    Try
                        Dim dtWO As DataTable = PSS.Data.Production.tworkorder.GetCustWObyName(WOname)
                        Dim rWO As DataRow = dtWO.Rows(0)
                        mWO = rWO("WO_ID")
                    Catch ex As Exception
                    End Try
                    If mWO > 0 Then
                        ''MsgBox("This Workorder is already being used.", MsgBoxStyle.OKOnly, "ERROR")
                        ''Exit Sub

                        '********************************************
                        'added by Lan on 02/19/2007 
                        'check if wo exist
                        '********************************************
                        Try
                            objMisc._SQL = "select count(*) as cnt from tdevice where wo_id = " & mWO & ";"
                            dt1 = objMisc.GetDataTable
                            If dt1.Rows(0)("cnt") > 0 Then
                                MsgBox("This Workorder is already being used with " & dt1.Rows(0)("cnt") & " devices.", MsgBoxStyle.OKOnly, "ERROR")
                                Me.Enabled = True
                                Exit Sub
                            Else
                                'objMisc._SQL = "delete from tworkorder where wo_id = " & mWO & ";"
                                'i = objMisc.ExecuteNonQuery
                                Me.RenameWO(mWO, WOname)
                                mWO = 0
                            End If

                        Catch ex As Exception
                            MessageBox.Show("Check WO ERR::: " & ex.tostring, "Check Work Order", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            Me.Enabled = True
                            Exit Sub
                        Finally
                            If Not IsNothing(dt1) Then
                                dt1.Dispose()
                                dt1 = Nothing
                            End If
                        End Try
                        '********************************************

                    End If
                End If
            Else
                '//Verify that workorders are available for processing
                If blnWOSHORT = True Then
                    WOname = Trim(txtRMA.Text) & "{S}"
                    mWO = 0
                    Try
                        Dim dtWO As DataTable = PSS.Data.Production.tworkorder.GetCustWObyName(WOname)
                        Dim rWO As DataRow = dtWO.Rows(0)
                        mWO = rWO("WO_ID")
                    Catch ex As Exception
                    End Try
                    If mWO > 0 Then
                        ''MsgBox("This Short Workorder is already being used.", MsgBoxStyle.OKOnly, "ERROR")
                        ''Exit Sub

                        '********************************************
                        'added by Lan on 02/19/2007 
                        'check if wo exist
                        '********************************************
                        Try
                            objMisc._SQL = "select count(*) as cnt from tdevice where wo_id = " & mWO & ";"
                            dt1 = objMisc.GetDataTable
                            If dt1.Rows(0)("cnt") > 0 Then
                                MsgBox("This Workorder is already being used with " & dt1.Rows(0)("cnt") & " devices.", MsgBoxStyle.OKOnly, "ERROR")
                                Me.Enabled = True
                                Exit Sub
                            Else
                                'objMisc._SQL = "delete from tworkorder where wo_id = " & mWO & ";"
                                'i = objMisc.ExecuteNonQuery
                                Me.RenameWO(mWO, WOname)
                                mWO = 0
                            End If

                        Catch ex As Exception
                            MessageBox.Show("Check WO ERR::: " & ex.tostring, "Check Work Order", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            Me.Enabled = True
                            Exit Sub
                        Finally
                            If Not IsNothing(dt1) Then
                                dt1.Dispose()
                                dt1 = Nothing
                            End If
                        End Try
                        '********************************************

                    End If
                End If
                If blnWOLONG = True Then
                    WOname = Trim(txtRMA.Text) & "{L}"
                    mWO = 0
                    Try
                        Dim dtWO As DataTable = PSS.Data.Production.tworkorder.GetCustWObyName(WOname)
                        Dim rWO As DataRow = dtWO.Rows(0)
                        mWO = rWO("WO_ID")
                    Catch ex As Exception
                    End Try
                    If mWO > 0 Then
                        ''MsgBox("This Long Workorder is already being used.", MsgBoxStyle.OKOnly, "ERROR")
                        ''Exit Sub

                        '********************************************
                        'added by Lan on 02/19/2007 
                        'check if wo exist
                        '********************************************
                        Try
                            objMisc._SQL = "select count(*) as cnt from tdevice where wo_id = " & mWO & ";"
                            dt1 = objMisc.GetDataTable
                            If dt1.Rows(0)("cnt") > 0 Then
                                MsgBox("This Workorder is already being used with " & dt1.Rows(0)("cnt") & " devices.", MsgBoxStyle.OKOnly, "ERROR")
                                Me.Enabled = True
                                Exit Sub
                            Else
                                'objMisc._SQL = "delete from tworkorder where wo_id = " & mWO & ";"
                                'i = objMisc.ExecuteNonQuery
                                Me.RenameWO(mWO, WOname)
                                mWO = 0
                            End If

                        Catch ex As Exception
                            MessageBox.Show("Check WO ERR::: " & ex.tostring, "Check Work Order", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            Me.Enabled = True
                            Exit Sub
                        Finally
                            If Not IsNothing(dt1) Then
                                dt1.Dispose()
                                dt1 = Nothing
                            End If
                        End Try
                        '********************************************

                    End If
                End If
            End If

            '********************************************
            'added by Lan on 02/19/2007 
            'destroy the object
            '********************************************
            objMisc = Nothing
            '********************************************



            '//verify that the detail records are not blank



            '//Removed October 4, 2006 - Data is verified through warehouse receive process
            'Dim dtBlankDevice As New DataTable()
            'Try
            'objCmdSelect.CommandText = ("SELECT * FROM [McHugh Export$] WHERE [Piece Identifier] = """)
            'objCmdSelect.Connection = objConn
            'objAdapter1.SelectCommand = objCmdSelect
            'objAdapter1.Fill(dtBlankDevice)

            'If dtBlankDevice.Rows.Count > 0 Then
            'MsgBox("Empty rows are present. can not continue.", MsgBoxStyle.Exclamation, "ERROR")
            'Exit Sub
            'End If
            'Catch ex As Exception
            'End Try
            'dtBlankDevice = Nothing
            '//Removed October 4, 2006 - Data is verified through warehouse receive process


            If mCustomer = 2219 Then
                WOname = Trim(txtRMA.Text)
                Dim mWO1 As Integer = 0
                mCount = Me.fileWareHouseReceive(WOname, mWO1, dt, _lTrayID, mModel, mCustomer, shortLOW, shortHIGH, dtCheck)

                '***************************
                'added by Lan on 02/21/2007 
                '***************************
                If mCount = 0 Then 'WO_ID exist
                    Me.Enabled = True
                    Exit Sub
                End If
                '***************************

                If mWO > 0 Then
                    Dim updDs As PSS.Data.Production.Joins
                    Dim updSQL = "UPDATE tworkorder SET wo_quantity = " & mCount & ", wo_raqnty = " & mCount & " WHERE wo_id = " & mWO
                    Dim blnUpdate As Boolean = updDs.OrderEntryUpdateDelete(updSQL)
                End If

                vResponse = MsgBox("Do you want to load these " & mCount & " entries?", MsgBoxStyle.OKCancel, "To Continue")
                Select Case vResponse
                    Case vbOK
                        runPrint()
                    Case vbCancel
                        mCount = 0
                        MsgBox("nothing will be processed into the system.", MsgBoxStyle.OKOnly)

                        '//May 23, 2006
                        '//rename the workorder so that it can be reloaded
                        If mWO > 0 Then
                            Dim dsRen As PSS.Data.Production.Joins
                            Dim vCount As Long = 0
                            Dim dtCount As DataTable = dsRen.OrderEntrySelect("SELECT * FROM tworkorder WHERE wo_custwo like '" & WOname & "%'")
                            vCount = dtCount.Rows.Count
                            Dim renSQL = "UPDATE tworkorder SET wo_custwo = '" & WOname & "_DNU" & vCount & "', wo_shipped = 1 WHERE wo_id = " & mWO
                            If mWO > 0 Then
                                Dim blnUpdate As Boolean = dsRen.OrderEntryUpdateDelete(renSQL)
                            End If
                            System.Windows.Forms.Application.DoEvents()
                            'mWO = 0
                            dataGrid.Clear()
                        End If
                        '//rename the workorder so that it can be reloaded
                        '//May 23, 2006
                        'Exit Sub
                End Select
            Else

                If blnWOSHORT = True Then
                    WOname = Trim(txtRMA.Text) & "{S}"
                    'mWO = 0
                    Dim mWO1 As Integer = 0
                    mCount = Me.fileWareHouseReceive(WOname, mWO1, dt, _lTrayID, mModel, mCustomer, shortLOW, shortHIGH, dtCheck)

                    '***************************
                    'added by Lan on 02/21/2007 
                    '***************************
                    If mCount = 0 Then 'WO_ID exist
                        Me.Enabled = True
                        Exit Sub
                    End If
                    '***************************

                    If mWO > 0 Then
                        Dim updDs As PSS.Data.Production.Joins
                        Dim updSQL = "UPDATE tworkorder SET wo_quantity = " & mCount & ", wo_raqnty = " & mCount & " WHERE wo_id = " & mWO
                        Dim blnUpdate As Boolean = updDs.OrderEntryUpdateDelete(updSQL)
                    End If

                    vResponse = MsgBox("Do you want to load these " & mCount & " entries?", MsgBoxStyle.OKCancel, "To Continue")
                    Select Case vResponse
                        Case vbOK
                            runPrint()
                        Case vbCancel
                            mCount = 0
                            MsgBox("nothing will be processed into the system.", MsgBoxStyle.OKOnly)

                            '//May 23, 2006
                            '//rename the workorder so that it can be reloaded
                            If mWO > 0 Then
                                Dim dsRen As PSS.Data.Production.Joins
                                Dim vCount As Long = 0
                                Dim dtCount As DataTable = dsRen.OrderEntrySelect("SELECT * FROM tworkorder WHERE wo_custwo like '" & WOname & "%'")
                                vCount = dtCount.Rows.Count
                                Dim renSQL = "UPDATE tworkorder SET wo_custwo = '" & WOname & "_DNU" & vCount & "', wo_shipped = 1 WHERE wo_id = " & mWO
                                If mWO > 0 Then
                                    Dim blnUpdate As Boolean = dsRen.OrderEntryUpdateDelete(renSQL)
                                End If
                                System.Windows.Forms.Application.DoEvents()
                                'mWO = 0
                                dataGrid.Clear()
                            End If
                            '//rename the workorder so that it can be reloaded
                            '//May 23, 2006
                            'Exit Sub
                    End Select
                End If




                System.Windows.Forms.Application.DoEvents()

                If blnWOLONG = True Then
                    WOname = Trim(txtRMA.Text) & "{L}"
                    'mWO = 0
                    Dim mWO1 As Integer = 0
                    mCount = Me.fileWareHouseReceive(WOname, mWO1, dt, _lTrayID, mModel, mCustomer, longLOW, longHIGH, dtCheck)

                    '***************************
                    'added by Lan on 02/21/2007 
                    '***************************
                    If mCount = 0 Then 'WO_ID exist
                        Me.Enabled = True
                        Exit Sub
                    End If
                    '***************************

                    If mWO > 0 Then
                        Dim updDs As PSS.Data.Production.Joins
                        Dim updSQL = "UPDATE tworkorder SET wo_quantity = " & mCount & ", wo_raqnty = " & mCount & " WHERE wo_id = " & mWO
                        Dim blnUpdate As Boolean = updDs.OrderEntryUpdateDelete(updSQL)
                    End If

                    vResponse = MsgBox("Do you want to load these " & mCount & " entries?", MsgBoxStyle.OKCancel, "To Continue")
                    Select Case vResponse
                        Case vbOK
                            runPrint()
                        Case vbCancel
                            MsgBox("nothing will be processed into the system.", MsgBoxStyle.OKOnly)
                            mCount = 0
                            '//May 23, 2006
                            '//rename the workorder so that it can be reloaded
                            If mWO > 0 Then
                                Dim dsRen As PSS.Data.Production.Joins
                                Dim vCount As Long = 0
                                Dim dtCount As DataTable = dsRen.OrderEntrySelect("SELECT * FROM tworkorder WHERE wo_custwo like '" & WOname & "%'")
                                vCount = dtCount.Rows.Count
                                Dim renSQL = "UPDATE tworkorder SET wo_custwo = '" & WOname & "_DNU" & vCount & "', wo_shipped = 1 WHERE wo_id = " & mWO
                                If mWO > 0 Then
                                    Dim blnUpdate As Boolean = dsRen.OrderEntryUpdateDelete(renSQL)
                                End If
                                System.Windows.Forms.Application.DoEvents()
                                'mWO = 0
                                dataGrid.Clear()
                            End If
                            '//rename the workorder so that it can be reloaded
                            '//May 23, 2006
                            'Exit Sub
                    End Select
                End If

            End If



            Me.updWHPPalletRcvd()
            System.Windows.Forms.Application.DoEvents()
            Me.updCellOptOwner(mWO, WOname)
            System.Windows.Forms.Application.DoEvents()
            MsgBox("Complete", MsgBoxStyle.OKOnly)


            mWO = 0

            Me.Enabled = True
            Exit Sub
            '//AFter this is the old code
            '//AFter this is the old code
            '//AFter this is the old code
            '//AFter this is the old code
            '//AFter this is the old code
            '//AFter this is the old code
            '//AFter this is the old code
            '//AFter this is the old code
            '//AFter this is the old code
            '//AFter this is the old code

            txtRMA.Text = UCase(txtRMA.Text)
            System.Windows.Forms.Application.DoEvents()

            mCustomer = cboCustomer.SelectedValue

            If mCustomer = 2058 Then
                mLocation = 2579
            ElseIf mCustomer = 2019 Then
                mLocation = 2540
            End If

            If Len(Trim(cboReceive.Text)) < 1 Then
                MsgBox("Please choose a receive type", MsgBoxStyle.OKOnly)
                Me.Enabled = True
                Exit Sub
            End If

            Try
                txtRMA.Text = UCase(txtRMA.Text)
            Catch ex As Exception
            End Try

            'Dim blnCheck1 As Boolean = False

            Try
                '//Verify data has been selected before continuing
                If Len(Trim(cboCustomer.Text)) > 0 And mCustomer > 0 Then
                    If Len(Trim(cboManufacturer.Text)) > 0 And mManufacturer > 0 Then
                        If Len(Trim(cboModel.Text)) > 0 And mModel > 0 Then
                            If Len(Trim(txtRMA.Text)) > 0 Then
                                'If CInt(txtQuantity.Text) > 0 Then
                                blnCheck1 = True
                                'End If
                            End If
                        End If
                    End If
                End If


            Catch ex As Exception
            End Try

            'If Len(Trim(cboGroup.Text)) < 1 Then
            'blnCheck1 = False
            'End If

            'Dim vPO As Integer
            If Len(Trim(txtPO.Text)) > 0 Then
                Try
                    vPO = CInt(txtPO.Text)

                    Dim dsPO As PSS.Data.Production.Joins
                    Dim dtPO As DataTable = dsPO.OrderEntrySelect("SELECT * FROM tpurchaseorder WHERE PO_ID = " & vPO)

                    If dtPO.Rows.Count < 1 Then
                        MsgBox("The PO value is invalid. Can not continue.", MsgBoxStyle.OKOnly, "ERROR")
                        Me.Enabled = True
                        Exit Sub
                    End If

                Catch ex As Exception
                    MsgBox("The PO value is invalid. Can not continue.", MsgBoxStyle.OKOnly, "ERROR")
                    Me.Enabled = True
                    Exit Sub
                End Try
            End If

            If blnCheck1 = False Then
                MsgBox("File Receiving can not activate - not all data is supplied or the ID values are  corrupt")
                cboManufacturer.Focus()
                Me.Enabled = True
                Exit Sub
            End If

            Try
                Dim dtWO As DataTable = PSS.Data.Production.tworkorder.GetCustWObyName(Trim(txtRMA.Text))
                Dim rWO As DataRow = dtWO.Rows(0)
                mWO = rWO("WO_ID")
            Catch ex As Exception
            End Try

            If mWO > 0 Then
                MsgBox("This Workorder is already being used.", MsgBoxStyle.OKOnly, "ERROR")
                Me.Enabled = True
                Exit Sub
            Else
                mWO = InsertWorkOrder(txtRMA.Text)
            End If


            If _lTrayID = 0 Then
                _lTrayID = InsertTray(mWO)
            End If



            '            Dim sConnectionstring As String
            '            Dim objConn As New OleDbConnection()
            '            Dim objCmdSelect As New OleDbCommand()
            '            Dim objAdapter1 As New OleDbDataAdapter()
            'Dim dt As New DataTable()
            'Dim objDataset1 As New DataSet()
            'Dim xCount As Integer = 0
            'Dim r As DataRow
            'Dim vResponse As String

            '            Dim strFile As String

            '            strFile = Dir("R:\ATCLE\ATCLE_DataFiles\" & Trim(txtRMA.Text) & ".xls")

            '            Do Until Len(strFile) < 1


            '               sConnectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=R:\ATCLE\ATCLE_DataFiles\" & strFile & ";Extended Properties=Excel 8.0;"
            '               objConn.ConnectionString = sConnectionstring
            '               objConn.Open()

            '               objCmdSelect.CommandText = ("SELECT * FROM [McHugh Export$]") '
            '               objCmdSelect.Connection = objConn
            '               objAdapter1.SelectCommand = objCmdSelect

            '               objAdapter1.Fill(dt)

            '                objAdapter1.Fill(objDataset1, "XLData")

            'Dim vNumber As Integer = CInt(txtQuantity.Text) - 1
            Dim vNumber As Integer = 0


            'Dim ds As PSS.Data.Production.Joins
            Dim ckSQL As String
            ckSQL = "SELECT WHP_BinLocation as BinLocation, WHR_Box_SN as PieceIdentifier, WHP_PartNumber as PartNumber FROM " & _
                        "twarehousepallet inner join twarehousereceive on twarehousepallet.WHPallet_ID = twarehousereceive.whpallet_id " & _
                        "inner join twarehousepalletload on " & _
                        "(twarehousepallet.WHPallet_ID = twarehousepalletload.WHPallet_ID " & _
                        "AND twarehousereceive.WHR_Box_SN = twarehousepalletload.WHP_PieceIdentifier) " & _
                        "WHERE twarehousepallet.WHPallet_Number = '" & UCase(Trim(txtRMA.Text)) & "' " & _
                        "AND twarehousereceive.WHR_Result = 0"

            dt = ds.OrderEntrySelect(ckSQL)


            For xCount = 0 To dt.Rows.Count - 1
                '    For xCount = 0 To vNumber
                r = dt.Rows(xCount)

                If Trim(r("BinLocation")) = Trim(txtRMA.Text) Then

                    '//Craig D Haney - change this code to run for every line
                    'If mSKU = 0 Then mSKU = SKUmake(r("Part Number"), mModel, mCustomer)
                    mSku = SKUmake(r("PartNumber"), mModel, mCustomer)
                    '//Craig D Haney - change this code to run for every line

                    '//Add record to grid
                    mSerialNumber = r("PieceIdentifier")
                    mSerialID = InsertDevice()
                    mCount += 1
                End If
            Next

            'objConn.Close()

            'If mCount > 0 Then Exit Do

            'strFile = Dir()

            '           Loop


            '//February 15, 2006
            '//Trigger to load regardless of numbers


            'If mCount = CInt(txtQuantity.Text) Then

            If mWO > 0 Then
                Dim updDs As PSS.Data.Production.Joins
                Dim updSQL = "UPDATE tworkorder SET wo_quantity = " & mCount & ", wo_raqnty = " & mCount & " WHERE wo_id = " & mWO
                Dim blnUpdate As Boolean = updDs.OrderEntryUpdateDelete(updSQL)
            End If

            vResponse = MsgBox("Do you want to load these " & mCount & " entries?", MsgBoxStyle.OKCancel, "To COntinue")
            Select Case vResponse
                Case vbOK
                    runPrint()
                Case vbCancel
                    MsgBox("nothing will be processed into the system.", MsgBoxStyle.OKOnly)
                    Me.Enabled = True
                    Exit Sub
            End Select


            'Else
            'End If

            Me.Enabled = True
        End Sub

        '****************************************************
        'added by Lan on 03/09/07
        '****************************************************
        Private Function RenameWO(ByVal iwo_id As Integer, _
                                   ByVal strWo_name As String) As Integer
            Dim objMisc As New PSS.Data.Production.Misc()
            Dim iCount As Long = 0
            Dim strSql As String
            Dim dt1 As DataTable
            Dim i As Integer = 0

            Try
                If mWO > 0 Then
                    strSql = "SELECT * FROM tworkorder WHERE wo_custwo like '" & strWo_name & "%';"
                    objMisc._SQL = strSql
                    dt1 = objMisc.GetDataTable
                    iCount = dt1.Rows.Count

                    If iwo_id > 0 Then
                        strSql = "UPDATE tworkorder SET wo_custwo = '" & strWo_name & "_DNU" & iCount & "', wo_shipped = 1 WHERE wo_id = " & iwo_id & ";"
                        objMisc._SQL = strSql
                        i = objMisc.ExecuteNonQuery
                    End If
                    System.Windows.Forms.Application.DoEvents()

                End If
            Catch ex As Exception
                Throw ex
            Finally
                objMisc = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function


        Private Function SKUmake(ByVal SKUnumber As String, ByVal vModel As Int32, ByVal vCust As Int32) As Int32

            Dim tVsku As New PSS.Data.Production.tsku()
            Dim verSKU As Boolean = tVsku.GetRowBySKU(UCase(Trim(SKUnumber)))
            Try
                If verSKU = False Then
                    'Insert record
                    Dim strSQL As String = "INSERT INTO tsku (Sku_Number, Model_ID, Cust_ID) VALUES ('" & UCase(Trim(SKUnumber)) & "', " & vModel & "," & vCust & ")"
                    SKUmake = tVsku.idTransaction(strSQL)
                Else

                    Dim vSku As DataRow = tVsku.GetValSKU(SKUnumber)
                    SKUmake = vSku("Sku_ID")
                End If
            Catch EX As Exception
            End Try

        End Function





















        Private Function CreateGridDT() As DataTable

            Dim dtGrid As New DataTable("dtGridMain")

            dtGrid.MinimumCapacity = 500
            dtGrid.CaseSensitive = False

            Dim dcDeviceID As New DataColumn("CountID")
            dtGrid.Columns.Add(dcDeviceID)
            Dim dcDeviceSN As New DataColumn("DeviceSN")
            dtGrid.Columns.Add(dcDeviceSN)
            Dim dcDeviceOLDsn As New DataColumn("DeviceOLDsn")
            dtGrid.Columns.Add(dcDeviceOLDsn)
            Dim dcDeviceModelType As New DataColumn("DeviceModelType")
            dtGrid.Columns.Add(dcDeviceModelType)
            Dim dcDeviceDateEntered As New DataColumn("DeviceDateEntered")
            dtGrid.Columns.Add(dcDeviceDateEntered)
            Dim dcDeviceDateBilled As New DataColumn("DeviceDateBilled")
            dtGrid.Columns.Add(dcDeviceDateBilled)
            Dim dcDeviceDateShipped As New DataColumn("DeviceDateShipped")
            dtGrid.Columns.Add(dcDeviceDateShipped)
            Dim dcDeviceManufWrty As New DataColumn("DeviceManufWrty")
            dtGrid.Columns.Add(dcDeviceManufWrty)
            Dim dcDeviceOEMWrty As New DataColumn("DeviceOEMWrty")
            dtGrid.Columns.Add(dcDeviceOEMWrty)
            Dim dcDevicePSSwrty As New DataColumn("DevicePSSwrty")
            dtGrid.Columns.Add(dcDevicePSSwrty)
            Dim dcDeviceCAPcode As New DataColumn("DeviceCAPcode")
            dtGrid.Columns.Add(dcDeviceCAPcode)
            Dim dcDeviceBAUD As New DataColumn("DeviceBAUD")
            dtGrid.Columns.Add(dcDeviceBAUD)
            Dim dcDeviceFrequency As New DataColumn("DeviceFrequency")
            dtGrid.Columns.Add(dcDeviceFrequency)
            Dim dcDeviceFOlot As New DataColumn("DeviceFOlot")
            dtGrid.Columns.Add(dcDeviceFOlot)
            Dim dcDeviceTrayID As New DataColumn("DeviceTrayID")
            dtGrid.Columns.Add(dcDeviceTrayID)
            Dim dcDeviceWOID As New DataColumn("DeviceWOID")
            dtGrid.Columns.Add(dcDeviceWOID)
            Dim dcDeviceModelID As New DataColumn("DeviceModelID")
            dtGrid.Columns.Add(dcDeviceModelID)
            Dim dcLocID As New DataColumn("DeviceLocationID")
            dtGrid.Columns.Add(dcLocID)
            Dim dcDBR As New DataColumn("DeviceDBR")
            dtGrid.Columns.Add(dcDBR)
            Dim dcLaborLevel As New DataColumn("DeviceLaborLevel")
            dtGrid.Columns.Add(dcLaborLevel)
            Dim dcLaborCharge As New DataColumn("DeviceLaborCharge")
            dtGrid.Columns.Add(dcLaborCharge)
            Dim dcReconcileID As New DataColumn("ReconcileID")
            dtGrid.Columns.Add(dcReconcileID)
            Dim dcSKU As New DataColumn("SKU")
            dtGrid.Columns.Add(dcSKU)
            Dim dcBillCode As New DataColumn("BillCode")
            dtGrid.Columns.Add(dcBillCode)

            '        If DeviceType = "2" Then
            Dim dcCSN As New DataColumn("CSNnumber")
            dtGrid.Columns.Add(dcCSN)
            Dim dcCourTrackIN As New DataColumn("CourTrackIN")
            dtGrid.Columns.Add(dcCourTrackIN)
            Dim dcAirTimeCarrierCode As New DataColumn("AirTimeCarrierCode")
            dtGrid.Columns.Add(dcAirTimeCarrierCode)
            Dim dcTransactionCode As New DataColumn("TransactionCode")
            dtGrid.Columns.Add(dcTransactionCode)
            Dim dcAPCcode As New DataColumn("APCcode")
            dtGrid.Columns.Add(dcAPCcode)
            Dim dcTransceiverCode As New DataColumn("TransceiverCode")
            dtGrid.Columns.Add(dcTransceiverCode)
            Dim dcIncomingIMEI As New DataColumn("IncomingIMEI")
            dtGrid.Columns.Add(dcIncomingIMEI)
            Dim dcWrtyClaimNumber As New DataColumn("WrtyClaimNumber")
            dtGrid.Columns.Add(dcWrtyClaimNumber)

            Dim dcOEMwrty As New DataColumn("DeviceOEMwrty")
            dtGrid.Columns.Add(dcOEMwrty)
            Dim dcDateCode As New DataColumn("DeviceDateCode")
            dtGrid.Columns.Add(dcDateCode)
            Dim dcCustFName As New DataColumn("DeviceCustFName")
            dtGrid.Columns.Add(dcCustFName)
            Dim dcCustLName As New DataColumn("DeviceCustLName")
            dtGrid.Columns.Add(dcCustLName)
            Dim dcModelNum As New DataColumn("DeviceModelNum")
            dtGrid.Columns.Add(dcModelNum)
            Dim dcPOPdate As New DataColumn("DevicePOPdate")
            dtGrid.Columns.Add(dcPOPdate)
            Dim dcComplaint As New DataColumn("DeviceComplaint")
            dtGrid.Columns.Add(dcComplaint)
            Dim dcMIN As New DataColumn("DeviceMIN")
            dtGrid.Columns.Add(dcMIN)
            Dim dcCarrModelCode As New DataColumn("DeviceCarrModelCode")
            dtGrid.Columns.Add(dcCarrModelCode)
            Dim dcDecimal As New DataColumn("Decimal")
            dtGrid.Columns.Add(dcDecimal)
            Dim dcReturnCode As New DataColumn("ReturnCode")
            dtGrid.Columns.Add(dcReturnCode)

            Dim dcSoftVerIN As New DataColumn("SoftVerIN")
            dtGrid.Columns.Add(dcSoftVerIN)
            Dim dcSoftVerOUT As New DataColumn("SoftVerOUT")
            dtGrid.Columns.Add(dcSoftVerOUT)
            Dim dcAirtimeAmt As New DataColumn("AirtimeAmt")
            dtGrid.Columns.Add(dcAirtimeAmt)
            Dim dcSUG As New DataColumn("SUG")
            dtGrid.Columns.Add(dcSUG)

            'If cboManufID.Text = "Motorola" Then
            Dim dcMSN As New DataColumn("DeviceMSN")
            dtGrid.Columns.Add(dcMSN)
            'End If

            'If cboManufID.Text = "Nokia" Then
            Dim dcProdCode As New DataColumn("DeviceProdCode")
            dtGrid.Columns.Add(dcProdCode)
            'End If

            '        End If

            CreateGridDT = dtGrid

        End Function

        Private Function InsertDevice() As Int32


            Try
                InsertDevice = 0
                '//Insert device into grid
                Dim dr1 As DataRow = dataGrid.NewRow
                dr1("CountID") = mCount + 1
                dr1("DeviceSN") = mSerialNumber
                dr1("DeviceManufWrty") = 0
                dr1("DeviceOEMWrty") = 0
                dr1("DevicePSSWrty") = 0
                dr1("DeviceDateEntered") = PSS.Gui.Receiving.FormatDate(Now)
                dr1("DeviceTrayID") = _lTrayID
                dr1("DeviceWOID") = mWO
                dr1("DeviceModelID") = mModel

                dr1("DeviceLocationID") = mLocation
                dr1("DeviceDBR") = "0" '//Not required
                If Len(Trim(mSerialNumber)) < 12 Then dr1("CSNnumber") = mSerialNumber
                '//dr1("CourTrackIN") = UCase(Me.txtCourierTrackIN.Text)
                '//dr1("AirTimeCarrierCode") = mCarrier
                '//dr1("TransactionCode") = mTransaction
                '//dr1("APCcode") = mAPC
                '//dr1("TransceiverCode") = UCase(Me.txtTransceiver.Text)
                If Len(Trim(mSerialNumber)) > 11 Then dr1("IncomingIMEI") = mSerialNumber
                '//dr1("DeviceDateCode") = UCase(Me.cboDateCode.Text)
                '//dr1("DeviceCustFName") = lblCustomerVAL.Text
                '//dr1("DeviceCustLName") = "" '//Not required
                '//dr1("DeviceModelNum") = "0"
                '//If Len(Trim(txtPOP.Text)) > 0 Then
                '//dr1("DevicePOPdate") = txtPOP.Text
                '//End If
                '//dr1("DeviceComplaint") = mComplaint

                '//dr1("SoftVerIN") = mSoftVerIN
                '//dr1("SoftVerOUT") = mSoftVerOUT
                '//dr1("AirTimeAmt") = mAirtime
                '//dr1("SUG") = mSUG

                '//dr1("DeviceMIN") = UCase(Me.txtMIN.Text)
                '//dr1("DeviceCarrModelCode") = UCase(Me.txtCarrModelCode.Text)
                '//dr1("Decimal") = mDecimal
                If Len(Trim(mSerialNumber)) > 11 Then dr1("DeviceMSN") = UCase(mSerialNumber)
                'If mMSN > 0 Then
                'dr1("DeviceSN") = ""
                'End If
                '//rSku = PSS.Data.Production.tsku.GetValSKU(vSKU)
                '//mSKU = mSKU
                dr1("SKU") = mSKU
                '//dr1("DeviceProdCode") = UCase(Me.txtProduct.Text)
                '//If mReturn > 0 Then dr1("ReturnCode") = mReturn
                dr1("BillCode") = vBillCode

                dataGrid.Rows.Add(dr1)
            Catch ex As Exception
                MsgBox("Could not add record.", MsgBoxStyle.OKOnly, "ERROR")
            Finally
                'clearFields()
                'increaseCount()
                InsertDevice = 1
            End Try

        End Function

        Private Function InsertWorkOrder(ByVal vWO As String) As Int32

            InsertWorkOrder = 0

            Dim newDate As String = PSS.Gui.Receiving.FormatDate(Now)

            Dim strSQL As String

            Dim vQty As Integer = 0
            'If txtQuantity.Text > 0 Then vQty = txtQuantity.Text


            Dim vReceive As Integer = 0
            If Trim(cboReceive.Text) = "Flashing" Then
                vReceive = 0
            ElseIf Trim(cboReceive.Text) = "Level 1.5 Repair" Then
                vReceive = 1
            End If

            Dim vPO As String = txtPO.Text
            If Len(Trim(vPO)) < 1 Then
                vPO = "NULL"
            End If

            '//Craig Haney - New to tag workorder as reject
            '//May 17, 2006
            Dim vReject As Integer = 0
            If chkReject.Checked = True Then
                vReject = 1
            End If
            '//May 17, 2006
            '//END

            'Dim vGroup As Integer = cboGroup.SelectedValue
            Dim vGroup As Integer = 0
            vGroup = wipOwnerParent
            'strSQL = "Insert into tworkorder (" & _
            '" WO_CustWO, WO_Date, Loc_ID, Prod_ID, WO_Quantity, WO_RAQnty, WO_Project, PO_ID, Group_ID, WO_Reject) VALUES ('" & _
            'Trim(vWO) & "', '" & _
            'newDate & "', " & _
            'mLocation & ", " & _
            '"2, " & _
            'vQty & ", " & _
            'vQty & ", " & _
            'vReceive & ", " & _
            'vPO & ", " & _
            'vGroup & ", " & _
            'vReject & ")"

            '//New String Statement to include Original RMA value
            '//Added July 27, 2006
            '******************************************
            '10/07/2006 Lan add prod_id, this prod_id define when user select model
            If iprod_id = 0 Then
                MessageBox.Show("Product ID was not defined.", "Insert WO", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Function
            End If
            '******************************************
            strSQL = "Insert into tworkorder (" & _
            " WO_CustWO, WO_Date, Loc_ID, Prod_ID, WO_Quantity, WO_RAQnty, WO_Project, PO_ID, Group_ID, WO_Reject, WO_RecPalletName) VALUES ('" & _
            Trim(vWO) & "', '" & _
            newDate & "', " & _
            mLocation & ", " & _
            iprod_id & ", " & _
            vQty & ", " & _
            vQty & ", " & _
            vReceive & ", " & _
            vPO & ", " & _
            vGroup & ", " & _
            vReject & ", '" & _
            txtRMA.Text & "')"


            Dim tblWO As New PSS.Data.Production.tworkorder()
            Dim woID As Int32 = tblWO.idTransaction(strSQL)

            InsertWorkOrder = woID

            tblWO = Nothing

        End Function

        Private Sub cboModel_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboModel.SelectedValueChanged
            Dim strQuery As String = ""
            Dim dt1 As DataTable

            Try
                mModel = cboModel.SelectedValue

                '*****************************************************
                ''Lan add 11/07/2006 get prod_id 
                If Me.cboModel.SelectedValue = 0 Then
                    MessageBox.Show("Please select model.", "Select Model", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Me.cboModel.Focus()
                    Exit Sub
                End If

                strQuery = "select * from tmodel where model_id = " & Me.cboModel.SelectedValue & ";"
                dt1 = dtSource.OrderEntrySelect(strQuery)

                If dt1.Rows.Count > 0 Then
                    iprod_id = dt1.Rows(0)("Prod_id")
                Else
                    MessageBox.Show("Please select model.", "Define Prod ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Me.cboModel.Focus()
                    Exit Sub
                End If
                '*****************************************************

            Catch EX As Exception
            End Try
        End Sub




















        Private Sub LoadTray(ByVal tmpTrayID As Long)

            If IsNumeric(tmpTrayID) Then
                Dim Source As DataTable = PSS.Data.Buisness.DeviceBilling.GetDeviceTrayByID(tmpTrayID)
                If Source.Rows.Count = 0 Then
                    MsgBox("This is not a valid tray.", MsgBoxStyle.Information, "Error")
                    _tray = Nothing
                Else
                    _tray = Source
                End If
                Source = Nothing
            Else
                MsgBox("A tray number is all numeric. please enter a valid tray.", MsgBoxStyle.Information, "Error")
            End If

        End Sub
        Private Sub LoadDevice(ByVal tmpSerial As String)
            Try
                Dim __device As DataRow() = _tray.Select("Device_SN = '" & UCase(tmpSerial) & "'")
                _device = New Device(__device(0)("Device_ID"))
                Dim i As Integer = 0
                For i = 0 To _tray.Rows.Count - 1
                    If _tray.Rows(i)("Device_SN") = UCase(tmpSerial) Then
                        Exit For
                    End If
                Next

            Catch ex As Exception
                MsgBox("This is not a valid billable device.", MsgBoxStyle.Information, "Error")
                _device = Nothing
            End Try
        End Sub


        Private Sub UpdateBilling()
            Try 'here in case there is not refrence to _device
                _device.Update()
                Dim d As DataRow() = _tray.Select("Device_ID = " & _device.ID)
                If _device.Parts.Rows.Count = 0 Then
                    d(0)("Device_DateBill") = DBNull.Value
                Else
                    d(0)("Device_DateBill") = Now
                End If
                d = Nothing
                '_device.Dispose()
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Information, "Error")
            Finally
            End Try
        End Sub


        Private Sub AutoBill(ByVal intBillCode As Integer)

            Try
                _device = Nothing
                _tray = Nothing
            Catch ex As Exception
            End Try

            Me.LoadTray(_lTrayID)

            Dim xCount As Integer = 0
            Dim dt As DataTable = PSS.Data.Production.Joins.OrderEntrySelect("SELECT * FROM tdevice WHERE tray_id = " & _lTrayID)
            Dim r As DataRow

            For xCount = 0 To dt.Rows.Count - 1

                r = dt.Rows(xCount)
                Me.LoadDevice(r("Device_SN"))
                System.Windows.Forms.Application.DoEvents()

                Try
                    'Bill Part
                    _device.AddPart(intBillCode)
                    System.Windows.Forms.Application.DoEvents()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

                If Len(Trim(_lTrayID)) > 0 Then
                    If Len(Trim(r("Device_SN"))) > 0 Then
                        UpdateBilling()
                    End If
                End If

                Try
                    _device = Nothing
                    System.Windows.Forms.Application.DoEvents()
                Catch ex As Exception
                End Try

            Next

        End Sub



        Private Sub AutoBillSingle()

            Dim dt As DataTable

            Dim dtemp As DataTable = PSS.Data.Production.Joins.OrderEntrySelect("SELECT WHPallet_ID FROM twarehousepallet WHERE twarehousepallet.whPallet_Number = '" & txtRMA.Text & "'")
            Dim rTemp As DataRow = dtemp.Rows(0)

            strSQL = "select whp_binlocation , whp_loadnumber , " & _
            "whp_PartNumber, whp_PieceIdentifier, " & _
            "twarehousereceive.whr_devcondition as mBillCode from " & _
            "twarehousepalletload INNER JOIN twarehousereceive on twarehousepalletload.whpallet_id = twarehousereceive.whpallet_id " & _
            "AND twarehousepalletload.whp_PieceIdentifier = twarehousereceive.whr_dev_sn " & _
            "WHERE twarehousepalletload.whPallet_ID = '" & rTemp("Whpallet_ID") & "'" & _
            "AND twarehousereceive.whr_result = 0"

            dt = PSS.Data.Production.Joins.OrderEntrySelect(strSQL)

            Dim mBC As Integer


            Try
                _device = Nothing
                _tray = Nothing
            Catch ex As Exception
            End Try

            Me.LoadTray(_lTrayID)

            Dim xCount As Integer = 0
            Dim r As DataRow

            For xCount = 0 To dt.Rows.Count - 1
                r = dt.Rows(xCount)

                If Len(Trim(r("WHP_PieceIdentifier"))) > 0 And Len(Trim(r("mBillCode"))) > 0 Then

                    Me.LoadDevice(r("WHP_PieceIdentifier"))
                    mBC = r("mBillCode")
                    System.Windows.Forms.Application.DoEvents()

                    If mBC > 0 Then
                        Try
                            'Bill Part
                            _device.AddPart(mBC)
                            System.Windows.Forms.Application.DoEvents()
                        Catch ex As Exception
                            MsgBox(ex.ToString)
                        End Try
                    End If

                    If Len(Trim(_lTrayID)) > 0 Then
                        If Len(Trim(r("WHP_PieceIdentifier"))) > 0 Then
                            UpdateBilling()
                        End If
                    End If

                    Try
                        _device = Nothing
                        System.Windows.Forms.Application.DoEvents()
                    Catch ex As Exception
                    End Try
                End If
            Next


        End Sub


























        Private Sub runPrint()
            Dim lstTech As New PSS.Data.Production.tusers()
            Dim dtTech As DataTable = lstTech.GetCellTechList
            Dim tmpUser, tmpEmployee As String
            Dim tmpID, tmpShift As Integer
            Dim objRecWksht As PSS.Data.Buisness.RecWorksheet

            tmpUser = PSS.Core.[Global].ApplicationUser.User
            tmpID = 0
            tmpShift = 0

            Dim xCount As Integer
            Dim r As DataRow

            For xCount = 0 To dtTech.Rows.Count - 1
                r = dtTech.Rows(xCount)
                If tmpUser = r("user_fullname") Then
                    tmpID = r("tech_id")
                    tmpEmployee = r("EmployeeNo")
                    tmpShift = r("Shift_ID")
                    Exit For
                End If
            Next

            dtTech = Nothing


            Dim numCopies As Integer = 1

            If mCustomer = 1403 Then numCopies = 10

            'btnPrint.Enabled = False

            Dim strReportLoc As String = PSS.Core.ReportPath
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            '//Write records from grid to database
            'MainWin.StatusBar.SetStatusText("Writing Devices to the Database")

            Dim tmpWorkDate As String = PSS.Core.[Global].ApplicationUser.Workdate
            If Len(Trim(tmpWorkDate)) < 1 Then
                MsgBox("Your user configuration is incorrect/incomplete. Please contact your direct lead to resolve this problem. Your login will not function until this is resolved.", MsgBoxStyle.Critical, "User Setup Error")
                End
            End If

            Dim blnRecDevice As Boolean '= tReceiving.ReceivingTransmitDeviceData(dataGrid)
            blnRecDevice = PSS.Data.Production.tdevice.ReceivingTransmitDeviceData(dataGrid, DeviceType, RecType, tmpShift, tmpWorkDate)

            If blnRecDevice = False Then
                MsgBox("An error occurred while writing the devices to the database. No devices were entered.", MsgBoxStyle.OKOnly)
                'btnPrint.Enabled = True
                Exit Sub
            End If


            '//Craig D Haney October 26, 2004
            Dim dtDis As DataTable = PSS.Data.Production.Joins.OrderEntrySelect("SELECT tdevice.*, tsku.sku_number FROM (tdevice inner join tsku on tdevice.sku_id = tsku.sku_id) where Tray_ID = " & _lTrayID)
            Dim rDis As DataRow
            Dim dtSKU As DataTable = PSS.Data.Production.Joins.OrderEntrySelect("SELECT * FROM lvalidsku WHERE Model_ID = " & mModel)
            Dim rSKU As DataRow
            Dim disCount, skuCount As Integer

            Dim dtInsert As PSS.Data.Production.Joins
            Dim blnInsert As Boolean

            '//Insert no trouble found
            For disCount = 0 To dtDis.Rows.Count - 1
                rDis = dtDis.Rows(disCount)
                blnInsert = dtInsert.OrderEntryUpdateDelete("INSERT INTO tdevicecodes( device_id, dcode_id) values (" & rDis("Device_ID") & ", 1290 )")
            Next

            Dim blnGoodSku As Boolean
            Dim blnDiscrep As PSS.Data.Production.Joins
            Dim blnDiscrep2 As Boolean

            If chkVerifySku.Checked = True Then
                For disCount = 0 To dtDis.Rows.Count - 1
                    rDis = dtDis.Rows(disCount)

                    blnGoodSku = False

                    For skuCount = 0 To dtSKU.Rows.Count - 1
                        rSKU = dtSKU.Rows(skuCount)
                        If rDis("Sku_Number") = rSKU("validSku") Then
                            blnGoodSku = True
                        End If
                    Next

                    If blnGoodSku = False Then
                        '//Insert into tcellopt
                        blnDiscrep2 = blnDiscrep.OrderEntryUpdateDelete("UPDATE tcellopt set skuDiscrep = 1 where device_id = " & rDis("Device_ID"))
                    End If

                Next
            End If
            '//Craig D Haney October 26, 2004


            Dim valStage As Integer
            valStage = 0

            If valStage = 0 Then
                '//Report to Print
                'MainWin.StatusBar.SetStatusText("Sending Worksheet to Printer")

                If chkPrint.Checked = True Then
                    Try
                        objRecWksht = New PSS.Data.Buisness.RecWorksheet()

                        objRecWksht.PrintRecReport(Me._lTrayID, 1)
                    Catch exp As Exception
                        MsgBox(exp.ToString)
                        Cursor.Current = System.Windows.Forms.Cursors.Default
                    End Try
                End If

                blnAutoBill = True

                If mCustomer <> 2219 Then
                    If blnAutoBill = True Then
                        '_lTrayID = Trim(Me.lblTrayVAL.Text)
                        If chkProgramming.Checked = True Then
                            intBillCode = 442
                            AutoBill(intBillCode)
                        End If

                        If chkCosmetic.Checked = True Then
                            intBillCode = 446
                            AutoBill(intBillCode)
                        End If

                        If chkFluffBuff.Checked = True Then
                            intBillCode = 447
                            AutoBill(intBillCode)
                        End If

                        If chkTesting.Checked = True Then
                            intBillCode = 448
                            AutoBill(intBillCode)
                        End If

                        If chkInsulator.Checked = True Then
                            intBillCode = 653
                            AutoBill(intBillCode)
                        End If

                    End If

                End If

                If mCustomer = 2219 Then
                    AutoBillSingle()
                End If

            End If
            'releaseControls()
            '//If cboDateCode.Enabled = True Then cboDateCode.Text = ""
            '//If txtPOP.Enabled = True Then txtPOP.Text = ""
            '//If cboAPC.Enabled = True Then cboAPC.Text = ""
            '//If txtIncIMEI.Enabled = True Then txtIncIMEI.Text = ""
            '//If txtCourierTrackIN.Enabled = True Then txtCourierTrackIN.Text = ""
            '//If cboCarrier.Enabled = True Then cboCarrier.Text = ""
            '//If cboTransaction.Enabled = True Then cboTransaction.Text = ""
            '//If txtTransceiver.Enabled = True Then txtTransceiver.Text = ""
            '//If txtCarrModelCode.Enabled = True Then txtCarrModelCode.Text = ""
            '//If txtMIN.Enabled = True Then txtMIN.Text = ""
            '//If txtProduct.Enabled = True Then txtProduct.Text = ""
            '//If cboComplaint.Enabled = True Then cboComplaint.Text = ""
            '//If cboReturn.Enabled = True Then cboReturn.Text = ""


            txtRMA.Focus()
            dataGrid.Clear()
            '//lblTrayVAL.Text = ""
            _lTrayID = 0
            _lTrayID = 0
            '//lblCountVAL.Text = 0
            mWO = 0
            mSKU = 0
            mCount = 0

            Cursor.Current = System.Windows.Forms.Cursors.Default
            'MainWin.StatusBar.SetStatusText("")


            '//txtDeviceSN.Focus()
            cboManufacturer.Focus()
            '//btnPrint.Enabled = True
        End Sub


        Private Sub btnRevByFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRevByFile.Click

            txtRMA.Text = UCase(txtRMA.Text)
            System.Windows.Forms.Application.DoEvents()

            '//This section is to determine if the workorder name has reserved values {}
            Dim blnWOname As Boolean = True
            Dim strWOcheck As String
            Dim mCount As Integer = 1

            For mCount = 1 To Len(txtRMA.Text)
                strWOcheck = Mid$(Trim(txtRMA.Text), mCount, 1)
                If strWOcheck = "{" Or strWOcheck = "}" Then
                    blnWOname = False
                    Exit For
                End If
            Next
            If blnWOname = False Then
                MsgBox("The workorder name can not contain the values {,}", MsgBoxStyle.OKOnly, "Change Name")
                Exit Sub
            End If
            '//This section is to determine if the workorder name has reserved values {}

            mCustomer = cboCustomer.SelectedValue

            '//This is a hard assign for locations based on customer
            '//SHOULD BE REMOVED
            If mCustomer = 2058 Then
                mLocation = 2579
            ElseIf mCustomer = 2019 Then
                mLocation = 2540
            ElseIf mCustomer = 2219 Then  '//Gamestop
                mLocation = 2743
            End If

            '//Check to see if receive type is defined
            If Len(Trim(cboReceive.Text)) < 1 Then
                MsgBox("Please choose a receive type", MsgBoxStyle.OKOnly)
                Exit Sub
            End If

            '//Should not be needed - March 31, 2006
            Try
                txtRMA.Text = UCase(txtRMA.Text)
            Catch ex As Exception
            End Try
            '//Should not be needed - March 31, 2006

            Dim blnCheck1 As Boolean = False

            Try
                '//Verify data has been selected before continuing
                If Len(Trim(cboCustomer.Text)) > 0 And mCustomer > 0 Then
                    If Len(Trim(cboManufacturer.Text)) > 0 And mManufacturer > 0 Then
                        If Len(Trim(cboModel.Text)) > 0 And mModel > 0 Then
                            If Len(Trim(txtRMA.Text)) > 0 Then
                                If CInt(txtQuantity.Text) > 0 Then
                                    'If Len(Trim(cboGroup.Text)) > 0 Then
                                    blnCheck1 = True
                                    'End If
                                End If
                            End If
                        End If
                    End If
                End If

            Catch ex As Exception
            End Try

            System.Windows.Forms.Application.DoEvents()
            If blnCheck1 = False Then
                MsgBox("File Receiving can not activate - not all data is supplied or the ID values are  corrupt")
                cboManufacturer.Focus()
                Exit Sub
            End If
            '//Verify data has been selected before continuing

            '//If a PO is defined then get the appropriate information
            Dim vPO As Integer
            If Len(Trim(txtPO.Text)) > 0 Then
                Try
                    vPO = CInt(txtPO.Text) '//All PO values should be numeric
                    Dim dsPO As PSS.Data.Production.Joins
                    Dim dtPO As DataTable = dsPO.OrderEntrySelect("SELECT * FROM tpurchaseorder WHERE PO_ID = " & vPO)

                    If dtPO.Rows.Count < 1 Then '//This identifies that the PO number does not exists in tpurchaseorder
                        MsgBox("The PO value is invalid. Can not continue.", MsgBoxStyle.OKOnly, "ERROR")
                        Exit Sub
                    End If
                Catch ex As Exception
                    '//This will catch if the po defined is not numeric
                    MsgBox("The PO value is invalid. Can not continue.", MsgBoxStyle.OKOnly, "ERROR")
                    Exit Sub
                End Try
            End If
            '//If a PO is defined then get the appropriate information

            Dim ds As PSS.Data.Production.Joins

            Dim sConnectionstring As String
            Dim objConn As New OleDbConnection()
            Dim objCmdSelect As New OleDbCommand()
            Dim objAdapter1 As New OleDbDataAdapter()
            Dim dt As New DataTable()
            Dim objDataset1 As New DataSet()
            Dim xCount As Integer = 0
            Dim r As DataRow
            Dim vResponse As String

            Dim strFile As String

            '//Assigned location of file
            'strFile = Dir("R:\ATCLE\ATCLE_DataFiles\" & Trim(txtRMA.Text) & ".xls")
            'Do Until Len(strFile) < 1

            '//Create a datatable of all values from the assigned file
            'sConnectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=R:\ATCLE\ATCLE_DataFiles\" & strFile & ";Extended Properties=Excel 8.0;"
            'objConn.ConnectionString = sConnectionstring
            'objConn.Open()
            'objCmdSelect.CommandText = ("SELECT * FROM [McHugh Export$]") '
            'objCmdSelect.Connection = objConn
            'objAdapter1.SelectCommand = objCmdSelect
            'objAdapter1.Fill(dt)
            'objAdapter1.Fill(objDataset1, "XLData")

            strSQL = "select whp_binlocation as 'Bin Location', whp_loadnumber as 'Load Number', whp_PartNumber as 'Part Number', whp_PieceIdentifier as 'Piece Identifier' from twarehousepalletload WHERE whp_BinLocation = '" & txtRMA.Text & "'"""
            dt = ds.OrderEntrySelect(strSQL)


            '//Get a listing off all skus for this workorder load
            '//SKU size (LONG AND SHORT) matter
            Dim dtSKUS As New DataTable()
            'objCmdSelect.CommandText = ("SELECT [Part Number], COUNT([Part Number]) as dcount FROM [McHugh Export$] GROUP BY [Part Number]")
            'objCmdSelect.Connection = objConn
            'objAdapter1.SelectCommand = objCmdSelect
            'objAdapter1.Fill(dtSKUS)

            strSQL = "select whp_PartNumber as 'Part Number', count(whp_PartNumber) as dcount from twarehousepalletload WHERE whp_BinLocation = '" & txtRMA.Text & "'"
            dtSKUS = ds.OrderEntrySelect(strSQL)

            Dim mSku As String
            Dim x As Integer

            '//Get the range sizes from the database - tskudescription
            Dim shortLOW, shortHIGH, longLOW, longHIGH As Integer
            Dim dtshort As DataTable = ds.OrderEntrySelect("SELECT * FROM tskudescription WHERE SKUDESC_ID = 1")
            r = dtshort.Rows(0)
            shortLOW = r("skuDESC_Length_LOW")
            shortHIGH = r("skuDESC_Length_HIGH")
            System.Windows.Forms.Application.DoEvents()
            dtshort = Nothing
            Dim dtlong As DataTable = ds.OrderEntrySelect("SELECT * FROM tskudescription WHERE SKUDESC_ID = 2")
            r = dtlong.Rows(0)
            longLOW = r("skuDESC_Length_LOW")
            longHIGH = r("skuDESC_Length_HIGH")
            System.Windows.Forms.Application.DoEvents()
            dtlong = Nothing
            '//Get the range sizes from the database - tskudescription



            Dim blnWOSHORT, blnWOLONG As Boolean
            blnWOSHORT = False
            blnWOLONG = False

            Try
                For x = 0 To dtSKUS.Rows.Count - 1
                    r = dtSKUS.Rows(x)
                    If Len(Trim(r("Part Number"))) >= longLOW And Len(Trim(r("Part Number"))) <= longHIGH Then
                        blnWOLONG = True
                    ElseIf Len(Trim(r("Part Number"))) >= shortLOW And Len(Trim(r("Part Number"))) <= shortHIGH Then
                        blnWOSHORT = True
                    End If
                Next
            Catch ex As Exception
                MsgBox("Can not load this file - empty rows.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End Try


            '//Verify that workorders are available for processing
            Dim WOname As String
            If blnWOSHORT = True Then
                WOname = Trim(txtRMA.Text) & "{S}"
                mWO = 0
                Try
                    Dim dtWO As DataTable = PSS.Data.Production.tworkorder.GetCustWObyName(WOname)
                    Dim rWO As DataRow = dtWO.Rows(0)
                    mWO = rWO("WO_ID")
                Catch ex As Exception
                End Try
                If mWO > 0 Then
                    MsgBox("This Short Workorder is already being used.", MsgBoxStyle.OKOnly, "ERROR")
                    Exit Sub
                End If
            End If
            If blnWOLONG = True Then
                WOname = Trim(txtRMA.Text) & "{L}"
                mWO = 0
                Try
                    Dim dtWO As DataTable = PSS.Data.Production.tworkorder.GetCustWObyName(WOname)
                    Dim rWO As DataRow = dtWO.Rows(0)
                    mWO = rWO("WO_ID")
                Catch ex As Exception
                End Try
                If mWO > 0 Then
                    MsgBox("This Long Workorder is already being used.", MsgBoxStyle.OKOnly, "ERROR")
                    Exit Sub
                End If
            End If

            '//verify that the detail records are not blank
            Dim dtBlankDevice As New DataTable()
            Try
                objCmdSelect.CommandText = ("SELECT * FROM [McHugh Export$] WHERE [Piece Identifier] = """)
                objCmdSelect.Connection = objConn
                objAdapter1.SelectCommand = objCmdSelect
                objAdapter1.Fill(dtBlankDevice)

                If dtBlankDevice.Rows.Count > 0 Then
                    MsgBox("Empty rows are present. can not continue.", MsgBoxStyle.Exclamation, "ERROR")
                    Exit Sub
                End If
            Catch ex As Exception
            End Try
            dtBlankDevice = Nothing

            If blnWOSHORT = True Then
                WOname = Trim(txtRMA.Text) & "{S}"
                'mWO = 0
                Dim mWO1 As Integer = 0
                mCount = Me.fileReceive(WOname, mWO1, dt, _lTrayID, mModel, mCustomer, shortLOW, shortHIGH)
                If mWO > 0 Then
                    Dim updDs As PSS.Data.Production.Joins
                    Dim updSQL = "UPDATE tworkorder SET wo_quantity = " & mCount & ", wo_raqnty = " & mCount & " WHERE wo_id = " & mWO
                    Dim blnUpdate As Boolean = updDs.OrderEntryUpdateDelete(updSQL)
                End If

                vResponse = MsgBox("Do you want to load these " & mCount & " entries?", MsgBoxStyle.OKCancel, "To Continue")
                Select Case vResponse
                    Case vbOK
                        runPrint()
                    Case vbCancel
                        MsgBox("nothing will be processed into the system.", MsgBoxStyle.OKOnly)
                        'Exit Sub
                End Select
            End If

            System.Windows.Forms.Application.DoEvents()

            If blnWOLONG = True Then
                WOname = Trim(txtRMA.Text) & "{L}"
                'mWO = 0
                Dim mWO1 As Integer = 0
                mCount = Me.fileReceive(WOname, mWO1, dt, _lTrayID, mModel, mCustomer, longLOW, longHIGH)

                If mWO > 0 Then
                    Dim updDs As PSS.Data.Production.Joins
                    Dim updSQL = "UPDATE tworkorder SET wo_quantity = " & mCount & ", wo_raqnty = " & mCount & " WHERE wo_id = " & mWO
                    Dim blnUpdate As Boolean = updDs.OrderEntryUpdateDelete(updSQL)
                End If

                vResponse = MsgBox("Do you want to load these " & mCount & " entries?", MsgBoxStyle.OKCancel, "To Continue")
                Select Case vResponse
                    Case vbOK
                        runPrint()
                    Case vbCancel
                        MsgBox("nothing will be processed into the system.", MsgBoxStyle.OKOnly)
                        'Exit Sub
                End Select
            End If

            Me.updWHPPalletRcvd()
            System.Windows.Forms.Application.DoEvents()
            Me.updCellOptOwner(mWO, WOname)
            System.Windows.Forms.Application.DoEvents()
            MsgBox("Complete", MsgBoxStyle.OKOnly)

            mWO = 0

        End Sub





        Private Function fileReceive(ByVal txtWO As String, ByVal WOID As Long, ByVal DT As DataTable, ByVal vTray As Long, ByVal vModel As Long, ByVal vCustomer As Long, ByVal mlow As Integer, ByVal mhigh As Integer) As Long


            Try
                Dim dtWO As DataTable = PSS.Data.Production.tworkorder.GetCustWObyName(txtWO)
                Dim rWO As DataRow = dtWO.Rows(0)
                mWO = rWO("WO_ID")
            Catch ex As Exception
            End Try

            If mWO > 0 Then
                MsgBox("This Workorder is already being used.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Function
            Else
                mWO = InsertWorkOrder(txtWO)
            End If


            If vTray = 0 Then
                vTray = InsertTray(mWO)
            End If

            'Dim vNumber As Integer = CInt(txtQuantity.Text) - 1

            Dim xCount As Integer = 0
            Dim r As DataRow

            For xCount = 0 To DT.Rows.Count - 1
                '    For xCount = 0 To vNumber
                r = DT.Rows(xCount)

                'If Trim(r("Bin Location")) = Trim(txtWO) Then
                If Len(Trim(r("Part Number"))) >= mlow And Len(Trim(r("Part Number"))) <= mhigh Then
                    '//Craig D Haney - change this code to run for every line
                    'If mSKU = 0 Then mSKU = SKUmake(r("Part Number"), mModel, mCustomer)
                    mSKU = SKUmake(r("Part Number"), vModel, vCustomer)
                    '//Craig D Haney - change this code to run for every line

                    '//Add record to grid
                    mSerialNumber = r("Piece Identifier")
                    mSerialID = InsertDevice()
                    mCount += 1
                End If
                'End If
            Next

            Return mCount

        End Function





















        Private Function InsertTray(ByVal valWO As Int32) As Int32

            Dim strSQL As String = "Insert into ttray (" & _
            " Tray_RecUser, WO_ID) VALUES ('" & _
            recUser & "', " & _
            mWO & ")"

            Dim tblTray As New PSS.Data.Production.ttray()
            Dim trayID As Int32 = tblTray.idTransDev(strSQL)
            InsertTray = trayID
            _lTrayID = trayID
            'lblTrayVAL.Text = _lTrayID

            'Get PSS Warranty fields
            'PopulatePSSwrtyFields(mCustomer)
        End Function



        Private Sub oldWarehouseReceive()

            txtRMA.Text = UCase(txtRMA.Text)
            System.Windows.Forms.Application.DoEvents()

            mCustomer = cboCustomer.SelectedValue

            If mCustomer = 2058 Then
                mLocation = 2579
            ElseIf mCustomer = 2019 Then
                mLocation = 2540
            End If

            If Len(Trim(cboReceive.Text)) < 1 Then
                MsgBox("Please choose a receive type", MsgBoxStyle.OKOnly)
                Exit Sub
            End If

            Try
                txtRMA.Text = UCase(txtRMA.Text)
            Catch ex As Exception
            End Try

            Dim blnCheck1 As Boolean = False

            Try
                '//Verify data has been selected before continuing
                If Len(Trim(cboCustomer.Text)) > 0 And mCustomer > 0 Then
                    If Len(Trim(cboManufacturer.Text)) > 0 And mManufacturer > 0 Then
                        If Len(Trim(cboModel.Text)) > 0 And mModel > 0 Then
                            If Len(Trim(txtRMA.Text)) > 0 Then
                                'If CInt(txtQuantity.Text) > 0 Then
                                blnCheck1 = True
                                'End If
                            End If
                        End If
                    End If
                End If


            Catch ex As Exception
            End Try

            'If Len(Trim(cboGroup.Text)) < 1 Then
            'blnCheck1 = False
            'End If

            Dim vPO As Integer
            If Len(Trim(txtPO.Text)) > 0 Then
                Try
                    vPO = CInt(txtPO.Text)

                    Dim dsPO As PSS.Data.Production.Joins
                    Dim dtPO As DataTable = dsPO.OrderEntrySelect("SELECT * FROM tpurchaseorder WHERE PO_ID = " & vPO)

                    If dtPO.Rows.Count < 1 Then
                        MsgBox("The PO value is invalid. Can not continue.", MsgBoxStyle.OKOnly, "ERROR")
                        Exit Sub
                    End If

                Catch ex As Exception
                    MsgBox("The PO value is invalid. Can not continue.", MsgBoxStyle.OKOnly, "ERROR")
                    Exit Sub
                End Try
            End If

            If blnCheck1 = False Then
                MsgBox("File Receiving can not activate - not all data is supplied or the ID values are  corrupt")
                cboManufacturer.Focus()
                Exit Sub
            End If

            Try
                Dim dtWO As DataTable = PSS.Data.Production.tworkorder.GetCustWObyName(Trim(txtRMA.Text))
                Dim rWO As DataRow = dtWO.Rows(0)
                mWO = rWO("WO_ID")
            Catch ex As Exception
            End Try

            If mWO > 0 Then
                MsgBox("This Workorder is already being used.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            Else
                mWO = InsertWorkOrder(txtRMA.Text)
            End If


            If _lTrayID = 0 Then
                _lTrayID = InsertTray(mWO)
            End If



            '            Dim sConnectionstring As String
            '            Dim objConn As New OleDbConnection()
            '            Dim objCmdSelect As New OleDbCommand()
            '            Dim objAdapter1 As New OleDbDataAdapter()
            Dim dt As New DataTable()
            Dim objDataset1 As New DataSet()
            Dim xCount As Integer = 0
            Dim r As DataRow
            Dim vResponse As String

            '            Dim strFile As String

            '            strFile = Dir("R:\ATCLE\ATCLE_DataFiles\" & Trim(txtRMA.Text) & ".xls")

            '            Do Until Len(strFile) < 1


            '               sConnectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=R:\ATCLE\ATCLE_DataFiles\" & strFile & ";Extended Properties=Excel 8.0;"
            '               objConn.ConnectionString = sConnectionstring
            '               objConn.Open()

            '               objCmdSelect.CommandText = ("SELECT * FROM [McHugh Export$]") '
            '               objCmdSelect.Connection = objConn
            '               objAdapter1.SelectCommand = objCmdSelect

            '               objAdapter1.Fill(dt)

            '                objAdapter1.Fill(objDataset1, "XLData")

            'Dim vNumber As Integer = CInt(txtQuantity.Text) - 1
            Dim vNumber As Integer = 0


            Dim ds As PSS.Data.Production.Joins
            Dim mSQL As String
            mSQL = "SELECT WHP_BinLocation as BinLocation, WHR_Box_SN as PieceIdentifier, WHP_PartNumber as PartNumber FROM " & _
                        "twarehousepallet inner join twarehousereceive on twarehousepallet.WHPallet_ID = twarehousereceive.whpallet_id " & _
                        "inner join twarehousepalletload on " & _
                        "(twarehousepallet.WHPallet_ID = twarehousepalletload.WHPallet_ID " & _
                        "AND twarehousereceive.WHR_Box_SN = twarehousepalletload.WHP_PieceIdentifier) " & _
                        "WHERE twarehousepallet.WHPallet_Number = '" & UCase(Trim(txtRMA.Text)) & "' " & _
                        "AND twarehousereceive.WHR_Result = 0"

            dt = ds.OrderEntrySelect(mSQL)


            For xCount = 0 To dt.Rows.Count - 1
                '    For xCount = 0 To vNumber
                r = dt.Rows(xCount)

                If Trim(r("BinLocation")) = Trim(txtRMA.Text) Then

                    '//Craig D Haney - change this code to run for every line
                    'If mSKU = 0 Then mSKU = SKUmake(r("Part Number"), mModel, mCustomer)
                    mSKU = SKUmake(r("PartNumber"), mModel, mCustomer)
                    '//Craig D Haney - change this code to run for every line

                    '//Add record to grid
                    mSerialNumber = r("PieceIdentifier")
                    mSerialID = InsertDevice()
                    mCount += 1
                End If
            Next

            'objConn.Close()

            'If mCount > 0 Then Exit Do

            'strFile = Dir()

            '           Loop


            '//February 15, 2006
            '//Trigger to load regardless of numbers


            'If mCount = CInt(txtQuantity.Text) Then

            If mWO > 0 Then
                Dim updDs As PSS.Data.Production.Joins
                Dim updSQL = "UPDATE tworkorder SET wo_quantity = " & mCount & ", wo_raqnty = " & mCount & " WHERE wo_id = " & mWO
                Dim blnUpdate As Boolean = updDs.OrderEntryUpdateDelete(updSQL)
            End If

            vResponse = MsgBox("Do you want to load these " & mCount & " entries?", MsgBoxStyle.OKCancel, "To COntinue")
            Select Case vResponse
                Case vbOK
                    runPrint()
                Case vbCancel
                    MsgBox("nothing will be processed into the system.", MsgBoxStyle.OKOnly)
                    Exit Sub
            End Select


            'Else
            'End If

        End Sub





        Private Function fileWareHouseReceive(ByVal txtWO As String, ByVal WOID As Long, ByVal DT As DataTable, ByVal vTray As Long, ByVal vModel As Long, ByVal vCustomer As Long, ByVal mlow As Integer, ByVal mhigh As Integer, ByVal DTCHECK As DataTable) As Long

            mCount = 0

            Try
                Dim dtWO As DataTable = PSS.Data.Production.tworkorder.GetCustWObyName(txtWO)
                Dim rWO As DataRow = dtWO.Rows(0)
                mWO = rWO("WO_ID")
            Catch ex As Exception
            End Try

            If mWO > 0 Then
                'MsgBox("This Workorder is already being used.", MsgBoxStyle.OKOnly, "ERROR")
                'Exit Function
                '********************************************
                'added by Lan on 02/19/2007 
                'check if wo exist
                '********************************************
                Dim objMisc As New PSS.Data.Production.Misc()
                Dim dt1 As DataTable
                Dim i As Integer = 0

                Try
                    objMisc._SQL = "select count(*) as cnt from tdevice where wo_id = " & mWO & ";"
                    dt1 = objMisc.GetDataTable
                    If dt1.Rows(0)("cnt") > 0 Then
                        MsgBox("This Workorder is already being used with " & dt1.Rows(0)("cnt") & " devices.", MsgBoxStyle.OKOnly, "ERROR")
                        Return 0
                    Else
                        objMisc._SQL = "delete from tworkorder where wo_id = " & mWO & ";"
                        i = objMisc.ExecuteNonQuery
                        mWO = 0
                    End If

                Catch ex As Exception
                    MessageBox.Show("Check WO ERR::: " & ex.tostring, "Check Work Order", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Return 0
                Finally
                    If Not IsNothing(dt1) Then
                        dt1.Dispose()
                        dt1 = Nothing
                    End If
                    objMisc = Nothing
                End Try


                '********************************************
            Else
                mWO = InsertWorkOrder(txtWO)
            End If


            If vTray = 0 Then
                vTray = InsertTray(mWO)
            End If

            'Dim vNumber As Integer = CInt(txtQuantity.Text) - 1

            Dim xCount As Integer = 0
            Dim r As DataRow
            Dim checkCount As Integer = 0
            Dim checkR As DataRow



            For xCount = 0 To DT.Rows.Count - 1
                '    For xCount = 0 To vNumber
                r = DT.Rows(xCount)

                '//Verify that the serial number is in the warehouseReceive group

                For checkCount = 0 To DTCHECK.Rows.Count - 1
                    checkR = DTCHECK.Rows(checkCount)
                    If checkR("PieceIdentifier") = r("WHP_PieceIdentifier") Then

                        Try
                            If mCustomer = 2219 Then
                                vBillCode = r("mBillCode")
                            Else
                                vBillCode = 0
                            End If
                        Catch ex As Exception
                            vBillCode = 0
                        End Try

                        'If Trim(r("Bin Location")) = Trim(txtWO) Then

                        If mCustomer <> 2219 Then
                            If Len(Trim(r("WHP_PartNumber"))) >= mlow And Len(Trim(r("WHP_PartNumber"))) <= mhigh Then
                                '//Craig D Haney - change this code to run for every line
                                'If mSKU = 0 Then mSKU = SKUmake(r("Part Number"), mModel, mCustomer)
                                mSKU = SKUmake(r("WHP_PartNumber"), vModel, vCustomer)
                                '//Craig D Haney - change this code to run for every line

                                '//Add record to grid
                                mSerialNumber = r("WHP_PieceIdentifier")
                                mSerialID = InsertDevice()
                                mCount += 1
                            End If
                        Else
                            mSKU = SKUmake(r("WHP_PartNumber"), vModel, vCustomer)
                            mSerialNumber = r("WHP_PieceIdentifier")
                            mSerialID = InsertDevice()
                            mCount += 1
                        End If
                    End If
                Next


                '//Verify that the serial number is in the warehouseReceive group




            Next

            Return mCount

        End Function


        Private Sub updWHPPalletRcvd()
            If Len(Trim(txtRMA.Text)) > 0 Then
                Dim dt As PSS.Data.Production.Joins
                Dim blnUpdate As Boolean
                Dim strSQL As String
                strSQL = "UPDATE twarehousepallet SET WHP_PalletRcvd = 1 WHERE WHPallet_Number = '" & UCase(txtRMA.Text) & "'"
                blnUpdate = dt.OrderEntryUpdateDelete(strSQL)
                If blnUpdate = False Then
                    MsgBox("The WarehousePallet Received could not be set. Contact IT.", MsgBoxStyle.Critical, "ERROR")
                End If
            End If
        End Sub


        Private Sub updCellOptOwner(ByVal WOID As Long, ByVal nameWO As String)

            Dim blnUpdate As Boolean
            Dim strSQL As String
            Dim dt As PSS.Data.Production.Joins

            If WOID > 0 Then
                strSQL = "UPDATE tdevice, tcellopt SET cellopt_WIPOwner = " & wipOwner & ", CellOpt_WIPEntryDt = '" & FormatDate(Now) & "' WHERE tdevice.device_id = tcellopt.device_id AND tdevice.wo_id = " & WOID
                blnUpdate = dt.OrderEntryUpdateDelete(strSQL)
                If blnUpdate = False Then
                    MsgBox("The WIP Owner could not be set. Contact IT.", MsgBoxStyle.Critical, "ERROR")
                End If

            Else
                Try
                    Dim dtWO As DataTable = PSS.Data.Production.tworkorder.GetCustWObyName(nameWO)
                    Dim rWO As DataRow = dtWO.Rows(0)
                    mWO = rWO("WO_ID")
                    If wipOwner > 0 Then
                        If mWO > 0 Then
                            strSQL = "UPDATE tdevice, tcellopt SET cellopt_WIPOwner = " & wipOwner & ", CellOpt_WIPEntryDt = '" & FormatDate(Now) & "' WHERE tdevice.device_id = tcellopt.device_id AND tdevice.wo_id = " & mWO
                            blnUpdate = dt.OrderEntryUpdateDelete(strSQL)
                            If blnUpdate = False Then
                                MsgBox("The WIP Owner could not be set. Contact IT.", MsgBoxStyle.Critical, "ERROR")
                            End If
                        End If
                    End If
                Catch ex As Exception
                End Try
            End If

        End Sub



        Private Sub cboCustomer_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustomer.SelectionChangeCommitted

            If cboCustomer.SelectedValue = 2219 Then
                Label1.Visible = False
                chkProgramming.Visible = False
                chkFluffBuff.Visible = False
                chkCosmetic.Visible = False
                chkTesting.Visible = False
                chkInsulator.Visible = False

                chkVerifySku.Checked = False
                chkPrint.Checked = False

                Me.txtPO.Enabled = False

            Else
                Label1.Visible = True
                chkProgramming.Visible = True
                chkFluffBuff.Visible = True
                chkCosmetic.Visible = True
                chkTesting.Visible = True
                chkInsulator.Visible = True

                chkVerifySku.Checked = True
                chkPrint.Checked = True

                Me.txtPO.Enabled = True
            End If

        End Sub


        Private Sub cboCustomer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomer.SelectedIndexChanged

        End Sub
    End Class

End Namespace
