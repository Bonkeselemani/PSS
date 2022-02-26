Option Explicit On 

Imports PSS.Data.Buisness
Imports PSS.Core

Public Class frmHTC_Edit_Function
    Inherits System.Windows.Forms.Form

    Private _objHTC As HTC

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _objHTC = New HTC()
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If

            _objHTC = Nothing
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSN As System.Windows.Forms.TextBox
    Friend WithEvents btnDoIt As System.Windows.Forms.Button
    Friend WithEvents dbgHistory As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents cboFunction As PSS.Gui.Controls.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmHTC_Edit_Function))
        Me.cboFunction = New PSS.Gui.Controls.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnDoIt = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSN = New System.Windows.Forms.TextBox()
        Me.dbgHistory = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        CType(Me.dbgHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboFunction
        '
        Me.cboFunction.AutoComplete = True
        Me.cboFunction.BackColor = System.Drawing.SystemColors.Window
        Me.cboFunction.DropDownWidth = 240
        Me.cboFunction.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFunction.ForeColor = System.Drawing.Color.Black
        Me.cboFunction.Items.AddRange(New Object() {"Unbill RUR and Send to Diagnostic", "Delete Last Test Record"})
        Me.cboFunction.Location = New System.Drawing.Point(8, 32)
        Me.cboFunction.MaxDropDownItems = 30
        Me.cboFunction.Name = "cboFunction"
        Me.cboFunction.Size = New System.Drawing.Size(240, 21)
        Me.cboFunction.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(8, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(216, 16)
        Me.Label5.TabIndex = 85
        Me.Label5.Text = "Select Function You Want to Do?:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'btnDoIt
        '
        Me.btnDoIt.BackColor = System.Drawing.Color.Red
        Me.btnDoIt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDoIt.ForeColor = System.Drawing.Color.White
        Me.btnDoIt.Location = New System.Drawing.Point(8, 111)
        Me.btnDoIt.Name = "btnDoIt"
        Me.btnDoIt.Size = New System.Drawing.Size(240, 40)
        Me.btnDoIt.TabIndex = 87
        Me.btnDoIt.Text = "JUST DO IT"
        Me.btnDoIt.Visible = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(10, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 16)
        Me.Label1.TabIndex = 89
        Me.Label1.Text = "SN :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'txtSN
        '
        Me.txtSN.BackColor = System.Drawing.Color.White
        Me.txtSN.Location = New System.Drawing.Point(48, 66)
        Me.txtSN.MaxLength = 15
        Me.txtSN.Name = "txtSN"
        Me.txtSN.Size = New System.Drawing.Size(200, 20)
        Me.txtSN.TabIndex = 2
        Me.txtSN.Text = ""
        '
        'dbgHistory
        '
        Me.dbgHistory.AllowUpdate = False
        Me.dbgHistory.AlternatingRows = True
        Me.dbgHistory.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.dbgHistory.FilterBar = True
        Me.dbgHistory.GroupByCaption = "Drag a column header here to group by that column"
        Me.dbgHistory.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.dbgHistory.Location = New System.Drawing.Point(8, 168)
        Me.dbgHistory.Name = "dbgHistory"
        Me.dbgHistory.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgHistory.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgHistory.PreviewInfo.ZoomFactor = 75
        Me.dbgHistory.Size = New System.Drawing.Size(440, 152)
        Me.dbgHistory.TabIndex = 109
        Me.dbgHistory.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Caption{AlignHorz:Center;}Normal{BackColor:SteelBlue;}Selected{ForeColo" & _
        "r:HighlightText;BackColor:Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{" & _
        "}Style16{}Style17{}Style10{AlignHorz:Near;}Style11{}OddRow{BackColor:LightSteelB" & _
        "lue;}Style13{}Style12{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;" & _
        "}RecordSelector{AlignImage:Center;}Footer{}Style21{}Style20{}Inactive{ForeColor:" & _
        "InactiveCaptionText;BackColor:InactiveCaption;}EvenRow{BackColor:NavajoWhite;}He" & _
        "ading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlTex" & _
        "t;AlignVert:Center;}FilterBar{Font:Microsoft Sans Serif, 9.75pt, style=Bold;Fore" & _
        "Color:Red;BackColor:White;}Style4{}Style9{}Style8{}Style5{}Group{AlignVert:Cente" & _
        "r;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style7{}Style6{}Style1{}Style3{" & _
        "}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" Alternat" & _
        "ingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeigh" & _
        "t=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16""" & _
        " DefRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>1" & _
        "48</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
        "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
        "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
        "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
        """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
        "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
        "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
        """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 436, 148<" & _
        "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
        "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
        "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
        "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
        "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
        "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
        "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
        "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
        "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
        "ultRecSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 436, 148</ClientArea><Pr" & _
        "intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
        "Style21"" /></Blob>"
        '
        'frmHTC_Edit_Function
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(456, 365)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.dbgHistory, Me.Label1, Me.txtSN, Me.btnDoIt, Me.cboFunction, Me.Label5})
        Me.Name = "frmHTC_Edit_Function"
        Me.Text = "HTC Edit Function"
        CType(Me.dbgHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '*******************************************************************
    Private Sub frmHTC_Edit_Function_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Highlight.SetHighLight(Me)
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "frmHTC_Edit_Function_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '*******************************************************************
    Private Sub cboFunction_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFunction.SelectedIndexChanged
        Try
            If Me.cboFunction.SelectedIndex > -1 Then Me.txtSN.Focus()
            Me.txtSN.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "cmbFunction_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '*******************************************************************
    Private Sub txtSN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSN.KeyPress
        Try
            If Not (e.KeyChar.IsLetterOrDigit(e.KeyChar) Or e.KeyChar.IsControl(e.KeyChar)) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtSN_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '*******************************************************************
    Private Sub txtSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyUp
        Try
            If e.KeyValue = 13 Then
                If Me.txtSN.Text.Trim.Length = 0 Then
                    Exit Sub
                Else
                    Select Case Me.cboFunction.SelectedIndex
                        Case 0  'Unbill RUR
                            Me.ValideInputCriteria_RUR(True)
                        Case 1  'Delete last record of test Function
                            Me.ValideInputCriteria_DeleteTestRecord(True)
                        Case Else
                            'DO NOTHING
                    End Select
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '*******************************************************************
    Private Sub btnDoIt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDoIt.Click
        Dim dt As DataTable
        Dim i As Integer = 0
        Dim objDevice As PSS.Rules.Device

        Try
            If Me.txtSN.Text.Trim.Length = 0 Then
                Exit Sub
            Else
                Select Case Me.cboFunction.SelectedIndex
                    Case 0  'Unbill RUR
                        If MessageBox.Show("Are you sure you want to unbill RUR?.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No Then Exit Sub
                        Me.Enabled = False
                        dt = Me.ValideInputCriteria_RUR(False)
                        If Not IsNothing(dt) Then
                            '1) Unbill RUR
                            objDevice = New PSS.Rules.Device(dt.Rows(0)("Device_ID"))
                            objDevice.DeletePart(dt.Rows(0)("Billcode_ID"))
                            objDevice.Update()

                            i = Me._objHTC.UnbillRUR(dt, Global.ApplicationUser.IDuser)
                            If i > 0 Then
                                Me.Enabled = True
                                Me.btnDoIt.Visible = False
                                Me.txtSN.Text = ""
                                Me.txtSN.Focus()
                                MessageBox.Show("Please send the unit back to diagnostic.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                        End If
                    Case 1  'Delete last record of test Function
                        Me.ValideInputCriteria_DeleteTestRecord(True)
                    Case Else
                        'DO NOTHING
                End Select
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnDoIt_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            objDevice.Dispose()
            objDevice = Nothing
            Me.Enabled = True
        End Try
    End Sub

    '*******************************************************************
    Private Function ValideInputCriteria_RUR(ByVal booPostData As Boolean) As DataTable
        Dim dt As DataTable
        Dim i As Integer = 0
        Dim R1 As DataRow
        Dim booResult As Boolean = False
        Try
            dt = Me._objHTC.GetUnbillRURDeviceInfo(Me.txtSN.Text.Trim)
            If dt.Rows.Count = 1 Then
                R1 = dt.Rows(0)
                If R1("Warranty") = "OOW" Then
                    MessageBox.Show("This unit is out of warranty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf R1("Box ID").ToString.Trim.Length > 0 Then
                    MessageBox.Show("This unit already assigned to a box (" & R1("Box ID") & ").", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf R1("Line Completion Date").ToString.Trim.Length > 0 Then
                    MessageBox.Show("This unit already completed by line.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf R1("Dcode_id") = 2942 Then
                    MessageBox.Show("This unit is out of warranty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf R1("BillCode_ID") <> 256 Then    'RUR BILLCODE
                    MessageBox.Show("This unit is out of warranty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    If booPostData = True Then
                        With Me.dbgHistory
                            .DataSource = Nothing
                            .DataSource = dt.DefaultView

                            For i = 0 To Me.dbgHistory.Columns.Count - 1
                                .Splits(0).DisplayColumns(i).Visible = False
                                .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                                .Splits(0).DisplayColumns(i).HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
                                Select Case .Columns(i).Caption
                                    Case "Station"
                                        .Splits(0).DisplayColumns(i).Width = 100
                                        .Splits(0).DisplayColumns(i).Visible = True
                                    Case "RUR Reason"
                                        .Splits(0).DisplayColumns(i).Width = 150
                                        .Splits(0).DisplayColumns(i).Visible = True
                                    Case "Warranty"
                                        .Splits(0).DisplayColumns(i).Width = 60
                                        .Splits(0).DisplayColumns(i).Visible = True
                                    Case "Box ID"
                                        .Splits(0).DisplayColumns(i).Width = 100
                                        .Splits(0).DisplayColumns(i).Visible = True
                                    Case "Line Completion Date"
                                        .Splits(0).DisplayColumns(i).Width = 150
                                        .Splits(0).DisplayColumns(i).Visible = True
                                    Case "PartNumber"
                                        .Splits(0).DisplayColumns(i).Width = 100
                                        .Splits(0).DisplayColumns(i).Visible = True
                                End Select
                            Next i
                        End With
                    End If

                    booResult = True
                    Me.btnDoIt.Visible = True
                End If
            ElseIf dt.Rows.Count > 1 Then
                MessageBox.Show("This unit does not meet RUR criteria. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                MessageBox.Show("This unit does not meet RUR criteria. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

            If booResult = True Then Return dt Else Return Nothing
        Catch ex As Exception
            Throw ex
        Finally
            R1 = Nothing
            Generic.DisposeDT(dt)
        End Try
    End Function

    '*******************************************************************
    Private Sub ValideInputCriteria_DeleteTestRecord(ByVal booPostData As Boolean)
        Try


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '*******************************************************************


End Class
