Option Explicit On 

Imports System.IO

Namespace Buisness
    Public Class SamSungWrty

        Private Const SamSung_Manuf_ID As Integer = 21
        Private _objDataProc As DBQuery.DataProc

        '******************************************************************
        Public Sub New()
            Try
                Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '******************************************************************
        Public Function GetYearList() As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim i As Integer

            Try
                strSql = "select YEAR(now()) as ID, date_format(now(), '%y') as 'Desc'"
                dt = Me._objDataProc.GetDataTable(strSql)

                For i = 1 To 10
                    R1 = dt.NewRow
                    R1("ID") = CInt(dt.Rows(0)("ID")) - i
                    R1("Desc") = Right(R1("ID"), 2).ToString
                    dt.Rows.Add(R1)
                    dt.AcceptChanges()
                Next i

                Return dt
            Catch ex As Exception
                Throw New Exception()
            Finally
                Generic.DisposeDT(dt)
                R1 = Nothing
            End Try
        End Function

        '******************************************************************
        Public Function Get12MonthList() As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim i As Integer

            Try
                strSql = "select 1 as ID, '01' as 'Desc'"
                dt = Me._objDataProc.GetDataTable(strSql)

                For i = 2 To 12
                    R1 = dt.NewRow
                    R1("ID") = i
                    R1("Desc") = Format(i, "00").ToString
                    dt.Rows.Add(R1)
                    dt.AcceptChanges()
                Next i

                Return dt
            Catch ex As Exception
                Throw New Exception()
            Finally
                Generic.DisposeDT(dt)
                R1 = Nothing
            End Try
        End Function

        '******************************************************************
        Public Function CheckWrty(ByVal iManufYear As Integer, _
                                  ByVal iManufMonth As Integer, _
                                  Optional ByVal strToday As String = "") As Integer
            Dim dteManuf, dteLastDateOfWrty, dte15MonthAfterManufDate As Date
            Dim iInWrty, iWrtyYear, iWrtyMonth As Integer
            Dim strSql As String

            Try
                '1:Get current date from server
                If strToday.Trim.Length = 0 Then strToday = Generic.GetMySqlDateTime("%Y-%m-%d")

                '2: construct manufacture date
                dteManuf = CDate(iManufYear & "-" & iManufMonth & "-" & Date.DaysInMonth(iManufYear, iManufMonth))

                '3: Add 15 moths to manufacture date
                dte15MonthAfterManufDate = DateAdd(DateInterval.Month, 15, dteManuf)

                '4: construct last date of warranty
                iWrtyYear = dte15MonthAfterManufDate.Year : iWrtyMonth = dte15MonthAfterManufDate.Month
                dteLastDateOfWrty = CDate(iWrtyYear & "-" & iWrtyMonth & "-" & Date.DaysInMonth(iWrtyYear, iWrtyMonth))

                If CDate(strToday) <= dteLastDateOfWrty Then iInWrty = 1 Else iInWrty = 0

                Return iInWrty
            Catch ex As Exception
                Throw New Exception()
            Finally
                dteManuf = Nothing
                dteLastDateOfWrty = Nothing
                dte15MonthAfterManufDate = Nothing
            End Try
        End Function

        '******************************************************************
        Public Function LoadRepCodeMatGrpPmtMap(ByVal strFileLoc As String) As Integer
            Dim strArrHeader() = New String() {"Repair Code", "Material Group Code", "Payment Code"}
            Dim objExcel As Object = Nothing    ' Excel application
            Dim objBook As Object = Nothing     ' Excel workbook
            Dim objSheet As Object = Nothing    ' Excel Worksheet
            Dim strRepCode, strMtGrpCode, strPmtCode As String
            Dim i, iRepID, iPmtID, iMapID, iRecords As Integer

            Try
                strRepCode = "" : strMtGrpCode = "" : strPmtCode = ""
                i = 1 : iRepID = 0 : iPmtID = 0 : iMapID = 0

                objExcel = CreateObject("Excel.Application")
                objBook = objExcel.Workbooks.Open(strFileLoc)
                objSheet = objExcel.Worksheets(1)
                objExcel.Visible = False

                '**************************************
                'Validate header
                '**************************************
                If objSheet.range("A" & i).value.ToString().Trim <> strArrHeader(0) Then
                    Throw New Exception("Header in column A must be """ & strArrHeader(0) & """.")
                ElseIf objSheet.range("B" & i).value.ToString().Trim <> strArrHeader(1) Then
                    Throw New Exception("Header in column B must be """ & strArrHeader(1) & """.")
                ElseIf objSheet.range("C" & i).value.ToString().Trim <> strArrHeader(2) Then
                    Throw New Exception("Header in column C must be """ & strArrHeader(2) & """.")
                Else
                    i += 1

                    If Not IsNothing(objSheet.range("A" & i).value) Then strRepCode = objSheet.range("A" & i).value.ToString.Trim
                    If Not IsNothing(objSheet.range("B" & i).value) Then strMtGrpCode = objSheet.range("B" & i).value.ToString.Trim
                    If Not IsNothing(objSheet.range("C" & i).value) Then strPmtCode = objSheet.range("C" & i).value.ToString.Trim

                    While strRepCode.Length > 0 AndAlso strMtGrpCode.Length > 0 AndAlso strPmtCode.Length > 0
                        iRepID = Me.GetSSCellRepID(strRepCode)
                        iPmtID = Me.GetSSWrtyPaymentCodeID(strPmtCode)
                        iMapID = Me.GetSSRepCdMtGrpPmtCdMapID(iRepID, strMtGrpCode)

                        If iRepID = 0 Then Throw New Exception("Repair code (" & strRepCode & ") does not exist in lrepaircode table.")
                        If iPmtID = 0 Then Throw New Exception("Payment code (" & strPmtCode & ") does not exist in lmanufpaymentcodes table.")

                        iRecords += Me.AddUpdateSSRepCdMtGrpPmtCdMap(iRepID, strMtGrpCode, iPmtID, iMapID)

                        '**********************************
                        'Reset loop variable
                        '**********************************
                        i += 1 : iRepID = 0 : iPmtID = 0 : iMapID = 0
                        strRepCode = "" : strMtGrpCode = "" : strPmtCode = ""
                        If Not IsNothing(objSheet.range("A" & i).value) Then strRepCode = objSheet.range("A" & i).value.ToString.Trim
                        If Not IsNothing(objSheet.range("B" & i).value) Then strMtGrpCode = objSheet.range("B" & i).value.ToString.Trim
                        If Not IsNothing(objSheet.range("C" & i).value) Then strPmtCode = objSheet.range("C" & i).value.ToString.Trim
                        '**********************************
                    End While
                End If

                Return iRecords
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(objSheet) Then
                    objSheet = Nothing
                    Generic.NAR(objSheet)
                End If
                If Not IsNothing(objBook) Then
                    objBook.Close()
                    objBook = Nothing
                    Generic.NAR(objBook)
                End If
                If Not IsNothing(objExcel) Then
                    objExcel.Quit()
                    objExcel = Nothing
                    Generic.NAR(objExcel)
                End If

                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function

        '******************************************************************
        Private Function GetSSCellRepID(ByVal strRepCode As String) As Integer
            Dim strSql As String = ""

            Try
                strSql = "SELECT Repair_ID FROM lrepaircodes WHERE Manuf_ID = " & Me.SamSung_Manuf_ID & " AND Prod_ID = 2 AND Repair_SDesc = '" & strRepCode & "' "
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Private Function GetSSWrtyPaymentCodeID(ByVal strPaymentCode As String) As Integer
            Dim strSql As String = ""

            Try
                strSql = "SELECT PC_ID FROM lmanufpaymentcodes WHERE Manuf_ID = " & Me.SamSung_Manuf_ID & " AND PC_Code = '" & strPaymentCode & "' "
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Private Function GetSSRepCdMtGrpPmtCdMapID(ByVal iRepID As Integer, _
                                                   ByVal strMaterialGroup As String) As Integer
            Dim strSql As String = ""

            Try
                strSql = "SELECT SWM_ID FROM tsamsungwrtymap " & Environment.NewLine
                strSql &= "WHERE Repair_ID = " & iRepID & Environment.NewLine
                strSql &= "AND MatGrp_WrtyClaim = '" & strMaterialGroup & "' " & Environment.NewLine
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Private Function AddUpdateSSRepCdMtGrpPmtCdMap(ByVal iRepID As Integer, _
                                                       ByVal strMaterialGroup As String, _
                                                       ByVal iPaymentCodeID As Integer, _
                                                       ByVal iSSWrtyMapID As Integer) As Integer
            Dim strSql As String = ""

            Try
                If iSSWrtyMapID > 0 Then
                    'Update
                    strSql = "UPDATE tsamsungwrtymap SET PC_ID = " & iPaymentCodeID & Environment.NewLine
                    strSql &= "WHERE SWM_ID = " & iSSWrtyMapID & Environment.NewLine
                Else
                    'Insert
                    strSql = "INSERT INTO tsamsungwrtymap (Repair_ID, MatGrp_WrtyClaim, PC_ID " & Environment.NewLine
                    strSql &= ") VALUES ( " & Environment.NewLine
                    strSql &= iRepID & ", '" & strMaterialGroup & "', " & iPaymentCodeID & Environment.NewLine
                    strSql &= ") ; " & Environment.NewLine
                End If

                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************

    End Class
End Namespace