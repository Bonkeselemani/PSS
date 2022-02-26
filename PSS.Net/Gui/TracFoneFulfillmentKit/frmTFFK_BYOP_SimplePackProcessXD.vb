Option Explicit On 

Imports System
Imports PSS.Data.Buisness
Imports System.Text

Namespace Gui.TracFoneFulfillmentKit
    Public Class frmTFFK_BYOP_SimplePackProcessXD
        Inherits System.Windows.Forms.Form

        Private _strSelectedDate As String = ""
        Private _strDate As String = ""
        Private _bCancelled As Boolean = False

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strDate As String)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._strDate = strDate

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
        Friend WithEvents dtpExpirationDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblExpirationDate As System.Windows.Forms.Label
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents btnOK As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.dtpExpirationDate = New System.Windows.Forms.DateTimePicker()
            Me.lblExpirationDate = New System.Windows.Forms.Label()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.btnOK = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            '
            'dtpExpirationDate
            '
            Me.dtpExpirationDate.CustomFormat = "yyyy-MM-dd"
            Me.dtpExpirationDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpExpirationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpExpirationDate.Location = New System.Drawing.Point(168, 16)
            Me.dtpExpirationDate.Name = "dtpExpirationDate"
            Me.dtpExpirationDate.Size = New System.Drawing.Size(112, 21)
            Me.dtpExpirationDate.TabIndex = 1
            Me.dtpExpirationDate.Value = New Date(2007, 3, 16, 0, 0, 0, 0)
            '
            'lblExpirationDate
            '
            Me.lblExpirationDate.BackColor = System.Drawing.Color.Transparent
            Me.lblExpirationDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblExpirationDate.ForeColor = System.Drawing.Color.Black
            Me.lblExpirationDate.Location = New System.Drawing.Point(0, 16)
            Me.lblExpirationDate.Name = "lblExpirationDate"
            Me.lblExpirationDate.Size = New System.Drawing.Size(168, 16)
            Me.lblExpirationDate.TabIndex = 104
            Me.lblExpirationDate.Text = "Select Expiration Date:"
            Me.lblExpirationDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnCancel
            '
            Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCancel.Location = New System.Drawing.Point(48, 48)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(104, 40)
            Me.btnCancel.TabIndex = 105
            Me.btnCancel.Text = "Cancel"
            '
            'btnOK
            '
            Me.btnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnOK.Location = New System.Drawing.Point(168, 48)
            Me.btnOK.Name = "btnOK"
            Me.btnOK.Size = New System.Drawing.Size(112, 40)
            Me.btnOK.TabIndex = 106
            Me.btnOK.Text = "OK"
            '
            'frmTFFK_BYOP_SimplePackProcessXD
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.LightSteelBlue
            Me.ClientSize = New System.Drawing.Size(312, 110)
            Me.ControlBox = False
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnOK, Me.btnCancel, Me.lblExpirationDate, Me.dtpExpirationDate})
            Me.Name = "frmTFFK_BYOP_SimplePackProcessXD"
            Me.Text = "Select Date"
            Me.ResumeLayout(False)

        End Sub

#End Region
        Public ReadOnly Property SelectedDate() As String
            Get
                Return Me._strSelectedDate
            End Get
        End Property

        Public ReadOnly Property bIsCancelled() As Boolean
            Get
                Return Me._bCancelled
            End Get
        End Property

        Private Sub frmTFFK_BYOP_SimplePackProcessXD_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim strYYYY As String = ""
            Dim strMM As String = ""
            Dim strDD As String = ""
            Dim strDT As String = ""

            Try
                Me.CenterToScreen()
                PSS.Core.Highlight.SetHighLight(Me)

                If Me._strDate.Trim.Length >= 8 Then
                    strYYYY = Me._strDate.Trim.Substring(0, 4)
                    strMM = Me._strDate.Trim.Substring(4, 2)
                    strDD = Me._strDate.Trim.Substring(6, 2)
                    strDT = strMM & "/" & strDD & "/" & strYYYY
                    If IsDate(strDT) Then
                        Dim myDate As Date = strDT
                        Me.dtpExpirationDate.Value = myDate
                    Else
                        Me.dtpExpirationDate.Value = Now.Date
                    End If
                Else
                    Me.dtpExpirationDate.Value = Now.Date
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub frmTFFK_BYOP_SimplePackProcessXD_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Me._bCancelled = True
            Me.Close()
        End Sub

        Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
            Dim iRow As Integer = 0

            Try
                Me._strSelectedDate = Me.dtpExpirationDate.Value.ToString("yyyyMM-d")
                Me.Close()
            Catch ex As Exception
                Me._bCancelled = True
                MessageBox.Show(ex.ToString, "Sub btnOk_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

    End Class
End Namespace