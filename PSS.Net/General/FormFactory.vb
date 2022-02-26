Imports PSS.Data

Public Class FormFactory

	Public Shared Sub OpenDispostionEdit(ByVal id As Integer)
		Dim _frm As New frmDispositionEdit(id)
		_frm.ShowDialog()
	End Sub

	Public Shared Sub OpenCustProdLocEdit(ByVal id As Integer)
		Dim _frm As New frmCustProdLocEdit(id)
		_frm.ShowDialog()
	End Sub

	Public Shared Sub OpenProductEdit(ByVal id As Integer)
		Dim _frm As New frmProductEdit(id)
		_frm.ShowDialog()
	End Sub

End Class
