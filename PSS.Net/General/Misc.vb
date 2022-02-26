
Imports PSS.Data.Production.Generic

Public Class Misc

    '******************************************************************************************
    Public Shared Function CheckOpenTabs(ByVal strTabPageTitle As String) As Boolean
        Dim bAlreadyOpen As Boolean = False
        Dim i, iOpenCount As Integer

        Try
            iOpenCount = PSS.Gui.MainWin.MainWin.wrkArea.TabPages.Count

            If iOpenCount > 0 Then
                For i = 0 To iOpenCount - 1
                    If PSS.Gui.MainWin.MainWin.wrkArea.TabPages(i).Title = strTabPageTitle Then
                        MessageBox.Show("You already have a tab for '" & strTabPageTitle & "' open.  Only one tab per option is allowed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        bAlreadyOpen = True

                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception
            MessageBox.Show("A problem has occurred in Gui.General.Misc.CheckOpenTabs: " & ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
        End Try

        Return bAlreadyOpen
    End Function

    '******************************************************************************************
    Public Shared Sub OpenWin(ByVal strTabPageTitle As String, ByRef win As Crownwood.Magic.Controls.TabPage, ByRef objForm As Object)
        Try
            win = New Crownwood.Magic.Controls.TabPage(strTabPageTitle, objForm)

            PSS.Gui.MainWin.MainWin.wrkArea.TabPages.Add(win)
            win.Selected = True
        Catch ex As Exception
            MessageBox.Show("A problem has occurred in Gui.MainWin.MenuMain.OpenWin: " & ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '******************************************************************************************
    Public Shared Sub PopulateC1DropDownList(ByRef ctrlCbo As C1.Win.C1List.C1Combo, _
                                       ByVal dt As DataTable, _
                                       ByVal strDisplayCol As String, _
                                       ByVal strValCol As String)
        Dim i As Integer = 0
        Try
            With ctrlCbo
                .DataSource = Nothing
                .DataSource = dt.DefaultView

                .ValueMember = strValCol
                .DisplayMember = strDisplayCol
                .Text = ""
                .ColumnHeaders = False
                .AutoCompletion = True
                .AutoDropDown = True
                .AutoSelect = True
                .AllowDrop = True
                .MaxDropDownItems = 10
                .Splits(0).DisplayColumns(strDisplayCol).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near

                If dt.Rows.Count > 0 Then

                    For i = 0 To dt.Columns.Count - 1
                        If dt.Columns(i).Caption.Trim.ToUpper = strDisplayCol.Trim.ToUpper Then
                            .Splits(0).DisplayColumns(i).Visible = True
                        Else
                            .Splits(0).DisplayColumns(i).Visible = False
                        End If
                    Next i

                    .Splits(0).DisplayColumns(strDisplayCol).Width = .Width - 5
                End If

            End With
        Catch ex As Exception
            Throw ex
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)
        End Try
    End Sub

	'******************************************************************************************





    Public Shared Function ValidateFrStationOfScreenInWorkFlow(ByVal strScreenName As String, _
                                                               ByVal strDevCurrentStation As String, _
                                                               ByVal iCustID As Integer, _
                                                               ByVal iModelID As Integer, _
                                                               Optional ByVal booAllowBlankInFromLoc As Boolean = False) As Boolean
        Dim dtWFlowInfo As DataTable
        Dim strAcceptableStationsArr() As String
        Dim booResult As Boolean = False
        Dim i As Integer = 0

        Try
            If strScreenName.Trim.Length = 0 Then
                MessageBox.Show("Screen name is missing.", "Validate Work Flow", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                'ElseIf strDevCurrentStation.Trim.Length = 0 Then
                '    MessageBox.Show("Current workstation is missing.", "Validate Work Flow", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf iCustID = 0 Then
                MessageBox.Show("Customer ID is not defined.", "Validate Work Flow", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                dtWFlowInfo = PSS.Data.Buisness.Generic.GetWorkFlowProcessData(strScreenName, iModelID, iCustID)

                If dtWFlowInfo.Rows.Count = 0 Then
                    MessageBox.Show("Work flow is not defined.", "Validate Work Flow", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dtWFlowInfo.Rows.Count > 1 Then
                    MessageBox.Show("Duplicate entry for this screen. Please contacts IT.", "Validate Work Flow", MessageBoxButtons.OK, MessageBoxIcon.Stop)
               Else
                    If booAllowBlankInFromLoc = True AndAlso (IsDBNull(dtWFlowInfo.Rows(0)("wfp_FrStation")) OrElse dtWFlowInfo.Rows(0)("wfp_FrStation").ToString.Trim.Length = 0) Then
                        booResult = True
                    Else
                        If booAllowBlankInFromLoc = False AndAlso (IsDBNull(dtWFlowInfo.Rows(0)("wfp_FrStation")) OrElse dtWFlowInfo.Rows(0)("wfp_FrStation").ToString.Trim.Length = 0) Then
                            MessageBox.Show("Missing from location in work flow. Please contacts IT.", "Validate Work Flow", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            strAcceptableStationsArr = dtWFlowInfo.Rows(0)("wfp_FrStation").ToString.Split("|")
                            For i = 0 To strAcceptableStationsArr.Length - 1
                                If strAcceptableStationsArr(i).Trim.ToLower = strDevCurrentStation.Trim.ToLower Then
                                    booResult = True
                                    Exit For
                                End If
                            Next i

                            If strDevCurrentStation.Trim.Length = 0 Then strDevCurrentStation = "blank"
                            If booResult = False Then MessageBox.Show("This screen does not accept any unit from " & strDevCurrentStation & ".", "Validate Work Flow", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        End If
                    End If 'By pass if from location is blank
                End If 'Existing of work flow
            End If 'validate function parameter

            Return booResult
        Catch ex As Exception
            Throw ex
        End Try
    End Function


	Public Shared Function ValidateFrStationOfScreenInWorkFlow2(ByVal strScreenName As String, _
	  ByVal strDevCurrentStation As String, _
	  ByVal iCustID As Integer, _
	  ByVal iModelID As Integer, _
	  Optional ByVal booAllowBlankInFromLoc As Boolean = False) As String
		Dim dtWFlowInfo As DataTable
		Dim strAcceptableStationsArr() As String
		Dim booResult As Boolean = False
		Dim i As Integer = 0
		Dim _retVal As String

		Try
			If strScreenName.Trim.Length = 0 Then
				_retVal = "Screen name is missing."
				'ElseIf strDevCurrentStation.Trim.Length = 0 Then
				'    _retVal = Current workstation is missing.", "Validate Work Flow", MessageBoxButtons.OK, MessageBoxIcon.Stop)
			ElseIf iCustID = 0 Then
				_retVal = "Customer ID is not defined."
			Else
				dtWFlowInfo = PSS.Data.Buisness.Generic.GetWorkFlowProcessData(strScreenName, iModelID, iCustID)

				If dtWFlowInfo.Rows.Count = 0 Then
					_retVal = "Workflow is not defined."
				ElseIf dtWFlowInfo.Rows.Count > 1 Then
					_retVal = "Duplicate entry for this screen. Please contacts IT."
				Else
					If booAllowBlankInFromLoc = True AndAlso (IsDBNull(dtWFlowInfo.Rows(0)("wfp_FrStation")) OrElse dtWFlowInfo.Rows(0)("wfp_FrStation").ToString.Trim.Length = 0) Then
						_retVal = "Valid"
						booResult = True
					Else
						If booAllowBlankInFromLoc = False AndAlso (IsDBNull(dtWFlowInfo.Rows(0)("wfp_FrStation")) OrElse dtWFlowInfo.Rows(0)("wfp_FrStation").ToString.Trim.Length = 0) Then
							_retVal = "Missing from location in work flow. Please contacts IT."
						Else
							strAcceptableStationsArr = dtWFlowInfo.Rows(0)("wfp_FrStation").ToString.Split("|")
							For i = 0 To strAcceptableStationsArr.Length - 1
								If strAcceptableStationsArr(i).Trim.ToLower = strDevCurrentStation.Trim.ToLower Then
									_retVal = "Valid"
									booResult = True
									Exit For
								End If
							Next i

							If strDevCurrentStation.Trim.Length = 0 Then strDevCurrentStation = "blank"
							If booResult = False Then _retVal = "This screen does not accept any unit from " & strDevCurrentStation & "."
						End If
					End If					  'By pass if from location is blank
				End If				'Existing of work flow
			End If			 'validate function parameter

			Return _retVal
		Catch ex As Exception
			Throw ex
		End Try
    End Function

    '******************************************************************************************
    'Get NTF Triaged Device by Box
    Public Shared Function Triaged_Device(ByVal strBoxID As String) As Boolean
        Dim dt As DataTable

        Try
            dt = PSS.Data.Buisness.TracFone.clsMisc.GetNTFDeviceBox(strBoxID, PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID)

            If dt.Rows.Count > 0 Then
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    '******************************************************************************************
    'Get NTF Triaged Device by SN
    Public Shared Function NTF_Device(ByVal iDevice_ID As Integer) As Boolean
        Dim dt As DataTable

        Try
            dt = PSS.Data.Buisness.TracFone.clsMisc.GetNTFDeviceID(iDevice_ID, PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID)

            If dt.Rows.Count > 0 Then
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    '******************************************************************************************
    Public Shared Sub CopyAllData(ByVal dbgData As C1.Win.C1TrueDBGrid.C1TrueDBGrid, Optional ByVal booVisibleColOnly As Boolean = False)
        Dim strData, strHeader As String
        Dim iRow As Integer
        Dim booCompleteHeader As Boolean = False
        Dim col As C1.Win.C1TrueDBGrid.C1DataColumn

        Try
            strData = "" : strHeader = ""

            If dbgData.RowCount > 0 And dbgData.Columns.Count > 0 Then
                'loop through each row
                For iRow = 0 To dbgData.RowCount - 1
                    'loop through each column
                    For Each col In dbgData.Columns
                        If dbgData.Splits(0).DisplayColumns(col.Caption).Visible = True OrElse booVisibleColOnly = False Then
                            'header
                            If booCompleteHeader = False Then strHeader = strHeader & col.Caption & vbTab

                            'Data
                            strData = strData & col.CellText(iRow) & vbTab
                        End If
                    Next col

                    'add new line to data
                    strData = strData & vbCrLf

                    'Stop collect header
                    booCompleteHeader = True
                Next iRow

                'combine header and data
                strData = strHeader & vbCrLf & strData

                'Copy Data to Clipboard
                System.Windows.Forms.Clipboard.SetDataObject(strData, False)
            Else
                Cursor.Current = Cursors.Default
                MessageBox.Show("No data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        Catch ex As Exception
            Throw ex
        Finally
            dbgData = Nothing
            col = Nothing
        End Try
    End Sub

    '******************************************************************************************
    Public Shared Sub CopySelectedRowsData(ByVal dbgData As C1.Win.C1TrueDBGrid.C1TrueDBGrid, Optional ByVal booVisibleColOnly As Boolean = False)
        Dim strData, strHeader As String
        Dim iRow As Integer
        Dim booCompleteHeader As Boolean = False
        Dim col As C1.Win.C1TrueDBGrid.C1DataColumn

        Try
            strData = "" : strHeader = ""

            If dbgData.SelectedRows.Count > 0 Then
                'loop through each selected row
                For Each iRow In dbgData.SelectedRows

                    'loop through each selected column
                    For Each col In dbgData.Columns
                        If dbgData.Splits(0).DisplayColumns(col.Caption).Visible = True OrElse booVisibleColOnly = False Then
                            'header
                            If booCompleteHeader = False Then
                                strHeader = strHeader & col.Caption & vbTab
                            End If
                            'data
                            strData = strData & col.CellText(iRow) & vbTab
                        End If
                    Next col

                    'add new line to data
                    strData = strData & vbCrLf

                    'Stop collect header
                    booCompleteHeader = True
                Next iRow

                'combine header and data
                strData = strHeader & vbCrLf & strData

                'Copy Data to Clipboard
                System.Windows.Forms.Clipboard.SetDataObject(strData, False)
            Else
                Cursor.Current = Cursors.Default
                MessageBox.Show("Please select a range of cells to copy.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        Catch ex As Exception
            Throw ex
        Finally
            dbgData = Nothing
            col = Nothing
        End Try
    End Sub

    '******************************************************************************************
    Public Shared Function CopyAllDataOfVisibleCols(ByVal dbgData As C1.Win.C1TrueDBGrid.C1TrueDBGrid) As DataTable
        Dim iRow As Integer
        Dim booCompleteHeader As Boolean = False
        Dim col As C1.Win.C1TrueDBGrid.C1DataColumn
        Dim dTB As New DataTable()

        Try

            If dbgData.RowCount > 0 And dbgData.Columns.Count > 0 Then
                'loop through each row
                For iRow = 0 To dbgData.RowCount - 1
                    Dim row As DataRow : row = dTB.NewRow()
                    'loop through each column
                    For Each col In dbgData.Columns
                        If dbgData.Splits(0).DisplayColumns(col.Caption).Visible = True Then
                            'header
                            If booCompleteHeader = False Then
                                dTB.Columns.Add(col.Caption, GetType(String))
                            End If

                            'Data
                            row(col.Caption) = col.CellText(iRow)
                        End If
                    Next col

                    'add new row to datatable
                    dTB.Rows.Add(row)

                    'Stop collect header
                    booCompleteHeader = True
                Next iRow

                Return dTB

            Else
                Cursor.Current = Cursors.Default
                MessageBox.Show("No data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        Catch ex As Exception
            Throw ex
        Finally
            dbgData = Nothing
            col = Nothing
        End Try
    End Function

    '******************************************************************************************
    Public Shared Function CopySelectedDataOfVisibleCols(ByVal dbgData As C1.Win.C1TrueDBGrid.C1TrueDBGrid) As DataTable
        Dim iRow As Integer
        Dim booCompleteHeader As Boolean = False
        Dim col As C1.Win.C1TrueDBGrid.C1DataColumn
        Dim dTB As New DataTable()

        Try

            If dbgData.SelectedRows.Count > 0 And dbgData.Columns.Count > 0 Then
                'loop through each row
                For Each iRow In dbgData.SelectedRows
                    Dim row As DataRow : row = dTB.NewRow()
                    'loop through each column
                    For Each col In dbgData.Columns
                        If dbgData.Splits(0).DisplayColumns(col.Caption).Visible = True Then
                            'header
                            If booCompleteHeader = False Then
                                dTB.Columns.Add(col.Caption, GetType(String))
                            End If

                            'Data
                            row(col.Caption) = col.CellText(iRow)
                        End If
                    Next col

                    'add new row to datatable
                    dTB.Rows.Add(row)

                    'Stop collect header
                    booCompleteHeader = True
                Next iRow

                Return dTB

            Else
                Cursor.Current = Cursors.Default
                MessageBox.Show("No data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        Catch ex As Exception
            Throw ex
        Finally
            dbgData = Nothing
            col = Nothing
        End Try
    End Function

    '******************************************************************************************

    Public Shared Function SumRowValues(ByVal dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal strColName As String, Optional ByVal bUseCheckBoxValue As Boolean = False, Optional ByVal strCheckBoxColName As String = "")
        Dim decSum As Decimal = 0

        Try
            Dim i As Integer

            For i = 0 To dbg.RowCount - 1
                If bUseCheckBoxValue Then
                    If Convert.ToBoolean(dbg.Columns(strCheckBoxColName).CellValue(i)) Then decSum += Convert.ToDecimal(dbg.Columns(strColName).CellValue(i))
                Else
                    decSum += Convert.ToDecimal(dbg.Columns(strColName).CellValue(i))
                End If
            Next i

            Return decSum
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '******************************************************************************************

    Public Shared Function InsertDataRowsIntoDataTable(ByVal drChild() As DataRow, ByVal dtColumnSource As DataTable) As DataTable
        Dim dt As DataTable = Nothing
        Dim dr As DataRow

        Try
            dt = dtColumnSource.Clone

            For Each dr In drChild : dt.ImportRow(dr) : Next dr

            Return dt
        Catch ex As Exception
            Throw ex
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)
        End Try
    End Function

    '******************************************************************************************

    Public Shared Sub SetGridStyles(ByVal dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal bShowColFooters As Boolean)
        Try
            With dbg
                .Font = New Font(dbg.Font, FontStyle.Bold)

                .CaptionStyle.BackColor = Color.LightYellow
                .CaptionStyle.ForeColor = Color.DarkGreen

                .HeadingStyle.BackColor = Color.Navy
                .HeadingStyle.ForeColor = Color.Yellow
                .HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Bottom

                .FilterBar = True
                .FilterActive = True

                .FilterBarStyle.BackColor = Color.White
                .FilterBarStyle.ForeColor = Color.Navy

                .AlternatingRows = True

                .EvenRowStyle.BackColor = Color.Silver
                .EvenRowStyle.ForeColor = Color.Blue

                .OddRowStyle.BackColor = Color.White
                .OddRowStyle.ForeColor = Color.Black

                .RecordSelectorStyle.ForeColor = Color.DarkBlue
                .RecordSelectorStyle.BackColor = Color.Silver

                .SelectedStyle.BackColor = Color.Black
                .SelectedStyle.ForeColor = Color.Yellow

                .AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows

                .ColumnFooters = bShowColFooters

                If bShowColFooters Then
                    .FooterStyle.BackColor = Color.DarkGreen
                    .FooterStyle.ForeColor = Color.White
                    .FooterStyle.Locked = True
                End If
            End With

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Sub InitializeC1DBGrid(ByVal dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        Try
            With dbg
                .DataSource = Nothing
                .Caption = String.Empty
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Sub TextChange(ByVal Ctl As TextBox, ByVal Obj As Object, ByVal Prop As String)
        Dim lngPos As Long
        Try
            CallByName(Obj, Prop, CallType.Set, Ctl.Text)
        Catch ex As Exception
            Beep()
            Try
                Ctl.Text = CallByName(Obj, Prop, CallType.Get)
                lngPos = Len(Trim$(Ctl.Text))
                Ctl.Select(IIf(lngPos = 0, 0, lngPos), 0)
            Catch ex2 As Exception
                MessageBox.Show(ex.Message, Prop, _
                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End Try
    End Sub

    Public Shared Function TextLostFocus(ByVal Ctl As TextBox, ByVal Obj As Object, ByVal Prop As String)
        Try
            TextLostFocus = CallByName(Obj, Prop, CallType.Get)

        Catch ex As Exception
            MessageBox.Show(ex.Message, Prop, _
             MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End Try

    End Function

    Public Shared Function GetBoxQty(ByVal BoxNr As String) As Int16
        Try
            Return PSS.Data.Buisness.Generic.GetBoxQty(BoxNr)
        Catch
            Return 0
        End Try
    End Function

End Class
