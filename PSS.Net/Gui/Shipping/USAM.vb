Imports System.IO
Imports eInfoDesigns.dbProvider.MySqlClient
Imports Microsoft.Data.Odbc

Public Class CUSAM

    Private Shared _conn As MySqlConnection = Nothing

    Public Shared mSeqNumber, mSerialNumber, mFO, mCapCode, mCapCodeNew, mFrequency, mChannel, mModel, mSKU As String


#Region "Database Methods"

    Private Function getConnection(Optional ByVal database As String = "production") As MySqlConnection

        Dim strConn As String = "SERVER=172.16.25.21" & _
                                ";DATABASE=production" & _
                                ";USER ID=appuser" & _
                                ";PASSWORD=appuser" & _
                                ";POOLING=TRUE;"

        Dim c As New MySqlConnection()
        Return New MySqlConnection(strConn)

    End Function

    Public Function getData() As DataTable

        _conn = getConnection()
        Dim strSQL As String = "select tdevice.device_sn, tdevicemetro.devicemetro_capcode from " & _
                                "tdevice left outer join tdevicemetro on tdevice.device_sn = tdevicemetro.devicemetro_sn " & _
                                "where tdevice.loc_id=2615 and tdevicemetro.devicemetro_capcode is not null order by tdevice.device_sn"
        Dim _cmd As New MySqlCommand(strSQL, _conn)
        Dim _da As New MySqlDataAdapter()
        _da.SelectCommand = _cmd
        Dim _dt As New DataTable()
        _da.Fill(_dt)
        _da.Dispose()
        _conn.Close()
        _conn.Dispose()
        _conn = Nothing
        Return _dt

    End Function





#End Region

#Region "Assign Derived Values"

    Public Shared Function createShipDate() As String
        Return Format(Now, "yyyyMMdd") '//Set static variable = mShipDate
    End Function

    Public Shared Function createOutputFileName(ByVal vOutputPrefix, ByVal vVendor) As String
        Return Trim(Trim(vOutputPrefix) & Trim(vVendor) & "_" & Trim(Format(Now, "yyMMdd")) & ".csv")    '//Create name for output file
    End Function

#End Region

#Region "Output Methods"


    Public Shared Function checkFile(ByVal mfilename As String) As Integer

        Dim cFile As String
        cFile = Dir("C:\" & mfilename)

        If Trim(cFile) = "" Then
            checkFile = 0
        Else
            checkFile = 1
        End If


    End Function

    Public Shared Function createOutput(ByVal vdt As DataTable, ByVal mFileName As String, ByVal vShipDate As String, ByVal mFO As String, ByVal mFrequency As String, ByVal mChannel As String, ByVal mModel As String, ByVal mSKU As String) As Boolean

        Dim fs As New FileStream("c:\" & mFileName, FileMode.Create, FileAccess.Write)
        Dim s As New StreamWriter(fs)
        s.BaseStream.Seek(0, SeekOrigin.End)

        '//This section has been removed so that these values can be entered by the user when creating the file
        '//These values are now being passed by the user
        '//BEGIN
        'mFO = ""
        'mCapCode = ""
        'mFrequency = ""
        'mChannel = ""
        'mModel = ""
        'mSKU = ""

        'mFO = "PSS021905154403"
        'mFrequency = "9296125"
        'mChannel = "ZA"
        'mModel = "TI3"
        'mSKU = "TI3BLKFLZA DIR"
        '//END

        '//Define Header
        Dim strHprefix As String = "HDR"
        Dim strDprefix As String = "DTL"
        Dim strTprefix As String = "TOT"

        Dim strHeader, strDetail, strTotal As String

        Dim seqNumber As Integer
        Dim mLot As String = "001"
        Dim mBox As String = "01"

        Dim mVendor As String = "PSSI"
        Dim mShipDate As String = vShipDate.PadLeft(6, " ")

        '//Write Header Line of File
        strHeader = strHprefix & "," & mVendor & "," & mShipDate
        s.WriteLine(strHeader)

        '//Write Detail Line(s) of File
        Dim xCount As Integer = 0
        Dim r As DataRow
        seqNumber = 0
        For xCount = 0 To vdt.Rows.Count - 1
            seqNumber += 1
            mSeqNumber = CStr(seqNumber).PadLeft(7, "0")
            r = vdt.Rows(xCount)
            mSerialNumber = r("Device_SN")
            If IsDBNull(r("Devicemetro_CapCode")) = False Then
                mCapCode = r("Devicemetro_CapCode")
                If Mid$(mCapCode, 1, 1) = "E" Then mCapCode = Mid$(mCapCode, 2, 10)
                If Mid$(mCapCode, 1, 1) = "e" Then mCapCode = Mid$(mCapCode, 2, 10)
                If Len(Trim(mCapCode.ToString)) < 10 Then
                    mCapCodeNew = mCapCode.PadRight(10)
                End If
            Else
                mCapCode = ""
                mCapCodeNew = ""

            End If

            strDetail = strDprefix & "," & mSeqNumber & "," & mSerialNumber & "," & _
                        mFO & "," & mLot & "," & mBox & "," & mCapCodeNew.ToString & "," & mFrequency & "," & _
                        mChannel & "," & mModel & "," & mSKU
            s.WriteLine(strDetail)
        Next

        '//Write TotalLine of File
        strTotal = strTprefix & "," & mSeqNumber
        s.WriteLine(strTotal)

        '//Close File
        s.Close()

        Return True

    End Function

#End Region

End Class
