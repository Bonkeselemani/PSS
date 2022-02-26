
Namespace Buisness
    Public Class WIPFlow

        Private objMisc As Production.Misc

        '**********************************************************
        Public Sub New()
            objMisc = New Production.Misc()
        End Sub

        Protected Overrides Sub Finalize()
            objMisc = Nothing
            MyBase.Finalize()
        End Sub

        '**********************************************************
        Public Function GetDeviceInfo(ByVal strIMEI As String) As DataTable
            Dim strsql As String = ""

            Try

                'Get device information
                strsql = "select tlocation.cust_id, tdevice.* from tdevice " & Environment.NewLine
                strsql &= "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & Environment.NewLine
                strsql &= "where tdevice.Device_SN = '" & strIMEI & "' and  " & Environment.NewLine
                strsql &= "tdevice.Device_DateShip is null " & Environment.NewLine
                strsql &= "order by tdevice.device_id desc;"

                Me.objMisc._SQL = strsql
                Return Me.objMisc.GetDataTable

            Catch ex As Exception
                Throw New Exception("Business.WipFlow.GetDeviceInfo():: " & ex.ToString)
            End Try
        End Function

        '**********************************************************
        Public Function IsPreviousStepOperated(ByVal iLineID As Integer, _
                                            ByVal iCustID As Integer, _
                                            ByVal iModelID As Integer, _
                                            ByVal iMachineGroupID As Integer, _
                                            ByVal iDeviceID As Integer) As Boolean
            Dim strsql As String = ""
            Dim dt1 As DataTable

            Try
                strsql = "SELECT * from twipjournal " & Environment.NewLine
                strsql &= "where device_id = " & iDeviceID & " and " & Environment.NewLine
                strsql &= "Line_id = " & iLineID & " and " & Environment.NewLine
                strsql &= "Model_id = " & iModelID & " and " & Environment.NewLine
                strsql &= "Cust_id = " & iCustID & ";"
                Me.objMisc._SQL = strsql
                dt1 = Me.objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Throw New Exception("Business.WipFlow.IsPreviousStepOperated():: " & ex.ToString)
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '**********************************************************
        Public Function WriteToWIPJournal(ByVal iLineID As Integer, _
                                            ByVal iCustID As Integer, _
                                            ByVal iModelID As Integer, _
                                            ByVal iMachineGroupID As Integer, _
                                            ByVal strmachineName As String, _
                                            ByVal iUserID As Integer, _
                                            ByVal strWorkDate As String, _
                                            ByVal iDeviceID As Integer, _
                                            ByVal iPassFail As Integer) As Integer
            Dim strsql As String = ""
            Dim dt1 As DataTable
            Dim i As Integer = 0
            Dim objGeneric As New PSS.Data.Buisness.Generic()
            Dim strTimeStamp As String = objGeneric.MySQLServerDateTime(1)
            'PSS.Core.Global.ApplicationUser.Workdate
            Dim iWC_Location_ID As Integer = 0


            Try
                'Get WCLocation_ID
                strsql = "select WCLocation_ID from lwclocation where WC_Machine = '" & strmachineName & "';"
                Me.objMisc._SQL = strsql
                dt1 = Me.objMisc.GetDataTable
                If dt1.Rows.Count > 0 Then
                    iWC_Location_ID = dt1.Rows(0)("WCLocation_ID")
                End If


                strsql = "INSERT INTO twipjournal " & Environment.NewLine
                strsql &= "(" & Environment.NewLine
                strsql &= "Cust_ID, " & Environment.NewLine
                strsql &= "Model_ID, " & Environment.NewLine
                strsql &= "Line_ID, " & Environment.NewLine
                strsql &= "WC_Location_ID, " & Environment.NewLine
                strsql &= "User_ID, " & Environment.NewLine
                strsql &= "WJ_Result, " & Environment.NewLine
                strsql &= "WJ_WorkDate, " & Environment.NewLine
                strsql &= "WJ_DateTime, " & Environment.NewLine
                strsql &= "MachineGroup_ID, " & Environment.NewLine
                strsql &= "Device_ID " & Environment.NewLine
                strsql &= ") " & Environment.NewLine
                strsql &= "VALUES " & Environment.NewLine
                strsql &= "(" & Environment.NewLine
                strsql &= iCustID & ", " & Environment.NewLine
                strsql &= iModelID & ", " & Environment.NewLine
                strsql &= iLineID & ", " & Environment.NewLine
                strsql &= iWC_Location_ID & ", " & Environment.NewLine
                strsql &= iUserID & ", " & Environment.NewLine
                '********************************************
                'iPassFail has value of 1 = PASS or 2 = FAIL
                strsql &= iPassFail & ", " & Environment.NewLine
                '********************************************
                strsql &= "'" & strWorkDate & "', " & Environment.NewLine
                strsql &= "'" & strTimeStamp & "', " & Environment.NewLine
                strsql &= iMachineGroupID & ", " & Environment.NewLine
                strsql &= iDeviceID & Environment.NewLine
                strsql &= ");"

                Me.objMisc._SQL = strsql
                i = Me.objMisc.ExecuteNonQuery

                Return i
            Catch ex As Exception
                Throw New Exception("Business.WipFlow.InsertToWIPJournal():: " & ex.ToString)
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                objGeneric = Nothing
            End Try
        End Function

        '**********************************************************
        Public Function UpdateCelloptWIPOwner(ByVal iWipOwner As Integer, _
                                              ByVal iDeviceID As Integer) As Integer


            Dim strsql As String = ""
            Dim i As Integer = 0
            Dim objGeneric As New PSS.Data.Buisness.Generic()
            'Dim strTimeStamp As String = Format(objGeneric.MySQLServerDateTime(1), "yyyy-MM-dd hh:mm:ss")
            Dim strTimeStamp As String = objGeneric.MySQLServerDateTime(1)

            Try

                'Update Tcellopt
                strsql = "UPDATE tcellopt SET Cellopt_WIPOwnerOld = Cellopt_WIPOwner, " & Environment.NewLine
                strsql &= "Cellopt_WIPOwner = " & iWipOwner & ", " & Environment.NewLine
                strsql &= "Cellopt_WIPEntryDt = '" & strTimeStamp & "' " & Environment.NewLine
                strsql &= "WHERE device_id = " & iDeviceID & ";"

                Me.objMisc._SQL = strsql
                i = Me.objMisc.ExecuteNonQuery

                Return i
            Catch ex As Exception
                Throw New Exception("Business.WipFlow.UpdateCelloptWIPOwner():: " & ex.ToString)
            Finally
                objGeneric = Nothing
            End Try
        End Function

        '**********************************************************
        Public Function GetCurrentWIPOwner(ByVal iDevice_id As Integer) As Integer
            Dim strsql As String = ""
            Dim dt1 As DataTable
            Dim iCurWipOwner As Integer = 0

            Try
                strsql = "select Cellopt_WIPOwner from tcellopt where device_id = " & iDevice_id & ";"
                Me.objMisc._SQL = strsql
                dt1 = Me.objMisc.GetDataTable
                If dt1.Rows.Count > 0 Then
                    iCurWipOwner = dt1.Rows(0)("Cellopt_WIPOwner")
                End If

                Return iCurWipOwner
            Catch ex As Exception
                Throw New Exception("Business.WipFlow.GetCurrentWIPOwner():: " & ex.ToString)
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '**********************************************************
        Public Function GetQCType(ByVal iMachineGroup As Integer) As DataTable
            Dim strsql As String = ""
            Dim dt1 As DataTable

            Try

                strsql = "select lgroups.QCType_id, lqctype.QCType " & Environment.NewLine
                strsql &= "from lgroups inner join lqctype on lgroups.QCType_ID = lqctype.QCType_ID " & Environment.NewLine
                strsql &= "where lgroups.group_id = " & iMachineGroup & ";"
                Me.objMisc._SQL = strsql
                dt1 = Me.objMisc.GetDataTable

                Return dt1

            Catch ex As Exception
                Throw New Exception("Business.WipFlow.GetCurrentWIPOwner():: " & ex.ToString)
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try


        End Function

    End Class
End Namespace