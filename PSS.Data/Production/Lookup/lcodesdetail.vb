Imports System
Imports System.Data
Imports eInfoDesigns.dbProvider.MySqlClient
Imports PSS.Data

Namespace Production

    Public Class lcodesdetail
        Inherits TableBase

        ''//----------------------------------------------------------------------------------------------------
        ''// Class Constructor (zero arguments)
        ''// Overloaded:	No
        ''//----------------------------------------------------------------------------------------------------
        'Public Sub New()
        '    '--- Set up the select statement
        '    Dim strSql As String = "SELECT * FROM lcodesdetail"
        '    '--- Set up the Connection
        '    _conn = Connection.GetConnection
        '    '_conn = Connection.GetConnection(, 1)   'Pass 1 for replication database connectivity.
        '    '--- Set up the data adapter
        '    _da = GetDataAdapter(strSql, _conn)
        '    '//--- Destroy object

        '    '//Craig Haney
        '    _conn.Close()
        '    _conn.Dispose()
        '    '//Craig Haney

        '    _conn = Nothing
        'End Sub

        Public Shared Function GetCodes(ByVal txtType As Int32, ByVal intManuf As Int32) As DataTable
            Dim strSql As String = "SELECT lcodesmaster.Mcode_Desc, lcodesdetail.* from (lcodesmaster INNER JOIN lcodesdetail ON lcodesmaster.Mcode_ID = lcodesdetail.Mcode_ID) WHERE lcodesdetail.Mcode_ID=" & txtType & " AND lcodesdetail.Manuf_ID = " & intManuf & " AND lcodesdetail.Dcode_Inactive = 0 order by Dcode_Ldesc"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function GetCodesCELL(ByVal txtType As Int32, ByVal intManuf As Int32) As DataTable
            Dim strSql As String = "SELECT lcodesmaster.Mcode_Desc, lcodesdetail.* from (lcodesmaster INNER JOIN lcodesdetail ON lcodesmaster.Mcode_ID = lcodesdetail.Mcode_ID) WHERE lcodesdetail.Mcode_ID=" & txtType & " AND lcodesdetail.Manuf_ID = " & intManuf & " AND lcodesdetail.prod_id= 2 AND lcodesdetail.Dcode_Inactive = 0 order by Dcode_Ldesc"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function GetCodesSMALL(ByVal txtType As Int32, ByVal intManuf As Int32) As DataTable
            Dim strSql As String = "SELECT lcodesmaster.Mcode_Desc, lcodesdetail.* from (lcodesmaster INNER JOIN lcodesdetail ON lcodesmaster.Mcode_ID = lcodesdetail.Mcode_ID) WHERE lcodesdetail.Mcode_ID=" & txtType & " AND lcodesdetail.Manuf_ID = " & intManuf & " AND (lcodesdetail.Dcode_PriorityLvl = 1 or lcodesdetail.Dcode_PriorityLvl = 2) AND lcodesdetail.Dcode_Inactive = 0 order by Dcode_Ldesc"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function GetCodesPRIORITY(ByVal txtType As Int32, ByVal intManuf As Int32) As DataTable
           Dim strSql As String = "SELECT lcodesmaster.Mcode_Desc, lcodesdetail.* from (lcodesmaster INNER JOIN lcodesdetail ON lcodesmaster.Mcode_ID = lcodesdetail.Mcode_ID) WHERE lcodesdetail.Mcode_ID=" & txtType & " AND lcodesdetail.Manuf_ID = " & intManuf & " AND lcodesdetail.Dcode_PriorityLvl = 2 AND lcodesdetail.Dcode_Inactive = 0 order by Dcode_Ldesc"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function GetRowByDCode(ByVal ID As Int32) As DataRow
           Dim strSql As String = "SELECT * FROM lcodesdetail WHERE Dcode_ID = " & ID & " AND lcodesdetail.Dcode_Inactive = 0;"
            Dim objDataProc As DBQuery.DataProc
            Dim dt As New DataTable()

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                dt = objDataProc.GetDataTable(strSql)

                If (dt.Rows.Count > 0) Then Return dt.Rows(0) Else Return Nothing
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        Public Shared Function GetAPCvalue(ByVal vAPCID As Int32) As DataRow
            Dim strSql As String = "SELECT * FROM lcodesdetail WHERE Dcode_ID = " & vAPCID & " AND lcodesdetail.Dcode_Inactive = 0;"
            Dim objDataProc As DBQuery.DataProc
            Dim dt As New DataTable()

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                dt = objDataProc.GetDataTable(strSql)

                If (dt.Rows.Count > 0) Then Return dt.Rows(0) Else Return Nothing
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        Public Shared Function GetvID(ByVal strValue As String, ByVal vMCode As Integer) As DataRow
            Dim strSql As String = "SELECT * FROM lcodesdetail WHERE Dcode_LDesc = '" & strValue & "' AND MCode_ID = " & vMCode & " AND lcodesdetail.Dcode_Inactive = 0"
            Dim objDataProc As DBQuery.DataProc
            Dim dt As New DataTable()

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                dt = objDataProc.GetDataTable(strSql)

                If (dt.Rows.Count > 0) Then Return dt.Rows(0) Else Return Nothing
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        Public Shared Function GetRepairStatusID(ByVal strValue As String, ByVal vMCode As Integer) As DataRow
            Dim strSql As String = "SELECT * FROM lcodesdetail WHERE Dcode_SDesc = '" & strValue & "' AND MCode_ID = " & vMCode & " AND lcodesdetail.Dcode_Inactive = 0"
            Dim objDataProc As DBQuery.DataProc
            Dim dt As New DataTable()

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                dt = objDataProc.GetDataTable(strSql)

                If (dt.Rows.Count > 0) Then Return dt.Rows(0) Else Return Nothing
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        Public Shared Function GetvString(ByVal intValue As Int32) As DataRow
            Dim strSql As String = "SELECT * FROM lcodesdetail WHERE Dcode_ID = " & intValue & " AND lcodesdetail.Dcode_Inactive = 0"
            Dim objDataProc As DBQuery.DataProc
            Dim dt As New DataTable()

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                dt = objDataProc.GetDataTable(strSql)

                If (dt.Rows.Count > 0) Then Return dt.Rows(0) Else Return Nothing
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function


        Public Shared Function GetChargeCust(ByVal intFC As Int32) As DataRow
            Dim strSql As String = "SELECT * FROM lcodesdetail WHERE Dcode_ID = '" & intFC & "' AND lcodesdetail.Dcode_Inactive = 0;"
            Dim objDataProc As DBQuery.DataProc
            Dim dt As New DataTable()

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                dt = objDataProc.GetDataTable(strSql)

                If (dt.Rows.Count > 0) Then Return dt.Rows(0) Else Return Nothing
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

    End Class

End Namespace