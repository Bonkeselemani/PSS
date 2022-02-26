Option Explicit On 

Imports PSS.Data
Imports PSS.Data.Buisness
Imports PSS.Core

Namespace Gui


    Public Class SyxDataStatus
        Inherits System.Windows.Forms.Form
        Public _booCancel As Boolean = True
        Public _strStatus As String = ""
        Private _objSyx As Syx
        Private _ShowCancelButton As Boolean
        Private _iStatusList As Integer
        Private _booPopulateData As Boolean = False

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal iStatusList As Integer, ByVal ShowCancelButton As Boolean)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call

            Me._iStatusList = iStatusList
            Me._ShowCancelButton = ShowCancelButton

            Me._objSyx = New Syx()

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
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents lblStatus As System.Windows.Forms.Label
        Friend WithEvents cboStatus As C1.Win.C1List.C1Combo
        Friend WithEvents btnComplete As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SyxDataStatus))
            Me.lblStatus = New System.Windows.Forms.Label()
            Me.cboStatus = New C1.Win.C1List.C1Combo()
            Me.btnComplete = New System.Windows.Forms.Button()
            Me.btnCancel = New System.Windows.Forms.Button()
            CType(Me.cboStatus, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblStatus
            '
            Me.lblStatus.BackColor = System.Drawing.Color.Transparent
            Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblStatus.ForeColor = System.Drawing.Color.White
            Me.lblStatus.Location = New System.Drawing.Point(112, 32)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Size = New System.Drawing.Size(176, 32)
            Me.lblStatus.TabIndex = 125
            Me.lblStatus.Text = "Status: "
            Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
            Me.cboStatus.Location = New System.Drawing.Point(112, 64)
            Me.cboStatus.MatchEntryTimeout = CType(2000, Long)
            Me.cboStatus.MaxDropDownItems = CType(5, Short)
            Me.cboStatus.MaxLength = 32767
            Me.cboStatus.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboStatus.Name = "cboStatus"
            Me.cboStatus.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboStatus.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboStatus.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboStatus.Size = New System.Drawing.Size(184, 21)
            Me.cboStatus.TabIndex = 126
            Me.cboStatus.Text = "C1Combo1"
            Me.cboStatus.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'btnComplete
            '
            Me.btnComplete.BackColor = System.Drawing.Color.Navy
            Me.btnComplete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnComplete.ForeColor = System.Drawing.Color.White
            Me.btnComplete.Location = New System.Drawing.Point(216, 104)
            Me.btnComplete.Name = "btnComplete"
            Me.btnComplete.Size = New System.Drawing.Size(96, 24)
            Me.btnComplete.TabIndex = 182
            Me.btnComplete.Text = "Complete"
            '
            'btnCancel
            '
            Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(192, Byte), CType(0, Byte))
            Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCancel.ForeColor = System.Drawing.Color.White
            Me.btnCancel.Location = New System.Drawing.Point(88, 104)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(96, 24)
            Me.btnCancel.TabIndex = 183
            Me.btnCancel.Text = "Cancel"
            '
            'SyxDataStatus
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(128, Byte))
            Me.ClientSize = New System.Drawing.Size(416, 174)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnComplete, Me.btnCancel, Me.lblStatus, Me.cboStatus})
            Me.Name = "SyxDataStatus"
            Me.Text = "SyxDataStatus"
            CType(Me.cboStatus, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub SyxDataStatus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable

            Try
                Me._booPopulateData = True

                Me.btnCancel.Visible = Me._ShowCancelButton
                dt = Me._objSyx.GetSyxStatusList(Me._iStatusList)
                Misc.PopulateC1DropDownList(Me.cboStatus, dt, "Status", "ID")
                Me.cboStatus.SelectedValue = 0
                Me.btnComplete.Visible = False

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error in FormLoad")
            Finally
                Generic.DisposeDT(dt)
                Me._booPopulateData = False
            End Try


        End Sub
        '****************************************************************************************************
        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Me.Close()
        End Sub

        '****************************************************************************************************
        Private Sub btnComplete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComplete.Click
            Me._booCancel = False
            Me._strStatus = Me.cboStatus.Text
            Me.Close()
        End Sub
        '****************************************************************************************************
        Private Sub cboStatus_RowChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboStatus.RowChange
            Try
                Me.btnComplete.Visible = False

                If _booPopulateData = True Then Exit Sub

                If Me.cboStatus.SelectedValue = 0 Then
                    Exit Sub
                Else
                    Me.btnComplete.Visible = True
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "cboStatus_RowChange", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
        '****************************************************************************************************


    End Class
End Namespace