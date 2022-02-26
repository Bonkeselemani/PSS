Option Explicit On 

Namespace Buisness
    Public Class MessTrayManipulate
        Private _objDataProc As DBQuery.DataProc

        '****************************************************************
        Public Sub New()
            Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
        End Sub

        '****************************************************************
        Protected Overrides Sub Finalize()
            Me._objDataProc = Nothing
            MyBase.Finalize()
        End Sub

        '****************************************************************
        Public Function GetDevicesByTrayID(ByVal iTrayID As Integer) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT tdevice.*, '0' as NewTray, Tray_Memo " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN ttray ON tdevice.Tray_ID = ttray.Tray_ID " & Environment.NewLine
                strSql &= "WHERE tdevice.Tray_ID = " & iTrayID & " " & Environment.NewLine
                strSql &= "AND Device_DateShip is null;"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************
        Public Function DivideTray(ByVal dtDevices As DataTable, _
                                   byval strUserName as String, _
                                   byval iUser_id as Integer) As Integer
            Dim strSql As String
            Dim i As Integer = 0
            Dim drArr() As DataRow
            Dim iNewTrayID As Integer = 0
            Dim strDevice_IDs As String = ""
            Dim objMessRec As PSS.Data.Buisness.MessReceive

            Try
                '*********************************
                'Get all device IDs fro new tray
                '*********************************
                drArr = dtDevices.Select("NewTray = 1")

                For i = 0 To drArr.Length - 1
                    If strDevice_IDs = "" Then
                        strDevice_IDs = drArr(i)("Device_ID")
                    Else
                        strDevice_IDs &= ", " & drArr(i)("Device_ID")
                    End If
                Next i

                i = 0

                '*********************************
                'Create new tray
                '*********************************
                strSql = "INSERT INTO ttray ( " & Environment.NewLine
                strSql &= "Tray_RecUserID, Tray_RecUser, WO_ID, Tray_Memo, Tray_OrgTrayID, Tray_AuditMemo " & Environment.NewLine
                strSql &= ") VALUES (" & Environment.NewLine
                strSql &= iUser_id & ", '" & strUserName & "', "
                If Not IsDBNull(dtDevices.Rows(0)("WO_ID")) Then
                    strSql &= dtDevices.Rows(0)("WO_ID") & ", "
                Else
                    strSql &= "null, "
                End If
                If Not IsDBNull(dtDevices.Rows(0)("Tray_Memo")) Then
                    strSql &= "'" & dtDevices.Rows(0)("Tray_Memo").ToString & "', "
                Else
                    strSql &= "null, "
                End If
                strSql &= dtDevices.Rows(0)("Tray_ID") & ", 'Divide Tray' );" & Environment.NewLine

                iNewTrayID = Me._objDataProc.idTransaction(strSql, "ttray")

                '*********************************
                'Assign new tray to devices
                '*********************************
                strSql = "UPDATE tdevice SET " & Environment.NewLine
                strSql &= "Tray_ID = " & iNewTrayID & " " & Environment.NewLine
                strSql &= "WHERE Tray_ID = " & dtDevices.Rows(0)("Tray_ID") & " " & Environment.NewLine
                strSql &= "AND Device_ID IN ( " & strDevice_IDs & ");"
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                '*********************************
                'Print traveler
                '*********************************
                objMessRec = New PSS.Data.Buisness.MessReceive()
                objMessRec.PrintRecReport(dtDevices.Rows(0)("Tray_ID"), 1)
                objMessRec.PrintRecReport(iNewTrayID, 1)

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dtDevices) Then
                    dtDevices.Dispose()
                    dtDevices = Nothing
                End If
                drArr = Nothing
                objMessRec = Nothing
            End Try
        End Function

        '****************************************************************



    End Class
End Namespace
