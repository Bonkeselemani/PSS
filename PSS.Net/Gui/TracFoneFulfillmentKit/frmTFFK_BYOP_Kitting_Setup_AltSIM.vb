
Option Explicit On 

Imports PSS.Data.Buisness
Imports System.Text

Namespace Gui.TracFoneFulfillmentKit
    Public Class frmTFFK_BYOP_Kitting_Setup_AltSIM
        Inherits System.Windows.Forms.Form

        Private _iSelectedModel_ID As Integer = 0
        Private _strSelectedModel As String = ""
        Private _bCancelled As Boolean = False
        Private _dtSIM As DataTable
        Private _strSelectedAltSIM_Model As String = ""
        Dim _iIsKeySIM As Integer = 0

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal dtSIM As DataTable, ByVal strSelectedAltSIM_Model As String)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._dtSIM = dtSIM
            Me._strSelectedAltSIM_Model = strSelectedAltSIM_Model

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
        Friend WithEvents tdgSIM As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnOk As System.Windows.Forms.Button
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents label2 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTFFK_BYOP_Kitting_Setup_AltSIM))
            Me.tdgSIM = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnOk = New System.Windows.Forms.Button()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.label2 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            CType(Me.tdgSIM, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'tdgSIM
            '
            Me.tdgSIM.AllowColMove = False
            Me.tdgSIM.AllowColSelect = False
            Me.tdgSIM.AllowFilter = False
            Me.tdgSIM.AllowSort = False
            Me.tdgSIM.AllowUpdate = False
            Me.tdgSIM.BackColor = System.Drawing.Color.White
            Me.tdgSIM.CaptionHeight = 17
            Me.tdgSIM.ColumnHeaders = False
            Me.tdgSIM.FetchRowStyles = True
            Me.tdgSIM.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgSIM.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgSIM.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.tdgSIM.Location = New System.Drawing.Point(16, 43)
            Me.tdgSIM.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Simple
            Me.tdgSIM.Name = "tdgSIM"
            Me.tdgSIM.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgSIM.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgSIM.PreviewInfo.ZoomFactor = 75
            Me.tdgSIM.RowHeight = 15
            Me.tdgSIM.Size = New System.Drawing.Size(472, 96)
            Me.tdgSIM.TabIndex = 0
            Me.tdgSIM.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Style9{}Normal{Font:Tahoma, 8.25pt;}HighlightRow{ForeColo" & _
            "r:HighlightText;BackColor:Highlight;}Style12{}OddRow{}RecordSelector{AlignImage:" & _
            "Center;}Style13{}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;Fo" & _
            "reColor:ControlText;BackColor:Control;}Style8{}Style10{AlignHorz:Near;}Style11{}" & _
            "Style14{}Style15{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView" & _
            " AllowColMove=""False"" AllowColSelect=""False"" Name="""" CaptionHeight=""17"" ColumnCa" & _
            "ptionHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyles=""True"" MarqueeStyle=""Dot" & _
            "tedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=" & _
            """1"" HorizontalScrollGroup=""1""><Height>92</Height><CaptionStyle parent=""Style2"" m" & _
            "e=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""E" & _
            "venRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterS" & _
            "tyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><He" & _
            "adingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRo" & _
            "w"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle par" & _
            "ent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Styl" & _
            "e11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=" & _
            """Style1"" /><ClientRect>0, 0, 468, 92</ClientRect><BorderSide>0</BorderSide><Bord" & _
            "erStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyle" & _
            "s><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style pa" & _
            "rent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style paren" & _
            "t=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent" & _
            "=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent" & _
            "=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Hea" & _
            "ding"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style paren" & _
            "t=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</" & _
            "horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><Clie" & _
            "ntArea>0, 0, 468, 92</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" />" & _
            "<PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'btnOk
            '
            Me.btnOk.BackColor = System.Drawing.Color.DodgerBlue
            Me.btnOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnOk.Location = New System.Drawing.Point(248, 160)
            Me.btnOk.Name = "btnOk"
            Me.btnOk.Size = New System.Drawing.Size(160, 48)
            Me.btnOk.TabIndex = 194
            Me.btnOk.Text = "OK"
            '
            'btnCancel
            '
            Me.btnCancel.BackColor = System.Drawing.Color.DodgerBlue
            Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCancel.Location = New System.Drawing.Point(120, 160)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(112, 48)
            Me.btnCancel.TabIndex = 195
            Me.btnCancel.Text = "Cancel"
            '
            'label2
            '
            Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.label2.ForeColor = System.Drawing.Color.Blue
            Me.label2.Location = New System.Drawing.Point(16, 26)
            Me.label2.Name = "label2"
            Me.label2.Size = New System.Drawing.Size(408, 16)
            Me.label2.TabIndex = 196
            Me.label2.Text = "Please select SIM model from the following list"
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.Location = New System.Drawing.Point(16, 8)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(408, 16)
            Me.Label1.TabIndex = 197
            Me.Label1.Text = "You selected Alt SIM model: "
            '
            'frmTFFK_BYOP_Kitting_Setup_AltSIM
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.LightCyan
            Me.ClientSize = New System.Drawing.Size(504, 230)
            Me.ControlBox = False
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.btnCancel, Me.btnOk, Me.tdgSIM, Me.label2})
            Me.Name = "frmTFFK_BYOP_Kitting_Setup_AltSIM"
            Me.Text = "Select SIM Model"
            CType(Me.tdgSIM, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Public ReadOnly Property bIsCancelled() As Boolean
            Get
                Return Me._bCancelled
            End Get
        End Property

        Public ReadOnly Property getSelectedModel_ID() As Integer
            Get
                Return Me._iSelectedModel_ID
            End Get
        End Property

        Public ReadOnly Property getSelectedModel() As String
            Get
                Return Me._strSelectedModel
            End Get
        End Property

        Public ReadOnly Property getSelectedIsKeySIM() As Integer
            Get
                Return Me._iIsKeySIM
            End Get
        End Property

        Private Sub frmTFFK_BYOP_Kitting_Setup_AltSIM_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                Me.CenterToScreen()
                PSS.Core.Highlight.SetHighLight(Me)

                Me.Label1.Text = Me.Label1.Text.Trim & " " & Me._strSelectedAltSIM_Model

                If Not Me._dtSIM.Rows.Count > 0 Then
                    MessageBox.Show("No SIM card data. Will quit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me._bCancelled = True : Me.Close() 'Quit
                End If

                Me.BindSIM_Data()
                Me.ActiveControl = Me.tdgSIM : Me.tdgSIM.Focus()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub frmTFFK_BYOP_Kitting_Setup_Qty_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub BindSIM_Data()
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
            'Row, Model_ID, Model, Qty, IsBYOP_Model, Model_Desc, Class, Subclass, Techology, UPC, Weight, Height, Width, Length, 
            'UPC_DCode_ID, Class_DCode_ID, SubClass_DCode_ID, Tech_Dcode_ID, Prod_ID, Has_BC, User_ID, UpdateDate, Parent_Model, IsKeySIM, Parent_Model_ID

            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                If Me._dtSIM.Rows.Count > 0 Then
                    With Me.tdgSIM
                        .DataSource = Me._dtSIM.DefaultView
                        For Each dbgc In .Splits(0).DisplayColumns
                            dbgc.Locked = True
                            Select Case dbgc.Name
                                Case "Model", "Qty", "Model_Desc"
                                    dbgc.Visible = True
                                Case Else
                                    dbgc.Visible = False
                            End Select
                            dbgc.AutoSize()
                        Next dbgc
                        .Splits(0).DisplayColumns("Model_Desc").Width = 200
                        '.Splits(0).DisplayColumns("IsKeySIM").FetchStyle = True 'for fetchcellevent to fire
                        '.Splits(0).DisplayColumns("IsBYOP_Model").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        '.Splits(0).DisplayColumns("IsBYOP_Model").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    End With
                    'Else
                    '    MessageBox.Show("No SIM card data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub BindSetupModels", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Me._bCancelled = True
            Me.Close()
        End Sub

        Private Sub tdgSIM_FetchRowStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles tdgSIM.FetchRowStyle
            Dim iKeySIM As Integer = 0

            Try
                iKeySIM = CInt(Me.tdgSIM.Columns("IsKeySIM").CellText(e.Row))
                If iKeySIM = 1 Then
                    e.CellStyle.BackColor = Color.Khaki
                Else
                    e.CellStyle.BackColor = Color.White
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub tdgSIM_FetchRowStyle", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click
            Dim iRow As Integer = 0

            Try
                If Not Me.tdgSIM.SelectedRows.Count = 1 Then
                    MessageBox.Show("Plesae select a row from the SIM list.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                For Each iRow In Me.tdgSIM.SelectedRows 'one row
                    Me._iSelectedModel_ID = Convert.ToInt32(Me.tdgSIM.Columns("Model_ID").CellText(iRow))
                    Me._strSelectedModel = Convert.ToString(Me.tdgSIM.Columns("Model").CellText(iRow))
                    Me._iIsKeySIM = Convert.ToInt32(Me.tdgSIM.Columns("IsKeySIM").CellText(iRow))
                    Me.Close()
                Next

            Catch ex As Exception
                Me._bCancelled = True
                MessageBox.Show(ex.ToString, "Sub btnOk_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class
End Namespace