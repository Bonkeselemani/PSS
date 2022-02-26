Option Explicit On 

Imports System
Imports System.Data
Imports System.Text
Imports MySql.Data

Namespace Buisness.CP
    Public Class CoolPad_ProduceBox
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
                strsql &= " FROM tpallett WHERE tpallett.Cust_ID=" & PSS.Data.Buisness.CP.CoolPad.CoolPad_CUSTOMER_ID & " AND tpallett.Pallet_Invalid=0 AND tpallett.Pallett_ReadyToShipFlg=1 AND tpallett.Pallett_Qty>0 AND tpallett.Pallett_ShipDate IS NULL" & Environment.NewLine
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

        'Public Function GetPalletsReadyToBeShipped(ByVal iHoldStatus As Integer, _
        '                                                   ByVal iMachineGroup As Integer, _
        '                                                   Optional ByVal iCustID As Integer = 0) As DataTable
        '    Dim dt As DataTable
        '    Dim strsql As String = String.Empty

        '    Try
        '        strsql = "Select tpallett.pallett_id, " & Environment.NewLine
        '        strsql &= "tpallett.Pallett_Name as Pallet, " & Environment.NewLine
        '        strsql &= "Count(*) as 'Count', " & Environment.NewLine
        '        'strsql &= "if(tpallett.Pallet_ShipType=9,'RTM',if(tpallett.Pallet_ShipType=1,'RUR',if(tpallett.Pallet_ShipType=8,'SCR','REGULAR'))) as 'Ship Type', " & Environment.NewLine
        '        'strsql &= "if(Cust_ID=2219 and tpallett.Pallet_ShipType=9,'Incomplete',if(tpallett.Pallet_ShipType=9,'RTM',if(tpallett.Pallet_ShipType=1,'RUR',if(tpallett.Pallet_ShipType=8,'SCR',if(Cust_ID=1545 and tpallett.Pallet_ShipType=1,'DBR','REGULAR'))))) as 'Ship Type', " & Environment.NewLine
        '        strsql &= "if(Cust_ID=2219 and tpallett.Pallet_ShipType=9,'Incomplete',if(tpallett.Pallet_ShipType=9,'RTM',if(Cust_ID in(1545,2507,2508) and tpallett.Pallet_ShipType=1,'DBR',if(tpallett.Pallet_ShipType=8,'SCR',if(tpallett.Pallet_ShipType=1,'RUR','REGULAR'))))) as 'Ship Type', " & Environment.NewLine
        '        strsql &= "tpallett.Pallet_SkuLen as 'SKU Length', " & Environment.NewLine
        '        strsql &= "tpallett.Pallet_ShipType, " & Environment.NewLine
        '        strsql &= "tpallett.model_id, " & Environment.NewLine
        '        strsql &= "tdevice.Loc_ID, " & Environment.NewLine
        '        strsql &= "tworkorder.group_id, " & Environment.NewLine
        '        strsql &= "tpallett.Cust_ID " & Environment.NewLine
        '        strsql &= "FROM tpallett " & Environment.NewLine
        '        strsql &= "INNER JOIN tdevice on tpallett.Pallett_ID = tdevice.Pallett_ID " & Environment.NewLine
        '        strsql &= "INNER JOIN tworkorder on tdevice.wo_id = tworkorder.wo_id " & Environment.NewLine

        '        If iHoldStatus = 0 Or iHoldStatus = 1 Then
        '            strsql &= "WHERE Pallett_ShipDate is null and tpallett.Pallett_ReadyToShipFlg = 1 " & Environment.NewLine
        '        ElseIf iHoldStatus = 2 Then
        '            strsql &= "WHERE Pallett_ShipDate is not null and tpallett.Pallett_ReadyToShipFlg = 1 and tpallett.AWPFlag = 1 " & Environment.NewLine
        '        End If

        '        If iCustID > 0 Then
        '            strsql &= " AND tpallett.Cust_ID = " & iCustID & Environment.NewLine
        '        Else
        '            '****************************************************
        '            'Lan added on 03/15/07. 
        '            'allow users see pallets belong to machine group only 
        '            If iMachineGroup = 2 Then   'CELL 1
        '                strsql &= " AND (Pallett_Name like  '2%' or tpallett.Pallett_Name like 'HTC%' ) " & Environment.NewLine
        '            ElseIf iMachineGroup = 3 Then  'CELL 2
        '                strsql &= " AND (tpallett.Pallett_Name like 'HTC%' or tpallett.Pallett_Name like '2%' or tpallett.Pallett_Name like 'DS%' ) " & Environment.NewLine
        '            ElseIf iMachineGroup = 14 Or iMachineGroup = 78 Then  'CELL 2
        '                strsql &= " AND tpallett.Pallett_Name like 'GS%' " & Environment.NewLine
        '            ElseIf iMachineGroup = 77 Then
        '                strsql &= " AND (tpallett.Pallett_Name like 'ST%' or tpallett.Pallett_Name like 'PL%' or tpallett.Pallett_Name like 'PE%') " & Environment.NewLine
        '            ElseIf iMachineGroup = SkyTel.SKYTEL_GROUPID Then  'iMachineGroup = 83 Then
        '                strsql &= " AND (tpallett.Pallett_Name like 'SK%') " & Environment.NewLine
        '            ElseIf iMachineGroup = SkyTel.MorrisCom_GROUPID Then '100
        '                strsql &= " AND (tpallett.Pallett_Name like 'MR%') " & Environment.NewLine
        '            ElseIf iMachineGroup = SkyTel.Propage_GROUPID Then '101
        '                strsql &= " AND (tpallett.Pallett_Name like 'PR%') " & Environment.NewLine
        '            ElseIf iMachineGroup = SkyTel.Aquis_GROUPID Then '96
        '                strsql &= " AND (tpallett.Pallett_Name like 'AQ%') " & Environment.NewLine
        '            Else
        '                strsql &= " AND tpallett.Pallett_Name like '" & iMachineGroup & "%' " & Environment.NewLine
        '            End If
        '            ''****************************************************
        '        End If

        '        strsql &= "GROUP BY tpallett.Pallett_ID " & Environment.NewLine
        '        strsql &= "ORDER BY Pallet;"

        '        objMisc._SQL = strsql
        '        dt = _objDataProc.GetDataTable

        '        Dim dr As DataRow
        '        For Each dr In dt.Rows
        '            If dr("Pallet_ShipType").ToString = "2" AndAlso (dr("Cust_ID").ToString = "1545" OrElse dr("Cust_ID").ToString = "2507" OrElse dr("Cust_ID").ToString = "2508") Then
        '                dr.BeginEdit() : dr("Ship Type") = "NER" : dr.EndEdit()
        '            End If
        '        Next dr
        '        dt.AcceptChanges()
        '        '*************************************************

        '        Return dt
        '    Catch ex As Exception
        '        Throw ex
        '    Finally
        '        Generic.DisposeDT(dt)
        '    End Try
        'End Function

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