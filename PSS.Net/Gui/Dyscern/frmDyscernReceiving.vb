'Option Explicit On 

'Imports PSS.Core.Global
'Imports PSS.Data.Buisness

'Public Class frmDyscernReceiving
'    Inherits System.Windows.Forms.Form

'    Private _objDysRec As DyscernReceiving

'    Private _strMachine As String = System.Net.Dns.GetHostName
'    Private _strUserName As String = ApplicationUser.User
'    Private _iUserID As Integer = ApplicationUser.IDuser
'    Private _iEmpNo As Integer = ApplicationUser.NumberEmp
'    Private _iShiftID As Integer = ApplicationUser.IDShift
'    Private _strWorkDate As String = ApplicationUser.Workdate
'    Private _iMachineGroupID As String = ApplicationUser.GroupID
'    Private _strMachineGroupDesc As String = ApplicationUser.Group_Desc
'    Private _iWCLocationID As Integer = 0
'    Private _iLineID As Integer = ApplicationUser.LineID

'    Private _dtRecItems As DataTable
'    Private _iWOID As Integer = 0
'    Private _iTrayID As Integer = 0
'    Private _strWOName As String = ""

'#Region " Windows Form Designer generated code "

'    Public Sub New()
'        MyBase.New()

'        'This call is required by the Windows Form Designer.
'        InitializeComponent()

'        'Add any initialization after the InitializeComponent() call
'        _objDysRec = New DyscernReceiving()
'    End Sub

'    'Form overrides dispose to clean up the component list.
'    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
'        If disposing Then
'            If Not (components Is Nothing) Then
'                components.Dispose()
'            End If
'            _objDysRec = Nothing
'        End If
'        MyBase.Dispose(disposing)
'    End Sub

'    'Required by the Windows Form Designer
'    Private components As System.ComponentModel.IContainer

'    'NOTE: The following procedure is required by the Windows Form Designer
'    'It can be modified using the Windows Form Designer.  
'    'Do not modify it using the code editor.
'    Friend WithEvents cmbRecModel As PSS.Gui.Controls.ComboBox
'    Friend WithEvents Label4 As System.Windows.Forms.Label
'    Friend WithEvents Label10 As System.Windows.Forms.Label
'    Friend WithEvents Label1 As System.Windows.Forms.Label
'    Friend WithEvents txtRecIMEI As System.Windows.Forms.TextBox
'    Friend WithEvents txtDeviceID As System.Windows.Forms.TextBox
'    Friend WithEvents dbgRecDevices As C1.Win.C1TrueDBGrid.C1TrueDBGrid
'    Friend WithEvents btnRecClearAll As System.Windows.Forms.Button
'    Friend WithEvents btnRecClear As System.Windows.Forms.Button
'    Friend WithEvents btnRec As System.Windows.Forms.Button
'    Friend WithEvents txtWO As System.Windows.Forms.TextBox
'    Friend WithEvents Label2 As System.Windows.Forms.Label
'    Friend WithEvents btnCancel As System.Windows.Forms.Button
'    Friend WithEvents Label3 As System.Windows.Forms.Label
'    Friend WithEvents Label5 As System.Windows.Forms.Label
'    Friend WithEvents Label6 As System.Windows.Forms.Label
'    Friend WithEvents lblRecQty As System.Windows.Forms.Label
'    Friend WithEvents lblFileQty As System.Windows.Forms.Label
'    Friend WithEvents lblScanQty As System.Windows.Forms.Label
'    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
'        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmDyscernReceiving))
'        Me.cmbRecModel = New PSS.Gui.Controls.ComboBox()
'        Me.Label4 = New System.Windows.Forms.Label()
'        Me.Label10 = New System.Windows.Forms.Label()
'        Me.txtRecIMEI = New System.Windows.Forms.TextBox()
'        Me.Label1 = New System.Windows.Forms.Label()
'        Me.txtDeviceID = New System.Windows.Forms.TextBox()
'        Me.lblScanQty = New System.Windows.Forms.Label()
'        Me.dbgRecDevices = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
'        Me.btnRecClearAll = New System.Windows.Forms.Button()
'        Me.btnRecClear = New System.Windows.Forms.Button()
'        Me.btnRec = New System.Windows.Forms.Button()
'        Me.Label2 = New System.Windows.Forms.Label()
'        Me.txtWO = New System.Windows.Forms.TextBox()
'        Me.btnCancel = New System.Windows.Forms.Button()
'        Me.Label3 = New System.Windows.Forms.Label()
'        Me.Label5 = New System.Windows.Forms.Label()
'        Me.lblRecQty = New System.Windows.Forms.Label()
'        Me.Label6 = New System.Windows.Forms.Label()
'        Me.lblFileQty = New System.Windows.Forms.Label()
'        CType(Me.dbgRecDevices, System.ComponentModel.ISupportInitialize).BeginInit()
'        Me.SuspendLayout()
'        '
'        'cmbRecModel
'        '
'        Me.cmbRecModel.AutoComplete = True
'        Me.cmbRecModel.BackColor = System.Drawing.SystemColors.Window
'        Me.cmbRecModel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.cmbRecModel.ForeColor = System.Drawing.Color.Black
'        Me.cmbRecModel.Location = New System.Drawing.Point(80, 43)
'        Me.cmbRecModel.Name = "cmbRecModel"
'        Me.cmbRecModel.Size = New System.Drawing.Size(216, 21)
'        Me.cmbRecModel.TabIndex = 2
'        '
'        'Label4
'        '
'        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label4.ForeColor = System.Drawing.Color.White
'        Me.Label4.Location = New System.Drawing.Point(24, 43)
'        Me.Label4.Name = "Label4"
'        Me.Label4.Size = New System.Drawing.Size(56, 16)
'        Me.Label4.TabIndex = 9
'        Me.Label4.Text = "Model:"
'        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'        '
'        'Label10
'        '
'        Me.Label10.BackColor = System.Drawing.Color.Transparent
'        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label10.ForeColor = System.Drawing.Color.White
'        Me.Label10.Location = New System.Drawing.Point(32, 91)
'        Me.Label10.Name = "Label10"
'        Me.Label10.Size = New System.Drawing.Size(48, 16)
'        Me.Label10.TabIndex = 101
'        Me.Label10.Text = "IMEI:"
'        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'        '
'        'txtRecIMEI
'        '
'        Me.txtRecIMEI.BackColor = System.Drawing.Color.White
'        Me.txtRecIMEI.Location = New System.Drawing.Point(80, 91)
'        Me.txtRecIMEI.MaxLength = 20
'        Me.txtRecIMEI.Name = "txtRecIMEI"
'        Me.txtRecIMEI.Size = New System.Drawing.Size(216, 20)
'        Me.txtRecIMEI.TabIndex = 4
'        Me.txtRecIMEI.Text = ""
'        '
'        'Label1
'        '
'        Me.Label1.BackColor = System.Drawing.Color.Transparent
'        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label1.ForeColor = System.Drawing.Color.White
'        Me.Label1.Location = New System.Drawing.Point(16, 67)
'        Me.Label1.Name = "Label1"
'        Me.Label1.Size = New System.Drawing.Size(64, 16)
'        Me.Label1.TabIndex = 103
'        Me.Label1.Text = "Device ID:"
'        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'        '
'        'txtDeviceID
'        '
'        Me.txtDeviceID.BackColor = System.Drawing.Color.White
'        Me.txtDeviceID.Location = New System.Drawing.Point(80, 67)
'        Me.txtDeviceID.MaxLength = 15
'        Me.txtDeviceID.Name = "txtDeviceID"
'        Me.txtDeviceID.Size = New System.Drawing.Size(216, 20)
'        Me.txtDeviceID.TabIndex = 3
'        Me.txtDeviceID.Text = ""
'        '
'        'lblScanQty
'        '
'        Me.lblScanQty.BackColor = System.Drawing.Color.Black
'        Me.lblScanQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
'        Me.lblScanQty.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.lblScanQty.ForeColor = System.Drawing.Color.Lime
'        Me.lblScanQty.Location = New System.Drawing.Point(344, 120)
'        Me.lblScanQty.Name = "lblScanQty"
'        Me.lblScanQty.Size = New System.Drawing.Size(96, 56)
'        Me.lblScanQty.TabIndex = 115
'        Me.lblScanQty.Text = "0"
'        Me.lblScanQty.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'        '
'        'dbgRecDevices
'        '
'        Me.dbgRecDevices.AllowColSelect = False
'        Me.dbgRecDevices.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
'        Me.dbgRecDevices.AllowSort = False
'        Me.dbgRecDevices.AllowUpdate = False
'        Me.dbgRecDevices.AllowUpdateOnBlur = False
'        Me.dbgRecDevices.AlternatingRows = True
'        Me.dbgRecDevices.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
'                    Or System.Windows.Forms.AnchorStyles.Left)
'        Me.dbgRecDevices.FilterBar = True
'        Me.dbgRecDevices.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.dbgRecDevices.GroupByCaption = "Drag a column header here to group by that column"
'        Me.dbgRecDevices.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
'        Me.dbgRecDevices.Location = New System.Drawing.Point(8, 120)
'        Me.dbgRecDevices.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
'        Me.dbgRecDevices.Name = "dbgRecDevices"
'        Me.dbgRecDevices.PreviewInfo.Location = New System.Drawing.Point(0, 0)
'        Me.dbgRecDevices.PreviewInfo.Size = New System.Drawing.Size(0, 0)
'        Me.dbgRecDevices.PreviewInfo.ZoomFactor = 75
'        Me.dbgRecDevices.RowHeight = 20
'        Me.dbgRecDevices.Size = New System.Drawing.Size(320, 328)
'        Me.dbgRecDevices.TabIndex = 134
'        Me.dbgRecDevices.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
'        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
'        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Font:Microsoft Sans Serif" & _
'        ", 8.25pt;ForeColor:White;BackColor:DarkSlateGray;}Selected{ForeColor:HighlightTe" & _
'        "xt;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;BackColor" & _
'        ":InactiveCaption;}FilterBar{BackColor:White;}Footer{}Caption{AlignHorz:Center;}S" & _
'        "tyle9{}Normal{Font:Microsoft Sans Serif, 8.25pt;BackColor:Control;AlignVert:Cent" & _
'        "er;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddRow{Fo" & _
'        "reColor:White;BackColor:DarkSlateBlue;}RecordSelector{AlignImage:Center;}Style13" & _
'        "{}Heading{Wrap:True;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Cent" & _
'        "er;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:White;BackColor:SteelBlu" & _
'        "e;}Style8{}Style10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style1{}</Data></S" & _
'        "tyles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColSelect=""False"" Name="""" Allo" & _
'        "wRowSizing=""None"" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHei" & _
'        "ght=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder" & _
'        """ RecordSelectorWidth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" Horizonta" & _
'        "lScrollGroup=""1""><Height>324</Height><CaptionStyle parent=""Style2"" me=""Style10"" " & _
'        "/><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""" & _
'        "Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=" & _
'        """Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle p" & _
'        "arent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style" & _
'        "7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow""" & _
'        " me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><Sele" & _
'        "ctedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><" & _
'        "ClientRect>0, 0, 316, 324</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sun" & _
'        "ken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style pa" & _
'        "rent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Headi" & _
'        "ng"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading""" & _
'        " me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" m" & _
'        "e=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" m" & _
'        "e=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""R" & _
'        "ecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption""" & _
'        " me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits>" & _
'        "<Layout>None</Layout><DefaultRecSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0" & _
'        ", 316, 324</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><PrintPage" & _
'        "FooterStyle parent="""" me=""Style15"" /></Blob>"
'        '
'        'btnRecClearAll
'        '
'        Me.btnRecClearAll.BackColor = System.Drawing.Color.Red
'        Me.btnRecClearAll.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.btnRecClearAll.ForeColor = System.Drawing.Color.White
'        Me.btnRecClearAll.Location = New System.Drawing.Point(344, 256)
'        Me.btnRecClearAll.Name = "btnRecClearAll"
'        Me.btnRecClearAll.RightToLeft = System.Windows.Forms.RightToLeft.No
'        Me.btnRecClearAll.Size = New System.Drawing.Size(96, 40)
'        Me.btnRecClearAll.TabIndex = 6
'        Me.btnRecClearAll.Text = "REMOVE ALL SNs"
'        '
'        'btnRecClear
'        '
'        Me.btnRecClear.BackColor = System.Drawing.Color.Red
'        Me.btnRecClear.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.btnRecClear.ForeColor = System.Drawing.Color.White
'        Me.btnRecClear.Location = New System.Drawing.Point(344, 200)
'        Me.btnRecClear.Name = "btnRecClear"
'        Me.btnRecClear.RightToLeft = System.Windows.Forms.RightToLeft.No
'        Me.btnRecClear.Size = New System.Drawing.Size(96, 40)
'        Me.btnRecClear.TabIndex = 5
'        Me.btnRecClear.Text = "REMOVE ONE SN"
'        '
'        'btnRec
'        '
'        Me.btnRec.BackColor = System.Drawing.Color.Green
'        Me.btnRec.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.btnRec.Location = New System.Drawing.Point(344, 344)
'        Me.btnRec.Name = "btnRec"
'        Me.btnRec.Size = New System.Drawing.Size(96, 40)
'        Me.btnRec.TabIndex = 7
'        Me.btnRec.Text = "RECEIVE"
'        '
'        'Label2
'        '
'        Me.Label2.BackColor = System.Drawing.Color.Transparent
'        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label2.ForeColor = System.Drawing.Color.White
'        Me.Label2.Location = New System.Drawing.Point(0, 18)
'        Me.Label2.Name = "Label2"
'        Me.Label2.Size = New System.Drawing.Size(80, 16)
'        Me.Label2.TabIndex = 137
'        Me.Label2.Text = "Work Order:"
'        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'        '
'        'txtWO
'        '
'        Me.txtWO.BackColor = System.Drawing.Color.White
'        Me.txtWO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
'        Me.txtWO.Location = New System.Drawing.Point(80, 16)
'        Me.txtWO.MaxLength = 15
'        Me.txtWO.Name = "txtWO"
'        Me.txtWO.Size = New System.Drawing.Size(216, 20)
'        Me.txtWO.TabIndex = 1
'        Me.txtWO.Text = ""
'        '
'        'btnCancel
'        '
'        Me.btnCancel.BackColor = System.Drawing.Color.SlateGray
'        Me.btnCancel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.btnCancel.ForeColor = System.Drawing.Color.White
'        Me.btnCancel.Location = New System.Drawing.Point(344, 400)
'        Me.btnCancel.Name = "btnCancel"
'        Me.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
'        Me.btnCancel.Size = New System.Drawing.Size(96, 40)
'        Me.btnCancel.TabIndex = 8
'        Me.btnCancel.Text = "CANCEL"
'        '
'        'Label3
'        '
'        Me.Label3.BackColor = System.Drawing.Color.Black
'        Me.Label3.ForeColor = System.Drawing.Color.SpringGreen
'        Me.Label3.Location = New System.Drawing.Point(352, 122)
'        Me.Label3.Name = "Label3"
'        Me.Label3.Size = New System.Drawing.Size(80, 16)
'        Me.Label3.TabIndex = 139
'        Me.Label3.Text = "Scan Qty"
'        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
'        '
'        'Label5
'        '
'        Me.Label5.BackColor = System.Drawing.Color.Black
'        Me.Label5.ForeColor = System.Drawing.Color.White
'        Me.Label5.Location = New System.Drawing.Point(472, 17)
'        Me.Label5.Name = "Label5"
'        Me.Label5.Size = New System.Drawing.Size(80, 16)
'        Me.Label5.TabIndex = 141
'        Me.Label5.Text = "Receive Qty"
'        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
'        '
'        'lblRecQty
'        '
'        Me.lblRecQty.BackColor = System.Drawing.Color.Black
'        Me.lblRecQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
'        Me.lblRecQty.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.lblRecQty.ForeColor = System.Drawing.Color.White
'        Me.lblRecQty.Location = New System.Drawing.Point(464, 16)
'        Me.lblRecQty.Name = "lblRecQty"
'        Me.lblRecQty.Size = New System.Drawing.Size(96, 56)
'        Me.lblRecQty.TabIndex = 140
'        Me.lblRecQty.Text = "0"
'        Me.lblRecQty.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'        '
'        'Label6
'        '
'        Me.Label6.BackColor = System.Drawing.Color.Black
'        Me.Label6.ForeColor = System.Drawing.Color.White
'        Me.Label6.Location = New System.Drawing.Point(352, 17)
'        Me.Label6.Name = "Label6"
'        Me.Label6.Size = New System.Drawing.Size(80, 16)
'        Me.Label6.TabIndex = 143
'        Me.Label6.Text = "File Qty"
'        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
'        '
'        'lblFileQty
'        '
'        Me.lblFileQty.BackColor = System.Drawing.Color.Black
'        Me.lblFileQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
'        Me.lblFileQty.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.lblFileQty.ForeColor = System.Drawing.Color.White
'        Me.lblFileQty.Location = New System.Drawing.Point(344, 16)
'        Me.lblFileQty.Name = "lblFileQty"
'        Me.lblFileQty.Size = New System.Drawing.Size(96, 56)
'        Me.lblFileQty.TabIndex = 142
'        Me.lblFileQty.Text = "0"
'        Me.lblFileQty.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'        '
'        'frmDyscernReceiving
'        '
'        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
'        Me.BackColor = System.Drawing.Color.SteelBlue
'        Me.ClientSize = New System.Drawing.Size(592, 462)
'        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label6, Me.lblFileQty, Me.Label5, Me.lblRecQty, Me.Label3, Me.btnCancel, Me.Label2, Me.txtWO, Me.btnRec, Me.btnRecClearAll, Me.btnRecClear, Me.dbgRecDevices, Me.lblScanQty, Me.Label1, Me.txtDeviceID, Me.Label10, Me.txtRecIMEI, Me.cmbRecModel, Me.Label4})
'        Me.ForeColor = System.Drawing.Color.White
'        Me.Name = "frmDyscernReceiving"
'        Me.Text = "Liquidity Services Receiving"
'        CType(Me.dbgRecDevices, System.ComponentModel.ISupportInitialize).EndInit()
'        Me.ResumeLayout(False)

'    End Sub

'#End Region

'    '**************************************************************
'    Private Sub frmDyscernReceiving_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
'        Dim objMisc As New PSS.Data.Buisness.Misc()
'        Dim dt1 As DataTable
'        Dim R1 As DataRow

'        Try
'            PSS.Core.Highlight.SetHighLight(Me)

'            ''********************************************
'            'Me.lblMachine.Text = GstrMachine
'            'Me.lblGroup.Text = Me.GstrMachineGroupDesc
'            'Me.lblUserName.Text = GstrUserName
'            'Me.lblShift.Text = "Shift " & GiShiftID
'            'Me.lblWorkDate.Text = Format(CDate(Me.GstrWorkDate), "MM/dd/yyyy")

'            ''********************************************
'            ''Get Wrok location ID 
'            ''********************************************
'            'dt1 = objMisc.CheckIfMachineTiedToLine(Me.GstrMachine)

'            'For Each R1 In dt1.Rows
'            '    GiWCLocationID = R1("WCLocation_ID")
'            'Next R1

'            '********************************************
'            'Load Model 
'            '********************************************
'            LoadModels()
'            '********************************************
'            'Create Receive datatable
'            Me.CreateDataTable_Receive()
'            Me.SetGridProperties_Receive()

'            Me.txtWO.Focus()

'        Catch ex As Exception
'            MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
'        Finally
'            objMisc = Nothing
'            R1 = Nothing
'            If Not IsNothing(dt1) Then
'                dt1.Dispose()
'                dt1 = Nothing
'            End If
'        End Try
'    End Sub

'    '*********************************************************
'    Private Sub LoadModels()
'        Dim dtModels As New DataTable()
'        Dim objMisc As New PSS.Data.Buisness.Misc()

'        Try
'            dtModels = objMisc.GetModels(2, 0)
'            With Me.cmbRecModel
'                .DataSource = dtModels.DefaultView
'                .DisplayMember = dtModels.Columns("Model_Desc").ToString
'                .ValueMember = dtModels.Columns("Model_ID").ToString
'                .SelectedValue = 0
'            End With

'        Catch ex As Exception
'            Throw ex
'        Finally
'            If Not IsNothing(dtModels) Then
'                dtModels.Dispose()
'                dtModels = Nothing
'            End If
'            objMisc = Nothing
'        End Try
'    End Sub

'    '**************************************************************
'    Private Sub CreateDataTable_Receive()
'        Dim objGen As PSS.Data.Buisness.Generic

'        Try
'            objGen = New PSS.Data.Buisness.Generic()

'            If Not IsNothing(Me._dtRecItems) Then
'                Me._dtRecItems.Dispose()
'                Me._dtRecItems = Nothing
'            End If

'            Me._dtRecItems = New DataTable()

'            'dd_id
'            objGen.AddNewColumnToDataTable(Me._dtRecItems, "dd_id", "System.Int32", "0")
'            'IMEI
'            objGen.AddNewColumnToDataTable(Me._dtRecItems, "IMEI", "System.String", "")
'            'Customer Device ID
'            objGen.AddNewColumnToDataTable(Me._dtRecItems, "Device ID", "System.String", "")
'            'Warranty
'            objGen.AddNewColumnToDataTable(Me._dtRecItems, "PSS Warranty", "System.Int32", "0")

'        Catch ex As Exception
'            Throw ex
'        Finally
'            objGen = Nothing
'        End Try
'    End Sub

'    '**************************************************************
'    Private Sub SetGridProperties_Receive()
'        Dim i As Integer

'        Try
'            Me.dbgRecDevices.DataSource = Nothing
'            Me.dbgRecDevices.DataSource = Me._dtRecItems

'            If Me._dtRecItems.Rows.Count > 0 Then
'                With Me.dbgRecDevices
'                    'Heading style (Horizontal Alignment to Center)
'                    For i = 0 To (Me.dbgRecDevices.Columns.Count - 1)
'                        .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
'                        .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
'                    Next

'                    'Set Column Widths
'                    .Splits(0).DisplayColumns("IMEI").Width = 130
'                    .Splits(0).DisplayColumns("Device ID").Width = 60
'                    .Splits(0).DisplayColumns("PSS Warranty").Width = 80

'                    .Splits(0).DisplayColumns("dd_id").Visible = False
'                End With
'                'Else
'                '    Me.dbgRecDevices.Visible = False
'            End If

'        Catch ex As Exception
'            Throw ex
'        End Try
'    End Sub

'    '**************************************************************
'    Private Sub cmbRecModel_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbRecModel.SelectionChangeCommitted
'        If Me.cmbRecModel.SelectedValue > 0 Then
'            Me.txtDeviceID.Focus()
'        End If
'    End Sub

'    '**************************************************************
'    Private Sub txtRecIMEI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRecIMEI.KeyPress
'        If Not (e.KeyChar.IsDigit(e.KeyChar) Or e.KeyChar.IsControl(e.KeyChar)) Then
'            e.Handled = True
'        End If
'    End Sub

'    '**************************************************************
'    Private Sub txtDeviceID_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDeviceID.KeyUp
'        If e.KeyValue = 13 Then
'            Me.txtRecIMEI.Focus()
'        End If
'    End Sub

'    '**************************************************************
'    Private Sub txtRecIMEI_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRecIMEI.KeyUp
'        Dim i As Integer = 0

'        Try
'            If e.KeyValue = 13 Then
'                If Me.txtRecIMEI.Text.Trim = "" Then
'                    Exit Sub
'                ElseIf Me.cmbRecModel.SelectedValue = 0 Then
'                    MessageBox.Show("Please select Model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
'                    Me.cmbRecModel.Focus()
'                ElseIf Me.txtDeviceID.Text.Trim = "" Then
'                    MessageBox.Show("Please enter Device ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
'                    Me.txtDeviceID.Focus()
'                    'ElseIf Me.txtRecIMEI.Text.Trim.Length <> 15 Then
'                    '    MessageBox.Show("IMEI length must be 15 digits.", "Validate IMEI", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
'                    '    Me.txtRecIMEI.SelectAll()
'                Else
'                    i = Me.ProcessSerialNum_Receive
'                    ''***************************
'                    If i > 0 Then
'                        Me.txtDeviceID.Text = ""
'                        Me.txtRecIMEI.Text = ""
'                        Me.txtDeviceID.Focus()
'                    End If
'                    ''***************************
'                End If
'            End If

'        Catch ex As Exception
'            MessageBox.Show(ex.ToString, "Scanned SN Keyup", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
'        End Try
'    End Sub

'    '**************************************************************
'    Private Function ProcessSerialNum_Receive() As Integer
'        Dim booSNExisted As Boolean = False
'        Dim objGen As PSS.Data.Buisness.Generic
'        Dim i As Integer = 0
'        Dim drNewRow As DataRow
'        Dim iPSSWarranty As Integer = 0
'        Dim dt As DataTable

'        Try
'            objGen = New PSS.Data.Buisness.Generic()

'            '*********************
'            '1:: Check Duplicate
'            '*********************
'            If Me._dtRecItems.Rows.Count > 0 Then
'                If Me._dtRecItems.Select("IMEI = '" & Me.txtRecIMEI.Text.Trim.ToUpper & "'", "").Length > 0 Then
'                    MessageBox.Show("This device is already scanned in. Try another one.", "Scan in Serial Number", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
'                    Me.txtRecIMEI.Text = ""
'                    Me.txtDeviceID.SelectAll()
'                    Exit Function
'                End If
'            End If

'            '*********************************
'            '2:: Check if device exist in WIP
'            '*********************************
'            booSNExisted = objGen.IsSNInWIP(Me._objDysRec.DYSCERN_CUSTOMER_ID, Me.txtRecIMEI.Text.Trim.ToUpper)
'            If booSNExisted = True Then
'                MessageBox.Show("This ""Serial Number"" already exists in WIP.", "Scan in Serial Number", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
'                Me.txtRecIMEI.Text = ""
'                Me.txtDeviceID.SelectAll()
'                Exit Function
'            End If

'            'Validate unit again data file
'            dt = Me._objDysRec.GetDeviceDataFileInfo(Me.txtDeviceID.Text.Trim, Me.txtWO.Text.Trim)
'            If dt.Rows.Count = 0 Then
'                MessageBox.Show("DID is missing in File.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
'                Me.txtRecIMEI.Text = ""
'                Me.txtDeviceID.SelectAll()
'                Exit Function
'            ElseIf Not IsDBNull(dt.Rows(0)("Device_ID")) AndAlso dt.Rows(0)("Device_ID") > 0 Then
'                MessageBox.Show("This DID already received under this RMA whith IMEI """ & dt.Rows(0)("IMEI") & """.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
'                Me.txtRecIMEI.Text = ""
'                Me.txtDeviceID.SelectAll()
'                Exit Function
'            ElseIf Me._dtRecItems.Select("dd_id = " & dt.Rows(0)("dd_id")).Length > 0 Then
'                MessageBox.Show("This DID is already assigned to another IMEI """ & dt.Rows(0)("IMEI") & """ on the list below.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
'                Me.txtRecIMEI.Text = ""
'                Me.txtDeviceID.SelectAll()
'                Exit Function
'            End If

'            '*********************************
'            '3:: Check for Warranty
'            '*********************************
'            'iPSSWarranty = Me._objDysRec.CheckPSSWarranty(Me._iLoc_ID, Me.txtRecIMEI.Text.Trim.ToUpper)

'            '*************************************************
'            '5::Create a new insert record for scanned device
'            '*************************************************
'            drNewRow = Me._dtRecItems.NewRow()
'            drNewRow("dd_id") = dt.Rows(0)("dd_id")
'            drNewRow("IMEI") = Me.txtRecIMEI.Text.Trim.ToUpper
'            drNewRow("Device ID") = Me.txtDeviceID.Text.Trim.ToUpper
'            drNewRow("PSS Warranty") = iPSSWarranty
'            Me._dtRecItems.Rows.Add(drNewRow)
'            Me._dtRecItems.AcceptChanges()

'            Me.lblScanQty.Text = Me._dtRecItems.Rows.Count
'            Me.SetGridProperties_Receive()

'            If Me._dtRecItems.Rows.Count > 0 Then
'                Me.dbgRecDevices.MoveLast()
'            End If
'            '**********************************

'            Return 1
'        Catch ex As Exception
'            Throw ex
'        Finally
'            objGen = Nothing
'            Generic.DisposeDT(dt)
'        End Try
'    End Function

'    '**************************************************************
'    Private Sub btnRecClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRecClear.Click
'        Dim R1 As DataRow
'        Dim strSelectedSN As String = ""

'        Try
'            If IsNothing(Me._dtRecItems) Then
'                Exit Sub
'            ElseIf Me._dtRecItems.Rows.Count = 0 Then
'                Exit Sub
'            Else

'                '*****************************
'                'Ask user for confirm message
'                '*****************************
'                If MessageBox.Show("Are you sure you want to Clear the selected device?", "Remove ONE Serial Number", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then

'                    '*****************
'                    'Get selected SN
'                    '*****************
'                    strSelectedSN = Trim(Me.dbgRecDevices.Columns("IMEI").Value)

'                    '*******************************
'                    'Remove selected SN in datatable
'                    '*******************************
'                    For Each R1 In Me._dtRecItems.Rows
'                        If R1("IMEI") = strSelectedSN Then
'                            Me._dtRecItems.Rows.Remove(R1)
'                            Me._dtRecItems.AcceptChanges()

'                            Exit For
'                        End If
'                    Next R1

'                    '*******************************
'                    'Reset datagrid, counter and msg label
'                    '*******************************
'                    If Me._dtRecItems.Rows.Count > 0 Then
'                        Me.dbgRecDevices.MoveLast()
'                    End If

'                    'Me.SetMsgLabel_Receive(Color.LightSteelBlue, Color.White, "")
'                    Me.lblScanQty.Text = Me._dtRecItems.Rows.Count
'                    Me.txtDeviceID.Text = ""
'                    Me.txtDeviceID.Focus()
'                    '*******************************
'                End If
'            End If
'        Catch ex As Exception
'            MessageBox.Show(ex.ToString, "Remove ONE Serial Number", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
'        Finally
'            R1 = Nothing
'            Me.txtDeviceID.Focus()
'        End Try
'    End Sub

'    '**************************************************************
'    Private Sub btnRecClearAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRecClearAll.Click
'        Dim R1 As DataRow

'        Try
'            If IsNothing(Me._dtRecItems) Then
'                Exit Sub
'            ElseIf Me._dtRecItems.Rows.Count = 0 Then
'                Exit Sub
'            Else
'                '*****************************
'                'Ask user for confirm message
'                '*****************************
'                If MessageBox.Show("Are you sure you want to Clear all devices?", "Remove ALL Serial Numbers", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
'                    '************************
'                    'Remove scanned devices
'                    '************************
'                    Me._dtRecItems.Clear()

'                    '****************************
'                    'Reset counter and Msg label
'                    '****************************
'                    'Me.SetMsgLabel_Receive(Color.LightSteelBlue, Color.White, "")
'                    Me.lblScanQty.Text = Me._dtRecItems.Rows.Count
'                    Me.txtDeviceID.Text = ""
'                    Me.txtDeviceID.Focus()
'                    '****************************
'                End If
'            End If

'        Catch ex As Exception
'            MessageBox.Show(ex.ToString, "Remove ALL Serial Numbers", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
'        Finally
'            R1 = Nothing
'            Me.txtDeviceID.Focus()
'        End Try
'    End Sub

'    '**************************************************************
'    Private Sub btnRec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRec.Click
'        Dim i As Integer = 0
'        Dim R1 As DataRow
'        Dim booSNExisted As Boolean = False
'        Dim objGen As New PSS.Data.Buisness.Generic()

'        Try
'            If Me._iWOID = 0 Then
'                MessageBox.Show("WO ID is missing. Re-enter Workorder name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
'            ElseIf Me._iTrayID = 0 Then
'                MessageBox.Show("Tray ID is missing. Re-enter Workorder name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
'            ElseIf Me._dtRecItems.Rows.Count > 0 Then
'                '****************************
'                'Check SN exist in WIP again
'                '****************************
'                For Each R1 In Me._dtRecItems.Rows
'                    booSNExisted = objGen.IsSNInWIP(Me._objDysRec.DYSCERN_CUSTOMER_ID, UCase(Trim(R1("IMEI"))))
'                    If booSNExisted = True Then
'                        MessageBox.Show("This ""Serial Number: " & UCase(Trim(R1("IMEI"))) & """ already exists in WIP. Please remove it before you load again.", "Scan in Serial Number", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
'                        Me.txtRecIMEI.SelectAll()
'                        Exit Sub
'                    End If
'                    booSNExisted = False
'                Next R1

'                If MessageBox.Show("Are you sure you want to receive all device(s) into PSS system?", "Load Device(s)", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub

'                Me.Enabled = False
'                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

'                i = Me._objDysRec.RecDCDevicesIntoPSSWIP(Me._strWOName, Me._iWOID, Me._iTrayID, Me.cmbRecModel.SelectedValue, _
'                                                        Me._strUserName, Me._iUserID, Me._iEmpNo, Me._iShiftID, Me._strWorkDate, Me._dtRecItems)
'                If i > 0 Then
'                    MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
'                    Me.lblRecQty.Text = CInt(Me.lblRecQty.Text) + Me._dtRecItems.Rows.Count
'                    Me._dtRecItems.Clear()
'                    Me.SetGridProperties_Receive()
'                    Me.lblScanQty.Text = Me._dtRecItems.Rows.Count
'                    Me.txtDeviceID.Text = ""
'                    Me.txtRecIMEI.Text = ""
'                    Me.txtDeviceID.Focus()
'                End If
'            End If

'        Catch ex As Exception
'            MessageBox.Show(ex.ToString, "btnRec_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
'        Finally
'            R1 = Nothing
'            objGen = Nothing
'            Cursor.Current = System.Windows.Forms.Cursors.Default
'            Me.Enabled = True
'            Me.txtDeviceID.Focus()
'        End Try
'    End Sub

'    '**************************************************************
'    Private Sub txtWO_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtWO.Enter
'        Me._strWOName = Me.txtWO.Text.Trim
'    End Sub

'    '**************************************************************
'    Private Sub txtWO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtWO.KeyPress
'        If Not (e.KeyChar.IsLetterOrDigit(e.KeyChar) Or e.KeyChar.IsControl(e.KeyChar)) Then
'            e.Handled = True
'        End If
'    End Sub

'    '**************************************************************
'    Private Sub txtWO_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWO.KeyUp
'        If e.KeyValue = 13 Then
'            If Me.txtWO.Text.Trim.Length > 0 Then
'                If Me.cmbRecModel.SelectedValue = 0 Then Me.cmbRecModel.Focus() Else Me.txtDeviceID.Focus()
'            End If
'        End If
'    End Sub

'    '**************************************************************
'    Private Sub txtWO_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtWO.Leave
'        Dim iRecQty As Integer = 0
'        Dim iFileQty As Integer = 0
'        Dim booResult As Boolean = False

'        Try
'            If Me.txtWO.Text.Trim.Length = 0 Then
'                Me._iWOID = 0
'                Me._iTrayID = 0
'                Me._strWOName = ""
'                Me._dtRecItems.Clear()
'                Me.SetGridProperties_Receive()
'                Me.lblScanQty.Text = Me._dtRecItems.Rows.Count
'                Me.lblRecQty.Text = 0
'                Me.lblFileQty.Text = 0
'                Me.txtDeviceID.Text = ""
'                Me.txtRecIMEI.Text = ""
'                Me.cmbRecModel.SelectedValue = 0
'                Me.txtWO.Text = ""
'            ElseIf Me._strWOName.Trim.ToLower = Me.txtWO.Text.Trim.ToLower And Me._iWOID > 0 And Me._iTrayID > 0 Then
'                'Do Nothing
'            Else
'                Me._iWOID = 0
'                Me._iTrayID = 0
'                Me._dtRecItems.Clear()
'                Me.SetGridProperties_Receive()
'                Me.lblScanQty.Text = Me._dtRecItems.Rows.Count
'                Me.lblRecQty.Text = 0
'                Me.lblFileQty.Text = 0
'                Me.txtDeviceID.Text = ""
'                Me.txtRecIMEI.Text = ""
'                iFileQty = Me._objDysRec.GetFileQty(Me.txtWO.Text.Trim)
'                If iFileQty = 0 Then
'                    MessageBox.Show("Workorder does not have data file. Please verify with your supervisor.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
'                    Me.txtWO.Text = ""
'                Else
'                    booResult = Me._objDysRec.GetWOIDTrayIDAndRecQty(Me._iMachineGroupID, Me._iUserID, Me._strUserName, Me.txtWO.Text.Trim, Me._iWOID, Me._iTrayID, iRecQty)
'                    If booResult = True Then
'                        Me._strWOName = Me.txtWO.Text.Trim
'                        Me.lblRecQty.Text = iRecQty
'                        Me.lblFileQty.Text = iFileQty
'                        Me.txtWO.Enabled = False
'                        If Me.cmbRecModel.SelectedValue = 0 Then Me.cmbRecModel.Focus() Else Me.txtDeviceID.Focus()
'                    End If
'                End If
'            End If
'        Catch ex As Exception
'            MessageBox.Show(ex.ToString, "txtWO_Leave", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
'        End Try
'    End Sub

'    '**************************************************************
'    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
'        Me._iWOID = 0
'        Me._iTrayID = 0
'        Me._strWOName = ""
'        Me._dtRecItems.Clear()
'        Me.SetGridProperties_Receive()
'        Me.lblScanQty.Text = Me._dtRecItems.Rows.Count
'        Me.lblFileQty.Text = 0
'        Me.lblRecQty.Text = 0
'        Me.txtDeviceID.Text = ""
'        Me.txtRecIMEI.Text = ""
'        Me.cmbRecModel.SelectedValue = 0
'        Me.txtWO.Enabled = True
'        Me.txtWO.Text = ""
'        Me.txtWO.Focus()
'    End Sub

'    '**************************************************************

'End Class
