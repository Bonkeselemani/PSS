Option Explicit On 

Imports System
Imports System.Data
Imports System.Text
Imports MySql.Data
Imports System.IO

Namespace Buisness.CP
    Public Class CoolPad_SpecialProject

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


        Public Function GetDevicePretest(ByVal iDevice_ID As Integer) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT * FROM  tpretest_data A " & Environment.NewLine
                strSql &= "inner join tdevice B  on A.Device_ID = B.Device_ID " & vbCrLf
                strSql &= " WHERE A.Device_ID =" & iDevice_ID & " and B.device_DateShip is null;" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetDeviceAQLData(ByVal iDevice_ID As Integer) As DataTable
            Dim strSql As String = ""
            Try
                'FQA:   QCType_ID=2, Pass: QCResult_ID=1
                strSql = "SELECT * FROM tqc WHERE QCType_ID =4 AND Device_ID=" & iDevice_ID & " ORDER BY QC_Date DESC;"
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

    End Class
End Namespace