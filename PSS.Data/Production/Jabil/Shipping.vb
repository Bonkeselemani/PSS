Option Explicit On 

Imports CrystalDecisions.CrystalReports.Engine

Namespace Buisness.Jabil
    Public Class Shipping
        Private _objDataProc As DBQuery.DataProc

#Region "Constructor/Destructor"

        '*******************************************************************************************************************
        Public Sub New()
            Try
                Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*******************************************************************************************************************
        Protected Overrides Sub Finalize()
            Me._objDataProc = Nothing
            MyBase.Finalize()
        End Sub

        '*******************************************************************************************************************
#End Region

        '*******************************************************************************************************************
        Public Function CreatePallet(ByVal iModelID As Integer, ByVal iPalletTypeID As Integer, ByVal iPallet_ShipType As Integer, _
                                     ByVal strPalletType_SDesc As String, ByRef objShip As Production.Shipping) As Integer
            Dim strSvrDate, strPalletName As String
            Dim iPalletID As Integer = 0

            Try
                strSvrDate = Format(CDate(Generic.MySQLServerDateTime()), "yyMMdd")
                strPalletName = "JB" & strSvrDate & strPalletType_SDesc

                '*********************************************
                'Get Pallet next sequence number
                '*********************************************
                strPalletName = objShip.GetPalletNameNextSeqNo(_objDataProc, Jabil.CUSTOMER_ID, Jabil.LOC_ID, strPalletName, 2)

                '*********************************************
                'Create Pallet
                '*********************************************
                Return objShip.CreatePallet(Jabil.CUSTOMER_ID, Jabil.LOC_ID, iModelID, 0, strPalletName, iPallet_ShipType, "", 0, 0, iPalletTypeID)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function GetOpenPallet(ByVal iLocID As Integer, ByVal iCustID As Integer) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT tpallett.* " & Environment.NewLine
                'strSql &= ", Model_Desc " & Environment.NewLine
                strSql &= ", Pallettype_SDesc, Pallettype_LDesc " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                'strSql &= "INNER JOIN tmodel ON tpallett.Model_ID = tmodel.Model_ID" & Environment.NewLine
                strSql &= "INNER JOIN lpallettype ON tpallett.PalletType_ID = lpallettype.PalletType_ID" & Environment.NewLine
                strSql &= "WHERE tpallett.Loc_ID = " & iLocID & " AND tpallett.Cust_ID = " & iCustID & Environment.NewLine
                strSql &= "AND Pallett_ReadyToShipFlg = 0 AND Pallett_ShipDate is null " & Environment.NewLine
                strSql &= "AND Pallet_Invalid = 0 " & Environment.NewLine
                strSql &= "ORDER BY Pallett_name" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        ''********************************************************************************
        'Public Function CreateManifest(ByVal iPalletID As Integer) As Integer
        '    Dim strSql, strPalletName As String
        '    Dim dt As DataTable
        '    Dim R1 As DataRow
        '    Dim strOutputData, strLine As String
        '    Dim i, j As Integer

        '    Try
        '        strSql = "SELECT 0 as 'Line #' " & Environment.NewLine
        '        strSql &= ", Pallett_Name as 'Pallet Name' " & Environment.NewLine
        '        strSql &= ", tmodel.Model_Desc as 'Model' " & Environment.NewLine
        '        strSql &= ", tdevice.Device_SN as 'IMEI' " & Environment.NewLine
        '        strSql &= ", if(CellOpt_MSN is null, '', CellOpt_MSN ) as 'SN' " & Environment.NewLine
        '        strSql &= ", Pallettype_LDesc as 'Result'" & Environment.NewLine
        '        strSql &= "FROM tdevice " & Environment.NewLine
        '        strSql &= "INNER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
        '        strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
        '        strSql &= "INNER JOIN tcellopt ON tdevice.Device_ID = tcellopt.Device_ID " & Environment.NewLine
        '        strSql &= "INNER JOIN lpallettype ON tpallett.PalletType_ID = lpallettype.PalletType_ID " & Environment.NewLine
        '        strSql &= "WHERE tdevice.Pallett_ID = " & iPalletID.ToString & " " & Environment.NewLine
        '        strSql &= "ORDER BY tdevice.Device_SN " & Environment.NewLine
        '        dt = Me._objDataProc.GetDataTable(strSql)

        '        'Create Line #
        '        i = 0
        '        For Each R1 In dt.Rows
        '            i += 1 : R1.BeginEdit() : R1("Line #") = i : R1.EndEdit() : R1.AcceptChanges()
        '        Next R1
        '        dt.AcceptChanges()

        '        If dt.Rows.Count > 0 Then
        '            strPalletName = dt.Rows(0)("Pallet Name")
        '            strOutputData = "" : strLine = ""

        '            'Write Header
        '            For i = 0 To dt.Columns.Count - 1
        '                If strLine.Trim.Length > 0 Then strLine &= ", "
        '                strLine &= dt.Columns(i).Caption
        '            Next i

        '            strOutputData &= strLine & vbCrLf

        '            'Write Data
        '            For i = 0 To dt.Rows.Count - 1
        '                strLine = ""
        '                For j = 0 To dt.Columns.Count - 1
        '                    If strLine.Trim.Length > 0 Then strLine &= ", "
        '                    strLine &= dt.Rows(i)(j)
        '                Next j
        '                strOutputData &= strLine & vbCrLf
        '            Next i

        '            If strOutputData <> "" Then
        '                If IO.File.Exists(Jabil.PalletManifestDir & strPalletName & ".csv") Then Kill(Jabil.PalletManifestDir & strPalletName & ".csv")
        '                PSS.Data.Production.Shipping.WriteDataToFile(Jabil.PalletManifestDir & strPalletName & ".csv", strOutputData)
        '            End If
        '        End If

        '        Return dt.Rows.Count
        '    Catch ex As Exception
        '        Throw ex
        '    Finally
        '        Generic.DisposeDT(dt)
        '        GC.Collect() : GC.WaitForPendingFinalizers()
        '    End Try
        'End Function

        '*******************************************************************************************************************
        Public Shared Function PrintHardDriveBoxLabel(ByVal iPalletID As Integer, _
                                                      ByVal strPalletTypeLDesc As String, _
                                                      ByVal iPrintCopies As Integer) As Integer
            Const strReportName As String = "C:\Label\HardDriveBoxLabel.rpt"
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc
            Dim dt As DataTable
            Dim objRpt As ReportDocument

            Try
                If iPrintCopies > 0 Then
                    objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                    strSql = "SELECT Pallett_Name as 'PalletName', Pallett_QTY as PalletQty, Model_Desc as 'ModelDesc'  " & Environment.NewLine
                    strSql &= ", '" & strPalletTypeLDesc & "' as 'PalletResult' " & Environment.NewLine
                    strSql &= "FROM tpallett INNER JOIN tmodel ON tpallett.Model_ID = tmodel.Model_ID" & Environment.NewLine
                    strSql &= "WHERE Pallett_ID = " & iPalletID & "" & Environment.NewLine
                    dt = objDataProc.GetDataTable(strSql)

                    '*****************************
                    '1: Print License Plate
                    '*****************************
                    If Not IsNothing(dt) Then
                        objRpt = New ReportDocument()

                        With objRpt
                            '.Load(PSS.Data.ConfigFile.GetBaseReportPath & strReportName)
                            .Load(strReportName)
                            .SetDataSource(dt)
                            .PrintToPrinter(iPrintCopies, True, 0, 0)
                        End With
                    End If
                End If
            Catch ex As Exception
                Throw ex
            Finally
                objRpt = Nothing
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '*******************************************************************************************************************

    End Class
End Namespace