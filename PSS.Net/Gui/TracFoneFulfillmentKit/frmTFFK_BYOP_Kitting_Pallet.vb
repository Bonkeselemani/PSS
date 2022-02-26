Option Explicit On 

Imports PSS.Data.Buisness
Imports System.Text

Namespace Gui.TracFoneFulfillmentKit
    Public Class frmTFFK_BYOP_Kitting_Pallet
        Inherits System.Windows.Forms.Form
        Private Declare Function IDAutomation_Universal_C128 _
                         Lib "IDAutomationNativeFontEncoder.dll" _
                        (ByVal D2E As String, ByRef tilde As Long, _
                         ByVal out As String, _
                         ByRef iSize As Long) As Long

        Private _strComputerName As String = ""
        'Private _strPalletLabel_PrinterName As String = ""
        Private _iPallet_ID As Integer = 0
        Private _dtPallet As DataTable

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
        Friend WithEvents chkPrinLabel As System.Windows.Forms.CheckBox
        Friend WithEvents lblWorkStation As System.Windows.Forms.Label
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents btnRemoveOne As System.Windows.Forms.Button
        Friend WithEvents lblQty As System.Windows.Forms.Label
        Friend WithEvents txtQty As System.Windows.Forms.TextBox
        Friend WithEvents btnComplete As System.Windows.Forms.Button
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents btnReprintLabel As System.Windows.Forms.Button
        Friend WithEvents lblPallet As System.Windows.Forms.Label
        Friend WithEvents txtPalletName As System.Windows.Forms.TextBox
        Friend WithEvents txtCartonNo As System.Windows.Forms.TextBox
        Friend WithEvents btnRemoveAll As System.Windows.Forms.Button
        Friend WithEvents tdgPallet As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents pnlPallet As System.Windows.Forms.Panel
        Friend WithEvents lblMasterItem As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTFFK_BYOP_Kitting_Pallet))
            Me.chkPrinLabel = New System.Windows.Forms.CheckBox()
            Me.lblWorkStation = New System.Windows.Forms.Label()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.btnRemoveAll = New System.Windows.Forms.Button()
            Me.btnReprintLabel = New System.Windows.Forms.Button()
            Me.btnRemoveOne = New System.Windows.Forms.Button()
            Me.pnlPallet = New System.Windows.Forms.Panel()
            Me.lblQty = New System.Windows.Forms.Label()
            Me.txtQty = New System.Windows.Forms.TextBox()
            Me.lblPallet = New System.Windows.Forms.Label()
            Me.txtPalletName = New System.Windows.Forms.TextBox()
            Me.btnComplete = New System.Windows.Forms.Button()
            Me.tdgPallet = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtCartonNo = New System.Windows.Forms.TextBox()
            Me.lblMasterItem = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.pnlPallet.SuspendLayout()
            CType(Me.tdgPallet, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'chkPrinLabel
            '
            Me.chkPrinLabel.ForeColor = System.Drawing.Color.Black
            Me.chkPrinLabel.Location = New System.Drawing.Point(432, 336)
            Me.chkPrinLabel.Name = "chkPrinLabel"
            Me.chkPrinLabel.Size = New System.Drawing.Size(160, 16)
            Me.chkPrinLabel.TabIndex = 216
            Me.chkPrinLabel.Text = "Print Pallet Label"
            '
            'lblWorkStation
            '
            Me.lblWorkStation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWorkStation.ForeColor = System.Drawing.Color.Navy
            Me.lblWorkStation.Location = New System.Drawing.Point(104, 8)
            Me.lblWorkStation.Name = "lblWorkStation"
            Me.lblWorkStation.Size = New System.Drawing.Size(216, 24)
            Me.lblWorkStation.TabIndex = 215
            Me.lblWorkStation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label9
            '
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.Navy
            Me.Label9.Location = New System.Drawing.Point(8, 8)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(96, 24)
            Me.Label9.TabIndex = 214
            Me.Label9.Text = "Workstation:"
            Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnRemoveAll
            '
            Me.btnRemoveAll.BackColor = System.Drawing.Color.DarkGray
            Me.btnRemoveAll.ForeColor = System.Drawing.Color.Black
            Me.btnRemoveAll.Location = New System.Drawing.Point(432, 168)
            Me.btnRemoveAll.Name = "btnRemoveAll"
            Me.btnRemoveAll.Size = New System.Drawing.Size(176, 40)
            Me.btnRemoveAll.TabIndex = 213
            Me.btnRemoveAll.Text = "Remove All Cartons"
            '
            'btnReprintLabel
            '
            Me.btnReprintLabel.BackColor = System.Drawing.Color.DarkGray
            Me.btnReprintLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprintLabel.ForeColor = System.Drawing.Color.RoyalBlue
            Me.btnReprintLabel.Location = New System.Drawing.Point(432, 224)
            Me.btnReprintLabel.Name = "btnReprintLabel"
            Me.btnReprintLabel.Size = New System.Drawing.Size(176, 40)
            Me.btnReprintLabel.TabIndex = 212
            Me.btnReprintLabel.Text = "Reprint Pallet Label"
            '
            'btnRemoveOne
            '
            Me.btnRemoveOne.BackColor = System.Drawing.Color.DarkGray
            Me.btnRemoveOne.ForeColor = System.Drawing.Color.Black
            Me.btnRemoveOne.Location = New System.Drawing.Point(432, 120)
            Me.btnRemoveOne.Name = "btnRemoveOne"
            Me.btnRemoveOne.Size = New System.Drawing.Size(176, 40)
            Me.btnRemoveOne.TabIndex = 211
            Me.btnRemoveOne.Text = "Remove One Carton"
            '
            'pnlPallet
            '
            Me.pnlPallet.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblMasterItem, Me.Label1, Me.lblQty, Me.txtQty, Me.lblPallet, Me.txtPalletName})
            Me.pnlPallet.Location = New System.Drawing.Point(8, 40)
            Me.pnlPallet.Name = "pnlPallet"
            Me.pnlPallet.Size = New System.Drawing.Size(592, 72)
            Me.pnlPallet.TabIndex = 210
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
            Me.txtQty.Location = New System.Drawing.Point(488, 8)
            Me.txtQty.Name = "txtQty"
            Me.txtQty.Size = New System.Drawing.Size(68, 33)
            Me.txtQty.TabIndex = 197
            Me.txtQty.Text = ""
            '
            'lblPallet
            '
            Me.lblPallet.BackColor = System.Drawing.Color.Transparent
            Me.lblPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPallet.ForeColor = System.Drawing.Color.Navy
            Me.lblPallet.Location = New System.Drawing.Point(24, 16)
            Me.lblPallet.Name = "lblPallet"
            Me.lblPallet.Size = New System.Drawing.Size(104, 21)
            Me.lblPallet.TabIndex = 194
            Me.lblPallet.Text = "Pallet Name:"
            Me.lblPallet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtPalletName
            '
            Me.txtPalletName.BackColor = System.Drawing.Color.White
            Me.txtPalletName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPalletName.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPalletName.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtPalletName.Location = New System.Drawing.Point(128, 16)
            Me.txtPalletName.Name = "txtPalletName"
            Me.txtPalletName.Size = New System.Drawing.Size(272, 23)
            Me.txtPalletName.TabIndex = 193
            Me.txtPalletName.Text = ""
            '
            'btnComplete
            '
            Me.btnComplete.BackColor = System.Drawing.Color.DarkGray
            Me.btnComplete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnComplete.ForeColor = System.Drawing.Color.DarkBlue
            Me.btnComplete.Location = New System.Drawing.Point(432, 272)
            Me.btnComplete.Name = "btnComplete"
            Me.btnComplete.Size = New System.Drawing.Size(176, 56)
            Me.btnComplete.TabIndex = 209
            Me.btnComplete.Text = "Complete Pallet"
            '
            'tdgPallet
            '
            Me.tdgPallet.AllowColMove = False
            Me.tdgPallet.AllowColSelect = False
            Me.tdgPallet.AllowFilter = False
            Me.tdgPallet.AllowSort = False
            Me.tdgPallet.AllowUpdate = False
            Me.tdgPallet.BackColor = System.Drawing.Color.White
            Me.tdgPallet.CaptionHeight = 17
            Me.tdgPallet.ColumnHeaders = False
            Me.tdgPallet.FetchRowStyles = True
            Me.tdgPallet.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgPallet.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgPallet.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.tdgPallet.Location = New System.Drawing.Point(136, 144)
            Me.tdgPallet.Name = "tdgPallet"
            Me.tdgPallet.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgPallet.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgPallet.PreviewInfo.ZoomFactor = 75
            Me.tdgPallet.RecordSelectors = False
            Me.tdgPallet.RowHeight = 15
            Me.tdgPallet.Size = New System.Drawing.Size(272, 456)
            Me.tdgPallet.TabIndex = 208
            Me.tdgPallet.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Style9{}Normal{Font:Tahoma, 8.25pt;}HighlightRow{ForeColo" & _
            "r:HighlightText;BackColor:Highlight;}Style12{}OddRow{}RecordSelector{AlignImage:" & _
            "Center;}Style13{}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;Fo" & _
            "reColor:ControlText;BackColor:Control;}Style8{}Style10{AlignHorz:Near;}Style11{}" & _
            "Style14{}Style15{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView" & _
            " AllowColMove=""False"" AllowColSelect=""False"" Name="""" CaptionHeight=""17"" ColumnCa" & _
            "ptionHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyles=""True"" MarqueeStyle=""Dot" & _
            "tedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" RecordSelectors=""Fal" & _
            "se"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>452</Height><Capti" & _
            "onStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" " & _
            "/><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar" & _
            """ me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""" & _
            "Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRow" & _
            "Style parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""S" & _
            "tyle4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=" & _
            """RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><" & _
            "Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 268, 452</ClientRect><Bord" & _
            "erSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.Merg" & _
            "eView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal" & _
            """ me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" m" & _
            "e=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=" & _
            """Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""Hig" & _
            "hlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""Od" & _
            "dRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=" & _
            """FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</" & _
            "vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17" & _
            "</DefaultRecSelWidth><ClientArea>0, 0, 268, 452</ClientArea><PrintPageHeaderStyl" & _
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
            Me.Label3.TabIndex = 207
            Me.Label3.Text = "Master Carton No:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCartonNo
            '
            Me.txtCartonNo.BackColor = System.Drawing.Color.White
            Me.txtCartonNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtCartonNo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtCartonNo.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtCartonNo.Location = New System.Drawing.Point(136, 120)
            Me.txtCartonNo.Name = "txtCartonNo"
            Me.txtCartonNo.Size = New System.Drawing.Size(272, 23)
            Me.txtCartonNo.TabIndex = 0
            Me.txtCartonNo.Text = ""
            '
            'lblMasterItem
            '
            Me.lblMasterItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblMasterItem.Location = New System.Drawing.Point(128, 40)
            Me.lblMasterItem.Name = "lblMasterItem"
            Me.lblMasterItem.Size = New System.Drawing.Size(296, 24)
            Me.lblMasterItem.TabIndex = 205
            Me.lblMasterItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Navy
            Me.Label1.Location = New System.Drawing.Point(16, 40)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(112, 24)
            Me.Label1.TabIndex = 204
            Me.Label1.Text = "Item:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'frmTFFK_BYOP_Kitting_Pallet
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.LightGray
            Me.ClientSize = New System.Drawing.Size(808, 654)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkPrinLabel, Me.lblWorkStation, Me.Label9, Me.btnRemoveAll, Me.btnReprintLabel, Me.btnRemoveOne, Me.pnlPallet, Me.btnComplete, Me.tdgPallet, Me.Label3, Me.txtCartonNo})
            Me.Name = "frmTFFK_BYOP_Kitting_Pallet"
            Me.Text = "frmTFFK_BYOP_Kitting_Pallet"
            Me.pnlPallet.ResumeLayout(False)
            CType(Me.tdgPallet, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmTFFK_BYOP_Kitting_Pallet_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                PSS.Core.Highlight.SetHighLight(Me)
                Me.chkPrinLabel.Checked = True

                If Me._strComputerName.Trim.Length = 0 Then
                    MessageBox.Show("No computer name (workstation). See IT", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                Me.lblWorkStation.Text = Me._strComputerName
                Me.txtQty.Text = 0
                Me.txtPalletName.Text = ""
                Me.txtPalletName.ReadOnly = True : Me.txtPalletName.BackColor = System.Drawing.Color.Cornsilk
                Me.txtQty.ReadOnly = True : Me.txtQty.BackColor = System.Drawing.Color.Cornsilk
                Me.pnlPallet.Visible = False

                Me.ActiveControl = Me.txtCartonNo
                Me.txtCartonNo.Text = "" : Me.txtCartonNo.SelectAll() : Me.txtCartonNo.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub frmTFFK_BYOP_Kitting_Pallet_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub txtCartonNo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCartonNo.KeyUp
            Try
                If e.KeyCode = Keys.Enter AndAlso Me.txtCartonNo.Text.Trim.Length > 0 Then
                    Me.ProcessSN()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtCartonNo_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub ProcessSN()
            Dim strCartonName As String = ""
            Dim strPalletName As String = ""

            Dim dt As DataTable
            Dim row As DataRow
            Dim iIdx As Integer = 0

            Try
                'Get  data
                strCartonName = Me.txtCartonNo.Text.Trim
                If strCartonName.Trim.Length = 0 Then
                    MessageBox.Show("Please enter carton name (carton tag).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtCartonNo.SelectAll() : Me.txtCartonNo.Focus()
                    Exit Sub
                ElseIf Me._objBYOP_Kitting.IsCartonBuiltInPallet(strCartonName) Then
                    MessageBox.Show("This carton '" & strCartonName & "' already in a pallet. Can't add.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtCartonNo.SelectAll() : Me.txtCartonNo.Focus()
                    Exit Sub
                ElseIf Convert.ToInt32(Me.txtQty.Text) >= Me._objTFFK._iMaxCartonQtyPerPallet Then
                    MessageBox.Show("The pallet is fulfilled (maximum qty of per pallet is " & Me._objTFFK._iMaxCartonQtyPerPallet.ToString & "). " & Environment.NewLine & "Ready to complete the pallet now.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtCartonNo.SelectAll() : Me.txtCartonNo.Focus()
                    Exit Sub
                End If

                dt = Me._objBYOP_Kitting.getPalletAvailableCartonData(strCartonName)
                If Me._iPallet_ID = 0 Then Me._dtPallet = dt.Clone

                If dt.Rows.Count > 1 Then
                    MessageBox.Show("Duplicate carton name '" & strCartonName & "'. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtCartonNo.SelectAll() : Me.txtCartonNo.Focus() : Exit Sub
                ElseIf dt.Rows.Count = 0 Then
                    MessageBox.Show("Can't find this carton '" & strCartonName & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtCartonNo.SelectAll() : Me.txtCartonNo.Focus() : Exit Sub
                ElseIf Me._dtPallet.Rows.Count > 0 Then
                    For Each row In Me._dtPallet.Rows
                        If Convert.ToString(row("Carton_Name")).Trim.ToUpper = strCartonName.Trim.ToUpper Then
                            MessageBox.Show("Carton '" & strCartonName & "' already in the list. Can't add it again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.txtCartonNo.SelectAll() : Me.txtCartonNo.Focus() : Exit Sub
                        End If
                    Next
                End If

                'Ready: dt.Rows.Count=1
                If Me._iPallet_ID = 0 Then 'create pallet name at the first carton
                    strPalletName = Me._objBYOP_Kitting.CreatePalletName(Me._strComputerName, Me._iPallet_ID)
                    Me.lblMasterItem.Text = Convert.ToString(dt.Rows(0).Item("Master_Item"))
                    Me.txtPalletName.Text = strPalletName
                    If Not Me._iPallet_ID > 0 Then
                        MessageBox.Show("Failed to create pallet name. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txtCartonNo.SelectAll() : Me.txtCartonNo.Focus() : Exit Sub
                    End If
                    Me.pnlPallet.Visible = True
                End If

                'Ready
                For Each row In dt.Rows 'must be 1 row 
                    iIdx = Me._dtPallet.Rows.Count + 1
                    row.BeginEdit() : row("Row") = iIdx : row.AcceptChanges()
                    Me._dtPallet.ImportRow(row)
                Next

                Me.BindCartonData(Me._dtPallet)

                Me.txtCartonNo.Text = "" : Me.txtCartonNo.SelectAll() : Me.txtCartonNo.Focus()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, " ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                dt = Nothing
            End Try
        End Sub

        Private Sub BindCartonData(ByVal dt As DataTable)
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
            Dim i As Integer = 0
            Dim iKeySIM As Integer = 0

            Try
                If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                    With Me.tdgPallet
                        .DataSource = dt.DefaultView
                        For Each dbgc In .Splits(0).DisplayColumns
                            dbgc.Locked = True
                            Select Case dbgc.Name
                                Case "Row", "Carton_Name", "ItemQty"
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

                Me.txtQty.Text = Me._dtPallet.Rows.Count.ToString

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "BindSNsData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnRemoveOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveOne.Click
            Dim strCartonNo As String = ""
            Dim row As DataRow
            Dim dtTmp As DataTable
            Dim bFound As Boolean = False
            Dim i As Integer = 0

            Try
                If IsNothing(Me._dtPallet) Then Exit Sub

                strCartonNo = InputBox("Enter carton name (carton tag):", "Enter carton name", "")

                If strCartonNo.Trim.Length > 0 Then
                    If Me._dtPallet.Rows.Count = 1 AndAlso strCartonNo.Trim.ToUpper = Convert.ToString(Me._dtPallet.Rows(0).Item("Carton_Name")).ToUpper Then
                        If strCartonNo.Trim.ToUpper = Convert.ToString(Me._dtPallet.Rows(0).Item("Carton_Name")).ToUpper Then
                            Me._dtPallet.Clear()
                            Me.txtQty.Text = 0 : Me.tdgPallet.DataSource = Nothing
                        Else
                            MessageBox.Show("Carton '" & strCartonNo & "' not in the list.")
                        End If
                    Else
                        dtTmp = Me._dtPallet.Clone
                        For Each row In Me._dtPallet.Rows
                            If strCartonNo.Trim.ToUpper = Convert.ToString(row("Carton_Name")).ToUpper Then
                                bFound = True
                            Else
                                i += 1
                                row.BeginEdit() : row("Row") = i : row.AcceptChanges()
                                dtTmp.ImportRow(row)
                            End If
                        Next
                        If bFound Then
                            Me._dtPallet = dtTmp.Copy
                            Me.BindCartonData(Me._dtPallet)
                        Else
                            MessageBox.Show("Carton '" & strCartonNo & "' not in the list.")
                        End If
                    End If
                Else
                    MessageBox.Show("You must enter an item SN.")
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRemoveOne_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.txtCartonNo.Text = "" : Me.txtCartonNo.SelectAll() : Me.txtCartonNo.Focus()
            End Try
        End Sub

        Private Sub RemoveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveAll.Click
            Try
                If IsNothing(Me._dtPallet) Then Exit Sub

                Dim result As Integer = MessageBox.Show("Do you want to remove all cartons from the list?", "Select Y/N", MessageBoxButtons.YesNo)
                If result = DialogResult.Yes Then
                    Me._dtPallet.Clear()
                    Me.txtQty.Text = 0 : Me.tdgPallet.DataSource = Nothing
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRemoveAll_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.txtCartonNo.Text = "" : Me.txtCartonNo.SelectAll() : Me.txtCartonNo.Focus()
            End Try
        End Sub

        Private Sub btnComplete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnComplete.Click
            Dim strCarton_IDs As String = ""
            Dim row As DataRow
            Dim i As Integer = 0
            Dim strPrinterName As String = ""
            Dim strPalletName As String = ""
            Dim strPalletNameCode As String = ""
            Dim iQty As Integer = 0
            Dim strQtyCode As String = ""
            Dim strMasterItem As String = ""
            Dim strMasterItemCode As String = ""

            Try
                If IsNothing(Me._dtPallet) OrElse Not Me._dtPallet.Rows.Count > 0 Then
                    MessageBox.Show("No pallet data yet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtCartonNo.SelectAll() : Me.txtCartonNo.Focus() : Exit Sub
                End If

                If Convert.ToInt32(Me.txtQty.Text) > Me._objTFFK._iMaxCartonQtyPerPallet Then
                    MessageBox.Show("qty of cartons in this pallet is greater than maximum qty per pallet(" & Me._objTFFK._iMaxCartonQtyPerPallet.ToString & ").", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtCartonNo.SelectAll() : Me.txtCartonNo.Focus() : Exit Sub
                End If
                If Not Me._dtPallet.Rows.Count = Convert.ToInt32(Me.txtQty.Text) Then
                    MessageBox.Show("The pallet rows don't match the qty. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtCartonNo.SelectAll() : Me.txtCartonNo.Focus() : Exit Sub
                End If
                If Not Me._iPallet_ID > 0 Then
                    MessageBox.Show("No Pallet_ID. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtCartonNo.SelectAll() : Me.txtCartonNo.Focus() : Exit Sub
                End If
                If Me._objBYOP_Kitting.IsPalletClosed(Me._iPallet_ID) Then
                    MessageBox.Show("The pallet (lot no) " & Me.txtPalletName.Text & " is closed or can't find it. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtCartonNo.SelectAll() : Me.txtCartonNo.Focus() : Exit Sub
                End If

                'ready 
                For Each row In Me._dtPallet.Rows
                    If strCarton_IDs.Trim.Length = 0 Then
                        strCarton_IDs = Convert.ToString(row("Carton_ID"))
                    Else
                        strCarton_IDs &= "," & Convert.ToString(row("Carton_ID"))
                    End If
                Next

                'save data
                i = Me._objBYOP_Kitting.SavePalletData(Me._iPallet_ID, Convert.ToInt32(Me.txtQty.Text), Convert.ToInt32(Me._dtPallet.Rows(0).Item("Model_ID")), 1, Me._UserID, strCarton_IDs)

                If i = 0 Then
                    MessageBox.Show("Failed to save. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtCartonNo.SelectAll() : Me.txtCartonNo.Focus() : Exit Sub
                End If

                'print pallet label
                If Me.chkPrinLabel.Checked Then
                    Dim FontEncoder As New IDAutomation.NetAssembly.FontEncoder()

                    strPrinterName = Me._objBYOP_Kitting.getTFFK_LabelPrinterName(Me._objTFFK.ProcessTypeIDs.Standard_Kitting, Me._strComputerName, Me._objTFFK.StandardKittingLabels.Pallet_Label)
                    strPalletName = Me.txtPalletName.Text.Trim : strPalletNameCode = FontEncoder.Code128a(strPalletName)
                    iQty = Convert.ToInt32(Me.txtQty.Text) : strQtyCode = FontEncoder.Code128a(iQty.ToString)
                    strMasterItem = Me.lblMasterItem.Text : strMasterItemCode = FontEncoder.Code128a(strMasterItem)
                    FontEncoder = Nothing
                    Me._objBYOP_Kitting.PrintPallet_Label(strPalletName, strPalletNameCode, iQty, strQtyCode, strMasterItem, strMasterItemCode, Format(Now, "dd/MM/yyyy"), strPrinterName, 1)
                End If

                'clear/reset for a new pallet
                Me._dtPallet = Nothing : Me._iPallet_ID = 0 : Me.txtPalletName.Text = "" : Me.lblMasterItem.Text = "" : txtQty.Text = 0
                Me.pnlPallet.Visible = False
                Me.tdgPallet.DataSource = Nothing
                Me.txtCartonNo.Text = "" : Me.txtCartonNo.SelectAll() : Me.txtCartonNo.Focus()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub btnComplete_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnReprintLabel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReprintLabel.Click
            Dim dt As DataTable
            Dim strPalletName As String = ""
            Dim strPrinterName As String = ""
            Dim strDatePallet As String = ""
            Dim strPalletNameCode As String = ""
            Dim iQty As Integer = 0
            Dim strQtyCode As String = ""
            Dim strMasterItem As String = ""
            Dim strMasterItemCode As String = ""

            'Pallet_ID, Pallet_Name, Carton_Qty, Model_ID, Closed, UserID, DateTime_Pallet, WorkStation, Master_Item, Cumputed_Carton_Qty, DateTime_Pallet, Pallet_Date

            Try
                strPalletName = InputBox("Enter pallet name (Lot No):", "Enter pallet", "")

                If strPalletName.Trim.Length = 0 Then
                    MessageBox.Show("You must enter a pallet name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                dt = Me._objBYOP_Kitting.getPalletLabelData(strPalletName)
                If Not dt.Rows.Count > 0 Then
                    MessageBox.Show("No data for this pallet '" & strPalletName & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                ElseIf dt.Rows.Count > 1 Then
                    MessageBox.Show("Duplicate pallet name '" & strPalletName & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                ElseIf Not Convert.ToInt32(dt.Rows(0).Item("Carton_Qty")) = Convert.ToInt32(dt.Rows(0).Item("Cumputed_Carton_Qty")) Then
                    MessageBox.Show("Invalid carton qty (miss match) in the pallet '" & strPalletName & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                Dim FontEncoder As New IDAutomation.NetAssembly.FontEncoder()

                strPrinterName = Me._objBYOP_Kitting.getTFFK_LabelPrinterName(Me._objTFFK.ProcessTypeIDs.Standard_Kitting, Me._strComputerName, Me._objTFFK.StandardKittingLabels.Pallet_Label)
                strPalletName = Convert.ToString(dt.Rows(0).Item("Pallet_Name")).Trim : strPalletNameCode = FontEncoder.Code128a(strPalletName)
                iQty = Convert.ToInt32(dt.Rows(0).Item("Carton_Qty")) : strQtyCode = FontEncoder.Code128a(iQty.ToString)
                strMasterItem = Convert.ToString(dt.Rows(0).Item("Master_Item")) : strMasterItemCode = FontEncoder.Code128a(strMasterItem)
                FontEncoder = Nothing
                strDatePallet = Convert.ToString(dt.Rows(0).Item("Pallet_Date"))

                Me._objBYOP_Kitting.PrintPallet_Label(strPalletName, strPalletNameCode, iQty, strQtyCode, strMasterItem, strMasterItemCode, strDatePallet, strPrinterName, 1)

                dt = Nothing

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub btnReprintLabel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

    End Class
End Namespace