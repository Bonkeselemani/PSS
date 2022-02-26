using System;
using System.Data;
using Microsoft.Data.Odbc;
using PSS.Data;
using System.Text;
using System.Diagnostics;



namespace PSSBase
{
	/// <summary>
	/// Summary description for QA.
	/// </summary>
	public class QA
	{
		#region DECLARATIONS

		private DateTime _start_dt;
		private DateTime _end_dt;
		private string _qc_type;

		private DataTable _smryDt = new DataTable();
		private DataTable _dtlDt = new DataTable();
	
		#endregion
		#region CONSTRUCTORS

		public QA()
		{
		}

		public QA(string qc_type, DateTime start_dt, DateTime end_dt)
	{
		_start_dt = start_dt;
		_end_dt = end_dt;
		_qc_type = qc_type;
		_smryDt = GetSummaryData();
		_dtlDt = GetDetailData();
		PutInPercFailForDtl();
		_dtlDt = SortDtlDT();
			//AddDtlTotalRow(_dt);


	}


		#endregion
		#region PROPERTIES

			public DateTime START_DT 
		{
			get{return _start_dt;}
			set{ _start_dt = value;}
		}
			public DateTime END_DT 
		{
			get{return _end_dt;}
			set{_end_dt = value;}
		}
			public string QC_TYPE 
		{
			get{return _qc_type;}
			set{_qc_type = value;}
		}
		
			public DataTable SummaryDT
			{
				get {return _smryDt;}
			}
			public DataTable DetailDT
			{
				get {return _dtlDt;}
			}


		#endregion
		#region METHODS

		// Summary Data Tables.
		protected DataTable GetSummaryData()
		{
			DataTable _dt = new DataTable();
			StringBuilder _sb = new StringBuilder();
			_sb.Append("SELECT DISTINCT ");
			_sb.Append("cd.Dcode_Ldesc AS Reason, ");
			_sb.Append("COUNT(qc.qcresult_id) AS Total, ");
			_sb.Append("SUM(CASE qc.qcresult_id WHEN 1 THEN 1 ELSE 0 END) AS Pass, ");
			_sb.Append("SUM(CASE qc.qcresult_id WHEN 2 THEN 1 ELSE 0 END) AS Fail, ");
			_sb.Append("0.00 AS '% Fail' ");
			_sb.Append("FROM ");
			_sb.Append("tdevice d ");
			_sb.Append("inner join tmessdata md on d.device_id = md.device_id ");
			_sb.Append("inner join tqc qc on md.device_id = qc.device_id ");
			_sb.Append("inner join lcodesdetail cd on qc.Dcode_id = cd.Dcode_id ");
			_sb.Append("inner join lqctype qct on qc.qctype_id = qct.qctype_id ");
			_sb.Append("left outer join tdevicebill db on md.device_id = db.device_id ");
			_sb.Append("left outer join lbillcodes bc on db.billcode_id = bc.billcode_id ");
			_sb.Append("left outer join lline l on qc.line_id = l.line_id ");
			_sb.Append("WHERE ");
			_sb.Append("qc_date BETWEEN '" + _start_dt.ToString("yyyy-MM-dd") + " 00:00:00' AND '" + _end_dt.ToString("yyyy-MM-dd") + " 23:59:59' AND ");
			_sb.Append("(qct.qctype = '" + _qc_type + "') ");
			_sb.Append("GROUP BY ");
			_sb.Append("cd.Dcode_Ldesc, ");
			_sb.Append("qct.qctype; ");
			Debug.WriteLine(_sb.ToString());
			DBQuery.DataProc _dbq = new DBQuery.DataProc(PSS.Data.ConfigFile.GetConnectionInfo());
			_dt = _dbq.GetDataTable(_sb.ToString());
			PutInPercFailForSummary(_dt);
			_dt = SortSmryDT(_dt);
			AddSmryTotalRow(_dt);
			return _dt;
		}

		protected int GetTotalCount(DataTable dt)
		{
			int _total = 0;
			foreach(DataRow _dr in dt.Rows)
			{
				_total += int.Parse(_dr["Total"].ToString());
			}
			return _total;
		}		
		
		protected void PutInPercFailForSummary(DataTable dt)
		{
			int _total = GetTotalCount(dt);
			foreach(DataRow _dr in dt.Rows)
			{
				decimal _pass = 0;
				decimal _fail = 0;
				decimal _prc = 0;
				_pass = decimal.Parse(_dr["Pass"].ToString());
				_fail = decimal.Parse(_dr["Fail"].ToString());
				_prc = System.Math.Round((_fail / _total * 100),2);
				_dr["% Fail"] = _prc/100;
			}
			dt.AcceptChanges();
		}

		protected DataTable SortSmryDT(DataTable dt)
		{
			// Sort the data.
			DataTable _dt2 = dt.Clone();
			DataRow[] _drs = dt.Select("", "% Fail DESC", DataViewRowState.CurrentRows);
			_dt2.BeginLoadData();
			foreach (DataRow _dr in _drs)
			{
				_dt2.LoadDataRow(_dr.ItemArray, true);
			}
			_dt2.EndLoadData();
			return _dt2;
		}

		protected void AddSmryTotalRow(DataTable dt)
		{
			decimal _total = 0;
			decimal _pass = 0;
			decimal _fail = 0;
			decimal _prc = 0;
			foreach(DataRow _dr in dt.Rows)
			{
				_total += decimal.Parse(_dr["Total"].ToString());
				_pass += decimal.Parse(_dr["Pass"].ToString());
				_fail += decimal.Parse(_dr["Fail"].ToString());
				_prc += decimal.Parse(_dr[4].ToString().Replace("%",""));
			}			
			DataRow _newDr = dt.NewRow();
			_newDr["Reason"] = "Total";
			_newDr["Total"] = _total;
			_newDr["Pass"] = _pass;
			_newDr["Fail"] = _fail;
			_newDr["% Fail"] = _prc;
			dt.Rows.Add(_newDr);
		}


		// Detail data tables.
		protected DataTable GetDetailData()
		{
			DataTable _dt = new DataTable();
			StringBuilder _sb = new StringBuilder();
			_sb.Append("SELECT DISTINCT ");
			_sb.Append("If(m.Model_Desc = 'Fuctional', 'FQA', m.Model_Desc) AS 'Model', ");
			_sb.Append("Device_SN as 'S/N', d.DEVICE_ID, ");
			_sb.Append("l.Line_Number, ");			
			_sb.Append("cd.Dcode_Ldesc AS 'Reason', ");
			_sb.Append("0.00 AS '% Fail' ");
			_sb.Append("FROM tdevice d ");
			_sb.Append("INNER JOIN tpallett on d.pallett_id = tpallett.pallett_id ");
			_sb.Append("INNER JOIN tpackingslip ON tpallett.pkslip_ID = tpackingslip.pkslip_ID ");
			_sb.Append("inner join tmessdata md on d.device_id = md.device_id ");
			_sb.Append("inner join lcodesdetail cd on qc.Dcode_id = cd.Dcode_id ");
			_sb.Append("inner join tmodel m on d.model_id = m.model_id ");
			_sb.Append("inner join tqc qc on md.device_id = qc.device_id ");
			_sb.Append("inner join lqctype qct on qc.qctype_id = qct.qctype_id ");
			_sb.Append("inner join tdevicebill db on md.device_id = db.device_id ");
			_sb.Append("left outer join lbillcodes bc on db.billcode_id = bc.billcode_id ");
			_sb.Append("left outer join lline l on qc.line_id = l.line_id ");
			_sb.Append("LEFT OUTER JOIN lfrequency ON md.freq_id = lfrequency.freq_ID ");
			_sb.Append("LEFT OUTER JOIN lbaud ON md.baud_id = lbaud.baud_ID ");
			_sb.Append("WHERE ");
			_sb.Append("qc_date BETWEEN '" + _start_dt.ToString("yyyy-MM-dd") + " 00:00:00' AND '" + _end_dt.ToString("yyyy-MM-dd") + " 23:59:59' AND ");
			_sb.Append("qc.qcresult_id = 2 AND ");
			_sb.Append("(qct.qctype = '" + _qc_type + "'); ");
			Debug.WriteLine(_sb.ToString());
			DBQuery.DataProc _dbq = new DBQuery.DataProc(PSS.Data.ConfigFile.GetConnectionInfo());
			_dt = _dbq.GetDataTable(_sb.ToString());
			return _dt;
		}
	
		protected void PutInPercFailForDtl()
		{
			// Join to other table to pick up the % Failed.
			foreach (DataRow _pdr in _smryDt.Rows)
			{
				foreach (DataRow _cdr in _dtlDt.Rows)
				{
					if((string)_pdr["Reason"] == (string)_cdr["Reason"])
						_cdr["% Fail"] = _pdr["% Fail"];
				}
			}
			_dtlDt.AcceptChanges();
		}


		protected DataTable SortDtlDT()
		{
			// Sort the data.
			DataTable _dt2 = _dtlDt.Clone();
			DataRow[] _drs = _dtlDt.Select("", "% Fail DESC", DataViewRowState.CurrentRows);
			_dt2.BeginLoadData();
			foreach (DataRow _dr in _drs)
			{
				_dt2.LoadDataRow(_dr.ItemArray, true);
			}
			_dt2.EndLoadData();
			return _dt2;
		}

		#endregion
	}
}
