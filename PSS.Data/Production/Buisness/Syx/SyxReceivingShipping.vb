Option Explicit On 
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Windows.Forms
Imports System.IO
Namespace Buisness
    Public Class SyxReceivingShipping
        Private _objDataProc As DBQuery.DataProc
        Private _strRptPath As String = "P:\Dept\Labels\" & System.Net.Dns.GetHostName & "\"
        Public Const _PalletManifestDir As String = "P:\Dept\SYX\Pallet packing list\"
        Private _strLabelShipping As String = "Syx_Shipping_Label.rpt"
        Private _strLabelReceiveBox As String = "Syx_Receive_Box_Label.rpt"


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

        '******************************************************************
        Private Sub NAR(ByRef o As Object)
            Try
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o)
            Catch
            Finally
                o = Nothing
            End Try
        End Sub

        '****************************************************************************************************
        Public Function GetSyxReceivedData(ByVal iWOID As Integer) As DataTable
            Dim strSql As String = String.Empty
            Dim dt As DataTable
            Dim i As Integer

            Try
                strSql = "SELECT 0 as 'Cnt'" & Environment.NewLine
                strSql &= ", IF(tmodel.Model_Desc IS NULL, syxdata.Model_Desc, tmodel.Model_Desc ) as 'Model'" & Environment.NewLine
                strSql &= ", syxdata.ReceivingPalletName as 'Receiving Pallet' " & Environment.NewLine
                strSql &= ", Device_SN as 'PSS SN' " & Environment.NewLine
                strSql &= ", syxdata.Manuf_SN as 'Manuf SN' " & Environment.NewLine
                strSql &= ", if( syxdata.HasBox = 1, 'Yes', 'No') as 'Has Box?' " & Environment.NewLine
                strSql &= ", if( Device_ManufWrty = 1, 'Yes', 'No') as 'Manuf Warranty?' " & Environment.NewLine
                strSql &= ", if( Device_PSSWrty = 1, 'Yes', 'No') as 'PSS Warranty?' " & Environment.NewLine
                strSql &= ", Device_DateRec as 'Receipt Date' " & Environment.NewLine
                strSql &= ", user_fullname as Receiver, syxdata.Receiver_Comment " & Environment.NewLine
                strSql &= ", if(tdevice.Model_ID = 0, 'Yes', 'No') as 'Missing Model?' " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN syxdata ON tdevice.Device_ID = syxdata.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN security.tusers ON syxdata.Receiver_UserID = security.tusers.User_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "WHERE tdevice.WO_ID = " & iWOID & Environment.NewLine
                strSql &= "ORDER BY tdevice.Device_ID " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                For i = 1 To dt.Rows.Count
                    dt.Rows(i - 1).BeginEdit() : dt.Rows(i - 1)("Cnt") = i : dt.Rows(i - 1).EndEdit()
                Next i
                dt.AcceptChanges()

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        ''****************************************************************************************************
        'Public Function GetDistinctMissingModelList(ByVal iWOID As Integer) As DataTable
        '    Dim strSql As String = String.Empty

        '    Try
        '        strSql = "SELECT distinct WO_CustWO as 'Work Order #', syxdata.Model_Desc as 'Model'" & Environment.NewLine
        '        strSql &= ", Manuf_Desc as Manufacture " & Environment.NewLine
        '        strSql &= ", lproduct.Prod_Desc as 'Product', count(*) as Quantity " & Environment.NewLine
        '        strSql &= ", lproduct.Prod_ID, lmanuf.Manuf_ID, tdevice.WO_ID " & Environment.NewLine
        '        strSql &= "FROM tdevice " & Environment.NewLine
        '        strSql &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
        '        strSql &= "INNER JOIN syxdata ON tdevice.Device_ID = syxdata.Device_ID " & Environment.NewLine
        '        strSql &= "INNER JOIN lmanuf ON syxdata.Manuf_ID = lmanuf.Manuf_ID " & Environment.NewLine
        '        strSql &= "INNER JOIN lproduct ON tworkorder.Prod_ID =  lproduct.Prod_ID " & Environment.NewLine
        '        strSql &= "WHERE tdevice.Model_ID = 0 " & Environment.NewLine
        '        If iWOID > 0 Then strSql &= "AND tdevice.WO_ID = " & iWOID & Environment.NewLine
        '        strSql &= "GROUP BY 'Work Order #', 'Model', Manufacture, 'Product' " & Environment.NewLine
        '        strSql &= "ORDER BY Model " & Environment.NewLine
        '        Return Me._objDataProc.GetDataTable(strSql)
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Function

        '****************************************************************************************************
        Public Function ReceiveSyxDevice(ByVal iWOID As Integer, ByVal iTrayID As Integer, ByVal iCCID As Integer, _
                                         ByVal strRecPalletName As String, ByVal iManufID As Integer, ByVal iModelID As Integer, _
                                         ByVal strModelDesc As String, ByVal strRecComments As String, _
                                         ByVal iHasBox As Integer, ByVal strManufSN As String, _
                                         ByVal iShiftID As Integer, ByVal iUserID As Integer, _
                                         ByVal dtAccessories As DataTable, ByVal Unitprice As Double, ByVal iScreenDCodeID As Integer, _
                                         ByVal iProdID As Integer, ByVal iPD_ID As Integer, ByVal EmpNo As Integer, _
                                         ByVal strStatus As String, ByVal strWorkstation As String, _
                                         ByVal strPSSSN As String, ByVal iBoxDamaged As Integer) As Integer
            Dim objRec As New PSS.Data.Production.Receiving()
            Dim i, iCnt, iDeviceID, iPSSWrty, iManufWrty, iWipOwner, iSRC_ID, iRepeatRepCnt As Integer
            Dim strSql, strWrkDate As String

            Try
                i = 0 : iCnt = 0 : iDeviceID = 0 : iPSSWrty = 0 : iManufWrty = 0 : iWipOwner = 1 : iSRC_ID = 0 : iRepeatRepCnt = 0
                strSql = "" : strWrkDate = ""
                'Create device
                iCnt = objRec.GetNextDeviceCountInTray(iTrayID) + 1
                strWrkDate = Generic.GetWorkDate(iShiftID)
                iRepeatRepCnt = objRec.GetRepeatRepCnt(Syx.LOCID, strPSSSN) + 1


                '********************************************
                'CREATE PSSI SERIAL
                '********************************************
                If strPSSSN.Trim.Length = 0 Then
                    iSRC_ID = Me.CreateSyxReceiveSn(iUserID, strPSSSN)
                    If iSRC_ID = 0 Then Throw New Exception("System has failed to create serial number " & strPSSSN & " (ID = 0).")
                End If
                '********************************************
                If strPSSSN.Trim.Length = 0 Then Throw New Exception("System has failed to create serial number (SN is blank).")

                'Insert into tdevice
                iDeviceID = objRec.InsertIntoTdevice(strPSSSN, strWrkDate, iCnt, iTrayID, Syx.LOCID, iWOID, iModelID, iShiftID, iPSSWrty, iManufWrty, , iCCID, , iRepeatRepCnt)
                If iDeviceID = 0 Then Throw New Exception("System has failed to insert into tdevice table.")

                'Create cellopt 
                i = objRec.InsertIntoTCellopt(iDeviceID, , , , , , , , , , , , , , , , strWorkstation, , iWipOwner, strManufSN)
                If i = 0 Then Throw New Exception("System has failed to insert into tcellopt.")

                'Update/insert syxdata table
                i = Me.InsertIntoSyxData(strRecPalletName, iDeviceID, iManufID, iModelID, strModelDesc, iUserID, strRecComments, iHasBox, strPSSSN, strManufSN, Unitprice, iProdID, iPD_ID, strStatus, iBoxDamaged)
                If i = 0 Then Throw New Exception("System has failed to insert into syxdata table.")

                'Update syxreceivesn table
                If iSRC_ID > 0 Then
                    i = Me.UpdatePSSSN(iDeviceID, iSRC_ID)
                    If i = 0 Then Throw New Exception("System has failed to update device ID into syxreceivesn table.")
                End If

                'Insert accessories
                i = Me.ReceiveAccessories(iDeviceID, iUserID, dtAccessories, iScreenDCodeID, iShiftID, EmpNo)

                'Print Receive Box Label
                Dim iNoOfCopyes As Integer = 1
                If iHasBox = 1 Then iNoOfCopyes = 2
                Me.Label_ReceiveBoxLabel(iDeviceID, iNoOfCopyes)

                Return iDeviceID
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dtAccessories)
            End Try
        End Function

        '****************************************************************************************************
        Public Function InsertIntoSyxData(ByVal strRecPalletName As String, ByVal iDeviceID As Integer, ByVal iManufID As Integer, _
                                          ByVal iModelID As Integer, ByVal strModelDesc As String, _
                                          ByVal iUserID As Integer, ByVal strComment As String, ByVal iHasBox As Integer, _
                                          ByVal strPSSSN As String, ByVal strManufSN As String, ByVal Unitprice As Double, _
                                          ByVal iProdID As Integer, ByVal iPD_ID As Integer, _
                                          ByVal strStatus As String, ByVal iBoxDamaged As Integer) As Integer
            Dim strSql As String = String.Empty

            Try
                strSql = "INSERT INTO syxdata ( " & Environment.NewLine
                strSql &= "Device_ID, NewModelProdID, Manuf_ID, Model_ID, Model_Desc, Receiver_UserID, Receiver_Comment, HasBox " & Environment.NewLine
                strSql &= ", ReceivingPalletName, PSS_SerialNumber, Manuf_SN, Cost, PD_ID, Status, BoxDamaged " & Environment.NewLine
                strSql &= ") VALUES (" & Environment.NewLine
                strSql &= iDeviceID & ", " & iProdID & ", " & iManufID & ", " & iModelID & Environment.NewLine
                strSql &= ", '" & strModelDesc & "', " & iUserID & Environment.NewLine
                strSql &= ", '" & strComment & "', " & iHasBox & ", '" & strRecPalletName & "' " & Environment.NewLine
                strSql &= ", '" & strPSSSN & "'" & Environment.NewLine
                strSql &= ", '" & strManufSN & "'" & Environment.NewLine
                strSql &= ", " & Unitprice & Environment.NewLine
                strSql &= ", " & iPD_ID & ", '" & strStatus & "', " & iBoxDamaged & Environment.NewLine
                strSql &= ")"
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************************
        Public Function GetRecQtyByUser(ByVal iUserID As Integer) As Integer
            Dim strSql As String = String.Empty

            Try
                strSql = "SELECT Count(*) as Qty" & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN syxdata ON tdevice.Device_ID = syxdata.Device_ID " & Environment.NewLine
                strSql &= "WHERE tdevice.Loc_ID = " & Syx.LOCID & " AND syxdata.Receiver_UserID = " & iUserID & Environment.NewLine
                strSql &= "AND Date_Format(Device_DateRec, '%Y-%m-%d') = Date_Format(now(), '%Y-%m-%d') " & Environment.NewLine
                strSql &= "GROUP BY Receiver_UserID " & Environment.NewLine
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************************
        Public Function ReceiveAccessories(ByVal iDeviceID As Integer, ByVal User_ID As Integer, _
                                           ByVal dtAccessories As DataTable, ByVal iScreenDCodeID As Integer, ByVal Shift_ID As Integer, ByVal EmpNo As Integer) As Integer
            Dim R1 As DataRow
            Dim strSql As String = ""
            Dim i As Integer = 0
            Dim objSyx As New Syx()
            Dim objBilling As New DeviceBilling()

            Dim BillCode_ID, Fail_ID, Repair_ID As Integer
            Dim Dbill_RegPartPrice, DBill_AvgCost, DBill_StdCost, DBill_InvoiceAmt As Decimal
            Dim Part_Number As String

            Try
                For Each R1 In dtAccessories.Rows
                    'strSql = "INSERT INTO tdeviceaccessories (" & Environment.NewLine
                    'strSql &= "Device_ID, BillCode_ID, Part_Number, Screen_ID, TransUserID, TransDate, Status_ID " & Environment.NewLine
                    'strSql &= ") VALUES ( " & Environment.NewLine
                    'strSql &= iDeviceID & Environment.NewLine
                    'strSql &= ", " & R1("BillCode_ID") & ", '" & R1("Part_Number") & "'" & Environment.NewLine
                    'strSql &= ", " & iScreenDCodeID & ", " & iUserID & ", now() , 3411 " & Environment.NewLine
                    'strSql &= ") "
                    'i += Me._objDataProc.ExecuteNonQuery(strSql)

                    Fail_ID = R1("Fail_ID")
                    Repair_ID = R1("Repair_ID")
                    BillCode_ID = R1("BillCode_ID")
                    DBill_AvgCost = R1("DBill_AvgCost")
                    DBill_StdCost = R1("DBill_StdCost")
                    DBill_InvoiceAmt = R1("DBill_InvoiceAmt")
                    Part_Number = R1("Part_Number")
                    Dbill_RegPartPrice = R1("Dbill_RegPartPrice")
                    objSyx.InsertRemovetDeviceBill(iDeviceID, Dbill_RegPartPrice, DBill_AvgCost, DBill_StdCost, DBill_InvoiceAmt, BillCode_ID, Part_Number, Fail_ID, Repair_ID, User_ID, True)
                    objBilling.InsertPartTransaction(iDeviceID, BillCode_ID, User_ID, EmpNo, Shift_ID, Part_Number, 1, Syx.ScreenID_Receiving)

                Next R1

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dtAccessories)
                objSyx = Nothing
                objBilling = Nothing
            End Try
        End Function

        '****************************************************************************************************
        Public Function UpdateMfgSerial(ByVal iDeviceID As Integer, ByVal new_Manuf_SN As String) As Integer
            Dim R1 As DataRow
            Dim strSql As String = ""

            Try
                strSql = "UPDATE syxdata" & Environment.NewLine
                strSql &= "SET Manuf_SN = '" & new_Manuf_SN & "'" & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************************
        Public Function GetDeviceAccessoriesTemplate() As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT * FROM tdeviceaccessories limit 0 " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************************
        Public Function GetModelAccessories(ByVal iModelID As Integer, ByVal BillType_ID As String) As DataTable
            Dim strSql As String = ""
            ' 1= Services 2=Part 3=Accessory

            Try
                strSql = "SELECT tpsmap.Prod_ID, lbillcodes.Billcode_ID, lbillcodes.Billcode_Desc, lpsprice.* " & Environment.NewLine
                strSql &= "FROM tpsmap INNER JOIN lpsprice ON tpsmap.PSPrice_ID = lpsprice.PSPrice_ID " & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes ON tpsmap.Billcode_ID = lbillcodes.Billcode_ID" & Environment.NewLine
                strSql &= "WHERE tpsmap.Model_ID = " & iModelID & Environment.NewLine
                strSql &= "AND BillType_ID in (" & BillType_ID & ")" & Environment.NewLine
                strSql &= "AND lpsprice.RVFlag = 0" & Environment.NewLine
                strSql &= "AND tpsmap.Inactive = 0" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************************
        Public Function GetASCPrice_ID(ByVal Manuf_ID As Integer, _
                                       ByVal Prod_ID As Integer, _
                                       Optional ByVal Insert As Boolean = False) As Integer

            Dim strSql As String = ""
            Dim ASCPrice_ID As Integer = 0

            Try
                strSql = "Select ASCPrice_ID" & Environment.NewLine
                strSql &= "From lascprice" & Environment.NewLine
                strSql &= "WHERE Prod_ID = " & Prod_ID & Environment.NewLine
                strSql &= "Order By ASCPrice_ID Limit 1" & Environment.NewLine
                ASCPrice_ID = Me._objDataProc.GetIntValue(strSql)

                If ASCPrice_ID = 0 And Insert = True Then
                    ASCPrice_ID = Me.InsertLascPrice(Manuf_ID, Prod_ID)
                End If

                Return ASCPrice_ID

            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '****************************************************************************************************
        Public Function GetProdGrp_ID(ByVal Prod_ID As Integer, _
                                  Optional ByVal ProdGrp_SDesc As String = "", _
                                  Optional ByVal ProdGrp_LDesc As String = "", _
                                  Optional ByVal Insert As Boolean = False) As Integer

            Dim strSql As String = ""
            Dim ProdGrp_ID As Integer

            Try
                strSql = "Select ProdGrp_ID" & Environment.NewLine
                strSql &= "From lprodgrp" & Environment.NewLine
                strSql &= "Where Prod_ID = " & Prod_ID & Environment.NewLine
                strSql &= "Order By ProdGrp_ID Limit 1" & Environment.NewLine
                ProdGrp_ID = Me._objDataProc.GetIntValue(strSql)

                If ProdGrp_ID = 0 And Insert = True Then
                    ProdGrp_ID = Me.InsertLprodgrp(ProdGrp_SDesc, ProdGrp_LDesc, Prod_ID)
                End If

                Return ProdGrp_ID

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************************
        Public Function GetModelInfo(ByVal Model_Desc As String) As DataTable

            Dim strSql As String = ""

            Try
                strSql = "Select a.*,b.Prod_Desc,c.Manuf_Desc" & Environment.NewLine
                strSql &= "From tmodel a" & Environment.NewLine
                strSql &= "Inner Join lproduct b on b.prod_id=a.prod_id" & Environment.NewLine
                strSql &= "Inner Join lmanuf c on c.manuf_id=a.manuf_id" & Environment.NewLine
                strSql &= "WHERE Model_Desc ='" & Model_Desc & "'" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************************
        Public Function GetRptGrp_ID(ByVal Prod_ID As Integer) As Integer

            Dim strSql As String = ""

            Try
                strSql = "SELECT RptGrp_ID " & Environment.NewLine
                strSql &= "FROM lrptgrp" & Environment.NewLine
                strSql &= "Where Prod_ID = " & Prod_ID & Environment.NewLine
                strSql &= "Order By RptGrp_ID Limit 1" & Environment.NewLine
                Return Me._objDataProc.GetIntValue(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************************
        Public Function GetPalletItemNumber(ByVal strItemNumber As String) As DataTable

            Dim strSql As String = ""

            Try
                strSql = "Select *" & Environment.NewLine
                strSql &= "From syxrecpalletdata" & Environment.NewLine
                strSql &= "WHERE itemnumber = '" & strItemNumber & "'" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try

        End Function

        '****************************************************************************************************
        Public Function GetPalletDataInfo(ByVal strPalletID As String, _
                                          ByVal strItemNumber As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "Select syxrecpalletdata.PD_ID, ItemNumber, ItemDescription, 0 as 'To Be Rec Qty', count(Device_ID) as 'Received Qty'" & Environment.NewLine
                strSql &= ", OnHandQty, OriginalOnHandQty, LastUpdateValue, OriginalLastUpdateValue" & Environment.NewLine
                strSql &= ", UPCCode, syxrecpallet.PalletID, syxrecpalletdata.InFile, Discrepancy, DiscrepancySetDate" & Environment.NewLine
                strSql &= ", unitcost " & Environment.NewLine
                strSql &= ", IF(syxrecpallet.Closed = 0 , 'No', 'Yes') as 'Closed?' " & Environment.NewLine
                strSql &= "From syxrecpallet" & Environment.NewLine
                strSql &= "INNER JOIN syxrecpalletdata ON syxrecpalletdata.PalletID = syxrecpallet.PalletID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN syxdata ON syxrecpalletdata.PD_ID = syxdata.PD_ID " & Environment.NewLine
                strSql &= "WHERE syxrecpallet.PalletID = '" & strPalletID & "'" & Environment.NewLine
                If strItemNumber.Trim.Length > 0 Then strSql &= "AND itemnumber = '" & strItemNumber & "'" & Environment.NewLine
                strSql &= " GROUP BY syxrecpalletdata.PD_ID "
                Dim dt As DataTable = Me._objDataProc.GetDataTable(strSql)
                Dim dr As DataRow
                For Each dr In dt.Rows
                    dr.BeginEdit()
                    dr("To Be Rec Qty") = Convert.ToInt32(dr("OnHandQty")) - Convert.ToInt32(dr("Received Qty"))
                    dr.EndEdit()
                Next dr

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function GetPalletInfo(ByVal strPalletID As String) As DataRow
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim R1 As DataRow = Nothing

            Try
                strSql = "SELECT * FROM syxrecpallet " & Environment.NewLine
                strSql &= "WHERE PalletID = '" & strPalletID & "'" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 1 Then
                    Throw New Exception("Pallet# " & strPalletID & " existed in the system more than one. Please contact IT.")
                ElseIf dt.Rows.Count = 1 Then
                    R1 = dt.Rows(0)
                End If
                Return R1
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing : Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function IsPalletClosed(ByVal strPalletID As String) As Boolean
            Dim strSql As String = ""
            Dim i As Integer

            Try
                strSql = "SELECT Closed FROM syxrecpallet " & Environment.NewLine
                strSql &= "WHERE PalletID = '" & strPalletID & "'" & Environment.NewLine
                i = Me._objDataProc.GetIntValue(strSql)
                If i = 0 Then
                    Return False
                Else
                    Return True
                End If

            Catch ex As Exception
                Throw ex
            Finally

            End Try
        End Function

        '*******************************************************************************************************************
        Public Function ClosePallet(ByVal strPalletID As String, ByVal UserID As Integer, _
                                    ByVal iDiscrepancyFlag As Integer) As Integer
            Dim strSql As String = ""
            Dim i As Integer


            Try
                strSql = "UPDATE syxrecpallet" & Environment.NewLine
                strSql &= "SET "
                strSql &= " Closed = 1" & Environment.NewLine
                strSql &= ", ClosedUsrID = " & UserID & Environment.NewLine
                strSql &= ", ClosedDate = now(), DiscrepancyFlag = " & iDiscrepancyFlag & Environment.NewLine
                strSql &= "WHERE PalletID = '" & strPalletID & "'" & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                Return i
            Catch ex As Exception
                Throw ex
            Finally

            End Try
        End Function

        '*******************************************************************************************************************
        Public Function ReOpenPallet(ByVal strPalletID As String, ByVal UserID As Integer) As Integer
            Dim strSql As String = ""
            Dim i As Integer


            Try
                strSql = "UPDATE syxrecpallet" & Environment.NewLine
                strSql &= "SET "
                strSql &= " Closed = 0" & Environment.NewLine
                strSql &= ", ClosedUsrID = " & UserID & Environment.NewLine
                strSql &= ", ClosedDate = now() " & Environment.NewLine
                strSql &= "WHERE PalletID = '" & strPalletID & "'" & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                Return i
            Catch ex As Exception
                Throw ex
            Finally

            End Try
        End Function
        '****************************************************************************************************
        Public Function InsertLascPrice(ByVal Manuf_ID As Integer, _
                                        ByVal Prod_ID As Integer) As Integer

            Dim strSql As String = String.Empty

            Try
                strSql = "Insert into lascprice (" & Environment.NewLine
                strSql &= "ASCPrice_Code, ASCPrice_APC, ASCPrice_Desc, ASCPrice_Price" & Environment.NewLine
                strSql &= ",ASCPrice_Special, Manuf_ID, Prod_ID" & Environment.NewLine
                strSql &= ") values (" & Environment.NewLine
                strSql &= "0, 'All', 'No ASC Value', 0.00,0" & Environment.NewLine
                strSql &= "," & Manuf_ID & Environment.NewLine
                strSql &= "," & Prod_ID & Environment.NewLine
                strSql &= ")" & Environment.NewLine
                Return Me._objDataProc.idTransaction(strSql, "lascprice")

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************************
        Public Function InsertLprodgrp(ByVal ProdGrp_SDesc As String, ByVal ProdGrp_LDesc As String, _
                                        ByVal Prod_ID As Integer) As Integer
            Dim strSql As String = String.Empty

            Try
                strSql = "Insert into lprodgrp (" & Environment.NewLine
                strSql &= "ProdGrp_SDesc, ProdGrp_LDesc, Prod_ID " & Environment.NewLine
                strSql &= ") values (" & Environment.NewLine
                strSql &= "'" & ProdGrp_SDesc & "'," & Environment.NewLine
                strSql &= "'" & ProdGrp_LDesc & "'," & Environment.NewLine
                strSql &= Prod_ID & Environment.NewLine
                strSql &= ")" & Environment.NewLine
                Return Me._objDataProc.idTransaction(strSql, "lprodgrp")

            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '****************************************************************************************************
        Public Function InsertModel(ByVal Model_Desc As String, ByVal Model_Tier As Integer, ByVal Model_Flat As Integer, _
                                    ByVal ProGrp_ID As Integer, ByVal ASCPrice_ID As Integer, _
                                    ByVal RptGrp_ID As Integer, ByVal Manuf_ID As Integer, ByVal Prod_ID As Integer) As Integer
            Dim strSql As String = String.Empty

            Try
                strSql = "INSERT INTO tmodel ( " & Environment.NewLine
                strSql &= "Model_Desc,Model_Tier,Model_Flat,ProdGrp_ID,ASCPrice_ID,RptGrp_ID,Manuf_ID,Prod_ID" & Environment.NewLine
                strSql &= ") VALUES (" & Environment.NewLine
                strSql &= "'" & Model_Desc & "'," & Environment.NewLine
                strSql &= Model_Tier & "," & Environment.NewLine
                strSql &= Model_Flat & "," & Environment.NewLine
                strSql &= ProGrp_ID & "," & Environment.NewLine
                strSql &= ASCPrice_ID & "," & Environment.NewLine
                strSql &= RptGrp_ID & "," & Environment.NewLine
                strSql &= Manuf_ID & "," & Environment.NewLine
                strSql &= Prod_ID & Environment.NewLine
                strSql &= ")"
                Return Me._objDataProc.idTransaction(strSql, "tmodel")
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************************
        Public Function CloseAndShipBox(ByVal iPalletID As Integer, ByVal iShiftID As Integer, _
                                        ByVal iBoxQty As Integer, ByVal strStatus As String, _
                                        ByRef objShip As Production.Shipping, _
                                        ByVal strNextWorkstation As String) As Integer
            Dim strSql, strWorkdate As String
            Dim dt, dtProdID As DataTable
            Dim objBulkship As BulkShipping
            Dim iOverpack_ID, iShip_ID, i, iProdID As Integer
            Dim R1 As DataRow

            Try
                strSql = "" : strWorkdate = "" : iOverpack_ID = 0 : iShip_ID = 0
                '***************************************************
                'Define work date
                '***************************************************
                If iShiftID = 0 Then Throw New Exception("System can't define shift ID.")
                strWorkdate = Generic.GetWorkDate(iShiftID)
                If strWorkdate.Trim.Length = 0 Then Throw New Exception("System can't define work date.")
                '***************************************************
                objBulkship = New BulkShipping()
                objBulkship.iPallet_ID = iPalletID

                objBulkship.iShipType = 0

                dtProdID = objBulkship.GetProdIDInPallet(iPalletID)
                If dtProdID.Rows.Count = 1 Then iProdID = CInt(dtProdID.Rows(0)("Prod_ID")) Else iProdID = 0
                '****************************************************************************
                ''Step 2:: Create Overpack
                '****************************************************************************
                iOverpack_ID = objBulkship.CreateOverPack(strWorkdate)
                '****************************************************************************
                ''Step 3:: Create Masterpack
                '****************************************************************************
                iShip_ID = objBulkship.CreateMasterPack(iOverpack_ID, iPalletID, iProdID, )
                '****************************************************************************
                strSql = "UPDATE tdevice, tpallett, tcellopt, syxdata " & Environment.NewLine
                strSql &= "SET "
                strSql &= " Ship_ID = " & iShip_ID & Environment.NewLine
                strSql &= ", Shift_ID_Ship = " & iShiftID & Environment.NewLine
                strSql &= ", Device_SendClaim = 0 " & Environment.NewLine
                strSql &= ", Device_DateShip = now() " & Environment.NewLine
                strSql &= ", Device_ShipWorkDate = '" & strWorkdate & "' " & Environment.NewLine
                strSql &= ", Pallett_ShipDate = '" & strWorkdate & "' " & Environment.NewLine
                strSql &= ", Pallett_ReadyToShipFlg = 1, Pallett_BulkShipped = 1 " & Environment.NewLine
                strSql &= ", Pallett_QTY = " & iBoxQty & " " & Environment.NewLine
                strSql &= ", Cellopt_WIPOwnerOld = Cellopt_WIPOwner " & Environment.NewLine
                strSql &= ", Cellopt_WIPOwner = 7 " & Environment.NewLine
                strSql &= ", Cellopt_WIPEntryDt  = now() " & Environment.NewLine
                strSql &= ", WorkStation = '" & strNextWorkstation & "', WorkStationEntryDt= now(), WIL_ID = 0 " & Environment.NewLine
                strSql &= ", Status = '" & strStatus & "'" & Environment.NewLine
                strSql &= "WHERE tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                strSql &= "AND tdevice.Device_ID = tcellopt.Device_ID " & Environment.NewLine
                strSql &= "AND tdevice.Device_ID = syxdata.Device_ID " & Environment.NewLine
                strSql &= "AND tdevice.Pallett_ID = " & iPalletID & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                If i = 0 Then Throw New Exception("System has failed to update shipping information.")

                strSql = "SELECT distinct WO_ID from tdevice WHERE Pallett_ID = " & iPalletID
                dt = Me._objDataProc.GetDataTable(strSql)

                For Each R1 In dt.Rows
                    If objShip.GetReadyToShipCountByWO(R1("WO_ID")) = 0 Then
                        strSql = "UPDATE tworkorder SET WO_Shipped = 1, WO_DateShip = '" & strWorkdate & "' WHERE WO_ID = " & R1("WO_ID") & Environment.NewLine
                        i = Me._objDataProc.ExecuteNonQuery(strSql)

                        If i = 0 Then Throw New Exception("System has failed to update shipping information in work order.")
                    End If
                Next R1

                '******************************
                Return i
            Catch ex As Exception
                Throw ex
            Finally
                objBulkship = Nothing : Generic.DisposeDT(dt)
            End Try
        End Function

        '****************************************************************************************************
        Public Function CreateSyxReceiveSn(ByVal iUserID As Integer, ByRef strSN As String) As Integer
            Dim strSql, strNow, strNextNo As String
            Dim strReturnData As String()
            Dim iNextNo As Integer = 0
            Dim iSRC_ID As Integer = 0

            Try
                strSql = "" : strSN = "" : strNow = ""
                strNow = Generic.GetMySqlDateTime("%y%m%d")
                strSN = "PSS" & strNow & "N"
                strSql = "SELECT IF(max(MID(Syx_SN,  11, 3)) is null, 0, max(MID(Syx_SN,  11, 3)) ) as NextNo FROM syxreceivesn WHERE Syx_SN like '" & strSN & "%' ORDER BY SRC_ID DESC ;"
                iNextNo = Me._objDataProc.GetIntValue(strSql) + 1
                strSN = strSN & iNextNo.ToString.PadLeft(3, "0")

                strSql = "INSERT INTO syxreceivesn ( SYX_SN, createbyUsrID, CreateDT " & Environment.NewLine
                strSql &= ") Values ( " & Environment.NewLine
                strSql &= " '" & strSN & "', " & iUserID & ", now()" & Environment.NewLine
                strSql &= ") ;" & Environment.NewLine
                iSRC_ID = Me._objDataProc.idTransaction(strSql, "syxreceivesn")

                Return iSRC_ID
            Catch ex As Exception
                strSN = "" : Throw ex
            End Try
        End Function

        '****************************************************************************************************
        Public Function UpdatePSSSN(ByVal iDeviceID As Integer, ByVal iSRC_ID As String) As Integer
            Dim strSql As String = ""

            Try
                strSql = "UPDATE syxreceivesn SET Device_ID = " & iDeviceID & " WHERE SRC_ID = " & iSRC_ID & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)

                Return iSRC_ID
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '****************************************************************************************************
        Public Function ChangeModel(ByVal Device_ID As Integer, _
                                    ByVal Model_ID As Integer, _
                                    ByVal Model_Desc As String, _
                                    ByVal PD_ID As Integer, _
                                    ByVal Prod_ID As Integer, _
                                    ByVal Manuf_ID As Integer, _
                                    ByVal ReceivingPalletName As String) As Integer

            Dim i As Integer
            Dim strSql As String = ""

            Try
                strSql = "UPDATE tdevice set Model_ID= " & Model_ID & Environment.NewLine
                strSql &= "Where Device_ID=" & Device_ID & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                strSql = "UPDATE syxdata set Model_ID= " & Model_ID & Environment.NewLine
                strSql &= ",Model_Desc='" & Model_Desc & "'" & Environment.NewLine
                strSql &= ",ReceivingPalletName='" & ReceivingPalletName & "'" & Environment.NewLine
                strSql &= ",PD_ID=" & PD_ID & Environment.NewLine
                strSql &= ",NewModelProdID=" & Prod_ID & Environment.NewLine
                strSql &= ",Manuf_ID=" & Manuf_ID & Environment.NewLine
                strSql &= "Where Device_ID=" & Device_ID & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '****************************************************************************************************
        Public Function GetOpenPallets(ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Try
                strSql = "SELECT * FROM syxrecpallet where closed = 0 order by PalletID;" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow = True Then dt.LoadDataRow(New Object() {"0", "--SELECT PALLET--"}, False)
                Return dt

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '****************************************************************************************************
        Public Function GetAvailableItemQty(ByVal strPallet As String, Optional ByVal strModel As String = "") As Integer
            Dim strSql As String = ""

            Try
                strSql = "Select sum(onHandQty) as Qty" & Environment.NewLine
                strSql &= "From syxrecpalletdata" & Environment.NewLine
                strSql &= "Where PalletID='" & strPallet & "'" & Environment.NewLine
                If strModel <> "" Then strSql &= "And ItemNumber='" & strModel & "'" & Environment.NewLine

                Return Me._objDataProc.GetIntValue(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************************
        Public Function GetReceivedItemQty(ByVal strPallet As String, Optional ByVal strModel As String = "") As Integer
            Dim strSql As String = ""

            Try
                strSql = "Select count(Model_Desc) as Qty" & Environment.NewLine
                strSql &= "FROM syxdata" & Environment.NewLine
                strSql &= "Where ReceivingPalletName='" & strPallet & "'" & Environment.NewLine
                If strModel <> "" Then strSql &= "And Model_Desc='" & strModel & "'" & Environment.NewLine
                Return Me._objDataProc.GetIntValue(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************************
        Public Function GetUnderValueCost() As Double
            Dim strSql As String = ""

            Try
                strSql = "Select Cost FROM syxundervaluecost WHERE Active = 1" & Environment.NewLine
                Return Me._objDataProc.GetDoubleValue(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************************
        Public Function GetDeviceCost(ByVal Device_ID As Integer) As Double
            Dim strSql As String = ""

            Try
                strSql = "Select Cost FROM syxdata WHERE Device_ID=" & Device_ID & Environment.NewLine
                Return Me._objDataProc.GetDoubleValue(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************************
        Public Function UpdateUnderValueCost(ByVal Cost As Double, ByVal UserID As Integer) As Integer

            Dim strSql As String = ""
            Dim i As Integer

            Try
                strSql = "Update syxundervaluecost set Active=0 Where Active=1;" & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                strSql = "Insert Into syxundervaluecost (Cost,SetDate,SetByUserID,Active)" & Environment.NewLine
                strSql &= " values (" & Environment.NewLine
                strSql &= Cost & Environment.NewLine
                strSql &= ",Now()" & Environment.NewLine
                strSql &= "," & UserID & Environment.NewLine
                strSql &= ",1" & Environment.NewLine
                strSql &= ")" & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                Return i

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function GetModelListInRecPallet(ByVal booAddSelectRow As Boolean, _
                                     ByVal strRecPalletName As String) As DataTable
            Dim strSql, strModelDesc As String
            Dim dt, dtSimilarModel As DataTable
            Dim R1 As DataRow
            Dim iModelID, iManufID, iProdID As Integer

            Try
                strSql = "" : strModelDesc = ""
                strSql = "SELECT syxrecpalletdata.PD_ID, syxrecpalletdata.ItemNumber as Model_Desc " & Environment.NewLine
                strSql &= ", if(tmodel.Model_ID is null, 0, tmodel.Model_ID) as Model_ID" & Environment.NewLine
                strSql &= ", if(tmodel.Prod_ID is null, 0, tmodel.Prod_ID) as Prod_ID" & Environment.NewLine
                strSql &= ", if(tmodel.Manuf_ID is null, 0, tmodel.Manuf_ID) as Manuf_ID " & Environment.NewLine
                strSql &= "FROM syxrecpalletdata " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tmodel ON syxrecpalletdata.ItemNumber = tmodel.Model_Desc " & Environment.NewLine
                strSql &= "WHERE syxrecpalletdata.PalletID = '" & strRecPalletName & "'" & Environment.NewLine
                strSql &= "ORDER BY Model_Desc " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                For Each R1 In dt.Rows
                    If Convert.ToInt32(R1("Model_ID")) = 0 Then
                        strModelDesc = R1("Model_Desc").ToString.Trim.Split(" ")(0)

                        strSql = "SELECT Model_Desc, Model_ID, Prod_ID, Manuf_ID " & Environment.NewLine
                        strSql &= "FROM tmodel WHERE Model_Desc Like '" & strModelDesc & " %'" & Environment.NewLine
                        strSql &= "UNION " & Environment.NewLine
                        strSql &= "SELECT Model_Desc, Model_ID, Prod_ID, Manuf_ID " & Environment.NewLine
                        strSql &= "FROM tmodel WHERE Model_Desc = '" & strModelDesc & "'" & Environment.NewLine
                        strSql &= "ORDER BY Model_Desc " & Environment.NewLine
                        dtSimilarModel = Me._objDataProc.GetDataTable(strSql)
                        If dtSimilarModel.Rows.Count > 0 Then
                            R1.BeginEdit()
                            R1("Prod_ID") = dtSimilarModel.Rows(0)("Prod_ID") : R1("Manuf_ID") = dtSimilarModel.Rows(0)("Manuf_ID")
                            R1.EndEdit()
                        End If
                    End If
                Next R1

                dt.AcceptChanges()

                If booAddSelectRow = True Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '****************************************************************************************************
        Public Function IsPalletExisted(ByVal strPalletID As String) As Boolean
            Try
                Dim strsql As String = ""
                strsql = "SELECT Count(*) as cnt FROM syxrecpallet WHERE Palletid = '" & strPalletID & "'"
                If Me._objDataProc.GetIntValue(strsql) > 0 Then Return True Else Return False
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************************
        Public Function UpdateOnhandqty(ByVal iDP_ID As Integer, ByVal iOriginalOnHandQty As Integer, _
                                        ByVal iItemQty As Integer, ByVal dbItemValue As Double, _
                                        ByVal iInFile As Integer, ByVal iUserID As Integer) As Integer
            Try
                Dim strsql As String = ""
                Dim strDiscrepancyMsg As String = ""
                Dim iDelta As Integer = iItemQty - iOriginalOnHandQty

                If iInFile > 0 Then
                    If iDelta < 0 Then
                        strDiscrepancyMsg = "Missing " & (iDelta * (-1)).ToString & " unit(s)."
                    ElseIf iDelta > 0 Then
                        strDiscrepancyMsg = "Extra " & (iDelta).ToString & " unit(s)."
                    End If
                Else
                    If iItemQty > 0 Then strDiscrepancyMsg = "Extra " & iItemQty & " unit(s)."
                End If

                strsql = "UPDATE syxrecpalletdata SET onhandqty = " & iItemQty & ", discrepancy = '" & strDiscrepancyMsg & "'" & Environment.NewLine
                strsql &= ", LastUpdateValue = " & (iItemQty * dbItemValue).ToString & Environment.NewLine
                If strDiscrepancyMsg.Trim.Length > 0 Then strsql &= ", DiscrepancySetDate = now() " & Environment.NewLine Else strsql &= ", DiscrepancySetDate = null " & Environment.NewLine
                strsql &= ", DiscrepancySetUserID = " & iUserID & Environment.NewLine
                strsql &= "WHERE PD_ID = " & iDP_ID & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strsql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************************
        Public Function AddPalletLineItem(ByVal strPalletID As String, ByVal strItemNumber As String, ByVal strItemDesc As String, _
                                          ByVal iOnhandQty As Integer, ByVal dbItemVAl As Double, _
                                          ByVal iUserID As Integer) As Integer
            Try
                Dim strsql As String = ""
                Dim strDiscrepancyMsg As String = ""

                strDiscrepancyMsg = "Extra " & iOnhandQty.ToString & " unit(s)."

                strsql = "INSERT INTO syxrecpalletdata ( " & Environment.NewLine
                strsql &= " ItemNumber, ItemDescription, OnHandQty, LastUpdateValue " & Environment.NewLine
                strsql &= ", UPCCode, PalletID, syxrecpalletdata.InFile, Discrepancy, DiscrepancySetDate" & Environment.NewLine
                strsql &= ", OriginalOnHandQty, OriginalLastUpdateValue, DiscrepancySetUserID , unitcost " & Environment.NewLine
                strsql &= ") VALUES ( " & Environment.NewLine
                strsql &= "'" & strItemNumber & "', '" & strItemDesc & "'" & Environment.NewLine
                strsql &= ", " & iOnhandQty & ", " & (iOnhandQty * dbItemVAl).ToString & Environment.NewLine
                strsql &= ", '', '" & strPalletID & "', 0, '" & strDiscrepancyMsg & "', now() " & Environment.NewLine
                strsql &= ", 0, 0, " & iUserID & ", " & dbItemVAl & Environment.NewLine
                strsql &= ") ;" & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strsql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************************
        Public Function IsDiscrepancyPallet(ByVal strPalletID As String) As Boolean
            Try
                Dim strsql As String = ""

                strsql = "SELECT Count(*) as cnt FROM  syxrecpalletdata " & Environment.NewLine
                strsql &= "WHERE DiscrepancySetDate is not null " & Environment.NewLine
                If Me._objDataProc.GetIntValue(strsql) > 0 Then Return True Else Return False
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************************
        Public Function GetItemHistory(ByVal strItemNumber As String) As DataTable
            Try
                Dim strsql As String = ""

                strsql = "SELECT DISTINCT ItemNumber, ItemDescription, unitcost " & Environment.NewLine
                strsql &= "FROM syxrecpalletdata " & Environment.NewLine
                strsql &= "WHERE itemnumber = '" & strItemNumber & "' AND DiscrepancySetDate is null " & Environment.NewLine
                strsql &= "ORDER BY unitcost DESC LIMIT 1"
                Return Me._objDataProc.GetDataTable(strsql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************************
        Public Function GetPretestResult(ByVal iDeviceID As Integer) As Integer
            Dim dt As DataTable
            Dim strsql As String = ""
            Dim iPretestResult As Integer = 0

            Try
                strsql = "SELECT DISTINCT QCResult_ID FROM tpretest_data WHERE Device_ID = " & iDeviceID & " ORDER BY tpretest_id DESC " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strsql)

                If dt.Rows.Count > 0 Then iPretestResult = dt.Rows(0)("QCResult_ID")

                Return iPretestResult
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************************
        Public Function IsDeviceHasCosBBillcode(ByVal iDeviceID As Integer) As Boolean
            Dim strsql As String = ""

            Try
                strsql = "SELECT Count(*) FROM tdevicebill  " & Environment.NewLine
                strsql &= "INNER JOIN lbillcodes ON tdevicebill.Billcode_ID = lbillcodes.Billcode_ID " & Environment.NewLine
                strsql &= "WHERE tdevicebill.Device_ID = " & iDeviceID & " AND Billcode_Desc = 'Cosmetic - B'" & Environment.NewLine
                If Me._objDataProc.GetIntValue(strsql) <= 0 Then Return False Else Return True
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************************
        Public Function GetServiceBillcodeDescList(ByVal iDeviceID As Integer) As String
            Dim strsql As String = ""
            Dim dt As DataTable
            Dim strServBillcodeDescList As String = ""
            Dim R1 As DataRow

            Try
                strsql = "SELECT Billcode_Desc FROM tdevicebill  " & Environment.NewLine
                strsql &= "INNER JOIN lbillcodes ON tdevicebill.Billcode_ID = lbillcodes.Billcode_ID " & Environment.NewLine
                strsql &= "WHERE tdevicebill.Device_ID = " & iDeviceID & " AND Billtype_ID = 1 ORDER BY Billcode_Desc" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strsql)

                For Each R1 In dt.Rows
                    If strServBillcodeDescList.Trim.Length > 0 Then strServBillcodeDescList &= "; "
                    strServBillcodeDescList &= R1("Billcode_Desc")
                Next R1

                Return strServBillcodeDescList
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************************
        Public Function GetPrevRepData(ByVal strSN As String, ByVal iLocID As Integer) As DataTable
            Dim strsql As String = ""

            Try
                strsql = "SELECT tmodel.Model_desc, tmodel.Manuf_ID, Manuf_Desc, tmodel.Prod_ID, Prod_desc " & Environment.NewLine
                strsql &= ", IF(Device_Dateship is null, '', Device_Dateship) as Device_Dateship, syxdata.Manuf_SN  " & Environment.NewLine
                strsql &= "FROM tdevice INNER JOIN tmodel ON tdevice.model_ID = tmodel.model_ID  " & Environment.NewLine
                strsql &= "INNER JOIN lmanuf ON tmodel.Manuf_ID = lmanuf.Manuf_ID " & Environment.NewLine
                strsql &= "INNER JOIN lproduct ON tmodel.Prod_ID = lproduct.Prod_ID " & Environment.NewLine
                strsql &= "INNER JOIN syxdata ON tdevice.Device_ID = syxdata.Device_ID  " & Environment.NewLine
                strsql &= "WHERE tdevice.Loc_ID = " & iLocID & " AND tdevice.Device_SN = '" & strSN & "' " & Environment.NewLine
                strsql &= "ORDER BY tdevice.Device_ID DESC " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strsql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************************

#Region "Label & Manifest Report"


        '******************************************************************
        Public Function CreateShippingManifest(ByVal strPalletName As String, _
                                               ByVal iPalletID As Integer, _
                                               Optional ByVal iPrintCopyNo As Integer = 1) As Integer
            Const iTotalHeader As Integer = 1
            'Excel Related variables
            Dim objDataProc As DBQuery.DataProc
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet
            Dim xlBI As Excel.XlBordersIndex() = {Excel.XlBordersIndex.xlEdgeLeft, Excel.XlBordersIndex.xlEdgeTop, Excel.XlBordersIndex.xlEdgeBottom, _
                Excel.XlBordersIndex.xlEdgeRight, Excel.XlBordersIndex.xlInsideVertical, Excel.XlBordersIndex.xlInsideHorizontal}

            Dim strFilePath, strSql As String
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim objArr(,) As Object
            Dim i, j As Integer

            Try
                strFilePath = Me._PalletManifestDir & strPalletName & ".xls"

                strSql = "SELECT 0 as 'Line#' " & Environment.NewLine
                strSql &= ", Pallett_Name as 'Pallet Name' " & Environment.NewLine
                strSql &= ", lmanuf.Manuf_Desc as 'Mfg' " & Environment.NewLine
                strSql &= ", tmodel.Model_Desc as 'Model' " & Environment.NewLine
                strSql &= ", tdevice.Device_SN as 'Serial' " & Environment.NewLine
                strSql &= ", Pallettype_LDesc as 'Result'" & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN lmanuf ON lmanuf .Manuf_ID = tmodel.Manuf_ID " & Environment.NewLine
                strSql &= "INNER JOIN lpallettype ON tpallett.PalletType_ID = lpallettype.PalletType_ID " & Environment.NewLine
                strSql &= "WHERE tdevice.Pallett_ID = " & iPalletID.ToString & " " & Environment.NewLine
                strSql &= "ORDER BY lmanuf.Manuf_Desc,tmodel.Model_Desc,tdevice.Device_SN;" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                'Create Line #
                i = 0
                For Each R1 In dt.Rows
                    i += 1
                    R1.BeginEdit()
                    R1("Line#") = i
                    R1.EndEdit()
                    R1.AcceptChanges()
                Next R1
                dt.AcceptChanges()

                If dt.Rows.Count > 0 Then
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

                    '*******************************
                    'Set column with
                    '*******************************
                    ExcelReports.SetCellWidths(objSheet, dt)

                    ''*******************************
                    '' Freeze column headers area
                    ''*******************************
                    'objExcel.ActiveWindow.FreezePanes = False
                    'objExcel.Range("A1:" & Generic.CalExcelColLetter(dt.Columns.Count) & (2).ToString).Select()
                    'objExcel.ActiveWindow.FreezePanes = True

                    '*******************************
                    ' Header & Footer    
                    '*******************************
                    With objSheet.PageSetup
                        .Orientation = Excel.XlPageOrientation.xlLandscape
                        .LeftHeader = "&""Arial,Bold""&14Pallet Manifest" & Chr(10) & "Pallet ID: " & strPalletName & Chr(10) & "Destination: " & strFilePath & Chr(10) & "Total: " & dt.Rows.Count.ToString
                        .LeftFooter = "** PSS Confidential **"
                        .CenterFooter = "&P of &N"
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
                    If File.Exists(strFilePath) Then File.Delete(strFilePath)
                    objBook.SaveAs(strFilePath)
                    '***********************************
                    'print Report
                    '***********************************
                    objExcel.ActiveWindow.SelectedSheets.PrintOut(Copies:=iPrintCopyNo, Collate:=True)
                    '***********************************

                End If
                Return dt.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
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
                    NAR(objBook)
                End If
                If Not IsNothing(objExcel) Then
                    objExcel.Quit()
                    NAR(objExcel)
                End If
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function

        '********************************************************************************
        Public Function Label_ReceiveBoxLabel(ByVal DeviceID As Integer, _
                                              ByVal iCopies As Integer) As Integer
            Dim strsql As String = ""
            Dim objRpt As ReportDocument
            Dim dt As DataTable

            Try

                strsql = "Select IF(tmodel.Model_Desc is null, syxdata.Model_Desc, tmodel.Model_Desc) AS Model" & Environment.NewLine
                strsql &= ", Manuf_SN AS Serial" & Environment.NewLine
                strsql &= ", syxdata.Device_ID AS DeviceID" & Environment.NewLine
                strsql &= ", Device_SN AS PSSSN" & Environment.NewLine
                strsql &= ", syxdata.ReceivingPalletName AS RecPalletName" & Environment.NewLine
                strsql &= "From tdevice INNER JOIN syxdata ON tdevice.Device_ID = syxdata.Device_ID " & Environment.NewLine
                strsql &= "LEFT OUTER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strsql &= "WHERE tdevice.Device_ID = " & DeviceID
                objRpt = New ReportDocument()

                With objRpt
                    .Load(Me._strRptPath & Me._strLabelReceiveBox)
                    dt = Me._objDataProc.GetDataTable(strsql)
                    If Not IsNothing(dt) Then .SetDataSource(dt)
                    .PrintToPrinter(iCopies, True, 0, 0)
                End With
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function
        '******************************************************************
        Public Shared Function GetSyxDeviceInfoByPSSSN(ByVal PSS_SN As String, _
                                               Optional ByVal Manuf_ID As Integer = 0) As DataTable

            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                strSql = "SELECT S.*,T.Device_DateShip "
                strSql &= "From syxdata S" & Environment.NewLine
                strSql &= "inner join tdevice T on T.device_ID=S.device_id" & Environment.NewLine
                strSql &= "WHERE S.PSS_SerialNUmber='" & PSS_SN & "'" & Environment.NewLine
                strSql &= "AND (Device_DateShip is null or Device_DateShip = '' or Device_DateShip = '0000-00-00 00:00:00')" & Environment.NewLine
                If Manuf_ID > 0 Then strSql &= "AND S.Manuf_ID = " & Manuf_ID & Environment.NewLine

                Return objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '**************************************************************
        Public Shared Function GetSyxDeviceInfoByMfgSN(ByVal Manuf_SN As String, _
                                                Optional ByVal Manuf_ID As Integer = 0) As DataTable

            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                strSql = "SELECT S.*,T.Device_DateShip "
                strSql &= "From syxdata S" & Environment.NewLine
                strSql &= "inner join tdevice T on T.device_ID=S.device_id" & Environment.NewLine
                strSql &= "WHERE S.Manuf_SN='" & Manuf_SN & "'" & Environment.NewLine
                strSql &= "AND (Device_DateShip is null or Device_DateShip = '' or Device_DateShip = '0000-00-00 00:00:00')" & Environment.NewLine
                If Manuf_ID > 0 Then strSql &= "AND S.Manuf_ID = " & Manuf_ID & Environment.NewLine

                Return objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '**************************************************************
        Public Shared Function GetSyxDeviceInfoInWIP(ByVal strSN As String, _
                                                  ByVal iCustID As Integer, _
                                                  Optional ByVal iLocID As Integer = 0, _
                                                  Optional ByVal booIncludeCelloptData As Boolean = False) As DataTable
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                strSql = "SELECT A.* "

                If booIncludeCelloptData = True Then
                    strSql &= ", if(WorkStation is null, '', WorkStation) as WorkStation " & Environment.NewLine
                    strSql &= ", if(D.CellOpt_SoftVerIN is null, '', D.CellOpt_SoftVerIN) as CellOpt_SoftVerIN " & Environment.NewLine
                    strSql &= ", if(D.CellOpt_SoftVerOUT is null, '', D.CellOpt_SoftVerOUT) as CellOpt_SoftVerOUT " & Environment.NewLine
                    strSql &= ", if(D.CellOpt_MSN is null, '', D.CellOpt_MSN) as CellOpt_MSN " & Environment.NewLine
                    strSql &= ", Cellopt_WIPOwner " & Environment.NewLine
                    strSql &= ", CellOpt_RefurbCompleteDt " & Environment.NewLine
                    strSql &= ", if(D.CellOpt_VerificationID is null, '', D.CellOpt_VerificationID) as CellOpt_VerificationID " & Environment.NewLine
                End If

                strSql &= "FROM production.tdevice A" & Environment.NewLine
                strSql &= "INNER JOIN production.tlocation B ON A.Loc_ID = B.Loc_ID " & Environment.NewLine

                If booIncludeCelloptData = True Then
                    strSql &= "INNER JOIN production.tcellopt D ON A.Device_ID = D.Device_ID " & Environment.NewLine
                End If
                strSql &= String.Format("WHERE A.Device_SN = '{0}' AND Cust_ID = {1}", strSN, iCustID) & Environment.NewLine
                strSql &= "AND (Device_DateShip is null or Device_DateShip = '' or Device_DateShip = '0000-00-00 00:00:00')" & Environment.NewLine

                If iLocID > 0 Then strSql &= String.Format("AND A.Loc_ID = {0}", iLocID) & Environment.NewLine

                Return objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '****************************************************************************************************
        Public Function GetSyxDeviceStatus(ByVal iDeviceID As Integer) As String
            Dim strSql As String = ""
            Try

                strSql = "Select Status" & Environment.NewLine
                strSql &= "From syxdata " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                Return Me._objDataProc.GetSingletonString(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '****************************************************************************************************

#End Region

        '****************************************************************************************************

    End Class
End Namespace