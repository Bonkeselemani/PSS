Option Explicit On 

Namespace Buisness
    Public Class TMIReceiving
        Private _objDataProc As DBQuery.DataProc

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

        '***************************************************************************************************
        Public Function GetOpenRecWorkOrder(ByVal iLocID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT tworkorder.WO_ID, ClaimNo as 'Customer Work Order', Cust2PSSI_TrackNo as TrackNo, Type, Brand as 'Manufacture', Model" & Environment.NewLine
                strSql &= ", ShipTo_name as 'Name', Address1, City, State_Long as 'State', ZipCode, Tel, Email" & Environment.NewLine
                strSql &= ", tmodel.Model_ID" & Environment.NewLine
                strSql &= "FROM tworkorder " & Environment.NewLine
                strSql &= "INNER JOIN extendedwarranty On tworkorder.WO_ID = extendedwarranty.WO_ID" & Environment.NewLine
                strSql &= "INNER JOIN lstate On extendedwarranty.State_ID = lstate.State_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tmodel ON extendedwarranty.Model = tmodel.model_Desc" & Environment.NewLine
                strSql &= "WHERE Loc_ID = " & iLocID & " AND WO_Closed = 0 and InvalidOrder = 0 ;"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************************
        Public Function ReceiveDeviceIntoWIP(ByVal iWOID As Integer, ByVal iTrayID As Integer, ByVal iModelID As Integer, _
                                             ByVal strSN As String, ByVal iShiftID As Integer, ByVal iUserID As Integer, _
                                             ByVal strUserName As String, _
                                             ByVal iCCID As Integer, ByVal strWorkStation As String) As Integer
            Dim objRec As PSS.Data.Production.Receiving
            Dim iDeviceID, iCnt, i, iWipOwner, iManufWrty, iSNCnt As Integer
            Dim strWrkDate, strMechanicalSN, strPSSSN As String
            Dim objCreatePSSISNs As New CreatePSSISNs()

            Try
                'iDeviceID = 0 : iCnt = 0 : i = 0 : iWipOwner = 1 : iManufWrty = 0 : iSRC_ID = 0 : iSNCnt = 0
                ': strMechanicalSN = "" : strPSSSN = ""
                'strWrkDate = Generic.GetWorkDate(iShiftID)

                ''CREATE PSSI SERIAL
                'If objCreatePSSISNs.IsLocked() Then Throw New Exception("Table was lock by another user. Please try again.")
                'objCreatePSSISNs.Lock(strUserName)

                'strPSSSN = objCreatePSSISNs.GetMostRecentlyCreatedSN()
                'If strPSSSN = "N/A" Then strPSSSN = "P" & Convert.ToDateTime(strWrkDate).ToString("yyMMdd")
                'iSNCnt = objCreatePSSISNs.GetTodaysCreatedSNsCount() + 1
                'strPSSSN = strPSSSN & iSNCnt.ToString("000")
                'objCreatePSSISNs.SaveSN(strPSSSN, iUserID)

                ''iSRC_ID = Me.CreateSyxReceiveSn(iUserID, strPSSSN)
                ''If iSRC_ID = 0 Then Throw New Exception("System has failed to create serial number (ID = 0).")
                ''If strPSSSN.Trim.Length = 0 Then Throw New Exception("System has failed to create serial number (SN is blank).")

                'objRec = New PSS.Data.Production.Receiving()

                ''Create device
                'iCnt = objRec.GetNextDeviceCountInTray(iTrayID) + 1
                'iDeviceID = objRec.InsertIntoTdevice(iTrayID, strWrkDate, iCnt, iTrayID, TMI.LOCID, iWOID, iModelID, iShiftID, , iManufWrty, , iCCID, )
                'If iDeviceID = 0 Then Throw New Exception("System has failed to insert into tdevice table.")

                ''Create cellopt 
                'If strMechanicalSN.Trim.Length = 0 Then strMechanicalSN = "NULL" 'DEFAULT VALUE
                'i = objRec.InsertIntoTCellopt(iDeviceID, strMechanicalSN, , , , , , , , , , , , , , , strWorkStation, , iWipOwner)
                'If i = 0 Then Throw New Exception("System has failed to insert into tcellopt.")

                'Return iDeviceID

            Catch ex As Exception
                Throw ex
            Finally
                objRec = Nothing
            End Try
        End Function

        '***************************************************************************************************


    End Class
End Namespace