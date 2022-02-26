Public Class frmReceivingCELL
    Inherits System.Windows.Forms.Form


    Private currentSection As String = ""
    Private displayLEFT As Integer
    Private displayTOP As Integer
    Private displayWIDTH As Integer
    Private displayHEIGHT As Integer

    Private blnCustomerComplete As Boolean = False

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
    Friend WithEvents ucCustomer As PSS.uctlCustomer.ucCustomer
    Friend WithEvents tvMAIN As System.Windows.Forms.TreeView
    Friend WithEvents UcRMA As PSS.ucRMASpecific
    Friend WithEvents UcGrid As PSS.ucGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ucCustomer = New PSS.uctlCustomer.ucCustomer()
        Me.UcRMA = New PSS.ucRMASpecific()
        Me.tvMAIN = New System.Windows.Forms.TreeView()
        Me.UcGrid = New PSS.ucGrid()
        Me.SuspendLayout()
        '
        'ucCustomer
        '
        Me.ucCustomer.Location = New System.Drawing.Point(192, 600)
        Me.ucCustomer.Name = "ucCustomer"
        Me.ucCustomer.Size = New System.Drawing.Size(64, 24)
        Me.ucCustomer.TabIndex = 1
        Me.ucCustomer.Visible = False
        '
        'UcRMA
        '
        Me.UcRMA.Location = New System.Drawing.Point(304, 360)
        Me.UcRMA.Name = "UcRMA"
        Me.UcRMA.Size = New System.Drawing.Size(104, 40)
        Me.UcRMA.TabIndex = 2
        Me.UcRMA.Visible = False
        '
        'tvMAIN
        '
        Me.tvMAIN.Dock = System.Windows.Forms.DockStyle.Left
        Me.tvMAIN.ImageIndex = -1
        Me.tvMAIN.Name = "tvMAIN"
        Me.tvMAIN.SelectedImageIndex = -1
        Me.tvMAIN.Size = New System.Drawing.Size(200, 629)
        Me.tvMAIN.TabIndex = 3
        '
        'UcGrid
        '
        Me.UcGrid.Location = New System.Drawing.Point(408, 456)
        Me.UcGrid.Name = "UcGrid"
        Me.UcGrid.Size = New System.Drawing.Size(312, 104)
        Me.UcGrid.TabIndex = 4
        Me.UcGrid.Visible = False
        '
        'frmReceivingCELL
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(760, 629)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.UcGrid, Me.tvMAIN, Me.UcRMA, Me.ucCustomer})
        Me.Name = "frmReceivingCELL"
        Me.Text = "Receiving"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmReceivingCELL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        tvMAIN.Nodes.Add("CUSTOMER")
        tvMAIN.Nodes.Add("RMA")
        tvMAIN.Nodes.Add("DEVICE")
        tvMAIN.Nodes.Add("GRID")

        ucCustomer.populateCustomer()

    End Sub

    Private Sub assignDisplayValues()

        displayLEFT = tvMAIN.Width + 20
        displayTOP = 20

        displayWIDTH = Me.Width - tvMAIN.Width - 20
        displayHEIGHT = Me.Height - 40

    End Sub

    Private Sub hideUCs()

        ucCustomer.Visible = False
        UcRMA.Visible = False
        UcGrid.Visible = False

    End Sub

    Private Sub closeSection()

        If currentSection = "" Then
        ElseIf currentSection = "CUSTOMER" Then
            If ucCustomer.validateUCcustomer() = False Then
                'blnCustomerComplete = False
                'MsgBox("Please complete entering the customer information", MsgBoxStyle.OKOnly)
                Exit Sub
            Else
                blnCustomerComplete = True
                addTreeCustomerINFO()
                tvMAIN.Nodes(0).Expand()
                tvMAIN.Nodes(0).Nodes(1).Expand()
            End If
        ElseIf currentSection = "RMA" Then
        ElseIf currentSection = "GRID" Then
        End If

    End Sub

#Region "User Control Customer"

    Private Sub ucCustomer_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucCustomer.VisibleChanged

        Try
            If ucCustomer.Visible = False Then
                addTreeCustomerINFO()
                tvMAIN.Nodes(0).Expand()
                tvMAIN.Nodes(0).Nodes(1).Expand()
                tvMAIN.Focus()
                tvMAIN.SelectedNode = tvMAIN.Nodes(1)
            End If
        Catch ex As Exception
        End Try

    End Sub


    Private Sub addTreeRMAINFO()

        tvMAIN.Nodes(1).Nodes.Clear()
        tvMAIN.Nodes(1).Nodes.Add("Carrier: " & UcRMA.cboAirCarrCode.Text)
        tvMAIN.Nodes(1).Nodes.Add("Ship To: " & UcRMA.cboShipTo.Text)
        tvMAIN.Nodes(1).Nodes.Add("RMA: " & UcRMA.txtWorkOrder.Text)
        tvMAIN.Nodes(1).Nodes.Add("QTY: " & UcRMA.txtQuantity.Text)
        tvMAIN.Nodes(1).Nodes.Add("PRL: " & UcRMA.txtPRL.Text)
        tvMAIN.Nodes(1).Nodes.Add("IP: " & UcRMA.txtIP.Text)
        tvMAIN.Nodes(1).Nodes.Add("RA QTY: " & UcRMA.txtRAQty.Text)
        tvMAIN.Nodes(1).Nodes.Add("SKU: " & UcRMA.txtSKU.Text)
        tvMAIN.Nodes(1).Nodes.Add("WRTY: " & UcRMA.txtWrty.Text)
        tvMAIN.Nodes(1).Nodes.Add("SUG: " & UcRMA.txtSUG.Text)
        tvMAIN.Nodes(1).Nodes.Add("Manuf: " & UcRMA.cboManufID.Text)
        tvMAIN.Nodes(1).Nodes.Add("Model: " & UcRMA.cboModID.Text)
        tvMAIN.Nodes(1).Nodes.Add("MEMO: " & UcRMA.txtWorkOrderMemo.Text)

    End Sub

    Private Sub addTreeCustomerINFO()

        tvMAIN.Nodes(0).Nodes.Clear()
        tvMAIN.Nodes(0).Nodes.Add(ucCustomer.cboCustomer.Text)
        tvMAIN.Nodes(0).Nodes.Add(ucCustomer.txtLocation.Text)

        Dim xCount As Integer = 0
        Try
            For xCount = 0 To 4
                If Len(Trim(ucCustomer.arrLocDetail(xCount))) > 0 Then
                    tvMAIN.Nodes(0).Nodes(1).Nodes.Add(ucCustomer.arrLocDetail(xCount))
                End If
            Next
        Catch ex As Exception
        End Try

    End Sub


#End Region

#Region "Tree View Elements"

    Private Sub tvMAIN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tvMAIN.KeyUp
        If e.KeyCode = 13 Then
            displaySection()
        End If
    End Sub

    Private Sub tvMAIN_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tvMAIN.MouseUp
        displaySection()
    End Sub

    Private Sub displaySection()

        hideUCs()
        Dim aIndex As Integer
        Dim strStart As Integer
        Dim strValue As String

        If tvMAIN.SelectedNode.Text = "CUSTOMER" Then
            closeSection()
            currentSection = "CUSTOMER"
            assignDisplayValues()
            ucCustomer.Left = displayLEFT
            ucCustomer.Top = displayTOP
            ucCustomer.Visible = True
            ucCustomer.Width = displayWIDTH
            ucCustomer.Height = displayHEIGHT
            '//Reload dropdown elements if values exists
            Try
                If IsDBNull(tvMAIN.Nodes(0).Nodes(1).ToString) = False Then

                    With ucCustomer.cboLocation
                        For aIndex = 0 To .Items.Count - 1
                            If CType(.Items(aIndex)(1), String).Trim = tvMAIN.Nodes(0).Nodes(1).Text Then
                                .SelectedIndex = aIndex
                                Exit For
                            End If
                        Next

                        If aIndex >= .Items.Count Then .SelectedIndex = -1
                    End With
                End If
            Catch ex As Exception
            End Try
            ucCustomer.cboCustomer.Focus()
            System.Windows.Forms.Application.DoEvents()
        ElseIf tvMAIN.SelectedNode.Text = "RMA" Then

            'If blnCustomerComplete = False Then
            'MsgBox("Please define a customer before continuing.", MsgBoxStyle.Exclamation, "Define Customer")
            'tvMAIN.SelectedNode = tvMAIN.Nodes(0)
            'Exit Sub
            'End If

            closeSection()
            currentSection = "RMA"
            assignDisplayValues()
            UcRMA.Left = displayLEFT
            UcRMA.Top = displayTOP
            UcRMA.Visible = True
            UcRMA.Width = displayWIDTH
            UcRMA.Height = displayHEIGHT

            Try
                If IsDBNull(tvMAIN.Nodes(1).Nodes(11).Text) = False Then 'Model

                    strStart = InStr(tvMAIN.Nodes(1).Nodes(11).Text, ":")
                    If strStart > 0 Then
                        strValue = Trim(Mid$(tvMAIN.Nodes(1).Nodes(11).Text, strStart + 1, 50))
                    End If

                    With UcRMA.cboModID
                        For aIndex = 0 To .Items.Count - 1
                            If CType(.Items(aIndex)(1), String).Trim = strValue Then
                                .SelectedIndex = aIndex
                                Exit For
                            End If
                        Next

                        If aIndex >= .Items.Count Then .SelectedIndex = -1
                    End With
                End If
            Catch ex As Exception
            End Try


        ElseIf tvMAIN.SelectedNode.Text = "GRID" Then
            closeSection()
            currentSection = "GRID"
            assignDisplayValues()
            UcGrid.Left = displayLEFT
            UcGrid.Top = displayTOP
            UcGrid.Visible = True
            UcGrid.Width = displayWIDTH
            UcGrid.Height = displayHEIGHT
            UcGrid.txtDeviceSN.Focus()
        End If

    End Sub


#End Region

    Private Sub UcRMA_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcRMA.VisibleChanged

        Try
            If UcRMA.Visible = False Then
                addTreeRMAINFO()
                tvMAIN.Nodes(1).Expand()
                tvMAIN.Focus()
                tvMAIN.SelectedNode = tvMAIN.Nodes(3)
            End If
        Catch ex As Exception
        End Try

    End Sub
End Class
