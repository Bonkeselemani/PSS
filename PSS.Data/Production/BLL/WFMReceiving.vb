Imports System.String
Imports System.Data
Namespace BLL
	Public Class WFMReceiving
		Inherits BaseClasses.CustReceiving
#Region "DECLARATIONS"
#End Region
#Region "CONSTRUCTORS"
		Sub New(ByVal user_id As Integer)
			MyBase.New(user_id)
			_cust_id = 2597
			_loc_id = 3402
		End Sub
#End Region
#Region "PROPERTIES"
#End Region
#Region "METHODS"
		Public Overrides Function GetBoxNumber(ByVal Prefix As String) As String
			' Builds the box number to be used.
			Dim _prefix As String = Prefix
			Dim _warantyStatus As String = "OW"
			Dim _date As String = Date.Now.Date.ToString("yyyyMMdd")
			Dim _boxNumber As String = ""
			Dim _retVal As String
			Dim _twhbox As New Data.BOL.wh_boxMaxNumber(_prefix & _date & _warantyStatus)
			_boxNumber = _twhbox.NextBoxNr
			_twhbox = Nothing
			_retVal = _boxNumber
			Return _retVal
		End Function
#End Region
	End Class
End Namespace
