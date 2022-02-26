Option Explicit On 

Namespace Gui
    Public Class SyxCollectAccessories
        Inherits System.Windows.Forms.Form

        Private _iScreenDCodeID As Integer  '3409= Receiving; 3764= Pretest 
        Public _booCancel As Boolean = True
        Public _dtSelectAccessories As New DataTable()
        Private _iModelID As Integer
        Private _iDeviceID As Integer
        Private _iProdID As Integer
        Private _dtAccessories As DataTable
        Private _objSyx As New PSS.Data.Buisness.Syx()
        Private _objBilling As New PSS.Data.Buisness.DeviceBilling()


#Region " Windows Form Designer generated code "

        Public Sub New(ByVal iScreenID As Integer, ByVal iModelID As Integer, ByVal iDeviceID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _iScreenDCodeID = iScreenID
            _iModelID = iModelID
            _iDeviceID = iDeviceID
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
        Friend WithEvents pnlAccessories As System.Windows.Forms.Panel
        Friend WithEvents btnCompleted As System.Windows.Forms.Button
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.pnlAccessories = New System.Windows.Forms.Panel()
            Me.btnCompleted = New System.Windows.Forms.Button()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            '
            'pnlAccessories
            '
            Me.pnlAccessories.AutoScroll = True
            Me.pnlAccessories.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlAccessories.Location = New System.Drawing.Point(16, 40)
            Me.pnlAccessories.Name = "pnlAccessories"
            Me.pnlAccessories.Size = New System.Drawing.Size(680, 408)
            Me.pnlAccessories.TabIndex = 0
            '
            'btnCompleted
            '
            Me.btnCompleted.Location = New System.Drawing.Point(552, 8)
            Me.btnCompleted.Name = "btnCompleted"
            Me.btnCompleted.Size = New System.Drawing.Size(104, 23)
            Me.btnCompleted.TabIndex = 1
            Me.btnCompleted.Text = "Completed"
            '
            'btnCancel
            '
            Me.btnCancel.Location = New System.Drawing.Point(424, 8)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(104, 23)
            Me.btnCancel.TabIndex = 2
            Me.btnCancel.Text = "Cancel"
            '
            'SyxCollectAccessories
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(712, 462)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancel, Me.btnCompleted, Me.pnlAccessories})
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "SyxCollectAccessories"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Collect Accessories"
            Me.ResumeLayout(False)

        End Sub

#End Region

        '****************************************************************************************************
        Private Sub SyxCollectAccessories_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim objSyxRec As New PSS.Data.Buisness.SyxReceivingShipping()
            Try

                '_dtSelectAccessories = objSyxRec.GetDeviceAccessoriesTemplate()
                _dtSelectAccessories = Me._objSyx.gettdevicebill(Me._iDeviceID)

                If _iScreenDCodeID = 3409 Then 'Receiving Screen 1=Service; 2=Part; 3=Accessory
                    Me.Text = "Collect Accessories"
                    _dtAccessories = objSyxRec.GetModelAccessories(_iModelID, "3")
                ElseIf _iScreenDCodeID = 3764 Then 'Pretest
                    Me.Text = "Collect Accessories / Parts"
                    _dtAccessories = objSyxRec.GetModelAccessories(_iModelID, "2,3")
                End If

                If _dtAccessories.Rows.Count = 0 Then
                    'Dim dr As DataRow
                    'dr = Me._objBilling.GetDeviceData(Me._iDeviceID)
                    'MsgBox("No parts, service or accessories map to this model" & dr("Model_Desc") & ". Please contact IT for further assist.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Information")
                    'MsgBox("No parts, service or accessories map to this model. Please notify customer department or IT.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Information")
                    Me._booCancel = False : Me.Close()
                Else
                    _iProdID = Me._dtAccessories.Rows(0)("Prod_ID")
                    Me.pnlAccessories.AutoScroll = True
                    Me.CreateButtons()
                    Me.HighLightSelectedButtons()
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "SyxCollectAccessories_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                objSyxRec = Nothing
            End Try
        End Sub

        '****************************************************************************************************
        Private Sub CreateButtons()
            Const btnWidth = 120
            Const btnHeight = 50
            Const iColLength = 6
            Dim R1 As DataRow
            Dim cBill() As Button
            Dim i, iPnlLeft, iPnlWidth, btnLeft, btnTop, colCount As Integer

            Try
                colCount = 0
                iPnlLeft = Me.pnlAccessories.Left
                iPnlWidth = Me.Width - 48

                ReDim cBill(Me._dtAccessories.Rows.Count)

                btnLeft = 5 : btnTop = 5

                For i = 0 To _dtAccessories.Rows.Count - 1
                    R1 = _dtAccessories.Rows(i)
                    cBill(i) = New System.Windows.Forms.Button()
                    With cBill(i)
                        .Text = R1("BillCode_Desc")
                        .Size = New Size(btnWidth, btnHeight)
                        colCount += 1
                        .Location = New Point(btnLeft, btnTop)
                        .Visible = True

                        .Tag = R1("BillCode_ID")
                        .Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                        AddHandler .Click, AddressOf Me.ButtonClick
                    End With

                    If colCount > iColLength Then
                        btnLeft = btnLeft + btnWidth + 5
                        btnTop = 5
                        colCount = 0
                    Else
                        btnTop = btnTop + btnHeight + 5
                    End If
                Next i

                Me.pnlAccessories.Controls.AddRange(cBill)
            Catch e1 As Exception
                MessageBox.Show(e1.ToString, "CreateBillingButtons", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                R1 = Nothing
                cBill = Nothing
            End Try
        End Sub

        '****************************************************************************************************
        Private Sub ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim R1, drNewRow As DataRow
            Dim BillCode_ID, Fail_ID, Repair_ID, Shift_ID, User_ID, EmpNo As Integer
            Dim Dbill_RegPartPrice, DBill_AvgCost, DBill_StdCost, DBill_InvoiceAmt As Decimal
            Dim Part_Number As String

            Try
                R1 = Me._dtAccessories.Select("Billcode_ID = " & CInt(sender.tag.ToString))(0)
                If R1("PSPrice_Number").ToString.Trim.ToLower = "syxtemp" AndAlso Me._dtSelectAccessories.Select("Billcode_ID = " & sender.tag.ToString).Length = 0 AndAlso Me.CollectPartAndReplaceTempPartInBOM(CInt(sender.tag.ToString), False) = False Then Exit Sub
                R1 = Me._dtAccessories.Select("Billcode_ID = " & CInt(sender.tag.ToString))(0)

                Shift_ID = Core.ApplicationUser.IDShift
                User_ID = Core.ApplicationUser.IDuser
                EmpNo = Core.ApplicationUser.NumberEmp
                Fail_ID = 0
                Repair_ID = 0

                BillCode_ID = CInt(sender.tag.ToString)
                DBill_AvgCost = R1("PSPrice_AvgCost")
                DBill_StdCost = R1("PSPrice_StndCost")
                DBill_InvoiceAmt = 0      'DBill_InvoiceAmt = R1("DBill_InvoiceAmt")
                Part_Number = R1("PSPrice_Number")
                Dbill_RegPartPrice = R1("PSPrice_StndCost")

                If Me._dtSelectAccessories.Select("Billcode_ID = " & CInt(sender.tag.ToString)).Length > 0 Then
                    Me._dtSelectAccessories.Rows.Remove(Me._dtSelectAccessories.Select("Billcode_ID = " & CInt(sender.tag.ToString))(0))
                    Me._dtSelectAccessories.AcceptChanges()
                    If _iScreenDCodeID = 3764 Then 'Pretest 
                        Me._objSyx.InsertRemovetDeviceBill(Me._iDeviceID, Dbill_RegPartPrice, DBill_AvgCost, DBill_StdCost, DBill_InvoiceAmt, BillCode_ID, Part_Number, Fail_ID, Repair_ID, User_ID, False)
                        Me._objBilling.InsertPartTransaction(Me._iDeviceID, BillCode_ID, User_ID, EmpNo, Shift_ID, Part_Number, -1, Me._iScreenDCodeID)
                    End If
                Else
                    drNewRow = Me._dtSelectAccessories.NewRow
                    drNewRow("Billcode_ID") = CInt(sender.tag.ToString)
                    drNewRow("Part_Number") = Part_Number
                    drNewRow("DBill_AvgCost") = DBill_AvgCost
                    drNewRow("DBill_StdCost") = DBill_StdCost
                    drNewRow("DBill_InvoiceAmt") = DBill_InvoiceAmt
                    drNewRow("Dbill_RegPartPrice") = Dbill_RegPartPrice
                    drNewRow("Fail_ID") = Fail_ID
                    drNewRow("Repair_ID") = Repair_ID
                    Me._dtSelectAccessories.Rows.Add(drNewRow)
                    Me._dtSelectAccessories.AcceptChanges()
                    If _iScreenDCodeID = 3764 Then 'Pretest 
                        Me._objSyx.InsertRemovetDeviceBill(Me._iDeviceID, Dbill_RegPartPrice, DBill_AvgCost, DBill_StdCost, DBill_InvoiceAmt, BillCode_ID, Part_Number, Fail_ID, Repair_ID, User_ID, True)
                        Me._objBilling.InsertPartTransaction(Me._iDeviceID, BillCode_ID, User_ID, EmpNo, Shift_ID, Part_Number, 1, Me._iScreenDCodeID)
                    End If
                End If

                Me.HighLightSelectedButtons()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "BillingButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True
            End Try
        End Sub

        '****************************************************************************************************
        Private Function CollectPartAndReplaceTempPartInBOM(ByVal iBillcodeID As Integer, ByVal booRVPart As Boolean) As Boolean
            Dim objColPartAndMapBOM As Gui.frmCollectPartAndRemapBOM
            Dim objSyxRec As New PSS.Data.Buisness.SyxReceivingShipping()
            Dim booResult As Boolean = False
            Dim iPspriceID As Integer = 0

            Try
                iPspriceID = Me._dtAccessories.Select("Billcode_ID = " & iBillcodeID)(0)("PSPrice_ID")
                objColPartAndMapBOM = New Gui.frmCollectPartAndRemapBOM(_iModelID, iBillcodeID, iPspriceID, booRVPart, Me._iProdID)
                objColPartAndMapBOM.ShowDialog()

                If objColPartAndMapBOM._booCancel = False Then booResult = True

                If objColPartAndMapBOM._booRefreshBOM = True Then
                    If _iScreenDCodeID = 3409 Then 'Receiving Screen 1=Service; 2=Part; 3=Accessory
                        _dtAccessories = objSyxRec.GetModelAccessories(_iModelID, "3")
                    ElseIf _iScreenDCodeID = 3764 Then 'Pretest
                        _dtAccessories = objSyxRec.GetModelAccessories(_iModelID, "2,3")
                    End If
                End If

                Return booResult
            Catch ex As Exception
                Throw ex
            Finally
                objSyxRec = Nothing
                If Not IsNothing(objColPartAndMapBOM) Then
                    objColPartAndMapBOM.Dispose() : objColPartAndMapBOM = Nothing
                End If
            End Try
        End Function

        '****************************************************************************************************
        Private Sub HighLightSelectedButtons()
            Dim i As Integer = 0

            Try
                For i = 0 To Me.pnlAccessories.Controls.Count - 1
                    Me.pnlAccessories.Controls(i).ForeColor = Color.Blue

                    If Me._dtSelectAccessories.Select("Billcode_ID = " & Me.pnlAccessories.Controls(i).Tag).Length > 0 Then
                        Me.pnlAccessories.Controls(i).ForeColor = Color.Blue
                    Else
                        Me.pnlAccessories.Controls(i).ForeColor = Color.Black
                    End If

                Next i
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '****************************************************************************************************
        Private Sub btnCompleted_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompleted.Click
            Me._booCancel = False
            Me.Close()
        End Sub

        '****************************************************************************************************
        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Me.Close()
        End Sub
        '****************************************************************************************************

    End Class
End Namespace