Imports System.IO
Imports System.Text


Imports PSS.Data.Buisness.MotoAsc


Namespace rules


    Public Class MotoAscClaim

        Private Beg_Week As Date
        Private End_Week As Date

        Private File_Name As String = "PSS001-" & ASCDate(Now.Date, 3) & ".txt"
        Private File_Path As String = "C:\Invoice ASC Files\"

        Private s As StringBuilder = New StringBuilder()

        Private r As DataRow, r2 As DataRow

        Public Sub New(ByVal startDate As Date, ByVal endDate As Date)
            Me.Beg_Week = startDate
            Me.End_Week = endDate
        End Sub

        Public Sub Run()
            s.Append("HDR|ASC-CLAIM|PSS|PSS001|PSS" & Format(Now.Date, "mmddyy") & vbCrLf)

            Dim iCount As Integer = 0
            Dim iSum As Double = 0.0

            For Each r In GetInitialData(Beg_Week, End_Week).Rows

                iCount += 1

                Dim MotoCode As String = PSS.Data.Buisness.MotoAsc.GetCompanyData(r("Loc_ID"))

                s.Append(r("Device_SN") & "|" & MotoCode & "|" & ASCDate(r("Device_DateRec"), 1) & "|" & _
                              ASCDate(r("Device_DateRec"), 2) & "|" & ASCDate(r("Device_DateShip"), 1) & "|" & _
                              ASCDate(r("Device_DateShip"), 2) & "|")


                Dim dt As DataTable = GetRepCodes(r("Device_ID"))
                For Each r2 In dt.Rows
                    s.Append(Trim(r2(0)) & ",")
                Next
                s.Remove(s.Length - 1, 1)

                s.Append("|")

                dt = GetPartData(r("Device_ID"), r("Model_ID"))
                For Each r2 In dt.Rows
                    s.Append(Trim(r2(0)) & ",")
                Next
                s.Remove(s.Length - 1, 1)

                s.Append("|")

                dt = GetFailCodes(r("Device_ID"))
                For Each r2 In dt.Rows
                    s.Append(Trim(r2(0)) & ",")
                Next
                s.Remove(s.Length - 1, 1)

                dt = Nothing

                iSum += PSS.Data.Buisness.MotoAsc.GetSum(r(0))

                s.Append(vbCrLf)
            Next

            s.Append("TRL|" & iCount & "|" & Format(ISum, "######0.00"))

            If Directory.Exists(File_Path) = False Then Directory.CreateDirectory(File_Path)
            If File.Exists(File_Path & File_Name) = True Then File.Delete(File_Path & File_Name)
            Dim f As New System.IO.FileStream(File_Path & File_Name, FileMode.OpenOrCreate)
            f.Write(System.Text.Encoding.Default.GetBytes(s.ToString), 0, s.Length)
            f.Close()
            MsgBox("The process has finished you may access the files generated from you computer in " & _
                        vbCrLf & File_Path & ".")

        End Sub

        Private Function ASCDate(ByVal d As DateTime, ByVal type As Integer) As String
            If type = 1 Then
                Return Format(d.Month, "00") & "/" & Format(d.Day, "00") & "/" & Right(d.Year, 2)
            ElseIf type = 2 Then
                Return FormatDateTime(d, DateFormat.LongTime).ToString()
            ElseIf type = 3 Then
                Return Format(d.Month, "00") & "_" & Format(d.Day, "00") & "_" & Right(d.Year, 2)
            End If
        End Function

    End Class

End Namespace
