Namespace JournalMethods

    Module objJournal


        Public Function WriteToJournal(ByVal mDeviceID As Long) As Boolean

            '//Verify that a valid device ID was passed
            If mDeviceID = 0 Or IsDBNull(mDeviceID) = True Then
                MsgBox("A valid Device ID was NOT passed to this function. No record will be written. Please contact IT.", MsgBoxStyle.Critical, "ERROR")
                Return False
            End If

            Dim IDuser, IDtech, IDshift As Integer
            Dim EmpNumber As String
            Dim strStartDate As Date

            IDuser = PSS.Core.Global.ApplicationUser.IDuser
            IDtech = PSS.Core.Global.ApplicationUser.IDtech
            IDshift = PSS.Core.Global.ApplicationUser.IDShift
            EmpNumber = PSS.Core.Global.ApplicationUser.NumberEmp

            '//Complete previous record
            Dim ds As PSS.Data.Production.tdevicejournal
            Dim maxJournalID As Long = ds.GetMaxJIDbyUser(IDuser)
            System.Windows.Forms.Application.DoEvents()
            Dim closeTime As String = ds.GetTimeDataBeforeUpdate(maxJournalID)
            System.Windows.Forms.Application.DoEvents()

            If Len(Trim(closeTime)) < 1 Then
                '//Update the previous record with current date/time
                Dim newDateTime As String = Now

            End If



        End Function



        Public Function WriteCompleteTime(ByVal mDeviceID As Long) As Boolean



        End Function



    End Module

End Namespace
