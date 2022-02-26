Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.Pantech

    Public Class frmPantechLabel

        Inherits System.Windows.Forms.Form

        Private Const _iCustID As Integer = 2453
        Private Const _iLocID As Integer = 3251
        Private _strScreenName As String = ""
        Private _iDevice_ID As Integer = 0
        Private _objLabel As PSS.Data.Buisness.Pantech
        Private _iModel_ID As Integer = 0


#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strScreenName As String)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _strScreenName = strScreenName
            _objLabel = New PSS.Data.Buisness.Pantech()
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
        Friend WithEvents cmdlblprint As System.Windows.Forms.Button
        Friend WithEvents txtIMEI As System.Windows.Forms.TextBox
        Friend WithEvents txtSNMSN As System.Windows.Forms.TextBox
        Friend WithEvents lblIMEI As System.Windows.Forms.Label
        Friend WithEvents lblFCC As System.Windows.Forms.Label
        Friend WithEvents lblHWREV As System.Windows.Forms.Label
        Friend WithEvents txtHW As System.Windows.Forms.TextBox
        Friend WithEvents lblModel As System.Windows.Forms.Label
        Friend WithEvents lblMadeIn As System.Windows.Forms.Label
        Friend WithEvents lblSN As System.Windows.Forms.Label
        Friend WithEvents txtFCCID As System.Windows.Forms.TextBox
        Friend WithEvents txtModelNo As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents cboLabelType As System.Windows.Forms.ComboBox
        Friend WithEvents C1Combo1 As C1.Win.C1List.C1Combo
        Friend WithEvents cboMadeIn As C1.Win.C1List.C1Combo
        Friend WithEvents pnlMain As System.Windows.Forms.Panel
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents txtSku As System.Windows.Forms.TextBox
        Friend WithEvents lblSKU As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPantechLabel))
            Me.txtIMEI = New System.Windows.Forms.TextBox()
            Me.lblIMEI = New System.Windows.Forms.Label()
            Me.pnlMain = New System.Windows.Forms.Panel()
            Me.cboMadeIn = New C1.Win.C1List.C1Combo()
            Me.cboLabelType = New System.Windows.Forms.ComboBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtFCCID = New System.Windows.Forms.TextBox()
            Me.lblFCC = New System.Windows.Forms.Label()
            Me.txtModelNo = New System.Windows.Forms.TextBox()
            Me.txtSku = New System.Windows.Forms.TextBox()
            Me.lblSKU = New System.Windows.Forms.Label()
            Me.lblModel = New System.Windows.Forms.Label()
            Me.lblMadeIn = New System.Windows.Forms.Label()
            Me.txtHW = New System.Windows.Forms.TextBox()
            Me.lblHWREV = New System.Windows.Forms.Label()
            Me.txtSNMSN = New System.Windows.Forms.TextBox()
            Me.lblSN = New System.Windows.Forms.Label()
            Me.cmdlblprint = New System.Windows.Forms.Button()
            Me.C1Combo1 = New C1.Win.C1List.C1Combo()
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.pnlMain.SuspendLayout()
            CType(Me.cboMadeIn, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.C1Combo1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'txtIMEI
            '
            Me.txtIMEI.Location = New System.Drawing.Point(96, 64)
            Me.txtIMEI.Name = "txtIMEI"
            Me.txtIMEI.Size = New System.Drawing.Size(179, 20)
            Me.txtIMEI.TabIndex = 1
            Me.txtIMEI.Text = ""
            '
            'lblIMEI
            '
            Me.lblIMEI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblIMEI.Location = New System.Drawing.Point(16, 64)
            Me.lblIMEI.Name = "lblIMEI"
            Me.lblIMEI.Size = New System.Drawing.Size(80, 16)
            Me.lblIMEI.TabIndex = 1
            Me.lblIMEI.Text = "IMEI/MEID:"
            Me.lblIMEI.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'pnlMain
            '
            Me.pnlMain.BackColor = System.Drawing.Color.LightSteelBlue
            Me.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlMain.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboMadeIn, Me.cboLabelType, Me.Label1, Me.txtFCCID, Me.lblFCC, Me.txtModelNo, Me.txtSku, Me.lblSKU, Me.lblModel, Me.lblMadeIn, Me.txtIMEI, Me.lblIMEI, Me.txtHW, Me.lblHWREV, Me.txtSNMSN, Me.lblSN})
            Me.pnlMain.Location = New System.Drawing.Point(8, 88)
            Me.pnlMain.Name = "pnlMain"
            Me.pnlMain.Size = New System.Drawing.Size(632, 208)
            Me.pnlMain.TabIndex = 2
            '
            'cboMadeIn
            '
            Me.cboMadeIn.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboMadeIn.AutoCompletion = True
            Me.cboMadeIn.AutoDropDown = True
            Me.cboMadeIn.AutoSelect = True
            Me.cboMadeIn.Caption = ""
            Me.cboMadeIn.CaptionHeight = 17
            Me.cboMadeIn.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboMadeIn.ColumnCaptionHeight = 17
            Me.cboMadeIn.ColumnFooterHeight = 17
            Me.cboMadeIn.ColumnHeaders = False
            Me.cboMadeIn.ContentHeight = 15
            Me.cboMadeIn.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboMadeIn.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboMadeIn.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboMadeIn.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboMadeIn.EditorHeight = 15
            Me.cboMadeIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboMadeIn.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboMadeIn.ItemHeight = 15
            Me.cboMadeIn.Location = New System.Drawing.Point(384, 32)
            Me.cboMadeIn.MatchEntryTimeout = CType(2000, Long)
            Me.cboMadeIn.MaxDropDownItems = CType(10, Short)
            Me.cboMadeIn.MaxLength = 32767
            Me.cboMadeIn.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboMadeIn.Name = "cboMadeIn"
            Me.cboMadeIn.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboMadeIn.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboMadeIn.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboMadeIn.Size = New System.Drawing.Size(176, 21)
            Me.cboMadeIn.TabIndex = 9
            Me.cboMadeIn.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'cboLabelType
            '
            Me.cboLabelType.Items.AddRange(New Object() {"Label", "Relabel"})
            Me.cboLabelType.Location = New System.Drawing.Point(96, 30)
            Me.cboLabelType.Name = "cboLabelType"
            Me.cboLabelType.Size = New System.Drawing.Size(179, 21)
            Me.cboLabelType.TabIndex = 0
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.Location = New System.Drawing.Point(16, 30)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(80, 16)
            Me.Label1.TabIndex = 27
            Me.Label1.Text = "Label Type:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtFCCID
            '
            Me.txtFCCID.Enabled = False
            Me.txtFCCID.Location = New System.Drawing.Point(384, 96)
            Me.txtFCCID.Name = "txtFCCID"
            Me.txtFCCID.Size = New System.Drawing.Size(176, 20)
            Me.txtFCCID.TabIndex = 14
            Me.txtFCCID.Text = ""
            '
            'lblFCC
            '
            Me.lblFCC.Enabled = False
            Me.lblFCC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblFCC.Location = New System.Drawing.Point(312, 96)
            Me.lblFCC.Name = "lblFCC"
            Me.lblFCC.Size = New System.Drawing.Size(72, 16)
            Me.lblFCC.TabIndex = 24
            Me.lblFCC.Text = "FCC ID:"
            Me.lblFCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtModelNo
            '
            Me.txtModelNo.Enabled = False
            Me.txtModelNo.Location = New System.Drawing.Point(96, 128)
            Me.txtModelNo.Name = "txtModelNo"
            Me.txtModelNo.Size = New System.Drawing.Size(176, 20)
            Me.txtModelNo.TabIndex = 13
            Me.txtModelNo.Text = ""
            '
            'txtSku
            '
            Me.txtSku.Enabled = False
            Me.txtSku.Location = New System.Drawing.Point(96, 96)
            Me.txtSku.Name = "txtSku"
            Me.txtSku.Size = New System.Drawing.Size(176, 20)
            Me.txtSku.TabIndex = 12
            Me.txtSku.Text = ""
            '
            'lblSKU
            '
            Me.lblSKU.Enabled = False
            Me.lblSKU.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSKU.Location = New System.Drawing.Point(16, 96)
            Me.lblSKU.Name = "lblSKU"
            Me.lblSKU.Size = New System.Drawing.Size(80, 16)
            Me.lblSKU.TabIndex = 21
            Me.lblSKU.Text = "SKU:"
            Me.lblSKU.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblModel
            '
            Me.lblModel.Enabled = False
            Me.lblModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblModel.Location = New System.Drawing.Point(16, 128)
            Me.lblModel.Name = "lblModel"
            Me.lblModel.Size = New System.Drawing.Size(80, 16)
            Me.lblModel.TabIndex = 11
            Me.lblModel.Text = "Model No:"
            Me.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblMadeIn
            '
            Me.lblMadeIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblMadeIn.Location = New System.Drawing.Point(312, 32)
            Me.lblMadeIn.Name = "lblMadeIn"
            Me.lblMadeIn.Size = New System.Drawing.Size(72, 16)
            Me.lblMadeIn.TabIndex = 7
            Me.lblMadeIn.Text = "Made in:"
            Me.lblMadeIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtHW
            '
            Me.txtHW.Enabled = False
            Me.txtHW.Location = New System.Drawing.Point(384, 128)
            Me.txtHW.Name = "txtHW"
            Me.txtHW.Size = New System.Drawing.Size(176, 20)
            Me.txtHW.TabIndex = 1
            Me.txtHW.Text = ""
            '
            'lblHWREV
            '
            Me.lblHWREV.Enabled = False
            Me.lblHWREV.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblHWREV.Location = New System.Drawing.Point(304, 128)
            Me.lblHWREV.Name = "lblHWREV"
            Me.lblHWREV.Size = New System.Drawing.Size(72, 16)
            Me.lblHWREV.TabIndex = 19
            Me.lblHWREV.Text = "H/W REV:"
            Me.lblHWREV.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtSNMSN
            '
            Me.txtSNMSN.Location = New System.Drawing.Point(384, 64)
            Me.txtSNMSN.Name = "txtSNMSN"
            Me.txtSNMSN.Size = New System.Drawing.Size(176, 20)
            Me.txtSNMSN.TabIndex = 1
            Me.txtSNMSN.Text = ""
            '
            'lblSN
            '
            Me.lblSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSN.Location = New System.Drawing.Point(280, 64)
            Me.lblSN.Name = "lblSN"
            Me.lblSN.Size = New System.Drawing.Size(104, 16)
            Me.lblSN.TabIndex = 3
            Me.lblSN.Text = "SN:"
            Me.lblSN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmdlblprint
            '
            Me.cmdlblprint.BackColor = System.Drawing.Color.Green
            Me.cmdlblprint.Enabled = False
            Me.cmdlblprint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdlblprint.ForeColor = System.Drawing.Color.White
            Me.cmdlblprint.Location = New System.Drawing.Point(240, 328)
            Me.cmdlblprint.Name = "cmdlblprint"
            Me.cmdlblprint.Size = New System.Drawing.Size(185, 46)
            Me.cmdlblprint.TabIndex = 12
            Me.cmdlblprint.Text = "Print "
            '
            'C1Combo1
            '
            Me.C1Combo1.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.C1Combo1.Caption = ""
            Me.C1Combo1.CaptionHeight = 17
            Me.C1Combo1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.C1Combo1.ColumnCaptionHeight = 19
            Me.C1Combo1.ColumnFooterHeight = 19
            Me.C1Combo1.ContentHeight = 14
            Me.C1Combo1.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.C1Combo1.EditorBackColor = System.Drawing.SystemColors.Window
            Me.C1Combo1.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.C1Combo1.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.C1Combo1.EditorHeight = 14
            Me.C1Combo1.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.C1Combo1.ItemHeight = 15
            Me.C1Combo1.Location = New System.Drawing.Point(520, 320)
            Me.C1Combo1.MatchEntryTimeout = CType(2000, Long)
            Me.C1Combo1.MaxDropDownItems = CType(5, Short)
            Me.C1Combo1.MaxLength = 32767
            Me.C1Combo1.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.C1Combo1.Name = "C1Combo1"
            Me.C1Combo1.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.C1Combo1.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.C1Combo1.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.C1Combo1.Size = New System.Drawing.Size(215, 20)
            Me.C1Combo1.TabIndex = 0
            Me.C1Combo1.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
            "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style1{}OddRow{}RecordSelector{Alig" & _
            "nImage:Center;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;For" & _
            "eColor:ControlText;AlignVert:Center;}Style8{}Style10{}Style11{}Style9{AlignHorz:" & _
            "Near;}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" " & _
            "Name=""Split[0,0]"" CaptionHeight=""19"" ColumnCaptionHeight=""19"" ColumnFooterHeight" & _
            "=""19"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 1" & _
            "56</ClientRect><Height>156</Height><VScrollBar><Width>20</Width></VScrollBar><HS" & _
            "crollBar><Height>20</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style" & _
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
            'lblTitle
            '
            Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTitle.ForeColor = System.Drawing.Color.Purple
            Me.lblTitle.Location = New System.Drawing.Point(8, 8)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(632, 64)
            Me.lblTitle.TabIndex = 15
            Me.lblTitle.Text = "Pantech Label"
            Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'frmPantechLabel
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(680, 509)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblTitle, Me.cmdlblprint, Me.pnlMain})
            Me.Name = "frmPantechLabel"
            Me.Text = "frmPantechLabel"
            Me.pnlMain.ResumeLayout(False)
            CType(Me.cboMadeIn, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.C1Combo1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '******************************************************************
        Private Sub frmPantechLabel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable

            Try

                Me.cboLabelType.SelectedIndex = 1

                dt = _objLabel.Label_GetManufCountry(True)
                Misc.PopulateC1DropDownList(Me.cboMadeIn, dt, "mc_name", "mc_id")
                Me.cboMadeIn.SelectedValue = 3
                '1, 'China'
                '2, 'Mexico'
                '3, 'Korea'
                '4, 'USA',


                Me.txtIMEI.Focus()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmPantechLabel_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '******************************************************************
        Private Sub FillLabelInfo_Label()
            Dim dt1, dt, dt2 As DataTable
            Dim R1 As DataRow
            Dim strWorkStation As String = " "

            Try
                dt1 = Me._objLabel.Label_GetDeviceInfo(Trim(Me.txtIMEI.Text), Me._iCustID)

                If dt1.Rows.Count > 0 Then
                    If dt1.Rows.Count > 1 Then
                        Throw New Exception("Serial #'s duplicated in the system. Please contact IT.")
                    Else
                        If Me.cboLabelType.SelectedIndex = 0 Then
                            strWorkStation = dt1.Rows(0)("WorkStation").ToString.Trim.ToUpper
                            If strWorkStation <> "Pantech Label" Then
                                MessageBox.Show("This device belongs to " & dt1.Rows(0)("WorkStation").ToString & " workstation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                Me.txtIMEI.Text = ""
                                Exit Sub
                            End If
                        End If
                    End If
                Else
                    MessageBox.Show("The device scanned in does not exist or already shipped.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
                    Exit Sub
                End If

                _iDevice_ID = dt1.Rows(0)("Device_id")
                _iModel_ID = dt1.Rows(0)("Model_id")


                '********************************
                'Display Label Panel(s)
                '********************************

                'SN
                If CInt(dt1.Rows(0)("Manuf_ID")) = 64 Then
                    If Not IsDBNull(dt1.Rows(0)("cellopt_msn")) AndAlso dt1.Rows(0)("cellopt_msn").ToString.Trim.Length > 0 Then
                        Me.txtSNMSN.Text = dt1.Rows(0)("cellopt_msn").ToString.Trim.ToUpper
                        Me.txtSNMSN.Enabled = False
                    Else
                        Me.txtSNMSN.Enabled = True
                    End If

                End If

                If Not IsDBNull(dt1.Rows(0)("HW")) AndAlso dt1.Rows(0)("HW").ToString.Trim.Length > 0 Then
                    Me.txtHW.Text = dt1.Rows(0)("HW")
                End If

                If Not IsDBNull(dt1.Rows(0)("SKU")) AndAlso dt1.Rows(0)("SKU").ToString.Trim.Length > 0 Then
                    Me.txtSku.Text = dt1.Rows(0)("SKU")
                End If

                If Not IsDBNull(dt1.Rows(0)("label_model_numb")) AndAlso dt1.Rows(0)("label_model_numb").ToString.Trim.Length > 0 Then
                    Me.txtModelNo.Text = dt1.Rows(0)("label_model_numb")
                End If

                If Not IsDBNull(dt1.Rows(0)("label_fcc")) AndAlso dt1.Rows(0)("label_fcc").ToString.Trim.Length > 0 Then
                    Me.txtFCCID.Text = dt1.Rows(0)("label_fcc")
                End If


            Catch ex As Exception
                MessageBox.Show(ex.ToString, "SN Scan", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
                Generic.DisposeDT(dt1)
                R1 = Nothing
            End Try
        End Sub

        '******************************************************************
        Private Sub cmdlblprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdlblprint.Click
            Const iIMEILabelBillcode As Integer = 1624
            Dim strNextWrkStation As String
            Dim i As Integer = 0
            Dim j As Integer = 0
            Dim objDevice As Rules.Device

            Try
                If Me.txtIMEI.Text.Trim.Length = 0 Then Exit Sub
                If Me._iDevice_ID = 0 Then
                    MessageBox.Show("System can't define device ID. Please re-enter IMEI #.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                DoValidation()

                strNextWrkStation = ""


                '*****************************************************
                'WE DO NOT PUSH UNIT TO ANY WORKSTATION AT THIS POINT
                'lworkflowprocess currently not set up for this customer. 
                'remember to add 'Pantech Label' as screen name if lworkflowprocess required. 
                '*****************************************************
                'If Me.cboLabelType.SelectedIndex = 0 Then
                '    strNextWrkStation = PSS.Data.Buisness.Generic.GetNextWorkStationInWFP(Me._strScreenName, 0, Me._iCustID, 0)
                '    If strNextWrkStation.Trim.Length > 0 Then i = Generic.SetTcelloptWorkStationForDevice(strNextWrkStation, _iDevice_ID)
                '    If i > 0 Then MessageBox.Show("This device now belongs to " & strNextWrkStation & " workstation.", "Information", MessageBoxButtons.OK)
                'End If

                '*******************************************
                'PRINT LABEL
                '*******************************************
                j = Me._objLabel.Label_PrintLabel(Trim(Me.txtModelNo.Text), (Trim(Me.txtIMEI.Text)), Trim(Me.txtFCCID.Text), _
                UCase(Trim(Me.txtSNMSN.Text)), "", Me.cboMadeIn.Text, "", "", _
                "", Trim(Me.txtSku.Text), "", "", _
                Trim(Me.txtHW.Text), "", "", "", "")

                '*******************************************
                'UPDATE LABEL INFO INTO TCELLOPT TABLE
                '*******************************************

                j = Me._objLabel.Label_UpdateSNMSN_Tcell(_iDevice_ID, Me.txtSNMSN.Text.Trim.ToUpper)

                '*******************************************
                'BILL ( label, IMEI ) 
                '*******************************************
                objDevice = New Rules.Device(Me._iDevice_ID)
                If Generic.IsBillcodeMapped(Me._iModel_ID, iIMEILabelBillcode) > 0 AndAlso Generic.IsBillcodeExisted(Me._iDevice_ID, iIMEILabelBillcode) = False Then
                    objDevice.AddPart(iIMEILabelBillcode)
                    objDevice.Update()
                End If
                '*******************************************

                ClearVarsAndCtrls()
                Me.txtIMEI.Text = ""
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString, "Pantech Print Label", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.txtIMEI.Focus()
                If Not IsNothing(objDevice) Then
                    objDevice.Dispose()
                    objDevice = Nothing
                End If
            End Try
        End Sub

        '******************************************************************
        Private Sub DoValidation()

            If Trim(Me.txtIMEI.Text) = "" Then
                Throw New Exception("IMEI is missing.")
            ElseIf Trim(Me.txtSNMSN.Text) = "" Then
                Throw New Exception("SN/MSN is missing.")
            ElseIf Trim(Me.cboMadeIn.SelectedValue) < 1 Then
                Throw New Exception("Made in is missing.")
            ElseIf Trim(Me.txtHW.Text) = "" Then
                Throw New Exception("HW REV is missing. Please contact IT for assist.")
            ElseIf Trim(Me.txtFCCID.Text) = "" Then
                Throw New Exception("FCC is missing. Please contact IT for assist.")
            ElseIf Trim(Me.txtSku.Text) = "" Then
                Throw New Exception("SKU is missing. Please contact IT for assist.")
            ElseIf Trim(Me.txtModelNo.Text) = "" Then
                Throw New Exception("Model is missing. Please contact IT for assist.")
            End If


        End Sub

        '******************************************************************
        Private Sub ClearVarsAndCtrls()
            Me._iDevice_ID = 0
            Me._iModel_ID = 0
            Me.txtModelNo.Text = ""
            Me.txtFCCID.Text = ""
            Me.txtSNMSN.Text = ""
            Me.txtHW.Text = ""
            Me.txtSku.Text = ""
            Me.cmdlblprint.Enabled = False


        End Sub

        '*******************************************************************
        Private Sub KeyUpEvent(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIMEI.KeyUp, txtSNMSN.KeyUp, txtHW.KeyUp, cboMadeIn.KeyUp
            Try
                If e.KeyCode = Keys.Enter Then
                    Select Case sender.Name
                        Case "txtIMEI"
                            If Me.txtIMEI.Text.Trim.Length = 0 Then
                                Me.txtIMEI.Focus()
                                Exit Sub
                            ElseIf Me.txtIMEI.Text.Trim.Length > 0 Then
                                ClearVarsAndCtrls()
                                FillLabelInfo_Label()
                                Me.txtSNMSN.Focus()
                            End If
                        Case "txtSNMSN"
                            If Me.txtSNMSN.Text.Trim.Length > 0 Then
                                Me.cboMadeIn.Focus()
                            Else
                                Me.txtSNMSN.Focus()
                            End If

                        Case "cboMadeIn"
                            If Me.cboMadeIn.SelectedValue > 0 Then
                                Me.txtSNMSN.Focus()
                            Else
                                Me.cboMadeIn.SelectAll()
                                Me.cboMadeIn.Focus()
                            End If

                    End Select

                    If Me.txtIMEI.Text.Trim.Length > 0 And Me.txtSNMSN.Text.Trim.Length > 0 And Me.cboMadeIn.SelectedValue > 0 Then
                        cmdlblprint.Enabled = True
                    Else
                        cmdlblprint.Enabled = False
                    End If

                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "KeyUpEvent", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*******************************************************************
        Private Sub cboLabelType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLabelType.SelectedIndexChanged
            ClearVarsAndCtrls()
        End Sub

        '*******************************************************************


        '*******************************************************************

        Public Sub New()

        End Sub
    End Class
End Namespace