Option Explicit On 
Imports PSS.Data
Imports PSS.Core
Imports PSS.Rules
Imports PSS.Core.Global
Imports System.IO
Imports PSS.Data.Buisness


Namespace Gui.Nespresso
    Public Class frmProduce
        Inherits System.Windows.Forms.Form
        Private _LocID = PSS.Data.Buisness.Nespresso.Nespresso.intLocID
        Private _MfgID = PSS.Data.Buisness.Nespresso.Nespresso.intMfgID
        Private _ProdID = PSS.Data.Buisness.Nespresso.Nespresso.intProdID
        Private _CusID = PSS.Data.Buisness.Nespresso.Nespresso.intCustID
        Private _DeviceID As Integer = 0
        Private _booPopDataToCombo As Boolean = False

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
        Friend WithEvents _Tittle As System.Windows.Forms.Label
        Friend WithEvents btnComplete As System.Windows.Forms.Button
        Friend WithEvents txtSerial As System.Windows.Forms.TextBox
        Friend WithEvents cboColor As C1.Win.C1List.C1Combo
        Friend WithEvents lblColor As System.Windows.Forms.Label
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents lblSerial As System.Windows.Forms.Label
        Friend WithEvents lblRePrintLabel As System.Windows.Forms.Label
        Friend WithEvents txtRePrintLabel As System.Windows.Forms.TextBox
        Friend WithEvents btnRePrintLabel As System.Windows.Forms.Button
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents tpProduce As System.Windows.Forms.TabPage
        Friend WithEvents tpLabel As System.Windows.Forms.TabPage
        Friend WithEvents StatusProduce As System.Windows.Forms.Label
        Friend WithEvents StatusLabel As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmProduce))
            Me._Tittle = New System.Windows.Forms.Label()
            Me.btnComplete = New System.Windows.Forms.Button()
            Me.txtSerial = New System.Windows.Forms.TextBox()
            Me.lblSerial = New System.Windows.Forms.Label()
            Me.cboColor = New C1.Win.C1List.C1Combo()
            Me.lblColor = New System.Windows.Forms.Label()
            Me.StatusProduce = New System.Windows.Forms.Label()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.lblRePrintLabel = New System.Windows.Forms.Label()
            Me.txtRePrintLabel = New System.Windows.Forms.TextBox()
            Me.btnRePrintLabel = New System.Windows.Forms.Button()
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.tpProduce = New System.Windows.Forms.TabPage()
            Me.tpLabel = New System.Windows.Forms.TabPage()
            Me.StatusLabel = New System.Windows.Forms.Label()
            CType(Me.cboColor, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControl1.SuspendLayout()
            Me.tpProduce.SuspendLayout()
            Me.tpLabel.SuspendLayout()
            Me.SuspendLayout()
            '
            '_Tittle
            '
            Me._Tittle.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me._Tittle.BackColor = System.Drawing.Color.Black
            Me._Tittle.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me._Tittle.ForeColor = System.Drawing.Color.Yellow
            Me._Tittle.Name = "_Tittle"
            Me._Tittle.Size = New System.Drawing.Size(800, 48)
            Me._Tittle.TabIndex = 122
            Me._Tittle.Text = "Nespresso Produce"
            Me._Tittle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnComplete
            '
            Me.btnComplete.BackColor = System.Drawing.Color.Green
            Me.btnComplete.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnComplete.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
            Me.btnComplete.Location = New System.Drawing.Point(272, 200)
            Me.btnComplete.Name = "btnComplete"
            Me.btnComplete.Size = New System.Drawing.Size(168, 32)
            Me.btnComplete.TabIndex = 143
            Me.btnComplete.Text = "Complete"
            '
            'txtSerial
            '
            Me.txtSerial.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
            Me.txtSerial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSerial.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtSerial.Location = New System.Drawing.Point(288, 112)
            Me.txtSerial.Name = "txtSerial"
            Me.txtSerial.Size = New System.Drawing.Size(216, 26)
            Me.txtSerial.TabIndex = 141
            Me.txtSerial.Text = ""
            '
            'lblSerial
            '
            Me.lblSerial.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSerial.ForeColor = System.Drawing.Color.White
            Me.lblSerial.Location = New System.Drawing.Point(160, 120)
            Me.lblSerial.Name = "lblSerial"
            Me.lblSerial.Size = New System.Drawing.Size(120, 16)
            Me.lblSerial.TabIndex = 142
            Me.lblSerial.Text = "Serial Number:"
            Me.lblSerial.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboColor
            '
            Me.cboColor.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboColor.AutoCompletion = True
            Me.cboColor.AutoDropDown = True
            Me.cboColor.AutoSelect = True
            Me.cboColor.Caption = ""
            Me.cboColor.CaptionHeight = 17
            Me.cboColor.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboColor.ColumnCaptionHeight = 17
            Me.cboColor.ColumnFooterHeight = 17
            Me.cboColor.ColumnHeaders = False
            Me.cboColor.ContentHeight = 15
            Me.cboColor.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboColor.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboColor.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboColor.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboColor.EditorHeight = 15
            Me.cboColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboColor.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboColor.ItemHeight = 15
            Me.cboColor.Location = New System.Drawing.Point(288, 152)
            Me.cboColor.MatchEntryTimeout = CType(2000, Long)
            Me.cboColor.MaxDropDownItems = CType(10, Short)
            Me.cboColor.MaxLength = 32767
            Me.cboColor.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboColor.Name = "cboColor"
            Me.cboColor.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboColor.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboColor.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboColor.Size = New System.Drawing.Size(216, 21)
            Me.cboColor.TabIndex = 146
            Me.cboColor.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:HotTrack;}Style3{}Inactive{ForeColor:InactiveCaptionText;Bac" & _
            "kColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Microsoft " & _
            "Sans Serif, 8.25pt;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}St" & _
            "yle9{AlignHorz:Near;}OddRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:True" & _
            ";AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Cont" & _
            "rol;}Style8{}Style10{}Style11{}Style1{}</Data></Styles><Splits><C1.Win.C1List.Li" & _
            "stBoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCapt" & _
            "ionHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" HorizontalScrollG" & _
            "roup=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height><VScrollBar>" & _
            "<Width>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScrollBar><Capti" & _
            "onStyle parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7""" & _
            " /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Sty" & _
            "le11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""" & _
            "HighlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddR" & _
            "owStyle parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""RecordSelecto" & _
            "r"" me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><Style parent=""" & _
            "Normal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedStyles><Style p" & _
            "arent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Head" & _
            "ing"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading" & _
            """ me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" " & _
            "me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal""" & _
            " me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Capt" & _
            "ion"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSpl" & _
            "its><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth></Blob>"
            '
            'lblColor
            '
            Me.lblColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblColor.ForeColor = System.Drawing.Color.White
            Me.lblColor.Location = New System.Drawing.Point(160, 152)
            Me.lblColor.Name = "lblColor"
            Me.lblColor.Size = New System.Drawing.Size(120, 21)
            Me.lblColor.TabIndex = 147
            Me.lblColor.Text = "Color:"
            Me.lblColor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'StatusProduce
            '
            Me.StatusProduce.BackColor = System.Drawing.Color.DimGray
            Me.StatusProduce.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.StatusProduce.Name = "StatusProduce"
            Me.StatusProduce.Size = New System.Drawing.Size(800, 80)
            Me.StatusProduce.TabIndex = 148
            Me.StatusProduce.Text = "Status"
            '
            'btnClear
            '
            Me.btnClear.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
            Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
            Me.btnClear.ForeColor = System.Drawing.Color.White
            Me.btnClear.Location = New System.Drawing.Point(448, 200)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(56, 30)
            Me.btnClear.TabIndex = 149
            Me.btnClear.Text = "CLEAR"
            '
            'lblRePrintLabel
            '
            Me.lblRePrintLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRePrintLabel.ForeColor = System.Drawing.Color.White
            Me.lblRePrintLabel.Location = New System.Drawing.Point(176, 128)
            Me.lblRePrintLabel.Name = "lblRePrintLabel"
            Me.lblRePrintLabel.Size = New System.Drawing.Size(120, 16)
            Me.lblRePrintLabel.TabIndex = 144
            Me.lblRePrintLabel.Text = "Serial Number:"
            Me.lblRePrintLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtRePrintLabel
            '
            Me.txtRePrintLabel.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
            Me.txtRePrintLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtRePrintLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtRePrintLabel.Location = New System.Drawing.Point(304, 120)
            Me.txtRePrintLabel.Name = "txtRePrintLabel"
            Me.txtRePrintLabel.Size = New System.Drawing.Size(216, 26)
            Me.txtRePrintLabel.TabIndex = 143
            Me.txtRePrintLabel.Text = ""
            '
            'btnRePrintLabel
            '
            Me.btnRePrintLabel.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(0, Byte), CType(0, Byte))
            Me.btnRePrintLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRePrintLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
            Me.btnRePrintLabel.Location = New System.Drawing.Point(328, 168)
            Me.btnRePrintLabel.Name = "btnRePrintLabel"
            Me.btnRePrintLabel.Size = New System.Drawing.Size(168, 32)
            Me.btnRePrintLabel.TabIndex = 145
            Me.btnRePrintLabel.Text = "Re-Print Label"
            '
            'TabControl1
            '
            Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpProduce, Me.tpLabel})
            Me.TabControl1.Location = New System.Drawing.Point(0, 48)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(800, 520)
            Me.TabControl1.TabIndex = 153
            '
            'tpProduce
            '
            Me.tpProduce.BackColor = System.Drawing.Color.RoyalBlue
            Me.tpProduce.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtSerial, Me.lblColor, Me.cboColor, Me.btnClear, Me.lblSerial, Me.btnComplete, Me.StatusProduce})
            Me.tpProduce.Location = New System.Drawing.Point(4, 22)
            Me.tpProduce.Name = "tpProduce"
            Me.tpProduce.Size = New System.Drawing.Size(792, 494)
            Me.tpProduce.TabIndex = 0
            Me.tpProduce.Text = "Produce"
            '
            'tpLabel
            '
            Me.tpLabel.BackColor = System.Drawing.Color.Teal
            Me.tpLabel.Controls.AddRange(New System.Windows.Forms.Control() {Me.StatusLabel, Me.btnRePrintLabel, Me.lblRePrintLabel, Me.txtRePrintLabel})
            Me.tpLabel.Location = New System.Drawing.Point(4, 22)
            Me.tpLabel.Name = "tpLabel"
            Me.tpLabel.Size = New System.Drawing.Size(792, 494)
            Me.tpLabel.TabIndex = 1
            Me.tpLabel.Text = "Re-Print Label"
            '
            'StatusLabel
            '
            Me.StatusLabel.BackColor = System.Drawing.Color.DimGray
            Me.StatusLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.StatusLabel.Name = "StatusLabel"
            Me.StatusLabel.Size = New System.Drawing.Size(800, 80)
            Me.StatusLabel.TabIndex = 149
            Me.StatusLabel.Text = "Status"
            '
            'frmProduce
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(6, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(792, 566)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1, Me._Tittle})
            Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ForeColor = System.Drawing.Color.Lime
            Me.Name = "frmProduce"
            Me.Text = "frmProduce"
            CType(Me.cboColor, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControl1.ResumeLayout(False)
            Me.tpProduce.ResumeLayout(False)
            Me.tpLabel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Loading"

        Private Sub frmProduce_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ResetVariables()
            Me.TabControl1.TabIndex = 2
            LoadColor()
            StatusProduce.ForeColor = Color.Lime
            StatusProduce.Text = "Please scan a valid Nespresso serial number..."
            StatusLabel.ForeColor = Color.Lime
            StatusLabel.Text = "Please scan a valid Nespresso serial number then click on 'Re-Print Label' to print."
        End Sub

        '********************************************************************************************************

        Private Sub LoadColor()
            Dim ojbMisc As New PSS.Data.Production.Misc()
            Dim dt As DataTable

            Try
                Me._booPopDataToCombo = True
                Me.cboColor.DataSource = Nothing : Me.cboColor.Text = ""
                dt = ojbMisc.GetDataTable("Select ColorID,ColorName From Color order by ColorName")
                dt.LoadDataRow(New Object() {0, "--Select Color--"}, False)
                Misc.PopulateC1DropDownList(Me.cboColor, dt, "ColorName", "ColorID")
                Me.cboColor.SelectedValue = 0

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "LoadColor", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me._booPopDataToCombo = False
                Generic.DisposeDT(dt)
            End Try
        End Sub
        '*******************************************************************

        '*******************************************************************
#End Region

#Region "Buttons/Text/Combo events"
        '*******************************************************************
        Private Sub txtSerial_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSerial.KeyDown
            If e.KeyValue = 13 AndAlso Me.txtSerial.Text.Trim.Length > 0 Then
                Me.ProcessSN()
            End If
        End Sub

        '*******************************************************************

        Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
            Me.ResetVariables()
            Me.cboColor.SelectedValue = 0
        End Sub

        '*******************************************************************

        Private Sub btnComplete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComplete.Click
            Dim strWorkDate As String = PSS.Core.Global.ApplicationUser.Workdate
            Dim objNespresso As New PSS.Data.Buisness.Nespresso.Nespresso()
            Dim iShiftID As Integer

            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                iShiftID = PSS.Core.ApplicationUser.IDShift
                If Me.txtSerial.Text = "" Then
                    StatusProduce.ForeColor = Color.Red
                    StatusProduce.Text = "Please scan device serial number..."
                    Exit Sub
                ElseIf Me.cboColor.SelectedValue = 0 Then
                    StatusProduce.ForeColor = Color.Red
                    StatusProduce.Text = "Please select device color..."
                    Exit Sub
                Else
                    objNespresso.ProduceCompletion(Me._DeviceID, Me.cboColor.SelectedText, strWorkDate, iShiftID)
                    objNespresso.Label_PrintProduceLabel(Me.txtSerial.Text)
                    Me.ResetVariables()
                    StatusProduce.ForeColor = Color.Lime
                    StatusProduce.Text = "The device serial# " & Me.txtSerial.Text & " has been completed ! Please scan another serial number..."
                    Me.txtRePrintLabel.Text = Me.txtSerial.Text
                End If



            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnComplete_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                objNespresso = Nothing
                Cursor.Current = Cursors.Default
                Me.Enabled = True

            End Try

        End Sub


        '********************************************************************************************************

        Private Sub cbo_RowChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboColor.RowChange

            Try
                If Me._booPopDataToCombo = False Then

                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    Me.btnComplete.Enabled = False

                    If sender.name = "cboColor" Then
                        If Me.txtSerial.Text = "" Then
                            StatusProduce.ForeColor = Color.Red
                            StatusProduce.Text = "Please scan device serial number..."
                        ElseIf Me.cboColor.SelectedValue = 0 Then
                            StatusProduce.ForeColor = Color.Red
                            StatusProduce.Text = "Please select device color..."
                        Else
                            StatusProduce.ForeColor = Color.Lime
                            StatusProduce.Text = "Please click on the 'Complete' button to finish..."
                            Me.btnComplete.Enabled = True
                        End If

                    End If

                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cbo_RowChange", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub btnRePrintLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRePrintLabel.Click

            Dim ojbMisc As New PSS.Data.Production.Misc()
            Dim objNespresso As New PSS.Data.Buisness.Nespresso.Nespresso()
            Dim dt As DataTable
            Dim strsql As String

            Try
                Me.txtRePrintLabel.Text = Trim(Me.txtRePrintLabel.Text.ToUpper)

                If Me.txtRePrintLabel.Text = "" Then
                    StatusLabel.ForeColor = Color.Red
                    StatusLabel.Text = "No Re-Print Serial Number entered !" & Environment.NewLine & "Please scan a valid serial number..."
                    Me.txtRePrintLabel.Focus()
                    Exit Sub
                End If

                strsql = "SELECT 'REFURBISHED' as Description, a.SN1 as Serial, a.SN2 as MfgSerial, a.SN4 as Color, m.Model_Desc as Model " & Environment.NewLine
                strsql &= "FROM tasndata a inner join tmodel m ON m.Model_ID=a.Model_ID " & Environment.NewLine
                strsql &= "WHERE a.SN1='" & Me.txtRePrintLabel.Text & "' " & Environment.NewLine
                strsql &= "AND a.SN4 IS NOT NULL;"

                dt = ojbMisc.GetDataTable(strsql)
                If dt.Rows.Count = 0 Then
                    StatusLabel.ForeColor = Color.Red
                    StatusLabel.Text = "The Re-Print Serial# " & Me.txtRePrintLabel.Text & " is not in system or hasn't been produced. " & Environment.NewLine & " Please rescan a valid serial number..."
                    Me.txtRePrintLabel.Focus()
                    Exit Sub
                Else
                    objNespresso.Label_PrintProduceLabel(Me.txtRePrintLabel.Text)
                    StatusLabel.ForeColor = Color.Lime
                    StatusLabel.Text = "The label for Serial# " & Me.txtRePrintLabel.Text & " has been printed."
                    Me.txtRePrintLabel.SelectAll()
                    Me.txtRePrintLabel.Focus()
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRePrintLabel", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                objNespresso = Nothing
                ojbMisc = Nothing
                Generic.DisposeDT(dt)
            End Try

        End Sub

        '*************************************************************************************************************

#End Region

#Region "Functions & Sub"

        '*******************************************************************
        Private Sub ProcessSN()

            Try

                Me.txtSerial.Text = Me.txtSerial.Text.Trim.ToUpper
                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                ' For Test
                'If DoValidation(txtSerial.Text) <> False Then
                If DoValidation(txtSerial.Text) = False Then
                    Me.Enabled = True
                    Me.txtSerial.Text = ""
                    Me.txtSerial.Focus()
                Else
                    Me.txtSerial.Enabled = False
                    If Me.cboColor.SelectedValue > 0 Then
                        StatusProduce.Text = "Please click on the 'Complete' button to finish..."
                        Me.btnComplete.Enabled = True
                    Else
                        StatusProduce.Text = "Please select device color then click on the 'Complete' button to finish..."
                        Me.btnComplete.Enabled = False
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Cursor.Current = Cursors.Default
                Me.Enabled = True

            End Try
        End Sub


        '*******************************************************************
        Private Function DoValidation(ByVal Serial As String) As Boolean

            Dim iMaxBillRule As Integer = 0
            Dim dtDevice, dtPressure, dtHipot As DataTable
            Dim ojbMisc As New PSS.Data.Production.Misc()
            Dim ojbBill As New PSS.Data.Buisness.Generic()
            Dim objNewTech As New PSS.Data.Buisness.NewTech()
            Me._DeviceID = 0

            Try
                StatusProduce.ForeColor = Color.Red
                'For Test
                'dtDevice = objNewTech.GetDeviceInWip(Serial, Me._CusID)
                Me._DeviceID = (dtDevice.Rows(0)("Device_ID"))
                If dtDevice.Rows.Count < 1 Then
                    StatusProduce.Text = "This device serial# " & Serial & " does not exist in the system or has been assigned to pallet or shipped."
                    Return False
                ElseIf dtDevice.Rows.Count > 1 Then
                    StatusProduce.Text = "This device serial# " & Serial & " existed more than one in the system. Please contact your lead or supervisor."
                    Return False
                ElseIf IsDBNull(dtDevice.Rows(0)("Device_DateBill")) Then
                    StatusProduce.Text = "This device serial#" & Serial & " has not been billed."
                    Return False
                Else
                    Me._DeviceID = (dtDevice.Rows(0)("Device_ID"))
                    dtPressure = ojbMisc.GetDataTable("select * from lbillcodes where BillCode_ID=2131 and billtype_id=1 And device_id=" & Me._ProdID)
                    dtHipot = ojbMisc.GetDataTable("select * from lbillcodes where BillCode_ID=2132 and billtype_id=1 And device_id=" & Me._ProdID)
                    iMaxBillRule = ojbBill.GetMaxBillRule(Me._DeviceID)

                    If dtPressure.Rows.Count < 1 Then
                        StatusProduce.Text = "Pressure Test billing for this device serial# " & Serial & " hasn't mapped. Please contact supervisor."
                        Return False
                    ElseIf dtHipot.Rows.Count < 1 Then
                        StatusProduce.Text = "Hipot test billing fir this device serial# " & Serial & " hasn't mapped. Please contact supervisor."
                        Return False
                    ElseIf iMaxBillRule <> 0 Then
                        StatusProduce.Text = "This device serial# " & Serial & " is not belongs to refurbish."
                        Return False
                    ElseIf Generic.IsValidQCResults(Me._DeviceID, 1, "Functional", True, True) = False Then
                        StatusProduce.Text = "This device serial#" & Serial & " has not passed QC."
                        Return False
                    Else
                        StatusProduce.ForeColor = Color.Lime
                        Return True
                    End If

                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "DoValidation", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return False
            Finally
                Buisness.Generic.DisposeDT(dtDevice)
                Buisness.Generic.DisposeDT(dtPressure)
                Buisness.Generic.DisposeDT(dtHipot)
                ojbMisc = Nothing
                ojbBill = Nothing
                objNewTech = Nothing

            End Try

        End Function

        '*****************************************************************
        Private Sub ResetVariables()

            'Reset global variables

            Cursor.Current = Cursors.Default
            Me.Enabled = True
            Me._DeviceID = 0
            Me.btnComplete.Enabled = False
            Me.txtSerial.Enabled = True
            Me.txtSerial.Text = ""
            Me.txtSerial.Focus()

        End Sub
        '*****************************************************************



#End Region




    End Class
End Namespace