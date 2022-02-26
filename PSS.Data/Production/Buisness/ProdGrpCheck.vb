Option Explicit On 

Imports System.Data.OleDb

Namespace Buisness
    Public Class ProdGrpCheck
        ' Created by Yuri 21-Jun-2007.
        ' Check the product group ID in the tmodel table to see if it's NULL.
        ' If it is, then substitute the Model_Flat value for it.  If the substitution fails,  
        ' discontinue data processing/display in the calling routine.
        Private objMisc As Production.Misc
        Private Const strErrMsg As String = "An error occurred while updating the product group ID.  Data processing and display will be terminated."
        Private Const strErrTitle As String = "Update Error"

#Region "CheckProdGrpID"

        Public Function CheckProdGrpID(ByVal strDeviceSN As String) As Boolean
            Try
                Return RunCheckProdGrpID(strDeviceSN, Constants.vbString)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function CheckProdGrpID(ByVal iModelID As Integer) As Boolean
            Try
                Return RunCheckProdGrpID(iModelID, Constants.vbInteger)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function RunCheckProdGrpID(ByVal objParam As Object, ByVal conType As Integer) As Boolean
            Dim booCheckOK As Boolean = True
            Dim iProdGrpCheckRet As Integer = 1
            Dim iModelID As Integer
            Dim strDeviceSN As String

            Try
                If conType = Constants.vbInteger Then
                    iModelID = CInt(objParam)

                    If IsProdGrpIDNull(iModelID) Then
                        iProdGrpCheckRet = SubstituteNullProdGrpID(iModelID)
                    End If
                Else
                    strDeviceSN = CStr(objParam)

                    If IsProdGrpIDNull(strDeviceSN) Then
                        iProdGrpCheckRet = SubstituteNullProdGrpID(strDeviceSN)
                    End If
                End If

                If iProdGrpCheckRet = 0 Then
                    MsgBox(Me.strErrMsg, MsgBoxStyle.OKOnly, Me.strErrTitle)
                    booCheckOK = False
                End If

                Return booCheckOK
            Catch ex As Exception
                Throw ex
            End Try
        End Function

#End Region ' CheckProdGrpID

#Region "IsProdGrpIDNull"
            ' Functions for determining whether ProdGrp_ID is NULL.

        Private Function IsProdGrpIDNull(ByVal strDeviceSN As String) As Boolean
            Dim strSql As String = ""

            Try
                strSql &= "SELECT CASE WHEN ProdGrp_ID IS NULL THEN 1 ELSE 0 END AS ProdGrpIsNull " & Environment.NewLine
                strSql &= "FROM tmodel A " & Environment.NewLine
                strSql &= "INNER JOIN tdevice B ON B.Model_ID = A.Model_ID " & Environment.NewLine
                strSql &= "WHERE B.Device_SN = '" & strDeviceSN & "';"

                Return GetIsProdGrpIDNull(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Private Function IsProdGrpIDNull(ByVal iModelID As Integer) As Boolean
            Dim strSql As String = ""

            Try
                strSql &= "SELECT CASE WHEN ProdGrp_ID IS NULL THEN 1 ELSE 0 END AS ProdGrpIsNull " & Environment.NewLine
                strSql &= "FROM tmodel A " & Environment.NewLine
                strSql &= "INNER JOIN tdevice B ON B.Model_ID = A.Model_ID " & Environment.NewLine
                strSql &= "WHERE B.Model_ID = '" & iModelID.ToString & "';"

                Return GetIsProdGrpIDNull(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Private Function GetIsProdGrpIDNull(ByVal strSql As String) As Boolean
            Dim dt As DataTable
            Dim booIsProdGrpIDNull As Boolean = False
            Dim iIsNull As Integer

            Try
                objMisc._SQL = strSql
                dt = objMisc.GetDataTable

                If dt.Rows.Count = 1 Then
                    If Not IsDBNull(dt.Rows(0)("ProdGrpIsNull")) Then
                        iIsNull = CInt(dt.Rows(0)("ProdGrpIsNull"))

                        If iIsNull = 1 Then
                            booIsProdGrpIDNull = True
                        End If
                    End If
                End If

                Return booIsProdGrpIDNull
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Function

#End Region ' IsProdGrpIDNull

#Region "SubstituteNullProdGrpID"
        ' Functions for replacing NULL ProdGrp_ID values.

        Private Function SubstituteNullProdGrpID(ByVal strDeviceSN As String) As Boolean
            Dim strSql As String = ""
            Dim iExecNonQueryExec
            Dim booSubstitutionSuccessful As Boolean = False

            Try
                strSql &= "UPDATE tmodel " & Environment.NewLine
                strSql &= "SET ProdGrp_ID = Model_Flat " & Environment.NewLine
                strSql &= "WHERE Model_ID = " & GetModelID(strDeviceSN).ToString & ";"

                Return RunSubstituteNullProdGrpID(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Private Function SubstituteNullProdGrpID(ByVal iModelID As Integer) As Boolean
            Dim strSql As String = ""

            Try
                strSql &= "UPDATE tmodel " & Environment.NewLine
                strSql &= "SET ProdGrp_ID = Model_Flat " & Environment.NewLine
                strSql &= "WHERE Model_ID = " & iModelID.ToString & ";"

                Return RunSubstituteNullProdGrpID(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Private Function RunSubstituteNullProdGrpID(ByVal strSql As String) As Boolean
            Dim iExecNonQuery As Integer
            Dim booSubstitutionSuccessful As Boolean = False

            Try
                objMisc._SQL = strSql
                iExecNonQuery = objMisc.ExecuteNonQuery

                If iExecNonQuery > 0 Then
                    booSubstitutionSuccessful = True
                End If

                Return booSubstitutionSuccessful
            Catch ex As Exception
                Throw ex
            End Try
        End Function

#End Region  ' SubstituteNullProdGrpID

        Private Function GetModelID(ByVal strDeviceSN As String) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim iModelID As Integer = -1

            Try
                strSql &= "SELECT A.Model_ID " & Environment.NewLine
                strSql &= "FROM tmodel A " & Environment.NewLine
                strSql &= "INNER JOIN tdevice B ON B.Model_ID = A.Model_ID " & Environment.NewLine
                strSql &= "WHERE B.Device_SN = '" & strDeviceSN & "';"

                objMisc._SQL = strSql
                dt = objMisc.GetDataTable

                If dt.Rows.Count = 1 Then
                    If Not IsDBNull(dt.Rows(0)("Model_ID")) Then
                        iModelID = CInt(dt.Rows(0)("Model_ID"))
                    End If
                End If

                Return iModelID
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Function

        '***************************************************************************
        Public Sub New()
            objMisc = New Production.Misc()
        End Sub
        '***************************************************************************
        Protected Overrides Sub Finalize()
            objMisc = Nothing
            MyBase.Finalize()
        End Sub
        '***************************************************************************
    End Class
End Namespace
