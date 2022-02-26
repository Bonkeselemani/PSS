Option Explicit On 

Public Class frmCollectRepCodePartInfo
    Inherits System.Windows.Forms.Form

    Private Const LCD_PART_NUMBER As String = "80H00673-01"
    Private Const MAINBOARD_PART_NUMBER As String = "99HCY090-02"

    Public _booCancelCollection As Boolean = False
    Public _iFailID As Integer = 0
    Public _iRepairID As Integer = 0

    Private _objHTC As PSS.Data.Buisness.HTC
    Private _iDeviceID As Integer = 0
    Private _iBillcodeID As Integer = 0
    Private _iModelID As Integer = 0
    Private _strStation As String = ""
    Private _iMC_ID As Integer = 0
    Private _iPSPrice_ID As Integer = 0
    Private _strPSPrice_Number As String = ""

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal iDeviceID As Integer, _
                   ByVal iBillcodeID As Integer, _
                   ByVal iModelID As Integer, _
                   ByVal strStation As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me._iDeviceID = iDeviceID
        Me._iBillcodeID = iBillcodeID
        Me._strStation = strStation
        Me._iModelID = iModelID

        Me._objHTC = New PSS.Data.Buisness.HTC()
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If

            If Not IsNothing(Me._objHTC) Then
                _objHTC = Nothing
            End If
        End If

        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtNewSN As System.Windows.Forms.TextBox
    Friend WithEvents pnlNewSN_IMEI As System.Windows.Forms.Panel
    Friend WithEvents pnlFailCodes As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chklstFailCodes As System.Windows.Forms.CheckedListBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.pnlNewSN_IMEI = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtNewSN = New System.Windows.Forms.TextBox()
        Me.pnlFailCodes = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chklstFailCodes = New System.Windows.Forms.CheckedListBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.pnlNewSN_IMEI.SuspendLayout()
        Me.pnlFailCodes.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlNewSN_IMEI
        '
        Me.pnlNewSN_IMEI.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label11, Me.txtNewSN})
        Me.pnlNewSN_IMEI.Location = New System.Drawing.Point(0, 264)
        Me.pnlNewSN_IMEI.Name = "pnlNewSN_IMEI"
        Me.pnlNewSN_IMEI.Size = New System.Drawing.Size(224, 64)
        Me.pnlNewSN_IMEI.TabIndex = 2
        Me.pnlNewSN_IMEI.Visible = False
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label11.Location = New System.Drawing.Point(24, 8)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 16)
        Me.Label11.TabIndex = 124
        Me.Label11.Text = "New SN:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'txtNewSN
        '
        Me.txtNewSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNewSN.Location = New System.Drawing.Point(24, 24)
        Me.txtNewSN.Name = "txtNewSN"
        Me.txtNewSN.Size = New System.Drawing.Size(184, 22)
        Me.txtNewSN.TabIndex = 0
        Me.txtNewSN.Text = ""
        '
        'pnlFailCodes
        '
        Me.pnlFailCodes.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.pnlFailCodes.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlFailCodes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlFailCodes.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.chklstFailCodes})
        Me.pnlFailCodes.Name = "pnlFailCodes"
        Me.pnlFailCodes.Size = New System.Drawing.Size(520, 256)
        Me.pnlFailCodes.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(152, 16)
        Me.Label1.TabIndex = 128
        Me.Label1.Text = "Fail Codes :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'chklstFailCodes
        '
        Me.chklstFailCodes.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.chklstFailCodes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chklstFailCodes.Location = New System.Drawing.Point(8, 24)
        Me.chklstFailCodes.Name = "chklstFailCodes"
        Me.chklstFailCodes.Size = New System.Drawing.Size(496, 208)
        Me.chklstFailCodes.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.Location = New System.Drawing.Point(264, 280)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 24)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        '
        'frmCollectRepCodePartInfo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(522, 335)
        Me.ControlBox = False
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancel, Me.pnlFailCodes, Me.pnlNewSN_IMEI})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmCollectRepCodePartInfo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Data Collection"
        Me.pnlNewSN_IMEI.ResumeLayout(False)
        Me.pnlFailCodes.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    Private Sub frmCollectRepCodePartInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim iIsRef As Integer = 0
        Dim dtSelectedFCRC As DataTable
        Dim dtPartNumber As DataTable
        Dim i As Integer = 0

        Try
            If Me._iDeviceID = 0 Or Me._iBillcodeID = 0 Or Me._iModelID = 0 Then
                MessageBox.Show("Can not define Device ID, Billcode ID and Model ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                _booCancelCollection = True
                Me.Close()
            End If

            If Me._objHTC.IsBillcodeExistInHTCRepairTable(Me._iDeviceID, Me._iBillcodeID, , ) > 0 Then
                Me.Close()
            End If

            Me.PopulateFailCodesByBillCode()

            PSS.Core.Highlight.SetHighLight(Me)
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "FormLoad", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PSS.Data.Buisness.Generic.DisposeDT(dtSelectedFCRC)
            PSS.Data.Buisness.Generic.DisposeDT(dtPartNumber)
        End Try
    End Sub

    '******************************************************************
    Private Sub PopulateFailCodesByBillCode()
        Dim dt As DataTable

        Try
            dt = Me._objHTC.GetFunctionalFailCodesByBillCodeID(2, Me._iModelID, Me._iBillcodeID)

            With Me.chklstFailCodes
                .DataSource = Nothing
                .DataSource = dt.DefaultView
                .DisplayMember = "Fail_LDesc"
                .ValueMember = "Fail_ID"

            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '******************************************************************
    Private Sub txtNewSN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNewSN.KeyPress
        Try
            If Not (e.KeyChar.IsLetterOrDigit(e.KeyChar) Or e.KeyChar.IsControl(e.KeyChar)) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "NewSN_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '******************************************************************
    Private Sub txtNewSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNewSN.KeyUp
        Dim i As Integer = 0
        Dim iIsRef As Integer = 0
        Dim dtNewIMEI As DataTable
        Dim dtSelectedFCRC As DataTable
        Dim strNewSN As String = ""
        Dim strNewIMEI As String = ""

        Try
            If e.KeyValue = 13 Then
                If Me._iFailID = 0 Or Me._iRepairID = 0 Or Me._iPSPrice_ID = 0 Or Me._strPSPrice_Number.Trim.Length = 0 Then
                    Exit Sub
                End If

                If Me._strPSPrice_Number <> Me.LCD_PART_NUMBER And Me._strPSPrice_Number <> Me.MAINBOARD_PART_NUMBER Then
                    Me.txtNewSN.Text = ""
                    Me.pnlNewSN_IMEI.Visible = False
                    Exit Sub
                End If
                dtNewIMEI = Me._objHTC.GetNewSNAndIMEI(Me.txtNewSN.Text.Trim.ToUpper)

                If dtNewIMEI.Rows.Count = 0 Then
                    MessageBox.Show("This SN has not yet input into the system. Please give it back to the part cage.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.txtNewSN.SelectAll()
                    Exit Sub
                ElseIf Me._strPSPrice_Number = Me.MAINBOARD_PART_NUMBER AndAlso IsDBNull(dtNewIMEI.Rows(0)("IMEI")) Then
                    MessageBox.Show("This SN has does not have IMEI associate with it. Please give it back to the part cage.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.txtNewSN.SelectAll()
                    Exit Sub
                ElseIf Me._strPSPrice_Number = Me.MAINBOARD_PART_NUMBER AndAlso dtNewIMEI.Rows(0)("IMEI").ToString.Trim.Length = 0 Then
                    MessageBox.Show("This SN has does not have IMEI associate with it. Please give it back to the part cage.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.txtNewSN.SelectAll()
                    Exit Sub
                End If

                dtSelectedFCRC = Me._objHTC.GetDeviceRepairDisplayList(Me._iDeviceID)
                If dtSelectedFCRC.Select("BillCode_ID = " & Me._iBillcodeID.ToString).Length > 0 Then
                    'Billcode already exist
                    Me.Close()
                End If

                If Not IsDBNull(dtNewIMEI.Rows(0)("IMEI")) Then strNewIMEI = dtNewIMEI.Rows(0)("IMEI")
                strNewSN = dtNewIMEI.Rows(0)("SN")
                If Me._iRepairID = PSS.Data.Buisness.HTC.HTC_COSMETIC_REPAIRID Then iIsRef = 1

                If Me._iFailID > 0 Or Me._iRepairID > 0 Then
                    If dtSelectedFCRC.Select("Fail_ID = " & Me._iFailID.ToString & " AND Repair_ID is null").Length > 0 Then
                        i = Me._objHTC.InsertFailCodeRepCode_ToRepairTable(dtSelectedFCRC.Select("Fail_ID = " & Me._iFailID.ToString & " AND Repair_ID is null")(0)("RI_ID"), Me._iDeviceID, Me._iMC_ID, Me._iFailID, Me._iRepairID, PSS.Core.Global.ApplicationUser.IDuser, Me._strStation, , iIsRef, Me._iBillcodeID, Me._iPSPrice_ID, Me._strPSPrice_Number, strNewSN, strNewIMEI)
                    Else
                        'NO Fail select
                        i = Me._objHTC.InsertFailCodeRepCode_ToRepairTable(0, Me._iDeviceID, Me._iMC_ID, Me._iFailID, Me._iRepairID, PSS.Core.Global.ApplicationUser.IDuser, Me._strStation, , iIsRef, Me._iBillcodeID, Me._iPSPrice_ID, Me._strPSPrice_Number, strNewSN, strNewIMEI)
                    End If
                    'Set consumed device_ID in table thtcsnimeimap
                    i = Me._objHTC.SetConsumeInfoToThtcsnIMEImap(Me._iDeviceID, PSS.Core.Global.ApplicationUser.IDuser, dtNewIMEI.Rows(0)("SI_ID"))
                    Me.Close()
                Else
                    Me.chklstFailCodes.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "NewSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dtSelectedFCRC)
            PSS.Data.Buisness.Generic.DisposeDT(dtNewIMEI)
        End Try
    End Sub

    '******************************************************************
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me._booCancelCollection = True
        Me.Close()
    End Sub

    '******************************************************************
    Private Sub chklstFailCodes_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles chklstFailCodes.ItemCheck
        Dim iIsRef As Integer = 0
        Dim i As Integer = 0
        Dim dtSelectedFCRC As DataTable

        Try
            If e.NewValue = CheckState.Unchecked Then
                Exit Sub
            ElseIf e.NewValue = CheckState.Checked Then
                Me._iFailID = Me.chklstFailCodes.SelectedValue
                Me._iRepairID = Me.chklstFailCodes.SelectedItem("Repair_ID")
                Me._iMC_ID = Me._objHTC.GetFailMainCategoryIDFromFCRC(Me._iFailID, Me._iRepairID)
                Me._iPSPrice_ID = Me.chklstFailCodes.SelectedItem("PSPrice_ID")
                Me._strPSPrice_Number = Me.chklstFailCodes.SelectedItem("PSPrice_Number").ToString.Trim.ToUpper

                'If billcode is LCD or Mainboard then collect newSN and newIMEI
                If Me._strPSPrice_Number = Me.LCD_PART_NUMBER Or Me._strPSPrice_Number = Me.MAINBOARD_PART_NUMBER Then
                    Me.pnlNewSN_IMEI.Visible = True
                    Me.txtNewSN.Text = ""
                    Me.txtNewSN.Focus()
                Else
                    If Me._iRepairID = PSS.Data.Buisness.HTC.HTC_COSMETIC_REPAIRID Then iIsRef = 1

                    dtSelectedFCRC = Me._objHTC.GetDeviceRepairDisplayList(Me._iDeviceID)
                    If dtSelectedFCRC.Select("BillCode_ID = " & Me._iBillcodeID.ToString).Length > 0 Then
                        'Billcode already exist
                        Me.Close()
                    End If
                    If dtSelectedFCRC.Select("Fail_ID = " & Me._iFailID.ToString & " AND Repair_ID is null").Length > 0 Then
                        i = Me._objHTC.InsertFailCodeRepCode_ToRepairTable(dtSelectedFCRC.Select("Fail_ID = " & Me._iFailID.ToString & " AND Repair_ID is null")(0)("RI_ID"), Me._iDeviceID, Me._iMC_ID, Me._iFailID, Me._iRepairID, PSS.Core.Global.ApplicationUser.IDuser, Me._strStation, , iIsRef, Me._iBillcodeID, Me._iPSPrice_ID, Me._strPSPrice_Number, , )
                        Me.Close()
                    Else
                        'NO Fail select
                        i = Me._objHTC.InsertFailCodeRepCode_ToRepairTable(0, Me._iDeviceID, Me._iMC_ID, Me._iFailID, Me._iRepairID, PSS.Core.Global.ApplicationUser.IDuser, Me._strStation, , iIsRef, Me._iBillcodeID, Me._iPSPrice_ID, Me._strPSPrice_Number, , )
                        Me.Close()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "chklstRepCode_ItemCheck", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dtSelectedFCRC)
        End Try
    End Sub

    '******************************************************************

End Class
