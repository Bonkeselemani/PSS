
Option Explicit On 

Namespace Gui.HR
    Public Class frmLegiantEEData
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
        Friend WithEvents dgEEData As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmLegiantEEData))
            Me.dgEEData = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            CType(Me.dgEEData, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'dgEEData
            '
            Me.dgEEData.AllowColMove = False
            Me.dgEEData.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
            Me.dgEEData.AllowUpdate = False
            Me.dgEEData.AllowUpdateOnBlur = False
            Me.dgEEData.AlternatingRows = True
            Me.dgEEData.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dgEEData.CaptionHeight = 19
            Me.dgEEData.CollapseColor = System.Drawing.Color.White
            Me.dgEEData.ExpandColor = System.Drawing.Color.White
            Me.dgEEData.FilterBar = True
            Me.dgEEData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dgEEData.ForeColor = System.Drawing.Color.White
            Me.dgEEData.GroupByCaption = "Drag a column header here to group by that column"
            Me.dgEEData.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dgEEData.Location = New System.Drawing.Point(8, 24)
            Me.dgEEData.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.dgEEData.Name = "dgEEData"
            Me.dgEEData.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dgEEData.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dgEEData.PreviewInfo.ZoomFactor = 75
            Me.dgEEData.RowHeight = 20
            Me.dgEEData.Size = New System.Drawing.Size(760, 504)
            Me.dgEEData.TabIndex = 13
            Me.dgEEData.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Font:Tahoma, 8.25pt;ForeC" & _
            "olor:Black;BackColor:AliceBlue;}Selected{ForeColor:HighlightText;BackColor:Highl" & _
            "ight;}Style3{}Inactive{ForeColor:White;BackColor:InactiveCaption;}FilterBar{Font" & _
            ":Microsoft Sans Serif, 8.25pt;ForeColor:Black;BackColor:White;}Footer{Font:Tahom" & _
            "a, 8.25pt, style=Bold, Italic;AlignHorz:Far;ForeColor:White;}Caption{AlignHorz:C" & _
            "enter;ForeColor:MidnightBlue;}Style9{}Normal{Font:Microsoft Sans Serif, 8.25pt, " & _
            "style=Bold;BackColor:LightSteelBlue;ForeColor:White;AlignVert:Center;}HighlightR" & _
            "ow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddRow{Font:Tahoma, 8.2" & _
            "5pt;ForeColor:Black;BackColor:LightBlue;}RecordSelector{AlignImage:Center;ForeCo" & _
            "lor:White;}Style13{}Heading{Wrap:True;Font:Tahoma, 8.25pt, style=Bold;AlignHorz:" & _
            "Center;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:White;BackColor:Ligh" & _
            "tSlateGray;}Style8{}Style10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style16{}" & _
            "Style17{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowCol" & _
            "Move=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""True"" CaptionHei" & _
            "ght=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" Marqu" & _
            "eeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefRecSelWidth=""16"" Vertical" & _
            "ScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>500</Height><CaptionStyle pare" & _
            "nt=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowSt" & _
            "yle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style1" & _
            "3"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""S" & _
            "tyle12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent" & _
            "=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><Od" & _
            "dRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelec" & _
            "tor"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent" & _
            "=""Normal"" me=""Style1"" /><ClientRect>0, 0, 756, 500</ClientRect><BorderSide>0</Bo" & _
            "rderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Spli" & _
            "ts><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Headin" & _
            "g"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" " & _
            "/><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /" & _
            "><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /" & _
            "><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Sty" & _
            "le parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" " & _
            "/><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><" & _
            "horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>16</DefaultRec" & _
            "SelWidth><ClientArea>0, 0, 756, 500</ClientArea><PrintPageHeaderStyle parent="""" " & _
            "me=""Style16"" /><PrintPageFooterStyle parent="""" me=""Style17"" /></Blob>"
            '
            'frmLegiantEEData
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.LightSteelBlue
            Me.ClientSize = New System.Drawing.Size(784, 565)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.dgEEData})
            Me.Name = "frmLegiantEEData"
            Me.Text = "frmLegiantEEData"
            CType(Me.dgEEData, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '***************************************************************************
        Private Sub frmLegiantEEData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As Datatable

            Try
                dt = PSS.Data.HR.EmployeeData.GetEmployeeData()

                Me.dgEEData.DataSource = dt.DefaultView
            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***************************************************************************
    End Class
End Namespace