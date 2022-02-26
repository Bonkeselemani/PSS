
Namespace Buisness
    Public Class SyxWip

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

        '*********************************************************************************************************
        Public Function GetWipSubLocationMap(ByVal iCustID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT workstation as 'Location', WIL_SDesc as 'Wip Sub Location', WIL_LDesc as 'Location Description'" & Environment.NewLine
                strSql &= ", IF( WIL_Active = 1, 'Yes', 'No') as 'Active?' " & Environment.NewLine
                strSql &= ", wipsublocmap.* " & Environment.NewLine
                strSql &= " FROM wipsublocmap WHERE Cust_ID = " & iCustID & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************************************************
        Public Function GetCustName(ByVal iCustID As Integer) As String
            Dim strSql As String = ""

            Try
                strSql = "SELECT Concat(Cust_Name1, if(Cust_Name2 is null, '', concat(' ', Cust_Name2))) as CustName " & Environment.NewLine
                strSql &= " FROM tcustomer WHERE Cust_ID = " & iCustID & Environment.NewLine
                Return Me._objDataProc.GetSingletonString(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************************************************
        Public Function GetWIPLocation(ByVal iMenuCustID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT WRB_ID, WorkFlowStation  " & Environment.NewLine
                strSql &= "FROM wipreportbucket WHERE " & iMenuCustID & "Active = 1 AND HasSubLoc = 1" & Environment.NewLine
                strSql &= "ORDER BY WorkFlowStation"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************************************************
        Public Function GetTranferToWIPLocation(ByVal strCustIDs As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT wfp_id, wfp_ScreenName, wfp_FrStation, wfp_ToStation" & Environment.NewLine
                strSql &= ", IF(wipreportbucket.HasSubLoc is null, 0, wipreportbucket.HasSubLoc) as HasSubLoc " & Environment.NewLine
                strSql &= "FROM lworkflowprocess " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN wipreportbucket on lworkflowprocess.wfp_ToStation = wipreportbucket.WorkFlowStation AND " & strCustIDs & "Active = 1" & Environment.NewLine
                strSql &= "WHERE Cust_IDs IN ( " & strCustIDs & " ) " & Environment.NewLine
                strSql &= "AND wfp_screenName like 'To %' ORDER BY wfp_ScreenName" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************************************************
        Public Function GetWipMainAndSubLocMap(ByVal iCustID As Integer, ByVal strSubLoc As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT * " & Environment.NewLine
                strSql &= "FROM wipsublocmap " & Environment.NewLine
                strSql &= "WHERE Cust_ID = " & iCustID & Environment.NewLine
                strSql &= "AND WIL_SDesc = '" & strSubLoc & "'" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************************************************
        Public Function MapWipMainAndSubLoc(ByVal iCustID As Integer, ByVal strMainLoc As String, _
                                            ByVal strSubLoc As String, ByVal strSubLocDesc As String, ByVal iActive As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "INSERT INTO wipsublocmap ( WIL_SDesc, WIL_LDesc, WIL_Active, Cust_ID, Workstation  " & Environment.NewLine
                strSql &= ") VALUES ( " & Environment.NewLine
                strSql &= "'" & strSubLoc & "', '" & strSubLocDesc & "', " & iActive & ", " & iCustID & ", '" & strMainLoc & "'" & Environment.NewLine
                strSql &= ") ; " & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************************************************
        Public Function UpdateWipMainAndSubLocMap(ByVal iWIL_ID As Integer, ByVal iCustID As Integer, ByVal strMainLoc As String, _
                                            ByVal strSubLoc As String, ByVal strSubLocDesc As String, ByVal iActive As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "UPDATE wipsublocmap SET WIL_SDesc = '" & strSubLoc & "', WIL_LDesc = '" & strSubLocDesc & "'" & Environment.NewLine
                strSql &= ", WIL_Active = " & iActive & ", Cust_ID = " & iCustID & ", Workstation = '" & strMainLoc & "' " & Environment.NewLine
                strSql &= "WHERE WIL_ID = " & iWIL_ID & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************************************************
        Public Function GetTotalDevCntInWip(ByVal iCustID As Integer, ByVal strWipLoc As String, ByVal strWIL_SDesc As String) As Integer
            Dim strSql As String = ""

            Try
                strSql = "SELECT COUNT(*) AS cnt FROM tdevice INNER JOIN tcellopt ON tdevice.Device_ID = tcellopt.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strSql &= "INNER JOIN wipsublocmap ON tcellopt.WIL_ID = wipsublocmap.WIL_ID " & Environment.NewLine
                strSql &= "WHERE Device_Dateship is null AND tlocation.Cust_ID = " & iCustID & " AND tcellopt.Workstation = '" & strWipLoc & "' " & Environment.NewLine
                strSql &= "AND wipsublocmap.WIL_SDesc = '" & strWIL_SDesc & "'" & Environment.NewLine
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************************************************
        Public Function GetTranferToWIPSubLocation(ByVal iCustID As Integer, ByVal strMainLoc As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT WIL_ID, WIL_SDesc, WIL_LDesc FROM wipsublocmap " & Environment.NewLine
                strSql &= "WHERE Workstation = '" & strMainLoc & "' AND WIL_Active = 1 AND Cust_ID = " & iCustID & "; " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************************************************
        Public Function GetDeviceInWipWithWorkstationLocation(ByVal iCustID As Integer, ByVal strDeviceSN As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT tdevice.Device_ID, tcellopt.Workstation, tcellopt.WIL_ID, tdevice.Pallett_ID" & Environment.NewLine
                strSql &= ", IF(WIL_SDesc is null, '', WIL_SDesc) as WIL_SDesc " & Environment.NewLine
                strSql &= ", IF(WIL_LDesc is null, '', WIL_LDesc) as WIL_LDesc " & Environment.NewLine
                strSql &= ", tdevice.Model_ID, tmodel.Model_Desc " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN tcellopt ON tdevice.Device_ID = tcellopt.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN wipsublocmap ON tcellopt.WIL_ID = wipsublocmap.WIL_ID" & Environment.NewLine
                strSql &= "WHERE Device_SN = '" & strDeviceSN & "' AND Device_Dateship is null" & Environment.NewLine
                strSql &= "AND tlocation.Cust_ID = " & iCustID & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************
        Public Function GetSelectedAWAP(ByVal iDeviceID As Integer) As DataTable
            Try

                Dim strSql As String = ""
                strSql = "SELECT A.BillCode_ID, LCase(B.Billcode_Desc) as Billcode_Desc, A.Part_Number, B.BillType_ID, sum(A.Trans_Amount) as Trans_Amount " & Environment.NewLine
                strSql &= ", IF(C.DBill_ID is null, 0, 1) as Consumed " & Environment.NewLine
                strSql &= "FROM tdevicebillAWAP A" & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes B ON A.Billcode_ID = B.billcode_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tdevicebill C ON A.Device_ID = C.Device_ID AND A.Billcode_ID = C.billcode_ID " & Environment.NewLine
                strSql &= "WHERE A.Device_ID = " & iDeviceID & Environment.NewLine
                strSql &= "GROUP BY A.BillCode_ID, B.BillType_ID, A.Part_Number HAVING Trans_Amount > 0 "

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************************************************
        Public Function SetWipNextLoc(ByVal iDeviceID As Integer, ByVal strToLoc As String, ByVal iWIL_ID As Integer, _
                                      ByVal strStatus As String, ByVal booSetLeftImageHoldDate As Boolean, _
                                      ByVal iUserID As Integer, ByVal strScreenName As String, ByVal strFormName As String) As Integer
            Dim strSql As String = ""
            Dim i As Integer
            Dim dt As DataTable

            Try
                strSql = "SELECT Device_ID, WorkStation FROM tcellopt WHERE Device_ID = " & iDeviceID
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count = 0 Then Throw New Exception("Device does not exist.")

                strSql = "UPDATE tcellopt "
                If strStatus.Trim.Length > 0 OrElse booSetLeftImageHoldDate = True Then strSql &= ", syxdata "
                strSql &= "SET WorkStation = '" & strToLoc & "', WorkStationEntryDt = now(), WIL_ID = " & iWIL_ID & Environment.NewLine
                If strStatus.Trim.Length > 0 Then strSql &= ", syxdata.status = '" & strStatus & "'" & Environment.NewLine
                If booSetLeftImageHoldDate = True Then strSql &= ", LeftImageHoldDate = now() " & Environment.NewLine
                strSql &= "WHERE tcellopt.Device_ID = " & iDeviceID & Environment.NewLine
                If strStatus.Trim.Length > 0 OrElse booSetLeftImageHoldDate = True Then strSql &= "AND tcellopt.Device_ID = syxdata.Device_ID" & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                Generic.SetTcelloptWorkstationJournal(dt, iUserID, strToLoc, strScreenName, strFormName)

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '*********************************************************************************************************
        Public Function GetPretestResult(ByVal iDeviceID As Integer) As String
            Try
                Dim strSql As String = ""
                strSql = "SELECT QCResult FROM tpretest_data " & Environment.NewLine
                strSql &= "INNER JOIN lqcresult ON tpretest_data.QCResult_ID = lqcresult.QCResult_ID " & Environment.NewLine
                strSql &= "WHERE tpretest_data.Device_ID = " & iDeviceID
                Return Me._objDataProc.GetSingletonString(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************************************************
        Public Function AddRemoveModelToImageLibrary(ByVal strModelDesc As String, ByVal iUserID As Integer, ByVal iHasImage As Integer) As Integer
            Dim strSql, strSplitModelName(), strGenericModel As String
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim i As Integer = 0

            Try
                strSplitModelName = strModelDesc.Trim.Split(" ")
                If strSplitModelName.Length > 0 AndAlso strSplitModelName(0).Trim.Length > 0 Then strGenericModel = strSplitModelName(0).Trim Else strGenericModel = strModelDesc.Trim

                strSql = "SELECT * FROM tmodel " & Environment.NewLine
                strSql &= "WHERE Model_Desc = '" & strGenericModel & "' OR Model_Desc like '" & strGenericModel & " %'" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                For Each R1 In dt.Rows
                    strSql = "SELECT count(*) as cnt FROM production.ImageLibrary WHERE Model_ID = " & R1("Model_ID") & Environment.NewLine
                    If Me._objDataProc.GetIntValue(strSql) > 0 Then
                        strSql = "UPDATE ImageLibrary SET HasImage = " & iHasImage & ", LastUpdDate = now(), LastUpdUserID = " & iUserID & " where Model_ID = " & R1("Model_ID")
                    Else
                        strSql = "INSERT INTO ImageLibrary ( Model_ID, HasImage, LastUpdDate, LastUpdUserID ) VALUES ( " & R1("Model_ID") & ", " & iHasImage & ", now(), " & iUserID & " ) "
                    End If
                    i += Me._objDataProc.ExecuteNonQuery(strSql)
                Next R1

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************************************************



    End Class
End Namespace