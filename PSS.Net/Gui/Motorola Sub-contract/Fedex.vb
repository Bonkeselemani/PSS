Imports Microsoft.Data.Odbc
Namespace Gui.MotorolaSubcontract
    Public Class Fedex

        Private dsState, dsCountry As DataSet

        Public Function WriteFedEx(ByVal recShip As Long) As Integer

            writeFedEx = False
fedex:

            '//write data to fedex database
            'Dim fxCustName, fCustContact, fxAddress1, fxAddress2, fxCity, fxState As String
            'Dim fxZip, fxCountry, fxDateEntered, fxCustPhone As String
            'Dim strFedExSQL As String
            Dim xCount As Integer = 0
            Dim r As DataRow
            Dim valLoc As String
            Dim valContact As String

            Try
                Dim dtFedex As DataTable
                Dim strcon As String = "DRIVER={Microsoft Access Driver (*.mdb)};dbq=g:\fedextrack.mdb"
                'Dim strcon As String = "DRIVER={Microsoft Access Driver (*.mdb)};dbq=g:\fedextrackTest.mdb"
                Dim conn As New OdbcConnection(strcon)
                Dim valShipTo As Int32 = 0
                Dim valCust As Int32 = 0
                Dim dtship As New PSS.Data.Production.Joins()
                Dim dtrs As DataTable = dtship.OrderEntrySelect("SELECT * from tship where Ship_ID = " & recShip)

                For Each r In dtrs.Rows 'There will be only one row
                    If Not IsDBNull(r("ShipTo_ID")) Then
                        valShipTo = Trim(r("ShipTo_ID"))
                        Exit For
                    End If
                Next

                'For xCount = 0 To dtrs.Rows.Count
                '    r = dtrs.Rows(xCount)
                '    If IsDBNull(r("ShipTo_ID")) = True Then
                '        Exit For
                '    End If
                '    If Trim(r("ShipTo_ID")) > 0 Then
                '        valShipTo = Trim(r("ShipTo_ID"))
                '        Exit For
                '    End If
                'Next

                If valShipTo = 0 Then
                    Dim dtLoc As New PSS.Data.Production.Joins()
                    Dim dtLocRS As DataTable
                    'dtLocRS = dtLoc.OrderEntrySelect("SELECT * from tdevice where Ship_ID = " & recShip)
                    dtLocRS = dtLoc.OrderEntrySelect("SELECT * from tdevice where Ship_ID = " & recShip)
                    For xCount = 0 To dtLocRS.Rows.Count
                        r = dtLocRS.Rows(xCount)
                        If Trim(r("Loc_ID")) > 0 Then
                            valLoc = Trim(r("Loc_ID"))
                            'valCust = Trim(r("Cust_ID"))
                            Exit For
                        End If
                    Next
                End If

                Dim valCustName As String

                Dim tblCustomerList As New PSS.Data.Production.Joins()
                Dim dtCustomer As DataTable
                dtCustomer = tblCustomerList.Shipping_CustomerListEndUser

                'If valCust > 0 Then
                Dim drCustomer As DataRow
                For xCount = 0 To dtCustomer.Rows.Count - 1
                    drCustomer = dtCustomer.Rows(xCount)
                    If Trim(drCustomer("Loc_ID")) = valLoc Then
                        valCustName = Trim(drCustomer("Cust_Name1"))
                        If IsDBNull((drCustomer("Cust_Name2"))) = False Then
                            valCustName += " " & Trim(drCustomer("Cust_Name2"))
                        End If
                        Exit For
                    End If
                Next
                'End If


                Dim txtState, txtcountry, strFieldNames, strField As String
                Dim yCount As Integer = 0
                Dim x As DataRow

                '//Get data to be written
                If valShipTo > 0 Then
                    'dtrs = dtship.OrderEntrySelect("SELECT * from tshipto where(ShipTo_ID = " & recShip)       'July 15, 2003")
                    'dtrs = dtship.OrderEntrySelect("SELECT * from tshipto where(ShipTo_ID = " & valShipTo)     'Commented by Asif on 04/21/2004
                    dtrs = dtship.OrderEntrySelect("SELECT * from tshipto where ShipTo_ID = " & valShipTo)

                    For xCount = 0 To dtrs.Rows.Count - 1
                        r = dtrs.Rows(xCount)

                        valCustName = r("ShipTo_Name")
                        valContact = "'Null'"
                        dtrs = dtship.OrderEntrySelect("SELECT * from tlocation where Loc_ID = " & recShip)
                        For yCount = 0 To dtrs.Rows.Count - 1
                            x = dtrs.Rows(yCount)
                            valContact = "'" & x("Loc_Contact") & "'"
                        Next

                        '//Get State
                        txtState = Get_StateText(Trim(r("State_ID")))
                        '//Get Country
                        txtcountry = Get_CountryText(Trim(r("Cntry_ID")))
                        'If Trim(txtcountry) = "United States" Then
                        txtcountry = "US"
                        If Trim(txtcountry) = "USA" Then txtcountry = "US"
                        If Trim(txtcountry) = "Canada" Then txtcountry = "CN"

                        strFieldNames = "(Shipping_ID, Cust_Name, Cust_Address1, Cust_Address2, Cust_City, Cust_State_Prov, Cust_Zip, Cust_Country, Date_Entered, Cust_Contact)"
                        strField = "(" & recShip & ", '" & valCustName & "', '" & r("ShipTo_Address1") & "', '" & r("ShipTo_Address2") & "', '" & r("ShipTo_City") & "', '" & txtState & "', '" & r("ShipTo_Zip") & "', '" & txtcountry & "', '" & Now & "', " & valContact & ")"

                    Next
                End If
                If valLoc > 0 Then

                    dtrs = dtship.OrderEntrySelect("SELECT * from tlocation where Loc_ID = " & valLoc)
                    For xCount = 0 To dtrs.Rows.Count
                        r = dtrs.Rows(xCount)
                        '//Get State
                        txtState = Get_StateText(Trim(r("State_ID")))
                        '//Get Country
                        txtcountry = Get_CountryText(Trim(r("Cntry_ID")))

                        If Trim(txtcountry) = "United States" Then txtcountry = "US"
                        If Trim(txtcountry) = "Canada" Then txtcountry = "CN"
                        strFieldNames = "(Shipping_ID, Cust_Name, Cust_Address1, Cust_Address2, Cust_City, Cust_State_Prov, Cust_Zip, Cust_Country, Date_Entered, Cust_Contact, Cust_Phone)"
                        'Dim valContact As String
                        If IsDBNull(r("Loc_Contact")) = False Then
                            valContact = r("Loc_Contact")
                        Else
                            valContact = valCustName
                        End If
                        Dim valPhone As String
                        If IsDBNull(r("Loc_Phone")) = False Then
                            valPhone = r("Loc_Phone")
                        Else
                            valPhone = "none"
                        End If
                        strField = "(" & recShip & ", '" & valCustName & "', '" & r("Loc_Address1") & "', '" & r("Loc_Address2") & "', '" & r("Loc_City") & "', '" & txtState & "', '" & r("Loc_Zip") & "', '" & txtcountry & "', '" & Now & "', '" & valContact & "', '" & valPhone & "')"
                        Exit For
                    Next
                End If

                Dim cmd As New OdbcCommand("insert into Customer_Info " & strFieldNames & " VALUES " & strField, conn)
                conn.Open()
                cmd.ExecuteNonQuery()

                conn.Close()
                conn.Dispose()

                'dtFedex.Dispose()
                'dtrs.Dispose()

            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try
            '//end write to fedex database

        End Function

        Private Function Get_StateText(ByVal addState As String) As String

            Dim tblState As New PSS.Data.Production.lstate()
            dsState = tblState.GetData
            tblState = Nothing

            '//Get State Value
            Dim tmpCount As Integer = 0
            Dim rState As DataRow

            For tmpCount = 0 To dsState.Tables("lstate").Rows.Count - 1
                rState = dsState.Tables("lstate").Rows(tmpCount)
                If Trim(rState("State_ID")) = addState Then
                    Get_StateText = rState("State_Short")
                    Exit For
                End If
            Next

        End Function

        Private Function Get_CountryText(ByVal addCountry As String) As String

            Dim tblCountry As New PSS.Data.Production.lcountry()
            dsCountry = tblCountry.GetData
            tblCountry = Nothing

            '//Get Country Value
            Dim tmpCount As Integer = 0
            Dim rCountry As DataRow

            For tmpCount = 0 To dsCountry.Tables("lcountry").Rows.Count - 1
                rCountry = dsCountry.Tables("lcountry").Rows(tmpCount)
                If Trim(rCountry("Cntry_ID")) = addCountry Then
                    Get_CountryText = rCountry("Cntry_Name")
                    Exit For
                End If
            Next

        End Function

    End Class
End Namespace
