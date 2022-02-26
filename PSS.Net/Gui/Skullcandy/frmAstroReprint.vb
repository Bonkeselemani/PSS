Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui
    Public Class frmAstroReprint
        Inherits System.Windows.Forms.Form

        Private _iMenuCustID As Integer
        Private _objSkullcandy As Skullcandy
        Private _objSkullcandyRec As SkullcandyRec
        Private _ObjSkullcandyPrint As SkullcandyPrint
        Private _dtPeriod As Integer = 7 '7 days
        Private _ds As New DataSet()
        Private _iMaxDeviceSNCountPerBundle As Integer = 2 'Current defined <> 2. deen to redesign Crystal Report if more than 2
        Private _strLabelProd As String = ""
        Private _strLabelProdDesc As String = ""
        Private _strLabelMasterCode As String = ""
        Private _strOverPackName As String = ""


#Region " Windows Form Designer generated code "

        Public Sub New(ByVal iCustID As Integer, ByVal strScreenName As String)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._iMenuCustID = iCustID
            Me._objSkullcandy = New Skullcandy()
            Me._objSkullcandyRec = New SkullcandyRec()
            Me._ObjSkullcandyPrint = New SkullcandyPrint()
            Me.lblTitle.Text = strScreenName

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
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents btnAllNo As System.Windows.Forms.Button
        Friend WithEvents btnAllYes As System.Windows.Forms.Button
        Friend WithEvents tdgData2 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents tdgData1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents btnLoadData As System.Windows.Forms.Button
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents btnClose As System.Windows.Forms.Button
        Friend WithEvents btnPrintBundleLabels As System.Windows.Forms.Button
        Friend WithEvents btnPrintBoxLabel As System.Windows.Forms.Button
        Friend WithEvents btnPrintBoxNameLabel As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAstroReprint))
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.btnPrintBoxNameLabel = New System.Windows.Forms.Button()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.btnAllNo = New System.Windows.Forms.Button()
            Me.btnPrintBundleLabels = New System.Windows.Forms.Button()
            Me.btnAllYes = New System.Windows.Forms.Button()
            Me.tdgData2 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnPrintBoxLabel = New System.Windows.Forms.Button()
            Me.btnClose = New System.Windows.Forms.Button()
            Me.tdgData1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
            Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.btnLoadData = New System.Windows.Forms.Button()
            Me.Panel1.SuspendLayout()
            CType(Me.tdgData2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, (System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTitle.ForeColor = System.Drawing.Color.Blue
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(352, 24)
            Me.lblTitle.TabIndex = 0
            '
            'Panel1
            '
            Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnPrintBoxNameLabel, Me.Label2, Me.Label3, Me.btnAllNo, Me.btnPrintBundleLabels, Me.btnAllYes, Me.tdgData2, Me.btnPrintBoxLabel})
            Me.Panel1.Location = New System.Drawing.Point(248, 32)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(360, 440)
            Me.Panel1.TabIndex = 67
            '
            'btnPrintBoxNameLabel
            '
            Me.btnPrintBoxNameLabel.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnPrintBoxNameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPrintBoxNameLabel.ForeColor = System.Drawing.Color.MediumBlue
            Me.btnPrintBoxNameLabel.Location = New System.Drawing.Point(80, 344)
            Me.btnPrintBoxNameLabel.Name = "btnPrintBoxNameLabel"
            Me.btnPrintBoxNameLabel.Size = New System.Drawing.Size(200, 32)
            Me.btnPrintBoxNameLabel.TabIndex = 85
            Me.btnPrintBoxNameLabel.Text = "Print Box Name Label"
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.MidnightBlue
            Me.Label2.Location = New System.Drawing.Point(8, 280)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(24, 16)
            Me.Label2.TabIndex = 84
            Me.Label2.Text = "Label Printer Name: EasyCoder12"
            Me.Label2.Visible = False
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.ForeColor = System.Drawing.Color.MidnightBlue
            Me.Label3.Location = New System.Drawing.Point(104, 8)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(256, 16)
            Me.Label3.TabIndex = 82
            Me.Label3.Text = "Note: Double Click a row to toggle print Yes or No "
            '
            'btnAllNo
            '
            Me.btnAllNo.BackColor = System.Drawing.Color.LightGray
            Me.btnAllNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnAllNo.ForeColor = System.Drawing.Color.DarkRed
            Me.btnAllNo.Location = New System.Drawing.Point(42, 2)
            Me.btnAllNo.Name = "btnAllNo"
            Me.btnAllNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.btnAllNo.Size = New System.Drawing.Size(40, 22)
            Me.btnAllNo.TabIndex = 81
            Me.btnAllNo.Text = "No"
            '
            'btnPrintBundleLabels
            '
            Me.btnPrintBundleLabels.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnPrintBundleLabels.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPrintBundleLabels.ForeColor = System.Drawing.Color.MediumBlue
            Me.btnPrintBundleLabels.Location = New System.Drawing.Point(80, 384)
            Me.btnPrintBundleLabels.Name = "btnPrintBundleLabels"
            Me.btnPrintBundleLabels.Size = New System.Drawing.Size(200, 32)
            Me.btnPrintBundleLabels.TabIndex = 80
            Me.btnPrintBundleLabels.Text = "Print Bundle (SN) Labels"
            '
            'btnAllYes
            '
            Me.btnAllYes.BackColor = System.Drawing.Color.LightGray
            Me.btnAllYes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnAllYes.ForeColor = System.Drawing.Color.DarkRed
            Me.btnAllYes.Location = New System.Drawing.Point(0, 2)
            Me.btnAllYes.Name = "btnAllYes"
            Me.btnAllYes.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.btnAllYes.Size = New System.Drawing.Size(40, 22)
            Me.btnAllYes.TabIndex = 79
            Me.btnAllYes.Text = "Yes"
            '
            'tdgData2
            '
            Me.tdgData2.AllowColMove = False
            Me.tdgData2.AllowColSelect = False
            Me.tdgData2.AllowFilter = False
            Me.tdgData2.AllowSort = False
            Me.tdgData2.AllowUpdate = False
            Me.tdgData2.AlternatingRows = True
            Me.tdgData2.BackColor = System.Drawing.Color.GhostWhite
            Me.tdgData2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tdgData2.Caption = "Bundles in Box"
            Me.tdgData2.FetchRowStyles = True
            Me.tdgData2.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgData2.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.tdgData2.Location = New System.Drawing.Point(0, 24)
            Me.tdgData2.Name = "tdgData2"
            Me.tdgData2.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgData2.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgData2.PreviewInfo.ZoomFactor = 75
            Me.tdgData2.Size = New System.Drawing.Size(352, 248)
            Me.tdgData2.TabIndex = 78
            Me.tdgData2.Text = "C1TrueDBGrid1"
            Me.tdgData2.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{Font:Microsoft Sans Serif, 8.25pt;AlignHorz:Center;ForeColor:Goldenrod;}Sty" & _
            "le1{}Normal{Font:Microsoft Sans Serif, 8.25pt;}HighlightRow{ForeColor:HighlightT" & _
            "ext;BackColor:Highlight;}Style14{}OddRow{}RecordSelector{AlignImage:Center;}Styl" & _
            "e15{}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:Con" & _
            "trolText;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}Style12{}Sty" & _
            "le13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMov" & _
            "e=""False"" AllowColSelect=""False"" Name="""" AlternatingRowStyle=""True"" CaptionHeigh" & _
            "t=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyles=""True"" Ma" & _
            "rqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Verti" & _
            "calScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>229</Height><CaptionStyle p" & _
            "arent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRo" & _
            "wStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Sty" & _
            "le13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me" & _
            "=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle par" & _
            "ent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" />" & _
            "<OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSe" & _
            "lector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style par" & _
            "ent=""Normal"" me=""Style1"" /><ClientRect>0, 17, 350, 229</ClientRect><BorderSide>0" & _
            "</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></" & _
            "Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""He" & _
            "ading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Capti" & _
            "on"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selecte" & _
            "d"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRo" & _
            "w"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" />" & _
            "<Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterB" & _
            "ar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSpli" & _
            "ts><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</Defaul" & _
            "tRecSelWidth><ClientArea>0, 0, 350, 246</ClientArea><PrintPageHeaderStyle parent" & _
            "="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'btnPrintBoxLabel
            '
            Me.btnPrintBoxLabel.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnPrintBoxLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPrintBoxLabel.ForeColor = System.Drawing.Color.MediumBlue
            Me.btnPrintBoxLabel.Location = New System.Drawing.Point(80, 304)
            Me.btnPrintBoxLabel.Name = "btnPrintBoxLabel"
            Me.btnPrintBoxLabel.Size = New System.Drawing.Size(200, 32)
            Me.btnPrintBoxLabel.TabIndex = 73
            Me.btnPrintBoxLabel.Text = "Print Masterpack Label"
            '
            'btnClose
            '
            Me.btnClose.BackColor = System.Drawing.Color.LightSlateGray
            Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClose.ForeColor = System.Drawing.Color.Crimson
            Me.btnClose.Location = New System.Drawing.Point(504, 0)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(96, 28)
            Me.btnClose.TabIndex = 85
            Me.btnClose.Text = "Close"
            '
            'tdgData1
            '
            Me.tdgData1.AllowUpdate = False
            Me.tdgData1.AlternatingRows = True
            Me.tdgData1.BackColor = System.Drawing.Color.GhostWhite
            Me.tdgData1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tdgData1.FetchRowStyles = True
            Me.tdgData1.FilterBar = True
            Me.tdgData1.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgData1.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.tdgData1.Location = New System.Drawing.Point(8, 104)
            Me.tdgData1.Name = "tdgData1"
            Me.tdgData1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgData1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgData1.PreviewInfo.ZoomFactor = 75
            Me.tdgData1.Size = New System.Drawing.Size(224, 368)
            Me.tdgData1.TabIndex = 66
            Me.tdgData1.Text = "C1TrueDBGrid1"
            Me.tdgData1.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Style9{}Normal{Font:Microsoft Sans Serif, 8.25pt;}Highlig" & _
            "htRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddRow{}RecordSelect" & _
            "or{AlignImage:Center;}Style13{}Heading{Wrap:True;AlignVert:Center;Border:Raised," & _
            ",1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{AlignHorz:N" & _
            "ear;}Style11{}Style14{}Style15{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDB" & _
            "Grid.MergeView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCapti" & _
            "onHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyles=""True"" FilterBar=""True"" Mar" & _
            "queeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Vertic" & _
            "alScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>366</Height><CaptionStyle pa" & _
            "rent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRow" & _
            "Style parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Styl" & _
            "e13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=" & _
            """Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle pare" & _
            "nt=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><" & _
            "OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSel" & _
            "ector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style pare" & _
            "nt=""Normal"" me=""Style1"" /><ClientRect>0, 0, 222, 366</ClientRect><BorderSide>0</" & _
            "BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Sp" & _
            "lits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Head" & _
            "ing"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption" & _
            """ /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected""" & _
            " /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow""" & _
            " /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><S" & _
            "tyle parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar" & _
            """ /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits" & _
            "><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultR" & _
            "ecSelWidth><ClientArea>0, 0, 222, 366</ClientArea><PrintPageHeaderStyle parent=""" & _
            """ me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'dtpStartDate
            '
            Me.dtpStartDate.CalendarFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpStartDate.CustomFormat = "yyyy-MM-dd"
            Me.dtpStartDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpStartDate.Location = New System.Drawing.Point(8, 48)
            Me.dtpStartDate.Name = "dtpStartDate"
            Me.dtpStartDate.Size = New System.Drawing.Size(104, 21)
            Me.dtpStartDate.TabIndex = 103
            Me.dtpStartDate.Value = New Date(2007, 3, 16, 0, 0, 0, 0)
            '
            'dtpEndDate
            '
            Me.dtpEndDate.CalendarFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpEndDate.CustomFormat = "yyyy-MM-dd"
            Me.dtpEndDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpEndDate.Location = New System.Drawing.Point(120, 48)
            Me.dtpEndDate.Name = "dtpEndDate"
            Me.dtpEndDate.Size = New System.Drawing.Size(104, 21)
            Me.dtpEndDate.TabIndex = 105
            Me.dtpEndDate.Value = New Date(2007, 3, 16, 0, 0, 0, 0)
            '
            'Label5
            '
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.MidnightBlue
            Me.Label5.Location = New System.Drawing.Point(8, 34)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(48, 16)
            Me.Label5.TabIndex = 104
            Me.Label5.Text = "Start"
            '
            'Label6
            '
            Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.MidnightBlue
            Me.Label6.Location = New System.Drawing.Point(120, 34)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(40, 16)
            Me.Label6.TabIndex = 106
            Me.Label6.Text = "End"
            '
            'btnLoadData
            '
            Me.btnLoadData.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnLoadData.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnLoadData.ForeColor = System.Drawing.Color.MediumBlue
            Me.btnLoadData.Location = New System.Drawing.Point(8, 72)
            Me.btnLoadData.Name = "btnLoadData"
            Me.btnLoadData.Size = New System.Drawing.Size(120, 32)
            Me.btnLoadData.TabIndex = 88
            Me.btnLoadData.Text = "Load Box Data"
            '
            'frmAstroReprint
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.Lavender
            Me.ClientSize = New System.Drawing.Size(602, 488)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.dtpStartDate, Me.dtpEndDate, Me.Label5, Me.Label6, Me.Panel1, Me.tdgData1, Me.lblTitle, Me.btnLoadData, Me.btnClose})
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Name = "frmAstroReprint"
            Me.Panel1.ResumeLayout(False)
            CType(Me.tdgData2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region


        '******************************************************************
        Private Sub frmAstroReprint_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                Me.CenterToParent()
                Me.MaximizeBox = False : Me.MaximizeBox = False
                Me.ControlBox = False : Me.FormBorderStyle = FormBorderStyle.None

                Me.dtpStartDate.Value = Format(DateAdd(DateInterval.Day, -_dtPeriod, Now), "yyyy-MM-dd")
                Me.dtpEndDate.Value = Format(Now, "yyyy-MM-dd")
                Me.Panel1.Visible = False
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************
        Private Sub btnLoadData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLoadData.Click
            Dim dt As DataTable
            Dim strDateStart As String
            Dim strDateEnd As String

            Try

                If Me.dtpStartDate.Value > Me.dtpEndDate.Value Then
                    strDateEnd = Me.dtpStartDate.Value.ToString("yyyy-MM-dd") & " 23:59:59"
                    strDateStart = Me.dtpEndDate.Value.ToString("yyyy-MM-dd") & " 00:00:00"
                Else
                    strDateStart = Me.dtpStartDate.Value.ToString("yyyy-MM-dd") & " 00:00:00"
                    strDateEnd = Me.dtpEndDate.Value.ToString("yyyy-MM-dd") & " 23:59:59"
                End If

                Me._ds = Me._objSkullcandyRec.Astro_ProdShip_ShippedDeviceData(Me._objSkullcandy.ASTRO_LOCID, strDateStart, strDateEnd)
                If Me._ds.Tables.Count >= 2 Then ' should be two
                    Me.tdgData1.DataSource = Me._ds.Tables("PalletData")
                    Me.tdgData1.Splits(0).DisplayColumns("OverPack_Name").Width = 200
                    Me.tdgData1.Splits(0).DisplayColumns("OverPack_ID").Width = 0
                    Me.tdgData1.Refresh()
                Else
                    Me.tdgData1.DataSource = Nothing
                    MessageBox.Show("No data.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnLoadData_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************
        Private Sub UpdateBoxDetailData(Optional ByVal rowIdx As Integer = 0)
            Try
                Dim iRowID As Integer = Me.tdgData1.Row
                Dim strOverPackName As String = "" ', strProjectID As String = ""
                Dim dt, dtFinal As DataTable
                Dim row, row2 As DataRow ', col As DataColumn
                Dim foundRows As DataRow()
                'Dim rowView As DataRowView
                Dim iOverPackID As Integer = 0, iShip_ID As Integer = 0
                Dim i, j As Integer
                Dim iUniqueShipIDs As New ArrayList()

                Dim strExpression As String = ""

                Me.Panel1.Visible = False

                'Initial select row
                If rowIdx > 0 Then iRowID = rowIdx
                Me.tdgData1.SelectedRows.Add(iRowID) 'select current row

                'Get overpack id
                If Not IsDBNull(Me.tdgData1.Columns("OverPack_ID").CellText(iRowID)) Then
                    iOverPackID = Me.tdgData1.Columns("OverPack_ID").CellText(iRowID)
                    strOverPackName = Me.tdgData1.Columns("OverPack_Name").CellText(iRowID)
                Else
                    MessageBox.Show("Failed to get Over Pack ID!", "UpdateBoxDetailData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                'Get data for selected OverPack_ID
                strExpression = "OverPack_ID = " & iOverPackID
                foundRows = Me._ds.Tables("DeviceData").Select(strExpression)
                dt = Me._ds.Tables("DeviceData").Clone
                For Each row In foundRows
                    dt.ImportRow(row)
                Next

                'Check ship_ID (one ship_ID is one bundle)
                For Each row In dt.Rows
                    If row.IsNull("Ship_ID") Then
                        MessageBox.Show("Invalid ship ID!", "UpdateBoxDetailData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    ElseIf Not row("Ship_ID") > 0 Then
                        MessageBox.Show("Invalid ship ID!", "UpdateBoxDetailData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    Else
                        If Not iUniqueShipIDs.Contains(row("Ship_ID")) Then
                            iUniqueShipIDs.Add(row("Ship_ID"))
                        End If
                    End If
                Next
                For i = 0 To iUniqueShipIDs.Count - 1
                    iShip_ID = iUniqueShipIDs(i)
                    strExpression = "Ship_ID=" & iShip_ID
                    foundRows = dt.Select(strExpression)
                    If Not foundRows.Length = Me._iMaxDeviceSNCountPerBundle Then
                        MessageBox.Show("Device SN count of a bundle must be 2! Failed!", "UpdateBoxDetailData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If
                Next

                '
                dtFinal = Me.BundleDataTableDefinition(Me._iMaxDeviceSNCountPerBundle)
                For i = 0 To iUniqueShipIDs.Count - 1
                    iShip_ID = iUniqueShipIDs(i)
                    strExpression = "Ship_ID=" & iShip_ID
                    foundRows = dt.Select(strExpression)
                    j = 0
                    row2 = dtFinal.NewRow
                    row2("Print") = "Yes"
                    For Each row In foundRows 'form bundle SNs, label data
                        If j = 0 Then
                            Me._strLabelProd = row("Cust_Model_Desc")
                            Me._strLabelProdDesc = row("Cust_IncomingDesc")
                            Me._strLabelMasterCode = row("Cust_OutGoingDesc")
                            Me._strOverPackName = row("OverPack_Name")
                        End If
                        j += 1
                        row2(Me._objSkullcandy.ASTRO_ShipColPreFix & j.ToString) = row("Device_SN")
                    Next
                    dtFinal.Rows.Add(row2)
                Next

                Me.tdgData2.DataSource = dtFinal
                Me.tdgData2.Splits(0).DisplayColumns("ID").Width = 20
                Me.tdgData2.Splits(0).DisplayColumns("Print").Width = 60
                Me.tdgData2.Splits(0).DisplayColumns(Me._objSkullcandy.ASTRO_ShipColPreFix & 1.ToString).Width = 120
                Me.tdgData2.Splits(0).DisplayColumns(Me._objSkullcandy.ASTRO_ShipColPreFix & 2.ToString).Width = 120

                Me.Panel1.Visible = True

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "UpdateBoxDetailData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************
        Private Function BundleDataTableDefinition(ByVal iSNCountPerBundle As Integer) As DataTable
            Dim dt As New DataTable()
            Dim i As Integer = 0

            dt.Columns.Add("ID", GetType(Integer))
            dt.Columns.Add("Print", GetType(String))
            For i = 1 To iSNCountPerBundle
                dt.Columns.Add(Me._objSkullcandy.ASTRO_ShipColPreFix & i.ToString, GetType(String))
            Next
            dt.Columns("ID").AutoIncrement = True
            dt.Columns("ID").AutoIncrementSeed = 1
            dt.Columns("ID").AutoIncrementStep = 1
            Return dt
        End Function

        '******************************************************************
        Private Sub tdgData1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdgData1.MouseUp

            Try
                If Me.tdgData1.PointAt(e.X, e.Y) = C1.Win.C1TrueDBGrid.PointAtEnum.AtFilterBar Then
                    Exit Sub
                End If
                ' Dim rtype As C1.Win.C1TrueDBGrid.RowTypeEnum = Me.tdgData1.Splits(0).Rows(Me.tdgData1.Row).RowType
                ' MessageBox.Show(rtype.ToString)
                'MessageBox.Show(tdgData1(tdgData1.Row, tdgData1.Col).ToString())

                If Me.tdgData1.RowCount > 0 Then
                    UpdateBoxDetailData()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "tdgData1_MouseUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************
        Private Sub tdgData2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdgData2.DoubleClick
            Dim iRowID As Integer
            Try
                iRowID = Me.tdgData2.Row
                If Me.tdgData2.Columns("Print").CellText(iRowID).ToUpper = "YES" Then
                    Me.tdgData2(iRowID, 1) = "No"
                Else
                    Me.tdgData2(iRowID, 1) = "Yes"
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "tdgData2_DoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************
        Private Sub btnAllYes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAllYes.Click
            Dim iRowID As Integer
            Try
                If Me.tdgData2.RowCount > 0 Then
                    For iRowID = 0 To Me.tdgData2.RowCount - 1
                        Me.tdgData2(iRowID, 1) = "Yes"
                    Next
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnYesNo_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************
        Private Sub btnAllNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAllNo.Click
            Dim iRowID As Integer
            Try

                If Me.tdgData2.RowCount > 0 Then
                    For iRowID = 0 To Me.tdgData2.RowCount - 1
                        Me.tdgData2(iRowID, 1) = "No"
                    Next
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnAllNo_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************
        Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Me.Close()
        End Sub

        '******************************************************************
        Private Sub btnPrintBundleLabels_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrintBundleLabels.Click
            Dim iRowID As Integer
            Try

                If Not Me.tdgData2.RowCount > 0 Then Exit Sub
                For iRowID = 0 To Me.tdgData2.RowCount - 1
                    If Me.tdgData2.Columns("Print").CellText(iRowID).ToUpper = "YES" Then
                        Me._ObjSkullcandyPrint.Print_AstroShipBoxSNLabel(Me.tdgData2.Columns(Me._objSkullcandy.ASTRO_ShipColPreFix & 1.ToString).CellText(iRowID), _
                                                                         Me.tdgData2.Columns(Me._objSkullcandy.ASTRO_ShipColPreFix & 2.ToString).CellText(iRowID), 1)
                    End If
                Next

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnAllNo_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************
        Private Sub btnPrintBoxLabel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrintBoxLabel.Click
            Try

                If Not Me.tdgData2.RowCount > 0 Then Exit Sub
                Me._ObjSkullcandyPrint.Print_AstroShipBoxMasterLabel(Me._strLabelProd, Me._strLabelProdDesc, Me._strLabelMasterCode, _
                                                                     Me._strOverPackName, Me.tdgData2.RowCount, 1)

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnPrintBoxLabel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************
        Private Sub btnPrintBoxNameLabel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrintBoxNameLabel.Click
            Try

                If Not Me.tdgData2.RowCount > 0 Then Exit Sub
                Me._ObjSkullcandyPrint.Print_AstroShipBoxLabel(Me._strOverPackName, 1)

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnPrintBoxNameLabel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class
End Namespace
