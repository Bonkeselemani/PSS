
Option Explicit On 

Imports PSS.Data.Production

Public Class frmCostCenterEmpDeptMapping
    Inherits System.Windows.Forms.Form

    Private _objCCTT As CostCenterTimeTracking
    Private _EmpDeptDT As DataTable
    Private _SessionUpdateDT As DataTable
    Private _iLegiantEEData_ID As Integer = 0
    Private _iSessionUpdate As Integer = 0



    Private _UserID As Integer = PSS.Core.Global.ApplicationUser.IDuser

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me._objCCTT = New CostCenterTimeTracking()
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            Try
                Me._objCCTT = Nothing
                Me._EmpDeptDT = Nothing
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
    Friend WithEvents tdgEmp As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents lbEmpDeptDesc As System.Windows.Forms.Label
    Friend WithEvents cboDept As C1.Win.C1List.C1Combo
    Friend WithEvents txtEmpNum As System.Windows.Forms.TextBox
    Friend WithEvents grpBoxAddUpdate As System.Windows.Forms.GroupBox
    Friend WithEvents lblEmpNum As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtMidName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnAddUpdate As System.Windows.Forms.Button
    Friend WithEvents lblLegiantEEData_ID As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCostCenterEmpDeptMapping))
        Me.tdgEmp = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.lbEmpDeptDesc = New System.Windows.Forms.Label()
        Me.cboDept = New C1.Win.C1List.C1Combo()
        Me.txtEmpNum = New System.Windows.Forms.TextBox()
        Me.grpBoxAddUpdate = New System.Windows.Forms.GroupBox()
        Me.btnAddUpdate = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtMidName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.lblEmpNum = New System.Windows.Forms.Label()
        Me.lblLegiantEEData_ID = New System.Windows.Forms.Label()
        CType(Me.tdgEmp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDept, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpBoxAddUpdate.SuspendLayout()
        Me.SuspendLayout()
        '
        'tdgEmp
        '
        Me.tdgEmp.AllowUpdate = False
        Me.tdgEmp.AlternatingRows = True
        Me.tdgEmp.BackColor = System.Drawing.Color.GhostWhite
        Me.tdgEmp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tdgEmp.CaptionHeight = 17
        Me.tdgEmp.FetchRowStyles = True
        Me.tdgEmp.FilterBar = True
        Me.tdgEmp.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tdgEmp.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdgEmp.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.tdgEmp.Location = New System.Drawing.Point(16, 24)
        Me.tdgEmp.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Simple
        Me.tdgEmp.Name = "tdgEmp"
        Me.tdgEmp.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdgEmp.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdgEmp.PreviewInfo.ZoomFactor = 75
        Me.tdgEmp.RowHeight = 15
        Me.tdgEmp.Size = New System.Drawing.Size(888, 256)
        Me.tdgEmp.TabIndex = 143
        Me.tdgEmp.Text = "C1TrueDBGrid1"
        Me.tdgEmp.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
        "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
        "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
        "tion{AlignHorz:Center;}Style9{}Normal{Font:Tahoma, 8.25pt;}HighlightRow{ForeColo" & _
        "r:HighlightText;BackColor:Highlight;}Style12{}OddRow{}RecordSelector{AlignImage:" & _
        "Center;}Style13{}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;Fo" & _
        "reColor:ControlText;BackColor:Control;}Style8{}Style10{AlignHorz:Near;}Style11{}" & _
        "Style14{}Style15{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView" & _
        " Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" " & _
        "ColumnFooterHeight=""17"" FetchRowStyles=""True"" FilterBar=""True"" MarqueeStyle=""Dot" & _
        "tedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=" & _
        """1"" HorizontalScrollGroup=""1""><Height>254</Height><CaptionStyle parent=""Style2"" " & _
        "me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""" & _
        "EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><Footer" & _
        "Style parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><H" & _
        "eadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightR" & _
        "ow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle pa" & _
        "rent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Sty" & _
        "le11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me" & _
        "=""Style1"" /><ClientRect>0, 0, 886, 254</ClientRect><BorderSide>0</BorderSide><Bo" & _
        "rderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedSty" & _
        "les><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style " & _
        "parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style par" & _
        "ent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style pare" & _
        "nt=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style pare" & _
        "nt=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""H" & _
        "eading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style par" & _
        "ent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1" & _
        "</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><Cl" & _
        "ientArea>0, 0, 886, 254</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14""" & _
        " /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
        '
        'lbEmpDeptDesc
        '
        Me.lbEmpDeptDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbEmpDeptDesc.Location = New System.Drawing.Point(16, 5)
        Me.lbEmpDeptDesc.Name = "lbEmpDeptDesc"
        Me.lbEmpDeptDesc.Size = New System.Drawing.Size(688, 24)
        Me.lbEmpDeptDesc.TabIndex = 144
        Me.lbEmpDeptDesc.Text = "Employee Department Data "
        '
        'cboDept
        '
        Me.cboDept.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboDept.AutoCompletion = True
        Me.cboDept.AutoDropDown = True
        Me.cboDept.AutoSelect = True
        Me.cboDept.Caption = ""
        Me.cboDept.CaptionHeight = 17
        Me.cboDept.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboDept.ColumnCaptionHeight = 17
        Me.cboDept.ColumnFooterHeight = 17
        Me.cboDept.ColumnHeaders = False
        Me.cboDept.ContentHeight = 15
        Me.cboDept.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboDept.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboDept.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDept.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboDept.EditorHeight = 15
        Me.cboDept.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDept.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
        Me.cboDept.ItemHeight = 15
        Me.cboDept.Location = New System.Drawing.Point(200, 128)
        Me.cboDept.MatchEntryTimeout = CType(2000, Long)
        Me.cboDept.MaxDropDownItems = CType(10, Short)
        Me.cboDept.MaxLength = 32767
        Me.cboDept.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboDept.Name = "cboDept"
        Me.cboDept.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboDept.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboDept.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboDept.Size = New System.Drawing.Size(256, 21)
        Me.cboDept.TabIndex = 145
        Me.cboDept.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:HotTrack;}Style3{}Inactive{ForeColor:InactiveCaptionText;Bac" & _
        "kColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Microsoft " & _
        "Sans Serif, 9.75pt;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}St" & _
        "yle1{}OddRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:True;BackColor:Cont" & _
        "rol;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}St" & _
        "yle10{}Style11{}Style9{AlignHorz:Near;}</Data></Styles><Splits><C1.Win.C1List.Li" & _
        "stBoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCapt" & _
        "ionHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" HorizontalScrollG" & _
        "roup=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height><VScrollBar>" & _
        "<Width>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScrollBar><Capti" & _
        "onStyle parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7""" & _
        " /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Sty" & _
        "le11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""" & _
        "HighlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddR" & _
        "owStyle parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""RecordSelecto" & _
        "r"" me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><Style parent=""" & _
        "Normal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedStyles><Style p" & _
        "arent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Head" & _
        "ing"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading" & _
        """ me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" " & _
        "me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal""" & _
        " me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Capt" & _
        "ion"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSpl" & _
        "its><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth></Blob>"
        '
        'txtEmpNum
        '
        Me.txtEmpNum.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtEmpNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmpNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmpNum.Location = New System.Drawing.Point(200, 24)
        Me.txtEmpNum.Name = "txtEmpNum"
        Me.txtEmpNum.ReadOnly = True
        Me.txtEmpNum.Size = New System.Drawing.Size(104, 22)
        Me.txtEmpNum.TabIndex = 146
        Me.txtEmpNum.Text = ""
        '
        'grpBoxAddUpdate
        '
        Me.grpBoxAddUpdate.BackColor = System.Drawing.Color.Lavender
        Me.grpBoxAddUpdate.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblLegiantEEData_ID, Me.btnAddUpdate, Me.Label4, Me.Label3, Me.txtMidName, Me.Label2, Me.txtLastName, Me.Label1, Me.txtFirstName, Me.lblEmpNum, Me.txtEmpNum, Me.cboDept})
        Me.grpBoxAddUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpBoxAddUpdate.Location = New System.Drawing.Point(24, 296)
        Me.grpBoxAddUpdate.Name = "grpBoxAddUpdate"
        Me.grpBoxAddUpdate.Size = New System.Drawing.Size(880, 168)
        Me.grpBoxAddUpdate.TabIndex = 147
        Me.grpBoxAddUpdate.TabStop = False
        Me.grpBoxAddUpdate.Text = "Add/Update Emp. Dept. Mapping"
        '
        'btnAddUpdate
        '
        Me.btnAddUpdate.BackColor = System.Drawing.Color.LightSlateGray
        Me.btnAddUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddUpdate.ForeColor = System.Drawing.Color.White
        Me.btnAddUpdate.Image = CType(resources.GetObject("btnAddUpdate.Image"), System.Drawing.Bitmap)
        Me.btnAddUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAddUpdate.Location = New System.Drawing.Point(488, 104)
        Me.btnAddUpdate.Name = "btnAddUpdate"
        Me.btnAddUpdate.Size = New System.Drawing.Size(248, 48)
        Me.btnAddUpdate.TabIndex = 155
        Me.btnAddUpdate.Text = "   Add/Update Map"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(32, 128)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(168, 24)
        Me.Label4.TabIndex = 154
        Me.Label4.Text = "Department:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(24, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(168, 24)
        Me.Label3.TabIndex = 153
        Me.Label3.Text = "Mid Initial/Full Mid Name:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtMidName
        '
        Me.txtMidName.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtMidName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMidName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMidName.Location = New System.Drawing.Point(200, 96)
        Me.txtMidName.Name = "txtMidName"
        Me.txtMidName.ReadOnly = True
        Me.txtMidName.Size = New System.Drawing.Size(256, 22)
        Me.txtMidName.TabIndex = 152
        Me.txtMidName.Text = ""
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(168, 24)
        Me.Label2.TabIndex = 151
        Me.Label2.Text = "Last Name:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtLastName
        '
        Me.txtLastName.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLastName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastName.Location = New System.Drawing.Point(200, 72)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.ReadOnly = True
        Me.txtLastName.Size = New System.Drawing.Size(256, 22)
        Me.txtLastName.TabIndex = 150
        Me.txtLastName.Text = ""
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(168, 24)
        Me.Label1.TabIndex = 149
        Me.Label1.Text = "First Name:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtFirstName
        '
        Me.txtFirstName.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFirstName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFirstName.Location = New System.Drawing.Point(200, 48)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.ReadOnly = True
        Me.txtFirstName.Size = New System.Drawing.Size(256, 22)
        Me.txtFirstName.TabIndex = 148
        Me.txtFirstName.Text = ""
        '
        'lblEmpNum
        '
        Me.lblEmpNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpNum.Location = New System.Drawing.Point(24, 24)
        Me.lblEmpNum.Name = "lblEmpNum"
        Me.lblEmpNum.Size = New System.Drawing.Size(168, 24)
        Me.lblEmpNum.TabIndex = 147
        Me.lblEmpNum.Text = "Employee Number:"
        Me.lblEmpNum.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblLegiantEEData_ID
        '
        Me.lblLegiantEEData_ID.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLegiantEEData_ID.ForeColor = System.Drawing.Color.DarkGray
        Me.lblLegiantEEData_ID.Location = New System.Drawing.Point(816, 10)
        Me.lblLegiantEEData_ID.Name = "lblLegiantEEData_ID"
        Me.lblLegiantEEData_ID.Size = New System.Drawing.Size(56, 16)
        Me.lblLegiantEEData_ID.TabIndex = 156
        Me.lblLegiantEEData_ID.Text = "0"
        Me.lblLegiantEEData_ID.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'frmCostCenterEmpDeptMapping
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(920, 478)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.grpBoxAddUpdate, Me.tdgEmp, Me.lbEmpDeptDesc})
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCostCenterEmpDeptMapping"
        Me.Text = "frmCostCenterEmpDeptMapping"
        CType(Me.tdgEmp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDept, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpBoxAddUpdate.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub frmCostCenterEmpDeptMapping_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As DataTable
        Try
            'Populate department
            'LegiantDeptData_ID, DepartmentID, DepartmentDesc, Active
            dt = Me._objCCTT.getDepartmentData
            dt.LoadDataRow(New Object() {"0", "", "--Select--"}, True)
            Misc.PopulateC1DropDownList(Me.cboDept, dt, "DepartmentDesc", "LegiantDeptData_ID")
            Me.cboDept.SelectedValue = 0

            'Get SessionUpdate table initialization
            Me._SessionUpdateDT = Me._objCCTT.getSessionUpdateDbDef

            'Bind data
            Me.BindEmpDeptData()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "frmCostCenterEmpDeptMapping_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BindEmpDeptData()
        Dim dt As DataTable
        Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
        Dim i As Integer = 0
        Dim row As DataRow
        Dim row2 As DataRow

        Try
            Cursor.Current = Cursors.WaitCursor
            Me.tdgEmp.DataSource = Nothing

            'IsMapped,EmployeeNum,FirstName,LastName,MidIni_MidName,Dept,Map Creator,EmpDeptMapUpdateTime,HireDate,EmpDeptMapUserID,ShiftID
            ',DepartmentID,PayGroupID,EmpKey,EmpID,UpdatedDateTime,LegiantEEData_ID,EENumLegiantFormat,SessionUpdate,LegiantDeptData_ID
            dt = Me._objCCTT.getEmployeeDeptData()

            For Each row In Me._SessionUpdateDT.Rows
                For Each row2 In dt.Rows
                    If row("LegiantEEData_ID") = row2("LegiantEEData_ID") Then
                        row2.BeginEdit() : row2("SessionUpdate") = Me._iSessionUpdate : row2.AcceptChanges()
                        Exit For
                    End If
                Next
            Next
            dt.DefaultView.Sort = "SessionUpdate Desc,IsMapped,FirstName"

            With Me.tdgEmp
                .DataSource = dt.DefaultView

                For Each dbgc In .Splits(0).DisplayColumns
                    dbgc.Locked = True
                    dbgc.AutoSize()
                Next dbgc

                '.Splits(0).DisplayColumns("Sku").Width = 80
                'Col 0 width
                For i = dt.Columns.Count - 1 To 8 Step -1
                    .Splits(0).DisplayColumns(i).Width = 0
                Next
                ' .Splits(0).DisplayColumns("OutboundTrackingNumber").Width = 0

            End With

            Me.lbEmpDeptDesc.Text = "Employee Department Data (" & dt.Rows.Count & ")"

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "BindEmpDeptData", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub tdgEmp_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdgEmp.MouseUp
        Dim iLegiantDeptData_ID As Integer = 0

        Try
            Me._iLegiantEEData_ID = 0 : Me.lblLegiantEEData_ID.Text = "0"

            If Me.tdgEmp.RowCount > 0 Then

                If IsDBNull(tdgEmp.Columns("LegiantEEData_ID").Value) = False Then
                    Me.lblLegiantEEData_ID.Text = tdgEmp.Columns("LegiantEEData_ID").Value
                    Me._iLegiantEEData_ID = tdgEmp.Columns("LegiantEEData_ID").Value
                End If

                If IsDBNull(tdgEmp.Columns("LegiantDeptData_ID").Value) = False Then
                    iLegiantDeptData_ID = tdgEmp.Columns("LegiantDeptData_ID").Value
                End If

                If IsDBNull(tdgEmp.Columns("FirstName").Value) = False Then
                    Me.txtFirstName.Text = tdgEmp.Columns("FirstName").Value
                End If

                If IsDBNull(tdgEmp.Columns("LastName").Value) = False Then
                    Me.txtLastName.Text = tdgEmp.Columns("LastName").Value
                End If

                If IsDBNull(tdgEmp.Columns("MidIni_MidName").Value) = False Then
                    Me.txtMidName.Text = tdgEmp.Columns("MidIni_MidName").Value
                End If

                If IsDBNull(tdgEmp.Columns("EmployeeNum").Value) = False Then
                    Me.txtEmpNum.Text = tdgEmp.Columns("EmployeeNum").Value
                End If


                Me.cboDept.SelectedValue = iLegiantDeptData_ID

            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "tdgEmp_MouseUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAddUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddUpdate.Click

        Dim strDeptID As String = ""
        Dim strDTime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
        Dim i As Integer = 0
        Dim rowNew As DataRow

        Try
            If Me.txtEmpNum.Text.Trim.Length > 0 AndAlso Me.cboDept.SelectedValue > 0 AndAlso Me._iLegiantEEData_ID > 0 Then
                strDeptID = Trim(Me.cboDept.DataSource.Table.Select("LegiantDeptData_ID = " & cboDept.SelectedValue)(0)("DepartmentID"))
                '  MessageBox.Show(strDeptID)
                i = Me._objCCTT.UpdateEmployeeDepartmentMap(Me._iLegiantEEData_ID, strDeptID, Me._UserID, strDTime)
                Me._iSessionUpdate += 1

                rowNew = Me._SessionUpdateDT.NewRow
                rowNew("LegiantEEData_ID") = Me._iLegiantEEData_ID
                rowNew("SessionUpdate") = Me._iSessionUpdate
                Me._SessionUpdateDT.Rows.Add(rowNew)

                Me.txtEmpNum.Text = "" : Me.txtFirstName.Text = "" : Me.txtLastName.Text = ""
                Me.txtMidName.Text = "" : Me.lblLegiantEEData_ID.Text = "0" : Me._iLegiantEEData_ID = 0
                Me.cboDept.SelectedValue = 0

                Me.BindEmpDeptData()

            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnAddUpdate_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
