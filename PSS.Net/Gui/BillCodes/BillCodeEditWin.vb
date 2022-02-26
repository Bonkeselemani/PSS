
Imports PSS.Rules

Namespace Gui
    Public Class BillCodeEditWin
        Inherits System.Windows.Forms.Form

        Private _billCode As Integer = 0

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal billCode As Integer)
            MyBase.New()
            Try
                'This call is required by the Windows Form Designer.
                InitializeComponent()

                Me.LoadValues()

                If billCode <> 0 Then
                    Me._billCode = billCode
                    Me.LoadBillCode()
            End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "new()", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
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
        Friend WithEvents lblDesc As System.Windows.Forms.Label
        Friend WithEvents txtDesc As System.Windows.Forms.TextBox
        Friend WithEvents lblBillRule As System.Windows.Forms.Label
        Friend WithEvents lblBillType As System.Windows.Forms.Label
        Friend WithEvents lblFailCode As System.Windows.Forms.Label
        Friend WithEvents lblRepCode As System.Windows.Forms.Label
        Friend WithEvents btnUpdate As System.Windows.Forms.Button
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents cboBillRule As PSS.Gui.Controls.ComboBox
        Friend WithEvents cboBillType As PSS.Gui.Controls.ComboBox
        Friend WithEvents cboFailCode As PSS.Gui.Controls.ComboBox
        Friend WithEvents cboRepCode As PSS.Gui.Controls.ComboBox
        Friend WithEvents cboDeviceType As PSS.Gui.Controls.ComboBox
        Friend WithEvents lblDevice As System.Windows.Forms.Label
        Friend WithEvents chkAggregate As System.Windows.Forms.CheckBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.lblDesc = New System.Windows.Forms.Label()
            Me.txtDesc = New System.Windows.Forms.TextBox()
            Me.lblBillRule = New System.Windows.Forms.Label()
            Me.lblBillType = New System.Windows.Forms.Label()
            Me.lblFailCode = New System.Windows.Forms.Label()
            Me.lblRepCode = New System.Windows.Forms.Label()
            Me.btnUpdate = New System.Windows.Forms.Button()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.cboBillRule = New PSS.Gui.Controls.ComboBox()
            Me.cboBillType = New PSS.Gui.Controls.ComboBox()
            Me.cboFailCode = New PSS.Gui.Controls.ComboBox()
            Me.cboRepCode = New PSS.Gui.Controls.ComboBox()
            Me.cboDeviceType = New PSS.Gui.Controls.ComboBox()
            Me.lblDevice = New System.Windows.Forms.Label()
            Me.chkAggregate = New System.Windows.Forms.CheckBox()
            Me.SuspendLayout()
            '
            'lblDesc
            '
            Me.lblDesc.Location = New System.Drawing.Point(8, 8)
            Me.lblDesc.Name = "lblDesc"
            Me.lblDesc.Size = New System.Drawing.Size(176, 16)
            Me.lblDesc.TabIndex = 0
            Me.lblDesc.Text = "Description"
            '
            'txtDesc
            '
            Me.txtDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDesc.Location = New System.Drawing.Point(8, 24)
            Me.txtDesc.Name = "txtDesc"
            Me.txtDesc.Size = New System.Drawing.Size(272, 21)
            Me.txtDesc.TabIndex = 0
            Me.txtDesc.Text = ""
            '
            'lblBillRule
            '
            Me.lblBillRule.Location = New System.Drawing.Point(8, 104)
            Me.lblBillRule.Name = "lblBillRule"
            Me.lblBillRule.Size = New System.Drawing.Size(120, 16)
            Me.lblBillRule.TabIndex = 2
            Me.lblBillRule.Text = "Bill Rule"
            '
            'lblBillType
            '
            Me.lblBillType.Location = New System.Drawing.Point(8, 152)
            Me.lblBillType.Name = "lblBillType"
            Me.lblBillType.Size = New System.Drawing.Size(120, 16)
            Me.lblBillType.TabIndex = 4
            Me.lblBillType.Text = "Bill Type"
            '
            'lblFailCode
            '
            Me.lblFailCode.Location = New System.Drawing.Point(16, 200)
            Me.lblFailCode.Name = "lblFailCode"
            Me.lblFailCode.Size = New System.Drawing.Size(120, 16)
            Me.lblFailCode.TabIndex = 6
            Me.lblFailCode.Text = "Failure Code"
            '
            'lblRepCode
            '
            Me.lblRepCode.Location = New System.Drawing.Point(8, 248)
            Me.lblRepCode.Name = "lblRepCode"
            Me.lblRepCode.Size = New System.Drawing.Size(120, 16)
            Me.lblRepCode.TabIndex = 8
            Me.lblRepCode.Text = "Repair Code"
            '
            'btnUpdate
            '
            Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.btnUpdate.Location = New System.Drawing.Point(16, 344)
            Me.btnUpdate.Name = "btnUpdate"
            Me.btnUpdate.Size = New System.Drawing.Size(120, 24)
            Me.btnUpdate.TabIndex = 6
            Me.btnUpdate.Text = "Insert / Update"
            '
            'btnCancel
            '
            Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.btnCancel.Location = New System.Drawing.Point(152, 344)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(120, 24)
            Me.btnCancel.TabIndex = 7
            Me.btnCancel.Text = "Cancel"
            '
            'cboBillRule
            '
            Me.cboBillRule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboBillRule.Location = New System.Drawing.Point(8, 120)
            Me.cboBillRule.Name = "cboBillRule"
            Me.cboBillRule.Size = New System.Drawing.Size(272, 21)
            Me.cboBillRule.TabIndex = 2
            '
            'cboBillType
            '
            Me.cboBillType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboBillType.Location = New System.Drawing.Point(8, 168)
            Me.cboBillType.Name = "cboBillType"
            Me.cboBillType.Size = New System.Drawing.Size(272, 21)
            Me.cboBillType.TabIndex = 3
            '
            'cboFailCode
            '
            Me.cboFailCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboFailCode.Location = New System.Drawing.Point(8, 216)
            Me.cboFailCode.Name = "cboFailCode"
            Me.cboFailCode.Size = New System.Drawing.Size(272, 21)
            Me.cboFailCode.TabIndex = 4
            '
            'cboRepCode
            '
            Me.cboRepCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboRepCode.Location = New System.Drawing.Point(8, 264)
            Me.cboRepCode.Name = "cboRepCode"
            Me.cboRepCode.Size = New System.Drawing.Size(272, 21)
            Me.cboRepCode.TabIndex = 5
            '
            'cboDeviceType
            '
            Me.cboDeviceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboDeviceType.Location = New System.Drawing.Point(8, 72)
            Me.cboDeviceType.Name = "cboDeviceType"
            Me.cboDeviceType.Size = New System.Drawing.Size(272, 21)
            Me.cboDeviceType.TabIndex = 1
            '
            'lblDevice
            '
            Me.lblDevice.Location = New System.Drawing.Point(8, 56)
            Me.lblDevice.Name = "lblDevice"
            Me.lblDevice.Size = New System.Drawing.Size(120, 16)
            Me.lblDevice.TabIndex = 10
            Me.lblDevice.Text = "Device"
            '
            'chkAggregate
            '
            Me.chkAggregate.Location = New System.Drawing.Point(8, 303)
            Me.chkAggregate.Name = "chkAggregate"
            Me.chkAggregate.Size = New System.Drawing.Size(160, 24)
            Me.chkAggregate.TabIndex = 11
            Me.chkAggregate.Text = "Aggregate"
            '
            'BillCodeEditWin
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
            Me.ClientSize = New System.Drawing.Size(290, 390)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkAggregate, Me.cboDeviceType, Me.lblDevice, Me.cboRepCode, Me.cboFailCode, Me.cboBillType, Me.cboBillRule, Me.btnCancel, Me.btnUpdate, Me.lblRepCode, Me.lblFailCode, Me.lblBillType, Me.lblBillRule, Me.txtDesc, Me.lblDesc})
            Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
            Me.Name = "BillCodeEditWin"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "BillCodeEditWin"
            Me.TopMost = True
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub LoadValues()
            Dim r As DataRow
            Me.cboBillType.AddItem(0, "No Value")
            For Each r In BillCode.GetBillTypes.Rows
                Me.cboBillType.AddItem(r(0), r(1))
            Next
            Me.cboBillType.SelectedIndex = 0

            For Each r In BillCode.GetDeviceTypes.Rows
                Me.cboDeviceType.AddItem(r(0), r(1))
            Next
            Me.cboDeviceType.SelectedIndex = 0

            Me.cboFailCode.AddItem(0, "No Value")
            For Each r In BillCode.GetFailCodes.Rows
                Me.cboFailCode.AddItem(r(0), r(1))
            Next
            Me.cboFailCode.SelectedIndex = 0

            Me.cboRepCode.AddItem(0, "No Value")
            For Each r In BillCode.GetRepCodes(Me.cboDeviceType.GetID).Rows
                Me.cboRepCode.AddItem(r(0), r(1))
            Next
            Me.cboRepCode.SelectedIndex = 0

            Me.cboBillRule.AddItem(0, "No Value")
            For Each r In BillCode.GetBillRules.Rows
                Me.cboBillRule.AddItem(r(0), r(1))
            Next
            Me.cboBillRule.SelectedIndex = 0
        End Sub

        Private Sub LoadBillCode()
            Dim dr As DataRow = BillCode.GetBillCode(_billCode)
            Try
                Me.txtDesc.Text = Convert.ToString(dr(1))
                Me.cboDeviceType.Text = Convert.ToString(dr("prod_desc"))
                Me.cboBillRule.Text = Convert.ToString(dr(2))
                Me.cboBillType.Text = Convert.ToString(dr(3))
                Me.cboFailCode.Text = Convert.ToString(dr(4))
                Me.cboRepCode.Text = Convert.ToString(dr(5))
                If Not IsDBNull(dr("AggBill")) AndAlso dr("AggBill").ToString.Trim = "1" Then Me.chkAggregate.Checked = True Else Me.chkAggregate.Checked = False
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '********************************************************************************************
        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Dim iExistedQty, iAggBilling As Integer

            Try
                If Me.cboBillType.GetID = 0 Then
                    MessageBox.Show("Please select Bill Type.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboBillType.Focus()
                Else
                    If Me.chkAggregate.Checked Then iAggBilling = 1 Else iAggBilling = 0
                    If _billCode = 0 Then
                        '****************************************************
                        'Added on 11/12/2009
                        'Check existing of billcode description by product ID
                        'Reason: eliminate duplicate in lbillcode table.
                        '****************************************************
                        iExistedQty = PSS.Data.Buisness.Generic.GetBillcodeCount(Me.txtDesc.Text, Me.cboDeviceType.GetID)
                        If Not IsDBNull(iExistedQty) AndAlso iExistedQty > 0 Then
                            MessageBox.Show("Bill code description of selected device type existed in the system.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtDesc.SelectAll() : Me.txtDesc.Focus()
                        Else
                            BillCode.InsertBillCode(Me.txtDesc.Text, Me.cboDeviceType.GetID, Me.cboBillRule.GetID, Me.cboBillType.GetID, Me.cboFailCode.GetID, Me.cboRepCode.GetID, iAggBilling)
                        End If
                        '****************************************************
                    Else
                        BillCode.UpdateBillCode(Me.txtDesc.Text, Me.cboDeviceType.GetID, Me.cboBillRule.GetID, Me.cboBillType.GetID, Me.cboFailCode.GetID, Me.cboRepCode.GetID, _billCode, iAggBilling)
                    End If

                    Me.Close()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Update", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************************
        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Me.Close()
        End Sub

        Private Sub cboDeviceType_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDeviceType.Leave
            Dim r As DataRow
            Try
                If Me.cboDeviceType.GetID > 0 Then
                    Me.cboRepCode.Items.Clear()
                    Me.cboRepCode.AddItem(0, "No Value")
                    For Each r In BillCode.GetRepCodes(Me.cboDeviceType.GetID).Rows
                        Me.cboRepCode.AddItem(r(0), r(1))
                    Next
                    Me.cboRepCode.SelectedIndex = 0
                Else
                    Me.cboRepCode.Items.Clear()
                    Me.cboRepCode.AddItem(0, "No Value")
                    Me.cboRepCode.SelectedIndex = 0
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Err", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                r = Nothing
            End Try
        End Sub


    End Class
End Namespace