Imports eInfoDesigns.dbProvider.MySqlClient
Imports System.Windows.Forms

Namespace Production
    Public Class Misc
        'Private Shared _conn As MySqlConnection = Nothing
        '***************************************************
        Private Shared strSQL As String = ""

        Public Shared Property _SQL() As String
            Get
                Return strSQL
            End Get
            Set(ByVal Value As String)
                strSQL = Value
            End Set
        End Property

        Private _objDataProc As DBQuery.DataProc

        Public Sub New()
            Try
                Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '***************************************************
        'Gets datatable
        '***************************************************
        Public Function GetDataRow() As DataRow
            Dim dt As DataTable = Nothing
            Try
                dt = GetDataTable()

                If dt.Rows.Count > 0 Then
                    Return dt.Rows(0)
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                Throw New Exception("Production.Misc.GetDataRow: " & ex.Message.ToString)
            Finally
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
                '*********************************
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
                '*********************************
            End Try
        End Function

        Public Function GetDataRow(ByVal strSql As String) As DataRow
            Me._SQL = strSql

            Return GetDataRow()
        End Function

        '*************************************************************************
        Public Function GetDataTable(Optional ByVal iServer_ID As Integer = 0) As DataTable
            Dim dt As New DataTable()

            Try
                If iServer_ID = 1 Then  '1 for Replication Servers
                    Return dt
                Else
                    Return Me._objDataProc.GetDataTable(Me._SQL)
                End If
            Catch ex As Exception
                Throw ex
            Finally
                '*********************************
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
                '*********************************
            End Try
        End Function

        Public Function GetDataTable(ByVal strSql As String, Optional ByVal iServer_ID As Integer = 0) As DataTable
            Try
                Me._SQL = strSql
                Return GetDataTable(iServer_ID)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************
        'Executes update queries
        '***************************************************************************
        Public Function ExecuteNonQuery() As Integer
           Try
                Return Me._objDataProc.ExecuteNonQuery(Me._SQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function ExecuteNonQuery(ByVal strSql As String) As Integer
            Try
                Me._SQL = strSql

                Return ExecuteNonQuery()
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************
        'Handles Insert SQL statements and returns the IDs
        '****************************************************************************
        Public Function idTransaction(ByVal SQL As String, ByVal strTable As String) As Int32
            Try
                Return Me._objDataProc.idTransaction(SQL, strTable)
            Catch ex As Exception
                Throw ex
            Finally
                '*********************************
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
                '*********************************
            End Try
        End Function

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
            '*********************************
            GC.Collect()
            GC.WaitForPendingFinalizers()
            GC.Collect()
            GC.WaitForPendingFinalizers()
            '*********************************
        End Sub

        Public Function GetLongValue(ByVal strSql As String) As Long
            Dim lRet As Long = 0
            Dim strRet As String = ""

            strRet = GetSingletonString(strSql)

            If IsNumeric(strRet) Then lRet = CLng(strRet)

            Return lRet
        End Function

        Public Function GetIntValue(ByVal strSql As String) As Integer
            Dim iRet As Integer = 0
            Dim strRet As String = ""

            strRet = GetSingletonString(strSql)

            If IsNumeric(strRet) Then iRet = CInt(strRet)

            Return iRet
        End Function

        Public Function GetSingletonString(ByVal strSql As String) As String
            Dim dt As DataTable = Nothing
            Dim dr As DataRow = Nothing
            Dim strRet As String = ""
            Dim sf As New StackFrame(0)

            Try
                dt = GetDataTable(strSql)

                If Not IsNothing(dt) Then
                    If dt.Rows.Count > 0 Then
                        dr = dt.Rows(0)

                        If Not IsDBNull(dr(0)) Then
                            strRet = dr(0)
                        End If
                    End If
                End If

                Return strRet
            Catch ex As Exception
                DisplayMessage(sf.GetMethod, ex.Message)
            Finally
                dr = Nothing

                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Function

        Public Shared Sub DisplayMessage(ByVal methInfo As Reflection.MethodBase, ByVal strMsg As String, Optional ByVal bIsErrMsg As Boolean = True)
            Dim theType As Type
            Dim strTitle, strLead As String
            Dim mbi As System.Windows.Forms.MessageBoxIcon

            theType = methInfo.DeclaringType

            If bIsErrMsg Then
                strTitle = "Error"
                strLead = "An error has occurred in "
                mbi = MessageBoxIcon.Error
            Else
                strTitle = "Information"
                strLead = ""
                mbi = MessageBoxIcon.Information
            End If

            MessageBox.Show(strLead & theType.FullName & "." & methInfo.Name & "(): " & Environment.NewLine & strMsg, strTitle, MessageBoxButtons.OK, mbi, MessageBoxDefaultButton.Button1)
        End Sub

        Public Shared Sub DisplayMessage(ByVal strMsg As String, Optional ByVal iStackLevel As Integer = 2, Optional ByVal bIsErrMsg As Boolean = True)
            Dim strTitle, strLead As String
            Dim mbi As System.Windows.Forms.MessageBoxIcon
            Dim strCurrentInfo As String = GetCurrentInfo(iStackLevel)

            If bIsErrMsg Then
                strTitle = "Error"
                strLead = "An error has occurred in "
                mbi = MessageBoxIcon.Error
            Else
                strTitle = "Information"
                strLead = ""
                mbi = MessageBoxIcon.Information
            End If

            MessageBox.Show(strCurrentInfo & Environment.NewLine & strMsg, strTitle, MessageBoxButtons.OK, mbi, MessageBoxDefaultButton.Button1)
        End Sub

        Public Shared Function GetCurrentInfo(Optional ByVal iStackLevel As Integer = 2) As String
            Dim st As New StackTrace(True)
            Dim pi As System.Reflection.ParameterInfo()
            Dim iIndex As Integer
            Dim strParams As String = ""

            pi = st.GetFrame(iStackLevel).GetMethod.GetParameters()

            If pi.Length > 0 Then
                For iIndex = 0 To pi.Length - 1
                    If strParams.Length > 0 Then strParams &= ", "

                    If pi(iIndex).IsOptional Then strParams &= "Optional "

                    If pi(iIndex).Member.ReflectedType.IsByRef Then
                        strParams &= "ByRef "
                    Else
                        strParams &= "ByVal "
                    End If

                    strParams &= pi(iIndex).Name.ToString & " As " & pi(iIndex).ParameterType.ToString

                    If pi(iIndex).IsOptional Then
                        strParams &= " = "

                        If pi(iIndex).GetType() Is System.Type.GetType("System.String") Then strParams &= "'"

                        strParams &= pi(iIndex).DefaultValue.ToString()

                        If pi(iIndex).GetType() Is System.Type.GetType("System.String") Then strParams &= "'"
                    End If
                Next
            End If

            Return "[" & st.GetFrame(iStackLevel).GetMethod().ReflectedType.Name & "." & st.GetFrame(iStackLevel).GetMethod().Name & "(" & strParams & "), line " & st.GetFrame(iStackLevel).GetFileLineNumber().ToString + "] "
        End Function

        Public Function GetDefaultAmount(ByVal strShortDesc As String) As Double
            ' To obtain default values from lConstants
            Dim dblDefaultAmount As Double = 0
            Dim strAmt As String = ""
            Dim strSql As String
            Dim sf As New StackFrame(0)

            Try
                If strShortDesc.Length > 0 Then
                    strSql = "SELECT Value" & Environment.NewLine
                    strSql &= "FROM lConstants " & Environment.NewLine
                    strSql &= "WHERE UPPER(ShortDesc) = " & strShortDesc.Trim.ToUpper

                    strAmt = GetSingletonString(strSql)

                    If strAmt.Length > 0 Then dblDefaultAmount = CDbl(strAmt)
                End If

                Return dblDefaultAmount
            Catch ex As Exception
                DisplayMessage(sf.GetMethod, ex.Message)
            End Try
        End Function

    End Class
End Namespace