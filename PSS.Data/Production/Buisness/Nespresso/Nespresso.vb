Option Explicit On 

Imports CrystalDecisions.CrystalReports.Engine
Imports DBQuery.DataProc
Imports System.Windows.Forms

Namespace Buisness.Nespresso
    Public Class Nespresso

        '**** Nespresso Constants ****
        Private _objDataProc As DBQuery.DataProc
        Public Const intLocID As Integer = 3261
        Public Const intCustID As Integer = 2463
        Public Const intMfgID As Integer = 68
        Public Const intProdID As Integer = 17
        Public Const ShortCustDesc As String = "NES"
        Public Const PalletManifestDir As String = "P:\Dept\Nespresso\Pallet packing list\"
        Public Const ShipBoxLabelLocation As String = "P:\Dept\Nespresso\Label\4x4GenericShipBoxLabel.rpt"
        Private strRptPath As String = "P:\Dept\Labels\" & System.Net.Dns.GetHostName & "\"
        Private strRptName As String = ""

#Region "Properties"
        'Use Const above
        '******************************************************************
        'Public Shared ReadOnly Property Nespresso_PRODID() As Integer
        '    Get
        '        Return 17
        '    End Get
        'End Property
        '******************************************************************
        'Public Shared ReadOnly Property Nespresso_ManufID() As Integer
        '    Get
        '        Return 68
        '    End Get
        'End Property
        '******************************************************************
        '******************************************************************
        'Public Shared ReadOnly Property Nespresso_LocID() As Integer
        '    Get
        '        Return 3261
        '    End Get
        'End Property

#End Region

#Region "Constructor/Destructor"

        '*******************************************************************************************************************
        Public Sub New()
            Try
                Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*******************************************************************************************************************
        Protected Overrides Sub Finalize()
            Me._objDataProc = Nothing
            MyBase.Finalize()
        End Sub

        '*******************************************************************************************************************
#End Region

#Region "Manage Recycle Mode"


        '********************************************************************************************************

        Public Function GetRecycleModels() As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT a.Model_ID,a.Model_Desc as 'Model Description', case b.Recycle when 1 then 'Yes' when 0 then 'No' else 'N/A' end as Recycle" & Environment.NewLine
                strSql &= " FROM tmodel a " & Environment.NewLine
                strSql &= " left join tRecycle b on b.Model_ID=a.Model_ID" & Environment.NewLine
                strSql &= " where a.manuf_id=" & Me.intMfgID & Environment.NewLine
                Return _objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '********************************************************************************************************

        Public Function UpdateRecycleModels(ByVal Model_ID As Integer, ByVal Recycle As Integer) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Try
                strSql = "SELECT Model_ID" & Environment.NewLine
                strSql &= " FROM trecycle " & Environment.NewLine
                strSql &= " where Manuf_ID=" & Me.intMfgID & Environment.NewLine
                strSql &= " And Model_ID=" & Model_ID & Environment.NewLine
                dt = _objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    strSql = "Update trecycle Set Recycle= " & Recycle & Environment.NewLine
                    strSql &= " where Manuf_ID=" & Me.intMfgID & Environment.NewLine
                    strSql &= " And Model_ID=" & Model_ID & Environment.NewLine
                    Return _objDataProc.ExecuteNonQuery(strSql)
                Else
                    strSql = "Insert trecycle (Manuf_ID,Model_ID,Recycle) Values (" & Environment.NewLine
                    strSql &= Me.intMfgID & "," & Environment.NewLine
                    strSql &= Model_ID & "," & Environment.NewLine
                    strSql &= Recycle & ")" & Environment.NewLine
                    Return _objDataProc.ExecuteNonQuery(strSql)
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Function

#End Region

#Region "Receiving"


        '********************************************************************************************************

        Public Function GetOpenWorkOrder(ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT Distinct tworkorder.WO_ID, WO_CustWO, WO_Quantity FROM tworkorder  " & Environment.NewLine
                strSql &= "WHERE Loc_ID = " & Me.intLocID & " AND WO_Closed = 0 AND InvalidOrder = 0 " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--Select Workorder--"}, False)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function
        '********************************************************************************************************

        Public Function GetOpenWorkOrderLine(ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT Distinct tworkorder.WO_ID, WO_CustWO, WO_Quantity FROM tworkorder  " & Environment.NewLine
                strSql &= "INNER JOIN tworkorderline ON tworkorder.WO_ID = tworkorderline.WO_ID " & Environment.NewLine
                strSql &= "WHERE Loc_ID = " & Me.intLocID & " AND WO_Closed = 0 AND InvalidOrder = 0 " & Environment.NewLine
                strSql &= "AND ReceivingClosed = 0" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--Select Workorder--"}, False)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function
        '********************************************************************************************************

        Public Function GetNextSerial() As String
            'Generate next serial number in sequence order
            Dim strSql As String = ""
            Dim lSerial As String = ""
            Dim prefixSerial As String = ""
            Dim lNumber, nNumber As Integer
            Dim dt As DataTable

            prefixSerial = "NES" & Now.ToString("yyMMdd") & "N"
            Try
                strSql = "Select Device_SN FROM tdevice a inner join " & Environment.NewLine
                strSql &= "tmodel b on b.Model_ID = a.Model_ID inner join " & Environment.NewLine
                strSql &= "lmanuf c on c.Manuf_ID = b.Manuf_ID " & Environment.NewLine
                strSql &= "where c.Manuf_ID = " & intMfgID & Environment.NewLine
                strSql &= " And Device_SN like '" & prefixSerial & "%' order By Device_ID desc limit 1" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    lSerial = dt.Rows(0)(0)
                    lNumber = lSerial.Substring(10)
                    nNumber = lNumber + 1
                    Return prefixSerial & nNumber.ToString("0000")
                Else
                    Return prefixSerial & "0001"
                End If

            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function
        '********************************************************************************************************

        Public Function GetModelsList(ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT a.Model_ID,a.Model_Desc, b.Recycle " & Environment.NewLine
                strSql &= "FROM tmodel a " & Environment.NewLine
                strSql &= "left join tRecycle b on b.Model_ID=a.Model_ID " & Environment.NewLine
                strSql &= "where a.manuf_id = " & Me.intMfgID & Environment.NewLine
                strSql &= "Order By a.Model_Desc" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--Select Model--", "0"}, False)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function
        '********************************************************************************************************

        Public Function GetReceivedDeviceInWO(ByVal iWOID As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim i As Integer

            Try
                strSql = "Select a.Device_Cnt as 'Item#',c.WO_CustWO as 'RMA#', d.Model_Desc as 'Model',a.Device_SN as 'Serial', b.SN2 as 'Mfg. Serial', " & Environment.NewLine
                strSql &= "a.Device_DateRec as 'Received Date'" & Environment.NewLine
                strSql &= "From tdevice a " & Environment.NewLine
                strSql &= "Left join tasndata b on b.Device_ID = a.Device_ID " & Environment.NewLine
                strSql &= "Left join tworkorder c on c.WO_ID = a.WO_ID " & Environment.NewLine
                strSql &= "Left join tmodel d on d.Model_ID = a.Model_ID " & Environment.NewLine
                strSql &= "Where a.WO_ID =" & iWOID & Environment.NewLine
                strSql &= "ORDER BY a.Device_ID" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                For i = 1 To dt.Rows.Count
                    dt.Rows(i - 1).BeginEdit() : dt.Rows(i - 1)("Item#") = i : dt.Rows(i - 1).EndEdit()
                Next i
                dt.AcceptChanges()

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function
        '********************************************************************************************************

        Public Function GetMfgDeviceInfo(ByVal MfgSerial As String, ByVal Loc_ID As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim i As Integer

            Try
                strSql = "Select a.Device_ID,b.ad_id,c.WO_CustWO as 'RMA#', d.Model_Desc as 'Model',a.Device_SN as 'Serial', b.SN2 as 'Mfg. Serial', " & Environment.NewLine
                strSql &= "a.Device_DateRec as 'Received Date'" & Environment.NewLine
                strSql &= "From tdevice a " & Environment.NewLine
                strSql &= "Left join tasndata b on b.Device_ID = a.Device_ID " & Environment.NewLine
                strSql &= "Left join tworkorder c on c.WO_ID = a.WO_ID " & Environment.NewLine
                strSql &= "Left join tmodel d on d.Model_ID = a.Model_ID " & Environment.NewLine
                strSql &= "Where b.SN2 ='" & MfgSerial & "' AND a.Loc_ID=" & Loc_ID & Environment.NewLine
                strSql &= "ORDER BY a.Device_ID" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '********************************************************************************************************

        Public Function GetDeviceInfo(ByVal Serial As String, ByVal Loc_ID As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim i As Integer

            Try
                strSql = "Select a.Device_ID,b.ad_id,c.WO_CustWO as 'RMA#', d.Model_Desc as 'Model',a.Device_SN as 'Serial', b.SN2 as 'Mfg. Serial', " & Environment.NewLine
                strSql &= "a.Device_DateRec as 'Received Date'" & Environment.NewLine
                strSql &= "From tdevice a " & Environment.NewLine
                strSql &= "Left join tasndata b on b.Device_ID = a.Device_ID " & Environment.NewLine
                strSql &= "Left join tworkorder c on c.WO_ID = a.WO_ID " & Environment.NewLine
                strSql &= "Left join tmodel d on d.Model_ID = a.Model_ID " & Environment.NewLine
                strSql &= "Where b.SN1 ='" & Serial & "' AND a.Loc_ID=" & Loc_ID & Environment.NewLine
                strSql &= "ORDER BY a.Device_ID" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function


        '********************************************************************************************************

        Public Function GetRecycle(ByVal iModelID As Integer) As Boolean
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim recycle As Boolean
            Try
                strSql = "Select Recycle From trecycle " & Environment.NewLine
                strSql &= "where Model_ID = " & iModelID & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    recycle = dt.Rows(0)(0)
                Else
                    recycle = False
                End If

                Return recycle
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

#End Region

#Region "Shipping"

        '********************************************************************************************************
        Public Function GetShipType(ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT * FROM lpallettype Where pt_id =1 And Active=1;" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "0", "", "--Select Ship Type--"}, False)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

         '********************************************************************************
        Public Function CreateShippingManifest(ByVal iPalletID As Integer) As Integer
            Dim strSql, strPalletName As String
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim strOutputData, strLine As String
            Dim i, j As Integer

            Try
                strSql = "SELECT 0 as 'Line #' " & Environment.NewLine
                strSql &= ", Pallett_Name as 'Pallet Name' " & Environment.NewLine
                strSql &= ", tmodel.Model_Desc as 'Model' " & Environment.NewLine
                strSql &= ", tdevice.Device_SN as 'Serial' " & Environment.NewLine
                strSql &= ", SN2 as 'Mfg. Serial' " & Environment.NewLine
                strSql &= ", Pallettype_LDesc as 'Result'" & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN tasndata ON tdevice.Device_ID = tasndata.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN lpallettype ON tpallett.PalletType_ID = lpallettype.PalletType_ID " & Environment.NewLine
                strSql &= "WHERE tdevice.Pallett_ID = " & iPalletID.ToString & " " & Environment.NewLine
                strSql &= "ORDER BY tdevice.Device_SN " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                'Create Line #
                i = 0
                For Each R1 In dt.Rows
                    i += 1 : R1.BeginEdit() : R1("Line #") = i : R1.EndEdit() : R1.AcceptChanges()
                Next R1
                dt.AcceptChanges()

                If dt.Rows.Count > 0 Then
                    strPalletName = dt.Rows(0)("Pallet Name")
                    strOutputData = "" : strLine = ""

                    'Write Header
                    For i = 0 To dt.Columns.Count - 1
                        If strLine.Trim.Length > 0 Then strLine &= ", "
                        strLine &= dt.Columns(i).Caption
                    Next i

                    strOutputData &= strLine & vbCrLf

                    'Write Data
                    For i = 0 To dt.Rows.Count - 1
                        strLine = ""
                        For j = 0 To dt.Columns.Count - 1
                            If strLine.Trim.Length > 0 Then strLine &= ", "
                            strLine &= dt.Rows(i)(j)
                        Next j
                        strOutputData &= strLine & vbCrLf
                    Next i

                    If strOutputData <> "" Then
                        If IO.File.Exists(Me.PalletManifestDir & strPalletName & ".csv") Then Kill(Me.PalletManifestDir & strPalletName & ".csv")
                        PSS.Data.Production.Shipping.WriteDataToFile(Me.PalletManifestDir & strPalletName & ".csv", strOutputData)
                    End If
                End If

                Return dt.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
                GC.Collect() : GC.WaitForPendingFinalizers()
            End Try
        End Function

        '********************************************************************************************************
        Public Function GetOpenPallet(ByVal iLocID As Integer, ByVal iCustID As Integer) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT tpallett.* " & Environment.NewLine
                strSql &= ", Model_Desc " & Environment.NewLine
                strSql &= ", Pallettype_SDesc, Pallettype_LDesc " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tpallett.Model_ID = tmodel.Model_ID" & Environment.NewLine
                strSql &= "INNER JOIN lpallettype ON tpallett.PalletType_ID = lpallettype.PalletType_ID" & Environment.NewLine
                strSql &= "WHERE tpallett.Loc_ID = " & iLocID & " AND tpallett.Cust_ID = " & iCustID & Environment.NewLine
                strSql &= "AND Pallett_ReadyToShipFlg = 0 AND Pallett_ShipDate is null " & Environment.NewLine
                strSql &= "AND Pallet_Invalid = 0 " & Environment.NewLine
                strSql &= "ORDER BY Model_Desc" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

          '********************************************************************************************************
        Public Function GetOpenRecyclePallet(ByVal iLocID As Integer, ByVal iCustID As Integer) As DataTable
            'Recycle pallet is created in Receiving Screen and the Pallett_ReadyToShipFlg = 1 (Closed) 
            'immediately to prevent operator seeing recycle pallet in Build Ship Box screen.
            'To get the actually open recycle, ignore the Pallett_ReadyToShipFlg,
            'using the Pallett_ShipDate is null & PalletType_ID= 7

            Dim strSql As String

            Try
                strSql = "SELECT tpallett.* " & Environment.NewLine
                strSql &= ", Model_Desc " & Environment.NewLine
                strSql &= ", Pallettype_SDesc, Pallettype_LDesc " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tpallett.Model_ID = tmodel.Model_ID" & Environment.NewLine
                strSql &= "INNER JOIN lpallettype ON tpallett.PalletType_ID = lpallettype.PalletType_ID" & Environment.NewLine
                strSql &= "WHERE tpallett.Loc_ID = " & iLocID & " AND tpallett.Cust_ID = " & iCustID & Environment.NewLine
                strSql &= "AND Pallett_ShipDate is null " & Environment.NewLine
                strSql &= "AND Pallet_Invalid = 0 " & Environment.NewLine
                strSql &= "AND tpallett.PalletType_ID= 7 " & Environment.NewLine
                strSql &= "ORDER BY Model_Desc" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '*******************************************************************************************************************
      
        '********************************************************************************************************



#End Region

#Region "Produce"
        '********************************************************************************************************

        Public Function ProduceCompletion(ByVal Device_ID As Integer, _
                                          ByVal Device_Color As String, _
                                          ByVal ShipWorkDate As String, _
                                          ByVal iShiftID As Integer, _
                                          Optional ByVal iFinishedGoodsFlg As Integer = 1 _
                                          ) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Try
                'update selected  color in tasndata 
                strSql = "Update tasndata  Set SN4='" & Device_Color & "'" & Environment.NewLine
                strSql &= " where Device_ID=" & Device_ID & Environment.NewLine
                _objDataProc.ExecuteNonQuery(strSql)

                'update tdevice ship info 
                strSql = "Update tdevice Set Device_DateShip=now()," & Environment.NewLine
                strSql &= "Device_ShipWorkDate='" & ShipWorkDate & "'," & Environment.NewLine
                strSql &= "Shift_ID_Ship = " & iShiftID & "," & Environment.NewLine
                strSql &= "Device_FinishedGoods = " & iFinishedGoodsFlg & " " & Environment.NewLine
                strSql &= "where Device_ID=" & Device_ID & Environment.NewLine
                Return _objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function
#End Region

#Region "Label"

        '********************************************************************************************************

        Public Function Label_PrintReceivingLabel(ByVal strSN As String)
            Dim rptDoc As New ReportDocument()

            Try
                strRptName = "NespressoReceiving.rpt"
                With rptDoc
                    .Load(strRptPath & strRptName)
                    .SetParameterValue("Device SN", strSN)
                    .PrintToPrinter(1, True, 0, 0)
                    .Close()
                End With
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************************************************

        Public Function Label_PrintProduceLabel(ByVal strSN As String)
            Dim strsql As String = ""
            Dim dt As DataTable
            Dim rptDoc As New ReportDocument()

            Try

                strRptName = "NespressoProduce.rpt"

                strsql = "SELECT 'REFURBISHED' as Description, a.SN1 as Serial, a.SN2 as MfgSerial, a.SN4 as Color, m.Model_Desc as Model " & Environment.NewLine
                strsql &= "FROM tasndata a inner join tmodel m ON m.Model_ID=a.Model_ID " & Environment.NewLine
                strsql &= "WHERE a.SN1='" & strSN & "';"
                dt = _objDataProc.GetDataTable(strsql)
                With rptDoc
                    .Load(strRptPath & strRptName)
                    If Not IsNothing(dt) Then .SetDataSource(dt)
                    .PrintToPrinter(1, True, 0, 0)
                    .Close()
                End With
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************************************************

#End Region

#Region "Admin"

#End Region



    End Class
End Namespace