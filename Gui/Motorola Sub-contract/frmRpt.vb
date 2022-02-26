'Imports System.Drawing
'Imports System
'Imports System.Drawing.Printing

'Public Class frmRpt
'    Inherits System.Windows.Forms.Form
'    'Friend WithEvents pt As System.Windows.Forms.PrintDialog
'    'Friend WithEvents pd As System.Drawing.Printing.PrintDocument

'    '************************************************************
'    Private objMotoSubcontract_Biz As PSS.Data.Buisness.MotorolaSubcontract_Biz
'    Private iCust_ID As Integer
'    Private iSKU_ID As Integer
'    Private iWO_ID As Integer
'    '************************************************************
'    Public Property WO_ID()
'        Get
'            Return Me.iWO_ID
'        End Get
'        Set(ByVal Value)
'            Me.iWO_ID = Value
'        End Set
'    End Property
'    '************************************************************
'    Public Property SKU_ID()
'        Get
'            Return Me.iSKU_ID
'        End Get
'        Set(ByVal Value)
'            Me.iSKU_ID = Value
'        End Set
'    End Property
'    '************************************************************
'    Public Property Cust_ID()
'        Get
'            Return Me.iCust_ID
'        End Get
'        Set(ByVal Value)
'            Me.iCust_ID = Value
'        End Set
'    End Property
'    '************************************************************
'#Region " Windows Form Designer generated code "

'    Public Sub New(ByVal iCustID As Integer, _
'                    Optional ByVal iSKUID As Integer = 0, _
'                    Optional ByVal iWOID As Integer = 0)

'        MyBase.New()

'        'This call is required by the Windows Form Designer.
'        InitializeComponent()

'        'Add any initialization after the InitializeComponent() call
'        Me.iCust_ID = iCustID
'        Me.iSKU_ID = iSKUID
'        Me.iWO_ID = iWOID
'    End Sub

'    'Form overrides dispose to clean up the component list.
'    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
'        If disposing Then
'            If Not (components Is Nothing) Then
'                components.Dispose()
'            End If
'        End If
'        MyBase.Dispose(disposing)
'    End Sub

'    'Required by the Windows Form Designer
'    Private components As System.ComponentModel.IContainer

'    'NOTE: The following procedure is required by the Windows Form Designer
'    'It can be modified using the Windows Form Designer.  
'    'Do not modify it using the code editor.
'    Friend WithEvents lstDeviceSN As System.Windows.Forms.ListBox
'    Friend WithEvents txtDeviceSN As System.Windows.Forms.TextBox
'    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
'    Friend WithEvents mnuPrint As System.Windows.Forms.MenuItem
'    Friend WithEvents mnuExit As System.Windows.Forms.MenuItem
'    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
'        Me.lstDeviceSN = New System.Windows.Forms.ListBox()
'        Me.txtDeviceSN = New System.Windows.Forms.TextBox()
'        Me.MainMenu1 = New System.Windows.Forms.MainMenu()
'        Me.mnuPrint = New System.Windows.Forms.MenuItem()
'        Me.mnuExit = New System.Windows.Forms.MenuItem()
'        Me.SuspendLayout()
'        '
'        'lstDeviceSN
'        '
'        Me.lstDeviceSN.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.lstDeviceSN.ItemHeight = 14
'        Me.lstDeviceSN.Location = New System.Drawing.Point(30, 48)
'        Me.lstDeviceSN.Name = "lstDeviceSN"
'        Me.lstDeviceSN.Size = New System.Drawing.Size(138, 564)
'        Me.lstDeviceSN.Sorted = True
'        Me.lstDeviceSN.TabIndex = 0
'        '
'        'txtDeviceSN
'        '
'        Me.txtDeviceSN.Location = New System.Drawing.Point(30, 24)
'        Me.txtDeviceSN.Name = "txtDeviceSN"
'        Me.txtDeviceSN.Size = New System.Drawing.Size(138, 20)
'        Me.txtDeviceSN.TabIndex = 2
'        Me.txtDeviceSN.Text = ""
'        '
'        'MainMenu1
'        '
'        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuPrint, Me.mnuExit})
'        '
'        'mnuPrint
'        '
'        Me.mnuPrint.Index = 0
'        Me.mnuPrint.Shortcut = System.Windows.Forms.Shortcut.F12
'        Me.mnuPrint.Text = "Print"
'        '
'        'mnuExit
'        '
'        Me.mnuExit.Index = 1
'        Me.mnuExit.Text = "Exit"
'        '
'        'frmRpt
'        '
'        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
'        Me.BackColor = System.Drawing.Color.LightSkyBlue
'        Me.ClientSize = New System.Drawing.Size(198, 635)
'        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtDeviceSN, Me.lstDeviceSN})
'        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
'        Me.MaximizeBox = False
'        Me.Menu = Me.MainMenu1
'        Me.MinimizeBox = False
'        Me.Name = "frmRpt"
'        Me.ShowInTaskbar = False
'        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
'        Me.Text = "Serial Numbers"
'        Me.ResumeLayout(False)

'    End Sub

'#End Region


'    '************************************************************
'    Private Sub txtDeviceSN_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDeviceSN.TextChanged
'        Me.lstDeviceSN.SelectedIndex = Me.lstDeviceSN.FindString(Me.txtDeviceSN.Text)
'    End Sub
'    '************************************************************
'    Private Sub frmRpt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
'        Dim dt As DataTable
'        Dim R1 As DataRow

'        Try
'            objMotoSubcontract_Biz = New PSS.Data.Buisness.MotorolaSubcontract_Biz()
'            'dt = objMotoSubcontract_Biz.GetSeviceSNsToBeShippedForWO(Me.Cust_ID, Me.WO_ID)

'            If Me.SKU_ID <> 0 Then
'                dt = objMotoSubcontract_Biz.GetSNsForSKUBasedShipping(Me.SKU_ID)   'NSC
'            ElseIf Me.WO_ID <> 0 Then
'                dt = objMotoSubcontract_Biz.GetSNsForWOBasedShipping(Me.WO_ID)   'RL
'            End If

'            For Each R1 In dt.Rows
'                Me.lstDeviceSN.Items.Add(R1("Device_SN"))
'            Next

'        Catch ex As Exception
'            Throw ex
'        Finally
'            '**************************
'            'Destroy the datatable
'            '**************************
'            If Not IsNothing(dt) Then
'                If Not IsDBNull(dt) Then
'                    dt.Dispose()
'                End If
'                dt = Nothing
'            End If
'            '**************************
'            objMotoSubcontract_Biz = Nothing
'        End Try

'    End Sub
'    '************************************************************

'    Private Sub mnuPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrint.Click

'        Const strFilePath As String = "C:\DeviceSNsToBeShipped.txt"
'        Dim objPrint As New MyLib.Printing()
'        Dim str As String

'        Try
'            FileOpen(1, strFilePath, OpenMode.Append)

'            For Each str In lstDeviceSN.Items
'                PrintLine(1, str + Environment.NewLine)
'            Next

'            Reset()

'            objPrint.DoPrint(strFilePath)

'        Catch ex As Exception
'            MsgBox("frmRpt.mnuPrint_Click: " & ex.Message.ToString, MsgBoxStyle.Critical, "Motorola NSC Shipping")
'        Finally
'            Reset()
'            objPrint = Nothing
'            Kill(strFilePath)
'        End Try
'    End Sub

'    Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
'        Me.Close()
'    End Sub
'End Class
