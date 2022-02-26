Option Explicit On 

Imports System.Windows.Forms

Namespace Buisness
    Public Class ScanDeviceToCostCenter
        Implements IDisposable

        'Const _strHost As String = "172.16.25.21"
        'Const _strDB As String = "production"
        'Const _strUser As String = "apuser"
        'Const _strPWEnc As String = "rqYO+SPdyd1g1JGhUXMm2w=="

        Dim _objDataProc As DBQuery.DataProc

        '***********************************************************************
        Public Sub New()
            'Dim strErr As String = ""
            'Dim strPWDec As String = ""

            Try
                'strPWDec = EncDec.Rijndael.Decrypt(Me._strPWEnc, strErr)

                'If strErr.Length > 0 Then
                '    MessageBox.Show(strErr & ".  Data processing discontinued.", "Error Decrypting Password", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                'Else
                '    Me._objDataProc = New DBQuery.DataProc(Me._strHost, Me._strDB, Me._strUser, strPWDec)
                'End If

                Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            Catch ex As Exception
            End Try
        End Sub

        '***********************************************************************
        Public Sub Dispose() Implements IDisposable.Dispose
            Me._objDataProc = Nothing
        End Sub

        ''***********************************************************************
        'Public Sub DisplayMessage(ByVal strMsg As String, Optional ByVal iStackLevel As Integer = 3, Optional ByVal bIsErrMsg As Boolean = True)
        '    Me._objDataProc.DisplayMessage(strMsg, iStackLevel, bIsErrMsg)
        'End Sub

        '***********************************************************************
        'Dispose dt
        '***********************************************************************
        Public Function DisposeDT(ByRef dt As DataTable)
            If Not IsNothing(dt) Then
                dt.Dispose()
                dt = Nothing
            End If
        End Function

        '***********************************************************************
        Public Function TransferDeviceIntoCostCenter(ByVal iCC_ID As Integer, _
                                                     ByVal iMachineGroupID As Integer, _
                                                     ByVal strSN As String) As Integer
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim i As Integer = 0

            Try
                strSql = "SELECT  tworkorder.Group_ID, tdevice.Device_ID, tdevice.cc_id, " & Environment.NewLine
                strSql &= "if(tcostcenter.cc_desc is null, '', tcostcenter.cc_desc ) as cc_desc, " & Environment.NewLine
                strSql &= "if(Group_Desc is null, '', Group_Desc ) as Group_Desc " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tcostcenter on tdevice.cc_id = tcostcenter.cc_id " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lgroups on tcostcenter.group_id = lgroups.group_id " & Environment.NewLine
                strSql &= "WHERE Device_SN = '" & strSN & "' " & Environment.NewLine
                strSql &= "AND ( Device_DateShip is null or Device_DateShip = '0000-00-00 00:00:00' or trim(Device_DateShip) = '' ) " & Environment.NewLine
                dt1 = Me._objDataProc.GetDataTable(strSql)

                If dt1.Rows.Count = 0 Then
                    Throw New Exception("Serial Number does not exist in WIP.")
                Else
                    If Not IsDBNull(dt1.Rows(0)("Group_ID")) Then
                        If dt1.Rows(0)("Group_ID") <> iMachineGroupID Then
                            Throw New Exception("Serial Number and machine don't belong to the same group.")
                        End If
                    End If
                    If Not IsDBNull(dt1.Rows(0)("cc_id")) Then
                        If dt1.Rows(0)("cc_id") <> 0 And dt1.Rows(0)("cc_id") = iCC_ID Then
                            Throw New Exception("Serial Number has already scanned in.")
                        ElseIf dt1.Rows(0)("cc_id") <> 0 And dt1.Rows(0)("cc_id") <> iCC_ID Then
                            Throw New Exception("Serial Number belongs to " & dt1.Rows(0)("Group_Desc").ToString.ToUpper & " cost center " & dt1.Rows(0)("cc_desc").ToString.ToUpper & ".")
                        End If
                    End If

                    strSql = "UPDATE tdevice SET cc_id = " & iCC_ID & " WHERE Device_ID = " & dt1.Rows(0)("Device_ID")
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                End If

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************


    End Class
End Namespace