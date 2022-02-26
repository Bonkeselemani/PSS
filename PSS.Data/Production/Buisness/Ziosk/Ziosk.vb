Option Explicit On 

Imports CrystalDecisions.CrystalReports.Engine

Namespace Buisness
    Public Class Ziosk
        Private _objDataProc As DBQuery.DataProc
        Private strRptPath As String = "P:\Dept\Labels\" & System.Net.Dns.GetHostName & "\"

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

        Public Shared ReadOnly Property CUSTOMER_ID() As Integer
            Get
                Return 2600
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property LOC_ID1() As Integer
            Get
                Return 3406
            End Get
        End Property

        Public Shared ReadOnly Property LOC_ID2() As Integer
            Get
                Return 3407
            End Get
        End Property

        '******************************************************************
        Public Shared ReadOnly Property Prod_ID() As Integer
            Get
                Return 53
            End Get
        End Property

        Public Function IsSNExist(ByVal iCust_ID As Integer, ByVal iModel_ID As Integer, ByVal strSN As String) As Boolean
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "select A.Device_ID,A.Device_SN from tdevice A" & Environment.NewLine
                strSql &= " inner join tmodel B on A.Model_ID=B.Model_ID" & Environment.NewLine
                strSql &= " inner join tlocation C on A.Loc_ID=C.Loc_ID" & Environment.NewLine
                strSql &= " inner join tcustomer D on C.Cust_ID=D.Cust_ID" & Environment.NewLine
                strSql &= " where D.Cust_ID=" & iCust_ID & " and A.Model_ID=" & iModel_ID & " and A.device_SN  = '" & strSN.Replace("'", "''") & "';" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then Return True

                Return False
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Sub getFCCAndModelLabelDesc(ByVal iModel_ID As Integer, ByRef strFCC As String, ByRef strModelLabelDesc As String)
            Try
                Dim dt As DataTable, row As DataRow
                Dim strSql As String = ""

                strSql = "Select * from llabel where model_id = " & iModel_ID & ";"
                dt = Me._objDataProc.GetDataTable(strSql)

                For Each row In dt.Rows      'should be one row. Take the first row  
                    strFCC = Trim(row("label_fcc"))
                    strModelLabelDesc = Trim(row("label_model_numb"))
                    Exit For
                Next

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Function PrintZioskLabel(ByVal iCust_ID As Integer, _
                                        ByVal iModel_ID As Integer, _
                                        ByVal strSN As String, _
                                        ByVal strHWVer As String, _
                                        ByVal strModelLabelDesc As String, _
                                        ByVal strMFGSite As String, _
                                        ByVal strDeviceRev As String, _
                                        ByVal strLabelPN As String, _
                                        ByVal strMadeIn As String, _
                                        ByVal strFCC As String)
            Dim dt As DataTable
            Dim strSql As String = ""
            Dim objRpt As ReportDocument
            Dim R1 As DataRow
            Dim strRptName As String = ""

            'Get Report name from llabel
            strSql = "Select * from lcustmodlbl where model_id = " & iModel_ID & " and cust_id = " & iCust_ID & ";"
            dt = Me._objDataProc.GetDataTable(strSql)

            If dt.Rows.Count = 0 Then
                Throw New Exception("Report Name could not be determined. Label for this Model and Customer may not be setup.")
            End If
            For Each R1 In dt.Rows      'Take the first row and move on
                strRptName = Trim(R1("Label_Name"))
                Exit For
            Next R1

            'Strip the extension
            If strRptName.Trim.IndexOf(".") > -1 Then strRptName = strRptName.Trim.Substring(0, strRptName.Trim.IndexOf("."))
            strRptName &= " Push.rpt"

            strSql = "Select '" & strSN.Replace("'", "''") & "' as 'DeviceSN'"
            strSql &= ",'" & strModelLabelDesc.Replace("'", "''") & "' as 'ModelLabelDesc'"
            strSql &= ",'" & strHWVer.Replace("'", "''") & "' as 'HWVer'"
            strSql &= ",'" & strMFGSite.Replace("'", "''") & "' as 'MSGSite'"
            strSql &= ",'" & strDeviceRev.Replace("'", "''") & "' as 'DeviceRev'"
            strSql &= ",'" & strLabelPN.Replace("'", "''") & "' as 'LabelPN'"
            strSql &= ",'" & strMadeIn.Replace("'", "''") & "' as 'MadeIn'"
            strSql &= ",'" & strFCC.Replace("'", "''") & "' as 'FCCID'"

            'Print Label
            objRpt = New ReportDocument()

            With objRpt
                .Load(strRptPath & strRptName)

                dt = Me._objDataProc.GetDataTable(strSql)

                If Not IsNothing(dt) Then .SetDataSource(dt)

                .PrintToPrinter(1, True, 0, 0)
            End With
        End Function

    End Class
End Namespace
