Namespace BLL
	Public Class QaulityControl
		Public Sub New()
		End Sub
#Region "PUBLIC"
		Public Shared Function RemoveAllQCForDevice(ByVal device_id As Integer) As Boolean
			Dim sql As String = GetQCDeleteStatementForDevice(device_id)
			Try
				Dim _objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
				_objDataProc.ExecuteNonQuery(sql)
				Return True
			Catch ex As Exception
				Throw ex
			End Try
		End Function
#End Region
#Region "PRIVATE"
		Private Shared Function GetQCDeleteStatementForDevice(ByVal device_id As Integer) As String
			Dim _sql As String
			_sql = "DELETE FROM production.tqc "
			_sql += "WHERE device_id = " & device_id.ToString() & ""
			Return _sql
		End Function
#End Region
	End Class
End Namespace
