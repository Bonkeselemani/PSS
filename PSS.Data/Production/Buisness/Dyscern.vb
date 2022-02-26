'Option Explicit On 

'Namespace Buisness

'    Public Class Dyscern

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
'        Public Function LoadASNFile(ByVal strWoName As String, _
'                                    ByVal iUserID As Integer, _
'                                    ByVal strUserName As String, _
'                                    ByVal dt As DataTable, _
'                                    ByRef iTotalDuplicateUnits As Integer) As Integer
'            Const iGroup = 3
'            Dim iWOID As Integer = 0
'            Dim iTrayID As Integer = 0
'            Dim objRec As Production.Receiving
'            Dim objDR As DyscernReceiving
'            Dim R1 As DataRow
'            Dim iduplicate As Integer = 0
'            Dim strSql As String
'            Dim i As Integer = 0

'            Try
'                objRec = New Production.Receiving()
'                objDR = New DyscernReceiving()

'                '************************
'                '1:: Create WO
'                '************************
'                iWOID = objRec.InsertIntoTworkorder(strWoName, strWoName, DyscernReceiving.DYSCERN_LOCATION_ID, 2, iGroup, , , , , , )
'                If iWOID = 0 Then
'                    Throw New Exception("System has failed to create 'Work Order'.")
'                End If

'                '***********************************
'                '2:: Create Tray
'                '***********************************
'                iTrayID = objRec.InsertIntoTtray(iUserID, strUserName, CStr(iWOID), )
'                If iTrayID = 0 Then
'                    Throw New Exception("System has failed to create tray.")
'                End If

'                '***********************************
'                '3:: Insert data
'                '***********************************
'                For Each R1 In dt.Rows
'                    strSql = "select count(*) as cnt from tdyscerndata where dd_FileName = '" & strWoName & "' and dd_CustDeviceID = '" & R1("DID") & "'"
'                    If Me._objDataProc.GetIntValue(strSql) > 0 Then iduplicate = 1

'                    i += objDR.InsertIntoTdyscernData(R1("DID"), 1, iduplicate, 0, strWoName, iUserID)

'                    iTotalDuplicateUnits += iduplicate
'                    iduplicate = 0
'                Next R1

'                Return i
'            Catch ex As Exception
'                Throw ex
'            Finally
'                R1 = Nothing
'                objRec = Nothing
'                Generic.DisposeDT(dt)
'            End Try
'        End Function

'        '**************************************************************
'        Public Function IsWorkorderExisted(ByVal strWOName As String) As Boolean
'            Dim strSql As String

'            Try
'                strSql = "Select count(*) as cnt from tworkorder where wo_custwo = '" & strWOName & "' and loc_id = " & DyscernReceiving.DYSCERN_LOCATION_ID
'                If Me._objDataProc.GetIntValue(strSql) > 0 Then Return True Else Return False
'            Catch ex As Exception
'                Throw ex
'            End Try
'        End Function

'        '**************************************************************
'        Private Function InsertIntoTdy(ByVal strWOName As String) As Boolean
'            Dim strSql As String

'            Try
'                strSql = "Select count(*) as cnt from tworkorder where wo_custwo = '" & strWOName & "' and loc_id = " & DyscernReceiving.DYSCERN_LOCATION_ID
'                If Me._objDataProc.GetIntValue(strSql) > 0 Then Return True Else Return False
'            Catch ex As Exception
'                Throw ex
'            End Try
'        End Function

'        '**************************************************************
'        Public Function ReceivingDetailRptByWO(ByVal strWOName As String) As Integer
'            Dim strSql As String
'            Dim dt As DataTable

'            Try
'                strSql = "SELECT dd_FileName as 'WO', dd_CustDeviceID as 'DID' " & Environment.NewLine
'                strSql &= ", if( dd_UnlockCode is not null, dd_UnlockCode, '') as 'Unlock Code' " & Environment.NewLine
'                strSql &= ", if(dd_InFile = 1, 'Yes', 'No') as 'In File' " & Environment.NewLine
'                strSql &= ", if(dd_Duplicate = 1, 'Yes', 'No') as 'Duplicate' " & Environment.NewLine
'                strSql &= ", if(Device_SN is null, '', Device_SN) as 'IMEI' " & Environment.NewLine
'                strSql &= ", if(A.User_fullname is null, '', A.User_Fullname) as 'Receiver' " & Environment.NewLine
'                strSql &= ", if(tdevice.Device_DateRec is null, '', date_format(tdevice.Device_DateRec, '%m/%d/%Y %H:%i:%s') ) as 'Receive Date' " & Environment.NewLine
'                strSql &= "FROM tdyscerndata " & Environment.NewLine
'                strSql &= "LEFT OUTER JOIN tdevice On tdyscerndata.Device_ID = tdevice.Device_ID " & Environment.NewLine
'                strSql &= "LEFT OUTER JOIN security.tusers A On tdyscerndata.dd_RecUsrID = A.User_ID " & Environment.NewLine
'                strSql &= "WHERE tdyscerndata.dd_FileName ='" & strWOName & "' " & Environment.NewLine
'                dt = Me._objDataProc.GetDataTable(strSql)

'                If dt.Rows.Count > 0 Then Generic.CreateExelReport(dt, 0, , 1, , , , )

'                Return dt.Rows.Count
'            Catch ex As Exception
'                Throw ex
'            Finally
'                Generic.DisposeDT(dt)
'            End Try
'        End Function

'        '**************************************************************


'    End Class
'End Namespace
