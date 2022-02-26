Option Explicit On 

Imports System
Imports System.data
Imports MySql.Data

Namespace Buisness.TracFoneFulfillmentKit
    Public Class mySQL5
        Private _strDB As String = "Production"
        Private _strUser As String = "apuser"
        Private _strPW As String = "Asd@321"
        Private _strHost As String = "172.16.25.25" '.221" '.25"
        Private _strConn As String = "Database=" & Me._strDB & ";Data Source=" & Me._strHost & ";User Id=" & Me._strUser & ";Password=" & Me._strPW

        Public ReadOnly Property getConnectionString() As String
            Get
                Return _strConn
            End Get
        End Property

        Public Function GetDataTable(ByVal strSQL As String) As DataTable
            Dim dt As New DataTable()

            Try
                Dim conn As New MySql.Data.MySqlClient.MySqlConnection(Me._strConn)
                Dim adapter As New MySql.Data.MySqlClient.MySqlDataAdapter()
                adapter.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)
                adapter.Fill(dt)
                conn.Close() : adapter = Nothing

                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function ExecuteNonQuery(ByVal strSQL As String) As Integer
            Dim i As Integer = 0

            Try
                Dim conn As New MySql.Data.MySqlClient.MySqlConnection(Me._strConn)
                Dim myCommand As New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)
                myCommand.Connection.Open()
                i = myCommand.ExecuteNonQuery()
                conn.Close()

                Return i

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetLastInsertedPrimaryKey(ByVal strSQL As String, ByVal strTable As String) As Integer
            Dim conn As MySql.Data.MySqlClient.MySqlConnection = New MySql.Data.MySqlClient.MySqlConnection(Me._strConn)
            Dim oTrans As MySql.Data.MySqlClient.MySqlTransaction = Nothing
            Dim iReturn As Integer = 0
            Dim _cmd1 As MySql.Data.MySqlClient.MySqlCommand = Nothing
            Dim _rdr As MySql.Data.MySqlClient.MySqlDataReader = Nothing
            Try
                conn.Open()
                _cmd1 = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)
                oTrans = CType(conn.BeginTransaction(IsolationLevel.Serializable), MySql.Data.MySqlClient.MySqlTransaction)
                _cmd1.Transaction = oTrans
                _cmd1.ExecuteNonQuery()

                strSQL = "SELECT LAST_INSERT_ID() " & Environment.NewLine
                strSQL += "FROM " & strTable

                _cmd1.CommandText = strSQL
                _cmd1.Connection = conn
                _cmd1.Transaction = oTrans
                _rdr = CType(_cmd1.ExecuteReader(), MySql.Data.MySqlClient.MySqlDataReader)
                While _rdr.Read()
                    iReturn = Convert.ToInt32(_rdr(0).ToString())
                    If iReturn > 0 Then Exit While
                End While

                Try
                    oTrans.Commit()
                Catch ex As Exception
                End Try

            Catch ex As MySql.Data.MySqlClient.MySqlException
                'oTrans.Rollback()
                iReturn = 0
                Throw ex
            Finally
                Try
                    _cmd1.Dispose() : _cmd1 = Nothing
                Catch ex As Exception
                End Try
                Try
                    _rdr.Close() : _rdr = Nothing
                Catch ex As Exception
                End Try
                Try
                    conn.Close() : conn.Dispose() : conn = Nothing
                Catch ex As Exception
                End Try
            End Try

            Return iReturn

        End Function


    End Class
End Namespace