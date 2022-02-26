Option Explicit On 

Imports System
Imports System.Data
Imports System.Text
Imports MySql.Data

Namespace Buisness.TracFoneFulfillmentKit
    Public Class TFFK_KittedReport
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


    End Class
End Namespace
