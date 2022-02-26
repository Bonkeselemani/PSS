Namespace Gui.WFMTracfone
	Public Class frmWfmAssignWHLoc
		Inherits System.Windows.Forms.Form
#Region " Windows Form Designer generated code "

		Public Sub New()
			MyBase.New()

			'This call is required by the Windows Form Designer.
			InitializeComponent()

			'Add any initialization after the InitializeComponent() call

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
		Friend WithEvents Label1 As System.Windows.Forms.Label
		Friend WithEvents Label2 As System.Windows.Forms.Label
		Friend WithEvents cboBins As System.Windows.Forms.ComboBox
		Friend WithEvents txtBoxNa As System.Windows.Forms.TextBox
		Friend WithEvents lblMsg As System.Windows.Forms.Label
		Friend WithEvents tgBoxes As C1.Win.C1TrueDBGrid.C1TrueDBGrid
		Friend WithEvents tgWH As C1.Win.C1TrueDBGrid.C1TrueDBGrid
		Friend WithEvents pnlBoxNr As System.Windows.Forms.Panel
		Friend WithEvents Label5 As System.Windows.Forms.Label
		Friend WithEvents btnAddBin As System.Windows.Forms.Button
		Friend WithEvents btnCopySelectedBoxes As System.Windows.Forms.Button
		Friend WithEvents btnCopyAllBoxes As System.Windows.Forms.Button
		Friend WithEvents btnCopySelectedWH As System.Windows.Forms.Button
		Friend WithEvents btnCopyAllWH As System.Windows.Forms.Button
		Friend WithEvents Label3 As System.Windows.Forms.Label
		Friend WithEvents btnRefresh As System.Windows.Forms.Button
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmWfmAssignWHLoc))
			Me.cboBins = New System.Windows.Forms.ComboBox()
			Me.Label1 = New System.Windows.Forms.Label()
			Me.txtBoxNa = New System.Windows.Forms.TextBox()
			Me.Label2 = New System.Windows.Forms.Label()
			Me.lblMsg = New System.Windows.Forms.Label()
			Me.tgBoxes = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
			Me.tgWH = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
			Me.pnlBoxNr = New System.Windows.Forms.Panel()
			Me.Label5 = New System.Windows.Forms.Label()
			Me.btnAddBin = New System.Windows.Forms.Button()
			Me.btnCopySelectedBoxes = New System.Windows.Forms.Button()
			Me.btnCopyAllBoxes = New System.Windows.Forms.Button()
			Me.btnCopySelectedWH = New System.Windows.Forms.Button()
			Me.btnCopyAllWH = New System.Windows.Forms.Button()
			Me.Label3 = New System.Windows.Forms.Label()
			Me.btnRefresh = New System.Windows.Forms.Button()
			CType(Me.tgBoxes, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.tgWH, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.pnlBoxNr.SuspendLayout()
			Me.SuspendLayout()
			'
			'cboBins
			'
			Me.cboBins.Location = New System.Drawing.Point(160, 8)
			Me.cboBins.MaxDropDownItems = 20
			Me.cboBins.Name = "cboBins"
			Me.cboBins.Size = New System.Drawing.Size(128, 21)
			Me.cboBins.TabIndex = 1
			Me.cboBins.TabStop = False
			'
			'Label1
			'
			Me.Label1.Location = New System.Drawing.Point(8, 8)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New System.Drawing.Size(144, 23)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Location to be assigned to:"
			Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
			'
			'txtBoxNa
			'
			Me.txtBoxNa.BackColor = System.Drawing.Color.LightSkyBlue
			Me.txtBoxNa.Location = New System.Drawing.Point(96, 8)
			Me.txtBoxNa.Name = "txtBoxNa"
			Me.txtBoxNa.Size = New System.Drawing.Size(216, 20)
			Me.txtBoxNa.TabIndex = 1
			Me.txtBoxNa.Text = ""
			'
			'Label2
			'
			Me.Label2.Location = New System.Drawing.Point(8, 8)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New System.Drawing.Size(80, 23)
			Me.Label2.TabIndex = 0
			Me.Label2.Text = "Box Number:"
			Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
			'
			'lblMsg
			'
			Me.lblMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblMsg.ForeColor = System.Drawing.Color.Red
			Me.lblMsg.Location = New System.Drawing.Point(416, 40)
			Me.lblMsg.Name = "lblMsg"
			Me.lblMsg.Size = New System.Drawing.Size(392, 24)
			Me.lblMsg.TabIndex = 5
			Me.lblMsg.Text = "Message to the user goes here."
			'
			'tgBoxes
			'
			Me.tgBoxes.AllowUpdate = False
			Me.tgBoxes.AlternatingRows = True
			Me.tgBoxes.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
						Or System.Windows.Forms.AnchorStyles.Left)
			Me.tgBoxes.Caption = "Boxes not Assigned to a Bin"
			Me.tgBoxes.CaptionHeight = 17
			Me.tgBoxes.FilterBar = True
			Me.tgBoxes.GroupByCaption = "Drag a column header here to group by that column"
			Me.tgBoxes.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
			Me.tgBoxes.Location = New System.Drawing.Point(8, 104)
			Me.tgBoxes.Name = "tgBoxes"
			Me.tgBoxes.PreviewInfo.Location = New System.Drawing.Point(0, 0)
			Me.tgBoxes.PreviewInfo.Size = New System.Drawing.Size(0, 0)
			Me.tgBoxes.PreviewInfo.ZoomFactor = 75
			Me.tgBoxes.RowHeight = 15
			Me.tgBoxes.Size = New System.Drawing.Size(392, 472)
			Me.tgBoxes.TabIndex = 11
			Me.tgBoxes.PropBag = "<?xml version=""1.0""?><Blob><DataCols><C1DataColumn Caption=""Column New"" DataField" & _
			"=""whb_id""><ValueItems /><GroupInfo /></C1DataColumn><C1DataColumn Caption=""Colum" & _
			"n New"" DataField=""box_na""><ValueItems /><GroupInfo><HeaderText>Box</HeaderText><" & _
			"ColumnVisible>True</ColumnVisible></GroupInfo></C1DataColumn><C1DataColumn Capti" & _
			"on=""Column New"" DataField=""Quantity""><ValueItems /><GroupInfo><HeaderText>Quanti" & _
			"ty</HeaderText><ColumnVisible>True</ColumnVisible></GroupInfo></C1DataColumn><C1" & _
			"DataColumn Caption=""Column New"" DataField=""model_desc""><ValueItems /><GroupInfo>" & _
			"<HeaderText>Model</HeaderText><ColumnVisible>True</ColumnVisible></GroupInfo></C" & _
			"1DataColumn><C1DataColumn Caption=""Location"" DataField=""loc_na""><ValueItems /><G" & _
			"roupInfo /></C1DataColumn></DataCols><Styles type=""C1.Win.C1TrueDBGrid.Design.Co" & _
			"ntextWrapper""><Data>Style50{}Style51{}Caption{AlignHorz:Center;}Style27{}Normal{" & _
			"Font:Tahoma, 11world;BackColor:SteelBlue;}Selected{ForeColor:HighlightText;BackC" & _
			"olor:Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{}Style16{}Style17{}St" & _
			"yle10{AlignHorz:Near;}Style11{}RecordSelector{AlignImage:Center;}Style13{}Style4" & _
			"4{}Style42{}Style12{}Style36{}Style7{}OddRow{BackColor:LightSteelBlue;}Style29{A" & _
			"lignHorz:Near;}Style28{AlignHorz:Near;}HighlightRow{ForeColor:HighlightText;Back" & _
			"Color:Highlight;}Style26{}Style25{}Footer{}Style23{AlignHorz:Near;}Style22{Align" & _
			"Horz:Near;}Style21{}Style20{}Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0" & _
			";AlignVert:Center;}Inactive{ForeColor:InactiveCaptionText;BackColor:InactiveCapt" & _
			"ion;}EvenRow{BackColor:NavajoWhite;}Style6{}Heading{Wrap:True;AlignVert:Center;B" & _
			"order:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style49{}Style" & _
			"48{}Style24{}Style9{}Style8{}Style1{}Style3{}Style4{}Style41{AlignHorz:Near;}Sty" & _
			"le40{AlignHorz:Near;}Style43{}Style45{}Style5{}Style47{AlignHorz:Near;}Style46{A" & _
			"lignHorz:Near;}Style38{}Style39{}FilterBar{Font:Microsoft Sans Serif, 9.75pt, st" & _
			"yle=Bold;ForeColor:Red;BackColor:White;}Style37{}Style34{AlignHorz:Near;}Style35" & _
			"{AlignHorz:Near;}Style32{}Style33{}Style30{}Style31{}Style2{}</Data></Styles><Sp" & _
			"lits><C1.Win.C1TrueDBGrid.MergeView HBarStyle=""Always"" VBarStyle=""Always"" Name=""" & _
			""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnF" & _
			"ooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelector" & _
			"Width=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""" & _
			"><Height>451</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle p" & _
			"arent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><Filte" & _
			"rBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Sty" & _
			"le3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" " & _
			"me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveSt" & _
			"yle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><" & _
			"RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent" & _
			"=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><internalCols><C1" & _
			"DisplayColumn><HeadingStyle parent=""Style2"" me=""Style22"" /><Style parent=""Style1" & _
			""" me=""Style23"" /><FooterStyle parent=""Style3"" me=""Style24"" /><EditorStyle parent" & _
			"=""Style5"" me=""Style25"" /><GroupHeaderStyle parent=""Style1"" me=""Style27"" /><Group" & _
			"FooterStyle parent=""Style1"" me=""Style26"" /><Visible>True</Visible><ColumnDivider" & _
			">DarkGray,Single</ColumnDivider><Width>150</Width><Height>15</Height><DCIdx>0</D" & _
			"CIdx></C1DisplayColumn><C1DisplayColumn><HeadingStyle parent=""Style2"" me=""Style2" & _
			"8"" /><Style parent=""Style1"" me=""Style29"" /><FooterStyle parent=""Style3"" me=""Styl" & _
			"e30"" /><EditorStyle parent=""Style5"" me=""Style31"" /><GroupHeaderStyle parent=""Sty" & _
			"le1"" me=""Style33"" /><GroupFooterStyle parent=""Style1"" me=""Style32"" /><Visible>Tr" & _
			"ue</Visible><ColumnDivider>DarkGray,Single</ColumnDivider><Width>150</Width><Hei" & _
			"ght>15</Height><DCIdx>1</DCIdx></C1DisplayColumn><C1DisplayColumn><HeadingStyle " & _
			"parent=""Style2"" me=""Style40"" /><Style parent=""Style1"" me=""Style41"" /><FooterStyl" & _
			"e parent=""Style3"" me=""Style42"" /><EditorStyle parent=""Style5"" me=""Style43"" /><Gr" & _
			"oupHeaderStyle parent=""Style1"" me=""Style45"" /><GroupFooterStyle parent=""Style1"" " & _
			"me=""Style44"" /><Visible>True</Visible><ColumnDivider>DarkGray,Single</ColumnDivi" & _
			"der><Width>150</Width><Height>15</Height><DCIdx>3</DCIdx></C1DisplayColumn><C1Di" & _
			"splayColumn><HeadingStyle parent=""Style2"" me=""Style34"" /><Style parent=""Style1"" " & _
			"me=""Style35"" /><FooterStyle parent=""Style3"" me=""Style36"" /><EditorStyle parent=""" & _
			"Style5"" me=""Style37"" /><GroupHeaderStyle parent=""Style1"" me=""Style39"" /><GroupFo" & _
			"oterStyle parent=""Style1"" me=""Style38"" /><Visible>True</Visible><ColumnDivider>D" & _
			"arkGray,Single</ColumnDivider><Width>150</Width><Height>15</Height><DCIdx>2</DCI" & _
			"dx></C1DisplayColumn><C1DisplayColumn><HeadingStyle parent=""Style2"" me=""Style46""" & _
			" /><Style parent=""Style1"" me=""Style47"" /><FooterStyle parent=""Style3"" me=""Style4" & _
			"8"" /><EditorStyle parent=""Style5"" me=""Style49"" /><GroupHeaderStyle parent=""Style" & _
			"1"" me=""Style51"" /><GroupFooterStyle parent=""Style1"" me=""Style50"" /><Visible>True" & _
			"</Visible><ColumnDivider>DarkGray,Single</ColumnDivider><Width>150</Width><Heigh" & _
			"t>15</Height><DCIdx>4</DCIdx></C1DisplayColumn></internalCols><ClientRect>0, 17," & _
			" 388, 451</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle" & _
			"></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Norm" & _
			"al"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" " & _
			"/><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /" & _
			"><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><St" & _
			"yle parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><S" & _
			"tyle parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /" & _
			"><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></" & _
			"NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified" & _
			"</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 388, 468</" & _
			"ClientArea><PrintPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle " & _
			"parent="""" me=""Style21"" /></Blob>"
			'
			'tgWH
			'
			Me.tgWH.AllowUpdate = False
			Me.tgWH.AlternatingRows = True
			Me.tgWH.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
						Or System.Windows.Forms.AnchorStyles.Left)
			Me.tgWH.Caption = "Boxes Assigned to a Bin"
			Me.tgWH.FilterBar = True
			Me.tgWH.GroupByCaption = "Drag a column header here to group by that column"
			Me.tgWH.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
			Me.tgWH.Location = New System.Drawing.Point(408, 104)
			Me.tgWH.Name = "tgWH"
			Me.tgWH.PreviewInfo.Location = New System.Drawing.Point(0, 0)
			Me.tgWH.PreviewInfo.Size = New System.Drawing.Size(0, 0)
			Me.tgWH.PreviewInfo.ZoomFactor = 75
			Me.tgWH.Size = New System.Drawing.Size(408, 472)
			Me.tgWH.TabIndex = 12
			Me.tgWH.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
			"r""><Data>Caption{AlignHorz:Center;}Normal{BackColor:SteelBlue;}Selected{ForeColo" & _
			"r:HighlightText;BackColor:Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{" & _
			"}Style16{}Style17{}Style10{AlignHorz:Near;}Style11{}OddRow{BackColor:LightSteelB" & _
			"lue;}Style13{}Style12{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;" & _
			"}RecordSelector{AlignImage:Center;}Footer{}Style21{}Style20{}Inactive{ForeColor:" & _
			"InactiveCaptionText;BackColor:InactiveCaption;}EvenRow{BackColor:NavajoWhite;}He" & _
			"ading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlTex" & _
			"t;AlignVert:Center;}FilterBar{Font:Microsoft Sans Serif, 9.75pt, style=Bold;Fore" & _
			"Color:Red;BackColor:White;}Style4{}Style9{}Style8{}Style5{}Group{AlignVert:Cente" & _
			"r;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style7{}Style6{}Style1{}Style3{" & _
			"}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView HBarStyle=""Alway" & _
			"s"" VBarStyle=""Always"" Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" Colu" & _
			"mnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""Dott" & _
			"edCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""" & _
			"1"" HorizontalScrollGroup=""1""><Height>451</Height><CaptionStyle parent=""Style2"" m" & _
			"e=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""E" & _
			"venRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterS" & _
			"tyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><He" & _
			"adingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRo" & _
			"w"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle par" & _
			"ent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Styl" & _
			"e11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=" & _
			"""Style1"" /><ClientRect>0, 17, 404, 451</ClientRect><BorderSide>0</BorderSide><Bo" & _
			"rderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedSty" & _
			"les><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style " & _
			"parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style par" & _
			"ent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style pare" & _
			"nt=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style pare" & _
			"nt=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""H" & _
			"eading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style par" & _
			"ent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1" & _
			"</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><Cl" & _
			"ientArea>0, 0, 404, 468</ClientArea><PrintPageHeaderStyle parent="""" me=""Style20""" & _
			" /><PrintPageFooterStyle parent="""" me=""Style21"" /></Blob>"
			'
			'pnlBoxNr
			'
			Me.pnlBoxNr.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtBoxNa, Me.Label2})
			Me.pnlBoxNr.Location = New System.Drawing.Point(504, 0)
			Me.pnlBoxNr.Name = "pnlBoxNr"
			Me.pnlBoxNr.Size = New System.Drawing.Size(320, 32)
			Me.pnlBoxNr.TabIndex = 3
			'
			'Label5
			'
			Me.Label5.ForeColor = System.Drawing.Color.Blue
			Me.Label5.Location = New System.Drawing.Point(8, 40)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New System.Drawing.Size(360, 23)
			Me.Label5.TabIndex = 4
			Me.Label5.Text = "Please select a location and then enter the box to be assigned."
			Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			'
			'btnAddBin
			'
			Me.btnAddBin.Location = New System.Drawing.Point(296, 8)
			Me.btnAddBin.Name = "btnAddBin"
			Me.btnAddBin.Size = New System.Drawing.Size(56, 24)
			Me.btnAddBin.TabIndex = 2
			Me.btnAddBin.Text = "Add"
			'
			'btnCopySelectedBoxes
			'
			Me.btnCopySelectedBoxes.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnCopySelectedBoxes.Location = New System.Drawing.Point(232, 72)
			Me.btnCopySelectedBoxes.Name = "btnCopySelectedBoxes"
			Me.btnCopySelectedBoxes.Size = New System.Drawing.Size(168, 23)
			Me.btnCopySelectedBoxes.TabIndex = 8
			Me.btnCopySelectedBoxes.Text = "Copy Selected Row(s)"
			'
			'btnCopyAllBoxes
			'
			Me.btnCopyAllBoxes.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnCopyAllBoxes.Location = New System.Drawing.Point(112, 72)
			Me.btnCopyAllBoxes.Name = "btnCopyAllBoxes"
			Me.btnCopyAllBoxes.Size = New System.Drawing.Size(112, 23)
			Me.btnCopyAllBoxes.TabIndex = 7
			Me.btnCopyAllBoxes.Text = "Copy All Rows"
			'
			'btnCopySelectedWH
			'
			Me.btnCopySelectedWH.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnCopySelectedWH.Location = New System.Drawing.Point(648, 72)
			Me.btnCopySelectedWH.Name = "btnCopySelectedWH"
			Me.btnCopySelectedWH.Size = New System.Drawing.Size(168, 23)
			Me.btnCopySelectedWH.TabIndex = 10
			Me.btnCopySelectedWH.Text = "Copy Selected Row(s)"
			'
			'btnCopyAllWH
			'
			Me.btnCopyAllWH.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnCopyAllWH.Location = New System.Drawing.Point(528, 72)
			Me.btnCopyAllWH.Name = "btnCopyAllWH"
			Me.btnCopyAllWH.Size = New System.Drawing.Size(112, 23)
			Me.btnCopyAllWH.TabIndex = 9
			Me.btnCopyAllWH.Text = "Copy All Rows"
			'
			'Label3
			'
			Me.Label3.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
			Me.Label3.Location = New System.Drawing.Point(8, 584)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New System.Drawing.Size(808, 16)
			Me.Label3.TabIndex = 13
			Me.Label3.Text = "This screen is used to assign a warehouse location to WFM Boxes.  Use the Copy Bu" & _
			"ttons to copy data to the clipboard that can be pasted into Excel."
			'
			'btnRefresh
			'
			Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
			Me.btnRefresh.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnRefresh.Location = New System.Drawing.Point(416, 72)
			Me.btnRefresh.Name = "btnRefresh"
			Me.btnRefresh.Size = New System.Drawing.Size(96, 23)
			Me.btnRefresh.TabIndex = 14
			Me.btnRefresh.Text = "Refresh Lists"
			'
			'frmWfmAssignWHLoc
			'
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(824, 606)
			Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRefresh, Me.btnCopySelectedBoxes, Me.btnCopyAllBoxes, Me.btnCopySelectedWH, Me.btnCopyAllWH, Me.btnAddBin, Me.Label5, Me.pnlBoxNr, Me.tgWH, Me.tgBoxes, Me.lblMsg, Me.Label3, Me.Label1, Me.cboBins})
			Me.Name = "frmWfmAssignWHLoc"
			Me.Text = "WFM Assign Warehouse Location"
			CType(Me.tgBoxes, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.tgWH, System.ComponentModel.ISupportInitialize).EndInit()
			Me.pnlBoxNr.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

#End Region
#Region "FORM EVENTS"

		Private Sub frmWfmAssignWHLoc_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			' UPON LOAD.
			ClearMsg()
			PopulateBinsCombo()
			PopulateBoxesGrid()
			PopulateWHGrid()
			btnRefresh.BackColor = System.Drawing.Color.FromName("Control")
			EnableControls()
		End Sub

#End Region
#Region "CONTROLS EVENTS"
		Private Sub txtBoxNa_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBoxNa.KeyUp
			' STARTS THE MOVEMENT OF THE BOX OR PALLET UPON THE ENTER KEY.
			If txtBoxNa.Text = "" Then Exit Sub
			Try
				If e.KeyCode = Keys.Enter AndAlso cboBins.SelectedValue > 0 Then
					' MAKE SURE THE BOX OR PALLLET ARE IN A VALID LOCATION TO MAKE THE ASSIGNMENT.
					' IF THEY ARE PROCESS THE MOVE.
					Dim _bin_na As String = cboBins.Text
					Dim _box_na As String = txtBoxNa.Text
					If _bin_na = "-- Remove BIN --" Then
						RemoveBin(_box_na)
					Else
						Dim _locCol As New Data.BOL.tcustomer_prod_BinlocationsCollection()
						Dim _wfmw As New Data.BLL.WFMWarehouse()
						If txtBoxNa.Text.Substring(0, 1) = "N" Then
							'If ValidateOkToMovePallet(txtBoxNa.Text) Then
							_wfmw.MovePalletWithinWH(txtBoxNa.Text, cboBins.SelectedValue, PSS.Core.ApplicationUser.IDuser)
							'Else
							'MessageBox.Show("The box is not valid to move due to its location or some other factor.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							'End If
						Else
							If ValidateOkToMoveBox(txtBoxNa.Text) Then
								_wfmw.MoveBoxWithinWH(txtBoxNa.Text, cboBins.SelectedValue, PSS.Core.ApplicationUser.IDuser)
							Else
								MessageBox.Show("The box is not valid to move due to its location or some other factor.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							End If
						End If
					End If
					txtBoxNa.Text = ""
					btnRefresh.BackColor = System.Drawing.Color.FromArgb(192, 255, 192)
					'PopulateBoxesGrid()
					'PopulateWHGrid()
					EnableControls()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
				txtBoxNa.Text = ""
				txtBoxNa.Focus()
			End Try
		End Sub
		Private Sub cboBins_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBins.SelectedValueChanged
			EnableControls()
		End Sub
		Private Sub btnAddBin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddBin.Click
			Dim _newBinName As String
			_newBinName = InputBox("Enter the Bin to be added.", Me.Text)
			If _newBinName <> "" Then
				Try
					Dim _bin As New Data.BOL.wh_bins()
					_bin.bin_na = _newBinName
					_bin.crt_user_id = PSS.Core.ApplicationUser.IDuser
					_bin.ApplyChanges()
					_bin = Nothing
					PopulateBinsCombo()
					MessageBox.Show("The new Bin has been added.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
				Catch ex As Exception
					MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				End Try
			End If
		End Sub
		Private Sub btnCopyAll_btnCopySelectedRows_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopySelectedBoxes.Click, btnCopyAllBoxes.Click, btnCopySelectedWH.Click, btnCopyAllWH.Click
			Try
				Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
				If sender.name = "btnCopyAllBoxes" Then
					Misc.CopyAllData(Me.tgBoxes)
				ElseIf sender.name = "btnCopySelectedBoxes" Then
					Misc.CopySelectedRowsData(Me.tgBoxes)
				ElseIf sender.name = "btnCopyAllWH" Then
					Misc.CopyAllData(Me.tgWH)
				ElseIf sender.name = "btnCopySelectedWH" Then
					Misc.CopySelectedRowsData(Me.tgWH)
				End If
			Catch ex As Exception
				MessageBox.Show(ex.ToString(), "CopyData", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Finally
				Me.Enabled = True : Cursor.Current = Cursors.Default
			End Try
		End Sub
		Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
			RefreshScreen()
		End Sub
#End Region
#Region "METHODS"
		Private Sub PopulateBinsCombo()
			' POPULATES THE MODEL COMBO BOX.
			Dim _dt As New DataTable()
			Dim _nr As DataRow
			Dim _bins As New Data.BOL.wh_binsCollection()
			cboBins.ValueMember = "bin_id"
			cboBins.DisplayMember = "bin_na"
			_dt = _bins.wh_binsDataTable.Copy
			_nr = _dt.NewRow()
			_nr(0) = 0
			_nr(1) = "-- Select --"
			_dt.Rows.InsertAt(_nr, 0)
			_dt.AcceptChanges()
			' Add option to remove bin.
			_nr = _dt.NewRow()
			_nr(0) = 999999999
			_nr(1) = "-- Remove BIN --"
			_dt.Rows.InsertAt(_nr, _dt.Rows.Count)
			_dt.AcceptChanges()
			cboBins.DataSource = _dt
			cboBins.Refresh()
			_bins = Nothing
		End Sub
		Private Sub PopulateBoxesGrid()
			' POPULATE THE BOXES GRID.
			Dim _dt As New DataTable()
			Dim _wfmMov As New Data.BLL.WFMBoxHandling()
			_dt = _wfmMov.GetWfmFloorNoBin()
			tgBoxes.SetDataBinding(_dt, "", False)
			'_wh_bx_col = Nothing
			StyleBoxesGrid()
		End Sub
		Private Sub PopulateWHGrid()
			' POPULATE THE WAREHOUSE GRID.
			Dim _dt As New DataTable()
			Dim _wfmWBin As New Data.BLL.WFMBoxHandling()
			_dt = _wfmWBin.GetWfmFloorWithBin()
			tgWH.SetDataBinding(_dt, "", False)
			_wfmWBin = Nothing
			StyleWHGrid()
		End Sub
		Private Sub PostMsg(ByVal text As String)
			' POST A MESSAGE TO THE USER.
			lblMsg.Text = text
			Me.Refresh()
		End Sub
		Private Sub ClearMsg()
			' CLEARS MESSAGES POSTED TO THE USER.
			lblMsg.Text = ""
		End Sub
		Private Sub EnableControls()
			pnlBoxNr.Visible = cboBins.SelectedValue > 0
		End Sub
		Private Sub StyleBoxesGrid()
			' STYLE THE BOXES GRID.
			tgBoxes.Columns(1).Caption = "BoxID"
			tgBoxes.Columns(2).Caption = "Qty"
			tgBoxes.Columns(3).Caption = "WHLocation"
			tgBoxes.Columns(4).Caption = "Model"
			tgBoxes.Columns(5).Caption = "Workstation"
			tgBoxes.Splits(0).DisplayColumns(0).Visible = False
			tgBoxes.Splits(0).DisplayColumns(1).Width = 125
			tgBoxes.Splits(0).DisplayColumns(2).Width = 50
			tgBoxes.Splits(0).DisplayColumns(3).Width = 35
			tgBoxes.Splits(0).DisplayColumns(4).Width = 50
			tgBoxes.Splits(0).DisplayColumns(5).Width = 75
		End Sub
		Private Sub StyleWHGrid()
			' STYLE THE WH GRID.
			tgWH.Columns(1).Caption = "BoxID"
			tgWH.Columns(2).Caption = "Qty"
			tgWH.Columns(3).Caption = "WHLocation"
			tgWH.Columns(4).Caption = "Model"
			tgWH.Columns(5).Caption = "Workstation"
			tgWH.Splits(0).DisplayColumns(0).Visible = False
			tgWH.Splits(0).DisplayColumns(1).Width = 125
			tgWH.Splits(0).DisplayColumns(2).Width = 50
			tgWH.Splits(0).DisplayColumns(3).Width = 35
			tgWH.Splits(0).DisplayColumns(4).Width = 50
			tgWH.Splits(0).DisplayColumns(5).Width = 75
		End Sub
		Private Sub RefreshScreen()
			' REFRESH THE SCREEN.
			Me.Cursor = Cursors.WaitCursor
			ClearMsg()
			PopulateBoxesGrid()
			PopulateWHGrid()
			btnRefresh.BackColor = System.Drawing.Color.FromName("Control")
			EnableControls()
			Me.Cursor = Cursors.Default
		End Sub
		Private Function ValidateOkToMovePallet(ByVal pallet As String) As Boolean
			' VALIDATE IT IS OK TO MOVE THIS PALLET.
			Dim _retVal As Boolean = False
			Dim _whLocs As New Data.BOL.tcustomer_prod_BinlocationsCollection()
			Dim _p As New Data.BOL.tpallet(pallet)
			Dim _pallet_id = _p.Pallett_ID
			_p = Nothing
			Dim _devs As New Data.BOL.tDeviceCollectionByPallett(_pallet_id)

			' MAKE SURE ALL DEVICES ARE IN THE SAME LOCATION.
			Dim _ws As String = _devs.deviceDataTable.Rows(0)("workstation")

			_devs = Nothing
			Dim _dm As New Data.BLL.DeviceMovement(PSS.Core.ApplicationUser.IDuser)
			Dim _dt As New DataTable()
			_dt = _dm.GetDevWrkstnsForPlt(_pallet_id)
			If _dt.Rows.Count = 0 Then
				Throw New Exception("No devices found for this Pallet.")
			ElseIf _dt.Rows.Count > 1 Then
				Throw New Exception("Pallet has devices in multiple locations.")
			ElseIf _dt.Rows(0)("workstation") <> _ws Then
				Throw New Exception("Pallet location does not match the location of the devices.")
			ElseIf _ws = "" Then
				Throw New Exception("This Pallet does have a valid location assigned to it.")
			End If
			_dt = Nothing

			' MAKE SURE THE LOCATION IS VALID FOR THIS SCREEN TO PROCESS.
			Dim _dr As DataRow
			For Each _dr In _whLocs.BinlocationsDataTable.Rows
				If _ws = _dr("loc_na") Then
					_retVal = True
					Exit For
				End If
			Next

			Return _retVal
		End Function
		Private Function ValidateOkToMoveBox(ByVal box_na As String) As Boolean
			' VALIDATE IT IS OKAY TO MOVE THE BOX.
			Dim _retVal As Boolean = False
			Dim _b As New Data.BOL.wh_box(box_na)
			Dim _whb_id As Integer = _b.whb_id
			Dim _cpl_id As Integer = _b.cpl_id()
			_b = Nothing
			Dim _loc As New Data.BOL.tcustomer_prod_locations(_cpl_id)
			Dim _loc_na As String = _loc.loc_na
			_loc = Nothing
			Dim _whLocs As New Data.BOL.tcustomer_prod_BinlocationsCollection()

			'Dim _devs As New Data.BOL.tDeviceCollectionByWHBox(box_na)

			' MAKE SURE ALL DEVICES ARE IN THE SAME LOCATION.
			'Dim _ws As String = _devs.deviceDataTable.Rows(0)("workstation").ToString()
			'_devs = Nothing
			'Dim _dm As New Data.BLL.DeviceMovement(PSS.Core.ApplicationUser.IDuser)
			'Dim _dt As New DataTable()
			'_dt = _dm.GetDevWrkstnsForWHBox(_whb_id)
			'If _dt.Rows.Count = 0 Then
			'	Throw New Exception("No devices found for this Box.")
			'ElseIf _dt.Rows.Count > 1 Then
			'	Throw New Exception("Box has devices in multiple locations.")
			'ElseIf _dt.Rows(0)("workstation").ToString() <> _ws Then
			'	Throw New Exception("Box location does not match the location of the devices.")
			'ElseIf _ws = "" Then
			'	Throw New Exception("This Box does have a valid location assigned to it.")
			'End If
			'_dt = Nothing


			' MAKE SURE THE LOCATION IS VALID FOR THIS SCREEN TO PROCESS.
			Dim _dr As DataRow
			For Each _dr In _whLocs.BinlocationsDataTable.Rows
				If _loc_na = _dr("loc_na") Then
					_retVal = True
					Exit For
				End If
			Next
			Return _retVal
		End Function
		Private Sub RemoveBin(ByVal box_na As String)
			' REMOVE THE BIN FROM THE BOX OR PALLET.
			If box_na <> "" Then
				Try
					If box_na.Substring(0, 1) = "N" Then
						Dim _p As New Data.BOL.tpallet(box_na)
						If _p.Pallett_ID > 0 AndAlso _p.Pallett_ID > 0 Then
							_p.WHLocation = ""
							_p.ApplyChanges()
							_p = Nothing
							PopulateBoxesGrid()
							PopulateWHGrid()
						End If
					Else
						Dim _box As New Data.BOL.wh_box(box_na)
						If _box.whb_id > 0 AndAlso _box.bin_id > 0 Then
							_box.bin_id = 0
							_box.ApplyChanges()
							_box = Nothing
							PopulateBoxesGrid()
							PopulateWHGrid()
						End If
					End If
				Catch ex As Exception
					MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				End Try
			End If
		End Sub
#End Region
	End Class
End Namespace