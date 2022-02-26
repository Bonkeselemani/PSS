Imports System.Text
Imports System.String
Imports System.Runtime.InteropServices
Namespace BaseClasses
	Public Class StringFunctions
#Region "SHARED METHODS"
		Public Shared Function PadZeros(ByVal length As Integer, ByVal value As Integer) As String
			' Pads a number with zeros.
			Dim _fmt As String = ""
			Dim _retVal As String = ""
			Dim i As Integer = 0
			For i = 1 To length
				_fmt = Concat(_fmt, "0")
			Next
			_retVal = value.ToString(_fmt)
			Return _retVal
		End Function
		Public Shared Function StrPtr(ByVal obj As Object) As Integer
			Dim Handle As GCHandle = GCHandle.Alloc(obj, GCHandleType.Pinned)
			Dim intReturn As Integer = Handle.AddrOfPinnedObject.ToInt32
			Handle.Free()
			Return intReturn
		End Function
#End Region
	End Class
End Namespace
