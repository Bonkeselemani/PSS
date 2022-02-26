Option Explicit On 

Imports System.Data.OleDb
Imports PSS.Data.Buisness

Public Class frmHTCProcessRMA
    Inherits System.Windows.Forms.Form

    Private _objHTC As HTC
    Private _dtData As DataTable

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _objHTC = New HTC()
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
            _objHTC = Nothing
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents btnBrowseToDataFile As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboSku As PSS.Gui.Controls.ComboBox
    Friend WithEvents lblModelDesc As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnCreateRMA As System.Windows.Forms.Button
    Friend WithEvents cboShipFrLoc As PSS.Gui.Controls.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dbgRMAData As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents txtPSSIRMA As System.Windows.Forms.TextBox
    Friend WithEvents txtCusRMA As System.Windows.Forms.TextBox
    Friend WithEvents lblQty As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmHTCProcessRMA))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblQty = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.cboShipFrLoc = New PSS.Gui.Controls.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnCreateRMA = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPSSIRMA = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblModelDesc = New System.Windows.Forms.Label()
        Me.cboSku = New PSS.Gui.Controls.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCusRMA = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnBrowseToDataFile = New System.Windows.Forms.Button()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.dbgRMAData = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Panel1.SuspendLayout()
        CType(Me.dbgRMAData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left)
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblQty, Me.btnCancel, Me.cboShipFrLoc, Me.Label5, Me.btnCreateRMA, Me.Label4, Me.txtPSSIRMA, Me.Label3, Me.lblModelDesc, Me.cboSku, Me.Label1, Me.txtCusRMA, Me.Label2, Me.btnBrowseToDataFile})
        Me.Panel1.Location = New System.Drawing.Point(1, 81)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(215, 423)
        Me.Panel1.TabIndex = 131
        '
        'lblQty
        '
        Me.lblQty.BackColor = System.Drawing.Color.Transparent
        Me.lblQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQty.ForeColor = System.Drawing.Color.Blue
        Me.lblQty.Location = New System.Drawing.Point(16, 264)
        Me.lblQty.Name = "lblQty"
        Me.lblQty.Size = New System.Drawing.Size(176, 24)
        Me.lblQty.TabIndex = 135
        Me.lblQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Gray
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(8, 328)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(184, 24)
        Me.btnCancel.TabIndex = 134
        Me.btnCancel.Text = "Cancel"
        '
        'cboShipFrLoc
        '
        Me.cboShipFrLoc.AutoComplete = True
        Me.cboShipFrLoc.BackColor = System.Drawing.SystemColors.Window
        Me.cboShipFrLoc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboShipFrLoc.ForeColor = System.Drawing.Color.Black
        Me.cboShipFrLoc.Location = New System.Drawing.Point(8, 24)
        Me.cboShipFrLoc.Name = "cboShipFrLoc"
        Me.cboShipFrLoc.Size = New System.Drawing.Size(184, 21)
        Me.cboShipFrLoc.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(8, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(176, 16)
        Me.Label5.TabIndex = 133
        Me.Label5.Text = "Ship From Location :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'btnCreateRMA
        '
        Me.btnCreateRMA.BackColor = System.Drawing.Color.ForestGreen
        Me.btnCreateRMA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreateRMA.ForeColor = System.Drawing.Color.White
        Me.btnCreateRMA.Location = New System.Drawing.Point(8, 368)
        Me.btnCreateRMA.Name = "btnCreateRMA"
        Me.btnCreateRMA.Size = New System.Drawing.Size(184, 24)
        Me.btnCreateRMA.TabIndex = 6
        Me.btnCreateRMA.Text = "Create RMA with data file"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label4.Location = New System.Drawing.Point(8, 174)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(184, 16)
        Me.Label4.TabIndex = 131
        Me.Label4.Text = "Model:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPSSIRMA
        '
        Me.txtPSSIRMA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPSSIRMA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPSSIRMA.Location = New System.Drawing.Point(8, 104)
        Me.txtPSSIRMA.MaxLength = 15
        Me.txtPSSIRMA.Name = "txtPSSIRMA"
        Me.txtPSSIRMA.Size = New System.Drawing.Size(184, 22)
        Me.txtPSSIRMA.TabIndex = 3
        Me.txtPSSIRMA.Text = ""
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label3.Location = New System.Drawing.Point(8, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(184, 16)
        Me.Label3.TabIndex = 130
        Me.Label3.Text = "PSS RMA #:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblModelDesc
        '
        Me.lblModelDesc.BackColor = System.Drawing.Color.White
        Me.lblModelDesc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblModelDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModelDesc.ForeColor = System.Drawing.Color.Red
        Me.lblModelDesc.Location = New System.Drawing.Point(8, 190)
        Me.lblModelDesc.Name = "lblModelDesc"
        Me.lblModelDesc.Size = New System.Drawing.Size(184, 21)
        Me.lblModelDesc.TabIndex = 128
        Me.lblModelDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSku
        '
        Me.cboSku.AutoComplete = True
        Me.cboSku.BackColor = System.Drawing.SystemColors.Window
        Me.cboSku.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSku.ForeColor = System.Drawing.Color.Black
        Me.cboSku.Location = New System.Drawing.Point(8, 150)
        Me.cboSku.Name = "cboSku"
        Me.cboSku.Size = New System.Drawing.Size(184, 21)
        Me.cboSku.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(8, 134)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(184, 16)
        Me.Label1.TabIndex = 127
        Me.Label1.Text = "Customer's Sku # :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'txtCusRMA
        '
        Me.txtCusRMA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCusRMA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCusRMA.Location = New System.Drawing.Point(8, 64)
        Me.txtCusRMA.MaxLength = 15
        Me.txtCusRMA.Name = "txtCusRMA"
        Me.txtCusRMA.Size = New System.Drawing.Size(184, 22)
        Me.txtCusRMA.TabIndex = 2
        Me.txtCusRMA.Text = ""
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label2.Location = New System.Drawing.Point(8, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(184, 16)
        Me.Label2.TabIndex = 125
        Me.Label2.Text = "Customer RMA #:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnBrowseToDataFile
        '
        Me.btnBrowseToDataFile.BackColor = System.Drawing.Color.SteelBlue
        Me.btnBrowseToDataFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowseToDataFile.ForeColor = System.Drawing.Color.White
        Me.btnBrowseToDataFile.Location = New System.Drawing.Point(8, 224)
        Me.btnBrowseToDataFile.Name = "btnBrowseToDataFile"
        Me.btnBrowseToDataFile.Size = New System.Drawing.Size(184, 24)
        Me.btnBrowseToDataFile.TabIndex = 5
        Me.btnBrowseToDataFile.Text = "Browse to data file"
        '
        'lblHeader
        '
        Me.lblHeader.BackColor = System.Drawing.Color.Black
        Me.lblHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.ForeColor = System.Drawing.Color.Yellow
        Me.lblHeader.Location = New System.Drawing.Point(2, 0)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(214, 80)
        Me.lblHeader.TabIndex = 133
        Me.lblHeader.Text = "HTC RMA Processing"
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dbgRMAData
        '
        Me.dbgRMAData.AllowArrows = False
        Me.dbgRMAData.AllowColMove = False
        Me.dbgRMAData.AllowFilter = False
        Me.dbgRMAData.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.dbgRMAData.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.dbgRMAData.CaptionHeight = 17
        Me.dbgRMAData.FetchRowStyles = True
        Me.dbgRMAData.FilterBar = True
        Me.dbgRMAData.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dbgRMAData.GroupByCaption = "Drag a column header here to group by that column"
        Me.dbgRMAData.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.dbgRMAData.Location = New System.Drawing.Point(217, 1)
        Me.dbgRMAData.Name = "dbgRMAData"
        Me.dbgRMAData.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgRMAData.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgRMAData.PreviewInfo.ZoomFactor = 75
        Me.dbgRMAData.RowHeight = 15
        Me.dbgRMAData.RowSubDividerColor = System.Drawing.Color.DimGray
        Me.dbgRMAData.Size = New System.Drawing.Size(552, 503)
        Me.dbgRMAData.TabIndex = 132
        Me.dbgRMAData.Text = "C1TrueDBGrid1"
        Me.dbgRMAData.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:DarkGray;}Selec" & _
        "ted{ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inac" & _
        "tiveCaptionText;BackColor:InactiveCaption;}FilterBar{ForeColor:Red;BackColor:Whi" & _
        "te;}Footer{}Caption{Font:Microsoft Sans Serif, 9.75pt, style=Bold;AlignHorz:Cent" & _
        "er;ForeColor:White;BackColor:DarkSlateGray;}Style1{}Normal{Font:Microsoft Sans S" & _
        "erif, 9.75pt, style=Bold;BackColor:LightSteelBlue;}HighlightRow{ForeColor:Highli" & _
        "ghtText;BackColor:Highlight;}Style14{}OddRow{}RecordSelector{AlignImage:Center;}" & _
        "Style15{}Heading{Wrap:True;BackColor:SteelBlue;Border:Raised,,1, 1, 1, 1;ForeCol" & _
        "or:White;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}Style12{}Sty" & _
        "le13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView HBarHeight=" & _
        """15"" AllowColMove=""False"" Name="""" AllowRowSizing=""None"" CaptionHeight=""17"" Colum" & _
        "nCaptionHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyles=""True"" FilterBar=""Tru" & _
        "e"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefRecSelWidth=""16"" " & _
        "VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>499</Height><CaptionSt" & _
        "yle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><E" & _
        "venRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me" & _
        "=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Grou" & _
        "p"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyl" & _
        "e parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style" & _
        "4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""Rec" & _
        "ordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Styl" & _
        "e parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 548, 499</ClientRect><BorderSi" & _
        "de>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeVie" & _
        "w></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me" & _
        "=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""C" & _
        "aption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Sel" & _
        "ected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""Highlig" & _
        "htRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow" & _
        """ /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""Fil" & _
        "terBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vert" & _
        "Splits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>16</De" & _
        "faultRecSelWidth><ClientArea>0, 0, 548, 499</ClientArea><PrintPageHeaderStyle pa" & _
        "rent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
        '
        'frmHTCProcessRMA
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(784, 517)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel1, Me.lblHeader, Me.dbgRMAData})
        Me.Name = "frmHTCProcessRMA"
        Me.Text = "HTC RMA Processing"
        Me.Panel1.ResumeLayout(False)
        CType(Me.dbgRMAData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '************************************************************************************
    Private Sub frmHTCProcessRMA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            PSS.Core.Highlight.SetHighLight(Me)
            Me.PopulateShipToLocation()
            Me.PopulateSku()
            Me.cboShipFrLoc.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "frmHTCProcessRMA_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '******************************************************************
    Private Sub PopulateShipToLocation()
        Dim dt As DataTable
        Try
            dt = Me._objHTC.GetShipToLocation()
            With Me.cboShipFrLoc
                .DataSource = Nothing
                .DataSource = dt.DefaultView
                .DisplayMember = "ShipTo_Name"
                .ValueMember = "ShipTo_ID"
                If dt.Rows.Count > 1 Then
                    .SelectedValue = dt.Rows(0)("ShipTo_ID")
                Else
                    .SelectedValue = 0
                End If
            End With
        Catch ex As Exception
            Throw ex
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)
        End Try
    End Sub

    '******************************************************************
    Private Sub PopulateSku()
        Dim dt As DataTable
        Try
            dt = Me._objHTC.GetHTCSku(True)
            With Me.cboSku
                .DataSource = Nothing
                .DataSource = dt.DefaultView
                .DisplayMember = "Sku_Desc"
                .ValueMember = "Sku_ID"
                If dt.Rows.Count = 2 Then
                    .SelectedValue = dt.Rows(0)("Sku_ID")
                Else
                    .SelectedValue = 0
                End If
            End With
        Catch ex As Exception
            Throw ex
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)
        End Try
    End Sub

    '************************************************************************************
    Private Sub cboShipFrLoc_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboShipFrLoc.SelectionChangeCommitted
        Try
            'Reset data grid
            Me.dbgRMAData.DataSource = Nothing
            Generic.DisposeDT(Me._dtData)
            Me.lblQty.Text = ""

            If Me.cboShipFrLoc.SelectedValue > 0 Then Me.txtCusRMA.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "cboShipFrLoc_SelectionChangeCommitted", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '************************************************************************************
    Private Sub txtCusRMA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCusRMA.KeyPress, txtPSSIRMA.KeyPress
        Try
            If Not (e.KeyChar.IsLetterOrDigit(e.KeyChar) Or e.KeyChar.IsControl(e.KeyChar)) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtCusRMA_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '************************************************************************************
    Private Sub txtCusRMA_PSSIRMA_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCusRMA.KeyUp
        If e.KeyValue = 13 Then
            'Reset data grid
            Me.dbgRMAData.DataSource = Nothing
            Generic.DisposeDT(Me._dtData)
            Me.lblQty.Text = ""

            If Me.txtCusRMA.Text.Trim.Length > 0 Then Me.txtPSSIRMA.Focus()
        End If
    End Sub

    '************************************************************************************
    Private Sub txtPSSIRMA_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPSSIRMA.KeyUp
        If e.KeyValue = 13 Then
            'Reset data grid
            Me.dbgRMAData.DataSource = Nothing
            Generic.DisposeDT(Me._dtData)
            Me.lblQty.Text = ""

            If Me.txtCusRMA.Text.Trim.Length > 0 Then Me.cboSku.Focus()
        End If
    End Sub

    '************************************************************************************
    Private Sub cboSku_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSku.SelectionChangeCommitted
        Try
            'Reset data grid
            Me.dbgRMAData.DataSource = Nothing
            Generic.DisposeDT(Me._dtData)
            Me.lblQty.Text = ""

            If Me.cboSku.SelectedValue = 0 Then
                Me.lblModelDesc.Text = ""
            Else
                Me.lblModelDesc.Text = Me.cboSku.SelectedItem("Model_Desc")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "cboSku_SelectionChangeCommitted", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '************************************************************************************
    Private Sub btnBrowseToDataFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBrowseToDataFile.Click
        Dim fdOpenFile As OpenFileDialog
        Dim strFileLoc As String = ""
        Dim i As Integer = 0

        Try
            'Reset data grid
            Me.dbgRMAData.DataSource = Nothing
            Generic.DisposeDT(Me._dtData)
            Me.lblQty.Text = ""
            DisableEnableControls(True)

            If Me.cboShipFrLoc.SelectedValue = 0 Then
                MessageBox.Show("Please select location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf Me.txtCusRMA.Text.Trim.Length = 0 Then
                MessageBox.Show("Please enter customer's RMA.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf Me.txtCusRMA.Text.Trim.ToUpper.StartsWith("RTS") = False Then
                MessageBox.Show("Customer's RMA must start with RTS.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf Me._objHTC.IsCustomerRMAExisted(Me.txtCusRMA.Text.Trim) = True Then
                MessageBox.Show("Customer's RMA already existed in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf Me.txtPSSIRMA.Text.Trim.Length = 0 Then
                MessageBox.Show("Please enter PSS's RMA.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf Me.txtPSSIRMA.Text.Trim.ToUpper.StartsWith(Me.txtCusRMA.Text.Trim.ToUpper) = False AndAlso MessageBox.Show("PSSI's RMA does not start with customer's RMA. Would you like to continue?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Exit Sub
            ElseIf Me.txtPSSIRMA.Text.Trim.ToUpper.EndsWith("PSS") = False AndAlso MessageBox.Show("PSSI's RMA does not end with PSS. Would you like to continue?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Exit Sub
            ElseIf Me._objHTC.IsPSSRMAExisted(Me.txtPSSIRMA.Text.Trim) = True Then
                MessageBox.Show("PSS RMA already existed in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf Me.cboSku.SelectedValue = 0 Then
                MessageBox.Show("Please select Sku.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                fdOpenFile = New OpenFileDialog()
                fdOpenFile.DefaultExt = ".*"
                fdOpenFile.ShowDialog()
                strFileLoc = fdOpenFile.FileName

                If strFileLoc.Trim.Length = 0 Then Exit Sub

                Me._dtData = Me.getIMEI(strFileLoc)
                If Not IsNothing(Me._dtData) Then
                    DisableEnableControls(False)

                    With Me.dbgRMAData
                        .DataSource = Me._dtData.DefaultView

                        For i = 0 To .Columns.Count - 1
                            .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                            If i > 0 Then .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        Next i

                        .Splits(0).DisplayColumns("Cnt").Width = 40
                        .Splits(0).DisplayColumns("IMEI").Width = 120
                        .Splits(0).DisplayColumns("Customer RMA").Width = 110
                        .Splits(0).DisplayColumns("PSS RMA").Width = 110
                        .Splits(0).DisplayColumns("Sku").Width = 60
                        .Splits(0).DisplayColumns("Ship From").Width = 120
                        .Splits(0).DisplayColumns("ShipTo_ID").Visible = False
                        .Splits(0).DisplayColumns("Sku_ID").Visible = False
                        .Splits(0).DisplayColumns("Name").Visible = False
                        .Splits(0).DisplayColumns("UsrID").Visible = False
                        .Splits(0).DisplayColumns("GroupID").Visible = False

                        .AlternatingRows = True
                        .EvenRowStyle.BackColor = Color.NavajoWhite
                        .EvenRowStyle.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Regular)
                        .OddRowStyle.BackColor = Color.LightSteelBlue
                        .OddRowStyle.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Regular)
                        .AllowFilter = False
                        .FilterBar = False
                        .AllowSort = False

                    End With
                    Me.lblQty.Text = "Qty: " & Me._dtData.Rows.Count
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnBrowseToDataFile_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '************************************************************************************
    Private Function getIMEI(ByVal strFileLocation As String) As DataTable
        Dim objExcel As Object = Nothing    ' Excel application
        Dim objBook As Object = Nothing     ' Excel workbook
        Dim objSheet As Object = Nothing    ' Excel Worksheet
        Dim sConnectionstring As String
        Dim objConn As New OleDbConnection()
        Dim objCmdSelect As New OleDbCommand()
        Dim objAdapter1 As New OleDbDataAdapter()
        Dim objDataset1 As New DataSet()
        Dim dt As New DataTable()
        Dim R1 As DataRow
        Dim strSql As String = ""
        Dim i As Integer = 0

        Try
            '//Create a datatable of all values from the assigned file
            sConnectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strFileLocation & ";Extended Properties=Excel 8.0;"
            objConn.ConnectionString = sConnectionstring
            objConn.Open()

            strSql = "SELECT 0 as Cnt, [Piece Identifier] as IMEI " & Environment.NewLine
            strSql &= ", '" & Me.txtCusRMA.Text.Trim & "' as [Customer RMA] " & Environment.NewLine
            strSql &= ", '" & Me.txtPSSIRMA.Text.Trim & "' as [PSS RMA] " & Environment.NewLine
            strSql &= ", '" & Me.cboSku.Text.Trim & "' as Sku " & Environment.NewLine
            strSql &= ", '" & Me.cboShipFrLoc.Text.Trim & "' as [Ship From] " & Environment.NewLine
            strSql &= ", " & Me.cboShipFrLoc.SelectedValue & " as ShipTo_ID " & Environment.NewLine
            strSql &= ", " & Me.cboSku.SelectedValue & " as Sku_ID " & Environment.NewLine
            strSql &= ", '" & Core.ApplicationUser.User & "' as Name " & Environment.NewLine
            strSql &= ", " & Core.ApplicationUser.IDuser & " as UsrID " & Environment.NewLine
            strSql &= ", 79 as GroupID " & Environment.NewLine
            strSql &= "FROM [McHugh Export$] WHERE [Piece Identifier] is not null ORDER BY [Piece Identifier]"
            objCmdSelect.CommandText = (strSql)

            objCmdSelect.Connection = objConn
            objAdapter1.SelectCommand = objCmdSelect
            objAdapter1.Fill(dt)
            objAdapter1.Fill(objDataset1, "XLData")
            'objConn.Close()

            For Each R1 In dt.Rows
                R1.BeginEdit()
                i += 1
                R1("Cnt") = i
                R1.EndEdit()
                dt.AcceptChanges()
            Next R1

            Return dt
        Catch ex As Exception
            Throw ex
        Finally
            Generic.DisposeDT(dt)
            '*************************************
            'Excel clean up
            If Not IsNothing(objSheet) Then
                objSheet = Nothing
                Generic.NAR(objSheet)
            End If
            If Not IsNothing(objBook) Then
                objBook.Close(False)
                Generic.NAR(objBook)
            End If
            If Not IsNothing(objExcel) Then
                objExcel.Quit()
                objExcel = Nothing
                Generic.NAR(objExcel)
            End If

            If Not IsNothing(objConn) Then
                objConn.Close()
                objConn.Dispose()
                objConn = Nothing
            End If
            If Not IsNothing(objCmdSelect) Then
                objCmdSelect.Dispose()
                objCmdSelect = Nothing
            End If
            If Not IsNothing(objAdapter1) Then
                objAdapter1.Dispose()
                objAdapter1 = Nothing
            End If
            If Not IsNothing(objDataset1) Then
                objDataset1.Dispose()
                objDataset1 = Nothing
            End If
            GC.Collect()
            GC.WaitForPendingFinalizers()
            GC.Collect()
            GC.WaitForPendingFinalizers()
        End Try
    End Function

    '************************************************************************************
    Private Sub btnCreateRMA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateRMA.Click
        Dim i As Integer = 0

        Try
            If IsNothing(Me._dtData) Then
                Exit Sub
            ElseIf Me._dtData.Rows.Count = 0 Then
                Exit Sub
            ElseIf Me._objHTC.IsCustomerRMAExisted(Me.txtCusRMA.Text.Trim) = True Then
                MessageBox.Show("Customer's RMA already existed in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf Me._objHTC.IsPSSRMAExisted(Me.txtPSSIRMA.Text.Trim) = True Then
                MessageBox.Show("PSS RMA already existed in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                Me.Enabled = False
                i = Me._objHTC.ProcessRMA(Me._dtData)
                If i > 0 Then
                    MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me._dtData.Clear()
                    Me.dbgRMAData.DataSource = Nothing
                    Me.txtCusRMA.Text = ""
                    Me.txtPSSIRMA.Text = ""
                    Me.cboSku.SelectedValue = 0
                    Me.lblModelDesc.Text = ""
                    Me.lblQty.Text = Me._dtData.Rows.Count
                    Me.Enabled = True
                    Me.cboShipFrLoc.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnCreateRMA_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Enabled = True
        End Try
    End Sub

    '************************************************************************************
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Try
            Me._dtData.Clear()
            Me.dbgRMAData.DataSource = Nothing
            Me.cboShipFrLoc.SelectedValue = 0
            Me.txtCusRMA.Text = ""
            Me.txtPSSIRMA.Text = ""
            Me.cboSku.SelectedValue = 0
            Me.lblModelDesc.Text = ""
            Me.lblQty.Text = Me._dtData.Rows.Count
            Me.cboShipFrLoc.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnClear_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '************************************************************************************
    Private Sub DisableEnableControls(ByVal booVal As Boolean)
        Me.cboShipFrLoc.Enabled = booVal
        Me.txtCusRMA.Enabled = booVal
        Me.txtPSSIRMA.Enabled = booVal
        Me.cboSku.Enabled = booVal
    End Sub

    '************************************************************************************

End Class
