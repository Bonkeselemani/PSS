Option Explicit On 

Imports PSS.Data.Buisness

Public Class frmDockShipping
    Inherits System.Windows.Forms.Form

    Private _objDockShip As DockShipping

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _objDockShip = New DockShipping()
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If

            _objDockShip = Nothing
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents txtTrackNo As System.Windows.Forms.TextBox
    Friend WithEvents lstPackingListNos As System.Windows.Forms.ListBox
    Friend WithEvents cboCarrierType As C1.Win.C1List.C1Combo
    Friend WithEvents txtPackingListNo As System.Windows.Forms.TextBox
    Friend WithEvents dtpDockShipDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnRemoveOne As System.Windows.Forms.Button
    Friend WithEvents btnRemoveAll As System.Windows.Forms.Button
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmDockShipping))
        Me.txtTrackNo = New System.Windows.Forms.TextBox()
        Me.lstPackingListNos = New System.Windows.Forms.ListBox()
        Me.cboCarrierType = New C1.Win.C1List.C1Combo()
        Me.txtPackingListNo = New System.Windows.Forms.TextBox()
        Me.dtpDockShipDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnRemoveOne = New System.Windows.Forms.Button()
        Me.btnRemoveAll = New System.Windows.Forms.Button()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.cboCarrierType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtTrackNo
        '
        Me.txtTrackNo.Location = New System.Drawing.Point(160, 48)
        Me.txtTrackNo.Name = "txtTrackNo"
        Me.txtTrackNo.Size = New System.Drawing.Size(232, 20)
        Me.txtTrackNo.TabIndex = 2
        Me.txtTrackNo.Text = ""
        '
        'lstPackingListNos
        '
        Me.lstPackingListNos.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left)
        Me.lstPackingListNos.Location = New System.Drawing.Point(160, 160)
        Me.lstPackingListNos.Name = "lstPackingListNos"
        Me.lstPackingListNos.Size = New System.Drawing.Size(232, 251)
        Me.lstPackingListNos.TabIndex = 5
        '
        'cboCarrierType
        '
        Me.cboCarrierType.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboCarrierType.AllowDrop = True
        Me.cboCarrierType.AutoCompletion = True
        Me.cboCarrierType.AutoDropDown = True
        Me.cboCarrierType.AutoSelect = True
        Me.cboCarrierType.Caption = ""
        Me.cboCarrierType.CaptionHeight = 17
        Me.cboCarrierType.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboCarrierType.ColumnCaptionHeight = 17
        Me.cboCarrierType.ColumnFooterHeight = 17
        Me.cboCarrierType.ContentHeight = 15
        Me.cboCarrierType.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboCarrierType.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboCarrierType.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCarrierType.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboCarrierType.EditorHeight = 15
        Me.cboCarrierType.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.cboCarrierType.ItemHeight = 15
        Me.cboCarrierType.Location = New System.Drawing.Point(160, 8)
        Me.cboCarrierType.MatchEntryTimeout = CType(2000, Long)
        Me.cboCarrierType.MaxDropDownItems = CType(5, Short)
        Me.cboCarrierType.MaxLength = 32767
        Me.cboCarrierType.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboCarrierType.Name = "cboCarrierType"
        Me.cboCarrierType.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboCarrierType.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboCarrierType.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboCarrierType.Size = New System.Drawing.Size(232, 21)
        Me.cboCarrierType.TabIndex = 2
        Me.cboCarrierType.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Yellow;}Selected{ForeColor:Hi" & _
        "ghlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;" & _
        "BackColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRo" & _
        "w{ForeColor:HighlightText;BackColor:Highlight;}Style1{}OddRow{BackColor:Yellow;}" & _
        "RecordSelector{AlignImage:Center;}Heading{Wrap:True;BackColor:Control;Border:Rai" & _
        "sed,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}Style10{}Style11" & _
        "{}Style9{AlignHorz:Near;}</Data></Styles><Splits><C1.Win.C1List.ListBoxView Allo" & _
        "wColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17""" & _
        " ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Clie" & _
        "ntRect>0, 0, 116, 156</ClientRect><Height>156</Height><VScrollBar><Width>16</Wid" & _
        "th></VScrollBar><HScrollBar><Height>16</Height></HScrollBar><CaptionStyle parent" & _
        "=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyl" & _
        "e parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><Headi" & _
        "ngStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" " & _
        "me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent" & _
        "=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10" & _
        """ /><SelectedStyle parent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""St" & _
        "yle1"" /></C1.Win.C1List.ListBoxView></Splits><NamedStyles><Style parent="""" me=""N" & _
        "ormal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Foote" & _
        "r"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive" & _
        """ /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightR" & _
        "ow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /" & _
        "><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group" & _
        """ /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Mo" & _
        "dified</Layout><DefaultRecSelWidth>16</DefaultRecSelWidth></Blob>"
        '
        'txtPackingListNo
        '
        Me.txtPackingListNo.Location = New System.Drawing.Point(160, 128)
        Me.txtPackingListNo.Name = "txtPackingListNo"
        Me.txtPackingListNo.Size = New System.Drawing.Size(232, 20)
        Me.txtPackingListNo.TabIndex = 4
        Me.txtPackingListNo.Text = ""
        '
        'dtpDockShipDate
        '
        Me.dtpDockShipDate.CustomFormat = ""
        Me.dtpDockShipDate.Location = New System.Drawing.Point(160, 88)
        Me.dtpDockShipDate.Name = "dtpDockShipDate"
        Me.dtpDockShipDate.Size = New System.Drawing.Size(232, 20)
        Me.dtpDockShipDate.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(48, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 16)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Carrier Type: "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(48, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 16)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Tracking #: "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(56, 129)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 16)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Packing List #: "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(48, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 16)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Dock Ship Date: "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.Color.Green
        Me.btnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.ForeColor = System.Drawing.Color.White
        Me.btnUpdate.Location = New System.Drawing.Point(408, 352)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(120, 40)
        Me.btnUpdate.TabIndex = 9
        Me.btnUpdate.Text = "Update"
        '
        'btnRemoveOne
        '
        Me.btnRemoveOne.BackColor = System.Drawing.Color.Red
        Me.btnRemoveOne.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveOne.ForeColor = System.Drawing.Color.White
        Me.btnRemoveOne.Location = New System.Drawing.Point(408, 232)
        Me.btnRemoveOne.Name = "btnRemoveOne"
        Me.btnRemoveOne.Size = New System.Drawing.Size(120, 40)
        Me.btnRemoveOne.TabIndex = 10
        Me.btnRemoveOne.Text = "Remove One Item From List"
        '
        'btnRemoveAll
        '
        Me.btnRemoveAll.BackColor = System.Drawing.Color.Red
        Me.btnRemoveAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveAll.ForeColor = System.Drawing.Color.White
        Me.btnRemoveAll.Location = New System.Drawing.Point(408, 280)
        Me.btnRemoveAll.Name = "btnRemoveAll"
        Me.btnRemoveAll.Size = New System.Drawing.Size(120, 40)
        Me.btnRemoveAll.TabIndex = 11
        Me.btnRemoveAll.Text = "Remove All Items From List"
        '
        'lblCount
        '
        Me.lblCount.BackColor = System.Drawing.Color.Black
        Me.lblCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCount.ForeColor = System.Drawing.Color.Lime
        Me.lblCount.Location = New System.Drawing.Point(408, 160)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(120, 48)
        Me.lblCount.TabIndex = 12
        Me.lblCount.Text = "0"
        Me.lblCount.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Black
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Lime
        Me.Label6.Location = New System.Drawing.Point(432, 160)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 16)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Count"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmDockShipping
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(600, 453)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label6, Me.lblCount, Me.btnRemoveAll, Me.btnRemoveOne, Me.btnUpdate, Me.Label4, Me.Label3, Me.Label2, Me.Label1, Me.dtpDockShipDate, Me.txtPackingListNo, Me.cboCarrierType, Me.lstPackingListNos, Me.txtTrackNo})
        Me.Name = "frmDockShipping"
        Me.Text = "frmDockShipping"
        CType(Me.cboCarrierType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    Private Sub frmDockShipping_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.PopulateCarriers()
            Me.dtpDockShipDate.Value = Now()

            PSS.Core.Highlight.SetHighLight(Me)

            Me.cboCarrierType.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "frmDockShipping_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '******************************************************************
    Private Sub PopulateCarriers()
        Dim dt As DataTable
        Try
            dt = Me._objDockShip.GetShipCarriers(True)
            With Me.cboCarrierType
                .DataSource = Nothing
                .DataSource = dt.DefaultView
                .ValueMember = "SC_ID"
                .DisplayMember = "SC_Desc"
                .Splits(0).DisplayColumns("SC_ID").Visible = False
                .Splits(0).DisplayColumns("SC_Desc").Width = .Width - (.VScrollBar.Width + 4)

                .ColumnHeaders = False
                .SelectedValue = 0
            End With
        Catch ex As Exception
            Throw ex
        Finally
            Generic.DisposeDT(dt)
        End Try
    End Sub

    '******************************************************************
    Private Sub cboCarrierType_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCarrierType.Enter
        Me.cboCarrierType.EditorBackColor = Color.Yellow
    End Sub

    '******************************************************************
    Private Sub cboCarrierType_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCarrierType.Leave
        Me.cboCarrierType.EditorBackColor = Color.White
    End Sub

    '******************************************************************
    Private Sub cboCarrierType_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCarrierType.KeyUp
        Try
            If e.KeyValue = Keys.Enter AndAlso Me.cboCarrierType.SelectedValue > 0 Then Me.txtTrackNo.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "cboCarrierType_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '******************************************************************
    Private Sub txtTrackNo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTrackNo.KeyUp
        Try
            If e.KeyValue = Keys.Enter AndAlso Me.txtTrackNo.Text.Trim.Length > 0 Then Me.dtpDockShipDate.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtTrackNo_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '******************************************************************
    Private Sub dtpDockShipDate_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpDockShipDate.KeyUp
        Try
            If e.KeyValue = Keys.Enter Then Me.txtPackingListNo.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtTrackNo_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '******************************************************************
    Private Sub txtPackingListNo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPackingListNo.KeyUp
        Dim dt As DataTable
        Dim iPackingListID As Integer
        Try
            If e.KeyValue = Keys.Enter Then
                If Me.txtPackingListNo.Text.Trim.Length = 0 Then
                    Exit Sub
                ElseIf Me.cboCarrierType.SelectedValue = 0 Then
                    MessageBox.Show("Please select carrier type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtPackingListNo.Text = ""
                    Me.cboCarrierType.Focus()
                ElseIf Me.txtTrackNo.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter tracking number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtPackingListNo.Text = ""
                    Me.txtTrackNo.Focus()
                ElseIf Me.dtpDockShipDate.Value > Now() Then
                    MessageBox.Show("Dock ship date can't be future.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtPackingListNo.Text = ""
                    Me.dtpDockShipDate.Focus()
                Else
                    iPackingListID = CInt(Me.txtPackingListNo.Text)
                    dt = Me._objDockShip.GetSensusPackingList(iPackingListID)
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("Packing number does not exist in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtPackingListNo.SelectAll()
                    ElseIf Not IsDBNull(dt.Rows(0)("SC_ID")) Then
                        MessageBox.Show("This packing ID is already had dock shipment information.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtPackingListNo.SelectAll()
                    Else
                        Me.lstPackingListNos.Items.Add(Me.txtPackingListNo.Text)
                        Me.lblCount.Text = Me.lstPackingListNos.Items.Count
                        Me.txtPackingListNo.Text = ""
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtTrackNo_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Generic.DisposeDT(dt)
        End Try
    End Sub

    '******************************************************************
    Private Sub btnRemoveOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveOne.Click
        Dim strPackingID As String = ""
        Try
            strPackingID = InputBox("Enter Packing List #:", "Packing List #")

            If strPackingID.Trim.Length = 0 Then Exit Sub

            If Me.lstPackingListNos.Items.IndexOf(strPackingID) > -1 Then
                Me.lstPackingListNos.Items.RemoveAt(Me.lstPackingListNos.Items.IndexOf(strPackingID))
                Me.lstPackingListNos.Refresh()
                Me.lblCount.Text = Me.lstPackingListNos.Items.Count
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnRemoveOne_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.txtPackingListNo.Focus()
        End Try
    End Sub

    '******************************************************************
    Private Sub btnRemoveAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemoveAll.Click
        Try
            If MessageBox.Show("Are you sure you want to remove all items is the list?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No Then Exit Sub

            Me.lstPackingListNos.Items.Clear()
            Me.lstPackingListNos.Refresh()
            Me.lblCount.Text = Me.lstPackingListNos.Items.Count

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnRemoveAll_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.txtPackingListNo.Focus()
        End Try
    End Sub

    '******************************************************************
    Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim strPackingIDs As String = ""
        Dim i As Integer = 0
        Try
            If Me.lstPackingListNos.Items.Count = 0 Then 
                Exit Sub
            ElseIf Me.cboCarrierType.SelectedValue = 0 Then
                MessageBox.Show("Please select carrier type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtPackingListNo.Text = ""
                Me.cboCarrierType.Focus()
            ElseIf Me.txtTrackNo.Text.Trim.Length = 0 Then
                MessageBox.Show("Please enter tracking number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtPackingListNo.Text = ""
                Me.txtTrackNo.Focus()
            ElseIf Me.dtpDockShipDate.Value > Now() Then
                MessageBox.Show("Dock ship date can't be future.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtPackingListNo.Text = ""
                Me.dtpDockShipDate.Focus()
            Else
                If MessageBox.Show("Are you sure you want to update dock shipment information for those packing ID(s)?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No Then Exit Sub

                For i = 0 To Me.lstPackingListNos.Items.Count - 1
                    If strPackingIDs.Trim.Length > 0 Then strPackingIDs &= ", "
                    strPackingIDs &= Me.lstPackingListNos.Items.Item(i)
                Next i

                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                Me._objDockShip.UpdateDockShippingInfo(Me.cboCarrierType.SelectedValue, Me.txtTrackNo.Text, Format(Me.dtpDockShipDate.Value, "yyyy-MM-dd"), strPackingIDs, PSS.Core.ApplicationUser.IDuser)

                'clear controls
                Me.txtPackingListNo.Text = ""
                Me.lstPackingListNos.Items.Clear()
                Me.lstPackingListNos.Refresh()
                Me.lblCount.Text = Me.lstPackingListNos.Items.Count

                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnUpdate_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
            Me.txtPackingListNo.Focus()
        End Try
    End Sub

    '******************************************************************


End Class
