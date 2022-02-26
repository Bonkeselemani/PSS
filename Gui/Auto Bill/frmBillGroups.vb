Option Explicit On 

Public Class frmBillGroups
    Inherits System.Windows.Forms.Form

    Private objAutoBill As PSS.Data.Buisness.AutoBill

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        objAutoBill = New PSS.Data.Buisness.AutoBill()

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
    Friend WithEvents cmdLoadFile As System.Windows.Forms.Button
    Friend WithEvents cmbCustomer As PSS.Gui.Controls.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbModel As PSS.Gui.Controls.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdAddUpdate As System.Windows.Forms.Button
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents RadioHigh As System.Windows.Forms.RadioButton
    Friend WithEvents RadioLow As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents RadioBillLevel As System.Windows.Forms.RadioButton
    Friend WithEvents RadioBillGroup As System.Windows.Forms.RadioButton
    Friend WithEvents PanelBillGroup As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PanelBillLevel As System.Windows.Forms.Panel
    Friend WithEvents dgBill As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents cmdUploadBillLevels As System.Windows.Forms.Button
    Friend WithEvents cmdDeleteBillLevel As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmBillGroups))
        Me.PanelBillLevel = New System.Windows.Forms.Panel()
        Me.cmdDeleteBillLevel = New System.Windows.Forms.Button()
        Me.cmdUploadBillLevels = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.RadioLow = New System.Windows.Forms.RadioButton()
        Me.RadioHigh = New System.Windows.Forms.RadioButton()
        Me.cmdAddUpdate = New System.Windows.Forms.Button()
        Me.cmbModel = New PSS.Gui.Controls.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbCustomer = New PSS.Gui.Controls.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdLoadFile = New System.Windows.Forms.Button()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.dgBill = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.RadioBillLevel = New System.Windows.Forms.RadioButton()
        Me.RadioBillGroup = New System.Windows.Forms.RadioButton()
        Me.PanelBillGroup = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PanelBillLevel.SuspendLayout()
        CType(Me.dgBill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBillGroup.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelBillLevel
        '
        Me.PanelBillLevel.BackColor = System.Drawing.Color.LightSteelBlue
        Me.PanelBillLevel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelBillLevel.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdDeleteBillLevel, Me.cmdUploadBillLevels, Me.Label3, Me.RadioLow, Me.RadioHigh, Me.cmdAddUpdate, Me.cmbModel, Me.Label2, Me.cmbCustomer, Me.Label1})
        Me.PanelBillLevel.Location = New System.Drawing.Point(3, 193)
        Me.PanelBillLevel.Name = "PanelBillLevel"
        Me.PanelBillLevel.Size = New System.Drawing.Size(226, 272)
        Me.PanelBillLevel.TabIndex = 0
        Me.PanelBillLevel.Visible = False
        '
        'cmdDeleteBillLevel
        '
        Me.cmdDeleteBillLevel.BackColor = System.Drawing.Color.Red
        Me.cmdDeleteBillLevel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDeleteBillLevel.ForeColor = System.Drawing.Color.Black
        Me.cmdDeleteBillLevel.Location = New System.Drawing.Point(48, 176)
        Me.cmdDeleteBillLevel.Name = "cmdDeleteBillLevel"
        Me.cmdDeleteBillLevel.Size = New System.Drawing.Size(120, 24)
        Me.cmdDeleteBillLevel.TabIndex = 20
        Me.cmdDeleteBillLevel.Text = "DELETE"
        '
        'cmdUploadBillLevels
        '
        Me.cmdUploadBillLevels.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdUploadBillLevels.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUploadBillLevels.ForeColor = System.Drawing.Color.White
        Me.cmdUploadBillLevels.Location = New System.Drawing.Point(32, 216)
        Me.cmdUploadBillLevels.Name = "cmdUploadBillLevels"
        Me.cmdUploadBillLevels.Size = New System.Drawing.Size(152, 40)
        Me.cmdUploadBillLevels.TabIndex = 19
        Me.cmdUploadBillLevels.Text = "Upload Bill Levels with Excel File"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(8, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(160, 16)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Set Bill Levels for Models"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RadioLow
        '
        Me.RadioLow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioLow.Location = New System.Drawing.Point(112, 112)
        Me.RadioLow.Name = "RadioLow"
        Me.RadioLow.Size = New System.Drawing.Size(91, 24)
        Me.RadioLow.TabIndex = 17
        Me.RadioLow.Text = "Bill Low"
        '
        'RadioHigh
        '
        Me.RadioHigh.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioHigh.Location = New System.Drawing.Point(8, 112)
        Me.RadioHigh.Name = "RadioHigh"
        Me.RadioHigh.Size = New System.Drawing.Size(91, 24)
        Me.RadioHigh.TabIndex = 16
        Me.RadioHigh.Text = "Bill High"
        '
        'cmdAddUpdate
        '
        Me.cmdAddUpdate.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdAddUpdate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAddUpdate.ForeColor = System.Drawing.Color.White
        Me.cmdAddUpdate.Location = New System.Drawing.Point(48, 144)
        Me.cmdAddUpdate.Name = "cmdAddUpdate"
        Me.cmdAddUpdate.Size = New System.Drawing.Size(120, 24)
        Me.cmdAddUpdate.TabIndex = 14
        Me.cmdAddUpdate.Text = "ADD/UPDATE"
        '
        'cmbModel
        '
        Me.cmbModel.AutoComplete = True
        Me.cmbModel.BackColor = System.Drawing.SystemColors.Window
        Me.cmbModel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbModel.ForeColor = System.Drawing.Color.Black
        Me.cmbModel.Location = New System.Drawing.Point(7, 88)
        Me.cmbModel.Name = "cmbModel"
        Me.cmbModel.Size = New System.Drawing.Size(196, 21)
        Me.cmbModel.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(7, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 16)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Model:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbCustomer
        '
        Me.cmbCustomer.AutoComplete = True
        Me.cmbCustomer.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCustomer.ForeColor = System.Drawing.Color.Black
        Me.cmbCustomer.Location = New System.Drawing.Point(8, 48)
        Me.cmbCustomer.Name = "cmbCustomer"
        Me.cmbCustomer.Size = New System.Drawing.Size(196, 21)
        Me.cmbCustomer.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(8, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Customer:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdLoadFile
        '
        Me.cmdLoadFile.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdLoadFile.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLoadFile.ForeColor = System.Drawing.Color.White
        Me.cmdLoadFile.Location = New System.Drawing.Point(8, 32)
        Me.cmdLoadFile.Name = "cmdLoadFile"
        Me.cmdLoadFile.Size = New System.Drawing.Size(208, 32)
        Me.cmdLoadFile.TabIndex = 1
        Me.cmdLoadFile.Text = "LOAD BILL GROUPS BY FILE"
        '
        'cmdDelete
        '
        Me.cmdDelete.BackColor = System.Drawing.Color.Red
        Me.cmdDelete.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelete.ForeColor = System.Drawing.Color.Black
        Me.cmdDelete.Location = New System.Drawing.Point(8, 72)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(200, 32)
        Me.cmdDelete.TabIndex = 2
        Me.cmdDelete.Text = "INACTIVATE A LOAD"
        '
        'lblHeader
        '
        Me.lblHeader.BackColor = System.Drawing.Color.Black
        Me.lblHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.ForeColor = System.Drawing.Color.Yellow
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(232, 39)
        Me.lblHeader.TabIndex = 11
        Me.lblHeader.Text = "BILL GROUPS"
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgBill
        '
        Me.dgBill.AllowColMove = False
        Me.dgBill.AllowColSelect = False
        Me.dgBill.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.dgBill.AllowSort = False
        Me.dgBill.AllowUpdate = False
        Me.dgBill.AllowUpdateOnBlur = False
        Me.dgBill.AlternatingRows = True
        Me.dgBill.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgBill.FilterBar = True
        Me.dgBill.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgBill.GroupByCaption = "Drag a column header here to group by that column"
        Me.dgBill.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.dgBill.Location = New System.Drawing.Point(232, 0)
        Me.dgBill.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.dgBill.Name = "dgBill"
        Me.dgBill.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dgBill.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dgBill.PreviewInfo.ZoomFactor = 75
        Me.dgBill.RowHeight = 20
        Me.dgBill.Size = New System.Drawing.Size(780, 464)
        Me.dgBill.TabIndex = 3
        Me.dgBill.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{ForeColor:White;BackColor" & _
        ":SteelBlue;}Selected{ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inacti" & _
        "ve{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{BackColor:" & _
        "White;}Footer{}Caption{AlignHorz:Center;}Style1{}Normal{Font:Arial, 9pt, style=B" & _
        "old;AlignVert:Center;BackColor:SteelBlue;}HighlightRow{ForeColor:HighlightText;B" & _
        "ackColor:Highlight;}Style14{}OddRow{BackColor:LightSteelBlue;}RecordSelector{Ali" & _
        "gnImage:Center;}Style15{}Heading{Wrap:True;Font:Microsoft Sans Serif, 8.25pt, st" & _
        "yle=Bold;AlignHorz:Center;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:C" & _
        "ontrolText;BackColor:Control;}Style8{}Style10{AlignHorz:Near;}Style11{}Style12{}" & _
        "Style13{}Style16{}Style17{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid." & _
        "MergeView AllowColMove=""False"" AllowColSelect=""False"" Name="""" AllowRowSizing=""No" & _
        "ne"" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" Colum" & _
        "nFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelect" & _
        "orWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""" & _
        "1""><Height>460</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle" & _
        " parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><Fil" & _
        "terBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""S" & _
        "tyle3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading" & _
        """ me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><Inactive" & _
        "Style parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /" & _
        "><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle pare" & _
        "nt=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, " & _
        "0, 776, 460</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderSty" & _
        "le></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""No" & _
        "rmal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer" & _
        """ /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive""" & _
        " /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><" & _
        "Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" />" & _
        "<Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector""" & _
        " /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" />" & _
        "</NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</" & _
        "Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 776, 460</Cl" & _
        "ientArea><PrintPageHeaderStyle parent="""" me=""Style16"" /><PrintPageFooterStyle pa" & _
        "rent="""" me=""Style17"" /></Blob>"
        '
        'RadioBillLevel
        '
        Me.RadioBillLevel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioBillLevel.ForeColor = System.Drawing.Color.White
        Me.RadioBillLevel.Location = New System.Drawing.Point(120, 48)
        Me.RadioBillLevel.Name = "RadioBillLevel"
        Me.RadioBillLevel.Size = New System.Drawing.Size(91, 24)
        Me.RadioBillLevel.TabIndex = 19
        Me.RadioBillLevel.Text = "Bill Level"
        '
        'RadioBillGroup
        '
        Me.RadioBillGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioBillGroup.ForeColor = System.Drawing.Color.White
        Me.RadioBillGroup.Location = New System.Drawing.Point(16, 48)
        Me.RadioBillGroup.Name = "RadioBillGroup"
        Me.RadioBillGroup.Size = New System.Drawing.Size(91, 24)
        Me.RadioBillGroup.TabIndex = 18
        Me.RadioBillGroup.Text = "Bill Group"
        '
        'PanelBillGroup
        '
        Me.PanelBillGroup.BackColor = System.Drawing.Color.LightSteelBlue
        Me.PanelBillGroup.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelBillGroup.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label4, Me.cmdDelete, Me.cmdLoadFile})
        Me.PanelBillGroup.Location = New System.Drawing.Point(3, 76)
        Me.PanelBillGroup.Name = "PanelBillGroup"
        Me.PanelBillGroup.Size = New System.Drawing.Size(226, 116)
        Me.PanelBillGroup.TabIndex = 20
        Me.PanelBillGroup.Visible = False
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(8, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(160, 16)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Upload Bill Groups"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmBillGroups
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(1028, 517)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.PanelBillGroup, Me.RadioBillLevel, Me.RadioBillGroup, Me.dgBill, Me.lblHeader, Me.PanelBillLevel})
        Me.Name = "frmBillGroups"
        Me.Text = "Bill Groups"
        Me.PanelBillLevel.ResumeLayout(False)
        CType(Me.dgBill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBillGroup.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        objAutoBill = Nothing
    End Sub

    '*********************************************************
    Private Sub frmBillGroups_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim objGen As New PSS.Data.Buisness.Generic()

        Try
            '*********************************************
            'Load customer of cell product only
            '*********************************************
            objGen.LoadCustomers(Me.cmbCustomer, 2)
            '*********************************************
            'Load auto-bill model of cell product only
            '*********************************************
            objGen.LoadModels(Me.cmbModel, 2, 1)
            '*********************************************************
            'by default display Billgroup option when the form loaded 
            '*********************************************************
            Me.RadioBillGroup.Checked = True
            Me.PanelBillGroup.Visible = True

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            objGen = Nothing
        End Try
    End Sub

    '*********************************************************
    Private Sub cmdLoadFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoadFile.Click
        Dim strFilePath As String = ""
        Dim i As Integer = 0

        Try
            Me.Enabled = False

            '********************************************************************************************************************
            Me.OpenFileDialog1.DefaultExt = "xls"
            Me.OpenFileDialog1.FilterIndex = 1
            Me.OpenFileDialog1.FileName = "*.xls"
            Me.OpenFileDialog1.ShowDialog()
            If Len(Trim(Me.OpenFileDialog1.FileName)) > 0 Then
                If LCase(Microsoft.VisualBasic.Right(Trim(Me.OpenFileDialog1.FileName), 3)) <> "xls" Then
                    MessageBox.Show("Incorrect file extension. It must be ""XLS"".", "File Extension", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
                strFilePath = Trim(Me.OpenFileDialog1.FileName)

            Else
                MessageBox.Show("Please select a file.", "Select File", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            '********************************************************************************************************************
            i = Me.objAutoBill.UploadBillGroups(strFilePath)

            If i > 0 Then
                MessageBox.Show("Load Completed.", "Load File", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

            Me.LoadBillDataGrid()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Load File", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
        End Try
    End Sub

    '*********************************************************
    Private Sub LoadBillDataGrid()
        Dim dt1 As DataTable

        Try
            Me.dgBill.DataSource = Nothing

            If Me.RadioBillGroup.Checked = True Then
                dt1 = Me.objAutoBill.GetBillGroups
            Else
                dt1 = Me.objAutoBill.GetBillLevels
            End If

            If dt1.Rows.Count > 0 Then
                Me.dgBill.Visible = True
                Me.dgBill.DataSource = dt1.DefaultView
                Me.SetGridProperties()
            Else
                Me.dgBill.Visible = False
            End If
        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
        End Try
    End Sub

    '*********************************************************
    Private Sub SetGridProperties()
        Dim iNumOfColumns As Integer = Me.dgBill.Columns.Count
        Dim i As Integer

        Try
            With Me.dgBill
                'Heading style (Horizontal Alignment to Center)
                For i = 0 To (iNumOfColumns - 1)
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                Next

                If Me.RadioBillGroup.Checked = True Then
                    'Set individual column data horizontal alignment
                    .Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    .Splits(0).DisplayColumns(5).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                    'Set Column Widths
                    .Splits(0).DisplayColumns(0).Width = 90         'LoadNumber
                    .Splits(0).DisplayColumns(1).Width = 100        'Customer_name
                    .Splits(0).DisplayColumns(2).Width = 100        'Model desc
                    .Splits(0).DisplayColumns(3).Width = 90         'Enterprise
                    .Splits(0).DisplayColumns(4).Width = 100        'BillGroup
                    .Splits(0).DisplayColumns(5).Width = 90         'BillLevel
                    .Splits(0).DisplayColumns(6).Width = 160        'BillCode Desc


                    'Make some columns invisible
                    .Splits(0).DisplayColumns(7).Visible = False    'bg_id
                    .Splits(0).DisplayColumns(8).Visible = False    'bg_cust_id
                    .Splits(0).DisplayColumns(9).Visible = False    'bg_model_id
                    .Splits(0).DisplayColumns(10).Visible = False   'billcode_id
                    .Width = 780
                Else
                    'Set individual column data horizontal alignment
                    .Splits(0).DisplayColumns("LaborLevel").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                    'Set Column Widths
                    .Splits(0).DisplayColumns("Customer").Width = 100           'Cust_Name1
                    .Splits(0).DisplayColumns("Model").Width = 120              'Model_Desc
                    .Splits(0).DisplayColumns("LaborLevel").Width = 80          'mbl_level

                    'Make some columns invisible
                    .Splits(0).DisplayColumns("mbl_id").Visible = False         'mbl_id
                    .Splits(0).DisplayColumns("mbl_cust_id").Visible = False    'mbl_cust_id
                    .Splits(0).DisplayColumns("mbl_model_id").Visible = False   'mbl_model_id
                    .Width = 340
                End If

                .Height = 610
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '*********************************************************
    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        Dim i As Integer = 0
        Dim iLoadNum As Integer = 0

        Try
            Me.Enabled = False

            iLoadNum = InputBox("Please enter Load Number:", "Get Load Number")

            i = Me.objAutoBill.InactivateBillGroupByLoadNo(iLoadNum)

            If i > 0 Then
                MessageBox.Show("Delete completed.", "Delete Bill Group", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

            Me.LoadBillDataGrid()

        Catch ex1 As InvalidCastException
            MessageBox.Show("Load Number must be a numeric. Not deleted.", "Get Load Number", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Delete Bill Group", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
        End Try
    End Sub

    '*********************************************************
    Private Sub RadioBillLevel_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioBillLevel.CheckedChanged
        Try
            If Me.RadioBillLevel.Checked = True Then
                '***********************************
                'Get BillLevel
                '***********************************
                LoadBillDataGrid()
                '***********************************
                Me.PanelBillLevel.Visible = True
                Me.PanelBillGroup.Visible = False
                Me.lblHeader.Text = "BILL LEVELS"
                Me.cmbCustomer.SelectedValue = 2113 'by default select cellstart customer
                Me.cmbModel.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Select Bill Level Option", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*********************************************************
    Private Sub RadioBillGroup_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioBillGroup.CheckedChanged
        Try
            If Me.RadioBillGroup.Checked = True Then
                '***********************************
                'Get BillLevel
                '***********************************
                LoadBillDataGrid()
                '***********************************
                Me.PanelBillGroup.Visible = True
                Me.PanelBillLevel.Visible = False
                Me.lblHeader.Text = "BILL GROUPS"
                Me.cmbCustomer.SelectedValue = 0
                Me.cmbModel.SelectedValue = 0
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Select Bill Group Option", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*********************************************************
    Private Sub dgBill_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles dgBill.RowColChange

        Try
            If Me.RadioBillLevel.Checked = True Then
                If Me.dgBill.Columns.Count = 0 Then
                    Exit Sub
                End If

                Me.cmbCustomer.SelectedValue = Me.dgBill.Columns("mbl_cust_id").Value
                Me.cmbModel.SelectedValue = Me.dgBill.Columns("mbl_model_id").Value
                If Me.dgBill.Columns("LaborLevel").Value = 1 Then
                    Me.RadioLow.Checked = True
                ElseIf Me.dgBill.Columns("LaborLevel").Value = 2 Then
                    Me.RadioHigh.Checked = True
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Row Colunm Change Event", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*********************************************************
    Private Sub cmdAddUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddUpdate.Click
        Dim i As Integer = 0
        Dim iHighLow As Integer = 0

        Try
            If Me.cmbCustomer.SelectedValue = 0 Then
                MessageBox.Show("Please select Customer.", "Add/Update Bill Level", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.cmbCustomer.Focus()
                Exit Sub
            End If
            If Me.cmbModel.SelectedValue = 0 Then
                MessageBox.Show("Please select Model.", "Add/Update Bill Level", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.cmbModel.Focus()
                Exit Sub
            End If

            If Me.RadioHigh.Checked = True Then
                iHighLow = 2
            ElseIf Me.RadioLow.Checked = True Then
                iHighLow = 1
            Else
                MessageBox.Show("Please select Bill Level.", "Add/Update Bill Level", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.RadioHigh.Focus()
                Exit Sub
            End If

            '**********************************
            'Update bill level
            '**********************************
            i = Me.objAutoBill.UpdateBillLevel(Me.cmbCustomer.SelectedValue, _
                                               Me.cmbModel.SelectedValue, _
                                               iHighLow)

            If i > 0 Then
                MessageBox.Show("Update completed.", "Add/Update Bill Level", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

            Me.LoadBillDataGrid()
            Me.cmbCustomer.SelectedValue = 0
            Me.cmbModel.SelectedValue = 0
            Me.RadioHigh.Checked = False
            Me.RadioLow.Checked = False
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Add/Update Bill Level", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*********************************************************
    Private Sub cmdDeleteBillLevel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteBillLevel.Click
        Dim i As Integer = 0

        Try
            If Me.dgBill.Columns.Count = 0 Then
                Exit Sub
            End If
            If Me.dgBill.Columns("mbl_id").Value = 0 Then
                MessageBox.Show("Please select a row to be delete.", "Delete a Bill Level", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            i = Me.objAutoBill.DeleteBillLevel(Me.dgBill.Columns("mbl_id").Value)

            If i > 0 Then
                MessageBox.Show("Delete completed.", "Delete Bill Level", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

            Me.LoadBillDataGrid()
            Me.cmbCustomer.SelectedValue = 0
            Me.cmbModel.SelectedValue = 0
            Me.RadioHigh.Checked = False
            Me.RadioLow.Checked = False
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Delete Bill Level", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*********************************************************
    Private Sub cmdUploadBillLevels_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUploadBillLevels.Click
        Dim strFilePath As String = ""
        Dim i As Integer = 0

        Try
            Me.Enabled = False

            '********************************************************************************************************************
            Me.OpenFileDialog1.DefaultExt = "xls"
            Me.OpenFileDialog1.FilterIndex = 1
            Me.OpenFileDialog1.FileName = "*.xls"
            Me.OpenFileDialog1.ShowDialog()
            If Len(Trim(Me.OpenFileDialog1.FileName)) > 0 Then
                If LCase(Microsoft.VisualBasic.Right(Trim(Me.OpenFileDialog1.FileName), 3)) <> "xls" Then
                    MessageBox.Show("Incorrect file extension. It must be ""XLS"".", "File Extension", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
                strFilePath = Trim(Me.OpenFileDialog1.FileName)

            Else
                MessageBox.Show("Please select a file.", "Select File", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            '********************************************************************************************************************
            i = Me.objAutoBill.UploadBillLevels(strFilePath)

            If i > 0 Then
                MessageBox.Show("Load Completed.", "Load File", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

            Me.LoadBillDataGrid()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Load File", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
        End Try
    End Sub

End Class
