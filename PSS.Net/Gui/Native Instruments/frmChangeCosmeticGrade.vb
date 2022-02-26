Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.NativeInstruments

    Public Class frmChangeCosmeticGrade
        Inherits System.Windows.Forms.Form

        Private _strScreenName As String = ""
        Private _iCust_ID As Integer = 0
        Private _iCosmetricGradeIDs As New ArrayList()
        Private _iDeviceID As Integer = 0
        Private _iWI_ID As Integer = 0

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strScreenName As String, ByVal iCustID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _strScreenName = strScreenName
            _iCust_ID = iCustID

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
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents cboCosmGrade As C1.Win.C1List.C1Combo
        Friend WithEvents cboCustomers As C1.Win.C1List.C1Combo
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents lblMainInputName As System.Windows.Forms.Label
        Friend WithEvents txtDeviceSN As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents btnSaveChange As System.Windows.Forms.Button
        Friend WithEvents txtCosmGradeOld As System.Windows.Forms.TextBox
        Friend WithEvents lblCosmGradeNew As System.Windows.Forms.Label
        Friend WithEvents btnReset As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmChangeCosmeticGrade))
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.cboCosmGrade = New C1.Win.C1List.C1Combo()
            Me.lblCosmGradeNew = New System.Windows.Forms.Label()
            Me.cboCustomers = New C1.Win.C1List.C1Combo()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.lblMainInputName = New System.Windows.Forms.Label()
            Me.txtDeviceSN = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtCosmGradeOld = New System.Windows.Forms.TextBox()
            Me.btnSaveChange = New System.Windows.Forms.Button()
            Me.btnReset = New System.Windows.Forms.Button()
            CType(Me.cboCosmGrade, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTitle.ForeColor = System.Drawing.Color.Navy
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(840, 24)
            Me.lblTitle.TabIndex = 0
            '
            'cboCosmGrade
            '
            Me.cboCosmGrade.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboCosmGrade.Caption = ""
            Me.cboCosmGrade.CaptionHeight = 17
            Me.cboCosmGrade.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboCosmGrade.ColumnCaptionHeight = 17
            Me.cboCosmGrade.ColumnFooterHeight = 17
            Me.cboCosmGrade.ContentHeight = 15
            Me.cboCosmGrade.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboCosmGrade.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboCosmGrade.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCosmGrade.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboCosmGrade.EditorHeight = 15
            Me.cboCosmGrade.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCosmGrade.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboCosmGrade.ItemHeight = 15
            Me.cboCosmGrade.Location = New System.Drawing.Point(224, 208)
            Me.cboCosmGrade.MatchEntryTimeout = CType(2000, Long)
            Me.cboCosmGrade.MaxDropDownItems = CType(5, Short)
            Me.cboCosmGrade.MaxLength = 32767
            Me.cboCosmGrade.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCosmGrade.Name = "cboCosmGrade"
            Me.cboCosmGrade.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCosmGrade.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCosmGrade.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCosmGrade.Size = New System.Drawing.Size(88, 21)
            Me.cboCosmGrade.TabIndex = 125
            Me.cboCosmGrade.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
            "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Microsoft" & _
            " Sans Serif, 8.25pt, style=Bold;}HighlightRow{ForeColor:HighlightText;BackColor:" & _
            "Highlight;}Style9{AlignHorz:Near;}OddRow{}RecordSelector{AlignImage:Center;}Head" & _
            "ing{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;B" & _
            "ackColor:Control;}Style8{}Style10{}Style11{}Style1{}</Data></Styles><Splits><C1." & _
            "Win.C1List.ListBoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""1" & _
            "7"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" Hori" & _
            "zontalScrollGroup=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height" & _
            "><VScrollBar><Width>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScr" & _
            "ollBar><CaptionStyle parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow" & _
            """ me=""Style7"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""G" & _
            "roup"" me=""Style11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowS" & _
            "tyle parent=""HighlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""St" & _
            "yle4"" /><OddRowStyle parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""" & _
            "RecordSelector"" me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><S" & _
            "tyle parent=""Normal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedSt" & _
            "yles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style" & _
            " parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style pa" & _
            "rent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style par" & _
            "ent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style pa" & _
            "rent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style" & _
            " parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSpli" & _
            "ts>1</horzSplits><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelW" & _
            "idth></Blob>"
            '
            'lblCosmGradeNew
            '
            Me.lblCosmGradeNew.BackColor = System.Drawing.Color.Transparent
            Me.lblCosmGradeNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCosmGradeNew.ForeColor = System.Drawing.Color.Black
            Me.lblCosmGradeNew.Location = New System.Drawing.Point(56, 208)
            Me.lblCosmGradeNew.Name = "lblCosmGradeNew"
            Me.lblCosmGradeNew.Size = New System.Drawing.Size(160, 16)
            Me.lblCosmGradeNew.TabIndex = 130
            Me.lblCosmGradeNew.Text = "New Cosmetic Grade:"
            Me.lblCosmGradeNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboCustomers
            '
            Me.cboCustomers.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboCustomers.Caption = ""
            Me.cboCustomers.CaptionHeight = 17
            Me.cboCustomers.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboCustomers.ColumnCaptionHeight = 17
            Me.cboCustomers.ColumnFooterHeight = 17
            Me.cboCustomers.ContentHeight = 15
            Me.cboCustomers.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboCustomers.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboCustomers.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCustomers.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboCustomers.EditorHeight = 15
            Me.cboCustomers.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCustomers.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboCustomers.ItemHeight = 15
            Me.cboCustomers.Location = New System.Drawing.Point(224, 80)
            Me.cboCustomers.MatchEntryTimeout = CType(2000, Long)
            Me.cboCustomers.MaxDropDownItems = CType(5, Short)
            Me.cboCustomers.MaxLength = 32767
            Me.cboCustomers.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCustomers.Name = "cboCustomers"
            Me.cboCustomers.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCustomers.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCustomers.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCustomers.Size = New System.Drawing.Size(271, 21)
            Me.cboCustomers.TabIndex = 124
            Me.cboCustomers.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
            "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Microsoft" & _
            " Sans Serif, 8.25pt, style=Bold;}HighlightRow{ForeColor:HighlightText;BackColor:" & _
            "Highlight;}Style9{AlignHorz:Near;}OddRow{}RecordSelector{AlignImage:Center;}Head" & _
            "ing{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;B" & _
            "ackColor:Control;}Style8{}Style10{}Style11{}Style1{}</Data></Styles><Splits><C1." & _
            "Win.C1List.ListBoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""1" & _
            "7"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" Hori" & _
            "zontalScrollGroup=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height" & _
            "><VScrollBar><Width>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScr" & _
            "ollBar><CaptionStyle parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow" & _
            """ me=""Style7"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""G" & _
            "roup"" me=""Style11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowS" & _
            "tyle parent=""HighlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""St" & _
            "yle4"" /><OddRowStyle parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""" & _
            "RecordSelector"" me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><S" & _
            "tyle parent=""Normal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedSt" & _
            "yles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style" & _
            " parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style pa" & _
            "rent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style par" & _
            "ent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style pa" & _
            "rent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style" & _
            " parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSpli" & _
            "ts>1</horzSplits><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelW" & _
            "idth></Blob>"
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Black
            Me.Label1.Location = New System.Drawing.Point(112, 80)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(104, 16)
            Me.Label1.TabIndex = 131
            Me.Label1.Text = "Customer:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblMainInputName
            '
            Me.lblMainInputName.BackColor = System.Drawing.Color.Transparent
            Me.lblMainInputName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblMainInputName.ForeColor = System.Drawing.Color.Black
            Me.lblMainInputName.Location = New System.Drawing.Point(136, 120)
            Me.lblMainInputName.Name = "lblMainInputName"
            Me.lblMainInputName.Size = New System.Drawing.Size(80, 19)
            Me.lblMainInputName.TabIndex = 128
            Me.lblMainInputName.Text = "Device SN:"
            Me.lblMainInputName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtDeviceSN
            '
            Me.txtDeviceSN.BackColor = System.Drawing.Color.Khaki
            Me.txtDeviceSN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtDeviceSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDeviceSN.Location = New System.Drawing.Point(224, 120)
            Me.txtDeviceSN.Name = "txtDeviceSN"
            Me.txtDeviceSN.Size = New System.Drawing.Size(272, 20)
            Me.txtDeviceSN.TabIndex = 127
            Me.txtDeviceSN.Tag = ""
            Me.txtDeviceSN.Text = ""
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.Black
            Me.Label3.Location = New System.Drawing.Point(24, 160)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(192, 19)
            Me.Label3.TabIndex = 133
            Me.Label3.Text = "Existing Cosmetic Grade:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCosmGradeOld
            '
            Me.txtCosmGradeOld.BackColor = System.Drawing.Color.Gainsboro
            Me.txtCosmGradeOld.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtCosmGradeOld.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtCosmGradeOld.Location = New System.Drawing.Point(224, 160)
            Me.txtCosmGradeOld.Name = "txtCosmGradeOld"
            Me.txtCosmGradeOld.Size = New System.Drawing.Size(88, 20)
            Me.txtCosmGradeOld.TabIndex = 132
            Me.txtCosmGradeOld.Tag = ""
            Me.txtCosmGradeOld.Text = ""
            '
            'btnSaveChange
            '
            Me.btnSaveChange.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSaveChange.ForeColor = System.Drawing.Color.DarkBlue
            Me.btnSaveChange.Location = New System.Drawing.Point(224, 256)
            Me.btnSaveChange.Name = "btnSaveChange"
            Me.btnSaveChange.Size = New System.Drawing.Size(272, 56)
            Me.btnSaveChange.TabIndex = 134
            Me.btnSaveChange.Text = "Update"
            '
            'btnReset
            '
            Me.btnReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReset.ForeColor = System.Drawing.Color.Maroon
            Me.btnReset.Location = New System.Drawing.Point(224, 40)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.Size = New System.Drawing.Size(272, 32)
            Me.btnReset.TabIndex = 135
            Me.btnReset.Text = "Reset"
            '
            'frmChangeCosmeticGrade
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(904, 582)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnReset, Me.btnSaveChange, Me.Label3, Me.txtCosmGradeOld, Me.cboCosmGrade, Me.lblCosmGradeNew, Me.cboCustomers, Me.Label1, Me.lblMainInputName, Me.txtDeviceSN, Me.lblTitle})
            Me.Name = "frmChangeCosmeticGrade"
            Me.Text = "frmChangeCosmeticGrade"
            CType(Me.cboCosmGrade, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '*****************************************************************************************************************
        Private Sub frmChangeCosmeticGrade_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                LoadData()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "frmChangeCosmeticGrade_Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*****************************************************************************************************************
        Private Sub LoadData()
            Dim dt As DataTable
            Dim row As DataRow

            Try

                dt = Generic.GetCustomers(True)
                Misc.PopulateC1DropDownList(Me.cboCustomers, dt, "Cust_Name1", "Cust_ID")
                Me.cboCustomers.SelectedValue = Me._iCust_ID

                If Me._iCust_ID = PSS.Data.Buisness.NI.CUSTOMERID Then
                    Me.lblTitle.Text = "NI - " & Me._strScreenName & " (Outbound)"

                    dt = Generic.GetCosmeticGrades(True)
                    Me._iCosmetricGradeIDs.Clear() : Me._iDeviceID = 0
                    For Each row In dt.Rows
                        Me._iCosmetricGradeIDs.Add(row("DCode_ID"))
                    Next
                    Me.cboCosmGrade.ClearItems()
                    Misc.PopulateC1DropDownList(Me.cboCosmGrade, dt, "DCode_LDesc", "DCode_ID")
                    Me.cboCosmGrade.SelectedValue = 0

                    Me.lblCosmGradeNew.Visible = False : Me.cboCosmGrade.Visible = False : Me.btnSaveChange.Enabled = False

                    Me.cboCustomers.Enabled = False
                    Me.txtCosmGradeOld.ReadOnly = True
                    Me.txtDeviceSN.ReadOnly = False
                    Me.txtDeviceSN.Text = ""
                    Me.txtCosmGradeOld.Text = ""

                    Me.ActiveControl = Me.txtDeviceSN
                    Me.txtDeviceSN.SelectAll() : Me.txtDeviceSN.Focus()
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "LoadData", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

      
        '*****************************************************************************************************************
        Private Sub txtDeviceSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDeviceSN.KeyUp
            If e.KeyValue = 13 Then       'Carriage Return
                ProcessSN()
            End If
        End Sub

        '*****************************************************************************************************************
        Private Sub ProcessSN()
            Dim dt, dtSalesOrder, dtDevice, dtCellOpt As DataTable
            Dim objNIRecShip As New NIRecShip()
            Dim strSN As String = ""
            Dim iSODetailsID As Integer = 0
            Dim iDeviceID_Local As Integer = 0

            Try
                strSN = Trim(Me.txtDeviceSN.Text)
                If Not strSN.Length > 0 Then
                    MessageBox.Show("Please enter a device SN!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtDeviceSN.SelectAll() : Me.txtDeviceSN.Focus() : Exit Sub
                End If

                'Get data
                dt = objNIRecShip.getNICosmeticGrade_ToChange(Me._iCust_ID, strSN, False)
                If dt.Rows.Count > 1 Then dt = objNIRecShip.getNICosmeticGrade_ToChange(Me._iCust_ID, strSN, True)

                'Validate warehouseitems
                If Not dt.Rows.Count > 0 Then
                    MessageBox.Show("This device " & strSN & " is not available for changing cosmetic grade!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtDeviceSN.SelectAll() : Me.txtDeviceSN.Focus() : Exit Sub
                ElseIf dt.Rows.Count > 1 Then
                    MessageBox.Show("Duplicate devices " & strSN & " are found in table warehouse.warehouseItems!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtDeviceSN.SelectAll() : Me.txtDeviceSN.Focus() : Exit Sub
                ElseIf dt.Rows(0).Item("DevConditionID") = 3856 Then 'new product
                    If dt.Rows(0).Item("CosmGradeID") = 3858 Then 'A grade
                        MessageBox.Show("New product! You can't change the cosmetic grade.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop) : Exit Sub
                    Else
                        MessageBox.Show("New product, but the grade isn't 'A'. Please see IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop) : Exit Sub
                    End If
                ElseIf dt.Rows(0).Item("SODetailsID") > 0 Then
                    iSODetailsID = dt.Rows(0).Item("SODetailsID")
                    dtSalesOrder = objNIRecShip.getNICosmeticGrade_SalesOrder(Me._iCust_ID, iSODetailsID)
                    If dtSalesOrder.Rows.Count > 0 Then
                        MessageBox.Show("The device has been filled and shipped. You can't change the cosmetic grade.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop) : Exit Sub
                    End If
                End If

                'Validate tDevice
                dtDevice = objNIRecShip.getNIDevice_BySN(3332, strSN)
                If Not dtDevice.Rows.Count > 0 Then
                    MessageBox.Show("Not produced yet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop) : Exit Sub
                ElseIf dtDevice.Rows.Count > 1 Then
                    MessageBox.Show("Duplicate devices " & strSN & " are found in table tDevice.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop) : Exit Sub
                Else
                    If dtDevice.Rows(0).IsNull("Device_DateShip") Then
                        MessageBox.Show("The devices " & strSN & " is in WIP.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop) : Exit Sub
                    Else 'produced
                        iDeviceID_Local = dtDevice.Rows(0).Item("Device_ID")
                    End If
                End If
                If Not iDeviceID_Local > 0 Then
                    MessageBox.Show("Invalid deviceID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop) : Exit Sub
                End If

                'Validate tCellopt
                dtCellOpt = objNIRecShip.getNIDeviceCellOpt(iDeviceID_Local)
                If Not dtCellOpt.Rows.Count > 0 Then
                    MessageBox.Show("Can't find outbound cosmetic grade data in table tCellOpt.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop) : Exit Sub
                ElseIf dtCellOpt.Rows.Count > 1 Then
                    MessageBox.Show("Duplicate devices are found in table tCellOpt.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop) : Exit Sub
                Else '=1
                    If dtCellOpt.Rows(0).IsNull("OutBoundCosmGradeID") AndAlso Not (dtCellOpt.Rows(0).IsNull("OutBoundCosmGradeID") > 0) Then
                        MessageBox.Show("Invalid outbound cosmetic grade.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop) : Exit Sub
                    End If
                End If

                'ready to load
                Me.txtCosmGradeOld.Text = dtCellOpt.Rows(0).Item("OutBoundCosmGrade")
                Me.txtCosmGradeOld.Tag = dtCellOpt.Rows(0).Item("OutBoundCosmGradeID")
                Me.lblCosmGradeNew.Visible = True : Me.cboCosmGrade.Visible = True : Me.btnSaveChange.Enabled = True
                Me._iDeviceID = iDeviceID_Local
                Me.txtDeviceSN.ReadOnly = True
                Me._iWI_ID = dt.Rows(0).Item("WI_ID")
            Catch ex As Exception
                MessageBox.Show(ex.Message, "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                objNIRecShip = Nothing : dt = Nothing : dtSalesOrder = Nothing : dtDevice = Nothing : dtCellOpt = Nothing
            End Try
        End Sub

        '*****************************************************************************************************************
        Private Sub btnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.Click
            Try
                Reset()
            Catch ex As Exception
                MessageBox.Show(ex.Message, " btnReset_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

            End Try
        End Sub

        '*****************************************************************************************************************
        Private Sub Reset()
            Try
                Me._iDeviceID = 0
                Me.lblCosmGradeNew.Visible = False : Me.cboCosmGrade.Visible = False : Me.btnSaveChange.Enabled = False
                Me.cboCustomers.Enabled = False
                Me.txtCosmGradeOld.ReadOnly = True
                Me.txtDeviceSN.ReadOnly = False
                Me.txtDeviceSN.Text = ""
                Me.txtCosmGradeOld.Text = ""
                Me.ActiveControl = Me.txtDeviceSN
                Me.txtDeviceSN.SelectAll() : Me.txtDeviceSN.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.Message, " Reset", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

            End Try
        End Sub

        '*****************************************************************************************************************
        Private Sub btnSaveChange_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveChange.Click
            Dim dt As DataTable
            Dim objNIRecShip As New NIRecShip()
            Dim strSN As String = ""
            Dim i As Integer = 0

            Try
                If Not Me._iCosmetricGradeIDs.Count > 0 Then
                    MessageBox.Show("No cosmetic grade data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtDeviceSN.SelectAll() : Me.txtDeviceSN.Focus()
                ElseIf Not Me._iDeviceID > 0 Then
                    MessageBox.Show("Invalid device_ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Not Me.cboCosmGrade.SelectedValue > 0 Then
                    MessageBox.Show("Please select a new cosmetic grade.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    'ElseIf Me.txtCosmGradeOld.Tag = Me.cboCosmGrade.SelectedValue Then
                    '    MessageBox.Show("No need to change.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else 'ready to change
                    i = objNIRecShip.UpdateNICosmeticGrade(Me._iDeviceID, Me.cboCosmGrade.SelectedValue, Me._iWI_ID)
                    If Not i > 0 Then
                        MessageBox.Show("Failed to change.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        MessageBox.Show("Successfully changed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.None)
                        Reset()
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnSaveChange_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                objNIRecShip = Nothing : dt = Nothing
            End Try
        End Sub

        '*****************************************************************************************************************
    End Class
End Namespace
