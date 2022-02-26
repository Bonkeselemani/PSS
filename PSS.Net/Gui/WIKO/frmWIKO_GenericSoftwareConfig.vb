Option Explicit On 

Imports PSS.Data.Buisness
Imports System.Text

Namespace Gui.WIKO
    Public Class frmWIKO_GenericSoftwareConfig
        Inherits System.Windows.Forms.Form

        Private _iCust_ID As Integer = 0
        Private _strScreenName As String = ""
        Private _objWiKo As PSS.Data.Buisness.WIKO.WIKO

        Private _iUserID As Integer = PSS.Core.Global.ApplicationUser.IDuser
        Private _strUser As String = PSS.Core.Global.ApplicationUser.User
        Private _objWIKO_ConfigSoft As PSS.Data.Buisness.WIKO.WIKO_GenericSoftwareConfig
#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strScreenName As String, ByVal iCust_ID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._iCust_ID = iCust_ID
            Me._strScreenName = strScreenName
            Me._objWiKo = New PSS.Data.Buisness.WIKO.WIKO()
            Me._objWIKO_ConfigSoft = New PSS.Data.Buisness.WIKO.WIKO_GenericSoftwareConfig()
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                Try
                    Me._objWiKo = Nothing
                  
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
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents dbgSoftwareVersInfo As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents cboModel As C1.Win.C1List.C1Combo
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents Button1 As System.Windows.Forms.Button
        Friend WithEvents Button2 As System.Windows.Forms.Button
        Friend WithEvents Button3 As System.Windows.Forms.Button
        Friend WithEvents txtSoftVersion As System.Windows.Forms.TextBox
        Friend WithEvents txtFlasApp As System.Windows.Forms.TextBox
        Friend WithEvents txtCarrier As System.Windows.Forms.TextBox
        Friend WithEvents dFileDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents txtBuilID As System.Windows.Forms.TextBox
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents txtFileName As System.Windows.Forms.TextBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents txtConnector As System.Windows.Forms.TextBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents txtDeviecName As System.Windows.Forms.TextBox
        Friend WithEvents lbCustomer As System.Windows.Forms.Label
        Friend WithEvents lblSMID As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmWIKO_GenericSoftwareConfig))
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.txtConnector = New System.Windows.Forms.TextBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.txtFileName = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.txtBuilID = New System.Windows.Forms.TextBox()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.dFileDate = New System.Windows.Forms.DateTimePicker()
            Me.txtSoftVersion = New System.Windows.Forms.TextBox()
            Me.txtFlasApp = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtCarrier = New System.Windows.Forms.TextBox()
            Me.cboModel = New C1.Win.C1List.C1Combo()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.dbgSoftwareVersInfo = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.Button3 = New System.Windows.Forms.Button()
            Me.Button2 = New System.Windows.Forms.Button()
            Me.Button1 = New System.Windows.Forms.Button()
            Me.txtDeviecName = New System.Windows.Forms.TextBox()
            Me.lbCustomer = New System.Windows.Forms.Label()
            Me.lblSMID = New System.Windows.Forms.Label()
            Me.Panel1.SuspendLayout()
            CType(Me.cboModel, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel2.SuspendLayout()
            CType(Me.dbgSoftwareVersInfo, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel3.SuspendLayout()
            Me.SuspendLayout()
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(544, 8)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(152, 23)
            Me.Label2.TabIndex = 1
            Me.Label2.Text = "Carrier"
            '
            'Label3
            '
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(280, 8)
            Me.Label3.Name = "Label3"
            Me.Label3.TabIndex = 2
            Me.Label3.Text = "SKU"
            '
            'Label5
            '
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.White
            Me.Label5.Location = New System.Drawing.Point(280, 72)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(120, 23)
            Me.Label5.TabIndex = 4
            Me.Label5.Text = "Flash Application"
            '
            'Label8
            '
            Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.White
            Me.Label8.Location = New System.Drawing.Point(16, 72)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(120, 23)
            Me.Label8.TabIndex = 7
            Me.Label8.Text = "Software Version"
            '
            'Panel1
            '
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtDeviecName, Me.txtConnector, Me.Label6, Me.txtFileName, Me.Label4, Me.txtBuilID, Me.Label7, Me.Label9, Me.dFileDate, Me.txtSoftVersion, Me.txtFlasApp, Me.Label1, Me.txtCarrier, Me.cboModel, Me.Label3, Me.Label2, Me.Label5, Me.Label8})
            Me.Panel1.Location = New System.Drawing.Point(16, 48)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(792, 184)
            Me.Panel1.TabIndex = 8
            '
            'txtConnector
            '
            Me.txtConnector.Location = New System.Drawing.Point(16, 152)
            Me.txtConnector.Name = "txtConnector"
            Me.txtConnector.Size = New System.Drawing.Size(232, 20)
            Me.txtConnector.TabIndex = 107
            Me.txtConnector.Text = ""
            '
            'Label6
            '
            Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.White
            Me.Label6.Location = New System.Drawing.Point(16, 128)
            Me.Label6.Name = "Label6"
            Me.Label6.TabIndex = 106
            Me.Label6.Text = "Connector"
            '
            'txtFileName
            '
            Me.txtFileName.Location = New System.Drawing.Point(280, 152)
            Me.txtFileName.Name = "txtFileName"
            Me.txtFileName.Size = New System.Drawing.Size(224, 20)
            Me.txtFileName.TabIndex = 105
            Me.txtFileName.Text = ""
            '
            'Label4
            '
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(280, 128)
            Me.Label4.Name = "Label4"
            Me.Label4.TabIndex = 104
            Me.Label4.Text = "File Name"
            '
            'txtBuilID
            '
            Me.txtBuilID.Location = New System.Drawing.Point(544, 152)
            Me.txtBuilID.Name = "txtBuilID"
            Me.txtBuilID.Size = New System.Drawing.Size(224, 20)
            Me.txtBuilID.TabIndex = 103
            Me.txtBuilID.Text = ""
            '
            'Label7
            '
            Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.White
            Me.Label7.Location = New System.Drawing.Point(544, 128)
            Me.Label7.Name = "Label7"
            Me.Label7.TabIndex = 101
            Me.Label7.Text = "Build ID"
            '
            'Label9
            '
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.White
            Me.Label9.Location = New System.Drawing.Point(544, 72)
            Me.Label9.Name = "Label9"
            Me.Label9.TabIndex = 99
            Me.Label9.Text = "File Date"
            '
            'dFileDate
            '
            Me.dFileDate.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dFileDate.Location = New System.Drawing.Point(544, 96)
            Me.dFileDate.Name = "dFileDate"
            Me.dFileDate.Size = New System.Drawing.Size(224, 20)
            Me.dFileDate.TabIndex = 98
            '
            'txtSoftVersion
            '
            Me.txtSoftVersion.Location = New System.Drawing.Point(16, 96)
            Me.txtSoftVersion.Name = "txtSoftVersion"
            Me.txtSoftVersion.Size = New System.Drawing.Size(232, 20)
            Me.txtSoftVersion.TabIndex = 97
            Me.txtSoftVersion.Text = ""
            '
            'txtFlasApp
            '
            Me.txtFlasApp.Location = New System.Drawing.Point(280, 96)
            Me.txtFlasApp.Name = "txtFlasApp"
            Me.txtFlasApp.Size = New System.Drawing.Size(224, 20)
            Me.txtFlasApp.TabIndex = 94
            Me.txtFlasApp.Text = ""
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(16, 8)
            Me.Label1.Name = "Label1"
            Me.Label1.TabIndex = 91
            Me.Label1.Text = "Device Name"
            '
            'txtCarrier
            '
            Me.txtCarrier.Location = New System.Drawing.Point(544, 32)
            Me.txtCarrier.Name = "txtCarrier"
            Me.txtCarrier.Size = New System.Drawing.Size(224, 20)
            Me.txtCarrier.TabIndex = 90
            Me.txtCarrier.Text = ""
            '
            'cboModel
            '
            Me.cboModel.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboModel.Caption = ""
            Me.cboModel.CaptionHeight = 17
            Me.cboModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboModel.ColumnCaptionHeight = 17
            Me.cboModel.ColumnFooterHeight = 17
            Me.cboModel.ContentHeight = 15
            Me.cboModel.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboModel.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboModel.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboModel.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboModel.EditorHeight = 15
            Me.cboModel.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboModel.ItemHeight = 15
            Me.cboModel.Location = New System.Drawing.Point(280, 32)
            Me.cboModel.MatchEntryTimeout = CType(2000, Long)
            Me.cboModel.MaxDropDownItems = CType(5, Short)
            Me.cboModel.MaxLength = 32767
            Me.cboModel.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboModel.Name = "cboModel"
            Me.cboModel.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboModel.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboModel.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboModel.Size = New System.Drawing.Size(224, 21)
            Me.cboModel.TabIndex = 89
            Me.cboModel.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Panel2
            '
            Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.dbgSoftwareVersInfo})
            Me.Panel2.Location = New System.Drawing.Point(16, 296)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(792, 288)
            Me.Panel2.TabIndex = 9
            '
            'dbgSoftwareVersInfo
            '
            Me.dbgSoftwareVersInfo.AllowColMove = False
            Me.dbgSoftwareVersInfo.AllowUpdate = False
            Me.dbgSoftwareVersInfo.CaptionHeight = 20
            Me.dbgSoftwareVersInfo.FilterBar = True
            Me.dbgSoftwareVersInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dbgSoftwareVersInfo.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgSoftwareVersInfo.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.dbgSoftwareVersInfo.Name = "dbgSoftwareVersInfo"
            Me.dbgSoftwareVersInfo.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgSoftwareVersInfo.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgSoftwareVersInfo.PreviewInfo.ZoomFactor = 75
            Me.dbgSoftwareVersInfo.RowHeight = 25
            Me.dbgSoftwareVersInfo.Size = New System.Drawing.Size(792, 288)
            Me.dbgSoftwareVersInfo.TabIndex = 5
            Me.dbgSoftwareVersInfo.Text = "C1TrueDBGrid1"
            Me.dbgSoftwareVersInfo.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:LightSteelBlue;" & _
            "}Selected{ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColo" & _
            "r:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{ForeColor:Red;}Footer" & _
            "{}Caption{AlignHorz:Center;BackColor:LightSteelBlue;}Style1{}Normal{Font:Microso" & _
            "ft Sans Serif, 8.25pt, style=Bold;}HighlightRow{ForeColor:HighlightText;BackColo" & _
            "r:Highlight;}Style12{}OddRow{BackColor:LightSteelBlue;}RecordSelector{AlignImage" & _
            ":Center;}Style13{}Heading{Wrap:True;AlignHorz:Center;BackColor:SteelBlue;Border:" & _
            "Raised,,1, 1, 1, 1;ForeColor:White;AlignVert:Center;}Style8{}Style10{AlignHorz:N" & _
            "ear;}Style11{}Style14{}Style15{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDB" & _
            "Grid.MergeView AllowColMove=""False"" Name="""" CaptionHeight=""17"" ColumnCaptionHeig" & _
            "ht=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder""" & _
            " RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" Horizontal" & _
            "ScrollGroup=""1""><Height>284</Height><CaptionStyle parent=""Style2"" me=""Style10"" /" & _
            "><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""S" & _
            "tyle8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""" & _
            "Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle pa" & _
            "rent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7" & _
            """ /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" " & _
            "me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><Selec" & _
            "tedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><C" & _
            "lientRect>0, 0, 788, 284</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunk" & _
            "en</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style par" & _
            "ent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Headin" & _
            "g"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" " & _
            "me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me" & _
            "=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me" & _
            "=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""Re" & _
            "cordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" " & _
            "me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><" & _
            "Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0," & _
            " 788, 284</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><PrintPageF" & _
            "ooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'Panel3
            '
            Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel3.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button3, Me.Button2, Me.Button1})
            Me.Panel3.Location = New System.Drawing.Point(16, 240)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(792, 48)
            Me.Panel3.TabIndex = 10
            '
            'Button3
            '
            Me.Button3.Enabled = False
            Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Button3.ForeColor = System.Drawing.Color.White
            Me.Button3.Location = New System.Drawing.Point(568, 8)
            Me.Button3.Name = "Button3"
            Me.Button3.Size = New System.Drawing.Size(176, 32)
            Me.Button3.TabIndex = 2
            Me.Button3.Text = "UPDATE"
            '
            'Button2
            '
            Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Button2.ForeColor = System.Drawing.Color.White
            Me.Button2.Location = New System.Drawing.Point(296, 8)
            Me.Button2.Name = "Button2"
            Me.Button2.Size = New System.Drawing.Size(176, 32)
            Me.Button2.TabIndex = 1
            Me.Button2.Text = "SAVE"
            '
            'Button1
            '
            Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Button1.ForeColor = System.Drawing.Color.White
            Me.Button1.Location = New System.Drawing.Point(16, 8)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(176, 32)
            Me.Button1.TabIndex = 0
            Me.Button1.Text = "NEW "
            '
            'txtDeviecName
            '
            Me.txtDeviecName.Location = New System.Drawing.Point(16, 32)
            Me.txtDeviecName.Name = "txtDeviecName"
            Me.txtDeviecName.Size = New System.Drawing.Size(224, 20)
            Me.txtDeviecName.TabIndex = 108
            Me.txtDeviecName.Text = ""
            '
            'lbCustomer
            '
            Me.lbCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbCustomer.ForeColor = System.Drawing.Color.White
            Me.lbCustomer.Location = New System.Drawing.Point(128, 8)
            Me.lbCustomer.Name = "lbCustomer"
            Me.lbCustomer.Size = New System.Drawing.Size(544, 40)
            Me.lbCustomer.TabIndex = 11
            Me.lbCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblSMID
            '
            Me.lblSMID.Location = New System.Drawing.Point(712, 24)
            Me.lblSMID.Name = "lblSMID"
            Me.lblSMID.TabIndex = 12
            Me.lblSMID.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'frmWIKO_GenericSoftwareConfig
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(816, 590)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblSMID, Me.lbCustomer, Me.Panel3, Me.Panel2, Me.Panel1})
            Me.Name = "frmWIKO_GenericSoftwareConfig"
            Me.Text = "frmWIKO_GenericSoftwareConfig"
            Me.Panel1.ResumeLayout(False)
            CType(Me.cboModel, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel2.ResumeLayout(False)
            CType(Me.dbgSoftwareVersInfo, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel3.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmWIKO_GenericSoftwareConfig_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dtModel As New DataTable()
            Dim iModel_ID As Integer = 0
            Try
                dtModel = Me._objWIKO_ConfigSoft.GetCustomerModels(_iCust_ID, True)
                Misc.PopulateC1DropDownList(Me.cboModel, dtModel, "Model_Desc", "Model_ID")
                If dtModel.Rows.Count = 2 Then
                    iModel_ID = dtModel.Rows(0).Item("model_ID")
                    Me.cboModel.SelectedValue = iModel_ID
                Else
                    Me.cboModel.SelectedValue = 0
                End If
                Me.lbCustomer.Text = dtModel.Rows(0).Item("Cust_name1")
                PopulateSoftVersions()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "FormLoad", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub


        Private Sub PopulateSoftVersions(Optional ByVal iPallettID As Integer = 0)
            Dim strModelMotoSku As String
            Dim dtSoftwareVersions As New DataTable()
            Try
                Me.dbgSoftwareVersInfo.DataSource = Nothing
                Me.txtCarrier.Text = ""
                Me.txtBuilID.Text = ""
                Me.txtConnector.Text = ""
                Me.txtFileName.Text = ""
                Me.txtFlasApp.Text = ""
                Me.txtSoftVersion.Text = ""
                dtSoftwareVersions = Me._objWIKO_ConfigSoft.GetSoftware_Versions(_iCust_ID)
                With Me.dbgSoftwareVersInfo
                    .DataSource = dtSoftwareVersions.DefaultView
                    SetGridOpenBoxProperties()
                End With

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "PopulateOpenBoxs", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dtSoftwareVersions)
            End Try
        End Sub
        Private Sub SetGridOpenBoxProperties(Optional ByVal SM_ID As Integer = 0)
            Dim iNumOfColumns As Integer = Me.dbgSoftwareVersInfo.Columns.Count
            Dim i As Integer
            'Pallett_ID, Model_ID, Loc_ID, Pallet_ShipType, Pallett_QTY, Box Name, Location, Model

            With Me.dbgSoftwareVersInfo
                'Heading style (Horizontal Alignment to Center)
                For i = 0 To (iNumOfColumns - 1)
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    .Splits(0).DisplayColumns(i).Visible = False
                Next

                For i = 0 To Me.dbgSoftwareVersInfo.Columns.Count - 1
                    'header forecolor
                    .Splits(0).DisplayColumns(i).HeadingStyle.ForeColor = .ForeColor.Black
                    .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                    'Body Forecolor
                    .Splits(0).DisplayColumns(i).Style.ForeColor = .ForeColor.Black
                Next
                'Set Column Widths
                .Splits(0).DisplayColumns("Device Name").Width = 170
                .Splits(0).DisplayColumns("Carrier").Width = 125
                .Splits(0).DisplayColumns("SKU").Width = 125
                .Splits(0).DisplayColumns("File Date").Width = 125
                .Splits(0).DisplayColumns("Software Version").Width = 200

                'Make some columns invisible
                .Splits(0).DisplayColumns("Device Name").Visible = True
                .Splits(0).DisplayColumns("Carrier").Visible = True
                .Splits(0).DisplayColumns("SKU").Visible = True
                .Splits(0).DisplayColumns("File Date").Visible = True
                .Splits(0).DisplayColumns("Software Version").Visible = True
                .AlternatingRows = True

                'For i = 0 To .RowCount - 1
                '    If .Columns("SM_ID").CellValue(i) = SM_ID Then
                '        Exit Sub
                '    End If
                '    .MoveNext()
                'Next i
            End With
        End Sub

        Private Sub resetFiels()
            Me.txtDeviecName.Text = ""
            Me.txtCarrier.Text = ""
            Me.txtBuilID.Text = ""
            Me.txtConnector.Text = ""
            Me.txtFileName.Text = ""
            Me.txtFlasApp.Text = ""
            Me.txtSoftVersion.Text = ""
            Me.dFileDate.Value = Now
            cboModel.Text = "--Select--"
            PopulateSoftVersions()
            Me.Button2.Enabled = True
            Me.Button3.Enabled = False
        End Sub


        Private Sub dbgSoftwareVersInfo_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dbgSoftwareVersInfo.MouseUp
            Me.txtCarrier.Text = Me.dbgSoftwareVersInfo.Columns("Carrier").Value()
            Me.txtDeviecName.Text = Me.dbgSoftwareVersInfo.Columns("Device Name").Value()
            Me.txtBuilID.Text = Me.dbgSoftwareVersInfo.Columns("BuilldID").Value()
            Me.txtConnector.Text = Me.dbgSoftwareVersInfo.Columns("Connector").Value()
            Me.txtFileName.Text = Me.dbgSoftwareVersInfo.Columns("File Name").Value()
            Me.txtFlasApp.Text = Me.dbgSoftwareVersInfo.Columns("FlashApplication").Value()
            Me.txtSoftVersion.Text = Me.dbgSoftwareVersInfo.Columns("Software Version").Value()
            Me.dFileDate.Text = (Me.dbgSoftwareVersInfo.Columns("File Date").Value())
            cboModel.Text = Me.dbgSoftwareVersInfo.Columns("SKU").Value()
            Me.lblSMID.Text = Me.dbgSoftwareVersInfo.Columns("SM_ID").Value()
            Me.Button3.Enabled = True
            Me.Button2.Enabled = False
        End Sub

        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
            resetFiels()
        End Sub

        Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
            Dim strTitle As String = "Save Software Information"
            If Me.txtDeviecName.Text = "" Then
                MessageBox.Show("Please Enter the Device Name.", strTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtConnector.Focus()
            ElseIf IsNothing(Me.cboModel.SelectedValue) OrElse Me.cboModel.SelectedValue = 0 Then
                MessageBox.Show("Please select the SKU .", strTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.cboModel.Focus()
            ElseIf Me.txtCarrier.Text = "" Then
                MessageBox.Show("Please Enter the Carrier.", strTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtCarrier.Focus()
            ElseIf Me.txtSoftVersion.Text = "" Then
                MessageBox.Show("Please Enter the Software Version.", strTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtSoftVersion.Focus()
            ElseIf Me.txtConnector.Text = "" Then
                MessageBox.Show("Please Enter the Connector.", strTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtConnector.Focus()
            Else
                'check if the software version exists 
                Dim dtVersion As New DataTable()
                dtVersion = Me._objWIKO_ConfigSoft.CheckIfVersionExists(Me.txtDeviecName.Text.Trim, Me.txtCarrier.Text.Trim, Me.cboModel.Text.Trim, _
                Me.dFileDate.Value.ToString("yyyy-MM-dd 00:00:00"), Me.txtSoftVersion.Text.Trim, Me._iCust_ID)
                If dtVersion.Rows.Count = 0 Then
                    Me._objWIKO_ConfigSoft.Save(Me.txtDeviecName.Text.Trim, Me.cboModel.SelectedValue, Me.txtCarrier.Text.Trim, Me.cboModel.Text.Trim, Me.txtFileName.Text.Trim, Me.txtFlasApp.Text.Trim, _
                    Me.dFileDate.Value.ToString("yyyy-MM-dd 00:00:00"), Me.txtConnector.Text.Trim, Me.txtBuilID.Text.Trim, Me.txtSoftVersion.Text.Trim, Me._iCust_ID, Me._iUserID, Date.Now.ToString("yyyy-MM-dd hh:mm:ss"))
                    MessageBox.Show("successfully Saved.", strTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    resetFiels()
                Else
                    MessageBox.Show("The Software Version Exists already in the System.", strTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.cboModel.Focus()
                    Exit Sub
                End If
            End If
        End Sub

        Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
            Dim strTitle As String = "Save Software Information"
            If IsNothing(Me.cboModel.SelectedValue) OrElse Me.cboModel.SelectedValue = 0 Then
                MessageBox.Show("Please select the SKU .", strTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.cboModel.Focus()
            ElseIf Me.txtCarrier.Text = "" Then
                MessageBox.Show("Please Enter the Carrier.", strTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtCarrier.Focus()
            ElseIf Me.txtSoftVersion.Text = "" Then
                MessageBox.Show("Please Enter the Software Version.", strTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtSoftVersion.Focus()
            ElseIf Me.txtConnector.Text = "" Then
                MessageBox.Show("Please Enter the Connector.", strTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtConnector.Focus()
            Else
                'check if the software version exists 
                Dim dtVersion As New DataTable()
                If Me.lblSMID.Text.Trim = String.Empty OrElse CInt(Me.lblSMID.Text.Trim) <= 0 Then
                    MessageBox.Show("Please select the Software Version", strTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                dtVersion = Me._objWIKO_ConfigSoft.CheckIfVersionExists(Me.txtDeviecName.Text.Trim, Me.txtCarrier.Text.Trim, Me.cboModel.Text.Trim, _
                    Me.dFileDate.Value.ToString("yyyy-MM-dd 00:00:00"), Me.txtSoftVersion.Text.Trim, Me._iCust_ID)
                If dtVersion.Rows.Count > 0 Then
                    MessageBox.Show("The Software Version with the same Information Exists already in the System.", strTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.cboModel.Focus()
                    Exit Sub
                End If
                Me._objWIKO_ConfigSoft.Update(Me.lblSMID.Text, Me.txtDeviecName.Text.Trim, Me.cboModel.SelectedValue, Me.txtCarrier.Text.Trim, Me.cboModel.Text.Trim, Me.txtFileName.Text.Trim, Me.txtFlasApp.Text.Trim, _
                Me.dFileDate.Value.ToString("yyyy-MM-dd 00:00:00"), Me.txtConnector.Text.Trim, Me.txtBuilID.Text.Trim, Me.txtSoftVersion.Text.Trim, Me._iCust_ID, Me._iUserID, Date.Now.ToString("yyyy-MM-dd hh:mm:ss"))
                MessageBox.Show("successfully Updated.", strTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                resetFiels()
                Me.Button2.Enabled = True
                Me.Button3.Enabled = False
            End If
        End Sub
    End Class
End Namespace
