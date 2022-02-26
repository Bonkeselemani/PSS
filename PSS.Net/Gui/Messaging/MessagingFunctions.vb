Option Explicit On 

Namespace Messaging
    Public Class Functions

        '****************************************************************************************************
        Public Shared Function DBRMessDevices(ByVal strInputType As String, _
                                          ByVal strItem_IDs As String, _
                                          ByVal iDBRReson As Integer) As Integer
            Dim iMessDBR_BillcodeID As Integer = 25
            Dim objMisc As New PSS.Data.Buisness.Misc()
            Dim objMessAdmin As PSS.Data.Buisness.MessAdmin
            Dim objDevice As PSS.Rules.Device
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim i As Integer = 0

            Try
                objMessAdmin = New PSS.Data.Buisness.MessAdmin()
                dt1 = objMessAdmin.GetEditDeviceInfo(strInputType, strItem_IDs)

                For Each R1 In dt1.Rows
                    'Set DBR Reason
                    i = objMisc.UPD(R1("Device_ID"), iDBRReson)

                    'Bill DBR
                    If PSS.Data.Buisness.Generic.IsBillcodeExisted(R1("Device_ID"), iMessDBR_BillcodeID) = False Then
                        objDevice = New PSS.Rules.Device(R1("Device_ID"))
                        objDevice.AddPart(iMessDBR_BillcodeID)
                        objDevice.Update()
                        If Not IsNothing(objDevice) Then
                            objDevice.Dispose() : objDevice = Nothing
                        End If
                    End If
                Next R1

                Return dt1.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                objMisc = Nothing : objMessAdmin = Nothing : R1 = Nothing
                If Not IsNothing(objDevice) Then
                    objDevice.Dispose() : objDevice = Nothing
                End If
                PSS.Data.Buisness.Generic.DisposeDT(dt1)
            End Try
        End Function

        '****************************************************************************************************
        Public Shared Function UnBillMessDBRDevices(ByVal strInputType As String, ByVal strInputItems_id As String) As Integer
            ' Me.GstrWorkDate, Me.GstrUserName, Me.GiUserID, Me.GiEmpNo, Me.GiShiftID) as Integer
            Dim iMessDBR_BillcodeID As Integer = 25
            Dim objDevice As PSS.Rules.Device
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim objMessAdmin As PSS.Data.Buisness.MessAdmin

            Try
                objMessAdmin = New PSS.Data.Buisness.MessAdmin()
                dt1 = objMessAdmin.GetEditDeviceInfo(strInputType, strInputItems_id)

                For Each R1 In dt1.Rows
                    'Delete DBR Code
                    objMessAdmin.DeleteDeviceCode(R1("Device_ID"))

                    'Unbill DBR
                    If PSS.Data.Buisness.Generic.IsBillcodeExisted(R1("Device_ID"), iMessDBR_BillcodeID) Then
                        objDevice = New PSS.Rules.Device(R1("Device_ID"))
                        objDevice.DeletePart(iMessDBR_BillcodeID)
                        objDevice.Update()
                        If Not IsNothing(objDevice) Then
                            objDevice.Dispose() : objDevice = Nothing
                        End If
                    End If
                Next R1

                'Reset ship information in tdevice
                objMessAdmin.ResetShipInfo(strInputType, strInputItems_id)

                Return dt1.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(objDevice) Then
                    objDevice.Dispose() : objDevice = Nothing
                End If
                R1 = Nothing : PSS.Data.Buisness.Generic.DisposeDT(dt1)
            End Try
        End Function

        '****************************************************************************************************

    End Class
End Namespace