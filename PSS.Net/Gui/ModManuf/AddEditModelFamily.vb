Imports PSS.Rules

Namespace Gui
    Public Class AddEditModelFamily
        Inherits System.Windows.Forms.Form
#Region " Windows Form Designer generated code "

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
        Friend WithEvents txtModelFamily As System.Windows.Forms.TextBox
        Friend WithEvents lblModelFamily As System.Windows.Forms.Label
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents cboCustomer As C1.Win.C1List.C1Combo
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents btnSave As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AddEditModelFamily))
            Me.txtModelFamily = New System.Windows.Forms.TextBox()
            Me.lblModelFamily = New System.Windows.Forms.Label()
            Me.btnSave = New System.Windows.Forms.Button()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.cboCustomer = New C1.Win.C1List.C1Combo()
            Me.Label8 = New System.Windows.Forms.Label()
            CType(Me.cboCustomer, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'txtModelFamily
            '
            Me.txtModelFamily.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtModelFamily.Location = New System.Drawing.Point(152, 24)
            Me.txtModelFamily.Name = "txtModelFamily"
            Me.txtModelFamily.Size = New System.Drawing.Size(288, 20)
            Me.txtModelFamily.TabIndex = 1
            Me.txtModelFamily.Text = ""
            '
            'lblModelFamily
            '
            Me.lblModelFamily.Location = New System.Drawing.Point(24, 24)
            Me.lblModelFamily.Name = "lblModelFamily"
            Me.lblModelFamily.Size = New System.Drawing.Size(120, 16)
            Me.lblModelFamily.TabIndex = 0
            Me.lblModelFamily.Text = "Model Family"
            '
            'btnSave
            '
            Me.btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSave.Location = New System.Drawing.Point(264, 96)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(80, 32)
            Me.btnSave.TabIndex = 4
            Me.btnSave.Text = "Save"
            '
            'btnCancel
            '
            Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCancel.Location = New System.Drawing.Point(360, 96)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(80, 32)
            Me.btnCancel.TabIndex = 5
            Me.btnCancel.Text = "Cancel"
            '
            'cboCustomer
            '
            Me.cboCustomer.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboCustomer.AutoCompletion = True
            Me.cboCustomer.AutoDropDown = True
            Me.cboCustomer.AutoSelect = True
            Me.cboCustomer.Caption = ""
            Me.cboCustomer.CaptionHeight = 17
            Me.cboCustomer.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboCustomer.ColumnCaptionHeight = 17
            Me.cboCustomer.ColumnFooterHeight = 17
            Me.cboCustomer.ColumnHeaders = False
            Me.cboCustomer.ContentHeight = 15
            Me.cboCustomer.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboCustomer.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboCustomer.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCustomer.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboCustomer.EditorHeight = 15
            Me.cboCustomer.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboCustomer.ItemHeight = 15
            Me.cboCustomer.Location = New System.Drawing.Point(152, 56)
            Me.cboCustomer.MatchEntryTimeout = CType(2000, Long)
            Me.cboCustomer.MaxDropDownItems = CType(20, Short)
            Me.cboCustomer.MaxLength = 32767
            Me.cboCustomer.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCustomer.Name = "cboCustomer"
            Me.cboCustomer.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCustomer.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCustomer.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCustomer.Size = New System.Drawing.Size(288, 21)
            Me.cboCustomer.TabIndex = 3
            Me.cboCustomer.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:HotTrack;}Style3{}Inactive{ForeColor:InactiveCaptionText;Bac" & _
            "kColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{F" & _
            "oreColor:HighlightText;BackColor:Highlight;}Style9{AlignHorz:Near;}OddRow{}Recor" & _
            "dSelector{AlignImage:Center;}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1" & _
            ", 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{}Style11{}Sty" & _
            "le1{}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" N" & _
            "ame=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=" & _
            """17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 15" & _
            "6</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HSc" & _
            "rollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style9" & _
            """ /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" me" & _
            "=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Head" & _
            "ing"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inact" & _
            "iveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style8" & _
            """ /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle p" & _
            "arent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1L" & _
            "ist.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style pare" & _
            "nt=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""" & _
            "Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""N" & _
            "ormal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=" & _
            """Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Head" & _
            "ing"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><v" & _
            "ertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth></Blob>"
            '
            'Label8
            '
            Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.Black
            Me.Label8.Location = New System.Drawing.Point(24, 56)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(88, 16)
            Me.Label8.TabIndex = 2
            Me.Label8.Text = "Customer:"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'AddEditModelFamily
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(466, 144)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboCustomer, Me.Label8, Me.btnCancel, Me.btnSave, Me.lblModelFamily, Me.txtModelFamily})
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "AddEditModelFamily"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Model Family"
            CType(Me.cboCustomer, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region
#Region "DECLARATIONS"

        Private _mfid As Integer
        Private _mf As PSS.Data.ModelFamily

#End Region
#Region "C0NSTRUCTORS"

        Public Sub New()
            MyBase.New()
            InitializeComponent()
        End Sub

#End Region
#Region "PROPERTIES"

        Public Property ModelFamilyID() As Integer
            Get
                Return _mfid
            End Get
            Set(ByVal Value As Integer)
                _mfid = Value
            End Set
        End Property

        Public ReadOnly Property IsValid() As Boolean
            Get
                Return (txtModelFamily.Text <> "" AndAlso cboCustomer.SelectedValue <> 0)
            End Get
        End Property

#End Region
#Region "FORM EVENTS"

        Private Sub AddEditModelFamily_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            LoadCustomers()
            If _mfid = 0 Then
                Me.Text = "Model Family (New)"
                _mf = New PSS.Data.ModelFamily()
            Else
                Me.Text = "Model Family (Update)"
                _mf = New PSS.Data.ModelFamily(_mfid)
                Me.cboCustomer.Enabled = False
                GetData(_mfid)
                PopulateForm()
            End If
        End Sub

#End Region
#Region "CONTROL EVENTS"

        Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
            Try
                If IsValid() Then
                    SaveRecord()
                    MessageBox.Show("The Model Family " & txtModelFamily.Text & " has been created/updated for the " & cboCustomer.Text & " customer.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                Else
                    Me.DialogResult = DialogResult.None
                    MessageBox.Show("You must enter a Model Family Name and select a Customer.", MessageBoxIcon.Exclamation)
                End If
            Catch ex As Exception
                Me.DialogResult = DialogResult.None
                MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End Sub
        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End Sub

#End Region
#Region "METHODS"

        Private Sub LoadCustomers()
            Dim dt As DataTable
            Try
                Me.cboCustomer.DataSource = Nothing
                dt = Data.Buisness.Generic.GetCustomers(True, , )
                Misc.PopulateC1DropDownList(Me.cboCustomer, dt, "Cust_Name1", "Cust_ID")
                Me.cboCustomer.SelectedValue = 0
            Catch ex As Exception
                Throw ex
            Finally
                Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        Private Sub SaveRecord()
            Try
                If Not IsValid Then Throw New Exception("No family name has been entered.")
                _mf.Name = txtModelFamily.Text
                _mf.CustomerID = cboCustomer.SelectedValue
                _mf.LastUpdateUserID = PSS.Core.ApplicationUser.IDuser
                _mf.ApplyChanges()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub GetData(ByVal id As Integer)
            _mf = New PSS.Data.ModelFamily(_mfid)
            Me.txtModelFamily.Text = _mf.Name
            Me.cboCustomer.SelectedValue = _mf.CustomerID
        End Sub

        Private Sub PopulateForm()
            Me.txtModelFamily.Text = _mf.Name
            Me.cboCustomer.SelectedValue = _mf.CustomerID
            Me.Refresh()
        End Sub

#End Region

        Private Sub txtModelFamily_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtModelFamily.TextChanged
            Misc.TextChange(Me.txtModelFamily, _mf, "Name")
        End Sub

    End Class
End Namespace
