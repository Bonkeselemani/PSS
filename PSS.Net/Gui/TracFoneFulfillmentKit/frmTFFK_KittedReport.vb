Option Explicit On 

Imports PSS.Data.Buisness
Imports System.Text

Namespace Gui.TracFoneFulfillmentKit
    Public Class frmTFFK_KittedReport
        Inherits System.Windows.Forms.Form

        Private _UserID As Integer = PSS.Core.Global.ApplicationUser.IDuser
        Private _strEmpID As String = PSS.Core.Global.ApplicationUser.NumberEmp
        Private _strUser As String = PSS.Core.Global.ApplicationUser.User

        Private _objTFFK_KittedRpt As PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK_KittedReport

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._objTFFK_KittedRpt = New PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK_KittedReport()

        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                Try
                    Me._objTFFK_KittedRpt = Nothing
                Catch ex As Exception
                End Try
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
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents cmbLn As System.Windows.Forms.ComboBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents txtBrCd As System.Windows.Forms.TextBox
        Friend WithEvents txtKID As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents txtQty As System.Windows.Forms.TextBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents txtItemCd As System.Windows.Forms.TextBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
        Friend WithEvents btnPrint As System.Windows.Forms.Button
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.cmbLn = New System.Windows.Forms.ComboBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.txtBrCd = New System.Windows.Forms.TextBox()
            Me.txtKID = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtQty = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.txtItemCd = New System.Windows.Forms.TextBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
            Me.btnPrint = New System.Windows.Forms.Button()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
            Me.GroupBox1.SuspendLayout()
            Me.SuspendLayout()
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.DateTimePicker1, Me.Label6, Me.txtQty, Me.Label4, Me.txtItemCd, Me.Label5, Me.txtKID, Me.Label3, Me.txtBrCd, Me.Label2, Me.cmbLn, Me.Label1})
            Me.GroupBox1.Location = New System.Drawing.Point(16, 16)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(528, 184)
            Me.GroupBox1.TabIndex = 0
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Print A4"
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.Location = New System.Drawing.Point(24, 32)
            Me.Label1.Name = "Label1"
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Kitting Line"
            '
            'cmbLn
            '
            Me.cmbLn.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9"})
            Me.cmbLn.Location = New System.Drawing.Point(128, 32)
            Me.cmbLn.Name = "cmbLn"
            Me.cmbLn.Size = New System.Drawing.Size(121, 21)
            Me.cmbLn.TabIndex = 1
            Me.cmbLn.Text = "ComboBox1"
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.Location = New System.Drawing.Point(24, 88)
            Me.Label2.Name = "Label2"
            Me.Label2.TabIndex = 2
            Me.Label2.Text = "BarCode"
            '
            'txtBrCd
            '
            Me.txtBrCd.Location = New System.Drawing.Point(128, 88)
            Me.txtBrCd.Name = "txtBrCd"
            Me.txtBrCd.Size = New System.Drawing.Size(120, 20)
            Me.txtBrCd.TabIndex = 3
            Me.txtBrCd.Text = ""
            '
            'txtKID
            '
            Me.txtKID.Location = New System.Drawing.Point(128, 144)
            Me.txtKID.Name = "txtKID"
            Me.txtKID.Size = New System.Drawing.Size(120, 20)
            Me.txtKID.TabIndex = 5
            Me.txtKID.Text = ""
            '
            'Label3
            '
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.Location = New System.Drawing.Point(24, 144)
            Me.Label3.Name = "Label3"
            Me.Label3.TabIndex = 4
            Me.Label3.Text = "Kit ID"
            '
            'txtQty
            '
            Me.txtQty.Location = New System.Drawing.Point(392, 144)
            Me.txtQty.Name = "txtQty"
            Me.txtQty.Size = New System.Drawing.Size(120, 20)
            Me.txtQty.TabIndex = 9
            Me.txtQty.Text = ""
            '
            'Label4
            '
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.Location = New System.Drawing.Point(288, 144)
            Me.Label4.Name = "Label4"
            Me.Label4.TabIndex = 8
            Me.Label4.Text = "Order Qty"
            '
            'txtItemCd
            '
            Me.txtItemCd.Location = New System.Drawing.Point(392, 88)
            Me.txtItemCd.Name = "txtItemCd"
            Me.txtItemCd.Size = New System.Drawing.Size(120, 20)
            Me.txtItemCd.TabIndex = 7
            Me.txtItemCd.Text = ""
            '
            'Label5
            '
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.Location = New System.Drawing.Point(288, 88)
            Me.Label5.Name = "Label5"
            Me.Label5.TabIndex = 6
            Me.Label5.Text = "Item Code"
            '
            'Label6
            '
            Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.Location = New System.Drawing.Point(288, 32)
            Me.Label6.Name = "Label6"
            Me.Label6.TabIndex = 10
            Me.Label6.Text = "Kit Date"
            '
            'DateTimePicker1
            '
            Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.DateTimePicker1.Location = New System.Drawing.Point(392, 32)
            Me.DateTimePicker1.Name = "DateTimePicker1"
            Me.DateTimePicker1.Size = New System.Drawing.Size(120, 20)
            Me.DateTimePicker1.TabIndex = 11
            '
            'btnPrint
            '
            Me.btnPrint.Location = New System.Drawing.Point(424, 216)
            Me.btnPrint.Name = "btnPrint"
            Me.btnPrint.Size = New System.Drawing.Size(72, 40)
            Me.btnPrint.TabIndex = 12
            Me.btnPrint.Text = "Print"
            '
            'btnClear
            '
            Me.btnClear.Location = New System.Drawing.Point(152, 216)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(72, 40)
            Me.btnClear.TabIndex = 13
            Me.btnClear.Text = "Clear"
            '
            'CrystalReportViewer1
            '
            Me.CrystalReportViewer1.ActiveViewIndex = -1
            Me.CrystalReportViewer1.Location = New System.Drawing.Point(16, 272)
            Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
            Me.CrystalReportViewer1.ReportSource = Nothing
            Me.CrystalReportViewer1.Size = New System.Drawing.Size(528, 256)
            Me.CrystalReportViewer1.TabIndex = 14
            '
            'frmTFFK_KittedReport
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(560, 534)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.CrystalReportViewer1, Me.GroupBox1, Me.btnPrint, Me.btnClear})
            Me.Name = "frmTFFK_KittedReport"
            Me.Text = "frmTFFK_KittedReport"
            Me.GroupBox1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click



        End Sub

        Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
            txtBrCd.Text = String.Empty
            txtItemCd.Text = String.Empty
            txtKID.Text = String.Empty
            txtQty.Text = String.Empty
        End Sub
    End Class
End Namespace

