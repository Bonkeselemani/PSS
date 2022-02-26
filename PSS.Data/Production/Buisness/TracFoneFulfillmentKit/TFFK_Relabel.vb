Option Explicit On 

Imports System
Imports System.Data
Imports System.Text
Imports MySql.Data

Namespace Buisness.TracFoneFulfillmentKit
    Public Class TFFK_Relabel

        Private _objDataProc As mySQL5

#Region "Constructor/Destructor"

        '******************************************************************
        Public Sub New()
            Try
                Me._objDataProc = New mySQL5()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '******************************************************************
        Protected Overrides Sub Finalize()
            Me._objDataProc = Nothing
            MyBase.Finalize()
        End Sub

#End Region

        '******************************************************************************************************
        Public Function GetDeviceSNInWIP(ByVal strSN As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT A.WI_ID, A.Device_ID, A.Serial as Device_SN, A.Model_ID, B.Model_Desc FROM warehouse.warehouse_items A " & Environment.NewLine
                strSql &= "INNER JOIN production.tmodel_Items B ON A.Model_ID = B.Model_ID " & Environment.NewLine
                strSql &= "WHERE SoDetailsID = 0 AND serial = '" & strSN & "' ;" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************
        Public Function GetWIPJobQty(ByVal ModelID As String) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT  Count(*) as cnt FROM warehouse.warehouse_items A " & Environment.NewLine
                strSql &= "WHERE SoDetailsID = 0 AND A.Model_ID = " & ModelID & Environment.NewLine
                strSql &= "Group by A.Model_ID ;"
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count <> 1 Then
                    Return 0
                ElseIf dt.Rows.Count = 1 Then
                    Return Convert.ToInt32(dt.Rows(0)(0))
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************************************************
        Public Function GetAvailableModelsToConvert(ByVal FromModelID As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT A.From_Model_ID, A.To_Model_ID, A.Qty_Limit " & Environment.NewLine
                strSql &= ", A.Active_EndDate, C.Model_Desc as 'From Model', C.Model_Desc as 'To Model'" & Environment.NewLine
                strSql &= "FROM edi.ttffk_model_relabel_map A " & Environment.NewLine
                strSql &= "INNER JOIN production.tmodel_Items B ON A.From_Model_ID = B.Model_ID" & Environment.NewLine
                strSql &= "INNER JOIN production.tmodel_Items C ON A.To_Model_ID = C.Model_ID" & Environment.NewLine
                strSql &= "WHERE A.From_Model_ID = " & FromModelID & " AND IsActive = 1 " & Environment.NewLine
                strSql &= "AND date_format(now(), '%Y-%m-%d') <= Active_EndDate  ;"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************
        Public Function UpdateRelabel(ByVal dtDevices As DataTable, ByVal Fr_Model_ID As Integer, _
                                      ByVal To_Model_ID As Integer, ByVal iUserID As Integer) As Integer
            Dim strSql As String = ""
            Dim strSqlVal As String = ""
            Dim i As Integer
            Dim deviceIDs As String = String.Empty
            Dim R1 As DataRow

            Try
                For Each R1 In dtDevices.Rows
                    If (deviceIDs.Length > 0) Then
                        deviceIDs &= ", "
                    End If
                    deviceIDs &= R1("Device_ID").ToString()

                    If strSqlVal.Length > 0 Then
                        strSqlVal &= ", "
                    End If
                    strSqlVal &= "( " & R1("WI_ID").ToString() & ", " & Fr_Model_ID.ToString & ", " & To_Model_ID.ToString & ", " & iUserID.ToString & ", now() )" & Environment.NewLine
                Next R1

                strSql = "INSERT INTO warehouse.warehouse_modelchange( WI_ID, From_Model_ID, To_Model_ID_To, User_ID_To, UpdatedDatetime )" & Environment.NewLine
                strSql &= " VALUES " & Environment.NewLine
                strSql &= strSqlVal
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                strSql = "UPDATE warehouse.warehouse_items, tdevice " & Environment.NewLine
                strSql &= "SET warehouse_items.Model_ID = " & To_Model_ID.ToString() & ", tdevice.Model_ID = " & To_Model_ID.ToString() & Environment.NewLine
                strSql &= "WHERE warehouse.warehouse_items.Device_ID = tdevice.Device_ID " & Environment.NewLine
                strSql &= "AND tdevice.Device_ID in (" & deviceIDs & ");"
                i = Me._objDataProc.ExecuteNonQuery(strSql)


                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************

    End Class
End Namespace