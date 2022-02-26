Namespace Buisness
    Public Class FileRec
        Private _objDataProc As DBQuery.DataProc

        Public Sub New()
            Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
        End Sub

        Public Function CheckPalletDevices(ByVal strDeviceSNsIn As String) As ArrayList
            Dim arrlstDeviceSNs As ArrayList
            Dim strSQL As String
            Dim dt As DataTable
            Dim dr As DataRow

            Try
                arrlstDeviceSNs = New ArrayList()

                strSQL = "SELECT device_sn " & Environment.NewLine
                strSQL &= "FROM tdevice " & Environment.NewLine
                strSQL &= "WHERE device_sn IN (" & strDeviceSNsIn & ") " & Environment.NewLine
                strSQL &= "AND device_shipdate IS NOT NULL " & Environment.NewLine
                strSQL &= "ORDER BY device_sn"

                dt = Me._objDataProc.GetDataTable(strSQL)

                If Not IsNothing(dt) Then
                    If dt.Rows.Count > 0 Then
                        For Each dr In dt.Rows
                            arrlstDeviceSNs.Add(dr(0))
                        Next dr
                    End If
                End If

                Return arrlstDeviceSNs
            Catch ex As Exception
                Throw ex
            Finally
                dr = Nothing

                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Function

        Public Function GetPOCount(ByVal iPOID As Integer) As Integer
            Dim strSQL As String

            Try
                strSQL = "SELECT COUNT(*) " & Environment.NewLine
                strSQL &= "FROM tpurchaseorder " & Environment.NewLine
                strSQL &= "WHERE PO_ID = " & iPOID.ToString

                Return Me._objDataProc.GetIntValue(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function PalletCheck(ByVal strRMA As String) As DataTable
            Dim strSQL As String

            Try
                strSQL = "SELECT WHP_BinLocation as BinLocation, WHR_Dev_SN as PieceIdentifier, WHP_PartNumber as PartNumber, WHR_WIPOwner, cust_id, model_id " & Environment.NewLine
                strSQL &= "FROM twarehousepallet " & Environment.NewLine
                strSQL &= "INNER JOIN twarehousereceive ON twarehousepallet.WHPallet_ID = twarehousereceive.whpallet_id " & Environment.NewLine
                strSQL &= "INNER JOIN twarehousepalletload ON twarehousepallet.WHPallet_ID = twarehousepalletload.WHPallet_ID AND twarehousepalletload.whp_PieceIdentifier = twarehousereceive.whr_dev_sn " & Environment.NewLine
                strSQL &= "WHERE twarehousepallet.WHPallet_Number = '" & strRMA & "' " & Environment.NewLine
                strSQL &= "AND twarehousereceive.WHR_Result = 0 " & Environment.NewLine
                strSQL &= "AND twarehousepallet.WHPalletClosed = 1"

                Return Me._objDataProc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetPalletInfo(ByVal strRMA As String) As DataTable
            Dim strSQL As String
            Dim iPalletID As Integer

            Try
                iPalletID = GetPalletID(strRMA)

                strSQL = "SELECT whp_binlocation, whp_loadnumber, whp_PartNumber, whp_PieceIdentifier, twarehousereceive.whr_devcondition as mBillCode " & Environment.NewLine
                strSQL &= "FROM twarehousepalletload " & Environment.NewLine
                strSQL &= "INNER JOIN twarehousereceive ON twarehousepalletload.whpallet_id = twarehousereceive.whpallet_id  AND twarehousepalletload.whp_PieceIdentifier = twarehousereceive.whr_dev_sn " & Environment.NewLine
                strSQL &= "WHERE twarehousepalletload.whPallet_ID = " & iPalletID.ToString

                Return Me._objDataProc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Private Function GetPalletID(ByVal strRMA As String) As Integer
            Dim strSQL As String

            Try
                strSQL = "SELECT WHPallet_ID " & Environment.NewLine
                strSQL &= "FROM twarehousepallet " & Environment.NewLine
                strSQL &= "WHERE twarehousepallet.whPallet_Number = '" & strRMA & "'"

                Return Me._objDataProc.GetIntValue(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetWHPData(ByVal strRMA As String) As DataTable
            Dim strSQL As String

            Try
                strSQL = "SELECT WHP_PartNumber, COUNT(WHP_PartNumber) as dcount " & Environment.NewLine
                strSQL &= "FROM twarehousepallet " & Environment.NewLine
                strSQL &= "INNER JOIN twarehousepalletload ON twarehousepallet.WHPallet_ID = twarehousepalletload.WHPallet_ID " & Environment.NewLine
                strSQL &= "WHERE twarehousepallet.WHPallet_Number = '" & strRMA & "' " & Environment.NewLine
                strSQL &= "GROUP BY WHP_PartNumber"

                Return Me._objDataProc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetSKUData(ByVal iSKUDescID As Integer) As DataTable
            Dim strSQL As String

            Try
                strSQL = "SELECT * " & Environment.NewLine
                strSQL &= "FROM tskudescription " & Environment.NewLine
                strSQL &= "WHERE SKUDESC_ID = " & iSKUDescID.ToString

                Return Me._objDataProc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class
End Namespace
