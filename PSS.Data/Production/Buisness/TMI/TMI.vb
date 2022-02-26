Option Explicit On 
Imports System.ComponentModel
Namespace Buisness
    Public Class TMI
        Public Const CUSTOMERID As Integer = 2519
        Public Const LOCID As Integer = 3319
        Public Const GROUPID As Integer = 102

        Public Enum WIP_Status
            <Description("RMA Received")> RMAReceived = 1
            <Description("Return Kit Shipped")> EmptyBoxShipped = 2
        End Enum


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

#Region "SQL Data Functions"



        '******************************************************************
        Public Function GetClaimFullInfo(ByVal iEW_ID As Integer, ByVal iCust_ID As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                Select Case iCust_ID
                    Case Me.CUSTOMERID
                        strSql = "SELECT a.EW_ID,a.WO_ID,a.ClaimNo,a.TMIServiceClient,a.ShipTo_Name," & Environment.NewLine
                        strSql &= " a.Type,a.Brand,a.Model,a.SerialNo,a.Reason,a.Note," & Environment.NewLine
                        strSql &= " a.Tel,a.Address1,a.Address2,a.City,a.State_ID, b.State_Short,a.ZipCode,a.Cntry_ID,c.Cntry_Name,a.Email,a.PSSI2Cust_TrackNo," & Environment.NewLine
                        strSql &= " a.Cust2PSSI_TrackNo,a.Final_PSSI2Cust_TrackNo,a.Date,a.LoadedDateTime," & Environment.NewLine
                        strSql &= " a.TrackCreatedDateTime,a.QuoteSubmittedDate,a.SC_ID,d.SC_Desc,a.Final_SC_ID,e.SC_Desc as Final_SC_Desc,a.S_ID," & Environment.NewLine
                        strSql &= " f.Description as PSSI_CurrentStatus,a.RepairStatusCode,a.PSSI2Cust_ShipmentCost," & Environment.NewLine
                        strSql &= " a.Cust2PSSI_ShipmentCost,a.Final_PSSI2Cust_ShipmentCost,a.Cust_ID," & Environment.NewLine
                        strSql &= " a.LastClaimNo,if(a.ReturnBoxYesNo=1,'Yes','No') as ReturnBoxYesNo,h.Cust_Name1,a.User_ID,g.user_fullname" & Environment.NewLine
                        strSql &= "  FROM ExtendedWarranty a" & Environment.NewLine
                        strSql &= " LEFT JOIN lstate b ON a.State_ID=b.State_ID" & Environment.NewLine
                        strSql &= " LEFT JOIN lcountry c ON a.Cntry_ID=c.cntry_ID" & Environment.NewLine
                        strSql &= "  LEFT JOIN  lshipcarrier d ON a.SC_ID=d.SC_ID" & Environment.NewLine
                        strSql &= "  LEFT JOIN  lshipcarrier e ON a.Final_SC_ID=e.SC_ID" & Environment.NewLine
                        strSql &= " LEFT JOIN  TMI_Status f ON a.S_ID=f.S_ID" & Environment.NewLine
                        strSql &= " LEFT JOIN  security.tusers g ON a.User_ID=g.User_ID" & Environment.NewLine
                        strSql &= " LEFT JOIN  tCustomer h ON a.Cust_ID=h.Cust_ID" & Environment.NewLine
                        strSql &= " WHERE a.EW_ID =" & iEW_ID & " AND a.Cust_ID=" & iCust_ID & ";" & Environment.NewLine
                    Case PSS.Data.Buisness.AIG.CUSTOMERID
                        strSql = "SELECT a.EW_ID,a.WO_ID,a.ClaimNo,a.ShipTo_Name," & Environment.NewLine
                        strSql &= " a.Type,a.Brand,a.Model,a.SerialNo,a.Reason,concat(trim(a.DefectType1),'. ' , trim(a.DefectType2),'. ' , trim(a.ErrDesc_ItemSKU)) as Note," & Environment.NewLine
                        strSql &= " a.Tel,a.Address1,a.Address2,a.City,a.State_ID, b.State_Short,a.ZipCode,a.Cntry_ID,c.Cntry_Name,a.Email,a.PSSI2Cust_TrackNo," & Environment.NewLine
                        strSql &= " a.Cust2PSSI_TrackNo,a.Final_PSSI2Cust_TrackNo,a.Date,a.LoadedDateTime," & Environment.NewLine
                        strSql &= " a.TrackCreatedDateTime,a.QuoteSubmittedDate,a.SC_ID,d.SC_Desc,a.Final_SC_ID,e.SC_Desc as Final_SC_Desc,a.S_ID," & Environment.NewLine
                        strSql &= " f.Description as PSSI_CurrentStatus,a.RepairStatusCode,a.PSSI2Cust_ShipmentCost," & Environment.NewLine
                        strSql &= " a.Cust2PSSI_ShipmentCost,a.Final_PSSI2Cust_ShipmentCost,a.Cust_ID," & Environment.NewLine
                        strSql &= " a.LastClaimNo,if(a.ReturnBoxYesNo=1,'Yes','No') as ReturnBoxYesNo,h.Cust_Name1,a.User_ID,g.user_fullname" & Environment.NewLine
                        strSql &= "  FROM ExtendedWarranty a" & Environment.NewLine
                        strSql &= " LEFT JOIN lstate b ON a.State_ID=b.State_ID" & Environment.NewLine
                        strSql &= " LEFT JOIN lcountry c ON a.Cntry_ID=c.cntry_ID" & Environment.NewLine
                        strSql &= "  LEFT JOIN  lshipcarrier d ON a.SC_ID=d.SC_ID" & Environment.NewLine
                        strSql &= "  LEFT JOIN  lshipcarrier e ON a.Final_SC_ID=e.SC_ID" & Environment.NewLine
                        strSql &= " LEFT JOIN  TMI_Status f ON a.S_ID=f.S_ID" & Environment.NewLine
                        strSql &= " LEFT JOIN  security.tusers g ON a.User_ID=g.User_ID" & Environment.NewLine
                        strSql &= " LEFT JOIN  tCustomer h ON a.Cust_ID=h.Cust_ID" & Environment.NewLine
                        strSql &= " WHERE a.EW_ID =" & iEW_ID & " AND a.Cust_ID=" & iCust_ID & ";" & Environment.NewLine
                End Select

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        Public Function GetClaimNoIDName(ByVal iCust_ID As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try

                strSql = "SELECT EW_ID,ShipTo_Name" & Environment.NewLine
                strSql &= " FROM extendedwarranty" & Environment.NewLine
                strSql &= " WHERE  WO_ID is Null  and cust_ID=" & iCust_ID & Environment.NewLine
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

        Public Function InsertWorkOrderData(ByVal WOCustWOStr As String, ByVal iWO_Quantity As Integer, _
                                            ByVal iLoc_ID As Integer, ByVal iGroup_ID As Integer) As Integer

            Dim strSql As String = ""
            Dim i As Integer = 0

            Try
                WOCustWOStr = WOCustWOStr.Replace("'", "''")

                strSql = "INSERT INTO tWorkOrder " & Environment.NewLine
                strSql &= " (WO_CustWO,WO_Date,Loc_ID,Group_ID,WO_Closed,WO_CameWithFile,WO_Quantity)" & Environment.NewLine
                strSql &= " VALUES ( '" & WOCustWOStr & "'," & "now()," & iLoc_ID & "," & iGroup_ID & "," & "0,1," & iWO_Quantity & ")" & Environment.NewLine

                i = Me._objDataProc.ExecuteNonQuery(strSql)

                If i = 0 Then 'failed
                    Return i
                Else
                    strSql = "SELECT LAST_INSERT_ID();"
                    Return Me._objDataProc.GetIntValue(strSql)
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetWorkOrderID(ByVal WOCustWOStr As String, ByVal iLoc_ID As Integer) As Integer

            Dim strSql As String = ""
            Dim dt As DataTable
            Dim iWO_ID As Integer = 0

            Try
                WOCustWOStr = WOCustWOStr.Replace("'", "''")


                strSql = "SELECT WO_ID FROM tWorkOrder " & Environment.NewLine
                strSql &= "WHERE WO_CustWO = '" & WOCustWOStr & "'" & Environment.NewLine
                strSql &= " AND Loc_ID=" & iLoc_ID & Environment.NewLine


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
                                            ByVal PSSIStatus_Str As String, _
                                            ByVal iSC_ID As Integer, _
                                            ByVal iUser_ID As Integer, _
                                            ByVal PPSI2CustomerShippingCost As Double) As Integer

            Dim strSql As String = ""

            Try

                strSql = "UPDATE ExtendedWarranty " & Environment.NewLine
                strSql &= " SET PSSI2Cust_TrackNo= '" & outboundTrackStr & "'," & Environment.NewLine
                strSql &= "Cust2PSSI_TrackNo='" & returnTrackStr & "'," & Environment.NewLine
                strSql &= "TrackCreatedDateTime=now()," & Environment.NewLine
                strSql &= "S_ID=" & PSSIStatus_ID & "," & Environment.NewLine
                strSql &= "PSSI_CurrentStatus='" & PSSIStatus_Str & "'," & Environment.NewLine
                strSql &= "SC_ID=" & iSC_ID & "," & Environment.NewLine
                strSql &= "WO_ID=" & iWO_ID & "," & Environment.NewLine
                strSql &= "PSSI2Cust_ShipmentCost =" & PPSI2CustomerShippingCost & "," & Environment.NewLine
                strSql &= "User_ID=" & iUser_ID & Environment.NewLine
                strSql &= " WHERE EW_ID=" & iEW_ID & Environment.NewLine

                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetClaimNoCount(ByVal ClaimNoStr As String, ByVal iCust_ID As Integer) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim WO_Quantity As Integer = 0

            Try
                ClaimNoStr = ClaimNoStr.Replace("'", "''")

                strSql = "SELECT Count(*)" & Environment.NewLine
                strSql &= " FROM ExtendedWarranty" & Environment.NewLine
                strSql &= " WHERE  CUST_ID =" & iCust_ID & Environment.NewLine
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

        Public Function GetClaimNo(ByVal iEW_ID As Integer) As String
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT ClaimNo" & Environment.NewLine
                strSql &= " FROM extendedwarranty" & Environment.NewLine
                strSql &= " WHERE EW_ID=" & iEW_ID & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    Return dt.Rows(0).Item(0)
                Else
                    Return ""
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

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

#End Region

    End Class
End Namespace