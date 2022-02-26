Option Explicit On 

Imports System.Data
Imports System.Windows.Forms
Imports DBQuery.DataProc

Namespace Buisness
    Public Class Accessories
        Private _objDataProc As DBQuery.DataProc

#Region "Constructor/Destructor"

        '*******************************************************************************************************************
        Public Sub New()
            Try
                Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "PSS.Data.Buisness.Accessories ctor", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*******************************************************************************************************************
        Protected Overrides Sub Finalize()
            Me._objDataProc = Nothing
            MyBase.Finalize()
        End Sub

        '*******************************************************************************************************************
#End Region

        Public Function GetReceivingAccessories() As DataTable
            Dim strSQL As String

            Try
                strSQL = "SELECT Accessory AS AccessoryID, AccessoryCategory AS Description" & Environment.NewLine
                strSQL &= "FROM production.accessorycatergories" & Environment.NewLine
                strSQL &= "ORDER BY Accessory"

                Return Me._objDataProc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetToBeShippedAccessories(ByVal strIMEI As String) As DataTable
            Dim strSQL As String

            Try
                strSQL = "SELECT A.Accessory AS AccessoryID, AccessoryCategory AS Description" & Environment.NewLine
                strSQL &= "FROM production.DeviceAccessoriesReceived A" & Environment.NewLine
                strSQL &= "INNER JOIN production.accessorycatergories B ON A.Accessory = B.Accessory" & Environment.NewLine
                strSQL &= "INNER JOIN production.tdevice C ON A.Device_ID = C.Device_ID" & Environment.NewLine
                strSQL &= String.Format("WHERE C.device_sn = '{0}'", strIMEI) & Environment.NewLine
                strSQL &= "ORDER BY Description"

                Return Me._objDataProc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetDeviceID(ByVal strIMEI As String) As Integer
            Dim strSQL As String

            Try
                strSQL = "SELECT device_id" & Environment.NewLine
                strSQL &= "FROM production.tdevice" & Environment.NewLine
                strSQL &= String.Format("WHERE device_sn = '{0}'", strIMEI)

                Return Me._objDataProc.GetIntValue(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetIMEI(ByVal iDeviceID As Integer) As String
            Dim strSQL As String

            Try
                strSQL = "SELECT device_sn" & Environment.NewLine
                strSQL &= "FROM production.tdevice" & Environment.NewLine
                strSQL &= String.Format("WHERE device_id = {0}", iDeviceID)

                Return Me._objDataProc.GetSingletonString(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Sub SaveReceivedAccessory(ByVal iDeviceID As Integer, ByVal iAccessoryID As Integer, ByVal iUserID As Integer)
            Dim strSQL As String

            Try
                strSQL = "INSERT INTO production.DeviceAccessoriesReceived (Device_ID, Accessory, ReceivingUserID, ReceivingDate)" & Environment.NewLine
                strSQL &= String.Format("VALUES ({0}, {1}, {2}, NOW())", iDeviceID, iAccessoryID, iUserID)

                Me._objDataProc.ExecuteNonQuery(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub ResetToBeShippedAccessories(ByVal iDeviceID As Integer, ByVal iShipType As Integer)
            Dim strSQL As String

            Try
                strSQL = "UPDATE production.DeviceAccessoriesReceived" & Environment.NewLine

                Select Case iShipType
                    Case 1 'Pantech
                        strSQL &= "SET ShippingUserID = NULL, ShippingDate = NULL, ShippedFlag = 0" & Environment.NewLine

                    Case 2 'QC
                        strSQL &= "SET QCShippingUserID = NULL, QCShippingDate = NULL, QCShippedFlag = 0" & Environment.NewLine
                End Select

                strSQL &= String.Format("WHERE Device_ID = {0}", iDeviceID)

                Me._objDataProc.ExecuteNonQuery(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub SaveToBeShippedAccessory(ByVal iDeviceID As Integer, ByVal iAccessoryID As Integer, ByVal iUserID As Integer, ByVal iShipType As Integer)
            Dim strSQL As String

            Try
                strSQL = "UPDATE production.DeviceAccessoriesReceived" & Environment.NewLine

                Select Case iShipType
                    Case 1 'Pantech
                        strSQL &= String.Format("SET ShippingUserID = {0}, ShippingDate = NOW(), ShippedFlag = 1", iUserID) & Environment.NewLine

                    Case 2  'QC
                        strSQL &= String.Format("SET QCShippingUserID = {0}, QCShippingDate = NOW(), QCShippedFlag = 1", iUserID) & Environment.NewLine
                End Select

                strSQL &= String.Format("WHERE Device_ID = {0} AND Accessory = {1}", iDeviceID, iAccessoryID)

                Me._objDataProc.ExecuteNonQuery(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Function GetToBeShippedAccessoriesLabelData(ByVal iDeviceID As Integer, ByVal iShipType As Integer) As DataTable
            Dim strSQL As String

            Try
                strSQL = "SELECT E.cust_name1 AS Customer, C.device_sn AS IMEI, IF(C.Device_ManufWrty = 0, 'OUT', 'IN') AS WarrantyStatus, B.AccessoryCategory" & Environment.NewLine
                strSQL &= "FROM production.DeviceAccessoriesReceived A" & Environment.NewLine
                strSQL &= "INNER JOIN production.accessorycatergories B ON A.Accessory = B.Accessory" & Environment.NewLine
                strSQL &= "INNER JOIN production.tdevice C ON A.Device_ID = C.Device_ID" & Environment.NewLine
                strSQL &= "INNER JOIN production.tlocation D ON C.Loc_ID = D.Loc_ID" & Environment.NewLine
                strSQL &= "INNER JOIN production.tcustomer E ON D.Cust_ID = E.Cust_ID" & Environment.NewLine
                strSQL &= String.Format("WHERE A.device_id = {0}", iDeviceID) & Environment.NewLine

                Select Case iShipType
                    Case 1 'Pantech
                        strSQL &= "AND A.ShippedFlag = 1" & Environment.NewLine

                    Case 2 'QC
                        strSQL &= "AND A.QCShippedFlag = 1" & Environment.NewLine
                End Select

                strSQL &= "ORDER BY B.AccessoryCategory"

                Return Me._objDataProc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Sub DeleteAccessoryData(ByVal iDeviceID As Integer)
            Dim strSQL As String

            Try
                strSQL = "DELETE FROM production.DeviceAccessoriesReceived" & Environment.NewLine
                strSQL &= String.Format("WHERE Device_ID = {0}", iDeviceID)

                Me._objDataProc.ExecuteNonQuery(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub DeleteAccessoryDataForPallett(ByVal iPallettID As Integer)
            Dim strSQL As String
            Dim dt As DataTable

            Try
                strSQL = "SELECT device_id" & Environment.NewLine
                strSQL &= "FROM production.tdevice" & Environment.NewLine
                strSQL &= String.Format("WHERE pallett_id = {0}", iPallettID)

                dt = Me._objDataProc.GetDataTable(strSQL)

                Dim dr As DataRow

                For Each dr In dt.Rows
                    Dim iDeviceID As Integer = Convert.ToInt32(dr(0))

                    DeleteAccessoryData(iDeviceID)
                Next dr
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub
    End Class
End Namespace
