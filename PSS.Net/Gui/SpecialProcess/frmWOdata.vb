Namespace Gui.SpecialProcess

    Public Class frmWOdata
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
        Friend WithEvents lblWO As System.Windows.Forms.Label
        Friend WithEvents txtWO As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents txtTotal As System.Windows.Forms.TextBox
        Friend WithEvents txtRepair As System.Windows.Forms.TextBox
        Friend WithEvents txtRUR As System.Windows.Forms.TextBox
        Friend WithEvents btnGetData As System.Windows.Forms.Button
        Friend WithEvents btnClear As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.lblWO = New System.Windows.Forms.Label()
            Me.txtWO = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtTotal = New System.Windows.Forms.TextBox()
            Me.txtRepair = New System.Windows.Forms.TextBox()
            Me.txtRUR = New System.Windows.Forms.TextBox()
            Me.btnGetData = New System.Windows.Forms.Button()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            '
            'lblWO
            '
            Me.lblWO.Location = New System.Drawing.Point(16, 16)
            Me.lblWO.Name = "lblWO"
            Me.lblWO.Size = New System.Drawing.Size(80, 16)
            Me.lblWO.TabIndex = 0
            Me.lblWO.Text = "WORKORDER:"
            '
            'txtWO
            '
            Me.txtWO.Location = New System.Drawing.Point(104, 12)
            Me.txtWO.Name = "txtWO"
            Me.txtWO.Size = New System.Drawing.Size(160, 20)
            Me.txtWO.TabIndex = 1
            Me.txtWO.Text = ""
            '
            'Label1
            '
            Me.Label1.Location = New System.Drawing.Point(16, 56)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(248, 16)
            Me.Label1.TabIndex = 2
            Me.Label1.Text = "Total number of devices in this workorder:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'Label2
            '
            Me.Label2.Location = New System.Drawing.Point(16, 80)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(248, 16)
            Me.Label2.TabIndex = 3
            Me.Label2.Text = "Repaired devices in this workorder:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'Label3
            '
            Me.Label3.Location = New System.Drawing.Point(16, 108)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(248, 16)
            Me.Label3.TabIndex = 4
            Me.Label3.Text = "RUR devices in this workorder:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'txtTotal
            '
            Me.txtTotal.Location = New System.Drawing.Point(272, 56)
            Me.txtTotal.Name = "txtTotal"
            Me.txtTotal.TabIndex = 0
            Me.txtTotal.Text = ""
            '
            'txtRepair
            '
            Me.txtRepair.Location = New System.Drawing.Point(272, 80)
            Me.txtRepair.Name = "txtRepair"
            Me.txtRepair.TabIndex = 0
            Me.txtRepair.Text = ""
            '
            'txtRUR
            '
            Me.txtRUR.Location = New System.Drawing.Point(272, 104)
            Me.txtRUR.Name = "txtRUR"
            Me.txtRUR.TabIndex = 0
            Me.txtRUR.Text = ""
            '
            'btnGetData
            '
            Me.btnGetData.Location = New System.Drawing.Point(272, 8)
            Me.btnGetData.Name = "btnGetData"
            Me.btnGetData.Size = New System.Drawing.Size(104, 24)
            Me.btnGetData.TabIndex = 2
            Me.btnGetData.Text = "Get Data"
            '
            'btnClear
            '
            Me.btnClear.Location = New System.Drawing.Point(272, 144)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(104, 23)
            Me.btnClear.TabIndex = 0
            Me.btnClear.Text = "Clear"
            '
            'frmWOdata
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(392, 325)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnClear, Me.btnGetData, Me.txtRUR, Me.txtRepair, Me.txtTotal, Me.Label3, Me.Label2, Me.Label1, Me.txtWO, Me.lblWO})
            Me.Name = "frmWOdata"
            Me.Text = "frmWOdata"
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmWOdata_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            txtWO.Focus()

        End Sub

        Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click

            txtWO.Text = ""
            txtTotal.Text = ""
            txtRepair.Text = ""
            txtRUR.Text = ""
            txtWO.Focus()

        End Sub

        Private Function GetData(ByVal mWO As String) As Boolean

            Dim ds As PSS.Data.Production.Joins
            Dim strSQL As String
            Dim dt As DataTable
            Dim r As DataRow

            '//Get ID for Workorder
            strSQL = "SELECT * FROM tworkorder WHERE WO_CustWO = '" & mWO & "' ORDER BY WO_ID Desc"
            dt = ds.OrderEntrySelect(strSQL)
            If dt.Rows.Count < 1 Then
                MsgBox("Either the workorder is invalid or not yet received. EXITING...", MsgBoxStyle.OKOnly)
                txtWO.Text = ""
                txtWO.Focus()
                Exit Function
            End If

            Dim woID As Long
            r = dt.Rows(0)
            woID = r("WO_ID")


            '//Get data for this workorder - Number of devices
            Try
                strSQL = "SELECT COUNT(Device_SN) as ttlCount FROM tdevice WHERE WO_ID = " & woID
                dt = ds.OrderEntrySelect(strSQL)
                If dt.Rows.Count < 0 Then
                    Exit Function
                End If

                r = dt.Rows(0)
                Me.txtTotal.Text = r("ttlCount")
            Catch ex As Exception
                Me.txtTotal.Text = "unknown"
            End Try

            '//Get data for this workorder - Repair devices
            Try
                strSQL = "SELECT DISTINCT COUNT(Device_SN) as ttlCount FROM tdevice INNER JOIN tdevicebill on tdevice.device_id = tdevicebill.device_id INNER JOIN lbillcodes on tdevicebill.billcode_id = lbillcodes.billcode_id WHERE WO_ID = " & woID & " AND lbillcodes.billcode_rule <> 1 GROUP BY wo_id"
                dt = ds.OrderEntrySelect(strSQL)
                If dt.Rows.Count < 0 Then
                    Exit Function
                End If

                r = dt.Rows(0)
                Me.txtRepair.Text = r("ttlCount")
            Catch ex As Exception
                Me.txtRepair.Text = "unknown"
            End Try

            '//Get data for this workorder - RUR devices
            Try
                strSQL = "SELECT DISTINCT COUNT(Device_SN) as ttlCount FROM tdevice INNER JOIN tdevicebill on tdevice.device_id = tdevicebill.device_id INNER JOIN lbillcodes on tdevicebill.billcode_id = lbillcodes.billcode_id WHERE WO_ID = " & woID & " AND lbillcodes.billcode_rule = 1"
                dt = ds.OrderEntrySelect(strSQL)
                If dt.Rows.Count < 0 Then
                    Exit Function
                End If

                r = dt.Rows(0)
                Me.txtRUR.Text = r("ttlCount")
            Catch ex As Exception
                Me.txtRUR.Text = "unknown"
            End Try

        End Function

        Private Sub btnGetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetData.Click

            Dim blnGetData As Boolean

            If Len(Trim(txtWO.Text)) > 0 Then
                blnGetData = Me.GetData(txtWO.Text)
            End If

            btnClear.Focus()

        End Sub

        Private Sub txtWO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWO.KeyDown

            If e.KeyCode = 13 Then
                Dim blnGetData As Boolean

                If Len(Trim(txtWO.Text)) > 0 Then
                    blnGetData = Me.GetData(txtWO.Text)
                End If

                btnClear.Focus()

            End If

        End Sub

    End Class

End Namespace
