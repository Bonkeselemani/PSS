Option Explicit On 
Imports System.ComponentModel

Namespace Buisness
    Public Class NI
        Public Const CUSTOMERID As Integer = 2531
        Public Const LOCID As Integer = 3332
        Public Const GROUPID As Integer = 104
        Public Const MANUFID As Integer = 199
        Public Const PRODID As Integer = 69
        Public Const PalletID_Scrap As Integer = 203542
        Public Const PalletID_Refurb As Integer = 203541
        Public Const PalletID_KeyboardSP As Integer = 264100
        Public Const RefurbDevConditionID As Integer = 3857
        Public Const SCRAP_FAILCODE As Integer = 3861
        Public Const SCRAP_BILLCODE As Integer = 2325
        Public Const RECLAIM_BILLCODE As Integer = 2823
        Public Const TESTTRIAGESORT_BILLCODE As Integer = 2849
        Public Const SOLaborChargePerUnit As Decimal = 3.5
        Public Const SOSparePartLaborChargePerLine As Decimal = 5.0 'For SendSparePart, $5.0 labor charge for each line of order
        Public Const ReceiveReconcileRMABillCodeID As Integer = 3019
        Public Const CallTagMailingID As Integer = 3018 'Billcode_ID
        Public Const PackShipBillCodeID As Integer = 3021 'Billcode_ID

        Public Shared _strRequiredBillcodes() = New String() {"Depot Repairs", _
        "Exception Repairs/Customer Abuse", "Exception Repairs Quote Rejected", _
        "PSS Warranty NFF", "Repaired PSS Warranty", _
        "BER", _
        "Reclamation", "Test, Triage and Sort", "2323"}

        'Public Enum WIP_Status
        '    <Description("RMA Received")> RMAReceived = 1
        '    <Description("Return Kit Shipped")> EmptyBoxShipped = 2
        'End Enum


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

        Public Function EnumDescription(ByVal EnumConstant As [Enum]) As String
            Dim fi As Reflection.FieldInfo = EnumConstant.GetType().GetField(EnumConstant.ToString())
            Dim aattr() As DescriptionAttribute = DirectCast(fi.GetCustomAttributes(GetType(DescriptionAttribute), False), DescriptionAttribute())
            If aattr.Length > 0 Then
                Return aattr(0).Description
            Else
                Return EnumConstant.ToString()
            End If
        End Function

#End Region

#Region "Shared Function"

        '*************************************************************************************
        Public Shared Function GetRepairType(ByVal iWOID As Integer) As String()
            Dim strSql, strRepairType As String
            Dim iDcodeID As Integer = 0
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT RepairType FROM extendedwarranty WHERE WO_ID = " & iWOID
                strRepairType = objDataProc.GetSingletonString(strSql)
                If strRepairType.Trim.Length = 0 Then Throw New Exception("Repair type is missing.")

                If strRepairType.Trim.ToLower = "sendrefurb" OrElse strRepairType.Trim.ToLower = "sendnew" Then
                    strSql = "SELECT * FROM lcodesdetail WHERE MCode_ID in ( 54 ) and DCode_L2Desc = '" & strRepairType & "'" & Environment.NewLine
                    iDcodeID = objDataProc.GetIntValue(strSql)
                    If iDcodeID = 0 Then Throw New Exception("Can't define repair type (" & strRepairType & ") ID.")
                End If

                Return New String() {iDcodeID.ToString, strRepairType}
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************************
        Public Shared Function IsBulkWorkOrder(ByVal iWOID As Integer) As Boolean
            Dim strSql As String
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT NI_DataSwitch FROM extendedwarranty WHERE WO_ID = " & iWOID
                If objDataProc.GetIntValue(strSql) = 2 Then Return True Else Return False
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************************
        Public Function CompleteScrapDevice(ByVal device_id As Integer)
            Dim objDataProc As DBQuery.DataProc
            Dim _sql As String
            objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            _sql = "UPDATE TDEVICE SET PALLETT_ID = " & PalletID_Scrap & " WHERE DEVICE_ID = " & device_id & ";"
            objDataProc.ExecuteNonQuery(_sql)
        End Function


#End Region

#Region "SQL Data Functions"



        '******************************************************************
        Public Function GetClaimFullInfo(ByVal iEW_ID As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT a.EW_ID,a.Cust_ID,a.ClaimNo,a.Prod_Code,b.NI_Prod_Desc Prod_desc,a.RepairType,if(a.Warranty=1,'Yes','No') Warranty,a.DefectType1,a.DefectType2,a.ErrDesc_ItemSKU," & Environment.NewLine
                strSql &= " a.Email,a.ServiceLevel,a.SerialNo,a.Language,a.Account,a.SenderReference,a.PurchaseDate,a.ShipTo_Name,a.Address1,a.Address2," & Environment.NewLine
                strSql &= " a.City,a.State_ID,a.State_ShortName State_Short,a.ZipCode,a.Cntry_ID,a.Cntry_Name,a.Tel,a.SC_ID,if(a.ReturnBoxYesNo=1,'Yes','No') ReturnBoxYesNo," & Environment.NewLine
                strSql &= " a.PSSI2Cust_TrackNo,a.Cust2PSSI_TrackNo,if(NI_DataSwitch=1,'End User',if (NI_DataSwitch=2,'Bulk','Unknown')) as 'OrderType'" & Environment.NewLine
                strSql &= " from extendedwarranty a" & Environment.NewLine
                strSql &= " left join ni_products b on a.Prod_Code=b.NI_Prod_ID" & Environment.NewLine
                strSql &= " where a.EW_ID=" & iEW_ID & "" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        Public Function GetClaimNoIDName() As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try

                strSql = "SELECT Concat(EW_ID, '-',ClaimNo) AS IDNo,ShipTo_Name,ServiceLevel,Cntry_ID,Cntry_Name" & Environment.NewLine
                strSql &= " FROM extendedwarranty" & Environment.NewLine
                strSql &= " WHERE  WO_ID is Null and NI_DataSwitch=1 and cust_ID=" & CUSTOMERID & Environment.NewLine
                strSql &= " ORDER BY LoadedDateTime desc, ShipTo_Name"

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function
        '******************************************************************
        Public Function GetShipCarriers() As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try

                strSql = "SELECT SC_ID,SC_Desc" & Environment.NewLine
                strSql &= " FROM lshipcarrier " & Environment.NewLine
                strSql &= " WHERE  SC_Active=1" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function
        '******************************************************************

        Public Function InsertWorkOrderData(ByVal WOCustWOStr As String, ByVal iWO_Quantity As Integer) As Integer

            Dim strSql As String = ""

            Try
                WOCustWOStr = WOCustWOStr.Replace("'", "''")


                strSql = "INSERT INTO tWorkOrder " & Environment.NewLine
                strSql &= " (WO_CustWO,WO_Date,Loc_ID,Group_ID,WO_Closed,WO_CameWithFile,WO_Quantity)" & Environment.NewLine
                strSql &= " VALUES ( " & Environment.NewLine
                strSql &= "'" & WOCustWOStr & "'," & Environment.NewLine
                strSql &= "now()," & Environment.NewLine
                strSql &= LOCID & "," & Environment.NewLine
                strSql &= GROUPID & "," & Environment.NewLine
                strSql &= "0" & "," & Environment.NewLine
                strSql &= "1," & iWO_Quantity & ")" & Environment.NewLine

                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetWorkOrderID(ByVal WOCustWOStr As String) As Integer

            Dim strSql As String = ""
            Dim dt As DataTable
            Dim iWO_ID As Integer = 0

            Try
                WOCustWOStr = WOCustWOStr.Replace("'", "''")


                strSql = "SELECT WO_ID FROM tWorkOrder " & Environment.NewLine
                strSql &= "WHERE WO_CustWO = '" & WOCustWOStr & "'" & Environment.NewLine
                strSql &= " AND Loc_ID=" & LOCID & Environment.NewLine
                strSql &= " AND Group_ID=" & GROUPID & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    iWO_ID = dt.Rows(0).Item(0)
                Else
                    iWO_ID = 0
                End If

                Return iWO_ID

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function UpdateExdenedWarrantyData(ByVal iEW_ID As Integer, _
                                            ByVal iWO_ID As Integer, _
                                            ByVal outboundTrackStr As String, _
                                            ByVal returnTrackStr As String, _
                                            ByVal PSSIStatus_ID As Integer, _
                                            ByVal iSC_ID As Integer, _
                                            ByVal iUser_ID As Integer, _
                                            ByVal PPSI2CustomerShippingCost As Double, _
                                            ByVal iBillcode_ID As Integer, _
                                            ByVal vLabelCharge As Double) As Integer

            Dim strSql As String = ""

            Try

                strSql = "UPDATE ExtendedWarranty " & Environment.NewLine
                strSql &= " SET PSSI2Cust_TrackNo= '" & outboundTrackStr & "'," & Environment.NewLine
                strSql &= "Cust2PSSI_TrackNo='" & returnTrackStr & "'," & Environment.NewLine
                strSql &= "TrackCreatedDateTime=now()," & Environment.NewLine
                strSql &= "S_ID=" & PSSIStatus_ID & "," & Environment.NewLine
                strSql &= "SC_ID=" & iSC_ID & "," & Environment.NewLine
                strSql &= "WO_ID=" & iWO_ID & "," & Environment.NewLine
                strSql &= "PSSI2Cust_ShipmentCost =" & PPSI2CustomerShippingCost & "," & Environment.NewLine
                strSql &= "BillCode_ID=" & iBillcode_ID & "," & Environment.NewLine
                strSql &= "LabelCharge=" & vLabelCharge & "," & Environment.NewLine
                strSql &= "User_ID=" & iUser_ID & Environment.NewLine
                strSql &= " WHERE EW_ID=" & iEW_ID & Environment.NewLine

                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetClaimNoCount(ByVal ClaimNoStr As String) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim WO_Quantity As Integer = 0

            Try
                ClaimNoStr = ClaimNoStr.Replace("'", "''")

                strSql = "SELECT Count(*)" & Environment.NewLine
                strSql &= " FROM ExtendedWarranty" & Environment.NewLine
                strSql &= " WHERE  CUST_ID =" & CUSTOMERID & Environment.NewLine
                strSql &= " AND ClaimNo ='" & ClaimNoStr & "'" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    WO_Quantity = dt.Rows(0).Item(0)
                Else
                    WO_Quantity = 0
                End If

                Return WO_Quantity

            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetDataToPrintRepairLetter(ByVal Device_SN As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "select a.Device_ID,a.Device_SN,a.WO_ID,b.EW_ID,b.ClaimNo,b.ShipTo_Name,b.TMIServiceClient" & Environment.NewLine
                strSql &= " from tdevice a" & Environment.NewLine
                strSql &= " inner join extendedwarranty b on a.WO_ID=b.WO_ID" & Environment.NewLine
                strSql &= " where device_SN='" & Device_SN & "';" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function


        '******************************************************************
        Public Function GetNIProducts(Optional ByVal iProdCode As Integer = 0) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "select * " & Environment.NewLine
                strSql &= " from NI_Products" & Environment.NewLine
                If iProdCode > 0 Then strSql &= " where NI_Prod_ID=" & iProdCode & ";" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetNIModels(ByVal iManufID As Integer, ByVal iProdID As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable


            Try
                strSql = "SELECT A.Model_ID,A.Model_Desc as 'Model',if(B.Model_ID>0,'Yes','No') as 'Mapped'" & Environment.NewLine
                strSql &= " FROM tmodel A" & Environment.NewLine
                strSql &= " LEFT JOIN NI_Product_PSSI_Model_Map B ON A.Model_ID=B.Model_ID" & Environment.NewLine
                strSql &= " WHERE prod_ID=" & iProdID & " and Manuf_ID =" & iManufID & ";" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)


                Return dt

            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function


        '******************************************************************
        Public Function GetNIProductModelMapData(Optional ByVal iModel_ID As Integer = 0) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable


            Try
                strSql = "SELECT C.NI_Prod_Desc,B.Model_Desc as 'Model',D.User_fullname as 'UpdateUser',A.UpdateDateTime,A.UpdateUserID,A.NI_Prod_ID,A.Model_ID,A.NI_PMM_ID" & Environment.NewLine
                strSql &= " FROM NI_Product_PSSI_Model_Map A" & Environment.NewLine
                strSql &= " INNER JOIN tModel B ON A.Model_ID=B.Model_ID" & Environment.NewLine
                strSql &= " INNER JOIN NI_Products C ON A.NI_Prod_ID=C.NI_Prod_ID" & Environment.NewLine
                strSql &= " LEFT JOIN Security.tUsers D ON A.UpdateUserID=D.User_ID" & Environment.NewLine
                If iModel_ID > 0 Then strSql &= " WHERE A.Model_ID= " & iModel_ID

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt

            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function SaveNIProductModelMapData(ByVal iNI_Prod_ID As Integer, _
                                                  ByVal iModel_ID As Integer, _
                                                  ByVal iUserID As Integer, _
                                                  ByVal strDTime As String) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim i As Integer = 0


            Try
                strSql = "SELECT * " & Environment.NewLine
                strSql &= " FROM NI_Product_PSSI_Model_Map " & Environment.NewLine
                strSql &= " WHERE Model_ID= " & iModel_ID
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count = 0 Then
                    strSql = "INSERT INTO NI_Product_PSSI_Model_Map (NI_Prod_ID,Model_ID,UpdateUserID,UpdateDateTime)"
                    strSql &= " VALUES (" & iNI_Prod_ID & "," & iModel_ID & "," & iUserID
                    strSql &= ",'" & strDTime & "');"
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                End If

                Return i

            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function RemoveNIProductModelMap(ByVal iNI_PMM_ID As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "DELETE FROM NI_Product_PSSI_Model_Map " & Environment.NewLine
                strSql &= " WHERE NI_PMM_ID= " & iNI_PMM_ID

                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetKeyboardSpecialProject_PackShipBillCodeID(ByVal iMethod As Integer, _
                                                                     ByVal iModelID As Integer) As Integer
            Dim iBillCodeID As Integer = 0

            Try
                If iMethod = 1 Then
                    Select Case iModelID
                        Case 3965 'Keyboard S25
                            iBillCodeID = 3046
                        Case 3962 'Keyboard S49
                            iBillCodeID = 3047
                        Case 3966 'Keyboard S61
                            iBillCodeID = 3048
                    End Select
                ElseIf iMethod = 2 Then
                    Select Case iModelID
                        Case 3965 'Keyboard S25
                            iBillCodeID = 3049
                        Case 3962 'Keyboard S49
                            iBillCodeID = 3050
                        Case 3966 'Keyboard S61
                            iBillCodeID = 3051
                    End Select
                End If

                Return iBillCodeID
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '******************************************************************


#End Region

#Region "Tech/Billing"




        '***************************************************************************************************
        Public Function GetPreviousRepairData(ByVal strCustRMA As String) As DataTable
            Dim strSql, strTechNotes As String
            Dim dt, dtQC, dtTech, dtWO As DataTable
            Dim R1, drArr() As DataRow
            Dim i As Integer

            Try
                dtWO = Generic.GetCustWo(strCustRMA, Me.LOCID)
                strSql = "" : strTechNotes = ""

                strSql = "SELECT Device_ID, Device_SN as 'PSS S/N', Device_DateRec as 'Receipt Date' " & Environment.NewLine
                strSql &= ", Device_DateShip as 'Ship Date', '' as 'AQL Inspector', '' as 'OBA Inspector', '' as 'Tech Notes' " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "WHERE WO_ID = " & dtWO.Rows(0)("WO_ID") & " ORDER BY Device_ID DESC "
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    strSql = "SELECT tdevice.Device_ID, tqc.QC_ID, tqc.QCType_ID, QCType, QCResult, user_fullname" & Environment.NewLine
                    strSql &= " FROM tdevice " & Environment.NewLine
                    strSql &= "INNER JOIN tqc ON tdevice.Device_ID = tqc.Device_ID " & Environment.NewLine
                    strSql &= "INNER JOIN lqctype ON tqc.QCType_ID = lqctype.QCType_ID" & Environment.NewLine
                    strSql &= "INNER JOIN lqcresult ON tqc.QCResult_ID = lqcresult.QCResult_ID" & Environment.NewLine
                    strSql &= "INNER JOIN security.tusers ON tqc.Inspector_ID = security.tusers.User_ID" & Environment.NewLine
                    strSql &= "WHERE WO_ID = " & dtWO.Rows(0)("WO_ID") & Environment.NewLine
                    dtQC = Me._objDataProc.GetDataTable(strSql)

                    strSql = "SELECT tdevice.Device_ID, ttestdata.TD_ID, TD_TestDt, Notes, user_fullname " & Environment.NewLine
                    strSql &= "FROM tdevice " & Environment.NewLine
                    strSql &= "INNER JOIN ttestdata ON tdevice.Device_ID = ttestdata.Device_ID AND ttestdata.Test_ID = 7" & Environment.NewLine
                    strSql &= "INNER JOIN security.tusers ON ttestdata.TD_UsrID = security.tusers.User_ID" & Environment.NewLine
                    strSql &= "WHERE WO_ID = " & dtWO.Rows(0)("WO_ID") & Environment.NewLine
                    dtTech = Me._objDataProc.GetDataTable(strSql)

                    For Each R1 In dt.Rows
                        R1.BeginEdit() : strTechNotes = ""
                        'AQL
                        drArr = dtQC.Select("Device_ID = " & R1("Device_ID") & " AND QCType_ID = 4", "QC_ID DESC")
                        If drArr.Length > 0 Then R1("AQL Inspector") = drArr(0)("user_fullname")
                        drArr = Nothing
                        'OBA
                        drArr = dtQC.Select("Device_ID = " & R1("Device_ID") & " AND QCType_ID = 5", "QC_ID DESC")
                        If drArr.Length > 0 Then R1("OBA Inspector") = drArr(0)("user_fullname")
                        drArr = Nothing
                        'Tech Notes
                        drArr = dtTech.Select("Device_ID = " & R1("Device_ID"), "TD_ID ASC")
                        For i = 0 To drArr.Length - 1
                            If drArr(i)("Notes").ToString.Trim.Length > 0 Then strTechNotes &= "Completed By " & drArr(i)("user_fullname") & ". Note: " & drArr(i)("Notes")
                        Next
                        R1("Tech Notes") = strTechNotes

                        R1.EndEdit()
                    Next R1
                End If

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing : drArr = Nothing
                Generic.DisposeDT(dt) : Generic.DisposeDT(dtQC) : Generic.DisposeDT(dtTech) : Generic.DisposeDT(dtWO)
            End Try
        End Function

        '***************************************************************************************************
        Public Function GetPrevRepRMA(ByVal iWOID As Integer) As String
            Dim strSql As String = ""

            Try
                strSql = "SELECT IF(LastClaimNo IS NULL, '', LastClaimNo) as LastClaimNo FROM extendedwarranty WHERE WO_ID = " & iWOID
                Return Me._objDataProc.GetSingletonString(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************************
        Public Function GetWOID(ByVal strCustWO As String) As Integer
            Dim strSql As String = ""

            Try
                strSql = "SELECT WO_ID FROM tworkorder WHERE Loc_ID = " & Me.LOCID & " AND WO_CustWO = '" & strCustWO & "'"
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************************
        Public Function GetDeviceSNsInWO(ByVal iWOID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT tdevice.Device_ID, Device_SN as 'PSS S/N', Device_DateRec, Device_DateShip, Manuf_SN " & Environment.NewLine
                strSql &= ", Model_Desc as Model, tmodel.Model_ID, Manuf_Desc as Manufacture, tmodel.Manuf_ID, Prod_Desc as 'Product Type', tmodel.Prod_ID " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN lmanuf ON tmodel.Manuf_ID = lmanuf.Manuf_ID " & Environment.NewLine
                strSql &= "INNER JOIN lproduct ON tmodel.Prod_ID = lproduct.Prod_ID " & Environment.NewLine
                strSql &= "INNER JOIN tcellopt ON tdevice.Device_ID = tcellopt.Device_ID " & Environment.NewLine
                strSql &= "WHERE WO_ID = " & iWOID & " ORDER BY Device_ID DESC "
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************************
        Public Function GetPreviousRepairPartsService(ByVal iDeviceID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT tdevicebill.Device_ID, Billcode_Desc as 'Bill Code', Part_Number as 'Part #' " & Environment.NewLine
                strSql &= ", DBill_StdCost as 'Part Cost', DBill_InvoiceAmt as 'Part Charge' " & Environment.NewLine
                strSql &= ", IF(BillType_ID = 1, 'Service', IF(BillType_ID = 2, 'Part', 'Accessory' )) as 'Bill Type' " & Environment.NewLine
                strSql &= ", Date_Rec as 'Trans Date', U.User_FullName as 'Tech/Biller' " & Environment.NewLine
                strSql &= "FROM tdevicebill INNER JOIN lbillcodes ON tdevicebill.Billcode_ID = lbillcodes.Billcode_ID " & Environment.NewLine
                strSql &= "INNER JOIN security.tusers U On tdevicebill.User_ID = U.User_ID " & Environment.NewLine
                strSql &= "WHERE tdevicebill.Device_ID = " & iDeviceID
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************************
        Public Shared Function GetMainService(ByVal dtBilledBillCode As DataTable) As String
            Dim i As Integer
            Dim strMainService As String = ""

            Try
                For i = 0 To _strRequiredBillcodes.Length - 1
                    If dtBilledBillCode.Select("Billcode_Desc = '" & _strRequiredBillcodes(i) & "'").Length > 0 Then
                        strMainService = _strRequiredBillcodes(i) : Exit For
                    End If
                Next i

                Return strMainService
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dtBilledBillCode)
            End Try
        End Function


        '***************************************************************************************************
        Public Shared Function IsMainService(ByVal strBillcodeDesc As String) As Boolean
            Dim i As Integer
            Dim booReturnVal As Boolean = False

            Try
                For i = 0 To _strRequiredBillcodes.Length - 1
                    If strBillcodeDesc = _strRequiredBillcodes(i) Then
                        booReturnVal = True : Exit For
                    End If
                Next i

                Return booReturnVal
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************************
        Public Function GetModel4DeviceID(ByVal iDeviceID As Integer) As String

            Dim strSql As String = ""
            Dim dt As DataTable
            Dim strModel As String = ""

            Try

                strSql = "select a.model_ID,a.Model_desc from tmodel a" & Environment.NewLine
                strSql &= "inner join tdevice b on a.model_id=b.model_id" & Environment.NewLine
                strSql &= "where b.device_id = " & iDeviceID & ";" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    strModel = dt.Rows(0).Item("Model_desc")
                End If

                Return strModel

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************************
        Public Function GetCosmeticGrade4DeviceID(ByVal iDeviceID As Integer) As String

            Dim strSql As String = ""
            Dim dt As DataTable
            Dim strGrade As String = ""

            Try

                strSql = "select dcode_ID,DCode_SDesc" & Environment.NewLine
                strSql &= "FROM tcellopt" & Environment.NewLine
                strSql &= "INNER JOIN lcodesdetail on tcellopt.OutBoundCosmGradeID = lcodesdetail.Dcode_ID" & Environment.NewLine
                strSql &= "where tcellopt.device_id = " & iDeviceID & ";" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    strGrade = dt.Rows(0).Item("DCode_SDesc")
                End If

                Return strGrade

            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '******************************************************************
        Public Function GetDefectClassReason(Optional ByVal iDefectClass_ID As Integer = 0, _
                                             Optional ByVal booAddSelecRow As Boolean = False) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                If iDefectClass_ID = 0 Then
                    strSql = "SELECT DefectClass_ID,DefectClass_Desc FROM ni_defectclass Order by DefectClass_Desc;" & Environment.NewLine
                Else
                    strSql = "SELECT DefectClass_ID,DefectClass_Desc FROM ni_defectclass Where DefectClass_ID = " & iDefectClass_ID & ";" & Environment.NewLine
                End If

                dt = Me._objDataProc.GetDataTable(strSql)

                If booAddSelecRow = True Then dt.LoadDataRow(New Object() {"0", "--Select--"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetSelectedDefectClassReasonData(ByVal iDevice_ID As Integer) As DataTable
            Dim strSQL As String = ""
            Dim dt As DataTable

            Try
                strSQL = "SELECT A.*,B.DefectClass_Desc FROM ni_device_defectclass A" & Environment.NewLine
                strSQL &= " INNER JOIN ni_defectclass B ON A.DefectClass_ID=B.DefectClass_ID" & Environment.NewLine
                strSQL &= " WHERE A.Device_ID=" & iDevice_ID & ";" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSQL)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function SaveSelectedDefectClassReasonData(ByVal iDevice_ID As Integer, ByVal iDefectClass_ID As Integer) As Integer
            Dim strSQL As String = ""
            Dim dt As DataTable
            Dim i As Integer = 0

            Try
                strSQL = "SELECT * FROM ni_device_defectclass " & Environment.NewLine
                strSQL &= " WHERE Device_ID=" & iDevice_ID & " AND DefectClass_ID=" & iDefectClass_ID & ";" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSQL)
                If Not dt.Rows.Count > 0 Then
                    strSQL = "INSERT INTO ni_device_defectclass (Device_ID,DefectClass_ID) " & Environment.NewLine
                    strSQL &= " VALUES (" & Environment.NewLine
                    strSQL &= iDevice_ID & "," & Environment.NewLine
                    strSQL &= iDefectClass_ID & ");" & Environment.NewLine
                    i = Me._objDataProc.ExecuteNonQuery(strSQL)
                Else
                    i = 1
                End If

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function DeleteSelectedDefectClassReason(ByVal iDevice_DC_ID As Integer) As Integer
            Dim strSQL As String = ""

            Try
                strSQL = "DELETE FROM ni_device_defectclass" & Environment.NewLine
                strSQL &= " WHERE Device_DC_ID=" & iDevice_DC_ID & ";" & Environment.NewLine

                Return Me._objDataProc.ExecuteNonQuery(strSQL)


            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetDeviceBillData(ByVal iDevice_ID As Integer) As DataTable
            Dim strSQL As String = ""
            Dim strBillCols As String = ""
            Dim strBillCodeCols As String = ""
            Dim strBillTypeCols As String = ""
            Dim dt As DataTable
            Dim row As DataRow

            Try
                strSQL = "DESC tDeviceBill;"
                dt = Me._objDataProc.GetDataTable(strSQL)
                For Each row In dt.Rows
                    If Trim(row("Field")).ToUpper <> "Device_ID".ToUpper Then
                        If strBillCols.Trim.Length = 0 Then
                            strBillCols = "B." & row("field")
                        Else
                            strBillCols &= ",B." & row("field")
                        End If
                    End If
                Next
                'strSQL = "DESC lBillCodes;"
                'dt = Me._objDataProc.GetDataTable(strSQL)
                'For Each row In dt.Rows
                '    If Trim(row("Field")).ToUpper <> "BillCode_ID".ToUpper AndAlso Trim(row("Field")).ToUpper <> "Device_ID".ToUpper Then
                '        If strBillCodeCols.Trim.Length = 0 Then
                '            strBillCodeCols = "C." & row("field")
                '        Else
                '            strBillCodeCols &= ",C." & row("field")
                '        End If
                '    End If
                'Next
                strBillCodeCols = "C.BillCode_Desc"
                strSQL = "DESC lBillType;"
                dt = Me._objDataProc.GetDataTable(strSQL)
                For Each row In dt.Rows
                    If Trim(row("Field")).ToUpper <> "BillType_ID".ToUpper Then
                        If strBillTypeCols.Trim.Length = 0 Then
                            strBillTypeCols = "D." & row("field")
                        Else
                            strBillTypeCols &= ",D." & row("field")
                        End If
                    End If
                Next
                strSQL = "SELECT A.*," & strBillCols & "," & strBillCodeCols & "," & strBillTypeCols & Environment.NewLine
                strSQL &= " FROM tDevice A INNER JOIN tDeviceBill B ON A.Device_ID=B.Device_ID" & Environment.NewLine
                strSQL &= " INNER JOIN lBillCodes C ON B.BillCode_ID=C.BillCode_ID" & Environment.NewLine
                strSQL &= " INNER JOIN lBillType D ON C.BillType_ID=D.BillType_ID" & Environment.NewLine
                strSQL &= " WHERE A.Device_ID=" & iDevice_ID & ";" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSQL)

                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function UpdateKeyboardDeviceBilling(ByVal iDevice_ID As Integer, _
                                                    ByVal iBillCode_ID As Integer, _
                                                    ByVal iUser_ID As Integer, _
                                                    ByVal vInvoiceAmt As Double, _
                                                    ByVal iEmpNo As Integer, _
                                                    ByVal iShift_ID As Integer, _
                                                    ByVal iProd_ID As Integer, _
                                                    ByVal strWorkDate As String, _
                                                    ByVal strBillDateTime As String, _
                                                    ByVal strPCName As String) As Integer
            Dim strSQL As String = ""
            Dim i As Integer = 0
            Dim dt As DataTable
            Dim vCharges As Double = 0.0
            Dim row As DataRow

            Try
                'Insert tdevicebill
                strSQL = "INSERT INTO tdevicebill ( DBill_RegPartPrice, DBill_AvgCost, DBill_StdCost, DBill_InvoiceAmt" & Environment.NewLine
                strSQL &= ", Device_ID, BillCode_ID, Fail_ID, Repair_ID, User_ID, Date_Rec, Part_Number" & Environment.NewLine
                strSQL &= ", ReplPartSN" & Environment.NewLine
                strSQL &= ") VALUES (" & Environment.NewLine
                strSQL &= "0,0,0," & vInvoiceAmt & Environment.NewLine
                strSQL &= "," & iDevice_ID & "," & iBillCode_ID & ",0,0," & iUser_ID & Environment.NewLine
                strSQL &= ",DATE_FORMAT(now(), '%Y-%m-%d'),'S0'" & Environment.NewLine
                strSQL &= ",'');" & Environment.NewLine

                i = Me._objDataProc.ExecuteNonQuery(strSQL)

                'Update tdevice
                strSQL = "SELECT * from tdevice where device_ID=" & iDevice_ID & ";"
                dt = Me._objDataProc.GetDataTable(strSQL)
                For Each row In dt.Rows
                    If row.IsNull("Device_LaborCharge") Then
                        vCharges = vInvoiceAmt
                    Else
                        vCharges = vInvoiceAmt + CDbl(row("Device_LaborCharge"))
                    End If
                Next
                strSQL = "UPDATE tDevice SET Device_LaborCharge=" & vCharges & ",Device_LaborLevel=1" & Environment.NewLine
                strSQL &= ",Device_DateBill='" & strBillDateTime & "' WHERE Device_ID=" & iDevice_ID & ";"

                i += Me._objDataProc.ExecuteNonQuery(strSQL)

                'Update parttransaction
                strSQL = "INSERT INTO tparttransaction" & Environment.NewLine
                strSQL &= " (Device_ID, BillCode_ID, User_ID, Date_Rec, EmployeeNo" & Environment.NewLine
                strSQL &= ", Trans_Amount, Shift_ID_Trans, WorkDate, MachineName, New, Date_Server, cc_id, Part_Number, Prod_ID" & Environment.NewLine
                strSQL &= ", ScreenID) VALUES (" & Environment.NewLine
                strSQL &= iDevice_ID & "," & iBillCode_ID & "," & iUser_ID & ",now()" & "," & iEmpNo & Environment.NewLine
                strSQL &= ",1," & iShift_ID & ",'" & strWorkDate & "','" & strPCName & "',1,Now(),0,'S0'," & iProd_ID & Environment.NewLine
                strSQL &= ",0);" & Environment.NewLine

                i += Me._objDataProc.ExecuteNonQuery(strSQL)

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function UpdateKeyboardDeviceAutoShip(ByVal iDevice_ID As Integer, _
                                                     ByVal iPallet_ID As Integer, _
                                                     ByVal iShift_ID As Integer, _
                                                     ByVal iDevConditionID As Integer, _
                                                     ByVal strDateTime As String, _
                                                     ByVal strWorkDate As String) As Integer
            Dim strSQL As String = ""
            Dim i As Integer = 0
            Dim dt As DataTable

            Dim iShip_ID As Integer = 735077
            Dim iGradeID As Integer = 3858
            Dim iWipOnwerIDOld As Integer = 1
            Dim iWipOnwerID As Integer = 7
            Dim strWorkStation As String = "INTRANSIT"

            Try
                '1. Insert tDevice
                strSQL = "Update tdevice set device_dateShip='" & strDateTime & "',device_shipworkdate='" & strWorkDate & "',Pallett_ID= " & iPallet_ID & Environment.NewLine
                strSQL &= ",Shift_ID_ship=" & iShift_ID & ",Ship_ID=" & iShip_ID & " WHERE Device_ID=" & iDevice_ID & ";" & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSQL)

                '2. Update tCellOpt
                strSQL = "update tcellopt set Cellopt_WIPOwnerOld=" & iWipOnwerIDOld & ", Cellopt_WIPOwner=" & iWipOnwerID & ", WorkStation='" & strWorkStation & "',OutBoundCosmGradeID=" & iGradeID & ",InBoundCosmGrade=" & iGradeID & "" & Environment.NewLine
                strSQL &= " WHERE Device_ID=" & iDevice_ID & ";"
                i += Me._objDataProc.ExecuteNonQuery(strSQL)

                '3. Copy/update warehouse_items
                strSQL = "SELECT * FROM warehouse.warehouse_items where device_ID=" & iDevice_ID & ";"
                dt = Me._objDataProc.GetDataTable(strSQL)
                If dt.Rows.Count = 0 Then
                    Throw New Exception("Can't update the device data in warehouse.warehouse_items. See IT.")
                Else
                    strSQL = "Insert Into warehouse.warehouse_items  (Device_ID,Serial,Date_Received,Pager_Number,Cap_Code,RF_ID,Physical_Abuse_ID" & Environment.NewLine
                    strSQL &= " ,Holder_Condition_ID,Case_Condition_ID,BatteryCover_Condition_ID,WB_ID,WR_ID,Labor_Charge,BillCode_ID,Model_ID" & Environment.NewLine
                    strSQL &= " ,Freq_ID,BaudRate_ID,Comment,Management_Type_ID,Recpt_UsrID,DevConditionID,CosmGradeID,SODetailsID,SoftKeyCode" & Environment.NewLine
                    strSQL &= " ,DOA,SelfInflicted,RptSent)" & Environment.NewLine
                    strSQL &= " Select 0 as Device_ID,Serial,Date_Received,Pager_Number,Cap_Code,RF_ID,Physical_Abuse_ID,Holder_Condition_ID" & Environment.NewLine
                    strSQL &= " ,Case_Condition_ID,BatteryCover_Condition_ID,WB_ID,WR_ID,0 as Labor_Charge,0 as BillCode_ID,Model_ID,Freq_ID," & Environment.NewLine
                    strSQL &= " BaudRate_ID,Comment," & iDevConditionID & " as Management_Type_ID,Recpt_UsrID," & iDevConditionID & " as DevConditionID," & iGradeID & " as CosmGradeID" & Environment.NewLine
                    strSQL &= " ,0 as SODetailsID,SoftKeyCode,DOA,0 as SelfInflicted,0 as RptSent" & Environment.NewLine
                    strSQL &= " FROM warehouse.warehouse_items  where Device_ID=" & iDevice_ID & ";" & Environment.NewLine
                    i += Me._objDataProc.ExecuteNonQuery(strSQL)
                End If

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function



        '******************************************************************
        Public Function DeleteSelectedDefectClassReasonByDeviceID(ByVal iDevice_ID As Integer) As Integer
            Dim strSQL As String = ""

            Try
                strSQL = "DELETE FROM ni_device_defectclass" & Environment.NewLine
                strSQL &= " WHERE Device_ID=" & iDevice_ID & ";" & Environment.NewLine

                Return Me._objDataProc.ExecuteNonQuery(strSQL)


            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function getDefectClassReasonSelected_TableDef() As DataTable
            Dim dt As New DataTable()
            dt.Columns.Add("DefectClass_Desc", GetType(String))
            dt.Columns.Add("DefectClass_ID", GetType(Integer))
            dt.Columns.Add("Device_ID", GetType(Integer))
            dt.Columns.Add("Device_DC_ID", GetType(Integer))
            Return dt
        End Function

        '***************************************************************************************************
        Public Function IsDeviceAbused(ByVal device_id As Integer) As Boolean
            Dim _abused As Boolean = False
            Dim objDataProc As DBQuery.DataProc
            Dim strSql As String
            Dim _result As String
            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "select * from warehouse.warehouse_items where SelfInflicted>0 and device_ID=" & device_id.ToString()
                _result = objDataProc.GetSingletonString(strSql)
                Return _result.Length > 0
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

#End Region

    End Class
End Namespace