Namespace Gui.Edit

    Public Class frmEdit_SKU
        Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            txtWOnum.Focus()

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
        Friend WithEvents lblSKU As System.Windows.Forms.Label
        Friend WithEvents txtWOnum As System.Windows.Forms.TextBox
        Friend WithEvents txtSKU As System.Windows.Forms.TextBox
        Friend WithEvents lblOrigSKU As System.Windows.Forms.Label
        Friend WithEvents lblDeviceNum As System.Windows.Forms.Label
        Friend WithEvents btnUpdate As System.Windows.Forms.Button
        Friend WithEvents lblWOnum As System.Windows.Forms.Label
        Friend WithEvents lblWorkorderName As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.lblWOnum = New System.Windows.Forms.Label()
            Me.lblSKU = New System.Windows.Forms.Label()
            Me.txtWOnum = New System.Windows.Forms.TextBox()
            Me.txtSKU = New System.Windows.Forms.TextBox()
            Me.lblOrigSKU = New System.Windows.Forms.Label()
            Me.lblDeviceNum = New System.Windows.Forms.Label()
            Me.btnUpdate = New System.Windows.Forms.Button()
            Me.lblWorkorderName = New System.Windows.Forms.Label()
            Me.SuspendLayout()
            '
            'lblWOnum
            '
            Me.lblWOnum.Location = New System.Drawing.Point(32, 48)
            Me.lblWOnum.Name = "lblWOnum"
            Me.lblWOnum.Size = New System.Drawing.Size(120, 16)
            Me.lblWOnum.TabIndex = 0
            Me.lblWOnum.Text = "Workorder Number:"
            Me.lblWOnum.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblSKU
            '
            Me.lblSKU.Location = New System.Drawing.Point(32, 72)
            Me.lblSKU.Name = "lblSKU"
            Me.lblSKU.Size = New System.Drawing.Size(120, 16)
            Me.lblSKU.TabIndex = 1
            Me.lblSKU.Text = "SKU:"
            Me.lblSKU.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtWOnum
            '
            Me.txtWOnum.Location = New System.Drawing.Point(160, 48)
            Me.txtWOnum.Name = "txtWOnum"
            Me.txtWOnum.Size = New System.Drawing.Size(64, 20)
            Me.txtWOnum.TabIndex = 2
            Me.txtWOnum.Text = ""
            '
            'txtSKU
            '
            Me.txtSKU.Location = New System.Drawing.Point(160, 72)
            Me.txtSKU.Name = "txtSKU"
            Me.txtSKU.Size = New System.Drawing.Size(144, 20)
            Me.txtSKU.TabIndex = 3
            Me.txtSKU.Text = ""
            '
            'lblOrigSKU
            '
            Me.lblOrigSKU.Location = New System.Drawing.Point(312, 72)
            Me.lblOrigSKU.Name = "lblOrigSKU"
            Me.lblOrigSKU.Size = New System.Drawing.Size(168, 16)
            Me.lblOrigSKU.TabIndex = 4
            Me.lblOrigSKU.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblDeviceNum
            '
            Me.lblDeviceNum.Location = New System.Drawing.Point(232, 48)
            Me.lblDeviceNum.Name = "lblDeviceNum"
            Me.lblDeviceNum.Size = New System.Drawing.Size(168, 16)
            Me.lblDeviceNum.TabIndex = 5
            Me.lblDeviceNum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnUpdate
            '
            Me.btnUpdate.Location = New System.Drawing.Point(160, 104)
            Me.btnUpdate.Name = "btnUpdate"
            Me.btnUpdate.Size = New System.Drawing.Size(144, 32)
            Me.btnUpdate.TabIndex = 6
            Me.btnUpdate.Text = "Update"
            '
            'lblWorkorderName
            '
            Me.lblWorkorderName.BackColor = System.Drawing.SystemColors.Control
            Me.lblWorkorderName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWorkorderName.ForeColor = System.Drawing.Color.SteelBlue
            Me.lblWorkorderName.Location = New System.Drawing.Point(24, 8)
            Me.lblWorkorderName.Name = "lblWorkorderName"
            Me.lblWorkorderName.Size = New System.Drawing.Size(456, 23)
            Me.lblWorkorderName.TabIndex = 7
            '
            'frmEdit_SKU
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(496, 149)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblWorkorderName, Me.btnUpdate, Me.lblDeviceNum, Me.lblOrigSKU, Me.txtSKU, Me.txtWOnum, Me.lblSKU, Me.lblWOnum})
            Me.Name = "frmEdit_SKU"
            Me.Text = "frmEdit_SKU"
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private mWOtext As String = ""
        Private mWOnum As Long = 0
        Private mCount As Integer = 0
        Private mSKU As String = ""

        Private Sub frmEdit_SKU_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            txtWOnum.Focus()
        End Sub

        Private Sub CleanForm()
            mWOtext = ""
            mWOnum = 0
            mSKU = ""
            txtWOnum.Text = ""
            txtSKU.Text = ""
            lblDeviceNum.Text = ""
            lblOrigSKU.Text = ""
            lblWorkorderName.Text = ""
            txtWOnum.Focus()
        End Sub

        Private Function getDeviceCount(ByVal mWOnum As Long) As Integer
            If mWOnum > 0 Then
                Dim strSQL As String
                Dim mCount As Integer = 0
                Dim dt As DataTable
                Try
                    strSQL = "SELECT device_sn FROM tdevice WHERE WO_ID = " & mWOnum
                    dt = PSS.Data.Production.Joins.OrderEntrySelect(strSQL)
                    mCount = dt.Rows.Count
                Catch ex As Exception
                    mCount = 0
                Finally
                    dt = Nothing
                End Try
                Return mCount
            Else
                Return 0
            End If

        End Function

        Private Function getWOtext(ByVal mWOnum As Long) As String
            If mWOnum > 0 Then
                Dim strSQL As String
                Dim mWOtext As String = ""
                Dim dt As DataTable
                Dim dr As DataRow
                Try
                    strSQL = "SELECT wo_custwo FROM tworkorder WHERE WO_ID = " & mWOnum
                    dt = PSS.Data.Production.Joins.OrderEntrySelect(strSQL)
                    dr = dt.Rows(0)
                    mWOtext = dr("wo_custwo")
                Catch ex As Exception
                    mWOtext = ""
                Finally
                    dt = Nothing
                End Try
                Return mWOtext
            Else
                Return ""
            End If

        End Function

        Private Function getOrigSKU(ByVal mWOnum As Long) As String
            If mWOnum > 0 Then
                Dim strSQL As String
                Dim mOrigSKU As String
                Dim dt As DataTable
                Dim dr As DataRow
                Dim xCount As Integer
                Try
                    strSQL = "SELECT DISTINCT tdevicemetro.devicemetro_sku " & _
                    "FROM tdevice INNER JOIN tdevicemetro " & _
                    "on tdevice.device_sn = tdevicemetro.devicemetro_sn " & _
                    "WHERE tdevice.WO_ID = " & mWOnum
                    dt = PSS.Data.Production.Joins.OrderEntrySelect(strSQL)
                    For xCount = 0 To dt.Rows.Count - 1
                        dr = dt.Rows(xCount)
                        mOrigSKU += dr("DeviceMetro_SKU")
                    Next
                Catch ex As Exception
                    mOrigSKU = ""
                Finally
                    dt = Nothing
                End Try
                Return mOrigSKU
            Else
                Return ""
            End If

        End Function

        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

            If mWOnum > 0 And Len(Trim(mSKU)) > 0 And Len(Trim(mWOtext)) > 0 And mCount > 0 And Len(Trim(txtSKU.Text)) > 0 Then
                '//Verify Count Value 
                If Len(Trim(lblDeviceNum.Text)) > 0 Then
                    '//Perform Update of Values
                    Dim ds As PSS.Data.Production.Joins
                    Dim blnDS As Boolean
                    Dim strSQL As String
                    '//Perform Update 1 - device table
                    strSQL = "update tdevice, tdevicemetro set tdevicemetro.devicemetro_sku = '" & Trim(txtSKU.Text) & "' WHERE tdevice.device_sn = tdevicemetro.devicemetro_sn and tdevice.wo_id = " & mWOnum
                    blnDS = ds.OrderEntryUpdateDelete(strSQL)
                    System.Windows.Forms.Application.DoEvents()
                    '//Perform Update 2 - usatest table
                    strSQL = "update tusatest set usa_finishedgoodssku = '" & Trim(txtSKU.Text) & "' where usa_wo = '" & mWOtext & "'"
                    blnDS = ds.OrderEntryUpdateDelete(strSQL)
                    System.Windows.Forms.Application.DoEvents()
                End If
            Else
                MsgBox("Please define a value for both Workorder Number and SKU", MsgBoxStyle.OKOnly, "ERROR")
                txtWOnum.Focus()
                Exit Sub
            End If

            '//Clean form at end of operation
            CleanForm()
        End Sub

        Private Sub txtWOnum_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtWOnum.Leave
            mWOnum = txtWOnum.Text
            System.Windows.Forms.Application.DoEvents()
            mCount = getDeviceCount(mWOnum)
            lblDeviceNum.Text = "Count: " & mCount
            System.Windows.Forms.Application.DoEvents()
            mWOtext = getWOtext(mWOnum)
            lblWorkorderName.Text = "WORKORDER: " & mWOtext
            System.Windows.Forms.Application.DoEvents()
            mSKU = getOrigSKU(mWOnum)
            lblOrigSKU.Text = "Original SKU: " & mSKU
            System.Windows.Forms.Application.DoEvents()
        End Sub

        Private Sub txtWOnum_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWOnum.KeyUp
            If e.KeyValue = 13 Then
                txtSKU.Focus()
            End If
        End Sub

        Private Sub txtSKU_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSKU.KeyUp
            If e.KeyValue = 13 Then
                txtWOnum.Focus()
            End If
        End Sub

    End Class

End Namespace
