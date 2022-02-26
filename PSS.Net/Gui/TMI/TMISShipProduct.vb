Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui
    Public Class TMISShipProduct
        Inherits System.Windows.Forms.Form

        Public _strScreenName As String = ""
        Private _objShip As PSS.Data.Production.Shipping
        Private _objTMIShip As TMIRecShip

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strScreenName As String)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _strScreenName = strScreenName
            _objShip = New PSS.Data.Production.Shipping()
            _objTMIShip = New TMIRecShip()
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If Disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(Disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        Friend WithEvents panelPallet As System.Windows.Forms.Panel
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents lblRMANo As System.Windows.Forms.Label
        Friend WithEvents lblShippedCount As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents btnReprintManifest As System.Windows.Forms.Button
        Friend WithEvents lblBoxName As System.Windows.Forms.Label
        Friend WithEvents lblBoxCount As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents txtDevSN As System.Windows.Forms.TextBox
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents btnCloseAndShipBox As System.Windows.Forms.Button
        Friend WithEvents btnRemoveAllSNs As System.Windows.Forms.Button
        Friend WithEvents btnRemoveSN As System.Windows.Forms.Button
        Friend WithEvents lstDevices As System.Windows.Forms.ListBox
        Friend WithEvents lblRMACount As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents cboCarrier As C1.Win.C1List.C1Combo
        Friend WithEvents lblCarrier As System.Windows.Forms.Label
        Friend WithEvents lblInTrackNo As System.Windows.Forms.Label
        Friend WithEvents txtTrackNo As System.Windows.Forms.TextBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(TMISShipProduct))
            Me.panelPallet = New System.Windows.Forms.Panel()
            Me.lblInTrackNo = New System.Windows.Forms.Label()
            Me.txtTrackNo = New System.Windows.Forms.TextBox()
            Me.cboCarrier = New C1.Win.C1List.C1Combo()
            Me.lblCarrier = New System.Windows.Forms.Label()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.lblRMANo = New System.Windows.Forms.Label()
            Me.lblShippedCount = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.btnReprintManifest = New System.Windows.Forms.Button()
            Me.lblBoxName = New System.Windows.Forms.Label()
            Me.lblBoxCount = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.txtDevSN = New System.Windows.Forms.TextBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.btnCloseAndShipBox = New System.Windows.Forms.Button()
            Me.btnRemoveAllSNs = New System.Windows.Forms.Button()
            Me.btnRemoveSN = New System.Windows.Forms.Button()
            Me.lstDevices = New System.Windows.Forms.ListBox()
            Me.lblRMACount = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.panelPallet.SuspendLayout()
            CType(Me.cboCarrier, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'panelPallet
            '
            Me.panelPallet.BackColor = System.Drawing.Color.SteelBlue
            Me.panelPallet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.panelPallet.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblInTrackNo, Me.txtTrackNo, Me.cboCarrier, Me.lblCarrier, Me.btnClear, Me.Label4, Me.Label1, Me.lblRMANo, Me.lblShippedCount, Me.Label5, Me.btnReprintManifest, Me.lblBoxName, Me.lblBoxCount, Me.Label2, Me.txtDevSN, Me.Label10, Me.btnCloseAndShipBox, Me.btnRemoveAllSNs, Me.btnRemoveSN, Me.lstDevices, Me.lblRMACount, Me.Label3})
            Me.panelPallet.Location = New System.Drawing.Point(8, 8)
            Me.panelPallet.Name = "panelPallet"
            Me.panelPallet.Size = New System.Drawing.Size(656, 440)
            Me.panelPallet.TabIndex = 123
            '
            'lblInTrackNo
            '
            Me.lblInTrackNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblInTrackNo.ForeColor = System.Drawing.Color.White
            Me.lblInTrackNo.Location = New System.Drawing.Point(320, 320)
            Me.lblInTrackNo.Name = "lblInTrackNo"
            Me.lblInTrackNo.Size = New System.Drawing.Size(208, 16)
            Me.lblInTrackNo.TabIndex = 114
            Me.lblInTrackNo.Text = "Track No:"
            Me.lblInTrackNo.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'txtTrackNo
            '
            Me.txtTrackNo.BackColor = System.Drawing.Color.White
            Me.txtTrackNo.Location = New System.Drawing.Point(320, 336)
            Me.txtTrackNo.Name = "txtTrackNo"
            Me.txtTrackNo.Size = New System.Drawing.Size(312, 20)
            Me.txtTrackNo.TabIndex = 113
            Me.txtTrackNo.Text = ""
            '
            'cboCarrier
            '
            Me.cboCarrier.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboCarrier.AutoCompletion = True
            Me.cboCarrier.AutoDropDown = True
            Me.cboCarrier.AutoSelect = True
            Me.cboCarrier.Caption = ""
            Me.cboCarrier.CaptionHeight = 17
            Me.cboCarrier.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboCarrier.ColumnCaptionHeight = 17
            Me.cboCarrier.ColumnFooterHeight = 17
            Me.cboCarrier.ColumnHeaders = False
            Me.cboCarrier.ContentHeight = 15
            Me.cboCarrier.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboCarrier.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboCarrier.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCarrier.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboCarrier.EditorHeight = 15
            Me.cboCarrier.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCarrier.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboCarrier.ItemHeight = 15
            Me.cboCarrier.Location = New System.Drawing.Point(320, 288)
            Me.cboCarrier.MatchEntryTimeout = CType(2000, Long)
            Me.cboCarrier.MaxDropDownItems = CType(10, Short)
            Me.cboCarrier.MaxLength = 32767
            Me.cboCarrier.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCarrier.Name = "cboCarrier"
            Me.cboCarrier.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCarrier.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCarrier.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCarrier.Size = New System.Drawing.Size(312, 21)
            Me.cboCarrier.TabIndex = 112
            Me.cboCarrier.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'lblCarrier
            '
            Me.lblCarrier.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCarrier.ForeColor = System.Drawing.Color.White
            Me.lblCarrier.Location = New System.Drawing.Point(320, 272)
            Me.lblCarrier.Name = "lblCarrier"
            Me.lblCarrier.Size = New System.Drawing.Size(208, 16)
            Me.lblCarrier.TabIndex = 111
            Me.lblCarrier.Text = "Shipment Carrier:"
            Me.lblCarrier.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'btnClear
            '
            Me.btnClear.BackColor = System.Drawing.Color.Green
            Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClear.ForeColor = System.Drawing.Color.White
            Me.btnClear.Location = New System.Drawing.Point(544, 24)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnClear.Size = New System.Drawing.Size(96, 32)
            Me.btnClear.TabIndex = 110
            Me.btnClear.Text = "Clear/Reset"
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(320, 75)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(157, 16)
            Me.Label4.TabIndex = 109
            Me.Label4.Text = "Box Name"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(8, 8)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(157, 16)
            Me.Label1.TabIndex = 108
            Me.Label1.Text = "Work Order/Claim #"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblRMANo
            '
            Me.lblRMANo.BackColor = System.Drawing.Color.Purple
            Me.lblRMANo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblRMANo.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRMANo.ForeColor = System.Drawing.Color.White
            Me.lblRMANo.Location = New System.Drawing.Point(8, 24)
            Me.lblRMANo.Name = "lblRMANo"
            Me.lblRMANo.Size = New System.Drawing.Size(288, 32)
            Me.lblRMANo.TabIndex = 107
            Me.lblRMANo.Tag = "0"
            Me.lblRMANo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblShippedCount
            '
            Me.lblShippedCount.BackColor = System.Drawing.Color.Purple
            Me.lblShippedCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblShippedCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblShippedCount.ForeColor = System.Drawing.Color.White
            Me.lblShippedCount.Location = New System.Drawing.Point(440, 24)
            Me.lblShippedCount.Name = "lblShippedCount"
            Me.lblShippedCount.Size = New System.Drawing.Size(80, 32)
            Me.lblShippedCount.TabIndex = 106
            Me.lblShippedCount.Text = "0"
            Me.lblShippedCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.Transparent
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.White
            Me.Label5.Location = New System.Drawing.Point(424, 8)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(104, 16)
            Me.Label5.TabIndex = 105
            Me.Label5.Text = "Shipped Count"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnReprintManifest
            '
            Me.btnReprintManifest.BackColor = System.Drawing.Color.DarkSlateGray
            Me.btnReprintManifest.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprintManifest.ForeColor = System.Drawing.Color.White
            Me.btnReprintManifest.Location = New System.Drawing.Point(496, 392)
            Me.btnReprintManifest.Name = "btnReprintManifest"
            Me.btnReprintManifest.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnReprintManifest.Size = New System.Drawing.Size(136, 24)
            Me.btnReprintManifest.TabIndex = 104
            Me.btnReprintManifest.Text = "Reprint Manifest"
            '
            'lblBoxName
            '
            Me.lblBoxName.BackColor = System.Drawing.Color.Black
            Me.lblBoxName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblBoxName.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBoxName.ForeColor = System.Drawing.Color.Lime
            Me.lblBoxName.Location = New System.Drawing.Point(320, 91)
            Me.lblBoxName.Name = "lblBoxName"
            Me.lblBoxName.Size = New System.Drawing.Size(320, 32)
            Me.lblBoxName.TabIndex = 102
            Me.lblBoxName.Tag = "0"
            Me.lblBoxName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblBoxCount
            '
            Me.lblBoxCount.BackColor = System.Drawing.Color.Black
            Me.lblBoxCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblBoxCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBoxCount.ForeColor = System.Drawing.Color.Lime
            Me.lblBoxCount.Location = New System.Drawing.Point(320, 147)
            Me.lblBoxCount.Name = "lblBoxCount"
            Me.lblBoxCount.Size = New System.Drawing.Size(80, 32)
            Me.lblBoxCount.TabIndex = 101
            Me.lblBoxCount.Text = "0"
            Me.lblBoxCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(320, 131)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(80, 16)
            Me.Label2.TabIndex = 100
            Me.Label2.Text = "Box Count"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'txtDevSN
            '
            Me.txtDevSN.Location = New System.Drawing.Point(11, 80)
            Me.txtDevSN.Name = "txtDevSN"
            Me.txtDevSN.Size = New System.Drawing.Size(285, 20)
            Me.txtDevSN.TabIndex = 2
            Me.txtDevSN.Text = ""
            '
            'Label10
            '
            Me.Label10.BackColor = System.Drawing.Color.Transparent
            Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.White
            Me.Label10.Location = New System.Drawing.Point(11, 64)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(157, 16)
            Me.Label10.TabIndex = 99
            Me.Label10.Text = "Serial Number:"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnCloseAndShipBox
            '
            Me.btnCloseAndShipBox.BackColor = System.Drawing.Color.Green
            Me.btnCloseAndShipBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCloseAndShipBox.ForeColor = System.Drawing.Color.White
            Me.btnCloseAndShipBox.Location = New System.Drawing.Point(320, 392)
            Me.btnCloseAndShipBox.Name = "btnCloseAndShipBox"
            Me.btnCloseAndShipBox.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnCloseAndShipBox.Size = New System.Drawing.Size(144, 24)
            Me.btnCloseAndShipBox.TabIndex = 4
            Me.btnCloseAndShipBox.Text = "Close && Ship Box"
            '
            'btnRemoveAllSNs
            '
            Me.btnRemoveAllSNs.BackColor = System.Drawing.Color.Red
            Me.btnRemoveAllSNs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveAllSNs.ForeColor = System.Drawing.Color.White
            Me.btnRemoveAllSNs.Location = New System.Drawing.Point(488, 216)
            Me.btnRemoveAllSNs.Name = "btnRemoveAllSNs"
            Me.btnRemoveAllSNs.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRemoveAllSNs.Size = New System.Drawing.Size(144, 24)
            Me.btnRemoveAllSNs.TabIndex = 6
            Me.btnRemoveAllSNs.Text = "REMOVE ALL SNs"
            '
            'btnRemoveSN
            '
            Me.btnRemoveSN.BackColor = System.Drawing.Color.Red
            Me.btnRemoveSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveSN.ForeColor = System.Drawing.Color.White
            Me.btnRemoveSN.Location = New System.Drawing.Point(320, 216)
            Me.btnRemoveSN.Name = "btnRemoveSN"
            Me.btnRemoveSN.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRemoveSN.Size = New System.Drawing.Size(144, 24)
            Me.btnRemoveSN.TabIndex = 5
            Me.btnRemoveSN.Text = "REMOVE SN"
            '
            'lstDevices
            '
            Me.lstDevices.Location = New System.Drawing.Point(11, 104)
            Me.lstDevices.Name = "lstDevices"
            Me.lstDevices.Size = New System.Drawing.Size(285, 316)
            Me.lstDevices.TabIndex = 3
            '
            'lblRMACount
            '
            Me.lblRMACount.BackColor = System.Drawing.Color.Purple
            Me.lblRMACount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblRMACount.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRMACount.ForeColor = System.Drawing.Color.White
            Me.lblRMACount.Location = New System.Drawing.Point(320, 24)
            Me.lblRMACount.Name = "lblRMACount"
            Me.lblRMACount.Size = New System.Drawing.Size(80, 32)
            Me.lblRMACount.TabIndex = 97
            Me.lblRMACount.Text = "0"
            Me.lblRMACount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(320, 8)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(80, 16)
            Me.Label3.TabIndex = 96
            Me.Label3.Text = "WO Count"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'TMISShipProduct
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(680, 470)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.panelPallet})
            Me.Name = "TMISShipProduct"
            Me.Text = "TMISShipProduct"
            Me.panelPallet.ResumeLayout(False)
            CType(Me.cboCarrier, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '***************************************************************************************************
        Private Sub TMISShipProduct_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                PSS.Core.Highlight.SetHighLight(Me)
                PopulateShipmentCarrier()

                '*********************************
                Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub ProcessWorkorder(ByVal iWOID As Integer)
            Dim dt As DataTable

            Try
                dt = Me._objShip.GetWorkorderInfo(iWOID)
                If dt.Rows.Count = 0 Then
                    Throw New Exception("Work order/Claim# is missing.")
                Else
                    Me.lblRMACount.Text = dt.Rows(0)("WO_RAQnty") ' & Me.cboRMANo.SelectedValue)(0)("WO_RAQnty")
                    Me.lblRMANo.Tag = iWOID
                    Me.lblRMANo.Text = dt.Rows(0)("WO_CustWo")
                    ProcessPallet(iWOID)
                    Me.lblShippedCount.Text = Me._objShip.GetShippedCountByWO(iWOID)
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub ProcessPallet(ByVal iWOID As Integer)
            Dim dt As DataTable
            Dim iPalletID As Integer = 0

            Try
                dt = Me._objShip.GetUnshipPalletByWO(iWOID)
                If dt.Rows.Count > 1 Then
                    Throw New Exception("Multiple open box existed for this RMA. Please contact IT.")
                ElseIf dt.Rows.Count = 0 Then
                    'Create new box
                    iPalletID = Me._objTMIShip.CreateBoxID(TMI.CUSTOMERID, TMI.LOCID, iWOID)
                    If iPalletID = 0 Then Throw New Exception("System has failed to create box.")
                    Me.lblBoxName.Text = Me._objShip.GetPalletName(iPalletID) : Me.lblBoxName.Tag = iPalletID
                    Me.RefreshDeviceList(iPalletID)
                Else
                    Me.lblBoxName.Text = dt.Rows(0)("Pallett_Name") : Me.lblBoxName.Tag = dt.Rows(0)("Pallett_ID")
                    Me.RefreshDeviceList(dt.Rows(0)("Pallett_ID"))
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub RefreshDeviceList(ByVal iPallet_ID As Integer)
            Dim dt1 As DataTable
            Dim objMisc As PSS.Data.Buisness.Misc

            Try
                If iPallet_ID > 0 Then
                    Me.lblBoxCount.Text = "0" : Me.lstDevices.DataSource = Nothing : Me.lstDevices.Items.Clear() : Me.lstDevices.Refresh()

                    objMisc = New PSS.Data.Buisness.Misc()
                    dt1 = objMisc.GetAllSNsForPallet(iPallet_ID)
                    Me.lstDevices.DataSource = dt1.DefaultView
                    Me.lstDevices.ValueMember = dt1.Columns("device_id").ToString
                    Me.lstDevices.DisplayMember = dt1.Columns("device_sn").ToString

                    Me.lblBoxCount.Text = Me.lstDevices.Items.Count
                End If

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt1)
                objMisc = Nothing
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub txtDevSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDevSN.KeyUp
            Dim dt, dtApprovedData As DataTable
            Dim iPalletID, iMaxBillRule, iRUR As Integer
            Dim booNewScan As Boolean = False

            Try
                If e.KeyCode = Keys.Enter Then
                    If Me.txtDevSN.Text.Trim.Length = 0 Then
                        Exit Sub
                    Else
                        Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                        dt = Generic.GetDeviceInfoInWIP(Me.txtDevSN.Text.Trim, TMI.CUSTOMERID, TMI.LOCID)
                        Me.Enabled = True : Cursor.Current = Cursors.Default

                        If dt.Rows.Count = 0 Then
                            MessageBox.Show("Device does not exist in WIP.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                        ElseIf dt.Rows.Count > 1 Then
                            MessageBox.Show("Device existed more than one in the system. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                        ElseIf IsDBNull(dt.Rows(0)("Device_DateBill")) Then
                            MessageBox.Show("This device has not been billed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                        ElseIf Me.lblRMANo.Tag.ToString.Trim.Length > 0 AndAlso Convert.ToInt32(Me.lblRMANo.Tag) > 0 AndAlso Convert.ToInt32(Me.lblRMANo.Tag) <> dt.Rows(0)("WO_ID") Then
                            MessageBox.Show("This device does not belong to above work order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                        ElseIf Not IsDBNull(dt.Rows(0)("Pallett_ID")) AndAlso Convert.ToInt32(dt.Rows(0)("Pallett_ID")) > 0 AndAlso Me.lblBoxName.Tag.ToString.Trim.Length > 0 AndAlso Convert.ToInt32(Me.lblBoxName.Tag) > 0 AndAlso Convert.ToInt32(Me.lblBoxName.Tag) <> dt.Rows(0)("Pallett_ID") Then
                            MessageBox.Show("Device is assigned to box ID " & dt.Rows(0)("Pallett_ID") & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                        Else
                            'New scan
                            If Me.lblRMANo.Text.Trim.Length = 0 OrElse Me.lblBoxName.Text.Trim.Length = 0 Then
                                Me.ProcessWorkorder(dt.Rows(0)("WO_ID")) : booNewScan = True
                            End If

                            If Me.lblRMANo.Text.Trim.Length = 0 OrElse Me.lblBoxName.Text.Trim.Length = 0 OrElse Me.lblRMANo.Tag.ToString.Trim.Length = 0 OrElse Me.lblBoxName.Tag.ToString.Trim.Length = 0 OrElse Convert.ToInt32(Me.lblRMANo.Tag) = 0 OrElse Convert.ToInt32(Me.lblBoxName.Tag) = 0 Then
                                MessageBox.Show("System has failed to process work order. Please re-enter S/N.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                            ElseIf Me.lblRMANo.Tag.ToString.Trim.Length > 0 AndAlso Convert.ToInt32(Me.lblRMANo.Tag) > 0 AndAlso Convert.ToInt32(Me.lblRMANo.Tag) <> dt.Rows(0)("WO_ID") Then
                                MessageBox.Show("This device does not belong to above work order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                            ElseIf Not IsDBNull(dt.Rows(0)("Pallett_ID")) AndAlso Convert.ToInt32(dt.Rows(0)("Pallett_ID")) > 0 AndAlso Me.lblBoxName.Tag.ToString.Trim.Length > 0 AndAlso Convert.ToInt32(Me.lblBoxName.Tag) > 0 AndAlso Convert.ToInt32(Me.lblBoxName.Tag) <> dt.Rows(0)("Pallett_ID") Then
                                MessageBox.Show("This device is assigned to box ID " & dt.Rows(0)("Pallett_ID") & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                            ElseIf Not IsNothing(Me.lstDevices.DataSource) AndAlso Me.lstDevices.Items.Count > 0 AndAlso Me.lstDevices.DataSource.Table.Select("device_sn = '" & Me.txtDevSN.Text.Trim.ToUpper & "'").Length > 0 Then
                                ''***************************************************
                                ''Check if the Device is already scanned in
                                ''***************************************************
                                If booNewScan = False Then
                                    MsgBox("This device is already scanned in.", MsgBoxStyle.Information, "Information") : Me.txtDevSN.SelectAll()
                                Else
                                    Me.txtDevSN.Text = ""
                                End If
                                Me.txtDevSN.Focus()
                            Else
                                'get maxium bill rule
                                iMaxBillRule = Generic.GetMaxBillRule(Convert.ToInt32(dt.Rows(0)("Device_ID")))
                                iRUR = 0

                                ''*****************************************************
                                ''Check QC
                                ''*****************************************************
                                'If iMaxBillRule <> 1 AndAlso iMaxBillRule <> 2 AndAlso iRUR <> 1 Then
                                '    If Generic.IsValidQCResults(dt.Rows(0)("Device_ID"), 1, "Functional", True, True) = False Then
                                '        Exit Sub : Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                                '    End If
                                'End If

                                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                                iPalletID = CInt(Me.lblBoxName.Tag)
                                If iPalletID = 0 Then
                                    Throw New Exception("System has failed to create box.")
                                ElseIf Generic.IsPalletClosed(iPalletID) = True Then
                                    MsgBox("Box had been closed by another machine. Please refresh your screen.", MsgBoxStyle.Information, "Device Scan")
                                Else
                                    PSS.Data.Production.Shipping.AssignDeviceToPallet(dt.Rows(0)("Device_ID"), iPalletID)
                                    RefreshDeviceList(iPalletID) : Me.txtDevSN.Text = "" : Me.Enabled = True : Me.txtDevSN.Focus()
                                End If 'check pallet status
                            End If 'check device's order and pallett
                        End If 'check device data
                    End If  'check user input
                End If 'enter key
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtDevSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt)
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub btnRemoveSN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveSN.Click
            Dim strSN As String = ""
            Dim i, iDeviceID As Integer

            Try
                '************************
                'Validations
                If IsNothing(Me.lstDevices.DataSource) OrElse Me.lstDevices.Items.Count = 0 Then
                    Exit Sub
                ElseIf CInt(Me.lblBoxName.Tag) = 0 Then
                    MessageBox.Show("Box ID is missing. Please refresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Else
                    '************************
                    strSN = InputBox("Enter S/N:", "S/N").Trim
                    If strSN = "" Then
                        Exit Sub
                    Else
                        i = 0 : iDeviceID = 0
                        If Me.lstDevices.DataSource.Table.Select("device_sn = '" & strSN & "'").Length > 0 Then
                            iDeviceID = Me.lstDevices.DataSource.Table.Select("device_sn = '" & strSN & "'")(0)("device_id")

                            Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                            i = PSS.Data.Production.Shipping.RemoveSNfromPallet(CInt(Me.lblBoxName.Tag), iDeviceID)
                            If i = 0 Then
                                MessageBox.Show("S/N entered was not removed from Box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Else
                                Me.RefreshDeviceList(CInt(Me.lblBoxName.Tag))
                            End If
                        Else
                            MessageBox.Show("S/N is not listed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        End If
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Remove S/N", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                Me.txtDevSN.Focus()
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub btnRemoveAllSNs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveAllSNs.Click
            Dim i As Integer = 0

            Try
                If IsNothing(Me.lstDevices.DataSource) OrElse Me.lstDevices.Items.Count = 0 Then
                    Exit Sub
                ElseIf MessageBox.Show("Are you sure you want to remove all devices from this Box?", "Clear All S/N", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Exit Sub
                ElseIf CInt(Me.lblBoxName.Tag) = 0 Then
                    MessageBox.Show("Box ID is missing. Please refresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                    i = PSS.Data.Production.Shipping.RemoveSNfromPallet(CInt(Me.lblBoxName.Tag), )
                    If i = 0 Then
                        MessageBox.Show("No S/N were removed from box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Else
                        Me.RefreshDeviceList(CInt(Me.lblBoxName.Tag))
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Clear All SNs", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                Me.txtDevSN.Focus()
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub btnCloseAndShipBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseAndShipBox.Click
            Dim i As Integer = 0
            Dim dt As DataTable

            Try
                If Me.lblRMANo.Text.Trim.Length = 0 OrElse Me.lblBoxName.Text.Trim.Length = 0 Then
                    Exit Sub
                ElseIf MessageBox.Show("Are you sure you want to close and ship this RMA", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Exit Sub
                ElseIf Me.cboCarrier.SelectedValue = 0 Then
                    MessageBox.Show("Please select ship carrier.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.txtTrackNo.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter tracking #.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.lblRMANo.Tag.ToString.Trim.Length = 0 OrElse Convert.ToInt32(Me.lblRMANo.Tag) = 0 Then
                    MessageBox.Show("RMA is not defined.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf CInt(Me.lblBoxName.Tag) = 0 Then
                    MessageBox.Show("Box ID is missing for this RMA.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf IsNothing(Me.lstDevices.DataSource) OrElse Me.lstDevices.Items.Count = 0 Then
                    MessageBox.Show("RMA is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf CInt(Me.lblBoxName.Tag) = 0 Then
                    MessageBox.Show("Box ID is missing. Please refresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    dt = Me._objShip.GetPalletInfoByName(Me.lblBoxName.Text.Trim, PSS.Data.Buisness.TMI.CUSTOMERID)
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("This box " & Me.lblBoxName.Text & " is not in the system. Please refresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    ElseIf dt.Rows.Count > 1 Then
                        MessageBox.Show("Multiple boxes existed. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    ElseIf dt.Rows(0)("Pallett_ID").ToString <> Me.lblBoxName.Tag.ToString Then
                        MessageBox.Show("Box name and ID does not match. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    ElseIf dt.Rows(0)("Pallett_ID") = 1 Then
                        MessageBox.Show("This box has already close. Please refresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    ElseIf Not IsDBNull(dt.Rows(0)("Pallett_ShipDate")) AndAlso dt.Rows(0)("Pallett_ShipDate").ToString.Trim.Length > 0 Then
                        MessageBox.Show("This box has already shipped. Please refresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Else
                        Dim iRcvdQty As Integer = Generic.GetRecQty(Convert.ToInt32(Me.lblRMANo.Tag))
                        If iRcvdQty <> Me.lstDevices.Items.Count Then
                            MessageBox.Show("Can't ship partial RMA.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If

                        Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                        Dim strNextStation As String = Generic.GetNextWorkStationInWFP(Me._strScreenName, 0, TMI.CUSTOMERID, , )

                        Me.BillExceptionRepairs()

                        i = Me._objTMIShip.CloseAndShipBox(CInt(Me.lblBoxName.Tag), Convert.ToInt32(Me.lblRMANo.Tag), PSS.Core.ApplicationUser.IDShift, Me.lstDevices.Items.Count, strNextStation, Me._objShip, Me.cboCarrier.SelectedValue, Me.txtTrackNo.Text.Trim)
                        If i = 0 Then
                            MessageBox.Show("System has failed to ship.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Else
                            Me._objTMIShip.PrintManifestLabel(CInt(Me.lblBoxName.Tag))

                            Me.lblRMANo.Text = "" : Me.lblRMANo.Tag = 0 : Me.lblRMACount.Text = "0"
                            Me.lblBoxName.Text = "" : Me.lblBoxName.Tag = "0"
                            Me.txtDevSN.Text = "" : Me.lblBoxCount.Text = "0"
                            Me.lstDevices.DataSource = Nothing : Me.lstDevices.Items.Clear() : Me.lstDevices.Refresh()
                            Me.txtTrackNo.Text = ""
                            Me.Enabled = True : Cursor.Current = Cursors.Default : Me.txtDevSN.Focus()
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnCloseAndShipBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub btnReprintManifest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprintManifest.Click
            Dim strPalletName As String = ""
            Dim dtPallettInfo As DataTable
            Dim objMisc As PSS.Data.Buisness.Misc

            Try
                strPalletName = InputBox("Enter Box Name:", "Box Name").Trim
                If strPalletName = "" Then
                    Exit Sub
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                    objMisc = New PSS.Data.Buisness.Misc()
                    dtPallettInfo = objMisc.GetPalletInfo_ByPallettName(strPalletName)
                    If dtPallettInfo.Rows.Count = 0 Then
                        MessageBox.Show("Box Name was not defined in system.", "Reprint Label", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    ElseIf dtPallettInfo.Rows.Count > 1 Then
                        MessageBox.Show("Box Name existed twice in the system.", "Reprint Label", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    ElseIf Convert.ToInt32(dtPallettInfo.Rows(0)("Cust_ID")) <> TMI.CUSTOMERID Then
                        MessageBox.Show("Box Name does not belong to TMI.", "Reprint Label", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    ElseIf IsDBNull(dtPallettInfo.Rows(0)("Pallett_ShipDate")) Then
                        MessageBox.Show("Box Name has not shipped.", "Reprint Label", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Else
                        Me._objTMIShip.PrintManifestLabel(Convert.ToInt32(dtPallettInfo.Rows(0)("Pallett_ID")))
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnReprintManifest_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                objMisc = Nothing : Generic.DisposeDT(dtPallettInfo)
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '*************************************************************************************************************
        Private Function BillExceptionRepairs() As Integer
            Dim dt As New DataTable()
            Dim R1 As DataRow
            Dim i As Integer = 0

            Try
                dt = Me.lstDevices.DataSource.Table
                For Each R1 In dt.Rows
                    If Me._objTMIShip.IsDeviceHasExceptionRepairs(R1("Device_ID")) = True Then
                        i += Me._objTMIShip.UpdateInvoiceAmount(R1("Device_ID"))
                    End If
                Next R1
                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Private Sub PopulateShipmentCarrier()
            Dim row As DataRow
            Dim i As Integer
            Dim dTB As DataTable
            Dim objTMI As PSS.Data.Buisness.TMI

            Try
                Me.cboCarrier.ClearItems()

                objTMI = New PSS.Data.Buisness.TMI()
                dTB = objTMI.GetShipCarriers

                If dTB.Rows.Count > 0 Then
                    Misc.PopulateC1DropDownList(Me.cboCarrier, dTB, "SC_Desc", "SC_ID")
                    Me.cboCarrier.SelectedValue = 2 'FedEx Ground
                End If

                dTB = Nothing
                objTMI = Nothing

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "PopulateShipmentCarrier", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*************************************************************************************************************


    End Class
End Namespace