Option Explicit On 

Namespace HR
    Public Class EmployeeData


        '***************************************************************************
        Public Shared Function GetEmployeeData() As DataTable
            Dim strSql As String
            Dim objDataProc As New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

            Try
                strSql = "SELECT EENumLegiantFormat as 'EE #', employeenum as 'Lock #', LastName, FirstName " & Environment.NewLine
                strSql &= ", PayGroupID,  A.DepartmentID, DepartmentDesc, A.ShiftID, ShiftDesc" & Environment.NewLine
                strSql &= ", if(Active = 1, 'Yes', 'No') as Active" & Environment.NewLine
                strSql &= "FROM security.tlegianteedata A" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN security.tlegiantdeptdata B ON A.DepartmentID = B.DepartmentID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN security.tlegiantshiftdata C ON A.ShiftID = C.ShiftID " & Environment.NewLine
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '***************************************************************************

    End Class
End Namespace