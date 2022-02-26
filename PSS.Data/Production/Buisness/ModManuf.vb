Imports eInfoDesigns.dbProvider.MySqlClient
Imports PSS.Data.Production
Imports System.Text

Namespace Buisness

    Public Class ModManuf

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

#End Region

#Region "Model"

        '******************************************************************************
        Public Shared Function GetLastInsertModelID(ByVal strModelDesc As String, _
                                                    ByVal iManufID As Integer, _
                                                    ByVal iProdID As Integer) As Integer
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT Model_ID FROM tmodel " & Environment.NewLine
                strSql &= "WHERE Model_Desc = '" & strModelDesc & "'" & Environment.NewLine
                strSql &= "AND Manuf_ID = " & iManufID & Environment.NewLine
                strSql &= "AND Prod_ID = " & iProdID & Environment.NewLine
                strSql &= "ORDER BY Model_ID DESC" & Environment.NewLine
                Return objDataProc.GetIntValue(strSql)

            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '******************************************************************************
        Public Shared Function MapPssCustModel(ByVal iPssCustMapID As Integer, _
                                               ByVal iCustID As Integer, _
                                               ByVal iModelID As Integer, _
                                               ByVal strItemNo As String, _
                                               ByVal strItemDesc As String, _
                                               ByVal strInSku As String, _
                                               ByVal strInSkuDesc As String, _
                                               ByVal strOutSku As String, _
                                               ByVal strOutSkuDesc As String, _
                                               ByVal strMaterialType As String, _
                                               ByVal straterialCategory As String, _
                                               ByVal strManufModeDesc As String, _
                                               ByVal iCustMapModelFamiliesID As Integer) As Integer
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                If iPssCustMapID = 0 Then
                    strSql = "INSERT INTO tcustmodel_pssmodel_map ( " & Environment.NewLine
                    strSql &= "cust_id " & Environment.NewLine
                    strSql &= ", model_id " & Environment.NewLine
                    strSql &= ", cust_model_number " & Environment.NewLine
                    strSql &= ", cust_model_desc " & Environment.NewLine
                    strSql &= ", cust_IncomingSku " & Environment.NewLine
                    strSql &= ", cust_IncomingDesc " & Environment.NewLine
                    strSql &= ", cust_OutgoingSku " & Environment.NewLine
                    strSql &= ", cust_OutgoingDesc " & Environment.NewLine
                    strSql &= ", cust_MaterialType " & Environment.NewLine
                    strSql &= ", cust_MaterialCategory " & Environment.NewLine
                    strSql &= ", Manuf_ModelDesc, ModelFamiliesID " & Environment.NewLine
                    strSql &= ") VALUES ( " & Environment.NewLine
                    strSql &= iCustID & Environment.NewLine
                    strSql &= ", " & iModelID & Environment.NewLine
                    strSql &= ", '" & strItemNo & "'" & Environment.NewLine
                    strSql &= ", '" & doapps(strItemDesc) & "'" & Environment.NewLine
                    strSql &= ", '" & doapps(strInSku) & "'" & Environment.NewLine
                    strSql &= ", '" & doapps(strInSkuDesc) & "'" & Environment.NewLine
                    strSql &= ", '" & doapps(strOutSku) & "'" & Environment.NewLine
                    strSql &= ", '" & doapps(strOutSkuDesc) & "'" & Environment.NewLine
                    strSql &= ", '" & doapps(strMaterialType) & "'" & Environment.NewLine
                    strSql &= ", '" & doapps(straterialCategory) & "'" & Environment.NewLine
                    strSql &= ", '" & doapps(strManufModeDesc) & "', " & iCustMapModelFamiliesID & Environment.NewLine
                    strSql &= ") ;" & Environment.NewLine
                Else
                    strSql = "UPDATE tcustmodel_pssmodel_map " & Environment.NewLine
                    strSql &= "SET " & Environment.NewLine
                    strSql &= " cust_model_number = '" & strItemNo & "'" & Environment.NewLine
                    strSql &= ", cust_model_desc = '" & doapps(strItemDesc) & "'" & Environment.NewLine
                    strSql &= ", cust_IncomingSku = '" & doapps(strInSku) & "'" & Environment.NewLine
                    strSql &= ", cust_IncomingDesc = '" & doapps(strInSkuDesc) & "'" & Environment.NewLine
                    strSql &= ", cust_OutgoingSku = '" & doapps(strOutSku) & "'" & Environment.NewLine
                    strSql &= ", cust_OutgoingDesc = '" & doapps(strOutSkuDesc) & "'" & Environment.NewLine
                    strSql &= ", cust_MaterialType = '" & doapps(strMaterialType) & "'" & Environment.NewLine
                    strSql &= ", cust_MaterialCategory = '" & doapps(straterialCategory) & "'" & Environment.NewLine
                    strSql &= ", Manuf_ModelDesc = '" & doapps(strManufModeDesc) & "'" & Environment.NewLine
                    strSql &= ", cm_inactive = 0 " & Environment.NewLine
                    strSql &= ", ModelFamiliesID = " & iCustMapModelFamiliesID & Environment.NewLine
                    strSql &= "WHERE cm_id = " & iPssCustMapID & ";" & Environment.NewLine
                End If

                Return objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '******************************************************************************
        Public Shared Function GetPSSCustModelMap(ByVal iModelID As Integer, _
                                                  ByVal iCustID As Integer) As DataTable
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT * FROM tcustmodel_pssmodel_map " & Environment.NewLine
                strSql &= "WHERE Model_ID = " & iModelID & Environment.NewLine
                strSql &= "AND Cust_ID = " & iCustID & Environment.NewLine
                Return objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '******************************************************************************
        Public Shared Function GetModels() As DataTable
            Dim strSql As String = "SELECT Model_ID, Model_Desc, Prod_ID FROM tmodel ORDER BY Model_Desc;"
            Return GetDataTable(strSql)
        End Function


        Public Shared Function InsertModel(ByVal model As String, ByVal tier As Integer, ByVal flat As Integer, _
                                           ByVal manuf As Integer, ByVal prod As Integer, ByVal asc As Integer, _
                                           ByVal iRptGrp_ID As Integer, ByVal iAPCCode As Integer, ByVal iGSM As Integer, ByVal iModelType As Integer, _
                                           ByVal iAccessoryCategory As Integer, ByVal iUserID As Integer, ByVal strModelMotoSku As String _
                                           , ByVal iAltWrtyDateCode As Integer, ByVal iHasBC As Integer, _
                                           ByVal iSWProcess As Integer, ByVal iKSCapable As Integer, ByVal iTriageNeeded As Integer) As Integer
            Dim strSql As String
            Try
                strSql = "INSERT INTO tmodel (Model_Desc, Model_MotoSku, Model_Tier, Model_Flat, Manuf_ID, Prod_ID, ASCPrice_ID, RptGrp_ID, Accessory, has_bc, sw_process, ks_capable, IsTriaged "

                If prod = 2 Then
                    If iAPCCode > 0 Then
                        strSql &= ", Dcode_ID "
                    End If

                    strSql &= ", Model_GSM, Model_Type "
                End If

                strSql &= ", User_ID, UpdateDate, AltWrtyDateCode ) "

                strSql &= "VALUES ('" & doapps(model) & "', '" & strModelMotoSku & "', '" & tier & "', '" & flat & "', '" & manuf & "', '" & prod & "', '" & asc & "', '" & _
                                   iRptGrp_ID & "' " & ", '" & iAccessoryCategory & "' " & ", " & iHasBC & "," & iSWProcess & "," & iKSCapable & "," & iTriageNeeded

                If prod = 2 Then
                    If iAPCCode > 0 Then
                        strSql &= "," & iAPCCode & " "
                    End If

                    strSql &= ", " & iGSM & ", " & iModelType & " "
                End If
                strSql &= ", " & iUserID & ", now(), " & iAltWrtyDateCode
                strSql &= ");"

                SetData(strSql)

                Return GetLastInsertModelID(doapps(model), manuf, prod)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function DeleteModel(ByVal model_id As Integer) As Boolean
            Try
                Dim strSql As String = "SELECT Count(Model_ID) FROM tpsmap WHERE Model_ID = " & model_id & ";"
                If CInt(GetDataTable(strSql).Rows(0)(0)) <> 0 Then
                    MsgBox("You cannot delete a model that has pricing tied to it." & CInt(GetDataTable(strSql).Rows(0)(0)))
                    Return False
                Else
                    strSql = "DELETE FROM tmodel WHERE Model_ID = " & model_id & ";"
                    SetData(strSql)

                    DeleteFromModelFamilies(model_id)

                    Return True
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Private Shared Sub DeleteFromModelFamilies(ByVal iModelID As Integer)
            Dim dt As DataTable

            Try
                Dim strSQL As String

                strSQL = "SELECT ModelFamiliesID, IFNULL(ModelIDsAndCustomerIDs, '') AS ModelIDsAndCustomerIDs" & Environment.NewLine
                strSQL &= "FROM cogs.ModelFamilies"

                dt = GetDataTable(strSQL)

                If dt.Rows.Count > 0 Then
                    Dim dr As DataRow

                    For Each dr In dt.Rows
                        Dim iModelFamiliyID As Integer = Convert.ToInt32(dr("ModelFamiliesID"))
                        Dim strCheck As String = dr("ModelIDsAndCustomerIDs").ToString()
                        Dim strModelIDsAndCustomerIDs() As String = strCheck.Split(",")

                        If strModelIDsAndCustomerIDs.Length > 0 Then
                            Dim strModelIDCustID As String

                            For Each strModelIDCustID In strModelIDsAndCustomerIDs
                                Dim strMC() As String = strModelIDCustID.Split(":")

                                If Convert.ToInt32(strMC(0)) = iModelID Then
                                    strCheck = strCheck.Replace(strModelIDCustID, String.Empty).Replace(",,", ",")

                                    strSQL = "UPDATE cogs.ModelFamilies" & Environment.NewLine
                                    strSQL &= String.Format("SET ModelIDsAndCustomerIDs = '{0}'", strCheck) & Environment.NewLine
                                    strSQL &= String.Format("WHERE ModelFamiliesID = {0}", iModelFamiliyID)
                                End If
                            Next strModelIDCustID
                        End If
                    Next dr
                End If
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub


        Public Shared Sub UpdateModel(ByVal model_id As Integer, ByVal model As String, ByVal tier As Integer, ByVal flat As Integer, _
                                                    ByVal manuf As Integer, ByVal prod As Integer, ByVal asc As Integer, ByVal iRptGrp_ID As Integer, _
                                                    ByVal iAPCCode As Integer, ByVal iGSM As Integer, ByVal iModelType As Integer, ByVal iAccessoryCategory As Integer, ByVal iUserID As Integer _
                                                    , ByVal iAltWrtyDateCode As Integer, ByVal iHasBC As Boolean, ByVal iModel_MotoSku As String, _
                                                    ByVal iSWProcess As Integer, ByVal iKSCapable As Integer, ByVal iTriageNeeded As Integer)
            Dim strSql As String
            If asc = 0 Then
                strSql = "UPDATE tmodel SET Model_Desc = '" & doapps(model) & "', Model_Tier = '" & tier & "', Model_Flat = '" & flat & "', " & _
                                             "Manuf_ID = '" & manuf & "', Prod_ID = '" & prod & "', RptGrp_ID = '" & iRptGrp_ID & "' "
            Else
                strSql = "UPDATE tmodel SET Model_Desc = '" & doapps(model) & "', Model_Tier = '" & tier & "', Model_Flat = '" & flat & "', " & _
                                             "Manuf_ID = '" & manuf & "', Prod_ID = '" & prod & "', ASCPrice_ID = '" & asc & "', RptGrp_ID = '" & iRptGrp_ID & "' "
            End If
            If prod = 2 Then
                If iAPCCode > 0 Then
                    strSql &= ", Dcode_ID = " & iAPCCode & " "
                End If
                strSql &= ", Model_GSM =  " & iGSM & ", Model_Type = " & iModelType & " "
            End If
            strSql &= ", Accessory = " & iAccessoryCategory & ", User_ID = " & iUserID & ", UpdateDate = now() " & Environment.NewLine
            strSql &= ", AltWrtyDateCode = " & iAltWrtyDateCode & Environment.NewLine
            strSql &= ", has_bc = " & IIf(iHasBC, "1", "0") & Environment.NewLine
            strSql &= ", Model_MotoSku = '" & iModel_MotoSku & "' " & Environment.NewLine
            strSql &= ", sw_process = " & iSWProcess & ", ks_capable = " & iKSCapable & Environment.NewLine
            strSql &= ", IsTriaged= " & iTriageNeeded & Environment.NewLine
            strSql &= " WHERE Model_ID = " & model_id & ";"

            SetData(strSql)
        End Sub

        '**************************************************************
        'added by Lan on 02/23/07. Check if Model_MotoSku exist
        Public Function ValidateModel_MotoSku(ByVal strModel_MotoSku As String) As String
            Dim dt1 As DataTable
            Dim strSql As String = ""
            Dim i As Integer = 0
            Dim strNewModel_MotoSku As String = strModel_MotoSku

            Try
                For i = 0 To strModel_MotoSku.Length - 1
                    strSql = "select count(*) as cnt from tmodel where Model_MotoSku = '" & strNewModel_MotoSku & "';"
                    dt1 = GetDataTable(strSql)
                    If dt1.Rows(0)("cnt") > 0 Then
                        strNewModel_MotoSku = Microsoft.VisualBasic.Left(strNewModel_MotoSku, strNewModel_MotoSku.Length - 1)
                    Else
                        Exit For
                    End If

                    'dispose datatable
                    If Not IsNothing(dt1) Then
                        dt1.Dispose()
                        dt1 = Nothing
                    End If
                Next i

                Return strNewModel_MotoSku

            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '**********************************************************************************
        Public Shared Function UpdateExcludePSDTestSofRef_Buffable(ByVal iModelID As Integer, _
                                                     ByVal booNoPSDTest As Boolean, _
                                                     ByVal booNoSWRef As Boolean, _
                                                     ByVal booBuffable As Boolean, _
                                                     ByVal iUserID As Integer) As Integer
            Dim dt As DataTable
            Dim strExistingModelIDs(), strUpdModelIDs, strToday, strSqlmanufIDs, strSqlCustIDs, strSqlBillcodeIDs As String
            Dim i, iActive As Integer
            Dim booFoundNewModel As Boolean = False

            Try
                strExistingModelIDs = Nothing : strUpdModelIDs = ""
                strSqlmanufIDs = "" : iActive = 1
                strToday = Generic.MySQLServerDateTime(1)
                '********************************
                '1: Set exclude PSD test modelsS
                '********************************
                dt = GetExceptionCriteria("SKIP_PSD")
                If dt.Rows.Count > 0 Then
                    strSqlmanufIDs = dt.Rows(0)("ManufIDs").ToString
                    iActive = Convert.ToInt16(dt.Rows(0)("Active"))
                    strSqlCustIDs = dt.Rows(0)("CustIDs").ToString : strSqlBillcodeIDs = dt.Rows(0)("BillcodeIDs").ToString
                    strExistingModelIDs = dt.Rows(0)("ModelIDs").ToString.Split(",")

                    For i = 0 To strExistingModelIDs.Length - 1
                        If strExistingModelIDs(i).Trim.Length > 0 Then
                            If strExistingModelIDs(i).Trim = iModelID.ToString Then
                                'Do nothing
                            Else
                                If strUpdModelIDs.Trim.Length > 0 Then strUpdModelIDs &= ","
                                strUpdModelIDs &= strExistingModelIDs(i).Trim
                            End If
                        End If
                    Next i
                End If

                If booNoPSDTest Then
                    If strUpdModelIDs.Trim.Length > 0 Then strUpdModelIDs &= ","
                    strUpdModelIDs &= iModelID.ToString
                End If

                'SAVE update and CAPTURE history
                UpdateModelListInExceptionCriteria("SKIP_PSD", strUpdModelIDs, iUserID, strToday)
                WriteExceptionCriteriaHist("SKIP_PSD", strSqlmanufIDs, strUpdModelIDs, strSqlBillcodeIDs, strSqlCustIDs, iActive, strToday, iUserID)

                '********************************
                '2: SET EXCLUDE Software Refurbish
                '********************************
                strExistingModelIDs = Nothing : strUpdModelIDs = "" : Generic.DisposeDT(dt)
                strSqlmanufIDs = "" : iActive = 1
                dt = GetExceptionCriteria("SKIP_SWREF")
                If dt.Rows.Count > 0 Then
                    strSqlmanufIDs = dt.Rows(0)("ManufIDs").ToString
                    iActive = Convert.ToInt16(dt.Rows(0)("Active"))
                    strSqlCustIDs = dt.Rows(0)("CustIDs").ToString : strSqlBillcodeIDs = dt.Rows(0)("BillcodeIDs").ToString
                    strExistingModelIDs = dt.Rows(0)("ModelIDs").ToString.Split(",")

                    For i = 0 To strExistingModelIDs.Length - 1
                        If strExistingModelIDs(i).Trim.Length > 0 Then
                            If strExistingModelIDs(i).Trim = iModelID.ToString Then
                                'Do nothing
                            Else
                                If strUpdModelIDs.Trim.Length > 0 Then strUpdModelIDs &= ","
                                strUpdModelIDs &= strExistingModelIDs(i).Trim
                            End If
                        End If
                    Next i
                End If

                If booNoSWRef Then
                    If strUpdModelIDs.Trim.Length > 0 Then strUpdModelIDs &= ","
                    strUpdModelIDs &= iModelID.ToString
                End If

                'SAVE update and CAPTURE history
                UpdateModelListInExceptionCriteria("SKIP_SWREF", strUpdModelIDs, iUserID, strToday)
                WriteExceptionCriteriaHist("SKIP_SWREF", strSqlmanufIDs, strUpdModelIDs, strSqlBillcodeIDs, strSqlCustIDs, iActive, strToday, iUserID)
                '********************************

                '********************************
                '3: SET EXCLUDE Software Refurbish
                '********************************
                strExistingModelIDs = Nothing : strUpdModelIDs = "" : strSqlCustIDs = "" : strSqlBillcodeIDs = "" : Generic.DisposeDT(dt)
                strSqlmanufIDs = "" : iActive = 1
                dt = GetExceptionCriteria("BUFFABLE")
                If dt.Rows.Count > 0 Then
                    strSqlmanufIDs = dt.Rows(0)("ManufIDs").ToString
                    iActive = Convert.ToInt16(dt.Rows(0)("Active"))
                    strSqlCustIDs = dt.Rows(0)("CustIDs").ToString : strSqlBillcodeIDs = dt.Rows(0)("BillcodeIDs").ToString
                    strExistingModelIDs = dt.Rows(0)("ModelIDs").ToString.Split(",")

                    For i = 0 To strExistingModelIDs.Length - 1
                        If strExistingModelIDs(i).Trim.Length > 0 Then
                            If strExistingModelIDs(i).Trim = iModelID.ToString Then
                                'Do nothing
                            Else
                                If strUpdModelIDs.Trim.Length > 0 Then strUpdModelIDs &= ","
                                strUpdModelIDs &= strExistingModelIDs(i).Trim
                            End If
                        End If
                    Next i
                End If

                If booBuffable Then
                    If strUpdModelIDs.Trim.Length > 0 Then strUpdModelIDs &= ","
                    strUpdModelIDs &= iModelID.ToString
                End If

                'SAVE update and CAPTURE history
                UpdateModelListInExceptionCriteria("BUFFABLE", strUpdModelIDs, iUserID, strToday)
                WriteExceptionCriteriaHist("BUFFABLE", strSqlmanufIDs, strUpdModelIDs, strSqlBillcodeIDs, strSqlCustIDs, iActive, strToday, iUserID)
                '********************************

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**********************************************************************************
        Public Shared Function GetExceptionCriteria(ByVal strExcepCriteriaDes As String) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT * FROM exceptioncriteria WHERE Description in ('" & strExcepCriteriaDes & "') AND Active = 1"
                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**********************************************************************************
        Public Shared Function GetCustomerLocationByCustIDs(ByVal strCustIDs As String) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT * FROM tlocation WHERE Cust_ID in (" & strCustIDs & ");"
                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**********************************************************************************
        Public Shared Function GetExceptionCriteria(ByVal strExcepCriteriaDes As String, ByVal strColName As String) As String
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT " & strColName & " FROM exceptioncriteria WHERE Description = '" & strExcepCriteriaDes & "' AND Active = 1"
                dt = GetDataTable(strSql)

                If dt.Rows.Count > 0 Then Return dt.Rows(0)(0).ToString Else Return ""
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**********************************************************************************
        Public Shared Function ParseExceptionCriteria(ByVal strExcepCriteriaDesc As String, ByVal strColName As String, _
                                                      ByVal strSplitChar As String) As DataTable
            Dim strData, strArrData() As String
            Dim dt, dtExpCriteria As DataTable
            Dim i As Integer = 0
            Dim R1 As DataRow

            Try
                strData = "" : dt = New DataTable()
                dtExpCriteria = GetExceptionCriteria(strExcepCriteriaDesc)

                Select Case strColName
                    Case "ManufIDs"
                        dt.Columns.Add(New DataColumn("Manuf_ID", System.Type.GetType("System.Int32", False)))
                    Case "ModelIDs"
                        dt.Columns.Add(New DataColumn("Model_ID", System.Type.GetType("System.Int32", False)))
                    Case "BillcodeIDs"
                        dt.Columns.Add(New DataColumn("BillCode_ID", System.Type.GetType("System.Int32", False)))
                    Case "PartNumbers"
                        dt.Columns.Add(New DataColumn("Part_Number", System.Type.GetType("System.String", False)))
                    Case "CustIDs"
                        dt.Columns.Add(New DataColumn("Cust_ID", System.Type.GetType("System.Int32", False)))
                End Select

                If dtExpCriteria.Rows.Count > 0 Then
                    strData = dtExpCriteria.Rows(0)(strColName)
                    strArrData = strData.Split(strSplitChar)
                    For i = 0 To strArrData.Length - 1
                        If strArrData(i).Trim.Length > 0 Then
                            R1 = dt.NewRow : R1(0) = strArrData(i).Trim : dt.Rows.Add(R1) : dt.AcceptChanges()
                        End If
                    Next i
                End If

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**********************************************************************************
        Private Shared Sub UpdateModelListInExceptionCriteria(ByVal strExcptCriteriaDecs As String, _
                                                              ByVal strModelIDs As String, _
                                                              ByVal iUserID As Integer, _
                                                              ByVal strLastUpdateDT As String)
            Dim strSql As String = ""
            Try
                strSql = "UPDATE exceptioncriteria " & Environment.NewLine
                strSql &= "SET ModelIDs = '" & strModelIDs & "'" & Environment.NewLine
                strSql &= ", LastUpdateDT = '" & strLastUpdateDT & "'" & Environment.NewLine
                strSql &= ", LastUpdateUserID = " & iUserID & Environment.NewLine
                strSql &= " WHERE Description = '" & strExcptCriteriaDecs & "'"
                SetData(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '**********************************************************************************
        Private Shared Sub WriteExceptionCriteriaHist(ByVal strExcptCriteriaDesc As String, _
                                                      ByVal strManufIDs As String, _
                                                      ByVal strModelIDs As String, _
                                                      ByVal strBillcodeIDs As String, ByVal strCustIDs As String, _
                                                      ByVal iActive As Integer, _
                                                      ByVal strLastUpdateDT As String, _
                                                      ByVal iUserID As Integer)
            Dim strSql As String = ""

            Try
                strSql = "INSERT INTO exceptioncriteriahist ( " & Environment.NewLine
                strSql &= " Description, ManufIDs, ModelIDs, BillcodeIDs, CustIDs, Active, LastUpdateDT, LastUpdateUserID" & Environment.NewLine
                strSql &= ") VALUES ( " & Environment.NewLine
                strSql &= "'" & strExcptCriteriaDesc & "', '" & strManufIDs & "' " & Environment.NewLine
                strSql &= ", '" & strModelIDs & "', '" & strBillcodeIDs & "', '" & strCustIDs & "', " & iActive & ", '" & strLastUpdateDT & "', " & iUserID & Environment.NewLine
                strSql &= ")"
                SetData(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '**********************************************************************************

        Public Shared Function IsKillSwitchModel(ByVal model_id As Integer) As Boolean
            ' TEST TO SEE IF THE DEVICE MODEL IS A SMART PHONE WITH A KILL SWITCH.
            Dim _dt As New DataTable()
            Dim _sb As New StringBuilder()
            _sb.Append("SELECT ")
            _sb.Append("model_id, ")
            _sb.Append("model_desc, ")
            _sb.Append("sw_process, ")
            _sb.Append("ks_capable ")
            _sb.Append("FROM production.tmodel ")
            _sb.Append("WHERE model_id = ")
            _sb.Append(model_id.ToString() & "; ")
            Try
                _dt = GetDataTable(_sb.ToString())
                ' TODO: THE NEXT LINE WILL BE USED ONCE WE START GOING BY THE KILLSWITCH FLAG.
                'If _dt.Rows(0)("sw_process") = 1 ANDALSO _dt.Rows(0)("ks_capable") = 1 Then
                If _dt.Rows(0)("ks_capable") = 1 Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Return False
            Finally
                _dt.Dispose()
            End Try
        End Function

        'Public Shared Function GetModelIDByDeviceID(ByVal device_id As Integer) As Integer
        '	Dim _retVal As Integer = 0
        '	Dim _dt As New DataTable()
        '	Dim _sb As New StringBuilder()
        '	_sb.Append("SELECT ")
        '	_sb.Append("model_id ")
        '	_sb.Append("FROM production.tdevice ")
        '	_sb.Append("WHERE device_id = ")
        '	_sb.Append(device_id.ToString() & "; ")
        '	Try
        '		_dt = GetDataTable(_sb.ToString())
        '		_retVal = _dt.Rows(0)("model_id")
        '	Catch ex As Exception
        '		Throw New Exception("Model id could not be located for this device.")
        '	Finally
        '		_dt.Dispose()
        '	End Try
        'End Function

        'Public Shared Function GetModelIDByDeviceSN(ByVal device_sn As Integer) As Integer
        '	Dim _retVal As Integer = 0
        '	Dim _dt As New DataTable()
        '	Dim _sb As New StringBuilder()
        '	_sb.Append("SELECT ")
        '	_sb.Append("model_id ")
        '	_sb.Append("FROM production.tdevice ")
        '	_sb.Append("WHERE device_sn = ")
        '	_sb.Append(device_sn.ToString() & "; ")
        '	Try
        '		_dt = GetDataTable(_sb.ToString())
        '		_retVal = _dt.Rows(0)("model_id")
        '	Catch ex As Exception
        '		Throw New Exception("Model id could not be located for this device.")
        '	Finally
        '		_dt.Dispose()
        '	End Try
        'End Function



#End Region

#Region "Manufacture"
		Public Shared Function GetManufs() As DataTable
			Dim strSql As String = "SELECT Manuf_ID, Manuf_Desc FROM lmanuf ORDER BY Manuf_Desc;"
			Return GetDataTable(strSql)
		End Function

		'******************************************************************************************************************
		Public Shared Sub InsertManuf(ByVal manufacture As String)
			Dim strSql As String = ""
			Try
				strSql = "INSERT INTO lmanuf (Manuf_Desc) VALUES ('" & doapps(manufacture) & "');"
				SetData(strSql)
			Catch ex As Exception
				Throw ex
			End Try
		End Sub

		'******************************************************************************************************************
		Public Shared Function IsManufExisted(ByVal strManufacture As String) As Boolean
			Dim strSql As String = ""
			Try
				strSql = "SELECT * FROM lmanuf WHERE Manuf_Desc = '" & doapps(strManufacture) & "';"
				If GetDataTable(strSql).Rows.Count > 0 Then Return True Else Return False
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'******************************************************************************************************************

		Public Shared Function DeleteManuf(ByVal manuf_id As Integer) As Boolean
			Dim strSql As String = "SELECT Count(Model_ID) FROM tmodel WHERE manuf_id = " & manuf_id & ";"
			If CInt(GetDataTable(strSql).Rows(0)(0)) <> 0 Then
				MsgBox("You cannot delete a manufacture that has models tied to it.")
				Return False
			Else
				strSql = "DELETE FROM lmanuf WHERE manuf_id = " & manuf_id & ";"
				SetData(strSql)
				Return True
			End If
		End Function

		Public Shared Sub UpdateManuf(ByVal manuf_id As Integer, ByVal adjDesc As String)
			Dim strSql As String = "UPDATE lmanuf SET Manuf_Desc = '" & doapps(adjDesc) & "' WHERE Manuf_ID = " & manuf_id & ";"
			SetData(strSql)
		End Sub
#End Region

#Region "Map"
		Public Shared Function GetModelsMapped() As DataTable

			'Dim strSql As String = "SELECT Model_ID as ID, Prod_Desc as Product, Manuf_Desc as Manufacture, " & _
			'    "Model_Desc as Description, Model_Tier as 'Tier Group', Model_Flat as 'Flat Group', ASCPrice_Code as 'ASC Code'	" & _
			'    ", if (model_GSM = 0, 'Non-GSM', 'GSM') as 'GSM' " & _
			'    ", if (model_type = 0, 'Non-Wipe Down', 'Wipe Down') as 'Model Type' " & _
			'    ", lcodesdetail.Dcode_Sdesc as 'APC Code'" & _
			'     ", if (accessorycatergories.Accessory is null, 'Not Accessory', accessorycatergories.AccessoryCategory) as 'Accessory' " & _
			'     ", if (UPC_Code is null, '', UPC_Code) as 'UPC_Code' " & _
			'     ", IF (FIND_IN_SET(CAST(tmodel.model_id AS CHAR), B.ModelIDSet) > 0, B.name, 'Not Selected') AS 'Model Family' " & _
			'    "FROM ((((lproduct INNER JOIN tmodel ON lproduct.Prod_ID = tmodel.Prod_ID) " & _
			'    "INNER JOIN lmanuf ON tmodel.Manuf_ID = lmanuf.Manuf_ID) " & _
			'    "INNER JOIN lascprice ON tmodel.ASCPrice_ID = lascprice.ASCPrice_ID) " & _
			'    "LEFT OUTER JOIN lcodesdetail on tmodel.Dcode_ID = lcodesdetail.Dcode_id) " & _
			'    "LEFT OUTER JOIN accessorycatergories on tmodel.Accessory = accessorycatergories.Accessory, " & _
			'    "cogs.ModelFamilies B " & _
			'    "ORDER BY tmodel.Model_Desc;"

			Dim strSql As String = ""

			Try
				strSql = "SELECT Model_ID as ID, Prod_Desc as Product, Manuf_Desc as Manufacture, " & Environment.NewLine
				strSql &= "Model_Desc as Description, Model_Tier as 'Tier Group', Model_Flat as 'Flat Group', ASCPrice_Code as 'ASC Code'	" & Environment.NewLine
				strSql &= ", if (model_GSM = 0, 'Non-GSM', 'GSM') as 'GSM' " & Environment.NewLine
				strSql &= ", if (model_type = 0, 'Non-Wipe Down', 'Wipe Down') as 'Model Type' " & Environment.NewLine
				strSql &= ", lcodesdetail.Dcode_Sdesc as 'APC Code'" & Environment.NewLine
				strSql &= ", if (accessorycatergories.Accessory is null, 'Not Accessory', accessorycatergories.AccessoryCategory) as 'Accessory' " & Environment.NewLine
				strSql &= ", if (UPC_Code is null, '', UPC_Code) as 'UPC_Code' " & Environment.NewLine
				strSql &= ", if (AltWrtyDateCode = 1, 'Yes', 'No') as 'Alt. Date Code Logic' " & Environment.NewLine
				strSql &= ", if (User_Fullname is null, '', User_Fullname) as 'Last Update User' " & Environment.NewLine
				strSql &= ", if (tmodel.UpdateDate is null, '', tmodel.UpdateDate) as 'Last Update Date' " & Environment.NewLine
				strSql &= "FROM lproduct INNER JOIN tmodel ON lproduct.Prod_ID = tmodel.Prod_ID " & Environment.NewLine
				strSql &= "INNER JOIN lmanuf ON tmodel.Manuf_ID = lmanuf.Manuf_ID " & Environment.NewLine
				strSql &= "INNER JOIN lascprice ON tmodel.ASCPrice_ID = lascprice.ASCPrice_ID " & Environment.NewLine
				strSql &= "LEFT OUTER JOIN lcodesdetail on tmodel.Dcode_ID = lcodesdetail.Dcode_id " & Environment.NewLine
				strSql &= "LEFT OUTER JOIN accessorycatergories on tmodel.Accessory = accessorycatergories.Accessory " & Environment.NewLine
				strSql &= "LEFT OUTER JOIN security.tusers on tmodel.User_ID = security.tusers.User_ID " & Environment.NewLine
				strSql &= "ORDER BY tmodel.Model_Desc;"

				Return GetDataTable(strSql)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'*************************************************************************
		'Added by Asif on 12/03/2003
		'*************************************************************************
		Public Shared Function GetReportGroups(ByVal iProd_ID As Integer) As DataTable
			Dim strSql As String = "SELECT rptgrp_id, rptgrp_desc FROM lrptgrp where Prod_ID = " & iProd_ID & " ORDER BY rptgrp_desc;"
			Return GetDataTable(strSql)
		End Function
		'*************************************************************************
		'Public Shared Function GetProductGroups(Optional ByVal iModel_ID As Integer = 0) As DataTable
		Public Shared Function GetProductGroups(Optional ByVal iProd_ID As Integer = 0) As DataTable
			Dim strSql As String

			'strSql = "SELECT ProdGrp_ID, ProdGrp_LDesc FROM lprodgrp;"
			'If iModel_ID = 0 Then
			If iProd_ID = 0 Then
				strSql = "SELECT ProdGrp_ID, ProdGrp_LDesc FROM lprodgrp;"
			Else
				'strSql = "SELECT lprodgrp.ProdGrp_ID, lprodgrp.ProdGrp_LDesc " & vbCrLf
				'strSql = strSql & "FROM lprodgrp inner join tmodel on tmodel.Prod_ID = lprodgrp.Prod_ID " & vbCrLf
				'strSql = strSql & "WHERE tmodel.Model_ID = " & iModel_ID & ";"

				strSql = "SELECT ProdGrp_ID, ProdGrp_LDesc FROM lprodgrp WHERE Prod_ID = " & iProd_ID & ";"
			End If

			Return GetDataTable(strSql)
		End Function

		Public Shared Function GetProducts() As DataTable
			Dim strSql As String = "SELECT Prod_ID, Prod_Desc FROM lproduct ORDER BY Prod_Desc;"
			Return GetDataTable(strSql)
		End Function

		Public Shared Function GetASC(ByVal iProd_ID As Integer) As DataTable
			Dim strSql As String = "SELECT ASCPrice_ID, concat(trim(ASCPrice_Code), ' (', trim(ASCPrice_Desc), ')(', ASCPrice_Price, ')') as ASCPrice_Desc FROM lascprice where Prod_ID = " & iProd_ID & " ORDER BY ASCPrice_Code;"
			Return GetDataTable(strSql)
		End Function

		Public Shared Function GetModel(ByVal Model_ID As Integer) As DataTable
			Dim strSql As String

			'Commented by Asif on 12/04/2003
			'strSql = "SELECT Model_ID as ID, Prod_Desc as Product, Manuf_Desc as Manufacture, " & _
			'                "Model_Desc as Description, Model_Tier as 'Tier Group', Model_Flat as 'Flat Group', ASCPrice_Code as 'ASC Code'	 " & _
			'                "FROM (((lproduct INNER JOIN tmodel ON lproduct.Prod_ID = tmodel.Prod_ID) " & _
			'                "INNER JOIN lmanuf ON tmodel.Manuf_ID = lmanuf.Manuf_ID) " & _
			'                "INNER JOIN lascprice ON tmodel.ASCPrice_ID = lascprice.ASCPrice_ID) " & _
			'                "WHERE Model_ID = " & Model_ID & ";"


            strSql = "SELECT Model_ID as ID, Prod_Desc as Product, Manuf_Desc as Manufacture, " & _
             "Model_Desc as Description, Model_Tier as 'Tier Group', Model_Flat as 'Flat Group', concat(trim(ASCPrice_Code), ' (', trim(ASCPrice_Desc), ')(', ASCPrice_Price, ')') as 'ASC Code', " & _
             "RptGrp_ID as 'Report Group', DCode_id, Model_GSM, Model_Type, tmodel.Manuf_ID, tmodel.Prod_ID, tmodel.Dcode_ID, tmodel.ASCPrice_ID, Accessory, Model_MotoSku " & _
             ", AltWrtyDateCode, tmodel.has_bc, tmodel.sw_process, tmodel.ks_capable " & _
             "FROM (((lproduct INNER JOIN tmodel ON lproduct.Prod_ID = tmodel.Prod_ID) " & _
             "INNER JOIN lmanuf ON tmodel.Manuf_ID = lmanuf.Manuf_ID) " & _
             "INNER JOIN lascprice ON tmodel.ASCPrice_ID = lascprice.ASCPrice_ID) " & _
             "WHERE Model_ID = " & Model_ID & ";"

			Return GetDataTable(strSql)
		End Function
#End Region

#Region "Pricing Groups"
		Public Shared Function GetProductGroupsLong() As DataTable
			Dim strSql As String = "SELECT ProdGrp_ID AS ID, ProdGrp_SDesc AS 'Short Desc', ProdGrp_LDesc AS 'Long Desc', " & _
					 "Prod_Desc AS 'Product' FROM lprodgrp " & _
					 "INNER JOIN lproduct ON lprodgrp.Prod_ID = lproduct.Prod_ID ORDER BY ProdGrp_LDesc;"
			Return GetDataTable(strSql)
		End Function

		Public Shared Function LoadProductGroup(ByVal id As Integer) As DataRow
			Dim strSql As String = "SELECT * FROM lprodgrp WHERE ProdGrp_ID = " & id & ";"
			Return GetDataTable(strSql).Rows(0)
		End Function
		'********************************************************************************************************
		'Added by Asif on 12/04/2003
		'********************************************************************************************************
		Public Shared Function GetReportGroupsLong() As DataTable
			Dim strSql As String
			'Dim strSql As String = "SELECT ProdGrp_ID AS ID, ProdGrp_SDesc AS 'Short Desc', ProdGrp_LDesc AS 'Long Desc', " & _
			'                                 "Prod_Desc AS 'Product' FROM lprodgrp " & _
			'                                 "INNER JOIN lproduct ON lprodgrp.Prod_ID = lproduct.Prod_ID ORDER BY ProdGrp_LDesc;"
			Try
				strSql = "SELECT lrptgrp.RptGrp_ID as 'ID', lrptgrp.RptGrp_Desc as 'Desc', lproduct.Prod_Desc AS 'Product' " & _
				   "FROM lrptgrp inner join lproduct ON lrptgrp.Prod_ID = lproduct.Prod_ID ORDER BY 'Desc';"
				Return GetDataTable(strSql)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Public Shared Function LoadReportGroup(ByVal id As Integer) As DataRow
			Dim strSql As String

			Try
				strSql = "SELECT * FROM lrptgrp WHERE RptGrp_ID = " & id & ";"
				Return GetDataTable(strSql).Rows(0)
			Catch ex As Exception
				Throw ex
			End Try

		End Function

		Public Shared Sub InsertReportGroup(ByVal strDesc As String, ByVal iProd As Integer)
			Dim strSql As String
			Try
				strSql = "INSERT INTO lrptgrp (RptGrp_Desc, Prod_ID) VALUES " & _
						"('" & doapps(strDesc) & "', '" & iProd & "')"
				SetData(strSql)
			Catch ex As Exception
				Throw ex
			End Try
		End Sub

		Public Shared Sub UpdateReportGroup(ByVal id As Integer, ByVal strDesc As String, ByVal iProd As Integer)
			Dim strSql As String
			Try
				strSql = "UPDATE lrptgrp SET RptGrp_Desc = '" & doapps(strDesc) & _
						 "', Prod_ID = '" & iProd & "' WHERE RptGrp_ID = " & id & ";"
				SetData(strSql)
			Catch ex As Exception
				Throw ex
			End Try

		End Sub

		Public Shared Function DeleteReportGroup(ByVal id As Integer) As Boolean

			Dim strSql As String
			Try
				strSql = "DELETE FROM lrptgrp WHERE RptGrp_ID = " & id & ";"
				SetData(strSql)
				Return True
			Catch ex As Exception
				Throw ex
			End Try

		End Function
		'**************************************************
		Public Shared Function DeleteProductGroup(ByVal id As Integer) As Boolean
			Dim strSql As String = "SELECT Count(Model_ID) FROM tmodel WHERE Model_Tier = " & id & " OR Model_Flat = " & id & ";"
			If GetDataTable(strSql).Rows(0)(0) <> 0 Then
				Return False
			Else
				strSql = "DELETE FROM lprodgrp WHERE ProdGrp_ID = " & id & ";"
				SetData(strSql)
				Return True
			End If
		End Function

		Public Shared Sub InsertProductGroup(ByVal SDesc As String, ByVal LDesc As String, ByVal Prod As Integer)
			Dim strSql As String = "INSERT INTO lprodgrp (ProdGrp_SDesc, ProdGrp_LDesc, Prod_ID) VALUES " & _
					 "('" & doapps(SDesc) & "', '" & doapps(LDesc) & "', '" & Prod & "')"
			SetData(strSql)
		End Sub

		Public Shared Sub UpdateProductGroup(ByVal id As Integer, ByVal SDesc As String, ByVal LDesc As String, ByVal Prod As Integer)
			Dim strSql As String = "UPDATE lprodgrp SET ProdGrp_SDesc = '" & doapps(SDesc) & _
					 "', ProdGrp_LDesc = '" & doapps(LDesc) & "', Prod_ID = '" & Prod & "' WHERE ProdGrp_ID = " & id & ";"
			SetData(strSql)
		End Sub
		'**************************************************
#End Region

#Region "Model Family"
		'Public Shared Sub UpdateModelFamily(ByVal iModelID As Integer, ByVal iCustomerID As Integer, ByVal iSelectedModelFamiliesID As Integer)
		'    Dim strSQL, strModelIDSet As String
		'    Dim dt As DataTable
		'    Dim iModelFamiliesID As Integer = 0
		'    Dim iCount As Integer
		'    Dim bUpdateID As Boolean = True
		'    Dim bReassignedID As Boolean = False

		'    Try
		'        If iSelectedModelFamiliesID <= 0 Then 'Delete model ID from model family IF it belongs to one
		'            strSQL = "SELECT ModelFamiliesID, CAST(ModelIDsAndCustomerIDs AS CHAR) AS ModelIDsAndCustomerIDs" & Environment.NewLine
		'            strSQL &= "FROM cogs.ModelFamilies"

		'            dt = GetDataTable(strSQL)

		'            If dt.Rows.Count > 0 Then
		'                Dim dr As DataRow

		'                For Each dr In dt.Rows
		'                    Dim iModelFamilyID As Integer = Convert.ToInt32(dr("ModelFamiliesID"))
		'                    Dim strMIDsAndCIDs As String = dr("ModelIDsAndCustomerIDs").ToString()
		'                    Dim strModelIDsAndCustomerIDs() As String = strMIDsAndCIDs.Split(",")
		'                    Dim strMC As String

		'                    For Each strMC In strModelIDsAndCustomerIDs
		'                        Dim iTestCustID As Integer = 0
		'                        If strMC.Split(":").Length > 0 AndAlso strMC.Split(":")(0).Trim.Length > 0 Then iTestCustID = Convert.ToInt32(strMC.Split(":")(0))

		'                        If iTestCustID = iCustomerID Then 'Remove this customer and update the record.
		'                            strMIDsAndCIDs = strMIDsAndCIDs.Replace(strMC, String.Empty).Replace(",,", ",")

		'                            strSQL = "UPDATE cogs.ModelFamilies" & Environment.NewLine
		'                            strSQL &= String.Format("SET ModelIDsAndCustomerIDs = '{0}'", strMIDsAndCIDs) & Environment.NewLine
		'                            strSQL &= String.Format("WHERE ModelFamiliesID = {0}", iModelFamilyID)

		'                            SetData(strSQL)

		'                            Exit For
		'                        End If
		'                    Next strMC
		'                Next dr
		'            End If
		'        Else
		'            strSQL = "SELECT CAST(ModelIDsAndCustomerIDs AS CHAR) AS ModelIDsAndCustomerIDs" & Environment.NewLine
		'            strSQL &= "FROM cogs.ModelFamilies" & Environment.NewLine
		'            strSQL &= String.Format("WHERE ModelFamiliesID = {0}", iSelectedModelFamiliesID)

		'            dt = GetDataTable(strSQL)

		'            If dt.Rows.Count > 0 Then
		'                Dim strSearch As String = String.Format("{0}:{1}", iModelID, iCustomerID)

		'                If dt.Rows(0)(0).ToString().Length > 0 Then
		'                    Dim strMIDsAndCIDs As String = dt.Rows(0)(0).ToString()
		'                    Dim strModelIDsAndCustomerIDs() As String = strMIDsAndCIDs.Split(",")
		'                    Dim strMC As String
		'                    Dim bFound As Boolean = False
		'                    Dim bEdit As Boolean = True

		'                    For Each strMC In strModelIDsAndCustomerIDs
		'                        If strMC.Equals(strSearch) Then
		'                            'Already there.  Perform no edits; just break.
		'                            bFound = True
		'                            bEdit = False

		'                            Exit For
		'                        Else
		'                            Dim iTestCustID As Integer = 0
		'                            If strMC.Split(":").Length > 0 AndAlso strMC.Split(":")(0).Trim.Length > 0 Then iTestCustID = Convert.ToInt32(strMC.Split(":")(0))

		'                            If iTestCustID = iCustomerID Then
		'                                'Change to the new customer ID.
		'                                strMIDsAndCIDs = strMIDsAndCIDs.Replace(strMC, strSearch)

		'                                bFound = True
		'                            End If
		'                        End If
		'                    Next strMC

		'                    If Not bFound Then strMIDsAndCIDs &= IIf(strMIDsAndCIDs.Length > 0, ",", String.Empty) & strSearch

		'                    If bEdit Then
		'                        strSQL = "UPDATE cogs.ModelFamilies" & Environment.NewLine
		'                        strSQL &= String.Format("SET ModelIDsAndCustomerIDs = '{0}'", strMIDsAndCIDs) & Environment.NewLine
		'                        strSQL &= String.Format("WHERE ModelFamiliesID = {0}", iSelectedModelFamiliesID)

		'                        SetData(strSQL)
		'                    End If
		'                Else 'Record for model family ID exists but has empty ModelIDsAndCustomerIDs
		'                    strSQL = "UPDATE cogs.ModelFamilies" & Environment.NewLine
		'                    strSQL &= String.Format("SET ModelIDsAndCustomerIDs = '{0}'", strSearch) & Environment.NewLine
		'                    strSQL &= String.Format("WHERE ModelFamiliesID = {0}", iSelectedModelFamiliesID)

		'                    SetData(strSQL)
		'                End If
		'            Else 'No record for this model family, which should exist.  Throw exception.
		'                Throw New Exception("No record for this model family could be found in cogs.ModelFamilies.")
		'            End If
		'        End If

		'        'If iSelectedModelFamiliesID <= 0 Then 'Delete model ID from model family IF it belongs to one
		'        '    strSQL = "SELECT COUNT(*)" & Environment.NewLine
		'        '    strSQL &= "FROM cogs.ModelFamilies" & Environment.NewLine
		'        '    strSQL &= String.Format("WHERE FIND_IN_SET('{0}', ModelIDSet) > 0", iModelID)

		'        '    dt = GetDataTable(strSQL)
		'        '    iCount = dt.Rows(0)(0)

		'        '    If iCount > 0 Then
		'        '        strSQL = "SELECT ModelFamiliesID, CAST(ModelIDSet AS CHAR)" & Environment.NewLine
		'        '        strSQL &= "FROM cogs.ModelFamilies" & Environment.NewLine
		'        '        strSQL &= String.Format("WHERE FIND_IN_SET('{0}', ModelIDSet) > 0", iModelID)

		'        '        dt = GetDataTable(strSQL)

		'        '        iModelFamiliesID = dt.Rows(0)(0)
		'        '    End If

		'        '    If iModelFamiliesID > 0 Then
		'        '        strModelIDSet = dt.Rows(0)(1)

		'        '        If strModelIDSet.Length > 0 Then
		'        '            strModelIDSet = strModelIDSet.Replace(iModelID.ToString, String.Empty)

		'        '            If strModelIDSet.Length > 0 Then
		'        '                strModelIDSet = strModelIDSet.Replace(",,", ",")

		'        '                If strModelIDSet.Substring(0, 1).Equals(",") Then strModelIDSet = strModelIDSet.Substring(1)

		'        '                If strModelIDSet.Substring(strModelIDSet.Length - 1, 1).Equals(",") Then strModelIDSet = strModelIDSet.Substring(0, strModelIDSet.Length - 1)
		'        '            End If

		'        '            strSQL = "UPDATE cogs.ModelFamilies" & Environment.NewLine
		'        '            strSQL &= String.Format("SET ModelIDSet = '{0}'", strModelIDSet) & Environment.NewLine
		'        '            strSQL &= String.Format("WHERE ModelFamiliesID = {0}", iModelFamiliesID)

		'        '            SetData(strSQL)
		'        '        End If
		'        '    End If
		'        'Else 'Add model to selected model family. If it already exists in another one, prompt user for change. If they're the same, don't update.
		'        '    strSQL = "SELECT COUNT(*)" & Environment.NewLine
		'        '    strSQL &= "FROM cogs.ModelFamilies" & Environment.NewLine
		'        '    strSQL &= String.Format("WHERE FIND_IN_SET('{0}', ModelIDSet) > 0", iModelID)

		'        '    dt = GetDataTable(strSQL)
		'        '    iCount = dt.Rows(0)(0)

		'        '    If iCount > 0 Then
		'        '        strSQL = "SELECT ModelFamiliesID, Name" & Environment.NewLine
		'        '        strSQL &= "FROM cogs.ModelFamilies" & Environment.NewLine
		'        '        strSQL &= String.Format("WHERE FIND_IN_SET('{0}', ModelIDSet) > 0", iModelID)

		'        '        dt = GetDataTable(strSQL)

		'        '        iModelFamiliesID = dt.Rows(0)(0)
		'        '    End If

		'        '    If iModelFamiliesID > 0 And iSelectedModelFamiliesID <> iModelFamiliesID Then
		'        '        bReassignedID = True

		'        '        If MsgBox(String.Format("This model is already assigned to model family {0}.  Would you like to reassign it to the new model family you selected?", dt.Rows(0)(1)), MsgBoxStyle.YesNo Or MsgBoxStyle.Question Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then bUpdateID = False
		'        '    ElseIf iSelectedModelFamiliesID = iModelFamiliesID Then
		'        '        bUpdateID = False
		'        '    End If

		'        '    If bUpdateID Then
		'        '        strSQL = "SELECT CAST(ModelIDSet AS CHAR)" & Environment.NewLine
		'        '        strSQL &= "FROM cogs.ModelFamilies" & Environment.NewLine
		'        '        strSQL &= String.Format("WHERE ModelFamiliesID = {0} ", iSelectedModelFamiliesID) & Environment.NewLine

		'        '        dt = GetDataTable(strSQL)

		'        '        strModelIDSet = Convert.ToString(dt.Rows(0)(0))
		'        '        strModelIDSet &= IIf(strModelIDSet.Length > 0, ",", String.Empty) & iModelID

		'        '        strSQL = "UPDATE cogs.ModelFamilies" & Environment.NewLine
		'        '        strSQL &= String.Format("SET ModelIDSet = '{0}'", strModelIDSet) & Environment.NewLine
		'        '        strSQL &= String.Format("WHERE ModelFamiliesID = {0}", iSelectedModelFamiliesID)

		'        '        SetData(strSQL)

		'        '        If bReassignedID And iModelFamiliesID > 0 Then
		'        '            strSQL = "SELECT CAST(ModelIDSet AS CHAR)" & Environment.NewLine
		'        '            strSQL &= "FROM cogs.ModelFamilies" & Environment.NewLine
		'        '            strSQL &= String.Format("WHERE ModelFamiliesID = {0} ", iModelFamiliesID) & Environment.NewLine

		'        '            dt = GetDataTable(strSQL)

		'        '            strModelIDSet = Convert.ToString(dt.Rows(0)(0))

		'        '            If strModelIDSet.Length > 0 Then
		'        '                strModelIDSet = strModelIDSet.Replace(iModelID.ToString, String.Empty)

		'        '                If strModelIDSet.Length > 0 Then
		'        '                    strModelIDSet = strModelIDSet.Replace(",,", ",")

		'        '                    If strModelIDSet.Substring(0, 1).Equals(",") Then strModelIDSet = strModelIDSet.Substring(1)

		'        '                    If strModelIDSet.Substring(strModelIDSet.Length - 1, 1).Equals(",") Then strModelIDSet = strModelIDSet.Substring(0, strModelIDSet.Length - 1)
		'        '                End If

		'        '                strSQL = "UPDATE cogs.ModelFamilies" & Environment.NewLine
		'        '                strSQL &= String.Format("SET ModelIDSet = '{0}'", strModelIDSet) & Environment.NewLine
		'        '                strSQL &= String.Format("WHERE ModelFamiliesID = {0}", iModelFamiliesID)

		'        '                SetData(strSQL)
		'        '            End If
		'        '        End If
		'        '    End If
		'        'End If

		'    Catch ex As Exception
		'        Throw ex
		'    Finally
		'        If Not IsNothing(dt) Then
		'            dt.Dispose()
		'            dt = Nothing
		'        End If
		'    End Try
		'End Sub

		Public Shared Function GetModelFamily(ByVal iModelID As Integer) As String
			Dim dt As DataTable
			Dim strSQL As String
			Dim iCount As Integer
			Dim strModelFamily As String = "Not Selected"

			Try
				strSQL = "SELECT COUNT(*)" & Environment.NewLine
				strSQL &= "FROM cogs.ModelFamilies" & Environment.NewLine
				strSQL &= String.Format("WHERE FIND_IN_SET('{0}', ModelIDSet) > 0", iModelID)

				dt = GetDataTable(strSQL)
				iCount = dt.Rows(0)(0)

				If iCount > 0 Then
					strSQL = "SELECT Name" & Environment.NewLine
					strSQL &= "FROM cogs.ModelFamilies" & Environment.NewLine
					strSQL &= String.Format("WHERE FIND_IN_SET('{0}', ModelIDSet) > 0", iModelID)

					dt = GetDataTable(strSQL)

					strModelFamily = dt.Rows(0)(0)
				End If

				Return strModelFamily
			Catch ex As Exception
				Throw ex
			Finally
				If Not IsNothing(dt) Then
					dt.Dispose()
					dt = Nothing
				End If
			End Try
		End Function

		Public Shared Function LoadModelFamilies() As DataTable
			Dim strSQL As String

			Try
				strSQL = "SELECT ModelFamiliesID, Name AS 'Family'" & Environment.NewLine
				strSQL &= "FROM cogs.ModelFamilies " & Environment.NewLine
				strSQL &= "ORDER BY Name"

				Return GetDataTable(strSQL)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Public Shared Function LoadModelFamiliesMap() As DataTable
			Dim strSQL As String

			Try
				strSQL = "SELECT A.ModelFamiliesID, Name AS 'Family', C.Cust_Name1 as 'Customer'" & Environment.NewLine
				'strSQL &= ", IF(B.ScrapUponRec = 1, 'Yes', 'No') as 'Scrap?' " & Environment.NewLine
				'strSQL &= ", IF(B.CollectDateCodeInternal = 1, 'Yes', 'No') as 'Date Code(Internal)?'" & Environment.NewLine
				'strSQL &= ", IF(B.CollectDateCodeExternal = 1, 'Yes', 'No') as 'Date Code(External)?'" & Environment.NewLine
				'strSQL &= ", IF(B.AudioTest = 1, 'Yes', 'No') as 'Audio Test?'" & Environment.NewLine
				strSQL &= ", B.LastUpdateDT as 'Updated Date'" & Environment.NewLine
				strSQL &= ", IF(User_Fullname is null, '', User_Fullname ) as 'Updated By' " & Environment.NewLine
				strSQL &= "FROM cogs.ModelFamilies A " & Environment.NewLine
				strSQL &= "INNER JOIN cogs.modelfamilies_Cust_map B ON A.ModelFamiliesID = B.ModelFamiliesID " & Environment.NewLine
				strSQL &= "INNER JOIN production.tcustomer C ON B.Cust_ID = C.Cust_ID " & Environment.NewLine
				strSQL &= "INNER JOIN security.tusers D ON B.LastUpdateUserID = D.User_ID " & Environment.NewLine
				strSQL &= "ORDER BY Name"

				Return GetDataTable(strSQL)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Public Shared Function GetModelIDSetForModelFamily(ByVal iModelFamilyID As Integer) As DataTable
			Dim strSQL As String

			Try
				strSQL = "SELECT CAST(ModelIDSet AS CHAR)" & Environment.NewLine
				strSQL &= "FROM cogs.ModelFamilies" & Environment.NewLine
				strSQL &= String.Format("WHERE ModelFamiliesID = {0}", iModelFamilyID)

				Return GetDataTable(strSQL)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Public Shared Sub DeleteModelFamily(ByVal iModelFamilyID As Integer)
			Dim strSQL As String

			Try
				strSQL = "DELETE FROM cogs.ModelFamilies" & Environment.NewLine
				strSQL &= String.Format("WHERE ModelFamiliesID = {0}", iModelFamilyID)

				SetData(strSQL)
			Catch ex As Exception
				Throw ex
			End Try
		End Sub

		Public Shared Function CheckExisitingModelFamilies(ByVal strModelFamily As String) As DataTable
			Dim strSQL As String

			Try
				strSQL = "SELECT * FROM cogs.ModelFamilies" & Environment.NewLine
				strSQL &= String.Format("WHERE Name = '{0}'", strModelFamily)

				Return GetDataTable(strSQL)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Public Shared Sub AddNewModelFamily(ByVal strModelFamily As String, ByVal cust_id As Integer, ByVal iUserID As Integer)
			Dim strSQL, strToday As String
			Try
				strToday = Generic.GetMySqlDateTime("%Y-%m-%d")
				strSQL = "INSERT INTO cogs.ModelFamilies (Name, customerid, LastUpdateDT, LastUpdateUserID )" & Environment.NewLine
				strSQL &= String.Format("VALUES ('{0}', {1}, '{2}', {3} )", strModelFamily, cust_id, strToday, iUserID)
				SetData(strSQL)
			Catch ex As Exception
				Throw ex
			End Try
		End Sub

		Public Shared Sub UpdateModelFamily(ByVal strOldModelFamily As String, ByVal strNewModelFamily As String, ByVal iUserID As Integer)
			Dim strSQL, strToday As String

			Try
				strToday = Generic.GetMySqlDateTime("%Y-%m-%d")
				strSQL = "UPDATE cogs.ModelFamilies" & Environment.NewLine
				strSQL &= String.Format("SET Name = '{0}', LastUpdateDT = '{1}', LastUpdateUserID = {2} ", strNewModelFamily, strToday, iUserID) & Environment.NewLine
				strSQL &= String.Format("WHERE Name = '{0}'", strOldModelFamily)

				SetData(strSQL)
			Catch ex As Exception
				Throw ex
			End Try
		End Sub

		Public Shared Function GetModelFamilyCustMap(ByVal strModelFamilyName As String, ByVal iCustID As Integer) As DataTable
			Dim strSQL As String

			Try
				strSQL = "SELECT A.* FROM cogs.modelfamilies_Cust_map A " & Environment.NewLine
				strSQL &= "INNER JOIN cogs.ModelFamilies B ON A.ModelFamiliesID = B.ModelFamiliesID " & Environment.NewLine
				strSQL &= "WHERE B.Name = '" & strModelFamilyName & "' AND A.Cust_ID = " & iCustID

				Return GetDataTable(strSQL)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Public Shared Sub SaveModelFamilyCustMap(ByVal iCustID As Integer, ByVal iModelFamilyID As Integer, _
				   ByVal iScrapUponRec As Integer, ByVal iCollectDateCodeInternal As Integer, ByVal iCollectDateCodeExternal As Integer, _
				   ByVal iUserID As Integer, ByVal iNeedAudioTest As Integer)
			Dim strSQL, strToday As String
			Dim dt As DataTable

			Try
				strToday = Generic.GetMySqlDateTime("%Y-%m-%d %H:%m:%s")
				strSQL = "SELECT * FROM cogs.modelfamilies_Cust_map WHERE Cust_ID = " & iCustID & " AND ModelFamiliesID = " & iModelFamilyID & Environment.NewLine
				dt = GetDataTable(strSQL)

				If dt.Rows.Count > 0 Then				'UPDATE
					If dt.Rows(0)("ScrapUponRec").ToString.Trim = iScrapUponRec.ToString AndAlso _
					   dt.Rows(0)("CollectDateCodeInternal").ToString.Trim = iCollectDateCodeInternal.ToString AndAlso _
					   dt.Rows(0)("CollectDateCodeExternal").ToString.Trim = iCollectDateCodeExternal.ToString AndAlso _
					   dt.Rows(0)("AudioTest").ToString.Trim = iNeedAudioTest.ToString Then
						'NO UPDATE NEEEDED
					Else
						strSQL = "UPDATE cogs.modelfamilies_Cust_map " & Environment.NewLine
						strSQL &= " SET ScrapUponRec = " & iScrapUponRec & ", CollectDateCodeInternal = " & iCollectDateCodeInternal & Environment.NewLine
						strSQL &= ", CollectDateCodeExternal =  " & iCollectDateCodeExternal & " , AudioTest = " & iNeedAudioTest & Environment.NewLine
						strSQL &= ", LastUpdateDT = '" & strToday & "', LastUpdateUserID = " & iUserID & Environment.NewLine
						strSQL &= " WHERE Cust_ID = " & iCustID & " AND ModelFamiliesID = " & iModelFamilyID
						SetData(strSQL)

						'Record history
						strSQL = "INSERT INTO cogs.modelfamilies_Cust_map_hist ( " & Environment.NewLine
						strSQL &= "ModelFamiliesID, Cust_ID , ScrapUponRec, CollectDateCodeInternal, CollectDateCodeExternal, AudioTest, LastUpdateDT, LastUpdateUserID " & Environment.NewLine
						strSQL &= " ) VALUES ( " & Environment.NewLine
						strSQL &= iModelFamilyID & ", " & iCustID & ", " & iScrapUponRec & ", " & iCollectDateCodeInternal & ", " & iCollectDateCodeExternal & "," & iNeedAudioTest & Environment.NewLine
						strSQL &= ", '" & strToday & "', " & iUserID & Environment.NewLine
						strSQL &= ") "
						SetData(strSQL)
					End If
				Else				'INSERT
					strSQL = "INSERT INTO cogs.modelfamilies_Cust_map ( " & Environment.NewLine
					strSQL &= " ModelFamiliesID, Cust_ID, ScrapUponRec, CollectDateCodeInternal, CollectDateCodeExternal, AudioTest, LastUpdateDT, LastUpdateUserID " & Environment.NewLine
					strSQL &= ") VALUES ( " & Environment.NewLine
					strSQL &= iModelFamilyID & ", " & iCustID & ", " & iScrapUponRec & ", " & iCollectDateCodeInternal & ", " & iCollectDateCodeExternal & "," & iNeedAudioTest & Environment.NewLine
					strSQL &= ", '" & strToday & "', " & iUserID & Environment.NewLine
					strSQL &= ") "
					SetData(strSQL)

					'Record history
					strSQL = "INSERT INTO cogs.modelfamilies_Cust_map_hist ( " & Environment.NewLine
					strSQL &= "ModelFamiliesID, Cust_ID , ScrapUponRec, CollectDateCodeInternal, CollectDateCodeExternal, AudioTest, LastUpdateDT, LastUpdateUserID " & Environment.NewLine
					strSQL &= " ) VALUES ( " & Environment.NewLine
					strSQL &= iModelFamilyID & ", " & iCustID & ", " & iScrapUponRec & ", " & iCollectDateCodeInternal & ", " & iCollectDateCodeExternal & "," & iNeedAudioTest & Environment.NewLine
					strSQL &= ", '" & strToday & "', " & iUserID & Environment.NewLine
					strSQL &= ") "
					SetData(strSQL)
				End If

			Catch ex As Exception
				Throw ex
			End Try
		End Sub
#End Region

#Region "Model Criteria"

		'*****************************************************************************
		Public Function GetModelCriteriaList(ByVal iCustID As Integer, _
				  Optional ByVal iManufID As Integer = 0, _
				  Optional ByVal iProdID As Integer = 0, _
				  Optional ByVal iModelID As Integer = 0) As DataTable

			Dim strSql As String = ""

			Try
				strSql = "SELECT A.ModelCriteria_ID, A.Model_ID, B.Prod_ID, B.Manuf_ID, B.Model_Desc as Model " & Environment.NewLine
				strSql &= ", C.Manuf_Desc as 'Manuf', D.Prod_desc As 'Product' " & Environment.NewLine
				strSql &= ", IF( G.Name is null, '', G.Name) As 'Model Family' " & Environment.NewLine
				strSql &= ", if( A.EndOfLife = 0, 'No', 'Yes') as 'EOL?'" & Environment.NewLine
				strSql &= ", if( A.Recycle = 0 , 'No', 'Yes') as 'Recycle?'" & Environment.NewLine
				strSql &= ", if( E.User_fullname is null, '', E.User_Fullname) as 'Update By'" & Environment.NewLine
				strSql &= ", if( A.UpdateDate is null, '', Date_Format(A.UpdateDate, '%m/%d/%Y')) as 'Update Date'" & Environment.NewLine
				strSql &= "FROM tmodelcriteria A INNER JOIN tmodel B ON A.Model_ID = B.Model_ID" & Environment.NewLine
				strSql &= "INNER JOIN lmanuf C ON B.Manuf_ID = C.Manuf_ID" & Environment.NewLine
				strSql &= "INNER JOIN lproduct D ON B.Prod_ID = D.Prod_ID" & Environment.NewLine
				strSql &= "LEFT OUTER JOIN security.tusers E ON A.UpdateByUsrID = E.User_ID" & Environment.NewLine
				strSql &= "LEFT OUTER JOIN tcustmodel_pssmodel_map F ON A.Model_ID = F.Model_ID AND A.Cust_ID = F.Cust_ID" & Environment.NewLine
				strSql &= "LEFT OUTER JOIN cogs.modelfamilies G ON F.modelfamiliesid = G.modelfamiliesid" & Environment.NewLine
				strSql &= "WHERE A.Cust_ID = " & iCustID & Environment.NewLine
				If iManufID > 0 Then strSql &= "AND B.Manuf_ID = " & iManufID & Environment.NewLine
				If iProdID > 0 Then strSql &= "AND B.Prod_ID = " & iProdID & Environment.NewLine
				If iModelID > 0 Then strSql &= " AND A.Model_ID = " & iModelID & Environment.NewLine
				strSql &= "ORDER BY B.Model_Desc;"
				Return Me._objDataProc.GetDataTable(strSql)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'*****************************************************************************
		Public Function GetMissingModelCriteria(ByVal iCustID As Integer, Optional ByVal iManufID As Integer = 0, _
				  Optional ByVal iProdID As Integer = 0) As DataTable

			Dim strSql As String = ""

			Try
				strSql = "SELECT A.Model_ID, A.Model_Desc as Model, A.Prod_ID, A.Manuf_ID" & Environment.NewLine
				strSql &= ", B.Manuf_Desc as 'Manuf', C.Prod_desc As 'Product' " & Environment.NewLine
				strSql &= ", if(F.Name is null, '', F.Name) as 'Model Family'  " & Environment.NewLine
				strSql &= "FROM tmodel A " & Environment.NewLine
				strSql &= "INNER JOIN lmanuf B ON A.Manuf_ID = B.Manuf_ID" & Environment.NewLine
				strSql &= "INNER JOIN lproduct C ON A.Prod_ID = C.Prod_ID" & Environment.NewLine
				strSql &= "LEFT OUTER JOIN tmodelcriteria D ON A.Model_ID = D.Model_ID " & " AND D.Cust_ID = " & iCustID & Environment.NewLine
				strSql &= "LEFT OUTER JOIN tcustmodel_pssmodel_map E ON A.Model_ID = E.Model_ID" & " AND E.Cust_ID = " & iCustID & Environment.NewLine
				strSql &= "LEFT OUTER JOIN cogs.modelfamilies F ON E.modelfamiliesid = F.modelfamiliesid " & Environment.NewLine
				strSql &= "WHERE D.Model_ID is null " & Environment.NewLine
				If iManufID > 0 Then strSql &= "AND A.Manuf_ID = " & iManufID & Environment.NewLine
				If iProdID > 0 Then strSql &= "AND A.Prod_ID = " & iProdID & Environment.NewLine
				strSql &= "ORDER BY A.Model_Desc;"
				Return Me._objDataProc.GetDataTable(strSql)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'*****************************************************************************
		Public Function AddModelcriteria(ByVal iCustID As Integer, ByVal iModelID As Integer, _
				 ByVal iEOL As Integer, ByVal iRecycle As Integer, _
				 ByVal iUserID As Integer) As Integer
			Dim strSql As String = ""
			Dim dt As DataTable

			Try
				strSql = "SELECT * FROM tmodelcriteria WHERE Cust_ID = " & iCustID & " AND Model_ID = " & iModelID
				dt = Me._objDataProc.GetDataTable(strSql)

				If dt.Rows.Count > 0 Then
					strSql = "UPDATE tmodelcriteria " & Environment.NewLine
					strSql &= "SET EndOfLife = " & iEOL & ", Recycle = " & iRecycle & ", UpdateByUsrID = " & iUserID & ", UpdateDate = now() " & Environment.NewLine
					strSql &= "WHERE ModelCriteria_ID = " & dt.Rows(0)("ModelCriteria_ID") & Environment.NewLine
				Else
					strSql = "INSERT INTO tmodelcriteria ( " & Environment.NewLine
					strSql &= " Cust_ID, Model_ID, EndOfLife, Recycle, UpdateByUsrID, UpdateDate " & Environment.NewLine
					strSql &= ") VALUES ( " & Environment.NewLine
					strSql &= iCustID & ", " & iModelID & Environment.NewLine
					strSql &= ", " & iEOL & ", " & iRecycle & Environment.NewLine
					strSql &= ", " & iUserID & ", now() " & Environment.NewLine
					strSql &= " ) "
				End If

				Return Me._objDataProc.ExecuteNonQuery(strSql)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'*****************************************************************************
		Public Function SetTmodelcriteriaEndOfLife(ByVal strModelCriteriaIDs As String, _
				   ByVal iEOL As Integer, ByVal iUserID As Integer) As Integer
			Dim strSql As String = ""

			Try
				strSql = "UPDATE tmodelcriteria " & Environment.NewLine
				strSql &= "SET EndOfLife = " & iEOL & ", UpdateByUsrID = " & iUserID & ", UpdateDate = now() " & Environment.NewLine
				strSql &= "WHERE ModelCriteria_ID IN ( " & strModelCriteriaIDs & " ) " & Environment.NewLine
				Return Me._objDataProc.ExecuteNonQuery(strSql)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'*****************************************************************************
		Public Function SetTmodelcriteriaRecycle(ByVal strModelCriteriaIDs As String, _
				   ByVal iRecycle As Integer, ByVal iUserID As Integer) As Integer
			Dim strSql As String = ""

			Try
				strSql = "UPDATE tmodelcriteria " & Environment.NewLine
				strSql &= "SET Recycle = " & iRecycle & ", UpdateByUsrID = " & iUserID & ", UpdateDate = now() " & Environment.NewLine
				strSql &= "WHERE ModelCriteria_ID IN ( " & strModelCriteriaIDs & " ) " & Environment.NewLine
				Return Me._objDataProc.ExecuteNonQuery(strSql)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'*****************************************************************************
		Public Function GetModelCriteria(ByVal iCustID As Integer, ByVal iModelID As Integer) As DataTable
			Dim strSql As String = ""

			Try
				strSql = "SELECT * FROM tmodelcriteria " & Environment.NewLine
				strSql &= "WHERE Model_ID = " & iModelID & " AND Cust_ID = " & iCustID & Environment.NewLine
				Return Me._objDataProc.GetDataTable(strSql)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'*****************************************************************************

#End Region

#Region "Execute Query For Shared Function"
		Private Shared Function doapps(ByVal [string] As String) As String
			Return Replace([string], "'", "''")
		End Function

		Private Shared Function GetDataTable(ByVal [string] As String) As DataTable
			Dim objDataProc As DBQuery.DataProc

			Try
				objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
				Return objDataProc.GetDataTable([string])

			Catch ex As Exception
				Throw ex
			Finally
				objDataProc = Nothing
			End Try
		End Function

		Private Shared Sub SetData(ByVal [string] As String)
			Dim objDataProc As DBQuery.DataProc

			Try
				objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
				objDataProc.ExecuteNonQuery([string])
			Catch ex As Exception
				Throw ex
			Finally
				objDataProc = Nothing
			End Try
		End Sub
#End Region

#Region "Customer Model Status"

		'*********************************************************************************************************************
		Public Function GetCustClassificationList(ByVal booAddSelectRow As Boolean, ByVal booActiveOnly As Boolean, ByVal strMCodeIDs As String) As DataTable
			Dim strSql As String = ""
			Dim dt As DataTable

			Try
				strSql = "SELECT A.DCode_ID, A.DCode_LDesc as 'Classification', A.Dcode_Inactive" & Environment.NewLine
				strSql &= ", if (A.Dcode_Inactive = 0, 'Yes', 'No') as 'Active?' " & Environment.NewLine
				strSql &= ", B.User_Fullname as 'User', A.UpdatedDate as 'Updated Date', A.MCode_ID" & Environment.NewLine
				strSql &= "FROM lcodesdetail A INNER JOIN security.tusers B ON A.User_ID = B.User_ID " & Environment.NewLine
				strSql &= "WHERE A.MCode_ID IN ( " & strMCodeIDs & " )" & Environment.NewLine
				If booActiveOnly Then strSql &= "AND Dcode_Inactive = 0" & Environment.NewLine
				strSql &= "ORDER BY 'Classification';"
				dt = Me._objDataProc.GetDataTable(strSql)
				If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--Select--"}, True)
				Return dt
			Catch ex As Exception
				Throw ex
			Finally
				Generic.DisposeDT(dt)
			End Try
		End Function

		'*********************************************************************************************************************
		Public Function GetMRPModelStatus(ByVal booAddSelectRow As Boolean, ByVal booActiveOnly As Boolean) As DataTable
			Dim strSql As String = ""
			Dim dt As DataTable

			Try
				strSql = "SELECT A.lassign_id as ID, A.assign_text as 'Status'" & Environment.NewLine
				strSql &= ", if(A.Active = 1, 'Yes', 'No') as 'Active?', A.Active" & Environment.NewLine
				strSql &= ", User_fullname as 'User', A.UpdatedDate as 'Updated Date'" & Environment.NewLine
                strSql &= " FROM cogs.ldevicestatus A INNER JOIN security.tusers B ON A.User_ID = B.User_ID" & Environment.NewLine
                If booActiveOnly Then strSql &= " WHERE Active = 1" & Environment.NewLine
                strSql &= " ORDER BY 'Status'"
                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--Select--"}, True)
                Return dt
            Catch ex As Exception
				Throw ex
			Finally
				Generic.DisposeDT(dt)
			End Try
		End Function

		'*********************************************************************************************************************
		Public Function GetModelClassificationJournal(ByVal iCustID As Integer, ByVal booActiveOnly As Boolean, Optional ByVal iModelID As Integer = 0) As DataTable
			Dim strSql As String = ""
            Dim dt, dt2 As DataTable
            Dim FilteredRows As DataRow()
            ' Dim iMaxCMCID As Integer = 0
            Dim arrModels As New ArrayList()
            Dim arrMaxCMCIDs As New ArrayList()
            Dim row As DataRow
            Dim i As Integer

			Try
                'strSql = "SELECT D.Model_Desc as Model, A.CMC_ID, B.DCode_LDesc as 'Cust Classification'" & Environment.NewLine
                'strSql &= ", A.EffectiveDate as 'Effective Date'" & Environment.NewLine
                'strSql &= ", C.assign_text as 'PSS Status', A.UpdatedDate as 'Updated Date', E.User_FullName as 'User'" & Environment.NewLine
                'strSql &= ", A.Model_ID, A.Cust_DCode_ID, A.MRP_Status_ID " & Environment.NewLine
                'strSql &= ", D.Has_BC "
                'strSql &= "FROM custmodelclassification A " & Environment.NewLine
                'strSql &= "INNER JOIN lcodesdetail B ON A.Cust_DCode_ID = B.DCode_ID" & Environment.NewLine
                'strSql &= "INNER JOIN cogs.ldevicestatus C ON A.MRP_Status_ID = C.lassign_id" & Environment.NewLine
                'strSql &= "INNER JOIN tmodel D ON A.Model_ID = D.Model_ID" & Environment.NewLine
                'strSql &= "INNER JOIN security.tusers E ON A.User_ID = E.User_ID" & Environment.NewLine
                'strSql &= "WHERE A.Cust_ID = " & iCustID & Environment.NewLine

                strSql = "SELECT D.Model_Desc as Model, A.CMC_ID, B.DCode_LDesc as 'Cust Classification'" & Environment.NewLine
                strSql &= " , A.EffectiveDate as 'Effective Date'" & Environment.NewLine
                strSql &= " , G.Assign_Text as 'PSS Status', A.UpdatedDate as 'Updated Date', E.User_FullName as 'User'" & Environment.NewLine
                strSql &= " , A.Model_ID, A.Cust_DCode_ID,F.Status_ID as 'MRP_Status_ID'" & Environment.NewLine
                strSql &= " , D.Has_BC" & Environment.NewLine
                strSql &= " FROM custmodelclassification A" & Environment.NewLine
                strSql &= " INNER JOIN lcodesdetail B ON A.Cust_DCode_ID = B.DCode_ID" & Environment.NewLine
                strSql &= " INNER JOIN tmodel D ON A.Model_ID = D.Model_ID" & Environment.NewLine
                strSql &= " INNER JOIN security.tusers E ON A.User_ID = E.User_ID" & Environment.NewLine
                strSql &= " LEFT JOIN cogs.tmodel_properties F ON A.Model_ID = F.Model_ID" & Environment.NewLine
                strSql &= " LEFT JOIN cogs.ldevicestatus G ON F.Status_ID=G.lassign_id" & Environment.NewLine
                strSql &= " WHERE A.Cust_ID = " & iCustID & Environment.NewLine

                If booActiveOnly Then strSql &= " AND A.Active = 1" & Environment.NewLine
                If iModelID > 0 Then strSql &= " AND A.Model_ID = " & iModelID & Environment.NewLine
                strSql &= " ORDER BY D.Model_Desc asc, CMC_ID desc ;"

                dt = Me._objDataProc.GetDataTable(strSql)

                For Each row In dt.Rows 'Find unique model_IDs
                    If Not arrModels.Contains(row("Model_ID")) Then
                        arrModels.Add(row("Model_ID")) 'unique model ID
                    End If
                Next
                For i = 0 To arrModels.Count - 1 'Find max CMC_ID for each model, i.e., most current effective date
                    FilteredRows = dt.Select("Model_ID = " & arrModels(i))
                    If FilteredRows.Length > 0 Then
                        arrMaxCMCIDs.Add(FilteredRows(0).Item(1))
                        Debug.Write(FilteredRows(0).Item(1))
                    End If
                Next

                For Each row In dt.Rows 'Remove MRP_Status if not current CMC_ID (most current effective date)
                    If Not arrMaxCMCIDs.Contains(row("CMC_ID")) Then
                        row.EndEdit()
                        row("PSS Status") = ""
                        row("MRP_Status_ID") = DBNull.Value
                        row.AcceptChanges()
                        'Else
                        '    Debug.Write("2: " & row("CMC_ID"))
                    End If
                Next

                Return dt

            Catch ex As Exception
				Throw ex
			End Try
		End Function

		'*********************************************************************************************************************
		Public Function SaveCustModelClassification( _
		  ByVal iCustID As Integer, _
		  ByVal iModelID As Integer, _
		  ByVal iCustDCodeID As Integer, _
		  ByVal iUserID As Integer, _
		  ByVal strEffectedDate As String, _
		  ByRef strErrMsg As String) As Integer
			Dim strSql As String = ""
			Dim dt As DataTable
			Dim i As Integer
			Dim R1, drTransHistOnEffDate As DataRow
			Dim dteToday, dteHighestEffectiveDate As DateTime

			Try
				drTransHistOnEffDate = Nothing
				dteToday = Convert.ToDateTime(Generic.GetMySqlDateTime("%Y-%m-%d"))
				dteHighestEffectiveDate = New DateTime(1900, 1, 1)

				strSql = "SELECT * FROM custmodelclassification " & Environment.NewLine
				strSql &= "WHERE Cust_ID = " & iCustID & " AND Model_ID = " & iModelID & Environment.NewLine
				strSql &= "ORDER BY CMC_ID DESC " & Environment.NewLine
				dt = Me._objDataProc.GetDataTable(strSql)

				If dt.Rows.Count > 0 Then
					'Find records have same effective date
					For Each R1 In dt.Rows
						If Convert.ToDateTime(R1("EffectiveDate")).ToString("yyyy-MM-dd") = strEffectedDate Then drTransHistOnEffDate = R1
						If Convert.ToDateTime(R1("EffectiveDate")) > dteHighestEffectiveDate Then dteHighestEffectiveDate = Convert.ToDateTime(R1("EffectiveDate"))
					Next R1

					If Convert.ToDateTime(dt.Rows(0)("EffectiveDate")).ToString("yyyy-MM-dd") = strEffectedDate AndAlso iCustDCodeID.ToString = dt.Rows(0)("Cust_DCode_ID").ToString Then
						strErrMsg = "Data is the same. No update occurs."
					ElseIf IsNothing(drTransHistOnEffDate) AndAlso dteHighestEffectiveDate > Convert.ToDateTime(strEffectedDate) Then
						strErrMsg = "Not allowed to add or update any record has effective date prior to " & dteHighestEffectiveDate.ToString("MM/dd/yyy") & "."
						'ElseIf Convert.ToDateTime(dteToday) >= Convert.ToDateTime(strEffectedDate) Then
						'    strErrMsg = "Not allowed to add or update any record has effective date prior to " & dteToday.ToString("MM/dd/yyy") & "."
					ElseIf Not IsNothing(drTransHistOnEffDate) AndAlso iCustDCodeID = Convert.ToInt32(drTransHistOnEffDate("Cust_Dcode_ID")) Then
						strErrMsg = "Data is the same. No update occurs."
					ElseIf Not IsNothing(drTransHistOnEffDate) AndAlso iCustDCodeID = Convert.ToInt32(drTransHistOnEffDate("Cust_Dcode_ID")) Then
						strSql = "UPDATE custmodelclassification SET UpdatedDate = now(), User_ID = " & iUserID & Environment.NewLine
						strSql &= " WHERE CMC_ID = " & drTransHistOnEffDate("CMC_ID").ToString & Environment.NewLine
						i = Me._objDataProc.ExecuteNonQuery(strSql)
					ElseIf Not IsNothing(drTransHistOnEffDate) AndAlso iCustDCodeID <> Convert.ToInt32(drTransHistOnEffDate("Cust_Dcode_ID")) Then
						strSql = "UPDATE custmodelclassification SET Cust_Dcode_ID = " & iCustDCodeID & ", UpdatedDate = now(), User_ID = " & iUserID & Environment.NewLine
						strSql &= " WHERE CMC_ID = " & drTransHistOnEffDate("CMC_ID").ToString & Environment.NewLine
						i = Me._objDataProc.ExecuteNonQuery(strSql)
					ElseIf Convert.ToDateTime(dt.Rows(0)("EffectiveDate")).ToString("yyyy-MM-dd") = strEffectedDate AndAlso iCustDCodeID.ToString = dt.Rows(0)("Cust_DCode_ID").ToString Then
						strSql = "UPDATE custmodelclassification SET UpdatedDate = now(), User_ID = " & iUserID & Environment.NewLine
						strSql &= " WHERE CMC_ID = " & dt.Rows(0)("CMC_ID").ToString & Environment.NewLine
						i = Me._objDataProc.ExecuteNonQuery(strSql)
					Else
						strSql = "INSERT INTO custmodelclassification ( " & Environment.NewLine
                        strSql &= " Cust_Dcode_ID, EffectiveDate, Cust_ID, Model_ID, UpdatedDate, User_ID " & Environment.NewLine
						strSql &= ") VALUES ( " & Environment.NewLine
						strSql &= iCustDCodeID & ", '" & strEffectedDate & "', " & iCustID & ", " & iModelID & ", now(), " & iUserID & Environment.NewLine
						strSql &= ")" & Environment.NewLine
						i = Me._objDataProc.ExecuteNonQuery(strSql)
					End If
				Else
					strSql = "INSERT INTO custmodelclassification ( " & Environment.NewLine
                    strSql &= " Cust_Dcode_ID, EffectiveDate, Cust_ID, Model_ID, UpdatedDate, User_ID " & Environment.NewLine
					strSql &= ") VALUES ( " & Environment.NewLine
					strSql &= iCustDCodeID & ", '" & strEffectedDate & "', " & iCustID & ", " & iModelID & ", now(), " & iUserID & Environment.NewLine
					strSql &= ")" & Environment.NewLine
					i = Me._objDataProc.ExecuteNonQuery(strSql)
				End If

				Return i
			Catch ex As Exception
				Throw ex
			Finally
				Generic.DisposeDT(dt)
			End Try
		End Function

		'*********************************************************************************************************************
		Public Function SaveCustClassification(ByVal iMCodeID As Integer, ByVal strClassification As String, ByVal strNewClassification As String, _
		   ByVal iInactive As Integer, ByVal iUserID As Integer, ByRef strMsg As String) As Integer
			Dim strSql As String = ""
			Dim dt, dt2 As DataTable
			Dim i As Integer = 0
			Dim objQC As QC

			Try
				strSql = "SELECT * FROM lcodesdetail WHERE MCode_ID = " & iMCodeID & " AND DCode_LDesc = '" & strClassification & "'" & Environment.NewLine
				dt = Me._objDataProc.GetDataTable(strSql)

				If dt.Rows.Count > 1 Then
					strMsg = "Duplicate record for classification """ & strClassification & """."
				ElseIf dt.Rows.Count = 0 AndAlso strNewClassification.Trim.Length > 0 Then
					strMsg = "Classification """ & strClassification & """ does not exist. No update happen."
				ElseIf dt.Rows.Count = 0 AndAlso strNewClassification.Trim.Length = 0 Then
					'insert 
					objQC = New QC()
					i = objQC.InsertLcodesDetail("", strClassification, "", iMCodeID, 0, iInactive, iUserID)
				ElseIf dt.Rows.Count > 0 AndAlso strNewClassification.Trim.Length = 0 AndAlso CInt(dt.Rows(0)("Inactive")) = iInactive Then
					strMsg = "Input data is already existed."
				ElseIf dt.Rows.Count > 0 AndAlso strNewClassification.Trim.Length = 0 AndAlso CInt(dt.Rows(0)("Inactive")) <> iInactive Then
					i = objQC.UpdateLcodesDetail("", strClassification, "", iInactive, Convert.ToInt32(dt.Rows(0)("Dcode_ID")), iUserID)
				ElseIf dt.Rows.Count > 0 AndAlso strNewClassification.Trim.Length > 0 Then
					'Update everything
					strSql = "SELECT * FROM lcodesdetail WHERE MCode_ID = " & iMCodeID & " AND DCode_LDesc = '" & strNewClassification & "'" & Environment.NewLine
					dt2 = Me._objDataProc.GetDataTable(strSql)
					If dt2.Rows.Count > 0 Then
						strMsg = "New Classification """ & strNewClassification & """ existed. Please choose a different name."
					Else
						i = objQC.UpdateLcodesDetail("", strNewClassification, "", iInactive, Convert.ToInt32(dt.Rows(0)("Dcode_ID")), iUserID)
					End If
				Else
					'Should never happen.
					strMsg = "System could not define current action."
				End If

				Return i
			Catch ex As Exception
				Throw ex
			Finally
				Generic.DisposeDT(dt) : Generic.DisposeDT(dt2) : objQC = Nothing
			End Try
		End Function

		'*********************************************************************************************************************
		Public Function SavePssStatus(ByVal strStatus As String, ByVal strNewStatus As String, _
		   ByVal iActive As Integer, ByVal iUserID As Integer, ByRef strMsg As String) As Integer
			Dim strSql As String = ""
			Dim dt, dt2 As DataTable
			Dim i As Integer = 0

			Try
				strSql = "SELECT * FROM cogs.ldevicestatus WHERE assign_text = '" & strStatus & "'" & Environment.NewLine
				dt = Me._objDataProc.GetDataTable(strSql)

				If dt.Rows.Count > 1 Then
					strMsg = "Duplicate record for status """ & strStatus & """."
				ElseIf dt.Rows.Count = 0 AndAlso strNewStatus.Trim.Length > 0 Then
					strMsg = "Status """ & strStatus & """ does not exist. No update happen."
				ElseIf dt.Rows.Count = 0 AndAlso strNewStatus.Trim.Length = 0 Then
					'insert 
					strSql = "INSERT INTO cogs.ldevicestatus ( assign_text, Active, User_ID, UpdatedDate " & Environment.NewLine
					strSql &= ") VALUES ( " & Environment.NewLine
					strSql &= "'" & strStatus & "', " & iActive & ", " & iUserID & ", now() " & Environment.NewLine
					strSql &= " ) "
					i = Me._objDataProc.ExecuteNonQuery(strSql)
				ElseIf dt.Rows.Count > 0 AndAlso strNewStatus.Trim.Length = 0 AndAlso CInt(dt.Rows(0)("Active")) = iActive Then
					strMsg = "Input data is already existed."
				ElseIf dt.Rows.Count > 0 AndAlso strNewStatus.Trim.Length = 0 AndAlso CInt(dt.Rows(0)("Active")) <> iActive Then
					'Update Active flag
					strSql = "UPDATE cogs.ldevicestatus SET Active = " & iActive & ", User_ID = " & iUserID & ", UpdatedDate = now() " & Environment.NewLine
					strSql &= "WHERE lassign_id = " & dt.Rows(0)("lassign_id").ToString
					i = Me._objDataProc.ExecuteNonQuery(strSql)
				ElseIf dt.Rows.Count > 0 AndAlso strNewStatus.Trim.Length > 0 Then
					'Update everything
					strSql = "SELECT * FROM cogs.ldevicestatus WHERE assign_text = '" & strNewStatus & "'" & Environment.NewLine
					dt2 = Me._objDataProc.GetDataTable(strSql)
					If dt2.Rows.Count > 0 Then
						strMsg = "New status """ & strNewStatus & """ existed. Please choose a different name."
					Else
						strSql = "UPDATE cogs.ldevicestatus SET Active = " & iActive & ", User_ID = " & iUserID & ", UpdatedDate = now() " & Environment.NewLine
						strSql &= "WHERE lassign_id = " & dt.Rows(0)("lassign_id").ToString
						i = Me._objDataProc.ExecuteNonQuery(strSql)
					End If
				Else
					'Should never happen.
					strMsg = "System could not define current action."
				End If
				Return i
			Catch ex As Exception
				Throw ex
			Finally
				Generic.DisposeDT(dt) : Generic.DisposeDT(dt2)
			End Try
		End Function

		'*********************************************************************************************************************

#End Region

	End Class

End Namespace
