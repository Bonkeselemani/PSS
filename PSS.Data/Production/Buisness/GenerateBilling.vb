
Namespace Buisness
    Public Class GenerateBilling

        Dim objMisc As Production.Misc
        Dim strSQL As String

        '******************************************
        Public Sub New()
            objMisc = New Production.Misc()
        End Sub

        '******************************************
        Protected Overrides Sub Finalize()
            objMisc = Nothing
            MyBase.Finalize()
        End Sub

        '********************************************************************
        Public Function ab_ADD(ByVal DeviceID As Long, ByVal BillCodeID As Integer, ByVal iProd As Integer, _
                                            ByVal iUser_ID As Integer, _
                                            ByVal strUser_Name As String, _
                                            ByVal iEmpNo As Integer, _
                                            ByVal iShift_ID As Integer, _
                                            ByVal strWorkDate As String) As Boolean
            Dim myDev As New Device(DeviceID)

            Try
                If iProd = 1 Then 'MESSAGING DEVICE
                    myDev.AddPart(BillCodeID, BillCodeID, iUser_ID, iEmpNo, iShift_ID, strWorkDate)
                Else
                    myDev.AddPartCELL(BillCodeID, 0, 0, iUser_ID, iEmpNo, iShift_ID, strWorkDate)
                End If

                Return True
            Catch ex As Exception
                Return False
            Finally
                myDev.Update(iUser_ID, strUser_Name, iEmpNo, iShift_ID, strWorkDate)
                UpdateDate(DeviceID)
                myDev.Close()
                myDev = Nothing
            End Try
        End Function

        '********************************************************************
        Public Function ab_DELETE(ByVal DeviceID As Long, ByVal BillCodeID As Integer, _
                                            ByVal iUser_ID As Integer, _
                                            ByVal strUser_Name As String, _
                                            ByVal iEmpNo As Integer, _
                                            ByVal iShift_ID As Integer, _
                                            ByVal strWorkDate As String) As Boolean
            Dim myDev As New Device(DeviceID)

            Try
                If DeviceID = 0 Then Return False

                myDev.DeletePart(BillCodeID, iUser_ID, iEmpNo, iShift_ID, strWorkDate)
                Return True

            Catch ex As Exception
                Return False
            Finally
                myDev.Update(iUser_ID, strUser_Name, iEmpNo, iShift_ID, strWorkDate)
                UpdateDate(DeviceID)
                myDev.Close()
                myDev = Nothing
            End Try
        End Function

        '********************************************************************
        Private Sub UpdateDate(ByVal DeviceID As Long)
            Dim dt As DataTable
            Dim r As DataRow
            Dim pc As Integer

            Try
                If DeviceID = 0 Then Exit Sub

                Me.objMisc._SQL = "SELECT SUM(Dbill_ID) as pcount FROM tdevicebill WHERE Device_ID = " & DeviceID
                dt = Me.objMisc.GetDataTable
                r = dt.Rows(0)
                pc = r("pcount")
            Catch ex As Exception
                pc = 0
            Finally
                If pc > 0 Then
                    Me.objMisc._SQL = "UPDATE tdevice set device_datebill = now() WHERE device_id = " & DeviceID
                Else
                    Me.objMisc._SQL = "UPDATE tdevice set device_datebill = Null WHERE device_id = " & DeviceID
                End If
                Me.objMisc.ExecuteNonQuery()
                dt = Nothing
            End Try
        End Sub

        '********************************************************************
        'Validate billcode: 
        ' 1)make sure billcode existed in tpsmap
        ' 2)billcode is not an inactive billcode
        '********************************************************************
        Public Function ValidateBillcode(ByVal iBillcode_ID As Integer, _
                                         ByVal strModel_IDs As String) As Boolean
            Dim strSql As String
            Dim RModel, R1 As DataRow
            Dim i As Integer = 0
            Dim booValid As Boolean = True
            Dim dt1 As DataTable

            Try
                If strModel_IDs = "" Then
                    Throw New Exception("Invalid model list.")
                End If

                strSql = "SELECT tpsmap.* " & Environment.NewLine
                strSql &= "FROM tmodel " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tpsmap on tmodel.Model_ID = tpsmap.Model_ID and tmodel.Prod_ID = tpsmap.Prod_ID AND tpsmap.Billcode_ID = " & iBillcode_ID & Environment.NewLine
                strSql &= "WHERE tmodel.Model_ID IN ( " & strModel_IDs & ");"

                Me.objMisc._SQL = strSql
                dt1 = Me.objMisc.GetDataTable

                For Each R1 In dt1.Rows
                    If IsDBNull(R1("PSMap_ID")) Then
                        booValid = False
                    ElseIf IsDBNull(R1("Inactive")) Then
                        booValid = False
                    ElseIf R1("Inactive") = 1 Then
                        booValid = False
                    End If
                Next R1

                Return booValid

            Catch ex As Exception
                Throw ex
            Finally
                RModel = Nothing
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '********************************************************************
        'This function check if billcode already billed for given device
        '********************************************************************
        Public Function IsBillcodeExistedForDevice(ByVal iDevice_ID As Integer, _
                                                   ByVal iBillcode_ID As Integer) As Boolean
            Dim strSql As String
            Dim R1 As DataRow
            Dim i As Integer = 0
            Dim booExisted As Boolean = False
            Dim dt1 As DataTable

            Try
                strSql = "SELECT * " & Environment.NewLine
                strSql &= "FROM tdevicebill " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDevice_ID & Environment.NewLine
                strSql &= "AND Billcode_ID = " & iBillcode_ID & ";"

                Me.objMisc._SQL = strSql
                dt1 = Me.objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    booExisted = True
                End If

                Return booExisted

            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '********************************************************************

    End Class
End Namespace

