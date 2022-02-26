Option Explicit On 

Imports PSS.Data
Imports PSS.Data.BOL
Imports PSS.Data.Buisness.Generic
Imports system.Text
Imports DBQuery.DataProc

Namespace BLL

	Public Class AMSReceiving

#Region "SHARED METHODS"

		Public Shared Function GetDbrNerForSN(ByVal sn As String, ByVal model_id As Integer) As Integer
			Dim _retVal As Integer = 0
			Dim _dt As New DataTable()
			Dim _objDataProc As New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			Dim _sb As New StringBuilder()
			' CHECK FOR DEVICE DBR/NER RECORDS.
			_sb.Append("SELECT ")
			_sb.Append("devc.devicecode_id ")
			_sb.Append("FROM tdevicecodes devc ")
			_sb.Append("INNER JOIN lcodesdetail cd ON devc.Dcode_ID = cd.Dcode_id ")
			_sb.Append("INNER JOIN tdevice d ON devc.device_id = d.device_id ")
			_sb.Append("WHERE ")
			_sb.Append("cd.Mcode_Id = 21 ")
			_sb.Append("AND ")
			_sb.Append("d.Device_sn = '" & sn & "' ")
			_sb.Append("AND ")
			_sb.Append("d.model_id = " & model_id & "; ")
			_dt = _objDataProc.GetDataTable(_sb.ToString())
			If _dt.Rows.Count = 0 Then
				Throw New Exception("No DBR/NER record was found for this model with this serial number.")
			Else
				_retVal = _dt.Rows(0)("devicecode_id")
				Return _retVal
			End If
		End Function

#End Region

	End Class

End Namespace
