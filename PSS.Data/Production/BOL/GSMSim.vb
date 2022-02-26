
Namespace BOL

Public Class GSMSim

#region "DECLARATIONS"

		Dim _sn As String = ""
		Dim _snLen As Integer = 20
		Dim _prefixLen As Integer = 13
		Dim _incrPos As Integer = 13
		Dim _incrLen As Integer = 5
		Dim _suffixPos As Integer = 19
		Dim _suffixLen As Integer = 1
		Dim _chksumPos As Integer = 18

#end region
#region "CONSTRUCTORS"

		Public Sub New(ByVal sn As String)
			If sn.Length <> 20 Then
				Throw New Exception("GSM SIM serial numbers must be 20 characters in lenght.")
			End If
			If sn.Substring(19, 1) <> "F" Then
				Throw New Exception("GSM SIM serial numbers must end with ""F"".")
			End If
			_sn = sn
		End Sub

#End Region
#Region "PROPERTIES"

		Public ReadOnly Property SerialNumber_Original() As String
			Get
				Return _sn
			End Get
		End Property

		Public ReadOnly Property SerialNumber_Calculated() As String
			Get
				Return Prefix & Incremental & Checksum_Calculated & Suffix
			End Get
		End Property

		Public ReadOnly Property SerialNumberNoChkSum() As String
			Get
				Return Prefix & Incremental
			End Get
		End Property

		Public ReadOnly Property Prefix() As String
			Get
				Return _sn.Substring(0, _prefixLen)
			End Get
		End Property

		Public ReadOnly Property Incremental() As String
			Get
				Return _sn.Substring(_incrPos, _incrLen)
			End Get
		End Property

		Public ReadOnly Property Suffix() As String
			Get
				Return _sn.Substring(_suffixPos, _suffixLen)
			End Get
		End Property

		Public ReadOnly Property Checksum() As String
			Get
				Return _sn.Substring(_chksumPos, 1)
			End Get
		End Property

		Public ReadOnly Property Checksum_Calculated() As String
			Get
				' GETS THE VALID CHECKSUM FOR A SERIAL NUMBER STRING.
				Dim odd As Boolean = True
				Dim i As Integer = 0
				Dim idWithoutCheckdigit As String = _sn.Substring(0, _sn.Length - 2)
				' this will be a running total
				Dim sum As Integer = 0
				' allowable characters within identifier
				Const validChars As String = "0123456789ABCDEFGHIJKLMNOPQRSTUVYWXZ_"
				' remove leading or trailing whitespace, convert to uppercase
				idWithoutCheckdigit = idWithoutCheckdigit.Trim().ToUpper()
				' loop through digits from right to left
				For i = 0 To idWithoutCheckdigit.Length - 1
					'set ch to "current" character to be processed
					Dim ch As Char = idWithoutCheckdigit.Chars(idWithoutCheckdigit.Length - i - 1)
					' throw exception for invalid characters
					If validChars.IndexOf(ch) = -1 Then
						Throw New Exception(ch & " is an invalid character")
					End If
					' our "digit" is calculated using ASCII value - 48
					Dim digit As Integer = AscW(ch) - 48
					' weight will be the current digit's contribution to
					' the running total
					Dim weight As Integer
					If i Mod 2 = 0 Then
						' for alternating digits starting with the rightmost, we
						' use our formula this is the same as multiplying x 2 and
						' adding digits together for values 0 to 9.  Using the
						' following formula allows us to gracefully calculate a
						' weight for non-numeric "digits" as well (from their
						' ASCII value - 48).
						weight = (2 * digit) - CInt(digit \ 5) * 9
					Else
						' even-positioned digits just contribute their ascii
						' value minus 48
						weight = digit
					End If

					' keep a running total of weights
					sum += weight
				Next i
				' avoid sum less than 10 (if characters below "0" allowed,
				' this could happen)
				sum = Math.Abs(sum) + 10
				' check digit is amount needed to reach next number
				' divisible by ten
				Return (10 - (sum Mod 10)) Mod 10
			End Get
		End Property

		'Private Shared Function GSMCheckDigit(ByVal idWithoutCheckdigit As String) As Integer
		'	' allowable characters within identifier
		'	Const validChars As String = "0123456789ABCDEFGHIJKLMNOPQRSTUVYWXZ_"
		'	Dim i As Integer = 0
		'	' remove leading or trailing whitespace, convert to uppercase
		'	idWithoutCheckdigit = idWithoutCheckdigit.Trim().ToUpper()
		'	' this will be a running total
		'	Dim sum As Integer = 0
		'	' loop through digits from right to left
		'	For i = 0 To idWithoutCheckdigit.Length - 1
		'		'set ch to "current" character to be processed
		'		Dim ch As Char = idWithoutCheckdigit.Chars(idWithoutCheckdigit.Length - i - 1)
		'		' throw exception for invalid characters
		'		If validChars.IndexOf(ch) = -1 Then
		'			Throw New Exception(ch & " is an invalid character")
		'		End If
		'		' our "digit" is calculated using ASCII value - 48
		'		Dim digit As Integer = AscW(ch) - 48
		'		' weight will be the current digit's contribution to
		'		' the running total
		'		Dim weight As Integer
		'		If i Mod 2 = 0 Then
		'			' for alternating digits starting with the rightmost, we
		'			' use our formula this is the same as multiplying x 2 and
		'			' adding digits together for values 0 to 9.  Using the
		'			' following formula allows us to gracefully calculate a
		'			' weight for non-numeric "digits" as well (from their
		'			' ASCII value - 48).
		'			weight = (2 * digit) - CInt(digit \ 5) * 9
		'		Else
		'			' even-positioned digits just contribute their ascii
		'			' value minus 48
		'			weight = digit
		'		End If

		'		' keep a running total of weights
		'		sum += weight
		'	Next i

		'	' avoid sum less than 10 (if characters below "0" allowed,
		'	' this could happen)
		'	sum = Math.Abs(sum) + 10
		'	' check digit is amount needed to reach next number
		'	' divisible by ten
		'	Return (10 - (sum Mod 10)) Mod 10
		'End Function

#End Region

	End Class

End Namespace

