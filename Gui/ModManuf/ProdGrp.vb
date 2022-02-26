Imports PSS.Rules

Namespace Gui

    Public Class ProdGrp
        Inherits System.Windows.Forms.Form

        Private _prodGroup As Integer

#Region " Windows Form Designer generated code "
        Public Sub New(ByVal productGroup As Integer)
            MyBase.New()
            InitializeComponent()
            Me._prodGroup = productGroup
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
        Friend WithEvents Button1 As System.Windows.Forms.Button
        Friend WithEvents Button2 As System.Windows.Forms.Button
        Friend WithEvents cboProduct As PSS.Gui.Controls.ComboBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents lblShort As System.Windows.Forms.Label
        Friend WithEvents txtSDesc As System.Windows.Forms.TextBox
        Friend WithEvents txtLDesc As System.Windows.Forms.TextBox
        Friend WithEvents lblLong As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.lblShort = New System.Windows.Forms.Label()
            Me.txtSDesc = New System.Windows.Forms.TextBox()
            Me.Button1 = New System.Windows.Forms.Button()
            Me.Button2 = New System.Windows.Forms.Button()
            Me.cboProduct = New PSS.Gui.Controls.ComboBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.txtLDesc = New System.Windows.Forms.TextBox()
            Me.lblLong = New System.Windows.Forms.Label()
            Me.SuspendLayout()
            '
            'lblShort
            '
            Me.lblShort.Location = New System.Drawing.Point(8, 56)
            Me.lblShort.Name = "lblShort"
            Me.lblShort.Size = New System.Drawing.Size(112, 16)
            Me.lblShort.TabIndex = 0
            Me.lblShort.Text = "Short Description"
            '
            'txtSDesc
            '
            Me.txtSDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSDesc.Cursor = System.Windows.Forms.Cursors.IBeam
            Me.txtSDesc.Location = New System.Drawing.Point(8, 72)
            Me.txtSDesc.Name = "txtSDesc"
            Me.txtSDesc.Size = New System.Drawing.Size(248, 21)
            Me.txtSDesc.TabIndex = 1
            Me.txtSDesc.Text = ""
            '
            'Button1
            '
            Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.Button1.Location = New System.Drawing.Point(8, 152)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(120, 40)
            Me.Button1.TabIndex = 8
            Me.Button1.Text = "Add / Update"
            '
            'Button2
            '
            Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.Button2.Location = New System.Drawing.Point(136, 152)
            Me.Button2.Name = "Button2"
            Me.Button2.Size = New System.Drawing.Size(120, 40)
            Me.Button2.TabIndex = 9
            Me.Button2.Text = "Cancel"
            '
            'cboProduct
            '
            Me.cboProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboProduct.Location = New System.Drawing.Point(8, 24)
            Me.cboProduct.Name = "cboProduct"
            Me.cboProduct.Size = New System.Drawing.Size(248, 21)
            Me.cboProduct.TabIndex = 11
            '
            'Label4
            '
            Me.Label4.Location = New System.Drawing.Point(8, 8)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(120, 16)
            Me.Label4.TabIndex = 10
            Me.Label4.Text = "Product Type:"
            '
            'txtLDesc
            '
            Me.txtLDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtLDesc.Cursor = System.Windows.Forms.Cursors.IBeam
            Me.txtLDesc.Location = New System.Drawing.Point(8, 120)
            Me.txtLDesc.Name = "txtLDesc"
            Me.txtLDesc.Size = New System.Drawing.Size(248, 21)
            Me.txtLDesc.TabIndex = 13
            Me.txtLDesc.Text = ""
            '
            'lblLong
            '
            Me.lblLong.Location = New System.Drawing.Point(8, 104)
            Me.lblLong.Name = "lblLong"
            Me.lblLong.Size = New System.Drawing.Size(112, 16)
            Me.lblLong.TabIndex = 12
            Me.lblLong.Text = "Long Description:"
            '
            'ProdGrp
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
            Me.ClientSize = New System.Drawing.Size(266, 202)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtLDesc, Me.lblLong, Me.cboProduct, Me.Label4, Me.Button2, Me.Button1, Me.txtSDesc, Me.lblShort})
            Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
            Me.Name = "ProdGrp"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Product Group"
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub Model_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            PSS.Core.Highlight.SetHighLight(Me)
            PopulateProducts()
            If Me._prodGroup <> 0 Then
                Me.LoadFields()
            End If
        End Sub

        Private Sub LoadFields()
            Dim r As DataRow = ModManuf.GetProductGroup(Me._prodGroup)
            Me.txtSDesc.Text = r("ProdGrp_SDesc")
            Me.txtLDesc.Text = r("ProdGrp_LDesc")
            Dim i As PSS.Gui.Controls.ComboBoxItem
            For Each i In Me.cboProduct.Items
                If i.ID = r("Prod_ID") Then
                    Me.cboProduct.Text = i.ToString
                    Exit For
                End If
            Next
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

        Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
            Me.Close()
        End Sub

        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
            If Me._prodGroup = 0 Then
                ModManuf.InsertProductGroup(Trim(Me.txtSDesc.Text), Trim(Me.txtLDesc.Text), Me.cboProduct.GetID)
            Else
                ModManuf.UpdateProductGroup(Me._prodGroup, Trim(Me.txtSDesc.Text), Trim(Me.txtLDesc.Text), Me.cboProduct.GetID)
            End If
            Me.Close()
        End Sub
    End Class

End Namespace
