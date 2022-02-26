Imports System
Imports System.Data
Imports PSS.Data.Buisness.Security

Namespace Rules

    Public Class SecurityPassword
        Inherits Object

        Private bUpperLetter As Boolean = True
        Private bLowerLetter As Boolean = True
        Private bNumericNumber As Boolean = True
        Private bSpecialCharacter As Boolean = True
        Private iPasswordLength As Integer = 0
        Private iPasswordExpireDays As Integer = 0
        Private iReuseLastPWMonths As Integer = 0
        Private iAccoutLockoutTimes As Integer = 0
        Private iAccountResetMinutes As Integer = 0

        Private iPWMinLen As Integer = 1
        Private iPWMaxLen As Integer = 16
        Private iDaysPerMonth As Integer = 30

        Private _objSecurity As PSS.Data.Buisness.Security
        Private _dtPasswordRuleData As DataTable
        Private strSpecialCharacters As String = "!@#$%^&*(){}[]"

#Region "Constructor/Destructor"

        '******************************************************************
        Public Sub New()
            Try
                Me._objSecurity = New PSS.Data.Buisness.Security()
                Me._dtPasswordRuleData = Me._objSecurity.getPasswordRuleData

                InitializeVariables()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub


        '******************************************************************
        Protected Overrides Sub Finalize()
            Me._objSecurity = Nothing
            MyBase.Finalize()
        End Sub

        '******************************************************************
#End Region

#Region "Properties"
        '******************************************************************
        Public ReadOnly Property SpeicalCharacters() As String
            Get
                Return Me.strSpecialCharacters
            End Get
        End Property

        Public ReadOnly Property UpperLetter() As Boolean
            Get
                Return Me.bUpperLetter
            End Get
        End Property
        Public ReadOnly Property LowerLetter() As Boolean
            Get
                Return Me.bLowerLetter
            End Get
        End Property
        Public ReadOnly Property NumericNumber() As Boolean
            Get
                Return Me.bNumericNumber
            End Get
        End Property
        Public ReadOnly Property SpecialCharacter() As Boolean
            Get
                Return Me.bSpecialCharacter
            End Get
        End Property
        Public ReadOnly Property PasswordLength() As Integer
            Get
                Return Me.iPasswordLength
            End Get
        End Property
        Public ReadOnly Property PasswordExpireDays() As Integer
            Get
                Return Me.iPasswordExpireDays
            End Get
        End Property
        Public ReadOnly Property ReuseLastPWMonths() As Integer
            Get
                Return Me.iReuseLastPWMonths
            End Get
        End Property
        Public ReadOnly Property AccoutLockoutTimes() As Integer
            Get
                Return Me.iAccoutLockoutTimes
            End Get
        End Property
        Public ReadOnly Property AccountResetMinutes() As Integer
            Get
                Return Me.iAccountResetMinutes
            End Get
        End Property
        Public ReadOnly Property MaxPasswordLength() As Integer
            Get
                Return Me.iPWMaxLen
            End Get
        End Property
#End Region

#Region "Password Initialization"

        '******************************************************************
        Public Sub InitializeVariables()
            Dim row As DataRow
            Try
                For Each row In Me._dtPasswordRuleData.Rows
                    Select Case row("RuleItem").ToString.Trim.ToUpper
                        Case "UpperLetter".ToUpper
                            If row("Required") = 0 Then
                                Me.bUpperLetter = False
                            Else
                                Me.bUpperLetter = True
                            End If
                        Case "LowerLetter".ToUpper
                            If row("Required") = 0 Then
                                Me.bLowerLetter = False
                            Else
                                Me.bLowerLetter = True
                            End If
                        Case "NumericNumber".ToUpper
                            If row("Required") = 0 Then
                                Me.bNumericNumber = False
                            Else
                                Me.bNumericNumber = True
                            End If
                        Case "SpecialCharacter".ToUpper
                            If row("Required") = 0 Then
                                Me.bSpecialCharacter = False
                            Else
                                Me.bSpecialCharacter = True
                            End If
                        Case "PasswordLength".ToUpper
                            If row("Required") >= Me.iPWMinLen AndAlso row("Required") <= Me.iPWMaxLen Then
                                Me.iPasswordLength = row("Required")
                            Else
                                Me.iPasswordLength = Me.iPWMinLen
                            End If
                        Case "PasswordExpireDays".ToUpper
                            If row("Required") > 0 Then
                                Me.iPasswordExpireDays = row("Required")
                            Else
                                Me.iPasswordExpireDays = 0
                            End If
                        Case "ReuseLastPWMonths".ToUpper
                            If row("Required") > 0 Then
                                Me.iReuseLastPWMonths = row("Required")
                            Else
                                Me.iReuseLastPWMonths = 0
                            End If
                        Case "AccoutLockoutTimes".ToUpper
                            If row("Required") > 0 Then
                                Me.iAccoutLockoutTimes = row("Required")
                            Else
                                Me.iAccoutLockoutTimes = 0
                            End If
                        Case "AccountResetMinutes".ToUpper
                            If row("Required") > 0 Then
                                Me.iAccountResetMinutes = row("Required")
                            Else
                                Me.iAccountResetMinutes = 0
                            End If
                    End Select



                Next

            Catch ex As Exception
                Throw ex
            End Try

        End Sub

        '******************************************************************
#End Region

#Region "Functions"

        '*****************************************************************
        Public Function PasswordRulesMsg() As String
            Dim strMsg As String = "Password Rule:".ToUpper & Environment.NewLine
            Try
                With Me
                    If .bUpperLetter Then strMsg &= " At least 1 uppercase letter is required" & Environment.NewLine
                    If .bLowerLetter Then strMsg &= " At least 1 lowercase letter is required" & Environment.NewLine
                    If .bSpecialCharacter Then strMsg &= " At least 1 speical character is required (1 of these " & .SpeicalCharacters & ")" & Environment.NewLine
                    If .bNumericNumber Then strMsg &= " At least 1 number is required" & Environment.NewLine
                    strMsg &= " Minimum password length is " & .PasswordLength & Environment.NewLine
                End With

                Return strMsg
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************
        Public Function IsPsswordContainUpperLeter(ByVal strPassword As String) As Boolean
            Dim strS As String = ""
            Dim c As String = ""
            Dim ascii As Integer

            Try

                For ascii = 65 To 90 'upper  letter
                    strS = Chr(ascii)
                    For Each c In strPassword
                        If strS = c Then Return True
                    Next
                Next

                Return False
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************
        Public Function IsPsswordContainLowerLeter(ByVal strPassword As String) As Boolean
            Dim strS As String = ""
            Dim c As String = ""
            Dim ascii As Integer

            Try

                For ascii = 65 To 90 'upper  letter
                    strS = Chr(ascii).ToString.ToLower
                    For Each c In strPassword
                        If strS = c Then Return True
                    Next
                Next

                Return False
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************
        Public Function IsPsswordContainSpecialChar(ByVal strPassword As String) As Boolean
            Dim strS As String = ""
            Dim c As String = ""

            Try

                For Each strS In strPassword
                    For Each c In Me.strSpecialCharacters
                        If strS = c Then Return True
                    Next
                Next

                Return False
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************
        Public Function IsPsswordContainNumber(ByVal strPassword As String) As Boolean
            Dim strS As String = ""
            Dim c As String = ""
            Dim i As Integer

            Try

                For i = 0 To 9
                    strS = i.ToString
                    For Each c In strPassword
                        If strS = c Then Return True
                    Next
                Next

                Return False
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************
        Public Function IsPsswordExpired(ByVal iUserID As Integer) As Boolean
            Dim iPwLogID As Integer
            Dim objSecurity As New PSS.Data.Buisness.Security()
            Dim dt1, dt2 As DataTable
            Dim row As DataRow
            Dim DTime As Date, DTimeNow As Date
            Dim isFound As Boolean = False

            Try
                If Not Me.iPasswordExpireDays > 0 Then Return False 'no expaired day

                dt1 = objSecurity.GetLoginDatatableByUserID(iUserID)
                dt2 = objSecurity.getPasswordLogData(iUserID)

                If dt2.Rows.Count = 0 Then Return True

                If dt1.Rows.Count > 0 Then 'must be one if any
                    iPwLogID = dt1.Rows(0).Item("PwLog_ID")
                    For Each row In dt2.Rows
                        If row("PwLog_ID") = iPwLogID Then
                            DTime = CDate(row("PwUsed_Date"))
                            isFound = True : Exit For
                        End If
                    Next
                    If Not isFound AndAlso dt2.Rows.Count > 0 Then
                        For Each row In dt2.Rows
                            DTime = CDate(row("PwUsed_Date"))
                            isFound = True : Exit For
                        Next
                    End If

                    If isFound Then
                        DTimeNow = CDate(PSS.Data.Buisness.Generic.MySQLServerDateTime(0))
                        If DateDiff(DateInterval.Day, DTime, DTimeNow) >= Me.iPasswordExpireDays Then
                            Return True
                        Else
                            Return False
                        End If
                    Else
                        Return True
                    End If
                Else
                    Return True
                End If

            Catch ex As Exception
                Throw ex
            Finally
                objSecurity = Nothing
            End Try
        End Function

        '*****************************************************************
        Public Function IsPsswordUsedBefore(ByVal iUserID As Integer, ByVal strPassword As String) As Boolean
            Dim objSecurity As New PSS.Data.Buisness.Security()
            Dim dt As DataTable
            Dim row As DataRow
            Dim strBeginDTime As String, strEndDtime As String
            Dim DTime As Date

            Try
                If Not Me.iReuseLastPWMonths > 0 Then Return False 'no need to validate it,. The restriction removed at this point

                DTime = CDate(PSS.Data.Buisness.Generic.MySQLServerDateTime(0))
                strEndDtime = Format(DTime, "yyyy-MM-dd HH:mm:ss")
                DTime = DTime.AddDays(-Me.iReuseLastPWMonths * Me.iDaysPerMonth)
                strBeginDTime = Format(DTime, "yyyy-MM-dd HH:mm:ss")

                dt = objSecurity.getPasswordLogData(iUserID, strBeginDTime, strEndDtime)

                If dt.Rows.Count = 0 Then
                    Return False
                Else
                    For Each row In dt.Rows
                        If row("Pw_Used").ToString.Trim = strPassword.Trim Then
                            Return True
                        End If
                    Next
                End If

                Return False

            Catch ex As Exception
                Throw ex
            Finally
                objSecurity = Nothing
            End Try
        End Function

        '*****************************************************************
        Public Function IsAccountLocked(ByVal iUserID As Integer) As Boolean
            Dim iPwLogID As Integer
            Dim objSecurity As New PSS.Data.Buisness.Security()
            Dim dt As DataTable
            Dim row As DataRow
            Dim DTime As Date, DTimeNow As Date
            Dim isFound As Boolean = False

            Try

                dt = objSecurity.GetLoginDatatableByUserID(iUserID)

                If dt.Rows.Count = 0 Then
                    Return False
                Else
                    If Not dt.Rows(0).IsNull("AccountLockOut_PwAttempted_id") _
                       AndAlso dt.Rows(0).Item("AccountLockOut_PwAttempted_id") > 0 Then
                        Return True
                    Else
                        Return False
                    End If
                End If

            Catch ex As Exception
                Throw ex
            Finally
                objSecurity = Nothing
            End Try
        End Function

        '*****************************************************************
        Public Sub SavePasswordAttemptedFailedLog(ByVal iUserID As Integer, ByVal strPassword As String)
            Dim objSecurity As New PSS.Data.Buisness.Security()
            Dim ojbCollectTrackingLog As New PSS.Data.BaseClasses.CollectTrackingLog()
            Dim dt As DataTable
            Dim row As DataRow
            Dim foundRows() As DataRow
            Dim DTime As Date, DTimeNow As Date
            Dim strSessionID As String = ""
            Dim bAccountLocked As Boolean = False
            Dim strPCName As String = ""
            Dim strWinUser As String = ""
            Dim strPreFix As String = "S"

            Try
                strPCName = ojbCollectTrackingLog.GetComputerName
                strWinUser = ojbCollectTrackingLog.GetWindowsUser

                dt = objSecurity.getPasswordAttemptedData(iUserID)
                If dt.Rows.Count = 0 Then
                    strSessionID = strPreFix & Format(Now, "yyyyMMddHHmmssfff")
                Else ' sorted by PwAttempted_Datetime DESC
                    DTime = CDate(dt.Rows(0).Item("PwAttempted_Datetime"))
                    DTimeNow = CDate(PSS.Data.Buisness.Generic.MySQLServerDateTime(0))
                    If DateDiff(DateInterval.Minute, DTime, DTimeNow) > Me.iAccountResetMinutes Then
                        strSessionID = strPreFix & Format(Now, "yyyyMMddHHmmssfff")
                    Else
                        strSessionID = dt.Rows(0).Item("SessionID")
                        foundRows = dt.Select("SessionID='" & strSessionID & "'")
                        If foundRows.Length >= Me.iAccoutLockoutTimes - 1 Then 'Acount loacked
                            bAccountLocked = True
                        End If
                    End If

                End If

                objSecurity.SavePasswordAttemptedLog(iUserID, strPassword, strSessionID, strPCName, _
                                                     strWinUser, bAccountLocked, True)

            Catch ex As Exception
                Throw ex
            Finally
                objSecurity = Nothing : ojbCollectTrackingLog = Nothing
            End Try
        End Sub

        '*****************************************************************
        Public Function IsAccountResetMinutesOver(ByVal iUserID As Integer) As Boolean ', ByVal strPassword As String)
            Dim objSecurity As New PSS.Data.Buisness.Security()
            Dim dt As DataTable
            Dim DTime As Date, DTimeNow As Date
            Dim bUnlock As Boolean = False
            Dim i As Integer = 0

            Try

                dt = objSecurity.getPasswordAttemptedData(iUserID)
                If dt.Rows.Count = 0 Then
                    Return True
                Else ' sorted by PwAttempted_Datetime DESC
                    DTime = CDate(dt.Rows(0).Item("PwAttempted_Datetime"))
                    DTimeNow = CDate(PSS.Data.Buisness.Generic.MySQLServerDateTime(0))
                    If DateDiff(DateInterval.Minute, DTime, DTimeNow) > Me.iAccountResetMinutes Then
                        If bUnlock Then
                            i = objSecurity.UnlockUserLogin(iUserID)
                        End If
                        Return True
                    Else
                        Return False
                    End If
                End If
            Catch ex As Exception
                Throw ex
            Finally
                objSecurity = Nothing
            End Try
        End Function

        '*****************************************************************
        Public Function IsAccountResetMinutesOver_AttemptedNo(ByVal iUserID As Integer) As Integer ', ByVal strPassword As String)
            Dim objSecurity As New PSS.Data.Buisness.Security()
            Dim ojbCollectTrackingLog As New PSS.Data.BaseClasses.CollectTrackingLog()
            Dim dt As DataTable
            Dim row As DataRow
            Dim foundRows() As DataRow
            Dim strSessionID As String = ""
            Dim bAccountLocked As Boolean = False

            Try

                dt = objSecurity.getPasswordAttemptedData(iUserID)
                If dt.Rows.Count = 0 Then
                    Return 0
                Else ' sorted by PwAttempted_Datetime DESC
                    strSessionID = dt.Rows(0).Item("SessionID")
                    foundRows = dt.Select("SessionID='" & strSessionID & "'")
                    Return foundRows.Length
                End If

            Catch ex As Exception
                Throw ex
            Finally
                objSecurity = Nothing : ojbCollectTrackingLog = Nothing
            End Try
        End Function

#End Region
    End Class

End Namespace
