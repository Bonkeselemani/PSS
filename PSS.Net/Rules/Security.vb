Imports PSS.Data.Buisness.Security
Imports PSS.Core.Registry

Namespace Rules
    Public Class Security
        Inherits Object

        Private adminName As String = "pssadmin"
        Private adminPass As String = "admin@4321!!"
        Private adminLogin As Boolean = False

        Private userID As Integer = 0
        Private ShiftID As Integer = 0
        Private userName As String = Nothing
        Private userPass As String = Nothing
        Private userFull As String = Nothing
        Private techID As String = Nothing
        Private empNumber As String = Nothing
        Private userLogin As Boolean = False
        Private strWorkdate As String = Nothing
        Private iGroup_ID As String = 0
        Private iLineID As String = 0
        Private strGroup_Desc As String = ""


        Private userStatus As Integer = 0
        Dim _objSec As New PSS.Data.Buisness.Security()

        Private Sub New()
        End Sub

        Public Sub New(ByVal username As String, ByVal password As String)
            If username.ToLower = adminName.ToLower And password = adminPass Then
                adminLogin = True
                Me.userFull = "PSS Admin"
                Me.techID = "999"

            Else
                Me.userName = username
                Me.userPass = password
            End If
        End Sub

        Private Function checkShiftTime() As Boolean
            Dim R1 As DataRow = Nothing
            Dim iPSSWeekDay As Integer = 0
            Dim iShiftStartDay As Integer = 0
            Dim iShiftEndDay As Integer = 0
            Dim strShiftStartTime As String = ""
            Dim strShiftEndTime As String = ""
            Dim dteShiftStartDateTime, dteShiftEndDateTime As DateTime
            Dim iShift_Flag As Integer = 0

            Try
                '***********************************************************
                'Check if the user is logging in outside his/her shift times
                '***********************************************************
                'Step 1: get PSS WeekDay
                '*************************
                R1 = Me._objSec.GetPSSWeekDay(WeekdayName(Weekday(Now)))
                iPSSWeekDay = R1("weekday_id")
                R1 = Nothing
                '*************************
                'Step 2: Get Current Shift details
                '*************************
                R1 = Me._objSec.GetShiftDetail(ShiftID)
                iShiftStartDay = R1("shift_startday")
                iShiftEndDay = R1("shift_endday")
                strShiftStartTime = Trim(R1("Shift_StartTime"))
                strShiftEndTime = Trim(R1("Shift_EndTime"))
                iShift_Flag = R1("Shift_Flag")
                R1 = Nothing

                Select Case iShift_Flag     'For shift Flag descriptions look up the table "lshiftflag"
                    Case 0
                        dteShiftStartDateTime = CDate(Format(CDate(strWorkdate), "MM/dd/yyyy") & " " & strShiftStartTime)
                        dteShiftEndDateTime = CDate(Format(CDate(strWorkdate), "MM/dd/yyyy") & " " & strShiftEndTime)
                    Case -1
                        dteShiftStartDateTime = CDate(Format(DateAdd(DateInterval.Day, 1, CDate(strWorkdate)), "MM/dd/yyyy") & " " & strShiftStartTime)
                        dteShiftEndDateTime = CDate(Format(DateAdd(DateInterval.Day, 1, CDate(strWorkdate)), "MM/dd/yyyy") & " " & strShiftEndTime)
                    Case 9
                        dteShiftStartDateTime = CDate(Format(CDate(strWorkdate), "MM/dd/yyyy") & " " & strShiftStartTime)
                        dteShiftEndDateTime = CDate(Format(DateAdd(DateInterval.Day, 1, CDate(strWorkdate)), "MM/dd/yyyy") & " " & strShiftEndTime)
                End Select
                '*************************
                'Step 3: 
                '(A)Check if the work day 
                'falls in the user's shift
                'days.
                '*************************
                If iPSSWeekDay >= iShiftStartDay And iPSSWeekDay <= iShiftEndDay Then
                    '(B) Check if the current 
                    'date time is with in the shift 
                    'datetimes
                    If Now >= dteShiftStartDateTime And Now <= dteShiftEndDateTime Then
                        Return True
                    Else
                        Return False
                    End If
                Else
                    Return False
                End If
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
            End Try
        End Function

        Public Function CheckLogin() As Boolean
            Dim i As Integer = 0
            Dim mWD As New PSS.Data.Buisness.WorkDate()
            Dim objGen As New PSS.Data.Buisness.Generic()
            Dim strServerDtTime As String = ""
            Dim dt1 As DataTable
            Dim R1, _r As DataRow
            '******************************
            'Dim strWeekDay As String = ""

            If adminLogin = False Then
                Try
                    'PASSED
                    _r = Me._objSec.GetLoginData(userName, userPass)

                    'FAILED

                    userID = _r("user_id")
                    userFull = _r("user_fullname")

                    'MsgBox("I am here. " & userID & " " & userFull)
                    '**************************************
                    'Added by Asif on 10/26/2005
                    If Not IsDBNull(_r("Tech_ID")) Then
                        techID = _r("Tech_ID")
                    Else
                        techID = 0
                    End If

                    If Not IsDBNull(_r("Shift_ID")) Then
                        ShiftID = _r("Shift_ID")
                    Else
                        ShiftID = 0
                    End If

                    '***************************************
                    'Check if the user is set to inactive
                    If Not IsDBNull(_r("user_inactive")) Then
                        userStatus = _r("user_inactive")
                    Else
                        userStatus = 0
                    End If

                    If userStatus = 1 Then
                        '//Display Error Message and Force exit here until user has a defined employee number
                        MsgBox("The security login account used has been inactivated. Please have your direct lead contact IT to correct this. You will not be able to login until this has been corrected.", MsgBoxStyle.Critical, "Login Inactive")
                        End
                    End If
                    '*******************
                    'Check if the employee number is assigned to the employee.
                    If Not IsDBNull(_r("EmployeeNo")) Then
                        empNumber = _r("EmployeeNo")      'This was there
                    Else
                        '//Display Error Message and Force exit here until user has a defined employee number
                        MsgBox("The security login used does not have an assigned employee number. Please have your direct lead contact IT to correct this. You will not be able to login until this has been corrected.", MsgBoxStyle.Critical, "Login Incomplete")
                        End
                        empNumber = 0
                    End If
                    '*******************
                    'Get the work date for the user and login time
                    'Dim mWD As New PSS.Data.Buisness.WorkDate()

                    strServerDtTime = objGen.MySQLServerDateTime()
                    'strWorkdate = mWD.WorkDate(ShiftID, Now)
                    strWorkdate = mWD.WorkDate(ShiftID, strServerDtTime)
                    If Len(Trim(strWorkdate)) > 0 Then
                    Else
                        MsgBox("The system could not determine the work date. Contact your direct lead or IT to resolve this issue.", MsgBoxStyle.Critical, "WorkDate")
                        End
                    End If
                    '*********************************************
                    'Get GroupID, GroupDesc and LineID by Machine
                    '*********************************************
                    dt1 = mWD.GetParentGroupForMachine()
                    If dt1.Rows.Count > 0 Then
                        R1 = dt1.Rows(0)
                        If Not IsDBNull(R1("Line_ID")) Then
                            iLineID = R1("Line_ID")
                        End If
                        If Not IsDBNull(R1("Group_ID")) Then
                            iGroup_ID = R1("Group_ID")
                        End If
                        If Not IsDBNull(R1("Group_Desc")) Then
                            strGroup_Desc = R1("Group_Desc")
                        End If
                    End If


                    ''iGroup_ID = mWD.GetParentGroupForMachine()
                    '''*******************
                    '''Get the LineID for the Machine
                    ''iLineID = mWD.GetParentGroupForMachine(1)
                    '*****************************************

                    '***********************************************************************
                    'if the employee is not exempt then do the following checks.
                    '***********************************************************************
                    If _r("ExemptFlag") = 0 Then

                        '**********************
                        'Check to see if the user is trying to logon on different machines 
                        'with same user id
                        If Not IsDBNull(_r("LastLogonMachine")) Then
                            If UCase(Trim(System.Net.Dns.GetHostName)) <> UCase(Trim(_r("LastLogonMachine"))) Then
                                i = 2   'Machine names differ
                                MessageBox.Show("This user has a PSS.NET session open on the machine '" & Trim(_r("LastLogonMachine")) & "'. Please close that session to open it on this machine.", "PSS.NET on Multiple Machines", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                                End
                            Else
                                i = 1   'machine names match
                            End If
                        End If
                        If i = 0 Then
                            'Set Last Logon Machine for the user
                            If Me._objSec.ResetLastLogonMachine(PSS.Core.Global.ApplicationUser.IDuser, System.Net.Dns.GetHostName) = 0 Then
                                MessageBox.Show("Set 'Last Logon Machine' for this user failed. Inform your lead.", "Failure - Last Logon Machine Setup", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            End If
                        End If

                        '**********************
                        'Check if the user is logging on outside his/her shift times
                        If _r("OTFlag") = 0 Then
                            Dim blnCheckShift As Boolean
                            blnCheckShift = checkShiftTime()
                            If blnCheckShift = False Then
                                MessageBox.Show("You are attempting to login outside of your current schedule time. Please have your direct lead contact IT to correct this. You will not be able to login until this has been corrected.", "Login time outside user shift times", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                                End
                            End If
                        End If
                        '**********************
                    ElseIf _r("ExemptFlag") = 1 Then
                        'Set Last Logon Machine for the exempt user
                        If Me._objSec.ResetLastLogonMachine(PSS.Core.Global.ApplicationUser.IDuser, System.Net.Dns.GetHostName) = 0 Then
                            MessageBox.Show("Set 'Last Logon Machine' for this user failed. Inform your lead.", "Failure - Last Logon Machine Setup", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        End If
                    End If
                    '***********************************************************************
                    userLogin = True
                    SetKey("RecentLogon", userName)

                    '**********************************************
                    'This will give all access to the screen
                    ' Use by IT member only..
                    '**********************************************
                    If _r("GlobalAccess") = 1 Then adminLogin = True
                    '**********************************************

                Catch ex As Exception
                    'Throw New Exception("The user name and password you provided are incorrect please try again." & vbCrLf & _
                    '                                "If the problem persists please contact an administrator.")
                    Throw ex
                Finally
                    mWD = Nothing
                    objGen = Nothing
                    R1 = Nothing : _r = Nothing
                    If Not IsNothing(dt1) Then
                        dt1.Dispose()
                        dt1 = Nothing
                    End If
                End Try
            End If
        End Function

        Public Function Login() As Boolean
            Dim R1 As DataRow
            Dim strServerDtTime As String = ""
            Dim mWD As New PSS.Data.Buisness.WorkDate()
            Dim dt As DataTable

            Try
                R1 = Me._objSec.GetLoginData(userName, userPass)

                userID = R1("user_id") : userFull = R1("user_fullname")

                If Not IsDBNull(R1("Tech_ID")) Then
                    techID = R1("Tech_ID")
                Else
                    techID = 0
                End If

                If Not IsDBNull(R1("Shift_ID")) Then
                    ShiftID = R1("Shift_ID")
                Else
                    ShiftID = 0
                End If

                If Not IsDBNull(R1("EmployeeNo")) Then empNumber = R1("EmployeeNo")

                strServerDtTime = Data.Buisness.Generic.MySQLServerDateTime(1)
                strWorkdate = mWD.WorkDate(ShiftID, strServerDtTime)

                '*********************************************
                'Get GroupID, GroupDesc and LineID by Machine
                '*********************************************
                dt = mWD.GetParentGroupForMachine()
                If dt.Rows.Count > 0 Then
                    R1 = dt.Rows(0)
                    If Not IsDBNull(R1("Line_ID")) Then
                        iLineID = R1("Line_ID")
                    End If
                    If Not IsDBNull(R1("Group_ID")) Then
                        iGroup_ID = R1("Group_ID")
                    End If
                    If Not IsDBNull(R1("Group_Desc")) Then
                        strGroup_Desc = R1("Group_Desc")
                    End If
                End If

            Catch ex As Exception
                'Throw ex
            Finally
                mWD = Nothing : Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        Public Function GetPermission(ByVal screen As String) As Integer
            Dim iReturn As Integer = 0
            If adminLogin = True Then
                iReturn = 2
            Else
                Try
                    iReturn = Me._objSec.GetPermData(userID, Left(screen, 50))
                Catch e As Exception
                    iReturn = 0
                End Try
            End If
            Return iReturn
        End Function

        Public Shared Function IsCellular(ByVal iGroupID As Integer) As Boolean
            ' Check if the group ID is a cellular group
            Dim objSecurity As New PSS.Data.Buisness.Security()

            Return objSecurity.IsCellular(iGroupID)
        End Function

        Public ReadOnly Property User() As String
            Get
                Return Me.userFull
            End Get
        End Property

        Public ReadOnly Property IDtech() As String
            Get
                Return Me.techID
            End Get
        End Property

        Public ReadOnly Property IDuser() As String
            Get
                Return Me.userID
            End Get
        End Property

        Public ReadOnly Property IDShift() As String
            Get
                Return Me.ShiftID
            End Get
        End Property

        Public ReadOnly Property NumberEmp() As String
            Get
                Return Me.empNumber
            End Get
        End Property

        Public ReadOnly Property Workdate() As String
            Get
                Return Me.strWorkdate
            End Get
        End Property
        Public ReadOnly Property GroupID() As Integer
            Get
                Return Me.iGroup_ID
            End Get
        End Property
        Public ReadOnly Property LineID() As Integer
            Get
                Return Me.iLineID
            End Get
        End Property
        Public ReadOnly Property Group_Desc() As String
            Get
                Return Me.strGroup_Desc
            End Get
        End Property
        Public ReadOnly Property AdminUserName() As String
            Get
                Return Me.adminName
            End Get
        End Property
        Public ReadOnly Property AdminPassword() As String
            Get
                Return Me.adminPass
            End Get
        End Property
        Public ReadOnly Property AdminLoginStatus() As Boolean
            Get
                Return Me.adminLogin
            End Get
        End Property

    End Class

End Namespace
