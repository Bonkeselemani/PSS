Option Explicit On 
'Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data
Imports System.IO
Imports System.Windows.Forms
Imports System.ComponentModel

Namespace Buisness
    Public Class AIGReports

        Public Enum EnumStatusReports
            <Description("Received_Box Shipped")> ReceivedBoxShipped = 1
            <Description("Unit Received")> UnitReceived = 2
            <Description("Return Shipped")> ReturnShipped = 3
            <Description("Send To SN_Salvage")> SendToSNSalvage = 4
            <Description("Canceled Claims")> CanceledClaims = 5
            <Description("Non Returned Box Claims")> NonReturnedBoxClaims = 6
        End Enum
        Public Enum EnumOtherReports
            <Description("Charges for 30-Day Non Return")> ChargesFor30DayNonReturn = 21
            <Description("Exception Repair Devices")> ExceptionRepairDevices = 22
        End Enum

        Private _objDataProc As DBQuery.DataProc

#Region "Constructor/Destructor"

        '******************************************************************
        Public Sub New()
            Try
                Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub


        '******************************************************************
        Protected Overrides Sub Finalize()
            Me._objDataProc = Nothing
            MyBase.Finalize()
        End Sub


#End Region

        '******************************************************************
        Public Function GetWipData(ByVal iCustID As Integer) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT A.ClaimNo as 'Claim Number', E.Device_SN as 'S/N', A.Brand, A.Model " & Environment.NewLine
                strSql &= ", IF(F.Workstation is null, '', F.Workstation) as 'Work Station', D.Description as PSSI_CurrentStatus " & Environment.NewLine
                strSql &= ", Date_Format(A.LoadedDateTime,'%Y-%m-%d') as 'RMA Received Date' " & Environment.NewLine
                strSql &= ", Date_Format(A.TrackCreatedDateTime,'%Y-%m-%d') as 'Return Kit Shipped Date' " & Environment.NewLine
                strSql &= ", Date_Format(E.Device_DateRec,'%Y-%m-%d') as 'Unit Received Date' " & Environment.NewLine
                strSql &= ", A.ExpectedShipDate " & Environment.NewLine
                strSql &= ", '' as 'Tech Name' " & Environment.NewLine
                strSql &= ", REPLACE(A.Tel,'-','') as Phone, Shipto_Name as Customer" & Environment.NewLine
                strSql &= ", Date_Format(A.QuoteSubmittedDate,'%Y-%m-%d') as 'Quote Submitted Date','' AS 'Part Need','' AS 'Part Arrived', E.Device_ID, A.WO_ID as 'PSS Workorder'" & Environment.NewLine
                strSql &= " FROM ExtendedWarranty A" & Environment.NewLine
                strSql &= " LEFT JOIN lShipCarrier B ON A.SC_ID = B.SC_ID" & Environment.NewLine
                strSql &= " LEFT JOIN lState C ON A.State_ID = C.State_ID" & Environment.NewLine
                strSql &= " LEFT JOIN tmi_Status D ON A.S_ID = D.S_ID" & Environment.NewLine
                strSql &= " LEFT JOIN tdevice E ON A.WO_ID = E.WO_ID" & Environment.NewLine
                strSql &= " LEFT JOIN tcellOpt F ON  E.Device_ID = F.Device_ID" & Environment.NewLine
                strSql &= " WHERE E.Device_DateShip IS NULL AND Cust_ID = " & iCustID & Environment.NewLine
                strSql &= " ORDER BY A.LoadedDateTime " & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetTechName(ByVal iWO_ID As Integer) As String
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim strRes As String = ""

            Try
                strSql = "SELECT security.tUsers.user_fullname from tpartneed INNER JOIN Security.tUsers ON tpartneed.Completed_User_ID= security.tUsers.User_ID where WO_ID=" & iWO_ID & Environment.NewLine
                'Completed_User_ID
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    strRes = dt.Rows(0).Item(0)
                End If

                Return strRes
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetReportData_1To6(ByVal iCust_ID As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = " SELECT Date_Format(A.LoadedDateTime ,'%Y-%m-%d') AS 'DISPATCH DATE', if(S_ID<>1, 'Empty Box Shipped','') AS 'BOX SHIPPED'" & Environment.NewLine
                strSql &= " ,A.ClaimNo AS 'CLAIM#',A.ShipTo_Name AS 'CUSTOMER NAME',A.PSSI2Cust_TrackNo AS 'EMPTY BOX TRACKING #',A.Cust2PSSI_TrackNo AS 'RETURN TRACKING # (BACK TO SERVICER)'" & Environment.NewLine
                strSql &= " ,Date_Format(B.Device_DateRec ,'%Y-%m-%d') AS 'DATE UNIT RECEIVED',if(S_ID=7, 'Shipped', A.PSSI_CurrentStatus)  AS 'STATUS'" & Environment.NewLine
                strSql &= " ,Date_Format(if(C.CellOpt_RefurbCompleteDt is Null, B.Device_DateShip,C.CellOpt_RefurbCompleteDt),'%Y-%m-%d') AS 'DATE REPAIRS COMPLETED'" & Environment.NewLine
                strSql &= " ,Date_Format(B.Device_DateShip,'%Y-%m-%d') AS 'DATE UNIT RETURNED',A.Final_PSSI2Cust_TrackNo AS 'TRACKING # (BACK TO CUSTOMER)'" & Environment.NewLine
                strSql &= " , 0 AS 'CANCELED', 0 AS 'SEND TO SN_SALVAGE (BER)', '' AS 'NOTES (REASON FOR CANCELATION)','' AS 'CLOSED','' AS 'INV#', if(S_ID=8,A.URP_Charge,0) AS 'AMT BILLED'" & Environment.NewLine
                strSql &= ",A.EW_ID,B.Device_ID,A.WO_ID,A.S_ID" & Environment.NewLine
                strSql &= " ,Date_Format(B.Device_DateShip,'%Y-%m-%d') AS ShippedDate" & Environment.NewLine
                strSql &= " FROM extendedwarranty A" & Environment.NewLine
                strSql &= " LEFT JOIN tDevice B ON A.WO_ID=B.WO_ID" & Environment.NewLine
                strSql &= " LEFT JOIN tCellOpt C ON B.Device_ID=C.Device_ID" & Environment.NewLine
                strSql &= " WHERE A.cust_id=" & iCust_ID & ";" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function IsBillCodeID_BER(ByVal iDevice_ID As Integer) As Boolean
            Dim strSql As String = ""
            Dim iBER_BillCodeID As Integer = 2533
            Dim dt As DataTable
            Dim bRes As Boolean = False

            Try
                strSql = "SELECT BillCode_ID FROM tDeviceBill" & Environment.NewLine
                strSql &= " WHERE Device_ID = " & iDevice_ID & " AND BillCode_ID = " & iBER_BillCodeID & ";" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    bRes = True
                End If
                dt = Nothing

                Return bRes
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function IsBillCodeID_Canceled(ByVal iDevice_ID As Integer) As Boolean
            Dim strSql As String = ""
            Dim iCanceled_BillCodeID As Integer = 2534
            Dim dt As DataTable
            Dim bRes As Boolean = False

            Try
                strSql = "SELECT BillCode_ID FROM tDeviceBill" & Environment.NewLine
                strSql &= " WHERE Device_ID = " & iDevice_ID & " AND BillCode_ID = " & iCanceled_BillCodeID & ";" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    bRes = True
                End If
                dt = Nothing

                Return bRes
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '******************************************************************
        Public Sub CreateExcelReport(ByVal ds As DataSet, ByVal strRptName As String)
            Dim R1, drEmail As DataRow
            Dim i, j, k, m, r, iRowNo, RowsNum, ColsNum As Integer
            Dim TopHeaderRowNum As Integer = 1
            Dim strFileName As String = ""

            Dim xlApp As New Excel.Application()
            Dim xlWorkBook As Excel.Workbook = Nothing
            Dim xlWorkSheet As Excel.Worksheet = Nothing
            Dim rng As Excel.Range
            Dim misValue As Object = System.Reflection.Missing.Value
            Dim objSaveFileDialog As New SaveFileDialog()

            Try
                If Not ds.Tables.Count > 0 Then Exit Sub

                xlWorkBook = DirectCast(xlApp.Workbooks.Add(Type.Missing), Excel.Workbook)

                'Add new worksheets as needed
                If ds.Tables.Count > 3 Then
                    For m = 3 To ds.Tables.Count - 1
                        xlWorkSheet = DirectCast(xlApp.Worksheets.Add(misValue, misValue, misValue, misValue), Excel.Worksheet) 'Add sheet
                        xlWorkSheet.Move(misValue, xlApp.ActiveWorkbook.Worksheets(xlApp.ActiveWorkbook.Worksheets.Count)) 'Move to the last 
                    Next
                End If

                'Populate data into Excel
                For k = 0 To ds.Tables.Count - 1  'Go through each table
                    'Initial sheet
                    xlWorkSheet = DirectCast(xlWorkBook.Sheets(k + 1), Excel._Worksheet)

                    'Get counts of rows and columns
                    RowsNum = ds.Tables(k).Rows.Count
                    ColsNum = ds.Tables(k).Columns.Count

                    'add header
                    For j = 0 To ColsNum - 1
                        xlWorkSheet.Cells(TopHeaderRowNum, j + 1) = ds.Tables(k).Columns(j).ColumnName
                    Next

                    'Populate data into excel sheet
                    For r = 0 To RowsNum - 1
                        For j = 0 To ds.Tables(k).Columns.Count - 1
                            xlWorkSheet.Cells(r + TopHeaderRowNum + 1, j + 1) = ds.Tables(k).Rows(r).Item(j)
                        Next
                    Next

                    'When no data
                    If Not RowsNum > 0 Then
                        xlWorkSheet.Cells(TopHeaderRowNum + 1, 1) = "No data"
                    End If

                    'Set Sheet name
                    xlWorkSheet.Name = ds.Tables(k).TableName

                    'Header bold 'and color
                    rng = xlWorkSheet.Range(xlWorkSheet.Cells(TopHeaderRowNum, 1), xlWorkSheet.Cells(TopHeaderRowNum, ColsNum))
                    rng.Font.Bold = True ': rng.Interior.ColorIndex = 15

                    'Auto Fit
                    xlWorkSheet.Cells.EntireColumn.AutoFit()
                    xlWorkSheet.Cells.EntireRow.AutoFit()

                    'Freeze Top Row
                    'Try
                    '    'xlWorkSheet.Activate()
                    '    xlWorkSheet.Application.ActiveWindow.SplitRow = 1
                    '    xlWorkSheet.Application.ActiveWindow.FreezePanes = True
                    'Catch ex As Exception
                    'End Try
                Next


                objSaveFileDialog.DefaultExt = "xls"
                objSaveFileDialog.FileName = strRptName & ".xls"
                objSaveFileDialog.ShowDialog()
                strFileName = objSaveFileDialog.FileName

                If strFileName.Trim.Length = 0 Then
                    MessageBox.Show("No file name has been selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    If strFileName.IndexOf("\") < 0 Then Exit Sub
                    If File.Exists(strFileName) = True Then Kill(strFileName)
                    xlWorkBook.SaveAs(strFileName)
                    MessageBox.Show("File has been saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                'Clean/Release 
                If Not IsNothing(xlWorkSheet) Then
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkSheet)
                End If
                If Not IsNothing(xlWorkBook) Then
                    'objWorkbook.Close(False)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkBook)
                End If
                If Not IsNothing(xlApp) Then
                    xlApp.Quit()
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp)
                End If

                GC.Collect() : GC.WaitForPendingFinalizers()
                GC.Collect() : GC.WaitForPendingFinalizers()

            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnCreateExcelReport", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************
        Public Function EnumDescription(ByVal EnumConstant As [Enum]) As String
            Dim fi As Reflection.FieldInfo = EnumConstant.GetType().GetField(EnumConstant.ToString())
            Dim aattr() As DescriptionAttribute = DirectCast(fi.GetCustomAttributes(GetType(DescriptionAttribute), False), DescriptionAttribute())
            If aattr.Length > 0 Then
                Return aattr(0).Description
            Else
                Return EnumConstant.ToString()
            End If
        End Function

        '******************************************************************
        Public Function GetPartNeedYesNo(ByVal iWO_ID As Integer) As String
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim strRes As String = "No"

            Try
                strSql = " SELECT * FROM tPartNeed WHERE WO_ID=" & iWO_ID & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    strRes = "Yes"
                End If

                Return strRes
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetPartArrivedYesNo(ByVal iWO_ID As Integer) As String
            Dim strSql As String = ""
            Dim dt As DataTable, row As DataRow
            Dim strRes As String = "" 'no part need, so return nothing

            Try
                strSql = " SELECT * FROM tPartNeed WHERE WO_ID=" & iWO_ID & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then 'need part(s) (at least 1 part needed)
                    For Each row In dt.Rows 'if one of all parts is not arrived, then "No"; All parts arrived, then "Yes"
                        If Not IsDate(row("Nav_PO_Rec_Date")) Then
                            strRes = "No"
                            Exit For
                        Else
                            strRes = "Yes"
                        End If
                    Next
                Else
                    strRes = ""
                End If

                Return strRes
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class
End Namespace