Option Explicit On 

Namespace Buisness
    Public Class CreateRMA

        Private _objDataProc As DBQuery.DataProc

        '******************************************************************
        Public Sub New()
            Try
                Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '******************************************************************
        Public Function GetRMA(ByVal strRMA As String, ByVal iLocID As Integer) As DataTable
            Dim strSql As String
            Try
                strSql = "SELECT * FROM tworkorder " & Environment.NewLine
                strSql &= "WHERE loc_id = " & iLocID & Environment.NewLine
                strSql &= "AND WO_CustWO = '" & strRMA.Trim & "'" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function CreateNewRMA(ByVal iLocID As Integer, _
                                     ByVal strRMA As String, _
                                     ByVal iPO As Integer, _
                                     ByVal iCameWithFile As Integer, _
                                     ByVal iProdID As Integer, _
                                     ByVal iGroupID As Integer, _
                                     ByVal strUsrName As String, _
                                     ByVal iUsrID As Integer, _
                                     Optional ByVal iWOQty As Integer = 0) As Integer
            Dim objRec As PSS.Data.Production.Receiving
            Dim strSql As String
            Dim i As Integer
            Dim iWO_ID As Integer
            Try
                '***************************************
                '2: Create workorder
                '***************************************
                objRec = New PSS.Data.Production.Receiving()

                iWO_ID = objRec.InsertIntoTworkorder(strRMA, strRMA, iLocID, iProdID, iGroupID, , , iPO, , iWOQty, iCameWithFile)
                If iWO_ID = 0 Then
                    Throw New Exception("System has failed to create workorder for this RMA.")
                End If

                '***************************************
                '3: Create Tray
                '***************************************
                strSql = "INSERT INTO ttray (" & Environment.NewLine
                strSql &= "Tray_RecUser, Tray_RecUserID, WO_ID, Tray_Memo " & Environment.NewLine
                strSql &= ") VALUES (" & Environment.NewLine
                strSql &= "'" & strUsrName & "', " & iUsrID & ", " & iWO_ID & ", NULL );"
                i = Me._objDataProc.ExecuteNonQuery(strSql)
                If i = 0 Then
                    Throw New Exception("System has failed to create tray ID for this RMA.")
                End If

                Return iWO_ID
            Catch ex As Exception
                Throw ex
            Finally
                objRec = Nothing
            End Try
        End Function

        '******************************************************************
        Public Function GetOpenRMA(ByVal iLocID As Integer, _
                                   ByVal iProdID As Integer) As DataTable
            Dim strSql As String
            Try
                strSql = "SELECT WO_CustWO as 'RMA/WO',  WO_Date as 'RMA Date' " & Environment.NewLine
                strSql &= ", if(WO_CameWithFile = 1,  WO_Quantity, 0) as 'File Qty',  WO_RAQnty as 'Receipt Qty' " & Environment.NewLine
                strSql &= ", if(PO_ID is null, 0, PO_ID) as 'PO ID' " & Environment.NewLine
                strSql &= ", if(Group_Desc is null, '', Group_Desc) as 'Assign To Group', IF(WO_CameWithFile = 1, 'Yes', 'No') as 'ASN File?' " & Environment.NewLine
                strSql &= "FROM tworkorder " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lgroups ON tworkorder.Group_ID = lgroups.Group_ID " & Environment.NewLine
                strSql &= "WHERE loc_id = " & iLocID & " AND WO_Closed = 0 " & Environment.NewLine
                strSql &= "AND Prod_ID = " & iProdID & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************


    End Class
End Namespace