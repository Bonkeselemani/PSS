Option Explicit On 
Imports DBQuery.DataProc
Public Class ModelReceivingStatus
#Region "METHODS"

    Public Function SelectAllByProductID(ByVal ProductID As Int32) As DataTable
        ' RETURNS A DATATABLE OF RECORDS FROM THE TMODEL_REC_STATUS TABLE FOR A PRODUCT ID.
        Dim _dt As DataTable = New DataTable()
        Try
            Dim _dataProc As DBQuery.DataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            Dim _cmdText = "SELECT t.mrs_id, t.prod_id, t.model_id, t.inactive FROM tmodel_rec_status t WHERE t.prod_id = " & ProductID.ToString() & ";"
            _dt = _dataProc.GetDataTable(_cmdText)
            Return _dt
        Catch ex As Exception
            Throw New Exception("An error occurred while to retreive records from the table." & vbCrLf & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function GetRecordsNotInMRS(ByVal ProductID As Int32)
        ' RETURNS A DATATABLE OF MODELS THAT ARE NOT CURRENTLY IN THE TMODEL_REC_STATUS TABLE FOR A PRODUCT ID.
        Dim _dt As DataTable = New DataTable()
        Try
            Dim _dataProc As DBQuery.DataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            Dim _cmdText As String = "SELECT m.model_id, m.model_desc " & _
                "FROM TMODEL m " & _
                "LEFT JOIN tmodel_rec_status mrs on m.model_id = mrs.model_id " & _
                "WHERE m.PROD_ID = " & ProductID.ToString() & " " & _
                "AND mrs.model_id is null; "
            _dt = _dataProc.GetDataTable(_cmdText)
            Return _dt
        Catch ex As Exception
            Throw New Exception("An error occurred while attempting to find new models." & vbCrLf & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function SyncWithTModel(ByVal _dt As DataTable, ByVal prod_id As Int32) As DataTable
        ' INSERTS RECORDS TO SYNC THE TMODEL_REC_STATUS TABLE WITH TMODEL BASED ON THE PRODUCT ID.
        Dim _dr As DataRow
        Try
            For Each _dr In _dt.Rows
                InsertRecord(prod_id, _dr("model_id"), False)
            Next
        Catch EX As Exception
            Throw New Exception("An error occurred while attempting insert model_id " & _dr("model_id").ToString() & vbCrLf & vbCrLf & EX.Message)
        End Try
    End Function
    Public Sub UpdateRecord(ByVal id As Int32, ByVal inactive As Boolean)
        ' UPDATES THE INACTIVE FIELD OF TMODEL_REC_STATUS TABLE FOR THE ID.
        Try
            Dim _dataProc As DBQuery.DataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            Dim _cmdText = "update tmodel_rec_status set inactive  = " & IIf(inactive, 1, 0) & " WHERE mrs_id = " & id.ToString() & ";"
            _dataProc.ExecuteNonQuery(_cmdText)
        Catch ex As Exception
            Throw New Exception("An error occurred while attempting to update the record." & vbCrLf & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Sub InsertRecord(ByVal prod_id As Int32, ByVal model_id As Int32, ByVal inactive As Boolean)
        ' INSERTS A NEW RECORD INTO THE TMODEL_REC_STATUS TABLE.
        Try
            Dim _dataProc As DBQuery.DataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            Dim _cmdText = "insert into tmodel_rec_status (prod_id, model_id, inactive) " & _
                "Values(" & prod_id.ToString() & ", " & model_id.ToString() & ", " & IIf(inactive, 1, 0) & ");"
            _dataProc.ExecuteNonQuery(_cmdText)
        Catch ex As Exception
            Throw New Exception("An error occurred while attempting to insert a new record." & vbCrLf & vbCrLf & ex.Message)
        End Try
    End Sub

#End Region
End Class
