Option Explicit On 

Namespace Gui
    Public Class AccessoryStatus
        Inherits System.Windows.Forms.Form

        Public _booCancel As Boolean = True
        Public _iStatusDCodeID As Integer = 0
        Public _strFailReason As String = ""
        Private _booPopulateData As Boolean = False

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
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents btnCompleted As System.Windows.Forms.Button
        Friend WithEvents txtFailReason As System.Windows.Forms.TextBox
        Friend WithEvents lblFailReason As System.Windows.Forms.Label
        Friend WithEvents cboStatus As C1.Win.C1List.C1Combo
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AccessoryStatus))
            Me.cboStatus = New C1.Win.C1List.C1Combo()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.lblFailReason = New System.Windows.Forms.Label()
            Me.txtFailReason = New System.Windows.Forms.TextBox()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.btnCompleted = New System.Windows.Forms.Button()
            CType(Me.cboStatus, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'cboStatus
            '
            Me.cboStatus.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboStatus.Caption = ""
            Me.cboStatus.CaptionHeight = 17
            Me.cboStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboStatus.ColumnCaptionHeight = 17
            Me.cboStatus.ColumnFooterHeight = 17
            Me.cboStatus.ContentHeight = 15
            Me.cboStatus.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboStatus.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboStatus.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboStatus.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboStatus.EditorHeight = 15
            Me.cboStatus.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboStatus.ItemHeight = 15
            Me.cboStatus.Location = New System.Drawing.Point(112, 16)
            Me.cboStatus.MatchEntryTimeout = CType(2000, Long)
            Me.cboStatus.MaxDropDownItems = CType(5, Short)
            Me.cboStatus.MaxLength = 32767
            Me.cboStatus.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboStatus.Name = "cboStatus"
            Me.cboStatus.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboStatus.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboStatus.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboStatus.Size = New System.Drawing.Size(272, 21)
            Me.cboStatus.TabIndex = 1
            Me.cboStatus.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label11
            '
            Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label11.ForeColor = System.Drawing.Color.Black
            Me.Label11.Location = New System.Drawing.Point(32, 16)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(72, 16)
            Me.Label11.TabIndex = 178
            Me.Label11.Text = "Status :"
            Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblFailReason
            '
            Me.lblFailReason.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblFailReason.ForeColor = System.Drawing.Color.Black
            Me.lblFailReason.Location = New System.Drawing.Point(8, 54)
            Me.lblFailReason.Name = "lblFailReason"
            Me.lblFailReason.Size = New System.Drawing.Size(96, 16)
            Me.lblFailReason.TabIndex = 180
            Me.lblFailReason.Text = "Fail Reason :"
            Me.lblFailReason.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblFailReason.Visible = False
            '
            'txtFailReason
            '
            Me.txtFailReason.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
            Me.txtFailReason.Location = New System.Drawing.Point(112, 54)
            Me.txtFailReason.MaxLength = 30
            Me.txtFailReason.Multiline = True
            Me.txtFailReason.Name = "txtFailReason"
            Me.txtFailReason.Size = New System.Drawing.Size(272, 66)
            Me.txtFailReason.TabIndex = 2
            Me.txtFailReason.Text = ""
            Me.txtFailReason.Visible = False
            '
            'btnCancel
            '
            Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCancel.Location = New System.Drawing.Point(296, 144)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(96, 24)
            Me.btnCancel.TabIndex = 181
            Me.btnCancel.Text = "Cancel"
            '
            'btnCompleted
            '
            Me.btnCompleted.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCompleted.Location = New System.Drawing.Point(144, 144)
            Me.btnCompleted.Name = "btnCompleted"
            Me.btnCompleted.Size = New System.Drawing.Size(96, 24)
            Me.btnCompleted.TabIndex = 3
            Me.btnCompleted.Text = "Completed"
            '
            'AccessoryStatus
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(424, 192)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCompleted, Me.btnCancel, Me.lblFailReason, Me.txtFailReason, Me.cboStatus, Me.Label11})
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "AccessoryStatus"
            Me.ShowInTaskbar = False
            Me.Text = "Accessory Status"
            CType(Me.cboStatus, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '****************************************************************************************************
        Private Sub AccessoryStatus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim objNewTech As New PSS.Data.Buisness.NewTech()
            Dim dt As DataTable

            Try
                dt = objNewTech.GetAccessoryStatus(True)
                _booPopulateData = True
                Misc.PopulateC1DropDownList(Me.cboStatus, dt, "Dcode_LDesc", "Dcode_ID")
                Me.cboStatus.SelectedValue = 3412
                _booPopulateData = False

                Me.btnCompleted.Visible = True
                Me.lblFailReason.Visible = True
                Me.txtFailReason.Visible = True
                Me.txtFailReason.Focus()

            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "AccessoryStatus_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                objNewTech = Nothing : _booPopulateData = False
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '****************************************************************************************************
        Private Sub cboStatus_RowChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboStatus.RowChange
            Try
                Me.btnCompleted.Visible = False
                Me.lblFailReason.Visible = False
                Me.txtFailReason.Visible = False

                If _booPopulateData = True Then Exit Sub

                If Me.cboStatus.SelectedValue = 0 Then
                    Exit Sub
                ElseIf Me.cboStatus.SelectedValue = 3412 Then
                    'Fail
                    Me.btnCompleted.Visible = True
                    Me.lblFailReason.Visible = True
                    Me.txtFailReason.Visible = True
                Else
                    'Missing
                    Me.btnCompleted.Visible = True
                    Me.lblFailReason.Visible = True
                    Me.txtFailReason.Visible = True
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "cboStatus_RowChange", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '****************************************************************************************************
        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Me.Close()
        End Sub

        '****************************************************************************************************
        Private Sub btnCompleted_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompleted.Click
            Me._booCancel = False
            Me._iStatusDCodeID = Me.cboStatus.SelectedValue
            Me._strFailReason = Me.txtFailReason.Text.Trim
            Me.Close()
        End Sub

        '****************************************************************************************************

    End Class
End Namespace