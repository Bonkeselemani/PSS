Public Class frmCompare_Consumed_AutoBilled_Revenue
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbCustomer As PSS.Gui.Controls.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbModel As PSS.Gui.Controls.ComboBox
    Friend WithEvents cmdLevel_2_3 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmd563RevRep As System.Windows.Forms.Button
    Friend WithEvents btn563NoSlvg As System.Windows.Forms.Button
    Friend WithEvents btn563SlvgOnly As System.Windows.Forms.Button
    Friend WithEvents btn563PreBillInWIP As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btn563SlvgOnly = New System.Windows.Forms.Button()
        Me.btn563NoSlvg = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmdLevel_2_3 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmd563RevRep = New System.Windows.Forms.Button()
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpFromDate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbModel = New PSS.Gui.Controls.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbCustomer = New PSS.Gui.Controls.ComboBox()
        Me.btn563PreBillInWIP = New System.Windows.Forms.Button()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.AddRange(New System.Windows.Forms.Control() {Me.btn563SlvgOnly, Me.btn563NoSlvg, Me.Label6, Me.cmdLevel_2_3, Me.Label2, Me.Label5, Me.cmd563RevRep, Me.dtpToDate, Me.dtpFromDate, Me.Label4, Me.cmbModel, Me.Label1, Me.Label3, Me.cmbCustomer})
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(504, 376)
        Me.Panel3.TabIndex = 68
        '
        'btn563SlvgOnly
        '
        Me.btn563SlvgOnly.BackColor = System.Drawing.Color.Gold
        Me.btn563SlvgOnly.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn563SlvgOnly.ForeColor = System.Drawing.Color.Black
        Me.btn563SlvgOnly.Location = New System.Drawing.Point(163, 328)
        Me.btn563SlvgOnly.Name = "btn563SlvgOnly"
        Me.btn563SlvgOnly.Size = New System.Drawing.Size(276, 31)
        Me.btn563SlvgOnly.TabIndex = 71
        Me.btn563SlvgOnly.Text = "563 Revenue Report (Salvage Only)"
        '
        'btn563NoSlvg
        '
        Me.btn563NoSlvg.BackColor = System.Drawing.Color.SteelBlue
        Me.btn563NoSlvg.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn563NoSlvg.ForeColor = System.Drawing.Color.White
        Me.btn563NoSlvg.Location = New System.Drawing.Point(163, 288)
        Me.btn563NoSlvg.Name = "btn563NoSlvg"
        Me.btn563NoSlvg.Size = New System.Drawing.Size(276, 31)
        Me.btn563NoSlvg.TabIndex = 70
        Me.btn563NoSlvg.Text = "563 Revenue Report (Exclude Salvage)"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(416, 80)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 16)
        Me.Label6.TabIndex = 69
        Me.Label6.Text = "(Optional)"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdLevel_2_3
        '
        Me.cmdLevel_2_3.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdLevel_2_3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLevel_2_3.ForeColor = System.Drawing.Color.White
        Me.cmdLevel_2_3.Location = New System.Drawing.Point(164, 232)
        Me.cmdLevel_2_3.Name = "cmdLevel_2_3"
        Me.cmdLevel_2_3.Size = New System.Drawing.Size(276, 31)
        Me.cmdLevel_2_3.TabIndex = 68
        Me.cmdLevel_2_3.Text = "563 Revenue Report (Labor Level > 1)"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Black
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Yellow
        Me.Label2.Location = New System.Drawing.Point(-1, -1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(505, 33)
        Me.Label2.TabIndex = 67
        Me.Label2.Text = "563 REVENUE"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(4, 136)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(160, 16)
        Me.Label5.TabIndex = 65
        Me.Label5.Text = "To Ship Work Date:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmd563RevRep
        '
        Me.cmd563RevRep.BackColor = System.Drawing.Color.SteelBlue
        Me.cmd563RevRep.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd563RevRep.ForeColor = System.Drawing.Color.White
        Me.cmd563RevRep.Location = New System.Drawing.Point(164, 176)
        Me.cmd563RevRep.Name = "cmd563RevRep"
        Me.cmd563RevRep.Size = New System.Drawing.Size(276, 31)
        Me.cmd563RevRep.TabIndex = 66
        Me.cmd563RevRep.Text = "563 REVENUE REPORT"
        '
        'dtpToDate
        '
        Me.dtpToDate.CustomFormat = "yyyy-MM-dd"
        Me.dtpToDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToDate.Location = New System.Drawing.Point(175, 136)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(104, 21)
        Me.dtpToDate.TabIndex = 64
        Me.dtpToDate.Value = New Date(2005, 1, 24, 0, 0, 0, 0)
        '
        'dtpFromDate
        '
        Me.dtpFromDate.CustomFormat = "yyyy-MM-dd"
        Me.dtpFromDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFromDate.Location = New System.Drawing.Point(175, 104)
        Me.dtpFromDate.Name = "dtpFromDate"
        Me.dtpFromDate.Size = New System.Drawing.Size(104, 21)
        Me.dtpFromDate.TabIndex = 62
        Me.dtpFromDate.Value = New Date(2007, 3, 16, 0, 0, 0, 0)
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(5, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(160, 16)
        Me.Label4.TabIndex = 63
        Me.Label4.Text = "From Ship Work Date:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbModel
        '
        Me.cmbModel.AutoComplete = True
        Me.cmbModel.BackColor = System.Drawing.SystemColors.Window
        Me.cmbModel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbModel.ForeColor = System.Drawing.Color.Black
        Me.cmbModel.Location = New System.Drawing.Point(175, 72)
        Me.cmbModel.Name = "cmbModel"
        Me.cmbModel.Size = New System.Drawing.Size(235, 21)
        Me.cmbModel.TabIndex = 61
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(84, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.TabIndex = 58
        Me.Label1.Text = "Customer:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(108, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 60
        Me.Label3.Text = "Model:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbCustomer
        '
        Me.cmbCustomer.AutoComplete = True
        Me.cmbCustomer.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCustomer.ForeColor = System.Drawing.Color.Black
        Me.cmbCustomer.Location = New System.Drawing.Point(174, 40)
        Me.cmbCustomer.Name = "cmbCustomer"
        Me.cmbCustomer.Size = New System.Drawing.Size(235, 21)
        Me.cmbCustomer.TabIndex = 59
        '
        'btn563PreBillInWIP
        '
        Me.btn563PreBillInWIP.BackColor = System.Drawing.Color.SteelBlue
        Me.btn563PreBillInWIP.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn563PreBillInWIP.ForeColor = System.Drawing.Color.White
        Me.btn563PreBillInWIP.Location = New System.Drawing.Point(24, 400)
        Me.btn563PreBillInWIP.Name = "btn563PreBillInWIP"
        Me.btn563PreBillInWIP.Size = New System.Drawing.Size(416, 31)
        Me.btn563PreBillInWIP.TabIndex = 71
        Me.btn563PreBillInWIP.Text = "563 Revenue Report (Pre-bill Devices In WIP)"
        '
        'frmCompare_Consumed_AutoBilled_Revenue
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(640, 510)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btn563PreBillInWIP, Me.Panel3})
        Me.Name = "frmCompare_Consumed_AutoBilled_Revenue"
        Me.Text = "563 REVENUE"
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmCompare_Consumed_AutoBilled_Revenue_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim objGeneric As New PSS.Data.Buisness.Generic()

        Try

            Me.dtpFromDate.Text = Now
            Me.dtpToDate.Text = Now
            objGeneric.LoadModels(Me.cmbModel, 2)
            objGeneric.LoadCustomers(Me.cmbCustomer, 2)

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            objGeneric = Nothing
        End Try
    End Sub

    '*******************************************************************
    Private Sub cmd563RevRep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd563RevRep.Click
        Dim i As Integer = 0
        Dim objAutoBill As New PSS.Data.Buisness.AutoBill()

        Try

            If Me.cmbCustomer.SelectedValue = 0 Then
                MessageBox.Show("Please select a Customer.", "Select Customer", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            If Me.dtpFromDate.Text = "" Or Me.dtpToDate.Text = "" Then
                MessageBox.Show("Please select dates.", "Select Dates", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            If Me.dtpToDate.Text < Me.dtpFromDate.Text Then
                MessageBox.Show("'To Ship Work Date' must be greater than or equal to 'From Ship Work Date'.", "Select Dates", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            Me.Enabled = False

            i = objAutoBill.Create563ReveueReport(Me.cmbCustomer.SelectedValue, _
                                                          Me.cmbCustomer.SelectedItem(Me.cmbCustomer.DisplayMember), _
                                                          Me.cmbModel.SelectedValue, _
                                                          Me.dtpFromDate.Text, _
                                                          Me.dtpToDate.Text)


        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Create Report", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
            objAutoBill = Nothing
        End Try
    End Sub

    '*******************************************************************
    Private Sub cmdLevel_2_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLevel_2_3.Click
        Dim i As Integer = 0
        Dim objAutoBill As New PSS.Data.Buisness.AutoBill()
        Dim iNoSlvg_OR_Level2And3_Flg As Integer = 2    '2: Labor level is 2 and 3

        Try

            If Me.cmbCustomer.SelectedValue = 0 Then
                MessageBox.Show("Please select a Customer.", "Select Customer", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            If Me.dtpFromDate.Text = "" Or Me.dtpToDate.Text = "" Then
                MessageBox.Show("Please select dates.", "Select Dates", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            If Me.dtpToDate.Text < Me.dtpFromDate.Text Then
                MessageBox.Show("'To Ship Work Date' must be greater than or equal to 'From Ship Work Date'.", "Select Dates", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            Me.Enabled = False

            i = objAutoBill.Create563ReveueReportLevel2And3(Me.cmbCustomer.SelectedValue, _
                                                          Me.cmbCustomer.SelectedItem(Me.cmbCustomer.DisplayMember), _
                                                          Me.cmbModel.SelectedValue, _
                                                          Me.dtpFromDate.Text, _
                                                          Me.dtpToDate.Text, _
                                                          iNoSlvg_OR_Level2And3_Flg)


        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Create Report", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
            objAutoBill = Nothing
        End Try
    End Sub

    '*******************************************************************
    Private Sub btn563NoSlvg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn563NoSlvg.Click
        Dim i As Integer = 0
        Dim objAutoBill As New PSS.Data.Buisness.AutoBill()
        Dim iNoSlvg_OR_Level2And3_Flg As Integer = 1    '1:NoSalvage

        Try

            If Me.cmbCustomer.SelectedValue = 0 Then
                MessageBox.Show("Please select a Customer.", "Select Customer", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            If Me.dtpFromDate.Text = "" Or Me.dtpToDate.Text = "" Then
                MessageBox.Show("Please select dates.", "Select Dates", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            If Me.dtpToDate.Text < Me.dtpFromDate.Text Then
                MessageBox.Show("'To Ship Work Date' must be greater than or equal to 'From Ship Work Date'.", "Select Dates", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            Me.Enabled = False

            i = objAutoBill.Create563ReveueReportLevel2And3(Me.cmbCustomer.SelectedValue, _
                                                          Me.cmbCustomer.SelectedItem(Me.cmbCustomer.DisplayMember), _
                                                          Me.cmbModel.SelectedValue, _
                                                          Me.dtpFromDate.Text, _
                                                          Me.dtpToDate.Text, _
                                                          iNoSlvg_OR_Level2And3_Flg)


        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Create Report", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
            objAutoBill = Nothing
        End Try
    End Sub

    '*******************************************************************
    Private Sub btn563SlvgOnly_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn563SlvgOnly.Click
        Dim i As Integer = 0
        Dim objAutoBill As New PSS.Data.Buisness.AutoBill()
        Dim iNoSlvg_OR_Level2And3_Flg As Integer = 0    '0:Salvage Only

        Try

            If Me.cmbCustomer.SelectedValue = 0 Then
                MessageBox.Show("Please select a Customer.", "Select Customer", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            If Me.dtpFromDate.Text = "" Or Me.dtpToDate.Text = "" Then
                MessageBox.Show("Please select dates.", "Select Dates", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            If Me.dtpToDate.Text < Me.dtpFromDate.Text Then
                MessageBox.Show("'To Ship Work Date' must be greater than or equal to 'From Ship Work Date'.", "Select Dates", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            Me.Enabled = False

            i = objAutoBill.Create563ReveueReportLevel2And3(Me.cmbCustomer.SelectedValue, _
                                                          Me.cmbCustomer.SelectedItem(Me.cmbCustomer.DisplayMember), _
                                                          Me.cmbModel.SelectedValue, _
                                                          Me.dtpFromDate.Text, _
                                                          Me.dtpToDate.Text, _
                                                          iNoSlvg_OR_Level2And3_Flg)


        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Create Report", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
            objAutoBill = Nothing
        End Try
    End Sub

    '*******************************************************************
    Private Sub btn563PreBillInWIP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn563PreBillInWIP.Click
        Dim i As Integer = 0
        Dim objAutoBill As New PSS.Data.Buisness.AutoBill_Prebill_InWIP()
        Dim iNoSlvg_OR_Level2And3_Flg As Integer = 3    '3:InWIP have Pre-bill Lot

        Try
            If Me.cmbCustomer.SelectedValue = 0 Then
                MessageBox.Show("Please select a Customer.", "Select Customer", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            Me.Enabled = False

            i = objAutoBill.Create563ReveueReportLevel2And3(Me.cmbCustomer.SelectedValue, _
                                                          Me.cmbCustomer.SelectedItem(Me.cmbCustomer.DisplayMember), _
                                                          Me.cmbModel.SelectedValue, _
                                                          Me.dtpFromDate.Text, _
                                                          Me.dtpToDate.Text, _
                                                          iNoSlvg_OR_Level2And3_Flg)


        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Create Report", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
            objAutoBill = Nothing
        End Try
    End Sub

    '*******************************************************************


End Class
