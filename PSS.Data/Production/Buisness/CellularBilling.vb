Option Explicit On 

Imports System.Data.OleDb

Namespace Buisness
    Public Class CellularBilling
        'Private _objMisc As New Production.Misc()

        'Public Function IsCellularDevice(ByVal strDeviceSN As String) As Boolean
        '    Dim strSql As String
        '    Dim dt As DataTable
        '    Dim bIsCellularDevice As Boolean = False
        '    Dim iCnt As Integer
        '    Dim sf As New StackFrame(0)

        '    Try
        '        strSql = "SELECT COUNT(*) AS Cnt " & Environment.NewLine
        '        strSql &= "FROM tdevice A " & Environment.NewLine
        '        strSql &= "INNER JOIN tmodel B ON B.model_id = A.model_id " & Environment.NewLine
        '        strSql &= "WHERE A.Device_SN = '" & strDeviceSN & "' " & Environment.NewLine
        '        strSql &= "AND B.prod_id = 2"

        '        dt = Me._objMisc.GetDataTable(strSql)

        '        If dt.Rows.Count = 1 Then
        '            If Not IsDBNull(dt.Rows(0)("Cnt")) Then
        '                iCnt = CInt(dt.Rows(0)("Cnt"))

        '                If iCnt > 0 Then bIsCellularDevice = True
        '            End If
        '        End If

        '        Return bIsCellularDevice
        '    Catch ex As Exception
        '        Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
        '    Finally
        '        If Not IsNothing(dt) Then
        '            dt.Dispose()
        '            dt = Nothing
        '        End If
        '    End Try
        'End Function

        'Public Function GetRefurbCompleteCount(ByVal iTechID As Integer) As String
        '    Dim strRefurbCompleteCnt As String = ""
        '    Dim strSQL As String
        '    Dim strCount As String = ""
        '    Dim sf As New StackFrame(0)

        '    Try
        '        strRefurbCompleteCnt = "Refurbs Completed " & Format(Now(), "MM/dd/yyyy") & ": "

        '        strSQL = "SELECT COUNT(*) " & Environment.NewLine
        '        strSQL &= "FROM tcellopt " & Environment.NewLine
        '        strSQL &= "WHERE Cellopt_RefurbCompleteWorkDt = '" & Format(Now, "yyyy-MM-dd") & "' " & Environment.NewLine
        '        strSQL &= "AND cellopt_refurbcompleteuserid = " & iTechID.ToString

        '        strCount = Me._objMisc.GetSingletonString(strSQL)

        '        If IsNumeric(strCount) Then
        '            strRefurbCompleteCnt &= Format(CInt(strCount), "#,##0")
        '        Else
        '            strRefurbCompleteCnt &= "0"
        '        End If

        '        Return strRefurbCompleteCnt
        '    Catch ex As Exception
        '        Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
        '    End Try
        'End Function

    End Class
End Namespace
