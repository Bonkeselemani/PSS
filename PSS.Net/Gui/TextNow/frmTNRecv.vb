Option Explicit On 

Imports PSS.Data.Buisness
Imports System.Text

Public Class frmTNRecv
    Inherits System.Windows.Forms.Form

    Private _iMenuCustID As Integer = 0
    Private _iLocID As Integer = 0
    Private _objTN As TN
    Private _dtSNs As DataTable
    Private _bReceived As Boolean = False
    Private _bIsValid As Boolean = False

    Private _UserID As Integer = PSS.Core.Global.ApplicationUser.IDuser
    Private _strComputerName As String = ""


#Region " Windows Form Designer generated code "

    Public Sub New(ByVal dt As DataTable)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me._objTN = New TN()
        Me._iMenuCustID = Me._objTN.CUSTOMERID
        Me._iLocID = Me._objTN.LOCID
        Me._dtSNs = dt

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            Try
                Me._objTN = Nothing
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
    Friend WithEvents tdgSNs As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnValidate As System.Windows.Forms.Button
    Friend WithEvents btnReceive As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnCopySNs As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTNRecv))
        Me.tdgSNs = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btnValidate = New System.Windows.Forms.Button()
        Me.btnReceive = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnCopySNs = New System.Windows.Forms.Button()
        CType(Me.tdgSNs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tdgSNs
        '
        Me.tdgSNs.AllowColMove = False
        Me.tdgSNs.AllowColSelect = False
        Me.tdgSNs.AllowFilter = False
        Me.tdgSNs.AllowSort = False
        Me.tdgSNs.AllowUpdate = False
        Me.tdgSNs.AlternatingRows = True
        Me.tdgSNs.BackColor = System.Drawing.Color.AliceBlue
        Me.tdgSNs.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tdgSNs.Caption = "Generated SIM Card SNs  (0)"
        Me.tdgSNs.CaptionHeight = 17
        Me.tdgSNs.FetchRowStyles = True
        Me.tdgSNs.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Flat
        Me.tdgSNs.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tdgSNs.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdgSNs.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.tdgSNs.Location = New System.Drawing.Point(16, 16)
        Me.tdgSNs.Name = "tdgSNs"
        Me.tdgSNs.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdgSNs.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdgSNs.PreviewInfo.ZoomFactor = 75
        Me.tdgSNs.RowSubDividerColor = System.Drawing.Color.LightBlue
        Me.tdgSNs.Size = New System.Drawing.Size(288, 624)
        Me.tdgSNs.TabIndex = 177
        Me.tdgSNs.Text = "C1TrueDBGrid1"
        Me.tdgSNs.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Al" & _
        "iceBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive{" & _
        "ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Capt" & _
        "ion{Font:Arial, 9pt;AlignHorz:Center;ForeColor:Green;BackColor:LightSteelBlue;}S" & _
        "tyle1{}Normal{Font:Arial, 8.25pt;}HighlightRow{ForeColor:HighlightText;BackColor" & _
        ":Highlight;}Style14{}OddRow{}RecordSelector{AlignImage:Center;}Style15{}Heading{" & _
        "Wrap:True;BackColor:LightSteelBlue;Border:Flat,ControlDark,1, 1, 1, 1;ForeColor:" & _
        "ControlText;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}Style12{}" & _
        "Style13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowCol" & _
        "Move=""False"" AllowColSelect=""False"" Name="""" AlternatingRowStyle=""True"" CaptionHe" & _
        "ight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyles=""True""" & _
        " FilterBorderStyle=""Flat"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""1" & _
        "7"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height" & _
        ">607</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""E" & _
        "ditor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyl" & _
        "e parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><" & _
        "GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Styl" & _
        "e2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle pare" & _
        "nt=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSe" & _
        "lectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Select" & _
        "ed"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 17, 288, 6" & _
        "07</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.W" & _
        "in.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><" & _
        "Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Styl" & _
        "e parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style" & _
        " parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style par" & _
        "ent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style pa" & _
        "rent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style" & _
        " parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedSt" & _
        "yles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><D" & _
        "efaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 288, 624</ClientArea>" & _
        "<PrintPageHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" m" & _
        "e=""Style15"" /></Blob>"
        '
        'btnValidate
        '
        Me.btnValidate.BackColor = System.Drawing.Color.Cornsilk
        Me.btnValidate.ForeColor = System.Drawing.Color.DarkGreen
        Me.btnValidate.Location = New System.Drawing.Point(312, 88)
        Me.btnValidate.Name = "btnValidate"
        Me.btnValidate.Size = New System.Drawing.Size(112, 40)
        Me.btnValidate.TabIndex = 178
        Me.btnValidate.Text = "Validate SN"
        '
        'btnReceive
        '
        Me.btnReceive.BackColor = System.Drawing.Color.LimeGreen
        Me.btnReceive.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReceive.ForeColor = System.Drawing.Color.MediumBlue
        Me.btnReceive.Location = New System.Drawing.Point(312, 128)
        Me.btnReceive.Name = "btnReceive"
        Me.btnReceive.Size = New System.Drawing.Size(112, 48)
        Me.btnReceive.TabIndex = 179
        Me.btnReceive.Text = "Receive SNs"
        '
        'btnCancel
        '
        Me.btnCancel.ForeColor = System.Drawing.Color.Red
        Me.btnCancel.Location = New System.Drawing.Point(312, 0)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(112, 32)
        Me.btnCancel.TabIndex = 180
        Me.btnCancel.Text = "Cancel"
        '
        'btnCopySNs
        '
        Me.btnCopySNs.ForeColor = System.Drawing.Color.SlateBlue
        Me.btnCopySNs.Location = New System.Drawing.Point(312, 32)
        Me.btnCopySNs.Name = "btnCopySNs"
        Me.btnCopySNs.Size = New System.Drawing.Size(112, 40)
        Me.btnCopySNs.TabIndex = 181
        Me.btnCopySNs.Text = "Copy SNs to Clipboard"
        '
        'frmTNRecv
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(432, 654)
        Me.ControlBox = False
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCopySNs, Me.btnCancel, Me.btnReceive, Me.btnValidate, Me.tdgSNs})
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTNRecv"
        Me.Text = "SIM Card SNs"
        CType(Me.tdgSNs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Public ReadOnly Property HasReceived() As Boolean
        Get
            Return Me._bReceived
        End Get
    End Property

    Private Sub frmTNRecv_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
        Dim row As DataRow
        Dim iSN_Length As Integer = 0

        Try
            Me.CenterToScreen()

            Me.tdgSNs.DataSource = Nothing
            Me.tdgSNs.Visible = False
            If Not Me._dtSNs.Rows.Count > 0 Then Exit Sub

            With Me.tdgSNs
                .DataSource = Me._dtSNs.DefaultView
                For Each dbgc In .Splits(0).DisplayColumns
                    dbgc.Locked = True
                    dbgc.AutoSize()
                Next dbgc
                .Splits(0).DisplayColumns("IncrementalValue").Width = 0
                .Splits(0).DisplayColumns("SN_NoChkSum").Width = 0
                .Splits(0).DisplayColumns("ChkSum").Width = 0
                ' .Splits(0).DisplayColumns("Printer_Name").FetchStyle = True 'for fetchcellevent to fire
                .Splits(0).DisplayColumns("SN_Length").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("SN_Length").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            End With
            'RecID,IncrementalValue,SN_NoChkSum,ChkSum, SN, SN_Length
            Me.tdgSNs.Visible = True
            Me.tdgSNs.Caption = "Generated SIM Card SNs  (" & Me._dtSNs.Rows.Count & ")"

            If Me._dtSNs.Rows.Count > 0 Then iSN_Length = Me._dtSNs.Rows(0).Item("SN_Length")
            For Each row In Me._dtSNs.Rows
                If Not row("SN_Length") = iSN_Length Then
                    MessageBox.Show("Not the same length of SNs. Stop to receive it and see IT.", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit For
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Sub frmTNRecv_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me._bReceived = False
        Me.Close()
    End Sub

    Private Sub btnValidate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnValidate.Click
        Dim strInput As String = ""
        Dim row As DataRow
        Dim i As Integer = 0

        Try
            Me._bReceived = False : Me._bIsValid = False
            strInput = InputBox("Enter a SN (not starting SN or ending SN) to validate:", "SN").Trim
            If strInput = "" Then Throw New Exception("Please enter a valid SN.")

            'RecID,IncrementalValue,SN_NoChkSum,ChkSum, SN 
            'For Each row In Me._dtSNs.Rows
            '    i = +1
            '    If i = 1 AndAlso Trim(row("SN")).ToString.ToUpper = strInput.Trim.ToUpper Then
            '        Throw New Exception("This is the starting SN. Please enter a valid one.")
            '    ElseIf i >= Me._dtSNs.Rows.Count AndAlso Trim(row("SN")).ToString.ToUpper = strInput.Trim.ToUpper Then
            '        Throw New Exception("This is the ending SN. Please enter a valid one.")
            '    ElseIf Trim(row("SN")).ToString.ToUpper = strInput.Trim.ToUpper Then
            '        Me._bIsValid = True : Exit For
            '    End If
            'Next
            For Each row In Me._dtSNs.Rows
                If Trim(row("SN")).ToString.ToUpper = strInput.Trim.ToUpper Then
                    Me._bIsValid = True : Exit For
                End If
            Next

            If Me._bIsValid Then
                MessageBox.Show("Found this SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("Can't find this SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Sub btnValidate_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnReceive_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReceive.Click
        Dim iSku_ID As Integer = 16 'TRI-CUT SIM HOME
        Dim strSNs As String = ""
        Dim row As DataRow

        Try
            If Not Me._bIsValid Then
                MessageBox.Show("You can't receive. Please validate a SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.btnValidate.Focus() : Exit Sub
            End If

            Dim result As Integer = MessageBox.Show("Do you want to receive these " & Me._dtSNs.Rows.Count & " SNs?", "Selection", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                For Each row In Me._dtSNs.Rows
                    If strSNs.Trim.Length = 0 Then
                        strSNs = "'" & row("SN") & "'"
                    Else
                        strSNs &= ",'" & row("SN") & "'"
                    End If
                Next
                If Me._objTN.AreSNsAlreadyExit(strSNs, iSku_ID) Then
                    MessageBox.Show("Some or all SNs are in the system. Can't receive them. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    If Me._objTN.ReceiveSNsIntoSystem(Me._dtSNs, iSku_ID, Me._iMenuCustID, Me._iLocID, Me._UserID) Then
                        Me._bReceived = True
                    Else
                        Me._bReceived = False
                    End If

                    Me.Close()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Sub btnReceive_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

  
    Private Sub btnCopySNs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopySNs.Click
        Dim row As DataRow
        Dim strData As String = ""

        Try
            ' Misc.CopyAllData(Me.tdgSNs)

            For Each row In Me._dtSNs.Rows
                strData &= Convert.ToString(row("SN")) & Environment.NewLine
            Next
            'Copy Data to Clipboard
            System.Windows.Forms.Clipboard.SetDataObject(strData, False)
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Sub btnCopySNs_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
