Option Explicit On 

Imports PSS.Data.Buisness
Imports System.Text

Namespace Gui.TracFoneFulfillmentKit
    Public Class frmTFFK_QC
        Inherits System.Windows.Forms.Form

        Private _UserID As Integer = PSS.Core.Global.ApplicationUser.IDuser
        Private _strEmpID As String = PSS.Core.Global.ApplicationUser.NumberEmp
        Private _strUser As String = PSS.Core.Global.ApplicationUser.User

        Private _objTFFK_QC As PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK_QC
        Private _BaseClass As PSS.Data.BaseClasses.CollectTrackingLog
        Private _strComputerName As String = ""
        Private _iJob_ID As Integer = 0

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._objTFFK_QC = New PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK_QC()
            Me._BaseClass = New PSS.Data.BaseClasses.CollectTrackingLog()
            Me._strComputerName = Me._BaseClass.GetComputerName
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                Try
                    Me._objTFFK_QC = Nothing
                Catch ex As Exception
                End Try
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
        Friend WithEvents cboLine As C1.Win.C1List.C1Combo
        Friend WithEvents lblLine As System.Windows.Forms.Label
        Friend WithEvents TxtEmployeeNo As System.Windows.Forms.TextBox
        Friend WithEvents cboFailCode As C1.Win.C1List.C1Combo
        Friend WithEvents txtTargetRate As System.Windows.Forms.TextBox
        Friend WithEvents txtJobNo As System.Windows.Forms.TextBox
        Friend WithEvents lblJobNo As System.Windows.Forms.Label
        Friend WithEvents txtWO As System.Windows.Forms.TextBox
        Friend WithEvents lblWO As System.Windows.Forms.Label
        Friend WithEvents txtModel As System.Windows.Forms.TextBox
        Friend WithEvents lblModel As System.Windows.Forms.Label
        Friend WithEvents txtSN As System.Windows.Forms.TextBox
        Friend WithEvents lblSN As System.Windows.Forms.Label
        Friend WithEvents lblDetails As System.Windows.Forms.Label
        Friend WithEvents btnPass As System.Windows.Forms.Button
        Friend WithEvents lblEmployeeNo As System.Windows.Forms.Label
        Friend WithEvents lblFailCode As System.Windows.Forms.Label
        Friend WithEvents lblTargetRate As System.Windows.Forms.Label
        Friend WithEvents txtDetails As System.Windows.Forms.TextBox
        Friend WithEvents txtJobQty As System.Windows.Forms.TextBox
        Friend WithEvents lblJobQty As System.Windows.Forms.Label
        Friend WithEvents lbllblTargetTotal As System.Windows.Forms.Label
        Friend WithEvents lbllblTestedTotal As System.Windows.Forms.Label
        Friend WithEvents lblTargetTotal As System.Windows.Forms.Label
        Friend WithEvents lblTestedTotal As System.Windows.Forms.Label
        Friend WithEvents lblPass As System.Windows.Forms.Label
        Friend WithEvents lbllblPass As System.Windows.Forms.Label
        Friend WithEvents lblFail As System.Windows.Forms.Label
        Friend WithEvents lbllblFail As System.Windows.Forms.Label
        Friend WithEvents lblPassRate As System.Windows.Forms.Label
        Friend WithEvents lbllblPassRate As System.Windows.Forms.Label
        Friend WithEvents btnRemove As System.Windows.Forms.Button
        Friend WithEvents btnViewRpt As System.Windows.Forms.Button
        Friend WithEvents btnReset As System.Windows.Forms.Button
        Friend WithEvents btnStartJob As System.Windows.Forms.Button
        Friend WithEvents pnlFailCode As System.Windows.Forms.Panel
        Friend WithEvents pnlJob As System.Windows.Forms.Panel
        Friend WithEvents pnlWOModelSN As System.Windows.Forms.Panel
        Friend WithEvents chkKeepWO As System.Windows.Forms.CheckBox
        Friend WithEvents chkKeepModel As System.Windows.Forms.CheckBox
        Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
        Friend WithEvents btnFail As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTFFK_QC))
            Me.cboLine = New C1.Win.C1List.C1Combo()
            Me.lblLine = New System.Windows.Forms.Label()
            Me.lblEmployeeNo = New System.Windows.Forms.Label()
            Me.TxtEmployeeNo = New System.Windows.Forms.TextBox()
            Me.cboFailCode = New C1.Win.C1List.C1Combo()
            Me.lblFailCode = New System.Windows.Forms.Label()
            Me.txtTargetRate = New System.Windows.Forms.TextBox()
            Me.lblTargetRate = New System.Windows.Forms.Label()
            Me.txtJobNo = New System.Windows.Forms.TextBox()
            Me.lblJobNo = New System.Windows.Forms.Label()
            Me.txtWO = New System.Windows.Forms.TextBox()
            Me.lblWO = New System.Windows.Forms.Label()
            Me.txtModel = New System.Windows.Forms.TextBox()
            Me.lblModel = New System.Windows.Forms.Label()
            Me.txtSN = New System.Windows.Forms.TextBox()
            Me.lblSN = New System.Windows.Forms.Label()
            Me.txtDetails = New System.Windows.Forms.TextBox()
            Me.lblDetails = New System.Windows.Forms.Label()
            Me.pnlFailCode = New System.Windows.Forms.Panel()
            Me.btnPass = New System.Windows.Forms.Button()
            Me.btnFail = New System.Windows.Forms.Button()
            Me.txtJobQty = New System.Windows.Forms.TextBox()
            Me.lblJobQty = New System.Windows.Forms.Label()
            Me.lbllblTargetTotal = New System.Windows.Forms.Label()
            Me.lbllblTestedTotal = New System.Windows.Forms.Label()
            Me.lblTargetTotal = New System.Windows.Forms.Label()
            Me.lblTestedTotal = New System.Windows.Forms.Label()
            Me.lblPass = New System.Windows.Forms.Label()
            Me.lbllblPass = New System.Windows.Forms.Label()
            Me.lblFail = New System.Windows.Forms.Label()
            Me.lbllblFail = New System.Windows.Forms.Label()
            Me.lblPassRate = New System.Windows.Forms.Label()
            Me.lbllblPassRate = New System.Windows.Forms.Label()
            Me.btnRemove = New System.Windows.Forms.Button()
            Me.btnViewRpt = New System.Windows.Forms.Button()
            Me.btnReset = New System.Windows.Forms.Button()
            Me.btnStartJob = New System.Windows.Forms.Button()
            Me.pnlJob = New System.Windows.Forms.Panel()
            Me.pnlWOModelSN = New System.Windows.Forms.Panel()
            Me.chkKeepModel = New System.Windows.Forms.CheckBox()
            Me.chkKeepWO = New System.Windows.Forms.CheckBox()
            Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
            CType(Me.cboLine, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboFailCode, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlFailCode.SuspendLayout()
            Me.pnlJob.SuspendLayout()
            Me.pnlWOModelSN.SuspendLayout()
            Me.SuspendLayout()
            '
            'cboLine
            '
            Me.cboLine.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboLine.AutoCompletion = True
            Me.cboLine.AutoDropDown = True
            Me.cboLine.AutoSelect = True
            Me.cboLine.Caption = ""
            Me.cboLine.CaptionHeight = 17
            Me.cboLine.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboLine.ColumnCaptionHeight = 17
            Me.cboLine.ColumnFooterHeight = 17
            Me.cboLine.ColumnHeaders = False
            Me.cboLine.ContentHeight = 15
            Me.cboLine.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboLine.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboLine.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboLine.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboLine.EditorHeight = 15
            Me.cboLine.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboLine.ItemHeight = 15
            Me.cboLine.Location = New System.Drawing.Point(16, 32)
            Me.cboLine.MatchEntryTimeout = CType(2000, Long)
            Me.cboLine.MaxDropDownItems = CType(10, Short)
            Me.cboLine.MaxLength = 32767
            Me.cboLine.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboLine.Name = "cboLine"
            Me.cboLine.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboLine.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboLine.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboLine.Size = New System.Drawing.Size(64, 21)
            Me.cboLine.TabIndex = 5
            Me.cboLine.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'lblLine
            '
            Me.lblLine.Location = New System.Drawing.Point(16, 16)
            Me.lblLine.Name = "lblLine"
            Me.lblLine.Size = New System.Drawing.Size(64, 23)
            Me.lblLine.TabIndex = 144
            Me.lblLine.Text = "QC Line"
            '
            'lblEmployeeNo
            '
            Me.lblEmployeeNo.Location = New System.Drawing.Point(104, 16)
            Me.lblEmployeeNo.Name = "lblEmployeeNo"
            Me.lblEmployeeNo.Size = New System.Drawing.Size(104, 23)
            Me.lblEmployeeNo.TabIndex = 146
            Me.lblEmployeeNo.Text = "Employee #"
            '
            'TxtEmployeeNo
            '
            Me.TxtEmployeeNo.Location = New System.Drawing.Point(104, 32)
            Me.TxtEmployeeNo.Name = "TxtEmployeeNo"
            Me.TxtEmployeeNo.Size = New System.Drawing.Size(72, 22)
            Me.TxtEmployeeNo.TabIndex = 6
            Me.TxtEmployeeNo.Text = ""
            Me.TxtEmployeeNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'cboFailCode
            '
            Me.cboFailCode.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboFailCode.AutoCompletion = True
            Me.cboFailCode.AutoDropDown = True
            Me.cboFailCode.AutoSelect = True
            Me.cboFailCode.Caption = ""
            Me.cboFailCode.CaptionHeight = 17
            Me.cboFailCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboFailCode.ColumnCaptionHeight = 17
            Me.cboFailCode.ColumnFooterHeight = 17
            Me.cboFailCode.ColumnHeaders = False
            Me.cboFailCode.ContentHeight = 17
            Me.cboFailCode.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboFailCode.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboFailCode.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboFailCode.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboFailCode.EditorHeight = 17
            Me.cboFailCode.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboFailCode.ItemHeight = 15
            Me.cboFailCode.Location = New System.Drawing.Point(8, 24)
            Me.cboFailCode.MatchEntryTimeout = CType(2000, Long)
            Me.cboFailCode.MaxDropDownItems = CType(10, Short)
            Me.cboFailCode.MaxLength = 32767
            Me.cboFailCode.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboFailCode.Name = "cboFailCode"
            Me.cboFailCode.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboFailCode.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboFailCode.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboFailCode.Size = New System.Drawing.Size(328, 23)
            Me.cboFailCode.TabIndex = 148
            Me.cboFailCode.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:HotTrack;}Style3{}Inactive{ForeColor:InactiveCaptionText;Bac" & _
            "kColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{F" & _
            "oreColor:HighlightText;BackColor:Highlight;}Style1{}OddRow{}RecordSelector{Align" & _
            "Image:Center;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;Fore" & _
            "Color:ControlText;AlignVert:Center;}Style8{}Style10{}Style11{}Style9{AlignHorz:N" & _
            "ear;}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" N" & _
            "ame=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=" & _
            """17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 15" & _
            "6</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HSc" & _
            "rollBar><Height>16</Height><Style>None</Style></HScrollBar><CaptionStyle parent=" & _
            """Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle" & _
            " parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><Headin" & _
            "gStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" m" & _
            "e=""Style6"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=" & _
            """OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10""" & _
            " /><SelectedStyle parent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Sty" & _
            "le1"" /></C1.Win.C1List.ListBoxView></Splits><NamedStyles><Style parent="""" me=""No" & _
            "rmal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer" & _
            """ /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive""" & _
            " /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRo" & _
            "w"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" />" & _
            "<Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group""" & _
            " /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Mod" & _
            "ified</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth></Blob>"
            '
            'lblFailCode
            '
            Me.lblFailCode.Location = New System.Drawing.Point(8, 8)
            Me.lblFailCode.Name = "lblFailCode"
            Me.lblFailCode.Size = New System.Drawing.Size(64, 23)
            Me.lblFailCode.TabIndex = 149
            Me.lblFailCode.Text = "Fail Code"
            '
            'txtTargetRate
            '
            Me.txtTargetRate.Location = New System.Drawing.Point(200, 32)
            Me.txtTargetRate.Name = "txtTargetRate"
            Me.txtTargetRate.Size = New System.Drawing.Size(136, 22)
            Me.txtTargetRate.TabIndex = 71
            Me.txtTargetRate.Text = ""
            Me.txtTargetRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'lblTargetRate
            '
            Me.lblTargetRate.Location = New System.Drawing.Point(200, 16)
            Me.lblTargetRate.Name = "lblTargetRate"
            Me.lblTargetRate.Size = New System.Drawing.Size(160, 23)
            Me.lblTargetRate.TabIndex = 150
            Me.lblTargetRate.Text = "QC Target Test Rate %"
            '
            'txtJobNo
            '
            Me.txtJobNo.Location = New System.Drawing.Point(16, 32)
            Me.txtJobNo.MaxLength = 50
            Me.txtJobNo.Name = "txtJobNo"
            Me.txtJobNo.Size = New System.Drawing.Size(200, 22)
            Me.txtJobNo.TabIndex = 1
            Me.txtJobNo.Text = ""
            '
            'lblJobNo
            '
            Me.lblJobNo.Location = New System.Drawing.Point(16, 8)
            Me.lblJobNo.Name = "lblJobNo"
            Me.lblJobNo.Size = New System.Drawing.Size(176, 23)
            Me.lblJobNo.TabIndex = 152
            Me.lblJobNo.Text = "Job Number"
            '
            'txtWO
            '
            Me.txtWO.Location = New System.Drawing.Point(16, 24)
            Me.txtWO.MaxLength = 50
            Me.txtWO.Name = "txtWO"
            Me.txtWO.Size = New System.Drawing.Size(200, 22)
            Me.txtWO.TabIndex = 10
            Me.txtWO.Text = ""
            '
            'lblWO
            '
            Me.lblWO.Location = New System.Drawing.Point(16, 8)
            Me.lblWO.Name = "lblWO"
            Me.lblWO.Size = New System.Drawing.Size(176, 23)
            Me.lblWO.TabIndex = 154
            Me.lblWO.Text = "WorkOrder Number"
            '
            'txtModel
            '
            Me.txtModel.Location = New System.Drawing.Point(16, 80)
            Me.txtModel.MaxLength = 50
            Me.txtModel.Name = "txtModel"
            Me.txtModel.Size = New System.Drawing.Size(200, 22)
            Me.txtModel.TabIndex = 11
            Me.txtModel.Text = ""
            '
            'lblModel
            '
            Me.lblModel.Location = New System.Drawing.Point(16, 64)
            Me.lblModel.Name = "lblModel"
            Me.lblModel.Size = New System.Drawing.Size(176, 23)
            Me.lblModel.TabIndex = 156
            Me.lblModel.Text = "Model Name"
            '
            'txtSN
            '
            Me.txtSN.Location = New System.Drawing.Point(16, 128)
            Me.txtSN.MaxLength = 50
            Me.txtSN.Name = "txtSN"
            Me.txtSN.Size = New System.Drawing.Size(200, 22)
            Me.txtSN.TabIndex = 12
            Me.txtSN.Text = ""
            '
            'lblSN
            '
            Me.lblSN.Location = New System.Drawing.Point(16, 112)
            Me.lblSN.Name = "lblSN"
            Me.lblSN.Size = New System.Drawing.Size(176, 23)
            Me.lblSN.TabIndex = 158
            Me.lblSN.Text = "Serial Number"
            '
            'txtDetails
            '
            Me.txtDetails.Location = New System.Drawing.Point(8, 80)
            Me.txtDetails.Multiline = True
            Me.txtDetails.Name = "txtDetails"
            Me.txtDetails.Size = New System.Drawing.Size(320, 64)
            Me.txtDetails.TabIndex = 14
            Me.txtDetails.Text = ""
            Me.txtDetails.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'lblDetails
            '
            Me.lblDetails.Location = New System.Drawing.Point(8, 64)
            Me.lblDetails.Name = "lblDetails"
            Me.lblDetails.Size = New System.Drawing.Size(176, 23)
            Me.lblDetails.TabIndex = 160
            Me.lblDetails.Text = "Details"
            '
            'pnlFailCode
            '
            Me.pnlFailCode.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboFailCode, Me.lblFailCode, Me.txtDetails, Me.lblDetails})
            Me.pnlFailCode.Location = New System.Drawing.Point(8, 288)
            Me.pnlFailCode.Name = "pnlFailCode"
            Me.pnlFailCode.Size = New System.Drawing.Size(344, 152)
            Me.pnlFailCode.TabIndex = 162
            '
            'btnPass
            '
            Me.btnPass.BackColor = System.Drawing.Color.Green
            Me.btnPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPass.ForeColor = System.Drawing.Color.Black
            Me.btnPass.Location = New System.Drawing.Point(368, 312)
            Me.btnPass.Name = "btnPass"
            Me.btnPass.Size = New System.Drawing.Size(144, 56)
            Me.btnPass.TabIndex = 15
            Me.btnPass.Text = "Pass"
            '
            'btnFail
            '
            Me.btnFail.BackColor = System.Drawing.Color.Red
            Me.btnFail.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnFail.ForeColor = System.Drawing.Color.Black
            Me.btnFail.Location = New System.Drawing.Point(520, 312)
            Me.btnFail.Name = "btnFail"
            Me.btnFail.Size = New System.Drawing.Size(128, 56)
            Me.btnFail.TabIndex = 16
            Me.btnFail.Text = "Fail"
            '
            'txtJobQty
            '
            Me.txtJobQty.Location = New System.Drawing.Point(224, 32)
            Me.txtJobQty.Name = "txtJobQty"
            Me.txtJobQty.Size = New System.Drawing.Size(136, 22)
            Me.txtJobQty.TabIndex = 2
            Me.txtJobQty.Text = ""
            '
            'lblJobQty
            '
            Me.lblJobQty.Location = New System.Drawing.Point(224, 8)
            Me.lblJobQty.Name = "lblJobQty"
            Me.lblJobQty.Size = New System.Drawing.Size(136, 23)
            Me.lblJobQty.TabIndex = 165
            Me.lblJobQty.Text = "Job Total Qty"
            '
            'lbllblTargetTotal
            '
            Me.lbllblTargetTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbllblTargetTotal.Location = New System.Drawing.Point(392, 80)
            Me.lbllblTargetTotal.Name = "lbllblTargetTotal"
            Me.lbllblTargetTotal.Size = New System.Drawing.Size(168, 32)
            Me.lbllblTargetTotal.TabIndex = 167
            Me.lbllblTargetTotal.Text = "QC Target Total:"
            Me.lbllblTargetTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lbllblTestedTotal
            '
            Me.lbllblTestedTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbllblTestedTotal.Location = New System.Drawing.Point(376, 128)
            Me.lbllblTestedTotal.Name = "lbllblTestedTotal"
            Me.lbllblTestedTotal.Size = New System.Drawing.Size(184, 32)
            Me.lbllblTestedTotal.TabIndex = 169
            Me.lbllblTestedTotal.Text = "QC Tested Total:"
            Me.lbllblTestedTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblTargetTotal
            '
            Me.lblTargetTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTargetTotal.Location = New System.Drawing.Point(568, 80)
            Me.lblTargetTotal.Name = "lblTargetTotal"
            Me.lblTargetTotal.Size = New System.Drawing.Size(96, 32)
            Me.lblTargetTotal.TabIndex = 171
            Me.lblTargetTotal.Text = "0"
            Me.lblTargetTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblTestedTotal
            '
            Me.lblTestedTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTestedTotal.Location = New System.Drawing.Point(568, 128)
            Me.lblTestedTotal.Name = "lblTestedTotal"
            Me.lblTestedTotal.Size = New System.Drawing.Size(96, 32)
            Me.lblTestedTotal.TabIndex = 172
            Me.lblTestedTotal.Text = "0"
            Me.lblTestedTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblPass
            '
            Me.lblPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPass.ForeColor = System.Drawing.Color.Green
            Me.lblPass.Location = New System.Drawing.Point(568, 168)
            Me.lblPass.Name = "lblPass"
            Me.lblPass.Size = New System.Drawing.Size(96, 32)
            Me.lblPass.TabIndex = 174
            Me.lblPass.Text = "0"
            Me.lblPass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lbllblPass
            '
            Me.lbllblPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbllblPass.Location = New System.Drawing.Point(376, 168)
            Me.lbllblPass.Name = "lbllblPass"
            Me.lbllblPass.Size = New System.Drawing.Size(184, 32)
            Me.lbllblPass.TabIndex = 173
            Me.lbllblPass.Text = "Pass:"
            Me.lbllblPass.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblFail
            '
            Me.lblFail.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblFail.ForeColor = System.Drawing.Color.Red
            Me.lblFail.Location = New System.Drawing.Point(568, 208)
            Me.lblFail.Name = "lblFail"
            Me.lblFail.Size = New System.Drawing.Size(96, 32)
            Me.lblFail.TabIndex = 176
            Me.lblFail.Text = "0"
            Me.lblFail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lbllblFail
            '
            Me.lbllblFail.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbllblFail.Location = New System.Drawing.Point(376, 208)
            Me.lbllblFail.Name = "lbllblFail"
            Me.lbllblFail.Size = New System.Drawing.Size(184, 32)
            Me.lbllblFail.TabIndex = 175
            Me.lbllblFail.Text = "Fail:"
            Me.lbllblFail.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblPassRate
            '
            Me.lblPassRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPassRate.Location = New System.Drawing.Point(568, 248)
            Me.lblPassRate.Name = "lblPassRate"
            Me.lblPassRate.Size = New System.Drawing.Size(96, 32)
            Me.lblPassRate.TabIndex = 178
            Me.lblPassRate.Text = "0"
            Me.lblPassRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lbllblPassRate
            '
            Me.lbllblPassRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbllblPassRate.Location = New System.Drawing.Point(376, 248)
            Me.lbllblPassRate.Name = "lbllblPassRate"
            Me.lbllblPassRate.Size = New System.Drawing.Size(184, 32)
            Me.lbllblPassRate.TabIndex = 177
            Me.lbllblPassRate.Text = "Pass Rate (%)"
            Me.lbllblPassRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnRemove
            '
            Me.btnRemove.BackColor = System.Drawing.Color.NavajoWhite
            Me.btnRemove.Location = New System.Drawing.Point(368, 384)
            Me.btnRemove.Name = "btnRemove"
            Me.btnRemove.Size = New System.Drawing.Size(144, 48)
            Me.btnRemove.TabIndex = 17
            Me.btnRemove.Text = "Remove SN"
            '
            'btnViewRpt
            '
            Me.btnViewRpt.ForeColor = System.Drawing.Color.DarkBlue
            Me.btnViewRpt.Location = New System.Drawing.Point(520, 384)
            Me.btnViewRpt.Name = "btnViewRpt"
            Me.btnViewRpt.Size = New System.Drawing.Size(128, 48)
            Me.btnViewRpt.TabIndex = 18
            Me.btnViewRpt.Text = "QC Report"
            '
            'btnReset
            '
            Me.btnReset.Location = New System.Drawing.Point(456, 16)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.Size = New System.Drawing.Size(88, 40)
            Me.btnReset.TabIndex = 21
            Me.btnReset.Text = "Reset Job"
            '
            'btnStartJob
            '
            Me.btnStartJob.ForeColor = System.Drawing.Color.DarkBlue
            Me.btnStartJob.Location = New System.Drawing.Point(360, 16)
            Me.btnStartJob.Name = "btnStartJob"
            Me.btnStartJob.Size = New System.Drawing.Size(88, 40)
            Me.btnStartJob.TabIndex = 20
            Me.btnStartJob.Text = "Start Job"
            '
            'pnlJob
            '
            Me.pnlJob.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblJobNo, Me.txtJobNo, Me.txtJobQty, Me.lblJobQty})
            Me.pnlJob.Location = New System.Drawing.Point(0, 56)
            Me.pnlJob.Name = "pnlJob"
            Me.pnlJob.Size = New System.Drawing.Size(368, 58)
            Me.pnlJob.TabIndex = 0
            '
            'pnlWOModelSN
            '
            Me.pnlWOModelSN.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkKeepModel, Me.chkKeepWO, Me.txtModel, Me.txtSN, Me.lblSN, Me.lblModel, Me.txtWO, Me.lblWO})
            Me.pnlWOModelSN.Location = New System.Drawing.Point(0, 120)
            Me.pnlWOModelSN.Name = "pnlWOModelSN"
            Me.pnlWOModelSN.Size = New System.Drawing.Size(368, 160)
            Me.pnlWOModelSN.TabIndex = 185
            '
            'chkKeepModel
            '
            Me.chkKeepModel.Location = New System.Drawing.Point(232, 80)
            Me.chkKeepModel.Name = "chkKeepModel"
            Me.chkKeepModel.TabIndex = 160
            Me.chkKeepModel.Text = "Keep Model"
            Me.ToolTip1.SetToolTip(Me.chkKeepModel, "If checked, the model remains")
            '
            'chkKeepWO
            '
            Me.chkKeepWO.Location = New System.Drawing.Point(232, 24)
            Me.chkKeepWO.Name = "chkKeepWO"
            Me.chkKeepWO.TabIndex = 159
            Me.chkKeepWO.Text = "Keep WO"
            Me.ToolTip1.SetToolTip(Me.chkKeepWO, "If checked, the WO number remains")
            '
            'frmTFFK_QC
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
            Me.ClientSize = New System.Drawing.Size(680, 510)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlWOModelSN, Me.pnlJob, Me.btnStartJob, Me.btnReset, Me.btnViewRpt, Me.btnRemove, Me.lblPassRate, Me.lbllblPassRate, Me.lblFail, Me.lbllblFail, Me.lblPass, Me.lbllblPass, Me.lblTestedTotal, Me.lblTargetTotal, Me.lbllblTestedTotal, Me.lbllblTargetTotal, Me.btnFail, Me.btnPass, Me.pnlFailCode, Me.txtTargetRate, Me.lblTargetRate, Me.TxtEmployeeNo, Me.lblEmployeeNo, Me.cboLine, Me.lblLine})
            Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Name = "frmTFFK_QC"
            Me.Text = "frmTFFK_QC"
            CType(Me.cboLine, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboFailCode, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlFailCode.ResumeLayout(False)
            Me.pnlJob.ResumeLayout(False)
            Me.pnlWOModelSN.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmTFFK_QC_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable

            Try
                PSS.Core.Highlight.SetHighLight(Me)
                'TabControl1.DrawMode = TabDrawMode.OwnerDrawFixed

                'Populate QC Line
                dt = Me._objTFFK_QC.GetTFFK_QC_Line
                Misc.PopulateC1DropDownList(Me.cboLine, dt, "Line", "DCode_ID")
                Me.cboLine.SelectedValue = 6516 'line 1 as default

                Me.TxtEmployeeNo.Text = Me._strEmpID.ToString
                Me.TxtEmployeeNo.ReadOnly = True

                'Populate QC LFailCode
                dt = Me._objTFFK_QC.GetTFFK_QC_FailCode(True)
                Misc.PopulateC1DropDownList(Me.cboFailCode, dt, "FailCode", "DCode_ID")
                Me.cboFailCode.SelectedValue = 0 'Select

                dt = Me._objTFFK_QC.GetTFFK_QC_TargetRate
                If dt.Rows.Count > 0 AndAlso IsNumeric(dt.Rows(0).Item("QCTargetPercent")) Then
                    Dim iVal As Int32 = Convert.ToInt32(dt.Rows(0).Item("QCTargetPercent"))
                    If iVal > 1 Then
                        Me.txtTargetRate.Text = iVal
                    Else
                        Me.txtTargetRate.Text = 1
                    End If
                Else
                    Me.txtTargetRate.Text = 0
                End If
                Me.txtTargetRate.ReadOnly = True

                Me.pnlJob.Enabled = True
                Me.pnlWOModelSN.Enabled = False
                Me.pnlFailCode.Enabled = False
                Me.btnPass.Enabled = False
                Me.btnFail.Enabled = False
                ActiveControl = Me.txtJobNo
                Me.txtJobNo.SelectAll() : Me.txtJobNo.Focus()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
            End Try

        End Sub

        Private Sub txtJobQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtJobQty.KeyPress
            'If (Not Char.IsControl(e.KeyChar) _
            '                            AndAlso (Not Char.IsDigit(e.KeyChar) _
            '                            AndAlso (e.KeyChar <> Microsoft.VisualBasic.ChrW(46)))) Then
            '    e.Handled = True
            'End If

            '' only allow one decimal point
            'If ((e.KeyChar = Microsoft.VisualBasic.ChrW(46)) _
            '            AndAlso (CType(sender, TextBox).Text.IndexOf(Microsoft.VisualBasic.ChrW(46)) > -1)) Then
            '    e.Handled = True
            'End If

            '97 - 122 = Ascii codes for simple letters
            '65 - 90  = Ascii codes for capital letters
            '48 - 57  = Ascii codes for numbers

            If Asc(e.KeyChar) <> 8 Then
                If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                    e.Handled = True
                End If
            End If
           
        End Sub

        Private Sub ComputeTargetTotal()
            Dim iVal As Int32 = 0
            Dim iTargetVal As Int32 = 0
            Dim iTestTotal As Int32 = 0
            Try
                iVal = Convert.ToInt32(Me.txtJobQty.Text)
                Me.txtJobQty.Text = iVal.ToString
                iTargetVal = Convert.ToInt32(Me.txtTargetRate.Text)
                iTestTotal = iVal * (iTargetVal / 100)
                If iTestTotal < 1 Then iTestTotal = 1
                Me.lblTargetTotal.Text = iTestTotal.ToString
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ComputeTargetTotal", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnStartJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartJob.Click

            Try

                If Not Me.cboLine.SelectedValue > 0 Then
                    MessageBox.Show("Select a QC line.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf Not IsNumeric(Me.txtTargetRate.Text) OrElse Not Convert.ToInt32(Me.txtTargetRate.Text) >= 1 Then
                    MessageBox.Show("Not a valid target test rate.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf Not Me.txtJobNo.Text.Trim.Length > 0 Then
                    MessageBox.Show("Enter a Job number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf Me.txtJobNo.Text.Trim.Length > 50 Then
                    MessageBox.Show("Maximum text length of job number is 50.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf Me.txtJobQty.Text.Trim.Length = 0 Then
                    MessageBox.Show("Enter a total number for the job.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf Not IsNumeric(Me.txtJobQty.Text.Trim) Then
                    MessageBox.Show("Enter a valid number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf Convert.ToInt32(Me.txtJobQty.Text) > 1 Then
                    Me.ComputeTargetTotal()
                    Me.StartJob()
                Else
                    Me.txtJobQty.Text = 1
                    Me.lblTargetTotal.Text = 1
                    Me.StartJob()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnStartJob_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub GetTestedDataAndCompute()
            Dim dtTmp As DataTable
            Dim iTestedTotal As Integer = 0
            Dim iPass As Integer = 0
            Dim vPassRate As Single = 0.0

            Try
                'get tested data
                dtTmp = Me._objTFFK_QC.GetTFFK_QC_TestedDataByJobID(1, Me._iJob_ID) 'pass
                iPass = dtTmp.Rows.Count
                Me.lblPass.Text = iPass
                dtTmp = Me._objTFFK_QC.GetTFFK_QC_TestedDataByJobID(2, Me._iJob_ID) 'fail
                iTestedTotal += dtTmp.Rows.Count
                Me.lblFail.Text = dtTmp.Rows.Count
                iTestedTotal = iPass + dtTmp.Rows.Count
                Me.lblTestedTotal.Text = iTestedTotal
                If iTestedTotal = 0 Then
                    Me.lblPassRate.Text = 0
                Else
                    vPassRate = FormatNumber((iPass / iTestedTotal) * 100, 2)
                    Me.lblPassRate.Text = vPassRate
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "GetTestedDataAndCompute", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                dtTmp = Nothing
            End Try
        End Sub

        Private Sub StartJob()
            Dim strJob As String = ""
            Dim iQty As Int32 = 0
            Dim strDateTime As String = Format(Now, "yyyy-MM-dd HH:mm-ss")
            Dim bNewJob As Boolean = False
            Dim dt As DataTable

            Try
                Me.btnStartJob.Enabled = False
                strJob = Me.txtJobNo.Text.Trim.ToString
                iQty = Convert.ToInt32(Me.txtJobQty.Text)

                dt = Me._objTFFK_QC.TFFK_QC_InsertJob(strJob, iQty, Me._UserID, strDateTime, bNewJob, Me._iJob_ID)

                If Not bNewJob Then 'existing job============================================
                    Dim result As Integer = MessageBox.Show("The job is in the system. Do you want to load it?", "Select", MessageBoxButtons.YesNo)
                    If result = DialogResult.No Then 'stop------------------------------
                        Me.lblTargetTotal.Text = 0 : Me.lblTestedTotal.Text = 0 : Me.lblPass.Text = 0
                        Me.lblFail.Text = 0 : Me.lblPassRate.Text = 0
                        Me.txtJobNo.Enabled = True
                        Me.txtJobQty.Enabled = True
                        Me.btnStartJob.Enabled = True
                        Me.pnlJob.Enabled = True
                        Me.txtJobQty.Text = ""
                        Me._iJob_ID = 0
                        Me.txtJobNo.SelectAll() : Me.txtJobNo.Focus()
                    ElseIf result = DialogResult.Yes AndAlso dt.Rows.Count > 0 Then 'Go ahead-------------------------------------
                        Me.txtJobNo.Text = dt.Rows(0).Item("QCJobNumber")
                        Me.txtJobQty.Text = dt.Rows(0).Item("QCJob_Quantity")
                        Me._iJob_ID = dt.Rows(0).Item("QCJob_ID")
                        'get tested data
                        Me.GetTestedDataAndCompute()

                        'compute
                        Me.ComputeTargetTotal()

                        'Ready
                        Me.pnlJob.Enabled = False
                        Me.pnlWOModelSN.Enabled = True
                        Me.txtWO.SelectAll() : Me.txtWO.Focus()
                    ElseIf result = DialogResult.Yes AndAlso Not dt.Rows.Count > 0 Then 'has issue
                        MessageBox.Show("The job is in the system, but it has an issue to load. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else 'new job===============================================================
                    ' MessageBox.Show("New job.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'compute
                    Me.ComputeTargetTotal()

                    'Ready
                    Me.pnlJob.Enabled = False
                    Me.pnlWOModelSN.Enabled = True
                    Me.txtWO.SelectAll() : Me.txtWO.Focus()
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "StartJob", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                dt = Nothing
            End Try
        End Sub

        Private Sub txtWO_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWO.KeyUp
            Try
                If e.KeyCode = Keys.Enter AndAlso Me.txtWO.Text.Trim.Length > 0 Then
                    Me.txtModel.SelectAll() : Me.txtModel.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtWO_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub txtModel_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtModel.KeyUp
            Try
                If e.KeyCode = Keys.Enter AndAlso Me.txtModel.Text.Trim.Length > 0 Then
                    Me.txtSN.SelectAll() : Me.txtSN.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtModel_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub txtSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyUp
            Try
                If e.KeyCode = Keys.Enter AndAlso Me.txtSN.Text.Trim.Length > 0 Then
                    Me.pnlFailCode.Enabled = True
                    Me.btnPass.Enabled = True : Me.btnFail.Enabled = True
                    Me.btnPass.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtModel_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub SaveTestResult(ByVal bIsPass As Boolean)
            Dim strDatetime = Format(Now, "yyyy-MM-dd HH:mm:ss")
            Dim strDate = Format(Now, "yyyy-MM-dd")

            Try
                If bIsPass Then 'pass
                    Me._objTFFK_QC.TFFK_QC_SaveResult(Me._iJob_ID, bIsPass, Me.cboLine.SelectedValue, Me.txtWO.Text.Trim, Me.txtModel.Text.Trim, _
                                                      Me.txtSN.Text.Trim, 0, "", Me._UserID, strDatetime, strDate, Me._strComputerName)
                Else 'Fail
                    Me._objTFFK_QC.TFFK_QC_SaveResult(Me._iJob_ID, bIsPass, Me.cboLine.SelectedValue, Me.txtWO.Text.Trim, Me.txtModel.Text.Trim, _
                                                      Me.txtSN.Text.Trim, Me.cboFailCode.SelectedValue, Me.txtDetails.Text.Trim, Me._UserID, strDatetime, strDate, Me._strComputerName)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "SaveTestResult", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub btnPass_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPass.Click
            Try
                If Not Me.txtSN.Text.Trim.Length > 0 Then
                    MessageBox.Show("Enter a SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf Not Me.txtWO.Text.Trim.Length > 0 Then
                    MessageBox.Show("Enter a work order number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf Not Me.txtModel.Text.Trim.Length > 0 Then
                    MessageBox.Show("Enter a model name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf Me._iJob_ID = 0 Then
                    MessageBox.Show("No job ID, see IT", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf Not Me.txtJobNo.Text.Trim.Length > 0 Then
                    MessageBox.Show("No job number, see IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf Me.cboFailCode.SelectedValue > 0 OrElse Me.txtDetails.Text.Trim.Length > 0 Then
                    MessageBox.Show("Fail code selection or detail info is ignored becuase you passed the test.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Me.SaveTestResult(True)
                    Me.DoItAfterPassOrFail()

                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnPass_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub btnFail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFail.Click
            Try
                If Not Me.txtSN.Text.Trim.Length > 0 Then
                    MessageBox.Show("Enter a SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf Not Me.txtWO.Text.Trim.Length > 0 Then
                    MessageBox.Show("Enter a work order number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf Not Me.txtModel.Text.Trim.Length > 0 Then
                    MessageBox.Show("Enter a model name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf Me._iJob_ID = 0 Then
                    MessageBox.Show("No job ID, see IT", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf Not Me.txtJobNo.Text.Trim.Length > 0 Then
                    MessageBox.Show("No job number, see IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf Not Me.cboFailCode.SelectedValue > 0 Then
                    MessageBox.Show("please select a fail code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Me.SaveTestResult(False)
                    Me.DoItAfterPassOrFail()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnFail_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub DoItAfterPassOrFail()
            Try
                Me.cboFailCode.SelectedValue = 0 : Me.txtDetails.Text = ""

                If Me.chkKeepWO.Checked AndAlso Me.chkKeepModel.Checked Then
                    Me.txtSN.Text = "" : Me.txtSN.SelectAll() : Me.txtSN.Focus()
                ElseIf Me.chkKeepWO.Checked AndAlso Not Me.chkKeepModel.Checked Then
                    Me.txtSN.Text = ""
                    Me.txtModel.Text = "" : Me.txtModel.SelectAll() : Me.txtModel.Focus()
                ElseIf Not Me.chkKeepWO.Checked AndAlso Me.chkKeepModel.Checked Then
                    Me.txtSN.Text = ""
                    Me.txtWO.Text = "" : Me.txtWO.SelectAll() : Me.txtWO.Focus()
                Else
                    Me.txtSN.Text = "" : Me.txtModel.Text = ""
                    Me.txtWO.Text = "" : Me.txtWO.SelectAll() : Me.txtWO.Focus()
                End If

                Me.btnPass.Enabled = False
                Me.btnFail.Enabled = False

                Me.GetTestedDataAndCompute()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "oItAfterPassOrFail", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub btnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.Click
            Try
                With Me
                    .txtJobNo.Enabled = True
                    .txtJobNo.Text = ""
                    .txtJobQty.Enabled = True
                    .txtJobQty.Text = ""
                    .txtWO.Text = ""
                    .txtModel.Text = ""
                    .txtSN.Text = ""
                    .cboFailCode.SelectedValue = 0
                    .txtDetails.Text = ""
                    .lblTargetTotal.Text = 0
                    .lblTestedTotal.Text = 0
                    .lblPass.Text = 0
                    .lblFail.Text = 0
                    .lblPassRate.Text = 0
                    .btnStartJob.Enabled = True
                    .btnPass.Enabled = False
                    .btnFail.Enabled = False
                    .pnlJob.Enabled = True
                    .pnlWOModelSN.Enabled = False
                    .txtJobNo.SelectAll() : .txtJobNo.Focus()
                End With

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnReset_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
            Try
                Dim fm As New frmTFFK_QC_Delete()
                fm.ShowDialog()

                fm.Dispose()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRemove_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub btnViewRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewRpt.Click
            Try
                Dim fm As New frmTFFK_QC_Report()
                fm.ShowDialog()

                fm.Dispose()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnViewRpt_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub
    End Class
End Namespace
