Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui

    Public Class frmCollectPartAndRemapBOM
        Inherits System.Windows.Forms.Form

        Private _iScreenDCodeID As Integer  '3409= Receiving; 3764= Pretest 
        Public _booCancel As Boolean = True
        Public _booRefreshBOM As Boolean = False
        Private _iModelID As Integer
        Private _iProdID As Integer
        Private _iBillcodeID, _iBillcodeIDRV As Integer
        Private _iPsPriceID, _iPsPriceIDRV As Integer
        Private _strBillcodeDesc, _strBillcodeDescRV As String
        Private _objSyx As PSS.Data.Buisness.Syx
        Private _booRVButton As Boolean = False

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal ModelID As Integer, ByVal BillcodeID As Integer, ByVal PSPriceID As Integer, ByVal IsRV As Boolean, ByVal iPRodID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()
            Try
                'Add any initialization after the InitializeComponent() call
                Me._iModelID = ModelID
                _booRVButton = IsRV

                If _booRVButton = True Then
                    _iBillcodeIDRV = BillcodeID
                    _iPsPriceIDRV = PSPriceID
                Else
                    _iBillcodeID = BillcodeID
                    _iPsPriceID = PSPriceID
                End If

                _iProdID = iPRodID

                _objSyx = New PSS.Data.Buisness.Syx()
            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "FormNewEvent", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        Friend WithEvents lblModel As System.Windows.Forms.Label
        Friend WithEvents lblBillcode As System.Windows.Forms.Label
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents txtPartNumber As System.Windows.Forms.TextBox
        Friend WithEvents txtPartDesc As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents btnSave As System.Windows.Forms.Button
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents lblCurrentMapPartNo As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents chkRVPart As System.Windows.Forms.CheckBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.lblModel = New System.Windows.Forms.Label()
            Me.lblBillcode = New System.Windows.Forms.Label()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.txtPartNumber = New System.Windows.Forms.TextBox()
            Me.txtPartDesc = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.btnSave = New System.Windows.Forms.Button()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.lblCurrentMapPartNo = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.chkRVPart = New System.Windows.Forms.CheckBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblModel
            '
            Me.lblModel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblModel.ForeColor = System.Drawing.Color.Black
            Me.lblModel.Location = New System.Drawing.Point(16, 16)
            Me.lblModel.Name = "lblModel"
            Me.lblModel.Size = New System.Drawing.Size(184, 23)
            Me.lblModel.TabIndex = 0
            Me.lblModel.Text = "Label1"
            '
            'lblBillcode
            '
            Me.lblBillcode.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBillcode.ForeColor = System.Drawing.Color.Black
            Me.lblBillcode.Location = New System.Drawing.Point(280, 16)
            Me.lblBillcode.Name = "lblBillcode"
            Me.lblBillcode.Size = New System.Drawing.Size(160, 23)
            Me.lblBillcode.TabIndex = 1
            Me.lblBillcode.Text = "Label1"
            '
            'Label8
            '
            Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.Black
            Me.Label8.Location = New System.Drawing.Point(16, 16)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(88, 16)
            Me.Label8.TabIndex = 183
            Me.Label8.Text = "New Part # "
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtPartNumber
            '
            Me.txtPartNumber.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPartNumber.Location = New System.Drawing.Point(112, 16)
            Me.txtPartNumber.MaxLength = 30
            Me.txtPartNumber.Name = "txtPartNumber"
            Me.txtPartNumber.Size = New System.Drawing.Size(240, 23)
            Me.txtPartNumber.TabIndex = 1
            Me.txtPartNumber.Text = ""
            '
            'txtPartDesc
            '
            Me.txtPartDesc.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPartDesc.Location = New System.Drawing.Point(112, 48)
            Me.txtPartDesc.MaxLength = 250
            Me.txtPartDesc.Multiline = True
            Me.txtPartDesc.Name = "txtPartDesc"
            Me.txtPartDesc.Size = New System.Drawing.Size(240, 88)
            Me.txtPartDesc.TabIndex = 2
            Me.txtPartDesc.Text = ""
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Black
            Me.Label1.Location = New System.Drawing.Point(16, 48)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(88, 32)
            Me.Label1.TabIndex = 185
            Me.Label1.Text = "Part Description "
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnSave
            '
            Me.btnSave.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnSave.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSave.ForeColor = System.Drawing.Color.Black
            Me.btnSave.Location = New System.Drawing.Point(112, 176)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(96, 23)
            Me.btnSave.TabIndex = 3
            Me.btnSave.Text = "Save"
            '
            'btnCancel
            '
            Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCancel.ForeColor = System.Drawing.Color.Black
            Me.btnCancel.Location = New System.Drawing.Point(256, 176)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(96, 23)
            Me.btnCancel.TabIndex = 4
            Me.btnCancel.Text = "Cancel"
            '
            'lblCurrentMapPartNo
            '
            Me.lblCurrentMapPartNo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCurrentMapPartNo.ForeColor = System.Drawing.Color.Black
            Me.lblCurrentMapPartNo.Location = New System.Drawing.Point(152, 40)
            Me.lblCurrentMapPartNo.Name = "lblCurrentMapPartNo"
            Me.lblCurrentMapPartNo.Size = New System.Drawing.Size(288, 23)
            Me.lblCurrentMapPartNo.TabIndex = 186
            Me.lblCurrentMapPartNo.Text = "Label1"
            Me.lblCurrentMapPartNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.Black
            Me.Label2.Location = New System.Drawing.Point(0, 40)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(152, 23)
            Me.Label2.TabIndex = 187
            Me.Label2.Text = "Current map part # :"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Panel1
            '
            Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkRVPart, Me.txtPartNumber, Me.Label8, Me.btnSave, Me.txtPartDesc, Me.Label1, Me.btnCancel})
            Me.Panel1.Location = New System.Drawing.Point(8, 72)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(432, 208)
            Me.Panel1.TabIndex = 1
            '
            'chkRVPart
            '
            Me.chkRVPart.Enabled = False
            Me.chkRVPart.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkRVPart.ForeColor = System.Drawing.Color.Black
            Me.chkRVPart.Location = New System.Drawing.Point(112, 144)
            Me.chkRVPart.Name = "chkRVPart"
            Me.chkRVPart.TabIndex = 186
            Me.chkRVPart.Text = "RV Part ???"
            '
            'Label3
            '
            Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.Black
            Me.Label3.Location = New System.Drawing.Point(208, 13)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(72, 23)
            Me.Label3.TabIndex = 188
            Me.Label3.Text = "Bill code :"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'frmCollectPartAndRemapBOM
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.LightSteelBlue
            Me.ClientSize = New System.Drawing.Size(446, 300)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label3, Me.Panel1, Me.Label2, Me.lblCurrentMapPartNo, Me.lblBillcode, Me.lblModel})
            Me.ForeColor = System.Drawing.Color.Blue
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "frmCollectPartAndRemapBOM"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Get Part"
            Me.Panel1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        '***********************************************************************************
        Private Sub frmCollectPartAndRemapBOM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                Me.lblModel.Text = "Model : " & Generic.GetModelDesc(_iModelID)

                If _booRVButton = True Then
                    Me.lblBillcode.Text = Generic.GetBillCodeDesc(_iBillcodeIDRV)
                    Me.lblCurrentMapPartNo.Text = Generic.GetPartNoDesc(_iPsPriceIDRV)
                    _strBillcodeDescRV = Me.lblBillcode.Text
                    _strBillcodeDesc = Me.lblBillcode.Text.ToUpper.Replace("RV_", "")

                    '******************************************************
                    'Crete regular billcode
                    '******************************************************
                    _iBillcodeID = Me._objSyx.GetBillcodeID(_strBillcodeDesc, Me._iProdID)
                    If _iBillcodeID = 0 Then
                        _iBillcodeID = Me._objSyx.CloneBillCodes(_strBillcodeDesc, _iBillcodeIDRV)
                        If _iBillcodeID = 0 Then Throw New Exception("System has failed to create new billcode " & _strBillcodeDesc & ".")
                    End If

                    '******************************************************
                Else
                    Me.lblBillcode.Text = Generic.GetBillCodeDesc(_iBillcodeID)
                    Me.lblCurrentMapPartNo.Text = Generic.GetPartNoDesc(_iPsPriceID)
                    _strBillcodeDescRV = "RV_" & Me.lblBillcode.Text
                    _strBillcodeDesc = Me.lblBillcode.Text

                    '******************************************************
                    'Crete RV billcode
                    '******************************************************
                    _iBillcodeIDRV = Me._objSyx.GetBillcodeID(_strBillcodeDescRV, Me._iProdID)
                    If _iBillcodeIDRV = 0 Then
                        _iBillcodeIDRV = Me._objSyx.CloneBillCodes(_strBillcodeDescRV, _iBillcodeID)
                        If _iBillcodeIDRV = 0 Then Throw New Exception("System has failed to create new billcode " & _strBillcodeDescRV & ".")
                    End If
                    '******************************************************
                End If

                Me.chkRVPart.Checked = Me._booRVButton

            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "FormLoad", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***********************************************************************************
        Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
            Dim i, iRVFlag As Integer
            Dim dt As DataTable
            Dim strPartDesc As String = ""

            Try
                If Me._iModelID = 0 Then
                    MessageBox.Show("System can't define model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me._iBillcodeID = 0 OrElse Me._iBillcodeIDRV = 0 Then
                    MessageBox.Show("System can't define bill code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me._iPsPriceID = 0 AndAlso Me._iPsPriceIDRV = 0 Then
                    MessageBox.Show("System can't define current map part #.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.lblCurrentMapPartNo.Text.Trim.ToLower <> "syxtemp" AndAlso Me.lblCurrentMapPartNo.Text.Trim.ToLower <> "syxtemp_rv" AndAlso Me.lblCurrentMapPartNo.Text.Trim.ToLower <> "temppart" AndAlso Me.lblCurrentMapPartNo.Text.Trim.ToLower <> "temppart_rv" Then
                    MessageBox.Show("Current part is not an temporary part. Can't re-map to new part.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.txtPartNumber.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter part number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.chkRVPart.Checked = True AndAlso Me.lblBillcode.Text.Trim.ToLower.StartsWith("rv_") = False Then
                    MessageBox.Show("Billcode is not an RV billcode. Please uncheck RV.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.chkRVPart.Checked = False AndAlso Me.lblBillcode.Text.Trim.ToLower.StartsWith("rv_") = True Then
                    MessageBox.Show("Please check RV part for RV billcode.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    strPartDesc = ""
                    strPartDesc = Me.txtPartDesc.Text.Trim

                    If Me.chkRVPart.Checked = True Then
                        iRVFlag = 1
                        If strPartDesc.Trim.Length = 0 Then strPartDesc = "RV " & Me.txtPartNumber.Text.Trim
                    Else
                        iRVFlag = 0
                        If strPartDesc.Trim.Length = 0 Then strPartDesc = Me.txtPartNumber.Text.Trim
                    End If

                    Me._objSyx.AddPartIntoPsprice(Me.txtPartNumber.Text.Trim.ToUpper, strPartDesc, Core.ApplicationUser.IDuser, iRVFlag)

                    Me._iPsPriceID = Me._objSyx.GetPSPriceID(Me.txtPartNumber.Text.Trim)
                    Me._iPsPriceIDRV = Me._objSyx.GetPSPriceID(Me.txtPartNumber.Text.Trim & "_RV")
                    If _iPsPriceID = 0 Then Throw New Exception("System has failed to insert new part (" & Me.txtPartNumber.Text.Trim & ").")
                    If _iPsPriceIDRV = 0 Then Throw New Exception("System has failed to insert new part (" & Me.txtPartNumber.Text.Trim & "_RV ).")

                    '************************************************************
                    'Get current map
                    '************************************************************
                    If Me._booRVButton = True Then
                        dt = Me._objSyx.GetCurrentMap(Me._iModelID, Me._iBillcodeIDRV)
                    Else
                        dt = Me._objSyx.GetCurrentMap(Me._iModelID, Me._iBillcodeID)
                    End If
                    '************************************************************
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("The mapping link between model and billcode have been removed. Please refresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf dt.Rows.Count > 1 Then
                        MessageBox.Show("Duplicate mapping on " & Environment.NewLine & "Part #: " & dt.Rows(0)("PsPrice_Number") & Environment.NewLine & "Part Description: " & dt.Rows(0)("PsPrice_Number") & Environment.NewLine, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        i = Me._objSyx.UpdatePartMapRegAndRV(Me._iPsPriceID, Me._iPsPriceIDRV, Me._iBillcodeID, Me._iBillcodeIDRV, Me._iModelID, dt, PSS.Core.ApplicationUser.IDuser)
                        If i > 0 Then
                            Me._booRefreshBOM = True
                            Me._booCancel = False
                            Me.Close()
                        Else
                            MessageBox.Show("No update happen", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "btnSave", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '***********************************************************************************
        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Me.Close()
        End Sub

        '***********************************************************************************

    End Class
End Namespace