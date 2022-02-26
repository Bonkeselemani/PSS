Option Explicit On 

Imports System.Windows.Forms

Namespace Buisness.WarrantyClaim
    Public Class MClaim

        Private _objDataProc As DBQuery.DataProc
        Private iBillCodeFlag As Integer = 0

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
#End Region

        '******************************************************************
        Public Property BillcodeFlag() As Integer
            Get
                Return iBillCodeFlag
            End Get
            Set(ByVal Value As Integer)
                iBillCodeFlag = Value
            End Set
        End Property

        '******************************************************************
        Public Function CheckIfMotorolaMClaimDataNeeded(ByVal iDevice_ID As Integer, _
                                                ByVal strSN As String) As Boolean
            Dim dt1 As DataTable
            Dim R1 As DataRow
            'Dim iManuf_ID As Integer = 0
            Dim iCust_ID As Integer = 0
            Dim iModel_ID As Integer = 0
            'Dim iBillcodeFlg As Integer = 0
            Dim iDcode_ID As Integer = 0
            Dim strCarrier As String = ""
            Dim iAPC_CodeID As Integer = 0
            Dim strAPC_codeDesc As String = ""

            Try
                '****************************
                'Step 1: Get the Device Info
                '****************************
                dt1 = Me.GetDeviceInfo(iDevice_ID)

                If dt1.Rows.Count > 0 Then
                    R1 = dt1.Rows(0)

                    '********************************
                    'Check if device is Wipe down 
                    If Not IsDBNull(R1("Model_Type")) Then
                        If CInt(R1("Model_Type").ToString) = 1 Then
                            Return False
                        End If
                    End If
                    '********************************

                    'If Not IsDBNull(R1("Manuf_ID")) Then
                    '    iManuf_ID = R1("Manuf_ID")
                    'End If

                    If Not IsDBNull(R1("Cust_ID")) Then
                        iCust_ID = R1("Cust_ID")
                    End If

                    If Not IsDBNull(R1("Model_ID")) Then
                        iModel_ID = R1("Model_ID")
                    End If

                    If Not IsDBNull(R1("Dcode_id")) Then
                        iAPC_CodeID = R1("Dcode_id")
                        If iAPC_CodeID > 0 Then
                            strAPC_codeDesc = Me.GetMotorolaAPCCodeDesc(iAPC_CodeID)
                        End If
                        If iAPC_CodeID = 0 Or strAPC_codeDesc = "" Then
                            Throw New Exception("APC code for this model is not set up. Please contact Engineering Department immediately.")
                        End If
                    End If

                    '****************************
                    'Step 2
                    '****************************
                    iBillCodeFlag = Me.CheckForWrtyBillcodes(iDevice_ID, iCust_ID, iModel_ID)
                    '****************************
                    'Step 3
                    '****************************
                    Select Case iCust_ID
                        Case 2019       'ATCLE
                            iDcode_ID = Me.GetDCodeID("CIN")
                        Case 2113       'Brightpoint
                            strCarrier = Me.GetCSCarrier_MotoDesc(iCust_ID, strSN)
                            If strCarrier = "" Then
                                iDcode_ID = 0
                            Else
                                iDcode_ID = Me.GetDCodeID(strCarrier)
                            End If
                    End Select
                End If
                '****************************
                'Step 3
                '****************************
                'If iManuf_ID = 1 And iBillCodeFlag > 0 And iDcode_ID > 0 Then
                If iBillCodeFlag > 0 And iDcode_ID > 0 Then
                    Return True
                Else
                    Return False
                End If
                '****************************
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                Buisness.Generic.DisposeDT(dt1)
            End Try
        End Function

        '******************************************************************
        Public Function GetDeviceInfo(ByVal iDeviceID As Integer) As DataTable
            Dim strsql As String = ""

            Try
                strsql = "select tworkorder.group_id, tdevice.device_id, tlocation.cust_id, tdevice.model_id, tmodel.manuf_id, tcellopt.cellopt_id, LensSUG_ID, " & Environment.NewLine
                strsql &= "tcellopt.CellOpt_IMEI, tcellopt.CellOpt_MSN, tcellopt.CellOpt_CSN, tcellopt.CellOpt_Transceiver, tcellopt.CellOpt_SoftVerIN, tmodel.Model_GSM, tmodel.Dcode_ID, tmodel.Model_Type " & Environment.NewLine
                strsql &= "from tcellopt " & Environment.NewLine
                strsql &= "inner join tdevice on tdevice.device_id = tcellopt.device_id " & Environment.NewLine
                strsql &= "inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & Environment.NewLine
                strsql &= "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & Environment.NewLine
                strsql &= "inner join tmodel on tdevice.model_id = tmodel.model_id " & Environment.NewLine
                strsql &= "left outer join llenssugdefault on tdevice.model_id = llenssugdefault.model_id AND tcellopt.CellOpt_Transceiver = llenssugdefault.LensSUG_text " & Environment.NewLine
                strsql &= "where tcellopt.Device_ID = " & iDeviceID & " " & Environment.NewLine
                strsql &= "order by tcellopt.device_id desc;"

                Return Me._objDataProc.GetDataTable(strsql)

            Catch ex As Exception
                Throw New Exception("Business.MClaim.GetCustIDFromIMEI(): " & ex.ToString)
            End Try
        End Function

        '******************************************************************
        Private Function GetCSCarrier_MotoDesc(ByVal iCustID As Integer, _
                                         ByVal strIMEI As String) As String
            Dim strsql As String = ""
            Dim dt1 As DataTable
            Dim strvar As String = ""

            Try
                strsql = "select cs_carrier.carrier_id, cs_carrier.carrier_MotoDesc " & Environment.NewLine
                strsql &= "from cstincomingdata " & Environment.NewLine
                strsql &= "inner join cs_partmap on cstincomingdata.csin_ItemNum = cs_partmap.part_number " & Environment.NewLine
                strsql &= "inner join cs_carrier on cs_partmap.carrier_id = cs_carrier.carrier_id " & Environment.NewLine
                strsql &= "where cstincomingdata.csin_esn = '" & strIMEI & "' and" & Environment.NewLine
                strsql &= "cstincomingdata.flgReceived = 1 order by csin_id desc;"
                dt1 = Me._objDataProc.GetDataTable(strsql)

                If dt1.Rows.Count > 0 Then
                    If Not IsDBNull(dt1.Rows(0)("carrier_MotoDesc")) Then
                        strvar = (dt1.Rows(0)("carrier_MotoDesc"))
                    Else
                        strvar = ""
                    End If
                Else
                    strvar = ""
                End If
                Return strvar
            Catch ex As Exception
                Throw New Exception("Business.MClaim.GetDeviceCarrier(): " & ex.ToString)
            Finally
                Buisness.Generic.DisposeDT(dt1)
            End Try
        End Function

        '******************************************************************
        Private Function CheckForWrtyBillcodes(ByVal iDevice_id As Integer, _
                                              ByVal iCust_id As Integer, _
                                              ByVal iModel_id As Integer) As Integer

            Dim strsql As String = ""
            Dim dt1 As DataTable
            Dim i As Integer = 0

            Try
                strsql = "select tdevicebill.billcode_id, lcodesdetail.Dcode_Sdesc " & Environment.NewLine
                strsql &= "from tdevicebill " & Environment.NewLine
                strsql &= "inner join tbillmap on tdevicebill.billcode_id = tbillmap.billcode_id " & Environment.NewLine
                strsql &= "inner join lbillcodes on tdevicebill.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
                strsql &= "inner join lcodesdetail on tbillmap.BMap_Transaction = lcodesdetail.Dcode_id " & Environment.NewLine
                strsql &= "where lcodesdetail.Dcode_Sdesc in ('REP', 'REW') and " & Environment.NewLine
                strsql &= "lcodesdetail.Prod_ID = 2 and " & Environment.NewLine
                strsql &= "lcodesdetail.Dcode_Inactive = 0 and " & Environment.NewLine
                strsql &= "bmap_inactive = 0 and " & Environment.NewLine
                strsql &= "BillType_ID = 2 and " & Environment.NewLine
                strsql &= "lcodesdetail.Manuf_ID = 1 and " & Environment.NewLine
                strsql &= "tbillmap.Cust_Id = " & iCust_id & " and " & Environment.NewLine
                strsql &= "tbillmap.Model_ID = " & iModel_id & " and " & Environment.NewLine
                strsql &= "tdevicebill.device_id = " & iDevice_id & ";"

                dt1 = Me._objDataProc.GetDataTable(strsql)

                If dt1.Rows.Count > 0 Then
                    If Trim(dt1.Rows(0)("Dcode_Sdesc")) = "REP" Then
                        i = 1
                    ElseIf Trim(dt1.Rows(0)("Dcode_Sdesc")) = "REW" Then
                        i = 2
                    End If
                End If

                Return i
            Catch ex As Exception
                Throw New Exception("Business.MClaim.CheckWrtyableBillcode(): " & ex.ToString)
            Finally
                Buisness.Generic.DisposeDT(dt1)
            End Try
        End Function

        '******************************************************************
        Private Function GetDCodeID(ByVal strCarrier_MotoDesc As String) As Integer
            Dim strsql As String = ""
            Dim dt1 As DataTable

            Try
                strsql = "select dcode_id from lcodesdetail where dcode_inactive = 0 and mcode_id = 1 and prod_id = 2 and manuf_id = 1 and dcode_sdesc = '" & strCarrier_MotoDesc & "';"
                dt1 = Me._objDataProc.GetDataTable(strsql)

                If dt1.Rows.Count > 0 Then
                    Return dt1.Rows(0)("dcode_id")
                Else
                    Return 0
                End If

            Catch ex As Exception
                Throw New Exception("Business.MClaim.CheckWrtyableBillcode(): " & ex.ToString)
            Finally
                Buisness.Generic.DisposeDT(dt1)
            End Try
        End Function

        '******************************************************************
        Public Function UpdateMClaimData(ByVal iCellopt_id As Integer, _
                                         ByVal strIMEI As String, _
                                         ByVal strMSN_CSN As String, _
                                         ByVal strSJUG As String, _
                                         ByVal strSoftVer As String, _
                                         ByVal iGSMFlag As Integer, _
                                         ByVal iDevice_id As Integer, _
                                         ByVal iDCode_id As Integer) As Integer

            Dim objGeneric As New PSS.Data.Buisness.Generic()
            Dim strDate As String = objGeneric.MySQLServerDateTime(1)
            Dim strsql As String = ""
            Dim dt1 As DataTable
            Dim i As Integer = 0

            Try

                '**************************************
                'Check for exist record in tdevicecodes
                strsql = "SELECT * FROM tdevicecodes where device_id = " & iDevice_id & " and dcode_id = " & iDCode_id & ";"
                dt1 = Me._objDataProc.GetDataTable(strsql)
                If dt1.Rows.Count = 0 Then
                    '**************************
                    'no data found in tdevicecode, 
                    ' insert into tdevicecodes
                    strsql = "INSERT INTO tdevicecodes (device_id, dcode_id) VALUES(" & iDevice_id & ", " & iDCode_id & ");"
                    i = Me._objDataProc.ExecuteNonQuery(strsql)
                End If


                '*****************************************
                'update tcellopt
                strsql = "update tcellopt, tdevice set " & Environment.NewLine
                'strsql &= "Cellopt_WIPOwnerOld = Cellopt_WIPOwner, " & Environment.NewLine
                'strsql &= "Cellopt_WIPOwner = " & iNewWipOwner & ", " & Environment.NewLine
                'strsql &= "Cellopt_WIPEntryDt = '" & strDate & "', " & Environment.NewLine

                strsql &= " tdevice.Device_ManufWrty = 1, " & Environment.NewLine

                If iGSMFlag = 1 Then
                    strsql &= "tcellopt.CellOpt_MSN = '" & strMSN_CSN & "', " & Environment.NewLine
                    strsql &= "tcellopt.CellOpt_OutMSN = '" & strMSN_CSN & "', " & Environment.NewLine
                Else
                    strsql &= "tcellopt.CellOpt_CSN = '" & strMSN_CSN & "', " & Environment.NewLine
                    strsql &= "tcellopt.CellOpt_OutCSN = '" & strMSN_CSN & "', " & Environment.NewLine
                End If

                strsql &= "tcellopt.CellOpt_Transceiver = '" & strSJUG & "', " & Environment.NewLine
                strsql &= "tcellopt.CellOpt_SugIn = '" & strSJUG & "', " & Environment.NewLine
                strsql &= "tcellopt.CellOpt_SugOut = '" & strSJUG & "', " & Environment.NewLine
                strsql &= "tcellopt.CellOpt_SoftVerIN = '" & strSoftVer & "', " & Environment.NewLine
                strsql &= "tcellopt.CellOpt_SoftVerOUT = '" & strSoftVer & "' " & Environment.NewLine
                strsql &= "where tcellopt.cellopt_id = " & iCellopt_id & " and " & Environment.NewLine
                strsql &= "tcellopt.device_id = tdevice.device_id and " & Environment.NewLine
                strsql &= "tcellopt.CellOpt_IMEI = '" & strIMEI & "';"

                Return Me._objDataProc.ExecuteNonQuery(strsql)

            Catch ex As Exception
                Throw New Exception("Business.MClaim.UpdateMClaimData(): " & ex.ToString)
            Finally
                objGeneric = Nothing
                Buisness.Generic.DisposeDT(dt1)
            End Try
        End Function

        '******************************************************************
        Public Function GetNewOwner(ByVal iCust_id As Integer, _
                                    ByVal iModel_id As Integer, _
                                    ByVal iLineID As Integer, _
                                    ByVal iParentGroupID As Integer) As Integer
            Dim strsql As String = ""
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim iPrevBucket As Integer = 0

            Try
                strsql = "select LPF_Sequence, LPF_Bucket " & Environment.NewLine
                strsql &= "from tlineprocessflow " & Environment.NewLine
                strsql &= "where line_id = " & iLineID & " and " & Environment.NewLine
                strsql &= "cust_id = " & iCust_id & " and " & Environment.NewLine
                strsql &= "model_id = " & iModel_id & " & Environment.NewLine"
                strsql &= "order by LPF_Sequence asc;"
                dt1 = Me._objDataProc.GetDataTable(strsql)

                If dt1.Rows.Count > 0 Then
                    For Each R1 In dt1.Rows
                        If iPrevBucket > 0 Then Return R1("LPF_Bucket")
                        If R1("LPF_Bucket") = iParentGroupID Then iPrevBucket = R1("LPF_Bucket")
                    Next R1
                Else
                    Return 0
                End If

            Catch ex As Exception
                Throw New Exception("Business.MClaim.CheckWrtyableBillcode(): " & ex.ToString)
            Finally
                Buisness.Generic.DisposeDT(dt1)
                R1 = Nothing
            End Try
        End Function

        '******************************************************************
        'Insert an empty row into the datatable
        '******************************************************************
        Private Function InsertEmptyRow(ByRef dt As DataTable, _
                                        Optional ByVal iEmptyRowValue As Integer = 0, _
                                        Optional ByVal strFiledName1 As String = "", _
                                        Optional ByVal strFieldName2 As String = "", _
                                        Optional ByVal strFieldName3 As String = "", _
                                        Optional ByVal strFieldName4 As String = "", _
                                        Optional ByVal strEmptyRowDisplay As String = "")
            Dim R1 As DataRow

            Try
                R1 = dt.NewRow
                If strFiledName1 <> "" Then
                    R1(strFiledName1) = iEmptyRowValue
                End If
                If strFieldName2 <> "" Then
                    R1(strFieldName2) = strEmptyRowDisplay
                End If

                dt.Rows.Add(R1)
            Catch ex As Exception
                Throw New Exception("Buisness.Misc.InsertEmptyRow(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                R1 = Nothing
            End Try
        End Function

        '******************************************************************
        Public Function GetMotoSUGNumbers(ByVal iModel_ID As Integer, _
                                          Optional ByVal iAddSelectRowFlg As Integer = 0, _
                                          Optional ByRef combo As ComboBox = Nothing) As DataTable
            Dim strsql As String = ""
            Dim dt1 As DataTable

            Try
                If iAddSelectRowFlg = 1 Then
                    strsql = "Select llenssugdefault.LensSUG_ID, llenssugdefault.LensSUG_text from llenssugdefault where model_id = " & iModel_ID & " order by LensSUG_text;"
                    dt1 = Me._objDataProc.GetDataTable(strsql)
                    InsertEmptyRow(dt1, , "LensSUG_ID", "LensSUG_text", , , "-- Select --")
                Else
                    strsql = "Select * from llenssugdefault where model_id = " & iModel_ID & " order by LensSUG_text;"
                    dt1 = Me._objDataProc.GetDataTable(strsql)
                End If

                If Not IsNothing(combo) Then
                    If iAddSelectRowFlg = 0 Then
                        InsertEmptyRow(dt1, , "LensSUG_ID", "LensSUG_text", , , "-- Select --")
                    End If

                    With combo
                        .DataSource = dt1.DefaultView
                        .DisplayMember = dt1.Columns("LensSUG_text").ToString
                        .ValueMember = dt1.Columns("LensSUG_ID").ToString
                        .SelectedValue = 0
                    End With
                End If

                Return dt1
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt1)
            End Try
        End Function

        '******************************************************************
        Public Function GetAllMotorolaAPCCodes() As DataTable
            Dim strsql As String = ""
            Dim dt1 As DataTable

            Try
                strsql = "Select dcode_id, dcode_sdesc from lcodesdetail where Mcode_Id = 6 and Dcode_Inactive = 0 and lcodesdetail.Manuf_ID = 1 order by dcode_sdesc;"
                dt1 = Me._objDataProc.GetDataTable(strsql)
                InsertEmptyRow(dt1, , "Dcode_ID", "Dcode_Sdesc", , , "-- Select --")
                Return dt1
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt1)
            End Try
        End Function

        '******************************************************************
        'Insert an empty row into the datatable
        '******************************************************************
        Public Function GetMotorolaAPCCodeDesc(ByVal iDcode_id As Integer) As String
            Dim strsql As String = ""
            Dim dt1 As DataTable
            Dim Dcode_Sdesc As String = ""

            Try
                strsql = "Select dcode_sdesc from lcodesdetail where Dcode_id = " & iDcode_id & ";"
                dt1 = Me._objDataProc.GetDataTable(strsql)

                If dt1.Rows.Count > 0 Then
                    Dcode_Sdesc = Trim(dt1.Rows(0)("dcode_sdesc"))
                End If

                Return Dcode_Sdesc
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt1)
            End Try
        End Function

        '******************************************************************
        'add entry into llenssugdefault
        '******************************************************************
        Public Function AddSUG(ByVal iModel_id As Integer, _
                                ByVal strSJUG As String, _
                                Optional ByVal iLensSUGID As Integer = 0) As Integer
            Dim strsql As String = ""
            Dim i As Integer = 0

            Try
                CheckIfSUGExists(iModel_id, strSJUG)

                If iLensSUGID = 0 Then
                    strsql = "INSERT INTO llenssugdefault (Model_id,LensSUG_text) VALUES " & Environment.NewLine
                    strsql &= "(" & iModel_id & ", '" & strSJUG & "');"
                    i = Me._objDataProc.ExecuteNonQuery(strsql)
                Else
                    strsql = "Update llenssugdefault set LensSUG_text = '" & strSJUG & "' where LensSUG_ID = " & iLensSUGID & ";"
                    i = Me._objDataProc.ExecuteNonQuery(strsql)
                End If

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Private Sub CheckIfSUGExists(ByVal iModel_id As Integer, _
                                     ByVal strSJUG As String)
            Dim dt1 As DataTable
            Dim strsql As String = ""

            Try
                strsql = "select * from llenssugdefault " & Environment.NewLine
                strsql &= "where Model_id = " & iModel_id & " and  " & Environment.NewLine
                strsql &= "LensSUG_text = '" & Trim(strSJUG) & "';"
                dt1 = Me._objDataProc.GetDataTable(strsql)

                If dt1.Rows.Count > 0 Then
                    Throw New Exception("SUG number already exist in the system.")
                End If

            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt1)
            End Try
        End Sub

        '******************************************************************
        Public Function IsAPC_CodeExisted(ByVal strScanAPC_Code As String) As Integer
            Dim dt1 As DataTable
            Dim strsql As String = ""

            Try
                strsql = "select count(*) as cnt from lcodesdetail where mcode_id = 6 and Dcode_Inactive = 0 and dcode_sdesc = '" & strScanAPC_Code & "';"
                dt1 = Me._objDataProc.GetDataTable(strsql)

                Return dt1.Rows(0)("cnt")
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt1)
            End Try
        End Function

        '******************************************************************
        Public Function GetMotoSoftwareVersion(ByVal iModel_ID As Integer, _
                                               Optional ByVal iAddSelectRowFlg As Integer = 0, _
                                               Optional ByRef combo As ComboBox = Nothing) As DataTable
            Dim strsql As String = ""
            Dim dt1 As DataTable

            Try
                If iAddSelectRowFlg = 1 Then
                    strsql = "SELECT sv_ID, sv_SoftwareVersion FROM lmoto_softwareversion WHERE sv_model_id = " & iModel_ID & ";"
                    dt1 = Me._objDataProc.GetDataTable(strsql)
                    InsertEmptyRow(dt1, , "sv_ID", "sv_SoftwareVersion", , , "-- Select --")
                Else
                    strsql = "SELECT * FROM lmoto_softwareversion WHERE sv_model_id = " & iModel_ID & ";"
                    dt1 = Me._objDataProc.GetDataTable(strsql)
                End If

                If Not IsNothing(combo) Then
                    If iAddSelectRowFlg = 0 Then
                        InsertEmptyRow(dt1, , "sv_ID", "sv_SoftwareVersion", , , "-- Select --")
                    End If

                    With combo
                        .DataSource = dt1.DefaultView
                        .DisplayMember = dt1.Columns("sv_SoftwareVersion").ToString
                        .ValueMember = dt1.Columns("sv_ID").ToString
                        .SelectedValue = 0
                    End With
                End If

                Return dt1
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt1)
            End Try
        End Function

        '******************************************************************
        Public Function GetSendMotorolaClaimFlg() As Integer
            Dim strsql As String = ""
            Dim dt1 As DataTable
            Dim iFlg As Integer = 0

            Try
                strsql = "SELECT  ConstValue FROM lconstants WHERE ShortDesc = 'SEND_MCLAIM';"
                dt1 = Me._objDataProc.GetDataTable(strsql)

                If dt1.Rows.Count > 0 Then
                    iFlg = dt1.Rows(0)("ConstValue")
                End If

                Return iFlg
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt1)
            End Try
        End Function

        '******************************************************************
        Public Function GetSendNokiaClaimFlg() As Integer
            Dim strsql As String = ""
          
            Try
                strsql = "SELECT ConstValue FROM lconstants WHERE ShortDesc = 'SEND_NKCLAIM';"
                Return Me._objDataProc.GetIntValue(strsql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Shared Function CalWarrantyStatus(ByVal strMSN As String, _
                                                 ByRef _strLastDateInWrty As String) As Integer
            Dim iWrtyStattus As Integer = 0
            Dim booInWrty As Boolean = False
            Dim objUnderWrty As UnderWarrantyNET1.UWNET1

            Try
                objUnderWrty = New UnderWarrantyNET1.UWNET1()

                booInWrty = objUnderWrty.UnderWarranty(strMSN)
                _strLastDateInWrty = objUnderWrty.LastDayOfWarranty(strMSN)

                If booInWrty = True Then iWrtyStattus = 1

                Return iWrtyStattus
            Catch ex As Exception
                Throw ex
            Finally
                objUnderWrty = Nothing
            End Try
        End Function

        '******************************************************************
        Public Function InsertUpdateSoftVersionList(ByVal iModelID As Integer, _
                                                    ByVal strSoftVer As String, _
                                                    Optional ByVal iSofVerID As Integer = 0) As Integer
            Dim strsql As String = ""
            Dim dt1 As DataTable
            Dim i = 0

            Try
                strsql = "SELECT * " & Environment.NewLine
                strsql &= "FROM lmoto_softwareversion  " & Environment.NewLine
                strsql &= "WHERE sv_Model_ID = " & iModelID & Environment.NewLine
                strsql &= "AND sv_SoftwareVersion = '" & strSoftVer & "';"
                dt1 = Me._objDataProc.GetDataTable(strsql)

                If dt1.Rows.Count > 0 Then
                    MessageBox.Show("Software version is already existed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    If iSofVerID = 0 Then
                        strsql = "INSERT INTO lmoto_softwareversion ( sv_Model_ID, sv_SoftwareVersion " & Environment.NewLine
                        strsql &= ") VALUES ( " & Environment.NewLine
                        strsql &= iModelID & ", '" & strSoftVer & "' " & Environment.NewLine
                        strsql &= ");"
                    Else
                        strsql = "UPDATE lmoto_softwareversion " & Environment.NewLine
                        strsql &= "SET sv_SoftwareVersion = '" & strSoftVer & "'" & Environment.NewLine
                        strsql &= "WHERE sv_ID = " & iSofVerID & Environment.NewLine
                    End If

                    i = Me._objDataProc.ExecuteNonQuery(strsql)
                End If

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt1)
            End Try
        End Function

        '******************************************************************
        Public Function GetAPCCode(ByVal iModelID As Integer) As String
            Dim strSql As String = ""
            Try
                strSql = "SELECT lcodesdetail.Dcode_Sdesc " & Environment.NewLine
                strSql &= "FROM tmodel " & Environment.NewLine
                strSql &= "INNER JOIN lcodesdetail ON tmodel.Dcode_ID = lcodesdetail.Dcode_id AND lcodesdetail.Mcode_Id = 6 " & Environment.NewLine
                strSql &= "AND tmodel.Manuf_ID = lcodesdetail.Manuf_ID AND tmodel.Prod_ID = lcodesdetail.Prod_ID " & Environment.NewLine
                strSql &= "WHERE Model_ID = " & iModelID & Environment.NewLine
                Return Me._objDataProc.GetSingletonString(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************

    End Class

End Namespace