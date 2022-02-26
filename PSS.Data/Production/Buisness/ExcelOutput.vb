'Imports DBQuery.DataProc
'Imports eInfoDesigns.dbProvider.MySqlClient
'Imports PSS.Data.Production
'Imports System.Windows.Forms

'Namespace Buisness
'    Public Class ExcelOutput
'        Public Enum ReportType
'            CELLULAR = 1
'            GAME_STOP = 2
'            MESSAGING = 3
'        End Enum

'        Dim _objSumMgrReportData_Cell As SummaryManagerReportData_Cell
'        Dim _objSumMgrReportData_GS As SummaryManagerReportData_GSMsg
'        Dim _objSumMgrReportData_Msg As SummaryManagerReportData_GSMsg

'        Public Sub New()
'            Me._objSumMgrReportData_Cell = New SummaryManagerReportData_Cell()
'            Me._objSumMgrReportData_GS = New SummaryManagerReportData_GSMsg()
'            Me._objSumMgrReportData_Msg = New SummaryManagerReportData_GSMsg()
'        End Sub

'        Public Function SetData(ByVal datStart As Date, ByVal datEnd As Date, Optional ByVal bGetGSMsgData As Boolean = True)
'            Me._objSumMgrReportData_Cell.SetData(datStart, datEnd)

'            If bGetGSMsgData Then
'                Me._objSumMgrReportData_GS.SetData(datStart, datEnd, SummaryManagerReportData_GSMsg.Groups.GAME_STOP)
'                Me._objSumMgrReportData_Msg.SetData(datStart, datEnd, SummaryManagerReportData_GSMsg.Groups.MESSAGING)
'            End If
'        End Function

'        Public Function GetTechData(ByVal rt As ReportType) As DataTable
'            Select Case rt
'                Case ReportType.CELLULAR
'                    Return Me._objSumMgrReportData_Cell.GetTechData
'                Case ReportType.GAME_STOP
'                    Return Me._objSumMgrReportData_GS.GetTechData
'                Case ReportType.MESSAGING
'                    Return Me._objSumMgrReportData_Msg.GetTechData
'            End Select
'        End Function

'        Public Function GetDeviceCount(ByVal iEEID As Integer) As Integer
'            Return Me._objSumMgrReportData_Cell.GetDeviceCount(iEEID)
'        End Function

'        Public Function GetRURRTMCount(ByVal iEEID As Integer, ByVal iBillCodeRule As Integer) As Integer
'            Return Me._objSumMgrReportData_Cell.GetRURRTMCount(iEEID, iBillCodeRule)
'        End Function

'        Public Function GetGoodCount(ByVal iEEID As Integer) As Integer
'            Return Me._objSumMgrReportData_Cell.GetGoodCount(iEEID)
'        End Function

'        Public Function GetRejectCount(ByVal iEEID As Integer) As Integer
'            Return Me._objSumMgrReportData_Cell.GetRejectCount(iEEID)
'        End Function

'        Public Function GetTechHours(ByVal iTechID As Integer) As Double
'            Return Me._objSumMgrReportData_Cell.GetTechHours(iTechID)
'        End Function

'        Public Function GetLaborValue(ByVal iEEID As Integer) As Double
'            Return Me._objSumMgrReportData_Cell.GetLaborValue(iEEID)
'        End Function

'        Public Function GetTechRate(ByVal iEEID As Integer) As Double
'            Return Me._objSumMgrReportData_Cell.GetTechRate(iEEID)
'        End Function

'        Public Function GetPartsValue(ByVal iEEID As Integer) As Double
'            Return Me._objSumMgrReportData_Cell.GetPartsValue(iEEID)
'        End Function

'        Public Function GetActualPoints(ByVal iEEID As Integer) As Double
'            Return Me._objSumMgrReportData_Cell.GetActualPoints(iEEID)
'        End Function

'        Public Function GetGoalPoints(ByVal dblHoursWorked As Double) As Double
'            Return Me._objSumMgrReportData_Cell.GetGoalPoints(dblHoursWorked)
'        End Function

'        Public Function GetStandardPointGoalsPerHour() As Double
'            Return Me._objSumMgrReportData_Cell.GetStandardPointGoalsPerHour
'        End Function

'        Public Function GetRejectPoints(ByVal iEEID As Integer, ByVal dblFactor As Double)
'            Return Me._objSumMgrReportData_Cell.GetRejectPoints(iEEID, dblFactor)
'        End Function

'        Public Sub DisplayMessage(ByVal strMsg As String, Optional ByVal iStackIndex As Integer = 3, Optional ByVal bIsErrMsg As Boolean = True)
'            Me._objSumMgrReportData_Cell.DisplayMessage(strMsg, iStackIndex, bIsErrMsg)
'        End Sub

'        Public Function GetTechHours(ByVal iTechNumber As Integer, ByVal rt As ReportType) As Double
'            Select Case rt
'                Case ReportType.GAME_STOP
'                    Return Me._objSumMgrReportData_GS.GetTechHours(iTechNumber)
'                Case ReportType.MESSAGING
'                    Return Me._objSumMgrReportData_Msg.GetTechHours(iTechNumber)
'            End Select
'        End Function

'        Public Function GetProduction(ByVal iTechNumber As Integer, ByVal rt As ReportType) As Integer
'            Select Case rt
'                Case ReportType.GAME_STOP
'                    Return Me._objSumMgrReportData_GS.GetProduction(iTechNumber)
'                Case ReportType.MESSAGING
'                    Return Me._objSumMgrReportData_Msg.GetProduction(iTechNumber)
'            End Select
'        End Function

'        Private Class SummaryManagerReportData_Cell
'            Inherits DataSet

'            Private Const _strTechData As String = "Tech Data"
'            Private Const _strModelData As String = "Model Data"
'            Private Const _strModelDetailsData As String = "Model Details Data"
'            Private Const _strGoodCountData As String = "Good Count Data"
'            Private Const _strRejectCountData As String = "Reject Count Data"
'            Private Const _strLaborValueData As String = "Labor Value Data"
'            Private Const _strPartsValueData As String = "Parts Value Data"
'            Private Const _strTechHoursData As String = "Tech Hours Data"
'            Private Const _strRURRTMData As String = "RURRTM Data"
'            Private Const _strQCData As String = "QC Data"

'            Private Const _dblStandardPointGoalsPerHour As Double = 10.0

'            Private _strStartDate As String = Format(Now, "yyyy-MM-dd")
'            Private _strEndDate As String = Format(Now, "yyyy-MM-dd")
'            Private _strTechIDIn As String = ""
'            Private _strDeviceIDIn As String = ""
'            Private _strModelIDIn As String = ""

'            Private _objDataProc As DBQuery.DataProc

'            Public Sub New()
'                Me.DataSetName = "Summary Manager's Report Data - Cellular"
'                Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
'            End Sub

'#Region "Set Data"
'            Public Sub SetData(ByVal datStart As Date, ByVal datEnd As Date)
'                SetStartEndDates(datStart, datEnd) ' MUST be called before anything else
'                TechData()
'                ModelData()
'                ModelDetails()
'                GetGoodCountData()
'                GetRejectCountData()
'                LaborValue()
'                PartsValue()
'                TechHours()
'                RURRTM()
'                DeviceQC()
'            End Sub

'            Private Sub SetStartEndDates(ByVal datStart As Date, ByVal datEnd As Date) ' MUST be called before anything else
'                Try
'                    Me._strStartDate = datStart.ToString("yyyy-MM-dd") & " 06:00:00" ' Start of first shift
'                    Me._strEndDate = DateAdd(DateInterval.Day, 1, datEnd).ToString("yyyy-MM-dd") & " 04:00:00" ' Past end of second shift
'                Catch ex As Exception
'                    Me._objDataProc.DisplayMessage(ex.Message)
'                End Try
'            End Sub

'            Private Sub TechData()
'                ' Get list of technicians and technician data for report
'                Dim strSQL As String
'                Dim dt As DataTable
'                Dim sf As New StackFrame(0)

'                Try
'                    strSQL = "SELECT DISTINCT B.user_fullname, CAST(B.employeeno AS UNSIGNED) AS employeeno, B.shift_id AS Shift_ID, B.TechRate, D.group_id, D.group_desc AS Group_Desc, A.device_id AS Device_ID " & Environment.NewLine
'                    strSQL &= "FROM tcellopt A " & Environment.NewLine
'                    strSQL &= "INNER JOIN security.tusers B ON A.cellopt_refurbcompleteuserid = B.user_id " & Environment.NewLine
'                    strSQL &= "INNER JOIN tdevice C ON A.device_id = C.device_id " & Environment.NewLine
'                    strSQL &= "INNER JOIN lgroups D ON B.group_id = D.group_id " & Environment.NewLine
'                    strSQL &= "INNER JOIN tmodel E ON E.model_id = C.model_id " & Environment.NewLine
'                    strSQL &= "WHERE A.cellopt_refurbcompletedt BETWEEN '" & Me._strStartDate & "' AND '" & Me._strEndDate & "' " & Environment.NewLine
'                    strSQL &= "AND E.model_type IN (0, 1) " & Environment.NewLine
'                    strSQL &= "AND B.is_user_refurber = 1 " & Environment.NewLine
'                    strSQL &= "ORDER BY B.user_fullname"

'                    AddTable(Me._strTechData, strSQL)
'                    TechIDInString()
'                    DeviceIDInString()
'                Catch ex As Exception
'                    Me._objDataProc.DisplayMessage(ex.Message)
'                End Try
'            End Sub

'            Private Sub ModelData()
'                ' Get models for date range and technicians
'                Dim strSQL As String

'                Try
'                    strSQL = "SELECT CAST(A.cellopt_refurbcompleteuserid AS UNSIGNED) AS employeeno, C.model_id AS model_id, D.model_desc, IFNULL(E.gmf_unithour, 0) AS Unit_Hour " & Environment.NewLine
'                    strSQL &= "FROM tcellopt A " & Environment.NewLine
'                    strSQL &= "INNER JOIN security.tusers B ON A.cellopt_refurbcompleteuserid = B.user_id " & Environment.NewLine
'                    strSQL &= "INNER JOIN tdevice C ON A.device_id = C.device_id " & Environment.NewLine
'                    strSQL &= "INNER JOIN tmodel D ON C.model_id = D.model_id " & Environment.NewLine
'                    strSQL &= "LEFT JOIN tgroupmodelfactor E ON D.model_id = E.model_id AND B.group_id = E.group_id " & Environment.NewLine
'                    strSQL &= "WHERE cellopt_refurbcompletedt BETWEEN '" & Me._strStartDate & "' AND '" & Me._strEndDate & "' " & Environment.NewLine
'                    strSQL &= "AND A.cellopt_refurbcompleteuserid IN (" & Me._strTechIDIn & ") " & Environment.NewLine
'                    strSQL &= "AND D.model_type IN (0, 1) " & Environment.NewLine

'                    AddTable(Me._strModelData, strSQL)
'                    ModelIDInString()
'                Catch ex As Exception
'                    Me._objDataProc.DisplayMessage(ex.Message)
'                End Try
'            End Sub

'            Private Sub ModelDetails()
'                ' Get model details for date range and technician
'                Dim strSQL As String

'                Try
'                    strSQL = "SELECT DISTINCT A.device_id, max(E.qc_id) as maxID, E.qcresult_id, E.device_id as qcDeviceID, D.model_id AS model_id, CAST(A.cellopt_refurbcompleteuserid AS UNSIGNED) AS employeeno " & Environment.NewLine
'                    strSQL &= "FROM tcellopt A " & Environment.NewLine
'                    strSQL &= "INNER JOIN security.tusers B ON A.cellopt_refurbcompleteuserid = B.user_id " & Environment.NewLine
'                    strSQL &= "INNER JOIN tdevice C ON A.device_id = C.device_id " & Environment.NewLine
'                    strSQL &= "INNER JOIN tmodel D ON C.model_id = D.model_id " & Environment.NewLine
'                    strSQL &= "LEFT OUTER JOIN tqc E ON C.device_id = E.device_id " & Environment.NewLine
'                    strSQL &= "WHERE A.cellopt_refurbcompletedt BETWEEN '" & Me._strStartDate & "' AND '" & Me._strEndDate & "' " & Environment.NewLine
'                    strSQL &= "AND A.cellopt_refurbcompleteuserid IN (" & Me._strTechIDIn & ") " & Environment.NewLine
'                    strSQL &= "AND D.model_type IN (0, 1) " & Environment.NewLine
'                    strSQL &= "GROUP BY A.device_id " & Environment.NewLine

'                    AddTable(Me._strModelDetailsData, strSQL)
'                Catch ex As Exception
'                    Me._objDataProc.DisplayMessage(ex.Message)
'                End Try
'            End Sub

'            Private Sub TechIDInString()
'                Dim dr As DataRow
'                Dim arrlstIDs As New ArrayList()
'                Dim iIndex As Integer
'                Dim sf As New StackFrame(0)

'                Try
'                    Me._strTechIDIn = ""

'                    For Each dr In Me.Tables(Me._strTechData).Rows
'                        If arrlstIDs.IndexOf(dr("employeeno")) = -1 Then
'                            arrlstIDs.Add(dr("employeeno"))
'                        End If
'                    Next

'                    For iIndex = 0 To arrlstIDs.Count - 1
'                        If Me._strTechIDIn.Length > 0 Then Me._strTechIDIn &= ", "

'                        Me._strTechIDIn &= arrlstIDs(iIndex)
'                    Next
'                Catch ex As Exception
'                    Me._objDataProc.DisplayMessage(ex.Message)
'                End Try
'            End Sub

'            Private Sub DeviceIDInString()
'                Dim strSQL As String
'                Dim dt As DataTable
'                Dim dr As DataRow

'                Try
'                    Me._strDeviceIDIn = ""

'                    strSQL = "SELECT DISTINCT device_id " & Environment.NewLine
'                    strSQL &= "FROM tcellopt " & Environment.NewLine
'                    strSQL &= "WHERE cellopt_refurbcompletedt BETWEEN '" & Me._strStartDate & "' AND '" & Me._strEndDate & "' " & Environment.NewLine
'                    strSQL &= "AND cellopt_refurbcompleteuserid IN (" & Me._strTechIDIn & ")"

'                    dt = Me._objDataProc.GetDataTable(strSQL)

'                    If Not IsNothing(dt) Then
'                        If dt.Rows.Count > 0 Then
'                            For Each dr In dt.Rows
'                                If Me._strDeviceIDIn.Length > 0 Then Me._strDeviceIDIn &= ", "

'                                Me._strDeviceIDIn &= dr("device_id")
'                            Next
'                        End If
'                    End If
'                Catch ex As Exception
'                    Me._objDataProc.DisplayMessage(ex.Message)
'                Finally
'                    dr = Nothing

'                    If Not IsNothing(dt) Then
'                        dt.Dispose()
'                        dt = Nothing
'                    End If
'                End Try
'            End Sub

'            Private Sub ModelIDInString()
'                Dim arrlstIDs As New ArrayList()
'                Dim dr As DataRow
'                Dim bFound As Boolean

'                Try
'                    Me._strModelIDIn = ""

'                    If Not IsNothing(Me.Tables(Me._strModelData)) Then
'                        If Me.Tables(Me._strModelData).Rows.Count > 0 Then
'                            For Each dr In Me.Tables(Me._strModelData).Rows
'                                bFound = False

'                                If arrlstIDs.Count > 0 Then
'                                    If arrlstIDs.IndexOf(dr("model_id")) > -1 Then bFound = True
'                                End If

'                                If Not bFound Then
'                                    arrlstIDs.Add(dr("model_id"))

'                                    If Me._strModelIDIn.Length > 0 Then Me._strModelIDIn &= ", "

'                                    Me._strModelIDIn &= dr("model_id")
'                                End If
'                            Next
'                        End If
'                    End If
'                Catch ex As Exception
'                    Me._objDataProc.DisplayMessage(ex.Message)
'                End Try
'            End Sub

'            Private Sub GetGoodCountData()
'                Dim strSQL As String

'                Try
'                    strSQL = "SELECT CAST(A.cellopt_refurbcompleteuserid AS UNSIGNED) AS employeeno, COUNT(*) AS GoodCount " & Environment.NewLine
'                    strSQL &= "FROM tcellopt A " & Environment.NewLine
'                    strSQL &= "INNER JOIN security.tusers B ON A.cellopt_refurbcompleteuserid = B.user_id " & Environment.NewLine
'                    strSQL &= "INNER JOIN tdevice C ON A.device_id = C.device_id " & Environment.NewLine
'                    strSQL &= "INNER JOIN tmodel D ON C.model_id = D.model_id " & Environment.NewLine
'                    strSQL &= "WHERE A.cellopt_refurbcompletedt BETWEEN '" & Me._strStartDate & "' AND '" & Me._strEndDate & "' " & Environment.NewLine
'                    strSQL &= "AND A.cellopt_refurbcompleteuserid IN (" & Me._strTechIDIn & ") " & Environment.NewLine
'                    strSQL &= "AND A.device_id IN (" & Me._strDeviceIDIn & ") " & Environment.NewLine
'                    strSQL &= "AND D.model_type IN (0, 1) " & Environment.NewLine
'                    strSQL &= "GROUP BY CAST(A.cellopt_refurbcompleteuserid AS UNSIGNED) " & Environment.NewLine
'                    strSQL &= "ORDER BY CAST(A.cellopt_refurbcompleteuserid AS UNSIGNED)"

'                    AddTable(Me._strGoodCountData, strSQL)
'                Catch ex As Exception
'                    Me._objDataProc.DisplayMessage(ex.Message)
'                End Try
'            End Sub

'            Private Sub GetRejectCountData()
'                Dim strSQL As String

'                Try
'                    strSQL = "SELECT DISTINCT A.device_id, max(E.qc_id) as maxID, E.qcresult_id, E.device_id as qcDeviceID, CAST(A.cellopt_refurbcompleteuserid AS UNSIGNED) AS employeeno " & Environment.NewLine
'                    strSQL &= "FROM tcellopt A " & Environment.NewLine
'                    strSQL &= "INNER JOIN security.tusers B ON A.cellopt_refurbcompleteuserid = B.user_id " & Environment.NewLine
'                    strSQL &= "INNER JOIN tdevice C ON A.device_id = C.device_id " & Environment.NewLine
'                    strSQL &= "INNER JOIN tmodel D ON C.model_id = D.model_id " & Environment.NewLine
'                    strSQL &= "INNER JOIN tqc E ON E.device_ID = A.device_id " & Environment.NewLine
'                    strSQL &= "WHERE A.cellopt_refurbcompletedt BETWEEN '" & Me._strStartDate & "' AND '" & Me._strEndDate & "' " & Environment.NewLine
'                    strSQL &= "AND A.cellopt_refurbcompleteuserid IN (" & Me._strTechIDIn & ") " & Environment.NewLine
'                    strSQL &= "AND A.device_id IN (" & Me._strDeviceIDIn & ") " & Environment.NewLine
'                    strSQL &= "AND D.model_type IN (0, 1) " & Environment.NewLine
'                    strSQL &= "GROUP BY A.device_id " & Environment.NewLine
'                    strSQL &= "ORDER BY CAST(A.cellopt_refurbcompleteuserid AS UNSIGNED), A.device_id"

'                    AddTable(Me._strRejectCountData, strSQL)
'                Catch ex As Exception
'                    Me._objDataProc.DisplayMessage(ex.Message)
'                End Try
'            End Sub

'            Private Sub LaborValue()
'                ' Get total labor value for date range, technician and device
'                Dim strSQL As String
'                Dim dt As DataTable = Nothing

'                Try
'                    strSQL = "SELECT CAST(A.cellopt_refurbcompleteuserid AS UNSIGNED) as employeeno, SUM(C.device_laborcharge) AS LaborValue" & Environment.NewLine
'                    strSQL &= "FROM tcellopt A " & Environment.NewLine
'                    strSQL &= "INNER JOIN security.tusers B ON A.cellopt_refurbcompleteuserid = B.user_id " & Environment.NewLine
'                    strSQL &= "INNER JOIN tdevice C ON A.device_id = C.device_id " & Environment.NewLine
'                    strSQL &= "WHERE A.cellopt_refurbcompletedt BETWEEN '" & Me._strStartDate & "' AND '" & Me._strEndDate & "' " & Environment.NewLine
'                    strSQL &= "AND A.cellopt_refurbcompleteuserid IN (" & Me._strTechIDIn & ") " & Environment.NewLine
'                    strSQL &= "AND A.cellopt_qcreject <> 2 " & Environment.NewLine
'                    strSQL &= "AND C.model_id IN (" & Me._strModelIDIn & ") " & Environment.NewLine
'                    strSQL &= "GROUP BY CAST(A.cellopt_refurbcompleteuserid AS UNSIGNED)"

'                    AddTable(Me._strLaborValueData, strSQL)
'                Catch ex As Exception
'                    Me._objDataProc.DisplayMessage(ex.Message)
'                Finally
'                    If Not IsNothing(dt) Then
'                        dt.Dispose()
'                        dt = Nothing
'                    End If
'                End Try
'            End Sub

'            Private Sub PartsValue()
'                ' Get total parts value for date range, technician and device
'                Dim strSQL As String

'                Try
'                    strSQL = "SELECT CAST(A.cellopt_refurbcompleteuserid AS UNSIGNED) AS employeeno, SUM(D.dbill_invoiceamt) AS PartsValue " & Environment.NewLine
'                    strSQL &= "FROM tcellopt A " & Environment.NewLine
'                    strSQL &= "INNER JOIN security.tusers B ON A.cellopt_refurbcompleteuserid = B.user_id " & Environment.NewLine
'                    strSQL &= "INNER JOIN tdevice C ON A.device_id = C.device_id " & Environment.NewLine
'                    strSQL &= "INNER JOIN tdevicebill D ON A.device_id = D.device_id " & Environment.NewLine
'                    strSQL &= "WHERE A.cellopt_refurbcompletedt BETWEEN '" & Me._strStartDate & "' AND '" & Me._strEndDate & "' " & Environment.NewLine
'                    strSQL &= "AND A.cellopt_refurbcompleteuserid IN (" & Me._strTechIDIn.ToString & ") " & Environment.NewLine
'                    strSQL &= "AND A.cellopt_qcreject <> 2 " & Environment.NewLine
'                    strSQL &= "AND C.model_id IN (" & Me._strModelIDIn & ") " & Environment.NewLine
'                    strSQL &= "GROUP BY CAST(A.cellopt_refurbcompleteuserid AS UNSIGNED)"

'                    AddTable(Me._strPartsValueData, strSQL)
'                Catch ex As Exception
'                    Me._objDataProc.DisplayMessage(ex.Message)
'                End Try
'            End Sub

'            Private Sub TechHours()
'                ' Get total technician hours for date
'                Dim strSQL As String
'                Dim strStartDate As String
'                Dim strEndDate As String

'                Try
'                    strStartDate = Me._strStartDate
'                    strEndDate = Me._strEndDate

'                    ' Remove time portion, if any, from beginning and end dates.
'                    If strStartDate.IndexOf(" ") > 0 Then strStartDate = strStartDate.Substring(0, strStartDate.IndexOf(" ")).Trim
'                    If strEndDate.IndexOf(" ") > 0 Then strEndDate = strEndDate.Substring(0, strEndDate.IndexOf(" ")).Trim

'                    strSQL = "SELECT CAST(employee_no AS UNSIGNED) AS employeeno, IFNULL(SUM(techhours_hours), 0) AS techhours_hours " & Environment.NewLine
'                    strSQL &= "FROM ttechhours " & Environment.NewLine
'                    strSQL &= "WHERE employee_no IN (" & Me._strTechIDIn & ") " & Environment.NewLine
'                    strSQL &= "AND techhours_date BETWEEN '" & strStartDate & "' AND '" & strEndDate & "' " & Environment.NewLine
'                    strSQL &= "GROUP BY CAST(employee_no AS UNSIGNED)"

'                    AddTable(Me._strTechHoursData, strSQL)
'                Catch ex As Exception
'                    Me._objDataProc.DisplayMessage(ex.Message)
'                End Try
'            End Sub

'            Private Sub RURRTM()
'                Dim strSQL As String

'                Try
'                    strSQL = "SELECT CAST(C.cellopt_refurbcompleteuserid AS UNSIGNED) AS employeeno, B.billcode_rule AS BillCodeRule, COUNT(*) AS Cnt " & Environment.NewLine
'                    strSQL &= "FROM tdevicebill A " & Environment.NewLine
'                    strSQL &= "INNER JOIN lbillcodes B ON A.billcode_id = B.billcode_id " & Environment.NewLine
'                    strSQL &= "INNER JOIN tcellopt C ON A.device_id = C.device_id " & Environment.NewLine
'                    strSQL &= "WHERE C.cellopt_refurbcompletedt BETWEEN '" & Me._strStartDate & "' AND '" & Me._strEndDate & "' " & Environment.NewLine
'                    strSQL &= "AND C.cellopt_qcreject <> 2 " & Environment.NewLine
'                    strSQL &= "AND B.billcode_rule IN (1, 9) " & Environment.NewLine
'                    strSQL &= "GROUP BY CAST(C.cellopt_refurbcompleteuserid AS UNSIGNED), B.billcode_rule"

'                    AddTable(Me._strRURRTMData, strSQL)
'                Catch ex As Exception
'                    Me._objDataProc.DisplayMessage(ex.Message)
'                End Try
'            End Sub

'            Private Sub DeviceQC()
'                Dim strSQL As String

'                Try
'                    strSQL = "SELECT QCResult_ID, Device_ID " & Environment.NewLine
'                    strSQL &= "FROM tqc " & Environment.NewLine
'                    strSQL &= "WHERE QC_WorkDate BETWEEN '" & Me._strStartDate & "' AND '" & Me._strEndDate & "' " & Environment.NewLine
'                    strSQL &= "AND Device_ID IN (" & Me._strDeviceIDIn & ")"

'                    AddTable(Me._strQCData, strSQL)
'                Catch ex As Exception
'                    Me._objDataProc.DisplayMessage(ex.Message)
'                End Try
'            End Sub
'#End Region ' Set Data

'#Region "Get Data"
'            Private Function DeviceCount(ByVal iEEID As Integer) As Integer
'                Dim iCount As Integer = 0
'                Dim strFilter As String
'                Dim dr() As DataRow

'                Try
'                    strFilter = "employeeno = " & iEEID.ToString
'                    dr = Me.Tables(Me._strTechData).Select(strFilter)

'                    iCount = dr.Length

'                    Return iCount
'                Catch ex As Exception
'                    Me._objDataProc.DisplayMessage(ex.Message)
'                End Try
'            End Function

'            Private Function RURRTMCount(ByVal iEEID As Integer, ByVal iBillCodeRule As Integer) As Integer
'                Dim strIn As String = ""
'                Dim strFilter As String
'                Dim strSQL As String
'                Dim iCount As Integer = 0
'                Dim dr() As DataRow
'                Dim sf As New StackFrame(0)

'                Try
'                    strFilter = "employeeno = " & iEEID.ToString & " AND BillCodeRule = " & iBillCodeRule.ToString
'                    dr = Me.Tables(Me._strRURRTMData).Select(strFilter)

'                    If dr.Length > 0 Then iCount = dr(0)("Cnt")

'                    Return iCount
'                Catch ex As Exception
'                    Me._objDataProc.DisplayMessage(ex.Message)
'                End Try
'            End Function

'            Private Function GoodCount(ByVal iEEID As Integer) As Integer
'                Dim strFilter As String
'                Dim iCount As Integer = 0
'                Dim dr() As DataRow

'                Try
'                    strFilter = "employeeno = " & iEEID.ToString
'                    dr = Me.Tables(Me._strGoodCountData).Select(strFilter)

'                    If dr.Length > 0 Then
'                        If Not IsDBNull(dr(0)("GoodCount")) Then iCount = dr(0)("GoodCount")
'                    End If

'                    Return iCount
'                Catch ex As Exception
'                    Me._objDataProc.DisplayMessage(ex.Message)
'                End Try
'            End Function

'            Private Function RejectCount(ByVal iEEID As Integer) As Integer
'                Dim strFilter As String
'                Dim iCount As Integer = 0
'                Dim dr() As DataRow

'                Try
'                    strFilter = "employeeno = " & iEEID.ToString & " AND qcresult_id = 2"
'                    dr = Me.Tables(Me._strRejectCountData).Select(strFilter)

'                    If dr.Length > 0 Then iCount = dr.Length

'                    Return iCount
'                Catch ex As Exception
'                    Me._objDataProc.DisplayMessage(ex.Message)
'                End Try
'            End Function

'            Private Function TechHours(ByVal iEEID As Integer) As Double
'                Dim dblTechHours As Double = 0
'                Dim strFilter As String
'                Dim drTechHours() As DataRow
'                Dim iIndex As Integer

'                Try
'                    strFilter = "employeeno = " & iEEID.ToString
'                    drTechHours = Me.Tables(Me._strTechHoursData).Select(strFilter)

'                    If drTechHours.Length > 0 Then
'                        If Not IsDBNull(drTechHours(0)("techhours_hours")) Then dblTechHours = drTechHours(0)("techhours_hours")
'                    End If

'                    Return dblTechHours
'                Catch ex As Exception
'                    Me._objDataProc.DisplayMessage(ex.Message)
'                End Try
'            End Function

'            Private Function LaborValue(ByVal iEEID As Integer) As Double
'                Dim dblLaborValue As Double = 0
'                Dim strFilter As String
'                Dim dr() As DataRow
'                Dim iIndex As Integer

'                Try
'                    strFilter = "employeeno = " & iEEID.ToString
'                    dr = Me.Tables(Me._strLaborValueData).Select(strFilter)

'                    If dr.Length > 0 Then
'                        If Not IsDBNull(dr(0)("LaborValue")) Then dblLaborValue = CDbl(dr(iIndex)("LaborValue"))
'                    End If

'                    Return dblLaborValue
'                Catch ex As Exception
'                    Me._objDataProc.DisplayMessage(ex.Message)
'                End Try
'            End Function

'            Private Function TechRate(ByVal iEEID As Integer) As Double
'                Dim dblTechRate As Double = 0
'                Dim strFilter As String
'                Dim dr() As DataRow

'                Try
'                    strFilter = "employeeno = " & iEEID.ToString
'                    dr = Me.Tables(Me._strTechData).Select(strFilter)

'                    If dr.Length > 0 Then
'                        If Not IsDBNull(dr(0)("TechRate")) Then dblTechRate = dr(0)("TechRate")
'                    End If

'                    Return dblTechRate
'                Catch ex As Exception
'                    Me._objDataProc.DisplayMessage(ex.Message)
'                End Try
'            End Function

'            Private Function PartsValue(ByVal iEEID As Integer) As Double
'                Dim dblPartsValue As Double = 0
'                Dim strFilter As String
'                Dim dr() As DataRow
'                Dim iIndex As Integer

'                Try
'                    strFilter = "employeeno = " & iEEID.ToString
'                    dr = Me.Tables(Me._strPartsValueData).Select(strFilter)

'                    If dr.Length > 0 Then
'                        If Not IsDBNull(dr(0)("PartsValue")) Then dblPartsValue += CDbl(dr(0)("PartsValue"))
'                    End If

'                    Return dblPartsValue
'                Catch ex As Exception
'                    Me._objDataProc.DisplayMessage(ex.Message)
'                End Try
'            End Function

'            Private Function ActualPoints(ByVal iEEID As Integer) As Double
'                Dim dblActualPoints As Double = 0
'                Dim strFilter As String
'                Dim drModel() As DataRow
'                Dim iIndex As Integer

'                Try
'                    strFilter = "employeeno = " & iEEID.ToString
'                    drModel = Me.Tables(Me._strModelData).Select(strFilter)

'                    If drModel.Length > 0 Then
'                        For iIndex = 0 To drModel.Length - 1
'                            If Not IsDBNull(drModel(iIndex)("Unit_Hour")) Then
'                                If drModel(iIndex)("Unit_Hour") <> 0 Then dblActualPoints += Me._dblStandardPointGoalsPerHour / drModel(iIndex)("Unit_Hour")
'                            End If
'                        Next
'                    End If

'                    Return dblActualPoints
'                Catch ex As Exception
'                    Me._objDataProc.DisplayMessage(ex.Message)
'                End Try
'            End Function

'            Private Function RejectPoints(ByVal iEEID As Integer, ByVal dblFactor As Double) As Double
'                Dim dblRejectPoints As Double = 0
'                Dim strFilter As String
'                Dim drRejects(), drModelDetails(), drModels() As DataRow
'                Dim iIndex, iIndex2 As Integer

'                Try
'                    strFilter = "employeeno = " & iEEID.ToString & " AND qcresult_id = 2"
'                    drRejects = Me.Tables(Me._strRejectCountData).Select(strFilter)

'                    If drRejects.Length > 0 Then
'                        For iIndex = 0 To drRejects.Length - 1
'                            strFilter = "employeeno = " & iEEID.ToString & " AND device_id = " & drRejects(iIndex)("device_id").ToString
'                            drModelDetails = Me.Tables(Me._strModelDetailsData).Select(strFilter)

'                            If drModelDetails.Length > 0 Then
'                                For iIndex2 = 0 To drModelDetails.Length - 1
'                                    strFilter = "employeeno = " & iEEID.ToString & " AND model_id = " & drModelDetails(iIndex2)("model_id")
'                                    drModels = Me.Tables(Me._strModelData).Select(strFilter)

'                                    If drModels.Length > 0 Then ' Just use the first record
'                                        If drModels(0)("Unit_Hour") > 0 Then dblRejectPoints += dblFactor * (Me._dblStandardPointGoalsPerHour / drModels(0)("Unit_Hour"))
'                                    End If
'                                Next
'                            End If
'                        Next
'                    End If

'                    Return dblRejectPoints
'                Catch ex As Exception
'                    Me._objDataProc.DisplayMessage(ex.Message)
'                End Try
'            End Function

'            Private Function GoalPoints(ByVal dblHoursWorked As Double) As Double
'                Return Me._dblStandardPointGoalsPerHour * dblHoursWorked
'            End Function

'#End Region ' Get Data

'            Public Sub AddTable(ByVal strTblName As String, ByVal strSQL As String)
'                Dim dt As DataTable
'                Dim dr As DataRow

'                Try
'                    dt = Me._objDataProc.GetDataTable(strSQL)

'                    If Not IsNothing(dt) Then
'                        If Me.Tables.Contains(strTblName) Then
'                            Me.Tables(strTblName).Rows.Clear()

'                            For Each dr In dt.Rows
'                                Me.Tables(strTblName).ImportRow(dr)
'                            Next
'                        Else
'                            Me.Tables.Add(dt)
'                            Me.Tables(Me.Tables.Count - 1).TableName = strTblName
'                        End If
'                    End If
'                Catch ex As Exception
'                    Me._objDataProc.DisplayMessage(ex.Message)
'                Finally
'                    dr = Nothing

'                    If Not IsNothing(dt) Then
'                        dt.Dispose()
'                        dt = Nothing
'                    End If
'                End Try
'            End Sub

'            Public Sub DisplayMessage(ByVal strMsg As String, Optional ByVal iStackIndex As Integer = 3, Optional ByVal bIsErrMsg As Boolean = True)
'                Me._objDataProc.DisplayMessage(strMsg, iStackIndex, bIsErrMsg)
'            End Sub

'#Region "Properties"
'            Public ReadOnly Property GetTechData()
'                Get
'                    Return Me.Tables(Me._strTechData)
'                End Get
'            End Property

'            Public ReadOnly Property GetDeviceCount(ByVal iEEID As Integer)
'                Get
'                    Return DeviceCount(iEEID)
'                End Get
'            End Property

'            Public ReadOnly Property GetRURRTMCount(ByVal iEEID As Integer, ByVal iBillCodeRule As Integer)
'                Get
'                    Return RURRTMCount(iEEID, iBillCodeRule)
'                End Get
'            End Property

'            Public ReadOnly Property GetGoodCount(ByVal iEEID As Integer)
'                Get
'                    Return GoodCount(iEEID)
'                End Get
'            End Property

'            Public ReadOnly Property GetRejectCount(ByVal iEEID As Integer)
'                Get
'                    Return RejectCount(iEEID)
'                End Get
'            End Property

'            Public ReadOnly Property GetTechHours(ByVal iEEID As Integer)
'                Get
'                    Return TechHours(iEEID)
'                End Get
'            End Property

'            Public ReadOnly Property GetLaborValue(ByVal iEEID As Integer)
'                Get
'                    Return LaborValue(iEEID)
'                End Get
'            End Property

'            Public ReadOnly Property GetTechRate(ByVal iEEID As Integer)
'                Get
'                    Return TechRate(iEEID)
'                End Get
'            End Property

'            Public ReadOnly Property GetPartsValue(ByVal iEEID As Integer)
'                Get
'                    Return PartsValue(iEEID)
'                End Get
'            End Property

'            Public ReadOnly Property GetActualPoints(ByVal iEEID As Integer)
'                Get
'                    Return ActualPoints(iEEID)
'                End Get
'            End Property

'            Public ReadOnly Property GetGoalPoints(ByVal dblHoursWorked As Double)
'                Get
'                    Return GoalPoints(dblHoursWorked)
'                End Get
'            End Property

'            Public ReadOnly Property GetStandardPointGoalsPerHour()
'                Get
'                    Return Me._dblStandardPointGoalsPerHour
'                End Get
'            End Property

'            Public ReadOnly Property GetRejectPoints(ByVal iEEID As Integer, ByVal dblFactor As Double)
'                Get
'                    Return RejectPoints(iEEID, dblFactor)
'                End Get
'            End Property
'#End Region
'        End Class

'        Private Class SummaryManagerReportData_GSMsg
'            Inherits DataSet

'            Public Enum Groups
'                GAME_STOP = 0
'                MESSAGING = 1
'            End Enum

'            Private Const _strTechData As String = "Tech Data"
'            Private Const _strTechHoursData As String = "Tech Hours Data"
'            Private Const _strProductionData As String = "Production Data"

'            Private _objDataProc As DBQuery.DataProc

'            Private _strStartDate As String = Format(Now, "yyyy-MM-dd")
'            Private _strEndDate As String = Format(Now, "yyyy-MM-dd")
'            Private _iGroupID As Integer ' GameStop or Messaging
'            Private _strTechIDIn As String = ""

'            Public Sub New()
'                Me.DataSetName = "Summary Manager's Report Data - GameStop and Messaging"
'                Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
'            End Sub

'#Region "Set Data"
'            Public Sub SetData(ByVal datStart As Date, ByVal datEnd As Date, ByVal grp As Groups)
'                GetGroupID(grp)
'                SetStartEndDates(datStart, datEnd) ' MUST be called before anything else
'                TechData()
'                TechHours()
'                ProductionData()
'            End Sub

'            Private Sub SetStartEndDates(ByVal datStart As Date, ByVal datEnd As Date) ' MUST be called before anything else
'                Try
'                    Me._strStartDate = datStart.ToString("yyyy-MM-dd")
'                    Me._strEndDate = datEnd.ToString("yyyy-MM-dd")
'                Catch ex As Exception
'                    Me._objDataProc.DisplayMessage(ex.Message)
'                End Try
'            End Sub

'            Private Sub GetGroupID(ByVal grp As Groups)
'                Dim strSQL As String

'                Try
'                    strSQL = "SELECT Group_ID " & Environment.NewLine
'                    strSQL &= "FROM lgroups " & Environment.NewLine
'                    strSQL &= "WHERE UPPER(TRIM(Group_Desc)) = "

'                    If grp = Groups.GAME_STOP Then
'                        strSQL &= "'GAMESTOP'"
'                    Else
'                        strSQL &= "'MESSAGING'"
'                    End If

'                    Me._iGroupID = Me._objDataProc.GetIntValue(strSQL)
'                Catch ex As Exception
'                    Me._objDataProc.DisplayMessage(ex.Message)
'                End Try
'            End Sub

'            Private Sub TechData()
'                ' Get list of technicians and technician data for report
'                Dim strSQL As String
'                Dim dt As DataTable
'                Dim sf As New StackFrame(0)

'                Try
'                    strSQL = "SELECT DISTINCT A.user_fullname, CAST(A.employeeno AS UNSIGNED) AS employeeno, A.shift_id AS Shift_ID, A.TechRate, B.group_desc AS Group_Desc " & Environment.NewLine
'                    strSQL &= "FROM security.tusers A " & Environment.NewLine
'                    strSQL &= "INNER JOIN lgroups B ON B.group_id = A.group_id " & Environment.NewLine
'                    strSQL &= "WHERE A.group_id = " & Me._iGroupID.ToString & " " & Environment.NewLine
'                    'strSQL &= "AND A.is_user_refurber = 1 " & Environment.NewLine
'                    strSQL &= "ORDER BY A.user_fullname"

'                    AddTable(Me._strTechData, strSQL)
'                    TechIDInString()
'                Catch ex As Exception
'                    Me._objDataProc.DisplayMessage(ex.Message)
'                End Try
'            End Sub

'            Private Sub TechIDInString()
'                Dim dr As DataRow
'                Dim arrlstIDs As New ArrayList()
'                Dim iIndex As Integer
'                Dim sf As New StackFrame(0)

'                Try
'                    Me._strTechIDIn = ""

'                    For Each dr In Me.Tables(Me._strTechData).Rows
'                        If arrlstIDs.IndexOf(dr("employeeno")) = -1 Then
'                            arrlstIDs.Add(dr("employeeno"))
'                        End If
'                    Next

'                    For iIndex = 0 To arrlstIDs.Count - 1
'                        If Me._strTechIDIn.Length > 0 Then Me._strTechIDIn &= ", "

'                        Me._strTechIDIn &= arrlstIDs(iIndex)
'                    Next
'                Catch ex As Exception
'                    Me._objDataProc.DisplayMessage(ex.Message)
'                End Try
'            End Sub

'            Private Sub TechHours()
'                ' Get total technician hours for date
'                Dim strSQL As String

'                Try
'                    strSQL = "SELECT CAST(A.employee_no AS UNSIGNED) AS employeeno, IFNULL(SUM(A.techhours_hours), 0) AS 'Hours Worked' " & Environment.NewLine
'                    strSQL &= "FROM ttechhours A " & Environment.NewLine
'                    strSQL &= "INNER JOIN security.tusers B ON B.EmployeeNo = A.employee_no " & Environment.NewLine
'                    strSQL &= "WHERE A.techhours_date BETWEEN '" & Me._strStartDate & "' AND '" & Me._strEndDate & "' " & Environment.NewLine
'                    strSQL &= "AND B.Group_ID = " & Me._iGroupID.ToString & " " & Environment.NewLine
'                    strSQL &= "AND B.user_inactive = 0 " & Environment.NewLine
'                    strSQL &= "GROUP BY CAST(A.employee_no AS UNSIGNED)"

'                    AddTable(Me._strTechHoursData, strSQL)
'                Catch ex As Exception
'                    Me._objDataProc.DisplayMessage(ex.Message)
'                End Try
'            End Sub

'            Private Sub ProductionData()
'                Dim strSQL As String

'                Try
'                    If Me._strTechIDIn.Length = 0 Then Exit Sub

'                    strSQL = "SELECT EmployeeNo, SUM(DailyProduction) AS Production" & Environment.NewLine
'                    strSQL &= "FROM tGSMsgData " & Environment.NewLine
'                    strSQL &= "WHERE EEDate BETWEEN  '" & Me._strStartDate & "' AND '" & Me._strEndDate & "' " & Environment.NewLine
'                    strSQL &= "AND EmployeeNo IN (" & Me._strTechIDIn & ") " & Environment.NewLine
'                    strSQL &= "GROUP BY EmployeeNo"

'                    AddTable(Me._strProductionData, strSQL)
'                Catch ex As Exception
'                    Me._objDataProc.DisplayMessage(ex.Message)
'                End Try
'            End Sub
'#End Region 'Set Data

'#Region "Get Data"
'            Private Function TechHours(ByVal iTechID As Integer) As Double
'                Dim dblTechHours As Double = 0
'                Dim strFilter As String
'                Dim dr() As DataRow

'                Try
'                    strFilter = "EmployeeNo = " & iTechID.ToString
'                    dr = Me.Tables(Me._strTechHoursData).Select(strFilter)

'                    If dr.Length > 0 Then dblTechHours = dr(0)("'Hours Worked'")

'                    Return dblTechHours
'                Catch ex As Exception
'                    Me._objDataProc.DisplayMessage(ex.Message)
'                End Try
'            End Function

'            Private Function Production(ByVal iTechID As Integer) As Integer
'                Dim iProduction As Integer = 0
'                Dim strFilter As String
'                Dim dr() As DataRow

'                Try
'                    strFilter = "EmployeeNo = " & iTechID.ToString
'                    dr = Me.Tables(Me._strProductionData).Select(strFilter)

'                    If dr.Length > 0 Then iProduction = dr(0)("Production")

'                    Return iProduction
'                Catch ex As Exception
'                    Me._objDataProc.DisplayMessage(ex.Message)
'                End Try
'            End Function
'#End Region 'Get Data

'            Public Sub AddTable(ByVal strTblName As String, ByVal strSQL As String)
'                Dim dt As DataTable
'                Dim dr As DataRow

'                Try
'                    dt = Me._objDataProc.GetDataTable(strSQL)

'                    If Not IsNothing(dt) Then
'                        If Me.Tables.Contains(strTblName) Then
'                            Me.Tables(strTblName).Rows.Clear()

'                            For Each dr In dt.Rows
'                                Me.Tables(strTblName).ImportRow(dr)
'                            Next
'                        Else
'                            Me.Tables.Add(dt)
'                            Me.Tables(Me.Tables.Count - 1).TableName = strTblName
'                        End If
'                    End If
'                Catch ex As Exception
'                    Me._objDataProc.DisplayMessage(ex.Message)
'                Finally
'                    dr = Nothing

'                    If Not IsNothing(dt) Then
'                        dt.Dispose()
'                        dt = Nothing
'                    End If
'                End Try
'            End Sub

'            Public Sub DisplayMessage(ByVal strMsg As String, Optional ByVal iStackIndex As Integer = 3, Optional ByVal bIsErrMsg As Boolean = True)
'                Me._objDataProc.DisplayMessage(strMsg, iStackIndex, bIsErrMsg)
'            End Sub

'#Region "Properties"
'            Public ReadOnly Property GetTechData()
'                Get
'                    Return Me.Tables(Me._strTechData)
'                End Get
'            End Property

'            Public ReadOnly Property GetProduction(ByVal iTechNumber As Integer)
'                Get
'                    Return Me.Production(iTechNumber)
'                End Get
'            End Property

'            Public ReadOnly Property GetTechHours(ByVal iTechNumber As Integer)
'                Get
'                    Return Me.TechHours(iTechNumber)
'                End Get
'            End Property
'#End Region 'Properties
'        End Class
'    End Class

'    Public Class CellularDetailData
'        Inherits DataSet

'        Private Const _strTechData As String = "Tech Data"
'        Private Const _strModelData As String = "Model Data"
'        Private Const _strModelDetailsData As String = "Model Details Data"
'        Private Const _strGoodCountData As String = "Good Count Data"
'        Private Const _strRejectCountData As String = "Reject Count Data"
'        Private Const _strLaborValueData As String = "Labor Value Data"
'        Private Const _strPartsValueData As String = "Parts Value Data"
'        Private Const _strTechHoursData As String = "Tech Hours Data"
'        Private Const _strRURRTMData As String = "RURRTM Data"
'        Private Const _strQCData As String = "QC Data"

'        Private Const _dblStandardPointGoalsPerHour As Double = 10.0

'        Private _strStartDate As String = Format(Now, "yyyy-MM-dd")
'        Private _strEndDate As String = Format(Now, "yyyy-MM-dd")
'        Private _strTechIDIn As String = ""
'        Private _strDeviceIDIn As String = ""
'        Private _strModelIDIn As String = ""

'        Private _objDataProc As DBQuery.DataProc

'        Public Sub New()
'            Me.DataSetName = "Detail Manager's Report Data - Cellular"
'            Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
'        End Sub

'#Region "Set Data"
'        Public Sub SetData(ByVal datStart As Date, ByVal datEnd As Date)
'            SetStartEndDates(datStart, datEnd) ' MUST be called before anything else
'            TechData()
'            ModelData()
'            ModelDetails()
'            GetGoodCountData()
'            GetRejectCountData()
'            LaborValue()
'            PartsValue()
'            TechHours()
'            RURRTM()
'            DeviceQC()
'        End Sub

'        Private Sub SetStartEndDates(ByVal datStart As Date, ByVal datEnd As Date) ' MUST be called before anything else
'            Try
'                Me._strStartDate = datStart.ToString("yyyy-MM-dd") & " 06:00:00" ' Start of first shift
'                Me._strEndDate = DateAdd(DateInterval.Day, 1, datEnd).ToString("yyyy-MM-dd") & " 04:00:00" ' Past end of second shift
'            Catch ex As Exception
'                Me._objDataProc.DisplayMessage(ex.Message)
'            End Try
'        End Sub

'        Private Sub TechData()
'            ' Get list of technicians and technician data for report
'            Dim strSQL As String
'            Dim dt As DataTable
'            Dim sf As New StackFrame(0)

'            Try
'                strSQL = "SELECT DISTINCT B.user_fullname, CAST(B.employeeno AS UNSIGNED) AS employeeno, B.shift_id AS Shift_ID, B.TechRate, D.group_id, D.group_desc AS Group_Desc, A.device_id AS Device_ID " & Environment.NewLine
'                strSQL &= "FROM tcellopt A " & Environment.NewLine
'                strSQL &= "INNER JOIN security.tusers B ON A.cellopt_refurbcompleteuserid = B.user_id " & Environment.NewLine
'                strSQL &= "INNER JOIN tdevice C ON A.device_id = C.device_id " & Environment.NewLine
'                strSQL &= "INNER JOIN lgroups D ON B.group_id = D.group_id " & Environment.NewLine
'                strSQL &= "INNER JOIN tmodel E ON E.model_id = C.model_id " & Environment.NewLine
'                strSQL &= "WHERE A.cellopt_refurbcompletedt BETWEEN '" & Me._strStartDate & "' AND '" & Me._strEndDate & "' " & Environment.NewLine
'                strSQL &= "AND E.model_type IN (0, 1) " & Environment.NewLine
'                strSQL &= "AND B.is_user_refurber = 1 " & Environment.NewLine
'                strSQL &= "ORDER BY B.user_fullname"

'                AddTable(Me._strTechData, strSQL)
'                TechIDInString()
'                DeviceIDInString()
'            Catch ex As Exception
'                Me._objDataProc.DisplayMessage(ex.Message)
'            End Try
'        End Sub

'        Private Sub ModelData()
'            ' Get models for date range and technicians
'            Dim strSQL As String

'            Try
'                strSQL = "SELECT CAST(A.cellopt_refurbcompleteuserid AS UNSIGNED) AS employeeno, C.model_id AS model_id, D.model_desc, IFNULL(E.gmf_unithour, 0) AS Unit_Hour " & Environment.NewLine
'                strSQL &= "FROM tcellopt A " & Environment.NewLine
'                strSQL &= "INNER JOIN security.tusers B ON A.cellopt_refurbcompleteuserid = B.user_id " & Environment.NewLine
'                strSQL &= "INNER JOIN tdevice C ON A.device_id = C.device_id " & Environment.NewLine
'                strSQL &= "INNER JOIN tmodel D ON C.model_id = D.model_id " & Environment.NewLine
'                strSQL &= "LEFT JOIN tgroupmodelfactor E ON D.model_id = E.model_id AND B.group_id = E.group_id " & Environment.NewLine
'                strSQL &= "WHERE cellopt_refurbcompletedt BETWEEN '" & Me._strStartDate & "' AND '" & Me._strEndDate & "' " & Environment.NewLine
'                strSQL &= "AND A.cellopt_refurbcompleteuserid IN (" & Me._strTechIDIn & ") " & Environment.NewLine
'                strSQL &= "AND D.model_type IN (0, 1) " & Environment.NewLine

'                AddTable(Me._strModelData, strSQL)
'                ModelIDInString()
'            Catch ex As Exception
'                Me._objDataProc.DisplayMessage(ex.Message)
'            End Try
'        End Sub

'        Private Sub ModelDetails()
'            ' Get model details for date range and technician
'            Dim strSQL As String

'            Try
'                strSQL = "SELECT DISTINCT A.device_id, max(E.qc_id) as maxID, E.qcresult_id, E.device_id as qcDeviceID, D.model_id AS model_id, D.model_desc as model_desc, CAST(A.cellopt_refurbcompleteuserid AS UNSIGNED) AS employeeno " & Environment.NewLine
'                strSQL &= "FROM tcellopt A " & Environment.NewLine
'                strSQL &= "INNER JOIN security.tusers B ON A.cellopt_refurbcompleteuserid = B.user_id " & Environment.NewLine
'                strSQL &= "INNER JOIN tdevice C ON A.device_id = C.device_id " & Environment.NewLine
'                strSQL &= "INNER JOIN tmodel D ON C.model_id = D.model_id " & Environment.NewLine
'                strSQL &= "LEFT OUTER JOIN tqc E ON C.device_id = E.device_id " & Environment.NewLine
'                strSQL &= "WHERE A.cellopt_refurbcompletedt BETWEEN '" & Me._strStartDate & "' AND '" & Me._strEndDate & "' " & Environment.NewLine
'                strSQL &= "AND A.cellopt_refurbcompleteuserid IN (" & Me._strTechIDIn & ") " & Environment.NewLine
'                strSQL &= "AND D.model_type IN (0, 1) " & Environment.NewLine
'                strSQL &= "GROUP BY A.device_id " & Environment.NewLine

'                AddTable(Me._strModelDetailsData, strSQL)
'            Catch ex As Exception
'                Me._objDataProc.DisplayMessage(ex.Message)
'            End Try
'        End Sub

'        Private Sub TechIDInString()
'            Dim dr As DataRow
'            Dim arrlstIDs As New ArrayList()
'            Dim iIndex As Integer
'            Dim sf As New StackFrame(0)

'            Try
'                Me._strTechIDIn = ""

'                For Each dr In Me.Tables(Me._strTechData).Rows
'                    If arrlstIDs.IndexOf(dr("employeeno")) = -1 Then
'                        arrlstIDs.Add(dr("employeeno"))
'                    End If
'                Next

'                For iIndex = 0 To arrlstIDs.Count - 1
'                    If Me._strTechIDIn.Length > 0 Then Me._strTechIDIn &= ", "

'                    Me._strTechIDIn &= arrlstIDs(iIndex)
'                Next
'            Catch ex As Exception
'                Me._objDataProc.DisplayMessage(ex.Message)
'            End Try
'        End Sub

'        Private Sub DeviceIDInString()
'            Dim strSQL As String
'            Dim dt As DataTable
'            Dim dr As DataRow

'            Try
'                Me._strDeviceIDIn = ""

'                strSQL = "SELECT DISTINCT device_id " & Environment.NewLine
'                strSQL &= "FROM tcellopt " & Environment.NewLine
'                strSQL &= "WHERE cellopt_refurbcompletedt BETWEEN '" & Me._strStartDate & "' AND '" & Me._strEndDate & "' " & Environment.NewLine
'                strSQL &= "AND cellopt_refurbcompleteuserid IN (" & Me._strTechIDIn & ")"

'                dt = Me._objDataProc.GetDataTable(strSQL)

'                If Not IsNothing(dt) Then
'                    If dt.Rows.Count > 0 Then
'                        For Each dr In dt.Rows
'                            If Me._strDeviceIDIn.Length > 0 Then Me._strDeviceIDIn &= ", "

'                            Me._strDeviceIDIn &= dr("device_id")
'                        Next
'                    End If
'                End If
'            Catch ex As Exception
'                Me._objDataProc.DisplayMessage(ex.Message)
'            Finally
'                dr = Nothing

'                If Not IsNothing(dt) Then
'                    dt.Dispose()
'                    dt = Nothing
'                End If
'            End Try
'        End Sub

'        Private Sub ModelIDInString()
'            Dim arrlstIDs As New ArrayList()
'            Dim dr As DataRow
'            Dim bFound As Boolean

'            Try
'                Me._strModelIDIn = ""

'                If Not IsNothing(Me.Tables(Me._strModelData)) Then
'                    If Me.Tables(Me._strModelData).Rows.Count > 0 Then
'                        For Each dr In Me.Tables(Me._strModelData).Rows
'                            bFound = False

'                            If arrlstIDs.Count > 0 Then
'                                If arrlstIDs.IndexOf(dr("model_id")) > -1 Then bFound = True
'                            End If

'                            If Not bFound Then
'                                arrlstIDs.Add(dr("model_id"))

'                                If Me._strModelIDIn.Length > 0 Then Me._strModelIDIn &= ", "

'                                Me._strModelIDIn &= dr("model_id")
'                            End If
'                        Next
'                    End If
'                End If
'            Catch ex As Exception
'                Me._objDataProc.DisplayMessage(ex.Message)
'            End Try
'        End Sub

'        Private Sub GetGoodCountData()
'            Dim strSQL As String

'            Try
'                strSQL = "SELECT CAST(A.cellopt_refurbcompleteuserid AS UNSIGNED) AS employeeno, D.model_desc, COUNT(*) AS GoodCount " & Environment.NewLine
'                strSQL &= "FROM tcellopt A " & Environment.NewLine
'                strSQL &= "INNER JOIN security.tusers B ON A.cellopt_refurbcompleteuserid = B.user_id " & Environment.NewLine
'                strSQL &= "INNER JOIN tdevice C ON A.device_id = C.device_id " & Environment.NewLine
'                strSQL &= "INNER JOIN tmodel D ON C.model_id = D.model_id " & Environment.NewLine
'                strSQL &= "WHERE A.cellopt_refurbcompletedt BETWEEN '" & Me._strStartDate & "' AND '" & Me._strEndDate & "' " & Environment.NewLine
'                strSQL &= "AND A.cellopt_refurbcompleteuserid IN (" & Me._strTechIDIn & ") " & Environment.NewLine
'                strSQL &= "AND A.device_id IN (" & Me._strDeviceIDIn & ") " & Environment.NewLine
'                strSQL &= "AND D.model_type IN (0, 1) " & Environment.NewLine
'                strSQL &= "GROUP BY CAST(A.cellopt_refurbcompleteuserid AS UNSIGNED), D.model_desc " & Environment.NewLine
'                strSQL &= "ORDER BY CAST(A.cellopt_refurbcompleteuserid AS UNSIGNED), D.model_desc"

'                AddTable(Me._strGoodCountData, strSQL)
'            Catch ex As Exception
'                Me._objDataProc.DisplayMessage(ex.Message)
'            End Try
'        End Sub

'        Private Sub GetRejectCountData()
'            Dim strSQL As String

'            Try
'                strSQL = "SELECT DISTINCT A.device_id, max(E.qc_id) as maxID, E.qcresult_id, E.device_id as qcDeviceID, CAST(A.cellopt_refurbcompleteuserid AS UNSIGNED) AS employeeno " & Environment.NewLine
'                strSQL &= "FROM tcellopt A " & Environment.NewLine
'                strSQL &= "INNER JOIN security.tusers B ON A.cellopt_refurbcompleteuserid = B.user_id " & Environment.NewLine
'                strSQL &= "INNER JOIN tdevice C ON A.device_id = C.device_id " & Environment.NewLine
'                strSQL &= "INNER JOIN tmodel D ON C.model_id = D.model_id " & Environment.NewLine
'                strSQL &= "INNER JOIN tqc E ON E.device_ID = A.device_id " & Environment.NewLine
'                strSQL &= "WHERE A.cellopt_refurbcompletedt BETWEEN '" & Me._strStartDate & "' AND '" & Me._strEndDate & "' " & Environment.NewLine
'                strSQL &= "AND A.cellopt_refurbcompleteuserid IN (" & Me._strTechIDIn & ") " & Environment.NewLine
'                strSQL &= "AND A.device_id IN (" & Me._strDeviceIDIn & ") " & Environment.NewLine
'                strSQL &= "AND D.model_type IN (0, 1) " & Environment.NewLine
'                strSQL &= "GROUP BY A.device_id " & Environment.NewLine
'                strSQL &= "ORDER BY CAST(A.cellopt_refurbcompleteuserid AS UNSIGNED), A.device_id"

'                AddTable(Me._strRejectCountData, strSQL)
'            Catch ex As Exception
'                Me._objDataProc.DisplayMessage(ex.Message)
'            End Try
'        End Sub

'        Private Sub LaborValue()
'            ' Get total labor value for date range, technician and device
'            Dim strSQL As String
'            Dim dt As DataTable = Nothing

'            Try
'                strSQL = "SELECT CAST(A.cellopt_refurbcompleteuserid AS UNSIGNED) as employeeno, SUM(C.device_laborcharge) AS LaborValue" & Environment.NewLine
'                strSQL &= "FROM tcellopt A " & Environment.NewLine
'                strSQL &= "INNER JOIN security.tusers B ON A.cellopt_refurbcompleteuserid = B.user_id " & Environment.NewLine
'                strSQL &= "INNER JOIN tdevice C ON A.device_id = C.device_id " & Environment.NewLine
'                strSQL &= "WHERE A.cellopt_refurbcompletedt BETWEEN '" & Me._strStartDate & "' AND '" & Me._strEndDate & "' " & Environment.NewLine
'                strSQL &= "AND A.cellopt_refurbcompleteuserid IN (" & Me._strTechIDIn & ") " & Environment.NewLine
'                strSQL &= "AND A.cellopt_qcreject <> 2 " & Environment.NewLine
'                strSQL &= "AND C.model_id IN (" & Me._strModelIDIn & ") " & Environment.NewLine
'                strSQL &= "GROUP BY CAST(A.cellopt_refurbcompleteuserid AS UNSIGNED)"

'                AddTable(Me._strLaborValueData, strSQL)
'            Catch ex As Exception
'                Me._objDataProc.DisplayMessage(ex.Message)
'            Finally
'                If Not IsNothing(dt) Then
'                    dt.Dispose()
'                    dt = Nothing
'                End If
'            End Try
'        End Sub

'        Private Sub PartsValue()
'            ' Get total parts value for date range, technician and device
'            Dim strSQL As String

'            Try
'                strSQL = "SELECT CAST(A.cellopt_refurbcompleteuserid AS UNSIGNED) AS employeeno, C.model_id, SUM(D.dbill_invoiceamt) AS PartsValue " & Environment.NewLine
'                strSQL &= "FROM tcellopt A " & Environment.NewLine
'                strSQL &= "INNER JOIN security.tusers B ON A.cellopt_refurbcompleteuserid = B.user_id " & Environment.NewLine
'                strSQL &= "INNER JOIN tdevice C ON A.device_id = C.device_id " & Environment.NewLine
'                strSQL &= "INNER JOIN tdevicebill D ON A.device_id = D.device_id " & Environment.NewLine
'                strSQL &= "WHERE A.cellopt_refurbcompletedt BETWEEN '" & Me._strStartDate & "' AND '" & Me._strEndDate & "' " & Environment.NewLine
'                strSQL &= "AND A.cellopt_refurbcompleteuserid IN (" & Me._strTechIDIn.ToString & ") " & Environment.NewLine
'                strSQL &= "AND A.cellopt_qcreject <> 2 " & Environment.NewLine
'                strSQL &= "AND C.model_id IN (" & Me._strModelIDIn & ") " & Environment.NewLine
'                strSQL &= "GROUP BY CAST(A.cellopt_refurbcompleteuserid AS UNSIGNED), C.model_id"

'                AddTable(Me._strPartsValueData, strSQL)
'            Catch ex As Exception
'                Me._objDataProc.DisplayMessage(ex.Message)
'            End Try
'        End Sub

'        Private Sub TechHours()
'            ' Get total technician hours for date
'            Dim strSQL As String
'            Dim strStartDate As String
'            Dim strEndDate As String

'            Try
'                strStartDate = Me._strStartDate
'                strEndDate = Me._strEndDate

'                ' Remove time portion, if any, from beginning and end dates.
'                If strStartDate.IndexOf(" ") > 0 Then strStartDate = strStartDate.Substring(0, strStartDate.IndexOf(" ")).Trim
'                If strEndDate.IndexOf(" ") > 0 Then strEndDate = strEndDate.Substring(0, strEndDate.IndexOf(" ")).Trim

'                strSQL = "SELECT CAST(employee_no AS UNSIGNED) AS employeeno, IFNULL(SUM(techhours_hours), 0) AS techhours_hours " & Environment.NewLine
'                strSQL &= "FROM ttechhours " & Environment.NewLine
'                strSQL &= "WHERE employee_no IN (" & Me._strTechIDIn & ") " & Environment.NewLine
'                strSQL &= "AND techhours_date BETWEEN '" & strStartDate & "' AND '" & strEndDate & "' " & Environment.NewLine
'                strSQL &= "GROUP BY CAST(employee_no AS UNSIGNED)"

'                AddTable(Me._strTechHoursData, strSQL)
'            Catch ex As Exception
'                Me._objDataProc.DisplayMessage(ex.Message)
'            End Try
'        End Sub

'        Private Sub RURRTM()
'            Dim strSQL As String

'            Try
'                strSQL = "SELECT CAST(C.cellopt_refurbcompleteuserid AS UNSIGNED) AS employeeno, B.billcode_rule AS BillCodeRule, A.device_id " & Environment.NewLine
'                strSQL &= "FROM tdevicebill A " & Environment.NewLine
'                strSQL &= "INNER JOIN lbillcodes B ON A.billcode_id = B.billcode_id " & Environment.NewLine
'                strSQL &= "INNER JOIN tcellopt C ON A.device_id = C.device_id " & Environment.NewLine
'                strSQL &= "WHERE C.cellopt_refurbcompletedt BETWEEN '" & Me._strStartDate & "' AND '" & Me._strEndDate & "' " & Environment.NewLine
'                strSQL &= "AND C.cellopt_qcreject <> 2 " & Environment.NewLine
'                strSQL &= "AND B.billcode_rule IN (1, 9)"
'                'strSQL &= "AND B.billcode_rule IN (1, 9) " & Environment.NewLine
'                'strSQL &= "GROUP BY CAST(C.cellopt_refurbcompleteuserid AS UNSIGNED), B.billcode_rule"

'                AddTable(Me._strRURRTMData, strSQL)
'            Catch ex As Exception
'                Me._objDataProc.DisplayMessage(ex.Message)
'            End Try
'        End Sub

'        Private Sub DeviceQC()
'            Dim strSQL As String

'            Try
'                strSQL = "SELECT QCResult_ID, Device_ID " & Environment.NewLine
'                strSQL &= "FROM tqc " & Environment.NewLine
'                strSQL &= "WHERE QC_WorkDate BETWEEN '" & Me._strStartDate & "' AND '" & Me._strEndDate & "' " & Environment.NewLine
'                strSQL &= "AND Device_ID IN (" & Me._strDeviceIDIn & ")"

'                AddTable(Me._strQCData, strSQL)
'            Catch ex As Exception
'                Me._objDataProc.DisplayMessage(ex.Message)
'            End Try
'        End Sub
'#End Region ' Set Data

'#Region "Get Data"
'        Private Function DeviceCount(ByVal iEEID As Integer) As Integer
'            Dim iCount As Integer = 0
'            Dim strFilter As String
'            Dim dr() As DataRow

'            Try
'                strFilter = "employeeno = " & iEEID.ToString
'                dr = Me.Tables(Me._strTechData).Select(strFilter)

'                iCount = dr.Length

'                Return iCount
'            Catch ex As Exception
'                Me._objDataProc.DisplayMessage(ex.Message)
'            End Try
'        End Function

'        Private Function RURRTMCount(ByVal iEEID As Integer, ByVal iBillCodeRule As Integer) As Integer
'            Dim strIn As String = ""
'            Dim strFilter As String
'            Dim strSQL As String
'            Dim iCount As Integer = 0
'            Dim dr() As DataRow
'            Dim sf As New StackFrame(0)

'            Try
'                strFilter = "employeeno = " & iEEID.ToString & " AND BillCodeRule = " & iBillCodeRule.ToString
'                dr = Me.Tables(Me._strRURRTMData).Select(strFilter)

'                If dr.Length > 0 Then iCount = dr.Length

'                Return iCount
'            Catch ex As Exception
'                Me._objDataProc.DisplayMessage(ex.Message)
'            End Try
'        End Function

'        Private Function GoodCount(ByVal iEEID As Integer) As Integer
'            Dim strFilter As String
'            Dim iCount As Integer = 0
'            Dim dr() As DataRow
'            Dim i As Integer

'            Try
'                strFilter = "employeeno = " & iEEID.ToString
'                dr = Me.Tables(Me._strGoodCountData).Select(strFilter)

'                If dr.Length > 0 Then
'                    For i = 0 To dr.Length - 1
'                        If Not IsDBNull(dr(i)("GoodCount")) Then iCount += dr(i)("GoodCount")
'                    Next
'                End If

'                Return iCount
'            Catch ex As Exception
'                Me._objDataProc.DisplayMessage(ex.Message)
'            End Try
'        End Function

'        Private Function RejectCount(ByVal iEEID As Integer) As Integer
'            Dim strFilter As String
'            Dim iCount As Integer = 0
'            Dim dr() As DataRow

'            Try
'                strFilter = "employeeno = " & iEEID.ToString & " AND qcresult_id = 2"
'                dr = Me.Tables(Me._strRejectCountData).Select(strFilter)

'                If dr.Length > 0 Then iCount = dr.Length

'                Return iCount
'            Catch ex As Exception
'                Me._objDataProc.DisplayMessage(ex.Message)
'            End Try
'        End Function

'        Private Function TechHours(ByVal iEEID As Integer) As Double
'            Dim dblTechHours As Double = 0
'            Dim strFilter As String
'            Dim drTechHours() As DataRow
'            Dim iIndex As Integer

'            Try
'                strFilter = "employeeno = " & iEEID.ToString
'                drTechHours = Me.Tables(Me._strTechHoursData).Select(strFilter)

'                If drTechHours.Length > 0 Then
'                    If Not IsDBNull(drTechHours(0)("techhours_hours")) Then dblTechHours = drTechHours(0)("techhours_hours")
'                End If

'                Return dblTechHours
'            Catch ex As Exception
'                Me._objDataProc.DisplayMessage(ex.Message)
'            End Try
'        End Function

'        Private Function LaborValue(ByVal iEEID As Integer) As Double
'            Dim dblLaborValue As Double = 0
'            Dim strFilter As String
'            Dim dr() As DataRow
'            Dim iIndex As Integer

'            Try
'                strFilter = "employeeno = " & iEEID.ToString
'                dr = Me.Tables(Me._strLaborValueData).Select(strFilter)

'                If dr.Length > 0 Then
'                    If Not IsDBNull(dr(0)("LaborValue")) Then dblLaborValue = CDbl(dr(iIndex)("LaborValue"))
'                End If

'                Return dblLaborValue
'            Catch ex As Exception
'                Me._objDataProc.DisplayMessage(ex.Message)
'            End Try
'        End Function

'        Private Function TechRate(ByVal iEEID As Integer) As Double
'            Dim dblTechRate As Double = 0
'            Dim strFilter As String
'            Dim dr() As DataRow

'            Try
'                strFilter = "employeeno = " & iEEID.ToString
'                dr = Me.Tables(Me._strTechData).Select(strFilter)

'                If dr.Length > 0 Then
'                    If Not IsDBNull(dr(0)("TechRate")) Then dblTechRate = dr(0)("TechRate")
'                End If

'                Return dblTechRate
'            Catch ex As Exception
'                Me._objDataProc.DisplayMessage(ex.Message)
'            End Try
'        End Function

'        Private Function PartsValue(ByVal iTechID As Integer) As DataTable
'            Dim dt As DataTable
'            Dim strFilter, strSort As String
'            Dim drModelDetails(), drParts(), dr As DataRow
'            Dim i As Integer
'            Dim strModelID As Integer = 0

'            Try
'                strFilter = "employeeno = " & iTechID.ToString
'                strSort = "model_desc ASC, device_id ASC"
'                drModelDetails = Me.Tables(Me._strModelDetailsData).Select(strFilter, strSort)

'                If drModelDetails.Length > 0 Then
'                    dt = CreatePartsReturnTable()

'                    For i = 0 To drModelDetails.Length - 1
'                        If strModelID <> drModelDetails(i)("model_id") Then
'                            If strModelID > 0 Then
'                                dt.Rows.Add(dr)
'                            End If

'                            dr = dt.NewRow

'                            dr("Model") = drModelDetails(i)("model_desc")
'                            dr("Model ID") = drModelDetails(i)("model_id")
'                            dr("Parts Value") = 0

'                            strModelID = drModelDetails(i)("model_id")
'                        End If
'                    Next

'                    ' Add the last row
'                    dt.Rows.Add(dr)
'                End If

'                For Each dr In dt.Rows
'                    strFilter = "employeeno = " & iTechID.ToString & " AND model_id = " & dr("Model ID")
'                    drParts = Me.Tables(Me._strPartsValueData).Select(strFilter)

'                    If drParts.Length > 0 Then
'                        If Not IsDBNull(drParts(0)("PartsValue")) Then dr("Parts Value") += drParts(0)("PartsValue")
'                    End If
'                Next

'                Return dt
'            Catch ex As Exception
'                Me._objDataProc.DisplayMessage(ex.Message)
'            Finally
'                drModelDetails = Nothing
'                drParts = Nothing
'                dr = Nothing

'                If Not IsNothing(dt) Then
'                    dt.Dispose()
'                    dt = Nothing
'                End If
'            End Try
'        End Function

'        Private Function CreatePartsReturnTable() As DataTable
'            Dim dt As DataTable

'            Try
'                dt = New DataTable("Parts Value Data")

'                dt.Columns.Add(New DataColumn("Model", System.Type.GetType("System.String")))
'                dt.Columns.Add(New DataColumn("Model ID", System.Type.GetType("System.Int32")))
'                dt.Columns.Add(New DataColumn("Parts Value", System.Type.GetType("System.Double")))

'                Return dt
'            Catch ex As Exception
'                Me._objDataProc.DisplayMessage(ex.Message)
'            Finally
'                If Not IsNothing(dt) Then
'                    dt.Dispose()
'                    dt = Nothing
'                End If
'            End Try
'        End Function

'        Private Function ActualPoints(ByVal iEEID As Integer) As Double
'            Dim dblActualPoints As Double = 0
'            Dim strFilter As String
'            Dim drModel() As DataRow
'            Dim iIndex As Integer

'            Try
'                strFilter = "employeeno = " & iEEID.ToString
'                drModel = Me.Tables(Me._strModelData).Select(strFilter)

'                If drModel.Length > 0 Then
'                    For iIndex = 0 To drModel.Length - 1
'                        If Not IsDBNull(drModel(iIndex)("Unit_Hour")) Then
'                            If drModel(iIndex)("Unit_Hour") <> 0 Then dblActualPoints += Me._dblStandardPointGoalsPerHour / drModel(iIndex)("Unit_Hour")
'                        End If
'                    Next
'                End If

'                Return dblActualPoints
'            Catch ex As Exception
'                Me._objDataProc.DisplayMessage(ex.Message)
'            End Try
'        End Function

'        Private Function RejectPoints(ByVal iEEID As Integer, ByVal dblFactor As Double) As Double
'            Dim dblRejectPoints As Double = 0
'            Dim strFilter As String
'            Dim drRejects(), drModelDetails(), drModels() As DataRow
'            Dim iIndex, iIndex2 As Integer

'            Try
'                strFilter = "employeeno = " & iEEID.ToString & " AND qcresult_id = 2"
'                drRejects = Me.Tables(Me._strRejectCountData).Select(strFilter)

'                If drRejects.Length > 0 Then
'                    For iIndex = 0 To drRejects.Length - 1
'                        strFilter = "employeeno = " & iEEID.ToString & " AND device_id = " & drRejects(iIndex)("device_id").ToString
'                        drModelDetails = Me.Tables(Me._strModelDetailsData).Select(strFilter)

'                        If drModelDetails.Length > 0 Then
'                            For iIndex2 = 0 To drModelDetails.Length - 1
'                                strFilter = "employeeno = " & iEEID.ToString & " AND model_id = " & drModelDetails(iIndex2)("model_id")
'                                drModels = Me.Tables(Me._strModelData).Select(strFilter)

'                                If drModels.Length > 0 Then ' Just use the first record
'                                    If drModels(0)("Unit_Hour") > 0 Then dblRejectPoints += dblFactor * (Me._dblStandardPointGoalsPerHour / drModels(0)("Unit_Hour"))
'                                End If
'                            Next
'                        End If
'                    Next
'                End If

'                Return dblRejectPoints
'            Catch ex As Exception
'                Me._objDataProc.DisplayMessage(ex.Message)
'            End Try
'        End Function

'        Private Function GoalPoints(ByVal dblHoursWorked As Double) As Double
'            Return Me._dblStandardPointGoalsPerHour * dblHoursWorked
'        End Function

'        Private Function ModelDetails(ByVal iTechID As Integer) As DataTable
'            Dim strFilter, strSort As String
'            Dim drModelDetails(), drRURRTM(), drModels(), drGoodCounts(), dr As DataRow
'            Dim dt As DataTable
'            Dim i As Integer
'            Dim strModelDesc As String = ""
'            Dim bAlreadyCounted As Boolean

'            Try
'                strFilter = "employeeno = " & iTechID.ToString
'                strSort = "model_desc ASC, device_id ASC"
'                drModelDetails = Me.Tables(Me._strModelDetailsData).Select(strFilter, strSort)

'                If drModelDetails.Length > 0 Then
'                    dt = CreateModelDetailsReturnTable()

'                    For i = 0 To drModelDetails.Length - 1
'                        If strModelDesc <> drModelDetails(i)("model_desc") Then
'                            If strModelDesc.Trim.Length <> 0 Then
'                                dt.Rows.Add(dr)
'                            End If

'                            dr = dt.NewRow

'                            dr("Model") = drModelDetails(i)("model_desc")
'                            dr("Model RUR Count") = 0
'                            dr("Model RTM Count") = 0
'                            dr("Model Reject Count") = 0
'                            dr("Model Good Count") = 0

'                            strModelDesc = drModelDetails(i)("model_desc")
'                        End If

'                        bAlreadyCounted = False

'                        If Not IsDBNull(drModelDetails(i)("qcresult_id")) Then
'                            If drModelDetails(i)("qcresult_id") = 2 Then
'                                dr("Model Reject Count") += 1
'                                bAlreadyCounted = True
'                            End If
'                        End If

'                        If Not bAlreadyCounted Then
'                            strFilter = "employeeno = " & iTechID.ToString & " AND device_id = " & drModelDetails(i)("device_id").ToString
'                            drRURRTM = Me.Tables(Me._strRURRTMData).Select(strFilter)

'                            If drRURRTM.Length > 0 Then
'                                If Not IsDBNull(drRURRTM(0)("BillCodeRule")) Then
'                                    If drRURRTM(0)("BillCodeRule") = 1 Then
'                                        dr("Model RUR Count") += 1
'                                        bAlreadyCounted = True
'                                    ElseIf drRURRTM(0)("BillCodeRule") = 9 Then
'                                        dr("Model RTM Count") += 1
'                                        bAlreadyCounted = True
'                                    End If
'                                End If
'                            End If
'                        End If
'                    Next

'                    ' Add the last row
'                    dt.Rows.Add(dr)
'                End If

'                For Each dr In dt.Rows
'                    AddUnitsData(dr, iTechID)

'                    strFilter = "employeeno = " & iTechID.ToString & " AND model_desc = '" & dr("Model") & "'"
'                    drGoodCounts = Me.Tables(Me._strGoodCountData).Select(strFilter)

'                    If drGoodCounts.Length > 0 Then dr("Model Good Count") = drGoodCounts(0)("GoodCount")
'                Next

'                Return dt
'            Catch ex As Exception
'                Me._objDataProc.DisplayMessage(ex.Message)
'            Finally
'                If Not IsNothing(drModelDetails) Then drModelDetails = Nothing

'                If Not IsNothing(dt) Then
'                    dt.Dispose()
'                    dt = Nothing
'                End If
'            End Try
'        End Function

'        Private Function CreateModelDetailsReturnTable() As DataTable
'            Dim dt As DataTable

'            Try
'                dt = New DataTable("Model Details Return Data")

'                dt.Columns.Add(New DataColumn("Model", System.Type.GetType("System.String")))
'                dt.Columns.Add(New DataColumn("Model RUR Count", System.Type.GetType("System.Int32")))
'                dt.Columns.Add(New DataColumn("Model RTM Count", System.Type.GetType("System.Int32")))
'                dt.Columns.Add(New DataColumn("Model Reject Count", System.Type.GetType("System.Int32")))
'                dt.Columns.Add(New DataColumn("Model Good Count", System.Type.GetType("System.Int32")))
'                dt.Columns.Add(New DataColumn("Model Units/Hour", System.Type.GetType("System.Double")))
'                dt.Columns.Add(New DataColumn("Model HPU", System.Type.GetType("System.Double")))

'                Return dt
'            Catch ex As Exception
'                Me._objDataProc.DisplayMessage(ex.Message)
'            Finally
'                If Not IsNothing(dt) Then
'                    dt.Dispose()
'                    dt = Nothing
'                End If
'            End Try
'        End Function

'        Private Sub AddUnitsData(ByRef dr As DataRow, ByVal iTechID As Integer)
'            Dim strFilter As String
'            Dim drModels() As DataRow

'            Try
'                dr("Model Units/Hour") = 0
'                dr("Model HPU") = 0

'                strFilter = "employeeno = " & iTechID.ToString & " AND model_desc = '" & dr("Model").ToString & "'"
'                drModels = Me.Tables(Me._strModelData).Select(strFilter)

'                If drModels.Length > 0 Then
'                    dr("Model Units/Hour") = drModels(0)("Unit_Hour")

'                    If drModels(0)("Unit_Hour") <> 0 Then dr("Model HPU") = Math.Round(1 / drModels(0)("Unit_Hour"), 4)
'                End If
'            Catch ex As Exception
'                Me._objDataProc.DisplayMessage(ex.Message)
'            End Try
'        End Sub

'        'Private Function CreateModelDetailsReturnTable() As DataTable
'        '    Dim dt As DataTable

'        '    Try
'        '        dt = New DataTable("Model Details Return Data")

'        '        dt.Columns.Add(New DataColumn("Model", System.Type.GetType("System.String")))
'        '        dt.Columns.Add(New DataColumn("Device ID", System.Type.GetType("System.Int32")))
'        '        dt.Columns.Add(New DataColumn("QC Status", System.Type.GetType("System.String")))
'        '        dt.Columns.Add(New DataColumn("Units/Hour", System.Type.GetType("System.Double")))
'        '        dt.Columns.Add(New DataColumn("HPU", System.Type.GetType("System.Double")))

'        '        Return dt
'        '    Catch ex As Exception
'        '        Me._objDataProc.DisplayMessage(ex.Message)
'        '    Finally
'        '        If Not IsNothing(dt) Then
'        '            dt.Dispose()
'        '            dt = Nothing
'        '        End If
'        '    End Try
'        'End Function

'#End Region ' Get Data

'        Public Sub AddTable(ByVal strTblName As String, ByVal strSQL As String)
'            Dim dt As DataTable
'            Dim dr As DataRow

'            Try
'                dt = Me._objDataProc.GetDataTable(strSQL)

'                If Not IsNothing(dt) Then
'                    If Me.Tables.Contains(strTblName) Then
'                        Me.Tables(strTblName).Rows.Clear()

'                        For Each dr In dt.Rows
'                            Me.Tables(strTblName).ImportRow(dr)
'                        Next
'                    Else
'                        Me.Tables.Add(dt)
'                        Me.Tables(Me.Tables.Count - 1).TableName = strTblName
'                    End If
'                End If
'            Catch ex As Exception
'                Me._objDataProc.DisplayMessage(ex.Message)
'            Finally
'                dr = Nothing

'                If Not IsNothing(dt) Then
'                    dt.Dispose()
'                    dt = Nothing
'                End If
'            End Try
'        End Sub

'        Public Sub DisplayMessage(ByVal strMsg As String, Optional ByVal iStackIndex As Integer = 3, Optional ByVal bIsErrMsg As Boolean = True)
'            Me._objDataProc.DisplayMessage(strMsg, iStackIndex, bIsErrMsg)
'        End Sub

'#Region "Properties"
'        Public ReadOnly Property GetTechData()
'            Get
'                Return Me.Tables(Me._strTechData)
'            End Get
'        End Property

'        Public ReadOnly Property GetDeviceCount(ByVal iEEID As Integer)
'            Get
'                Return DeviceCount(iEEID)
'            End Get
'        End Property

'        Public ReadOnly Property GetRURRTMCount(ByVal iEEID As Integer, ByVal iBillCodeRule As Integer)
'            Get
'                Return RURRTMCount(iEEID, iBillCodeRule)
'            End Get
'        End Property

'        Public ReadOnly Property GetGoodCount(ByVal iEEID As Integer)
'            Get
'                Return GoodCount(iEEID)
'            End Get
'        End Property

'        Public ReadOnly Property GetRejectCount(ByVal iEEID As Integer)
'            Get
'                Return RejectCount(iEEID)
'            End Get
'        End Property

'        Public ReadOnly Property GetTechHours(ByVal iEEID As Integer)
'            Get
'                Return TechHours(iEEID)
'            End Get
'        End Property

'        Public ReadOnly Property GetLaborValue(ByVal iEEID As Integer)
'            Get
'                Return LaborValue(iEEID)
'            End Get
'        End Property

'        Public ReadOnly Property GetTechRate(ByVal iEEID As Integer)
'            Get
'                Return TechRate(iEEID)
'            End Get
'        End Property

'        Public ReadOnly Property GetPartsValue(ByVal iEEID As Integer)
'            Get
'                Return PartsValue(iEEID)
'            End Get
'        End Property

'        Public ReadOnly Property GetActualPoints(ByVal iEEID As Integer)
'            Get
'                Return ActualPoints(iEEID)
'            End Get
'        End Property

'        Public ReadOnly Property GetGoalPoints(ByVal dblHoursWorked As Double)
'            Get
'                Return GoalPoints(dblHoursWorked)
'            End Get
'        End Property

'        Public ReadOnly Property GetStandardPointGoalsPerHour()
'            Get
'                Return Me._dblStandardPointGoalsPerHour
'            End Get
'        End Property

'        Public ReadOnly Property GetRejectPoints(ByVal iEEID As Integer, ByVal dblFactor As Double)
'            Get
'                Return RejectPoints(iEEID, dblFactor)
'            End Get
'        End Property

'        Public ReadOnly Property GetModelDetails(ByVal iEEID As Integer)
'            Get
'                Return ModelDetails(iEEID)
'            End Get
'        End Property
'#End Region
'    End Class
'End Namespace
