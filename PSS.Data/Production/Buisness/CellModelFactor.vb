Imports System.Data.OleDb
Imports System.IO
Imports System.Xml
Imports PSS.Data

Namespace Buisness

    Public Class CellModelFactor

        Private ds As PSS.Data.Production.Joins
        Private dt, dtCall As DataTable

        Public _Group As Integer = 0
        Public _Manuf As Integer = 0
        Public _Model As Integer = 0
        Public _UnitsHour As Double = 0.0


        Public Function getDataTable(ByVal strSQL As String) As DataTable
            Try
                dt = ds.OrderEntrySelect(strSQL)
                Return dt
            Catch ex As Exception
            End Try
        End Function

        Public Function getMainGrid() As DataTable

            If _Group > 0 Then


                Dim strSQL As String = "SELECT tgroupmodelfactor.group_id, tgroupmodelfactor.model_id, lmanuf.manuf_desc as Manufacturer, tmodel.model_desc as Model, tgroupmodelfactor.gmf_unithour as UnitsPerHour FROM tgroupmodelfactor " & _
                "inner join lgroups on tgroupmodelfactor.group_id = lgroups.group_id " & _
                "inner join tmodel on tgroupmodelfactor.model_id = tmodel.model_id " & _
                "inner join lmanuf on tmodel.manuf_id = lmanuf.manuf_id " & _
                "WHERE tgroupmodelfactor.group_id = " & _Group

                dtCall = getDataTable(strSQL)
                Return dtCall
            End If
        End Function

        Public Function modifyTable() As Boolean
            Dim blnModify As Boolean
            If _Group > 0 And _Model > 0 And _UnitsHour > 0.0 Then
                dtCall = ds.OrderEntrySelect("SELECT * FROM tgroupmodelfactor WHERE group_id = " & _Group & " AND model_id = " & _Model)
                If dtCall.Rows.Count > 0 Then
                    '//Record should be updated
                    blnModify = updateRecord()
                    Return blnModify
                Else
                    '//Record should be inserted
                    blnModify = insertRecord()
                    Return blnModify
                End If
            End If
        End Function

        Public Function insertRecord() As Boolean
            Dim blnInsert As Boolean
            Dim strSQL As String
            If _Group > 0 And _Model > 0 And _UnitsHour > 0.0 Then
                Dim mFactor As Double = 1 / (_UnitsHour)
                strSQL = "INSERT INTO tgroupmodelfactor (group_id, model_id, gmf_unithour, gmf_factor) VALUES (" & _Group & ", " & _Model & ", " & _UnitsHour & ", " & mFactor & ")"
                blnInsert = ds.OrderEntryUpdateDelete(strSQL)
                Return blnInsert
            End If
        End Function

        Public Function updateRecord() As Boolean
            Dim blnInsert As Boolean
            Dim strSQL As String
            If _Group > 0 And _Model > 0 And _UnitsHour > 0.0 Then
                Dim mFactor As Double = 1 / (_UnitsHour)
                strSQL = "update tgroupmodelfactor set gmf_unithour = " & _UnitsHour & ", gmf_factor = " & mFactor & " where Group_ID = " & _Group & " and Model_ID = " & _Model
                blnInsert = ds.OrderEntryUpdateDelete(strSQL)
                Return blnInsert
            End If
        End Function


        Public Function deleteRecord() As Boolean
            Dim blnInsert As Boolean
            Dim strSQL As String
            If _Group > 0 And _Model > 0 And _UnitsHour > 0.0 Then
                strSQL = "DELETE FROM tgroupmodelfactor WHERE group_id = " & _Group & " AND model_id = " & _Model
                blnInsert = ds.OrderEntryUpdateDelete(strSQL)
                Return blnInsert
            End If
        End Function

        Public Function getManufacturer(ByVal mModel) As Integer
            dtCall = getDataTable("SELECT lmanuf.manuf_ID FROM tmodel INNER JOIN lmanuf ON tmodel.manuf_id = lmanuf.manuf_id WHERE tmodel.model_id = " & mModel)
            Dim r As DataRow = dtCall.Rows(0)
            Return r("Manuf_ID")
        End Function




        Public Property group()
            Get
                Return _Group
            End Get
            Set(ByVal Value)
                _Group = Value
            End Set
        End Property
        Public Property manuf()
            Get
                Return _Manuf
            End Get
            Set(ByVal Value)
                _Manuf = Value
            End Set
        End Property
        Public Property model()
            Get
                Return _Model
            End Get
            Set(ByVal Value)
                _Model = Value
            End Set
        End Property
        Public Property unitsHour()
            Get
                Return _UnitsHour
            End Get
            Set(ByVal Value)
                _UnitsHour = Value
            End Set
        End Property



    End Class

End Namespace
