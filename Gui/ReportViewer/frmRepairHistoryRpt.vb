Option Explicit On 

Namespace Gui.ReportViewer

    Public Class frmRepairHistoryRpt
        Inherits System.Windows.Forms.Form

        Private _strReportTile As String = ""

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strReportTille As String)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _strReportTile = strReportTille
            Me.lblTitle.Text = _strReportTile
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
        Friend WithEvents btnBAllLCDHistory As System.Windows.Forms.Button
        Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
        Friend WithEvents btnRepHis As System.Windows.Forms.Button
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtColumn As System.Windows.Forms.TextBox
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents cboCustomer As C1.Win.C1List.C1Combo
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmRepairHistoryRpt))
            Me.btnBAllLCDHistory = New System.Windows.Forms.Button()
            Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
            Me.btnRepHis = New System.Windows.Forms.Button()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtColumn = New System.Windows.Forms.TextBox()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.cboCustomer = New C1.Win.C1List.C1Combo()
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.Panel1.SuspendLayout()
            CType(Me.cboCustomer, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'btnBAllLCDHistory
            '
            Me.btnBAllLCDHistory.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnBAllLCDHistory.Location = New System.Drawing.Point(164, 197)
            Me.btnBAllLCDHistory.Name = "btnBAllLCDHistory"
            Me.btnBAllLCDHistory.Size = New System.Drawing.Size(266, 50)
            Me.btnBAllLCDHistory.TabIndex = 2
            Me.btnBAllLCDHistory.Text = "Get All LCD Repair History"
            '
            'btnRepHis
            '
            Me.btnRepHis.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnRepHis.Location = New System.Drawing.Point(164, 276)
            Me.btnRepHis.Name = "btnRepHis"
            Me.btnRepHis.Size = New System.Drawing.Size(266, 50)
            Me.btnRepHis.TabIndex = 3
            Me.btnRepHis.Text = "Repair History"
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.Location = New System.Drawing.Point(10, 59)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(256, 40)
            Me.Label1.TabIndex = 5
            Me.Label1.Text = "Set Starting Column to Generate Data"
            '
            'txtColumn
            '
            Me.txtColumn.AcceptsReturn = True
            Me.txtColumn.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtColumn.Location = New System.Drawing.Point(276, 59)
            Me.txtColumn.Name = "txtColumn"
            Me.txtColumn.Size = New System.Drawing.Size(134, 30)
            Me.txtColumn.TabIndex = 1
            Me.txtColumn.Text = "0"
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.txtColumn, Me.Label3, Me.cboCustomer})
            Me.Panel1.Location = New System.Drawing.Point(10, 59)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(543, 119)
            Me.Panel1.TabIndex = 0
            '
            'Label3
            '
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.Black
            Me.Label3.Location = New System.Drawing.Point(20, 20)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(93, 19)
            Me.Label3.TabIndex = 10
            Me.Label3.Text = "Customer:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboCustomer
            '
            Me.cboCustomer.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboCustomer.Caption = ""
            Me.cboCustomer.CaptionHeight = 17
            Me.cboCustomer.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboCustomer.ColumnCaptionHeight = 17
            Me.cboCustomer.ColumnFooterHeight = 17
            Me.cboCustomer.ContentHeight = 18
            Me.cboCustomer.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboCustomer.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboCustomer.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCustomer.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboCustomer.EditorHeight = 18
            Me.cboCustomer.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboCustomer.ItemHeight = 15
            Me.cboCustomer.Location = New System.Drawing.Point(123, 17)
            Me.cboCustomer.MatchEntryTimeout = CType(2000, Long)
            Me.cboCustomer.MaxDropDownItems = CType(5, Short)
            Me.cboCustomer.MaxLength = 32767
            Me.cboCustomer.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCustomer.Name = "cboCustomer"
            Me.cboCustomer.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCustomer.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCustomer.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCustomer.Size = New System.Drawing.Size(369, 24)
            Me.cboCustomer.TabIndex = 0
            Me.cboCustomer.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            "aultRecSelWidth>20</DefaultRecSelWidth></Blob>"
            '
            'lblTitle
            '
            Me.lblTitle.BackColor = System.Drawing.Color.Transparent
            Me.lblTitle.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold)
            Me.lblTitle.ForeColor = System.Drawing.Color.Yellow
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(297, 28)
            Me.lblTitle.TabIndex = 8
            Me.lblTitle.Text = "Repair History Reports"
            Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'frmRepairHistoryRpt
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(704, 488)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblTitle, Me.Panel1, Me.btnRepHis, Me.btnBAllLCDHistory})
            Me.Name = "frmRepairHistoryRpt"
            Me.Text = "frmRepairHistoryRpt"
            Me.Panel1.ResumeLayout(False)
            CType(Me.cboCustomer, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '*****************************************************************
        Private Sub frmRepairHistoryRpt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable
            Try

                If Me._strReportTile = "Pretest/QC History Report" Then
                    Me.btnRepHis.Visible = False
                    Me.btnBAllLCDHistory.Text = "Pretest/QC History Report"
                End If

                dt = PSS.Data.Buisness.Generic.GetCustomers(True, 1)
                Misc.PopulateC1DropDownList(Me.cboCustomer, dt, "Cust_Name1", "Cust_ID")
                Me.cboCustomer.SelectedValue = 14
                Me.txtColumn.SelectAll()
                txtColumn.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frm_Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '*****************************************************************
        Private Sub btnBAllLCDHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBAllLCDHistory.Click
            Dim strFilePatth As String = ""
            Dim i As Integer
            Dim iStartCol As Integer
            Dim objQC As PSS.Data.Buisness.QC

            Try
                If Me.cboCustomer.SelectedValue = 0 Then
                    MessageBox.Show("Please select customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboCustomer.Focus()
                Else
                    iStartCol = txtColumn.Text

                    If iStartCol > 0 Then
                        Me.OpenFileDialog1.FilterIndex = 1
                        Me.OpenFileDialog1.ShowDialog()
                        strFilePatth = Trim(Me.OpenFileDialog1.FileName)

                        If strFilePatth.Trim.Length = 0 Then Exit Sub

                        Me.Enabled = False
                        Cursor.Current = Cursors.WaitCursor

                        objQC = New PSS.Data.Buisness.QC()

                        If Me._strReportTile = "Pretest/QC History Report" Then
                            i = objQC.CreatePreQCHistoryRpt(iStartCol, strFilePatth, Me.cboCustomer.SelectedValue)
                        Else
                            i = objQC.CreateLCDRepairHistoryRpt(iStartCol, strFilePatth, Me.cboCustomer.SelectedValue)
                        End If

                        If i > 0 Then MsgBox("Completed.", MsgBoxStyle.Information, "Information")
                    Else
                        MsgBox("Please enter a positive number to set starting column", MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error")
                    End If

                    Me.Enabled = True
                    Me.txtColumn.SelectAll()
                    Me.txtColumn.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CheckSN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                objQC = Nothing
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Sub

        '*****************************************************************
        Private Sub btnRepHis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRepHis.Click
            Dim strFilePatth As String = ""
            Dim i As Integer
            Dim iStartCol As Integer
            Dim objQC As PSS.Data.Buisness.QC

            Try
                If Me.cboCustomer.SelectedValue = 0 Then
                    MessageBox.Show("Please select customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboCustomer.Focus()
                Else
                    iStartCol = txtColumn.Text

                    If iStartCol > 0 Then
                        Me.OpenFileDialog1.FilterIndex = 1
                        Me.OpenFileDialog1.ShowDialog()
                        strFilePatth = Trim(Me.OpenFileDialog1.FileName)

                        If strFilePatth.Trim.Length = 0 Then Exit Sub

                        Me.Enabled = False
                        Cursor.Current = Cursors.WaitCursor

                        objQC = New PSS.Data.Buisness.QC()

                        i = objQC.CreateRepairHistoryRpt(iStartCol, strFilePatth, Me.cboCustomer.SelectedValue)

                        If i > 0 Then MsgBox("Completed.", MsgBoxStyle.Information, "Information")
                    Else
                        MsgBox("Please enter a positive number to set starting column", MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error")
                    End If

                    Me.Enabled = True
                    Me.txtColumn.SelectAll()
                    Me.txtColumn.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CheckSN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                objQC = Nothing
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Sub

        '*****************************************************************
        Private Sub cboCustomer_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCustomer.KeyUp
            Try
                If e.KeyCode = Keys.Enter Then
                    If Me.cboCustomer.SelectedValue > 0 Then
                        Me.txtColumn.SelectAll()
                        Me.txtColumn.Focus()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboCustomer_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*****************************************************************

    End Class
End Namespace
