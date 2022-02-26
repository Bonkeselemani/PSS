Option Explicit On 

Namespace Buisness.TracFone
    Public Class TFTestTriage
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

#Region "Properties"
        Public Shared ReadOnly Property Disp_ID_SOF() As Integer
            Get
                Return 2
            End Get
        End Property
        Public Shared ReadOnly Property Disp_ID_FUN() As Integer
            Get
                Return 3
            End Get
        End Property
        Public Shared ReadOnly Property Disp_ID_COS() As Integer
            Get
                Return 4
            End Get
        End Property
        Public Shared ReadOnly Property Disp_ID_NTF() As Integer
            Get
                Return 5
            End Get
        End Property
#End Region

#Region "Triage SQL"
        'EXAMPLE: ******************************************************************
        Public Function GetBilledPartsServicesBillcodeID(ByVal iDeviceID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT tdevicebill.Billcode_ID, BillCode_Rule " & Environment.NewLine
                strSql &= "FROM tdevicebill " & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes ON tdevicebill.Billcode_ID = lbillcodes.billcode_ID " & Environment.NewLine
                strSql += "WHERE tdevicebill.Device_ID = " & iDeviceID & " " & Environment.NewLine
                'strSql += "AND BillType_ID = 1 " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetTriageReadyBoxDeviceData(ByVal iLoc_ID As Integer, ByVal strBox As String) As DataTable
            Dim strSql As String = ""
            'FuncRep = 2 is X Model
            Try
                strSql = "SELECT A.Device_ID,A.Device_Sn,A.Device_DateRec,A.Loc_ID,A.WO_ID,C.WO_CustWO,A.Model_ID,E.Model_Desc" & Environment.NewLine
                strSql &= " ,B.VN_ItemNo,B.BoxID,B.wb_ID,D.FuncRep,B.Order_ID,B.OrderNo,D.Workstation,D.CellOpt_ID,B.Item_ID" & Environment.NewLine
                strSql &= " FROM tdevice A" & Environment.NewLine
                strSql &= " INNER JOIN edi.titem B ON A.Device_ID=B.Device_ID" & Environment.NewLine
                strSql &= " INNER JOIN tworkorder C ON A.WO_ID=C.WO_ID" & Environment.NewLine
                strSql &= " INNER JOIN edi.twarehousebox D ON B.wb_id=D.wb_ID" & Environment.NewLine
                strSql &= " INNER JOIN tcellopt D ON A.Device_ID=D.Device_ID" & Environment.NewLine
                strSql &= " INNER JOIN tmodel E ON A.Model_ID=E.Model_ID" & Environment.NewLine
                strSql &= " WHERE A.LOC_ID=" & iLoc_ID & " AND C.WO_Closed=1" & Environment.NewLine
                strSql &= " AND D.FuncRep=2 AND D.Workstation='Triage'" & Environment.NewLine
                strSql &= " AND B.BoxID='" & strBox.Replace("'", "''") & "';" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetModelDataForTriage(ByVal strXModel As String, ByVal iDisp_ID As Integer) As DataTable
            Dim strSql As String = ""
            Dim strModelDesc As String = ""
            Dim dt As DataTable

            Try

                Select Case iDisp_ID
                    Case 2, 3 'SOF, FUN
                        strXModel = strXModel.Trim.Substring(0, strXModel.Trim.Length - 1)
                        strModelDesc = strXModel.Trim & "_FUN"
                    Case 4 'COS
                        strModelDesc = strXModel.Trim.Substring(0, strXModel.Trim.Length - 1)
                    Case 5 'NTF
                        strModelDesc = strXModel.Trim
                End Select

                If strModelDesc.Length > 0 Then
                    strSql = "Select * from tmodel where model_desc = '" & strModelDesc & "';"
                    dt = Me._objDataProc.GetDataTable(strSql)
                End If

                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function InsertUpdateTriageData(ByVal iDevice_ID As Integer, _
                                               ByVal iDisp_ID As Integer, _
                                               ByVal iReceived_Model_ID As Integer, _
                                               ByVal iTriaged_Model_ID As Integer, _
                                               ByVal iWB_ID_Incoming As Integer, _
                                               ByVal iTriage_Completed As Integer, _
                                               ByVal iUserID As Integer, _
                                               ByVal strDateTime As String, _
                                               ByVal strWorkStation As String) As Integer
            Dim strSql As String = ""
            Dim strModelDesc As String = ""
            Dim dt As DataTable
            Dim i As Integer = 0

            Try
                strSql = "Select * from production.tdevice_triaged_data where Device_ID=" & iDevice_ID
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then 'update existing
                    strSql = "Update production.tdevice_triaged_data"
                    strSql &= " Set Disp_ID=" & iDisp_ID
                    strSql &= ", wb_ID_Incoming= " & iWB_ID_Incoming
                    strSql &= ", Received_Model_ID= " & iReceived_Model_ID
                    strSql &= ", Triaged_Model_ID= " & iTriaged_Model_ID
                    strSql &= ", Triage_Completed=" & iTriage_Completed
                    strSql &= ", Triage_DateTime= '" & strDateTime & "'"
                    strSql &= ", User_ID= " & iUserID
                    strSql &= " Where Device_ID=" & iDevice_ID
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                Else 'Insert new
                    strSql = "Insert Into  production.tdevice_triaged_data (Device_ID,Disp_ID,wb_ID_Incoming,Received_Model_ID,Triaged_Model_ID,Triage_Completed,Triage_DateTime,User_ID)"
                    strSql &= "Values (" & iDevice_ID
                    strSql &= "," & iDisp_ID
                    strSql &= "," & iWB_ID_Incoming
                    strSql &= "," & iReceived_Model_ID
                    strSql &= "," & iTriaged_Model_ID
                    strSql &= "," & iTriage_Completed
                    strSql &= ",'" & strDateTime & "'"
                    strSql &= "," & iUserID & ");"
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                End If

                strSql = "Update production.tdevice Set Model_ID=" & iTriaged_Model_ID & " Where Device_ID=" & iDevice_ID & ";"
                i += Me._objDataProc.ExecuteNonQuery(strSql)
                strSql = "Update production.tCellopt Set WorkStation='" & strWorkStation & "' Where Device_ID=" & iDevice_ID & ";"
                i += Me._objDataProc.ExecuteNonQuery(strSql)

                Return i

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function UpdateCompleteTriage(ByVal strDevice_IDs As String) As Integer
            Dim strSql As String = ""
            Try
                strSql = "Update production.tdevice_triaged_data Set Triage_Completed=1"
                strSql &= " Where Device_ID in (" & strDevice_IDs & ");"
                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
#End Region

    End Class
End Namespace