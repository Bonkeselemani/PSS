Imports System
Imports System.Data
Imports eInfoDesigns.dbProvider.MySqlClient
Imports PSS.Data

Namespace Production

    Public Class Generic

        Inherits TableBase

        '//----------------------------------------------------------------------------------------------------
        '// Class Constructor (zero arguments)
        '// Overloaded:	No
        '//----------------------------------------------------------------------------------------------------

        Public Shared Function GenericSelect(ByVal sSQL As String) As DataTable
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(sSQL)

            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function GenericInsert(ByVal sSQL As String) As Boolean
            Dim objDataProc As DBQuery.DataProc

            Try
                GenericInsert = False
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                objDataProc.ExecuteNonQuery(sSQL)
                GenericInsert = True
                Return True
            Catch ex As Exception
                GenericInsert = False
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function


        Public Function idTrans(ByVal SQL As String, ByVal tName As String) As Int32
            Dim objDataProc As DBQuery.DataProc

            Try
                idTrans = False
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.idTransaction(SQL, tName)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

    End Class

End Namespace



