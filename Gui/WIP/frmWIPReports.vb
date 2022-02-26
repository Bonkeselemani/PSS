Public Class frmWIPReports
    Inherits System.Windows.Forms.Form
    Private objWIP As PSS.Data.Buisness.WIP
    Private objQC As PSS.Data.Buisness.QC
    Private objMisc As PSS.Data.Buisness.Misc
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        objWIP = New PSS.Data.Buisness.WIP()
        objQC = New PSS.Data.Buisness.QC()
        objMisc = New PSS.Data.Buisness.Misc()
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
    Friend WithEvents cmdWIPCount As System.Windows.Forms.Button
    Friend WithEvents cmdWIPIMEIs As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbModel As PSS.Gui.Controls.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbCustomer As PSS.Gui.Controls.ComboBox
    Friend WithEvents cmdWIPSummaryNew As System.Windows.Forms.Button
    Friend WithEvents cmdWIPDetailNew As System.Windows.Forms.Button
    Friend WithEvents cmdATCLEWII As System.Windows.Forms.Button
    Friend WithEvents cmdVerifyExcelData As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdVerifyIMEIs As System.Windows.Forms.Button
    Friend WithEvents grpboxGetDisInfo As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDisIMEI As System.Windows.Forms.TextBox
    Friend WithEvents grdDiscrepacy As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmWIPReports))
        Me.cmdWIPCount = New System.Windows.Forms.Button()
        Me.cmdWIPIMEIs = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdWIPDetailNew = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmdWIPSummaryNew = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbModel = New PSS.Gui.Controls.ComboBox()
        Me.cmbCustomer = New PSS.Gui.Controls.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.cmdATCLEWII = New System.Windows.Forms.Button()
        Me.cmdVerifyExcelData = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdVerifyIMEIs = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.grpboxGetDisInfo = New System.Windows.Forms.GroupBox()
        Me.grdDiscrepacy = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.txtDisIMEI = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.grpboxGetDisInfo.SuspendLayout()
        CType(Me.grdDiscrepacy, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdWIPCount
        '
        Me.cmdWIPCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdWIPCount.Location = New System.Drawing.Point(80, 72)
        Me.cmdWIPCount.Name = "cmdWIPCount"
        Me.cmdWIPCount.Size = New System.Drawing.Size(272, 24)
        Me.cmdWIPCount.TabIndex = 0
        Me.cmdWIPCount.Text = "WIP Summary (Excel File)"
        '
        'cmdWIPIMEIs
        '
        Me.cmdWIPIMEIs.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdWIPIMEIs.Location = New System.Drawing.Point(80, 13)
        Me.cmdWIPIMEIs.Name = "cmdWIPIMEIs"
        Me.cmdWIPIMEIs.Size = New System.Drawing.Size(272, 24)
        Me.cmdWIPIMEIs.TabIndex = 1
        Me.cmdWIPIMEIs.Text = "WIP Detail (Text File)"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdWIPDetailNew, Me.cmdWIPIMEIs})
        Me.Panel1.Location = New System.Drawing.Point(0, 144)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(368, 89)
        Me.Panel1.TabIndex = 2
        '
        'cmdWIPDetailNew
        '
        Me.cmdWIPDetailNew.BackColor = System.Drawing.SystemColors.Control
        Me.cmdWIPDetailNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdWIPDetailNew.Location = New System.Drawing.Point(80, 48)
        Me.cmdWIPDetailNew.Name = "cmdWIPDetailNew"
        Me.cmdWIPDetailNew.Size = New System.Drawing.Size(272, 24)
        Me.cmdWIPDetailNew.TabIndex = 2
        Me.cmdWIPDetailNew.Text = "New WIP Detail (Text File)"
        Me.cmdWIPDetailNew.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdWIPSummaryNew, Me.Label2, Me.cmbModel, Me.cmdWIPCount, Me.cmbCustomer, Me.Label1})
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(368, 136)
        Me.Panel2.TabIndex = 3
        '
        'cmdWIPSummaryNew
        '
        Me.cmdWIPSummaryNew.BackColor = System.Drawing.SystemColors.Control
        Me.cmdWIPSummaryNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdWIPSummaryNew.Location = New System.Drawing.Point(80, 104)
        Me.cmdWIPSummaryNew.Name = "cmdWIPSummaryNew"
        Me.cmdWIPSummaryNew.Size = New System.Drawing.Size(272, 24)
        Me.cmdWIPSummaryNew.TabIndex = 92
        Me.cmdWIPSummaryNew.Text = "New WIP Summary (Excel File)"
        Me.cmdWIPSummaryNew.Visible = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(8, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 88
        Me.Label2.Text = "Model:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbModel
        '
        Me.cmbModel.AutoComplete = True
        Me.cmbModel.BackColor = System.Drawing.SystemColors.Window
        Me.cmbModel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbModel.ForeColor = System.Drawing.Color.Black
        Me.cmbModel.Location = New System.Drawing.Point(80, 40)
        Me.cmbModel.Name = "cmbModel"
        Me.cmbModel.Size = New System.Drawing.Size(272, 21)
        Me.cmbModel.TabIndex = 87
        '
        'cmbCustomer
        '
        Me.cmbCustomer.AutoComplete = True
        Me.cmbCustomer.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCustomer.ForeColor = System.Drawing.Color.Black
        Me.cmbCustomer.Location = New System.Drawing.Point(80, 8)
        Me.cmbCustomer.Name = "cmbCustomer"
        Me.cmbCustomer.Size = New System.Drawing.Size(272, 21)
        Me.cmbCustomer.TabIndex = 90
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(0, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 91
        Me.Label1.Text = "Customer:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.AddExtension = False
        Me.SaveFileDialog1.DefaultExt = "xls"
        Me.SaveFileDialog1.FileName = "WIP"
        Me.SaveFileDialog1.Filter = "Excel files (*.xls)|*.xls|Text files (*.txt)|*.txt"
        '
        'cmdATCLEWII
        '
        Me.cmdATCLEWII.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdATCLEWII.ForeColor = System.Drawing.Color.White
        Me.cmdATCLEWII.Location = New System.Drawing.Point(400, 248)
        Me.cmdATCLEWII.Name = "cmdATCLEWII"
        Me.cmdATCLEWII.Size = New System.Drawing.Size(312, 32)
        Me.cmdATCLEWII.TabIndex = 4
        Me.cmdATCLEWII.Text = "ATCLE WIP (For Robert McVey Only)"
        '
        'cmdVerifyExcelData
        '
        Me.cmdVerifyExcelData.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdVerifyExcelData.ForeColor = System.Drawing.Color.Lime
        Me.cmdVerifyExcelData.Location = New System.Drawing.Point(400, 48)
        Me.cmdVerifyExcelData.Name = "cmdVerifyExcelData"
        Me.cmdVerifyExcelData.Size = New System.Drawing.Size(312, 64)
        Me.cmdVerifyExcelData.TabIndex = 5
        Me.cmdVerifyExcelData.Text = "Verify ATCLE Excel File against PSS Database (For Robert McVey Only) (IMEI and  P" & _
        "allet)"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Lime
        Me.Label3.Location = New System.Drawing.Point(400, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(304, 40)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Required Items in Excel File: (1) Sheet Name must be ""McHugh Export"" (2) Columns " & _
        """Piece Identifier"" and ""Bin Location"" must be present in the sheet."
        '
        'cmdVerifyIMEIs
        '
        Me.cmdVerifyIMEIs.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdVerifyIMEIs.ForeColor = System.Drawing.Color.Lime
        Me.cmdVerifyIMEIs.Location = New System.Drawing.Point(400, 168)
        Me.cmdVerifyIMEIs.Name = "cmdVerifyIMEIs"
        Me.cmdVerifyIMEIs.Size = New System.Drawing.Size(312, 64)
        Me.cmdVerifyIMEIs.TabIndex = 7
        Me.cmdVerifyIMEIs.Text = "Verify IMEIs  only from an excel file against PSS Database (For Robert McVey Only" & _
        ") (IMEI only)"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Lime
        Me.Label4.Location = New System.Drawing.Point(400, 128)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(312, 40)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Required Items in Excel File: (1) Sheet Name must be ""McHugh Export"" (2) Columns " & _
        """Piece Identifier"" must be present in the sheet."
        '
        'grpboxGetDisInfo
        '
        Me.grpboxGetDisInfo.Controls.AddRange(New System.Windows.Forms.Control() {Me.grdDiscrepacy, Me.txtDisIMEI, Me.Label5})
        Me.grpboxGetDisInfo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.grpboxGetDisInfo.Location = New System.Drawing.Point(8, 288)
        Me.grpboxGetDisInfo.Name = "grpboxGetDisInfo"
        Me.grpboxGetDisInfo.Size = New System.Drawing.Size(704, 152)
        Me.grpboxGetDisInfo.TabIndex = 9
        Me.grpboxGetDisInfo.TabStop = False
        Me.grpboxGetDisInfo.Text = "ATCLE DISCREPANCY INFO"
        '
        'grdDiscrepacy
        '
        Me.grdDiscrepacy.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdDiscrepacy.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.grdDiscrepacy.Location = New System.Drawing.Point(8, 41)
        Me.grdDiscrepacy.Name = "grdDiscrepacy"
        Me.grdDiscrepacy.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdDiscrepacy.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdDiscrepacy.PreviewInfo.ZoomFactor = 75
        Me.grdDiscrepacy.Size = New System.Drawing.Size(688, 104)
        Me.grdDiscrepacy.TabIndex = 94
        Me.grdDiscrepacy.Text = "C1TrueDBGrid1"
        Me.grdDiscrepacy.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
        "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
        "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
        "er;}Style1{}Normal{BackColor:LightSteelBlue;}HighlightRow{ForeColor:HighlightTex" & _
        "t;BackColor:Highlight;}Style14{}OddRow{}RecordSelector{AlignImage:Center;}Style1" & _
        "5{}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:Contr" & _
        "olText;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}Style12{}Style" & _
        "13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView HBarHeight=""1" & _
        "0"" VBarHeight=""10"" Name="""" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFoo" & _
        "terHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSe" & _
        "lWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>100</Heigh" & _
        "t><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""" & _
        "Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""F" & _
        "ilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle " & _
        "parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><High" & _
        "LightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactiv" & _
        "e"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle" & _
        " parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Sty" & _
        "le6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 684, 100</ClientRe" & _
        "ct><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBG" & _
        "rid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent" & _
        "=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""He" & _
        "ading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Nor" & _
        "mal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal""" & _
        " me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal" & _
        """ me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Nor" & _
        "mal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSp" & _
        "lits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSel" & _
        "Width>17</DefaultRecSelWidth><ClientArea>0, 0, 684, 100</ClientArea><PrintPageHe" & _
        "aderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" " & _
        "/></Blob>"
        '
        'txtDisIMEI
        '
        Me.txtDisIMEI.Location = New System.Drawing.Point(48, 16)
        Me.txtDisIMEI.Name = "txtDisIMEI"
        Me.txtDisIMEI.Size = New System.Drawing.Size(144, 20)
        Me.txtDisIMEI.TabIndex = 93
        Me.txtDisIMEI.Text = ""
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(8, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 16)
        Me.Label5.TabIndex = 92
        Me.Label5.Text = "IMEI:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmWIPReports
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(728, 462)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.grpboxGetDisInfo, Me.Label4, Me.cmdVerifyIMEIs, Me.Label3, Me.cmdVerifyExcelData, Me.cmdATCLEWII, Me.Panel2, Me.Panel1})
        Me.Name = "frmWIPReports"
        Me.Text = "WIP Reports"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.grpboxGetDisInfo.ResumeLayout(False)
        CType(Me.grdDiscrepacy, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub cmdWIPCount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWIPCount.Click
        Dim i As Integer = 0

        Try
            'If Me.cmbCustomer.SelectedValue = 0 Then
            '    Throw New Exception("Please select a Customer.")
            'End If
            '*******************************************
            'Save File Dialog box
            '*******************************************
            Me.SaveFileDialog1.DefaultExt = "xls"
            Me.SaveFileDialog1.FilterIndex = 1
            Me.SaveFileDialog1.FileName = "WIP Summary.xls"
            System.Windows.Forms.Application.DoEvents()

            Me.SaveFileDialog1.ShowDialog()
            If Len(Trim(Me.SaveFileDialog1.FileName)) > 0 Then
                'If LCase(Microsoft.VisualBasic.Right(Trim(Me.SaveFileDialog1.FileName), 3)) <> "xls" Then
                '    MessageBox.Show("WIP file can only be saved as an '.xls' file.", "File Extension", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                '    Exit Sub
                'End If
                If Len(Dir(Me.SaveFileDialog1.FileName)) > 0 Then
                    Kill(Me.SaveFileDialog1.FileName)
                End If
            Else
                MessageBox.Show("Please input a file name to save the file.", "Save WIP File", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            '********************************************
            cmdWIPCount.Enabled = False
            i = Me.objWIP.GetWIPByGroup(Me.cmbCustomer.SelectedValue, , Me.SaveFileDialog1.FileName, Me.cmbModel.SelectedValue, Me.cmbModel.Text)   'Counts only


        Catch ex As Exception
            MessageBox.Show(ex.ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            cmdWIPCount.Enabled = True
        End Try
    End Sub

    Private Sub cmdWIPIMEIs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWIPIMEIs.Click
        Dim i As Integer = 0

        Try
            'If Me.cmbCustomer.SelectedValue = 0 Then
            '    Throw New Exception("Please select a Customer.")
            'End If
            '*******************************************
            'Save File Dialog box
            '*******************************************
            Me.SaveFileDialog1.DefaultExt = "txt"
            Me.SaveFileDialog1.FilterIndex = 2
            Me.SaveFileDialog1.FileName = "WIP Detail.txt"
            System.Windows.Forms.Application.DoEvents()
            Me.SaveFileDialog1.ShowDialog()

            If Len(Trim(Me.SaveFileDialog1.FileName)) > 0 Then
                'If LCase(Microsoft.VisualBasic.Right(Trim(Me.SaveFileDialog1.FileName), 3)) <> "txt" Then
                '    MessageBox.Show("WIP file can only be saved as a '.TXT' file.", "File Extension", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                '    Exit Sub
                'End If
                If Len(Dir(Me.SaveFileDialog1.FileName)) > 0 Then
                    Kill(Me.SaveFileDialog1.FileName)
                End If
            Else
                MessageBox.Show("Please input a file name to save the file.", "Save WIP File", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            '*******************************************
            cmdWIPIMEIs.Enabled = False
            i = Me.objWIP.GetWIPByGroup(Me.cmbCustomer.SelectedValue, 1, Me.SaveFileDialog1.FileName, , )
            If i = 1 Then
                MessageBox.Show("Cellular WIP Detail Report has been created and saved at '" & Trim(Me.SaveFileDialog1.FileName) & "'.", "WIP Detail Report", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            cmdWIPIMEIs.Enabled = True
        End Try
    End Sub

    Private Sub LoadCustomers()
        Dim dtCustomers As DataTable
        Try
            dtCustomers = objMisc.GetCustomers
            With Me.cmbCustomer
                .DataSource = dtCustomers.DefaultView
                .DisplayMember = dtCustomers.Columns("cust_name1").ToString
                .ValueMember = dtCustomers.Columns("Cust_ID").ToString
                .SelectedValue = 0
            End With
        Catch ex As Exception
            MsgBox("Error in frmWIPReports.LoadCustomers:: " & ex.Message.ToString, MsgBoxStyle.Critical)
        Finally
            If Not IsNothing(dtCustomers) Then
                dtCustomers.Dispose()
                dtCustomers = Nothing
            End If
        End Try
    End Sub

    Private Sub LoadModels()
        Dim dtModels As New DataTable()
        Dim objMisc As New PSS.Data.Buisness.Misc()
        Try
            dtModels = objMisc.GetModels()
            With Me.cmbModel
                .DataSource = dtModels.DefaultView
                .DisplayMember = dtModels.Columns("Model_Desc").ToString
                .ValueMember = dtModels.Columns("Model_ID").ToString
                .SelectedValue = 0
            End With

        Catch ex As Exception
            MsgBox("Error in frmWIPReports.LoadModels:: " & ex.Message.ToString, MsgBoxStyle.Critical)
        Finally
            If Not IsNothing(dtModels) Then
                dtModels.Dispose()
                dtModels = Nothing
            End If
            If Not IsNothing(objMisc) Then
                objMisc = Nothing
            End If
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        objQC = Nothing
        objWIP = Nothing
        objMisc = Nothing
        MyBase.Finalize()
    End Sub

    Private Sub frmWIPReports_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCustomers()
        Me.LoadModels()
    End Sub


    Private Sub cmdWIPSummaryNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWIPSummaryNew.Click
        Dim i As Integer = 0

        Try
            '*******************************************
            'Save File Dialog box
            '*******************************************
            Me.SaveFileDialog1.DefaultExt = "xls"
            Me.SaveFileDialog1.FilterIndex = 1
            Me.SaveFileDialog1.FileName = "WIP Summary.xls"
            System.Windows.Forms.Application.DoEvents()

            Me.SaveFileDialog1.ShowDialog()
            If Len(Trim(Me.SaveFileDialog1.FileName)) > 0 Then
                If Len(Dir(Me.SaveFileDialog1.FileName)) > 0 Then
                    Kill(Me.SaveFileDialog1.FileName)
                End If
            Else
                MessageBox.Show("Please input a file name to save the file.", "Save WIP File", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            '********************************************
            cmdWIPSummaryNew.Enabled = False
            i = Me.objWIP.New_WIPReport(Me.cmbCustomer.SelectedValue, , Me.SaveFileDialog1.FileName, Me.cmbModel.SelectedValue, Me.cmbModel.Text)   'Counts only

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            cmdWIPSummaryNew.Enabled = True
        End Try
    End Sub

    Private Sub cmdWIPDetailNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWIPDetailNew.Click
        Dim i As Integer = 0

        Try
            '*******************************************
            'Save File Dialog box
            '*******************************************
            Me.SaveFileDialog1.DefaultExt = "txt"
            Me.SaveFileDialog1.FilterIndex = 2
            Me.SaveFileDialog1.FileName = "WIP Detail.txt"
            System.Windows.Forms.Application.DoEvents()
            Me.SaveFileDialog1.ShowDialog()

            If Len(Trim(Me.SaveFileDialog1.FileName)) > 0 Then
                If Len(Dir(Me.SaveFileDialog1.FileName)) > 0 Then
                    Kill(Me.SaveFileDialog1.FileName)
                End If
            Else
                MessageBox.Show("Please input a file name to save the file.", "Save WIP File", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            '*******************************************
            cmdWIPDetailNew.Enabled = False
            i = Me.objWIP.New_WIPReport(Me.cmbCustomer.SelectedValue, 1, Me.SaveFileDialog1.FileName, , )
            If i = 1 Then
                MessageBox.Show("Cellular WIP Detail Report has been created and saved at '" & Trim(Me.SaveFileDialog1.FileName) & "'.", "WIP Detail Report", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            cmdWIPDetailNew.Enabled = True
        End Try
    End Sub

    Private Sub cmdATCLEWII_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdATCLEWII.Click
        Dim i As Integer = 0
        Try
            i = Me.objWIP.ATCLEWIPDetailRpt()

            If i > 0 Then
                MessageBox.Show("ATCLE WIP report is created at 'C:\ATCLE WIP Detail.txt'.", "ATCLE WIP Report", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "ATCLE WIP Report", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub cmdVerifyExcelData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVerifyExcelData.Click
        Dim strFilePath As String = ""
        Try
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
            Me.objWIP.ATCLEWIP_VerifyExcelFileData(strFilePath, 0)


        Catch ex As Exception
            MessageBox.Show(ex.ToString, "ATCLE WIP Report", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

 
    Private Sub cmdVerifyIMEIs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVerifyIMEIs.Click
        Dim strFilePath As String = ""
        Try
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
            Me.objWIP.ATCLEWIP_VerifyExcelFileData(strFilePath, 1)

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "ATCLE WIP Report", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub


    Private Sub txtDisIMEI_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDisIMEI.KeyUp
        Dim dt1 As DataTable

        Try
            If e.KeyValue = 13 Then

                If Me.txtDisIMEI.Text.Trim = "" Then
                    Exit Sub
                End If

                Me.Enabled = False
                Me.grdDiscrepacy.DataSource = Nothing

                dt1 = Me.objWIP.GetWHDiscrepacyInfo(Me.txtDisIMEI.Text.Trim.ToUpper)
                Me.grdDiscrepacy.DataSource = dt1.DefaultView
                Me.txtDisIMEI.SelectAll()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Get Disccrepancy Info", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
            Me.Enabled = True
        End Try
    End Sub

End Class
