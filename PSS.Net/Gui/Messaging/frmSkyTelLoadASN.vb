Option Explicit On 

Imports PSS.Data.Buisness
Imports System.Data.OleDb
Imports System.IO

Public Class frmSkyTelLoadASN
    Inherits System.Windows.Forms.Form

    Private _objSkyTel As SkyTel
    Private _dtData As DataTable
    Private _dtFreqs As DataTable
    Private _dtBauds As DataTable
    Private _dtWO As DataTable
    Private _strArrHeader() As String

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _objSkyTel = New SkyTel()

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If

            _objSkyTel = Nothing
            If Not IsNothing(_dtData) Then
                _dtData.Dispose()
                _dtData = Nothing
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents btnBrowseData As System.Windows.Forms.Button
    Friend WithEvents gbLoadASNFile As System.Windows.Forms.GroupBox
    Friend WithEvents lblFileLoc As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblMissingBaud As System.Windows.Forms.Label
    Friend WithEvents lblMissingSN As System.Windows.Forms.Label
    Friend WithEvents lblMissingCap As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblMissingFreq As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Cancel As System.Windows.Forms.Button
    Friend WithEvents lblFileQty As System.Windows.Forms.Label
    Friend WithEvents btnLoadData As System.Windows.Forms.Button
    Friend WithEvents lblDuplicateSN As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dbgData As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSkyTelLoadASN))
        Me.btnBrowseData = New System.Windows.Forms.Button()
        Me.gbLoadASNFile = New System.Windows.Forms.GroupBox()
        Me.dbgData = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.btnLoadData = New System.Windows.Forms.Button()
        Me.lblMissingFreq = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblMissingCap = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblFileQty = New System.Windows.Forms.Label()
        Me.lblMissingBaud = New System.Windows.Forms.Label()
        Me.lblDuplicateSN = New System.Windows.Forms.Label()
        Me.lblMissingSN = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblFileLoc = New System.Windows.Forms.Label()
        Me.gbLoadASNFile.SuspendLayout()
        CType(Me.dbgData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnBrowseData
        '
        Me.btnBrowseData.BackColor = System.Drawing.Color.SteelBlue
        Me.btnBrowseData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowseData.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnBrowseData.Location = New System.Drawing.Point(8, 24)
        Me.btnBrowseData.Name = "btnBrowseData"
        Me.btnBrowseData.Size = New System.Drawing.Size(184, 24)
        Me.btnBrowseData.TabIndex = 0
        Me.btnBrowseData.Text = "Browse Data"
        '
        'gbLoadASNFile
        '
        Me.gbLoadASNFile.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.gbLoadASNFile.Controls.AddRange(New System.Windows.Forms.Control() {Me.dbgData, Me.Cancel, Me.btnLoadData, Me.lblMissingFreq, Me.Label11, Me.lblMissingCap, Me.Label9, Me.lblFileQty, Me.lblMissingBaud, Me.lblDuplicateSN, Me.lblMissingSN, Me.Label4, Me.Label6, Me.Label2, Me.Label1, Me.lblFileLoc, Me.btnBrowseData})
        Me.gbLoadASNFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbLoadASNFile.Location = New System.Drawing.Point(8, 16)
        Me.gbLoadASNFile.Name = "gbLoadASNFile"
        Me.gbLoadASNFile.Size = New System.Drawing.Size(664, 480)
        Me.gbLoadASNFile.TabIndex = 1
        Me.gbLoadASNFile.TabStop = False
        Me.gbLoadASNFile.Text = "Load ASN File"
        '
        'dbgData
        '
        Me.dbgData.AlternatingRows = True
        Me.dbgData.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.dbgData.FilterBar = True
        Me.dbgData.GroupByCaption = "Drag a column header here to group by that column"
        Me.dbgData.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.dbgData.Location = New System.Drawing.Point(208, 24)
        Me.dbgData.Name = "dbgData"
        Me.dbgData.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgData.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgData.PreviewInfo.ZoomFactor = 75
        Me.dbgData.Size = New System.Drawing.Size(440, 440)
        Me.dbgData.TabIndex = 16
        Me.dbgData.Text = "C1TrueDBGrid1"
        Me.dbgData.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:LightSteelBlue;" & _
        "}Selected{ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColo" & _
        "r:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{Alig" & _
        "nHorz:Center;}Style9{}Normal{Font:Microsoft Sans Serif, 8.25pt, style=Bold;}High" & _
        "lightRow{ForeColor:HighlightText;BackColor:Highlight;}Style14{}OddRow{BackColor:" & _
        "CornflowerBlue;}RecordSelector{AlignImage:Center;}Style15{}Heading{Wrap:True;Ali" & _
        "gnVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;" & _
        "}Style8{}Style10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style1{}</Data></Sty" & _
        "les><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" AlternatingRowStyle=""True"" Ca" & _
        "ptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""Tru" & _
        "e"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefRecSelWidth=""16"" " & _
        "VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>436</Height><CaptionSt" & _
        "yle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><E" & _
        "venRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me" & _
        "=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Grou" & _
        "p"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyl" & _
        "e parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style" & _
        "4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""Rec" & _
        "ordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Styl" & _
        "e parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 436, 436</ClientRect><BorderSi" & _
        "de>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeVie" & _
        "w></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me" & _
        "=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""C" & _
        "aption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Sel" & _
        "ected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""Highlig" & _
        "htRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow" & _
        """ /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""Fil" & _
        "terBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vert" & _
        "Splits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>16</De" & _
        "faultRecSelWidth><ClientArea>0, 0, 436, 436</ClientArea><PrintPageHeaderStyle pa" & _
        "rent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
        '
        'Cancel
        '
        Me.Cancel.BackColor = System.Drawing.Color.CadetBlue
        Me.Cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Cancel.Location = New System.Drawing.Point(128, 280)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(64, 24)
        Me.Cancel.TabIndex = 15
        Me.Cancel.Text = "Cancel"
        '
        'btnLoadData
        '
        Me.btnLoadData.BackColor = System.Drawing.Color.CadetBlue
        Me.btnLoadData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoadData.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnLoadData.Location = New System.Drawing.Point(8, 280)
        Me.btnLoadData.Name = "btnLoadData"
        Me.btnLoadData.Size = New System.Drawing.Size(80, 24)
        Me.btnLoadData.TabIndex = 14
        Me.btnLoadData.Text = "Load Data"
        '
        'lblMissingFreq
        '
        Me.lblMissingFreq.ForeColor = System.Drawing.Color.Blue
        Me.lblMissingFreq.Location = New System.Drawing.Point(144, 240)
        Me.lblMissingFreq.Name = "lblMissingFreq"
        Me.lblMissingFreq.Size = New System.Drawing.Size(48, 16)
        Me.lblMissingFreq.TabIndex = 13
        Me.lblMissingFreq.Text = "0"
        Me.lblMissingFreq.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.ForeColor = System.Drawing.Color.Blue
        Me.Label11.Location = New System.Drawing.Point(16, 240)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(120, 16)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Missing Frequency:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMissingCap
        '
        Me.lblMissingCap.ForeColor = System.Drawing.Color.Blue
        Me.lblMissingCap.Location = New System.Drawing.Point(144, 216)
        Me.lblMissingCap.Name = "lblMissingCap"
        Me.lblMissingCap.Size = New System.Drawing.Size(48, 16)
        Me.lblMissingCap.TabIndex = 11
        Me.lblMissingCap.Text = "0"
        Me.lblMissingCap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(16, 216)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(120, 16)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Missing Capcode:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFileQty
        '
        Me.lblFileQty.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblFileQty.Location = New System.Drawing.Point(144, 120)
        Me.lblFileQty.Name = "lblFileQty"
        Me.lblFileQty.Size = New System.Drawing.Size(48, 16)
        Me.lblFileQty.TabIndex = 9
        Me.lblFileQty.Text = "0"
        Me.lblFileQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMissingBaud
        '
        Me.lblMissingBaud.ForeColor = System.Drawing.Color.Blue
        Me.lblMissingBaud.Location = New System.Drawing.Point(144, 192)
        Me.lblMissingBaud.Name = "lblMissingBaud"
        Me.lblMissingBaud.Size = New System.Drawing.Size(48, 16)
        Me.lblMissingBaud.TabIndex = 8
        Me.lblMissingBaud.Text = "0"
        Me.lblMissingBaud.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDuplicateSN
        '
        Me.lblDuplicateSN.ForeColor = System.Drawing.Color.Blue
        Me.lblDuplicateSN.Location = New System.Drawing.Point(144, 168)
        Me.lblDuplicateSN.Name = "lblDuplicateSN"
        Me.lblDuplicateSN.Size = New System.Drawing.Size(48, 16)
        Me.lblDuplicateSN.TabIndex = 7
        Me.lblDuplicateSN.Text = "0"
        Me.lblDuplicateSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMissingSN
        '
        Me.lblMissingSN.ForeColor = System.Drawing.Color.Blue
        Me.lblMissingSN.Location = New System.Drawing.Point(144, 144)
        Me.lblMissingSN.Name = "lblMissingSN"
        Me.lblMissingSN.Size = New System.Drawing.Size(48, 16)
        Me.lblMissingSN.TabIndex = 6
        Me.lblMissingSN.Text = "0"
        Me.lblMissingSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(16, 192)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 16)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Missing Baud Rate:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(16, 168)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(120, 16)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Duplicate S/N:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(16, 144)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Missing S/N:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label1.Location = New System.Drawing.Point(16, 120)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "File Quantity:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFileLoc
        '
        Me.lblFileLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFileLoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblFileLoc.Location = New System.Drawing.Point(8, 64)
        Me.lblFileLoc.Name = "lblFileLoc"
        Me.lblFileLoc.Size = New System.Drawing.Size(184, 48)
        Me.lblFileLoc.TabIndex = 1
        Me.lblFileLoc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmSkyTelLoadASN
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(680, 517)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.gbLoadASNFile})
        Me.Name = "frmSkyTelLoadASN"
        Me.Text = "frmSkyTelLoadASN"
        Me.gbLoadASNFile.ResumeLayout(False)
        CType(Me.dbgData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '***************************************************************
    Private Sub frmSkyTelLoadASN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer = 0

        Try
            _dtData = New DataTable()
            _strArrHeader = New String() {"SHIP NUMBER", "FREQUENCY", "CAP CODE", "SERIAL NO.", "BAUD RATE", "BAUD DESCR", "MANUFACTURER", "MODEL CODE", "MODEL DESCRIPTION", "SERVICE TYPE", "SKYTEL EQUIPMENT#"}

            For i = 0 To _strArrHeader.Length - 1
                Generic.AddNewColumnToDataTable(_dtData, _strArrHeader(i), "System.String")
            Next i

            Generic.AddNewColumnToDataTable(_dtData, "freq_id", "System.Int32", "0")
            Generic.AddNewColumnToDataTable(_dtData, "baud_id", "System.Int32", "0")
            Generic.AddNewColumnToDataTable(_dtData, "No SN", "System.Int32", "0")
            Generic.AddNewColumnToDataTable(_dtData, "Duplicate SN", "System.Int32", "0")
            Generic.AddNewColumnToDataTable(_dtData, "No Freq", "System.Int32", "0")
            Generic.AddNewColumnToDataTable(_dtData, "No Cap", "System.Int32", "0")
            Generic.AddNewColumnToDataTable(_dtData, "No Baud", "System.Int32", "0")

            Me._dtWO = New DataTable()
            Generic.AddNewColumnToDataTable(_dtWO, "WO", "System.String")
            Generic.AddNewColumnToDataTable(_dtWO, "WO_ID", "System.Int32", 0)

            _dtFreqs = Generic.GetFreqs(False)
            _dtBauds = _objSkyTel.GetCustPSSBaudMap()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "frmSkyTelLoadASN_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '***************************************************************
    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Try
            ClearCtrlsVars()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Cancel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '***************************************************************
    Private Sub ClearCtrlsVars()
        Try
            Me.lblFileLoc.Text = ""
            Me.lblFileQty.Text = "0"
            Me.lblMissingSN.Text = "0"
            Me.lblDuplicateSN.Text = "0"
            Me.lblMissingBaud.Text = "0"
            Me.lblMissingCap.Text = "0"
            Me.lblMissingFreq.Text = "0"
            Me._dtData.Rows.Clear()
            Me._dtWO.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '***************************************************************
    Private Sub btnBrowseData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseData.Click
        Dim fdOpenFile As OpenFileDialog
        Dim strFilePath As String = ""
        Dim i As Integer = 0
        Dim iTotalDupUnits As Integer = 0

        Try
            fdOpenFile = New OpenFileDialog()
            fdOpenFile.DefaultExt = ".*"
            fdOpenFile.ShowDialog()
            strFilePath = fdOpenFile.FileName

            If strFilePath.Trim.Length = 0 Then
                Exit Sub
            ElseIf strFilePath.Trim.EndsWith(".csv") = False Then
                MessageBox.Show("Incorrect file format. File must be in csv format.", "Information", MessageBoxButtons.OK)
            Else
                Me.ReadDataFrFile(strFilePath)
                If Me._dtData.Rows.Count = 0 Then
                    MessageBox.Show("No record found in the data file.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    Me.lblFileLoc.Text = strFilePath
                    Me.lblFileQty.Text = Me._dtData.Rows.Count
                    Me.lblMissingSN.Text = Me._dtData.Compute("Sum([No SN])", "")
                    Me.lblDuplicateSN.Text = Me._dtData.Compute("Sum([Duplicate SN])", "")
                    Me.lblMissingBaud.Text = Me._dtData.Compute("Sum([No Baud])", "")
                    Me.lblMissingCap.Text = Me._dtData.Compute("Sum([No Cap])", "")
                    Me.lblMissingFreq.Text = Me._dtData.Compute("Sum([No Freq])", "")

                    With Me.dbgData
                        .DataSource = Me._dtData.DefaultView
                        For i = 0 To Me._dtData.Columns.Count - 1
                            .Splits(0).DisplayColumns(i).HeadingStyle.BackColor = Color.Blue
                            .Splits(0).DisplayColumns(i).HeadingStyle.ForeColor = Color.White
                            .Splits(0).DisplayColumns(i).HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
                            .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                            If Me._dtData.Columns(i).Caption = "freq_id" Then .Splits(0).DisplayColumns(i).Visible = False
                            If Me._dtData.Columns(i).Caption = "baud_id" Then .Splits(0).DisplayColumns(i).Visible = False
                        Next i
                    End With
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnBrowseData_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            If Not IsNothing(fdOpenFile) Then
                fdOpenFile.Dispose()
                fdOpenFile = Nothing
            End If
            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '**************************************************************
    Private Sub ReadDataFrFile(ByVal FilePath As String)
        Dim strLineData As String = ""
        Dim strArrData() As String
        Dim objReader As StreamReader
        Dim strField As String = ""

        Try
            objReader = New StreamReader(FilePath)

            'reset datatable
            Me._dtData.Rows.Clear()
            Me._dtWO.Rows.Clear()

            'read header line
            strLineData = Trim(objReader.ReadLine())

            'Loop through File
            While objReader.Peek <> -1

                '**********************************
                'Read a line from Data file
                '**********************************
                strLineData = Trim(objReader.ReadLine())

                If Trim(strLineData) <> "" Then
                    Me.AddRecord(strLineData)
                End If  'check for blank line
            End While

        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(objReader) Then
                objReader.Close()
                objReader = Nothing
            End If
        End Try
    End Sub

    '***************************************************************
    Private Sub AddRecord(ByVal strLineData As String)
        Dim R1, R2 As DataRow
        Dim strArrData() As String
        Dim i As Integer = 0

        Try
            If strLineData.Trim.Length > 0 Then
                strArrData = strLineData.Split(",")
                If strArrData.Length > 0 Then

                    R1 = Me._dtData.NewRow

                    '***************************
                    'assign data to data table
                    '***************************
                    For i = 0 To strArrData.Length - 1
                        If i < Me._strArrHeader.Length Then
                            strArrData(i) = strArrData(i).Trim
                            If strArrData(i).StartsWith("""") Then strArrData(i) = strArrData(i).ToString.Remove(0, 1).Trim
                            If strArrData(i).EndsWith("""") Then strArrData(i) = strArrData(i).ToString.Remove(strArrData(i).ToString.Length - 1, 1).Trim
                            R1(i) = strArrData(i).ToString.Trim
                        End If
                    Next i

                    '*****************
                    'Set discrepancy
                    '*****************
                    If R1("SERIAL NO.").ToString.Trim.Length = 0 Then R1("No SN") = 1
                    If R1("FREQUENCY").ToString.Trim.Length = 0 Then R1("No Freq") = 1
                    If R1("CAP CODE").ToString.Trim.Length = 0 Then R1("No Cap") = 1
                    If R1("BAUD RATE").ToString.Trim.Length = 0 Then R1("No Baud") = 1

                    If R1("SERIAL NO.").ToString.Trim.Length > 0 Then
                        If Me._dtData.Select("[SERIAL NO.] = '" & R1("SERIAL NO.").ToString.Trim & "'").Length > 1 Then R1("Duplicate SN") = 1
                    End If

                    '*************************************
                    'Assign baud rate and frequency id
                    '*************************************
                    If Me._dtBauds.Select("BaudCode = '" & R1("BAUD RATE") & "'").Length > 0 Then R1("baud_id") = Me._dtBauds.Select("BaudCode = '" & R1("BAUD RATE") & "'")(0)("BaudID")
                    If R1("baud_id") = 0 Then R1("No Baud") = 1
                    If Me._dtFreqs.Select("freq_Number = '" & R1("FREQUENCY") & "'").Length > 0 Then R1("freq_id") = Me._dtFreqs.Select("freq_Number = '" & R1("FREQUENCY") & "'")(0)("freq_id")
                    If R1("freq_id") = 0 Then R1("No Freq") = 1

                    Me._dtData.Rows.Add(R1)

                    '***********************
                    'Create Wo datatable
                    '***********************
                    R2 = _dtWO.NewRow
                    R2("WO") = R1("SHIP NUMBER")
                    If Me._dtWO.Select("WO = '" & R1("SHIP NUMBER") & "'").Length = 0 Then Me._dtWO.Rows.Add(R2)
                    '***********************
                End If  'Check for empty array
            End If
        Catch ex As Exception
            Throw ex
        Finally
            R1 = Nothing
        End Try
    End Sub

    '***************************************************************
    Private Sub btnLoadData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadData.Click
        Dim i As Integer = 0
        Dim strMsg As String = ""

        Try
            If Me._dtData.Rows.Count Then
                Me.Enabled = False
                Cursor.Current = Cursors.Default

                If CInt(Me.lblDuplicateSN.Text) > 0 Or CInt(Me.lblMissingSN.Text) > 0 Then
                    If CInt(Me.lblDuplicateSN.Text) Then strMsg &= "duplicate SN"
                    If CInt(Me.lblMissingSN.Text) Then strMsg &= "and blank SN"
                    MessageBox.Show("This file contains " & strMsg & ". Please contact your supervisor.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    i = Me._objSkyTel.LoadASNData(Me._dtData, Me._dtWO, PSS.Core.ApplicationUser.User, PSS.Core.ApplicationUser.IDuser)

                    If i > 0 Then
                        MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ClearCtrlsVars()
                    End If
                End If
            Else
                MessageBox.Show("No data to load.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "btnLoadData_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '***************************************************************

End Class
