Option Explicit On 
Imports System.IO

Namespace Buisness.TracFone
    Public Class BuildShipPallet

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
		'******************************************************************
		Public Shared ReadOnly Property WFM_CUSTOMER_ID() As Integer
			Get
				Return 2597
			End Get
		End Property
		'******************************************************************
		Public Shared ReadOnly Property TracFone_CUSTOMER_ID() As Integer
			Get
				Return 2258
			End Get
		End Property
		'******************************************************************
		Public Shared ReadOnly Property TracFone_LOC_ID() As Integer
			Get
				Return 2946
			End Get
		End Property
		'******************************************************************
		Public Shared ReadOnly Property TracFone_MANIFEST_DIR() As String
			Get
				Return "P:\Dept\TracFone\Pallet Packing List\"
			End Get
		End Property
		'******************************************************************
		Public Shared ReadOnly Property TracFone_GROUPID() As Integer
			Get
				Return 79
			End Get
		End Property
		'******************************************************************
		Public Shared ReadOnly Property TracFone_PRODID() As Integer
			Get
				Return 2
			End Get
		End Property
		'******************************************************************
#End Region

#Region "Build Ship Box & Ship Box"

		'******************************************************************
		Public Function GetModelsWithMotoSku(ByVal booAddSelectRow As Boolean) As DataTable
			Dim strSql, strModelDesc As String
			Dim dt, dtModelID As DataTable
			Dim R1 As DataRow

			Try
				strSql = "" : strModelDesc = ""

				strSql = "SELECT Distinct B.cust_model_number as 'Model_Desc', 0 as Model_ID, '' as Model_MotoSku  " & Environment.NewLine
				strSql &= "FROM tmodel A " & Environment.NewLine
				strSql &= "INNER JOIN production.tcustmodel_pssmodel_map B ON A.Model_ID = B.Model_ID  " & Environment.NewLine
				strSql &= "WHERE Prod_ID = 2  " & Environment.NewLine
				strSql &= "AND B.Cust_ID = " & Me.TracFone_CUSTOMER_ID & "  " & Environment.NewLine
				strSql &= "AND B.cust_MaterialCategory = 'PHONE' " & Environment.NewLine
				strSql &= "AND Model_MotoSku is not null  " & Environment.NewLine
				strSql &= "ORDER BY Model_Desc; " & Environment.NewLine
				dt = Me._objDataProc.GetDataTable(strSql)

				For Each R1 In dt.Rows
					If strModelDesc.Trim.Length > 0 Then strModelDesc &= ", "
					strModelDesc &= "'" & R1("Model_Desc") & "'"
				Next R1

				If strModelDesc.Trim.Length > 0 Then
					strSql = "SELECT Model_Desc, Model_ID, Model_MotoSku FROM tmodel WHERE Model_Desc IN (" & strModelDesc & ") AND Prod_ID = 2 ORDER BY Model_Desc "
					dtModelID = Me._objDataProc.GetDataTable(strSql)
					If booAddSelectRow Then dt.LoadDataRow(New Object() {"--Select--", 0, "--Select--"}, True)
				Else
					dtModelID = New DataTable()
				End If

				Return dtModelID
			Catch ex As Exception
				Throw ex
			Finally
				R1 = Nothing
				Generic.DisposeDT(dt)
			End Try
		End Function

		'******************************************************************
		Public Function GetTracFoneShipBoxTypes() As DataTable
			Dim strSql As String = ""
			Dim dt As DataTable
			Dim drNewRow As DataRow

			Try
				strSql = "SELECT 0 as 'ShipTypeID', 'REF' as 'ShipTypeSDesc', 'REFURBISHED' as 'ShipTypeLDesc' " & Environment.NewLine
				dt = Me._objDataProc.GetDataTable(strSql)
				drNewRow = dt.NewRow
				drNewRow("ShipTypeID") = 1
				drNewRow("ShipTypeSDesc") = "BER"
				drNewRow("ShipTypeLDesc") = "BER"
				dt.Rows.Add(drNewRow)

				drNewRow = Nothing
				drNewRow = dt.NewRow
				drNewRow("ShipTypeID") = 10
				drNewRow("ShipTypeSDesc") = "FRB"
				drNewRow("ShipTypeLDesc") = "Func Failure Return BrightStar"
				dt.Rows.Add(drNewRow)

				drNewRow = Nothing
				drNewRow = dt.NewRow
				drNewRow("ShipTypeID") = 11
				drNewRow("ShipTypeSDesc") = "FRC"
				drNewRow("ShipTypeLDesc") = "Func Failure Return Cooper"
				dt.Rows.Add(drNewRow)

				drNewRow = Nothing
				drNewRow = dt.NewRow
				drNewRow("ShipTypeID") = 12
				drNewRow("ShipTypeSDesc") = "FTR"
				drNewRow("ShipTypeLDesc") = "Forward To Repair"
				dt.Rows.Add(drNewRow)

				Return dt
			Catch ex As Exception
				Throw ex
			Finally
				drNewRow = Nothing
				Generic.DisposeDT(dt)
			End Try
		End Function

		'******************************************************************
		Public Function GetTFOpenPallets(ByVal iModelID As Integer) As DataTable
			Dim strSql As String

			Try
				strSql = "SELECT Pallett_ID, tpallett.Model_ID, Model_Desc, Loc_ID, Pallet_ShipType, Pallet_SkuLen, Pallett_QTY, Pallett_Name as 'Box Name' " & Environment.NewLine
				strSql &= ", If(Billcode_Desc is null , '', Billcode_Desc) as 'BER Reason'" & Environment.NewLine
				strSql &= "FROM tpallett " & Environment.NewLine
				strSql &= "INNER JOIN tmodel ON tpallett.Model_ID = tmodel.Model_ID " & Environment.NewLine
				strSql &= "LEFT OUTER JOIN lbillcodes ON tpallett.Pallet_SkuLen = lbillcodes.Billcode_ID AND billcode_rule = 1" & Environment.NewLine
				strSql &= "WHERE tpallett.cust_ID = " & PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID.ToString & Environment.NewLine
				strSql &= "AND Pallett_ReadyToShipFlg = 0 " & Environment.NewLine
				strSql &= "AND tpallett.Model_ID = " & iModelID.ToString & Environment.NewLine
				strSql &= "AND Pallet_Invalid = 0 " & Environment.NewLine
				strSql &= "Order by Pallett_id Desc"

				Return Me._objDataProc.GetDataTable(strSql)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'******************************************************************
		Public Function CreateBoxID(ByVal iModelID As Integer, _
									ByVal iBoxType As Integer, _
									ByVal strPalletPrefix As String) As Integer
			Dim strSql As String = ""
			Dim strDate As String = ""
			Dim strPalletName As String = ""
			Dim iPalletID As Integer = 0
			Dim iMaxNum As Integer = 0

			Try
				strDate = strDate.Replace(" ", "")
				'******************************
				'construct pallet name
				'******************************
				strDate = Generic.GetMySqlDateTime("%y%m%d")

				strPalletPrefix = strPalletPrefix + strDate & "N"

				strPalletName = Me.DefinePalletName(strPalletPrefix, iMaxNum)

				'check max number palletts
				If iMaxNum > 999 Then Throw New Exception("Max pallets (per model per box type per day) hit the 999 limit." & Environment.NewLine)

				'******************************
				'check for duplicate pallet
				'******************************
				strSql = "Select count(*) as cnt From tpallett where Pallett_Name = '" & strPalletName & "' and Loc_ID = " & Me.TracFone_LOC_ID
				If Me._objDataProc.GetIntValue(strSql) > 0 Then Throw New Exception("System is trying to create pallet (" & strPalletName & ") which is already existed in system.")

				'******************************
				'Create pallet
				''******************************
				strSql = "INSERT INTO tpallett ( " & Environment.NewLine
				strSql &= "Pallett_Name " & Environment.NewLine
				'strSql &= ", Pallet_SkuLen " & Environment.NewLine
				strSql &= ", Pallet_ShipType " & Environment.NewLine
				strSql &= ", Model_ID " & Environment.NewLine
				strSql &= ", Cust_ID  " & Environment.NewLine
				strSql &= ", Loc_ID  " & Environment.NewLine
				strSql &= ") VALUES (  " & Environment.NewLine
				strSql &= "'" & strPalletName & "' " & Environment.NewLine
				'strSql &= ", '" & iFreqID & "' " & Environment.NewLine
				strSql &= ", " & iBoxType & Environment.NewLine
				strSql &= ", " & iModelID & Environment.NewLine
				strSql &= ", " & Me.TracFone_CUSTOMER_ID & " " & Environment.NewLine
				strSql &= ", " & Me.TracFone_LOC_ID & ");" & Environment.NewLine
				iPalletID = Me._objDataProc.idTransaction(strSql, "tpallett")

				If iPalletID = 0 Then iPalletID = Me.GetTracFonePalletID(strPalletName)

				'******************************

				Return iPalletID
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'******************************************************************
        Private Function DefinePalletName(ByVal strPalletPrefix As String, Optional ByRef iMaxNum As Integer = 0, Optional ByVal iCust_ID As Integer = 0) As String
            Dim strSQL As String
            Dim dt, dt2 As DataTable
            Dim strPallett_Name As String = strPalletPrefix


            Try
                'strSQL = "SELECT max(right(Pallett_Name, 2) ) + 1 as Pallett_Num " & Environment.NewLine
                'strSQL &= "FROM tpallett " & Environment.NewLine
                'strSQL &= "WHERE Pallett_Name like '" & strPalletPrefix & "%' " & Environment.NewLine
                'strSQL &= "AND Cust_ID = " & Me.TracFone_CUSTOMER_ID & Environment.NewLine
                'strSQL &= "AND Loc_ID = " & Me.TracFone_LOC_ID & Environment.NewLine
                'dt = Me._objDataProc.GetDataTable(strSQL)
                'If dt.Rows.Count > 0 Then
                '    If Not IsDBNull(dt.Rows(0)("Pallett_Num")) Then
                '        strPallett_Name &= Format(dt.Rows(0)("Pallett_Num"), "00")
                '    Else
                '        strPallett_Name &= "01"
                '    End If
                'Else
                '    strPallett_Name &= "01"
                'End If

                'The above code only allow to create up to 100. 
                'Let's change to up to 999
                strSQL = "SELECT max(right(Pallett_Name, 2) ) + 1 as Pallett_Num " & Environment.NewLine
                strSQL &= "FROM tpallett " & Environment.NewLine
                strSQL &= "WHERE Pallett_Name like '" & strPalletPrefix & "%' " & Environment.NewLine
                If iCust_ID = PSS.Data.Buisness.WFM.CUSTOMER_ID Then
                    strSQL &= "AND Cust_ID = " & iCust_ID & Environment.NewLine
                    strSQL &= "AND Loc_ID = " & PSS.Data.Buisness.WFM.LOC_ID & Environment.NewLine
                Else
                    strSQL &= "AND Cust_ID = " & Me.TracFone_CUSTOMER_ID & Environment.NewLine
                    strSQL &= "AND Loc_ID = " & Me.TracFone_LOC_ID & Environment.NewLine
                End If
                'strSQL &= "AND Cust_ID = " & Me.TracFone_CUSTOMER_ID & Environment.NewLine
                'strSQL &= "AND Loc_ID = " & Me.TracFone_LOC_ID & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSQL)
                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows(0)("Pallett_Num")) Then
                        If dt.Rows(0)("Pallett_Num") >= 100 Then
                            strSQL = "SELECT max(CONVERT(replace(right(Pallett_Name, 3),'N','') , SIGNED INTEGER)+1)  as Pallett_Num " & Environment.NewLine
                            strSQL &= "FROM tpallett " & Environment.NewLine
                            strSQL &= "WHERE Pallett_Name like '" & strPalletPrefix & "%' " & Environment.NewLine
                            If iCust_ID = PSS.Data.Buisness.WFM.CUSTOMER_ID Then
                                strSQL &= "AND Cust_ID = " & iCust_ID & Environment.NewLine
                                strSQL &= "AND Loc_ID = " & PSS.Data.Buisness.WFM.LOC_ID & Environment.NewLine
                            Else
                                strSQL &= "AND Cust_ID = " & Me.TracFone_CUSTOMER_ID & Environment.NewLine
                                strSQL &= "AND Loc_ID = " & Me.TracFone_LOC_ID & Environment.NewLine
                            End If
                            'strSQL &= "AND Cust_ID = " & Me.TracFone_CUSTOMER_ID & Environment.NewLine
                            'strSQL &= "AND Loc_ID = " & Me.TracFone_LOC_ID & Environment.NewLine
                            dt2 = Me._objDataProc.GetDataTable(strSQL)
                            strPallett_Name &= dt2.Rows(0)("Pallett_Num")
                            iMaxNum = dt2.Rows(0)("Pallett_Num")
                        Else
                            strPallett_Name &= Format(dt.Rows(0)("Pallett_Num"), "00")
                            iMaxNum = Format(dt.Rows(0)("Pallett_Num"), "00")
                        End If
                    Else
                        strPallett_Name &= "01"
                        iMaxNum = 1
                    End If
                Else
                    strPallett_Name &= "01"
                    iMaxNum = 1
                End If

                Return strPallett_Name
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetTracFonePalletID(ByVal strPalletName As String) As Integer
            Dim strSQL As String
            Dim dt As DataTable
            Dim iPalletID As Integer = 0

            Try
                strSQL = "SELECT Pallett_ID " & Environment.NewLine
                strSQL &= "FROM tpallett " & Environment.NewLine
                strSQL &= "WHERE Pallett_Name = '" & strPalletName & "' " & Environment.NewLine
                strSQL &= "AND Cust_ID = " & Me.TracFone_CUSTOMER_ID & Environment.NewLine
                strSQL &= "AND Loc_ID = " & Me.TracFone_LOC_ID & Environment.NewLine
                strSQL &= "AND Pallet_Invalid = 0 " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSQL)
                If dt.Rows.Count > 1 Then
                    Throw New Exception("Duplicate Box """ & strPalletName & """. Please contact IT.")
                ElseIf dt.Rows.Count = 0 Then
                    Throw New Exception("Box ID is missing for box  """ & strPalletName & """. Please contact IT.")
                Else
                    iPalletID = dt.Rows(0)("Pallett_ID")
                End If

                Return iPalletID
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function IsOpenBoxExisted(ByVal iModelID As Integer, _
                 ByVal iBoxType As Integer, _
                 ByVal iMchCCGrpID As Integer) As Boolean
            Dim strSQL As String
            Dim dt As DataTable

            Try
                strSQL = "SELECT * " & Environment.NewLine
                strSQL &= "FROM tpallett " & Environment.NewLine
                strSQL &= "WHERE Cust_ID = " & Me.TracFone_CUSTOMER_ID & Environment.NewLine
                strSQL &= "AND Loc_ID = " & Me.TracFone_LOC_ID & Environment.NewLine
                strSQL &= "AND Pallett_ReadyToShipFlg = 0 " & Environment.NewLine
                strSQL &= "AND Pallett_Name like '" & iMchCCGrpID & "%' " & Environment.NewLine
                strSQL &= "AND Pallet_ShipType  = " & iBoxType & Environment.NewLine
                strSQL &= "AND Model_ID = " & iModelID & Environment.NewLine
                strSQL &= "AND Pallet_Invalid = 0 " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSQL)
                If dt.Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        ''******************************************************************
        Public Function GetDeviceInfoInWIP(ByVal strSN As String, _
                   ByVal iLocID As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim booPalletClosed As Boolean = False

            Try
                strSql = "SELECT tdevice.*, cust_model_number as Model_Desc" & Environment.NewLine
                strSql &= ", if(WorkStation is null, '', WorkStation) as WorkStation " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strSql &= "INNER JOIN tcustmodel_pssmodel_map ON tdevice.Model_ID = tcustmodel_pssmodel_map.Model_ID AND tlocation.Cust_ID = tcustmodel_pssmodel_map.Cust_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tcellopt ON tdevice.Device_ID = tcellopt.Device_ID " & Environment.NewLine
                strSql &= "WHERE Device_SN = '" & strSN & "' " & Environment.NewLine
                strSql &= "AND (Device_DateShip is null OR Device_DateShip = '0000-00-00 00:00:00' or Device_DateShip  = '') " & Environment.NewLine
                strSql &= "AND tdevice.Loc_ID = " & iLocID & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        ''******************************************************************
        Public Function CheckDeviceShipType(ByVal iPallet_ShipType As Integer, _
                 ByVal iDeviceID As Integer, _
                 ByRef booFailDeviceHasPart As Boolean) As Boolean
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                CheckDeviceShipType = False

                strSql = "SELECT DISTINCT BillCode_Rule " & Environment.NewLine
                strSql &= "FROM tdevicebill " & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes ON tdevicebill.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
                strSql &= "WHERE tdevicebill.Device_ID = " & iDeviceID & Environment.NewLine
                'strSql &= "AND lbillcodes.BillType_ID = 2 " & Environment.NewLine
                strSql &= "ORDER BY lbillcodes.BillCode_Rule " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If iPallet_ShipType = 0 AndAlso dt.Rows.Count = 0 Then
                    Throw New Exception("System could not define Billcode rule. Please verify device's billing.")
                Else
                    If iPallet_ShipType = 0 Then       'REFURBISHED
                        If dt.Select("BillCode_Rule = 1").Length > 0 Then
                            Throw New Exception("This is an DBR unit can't put on Refurbished box.")
                        ElseIf dt.Select("BillCode_Rule = 2").Length > 0 Then
                            Throw New Exception("This is an NER unit can't put on Refurbished box.")
                        ElseIf dt.Select("BillCode_Rule > 1").Length > 0 Then
                            Throw New Exception("This is a fail unit can't put on Refurbished box.")
                        End If
                    Else
                        If Generic.IsDeviceHadParts(iDeviceID) = True Then
                            booFailDeviceHasPart = True
                            If iPallet_ShipType <> 1 Then Throw New Exception("This device has parts please remove them.")
                        End If
                        If iPallet_ShipType = 1 AndAlso dt.Select("BillCode_Rule = 1").Length = 0 Then Throw New Exception("This device is not RUR.")
                    End If
                End If

                Return True
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        ''******************************************************************
        'Public Shared Function CreateShipManifestReport(ByVal iPalletID As Integer, _
        '                                                ByVal strFileName As String) As Integer
        '    Const iTotalHeader As Integer = 1
        '    'Excel Related variables
        '    Dim objDataProc As DBQuery.DataProc
        '    Dim objExcel As Excel.Application    ' Excel application
        '    Dim objBook As Excel.Workbook     ' Excel workbook
        '    Dim objSheet As Excel.Worksheet    ' Excel Worksheet
        '    Dim xlBI As Excel.XlBordersIndex() = {Excel.XlBordersIndex.xlEdgeLeft, Excel.XlBordersIndex.xlEdgeTop, Excel.XlBordersIndex.xlEdgeBottom, _
        '        Excel.XlBordersIndex.xlEdgeRight, Excel.XlBordersIndex.xlInsideVertical, Excel.XlBordersIndex.xlInsideHorizontal}

        '    Dim strFilePath, strSql As String
        '    Dim dt As DataTable
        '    Dim R1 As DataRow
        '    Dim objArr(,) As Object
        '    Dim i, j As Integer

        '    Try
        '        objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
        '        strFilePath = BuildShipPallet.TracFone_MANIFEST_DIR + strFileName + ".xls"

        '        strSql = "SELECT 0 as 'Line#', Pallet_ShipType " & Environment.NewLine
        '        strSql += ", tdevice.Device_SN as 'SN', tmodel.Model_Desc as 'Model' " + Environment.NewLine
        '        strSql += ", freq_Number as 'Freq', capcode as 'Capcode', baud_Number as 'Baud Rate' " + Environment.NewLine
        '        strSql += ", if(Dcode_Ldesc is null, '', Dcode_Ldesc ) as 'Fail Reason' " & Environment.NewLine
        '        strSql += "FROM tdevice " + Environment.NewLine
        '        strSql += "INNER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
        '        strSql += "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " + Environment.NewLine
        '        strSql += "INNER JOIN tmessdata ON tdevice.Device_ID = tmessdata.Device_ID " + Environment.NewLine
        '        strSql += "LEFT OUTER JOIN lfrequency ON tmessdata.freq_id = lfrequency.freq_id " + Environment.NewLine
        '        strSql += "LEFT OUTER JOIN lbaud ON tmessdata.baud_id = lbaud.baud_id " + Environment.NewLine
        '        strSql += "LEFT OUTER JOIN tdevicecodes ON tdevice.Device_ID = tdevicecodes.Device_ID " + Environment.NewLine
        '        strSql += "LEFT OUTER JOIN lcodesdetail ON tdevicecodes.Dcode_ID = lcodesdetail.Dcode_ID " + Environment.NewLine
        '        strSql += "WHERE tdevice.Pallett_ID = " + iPalletID.ToString + " " + Environment.NewLine
        '        strSql += "ORDER BY tdevice.Device_SN " + Environment.NewLine
        '        dt = objDataProc.GetDataTable(strSql)

        '        'Create Line #
        '        i = 0
        '        For Each R1 In dt.Rows
        '            i += 1
        '            R1.BeginEdit()
        '            R1("Line#") = i
        '            R1.EndEdit()
        '            R1.AcceptChanges()
        '        Next R1
        '        dt.AcceptChanges()

        '        If dt.Rows.Count > 0 Then
        '            'Remove unneccessary columns
        '            If dt.Rows(0)("Pallet_ShipType") = 0 Then dt.Columns.Remove("Fail Reason")
        '            dt.Columns.Remove("Pallet_ShipType")
        '            dt.AcceptChanges()

        '            ReDim objArr(dt.Rows.Count + iTotalHeader, dt.Columns.Count)

        '            'Write Header
        '            For i = 0 To dt.Columns.Count - 1
        '                objArr(iTotalHeader - 1, i) = dt.Columns(i).Caption
        '            Next i

        '            'Write Data
        '            For i = 0 To dt.Rows.Count - 1
        '                For j = 0 To dt.Columns.Count - 1
        '                    objArr(i + iTotalHeader, j) = dt.Rows(i)(j)
        '                Next
        '            Next i

        '            'Instantiate Excel Object
        '            objExcel = New Excel.Application()      'Starts the Excel Session
        '            objBook = objExcel.Workbooks.Add                    'Add a Workbook
        '            objExcel.Application.Visible = True                'Make this false while going live
        '            objExcel.Application.DisplayAlerts = False
        '            objSheet = objBook.Worksheets.Item(1)               'Select a Sheet 1 for this

        '            objExcel.ActiveSheet.Pagesetup.Orientation = 2      ' 1 = Portrait ; 2 = landscape

        '            '*******************************
        '            'set text format
        '            '*******************************
        '            For i = 1 To dt.Columns.Count - 1
        '                objSheet.Columns(i + 1).Select()
        '                objExcel.Selection.NumberFormat = "@"
        '            Next i

        '            objSheet.Range("A1" & ":" & Generic.CalExcelColLetter(dt.Columns.Count) & (dt.Rows.Count + iTotalHeader).ToString).Value = objArr

        '            '*******************************
        '            'header
        '            '*******************************
        '            objSheet.Range("A" & iTotalHeader & ":" & Generic.CalExcelColLetter(dt.Columns.Count) & iTotalHeader.ToString).HorizontalAlignment = Excel.Constants.xlCenter
        '            objSheet.Range("A" & iTotalHeader & ":" & Generic.CalExcelColLetter(dt.Columns.Count) & iTotalHeader.ToString).VerticalAlignment = Excel.Constants.xlCenter
        '            '*******************************
        '            With objSheet.Range("A" & iTotalHeader & ":" & Generic.CalExcelColLetter(dt.Columns.Count) & iTotalHeader.ToString).Font
        '                .Name = "Arial"
        '                .FontStyle = "Bold"
        '                .Size = 8
        '                .Underline = False
        '                .ColorIndex = 25
        '            End With
        '            objExcel.Range("A" & iTotalHeader & ":" & Generic.CalExcelColLetter(dt.Columns.Count) & iTotalHeader.ToString).Select()
        '            objExcel.Selection.Interior.ColorIndex = 15 'LIGHT GRAY

        '            '*******************************
        '            'set border
        '            '*******************************
        '            objExcel.Range("A" & iTotalHeader & ":" & Generic.CalExcelColLetter(dt.Columns.Count) & (dt.Rows.Count + iTotalHeader).ToString).Select()
        '            objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.Constants.xlNone
        '            objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.Constants.xlNone

        '            For j = 0 To xlBI.Length - 1
        '                With objExcel.Selection.Borders(xlBI(j))
        '                    .LineStyle = Excel.XlLineStyle.xlContinuous
        '                    .Weight = Excel.XlBorderWeight.xlThin
        '                    .ColorIndex = Excel.Constants.xlAutomatic
        '                End With
        '            Next j

        '            '*******************************
        '            'Set column with
        '            '*******************************
        '            ExcelReports.SetCellWidths(objSheet, dt)

        '            ''*******************************
        '            '' Freeze column headers area
        '            ''*******************************
        '            'objExcel.ActiveWindow.FreezePanes = False
        '            'objExcel.Range("A1:" & Generic.CalExcelColLetter(dt.Columns.Count) & (2).ToString).Select()
        '            'objExcel.ActiveWindow.FreezePanes = True

        '            '*******************************
        '            With objSheet.PageSetup
        '                .Orientation = Excel.XlPageOrientation.xlLandscape
        '                .LeftHeader = "&""Arial,Bold""&14Box Manifest" & Chr(10) & "Box ID: " & strFileName & Chr(10) & "Frequency: " & dt.Rows(0)("Freq") & Chr(10) & "Total: " & dt.Rows.Count.ToString
        '                .LeftFooter = "** PSS Confidential **"
        '                .CenterFooter = "&P of &N"
        '                .RightFooter = "&D&' @'&T"
        '                .HeaderMargin = -25
        '                .TopMargin = 100
        '                .RightMargin = -25
        '                .LeftMargin = -25
        '                '.FitToPagesWide = 1
        '                '.FitToPagesTall = 1
        '            End With

        '            '*******************************
        '            'Save file
        '            '*******************************
        '            If File.Exists(strFilePath) Then Kill(strFilePath)
        '            objBook.SaveAs(strFilePath)
        '            ''***********************************
        '            ''print Report
        '            ''***********************************
        '            'objExcel.ActiveWindow.SelectedSheets.PrintOut(Copies:=iPrintCopyNo, Collate:=True)
        '            ''***********************************

        '        End If
        '        Return dt.Rows.Count
        '    Catch ex As Exception
        '        Throw ex
        '    Finally
        '        objDataProc = Nothing
        '        Generic.DisposeDT(dt)
        '        xlBI = Nothing
        '        objArr = Nothing

        '        '*************************************
        '        'Excel clean up
        '        If Not IsNothing(objSheet) Then
        '            Generic.NAR(objSheet)
        '        End If
        '        If Not IsNothing(objBook) Then
        '            objBook.Close(False)
        '            NAR(objBook)
        '        End If
        '        If Not IsNothing(objExcel) Then
        '            objExcel.Quit()
        '            NAR(objExcel)
        '        End If
        '        GC.Collect()
        '        GC.WaitForPendingFinalizers()
        '        GC.Collect()
        '        GC.WaitForPendingFinalizers()
        '    End Try
        'End Function

        ''******************************************************************
        Private Shared Sub NAR(ByRef o As Object)
            Try
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o)
            Catch ex As Exception
                Throw ex
            Finally
                o = Nothing
            End Try
        End Sub

        ''******************************************************************
        Public Function GetTracFonePallet(ByVal strPallet As String) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT tpallett.*, Manuf_ID, Model_Desc  FROM tpallett " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tpallett.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "WHERE pallett_name = '" & strPallet & "' " & Environment.NewLine
                strSql &= "AND cust_id = " & BuildShipPallet.TracFone_CUSTOMER_ID & Environment.NewLine
                strSql &= "AND Pallet_Invalid = 0 "
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        ''******************************************************************
        Public Function GetWFMPallet(ByVal strPallet As String) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT tpallett.*, Manuf_ID, Model_Desc  FROM tpallett " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tpallett.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "WHERE pallett_name = '" & strPallet & "' " & Environment.NewLine
                strSql &= "AND cust_id = " & PSS.Data.Buisness.WFM.CUSTOMER_ID & Environment.NewLine
                strSql &= "AND Pallet_Invalid = 0 "
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        ''******************************************************************
        Public Function PrintBoxLabel(ByVal iPalletID As Integer, ByVal iPalletShipType As Integer, Optional ByVal strCustomer As String = "") As Integer
            Const strReportName As String = "TF 4x4BoxLabel Push.rpt"
            Dim strSql As String
            Dim dt As DataTable

            Try
                strSql = "SELECT CONCAT('*',cust_OutgoingSku, '*') as PartNumBar" & Environment.NewLine
                strSql &= ", if(Pallet_ShipType = 0, cust_OutgoingSku, cust_IncomingSku) as PartNum " & Environment.NewLine
                strSql &= ", if(Pallet_ShipType = 0, cust_OutgoingDesc, cust_OutgoingDesc) as PartDesc " & Environment.NewLine
                strSql &= ", CONCAT('*', Pallett_Name, '*' ) as CartonIDBar " & Environment.NewLine
                strSql &= ", Pallett_Name as CartonID " & Environment.NewLine
                strSql &= ", CONCAT('*',Pallett_QTY,'*') as CartonQtyBar " & Environment.NewLine
                strSql &= ", Pallett_QTY as CartonQty " & Environment.NewLine
                If iPalletShipType = 1 Then
                    strSql &= ",if(left(Billcode_Desc,3)='RUR', 'RUR', Billcode_Desc) as 'BERReason'  " & Environment.NewLine    ' Billcode_Desc as 'BERReason'  " & Environment.NewLine
                Else
                    strSql &= ", '' as 'BERReason'  " & Environment.NewLine
                End If
                strSql &= ", '" & strCustomer & "' as 'Customer'  " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "INNER JOIN tcustmodel_pssmodel_map ON tpallett.Model_ID = tcustmodel_pssmodel_map.Model_ID " & Environment.NewLine
                If iPalletShipType = 1 Then strSql &= "INNER JOIN lbillcodes ON tpallett.Pallet_SkuLen = lbillcodes.Billcode_ID " & Environment.NewLine
                strSql &= "WHERE pallett_id = " & iPalletID & Environment.NewLine
                strSql &= "AND Pallet_Invalid = 0 "
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    clsMisc.PrintCrystalReportLabel(dt, strReportName, 1)
                    Return dt.Rows.Count
                Else
                    Return dt.Rows.Count
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        ''******************************************************************
        Public Function PrintBoxLabel_TFWFM(ByVal iPalletID As Integer, ByVal iPalletShipType As Integer, ByVal iCust_ID As Integer, ByVal strCustomer As String) As Integer
            Const strReportName As String = "TF 4x4BoxLabel Push.rpt"
            Dim strSql As String
            Dim dt As DataTable

            Try
                strSql = "SELECT CONCAT('*',cust_OutgoingSku, '*') as PartNumBar" & Environment.NewLine
                strSql &= ", if(Pallet_ShipType = 0, cust_OutgoingSku, cust_IncomingSku) as PartNum " & Environment.NewLine
                strSql &= ", if(Pallet_ShipType = 0, cust_OutgoingDesc, cust_OutgoingDesc) as PartDesc " & Environment.NewLine
                strSql &= ", CONCAT('*', Pallett_Name, '*' ) as CartonIDBar " & Environment.NewLine
                strSql &= ", Pallett_Name as CartonID " & Environment.NewLine
                strSql &= ", CONCAT('*',Pallett_QTY,'*') as CartonQtyBar " & Environment.NewLine
                strSql &= ", Pallett_QTY as CartonQty " & Environment.NewLine
                If iPalletShipType = 1 Then
                    strSql &= ",if(left(Billcode_Desc,3)='RUR', 'RUR', Billcode_Desc) as 'BERReason'  " & Environment.NewLine    ' Billcode_Desc as 'BERReason'  " & Environment.NewLine
                Else
                    strSql &= ", '' as 'BERReason'  " & Environment.NewLine
                End If
                strSql &= ", '" & strCustomer & "' as 'Customer'  " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "INNER JOIN tcustmodel_pssmodel_map ON tpallett.Model_ID = tcustmodel_pssmodel_map.Model_ID AND tcustmodel_pssmodel_map.Cust_ID=" & iCust_ID & Environment.NewLine
                If iPalletShipType = 1 Then strSql &= "INNER JOIN lbillcodes ON tpallett.Pallet_SkuLen = lbillcodes.Billcode_ID " & Environment.NewLine
                strSql &= "WHERE pallett_id = " & iPalletID & Environment.NewLine
                strSql &= "AND Pallet_Invalid = 0 "
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    clsMisc.PrintCrystalReportLabel(dt, strReportName, 1)
                    Return dt.Rows.Count
                Else
                    Return dt.Rows.Count
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function PrintWFMBoxLabel(ByVal dtBox As DataTable) As Integer
            Const strReportName As String = "TF WFM Warehouse Box Label.rpt"
            Dim strSql As String
            Dim dt As DataTable
            Try
                'A.Device_ID,A.Device_SN,B.Pallett_ID,B.Pallett_Name,B.pallett_qty,C.Model_ID,C.Model_Desc,B.disp_id,D.disp_cd as 'Disp_Desc'
                strSql = "SELECT '" & dtBox.Rows(0).Item("Pallett_Name") & "' as BoxID" & Environment.NewLine
                strSql &= ",'*" & dtBox.Rows(0).Item("Pallett_Name") & "*' as BoxID_Barcode " & Environment.NewLine
                strSql &= ",'" & dtBox.Rows(0).Item("Model_Desc") & "' as Model_Desc " & Environment.NewLine
                strSql &= "," & dtBox.Rows.Count.ToString & " as BoxQty " & Environment.NewLine
                strSql &= ",'0000' as OrderNo " & Environment.NewLine
                strSql &= ",'" & dtBox.Rows(0).Item("Disp_Desc") & "' as BoxType " & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    clsMisc.PrintCrystalReportLabel(dt, strReportName, 1)
                    Return dt.Rows.Count
                Else
                    Return dt.Rows.Count
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        ''******************************************************************
        Public Function GetAccModelWithSku(ByVal booAddSelectRow As Boolean, Optional ByVal iCust_ID As Integer = 0) As DataTable
            Dim dt As DataTable
            Dim strSql As String = ""

            Try
                If iCust_ID = PSS.Data.Buisness.WFM.CUSTOMER_ID Then
                    strSql = "SELECT model_id, model_desc, model_motosku FROM tmodel WHERE manuf_id =220 AND Model_MotoSku is not null ORDER BY model_desc;"
                Else
                    strSql = "SELECT model_id, model_desc, model_motosku FROM tmodel WHERE manuf_id = 53 AND Model_MotoSku is not null ORDER BY model_desc;"
                End If
                'strSql = "SELECT model_id, model_desc, model_motosku FROM tmodel WHERE manuf_id = 53 AND Model_MotoSku is not null ORDER BY model_desc;"
                dt = _objDataProc.GetDataTable(strSql)

                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function CreateAccBoxID(ByVal iModelID As Integer, _
               ByVal iBoxType As Integer, _
               ByVal strPalletPrefix As String, _
               ByVal Qty As Integer, _
               Optional ByVal iCust_ID As Integer = 0) As Integer
            Dim strSql As String = ""
            Dim strDate As String = ""
            Dim strPalletName As String = ""
            Dim iPalletID As Integer = 0
            Dim iMaxNum As Integer = 0

            Try
                strDate = strDate.Replace(" ", "")
                '******************************
                'construct pallet name
                '******************************
                strDate = Generic.GetMySqlDateTime("%y%m%d")

                strPalletPrefix = strPalletPrefix + strDate & "N"

                strPalletName = Me.DefinePalletName(strPalletPrefix, iMaxNum, iCust_ID)

                'check max number palletts
                If iMaxNum > 999 Then Throw New Exception("Max pallets (per model per box type per day) hit the 999 limit." & Environment.NewLine)

                '******************************
                'check for duplicate pallet
                '******************************
                strSql = "Select count(*) as cnt From tpallett where Pallett_Name = '" & strPalletName & "' and Loc_ID = " & Me.TracFone_LOC_ID
                If Me._objDataProc.GetIntValue(strSql) > 0 Then Throw New Exception("System is trying to create pallet (" & strPalletName & ") which is already existed in system.")

                '******************************
                'Create pallet
                ''******************************
                strSql = "INSERT INTO tpallett ( " & Environment.NewLine
                strSql &= "Pallett_Name " & Environment.NewLine
                'strSql &= ", Pallet_SkuLen " & Environment.NewLine
                strSql &= ", Pallet_ShipType " & Environment.NewLine
                strSql &= ", Pallett_ReadyToShipFlg " & Environment.NewLine
                strSql &= ", Pallett_ShipDate  " & Environment.NewLine
                strSql &= ", Pallett_BulkShipped  " & Environment.NewLine
                strSql &= ", Pallett_QTY " & Environment.NewLine
                strSql &= ", AQL_QCResult_ID " & Environment.NewLine
                strSql &= ", Model_ID " & Environment.NewLine
                strSql &= ", Cust_ID  " & Environment.NewLine
                strSql &= ", Loc_ID  " & Environment.NewLine
                strSql &= ") VALUES (  " & Environment.NewLine
                strSql &= "'" & strPalletName & "' " & Environment.NewLine
                'strSql &= ", '" & iFreqID & "' " & Environment.NewLine
                strSql &= ", " & iBoxType & Environment.NewLine
                strSql &= ", " & 1 & Environment.NewLine
                strSql &= ", date_format(now(), '%Y-%m-%d')" & Environment.NewLine
                strSql &= ", " & 1 & Environment.NewLine
                strSql &= ", " & Qty & Environment.NewLine
                strSql &= ", " & 0 & Environment.NewLine
                strSql &= ", " & iModelID & Environment.NewLine
                If iCust_ID = PSS.Data.Buisness.WFM.CUSTOMER_ID Then
                    strSql &= ", " & iCust_ID & " " & Environment.NewLine
                    strSql &= ", " & PSS.Data.Buisness.WFM.LOC_ID & ");" & Environment.NewLine
                Else
                    strSql &= ", " & Me.TracFone_CUSTOMER_ID & " " & Environment.NewLine
                    strSql &= ", " & Me.TracFone_LOC_ID & ");" & Environment.NewLine
                End If
                'strSql &= ", " & Me.TracFone_CUSTOMER_ID & " " & Environment.NewLine
                'strSql &= ", " & Me.TracFone_LOC_ID & ");" & Environment.NewLine

                iPalletID = Me._objDataProc.idTransaction(strSql, "tpallett")

                If iPalletID = 0 Then iPalletID = Me.GetTracFonePalletID(strPalletName)

                '******************************

                Return iPalletID
            Catch ex As Exception
                Throw ex
            End Try
        End Function

#End Region

		'******************************************************************
		Public Function SetTcelloptWorkStationForPallet(ByVal strNextWrkStation As String, _
														ByVal iPalletID As Integer) As Integer
			Dim strSql As String = ""
			Try
				strSql = "UPDATE production.tcellopt A " & Environment.NewLine
				strSql &= "INNER JOIN production.tdevice B ON A.Device_ID = B.Device_ID " & Environment.NewLine
				strSql &= "SET A.WorkStationEntryDt = now(), A.WorkStation = '" & strNextWrkStation & "'" & Environment.NewLine
				strSql &= "WHERE B.Pallett_ID = " & iPalletID & " " & Environment.NewLine
				Return _objDataProc.ExecuteNonQuery(strSql)

			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'******************************************************************
		Public Function GetBoxSN(ByVal iPalletID As Integer) As DataTable
			Dim strSql As String = ""
			Try
				strSql = "SELECT Device_SN as IMEI, '' as BillCode_Rule, '' as Model_ID, '' as Model_Desc, '' as SKU_Number, '' as RURRTMHasParts, tdevice.Device_ID as device_id, 0 as wo_id, 0 as SNCheck " & Environment.NewLine
				strSql &= ", FuncRep, tdevice.Device_ManufWrty, edi.titem.Manuf_Date, Manuf_ID, WrtyClaimReceiptDt " & Environment.NewLine
				strSql &= ", if (CellOpt_VerificationID is null, '', CellOpt_VerificationID) as CellOpt_VerificationID " & Environment.NewLine
				strSql &= "FROM tdevice " & Environment.NewLine
				strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
				strSql &= "INNER JOIN edi.titem ON tdevice.Device_ID = edi.titem.Device_ID " & Environment.NewLine
				strSql &= "INNER JOIN tcellopt ON tdevice.Device_ID = tcellopt.Device_ID " & Environment.NewLine
				strSql &= "WHERE tdevice.Pallett_ID = " & iPalletID & " " & Environment.NewLine
				strSql &= "Order By tdevice.Device_SN;"
				Return _objDataProc.GetDataTable(strSql)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'******************************************************************
		Public Function GetWipWONo(ByVal iModelID As Integer) As DataRow
			Dim strSql As String = ""
			Dim dt As DataTable
			Try
				strSql = "SELECT * FROM edi.twipwo " & Environment.NewLine
				strSql &= "WHERE date_format(now(), '%Y-%m-%d') >= ScheduledStartDate " & Environment.NewLine
				strSql &= "AND date_format(now(), '%Y-%m-%d') <= ScheduledCompletionDate " & Environment.NewLine
				strSql &= "AND Model_ID = " & iModelID & Environment.NewLine
				strSql &= "AND StatusType = 3;" & Environment.NewLine
				dt = _objDataProc.GetDataTable(strSql)
				If dt.Rows.Count > 0 Then Return dt.Rows(0) Else Return Nothing
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'******************************************************************
		Public Function UpdateWipWorkOrder(ByVal iPalletID As Integer, _
										   ByVal strWipWO As String, _
										   ByVal iWipWO_ID As Integer) As Integer
			Dim strSql As String = ""
			Try
				strSql = "UPDATE edi.titem A " & Environment.NewLine
				strSql &= "INNER JOIN production.tdevice B ON A.Device_ID = B.Device_ID " & Environment.NewLine
				strSql &= "SET A.WIPOrderNo = '" & strWipWO & "'" & Environment.NewLine
				strSql &= ", A.WIPWO_ID = " & iWipWO_ID & "" & Environment.NewLine
				strSql &= "WHERE Pallett_ID = " & iPalletID & " " & Environment.NewLine
				Return _objDataProc.ExecuteNonQuery(strSql)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'******************************************************************
		Public Function GetTFPalletsReadyToBeShipped(ByVal iHoldStatus As Integer) As DataTable
			Dim strSql As String = ""
			Try
				strSql = "SELECT tpallett.pallett_id, " & Environment.NewLine
				strSql &= "tpallett.Pallett_Name as Box, " & Environment.NewLine
				strSql &= "Count(*) as 'Count', " & Environment.NewLine
				'strsql &= "if(tpallett.Pallet_ShipType=9,'RTM',if(tpallett.Pallet_ShipType=1,'RUR',if(tpallett.Pallet_ShipType=8,'SCR','REGULAR'))) as 'Ship Type', " & Environment.NewLine
				strSql &= "IF(tpallett.Pallet_ShipType=0,'REFURBISHED', IF(Pallet_ShipType = 10, 'FFR', 'BER')) as 'Ship Type', " & Environment.NewLine
				strSql &= "tpallett.Pallet_SkuLen as 'SKU Length', " & Environment.NewLine
				strSql &= "tpallett.Pallet_ShipType, " & Environment.NewLine
				strSql &= "tpallett.model_id, " & Environment.NewLine
				strSql &= "tdevice.Loc_ID, " & Environment.NewLine
				strSql &= "tworkorder.group_id, " & Environment.NewLine
				strSql &= "tpallett.Cust_ID " & Environment.NewLine
				strSql &= ", IF(AQL_QCResult_ID = 1, 'PASSED', IF(AQL_QCResult_ID = 2, 'FAILED', '')) as 'AQL Result' " & Environment.NewLine
				strSql &= ", AQL_QCResult_ID " & Environment.NewLine
				strSql &= ", tmodel.Model_Desc " & Environment.NewLine
				strSql &= ", tmodel.Manuf_ID " & Environment.NewLine
				strSql &= "FROM tpallett " & Environment.NewLine
				strSql &= "INNER JOIN tmodel ON tpallett.Model_ID = tmodel.Model_ID " & Environment.NewLine
				strSql &= "INNER JOIN tdevice ON tpallett.Pallett_ID = tdevice.Pallett_ID " & Environment.NewLine
				strSql &= "INNER JOIN tworkorder ON tdevice.wo_id = tworkorder.wo_id " & Environment.NewLine
				strSql &= "WHERE tpallett.Cust_ID = " & Me.TracFone_CUSTOMER_ID & Environment.NewLine
				If iHoldStatus = 0 Or iHoldStatus = 1 Then
					strSql &= "AND Pallett_ShipDate is null and tpallett.Pallett_ReadyToShipFlg = 1 " & Environment.NewLine
				ElseIf iHoldStatus = 2 Then
					strSql &= "AND Pallett_ShipDate is not null and tpallett.Pallett_ReadyToShipFlg = 1 and tpallett.AWPFlag = 1 " & Environment.NewLine
				End If
				'strSql &= "AND ( AQL_QCResult_ID = 1 OR AQL_QCResult_ID = 0 ) " & Environment.NewLine
				strSql &= "group by tpallett.Pallett_ID " & Environment.NewLine
				strSql &= "order by Box;"
				Return Me._objDataProc.GetDataTable(strSql)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'******************************************************************
		Public Function GetWorkStationCountInPallet(ByVal iPalletID As Integer) As Integer
			Dim strSql As String = ""
			Dim dt As DataTable
			Try
				strSql = "SELECT DISTINCT WorkStation " & Environment.NewLine
				strSql &= "FROM tpallett " & Environment.NewLine
				strSql &= "INNER JOIN tdevice on tpallett.Pallett_ID = tdevice.Pallett_ID " & Environment.NewLine
				strSql &= "INNER JOIN tcellopt ON tdevice.Device_ID = tcellopt.Device_ID " & Environment.NewLine
				strSql &= "WHERE tdevice.Device_ID = " & iPalletID & Environment.NewLine
				dt = Me._objDataProc.GetDataTable(strSql)

				Return dt.Rows.Count
			Catch ex As Exception
				Throw ex
			Finally
				Generic.DisposeDT(dt)
			End Try
		End Function

		'******************************************************************
		Public Function ReopenTFBox(ByVal iPalletID As Integer, _
									ByVal strStation As String) As Integer
			Dim strSql As String = ""

			Try
				strSql = "UPDATE tpallett, tcellopt "
				strSql &= "INNER JOIN tdevice ON tpallett.Pallett_ID = tdevice.Pallett_ID " & Environment.NewLine
				strSql += "Set tpallett.Pallett_ReadyToShipFlg = 0 " & Environment.NewLine
				If strStation.Trim.Length > 0 Then strSql &= ", tcellopt.WorkStation = '" & strStation & "', tcellopt.WorkStationEntryDt = now() " & Environment.NewLine
				strSql += "WHERE tdevice.Device_ID = tcellopt.Device_ID AND tpallett.Pallett_ID = " & iPalletID & " " & Environment.NewLine
				strSql += "AND tdevice.Device_DateShip is NULL  " & Environment.NewLine
				strSql += "AND Pallett_ReadyToShipFlg = 1;"

				Return Me._objDataProc.ExecuteNonQuery(strSql)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'******************************************************************
		Public Function GetTFOrderReadyTemplate() As DataTable
			Dim strSql As String
			Try
				strSql = "SELECT 0 as 'Order #', 0 as WO_ID, 0 as 'Qty' limit 0; " & Environment.NewLine
				Return Me._objDataProc.GetDataTable(strSql)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'******************************************************************
		Public Function GetTFOrderNoToFillAccessory(ByVal strOrderNo As String) As DataTable
			Dim strSql As String
			Try
				strSql = "SELECT distinct c.Model_ID, c.cust_model_number, a.wo_id, wo_custwo, wo_raqnty, wo_closed, pkslip_id, count(*) AS cnt" & Environment.NewLine
				strSql &= "FROM tworkorder a" & Environment.NewLine
				strSql &= "INNER JOIN tpallett b ON a.wo_id = b.wo_id " & Environment.NewLine
				strSql &= "INNER JOIN tcustmodel_pssmodel_map c On b.model_id = c.model_id " & Environment.NewLine
				strSql &= "INNER JOIN tdevice d ON d.pallett_id = b.pallett_id" & Environment.NewLine
				strSql &= "WHERE a.wo_custwo= '" & strOrderNo & "'" & Environment.NewLine
				strSql &= "AND b.cust_id = " & BuildShipPallet.TracFone_CUSTOMER_ID & Environment.NewLine
				strSql &= "AND cust_materialcategory = 'PHONE' AND pallet_invalid = 0 AND Pallet_ShipType = 0 AND device_invoice = 0 GROUP BY a.wo_id; " & Environment.NewLine

				Return Me._objDataProc.GetDataTable(strSql)
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		'******************************************************************
		Public Function CreateBillAccessory(ByVal iPalletID As Integer, _
									ByVal iWoID As Integer, _
									ByVal iQty As Integer, _
									ByVal iBilledQty As Integer, _
									ByVal iUserID As Integer) As Integer
			Dim strSql As String = ""

			Try
				strSql = "INSERT INTO tautobillaccessorytransaction "
				strSql &= "(Pallett_ID, WO_ID, AccessoryQty, abh_BilledQty, abh_UserID, abh_TransDate, abh_ComputerName)" & Environment.NewLine
				strSql &= "VALUES (" & iPalletID & ", " & iWoID & ", " & iQty & ", " & iBilledQty & Environment.NewLine
				strSql &= ", " & iUserID & ", now() , '" & System.Net.Dns.GetHostName & "');" & Environment.NewLine

				Return Me._objDataProc.ExecuteNonQuery(strSql)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'******************************************************************
		Public Function GetBillAccessoryWO(ByVal iWoID As Integer) As Integer
			Dim strSql As String = ""
			Dim dt As DataTable
			Try
				strSql = "SELECT * FROM tautobillaccessorytransaction " & Environment.NewLine
				strSql &= "WHERE wo_id = " & iWoID & Environment.NewLine
				dt = Me._objDataProc.GetDataTable(strSql)
				Return dt.Rows.Count
			Catch ex As Exception
				Throw ex
			Finally
				Generic.DisposeDT(dt)
			End Try
		End Function

		'******************************************************************
		Public Function GetDeviceIDHasNoBatteryCover(ByVal dtOrders As DataTable, _
													 ByVal iBatteryCoverBillcodeID As Integer) As DataTable
			Dim strSql, strWOIDs As String
			Dim R1, drNewRow As DataRow
			Dim dt, dtDeviceWithNoBatteryCover As DataTable

			Try
				strSql = "" : strWOIDs = ""
				For Each R1 In dtOrders.Rows
					If strWOIDs.Trim.Length > 0 Then strWOIDs &= ", "
					strWOIDs &= R1("WO_ID")
				Next R1

				strSql = "SELECT Distinct Device_ID, tpallett.Model_ID, tpallett.WO_ID " & Environment.NewLine
				strSql &= "FROM tpallett " & Environment.NewLine
				strSql &= "INNER JOIN tdevice ON tpallett.Pallett_ID = tdevice.Pallett_ID " & Environment.NewLine
				strSql &= "WHERE tpallett.WO_ID in ( " & strWOIDs & ")" & Environment.NewLine
				strSql &= "ORDER BY tpallett.WO_ID" & Environment.NewLine
				dt = Me._objDataProc.GetDataTable(strSql)
				dtDeviceWithNoBatteryCover = New DataTable()
				dtDeviceWithNoBatteryCover = dt.Clone

				For Each R1 In dt.Rows
					strSql = "SELECT count(*) as cnt " & Environment.NewLine
					strSql &= "FROM tdevicebill " & Environment.NewLine
					strSql &= "WHERE Device_ID = " & R1("Device_ID") & Environment.NewLine
					strSql &= "AND BillCode_ID = " & iBatteryCoverBillcodeID & Environment.NewLine
					If Me._objDataProc.GetIntValue(strSql) = 0 Then
						drNewRow = dtDeviceWithNoBatteryCover.NewRow
						drNewRow("Device_ID") = R1("Device_ID") : drNewRow("Model_ID") = R1("Model_ID") : drNewRow("WO_ID") = R1("WO_ID")
						dtDeviceWithNoBatteryCover.Rows.Add(drNewRow)
						dtDeviceWithNoBatteryCover.AcceptChanges()
						drNewRow = Nothing
					End If
				Next R1

				Return dtDeviceWithNoBatteryCover
			Catch ex As Exception
				Throw ex
			Finally
				Generic.DisposeDT(dtOrders)
				Generic.DisposeDT(dt)
				Generic.DisposeDT(dtDeviceWithNoBatteryCover)
				R1 = Nothing
			End Try
		End Function

		'******************************************************************
		Public Function RecalculateWarrantyStatus(ByVal iDeviceID As Integer, _
											 ByVal strManufDateCode As String, _
											 ByVal iManufID As Integer) As Integer
			Dim strSql, strMaxQC As String
			Dim objWrty As Object
			Dim iManufYr, iManufMonth, iWrtyStatus As Integer

			Try
				iWrtyStatus = 0
				strSql = "" : strMaxQC = ""
				strSql = "SELECT max(qc_date) FROM tqc " & Environment.NewLine
				strSql &= "WHERE device_id = " & iDeviceID & Environment.NewLine
				strSql &= "AND qctype_id = 2 AND qcresult_id = 1;"
				strMaxQC = Me._objDataProc.GetSingletonString(strSql)

				If iManufID = 21 Then
					If strManufDateCode.Trim.Length > 0 Then
						objWrty = New Buisness.WarrantyClaim.SamSungWrty()
						iManufYr = Left(Year(CDate(strMaxQC)), 2) & strManufDateCode.Trim.Split(".")(0).PadLeft(2, "0")
						iManufMonth = strManufDateCode.Trim.Split(".")(1).ToString.PadLeft(2, "0")
						iWrtyStatus = objWrty.CheckWrty(iManufYr, iManufMonth, Format(CDate(strMaxQC), "yyyy-MM-dd"))

						strSql = "UPDATE edi.titem, tdevice SET WrtyClaimReceiptDt = '" & Format(CDate(strMaxQC), "yyyy-MM-dd hh:mm:ss") & "'" & Environment.NewLine
						strSql &= ", Device_ManufWrty = " & iWrtyStatus & Environment.NewLine
						strSql &= "WHERE tdevice.Device_ID = edi.titem.Device_ID AND tdevice.device_id = " & iDeviceID & Environment.NewLine
						Me._objDataProc.ExecuteNonQuery(strSql)
					End If
				ElseIf iManufID = 16 Then
					If strManufDateCode.Trim.Length > 0 Then
						objWrty = New Buisness.WarrantyClaim.LG()
						iWrtyStatus = objWrty.CalWarrantyStatus(strManufDateCode, Format(CDate(strMaxQC), "yyyy-MM-dd"))

						strSql = "UPDATE edi.titem, tdevice SET WrtyClaimReceiptDt = '" & Format(CDate(strMaxQC), "yyyy-MM-dd hh:mm:ss") & "'" & Environment.NewLine
						strSql &= ", Device_ManufWrty = " & iWrtyStatus & Environment.NewLine
						strSql &= "WHERE tdevice.Device_ID = edi.titem.Device_ID AND tdevice.device_id = " & iDeviceID & Environment.NewLine
						Me._objDataProc.ExecuteNonQuery(strSql)
					End If
				End If

				Return iWrtyStatus
			Catch ex As Exception
				Throw ex
			Finally
				objWrty = Nothing
			End Try
		End Function

		'******************************************************************
		Public Function GetBillingServicesList(ByVal iModelID As Integer) As DataTable
			Dim strSql As String = ""

			Try
				strSql = "SELECT A.Billcode_ID, Billcode_Desc " & Environment.NewLine
				strSql &= "FROM lbillcodes A " & Environment.NewLine
				strSql &= "INNER JOIN tpsmap B ON A.Billcode_ID = B.Billcode_ID AND B.Model_ID = " & iModelID & Environment.NewLine
				strSql &= "WHERE A.BillType_ID = 1 " & Environment.NewLine
				strSql &= "AND BillCode_Rule = 0 AND A.Billcode_ID NOT IN ( 531, 1618, 1619, 1612 ) " & Environment.NewLine
				Return Me._objDataProc.GetDataTable(strSql)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'******************************************************************
		Public Function GetTracFoneDeviceInWHBox(ByVal strWHBox As String) As DataTable
			Dim strSql As String = ""

			Try
				strSql = "SELECT A.Device_ID, B.Workstation, C.Pallett_ID, C.Model_ID, D.cust_model_number " & Environment.NewLine
				strSql &= "FROM edi.titem A " & Environment.NewLine
				strSql &= "INNER JOIN tcellopt B on A.device_id = B.device_id " & Environment.NewLine
				strSql &= "INNER JOIN tdevice C on A.device_id = C.device_id " & Environment.NewLine
				strSql &= "INNER JOIN tcustmodel_pssmodel_map D on C.Model_ID = D.Model_ID AND D.Cust_ID = 2258 " & Environment.NewLine
				strSql &= "WHERE boxid = '" & strWHBox & "' " & Environment.NewLine
				Return Me._objDataProc.GetDataTable(strSql)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'******************************************************************
		Public Function AssignDeviceInWHBoxToPallet(ByVal strWHBox As String, _
													ByVal iPalletID As Integer) As Integer
			Dim strSql As String = ""

			Try
				strSql = "UPDATE tdevice A " & Environment.NewLine
				strSql &= "INNER JOIN edi.titem B ON A.Device_ID = B.Device_ID " & Environment.NewLine
				strSql &= "SET pallett_id = " & iPalletID.ToString & Environment.NewLine
				strSql &= "WHERE B.BoxID = '" & strWHBox & "'" & Environment.NewLine
				Return Me._objDataProc.ExecuteNonQuery(strSql)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'******************************************************************
		Public Function SetAQLResultOfBox(ByVal iPalletID As Integer, _
										  ByVal iResult As Integer) As Integer
			Dim strSql As String = ""

			Try
				strSql = "UPDATE tpallett SET AQL_QCResult_ID = " & iResult & Environment.NewLine
				strSql &= "WHERE Pallett_ID = " & iPalletID & " " & Environment.NewLine
				Return Me._objDataProc.ExecuteNonQuery(strSql)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'******************************************************************
		Public Function SetPalletSkuLen(ByVal iPallettID As Integer, ByVal strPalletSkuLen As String) As Integer
			Dim strSql As String = ""

			Try
				strSql = "UPDATE tpallett SET Pallet_SkuLen = '" & strPalletSkuLen & "'" & Environment.NewLine
				strSql &= "WHERE Pallett_ID = " & iPallettID & " " & Environment.NewLine
				Return Me._objDataProc.ExecuteNonQuery(strSql)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'******************************************************************
		Public Function GetBERBillcodeID(ByVal iDeviceID As Integer) As String
			Dim strSql As String = ""
			Dim dt As DataTable

			Try
				strSql = "SELECT DISTINCT tdevicebill.Billcode_ID " & Environment.NewLine
				strSql &= "FROM tdevicebill " & Environment.NewLine
				strSql &= "INNER JOIN lbillcodes ON tdevicebill.billcode_id = lbillcodes.billcode_id AND billcode_rule = 1 " & Environment.NewLine
				strSql &= "WHERE tdevicebill.Device_ID = " & iDeviceID & " " & Environment.NewLine
				dt = Me._objDataProc.GetDataTable(strSql)

				If dt.Rows.Count = 0 Then
					Throw New Exception("No BER service is billed.")
				ElseIf dt.Rows.Count > 1 Then
					Throw New Exception("More than one BER service existed.")
				Else
					Return dt.Rows(0)(0).ToString
				End If
			Catch ex As Exception
				Throw ex
			Finally
				Generic.DisposeDT(dt)
			End Try
		End Function

		'******************************************************************
		Public Function IsBoxContainMultiBERCode(ByVal iPalletID As Integer, ByVal iBillcodeID As Integer) As DataSet
			Dim strSql As String = ""
			Dim dt As DataTable
			Dim ds As New DataSet()

			Try
				strSql = "SELECT DISTINCT Device_SN " & Environment.NewLine
				strSql &= "FROM tdevice " & Environment.NewLine
				strSql &= "LEFT OUTER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID AND tdevicebill.Billcode_ID = " & iBillcodeID & Environment.NewLine
				strSql &= "LEFT OUTER JOIN lbillcodes ON tdevicebill.billcode_id = lbillcodes.billcode_id AND billcode_rule = 1 " & Environment.NewLine
				strSql &= "WHERE tdevice.Pallett_ID = " & iPalletID & Environment.NewLine
				strSql &= "AND tdevicebill.Billcode_ID is null"
				dt = Me._objDataProc.GetDataTable(strSql)
				ds.Tables.Add(dt)

				strSql = "SELECT DISTINCT Device_SN " & Environment.NewLine
				strSql &= "FROM tdevice " & Environment.NewLine
				strSql &= "INNER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID " & Environment.NewLine
				strSql &= "INNER JOIN lbillcodes ON tdevicebill.billcode_id = lbillcodes.billcode_id AND billcode_rule = 1 " & Environment.NewLine
				strSql &= "WHERE tdevice.Pallett_ID = " & iPalletID & Environment.NewLine
				strSql &= "AND tdevicebill.Billcode_ID <> " & iBillcodeID
				dt = Me._objDataProc.GetDataTable(strSql)
				ds.Tables.Add(dt)

				Return ds
			Catch ex As Exception
				Throw ex
			Finally
				Generic.DisposeDT(dt)
			End Try
		End Function

        '******************************************************************
        Public Function GetDeviceAdditionalBillData(ByVal iDevice_ID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "select A.*,B.Disp_ID,B.Received_Model_ID,B.Triaged_Model_ID,B.Wb_ID_Incoming,B.Triage_Completed" & Environment.NewLine
                strSql &= " ,C.DBill_InvoiceAmt,C.BillCode_ID,D.BillCode_Desc" & Environment.NewLine
                strSql &= " FROM  production.tdevice A" & Environment.NewLine
                strSql &= " INNER JOIN production.tdevice_triaged_data B ON A.Device_ID=B.Device_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tdevicebill_additional C ON A.Device_ID=C.Device_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.lbillcodes D ON C.BillCode_ID=D.BillCode_ID" & Environment.NewLine
                strSql &= " WHERE A.Device_ID =" & iDevice_ID & ";" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************

    End Class
End Namespace