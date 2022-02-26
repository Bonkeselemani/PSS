Imports PSS.Core
Imports PSS.Data

Namespace Gui.HideBillCodes

    Public Class frmHideBillCodes
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
        Friend WithEvents lblManuf As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents chkBillCodes As System.Windows.Forms.CheckedListBox
        Friend WithEvents cboManuf As PSS.Gui.Controls.ComboBox
        Friend WithEvents cboModel As PSS.Gui.Controls.ComboBox
        Friend WithEvents lblNarrative As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.lblManuf = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.chkBillCodes = New System.Windows.Forms.CheckedListBox()
            Me.cboManuf = New PSS.Gui.Controls.ComboBox()
            Me.cboModel = New PSS.Gui.Controls.ComboBox()
            Me.lblNarrative = New System.Windows.Forms.Label()
            Me.SuspendLayout()
            '
            'lblManuf
            '
            Me.lblManuf.Location = New System.Drawing.Point(8, 21)
            Me.lblManuf.Name = "lblManuf"
            Me.lblManuf.Size = New System.Drawing.Size(104, 16)
            Me.lblManuf.TabIndex = 1
            Me.lblManuf.Text = "MANUFACTURER:"
            Me.lblManuf.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'Label1
            '
            Me.Label1.Location = New System.Drawing.Point(8, 45)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(104, 16)
            Me.Label1.TabIndex = 2
            Me.Label1.Text = "MODEL:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'chkBillCodes
            '
            Me.chkBillCodes.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.chkBillCodes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.chkBillCodes.Location = New System.Drawing.Point(120, 120)
            Me.chkBillCodes.Name = "chkBillCodes"
            Me.chkBillCodes.Size = New System.Drawing.Size(296, 182)
            Me.chkBillCodes.TabIndex = 5
            '
            'cboManuf
            '
            Me.cboManuf.AutoComplete = True
            Me.cboManuf.Location = New System.Drawing.Point(120, 16)
            Me.cboManuf.Name = "cboManuf"
            Me.cboManuf.Size = New System.Drawing.Size(168, 21)
            Me.cboManuf.TabIndex = 1
            '
            'cboModel
            '
            Me.cboModel.AutoComplete = True
            Me.cboModel.Location = New System.Drawing.Point(120, 40)
            Me.cboModel.Name = "cboModel"
            Me.cboModel.Size = New System.Drawing.Size(168, 21)
            Me.cboModel.TabIndex = 2
            '
            'lblNarrative
            '
            Me.lblNarrative.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblNarrative.ForeColor = System.Drawing.Color.Tomato
            Me.lblNarrative.Location = New System.Drawing.Point(8, 72)
            Me.lblNarrative.Name = "lblNarrative"
            Me.lblNarrative.Size = New System.Drawing.Size(488, 48)
            Me.lblNarrative.TabIndex = 6
            Me.lblNarrative.Text = "SELECTED BILLCODES WILL NOT BE DISPLAYED IN THE TECHNICIAN BILLING SCREEN."
            Me.lblNarrative.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'frmHideBillCodes
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(672, 333)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblNarrative, Me.cboModel, Me.cboManuf, Me.chkBillCodes, Me.Label1, Me.lblManuf})
            Me.Name = "frmHideBillCodes"
            Me.Text = "frmHideBillCodes"
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private ds As PSS.Data.Production.Joins

        Private dtManuf, dtModel, dtBillCodes As DataTable
        Private strSQL As String

        Private Sub frmHideBillCodes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            chkBillCodes.Visible = False
            System.Windows.Forms.Application.DoEvents()
            cboManuf.Focus()
            loadManuf()
            System.Windows.Forms.Application.DoEvents()
            chkBillCodes.Visible = True
        End Sub

#Region "Load Functions"

        Private Sub loadManuf()
            dtManuf = getManuf()
            cboManuf.DataSource = dtManuf
            cboManuf.DisplayMember = dtManuf.Columns("Manuf_Desc").ToString
            cboManuf.ValueMember = dtManuf.Columns("Manuf_ID").ToString
        End Sub
        Private Sub loadModel(ByVal mManuf As Long)
            dtModel = getModel(mManuf)
            cboModel.DataSource = dtModel
            cboModel.DisplayMember = dtModel.Columns("Model_Desc").ToString
            cboModel.ValueMember = dtModel.Columns("Model_ID").ToString
        End Sub

#End Region

#Region "Create Data Tables"

        Private Function getManuf() As DataTable
            strSQL = "SELECT * FROM lmanuf ORDER BY Manuf_Desc"
            Return ds.OrderEntrySelect(strSQL)
        End Function
        Private Function getModel(ByVal vmanuf As Long) As DataTable
            strSQL = "SELECT * FROM tmodel WHERE manuf_ID = " & vmanuf & " ORDER BY Model_Desc"
            Return ds.OrderEntrySelect(strSQL)
        End Function
        Private Function getBillCodes(ByVal vmodel As Long) As DataTable
            strSQL = "SELECT lbillcodes.billcode_id, lbillcodes.billcode_desc, tpsmap.inactive FROM tpsmap inner join lbillcodes on tpsmap.billcode_id = lbillcodes.billcode_id WHERE tpsmap.model_id = " & vmodel & " ORDER BY lbillcodes.billcode_desc"
            Return ds.OrderEntrySelect(strSQL)
        End Function

#End Region

#Region "On Change Events for Combo Boxes"

        Private Sub cboManuf_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboManuf.SelectedValueChanged
            Try
                loadModel(cboManuf.SelectedValue)
            Catch ex As Exception
            End Try
        End Sub
        Private Sub cboModel_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboModel.SelectedValueChanged
            Try
                loadBillCodes(cboModel.SelectedValue)
            Catch ex As Exception
            End Try
        End Sub

#End Region

#Region "Specific Bill Code Data"

        Private Sub loadBillCodes(ByVal mModel As Long)

            '//This will load the billcodes for the selection manufacturer/model
            Try
                chkBillCodes.Items.Clear()
            Catch ex As Exception
            End Try

            Try
                dtBillCodes = getBillCodes(cboModel.SelectedValue)
                Dim rBC As DataRow
                Dim xCount As Integer = 0
                Dim blnChecked As Boolean = False
                For xCount = 0 To dtBillCodes.Rows.Count - 1
                    rBC = dtBillCodes.Rows(xCount)

                    blnChecked = False
                    If rBC("Inactive") = 1 Then blnChecked = True
                    chkBillCodes.Items.Add(rBC("BillCode_Desc"), blnChecked)
                Next
            Catch ex As Exception
            End Try

        End Sub
        Private Function getBillCodeID(ByVal mDesc As String) As Long
            Dim xCount As Integer = 0
            Dim r As DataRow
            For xCount = 0 To dtBillCodes.Rows.Count - 1
                r = dtBillCodes.Rows(xCount)
                If r("BillCode_Desc") = mDesc Then
                    Return r("BillCode_ID")
                End If
            Next
            Return 0
        End Function

#End Region


        Private Sub chkBillCodes_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles chkBillCodes.ItemCheck

            Dim CheckStatus As Integer
            Dim _ID As Long
            Dim ModelID As Long = cboModel.SelectedValue
            Dim mSQL As String
            Dim blnUpdate As Boolean

            _ID = getBillCodeID(chkBillCodes.SelectedItem)

            If _ID > 0 And ModelID > 0 Then

                CheckStatus = chkBillCodes.GetItemCheckState(chkBillCodes.SelectedIndex)

                If CheckStatus = 0 Then
                    '//Item is about to be checked
                    mSQL = "UPDATE tpsmap SET Inactive = 1 WHERE tpsmap.model_id = " & ModelID & " AND tpsmap.billcode_id = " & _ID
                    blnUpdate = ds.OrderEntryUpdateDelete(mSQL)
                Else
                    '//Item is about to be unchecked
                    mSQL = "UPDATE tpsmap SET Inactive = 0 WHERE tpsmap.model_id = " & ModelID & " AND tpsmap.billcode_id = " & _ID
                    blnUpdate = ds.OrderEntryUpdateDelete(mSQL)
                End If

            End If

        End Sub

    End Class
End Namespace
