Option Explicit On 

Namespace Buisness.TracFone
    Public Class TFTestBuildTriagedBox
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


#Region "Build Triaged Box SQL"
        'EXAMPLE: ******************************************************************
        Public Function GetBilledPartsServicesBillcodeID(ByVal iDeviceID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT tdevicebill.Billcode_ID, BillCode_Rule " & Environment.NewLine
                strSql &= "FROM tdevicebill " & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes ON tdevicebill.Billcode_ID = lbillcodes.billcode_ID " & Environment.NewLine
                strSql += "WHERE tdevicebill.Device_ID = " & iDeviceID & " " & Environment.NewLine
                'strSql += "AND BillType_ID = 1 " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetTracfoneCosmeticModels(ByVal booAddSelectRow As Boolean) As DataTable
            Dim dt As DataTable
            Dim strSql As String = ""

            'Only Cosmetic models, not incluse _FUN models and X models
            Try
                strSql = "SELECT DISTINCT tmodel.Model_ID, Model_Desc, Manuf_ID, cust_model_number, cust_model_desc" & Environment.NewLine
                strSql &= " , tcustmodel_pssmodel_map.cust_IncomingSku, tcustmodel_pssmodel_map.cust_IncomingDesc" & Environment.NewLine
                strSql &= " FROM tmodel" & Environment.NewLine
                strSql &= " INNER JOIN tcustmodel_pssmodel_map ON tmodel.Model_ID = tcustmodel_pssmodel_map.model_id" & Environment.NewLine
                strSql &= " WHERE tcustmodel_pssmodel_map.cust_id = " & BuildShipPallet.TracFone_CUSTOMER_ID & Environment.NewLine
                strSql &= " AND cust_MaterialCategory = 'PHONE' AND Substring(Trim(Model_Desc),Length(Trim(Model_Desc))-3,4) <> '_FUN'" & Environment.NewLine
                strSql &= " AND Substring(Trim(Model_Desc),Length(Trim(Model_Desc)),1) <> 'X'" & Environment.NewLine
                strSql &= " ORDER BY Model_Desc;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetTracfone_FUN_Model_By_NTF_XModel(ByVal iNTF_XModel_ID As Integer, _
                                                            Optional ByVal strNTF_XModel_Desc As String = "") As DataTable
            Dim dt As DataTable
            Dim strSql As String = ""
            Dim strCOS_Model_Desc As String = ""

            Try
                'Get COS model from X model
                If strNTF_XModel_Desc.Trim.Length > 0 Then
                    strCOS_Model_Desc = Left(strNTF_XModel_Desc.Trim, strNTF_XModel_Desc.Trim.Length - 1) 'take off last 1 character "X"
                Else
                    strSql = "Select * from tmodel where Model_ID =" & iNTF_XModel_ID
                    dt = Me._objDataProc.GetDataTable(strSql)
                    If dt.Rows.Count > 0 Then
                        strCOS_Model_Desc = Left(Trim(dt.Rows(0).Item("Model_Desc")).ToString, Trim(dt.Rows(0).Item("Model_Desc")).ToString.Length - 1)
                    Else
                        strCOS_Model_Desc = "Found_No_Model_No_Model_No_Model"
                    End If
                End If

                'Get _FUN model based on the COS model
                strSql = "SELECT DISTINCT tmodel.Model_ID, Model_Desc, Manuf_ID, cust_model_number, cust_model_desc" & Environment.NewLine
                strSql &= " , tcustmodel_pssmodel_map.cust_IncomingSku, tcustmodel_pssmodel_map.cust_IncomingDesc" & Environment.NewLine
                strSql &= " FROM tmodel" & Environment.NewLine
                strSql &= " INNER JOIN tcustmodel_pssmodel_map ON tmodel.Model_ID = tcustmodel_pssmodel_map.model_id" & Environment.NewLine
                strSql &= " WHERE tcustmodel_pssmodel_map.cust_id =" & BuildShipPallet.TracFone_CUSTOMER_ID & Environment.NewLine
                strSql &= " AND cust_MaterialCategory = 'PHONE' AND Substring(Trim(Model_Desc),Length(Trim(Model_Desc))-3,4) = '_FUN'" & Environment.NewLine
                strSql &= " AND Model_Desc = '" & strCOS_Model_Desc & "_FUN';" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetTracfoneAllModelsOrOneModel(ByVal booAddSelectRow As Boolean, Optional ByVal strModelDesc As String = "") As DataTable
            Dim dt As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT DISTINCT tmodel.Model_ID, Model_Desc, Manuf_ID, cust_model_number, cust_model_desc" & Environment.NewLine
                strSql &= ", tcustmodel_pssmodel_map.cust_IncomingSku, tcustmodel_pssmodel_map.cust_IncomingDesc " & Environment.NewLine
                strSql &= "FROM tmodel " & Environment.NewLine
                strSql &= "INNER JOIN tcustmodel_pssmodel_map ON tmodel.Model_ID = tcustmodel_pssmodel_map.model_id " & Environment.NewLine
                strSql &= "WHERE tcustmodel_pssmodel_map.cust_id = " & BuildShipPallet.TracFone_CUSTOMER_ID & Environment.NewLine
                strSql &= "AND cust_MaterialCategory = 'PHONE' " & Environment.NewLine
                If strModelDesc.Trim.Length > 0 Then strSql &= "AND Model_Desc ='" & strModelDesc & "'" & Environment.NewLine
                strSql &= "ORDER BY Model_Desc;"
                dt = Me._objDataProc.GetDataTable(strSql)

                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetTriagedDevice(ByVal sn As String) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT DV.Device_ID,DV.Device_SN,MD1.Model_Desc as 'Triaged_Model',MD2.Model_Desc as 'Device_Model' " & Environment.NewLine
                strSql &= ",DP.Disp_cd as 'Triaged_Disposition',DP.Disp_na as 'Triaged_Disposition_Full' " & Environment.NewLine
                strSql &= ",IF(TD.Disp_ID=2 or TD.Disp_ID=3,'FUN',IF(TD.Disp_ID=4,'COS', IF(TD.Disp_ID=5, 'NTF',''))) as 'BoxType' " & Environment.NewLine
                strSql &= ",CO.Workstation,IF(TD.Triaged_Model_ID=DV.Model_ID,'Yes','No') as 'IsModelMatched' " & Environment.NewLine
                strSql &= ",IF(CO.Workstation ='Triage Box','Yes','No') as 'IsValidWorkstation' " & Environment.NewLine
                strSql &= ",TD.Triaged_Model_ID,DV.Model_ID,TD.Disp_ID,IF(TD.Disp_ID=2 or TD.Disp_ID=3,1 " & Environment.NewLine
                strSql &= ",IF(TD.Disp_ID=4,0, IF(TD.Disp_ID=5, 3, -1))) as 'FuncRep',IF(TD.Disp_ID=2 or TD.Disp_ID=3,'F',IF(TD.Disp_ID=4,'C', IF(TD.Disp_ID=5, 'N',''))) as 'PrefixBoxName',TD.Triage_Completed " & Environment.NewLine
                strSql &= "FROM production.tdevice_triaged_data TD " & Environment.NewLine
                strSql &= "INNER JOIN production.tdevice DV ON TD.Device_ID=DV.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN production.tcellopt CO ON TD.Device_ID=CO.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN edi.titem EI ON TD.Device_ID=EI.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN production.tmodel MD1 ON TD.Triaged_Model_ID=MD1.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN production.tmodel MD2 ON DV.Model_ID=MD2.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN production.tdispositions DP ON TD.Disp_ID=DP.Disp_ID " & Environment.NewLine
                strSql &= "WHERE Triage_Completed=1 AND DV.Device_SN = '" & sn & "'; " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)

                'If dt.Rows.Count = 0 Then
                '    Throw New Exception("Serial Number is not able to be added to the box.")
                'ElseIf dt.Rows.Count > 1 Then
                '    Throw New Exception("Serial Number existed more than once. Please contact IT.")
                'ElseIf dt.Rows(0)("Device_SN").ToString.Trim = sn _
                'And dt.Rows(0)("Triaged_Model").ToString.Trim = modl _
                'And dt.Rows(0)("Triaged_Disposition").ToString.Trim = disp _
                'And dt.Rows(0)("IsModelMatched").ToString.Trim.ToUpper = "YES" _
                'And dt.Rows(0)("IsValidWorkstation").ToString.Trim.ToUpper = "YES" Then
                '    booReturnVal = True
                'End If

                'Return booReturnVal
            Catch ex As Exception
                Throw ex
                'Finally
                '    Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function CreateTriagedBoxID(ByVal iModelID As Integer, _
                                           ByVal iFuncRep As Integer, _
                                           ByVal strPrefixBoxName As String, _
                                           ByVal strBoxStage As String) As DataTable
            Dim strSql As String = ""
            Dim strSvrDTime As String = ""
            Dim iNextSeqNo As Integer = 0
            Dim strBoxID As String = ""
            Dim iWHBoxID As Integer = 0
            Dim iWrtyFlag As Integer = 0
            Dim iWrtyExpInLess31Days As Integer = 0
            'Dim dt As DataTable
            'Dim R1 As DataRow
            Dim objMisc As New TracFone.clsMisc()

            Try
                strSvrDTime = Format(CDate(Generic.MySQLServerDateTime()), "yyyyMMdd")
                If strSvrDTime.Trim.Length = 0 Then strSvrDTime = Format(Now(), "yyyyMMdd")

                strBoxID &= strPrefixBoxName & strSvrDTime & "OW"

                iNextSeqNo = objMisc.GetWHBoxNexSeqNo(strBoxID, objMisc._iWHBoxSegDigitCnt)
                If iNextSeqNo = 0 Then Throw New Exception("System has failed to get next box number.")
                strBoxID = strBoxID & iNextSeqNo.ToString.PadLeft(objMisc._iWHBoxSegDigitCnt, "0")

                iWHBoxID = objMisc.InsertEdiWarehouseBox(strBoxID, iFuncRep, iWrtyFlag, 0, iModelID, iWrtyExpInLess31Days, 0, strBoxStage)
                If iWHBoxID = 0 Then Throw New Exception("System has failed to create new box.")

                strSql = "Select * from edi.twarehousebox where wb_ID=" & iWHBoxID
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function UpdateTriagedBoxDevice(ByVal iDevice_ID As Integer, ByVal StrSN As String, _
                                               ByVal strWorkstation As String, ByVal iWB_ID As Integer, _
                                               ByVal strBoxName As String, ByVal iFuncRep As Integer, _
                                               ByVal strMsg As String) As Boolean
            Dim strSql As String = ""
            Dim bRes As Boolean = False
            Dim dt, dt2 As DataTable
            Dim i As Integer = 0

            Try
                strMsg = ""

                strSql = "SELECT A.Device_ID,B.Device_SN,A.Workstation,A.Cellopt_WIPOwner,A.Cellopt_WIPEntryDt,A.WorkStationEntryDt" & Environment.NewLine
                strSql &= " ,B.Device_DateRec,B.Device_DateBill,B.Device_DateShip,D.wb_ID,D.BoxID,E.FuncRep" & Environment.NewLine
                strSql &= " FROM production.tcellopt A" & Environment.NewLine
                strSql &= " INNER JOIN production.tdevice B ON A.Device_ID=B.Device_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tdevice_triaged_data C ON A.Device_ID=C.Device_ID" & Environment.NewLine
                strSql &= " INNER JOIN edi.titem D ON A.Device_ID=D.Device_ID" & Environment.NewLine
                strSql &= " LEFT JOIN edi.twarehousebox E ON D.wb_ID=E.wb_ID" & Environment.NewLine
                strSql &= " WHERE A.Device_ID= " & iDevice_ID & ";" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count = 0 Then
                    strMsg = "Can't find this device '" & StrSN & "'. See IT."
                ElseIf dt.Rows.Count > 1 Then
                    strMsg = "Found duplicate device '" & StrSN & "'. See IT."
                Else
                    If Not Trim(dt.Rows(0).Item("Workstation")).ToString.ToUpper = "Triage Box".ToUpper Then
                        strMsg = "This device '" & StrSN & "' has invalid workstation (not 'Triage Box'). See IT."
                    ElseIf Not dt.Rows(0).IsNull("Device_DateShip") Then
                        strMsg = "This device '" & StrSN & "' has been produced. See IT."
                    ElseIf Not dt.Rows(0).IsNull("FuncRep") AndAlso _
                           (dt.Rows(0).Item("FuncRep") = 0 OrElse dt.Rows(0).Item("FuncRep") = 1 OrElse dt.Rows(0).Item("FuncRep") = 3) Then
                        strMsg = "This device '" & StrSN & "' already belongs to another triaged box '" & dt.Rows(0).Item("BoxID") & "'. See IT."
                    Else 'ready to update
                        strSql = "UPDATE production.tcellopt set workstation ='" & strWorkstation & "' WHERE Device_ID = " & iDevice_ID
                        i = Me._objDataProc.ExecuteNonQuery(strSql)
                        strSql = "Select * from production.tcellopt where device_ID=" & iDevice_ID
                        dt2 = Me._objDataProc.GetDataTable(strSql)
                        If dt2.Rows.Count > 0 Then 'should be 1 row
                            If Trim(dt2.Rows(0).Item("Workstation")).ToString.ToUpper = strWorkstation.Trim.ToUpper Then
                                bRes = True
                                strMsg = ""
                            Else
                                strMsg = "Failed to update tCellopt.Workstation. See IT."
                            End If
                        Else
                            strMsg = "Failed to update tCellopt.Workstation.. See IT."
                        End If
                    End If
                End If

                'if sucessfully updated tcellopt, now update edi.itiem
                If bRes Then
                    strSql = "UPDATE edi.titem set wb_id = " & iWB_ID & ",BoxID='" & strBoxName & "',FuncRep=" & iFuncRep & " WHERE device_ID=" & iDevice_ID
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                    If i = 0 Then 'failed
                        strMsg = "Successed to update tCellopt.Workstation, but Failed to update edi.titem.wb_id and  edi.titem.BoxID. See IT."
                        bRes = False
                    End If
                End If

                Return bRes
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function UndoDevicesFromTriagedBox(ByVal strDevice_IDs As String, ByVal iBillCode_ID As Integer, ByVal strMsg As String) As Boolean
            Dim strSql As String = ""
            Dim dt, dt2 As DataTable
            Dim row As DataRow
            Dim i As Integer = 0
            Dim iDevice_ID As Integer = 0
            Dim arrLstWorkstations As New ArrayList()

            Try
                strMsg = ""
                arrLstWorkstations.Add("FQA")
                arrLstWorkstations.Add("BER SCREEN")
                arrLstWorkstations.Add("SW SCREEN")
                arrLstWorkstations.Add("PRE-BUFF")
                arrLstWorkstations.Add("WH-WIP")

                strSql = "SELECT A.Device_ID,B.Device_SN,A.Workstation,A.Cellopt_WIPOwner,A.Cellopt_WIPEntryDt,A.WorkStationEntryDt" & Environment.NewLine
                strSql &= " ,B.Device_DateRec,B.Device_DateBill,B.Device_DateShip,D.wb_ID,D.BoxID,E.FuncRep" & Environment.NewLine
                strSql &= " FROM production.tcellopt A" & Environment.NewLine
                strSql &= " INNER JOIN production.tdevice B ON A.Device_ID=B.Device_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tdevice_triaged_data C ON A.Device_ID=C.Device_ID" & Environment.NewLine
                strSql &= " INNER JOIN edi.titem D ON A.Device_ID=D.Device_ID" & Environment.NewLine
                strSql &= " LEFT JOIN edi.twarehousebox E ON D.wb_ID=E.wb_ID" & Environment.NewLine
                strSql &= " WHERE A.Device_ID in (" & strDevice_IDs & ");" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count = 0 Then
                    strMsg = "Failed to process it. See IT."
                    Return False
                Else
                    For Each row In dt.Rows
                        If Not arrLstWorkstations.Contains(Trim(row("Workstation")).ToString) Then
                            strMsg = "Invalid workstation. Can't process it."
                            Return False
                        End If
                        If Not dt.Rows(0).IsNull("Device_DateShip") Then
                            strMsg = "Found produced device. Can't process it."
                            Return False
                        End If
                    Next

                    'Undo tcellopt
                    strSql = "UPDATE production.tcellopt set workstation ='Triage Box' WHERE Device_ID  in (" & strDevice_IDs & ");"
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                    'Undo edi.titem
                    For Each row In dt.Rows
                        iDevice_ID = row("Device_ID")
                        strSql = "Select WB.WB_ID,WB.BoxID,WB.FuncRep from  production.tdevice_triaged_data TD" & Environment.NewLine
                        strSql &= " inner join edi.twarehousebox WB On TD.WB_ID_Incoming=WB.WB_ID  where device_ID =" & iDevice_ID & ";" & Environment.NewLine
                        dt2 = Me._objDataProc.GetDataTable(strSql)
                        If dt2.Rows.Count > 0 Then
                            strSql = "UPDATE edi.titem set wb_id = " & dt2.Rows(0).Item("WB_ID") & ",BoxID='" & dt2.Rows(0).Item("BoxID") & "',FuncRep=" & dt2.Rows(0).Item("FuncRep") & " WHERE device_ID=" & iDevice_ID & ";"
                            i = Me._objDataProc.ExecuteNonQuery(strSql)
                        End If
                    Next
                    'Undo charges
                    strSql = "Delete from production.tdevicebill_additional Where Device_ID in (" & strDevice_IDs & ") AND BillCode_ID =" & iBillCode_ID & ";"
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                End If

                Return True

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetBoxedDevices(ByVal iWB_ID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT A.Device_ID,B.Device_SN,A.Workstation,A.Cellopt_WIPOwner,A.Cellopt_WIPEntryDt,A.WorkStationEntryDt" & Environment.NewLine
                strSql &= " ,B.Device_DateRec,B.Device_DateBill,B.Device_DateShip,D.wb_ID,D.BoxID,E.FuncRep" & Environment.NewLine
                strSql &= " FROM production.tcellopt A" & Environment.NewLine
                strSql &= " INNER JOIN production.tdevice B ON A.Device_ID=B.Device_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tdevice_triaged_data C ON A.Device_ID=C.Device_ID" & Environment.NewLine
                strSql &= " INNER JOIN edi.titem D ON A.Device_ID=D.Device_ID" & Environment.NewLine
                strSql &= " INNER JOIN edi.twarehousebox E ON D.wb_ID=E.wb_ID" & Environment.NewLine
                strSql &= " WHERE D.wb_ID = " & iWB_ID & ";" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '******************************************************************
        Public Function GetOpenBoxes() As DataTable
            Dim strSql As String = ""
            Dim dtOpenBoxes, dtBoxDetails As DataTable
            Dim row, row2 As DataRow
            Dim iWB_ID As Integer = 0

            Try
                strSql = "SELECT WB.BoxID as 'Box_Name',Count(*) as 'Qty','' as 'Box_Model',0 as 'Model_ID','' as 'Disposition',0 as 'Disp_ID','' as 'Status', WB.WB_ID,WB.BoxStage" & Environment.NewLine
                strSql &= " FROM production.tdevice_triaged_data TD" & Environment.NewLine
                strSql &= " INNER JOIN production.tdevice DV ON TD.Device_ID=DV.Device_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tcellopt CO ON TD.Device_ID=CO.Device_ID" & Environment.NewLine
                strSql &= " INNER JOIN edi.titem EI ON TD.Device_ID=EI.Device_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tmodel MD1 ON TD.Triaged_Model_ID=MD1.Model_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tmodel MD2 ON DV.Model_ID=MD2.Model_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tdispositions DP ON TD.Disp_ID=DP.Disp_ID" & Environment.NewLine
                strSql &= " INNER Join edi.twarehousebox WB ON EI.wb_ID=WB.WB_ID" & Environment.NewLine
                strSql &= " WHERE WB.Closed=0 AND WB.BoxStage='Triage Box'" & Environment.NewLine
                strSql &= " GROUP BY  WB.WB_ID,WB.BoxID;" & Environment.NewLine

                dtOpenBoxes = Me._objDataProc.GetDataTable(strSql)

                For Each row In dtOpenBoxes.Rows
                    iWB_ID = row("WB_ID")

                    strSql = "SELECT WB.WB_ID,WB.BoxID as 'WH_Box_Name',EI.BoxID as 'Item_Box_Name'" & Environment.NewLine
                    strSql &= " ,DV.Device_ID,DV.Device_SN,MD1.Model_Desc as 'Triaged_Model',MD2.Model_Desc as 'Device_Model',DP.Disp_cd as 'Triaged_Disposition',DP.Disp_na as 'Triaged_Disposition_Full'" & Environment.NewLine
                    strSql &= " ,IF(TD.Disp_ID=2 or TD.Disp_ID=3,'FUN',IF(TD.Disp_ID=4,'COS', IF(TD.Disp_ID=5, 'NTF',''))) as 'BoxType',CO.Workstation" & Environment.NewLine
                    strSql &= " ,IF(TD.Triaged_Model_ID=DV.Model_ID,'Yes','No') as 'IsModelMatched'" & Environment.NewLine
                    strSql &= " ,IF(CO.Workstation ='FQA' or CO.Workstation ='BER SCREEN' or CO.Workstation ='SW SCREEN'  or CO.Workstation ='PRE-BUFF' or CO.Workstation ='WH-WIP' ,'Yes','No') as 'IsValidWorkstation'" & Environment.NewLine
                    strSql &= " ,IF(EI.BoxID=WB.BoxID,'Yes','No') as 'IsBoxNameMatched'" & Environment.NewLine
                    strSql &= " ,TD.Triaged_Model_ID,DV.Model_ID,TD.Disp_ID" & Environment.NewLine
                    strSql &= " ,IF(TD.Disp_ID=2 or TD.Disp_ID=3,1,IF(TD.Disp_ID=4,0, IF(TD.Disp_ID=5, 3, -1))) as 'FuncRep'" & Environment.NewLine
                    strSql &= " ,IF(TD.Disp_ID=2 or TD.Disp_ID=3,'F',IF(TD.Disp_ID=4,'C', IF(TD.Disp_ID=5, 'N',''))) as 'PrefixBoxName'" & Environment.NewLine
                    strSql &= " ,TD.Triage_Completed" & Environment.NewLine
                    strSql &= " FROM production.tdevice_triaged_data TD" & Environment.NewLine
                    strSql &= " INNER JOIN production.tdevice DV ON TD.Device_ID=DV.Device_ID" & Environment.NewLine
                    strSql &= " INNER JOIN production.tcellopt CO ON TD.Device_ID=CO.Device_ID" & Environment.NewLine
                    strSql &= " INNER JOIN edi.titem EI ON TD.Device_ID=EI.Device_ID" & Environment.NewLine
                    strSql &= " INNER JOIN production.tmodel MD1 ON TD.Triaged_Model_ID=MD1.Model_ID" & Environment.NewLine
                    strSql &= " INNER JOIN production.tmodel MD2 ON DV.Model_ID=MD2.Model_ID" & Environment.NewLine
                    strSql &= " INNER JOIN production.tdispositions DP ON TD.Disp_ID=DP.Disp_ID" & Environment.NewLine
                    strSql &= " INNER Join edi.twarehousebox WB ON EI.wb_ID=WB.WB_ID" & Environment.NewLine
                    strSql &= " WHERE WB.WB_ID=" & iWB_ID & ";" & Environment.NewLine
                    dtBoxDetails = Me._objDataProc.GetDataTable(strSql)

                    row.BeginEdit() : row("Status") = "Valid"
                    If dtBoxDetails.Rows.Count = 0 Then
                        row("Status") = "Invalid"
                    Else
                        row("Box_Model") = dtBoxDetails.Rows(0).Item("Triaged_Model")
                        row("Model_ID") = dtBoxDetails.Rows(0).Item("Triaged_Model_ID")
                        row("Disposition") = dtBoxDetails.Rows(0).Item("BoxType")
                        row("Disp_ID") = dtBoxDetails.Rows(0).Item("Disp_ID")
                        For Each row2 In dtBoxDetails.Rows
                            If Not Trim(row2("IsModelMatched")).ToString.ToUpper = "Yes".ToUpper Then
                                row("Status") = "Invalid" : Exit For
                            End If
                            If Not Trim(row2("IsValidWorkstation")).ToString.ToUpper = "Yes".ToUpper Then
                                row("Status") = "Invalid" : Exit For
                            End If
                            If Not Trim(row2("IsBoxNameMatched")).ToString.ToUpper = "Yes".ToUpper Then
                                row("Status") = "Invalid" : Exit For
                            End If
                        Next
                    End If

                    row.AcceptChanges()
                Next

                Return dtOpenBoxes

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetReopenTriageBox(ByVal strBoxName As String, ByRef IsOpenBox As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dtBox, dtBoxDetails As DataTable
            Dim row, row2 As DataRow
            Dim iWB_ID As Integer = 0

            Try
                strSql = "SELECT WB.BoxID as 'Box_Name',Count(*) as 'Qty','' as 'Box_Model',0 as 'Model_ID','' as 'Disposition',0 as 'Disp_ID','' as 'Status', WB.WB_ID,WB.BoxStage,WB.Closed" & Environment.NewLine
                strSql &= " FROM production.tdevice_triaged_data TD" & Environment.NewLine
                strSql &= " INNER JOIN production.tdevice DV ON TD.Device_ID=DV.Device_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tcellopt CO ON TD.Device_ID=CO.Device_ID" & Environment.NewLine
                strSql &= " INNER JOIN edi.titem EI ON TD.Device_ID=EI.Device_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tmodel MD1 ON TD.Triaged_Model_ID=MD1.Model_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tmodel MD2 ON DV.Model_ID=MD2.Model_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tdispositions DP ON TD.Disp_ID=DP.Disp_ID" & Environment.NewLine
                strSql &= " INNER Join edi.twarehousebox WB ON EI.wb_ID=WB.WB_ID" & Environment.NewLine
                strSql &= " WHERE WB.BoxStage='Triage Box' AND WB.BoxID ='" & strBoxName & "'" & Environment.NewLine
                strSql &= " GROUP BY WB.WB_ID,WB.BoxID;" & Environment.NewLine

                dtBox = Me._objDataProc.GetDataTable(strSql)

                For Each row In dtBox.Rows
                    If row("Closed") = 0 Then IsOpenBox = True Else IsOpenBox = False
                    iWB_ID = row("WB_ID")

                    strSql = "SELECT WB.WB_ID,WB.BoxID as 'WH_Box_Name',EI.BoxID as 'Item_Box_Name'" & Environment.NewLine
                    strSql &= " ,DV.Device_ID,DV.Device_SN,MD1.Model_Desc as 'Triaged_Model',MD2.Model_Desc as 'Device_Model',DP.Disp_cd as 'Triaged_Disposition',DP.Disp_na as 'Triaged_Disposition_Full'" & Environment.NewLine
                    strSql &= " ,IF(TD.Disp_ID=2 or TD.Disp_ID=3,'FUN',IF(TD.Disp_ID=4,'COS', IF(TD.Disp_ID=5, 'NTF',''))) as 'BoxType',CO.Workstation" & Environment.NewLine
                    strSql &= " ,IF(TD.Triaged_Model_ID=DV.Model_ID,'Yes','No') as 'IsModelMatched'" & Environment.NewLine
                    strSql &= " ,IF(CO.Workstation ='FQA' or CO.Workstation ='BER SCREEN' or CO.Workstation ='SW SCREEN'  or CO.Workstation ='PRE-BUFF' or CO.Workstation ='WH-WIP' ,'Yes','No') as 'IsValidWorkstation'" & Environment.NewLine
                    strSql &= " ,IF(EI.BoxID=WB.BoxID,'Yes','No') as 'IsBoxNameMatched'" & Environment.NewLine
                    strSql &= " ,TD.Triaged_Model_ID,DV.Model_ID,TD.Disp_ID" & Environment.NewLine
                    strSql &= " ,IF(TD.Disp_ID=2 or TD.Disp_ID=3,1,IF(TD.Disp_ID=4,0, IF(TD.Disp_ID=5, 3, -1))) as 'FuncRep'" & Environment.NewLine
                    strSql &= " ,IF(TD.Disp_ID=2 or TD.Disp_ID=3,'F',IF(TD.Disp_ID=4,'C', IF(TD.Disp_ID=5, 'N',''))) as 'PrefixBoxName'" & Environment.NewLine
                    strSql &= " ,TD.Triage_Completed" & Environment.NewLine
                    strSql &= " FROM production.tdevice_triaged_data TD" & Environment.NewLine
                    strSql &= " INNER JOIN production.tdevice DV ON TD.Device_ID=DV.Device_ID" & Environment.NewLine
                    strSql &= " INNER JOIN production.tcellopt CO ON TD.Device_ID=CO.Device_ID" & Environment.NewLine
                    strSql &= " INNER JOIN edi.titem EI ON TD.Device_ID=EI.Device_ID" & Environment.NewLine
                    strSql &= " INNER JOIN production.tmodel MD1 ON TD.Triaged_Model_ID=MD1.Model_ID" & Environment.NewLine
                    strSql &= " INNER JOIN production.tmodel MD2 ON DV.Model_ID=MD2.Model_ID" & Environment.NewLine
                    strSql &= " INNER JOIN production.tdispositions DP ON TD.Disp_ID=DP.Disp_ID" & Environment.NewLine
                    strSql &= " INNER Join edi.twarehousebox WB ON EI.wb_ID=WB.WB_ID" & Environment.NewLine
                    strSql &= " WHERE WB.WB_ID=" & iWB_ID & ";" & Environment.NewLine
                    dtBoxDetails = Me._objDataProc.GetDataTable(strSql)

                    row.BeginEdit() : row("Status") = "Valid"
                    If dtBoxDetails.Rows.Count = 0 Then
                        row("Status") = "Invalid"
                    Else
                        row("Box_Model") = dtBoxDetails.Rows(0).Item("Triaged_Model")
                        row("Model_ID") = dtBoxDetails.Rows(0).Item("Triaged_Model_ID")
                        row("Disposition") = dtBoxDetails.Rows(0).Item("BoxType")
                        row("Disp_ID") = dtBoxDetails.Rows(0).Item("Disp_ID")
                        For Each row2 In dtBoxDetails.Rows
                            If Not Trim(row2("IsModelMatched")).ToString.ToUpper = "Yes".ToUpper Then
                                row("Status") = "Invalid" : Exit For
                            End If
                            If Not Trim(row2("IsValidWorkstation")).ToString.ToUpper = "Yes".ToUpper Then
                                row("Status") = "Invalid" : Exit For
                            End If
                            If Not Trim(row2("IsBoxNameMatched")).ToString.ToUpper = "Yes".ToUpper Then
                                row("Status") = "Invalid" : Exit For
                            End If
                        Next
                    End If

                    row.AcceptChanges()

                    Exit For 'should be one row (one box)
                Next

                Return dtBox

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetCompletedTriageBoxBeforeClose(ByVal iWB_ID As Integer, ByVal strBoxName As String) As DataTable
            Dim strSql As String = ""
            Dim i As Integer = 0

            Try
                strSql = "SELECT WB.WB_ID,WB.BoxID as 'WH_Box_Name',EI.BoxID as 'Item_Box_Name'" & Environment.NewLine
                strSql &= " ,DV.Device_ID,DV.Device_SN,MD1.Model_Desc as 'Triaged_Model',MD2.Model_Desc as 'Device_Model',DP.Disp_cd as 'Triaged_Disposition',DP.Disp_na as 'Triaged_Disposition_Full'" & Environment.NewLine
                strSql &= " ,IF(TD.Disp_ID=2 or TD.Disp_ID=3,'FUN',IF(TD.Disp_ID=4,'COS', IF(TD.Disp_ID=5, 'NTF',''))) as 'BoxType'" & Environment.NewLine
                strSql &= " ,IF(TD.Triaged_Model_ID=DV.Model_ID,'Yes','No') as 'IsModelMatched'" & Environment.NewLine
                strSql &= " ,IF(CO.Workstation ='FQA' or CO.Workstation ='BER SCREEN' or CO.Workstation ='SW SCREEN'  or CO.Workstation ='PRE-BUFF' or CO.Workstation ='WH-WIP' ,'Yes','No') as 'IsValidWorkstation'" & Environment.NewLine
                strSql &= " ,IF(EI.BoxID=WB.BoxID,'Yes','No') as 'IsBoxNameMatched'" & Environment.NewLine
                strSql &= " ,TD.Triaged_Model_ID,DV.Model_ID,TD.Disp_ID" & Environment.NewLine
                strSql &= " ,IF(TD.Disp_ID=2 or TD.Disp_ID=3,1,IF(TD.Disp_ID=4,0, IF(TD.Disp_ID=5, 3, -1))) as 'FuncRep'" & Environment.NewLine
                strSql &= " ,IF(TD.Disp_ID=2 or TD.Disp_ID=3,'F',IF(TD.Disp_ID=4,'C', IF(TD.Disp_ID=5, 'N',''))) as 'PrefixBoxName'" & Environment.NewLine
                strSql &= " ,TD.Triage_Completed,WB.Closed" & Environment.NewLine
                strSql &= " FROM production.tdevice_triaged_data TD" & Environment.NewLine
                strSql &= " INNER JOIN production.tdevice DV ON TD.Device_ID=DV.Device_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tcellopt CO ON TD.Device_ID=CO.Device_ID" & Environment.NewLine
                strSql &= " INNER JOIN edi.titem EI ON TD.Device_ID=EI.Device_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tmodel MD1 ON TD.Triaged_Model_ID=MD1.Model_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tmodel MD2 ON DV.Model_ID=MD2.Model_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tdispositions DP ON TD.Disp_ID=DP.Disp_ID" & Environment.NewLine
                strSql &= " INNER Join edi.twarehousebox WB ON EI.wb_ID=WB.WB_ID" & Environment.NewLine
                If strBoxName.Trim.Length > 0 Then
                    strSql &= " WHERE WB.BoxID='" & strBoxName & "';" & Environment.NewLine
                Else
                    strSql &= " WHERE WB.WB_ID=" & iWB_ID & ";" & Environment.NewLine
                End If

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function CloseAndPrintTriageBox(ByVal iWB_ID As Integer, _
                                               ByVal strBoxName As String, _
                                               ByVal strModel_Desc As String, _
                                               ByVal iQty As Integer, _
                                               ByVal strBoxType As String, _
                                               ByVal strWrtyStatus As String) As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0
            Dim objTFReveive As PSS.Data.Buisness.TracFone.Receive

            Try
                strSql = "UPDATE edi.twarehousebox " & Environment.NewLine
                strSql &= "SET Closed = 1 " & Environment.NewLine
                strSql &= "WHERE wb_id = " & iWB_ID & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                objTFReveive = New PSS.Data.Buisness.TracFone.Receive()
                objTFReveive.PrintWarehouseBuildTriageBoxID(strBoxName, strModel_Desc, iQty, strBoxType, strWrtyStatus)
                objTFReveive = Nothing

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function RePrintTriageBox(ByVal iWB_ID As Integer, _
                                               ByVal strBoxName As String, _
                                               ByVal strModel_Desc As String, _
                                               ByVal iQty As Integer, _
                                               ByVal strBoxType As String, _
                                               ByVal strWrtyStatus As String) As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0
            Dim objTFReveive As PSS.Data.Buisness.TracFone.Receive

            Try

                objTFReveive = New PSS.Data.Buisness.TracFone.Receive()
                objTFReveive.PrintWarehouseBuildTriageBoxID(strBoxName, strModel_Desc, iQty, strBoxType, strWrtyStatus)
                objTFReveive = Nothing

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function ResetBoxOpen(ByVal iWB_ID As Integer) As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0

            Try
                strSql = "UPDATE edi.twarehousebox " & Environment.NewLine
                strSql &= "SET Closed = 0 " & Environment.NewLine
                strSql &= "WHERE wb_id = " & iWB_ID & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function UpdateNTFTotalFlatLaborCharge(ByVal iDevice_ID As Integer, _
                                                      ByVal iModel_ID As Integer, _
                                                      ByVal iInvYearMonth As Integer, _
                                                      ByVal strDtime As String, _
                                                      ByVal iUserID As Integer, _
                                                      Optional ByVal strModel_Desc As String = "") As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim i As Integer = 0
            Dim vLaborCharge As Single = 0.0
            Dim iNTF_BillCode_ID As Integer = 541
            Dim strServicePart As String = "S0"

            Try
                'Get flat rate data
                strSql = "SELECT A.* FROM tflatratepricebymodel A INNER JOIN tmodel B ON A.Model_ID = B.Model_ID" & Environment.NewLine
                strSql &= " WHERE Cust_ID = " & BuildShipPallet.TracFone_CUSTOMER_ID & Environment.NewLine
                strSql &= " AND InvYearMonth <= " & iInvYearMonth & Environment.NewLine
                If strModel_Desc.Trim.Length > 0 Then
                    strSql &= " AND B.Model_Desc = '" & strModel_Desc & "'" & Environment.NewLine
                Else
                    strSql &= " AND B.Model_ID = " & iModel_ID & Environment.NewLine
                End If
                strSql &= " ORDER BY InvYearMonth DESC LIMIT 1" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    vLaborCharge = dt.Rows(0).Item("IW_LaborCharge") 'get flat rate
                    'Update tdevice labor charge
                    strSql = "UPDATE tdevice SET Device_DateBill = '" & strDtime & "',Device_LaborCharge = " & vLaborCharge
                    strSql &= " WHERE Device_ID = " & iDevice_ID
                    i = Me._objDataProc.ExecuteNonQuery(strSql)

                    'delete old bill data
                    strSql = "DELETE from tdevicebill WHERE device_ID = " & iDevice_ID & " AND BillCode_ID = " & iNTF_BillCode_ID
                    i += Me._objDataProc.ExecuteNonQuery(strSql)

                    'Add bill data
                    strSql = "INSERT INTO tdevicebill (DBill_RegPartPrice,DBill_AvgCost,DBill_StdCost,DBill_InvoiceAmt,Device_ID,BillCode_ID,Part_Number,Fail_ID,Repair_ID,Comp_ID,User_ID,Date_Rec,ReplPartSN)" & Environment.NewLine
                    strSql &= " VALUES (0.0,0.0,0.0," & vLaborCharge & "," & iDevice_ID & "," & iNTF_BillCode_ID & ",'" & strServicePart & "',0.0,0.0,Null," & iUserID & ",'" & strDtime & "','');" & Environment.NewLine
                    i += Me._objDataProc.ExecuteNonQuery(strSql)
                End If

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '******************************************************************
        Public Function UpdateNTFTotalFlatLaborLevel(ByVal iDevice_ID As Integer, _
                                                     ByVal iLaborLevel As Integer) As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0

            Try

                'Update tdevice labor level
                strSql = "UPDATE tdevice SET Device_LaborLevel = " & iLaborLevel & " WHERE Device_ID = " & iDevice_ID
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
#End Region
    End Class
End Namespace