
Option Explicit On 

Imports CrystalDecisions.CrystalReports.Engine
Imports DBQuery.DataProc
Imports System.Windows.Forms

Namespace Buisness.Jabil

    Public Module StaticData
#Region "Properties"
        '******************************************************************
        Public ReadOnly Property CUSTOMER_ID() As Integer
            Get
                Return 2462
            End Get
        End Property
        '******************************************************************
        Public ReadOnly Property LOC_ID() As Integer
            Get
                Return 3260
            End Get
        End Property
        '******************************************************************

        Public ReadOnly Property GROUPID() As Integer
            Get
                Return 93
            End Get
        End Property
        '******************************************************************
        Public ReadOnly Property PRODID() As Integer
            Get
                Return 2
            End Get
        End Property
        '******************************************************************
        Public ReadOnly Property SupportCCID() As Integer
            Get
                Return 69
            End Get
        End Property
        '******************************************************************
        Public ReadOnly Property PalletManifestDir() As String
            Get
                Return "P:\Dept\JABIL\Pallet packing list\"
            End Get
        End Property
        '******************************************************************
        Public ReadOnly Property ShipBoxLabelLocation() As String
            Get
                Return "P:\Dept\JABIL\Label\4x4GenericShipBoxLabel.rpt"
            End Get
        End Property
        '******************************************************************
#End Region
    End Module

    Public Class Receiving
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

        '*******************************************************************************************************************
        Public Function ReceiveUnit(ByVal iWOID As Integer, ByVal iTrayID As Integer, ByVal iModelID As Integer, ByVal iCCID As Integer, _
                                    ByVal strIMEI As String, ByVal strMechanicalSN As String, ByVal iUserID As Integer, ByVal iShiftID As Integer, _
                                    ByVal iPASN_ID As Integer, ByVal strRMANo As String, ByRef objRec As PSS.Data.Production.Receiving) As Integer
            Dim objUWrtyPantech As UnderWarrantyNET1.Pantech
            Dim objPantech As Pantech
            Dim objPSSWarty As Buisness.PSSWarranty
            Dim iDeviceID, iCnt, i, iWipOwner, iManufWrty, iPSSWrty As Integer
            Dim strWrkDate, strDateCode, strLastDateInWrty As String

            Try
                iDeviceID = 0 : iCnt = 0 : i = 0 : iWipOwner = 1
                strWrkDate = "" : strDateCode = ""
                strWrkDate = Generic.GetWorkDate(iShiftID)

                '*************************************************************
                'GET WARRANTY STATUS
                '*************************************************************
                If strMechanicalSN.StartsWith("8") OrElse strMechanicalSN.StartsWith("9") Then
                    'manufacture in 2008 or 2009
                    strDateCode = "0" & Microsoft.VisualBasic.Left(strMechanicalSN, 3)
                Else
                    'manufacture after 2009
                    strDateCode = Microsoft.VisualBasic.Left(strMechanicalSN, 4)
                End If
                objUWrtyPantech = New UnderWarrantyNET1.Pantech(strDateCode, False, "")
                iManufWrty = objUWrtyPantech.InWarranty()

                '*************************************************************
                'GET PSSWARRANTY STATUS
                '*************************************************************
                objPSSWarty = New PSSWarranty()
                iPSSWrty = objPSSWarty.IsInWarranty(strIMEI, Jabil.CUSTOMER_ID, Jabil.PRODID, True)
                'Create device
                iCnt = objRec.GetNextDeviceCountInTray(iTrayID) + 1
                iDeviceID = objRec.InsertIntoTdevice(strIMEI, strWrkDate, iCnt, iTrayID, Jabil.LOC_ID, iWOID, iModelID, iShiftID, iPSSWrty, iManufWrty, , iCCID, )
                If iDeviceID = 0 Then Throw New Exception("System has failed to insert into tdevice table.")

                'Create cellopt 
                If strMechanicalSN.Trim.Length = 0 Then strMechanicalSN = "NULL" 'DEFAULT VALUE
                i = objRec.InsertIntoTCellopt(iDeviceID, strMechanicalSN, strIMEI, , , , strIMEI, , , strDateCode, , , , , , , , , iWipOwner)
                If i = 0 Then Throw New Exception("System has failed to insert into tcellopt.")

                'Update/insert pantechasn table
                objPantech = New Pantech()
                i = objPantech.UpdateInsertPantechASNTable(iPASN_ID, strIMEI, strRMANo, iDeviceID)
                If i = 0 Then Throw New Exception("System has failed to update pantechasn table.")

                Return iManufWrty

            Catch ex As Exception
                Throw ex
            Finally
                objUWrtyPantech = Nothing : objPantech = Nothing
            End Try
        End Function

        '*******************************************************************************************************************

    End Class

End Namespace