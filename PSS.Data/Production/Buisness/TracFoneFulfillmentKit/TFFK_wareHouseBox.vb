Imports System
Imports System.Data
Imports System.Text
Imports MySql.Data
Namespace Buisness.TracFoneFulfillmentKit
    Public Class wareHouseBox

        Private _objDataProc As New mySQL5()

      

        Public Function getData(ByVal dat As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT A.BoxId,C.model_desc As 'Description',A.WHLocation,A.PickLocation,A.workstation As 'Status', B.LocationName As 'Mapped Loc'" & Environment.NewLine
                strSql &= " from edi.twarehousebox A inner join saleorders.tpicklocationmatrix B on A.model_id=B.model_id " & Environment.NewLine
                strSql &= " inner join production.tmodel_items C on c.model_id=A.model_id " & Environment.NewLine
                strSql &= " where A.BoxId >='" & dat & "-0001';"

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

    End Class
End Namespace

