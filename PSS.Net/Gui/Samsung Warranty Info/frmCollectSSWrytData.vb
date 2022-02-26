Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.Samsung

    Public Class frmCollectSSWrytData
        Inherits System.Windows.Forms.Form

        Public _booCancel As Boolean = True
        Public _strYear As String = ""
        Public _strMonth As String = ""
        Public _strLastDateInWarranty As String = Nothing
        Public _iWrty As Integer = -1
        Private _objSSWrtyData As WarrantyClaim.SamSungWrty

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _objSSWrtyData = New WarrantyClaim.SamSungWrty()
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
        Friend WithEvents grbWrtyData As System.Windows.Forms.GroupBox
        Friend WithEvents cboManufMonth As C1.Win.C1List.C1Combo
        Friend WithEvents cboManufYear As C1.Win.C1List.C1Combo
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCollectSSWrytData))
            Me.grbWrtyData = New System.Windows.Forms.GroupBox()
            Me.cboManufMonth = New C1.Win.C1List.C1Combo()
            Me.cboManufYear = New C1.Win.C1List.C1Combo()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.grbWrtyData.SuspendLayout()
            CType(Me.cboManufMonth, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboManufYear, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'grbWrtyData
            '
            Me.grbWrtyData.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboManufMonth, Me.cboManufYear, Me.Label12, Me.Label10})
            Me.grbWrtyData.Location = New System.Drawing.Point(8, 8)
            Me.grbWrtyData.Name = "grbWrtyData"
            Me.grbWrtyData.Size = New System.Drawing.Size(240, 40)
            Me.grbWrtyData.TabIndex = 1
            Me.grbWrtyData.TabStop = False
            '
            'cboManufMonth
            '
            Me.cboManufMonth.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboManufMonth.AutoCompletion = True
            Me.cboManufMonth.AutoDropDown = True
            Me.cboManufMonth.AutoSelect = True
            Me.cboManufMonth.Caption = ""
            Me.cboManufMonth.CaptionHeight = 17
            Me.cboManufMonth.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboManufMonth.ColumnCaptionHeight = 17
            Me.cboManufMonth.ColumnFooterHeight = 17
            Me.cboManufMonth.ColumnHeaders = False
            Me.cboManufMonth.ContentHeight = 15
            Me.cboManufMonth.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboManufMonth.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboManufMonth.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboManufMonth.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboManufMonth.EditorHeight = 15
            Me.cboManufMonth.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboManufMonth.ItemHeight = 15
            Me.cboManufMonth.Location = New System.Drawing.Point(178, 10)
            Me.cboManufMonth.MatchEntryTimeout = CType(2000, Long)
            Me.cboManufMonth.MaxDropDownItems = CType(10, Short)
            Me.cboManufMonth.MaxLength = 32767
            Me.cboManufMonth.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboManufMonth.Name = "cboManufMonth"
            Me.cboManufMonth.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboManufMonth.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboManufMonth.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboManufMonth.Size = New System.Drawing.Size(50, 21)
            Me.cboManufMonth.TabIndex = 2
            Me.cboManufMonth.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:HotTrack;}Style3{}Inactive{ForeColor:InactiveCaptionText;Bac" & _
            "kColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{F" & _
            "oreColor:HighlightText;BackColor:Highlight;}Style9{AlignHorz:Near;}OddRow{}Recor" & _
            "dSelector{AlignImage:Center;}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1" & _
            ", 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{}Style11{}Sty" & _
            "le1{}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" N" & _
            "ame=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=" & _
            """17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 15" & _
            "6</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HSc" & _
            "rollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style9" & _
            """ /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" me" & _
            "=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Head" & _
            "ing"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inact" & _
            "iveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style8" & _
            """ /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle p" & _
            "arent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1L" & _
            "ist.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style pare" & _
            "nt=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""" & _
            "Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""N" & _
            "ormal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=" & _
            """Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Head" & _
            "ing"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><v" & _
            "ertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Defa" & _
            "ultRecSelWidth>16</DefaultRecSelWidth></Blob>"
            '
            'cboManufYear
            '
            Me.cboManufYear.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboManufYear.AutoCompletion = True
            Me.cboManufYear.AutoDropDown = True
            Me.cboManufYear.AutoSelect = True
            Me.cboManufYear.Caption = ""
            Me.cboManufYear.CaptionHeight = 17
            Me.cboManufYear.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboManufYear.ColumnCaptionHeight = 17
            Me.cboManufYear.ColumnFooterHeight = 17
            Me.cboManufYear.ColumnHeaders = False
            Me.cboManufYear.ContentHeight = 15
            Me.cboManufYear.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboManufYear.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboManufYear.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboManufYear.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboManufYear.EditorHeight = 15
            Me.cboManufYear.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboManufYear.ItemHeight = 15
            Me.cboManufYear.Location = New System.Drawing.Point(52, 12)
            Me.cboManufYear.MatchEntryTimeout = CType(2000, Long)
            Me.cboManufYear.MaxDropDownItems = CType(10, Short)
            Me.cboManufYear.MaxLength = 32767
            Me.cboManufYear.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboManufYear.Name = "cboManufYear"
            Me.cboManufYear.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboManufYear.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboManufYear.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboManufYear.Size = New System.Drawing.Size(64, 21)
            Me.cboManufYear.TabIndex = 1
            Me.cboManufYear.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:HotTrack;}Style3{}Inactive{ForeColor:InactiveCaptionText;Bac" & _
            "kColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{F" & _
            "oreColor:HighlightText;BackColor:Highlight;}Style1{}OddRow{}RecordSelector{Align" & _
            "Image:Center;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;Fore" & _
            "Color:ControlText;AlignVert:Center;}Style8{}Style10{}Style11{}Style9{AlignHorz:N" & _
            "ear;}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" N" & _
            "ame=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=" & _
            """17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 15" & _
            "6</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HSc" & _
            "rollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style9" & _
            """ /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" me" & _
            "=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Head" & _
            "ing"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inact" & _
            "iveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style8" & _
            """ /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle p" & _
            "arent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1L" & _
            "ist.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style pare" & _
            "nt=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""" & _
            "Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""N" & _
            "ormal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=" & _
            """Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Head" & _
            "ing"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><v" & _
            "ertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Defa" & _
            "ultRecSelWidth>16</DefaultRecSelWidth></Blob>"
            '
            'Label12
            '
            Me.Label12.BackColor = System.Drawing.Color.Transparent
            Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label12.ForeColor = System.Drawing.Color.White
            Me.Label12.Location = New System.Drawing.Point(128, 14)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(48, 16)
            Me.Label12.TabIndex = 89
            Me.Label12.Text = "Month:"
            Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label10
            '
            Me.Label10.BackColor = System.Drawing.Color.Transparent
            Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.White
            Me.Label10.Location = New System.Drawing.Point(0, 13)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(48, 16)
            Me.Label10.TabIndex = 87
            Me.Label10.Text = "Year:"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnCancel
            '
            Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCancel.ForeColor = System.Drawing.Color.White
            Me.btnCancel.Location = New System.Drawing.Point(192, 56)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(56, 24)
            Me.btnCancel.TabIndex = 2
            Me.btnCancel.Text = "Cancel"
            '
            'frmCollectSSWrytData
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(256, 85)
            Me.ControlBox = False
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancel, Me.grbWrtyData})
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "frmCollectSSWrytData"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Samsung Warranty Data Collection"
            Me.grbWrtyData.ResumeLayout(False)
            CType(Me.cboManufMonth, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboManufYear, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '******************************************************************
        Private Sub frmCollectSSWrytData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable

            Try
                dt = _objSSWrtyData.GetYearList()
                Misc.PopulateC1DropDownList(Me.cboManufYear, dt, "Desc", "ID")

                dt = _objSSWrtyData.Get12MonthList()
                Misc.PopulateC1DropDownList(Me.cboManufMonth, dt, "Desc", "ID")

                Me.cboManufYear.SelectAll()
                Me.cboManufYear.Focus()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmCollectSSWrytData_Load", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '******************************************************************
        Private Sub cboManufYear_Month_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboManufYear.KeyUp, cboManufMonth.KeyUp
            Dim i As Integer
            Try
                If e.KeyCode = Keys.Enter Then
                    If sender.name = "cboManufYear" Then
                        Me.cboManufMonth.SelectAll()
                        Me.cboManufMonth.Focus()
                    ElseIf sender.name = "cboManufMonth" Then
                        If IsNothing(Me.cboManufYear.SelectedValue) Then
                            MessageBox.Show("Please enter Year.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.cboManufYear.SelectAll()
                            Me.cboManufYear.Focus()
                        ElseIf IsNothing(Me.cboManufMonth.SelectedValue) Then
                            MessageBox.Show("Please enter Month.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.cboManufMonth.SelectAll()
                            Me.cboManufMonth.Focus()
                        Else
                            If Me.cboManufYear.DataSource.Table.Select("Desc = '" & Me.cboManufYear.Text & "'").length = 0 Then
                                MessageBox.Show("Please enter valid Year.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.cboManufYear.SelectAll()
                                Me.cboManufYear.Focus()
                                Exit Sub
                            ElseIf Me.cboManufMonth.DataSource.Table.Select("Desc = '" & Me.cboManufMonth.Text & "'").length = 0 Then
                                MessageBox.Show("Please enter valid Month.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.cboManufMonth.SelectAll()
                                Me.cboManufMonth.Focus()
                                Exit Sub
                            End If

                            'Check Warranty
                            Me._iWrty = Me._objSSWrtyData.CheckWrty(Me.cboManufYear.SelectedValue, Me.cboManufMonth.SelectedValue)
                            If Me._iWrty < 0 Then
                                MessageBox.Show("Invalid warranty result please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.cboManufMonth.SelectAll()
                                Me.cboManufMonth.Focus()
                            Else
                                Me._booCancel = False
                                Me._strYear = Mid(Me.cboManufYear.SelectedValue.ToString, 3)
                                Me._strMonth = Me.cboManufMonth.SelectedValue.ToString.PadLeft(2, "0")
                                Me._strLastDateInWarranty = _objSSWrtyData._strLastDateInWarranty
                                Me.Close()
                            End If
                        End If
                    End If  'type of combo box
                End If  'Enter key

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboManufYear_Month_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '******************************************************************
        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Try
                Me._booCancel = True
                Me._strYear = "" : Me._strMonth = "" : Me._iWrty = -1 : Me._strLastDateInWarranty = Nothing

                If Not IsNothing(Me._objSSWrtyData) Then
                    _objSSWrtyData = Nothing
                End If

                Me.Close()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnCancel_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '******************************************************************

    End Class
End Namespace