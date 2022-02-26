
Namespace Rules

    Public Enum SearchTypes
        CompanyName
        CustomerLastName
        CustoemerWO
        PSSWO
        Tray
        Serial
        ShipManifest
        OldSerial
        IMEI
        Pallet
        DyscernDID
        SonitrolRMA
        PackingSlipNumber
        SyxMfgSerial
    End Enum

    Public Class Search

        Public Shared Function GetMainData(ByVal searchString As String, ByVal searchType As SearchTypes) As DataView
            Return PSS.Data.Buisness.Search.GetMainData(GetSearchType(searchType) & " = " & searchString).DefaultView
        End Function

        Public Shared Function GetMainData(ByVal searchString As String, ByVal searchType As SearchTypes, ByVal startDate As Date, ByVal endDate As Date) As DataView
            Return PSS.Data.Buisness.Search.GetMainData(GetSearchType(searchType) & " = " & searchString, FormatMySqlDate(startDate), FormatMySqlDate(endDate)).DefaultView
        End Function

        Public Shared Function GetPartialData(ByVal searchString As String, ByVal searchType As SearchTypes, ByVal startDate As Date, ByVal endDate As Date)
            Return PSS.Data.Buisness.Search.GetMainData(GetSearchType(searchType) & " LIKE " & searchString, FormatMySqlDate(startDate), FormatMySqlDate(endDate)).DefaultView
        End Function

        Private Shared Function FormatMySqlDate(ByVal myDate As Date) As String
            Return "'" & myDate.Year & "-" & myDate.Month & "-" & myDate.Day & "'"
        End Function

        Public Shared Function GetParts(ByVal id As Integer) As DataView
            Try
                Return PSS.Data.Buisness.Search.GetPartData(id).DefaultView
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function GetDevice(ByVal id As Integer) As DataView
            Return PSS.Data.Buisness.Search.GetDeviceData(id).DefaultView
        End Function

        Public Shared Function GetMessagingData(ByVal searchString As String) As DataView
            Return PSS.Data.Buisness.Search.GetMessagingData(searchString).DefaultView
        End Function

        Public Shared Function GetPretestData(ByVal searchString As String) As DataView
            Return PSS.Data.Buisness.Search.GetPretestData(searchString).DefaultView
        End Function

        Public Shared Function GetQCData(ByVal searchString As String) As DataView
            Return PSS.Data.Buisness.Search.GetQCData(searchString).DefaultView
        End Function

        Private Shared Function GetSearchType(ByVal searchType As SearchTypes) As String
            Select Case searchType
                Case SearchTypes.CompanyName
                    Return "tcustomer.Cust_Name1"
                Case SearchTypes.CustoemerWO
                    Return "tworkorder.WO_CustWO"
                Case SearchTypes.CustomerLastName
                    Return "tcustomer.Cust_Name2"
                Case SearchTypes.PSSWO
                    Return "tdevice.WO_ID"
                Case SearchTypes.Serial
                    Return "tdevice.Device_SN"
                Case SearchTypes.Tray
                    Return "tdevice.Tray_ID"
                Case SearchTypes.ShipManifest
                    Return "tdevice.Ship_ID"
                Case SearchTypes.OldSerial
                    Return "tdevice.Device_OldSN"
                Case SearchTypes.IMEI
                    Return "tcellopt.Cellopt_OutIMEI"
                Case SearchTypes.Pallet
                    Return "tdevice.Pallett_ID"
                Case SearchTypes.DyscernDID
                    Return "tdyscerndata.dd_CustDeviceID"
                Case SearchTypes.SonitrolRMA
                    Return "tsonitroldata.sd_RMA"
                Case SearchTypes.PackingSlipNumber
                    Return "tpallett.pkslip_ID"
                Case Else
            End Select
        End Function

    End Class

End Namespace
