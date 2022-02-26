'Namespace Billing
'    Public Class BillingChain
'        Public Enum BillingClassID
'            IDAmericanMessaging = 1
'        End Enum

'        'Private Delegate Sub BillingClass(ByVal iCustID As Integer, ByVal iDeviceID As Integer)
'        Private _objBillingClass() As Object

'        Public Sub New(ByVal iCustID As Integer, ByVal iDeviceIDs() As Integer, ByVal bcID As BillingClassID)
'            Dim i As Integer

'            Try
'                If iDeviceIDs.Length > 0 Then
'                    Select Case bcID
'                        Case BillingClassID.IDAmericanMessaging
'                            'Me._objBillingClass = New BillingClass(AddressOf AmericanMessaging(iCustID, iDeviceIDs(0)))
'                            Me._objBillingClass = New AmericanMessaging(iDeviceIDs.Length) {}

'                            For i = 0 To iDeviceIDs.Length - 1
'                                Me._objBillingClass(i) = New AmericanMessaging(iCustID, iDeviceIDs(i))
'                            Next i
'                    End Select
'                End If
'            Catch ex As Exception
'            End Try
'        End Sub

'        Public Function GetBilledCodes(ByVal iDeviceID As Integer) As DataTable
'            Dim i As Integer
'            'Dim en As IEnumerator
'            Dim dt As DataTable

'            Try
'                'en = Me._objBillingClass.GetEnumerator

'                'While en.MoveNext
'                '    If en.Current.DeviceID() = iDeviceID Then
'                '        dt = en.Current.BilledCodes()

'                '        Exit While
'                '    End If
'                'End While

'                For i = 0 To Me._objBillingClass.Length - 1
'                    If Me._objBillingClass(i).DeviceID() = iDeviceID Then
'                        dt = Me._objBillingClass(i).BilledCodes()

'                        Exit For
'                    End If
'                Next

'                Return dt
'            Catch ex As Exception
'                Throw ex
'            Finally
'                If Not IsNothing(dt) Then
'                    dt.Dispose()
'                    dt = Nothing
'                End If
'            End Try
'        End Function

'        Public Function GetDeviceDetails(ByVal iDeviceID As Integer) As DataTable
'            Dim i As Integer
'            Dim dt As DataTable

'            Try
'                For i = 0 To Me._objBillingClass.Length - 1
'                    If Me._objBillingClass(i).DeviceID() = iDeviceID Then
'                        dt = Me._objBillingClass(i).DeviceDetails()

'                        Exit For
'                    End If
'                Next

'                Return dt
'            Catch ex As Exception
'                Throw ex
'            Finally
'                If Not IsNothing(dt) Then
'                    dt.Dispose()
'                    dt = Nothing
'                End If
'            End Try
'        End Function
'    End Class
'End Namespace
