Public Class frmEmpIncentive
    Inherits System.Windows.Forms.Form
    Private GobjEmpIncentive As PSS.Data.Buisness.EmployeeIncentive

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        GobjEmpIncentive = New PSS.Data.Buisness.EmployeeIncentive()
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
    Friend WithEvents cmdLoadHours As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cmdLoadHours = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmdLoadHours
        '
        Me.cmdLoadHours.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdLoadHours.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLoadHours.ForeColor = System.Drawing.Color.Yellow
        Me.cmdLoadHours.Location = New System.Drawing.Point(28, 88)
        Me.cmdLoadHours.Name = "cmdLoadHours"
        Me.cmdLoadHours.Size = New System.Drawing.Size(592, 56)
        Me.cmdLoadHours.TabIndex = 0
        Me.cmdLoadHours.Text = "STEP 2:        Click this button and select the Excel file you just saved. This w" & _
        "ill load hours in to PSS Database"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.AddExtension = False
        Me.OpenFileDialog1.CheckFileExists = False
        Me.OpenFileDialog1.DefaultExt = "xls"
        Me.OpenFileDialog1.Filter = "Excel files (*.xls)|*.xls|CSV (Comma Delimited) *.CSV|*.csv"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Yellow
        Me.Label1.Location = New System.Drawing.Point(32, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(568, 40)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "STEP 1:       Save the TAB delimited Text file as an Excel file and rename the Ex" & _
        "cel sheet to ""hours""."
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(32, 178)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(512, 22)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Loading the same file multiple times does not create duplicate data."
        '
        'frmEmpIncentive
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(648, 222)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label2, Me.Label1, Me.cmdLoadHours})
        Me.Name = "frmEmpIncentive"
        Me.Text = "Cellular Incentive Program"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub cmdLoadHours_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoadHours.Click
        Dim i As Integer = 0
        Dim strFilePath As String = ""

        Try
            '****************************************************************
            'Get the file name and path
            '****************************************************************
            Me.OpenFileDialog1.DefaultExt = "xls"
            Me.OpenFileDialog1.FilterIndex = 1
            Me.OpenFileDialog1.FileName = "Hours Export.xls"
            Me.OpenFileDialog1.ShowDialog()
            If Len(Trim(Me.OpenFileDialog1.FileName)) > 0 Then
                If LCase(Microsoft.VisualBasic.Right(Trim(Me.OpenFileDialog1.FileName), 3)) <> "xls" Then
                    MessageBox.Show("Incorrect file extension. It must be ""XLS"".", "File Extension", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
                strFilePath = Trim(Me.OpenFileDialog1.FileName)
                '*****************************
                'Load File
                '*****************************
                i = GobjEmpIncentive.LoadEmployeeHours(strFilePath)

                If i > 0 Then
                    MessageBox.Show("This file has been loaded successfully in to PSS database.", "Load Hours Click", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                '*****************************
            Else
                MessageBox.Show("Please select a file.", "Select File", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            '****************************************************************

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Load Hours Clicked", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        GobjEmpIncentive = Nothing
        MyBase.Finalize()
    End Sub


End Class
