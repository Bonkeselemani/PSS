Option Explicit On 

Imports DBQuery.DataProc
Imports System.Windows.Forms

Namespace Buisness

    Public Class PSSWarranty

        Private _objDataProc As DBQuery.DataProc

#Region "Constructor/Destructor"

        '*******************************************************************************************************************
        Public Sub New()
            Try
                Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*******************************************************************************************************************
        Protected Overrides Sub Finalize()
            Me._objDataProc = Nothing
            MyBase.Finalize()
        End Sub

        '*******************************************************************************************************************
#End Region

#Region "Customer Warranty"

        '*******************************************************************************************************************
        Public Function IsInWarranty(ByVal Serial As String, ByVal Cust_ID As Integer, ByVal Prod_ID As Integer, ByVal booDockShipDate As Boolean) As Integer

            Dim dt As DataTable
            Dim strSql As String = ""
            Dim shipdate As String
            Dim finishedgood, WrtDays As Integer


            Try
                strSql = "select t.Device_id,t.Device_SN,t.Device_FinishedGoods,t.Device_DateShip" & Environment.NewLine
                strSql += ", m.Model_ID,m.Model_Desc,p.Prod_ID,p.Prod_Desc" & Environment.NewLine
                strSql += ",l.Loc_ID,l.Loc_Name,l.Cust_ID" & Environment.NewLine
                If booDockShipDate = True Then
                    strSql += ",s.pkslip_createDt" & Environment.NewLine
                End If
                strSql += "from tdevice t" & Environment.NewLine
                strSql += "Left Join tmodel m on m.Model_ID=t.Model_ID" & Environment.NewLine
                strSql += "Left Join lproduct p on p.Prod_ID=m.Prod_ID" & Environment.NewLine
                strSql += "Left Join tlocation l on l.Loc_ID=t.Loc_ID" & Environment.NewLine
                If booDockShipDate = True Then
                    strSql += "Left Join tPallett r on r.Pallett_ID=t.Pallett_ID" & Environment.NewLine
                    strSql += "Left Join tpackingslip s on s.pkslip_ID=r.pkslip_ID" & Environment.NewLine
                End If
                strSql += "Where t.Device_SN='" & Serial & "'" & Environment.NewLine
                strSql += "And l.Cust_ID= " & Cust_ID & Environment.NewLine
                strSql += "And p.Prod_ID= " & Prod_ID & Environment.NewLine
                strSql += "order by t.device_id desc limit 1;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count < 1 Then
                    Return 0
                Else
                    finishedgood = CInt(dt.Rows(0)("Device_FinishedGoods"))

                    If finishedgood <> 1 Then
                        Return 0
                    Else

                        If booDockShipDate = True Then
                            shipdate = dt.Rows(0)("pkslip_createDt")
                            'shipdate = "2011-08-12 08:44:20" ****** For Test ********
                        Else
                            shipdate = dt.Rows(0)("Device_DateShip")
                        End If

                        WrtDays = GetWrtDays(Cust_ID, Prod_ID)
                        Dim ishipdays As Integer = DateDiff(DateInterval.Day, CDate(shipdate), Now())
                        If ishipdays > WrtDays Then
                            Return 0
                        Else
                            Return 1
                        End If

                    End If

                End If

            Catch ex As Exception
                Throw ex
            End Try

        End Function

        '*******************************************************************************************************************

        Public Function GetWrtDays(ByVal Cust_ID As Integer, ByVal Prod_ID As Integer) As Integer

            Dim strSql As String = ""

            Try
                strSql = "SELECT CustWrty_DaysinWrty as WrtDays FROM tcustwrty" & Environment.NewLine
                strSql += "Where Prod_ID=" & Prod_ID & Environment.NewLine
                strSql += "And Cust_ID=" & Cust_ID & Environment.NewLine
                Return Me._objDataProc.GetIntValue(strSql)

            Catch ex As Exception
                Throw ex
            End Try

        End Function

        '*******************************************************************************************************************

#End Region


    End Class

End Namespace
