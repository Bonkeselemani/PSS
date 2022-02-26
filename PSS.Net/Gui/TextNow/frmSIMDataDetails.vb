Imports System.IO

Public Class frmSIMDataDetails
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
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents lblScreenDesc As System.Windows.Forms.Label
	Friend WithEvents lblRowCount As System.Windows.Forms.Label
    Friend WithEvents tdgInventoryDetails As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents lblCardCount As System.Windows.Forms.Label

	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSIMDataDetails))
        Me.btnExport = New System.Windows.Forms.Button()
        Me.lblScreenDesc = New System.Windows.Forms.Label()
        Me.lblRowCount = New System.Windows.Forms.Label()
        Me.tdgInventoryDetails = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.lblCardCount = New System.Windows.Forms.Label()
        CType(Me.tdgInventoryDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(560, 400)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(114, 23)
        Me.btnExport.TabIndex = 2
        Me.btnExport.Text = "Export to Excel"
        '
        'lblScreenDesc
        '
        Me.lblScreenDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScreenDesc.Location = New System.Drawing.Point(8, 400)
        Me.lblScreenDesc.Name = "lblScreenDesc"
        Me.lblScreenDesc.Size = New System.Drawing.Size(208, 24)
        Me.lblScreenDesc.TabIndex = 31
        Me.lblScreenDesc.Text = "This screen displays detailed information from other screens."
        Me.lblScreenDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRowCount
        '
        Me.lblRowCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRowCount.ForeColor = System.Drawing.Color.Blue
        Me.lblRowCount.Location = New System.Drawing.Point(216, 400)
        Me.lblRowCount.Name = "lblRowCount"
        Me.lblRowCount.Size = New System.Drawing.Size(152, 23)
        Me.lblRowCount.TabIndex = 32
        Me.lblRowCount.Text = "Record Count: "
        Me.lblRowCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tdgInventoryDetails
        '
        Me.tdgInventoryDetails.AllowArrows = False
        Me.tdgInventoryDetails.AllowColMove = False
        Me.tdgInventoryDetails.AllowColSelect = False
        Me.tdgInventoryDetails.AllowUpdate = False
        Me.tdgInventoryDetails.AlternatingRows = True
        Me.tdgInventoryDetails.BackColor = System.Drawing.Color.White
        Me.tdgInventoryDetails.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tdgInventoryDetails.Caption = "SIM Card Inventory Details"
        Me.tdgInventoryDetails.FetchRowStyles = True
        Me.tdgInventoryDetails.FilterBar = True
        Me.tdgInventoryDetails.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Flat
        Me.tdgInventoryDetails.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tdgInventoryDetails.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdgInventoryDetails.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.tdgInventoryDetails.Name = "tdgInventoryDetails"
        Me.tdgInventoryDetails.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdgInventoryDetails.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdgInventoryDetails.PreviewInfo.ZoomFactor = 75
        Me.tdgInventoryDetails.RowSubDividerColor = System.Drawing.Color.LightBlue
        Me.tdgInventoryDetails.Size = New System.Drawing.Size(680, 392)
        Me.tdgInventoryDetails.TabIndex = 179
        Me.tdgInventoryDetails.Text = "C1TrueDBGrid1"
        Me.tdgInventoryDetails.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Al" & _
        "iceBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive{" & _
        "ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{Font:" & _
        "Arial, 8.25pt, style=Bold;}Caption{Font:Arial, 8.25pt, style=Bold;AlignHorz:Cent" & _
        "er;ForeColor:White;BackColor:DarkGreen;}Style1{}Normal{Font:Arial, 8.25pt;}Highl" & _
        "ightRow{ForeColor:HighlightText;BackColor:Highlight;}Style14{}OddRow{}RecordSele" & _
        "ctor{AlignImage:Center;}Style15{}Heading{Wrap:True;BackColor:LightSteelBlue;Bord" & _
        "er:Flat,ControlDark,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}S" & _
        "tyle10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style9{}</Data></Styles><Split" & _
        "s><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""False"" Nam" & _
        "e="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" Colu" & _
        "mnFooterHeight=""17"" FetchRowStyles=""True"" FilterBar=""True"" FilterBorderStyle=""Fl" & _
        "at"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17""" & _
        " VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>375</Height><CaptionS" & _
        "tyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><" & _
        "EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" m" & _
        "e=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Gro" & _
        "up"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowSty" & _
        "le parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Styl" & _
        "e4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""Re" & _
        "cordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Sty" & _
        "le parent=""Normal"" me=""Style1"" /><ClientRect>0, 17, 680, 375</ClientRect><Border" & _
        "Side>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeV" & _
        "iew></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" " & _
        "me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=" & _
        """Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""S" & _
        "elected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""Highl" & _
        "ightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddR" & _
        "ow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""F" & _
        "ilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</ve" & _
        "rtSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</" & _
        "DefaultRecSelWidth><ClientArea>0, 0, 680, 392</ClientArea><PrintPageHeaderStyle " & _
        "parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
        '
        'lblCardCount
        '
        Me.lblCardCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCardCount.ForeColor = System.Drawing.Color.Blue
        Me.lblCardCount.Location = New System.Drawing.Point(376, 400)
        Me.lblCardCount.Name = "lblCardCount"
        Me.lblCardCount.Size = New System.Drawing.Size(152, 23)
        Me.lblCardCount.TabIndex = 180
        Me.lblCardCount.Text = "Record Count:"
        Me.lblCardCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmSIMDataDetails
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(682, 432)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblCardCount, Me.tdgInventoryDetails, Me.lblRowCount, Me.lblScreenDesc, Me.btnExport})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSIMDataDetails"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SIM Data Details"
        CType(Me.tdgInventoryDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "DECLARATIONS"

	Dim _typeOfData As String
	Dim _filter As String
    Dim _filterValue As String
    Dim _IsInventoryData As Boolean
	Dim dt As New DataTable()
    Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
#End Region

#Region "CONSTRUCTORS"

    Public Sub New(ByVal PassedDt As DataTable, ByVal Title As String, ByVal IsInventoryData As Boolean)
        MyBase.New()
        InitializeComponent()
        Try
            dt = PassedDt
            Me.tdgInventoryDetails.DataSource = dt.DefaultView
            For Each dbgc In Me.tdgInventoryDetails.Splits(0).DisplayColumns
                dbgc.Locked = True
                dbgc.AutoSize()
            Next dbgc
            'Me.tdgInventoryDetails.Splits(0).DisplayColumns("Sku_ID").Width = 0
            lblRowCount.Text = "Record Count: " & PassedDt.Rows.Count.ToString()
            Me.tdgInventoryDetails.Caption = Title
            Me._IsInventoryData = IsInventoryData

            Me.lblCardCount.Visible = False
            If Not IsInventoryData Then
                Try
                    Dim sum As Integer = 0
                    Dim row As DataRow
                    For Each row In dt.Rows
                        sum += row("Qty")
                    Next
                    Me.lblCardCount.Text = "Card Count: " & sum.ToString
                    Me.lblCardCount.Visible = True
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

#End Region

#Region "FORM EVENTS"

#End Region

#Region "CONTROL EVENTS"

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim _xl As New Data.ExcelReports()
        If Me._IsInventoryData Then
            _xl.RunSimpleExcelFormat(Me.dt, Me.tdgInventoryDetails.Caption, New String() {"A", "B", "C", "D"})
        Else
            _xl.RunSimpleExcelFormat(Me.dt, Me.tdgInventoryDetails.Caption, New String() {"A", "B", "C", "D", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T"})
        End If
    End Sub

#End Region

#Region "METHODS"



#End Region


End Class
