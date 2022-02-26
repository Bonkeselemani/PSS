Option Explicit On 

Namespace Buisness

    Public Class AquisProdRec
        Private _objDataProc As DBQuery.DataProc

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

        '*********************************************************************************************************
        Public Function GetWarehouseItemByBoxName(ByVal strBoxName As String) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT B.*, A.Closed " & Environment.NewLine
                strSql &= "FROM warehouse.warehouse_box A " & Environment.NewLine
                strSql &= "INNER JOIN warehouse.warehouse_items B ON A.WB_ID = B.WB_ID " & Environment.NewLine
                strSql &= "WHERE A.Box_Name = '" & strBoxName & "'" & Environment.NewLine
                strSql &= "AND Device_ID = 0"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************************************************
        Public Function GetWarehouseItemBySN(ByVal strSN As String) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT * " & Environment.NewLine
                strSql &= "FROM warehouse.warehouse_items A " & Environment.NewLine
                strSql &= "WHERE A.Serial = '" & strSN & "'" & Environment.NewLine
                strSql &= "AND Device_ID = 0" 'the Device_ID default =0. If >0, then it has been move out from warehouse
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************************************************
        'Public Function GetDeviceRecCountBySN(ByVal strSN As String) As Integer
        '    Dim strSql As String = ""
        '    Dim recNum As Integer = 0
        '    Dim dTB As DataTable

        '    Try
        '        strSql = "SELECT * " & Environment.NewLine
        '        strSql &= "FROM tDevice A " & Environment.NewLine
        '        strSql &= "WHERE A.Device_SN = '" & strSN & "'"

        '        dTB = Me._objDataProc.GetDataTable(strSql)
        '        Return dTB.Rows.Count
        '        dTB = Nothing

        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Function

        '*********************************************************************************************************
        Public Function GetItemsHasDeviceID(ByVal iWarehouseItemIDs As String) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT * " & Environment.NewLine
                strSql &= "FROM warehouse.warehouse_items A " & Environment.NewLine
                strSql &= "WHERE WI_ID IN (" & iWarehouseItemIDs & ")" & Environment.NewLine
                strSql &= "AND Device_ID > 0"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************************************************
        Public Function UpdateDeviceIDOfITem(ByVal iWarehouseItemID As Integer, ByVal iDeviceID As Integer) As Integer
            Dim strSql As String = ""
            Try
                strSql = "UPDATE warehouse.warehouse_items SET Device_ID = " & iDeviceID & Environment.NewLine
                strSql &= "WHERE WI_ID = " & iWarehouseItemID & Environment.NewLine
                strSql &= "AND Device_ID = 0"
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************************************************
        Public Function GetDevicesInWip(ByVal iLocID As Integer, ByVal strSNs As String) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT Device_SN FROM tdevice " & Environment.NewLine
                strSql &= "WHERE Loc_ID = " & iLocID & Environment.NewLine
                strSql &= "AND Device_SN IN (" & strSNs & ") AND device_dateship is null " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************************************************
    End Class
End Namespace