Option Explicit On 

Imports System
Imports System.Data
Imports System.Text
Imports MySql.Data

Namespace Buisness.WingTech
    Public Class WingTech_ProduceBox
        Private _objDataProc As DBQuery.DataProc



        Public Function getAllPallets() As DataTable

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
                strsql &= " FROM tpallett WHERE tpallett.Cust_ID=2629 AND tpallett.Pallet_Invalid=0 AND tpallett.Pallett_ReadyToShipFlg=1 AND tpallett.Pallett_Qty>0 AND tpallett.Pallett_ShipDate IS NULL" & Environment.NewLine
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
        Public Function getDeviceSn(ByVal pId As String, ByVal mId As String) As DataTable


            Dim strsql As String = String.Empty
            Dim dt As DataTable
            Try
                strsql = "Select device_id,Device_SN as SN from tdevice where Pallett_ID=" & pId & " and   device_dateship is null;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strsql)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally

                Generic.DisposeDT(dt)
            End Try



        End Function
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

    End Class
End Namespace

