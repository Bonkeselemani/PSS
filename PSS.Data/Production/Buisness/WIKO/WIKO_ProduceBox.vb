Option Explicit On 
Imports System
Imports System.Data
Imports System.Text
Imports MySql.Data
Imports PSS.Data.Buisness

Namespace Buisness.WIKO
    Public Class WIKO_ProduceBox
        Private _objDataProc As DBQuery.DataProc
        Private _objWiko As New WIKO()
        Private iCustID As Integer
        Private Declare Function IDAutomation_Universal_C128 _
                 Lib "IDAutomationNativeFontEncoder.dll" _
                (ByVal D2E As String, ByRef tilde As Long, _
                 ByVal out As String, _
                 ByRef iSize As Long) As Long

#Region "Constructor/Destructor"

        '******************************************************************
        Public Sub New()
            Try
                iCustID = _objWiko.WIKO_CUSTOMER_ID
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

        Public Function GetWiKoLocations(ByVal iCust_ID As Integer, ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "Select Loc_ID,Loc_Name from production.tlocation WHere Cust_ID=" & iCust_ID & ";"
                dt = Me._objDataProc.GetDataTable(strSql)

                If booAddSelectRow Then dt.LoadDataRow(New Object() {0, "--Select--"}, True)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getDeviceSn(ByVal pId As String, ByVal mId As String) As DataTable
            Dim strsql As String = String.Empty
            Dim dt As DataTable
            Try
                strsql = "Select device_id,Device_SN as SN from tdevice where Pallett_ID=" & pId & " and Model_Id=" & mId & " and device_dateship is null;" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strsql)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try

        End Function

        Public Function getAllPallets(ByVal strLoc_id As String) As DataTable

            Dim strsql As String = String.Empty
            Dim dt As DataTable
            Try
                strsql = "Select tpallett.pallett_id," & Environment.NewLine
                strsql &= "  tpallett.Pallett_Name as Pallet," & Environment.NewLine
                strsql &= "  Count(*) as 'Count'," & Environment.NewLine
                strsql &= "  tpallett.Pallett_Qty as 'Quantity'," & Environment.NewLine
                strsql &= " tpallett.Pallet_SkuLen as 'SKU Length'," & Environment.NewLine
                strsql &= " tpallett.Pallet_ShipType as 'ShipType'," & Environment.NewLine
                strsql &= " tpallett.model_id," & Environment.NewLine
                strsql &= " tpallett.Cust_ID," & Environment.NewLine
                strsql &= " tpallett.Loc_ID" & Environment.NewLine
                strsql &= " FROM tpallett WHERE tpallett.Loc_ID IN ( " & strLoc_id & " )  and cust_id= " & iCustID & " AND tpallett.Pallet_Invalid=0 AND tpallett.Pallett_ReadyToShipFlg=1 AND tpallett.Pallett_Qty>0 AND tpallett.Pallett_ShipDate IS NULL " & Environment.NewLine
                strsql &= " GROUP BY tpallett.Pallett_ID " & Environment.NewLine
                strsql &= " ORDER BY Pallet;" & Environment.NewLine


                dt = Me._objDataProc.GetDataTable(strsql)

                'dt.LoadDataRow(New Object() {0, "--Select--"}, True)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally

                Generic.DisposeDT(dt)
            End Try

        End Function

        Public Function GetOnePallet(ByVal strLoc_id As String, ByVal strPalletName As String) As DataTable

            Dim strsql As String = String.Empty
            Dim dt As DataTable
            Try
                strsql = "Select tpallett.pallett_id," & Environment.NewLine
                strsql &= " tpallett.Pallett_Name as Pallet " & Environment.NewLine
                strsql &= " FROM tpallett " & Environment.NewLine
                strsql &= " WHERE tpallett.Loc_ID IN ( " & strLoc_id & " )  " & Environment.NewLine
                strsql &= " AND tpallett.Pallett_Name = '" & strPalletName & "' " & Environment.NewLine
                strsql &= " AND cust_id= " & iCustID & " AND tpallett.Pallet_Invalid=0 " & Environment.NewLine
                strsql &= " AND tpallett.Pallett_ReadyToShipFlg=1 AND tpallett.Pallett_Qty>0 " & Environment.NewLine
                strsql &= " AND tpallett.Pallett_ShipDate IS NULL " & Environment.NewLine
                strsql &= " GROUP BY tpallett.Pallett_ID " & Environment.NewLine
                strsql &= " ORDER BY Pallet;" & Environment.NewLine


                dt = Me._objDataProc.GetDataTable(strsql)

                'dt.LoadDataRow(New Object() {0, "--Select--"}, True)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally

                Generic.DisposeDT(dt)
            End Try

        End Function


    End Class


End Namespace