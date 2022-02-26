Imports System
Imports System.Data
Imports eInfoDesigns.dbProvider.MySqlClient
Imports PSS.Data

Namespace Production

    Public Class tusers

        Inherits TableBase

        ''//----------------------------------------------------------------------------------------------------
        ''// Class Constructor (zero arguments)
        ''// Overloaded:	No
        ''//----------------------------------------------------------------------------------------------------

        'Public Sub New()
        '    '--- Set up the select statement
        '    Dim strSql As String = "SELECT * FROM security.tusers"
        '    '--- Set up the Connection
        '    _conn = Connection.GetConnection("security")
        '    '--- Set up the data adapter
        '    _da = GetDataAdapter(strSql, _conn)
        '    '//--- Destroy object

        '    '//Craig Haney
        '    _conn.Close()
        '    _conn.Dispose()
        '    '//Craig Haney

        '    _conn = Nothing
        'End Sub

        Public Shared Function GetUserList(ByVal strusername As String) As DataTable
            Dim strSql As String
            Dim objDataProc As DBQuery.DataProc
            Dim dt As DataTable
            Dim row As DataRow
            Dim strDecriptMsg As String = ""
            Dim strDecryptedPW As String = ""
            Dim iPwEncryDecryFlag As Integer = 0


            Try
                strSql = "SELECT A.*, IFNULL(B.group_desc, '') AS 'Group Description' " & Environment.NewLine
                strSql &= "FROM security.tusers A " & Environment.NewLine
                strSql &= "LEFT JOIN production.lgroups B ON B.group_id = A.group_id " & Environment.NewLine
                If LCase(strusername) <> "pss admin" Then strSql &= "WHERE AdminUser = 0 " & Environment.NewLine
                strSql &= "ORDER BY user_fullname"

                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                dt = objDataProc.GetDataTable(strSql)
                For Each row In dt.Rows
                    iPwEncryDecryFlag = row("PwEncryDecryFlag")
                    If iPwEncryDecryFlag = 1 Then
                        strDecryptedPW = EncDec.Rijndael.Decrypt(row("user_pass"), strDecriptMsg)
                        row.BeginEdit() : row("user_pass") = strDecryptedPW : row.AcceptChanges()
                    End If
                Next

                Return dt

            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function GetCellTechList() As DataTable
             Dim strSql As String = "SELECT * FROM security.tusers WHERE tech_id > 0 ORDER BY tech_id"
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

        Public Shared Function InsertUser(ByVal vName As String, _
                                            ByVal vPass As String, _
                                            ByVal vFName As String, _
                                            ByVal strEmpNo As String, _
                                            ByVal iTech_ID As Integer, _
                                            ByVal iQCStamp As Integer, _
                                            ByVal vShift As Integer, _
                                            ByVal vInactive As Integer, _
                                            ByVal iExempt As Integer, _
                                            ByVal iOT As Integer, _
                                            ByVal iRefurber As Integer, _
                                            ByVal iLockout As Integer, _
                                            ByRef iUserID As Integer) As Boolean
            Dim strSQL As String
            Dim objDataProc As DBQuery.DataProc
            Dim strEncryptedPW As String = ""
            Dim strEncDecErr As String = ""

            Try
                InsertUser = False

                strEncryptedPW = EncDec.Rijndael.Encrypt(vPass, strEncDecErr)
                If strEncDecErr.Trim.Length = 0 Then
                    vPass = strEncryptedPW.Replace("'", "''")
                Else
                    Throw New Exception("Function InsertUser: password ecncryption error - " & strEncDecErr)
                End If
                strSQL = "INSERT INTO security.tusers (" & Environment.NewLine
                strSQL += "user_Name, " & Environment.NewLine
                strSQL += "user_pass, " & Environment.NewLine
                strSQL += "user_fullname, " & Environment.NewLine
                strSQL += "EmployeeNo, " & Environment.NewLine
                strSQL += "tech_id, " & Environment.NewLine
                strSQL += "shift_id, " & Environment.NewLine
                strSQL += "user_Inactive, " & Environment.NewLine
                strSQL += "is_user_refurber, " & Environment.NewLine
                strSQL += "ExemptFlag, " & Environment.NewLine
                strSQL += "OTFlag, " & Environment.NewLine
                strSQL += "QCStamp, " & Environment.NewLine
                strSQL += "AccountLockOut_PwAttempted_id, " & Environment.NewLine
                strSQL += "PwEncryDecryFlag" & Environment.NewLine

                strSQL += ") VALUES (" & Environment.NewLine

                strSQL += "'" & vName & "', " & Environment.NewLine
                strSQL += "'" & vPass & "', " & Environment.NewLine
                strSQL += "'" & vFName & "', " & Environment.NewLine
                strSQL += "'" & strEmpNo & "', " & Environment.NewLine
                If iTech_ID = 0 Then
                    strSQL += "NULL, " & Environment.NewLine
                Else
                    strSQL += iTech_ID & ", " & Environment.NewLine
                End If

                If vShift = 0 Then
                    strSQL += "NULL, " & Environment.NewLine
                Else
                    strSQL += vShift & ", " & Environment.NewLine
                End If

                strSQL += vInactive & ", " & Environment.NewLine
                strSQL += iRefurber & ", " & Environment.NewLine
                strSQL += iExempt & ", " & Environment.NewLine
                strSQL += iOT & ", " & Environment.NewLine

                If iQCStamp = 0 Then
                    strSQL += "NULL, " & Environment.NewLine
                Else
                    strSQL += iQCStamp & "," & Environment.NewLine
                End If
                strSQL += iLockout & ",1" & Environment.NewLine

                strSQL += ");"
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                objDataProc.ExecuteNonQuery(strSQL)

                strSQL = "SELECT LAST_INSERT_ID();"
                iUserID = objDataProc.GetIntValue(strSQL)

                InsertUser = True
                Return True
            Catch ex As Exception
                InsertUser = False
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function EditUser(ByVal userID As String, _
                                        ByVal vName As String, _
                                        ByVal vPass As String, _
                                        ByVal vFName As String, _
                                        ByVal strEmpNo As String, _
                                        ByVal iTech_ID As Integer, _
                                        ByVal iQCStamp As Integer, _
                                        ByVal vShift As Integer, _
                                        ByVal iGroup As Integer, _
                                        ByVal vInactive As Integer, _
                                        ByVal iExempt As Integer, _
                                        ByVal iClearMachine As Integer, _
                                        ByVal iOT As Integer, _
                                        ByVal iRefurber As Integer, _
                                        ByVal iLockout As Integer) As Boolean

            Dim strSQL As String = ""
            Dim objDataProc As DBQuery.DataProc

            Dim strEncryptedPW As String = ""
            Dim strEncDecErr As String = ""

            Try

                EditUser = False

                strEncryptedPW = EncDec.Rijndael.Encrypt(vPass, strEncDecErr)
                If strEncDecErr.Trim.Length = 0 Then
                    vPass = strEncryptedPW.Replace("'", "''")
                Else
                    Throw New Exception("Function EditUser: password ecncryption error - " & strEncDecErr)
                End If

                strSQL = "UPDATE security.tusers set " & Environment.NewLine
                strSQL += "user_name = '" & vName & "', " & Environment.NewLine
                strSQL += "user_pass = '" & vPass & "', " & Environment.NewLine
                strSQL += "user_fullname = '" & vFName & "', " & Environment.NewLine
                strSQL += "EmployeeNo = '" & strEmpNo & "', " & Environment.NewLine

                If vShift = 0 Then
                    strSQL += "shift_id = NULL, " & Environment.NewLine
                Else
                    strSQL += "shift_id = " & vShift & ", " & Environment.NewLine
                End If

                strSQL &= "group_id = " & iGroup.ToString & ", " & Environment.NewLine

                strSQL += "user_Inactive = " & vInactive & ", " & Environment.NewLine
                strSQL += "is_user_refurber = " & iRefurber & ", " & Environment.NewLine
                strSQL += "ExemptFlag = " & iExempt & ", " & Environment.NewLine
                strSQL += "OTFlag = " & iOT & ", " & Environment.NewLine

                If iClearMachine = 1 Then       'Clear the machine
                    strSQL += "LastLogonMachine = NULL, " & Environment.NewLine
                End If

                If iTech_ID = 0 Then
                    strSQL += "tech_id = NULL, " & Environment.NewLine
                Else
                    strSQL += "tech_id = " & iTech_ID & ", " & Environment.NewLine
                End If

                'Lockout
                strSQL += "AccountLockOut_PwAttempted_id = " & iLockout & ", " & Environment.NewLine

                'PwEncryDecryFlag 
                strSQL += "PwEncryDecryFlag =1, " & Environment.NewLine

                If iQCStamp = 0 Then
                    strSQL += "QCStamp = NULL " & Environment.NewLine
                Else
                    strSQL += "QCStamp = " & iQCStamp & Environment.NewLine
                End If



                strSQL += " WHERE user_ID = " & userID

                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                objDataProc.ExecuteNonQuery(strSQL)
                EditUser = True
                Return True
            Catch ex As Exception
                EditUser = False
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function DeleteUser(ByVal userID As String) As Boolean
            Dim strSQL As String = "DELETE FROM security.tusers WHERE user_ID = " & userID
            Dim objDataProc As DBQuery.DataProc

            Try
                DeleteUser = False
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                objDataProc.ExecuteNonQuery(strSQL)
                DeleteUser = True
                Return True
            Catch ex As Exception
                DeleteUser = False
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

    End Class
End Namespace

