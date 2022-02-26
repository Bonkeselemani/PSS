Option Explicit On 

Imports System
Imports System.Data
Imports System.Text
Imports MySql.Data

Namespace Buisness.WIKO
    Public Class WIKO_GenericSoftwareConfig

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

        Public Function GetCustomerModels(ByVal iCust_ID As Integer, ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Try
                strSql = "Select  Model_ID, Model_Desc,Cust_Name1 from tmodel A INNER JOIN tCustomer B ON A.cust_ids=B.Cust_ID WHERE cust_ids=" & iCust_ID & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow Then dt.LoadDataRow(New Object() {0, "--Select--"}, True)
                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetSoftware_Versions(ByVal iCust_ID As Integer) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT SM_ID, DeviceName as 'Device Name', Carrier,ASN_SKU as SKU, SoftwareFileName as 'File Name',FlashApplication" & Environment.NewLine
                strSql &= ",IF(FileDate IS NULL,'', IF(DATE_FORMAT(FileDate,'%m/%d/%Y') ='00/00/0000','',DATE_FORMAT(FileDate,'%m/%d/%Y')))  AS 'File Date'," & Environment.NewLine
                strSql &= " Connector,BuilldID,SoftwareVersion as 'Software Version' " & Environment.NewLine
                strSql &= " From warehouse.tsoftwarematrix" & Environment.NewLine
                strSql &= " where cust_id= " & iCust_ID & "  " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function CheckIfVersionExists(ByVal strDevice_Name As String, _
                                           ByVal strCarrier As String, _
                                           ByVal strSKU As String, _
                                           ByVal strFileDate As String, _
                                           ByVal strSoftVersion As String, ByVal iCust_id As Integer _
                                          ) As DataTable
            Dim strSql As String
            Try
                strSql = "SELECT SM_ID " & Environment.NewLine
                strSql &= " From warehouse.tsoftwarematrix" & Environment.NewLine
                strSql &= " where cust_id= " & iCust_id & " and ASN_SKU=  '" & strSKU & "' and SoftwareVersion = '" & strSoftVersion & "' and  " & Environment.NewLine
                strSql &= "  DeviceName= '" & strDevice_Name & "' and Carrier=  '" & strCarrier & "'  " & Environment.NewLine
                strSql &= "  AND FileDate = '" & strFileDate & "'" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function Save(ByVal strDevice_Name As String, _
                                           ByVal strModel As String, _
                                           ByVal strCarrier As String, _
                                           ByVal strSKU As String, _
                                           ByVal strFileName As String, _
                                           ByVal strFlashApp As String, ByVal strFileDate As String, _
                                           ByVal strConnector As String, ByVal strBuilID As String, _
                                            ByVal strSoftVersion As String, ByVal iCust_id As Integer, _
                                           ByVal iUserID As Integer, ByVal strUpdateTime As String) As Integer
            Dim strSql As String = ""

            Try

                '******************************
                'Save new Software verion
                ''******************************
                strSql = "INSERT INTO warehouse.tsoftwarematrix ( " & Environment.NewLine
                strSql &= "DeviceName " & Environment.NewLine
                strSql &= ", PSS_Model " & Environment.NewLine
                strSql &= ", Carrier " & Environment.NewLine
                strSql &= ", ASN_SKU " & Environment.NewLine
                strSql &= ",SoftwareFileName " & Environment.NewLine
                strSql &= ", FlashApplication " & Environment.NewLine
                strSql &= ", FileDate " & Environment.NewLine
                strSql &= ", Connector " & Environment.NewLine
                strSql &= ", BuilldID  " & Environment.NewLine
                strSql &= ", SoftwareVersion  " & Environment.NewLine
                strSql &= ", Cust_ID  " & Environment.NewLine
                strSql &= ", UserID  " & Environment.NewLine
                strSql &= ", UpdatedDtime  " & Environment.NewLine
                strSql &= ") VALUES ( " & Environment.NewLine
                strSql &= "'" & strDevice_Name & "' " & Environment.NewLine
                strSql &= ", '" & strModel & "' " & Environment.NewLine
                strSql &= ", '" & strCarrier & "' " & Environment.NewLine
                strSql &= " , '" & strSKU & "' " & Environment.NewLine
                strSql &= ",'" & strFileName & "' " & Environment.NewLine
                strSql &= ", '" & strFlashApp & "' " & Environment.NewLine
                strSql &= ", '" & strFileDate & "' " & Environment.NewLine
                strSql &= " , '" & strConnector & "' " & Environment.NewLine
                strSql &= ", '" & strBuilID & "' " & Environment.NewLine
                strSql &= ", '" & strSoftVersion & "' " & Environment.NewLine
                strSql &= " ,  " & iCust_id & "  " & Environment.NewLine
                strSql &= ",  " & iUserID & "  " & Environment.NewLine
                strSql &= " , '" & strUpdateTime & "') " & Environment.NewLine
                Return Me._objDataProc.idTransaction(strSql, "tpallett")

            Catch ex As Exception
                Throw ex
            End Try
        End Function


        Public Function Update(ByVal iSM_ID As Integer, ByVal strDevice_Name As String, _
                                         ByVal strModel As String, _
                                         ByVal strCarrier As String, _
                                         ByVal strSKU As String, _
                                         ByVal strFileName As String, _
                                         ByVal strFlashApp As String, ByVal strFileDate As String, _
                                         ByVal strConnector As String, ByVal strBuilID As String, _
                                          ByVal strSoftVersion As String, ByVal iCust_id As Integer, _
                                         ByVal iUserID As Integer, ByVal strUpdateTime As String) As Integer
            Dim strSql As String = ""
            Try

                '******************************
                'Save new Software verion
                ''******************************
                strSql = "Update warehouse.tsoftwarematrix  set  " & Environment.NewLine
                strSql &= "DeviceName='" & strDevice_Name & "' " & Environment.NewLine
                strSql &= ", PSS_Model='" & strModel & "' " & Environment.NewLine
                strSql &= ", Carrier ='" & strCarrier & "' " & Environment.NewLine
                strSql &= ", ASN_SKU='" & strSKU & "' " & Environment.NewLine
                strSql &= ",SoftwareFileName='" & strFileName & "' " & Environment.NewLine
                strSql &= ", FlashApplication='" & strFlashApp & "' " & Environment.NewLine
                strSql &= ", FileDate='" & strFileDate & "' " & Environment.NewLine
                strSql &= ", Connector='" & strConnector & "'  " & Environment.NewLine
                strSql &= ", BuilldID='" & strBuilID & "'  " & Environment.NewLine
                strSql &= ", SoftwareVersion='" & strSoftVersion & "'  " & Environment.NewLine
                strSql &= ", UpdatedDtime='" & strUpdateTime & "'  " & Environment.NewLine
                strSql &= "  where SM_ID= " & iSM_ID & "  " & Environment.NewLine
                Return Me._objDataProc.idTransaction(strSql, "tpallett")

            Catch ex As Exception
                Throw ex
            End Try
        End Function


    End Class
End Namespace