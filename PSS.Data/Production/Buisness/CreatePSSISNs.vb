Imports System.Windows.Forms

Namespace Buisness
    Public Class CreatePSSISNs
        Private _objDataProc As DBQuery.DataProc

        Public Sub New()
            Try
                Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "PSS.Data.Buisness.CreatePSSISNs ctor", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Public Function IsLocked() As Boolean
            Dim strSQL As String

            Try
                strSQL = "SELECT Locked" & Environment.NewLine
                strSQL &= "FROM production.PSSISNCreationLock"

                Return IIf(Me._objDataProc.GetIntValue(strSQL) = 0, False, True)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetLockingUser() As String
            Dim strSQL As String

            Try
                strSQL = "SELECT UserName" & Environment.NewLine
                strSQL &= "FROM production.PSSISNCreationLock"

                Return Me._objDataProc.GetSingletonString(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Sub Lock(ByVal strUser As String)
            Dim strSQL As String

            Try
                strSQL = "SELECT COUNT(*)" & Environment.NewLine
                strSQL &= "FROM production.PSSISNCreationLock"

                If Me._objDataProc.GetIntValue(strSQL) = 0 Then
                    strSQL = "INSERT INTO production.PSSISNCreationLock (Locked, UserName)" & Environment.NewLine
                    strSQL &= String.Format("VALUES (1, '{0}')", strUser)
                Else
                    strSQL = "UPDATE production.PSSISNCreationLock" & Environment.NewLine
                    strSQL &= String.Format("SET Locked = 1, UserName = '{0}'", strUser)
                End If

                Me._objDataProc.ExecuteNonQuery(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub Unlock()
            Dim strSQL As String

            Try
                strSQL = "UPDATE production.PSSISNCreationLock" & Environment.NewLine
                strSQL &= "SET Locked = 0, UserName = ''"

                Me._objDataProc.ExecuteNonQuery(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Function GetServerDate() As DateTime
            Dim strSQL As String

            Try
                strSQL = "SELECT DATE_FORMAT(NOW(), '%Y-%m-%d')"

                Return Convert.ToDateTime(Me._objDataProc.GetSingletonString(strSQL))
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function CheckSNs(ByVal iQuantity As Integer, ByRef iLast As Integer) As String
            Dim strSQL As String

            Try
                Dim strNow As String = String.Format("{0:yyMMdd}", GetServerDate())

                If strNow.Length > 0 Then
                    Dim iStart As Integer = 1
                    Dim strMax As String = GetMostRecentlyCreatedSN()

                    If strMax.Length > 0 And Not strMax.Equals("N/A") Then
                        Dim strHex = strMax.Substring(strMax.Length - 3)

                        iStart = ConvertFromHexToInt(strHex) + 1
                        iLast = ConvertFromHexToInt(strHex)
                    End If

                    If iStart > 4095 Then 'i.e., > xFFF
                        Throw New Exception("The maximum number of serial numbers (4095) allowed for today has already been created.")
                    ElseIf iStart + iQuantity - 1 > 4095 Then
                        Throw New Exception(String.Format("The maximum number of serial numbers you can create today is {0}.", 4095 - iStart + 1))
                    End If
                End If

                Return strNow
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function ConvertFromHexToInt(ByVal strHex As String)
            Try
                Return Int32.Parse(strHex, System.Globalization.NumberStyles.HexNumber)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Sub SaveSN(ByVal strSN As String, ByVal iUserID As Integer)
            Dim strSQL As String

            Try
                If SNExists(strSN) Then
                    strSQL = "UPDATE production.PSSISN" & Environment.NewLine
                    strSQL &= String.Format("SET LastReprintDate = NOW(), LastReprintUserID = {0}", iUserID)
                Else
                    strSQL = "INSERT INTO production.PSSISN (PSSISN, CreationDate, UserID)" & Environment.NewLine
                    strSQL &= String.Format("VALUES ('{0}', NOW(), {1})", strSN, iUserID)
                End If

                Me._objDataProc.ExecuteNonQuery(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Function SNExists(ByVal strSN As String)
            Dim strSQL As String

            Try
                strSQL = "SELECT COUNT(*)"
                strSQL &= "FROM production.PSSISN" & Environment.NewLine
                strSQL &= String.Format("WHERE PSSISN = '{0}'", strSN)

                Return IIf(Me._objDataProc.GetIntValue(strSQL) > 0, True, False)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Protected Overrides Sub Finalize()
            Me._objDataProc = Nothing
            MyBase.Finalize()
        End Sub

        Public Function GetMostRecentlyCreatedSN() As String
            Dim strSQL As String

            Try
                strSQL = "SELECT IFNULL(MAX(PSSISN), 'N/A')" & Environment.NewLine
                strSQL &= "FROM production.PSSISN" & Environment.NewLine
                strSQL &= String.Format("WHERE PSSISN LIKE 'P{0}%'", String.Format("{0:yyMMdd}", GetServerDate()))

                Return Me._objDataProc.GetSingletonString(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetTodaysCreatedSNsCount() As Integer
            Dim strSQL As String

            Try
                strSQL = "SELECT COUNT(*)" & Environment.NewLine
                strSQL &= "FROM production.PSSISN" & Environment.NewLine
                strSQL &= String.Format("WHERE PSSISN LIKE 'P{0}%'", String.Format("{0:yyMMdd}", GetServerDate()))

                Return Me._objDataProc.GetIntValue(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class
End Namespace
