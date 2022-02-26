
Namespace Buisness
    Public Class Conn

        Public Const CUSTOMERID As Integer = 25180
        Public Const LOCID As Integer = 3318

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

#Region "Manage High Low Value"

        Public Function GetCONNSHighLowData() As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT ConHighLowVal.HL_ID,lProduct.Prod_Desc AS ProdType,lManuf.Manuf_Desc AS Manufacture,tModel.Model_Desc AS Model," & Environment.NewLine
                strSql &= "IF(ConHighLowVal.HighLow=0, 'Low','High') AS HighLow, ConHighLowVal.HighLow AS HighLowVal," & Environment.NewLine
                strSql &= "lProduct.Prod_ID,lManuf.Manuf_ID,tModel.Model_ID" & Environment.NewLine
                strSql &= " FROM ConHighLowVal" & Environment.NewLine
                strSql &= " INNER JOIN tModel ON ConHighLowVal.Model_ID=tModel.Model_ID" & Environment.NewLine
                strSql &= " INNER JOIN lManuf ON lManuf.Manuf_ID=tModel.Manuf_ID" & Environment.NewLine
                strSql &= " INNER JOIN lProduct ON lProduct.Prod_ID=tModel.Prod_ID" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function UpdateCONNSHighLowData(ByVal iHL_IDs As String, _
                                               ByVal iHL_Val As Integer, _
                                               ByVal iUserID As Integer) As Integer
            Dim strSql As String = ""

            Try
                If iHL_Val > 1 Then iHL_Val = 1
                If iHL_Val < 0 Then iHL_Val = 0

                strSql = "UPDATE ConHighLowVal" & Environment.NewLine
                strSql &= " SET HighLow = " & iHL_Val & Environment.NewLine
                strSql &= ", User_ID=" & iUserID & Environment.NewLine
                strSql &= ", LastUpdatedDT = now() " & Environment.NewLine
                strSql &= " WHERE HL_ID IN (" & iHL_IDs & ")" & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

#End Region

    End Class
End Namespace