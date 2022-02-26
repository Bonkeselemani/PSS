'Imports PSS.Core
'Imports PSS.Data

'Namespace Gui.Receiving

'    Public Class frmUSADataLoad
'        Inherits System.Windows.Forms.Form

'#Region " Windows Form Designer generated code "

'        Public Sub New()
'            MyBase.New()

'            'This call is required by the Windows Form Designer.
'            InitializeComponent()

'            'Add any initialization after the InitializeComponent() call

'        End Sub

'        'Form overrides dispose to clean up the component list.
'        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
'            If disposing Then
'                If Not (components Is Nothing) Then
'                    components.Dispose()
'                End If
'            End If
'            MyBase.Dispose(disposing)
'        End Sub

'        'Required by the Windows Form Designer
'        Private components As System.ComponentModel.IContainer

'        'NOTE: The following procedure is required by the Windows Form Designer
'        'It can be modified using the Windows Form Designer.  
'        'Do not modify it using the code editor.
'        Friend WithEvents lblDoc As System.Windows.Forms.Label
'        Friend WithEvents Label2 As System.Windows.Forms.Label
'        Friend WithEvents Label3 As System.Windows.Forms.Label
'        Friend WithEvents Label4 As System.Windows.Forms.Label
'        Friend WithEvents Label5 As System.Windows.Forms.Label
'        Friend WithEvents Label6 As System.Windows.Forms.Label
'        Friend WithEvents Label7 As System.Windows.Forms.Label
'        Friend WithEvents Label8 As System.Windows.Forms.Label
'        Friend WithEvents Label9 As System.Windows.Forms.Label
'        Friend WithEvents Label10 As System.Windows.Forms.Label
'        Friend WithEvents Label11 As System.Windows.Forms.Label
'        Friend WithEvents Label1 As System.Windows.Forms.Label
'        Friend WithEvents Label12 As System.Windows.Forms.Label
'        Friend WithEvents txtVendor As System.Windows.Forms.TextBox
'        Friend WithEvents txtReturnOfficeCode As System.Windows.Forms.TextBox
'        Friend WithEvents txtWorkorderNumber As System.Windows.Forms.TextBox
'        Friend WithEvents txtWorkorderQty As System.Windows.Forms.TextBox
'        Friend WithEvents txtCreationDate As System.Windows.Forms.TextBox
'        Friend WithEvents txtStartDate As System.Windows.Forms.TextBox
'        Friend WithEvents txtDueDate As System.Windows.Forms.TextBox
'        Friend WithEvents txtChannelCode As System.Windows.Forms.TextBox
'        Friend WithEvents txtFromLocation As System.Windows.Forms.TextBox
'        Friend WithEvents txtProcessedBy As System.Windows.Forms.TextBox
'        Friend WithEvents txtWorkorderSKU As System.Windows.Forms.TextBox
'        Friend WithEvents Label13 As System.Windows.Forms.Label
'        Friend WithEvents Label14 As System.Windows.Forms.Label
'        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
'            Me.lblDoc = New System.Windows.Forms.Label()
'            Me.Label2 = New System.Windows.Forms.Label()
'            Me.Label3 = New System.Windows.Forms.Label()
'            Me.Label4 = New System.Windows.Forms.Label()
'            Me.Label5 = New System.Windows.Forms.Label()
'            Me.Label6 = New System.Windows.Forms.Label()
'            Me.Label7 = New System.Windows.Forms.Label()
'            Me.Label8 = New System.Windows.Forms.Label()
'            Me.Label9 = New System.Windows.Forms.Label()
'            Me.Label10 = New System.Windows.Forms.Label()
'            Me.Label11 = New System.Windows.Forms.Label()
'            Me.Label1 = New System.Windows.Forms.Label()
'            Me.Label12 = New System.Windows.Forms.Label()
'            Me.txtVendor = New System.Windows.Forms.TextBox()
'            Me.txtReturnOfficeCode = New System.Windows.Forms.TextBox()
'            Me.txtWorkorderNumber = New System.Windows.Forms.TextBox()
'            Me.txtWorkorderQty = New System.Windows.Forms.TextBox()
'            Me.txtCreationDate = New System.Windows.Forms.TextBox()
'            Me.txtStartDate = New System.Windows.Forms.TextBox()
'            Me.txtDueDate = New System.Windows.Forms.TextBox()
'            Me.txtChannelCode = New System.Windows.Forms.TextBox()
'            Me.txtFromLocation = New System.Windows.Forms.TextBox()
'            Me.txtProcessedBy = New System.Windows.Forms.TextBox()
'            Me.txtWorkorderSKU = New System.Windows.Forms.TextBox()
'            Me.Label13 = New System.Windows.Forms.Label()
'            Me.Label14 = New System.Windows.Forms.Label()
'            Me.SuspendLayout()
'            '
'            'lblDoc
'            '
'            Me.lblDoc.BackColor = System.Drawing.Color.LightYellow
'            Me.lblDoc.Location = New System.Drawing.Point(8, 8)
'            Me.lblDoc.Name = "lblDoc"
'            Me.lblDoc.Size = New System.Drawing.Size(528, 16)
'            Me.lblDoc.TabIndex = 0
'            Me.lblDoc.Text = "DOC:"
'            '
'            'Label2
'            '
'            Me.Label2.Location = New System.Drawing.Point(8, 48)
'            Me.Label2.Name = "Label2"
'            Me.Label2.Size = New System.Drawing.Size(104, 13)
'            Me.Label2.TabIndex = 1
'            Me.Label2.Text = "Vendor:"
'            Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
'            '
'            'Label3
'            '
'            Me.Label3.Location = New System.Drawing.Point(8, 72)
'            Me.Label3.Name = "Label3"
'            Me.Label3.Size = New System.Drawing.Size(104, 13)
'            Me.Label3.TabIndex = 2
'            Me.Label3.Text = "Return Office Code:"
'            Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
'            '
'            'Label4
'            '
'            Me.Label4.Location = New System.Drawing.Point(8, 96)
'            Me.Label4.Name = "Label4"
'            Me.Label4.Size = New System.Drawing.Size(104, 13)
'            Me.Label4.TabIndex = 3
'            Me.Label4.Text = "Workorder #:"
'            Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
'            '
'            'Label5
'            '
'            Me.Label5.Location = New System.Drawing.Point(8, 120)
'            Me.Label5.Name = "Label5"
'            Me.Label5.Size = New System.Drawing.Size(104, 13)
'            Me.Label5.TabIndex = 4
'            Me.Label5.Text = "Workorder Qty:"
'            Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
'            '
'            'Label6
'            '
'            Me.Label6.Location = New System.Drawing.Point(8, 144)
'            Me.Label6.Name = "Label6"
'            Me.Label6.Size = New System.Drawing.Size(104, 13)
'            Me.Label6.TabIndex = 5
'            Me.Label6.Text = "Creation Date:"
'            Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
'            '
'            'Label7
'            '
'            Me.Label7.Location = New System.Drawing.Point(8, 168)
'            Me.Label7.Name = "Label7"
'            Me.Label7.Size = New System.Drawing.Size(104, 13)
'            Me.Label7.TabIndex = 6
'            Me.Label7.Text = "Start Date:"
'            Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
'            '
'            'Label8
'            '
'            Me.Label8.Location = New System.Drawing.Point(8, 192)
'            Me.Label8.Name = "Label8"
'            Me.Label8.Size = New System.Drawing.Size(104, 13)
'            Me.Label8.TabIndex = 7
'            Me.Label8.Text = "Due Date:"
'            Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
'            '
'            'Label9
'            '
'            Me.Label9.Location = New System.Drawing.Point(8, 216)
'            Me.Label9.Name = "Label9"
'            Me.Label9.Size = New System.Drawing.Size(104, 13)
'            Me.Label9.TabIndex = 8
'            Me.Label9.Text = "Workorder SKU:"
'            Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
'            '
'            'Label10
'            '
'            Me.Label10.Location = New System.Drawing.Point(8, 240)
'            Me.Label10.Name = "Label10"
'            Me.Label10.Size = New System.Drawing.Size(104, 13)
'            Me.Label10.TabIndex = 9
'            Me.Label10.Text = "Channel Code:"
'            Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopRight
'            '
'            'Label11
'            '
'            Me.Label11.Location = New System.Drawing.Point(8, 264)
'            Me.Label11.Name = "Label11"
'            Me.Label11.Size = New System.Drawing.Size(104, 13)
'            Me.Label11.TabIndex = 10
'            Me.Label11.Text = "From Location:"
'            Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopRight
'            '
'            'Label1
'            '
'            Me.Label1.Location = New System.Drawing.Point(8, 288)
'            Me.Label1.Name = "Label1"
'            Me.Label1.Size = New System.Drawing.Size(104, 13)
'            Me.Label1.TabIndex = 11
'            Me.Label1.Text = "Processed By:"
'            Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
'            '
'            'Label12
'            '
'            Me.Label12.BackColor = System.Drawing.Color.LightYellow
'            Me.Label12.Location = New System.Drawing.Point(8, 336)
'            Me.Label12.Name = "Label12"
'            Me.Label12.Size = New System.Drawing.Size(528, 16)
'            Me.Label12.TabIndex = 12
'            Me.Label12.Text = "Repair Vendor:"
'            '
'            'txtVendor
'            '
'            Me.txtVendor.Location = New System.Drawing.Point(120, 48)
'            Me.txtVendor.Name = "txtVendor"
'            Me.txtVendor.Size = New System.Drawing.Size(128, 20)
'            Me.txtVendor.TabIndex = 13
'            Me.txtVendor.Text = ""
'            '
'            'txtReturnOfficeCode
'            '
'            Me.txtReturnOfficeCode.Location = New System.Drawing.Point(120, 72)
'            Me.txtReturnOfficeCode.Name = "txtReturnOfficeCode"
'            Me.txtReturnOfficeCode.Size = New System.Drawing.Size(128, 20)
'            Me.txtReturnOfficeCode.TabIndex = 14
'            Me.txtReturnOfficeCode.Text = ""
'            '
'            'txtWorkorderNumber
'            '
'            Me.txtWorkorderNumber.Location = New System.Drawing.Point(120, 96)
'            Me.txtWorkorderNumber.Name = "txtWorkorderNumber"
'            Me.txtWorkorderNumber.Size = New System.Drawing.Size(128, 20)
'            Me.txtWorkorderNumber.TabIndex = 15
'            Me.txtWorkorderNumber.Text = ""
'            '
'            'txtWorkorderQty
'            '
'            Me.txtWorkorderQty.Location = New System.Drawing.Point(120, 120)
'            Me.txtWorkorderQty.Name = "txtWorkorderQty"
'            Me.txtWorkorderQty.Size = New System.Drawing.Size(128, 20)
'            Me.txtWorkorderQty.TabIndex = 16
'            Me.txtWorkorderQty.Text = ""
'            '
'            'txtCreationDate
'            '
'            Me.txtCreationDate.Location = New System.Drawing.Point(120, 144)
'            Me.txtCreationDate.Name = "txtCreationDate"
'            Me.txtCreationDate.Size = New System.Drawing.Size(128, 20)
'            Me.txtCreationDate.TabIndex = 17
'            Me.txtCreationDate.Text = ""
'            '
'            'txtStartDate
'            '
'            Me.txtStartDate.Location = New System.Drawing.Point(120, 168)
'            Me.txtStartDate.Name = "txtStartDate"
'            Me.txtStartDate.Size = New System.Drawing.Size(128, 20)
'            Me.txtStartDate.TabIndex = 18
'            Me.txtStartDate.Text = ""
'            '
'            'txtDueDate
'            '
'            Me.txtDueDate.Location = New System.Drawing.Point(120, 192)
'            Me.txtDueDate.Name = "txtDueDate"
'            Me.txtDueDate.Size = New System.Drawing.Size(128, 20)
'            Me.txtDueDate.TabIndex = 19
'            Me.txtDueDate.Text = ""
'            '
'            'txtChannelCode
'            '
'            Me.txtChannelCode.Location = New System.Drawing.Point(120, 240)
'            Me.txtChannelCode.Name = "txtChannelCode"
'            Me.txtChannelCode.Size = New System.Drawing.Size(128, 20)
'            Me.txtChannelCode.TabIndex = 21
'            Me.txtChannelCode.Text = ""
'            '
'            'txtFromLocation
'            '
'            Me.txtFromLocation.Location = New System.Drawing.Point(120, 264)
'            Me.txtFromLocation.Name = "txtFromLocation"
'            Me.txtFromLocation.Size = New System.Drawing.Size(128, 20)
'            Me.txtFromLocation.TabIndex = 22
'            Me.txtFromLocation.Text = ""
'            '
'            'txtProcessedBy
'            '
'            Me.txtProcessedBy.Location = New System.Drawing.Point(120, 288)
'            Me.txtProcessedBy.Name = "txtProcessedBy"
'            Me.txtProcessedBy.Size = New System.Drawing.Size(128, 20)
'            Me.txtProcessedBy.TabIndex = 23
'            Me.txtProcessedBy.Text = ""
'            '
'            'txtWorkorderSKU
'            '
'            Me.txtWorkorderSKU.Location = New System.Drawing.Point(120, 216)
'            Me.txtWorkorderSKU.Name = "txtWorkorderSKU"
'            Me.txtWorkorderSKU.Size = New System.Drawing.Size(128, 20)
'            Me.txtWorkorderSKU.TabIndex = 20
'            Me.txtWorkorderSKU.Text = ""
'            '
'            'Label13
'            '
'            Me.Label13.Location = New System.Drawing.Point(8, 360)
'            Me.Label13.Name = "Label13"
'            Me.Label13.Size = New System.Drawing.Size(104, 13)
'            Me.Label13.TabIndex = 24
'            Me.Label13.Text = "Ship To Office Code:"
'            Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopRight
'            '
'            'Label14
'            '
'            Me.Label14.Location = New System.Drawing.Point(8, 384)
'            Me.Label14.Name = "Label14"
'            Me.Label14.Size = New System.Drawing.Size(104, 13)
'            Me.Label14.TabIndex = 25
'            Me.Label14.Text = "Processed By:"
'            Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopRight
'            '
'            'frmUSADataLoad
'            '
'            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
'            Me.ClientSize = New System.Drawing.Size(552, 485)
'            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label14, Me.Label13, Me.txtProcessedBy, Me.txtFromLocation, Me.txtChannelCode, Me.txtWorkorderSKU, Me.txtDueDate, Me.txtStartDate, Me.txtCreationDate, Me.txtWorkorderQty, Me.txtWorkorderNumber, Me.txtReturnOfficeCode, Me.txtVendor, Me.Label12, Me.Label1, Me.Label11, Me.Label10, Me.Label9, Me.Label8, Me.Label7, Me.Label6, Me.Label5, Me.Label4, Me.Label3, Me.Label2, Me.lblDoc})
'            Me.Name = "frmUSADataLoad"
'            Me.Text = "frmUSADataLoad"
'            Me.ResumeLayout(False)

'        End Sub

'#End Region

'        Private Sub frmUSADataLoad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

'        End Sub

'    End Class
'End Namespace
