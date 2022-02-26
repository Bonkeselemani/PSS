Namespace uctlCustomer

    Public Class ucCustomer
        Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call

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
        Friend WithEvents lblCustomer As System.Windows.Forms.Label
        Friend WithEvents lblLocation As System.Windows.Forms.Label
        Friend WithEvents txtLocation As System.Windows.Forms.TextBox
        Friend WithEvents txtLocationLONG As System.Windows.Forms.TextBox
        Friend WithEvents cboCustomer As PSS.Gui.Controls.ComboBox
        Friend WithEvents cboLocation As PSS.Gui.Controls.ComboBox
        Friend WithEvents lblHeading As System.Windows.Forms.Label
        Friend WithEvents btnClose As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.lblCustomer = New System.Windows.Forms.Label()
            Me.lblLocation = New System.Windows.Forms.Label()
            Me.txtLocation = New System.Windows.Forms.TextBox()
            Me.txtLocationLONG = New System.Windows.Forms.TextBox()
            Me.cboCustomer = New PSS.Gui.Controls.ComboBox()
            Me.cboLocation = New PSS.Gui.Controls.ComboBox()
            Me.lblHeading = New System.Windows.Forms.Label()
            Me.btnClose = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            '
            'lblCustomer
            '
            Me.lblCustomer.Location = New System.Drawing.Point(8, 40)
            Me.lblCustomer.Name = "lblCustomer"
            Me.lblCustomer.Size = New System.Drawing.Size(56, 16)
            Me.lblCustomer.TabIndex = 0
            Me.lblCustomer.Text = "Customer:"
            Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblLocation
            '
            Me.lblLocation.Location = New System.Drawing.Point(8, 64)
            Me.lblLocation.Name = "lblLocation"
            Me.lblLocation.Size = New System.Drawing.Size(56, 16)
            Me.lblLocation.TabIndex = 0
            Me.lblLocation.Text = "Location:"
            Me.lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtLocation
            '
            Me.txtLocation.Enabled = False
            Me.txtLocation.Location = New System.Drawing.Point(64, 56)
            Me.txtLocation.Name = "txtLocation"
            Me.txtLocation.Size = New System.Drawing.Size(128, 20)
            Me.txtLocation.TabIndex = 0
            Me.txtLocation.TabStop = False
            Me.txtLocation.Text = ""
            '
            'txtLocationLONG
            '
            Me.txtLocationLONG.BackColor = System.Drawing.SystemColors.Control
            Me.txtLocationLONG.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.txtLocationLONG.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtLocationLONG.ForeColor = System.Drawing.Color.SteelBlue
            Me.txtLocationLONG.Location = New System.Drawing.Point(80, 88)
            Me.txtLocationLONG.Multiline = True
            Me.txtLocationLONG.Name = "txtLocationLONG"
            Me.txtLocationLONG.Size = New System.Drawing.Size(248, 80)
            Me.txtLocationLONG.TabIndex = 3
            Me.txtLocationLONG.Text = ""
            '
            'cboCustomer
            '
            Me.cboCustomer.AutoComplete = True
            Me.cboCustomer.Location = New System.Drawing.Point(64, 32)
            Me.cboCustomer.Name = "cboCustomer"
            Me.cboCustomer.Size = New System.Drawing.Size(264, 21)
            Me.cboCustomer.TabIndex = 1
            '
            'cboLocation
            '
            Me.cboLocation.AutoComplete = True
            Me.cboLocation.Location = New System.Drawing.Point(192, 56)
            Me.cboLocation.Name = "cboLocation"
            Me.cboLocation.Size = New System.Drawing.Size(136, 21)
            Me.cboLocation.TabIndex = 2
            Me.cboLocation.Visible = False
            '
            'lblHeading
            '
            Me.lblHeading.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, (System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblHeading.Location = New System.Drawing.Point(8, 8)
            Me.lblHeading.Name = "lblHeading"
            Me.lblHeading.Size = New System.Drawing.Size(312, 23)
            Me.lblHeading.TabIndex = 4
            Me.lblHeading.Text = "CUSTOMER INFORMATION"
            '
            'btnClose
            '
            Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnClose.Location = New System.Drawing.Point(376, 8)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(144, 23)
            Me.btnClose.TabIndex = 16
            Me.btnClose.Text = "&Close"
            '
            'ucCustomer
            '
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnClose, Me.lblHeading, Me.cboLocation, Me.cboCustomer, Me.txtLocationLONG, Me.txtLocation, Me.lblLocation, Me.lblCustomer})
            Me.Name = "ucCustomer"
            Me.Size = New System.Drawing.Size(528, 184)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Public blnCustomer As Boolean = False
        Public RecType As Integer = 1
        Public DeviceType As Integer = 2
        Public arrLocDetail(4) As String
        Private dtLocation As DataTable
        Private dtCust As DataTable


        Public Function validateUCcustomer() As Boolean
            validateUCcustomer = False

            If Len(Trim(cboCustomer.Text)) > 0 Then
            Else
                cboCustomer.Focus()
                Exit Function
            End If

            If Len(Trim(txtLocation.Text)) > 0 Then
            Else
                txtLocation.Focus()
                Exit Function
            End If

            validateUCcustomer = True
            Me.Visible = False

        End Function

        Private Sub txtLocation_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLocation.Enter
            blnCustomer = False
        End Sub

        Private Sub txtLocationLONG_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLocationLONG.Enter
            If validateUCcustomer() = True Then Me.Visible = False
        End Sub

        Public Sub populateCustomer()

            'This will generate the data for the cboCustomerID control.
            'It will also create a two dimensional array that holds the Customer IDs
            'and Names
            Dim tblCustomer As New PSS.Data.Production.Joins()
            Dim tblCustEU As New PSS.Data.Production.tcustomer()

            '//Defines different selection lists depending on RecType
            If RecType = "1" Then 'FIRM
                dtCust = tblCustomer.CustomerListPagerFirm(DeviceType)
            End If
            If RecType = "2" Then 'COAM
                dtCust = tblCustomer.CustomerListPagerCOAM(DeviceType)
            End If
            If RecType = "5" Then 'FIRM
                dtCust = tblCustomer.CustomerListPagerFirm(DeviceType)
            End If

            cboCustomer.DataSource = dtCust.DefaultView
            cboCustomer.DisplayMember = dtCust.Columns("cust_name1").ToString
            cboCustomer.ValueMember = dtCust.Columns("cust_id").ToString
            cboCustomer.SelectedIndex = -1

        End Sub

        Private Sub populateLocations(ByVal vCustID As Int32)
            Try
                '//Clear items from dtLocation
                dtLocation = Nothing
            Catch ex As Exception
            End Try
            dtLocation = PSS.Data.Production.tlocation.GetRowsByCustomerID(vCustID)
        End Sub

        Private Sub populateCboLocation()
            Try
                cboLocation.DataSource = dtLocation
                cboLocation.DisplayMember = dtLocation.Columns("loc_name").ToString
                cboLocation.ValueMember = dtLocation.Columns("loc_id").ToString
                cboLocation.Visible = True
            Catch ex As Exception
            End Try
        End Sub

        Private Sub txtLocation_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLocation.KeyUp
            selectLocation()
        End Sub

        Private Function getStateName(ByVal vStateID) As String
            getStateName = PSS.Data.Production.lstate.GetNameByPK(vStateID)
        End Function

        Private Sub clearLocationInfo()
            txtLocation.Text = ""
            txtLocationLONG.Text = ""
        End Sub

        Private Sub cboCustomer_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustomer.Enter
            blnCustomer = False
        End Sub

        Private Sub selectLocation()

            '//Determine and display the most appropriate location
            Dim xCount As Integer = 0
            Dim r As DataRow

            For xCount = 0 To dtLocation.Rows.Count - 1
                r = dtLocation.Rows(xCount)
                If InStr(r("Loc_Name"), txtLocation.Text, CompareMethod.Text) = 1 Then
                    '//Get address
                    txtLocationLONG.Text = r("Loc_Address1") & vbCrLf & r("Loc_Address2") & vbCrLf & _
                                 r("loc_City") & ", " & getStateName(r("State_ID")) & "  " & r("Loc_Zip")

                    Dim yCount As Integer = 0

                    arrLocDetail(0) = ""
                    arrLocDetail(1) = ""
                    arrLocDetail(2) = ""
                    arrLocDetail(3) = ""
                    arrLocDetail(4) = ""

                    If IsDBNull(r("Loc_Address1")) = False Then
                        arrLocDetail(yCount) = r("Loc_Address1")
                        yCount += 1
                    End If
                    If IsDBNull(r("Loc_Address2")) = False Then
                        arrLocDetail(yCount) = r("Loc_Address2")
                        yCount += 1
                    End If
                    If Len(Trim(r("loc_City") & ", " & getStateName(r("State_ID")) & "  " & r("Loc_Zip"))) > 4 Then
                        arrLocDetail(yCount) = r("loc_City") & ", " & getStateName(r("State_ID")) & "  " & r("Loc_Zip")
                        yCount += 1
                    End If

                    Exit For
                End If
            Next

        End Sub

        Private Sub selectLocationGroup()
            Try
                If cboCustomer.SelectedValue > 0 Then
                    populateLocations(cboCustomer.SelectedValue)
                    If dtLocation.Rows.Count = 1 Then '//Force populate the values
                        Dim r As DataRow
                        r = dtLocation.Rows(0)
                        txtLocation.Text = r("Loc_Name")
                        txtLocationLONG.Text = r("Loc_Address1") & vbCrLf & r("Loc_Address2") & vbCrLf & _
                                     r("loc_City") & ", " & getStateName(r("State_ID")) & "  " & r("Loc_Zip")

                        Dim xCount As Integer = 0

                        arrLocDetail(0) = ""
                        arrLocDetail(1) = ""
                        arrLocDetail(2) = ""
                        arrLocDetail(3) = ""
                        arrLocDetail(4) = ""

                        If IsDBNull(r("Loc_Address1")) = False Then
                            arrLocDetail(xCount) = r("Loc_Address1")
                            xCount += 1
                        End If
                        If IsDBNull(r("Loc_Address2")) = False Then
                            arrLocDetail(xCount) = r("Loc_Address2")
                            xCount += 1
                        End If
                        If Len(Trim(r("loc_City") & ", " & getStateName(r("State_ID")) & "  " & r("Loc_Zip"))) > 4 Then
                            arrLocDetail(xCount) = r("loc_City") & ", " & getStateName(r("State_ID")) & "  " & r("Loc_Zip")
                            xCount += 1
                        End If
                    Else '//There is nore than one location defined for this customer
                        txtLocation.Text = ""
                        txtLocationLONG.Text = ""
                        populateCboLocation()
                    End If
                End If
            Catch ex As Exception
            End Try

        End Sub

        Private Sub cboCustomer_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustomer.SelectedValueChanged
            cboLocation.Visible = False
            selectLocationGroup()
        End Sub

        Private Sub cboLocation_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLocation.SelectedIndexChanged
            txtLocation.Text = cboLocation.Text
            selectLocation()
        End Sub

        Private Sub cboLocation_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLocation.Leave
            cboLocation.Visible = False
        End Sub

        Private Sub cboCustomer_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCustomer.KeyUp
            If e.KeyValue = 13 Then
                If Len(Trim(cboCustomer.Text)) > 0 Then

                    If VerifyCreditWorthiness() = False Then
                        Exit Sub
                    End If

                    If cboLocation.Visible = True Then
                        cboLocation.Focus()
                    Else
                        txtLocationLONG.Focus()
                    End If
                End If
            End If
        End Sub

        Private Sub cboLocation_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboLocation.KeyUp
            If e.KeyValue = 13 Then
                If Len(Trim(cboLocation.Text)) > 0 Then
                    txtLocationLONG.Focus()
                End If
            End If
        End Sub

        Private Function VerifyCreditWorthiness() As Boolean

            '//This method will examine the field Cust_CrApproveRec
            '//If this value is set to 1 then the customer is credit worthy
            Dim xCount As Integer = 0

            VerifyCreditWorthiness = False
            Try
                'Begin examination for credit worthiness
                Dim r As DataRow
                For xCount = 0 To dtCust.Rows.Count - 1
                    r = dtCust.Rows(xCount)
                    If r("cust_id") = cboCustomer.SelectedValue Then
                        If r("Cust_CrApproveRec") = 0 Then
                            '//This is displayed if the field Cust_CrApproveRec is set to 0
                            MsgBox("The Customer Account is awaiting credit approval or has exceeded it's credit limit.  Call ext 235 for status on Credit.", MsgBoxStyle.OKOnly, "Credit Issue")
                            '//A new cstomer must be selected to continue
                            cboCustomer.Focus()
                            Exit Function
                        End If
                    End If
                Next
                VerifyCreditWorthiness = True
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try

        End Function

        Private Sub ucCustomer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            cboCustomer.SelectedIndex = -1
        End Sub

        Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
            txtLocationLONG.Focus()
        End Sub

    End Class

End Namespace
