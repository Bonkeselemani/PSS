Option Explicit On 

Imports eInfoDesigns.dbProvider.MySqlClient

Namespace Buisness.WarrantyClaim
    Public Class MotoWarrantyData

        Private _objDataProc As DBQuery.DataProc
        Private strSql As String

#Region "Constructor/Destructor"

        '******************************************************************
        Public Sub New()
            Try
                Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '******************************************************************
        Protected Overrides Sub Finalize()
            Me._objDataProc = Nothing
            MyBase.Finalize()
        End Sub

        '******************************************************************
#End Region

#Region "Update Codes (Commented Code)"
        '************************************************************************************************************
        'Public Shared Function Deleteme_Select() As Boolean
        '    'Delete me

        '    Dim MyTable As DataTable
        '    Dim booVar As Boolean
        '    Dim R1 As DataRow

        '    '***********************
        '    'Airtime carrier codes
        '    '***********************
        '    'strSql = "Select Device_ID, CellOpt_AirCarrCode as Dcode_ID  "
        '    'strSql = strSql + "from tcellopt "
        '    'strSql = strSql + "where CellOpt_AirCarrCode Is Not null and CellOpt_AirCarrCode <> 0 "
        '    'strSql = strSql + "order by device_id"
        '    '***********************
        '    'Transaction codes
        '    '***********************
        '    'strSql = "Select Device_ID, CellOpt_transaction as Dcode_ID "
        '    'strSql = strSql + "from tcellopt "
        '    'strSql = strSql + "where CellOpt_transaction Is Not null and CellOpt_transaction <> 0 "
        '    'strSql = strSql + "order by device_id"
        '    '***********************
        '    'Customer Complaint Codes
        '    '***********************
        '    strSql = "Select Device_ID, cellopt_complaint as Dcode_ID  "
        '    strSql = strSql + "from tcellopt "
        '    strSql = strSql + "where cellopt_complaint Is Not null and cellopt_complaint <> 0 "
        '    strSql = strSql + "order by device_id"
        '    '***********************
        '    'APC Codes
        '    '***********************
        '    'strSql = "select tcellopt.Device_ID, tcellopt.CellOpt_APC, lcodesdetail.Dcode_sdesc, lcodesdetail.Dcode_ID "
        '    'strSql = strSql + "from tcellopt inner join lcodesdetail on tcellopt.cellopt_APC = lcodesdetail.Dcode_sdesc "
        '    'strSql = strSql + "where tcellopt.CellOpt_APC Is Not null and tcellopt.CellOpt_APC <> '' "
        '    'strSql = strSql + "order by tcellopt.Device_ID "

        '    Try
        '        'Return GetDataTable(strSql)
        '        MyTable = GetDataTable(strSql)
        '        For Each R1 In MyTable.Rows
        '            strSql = ""
        '            'strSql = "Replace into tdevicecodes (Device_ID, Dcode_ID) values (" & R1("Device_ID") & ", " & R1("cellopt_complaint") & ")"
        '            strSql = "Replace into tdevicecodes (Device_ID, Dcode_ID) values (" & R1("Device_ID") & ", " & R1("Dcode_ID") & ")"
        '            booVar = ExecuteNonQueries(strSql)
        '        Next
        '        Return True
        '    Catch Ex As Exception
        '        booVar = False
        '        Throw Ex
        '    Finally
        '        strSql = ""
        '    End Try

        'End Function
#End Region

        '************************************************************************************************************
        Public Function GetMotoWarrantyClaimInfo1(ByVal iDevice_ID As Integer) As DataTable

            '******************************************************************
            'Construct the SQL Query string here
            '******************************************************************
            strSql = "SELECT " + vbCrLf
            strSql = strSql + "tdevice.Device_ID, " + vbCrLf
            strSql = strSql + "tlocation.cust_ID, " + vbCrLf
            strSql = strSql + "'' AS AirtimeCarCode, " + vbCrLf
            strSql = strSql + "'' AS TransactionCode, " + vbCrLf
            strSql = strSql + "'' AS Product_APCcode, " + vbCrLf
            strSql = strSql + "IF(tcellopt.CellOpt_Transceiver IS NULL, '', TRIM(LEFT(tcellopt.CellOpt_Transceiver, 15))) AS TansceiverCode, " + vbCrLf
            strSql = strSql + "IF(tcellopt.CellOpt_MSN IS NULL, '', tcellopt.CellOpt_MSN) AS IncomingMSN, " + vbCrLf
            strSql = strSql + "IF(tcellopt.CellOpt_OutMSN IS NULL, '', tcellopt.CellOpt_OutMSN) AS OutgoingMSN, " + vbCrLf
            strSql = strSql + "IF(tcellopt.CellOpt_IMEI IS NULL, '', tcellopt.CellOpt_IMEI) AS IncomingIMEI, " + vbCrLf
            strSql = strSql + "IF(tcellopt.CellOpt_OutIMEI IS NULL, '', tcellopt.CellOpt_OutIMEI) AS OutgoingIMEI, " + vbCrLf
            'strSql = strSql + "IF(tcellopt.CellOpt_RepairStatus IS NULL, '', TRIM(LEFT(tcellopt.CellOpt_RepairStatus, 3))) AS RepairStatus, " + vbCrLf
            'strSql = strSql + "'SHP' AS RepairStatus, " + vbCrLf
            strSql = strSql + "IF(tdevice.Device_DateRec IS NULL, '', DATE_FORMAT(tdevice.Device_DateRec, '%M %d %Y %r')) AS DateReceived, " + vbCrLf
            'strSql = strSql + "'' AS TimeReceived, " + vbCrLf     'Added on 02/19/2004
            strSql = strSql + "IF(tdevice.Device_DateShip IS NULL, '', DATE_FORMAT(tdevice.Device_DateShip, '%M %d %Y %r')) AS DateShipped, " + vbCrLf
            'strSql = strSql + "'' AS TimeShipped, " + vbCrLf
            'strSql = strSql + "'' AS ReapairDate, " + vbCrLf
            strSql = strSql + "IF(tdevice.Device_DateBill IS NULL, '', DATE_FORMAT(tdevice.Device_DateBill, '%M %d %Y %r')) AS ReapairDate, " + vbCrLf
            'strSql = strSql + "'' AS RepairTime, " + vbCrLf
            'strSql = strSql + "'' AS RepairCycleTime, " + vbCrLf
            strSql = strSql + "'' AS POPWarrantyClaim, " + vbCrLf

            strSql = strSql + "IF(tcellopt.CellOpt_POP IS NULL, '', DATE_FORMAT(tcellopt.CellOpt_POP, '%M %d %Y %r')) AS DateofPurchase, " + vbCrLf
            'strSql = strSql + "IF(tcellopt.CellOpt_POP IS NULL, '', tcellopt.CellOpt_POP) AS DateofPurchase, " + vbCrLf

            strSql = strSql + "IF(tcellopt.CellOpt_CSN IS NULL, '', tcellopt.CellOpt_CSN) AS IncomingESNorCSN, " + vbCrLf
            strSql = strSql + "IF(tdevice.Device_SN IS NULL, '', tdevice.Device_SN) AS DeviceSerialNumber, " + vbCrLf
            strSql = strSql + "IF(tcellopt.CellOpt_OutCSN IS NULL, '', tcellopt.CellOpt_OutCSN) AS OutgoingESNorCSN, " + vbCrLf
            strSql = strSql + "IF(tcellopt.CellOpt_SoftVerIN IS NULL, '', tcellopt.CellOpt_SoftVerIN) AS SoftwareVersionIn, " + vbCrLf
            strSql = strSql + "IF(tcellopt.CellOpt_SoftVerOUT IS NULL, '', tcellopt.CellOpt_SoftVerOUT) AS SoftwareVersionOut, " + vbCrLf
            strSql = strSql + "'' AS CustomerComplaint, " + vbCrLf
            strSql = strSql + "IF(tcellopt.CellOpt_TechID IS NULL, '', tcellopt.CellOpt_TechID) AS TechnicianID, " + vbCrLf
            strSql = strSql + "'' AS PrimaryProbFoundCode, " + vbCrLf
            strSql = strSql + "'' AS PrimaryRepairAction, " + vbCrLf
            strSql = strSql + "IF(tcellopt.CellOpt_Airtime IS NULL, '', tcellopt.CellOpt_Airtime) AS Airtime " + vbCrLf

            strSql = strSql + "FROM " + vbCrLf
            strSql = strSql + "tdevice inner join tcellopt on tdevice.Device_ID = tcellopt.Device_ID " + vbCrLf
            strSql = strSql + "inner join tlocation on tdevice.loc_ID = tlocation.loc_ID " + vbCrLf

            strSql = strSql + "WHERE " + vbCrLf
            strSql = strSql + "tdevice.Device_ID = " & iDevice_ID
            strSql = strSql + "; "

            Try
                Return Me._objDataProc.GetDataTable(strSql)
            Catch Ex As Exception
                Throw Ex
            Finally
                strSql = ""
            End Try
        End Function

        '****************************************************************************
        'Gets the second part of the motorol warranty claim info
        '****************************************************************************
        Public Function GetMotoWarrantyClaimInfo2(ByVal iDevice_ID As Integer) As DataTable

            '******************************************************************
            'Construct the SQL Query string here
            '******************************************************************
            strSql = "SELECT Distinct" + vbCrLf
            strSql = strSql + "tdevicecodes.Device_ID, " + vbCrLf
            strSql = strSql + "tdevicecodes.Dcode_ID, " + vbCrLf
            strSql = strSql + "lcodesdetail.Dcode_Sdesc, " + vbCrLf
            strSql = strSql + "lcodesmaster.Mcode_Desc " + vbCrLf

            strSql = strSql + "FROM " + vbCrLf
            strSql = strSql + "(((((((lmanuf " + vbCrLf
            strSql = strSql + "inner join tmodel on lmanuf.Manuf_ID = tmodel.Manuf_ID) " + vbCrLf
            strSql = strSql + "inner join tdevice on tmodel.Model_ID = tdevice.Model_ID) " + vbCrLf
            strSql = strSql + "inner join tdevicecodes on tdevice.Device_ID = tdevicecodes.Device_ID) " + vbCrLf
            strSql = strSql + "inner join tworkorder on tdevice.WO_ID = tworkorder.WO_ID) " + vbCrLf
            strSql = strSql + "inner join lcodesdetail on tdevicecodes.Dcode_ID = lcodesdetail.Dcode_ID) " + vbCrLf
            strSql = strSql + "inner join lcodesmaster on lcodesdetail.Mcode_ID = lcodesmaster.Mcode_ID) " + vbCrLf
            strSql = strSql + "inner join tlocation on tworkorder.Loc_ID = tlocation.Loc_ID) " + vbCrLf

            strSql = strSql + "WHERE " + vbCrLf
            strSql = strSql + "tdevice.Device_ID = " & iDevice_ID & vbCrLf

            strSql = strSql + "ORDER BY lcodesdetail.Dcode_Sdesc; "

            Try
                Return Me._objDataProc.GetDataTable(strSql)
            Catch Ex As Exception
                Throw Ex
            Finally
                strSql = ""
            End Try
        End Function

        '****************************************************************************
        'Get the Component detail info 1
        '****************************************************************************
        Public Function GetMotoWarrantyClaimDetail1(ByVal iDevice_ID As Integer) As DataTable

            strSql = "SELECT DISTINCT " + vbCrLf
            strSql = strSql + "tdevice.Device_ID, " + vbCrLf
            strSql = strSql + "tdevicebill.dbill_id, " + vbCrLf
            strSql = strSql + "IF (lpsprice.PSPrice_Number IS NULL, '', UCase(TRIM(lpsprice.PSPrice_Number))) AS MotoPartNumber, " + vbCrLf
            strSql = strSql + "'' AS RefDesignator, " + vbCrLf
            strSql = strSql + "IF (tbillcell.BCell_RefDSNum IS NULL, '', tbillcell.BCell_RefDSNum) AS RefDesigNum, " + vbCrLf
            strSql = strSql + "'' AS PartFailureCode " + vbCrLf

            strSql = strSql + "FROM " + vbCrLf
            strSql = strSql + "((((((tdevice " + vbCrLf
            strSql = strSql + "INNER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID) " + vbCrLf
            strSql = strSql + "LEFT OUTER JOIN tbillcell ON tdevicebill.DBill_ID = tbillcell.DBill_ID) " + vbCrLf
            strSql = strSql + "INNER JOIN tpsmap ON tdevicebill.BillCode_ID = tpsmap.BillCode_ID AND tdevice.Model_ID = tpsmap.Model_ID) " + vbCrLf
            strSql = strSql + "INNER JOIN lpsprice ON tpsmap.PSPrice_ID = lpsprice.PSPrice_ID) " + vbCrLf
            strSql = strSql + "INNER JOIN lbillcodes on tdevicebill.BillCode_ID = lbillcodes.BillCode_ID) " + vbCrLf
            strSql = strSql + "INNER JOIN tpartscodes ON tdevicebill.DBill_ID = tpartscodes.DBill_ID) " + vbCrLf

            strSql = strSql + "WHERE " + vbCrLf
            strSql = strSql + "lbillcodes.BillType_ID = 2 and " + vbCrLf
            strSql = strSql + "tdevice.Device_ID = " & iDevice_ID & vbCrLf
            strSql = strSql + "ORDER BY tbillcell.dbill_id; "

            Try
                Return Me._objDataProc.GetDataTable(strSql)
            Catch Ex As Exception
                Throw Ex
            Finally
                strSql = ""
            End Try
        End Function

        '****************************************************************************
        'Gets the second part of the motorol warranty claim info
        '****************************************************************************
        Public Function GetMotoWarrantyClaimDetail2(ByVal iDevice_ID As Integer) As DataTable

            strSql = "SELECT " + vbCrLf
            strSql = strSql + "tdevicebill.Device_ID, " + vbCrLf
            strSql = strSql + "tpartscodes.dbill_id, " + vbCrLf
            strSql = strSql + "tpartscodes.tpartscode_id, " + vbCrLf
            strSql = strSql + "tpartscodes.Dcode_ID, " + vbCrLf
            strSql = strSql + "lcodesdetail.Dcode_Sdesc, " + vbCrLf
            strSql = strSql + "lcodesmaster.Mcode_Desc, " + vbCrLf
            strSql = strSql + "lcodesmaster.Mcode_ID " + vbCrLf

            strSql = strSql + "FROM " + vbCrLf
            strSql = strSql + "((((tdevicebill " + vbCrLf
            strSql = strSql + "INNER JOIN tpartscodes ON tdevicebill.DBill_ID = tpartscodes.DBill_ID) " + vbCrLf
            strSql = strSql + "INNER JOIN lcodesdetail ON tpartscodes.Dcode_ID = lcodesdetail.Dcode_ID) " + vbCrLf
            strSql = strSql + "INNER JOIN lcodesmaster ON lcodesdetail.MCode_ID = lcodesmaster.MCode_ID) " + vbCrLf
            strSql = strSql + "INNER JOIN lbillcodes on tdevicebill.BillCode_ID = lbillcodes.BillCode_ID) " + vbCrLf

            strSql = strSql + "WHERE " + vbCrLf
            strSql = strSql + "lbillcodes.BillType_ID = 2 and " + vbCrLf
            strSql = strSql + "tdevicebill.Device_ID = " & iDevice_ID & vbCrLf

            strSql = strSql + "ORDER BY tpartscodes.tpartscode_id; "

            Try
                Return Me._objDataProc.GetDataTable(strSql)
            Catch Ex As Exception
                Throw Ex
            Finally
                strSql = ""
            End Try
        End Function

        '***************************************************************************

    End Class
End Namespace
