Public Class frmMachineModelMap
    Inherits System.Windows.Forms.Form
    Private objInventory As PSS.Data.Buisness.Inventory
    Private iProd_ID As Integer = 2

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        objInventory = New PSS.Data.Buisness.Inventory()
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
    Friend WithEvents cmbGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbLine As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbSide As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbMachine As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents cmdRemove As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents cmbModel As System.Windows.Forms.ComboBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdDone As System.Windows.Forms.Button
    Friend WithEvents grdMap As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMachineModelMap))
        Dim GridLines1 As C1.Win.C1TrueDBGrid.Util.GridLines = New C1.Win.C1TrueDBGrid.Util.GridLines()
        Me.cmbGroup = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbLine = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbSide = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbMachine = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmbModel = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.cmdRemove = New System.Windows.Forms.Button()
        Me.cmdDone = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.grdMap = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.grdMap, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbGroup
        '
        Me.cmbGroup.Location = New System.Drawing.Point(91, 20)
        Me.cmbGroup.Name = "cmbGroup"
        Me.cmbGroup.Size = New System.Drawing.Size(160, 21)
        Me.cmbGroup.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(31, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Group:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(31, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 23)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Line:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbLine
        '
        Me.cmbLine.Location = New System.Drawing.Point(91, 52)
        Me.cmbLine.Name = "cmbLine"
        Me.cmbLine.Size = New System.Drawing.Size(160, 21)
        Me.cmbLine.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(3, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 23)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Line Side:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbSide
        '
        Me.cmbSide.Location = New System.Drawing.Point(91, 83)
        Me.cmbSide.Name = "cmbSide"
        Me.cmbSide.Size = New System.Drawing.Size(160, 21)
        Me.cmbSide.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(16, 113)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 23)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Bench:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbMachine
        '
        Me.cmbMachine.Location = New System.Drawing.Point(91, 115)
        Me.cmbMachine.Name = "cmbMachine"
        Me.cmbMachine.Size = New System.Drawing.Size(160, 21)
        Me.cmbMachine.TabIndex = 6
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label4, Me.cmbLine, Me.cmbMachine, Me.cmbGroup, Me.Label1, Me.Label2, Me.cmbSide, Me.Label3})
        Me.Panel1.Location = New System.Drawing.Point(24, 24)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(280, 160)
        Me.Panel1.TabIndex = 8
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmbModel, Me.Label6})
        Me.Panel2.Location = New System.Drawing.Point(24, 192)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(280, 61)
        Me.Panel2.TabIndex = 9
        '
        'cmbModel
        '
        Me.cmbModel.Location = New System.Drawing.Point(91, 20)
        Me.cmbModel.Name = "cmbModel"
        Me.cmbModel.Size = New System.Drawing.Size(160, 21)
        Me.cmbModel.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(31, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 23)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Model:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdAdd
        '
        Me.cmdAdd.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAdd.ForeColor = System.Drawing.Color.White
        Me.cmdAdd.Location = New System.Drawing.Point(88, 271)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(135, 32)
        Me.cmdAdd.TabIndex = 10
        Me.cmdAdd.Text = "Add Model "
        '
        'cmdRemove
        '
        Me.cmdRemove.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdRemove.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRemove.ForeColor = System.Drawing.Color.White
        Me.cmdRemove.Location = New System.Drawing.Point(88, 312)
        Me.cmdRemove.Name = "cmdRemove"
        Me.cmdRemove.Size = New System.Drawing.Size(135, 32)
        Me.cmdRemove.TabIndex = 11
        Me.cmdRemove.Text = "Remove Model "
        '
        'cmdDone
        '
        Me.cmdDone.BackColor = System.Drawing.Color.Navy
        Me.cmdDone.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDone.ForeColor = System.Drawing.Color.White
        Me.cmdDone.Location = New System.Drawing.Point(8, 376)
        Me.cmdDone.Name = "cmdDone"
        Me.cmdDone.Size = New System.Drawing.Size(840, 32)
        Me.cmdDone.TabIndex = 12
        Me.cmdDone.Text = "DONE. NOTIFY PARTS CAGE."
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdAdd, Me.Panel1, Me.Panel2, Me.cmdRemove})
        Me.Panel3.Location = New System.Drawing.Point(8, 7)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(328, 361)
        Me.Panel3.TabIndex = 13
        '
        'grdMap
        '
        Me.grdMap.AllowColMove = False
        Me.grdMap.AllowColSelect = False
        Me.grdMap.AllowFilter = False
        Me.grdMap.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows
        Me.grdMap.AllowSort = False
        Me.grdMap.AlternatingRows = True
        Me.grdMap.BackColor = System.Drawing.Color.SteelBlue
        Me.grdMap.CaptionHeight = 17
        Me.grdMap.CollapseColor = System.Drawing.Color.Black
        Me.grdMap.DataChanged = False
        Me.grdMap.BackColor = System.Drawing.Color.Empty
        Me.grdMap.ExpandColor = System.Drawing.Color.Black
        Me.grdMap.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdMap.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdMap.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.grdMap.Location = New System.Drawing.Point(7, 27)
        Me.grdMap.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
        Me.grdMap.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.grdMap.Name = "grdMap"
        Me.grdMap.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdMap.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdMap.PreviewInfo.ZoomFactor = 75
        Me.grdMap.PrintInfo.ShowOptionsDialog = False
        Me.grdMap.RecordSelectorWidth = 16
        GridLines1.Color = System.Drawing.Color.DarkGray
        GridLines1.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single
        Me.grdMap.RowDivider = GridLines1
        Me.grdMap.RowHeight = 20
        Me.grdMap.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.grdMap.ScrollTips = False
        Me.grdMap.Size = New System.Drawing.Size(489, 325)
        Me.grdMap.TabIndex = 14
        Me.grdMap.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
        "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
        "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
        "er;}Normal{Font:Microsoft Sans Serif, 8.25pt;AlignVert:Center;BackColor:SteelBlu" & _
        "e;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style1{}OddRow{Back" & _
        "Color:Control;}RecordSelector{AlignImage:Center;}Heading{Wrap:True;Font:Microsof" & _
        "t Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;AlignVert:Center;Border:Raised" & _
        ",,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{AlignHorz:" & _
        "Near;}Style11{}Style12{}Style13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueD" & _
        "BGrid.MergeView AllowColMove=""False"" AllowColSelect=""False"" Name="""" AlternatingR" & _
        "owStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""1" & _
        "7"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefRecSelWidth=""16"" " & _
        "VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 485, 321</Cl" & _
        "ientRect><BorderSide>0</BorderSide><CaptionStyle parent=""Style2"" me=""Style10"" />" & _
        "<EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""St" & _
        "yle8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""F" & _
        "ooter"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle par" & _
        "ent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7""" & _
        " /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" m" & _
        "e=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><Select" & _
        "edStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /></C" & _
        "1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" " & _
        "/><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><S" & _
        "tyle parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><St" & _
        "yle parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style " & _
        "parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style" & _
        " parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><St" & _
        "yle parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></Name" & _
        "dStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout" & _
        "><DefaultRecSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 485, 321</ClientAr" & _
        "ea></Blob>"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel4.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label5, Me.grdMap})
        Me.Panel4.Location = New System.Drawing.Point(344, 7)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(504, 361)
        Me.Panel4.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(5, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(240, 23)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Existing Bench to Model Mapping:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmMachineModelMap
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(912, 420)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel4, Me.Panel3, Me.cmdDone})
        Me.Name = "frmMachineModelMap"
        Me.Text = "Assign Models to Machines"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.grdMap, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Protected Overrides Sub Finalize()
        objInventory = Nothing
        MyBase.Finalize()
    End Sub
    '****************************************************
    Private Sub frmMachineModelMap_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            LoadGroups()
            'LoadAllLines()
            'LoadAllSides()
            'LoadAllMachines()
            LoadAllModels()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "frmMachineModelMap_Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '****************************************************
    Private Sub LoadAllModels()

        Dim dtModels As DataTable

        Try
            dtModels = Me.objInventory.GetModels(iProd_ID, 1)
            Me.cmbModel.DataSource = dtModels.DefaultView
            Me.cmbModel.ValueMember = dtModels.Columns("Model_ID").ToString
            Me.cmbModel.DisplayMember = dtModels.Columns("Model").ToString
            Me.cmbModel.SelectedValue = 0

        Catch ex As Exception
            Throw New Exception("LoadAllModels:: " & ex.Message.ToString)
        Finally
            If Not IsNothing(dtModels) Then
                dtModels.Dispose()
                dtModels = Nothing
            End If
        End Try
    End Sub

    '****************************************************
    Private Sub LoadGroups()

        Dim dtGroups As DataTable

        Try
            dtGroups = Me.objInventory.GetGroups(1)
            Me.cmbGroup.DataSource = dtGroups.DefaultView
            Me.cmbGroup.ValueMember = dtGroups.Columns("Group_ID").ToString
            Me.cmbGroup.DisplayMember = dtGroups.Columns("Group").ToString
            Me.cmbGroup.SelectedValue = 0

        Catch ex As Exception
            Throw New Exception("LoadGroups:: " & ex.Message.ToString)
        Finally
            If Not IsNothing(dtGroups) Then
                dtGroups.Dispose()
                dtGroups = Nothing
            End If
        End Try
    End Sub
    '****************************************************
    'Load all lines
    '****************************************************
    Private Sub LoadAllLines()
        Dim dtLines As DataTable

        Try
            dtLines = Me.objInventory.GetLines(Me.cmbGroup.SelectedValue, 1)
            'Me.cmbLine.Items.Clear()
            Me.cmbLine.DataSource = dtLines.DefaultView
            Me.cmbLine.ValueMember = dtLines.Columns("Line_ID").ToString
            Me.cmbLine.DisplayMember = dtLines.Columns("Line").ToString
            Me.cmbLine.SelectedValue = 0

        Catch ex As Exception
            Throw New Exception("LoadAllLines:: " & ex.Message.ToString)
        Finally
            If Not IsNothing(dtLines) Then
                dtLines.Dispose()
                dtLines = Nothing
            End If
        End Try
    End Sub
    '****************************************************
    Private Sub LoadAllSides()
        Dim dtSides As DataTable
        Try
            dtSides = Me.objInventory.GetLineSides(Me.cmbLine.SelectedValue, 1)
            'Me.cmbSide.Items.Clear()
            Me.cmbSide.DataSource = dtSides.DefaultView
            Me.cmbSide.ValueMember = dtSides.Columns("LineSide_ID").ToString
            Me.cmbSide.DisplayMember = dtSides.Columns("Line Side").ToString
            Me.cmbSide.SelectedValue = 0

        Catch ex As Exception
            Throw New Exception("LoadAllSides:: " & ex.Message.ToString)
        Finally
            If Not IsNothing(dtSides) Then
                dtSides.Dispose()
                dtSides = Nothing
            End If
        End Try
    End Sub
    '****************************************************
    Private Sub LoadAllMachines()
        Dim dtMachines As DataTable

        Try
            dtMachines = Me.objInventory.GetMachines(Me.cmbGroup.SelectedValue, _
                                                    Me.cmbLine.SelectedValue, _
                                                    Me.cmbSide.SelectedValue, _
                                                    1, _
                                                    1)

            Me.cmbMachine.DataSource = dtMachines.DefaultView
            Me.cmbMachine.ValueMember = dtMachines.Columns("wclocation_ID").ToString
            Me.cmbMachine.DisplayMember = dtMachines.Columns("Bin").ToString
            Me.cmbMachine.SelectedValue = 0

        Catch ex As Exception
            Throw New Exception("LoadAllMachines:: " & ex.Message.ToString)
        Finally
            If Not IsNothing(dtMachines) Then
                dtMachines.Dispose()
                dtMachines = Nothing
            End If
        End Try
    End Sub
    '****************************************************

    Private Sub cmbGroup_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGroup.SelectionChangeCommitted
        Me.cmbLine.SelectedValue = 0
        Me.cmbSide.SelectedValue = 0
        Me.cmbMachine.SelectedValue = 0
        'Me.grdMap.ClearFields()
        'If Me.cmbGroup.SelectedValue > 0 Then
        LoadAllLines()
        LoadAllMachines()
        LoadAllMachineModelMappings()
        'End If

    End Sub

    Private Sub cmbLine_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLine.SelectionChangeCommitted
        Me.cmbSide.SelectedValue = 0
        Me.cmbMachine.SelectedValue = 0
        'Me.grdMap.ClearFields()
        'If Me.cmbLine.SelectedValue > 0 Then
        LoadAllSides()
        LoadAllMachines()
        LoadAllMachineModelMappings()
        'End If

    End Sub

    Private Sub cmbSide_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSide.SelectionChangeCommitted
        Me.cmbMachine.SelectedValue = 0
        'Me.grdMap.ClearFields()
        'If Me.cmbSide.SelectedValue > 0 Then
        LoadAllMachines()
        LoadAllMachineModelMappings()
        'End If
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Dim i As Integer = 0

        If Me.cmbMachine.SelectedValue = 0 And Me.cmbSide.SelectedValue = 0 And Me.cmbLine.SelectedValue = 0 And Me.cmbGroup.SelectedValue = 0 Then
            Throw New Exception("Please select a 'Group' or 'Line' or 'Line Side' or 'Machine'.")
        End If
        If Me.cmbModel.SelectedValue = 0 Then
            Throw New Exception("Please select a 'Model'.")
        End If

        Try
            i = Me.objInventory.AssignModelToMachine(Me.cmbMachine.SelectedValue, _
                                        Me.cmbSide.SelectedValue, _
                                        Me.cmbLine.SelectedValue, _
                                        Me.cmbGroup.SelectedValue, _
                                        Me.cmbModel.SelectedValue, _
                                        1)

            LoadAllMachineModelMappings()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "cmdAdd_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try


    End Sub

    Private Sub LoadAllMachineModelMappings()
        Dim dtMap As DataTable

        Try
            dtMap = Me.objInventory.GetAllMachineModelMappings(Me.cmbGroup.SelectedValue, _
                                                                Me.cmbLine.SelectedValue, _
                                                                Me.cmbSide.SelectedValue, _
                                                                Me.cmbMachine.SelectedValue)
            Me.grdMap.ClearFields()
            If dtMap.Rows.Count > 0 Then

                Me.grdMap.DataSource = dtMap.DefaultView
                SetgrdMapProperties()
            End If
        Catch ex As Exception
            Throw New Exception("LoadAllMachineModelMappings:: " & ex.Message.ToString)
        Finally
            If Not IsNothing(dtMap) Then
                dtMap.Dispose()
                dtMap = Nothing
            End If
        End Try
    End Sub

    Private Sub Asif()
        With Me.grdMap
            Dim x As String = .Splits(0).DisplayColumns(1).Width
            MsgBox(x)
        End With
        With Me.grdMap
            Dim x As String = .Splits(0).DisplayColumns(2).Width
            MsgBox(x)
        End With
        With Me.grdMap
            Dim x As String = .Splits(0).DisplayColumns(3).Width
            MsgBox(x)
        End With
        With Me.grdMap
            Dim x As String = .Splits(0).DisplayColumns(4).Width
            MsgBox(x)
        End With
        With Me.grdMap
            Dim x As String = .Splits(0).DisplayColumns(5).Width
            MsgBox(x)
        End With
        With Me.grdMap
            Dim x As String = .Splits(0).DisplayColumns(6).Width
            MsgBox(x)
        End With

    End Sub

    Private Sub SetgrdMapProperties()
        Dim iNumOfColumns As Integer = Me.grdMap.Columns.Count
        Dim i As Integer

        With Me.grdMap
            'Heading style (Horizontal Alignment to Center)
            For i = 0 To (iNumOfColumns - 1)
                .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Next

            'Set individual column data horizontal alignment
            .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            .Splits(0).DisplayColumns(3).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            .Splits(0).DisplayColumns(4).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            .Splits(0).DisplayColumns(5).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            .Splits(0).DisplayColumns(6).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General

            'Set Column Widths
            .Splits(0).DisplayColumns(1).Width = 80
            .Splits(0).DisplayColumns(2).Width = 50
            .Splits(0).DisplayColumns(3).Width = 50
            .Splits(0).DisplayColumns(4).Width = 78
            .Splits(0).DisplayColumns(5).Width = 66
            .Splits(0).DisplayColumns(6).Width = 117

            'Make some columns invisible
            .Splits(0).DisplayColumns(0).Visible = False

        End With
    End Sub

    Private Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemove.Click

        Dim i As Integer = 0

        If Me.cmbMachine.SelectedValue = 0 And Me.cmbSide.SelectedValue = 0 And Me.cmbLine.SelectedValue = 0 And Me.cmbGroup.SelectedValue = 0 Then
            MessageBox.Show("Please select a 'Group' or 'Line' or 'Line Side' or 'Machine'.")
            Exit Sub
        End If
        If Me.cmbModel.SelectedValue = 0 Then
            MessageBox.Show("Please select a 'Model'.")
            Exit Sub
        End If

        Try
            i = Me.objInventory.AssignModelToMachine(Me.cmbMachine.SelectedValue, _
                                        Me.cmbSide.SelectedValue, _
                                        Me.cmbLine.SelectedValue, _
                                        Me.cmbGroup.SelectedValue, _
                                        Me.cmbModel.SelectedValue, _
                                        -1)

            MessageBox.Show("This model has been marked to be removed. It will be removed from the screen when you click the 'DONE NOTIFY PARTS CAGE' button.", "Remove Model", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            'LoadAllMachineModelMappings()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "cmdRemove_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub cmbMachine_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMachine.SelectionChangeCommitted
        LoadAllMachineModelMappings()
    End Sub

    Private Sub cmdDone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDone.Click
        Dim i As Integer = 0
        Dim StrCurDtTime As String = Format(Now(), "yyyy-MM-dd HH:mm:ss")
        Try
            If Me.cmbGroup.SelectedValue = 0 Then
                Throw New Exception("Please select a 'Group'")
            End If
            i = Me.objInventory.NotifyModelChangeToPartsCage(Me.cmbGroup.SelectedValue, StrCurDtTime)
            If i > 0 Then
                MessageBox.Show("Parts cage has been notified of the changes.", "Parts Cage Notification", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                'LoadAllMachineModelMappings()
            Else
                MessageBox.Show("No new changes were found hence parts cage is not notified.", "Parts Cage Notification", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
            LoadAllMachineModelMappings()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "cmdRemove_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub grdMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdMap.Click
        Try
            'i = Me.objInventory.GetMachineModelMapInfo()


        Catch ex As Exception

        End Try
    End Sub
End Class
