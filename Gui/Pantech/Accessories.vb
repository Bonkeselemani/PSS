Option Explicit On 

Imports PSS.Data.Buisness
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO

Namespace Gui.Pantech
    Public Class Accessories
        Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

        Private _iDeviceID As Integer
        Private _strIMEI As String
        Private _bReceiving As Boolean
        Private _objAccessories As PSS.Data.Buisness.Accessories
        Private _bCancelClosing = False
        Private Const _strReportDir As String = "C:\Label\PSSI\"
        Private Const _strReportName As String = "PSSI Customer Equipment Checklist Push.rpt"

        Public Enum ShipType
            PANTECH = 1
            QC = 2
        End Enum

        Private _st As ShipType = ShipType.PANTECH

        Public Sub New(ByVal strIMEI As String, ByVal bReceiving As Boolean, ByVal st As ShipType)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._strIMEI = strIMEI
            Me._bReceiving = bReceiving
            Me._st = st
            Me._objAccessories = New PSS.Data.Buisness.Accessories()
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
        Friend WithEvents chklstAccessories As System.Windows.Forms.CheckedListBox
        Friend WithEvents btnOK As System.Windows.Forms.Button
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents lblAccessories As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.chklstAccessories = New System.Windows.Forms.CheckedListBox()
            Me.btnOK = New System.Windows.Forms.Button()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.lblAccessories = New System.Windows.Forms.Label()
            Me.SuspendLayout()
            '
            'chklstAccessories
            '
            Me.chklstAccessories.BackColor = System.Drawing.Color.FloralWhite
            Me.chklstAccessories.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chklstAccessories.ForeColor = System.Drawing.Color.Blue
            Me.chklstAccessories.Location = New System.Drawing.Point(160, 16)
            Me.chklstAccessories.Name = "chklstAccessories"
            Me.chklstAccessories.Size = New System.Drawing.Size(216, 139)
            Me.chklstAccessories.TabIndex = 0
            '
            'btnOK
            '
            Me.btnOK.BackColor = System.Drawing.Color.SteelBlue
            Me.btnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnOK.ForeColor = System.Drawing.Color.White
            Me.btnOK.Location = New System.Drawing.Point(40, 184)
            Me.btnOK.Name = "btnOK"
            Me.btnOK.Size = New System.Drawing.Size(104, 48)
            Me.btnOK.TabIndex = 1
            Me.btnOK.Text = "OK"
            '
            'btnCancel
            '
            Me.btnCancel.BackColor = System.Drawing.Color.SteelBlue
            Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCancel.ForeColor = System.Drawing.Color.White
            Me.btnCancel.Location = New System.Drawing.Point(240, 184)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(104, 48)
            Me.btnCancel.TabIndex = 2
            Me.btnCancel.Text = "Cancel"
            '
            'lblAccessories
            '
            Me.lblAccessories.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblAccessories.ForeColor = System.Drawing.Color.Black
            Me.lblAccessories.Location = New System.Drawing.Point(8, 16)
            Me.lblAccessories.Name = "lblAccessories"
            Me.lblAccessories.Size = New System.Drawing.Size(136, 23)
            Me.lblAccessories.TabIndex = 3
            Me.lblAccessories.Text = "Select Accessories:"
            '
            'Accessories
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.LightSteelBlue
            Me.CancelButton = Me.btnCancel
            Me.ClientSize = New System.Drawing.Size(384, 246)
            Me.ControlBox = False
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblAccessories, Me.btnCancel, Me.btnOK, Me.chklstAccessories})
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
            Me.Name = "Accessories"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Accessories"
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub Accessories_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                Me._iDeviceID = Me._objAccessories.GetDeviceID(Me._strIMEI)

                SetupAccessories()

                If Me._bReceiving Then
                    Me.Text = String.Format("Received Accessories for IMEI {0}", Me._strIMEI)
                Else
                    Me.Text = String.Format("Accessories Shipped with IMEI {0}", Me._strIMEI)

                    Me._objAccessories.ResetToBeShippedAccessories(Me._iDeviceID, Convert.ToInt32(Me._st))
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Accessories_Load", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub SetupAccessories()
            Dim dt As DataTable

            Try
                Me.chklstAccessories.DataSource = Nothing

                If Me._bReceiving Then
                    dt = Me._objAccessories.GetReceivingAccessories()
                Else
                    dt = Me._objAccessories.GetToBeShippedAccessories(Me._strIMEI)
                End If

                If dt.Rows.Count > 0 Then
                    Me.chklstAccessories.DataSource = dt.DefaultView
                    Me.chklstAccessories.DisplayMember = "Description"
                    Me.chklstAccessories.ValueMember = "AccessoryID"
                    Me.chklstAccessories.SelectedIndex = -1
                Else
                    If Me._bReceiving Then
                        MessageBox.Show("No accessory data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show(String.Format("No accessory data for IMEI {0}.", Me._strIMEI), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    Me.btnOK.Enabled = False
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
            Try
                Me.Enabled = False
                Me.Cursor = Cursors.WaitCursor

                If Me.chklstAccessories.CheckedItems.Count = 0 Then
                    MessageBox.Show("You must check at least one accessory.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Else
                    If Not Me._bReceiving Then Me._objAccessories.ResetToBeShippedAccessories(Me._iDeviceID, Convert.ToInt32(Me._st))

                    Dim i As Integer

                    For i = 0 To Me.chklstAccessories.CheckedItems.Count - 1
                        If Me._bReceiving Then
                            Me._objAccessories.SaveReceivedAccessory(Me._iDeviceID, CType(CType(CType(Me.chklstAccessories.CheckedItems(i), Object), System.Data.DataRowView).Row, System.Data.DataRow).ItemArray(0), PSS.Core.ApplicationUser.IDuser)
                        Else
                            Me._objAccessories.SaveToBeShippedAccessory(Me._iDeviceID, CType(CType(CType(Me.chklstAccessories.CheckedItems(i), Object), System.Data.DataRowView).Row, System.Data.DataRow).ItemArray(0), PSS.Core.ApplicationUser.IDuser, Convert.ToInt32(Me._st))
                        End If
                    Next i

                    If Me._bReceiving Then
                        MessageBox.Show("Accessory receiving data saved successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Else
                        PrintAccessoriesLabel(Me._iDeviceID)

                        MessageBox.Show("Accessory shipping data saved and printed successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If

                    Me.Close()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnOK_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Cursor = Cursors.Default
                Me.Enabled = True
            End Try
        End Sub

        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Try
                If Me.chklstAccessories.Items.Count > 0 Then Me._bCancelClosing = IIf(MessageBox.Show("Are you sure you want to cancel accessory selection?", "Cancel Selection", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No, True, False)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnCancel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub Accessories_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
            Try
                e.Cancel = Me._bCancelClosing
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Accessories_Closing", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub PrintAccessoriesLabel(ByVal iDeviceID As Integer)
            Dim dt As DataTable

            Try
                If Not File.Exists(Me._strReportDir & Me._strReportName) Then Throw New Exception(String.Format("Unable to locate report file '{0}'.", Me._strReportDir & Me._strReportName))

                dt = Me._objAccessories.GetToBeShippedAccessoriesLabelData(iDeviceID, Convert.ToInt32(Me._st))

                If (dt.Rows.Count > 0) Then
                    Dim objRpt As New ReportDocument()

                    With objRpt
                        .Load(Me._strReportDir & Me._strReportName)
                        .SetDataSource(dt)
                        .PrintToPrinter(1, True, 0, 0)
                    End With
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub
    End Class
End Namespace
