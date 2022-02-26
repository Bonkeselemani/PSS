Imports eInfoDesigns.dbProvider.MySqlClient
Imports Microsoft.Data.Odbc

Imports PSS.Data
Imports PSS.Core
Imports PSS.Rules
Imports PSS.Core.Global
Imports System
Imports System.Data
Imports System.GC
Imports System.IO
Imports System.Data.OleDb


Public Class frmAdminSearch
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
    Friend WithEvents dlgFileName As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblFileName As System.Windows.Forms.Label
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
    Friend WithEvents grpListType As System.Windows.Forms.GroupBox
    Friend WithEvents rbCustomer As System.Windows.Forms.RadioButton
    Friend WithEvents rbLocation As System.Windows.Forms.RadioButton
    Friend WithEvents cklstSelection As System.Windows.Forms.CheckedListBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.dlgFileName = New System.Windows.Forms.OpenFileDialog()
        Me.lblFileName = New System.Windows.Forms.Label()
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.grpListType = New System.Windows.Forms.GroupBox()
        Me.rbLocation = New System.Windows.Forms.RadioButton()
        Me.rbCustomer = New System.Windows.Forms.RadioButton()
        Me.cklstSelection = New System.Windows.Forms.CheckedListBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.grpListType.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblFileName
        '
        Me.lblFileName.BackColor = System.Drawing.Color.SteelBlue
        Me.lblFileName.ForeColor = System.Drawing.Color.White
        Me.lblFileName.Location = New System.Drawing.Point(16, 8)
        Me.lblFileName.Name = "lblFileName"
        Me.lblFileName.Size = New System.Drawing.Size(184, 16)
        Me.lblFileName.TabIndex = 0
        Me.lblFileName.Text = "FILE SELECT"
        Me.lblFileName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(16, 24)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(184, 20)
        Me.txtFileName.TabIndex = 1
        Me.txtFileName.Text = ""
        '
        'grpListType
        '
        Me.grpListType.Controls.AddRange(New System.Windows.Forms.Control() {Me.rbLocation, Me.rbCustomer})
        Me.grpListType.Location = New System.Drawing.Point(16, 48)
        Me.grpListType.Name = "grpListType"
        Me.grpListType.Size = New System.Drawing.Size(184, 48)
        Me.grpListType.TabIndex = 3
        Me.grpListType.TabStop = False
        Me.grpListType.Text = "Select Source"
        '
        'rbLocation
        '
        Me.rbLocation.Location = New System.Drawing.Point(104, 24)
        Me.rbLocation.Name = "rbLocation"
        Me.rbLocation.Size = New System.Drawing.Size(72, 16)
        Me.rbLocation.TabIndex = 1
        Me.rbLocation.Text = "Location"
        '
        'rbCustomer
        '
        Me.rbCustomer.Location = New System.Drawing.Point(16, 24)
        Me.rbCustomer.Name = "rbCustomer"
        Me.rbCustomer.Size = New System.Drawing.Size(72, 16)
        Me.rbCustomer.TabIndex = 0
        Me.rbCustomer.Text = "Customer"
        '
        'cklstSelection
        '
        Me.cklstSelection.Location = New System.Drawing.Point(16, 96)
        Me.cklstSelection.Name = "cklstSelection"
        Me.cklstSelection.Size = New System.Drawing.Size(184, 319)
        Me.cklstSelection.TabIndex = 4
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(16, 432)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(184, 23)
        Me.btnSearch.TabIndex = 5
        Me.btnSearch.Text = "Execute"
        '
        'frmAdminSearch
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(224, 461)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnSearch, Me.cklstSelection, Me.grpListType, Me.txtFileName, Me.lblFileName})
        Me.Name = "frmAdminSearch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Administrative File Search"
        Me.grpListType.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim arrCustomer(10) As String
    Dim arrLocation(10) As String
    Dim dtCustomer, dtLocation As DataTable

    Private Function getFileName() As String

        '//Display Get File Dialog
        dlgFileName.ShowDialog()
        Return dlgFileName.FileName

    End Function

    Private Sub getCustomerArray()

        Dim strSQL As String = "Select * from tcustomer where cust_name2 is null order by cust_name1 asc"
        Dim ds As New PSS.Data.Production.Joins()
        dtCustomer = ds.OrderEntrySelect(strSQL)
        ReDim Preserve arrCustomer(dtCustomer.Rows.Count - 1)

    End Sub

    Private Sub loadCustomerArray()

        Dim xCount As Integer
        Dim r As DataRow

        For xCount = 0 To dtCustomer.Rows.Count - 1
            r = dtCustomer.Rows(xCount)
            'arrCustomer(xCount, 0) = r("Cust_ID")
            arrCustomer(xCount) = r("Cust_Name1")
        Next

    End Sub

    Private Sub clearCheckList()
        cklstSelection.Items.Clear()
    End Sub

    Private Sub loadCheckList()

        Dim xCount As Integer = 0

        If rbCustomer.Checked = True Then
            For xCount = 0 To UBound(arrCustomer)
                cklstSelection.Items.Add(arrCustomer(xCount))
            Next
        ElseIf rbLocation.Checked = True Then
            For xCount = 0 To UBound(arrLocation)
                cklstSelection.Items.Add(arrLocation(xCount))
            Next
        End If


    End Sub

    Private Sub getLocationArray()

        Dim strSQL As String = "Select * from tlocation where loc_name is not null order by loc_name asc"
        Dim ds As New PSS.Data.Production.Joins()
        dtLocation = ds.OrderEntrySelect(strSQL)
        ReDim Preserve arrLocation(dtLocation.Rows.Count - 1)

    End Sub

    Private Sub loadLocationArray()

        Dim xCount As Integer
        Dim r As DataRow

        For xCount = 0 To dtLocation.Rows.Count - 1
            r = dtLocation.Rows(xCount)
            'arrLocation(xCount, 0) = r("Loc_ID")
            arrLocation(xCount) = r("Loc_Name")
        Next

    End Sub

    Private Sub rbCustomer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbCustomer.CheckedChanged
        clearCheckList()
        loadCheckList()
    End Sub

    Private Sub rbLocation_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbLocation.CheckedChanged
        clearCheckList()
        loadCheckList()
    End Sub

    Private Sub frmAdminSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        getCustomerArray()
        loadCustomerArray()

        getLocationArray()
        loadLocationArray()

        rbCustomer.Checked = True

    End Sub

    Private Sub lblFileName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblFileName.Click
        txtFileName.Text = getFileName()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Dim sConnectionstring As String
        Dim objConn As New OleDbConnection()
        Dim objCmdSelect As New OleDbCommand()
        Dim objCmdSelect1 As New OleDbCommand()
        Dim objAdapter1 As New OleDbDataAdapter()
        Dim dt As New DataTable()
        Dim ds As New DataSet()
        Dim objDataset1 As New DataSet()
        Dim strFile As String
        Dim r, rDS As DataRow

        strFile = txtFileName.Text


        sConnectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strFile & ";Extended Properties=Excel 8.0;"
        objConn.ConnectionString = sConnectionstring
        objConn.Open()

        objCmdSelect.CommandText = ("SELECT * FROM [Sheet1$]")
        objCmdSelect.Connection = objConn
        objAdapter1.SelectCommand = objCmdSelect

        objAdapter1.Fill(dt)
        objAdapter1.Fill(objDataset1, "XLData")

        MsgBox(dt.Rows.Count)

        Dim sFile As PSS.Data.Production.Joins


        Dim strParam, strParamOut As String
        Dim dsParam As PSS.Data.Production.Joins
        Dim dtParam As DataTable
        Dim rParam As DataRow
        Dim vCount As Integer

        'If rbCustomer.Checked = True Then
        'For vCount = 0 To Me.cklstSelection.SelectedItems.Count - 1
        '    If vCount = 0 Then
        'strParam += "'" & cklstSelection.SelectedItems(vCount) & "'"
        '    Else
        '        strParam += ", '" & cklstSelection.SelectedItems(vCount) & "'"
        '    End If
        'Next
        'dtParam = dsParam.OrderEntrySelect("SELECT Cust_ID FROM tcustomer WHERE Cust_Name1 IN (" & strParam & ")")
        'For vCount = 0 To dtParam.Rows.Count - 1
        'rParam = dtParam.Rows(vCount)
        'If vCount = 0 Then
        'strParamOut += rParam("Cust_ID")
        'Else
        '    strParamOut += ", " & rParam("Cust_ID")
        'End If
        'Next

        'ElseIf rbLocation.Checked = True Then

        'For vCount = 0 To Me.cklstSelection.SelectedItems.Count - 1
        'If vCount = 0 Then
        '    strParam += "'" & cklstSelection.SelectedItems(vCount) & "'"
        'Else
        '    strParam += ", '" & cklstSelection.SelectedItems(vCount) & "'"
        'End If
        'Next
        'dtParam = dsParam.OrderEntrySelect("SELECT Loc_ID FROM tlocation WHERE Loc_Name IN (" & strParam & ")")
        'For vCount = 0 To dtParam.Rows.Count - 1
        'rParam = dtParam.Rows(vCount)
        'If vCount = 0 Then
        'strParamOut += rParam("Loc_ID")
        'Else
        '    strParamOut += ", " & rParam("Cust_ID")
        'End If
        'Next

        'End If

        Dim dtSource As DataTable = sFile.OrderEntrySelect("select device_sn, device_daterec, device_dateship, Ship_id, Tray_id from tdevice where loc_id in (78,15,19) order by device_sn, device_daterec desc")

        'Dim dtSource As DataTable

        'If rbCustomer.Checked = True Then
        'dtSource = sFile.OrderEntrySelect("select device_sn, device_daterec, device_dateship, Ship_id, Tray_id from tdevice inner join tlocation on tdevice.loc_id = tlocation.loc_id where tlocation.cust_id in (" & strParamOut & ") order by device_sn, device_daterec desc")
        'ElseIf rbLocation.Checked = True Then
        '    dtSource = sFile.OrderEntrySelect("select device_sn, device_daterec, device_dateship, Ship_id, Tray_id from tdevice where loc_id in (" & strParamOut & ") order by device_sn, device_daterec desc")
        'End If


        Dim xCount As Integer = 0
        Dim zCount As Integer = 0
        Dim strDevice As String

        Dim vDateRec As String
        Dim vDateShip As String
        Dim vShipID As String
        Dim vTrayID As String
        Dim vStatus As String
        Dim mIsAvailable As Boolean = False

        For xCount = 0 To dt.Rows.Count - 1
            r = dt.Rows(xCount)
            strDevice = r("Serial #")

            For zCount = 0 To dtSource.Rows.Count - 1
                '//Get the value from the database table
                rDS = dtSource.Rows(zCount)
                If Trim(rDS("Device_SN")) = Trim(strDevice) Then

                    mIsAvailable = True

                    If IsDBNull(rDS("Device_DateRec")) = False Then vDateRec = rDS("Device_DateRec")
                    If IsDBNull(rDS("Device_DateShip")) = False Then vDateShip = rDS("Device_DateShip")
                    If IsDBNull(rDS("Ship_ID")) = False Then vShipID = rDS("Ship_ID")
                    If IsDBNull(rDS("Tray_ID")) = False Then vTrayID = rDS("Tray_ID")

                    If IsDBNull(rDS("Device_DateShip")) = True Then vStatus = "Work In Progress"
                    If IsDBNull(rDS("Device_DateShip")) = False Then vStatus = "Closed"

                    Exit For

                End If

                If mIsAvailable = False Then vStatus = "Not Found"
            Next

            mIsAvailable = False

            '/Write data to table

            If Len(vDateRec) > 0 Then
                If vStatus = "Work In Progress" Then
                    objCmdSelect1.CommandText = ("UPDATE [Sheet1$] SET DateReceived  = '" & vDateRec & "' WHERE [Serial #] = '" & strDevice & "'")
                    objCmdSelect1.Connection = objConn
                    objCmdSelect1.ExecuteNonQuery()
                End If
            End If
            If Len(vDateShip) > 0 Then
                If vStatus = "Closed" Then
                    objCmdSelect1.CommandText = ("UPDATE [Sheet1$] SET DateShipped  = '" & vDateShip & "' WHERE [Serial #] = '" & strDevice & "'")
                    objCmdSelect1.Connection = objConn
                    objCmdSelect1.ExecuteNonQuery()
                End If
            End If

            If Len(vShipID) > 0 Then
                If vStatus = "Closed" Then
                    objCmdSelect1.CommandText = ("UPDATE [Sheet1$] SET [Manifest #]  = '" & vShipID & "' WHERE [Serial #] = '" & strDevice & "'")
                    objCmdSelect1.Connection = objConn
                    objCmdSelect1.ExecuteNonQuery()
                End If
            End If

            If Len(vTrayID) > 0 Then
                objCmdSelect1.CommandText = ("UPDATE [Sheet1$] SET TrayID  = '" & vTrayID & "' WHERE [Serial #] = '" & strDevice & "'")
                objCmdSelect1.Connection = objConn
                objCmdSelect1.ExecuteNonQuery()
            End If

            If Len(vStatus) > 0 Then
                objCmdSelect1.CommandText = ("UPDATE [Sheet1$] SET Status  = '" & vStatus & "' WHERE [Serial #] = '" & strDevice & "'")
                objCmdSelect1.Connection = objConn
                objCmdSelect1.ExecuteNonQuery()
            End If

            vDateRec = ""
            vDateShip = ""
            vShipID = ""
            vTrayID = ""
            vStatus = ""

        Next


        objConn.Close()

    End Sub




End Class
