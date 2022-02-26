Imports PSS.Rules
Namespace Gui
    Public Class RptGrp
        Inherits System.Windows.Forms.Form

        Private _RptGroup As Integer
#Region " Windows Form Designer generated code "

        Public Sub New(ByVal iReportGroup As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._RptGroup = iReportGroup

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
        Friend WithEvents cboProduct As PSS.Gui.Controls.ComboBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents lblShort As System.Windows.Forms.Label
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents btnAddUpdate As System.Windows.Forms.Button
        Friend WithEvents txtDesc As System.Windows.Forms.TextBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.cboProduct = New PSS.Gui.Controls.ComboBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.btnAddUpdate = New System.Windows.Forms.Button()
            Me.txtDesc = New System.Windows.Forms.TextBox()
            Me.lblShort = New System.Windows.Forms.Label()
            Me.SuspendLayout()
            '
            'cboProduct
            '
            Me.cboProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboProduct.ItemHeight = 13
            Me.cboProduct.Location = New System.Drawing.Point(48, 31)
            Me.cboProduct.Name = "cboProduct"
            Me.cboProduct.Size = New System.Drawing.Size(248, 21)
            Me.cboProduct.TabIndex = 19
            '
            'Label4
            '
            Me.Label4.Location = New System.Drawing.Point(48, 15)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(120, 16)
            Me.Label4.TabIndex = 18
            Me.Label4.Text = "Product Type:"
            '
            'btnCancel
            '
            Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.btnCancel.Location = New System.Drawing.Point(208, 152)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(80, 40)
            Me.btnCancel.TabIndex = 17
            Me.btnCancel.Text = "Cancel"
            '
            'btnAddUpdate
            '
            Me.btnAddUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.btnAddUpdate.Location = New System.Drawing.Point(104, 152)
            Me.btnAddUpdate.Name = "btnAddUpdate"
            Me.btnAddUpdate.Size = New System.Drawing.Size(80, 40)
            Me.btnAddUpdate.TabIndex = 16
            Me.btnAddUpdate.Text = "Add / Update"
            '
            'txtDesc
            '
            Me.txtDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDesc.Cursor = System.Windows.Forms.Cursors.IBeam
            Me.txtDesc.Location = New System.Drawing.Point(48, 79)
            Me.txtDesc.Name = "txtDesc"
            Me.txtDesc.Size = New System.Drawing.Size(248, 21)
            Me.txtDesc.TabIndex = 15
            Me.txtDesc.Text = ""
            '
            'lblShort
            '
            Me.lblShort.Location = New System.Drawing.Point(48, 63)
            Me.lblShort.Name = "lblShort"
            Me.lblShort.Size = New System.Drawing.Size(112, 16)
            Me.lblShort.TabIndex = 14
            Me.lblShort.Text = "Description"
            '
            'RptGrp
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
            Me.ClientSize = New System.Drawing.Size(346, 208)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboProduct, Me.Label4, Me.btnCancel, Me.btnAddUpdate, Me.txtDesc, Me.lblShort})
            Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
            Me.Name = "RptGrp"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Report Group"
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private _rgid As Integer

        Public Property ReportGroupID() As Integer
            Get
                Return _rgid
            End Get
            Set(ByVal Value As Integer)
                _rgid = Value
            End Set
        End Property

        Private Sub RptGrp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            PSS.Core.Highlight.SetHighLight(Me)
            PopulateProducts()
            If Me._RptGroup <> 0 Then
                Me.LoadFields()
            End If
        End Sub

        Private Sub LoadFields()
            'Dim r As DataRow = ModManuf.GetProductGroup(Me._RptGroup)

            Dim r As DataRow
            Dim i As PSS.Gui.Controls.ComboBoxItem

            Try
                r = ModManuf.GetReportGroup(Me._RptGroup)
                Me.txtDesc.Text = r("RptGrp_Desc")

                'Populate the Product Type combo box here
                For Each i In Me.cboProduct.Items
                    If i.ID = r("Prod_ID") Then
                        Me.cboProduct.Text = i.ToString
                        Exit For
                    End If
                Next
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        End Sub

        Private Sub PopulateProducts()
            Dim dt As DataTable = ModManuf.GetProducts
            Dim r As DataRow
            For Each r In dt.Rows
                Me.cboProduct.AddItem(r(0), r(1))
            Next
            dt.Dispose()
            dt = Nothing
        End Sub

        'This click event fires up when Add/Update Report group button is clicked
        Private Sub btnAddUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddUpdate.Click
            Try
                If Me._RptGroup = 0 Then
                    ModManuf.InsertReportGroup(Trim(Me.txtDesc.Text), Me.cboProduct.GetID)
                Else
                    ModManuf.UpdateReportGroup(Me._RptGroup, Trim(Me.txtDesc.Text), Me.cboProduct.GetID)
                End If
                Me.DialogResult = DialogResult.OK
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
                Me.DialogResult = DialogResult.Cancel
            Finally
                Me.Close()
            End Try
        End Sub

        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End Sub
    End Class
End Namespace
