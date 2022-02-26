'//------------------------------------------------------------------------------------------------------------
'// Filename:	TableBase.vb
'// Author:		Tony Pearson
'// Date:		2/27/2003
'// Purpose:   Table Functions. 
'//------------------------------------------------------------------------------------------------------------

'//--------------------------------------------------------------------------------------------------------
'// Declare all the NameSpaces to be referenced
'//--------------------------------------------------------------------------------------------------------
Imports System
Imports System.Data
Imports eInfoDesigns.dbProvider.MySqlClient

Namespace Production

    '//--------------------------------------------------------------------------------------------------------------
    '// Public Class
    '// Purpose:	Base Class for all table objects
    '//--------------------------------------------------------------------------------------------------------------
    Public Class TableBase

        '//------------------------------------------------------------------------------------------------------------
        '// Public Method
        '// Overloaded:		No
        '// Parameters:	    None
        '// Return Value:	DataSet
        '// Purpose:		    Retrieves all company info.
        '//------------------------------------------------------------------------------------------------------------
        Public Function GetData() As DataSet
            Dim strSql As String = "SELECT * FROM " & Me.GetType.Name.ToString
            Dim ds As New DataSet()
            Dim dt As New DataTable()
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                dt = objDataProc.GetDataTable(strSql)
                dt.TableName = Me.GetType.Name.ToString
                ds.Tables.Add(dt)
                Return ds
            Catch ex As MySqlException
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Function idTransaction(ByVal SQL As String) As Int32
            Dim strTableName As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                idTransaction = 0
                strTableName = Me.GetType.Name.ToString

                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.idTransaction(SQL, strTableName)

            Catch ex As Exception
                idTransaction = 0
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Function idTransDev(ByVal SQL As String) As Int32
            Dim strTableName As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                idTransDev = 0
                strTableName = Me.GetType.Name.ToString

                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.idTransaction(SQL, strTableName)

            Catch ex As Exception
                idTransDev = 0
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

    End Class
End Namespace