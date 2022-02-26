Public Class frmTFFK_NEW_UPC
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
    Friend WithEvents C1CmbMasterDesc As C1.Win.C1List.C1Combo
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnProcess As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDcodeLong As System.Windows.Forms.TextBox
    Friend WithEvents txtDcodeShort As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTFFK_NEW_UPC))
        Me.C1CmbMasterDesc = New C1.Win.C1List.C1Combo()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDcodeLong = New System.Windows.Forms.TextBox()
        Me.txtDcodeShort = New System.Windows.Forms.TextBox()
        Me.btnProcess = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.C1CmbMasterDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1CmbMasterDesc
        '
        Me.C1CmbMasterDesc.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.C1CmbMasterDesc.AutoCompletion = True
        Me.C1CmbMasterDesc.AutoDropDown = True
        Me.C1CmbMasterDesc.AutoSelect = True
        Me.C1CmbMasterDesc.Caption = ""
        Me.C1CmbMasterDesc.CaptionHeight = 17
        Me.C1CmbMasterDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.C1CmbMasterDesc.ColumnCaptionHeight = 17
        Me.C1CmbMasterDesc.ColumnFooterHeight = 17
        Me.C1CmbMasterDesc.ColumnHeaders = False
        Me.C1CmbMasterDesc.ContentHeight = 15
        Me.C1CmbMasterDesc.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.C1CmbMasterDesc.EditorBackColor = System.Drawing.SystemColors.Window
        Me.C1CmbMasterDesc.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1CmbMasterDesc.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.C1CmbMasterDesc.EditorHeight = 15
        Me.C1CmbMasterDesc.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.C1CmbMasterDesc.ItemHeight = 15
        Me.C1CmbMasterDesc.Location = New System.Drawing.Point(248, 64)
        Me.C1CmbMasterDesc.MatchEntryTimeout = CType(2000, Long)
        Me.C1CmbMasterDesc.MaxDropDownItems = CType(10, Short)
        Me.C1CmbMasterDesc.MaxLength = 32767
        Me.C1CmbMasterDesc.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.C1CmbMasterDesc.Name = "C1CmbMasterDesc"
        Me.C1CmbMasterDesc.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.C1CmbMasterDesc.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.C1CmbMasterDesc.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.C1CmbMasterDesc.Size = New System.Drawing.Size(336, 21)
        Me.C1CmbMasterDesc.TabIndex = 233
        Me.C1CmbMasterDesc.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
        "ultRecSelWidth>17</DefaultRecSelWidth></Blob>"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(8, 64)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(176, 16)
        Me.Label15.TabIndex = 232
        Me.Label15.Text = "Master Code Description"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(8, 168)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(184, 16)
        Me.Label7.TabIndex = 225
        Me.Label7.Text = "Dcode Short Description"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(24, 272)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(168, 16)
        Me.Label1.TabIndex = 235
        Me.Label1.Text = "Dcode Long Description"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDcodeLong
        '
        Me.txtDcodeLong.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDcodeLong.Location = New System.Drawing.Point(248, 264)
        Me.txtDcodeLong.Name = "txtDcodeLong"
        Me.txtDcodeLong.Size = New System.Drawing.Size(344, 26)
        Me.txtDcodeLong.TabIndex = 239
        Me.txtDcodeLong.Text = ""
        '
        'txtDcodeShort
        '
        Me.txtDcodeShort.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDcodeShort.Location = New System.Drawing.Point(248, 160)
        Me.txtDcodeShort.Name = "txtDcodeShort"
        Me.txtDcodeShort.Size = New System.Drawing.Size(336, 26)
        Me.txtDcodeShort.TabIndex = 238
        Me.txtDcodeShort.Text = ""
        '
        'btnProcess
        '
        Me.btnProcess.BackColor = System.Drawing.Color.Green
        Me.btnProcess.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProcess.ForeColor = System.Drawing.Color.White
        Me.btnProcess.Location = New System.Drawing.Point(232, 344)
        Me.btnProcess.Name = "btnProcess"
        Me.btnProcess.Size = New System.Drawing.Size(168, 48)
        Me.btnProcess.TabIndex = 240
        Me.btnProcess.Text = "Save"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(192, 32)
        Me.Label4.TabIndex = 241
        Me.Label4.Text = "New UPC Details"
        '
        'frmTFFK_NEW_UPC
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(616, 406)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label4, Me.btnProcess, Me.txtDcodeLong, Me.txtDcodeShort, Me.Label1, Me.C1CmbMasterDesc, Me.Label15, Me.Label7})
        Me.Name = "frmTFFK_NEW_UPC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NEW UPC"
        CType(Me.C1CmbMasterDesc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private _objAdmin As New PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK_AdminFunctions()
    Private _UserID As Integer = PSS.Core.Global.ApplicationUser.IDuser
    Private _strEmpID As String = PSS.Core.Global.ApplicationUser.NumberEmp
    Private _strUser As String = PSS.Core.Global.ApplicationUser.User
    Private mydt As DataTable

    Private Sub frmTFFK_NEW_UPC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Bind with the combo technology
        mydt = Me._objAdmin.retrieveModeID()
        Me.mydt.LoadDataRow(New Object() {"0", "--Select--"}, True)
        Misc.PopulateC1DropDownList(C1CmbMasterDesc, mydt, "Mcode_desc", "MCode_ID")
        C1CmbMasterDesc.SelectedIndex = -1
    End Sub

    Private Sub C1CmbMasterDesc_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1CmbMasterDesc.SelectedValueChanged

        
    End Sub

    Private Sub btnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess.Click
        Dim productId As Integer = 2
        Dim rows As DataRow
        Dim cols As DataColumn
        Dim i As Integer
        'Dim objAdmin As New frmTffk_Admin()
        'If txtDcodeLong.Text <> "" Or txtDcodeShort.Text <> "" Or C1CmbMasterDesc.SelectedIndex <> -1 Then

        '    Dim result As DialogResult = MessageBox.Show("You will add new detail, Continue ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        '    If result = DialogResult.Yes Then

        '        Dim str As String = "'" & txtDcodeShort.Text & "','" & txtDcodeLong.Text & "','" & productId & "','" & Me.mydt.Rows(C1CmbMasterDesc.SelectedIndex).Item("MCode_ID") & "','" & _UserID & "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "'"

        '        Dim dt As DataTable = Me._objAdmin.saveUPCDetaill(str, txtDcodeShort.Text, txtDcodeLong.Text)

        '        For Each rows In dt.Rows
        '            i = 0
        '            For Each cols In dt.Columns

        '                If i = 0 Then

        '                    MsgBox("New UPC Code Id is " & rows(cols), MsgBoxStyle.Information)
        '                End If
        '                i += 1
        '            Next
        '        Next


        '    End If

        'End If
    End Sub
End Class
