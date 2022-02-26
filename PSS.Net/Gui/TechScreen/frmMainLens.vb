Public Class frmMainLens
    Inherits System.Windows.Forms.Form


#Region " Windows Form Designer generated code "

    Public Sub New(ByVal vDeviceID As Long, ByVal vModel As Long)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        'Me.txtAirtime.Text = vDeviceID
        Me.getDeviceData(vDeviceID, vModel)

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
    Friend WithEvents lblAirtime As System.Windows.Forms.Label
    Friend WithEvents lblSoftwareIN As System.Windows.Forms.Label
    Friend WithEvents lblSoftwareOUT As System.Windows.Forms.Label
    Friend WithEvents lblIMEIIN As System.Windows.Forms.Label
    Friend WithEvents lblIMEIOUT As System.Windows.Forms.Label
    Friend WithEvents lblTransceiver As System.Windows.Forms.Label
    Friend WithEvents lblAirtimeCarrier As System.Windows.Forms.Label
    Friend WithEvents txtAirtime As System.Windows.Forms.TextBox
    Friend WithEvents txtSoftwareIN As System.Windows.Forms.TextBox
    Friend WithEvents txtSoftwareOUT As System.Windows.Forms.TextBox
    Friend WithEvents txtIMEIIN As System.Windows.Forms.TextBox
    Friend WithEvents txtIMEIOUT As System.Windows.Forms.TextBox
    Friend WithEvents txtAirtimeCarrier As System.Windows.Forms.TextBox
    Friend WithEvents btnInsert As System.Windows.Forms.Button
    Friend WithEvents lblMSN As System.Windows.Forms.Label
    Friend WithEvents txtMSN As System.Windows.Forms.TextBox
    Friend WithEvents cboSUG As PSS.Gui.Controls.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblAirtime = New System.Windows.Forms.Label()
        Me.lblSoftwareIN = New System.Windows.Forms.Label()
        Me.lblSoftwareOUT = New System.Windows.Forms.Label()
        Me.lblIMEIIN = New System.Windows.Forms.Label()
        Me.lblIMEIOUT = New System.Windows.Forms.Label()
        Me.lblMSN = New System.Windows.Forms.Label()
        Me.lblTransceiver = New System.Windows.Forms.Label()
        Me.lblAirtimeCarrier = New System.Windows.Forms.Label()
        Me.txtAirtime = New System.Windows.Forms.TextBox()
        Me.txtSoftwareIN = New System.Windows.Forms.TextBox()
        Me.txtSoftwareOUT = New System.Windows.Forms.TextBox()
        Me.txtIMEIIN = New System.Windows.Forms.TextBox()
        Me.txtIMEIOUT = New System.Windows.Forms.TextBox()
        Me.txtMSN = New System.Windows.Forms.TextBox()
        Me.txtAirtimeCarrier = New System.Windows.Forms.TextBox()
        Me.btnInsert = New System.Windows.Forms.Button()
        Me.cboSUG = New PSS.Gui.Controls.ComboBox()
        Me.SuspendLayout()
        '
        'lblAirtime
        '
        Me.lblAirtime.Location = New System.Drawing.Point(40, 28)
        Me.lblAirtime.Name = "lblAirtime"
        Me.lblAirtime.Size = New System.Drawing.Size(176, 16)
        Me.lblAirtime.TabIndex = 0
        Me.lblAirtime.Text = "Airtime"
        '
        'lblSoftwareIN
        '
        Me.lblSoftwareIN.Location = New System.Drawing.Point(40, 52)
        Me.lblSoftwareIN.Name = "lblSoftwareIN"
        Me.lblSoftwareIN.Size = New System.Drawing.Size(176, 16)
        Me.lblSoftwareIN.TabIndex = 0
        Me.lblSoftwareIN.Text = "Software Version IN"
        '
        'lblSoftwareOUT
        '
        Me.lblSoftwareOUT.Location = New System.Drawing.Point(40, 76)
        Me.lblSoftwareOUT.Name = "lblSoftwareOUT"
        Me.lblSoftwareOUT.Size = New System.Drawing.Size(176, 16)
        Me.lblSoftwareOUT.TabIndex = 0
        Me.lblSoftwareOUT.Text = "Software Version OUT"
        '
        'lblIMEIIN
        '
        Me.lblIMEIIN.Location = New System.Drawing.Point(40, 100)
        Me.lblIMEIIN.Name = "lblIMEIIN"
        Me.lblIMEIIN.Size = New System.Drawing.Size(176, 16)
        Me.lblIMEIIN.TabIndex = 0
        Me.lblIMEIIN.Text = "IMEI IN"
        '
        'lblIMEIOUT
        '
        Me.lblIMEIOUT.Location = New System.Drawing.Point(40, 124)
        Me.lblIMEIOUT.Name = "lblIMEIOUT"
        Me.lblIMEIOUT.Size = New System.Drawing.Size(176, 16)
        Me.lblIMEIOUT.TabIndex = 0
        Me.lblIMEIOUT.Text = "IMEI OUT"
        '
        'lblMSN
        '
        Me.lblMSN.Location = New System.Drawing.Point(40, 148)
        Me.lblMSN.Name = "lblMSN"
        Me.lblMSN.Size = New System.Drawing.Size(176, 16)
        Me.lblMSN.TabIndex = 0
        Me.lblMSN.Text = "MSN"
        '
        'lblTransceiver
        '
        Me.lblTransceiver.Location = New System.Drawing.Point(40, 196)
        Me.lblTransceiver.Name = "lblTransceiver"
        Me.lblTransceiver.Size = New System.Drawing.Size(176, 16)
        Me.lblTransceiver.TabIndex = 0
        Me.lblTransceiver.Text = "Transceiver (SJUG)"
        '
        'lblAirtimeCarrier
        '
        Me.lblAirtimeCarrier.Location = New System.Drawing.Point(40, 220)
        Me.lblAirtimeCarrier.Name = "lblAirtimeCarrier"
        Me.lblAirtimeCarrier.Size = New System.Drawing.Size(176, 16)
        Me.lblAirtimeCarrier.TabIndex = 0
        Me.lblAirtimeCarrier.Text = "Airtime Carrier Code"
        '
        'txtAirtime
        '
        Me.txtAirtime.Location = New System.Drawing.Point(224, 24)
        Me.txtAirtime.Name = "txtAirtime"
        Me.txtAirtime.Size = New System.Drawing.Size(200, 20)
        Me.txtAirtime.TabIndex = 1
        Me.txtAirtime.Text = ""
        '
        'txtSoftwareIN
        '
        Me.txtSoftwareIN.Location = New System.Drawing.Point(224, 48)
        Me.txtSoftwareIN.Name = "txtSoftwareIN"
        Me.txtSoftwareIN.Size = New System.Drawing.Size(200, 20)
        Me.txtSoftwareIN.TabIndex = 2
        Me.txtSoftwareIN.Text = ""
        '
        'txtSoftwareOUT
        '
        Me.txtSoftwareOUT.Location = New System.Drawing.Point(224, 72)
        Me.txtSoftwareOUT.Name = "txtSoftwareOUT"
        Me.txtSoftwareOUT.Size = New System.Drawing.Size(200, 20)
        Me.txtSoftwareOUT.TabIndex = 3
        Me.txtSoftwareOUT.Text = ""
        '
        'txtIMEIIN
        '
        Me.txtIMEIIN.Location = New System.Drawing.Point(224, 96)
        Me.txtIMEIIN.Name = "txtIMEIIN"
        Me.txtIMEIIN.Size = New System.Drawing.Size(200, 20)
        Me.txtIMEIIN.TabIndex = 4
        Me.txtIMEIIN.Text = ""
        '
        'txtIMEIOUT
        '
        Me.txtIMEIOUT.Location = New System.Drawing.Point(224, 120)
        Me.txtIMEIOUT.Name = "txtIMEIOUT"
        Me.txtIMEIOUT.Size = New System.Drawing.Size(200, 20)
        Me.txtIMEIOUT.TabIndex = 5
        Me.txtIMEIOUT.Text = ""
        '
        'txtMSN
        '
        Me.txtMSN.Location = New System.Drawing.Point(224, 144)
        Me.txtMSN.Name = "txtMSN"
        Me.txtMSN.Size = New System.Drawing.Size(200, 20)
        Me.txtMSN.TabIndex = 6
        Me.txtMSN.Text = ""
        '
        'txtAirtimeCarrier
        '
        Me.txtAirtimeCarrier.Location = New System.Drawing.Point(224, 216)
        Me.txtAirtimeCarrier.Name = "txtAirtimeCarrier"
        Me.txtAirtimeCarrier.Size = New System.Drawing.Size(200, 20)
        Me.txtAirtimeCarrier.TabIndex = 8
        Me.txtAirtimeCarrier.Text = ""
        '
        'btnInsert
        '
        Me.btnInsert.Location = New System.Drawing.Point(224, 248)
        Me.btnInsert.Name = "btnInsert"
        Me.btnInsert.Size = New System.Drawing.Size(200, 23)
        Me.btnInsert.TabIndex = 9
        Me.btnInsert.Text = "SET DATA"
        '
        'cboSUG
        '
        Me.cboSUG.AutoComplete = True
        Me.cboSUG.Location = New System.Drawing.Point(224, 192)
        Me.cboSUG.Name = "cboSUG"
        Me.cboSUG.Size = New System.Drawing.Size(200, 21)
        Me.cboSUG.TabIndex = 7
        '
        'frmMainLens
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(448, 285)
        Me.ControlBox = False
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboSUG, Me.btnInsert, Me.txtAirtimeCarrier, Me.txtMSN, Me.txtIMEIOUT, Me.txtIMEIIN, Me.txtSoftwareOUT, Me.txtSoftwareIN, Me.txtAirtime, Me.lblAirtimeCarrier, Me.lblTransceiver, Me.lblMSN, Me.lblIMEIOUT, Me.lblIMEIIN, Me.lblSoftwareOUT, Me.lblSoftwareIN, Me.lblAirtime})
        Me.Name = "frmMainLens"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Load NSC Data"
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private mDevice As Long
    Private blnZ As Boolean

    Private Sub frmMainLens_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub


    Private Sub getDeviceData(ByVal vdeviceid As Long, ByVal vModelID As Long)

        mDevice = vdeviceid

        Dim dtDefault As DataTable = PSS.Data.Production.Joins.OrderEntrySelect("SELECT * FROM lv3lensdefaults")
        Dim rdefault As DataRow = dtDefault.Rows(0)

        Dim dtSUGDefault As DataTable
        dtSUGDefault = PSS.Data.Production.Joins.OrderEntrySelect("SELECT * FROM llenssugdefault WHERE Model_ID = " & vModelID & " ORDER BY LensSUG_Text")

        Dim rSUGdefault As DataRow
        Dim xcount As Integer


        Me.cboSUG.DataSource = dtSUGDefault
        Me.cboSUG.DisplayMember = dtSUGDefault.Columns("LensSUG_TEXT").ToString

        Dim dt As DataTable = PSS.Data.Production.Joins.OrderEntrySelect("SELECT * FROM tcellopt WHERE device_id = " & vdeviceid)
        Dim r As DataRow = dt.Rows(0)

        If IsDBNull(r("cellopt_airtime")) = False Then
            Me.txtAirtime.Text = r("cellopt_airtime")
            Me.txtAirtime.Enabled = False
        Else
            Me.txtAirtime.Text = rdefault("Lens_Airtime")
            Me.txtAirtime.Enabled = False
        End If

        If IsDBNull(r("cellopt_SoftVerIN")) = False Then
            Me.txtSoftwareIN.Text = r("cellopt_SoftVerIN")
            Me.txtSoftwareIN.Enabled = False
        Else
            Me.txtSoftwareIN.Text = rdefault("Lens_SoftwareIN")
            Me.txtSoftwareIN.Enabled = False
        End If

        If IsDBNull(r("cellopt_SoftVerOUT")) = False Then
            Me.txtSoftwareOUT.Text = r("cellopt_SoftVerOUT")
            Me.txtSoftwareOUT.Enabled = False
        Else
            Me.txtSoftwareOUT.Text = rdefault("Lens_SoftwareOUT")
            Me.txtSoftwareOUT.Enabled = False
        End If

        If IsDBNull(r("cellopt_IMEI")) = False Then
            Me.txtIMEIIN.Text = r("cellopt_IMEI")
            Me.txtIMEIIN.Enabled = False
        End If

        If IsDBNull(r("cellopt_OutIMEI")) = False Then
            Me.txtIMEIOUT.Text = r("cellopt_OutIMEI")
            Me.txtIMEIOUT.Enabled = False
        End If

        Me.txtMSN.Text = ""
        If IsDBNull(r("cellopt_OutMSN")) = False Then
            'Me.txtMSN.Text = r("cellopt_OutMSN")
        Else
        End If

        If IsDBNull(r("cellopt_SUGIN")) = False Then
            'Me.cboSUG.SelectedText = r("cellopt_SUGIN")
            Me.cboSUG.Text = ""
        Else
        End If

        If IsDBNull(r("cellopt_AirCarrCode")) = False Then
            Me.txtAirtimeCarrier.Text = r("cellopt_AirCarrCode")
            Me.txtAirtimeCarrier.Enabled = False
        Else
            Me.txtAirtimeCarrier.Text = rdefault("Lens_AirtimeCarrCode")
            Me.txtAirtimeCarrier.Enabled = False
        End If


    End Sub


    Private Sub btnInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsert.Click

        Dim blnOK As Boolean = False

        '//MSN Rules
        '//MSN Must Start with D54
        Try
            If UCase(Mid$(Me.txtMSN.Text, 1, 3)) <> "D54" Then
                MsgBox("An MSN Value always starts with D54", MsgBoxStyle.OKOnly, "ERROR")
                Me.txtMSN.Focus()
                Exit Sub
            End If
        Catch ex As Exception
        End Try
        '//MSN Must be 10 characters or more
        Try
            If Len(Trim(Me.txtMSN.Text)) < 10 Then
                MsgBox("An MSN Value must be at least 10 characters", MsgBoxStyle.OKOnly, "ERROR")
                Me.txtMSN.Focus()
                Exit Sub
            End If
        Catch ex As Exception
        End Try
        '//MSN Must be less than 13 characters
        Try
            If Len(Trim(Me.txtMSN.Text)) > 11 Then
                MsgBox("An MSN Value must can not be greater than 13 characters", MsgBoxStyle.OKOnly, "ERROR")
                Me.txtMSN.Focus()
                Exit Sub
            End If
        Catch ex As Exception
        End Try
        '//SJUG Must start with SJUG
        Try
            If UCase(Mid$(Me.cboSUG.Text, 1, 4)) <> "SJUG" Then
                MsgBox("An SJUG Value always starts with SJUG", MsgBoxStyle.OKOnly, "ERROR")
                Me.cboSUG.Focus()
                Exit Sub
            End If
        Catch ex As Exception
        End Try
        '//SJUG Must be less than 12 characters
        Try
            If Len(Trim(Me.cboSUG.Text)) > 12 Then
                MsgBox("An SJUG Value must can not be greater than 12 characters", MsgBoxStyle.OKOnly, "ERROR")
                Me.cboSUG.Focus()
                Exit Sub
            End If
        Catch ex As Exception
        End Try
        '//SJUG Must be gretaer than 9 characters
        Try
            If Len(Trim(Me.cboSUG.Text)) < 9 Then
                MsgBox("An SJUG Value must can not be less than 10 characters", MsgBoxStyle.OKOnly, "ERROR")
                Me.cboSUG.Focus()
                Exit Sub
            End If
        Catch ex As Exception
        End Try

        If Len(Trim(Me.txtAirtime.Text)) > 0 Then
            If Len(Trim(Me.txtAirtimeCarrier.Text)) > 0 Then
                If Len(Trim(Me.txtIMEIIN.Text)) > 0 Then
                    If Len(Trim(Me.txtIMEIOUT.Text)) > 0 Then
                        If Len(Trim(Me.txtMSN.Text)) > 0 Then
                            If Len(Trim(Me.txtSoftwareIN.Text)) > 0 Then
                                If Len(Trim(Me.txtSoftwareOUT.Text)) > 0 Then
                                    If Len(Trim(Me.cboSUG.Text)) > 0 Then
                                        '//Update record
                                        Dim strSQL As String = "UPDATE tcellopt set cellopt_Airtime = '" & Trim(Me.txtAirtime.Text) & "', " & _
                                        "cellopt_AirCarrCode = " & Me.txtAirtimeCarrier.Text & ", " & _
                                        "cellopt_IMEI = '" & Me.txtIMEIIN.Text & "', " & _
                                        "cellopt_OutIMEI = '" & Me.txtIMEIOUT.Text & "', " & _
                                        "cellopt_MSN = '" & UCase(Me.txtMSN.Text) & "', " & _
                                        "cellopt_OutMSN = '" & UCase(Me.txtMSN.Text) & "', " & _
                                        "cellopt_SoftVerIN = '" & Me.txtSoftwareIN.Text & "', " & _
                                        "cellopt_SoftVerOUT = '" & Me.txtSoftwareOUT.Text & "', " & _
                                        "cellopt_SugIn = '" & Me.cboSUG.Text & "', " & _
                                        "cellopt_SugOut = '" & Me.cboSUG.Text & "', " & _
                                        "cellopt_Transceiver = '" & Me.cboSUG.Text & "' WHERE device_id = " & mDevice

                                        If mDevice > 0 Then
                                            Dim blnUpdate As Boolean = PSS.Data.Production.Joins.OrderEntryUpdateDelete(strSQL)
                                            blnOK = True
                                        End If

                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

        If blnOK = True Then
            Me.Close()
        Else
            MsgBox("the data must be complete to continue", MsgBoxStyle.OKOnly)
            Exit Sub
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        blnZ = False
        Me.Close()
    End Sub

End Class
