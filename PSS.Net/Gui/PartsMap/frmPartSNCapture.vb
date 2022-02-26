Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui
    Public Class frmPartSNCapture
        Inherits System.Windows.Forms.Form

        Private _booLoadData As Boolean = False
        Private _objPart As PSS.Data.Buisness.PartsMap

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _objPart = New PSS.Data.Buisness.PartsMap()
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
            _objPart = Nothing
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        Friend WithEvents cboCustomers As C1.Win.C1List.C1Combo
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents cboModels As C1.Win.C1List.C1Combo
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents btnSaveData As System.Windows.Forms.Button
        Friend WithEvents cklstBOM As System.Windows.Forms.CheckedListBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPartSNCapture))
            Me.cboCustomers = New C1.Win.C1List.C1Combo()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.cboModels = New C1.Win.C1List.C1Combo()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.cklstBOM = New System.Windows.Forms.CheckedListBox()
            Me.btnSaveData = New System.Windows.Forms.Button()
            CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboModels, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'cboCustomers
            '
            Me.cboCustomers.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboCustomers.AutoCompletion = True
            Me.cboCustomers.AutoDropDown = True
            Me.cboCustomers.AutoSelect = True
            Me.cboCustomers.Caption = ""
            Me.cboCustomers.CaptionHeight = 17
            Me.cboCustomers.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboCustomers.ColumnCaptionHeight = 17
            Me.cboCustomers.ColumnFooterHeight = 17
            Me.cboCustomers.ContentHeight = 16
            Me.cboCustomers.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboCustomers.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboCustomers.EditorFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCustomers.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboCustomers.EditorHeight = 16
            Me.cboCustomers.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboCustomers.ItemHeight = 15
            Me.cboCustomers.Location = New System.Drawing.Point(8, 24)
            Me.cboCustomers.MatchEntryTimeout = CType(2000, Long)
            Me.cboCustomers.MaxDropDownItems = CType(10, Short)
            Me.cboCustomers.MaxLength = 32767
            Me.cboCustomers.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCustomers.Name = "cboCustomers"
            Me.cboCustomers.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCustomers.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCustomers.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCustomers.Size = New System.Drawing.Size(232, 22)
            Me.cboCustomers.TabIndex = 23
            Me.cboCustomers.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
            "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style9{AlignHorz:Near;}OddRow{}Reco" & _
            "rdSelector{AlignImage:Center;}Heading{Wrap:True;AlignVert:Center;Border:Raised,," & _
            "1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{}Style11{}St" & _
            "yle1{}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" " & _
            "Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight" & _
            "=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 1" & _
            "56</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HS" & _
            "crollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style" & _
            "9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" m" & _
            "e=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Hea" & _
            "ding"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inac" & _
            "tiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style" & _
            "8"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle " & _
            "parent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1" & _
            "List.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style par" & _
            "ent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=" & _
            """Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""" & _
            "Normal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent" & _
            "=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Hea" & _
            "ding"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><" & _
            "vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Def" & _
            "aultRecSelWidth>17</DefaultRecSelWidth></Blob>"
            '
            'Label7
            '
            Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.White
            Me.Label7.Location = New System.Drawing.Point(8, 8)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(112, 16)
            Me.Label7.TabIndex = 24
            Me.Label7.Text = "Customer"
            '
            'cboModels
            '
            Me.cboModels.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboModels.AutoCompletion = True
            Me.cboModels.AutoDropDown = True
            Me.cboModels.AutoSelect = True
            Me.cboModels.Caption = ""
            Me.cboModels.CaptionHeight = 17
            Me.cboModels.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboModels.ColumnCaptionHeight = 17
            Me.cboModels.ColumnFooterHeight = 17
            Me.cboModels.ContentHeight = 16
            Me.cboModels.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboModels.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboModels.EditorFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboModels.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboModels.EditorHeight = 16
            Me.cboModels.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboModels.ItemHeight = 15
            Me.cboModels.Location = New System.Drawing.Point(256, 24)
            Me.cboModels.MatchEntryTimeout = CType(2000, Long)
            Me.cboModels.MaxDropDownItems = CType(10, Short)
            Me.cboModels.MaxLength = 32767
            Me.cboModels.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboModels.Name = "cboModels"
            Me.cboModels.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboModels.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboModels.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboModels.Size = New System.Drawing.Size(264, 22)
            Me.cboModels.TabIndex = 25
            Me.cboModels.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
            "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style1{}OddRow{}RecordSelector{Alig" & _
            "nImage:Center;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;For" & _
            "eColor:ControlText;AlignVert:Center;}Style8{}Style10{}Style11{}Style9{AlignHorz:" & _
            "Near;}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" " & _
            "Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight" & _
            "=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 1" & _
            "56</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HS" & _
            "crollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style" & _
            "9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" m" & _
            "e=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Hea" & _
            "ding"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inac" & _
            "tiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style" & _
            "8"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle " & _
            "parent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1" & _
            "List.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style par" & _
            "ent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=" & _
            """Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""" & _
            "Normal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent" & _
            "=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Hea" & _
            "ding"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><" & _
            "vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Def" & _
            "aultRecSelWidth>17</DefaultRecSelWidth></Blob>"
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(256, 8)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(144, 16)
            Me.Label1.TabIndex = 26
            Me.Label1.Text = "Model"
            '
            'cklstBOM
            '
            Me.cklstBOM.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cklstBOM.HorizontalScrollbar = True
            Me.cklstBOM.Location = New System.Drawing.Point(8, 64)
            Me.cklstBOM.Name = "cklstBOM"
            Me.cklstBOM.Size = New System.Drawing.Size(648, 436)
            Me.cklstBOM.TabIndex = 27
            Me.cklstBOM.ThreeDCheckBoxes = True
            '
            'btnSaveData
            '
            Me.btnSaveData.BackColor = System.Drawing.Color.Green
            Me.btnSaveData.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSaveData.ForeColor = System.Drawing.Color.White
            Me.btnSaveData.Location = New System.Drawing.Point(536, 24)
            Me.btnSaveData.Name = "btnSaveData"
            Me.btnSaveData.Size = New System.Drawing.Size(120, 23)
            Me.btnSaveData.TabIndex = 28
            Me.btnSaveData.Text = "Save"
            '
            'frmPartSNCapture
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(680, 550)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnSaveData, Me.cklstBOM, Me.cboModels, Me.Label1, Me.cboCustomers, Me.Label7})
            Me.Name = "frmPartSNCapture"
            Me.Text = "frmPartSNCapture"
            CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboModels, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '**********************************************************************************
        Private Sub frmPartSNCapture_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable

            Try
                _booLoadData = True
                dt = Generic.GetCustomers(True)
                Misc.PopulateC1DropDownList(Me.cboCustomers, dt, "Cust_Name1", "Cust_ID")
                Me.cboCustomers.SelectedValue = 0
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
                _booLoadData = False
            End Try
        End Sub

        '**********************************************************************************
        Private Sub cboCustomers_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustomers.SelectedValueChanged
            Try
                If _booLoadData = True Then Exit Sub

                Me.cklstBOM.DataSource = Nothing
                Me.cklstBOM.Refresh()

                If Me.cboCustomers.SelectedValue = 0 Then
                    Me.cboModels.DataSource = Nothing
                    Me.cboModels.Refresh()
                Else
                    Me.LoadModels(Me.cboCustomers.SelectedValue)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '**********************************************************************************
        Private Sub LoadModels(ByVal iCustID As Integer)
            Dim dt As DataTable

            Try
                _booLoadData = True
                dt = Me._objPart.GetModelsByCustomer(Me.cboCustomers.SelectedValue, True)
                Misc.PopulateC1DropDownList(Me.cboModels, dt, "Model_Desc", "Model_ID")
                Me.cboModels.SelectedValue = 0
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
                _booLoadData = False
            End Try
        End Sub

        '**********************************************************************************
        Private Sub cboModels_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboModels.SelectedValueChanged
            Try
                If Me._booLoadData = True Then Exit Sub

                Me.cklstBOM.DataSource = Nothing
                Me.cklstBOM.Refresh()

                If Me.cboCustomers.SelectedValue > 0 AndAlso Me.cboModels.SelectedValue > 0 Then
                    Me.LoadBOM(Me.cboModels.SelectedValue)
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '**********************************************************************************
        Private Sub LoadBOM(ByVal iModelID As Integer)
            Dim dt, dtCollectPartSN As DataTable
            Dim i As Integer

            Try
                dt = Me._objPart.GetBOMPartID(Me.cboModels.SelectedValue)
                Me.cklstBOM.DataSource = dt.DefaultView
                Me.cklstBOM.ValueMember = "PSPrice_ID"
                Me.cklstBOM.DisplayMember = "PartNoDesc"

                dtCollectPartSN = Me._objPart.GetPartSNCaptureConfig(Me.cboCustomers.SelectedValue, Me.cboModels.SelectedValue, True)

                For i = 0 To Me.cklstBOM.Items.Count - 1
                    If dtCollectPartSN.Select("PSPrice_ID = " & Me.cklstBOM.Items.Item(i)("PSPrice_ID")).Length > 0 Then Me.cklstBOM.SetItemChecked(i, True)
                Next i
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt) : Generic.DisposeDT(dtCollectPartSN)
            End Try
        End Sub

        '**********************************************************************************
        Private Sub btnSaveData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveData.Click
            Dim dt As New DataTable()
            Dim dc As DataColumn
            Dim i As Integer
            Dim R1 As DataRow

            Try
                dt = Me.cklstBOM.DataSource.Table.Copy
                Generic.AddNewColumnToDataTable(dt, "CollectSN", "System.Int16", "0")

                For i = 0 To Me.cklstBOM.CheckedIndices.Count - 1
                    R1 = dt.Select("PSPrice_ID = " & Me.cklstBOM.Items.Item(Me.cklstBOM.CheckedIndices(i))("PSPrice_ID"))(0)
                    R1.BeginEdit()
                    R1("CollectSN") = 1
                    R1.EndEdit()
                Next i

                i = 0
                i = Me._objPart.SetPartSerialNumberCapture(Me.cboCustomers.SelectedValue, dt)

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnSaveData_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '**********************************************************************************

    End Class
End Namespace