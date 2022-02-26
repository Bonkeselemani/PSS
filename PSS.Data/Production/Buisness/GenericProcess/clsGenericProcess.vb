Option Explicit On 

Imports System.IO
Imports System.Data.OleDb
Imports System.Windows.Forms

Namespace Buisness.GenericProcess

    Public Class clsGenericProcess

        Public Const ManifestBaseDir As String = "P:\Dept\"
        Public Const ManifestFolderName As String = "Pallet packing list"

        Private _objDataProc As DBQuery.DataProc

        '********************************************************************************
        Public Sub New()
            Try
                Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

#Region "Receiving"

        '********************************************************************************
        Public Function GetOpenRMA(ByVal booAddSelectRow As Boolean, _
                                   ByVal iLocID As Integer, _
                                   ByVal iProdID As Integer) As DataTable
            Dim strSql As String
            Dim dt As DataTable

            Try
                strSql = "SELECT * " & Environment.NewLine
                strSql &= "FROM tworkorder " & Environment.NewLine
                strSql &= "WHERE loc_id = " & iLocID & " AND WO_Closed = 0 " & Environment.NewLine
                strSql &= "AND Prod_ID = " & iProdID & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If booAddSelectRow = True Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************************
        Public Function GetFileAndRecQty(ByVal iWOID As Integer) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "Select count(Device_id) as RecQty, if(tworkorder.WO_CameWithFile = 1, count(ad_id), 0) as FileQty, 0 as RejQty  " & Environment.NewLine
                strSql &= "FROM tworkorder " & Environment.NewLine
                strSql &= "INNER JOIN tasndata ON tworkorder.WO_ID = tasndata.WO_ID " & Environment.NewLine
                strSql &= "WHERE tworkorder.WO_ID = " & iWOID & Environment.NewLine
                strSql &= "GROUP BY tworkorder.WO_ID " & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************************
        Public Function ReceiveDeviceIntoWIP(ByVal iWOID As Integer, _
                                             ByVal iTrayID As Integer, _
                                             ByVal iLocID As Integer, _
                                             ByVal iModelID As Integer, _
                                             ByVal strInPO As String, _
                                             ByVal strInRMA As String, _
                                             ByVal strDeviceMemo As String, _
                                             ByVal strSN1 As String, _
                                             ByVal strSN2 As String, _
                                             ByVal strSN3 As String, _
                                             ByVal strSN4 As String, _
                                             ByVal iShiftID As Integer, _
                                             ByVal IDuser As Integer, _
                                             ByVal iDiscrepancy As Integer, _
                                             ByVal iAsnDataID As Integer, _
                                             ByVal iCCID As Integer) As Integer
            Dim strSql As String
            Dim objRec As New PSS.Data.Production.Receiving()
            Dim iDeviceID, iSeqNo, i, iManufWrty As Integer

            Try
                iDeviceID = 0 : iSeqNo = 0 : i = 0 : iManufWrty = 0

                iSeqNo = objRec.GetNextDeviceCountInTray(iTrayID) + 1

                '1:Write to tdevice
                iDeviceID = objRec.InsertIntoTdevice(strSN1, Generic.GetWorkDate(iShiftID), iSeqNo, iTrayID, iLocID, iWOID, iModelID, iShiftID, , iManufWrty, , iCCID, )
                If iDeviceID = 0 Then Throw New Exception("System has failed to insert a record into tdevice.")

                '2:Update/Insert ASN Data
                i = InsertUpdateAsnData(iWOID, iLocID, iModelID, iDeviceID, strInPO, strInRMA, strDeviceMemo, strSN1, strSN2, strSN3, strSN4, "", iDiscrepancy, iAsnDataID, IDuser, )
                If i = 0 Then Throw New Exception("System has failed to write data into tasndata table.")

                Return iDeviceID
            Catch ex As Exception
                Throw ex
            Finally
                objRec = Nothing
            End Try
        End Function

        '********************************************************************************
        Public Function InsertUpdateAsnData(ByVal iWOID As Integer, _
                                            ByVal iLocID As Integer, _
                                            ByVal iModelID As Integer, _
                                            ByVal iDeviceID As Integer, _
                                            ByVal strInPO As String, _
                                            ByVal strInRMA As String, _
                                            ByVal strDeviceMemo As String, _
                                            ByVal strSN1 As String, _
                                            ByVal strSN2 As String, _
                                            ByVal strSN3 As String, _
                                            ByVal strSN4 As String, _
                                            ByVal strSN5 As String, _
                                            ByVal iDiscrepancy As Integer, _
                                            ByVal iAsnDataID As Integer, _
                                            Optional ByVal iRecvdUsrID As Integer = 0, _
                                            Optional ByVal iFileLoadedUsrID As Integer = 0, _
                                            Optional ByVal iModelID_EDI As Integer = 0) As Integer
            Dim strSql, strField, strVal As String

            Try
                strSql = "" : strField = "" : strVal = ""

                If iAsnDataID = 0 Then
                    strField &= "WO_ID " & Environment.NewLine
                    strVal &= iWOID & Environment.NewLine
                    strField &= ", Loc_ID " & Environment.NewLine
                    strVal &= ", " & iLocID & Environment.NewLine
                    strField &= ", Model_ID " & Environment.NewLine
                    strVal &= ", " & iModelID & Environment.NewLine
                    strField &= ", Discrepancy " & Environment.NewLine
                    strVal &= ", " & iDiscrepancy & Environment.NewLine
                    strField &= ", Device_ID " & Environment.NewLine
                    strVal &= ", " & iDeviceID & Environment.NewLine
                    strField &= ", SN1  " & Environment.NewLine
                    strVal &= ", '" & strSN1 & "'" & Environment.NewLine

                    If strSN2.Trim.Length > 0 Then
                        strField &= ", SN2 " & Environment.NewLine
                        strVal &= ", '" & strSN2 & "'" & Environment.NewLine
                    End If
                    If strSN3.Trim.Length > 0 Then
                        strField &= ", SN3 " & Environment.NewLine
                        strVal &= ", '" & strSN3 & "'" & Environment.NewLine
                    End If
                    If strSN4.Trim.Length > 0 Then
                        strField &= ", SN4 " & Environment.NewLine
                        strVal &= ", '" & strSN4 & "'" & Environment.NewLine
                    End If
                    If strSN5.Trim.Length > 0 Then
                        strField &= ", SN5 " & Environment.NewLine
                        strVal &= ", '" & strSN5 & "'" & Environment.NewLine
                    End If
                    If strInPO.Trim.Length > 0 Then
                        strField &= ", InPO " & Environment.NewLine
                        strVal &= ", '" & strInPO & "'" & Environment.NewLine
                    End If
                    If strInRMA.Trim.Length > 0 Then
                        strField &= ", InRMA " & Environment.NewLine
                        strVal &= ", '" & strInRMA & "'" & Environment.NewLine
                    End If
                    If iRecvdUsrID > 0 Then
                        strField &= ", RecvdUsrID " & Environment.NewLine
                        strVal &= ", " & iRecvdUsrID & Environment.NewLine
                    End If
                    If iFileLoadedUsrID > 0 Then
                        strField &= ", FileLoadedUsrID " & Environment.NewLine
                        strVal &= ", " & iFileLoadedUsrID & Environment.NewLine
                    End If
                    If iModelID_EDI > 0 Then
                        strField &= ", Model_ID_EDI " & Environment.NewLine
                        strVal &= ", " & iModelID_EDI & Environment.NewLine
                    End If

                    strSql = "INSERT INTO tasndata ( " & Environment.NewLine
                    strSql &= strField
                    strSql &= ") VALUES ( " & Environment.NewLine
                    strSql &= strVal
                    strSql &= ");"
                Else
                    strSql = "UPDATE tasndata SET  " & Environment.NewLine
                    strSql &= ", Discrepancy = " & iDiscrepancy & Environment.NewLine
                    strSql &= ", WO_ID = " & iWOID & Environment.NewLine
                    strSql &= ", Model_ID = " & iModelID & Environment.NewLine
                    strSql &= ", Device_ID = " & iDeviceID & Environment.NewLine
                    strSql &= ", sn1 = '" & strSN1 & "' " & Environment.NewLine
                    If strSN2.Trim.Length > 0 Then strSql &= ", SN2 = '" & strSN2.Trim & "'" & Environment.NewLine
                    If strSN3.Trim.Length > 0 Then strSql &= ", SN3 = '" & strSN3 & "'" & Environment.NewLine
                    If strSN4.Trim.Length > 0 Then strSql &= ", SN4 = '" & strSN4 & "'" & Environment.NewLine
                    If strInPO.Trim.Length > 0 Then strSql &= ", InPO = '" & strInPO & "'" & Environment.NewLine
                    If strInRMA.Trim.Length > 0 Then strSql &= ", InRMA = '" & strInRMA & "'" & Environment.NewLine
                    If strDeviceMemo.Trim.Length > 0 Then strSql &= ", Memo = '" & strDeviceMemo & "'" & Environment.NewLine
                    If iModelID_EDI > 0 Then strSql &= ", Model_ID_EDI = " & iModelID_EDI & Environment.NewLine
                    strSql &= "WHERE ad_id = " & iAsnDataID & Environment.NewLine
                End If

                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************************
        Public Function GetReceivedUnits(ByVal iWOID As Integer, _
                                         ByVal booIncludeFileData As Boolean) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT if(Device_Cnt is null, '', Device_Cnt) as 'Cnt' " & Environment.NewLine
                strSql &= ", tmodel.Model_Desc as 'Model', SN1 " & Environment.NewLine
                strSql &= ", if(SN2 is null, '', SN2) as 'SN2' " & Environment.NewLine
                strSql &= ", if(SN3 is null, '', SN3) as 'SN3' " & Environment.NewLine
                strSql &= ", if(SN4 is null, '', SN4) as 'SN4' " & Environment.NewLine
                strSql &= ", if( Memo is null, '', Memo) as 'Device Memo' " & Environment.NewLine
                strSql &= ", if(InPO is null, '', InPO) as 'Customer PO' " & Environment.NewLine
                strSql &= ", if(InRMA is null, '', InRMA) as 'Customer RMA' " & Environment.NewLine
                strSql &= ", if(Discrepancy = 1, 'Yes', 'No') as 'Discrepancy?' " & Environment.NewLine
                strSql &= ", if(WO_CameWithFile = 1, 'Yes', 'No') as 'Has File?' " & Environment.NewLine
                strSql &= ", if(Group_Desc is null, '', Group_Desc) as 'Assigned To' " & Environment.NewLine
                strSql &= ", WO_CustWO as 'PSS WO' " & Environment.NewLine
                strSql &= ", if( (PO_ID is null or PO_ID = 0), '', PO_ID) as 'PSS PO' " & Environment.NewLine
                strSql &= "FROM tasndata  " & Environment.NewLine
                strSql &= "INNER JOIN tworkorder ON tasndata.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tdevice ON tasndata.Device_ID = tdevice.Device_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tmodel ON tasndata.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN security.tusers ON tasndata.RecvdUsrID = security.tusers.user_id " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lgroups ON tworkorder.Group_ID = lgroups.Group_ID " & Environment.NewLine
                strSql &= "WHERE tasndata.WO_ID = " & iWOID & Environment.NewLine
                If booIncludeFileData = False Then strSql &= "AND tasndata.Device_ID is not null AND tasndata.Device_ID > 0 " & Environment.NewLine
                strSql &= "ORDER BY tasndata.Device_ID DESC " & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************************
        Public Function SetInFileNotInLotDiscrepancy(ByVal iWOID As Integer) As Integer
            Dim strsql As String = ""

            Try
                strsql = "UPDATE tasndata SET Discrepancy = 2 WHERE WO_ID = " & iWOID & " AND ( Device_ID is null or Device_ID = 0) "
                Return Me._objDataProc.ExecuteNonQuery(strsql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************************

#End Region

        '********************************************************************************
        Public Function GetOpenPallets(ByVal iLocID As Integer) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT DISTINCT tpallett.*, pt_id, Pallettype_LDesc, NoPartAllow, BillRule_ID, Pallett_Name as 'Lot Name' " & Environment.NewLine
                strSql &= ", if(Model_Desc is null, '', Model_Desc) as Model " & Environment.NewLine
                strSql &= ", if(tworkorder.WO_CustWO is null, '', tworkorder.WO_CustWO) as 'Workorder' " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "INNER JOIN lpallettype ON tpallett.PalletType_ID = lpallettype.PalletType_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tmodel ON tpallett.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tworkorder ON tpallett.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                strSql &= "WHERE Pallet_Invalid = 0 AND tpallett.loc_id = " & iLocID & " AND Pallett_ReadyToShipFlg = 0 " & Environment.NewLine
                strSql &= "ORDER BY 'Lot Name' "
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************************
        Public Function GetOpenPalletCount(ByVal iLocID As Integer, _
                                           ByVal iPalletTypeID As Integer, _
                                           Optional ByVal iModelID As Integer = 0) As Integer
            Dim strSql As String

            Try
                strSql = "SELECT count(*) as cnt " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "WHERE Pallet_Invalid = 0 AND loc_id = " & iLocID & " AND Pallett_ReadyToShipFlg = 0 " & Environment.NewLine
                strSql &= "AND PalletType_ID = " & iPalletTypeID & Environment.NewLine
                If iModelID > 0 Then strSql &= "AND Model_ID = " & iModelID & Environment.NewLine
                Return Me._objDataProc.GetIntValue(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************************
        Public Function CreatePalletGP(ByVal iCustID As Integer, _
                                       ByVal iLocID As Integer, _
                                       ByVal iModelID As Integer, _
                                       ByVal iPalletTypeID As Integer, _
                                       ByVal strPalletTypeSDesc As String, _
                                       ByVal iPalletShipType As Integer, _
                                       Optional ByVal strCust_PO As String = "") As Integer
            Dim strSql, strSvrDate, strPalletName As String
            Dim iNextNo As Integer = 0

            Try
                strPalletName = iLocID.ToString.PadLeft(5, "0")
                strSvrDate = Format(CDate(Generic.MySQLServerDateTime()), "yyMMdd")

                '*********************************************
                'Get Pallet next sequence number
                '*********************************************
                strSql = "SELECT max(if(Right(Pallett_Name,4) is null, 0, Right(Pallett_Name,4) )) as Seq " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "WHERE Pallett_Name like '" & strPalletName & "%" & strSvrDate & "%'" & Environment.NewLine
                strSql &= "AND Loc_ID = " & iLocID & Environment.NewLine
                iNextNo = Me._objDataProc.GetIntValue(strSql)

                '*********************************************
                'Construct pallet name
                '*********************************************
                strPalletName &= strPalletTypeSDesc.Trim.ToUpper & strSvrDate & "N" & (iNextNo + 1).ToString.PadLeft(4, "0")

                If iCustID = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_CUSTOMER_ID _
                   AndAlso iLocID = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_Special_LOC_ID Then
                    Dim iPallettName As Long = 6010921040399999
                    Dim strPN As String = "0" & iPallettName.ToString
                    Dim dtPN As DataTable

                    strSql = "select * from production.tpallett where cust_ID=" & iCustID & " and loc_ID=" & iLocID & Environment.NewLine
                    strSql &= " and length(Trim(Pallett_Name))=Length('" & strPN & "') and pallett_name REGEXP '^-?[0-9]+$'" & Environment.NewLine
                    strSql &= "Order By CONVERT(pallett_Name, Unsigned Integer ) Asc limit 1;"
                    dtPN = Me._objDataProc.GetDataTable(strSql)
                    If dtPN.Rows.Count > 0 Then  'should be 1
                        iPallettName = dtPN.Rows(0).Item("Pallett_Name")
                        iPallettName = iPallettName - 1
                        strPalletName = "0" & iPallettName.ToString
                        If Not strPalletName.Trim.Length = strPN.Length Then
                            Throw New Exception("Invalid pallet name '" & strPalletName & "'")
                        End If
                    Else
                        strPalletName = strPN
                    End If

                    strSql = "select * from production.tpallett where cust_ID=2" & iCustID & " and loc_ID=" & iLocID & " and Pallett_Name='" & strPalletName & "';"
                    dtPN = Me._objDataProc.GetDataTable(strSql)
                    If dtPN.Rows.Count > 0 Then Throw New Exception("Pallet name '" & strPalletName & "' is already in the system! See IT.")
                End If

                    '*********************************************
                    'Create Pallet
                    '*********************************************
                    strSql = "INSERT INTO tpallett ( " & Environment.NewLine
                    strSql &= "Pallett_Name " & Environment.NewLine
                    strSql &= ", Pallet_ShipType " & Environment.NewLine
                    If iModelID > 0 Then strSql &= ", Model_ID " & Environment.NewLine
                    strSql &= ", Cust_ID  " & Environment.NewLine
                    strSql &= ", Loc_ID  " & Environment.NewLine
                    strSql &= ", PalletType_ID  " & Environment.NewLine
                    strSql &= ", Cust_PO  " & Environment.NewLine
                    strSql &= ") VALUES (  " & Environment.NewLine
                    strSql &= "'" & strPalletName.ToUpper & "' " & Environment.NewLine
                    strSql &= ", " & iPalletShipType & Environment.NewLine
                    If iModelID > 0 Then strSql &= ", " & iModelID & Environment.NewLine
                    strSql &= ", " & iCustID & " " & Environment.NewLine
                    strSql &= ", " & iLocID & " " & Environment.NewLine
                    strSql &= ", " & iPalletTypeID & Environment.NewLine
                    strSql &= ", '" & strCust_PO & "'" & Environment.NewLine
                    strSql &= ");" & Environment.NewLine
                    Return Me._objDataProc.idTransaction(strSql, "tpallett")

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************************
        Public Function CreateSpecialLotPallet(ByVal iCustID As Integer, _
                                       ByVal iLocID As Integer, _
                                       ByVal iModelID As Integer, _
                                       ByVal Pallet_Name As String, _
                                       ByVal Pallet_ShipDate As String, _
                                       ByVal Pallet_BulkShipped As Integer, _
                                       ByVal Pallet_ReadyToShipFlg As Integer, _
                                       ByVal SpecialInvProject As Integer, _
                                       ByVal Pallet_QTY As Integer) As Integer
            Dim strSql As String = ""

            Try
                '*********************************************
                'Create Special Lot/Pallet
                '*********************************************
                strSql = "INSERT INTO tpallett ( " & Environment.NewLine
                strSql &= "Cust_ID  " & Environment.NewLine
                strSql &= ", Loc_ID  " & Environment.NewLine
                strSql &= ", Model_ID  " & Environment.NewLine
                strSql &= ", Pallett_Name  " & Environment.NewLine
                strSql &= ", Pallett_ShipDate  " & Environment.NewLine
                strSql &= ", Pallett_BulkShipped  " & Environment.NewLine
                strSql &= ", Pallett_ReadyToShipFlg  " & Environment.NewLine
                strSql &= ", SpecialInvProject  " & Environment.NewLine
                strSql &= ", Pallett_QTY  " & Environment.NewLine
                strSql &= ") VALUES (  " & Environment.NewLine
                strSql &= iCustID & " " & Environment.NewLine
                strSql &= ", " & iLocID & " " & Environment.NewLine
                strSql &= ", " & iModelID & " " & Environment.NewLine
                strSql &= ",'" & Pallet_Name.ToUpper & "' " & Environment.NewLine
                strSql &= ",'" & Pallet_ShipDate & "' " & Environment.NewLine
                strSql &= ", " & Pallet_BulkShipped & " " & Environment.NewLine
                strSql &= ", " & Pallet_ReadyToShipFlg & " " & Environment.NewLine
                strSql &= ", " & SpecialInvProject & " " & Environment.NewLine
                strSql &= ", " & Pallet_QTY & " " & Environment.NewLine
                strSql &= ");" & Environment.NewLine
                Return Me._objDataProc.idTransaction(strSql, "tpallett")

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************************
        Public Function ClosePalletGP(ByVal iPalletID As Integer, _
                                      ByVal strPalletName As String, _
                                      ByVal iModelID As Integer, _
                                      ByVal strPalletTypeLDesc As String, _
                                      ByVal iPalletQty As Integer, _
                                      ByVal iProdID As Integer, _
                                      Optional ByVal strCustomerName As String = "") As Integer

            Dim strSql As String = ""
            Dim i As Integer = 0
            Dim iPrintBoxLabelQty As Integer = 3

            Try
                If iProdID = 71 Then iPrintBoxLabelQty = 1

                If iProdID = 18 Then
                    'Get total Component quantity - Plastronics Socket Company
                    strSql = "Select sum(Device_Qty) as cnt From tdevice where Pallett_ID = " & iPalletID.ToString & " Group By Pallett_ID"
                    iPalletQty = Me._objDataProc.GetIntValue(strSql)
                End If

                strSql = "update tpallett set Pallett_ReadyToShipFlg = 1, Pallett_QTY = " & iPalletQty & ", AQL_QCResult_ID = 0 where pallett_id = " & iPalletID.ToString
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                'Print Crystal Report ( Pallet Label )
                If iProdID = 14 Then 'Hard Drive Round2
                    'Const strReportName As String = "C:\Label\4x4GenericShipBoxLabel.rpt"
                    Dim strReportName As String = "P:\Dept\Labels\" & System.Net.Dns.GetHostName & "\4x4GenericShipBoxLabel.rpt"
                    iPrintBoxLabelQty = 1
                    PSS.Data.Production.Shipping.Print4x4GenericShipBoxLabel(iPalletID, strReportName, iPrintBoxLabelQty, True)
                ElseIf iProdID = 18 Then 'Plastronics Socket Company
                    'Angel said leave Pallet Type blank
                    'Production.Shipping.PrintCustomerPallet(strCustomerName, strPalletName, iModelID, strPalletTypeLDesc, iPalletQty, 2)
                    iPrintBoxLabelQty = 2
                    Production.Shipping.PrintCustomerPallet(strCustomerName, strPalletName, iModelID, "", iPalletQty, iPrintBoxLabelQty)
                Else
                    Production.Shipping.PrintPalletLicensePlate(strPalletName, iModelID, strPalletTypeLDesc, iPalletQty, iPrintBoxLabelQty)
                End If

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************************
        Public Function GetPalletTypeLDesc(ByVal iPalletTypeID As Integer) As String
            Dim strSql As String

            Try
                strSql = "SELECT Pallettype_LDesc " & Environment.NewLine
                strSql &= "FROM lpallettype " & Environment.NewLine
                strSql &= "WHERE PalletType_ID = " & iPalletTypeID & Environment.NewLine
                Return Me._objDataProc.GetSingletonString(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************************
        Public Function GetReadyToBeShipPallets(ByVal iLocID As Integer) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT tpallett.*, Pallett_Name as 'Lot Name' " & Environment.NewLine
                strSql &= ", if(Model_Desc is null, '', Model_Desc) as Model " & Environment.NewLine
                strSql &= ", Pallett_QTY as 'Qty' " & Environment.NewLine
                strSql &= ", pt_id, Pallettype_LDesc, NoPartAllow, BillRule_ID " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "INNER JOIN lpallettype ON tpallett.PalletType_ID = lpallettype.PalletType_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tmodel ON tpallett.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "WHERE Pallet_Invalid = 0 AND Pallett_ReadyToShipFlg  = 1 AND Pallett_BulkShipped  = 0  " & Environment.NewLine
                strSql &= "AND Pallett_ShipDate is null " & Environment.NewLine
                strSql &= "AND Loc_ID = " & iLocID & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************************
        Public Function CreateManifest(ByVal iPalletID As Integer, _
                                       ByVal strFilePath As String, _
                                       ByVal iPrintCopyNo As Integer, _
                                       ByVal booAddSNBarcodeColumn As Boolean, _
                                       ByVal booSetBorder As Boolean) As Integer
            Const iTotalHeader As Integer = 1
            'Excel Related variables
            Dim objDataProc As DBQuery.DataProc
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet
            Dim xlBI As Excel.XlBordersIndex() = {Excel.XlBordersIndex.xlEdgeLeft, Excel.XlBordersIndex.xlEdgeTop, Excel.XlBordersIndex.xlEdgeBottom, _
                Excel.XlBordersIndex.xlEdgeRight, Excel.XlBordersIndex.xlInsideVertical, Excel.XlBordersIndex.xlInsideHorizontal}

            Dim strSql, strPalletName As String
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim objArr(,) As Object
            Dim i, j As Integer

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                strSql = "SELECT 0 as '#' " & Environment.NewLine
                strSql &= ", Pallett_Name as 'Lot Name' " & Environment.NewLine
                strSql &= ", tdevice.Device_SN as 'SN' " & Environment.NewLine
                If booAddSNBarcodeColumn Then strSql &= ", concat('*', tdevice.Device_SN, '*') as 'SN Barcode' " & Environment.NewLine
                strSql &= ", if(SN2 is null, '', SN2 ) as 'SN2' " & Environment.NewLine
                strSql &= ", if(InPO is null, '', InPO ) as 'PO' " & Environment.NewLine
                strSql &= ", if(InRMA is null, '', InRMA ) as 'RMA' " & Environment.NewLine
                strSql &= ", Pallettype_LDesc as 'Result'" & Environment.NewLine
                strSql &= ", tmodel.Model_Desc as 'Model' " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN lpallettype ON tpallett.PalletType_ID = lpallettype.PalletType_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tasndata ON tdevice.Device_ID = tasndata.Device_ID " & Environment.NewLine
                strSql &= "WHERE tdevice.Pallett_ID = " & iPalletID.ToString & " " & Environment.NewLine
                strSql &= "ORDER BY tdevice.Device_SN " & Environment.NewLine
                dt = objDataProc.GetDataTable(strSql)

                'Create Line #
                i = 0
                For Each R1 In dt.Rows
                    i += 1
                    R1.BeginEdit()
                    R1("#") = i
                    R1.EndEdit()
                    R1.AcceptChanges()
                Next R1
                dt.AcceptChanges()

                If dt.Rows.Count > 0 Then
                    strPalletName = dt.Rows(0)("Lot Name")

                    ''Remove unneccessary columns
                    'If dt.Rows(0)("Pallet_ShipType") = 0 Then dt.Columns.Remove("Fail Reason")
                    dt.Columns.Remove("Lot Name")
                    dt.AcceptChanges()

                    ReDim objArr(dt.Rows.Count + iTotalHeader, dt.Columns.Count)

                    ''Write title & total
                    'objArr(0, 0) = "Pallet Manifest"
                    'objArr(1, 0) = "Pallet ID: " + strFileName
                    'objArr(2, 0) = "Destination: " + strLoc
                    'objArr(3, 0) = "Total: " + dt.Rows.Count.ToString

                    'Write Header
                    For i = 0 To dt.Columns.Count - 1
                        objArr(iTotalHeader - 1, i) = dt.Columns(i).Caption
                    Next i

                    'Write Data
                    For i = 0 To dt.Rows.Count - 1
                        For j = 0 To dt.Columns.Count - 1
                            objArr(i + iTotalHeader, j) = dt.Rows(i)(j)
                        Next
                    Next i

                    'Instantiate Excel Object
                    objExcel = New Excel.Application()      'Starts the Excel Session
                    objBook = objExcel.Workbooks.Add                    'Add a Workbook
                    objExcel.Application.Visible = True                'Make this false while going live
                    objExcel.Application.DisplayAlerts = False
                    objSheet = objBook.Worksheets.Item(1)               'Select a Sheet 1 for this

                    objExcel.ActiveSheet.Pagesetup.Orientation = 2      ' 1 = Portrait ; 2 = landscape

                    '*******************************
                    'set text format
                    '*******************************
                    For i = 1 To dt.Columns.Count - 1
                        objSheet.Columns(i + 1).Select()
                        objExcel.Selection.NumberFormat = "@"
                    Next i

                    objSheet.Range("A1" & ":" & Generic.CalExcelColLetter(dt.Columns.Count) & (dt.Rows.Count + iTotalHeader).ToString).Value = objArr

                    ''*******************************
                    ''Titles & Total
                    ''*******************************
                    'objSheet.Range("A1:" & Generic.CalExcelColLetter(dt.Columns.Count) & (iTotalHeader - 1).ToString).HorizontalAlignment = Excel.Constants.xlLeft
                    'objSheet.Range("A1:" & Generic.CalExcelColLetter(dt.Columns.Count) & (iTotalHeader - 1).ToString).VerticalAlignment = Excel.Constants.xlCenter
                    ''*******************************
                    'With objSheet.Range("A1:" & Generic.CalExcelColLetter(dt.Columns.Count) & (iTotalHeader - 1).ToString).Font
                    '    .Name = "Arial"
                    '    .FontStyle = "Bold"
                    '    .Size = 14
                    '    .Underline = False
                    '    .ColorIndex = 25
                    'End With
                    'objSheet.Range("A1", Generic.CalExcelColLetter(dt.Columns.Count) & (1).ToString).Merge()
                    'objSheet.Range("A2", Generic.CalExcelColLetter(dt.Columns.Count) & (2).ToString).Merge()
                    'objSheet.Range("A3", Generic.CalExcelColLetter(dt.Columns.Count) & (3).ToString).Merge()
                    'objSheet.Range("A4", Generic.CalExcelColLetter(dt.Columns.Count) & (4).ToString).Merge()

                    '*******************************
                    'header
                    '*******************************
                    objSheet.Range("A" & iTotalHeader & ":" & Generic.CalExcelColLetter(dt.Columns.Count) & iTotalHeader.ToString).HorizontalAlignment = Excel.Constants.xlCenter
                    objSheet.Range("A" & iTotalHeader & ":" & Generic.CalExcelColLetter(dt.Columns.Count) & iTotalHeader.ToString).VerticalAlignment = Excel.Constants.xlCenter
                    '*******************************
                    With objSheet.Range("A" & iTotalHeader & ":" & Generic.CalExcelColLetter(dt.Columns.Count) & iTotalHeader.ToString).Font
                        .Name = "Arial"
                        .FontStyle = "Bold"
                        .Size = 8
                        .Underline = False
                        .ColorIndex = 25
                    End With
                    objExcel.Range("A" & iTotalHeader & ":" & Generic.CalExcelColLetter(dt.Columns.Count) & iTotalHeader.ToString).Select()
                    objExcel.Selection.Interior.ColorIndex = 15 'LIGHT GRAY

                    '*******************************
                    'set border
                    '*******************************
                    If booSetBorder Then
                        objExcel.Range("A" & iTotalHeader & ":" & Generic.CalExcelColLetter(dt.Columns.Count) & (dt.Rows.Count + iTotalHeader).ToString).Select()
                        objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.Constants.xlNone
                        objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.Constants.xlNone

                        For j = 0 To xlBI.Length - 1
                            With objExcel.Selection.Borders(xlBI(j))
                                .LineStyle = Excel.XlLineStyle.xlContinuous
                                .Weight = Excel.XlBorderWeight.xlThin
                                .ColorIndex = Excel.Constants.xlAutomatic
                            End With
                        Next j
                    End If

                    '*******************************
                    'Set column with
                    '*******************************
                    ExcelReports.SetCellWidths(objSheet, dt)

                    '*******************************
                    If booAddSNBarcodeColumn Then
                        objSheet.Range("C2:C" & (dt.Rows.Count + 1)).Select()
                        With objExcel.Selection
                            .Font.Name = "C39P12DhTt"
                            .Font.Size = 18

                            .HorizontalAlignment = Excel.Constants.xlCenter
                            .VerticalAlignment = Excel.Constants.xlCenter
                        End With

                        For j = 1 To dt.Rows.Count
                            objSheet.Rows(j + 1).RowHeight = 40
                        Next j

                        For j = 1 To dt.Columns.Count
                            If dt.Columns(j - 1).Caption.EndsWith("Barcode") Then
                                Dim strColLeter As String = Generic.CalExcelColLetter(j)
                                objSheet.Columns(strColLeter & ":" & strColLeter).ColumnWidth = 44
                                Exit For
                            End If
                        Next j
                    End If

                    '*******************************
                    ' Freeze column headers area
                    '*******************************
                    objExcel.ActiveWindow.FreezePanes = False
                    objExcel.Range("A1:" & Generic.CalExcelColLetter(dt.Columns.Count) & (2).ToString).Select()
                    objExcel.ActiveWindow.FreezePanes = True

                    '*******************************
                    With objSheet.PageSetup
                        .Orientation = Excel.XlPageOrientation.xlLandscape
                        .LeftHeader = "&""Arial,Bold""&14Lot Manifest" & Chr(10) & "Lot Name: " & strPalletName & Chr(10) & "Total: " & dt.Rows.Count.ToString
                        .LeftFooter = "** PSS Confidential **"
                        .CenterFooter = "&P of &N" & " (" & strPalletName & ")"
                        .RightFooter = "&D&' @'&T"
                        .HeaderMargin = -25
                        .TopMargin = 100
                        .RightMargin = -25
                        .LeftMargin = -25
                        '.FitToPagesWide = 1
                        '.FitToPagesTall = 1
                    End With

                    '*******************************
                    'Save file
                    '*******************************
                    If Directory.Exists(strFilePath) = False Then Directory.CreateDirectory(strFilePath)
                    If File.Exists(strFilePath) Then Kill(strFilePath & strPalletName & ".xls")
                    objBook.SaveAs(strFilePath & strPalletName & ".xls")

                    '***********************************
                    'print Report
                    '***********************************
                    If iPrintCopyNo > 0 Then objExcel.ActiveWindow.SelectedSheets.PrintOut(Copies:=iPrintCopyNo, Collate:=True)
                    '***********************************
                End If

                Return dt.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
                Generic.DisposeDT(dt)
                xlBI = Nothing
                objArr = Nothing

                '*************************************
                'Excel clean up
                If Not IsNothing(objSheet) Then
                    Generic.NAR(objSheet)
                End If
                If Not IsNothing(objBook) Then
                    objBook.Close(False)
                    Generic.NAR(objBook)
                End If
                If Not IsNothing(objExcel) Then
                    objExcel.Quit()
                    Generic.NAR(objExcel)
                End If
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function

        '********************************************************************************
        Public Function ExtractSNs(ByVal strManifestLoc As String, _
                                   ByVal iPalletID As Integer, _
                                   ByVal iLocID As Integer) As DataTable
            Dim strSql As String = ""
            Dim R1 As DataRow
            Dim dt1, dtPalletInfo As DataTable
            Dim i As Integer = 1
            Dim booDeviceHasParts As Boolean = False

            Try
                '***********************************
                'Added by Lan on 03/15/07
                'prevent user from ship open pallet
                'THIS OCCUR WHEN OTHER MACHINE OPEN PALLET AND CURRENT MACHINE DID NOT GET REFRESH
                '***********************************
                strSql = "select tpallett.*, BillRule_ID, NoPartAllow from tpallett  " & Environment.NewLine
                strSql &= "inner join lpallettype on tpallett.PalletType_ID = lpallettype.PalletType_ID " & Environment.NewLine
                strSql &= "where Pallett_id = " & iPalletID & ";"
                dtPalletInfo = Me._objDataProc.GetDataTable(strSql)
                If dtPalletInfo.Rows.Count > 0 Then
                    If dtPalletInfo.Rows(0)("Pallett_ReadyToShipFlg") = 0 Then
                        Throw New Exception("This lot may have been reopened. Please close this screen and reopen it.")
                    End If
                Else
                    Throw New Exception("Lot does not exist.")
                End If
                '***********************************
                'Get all devices in pallet in systems
                '************************************
                strSql = "SELECT Device_SN as SN, '' as BillCode_Rule, tdevice.Model_ID" & Environment.NewLine
                strSql &= ", Model_Desc, '' as SKU_Number, '' as RURRTMHasParts" & Environment.NewLine
                strSql &= ", Device_ID as Device_ID, WO_ID as WO_ID, Device_DateBill, Loc_ID FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID" & Environment.NewLine
                strSql &= "WHERE Pallett_ID = " & iPalletID
                dt1 = Me._objDataProc.GetDataTable(strSql)

                For Each R1 In dt1.Rows
                    If IsDBNull(R1("Device_DateBill")) Then Throw New Exception("Device has not been billed.")

                    If dtPalletInfo.Rows(0)("Model_ID") > 0 AndAlso R1("Model_ID") <> dtPalletInfo.Rows(0)("Model_ID") Then Throw New Exception("Model of device and lot does not match.")

                    booDeviceHasParts = Generic.IsDeviceHadParts(R1("Loc_ID"))
                    If dtPalletInfo.Rows(0)("NoPartAllow") = 1 AndAlso booDeviceHasParts = True Then
                        Throw (New Exception("Device """ & R1("SN") & """ has part(s)."))
                    End If

                    R1.BeginEdit()
                    R1("SKU_Number") = dtPalletInfo.Rows(0)("Pallet_SkuLen")
                    If dtPalletInfo.Rows(0)("Pallet_ShipType") <> 0 AndAlso booDeviceHasParts = True Then R1("RURRTMHasParts") = 1
                    R1("BillCode_Rule") = Generic.GetMaxBillRule(R1("Device_ID"))
                    R1.EndEdit()
                    dt1.AcceptChanges()

                    booDeviceHasParts = False
                Next R1
                '***************************************

                Return dt1

            Catch ex As Exception
                Throw New Exception("Buisness.BulkShipping.ExtractSNs(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                R1 = Nothing
                Generic.DisposeDT(dt1)
                Generic.DisposeDT(dtPalletInfo)
            End Try
        End Function

        '********************************************************************************
        Public Function ExtractSNsWithoutASNFile(ByVal iPalletID As Integer) As DataTable
            Dim strSql As String = ""
            Try

                strSql = "SELECT Device_SN as 'SN', Pallet_ShipType as BillCode_Rule, tdevice.Model_ID as Model_ID" & Environment.NewLine
                strSql &= ", Model_Desc , Pallet_SkuLen as SKU_Number, '' as RURRTMHasParts, Device_ID as device_id " & Environment.NewLine
                strSql &= ", tdevice.WO_ID as wo_id" & Environment.NewLine
                strSql &= "FROM tpallett inner join tdevice on tdevice.pallett_id = tpallett.pallett_id" & Environment.NewLine
                strSql &= "INNER JOIN tmodel on tdevice.model_id = tmodel.model_id" & Environment.NewLine
                strSql &= "where tpallett.Pallett_ID = " & iPalletID & ";"
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************************
        Public Function GetProdID(ByVal iModelID As Integer) As Integer
            Dim strSql As String

            Try
                strSql = "SELECT Prod_ID " & Environment.NewLine
                strSql &= "FROM tmodel WHERE Model_ID = " & iModelID & Environment.NewLine
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetModelIdOfDevice(ByVal device_id As Integer) As Integer
            Dim strSql As String

            Try
                strSql = "SELECT model_id "
                strSql &= "FROM tdevice "
                strSql &= "WHERE device_id = " & device_id & """"
                Return _objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetModelIdOfPallet(ByVal pallet_id As Integer) As Integer
            Dim strSql As String
            Try
                strSql = "SELECT model_id "
                strSql &= "FROM tpallett "
                strSql &= "WHERE pallett_id = " & pallet_id & ""
                Return _objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function



        '********************************************************************************
        Public Function AttachedPalletToWO(ByVal iPalletID As Integer, ByVal iWOID As Integer) As Integer
            Dim strSql As String

            Try
                strSql = "UPDATE tpallett SET WO_ID = " & iWOID & Environment.NewLine
                strSql &= "WHERE Pallett_ID = " & iPalletID & " AND WO_ID = 0" & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************************
        Public Function ReleasePalletFromWO(ByVal iPalletID As Integer) As Integer
            Dim strSql As String

            Try
                strSql = "UPDATE tpallett SET WO_ID = 0 " & Environment.NewLine
                strSql &= "WHERE Pallett_ID = " & iPalletID & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************************
        Public Function AQL_GetOpenLotID(ByVal iCust_id As Integer) As Integer
            Dim strSql, AQL_Date, strtest As String
            AQL_Date = Format(Now(), "yyyy-MM-dd")


            Try
                strSql = "Select AQL_Lot_ID From AQL_Lot" & Environment.NewLine
                strSql &= "WHERE Cust_ID = " & iCust_id & Environment.NewLine
                strSql &= "And AQL_Close = 0" & Environment.NewLine
                strSql &= "And AQL_Date ='" & AQL_Date & "'" & Environment.NewLine
                strSql &= "Order By AQL_Lot_ID desc limit 1" & Environment.NewLine
                strtest = Me._objDataProc.GetSingletonString(strSql)
                If strtest = "" Then
                    Return 0
                Else
                    Return CInt(strtest)
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '********************************************************************************
        Public Function AQL_GetQty(ByVal iAQL_Lot_ID As Integer) As Integer
            Dim strSql As String

            Try
                strSql = "Select Quantity From AQL_Lot" & Environment.NewLine
                strSql &= "WHERE AQL_Lot_ID = " & iAQL_Lot_ID & Environment.NewLine
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '********************************************************************************
        Public Function AQL_CreateLot(ByVal iCust_id As Integer, ByVal iQuantity As Integer) As Integer
            Dim strSql, AQL_Date, strLotNameFormat, strAQLLotName As String
            Dim iNextNo As Integer

            Try

                AQL_Date = Format(Now(), "yyyy-MM-dd")
                strLotNameFormat = Format(Now(), "yyyyMMdd")

                '*********************************************
                'Get AQL Lot sequence number
                '*********************************************
                strSql = "SELECT max(if(Right(AQL_Lot_Name,3) is null, 0, Right(AQL_Lot_Name,3) )) as Seq " & Environment.NewLine
                strSql &= "FROM aql_lot " & Environment.NewLine
                strSql &= "WHERE AQL_Date = '" & AQL_Date & "'" & Environment.NewLine
                strSql &= "AND Cust_ID = " & iCust_id & Environment.NewLine
                iNextNo = Me._objDataProc.GetIntValue(strSql)

                '*********************************************
                'Construct and Create AQL Lot Name ; format =YYYYMMDDN###
                '*********************************************
                strAQLLotName = strLotNameFormat & "N" & (iNextNo + 1).ToString.PadLeft(3, "0")

                strSql = "INSERT INTO AQL_Lot (AQL_Lot_Name,Cust_ID,AQL_Date,AQL_Close,Quantity) " & Environment.NewLine
                strSql &= " VALUES (" & Environment.NewLine
                strSql &= "'" & strAQLLotName & "'" & Environment.NewLine
                strSql &= "," & iCust_id & Environment.NewLine
                strSql &= ",'" & AQL_Date & "'" & Environment.NewLine
                strSql &= ",0" & Environment.NewLine
                strSql &= "," & iQuantity & Environment.NewLine
                strSql &= ");" & Environment.NewLine
                Return Me._objDataProc.idTransaction(strSql, "AQL_Lot")

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************************
        Public Function AQL_UpdateQty(ByVal iAQL_Lot_ID As Integer, ByVal iQuantity As Integer) As Integer
            Dim strSql As String

            Try
                strSql = "UPDATE AQL_Lot SET Quantity = " & iQuantity & Environment.NewLine
                strSql &= "WHERE AQL_Lot_ID = " & iAQL_Lot_ID & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '********************************************************************************
        Public Function AQL_AssignLotID(ByVal iPallet_ID As Integer, ByVal iAQL_Lot_ID As Integer) As Integer
            Dim strSql As String

            Try
                strSql = "UPDATE tpallett SET AQL_Lot_ID = " & iAQL_Lot_ID & Environment.NewLine
                strSql &= "WHERE Pallett_ID = " & iPallet_ID & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '********************************************************************************
        Public Function AQL_CloseLot(ByVal iAQL_Lot_ID As Integer) As Integer
            Dim strSql As String

            Try
                strSql = "UPDATE AQL_Lot SET AQL_Close = 1" & Environment.NewLine
                strSql &= "WHERE AQL_Lot_ID = " & iAQL_Lot_ID & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '********************************************************************************

    End Class
End Namespace
