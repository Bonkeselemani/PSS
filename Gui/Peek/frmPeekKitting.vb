Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.Peek
    Public Class frmKittingFunctions
        Inherits System.Windows.Forms.Form

        Private Const _iPeekCustID As Integer = 2288

        Private _iInventorySNID As Integer = 0
        Private _iItemsID As Integer = 0
        Private _bPopulateData As Boolean = False
        Private _iMenuCustID As Integer = 0

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal iCustID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _iMenuCustID = iCustID
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
        Friend WithEvents txtIMEI As System.Windows.Forms.TextBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents lblCurrentModel As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents cboModel As C1.Win.C1List.C1Combo
        Friend WithEvents txtSim As System.Windows.Forms.TextBox
        Friend WithEvents lblFlashModel As System.Windows.Forms.Label
        Friend WithEvents lblSim As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents cboFuncTypes As System.Windows.Forms.ComboBox
        Friend WithEvents btnProcessFunc As System.Windows.Forms.Button
        Friend WithEvents lblCurrentSimNo As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents chkPrintLabel As System.Windows.Forms.CheckBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmKittingFunctions))
            Me.Label5 = New System.Windows.Forms.Label()
            Me.txtIMEI = New System.Windows.Forms.TextBox()
            Me.btnProcessFunc = New System.Windows.Forms.Button()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.lblCurrentModel = New System.Windows.Forms.Label()
            Me.lblFlashModel = New System.Windows.Forms.Label()
            Me.cboModel = New C1.Win.C1List.C1Combo()
            Me.lblSim = New System.Windows.Forms.Label()
            Me.txtSim = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.cboFuncTypes = New System.Windows.Forms.ComboBox()
            Me.lblCurrentSimNo = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.chkPrintLabel = New System.Windows.Forms.CheckBox()
            CType(Me.cboModel, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.Transparent
            Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.White
            Me.Label5.Location = New System.Drawing.Point(16, 74)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(112, 16)
            Me.Label5.TabIndex = 133
            Me.Label5.Text = "Serial Number:"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtIMEI
            '
            Me.txtIMEI.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtIMEI.Location = New System.Drawing.Point(128, 72)
            Me.txtIMEI.Name = "txtIMEI"
            Me.txtIMEI.Size = New System.Drawing.Size(200, 23)
            Me.txtIMEI.TabIndex = 2
            Me.txtIMEI.Text = ""
            '
            'btnProcessFunc
            '
            Me.btnProcessFunc.BackColor = System.Drawing.Color.Green
            Me.btnProcessFunc.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnProcessFunc.ForeColor = System.Drawing.Color.White
            Me.btnProcessFunc.Location = New System.Drawing.Point(128, 280)
            Me.btnProcessFunc.Name = "btnProcessFunc"
            Me.btnProcessFunc.Size = New System.Drawing.Size(200, 40)
            Me.btnProcessFunc.TabIndex = 5
            Me.btnProcessFunc.Text = "Process Now"
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(16, 113)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(112, 16)
            Me.Label4.TabIndex = 136
            Me.Label4.Text = "Current Model:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCurrentModel
            '
            Me.lblCurrentModel.BackColor = System.Drawing.SystemColors.Control
            Me.lblCurrentModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCurrentModel.Location = New System.Drawing.Point(128, 112)
            Me.lblCurrentModel.Name = "lblCurrentModel"
            Me.lblCurrentModel.Size = New System.Drawing.Size(200, 20)
            Me.lblCurrentModel.TabIndex = 137
            Me.lblCurrentModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblFlashModel
            '
            Me.lblFlashModel.BackColor = System.Drawing.Color.Transparent
            Me.lblFlashModel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblFlashModel.ForeColor = System.Drawing.Color.White
            Me.lblFlashModel.Location = New System.Drawing.Point(24, 176)
            Me.lblFlashModel.Name = "lblFlashModel"
            Me.lblFlashModel.Size = New System.Drawing.Size(104, 21)
            Me.lblFlashModel.TabIndex = 126
            Me.lblFlashModel.Text = "New ModeL :"
            Me.lblFlashModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboModel
            '
            Me.cboModel.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboModel.AutoCompletion = True
            Me.cboModel.AutoDropDown = True
            Me.cboModel.AutoSelect = True
            Me.cboModel.Caption = ""
            Me.cboModel.CaptionHeight = 17
            Me.cboModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboModel.ColumnCaptionHeight = 17
            Me.cboModel.ColumnFooterHeight = 17
            Me.cboModel.ColumnHeaders = False
            Me.cboModel.ContentHeight = 15
            Me.cboModel.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboModel.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboModel.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboModel.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboModel.EditorHeight = 15
            Me.cboModel.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboModel.ItemHeight = 15
            Me.cboModel.Location = New System.Drawing.Point(128, 176)
            Me.cboModel.MatchEntryTimeout = CType(2000, Long)
            Me.cboModel.MaxDropDownItems = CType(10, Short)
            Me.cboModel.MaxLength = 32767
            Me.cboModel.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboModel.Name = "cboModel"
            Me.cboModel.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboModel.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboModel.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboModel.Size = New System.Drawing.Size(200, 21)
            Me.cboModel.TabIndex = 3
            Me.cboModel.Visible = False
            Me.cboModel.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'lblSim
            '
            Me.lblSim.BackColor = System.Drawing.Color.Transparent
            Me.lblSim.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSim.ForeColor = System.Drawing.Color.White
            Me.lblSim.Location = New System.Drawing.Point(56, 211)
            Me.lblSim.Name = "lblSim"
            Me.lblSim.Size = New System.Drawing.Size(72, 16)
            Me.lblSim.TabIndex = 135
            Me.lblSim.Text = "SIM #:"
            Me.lblSim.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblSim.Visible = False
            '
            'txtSim
            '
            Me.txtSim.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtSim.Location = New System.Drawing.Point(128, 208)
            Me.txtSim.Name = "txtSim"
            Me.txtSim.Size = New System.Drawing.Size(200, 23)
            Me.txtSim.TabIndex = 4
            Me.txtSim.Text = ""
            Me.txtSim.Visible = False
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(8, 32)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(120, 21)
            Me.Label2.TabIndex = 124
            Me.Label2.Text = "Function Types :"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboFuncTypes
            '
            Me.cboFuncTypes.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboFuncTypes.Items.AddRange(New Object() {"Kitting", "Re-Label", "Update Item #", "Update Sim #"})
            Me.cboFuncTypes.Location = New System.Drawing.Point(128, 32)
            Me.cboFuncTypes.Name = "cboFuncTypes"
            Me.cboFuncTypes.Size = New System.Drawing.Size(200, 24)
            Me.cboFuncTypes.TabIndex = 138
            Me.cboFuncTypes.Text = "ComboBox1"
            '
            'lblCurrentSimNo
            '
            Me.lblCurrentSimNo.BackColor = System.Drawing.SystemColors.Control
            Me.lblCurrentSimNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCurrentSimNo.Location = New System.Drawing.Point(128, 144)
            Me.lblCurrentSimNo.Name = "lblCurrentSimNo"
            Me.lblCurrentSimNo.Size = New System.Drawing.Size(200, 20)
            Me.lblCurrentSimNo.TabIndex = 140
            Me.lblCurrentSimNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(16, 146)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(112, 16)
            Me.Label3.TabIndex = 139
            Me.Label3.Text = "Current Sim #:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkPrintLabel
            '
            Me.chkPrintLabel.Checked = True
            Me.chkPrintLabel.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkPrintLabel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkPrintLabel.ForeColor = System.Drawing.Color.White
            Me.chkPrintLabel.Location = New System.Drawing.Point(128, 240)
            Me.chkPrintLabel.Name = "chkPrintLabel"
            Me.chkPrintLabel.TabIndex = 141
            Me.chkPrintLabel.Text = "Print Label"
            '
            'frmKittingFunctions
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(368, 349)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkPrintLabel, Me.lblCurrentSimNo, Me.Label3, Me.cboFuncTypes, Me.lblCurrentModel, Me.Label4, Me.btnProcessFunc, Me.Label5, Me.txtIMEI, Me.Label2, Me.cboModel, Me.lblSim, Me.txtSim, Me.lblFlashModel})
            Me.Name = "frmKittingFunctions"
            Me.Text = "Peek Kitting Process"
            CType(Me.cboModel, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '*******************************************************************************
        Private Sub frmPeekLabel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable

            Try
                PSS.Core.Highlight.SetHighLight(Me)

                Me.cboFuncTypes.SelectedIndex = 0

                'Populate product type
                _bPopulateData = True
                dt = PSS.Data.Buisness.Peek.Biz.GetModelListAndItemsID()
                Misc.PopulateC1DropDownList(Me.cboModel, dt, "Model_desc", "Model_id")
                Me.cboModel.SelectedValue = 0

                Me.txtIMEI.Focus()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmDockShipping_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
                _bPopulateData = False
            End Try
        End Sub

        '*******************************************************************************
        Private Sub cboFuncTypes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFuncTypes.SelectedIndexChanged
            Try
                Me.ProcessFunctionTypesSelection()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboFuncTypes_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*******************************************************************************
        Private Sub ProcessFunctionTypesSelection()
            Try
                Me.btnProcessFunc.Text = Me.cboFuncTypes.Text & "(F12)"
                _iInventorySNID = 0 : _iItemsID = 0
                Me.lblCurrentModel.Text = ""
                Me.lblCurrentSimNo.Text = ""
                Me.txtIMEI.Text = ""
                Me.txtSim.Text = ""

                If Me.cboFuncTypes.SelectedIndex = 0 Then 'Kitting
                    Me.lblSim.Visible = True
                    Me.txtSim.Visible = True

                    Me.lblFlashModel.Visible = True
                    Me.cboModel.Visible = True

                    Me.chkPrintLabel.Checked = True
                ElseIf Me.cboFuncTypes.SelectedIndex = 1 Then   'Re-label
                    Me.lblSim.Visible = False
                    Me.txtSim.Visible = False

                    Me.lblFlashModel.Visible = False
                    Me.cboModel.Visible = False
                    Me.chkPrintLabel.Checked = True
                ElseIf Me.cboFuncTypes.SelectedIndex = 2 Then   'Update Item #
                    Me.lblFlashModel.Visible = True
                    Me.cboModel.Visible = True

                    Me.lblSim.Visible = False
                    Me.txtSim.Visible = False
                ElseIf Me.cboFuncTypes.SelectedIndex = 3 Then   'Update Sim #
                    Me.lblSim.Visible = True
                    Me.txtSim.Visible = True

                    Me.lblFlashModel.Visible = False
                    Me.cboModel.Visible = False
                End If

                If Me.cboFuncTypes.SelectedIndex >= 0 Then Me.txtIMEI.Focus()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*******************************************************************************
        Private Sub txtIMEI_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIMEI.KeyUp
            Const strSimItemNo As String = "PK-SIM-001"
            Dim dt As DataTable
            Dim strAccData, strAccDataArr() As String
            Dim i As Integer = 0

            Try
                If e.KeyCode = Keys.Enter Then
                    'Populate product type
                    Me.lblCurrentModel.Text = ""
                    Me.lblCurrentSimNo.Text = ""
                    Me.txtSim.Text = ""
                    _iInventorySNID = 0 : _iItemsID = 0

                    If Me.txtIMEI.Text.Trim.Length = 0 Then Exit Sub
                    If Me.cboFuncTypes.SelectedIndex < 0 Then
                        MessageBox.Show("Please select function.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.cboFuncTypes.SelectAll() : Me.cboFuncTypes.Focus()
                    Else

                        If Me.cboFuncTypes.SelectedIndex = 1 Then
                            dt = PSS.Data.Buisness.Peek.Biz.GetLatestInventorySNAndSimNo(Me.txtIMEI.Text.Trim)
                        Else
                            dt = PSS.Data.Buisness.Peek.Biz.GetOpenInventorySNAndSimNo(Me.txtIMEI.Text.Trim)
                        End If

                        If dt.Rows.Count = 0 Then
                            MessageBox.Show("Device does not exist in inventory.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
                        ElseIf dt.Rows.Count > 1 Then
                            MessageBox.Show("Device exist more than one in inventory. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
                        Else
                            Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                            strAccData = ""

                            Me._iInventorySNID = CInt(dt.Rows(0)("InventorySNID").ToString)
                            Me.lblCurrentModel.Text = dt.Rows(0)("NavItemID").ToString
                            _iItemsID = CInt(dt.Rows(0)("ItemsID").ToString)

                            '************************************
                            'Get current Sim #
                            '************************************
                            If Not IsDBNull(dt.Rows(0)("AccPartsNoAndID")) Then strAccData = dt.Rows(0)("AccPartsNoAndID")
                            If strAccData.Trim.Length > 0 Then
                                strAccDataArr = strAccData.Split("|")

                                For i = 0 To strAccDataArr.Length - 1
                                    If strAccDataArr(i).Trim.ToUpper = strSimItemNo Then
                                        If i <= strAccDataArr.Length Then
                                            Me.lblCurrentSimNo.Text = strAccDataArr(i + 1)
                                            Exit For
                                        End If
                                    End If
                                Next i
                            End If

                            '************************************
                            If Me.cboModel.Visible = True AndAlso Me.cboModel.SelectedValue = 0 Then
                                Me.Enabled = True : Me.cboModel.SelectAll() : Me.cboModel.Focus()
                            ElseIf Me.txtSim.Visible = True Then
                                Me.Enabled = True : Me.txtSim.SelectAll() : Me.txtSim.Focus()
                            Else
                                Me.Enabled = True : Me.txtIMEI.Focus()
                            End If
                        End If
                    End If
                ElseIf e.KeyCode = Keys.F12 Then
                    Me.ProccessSelectedFunctions()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtIMEI_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '*******************************************************************************
        Private Sub ProccessSelectedFunctions()
            Try
                Select Case Me.cboFuncTypes.SelectedIndex
                    Case 0 'Kitting
                        Me.ProcessKitting()
                    Case 1  'Print Label
                        Me.PrintLabel()
                    Case 2  'Update Item #
                        Me.UpdateModel()
                    Case 3  'Update Sim #
                        Me.UpdateSimNo()
                End Select
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*******************************************************************************
        Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcessFunc.Click
            Try
                ProccessSelectedFunctions()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnPrint_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*******************************************************************************
        Private Sub PrintLabel()
            Dim i As Integer = 0

            Try
                If Me._iInventorySNID = 0 Then
                    MessageBox.Show("SN ID is mising. Please re-enter serial number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
                ElseIf Me.lblCurrentSimNo.Text.Trim.Length = 0 Then
                    MessageBox.Show("Sim # is missing for this device.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
                Else
                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor

                    i = PSS.Data.Buisness.Peek.Biz.PrintLabel(Me._iInventorySNID, Me.lblCurrentSimNo.Text.Trim)

                    If i > 0 Then
                        Me.lblCurrentModel.Text = ""
                        Me.lblCurrentSimNo.Text = ""
                        Me.txtIMEI.Text = ""
                        Me.txtSim.Text = ""
                        Me._iInventorySNID = 0
                        Me.Enabled = True : Me.txtIMEI.Focus()
                    End If
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        '*******************************************************************************
        Private Sub ProcessKitting()
            Dim objPeek As PSS.Data.Buisness.Peek.Biz
            Dim i, iShiftID As Integer
            Dim iNewItemID As Integer = 0
            Dim bBillFlashing As Boolean = False
            Dim dtInvSN, dtDeviceSN As DataTable

            Try
                If Me._iInventorySNID = 0 Then
                    MessageBox.Show("SN ID is mising. Please re-enter serial number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
                ElseIf Me.cboModel.SelectedValue = 0 Then
                    MessageBox.Show("Please select model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboModel.SelectAll() : Me.cboModel.Focus()
                ElseIf Me.txtSim.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter sim #.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtSim.SelectAll() : Me.txtSim.Focus()
                Else
                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor

                    dtInvSN = PSS.Data.Buisness.Peek.Biz.GetOpenInventorySNAndSimNo(Me.txtIMEI.Text.Trim)

                    If dtInvSN.Rows.Count = 0 Then
                        MessageBox.Show("Device does not exist in inventory.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me._iInventorySNID = 0 : Me._iItemsID = 0
                        Me.lblCurrentModel.Text = "" : Me.lblCurrentSimNo.Text = ""
                        Me.txtSim.Text = ""
                        Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
                    ElseIf dtInvSN.Rows.Count > 1 Then
                        MessageBox.Show("Device exist more than one in inventory. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        i = 0 : iShiftID = PSS.Core.[Global].ApplicationUser.IDShift
                        iNewItemID = CInt(Me.cboModel.DataSource.Table.Select("Model_id = " & Me.cboModel.SelectedValue)(0)("ItemsID"))

                        If Me._iItemsID = iNewItemID Then
                            If MessageBox.Show("Current model and new model are the same. Do you want to continue?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub
                        End If

                        objPeek = New PSS.Data.Buisness.Peek.Biz()
                        dtDeviceSN = objPeek.GetDeviceInWipByIMEICustID(Me.txtIMEI.Text.Trim, _iPeekCustID, Me.cboModel.SelectedValue, iShiftID)

                        If dtDeviceSN.Rows.Count = 0 Then
                            MessageBox.Show("Device does not exist in WIP.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
                        ElseIf dtDeviceSN.Rows.Count > 1 Then
                            MessageBox.Show("Duplicate SN in WIP.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
                        Else
                            'Save Model
                            i = objPeek.SaveModelID(dtDeviceSN.Rows(0)("Device_ID"), Me.cboModel.SelectedValue, Me.txtSim.Text.Trim)

                            'Bill Fashing
                            bBillFlashing = Me.BillFlashingService(dtDeviceSN.Rows(0)("Device_ID"), Me.cboModel.SelectedValue)

                            'Close ship date
                            i = objPeek.SetDeviceShipDate(dtDeviceSN.Rows(0)("Device_ID"), iShiftID)

                            i = PSS.Data.Buisness.Peek.Biz.SaveItemsID(Me._iInventorySNID, iNewItemID)
                            i = PSS.Data.Buisness.Peek.Biz.SaveSimNo(Me._iInventorySNID, Me.txtSim.Text.Trim)
                            i = PSS.Data.Buisness.Peek.Biz.PrintLabel(Me._iInventorySNID, Me.txtSim.Text.Trim)

                            If i > 0 Then
                                Me.lblCurrentModel.Text = ""
                                Me.lblCurrentSimNo.Text = ""
                                Me.txtIMEI.Text = ""
                                Me.txtSim.Text = ""
                                Me._iInventorySNID = 0
                                Me.Enabled = True : Me.txtIMEI.Focus()
                            End If
                        End If ' dtDeviceSN check
                    End If 'dtInvSN check
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        '*******************************************************************************
        Public Shared Function BillFlashingService(ByVal iDeviceID As Integer, _
                                             ByVal iModelID As Integer) As Boolean
            Dim objDevice As Rules.Device
            Try
                objDevice = New Rules.Device(iDeviceID)
                If Generic.IsBillcodeMapped(iModelID, 1876) = 0 Then Throw New Exception("Billcode ID 1876 is not mapped.")
                If Generic.IsBillcodeExisted(iDeviceID, 1876) = False Then objDevice.AddPart(1876)

                If Generic.IsBillcodeMapped(iModelID, 1877) = 0 Then Throw New Exception("Billcode ID 1877 is not mapped.")
                If Generic.IsBillcodeExisted(iDeviceID, 1877) = False Then objDevice.AddPart(1877)

                If Generic.IsBillcodeMapped(iModelID, 1878) = 0 Then Throw New Exception("Billcode ID 1878 is not mapped.")
                If Generic.IsBillcodeExisted(iDeviceID, 1878) = False Then objDevice.AddPart(1878)

                objDevice.Update()

                Return True
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************
        Private Sub UpdateSimNo()
            Dim i As Integer = 0

            Try
                If Me._iInventorySNID = 0 Then
                    MessageBox.Show("SN ID is mising. Please re-enter serial number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
                ElseIf Me.txtSim.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter sim #.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtSim.SelectAll() : Me.txtSim.Focus()
                ElseIf Me.lblCurrentSimNo.Text.Trim.ToLower = Me.txtSim.Text.Trim.ToLower Then
                    MessageBox.Show("Current and new sim # are the same.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtSim.SelectAll() : Me.txtSim.Focus()
                Else
                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor

                    i = PSS.Data.Buisness.Peek.Biz.SaveSimNo(Me._iInventorySNID, Me.txtSim.Text.Trim)
                    If Me.chkPrintLabel.Checked = True Then i = PSS.Data.Buisness.Peek.Biz.PrintLabel(Me._iInventorySNID, Me.txtSim.Text.Trim)

                    If i > 0 Then
                        Me.lblCurrentModel.Text = ""
                        Me.lblCurrentSimNo.Text = ""
                        Me.txtIMEI.Text = ""
                        Me.txtSim.Text = ""
                        Me._iInventorySNID = 0 : Me._iItemsID = 0
                        Me.Enabled = True : Me.txtIMEI.Focus()
                    End If
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        '*******************************************************************************
        Private Sub UpdateModel()
            Dim objPeek As PSS.Data.Buisness.Peek.Biz
            Dim i As Integer
            Dim iNewItemID As Integer = 0
            Dim bBillFlashing As Boolean = False
            Dim dtInvSN, dtDeviceSN As DataTable

            Try
                If Me._iInventorySNID = 0 Then
                    MessageBox.Show("SN ID is mising. Please re-enter serial number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
                ElseIf Me.cboModel.SelectedValue = 0 Then
                    MessageBox.Show("Please select model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboModel.SelectAll() : Me.cboModel.Focus()
                Else
                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor

                    dtInvSN = PSS.Data.Buisness.Peek.Biz.GetOpenInventorySNAndSimNo(Me.txtIMEI.Text.Trim)

                    If dtInvSN.Rows.Count = 0 Then
                        MessageBox.Show("Device does not exist in inventory.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me._iInventorySNID = 0 : Me._iItemsID = 0
                        Me.lblCurrentModel.Text = "" : Me.lblCurrentSimNo.Text = ""
                        Me.txtSim.Text = ""
                        Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
                    ElseIf dtInvSN.Rows.Count > 1 Then
                        MessageBox.Show("Device exist more than one in inventory. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        i = 0
                        iNewItemID = CInt(Me.cboModel.DataSource.Table.Select("Model_id = " & Me.cboModel.SelectedValue)(0)("ItemsID"))

                        If Me._iItemsID = iNewItemID Then
                            If MessageBox.Show("Current model and new model are the same. Do you want to continue?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub
                        End If

                        objPeek = New PSS.Data.Buisness.Peek.Biz()
                        dtDeviceSN = objPeek.GetLastInsertDeviceIDByIMEICustID(Me.txtIMEI.Text.Trim, _iPeekCustID)

                        If dtDeviceSN.Rows.Count > 0 Then
                            'Update model in tdevice
                            i = objPeek.SaveModelID(dtDeviceSN.Rows(0)("Device_ID"), Me.cboModel.SelectedValue, "")
                        End If

                        i = PSS.Data.Buisness.Peek.Biz.SaveItemsID(Me._iInventorySNID, iNewItemID)
                        If Me.chkPrintLabel.Checked = True Then i = PSS.Data.Buisness.Peek.Biz.PrintLabel(Me._iInventorySNID, Me.txtSim.Text.Trim)

                        If i > 0 Then
                            Me.lblCurrentModel.Text = ""
                            Me.lblCurrentSimNo.Text = ""
                            Me.txtIMEI.Text = ""
                            Me.txtSim.Text = ""
                            Me._iInventorySNID = 0
                            Me.Enabled = True : Me.txtIMEI.Focus()
                        End If

                    End If 'dtInvSN check
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        '*******************************************************************************
        Private Sub cboModel_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboModel.SelectedValueChanged
            If _bPopulateData = False AndAlso Me.cboModel.SelectedValue > 0 Then
                Me.txtSim.SelectAll() : Me.txtSim.Focus()
            End If
        End Sub

        '*******************************************************************************
        Private Sub Ctrls_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSim.KeyUp, btnProcessFunc.KeyUp, cboFuncTypes.KeyUp, cboModel.KeyUp, chkPrintLabel.KeyUp
            Try
                If e.KeyCode = Keys.F12 AndAlso Me.cboFuncTypes.SelectedIndex >= 0 Then
                    Me.ProccessSelectedFunctions()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, sender.Name & "_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*******************************************************************************
        Private Sub lblCurrentSimNo_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblCurrentSimNo.DoubleClick
            Try
                If Me.lblCurrentSimNo.Text.Trim.Length > 0 AndAlso Me.txtSim.Text.Trim.Length = 0 Then
                    Me.txtSim.Text = Me.lblCurrentSimNo.Text.Trim
                    Me.txtSim.SelectAll()
                    Me.txtSim.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "lblCurrentSimNo_DoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*******************************************************************************

    End Class
End Namespace