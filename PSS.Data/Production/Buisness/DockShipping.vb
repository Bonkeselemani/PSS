Option Explicit On 

Namespace Buisness

    Public Class DockShipping

        Private _objDataProc As DBQuery.DataProc

        '******************************************************************
        Public Sub New()
            Try
                Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '******************************************************************
        Public Function GetShipCarriers(ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Try
                strSql = "select SC_ID, SC_Desc, SCAC_Code, CustUsedCodes from lshipcarrier where SC_Active = 1 order by SC_Desc"
                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow = True Then dt.LoadDataRow(New Object() {"0", "-- Select --"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetSensusPackingList(ByVal iPackingListID As Integer) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "select * from tpackingslip where pkslip_ID = " & iPackingListID
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function UpdateDockShippingInfo(ByVal iCarrierID As Integer, _
                                               ByVal strTrackingNo As String, _
                                               ByVal strDockShipDate As String, _
                                               ByVal strPackingIDs As String, _
                                               ByVal iUsrID As Integer) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim strPackIDs As String = ""
            Dim R1 As DataRow
            Try
                strSql = "SELECT distinct pkslip_ID " & Environment.NewLine
                strSql &= "FROM tpackingslip  " & Environment.NewLine
                strSql &= "WHERE pkslip_ID in ( " & strPackingIDs & " ) " & Environment.NewLine
                strSql &= "AND (SC_ID is not null or SC_ID > 0);"
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    For Each R1 In dt.Rows
                        If strPackIDs.Trim.Length > 0 Then strPackIDs &= vbCrLf
                        strPackIDs &= R1("pkslip_ID")
                    Next R1

                    MsgBox("The following Packing # had been updated. " & Environment.NewLine & strPackIDs & Environment.NewLine & "Please remove them from the list.", MsgBoxStyle.Critical, "Information")
                    Exit Function
                Else
                    strSql = "UPDATE tpackingslip SET SC_ID = " & iCarrierID & Environment.NewLine
                    strSql &= ", pkslip_TrackNo = '" & strTrackingNo.Trim & "'" & Environment.NewLine
                    strSql &= ", pkslip_DockShipDate = '" & strDockShipDate.Trim & "'" & Environment.NewLine
                    strSql &= ", pkslip_DSUpdateUserID = " & iUsrID & Environment.NewLine
                    strSql &= ", pkSlip_DSUpdateDate = now() " & Environment.NewLine
                    strSql &= "WHERE pkslip_ID in ( " & strPackingIDs & " ) " & Environment.NewLine
                    Return Me._objDataProc.ExecuteNonQuery(strSql)
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************

    End Class
End Namespace
