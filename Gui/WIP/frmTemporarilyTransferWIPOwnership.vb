Imports PSS.Data.Buisness

Public Class frmTemporarilyTransferWIPOwnership
    Inherits System.Windows.Forms.Form

    Private objMisc As PSS.Data.Buisness.Misc
    Private objdtSource As PSS.Data.Production.Joins
    Private objCSBER As PSS.Data.Buisness.CellStarBER
    Private dtWipTransfESNs As DataTable

    Private Shared ctl As Control
    Private Shared HighLightColor As Color = Color.Yellow
    Private Shared WindowColor As Color = Color.White
    Private Shared EnterHandler As New EventHandler(AddressOf Enter_Event)
    Private Shared LeaveHandler As New EventHandler(AddressOf Leave_Event)

    Private _dsDeviceData As DataSet
    Private Const _strDeviceData As String = "Device Data"

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
    Friend WithEvents pnlTransfer As System.Windows.Forms.Panel
    Friend WithEvents lblTempTransfer As System.Windows.Forms.Label
    Friend WithEvents lblDeviceSN As System.Windows.Forms.Label
    Friend WithEvents txtDeviceSN As System.Windows.Forms.TextBox
    Friend WithEvents lstDeviceSN As System.Windows.Forms.ListBox
    Friend WithEvents btnTransfer As System.Windows.Forms.Button
    Friend WithEvents lblSelectedSN As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.pnlTransfer = New System.Windows.Forms.Panel()
        Me.btnTransfer = New System.Windows.Forms.Button()
        Me.lstDeviceSN = New System.Windows.Forms.ListBox()
        Me.lblDeviceSN = New System.Windows.Forms.Label()
        Me.txtDeviceSN = New System.Windows.Forms.TextBox()
        Me.lblTempTransfer = New System.Windows.Forms.Label()
        Me.lblSelectedSN = New System.Windows.Forms.Label()
        Me.pnlTransfer.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTransfer
        '
        Me.pnlTransfer.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlTransfer.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblSelectedSN, Me.btnTransfer, Me.lstDeviceSN, Me.lblDeviceSN, Me.txtDeviceSN, Me.lblTempTransfer})
        Me.pnlTransfer.Location = New System.Drawing.Point(104, 16)
        Me.pnlTransfer.Name = "pnlTransfer"
        Me.pnlTransfer.Size = New System.Drawing.Size(472, 320)
        Me.pnlTransfer.TabIndex = 4
        '
        'btnTransfer
        '
        Me.btnTransfer.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnTransfer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTransfer.Location = New System.Drawing.Point(192, 280)
        Me.btnTransfer.Name = "btnTransfer"
        Me.btnTransfer.Size = New System.Drawing.Size(88, 24)
        Me.btnTransfer.TabIndex = 7
        Me.btnTransfer.Text = "Transfer"
        '
        'lstDeviceSN
        '
        Me.lstDeviceSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstDeviceSN.Location = New System.Drawing.Point(144, 88)
        Me.lstDeviceSN.Name = "lstDeviceSN"
        Me.lstDeviceSN.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstDeviceSN.Size = New System.Drawing.Size(176, 173)
        Me.lstDeviceSN.TabIndex = 6
        '
        'lblDeviceSN
        '
        Me.lblDeviceSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeviceSN.Location = New System.Drawing.Point(48, 48)
        Me.lblDeviceSN.Name = "lblDeviceSN"
        Me.lblDeviceSN.Size = New System.Drawing.Size(88, 16)
        Me.lblDeviceSN.TabIndex = 5
        Me.lblDeviceSN.Text = "Serial Number:"
        Me.lblDeviceSN.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'txtDeviceSN
        '
        Me.txtDeviceSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeviceSN.Location = New System.Drawing.Point(144, 48)
        Me.txtDeviceSN.Name = "txtDeviceSN"
        Me.txtDeviceSN.Size = New System.Drawing.Size(176, 20)
        Me.txtDeviceSN.TabIndex = 4
        Me.txtDeviceSN.Text = "TextBox1"
        Me.txtDeviceSN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblTempTransfer
        '
        Me.lblTempTransfer.BackColor = System.Drawing.Color.Black
        Me.lblTempTransfer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTempTransfer.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTempTransfer.ForeColor = System.Drawing.Color.Lime
        Me.lblTempTransfer.Name = "lblTempTransfer"
        Me.lblTempTransfer.Size = New System.Drawing.Size(472, 32)
        Me.lblTempTransfer.TabIndex = 1
        Me.lblTempTransfer.Text = "Temporarily Transfer WIP Ownership"
        Me.lblTempTransfer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSelectedSN
        '
        Me.lblSelectedSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectedSN.Location = New System.Drawing.Point(16, 88)
        Me.lblSelectedSN.Name = "lblSelectedSN"
        Me.lblSelectedSN.Size = New System.Drawing.Size(120, 16)
        Me.lblSelectedSN.TabIndex = 8
        Me.lblSelectedSN.Text = "Selected for Transfer:"
        Me.lblSelectedSN.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'frmTemporarilyTransferWIPOwnership
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(656, 357)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlTransfer})
        Me.Name = "frmTemporarilyTransferWIPOwnership"
        Me.Text = "frmTemporarilyTransferWIPOwnership"
        Me.pnlTransfer.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub frmTemporarilyTransferWIPOwnership_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtDeviceSN.Text = ""
        Dim iParentGroupID As Integer = PSS.Core.[Global].ApplicationUser.GroupID

        'Handlers to highlight in custom colors
        SetHandler(Me.txtDeviceSN)
        SetupDataSet()
        BindList()

        Me.txtDeviceSN.Focus()
    End Sub

    Private Sub SetupDataSet()
        ' Create a dataset for binding to the list box.
        Dim i As Integer
        Dim sf As New StackFrame(0)

        Try
            If Not IsNothing(Me._dsDeviceData) Then
                If Me._dsDeviceData.Tables.Count > 0 Then
                    For i = 0 To Me._dsDeviceData.Tables.Count - 1
                        Me._dsDeviceData.Tables(i).Dispose()
                    Next
                End If

                Me._dsDeviceData.Clear()
                Me._dsDeviceData.Dispose()
            End If

            Me._dsDeviceData = New DataSet(Me._strDeviceData)
            Me._dsDeviceData.Tables.Add(Me._strDeviceData)
            Me._dsDeviceData.Tables(Me._strDeviceData).Columns.Add(New DataColumn("Device SN", System.Type.GetType("System.String")))
            Me._dsDeviceData.Tables(Me._strDeviceData).Columns.Add(New DataColumn("Device ID", System.Type.GetType("System.Int32")))
            Me._dsDeviceData.Tables(Me._strDeviceData).DefaultView.Sort = "[Device SN] ASC"
        Catch ex As Exception
            PSS.Data.Production.Misc.DisplayMessage(sf.GetMethod, ex.Message)
        End Try
    End Sub

    Private Sub LoadDeviceSN(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDeviceSN.KeyDown
        Dim strDeviceSN As String = ""
        Dim dr As DataRow
        Dim wott As WIPOwnershipTempTransfer
        Dim sf As New StackFrame(0)

        Try
            If e.KeyCode = Keys.Enter Then
                Me.Busy(True)
                strDeviceSN = Me.txtDeviceSN.Text.Trim

                If strDeviceSN.Trim.Length > 0 Then
                    wott = New WIPOwnershipTempTransfer(strDeviceSN)

                    If CheckDeviceSN(wott) Then
                        dr = Me._dsDeviceData.Tables(Me._strDeviceData).NewRow
                        dr.Item(Me._dsDeviceData.Tables(Me._strDeviceData).Columns(0).ColumnName) = strDeviceSN
                        dr.Item(Me._dsDeviceData.Tables(Me._strDeviceData).Columns(1).ColumnName) = wott.DeviceID

                        Me._dsDeviceData.Tables(Me._strDeviceData).Rows.Add(dr)
                    End If

                    Me.txtDeviceSN.Text = ""
                End If
            End If
        Catch ex As Exception
            PSS.Data.Production.Misc.DisplayMessage(sf.GetMethod, ex.Message)
        Finally
            Me.Busy(False)
            Me.txtDeviceSN.Focus()
        End Try
    End Sub

    Private Function CheckDeviceSN(ByVal wott As WIPOwnershipTempTransfer) As Boolean
        Const chrDoubleQuote As Char = Chr(34)
        Dim bOK As Boolean = True
        Dim strMsg As String
        Dim iIndex As Integer = -1
        Dim sf As New StackFrame(0)

        Try
            If Not wott.IsValidDeviceSN() Then
                PSS.Data.Production.Misc.DisplayMessage(sf.GetMethod, chrDoubleQuote & wott.DeviceSN & chrDoubleQuote & " is not a valid serial number.", False)

                bOK = False
            ElseIf wott.DeviceAlreadyInList(Me.lstDeviceSN, Me._dsDeviceData.Tables(Me._strDeviceData).Columns(0).ColumnName) Then
                iIndex = Me.lstDeviceSN.Items.IndexOf(wott.DeviceSN)

                If iIndex > -1 Then Me.lstDeviceSN.SelectedIndex = iIndex

                PSS.Data.Production.Misc.DisplayMessage(sf.GetMethod, chrDoubleQuote & wott.DeviceSN & chrDoubleQuote & " is already in the transfer list.", False)

                bOK = False
            ElseIf Not wott.IsValidDeviceForTransfer() Then
                PSS.Data.Production.Misc.DisplayMessage(sf.GetMethod, chrDoubleQuote & wott.DeviceSN & chrDoubleQuote & " is not valid for transfer.", False)

                bOK = False
            End If

            Return bOK
        Catch ex As Exception
            PSS.Data.Production.Misc.DisplayMessage(sf.GetMethod, ex.Message)
        End Try
    End Function

    Private Shared Sub SetHandler(ByVal ctl As Control)
        AddHandler ctl.Enter, EnterHandler
        AddHandler ctl.Leave, LeaveHandler
        AddHandler ctl.Click, EnterHandler
    End Sub

    Private Sub BindList()
        ' Bind the list box to the previously-created dataset. 
        Dim sf As New StackFrame(0)

        Try
            If Me.lstDeviceSN.DataBindings.Count = 0 Then
                Me.lstDeviceSN.ValueMember = Me._dsDeviceData.Tables(Me._strDeviceData).Columns(1).ColumnName
                Me.lstDeviceSN.DataSource = Me._dsDeviceData.Tables(Me._strDeviceData)
                Me.lstDeviceSN.DisplayMember = Me._dsDeviceData.Tables(Me._strDeviceData).Columns(0).ColumnName
            End If
        Catch ex As Exception
            PSS.Data.Production.Misc.DisplayMessage(sf.GetMethod, ex.Message)
        Finally
        End Try
    End Sub

    '******************************************************************************
    Private Shared Sub Enter_Event(ByVal sender As Object, ByVal e As EventArgs)
        Change_Color(sender, HighLightColor)
    End Sub

    '******************************************************************************
    Private Shared Sub Leave_Event(ByVal sender As Object, ByVal e As EventArgs)
        Change_Color(sender, WindowColor)
    End Sub

    '******************************************************************************
    Private Shared Sub Change_Color(ByVal sender As Object, ByVal color As Color)
        Dim Type As String = sender.GetType.Name.ToString

        Select Case Type
            Case "ComboBox"
                CType(sender, ComboBox).BackColor = color
            Case "TextBox"
                CType(sender, TextBox).BackColor = color
            Case Else
                'no other types should be hightlighted.
        End Select
    End Sub

    Private Sub ResizeForm(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Dim sf As New StackFrame(0)

        Try
            Me.pnlTransfer.Top = 0
            Me.pnlTransfer.Left = (MyBase.Width - Me.pnlTransfer.Width) / 2
        Catch ex As Exception
            PSS.Data.Production.Misc.DisplayMessage(sf.GetMethod, ex.Message)
        End Try
    End Sub

    Private Sub Busy(ByVal bBusy As Boolean)
        Dim sf As New StackFrame(0)

        Try
            Me.lblDeviceSN.Enabled = Not bBusy
            Me.txtDeviceSN.Enabled = Not bBusy
            Me.lstDeviceSN.Enabled = Not bBusy
            Me.lblSelectedSN.Enabled = Not bBusy
            Me.btnTransfer.Enabled = (Not bBusy) And (Me.lstDeviceSN.Items.Count > 0)

            If bBusy Then
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Else
                Cursor.Current = System.Windows.Forms.Cursors.Default
            End If
        Catch ex As Exception
            PSS.Data.Production.Misc.DisplayMessage(sf.GetMethod, ex.Message)
        End Try
    End Sub

    Private Sub CheckList(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lstDeviceSN.KeyDown
        Dim i, iDeviceID, iIndex As Integer
        Dim dr As DataRow
        Dim sf As New StackFrame(0)

        Try
            If e.KeyCode = Keys.Delete Then
                Busy(True)

                If Me.lstDeviceSN.SelectedIndices.Count > 0 Then
                    ' Must go through these loops (hoops) b/c the list is sorted whereas the datatable is not 
                    ' (the associated dataview is sorted).
                    For i = Me.lstDeviceSN.SelectedIndices.Count - 1 To 0 Step -1
                        iDeviceID = Me.lstDeviceSN.Items(Me.lstDeviceSN.SelectedIndices(i))(1)
                        iIndex = -1

                        For Each dr In Me._dsDeviceData.Tables(Me._strDeviceData).Rows
                            iIndex += 1

                            If CInt(dr("Device ID")) = iDeviceID Then Exit For
                        Next

                        If iIndex > -1 Then Me._dsDeviceData.Tables(Me._strDeviceData).Rows(iIndex).Delete()
                    Next
                End If
            End If
        Catch ex As Exception
            PSS.Data.Production.Misc.DisplayMessage(sf.GetMethod, ex.Message)
        Finally
            Busy(False)
            Me.txtDeviceSN.Focus()
        End Try
    End Sub

    Private Sub Transfer(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransfer.Click
        Dim strTransferDeviceIDs As String = ""
        Dim i As Integer
        Dim wott As PSS.Data.Buisness.WIPOwnershipTempTransfer
        Dim sf As New StackFrame(0)

        Try
            If Me.lstDeviceSN.Items.Count > 0 Then
                Busy(True)

                For i = 0 To Me.lstDeviceSN.Items.Count - 1
                    If strTransferDeviceIDs.Length > 0 Then
                        strTransferDeviceIDs &= ", "
                    End If

                    strTransferDeviceIDs &= Me.lstDeviceSN.Items(i)("Device ID")
                Next

                If strTransferDeviceIDs.Length > 0 Then
                    wott = New PSS.Data.Buisness.WIPOwnershipTempTransfer()

                    wott.TransferDevices(strTransferDeviceIDs)
                End If
            End If
        Catch ex As Exception
            PSS.Data.Production.Misc.DisplayMessage(sf.GetMethod, ex.Message)
        Finally
            Busy(False)
        End Try
    End Sub
End Class
