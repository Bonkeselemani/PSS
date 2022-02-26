Imports System.String
Imports System.Data
Imports System.Text
Namespace BLL
	Public Class WFMWarehouse
#Region "DECLARATIONS"

		Private _dtSerials As New DataTable()
		Private _model_id As Integer
		Private _qty As Integer
		Private _user_id As Integer
		Private _cust_id = 2597
		Private _loc_id = 3402

#End Region
#Region "CONSTRUCTORS"

		Public Sub New()
		End Sub

#End Region
#Region "PROPERTIES"

#End Region
#Region "METHODS"
		Public Function MoveBoxWithinWH(ByVal box_na As String, ByVal bin_id As Integer, ByVal user_id As Integer) As Boolean
			Try
				'UPDATE THE BIN OF THE BOX.
				Dim _result As Integer
				_result = Update_wh_box_bin(box_na, bin_id)
				Return (_result > 0)
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function Update_wh_box_bin(ByVal box_na As String, ByVal bin_id As Integer) As Integer
			' Updates a record into the warehouse.wh_box table.
			Dim _retVal As Integer
			Dim _wb As New BOL.wh_box(box_na)
			If _wb.whb_id < 1 Then
				Throw New Exception("Box " & box_na & " could not be found.")
			End If
			_wb.bin_id = bin_id
			_wb.ApplyChanges()
			_retVal = _wb.whb_id
			_wb = Nothing
			Return _retVal
		End Function
		Public Function MovePalletWithinWH(ByVal box_na As String, ByVal bin_id As Integer, ByVal user_id As Integer) As Boolean
			Try
				'UPDATE THE BIN OF THE PALLET.
				Dim _result As Integer
				_result = Update_pallet_bin(box_na, bin_id)
				Return (_result > 0)
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function Update_pallet_bin(ByVal pallet_name As String, ByVal bin_id As Integer) As Integer
			' Updates a record into the warehouse.wh_box table.
			Dim _retVal As Integer
			Dim _p As New BOL.tpallet(pallet_name)
			If _p.Pallett_ID < 1 Then
				Throw New Exception("Box " & pallet_name & " could not be found.")
			End If
			Dim _bin As New BOL.wh_bins(bin_id)
			Dim _binName As String = _bin.bin_na
			_bin = Nothing
			_p.WHLocation = _binName
			_p.ApplyChanges()
			_retVal = _p.Pallett_ID
			_p = Nothing
			Return _retVal
		End Function
		Private Function Inserttcellopt(ByVal device_id As Integer) As Integer
			' Insert a record into the production.tcellopt table.
			Dim _co As New BOL.tcellopt()
			_co.Device_ID = device_id
			_co.WorkStation = "WH-WIP"
			_co.WorkStationEntryDt = Date.Now
			_co.ApplyChanges()
			Return _co.CellOpt_ID
		End Function
#End Region
	End Class
	Public Class WFMBoxHandling
#Region "SHARED METHODS"
		Public Shared Function GetWfmFloorNoBin() As DataTable
			Dim _objDataProc As New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			Dim _dt As New DataTable()
			Dim _sb As New StringBuilder()
			_sb.Append("SELECT ")
			_sb.Append("wb.whb_id, ")
			_sb.Append("wb.box_na as box_na, ")
			_sb.Append("wb.quantity, ")
			_sb.Append("bins.bin_na, ")
			_sb.Append("m.model_desc, ")
			_sb.Append("CASE ")
			_sb.Append("WHEN cpl.loc_na = 'WH-FLOOR' and disp_cd = 'SOF' THEN 'SOF'")
			_sb.Append("WHEN cpl.loc_na = 'WH-FLOOR' and disp_cd = 'COS' THEN 'COS' ")
			_sb.Append("WHEN cpl.loc_na = 'WH-FLOOR' and disp_cd = 'FUN' THEN 'FUN' ")
			_sb.Append("WHEN cpl.loc_na = 'WH-FLOOR' and disp_cd = 'NTF' THEN 'NTF' ")
			_sb.Append("ELSE cpl.loc_na  ")
			_sb.Append("END AS Location ")
			_sb.Append("FROM warehouse.wh_box wb ")
			_sb.Append("INNER JOIN production.tmodel m ON wb.model_id = m.model_id  ")
			_sb.Append("INNER JOIN production.tcustomer_prod_locations cpl ON wb.cpl_id = cpl.cpl_id  ")
			_sb.Append("LEFT JOIN production.tdispositions disp on wb.disp_id = disp.disp_id  ")
			_sb.Append("LEFT JOIN warehouse.wh_bins bins on wb.bin_id = bins.bin_id ")
			_sb.Append("WHERE(wb.bin_id Is NULL And (disp.disp_id <> 5 Or disp.disp_id Is null) And cpl.allow_bin = 1) ")
			_sb.Append("UNION SELECT DISTINCT  ")
			_sb.Append("p.pallett_id,  ")
			_sb.Append("p.pallett_name as box_na,  ")
			_sb.Append("p.pallett_qty,  ")
			_sb.Append("p.whlocation,  ")
			_sb.Append("m.model_desc,  ")
			_sb.Append("CASE  ")
			_sb.Append("WHEN co.workstation = 'WH-FLOOR' and disp_cd = 'SOF' THEN 'SOF' ")
			_sb.Append("WHEN co.workstation = 'WH-FLOOR' and disp_cd = 'COS' THEN 'COS' ")
			_sb.Append("WHEN co.workstation = 'WH-FLOOR' and disp_cd = 'FUN' THEN 'FUN' ")
			_sb.Append("WHEN co.workstation = 'WH-FLOOR' and disp_cd = 'NTF' THEN 'NTF' ")
			_sb.Append("ELSE co.workstation ")
			_sb.Append("END AS Location ")
			_sb.Append("FROM tpallett p ")
			_sb.Append("INNER JOIN production.tmodel m ON p.model_id = m.model_id ")
			_sb.Append("inner join tdevice d on p.pallett_id = d.pallett_id ")
			_sb.Append("INNER JOIN tcellopt co on d.device_id = co.device_id ")
			_sb.Append("LEFT JOIN production.tdispositions disp on p.disp_id = disp.disp_id ")
			_sb.Append("WHERE ")
			_sb.Append("(p.WHLocation IS NULL or p.whlocation = '') AND  ")
			_sb.Append("co.workstation = 'WH-FLOOR' AND ")
			_sb.Append("d.loc_id = 3402 and ")
			_sb.Append("disp.disp_id = 5 ")
			_sb.Append("ORDER BY box_na; ")
			_dt = _objDataProc.GetDataTable(_sb.ToString())
			_objDataProc = Nothing
			Return _dt
		End Function
		Public Shared Function GetWfmFloorWithBin() As DataTable
			Dim _objDataProc As New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			Dim _dt As New DataTable()
			Dim _sb As New StringBuilder()
			_sb.Append("SELECT ")
			_sb.Append("wb.whb_id, ")
			_sb.Append("wb.box_na as box_na, ")
			_sb.Append("wb.quantity, ")
			_sb.Append("bins.bin_na, ")
			_sb.Append("m.model_desc, ")
			_sb.Append("CASE ")
			_sb.Append("WHEN cpl.loc_na = 'WH-FLOOR' and disp_cd = 'SOF' THEN 'SOF'")
			_sb.Append("WHEN cpl.loc_na = 'WH-FLOOR' and disp_cd = 'COS' THEN 'COS' ")
			_sb.Append("WHEN cpl.loc_na = 'WH-FLOOR' and disp_cd = 'FUN' THEN 'FUN' ")
			_sb.Append("WHEN cpl.loc_na = 'WH-FLOOR' and disp_cd = 'NTF' THEN 'NTF' ")
			_sb.Append("ELSE cpl.loc_na  ")
			_sb.Append("END AS Location ")
			_sb.Append("FROM warehouse.wh_box wb ")
			_sb.Append("INNER JOIN production.tmodel m ON wb.model_id = m.model_id  ")
			_sb.Append("INNER JOIN production.tcustomer_prod_locations cpl ON wb.cpl_id = cpl.cpl_id  ")
			_sb.Append("LEFT JOIN production.tdispositions disp on wb.disp_id = disp.disp_id  ")
			_sb.Append("INNER JOIN warehouse.wh_bins bins on wb.bin_id = bins.bin_id ")
			_sb.Append("WHERE (disp.disp_id <> 5 Or disp.disp_id Is null) And cpl.allow_bin = 1 ")
			_sb.Append("UNION SELECT DISTINCT  ")
			_sb.Append("p.pallett_id, ")
			_sb.Append("p.pallett_name as box_na, ")
			_sb.Append("p.pallett_qty, ")
			_sb.Append("p.WHLocation, ")
			_sb.Append("m.model_desc, ")
			_sb.Append("CASE  ")
			_sb.Append("WHEN co.workstation = 'WH-FLOOR' and disp_cd = 'SOF' THEN 'SOF' ")
			_sb.Append("WHEN co.workstation = 'WH-FLOOR' and disp_cd = 'COS' THEN 'COS' ")
			_sb.Append("WHEN co.workstation = 'WH-FLOOR' and disp_cd = 'FUN' THEN 'FUN' ")
			_sb.Append("WHEN co.workstation = 'WH-FLOOR' and disp_cd = 'NTF' THEN 'NTF' ")
			_sb.Append("ELSE co.workstation ")
			_sb.Append("END AS Location ")
			_sb.Append("FROM tpallett p ")
			_sb.Append("INNER JOIN production.tmodel m ON p.model_id = m.model_id ")
			_sb.Append("inner join tdevice d on p.pallett_id = d.pallett_id ")
			_sb.Append("INNER JOIN tcellopt co on d.device_id = co.device_id ")
			_sb.Append("LEFT JOIN production.tdispositions disp on p.disp_id = disp.disp_id ")
			_sb.Append("WHERE ")
			_sb.Append("(p.WHLocation IS NOT NULL and p.whlocation <> '') AND  ")
			_sb.Append("co.workstation = 'WH-FLOOR' AND ")
			_sb.Append("d.loc_id = 3402 and ")
			_sb.Append("disp.disp_id = 5 ")
			_sb.Append("ORDER BY box_na; ")
			_dt = _objDataProc.GetDataTable(_sb.ToString())
			_objDataProc = Nothing
			Return _dt
		End Function
#End Region
	End Class
End Namespace
