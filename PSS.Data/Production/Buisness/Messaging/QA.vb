Imports System
Imports System.Data
Imports Microsoft.Data.Odbc
Imports PSS.Data
Imports System.Text
Imports System.Diagnostics

Namespace Buisness

    Public Class QA
#Region "DECLARATIONS"

        Private _start_dt As Date
        Private _end_dt As Date
        Private _qc_type As String

        Private _smryDt As New DataTable()
        Private _dtlDt As New DataTable()

#End Region
#Region "CONSTRUCTORS"

        Public Sub New()
        End Sub

        Public Sub New(ByVal qc_type As String, ByVal start_dt As Date, ByVal end_dt As Date, ByVal IncludeCntWrls As Boolean)
            _start_dt = start_dt
            _end_dt = end_dt
            _qc_type = qc_type
            _smryDt = GetSummaryData(IncludeCntWrls)
            _dtlDt = GetDetailData(IncludeCntWrls)
            PutInPercFailForDtl()
            _dtlDt = SortDtlDT()
            'AddDtlTotalRow(_dt);


        End Sub


#End Region
#Region "PROPERTIES"

        Public Property START_DT() As Date
            Get
                Return _start_dt
            End Get
            Set(ByVal value As Date)
                _start_dt = value
            End Set
        End Property
        Public Property END_DT() As Date
            Get
                Return _end_dt
            End Get
            Set(ByVal value As Date)
                _end_dt = value
            End Set
        End Property
        Public Property QC_TYPE() As String
            Get
                Return _qc_type
            End Get
            Set(ByVal value As String)
                _qc_type = value
            End Set
        End Property

        Public ReadOnly Property SummaryDT() As DataTable
            Get
                Return _smryDt
            End Get
        End Property
        Public ReadOnly Property DetailDT() As DataTable
            Get
                Return _dtlDt
            End Get
        End Property


#End Region
#Region "METHODS"

        ' Summary Data Tables.
        Protected Function GetSummaryData(ByVal _includeCntWrls As Boolean) As DataTable
            Dim _dt As New DataTable()
            Dim _sb As New StringBuilder()
            _sb.Append("SELECT DISTINCT ")
            _sb.Append("cd.Dcode_Ldesc AS Reason, ")
            _sb.Append("COUNT(qc.qcresult_id) AS Total, ")
            _sb.Append("SUM(CASE qc.qcresult_id WHEN 1 THEN 1 ELSE 0 END) AS Pass, ")
            _sb.Append("SUM(CASE qc.qcresult_id WHEN 2 THEN 1 ELSE 0 END) AS Fail, ")
            _sb.Append("0.00 AS '% Fail' ")
            _sb.Append("FROM ")
            _sb.Append("tdevice d ")
            _sb.Append("inner join tlocation loc ON d.loc_id = loc.loc_id ")
            _sb.Append("inner join tcustomer cust on loc.cust_id = cust.cust_id ")
            _sb.Append("inner join tmessdata md on d.device_id = md.device_id ")
            _sb.Append("inner join tqc qc on d.device_id = qc.device_id ")
            _sb.Append("inner join lcodesdetail cd on qc.Dcode_id = cd.Dcode_id ")
            _sb.Append("inner join lqctype qct on qc.qctype_id = qct.qctype_id ")
            _sb.Append("WHERE ")
            _sb.Append("(qc_date BETWEEN '" & _start_dt.ToString("yyyy-MM-dd") & " 00:00:00' AND '" & _end_dt.ToString("yyyy-MM-dd") & " 23:59:59') AND ")
            If _includeCntWrls Then
                _sb.Append("(cust.cust_id in(14,444,2563,2507,2508,2574)) AND ")
            Else
                _sb.Append("(cust.cust_id in(14,444,2563,2507,2508)) AND ")
            End If
            _sb.Append("(qct.qctype = '" & _qc_type & "') ")
            _sb.Append("GROUP BY ")
            _sb.Append("cd.Dcode_Ldesc, ")
            _sb.Append("qct.qctype; ")
            Debug.WriteLine(_sb.ToString())
            Dim _dbq As New DBQuery.DataProc(PSS.Data.ConfigFile.GetConnectionInfo())
            _dt = _dbq.GetDataTable(_sb.ToString())
            PutInPercFailForSummary(_dt)
            _dt = SortSmryDT(_dt)
            AddSmryTotalRow(_dt)
            Return _dt
        End Function

        Protected Function GetTotalCount(ByVal dt As DataTable) As Integer
            Dim _total As Integer = 0
            Dim _dr As DataRow
            For Each _dr In dt.Rows
                _total += Integer.Parse(_dr("Total").ToString())
            Next _dr
            Return _total
        End Function

        Protected Sub PutInPercFailForSummary(ByVal dt As DataTable)
            Dim _total As Integer = GetTotalCount(dt)
            Dim _dr As DataRow
            For Each _dr In dt.Rows
                Dim _pass As Decimal = 0
                Dim _fail As Decimal = 0
                Dim _prc As Decimal = 0
                _pass = Decimal.Parse(_dr("Pass").ToString())
                _fail = Decimal.Parse(_dr("Fail").ToString())
                _prc = System.Math.Round((_fail / _total * 100), 2)
                _dr("% Fail") = _prc '/ 100
            Next _dr
            dt.AcceptChanges()
        End Sub

        Protected Function SortSmryDT(ByVal dt As DataTable) As DataTable
            ' Sort the data.
            Dim _dt2 As DataTable = dt.Clone()
            Dim _drs() As DataRow = dt.Select("", "% Fail DESC", DataViewRowState.CurrentRows)
            _dt2.BeginLoadData()
            Dim _dr As DataRow
            For Each _dr In _drs
                _dt2.LoadDataRow(_dr.ItemArray, True)
            Next _dr
            _dt2.EndLoadData()
            Return _dt2
        End Function

        Protected Sub AddSmryTotalRow(ByVal dt As DataTable)
            Dim _total As Decimal = 0
            Dim _pass As Decimal = 0
            Dim _fail As Decimal = 0
            Dim _prc As Decimal = 0
            Dim _dr As DataRow
            For Each _dr In dt.Rows
                _total += Decimal.Parse(_dr("Total").ToString())
                _pass += Decimal.Parse(_dr("Pass").ToString())
                _fail += Decimal.Parse(_dr("Fail").ToString())
                _prc += Decimal.Parse(_dr(4).ToString().Replace("%", ""))
            Next _dr
            Dim _newDr As DataRow = dt.NewRow()
            _newDr("Reason") = "Total"
            _newDr("Total") = _total
            _newDr("Pass") = _pass
            _newDr("Fail") = _fail
            _newDr("% Fail") = _prc
            dt.Rows.Add(_newDr)
        End Sub

        ' Detail data tables.
        Protected Function GetDetailData(ByVal _includeCntWrls As Boolean) As DataTable
            Dim _dt As New DataTable()
            Dim _sb As New StringBuilder()
            _sb.Append("SELECT ")
            _sb.Append("If(m.Model_Desc = 'Fuctional', 'FQA', m.Model_Desc) AS 'Model', ")
            _sb.Append("Device_SN as 'S/N', d.DEVICE_ID, ")
            _sb.Append("cc.cc_desc AS 'Line_Number', ")
            _sb.Append("cd.Dcode_Ldesc AS 'Reason', ")
            _sb.Append("0.00 AS '% Fail' ")
            _sb.Append("FROM tdevice d ")
            _sb.Append("inner join tlocation loc ON d.loc_id = loc.loc_id ")
            _sb.Append("inner join tcustomer cust on loc.cust_id = cust.cust_id ")
            _sb.Append("inner join tmessdata md on d.device_id = md.device_id ")
            _sb.Append("inner join tqc qc on d.device_id = qc.device_id ")
            _sb.Append("inner join lcodesdetail cd on qc.Dcode_id = cd.Dcode_id ")
            _sb.Append("inner join tmodel m on d.model_id = m.model_id ")
            _sb.Append("inner join lqctype qct on qc.qctype_id = qct.qctype_id ")
            _sb.Append("inner join tcostcenter cc on d.cc_id = cc.cc_id ")
            _sb.Append("WHERE ")
            _sb.Append("(qc_date BETWEEN '" & _start_dt.ToString("yyyy-MM-dd") & " 00:00:00' AND '" & _end_dt.ToString("yyyy-MM-dd") & " 23:59:59') AND ")
            _sb.Append("(qc.qcresult_id = 2) AND ")
            If _includeCntWrls Then
                _sb.Append("(cust.cust_id in(14,444,2563,2507,2508,2574)) AND ")
            Else
                _sb.Append("(cust.cust_id in(14,444,2563,2507,2508)) AND ")
            End If
            _sb.Append("(qct.qctype = '" & _qc_type & "'); ")
            Debug.WriteLine(_sb.ToString())
            Dim _dbq As New DBQuery.DataProc(PSS.Data.ConfigFile.GetConnectionInfo())
            _dt = _dbq.GetDataTable(_sb.ToString())
            Return _dt
        End Function

        Protected Sub PutInPercFailForDtl()
            ' Join to other table to pick up the % Failed.
            Dim _pdr As DataRow
            For Each _pdr In _smryDt.Rows
                Dim _cdr As DataRow
                For Each _cdr In _dtlDt.Rows
                    If DirectCast(_pdr("Reason"), String) = DirectCast(_cdr("Reason"), String) Then
                        _cdr("% Fail") = _pdr("% Fail")
                    End If
                Next _cdr
            Next _pdr
            _dtlDt.AcceptChanges()
        End Sub


        Protected Function SortDtlDT() As DataTable
            ' Sort the data.
            Dim _dt2 As DataTable = _dtlDt.Clone()
            Dim _drs() As DataRow = _dtlDt.Select("", "% Fail DESC, Reason ASC", DataViewRowState.CurrentRows)
            _dt2.BeginLoadData()
            Dim _dr As DataRow
            For Each _dr In _drs
                _dt2.LoadDataRow(_dr.ItemArray, True)
            Next _dr
            _dt2.EndLoadData()
            Return _dt2
        End Function

#End Region
    End Class
End Namespace
