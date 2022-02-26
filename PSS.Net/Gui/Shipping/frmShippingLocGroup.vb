Imports PSS.Core
Imports PSS.Data

Imports Microsoft.Data.Odbc

Namespace Gui.Shipping

    Public Class frmShippingLocGroup
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
        Friend WithEvents lblCustomer As System.Windows.Forms.Label
        Friend WithEvents cboCustomer As System.Windows.Forms.ComboBox
        Friend WithEvents lblLocation As System.Windows.Forms.Label
        Friend WithEvents cboLocation As System.Windows.Forms.ComboBox
        Friend WithEvents lblLocationList As System.Windows.Forms.Label
        Friend WithEvents lblNotAvailable As System.Windows.Forms.Label
        Friend WithEvents lstLocation As System.Windows.Forms.ListBox
        Friend WithEvents lstNotAvailable As System.Windows.Forms.ListBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents lstSelected As System.Windows.Forms.ListBox
        Friend WithEvents btnSave As System.Windows.Forms.Button
        Friend WithEvents lblSelected As System.Windows.Forms.Label
        Friend WithEvents imgRightArrow As System.Windows.Forms.PictureBox
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents imgLeftArrow As System.Windows.Forms.PictureBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmShippingLocGroup))
            Me.lblCustomer = New System.Windows.Forms.Label()
            Me.cboCustomer = New System.Windows.Forms.ComboBox()
            Me.lblLocation = New System.Windows.Forms.Label()
            Me.cboLocation = New System.Windows.Forms.ComboBox()
            Me.lblLocationList = New System.Windows.Forms.Label()
            Me.lblNotAvailable = New System.Windows.Forms.Label()
            Me.lstLocation = New System.Windows.Forms.ListBox()
            Me.lstNotAvailable = New System.Windows.Forms.ListBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.lstSelected = New System.Windows.Forms.ListBox()
            Me.btnSave = New System.Windows.Forms.Button()
            Me.lblSelected = New System.Windows.Forms.Label()
            Me.imgRightArrow = New System.Windows.Forms.PictureBox()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.imgLeftArrow = New System.Windows.Forms.PictureBox()
            Me.SuspendLayout()
            '
            'lblCustomer
            '
            Me.lblCustomer.Location = New System.Drawing.Point(24, 26)
            Me.lblCustomer.Name = "lblCustomer"
            Me.lblCustomer.Size = New System.Drawing.Size(64, 16)
            Me.lblCustomer.TabIndex = 0
            Me.lblCustomer.Text = "Customer:"
            Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboCustomer
            '
            Me.cboCustomer.Location = New System.Drawing.Point(88, 24)
            Me.cboCustomer.Name = "cboCustomer"
            Me.cboCustomer.Size = New System.Drawing.Size(272, 21)
            Me.cboCustomer.TabIndex = 1
            '
            'lblLocation
            '
            Me.lblLocation.Location = New System.Drawing.Point(32, 56)
            Me.lblLocation.Name = "lblLocation"
            Me.lblLocation.Size = New System.Drawing.Size(56, 16)
            Me.lblLocation.TabIndex = 2
            Me.lblLocation.Text = "Location:"
            Me.lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboLocation
            '
            Me.cboLocation.Location = New System.Drawing.Point(88, 54)
            Me.cboLocation.Name = "cboLocation"
            Me.cboLocation.Size = New System.Drawing.Size(121, 21)
            Me.cboLocation.TabIndex = 3
            '
            'lblLocationList
            '
            Me.lblLocationList.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblLocationList.Location = New System.Drawing.Point(248, 96)
            Me.lblLocationList.Name = "lblLocationList"
            Me.lblLocationList.Size = New System.Drawing.Size(104, 16)
            Me.lblLocationList.TabIndex = 4
            Me.lblLocationList.Text = "Locations"
            Me.lblLocationList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblNotAvailable
            '
            Me.lblNotAvailable.BackColor = System.Drawing.Color.Red
            Me.lblNotAvailable.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblNotAvailable.ForeColor = System.Drawing.Color.White
            Me.lblNotAvailable.Location = New System.Drawing.Point(240, 248)
            Me.lblNotAvailable.Name = "lblNotAvailable"
            Me.lblNotAvailable.Size = New System.Drawing.Size(184, 16)
            Me.lblNotAvailable.TabIndex = 5
            Me.lblNotAvailable.Text = "Not Available"
            Me.lblNotAvailable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lstLocation
            '
            Me.lstLocation.Location = New System.Drawing.Point(240, 112)
            Me.lstLocation.Name = "lstLocation"
            Me.lstLocation.Size = New System.Drawing.Size(112, 134)
            Me.lstLocation.TabIndex = 6
            '
            'lstNotAvailable
            '
            Me.lstNotAvailable.Location = New System.Drawing.Point(240, 264)
            Me.lstNotAvailable.Name = "lstNotAvailable"
            Me.lstNotAvailable.Size = New System.Drawing.Size(184, 134)
            Me.lstNotAvailable.TabIndex = 7
            '
            'Label5
            '
            Me.Label5.Location = New System.Drawing.Point(216, 56)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(344, 16)
            Me.Label5.TabIndex = 8
            Me.Label5.Text = "(This location will accept devices from any location selected below.)"
            '
            'lstSelected
            '
            Me.lstSelected.Location = New System.Drawing.Point(432, 112)
            Me.lstSelected.Name = "lstSelected"
            Me.lstSelected.Size = New System.Drawing.Size(120, 225)
            Me.lstSelected.TabIndex = 9
            '
            'btnSave
            '
            Me.btnSave.Location = New System.Drawing.Point(432, 344)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(120, 23)
            Me.btnSave.TabIndex = 10
            Me.btnSave.Text = "&Save"
            '
            'lblSelected
            '
            Me.lblSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSelected.Location = New System.Drawing.Point(432, 96)
            Me.lblSelected.Name = "lblSelected"
            Me.lblSelected.Size = New System.Drawing.Size(112, 16)
            Me.lblSelected.TabIndex = 11
            Me.lblSelected.Text = "SELECTED"
            Me.lblSelected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'imgRightArrow
            '
            Me.imgRightArrow.Image = CType(resources.GetObject("imgRightArrow.Image"), System.Drawing.Bitmap)
            Me.imgRightArrow.Location = New System.Drawing.Point(368, 120)
            Me.imgRightArrow.Name = "imgRightArrow"
            Me.imgRightArrow.Size = New System.Drawing.Size(48, 48)
            Me.imgRightArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
            Me.imgRightArrow.TabIndex = 12
            Me.imgRightArrow.TabStop = False
            '
            'btnCancel
            '
            Me.btnCancel.Location = New System.Drawing.Point(432, 376)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(120, 23)
            Me.btnCancel.TabIndex = 13
            Me.btnCancel.Text = "&Cancel"
            '
            'imgLeftArrow
            '
            Me.imgLeftArrow.Image = CType(resources.GetObject("imgLeftArrow.Image"), System.Drawing.Bitmap)
            Me.imgLeftArrow.Location = New System.Drawing.Point(368, 184)
            Me.imgLeftArrow.Name = "imgLeftArrow"
            Me.imgLeftArrow.Size = New System.Drawing.Size(48, 48)
            Me.imgLeftArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
            Me.imgLeftArrow.TabIndex = 14
            Me.imgLeftArrow.TabStop = False
            '
            'frmShippingLocGroup
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(776, 493)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.imgLeftArrow, Me.btnCancel, Me.imgRightArrow, Me.lblSelected, Me.btnSave, Me.lstSelected, Me.Label5, Me.lstNotAvailable, Me.lstLocation, Me.lblNotAvailable, Me.lblLocationList, Me.cboLocation, Me.lblLocation, Me.cboCustomer, Me.lblCustomer})
            Me.Name = "frmShippingLocGroup"
            Me.Text = "frmShippingLocGroup"
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private dsCustomer As DataSet
        Private dtLocation As DataTable
        Private dtLoc2Loc As DataTable
        Private xCount As Integer
        Private r As DataRow
        Private intCustomer, intLoc2 As Int32

        Private Sub frmShippingLocGroup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            getDScustomer()
            LoadCustomerComboBox(dsCustomer)

        End Sub

        Private Sub getdtLoc2Loc()

            Dim newCount As Integer = 0
            Dim clsLoc2Loc As New PSS.Data.Production.Joins()
            Dim strSQL As String = "select tlocation.loc_name, tshipchange.loc_id_to from (tlocation INNER JOIN tshipchange ON tlocation.loc_id = tshipchange.Loc_ID) where tlocation.cust_ID=" & intCustomer & " ORDER BY tlocation.Loc_Name"
            dtLoc2Loc = clsLoc2Loc.OrderEntrySelect(strSQL)
            Dim xxLoc As String
            Dim r2 As DataRow


            For xCount = 0 To dtLoc2Loc.Rows.Count - 1
                r = dtLoc2Loc.Rows(xCount)
                'If Trim(r("Loc_ID_To")) = Trim(intLoc2) Then
                '//Populate the non available box

                For newCount = 0 To dtLocation.Rows.Count - 1
                    r2 = dtLocation.Rows(newCount)
                    If Trim(r2("Loc_ID")) = Trim(r("Loc_ID_To")) Then
                        xxLoc = Trim(r2("Loc_Name"))
                    End If
                Next

                Me.lstNotAvailable.Items.Add(r("Loc_Name") & " TO: " & xxLoc)

                If Trim(r("Loc_ID_To")) = Trim(intLoc2) Then
                    Me.lstSelected.Items.Add(r("Loc_Name"))
                End If

                'Remove from location list
                For newCount = 0 To lstLocation.Items.Count - 1
                    If Trim(lstLocation.Items(newCount)) = Trim(r("Loc_Name")) Then
                        lstLocation.Items.Remove(lstLocation.Items(newCount))
                        Exit For
                    End If
                Next

                'End If
            Next

        End Sub

        Private Sub getDScustomer()

            Dim clsCustomer As New PSS.Data.Production.tcustomer()
            dsCustomer = clsCustomer.GetDataOrdered

            clsCustomer = Nothing

        End Sub

        Private Sub getDSLocation(ByVal valCustomer As Integer)

            Dim clsLocation As New PSS.Data.Production.tlocation()
            dtLocation = clsLocation.GetRowsByCustomerID(valCustomer)

            clsLocation = Nothing

        End Sub

        Private Sub LoadCustomerComboBox(ByVal valDS As DataSet)

            For xCount = 0 To valDS.Tables("tcustomer").Rows.Count - 1
                r = valDS.Tables("tcustomer").Rows(xCount)
                cboCustomer.Items.Add(r("Cust_Name1"))
            Next

        End Sub

        Private Sub cboCustomer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomer.SelectedIndexChanged

            cboLocation.Items.Clear()

            '//Determine the customer number
            intCustomer = 0
            For xCount = 0 To dsCustomer.Tables("tcustomer").Rows.Count - 1
                r = dsCustomer.Tables("tcustomer").Rows(xCount)
                If Trim(r("Cust_Name1")) = Trim(cboCustomer.Text) Then
                    intCustomer = r("Cust_ID")
                    Exit For
                End If
            Next

            If intCustomer = 0 Then
                MsgBox("Error obtaining customer id", MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

            Me.LoadLocationComboBox(intCustomer)


        End Sub

        Private Sub LoadLocationComboBox(ByVal valCustomer As Integer)

            Me.getDSLocation(valCustomer)
            For xCount = 0 To Me.dtLocation.Rows.Count - 1
                r = dtLocation.Rows(xCount)

                If Trim(r("Loc_Name")) <> Trim(cboLocation.Text) Then
                    cboLocation.Items.Add(r("Loc_Name"))
                End If

            Next

        End Sub

        Private Sub cboLocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLocation.SelectedIndexChanged

            intLoc2 = 0

            Me.lstNotAvailable.Items.Clear()
            Me.lstLocation.Items.Clear()
            Me.lstSelected.Items.Clear()

            Me.getDSLocation(intCustomer)
            For xCount = 0 To Me.dtLocation.Rows.Count - 1
                r = dtLocation.Rows(xCount)

                If Trim(r("Loc_Name")) = Trim(cboLocation.Text) Then
                    intLoc2 = r("Loc_ID")
                    lstLocation.Items.Add(r("Loc_Name"))
                Else
                    lstLocation.Items.Add(r("Loc_Name"))
                End If
            Next

            getdtLoc2Loc()

        End Sub

        Private Sub Move2Select()

            '//Take the selected value and add it to the selected list.

            '//Place in order of location name
            Dim vPlaced As Boolean = False
            For xCount = 0 To lstSelected.Items.Count - 1
                If lstSelected.Items.Count = -1 Then
                    lstSelected.Items.Add(lstLocation.SelectedItem)
                    vPlaced = True
                ElseIf lstSelected.Items(xCount) > lstLocation.SelectedItem Then
                    lstSelected.Items.Insert(xCount, lstLocation.SelectedItem)
                    vPlaced = True
                    Exit For
                End If
            Next

            If vPlaced = False Then
                lstSelected.Items.Add(lstLocation.SelectedItem)
            End If


            '//Remove selected item from lstLocation
            lstLocation.Items.Remove(lstLocation.SelectedItem)

        End Sub

        Private Sub Move2Location()

            '//Take the selected value and add it to the location list.

            '//Place in order of location name
            Dim vPlaced As Boolean = False
            For xCount = 0 To lstLocation.Items.Count - 1
                If lstLocation.Items.Count = -1 Then
                    lstLocation.Items.Add(lstSelected.SelectedItem)
                    vPlaced = True
                ElseIf lstLocation.Items(xCount) > lstSelected.SelectedItem Then
                    lstLocation.Items.Insert(xCount, lstSelected.SelectedItem)
                    vPlaced = True
                    Exit For
                End If
            Next

            If vPlaced = False Then
                lstLocation.Items.Add(lstSelected.SelectedItem)
            End If

            '//Remove selected item from lstSelected
            lstSelected.Items.Remove(lstSelected.SelectedItem)

        End Sub

        Private Sub lstLocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstLocation.SelectedIndexChanged

            If Len(Trim((lstLocation.SelectedItem))) > 0 Then
                Move2Select()
            End If

        End Sub

        Private Sub lstLocation_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lstLocation.KeyUp



        End Sub

        Private Sub lstSelected_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstSelected.SelectedIndexChanged

            If Len(Trim((lstSelected.SelectedItem))) > 0 Then
                Move2Location()
            End If

        End Sub

        Private Sub cboCustomer_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustomer.Leave

            '//Determine the customer number
            intCustomer = 0
            For xCount = 0 To dsCustomer.Tables("tcustomer").Rows.Count - 1
                r = dsCustomer.Tables("tcustomer").Rows(xCount)
                If Trim(r("Cust_Name1")) = Trim(cboCustomer.Text) Then
                    intCustomer = r("Cust_ID")
                    Exit For
                End If
            Next

            If intCustomer = 0 Then
                MsgBox("Error obtaining customer id", MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

            Me.LoadLocationComboBox(intCustomer)

        End Sub

        Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

            '//Insert record into table tshipchange
            Dim valShipToLocation As Int32 = 0
            Dim arrSave(1000, 1) As Int32
            Dim stepCount As Integer = 0
            Dim stepLoc As String
            Dim stepInt As Int32
            Dim arrCount As Integer = 0

            For xCount = 0 To dtLocation.Rows.Count
                r = dtLocation.Rows(xCount)
                If Trim(r("Loc_Name")) = Trim(cboLocation.Text) Then
                    valShipToLocation = Trim(r("Loc_ID"))
                    Exit For
                End If
            Next

            If valShipToLocation = 0 Then
                '//Throw error and exit sub
                MsgBox("the ship to value can not be determined.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

            For stepCount = 0 To lstSelected.Items.Count - 1
                stepLoc = lstSelected.Items(stepCount)
                For xCount = 0 To dtLocation.Rows.Count - 1
                    r = dtLocation.Rows(xCount)
                    If Trim(r("Loc_Name")) = Trim(stepLoc) Then
                        '//Add values to array
                        arrSave(arrCount, 0) = Trim(r("Loc_ID"))
                        arrSave(arrCount, 1) = valShipToLocation
                        arrCount += 1
                        Exit For
                    End If
                Next
            Next

            Dim strSQL As String
            Dim clsRemove As New PSS.Data.Production.Joins()
            Dim blnRemove As Boolean

            '//Remove elements from table
            If valShipToLocation > 0 Then
                strSQL = "DELETE FROM tshipchange where Loc_ID_To = " & valShipToLocation
                blnRemove = clsRemove.OrderEntryUpdateDelete(strSQL)

                If blnRemove = False Then
                    'Throw error and exit sub
                End If
            End If

            '//Insert elements into table
            For xCount = 0 To arrCount - 1
                strSQL = "INSERT into tshipchange (Loc_ID, Loc_ID_To) VALUES (" & arrSave(xCount, 0) & ", " & arrSave(xCount, 1) & ")"
                blnRemove = clsRemove.OrderEntryUpdateDelete(strSQL)
            Next

            lstSelected.Items.Clear()
            lstNotAvailable.Items.Clear()
            getdtLoc2Loc()

            clsRemove = Nothing

        End Sub

        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

            Me.lstSelected.Items.Clear()
            Me.lstLocation.Items.Clear()
            Me.lstNotAvailable.Items.Clear()
            Me.cboLocation.Text = ""
            Me.cboLocation.Items.Clear()
            Me.cboCustomer.Text = ""
            Me.cboCustomer.Focus()

        End Sub
    End Class
End Namespace
