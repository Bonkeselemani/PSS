Imports System
Imports System.Data

Imports PSS.Rules.PartsMap
Imports PSS.Data.Buisness

Namespace Gui.TracFone
    Public Class frmBillCodeMap
        Inherits System.Windows.Forms.Form

        Private _objPartsMap As PSS.Data.Buisness.PartsMap
        Private _iBillCodeID As Integer = 0
        Private _iTFB_ID As Integer = 0

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal BillCode_ID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _iBillCodeID = BillCode_ID
            _objPartsMap = New PSS.Data.Buisness.PartsMap()
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
        Friend WithEvents cboBillCode As C1.Win.C1List.C1Combo
        Friend WithEvents lblBillCode As System.Windows.Forms.Label
        Friend WithEvents cboBillCode4Report As C1.Win.C1List.C1Combo
        Friend WithEvents lblBillCode4Report As System.Windows.Forms.Label
        Friend WithEvents btnSave As System.Windows.Forms.Button
        Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents btnSaveClose As System.Windows.Forms.Button
        Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
        Friend WithEvents btnClose As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmBillCodeMap))
            Me.cboBillCode = New C1.Win.C1List.C1Combo()
            Me.lblBillCode = New System.Windows.Forms.Label()
            Me.cboBillCode4Report = New C1.Win.C1List.C1Combo()
            Me.lblBillCode4Report = New System.Windows.Forms.Label()
            Me.btnSave = New System.Windows.Forms.Button()
            Me.TextBox1 = New System.Windows.Forms.TextBox()
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.btnSaveClose = New System.Windows.Forms.Button()
            Me.btnClose = New System.Windows.Forms.Button()
            Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
            CType(Me.cboBillCode, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboBillCode4Report, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'cboBillCode
            '
            Me.cboBillCode.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboBillCode.AutoCompletion = True
            Me.cboBillCode.AutoDropDown = True
            Me.cboBillCode.AutoSelect = True
            Me.cboBillCode.Caption = ""
            Me.cboBillCode.CaptionHeight = 17
            Me.cboBillCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboBillCode.ColumnCaptionHeight = 17
            Me.cboBillCode.ColumnFooterHeight = 17
            Me.cboBillCode.ContentHeight = 16
            Me.cboBillCode.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboBillCode.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboBillCode.EditorFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboBillCode.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboBillCode.EditorHeight = 16
            Me.cboBillCode.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboBillCode.ItemHeight = 15
            Me.cboBillCode.Location = New System.Drawing.Point(120, 88)
            Me.cboBillCode.MatchEntryTimeout = CType(2000, Long)
            Me.cboBillCode.MaxDropDownItems = CType(10, Short)
            Me.cboBillCode.MaxLength = 32767
            Me.cboBillCode.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboBillCode.Name = "cboBillCode"
            Me.cboBillCode.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboBillCode.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboBillCode.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboBillCode.Size = New System.Drawing.Size(272, 22)
            Me.cboBillCode.TabIndex = 1
            Me.cboBillCode.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'lblBillCode
            '
            Me.lblBillCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBillCode.Location = New System.Drawing.Point(120, 72)
            Me.lblBillCode.Name = "lblBillCode"
            Me.lblBillCode.Size = New System.Drawing.Size(112, 16)
            Me.lblBillCode.TabIndex = 20
            Me.lblBillCode.Text = "Bill Code"
            '
            'cboBillCode4Report
            '
            Me.cboBillCode4Report.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboBillCode4Report.AutoCompletion = True
            Me.cboBillCode4Report.AutoDropDown = True
            Me.cboBillCode4Report.AutoSelect = True
            Me.cboBillCode4Report.Caption = ""
            Me.cboBillCode4Report.CaptionHeight = 17
            Me.cboBillCode4Report.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboBillCode4Report.ColumnCaptionHeight = 17
            Me.cboBillCode4Report.ColumnFooterHeight = 17
            Me.cboBillCode4Report.ContentHeight = 16
            Me.cboBillCode4Report.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboBillCode4Report.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboBillCode4Report.EditorFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboBillCode4Report.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboBillCode4Report.EditorHeight = 16
            Me.cboBillCode4Report.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboBillCode4Report.ItemHeight = 15
            Me.cboBillCode4Report.Location = New System.Drawing.Point(120, 136)
            Me.cboBillCode4Report.MatchEntryTimeout = CType(2000, Long)
            Me.cboBillCode4Report.MaxDropDownItems = CType(10, Short)
            Me.cboBillCode4Report.MaxLength = 32767
            Me.cboBillCode4Report.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboBillCode4Report.Name = "cboBillCode4Report"
            Me.cboBillCode4Report.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboBillCode4Report.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboBillCode4Report.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboBillCode4Report.Size = New System.Drawing.Size(272, 22)
            Me.cboBillCode4Report.TabIndex = 2
            Me.cboBillCode4Report.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'lblBillCode4Report
            '
            Me.lblBillCode4Report.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBillCode4Report.Location = New System.Drawing.Point(120, 120)
            Me.lblBillCode4Report.Name = "lblBillCode4Report"
            Me.lblBillCode4Report.Size = New System.Drawing.Size(112, 16)
            Me.lblBillCode4Report.TabIndex = 22
            Me.lblBillCode4Report.Text = "Bill Code for Report"
            '
            'btnSave
            '
            Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSave.Location = New System.Drawing.Point(120, 184)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(72, 40)
            Me.btnSave.TabIndex = 3
            Me.btnSave.Text = "Save"
            Me.ToolTip1.SetToolTip(Me.btnSave, "Create a map and save it")
            '
            'TextBox1
            '
            Me.TextBox1.Location = New System.Drawing.Point(8, 40)
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.Size = New System.Drawing.Size(64, 20)
            Me.TextBox1.TabIndex = 24
            Me.TextBox1.TabStop = False
            Me.TextBox1.Text = "TextBox1"
            '
            'lblTitle
            '
            Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTitle.ForeColor = System.Drawing.Color.SlateBlue
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(640, 32)
            Me.lblTitle.TabIndex = 25
            Me.lblTitle.Text = "Creation of a mapped relationship between a billcode and a code for report"
            '
            'btnSaveClose
            '
            Me.btnSaveClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSaveClose.Location = New System.Drawing.Point(200, 184)
            Me.btnSaveClose.Name = "btnSaveClose"
            Me.btnSaveClose.Size = New System.Drawing.Size(104, 40)
            Me.btnSaveClose.TabIndex = 4
            Me.btnSaveClose.Text = "Save/Close"
            Me.ToolTip1.SetToolTip(Me.btnSaveClose, "Create a map, save it, and close this window")
            '
            'btnClose
            '
            Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClose.Location = New System.Drawing.Point(312, 184)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(80, 40)
            Me.btnClose.TabIndex = 26
            Me.btnClose.Text = "Close"
            Me.ToolTip1.SetToolTip(Me.btnClose, "Close this window")
            '
            'frmBillCodeMap
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(584, 470)
            Me.ControlBox = False
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnClose, Me.btnSaveClose, Me.lblTitle, Me.TextBox1, Me.btnSave, Me.cboBillCode4Report, Me.lblBillCode4Report, Me.cboBillCode, Me.lblBillCode})
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "frmBillCodeMap"
            Me.Text = "BillCodeMap"
            CType(Me.cboBillCode, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboBillCode4Report, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmBillCodeMap_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Try
                Dim dt As DataTable = _objPartsMap.GetBillCodesForReportMappedData(_iBillCodeID)

                Me.TextBox1.Text = _iBillCodeID
                Me.TextBox1.Visible = False
                Me.cboBillCode.Enabled = False
                Me.btnClose.Visible = False
                Me.btnSave.Visible = False

                If dt.Rows.Count > 1 Then
                    MessageBox.Show("Sub frmBillCodeMap_Load: Duplicated billcode found in the mapped table 'TracfoneBillCodeMap'. See IT!")
                ElseIf dt.Rows.Count = 1 Then 'Found a mapped relationship data
                    PopulateBillCodes(_iBillCodeID)
                    _iTFB_ID = dt.Rows(0).Item("tfb_id")
                    PopulateBillCodesForReport(_iTFB_ID)

                    If Me.cboBillCode.SelectedValue = 0 Then
                        MessageBox.Show("Alert: Table 'TracfoneBillCodeMap' as the mapped billcode_id, but can't find  it in table 'lbillcodes'")
                    End If

                    If Me.cboBillCode4Report.SelectedValue = 0 Then
                        MessageBox.Show("Alert: Table 'TracfoneBillCodeMap' as the mapped tfb_id, but can't find in table 'tracfonebillcode'")
                    End If
                Else 'No mapped relationship yet
                    PopulateBillCodes(_iBillCodeID)
                    PopulateBillCodesForReport()
                End If

                dt = Nothing

            Catch ex As Exception
                MessageBox.Show("Sub frmBillCodeMap_Load: " & ex.ToString, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try

        End Sub

        Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
            CreateMappedRelationship()
        End Sub

        '***************************************************************************************
        Private Sub CreateMappedRelationship()
            Dim iSelectedBillCodeID As Integer, iSelectedTfbID As Integer, iTfbID_tmp As Integer
            Dim strSelectedBillCodeDesc As String, strSelectedTfbDesc As String, strTfbDesc_tmp As String
            Dim strNewMap As String, i As Integer, iTfbmID As Integer
            Dim dt As DataTable, dt1 As DataTable
            Dim iUserID As Integer = PSS.Core.Global.ApplicationUser.IDuser
            Dim strDTime As String = Format(Now, "yyyy-MM-dd hh:mm:ss")

            Try
                'Check if items are selected 
                If Me.cboBillCode.SelectedValue > 0 Then
                    iSelectedBillCodeID = Me.cboBillCode.SelectedValue
                    strSelectedBillCodeDesc = Me.cboBillCode.Text
                Else
                    MessageBox.Show("Please select a billcode!")
                    Exit Sub
                End If

                If Me.cboBillCode4Report.SelectedValue > 0 Then
                    iSelectedTfbID = Me.cboBillCode4Report.SelectedValue
                    strSelectedTfbDesc = Me.cboBillCode4Report.Text
                Else
                    MessageBox.Show("Please select a code to map for report!")
                    Exit Sub
                End If

                strNewMap = "map between '" & strSelectedBillCodeDesc & "' and '" & strSelectedTfbDesc & "'"

                'Check if the bill code has been mapped already
                dt = _objPartsMap.GetBillCodesForReportMappedData(iSelectedBillCodeID)
                If dt.Rows.Count > 1 Then 'found more than 1 relationship
                    MessageBox.Show("Failed to create this map relation! The billcode '" & strSelectedBillCodeDesc & "' has been mapped more than 1 relationship. See IT!")
                ElseIf dt.Rows.Count = 1 Then 'found 1 relationship
                    iTfbID_tmp = dt.Rows(0).Item("tfb_ID")
                    iTfbmID = dt.Rows(0).Item("tfbm_ID")
                    If iTfbID_tmp = iSelectedTfbID Then 'the same
                        ' MessageBox.Show("The " & strNewMap & " has already been created. Do nothing this time.")
                        Me.DialogResult = DialogResult.OK
                    Else 'not same
                        'Simply just update it
                        i = _objPartsMap.UpdateMapInTracfoneBillCodeMap(iTfbmID, iSelectedBillCodeID, iSelectedTfbID, strDTime, iUserID)
                        If i = 0 Then
                            MessageBox.Show("Failed to replace the invalid existing map with the " & strNewMap & ". See IT!")
                        Else
                            MessageBox.Show("Successfully replaced the invalid existing map with the " & strNewMap & ".")
                            Me.DialogResult = DialogResult.OK
                        End If

                        'No need this
                        'dt1 = _objPartsMap.Found_TFBID(iTfbID_tmp)
                        'If dt1.Rows.Count = 0 Then 'existing map is invalid
                        '    Dim result = MessageBox.Show("An invalid map exists. Do you want to replace it with the " & strNewMap & "? (Please select Yes)", "Make a selection", MessageBoxButtons.YesNo)
                        '    If result = DialogResult.Yes Then
                        '        'replace it now
                        '        i = _objPartsMap.UpdateMapInTracfoneBillCodeMap(iTfbmID, iSelectedBillCodeID, iSelectedTfbID, strDTime, iUserID)
                        '        If i = 0 Then
                        '            MessageBox.Show("Failed to replace the invalid existing map with the " & strNewMap & ". See IT!")
                        '        Else
                        '            MessageBox.Show("Successfully replaced the invalid existing map with the " & strNewMap & ".")
                        '            Me.DialogResult = DialogResult.OK
                        '        End If
                        '    Else
                        '        i = _objPartsMap.DeleteMapInTracfoneBillCodeMap(iTfbmID)
                        '        If i = 0 Then
                        '            MessageBox.Show("You selected to give up to create the " & strNewMap & " this time. Failed to delete the invalid existing map. See IT!")
                        '        Else
                        '            MessageBox.Show("You selected to give up to create the " & strNewMap & " this time. The invalid existing map has been deleted automatically! Please recreate the map again!")
                        '        End If
                        '    End If
                        'Else 'existing map is valid
                        '    strTfbDesc_tmp = dt1.Rows(0).Item("tfb_desc")
                        '    Dim result = MessageBox.Show("Billcode '" & strSelectedBillCodeDesc & "' has mapped to '" & _
                        '                                  strTfbDesc_tmp & "'. Do you want to replace it with the " & strNewMap, "Make a selection", MessageBoxButtons.YesNo)
                        '    If result = DialogResult.Yes Then
                        '        'replace it now
                        '        i = _objPartsMap.UpdateMapInTracfoneBillCodeMap(iTfbmID, iSelectedBillCodeID, iSelectedTfbID, strDTime, iUserID)
                        '        If i = 0 Then
                        '            MessageBox.Show("Failed to replace the existing map with the " & strNewMap & ". See IT!")
                        '        Else
                        '            MessageBox.Show("Successfully replaced the existing map with the " & strNewMap & ".")
                        '            Me.DialogResult = DialogResult.OK
                        '        End If
                        '    Else
                        '        MessageBox.Show("You selected to give up to create the " & strNewMap & " and keep the existing map!")
                        '    End If
                        'End If
                    End If
                Else 'create it
                    i = _objPartsMap.InsertMapInTracfoneBillCodeMap(iSelectedBillCodeID, iSelectedTfbID, strDTime, iUserID)
                    If i = 0 Then
                        MessageBox.Show("Failed to create the " & strNewMap & ". See IT!")
                    Else
                        MessageBox.Show("Successfully created the " & strNewMap & ".")
                        Me.DialogResult = DialogResult.OK
                    End If
                End If

                dt = Nothing : dt1 = Nothing

            Catch ex As Exception
                MessageBox.Show("Sub CreateMappedRelationship: " & ex.ToString, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try

        End Sub

        '***************************************************************************************
        Private Sub PopulateBillCodes(Optional ByVal iSelectedVal As Integer = 0)
            Dim dt As DataTable, row As DataRow, bFoundIt As Boolean = False


            Try

                Me.cboBillCode.DataSource = Nothing
                Generic.DisposeDT(dt)
                dt = Generic.GetBillCodes(True)

                'delete 1 billcode_id=0 row, 0 is conflict with --SELECT-- row, Billcode_Desc=ACGA0009205 never used maybe a test code?
                For Each row In dt.Rows
                    If row("Billcode_ID") = 0 AndAlso row("Billcode_Desc") <> "--SELECT--" Then
                        row.Delete()
                        Exit For
                    End If
                Next
                dt.AcceptChanges()

                'populate
                Misc.PopulateC1DropDownList(Me.cboBillCode, dt, "Billcode_Desc", "Billcode_ID")
                If Not iSelectedVal = 0 Then
                    Me.cboBillCode.SelectedValue = iSelectedVal
                Else
                    For Each row In dt.Rows
                        If iSelectedVal = row("Billcode_ID") AndAlso row("Billcode_Desc") <> "--SELECT--" Then
                            Me.cboBillCode.SelectedValue = iSelectedVal
                            bFoundIt = True
                            Exit For
                        End If
                    Next
                    If bFoundIt = False Then
                        Me.cboBillCode.SelectedValue = 0
                    End If
                End If

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub


        '***************************************************************************************
        Private Sub PopulateBillCodesForReport(Optional ByVal iSelectedVal As Integer = 0)
            Dim dt As DataTable, row As DataRow, bFoundIt As Boolean = False

            Try
                Me.cboBillCode4Report.DataSource = Nothing
                Generic.DisposeDT(dt)
                dt = Generic.GetBillCodesForReport(True)
                Misc.PopulateC1DropDownList(Me.cboBillCode4Report, dt, "tfb_Desc", "tfb_id")

                If Not iSelectedVal = 0 Then
                    Me.cboBillCode4Report.SelectedValue = iSelectedVal
                Else
                    For Each row In dt.Rows
                        If iSelectedVal = row("tfb_id") AndAlso row("tfb_Desc") <> "--SELECT--" Then
                            Me.cboBillCode4Report.SelectedValue = iSelectedVal
                            bFoundIt = True
                            Exit For
                        End If
                    Next
                    If bFoundIt = False Then
                        Me.cboBillCode4Report.SelectedValue = 0
                    End If
                End If


            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub


        Private Sub btnSaveClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveClose.Click
            CreateMappedRelationship()
            If Me.cboBillCode4Report.SelectedValue > 0 Then
                Me.Close()
            End If
        End Sub


        Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Me.Close()
        End Sub
    End Class
End Namespace
