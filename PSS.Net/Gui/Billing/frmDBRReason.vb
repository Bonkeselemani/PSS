Namespace Gui.Billing
    Public Class frmDBRReason
        Inherits System.Windows.Forms.Form
        Private objMisc As PSS.Data.Buisness.Misc
        Private dtDBR As DataTable = Nothing
        Private R1 As DataRow = Nothing
        Private iPrevDcodeID As Integer = 0

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            objMisc = New PSS.Data.Buisness.Misc()
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
        Friend WithEvents btnOK As System.Windows.Forms.Button
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents cboDBRReasons As C1.Win.C1List.C1Combo
        Friend WithEvents btnCancelIt As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmDBRReason))
            Me.btnOK = New System.Windows.Forms.Button()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.cboDBRReasons = New C1.Win.C1List.C1Combo()
            Me.btnCancelIt = New System.Windows.Forms.Button()
            CType(Me.cboDBRReasons, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'btnOK
            '
            Me.btnOK.BackColor = System.Drawing.Color.Transparent
            Me.btnOK.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnOK.ForeColor = System.Drawing.Color.Black
            Me.btnOK.Location = New System.Drawing.Point(184, 96)
            Me.btnOK.Name = "btnOK"
            Me.btnOK.Size = New System.Drawing.Size(75, 40)
            Me.btnOK.TabIndex = 2
            Me.btnOK.Text = "OK"
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label2.Location = New System.Drawing.Point(19, 19)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(104, 11)
            Me.Label2.TabIndex = 10
            Me.Label2.Text = "DBR Reason:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboDBRReasons
            '
            Me.cboDBRReasons.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboDBRReasons.AutoCompletion = True
            Me.cboDBRReasons.AutoDropDown = True
            Me.cboDBRReasons.AutoSelect = True
            Me.cboDBRReasons.Caption = ""
            Me.cboDBRReasons.CaptionHeight = 17
            Me.cboDBRReasons.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboDBRReasons.ColumnCaptionHeight = 17
            Me.cboDBRReasons.ColumnFooterHeight = 17
            Me.cboDBRReasons.ColumnHeaders = False
            Me.cboDBRReasons.ContentHeight = 15
            Me.cboDBRReasons.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboDBRReasons.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboDBRReasons.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboDBRReasons.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboDBRReasons.EditorHeight = 15
            Me.cboDBRReasons.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboDBRReasons.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboDBRReasons.ItemHeight = 15
            Me.cboDBRReasons.Location = New System.Drawing.Point(32, 32)
            Me.cboDBRReasons.MatchEntryTimeout = CType(2000, Long)
            Me.cboDBRReasons.MaxDropDownItems = CType(10, Short)
            Me.cboDBRReasons.MaxLength = 32767
            Me.cboDBRReasons.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboDBRReasons.Name = "cboDBRReasons"
            Me.cboDBRReasons.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboDBRReasons.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboDBRReasons.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboDBRReasons.Size = New System.Drawing.Size(288, 21)
            Me.cboDBRReasons.TabIndex = 0
            Me.cboDBRReasons.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'btnCancelIt
            '
            Me.btnCancelIt.BackColor = System.Drawing.Color.Transparent
            Me.btnCancelIt.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCancelIt.ForeColor = System.Drawing.Color.Black
            Me.btnCancelIt.Location = New System.Drawing.Point(64, 96)
            Me.btnCancelIt.Name = "btnCancelIt"
            Me.btnCancelIt.Size = New System.Drawing.Size(75, 40)
            Me.btnCancelIt.TabIndex = 11
            Me.btnCancelIt.Text = "Cancel"
            '
            'frmDBRReason
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.Thistle
            Me.ClientSize = New System.Drawing.Size(350, 155)
            Me.ControlBox = False
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancelIt, Me.cboDBRReasons, Me.Label2, Me.btnOK})
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
            Me.Name = "frmDBRReason"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "DBR Reason"
            CType(Me.cboDBRReasons, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '*************************************************************************
        Private Shared iDBRCode As Integer = 0
        Public Shared Property DBRCode() As Integer
            Get
                Return iDBRCode
            End Get
            Set(ByVal Value As Integer)
                iDBRCode = Value
            End Set
        End Property
        '*************************************************************************
        Private Shared iCust_ID As Integer = 0
        Public Shared Property CustID() As Integer
            Get
                Return iCust_ID
            End Get
            Set(ByVal Value As Integer)
                iCust_ID = Value
            End Set
        End Property
        '*************************************************************************
        Private Shared iDevice_ID As Integer = 0
        Public Shared Property DeviceID() As Integer
            Get
                Return iDevice_ID
            End Get
            Set(ByVal Value As Integer)
                iDevice_ID = Value
            End Set
        End Property

        '*************************************************************************
        Private Shared strHeaderLabel As String = "DBR Reason"
        Public Shared Property HeaderLabel() As String
            Get
                Return strHeaderLabel
            End Get
            Set(ByVal Value As String)
                strHeaderLabel = Value
            End Set
        End Property

        '*************************************************************************
        Private Shared bIsDBR As Boolean = True
        Public Shared Property IsDBR() As Boolean
            Get
                Return bIsDBR
            End Get
            Set(ByVal Value As Boolean)
                bIsDBR = Value
            End Set
        End Property
        '*************************************************************************
        Private Shared bIsAMS As Boolean = False
        Public Shared Property IsAMS() As Boolean
            Get
                Return bIsAMS
            End Get
            Set(ByVal Value As Boolean)
                bIsAMS = Value
            End Set
        End Property

        '*************************************************************************
        Private Sub frmDBRReason_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Me.Label2.Text = Me.strHeaderLabel
            Me.Text = Me.strHeaderLabel

            GetPrevDBR()
            LoadDBRCodes()
            Me.cboDBRReasons.Focus() : Me.cboDBRReasons.SelectAll()
        End Sub
        '*************************************************************************
        Private Sub GetPrevDBR()
            iPrevDcodeID = 0
            iPrevDcodeID = objMisc.GetPrevDBR(Me.DeviceID)
        End Sub
        '*************************************************************************
        Private Sub LoadDBRCodes()
            Dim objDBRManifest As New PSS.Data.Buisness.DBRManifest()
            Try
                If Not Me.IsDBR Then 'NER
                    dtDBR = objDBRManifest.GetNERReasons(True, True, bIsAMS)
                Else 'DBR
                    dtDBR = objMisc.GetDBRCodes(bIsAMS)
                End If
                Misc.PopulateC1DropDownList(Me.cboDBRReasons, dtDBR, "DispalyDesc", "Dcode_ID")
                ' Me.cboDBRReasons.SelectedValue = 0   'Empty Row      0 is a Magoc number :)
                If dtDBR.Rows.Count >= 1 AndAlso dtDBR.Rows.Count <= 2 Then
                    Me.cboDBRReasons.SelectedValue = dtDBR.Rows(0).Item("Dcode_ID")
                ElseIf dtDBR.Rows.Count > 2 Then
                    Me.cboDBRReasons.SelectedValue = 0
                End If

            Catch ex As Exception
                objMisc.DisposeDT(dtDBR)
                MessageBox("Error in frmDBRReason.LoadDBRCodes:: " & ex.Message.ToString)
            Finally
                objDBRManifest = Nothing
            End Try
        End Sub
        '*************************************************************************
        Protected Overrides Sub Finalize()
            objMisc.DisposeDT(dtDBR)
            objMisc = Nothing
            MyBase.Finalize()
        End Sub
        '*************************************************************************
        Private Sub MessageBox(ByVal strMsg As String, _
                                Optional ByVal iLevel As Integer = 0, _
                                Optional ByVal strheading As String = "PSS.NET")
            Select Case iLevel
                Case 1      'Critical
                    MsgBox(strMsg, MsgBoxStyle.Critical, strheading)
                Case 2
                    'Add a different level here
                Case 3
                    'Add a different level here
                Case Else
                    MsgBox(strMsg, MsgBoxStyle.Information, strheading)
            End Select

        End Sub

        '*************************************************************************

        Private Sub KeyDownInControls(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboDBRReasons.KeyUp
            If e.KeyValue = 13 Then        'Enter Key
                SaveDBR()
                'ElseIf e.KeyValue = 49 Then
                '    Me.cboDBRReasons.SelectedValue = 1
                'ElseIf e.KeyValue = 50 Then
                '    Me.cboDBRReasons.SelectedValue = 2
                'ElseIf e.KeyValue = 51 Then
                '    Me.cboDBRReasons.Text = ""
                '    Me.cboDBRReasons.SelectedValue = 3
                '    Me.cboDBRReasons.Refresh()
                'ElseIf e.KeyValue = 52 Then
                '    Me.cboDBRReasons.SelectedValue = 4
                'ElseIf e.KeyValue = 53 Then
                '    Me.cboDBRReasons.SelectedValue = 5
                'ElseIf e.KeyValue = 54 Then
                '    Me.cboDBRReasons.SelectedValue = 6
                'ElseIf e.KeyValue = 55 Then
                '    Me.cboDBRReasons.SelectedValue = 7
                'ElseIf e.KeyValue = 56 Then
                '    Me.cboDBRReasons.SelectedValue = 8
            End If
        End Sub
        '*************************************************************************
        Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
            SaveDBR()
        End Sub
        '*************************************************************************
        Private Sub SaveDBR()
            If Me.cboDBRReasons.SelectedValue = 0 Then
                If Not Me.IsDBR Then 'NER
                    MessageBox("Please select a NER Reason.")
                Else
                    MessageBox("Please select a DBR Reason.")
                End If

                Exit Sub
            Else
                Me.DBRCode = Me.cboDBRReasons.SelectedValue
                Me.Close()
            End If
        End Sub
        '*************************************************************************
        Public Function DeleteDBRCode() As Integer
            Return objMisc.DeleteDBRCode(Me.DeviceID, Me.DBRCode)
        End Function
        '*************************************************************************
        Public Function UPD() As Integer
            Return objMisc.UPD(Me.DeviceID, Me.DBRCode)
        End Function
        '*************************************************************************
        Private Sub btnCancelIt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelIt.Click
            Me.DBRCode = -999999
            Me.Close()
        End Sub
        '*************************************************************************

    End Class
End Namespace