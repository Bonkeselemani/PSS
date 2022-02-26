'Namespace BaseClasses
'    Public MustInherit Class MessagingBilling
'        Inherits BillingBase

'        'The base class for messaging billing, inheriting from BillingBase.  This class is abstract and cannot be instantiated.
'        Public Sub New(ByVal iCustID As Integer, ByVal iDeviceID As Integer)
'            MyBase.New(iCustID, iDeviceID)
'        End Sub

'        'Private Sub DBRDelete()
'        '    Try
'        '        DBRDelete(25)
'        '    Catch ex As Exception
'        '        Throw ex
'        '    End Try
'        'End Sub

'        'Private Sub DBRDelete(ByVal iBillCodeID As Integer)
'        '    Dim strSQL As String

'        '    Try
'        '        If iBillCodeID = 25 Then 'Drop DBR
'        '            strSQL = "UPDATE tdevice " & Environment.NewLine
'        '            strSQL &= "SET Device_DateShip = NULL, Device_ShipWorkDate = '0000-00-00', ship_id = NULL, Shift_ID_Ship = 0 " & Environment.NewLine
'        '            strSQL &= "WHERE Device_ID = " & Me.DeviceID.ToString

'        '            Me.DataProc.ExecuteNonQuery(strSQL)
'        '        End If
'        '    Catch ex As Exception
'        '        Throw ex
'        '    End Try
'        'End Sub
'    End Class
'End Namespace