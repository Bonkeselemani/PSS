Option Explicit On 

Imports System
Imports System.Data
Imports System.Text
Imports MySql.Data
Imports System.IO
'Imports System.Runtime.InteropServices


Namespace Buisness.TracFoneFulfillmentKit
    Public Class TFFK
        Private _objDataProc As mySQL5
        Public _iWHBoxSegDigitCnt = 4
        Public Const _iWHRecvMaxQtyPerBox = 300 ' 60 '300
        Public Const _iWHRecvBoxLabelCopiesNumber = 4 ' 1 '4
        Public Const _strPickWorkstation As String = "In-Pick" 'after Transfer screen
        Public Const _strPackWorkstation As String = "In-Pack" 'after Print/Pick screen
        Public Const _strShipWorkstation As String = "In-Transit" 'After Pack (Shipped)

        Public Const _iMeiJerOrderWeightLimit As Integer = 300 ' 4 '300
        Public Const _iMeiJerOrderBoxQtyLimit As Integer = 20 '4 '20
        Public Const _iMeijerQtyPerBox As Integer = 3 '3
        Public Const _iMeijerRegularCarrierShipMethodID As Integer = 6 '6 Fedex Ground 
        Public Const _iMeijerBulkCarrierShipMethodID As Integer = 10 '10 Fedex Freight
        Public Const _iFredsBulkCarrierShipMethodID As Integer = 10 '10 Fedex Freight
        Public Const _iFrysRegularCarrierShipMethodID As Integer = 6  '6 Fedex Ground  '1 '1 UPS Ground
        Public Const _iOtherCustomerCarrierShipMethodID As Integer = 1 '1 UPS Ground
        Public Const _iSaiaCarrierLTLShipMethodID As Integer = 11 '11 Saia LTL Freight 

        Public Const _iPerGroupOrderNumberLimit As Integer = 20 '3 '20
        Public Const _iPerBoxItemNumber As Integer = 3

        Public Const _iBufferSaveDeviceNumber As Integer = 10 'How many rec to save temp 100
        Public Const _LogFilePath As String = "N:\PSSNET_Logs"

        Public Const _iSimQtyPerKittingPack As Integer = 3
        Public Const _iKittedPackQtyPerCarton As Integer = 5
        Public Const _iMaxCartonQtyPerPallet As Integer = 192 '(192x5 =960)
        Public Const _iKittingRequiredSN_KeyItem As Integer = 1

        Public Const _strBYOP_SP_PalletName_PreFix As String = "SP"
        Public Const _strBYOP_SP_MasterCartonName_PreFix As String = "MC"
        Public Const _strBYOP_SP_InnerCartonName_PreFix As String = "IC"

        'Public Const _strProcessType01 As String = "Standard Kitting"
        'Public Const _strProcessType02 As String = "Simple Packing"

        Public Enum ProcessTypeIDs As Integer
            Standard_Kitting = 1
            Simple_Packing = 2
        End Enum
        Public Enum StandardKittingLabels As Integer
            Pack_SKU_Label = 1
            Pack_UPC_A_Label = 2
            Carton_Label = 3
            Pallet_Label = 4
        End Enum
        Public Enum SimplePackingLabels As Integer
            Inner_Carton_Label = 5
            Master_Carton_Label = 6
            Pallet_Label = 7
        End Enum

#Region "Constructor/Destructor"

        '******************************************************************
        Public Sub New()
            Try
                Me._objDataProc = New mySQL5()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '******************************************************************
        Protected Overrides Sub Finalize()
            Me._objDataProc = Nothing
            MyBase.Finalize()
        End Sub

#End Region
#Region "Properties"
#Region "Meijer"
        Public Shared ReadOnly Property Meijer_CUSTOMER_ID() As Integer
            Get
                Return 2616
            End Get
        End Property
        '******************************************************************
        'Public Shared ReadOnly Property Meijer_LOC_ID() As Integer
        '    Get
        '        Return 19
        '    End Get
        'End Property
        '******************************************************************
        'Public Shared ReadOnly Property Meijer_MANIFEST_DIR() As String
        '    Get
        '        Return "P:\Dept\AMS\Pallet Packing List\"
        '    End Get
        'End Property
#End Region
#Region "Freds"
        Public Shared ReadOnly Property Freds_CUSTOMER_ID() As Integer
            Get
                Return 2615
            End Get
        End Property
        '******************************************************************
        'Public Shared ReadOnly Property Freds_LOC_ID() As Integer
        '    Get
        '        Return 19
        '    End Get
        'End Property
        ''******************************************************************
        'Public Shared ReadOnly Property Freds_MANIFEST_DIR() As String
        '    Get
        '        Return "P:\Dept\AMS\Pallet Packing List\"
        '    End Get
        'End Property
#End Region
#Region "Frys"
        Public Shared ReadOnly Property Frys_CUSTOMER_ID() As Integer
            Get
                Return 2617
            End Get
        End Property
        '******************************************************************
        'Public Shared ReadOnly Property Frys_LOC_ID() As Integer
        '    Get
        '        Return 19
        '    End Get
        'End Property
        ''******************************************************************
        'Public Shared ReadOnly Property Frys_MANIFEST_DIR() As String
        '    Get
        '        Return "P:\Dept\AMS\Pallet Packing List\"
        '    End Get
        'End Property
#End Region
#Region "FedEx"
        Public Shared ReadOnly Property FedEx_TransactionCode() As String
            Get
                Return "020"
            End Get
        End Property
        Public Shared ReadOnly Property FedEx_Company() As String
            Get
                Return "PSS Inc."
            End Get
        End Property
        Public Shared ReadOnly Property FedEx_PayType() As String
            Get
                Return "1"
            End Get
        End Property
        Public Shared ReadOnly Property FedEx_RecipientCountry() As String
            Get
                Return "US"
            End Get
        End Property
        Public Shared ReadOnly Property FedEx_RecipientCarriageValue() As String
            Get
                Return "100"
            End Get
        End Property
        Public Shared ReadOnly Property FedEx_WeightUnit() As String
            Get
                Return "LBS"
            End Get
        End Property
        Public Shared ReadOnly Property FedEx_SenderCountry() As String
            Get
                Return "US"
            End Get
        End Property
        Public Shared ReadOnly Property FedEx_LabelFormat() As String
            Get
                Return "288"
            End Get
        End Property
        Public Shared ReadOnly Property FedEx_ResidentialDeliveryFlag() As String
            Get
                Return "N"
            End Get
        End Property
        Public Shared ReadOnly Property FedEx_Printer() As String
            Get
                Return "\\PHQ-NAVSQL\Zebra Label 1"
            End Get
        End Property
        Public Shared ReadOnly Property FedEx_PackingType() As String
            Get
                Return "01"
            End Get
        End Property
#End Region
#Region "UPS"
        Public Shared ReadOnly Property PSSI_UPS_Account() As String
            Get
                Return "13F13V"
            End Get
        End Property
#End Region
#End Region
        Public Function getShipCarrierServiceType(ByVal iShipCarrier_ID As Integer) As String
            Dim strSql As String = ""
            Dim strRet As String = ""
            Dim dt As DataTable

            Try

                strSql = "SELECT * FROM saleorders.shipcarriers where ShipCarrier_ID=" & iShipCarrier_ID & ";"
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 AndAlso Not dt.Rows(0).IsNull("ServiceType") Then
                    strRet = Convert.ToString(dt.Rows(0).Item("ServiceType")).Trim
                End If

                Return strRet

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetWHBoxNexSeqNo(ByVal strBoxNamePreFix As String, ByVal iBoxSegDigitCnt As Integer) As Integer
            Dim strSql As String = ""
            Dim _sb As New StringBuilder()
            Dim iNextSeqNo As Integer
            Dim iNextSeqNo2 As Integer
            Dim dt As DataTable
            Dim dt2 As DataTable
            Dim _retVal As Integer
            Try
                ' GET THE MAX FROM THE TWAREHOUSEBOX TABLE.
                strSql = "SELECT max(right(BoxID, " & iBoxSegDigitCnt & " ) ) + 1 as NextSequenceNumber " & Environment.NewLine
                strSql &= "FROM edi.twarehousebox " & Environment.NewLine
                strSql &= "WHERE BoxID like '" & strBoxNamePreFix & "%' AND Length(BoxID) = " & (strBoxNamePreFix.Length + iBoxSegDigitCnt) & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 AndAlso Not IsDBNull(dt.Rows(0)("NextSequenceNumber")) Then
                    iNextSeqNo = CInt(dt.Rows(0)("NextSequenceNumber"))
                Else
                    iNextSeqNo = 1
                End If
                ' GET THE MAX FROM THE WH_BOX TABLE.
                _sb.Append("SELECT max(right(box_na, " & iBoxSegDigitCnt & " ) ) + 1 as NextSequenceNumber ")
                _sb.Append("FROM warehouse.wh_box ")
                _sb.Append("WHERE ")
                _sb.Append("box_na like '" & strBoxNamePreFix & "%' ")
                _sb.Append("AND ")
                _sb.Append("Length(box_na) = " & (strBoxNamePreFix.Length + iBoxSegDigitCnt) & " ")
                dt2 = Me._objDataProc.GetDataTable(_sb.ToString())
                If dt2.Rows.Count > 0 AndAlso Not IsDBNull(dt2.Rows(0)("NextSequenceNumber")) Then
                    iNextSeqNo2 = CInt(dt2.Rows(0)("NextSequenceNumber"))
                Else
                    iNextSeqNo2 = 1
                End If
                ' RETURN THE MAX NUMBER OF THE TWO TABLES.
                _retVal = IIf(iNextSeqNo > iNextSeqNo2, iNextSeqNo, iNextSeqNo2)
                Return _retVal
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        Public Function InsertEdiWarehouseBox(ByVal strBoxID As String, ByVal iFuncRep As Integer, ByVal iWrtyFlag As Integer _
          , ByVal iOrderID As Integer, ByVal iModelID As Integer, ByVal iWrtyExpedite As Integer, ByVal iQty As Integer, ByVal iClosed As Integer _
          , Optional ByVal strBoxStage As String = "", Optional ByVal strWorkStation As String = "", Optional ByVal strWhLocation As String = "") As Integer
            Dim strSql As String = ""

            Try
                strWhLocation = strWhLocation.Replace("'", "''")

                strSql = "INSERT INTO edi.twarehousebox ( BoxID, FuncRep, WarrantyFlag, Order_ID, Model_ID, WrtyExpedite, closed , Qty" & Environment.NewLine
                If strBoxStage.Trim.Length > 0 Then strSql &= ",BoxStage" & Environment.NewLine
                If strWorkStation.Trim.Length > 0 Then strSql &= ", WorkStation" & Environment.NewLine
                If strWhLocation.Trim.Length > 0 Then strSql &= ", WHLocation" & Environment.NewLine
                strSql &= ") VALUES ( " & Environment.NewLine
                strSql &= "'" & strBoxID & "'" & Environment.NewLine
                strSql &= ", " & iFuncRep & Environment.NewLine
                strSql &= ", " & iWrtyFlag & Environment.NewLine
                strSql &= ", " & iOrderID & Environment.NewLine
                strSql &= ", " & iModelID & Environment.NewLine
                strSql &= ", " & iWrtyExpedite & Environment.NewLine
                strSql &= ", " & iClosed & Environment.NewLine
                strSql &= ", " & iQty & Environment.NewLine
                If strBoxStage.Trim.Length > 0 Then strSql &= ", '" & strBoxStage & "'" & Environment.NewLine
                If strWorkStation.Trim.Length > 0 Then strSql &= ", '" & strWorkStation & "'" & Environment.NewLine
                If strWhLocation.Trim.Length > 0 Then strSql &= ", '" & strWhLocation & "'" & Environment.NewLine
                strSql &= "); " & Environment.NewLine

                Return Me._objDataProc.GetLastInsertedPrimaryKey(strSql, "edi.twarehousebox")

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetWarehouseReceiptBoxNexSeqNo(ByVal strBoxNamePreFix As String, ByVal iBoxSegDigitCnt As Integer) As Integer
            Dim strSql As String = ""
            Dim _sb As New StringBuilder()
            Dim iNextSeqNo As Integer
            Dim dt As DataTable
            Dim dt2 As DataTable

            Try
                ' GET THE MAX FROM THE TWAREHOUSEBOX TABLE.
                strSql = "SELECT max(right(WR_Name, " & iBoxSegDigitCnt & " ) ) + 1 as NextSequenceNumber " & Environment.NewLine
                strSql &= "FROM warehouse.warehouse_Receipt " & Environment.NewLine
                strSql &= "WHERE WR_Name like '" & strBoxNamePreFix & "%' AND Length(WR_Name) = " & (strBoxNamePreFix.Length + iBoxSegDigitCnt) & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 AndAlso Not IsDBNull(dt.Rows(0)("NextSequenceNumber")) Then
                    iNextSeqNo = CInt(dt.Rows(0)("NextSequenceNumber"))
                Else
                    iNextSeqNo = 1
                End If

                Return iNextSeqNo
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        'Public Function StrPtr(ByVal obj As Object) As Integer
        '    Dim Handle As GCHandle = GCHandle.Alloc(obj, GCHandleType.Pinned)
        '    Dim intReturn As Integer = Handle.AddrOfPinnedObject.ToInt32
        '    Handle.Free()
        '    Return intReturn
        'End Function

        Public Shared Function ComputeGroups(ByVal iTotalItemNumbers As Integer, ByVal iNumPerGroup As Integer) As Integer
            Dim iGroupNum As Integer = 0
            Dim iIntNum As Integer = 0
            Dim iModNum As Integer = 0
            Dim rowNew As DataRow
            Dim i As Integer = 0

            Try

                If iTotalItemNumbers = 0 Then Return 0
                If Not iNumPerGroup > 0 OrElse iNumPerGroup > iTotalItemNumbers Then Return iTotalItemNumbers

                iIntNum = iTotalItemNumbers \ iNumPerGroup
                iModNum = iTotalItemNumbers Mod iNumPerGroup
                If iIntNum = 0 AndAlso iModNum > 0 Then 'not 1 full group
                    iGroupNum = 1
                ElseIf iIntNum > 0 AndAlso iModNum = 0 Then '>1 full group
                    iGroupNum = iIntNum
                ElseIf iIntNum > 0 AndAlso iModNum > 0 Then '>full group plus a non-full group
                    iGroupNum = iIntNum + 1
                End If

                Return iGroupNum
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function CreateTextFile(ByVal strPathFile As String, ByVal strText As String, Optional ByRef strErrMsg As String = "")
            ' Dim path As String =  System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            'Dim FILE_NAME As String = path & "\mydebug.txt"
            Try
                If System.IO.File.Exists(strPathFile) = True Then
                    strErrMsg = "File already exists!"
                    Return False
                End If

                Dim objWriter As New System.IO.StreamWriter(strPathFile, True) 'Appen true
                objWriter.WriteLine(strText)
                objWriter.Close()

                strErrMsg = ""
                Return True
            Catch ex As Exception
                strErrMsg = ex.Message
                Return False
            End Try
        End Function

        Public Shared Function GetCheckSumDigit(ByVal code As String) As Integer
            Dim sum As Integer = 0
            Dim i As Integer = 0

            Try
                For i = 0 To code.Length - 1
                    Dim n As Integer = Integer.Parse(code.Substring(code.Length - 1 - i, 1))
                    If i Mod 2 = 0 Then
                        sum += n * 3
                    Else
                        sum += n
                    End If
                    ' sum += If(i Mod 2 = 0, n * 3, n)
                Next

                'Return If(sum Mod 10 = 0, 0, 10 - sum Mod 10)
                If sum Mod 10 = 0 Then
                    Return 0
                Else
                    Return 10 - sum Mod 10
                End If

            Catch ex As Exception
                Return 0
            End Try
        End Function


        Public Shared Function RemoveXtraSpaces(ByVal strVal As String, ByVal bUpcase As Boolean) As String
            Dim strRet As String = ""
            Try
                Do While InStr(1, strVal, "  ")
                    strVal = Replace(strVal, "  ", " ")
                Loop
                If bUpcase Then
                    strRet = StrConv(strVal, vbUpperCase)
                Else
                    strRet = strVal
                End If

                Return strRet

            Catch ex As Exception
                Return strRet
            End Try
        End Function

        Public Shared Function RemoveAllSpaces(ByVal strVal As String, ByVal bUpcase As Boolean) As String

            Dim strRet As String = ""
            Try
                Do While InStr(1, strVal, " ")
                    strVal = Replace(strVal, " ", "")
                Loop
                If bUpcase Then
                    strRet = StrConv(strVal, vbUpperCase)
                Else
                    strRet = strVal
                End If

                Return strRet

            Catch ex As Exception
                Return strRet
            End Try
        End Function
    End Class
End Namespace