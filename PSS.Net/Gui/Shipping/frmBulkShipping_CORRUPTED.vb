Imports System.IO
Public Class frmBulkShipping
    Inherits System.Windows.Forms.Form
    Private objBulkShip As PSS.Data.Buisness.BulkShipping
    Private objMisc As PSS.Data.Buisness.Misc

    'Private iCust_ID As Integer = 0
    Private iLoc_ID As Integer = 0
    'Private strShipType As String = ""
    Private iShipType As Integer = 0
    Private strSKULength As String = ""
    Private iModel_ID As Integer = 0
    Private iFileCheckDone As Integer = 0
    Private strWorkDate As String = PSS.Core.Global.ApplicationUser.Workdate
    Private strUser As String = PSS.Core.Global.ApplicationUser.User
    Private iShiftID As Integer = PSS.Core.Global.ApplicationUser.IDShift
    'Private booVerifyShipped As Boolean = False
    Private iPallett_ID As Integer = 0
    Private strPalletName As String = ""

    Private strFilePath As String = ""
    Private strATCLEFilePath As String = "P:\Dept\ATCLE\Palet packing list\"
    Private strCellStarFilePath As String = "P:\Dept\Cellstar\Pallet packing list\"
    Private strGameStopFilePath As String = "P:\Dept\Game stop\Pallet packing list\"


    'Private radioButtons(2) As RadioButton
    Private iHoldStatus As Integer = 0
    Private iFlg As Integer = 0
    Private iGroup_ID As Integer = 0
    Private iCust_ID As Integer = 0


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        objBulkShip = New PSS.Data.Buisness.BulkShipping()
        objMisc = New PSS.Data.Buisness.Misc()
        'radioButtons(0) = Me.RadioRegular
        'radioButtons(1) = Me.RadioShipAndHold
        'radioButtons(2) = Me.RadioRemoveFromHold

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
    Friend WithEvents lstRegular As System.Windows.Forms.ListBox
    Friend WithEvents lstRUR As System.Windows.Forms.ListBox
    Friend WithEvents lstRTM As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdShip As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblCnt As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lstWrongModel As System.Windows.Forms.ListBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lstRURRTMParts As System.Windows.Forms.ListBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lstWrongSKULength As System.Windows.Forms.ListBox
    Friend WithEvents cmdFileCheck As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lstDetail As System.Windows.Forms.ListBox
    Friend WithEvents chkNoReprot As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents grdPallets As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblPallet As System.Windows.Forms.Label
    Friend WithEvents cmdRemoveFromHold As System.Windows.Forms.Button
    Friend WithEvents RadioRemoveFromHold As System.Windows.Forms.RadioButton
    Friend WithEvents RadioShipAndHold As System.Windows.Forms.RadioButton
    Friend WithEvents RadioRegular As System.Windows.Forms.RadioButton
    Friend WithEvents lblGridCaption As System.Windows.Forms.Label
    Friend WithEvents PanelList As System.Windows.Forms.Panel
    Friend WithEvents cmdReprintPalletLabel As System.Windows.Forms.Button
    Friend WithEvents cmdReprintManifest As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmBulkShipping))
        Me.lstRegular = New System.Windows.Forms.ListBox()
        Me.lstRUR = New System.Windows.Forms.ListBox()
        Me.lstRTM = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbl = New System.Windows.Forms.Label()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.cmdShip = New System.Windows.Forms.Button()
        Me.lblCnt = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioRemoveFromHold = New System.Windows.Forms.RadioButton()
        Me.RadioShipAndHold = New System.Windows.Forms.RadioButton()
        Me.RadioRegular = New System.Windows.Forms.RadioButton()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lstWrongModel = New System.Windows.Forms.ListBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lstRURRTMParts = New System.Windows.Forms.ListBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lstWrongSKULength = New System.Windows.Forms.ListBox()
        Me.cmdFileCheck = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lstDetail = New System.Windows.Forms.ListBox()
        Me.chkNoReprot = New System.Windows.Forms.CheckBox()
        Me.grdPallets = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.lblGridCaption = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblPallet = New System.Windows.Forms.Label()
        Me.cmdRemoveFromHold = New System.Windows.Forms.Button()
        Me.PanelList = New System.Windows.Forms.Panel()
        Me.cmdReprintPalletLabel = New System.Windows.Forms.Button()
        Me.cmdReprintManifest = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.grdPallets, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lstRegular
        '
        Me.lstRegular.Name = "lstRegular"
        Me.lstRegular.TabIndex = 0
        '
        'lstRUR
        '
        Me.lstRUR.Name = "lstRUR"
        Me.lstRUR.TabIndex = 0
        '
        'lstRTM
        '
        Me.lstRTM.Name = "lstRTM"
        Me.lstRTM.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Name = "Label1"
        Me.Label1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Name = "Label2"
        Me.Label2.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.Name = "Label3"
        Me.Label3.TabIndex = 0
        '
        'lbl
        '
        Me.lbl.BackColor = System.Drawing.Color.Black
        Me.lbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.Yellow
        Me.lbl.Location = New System.Drawing.Point(1, 1)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(327, 56)
        Me.lbl.TabIndex = 7
        Me.lbl.Text = "SHIP PALLETS"
        Me.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdClear
        '
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.TabIndex = 0
        '
        'cmdShip
        '
        Me.cmdShip.Name = "cmdShip"
        Me.cmdShip.TabIndex = 0
        '
        'lblCnt
        '
        Me.lblCnt.Name = "lblCnt"
        Me.lblCnt.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.Name = "Label6"
        Me.Label6.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'RadioRemoveFromHold
        '
        Me.RadioRemoveFromHold.Name = "RadioRemoveFromHold"
        Me.RadioRemoveFromHold.TabIndex = 0
        '
        'RadioShipAndHold
        '
        Me.RadioShipAndHold.Name = "RadioShipAndHold"
        Me.RadioShipAndHold.TabIndex = 0
        '
        'RadioRegular
        '
        Me.RadioRegular.Name = "RadioRegular"
        Me.RadioRegular.TabIndex = 0
        '
        'Label11
        '
        Me.Label11.Name = "Label11"
        Me.Label11.TabIndex = 0
        '
        'lstWrongModel
        '
        Me.lstWrongModel.Name = "lstWrongModel"
        Me.lstWrongModel.TabIndex = 0
        '
        'Label12
        '
        Me.Label12.Name = "Label12"
        Me.Label12.TabIndex = 0
        '
        'lstRURRTMParts
        '
        Me.lstRURRTMParts.Name = "lstRURRTMParts"
        Me.lstRURRTMParts.TabIndex = 0
        '
        'Label13
        '
        Me.Label13.Name = "Label13"
        Me.Label13.TabIndex = 0
        '
        'lstWrongSKULength
        '
        Me.lstWrongSKULength.Name = "lstWrongSKULength"
        Me.lstWrongSKULength.TabIndex = 0
        '
        'cmdFileCheck
        '
        Me.cmdFileCheck.Name = "cmdFileCheck"
        Me.cmdFileCheck.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.Name = "Label9"
        Me.Label9.TabIndex = 0
        '
        'lstDetail
        '
        Me.lstDetail.Name = "lstDetail"
        Me.lstDetail.TabIndex = 0
        '
        'chkNoReprot
        '
        Me.chkNoReprot.Name = "chkNoReprot"
        Me.chkNoReprot.TabIndex = 0
        '
        'grdPallets
        '
        Me.grdPallets.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdPallets.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.grdPallets.Name = "grdPallets"
        Me.grdPallets.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdPallets.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdPallets.PreviewInfo.ZoomFactor = 75
        Me.grdPallets.TabIndex = 0
        Me.grdPallets.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
        "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
        "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
        "er;}Style14{}Normal{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}S" & _
        "tyle9{}OddRow{}RecordSelector{AlignImage:Center;}Style15{}Heading{Wrap:True;Alig" & _
        "nVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}" & _
        "Style8{}Style10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style1{}</Data></Styl" & _
        "es><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" CaptionHeight=""17"" ColumnCapti" & _
        "onHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSele" & _
        "ctorWidth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup" & _
        "=""1""><Height>0</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle" & _
        " parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><Fil" & _
        "terBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""S" & _
        "tyle3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading" & _
        """ me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><Inactive" & _
        "Style parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /" & _
        "><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle pare" & _
        "nt=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, " & _
        "0, 0, 0</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle><" & _
        "/C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal" & _
        """ /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" />" & _
        "<Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><" & _
        "Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Styl" & _
        "e parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Sty" & _
        "le parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><" & _
        "Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></Na" & _
        "medStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layo" & _
        "ut><DefaultRecSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 0, 0</ClientArea" & _
        "><PrintPageHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" " & _
        "me=""Style15"" /></Blob>"
        '
        'lblGridCaption
        '
        Me.lblGridCaption.Name = "lblGridCaption"
        Me.lblGridCaption.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'Button1
        '
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 0
        '
        'lblPallet
        '
        Me.lblPallet.Name = "lblPallet"
        Me.lblPallet.TabIndex = 0
        '
        'cmdRemoveFromHold
        '
        Me.cmdRemoveFromHold.Name = "cmdRemoveFromHold"
        Me.cmdRemoveFromHold.TabIndex = 0
        '
        'PanelList
        '
        Me.PanelList.Name = "PanelList"
        Me.PanelList.TabIndex = 0
        '
        'cmdReprintPalletLabel
        '
        Me.cmdReprintPalletLabel.Name = "cmdReprintPalletLabel"
        Me.cmdReprintPalletLabel.TabIndex = 0
        '
        'cmdReprintManifest
        '
        Me.cmdReprintManifest.Name = "cmdReprintManifest"
        Me.cmdReprintManifest.TabIndex = 0
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(192, 152)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 24)
        Me.Button2.TabIndex = 0
        Me.Button2.Text = "Button2"
        '
        'frmBulkShipping
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button2})
        Me.Name = "frmBulkShipping"
        CType(Me.grdPallets, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    'Private Sub radioOptionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioRegular.CheckedChanged, RadioRemoveFromHold.CheckedChanged, RadioShipAndHold.CheckedChanged

    '    Dim Found As Boolean = False
    '    Dim i As Integer = 0

    '    While i < radioButtons.GetLength(0) And Not Found
    '        If radioButtons(i).Checked Then
    '            Found = True
    '            iHoldStatus = i

    '            If iHoldStatus = 0 Then
    '                Me.lblGridCaption.Text = "Pallets to be Shipped:"
    '                Me.cmdRemoveFromHold.Visible = False
    '            ElseIf iHoldStatus = 1 Then
    '                Me.lblGridCaption.Text = "Pallets to be Shipped:"
    '                Me.cmdRemoveFromHold.Visible = False
    '            ElseIf iHoldStatus = 2 Then
    '                Me.lblGridCaption.Text = "Pallets Shipped but on Hold:"
    '                Me.cmdRemoveFromHold.Visible = True
    '            End If
    '            LoadPallets()
    '        End If
    '        i += 1
    '    End While


    'End Sub

    Private Sub ClearListControls()
        Me.lstRegular.Items.Clear()
        Me.lstRTM.Items.Clear()
        Me.lstRUR.Items.Clear()
        Me.lstRURRTMParts.Items.Clear()
        Me.lstWrongModel.Items.Clear()
        Me.lstWrongSKULength.Items.Clear()
        Me.lstDetail.Items.Clear()
        Me.lblCnt.Text = ""
        Me.lblPallet.Text = ""
    End Sub

    'Private Sub cmdSelectFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectFile.Click
    '    Dim iExcelNum As Integer = 0
    '    Dim iPSSNum As Integer = 0
    '    Dim R1 As DataRow
    '    Dim i As Integer = 0


    '    Try
    '        Me.cmdShip.Enabled = False
    '        Cursor.Current = Cursors.WaitCursor

    '        Me.BackColor = System.Drawing.Color.SteelBlue
    '        System.Windows.Forms.Application.DoEvents()

    '        RequiredDataValidation()
    '        ClearListControls()

    '        Me.OpenFileDialog1.ShowDialog()

    '        If Len(Trim(Me.OpenFileDialog1.FileName)) > 0 Then
    '            If LCase(Microsoft.VisualBasic.Right(Trim(Me.OpenFileDialog1.FileName), 3)) <> "xls" Then
    '                MsgBox("Please select an excel file for validation.")
    '            Else
    '                '************************************************
    '                Me.lblFileName.Text = NameOnlyFromFullPath(Me.OpenFileDialog1.FileName)
    '                '************************************************
    '                'Get pallett_id
    '                iPallett_ID = objBulkShip.GetPallettID(Trim(Me.lblFileName.Text))
    '                '************************************************
    '                'Initialise Variables
    '                iCust_ID = Me.cmbCustomer.SelectedValue
    '                iLoc_ID = Me.cmbLocation.SelectedValue
    '                iModel_ID = Me.cmbModel.SelectedValue
    '                strShipType = Me.cmbShipType.SelectedItem
    '                strSKULength = Me.cmbSkuLength.SelectedItem
    '                booVerifyShipped = Me.chkVerifyShipped.Checked
    '                '*********************
    '                'objBulkShip variables
    '                Me.objBulkShip.iLoc_ID = iLoc_ID
    '                Me.objBulkShip.strWorkDt = strWorkDate
    '                Me.objBulkShip.iShiftID = iShiftID
    '                Me.objBulkShip.struser = strUser
    '                Me.objBulkShip.iBulkShipped = 1     'A flag in tpallett table to show it was Bulk Shipped
    '                Select Case strShipType
    '                    Case "REGULAR"
    '                        Me.objBulkShip.iShipType = 0
    '                    Case "RUR"
    '                        Me.objBulkShip.iShipType = 1
    '                    Case "RTM"
    '                        Me.objBulkShip.iShipType = 9
    '                End Select
    '                '*********************
    '                iFileCheckDone = 0
    '                '************************************************
    '                'Step 1 :: Extract IMEI numbers from the excel file
    '                '************************************************
    '                Me.objBulkShip.strFilePath = Me.OpenFileDialog1.FileName
    '                iExcelNum = objBulkShip.ExtractSNs(booVerifyShipped)
    '                If iExcelNum > 0 Then

    '                    '#############################################################
    '                    ''' STEP2 ::
    '                    '''Obtain and set validation data.
    '                    ''' Broken down in to pieces as far as getting data is concerned 
    '                    ''' because not all customers need all these validations.
    '                    ''' This will be easier to brach out the code.
    '                    '#############################################################

    '                    '***********************************************************
    '                    '(A) :: Get Model
    '                    '***********************************************************
    '                    iPSSNum = objBulkShip.GetModel(booVerifyShipped)
    '                    If iPSSNum <> iPSSNum Then
    '                        Throw New Exception("cmdSelectFile_Click.GetModel:: Records from excel file don't have same number of records from PSS Database.")
    '                    End If

    '                    '***********************************************************
    '                    '(B) :: Get the SKU Length
    '                    '***********************************************************
    '                    iPSSNum = objBulkShip.GetSKU(booVerifyShipped)
    '                    If iPSSNum <> iPSSNum Then
    '                        Throw New Exception("cmdSelectFile_Click.GetSKU:: Records from excel file don't have same number of records from PSS Database.")
    '                    End If

    '                    '***********************************************************
    '                    '(C) :: Get Billcoderule
    '                    '***********************************************************
    '                    iPSSNum = objBulkShip.GetBillcodeRule(booVerifyShipped)
    '                    If iExcelNum <> iPSSNum Then
    '                        Throw New Exception("cmdSelectFile_Click.GetBillcodeRule:: Records from excel file don't have same number of records from PSS Database.")
    '                    Else
    '                        Me.lblCnt.Text = iPSSNum
    '                    End If

    '                    '#############################################################
    '                    'Step 3::
    '                    'write data to controls based on the business logic
    '                    '#############################################################


    '                    '*******************************************************
    '                    For Each R1 In objBulkShip.dtExcelSNs.Rows

    '                        '*******************************************************
    '                        '(A) Model Validation (For all customers)
    '                        '*******************************************************
    '                        If R1("Model_ID") <> iModel_ID Then
    '                            Me.lstWrongModel.Items.Add(Trim(R1("IMEI")))
    '                        End If

    '                        '*******************************************************
    '                        'CHECK SKU LENGTHS ONLY FOR REGULAR PHONES NOT RUR AND RTM PHONES
    '                        '*******************************************************
    '                        'If iCust_ID = 2019 Then
    '                        If strShipType = "REGULAR" Then
    '                            If Len(R1("Sku_Number")) >= 1 And Len(R1("Sku_Number")) <= 5 Then
    '                                If UCase(strSKULength) <> "SHORT" Then
    '                                    Me.lstWrongSKULength.Items.Add(Trim(R1("IMEI")))
    '                                End If
    '                            ElseIf Len(R1("Sku_Number")) >= 6 And Len(R1("Sku_Number")) <= 15 Then
    '                                If UCase(strSKULength) <> "LONG" Then
    '                                    Me.lstWrongSKULength.Items.Add(Trim(R1("IMEI")))
    '                                End If
    '                            Else
    '                                Throw New Exception("SKU length out of bounds.")
    '                            End If
    '                        End If
    '                        'End If

    '                        '*******************************************************
    '                        '(C) BILLCODERULE validation    (For all customers)
    '                        '*******************************************************
    '                        If R1("Billcode_rule") = 9 Then     'RTM
    '                            Me.lstRTM.Items.Add(Trim(R1("IMEI")))
    '                        ElseIf R1("Billcode_rule") = 1 Then 'RUR
    '                            Me.lstRUR.Items.Add(Trim(R1("IMEI")))
    '                        ElseIf R1("Billcode_rule") = 0 Then 'Regular
    '                            Me.lstRegular.Items.Add(Trim(R1("IMEI")))
    '                        End If
    '                        '*******************************************************
    '                        'RUR/RTMs have parts
    '                        '*******************************************************
    '                        If R1("RURRTMHasParts") = "1" Then
    '                            Me.lstRURRTMParts.Items.Add(Trim(R1("IMEI")))
    '                        End If

    '                    Next R1
    '                    '#############################################################
    '                    'Do Validations
    '                    '*******************************************************
    '                    DoValidation()
    '                    '*******************************************************
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Ship Cell Pallets (Load File)", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
    '    Finally
    '        R1 = Nothing
    '        Me.cmdShip.Enabled = True
    '        Cursor.Current = Cursors.Default
    '    End Try


    'End Sub

    'Public Function NameOnlyFromFullPath(ByVal strFilePath As String) As String
    '    'EXAMPLE: input ="C:\winnt\system32\kernel.dll, 
    '    'output = kernel.dll
    '    Dim iPos As Integer
    '    Dim strFilename As String = ""

    '    If strFilePath <> "" Then
    '        ''output = kernel.dll
    '        iPos = strFilePath.LastIndexOfAny("\")
    '        iPos += 1
    '        strFilename = strFilePath.Substring(iPos, (Len(strFilePath) - iPos))

    '        ''output = kernel Without extension
    '        iPos = strFilename.LastIndexOfAny(".")
    '        Return strFilename.Substring(0, iPos)
    '    Else
    '        Return ""
    '    End If
    'End Function


    Protected Overrides Sub Finalize()
        objMisc = Nothing
        objBulkShip = Nothing
        MyBase.Finalize()
    End Sub

    Private Sub cmdShip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShip.Click
        Dim i As Integer = 0
        Try
            '*****************************************************
            'If booVerifyShipped = True Then
            '    Throw New Exception("This pallet has already been shipped.")
            'End If

            '*****************************************************
            DoValidation()
            '*****************************************************
            'Make sure a file has been selected and FILE CHECK done
            If iFileCheckDone = 0 Then
                Me.cmdShip.Enabled = False
                Throw New Exception("File check has not been done.")
            ElseIf iFileCheckDone = 1 Then
                Me.cmdShip.Enabled = False
                Me.BackColor = System.Drawing.Color.Red
                System.Windows.Forms.Application.DoEvents()
                Throw New Exception("Serial Number (IMEI) you have scanned in to do 'File Check' did not exist in the file.")
            End If
            '******************************************************
            'Bulk SHIP now.
            Me.cmdShip.Enabled = True
            i = objBulkShip.BulkShip(Me.chkNoReprot.Checked, iHoldStatus)
            '******************************************************
            iFileCheckDone = 0
            Me.cmdShip.Enabled = False
            'Me.PanelList.Visible = False
            Me.RadioRegular.Checked = True
            iHoldStatus = 0
            'iFlg = 0
            'Me.lblPallet.Text = ""
            'Me.lblCnt.Text = ""
            ClearControls()
            LoadPallets()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Ship Cell Pallets", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearControls()
    End Sub

    Private Sub ClearControls()

        iPallett_ID = 0
        iGroup_ID = 0
        strPalletName = ""
        iLoc_ID = 0
        iModel_ID = 0
        iShipType = 0
        strSKULength = ""
        iFlg = 0
        'iHoldStatus = 0

        'Me.RadioRegular.Checked = True
        Me.objBulkShip.iLoc_ID = 0
        'Me.objBulkShip.strWorkDt = ""
        'Me.objBulkShip.iShiftID = 0
        'Me.objBulkShip.struser = strUser
        'Me.objBulkShip.iBulkShipped = 1
        Me.objBulkShip.iShipType = 0
        Me.objBulkShip.strFilePath = ""
        Me.objBulkShip.iPallet_ID = 0
        Me.lblPallet.Text = ""
        Me.PanelList.Visible = False


        Me.lstRegular.Items.Clear()
        Me.lstDetail.Items.Clear()
        Me.lstRTM.Items.Clear()
        Me.lstRUR.Items.Clear()
        Me.lstRURRTMParts.Items.Clear()
        Me.lstWrongModel.Items.Clear()
        Me.lstWrongSKULength.Items.Clear()
        Me.chkNoReprot.Checked = False
        Me.lblCnt.Text = ""
        iFileCheckDone = 0
        Me.BackColor = System.Drawing.Color.SteelBlue
        System.Windows.Forms.Application.DoEvents()

        '*********************
        'objBulkShip Variables
        objBulkShip.iLoc_ID = 0
        objBulkShip.strWorkDt = ""
        objBulkShip.iBulkShipped = 0

        If Not IsNothing(objBulkShip.dtExcelSNs) Then
            objBulkShip.dtExcelSNs.Dispose()
            objBulkShip.dtExcelSNs = Nothing
        End If
        If Not IsNothing(objBulkShip.dtWO) Then
            objBulkShip.dtWO.Dispose()
            objBulkShip.dtWO = Nothing
        End If
        '*********************
    End Sub

    'Private Sub RequiredDataValidation()
    '    If Me.cmbShipType.SelectedItem = "" Then
    '        Throw New Exception("'Ship Type' is not selected.")
    '    End If
    '    If Me.cmbCustomer.SelectedValue = 0 Then
    '        Throw New Exception("Customer is not selected.")
    '    End If
    '    If Me.cmbLocation.SelectedValue = 0 Then
    '        Throw New Exception("Location is not selected.")
    '    End If
    '    If Me.cmbModel.SelectedValue = 0 Then
    '        Throw New Exception("Model is not selected.")
    '    End If
    '    If Me.cmbSkuLength.SelectedItem = "" Then
    '        Throw New Exception("'Sku Length' is not selected.")
    '    End If
    'End Sub


    Private Sub DoValidation()
        '***************************
        If Len(Trim(strWorkDate)) = 0 Then
            Throw New Exception("'Work Date' could not be determined. Shipping user may not have a 'Shift' assigned.")
        End If
        '***************************
        If IsNothing(objBulkShip.dtExcelSNs) Then
            Throw New Exception("Select an Excel file to ship.")
        End If
        If objBulkShip.dtExcelSNs.Rows.Count = 0 Then
            Me.BackColor = System.Drawing.Color.Red
            System.Windows.Forms.Application.DoEvents()
            Throw New Exception("There are no devices to ship in this file. Please make sure you have selected the correct file and it has valid data.")
        End If
        '***************************
        'Check the Billcode rule of the device and the Selected ShipType.
        'If they are different then don't let them ship
        If iShipType = 0 Then   'REGULAR
            If Me.lstRUR.Items.Count > 0 Then
                Me.BackColor = System.Drawing.Color.Red
                System.Windows.Forms.Application.DoEvents()
                Throw New Exception("You are trying to ship RUR devices with REGULAR devices. Not allowed.")
            End If
            If Me.lstRTM.Items.Count > 0 Then
                Me.BackColor = System.Drawing.Color.Red
                System.Windows.Forms.Application.DoEvents()
                Throw New Exception("You are trying to ship RTM devices with REGULAR devices. Not allowed.")
            End If
        ElseIf iShipType = 1 Then   'RUR
            If Me.lstRegular.Items.Count > 0 Then
                Me.BackColor = System.Drawing.Color.Red
                System.Windows.Forms.Application.DoEvents()
                Throw New Exception("You are trying to ship REGULAR devices with RUR devices. Not allowed.")
            End If
            If Me.lstRTM.Items.Count > 0 Then
                Me.BackColor = System.Drawing.Color.Red
                System.Windows.Forms.Application.DoEvents()
                Throw New Exception("You are trying to ship RTM devices with RUR devices. Not allowed.")
            End If
        ElseIf iShipType = 9 Then   'RTM
            If Me.lstRegular.Items.Count > 0 Then
                Me.BackColor = System.Drawing.Color.Red
                System.Windows.Forms.Application.DoEvents()
                Throw New Exception("You are trying to ship REGULAR devices with RTM devices. Not allowed.")
            End If
            If Me.lstRUR.Items.Count > 0 Then
                Me.BackColor = System.Drawing.Color.Red
                System.Windows.Forms.Application.DoEvents()
                Throw New Exception("You are trying to ship RUR devices with RTM devices. Not allowed.")
            End If
        ElseIf iShipType = 8 Then   'RTM/Scrap
            If Me.lstRegular.Items.Count > 0 Then
                Me.BackColor = System.Drawing.Color.Red
                System.Windows.Forms.Application.DoEvents()
                Throw New Exception("You are trying to ship REGULAR devices with SCRAP devices. Not allowed.")
            End If
            If Me.lstRUR.Items.Count > 0 Then
                Me.BackColor = System.Drawing.Color.Red
                System.Windows.Forms.Application.DoEvents()
                Throw New Exception("You are trying to ship RUR devices with SCRAP devices. Not allowed.")
            End If
        Else
            Throw New Exception("'Ship Type' not determined.")
        End If

        '***************************
        'Discrepancies
        If Me.lstRURRTMParts.Items.Count > 0 Then
            Me.BackColor = System.Drawing.Color.Red
            System.Windows.Forms.Application.DoEvents()
            Throw New Exception("There are RUR/RTM devices that still have parts billed. Shipping not allowed.")
        End If
        If Me.lstWrongModel.Items.Count > 0 Then
            Me.BackColor = System.Drawing.Color.Red
            System.Windows.Forms.Application.DoEvents()
            Throw New Exception("There are devices of wrong model in the file. Shipping not allowed.")
        End If
        If Me.iCust_ID = 2219 Then
            If iShipType <> 9 Then
                If Me.lstWrongSKULength.Items.Count > 0 Then
                    Me.BackColor = System.Drawing.Color.Red
                    System.Windows.Forms.Application.DoEvents()
                    Throw New Exception("You are trying to ship INCOMPLETE devices with other type of devices. Not allowed.")
                End If
            End If
        Else
            If Me.lstWrongSKULength.Items.Count > 0 Then
                Me.BackColor = System.Drawing.Color.Red
                System.Windows.Forms.Application.DoEvents()
                Throw New Exception("There are devices of wrong SKU length in the file. Shipping not allowed.")
            End If
        End If

        '***************************

        Me.PanelList.Visible = True
    End Sub
    '*********************************************************
    'Form Load
    Private Sub frmBulkShipping_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Trim(strWorkDate) = "" Then
                Throw New Exception("'Work Date' could not be determined. 'PSS User' may not have correct shift assigned.")
            End If
            Me.objBulkShip.strWorkDt = strWorkDate
            Me.objBulkShip.iShiftID = iShiftID
            Me.objBulkShip.struser = strUser
            iHoldStatus = 0
            Me.RadioRegular.Select()
            LoadPallets()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Ship Cell Pallets:frmBulkShipping_Load()", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
        
    End Sub
    '********************************************************
    'GetPalletsReadyToBeShipped
    Private Sub LoadPallets()
        Dim dtPallets As DataTable

        Try
            ClearControls()
            dtPallets = Me.objBulkShip.GetPalletsReadyToBeShipped(iHoldStatus)
            Me.grdPallets.ClearFields()
            Me.grdPallets.DataSource = dtPallets.DefaultView
            SetPalletGridProperties()
        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(dtPallets) Then
                dtPallets.Dispose()
                dtPallets = Nothing
            End If
        End Try
    End Sub
    '********************************************************
    Private Sub SetPalletGridProperties()
        Dim iNumOfColumns As Integer = Me.grdPallets.Columns.Count
        Dim i As Integer


        With Me.grdPallets
            'Heading style (Horizontal Alignment to Center)
            For i = 0 To (iNumOfColumns - 1)
                .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Next

            'Set individual column data horizontal alignment
            .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns(3).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns(4).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Set Column Widths
            .Splits(0).DisplayColumns(1).Width = 140
            .Splits(0).DisplayColumns(2).Width = 45
            .Splits(0).DisplayColumns(3).Width = 69
            .Splits(0).DisplayColumns(4).Width = 81

            'Make some columns invisible
            .Splits(0).DisplayColumns(0).Visible = False
            .Splits(0).DisplayColumns(5).Visible = False
            .Splits(0).DisplayColumns(6).Visible = False
            .Splits(0).DisplayColumns(7).Visible = False
            .Splits(0).DisplayColumns(8).Visible = False

        End With
    End Sub
    '********************************************************
    'Private Sub LoadCustomers()
    '    Dim dtCustomers As New DataTable()
    '    Try
    '        dtCustomers = objMisc.GetCustomers
    '        With Me.cmbCustomer
    '            .DataSource = dtCustomers.DefaultView
    '            .DisplayMember = dtCustomers.Columns("cust_name1").ToString
    '            .ValueMember = dtCustomers.Columns("Cust_ID").ToString
    '            .SelectedValue = 0 '2019       'ATCLE-AWS
    '        End With
    '        LoadLocations()
    '    Catch ex As Exception
    '        MsgBox("Error in frmBulkShipping.LoadCustomers:: " & ex.Message.ToString, MsgBoxStyle.Critical)
    '    Finally
    '        If Not IsNothing(dtCustomers) Then
    '            dtCustomers.Dispose()
    '            dtCustomers = Nothing
    '        End If
    '    End Try
    'End Sub
    '*********************************************************
    'Private Sub LoadLocations()
    '    Dim dtLoc As DataTable

    '    Try
    '        If Me.cmbCustomer.SelectedValue = 0 Then
    '            Exit Sub
    '        End If

    '        If Not IsNothing(dtLoc) Then
    '            dtLoc.Dispose()
    '            dtLoc = Nothing
    '        End If

    '        dtLoc = objMisc.GetLocations(Me.cmbCustomer.SelectedValue)
    '        '**************************************************
    '        'Fill the Customer combo box
    '        '**************************************************
    '        With Me.cmbLocation
    '            .DataSource = dtLoc.DefaultView
    '            .ValueMember = dtLoc.Columns("Loc_id").ToString
    '            .DisplayMember = dtLoc.Columns("Loc_Name").ToString
    '            .SelectedValue = 0

    '            'If Me.cmbCustomer.SelectedValue = 2019 Then
    '            '    .SelectedValue = 2540   'ALTX02
    '            'Else
    '            '    .SelectedValue = 0
    '            'End If
    '        End With

    '        '**************************************************
    '    Catch ex As Exception
    '        MsgBox("frmBulkShipping.LoadLocations: " & ex.Message.ToString, MsgBoxStyle.Critical, "Customer Specific Shipping")
    '    Finally
    '        If Not IsNothing(dtLoc) Then
    '            dtLoc.Dispose()
    '            dtLoc = Nothing
    '        End If
    '    End Try
    'End Sub
    '*********************************************************
    'Private Sub LoadModels()
    '    Dim dtModels As New DataTable()
    '    Try
    '        dtModels = objMisc.GetModels()
    '        With Me.cmbModel
    '            .DataSource = dtModels.DefaultView
    '            .DisplayMember = dtModels.Columns("Model_Desc").ToString
    '            .ValueMember = dtModels.Columns("Model_ID").ToString
    '            .SelectedValue = 0
    '        End With

    '    Catch ex As Exception
    '        MsgBox("Error in frmBulkShipping.LoadModels:: " & ex.Message.ToString, MsgBoxStyle.Critical)
    '    Finally
    '        If Not IsNothing(dtModels) Then
    '            dtModels.Dispose()
    '            dtModels = Nothing
    '        End If
    '    End Try
    'End Sub
    '*********************************************************
    'Private Sub cmbCustomer_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCustomer.SelectionChangeCommitted
    '    Try
    '        LoadLocations()          'Fill the location combo box
    '    Catch ex As Exception
    '        MsgBox("frmBulkShipping.cboCustomer_SelectionChangeCommitted: " & ex.Message.ToString)
    '    End Try
    'End Sub
    '*********************************************************
    Private Sub cmdFileCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFileCheck.Click
        Dim strIMEI As String = ""
        Dim R1 As DataRow
        Dim iMatch As Integer = 0

        Try
            If Not IsNothing(objBulkShip.dtExcelSNs) Then
                Select Case iCust_ID
                    Case 2019      'ATCLE
                        strIMEI = InputBox("Please scan in a 'Serial Number' (IMEI) to make sure you have selected the right file.")
                        If strIMEI <> "" Then
                            For Each R1 In objBulkShip.dtExcelSNs.Rows
                                If strIMEI = Trim(R1("IMEI")) Then
                                    iMatch = 1
                                    Exit For
                                End If
                            Next R1
                        End If
                        '0 - File Check not done
                        '1 - DOne but SN not in file
                        '2 - Right file.
                        If iMatch = 1 Then
                            iFileCheckDone = 2
                            Me.BackColor = System.Drawing.Color.SteelBlue
                            System.Windows.Forms.Application.DoEvents()
                            MessageBox.Show("Serial Number (IMEI) exists in the file.", "File Check", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.cmdShip.Enabled = True
                        ElseIf iMatch = 0 Then
                            iFileCheckDone = 1
                            Me.BackColor = System.Drawing.Color.Red
                            System.Windows.Forms.Application.DoEvents()
                            MessageBox.Show("STOP! Serial Number (IMEI) does not exist in the file.", "File Check", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.cmdShip.Enabled = False
                        End If
                    Case 2113      'Cellstar
                        strIMEI = InputBox("Please scan in a 'Serial Number' (SN) to make sure you have selected the right file.")
                        If strIMEI <> "" Then
                            For Each R1 In objBulkShip.dtExcelSNs.Rows
                                If strIMEI = Trim(R1("SN")) Then
                                    iMatch = 1
                                    Exit For
                                End If
                            Next R1
                        End If
                        '0 - File Check not done
                        '1 - DOne but SN not in file
                        '2 - Right file.
                        If iMatch = 1 Then
                            iFileCheckDone = 2
                            Me.BackColor = System.Drawing.Color.SteelBlue
                            System.Windows.Forms.Application.DoEvents()
                            MessageBox.Show("Serial Number (SN) exists in the file.", "File Check", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.cmdShip.Enabled = True
                        ElseIf iMatch = 0 Then
                            iFileCheckDone = 1
                            Me.BackColor = System.Drawing.Color.Red
                            System.Windows.Forms.Application.DoEvents()
                            MessageBox.Show("STOP! Serial Number (SN) does not exist in the file.", "File Check", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.cmdShip.Enabled = False
                        End If
                    Case 2219      'gamestop
                        strIMEI = InputBox("Please scan in a 'Serial Number' (SN) to make sure you have selected the right file.")
                        If strIMEI <> "" Then
                            For Each R1 In objBulkShip.dtExcelSNs.Rows
                                If strIMEI = Trim(R1("Serial")) Then
                                    iMatch = 1
                                    Exit For
                                End If
                            Next R1
                        End If
                        '0 - File Check not done
                        '1 - DOne but SN not in file
                        '2 - Right file.
                        If iMatch = 1 Then
                            iFileCheckDone = 2
                            Me.BackColor = System.Drawing.Color.SteelBlue
                            System.Windows.Forms.Application.DoEvents()
                            MessageBox.Show("Serial Number (SN) exists in the file.", "File Check", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.cmdShip.Enabled = True
                        ElseIf iMatch = 0 Then
                            iFileCheckDone = 1
                            Me.BackColor = System.Drawing.Color.Red
                            System.Windows.Forms.Application.DoEvents()
                            MessageBox.Show("STOP! Serial Number (SN) does not exist in the file.", "File Check", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.cmdShip.Enabled = False
                        End If
                    Case Else
                        Throw New Exception("Cust_ID is missing.")
                End Select



                
            End If

        Catch ex As Exception
            MsgBox("frmBulkShipping.cmdFileCheck_Click: " & ex.Message.ToString)
        Finally
            R1 = Nothing
        End Try

    End Sub
    '*********************************************************
    Private Sub lstRURRTMParts_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstRURRTMParts.SelectedIndexChanged
        Dim dt1 As New DataTable()
        Dim R1 As DataRow

        Try
            dt1 = objMisc.GetPartsForDevice(Trim(Me.lstRURRTMParts.Items(Me.lstRURRTMParts.SelectedIndex)))

            Me.lstDetail.Items.Clear()

            For Each R1 In dt1.Rows
                Me.lstDetail.Items.Add(Trim(R1("PSprice_Desc")))
            Next R1

        Catch ex As Exception
            MsgBox("frmBulkShipping.lstRURRTMParts_SelectedIndexChanged: " & ex.Message.ToString)
        Finally
            R1 = Nothing
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
        End Try
    End Sub

    Private Sub lstWrongModel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstWrongModel.SelectedIndexChanged
        Dim dt1 As New DataTable()
        Dim R1 As DataRow

        Try
            Me.lstDetail.Items.Clear()
            dt1 = objMisc.GetDeviceInfo(Trim(Me.lstWrongModel.Items(Me.lstWrongModel.SelectedIndex)))
            If dt1.Rows.Count > 0 Then
                R1 = dt1.Rows(0)
                Me.lstDetail.Items.Add(Trim(R1("Model_desc")))
            End If

        Catch ex As Exception
            MsgBox("frmBulkShipping.lstWrongModel_SelectedIndexChanged: " & ex.Message.ToString)
        Finally
            R1 = Nothing
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
        End Try
    End Sub

    Private Sub lstWrongSKULength_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstWrongSKULength.SelectedIndexChanged
        Dim R1 As DataRow

        Try
            Me.lstDetail.Items.Clear()
            For Each R1 In objBulkShip.dtExcelSNs.Rows
                If Trim(R1("IMEI")) = Trim(Me.lstWrongSKULength.Items(Me.lstWrongSKULength.SelectedIndex)) Then
                    Me.lstDetail.Items.Add(Trim(R1("SKU_Number")))
                    Exit For
                End If
            Next R1
        Catch ex As Exception
            MsgBox("frmBulkShipping.lstWrongSKULength_SelectedIndexChanged: " & ex.Message.ToString)
        Finally
            R1 = Nothing
        End Try
    End Sub

    Private Sub Asif()
        With Me.grdPallets
            'Dim x As String = "Group: " & .Splits(0).DisplayColumns(1).Width
            MsgBox(.Splits(0).DisplayColumns(1).Width & Environment.NewLine & _
            .Splits(0).DisplayColumns(2).Width & Environment.NewLine & _
            .Splits(0).DisplayColumns(3).Width & Environment.NewLine & _
            .Splits(0).DisplayColumns(4).Width & Environment.NewLine)
        End With

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MsgBox(iHoldStatus)
        'Asif()
    End Sub

    Private Sub grdPallets_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles grdPallets.RowColChange
        If Me.grdPallets.Columns.Count = 0 Then
            Exit Sub
        End If
        If Me.RadioRemoveFromHold.Checked = True Then
            iPallett_ID = Me.grdPallets.Columns("pallett_id").Value
            Exit Sub
        End If
        If iFlg = 0 Then
            Exit Sub
        End If
        ProcessPallet()
    End Sub

    Private Sub ProcessPallet()
        Dim iExcelNum As Integer = 0
        Dim iPSSNum As Integer = 0
        Dim R1 As DataRow
        Dim i As Integer = 0
        Dim strFileLocation As String = ""

        Try
            Cursor.Current = Cursors.WaitCursor
            Me.BackColor = System.Drawing.Color.SteelBlue
            System.Windows.Forms.Application.DoEvents()

            ClearListControls()
            Me.PanelList.Visible = False
            '************************************************
            'Retrieve Grid info
            '************************************************
            iPallett_ID = Me.grdPallets.Columns("pallett_id").Value
            strPalletName = Trim(Me.grdPallets.Columns("Pallet").Value.ToString)
            iLoc_ID = Me.grdPallets.Columns("Loc_ID").Value
            iModel_ID = Me.grdPallets.Columns("Model_ID").Value
            iShipType = Me.grdPallets.Columns("Pallet_ShipType").Value
            strSKULength = Trim(Me.grdPallets.Columns("SKU Length").Value.ToString)
            iGroup_ID = Me.grdPallets.Columns("group_id").Value
            iCust_ID = Me.grdPallets.Columns("Cust_ID").Value
            Select Case iCust_ID
                Case 2019      'ATCLE
                    strFilePath = strATCLEFilePath
                Case 2113      'Cellstar
                    strFilePath = strCellStarFilePath
                Case 2219      'gamestop
                    strFilePath = strGameStopFilePath
                Case Else
                    Throw New Exception("Pallet manifest file path missing (Cust_ID in tpallett needs to be updated).")
            End Select
            '************************************************
            'Check if the excel file exists
            '************************************************
            strFileLocation = strFilePath & strPalletName & ".xls"
            If Not File.Exists(strFileLocation) Then
                Throw New Exception("Pallet Excel File was not found in '" & strFilePath & "'")
            End If
            '************************************************
            Me.lblPallet.Text = strPalletName
            '*********************
            'objBulkShip variables
            Me.objBulkShip.iLoc_ID = iLoc_ID
            Me.objBulkShip.iBulkShipped = 1
            Me.objBulkShip.iShipType = iShipType
            Me.objBulkShip.strFilePath = strFileLocation
            Me.objBulkShip.iPallet_ID = iPallett_ID
            Me.objBulkShip.iGroup_ID = iGroup_ID
            Me.objBulkShip.strWorkDt = strWorkDate
            Me.objBulkShip.iShiftID = iShiftID
            Me.objBulkShip.struser = strUser
            Me.objBulkShip.iCust_ID = iCust_ID
            '*********************
            iFileCheckDone = 0
            '************************************************
            'Step 1 :: Extract IMEI numbers from the excel file
            '************************************************
            iExcelNum = objBulkShip.ExtractSNs()
            If iExcelNum > 0 Then

                '#############################################################
                ''' STEP2 ::
                '''Obtain and set validation data.
                ''' Broken down in to pieces as far as getting data is concerned 
                ''' because not all customers need all these validations.
                ''' This will be easier to brach out the code.
                '#############################################################

                '***********************************************************
                '(A) :: Get Model
                '***********************************************************
                iPSSNum = objBulkShip.GetModel()
                If iExcelNum <> iPSSNum Then
                    Throw New Exception("cmdSelectFile_Click.GetModel:: Records from excel file don't have same number of records from PSS Database.")
                End If

                '***********************************************************
                '(B) :: Get the SKU Length
                '***********************************************************
                If iCust_ID = 2019 Then      'ATCLE-AWS
                    iPSSNum = objBulkShip.GetSKU()
                    If iExcelNum <> iPSSNum Then
                        Throw New Exception("cmdSelectFile_Click.GetSKU:: Records from excel file don't have same number of records from PSS Database.")
                    End If
                End If

                '***********************************************************
                '(C) :: Get Billcoderule
                '***********************************************************
                iPSSNum = objBulkShip.GetBillcodeRule()
                If iExcelNum <> iPSSNum Then
                    Throw New Exception("cmdSelectFile_Click.GetBillcodeRule:: Records from excel file don't have same number of records from PSS Database.")
                Else
                    Me.lblCnt.Text = iPSSNum
                End If

                '#############################################################
                'Step 3::
                'write data to controls based on the business logic
                '#############################################################

                '*******************************************************
                For Each R1 In objBulkShip.dtExcelSNs.Rows

                    '*******************************************************
                    '(A) Model Validation (For all customers)
                    '*******************************************************
                    If R1("Model_ID") <> iModel_ID Then
                        Select Case iCust_ID
                            Case 2019      'ATCLE
                                Me.lstWrongModel.Items.Add(Trim(R1("IMEI")))
                            Case 2113      'Cellstar
                                Me.lstWrongModel.Items.Add(Trim(R1("SN")))
                            Case 2219      'gamestop
                                Me.lstWrongModel.Items.Add(Trim(R1("SN")))
                            Case Else
                                Throw New Exception("Pallet manifest file path missing (Cust_ID in tpallett needs to be updated).")
                        End Select

                    End If
                    '*******************************************************
                    'CHECK SKU LENGTHS ONLY FOR REGULAR PHONES NOT RUR AND RTM PHONES
                    '*******************************************************
                    If iCust_ID = 2019 Then      'ATCLE-AWS
                        If iShipType = 0 Then       'REGULAR
                            If Len(R1("Sku_Number")) >= 1 And Len(R1("Sku_Number")) <= 5 Then
                                If UCase(strSKULength) <> "SHORT" Then
                                    Me.lstWrongSKULength.Items.Add(Trim(R1("IMEI")))
                                End If
                            ElseIf Len(R1("Sku_Number")) >= 6 And Len(R1("Sku_Number")) <= 15 Then
                                If UCase(strSKULength) <> "LONG" Then
                                    Me.lstWrongSKULength.Items.Add(Trim(R1("IMEI")))
                                End If
                            Else
                                Throw New Exception("SKU length out of bounds.")
                            End If
                        End If
                    End If
                    '*******************************************************
                    '(C) BILLCODERULE validation    (For all customers)
                    '*******************************************************
                    Select Case iCust_ID
                        Case 2019      'ATCLE
                            '*******************************************************
                            If R1("Billcode_rule") = 9 Then     'RTM
                                Me.lstRTM.Items.Add(Trim(R1("IMEI")))
                            ElseIf R1("Billcode_rule") = 1 Then 'RUR
                                Me.lstRUR.Items.Add(Trim(R1("IMEI")))
                            ElseIf R1("Billcode_rule") = 0 Then 'Regular
                                Me.lstRegular.Items.Add(Trim(R1("IMEI")))
                            End If
                            '*******************************************************
                            'RUR/RTMs have parts
                            '*******************************************************
                            If R1("RURRTMHasParts") = "1" Then
                                Me.lstRURRTMParts.Items.Add(Trim(R1("IMEI")))
                            End If
                            '*******************************************************
                        Case 2113      'Cellstar
                            '*******************************************************
                            If R1("Billcode_rule") = 9 Then     'RTM
                                Me.lstRTM.Items.Add(Trim(R1("SN")))
                            ElseIf R1("Billcode_rule") = 1 Then 'RUR
                                Me.lstRUR.Items.Add(Trim(R1("SN")))
                            ElseIf R1("Billcode_rule") = 0 Then 'Regular
                                Me.lstRegular.Items.Add(Trim(R1("SN")))
                            End If
                            '*******************************************************
                            'RUR/RTMs have parts
                            '*******************************************************
                            If R1("RURRTMHasParts") = "1" Then
                                Me.lstRURRTMParts.Items.Add(Trim(R1("SN")))
                            End If
                            '*******************************************************
                        Case 2219      'gamestop
                            '*******************************************************
                            If R1("Billcode_rule") = 8 Then     'Scrap
                                Me.lstRTM.Items.Add(Trim(R1("Serial")))
                            ElseIf R1("Billcode_rule") = 1 Then 'RUR
                                Me.lstRUR.Items.Add(Trim(R1("Serial")))
                            ElseIf R1("Billcode_rule") = 0 Then 'Regular
                                Me.lstRegular.Items.Add(Trim(R1("Serial")))
                            ElseIf R1("Billcode_rule") = 9 Then 'Incomplete     added by Lan 12/04/2006
                                Me.lstWrongSKULength.Items.Add(Trim(R1("Serial")))
                            End If
                            '*******************************************************
                        Case Else
                            Throw New Exception("Pallet manifest file path missing (Cust_ID in tpallett needs to be updated).")
                    End Select





                Next R1
                '#############################################################
                'Do Validations
                '*******************************************************
                DoValidation()
                '*******************************************************
            End If
            Me.PanelList.Visible = True
        Catch ex As Exception
            Me.PanelList.Visible = False
            iFlg = 0
            MessageBox.Show(ex.Message, "Ship Cell Pallets (ProcessPallet)", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
        Finally
            R1 = Nothing
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub RadioRegular_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioRegular.CheckedChanged
        Try
            Cursor.Current = Cursors.WaitCursor
            If Me.RadioRegular.Checked = True Then

                Me.RadioShipAndHold.Checked = False
                Me.RadioRemoveFromHold.Checked = False
                If iHoldStatus = 2 Then
                    iHoldStatus = 0
                    LoadPallets()
                End If
                iHoldStatus = 0
                Me.lblGridCaption.Text = "Pallets to be Shipped:"
                Me.cmdRemoveFromHold.Visible = False
                If iFlg > 0 Then
                    Me.PanelList.Visible = True
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Ship Cell Pallets:RadioRegular_CheckedChanged()", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub
    Private Sub RadioShipAndHold_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioShipAndHold.CheckedChanged
        Try
            Cursor.Current = Cursors.WaitCursor
            If Me.RadioShipAndHold.Checked = True Then

                Me.RadioRegular.Checked = False
                Me.RadioRemoveFromHold.Checked = False
                If iHoldStatus = 2 Then
                    iHoldStatus = 1
                    LoadPallets()
                End If
                iHoldStatus = 1
                Me.lblGridCaption.Text = "Pallets to be Shipped:"
                Me.cmdRemoveFromHold.Visible = False
                If iFlg > 0 Then
                    Me.PanelList.Visible = True
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Ship Cell Pallets:RadioShipAndHold_CheckedChanged()", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub
    Private Sub RadioRemoveFromHold_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioRemoveFromHold.CheckedChanged
       
        Try
            Cursor.Current = Cursors.WaitCursor
            If Me.RadioRemoveFromHold.Checked = True Then
                Me.RadioRegular.Checked = False
                Me.RadioShipAndHold.Checked = False
                iHoldStatus = 2
                LoadPallets()
                Me.lblGridCaption.Text = "Shipped Pallets on Hold:"
                Me.cmdRemoveFromHold.Visible = True
                Me.PanelList.Visible = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Ship Cell Pallets:RadioRemoveFromHold_CheckedChanged()", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub
    Private Sub grdPallets_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdPallets.Click
        If Me.RadioRemoveFromHold.Checked = False Then
            iFlg = 1
        End If

    End Sub

    Private Sub cmdRemoveFromHold_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveFromHold.Click
        Dim i As Integer = 0
        Try
            If MessageBox.Show("Are you sure you want to remove this Pallet from 'Awaiting Parts' to 'In-transit'?", "Move to In-transit", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Exit Sub
            End If
            Cursor.Current = Cursors.WaitCursor
            i = objBulkShip.MovePalletsFromAWPtoIntransit(iPallett_ID)
            LoadPallets()
            MessageBox.Show("Done.", "Remove Pallet from Hold", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Ship Cell Pallets:cmdRemoveFromHold_Click()", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmdReprintPalletLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReprintPalletLabel.Click
        Dim str_pallet As String = ""
        Dim iPalletID As Integer = 0

        Try
            str_pallet = InputBox("Enter Pallet Name.", "Reprint Pallet Label")
            If str_pallet = "" Then
                Throw New Exception("Please enter a Pallet Name if you want to reprint the pallet label.")
            End If

            Me.cmdReprintPalletLabel.Enabled = False
            Cursor.Current = Cursors.WaitCursor

            iPalletID = objMisc.GetPalletID(Trim(str_pallet), 1)
            If iPalletID > 0 Then
                '********************
                'GameStop customer
                If iCust_ID = 0 Then
                    If UCase(Mid(str_pallet, 1, 3)) = "RL1" Then
                        iCust_ID = 2219
                    End If
                End If
                '********************
                objMisc.PrintPalletDeviceCountRpt(iPalletID, iCust_ID)
            Else
                Throw New Exception("Pallet Name was not defined in system.")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Reprint Pallet Label.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.cmdReprintPalletLabel.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub


    '***************************************************************************
    'LAN add
    Private Sub cmdReprintManifest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReprintManifest.Click
        ''Dim str_pallet As String = ""

        ''Try
        ''    str_pallet = Trim(InputBox("Enter Pallet Name.", "Reprint Pallet Manifest"))
        ''    If str_pallet = "" Then
        ''        Throw New Exception("Please enter a Pallet Name if you want to reprint the pallet manifest.")
        ''    End If

        ''    Me.cmdReprintManifest.Enabled = False
        ''    Cursor.Current = Cursors.WaitCursor

        ''    If File.Exists(strFilePath & str_pallet & ".xls") Then
        ''        objBulkShip.PrintExcelFile(strFilePath & str_pallet & ".xls")
        ''    Else
        ''        Throw New Exception("File not found.")
        ''    End If
        ''Catch ex As Exception
        ''    MessageBox.Show(ex.ToString, "Reprint Pallet Manifest.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        ''Finally
        ''    Me.cmdReprintManifest.Enabled = True
        ''    Cursor.Current = Cursors.Default
        ''End Try
        '***************************************************************************
    End Sub
End Class
