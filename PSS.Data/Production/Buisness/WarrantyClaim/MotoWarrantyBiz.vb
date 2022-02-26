
Namespace Buisness.WarrantyClaim
    Public Class MotoWarrantyBiz

        Private Shared objMotoWarrantyData As MotoWarrantyData
        'Private Shared ObjUtilib As Utilib.Utility
        Private Shared ObjUtilib As MyLib.Utility
        Private Shared dtWarrantyData2 As DataTable
        Private Shared dtWarrantyData1 As DataTable

        Public Shared Function GetMotoWarrantyClaimInfo(ByVal iDevice_ID As Integer) As DataTable

            '****************************************************************************************************
            'Claim Information
            '******************************************************************
            Try
                'Part 1
                objMotoWarrantyData = New MotoWarrantyData()
                dtWarrantyData1 = objMotoWarrantyData.GetMotoWarrantyClaimInfo1(iDevice_ID)

                'Part 2
                dtWarrantyData2 = objMotoWarrantyData.GetMotoWarrantyClaimInfo2(iDevice_ID)
                Return ConsolidateClaimInfo(dtWarrantyData1, dtWarrantyData2)

            Catch ex As Exception

                Throw ex
            Finally
                If Not IsNothing(dtWarrantyData1) Then
                    dtWarrantyData1.Dispose()
                End If
                dtWarrantyData1 = Nothing

                If Not IsNothing(dtWarrantyData2) Then
                    dtWarrantyData2.Dispose()
                End If
                dtWarrantyData2 = Nothing

                objMotoWarrantyData = Nothing
            End Try

            '****************************************************************************************************

        End Function

        Public Shared Function GetMotoWarrantyClaimDetailInfo(ByVal iDevice_ID As Integer) As DataTable
            '****************************************************************************************************
            'Claim Detail
            '********************************************************************
            Dim R1 As DataRow
            Dim R2 As DataRow

            Try
                'Part 1
                objMotoWarrantyData = New MotoWarrantyData()
                dtWarrantyData1 = objMotoWarrantyData.GetMotoWarrantyClaimDetail1(iDevice_ID)
                dtWarrantyData2 = objMotoWarrantyData.GetMotoWarrantyClaimDetail2(iDevice_ID)

                For Each R1 In dtWarrantyData1.Rows

                    For Each R2 In dtWarrantyData2.Rows
                        If R1("dbill_id") = R2("dbill_id") Then
                            R1.BeginEdit()

                            Select Case CInt(R2("MCode_ID"))
                                Case 11     'Ref Desig Code
                                    If Not IsDBNull(R2("DCode_ID")) Then
                                        R1("RefDesignator") = R2("DCode_ID")
                                    End If

                                Case 4      'Failure Code
                                    If Not IsDBNull(R2("DCode_ID")) Then
                                        R1("PartFailureCode") = R2("DCode_ID")
                                    End If

                                Case Else
                                    '''

                            End Select

                            R1.EndEdit()
                        End If
                    Next R2

                Next R1

                Return dtWarrantyData1

            Catch ex As Exception

                If Not IsNothing(dtWarrantyData1) Then
                    dtWarrantyData1.Dispose()
                End If
                dtWarrantyData1 = Nothing

                Throw ex
            Finally

                If Not IsNothing(dtWarrantyData2) Then
                    dtWarrantyData2.Dispose()
                End If
                dtWarrantyData2 = Nothing

                objMotoWarrantyData = Nothing
            End Try

        End Function
        '****************************************************************************
        'This method consolidates the two data tables in to one final table to output
        '****************************************************************************
        Private Shared Function ConsolidateClaimInfo(ByVal T1 As DataTable, ByVal T2 As DataTable) As DataTable
            'AddHandler R1.ColumnChanged, New DataColumnChangeEventHandler(AddressOf OnColumnChanged)

            Dim R1 As DataRow
            Dim R2 As DataRow
            Dim iFlagCarrier As Integer = 0
            Dim iFlagTansaction As Integer = 0
            Dim iFlagAPC As Integer = 0
            Dim iFlagComplaint As Integer = 0
            Dim iFlagProblemFound As Integer = 0
            Dim iFlagRepair As Integer = 0

            Try
                ObjUtilib = New MyLib.Utility()
                For Each R1 In T1.Rows


                    R1.BeginEdit()

                    If Not IsDBNull(R1("DateofPurchase")) Then
                        If R1("DateofPurchase") <> "" Then
                            'R1("DateofPurchase") = ObjGeneral.FormatDate_DDMMYYYY(R1("DateofPurchase"))
                            R1("POPWarrantyClaim") = "Y"
                        Else
                            R1("POPWarrantyClaim") = "N"
                        End If
                    End If

                    '********************************************
                    For Each R2 In T2.Rows
                        'If R2("Device_ID") = R1("WarrantyClaim") Then
                        If R2("Device_ID") = R1("Device_ID") Then

                            Select Case Trim(R2("Mcode_Desc"))
                                Case "Carrier"
                                    If iFlagCarrier = 0 Then
                                        R1("AirtimeCarCode") = Left(R2("Dcode_Sdesc"), 6)
                                        iFlagCarrier = 1
                                    End If
                                Case "Transaction"
                                    If iFlagTansaction = 0 Then
                                        R1("TransactionCode") = Left(R2("Dcode_Sdesc"), 3)
                                        iFlagTansaction = 1
                                    End If
                                Case "APC"
                                    If iFlagAPC = 0 Then
                                        R1("Product_APCcode") = Left(R2("Dcode_Sdesc"), 4)
                                        iFlagAPC = 1
                                    End If
                                Case "Complaint"
                                    If iFlagComplaint = 0 Then
                                        R1("CustomerComplaint") = Left(R2("Dcode_Sdesc"), 8)
                                        iFlagComplaint = 1
                                    End If
                                Case "Problem Found"
                                    If iFlagProblemFound = 0 Then
                                        R1("PrimaryProbFoundCode") = Left(R2("Dcode_Sdesc"), 8)
                                        iFlagProblemFound = 1
                                    End If
                                Case "Repair"
                                    If iFlagRepair = 0 Then
                                        R1("PrimaryRepairAction") = Left(R2("Dcode_Sdesc"), 8)
                                        iFlagRepair = 1
                                    End If
                            End Select
                        End If
                    Next

                    R1.EndEdit()
                    iFlagCarrier = 0
                    iFlagTansaction = 0
                    iFlagAPC = 0
                    iFlagComplaint = 0
                    iFlagProblemFound = 0
                    iFlagRepair = 0

                Next

            Catch ex As Exception
                MsgBox(ex.Message)
                R1.CancelEdit()
                If Not IsNothing(T1) Then
                    T1.Dispose()
                End If
                T1 = Nothing
                Throw ex
            Finally
                If Not IsNothing(T2) Then
                    T2.Dispose()
                End If
                T2 = Nothing
            End Try

            Return T1

        End Function


    End Class
End Namespace
