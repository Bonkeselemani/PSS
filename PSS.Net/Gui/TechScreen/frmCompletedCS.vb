
Namespace Gui

    Public Class frmCompletedCS
        Inherits System.Windows.Forms.Form

        Private objdtSource As PSS.Data.Buisness.CellStarBER
        Private iManuf_id As Integer
        Private icsin_id As Integer
        Private iResult As Integer = 0


#Region " Windows Form Designer generated code "

        Public Sub New(ByVal iManufID As Integer, ByVal iCsinID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            objdtSource = New PSS.Data.Buisness.CellStarBER()
            iManuf_id = iManufID
            icsin_id = iCsinID

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
        Friend WithEvents lblCustomer1 As System.Windows.Forms.Label
        Friend WithEvents lblModel1 As System.Windows.Forms.Label
        Friend WithEvents cboProbFound As PSS.Gui.Controls.ComboBox
        Friend WithEvents cboRepAction As PSS.Gui.Controls.ComboBox
        Friend WithEvents cmdCancel As System.Windows.Forms.Button
        Friend WithEvents cmdCompleted As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.lblCustomer1 = New System.Windows.Forms.Label()
            Me.lblModel1 = New System.Windows.Forms.Label()
            Me.cboProbFound = New PSS.Gui.Controls.ComboBox()
            Me.cboRepAction = New PSS.Gui.Controls.ComboBox()
            Me.cmdCancel = New System.Windows.Forms.Button()
            Me.cmdCompleted = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            '
            'lblCustomer1
            '
            Me.lblCustomer1.BackColor = System.Drawing.Color.Transparent
            Me.lblCustomer1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCustomer1.ForeColor = System.Drawing.Color.White
            Me.lblCustomer1.Location = New System.Drawing.Point(16, 19)
            Me.lblCustomer1.Name = "lblCustomer1"
            Me.lblCustomer1.Size = New System.Drawing.Size(112, 16)
            Me.lblCustomer1.TabIndex = 24
            Me.lblCustomer1.Text = "Problem Found : "
            Me.lblCustomer1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblModel1
            '
            Me.lblModel1.BackColor = System.Drawing.Color.Transparent
            Me.lblModel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblModel1.ForeColor = System.Drawing.Color.White
            Me.lblModel1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblModel1.Location = New System.Drawing.Point(16, 48)
            Me.lblModel1.Name = "lblModel1"
            Me.lblModel1.Size = New System.Drawing.Size(112, 16)
            Me.lblModel1.TabIndex = 23
            Me.lblModel1.Text = "Repair Action : "
            Me.lblModel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboProbFound
            '
            Me.cboProbFound.AutoComplete = True
            Me.cboProbFound.BackColor = System.Drawing.SystemColors.Window
            Me.cboProbFound.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboProbFound.ForeColor = System.Drawing.Color.Black
            Me.cboProbFound.Location = New System.Drawing.Point(136, 16)
            Me.cboProbFound.Name = "cboProbFound"
            Me.cboProbFound.Size = New System.Drawing.Size(352, 24)
            Me.cboProbFound.TabIndex = 0
            '
            'cboRepAction
            '
            Me.cboRepAction.AutoComplete = True
            Me.cboRepAction.BackColor = System.Drawing.SystemColors.Window
            Me.cboRepAction.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboRepAction.ForeColor = System.Drawing.Color.Black
            Me.cboRepAction.Location = New System.Drawing.Point(136, 44)
            Me.cboRepAction.Name = "cboRepAction"
            Me.cboRepAction.Size = New System.Drawing.Size(352, 24)
            Me.cboRepAction.TabIndex = 1
            '
            'cmdCancel
            '
            Me.cmdCancel.BackColor = System.Drawing.Color.LightSteelBlue
            Me.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.cmdCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdCancel.ForeColor = System.Drawing.Color.Black
            Me.cmdCancel.Location = New System.Drawing.Point(144, 88)
            Me.cmdCancel.Name = "cmdCancel"
            Me.cmdCancel.Size = New System.Drawing.Size(96, 24)
            Me.cmdCancel.TabIndex = 2
            Me.cmdCancel.Text = "Cancel "
            Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'cmdCompleted
            '
            Me.cmdCompleted.BackColor = System.Drawing.Color.LightSteelBlue
            Me.cmdCompleted.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.cmdCompleted.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdCompleted.ForeColor = System.Drawing.Color.Black
            Me.cmdCompleted.Location = New System.Drawing.Point(312, 88)
            Me.cmdCompleted.Name = "cmdCompleted"
            Me.cmdCompleted.Size = New System.Drawing.Size(96, 24)
            Me.cmdCompleted.TabIndex = 3
            Me.cmdCompleted.Text = "Completed "
            Me.cmdCompleted.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'frmCompletedCS
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(536, 125)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdCompleted, Me.cmdCancel, Me.lblCustomer1, Me.lblModel1, Me.cboProbFound, Me.cboRepAction})
            Me.MaximizeBox = False
            Me.Name = "frmCompletedCS"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Completed Brightpoint device"
            Me.ResumeLayout(False)

        End Sub

#End Region

        Public Property Result() As String
            Get
                Return iResult
            End Get
            Set(ByVal Value As String)
                iResult = Value
            End Set
        End Property

        Protected Overrides Sub Finalize()
            objdtSource = Nothing
            objdtSource = Nothing
            MyBase.Finalize()
        End Sub
        Private Sub frmCompletedCS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Me.LoadProbFound()
            Me.LoadRepairAction()
        End Sub
        Private Sub LoadProbFound()
            Me.LoadCombox(9, Me.cboProbFound)
        End Sub
        Private Sub LoadRepairAction()
            Me.LoadCombox(3, Me.cboRepAction)
        End Sub

        Private Sub LoadCombox(ByVal mcode_id As Integer, ByRef ctrlCombox As Windows.Forms.ComboBox)
            Dim dt1 As DataTable
            Dim strSql As String = ""

            Try
                strSql = "select dcode_id, dcode_ldesc from lcodesdetail where mcode_id = " & mcode_id & " and dcode_inactive = 0 and manuf_id = " & iManuf_id & " order by Dcode_Ldesc;"
                dt1 = objdtSource.GetSelectedDt(strSql)

                dt1.LoadDataRow(New Object() {"0", "-- SELECT --"}, False)
                ctrlCombox.DataSource = dt1.DefaultView
                ctrlCombox.DisplayMember = Trim(dt1.Columns("dcode_ldesc").ToString)
                ctrlCombox.ValueMember = dt1.Columns("dcode_id").ToString

                ctrlCombox.SelectedValue = 0

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Load Combox", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Sub


        Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
            iResult = 0
            Me.Close()
        End Sub

        Private Sub cmdCompleted_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCompleted.Click
            Dim strSql As String = ""
            Dim i As Integer = 0

            '*********************************
            'validate user input
            If Me.cboProbFound.SelectedValue = 0 Then
                MessageBox.Show("Please select problem found.", "Update Data", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.cboProbFound.Focus()
                Exit Sub
            End If

            If Me.cboRepAction.SelectedValue = 0 Then
                MessageBox.Show("Please select repair action.", "Update Data", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.cboRepAction.Focus()
                Exit Sub
            End If
            If Me.iManuf_id = 0 Then
                MessageBox.Show("Manufacture was not defined.", "Update Data", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If Me.icsin_id = 0 Then
                MessageBox.Show("csin_ID was not defined.", "Update Data", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            '*********************************

            Try
                strSql = "UPDATE cstincomingdata SET csin_PF = " & Me.cboProbFound.SelectedValue & ", csin_RA = " & Me.cboRepAction.SelectedValue & " WHERE csin_id = " & icsin_id & ";"
                i = objdtSource.UpdtDelInsert(strSql)
                iResult = i
                Me.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Update Data", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try

        End Sub


    End Class
End Namespace