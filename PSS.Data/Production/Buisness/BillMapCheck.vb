Option Explicit On 

Imports System.Data.OleDb
Imports System.IO

Namespace Buisness
    Public Class BillMapCheck
        Private objMisc As Production.Misc

        '***************************************************
        Public Sub New()
            objMisc = New Production.Misc()
        End Sub
        '***************************************************
        Protected Overrides Sub Finalize()
            objMisc = Nothing
            MyBase.Finalize()
        End Sub

        '***************************************************
        'Dispose dt
        '***************************************************
        Public Function DisposeDT(ByRef dt As DataTable)
            If Not IsNothing(dt) Then
                dt.Dispose()
                dt = Nothing
            End If
        End Function
        '***************************************************
        Private Sub NAR(ByVal o As Object)
            Try
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o)
            Catch
            Finally
                o = Nothing
            End Try
        End Sub

        '**************************************************************************
        


        '**************************************************************************
        Public Function AutoMapServices(ByVal iCust_id As Integer, _
                                        ByVal iModel_id As Integer) As Integer
            Dim strSql As String = ""
            Dim dt1, dt2, dt3 As DataTable
            Dim R1, R3 As DataRow
            Dim i As Integer = 0
            Dim strField As String = ""
            Dim strValues As String = ""

            Try
                strSql = "Select distinct lbillcodes.BillCode_ID from lbillcodes " & Environment.NewLine
                strSql &= "inner join tpsmap on lbillcodes.billcode_id = tpsmap.BillCode_ID " & Environment.NewLine
                strSql &= "where BillType_ID = 1 and model_id = " & iModel_id & " " & Environment.NewLine
                strSql &= "order by Billcode_id;"

                Me.objMisc._SQL = strSql
                dt1 = Me.objMisc.GetDataTable

                For Each R1 In dt1.Rows
                    'dispose dt2
                    If Not IsNothing(dt2) Then
                        dt2.Dispose()
                        dt2 = Nothing
                    End If
                    '************************************************************
                    'Step 1:: Check if billcode exist for this model and customer
                    '************************************************************
                    strSql = "Select * from tbillmap where billcode_id = " & R1("BillCode_ID") & " and cust_id = " & iCust_id & " and model_id = " & iModel_id & ";"
                    Me.objMisc._SQL = strSql
                    dt2 = Me.objMisc.GetDataTable

                    If dt2.Rows.Count > 0 Then
                        '************************
                        'Billcode exist then skip 
                        '************************
                    Else
                        '************************
                        'dispose dt3
                        '************************
                        If Not IsNothing(dt3) Then
                            dt3.Dispose()
                            dt3 = Nothing
                        End If

                        '********************************
                        'Get latest Billcode in tbillmap
                        '********************************
                        strSql = "Select * from tbillmap where billcode_id = " & R1("BillCode_ID") & " and BMap_Inactive = 0 order by bmap_id desc;"
                        Me.objMisc._SQL = strSql
                        dt3 = Me.objMisc.GetDataTable

                        If dt3.Rows.Count > 0 Then
                            R3 = dt3.Rows(0)
                            '********************************
                            'Create insert field and value string
                            '********************************
                            strField = ""
                            strValues = ""

                            If Not IsDBNull(R3("BMap_ProblemFound")) Then
                                If Len(Trim(R3("BMap_ProblemFound"))) > 0 Then
                                    strField &= "BMap_ProblemFound" & Environment.NewLine
                                    strValues &= R3("BMap_ProblemFound") & Environment.NewLine
                                End If
                            End If
                            If Not IsDBNull(R3("BMap_RepairAction")) Then
                                If Len(Trim(R3("BMap_RepairAction"))) > 0 Then
                                    strField &= ", BMap_RepairAction" & Environment.NewLine
                                    strValues &= ", " & R3("BMap_RepairAction") & Environment.NewLine
                                End If
                            End If
                            If Not IsDBNull(R3("BMap_RefDes")) Then
                                If Len(Trim(R3("BMap_RefDes"))) > 0 Then
                                    strField &= ", BMap_RefDes" & Environment.NewLine
                                    strValues &= ", " & R3("BMap_RefDes") & Environment.NewLine
                                End If
                            End If
                            If Not IsDBNull(R3("BMap_RefDesNumb")) Then
                                If Len(Trim(R3("BMap_RefDesNumb"))) > 0 Then
                                    strField &= ", BMap_RefDesNumb" & Environment.NewLine
                                    strValues &= ", " & R3("BMap_RefDesNumb") & Environment.NewLine
                                End If
                            End If
                            If Not IsDBNull(R3("BMap_Failure")) Then
                                If Len(Trim(R3("BMap_Failure"))) > 0 Then
                                    strField &= ", BMap_Failure" & Environment.NewLine
                                    strValues &= ", " & R3("BMap_Failure") & Environment.NewLine
                                End If
                            End If
                            If Not IsDBNull(R3("BMap_Transaction")) Then
                                If Len(Trim(R3("BMap_Transaction"))) > 0 Then
                                    strField &= ", BMap_Transaction" & Environment.NewLine
                                    strValues &= ", " & R3("BMap_Transaction") & Environment.NewLine
                                End If
                            End If
                            If Not IsDBNull(R3("BMap_Complaint")) Then
                                If Len(Trim(R3("BMap_Complaint"))) > 0 Then
                                    strField &= ", BMap_Complaint" & Environment.NewLine
                                    strValues &= ", " & R3("BMap_Complaint") & Environment.NewLine
                                End If

                            End If
                            If Not IsDBNull(R3("BMap_APC")) Then
                                If Len(Trim(R3("BMap_APC"))) > 0 Then
                                    strField &= ", BMap_APC" & Environment.NewLine
                                    strValues &= ", " & R3("BMap_APC") & Environment.NewLine
                                End If
                            End If
                            If Not IsDBNull(R3("BMap_AirtimeCarrier")) Then
                                If Len(Trim(R3("BMap_AirtimeCarrier"))) > 0 Then
                                    strField &= ", BMap_AirtimeCarrier" & Environment.NewLine
                                    strValues &= ", " & R3("BMap_AirtimeCarrier") & Environment.NewLine
                                End If
                            End If

                            strField &= ", Cust_Id" & Environment.NewLine
                            strValues &= ", " & iCust_id & Environment.NewLine

                            strField &= ", Model_ID" & Environment.NewLine
                            strValues &= ", " & iModel_id & Environment.NewLine

                            strField &= ", BillCode_ID" & Environment.NewLine
                            strValues &= ", " & R3("BillCode_ID") & Environment.NewLine

                            strField &= ", BMap_AutoMapFlag" & Environment.NewLine
                            strValues &= ", 1" & Environment.NewLine

                            '********************
                            'insert into database
                            '********************
                            strSql = "INSERT INTO tbillmap " & Environment.NewLine
                            strSql &= "(" & strField & ")" & Environment.NewLine
                            strSql &= "VALUES " & Environment.NewLine
                            strSql &= "(" & strValues & ")" & Environment.NewLine
                            strSql &= ";"

                            Me.objMisc._SQL = strSql
                            i = Me.objMisc.ExecuteNonQuery
                            '********************
                        End If
                    End If
                    '*****************************************
                Next R1

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                R3 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                If Not IsNothing(dt2) Then
                    dt2.Dispose()
                    dt2 = Nothing
                End If
                If Not IsNothing(dt3) Then
                    dt3.Dispose()
                    dt3 = Nothing
                End If
            End Try
        End Function

        '**************************************************************************
        Public Function DelAutoMapServices(ByVal iCust_id As Integer, _
                                        ByVal iModel_id As Integer) As Integer
            Dim strSql As String
            Dim i As Integer = 0

            Try
                strSql = "delete from tbillmap where cust_id = " & iCust_id & " and model_id = " & iModel_id & " and BMap_AutoMapFlag = 1;"
                Me.objMisc._SQL = strSql
                i = Me.objMisc.ExecuteNonQuery
                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************
        'Added by Lan on 08/13/07
        Public Function GetUnMapBillcodes(ByVal iCust_ID As Integer) As Integer
            Dim strSql As String
            Dim i As Integer = 0
            Dim dt1, dt2 As DataTable
            Dim R1, R2 As DataRow
            Dim booMatch As Boolean = False
            Dim drNewRow As DataRow

            Try
                strSql = "select distinct lbillcodes.BillCode_ID, lbillcodes.BillCode_Desc, tdevice.Model_ID, tmodel.Model_Desc  " & Environment.NewLine
                strSql &= "from tdevice, cstincomingdata, tcellopt " & Environment.NewLine
                strSql &= "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & Environment.NewLine
                strSql &= "inner join tmodel on tdevice.model_id = tmodel.model_id " & Environment.NewLine
                strSql &= "inner join tdevicebill on tdevice.device_id = tdevicebill.Device_ID " & Environment.NewLine
                strSql &= "inner join lbillcodes on tdevicebill.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
                strSql &= "left outer join tbillmap on tdevicebill.BillCode_ID = tbillmap.BillCode_ID " & Environment.NewLine
                strSql &= "and tbillmap.model_id = tdevice.model_id and tbillmap.Cust_Id = 2113 " & Environment.NewLine
                strSql &= "where tdevice.Device_ID = cstincomingdata.Device_ID and tdevice.Device_ID = tcellopt.Device_ID " & Environment.NewLine
                strSql &= "and BillCode_Rule not in (1,2) " & Environment.NewLine
                strSql &= "and lbillcodes.billcode_id not in (541,533,1010,1053,255) " & Environment.NewLine
                strSql &= "and tbillmap.BMap_ID is null " & Environment.NewLine
                strSql &= "and cstincomingdata.ClosedStatusSent = 0 " & Environment.NewLine
                strSql &= "and cstincomingdata.isSalvageFlg = 0 " & Environment.NewLine
                strSql &= "and Device_DateBill is not null " & Environment.NewLine
                strSql &= "and tlocation.cust_id = " & iCust_ID & Environment.NewLine
                strSql &= "and tmodel.prod_id = 2 " & Environment.NewLine
                strSql &= "order by Model_Desc;"
                Me.objMisc._SQL = strSql
                dt1 = Me.objMisc.GetDataTable

                strSql = "select distinct lbillcodes.BillCode_ID, lbillcodes.BillCode_Desc, tdevice.Model_ID, tmodel.Model_Desc  " & Environment.NewLine
                strSql &= "from tdevice, cstincomingdata, tcellopt " & Environment.NewLine
                strSql &= "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & Environment.NewLine
                strSql &= "inner join tmodel on tdevice.model_id = tmodel.model_id " & Environment.NewLine
                strSql &= "inner join tdevicebill_563 on tdevice.device_id = tdevicebill_563.Device_ID " & Environment.NewLine
                strSql &= "inner join lbillcodes on tdevicebill_563.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
                strSql &= "left outer join tbillmap on tdevicebill_563.BillCode_ID = tbillmap.BillCode_ID " & Environment.NewLine
                strSql &= "and tbillmap.model_id = tdevice.model_id and tbillmap.Cust_Id = 2113 " & Environment.NewLine
                strSql &= "where tdevice.Device_ID = cstincomingdata.Device_ID and tdevice.Device_ID = tcellopt.Device_ID " & Environment.NewLine
                strSql &= "and BillCode_Rule not in (1,2) " & Environment.NewLine
                strSql &= "and lbillcodes.billcode_id not in (541,533,1010,1053,255) " & Environment.NewLine
                strSql &= "and tbillmap.BMap_ID is null " & Environment.NewLine
                strSql &= "and cstincomingdata.ClosedStatusSent = 0 " & Environment.NewLine
                strSql &= "and cstincomingdata.isSalvageFlg = 0 " & Environment.NewLine
                strSql &= "and Device_DateBill is not null " & Environment.NewLine
                strSql &= "and tlocation.cust_id = " & iCust_ID & Environment.NewLine
                strSql &= "and tmodel.prod_id = 2 " & Environment.NewLine
                strSql &= "order by Model_Desc;"
                Me.objMisc._SQL = strSql
                dt2 = Me.objMisc.GetDataTable

                If dt2.Rows.Count > 0 Then
                    For Each R2 In dt2.Rows
                        For Each R1 In dt1.Rows
                            If R2("Model_ID") = R1("Model_ID") And R2("BillCode_ID") = R1("BillCode_ID") Then
                                booMatch = True
                                Exit For
                            End If
                        Next R1

                        If booMatch = False Then
                            drNewRow = dt1.NewRow
                            drNewRow("BillCode_ID") = R2("BillCode_ID")
                            drNewRow("Model_ID") = R2("Model_ID")
                            drNewRow("BillCode_Desc") = R2("BillCode_Desc")
                            drNewRow("Model_Desc") = R2("Model_Desc")
                            dt1.Rows.Add(drNewRow)
                            dt1.AcceptChanges()
                            drNewRow = Nothing
                        End If

                        booMatch = False

                    Next R2
                End If

                If dt1.Rows.Count > 0 Then
                    Generic.CreateExelReport(dt1, , , )
                End If

                Return dt1.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                R2 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                If Not IsNothing(dt2) Then
                    dt2.Dispose()
                    dt2 = Nothing
                End If
            End Try
        End Function

    End Class
End Namespace