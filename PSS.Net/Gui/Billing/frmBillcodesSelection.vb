Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.Billing
    Public Class frmBillcodesSelection
        Inherits System.Windows.Forms.Form

        Public _booCancel As Boolean = True
        Private _iBillRules As Integer
        Private _iBillTypeID As Integer
        Private _booMutipleSelection As Boolean = False
        Private _strNextWorkStation As String = ""
        Private _dtBilledData As DataTable
        Private _objDeviceBilling As PSS.Rules.Device

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal iDeviceID As Integer, _
                       Optional ByVal iBillTypeID As Integer = 1, _
                       Optional ByVal iBillRule As Integer = -1, _
                       Optional ByVal booMultipleSelection As Boolean = False, _
                       Optional ByVal strNextWorkstation As String = "")
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _booMutipleSelection = booMultipleSelection
            _strNextWorkStation = strNextWorkstation
            _objDeviceBilling = New PSS.Rules.Device(iDeviceID)

            'Default billrule to RUR
            If iBillRule = -1 Then iBillRule = 1
            _iBillRules = iBillRule
            _iBillTypeID = iBillTypeID

        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If

                If Not (IsNothing(_objDeviceBilling)) Then
                    _objDeviceBilling.Dispose()
                    _objDeviceBilling = Nothing
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        Friend WithEvents pnlBillButtons As System.Windows.Forms.Panel
        Friend WithEvents btnCompleted As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.pnlBillButtons = New System.Windows.Forms.Panel()
            Me.btnCompleted = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            '
            'pnlBillButtons
            '
            Me.pnlBillButtons.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.pnlBillButtons.BackColor = System.Drawing.SystemColors.Control
            Me.pnlBillButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlBillButtons.Location = New System.Drawing.Point(8, 40)
            Me.pnlBillButtons.Name = "pnlBillButtons"
            Me.pnlBillButtons.Size = New System.Drawing.Size(664, 464)
            Me.pnlBillButtons.TabIndex = 0
            '
            'btnCompleted
            '
            Me.btnCompleted.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnCompleted.BackColor = System.Drawing.Color.Gainsboro
            Me.btnCompleted.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCompleted.Location = New System.Drawing.Point(560, 8)
            Me.btnCompleted.Name = "btnCompleted"
            Me.btnCompleted.Size = New System.Drawing.Size(112, 24)
            Me.btnCompleted.TabIndex = 1
            Me.btnCompleted.Text = "Completed"
            '
            'frmBillcodesSelection
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(680, 517)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCompleted, Me.pnlBillButtons})
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "frmBillcodesSelection"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Billcode Selection"
            Me.ResumeLayout(False)

        End Sub

#End Region

        '******************************************************************************
        Private Sub frmRURBillcodes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                If _objDeviceBilling.ID = 0 Then
                    MessageBox.Show("Device ID is missing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.btnCompleted.Visible = False
                Else
                    _dtBilledData = _objDeviceBilling.Parts
                    CreateBillingButton()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmRURBillcodes_Load", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '******************************************************************************
        Private Sub CreateBillingButton()
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim cBill() As Button
            Dim i, iColCount As Integer

            Const iColLength As Integer = 6
            Const vBuffer As Integer = 5
            Const hBuffer As Integer = 5
            Const btnWidth = 120
            Const btnHeight = 50
            Dim btnLeft, btnTop As Int32

            Try
                dt = _objDeviceBilling.BillableBillcodes

                iColCount = 0
                ReDim cBill(dt.Rows.Count)

                btnLeft = hBuffer
                btnTop = vBuffer

                For i = 0 To dt.Rows.Count - 1
                    R1 = dt.Rows(i)

                    If CInt(R1("BillCode_Rule")) = Me._iBillRules AndAlso CInt(R1("BillType_ID")) = Me._iBillTypeID Then
                        cBill(i) = New System.Windows.Forms.Button()
                        With cBill(i)
                            .BackColor = Color.Wheat
                            .Text = R1("BillCode_Desc")
                            .Size = New Size(btnWidth, btnHeight)

                            iColCount += 1
                            .Location = New Point(btnLeft, btnTop)
                            .Visible = True

                            .Tag = R1("BillCode_ID")
                            .Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                            AddHandler .Click, AddressOf Me.billingClick

                            If _dtBilledData.Select("BillCode_ID = " & R1("BillCode_ID")).Length > 0 Then .ForeColor = Color.Blue
                        End With

                        If iColCount > iColLength Then
                            btnLeft = btnLeft + btnWidth + 5
                            btnTop = vBuffer
                            iColCount = 0
                        Else
                            btnTop = btnTop + btnHeight + 5
                        End If
                    End If
                Next i

                Me.pnlBillButtons.Controls.AddRange(cBill)

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
                R1 = Nothing
            End Try
        End Sub

        '******************************************************************************
        Private Sub billingClick(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim i As Integer

            Try
                '//Determine action to be performed
                If Me._dtBilledData.Select("Billcode_ID = " & sender.tag.ToString).Length > 0 Then
                    'Remove
                    Me._objDeviceBilling.DeletePart(CInt(sender.tag.ToString))
                    Me._objDeviceBilling.Update()

                Else
                    'Add
                    '************************************
                    'Not allow more than one selection
                    '************************************
                    If _booMutipleSelection = False Then
                        For i = 0 To Me.pnlBillButtons.Controls.Count - 1
                            If _dtBilledData.Select("Billcode_ID = " & Me.pnlBillButtons.Controls(i).Tag).Length > 0 Then
                                MessageBox.Show("Only allows to select one billcode.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Exit Sub
                            End If
                        Next i
                    End If

                    '************************************
                    Me._objDeviceBilling.AddPart(CInt(sender.tag.ToString))
                    Me._objDeviceBilling.Update()
                End If

                _dtBilledData = _objDeviceBilling.Parts
                For i = 0 To Me.pnlBillButtons.Controls.Count - 1
                    If _dtBilledData.Select("Billcode_ID = " & Me.pnlBillButtons.Controls(i).Tag).Length > 0 Then
                        Me.pnlBillButtons.Controls(i).ForeColor = Color.Blue
                        Me.ControlBox = False
                    Else
                        Me.pnlBillButtons.Controls(i).ForeColor = Color.Black
                    End If
                Next i

                HideShowControlBox()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "BillingButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************************
        Private Sub HideShowControlBox()
            Dim i As Integer

            Try
                Me.ControlBox = True
                For i = 0 To Me.pnlBillButtons.Controls.Count - 1
                    If _dtBilledData.Select("Billcode_ID = " & Me.pnlBillButtons.Controls(i).Tag).Length > 0 Then
                        Me.ControlBox = False : Exit For
                    End If
                Next i
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '******************************************************************************
        Private Sub btnCompleted_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompleted.Click
            Dim i As Integer
            Dim booHasSelection As Boolean = False

            Try

                For i = 0 To Me.pnlBillButtons.Controls.Count - 1
                    If _dtBilledData.Select("Billcode_ID = " & Me.pnlBillButtons.Controls(i).Tag).Length > 0 Then
                        booHasSelection = True : Exit For
                    End If
                Next i

                If booHasSelection = True Then
                    Me._booCancel = False
                    Me.Close()
                Else
                    MessageBox.Show("You must select at least one billcode.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnCompleted_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************************

    End Class
End Namespace
