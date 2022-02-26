
'Option Explicit On 

'Imports System.Windows.Forms

'Namespace Buisness
'    Public Class DyscernReceiving

'#Region "Properties"
'        '******************************************************************
'        Public Shared ReadOnly Property DYSCERN_CUSTOMER_ID() As Integer
'            Get
'                Return 2245
'            End Get
'        End Property

'        '******************************************************************
'        Public Shared ReadOnly Property DYSCERN_LOCATION_ID() As Integer
'            Get
'                Return 2769
'            End Get
'        End Property
'#End Region

'        Private _objDataProc As DBQuery.DataProc

'        '**************************************************************
'        Public Sub New()
'            Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
'        End Sub

'        '**************************************************************
'        Protected Overrides Sub Finalize()
'            Me._objDataProc = Nothing
'            MyBase.Finalize()
'        End Sub

'        '**************************************************************
'        Public Function CheckPSSWarranty(ByVal iLoc_ID As Integer, _
'                                         ByVal strDevSN As String) As Integer
'            Dim strSeverDt As String = ""
'            Dim strSql As String = ""
'            Dim dt1 As DataTable
'            Dim R1 As DataRow
'            Dim iResult As Integer = 0

'            Try
'                strSeverDt = Generic.MySQLServerDateTime(1)

'                strSql = "SELECT * FROM tdevice " & Environment.NewLine
'                strSql &= "WHERE tdevice.Device_SN = '" & strDevSN & "' " & Environment.NewLine
'                strSql &= "AND tdevice.Device_DateShip is not null " & Environment.NewLine
'                strSql &= "AND Loc_ID = " & iLoc_ID & Environment.NewLine
'                strSql &= "ORDER BY Device_DateShip DESC;"
'                dt1 = Me._objDataProc.GetDataTable(strSql)

'                For Each R1 In dt1.Rows
'                    If Not IsDBNull(R1("Device_DateShip")) Then
'                        If DateDiff(DateInterval.Day, CDate(R1("Device_DateShip")), CDate(strSeverDt)) <= 90 Then
'                            iResult = 1
'                        End If
'                    End If
'                Next R1

'                Return iResult
'            Catch ex As Exception
'                Throw ex
'            Finally
'                If Not IsNothing(dt1) Then
'                    dt1.Dispose()
'                    dt1 = Nothing
'                End If
'            End Try
'        End Function

'        '**************************************************************
'        Public Function RecDCDevicesIntoPSSWIP(ByVal strWoName As String, _
'                                              ByVal iWOID As Integer, _
'                                              ByVal iTrayID As Integer, _
'                                              ByVal iModel_ID As Integer, _
'                                              ByVal strUserName As String, _
'                                              ByVal iUser_ID As Integer, _
'                                              ByVal iEmpNo As Integer, _
'                                              ByVal iShift_ID As Integer, _
'                                              ByVal strWorkDate As String, _
'                                              ByVal dtDevices As DataTable) As Integer
'            Const iCell2Support_CCID As Integer = 38
'            Dim objRec As Production.Receiving
'            Dim strSql As String = ""
'            Dim R1 As DataRow
'            Dim iDevice_ID As Integer = 0
'            Dim i As Integer = 0
'            Dim strCustRepOrder As String = ""
'            Dim iCnt As Integer = 0

'            Try
'                objRec = New Production.Receiving()

'                '***********************************
'                'Loop through each device
'                '***********************************
'                For Each R1 In dtDevices.Rows
'                    iCnt += 1

'                    '************************
'                    '3:: Insert into tdevice
'                    '************************
'                    iDevice_ID = objRec.InsertIntoTdevice(R1("IMEI"), _
'                                                          strWorkDate, _
'                                                          iCnt, _
'                                                          iTrayID, _
'                                                          Me.DYSCERN_LOCATION_ID, _
'                                                          iWOID, _
'                                                          iModel_ID, _
'                                                          iShift_ID, _
'                                                          R1("PSS Warranty"), , , iCell2Support_CCID)
'                    If iDevice_ID = 0 Then
'                        Throw New Exception("System has failed to insert into tdevice.")
'                    End If

'                    '************************
'                    '4:: Insert into tcellopt
'                    '************************
'                    i = objRec.InsertIntoTCellopt(iDevice_ID, , , , , , , , , , , , , , )
'                    If i = 0 Then
'                        Throw New Exception("System has failed to insert into tcellopt.")
'                    End If

'                    '***************************
'                    '5:: Write Customer Device ID into tdyscerndata
'                    '***************************
'                    If R1("dd_id") = 0 Then 'missing
'                        i = Me.InsertIntoTdyscernData(R1("Device ID"), 0, 0, iDevice_ID, strWoName, iUser_ID)
'                    Else
'                        strSql = "update tdyscerndata set Device_ID = " & iDevice_ID & ", dd_RecUsrID = " & iUser_ID & " where dd_id = " & R1("dd_id")
'                        i = Me._objDataProc.ExecuteNonQuery(strSql)
'                    End If

'                    If i = 0 Then
'                        Throw New Exception("System has failed to write 'Customer Device ID' receive flag.")
'                    End If

'                    '***************************
'                    'Reset loop variable
'                    '***************************
'                    iDevice_ID = 0
'                    '***************************
'                Next R1

'                'update wo quantity
'                strSql = "Update tworkorder set WO_Quantity = " & Me.GetWORecQty(iWOID) & " where wo_id = " & iWOID & ";"
'                Me._objDataProc.ExecuteNonQuery(strSql)

'                Return iCnt
'            Catch ex As Exception
'                Throw ex
'            Finally
'                objRec = Nothing
'                R1 = Nothing
'                If Not IsNothing(dtDevices) Then
'                    dtDevices.Dispose()
'                    dtDevices = Nothing
'                End If
'            End Try
'        End Function

'        '**************************************************************
'        Public Function GetWORecQty(ByVal iWOID As Integer) As Integer
'            Dim strSql As String
'            Try
'                strSql = "select count(*) as cnt from tdevice where wo_id = " & iWOID
'                Return Me._objDataProc.GetIntValue(strSql)
'            Catch ex As Exception
'                Throw ex
'            End Try
'        End Function

'        '**************************************************************
'        Public Function InsertIntoTdyscernData(ByVal strCust_DeviceID As String, _
'                                               ByVal iInfile As Integer, _
'                                               ByVal iDuplicate As Integer, _
'                                               ByVal iDevice_ID As Integer, _
'                                               ByVal strFileName As String, _
'                                               ByVal iUsrID As Integer) As Integer
'            Dim strSql As String
'            Dim strField As String
'            Dim strData As String

'            Try
'                strField = "dd_CustDeviceID, dd_FileName, dd_InFile, dd_Duplicate " & Environment.NewLine
'                strData = "'" & strCust_DeviceID & "', '" & strFileName & "', " & iInfile & ", " & iDuplicate & Environment.NewLine
'                If iDevice_ID > 0 Then
'                    strField &= ", Device_ID, dd_RecUsrID " & Environment.NewLine
'                    strData &= ", " & iDevice_ID & ", " & iUsrID & " " & Environment.NewLine
'                Else
'                    strField &= ", dd_FileLoadDt, dd_FileLoadUsrID " & Environment.NewLine
'                    strData &= ", now(), " & iUsrID & " " & Environment.NewLine
'                End If
'                strSql = "INSERT INTO tdyscerndata (" & Environment.NewLine
'                strSql &= strField & ") VALUES ( " & strData & " )"
'                Return Me._objDataProc.ExecuteNonQuery(strSql)
'            Catch ex As Exception
'                Throw ex
'            End Try
'        End Function

'        '**************************************************************
'        Public Function GetWOIDTrayIDAndRecQty(ByVal iMachineGroupID As Integer, _
'                                              ByVal iUserID As Integer, _
'                                              ByVal strUserName As String, _
'                                              ByVal strWOName As String, _
'                                              ByRef iWOID As Integer, _
'                                              ByRef iTrayID As Integer, _
'                                              ByRef iRecQty As Integer) As Boolean
'            Dim strSql As String
'            Dim dt As DataTable
'            Dim booResult As Boolean = False
'            Dim objRec As Production.Receiving

'            Try
'                strSql = "select * from tworkorder where WO_CustWO = '" & strWOName & "' and Loc_ID = " & Me.DYSCERN_LOCATION_ID & "; "
'                dt = Me._objDataProc.GetDataTable(strSql)

'                If dt.Rows.Count = 0 Then
'                    MessageBox.Show("Workorder does not exist in the system. Please verify with your suppervisor.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
'                ElseIf dt.Rows.Count > 1 Then
'                    MessageBox.Show("This workorder " & strWOName.ToUpper & " existed more than one in the system. Please verify with your suppervisor.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
'                ElseIf dt.Rows.Count = 1 Then
'                    booResult = True

'                    iWOID = dt.Rows(0)("WO_ID")
'                    iRecQty = dt.Rows(0)("WO_Quantity")

'                    'Get Tray ID
'                    strSql = "select Tray_ID from ttray where wo_id = " & iWOID & " order by tray_id desc"
'                    iTrayID = Me._objDataProc.GetIntValue(strSql)
'                    If iTrayID = 0 Then
'                        '***********************************
'                        '1:: Create Tray
'                        '***********************************
'                        objRec = New Production.Receiving()
'                        iTrayID = objRec.InsertIntoTtray(iUserID, strUserName, CStr(iWOID), )
'                        If iTrayID = 0 Then
'                            Throw New Exception("System has failed to create tray.")
'                        End If
'                    End If
'                End If

'                Return booResult
'            Catch ex As Exception
'                Throw ex
'            Finally
'                objRec = Nothing
'                Generic.DisposeDT(dt)
'            End Try
'        End Function

'        '**************************************************************
'        Public Function GetFileQty(ByVal strWOName As String) As Integer
'            Dim strSql As String

'            Try
'                strSql = "select count(*) as cnt from tdyscerndata where dd_FileName = '" & strWOName & "';"
'                Return Me._objDataProc.GetIntValue(strSql)
'            Catch ex As Exception
'                Throw ex
'            End Try
'        End Function

'        '**************************************************************
'        Public Function GetDeviceDataFileInfo(ByVal strDID As String, ByVal strWOName As String) As DataTable
'            Dim strSql As String

'            Try
'                strSql = "select tdyscerndata.*  " & Environment.NewLine
'                strSql &= ", if(Device_SN is null, '', Device_SN ) as IMEI " & Environment.NewLine
'                strSql &= "from tdyscerndata " & Environment.NewLine
'                strSql &= "left outer join tdevice ON tdyscerndata.Device_ID = tdevice.Device_ID " & Environment.NewLine
'                strSql &= "where dd_FileName = '" & strWOName & "' " & Environment.NewLine
'                strSql &= "and dd_CustDeviceID = '" & strDID & "' " & Environment.NewLine
'                strSql &= "and dd_Duplicate = 0 " & Environment.NewLine
'                Return Me._objDataProc.GetDataTable(strSql)
'            Catch ex As Exception
'                Throw ex
'            End Try
'        End Function

'        '**************************************************************

'    End Class
'End Namespace
