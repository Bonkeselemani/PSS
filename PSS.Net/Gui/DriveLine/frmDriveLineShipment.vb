
Option Explicit On 

Imports PSS.Data
Imports System.Text

Namespace Gui
    Public Class frmDriveLineShipment
        Inherits System.Windows.Forms.Form

        Private _objDriveLine As PSS.Data.Buisness.DriveLine
        Private _objDriveLinePrint As PSS.Data.Buisness.DriveLinePrint
        Private _iEWID As Integer = 0
        Private _iWOID As Integer = 0
        Private _strOrderName As String
        Private _bHasDetailData As Boolean = False
        Private _strToShipName, _strToAddress, _strToCity, _strToState, _strToZip, _strToPhone As String
        Private _dtComponentsLocationDataTable As DataTable
        Private _strLastSelectedProjectID As String = ""
        Private _iDefaultRepLabelCount As Integer = 5

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._objDriveLine = New PSS.Data.Buisness.DriveLine()
            Me._objDriveLinePrint = New PSS.Data.Buisness.DriveLinePrint()
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
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents tdgData1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnRefresh As System.Windows.Forms.Button
        Friend WithEvents lblOrderRecNum As System.Windows.Forms.Label
        Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
        Friend WithEvents btnInfo As System.Windows.Forms.Button
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents lblShipQty As System.Windows.Forms.Label
        Friend WithEvents lblOrderQty As System.Windows.Forms.Label
        Friend WithEvents btnCloseOrder As System.Windows.Forms.Button
        Friend WithEvents txtShipTo As System.Windows.Forms.TextBox
        Friend WithEvents lblShipTo As System.Windows.Forms.Label
        Friend WithEvents btnReCalTotal As System.Windows.Forms.Button
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents chkPrintLabel As System.Windows.Forms.CheckBox
        Friend WithEvents chkPrintManifest As System.Windows.Forms.CheckBox
        Friend WithEvents Button2 As System.Windows.Forms.Button
        Friend WithEvents btnReprint As System.Windows.Forms.Button
        Friend WithEvents txtRepIDLabel As System.Windows.Forms.TextBox
        Friend WithEvents chkRepIDLabel As System.Windows.Forms.CheckBox
        Friend WithEvents txtRepID As System.Windows.Forms.TextBox
        Friend WithEvents btnPrintRepIDLabel As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmDriveLineShipment))
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.tdgData1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnRefresh = New System.Windows.Forms.Button()
            Me.lblOrderRecNum = New System.Windows.Forms.Label()
            Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
            Me.btnReCalTotal = New System.Windows.Forms.Button()
            Me.btnInfo = New System.Windows.Forms.Button()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.btnPrintRepIDLabel = New System.Windows.Forms.Button()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.txtRepID = New System.Windows.Forms.TextBox()
            Me.chkRepIDLabel = New System.Windows.Forms.CheckBox()
            Me.txtRepIDLabel = New System.Windows.Forms.TextBox()
            Me.chkPrintManifest = New System.Windows.Forms.CheckBox()
            Me.chkPrintLabel = New System.Windows.Forms.CheckBox()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.lblShipQty = New System.Windows.Forms.Label()
            Me.lblOrderQty = New System.Windows.Forms.Label()
            Me.btnReprint = New System.Windows.Forms.Button()
            Me.btnCloseOrder = New System.Windows.Forms.Button()
            Me.txtShipTo = New System.Windows.Forms.TextBox()
            Me.lblShipTo = New System.Windows.Forms.Label()
            Me.DataGrid1 = New System.Windows.Forms.DataGrid()
            Me.Button2 = New System.Windows.Forms.Button()
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Font = New System.Drawing.Font("Arial Black", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTitle.ForeColor = System.Drawing.Color.Olive
            Me.lblTitle.Location = New System.Drawing.Point(0, -5)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(272, 32)
            Me.lblTitle.TabIndex = 56
            Me.lblTitle.Text = "DriveLine Shipment"
            '
            'tdgData1
            '
            Me.tdgData1.AllowUpdate = False
            Me.tdgData1.AlternatingRows = True
            Me.tdgData1.BackColor = System.Drawing.Color.GhostWhite
            Me.tdgData1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tdgData1.FetchRowStyles = True
            Me.tdgData1.FilterBar = True
            Me.tdgData1.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgData1.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.tdgData1.Location = New System.Drawing.Point(0, 24)
            Me.tdgData1.Name = "tdgData1"
            Me.tdgData1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgData1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgData1.PreviewInfo.ZoomFactor = 75
            Me.tdgData1.Size = New System.Drawing.Size(888, 224)
            Me.tdgData1.TabIndex = 57
            Me.tdgData1.Text = "C1TrueDBGrid1"
            Me.tdgData1.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Style1{}Normal{Font:Microsoft Sans Serif, 8.25pt;}Highlig" & _
            "htRow{ForeColor:HighlightText;BackColor:Highlight;}Style14{}OddRow{}RecordSelect" & _
            "or{AlignImage:Center;}Style15{}Heading{Wrap:True;BackColor:Control;Border:Raised" & _
            ",,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}Style10{AlignHorz:N" & _
            "ear;}Style11{}Style12{}Style13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDB" & _
            "Grid.MergeView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCapti" & _
            "onHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyles=""True"" FilterBar=""True"" Mar" & _
            "queeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Vertic" & _
            "alScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>222</Height><CaptionStyle pa" & _
            "rent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRow" & _
            "Style parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Styl" & _
            "e13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=" & _
            """Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle pare" & _
            "nt=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><" & _
            "OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSel" & _
            "ector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style pare" & _
            "nt=""Normal"" me=""Style1"" /><ClientRect>0, 0, 886, 222</ClientRect><BorderSide>0</" & _
            "BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Sp" & _
            "lits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Head" & _
            "ing"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption" & _
            """ /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected""" & _
            " /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow""" & _
            " /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><S" & _
            "tyle parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar" & _
            """ /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits" & _
            "><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultR" & _
            "ecSelWidth><ClientArea>0, 0, 886, 222</ClientArea><PrintPageHeaderStyle parent=""" & _
            """ me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'btnRefresh
            '
            Me.btnRefresh.Location = New System.Drawing.Point(280, 0)
            Me.btnRefresh.Name = "btnRefresh"
            Me.btnRefresh.Size = New System.Drawing.Size(128, 23)
            Me.btnRefresh.TabIndex = 58
            Me.btnRefresh.Text = "Refresh Order Data"
            '
            'lblOrderRecNum
            '
            Me.lblOrderRecNum.ForeColor = System.Drawing.Color.Blue
            Me.lblOrderRecNum.Location = New System.Drawing.Point(416, 0)
            Me.lblOrderRecNum.Name = "lblOrderRecNum"
            Me.lblOrderRecNum.Size = New System.Drawing.Size(184, 24)
            Me.lblOrderRecNum.TabIndex = 63
            Me.lblOrderRecNum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnReCalTotal
            '
            Me.btnReCalTotal.BackColor = System.Drawing.Color.Transparent
            Me.btnReCalTotal.ForeColor = System.Drawing.Color.Transparent
            Me.btnReCalTotal.Image = CType(resources.GetObject("btnReCalTotal.Image"), System.Drawing.Bitmap)
            Me.btnReCalTotal.Location = New System.Drawing.Point(592, 144)
            Me.btnReCalTotal.Name = "btnReCalTotal"
            Me.btnReCalTotal.Size = New System.Drawing.Size(18, 17)
            Me.btnReCalTotal.TabIndex = 76
            Me.btnReCalTotal.TextAlign = System.Drawing.ContentAlignment.TopLeft
            Me.ToolTip1.SetToolTip(Me.btnReCalTotal, "Refresh total")
            '
            'btnInfo
            '
            Me.btnInfo.BackColor = System.Drawing.Color.BurlyWood
            Me.btnInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnInfo.ForeColor = System.Drawing.Color.Blue
            Me.btnInfo.Location = New System.Drawing.Point(592, 104)
            Me.btnInfo.Name = "btnInfo"
            Me.btnInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.btnInfo.Size = New System.Drawing.Size(16, 18)
            Me.btnInfo.TabIndex = 75
            Me.btnInfo.Text = "i"
            Me.btnInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter
            Me.ToolTip1.SetToolTip(Me.btnInfo, "View quantities  by components")
            '
            'Panel1
            '
            Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnPrintRepIDLabel, Me.GroupBox1, Me.btnReCalTotal, Me.btnInfo, Me.GroupBox2, Me.btnReprint, Me.btnCloseOrder, Me.txtShipTo, Me.lblShipTo, Me.DataGrid1})
            Me.Panel1.Location = New System.Drawing.Point(0, 256)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(888, 328)
            Me.Panel1.TabIndex = 64
            '
            'btnPrintRepIDLabel
            '
            Me.btnPrintRepIDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPrintRepIDLabel.ForeColor = System.Drawing.Color.DarkGreen
            Me.btnPrintRepIDLabel.Location = New System.Drawing.Point(752, 294)
            Me.btnPrintRepIDLabel.Name = "btnPrintRepIDLabel"
            Me.btnPrintRepIDLabel.Size = New System.Drawing.Size(128, 28)
            Me.btnPrintRepIDLabel.TabIndex = 78
            Me.btnPrintRepIDLabel.Text = "Print RepID Label"
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtRepID, Me.chkRepIDLabel, Me.txtRepIDLabel, Me.chkPrintManifest, Me.chkPrintLabel})
            Me.GroupBox1.Location = New System.Drawing.Point(608, 168)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(272, 72)
            Me.GroupBox1.TabIndex = 77
            Me.GroupBox1.TabStop = False
            '
            'txtRepID
            '
            Me.txtRepID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtRepID.ForeColor = System.Drawing.Color.Black
            Me.txtRepID.Location = New System.Drawing.Point(128, 40)
            Me.txtRepID.Name = "txtRepID"
            Me.txtRepID.Size = New System.Drawing.Size(88, 22)
            Me.txtRepID.TabIndex = 83
            Me.txtRepID.Text = ""
            Me.txtRepID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'chkRepIDLabel
            '
            Me.chkRepIDLabel.Location = New System.Drawing.Point(8, 44)
            Me.chkRepIDLabel.Name = "chkRepIDLabel"
            Me.chkRepIDLabel.Size = New System.Drawing.Size(120, 16)
            Me.chkRepIDLabel.TabIndex = 82
            Me.chkRepIDLabel.Text = "Print RepID Label"
            '
            'txtRepIDLabel
            '
            Me.txtRepIDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtRepIDLabel.ForeColor = System.Drawing.Color.Black
            Me.txtRepIDLabel.Location = New System.Drawing.Point(224, 40)
            Me.txtRepIDLabel.Name = "txtRepIDLabel"
            Me.txtRepIDLabel.Size = New System.Drawing.Size(40, 22)
            Me.txtRepIDLabel.TabIndex = 81
            Me.txtRepIDLabel.Text = "5"
            Me.txtRepIDLabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'chkPrintManifest
            '
            Me.chkPrintManifest.Location = New System.Drawing.Point(152, 16)
            Me.chkPrintManifest.Name = "chkPrintManifest"
            Me.chkPrintManifest.Size = New System.Drawing.Size(116, 16)
            Me.chkPrintManifest.TabIndex = 1
            Me.chkPrintManifest.Text = "Print Pick Ticket"
            '
            'chkPrintLabel
            '
            Me.chkPrintLabel.Location = New System.Drawing.Point(8, 16)
            Me.chkPrintLabel.Name = "chkPrintLabel"
            Me.chkPrintLabel.Size = New System.Drawing.Size(88, 16)
            Me.chkPrintLabel.TabIndex = 0
            Me.chkPrintLabel.Text = "Print Labels"
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label2, Me.Label1, Me.lblShipQty, Me.lblOrderQty})
            Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox2.ForeColor = System.Drawing.Color.Blue
            Me.GroupBox2.Location = New System.Drawing.Point(608, 104)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(272, 56)
            Me.GroupBox2.TabIndex = 74
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Total"
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.Black
            Me.Label2.Location = New System.Drawing.Point(144, 24)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(40, 16)
            Me.Label2.TabIndex = 69
            Me.Label2.Text = "Ship:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Black
            Me.Label1.Location = New System.Drawing.Point(8, 24)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(48, 16)
            Me.Label1.TabIndex = 68
            Me.Label1.Text = "Order:"
            '
            'lblShipQty
            '
            Me.lblShipQty.BackColor = System.Drawing.Color.White
            Me.lblShipQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblShipQty.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblShipQty.ForeColor = System.Drawing.Color.Black
            Me.lblShipQty.Location = New System.Drawing.Point(184, 16)
            Me.lblShipQty.Name = "lblShipQty"
            Me.lblShipQty.Size = New System.Drawing.Size(80, 32)
            Me.lblShipQty.TabIndex = 67
            Me.lblShipQty.Text = "0"
            Me.lblShipQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblOrderQty
            '
            Me.lblOrderQty.BackColor = System.Drawing.Color.White
            Me.lblOrderQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblOrderQty.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblOrderQty.ForeColor = System.Drawing.Color.Black
            Me.lblOrderQty.Location = New System.Drawing.Point(56, 16)
            Me.lblOrderQty.Name = "lblOrderQty"
            Me.lblOrderQty.Size = New System.Drawing.Size(80, 32)
            Me.lblOrderQty.TabIndex = 66
            Me.lblOrderQty.Text = "0"
            Me.lblOrderQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnReprint
            '
            Me.btnReprint.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprint.ForeColor = System.Drawing.Color.Purple
            Me.btnReprint.Location = New System.Drawing.Point(752, 248)
            Me.btnReprint.Name = "btnReprint"
            Me.btnReprint.Size = New System.Drawing.Size(128, 38)
            Me.btnReprint.TabIndex = 73
            Me.btnReprint.Text = "Reprint"
            '
            'btnCloseOrder
            '
            Me.btnCloseOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCloseOrder.ForeColor = System.Drawing.Color.Crimson
            Me.btnCloseOrder.Location = New System.Drawing.Point(608, 248)
            Me.btnCloseOrder.Name = "btnCloseOrder"
            Me.btnCloseOrder.Size = New System.Drawing.Size(136, 38)
            Me.btnCloseOrder.TabIndex = 72
            Me.btnCloseOrder.Text = "Close Order"
            '
            'txtShipTo
            '
            Me.txtShipTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtShipTo.Location = New System.Drawing.Point(608, 24)
            Me.txtShipTo.Multiline = True
            Me.txtShipTo.Name = "txtShipTo"
            Me.txtShipTo.Size = New System.Drawing.Size(272, 72)
            Me.txtShipTo.TabIndex = 71
            Me.txtShipTo.Text = ""
            '
            'lblShipTo
            '
            Me.lblShipTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblShipTo.ForeColor = System.Drawing.Color.Blue
            Me.lblShipTo.Location = New System.Drawing.Point(608, 8)
            Me.lblShipTo.Name = "lblShipTo"
            Me.lblShipTo.Size = New System.Drawing.Size(200, 24)
            Me.lblShipTo.TabIndex = 70
            Me.lblShipTo.Text = "Ship To:"
            '
            'DataGrid1
            '
            Me.DataGrid1.DataMember = ""
            Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.DataGrid1.Location = New System.Drawing.Point(8, 8)
            Me.DataGrid1.Name = "DataGrid1"
            Me.DataGrid1.Size = New System.Drawing.Size(584, 304)
            Me.DataGrid1.TabIndex = 57
            '
            'Button2
            '
            Me.Button2.Location = New System.Drawing.Point(752, 0)
            Me.Button2.Name = "Button2"
            Me.Button2.Size = New System.Drawing.Size(56, 16)
            Me.Button2.TabIndex = 65
            Me.Button2.Text = "Button2"
            '
            'frmDriveLineShipment
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.LightGray
            Me.ClientSize = New System.Drawing.Size(912, 590)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel1, Me.lblOrderRecNum, Me.btnRefresh, Me.tdgData1, Me.lblTitle, Me.Button2})
            Me.Name = "frmDriveLineShipment"
            Me.Text = "DriveLine - Shipment"
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1.ResumeLayout(False)
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox2.ResumeLayout(False)
            CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmDriveLineShipment_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                Me.chkPrintLabel.Checked = True
                Me.chkPrintManifest.Checked = True
                Me.chkRepIDLabel.Checked = True
                Me.Button2.Visible = False

                LoadOrderData()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmDriveLineShipment_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub


        Private Sub LoadOrderData(Optional ByVal iFlag As Integer = 0)
            Dim dt, dtFinal, dtShipDays As DataTable
            Dim row, row2 As DataRow, foundRows As DataRow()
            Dim rowView As DataRowView
            Dim strExpression As String = ""

            Try
                Me.tdgData1.DataSource = Nothing : Me.DataGrid1.DataSource = Nothing
                Me.txtShipTo.Text = "" : Me.lblOrderQty.Text = 0 : Me.lblShipQty.Text = 0
                Me.DataGrid1.CaptionText = ""

                dt = Me._objDriveLine.GetDriveLineOpenOrders()
                If Not dt.Rows.Count > 0 Then Exit Sub

                dtShipDays = Me._objDriveLine.GetFedExShipDays()

                'Update ShipDays
                For Each row In dt.Rows
                    strExpression = "State_Short='" & row("State") & "'"
                    foundRows = dtShipDays.Select(strExpression)
                    For Each row2 In foundRows 'should be 1 row 
                        row.BeginEdit()
                        row("ShipDays") = row2("ShipDays")
                        row.AcceptChanges() : row.EndEdit()
                        Exit For
                    Next
                Next

                'Sort
                Dim dv As DataView = dt.DefaultView
                dv.Sort = "ShipDays Desc,State Asc"
                dtFinal = dt.Clone
                For Each rowView In dv
                    row = rowView.Row
                    dtFinal.ImportRow(row)
                Next

                If dtFinal.Rows.Count > 0 Then 'dt.Rows.Count > 0 Then
                    Me.tdgData1.DataSource = dtFinal 'dt
                    Me.tdgData1.Splits(0).DisplayColumns("OrderName").Width = 120
                    'Me.tdgData1.Splits(0).DisplayColumns("Retailer").Width = 60
                    Me.tdgData1.Splits(0).DisplayColumns("Project_ID").Width = 50
                    Me.tdgData1.Splits(0).DisplayColumns("Rep_ID").Width = 50
                    Me.tdgData1.Splits(0).DisplayColumns("ZipCode").Width = 70
                    Me.tdgData1.Splits(0).DisplayColumns("State").Width = 40
                    Me.tdgData1.Splits(0).DisplayColumns("ShipDays").Width = 30
                    Me.lblOrderRecNum.Text = "Open Orders: " & dt.Rows.Count
                    Me._bHasDetailData = False
                Else
                    If iFlag = 0 Then
                        ' MessageBox.Show("No order data!", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.lblOrderRecNum.Text = "No Open Order Data!"
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub LoadOrderData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                dt = Nothing : dtFinal = Nothing
            End Try
        End Sub

        Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click

            LoadOrderData()

        End Sub

        '********************************************************************************
        Private Sub UpdateDetailOrderData(Optional ByVal rowIdx As Integer = 0)
            Try

                Dim iRowID As Integer = Me.tdgData1.Row
                Dim strDetailName As String = "", strProjectID As String = ""
                Dim dt, dtFinal As DataTable, row, row2 As DataRow, col As DataColumn
                Dim foundRows As DataRow()
                Dim rowView As DataRowView
                'Dim myD As Date
                Dim j As Integer = 0, i As Integer = 0
                Dim strTableName As String = "DetailData"
                Dim strExpression As String = ""

                Dim aGridTableStyle As New DataGridTableStyle()

                aGridTableStyle.AllowSorting = False

                ' MessageBox.Show("Me.tdgData1.Row=" & Me.tdgData1.Row)

                'Initial select row
                If rowIdx > 0 Then iRowID = rowIdx
                Me.tdgData1.SelectedRows.Add(iRowID) 'select current row

                'Ship Address info
                Me.txtShipTo.Text = ""
                Me._strToShipName = Me.tdgData1.Columns("ShipTo_Name").CellText(iRowID)
                Me._strToAddress = Me.tdgData1.Columns("Address").CellText(iRowID)
                Me._strToCity = Me.tdgData1.Columns("City").CellText(iRowID)
                Me._strToState = Me.tdgData1.Columns("State").CellText(iRowID)
                Me._strToZip = Me.tdgData1.Columns("ZipCode").CellText(iRowID)
                Me._strToPhone = Me.tdgData1.Columns("Phone").CellText(iRowID)

                Me.txtShipTo.Text = Me._strToShipName & Environment.NewLine
                Me.txtShipTo.Text &= Me._strToAddress & Environment.NewLine
                Me.txtShipTo.Text &= Me._strToCity & ", " & Me._strToState & " " & Me._strToZip & Environment.NewLine
                Me.txtShipTo.Text &= Me._strToPhone

                'Get key EW_ID
                If Not IsDBNull(Me.tdgData1.Columns("EW_ID").CellText(iRowID)) Then
                    Me._iEWID = Me.tdgData1.Columns("EW_ID").CellText(iRowID)
                Else
                    MessageBox.Show("Failed to get EW_ID!", "UpdateDetailOrderData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                If Not Me._iEWID > 0 Then
                    MessageBox.Show("Failed to get EW_ID!", "UpdateDetailOrderData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                'Get WO_ID
                If Not IsDBNull(Me.tdgData1.Columns("WO_ID").CellText(iRowID)) Then
                    Me._iWOID = Me.tdgData1.Columns("WO_ID").CellText(iRowID)
                Else
                    MessageBox.Show("Failed to get WO_ID!", "UpdateDetailOrderData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                If Not Me._iWOID > 0 Then
                    MessageBox.Show("Failed to get WO_ID!", "UpdateDetailOrderData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                'Grid Title
                Me._strOrderName = Me.tdgData1.Columns("OrderName").CellText(iRowID)
                'strDetailName = "Order: " & Me._strOrderName & _
                '                ", Retailer: " & Me.tdgData1.Columns("Retailer").CellText(iRowID) & _
                '                ", Project: " & Me.tdgData1.Columns("Project_ID").CellText(iRowID) & _
                '                ", Rep: " & Me.tdgData1.Columns("Rep_ID").CellText(iRowID)
                strDetailName = "Order: " & Me._strOrderName & _
                              ", Project: " & Me.tdgData1.Columns("Project_ID").CellText(iRowID) & _
                              ", Rep: " & Me.tdgData1.Columns("Rep_ID").CellText(iRowID)
                strProjectID = Me.tdgData1.Columns("Project_ID").CellText(iRowID)
                Me.txtRepID.Text = Me.tdgData1.Columns("Rep_ID").CellText(iRowID)
                Me.DataGrid1.CaptionText = strDetailName

                '---------------------------------------- DATA ------------------------------------------------------------------------
                'Keep ProjectID and get Components Location data
                If Not Me._strLastSelectedProjectID = strProjectID Then
                    Me._strLastSelectedProjectID = strProjectID
                    Me._dtComponentsLocationDataTable = Me._objDriveLine.GetDriveLine_LocationComponentAssignmentData(strProjectID)
                End If

                'Get data
                dt = Me._objDriveLine.GetDriveLineOrderDetails(Me._iEWID, strProjectID)
                If Not dt.Rows.Count > 0 Then
                    MessageBox.Show("No detail data!", "UpdateDetailOrderData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                'Add Bin(LocNo)
                For Each row In dt.Rows
                    strExpression = "Component='" & row("Component") & "'"
                    foundRows = Me._dtComponentsLocationDataTable.Select(strExpression)
                    For Each row2 In foundRows 'should be 1 row 
                        row.BeginEdit()
                        row("Bin") = row2("LocNo")
                        row.AcceptChanges() : row.EndEdit()
                        Exit For
                    Next
                Next

                'Sort
                Dim dv As DataView = dt.DefaultView
                dv.Sort = "StoreNo Asc,Bin Asc"
                dtFinal = dt.Clone
                For Each rowView In dv
                    row = rowView.Row
                    dtFinal.ImportRow(row)
                Next

                'Add RowID
                i = 0 : Me._bHasDetailData = True
                For Each row In dtFinal.Rows 'dt.Rows
                    i += 1
                    row.BeginEdit()
                    row("RowID") = i
                    row.AcceptChanges()
                    row.EndEdit()
                Next
                '------------------------------------------------------------------------------------------------------------------------------

                dt = Nothing : dv = Nothing

                dtFinal.TableName = strTableName 'dt.TableName = strTableName
                aGridTableStyle.MappingName = strTableName

                ' Create GridColumnStyle objects for the grid columns 
                Dim aRowID As New DataGridTextBoxColumn()
                Dim aRetailer As New DataGridTextBoxColumn()
                Dim aStoreNo As New DataGridTextBoxColumn()
                Dim aComponent As New DataGridTextBoxColumn()
                Dim aOrderQty As New DataGridTextBoxColumn()
                Dim aShipQty As New DataGridTextBoxColumn()
                Dim aBin As New DataGridTextBoxColumn()
                Dim aUOM As New DataGridTextBoxColumn()
                Dim aAddress As New DataGridTextBoxColumn()
                Dim aCity As New DataGridTextBoxColumn()
                Dim aState As New DataGridTextBoxColumn()
                Dim aZipCode As New DataGridTextBoxColumn()
                Dim aDLStoreID As New DataGridTextBoxColumn()
                Dim aEWID As New DataGridTextBoxColumn()
                Dim aDLDetailID As New DataGridTextBoxColumn()

                'Setup
                With aRowID '1
                    .MappingName = "RowID" : .HeaderText = "RowID"
                    .Width = 20 : .Alignment = HorizontalAlignment.Center
                    '.NullText = ""
                    .TextBox.Enabled = False : .ReadOnly = True : .Format = "#0"
                End With
                With aStoreNo '2
                    .MappingName = "StoreNo" : .HeaderText = "StoreNo"
                    .Width = 50 : .Alignment = HorizontalAlignment.Right
                    .TextBox.Enabled = False : .ReadOnly = True : .NullText = ""
                End With
                With aRetailer '3
                    .MappingName = "Retailer" : .HeaderText = "Retailer"
                    .Width = 50 : .Alignment = HorizontalAlignment.Left
                    .TextBox.Enabled = False : .ReadOnly = True : .NullText = ""
                End With
                With aComponent '4
                    .MappingName = "Component" : .HeaderText = "Component"
                    .Width = 200 : .Alignment = HorizontalAlignment.Left
                    .TextBox.Enabled = False : .ReadOnly = True : .NullText = ""
                End With
                With aOrderQty '5
                    .MappingName = "OrderQty" : .HeaderText = "OrderQty"
                    .Width = 50 : .Alignment = HorizontalAlignment.Right
                    .TextBox.Enabled = False : .ReadOnly = True : .Format = "#0"
                End With
                With aShipQty '6
                    .MappingName = "ShipQty" : .HeaderText = "ShipQty"
                    .Width = 50 : .Alignment = HorizontalAlignment.Right
                    .TextBox.Enabled = False : .ReadOnly = False '.TextBox.Enabled = True : .ReadOnly = False
                    .TextBox.BackColor = Color.Yellow : .Format = "#0"
                    AddHandler .TextBox.TextChanged, AddressOf TextBox_TextChanged
                    '  AddHandler .TextBox.MouseLeave, AddressOf TextBox_MouseLeave
                End With
                With aBin '7
                    .MappingName = "Bin" : .HeaderText = "Bin"
                    .Width = 40 : .Alignment = HorizontalAlignment.Right
                    .TextBox.Enabled = False : .ReadOnly = True : .Format = "#0"
                End With
                With aUOM '8
                    .MappingName = "UOM" : .HeaderText = "UOM"
                    .Width = 40 : .Alignment = HorizontalAlignment.Left
                    .TextBox.Enabled = False : .ReadOnly = True : .NullText = ""
                End With
                With aAddress '9
                    .MappingName = "Address" : .HeaderText = "Address"
                    .Width = 80 : .Alignment = HorizontalAlignment.Left
                    .TextBox.Enabled = False : .ReadOnly = True : .NullText = ""
                End With
                With aCity '10
                    .MappingName = "City" : .HeaderText = "City"
                    .Width = 60 : .Alignment = HorizontalAlignment.Left
                    .TextBox.Enabled = False : .ReadOnly = True : .NullText = ""
                End With
                With aState '11
                    .MappingName = "State" : .HeaderText = "State"
                    .Width = 30 : .Alignment = HorizontalAlignment.Left
                    .TextBox.Enabled = False : .ReadOnly = True : .NullText = ""
                End With
                With aZipCode '12
                    .MappingName = "ZipCode" : .HeaderText = "ZipCode"
                    .Width = 30 : .Alignment = HorizontalAlignment.Left
                    .TextBox.Enabled = False : .ReadOnly = True : .NullText = ""
                End With
                'With aDLStoreID '13
                '    .MappingName = "DLStore_ID" : .HeaderText = "DLStoreID"
                '    .Width = 30 : .Alignment = HorizontalAlignment.Right
                '    .TextBox.Enabled = False : .ReadOnly = True : .Format = "#0"
                'End With
                'With aEWID '14
                '    .MappingName = "EW_ID" : .HeaderText = "EWID"
                '    .Width = 30 : .Alignment = HorizontalAlignment.Right
                '    .TextBox.Enabled = False : .ReadOnly = True : .Format = "#0"
                'End With
                'With aDLDetailID '15
                '    .MappingName = "DLDetail_ID" : .HeaderText = "DLDetailID"
                '    .Width = 30 : .Alignment = HorizontalAlignment.Right
                '    .TextBox.Enabled = False : .ReadOnly = True : .Format = "#0"
                'End With

                With aGridTableStyle.GridColumnStyles
                    .Add(aRowID) : .Add(aRetailer) : .Add(aStoreNo) : .Add(aComponent) : .Add(aOrderQty)
                    .Add(aShipQty) : .Add(aBin) : .Add(aUOM) : .Add(aAddress) : .Add(aCity)
                    .Add(aState) : .Add(aZipCode)
                    '.Add(aDLStoreID) : .Add(aEWID) : .Add(aDLDetailID)
                End With

                Try
                    DataGrid1.TableStyles.Add(aGridTableStyle)
                Catch
                End Try

                Me.DataGrid1.AllowSorting = False
                dtFinal.DefaultView.AllowNew = False 'dt.DefaultView.AllowNew = False
                'dt.Columns(0).ReadOnly = True
                'Bind the DataGrid to the Datatablet. Expand and navigate to first row.
                Me.DataGrid1.DataSource = dtFinal 'dt
                Me.DataGrid1.Expand(-1)
                Me.DataGrid1.NavigateTo(0, strTableName)

                ComputeTotalOrderQty() : ComputeTotalShipQty()

                'Get focus first row, 5th column
                'Me.DataGrid1.Focus()
                'Me.DataGrid1.CurrentCell = New DataGridCell(0, 4)

                Me.btnCloseOrder.Focus()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "UpdateDetailOrderData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Sub

        '********************************************************************************
        Private Sub RefreshGridRecNumLabel()
            Try
                If tdgData1.RowCount > 0 Then
                    Me.lblOrderRecNum.Text = "Open Orders: " & Me.tdgData1.RowCount
                Else
                    Me.lblOrderRecNum.Text = "Open Orders: 0"
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "RefreshGridRecNumLabel", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub ComputeTotalOrderQty()
            Try
                If Not Me._bHasDetailData Then Exit Sub

                Dim dt As DataTable = Me.DataGrid1.DataSource
                Dim sumObj As Object = dt.Compute("Sum(OrderQty)", "")
                If sumObj Is Nothing Or sumObj.ToString.Trim.Length = 0 Then
                    Me.lblOrderQty.Text = 0
                Else
                    Me.lblOrderQty.Text = sumObj
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, " ComputeTotalOrderQty", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub ComputeTotalShipQty()
            Try
                If Not Me._bHasDetailData Then Exit Sub

                Dim dt As DataTable = Me.DataGrid1.DataSource
                Dim sumObj As Object = dt.Compute("Sum(ShipQty)", "")
                If sumObj Is Nothing Or sumObj.ToString.Trim.Length = 0 Then
                    Me.lblShipQty.Text = 0
                Else
                    Me.lblShipQty.Text = sumObj
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, " ComputeTotalShipQty", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub TextBox_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
            ComputeTotalShipQty()
        End Sub

        '********************************************************************************
        Private Sub TextBox_MouseLeave(ByVal sender As Object, ByVal e As EventArgs)
            ComputeTotalShipQty()
        End Sub

        '********************************************************************************
        Private Sub tdgData1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdgData1.MouseUp

            Try
                If Me.tdgData1.PointAt(e.X, e.Y) = C1.Win.C1TrueDBGrid.PointAtEnum.AtFilterBar Then
                    Me.Panel1.Visible = False
                    Exit Sub
                End If
                ' Dim rtype As C1.Win.C1TrueDBGrid.RowTypeEnum = Me.tdgData1.Splits(0).Rows(Me.tdgData1.Row).RowType
                ' MessageBox.Show(rtype.ToString)
                'MessageBox.Show(tdgData1(tdgData1.Row, tdgData1.Col).ToString())

                If Me.tdgData1.RowCount > 0 Then
                    Me.Panel1.Visible = True
                    UpdateDetailOrderData()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "tdgData1_MouseUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub


        '********************************************************************************
        Private Sub tdgData1_AfterFilter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles tdgData1.AfterFilter
            RefreshGridRecNumLabel()
        End Sub

        '********************************************************************************
        Private Sub tdgData1_AfterSort(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles tdgData1.AfterSort
            RefreshGridRecNumLabel()
        End Sub

        '********************************************************************************
        Private Sub btnInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInfo.Click
            Dim dt As DataTable = Me.DataGrid1.DataSource
            Dim row As DataRow
            Dim objUniq As PSS.Data.Buisness.TracFone.Admin
            Dim arrList As New ArrayList()
            Dim strS As String = "", strMsg As String = ""

            Try
                If Not Me._bHasDetailData Then Exit Sub

                If Me.DataGrid1.VisibleRowCount > 0 Then
                    objUniq = New PSS.Data.Buisness.TracFone.Admin()
                    For Each row In objUniq.SelectDistinct("Result", dt, "Component").Rows
                        arrList.Add(row("Component"))
                        strS = row("Component")
                        Dim vObj As Object = dt.Compute("Sum(OrderQty)", "Component='" & strS & "'")
                        If vObj Is Nothing Or vObj.ToString.Trim.Length = 0 Then
                            strMsg &= strS & " ---- 0 piece" & Environment.NewLine
                        Else
                            strMsg &= strS & " ---- " & vObj & " pieces" & Environment.NewLine
                        End If
                    Next
                    MessageBox.Show(strMsg, "Quantities by Components", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnInfo_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                objUniq = Nothing
            End Try
        End Sub

        '********************************************************************************
        Private Sub btnCloseOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseOrder.Click
            Dim dt As DataTable, row As DataRow
            Dim iDLDetailID, iUser_ID, iShipQty, i As Integer
            Dim strWOShipDate As String, strShipDateTime As String
            Dim strRetailer As String

            Try
                If Not Me._bHasDetailData Then Exit Sub

                ComputeTotalOrderQty() : ComputeTotalShipQty()

                dt = Me.DataGrid1.DataSource

                'Validate
                For Each row In dt.Rows
                    If Not row("OrderQty") = row("ShipQty") Then
                        MessageBox.Show("Row " & row("RowID") & ": Order and ship quantities are not the same.", "Quantity Check", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Try
                            Me.DataGrid1.Focus()
                            Me.DataGrid1.CurrentCell = New DataGridCell(row("RowID") - 1, 4)
                        Catch
                        End Try
                        Exit Sub
                    End If
                Next
                If Not Me.lblOrderQty.Text = Me.lblShipQty.Text Then
                    MessageBox.Show("Invalid ship quantity.", "Quantity Check", MessageBoxButtons.OK, MessageBoxIcon.Stop) : Exit Sub
                ElseIf Not IsNumeric(Me.lblOrderQty.Text) Then
                    MessageBox.Show("Invalid order quantity.", "Quantity Check", MessageBoxButtons.OK, MessageBoxIcon.Stop) : Exit Sub
                ElseIf Not IsNumeric(Me.lblShipQty.Text) Then
                    MessageBox.Show("Invalid ship quantity.", "Quantity Check", MessageBoxButtons.OK, MessageBoxIcon.Stop) : Exit Sub
                Else
                    If Me.lblOrderQty.Text = 0 Or Me.lblShipQty.Text = 0 Then
                        MessageBox.Show("Invalid quantity.", "Quantity Check", MessageBoxButtons.OK, MessageBoxIcon.Stop) : Exit Sub
                    End If
                End If

                'Ready to close
                strWOShipDate = Format(Now, "yyyy-MM-dd") : strShipDateTime = Format(Now, "yyyy-MM-dd hh:mm:ss")
                iUser_ID = PSS.Core.ApplicationUser.IDuser
                i = Me._objDriveLine.UpdateAndCloseWorkOrder(Me._iWOID, Me._objDriveLine.LOCID, Me.lblShipQty.Text, strWOShipDate)
                If i = 0 Then
                    MessageBox.Show("Failed to close. See IT.", "Close Workorder", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                'PreID label
                If Me.chkRepIDLabel.Checked Then
                    If IsNumeric(Me.txtRepIDLabel.Text) AndAlso Me.txtRepID.Text.Trim.Length > 0 Then
                        PrintRepIDLabel()
                    Else
                        MessageBox.Show("No valid RepID label data!", "Close Workorder Components", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If

                For Each row In dt.Rows
                    iDLDetailID = row("DLDetail_ID") : iShipQty = row("ShipQty")
                    i = Me._objDriveLine.UpdateAndCloseWorkOrder_Components(iDLDetailID, iShipQty, iUser_ID, strShipDateTime)
                    If i = 0 Then
                        MessageBox.Show("Failed to close. See IT", "Close Workorder Components", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If

                    'Print label
                    If Me.chkPrintLabel.Checked Then
                        Me._objDriveLinePrint.Print_ShipBoxLabel(Me._strOrderName, row("Retailer"), row("StoreNo"), row("Component"), row("Bin"), row("shipQty"))
                    End If
                Next

                'Print Pick Ticket
                If Me.chkPrintManifest.Checked Then
                    Me._objDriveLinePrint.Print_ManifestReport(Me._strOrderName, strWOShipDate, Me._strToShipName, Me._strToAddress, _
                                                               Me._strToCity, Me._strToState, Me._strToZip, Me._strToPhone, _
                                                               Me.lblShipQty.Text, dt, 1)
                End If

                LoadOrderData(1) 'reload data

                'If Me.DataGrid1.VisibleRowCount AndAlso dt.Rows.Count > 0 Then
                '    MessageBox.Show("Me.DataGrid1.VisibleRowCount=" & Me.DataGrid1.VisibleRowCount & "  dt.Rows.Count= " & dt.Rows.Count, "Quantities by Components", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, " btnCloseOrder_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                dt = Nothing
            End Try
        End Sub

        '********************************************************************************
        Private Sub PrintRepIDLabel()
            Dim iCopies As Integer = 0
            Try
                If IsNumeric(Me.txtRepIDLabel.Text) AndAlso Me.txtRepID.Text.Trim.Length > 0 Then
                    iCopies = Me.txtRepIDLabel.Text
                    If iCopies > 0 Then
                        Me._objDriveLinePrint.Print_ShipBoxLabel_RepID("", "", "", Me.txtRepID.Text, 0, iCopies)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub PrintRepIDLabel", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        'Private Sub DataGrid1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DataGrid1.KeyPress
        '    ComputeTotalShipQty()
        'End Sub

        '********************************************************************************
        Private Sub Panel1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseMove
            Try
                If Me.DataGrid1.VisibleRowCount > 0 Then
                    ' If Me.DataGrid1.CurrentCell.RowNumber = Me.DataGrid1.VisibleRowCount - 1 Then
                    '  Me.btnCloseOrder.Focus()
                    ComputeTotalOrderQty() : ComputeTotalShipQty()
                    'End If
                End If
            Catch
            End Try
        End Sub

        '********************************************************************************
        Private Sub btnReCalTotal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReCalTotal.Click
            ComputeTotalShipQty()
        End Sub

        '********************************************************************************
        Private Sub chkPrintLabel_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkPrintLabel.CheckedChanged
            Try
                If Me.chkPrintLabel.Checked Then
                    Me.chkPrintLabel.ForeColor = Color.Navy
                Else
                    Me.chkPrintLabel.ForeColor = Color.Black
                End If
            Catch
            End Try
        End Sub

        '********************************************************************************
        Private Sub chkPrintManifest_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPrintManifest.CheckedChanged
            Try
                If Me.chkPrintManifest.Checked Then
                    Me.chkPrintManifest.ForeColor = Color.Navy
                Else
                    Me.chkPrintManifest.ForeColor = Color.Black
                End If
            Catch
            End Try
        End Sub

        '********************************************************************************
        Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
            Dim i As Integer
            Dim strS As String = ""

            strS = "This is a test" & Environment.NewLine
            strS &= "Line 2 " & Environment.NewLine


            i = Me._objDriveLinePrint.Print_TestLabel(strS, 1)
        End Sub

        '********************************************************************************
        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub


        '********************************************************************************
        Private Sub btnReprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprint.Click
            Try
                Dim fm As New frmDriveLineReprint()
                fm.ShowDialog()
                fm.Close()
                fm.Dispose()

                '    Exit Sub

                '    Dim strOrderName As String
                '    Dim dtWorkOrder As DataTable
                '    Dim dtDetails As DataTable, row As DataRow
                '    Dim iEW_ID As Integer, iTotalQty As Integer = 0
                '    Dim vObj As Object

                '    Try

                '        strOrderName = InputBox("Enter DriveLine OrderName:", "Reprint Label and/or manifest").Trim
                '        If Not strOrderName.Length > 0 Then
                '            Exit Sub
                '        End If

                '        dtWorkOrder = Me._objDriveLine.GetDriveLineClosedOrder(strOrderName)
                '        If Not dtWorkOrder.Rows.Count > 0 Then
                '            MessageBox.Show("The order isn't in WIP.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                '        ElseIf dtWorkOrder.Rows.Count > 1 Then
                '            MessageBox.Show("Found duplicate orders.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                '        Else
                '            iEW_ID = dtWorkOrder.Rows(0).Item("EW_ID")
                '            strOrderName = dtWorkOrder.Rows(0).Item("OrderName")
                '            dtDetails = Me._objDriveLine.GetDriveLineOrderDetails(iEW_ID, True)

                '            If Not dtDetails.Rows.Count > 0 Then
                '                MessageBox.Show("Can't find order detail data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                '            Else

                '                For Each row In dtDetails.Rows
                '                    vObj = row("ShipQty")
                '                    If vObj Is Nothing Or vObj.ToString.Trim.Length = 0 Then
                '                        iTotalQty += 0
                '                    Else
                '                        iTotalQty += vObj
                '                    End If
                '                Next
                '                For Each row In dtDetails.Rows
                ''Print label
                '                    If Me.chkPrintLabel.Checked Then
                '                        Me._objDriveLinePrint.Print_ShipBoxLabel(strOrderName, row("StoreNo"), row("Component"), row("shipQty"))
                '                    End If
                '                Next

                ''Print Manifest
                '                If Me.chkPrintManifest.Checked Then
                '                    Me._objDriveLinePrint.Print_ManifestReport(dtWorkOrder.Rows(0).Item("OrderName"), dtWorkOrder.Rows(0).Item("WO_DateShip"), _
                '                                                               dtWorkOrder.Rows(0).Item("ShipTo_Name"), dtWorkOrder.Rows(0).Item("Address"), _
                '                                                               dtWorkOrder.Rows(0).Item("City"), dtWorkOrder.Rows(0).Item("State"), _
                '                                                               dtWorkOrder.Rows(0).Item("ZipCode"), dtWorkOrder.Rows(0).Item("Phone"), _
                '                                                               iTotalQty, dtDetails, 1)
                '                End If
                '            End If
                '        End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnReprint_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Finally
                '    vObj = Nothing : dtWorkOrder = Nothing : dtDetails = Nothing
            End Try
        End Sub

        '********************************************************************************
        Private Sub txtShipTo_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtShipTo.Enter
            Me.txtShipTo.ReadOnly = True
        End Sub

        '********************************************************************************
        Private Sub txtShipTo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtShipTo.Leave
            Me.txtShipTo.ReadOnly = False
        End Sub

        '********************************************************************************
        Private Sub txtRepIDLabel_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRepIDLabel.KeyPress
            Dim allowed As String = "0123456789"
            Dim curchar As Integer = Asc(e.KeyChar)

            If (allowed.IndexOf(e.KeyChar) = -1) And (curchar <> 8) Then
                e.Handled = True
            End If
        End Sub

        '********************************************************************************
        Private Sub txtRepIDLabel_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRepIDLabel.KeyUp
            If IsNumeric(Me.txtRepIDLabel.Text) Then
                Dim iNum As Integer = Me.txtRepIDLabel.Text
                If iNum > 0 Then
                    Me.txtRepIDLabel.Text = iNum
                Else
                    Me.txtRepIDLabel.Text = Me._iDefaultRepLabelCount
                End If
            Else
                Me.txtRepIDLabel.Text = Me._iDefaultRepLabelCount
            End If
        End Sub

        '********************************************************************************
        Private Sub btnPrintRepIDLabel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrintRepIDLabel.Click
            If Not Me.txtRepID.Text.Trim.Length > 0 Then
                MessageBox.Show("No RepID Data.", "btnPrintRepIDLabel_Click(", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            If Not IsNumeric(Me.txtRepIDLabel.Text) Then
                Me.txtRepIDLabel.Text = Me._iDefaultRepLabelCount
            End If

            PrintRepIDLabel()

        End Sub

        '********************************************************************************
        Private Sub chkRepIDLabel_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkRepIDLabel.CheckedChanged
            Try
                If Me.chkRepIDLabel.Checked Then
                    Me.chkRepIDLabel.ForeColor = Color.Navy
                Else
                    Me.chkRepIDLabel.ForeColor = Color.Black
                End If
            Catch
            End Try
        End Sub
    End Class
End Namespace

