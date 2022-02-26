Option Explicit On 

Public Class frmModelTarget
    Inherits System.Windows.Forms.Form

    Private GobjModelTarget As PSS.Data.Buisness.ModelTarget
    Private GiUserID As Integer = PSS.Core.[Global].ApplicationUser.IDuser
    Private GdtCellstarEnterprise As DataTable

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        GobjModelTarget = New PSS.Data.Buisness.ModelTarget()

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
    Friend WithEvents cmbModel As PSS.Gui.Controls.ComboBox
    Friend WithEvents lblModel As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents grdModelTarget As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbCustomer As PSS.Gui.Controls.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbEnterprise As PSS.Gui.Controls.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdAddUpdateTarget As System.Windows.Forms.Button
    Friend WithEvents mskBERCap As AxMSMask.AxMaskEdBox
    Friend WithEvents mskTarget As AxMSMask.AxMaskEdBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmModelTarget))
        Me.grdModelTarget = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.cmbModel = New PSS.Gui.Controls.ComboBox()
        Me.lblModel = New System.Windows.Forms.Label()
        Me.cmdAddUpdateTarget = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbCustomer = New PSS.Gui.Controls.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbEnterprise = New PSS.Gui.Controls.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.mskBERCap = New AxMSMask.AxMaskEdBox()
        Me.mskTarget = New AxMSMask.AxMaskEdBox()
        CType(Me.grdModelTarget, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mskBERCap, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mskTarget, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdModelTarget
        '
        Me.grdModelTarget.AllowColMove = False
        Me.grdModelTarget.AllowColSelect = False
        Me.grdModelTarget.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.grdModelTarget.AllowUpdate = False
        Me.grdModelTarget.AlternatingRows = True
        Me.grdModelTarget.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left)
        Me.grdModelTarget.FilterBar = True
        Me.grdModelTarget.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdModelTarget.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdModelTarget.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.grdModelTarget.Location = New System.Drawing.Point(296, 16)
        Me.grdModelTarget.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.grdModelTarget.Name = "grdModelTarget"
        Me.grdModelTarget.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdModelTarget.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdModelTarget.PreviewInfo.ZoomFactor = 75
        Me.grdModelTarget.RowHeight = 20
        Me.grdModelTarget.Size = New System.Drawing.Size(528, 256)
        Me.grdModelTarget.TabIndex = 119
        Me.grdModelTarget.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
        "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
        "CaptionText;BackColor:InactiveCaption;}FilterBar{ForeColor:Red;BackColor:Transpa" & _
        "rent;}Footer{}Caption{AlignHorz:Center;}Style1{}Normal{Font:Microsoft Sans Serif" & _
        ", 8.25pt;AlignVert:Center;BackColor:Control;}HighlightRow{ForeColor:HighlightTex" & _
        "t;BackColor:Highlight;}Style14{}OddRow{BackColor:Control;}RecordSelector{AlignIm" & _
        "age:Center;}Style15{}Heading{Wrap:True;Font:Microsoft Sans Serif, 8.25pt, style=" & _
        "Bold;AlignHorz:Center;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:Contr" & _
        "olText;BackColor:Control;}Style8{}Style10{AlignHorz:Near;}Style11{}Style12{}Styl" & _
        "e13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove" & _
        "=""False"" AllowColSelect=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyl" & _
        "e=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" Fil" & _
        "terBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSel" & _
        "Width=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>252</Height" & _
        "><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""S" & _
        "tyle5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""Fi" & _
        "lterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle p" & _
        "arent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighL" & _
        "ightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive" & _
        """ me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle " & _
        "parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Styl" & _
        "e6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 524, 252</ClientRec" & _
        "t><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGr" & _
        "id.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=" & _
        """Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Hea" & _
        "ding"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Norm" & _
        "al"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" " & _
        "me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal""" & _
        " me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Norm" & _
        "al"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSpl" & _
        "its>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelW" & _
        "idth>17</DefaultRecSelWidth><ClientArea>0, 0, 524, 252</ClientArea><PrintPageHea" & _
        "derStyle parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /" & _
        "></Blob>"
        '
        'cmbModel
        '
        Me.cmbModel.AutoComplete = True
        Me.cmbModel.Location = New System.Drawing.Point(112, 48)
        Me.cmbModel.Name = "cmbModel"
        Me.cmbModel.Size = New System.Drawing.Size(160, 21)
        Me.cmbModel.TabIndex = 2
        '
        'lblModel
        '
        Me.lblModel.BackColor = System.Drawing.Color.Transparent
        Me.lblModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModel.ForeColor = System.Drawing.Color.White
        Me.lblModel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblModel.Location = New System.Drawing.Point(16, 48)
        Me.lblModel.Name = "lblModel"
        Me.lblModel.Size = New System.Drawing.Size(88, 16)
        Me.lblModel.TabIndex = 117
        Me.lblModel.Text = "Model : "
        Me.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdAddUpdateTarget
        '
        Me.cmdAddUpdateTarget.BackColor = System.Drawing.Color.Green
        Me.cmdAddUpdateTarget.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAddUpdateTarget.ForeColor = System.Drawing.Color.White
        Me.cmdAddUpdateTarget.Location = New System.Drawing.Point(112, 184)
        Me.cmdAddUpdateTarget.Name = "cmdAddUpdateTarget"
        Me.cmdAddUpdateTarget.Size = New System.Drawing.Size(160, 32)
        Me.cmdAddUpdateTarget.TabIndex = 6
        Me.cmdAddUpdateTarget.Text = "Add/Update Target"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(16, 112)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 16)
        Me.Label10.TabIndex = 114
        Me.Label10.Text = "BER Cap:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(16, 144)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 121
        Me.Label1.Text = "Target:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbCustomer
        '
        Me.cmbCustomer.AutoComplete = True
        Me.cmbCustomer.Location = New System.Drawing.Point(112, 16)
        Me.cmbCustomer.Name = "cmbCustomer"
        Me.cmbCustomer.Size = New System.Drawing.Size(160, 21)
        Me.cmbCustomer.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label2.Location = New System.Drawing.Point(16, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 122
        Me.Label2.Text = "Customer : "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbEnterprise
        '
        Me.cmbEnterprise.AutoComplete = True
        Me.cmbEnterprise.Location = New System.Drawing.Point(112, 80)
        Me.cmbEnterprise.Name = "cmbEnterprise"
        Me.cmbEnterprise.Size = New System.Drawing.Size(160, 21)
        Me.cmbEnterprise.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label3.Location = New System.Drawing.Point(16, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 124
        Me.Label3.Text = "Enterprise : "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mskBERCap
        '
        Me.mskBERCap.Location = New System.Drawing.Point(112, 112)
        Me.mskBERCap.Name = "mskBERCap"
        Me.mskBERCap.OcxState = CType(resources.GetObject("mskBERCap.OcxState"), System.Windows.Forms.AxHost.State)
        Me.mskBERCap.Size = New System.Drawing.Size(72, 20)
        Me.mskBERCap.TabIndex = 4
        '
        'mskTarget
        '
        Me.mskTarget.Location = New System.Drawing.Point(112, 144)
        Me.mskTarget.Name = "mskTarget"
        Me.mskTarget.OcxState = CType(resources.GetObject("mskTarget.OcxState"), System.Windows.Forms.AxHost.State)
        Me.mskTarget.Size = New System.Drawing.Size(72, 20)
        Me.mskTarget.TabIndex = 5
        '
        'frmModelTarget
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(832, 310)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.mskTarget, Me.mskBERCap, Me.cmbEnterprise, Me.Label3, Me.cmbCustomer, Me.Label2, Me.Label1, Me.grdModelTarget, Me.cmbModel, Me.lblModel, Me.cmdAddUpdateTarget, Me.Label10})
        Me.Name = "frmModelTarget"
        Me.Text = "Set Model Target"
        CType(Me.grdModelTarget, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mskBERCap, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mskTarget, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        Me.GobjModelTarget = Nothing
        If Not IsNothing(Me.GdtCellstarEnterprise) Then
            Me.GdtCellstarEnterprise.Dispose()
            Me.GdtCellstarEnterprise = Nothing
        End If
    End Sub

    '*********************************************************
    Private Sub frmModelTarget_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim objGen As New PSS.Data.Buisness.Generic()
        Dim dt1 As DataTable

        Try
            '*********************************************
            'Load customer of cell product only
            '*********************************************
            objGen.LoadCustomers(Me.cmbCustomer, 2)
            '*********************************************
            'Load auto-bill model of cell product only
            '*********************************************
            objGen.LoadModels(Me.cmbModel, 2, )
            '*********************************************
            'Load Model Target
            '*********************************************
            dt1 = Me.GobjModelTarget.GetAllModelTarget()
            Me.SetDataGrid_ModelTarger(dt1)
            '*********************************************
            'Load all Brightpoint Enterprise
            '*********************************************
            Me.GdtCellstarEnterprise = Me.GobjModelTarget.GetAllCellstarEnterpriseCode()
            '*******************************************
            'set default value to Enterprise combobox
            '*******************************************
            Me.cmbEnterprise.Items.Clear()
            Me.cmbEnterprise.Items.Add("-- Select --")
            '*******************************************
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            objGen = Nothing
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
        End Try
    End Sub

    '*********************************************************
    Private Sub SetDataGrid_ModelTarger(ByVal dt1 As DataTable)

        Dim iNumOfColumns As Integer = Me.grdModelTarget.Columns.Count
        Dim i As Integer

        Try
            If dt1.Rows.Count > 0 Then
                Me.grdModelTarget.DataSource = Nothing
                Me.grdModelTarget.DataSource = dt1.DefaultView
                Me.grdModelTarget.Refresh()
            Else
                Me.grdModelTarget.DataSource = Nothing
                Me.grdModelTarget.Refresh()
                Exit Sub
            End If

            With Me.grdModelTarget
                'Heading style (Horizontal Alignment to Center)
                For i = 0 To (iNumOfColumns - 1)
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Next i

                ''Set individual column data horizontal alignment
                '.Splits(0).DisplayColumns("BER Cap").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                '.Splits(0).DisplayColumns("Target").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                '.Splits(0).DisplayColumns("Enterprise").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                'Set Column Widths
                .Splits(0).DisplayColumns("Customer").Width = 100
                .Splits(0).DisplayColumns("Model").Width = 141
                .Splits(0).DisplayColumns("Enterprise").Width = 83
                .Splits(0).DisplayColumns("BER Cap").Width = 80
                .Splits(0).DisplayColumns("Target").Width = 80

                'Make some columns invisible
                .Splits(0).DisplayColumns("MT_ID").Visible = False
                .Splits(0).DisplayColumns("MT_Cust_ID").Visible = False
                .Splits(0).DisplayColumns("MT_Model_ID").Visible = False

            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '*********************************************************
    Private Sub PopulateEnterprise(ByVal iCust_ID As Integer)
        Dim R1 As DataRow
        Dim i As Integer = 0

        Try
            Me.cmbEnterprise.Items.Clear()
            Me.cmbEnterprise.Items.Add("-- Select --")

            Select Case iCust_ID
                Case 2113   'Brightpoint
                    For Each R1 In Me.GdtCellstarEnterprise.Rows
                        Me.cmbEnterprise.Items.Add(R1("Enterprise"))
                        i += 1
                    Next R1
                Case 2019   'ATCLE
                    Me.cmbEnterprise.Items.Add("ATCLE")
                Case Else
            End Select

            Me.cmbEnterprise.SelectedIndex = 0
        Catch ex As Exception
            Throw ex
        Finally
            R1 = Nothing
            Me.cmbEnterprise.Refresh()
        End Try
    End Sub

    '*********************************************************
    Private Sub cmbCustomer_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCustomer.SelectionChangeCommitted
        If Me.cmbCustomer.SelectedValue > 0 Then
            Me.PopulateEnterprise(Me.cmbCustomer.SelectedValue)
        End If
    End Sub

    '*********************************************************
    Private Sub cmbEnterprise_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbEnterprise.SelectionChangeCommitted
        Me.mskBERCap.Focus()
    End Sub

    '*********************************************************
    Private Sub grdModelTarget_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles grdModelTarget.MouseUp
        Dim i As Integer = 0

        Try
            '****************
            'Reset Data
            '****************
            Me.cmbCustomer.SelectedValue = 0
            Me.cmbModel.SelectedValue = 0
            Me.cmbEnterprise.SelectedIndex = 0
            SetMaskControlText(Me.mskBERCap, "")
            SetMaskControlText(Me.mskTarget, "")

            '****************
            'populate data
            '****************
            'Customer
            If Not IsDBNull(Me.grdModelTarget.Columns("MT_Cust_ID").Value) Then
                Me.cmbCustomer.SelectedValue = Me.grdModelTarget.Columns("MT_Cust_ID").Value
                Me.PopulateEnterprise(Me.cmbCustomer.SelectedValue)
            Else
                Exit Sub
            End If

            'Model
            If Not IsDBNull(Me.grdModelTarget.Columns("MT_Model_ID").Value) Then
                Me.cmbModel.SelectedValue = Me.grdModelTarget.Columns("MT_Model_ID").Value
            Else
                Exit Sub
            End If

            'Enterprise
            If Not IsDBNull(Me.grdModelTarget.Columns("Enterprise").Value) Then
                For i = 0 To Me.cmbEnterprise.Items.Count - 1
                    If UCase(Trim(Me.cmbEnterprise.Items.Item(i))) = UCase(Trim(Me.grdModelTarget.Columns("Enterprise").Value)) Then
                        Me.cmbEnterprise.SelectedIndex = i
                        Exit For
                    End If
                Next i
            End If

            'BER Cap
            If Not IsDBNull(Me.grdModelTarget.Columns("BER Cap").Value) Then
                SetMaskControlText(Me.mskBERCap, Me.grdModelTarget.Columns("BER Cap").Value)
            End If

            'Target
            If Not IsDBNull(Me.grdModelTarget.Columns("Target").Value) Then
                SetMaskControlText(Me.mskTarget, Me.grdModelTarget.Columns("Target").Value)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "DataGrid KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*********************************************************
    Private Sub SetMaskControlText(ByRef mskCtrl As AxMSMask.AxMaskEdBox, _
                                   Optional ByVal strText As String = "")
        Dim strMask As String = ""

        With mskCtrl
            strMask = .Mask
            .Mask = ""
            .CtlText = strText
            .Mask = strMask
        End With
    End Sub

    '*********************************************************
    Private Sub mskBERCap_KeyUpEvent(ByVal sender As Object, ByVal e As AxMSMask.MaskEdBoxEvents_KeyUpEvent) Handles mskBERCap.KeyUpEvent
        If e.keyCode = 13 Then
            Me.mskTarget.Focus()
        End If
    End Sub

    '*********************************************************
    Private Sub cmdAddUpdateTarget_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddUpdateTarget.Click
        Dim i As Integer = 0
        Dim dt1 As DataTable

        Try
            'Validation
            If Me.cmbCustomer.SelectedValue = 0 Then
                MessageBox.Show("Please select Customer.", "Validate User Selection", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.cmbCustomer.Focus()
                Exit Sub
            End If

            If Me.cmbModel.SelectedValue = 0 Then
                MessageBox.Show("Please select Model.", "Validate User Selection", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.cmbModel.Focus()
                Exit Sub
            End If

            If Me.cmbEnterprise.SelectedIndex = 0 Then
                MessageBox.Show("Please select Enterprise.", "Validate User Selection", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.cmbEnterprise.Focus()
                Exit Sub
            End If

            '*****************************
            'Ask user for confirm message
            '*****************************
            If MessageBox.Show("Are you sure you want to ""Add/Update"" the Target?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Exit Sub
            End If

            Me.Enabled = False
            Cursor.Current = Cursors.WaitCursor

            '**********************
            'Update Model Target
            '**********************
            i = Me.GobjModelTarget.AddUpdateModelTarget(Me.GiUserID, _
                                                        Me.cmbCustomer.SelectedValue, _
                                                        Me.cmbModel.SelectedValue, _
                                                        UCase(Trim(Me.cmbEnterprise.Items.Item(Me.cmbEnterprise.SelectedIndex))), _
                                                        Me.mskBERCap.CtlText, _
                                                        Me.mskTarget.CtlText)
            If i > 0 Then
                '****************
                'Reset Data
                '****************
                Me.cmbCustomer.SelectedValue = 0
                Me.cmbModel.SelectedValue = 0
                Me.cmbEnterprise.SelectedIndex = 0
                SetMaskControlText(Me.mskBERCap, "")
                SetMaskControlText(Me.mskTarget, "")

                MessageBox.Show("Completed.", "Add/Update Target", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
            '**********************
            'Refresh DataGrid
            '**********************
            dt1 = Me.GobjModelTarget.GetAllModelTarget()
            Me.SetDataGrid_ModelTarger(dt1)
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Add/Update Target Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
            Me.Enabled = True
            Cursor.Current = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    '*********************************************************


End Class
