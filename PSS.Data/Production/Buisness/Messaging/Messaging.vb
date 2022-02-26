Option Explicit On 
Imports CrystalDecisions.CrystalReports.Engine
Imports DBQuery.DataProc
Imports System.Windows.Forms
Imports PSS.Data
Imports System.IO
Imports System.Text
Namespace Buisness
	Public Class Messaging
#Region "DECLARATIONS"
		'lcodesmaster reference for Aquis pager
		'lcodesmaster : Pager Holder = 44;
		'Pager Condition = 45;
		'Physical Abuse = 46
		'Management Type = 47

		'Pager/Holder/Case/Battery Cover Condition ID from lcodesdetail 
		'Dcode_id	Dcode_Sdesc	Dcode_Ldesc
		'3395	PH	Holster
		'3396	PC	Clip
		'3397	MI	Mechanical Intact
		'3398	PD	Damaged
		'3399	PM	Missing
		'3400	NR	Not Required
		'3401	PD	Physical Damage
		'3402	WD	Water Damage
		'3403	PU	Pager Unrepairable
		'3404	NP	No Physical Abuse
		'3405	IM	Inventory Management
		'3406	RM	Return Management
		'3407	RR	Return Retired Product Management
		Public Const Aquis_NotRequired = 3400
		Public Const Aquis_NoPhysicalAbuse = 3404
		Public Const Prod_ID = 1
		Public Const Aquis_Cust_ID = 444
		Public Const Aquis_Loc_ID = 442
		Public Const Pager_Holder_ID = 44
		Public Const Pager_Condition_ID = 45
		Public Const Physical_Abuse_ID = 46
		Public Const Aquis_Holster_ID = 3395
		Public Const Aquis_Clip_ID = 3396
		'Public Const Aquis_Inventory_Management = 3405
		'Public Const Aquis_Return_Management = 3406
		'Public Const Aquis_Return_Retired_Product_Management = 3407
        Public Const strMessCust_IDs As String = "14,444,2563,2507,2508,2607"
		Public Const AquisRecDocLoc As String = "C:\Aquis_Doc\"		  'Local scan document
		Public Const AquisRecDocNet As String = "R:\Aquis\Receiving_Doc\"		 'scan docoment storage location
		Private _objDataProc As DBQuery.DataProc
		Private _strRptPath As String = "P:\Dept\Labels\" & System.Net.Dns.GetHostName & "\"
		Private _strAquisReceivingRptName As String = "Aquis_Receiving_Label.rpt"
		Private _strAquisBoxRptName As String = "Aquis_Box_Label.rpt"
#End Region
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
		Public Function DisposeDT(ByRef dt As DataTable)
			If Not IsNothing(dt) Then
				dt.Dispose()
				dt = Nothing
			End If
		End Function

#End Region
#Region "Misc.(get Model/Conditions/Holder/Freq/Baud/Signal/Carrier etc.)"


		''********************************************************************************************************

		'Public Function GetModels(ByVal booAddSelectRow As Boolean, _
		'                             Optional ByVal iProdID As Integer = 0, _
		'                             Optional ByVal iManufID As Integer = 0) As DataTable

		'    Dim strSql As String = ""
		'    Dim dt As DataTable

		'    Try
		'        strSql = "SELECT a.Model_ID,a.Model_Desc , case b.Holder_ID when 3340 then 'Holster' when 3341 then 'Clip' else '' end as 'Holder',b.EndOfLife" & Environment.NewLine
		'        strSql &= "FROM tmodel a " & Environment.NewLine
		'        strSql &= "LEFT JOIN tmodelcriteria b on b.Model_ID=a.Model_ID" & Environment.NewLine
		'        If iProdID > 0 Then strSql &= "WHERE a.Prod_ID = " & iProdID & Environment.NewLine Else strSql &= "WHERE a.prod_id=" & Me.Prod_ID & Environment.NewLine
		'        If iManufID > 0 Then strSql &= "AND Manuf_ID = " & iManufID & Environment.NewLine
		'        strSql &= "AND b.Holder_ID is not null" & Environment.NewLine
		'        strSql &= "ORDER BY a.Model_Desc;" & Environment.NewLine
		'        dt = Me._objDataProc.GetDataTable(strSql)
		'        If booAddSelectRow = True Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)
		'        Return dt

		'    Catch ex As Exception
		'        Throw ex
		'    Finally
		'        Me.DisposeDT(dt)
		'    End Try
		'End Function

		''********************************************************************************************************

		'Public Function GetPhysicalAbuse(ByVal booAddSelectRow As Boolean) As DataTable
		'    Dim strSql As String = ""
		'    Dim dt As DataTable

		'    Try
		'        strSql = "SELECT Dcode_id,Dcode_Ldesc,Dcode_Sdesc " & Environment.NewLine
		'        strSql &= "FROM lcodesdetail" & Environment.NewLine
		'        strSql &= "WHERE prod_ID = " & Me.Prod_ID & Environment.NewLine
		'        strSql &= "AND mcode_ID = " & Me.Physical_Abuse_ID & Environment.NewLine
		'        dt = Me._objDataProc.GetDataTable(strSql)
		'        If booAddSelectRow = True Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)
		'        Return dt
		'    Catch ex As Exception
		'        Throw ex
		'    Finally
		'        Me.DisposeDT(dt)
		'    End Try
		'End Function

		''********************************************************************************************************

		'Public Function GetPagerConditions(ByVal booAddSelectRow As Boolean) As DataTable
		'    Dim strSql As String = ""
		'    Dim dt As DataTable

		'    Try
		'        strSql = "SELECT Dcode_id,Dcode_Ldesc,Dcode_Sdesc " & Environment.NewLine
		'        strSql &= "FROM lcodesdetail" & Environment.NewLine
		'        strSql &= "WHERE prod_ID = " & Me.Prod_ID & Environment.NewLine
		'        strSql &= "AND mcode_ID = " & Me.Pager_Condition_ID & Environment.NewLine
		'        dt = Me._objDataProc.GetDataTable(strSql)
		'        If booAddSelectRow = True Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)
		'        Return dt
		'    Catch ex As Exception
		'        Throw ex
		'    Finally
		'        Me.DisposeDT(dt)
		'    End Try
		'End Function

		''********************************************************************************************************

		'Public Function GetPagerHolders(ByVal booAddSelectRow As Boolean) As DataTable
		'    Dim strSql As String = ""
		'    Dim dt As DataTable

		'    Try
		'        strSql = "SELECT Dcode_id,Dcode_Ldesc,Dcode_Sdesc" & Environment.NewLine
		'        strSql &= "FROM lcodesdetail" & Environment.NewLine
		'        strSql &= "WHERE prod_ID = " & Me.Prod_ID & Environment.NewLine
		'        strSql &= "AND mcode_ID = " & Me.Pager_Holder_ID & Environment.NewLine
		'        dt = Me._objDataProc.GetDataTable(strSql)
		'        If booAddSelectRow = True Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)
		'        Return dt
		'    Catch ex As Exception
		'        Throw ex
		'    Finally
		'        Me.DisposeDT(dt)
		'    End Try
		'End Function

		'*******************************************************
		Public Function GetFrequencies(ByVal booAddSelectRow As Boolean) As DataTable
			Dim strSql As String
			Dim dt As DataTable

			Try
				strSql = "SELECT * FROM lfrequency ORDER BY freq_id;"
				dt = Me._objDataProc.GetDataTable(strSql)
				If booAddSelectRow = True Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)
				Return dt

			Catch ex As Exception
				Throw ex
			Finally
				Me.DisposeDT(dt)
			End Try

		End Function
		''********************************************************************************************************
		'Public Function GetBaudRate(ByVal booAddSelectRow As Boolean) As DataTable
		'    Dim strSql As String
		'    Dim dt As DataTable

		'    Try
		'        strSql = "SELECT * FROM lbaud ORDER BY baud_number;"
		'        dt = Me._objDataProc.GetDataTable(strSql)
		'        If booAddSelectRow = True Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)
		'        Return dt

		'    Catch ex As Exception
		'        Throw ex
		'    Finally
		'        Me.DisposeDT(dt)
		'    End Try

		'End Function

		'********************************************************************************************************
		Public Function GetSignalFormat() As DataTable
			Dim strSql As String

			Try
				strSql = "SELECT '0' as 'ID' , '-- SELECT --' as 'SignalFormat'" & Environment.NewLine
				strSql &= "Union" & Environment.NewLine
				strSql &= "SELECT '1' as 'ID' , 'FLEX' as 'SignalFormat'" & Environment.NewLine
				strSql &= "Union" & Environment.NewLine
				strSql &= "SELECT '2' as 'ID' , 'POCSAG' as 'SignalFormat';" & Environment.NewLine
				Return Me._objDataProc.GetDataTable(strSql)

			Catch ex As Exception
				Throw ex
			End Try

		End Function

		''********************************************************************************************************
		'Public Function GetShipmentCarrier(ByVal booAddSelectRow As Boolean) As DataTable
		'    Dim strSql As String
		'    Dim dt As DataTable

		'    Try
		'        strSql = "SELECT * FROM lshipcarrier ORDER BY SC_Desc;"
		'        dt = Me._objDataProc.GetDataTable(strSql)
		'        If booAddSelectRow = True Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)
		'        Return dt

		'    Catch ex As Exception
		'        Throw ex
		'    Finally
		'        Me.DisposeDT(dt)
		'    End Try

		'End Function

		'********************************************************************************************************

#End Region
#Region "Aquis Manage Model Setup"

		'********************************************************************************************************

		Public Function GetModelsCriteria() As DataTable
			Dim strSql As String = ""

			Try
				strSql = "SELECT a.Model_ID,a.Model_Desc as 'Model Description', case b.Holder_ID when 3340 then 'Holster' when 3341 then 'Clip' else '' end as 'Holder',b.EndOfLife" & Environment.NewLine
				strSql &= "FROM tmodel a " & Environment.NewLine
				strSql &= "LEFT JOIN tmodelcriteria b on b.Model_ID=a.Model_ID" & Environment.NewLine
				strSql &= "WHERE a.prod_id=" & Me.Prod_ID & Environment.NewLine
				strSql &= "Order By a.Model_Desc" & Environment.NewLine
				Return Me._objDataProc.GetDataTable(strSql)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'********************************************************************************************************

		Public Function UpdateModelHolder(ByVal Cust_ID As Integer, ByVal Model_ID As Integer, ByVal Holder_ID As Integer) As Integer
			Dim strSql As String = ""
			Dim dt As DataTable
			Try
				strSql = "SELECT Model_ID" & Environment.NewLine
				strSql &= " FROM tmodelcriteria " & Environment.NewLine
				strSql &= " where Cust_ID=" & Cust_ID & Environment.NewLine
				strSql &= " And Model_ID=" & Model_ID & Environment.NewLine
				dt = _objDataProc.GetDataTable(strSql)

				If dt.Rows.Count > 0 Then
					strSql = "Update tmodelcriteria Set Holder_ID =" & Holder_ID & Environment.NewLine
					strSql &= "where Cust_ID=" & Cust_ID & Environment.NewLine
					strSql &= "And Model_ID=" & Model_ID & Environment.NewLine
					Return _objDataProc.ExecuteNonQuery(strSql)
				Else
					strSql = "Insert tmodelcriteria (Cust_ID,Model_ID,Holder_ID) Values (" & Environment.NewLine
					strSql &= Cust_ID & "," & Environment.NewLine
					strSql &= Model_ID & "," & Environment.NewLine
					strSql &= Holder_ID & ")" & Environment.NewLine
					Return _objDataProc.ExecuteNonQuery(strSql)
				End If

			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'********************************************************************************************************

		Public Function UpdateModelEndOfLife(ByVal Cust_ID As Integer, ByVal Model_ID As Integer, ByVal EndOfLife_ID As Integer) As Integer
			Dim strSql As String = ""
			Dim dt As DataTable
			Try
				strSql = "SELECT Model_ID" & Environment.NewLine
				strSql &= " FROM tmodelcriteria " & Environment.NewLine
				strSql &= " where Cust_ID=" & Cust_ID & Environment.NewLine
				strSql &= " And Model_ID=" & Model_ID & Environment.NewLine
				dt = _objDataProc.GetDataTable(strSql)

				If dt.Rows.Count > 0 Then
					strSql = "Update tmodelcriteria Set EndOfLife =" & EndOfLife_ID & Environment.NewLine
					strSql &= "where Cust_ID=" & Cust_ID & Environment.NewLine
					strSql &= "And Model_ID=" & Model_ID & Environment.NewLine
					Return _objDataProc.ExecuteNonQuery(strSql)
				Else
					strSql = "Insert tmodelcriteria (Cust_ID,Model_ID,EndOfLife) Values (" & Environment.NewLine
					strSql &= Cust_ID & "," & Environment.NewLine
					strSql &= Model_ID & "," & Environment.NewLine
					strSql &= EndOfLife_ID & ")" & Environment.NewLine
					Return _objDataProc.ExecuteNonQuery(strSql)
				End If

			Catch ex As Exception
				Throw ex
			End Try
		End Function

#End Region
#Region "Aquis Warehouse Box"

		''********************************************************************************************************
		'Public Function IsThereOpenBox(ByVal iModelID As Integer, _
		'                               ByVal iFreqID As Integer, _
		'                               ByVal iBaudRateID As Integer) As Boolean

		'    Dim strSql As String = ""
		'    Dim dt As DataTable

		'    Try
		'        strSql = "SELECT *" & Environment.NewLine
		'        strSql &= "FROM warehouse.warehouse_box w" & Environment.NewLine
		'        strSql &= "WHERE Closed = 0" & Environment.NewLine
		'        strSql &= "AND Model_ID =" & iModelID & Environment.NewLine
		'        strSql &= "AND Freq_ID =" & iFreqID & Environment.NewLine
		'        strSql &= "AND BaudRate_ID =" & iBaudRateID & Environment.NewLine

		'        dt = Me._objDataProc.GetDataTable(strSql)

		'        If dt.Rows.Count > 0 Then
		'            Return True
		'        Else
		'            Return False
		'        End If

		'    Catch ex As Exception
		'        Throw ex
		'    Finally
		'        Me.DisposeDT(dt)
		'    End Try
		'End Function

		'********************************************************************************************************
		'Public Function IsWareHouseBoxClose(ByVal WB_ID As Integer) As Boolean

		'    Dim strSql As String = ""
		'    Dim dt As DataTable

		'    Try
		'        strSql = "SELECT *" & Environment.NewLine
		'        strSql &= "FROM warehouse.warehouse_box w" & Environment.NewLine
		'        strSql &= "WHERE Closed = 1" & Environment.NewLine
		'        strSql &= "AND WB_ID =" & WB_ID & Environment.NewLine

		'        dt = Me._objDataProc.GetDataTable(strSql)

		'        If dt.Rows.Count > 0 Then
		'            Return True
		'        Else
		'            Return False
		'        End If

		'    Catch ex As Exception
		'        Throw ex
		'    Finally
		'        Me.DisposeDT(dt)
		'    End Try
		'End Function

		'********************************************************************************************************
		Public Function IsWareHouseSerialExist(ByVal Serial As String) As Boolean

			Dim strSql As String = ""
			Dim dt As DataTable

			Try
				strSql = "SELECT *" & Environment.NewLine
				strSql &= "FROM warehouse.warehouse_items" & Environment.NewLine
				strSql &= "Where Serial='" & Serial & "'" & Environment.NewLine
				strSql &= "AND Device_ID=0;" & Environment.NewLine

				dt = Me._objDataProc.GetDataTable(strSql)

				If dt.Rows.Count > 0 Then
					Return True
				Else
					Return False
				End If

			Catch ex As Exception
				Throw ex
			Finally
				Me.DisposeDT(dt)
			End Try
		End Function
		'******************************************************************
		Public Function GetNextWareHouseBoxSeqNo(ByVal strBoxPrefix As String, ByVal iNumberLength As Integer) As String
			Dim strSQL As String
			Dim dt As DataTable
			Dim strBox_Name As String = strBoxPrefix

			Try
				strSQL = "SELECT max(right(Box_Name, " & iNumberLength & " ) ) + 1 as NextSequenceNumber " & Environment.NewLine
				strSQL &= "FROM warehouse.warehouse_box " & Environment.NewLine
				strSQL &= "WHERE Box_Name like '" & strBoxPrefix & "%' " & Environment.NewLine
				dt = Me._objDataProc.GetDataTable(strSQL)
				If dt.Rows.Count > 0 Then
					If Not IsDBNull(dt.Rows(0)("NextSequenceNumber")) Then
						strBox_Name &= dt.Rows(0)("NextSequenceNumber").ToString.Trim.PadLeft(iNumberLength, "0")
					Else
						strBox_Name &= "1".PadLeft(iNumberLength, "0")
					End If
				Else
					strBox_Name &= "1".PadLeft(iNumberLength, "0")
				End If

				Return strBox_Name
			Catch ex As Exception
				Throw ex
			Finally
				Me.DisposeDT(dt)
			End Try
		End Function

		''*******************************************************************************************************************
		'Public Function CreateWareHouseBox(ByVal BoxPrefix As String, ByVal Cust_ID As Integer, ByVal Loc_ID As Integer, ByVal iModelID As Integer, _
		'                            ByVal iFrequencyID As Integer, ByVal iBaudRateID As Integer, ByVal iUserID As Integer) As Integer

		'    Dim strSQL, strDateFormat, strBoxName As String
		'    Dim dt As DataTable
		'    Dim iWareHouseBoxID As Integer = 0
		'    'ApplicationUser.IDuser, ApplicationUser.User
		'    Try
		'        strDateFormat = Format(CDate(Generic.MySQLServerDateTime()), "yyyyMMdd")
		'        strBoxName = BoxPrefix & strDateFormat & "B"
		'        'Build BoxName with next seq. number
		'        strBoxName = Me.GetNextWareHouseBoxSeqNo(strBoxName, 4)

		'        '*********************************************
		'        'Create Pallet
		'        '*********************************************
		'        strSQL = "INSERT INTO warehouse.warehouse_box (" & Environment.NewLine
		'        strSQL &= "Box_Name " & Environment.NewLine
		'        strSQL &= ", Model_ID" & Environment.NewLine
		'        strSQL &= ", Freq_ID" & Environment.NewLine
		'        strSQL &= ", BaudRate_ID" & Environment.NewLine
		'        strSQL &= ", Closed" & Environment.NewLine
		'        strSQL &= ", Box_CreatedDate" & Environment.NewLine
		'        strSQL &= ", Box_ShipDate" & Environment.NewLine
		'        strSQL &= ", User_ID" & Environment.NewLine
		'        strSQL &= ", Box_QTY" & Environment.NewLine
		'        strSQL &= ", Cust_ID" & Environment.NewLine
		'        strSQL &= ", Loc_ID" & Environment.NewLine
		'        strSQL &= ") VALUES ( " & Environment.NewLine
		'        strSQL &= "'" & strBoxName & "'" & Environment.NewLine
		'        strSQL &= ", " & iModelID & Environment.NewLine
		'        strSQL &= ", " & iFrequencyID & Environment.NewLine
		'        strSQL &= ", " & iBaudRateID & Environment.NewLine
		'        strSQL &= ", 0" & Environment.NewLine
		'        strSQL &= ", Now()" & Environment.NewLine
		'        strSQL &= ", Null" & Environment.NewLine
		'        strSQL &= ", " & iUserID & Environment.NewLine
		'        strSQL &= ", 0" & Environment.NewLine
		'        strSQL &= ", " & Cust_ID & Environment.NewLine
		'        strSQL &= ", " & Loc_ID & Environment.NewLine
		'        strSQL &= ")"
		'        Return _objDataProc.idTransaction(strSQL, "warehouse.warehouse_box")

		'    Catch ex As Exception
		'        Throw ex
		'    End Try
		'End Function


		''*******************************************************************************************************************

		'Public Function GetWarehouseOpenBoxes(ByVal iLocID As Integer, ByVal iCustID As Integer) As DataTable
		'    Dim strSql As String

		'    Try
		'        strSql = "SELECT w.*,m.Model_Desc as 'Model',f.freq_number as 'Freq',b.baud_number as 'Baud',m.Manuf_ID" & Environment.NewLine
		'        strSql &= "FROM warehouse.warehouse_box w" & Environment.NewLine
		'        strSql &= "Left join Production.tmodel m on m.model_id=w.model_id" & Environment.NewLine
		'        strSql &= "Left join Production.lfrequency f on f.freq_id=w.freq_id" & Environment.NewLine
		'        strSql &= "Left join Production.lbaud b on b.baud_id=w.baudrate_id" & Environment.NewLine
		'        strSql &= "Where w.Closed=0" & Environment.NewLine
		'        strSql &= "And w.Cust_ID = " & iCustID & Environment.NewLine
		'        strSql &= "And w.Loc_ID = " & iLocID & Environment.NewLine
		'        strSql &= "Order By w.WB_ID" & Environment.NewLine
		'        Return Me._objDataProc.GetDataTable(strSql)

		'    Catch ex As Exception
		'        Throw ex
		'    End Try
		'End Function
		'*******************************************************************************************************************

		'Public Function GetWarehouseOpenBoxes(ByVal WR_ID As Integer) As DataTable
		'    Dim strSql As String

		'    Try
		'        strSql = "SELECT Distinct a.Box_Name " & Environment.NewLine
		'        strSql &= "FROM warehouse.warehouse_box a" & Environment.NewLine
		'        strSql &= "Inner Join warehouse.warehouse_items b on b.WB_ID=a.WB_ID" & Environment.NewLine
		'        strSql &= "Where b.WR_ID=" & WR_ID & Environment.NewLine
		'        strSql &= "And a.Closed = 0" & Environment.NewLine
		'        strSql &= "Order By a.Box_Name;" & Environment.NewLine

		'        Return Me._objDataProc.GetDataTable(strSql)

		'    Catch ex As Exception
		'        Throw ex
		'    End Try
		'End Function

		''**************************************************************
		'Public Function GetWarehouseBoxByName(ByVal strBoxName As String, _
		'                        ByVal iLocID As Integer, ByVal iCustID As Integer) As DataTable

		'    Dim strSql As String = ""

		'    Try

		'        strSql = "SELECT *" & Environment.NewLine
		'        strSql &= "FROM warehouse.warehouse_box w" & Environment.NewLine
		'        strSql &= "WHERE w.Box_Name= '" & strBoxName & "'" & Environment.NewLine
		'        strSql &= "And w.Cust_ID = " & iCustID & Environment.NewLine
		'        strSql &= "And w.Loc_ID = " & iLocID & Environment.NewLine
		'        Return Me._objDataProc.GetDataTable(strSql)

		'    Catch ex As Exception
		'        Throw ex
		'    End Try
		'End Function


		''*******************************************************************************************************************
		'Public Function GetWarehouseBoxItems(ByVal iWB_ID As Integer) As DataTable
		'    Dim strSql As String

		'    Try
		'        strSql = "SELECT i.*,b.Closed" & Environment.NewLine
		'        strSql &= "FROM warehouse.warehouse_items i" & Environment.NewLine
		'        strSql &= "inner join warehouse.warehouse_box b on b.WB_ID=i.WB_ID" & Environment.NewLine
		'        strSql &= "Where b.Closed=0" & Environment.NewLine
		'        strSql &= "And b.WB_ID = " & iWB_ID & Environment.NewLine
		'        strSql &= "Order By i.Serial,i.Pager_Number" & Environment.NewLine
		'        Return Me._objDataProc.GetDataTable(strSql)

		'    Catch ex As Exception
		'        Throw ex
		'    End Try
		'End Function

		''**************************************************************
		'Public Function DeleteWarehouseBox(ByVal iWB_ID As Integer) As Integer

		'    Dim strSql As String = ""

		'    Try

		'        strSql = "Delete From Warehouse.warehouse_box" & Environment.NewLine
		'        strSql += "Where WB_ID = " & iWB_ID
		'        Return Me._objDataProc.ExecuteNonQuery(strSql)

		'    Catch ex As Exception
		'        Throw ex

		'    End Try


		'End Function

		''**************************************************************
		'Public Function ReopenWarehouseBox(ByVal iWB_ID As Integer) As Integer

		'    Dim strSql As String = ""

		'    Try

		'        strSql = "Update Warehouse.warehouse_box" & Environment.NewLine
		'        strSql += "Set Closed = 0 " & Environment.NewLine
		'        strSql += "Where WB_ID = " & iWB_ID
		'        Return Me._objDataProc.ExecuteNonQuery(strSql)

		'    Catch ex As Exception
		'        Throw ex

		'    End Try


		'End Function

		''**************************************************************
		'Public Function ClearWarehouseBox(ByVal iWB_ID As Integer, ByVal iUserID As Integer) As Integer
		'    Dim i As Integer
		'    Dim strSql As String = ""

		'    Try


		'        strSql = "Update Warehouse.warehouse_box" & Environment.NewLine
		'        strSql += "Set Box_QTY = 0,User_ID=" & iUserID & Environment.NewLine
		'        strSql += ",Box_CreatedDate=now()" & Environment.NewLine
		'        strSql += "Where WB_ID = " & iWB_ID
		'        i = Me._objDataProc.ExecuteNonQuery(strSql)

		'        strSql = "Update Warehouse.warehouse_items" & Environment.NewLine
		'        strSql += "Set WB_ID = 0" & Environment.NewLine
		'        strSql += "Where WB_ID = " & iWB_ID
		'        Return Me._objDataProc.ExecuteNonQuery(strSql)

		'    Catch ex As Exception
		'        Throw ex

		'    End Try


		'End Function

		'******************************************************************

#End Region
#Region "Aquis Warehouse Receipt"
		''**************************************************************
		'Public Function InsertCustomerAddress(ByVal Last_Name As String, _
		'                                      ByVal First_Name As String, _
		'                                      ByVal MI_Name As String, _
		'                                      ByVal Address1 As String, _
		'                                      ByVal Address2 As String, _
		'                                      ByVal City As String, _
		'                                      ByVal Zip As String, _
		'                                      ByVal State_ID As Integer, _
		'                                      ByVal Cntry_ID As Integer, _
		'                                      ByVal Tel As String, _
		'                                      ByVal Fax As String, _
		'                                      ByVal Email As String, _
		'                                      ByVal Cust_ID As Integer, _
		'                                      ByVal Loc_ID As Integer, _
		'                                      ByVal Company_Name As String) As Integer

		'    Dim strSql As String = ""

		'    Try

		'        strSql = "INSERT INTO treceivefrom (" & Environment.NewLine
		'        strSql &= "Last_Name" & Environment.NewLine
		'        strSql &= ", First_Name" & Environment.NewLine
		'        strSql &= ", MI_Name" & Environment.NewLine
		'        strSql &= ", Address1" & Environment.NewLine
		'        strSql &= ", Address2" & Environment.NewLine
		'        strSql &= ", City" & Environment.NewLine
		'        strSql &= ", Zip" & Environment.NewLine
		'        strSql &= ", State_ID" & Environment.NewLine
		'        strSql &= ", Cntry_ID" & Environment.NewLine
		'        strSql &= ", Tel" & Environment.NewLine
		'        strSql &= ", Fax" & Environment.NewLine
		'        strSql &= ", Email" & Environment.NewLine
		'        strSql &= ", Cust_ID" & Environment.NewLine
		'        strSql &= ", Loc_ID" & Environment.NewLine
		'        strSql &= ", Company_Name" & Environment.NewLine
		'        strSql &= ") VALUES ( " & Environment.NewLine
		'        strSql &= "'" & Last_Name & "'" & Environment.NewLine
		'        strSql &= ",'" & First_Name & "'" & Environment.NewLine
		'        strSql &= ",'" & MI_Name & "'" & Environment.NewLine
		'        strSql &= ",'" & Address1 & "'" & Environment.NewLine
		'        strSql &= ",'" & Address2 & "'" & Environment.NewLine
		'        strSql &= ",'" & City & "'" & Environment.NewLine
		'        strSql &= ",'" & Zip & "'" & Environment.NewLine
		'        strSql &= ", " & State_ID & Environment.NewLine
		'        strSql &= ", " & Cntry_ID & Environment.NewLine
		'        strSql &= ",'" & Tel & "'" & Environment.NewLine
		'        strSql &= ",'" & Fax & "'" & Environment.NewLine
		'        strSql &= ",'" & Email & "'" & Environment.NewLine
		'        strSql &= ", " & Cust_ID & Environment.NewLine
		'        strSql &= ", " & Loc_ID & Environment.NewLine
		'        strSql &= ",'" & Company_Name & "'" & Environment.NewLine
		'        strSql &= ")"

		'        Return _objDataProc.idTransaction(strSql, "treceivefrom")

		'    Catch ex As Exception
		'        Throw ex

		'    End Try

		'End Function

		''*******************************************************************************************************************

		'Public Function GetCustomersList(ByVal booAddSelectRow As Boolean, _
		'                                    ByVal iLocID As Integer, _
		'                                    ByVal iCustID As Integer) As DataTable
		'    Dim strSql As String
		'    Dim dt As DataTable

		'    Try
		'        strSql = "SELECT RF_ID, concat(Last_Name,',',First_Name,' ',MI_Name) as FullName" & Environment.NewLine
		'        strSql &= "FROM treceivefrom" & Environment.NewLine
		'        strSql &= "Where Cust_ID = " & iCustID & Environment.NewLine
		'        strSql &= "And Loc_ID = " & iLocID & Environment.NewLine
		'        strSql &= "Order By FullName" & Environment.NewLine
		'        dt = Me._objDataProc.GetDataTable(strSql)
		'        If booAddSelectRow = True Then dt.LoadDataRow(New Object() {"0", "--Create New Customer--"}, False)

		'        Return dt
		'    Catch ex As Exception
		'        Throw ex
		'    Finally
		'        Me.DisposeDT(dt)
		'    End Try

		'End Function

		''*******************************************************************************************************************
		'Public Function CreateWareHouseReceipt(ByVal BoxPrefix As String, ByVal iCustID As Integer, ByVal iLocID As Integer, ByVal RF_ID As Integer, _
		'                ByVal SC_ID As Integer, ByVal Tracking As String, _
		'                ByVal Account As String, _
		'                ByVal iUserID As Integer, _
		'                Optional ByVal RMA As String = "") As Integer

		'    Dim strSQL, strDateFormat, strReceiptName As String
		'    Dim dt As DataTable
		'    Dim iWR_ID As Integer = 0

		'    Try
		'        strDateFormat = Format(CDate(Generic.MySQLServerDateTime()), "yyyyMMdd")
		'        strReceiptName = BoxPrefix & strDateFormat & "R"
		'        strReceiptName = Me.GetNextWareHouseReceiptSeqNo(iCustID, iLocID, strReceiptName, 4)

		'        '*********************************************
		'        'Create Warehouse Receipt 
		'        '*********************************************
		'        strSQL = "INSERT INTO warehouse.warehouse_receipt (" & Environment.NewLine
		'        strSQL &= "WR_Name " & Environment.NewLine
		'        strSQL &= ", RF_ID" & Environment.NewLine
		'        strSQL &= ", SC_ID" & Environment.NewLine
		'        strSQL &= ", Tracking" & Environment.NewLine
		'        strSQL &= ", Account" & Environment.NewLine
		'        strSQL &= ", Receipt_Date" & Environment.NewLine
		'        strSQL &= ", Receipt_QTY" & Environment.NewLine
		'        strSQL &= ", Closed" & Environment.NewLine
		'        strSQL &= ", User_ID" & Environment.NewLine
		'        strSQL &= ", Cust_ID" & Environment.NewLine
		'        strSQL &= ", Loc_ID " & Environment.NewLine
		'        If RMA <> "" Then strSQL &= ", RMA " & Environment.NewLine
		'        strSQL &= ") VALUES ( " & Environment.NewLine
		'        strSQL &= "'" & strReceiptName & "'" & Environment.NewLine
		'        strSQL &= ", " & RF_ID & Environment.NewLine
		'        strSQL &= ", " & SC_ID & Environment.NewLine
		'        strSQL &= ", '" & Tracking & "'" & Environment.NewLine
		'        strSQL &= ", '" & Account & "'" & Environment.NewLine
		'        strSQL &= ", Now()" & Environment.NewLine
		'        strSQL &= ", 0" & Environment.NewLine
		'        strSQL &= ", 0" & Environment.NewLine
		'        strSQL &= ", " & iUserID & Environment.NewLine
		'        strSQL &= ", " & iCustID & Environment.NewLine
		'        strSQL &= ", " & iLocID & Environment.NewLine
		'        If RMA <> "" Then strSQL &= ", '" & RMA & "'" & Environment.NewLine
		'        strSQL &= ")"
		'        Return _objDataProc.idTransaction(strSQL, "warehouse.warehouse_receipt")

		'    Catch ex As Exception
		'        Throw ex
		'    End Try
		'End Function

		'******************************************************************
		Public Function GetNextWareHouseReceiptSeqNo(ByVal iCustID As Integer, ByVal iLocID As Integer _
		  , ByVal strReceiptPrefix As String, ByVal iNumberLength As Integer) As String
			Dim strSQL As String
			Dim dt As DataTable
			Dim strReceipt_Name As String = strReceiptPrefix

			Try
				strSQL = "SELECT max(right(WR_Name, " & iNumberLength & " ) ) + 1 as NextSequenceNumber " & Environment.NewLine
				strSQL &= "FROM warehouse.warehouse_receipt " & Environment.NewLine
				strSQL &= "WHERE WR_Name like '" & strReceiptPrefix & "%' " & Environment.NewLine
				strSQL &= "AND Cust_ID = " & iCustID & Environment.NewLine
				strSQL &= "AND Loc_ID = " & iLocID & Environment.NewLine
				dt = Me._objDataProc.GetDataTable(strSQL)
				If dt.Rows.Count > 0 Then
					If Not IsDBNull(dt.Rows(0)("NextSequenceNumber")) Then
						strReceipt_Name &= dt.Rows(0)("NextSequenceNumber").ToString.Trim.PadLeft(iNumberLength, "0")
					Else
						strReceipt_Name &= "1".PadLeft(iNumberLength, "0")
					End If
				Else
					strReceipt_Name &= "1".PadLeft(iNumberLength, "0")
				End If

				Return strReceipt_Name
			Catch ex As Exception
				Throw ex
			Finally
				Me.DisposeDT(dt)
			End Try
		End Function


		''*******************************************************************************************************************

		'Public Function GetWarehouseReceiptOpen(ByVal iLocID As Integer, ByVal iCustID As Integer) As DataTable
		'    Dim strSql As String

		'    Try
		'        strSql = "SELECT w.WR_ID,w.WR_Name as 'Receipt Name', concat(Last_Name,',',First_Name,' ',MI_Name) as 'Customer Name',w.Tracking,w.Account,r.RF_ID" & Environment.NewLine
		'        strSql &= "FROM warehouse.warehouse_receipt w" & Environment.NewLine
		'        strSql &= "Left join production.treceivefrom r on r.rf_id=w.rf_id" & Environment.NewLine
		'        strSql &= "Where w.Closed=0" & Environment.NewLine
		'        strSql &= "And w.Cust_ID = " & iCustID & Environment.NewLine
		'        strSql &= "And w.Loc_ID = " & iLocID & Environment.NewLine
		'        strSql &= "Order By w.WR_ID" & Environment.NewLine
		'        Return Me._objDataProc.GetDataTable(strSql)

		'    Catch ex As Exception
		'        Throw ex
		'    End Try
		'End Function

		''*******************************************************************************************************************

		'Public Function GetWarehouseReceiptItems(ByVal iWR_ID) As DataTable
		'    Dim strSql As String

		'    Try
		'        strSql = "SELECT i.*,r.Closed" & Environment.NewLine
		'        strSql &= "FROM warehouse.warehouse_items i" & Environment.NewLine
		'        strSql &= "inner join warehouse.warehouse_receipt r on r.WR_ID=i.WR_ID" & Environment.NewLine
		'        strSql &= "Where r.Closed=0" & Environment.NewLine
		'        strSql &= "And r.WR_ID = " & iWR_ID & Environment.NewLine
		'        strSql &= "Order By i.Serial,i.Pager_Number" & Environment.NewLine
		'        Return Me._objDataProc.GetDataTable(strSql)

		'    Catch ex As Exception
		'        Throw ex
		'    End Try
		'End Function
		''**************************************************************
		'Public Function InsertWarehouseReceiptItems(ByVal Serial As String, _
		'                                      ByVal Pager_Number As String, _
		'                                      ByVal Cap_Code As String, _
		'                                      ByVal RF_ID As Integer, _
		'                                      ByVal Physical_Abuse_ID As Integer, _
		'                                      ByVal Holder_Condition_ID As Integer, _
		'                                      ByVal Case_Condition_ID As Integer, _
		'                                      ByVal BatteryCover_Condition_ID As Integer, _
		'                                      ByVal WB_ID As Integer, _
		'                                      ByVal WR_ID As Integer, _
		'                                      ByVal Labor_Charge As Decimal, _
		'                                      ByVal Model_ID As Integer, _
		'                                      ByVal Freq_ID As Integer, _
		'                                      ByVal BaudRate_ID As Integer, _
		'                                      ByVal Comment As String, _
		'                                      ByVal Management_Type_ID As Integer) As Integer

		'    Dim strSql As String = ""

		'    Try

		'        strSql = "INSERT INTO warehouse.warehouse_items (" & Environment.NewLine
		'        strSql &= "Serial" & Environment.NewLine
		'        strSql &= ", Date_Received" & Environment.NewLine
		'        strSql &= ", Pager_Number" & Environment.NewLine
		'        strSql &= ", Cap_Code" & Environment.NewLine
		'        strSql &= ", RF_ID" & Environment.NewLine
		'        strSql &= ", Physical_Abuse_ID" & Environment.NewLine
		'        strSql &= ", Holder_Condition_ID" & Environment.NewLine
		'        strSql &= ", Case_Condition_ID" & Environment.NewLine
		'        strSql &= ", BatteryCover_Condition_ID" & Environment.NewLine
		'        strSql &= ", WB_ID" & Environment.NewLine
		'        strSql &= ", WR_ID" & Environment.NewLine
		'        strSql &= ", Labor_Charge" & Environment.NewLine
		'        strSql &= ", Model_ID" & Environment.NewLine
		'        strSql &= ", Freq_ID" & Environment.NewLine
		'        strSql &= ", BaudRate_ID" & Environment.NewLine
		'        strSql &= ", Comment" & Environment.NewLine
		'        strSql &= ", Management_Type_ID" & Environment.NewLine
		'        strSql &= ") VALUES ( " & Environment.NewLine
		'        strSql &= "'" & Serial & "'" & Environment.NewLine
		'        strSql &= ", Now()" & Environment.NewLine
		'        strSql &= ",'" & Pager_Number & "'" & Environment.NewLine
		'        strSql &= ",'" & Cap_Code & "'" & Environment.NewLine
		'        strSql &= ", " & RF_ID & Environment.NewLine
		'        strSql &= ", " & Physical_Abuse_ID & Environment.NewLine
		'        strSql &= ", " & Holder_Condition_ID & Environment.NewLine
		'        strSql &= ", " & Case_Condition_ID & Environment.NewLine
		'        strSql &= ", " & BatteryCover_Condition_ID & Environment.NewLine
		'        strSql &= ", " & WB_ID & Environment.NewLine
		'        strSql &= ", " & WR_ID & Environment.NewLine
		'        strSql &= ", " & Labor_Charge & Environment.NewLine
		'        strSql &= ", " & Model_ID & Environment.NewLine
		'        strSql &= ", " & Freq_ID & Environment.NewLine
		'        strSql &= ", " & BaudRate_ID & Environment.NewLine
		'        strSql &= ",'" & Comment & "'" & Environment.NewLine
		'        strSql &= ", " & Management_Type_ID & Environment.NewLine
		'        strSql &= ")"

		'        Return _objDataProc.idTransaction(strSql, "warehouse.warehouse_items")

		'    Catch ex As Exception
		'        Throw ex

		'    End Try

		'End Function

		'******************************************************************

		'Public Function GetWarehouseReceiptByName(ByVal strReceiptName As String, _
		'                        ByVal iLocID As Integer, ByVal iCustID As Integer) As DataTable

		'    Dim strSql As String = ""

		'    Try
		'        strSql = "SELECT *" & Environment.NewLine
		'        strSql &= "FROM warehouse.warehouse_receipt r" & Environment.NewLine
		'        strSql &= "WHERE r.WR_Name= '" & strReceiptName & "'" & Environment.NewLine
		'        strSql &= "And r.Cust_ID = " & iCustID & Environment.NewLine
		'        strSql &= "And r.Loc_ID = " & iLocID & Environment.NewLine
		'        Return Me._objDataProc.GetDataTable(strSql)

		'    Catch ex As Exception
		'        Throw ex
		'    End Try
		'End Function


		''**************************************************************
		'Public Function CloseWarehouseReceipt(ByVal iWR_ID As Integer, ByVal iReceipt_QTY As Integer) As Integer
		'    Dim strSql As String = ""

		'    Try
		'        strSql = "Update Warehouse.warehouse_Receipt" & Environment.NewLine
		'        strSql += "Set Closed = 1,Receipt_QTY= " & iReceipt_QTY & Environment.NewLine
		'        strSql += "Where WR_ID = " & iWR_ID
		'        Return Me._objDataProc.ExecuteNonQuery(strSql)

		'    Catch ex As Exception
		'        Throw ex
		'    End Try
		'End Function

		''**************************************************************
		'Public Function ReopenWarehouseReceipt(ByVal iWR_ID As Integer) As Integer

		'    Dim strSql As String = ""

		'    Try
		'        strSql = "Update Warehouse.warehouse_Receipt" & Environment.NewLine
		'        strSql += "Set Closed = 0 " & Environment.NewLine
		'        strSql += "Where WR_ID = " & iWR_ID
		'        Return Me._objDataProc.ExecuteNonQuery(strSql)

		'    Catch ex As Exception
		'        Throw ex
		'    End Try
		'End Function

		'**************************************************************
		Public Function DeleteWarehouseItem(ByVal iWI_ID As Integer) As Integer
			Dim strSql As String = ""
			Try
				strSql = "Delete From Warehouse.warehouse_items" & Environment.NewLine
				strSql += "Where WI_ID = " & iWI_ID
				Return Me._objDataProc.ExecuteNonQuery(strSql)

			Catch ex As Exception
				Throw ex
			End Try
		End Function

		''**************************************************************
		'Public Function ClearWarehouseItemBoxID(ByVal iWI_ID As Integer) As Integer

		'    Dim strSql As String = ""

		'    Try

		'        strSql = "Update Warehouse.warehouse_items" & Environment.NewLine
		'        strSql += "Set WB_ID =0" & Environment.NewLine
		'        strSql += "Where WI_ID = " & iWI_ID
		'        Return Me._objDataProc.ExecuteNonQuery(strSql)

		'    Catch ex As Exception
		'        Throw ex
		'    End Try
		'End Function


		''**************************************************************
		'Public Function UpdateWarehouseItemBoxID(ByVal iWI_ID As Integer, ByVal iWB_ID As Integer) As Integer

		'    Dim strSql As String = ""

		'    Try

		'        strSql = "Update Warehouse.warehouse_items" & Environment.NewLine
		'        strSql += "Set WB_ID = " & iWB_ID & Environment.NewLine
		'        strSql += "Where WI_ID = " & iWI_ID
		'        Return Me._objDataProc.ExecuteNonQuery(strSql)

		'    Catch ex As Exception
		'        Throw ex

		'    End Try


		'End Function

		'**************************************************************
		Public Function UpdateWarehouseItemBoxIDByWRID(ByVal iWR_ID As Integer, ByVal iWB_ID As Integer) As Integer
			Dim strSql As String = ""

			Try
				strSql = "Update Warehouse.warehouse_items" & Environment.NewLine
				strSql += "Set WB_ID = " & iWB_ID & Environment.NewLine
				strSql += "Where WR_ID = " & iWR_ID
				Return Me._objDataProc.ExecuteNonQuery(strSql)

			Catch ex As Exception
				Throw ex

			End Try
		End Function

		''**************************************************************
		'Public Function CloseWarehouseBox(ByVal iWB_ID As Integer, ByVal iBox_QTY As Integer) As Integer

		'    Dim strSql As String = ""

		'    Try

		'        strSql = "Update Warehouse.warehouse_Box" & Environment.NewLine
		'        strSql += "Set Closed = 1,Box_QTY = " & iBox_QTY & Environment.NewLine
		'        strSql += "Where WB_ID = " & iWB_ID
		'        Return Me._objDataProc.ExecuteNonQuery(strSql)

		'    Catch ex As Exception
		'        Throw ex
		'    End Try

		'End Function

		''******************************************************************



#End Region
#Region "Aquis Transfer From WHIP To Production"

#End Region
#Region "Label"

		''******************************************************************

		'Public Function Label_GetLabelInfoByID(ByVal WI_ID As Integer) As DataTable

		'    Dim strsql As String = ""
		'    Dim dt As DataTable

		'    Try

		'        strsql = "SELECT w.*,m.Model_Desc,f.freq_number,b.baud_number,r.Closed as WR_Closed" & Environment.NewLine
		'        strsql &= "FROM warehouse.warehouse_items w" & Environment.NewLine
		'        strsql &= "Left join warehouse.warehouse_receipt r on r.wr_id=w.wr_id" & Environment.NewLine
		'        strsql &= "Left join Production.tmodel m on m.model_id=w.model_id" & Environment.NewLine
		'        strsql &= "Left join Production.lfrequency f on f.freq_id=w.freq_id" & Environment.NewLine
		'        strsql &= "Left join Production.lbaud b on b.baud_id=w.baudrate_id" & Environment.NewLine
		'        strsql &= "Where w.wi_id=" & WI_ID & ";" & Environment.NewLine

		'        dt = _objDataProc.GetDataTable(strsql)

		'        Return dt
		'    Catch ex As Exception
		'        Throw ex
		'    Finally
		'        PSS.Data.Buisness.Generic.DisposeDT(dt)

		'    End Try
		'End Function
		''******************************************************************
		'Public Function Label_GetLabelInfoBySerial(ByVal strSerial As String) As DataTable

		'    Dim strsql As String = ""
		'    Dim dt As DataTable

		'    Try

		'        strsql = "SELECT w.*,m.Model_Desc,f.freq_number,b.baud_number,r.Closed as WR_Closed" & Environment.NewLine
		'        strsql &= "FROM warehouse.warehouse_items w" & Environment.NewLine
		'        strsql &= "Left join warehouse.warehouse_receipt r on r.wr_id=w.wr_id" & Environment.NewLine
		'        strsql &= "Left join Production.tmodel m on m.model_id=w.model_id" & Environment.NewLine
		'        strsql &= "Left join Production.lfrequency f on f.freq_id=w.freq_id" & Environment.NewLine
		'        strsql &= "Left join Production.lbaud b on b.baud_id=w.baudrate_id" & Environment.NewLine
		'        strsql &= "Where w.Serial='" & strSerial & "';" & Environment.NewLine

		'        dt = _objDataProc.GetDataTable(strsql)

		'        Return dt
		'    Catch ex As Exception
		'        Throw ex
		'    Finally
		'        PSS.Data.Buisness.Generic.DisposeDT(dt)

		'    End Try
		'End Function
		'******************************************************************
		Public Function Label_GetLabelInfoByPagerTel(ByVal strPagerTel As String) As DataTable

			Dim strsql As String = ""
			Dim dt As DataTable

			Try

				strsql = "SELECT w.*,m.Model_Desc,f.freq_number,b.baud_number,r.Closed as WR_Closed" & Environment.NewLine
				strsql &= "FROM warehouse.warehouse_items w" & Environment.NewLine
				strsql &= "Left join warehouse.warehouse_receipt r on r.wr_id=w.wr_id" & Environment.NewLine
				strsql &= "Left join Production.tmodel m on m.model_id=w.model_id" & Environment.NewLine
				strsql &= "Left join Production.lfrequency f on f.freq_id=w.freq_id" & Environment.NewLine
				strsql &= "Left join Production.lbaud b on b.baud_id=w.baudrate_id" & Environment.NewLine
				strsql &= "Where w.Pager_Number='" & strPagerTel & "';" & Environment.NewLine

				dt = _objDataProc.GetDataTable(strsql)

				Return dt
			Catch ex As Exception
				Throw ex
			Finally
				PSS.Data.Buisness.Generic.DisposeDT(dt)

			End Try
		End Function

		''******************************************************************
		'Public Function Label_GetLabelInfoBySerialOrPager(ByVal strSerialPager As String) As DataTable

		'    Dim strsql As String = ""
		'    Dim dt As DataTable

		'    Try

		'        strsql = "SELECT w.*,m.Model_Desc,f.freq_number,b.baud_number,r.Closed as WR_Closed" & Environment.NewLine
		'        strsql &= "FROM warehouse.warehouse_items w" & Environment.NewLine
		'        strsql &= "Left join warehouse.warehouse_receipt r on r.wr_id=w.wr_id" & Environment.NewLine
		'        strsql &= "Left join Production.tmodel m on m.model_id=w.model_id" & Environment.NewLine
		'        strsql &= "Left join Production.lfrequency f on f.freq_id=w.freq_id" & Environment.NewLine
		'        strsql &= "Left join Production.lbaud b on b.baud_id=w.baudrate_id" & Environment.NewLine
		'        strsql &= "Where w.Serial='" & strSerialPager & "';" & Environment.NewLine

		'        dt = _objDataProc.GetDataTable(strsql)

		'        If dt.Rows.Count < 1 Then
		'            strsql = "SELECT w.*,m.Model_Desc,f.freq_number,b.baud_number,r.Closed as WR_Closed" & Environment.NewLine
		'            strsql &= "FROM warehouse.warehouse_items w" & Environment.NewLine
		'            strsql &= "Left join warehouse.warehouse_receipt r on r.wr_id=w.wr_id" & Environment.NewLine
		'            strsql &= "Left join Production.tmodel m on m.model_id=w.model_id" & Environment.NewLine
		'            strsql &= "Left join Production.lfrequency f on f.freq_id=w.freq_id" & Environment.NewLine
		'            strsql &= "Left join Production.lbaud b on b.baud_id=w.baudrate_id" & Environment.NewLine
		'            strsql &= "Where w.Pager_Number='" & strSerialPager & "';" & Environment.NewLine

		'            dt = _objDataProc.GetDataTable(strsql)

		'        End If

		'        Return dt
		'    Catch ex As Exception
		'        Throw ex
		'    Finally
		'        PSS.Data.Buisness.Generic.DisposeDT(dt)

		'    End Try
		'End Function

		' '******************************************************************

		'Public Function Label_AquisReceivingLabel(ByVal strModel As String, _
		'                                   ByVal strFreq As String, _
		'                                   ByVal strBaudRate As String, _
		'                                   ByVal strSerial As String _
		'                                   ) As Integer
		'    Dim strsql As String = ""
		'    Dim objRpt As ReportDocument
		'    Dim dt As DataTable
		'    Dim objDataProc As DBQuery.DataProc

		'    Try



		'        strsql = "Select '" & strModel & "' AS Model, '" & strFreq & "' AS Freq, '" & strBaudRate & "' AS BaudRate, " & Environment.NewLine
		'        strsql &= " '" & strSerial & "' AS Serial" & Environment.NewLine
		'        strsql &= "From warehouse.warehouse_items limit 1;"

		'        objRpt = New ReportDocument()

		'        With objRpt
		'            .Load(Me._strRptPath & Me._strAquisReceivingRptName)
		'            dt = _objDataProc.GetDataTable(strsql)
		'            If Not IsNothing(dt) Then .SetDataSource(dt)
		'            .PrintToPrinter(1, True, 0, 0)
		'        End With
		'    Catch ex As Exception
		'        Throw ex
		'    Finally
		'        PSS.Data.Buisness.Generic.DisposeDT(dt)
		'        GC.Collect()
		'        GC.WaitForPendingFinalizers()
		'    End Try
		'End Function

		''******************************************************************
		'Public Function Label_AquisBoxLabel(ByVal strBoxName As String, _
		'                                    ByVal strModel As String, _
		'                                   ByVal strFreq As String, _
		'                                   ByVal strBaudRate As String, _
		'                                   ByVal strQty As String _
		'                                   ) As Integer
		'    Dim strsql As String = ""
		'    Dim objRpt As ReportDocument
		'    Dim dt As DataTable

		'    Dim objDataProc As DBQuery.DataProc
		'    Dim R1 As DataRow

		'    Try

		'        strsql = "Select '" & strBoxName & "' AS Box_Name,'" & strModel & "' AS Model, '" & strFreq & "' AS Freq, '" & strBaudRate & "' AS BaudRate, " & Environment.NewLine
		'        strsql &= " '" & strQty & "' AS Quantity" & Environment.NewLine
		'        strsql &= "From warehouse.warehouse_items limit 1;"
		'        objRpt = New ReportDocument()

		'        With objRpt
		'            .Load(Me._strRptPath & Me._strAquisBoxRptName)
		'            dt = _objDataProc.GetDataTable(strsql)
		'            If Not IsNothing(dt) Then .SetDataSource(dt)
		'            .PrintToPrinter(1, True, 0, 0)
		'        End With
		'    Catch ex As Exception
		'        Throw ex
		'    Finally
		'        PSS.Data.Buisness.Generic.DisposeDT(dt)
		'        GC.Collect()
		'        GC.WaitForPendingFinalizers()
		'    End Try
		'End Function

		''******************************************************************
		'Public Function Label_GetLabelInfoByBoxName(ByVal strBoxName As String) As DataTable

		'    Dim strsql As String = ""
		'    Dim dt As DataTable

		'    Try

		'        strsql = "SELECT w.*,m.Model_Desc,f.freq_number,b.baud_number,m.Manuf_ID" & Environment.NewLine
		'        strsql &= "FROM warehouse.warehouse_box w" & Environment.NewLine
		'        strsql &= "Left join Production.tmodel m on m.model_id=w.model_id" & Environment.NewLine
		'        strsql &= "Left join Production.lfrequency f on f.freq_id=w.freq_id" & Environment.NewLine
		'        strsql &= "Left join Production.lbaud b on b.baud_id=w.baudrate_id" & Environment.NewLine
		'        strsql &= "Where Box_Name = '" & strBoxName & "'" & Environment.NewLine

		'        dt = _objDataProc.GetDataTable(strsql)

		'        Return dt
		'    Catch ex As Exception
		'        Throw ex
		'    Finally
		'        PSS.Data.Buisness.Generic.DisposeDT(dt)

		'    End Try
		'End Function
		''******************************************************************

		'Public Function Label_GetLabelInfoByBoxID(ByVal WB_ID As String) As DataTable

		'    Dim strsql As String = ""
		'    Dim dt As DataTable

		'    Try

		'        strsql = "SELECT w.*,m.Model_Desc,f.freq_number,b.baud_number,m.Manuf_ID" & Environment.NewLine
		'        strsql &= "FROM warehouse.warehouse_box w" & Environment.NewLine
		'        strsql &= "Left join Production.tmodel m on m.model_id=w.model_id" & Environment.NewLine
		'        strsql &= "Left join Production.lfrequency f on f.freq_id=w.freq_id" & Environment.NewLine
		'        strsql &= "Left join Production.lbaud b on b.baud_id=w.baudrate_id" & Environment.NewLine
		'        strsql &= "Where WB_ID = " & WB_ID & Environment.NewLine

		'        dt = _objDataProc.GetDataTable(strsql)

		'        Return dt
		'    Catch ex As Exception
		'        Throw ex
		'    Finally
		'        PSS.Data.Buisness.Generic.DisposeDT(dt)

		'    End Try
		'End Function
		''******************************************************************



#End Region
#Region "Document Handler"

		'Public Function MoveRecDocuments(ByVal iWR_ID) As Boolean
		'    'Move receive documents to network location, delete local document after moved.

		'    Dim Di As Directory
		'    Dim strSaveACopyToDir As String = Me.AquisRecDocNet + "WR_ID_" + CStr(iWR_ID)

		'    Dim strFileName As String
		'    strFileName = Dir(Me.AquisRecDocLoc, FileAttribute.Normal)   ' Retrieve the first entry.

		'    If strFileName = "" Then
		'        Exit Function
		'    Else
		'        Di.CreateDirectory(strSaveACopyToDir)
		'        strSaveACopyToDir += "\"

		'        Do While strFileName <> ""   ' Start the loop.
		'            If File.Exists(Me.AquisRecDocLoc & strFileName) = True Then

		'                ''***********************************
		'                ''Save a copy to network folder
		'                ''***********************************
		'                If strSaveACopyToDir.Trim.Length > 0 AndAlso Directory.Exists(strSaveACopyToDir) = True Then
		'                    File.Copy(Me.AquisRecDocLoc & strFileName, strSaveACopyToDir & strFileName)
		'                End If
		'                ''***********************************
		'                ''Delete local file
		'                ''***********************************
		'                File.Delete(Me.AquisRecDocLoc & strFileName)

		'                ''***********************************
		'                ''Get next file name in directory
		'                ''***********************************
		'                strFileName = Dir()   ' Get next entry.
		'            End If
		'        Loop
		'    End If
		'End Function

		''******************************************************************
		'Public Function IsThereAReceiveDoc() As Boolean
		'    'Check receive documents has been scan 

		'    Dim strFileName As String
		'    strFileName = Dir(Me.AquisRecDocLoc, FileAttribute.Normal)   ' Retrieve the first entry.

		'    If strFileName = "" Then
		'        If MessageBox.Show("The receive documents has not been scanned.  Are you sure you want to proceed without document ? Click on 'No' to cancel and scan the document then retry.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
		'            Return False
		'        Else
		'            'THERE IS NO DOCUMENT TO SCAN
		'            'Operator choose not to scan document and continue.
		'            Return True
		'        End If

		'    Else
		'        Return True
		'    End If
		'End Function

#End Region
#Region "Report"
		''******************************************************************
		'Public Function ReportReceiptDetails(ByVal strFromShipDate As String, _
		'                                        ByVal strToShipDate As String) As Integer
		'    Dim objGeneric As New PSS.Data.Buisness.Generic()
		'    Dim strSql As String = ""
		'    Dim dt As DataTable

		'    Try
		'        strSql = "SELECT  i.Serial, i.Labor_Charge as 'Labor Charge',b.Box_Name,r.wr_Name as 'Receipt Name',r.Receipt_Date, r.Tracking" & Environment.NewLine
		'        strSql &= ",concat(f.First_Name,' ',f.Last_Name,' ',f.MI_Name) as 'Received From'" & Environment.NewLine
		'        strSql &= ",m.Model_Desc,lf.freq_Number as 'Freq',lb.baud_Number as 'Baud',u.user_fullname as 'Received By',lc.Dcode_Ldesc as 'Management Type'" & Environment.NewLine
		'        'strSql &= ",i.WR_ID,i.WB_ID,i.WI_ID,i.Model_ID,i.Freq_ID,i.BaudRate_ID" & Environment.NewLine
		'        strSql &= "FROM warehouse.warehouse_items i" & Environment.NewLine
		'        strSql &= "Left join warehouse.warehouse_receipt r on r.wr_id = i.wr_id" & Environment.NewLine
		'        strSql &= "Left join warehouse.warehouse_box b on b.wb_id = i.wb_id" & Environment.NewLine
		'        strSql &= "Inner join treceivefrom f on f.rf_id=r.rf_id" & Environment.NewLine
		'        strSql &= "Inner join tmodel m on m.model_id=i.model_id" & Environment.NewLine
		'        strSql &= "Inner join lfrequency lf on lf.freq_id=i.freq_id" & Environment.NewLine
		'        strSql &= "Inner join lbaud lb on lb.baud_id=i.baudRate_id" & Environment.NewLine
		'        strSql &= "Inner join security.tusers u on u.user_id=r.user_id" & Environment.NewLine
		'        strSql &= "Inner join lcodesdetail lc on lc.Dcode_id = i.Management_Type_id" & Environment.NewLine
		'        strSql &= "Where r.Receipt_Date >= '" & strFromShipDate & "' And r.Receipt_Date <= '" & strToShipDate & "'" & Environment.NewLine
		'        strSql &= "Order By r.wr_Name,i.serial;" & Environment.NewLine

		'        dt = Me._objDataProc.GetDataTable(strSql)

		'        If dt.Rows.Count = 0 Then
		'            Throw New Exception("No record found for this report.")
		'        Else
		'            objGeneric.CreateExelReport(dt)
		'        End If
		'        Return dt.Rows.Count
		'    Catch ex As Exception
		'        Throw ex
		'    Finally
		'        objGeneric = Nothing
		'        If Not IsNothing(dt) Then
		'            dt.Dispose()
		'            dt = Nothing
		'        End If
		'    End Try

		'End Function
		''******************************************************************
		'Public Function ReportReceiptSummary(ByVal strFromShipDate As String, _
		'                                        ByVal strToShipDate As String) As Integer
		'    Dim objGeneric As New PSS.Data.Buisness.Generic()
		'    Dim strSql As String = ""
		'    Dim dt As DataTable

		'    Try
		'        strSql = "SELECT  distinct b.Box_Name as 'Box Name',b.Box_QTY as Qty,r.wr_Name as 'Receipt Name'" & Environment.NewLine
		'        strSql &= ",r.Receipt_Date as 'Received Date', r.Tracking" & Environment.NewLine
		'        strSql &= ",concat(f.First_Name,' ',f.Last_Name,' ',f.MI_Name) as 'Received From'" & Environment.NewLine
		'        strSql &= ",m.Model_Desc as Model,lf.freq_Number as 'Freq',lb.baud_Number as 'Baud',u.user_fullname as 'Received By',lc.Dcode_Ldesc as 'Management Type'" & Environment.NewLine
		'        strSql &= "FROM warehouse.warehouse_items i" & Environment.NewLine
		'        strSql &= "Inner join warehouse.warehouse_receipt r on r.wr_id = i.wr_id" & Environment.NewLine
		'        strSql &= "Inner join warehouse.warehouse_box b on b.wb_id = i.wb_id" & Environment.NewLine
		'        strSql &= "Inner join treceivefrom f on f.rf_id=r.rf_id" & Environment.NewLine
		'        strSql &= "Inner join tmodel m on m.model_id=i.model_id" & Environment.NewLine
		'        strSql &= "Inner join lfrequency lf on lf.freq_id=i.freq_id" & Environment.NewLine
		'        strSql &= "Inner join lbaud lb on lb.baud_id=i.baudRate_id" & Environment.NewLine
		'        strSql &= "Inner join security.tusers u on u.user_id=r.user_id" & Environment.NewLine
		'        strSql &= "Inner join lcodesdetail lc on lc.Dcode_id = i.Management_Type_id" & Environment.NewLine
		'        strSql &= "Where r.Receipt_Date >= '" & strFromShipDate & "' And r.Receipt_Date <= '" & strToShipDate & "'" & Environment.NewLine
		'        strSql &= "Order By b.box_Name;" & Environment.NewLine

		'        dt = Me._objDataProc.GetDataTable(strSql)

		'        If dt.Rows.Count = 0 Then
		'            Throw New Exception("No record found for this report.")
		'        Else
		'            objGeneric.CreateExelReport(dt)
		'        End If
		'        Return dt.Rows.Count
		'    Catch ex As Exception
		'        Throw ex
		'    Finally
		'        objGeneric = Nothing
		'        If Not IsNothing(dt) Then
		'            dt.Dispose()
		'            dt = Nothing
		'        End If
		'    End Try

		'End Function

		''******************************************************************
		'Public Function ReportWarehouseInventoryItems() As Integer
		'    Dim objGeneric As New PSS.Data.Buisness.Generic()
		'    Dim strSql As String = ""
		'    Dim dt As DataTable

		'    Try
		'        strSql = "SELECT b.Box_name,m.Model_Desc as Model,lf.freq_Number as 'Freq',lb.baud_Number as 'Baud', count(WI_ID) as Qty" & Environment.NewLine
		'        strSql &= "FROM warehouse.warehouse_items i" & Environment.NewLine
		'        strSql &= "Left join warehouse.warehouse_receipt r on r.wr_id = i.wr_id" & Environment.NewLine
		'        strSql &= "Left join warehouse.warehouse_box b on b.wb_id = i.wb_id" & Environment.NewLine
		'        strSql &= "inner join treceivefrom f on f.rf_id=r.rf_id" & Environment.NewLine
		'        strSql &= "inner join tmodel m on m.model_id=i.model_id" & Environment.NewLine
		'        strSql &= "inner join lfrequency lf on lf.freq_id=i.freq_id" & Environment.NewLine
		'        strSql &= "inner join lbaud lb on lb.baud_id=i.baudRate_id" & Environment.NewLine
		'        strSql &= "inner join security.tusers u on u.user_id=r.user_id" & Environment.NewLine
		'        strSql &= "Where i.Device_ID < 1" & Environment.NewLine
		'        strSql &= "Group By m.Model_Desc,lf.freq_Number,lb.baud_Number" & Environment.NewLine
		'        strSql &= "order by m.Model_Desc,lf.freq_Number,lb.baud_Number;" & Environment.NewLine

		'        dt = Me._objDataProc.GetDataTable(strSql)

		'        If dt.Rows.Count = 0 Then
		'            Throw New Exception("No record found for this report.")
		'        Else
		'            objGeneric.CreateExelReport(dt)
		'        End If
		'        Return dt.Rows.Count
		'    Catch ex As Exception
		'        Throw ex
		'    Finally
		'        objGeneric = Nothing
		'        If Not IsNothing(dt) Then
		'            dt.Dispose()
		'            dt = Nothing
		'        End If
		'    End Try

		'End Function
		''******************************************************************


#End Region
#Region "Misc"

		'******************************************************************
        Public Function getOtherCustomers(Optional ByVal arrListCustIDs As ArrayList = Nothing) As String
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim custIDs As String = ""
            Dim i As Integer = 0
            Dim strCustIDs() As String

            Try
                strSql = "SELECT *" & Environment.NewLine
                strSql &= "FROM exceptioncriteria" & Environment.NewLine
                strSql &= "WHERE Description = 'AMS_OTHER_CUSTOMERS';"

                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    custIDs = dt.Rows(0).Item("CustIDs")
                    If custIDs.Trim.Length > 0 Then
                        strCustIDs = custIDs.Split(New Char() {","c})
                        For i = 0 To strCustIDs.Length - 1
                            arrListCustIDs.Add(strCustIDs(i))
                        Next
                    End If
                    Return custIDs
                Else
                    Return ""
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function getPagerInfoBySerial(ByVal iCustID As Integer, ByVal iLocID As Integer _
          , ByVal Serial As String) As DataTable
            Dim objGeneric As New PSS.Data.Buisness.Generic()
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT *" & Environment.NewLine
                strSql &= "FROM warehouse.warehouse_items i" & Environment.NewLine
                strSql &= "Left join warehouse.warehouse_receipt r on r.wr_id = i.wr_id" & Environment.NewLine
                strSql &= "Left join warehouse.warehouse_box b on b.wb_id = i.wb_id" & Environment.NewLine
                strSql &= "Inner join treceivefrom f on f.rf_id=r.rf_id" & Environment.NewLine
                strSql &= "Inner join tmodel m on m.model_id=i.model_id" & Environment.NewLine
                strSql &= "Inner join lfrequency lf on lf.freq_id=i.freq_id" & Environment.NewLine
                strSql &= "Inner join lbaud lb on lb.baud_id=i.baudRate_id" & Environment.NewLine
                strSql &= "Inner join security.tusers u on u.user_id=r.user_id" & Environment.NewLine
                strSql &= "Inner join lcodesdetail lc on lc.Dcode_id = i.Management_Type_id" & Environment.NewLine
                strSql &= "Where r.Cust_ID=" & iCustID & " & Environment.NewLine"
                strSql &= "And r.Loc_ID=" & iLocID & Environment.NewLine
                strSql &= "And i.Serial='" & Serial & "';" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt

            Catch ex As Exception
                Throw ex
            Finally
                objGeneric = Nothing
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try

        End Function

        '******************************************************************
        Public Function getPagerInfoByDeviceID(ByVal iCustID As Integer, ByVal iLocID As Integer _
          , ByVal DeviceID As Integer) As DataTable
            Dim objGeneric As New PSS.Data.Buisness.Generic()
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                ' strSql = "SELECT * " & Environment.NewLine
                strSql = "SELECT i.WI_ID,i.Device_ID,i.Serial,i.Date_Received,i.Pager_Number,i.Cap_Code,i.RF_ID,i.Physical_Abuse_ID,i.Holder_Condition_ID,i.Case_Condition_ID,i.BatteryCover_Condition_ID,i.WB_ID,i.WR_ID,i.Labor_Charge," & Environment.NewLine
                strSql &= "i.Model_ID,i.Freq_ID,i.BaudRate_ID,i.Comment,i.Management_Type_ID,r.WR_Name,r.SC_ID,r.Tracking,r.Account,r.Receipt_Date,r.Receipt_QTY,r.Closed,r.User_ID,r.Cust_ID,r.Loc_ID,r.RMA,b.Box_Name," & Environment.NewLine
                strSql &= "b.Box_CreatedDate,b.Box_ShipDate,b.Box_QTY,f.Last_Name,f.First_Name,f.MI_Name,f.Address1,f.Address2,f.City,f.Zip,f.State_ID,f.Cntry_ID,f.Tel,f.Fax,f.Email,f.Company_Name,m.Model_Desc," & Environment.NewLine
                strSql &= "m.Model_Type,m.Model_MotoSku,m.Model_Tier,m.Model_Flat,m.Model_HexSN,m.Manuf_ID,m.Prod_ID,m.ProdGrp_ID,m.ASCPrice_ID,m.RptGrp_ID,m.Conv_ID,m.Dcode_ID,m.Model_GSM,m.Accessory," & Environment.NewLine
                strSql &= "m.UPC_Code,m.UpdateDate,m.Weight_Factor,m.GoalHour,m.PiecesPerHour,m.PiecePoint,m.PointGoal, m.Model_UnlockCode,m.CustomModelGroup,m.Model_Timestamp,m.Model_Volume," & Environment.NewLine
                strSql &= "m.MRP_Status,m.MRP_Hide,m.MRP_Group,m.ManufModelNumber,lf.freq_Number,lf.freq_MotoCode,lb.baud_id,lb.baud_Number,lb.baud_MotoCode,lb.baud_LabelCode,lb.am_format,lb.am_format_2way," & Environment.NewLine
                strSql &= "u.user_name,u.user_pass,u.user_fullname,u.EmployeeNo,u.QCStamp,u.tech_id,u.shift_id,u.is_user_refurber,u.user_inactive,u.ExemptFlag,u.OTFlag,u.AdminUser,u.LastLogonMachine,u.group_id," & Environment.NewLine
                strSql &= "u.TechRate,u.GlobalAccess,lc.Dcode_Sdesc,lc.Dcode_Ldesc,lc.Dcode_L2desc,lc.Dcode_Inactive,lc.Dcode_ChrgCust,lc.Dcode_PriorityLvl,lc.Dcode_Critical,lc.Mcode_Id,lc.ReturnToBucket" & Environment.NewLine
                strSql &= "FROM warehouse.warehouse_items i" & Environment.NewLine
                strSql &= "Left join warehouse.warehouse_receipt r on r.wr_id = i.wr_id" & Environment.NewLine
                strSql &= "Left join warehouse.warehouse_box b on b.wb_id = i.wb_id" & Environment.NewLine
                strSql &= "Inner join treceivefrom f on f.rf_id=r.rf_id" & Environment.NewLine
                strSql &= "Inner join tmodel m on m.model_id=i.model_id" & Environment.NewLine
                strSql &= "Inner join lfrequency lf on lf.freq_id=i.freq_id" & Environment.NewLine
                strSql &= "Inner join lbaud lb on lb.baud_id=i.baudRate_id" & Environment.NewLine
                strSql &= "Inner join security.tusers u on u.user_id=r.user_id" & Environment.NewLine
                strSql &= "Inner join lcodesdetail lc on lc.Dcode_id = i.Management_Type_id" & Environment.NewLine
                strSql &= "Where r.Cust_ID=" & iCustID & Environment.NewLine
                strSql &= "And r.Loc_ID=" & iLocID & Environment.NewLine
                strSql &= "And i.Device_ID=" & DeviceID & ";" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt

            Catch ex As Exception
                Throw ex
            Finally
                objGeneric = Nothing
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try

        End Function
        '********************************************************************************************************
        Public Function IsCapCodeExist(ByVal LocID As Integer, ByVal strCapcode As String) As Boolean

            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT *" & Environment.NewLine
                strSql &= "FROM tmessdata m" & Environment.NewLine
                strSql &= "inner join tdevice t on t.device_id=m.device_id" & Environment.NewLine
                strSql &= "Where t.loc_ID =" & LocID & Environment.NewLine
                strSql &= "And m.capcode='" & strCapcode & "'" & Environment.NewLine
                strSql &= ";" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                Throw ex
            Finally
                Me.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function SaveMessagingFreqCapcodes(ByVal iCustID As Integer, ByVal iUserID As Integer, ByVal iFreqID As Integer, _
           ByVal iAvailable As Integer, ByVal strCapCode As String, _
           ByVal strDTime As String) As Integer
            Dim strSQL As String
            Dim dt As DataTable

            Try
                strCapCode = strCapCode.Replace("'", "''")

                strSQL = "SELECT * FROM tmessfreqcapcodepool WHERE Cust_ID=" & iCustID & " AND Available= 1" & " AND CapCode='" & strCapCode & "'"
                dt = Me._objDataProc.GetDataTable(strSQL)

                'if this capcode is open for any freq, don't save
                If Not dt.Rows.Count > 0 Then
                    strSQL = "INSERT INTO tmessfreqcapcodepool (Freq_ID,CapCode,Available,Cust_ID,UserID,UpdateDatetime)" & _
                       " VALUES (" & iFreqID & ",'" & strCapCode & "'," & iAvailable & "," & iCustID & "," & iUserID & ",'" & strDTime & "')"

                    Return Me._objDataProc.ExecuteNonQuery(strSQL)
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '******************************************************************
        Public Function GetMessagingFreqCapcodes(ByVal iCustID As Integer, ByVal iAvailable As Integer) As DataTable
            Dim strSQL As String

            Try

                strSQL = "SELECT B.Freq_Number,A.CapCode,If(A.Available=1,'Yes','No') AS Available,A.UpdateDatetime,C.user_fullname AS UpdateUser, A.Freq_ID,A.Cust_ID,A.UserID,A.FCP_ID FROM tmessfreqcapcodepool A" & Environment.NewLine
                strSQL &= " INNER JOIN lFrequency B ON A.Freq_ID=B.Freq_ID" & Environment.NewLine
                strSQL &= " LEFT JOIN security.tusers C ON A.UserID=C.User_ID" & Environment.NewLine
                strSQL &= " WHERE Cust_ID =" & iCustID & " AND Available= " & iAvailable

                Return Me._objDataProc.GetDataTable(strSQL)

            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '******************************************************************
        Public Function GetMessagingDuplicatedFreqCapcodes(ByVal iCustID As Integer, ByVal iAvailable As Integer, _
           ByVal iFreqID As Integer, ByVal strCapCode As String, _
           ByVal bSameFreq As Boolean) As DataTable
            Dim strSQL As String
            strCapCode = strCapCode.Replace("'", "''")

            Try

                strSQL &= " SELECT B.Freq_Number,A.CapCode, A.Freq_ID,A.Cust_ID,A.FCP_ID" & Environment.NewLine
                strSQL &= " FROM tmessfreqcapcodepool A" & Environment.NewLine
                strSQL &= " INNER JOIN lFrequency B ON A.Freq_ID=B.Freq_ID" & Environment.NewLine
                strSQL &= " WHERE Cust_ID =" & iCustID & " AND Available=" & iAvailable & Environment.NewLine
                If bSameFreq Then
                    strSQL &= " AND A.Freq_ID=" & iFreqID & " AND CapCode='" & strCapCode & "';" & Environment.NewLine
                Else
                    strSQL &= " AND A.Freq_ID<>" & iFreqID & " AND CapCode='" & strCapCode & "';" & Environment.NewLine
                End If

                Return Me._objDataProc.GetDataTable(strSQL)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function DeleteMessagingFreqCapcodes(ByVal strFCP_IDs As String) As Integer
            Dim strSQL As String
            Try
                strSQL = "DELETE FROM tmessfreqcapcodepool " & Environment.NewLine
                strSQL &= " WHERE FCP_ID in (" & strFCP_IDs & ")"
                Return Me._objDataProc.ExecuteNonQuery(strSQL)

            Catch ex As Exception
                Throw ex
            End Try
        End Function



        Public Function LoadExcelFreqCodeMappingData(ByVal strExcelPathFile As String, _
           ByRef strErrMsg As String) As DataTable
            'Data must be in Excel Sheet 1
            'First row has header names

            Dim HeaderNames As New ArrayList()
            Dim dt As DataTable
            Dim row As DataRow
            Dim objV As Object

            Dim UsedRowsNum1 As Integer = 0, UsedColsNum1 As Integer = 0
            Dim i As Integer = 0, j As Integer = 0, k As Integer = 0, myIndex As Integer
            Dim strColName As String = "", strTmp As String = ""
            Dim strDateTime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

            Dim xlApp As New Excel.Application()
            Dim xlWorkBook As Excel.Workbook = Nothing
            Dim xlWorkSheet1 As Excel.Worksheet = Nothing
            'Dim xlWorkSheet2 As Excel.Worksheet = Nothing

            Try
                'define header names
                HeaderNames.Add("Freq_Number") : HeaderNames.Add("Freq_Code")

                'define table
                dt = New DataTable()
                dt.Columns.Add("RowID", GetType(Integer))
                dt.Columns.Add("Freq_ID", GetType(Integer))
                dt.Columns.Add(HeaderNames(0), GetType(String))
                dt.Columns.Add(HeaderNames(1), GetType(String))
                dt.Columns.Add("Status", GetType(String))
                dt.Columns.Add("UpdateDatetime", GetType(String))

                strErrMsg = ""
                If File.Exists(strExcelPathFile) Then
                    xlWorkBook = xlApp.Workbooks.Open(strExcelPathFile)

                    xlWorkSheet1 = xlWorkBook.Worksheets(1)
                    xlWorkSheet1.Select()
                    UsedRowsNum1 = xlWorkBook.ActiveSheet.UsedRange.Rows.Count()
                    UsedColsNum1 = xlWorkBook.ActiveSheet.UsedRange.Columns.Count()

                    'Get row number util empty cell (first col, rows)
                    For i = 1 To UsedRowsNum1
                        If Microsoft.VisualBasic.IsDBNull(xlWorkSheet1.Cells(i, 1).value) Then       '.Range("A" & i).Value
                            Exit For
                        ElseIf Microsoft.VisualBasic.IsNothing(xlWorkSheet1.Cells(i, 1).value) Then
                            Exit For
                        ElseIf xlWorkSheet1.Cells(i, 1).value Is "" Or xlWorkSheet1.Cells(i, 1).value Is Nothing Then
                            Exit For
                        Else
                            strTmp = xlWorkSheet1.Cells(i, 1).value
                            If strTmp.Trim.Length > 0 Then
                                UsedRowsNum1 = i
                            Else
                                Exit For
                            End If
                        End If
                    Next

                    'Get colmun number until empty cell (first row, cols)
                    Try
                        For j = 1 To UsedColsNum1
                            objV = xlWorkSheet1.Cells(1, j).value
                            If objV Is Nothing Then
                                UsedColsNum1 = j - 1 : Exit For 'if empty, stop
                            End If
                            strTmp = xlWorkSheet1.Cells(1, j).value
                            If Not strTmp.Trim.Length > 0 Then
                                UsedColsNum1 = j - 1 : Exit For 'if spaces, stop
                            End If
                        Next
                    Catch ex As Exception
                    End Try
                    ' MessageBox.Show("UsedRowsNum1 =" & UsedRowsNum1 & "   UsedColsNum1=" & UsedColsNum1)

                    '1. Validate header names:----------------------------------------------------
                    If UsedRowsNum1 > 1 AndAlso UsedColsNum1 >= HeaderNames.Count Then
                        For j = 1 To HeaderNames.Count       'get header names
                            strColName = xlWorkSheet1.Cells(1, j).value
                            If Not HeaderNames.Contains(strColName.Trim) Then
                                strErrMsg = "Invalid header name(s) in Excel file." : Exit Function
                            End If
                        Next       'j
                    Else
                        strErrMsg = "No enough rows or columns  Excel file." : Exit Function
                    End If


                    '3. Load Data---------------------------------------------------------------------------------------------
                    'Load Excdel data into datatable
                    For i = 2 To UsedRowsNum1       'go through each row of the Excelsheet
                        row = dt.NewRow()
                        row("RowID") = i - 1       'col 0
                        row("Freq_ID") = 0
                        For k = 0 To HeaderNames.Count - 1        'each column
                            j = k + 1

                            objV = xlWorkSheet1.Cells(i, j).value
                            If objV Is Nothing Then
                                strErrMsg = "Excel file has no data in cell(" & i & ":" & j & ") ." : Exit Function
                            End If
                            strTmp = xlWorkSheet1.Cells(i, 1).value
                            If Not strTmp.Trim.Length > 0 Then
                                strErrMsg = "Excel file has no data in cell(" & i & ":" & j & ") ." : Exit Function
                            End If

                            row(j + 1) = xlWorkSheet1.Cells(i, j).value
                            If k = HeaderNames.Count - 1 Then
                                row(j + 2) = "Ready to save" : row(j + 3) = strDateTime
                            End If
                        Next       'each column
                        dt.Rows.Add(row)
                    Next       'go through each row of the Excelsheet


                    If Not IsNothing(xlWorkSheet1) Then
                        PSS.Data.Buisness.Generic.NAR(xlWorkSheet1)
                    End If

                    If Not IsNothing(xlWorkBook) Then
                        xlWorkBook.Close(False)
                        PSS.Data.Buisness.Generic.NAR(xlWorkBook)
                    End If
                    If Not IsNothing(xlApp) Then
                        xlApp.Quit()
                        PSS.Data.Buisness.Generic.NAR(xlApp)
                    End If

                    Return dt
                End If

            Catch ex As Exception
                strErrMsg = "Function LoadExcelData: " & ex.ToString
                Return dt
            Finally
                If Not IsNothing(xlWorkSheet1) Then
                    PSS.Data.Buisness.Generic.NAR(xlWorkSheet1)
                End If
                If Not IsNothing(xlWorkBook) Then
                    xlWorkBook.Close(False)
                    PSS.Data.Buisness.Generic.NAR(xlWorkBook)
                End If
                If Not IsNothing(xlApp) Then
                    xlApp.Quit()
                    PSS.Data.Buisness.Generic.NAR(xlApp)
                End If
            End Try

        End Function

        '*******************************************************************************************************************
        Public Function GetFreqID(ByVal strFreqNumber As String) As Integer
            Dim strSql As String
            Dim dt As DataTable

            Try
                strSql = "SELECT * FROM lfrequency WHERE freq_number='" & strFreqNumber.Replace("'", "''") & "';"
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count = 0 Then
                    Return 0
                Else
                    Return dt.Rows(0).Item("Freq_ID")
                End If
                dt = Nothing

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function FreqIDCodeExist(ByVal iCustID As Integer, ByVal iFreqID As Integer, ByVal strFreqCode As String) As Boolean
            Dim strSql As String
            Dim dt As DataTable

            Try
                strSql = "SELECT * FROM tcustomerfreqcodemap" & Environment.NewLine
                strSql &= " WHERE Cust_ID=" & iCustID & " AND (Freq_ID=" & iFreqID & " OR Freq_Code='" & strFreqCode.Replace("'", "''") & "');"

                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count = 0 Then
                    Return False
                Else
                    Return True
                End If
                dt = Nothing

            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '*******************************************************************************************************************
        Public Function SaveGreqIDFreqCodeMapData(ByVal iCustID As Integer, ByVal iFreqID As Integer, _
           ByVal strFreqCode As String, ByVal iUserID As Integer, ByVal strDTime As String) As Integer
            Dim strSql As String
            Dim dt As DataTable

            Try
                strFreqCode = strFreqCode.Replace("'", "''")
                strSql = "INSERT INTO tcustomerfreqcodemap (Cust_ID,Freq_ID,Freq_Code,User_ID,UpdateDateTime)" & Environment.NewLine
                strSql &= " VALUES (" & iCustID & "," & iFreqID & ",'" & strFreqCode & "'," & iUserID & ",'" & strDTime & "');"

                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '*******************************************************************************************************************
        Public Function GetFreqIDFreqCodeMappingData(ByVal iCustID As Integer) As DataTable
            Dim strSql As String
            Try
                strSql = "SELECT D.Cust_Name1 AS 'Customer',A.Freq_Code,B.Freq_Number,A.Freq_ID,C.User_FullName AS 'Updated User'" & Environment.NewLine
                strSql &= " FROM tcustomerfreqcodemap A" & Environment.NewLine
                strSql &= " INNER JOIN lfrequency B ON A.Freq_ID=B.Freq_ID" & Environment.NewLine
                strSql &= " LEFT JOIN security.tusers C ON A.User_ID = C.User_ID" & Environment.NewLine
                strSql &= " INNER JOIN tcustomer D ON A.Cust_ID=D.Cust_ID" & Environment.NewLine
                strSql &= " WHERE A.Cust_ID=" & iCustID & ";" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function getMessagingWIPOwnerData(ByVal strExclWipOwnerIDs As String, ByVal strActiveColName As String, _
          ByVal booAddSelectRow As Boolean) As DataTable
            Dim objGeneric As New PSS.Data.Buisness.Generic()
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim _sb As New StringBuilder()
            Try
                _sb.Append("SELECT * FROM  lwipowner ")
                _sb.Append("WHERE AMS_WipFlow > 0  AND ")
                _sb.Append("WipOwner_ID NOT IN ( 1, 4, 5, 7, 12  ) ")
                _sb.Append("UNION SELECT ")
                _sb.Append("wipowner_id,  ")
                _sb.Append("wipowner_desc, ")
                _sb.Append("ams_wipflow + 200 as ams_wipflow, ")
                _sb.Append("wipset, ")
                _sb.Append("inactive ")
                _sb.Append("FROM lwipowner_set2 ")
                _sb.Append("where wipowner_desc = 'WH' ")
                _sb.Append("ORDER BY AMS_WipFlow; ")
                'strSql = "SELECT * FROM  lwipowner WHERE " & strActiveColName & " > 0 "
                'If strExclWipOwnerIDs.Trim.Length > 0 Then strSql &= " AND WipOwner_ID NOT IN ( " & strExclWipOwnerIDs & " )"
                'strSql &= "ORDER BY " & strActiveColName & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(_sb.ToString())
                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                objGeneric = Nothing
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Function

        '******************************************************************
        Public Function getMessagingWIPOwnerSubLocationData(ByVal strIncludedWIPOwnerIPs As String, ByVal booAddSelectRow As Boolean) As DataTable
            Dim objGeneric As New PSS.Data.Buisness.Generic()
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "select * from  lwipownersubloc where wipowner_ID in (" & strIncludedWIPOwnerIPs & ");" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)

                Return dt

            Catch ex As Exception
                Throw ex
            Finally
                objGeneric = Nothing
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try

        End Function

        '******************************************************************
        Public Function getMessagingCostCenterData(ByVal booAddSelectRow As Boolean) As DataTable
            Dim objGeneric As New PSS.Data.Buisness.Generic()
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "select cc_id,cc_desc from tcostcenter where group_ID=1 and wa_ID=2 and cc_inactive=0;" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)

                Return dt

            Catch ex As Exception
                Throw ex
            Finally
                objGeneric = Nothing
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Function

        Public Function getMessagingWIP_BySN(ByVal strCustomerIDs As String, ByVal strSN As String) As DataTable
            Dim strSql As String = ""

            Try
                strSN = strSN.Replace("'", "''")
                strSql = "select A.Device_SN, D.Model_Desc, C.wipowner_desc" & Environment.NewLine
                strSql &= " , B.wipowner_id, B.wipowner_EntryDt, B.wipowner_id_Old, B.wipownersubloc_id" & Environment.NewLine
                strSql &= " , A.Device_DateRec, A.Device_DateShip, A.Device_ID, A.Tray_ID, A.cc_ID, A.WO_ID, A.Loc_ID " & Environment.NewLine
                strSql &= " , A.Model_ID, A.Pallett_ID, B.MD_ID, if(B.Freq_ID is null, 0, B.Freq_ID) as Freq_ID, B.Baud_ID, B.Capcode " & Environment.NewLine
                strSql &= " , IF( J.wipowner_desc is null, '', J.wipowner_desc) as 'WIP Loc', " & Environment.NewLine
                strSql &= "K.wipownersubloc_desc AS 'WIP Sub Loc', "
                strSql &= "L.cc_desc AS 'Cost Center', "
                strSql &= "IF(M.freq_Number is null, '', M.freq_Number) as freq_Number "
                strSql &= " from tdevice A" & Environment.NewLine
                strSql &= " inner join tmessdata B on A.device_id = B.device_id" & Environment.NewLine
                strSql &= " inner join lwipowner C on B.wipowner_id = C.wipowner_id" & Environment.NewLine
                strSql &= " inner join tmodel D on A.model_ID = D.model_ID" & Environment.NewLine
                strSql &= " inner join tlocation H on A.Loc_ID = H.Loc_ID" & Environment.NewLine
                strSql &= " inner join tcustomer I on H.Cust_ID = I.Cust_ID" & Environment.NewLine
                strSql &= " inner join tworkorder W on A.WO_ID = W.WO_ID" & Environment.NewLine
                strSql &= " left outer join lwipowner J on B.wipowner_id = J.wipowner_id " & Environment.NewLine
                strSql &= " left outer join lwipownersubloc K on B.wipownersubloc_id = K.wipownersubloc_id " & Environment.NewLine
                strSql &= " left outer join tcostcenter L on A.cc_id = L.cc_id " & Environment.NewLine
                strSql &= " left outer join lfrequency M on B.Freq_ID = M.Freq_ID " & Environment.NewLine
                strSql &= " where I.cust_id in (" & strCustomerIDs & ") and A.device_DateShip is null and A.device_SN='" & strSN & "';" & Environment.NewLine

                'strSql = "select A.Device_SN, D.Model_Desc, C.wipowner_desc" & Environment.NewLine
                'strSql &= " , B.wipowner_id, B.wipowner_EntryDt, B.wipowner_id_Old, B.wipownersubloc_id" & Environment.NewLine
                'strSql &= " , A.Device_DateRec, A.Device_DateShip, A.Device_ID, A.Tray_ID, A.cc_ID, A.WO_ID, A.Loc_ID " & Environment.NewLine
                'strSql &= " , A.Model_ID, A.Pallett_ID, B.MD_ID, if(B.Freq_ID is null, 0, B.Freq_ID) as Freq_ID, B.Baud_ID, B.Capcode " & Environment.NewLine
                'strSql &= " , IF( J.wipowner_desc is null, '', J.wipowner_desc) as 'WIP Loc' " & Environment.NewLine
                'strSql &= " , IF( B.wipowner_id = 2 and K.wipownersubloc_desc is not null, K.wipownersubloc_desc, if (B.wipowner_id = 3 and L.cc_desc is not null, L.cc_desc, '') ) as 'WIP Sub Loc' " & Environment.NewLine
                'strSql &= ", IF(M.freq_Number is null, '', M.freq_Number) as freq_Number " & Environment.NewLine
                'strSql &= " from tdevice A" & Environment.NewLine
                'strSql &= " inner join tmessdata B on A.device_id = B.device_id" & Environment.NewLine
                'strSql &= " inner join lwipowner C on B.wipowner_id = C.wipowner_id" & Environment.NewLine
                'strSql &= " inner join tmodel D on A.model_ID = D.model_ID" & Environment.NewLine
                'strSql &= " inner join tlocation H on A.Loc_ID = H.Loc_ID" & Environment.NewLine
                'strSql &= " inner join tcustomer I on H.Cust_ID = I.Cust_ID" & Environment.NewLine
                'strSql &= " inner join tworkorder W on A.WO_ID = W.WO_ID" & Environment.NewLine
                'strSql &= " left outer join lwipowner J on B.wipowner_id = J.wipowner_id " & Environment.NewLine
                'strSql &= " left outer join lwipownersubloc K on B.wipownersubloc_id = K.wipownersubloc_id " & Environment.NewLine
                'strSql &= " left outer join tcostcenter L on A.cc_id = L.cc_id " & Environment.NewLine
                'strSql &= " left outer join lfrequency M on B.Freq_ID = M.Freq_ID " & Environment.NewLine
                'strSql &= " where I.cust_id in (" & strCustomerIDs & ") and A.device_DateShip is null and A.device_SN='" & strSN & "';" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try

        End Function

        '******************************************************************
        Public Function getMessagingWIP_ByTrayID(ByVal strCustomerIDs As String, ByVal iTrayID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "select A.Device_SN, D.Model_Desc, C.wipowner_desc" & Environment.NewLine
                strSql &= " , B.wipowner_id, B.wipowner_EntryDt, B.wipowner_id_Old, B.wipownersubloc_id" & Environment.NewLine
                strSql &= " , A.Device_DateRec, A.Device_DateShip, A.Device_ID, A.Tray_ID, A.cc_ID, A.WO_ID, A.Loc_ID " & Environment.NewLine
                strSql &= " , A.Model_ID, A.Pallett_ID, B.MD_ID, if(B.Freq_ID is null, 0, B.Freq_ID) as Freq_ID, B.Baud_ID, B.Capcode " & Environment.NewLine
                strSql &= " , IF( J.wipowner_desc is null, '', J.wipowner_desc) as 'WIP Loc' " & Environment.NewLine
                strSql &= " , IF( B.wipowner_id = 2 and K.wipownersubloc_desc is not null, K.wipownersubloc_desc, if (B.wipowner_id = 3 and L.cc_desc is not null, L.cc_desc, '') ) as 'WIP Sub Loc' " & Environment.NewLine
                strSql &= ", IF(M.freq_Number is null, '', M.freq_Number) as freq_Number, IF(A.device_DateShip is null, '', A.device_DateShip) as device_DateShip " & Environment.NewLine
                strSql &= " from tdevice A" & Environment.NewLine
                strSql &= " inner join tmessdata B on A.device_id = B.device_id" & Environment.NewLine
                strSql &= " inner join lwipowner C on B.wipowner_id = C.wipowner_id" & Environment.NewLine
                strSql &= " inner join tmodel D on A.model_ID = D.model_ID" & Environment.NewLine
                strSql &= " inner join tlocation H on A.Loc_ID = H.Loc_ID" & Environment.NewLine
                strSql &= " inner join tcustomer I on H.Cust_ID = I.Cust_ID" & Environment.NewLine
                strSql &= " inner join tworkorder W on A.WO_ID = W.WO_ID" & Environment.NewLine
                strSql &= " left outer join lwipowner J on B.wipowner_id = J.wipowner_id " & Environment.NewLine
                strSql &= " left outer join lwipownersubloc K on B.wipownersubloc_id = K.wipownersubloc_id " & Environment.NewLine
                strSql &= " left outer join tcostcenter L on A.cc_id = L.cc_id " & Environment.NewLine
                strSql &= " left outer join lfrequency M on B.Freq_ID = M.Freq_ID " & Environment.NewLine
                strSql &= " where A.Tray_ID = " & iTrayID & " AND I.cust_id in (" & strCustomerIDs & ") " & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function getMessagingWIP_ByDeviceIDs(ByVal strDevice_IDs As String) As DataTable
            Dim objGeneric As New PSS.Data.Buisness.Generic()
            Dim strSql As String = ""
            Dim dt As DataTable

            Try

                strSql = "select A.Device_SN,D.Model_Desc,C.wipowner_desc" & Environment.NewLine
                strSql &= " ,B.wipowner_id,B.wipowner_EntryDt,B.wipowner_id_Old,B.wipownersubloc_id" & Environment.NewLine
                strSql &= " ,A.Device_DateRec,A.Device_DateShip,A.Device_ID,A.Tray_ID,A.CC_ID,A.WO_ID" & Environment.NewLine
                strSql &= " ,A.Model_ID,A.Pallett_ID,B.MD_ID,B.Freq_ID,B.Baud_ID,B.Capcode" & Environment.NewLine
                strSql &= " from tdevice A" & Environment.NewLine
                strSql &= " inner join tmessdata B on A.device_id=B.device_id" & Environment.NewLine
                strSql &= " inner join lwipowner C on B.wipowner_id=C.wipowner_id" & Environment.NewLine
                strSql &= " inner join tmodel D on A.model_ID=D.model_ID" & Environment.NewLine
                strSql &= " inner join tlocation H on A.Loc_ID=H.Loc_ID" & Environment.NewLine
                strSql &= " inner join tcustomer I on H.Cust_ID=I.Cust_ID" & Environment.NewLine
                strSql &= " inner join tworkorder W on A.WO_ID=W.WO_ID" & Environment.NewLine
                strSql &= " where A.device_DateShip is null and A.device_id in (" & strDevice_IDs & ");" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt

            Catch ex As Exception
                Throw ex
            Finally
                objGeneric = Nothing
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try

        End Function

        '******************************************************************
        Public Function UpdateMessagingWIPDeviceTrayID(ByVal strDevice_IDs As String, ByVal iTray_ID As Integer) As Integer
            Dim objGeneric As New PSS.Data.Buisness.Generic()
            Dim strSql As String = ""

            Try

                strSql = "Update tdevice set Tray_ID=" & iTray_ID & " where device_ID in (" & strDevice_IDs & ");"

                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            Finally
                objGeneric = Nothing
            End Try
        End Function

        '******************************************************************
        Public Function UpdateMessagingDeviceCostCenter(ByVal strDevice_IDs As String, ByVal iCC_ID As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "Update tdevice set CC_ID= " & iCC_ID & " where device_ID in (" & strDevice_IDs & ");"

                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetTmessWipLocCount(ByVal iWipownerID As Integer, ByVal iWipownersublocID As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "SELECT COUNT(*) AS Cnt FROM tmessdata INNER JOIN tdevice ON tmessdata.device_ID = tdevice.device_ID WHERE wipowner_id = " & iWipownerID & " AND wipownersubloc_id  = " & iWipownersublocID

                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetTmessWipLocFreqCount(ByVal iWipownerID As Integer, ByVal iWipownersublocID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT tmessdata.Freq_ID, freq_Number, COUNT(*) AS Cnt FROM tmessdata LEFT OUTER JOIN lfrequency ON tmessdata.Freq_ID = lfrequency.Freq_ID " & Environment.NewLine
                strSql &= "WHERE wipowner_id = " & iWipownerID & " And wipownersubloc_id = " & iWipownersublocID & Environment.NewLine
                strSql &= "GROUP BY tmessdata.Freq_ID "

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetMessCustomers(ByVal strCust_IDs As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "Select A.Cust_ID,B.Loc_ID,A.Cust_Name1 As 'Customer'" & Environment.NewLine
                strSql &= " from tcustomer A" & Environment.NewLine
                strSql &= " inner join tlocation B on A.Cust_ID=B.Cust_ID where A.cust_ID in (" & strCust_IDs & ")" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetMessCustomerByCustomerID(ByVal iCust_ID As Integer) As String
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "Select Cust_Name1 As 'Customer'" & Environment.NewLine
                strSql &= " from tcustomer A" & Environment.NewLine
                strSql &= " where cust_ID = " & iCust_ID & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    Return dt.Rows(0).Item("Customer").ToString
                Else
                    Return ""
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetMessModelActiveInactiveData(ByVal iProd_ID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT B.Model_Desc AS 'Model',IF(A.Inactive=1,'No','Yes') AS 'Active'" & Environment.NewLine
                strSql &= " ,IF(A.KeyModel=1,'Yes','No') AS 'Key Model',A.equip_type AS 'Equip Type',D.User_FullName AS 'User'"
                strSql &= " ,A.Updatedatetime AS 'Rec_Date',C.Prod_Desc AS 'Product'" & Environment.NewLine
                strSql &= " ,A.Model_ID,A.Prod_ID,A.Inactive,A.KeyModel,A.User_ID,A.mrs_ID" & Environment.NewLine
                strSql &= " FROM tmodel_rec_status A" & Environment.NewLine
                strSql &= " INNER JOIN tmodel B ON A.model_ID=B.model_ID" & Environment.NewLine
                strSql &= " INNER JOIN lproduct C ON A.prod_ID=C.prod_ID" & Environment.NewLine
                strSql &= " LEFT JOIN security.tusers D ON A.USer_ID=D.User_ID" & Environment.NewLine
                strSql &= " WHERE A.Prod_ID=" & iProd_ID & Environment.NewLine
                strSql &= " ORDER BY A.KeyModel DESC,B.Model_Desc;" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetMessModelData(ByVal iProd_ID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT * from tmodel WHERE prod_ID=" & iProd_ID & ";"

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetMessUsedModels(ByVal strLoc_IDs As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT DISTINCT A.Model_ID,B.Model_Desc" & Environment.NewLine
                strSql &= " FROM tdevice A" & Environment.NewLine
                strSql &= " INNER JOIN tmodel B ON A.Model_ID=B.Model_ID" & Environment.NewLine
                strSql &= " WHERE A.Loc_ID in (" & strLoc_IDs & ");" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function AddMessNewProdModel(ByVal iProd_ID As Integer, _
           ByVal iModel_ID As Integer, _
           ByVal iInactive As Integer, _
           ByVal iKeyModel As Integer, _
           ByVal iUser_ID As Integer, _
           ByVal strDateTime As String) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim i As Integer = 0
            Try
                strSql = "SELECT * FROM tmodel_rec_status WHERE Model_ID=" & iModel_ID
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count = 0 Then
                    strSql = "INSERT INTO tmodel_rec_status (prod_id,model_id,inactive,KeyModel,User_ID,UpdateDatetime)" & Environment.NewLine
                    strSql &= " VALUES (" & iProd_ID & "," & iModel_ID & "," & iInactive & "," & iKeyModel & "," & Environment.NewLine
                    strSql &= iUser_ID & ",'" & strDateTime & "');"

                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                End If

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function UpdateMessKeyModel(ByVal iProd_ID As Integer, _
          ByVal iModel_ID As Integer, _
          ByVal iKeyModel As Integer) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Try

                strSql = "Update tmodel_rec_status Set KeyModel=" & iKeyModel & Environment.NewLine
                strSql &= " WHERE Prod_ID=" & iProd_ID & " AND Model_ID=" & iModel_ID & ";"

                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function UpdateMesActiveInactiveModel(ByVal iMrs_ID As Integer, _
           ByVal iInactive As Integer) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Try

                strSql = "Update tmodel_rec_status Set inactive=" & iInactive & Environment.NewLine
                strSql &= " WHERE Mrs_ID=" & iMrs_ID & ";"

                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetMessActiveInactiveModelData(Optional ByVal iModel_ID As Integer = 0) As DataTable
            Dim strSql As String = ""

            Try

                strSql = "SELECT A.Model_ID,B.Model_Desc,IF(A.Inactive=1,'No','Yes') AS 'ActiveModel'" & Environment.NewLine
                strSql &= ",IF(A.Inactive=1,'Inactive','Active') AS 'ModelStatus'" & Environment.NewLine
                strSql &= " ,IF(A.KeyModel=1, 'Yes','No') AS 'IsKeyModel'" & Environment.NewLine
                strSql &= " ,A.Inactive" & Environment.NewLine
                strSql &= " ,A.KeyModel,A.Prod_ID,A.MRS_ID" & Environment.NewLine
                strSql &= " FROM tmodel_rec_status A" & Environment.NewLine
                strSql &= " INNER JOIN tmodel B ON A.Model_ID=B.Model_ID" & Environment.NewLine
                strSql &= " WHERE A.Prod_ID=1" & Environment.NewLine

                If iModel_ID > 0 Then strSql &= " AND A.Model_ID=" & iModel_ID

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************
        Public Function GetAllSNsModelsForPallet(ByVal iPalletID As Integer, _
                                                 Optional ByVal strDevice_SN As String = "" _
                                                 ) As DataTable
            Dim strSql As String = ""

            Try
                If strDevice_SN.Trim.Length > 0 Then
                    strSql = "Select A.Device_ID, A.Device_SN, B.Model_Desc,A.Loc_ID,A.Model_ID from tdevice A" & Environment.NewLine
                    strSql &= " left Join tmodel B On A.Model_ID=B.Model_ID" & Environment.NewLine
                    strSql &= " where pallett_id = " & iPalletID & "  and device_sn = '" & strDevice_SN.Trim & "';" & Environment.NewLine
                Else
                    strSql = "Select A.Device_ID, A.Device_SN, B.Model_Desc,A.Loc_ID,A.Model_ID from tdevice A" & Environment.NewLine
                    strSql &= " left Join tmodel B On A.Model_ID=B.Model_ID" & Environment.NewLine
                    strSql &= " where pallett_id =" & iPalletID & " order by device_id;" & Environment.NewLine
                End If

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************
        Public Function GetPallettSummaryDataDefinition(ByVal dt As DataTable) As DataTable
            Dim strSql As String = ""
            Dim row, rowNew As DataRow
            Dim dtOut As New DataTable()
            Dim arrLstUniqModels As New ArrayList()
            Dim i As Integer = 0, iQty As Integer = 0
            Dim filteredRows() As DataRow

            Try
                strSql = "select 1 as 'Qty','test model' as 'Model';"
                dtOut = Me._objDataProc.GetDataTable(strSql)
                dtOut.Rows.Clear() 'or: dtOut.Clear(), dtOut.Reset() if you want to keep the table structure (i.e. columns), use datatable.rows.clear . And if you want to start from scratch, use datatable.clear , or even datatable.reset to go right back to the beginning. datatable.reset is effectively the next level up from datatable.clear .

                If dt.Rows.Count > 0 Then
                    For Each row In dt.Rows
                        If Not arrLstUniqModels.Contains(row("Model_Desc")) Then
                            arrLstUniqModels.Add(row("Model_Desc"))
                        End If
                    Next
                    For i = 0 To arrLstUniqModels.Count - 1
                        filteredRows = dt.Select("Model_Desc = '" & arrLstUniqModels(i).ToString.Replace("'", "''") & "'")
                        iQty = filteredRows.Length
                        rowNew = dtOut.NewRow
                        rowNew("Model") = arrLstUniqModels(i).ToString
                        rowNew("Qty") = iQty
                        dtOut.Rows.Add(rowNew)
                    Next
                End If

                Return dtOut
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetMessDeviceData(ByVal iLoc_IDs As String, ByVal strSN As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT A.Device_ID,A.Device_SN,A.Device_DateRec,A.Device_DateBill" & Environment.NewLine
                strSql &= " ,A.device_dateShip,A.Pallett_ID,A.Device_LaborCharge,A.Device_PartCharge" & Environment.NewLine
                strSql &= " ,B.wipowner_id,IF(B.wipowner_id<=200,H.wipowner_desc,C.wipowner_desc) AS wipowner_desc" & Environment.NewLine
                strSql &= " ,B.wipowner_EntryDt,B.wipownersubloc_id,B.EvalBillCode_ID" & Environment.NewLine
                strSql &= " ,B.EvalCharges,B.EvalDateTime,B.EvalUserID,B.EvalFlag,M.Cust_Name1" & Environment.NewLine
                strSql &= " , if(M.Cust_ID=" & PSS.Data.Buisness.SkyTel.CriticalAlert_CUSTOMER_ID & ",  CONCAT(M.Cust_Name1, ' - ', K.Loc_Name), M.Cust_Name1) as 'Customer'" & Environment.NewLine
                strSql &= ",A.Ship_ID,A.WO_ID,A.Loc_ID,K.Cust_ID" & Environment.NewLine
                strSql &= " FROM tdevice A" & Environment.NewLine
                strSql &= " INNER JOIN tmessdata B ON A.device_ID=B.device_ID" & Environment.NewLine
                strSql &= " INNER JOIN tlocation K ON A.Loc_ID=K.Loc_ID" & Environment.NewLine
                strSql &= " INNER JOIN tCustomer M ON K.Cust_ID=M.Cust_ID" & Environment.NewLine
                strSql &= " LEFT JOIN lwipowner_set2 C ON B.WipOwner_ID=C.WipOwner_ID" & Environment.NewLine
                strSql &= " LEFT JOIN lwipowner H ON B.WipOwner_ID=H.WipOwner_ID" & Environment.NewLine
                strSql &= " LEFT JOIN lbillcodes F ON B.EvalBillCode_ID= F.billcode_ID" & Environment.NewLine
                strSql &= " WHERE A.Device_DateShip IS NULL AND A.LOC_ID in (" & iLoc_IDs & ")" & Environment.NewLine
                strSql &= " AND A.Device_SN='" & strSN.Replace("'", "''") & "'" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '******************************************************************
        Public Function GetMessDeviceDataByDeviceID(ByVal iDeviceID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT * FROM tDevice WHERE Device_ID=" & iDeviceID & ";"
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetMessDataByDeviceID(ByVal iDevice_ID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT * FROM tMessData WHERE Device_ID = " & iDevice_ID & ";" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        ''******************************************************************
        'Public Function GetMessDataByDeviceSN(ByVal strDevice_SN As String) As DataTable
        '    Dim strSql As String = ""

        '    Try
        '        strSql = "SELECT * FROM tMessData WHERE Device_SN = '" & strDevice_SN.Replace("'", "''") & "';" & Environment.NewLine

        '        Return Me._objDataProc.GetDataTable(strSql)

        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Function


        '*************************************************************************************
        Public Function GetMessAggregateCharge(ByVal iCust_ID As Integer, ByVal iBillCode_ID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT A.BillCode_ID,B.BillCode_Desc,A.tCab_Amount,A.Tcab_ID" & Environment.NewLine
                strSql &= " FROM tcustaggregatebilling A" & Environment.NewLine
                strSql &= " inner join lbillcodes B on A.Billcode_ID=B.BillCode_ID" & Environment.NewLine
                strSql &= " where cust_ID=" & iCust_ID & " and A.BillCode_ID=" & iBillCode_ID & ";" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '******************************************************************
        Public Function GetMessDeviceBillByDeviceID(ByVal iDevice_ID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT * FROM tDeviceBill WHERE Device_ID = " & iDevice_ID & ";" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '******************************************************************
        Public Function InsertMessDeviceBill(ByVal DBill_RegPartPrice As Double, _
         ByVal DBill_AvgCost As Double, _
         ByVal DBill_StdCost As Double, _
         ByVal DBill_InvoiceAmt As Double, _
         ByVal iDevice_ID As Integer, _
         ByVal iBillCode_ID As Integer, _
         ByVal strPartNumber As String, _
         ByVal iFail_ID As Integer, _
         ByVal iRepair_ID As Integer, _
         ByVal objComp_ID As Object, _
         ByVal iUser_ID As Integer, _
         ByVal strDate_Rec As String, _
         ByVal strReplPartSN As String) As Integer

            Dim strSql As String = ""

            Try
                strSql = "INSERT INTO tDeviceBill" & Environment.NewLine
                strSql &= " (DBill_RegPartPrice,DBill_AvgCost,DBill_StdCost,DBill_InvoiceAmt"
                strSql &= ",Device_ID,BillCode_ID,Part_Number,Fail_ID,Repair_ID,Comp_ID"
                strSql &= ",User_ID,Date_Rec,ReplPartSN)"
                strSql &= " VALUES ("
                strSql &= DBill_RegPartPrice & "," & DBill_AvgCost & "," & DBill_StdCost & "," & DBill_InvoiceAmt
                strSql &= "," & iDevice_ID & "," & iBillCode_ID & ",'" & strPartNumber & "'," & iFail_ID & "," & iRepair_ID
                If objComp_ID Is DBNull.Value Then    'IsDBNull(iComp_ID) Then
                    strSql &= ",Null"
                Else
                    strSql &= "," & CInt(objComp_ID)
                End If
                strSql &= "," & iUser_ID & ",'" & strDate_Rec & "','" & strReplPartSN & "');"

                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function UpdateMessDevice(ByVal strBillDateTime As String, _
           ByVal strShipDateTime As String, _
           ByVal strShipWorkDate As String, _
           ByVal iManufWrty As Integer, _
           ByVal iPSSWrty As Integer, _
           ByVal iDeviceID As Integer, _
           ByVal iLaborLevel As Integer, _
           ByVal vLaborCharge As Double, _
           ByVal vManufWrtyLaborCharge As Double, _
           ByVal vPartCharge As Double, _
           ByVal vManufWrtyPartCharge As Double, _
           ByVal iShipID As Integer, _
           ByVal iShiftID As Integer) As Integer

            Dim strSql As String = ""

            Try
                strSql = "UPDATE tdevice "
                strSql &= "SET Device_DateBill = '" & strBillDateTime & "',"
                strSql &= "Device_DateShip  = '" & strShipDateTime & "',"
                strSql &= "Device_ShipWorkDate = '" & strShipWorkDate & "',"
                strSql &= "Device_ManufWrty = " & iManufWrty & ","
                strSql &= "Device_PSSWrty = " & iPSSWrty & ","
                strSql &= "Device_LaborLevel = " & iLaborLevel & ","
                strSql &= "Device_LaborCharge  = " & vLaborCharge & ","
                strSql &= "Device_ManufWrtyLaborCharge = " & vManufWrtyLaborCharge & ","
                strSql &= "Device_PartCharge = " & vPartCharge & ","
                strSql &= "Device_ManufWrtyPartCharge = " & vManufWrtyPartCharge & ","
                strSql &= "Ship_ID  = " & iShipID & ","
                strSql &= "Shift_ID_Ship = " & iShiftID
                strSql &= " WHERE Device_ID =  " & iDeviceID & ";"

                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function UpdateMessEvalBill(ByVal iDeviceID As Integer, _
          ByVal iEvalBillCodeID As Integer, _
          ByVal vEvalCharge As Double, _
          ByVal iWipOwnerID As Integer, _
          ByVal iUserID As Integer, _
          ByVal strDateTime As String) As Integer

            Dim strSql As String = ""

            Try
                strSql = "UPDATE tmessdata "
                strSql &= "SET EvalBillCode_ID = " & iEvalBillCodeID & ","
                strSql &= "EvalCharges  = " & vEvalCharge & ","
                strSql &= "wipowner_id_Old = wipowner_id,"
                strSql &= "wipowner_id=" & iWipOwnerID & ","
                strSql &= "EvalUserID = " & iUserID & ","
                strSql &= "EvalDateTime = '" & strDateTime & "', "
                strSql &= "wipowner_entrydt = '" & strDateTime & "' "
                strSql &= " WHERE Device_ID =  " & iDeviceID & ";"

                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function UpdateMessWipOwnerData(ByVal iDeviceID As Integer, _
           ByVal iWipOwnerID As Integer, _
           ByVal strDateTime As String) As Integer
            Dim strSql As String = ""
            Try
                strSql = "UPDATE tmessdata "
                strSql &= " SET wipowner_id_Old=wipowner_id,"
                strSql &= "wipowner_id=" & iWipOwnerID & ","
                strSql &= "wipowner_EntryDt= '" & strDateTime & "'"
                strSql &= " WHERE Device_ID =  " & iDeviceID & ";"

                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function UndoDBRNER_MessDeviceData(ByVal iDevice_ID As Integer, ByVal username As String) As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0
            Dim _dwsj As PSS.Data.BOL.tdevice_workstation_journal
            Dim _cmp_na As String = Environment.MachineName

            Try
                'Delete bill data
                strSql = "DELETE FROM tDeviceBill WHERE Device_ID = " & iDevice_ID & ";"
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                'reset tdevice
                strSql = "UPDATE tdevice SET device_dateBill=null, device_dateSHip=null,device_ShipWorkDate=null,ship_ID=null,device_LaborCharge=0.00,"
                strSql &= "Pallett_ID=null,Shift_ID_Ship=0 WHERE device_ID = " & iDevice_ID & ";"
                i += Me._objDataProc.ExecuteNonQuery(strSql)

                'reset tmessdata
                strSql = "UPDATE tmessdata SET EvalBillCode_ID =0,EvalCharges  = 0.00,wipowner_id_Old=0,"
                strSql &= "wipowner_id=202,EvalUserID = 0,EvalDateTime = null"
                strSql &= " WHERE Device_ID =  " & iDevice_ID & ";"
                i += Me._objDataProc.ExecuteNonQuery(strSql)

                ' ADD THE DEVICE JOURNAL ENTRY.
                _dwsj = New PSS.Data.BOL.tdevice_workstation_journal(iDevice_ID, 1, "Pre-Eval", "", username, _cmp_na, "Pre-Eval - Undo")
                _dwsj.ApplyChanges()

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function UndoProcessToPreCell_MessDeviceData(ByVal iDevice_ID As Integer, ByVal username As String) As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0
            Dim _dwsj As PSS.Data.BOL.tdevice_workstation_journal
            Dim _cmp_na As String = Environment.MachineName
            Try
                'reset tmessdata only
                strSql = "UPDATE tmessdata SET "
                strSql &= "EvalBillCode_ID =0, "
                strSql &= "EvalCharges  = 0.00, "
                strSql &= "wipowner_id_Old=0, "
                strSql &= "wipowner_id=202, "
                strSql &= "EvalUserID = 0, "
                strSql &= "EvalDateTime = null "
                strSql &= " WHERE Device_ID =  " & iDevice_ID & ";"
                i = Me._objDataProc.ExecuteNonQuery(strSql)
                ' ADD THE DEVICE JOURNAL ENTRY.
                _dwsj = New PSS.Data.BOL.tdevice_workstation_journal(iDevice_ID, 1, "Pre-Eval", "", username, _cmp_na, "Pre-Eval - Undo")
                _dwsj.ApplyChanges()
                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************

#End Region
	End Class
End Namespace
