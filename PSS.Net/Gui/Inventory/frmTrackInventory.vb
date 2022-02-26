
Namespace Inventory
    Public Class frmTrackInventory
        Inherits System.Windows.Forms.Form

        Private objInventory As PSS.Data.Buisness.Inventory
        Private dtItem As DataTable
        Private iShiftID As Integer = PSS.Core.Global.ApplicationUser.IDShift
        Private strWorkDt As String = Format(CDate(PSS.Core.Global.ApplicationUser.Workdate), "yyyy-MM-dd")

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            objInventory = New PSS.Data.Buisness.Inventory()
            dtItem = New DataTable()
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
        Friend WithEvents grdItems As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents lblShift As System.Windows.Forms.Label
        Friend WithEvents Button2 As System.Windows.Forms.Button
        Friend WithEvents lblUserName As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents lblBin As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents cmdSave As System.Windows.Forms.Button
        Friend WithEvents cmdReplenish As System.Windows.Forms.Button
        Friend WithEvents Button1 As System.Windows.Forms.Button
        Friend WithEvents cmdRecover As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTrackInventory))
            Dim GridLines1 As C1.Win.C1TrueDBGrid.Util.GridLines = New C1.Win.C1TrueDBGrid.Util.GridLines()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.grdItems = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.lblBin = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.lblShift = New System.Windows.Forms.Label()
            Me.Button2 = New System.Windows.Forms.Button()
            Me.lblUserName = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.cmdSave = New System.Windows.Forms.Button()
            Me.cmdReplenish = New System.Windows.Forms.Button()
            Me.Button1 = New System.Windows.Forms.Button()
            Me.cmdRecover = New System.Windows.Forms.Button()
            CType(Me.grdItems, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel2.SuspendLayout()
            Me.SuspendLayout()
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Black
            Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.Yellow
            Me.Label2.Location = New System.Drawing.Point(8, 8)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(224, 88)
            Me.Label2.TabIndex = 57
            Me.Label2.Text = "Bench Cycle Count"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'grdItems
            '
            Me.grdItems.AllowColMove = False
            Me.grdItems.AllowColSelect = False
            Me.grdItems.AllowFilter = False
            Me.grdItems.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows
            Me.grdItems.AllowSort = False
            Me.grdItems.AlternatingRows = True
            Me.grdItems.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.grdItems.BackColor = System.Drawing.Color.LightSteelBlue
            Me.grdItems.CaptionHeight = 17
            Me.grdItems.CollapseColor = System.Drawing.Color.Black
            Me.grdItems.DataChanged = False
            Me.grdItems.BackColor = System.Drawing.Color.Empty
            Me.grdItems.ExpandColor = System.Drawing.Color.Black
            Me.grdItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grdItems.GroupByCaption = "Drag a column header here to group by that column"
            Me.grdItems.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.grdItems.Location = New System.Drawing.Point(7, 102)
            Me.grdItems.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
            Me.grdItems.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.grdItems.Name = "grdItems"
            Me.grdItems.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.grdItems.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.grdItems.PreviewInfo.ZoomFactor = 75
            Me.grdItems.PrintInfo.ShowOptionsDialog = False
            Me.grdItems.RecordSelectorWidth = 16
            GridLines1.Color = System.Drawing.Color.DarkGray
            GridLines1.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single
            Me.grdItems.RowDivider = GridLines1
            Me.grdItems.RowHeight = 20
            Me.grdItems.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.grdItems.ScrollTips = False
            Me.grdItems.Size = New System.Drawing.Size(729, 458)
            Me.grdItems.TabIndex = 1
            Me.grdItems.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Normal{Font:Microsoft Sans Serif, 8.25pt, style=Bold;BackColor:LightSteelBlu" & _
            "e;AlignVert:Center;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}St" & _
            "yle9{}OddRow{BackColor:LightSteelBlue;}RecordSelector{AlignImage:Center;}Heading" & _
            "{Wrap:True;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;BackCo" & _
            "lor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}St" & _
            "yle8{}Style10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style1{}</Data></Styles" & _
            "><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""Fal" & _
            "se"" Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""1" & _
            "7"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""" & _
            "16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Clien" & _
            "tRect>0, 0, 725, 454</ClientRect><BorderSide>0</BorderSide><CaptionStyle parent=" & _
            """Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle" & _
            " parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" " & _
            "/><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Styl" & _
            "e12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""H" & _
            "ighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRo" & _
            "wStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector" & _
            """ me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""N" & _
            "ormal"" me=""Style1"" /></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Styl" & _
            "e parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""H" & _
            "eading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Head" & _
            "ing"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Norma" & _
            "l"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Norma" & _
            "l"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" m" & _
            "e=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Capt" & _
            "ion"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSpl" & _
            "its><Layout>None</Layout><DefaultRecSelWidth>16</DefaultRecSelWidth><ClientArea>" & _
            "0, 0, 725, 454</ClientArea></Blob>"
            '
            'Panel2
            '
            Me.Panel2.BackColor = System.Drawing.Color.Black
            Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblBin, Me.Label3, Me.lblShift, Me.Button2, Me.lblUserName, Me.Label7})
            Me.Panel2.Location = New System.Drawing.Point(240, 8)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(496, 88)
            Me.Panel2.TabIndex = 87
            '
            'lblBin
            '
            Me.lblBin.BackColor = System.Drawing.Color.Transparent
            Me.lblBin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBin.ForeColor = System.Drawing.Color.White
            Me.lblBin.Location = New System.Drawing.Point(86, 49)
            Me.lblBin.Name = "lblBin"
            Me.lblBin.Size = New System.Drawing.Size(173, 16)
            Me.lblBin.TabIndex = 90
            Me.lblBin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(38, 49)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(40, 16)
            Me.Label3.TabIndex = 89
            Me.Label3.Text = "Bin :"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblShift
            '
            Me.lblShift.BackColor = System.Drawing.Color.Transparent
            Me.lblShift.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblShift.ForeColor = System.Drawing.Color.White
            Me.lblShift.Location = New System.Drawing.Point(272, 16)
            Me.lblShift.Name = "lblShift"
            Me.lblShift.Size = New System.Drawing.Size(111, 16)
            Me.lblShift.TabIndex = 88
            Me.lblShift.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Button2
            '
            Me.Button2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Button2.Location = New System.Drawing.Point(144, 245)
            Me.Button2.Name = "Button2"
            Me.Button2.Size = New System.Drawing.Size(200, 31)
            Me.Button2.TabIndex = 66
            Me.Button2.TabStop = False
            Me.Button2.Text = "Generate Report"
            '
            'lblUserName
            '
            Me.lblUserName.BackColor = System.Drawing.Color.Transparent
            Me.lblUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblUserName.ForeColor = System.Drawing.Color.White
            Me.lblUserName.Location = New System.Drawing.Point(83, 15)
            Me.lblUserName.Name = "lblUserName"
            Me.lblUserName.Size = New System.Drawing.Size(173, 16)
            Me.lblUserName.TabIndex = 83
            Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label7
            '
            Me.Label7.BackColor = System.Drawing.Color.Transparent
            Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.White
            Me.Label7.Location = New System.Drawing.Point(3, 15)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(74, 16)
            Me.Label7.TabIndex = 82
            Me.Label7.Text = "PSS User :"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmdSave
            '
            Me.cmdSave.BackColor = System.Drawing.Color.LightSteelBlue
            Me.cmdSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdSave.ForeColor = System.Drawing.Color.Blue
            Me.cmdSave.Location = New System.Drawing.Point(745, 104)
            Me.cmdSave.Name = "cmdSave"
            Me.cmdSave.Size = New System.Drawing.Size(104, 80)
            Me.cmdSave.TabIndex = 2
            Me.cmdSave.Text = "SAVE Bench Cycle Count"
            '
            'cmdReplenish
            '
            Me.cmdReplenish.BackColor = System.Drawing.Color.LightSteelBlue
            Me.cmdReplenish.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdReplenish.ForeColor = System.Drawing.Color.Red
            Me.cmdReplenish.Location = New System.Drawing.Point(745, 280)
            Me.cmdReplenish.Name = "cmdReplenish"
            Me.cmdReplenish.Size = New System.Drawing.Size(104, 80)
            Me.cmdReplenish.TabIndex = 88
            Me.cmdReplenish.Text = "REPLENISH PARTS       (For Marerials Dept. Only)"
            Me.cmdReplenish.Visible = False
            '
            'Button1
            '
            Me.Button1.Location = New System.Drawing.Point(744, 32)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(80, 32)
            Me.Button1.TabIndex = 89
            Me.Button1.Text = "Button1"
            Me.Button1.Visible = False
            '
            'cmdRecover
            '
            Me.cmdRecover.BackColor = System.Drawing.Color.LightSteelBlue
            Me.cmdRecover.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdRecover.ForeColor = System.Drawing.Color.Red
            Me.cmdRecover.Location = New System.Drawing.Point(745, 376)
            Me.cmdRecover.Name = "cmdRecover"
            Me.cmdRecover.Size = New System.Drawing.Size(104, 80)
            Me.cmdRecover.TabIndex = 90
            Me.cmdRecover.Text = "RECOVER PARTS       (For Marerials Dept. Only)"
            Me.cmdRecover.Visible = False
            '
            'frmTrackInventory
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(944, 620)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdRecover, Me.Button1, Me.cmdReplenish, Me.cmdSave, Me.Panel2, Me.grdItems, Me.Label2})
            Me.Name = "frmTrackInventory"
            Me.Text = "frmTrackInventory"
            CType(Me.grdItems, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel2.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmTrackInventory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim i As Integer = 0

            Try
                '*************************************************************************************
                'Check if there is a lock on nav item table
                '*************************************************************************************
                i = 0
                i = objInventory.CheckForSystemLocks()
                If i > 0 Then
                    Throw New Exception("System is going through scheduled maintenance. Please wait 2 Mins before running 'Bench Cycle Count' again.")
                End If

                
                '*************************************************************************************
                'Check if the Machine has a Bin tied to it.
                '*************************************************************************************
                i = 0
                i = objInventory.CheckMachineBinAssociation()
                If i = 0 Then
                    Throw New Exception("No bin is assigned to this Machine. Contact administrator.")
                ElseIf i > 1 Then    'Only one bin per bench
                    Throw New Exception("More than one bin is assigned to this Machine. Contact administrator.")
                End If
                '*************************************************************************************

                objInventory.SetConsumptionStartDate()
                objInventory.SetShiftInfo(PSS.Core.Global.ApplicationUser.IDShift)
                LoadItemGrid()

                Me.lblUserName.Text = PSS.Core.Global.ApplicationUser.User
                Me.lblShift.Text = Me.objInventory.Shift
                Me.lblBin.Text = Me.objInventory.BinCode
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString, "Cycle Count", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.Close()
            End Try
        End Sub

        Private Sub LoadItemGrid()

            Try
                dtItem = Me.objInventory.GetItemGridData()
                Me.grdItems.ClearFields()
                Me.grdItems.DataSource = dtItem.DefaultView
                SetGridProperties()
            Catch ex As Exception
                Throw New Exception("frmTrackInventory.LoadItemGrid: " & ex.Message.ToString)
            End Try

        End Sub

        Private Sub SetGridProperties()
            Dim iNumOfColumns As Integer = Me.grdItems.Columns.Count
            Dim i As Integer


            With Me.grdItems
                'Heading style (Horizontal Alignment to Center)
                For i = 0 To (iNumOfColumns - 1)
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Next
                'header forecolor
                .Splits(0).DisplayColumns(4).HeadingStyle.ForeColor = .ForeColor.Blue
                .Splits(0).DisplayColumns(5).HeadingStyle.ForeColor = .ForeColor.Blue
                .Splits(0).DisplayColumns(6).HeadingStyle.ForeColor = .ForeColor.Blue
                .Splits(0).DisplayColumns(7).HeadingStyle.ForeColor = .ForeColor.Red
                .Splits(0).DisplayColumns(8).HeadingStyle.ForeColor = .ForeColor.Red

                'Set individual column data horizontal alignment
                .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                .Splits(0).DisplayColumns(3).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                .Splits(0).DisplayColumns(4).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns(5).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns(6).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns(7).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns(8).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                'Body Forecolor
                .Splits(0).DisplayColumns(4).Style.ForeColor = .ForeColor.Blue
                .Splits(0).DisplayColumns(5).Style.ForeColor = .ForeColor.Blue
                .Splits(0).DisplayColumns(6).Style.ForeColor = .ForeColor.Blue
                .Splits(0).DisplayColumns(7).Style.ForeColor = .ForeColor.Red
                .Splits(0).DisplayColumns(8).Style.ForeColor = .ForeColor.Red

                'Body Font Weight


                'Set Column Widths
                .Splits(0).DisplayColumns(2).Width = 130
                .Splits(0).DisplayColumns(3).Width = 200
                .Splits(0).DisplayColumns(4).Width = 64
                .Splits(0).DisplayColumns(5).Width = 64
                .Splits(0).DisplayColumns(6).Width = 64
                .Splits(0).DisplayColumns(7).Width = 80
                .Splits(0).DisplayColumns(8).Width = 80

                'Make some columns invisible
                .Splits(0).DisplayColumns(0).Visible = False
                .Splits(0).DisplayColumns(1).Visible = False
                .Splits(0).DisplayColumns(7).Visible = False
                .Splits(0).DisplayColumns(8).Visible = False


            End With
        End Sub

        Protected Overrides Sub Finalize()
            objInventory = Nothing
            If Not IsNothing(dtItem) Then
                dtItem.Dispose()
                dtItem = Nothing
            End If
            MyBase.Finalize()
        End Sub


        Private Sub Asif()
            With Me.grdItems
                Dim x As String = .Splits(0).DisplayColumns(2).Width & "-" & _
                                    .Splits(0).DisplayColumns(3).Width & "-" & _
                                    .Splits(0).DisplayColumns(4).Width & "-" & _
                                    .Splits(0).DisplayColumns(5).Width & "-" & _
                                    .Splits(0).DisplayColumns(6).Width & "-" & _
                                    .Splits(0).DisplayColumns(7).Width

                MsgBox(x)
            End With

        End Sub

        Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
            Dim R1 As DataRow
            Dim i As Integer = 0
            Dim strDate As String = Format(Now(), "yyyy-MM-dd HH:mm:ss")
            Dim iNewQty As Integer = 0
            Dim iScrapQty As Integer = 0
            Dim iDefectiveQty As Integer = 0

            Cursor.Current = Cursors.WaitCursor
            cmdSave.Enabled = False

            Try
                '*************************************************************************************
                'Check this there is any data in Replenish Column
                '*************************************************************************************
                For Each R1 In dtItem.Rows
                    If Len(Trim(R1("Replenish"))) > 0 Then
                        Throw New Exception("Please clear the data in 'Replenish' column in the grid.")
                    End If
                Next R1
                '*************************************************************************************
                For Each R1 In dtItem.Rows

                    'New Quantity
                    If Len(Trim(R1("New"))) > 0 Then
                        If Not IsNumeric(R1("New")) Then
                            Throw New Exception("Please enter a numeric value for New.")
                        End If
                        iNewQty = CInt(R1("New"))
                    Else
                        iNewQty = 0
                    End If

                    'Scrap Quantity
                    If Len(Trim(R1("Scrap"))) > 0 Then
                        If Not IsNumeric(R1("Scrap")) Then
                            Throw New Exception("Please enter a numeric value for Scrap.")
                        End If
                        iScrapQty = CInt(R1("Scrap"))
                    Else
                        iScrapQty = 0
                    End If

                    'Defective Quantity
                    If Len(Trim(R1("Defective"))) > 0 Then
                        If Not IsNumeric(R1("Defective")) Then
                            Throw New Exception("Please enter a numeric value for Defective.")
                            Exit Sub
                        End If
                        iDefectiveQty = CInt(R1("Defective"))
                    Else
                        iDefectiveQty = 0
                    End If

                    i = Me.objInventory.SaveBenchData(strWorkDt, _
                                                iShiftID, _
                                                strDate, _
                                                Trim(R1("No_")), _
                                                Trim(R1("Description")), _
                                                iNewQty, _
                                                iScrapQty, _
                                                iDefectiveQty, _
                                                PSS.Core.Global.ApplicationUser.IDuser)

                Next R1

                If i > 0 Then
                    displayNoteBoard("Cycle counts have been saved successfully.", 7000)
                    Me.Close()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Save Cycle Counts", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                R1 = Nothing
                Cursor.Current = Cursors.Default
                cmdSave.Enabled = True
            End Try
        End Sub
        Private Sub displayNoteBoard(ByVal vString As String, ByVal iMilliSecs As Integer)
            Dim frm As New Gui.NoteBoard.frmNoteBoard(vString, iMilliSecs)
            frm.ShowDialog()
            If Not IsNothing(frm) Then
                frm = Nothing
            End If
        End Sub

        Private Sub cmdReplenish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReplenish.Click
            Dim myfrmObj As New frmPassword()
            Dim R1 As DataRow
            Dim iReplenish As Integer = 0
            Dim i As Integer = 0

            Cursor.Current = Cursors.WaitCursor
            Me.cmdReplenish.Enabled = False

            Try
                '*************************************************************************************
                'Check this there is any data in New, Scrap and defective columns
                '*************************************************************************************
                For Each R1 In dtItem.Rows
                    If Len(Trim(R1("New"))) > 0 Then
                        Throw New Exception("Please clear the data in 'New' column in the grid.")
                    ElseIf Len(Trim(R1("Scrap"))) > 0 Then
                        Throw New Exception("Please clear the data in 'Scrap' column in the grid.")
                    ElseIf Len(Trim(R1("Defective"))) > 0 Then
                        Throw New Exception("Please clear the data in 'Defective' column in the grid.")
                    ElseIf Len(Trim(R1("Recover"))) > 0 Then
                        Throw New Exception("Please clear the data in 'Recover' column in the grid.")
                    ElseIf Len(Trim(R1("Replenish"))) > 0 Then
                        If IsNumeric(Trim(R1("Replenish"))) Then
                            If CInt(R1("Replenish")) < 0 Then
                                Throw New Exception("'Replenish' column can only have positive values.")
                            End If
                        Else
                            Throw New Exception("'Replenish' column can only have numeric values.")
                        End If

                        'ElseIf CInt(R1("Recover")) >= 0 Then
                        '    Throw New Exception("'Recover' column can only have negative values.")
                    End If
                Next R1
                '******************************************************

                myfrmObj.ShowDialog()

                If myfrmObj.PasswordValidated = 0 Then        '1 is validated; 0 is not validated
                    Throw New Exception("Password did not match. Please check your password and re-enter.")
                End If
                '******************************************************
                'Perform Replenishment here
                If MessageBox.Show("Are you sure you want to Replenish Parts on this Desk?", "Replenish Parts", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                    For Each R1 In dtItem.Rows

                        'Replenish Quantity
                        If Len(Trim(R1("Replenish"))) > 0 Then
                            If Not IsNumeric(R1("Replenish")) Then
                                Throw New Exception("Please enter a numeric value for Replenish.")
                                Exit Sub
                            End If
                            iReplenish = CInt(R1("Replenish"))
                        Else
                            iReplenish = 0
                        End If
                        If iReplenish > 0 Then
                            i = Me.objInventory.ReplenishParts(strWorkDt, Trim(R1("No_")), iReplenish)
                        End If
                    Next R1

                    'Display message
                    If i > 0 Then
                        displayNoteBoard("Parts have been replenished successfully for this desk.", 7000)
                        Me.Close()
                    End If
                End If
                '******************************************************
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Replenish Parts", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                R1 = Nothing
                If Not IsNothing(myfrmObj) Then
                    myfrmObj = Nothing
                End If

                Cursor.Current = Cursors.Default
                Me.cmdReplenish.Enabled = True

            End Try

        End Sub

        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
            Asif()
        End Sub


        Private Sub cmdRecover_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRecover.Click
            Dim myfrmObj As New frmPassword()
            Dim R1 As DataRow
            Dim iRecover As Integer = 0
            Dim i As Integer = 0

            Cursor.Current = Cursors.WaitCursor
            Me.cmdReplenish.Enabled = False

            Try
                '*************************************************************************************
                'Check this there is any data in New, Scrap, defective and Replenish columns
                '*************************************************************************************
                For Each R1 In dtItem.Rows
                    If Len(Trim(R1("New"))) > 0 Then
                        Throw New Exception("Please clear the data in 'New' column in the grid.")
                    ElseIf Len(Trim(R1("Scrap"))) > 0 Then
                        Throw New Exception("Please clear the data in 'Scrap' column in the grid.")
                    ElseIf Len(Trim(R1("Defective"))) > 0 Then
                        Throw New Exception("Please clear the data in 'Defective' column in the grid.")
                    ElseIf Len(Trim(R1("Replenish"))) > 0 Then
                        Throw New Exception("Please clear the data in 'Replenish' column in the grid.")
                    
                    ElseIf Len(Trim(R1("Recover"))) > 0 Then
                        If IsNumeric(Trim(R1("Recover"))) Then
                            If CInt(R1("Recover")) >= 0 Then
                                Throw New Exception("'Recover' column can only have negative values.")
                            End If
                        Else
                            Throw New Exception("'Recover' column can only have numeric values.")
                        End If
                        'ElseIf CInt(R1("Replenish")) < 0 Then
                        '    Throw New Exception("'Replenish' column can only have positive values.")
                        'ElseIf CInt(R1("Recover")) >= 0 Then
                        '    Throw New Exception("'Recover' column can only have negative values.")
                    End If
                Next R1
                '******************************************************

                myfrmObj.ShowDialog()

                If myfrmObj.PasswordValidated = 0 Then        '1 is validated; 0 is not validated
                    Throw New Exception("Password did not match. Please check your password and re-enter.")
                End If
                '******************************************************
                'Perform Replenishment here
                If MessageBox.Show("Are you sure you want to Recover these Parts on this Desk?", "Recover Parts", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                    For Each R1 In dtItem.Rows

                        'Replenish Quantity
                        If Len(Trim(R1("Recover"))) > 0 Then
                            If Not IsNumeric(R1("Recover")) Then
                                Throw New Exception("Please enter a numeric value for Replenish.")
                                Exit Sub
                            End If
                            iRecover = CInt(R1("Recover"))
                        Else
                            iRecover = 0
                        End If
                        If iRecover > 0 Then
                            i = Me.objInventory.ReplenishParts(strWorkDt, Trim(R1("No_")), iRecover)
                        End If
                    Next R1

                    'Display message
                    If i > 0 Then
                        displayNoteBoard("Parts have been replenished successfully for this desk.", 7000)
                        Me.Close()
                    End If
                End If
                '******************************************************
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Recover Parts", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                R1 = Nothing
                If Not IsNothing(myfrmObj) Then
                    myfrmObj = Nothing
                End If

                Cursor.Current = Cursors.Default
                Me.cmdReplenish.Enabled = True

            End Try

        End Sub
    End Class
End Namespace