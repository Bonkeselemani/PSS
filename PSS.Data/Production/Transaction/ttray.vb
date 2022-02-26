Imports System
Imports System.Data
Imports eInfoDesigns.dbProvider.MySqlClient
Imports PSS.Data

Namespace Production

	Public Class ttray
        Inherits TableBase

        ''//----------------------------------------------------------------------------------------------------
        '      '// Class Constructor ()
        ''// Overloaded:	No
        ''//----------------------------------------------------------------------------------------------------
        '      Public Sub New()
        '          '--- Set up the select statement
        '          Dim strSql As String =  "SELECT * FROM ttray"

        '          '--- Set up the Connection
        '          _conn = Connection.GetConnection
        '          '--- Set up the data adapter
        '          _da = GetDataAdapter(strSql, _conn)
        '          '//--- Destroy object

        '          '//Craig Haney
        '          _conn.Close()
        '          _conn.Dispose()
        '          '//Craig Haney

        '          _conn = Nothing
        '      End Sub

        Public Shared Function GetDataRow(ByVal ID As Int32) As DataRow
            Dim strSql As String = "SELECT * FROM ttray WHERE tray_Id = " & ID & ";"
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