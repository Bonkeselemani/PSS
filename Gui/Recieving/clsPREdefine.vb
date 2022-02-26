Imports PSS.Core
Imports PSS.Data

Namespace Gui.Receiving

    Public Class clsPREdefine
        Inherits System.Windows.Forms.Form

        Public Sub New()
            mRecType = 0
        End Sub

        Private mCustomer As Integer
        Private mRMA As String
        Private mQty As Integer
        Private mPRL As String
        Private mIP As String
        Private mSKU As String
        Private mManufacturer As Integer
        Private mModel As Integer
        Private mRecType As Integer

        'FORM STANDARD
        Private xCount As Integer
        Private r As DataRow

        Public Function PopulateCustomers() As DataTable

            Dim tblCustomer As New PSS.Data.Production.Joins()
            Dim dtCust As DataTable

            dtCust = tblCustomer.CustomerListPagerFirm("2")
            PopulateCustomers = dtCust

            System.GC.Collect()

            dtCust.Dispose()
            dtCust = Nothing
            tblCustomer = Nothing
        End Function

        Public Function PopulateManufacturers() As DataTable

            Dim tblManuf As New PSS.Data.Production.Joins()
            Dim dtManuf As DataTable

            'dtManuf = tblManuf.ManufListByDeviceType(2)
            dtManuf = tblManuf.OrderEntrySelect("select Distinct lmanuf.* from (lmanuf INNER JOIN tmodel ON lmanuf.manuf_id = tmodel.manuf_id)WHERE prod_id=2")
            PopulateManufacturers = dtManuf

            System.GC.Collect()

            dtManuf.Dispose()
            dtManuf = Nothing
            tblManuf = Nothing
        End Function

        Public Function PopulateModels() As DataTable

            If mManufacturer > 0 Then

                Dim tblJoins As New PSS.Data.Production.Joins()
                'Dim dtModels As DataTable = tblJoins.ModelListByManufAndDeviceType(2, mManufacturer)
                Dim tblModels As New PSS.Data.Production.Joins()
                Dim dtmodels As DataTable

                Dim strSql As String = "Select Distinct tmodel.model_id, tmodel.model_desc from tmodel, tpsmap, " & _
                "lmanuf where tmodel.model_id = tpsmap.model_id and tmodel.manuf_id = lmanuf.manuf_id " & _
                "and tpsmap.prod_id = 2 and lmanuf.manuf_id= " & mManufacturer & " Order By tmodel.model_desc"
                dtmodels = tblModels.OrderEntrySelect(strSql)

                PopulateModels = dtmodels

                System.GC.Collect()

                dtmodels.Dispose()
                dtmodels = Nothing
                tblJoins = Nothing

            End If
        End Function

        Public Function SaveData() As Boolean

            SaveData = False

            If mRecType = 0 Then '/Then new entry INSERT
                Dim insRec As Boolean = SaveRecord()
                If insRec = True Then SaveData = True
            ElseIf mRecType = 1 Then '/The loaded entry UPDATE

            End If
        End Function

        Public Function SaveRecord() As Boolean
            Try
                Dim strSQL As String = "INSERT into trmadef " & _
                "(RMA_Name, RMA_Qty, RMA_PRL, RMA_IP, RMA_SKU, Cust_ID, Manuf_ID, Model_ID) " & _
                "VALUES('" & mRMA & "', " & mQty & ", '" & _
                mPRL & "', '" & mIP & "', '" & mSKU & "', " & _
                mCustomer & ", " & mManufacturer & ", " & mModel & ")"
                PSS.Data.Production.Joins.OrderEntryUpdateDelete(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

#Region "Property Settings"

        Public Property Customer()
            Get
                Return mCustomer
            End Get
            Set(ByVal Value)
                If Len(Trim(Value)) > 0 Then
                    If IsNumeric(Value) = True Then
                        If CDbl(Value) = CInt(Value) Then
                            mCustomer = Value
                        Else
                            mCustomer = 0
                        End If
                    End If
                End If
            End Set
        End Property

        Public Property Manufacturer()
            Get
                Return mManufacturer
            End Get
            Set(ByVal Value)
                If Len(Trim(Value)) > 0 Then
                    If IsNumeric(Value) = True Then
                        If CDbl(Value) = CInt(Value) Then
                            mManufacturer = Value
                        Else
                            mManufacturer = 0
                        End If
                    End If
                End If
            End Set
        End Property

        Public Property Model()
            Get
                Return mModel
            End Get
            Set(ByVal Value)
                If Len(Trim(Value)) > 0 Then
                    If IsNumeric(Value) = True Then
                        If CDbl(Value) = CInt(Value) Then
                            mModel = Value
                        Else
                            mModel = 0
                        End If
                    End If
                End If
            End Set
        End Property

        Public Property RMA()
            Get
                Return mRMA
            End Get
            Set(ByVal Value)
                If Len(Trim(Value)) > 0 Then
                    mRMA = Value
                Else
                    mRMA = ""
                End If
            End Set
        End Property

        Public Property Qty()
            Get
                Return mQty
            End Get
            Set(ByVal Value)
                If Len(Trim(Value)) > 0 Then
                    mQty = Value
                Else
                    mQty = 0
                End If
            End Set
        End Property

        Public Property PRL()
            Get
                Return mPRL
            End Get
            Set(ByVal Value)
                If Len(Trim(Value)) > 0 Then
                    mPRL = Value
                Else
                    mPRL = ""
                End If
            End Set
        End Property

        Public Property IP()
            Get
                Return mIP
            End Get
            Set(ByVal Value)
                If Len(Trim(Value)) > 0 Then
                    mIP = Value
                Else
                    mIP = ""
                End If
            End Set
        End Property

        Public Property SKU()
            Get
                Return mSKU
            End Get
            Set(ByVal Value)
                If Len(Trim(Value)) > 0 Then
                    mSKU = Value
                Else
                    mSKU = ""
                End If
            End Set
        End Property


#End Region


    End Class
End Namespace
