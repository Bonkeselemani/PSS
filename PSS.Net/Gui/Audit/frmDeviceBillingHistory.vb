Public Class frmDeviceBillingHistory
    Inherits System.Windows.Forms.Form

    Private objAudit As PSS.Data.Buisness.Audit

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        objAudit = New PSS.Data.Buisness.Audit()
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDevice As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents grdBillHistory As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents lblSN As System.Windows.Forms.Label
    Friend WithEvents cmdRmcvey As System.Windows.Forms.Button
    Friend WithEvents dgResolderParts As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmDeviceBillingHistory))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDevice = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgResolderParts = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.cmdRmcvey = New System.Windows.Forms.Button()
        Me.lblSN = New System.Windows.Forms.Label()
        Me.grdBillHistory = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Panel1.SuspendLayout()
        CType(Me.dgResolderParts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdBillHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(-2, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 16)
        Me.Label2.TabIndex = 77
        Me.Label2.Text = "Serial Number:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDevice
        '
        Me.txtDevice.Location = New System.Drawing.Point(121, 8)
        Me.txtDevice.Name = "txtDevice"
        Me.txtDevice.Size = New System.Drawing.Size(164, 20)
        Me.txtDevice.TabIndex = 1
        Me.txtDevice.Text = ""
        '
        'Panel1
        '
        Me.Panel1.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.dgResolderParts, Me.cmdRmcvey, Me.lblSN, Me.grdBillHistory, Me.Label2, Me.txtDevice})
        Me.Panel1.Location = New System.Drawing.Point(8, 8)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(880, 577)
        Me.Panel1.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(16, 400)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 16)
        Me.Label1.TabIndex = 81
        Me.Label1.Text = "Resolder Parts:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgResolderParts
        '
        Me.dgResolderParts.AllowUpdate = False
        Me.dgResolderParts.AllowUpdateOnBlur = False
        Me.dgResolderParts.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.dgResolderParts.GroupByCaption = "Drag a column header here to group by that column"
        Me.dgResolderParts.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.dgResolderParts.Location = New System.Drawing.Point(120, 400)
        Me.dgResolderParts.Name = "dgResolderParts"
        Me.dgResolderParts.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dgResolderParts.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dgResolderParts.PreviewInfo.ZoomFactor = 75
        Me.dgResolderParts.Size = New System.Drawing.Size(744, 160)
        Me.dgResolderParts.TabIndex = 80
        Me.dgResolderParts.Text = "C1TrueDBGrid1"
        Me.dgResolderParts.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:White;}Selected" & _
        "{ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactiv" & _
        "eCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cen" & _
        "ter;}Style1{}Normal{BackColor:LightSteelBlue;}HighlightRow{ForeColor:HighlightTe" & _
        "xt;BackColor:Highlight;}Style14{}OddRow{}RecordSelector{AlignImage:Center;}Style" & _
        "15{}Heading{Wrap:True;AlignHorz:Center;AlignVert:Center;Border:Raised,,1, 1, 1, " & _
        "1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{AlignHorz:Near;}Style" & _
        "11{}Style12{}Style13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.Merge" & _
        "View Name="""" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17""" & _
        " MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefRecSelWidth=""16"" Ve" & _
        "rticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>156</Height><CaptionStyl" & _
        "e parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><Eve" & _
        "nRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""" & _
        "Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group""" & _
        " me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle " & _
        "parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4""" & _
        " /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""Recor" & _
        "dSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style " & _
        "parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 740, 156</ClientRect><BorderSide" & _
        ">0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView>" & _
        "</Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""" & _
        "Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Cap" & _
        "tion"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selec" & _
        "ted"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""Highlight" & _
        "Row"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" " & _
        "/><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""Filte" & _
        "rBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSp" & _
        "lits><horzSplits>1</horzSplits><Layout>Modified</Layout><DefaultRecSelWidth>16</" & _
        "DefaultRecSelWidth><ClientArea>0, 0, 740, 156</ClientArea><PrintPageHeaderStyle " & _
        "parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
        '
        'cmdRmcvey
        '
        Me.cmdRmcvey.Location = New System.Drawing.Point(464, 8)
        Me.cmdRmcvey.Name = "cmdRmcvey"
        Me.cmdRmcvey.Size = New System.Drawing.Size(200, 24)
        Me.cmdRmcvey.TabIndex = 79
        Me.cmdRmcvey.Text = "Robert McVey"
        Me.cmdRmcvey.Visible = False
        '
        'lblSN
        '
        Me.lblSN.BackColor = System.Drawing.Color.Transparent
        Me.lblSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSN.ForeColor = System.Drawing.Color.Blue
        Me.lblSN.Location = New System.Drawing.Point(13, 32)
        Me.lblSN.Name = "lblSN"
        Me.lblSN.Size = New System.Drawing.Size(187, 16)
        Me.lblSN.TabIndex = 78
        Me.lblSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grdBillHistory
        '
        Me.grdBillHistory.AllowUpdate = False
        Me.grdBillHistory.AllowUpdateOnBlur = False
        Me.grdBillHistory.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdBillHistory.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdBillHistory.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
        Me.grdBillHistory.Location = New System.Drawing.Point(16, 48)
        Me.grdBillHistory.Name = "grdBillHistory"
        Me.grdBillHistory.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdBillHistory.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdBillHistory.PreviewInfo.ZoomFactor = 75
        Me.grdBillHistory.Size = New System.Drawing.Size(848, 344)
        Me.grdBillHistory.TabIndex = 0
        Me.grdBillHistory.Text = "C1TrueDBGrid1"
        Me.grdBillHistory.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:White;}Selected" & _
        "{ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactiv" & _
        "eCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cen" & _
        "ter;}Style9{}Normal{BackColor:LightSteelBlue;}HighlightRow{ForeColor:HighlightTe" & _
        "xt;BackColor:Highlight;}Style12{}OddRow{}RecordSelector{AlignImage:Center;}Style" & _
        "13{}Heading{Wrap:True;AlignHorz:Center;BackColor:Control;Border:Raised,,1, 1, 1," & _
        " 1;ForeColor:ControlText;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style" & _
        "11{}Style14{}Style15{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.Merge" & _
        "View Name="""" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17""" & _
        " MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefRecSelWidth=""16"" Ve" & _
        "rticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>340</Height><CaptionStyl" & _
        "e parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><Eve" & _
        "nRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""" & _
        "Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group""" & _
        " me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle " & _
        "parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4""" & _
        " /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""Recor" & _
        "dSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style " & _
        "parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 844, 340</ClientRect><BorderSide" & _
        ">0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView>" & _
        "</Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""" & _
        "Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Cap" & _
        "tion"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selec" & _
        "ted"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""Highlight" & _
        "Row"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" " & _
        "/><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""Filte" & _
        "rBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSp" & _
        "lits><horzSplits>1</horzSplits><Layout>Modified</Layout><DefaultRecSelWidth>16</" & _
        "DefaultRecSelWidth><ClientArea>0, 0, 844, 340</ClientArea><PrintPageHeaderStyle " & _
        "parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
        '
        'frmDeviceBillingHistory
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(896, 605)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel1})
        Me.Name = "frmDeviceBillingHistory"
        Me.Text = "Device' Billing History"
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgResolderParts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdBillHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub txtDevice_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDevice.KeyUp
        If e.KeyValue = 13 Then
            LoadBillHistory()
        End If
    End Sub

    Private Sub LoadBillHistory()
        Dim ds As New DataSet()
        Dim dt As DataTable
        Try
            If Trim(Me.txtDevice.Text) <> "" Then
                Me.lblSN.Text = Trim(Me.txtDevice.Text)
                ds = objAudit.GetDeviceBillingHistory(Trim(Me.txtDevice.Text))
                dt = ds.Tables("Replacement")

                With Me.grdBillHistory
                    .ClearFields()
                    .DataSource = dt.DefaultView
                    .Splits(0).DisplayColumns("Device ID").Visible = False
                End With

                dt = Nothing : dt = ds.Tables("Resolder")
                With Me.dgResolderParts
                    .ClearFields()
                    .DataSource = dt.DefaultView
                End With
            Else
                Me.lblSN.Text = ""
                Me.grdBillHistory.ClearFields()
            End If

        Catch ex As Exception
            MsgBox("Error in frmDeviceBillingHistory.LoadBillHistory:: " & ex.Message.ToString, MsgBoxStyle.Critical)
        Finally
            objAudit.DisposeDT(dt)
            If Not IsNothing(ds) Then
                ds.Dispose()
                ds = Nothing
            End If
            Me.txtDevice.Text = ""
            Me.txtDevice.Focus()
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        objAudit = Nothing
        MyBase.Finalize()
    End Sub

    



    Private Sub frmDeviceBillingHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtDevice.Focus()
    End Sub

    Private Sub cmdRmcvey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRmcvey.Click
        Dim i As Integer = 0
        'dt1 = objAudit.GetDeviceBillingHistory(Trim(Me.txtDevice.Text))
        i = objAudit.RobertMcVey()
    End Sub

    
End Class
