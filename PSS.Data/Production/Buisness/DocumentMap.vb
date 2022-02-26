Option Explicit On 
Imports System.IO

Namespace Buisness.Document
    Public Class DocumentMap
        Private _objDataProc As DBQuery.DataProc
        Private _objDocMap As PSS.Data.Buisness.Document.DocumentMap
        


#Region "Constructor/Destructor"

        '******************************************************************
        Public Sub New()
            Try
                Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '******************************************************************
        Protected Overrides Sub Finalize()
            Me._objDataProc = Nothing
            MyBase.Finalize()
        End Sub

        '******************************************************************
#End Region

        '******************************************************************
        Public Function GetDocMapStation() As DataTable
            Dim strSql As String
            Dim dt As DataTable

            Try
                strSql = "SELECT DISTINCT 1 as id, StationType " & Environment.NewLine
                strSql &= "FROM tdoclocmap " & Environment.NewLine
                strSql &= "WHERE dm_Active = 1 " & Environment.NewLine
                strSql &= "ORDER BY StationType"
                dt = Me._objDataProc.GetDataTable(strSql)
                dt.LoadDataRow(New Object() {"0", "--Select--"}, False)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        Public Function GetDocMapStation(ByVal DeptID As Integer) As DataTable
            Dim strSql As String
            Dim dt As DataTable

            Try
                strSql = "SELECT DISTINCT 1 as id, StationType " & Environment.NewLine
                strSql &= "FROM tdoclocmap " & Environment.NewLine
                strSql &= "WHERE DepartmentID = " & DeptID & " And dm_Active = 1 " & Environment.NewLine
                strSql &= "ORDER BY StationType"
                dt = Me._objDataProc.GetDataTable(strSql)
                dt.LoadDataRow(New Object() {"0", "--Select--"}, False)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetDocMapModel(ByVal strStationType As String) As DataTable
            Dim strSql As String
            Dim dt As DataTable

            Try
                strSql = "SELECT DISTINCT 1 as id, ModelGeneral " & Environment.NewLine
                strSql &= "FROM tdoclocmap " & Environment.NewLine
                strSql &= "WHERE StationType = '" & strStationType & "'" & Environment.NewLine
                strSql &= "AND dm_Active = 1 " & Environment.NewLine
                strSql &= "ORDER BY ModelGeneral"
                dt = Me._objDataProc.GetDataTable(strSql)
                dt.LoadDataRow(New Object() {"0", "--Select--"}, False)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function
        '******************************************************************
        Public Function GetDocMapModel(ByVal DeptID As Integer, ByVal strStationType As String) As DataTable
            Dim strSql As String
            Dim dt As DataTable

            Try
                strSql = "SELECT DISTINCT 1 as id, ModelGeneral " & Environment.NewLine
                strSql &= "FROM tdoclocmap " & Environment.NewLine
                strSql &= "WHERE StationType = '" & strStationType & "' And DepartmentID = " & DeptID & Environment.NewLine
                strSql &= "AND dm_Active = 1 " & Environment.NewLine
                strSql &= "ORDER BY ModelGeneral"
                dt = Me._objDataProc.GetDataTable(strSql)
                dt.LoadDataRow(New Object() {"0", "--Select--"}, False)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetDocMapDocName(ByVal strStationType As String, _
                                         ByVal strModel As String) As DataTable
            Dim strSql As String
            Dim dt As DataTable

            Try
                strSql = "SELECT DISTINCT 1 as id, dm_Name " & Environment.NewLine
                strSql &= "FROM tdoclocmap " & Environment.NewLine
                strSql &= "WHERE StationType = '" & strStationType & "'" & Environment.NewLine
                strSql &= "AND ModelGeneral = '" & strModel & "'" & Environment.NewLine
                strSql &= "AND dm_Active = 1 " & Environment.NewLine
                strSql &= "ORDER BY dm_Name"
                dt = Me._objDataProc.GetDataTable(strSql)
                dt.LoadDataRow(New Object() {"0", "--Select--"}, False)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function
        '******************************************************************
        Public Function GetDocMapDocName(ByVal DeptID As Integer, ByVal strStationType As String, _
                                         ByVal strModel As String) As DataTable
            Dim strSql As String
            Dim dt As DataTable

            Try
                strSql = "SELECT DISTINCT 1 as id, dm_Name " & Environment.NewLine
                strSql &= "FROM tdoclocmap " & Environment.NewLine
                strSql &= "WHERE DepartmentID = " & DeptID & " And StationType = '" & strStationType & "'" & Environment.NewLine
                strSql &= "AND ModelGeneral = '" & strModel & "'" & Environment.NewLine
                strSql &= "AND dm_Active = 1 " & Environment.NewLine
                strSql &= "ORDER BY dm_Name"
                dt = Me._objDataProc.GetDataTable(strSql)
                dt.LoadDataRow(New Object() {"0", "--Select--"}, False)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function
        '******************************************************************
        Public Function GetDocMapFilePathAndName(ByVal strStation As String, _
                                                 ByVal strModelGeneral As String, _
                                                 ByVal strDocName As String) As String
            Dim strSql, strDocPath As String
            Dim dt As DataTable

            Try
                strSql = "SELECT * " & Environment.NewLine
                strSql &= "FROM tdoclocmap " & Environment.NewLine
                strSql &= "WHERE StationType = '" & strStation & "'" & Environment.NewLine
                strSql &= "ANd ModelGeneral = '" & strModelGeneral & "'" & Environment.NewLine
                strSql &= "ANd dm_Name = '" & strDocName & "'" & Environment.NewLine
                strSql &= "ANd dm_Active = 1 " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                strDocPath = ""
                If dt.Rows.Count > 0 Then
                    strDocPath = dt.Rows(0)("dm_path") & "\" & dt.Rows(0)("dm_fileName")
                End If

                Return strDocPath
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetDepartment() As DataTable
            Dim strSql As String
            Dim dt As DataTable

            Try
                strSql = "SELECT DepartmentID, DepartmentDesc FROM security.tlegiantdeptdata WHERE Active = 1 ORDER BY DepartmentDesc; "
                dt = Me._objDataProc.GetDataTable(strSql)
                dt.LoadDataRow(New Object() {"0", "--Select--"}, False)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function


        '*******************************************************************
        Public Function GetDeptDoc(ByVal DeptID As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim sdim As String

            Try
                strSql = "SELECT DepartmentDesc AS 'Department Desc', StationType AS 'Station Type', ModelGeneral AS 'Model/General'," & Environment.NewLine
                strSql &= "dm_Name AS 'Document Name', dm_path AS 'Directory Path', dm_FileName AS 'File Name', dm_id AS 'DMID'" & Environment.NewLine
                strSql &= ", if( dm_UpdDT is null, '', dm_UpdDT) as 'Update Date' " & Environment.NewLine
                strSql &= ", if(user_fullname is null, '', user_fullname) as 'Update By', dm_Active as 'Active'" & Environment.NewLine
                strSql &= "FROM tdoclocmap a" & Environment.NewLine
                strSql &= "INNER JOIN security.tlegiantdeptdata b ON a.DepartmentID = b.DepartmentID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN security.tusers c ON a.dm_UpdUsrID = c.User_ID" & Environment.NewLine
                strSql &= "WHERE a.DepartmentID = " & DeptID & " ORDER BY StationType;"
                dt = Me._objDataProc.GetDataTable(strSql)
                Return dt



            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)

            End Try
        End Function

        '***************************************************
        Public Function GetModelGeneral(ByVal booAddSelectRow As Boolean, _
                                  Optional ByVal iProd_ID As Integer = 0) As DataTable
            Dim dt As DataTable
            Dim strSql As String = ""

            Try
                strSql = "Select distinct Model_id, Model_desc, Model_MotoSku "
                strSql &= " from tmodel "
                If iProd_ID > 0 Then strSql &= " where prod_id = " & iProd_ID & " "
                strSql &= " order by Model_Desc;"
                dt = Me._objDataProc.GetDataTable(strSql)

                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "General"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '*******************************************************************
        Public Function UpdateDocMap(ByVal DMID As Integer, ByVal deptid As Integer, _
                    ByVal strDirectoryPath As String, ByVal strFileName As String, ByVal dmName As String, _
                    ByVal userid As Integer, ByVal modgeneral As String, ByVal stationtype As String) As Integer
            Dim dt As DataTable
            ' dt = Me._objDocMap.GetDeptDoc(
            Dim dmi As Integer = DMID
            Dim strSql As String = ""
            Try
                If dmi > 0 Then
                    'strSql = "Update tdoclocmap SET dm_path = '" & strDirectoryPath & "', dm_FileName = '" & strFileName & "' " & Environment.NewLine
                    strSql = "Update tdoclocmap SET dm_Active =0 where dm_id = " & DMID & "; "
                    'dm_id, DepartmentID, StationType, ModelGeneral, dm_Name, dm_path, dm_FileName, dm_UpdDT, dm_UpdUsrID, dm_Active
                End If

                InsertintoDocMap(userid, deptid, modgeneral, dmName, strDirectoryPath, strFileName, stationtype)
                'strSql &= "where dm_id = " & DMID & ";"


                Return _objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '*******************************************************************
        Public Function DisableDocMap(ByVal DMID As Integer, ByVal userid As Integer) As Integer
            Dim dt As DataTable
            ' dt = Me._objDocMap.GetDeptDoc(
            Dim dmi As Integer = DMID
            Dim strSql As String = ""
            Try
                If dmi > 0 Then
                    strSql = "Update tdoclocmap SET dm_Active =0,dm_UpdUsrID=" & userid & ",dm_UpdDT= now() where dm_id = " & DMID & "; "
                End If

                Return _objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************
        Public Function InsertintoDocMap(ByVal iUsrID As Integer, _
                                         ByVal iDeptID As Integer, _
                                         ByVal strModel As String, _
                                         ByVal strDocName As String, _
                                         ByVal strPath As String, _
                                         ByVal strFileName As String, _
                                         Optional ByVal strStation As String = "") As Integer

            Dim strSql As String = ""
            Try

                strSql = "INSERT INTO tdoclocmap (DepartmentID, StationType, ModelGeneral, dm_Name, dm_path, dm_FileName , dm_UpdDT, dm_UpdUsrID)" & Environment.NewLine
                strSql &= "VALUES " & Environment.NewLine
                strSql &= "(" & iDeptID & ",'" & strStation & "','" & strModel & "'," & Environment.NewLine
                strSql &= "'" & strDocName & "','" & strPath & "','" & strFileName & "', now(), " & iUsrID & ");"
                Return _objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

    End Class
End Namespace