Option Explicit On 

Imports System
Imports PSS.Data.Buisness
Imports System.Text

Namespace Gui.TracFoneFulfillmentKit
    Public Class frmTFFK_BYOP_Kitting_MCarton
        Inherits System.Windows.Forms.Form

        Private Declare Function IDAutomation_Universal_C128 _
                         Lib "IDAutomationNativeFontEncoder.dll" _
                        (ByVal D2E As String, ByRef tilde As Long, _
                         ByVal out As String, _
                         ByRef iSize As Long) As Long

        Private _strComputerName As String = ""
        Private _strCartonLabel_PrinterName As String = ""
        Private _iCarton_ID As Integer = 0
        Private _dtCarton As DataTable

        Private _objTFFK As PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK
        Private _objBYOP_Kitting As PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK_BYOP_Kitting
        Private _BaseClass As PSS.Data.BaseClasses.CollectTrackingLog

        Private _UserID As Integer = PSS.Core.Global.ApplicationUser.IDuser

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._objTFFK = New PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK()
            Me._objBYOP_Kitting = New PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK_BYOP_Kitting()
            Me._BaseClass = New PSS.Data.BaseClasses.CollectTrackingLog()
            Me._strComputerName = Me._BaseClass.GetComputerName
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                Try
                    Me._objTFFK = Nothing
                    Me._objBYOP_Kitting = Nothing
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
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents pnlCarton As System.Windows.Forms.Panel
        Friend WithEvents lblCarton As System.Windows.Forms.Label
        Friend WithEvents txtCarton As System.Windows.Forms.TextBox
        Friend WithEvents btnComplete As System.Windows.Forms.Button
        Friend WithEvents btnRemoveOne As System.Windows.Forms.Button
        Friend WithEvents lblQty As System.Windows.Forms.Label
        Friend WithEvents txtQty As System.Windows.Forms.TextBox
        Friend WithEvents lblWorkStation As System.Windows.Forms.Label
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents chkPrinLabel As System.Windows.Forms.CheckBox
        Friend WithEvents tdgItemSNs As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents txtSN As System.Windows.Forms.TextBox
        Friend WithEvents lblUPC As System.Windows.Forms.Label
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents lblMasterItem As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents btnRemoveAll As System.Windows.Forms.Button
        Friend WithEvents btnReprintLabel As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTFFK_BYOP_Kitting_MCarton))
            Me.tdgItemSNs = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtSN = New System.Windows.Forms.TextBox()
            Me.btnComplete = New System.Windows.Forms.Button()
            Me.pnlCarton = New System.Windows.Forms.Panel()
            Me.txtCarton = New System.Windows.Forms.TextBox()
            Me.lblUPC = New System.Windows.Forms.Label()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.lblMasterItem = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.lblQty = New System.Windows.Forms.Label()
            Me.txtQty = New System.Windows.Forms.TextBox()
            Me.lblCarton = New System.Windows.Forms.Label()
            Me.btnRemoveOne = New System.Windows.Forms.Button()
            Me.btnReprintLabel = New System.Windows.Forms.Button()
            Me.btnRemoveAll = New System.Windows.Forms.Button()
            Me.lblWorkStation = New System.Windows.Forms.Label()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.chkPrinLabel = New System.Windows.Forms.CheckBox()
            CType(Me.tdgItemSNs, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlCarton.SuspendLayout()
            Me.SuspendLayout()
            '
            'tdgItemSNs
            '
            Me.tdgItemSNs.AllowColMove = False
            Me.tdgItemSNs.AllowColSelect = False
            Me.tdgItemSNs.AllowFilter = False
            Me.tdgItemSNs.AllowSort = False
            Me.tdgItemSNs.AllowUpdate = False
            Me.tdgItemSNs.BackColor = System.Drawing.Color.White
            Me.tdgItemSNs.CaptionHeight = 17
            Me.tdgItemSNs.ColumnHeaders = False
            Me.tdgItemSNs.FetchRowStyles = True
            Me.tdgItemSNs.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgItemSNs.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgItemSNs.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.tdgItemSNs.Location = New System.Drawing.Point(136, 144)
            Me.tdgItemSNs.Name = "tdgItemSNs"
            Me.tdgItemSNs.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgItemSNs.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgItemSNs.PreviewInfo.ZoomFactor = 75
            Me.tdgItemSNs.RecordSelectors = False
            Me.tdgItemSNs.RowHeight = 15
            Me.tdgItemSNs.Size = New System.Drawing.Size(272, 120)
            Me.tdgItemSNs.TabIndex = 190
            Me.tdgItemSNs.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Style1{}Normal{Font:Tahoma, 8.25pt;}HighlightRow{ForeColo" & _
            "r:HighlightText;BackColor:Highlight;}Style14{}OddRow{}RecordSelector{AlignImage:" & _
            "Center;}Style15{}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;F" & _
            "oreColor:ControlText;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}" & _
            "Style12{}Style13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView" & _
            " AllowColMove=""False"" AllowColSelect=""False"" Name="""" CaptionHeight=""17"" ColumnCa" & _
            "ptionHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyles=""True"" MarqueeStyle=""Dot" & _
            "tedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" RecordSelectors=""Fal" & _
            "se"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>116</Height><Capti" & _
            "onStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" " & _
            "/><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar" & _
            """ me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""" & _
            "Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRow" & _
            "Style parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""S" & _
            "tyle4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=" & _
            """RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><" & _
            "Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 268, 116</ClientRect><Bord" & _
            "erSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.Merg" & _
            "eView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal" & _
            """ me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" m" & _
            "e=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=" & _
            """Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""Hig" & _
            "hlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""Od" & _
            "dRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=" & _
            """FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</" & _
            "vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17" & _
            "</DefaultRecSelWidth><ClientArea>0, 0, 268, 116</ClientArea><PrintPageHeaderStyl" & _
            "e parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob" & _
            ">"
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.Navy
            Me.Label3.Location = New System.Drawing.Point(8, 120)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(128, 21)
            Me.Label3.TabIndex = 189
            Me.Label3.Text = "Item SN:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtSN
            '
            Me.txtSN.BackColor = System.Drawing.Color.White
            Me.txtSN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSN.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtSN.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtSN.Location = New System.Drawing.Point(136, 120)
            Me.txtSN.Name = "txtSN"
            Me.txtSN.Size = New System.Drawing.Size(272, 23)
            Me.txtSN.TabIndex = 0
            Me.txtSN.Text = ""
            '
            'btnComplete
            '
            Me.btnComplete.BackColor = System.Drawing.Color.BurlyWood
            Me.btnComplete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnComplete.ForeColor = System.Drawing.Color.DarkBlue
            Me.btnComplete.Location = New System.Drawing.Point(432, 216)
            Me.btnComplete.Name = "btnComplete"
            Me.btnComplete.Size = New System.Drawing.Size(208, 56)
            Me.btnComplete.TabIndex = 193
            Me.btnComplete.Text = "Complete Master Carton"
            '
            'pnlCarton
            '
            Me.pnlCarton.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtCarton, Me.lblUPC, Me.Label11, Me.lblMasterItem, Me.Label1, Me.lblQty, Me.txtQty, Me.lblCarton})
            Me.pnlCarton.Location = New System.Drawing.Point(8, 24)
            Me.pnlCarton.Name = "pnlCarton"
            Me.pnlCarton.Size = New System.Drawing.Size(648, 88)
            Me.pnlCarton.TabIndex = 194
            '
            'txtCarton
            '
            Me.txtCarton.BackColor = System.Drawing.Color.White
            Me.txtCarton.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.txtCarton.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtCarton.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtCarton.Location = New System.Drawing.Point(128, 14)
            Me.txtCarton.Name = "txtCarton"
            Me.txtCarton.Size = New System.Drawing.Size(272, 23)
            Me.txtCarton.TabIndex = 193
            Me.txtCarton.Text = ""
            '
            'lblUPC
            '
            Me.lblUPC.Location = New System.Drawing.Point(128, 60)
            Me.lblUPC.Name = "lblUPC"
            Me.lblUPC.Size = New System.Drawing.Size(136, 24)
            Me.lblUPC.TabIndex = 205
            Me.lblUPC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label11
            '
            Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label11.ForeColor = System.Drawing.Color.Navy
            Me.Label11.Location = New System.Drawing.Point(48, 60)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(80, 24)
            Me.Label11.TabIndex = 204
            Me.Label11.Text = "UPC(14):"
            Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblMasterItem
            '
            Me.lblMasterItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblMasterItem.Location = New System.Drawing.Point(128, 40)
            Me.lblMasterItem.Name = "lblMasterItem"
            Me.lblMasterItem.Size = New System.Drawing.Size(296, 24)
            Me.lblMasterItem.TabIndex = 203
            Me.lblMasterItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Navy
            Me.Label1.Location = New System.Drawing.Point(32, 40)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(96, 24)
            Me.Label1.TabIndex = 202
            Me.Label1.Text = "Item:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblQty
            '
            Me.lblQty.BackColor = System.Drawing.Color.Transparent
            Me.lblQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblQty.ForeColor = System.Drawing.Color.Navy
            Me.lblQty.Location = New System.Drawing.Point(424, 16)
            Me.lblQty.Name = "lblQty"
            Me.lblQty.Size = New System.Drawing.Size(64, 21)
            Me.lblQty.TabIndex = 198
            Me.lblQty.Text = "Qty:"
            Me.lblQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtQty
            '
            Me.txtQty.BackColor = System.Drawing.Color.White
            Me.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtQty.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtQty.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtQty.Location = New System.Drawing.Point(488, 14)
            Me.txtQty.Name = "txtQty"
            Me.txtQty.Size = New System.Drawing.Size(68, 33)
            Me.txtQty.TabIndex = 197
            Me.txtQty.Text = ""
            '
            'lblCarton
            '
            Me.lblCarton.BackColor = System.Drawing.Color.Transparent
            Me.lblCarton.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCarton.ForeColor = System.Drawing.Color.Navy
            Me.lblCarton.Location = New System.Drawing.Point(8, 16)
            Me.lblCarton.Name = "lblCarton"
            Me.lblCarton.Size = New System.Drawing.Size(120, 21)
            Me.lblCarton.TabIndex = 194
            Me.lblCarton.Text = "Master Carton:"
            Me.lblCarton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnRemoveOne
            '
            Me.btnRemoveOne.BackColor = System.Drawing.Color.BurlyWood
            Me.btnRemoveOne.Location = New System.Drawing.Point(432, 120)
            Me.btnRemoveOne.Name = "btnRemoveOne"
            Me.btnRemoveOne.Size = New System.Drawing.Size(104, 40)
            Me.btnRemoveOne.TabIndex = 197
            Me.btnRemoveOne.Text = "Remove One SN"
            '
            'btnReprintLabel
            '
            Me.btnReprintLabel.BackColor = System.Drawing.Color.BurlyWood
            Me.btnReprintLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprintLabel.ForeColor = System.Drawing.Color.RoyalBlue
            Me.btnReprintLabel.Location = New System.Drawing.Point(432, 168)
            Me.btnReprintLabel.Name = "btnReprintLabel"
            Me.btnReprintLabel.Size = New System.Drawing.Size(208, 40)
            Me.btnReprintLabel.TabIndex = 198
            Me.btnReprintLabel.Text = "Reprint Carton Label"
            '
            'btnRemoveAll
            '
            Me.btnRemoveAll.BackColor = System.Drawing.Color.BurlyWood
            Me.btnRemoveAll.Location = New System.Drawing.Point(536, 120)
            Me.btnRemoveAll.Name = "btnRemoveAll"
            Me.btnRemoveAll.Size = New System.Drawing.Size(104, 40)
            Me.btnRemoveAll.TabIndex = 199
            Me.btnRemoveAll.Text = "Remove All SNs"
            '
            'lblWorkStation
            '
            Me.lblWorkStation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWorkStation.ForeColor = System.Drawing.Color.Navy
            Me.lblWorkStation.Location = New System.Drawing.Point(104, 0)
            Me.lblWorkStation.Name = "lblWorkStation"
            Me.lblWorkStation.Size = New System.Drawing.Size(216, 24)
            Me.lblWorkStation.TabIndex = 201
            Me.lblWorkStation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label9
            '
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.Navy
            Me.Label9.Location = New System.Drawing.Point(8, 0)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(96, 24)
            Me.Label9.TabIndex = 200
            Me.Label9.Text = "Workstation:"
            Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkPrinLabel
            '
            Me.chkPrinLabel.ForeColor = System.Drawing.Color.Black
            Me.chkPrinLabel.Location = New System.Drawing.Point(432, 280)
            Me.chkPrinLabel.Name = "chkPrinLabel"
            Me.chkPrinLabel.Size = New System.Drawing.Size(160, 16)
            Me.chkPrinLabel.TabIndex = 205
            Me.chkPrinLabel.Text = "Print Carton  Label"
            '
            'frmTFFK_BYOP_Kitting_MCarton
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.Wheat
            Me.ClientSize = New System.Drawing.Size(744, 366)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkPrinLabel, Me.lblWorkStation, Me.Label9, Me.btnRemoveAll, Me.btnReprintLabel, Me.btnRemoveOne, Me.pnlCarton, Me.btnComplete, Me.tdgItemSNs, Me.Label3, Me.txtSN})
            Me.Name = "frmTFFK_BYOP_Kitting_MCarton"
            Me.Text = "frmTFFK_BYOP_Kitting_MCarton"
            CType(Me.tdgItemSNs, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlCarton.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region


        Private Sub frmTFFK_BYOP_Kitting_MCarton_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Try
                PSS.Core.Highlight.SetHighLight(Me)
                Me.chkPrinLabel.Checked = True

                If Me._strComputerName.Trim.Length = 0 Then
                    MessageBox.Show("No computer name (workstation). See IT", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                Me.lblWorkStation.Text = Me._strComputerName
                Me.txtQty.Text = 0
                Me.txtCarton.Text = ""
                Me.txtCarton.ReadOnly = True : Me.txtCarton.BackColor = System.Drawing.Color.Cornsilk
                Me.txtQty.ReadOnly = True : Me.txtQty.BackColor = System.Drawing.Color.Cornsilk
                Me.pnlCarton.Visible = False

                Me.ActiveControl = Me.txtSN
                Me.txtSN.Text = "" : Me.txtSN.SelectAll() : Me.txtSN.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub frmTFFK_BYOP_Kitting_MCarton_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub txtSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyUp
            Try
                If e.KeyCode = Keys.Enter AndAlso Me.txtSN.Text.Trim.Length > 0 Then
                    Me.ProcessSN()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub ProcessSN()
            Dim strSN As String = ""
            Dim strCartonName As String = ""

            Dim dt As DataTable
            Dim row As DataRow
            Dim iIdx As Integer = 0

            Try
                'Get  data
                strSN = Me.txtSN.Text.Trim
                If strSN.Trim.Length = 0 Then
                    MessageBox.Show("Please enter SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtSN.SelectAll() : Me.txtSN.Focus()
                    Exit Sub
                ElseIf Convert.ToInt32(Me.txtQty.Text) >= Me._objTFFK._iKittedPackQtyPerCarton Then
                    MessageBox.Show("The carton is fulfilled (qty of per carton is " & Me._objTFFK._iKittedPackQtyPerCarton.ToString & "). " & Environment.NewLine & "Ready to complete the carton now.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtSN.Text = "" : Me.btnComplete.Focus()
                    Exit Sub
                End If

                dt = Me._objBYOP_Kitting.getMasterCartonAvailableItemData(strSN)
                If Me._iCarton_ID = 0 Then Me._dtCarton = dt.Clone

                If dt.Rows.Count > 1 Then
                    MessageBox.Show("Duplicate SNs. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtSN.SelectAll() : Me.txtSN.Focus() : Exit Sub
                ElseIf dt.Rows.Count = 0 Then
                    MessageBox.Show("Can't find this SN '" & strSN & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtSN.SelectAll() : Me.txtSN.Focus() : Exit Sub
                ElseIf Me._dtCarton.Rows.Count > 0 Then
                    For Each row In Me._dtCarton.Rows
                        If Convert.ToString(row("SN")).Trim.ToUpper = strSN.Trim.ToUpper Then
                            MessageBox.Show("SN '" & strSN & "' already in the list. Can't add it again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.txtSN.SelectAll() : Me.txtSN.Focus() : Exit Sub
                        End If
                    Next
                End If

                'Ready: dt.Rows.Count=1
                If Me._iCarton_ID = 0 Then 'create carton name at the first SN
                    strCartonName = Me._objBYOP_Kitting.CreateMasterCartonName(Me._strComputerName, Me._iCarton_ID)
                    Me.lblMasterItem.Text = Convert.ToString(dt.Rows(0).Item("Master_Item"))
                    Me.txtCarton.Text = strCartonName
                    Me.lblUPC.Text = Convert.ToString(dt.Rows(0).Item("UPC"))
                    If Not Me._iCarton_ID > 0 Then
                        MessageBox.Show("Failed to create master carton name. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txtSN.SelectAll() : Me.txtSN.Focus() : Exit Sub
                    End If
                    Me.pnlCarton.Visible = True
                End If

                'Ready
                For Each row In dt.Rows 'must be 1 row 
                    iIdx = Me._dtCarton.Rows.Count + 1
                    row.BeginEdit() : row("Row") = iIdx : row.AcceptChanges()
                    Me._dtCarton.ImportRow(row)
                Next

                Me.BindSNsData(Me._dtCarton)

                If Convert.ToInt32(Me.txtQty.Text) = Me._objTFFK._iKittedPackQtyPerCarton Then
                    Me.txtSN.Text = "" : Me.btnComplete.Focus()
                Else
                    Me.txtSN.Text = "" : Me.txtSN.SelectAll() : Me.txtSN.Focus()
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, " ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                dt = Nothing
            End Try
        End Sub

        Private Sub BindSNsData(ByVal dt As DataTable)
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
            Dim i As Integer = 0
            Dim iKeySIM As Integer = 0

            Try
                If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                    With Me.tdgItemSNs
                        .DataSource = dt.DefaultView
                        For Each dbgc In .Splits(0).DisplayColumns
                            dbgc.Locked = True
                            Select Case dbgc.Name
                                Case "Row", "SN"
                                    dbgc.Visible = True
                                Case Else
                                    dbgc.Visible = False
                            End Select
                            dbgc.AutoSize()
                            'If dbgc.Name = "SN" Then dbgc.Width = 200
                        Next dbgc
                        '.Splits(0).DisplayColumns("SoDetailsID").Width = 0
                    End With
                End If

                Me.txtQty.Text = Me._dtCarton.Rows.Count.ToString

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "BindSNsData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnRemoveOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveOne.Click
            Dim strSN As String = ""
            Dim row As DataRow
            Dim dtTmp As DataTable
            Dim bFound As Boolean = False
            Dim i As Integer = 0

            Try
                If IsNothing(Me._dtCarton) Then Exit Sub

                strSN = InputBox("Enter Item SN:", "Enter SN", "")

                If strSN.Trim.Length > 0 Then
                    If Me._dtCarton.Rows.Count = 1 AndAlso strSN.Trim.ToUpper = Convert.ToString(Me._dtCarton.Rows(0).Item("SN")).ToUpper Then
                        If strSN.Trim.ToUpper = Convert.ToString(Me._dtCarton.Rows(0).Item("SN")).ToUpper Then
                            Me._dtCarton.Clear()
                            Me.BindSNsData(Me._dtCarton)
                        Else
                            MessageBox.Show("SN '" & strSN & "' not in the list.")
                        End If
                    Else
                        dtTmp = Me._dtCarton.Clone
                        For Each row In Me._dtCarton.Rows
                            If strSN.Trim.ToUpper = Convert.ToString(row("SN")).ToUpper Then
                                bFound = True
                            Else
                                i += 1
                                row.BeginEdit() : row("Row") = i : row.AcceptChanges()
                                dtTmp.ImportRow(row)
                            End If
                        Next
                        If bFound Then
                            Me._dtCarton = dtTmp.Copy
                            Me.BindSNsData(Me._dtCarton)
                        Else
                            MessageBox.Show("SN '" & strSN & "' not in the list.")
                        End If
                    End If
                Else
                    MessageBox.Show("You must enter an item SN.")
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRemoveOne_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.txtSN.Text = "" : Me.txtSN.SelectAll() : Me.txtSN.Focus()
            End Try
        End Sub

        Private Sub RemoveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveAll.Click
            Try
                If IsNothing(Me._dtCarton) Then Exit Sub

                Me._dtCarton.Clear()
                Me.BindSNsData(Me._dtCarton)
                ' Me.txtSN.Text = "" : Me.txtSN.SelectAll() : Me.txtSN.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRemoveAll_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.txtSN.Text = "" : Me.txtSN.SelectAll() : Me.txtSN.Focus()
            End Try
        End Sub

        Private Sub btnComplete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnComplete.Click
            Dim strKP_IDs As String = ""
            Dim row As DataRow
            Dim i As Integer = 0
            Dim strPrinterName As String = ""

            Try
                If IsNothing(Me._dtCarton) Then
                    MessageBox.Show("Empty carton data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtSN.SelectAll() : Me.txtSN.Focus() : Exit Sub
                End If

                If Not Convert.ToInt32(Me.txtQty.Text) = Me._objTFFK._iKittedPackQtyPerCarton Then
                    MessageBox.Show("Not fulfilled the carton yet (need " & Me._objTFFK._iKittedPackQtyPerCarton.ToString & ").", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtSN.SelectAll() : Me.txtSN.Focus() : Exit Sub
                End If
                If Not Me._dtCarton.Rows.Count = Convert.ToInt32(Me.txtQty.Text) Then
                    MessageBox.Show("The carton data rows don't match the qty. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtSN.SelectAll() : Me.txtSN.Focus() : Exit Sub
                End If
                If Not Me._iCarton_ID > 0 Then
                    MessageBox.Show("No Carton_ID. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtSN.SelectAll() : Me.txtSN.Focus() : Exit Sub
                End If
                If Me._objBYOP_Kitting.IsCartonClosed(Me._iCarton_ID) Then
                    MessageBox.Show("The carton " & Me.txtCarton.Text & " is closed or can't find it. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtSN.SelectAll() : Me.txtSN.Focus() : Exit Sub
                End If

                'ready 
                For Each row In Me._dtCarton.Rows
                    If strKP_IDs.Trim.Length = 0 Then
                        strKP_IDs = Convert.ToString(row("KP_ID"))
                    Else
                        strKP_IDs &= "," & Convert.ToString(row("KP_ID"))
                    End If
                Next
                'save data
                i = Me._objBYOP_Kitting.SaveMasterCartonData(Me._iCarton_ID, Convert.ToInt32(Me.txtQty.Text), Convert.ToInt32(Me._dtCarton.Rows(0).Item("Model_ID")), 1, Me._UserID, strKP_IDs, 0)

                If i = 0 Then
                    MessageBox.Show("Failed to save. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtSN.SelectAll() : Me.txtSN.Focus() : Exit Sub
                End If
                'printmaster carton label
                If Me.chkPrinLabel.Checked Then
                    Dim FontEncoder As New IDAutomation.NetAssembly.FontEncoder()
                    'Row, Pack_WO_ID, KMSet_ID, WIP_No, Target_Qty, Qty, Closed, KP_ID, UPC, ItemUPC, Master_Item, SN, Model_ID, KPD_ID, Carton_ID
                    Dim strUPC As String = "" : Dim strUPCCode As String = ""
                    Dim iQty As Integer = 0 : Dim strQtyCode As String = ""
                    Dim strItem As String = "" : Dim strItemCode As String = ""
                    Dim strTag As String = "" : Dim strTagCode As String = ""
                    Dim strSN1 As String = "" : Dim strSN1Code As String = ""
                    Dim strSN2 As String = "" : Dim strSN2Code As String = ""
                    Dim strSN3 As String = "" : Dim strSN3Code As String = ""
                    Dim strSN4 As String = "" : Dim strSN4Code As String = ""
                    Dim strSN5 As String = "" : Dim strSN5Code As String = ""

                    strUPC = Convert.ToString(Me._dtCarton.Rows(0).Item("UPC")).Trim
                    strUPCCode = FontEncoder.Code128a(strUPC)
                    iQty = Convert.ToInt32(Me.txtQty.Text)
                    strQtyCode = FontEncoder.Code128a(iQty)
                    strItem = Convert.ToString(Me._dtCarton.Rows(0).Item("Master_Item")).Trim
                    strItemCode = FontEncoder.Code128a(strItem)
                    strTag = Me.txtCarton.Text.Trim
                    strTagCode = FontEncoder.Code128a(strTag)
                    For i = 0 To Me._dtCarton.Rows.Count - 1
                        Select Case i
                            Case 0
                                strSN1 = Convert.ToString(Me._dtCarton.Rows(i).Item("SN")).Trim
                                strSN1Code = FontEncoder.Code128a(strSN1)
                            Case 1
                                strSN2 = Convert.ToString(Me._dtCarton.Rows(i).Item("SN")).Trim
                                strSN2Code = FontEncoder.Code128a(strSN2)
                            Case 2
                                strSN3 = Convert.ToString(Me._dtCarton.Rows(i).Item("SN")).Trim
                                strSN3Code = FontEncoder.Code128a(strSN3)
                            Case 3
                                strSN4 = Convert.ToString(Me._dtCarton.Rows(i).Item("SN")).Trim
                                strSN4Code = FontEncoder.Code128a(strSN4)
                            Case 4
                                strSN5 = Convert.ToString(Me._dtCarton.Rows(i).Item("SN")).Trim
                                strSN5Code = FontEncoder.Code128a(strSN5)
                        End Select
                    Next
                    FontEncoder = Nothing
                    strPrinterName = Me._objBYOP_Kitting.getTFFK_LabelPrinterName(Me._objTFFK.ProcessTypeIDs.Standard_Kitting, Me._strComputerName, Me._objTFFK.StandardKittingLabels.Carton_Label)
                    Me._objBYOP_Kitting.PrintMasterCarton_Label(strUPC, strUPCCode, iQty, strQtyCode, strItem, strItemCode, _
                                                                 strTag, strTagCode, strSN1, strSN1Code, strSN2, strSN2Code, strSN3, _
                                                                 strSN3Code, strSN4, strSN4Code, strSN5, strSN5Code, strPrinterName, 1)
                End If

                'clear/reset for anew carton
                Me._dtCarton = Nothing : Me._iCarton_ID = 0 : Me.txtCarton.Text = "" : Me.lblMasterItem.Text = "" : Me.lblUPC.Text = "" : Me.txtQty.Text = 0
                Me.pnlCarton.Visible = False
                Me.tdgItemSNs.DataSource = Nothing
                Me.txtSN.Text = "" : Me.txtSN.SelectAll() : Me.txtSN.Focus()


            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnComplete_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnReprintLabel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReprintLabel.Click
            Dim strUPC As String = "" : Dim strUPCCode As String = ""
            Dim iQty As Integer = 0 : Dim strQtyCode As String = ""
            Dim strItem As String = "" : Dim strItemCode As String = ""
            Dim strTag As String = "" : Dim strTagCode As String = ""
            Dim strSN1 As String = "" : Dim strSN1Code As String = ""
            Dim strSN2 As String = "" : Dim strSN2Code As String = ""
            Dim strSN3 As String = "" : Dim strSN3Code As String = ""
            Dim strSN4 As String = "" : Dim strSN4Code As String = ""
            Dim strSN5 As String = "" : Dim strSN5Code As String = ""
            Dim strPrinterName As String = ""
            Dim i As Integer = 0
            Dim FontEncoder As New IDAutomation.NetAssembly.FontEncoder()
            Dim dt As DataTable
            Dim strCartonName As String = ""

            Try
                'Row, Pack_WO_ID, KMSet_ID, WIP_No, Target_Qty, Qty, Closed, KP_ID, UPC, ItemUPC, Carton_Name, ItemQty, Master_Item, SN, Model_ID, KPD_ID, Carton_ID
                strCartonName = InputBox("Enter carton name (carton tag):", "Enter carton name", "")

                If strCartonName.Trim.Length = 0 Then
                    MessageBox.Show("You must enter a carton name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                dt = Me._objBYOP_Kitting.getCartonLabelData(strCartonName)
                If Not dt.Rows.Count > 0 Then
                    MessageBox.Show("No data for this carton '" & strCartonName & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                strUPC = Convert.ToString(dt.Rows(0).Item("UPC")).Trim : strUPCCode = FontEncoder.Code128a(strUPC)
                iQty = Convert.ToInt32(dt.Rows(0).Item("ItemQty")) : strQtyCode = FontEncoder.Code128a(iQty)
                strItem = Convert.ToString(dt.Rows(0).Item("Master_Item")).Trim : strItemCode = FontEncoder.Code128a(strItem)
                strTag = Convert.ToString(dt.Rows(0).Item("Carton_Name")).Trim : strTagCode = FontEncoder.Code128a(strTag)
                For i = 0 To dt.Rows.Count - 1
                    Select Case i
                        Case 0
                            strSN1 = Convert.ToString(dt.Rows(i).Item("SN")).Trim
                            strSN1Code = FontEncoder.Code128a(strSN1)
                        Case 1
                            strSN2 = Convert.ToString(dt.Rows(i).Item("SN")).Trim
                            strSN2Code = FontEncoder.Code128a(strSN2)
                        Case 2
                            strSN3 = Convert.ToString(dt.Rows(i).Item("SN")).Trim
                            strSN3Code = FontEncoder.Code128a(strSN3)
                        Case 3
                            strSN4 = Convert.ToString(dt.Rows(i).Item("SN")).Trim
                            strSN4Code = FontEncoder.Code128a(strSN4)
                        Case 4
                            strSN5 = Convert.ToString(dt.Rows(i).Item("SN")).Trim
                            strSN5Code = FontEncoder.Code128a(strSN5)
                    End Select
                Next

                strPrinterName = Me._objBYOP_Kitting.getTFFK_LabelPrinterName(Me._objTFFK.ProcessTypeIDs.Standard_Kitting, Me._strComputerName, Me._objTFFK.StandardKittingLabels.Carton_Label)

                Me._objBYOP_Kitting.PrintMasterCarton_Label(strUPC, strUPCCode, iQty, strQtyCode, strItem, strItemCode, _
                                                             strTag, strTagCode, strSN1, strSN1Code, strSN2, strSN2Code, strSN3, _
                                                             strSN3Code, strSN4, strSN4Code, strSN5, strSN5Code, strPrinterName, 1)

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub PrintPalletLabel", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            FontEncoder = Nothing
        End Sub
    End Class
End Namespace