Option Explicit On 

Imports System
Imports System.Data
Imports System.Text
Imports MySql.Data

Namespace Buisness.Vinsmart

    Public Class Vinsmart_SpecialKit

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

        Public Function GetKitDatatableDef() As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT  0 AS 'RecNo','' AS 'Model','' AS  'IMEI','' AS 'ICCID', 0 AS 'Device_ID',0 AS 'Model_ID',0 AS 'WI_ID',0 AS 'EW_ID' Limit 0;"
                dt = Me._objDataProc.GetDataTable(strSql)
                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetDeviceData(ByVal iCust_ID As Integer, ByVal iLoc_ID As Integer, ByVal strAccount As String, ByVal strSN As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strAccount = strAccount.Replace("'", "''") : strSN = strSN.Replace("'", "''")

                strSql = "SELECT A.Cust_ID,A.Loc_ID,A.EW_ID,B.Device_ID,B.Model_ID,C.wb_id,C.BoxID,A.WI_ID,A.SerialNo AS 'IMEI',D.Model_Desc,A.Item_Sku,A.Account" & Environment.NewLine
                strSql &= " FROM production.extendedwarranty A" & Environment.NewLine
                strSql &= " INNER JOIN production.tdevice B ON A.Device_ID=B.Device_ID" & Environment.NewLine
                strSql &= " INNER JOIN edi.twarehouseBox C ON A.wb_ID=C.wb_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tModel D ON B.Model_ID=D.Model_ID" & Environment.NewLine
                strSql &= " WHERE A.Cust_ID=" & iCust_ID & " AND A.Loc_ID=" & iLoc_ID & " AND A.Account ='" & strAccount & "' AND A.SerialNo='" & strSN & "';"

                dt = Me._objDataProc.GetDataTable(strSql)
                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetSIMCardData(ByVal iCust_ID As Integer, ByVal iLoc_ID As Integer, ByVal strICCID As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strICCID = strICCID.Replace("'", "''")
                strSql = "SELECT C.WI_ID,A.WO_ID,B.WR_ID,WO_CustWO,WO_Date,WO_Quantity,C.Device_ID,C.Serial AS 'ICCID',C.Insert_decode_ID AS 'Kitted'" & Environment.NewLine
                strSql &= " FROM production.tworkorder A" & Environment.NewLine
                strSql &= " INNER JOIN warehouse.warehouse_receipt B ON A.WO_ID =B.WO_ID" & Environment.NewLine
                strSql &= " INNER JOIN warehouse.warehouse_items C ON B.WR_ID=C.WR_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tDevice D ON C.Device_ID=D.Device_ID" & Environment.NewLine
                strSql &= " WHERE B.Cust_ID=" & iCust_ID & " AND B.LOC_ID=" & iLoc_ID & "  AND C.Serial ='" & strICCID & "';"

                dt = Me._objDataProc.GetDataTable(strSql)
                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function UpdateKittedItems(ByVal iEW_ID As Integer, ByVal iWI_ID As Integer, ByVal strKittedSession As String, ByVal strDateTime As String, ByVal iUserID As Integer) As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0

            Try
                strSql = "UPDATE production.extendedwarranty SET WI_ID = " & iWI_ID & ",Kitted_Session = '" & strKittedSession & "',Kitted_DateTime = '" & strDateTime & "',Kitted_UserID = " & iUserID
                strSql &= " WHERE EW_ID = " & iEW_ID & ";"
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                'insert_decode_id = 1 means SIM card is kitted
                strSql = "UPDATE warehouse.warehouse_items SET insert_decode_id = 1 WHERE WI_ID = " & iWI_ID & ";"
                i += Me._objDataProc.ExecuteNonQuery(strSql)

                Return i

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function UndoKittedItems(ByVal strEW_IDs As String, ByVal strWI_IDs As String) As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0

            Try
                strSql = "UPDATE production.extendedwarranty SET WI_ID = 0 WHERE EW_ID IN (" & strEW_IDs & ");"
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                strSql = "UPDATE warehouse.warehouse_items SET insert_decode_id = 0 WHERE WI_ID IN (" & strWI_IDs & ");"
                i += Me._objDataProc.ExecuteNonQuery(strSql)

                Return i

            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class
End Namespace