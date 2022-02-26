
Option Explicit On 

Namespace Buisness
    Public Class CellAdmin

        Private objMisc As Production.Misc

        '***************************************************************
        Public Sub New()
            objMisc = New Production.Misc()
        End Sub

        '***************************************************************
        Protected Overrides Sub Finalize()
            objMisc = Nothing
            MyBase.Finalize()
        End Sub

        '***************************************************************
        Private Function GetWorkorderInfo(ByVal strRecPalletName As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT * " & Environment.NewLine
                strSql &= "FROM tworkorder " & Environment.NewLine
                strSql &= "WHERE WO_RecPalletName = '" & strRecPalletName & "';"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.GetDataTable

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************
        Private Function GetWHPalletInfo(ByVal strRecPalletName As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT * " & Environment.NewLine
                strSql &= "FROM twarehousepallet " & Environment.NewLine
                strSql &= "WHERE WHPallet_Number = '" & strRecPalletName & "';"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.GetDataTable

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************
        Public Function ByPassQCByReWorkPallet(ByVal strRecPalletName As String) As Integer
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim iWO_ID As Integer = 0
            Dim i As Integer = 0

            Try
                dt1 = GetWorkorderInfo(strRecPalletName)

                If dt1.Rows.Count = 0 Then
                    Throw New Exception("Pallet does not exist in WIP.")
                Else
                    iWO_ID = dt1.Rows(0)("WO_ID")

                    If Not IsNothing(dt1) Then
                        dt1.Dispose()
                        dt1 = Nothing
                    End If

                    '***********************
                    'Get device information
                    '***********************
                    strSql = "SELECT * FROM tdevice WHERE WO_ID = " & iWO_ID
                    Me.objMisc._SQL = strSql
                    dt1 = Me.objMisc.GetDataTable

                    If dt1.Rows.Count = 0 Then
                        Throw New Exception("Pallet contains no device.")
                    Else
                        For Each R1 In dt1.Rows
                            '***********************
                            'Check if any of device has ship date
                            '***********************
                            If Not IsDBNull(R1("Device_DateShip")) Then
                                If R1("Device_DateShip") <> "0000-00-00 00:00:00" Then
                                    Throw New Exception("Pallet contains shipped devices that violate the rules of rework pallet. Cannot continue.")
                                End If
                            End If

                            '***********************
                            'Check if any of device has pallet assign to it
                            '***********************
                            If Not IsDBNull(R1("Pallett_ID")) Then
                                Throw New Exception("Some of the devices in this pallet have a ship pallet assigned to it. Cannot continue.")
                            End If
                        Next R1

                        'strSql = "UPDATE tdevice, tworkorder, tcellopt " & Environment.NewLine
                        'strSql &= "set Cellopt_WIPOwnerOld = Cellopt_WIPOwner " & Environment.NewLine
                        'strSql &= ", Cellopt_WIPEntryDt = now() " & Environment.NewLine
                        'strSql &= ", Cellopt_WIPOwner = tworkorder.Group_ID " & Environment.NewLine
                        'strSql &= ", tworkorder.WO_NoQC = 1 " & Environment.NewLine
                        'strSql &= "WHERE tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                        'strSql &= "AND tdevice.Device_ID = tcellopt.Device_ID " & Environment.NewLine
                        'strSql &= "AND tdevice.WO_ID = " & iWO_ID & ";"

                        strSql = "UPDATE tworkorder " & Environment.NewLine
                        strSql &= "SET tworkorder.WO_NoQC = 1 " & Environment.NewLine
                        strSql &= "WHERE WO_ID = " & iWO_ID & ";"
                        Me.objMisc._SQL = strSql
                        i = Me.objMisc.ExecuteNonQuery
                    End If
                End If

                Return i

            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '***************************************************************
        Public Function ReOpenWarehousepallet(ByVal strPalletName As String) As Integer
            Dim strSql As String = ""
            Dim dtWO, dtWHPallet As DataTable
            Dim R1 As DataRow
            Dim i As Integer = 0

            Try
                dtWO = Me.GetWorkorderInfo(strPalletName)

                For Each R1 In dtWO.Rows
                    If InStr(1, UCase(Trim(R1("WO_CustWO"))), "DNU") = 0 Then
                        Throw New Exception("Pallet has been received into the production. Cannot re-open.")
                    End If
                Next R1

                dtWHPallet = Me.GetWHPalletInfo(strPalletName)

                If dtWHPallet.Rows.Count = 0 Then
                    Throw New Exception("Pallet does not exist.")
                Else
                    If dtWHPallet.Rows(0)("WHP_PalletRcvd") = 1 Then
                        Throw New Exception("Pallet has been received into the production. Cannot re-open.")
                    Else
                        strSql = "UPDATE twarehousepallet " & Environment.NewLine
                        strSql &= "WHPalletClosed = 0 " & Environment.NewLine
                        strSql &= "WHERE WHPallet_Number = '" & strPalletName & "';"
                        Me.objMisc._SQL = strSql
                        i = Me.objMisc.ExecuteNonQuery
                    End If
                End If

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************

    End Class

End Namespace
