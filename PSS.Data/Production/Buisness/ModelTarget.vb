Option Explicit On 

Namespace Buisness
    Public Class ModelTarget

        Private objMisc As Production.Misc

        '***************************************************
        Public Sub New()
            objMisc = New Production.Misc()
        End Sub

        Protected Overrides Sub Finalize()
            objMisc = Nothing
            MyBase.Finalize()
        End Sub
        '***************************************************

        '*****************************************************************
        Public Function GetAllModelTarget() As DataTable
            Dim strSql, strModelDesc As String
            Dim dtMT, dtFR As DataTable
            Dim R1, drArr() As DataRow

            Try
                strSql = "SELECT MT_ID, tmodeltarget.MT_Cust_ID, tmodeltarget.MT_Model_ID, " & Environment.NewLine
                strSql &= "tcustomer.Cust_Name1 as Customer,  tmodel.Model_Desc as Model, " & Environment.NewLine
                strSql &= "MT_Enterprise as Enterprise, " & Environment.NewLine
                strSql &= "tmodeltarget.MT_BERCap as 'BER Cap', " & Environment.NewLine
                strSql &= "tmodeltarget.MT_Target as 'Target' " & Environment.NewLine
                strSql &= ", if(AutoBill = 1, 'Yes', 'No') as 'Special Billing?', AutoBill " & Environment.NewLine
                strSql &= ", if(IsOnHold2 = 1, 'Yes', 'No') as 'OnHold2?', IsOnHold2" & Environment.NewLine
                strSql &= ", if(FlatRate = 1, 'Yes', 'No') as 'FlatRate?', FlatRate " & Environment.NewLine
                'strSql &= ", FlatRate_IW_LaborCharge as 'Flat IW Labor', FlatRate_IW_PartCharge as 'Flat IW Part' " & Environment.NewLine
                'strSql &= ", FlatRate_OW_LaborCharge as 'Flat OW Labor', FlatRate_OW_PartCharge as 'Flat OW Part', FlatRate_DeviceSaving as 'Flat-Saving' " & Environment.NewLine
                strSql &= ", 0 as FlatRate_ID , 0.0 as 'Flat IW Labor', 0.0 as 'Flat IW Part',0.0 as 'IW Battery Cover' " & Environment.NewLine
                strSql &= ", 0.0 as 'Flat OW Labor', 0.0 as 'Flat OW Part',0.0 as 'OW Battery Cover', 0.0 as 'Flat-Saving'" & Environment.NewLine
                strSql &= ", 0.0 as 'OnHold2_Labor',0.0 as 'OnHold2_Part'" & Environment.NewLine
                strSql &= ", '' as 'Requested Date' ,  '' as 'Approved Date', 0 as 'Invoice Effective Month', 0 as 'Invoice Effective Year' " & Environment.NewLine
                strSql &= ", if(Active = 1, 'Yes', 'No') as 'Active?', Active " & Environment.NewLine
                strSql &= "FROM tmodeltarget " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tmodel.Model_ID = tmodeltarget.MT_Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN tcustomer ON tmodeltarget.MT_Cust_ID = tcustomer.Cust_ID " & Environment.NewLine
                strSql &= "WHERE tcustomer.Cust_Inactive = 0 "
                objMisc._SQL = strSql
                dtMT = objMisc.GetDataTable

                strSql = "SELECT UCASE(Model_Desc) as 'Model', A.* FROM tflatratepricebymodel A INNER JOIN tmodel B ON A.Model_ID = B.Model_ID ORDER BY Model_ID, InvYearMonth " & Environment.NewLine
                objMisc._SQL = strSql
                dtFR = objMisc.GetDataTable

                For Each R1 In dtMT.Rows
                    If CInt(R1("FlatRate")) = 1 Then
                        strModelDesc = R1("Model")
                        If strModelDesc.ToUpper.EndsWith("_FUN") Then strModelDesc = strModelDesc.ToUpper.Replace("_FUN", "")

                        R1.BeginEdit()

                        drArr = dtFR.Select("Cust_ID = " & R1("MT_Cust_ID") & " AND Model = '" & strModelDesc & "'", "InvYearMonth DESC")
                        If drArr.Length > 0 Then
                            R1("FlatRate_ID") = drArr(0)("FlatRate_ID")
                            R1("Flat IW Labor") = drArr(0)("IW_LaborCharge") : R1("Flat IW Part") = drArr(0)("IW_PartCharge")
                            R1("Flat OW Labor") = drArr(0)("OW_LaborCharge") : R1("Flat OW Part") = drArr(0)("OW_PartCharge")
                            R1("IW Battery Cover") = drArr(0)("IW_BattCovCost")
                            R1("OW Battery Cover") = drArr(0)("OW_BattCovCost")

                            R1("Flat-Saving") = drArr(0)("DeviceSaving")

                            R1("OnHold2_Labor") = drArr(0)("OnHold2_LaborCharge")
                            R1("OnHold2_Part") = drArr(0)("OnHold2_PartCharge")

                        R1("Requested Date") = CDate(drArr(0)("RequestedDate")).ToString("MM/dd/yy")
                        R1("Approved Date") = CDate(drArr(0)("ApprovedDate")).ToString("MM/dd/yy")
                        R1("Invoice Effective Month") = drArr(0)("InvoiceMonth")
                        R1("Invoice Effective Year") = drArr(0)("InvoiceYear")
                    End If

                    R1.EndEdit()
                    End If
                Next R1

                dtMT.AcceptChanges()

                Return dtMT
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************
        Public Function GetAllCellstarEnterpriseCode() As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT DISTINCT csin_EnterpriseCode as Enterprise FROM cstincomingdata WHERE csin_EnterpriseCode is not null;" 
                objMisc._SQL = strSql
                Return objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************
        Public Function AddUpdateModelTarget(ByVal iUser_ID As Integer, ByVal iCust_ID As Integer, ByVal iModel_ID As Integer, _
                                             ByVal strEnterprise As String, ByVal decBERCap As Decimal, _
                                             ByVal decTarget As Decimal, ByVal iAutoBill As Integer, ByVal iActive As Integer, _
                                             ByVal iFlatRate As Integer, ByVal decIWLabor As Decimal, ByVal decIWPart As Decimal, _
                                             ByVal decOWLabor As Decimal, ByVal decOWPart As Decimal, ByVal decSaving As Decimal, _
                                             ByVal strFlatRate_RequestedDate As String, ByVal strFlatRate_ApprovedDate As String, _
                                             ByVal dteInvEffMonthYr As DateTime, ByVal strModelDesc As String, _
                                             ByVal iOnHold2 As Integer, ByVal decOnHold2Labor As Decimal, ByVal decOnHold2Part As Decimal, _
                                             ByVal decIWBCCost As Decimal, ByVal decOWBCCost As Decimal) As Integer
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim i, iCosModelID, iFuncModelID As Integer

            Try
                If iFlatRate = 1 Then
                    If strModelDesc.ToUpper.EndsWith("_FUN") Then
                        iFuncModelID = iModel_ID
                        iCosModelID = Generic.GetModelIDByModelDesc(strModelDesc.ToUpper.Replace("_FUN", ""))
                        If iCosModelID = 0 Then Throw New Exception("System has failed to find cosmetic model id of model '" & strModelDesc & "'.")
                    Else
                        iCosModelID = iModel_ID
                        iFuncModelID = Generic.GetModelIDByModelDesc(strModelDesc.ToUpper & "_FUN")
                        If iFuncModelID = 0 Then Throw New Exception("System has failed to find functional model id of model '" & strModelDesc & "'.")
                    End If
                End If

                '1: SET MODEL TARGET
                strSql = "SELECT MT_ID " & Environment.NewLine
                strSql &= "FROM tmodeltarget" & Environment.NewLine
                strSql &= "WHERE MT_Cust_ID = " & iCust_ID & " " & Environment.NewLine
                strSql &= "AND MT_Model_ID = " & iModel_ID & " " & Environment.NewLine
                strSql &= "AND MT_Enterprise = '" & strEnterprise.Trim & "';"
                objMisc._SQL = strSql
                dt1 = objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    strSql = "UPDATE tmodeltarget " & Environment.NewLine
                    strSql &= "SET MT_BERCap = " & decBERCap & Environment.NewLine
                    strSql &= ", MT_Target = " & decTarget & Environment.NewLine
                    strSql &= ", AutoBill = " & iAutoBill & ", Active = " & iActive & Environment.NewLine
                    strSql &= " WHERE MT_ID = " & dt1.Rows(0)("MT_ID") & ";"

                    objMisc._SQL = strSql
                    i = objMisc.ExecuteNonQuery
                Else
                    strSql = "INSERT INTO tmodeltarget ( " & Environment.NewLine
                    strSql &= "MT_Cust_ID " & Environment.NewLine
                    strSql &= ", MT_Model_ID " & Environment.NewLine
                    strSql &= ", MT_User_ID " & Environment.NewLine
                    strSql &= ", MT_Enterprise " & Environment.NewLine
                    strSql &= ", MT_BERCap " & Environment.NewLine
                    strSql &= ", MT_Target, AutoBill, Active " & Environment.NewLine
                    strSql &= ") VALUES ( " & Environment.NewLine
                    strSql &= iCust_ID & Environment.NewLine
                    strSql &= ", " & iModel_ID & Environment.NewLine
                    strSql &= ", " & iUser_ID & Environment.NewLine
                    strSql &= ", '" & strEnterprise.Trim & "'" & Environment.NewLine
                    strSql &= ", " & decBERCap & Environment.NewLine
                    strSql &= ", " & decTarget & ", " & iAutoBill & ", " & iActive & Environment.NewLine
                    strSql &= ");"
                    objMisc._SQL = strSql
                    i = objMisc.ExecuteNonQuery
                End If

                '2: SET FLAT RATE, AND OnHold2 DATA
                'SET flat rate for COSMESTIC and FUNCTIONAL
                strSql = "UPDATE tmodeltarget SET FlatRate = " & iFlatRate & ",IsOnHold2 = " & iOnHold2 & " WHERE mt_Model_ID in ( " & iFuncModelID & ", " & iCosModelID & " ) "
                objMisc._SQL = strSql
                i += objMisc.ExecuteNonQuery

                If iFlatRate = 1 Then
                    strSql = "SELECT * FROM tflatratepricebymodel " & Environment.NewLine
                    strSql &= "WHERE Cust_ID = " & iCust_ID & " AND Model_ID = " & iCosModelID & Environment.NewLine
                    strSql &= " AND InvoiceMonth = " & dteInvEffMonthYr.Month & " AND InvoiceYear = " & dteInvEffMonthYr.Year & Environment.NewLine
                    objMisc._SQL = strSql
                    dt1 = objMisc.GetDataTable

                    If dt1.Rows.Count > 0 Then
                        strSql = "UPDATE tflatratepricebymodel SET "
                        strSql &= "IW_LaborCharge = " & decIWLabor & " , IW_PartCharge = " & decIWPart & Environment.NewLine
                        strSql &= ", OW_LaborCharge = " & decOWLabor & ", OW_PartCharge = " & decOWPart & ", DeviceSaving = " & decSaving & Environment.NewLine
                        strSql &= ", RequestedDate = '" & strFlatRate_RequestedDate & "', ApprovedDate = '" & strFlatRate_ApprovedDate & "' " & Environment.NewLine
                        strSql &= ", LastUpdateDate = now(), User_ID = " & iUser_ID & Environment.NewLine
                        strSql &= ", OnHold2_LaborCharge = " & decOnHold2Labor & ", OnHold2_PartCharge = " & decOnHold2Part & Environment.NewLine
                        strSql &= ", IW_BattCovCost = " & decIWBCCost & ", OW_BattCovCost = " & decOWBCCost & Environment.NewLine
                        strSql &= "WHERE FlatRate_ID = " & dt1.Rows(0)("FlatRate_ID")
                        objMisc._SQL = strSql
                        i += objMisc.ExecuteNonQuery
                    Else
                        strSql = " INSERT INTO tflatratepricebymodel ( " & Environment.NewLine
                        strSql &= " Cust_ID, Model_ID, User_ID, IW_LaborCharge, IW_PartCharge, OW_LaborCharge, OW_PartCharge " & Environment.NewLine
                        strSql &= ", DeviceSaving, RequestedDate, ApprovedDate" & Environment.NewLine
                        strSql &= ", InvoiceMonth, InvoiceYear, InvYearMonth, LastUpdateDate,OnHold2_LaborCharge,OnHold2_PartCharge,IW_BattCovCost,OW_BattCovCost" & Environment.NewLine
                        strSql &= " ) VALUES ( " & Environment.NewLine
                        strSql &= iCust_ID & ", " & iCosModelID & ", " & iUser_ID & ", " & decIWLabor & ", " & decIWPart & ", " & decOWLabor & ", " & decOWPart & Environment.NewLine
                        strSql &= ", " & decSaving & ", '" & strFlatRate_RequestedDate & "', '" & strFlatRate_ApprovedDate & "'" & Environment.NewLine
                        strSql &= ", " & dteInvEffMonthYr.Month.ToString("00") & ", " & dteInvEffMonthYr.Year & ", " & dteInvEffMonthYr.Year & dteInvEffMonthYr.Month.ToString("00") & ", now() " & Environment.NewLine
                        strSql &= "," & decOnHold2Labor & "," & decOnHold2Part & "," & decIWBCCost & "," & decOWBCCost & Environment.NewLine
                        strSql &= ") "
                        objMisc._SQL = strSql
                        i += objMisc.ExecuteNonQuery
                    End If
                End If

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '****************************************************************************************************************************************
        Public Function GetFlatRateData() As DataTable
            Dim strSql As String = ""
            Try
                strSql &= "SELECT Cust_Name1 as 'Customer', Model_Desc as 'Model'" & Environment.NewLine
                strSql &= ", IW_LaborCharge as 'IW Labor', IW_PartCharge as 'IW Part', IW_BattCovCost as 'IW BC Cost', OW_LaborCharge as 'OW Labor', OW_PartCharge as 'OW Part', OW_BattCovCost as 'OW BC Cost', DeviceSaving as 'Device Saving'" & Environment.NewLine
                strSql &= ",OnHold2_LaborCharge as 'OH2_LaborCharge',OnHold2_PartCharge as 'OH2_PartCharge'" & Environment.NewLine
                strSql &= ", Date_format(RequestedDate, '%m/%d/%Y') as 'Requested Date', Date_format(ApprovedDate, '%m/%d/%Y') as 'Approved Date'" & Environment.NewLine
                strSql &= ", InvoiceMonth as 'Invoice Effective Month', InvoiceYear as 'Invoice Effective Year'" & Environment.NewLine
                strSql &= ", LastUpdateDate as 'Updated Date', User_FullName as 'Update By'" & Environment.NewLine
                strSql &= "FROM tflatratepricebymodel A INNER JOIN tmodel B ON A.Model_ID = B.Model_ID INNER JOIN tcustomer C ON A.Cust_ID = C.Cust_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN security.tusers D ON A.User_ID = D.User_ID" & Environment.NewLine
                strSql &= "ORDER BY Cust_Name1, Model_Desc ASC, InvYearMonth DESC "
                objMisc._SQL = strSql
                Return objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************************************************************


    End Class
End Namespace