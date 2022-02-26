Option Explicit On 

Namespace Buisness.Pantech
    Public Class Receiving
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
        Public Function GetOpenRMAsList(ByVal iCustID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT tworkorder.WO_ID, tworkorder.WO_CustWO as 'RMA #', tworkorder.WO_Quantity as 'WO Qty', tworkorder.WO_RAQnty as 'WO Received Qty'" & Environment.NewLine
                strSql &= ", tworkorder.PO_ID, tworkorder.Loc_ID, ShipTo_Name as 'Ship To Name', tshipto.ShipTo_Address1, tshipto.ShipTo_Address2" & Environment.NewLine
                strSql &= ", tshipto.ShipTo_City, tshipto.ShipTo_Zip, lstate.State_ID, lstate.State_Short, lcountry.Cntry_ID,  lcountry.Cntry_Name" & Environment.NewLine
                strSql &= ", tshipto.Tel, tshipto.Fax, tshipto.Email" & Environment.NewLine
                strSql &= "FROM tworkorder INNER JOIN tlocation ON tworkorder.Loc_ID = tlocation.Loc_ID" & Environment.NewLine
                strSql &= "INNER JOIN tshipto ON tworkorder.ShipTo_ID = tshipto.ShipTo_ID" & Environment.NewLine
                strSql &= "INNER JOIN lstate ON tshipto.State_Id = lstate.State_ID" & Environment.NewLine
                strSql &= "INNER JOIN lcountry ON lcountry.Cntry_ID = tshipto.Cntry_ID" & Environment.NewLine
                strSql &= "WHERE tlocation.Cust_ID = 2453 And tworkorder.WO_Closed = 0 " & Environment.NewLine
                strSql &= "ORDER BY 'RMA #' "
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function GetPantechModel(ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT tmodel.Model_ID, tmodel.Model_Desc FROM tmodel WHERE manuf_ID = 64 ORDER BY Model_Desc " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow = True Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '*******************************************************************************************************************

    End Class
End Namespace