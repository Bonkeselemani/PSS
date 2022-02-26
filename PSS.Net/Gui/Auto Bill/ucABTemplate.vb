Option Explicit On 

Public Class ucABtemplate
    Inherits System.Windows.Forms.UserControl

    Private _objMisc As PSS.Data.production.Misc
    Private _iCust_ID As Long
    Private _iModel_ID As Integer
    Private _strEnterprise As String
    Private _iBillcode_ID As Integer
    Private _booActive As Boolean
    Private _strNavPartDesc_Tooltip As String
    Private idx_txtBG As Integer

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal iCust_ID As Long, _
                   ByVal iModel_ID As Integer, _
                   ByVal strEnterprise As String, _
                   ByVal iBillcode_ID As Integer, _
                   ByVal strPsprice As String, _
                   ByVal strPsprice_Desc As String, _
                   ByVal strBillcode_Desc As String, _
                   ByVal iLaborLvl As Integer, _
                   ByVal dbInvAmt As Double, _
                   ByVal iTpsmapInvisible As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _booActive = False
        _iCust_ID = iCust_ID
        _iModel_ID = iModel_ID
        _strEnterprise = strEnterprise
        _iBillcode_ID = iBillcode_ID
        _strNavPartDesc_Tooltip = strPsprice_Desc

        Me.lblItem.Text = strPsprice

        Me.lblBCdesc.Text = strBillcode_Desc
        Me.lblLaborLvl.Text = iLaborLvl
        Me.lblPrice.Text = Format(dbInvAmt, "$ ##0.00")
        Me.lblTpsmapInactive.Text = iTpsmapInvisible
        _objMisc = New PSS.Data.Production.Misc()

    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents lblBCdesc As System.Windows.Forms.Label
    Friend WithEvents lblLaborLvl As System.Windows.Forms.Label
    Friend WithEvents lblPrice As System.Windows.Forms.Label
    Friend WithEvents chk3 As System.Windows.Forms.CheckBox
    Friend WithEvents chk4 As System.Windows.Forms.CheckBox
    Friend WithEvents chk5 As System.Windows.Forms.CheckBox
    Friend WithEvents chk7 As System.Windows.Forms.CheckBox
    Friend WithEvents chk9 As System.Windows.Forms.CheckBox
    Friend WithEvents chk1 As System.Windows.Forms.CheckBox
    Friend WithEvents chk6 As System.Windows.Forms.CheckBox
    Friend WithEvents chk8 As System.Windows.Forms.CheckBox
    Friend WithEvents chk2 As System.Windows.Forms.CheckBox
    Friend WithEvents lblTpsmapInactive As System.Windows.Forms.Label
    Friend WithEvents chk0 As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblItem = New System.Windows.Forms.Label()
        Me.lblBCdesc = New System.Windows.Forms.Label()
        Me.lblLaborLvl = New System.Windows.Forms.Label()
        Me.lblPrice = New System.Windows.Forms.Label()
        Me.chk3 = New System.Windows.Forms.CheckBox()
        Me.chk4 = New System.Windows.Forms.CheckBox()
        Me.chk5 = New System.Windows.Forms.CheckBox()
        Me.chk7 = New System.Windows.Forms.CheckBox()
        Me.chk9 = New System.Windows.Forms.CheckBox()
        Me.chk1 = New System.Windows.Forms.CheckBox()
        Me.chk6 = New System.Windows.Forms.CheckBox()
        Me.chk8 = New System.Windows.Forms.CheckBox()
        Me.chk2 = New System.Windows.Forms.CheckBox()
        Me.lblTpsmapInactive = New System.Windows.Forms.Label()
        Me.chk0 = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'lblItem
        '
        Me.lblItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItem.Location = New System.Drawing.Point(8, 8)
        Me.lblItem.Name = "lblItem"
        Me.lblItem.Size = New System.Drawing.Size(176, 16)
        Me.lblItem.TabIndex = 0
        Me.lblItem.Text = "lblItem"
        '
        'lblBCdesc
        '
        Me.lblBCdesc.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblBCdesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBCdesc.Location = New System.Drawing.Point(192, 8)
        Me.lblBCdesc.Name = "lblBCdesc"
        Me.lblBCdesc.Size = New System.Drawing.Size(96, 16)
        Me.lblBCdesc.TabIndex = 1
        Me.lblBCdesc.Text = "lblBCdesc"
        '
        'lblLaborLvl
        '
        Me.lblLaborLvl.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblLaborLvl.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLaborLvl.Location = New System.Drawing.Point(352, 8)
        Me.lblLaborLvl.Name = "lblLaborLvl"
        Me.lblLaborLvl.Size = New System.Drawing.Size(16, 16)
        Me.lblLaborLvl.TabIndex = 2
        Me.lblLaborLvl.Text = "Lvl"
        '
        'lblPrice
        '
        Me.lblPrice.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrice.Location = New System.Drawing.Point(376, 8)
        Me.lblPrice.Name = "lblPrice"
        Me.lblPrice.Size = New System.Drawing.Size(40, 16)
        Me.lblPrice.TabIndex = 3
        Me.lblPrice.Text = "lblPrice"
        '
        'chk3
        '
        Me.chk3.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.chk3.BackColor = System.Drawing.Color.LightGreen
        Me.chk3.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chk3.Location = New System.Drawing.Point(552, 0)
        Me.chk3.Name = "chk3"
        Me.chk3.Size = New System.Drawing.Size(48, 24)
        Me.chk3.TabIndex = 5
        Me.chk3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chk4
        '
        Me.chk4.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.chk4.BackColor = System.Drawing.Color.SteelBlue
        Me.chk4.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chk4.ForeColor = System.Drawing.Color.Transparent
        Me.chk4.Location = New System.Drawing.Point(600, 0)
        Me.chk4.Name = "chk4"
        Me.chk4.Size = New System.Drawing.Size(48, 24)
        Me.chk4.TabIndex = 7
        Me.chk4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chk5
        '
        Me.chk5.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.chk5.BackColor = System.Drawing.Color.LightGreen
        Me.chk5.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chk5.Location = New System.Drawing.Point(648, 0)
        Me.chk5.Name = "chk5"
        Me.chk5.Size = New System.Drawing.Size(48, 24)
        Me.chk5.TabIndex = 8
        Me.chk5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chk7
        '
        Me.chk7.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.chk7.BackColor = System.Drawing.Color.LightGreen
        Me.chk7.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chk7.Location = New System.Drawing.Point(744, 0)
        Me.chk7.Name = "chk7"
        Me.chk7.Size = New System.Drawing.Size(48, 24)
        Me.chk7.TabIndex = 9
        Me.chk7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chk9
        '
        Me.chk9.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.chk9.BackColor = System.Drawing.Color.LightGreen
        Me.chk9.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chk9.Location = New System.Drawing.Point(840, 0)
        Me.chk9.Name = "chk9"
        Me.chk9.Size = New System.Drawing.Size(48, 24)
        Me.chk9.TabIndex = 10
        Me.chk9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chk1
        '
        Me.chk1.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.chk1.BackColor = System.Drawing.Color.LightGreen
        Me.chk1.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chk1.Location = New System.Drawing.Point(456, 0)
        Me.chk1.Name = "chk1"
        Me.chk1.Size = New System.Drawing.Size(48, 24)
        Me.chk1.TabIndex = 11
        Me.chk1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chk6
        '
        Me.chk6.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.chk6.BackColor = System.Drawing.Color.SteelBlue
        Me.chk6.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chk6.ForeColor = System.Drawing.Color.Transparent
        Me.chk6.Location = New System.Drawing.Point(696, 0)
        Me.chk6.Name = "chk6"
        Me.chk6.Size = New System.Drawing.Size(48, 24)
        Me.chk6.TabIndex = 12
        Me.chk6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chk8
        '
        Me.chk8.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.chk8.BackColor = System.Drawing.Color.SteelBlue
        Me.chk8.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chk8.ForeColor = System.Drawing.Color.Transparent
        Me.chk8.Location = New System.Drawing.Point(792, 0)
        Me.chk8.Name = "chk8"
        Me.chk8.Size = New System.Drawing.Size(48, 24)
        Me.chk8.TabIndex = 13
        Me.chk8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chk2
        '
        Me.chk2.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.chk2.BackColor = System.Drawing.Color.SteelBlue
        Me.chk2.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chk2.ForeColor = System.Drawing.Color.Transparent
        Me.chk2.Location = New System.Drawing.Point(503, 0)
        Me.chk2.Name = "chk2"
        Me.chk2.Size = New System.Drawing.Size(48, 24)
        Me.chk2.TabIndex = 14
        Me.chk2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTpsmapInactive
        '
        Me.lblTpsmapInactive.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblTpsmapInactive.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTpsmapInactive.Location = New System.Drawing.Point(304, 8)
        Me.lblTpsmapInactive.Name = "lblTpsmapInactive"
        Me.lblTpsmapInactive.Size = New System.Drawing.Size(40, 16)
        Me.lblTpsmapInactive.TabIndex = 15
        '
        'chk0
        '
        Me.chk0.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.chk0.BackColor = System.Drawing.Color.SteelBlue
        Me.chk0.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chk0.ForeColor = System.Drawing.Color.Transparent
        Me.chk0.Location = New System.Drawing.Point(408, 0)
        Me.chk0.Name = "chk0"
        Me.chk0.Size = New System.Drawing.Size(48, 24)
        Me.chk0.TabIndex = 16
        Me.chk0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ucABtemplate
        '
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.chk0, Me.lblTpsmapInactive, Me.chk2, Me.chk8, Me.chk6, Me.chk1, Me.chk9, Me.chk7, Me.chk5, Me.chk4, Me.chk3, Me.lblPrice, Me.lblLaborLvl, Me.lblBCdesc, Me.lblItem})
        Me.Name = "ucABtemplate"
        Me.Size = New System.Drawing.Size(888, 24)
        Me.ResumeLayout(False)

    End Sub

#End Region

    '*****************************************************************
    Private Sub ucABtemplate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strSql As String
        Dim dt1 As DataTable
        Dim R1 As DataRow

        Try
            '********************************
            'Reset billcode check controls
            '********************************
            chk0.Checked = False
            chk1.Checked = False
            chk2.Checked = False
            chk3.Checked = False
            chk4.Checked = False
            chk5.Checked = False
            chk6.Checked = False
            chk7.Checked = False
            chk8.Checked = False
            chk9.Checked = False

            '********************************
            'Get Active/Inactive billcodes
            '********************************
            strSql = "SELECT * FROM tbillgroup " & Environment.NewLine
            strSql &= "WHERE bg_cust_id = " & _iCust_ID & " " & Environment.NewLine
            strSql &= "AND bg_model_id = " & _iModel_ID & " " & Environment.NewLine
            strSql &= "AND bg_enterprise = '" & _strEnterprise & "' " & Environment.NewLine
            strSql &= "AND billcode_id = " & _iBillcode_ID & ";"
            Me._objMisc._SQL = strSql
            dt1 = _objMisc.GetDataTable()


            '********************************
            'Set billcodec check box 
            '********************************
            For Each R1 In dt1.Rows

                Select Case R1("bg_bill_group")
                    Case "BG0"
                        If R1("bg_Inactive") = 0 Then chk0.Checked = True
                    Case "BG1"
                        If R1("bg_Inactive") = 0 Then chk1.Checked = True
                    Case "BG2"
                        If R1("bg_Inactive") = 0 Then chk2.Checked = True
                    Case "BG3"
                        If R1("bg_Inactive") = 0 Then chk3.Checked = True
                    Case "BG4"
                        If R1("bg_Inactive") = 0 Then chk4.Checked = True
                    Case "BG5"
                        If R1("bg_Inactive") = 0 Then chk5.Checked = True
                    Case "BG6"
                        If R1("bg_Inactive") = 0 Then chk6.Checked = True
                    Case "BG7"
                        If R1("bg_Inactive") = 0 Then chk7.Checked = True
                    Case "BG8"
                        If R1("bg_Inactive") = 0 Then chk8.Checked = True
                    Case "BG9"
                        If R1("bg_Inactive") = 0 Then chk9.Checked = True
                End Select
            Next R1

            GetControlIdx()

            _booActive = True
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "ucABtemplate_Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
        End Try
    End Sub

    '*****************************************************************
    Private Sub GetControlIdx()
        Dim ctl As Control
        Dim i As Integer = 0

        Try
            For i = 0 To Me.ParentForm.Controls.Count - 1
                If Me.ParentForm.Controls(i).Name = "idx_txtBG" Then
                    idx_txtBG = i
                    Exit Sub
                End If
            Next i
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '*****************************************************************
    Private Sub RecordData(ByVal i As Integer, ByRef ctl As Control)
        Dim bCheck As Boolean
        Dim iInactive As Integer

        Try
            bCheck = CType(ctl, CheckBox).Checked

            If bCheck = True Then
                iInactive = 0
            Else
                iInactive = 1
            End If

            Me.RecordDataChange(_iCust_ID, _iModel_ID, _strEnterprise, "BG" & i, iInactive)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '*****************************************************************
    Private Sub chk0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk0.CheckedChanged
        If _booActive = True Then
            RecordData(0, chk0)
            Me.ParentForm.Controls(idx_txtBG).Text = 0
        End If
    End Sub

    '*****************************************************************
    Private Sub chk1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk1.CheckedChanged
        If _booActive = True Then
            RecordData(1, chk1)
            Me.ParentForm.Controls(idx_txtBG).Text = 1
        End If
    End Sub

    '*****************************************************************
    Private Sub chk2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk2.CheckedChanged
        If _booActive = True Then
            RecordData(2, chk2)
            Me.ParentForm.Controls(idx_txtBG).Text = 2
        End If
    End Sub

    '*****************************************************************
    Private Sub chk3_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk3.CheckedChanged
        If _booActive = True Then
            RecordData(3, chk3)
            Me.ParentForm.Controls(idx_txtBG).Text = 3
        End If
    End Sub

    '*****************************************************************
    Private Sub chk4_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk4.CheckedChanged
        If _booActive = True Then
            RecordData(4, chk4)
            Me.ParentForm.Controls(idx_txtBG).Text = 4
        End If
    End Sub

    '*****************************************************************
    Private Sub chk5_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk5.CheckedChanged
        If _booActive = True Then
            RecordData(5, chk5)
            Me.ParentForm.Controls(idx_txtBG).Text = 5
        End If
    End Sub

    '*****************************************************************
    Private Sub chk6_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk6.CheckedChanged
        If _booActive = True Then
            RecordData(6, chk6)
            Me.ParentForm.Controls(idx_txtBG).Text = 6
        End If
    End Sub

    '*****************************************************************
    Private Sub chk7_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk7.CheckedChanged
        If _booActive = True Then
            RecordData(7, chk7)
            Me.ParentForm.Controls(idx_txtBG).Text = 7
        End If
    End Sub

    '*****************************************************************
    Private Sub chk8_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk8.CheckedChanged
        If _booActive = True Then
            RecordData(8, chk8)
            Me.ParentForm.Controls(idx_txtBG).Text = 8
        End If
    End Sub

    '*****************************************************************
    Private Sub chk9_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk9.CheckedChanged
        If _booActive = True Then
            RecordData(9, chk9)
            Me.ParentForm.Controls(idx_txtBG).Text = 9
        End If
    End Sub

    '*****************************************************************
    Private Function RecordDataChange(ByVal iCust_ID As Long, _
                                      ByVal iModel As Integer, _
                                      ByVal strEnterprise As String, _
                                      ByVal strBillGrpName As String, _
                                      ByVal iInactiveFlg As Integer) As Integer

        Dim iBillLevel As Integer = 1
        Dim i As Integer
        Dim dt1 As DataTable
        Dim R1 As DataRow
        Dim strSql As String
        Dim iBg_ID As Integer = 0
        Dim objBillGrpAdmin As PSS.Data.Buisness.BillGroupsAdmin

        Try
            '//Does record exist?
            '//**************************************************************************************************************
            strSql = "SELECT * " & Environment.NewLine
            strSql &= "FROM tbillgroup " & Environment.NewLine
            strSql &= "WHERE bg_cust_id = " & _iCust_ID & " " & Environment.NewLine
            strSql &= "AND bg_model_id = " & _iModel_ID & " " & Environment.NewLine
            strSql &= "AND bg_enterprise = '" & _strEnterprise & "' " & Environment.NewLine
            strSql &= "AND bg_bill_group = '" & strBillGrpName & "' " & Environment.NewLine
            'strSql &= "AND billcode_id = " & _iBillcode_ID & ";"

            Me._objMisc._SQL = strSql
            dt1 = Me._objMisc.GetDataTable()

            For Each R1 In dt1.Rows
                If R1("billcode_id") = _iBillcode_ID Then
                    iBg_ID = R1("bg_id")
                    Exit For
                End If
            Next R1

            '//**************************************************************************************************************
            If iBg_ID > 0 Then
                '//Record does exists - UPDATE
                '//**************************************************************************************************************
                strSql = "UPDATE tbillgroup " & Environment.NewLine
                strSql &= "SET bg_Inactive = " & iInactiveFlg & " " & Environment.NewLine
                strSql &= "WHERE bg_id = " & iBg_ID & ";"
                Me._objMisc._SQL = strSql
                i += Me._objMisc.ExecuteNonQuery()
                '//**************************************************************************************************************
            Else
                If dt1.Rows.Count > 0 Then
                    iBillLevel = dt1.Rows(0)("bg_level")
                Else
                    objBillGrpAdmin = New PSS.Data.Buisness.BillGroupsAdmin()
                    iBillLevel = objBillGrpAdmin.GetBillLevel(_iCust_ID, _iModel_ID)
                End If
                '//Record does not exists - INSERT
                strSql = "INSERT INTO tbillgroup ( " & Environment.NewLine
                strSql &= "bg_cust_id" & Environment.NewLine
                strSql &= ", bg_model_id " & Environment.NewLine
                strSql &= ", bg_enterprise " & Environment.NewLine
                strSql &= ", bg_bill_group " & Environment.NewLine
                strSql &= ", billcode_id " & Environment.NewLine
                strSql &= ", bg_level " & Environment.NewLine
                strSql &= ", bg_inactive " & Environment.NewLine
                strSql &= ") VALUES ( " & Environment.NewLine
                strSql &= iCust_ID & Environment.NewLine
                strSql &= ", " & iModel & Environment.NewLine
                strSql &= ", '" & strEnterprise & "' " & Environment.NewLine
                strSql &= ", '" & strBillGrpName & "' " & Environment.NewLine
                strSql &= ", " & _iBillcode_ID & " " & Environment.NewLine
                strSql &= ", " & iBillLevel & Environment.NewLine
                strSql &= ", " & iInactiveFlg & ")" & Environment.NewLine
                Me._objMisc._SQL = strSql
                i += Me._objMisc.ExecuteNonQuery()
            End If

            Return i
        Catch ex As Exception
            Throw ex
        Finally
            objBillGrpAdmin = Nothing
            R1 = Nothing
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
        End Try
    End Function

    '*****************************************************************
    Private Sub lblItem_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblItem.MouseHover
        Dim ttItem As New ToolTip()

        Try
            ttItem.SetToolTip(Me.lblItem, Me._strNavPartDesc_Tooltip)
            ttItem.InitialDelay = 200
            ttItem.ReshowDelay = 100
            ttItem.AutoPopDelay = 5000
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "LabelItem_MouseHover", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*****************************************************************


End Class
