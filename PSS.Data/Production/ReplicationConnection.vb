Imports EncDec

Public Class ReplicationConnection
    Public Sub New()

    End Sub

    Public Shared Function GetReplicationConnection() As DBQuery.DataProc
        Dim strSQL As String, strErr As String = String.Empty, strPW As String = String.Empty
        Dim strConnectionInfo As String = String.Empty
        Dim objDP As DBQuery.DataProc

        Try
            objDP = New DBQuery.DataProc(ConfigFile.GetConnectionInfo())

            strSQL = "SELECT CurrentRepConnection" & Environment.NewLine
            strSQL &= "FROM security.Replication" & Environment.NewLine
            strSQL &= "LIMIT 1"

            strConnectionInfo = objDP.GetSingletonString(strSQL)

            If strConnectionInfo.Length > 0 Then
                'Parse the string for connection parameters
                Dim iIndex As Integer, i As Integer = -1
                Dim strComponent() As String = {"server", "database", "user id", "password"}
                Dim strInfo() As String = strConnectionInfo.Split(";")
                Dim strParameters(3) As String
                Dim strComp As String, strSub As String, strInf

                For Each strComp In strComponent
                    Dim strThisComp As String = String.Format("{0}=", strComp)

                    For Each strInf In strInfo
                        If strInf.ToLower().IndexOf(strThisComp) > -1 Then
                            iIndex = strThisComp.IndexOf("=") + 1
                            strSub = strInf.Substring(iIndex)

                            i = i + 1
                            strParameters(i) = strSub

                            If strComp.ToLower().IndexOf("password") > -1 Then
                                'Decrypt the password
                                Dim strDec As String = EncDec.Rijndael.Decrypt(strParameters(i), strErr)

                                If strErr.Length > 0 Then Throw New Exception(String.Format("An error occurred while decrypting the replication connection password: {0}", strErr))

                                strParameters(i) = strDec
                            End If

                            Exit For
                        End If
                    Next
                Next

                Return New DBQuery.DataProc(strParameters(0), strParameters(1), strParameters(2), strParameters(3))
            Else
                Throw New Exception("Invalid replication connection string.")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
