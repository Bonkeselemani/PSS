Public Class frmRemoveDBRNERReason
    Inherits System.Windows.Forms.Form

    Private _iDeviceID As Integer = 0
    Private _strDeviceSN As String = ""
    Private _strDBRNER As String = ""
    Private _dt As DataTable
    Private _objDBRManifest As Data.Buisness.DBRManifest

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal iDeviceID As Integer, ByVal strDeviceSN As String, _
                   ByVal strDBRNER As String, ByVal dt As DataTable)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me._iDeviceID = iDeviceID
        Me._strDeviceSN = strDeviceSN
        Me._strDBRNER = strDBRNER
        Me._dt = dt
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
    Friend WithEvents btnDBRRemoveReason As System.Windows.Forms.Button
    Friend WithEvents tdgDBRNERReason As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents lblDeviceID As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmRemoveDBRNERReason))
        Me.btnDBRRemoveReason = New System.Windows.Forms.Button()
        Me.tdgDBRNERReason = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.lblDeviceID = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        CType(Me.tdgDBRNERReason, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnDBRRemoveReason
        '
        Me.btnDBRRemoveReason.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDBRRemoveReason.ForeColor = System.Drawing.Color.Brown
        Me.btnDBRRemoveReason.Location = New System.Drawing.Point(40, 176)
        Me.btnDBRRemoveReason.Name = "btnDBRRemoveReason"
        Me.btnDBRRemoveReason.Size = New System.Drawing.Size(184, 48)
        Me.btnDBRRemoveReason.TabIndex = 83
        Me.btnDBRRemoveReason.Text = "Delete Reason"
        '
        'tdgDBRNERReason
        '
        Me.tdgDBRNERReason.AllowColMove = False
        Me.tdgDBRNERReason.AllowColSelect = False
        Me.tdgDBRNERReason.AllowFilter = False
        Me.tdgDBRNERReason.AllowSort = False
        Me.tdgDBRNERReason.AllowUpdate = False
        Me.tdgDBRNERReason.AlternatingRows = True
        Me.tdgDBRNERReason.BackColor = System.Drawing.Color.GhostWhite
        Me.tdgDBRNERReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tdgDBRNERReason.Caption = "Reason"
        Me.tdgDBRNERReason.CaptionHeight = 17
        Me.tdgDBRNERReason.FetchRowStyles = True
        Me.tdgDBRNERReason.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdgDBRNERReason.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.tdgDBRNERReason.Location = New System.Drawing.Point(44, 8)
        Me.tdgDBRNERReason.Name = "tdgDBRNERReason"
        Me.tdgDBRNERReason.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdgDBRNERReason.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdgDBRNERReason.PreviewInfo.ZoomFactor = 75
        Me.tdgDBRNERReason.RowHeight = 15
        Me.tdgDBRNERReason.Size = New System.Drawing.Size(344, 136)
        Me.tdgDBRNERReason.TabIndex = 82
        Me.tdgDBRNERReason.Text = "C1TrueDBGrid1"
        Me.tdgDBRNERReason.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
        "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
        "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
        "tion{AlignHorz:Center;ForeColor:Green;}Style1{}Normal{Font:Microsoft Sans Serif," & _
        " 9.75pt;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style14{}OddR" & _
        "ow{}RecordSelector{AlignImage:Center;}Style15{}Heading{Wrap:True;BackColor:Contr" & _
        "ol;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}Sty" & _
        "le10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style9{}</Data></Styles><Splits>" & _
        "<C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""False"" Name=" & _
        """"" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" Column" & _
        "FooterHeight=""17"" FetchRowStyles=""True"" MarqueeStyle=""DottedCellBorder"" RecordSe" & _
        "lectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGro" & _
        "up=""1""><Height>117</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorS" & _
        "tyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" />" & _
        "<FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" m" & _
        "e=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Hea" & _
        "ding"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><Inac" & _
        "tiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style" & _
        "9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle " & _
        "parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect" & _
        ">0, 17, 342, 117</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</Bord" & _
        "erStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" m" & _
        "e=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""F" & _
        "ooter"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inac" & _
        "tive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor" & _
        """ /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRo" & _
        "w"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSele" & _
        "ctor"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Grou" & _
        "p"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>N" & _
        "one</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 342, 13" & _
        "4</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterSty" & _
        "le parent="""" me=""Style15"" /></Blob>"
        '
        'lblDeviceID
        '
        Me.lblDeviceID.Location = New System.Drawing.Point(24, 232)
        Me.lblDeviceID.Name = "lblDeviceID"
        Me.lblDeviceID.Size = New System.Drawing.Size(88, 16)
        Me.lblDeviceID.TabIndex = 84
        Me.lblDeviceID.Text = "0"
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.DarkBlue
        Me.btnClose.Location = New System.Drawing.Point(232, 176)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(152, 48)
        Me.btnClose.TabIndex = 85
        Me.btnClose.Text = "OK"
        '
        'frmRemoveDBRNERReason
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(434, 256)
        Me.ControlBox = False
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnClose, Me.lblDeviceID, Me.btnDBRRemoveReason, Me.tdgDBRNERReason})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmRemoveDBRNERReason"
        Me.Text = " Select reason to delete"
        CType(Me.tdgDBRNERReason, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    '******************************************************************************************
    Private Sub frmRemoveDBRNERReason_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.lblDeviceID.Text = Me._iDeviceID : Me.lblDeviceID.Visible = False
        Me.tdgDBRNERReason.Caption = Me._strDBRNER & " Reason"
        Me.tdgDBRNERReason.DataSource = Me._dt
        SetGridFormat()
        Me._objDBRManifest = New Data.Buisness.DBRManifest()
        Me.CenterToParent()
    End Sub

    '******************************************************************************************
    Private Sub btnDBRRemoveReason_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDBRRemoveReason.Click
        Dim strData, strHeader As String
        Dim iRow As Integer
        Dim booCompleteHeader As Boolean = False
        Dim col As C1.Win.C1TrueDBGrid.C1DataColumn
        Dim isOk As Boolean = False
        Dim strDeviceCodeIDs As String = ""
        Dim i As Integer = 0
        Dim dtReason As DataTable

        Try
            strData = "" : strHeader = ""

            If Not Me.tdgDBRNERReason.RowCount > 0 Then
                MessageBox.Show("No reason data.", "Remove reason", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                If Me.tdgDBRNERReason.RowCount = 1 AndAlso Me.tdgDBRNERReason.SelectedRows.Count > 0 Then
                    MessageBox.Show("Must have 1 reason. Can't delete the last.", "Remove reason", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf Me.tdgDBRNERReason.RowCount = Me.tdgDBRNERReason.SelectedRows.Count Then
                    MessageBox.Show("Must have 1 reason. Can't delete all.", "Remove reason", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf Me.tdgDBRNERReason.RowCount > 1 AndAlso Me.tdgDBRNERReason.SelectedRows.Count > 0 Then
                    For Each iRow In Me.tdgDBRNERReason.SelectedRows
                        If strDeviceCodeIDs.Trim.Length = 0 Then
                            strDeviceCodeIDs = Me.tdgDBRNERReason.Columns("devicecode_id").CellText(iRow)
                        Else
                            strDeviceCodeIDs = strDeviceCodeIDs & "," & Me.tdgDBRNERReason.Columns("devicecode_id").CellText(iRow)
                        End If
                    Next
                    i = Me._objDBRManifest.DeleteDBRNERFailCode(strDeviceCodeIDs) 'delete
                    dtReason = Me._objDBRManifest.GetDBRNERFailCodeData(Me._iDeviceID)
                    Me.tdgDBRNERReason.DataSource = dtReason
                    SetGridFormat()
                Else
                    MessageBox.Show("Please select a reason to delete.", "Remove reason", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnDBRRemoveReason", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '******************************************************************************************
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Try
            If Me.tdgDBRNERReason.RowCount = 0 Then
                'MessageBox.Show("No reason.", "Remove reason", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DialogResult = Windows.Forms.DialogResult.No
            ElseIf Me.tdgDBRNERReason.RowCount > 1 Then
                MessageBox.Show("Must be 1 reason. Please delete it until 1 reason.", "Remove reason", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf Me.tdgDBRNERReason.RowCount = 1 Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, " btnClose", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub SetGridFormat()
        Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
        'Dim i As Integer = 0

        Try
            With Me.tdgDBRNERReason
                For Each dbgc In .Splits(0).DisplayColumns
                    dbgc.Locked = True
                    'dbgc.AutoSize()
                    .Splits(0).DisplayColumns("Reason").Width = 320
                    .Splits(0).DisplayColumns("DeviceCode_ID").Width = 0
                    .Splits(0).DisplayColumns("Device_ID").Width = 0
                    .Splits(0).DisplayColumns("Dcode_ID").Width = 0
                    '.Splits(0).DisplayColumns("DeviceCode_ID").Visible = False
                    '.Splits(0).DisplayColumns("Device_ID").Locked = False
                    '.Splits(0).DisplayColumns("Dcode_ID").Locked = False
                    'If i > 8 Then .Splits(0).DisplayColumns(i).Width = 30
                    'i += 1
                Next dbgc
            End With

        Catch ex As Exception
            MessageBox.Show(ex.ToString, " btnClose", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End Try
    End Sub
End Class
