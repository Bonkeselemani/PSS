Option Explicit On 

Imports CrystalDecisions.CrystalReports.Engine
Imports System.Windows.Forms

Namespace Buisness

    Public Class DriveCam

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
        Public Shared ReadOnly Property PARENTCOMP_ID() As Integer
            Get
                Return 734
            End Get
        End Property

        ''******************************************************************
        'Public Shared ReadOnly Property SKYTEL_LOC_ID() As Integer
        '    Get
        '        Return 2062
        '    End Get
        'End Property
        '******************************************************************
        Public Shared ReadOnly Property MANIFEST_DIR() As String
            Get
                Return "P:\Dept\DriveCam\Pallet Packing List\"
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property GROUPID() As Integer
            Get
                Return 84
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property PRODID() As Integer
            Get
                Return 9
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property RUR_SCRAP_PALLETID() As Integer
            Get
                Return 144029
            End Get
        End Property
        Public Shared ReadOnly Property RUR_MASTER_CODEID() As Integer
            Get
                Return 38
            End Get
        End Property

        '******************************************************************
        Public Shared ReadOnly Property VeoliaTrans_MANIFEST_DIR() As String
            Get
                Return "P:\Dept\VeoliaTransportation\Pallet Packing List\"
            End Get
        End Property

        '******************************************************************
        Public Shared ReadOnly Property SUPPORTCCID() As Integer
            Get
                Return 45
            End Get
        End Property

        '******************************************************************

#End Region

#Region "Receiving"
        '******************************************************************
        Public Function GetParentCoListByProdID(ByVal iProdID As Integer, _
                                                ByVal booAllowCreditCardCustomer As Boolean, _
                                                Optional ByVal booAddSelectRow As Boolean = False) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "Select distinct lparentco.* from lparentco " & Environment.NewLine
                strSql &= "INNER JOIN tcustomer on lparentco.pco_id = tcustomer.pco_id " & Environment.NewLine
                strSql &= "INNER JOIN tcusttoprice ON tcustomer.Cust_ID = tcusttoprice.Cust_ID " & Environment.NewLine
                strSql &= "WHERE tcusttoprice.Prod_ID = " & iProdID & Environment.NewLine
                strSql &= "AND lparentco.PCo_Active = 1" & Environment.NewLine
                If booAllowCreditCardCustomer = False Then strSql &= "AND tcustomer.Pay_ID <> 2 " & Environment.NewLine
                'strSql &= "where lparentco.PCo_ID in (  " & strPCoIDs & ") "
                strSql &= "ORDER BY lparentco.PCo_Name;"
                dt = Me._objDataProc.GetDataTable(strSql)

                If booAddSelectRow = True Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetCustomersByPCo(ByVal strPCoIDs As String) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "Select Cust_ID as ID, if(Cust_Name2 is null, Cust_Name1, CONCAT(Cust_Name1, ' ', Cust_Name2)) as 'Name', tcustomer.* " & Environment.NewLine
                strSql &= "FROM tcustomer " & Environment.NewLine
                strSql &= "WHERE PCo_ID IN ( " & strPCoIDs & " )" & Environment.NewLine
                strSql &= "ORDER BY Name "
                'strSql = "Select Cust_ID, Cust_Name1 as 'Name' from tcustomer where PCo_ID = " & iPCoID
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetCustomersByProdID(ByVal iProdID As Integer) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT DISTINCT tcustomer.Cust_ID as ID, if(Cust_Name2 is null, Cust_Name1, CONCAT(Cust_Name1, ' ', Cust_Name2)) as 'Name', tcustomer.* " & Environment.NewLine
                strSql &= "FROM tcustomer " & Environment.NewLine
                strSql &= "INNER JOIN tcusttoprice ON tcustomer.Cust_ID = tcusttoprice.Cust_ID " & Environment.NewLine
                strSql &= "WHERE Prod_ID = " & iProdID & Environment.NewLine
                strSql &= "ORDER BY Name "
                'strSql = "Select Cust_ID, Cust_Name1 as 'Name' from tcustomer where PCo_ID = " & iPCoID
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetModels(ByVal booAddSelectRow As Boolean, _
                                  ByVal iProdID As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Try
                strSql = "Select * from tmodel where Prod_ID = " & iProdID & Environment.NewLine
                strSql &= "ORDER BY Model_Desc "
                'strSql = "Select Cust_ID, Cust_Name1 as 'Name' from tcustomer where PCo_ID = " & iPCoID
                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow = True Then dt.LoadDataRow(New Object() {"0", "--SELECT--", 0, 0}, False)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetCreditCardType(ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Try
                strSql = "select * from lcctype where CCType_ID <> 2 order by CCType_Desc "
                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow = True Then dt.LoadDataRow(New Object() {"0", "--SELECT--", 0, 0}, False)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetCCExpMonths() As DataTable
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim iMonth As Integer
            Try
                dt = New DataTable()
                dt.Columns.Add(New DataColumn("ID", System.Type.GetType("System.String")))
                dt.Columns.Add(New DataColumn("Month", System.Type.GetType("System.String")))

                For iMonth = 1 To 12
                    R1 = dt.NewRow
                    R1("ID") = Format(iMonth, "00")
                    R1("Month") = Format(iMonth, "00")
                    dt.Rows.Add(R1)
                    dt.AcceptChanges()
                    R1 = Nothing
                Next iMonth

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Function

        '******************************************************************
        Public Function GetCCExpYears() As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim i, iYear As Integer

            Try
                strSql = "select date_format(now(), '%y') as ID, date_format(now(), '%Y')  as 'Year'"
                dt = Me._objDataProc.GetDataTable(strSql)

                iYear = dt.Rows(0)("Year")

                For i = iYear + 1 To iYear + 10
                    iYear += 1
                    R1 = dt.NewRow
                    R1("ID") = Right(iYear.ToString, 2)
                    R1("Year") = Format(iYear, "0000")
                    dt.Rows.Add(R1)
                    dt.AcceptChanges()
                Next i

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Function

        '******************************************************************
        Public Function GetState(ByVal booAddSelectRow As Boolean, ByVal booLongDesc As Boolean)
            Dim strSql As String = ""
            Dim dt As DataTable
            Try
                strSql = "SELECT State_ID "
                If booLongDesc Then strSql &= ", State_Long as 'State_Desc'" Else strSql &= ", State_Short as 'State_Desc' "
                strSql &= "FROM lstate "
                If booLongDesc = True Then strSql &= "order by State_Long " Else strSql &= "order by State_Short "
                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow = True Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Function

        '******************************************************************
        Public Function GetCountry(ByVal booAddSelectRow As Boolean)
            Dim strSql As String = ""
            Dim dt As DataTable
            Try
                strSql = "SELECT Cntry_ID, Cntry_Name FROM lcountry order by Cntry_Name"
                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow = True Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Function

        '******************************************************************
        Public Function CreateYesNoDataTable() As DataTable
            Dim R1 As DataRow
            Dim dt As DataTable
            Try
                dt = New DataTable()
                dt.Columns.Add(New DataColumn("ID", System.Type.GetType("System.Int32")))
                dt.Columns.Add(New DataColumn("Desc", System.Type.GetType("System.String")))

                R1 = dt.NewRow
                R1("ID") = 0
                R1("Desc") = "NO"
                dt.Rows.Add(R1)
                dt.AcceptChanges()
                R1 = Nothing
                R1 = dt.NewRow
                R1("ID") = 1
                R1("Desc") = "YES"
                dt.Rows.Add(R1)
                dt.AcceptChanges()

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetCustLocation(ByVal iCustID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT * FROM tlocation WHERE tlocation.Cust_ID = " & iCustID & " ORDER BY Loc_ID desc"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetLastCreditCardInfo(ByVal iCustID As Integer) As DataTable
            Dim strSql, strDecriptMsg As String
            Dim dt As DataTable
            Dim R1 As DataRow

            Try
                strSql = "SELECT tcreditcard.*, lcctype.CCType_Desc  " & Environment.NewLine
                strSql &= "FROM tcreditcard " & Environment.NewLine
                strSql &= "INNER JOIN lcctype ON tcreditcard.CCardType_ID = lcctype.CCType_ID  " & Environment.NewLine
                strSql &= "WHERE Cust_ID = " & iCustID & "  " & Environment.NewLine
                strSql &= "ORDER BY CreditCard_ID DESC" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                For Each R1 In dt.Rows
                    strDecriptMsg = ""
                    R1.BeginEdit()
                    R1("CreditCard_Num") = EncDec.Rijndael.Decrypt(R1("CreditCard_Num"), strDecriptMsg)
                    R1("CreditCard_AuthCode") = EncDec.Rijndael.Decrypt(R1("CreditCard_AuthCode"), strDecriptMsg)
                    R1.EndEdit()
                Next R1

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function SearchCustByAddress(ByVal iPCoID As Integer, _
                                            ByVal strAddress As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT DISTINCT tcustomer.*, Concat(Cust_Name1, ' ', if(Cust_Name2 is null, '', Cust_Name2)) as 'Name' " & Environment.NewLine
                strSql &= "FROM tcustomer " & Environment.NewLine
                strSql &= "INNER JOIN tlocation ON tcustomer.Cust_ID = tlocation.Cust_ID " & Environment.NewLine
                strSql &= "WHERE tcustomer.PCo_ID = " & iPCoID & Environment.NewLine
                strSql &= "AND tlocation.Loc_Address1 like '%" & strAddress & "%'" & Environment.NewLine
                strSql &= "ORDER BY Name"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function CreateNewCustomer(ByRef iCustID As Integer, _
                                          ByRef iLocID As Integer, _
                                          ByVal strFirstName As String, _
                                          ByVal strLastName As String, _
                                          ByVal strAddress1 As String, _
                                          ByVal strAddress2 As String, _
                                          ByVal strCity As String, _
                                          ByVal iStateID As Integer, _
                                          ByVal strZipCode As String, _
                                          ByVal iCountryID As Integer, _
                                          ByVal strPhoneNumber As String, _
                                          ByVal strFaxNumber As String, _
                                          ByVal iNonWrtyRepair As Integer, _
                                          ByVal strEmailAddress As String, _
                                          ByVal iCCTypeID As Integer, _
                                          ByVal strCCNo As String, _
                                          ByVal strCCSecurityCode As String, _
                                          ByVal strCCExpDate As String) As Integer
            Dim strSql As String = ""
            Dim dtPCo As DataTable
            Dim i, iSaleTax As Integer
          

            Try
                iSaleTax = 0
                If iStateID = 44 Then iSaleTax = 1

                strSql = "SELECT * FROM lparentco WHERE PCo_ID = " & Me.PARENTCOMP_ID & Environment.NewLine
                dtPCo = Me._objDataProc.GetDataTable(strSql)

                If dtPCo.Rows.Count > 0 Then
                    '1: Create Customer
                    strSql = "INSERT INTO tcustomer " & Environment.NewLine
                    strSql &= "( Cust_Name1 " & Environment.NewLine
                    strSql &= ", Cust_Name2 " & Environment.NewLine
                    strSql &= ", Cust_RepairNonWrty " & Environment.NewLine
                    strSql &= ", Cust_ReplaceLCD " & Environment.NewLine
                    strSql &= ", PCo_ID " & Environment.NewLine
                    strSql &= ", PlusParts " & Environment.NewLine
                    strSql &= ", Cust_RejectDays " & Environment.NewLine
                    strSql &= ", Cust_RejectTimes " & Environment.NewLine
                    strSql &= ", Cust_CrApproveRec " & Environment.NewLine
                    strSql &= ", Cust_CrApproveShip " & Environment.NewLine
                    strSql &= ", Cust_CollSalesTax " & Environment.NewLine
                    strSql &= ", Pay_ID " & Environment.NewLine
                    strSql &= ", Cust_AggBilling " & Environment.NewLine
                    strSql &= ") VALUES (" & Environment.NewLine
                    strSql &= "'" & strFirstName & "' " & Environment.NewLine
                    strSql &= ", '" & strLastName & "' " & Environment.NewLine
                    strSql &= ", " & iNonWrtyRepair & " " & Environment.NewLine
                    strSql &= ", 0 " & Environment.NewLine
                    strSql &= ", " & Me.PARENTCOMP_ID & "  " & Environment.NewLine
                    strSql &= ", 0, 0, 0, 1, 1  " & Environment.NewLine
                    strSql &= ", " & iSaleTax & " " & Environment.NewLine
                    strSql &= ", 2 " & Environment.NewLine
                    strSql &= ", 1 );"
                    iCustID = Me._objDataProc.idTransaction(strSql, "tcustomer")
                    If iCustID = 0 Then Throw New Exception("System has failed to create Customer.")

                    '2: Create Customer Markup
                    strSql = "INSERT INTO tcustmarkup " & Environment.NewLine
                    strSql &= "(Markup_RUR " & Environment.NewLine
                    strSql &= ", Markup_NER " & Environment.NewLine
                    strSql &= ", Markup_Cust " & Environment.NewLine
                    strSql &= ", Cust_ID " & Environment.NewLine
                    strSql &= ", Prod_ID " & Environment.NewLine
                    strSql &= ", Invtrymthd_ID " & Environment.NewLine
                    strSql &= ", Markup_PlusParts " & Environment.NewLine
                    strSql &= ") VALUES ( " & Environment.NewLine
                    strSql &= dtPCo.Rows(0)("PCo_DefRUR") & " " & Environment.NewLine
                    strSql &= ", " & dtPCo.Rows(0)("PCo_DefNER") & Environment.NewLine
                    strSql &= ", " & dtPCo.Rows(0)("PCo_DefMarkUp") & " " & Environment.NewLine
                    strSql &= ", " & iCustID & " " & Environment.NewLine
                    strSql &= ", " & Me.PRODID & Environment.NewLine
                    strSql &= ", 1 " & Environment.NewLine
                    strSql &= ", 0)"
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                    If i = 0 Then Throw New Exception("System has failed to create Customer Markup.")

                    '3: Create Customer Warranty
                    strSql = "INSERT INTO tcustwrty " & Environment.NewLine
                    strSql &= "( CustWrty_DaysinWrty " & Environment.NewLine
                    strSql &= ", PSSWrtyParts_ID " & Environment.NewLine
                    strSql &= ", PSSWrtyLabor_ID " & Environment.NewLine
                    strSql &= ", Prod_ID " & Environment.NewLine
                    strSql &= ", Cust_ID " & Environment.NewLine
                    strSql &= ") VALUES (  " & Environment.NewLine
                    strSql &= dtPCo.Rows(0)("PCo_DefWrtyDays") & " " & Environment.NewLine
                    strSql &= ", " & dtPCo.Rows(0)("PSSWrtyParts_ID") & " " & Environment.NewLine
                    strSql &= ", " & dtPCo.Rows(0)("PssWrtyLabor_ID") & " " & Environment.NewLine
                    strSql &= ", " & Me.PRODID & Environment.NewLine
                    strSql &= ", " & iCustID & ")"
                    i = Me._objDataProc.ExecuteNonQuery(strSql)

                    If i = 0 Then Throw New Exception("System has failed to create Customer Warranty.")

                    '4: Create Customer Warranty
                    strSql = "INSERT INTO tcusttoprice " & Environment.NewLine
                    strSql &= "( Cust_ID " & Environment.NewLine
                    strSql &= ", PrcGroup_ID " & Environment.NewLine
                    strSql &= ", prod_ID " & Environment.NewLine
                    strSql &= ") VALUES ( " & Environment.NewLine
                    strSql &= iCustID & " " & Environment.NewLine
                    strSql &= ", " & dtPCo.Rows(0)("PrcGroup_ID") & " " & Environment.NewLine
                    strSql &= ", " & Me.PRODID & ")"
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                    If i = 0 Then Throw New Exception("System has failed to create Customer to Price.")

                    '5: Create Location
                    strSql = "INSERT INTO tlocation " & Environment.NewLine
                    strSql &= "( Loc_Address1  " & Environment.NewLine
                    strSql &= ", Loc_Address2" & Environment.NewLine
                    strSql &= ", Loc_City " & Environment.NewLine
                    strSql &= ", Loc_Zip " & Environment.NewLine
                    strSql &= ", Loc_Phone " & Environment.NewLine
                    strSql &= ", Loc_Fax " & Environment.NewLine
                    strSql &= ", State_ID " & Environment.NewLine
                    strSql &= ", Cntry_ID " & Environment.NewLine
                    strSql &= ", Cust_ID " & Environment.NewLine
                    strSql &= ", Loc_AfterMarket " & Environment.NewLine
                    strSql &= ", Loc_ManifestDetail " & Environment.NewLine
                    strSql &= ") VALUES (  " & Environment.NewLine
                    strSql &= " '" & strAddress1.Trim & "' " & Environment.NewLine
                    strSql &= ", '" & strAddress2.Trim & "' " & Environment.NewLine
                    strSql &= ", '" & strCity & "' " & Environment.NewLine
                    strSql &= ", '" & strZipCode & "' " & Environment.NewLine
                    strSql &= ", '" & strPhoneNumber & "' " & Environment.NewLine
                    strSql &= ", '" & strFaxNumber & "' " & Environment.NewLine
                    strSql &= ", " & iStateID & " " & Environment.NewLine
                    strSql &= ", " & iCountryID & " " & Environment.NewLine
                    strSql &= ", " & iCustID & ", 1, 1 );"
                    iLocID = Me._objDataProc.idTransaction(strSql, "tlocation")
                    If iLocID = 0 Then Throw New Exception("System has failed to create Loction.")

                    '5: Add/Update Credit Card Information
                    i = InsertUpdateCreditCard(iCustID, iCCTypeID, strCCNo, strCCSecurityCode, strCCExpDate)
                    If i = 0 Then Throw New Exception("System has failed to record credit card information.")
                Else
                    Throw New Exception("Parent Company is missing.")
                End If

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dtPCo)
            End Try
        End Function

        '******************************************************************
        Public Function InsertUpdateCreditCard(ByVal iCustID As Integer, _
                                               ByVal iCCTypeID As Integer, _
                                               ByVal strCCNo As String, _
                                               ByVal strCCSecurityCode As String, _
                                               ByVal strCCExpDate As String) As Integer
            Dim strSql, strEncCCNo, strEncAuthorizeCode, strEncReturnMsg As String
            Dim dt As DataTable
            Dim i As Integer

            Try
                strSql = "" : strEncCCNo = "" : strEncAuthorizeCode = "" : strEncReturnMsg = ""
                strEncCCNo = EncDec.Rijndael.Encrypt(strCCNo, strEncReturnMsg)
                strEncAuthorizeCode = EncDec.Rijndael.Encrypt(strCCSecurityCode, strEncReturnMsg)

                If strEncCCNo.Trim.Length = 0 Or strEncAuthorizeCode.Trim.Length = 0 Then Throw New Exception("System has failed to encrypt credit card information.")

                strSql = "select * from tcreditcard where cust_id = " & iCustID & " ORDER BY CreditCard_ID DESC "
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    'UPDATE
                    strSql = "UPDATE tcreditcard " & Environment.NewLine
                    strSql &= "SET CCardType_ID = " & iCCTypeID & Environment.NewLine
                    strSql &= ", CreditCard_Num = '" & strEncCCNo & "'" & Environment.NewLine
                    strSql &= ", CreditCard_AuthCode = '" & strEncAuthorizeCode & "'" & Environment.NewLine
                    strSql &= ", CreditCard_ExpDate = '" & strCCExpDate & "'" & Environment.NewLine
                    strSql &= "WHERE CreditCard_ID = " & dt.Rows(0)("CreditCard_ID") & Environment.NewLine
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                    If i = 0 Then Throw New Exception("System has failed to update credit card information.")
                Else
                    'INSERT
                    strSql = "INSERT INTO tcreditcard " & Environment.NewLine
                    strSql &= "( Cust_ID " & Environment.NewLine
                    strSql &= ", CCardType_ID " & Environment.NewLine
                    strSql &= ", CreditCard_Num " & Environment.NewLine
                    strSql &= ", CreditCard_AuthCode " & Environment.NewLine
                    strSql &= ", CreditCard_ExpDate " & Environment.NewLine
                    strSql &= ") VALUES ( " & Environment.NewLine
                    strSql &= iCustID & " " & Environment.NewLine
                    strSql &= ", " & iCCTypeID & " " & Environment.NewLine
                    strSql &= ", '" & strEncCCNo & "' " & Environment.NewLine
                    strSql &= ", '" & strEncAuthorizeCode & "' " & Environment.NewLine
                    strSql &= ", '" & strCCExpDate & "' )"
                    i = Me._objDataProc.ExecuteNonQuery(strSql)

                    If i = 0 Then Throw New Exception("System has failed to update credit card information.")
                End If

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetCustInfo(ByVal iCustID As Integer, ByVal iLocID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT Concat(Cust_Name1, ' ', if(Cust_Name2 is null, '', Cust_Name2)) as 'Name' " & Environment.NewLine
                strSql &= ", tlocation.Loc_Address1 as 'Address1' " & Environment.NewLine
                strSql &= ", IF(tlocation.Loc_Address2 is null, '', tlocation.Loc_Address2) as 'Address2' " & Environment.NewLine
                strSql &= ", CONCAT(Loc_City, ' ', State_Short, ', ', Loc_Zip ) as 'CityStateZip'  " & Environment.NewLine
                strSql &= ", Cntry_Name as Country " & Environment.NewLine
                strSql &= ", Loc_Phone as Phone " & Environment.NewLine
                strSql &= ", Loc_Fax as Fax " & Environment.NewLine
                strSql &= ", if(Cust_RepairNonWrty = 1, 'YES', 'NO') as RepNonWrty " & Environment.NewLine
                strSql &= "FROM tcustomer " & Environment.NewLine
                strSql &= "INNER JOIN tlocation ON tcustomer.Cust_ID = tlocation.Cust_ID " & Environment.NewLine
                strSql &= "INNER JOIN lstate ON tlocation.State_ID = lstate.State_ID " & Environment.NewLine
                strSql &= "INNER JOIN lcountry ON tlocation.Cntry_ID = lcountry.Cntry_ID " & Environment.NewLine
                strSql &= "WHERE tcustomer.Cust_ID = " & iCustID & Environment.NewLine
                strSql &= "AND tlocation.Loc_ID = " & iLocID & Environment.NewLine
                strSql &= "ORDER BY Name"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function CreateWO(ByVal iLocID As Integer, _
                                 ByRef strWOName As String, _
                                 ByVal strPOID As String) As Integer
            Dim objRec As PSS.Data.Production.Receiving
            Dim strSql As String = ""
            Dim iWOID As Integer = 0

            Try
                strSql = "select DATE_FORMAT(now(), '%Y%m%d%H%i%s') as WOName"
                strWOName = Me._objDataProc.GetSingletonString(strSql)
                objRec = New PSS.Data.Production.Receiving()
                iWOID = objRec.InsertIntoTworkorder(strWOName, strWOName, iLocID, Me.PRODID, Me.GROUPID, , , strPOID, , , 0)

                Return iWOID
            Catch ex As Exception
                Throw ex
            Finally
                objRec = Nothing
            End Try
        End Function

        '******************************************************************
        Public Function CreateTray(ByVal strUsrName As String, _
                                   ByVal iUsrID As Integer, _
                                   ByVal iWOID As Integer, _
                                   ByVal strTrayMemo As String) As Integer
            Dim objRec As PSS.Data.Production.Receiving
            Dim iTrayID As Integer = 0

            Try
                objRec = New PSS.Data.Production.Receiving()
                iTrayID = objRec.InsertIntoTtray(iUsrID, strUsrName, iWOID, strTrayMemo)

                Return iTrayID
            Catch ex As Exception
                Throw ex
            Finally
                objRec = Nothing
            End Try
        End Function

        '******************************************************************
        Public Function ReceiveDevice(ByVal iLocID As Integer, ByVal iWOID As Integer, ByVal iTrayID As Integer, _
                                      ByVal strSN As String, ByVal iModelID As Integer, ByVal iShiftID As Integer, _
                                      ByVal iUsrID As Integer, ByVal iRURReturnToCust As Integer, _
                                      ByVal iAuthorizeCompactFlash As Integer) As Integer
            Dim strWrkDate As String = ""
            Dim iDeviceID As Integer = 0
            Dim iCnt As Integer = 0
            Dim objRec As PSS.Data.Production.Receiving

            Try
                strWrkDate = PSS.Data.Buisness.Generic.GetWorkDate(iShiftID)
                iCnt = objRec.GetNextDeviceCountInTray(iTrayID) + 1

                'Writer device to tdevice table
                objRec = New PSS.Data.Production.Receiving()
                iDeviceID = objRec.InsertIntoTdevice(strSN, strWrkDate, iCnt, iTrayID, iLocID, iWOID, iModelID, iShiftID, , , , SUPPORTCCID, )
                If iDeviceID = 0 Then
                    Throw New Exception("System has failed to create Device ID.")
                End If

                objRec.InsertIntoTCellopt(iDeviceID, , , , , , , , , , , , , , , iRURReturnToCust)

                objRec.InsertIntoTDriveCamData(iDeviceID, iUsrID, iAuthorizeCompactFlash)

                Return iDeviceID
            Catch ex As Exception
                Throw ex
            Finally
                objRec = Nothing
            End Try
        End Function

        '******************************************************************
        Public Function GetReceiveDataByWOID(ByVal iWOID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT Device_Cnt as Cnt, Device_sn as 'SN', tworkorder.WO_CustWO as 'WO' " & Environment.NewLine
                strSql &= ", Device_DateRec as 'Receive Date', Device_DateShip as 'Ship Date' " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                strSql &= "WHERE tdevice.wo_id = " & iWOID & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function IsValidCreditCardNo(ByVal strCCNo As String, _
                                            ByVal drCCType As DataRow) As Boolean
            Dim strPrefix1 As String = ""
            Dim strPrefix2 As String = ""
            Dim iPrefixStartRange As Integer = 0
            Dim iPrefixEndrange As Integer = 0
            Dim iCCPrefixRangeNo As Integer = 0
            Dim iCCLen1 As Integer = 0
            Dim iCCLen2 As Integer = 0
            Dim booReturnVal As Boolean = False
            Dim booPrefixMatch As Boolean = False
            Dim strPrefixMessge As String = ""

            Try
                If Not IsDBNull(drCCType("CCType_Prefix1")) AndAlso drCCType("CCType_Prefix1") > 0 Then
                    strPrefix1 = drCCType("CCType_Prefix1").ToString.Trim
                    strPrefixMessge = strPrefix1
                End If
                If Not IsDBNull(drCCType("CCType_Prefix2")) AndAlso drCCType("CCType_Prefix2") > 0 Then
                    strPrefix2 = drCCType("CCType_Prefix2").ToString.Trim
                    If strPrefixMessge.Trim.Length > 0 Then strPrefixMessge &= ", "
                    strPrefixMessge &= strPrefix2
                End If

                If Not IsDBNull(drCCType("CCType_PrefixRange")) AndAlso drCCType("CCType_PrefixRange").ToString.Length > 0 Then
                    iPrefixStartRange = CInt(drCCType("CCType_PrefixRange").ToString.Trim.Split("-")(0))
                    iPrefixEndrange = CInt(drCCType("CCType_PrefixRange").ToString.Trim.Split("-")(1))
                    iCCPrefixRangeNo = CInt(Mid(strCCNo.Trim, 1, Math.Max(iPrefixStartRange.ToString.Trim.Length, iPrefixEndrange.ToString.Trim.Length)))
                    If strPrefixMessge.Trim.Length > 0 Then strPrefixMessge &= ", "
                    strPrefixMessge &= drCCType("CCType_PrefixRange")
                End If

                If Not IsDBNull(drCCType("CCType_Length")) AndAlso drCCType("CCType_Length") > 0 Then iCCLen1 = drCCType("CCType_Length")
                If Not IsDBNull(drCCType("CCType_Length2")) AndAlso drCCType("CCType_Length2") > 0 Then iCCLen2 = drCCType("CCType_Length2")

                If (strPrefix1 <> "" And strCCNo.Trim.StartsWith(strPrefix1.ToString) = True) Then
                    booPrefixMatch = True
                ElseIf (strPrefix2 <> "" And strCCNo.Trim.StartsWith(strPrefix2.ToString) = True) Then
                    booPrefixMatch = True
                ElseIf (iPrefixStartRange > 0 AndAlso iPrefixEndrange > 0 AndAlso iCCPrefixRangeNo > 0 AndAlso iCCPrefixRangeNo >= iPrefixStartRange AndAlso iCCPrefixRangeNo <= iPrefixEndrange) Then
                    booPrefixMatch = True
                End If

                If booPrefixMatch = False Then
                    MessageBox.Show(drCCType("CCType_Desc").ToString.ToUpper & " card must start with " & strPrefixMessge & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ElseIf (iCCLen1 > 0 AndAlso strCCNo.Trim.Length <> iCCLen1) And (iCCLen2 > 0 And strCCNo.Trim.Length <> iCCLen2) Then
                    MessageBox.Show(drCCType("CCType_Desc").ToString.ToUpper & " card must has " & IIf(iCCLen1 > 0 And iCCLen2 > 0, "either " & iCCLen1 & " or " & iCCLen2, IIf(iCCLen1 > 0, iCCLen1, iCCLen2)) & " digits.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ElseIf Me.LuhnCheck(strCCNo) = False Then
                    MessageBox.Show("Card number is not a valid number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    booReturnVal = True
                End If

                Return booReturnVal
            Catch ex As Exception
                Throw ex
            Finally
                drCCType = Nothing
            End Try
        End Function

        '******************************************************************
        Private Function LuhnCheck(ByVal strCCNum As String) As Boolean
            Dim iCount, iNum, iDigit, iSum As Integer
            Dim booResult As Boolean = True

            Try
                '**************************************
                'digit check
                '**************************************
                For iCount = 1 To strCCNum.Length
                    If Not IsNumeric(strCCNum.Substring(iCount - 1, 1)) Then
                        booResult = False
                    End If
                Next iCount

                '**************************************
                'LuhnCheck
                '**************************************
                If booResult = True Then
                    'checks to see if the credit card number is valid
                    'gets the credit card number,then checks to see if the number
                    'is a number. Then adds the number and returns true if number mod 10 yield zero.

                    'loop through the credit card numbers
                    For iCount = 1 To strCCNum.Length

                        'get the next number
                        iNum = CInt(Mid(strCCNum, strCCNum.Length - iCount + 1, 1))
                        If (iCount Mod 2 = 0) Then
                            iNum *= 2
                        End If

                        If iNum > 9 Then iNum = iNum - 9
                        iSum += iNum
                    Next iCount

                    If iSum Mod 10 <> 0 Then booResult = False
                End If
                '**************************************

                Return booResult

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************

#End Region

#Region "Build and Ship Box"
        '******************************************************************
        Public Function GetDDOpenPallets(ByVal iCustID As Integer, _
                                         ByVal iLocID As Integer, _
                                         ByVal strPalletStartName As String) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT Pallett_ID, tpallett.Cust_ID, tpallett.Loc_ID, Pallet_ShipType, Pallet_SkuLen, Pallett_Name as 'Box Name', Loc_Name as 'Loc Name' " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "INNER JOIN tlocation ON tpallett.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strSql &= "WHERE tpallett.cust_ID = " & iCustID.ToString & Environment.NewLine
                strSql &= "AND tpallett.Loc_ID = " & iLocID & Environment.NewLine
                strSql &= "AND pallett_name like '" & strPalletStartName & "%' " & Environment.NewLine
                strSql &= "AND Pallett_ReadyToShipFlg = 0 " & Environment.NewLine
                'strSql &= "AND tpallett.Model_ID = " & iModelID.ToString & Environment.NewLine
                strSql &= "AND Pallet_Invalid = 0 " & Environment.NewLine
                strSql &= "Order by Pallett_Name"

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function IsOpenBoxExisted(ByVal iCustID As Integer, _
                                         ByVal iLocID As Integer, _
                                         ByVal iMchCCGrpID As Integer) As Boolean
            Dim strSQL As String
            Dim dt As DataTable

            Try
                strSQL = "SELECT * " & Environment.NewLine
                strSQL &= "FROM tpallett " & Environment.NewLine
                strSQL &= "WHERE Cust_ID = " & iCustID & Environment.NewLine
                strSQL &= "AND Loc_ID = " & iLocID & Environment.NewLine
                strSQL &= "AND Pallett_ReadyToShipFlg = 0 " & Environment.NewLine
                strSQL &= "AND Pallett_Name like '" & iMchCCGrpID & "%' " & Environment.NewLine
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

        '******************************************************************
        Public Function CreateBoxID(ByVal iCustID As Integer, _
                                    ByVal iLocID As Integer, _
                                    ByVal strPalletPrefix As String) As Integer
            Dim strSql As String = ""
            Dim strDate As String = ""
            Dim strPalletName As String = ""
            Dim iPalletID As Integer = 0

            Try
                '******************************
                'construct pallet name
                '******************************
                strDate = Generic.GetMySqlDateTime("%y%m%d")

                strPalletPrefix = strPalletPrefix + "DC" + strDate & "N"

                strPalletName = Me.DefinePalletName(strPalletPrefix)

                '******************************
                'check for duplicate pallet
                '******************************
                strSql = "Select count(*) as cnt From tpallett where Pallett_Name = '" & strPalletName & "' "
                If Me._objDataProc.GetIntValue(strSql) > 0 Then Throw New Exception("System is trying to create pallet (" & strPalletName & ") which is already existed in system.")

                '******************************
                'Create pallet
                ''******************************
                strSql = "INSERT INTO tpallett ( " & Environment.NewLine
                strSql &= "Pallett_Name " & Environment.NewLine
                strSql &= ", Cust_ID  " & Environment.NewLine
                strSql &= ", Loc_ID  " & Environment.NewLine
                strSql &= ") VALUES (  " & Environment.NewLine
                strSql &= "'" & strPalletName & "' " & Environment.NewLine
                strSql &= ", " & iCustID & Environment.NewLine
                strSql &= ", " & iLocID & Environment.NewLine
                strSql &= ")"
                iPalletID = Me._objDataProc.idTransaction(strSql, "tpallett")

                If iPalletID = 0 Then iPalletID = Me.GetLastPalletID(strPalletName)

                '******************************

                Return iPalletID
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Private Function DefinePalletName(ByVal strPalletPrefix As String) As String
            Dim strSQL As String
            Dim dt As DataTable
            Dim strPallett_Name As String = strPalletPrefix

            Try
                strSQL = "SELECT max(right(Pallett_Name, 3) ) + 1 as Pallett_Num " & Environment.NewLine
                strSQL &= "FROM tpallett " & Environment.NewLine
                strSQL &= "WHERE Pallett_Name like '" & strPalletPrefix & "%' " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSQL)
                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows(0)("Pallett_Num")) Then
                        strPallett_Name &= Format(dt.Rows(0)("Pallett_Num"), "000")
                    Else
                        strPallett_Name &= "001"
                    End If
                Else
                    strPallett_Name &= "001"
                End If

                Return strPallett_Name
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetLastPalletID(ByVal strPalletName As String) As Integer
            Dim strSQL As String
            Dim dt As DataTable
            Dim iPalletID As Integer = 0

            Try
                strSQL = "SELECT Pallett_ID " & Environment.NewLine
                strSQL &= "FROM tpallett " & Environment.NewLine
                strSQL &= "WHERE Pallett_Name = '" & strPalletName & "' " & Environment.NewLine
                strSQL &= "AND Pallet_Invalid = 0 " & Environment.NewLine
                strSQL &= "ORDER BY Pallett_ID DESC"
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
        Public Function GetDeviceInfoInWIP(ByVal strSN As String, _
                                           ByVal iLocID As Integer) As DataTable
            Dim strSQL As String
            Dim dt As DataTable

            Try
                strSQL = "SELECT tdevice.*, tcellopt.Cellopt_WIPOwner as wipowner_id, RUR_ReturnToCust, tmodel.Model_Type " & Environment.NewLine
                strSQL &= "FROM tdevice " & Environment.NewLine
                strSQL &= "INNER JOIN tcellopt ON tdevice.Device_ID = tcellopt.Device_ID " & Environment.NewLine
                strSQL &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSQL &= "WHERE Device_SN = '" & strSN & "' " & Environment.NewLine
                strSQL &= "AND Loc_ID = " & iLocID & Environment.NewLine
                strSQL &= "AND (Device_DateShip is null OR Device_DateShip = '0000-00-00 00:00:00' or Device_DateShip  = '') " & Environment.NewLine
                strSQL &= "ORDER BY Device_ID DESC"
                Return Me._objDataProc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetDeviceBillingInfo(ByVal iDeviceID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT tdevicebill.*, BillCode_Rule, BillType_ID " & Environment.NewLine
                strSql &= "FROM tdevicebill " & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes ON tdevicebill.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
                strSql &= "WHERE tdevicebill.Device_ID = " & iDeviceID & Environment.NewLine
                strSql &= "ORDER BY lbillcodes.BillCode_Rule Desc " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        ''******************************************************************
        'Public Function CloseAndShipPallet(ByVal iCustID As Integer, _
        '                                   ByVal iPalletID As Integer, _
        '                                   ByVal iPalletQty As Integer, _
        '                                   ByVal iShiftID As Integer) As Integer
        '    Dim strSql As String = ""
        '    Dim strWkdate As String = ""

        '    Try
        '        strWkdate = Generic.GetWorkDate(iShiftID)
        '        strSql = "UPDATE tpallett, tdevice, tcellopt " & Environment.NewLine
        '        strSql &= "SET Pallett_ReadyToShipFlg = 1" & Environment.NewLine
        '        strSql &= ", Pallett_QTY = " & iPalletQty & Environment.NewLine
        '        strSql &= ", Pallett_ShipDate = '" & strWkdate & "' " & Environment.NewLine
        '        strSql &= ", Pallett_BulkShipped = 1 " & " " & Environment.NewLine

        '        'strSql &= ", Ship_ID = " & iShip_ID & " " & Environment.NewLine
        '        strSql &= ", Shift_ID_Ship = " & iShiftID & " " & Environment.NewLine
        '        strSql &= ", Device_SendClaim = 0 " & Environment.NewLine
        '        strSql &= ", Device_DateShip = now() " & Environment.NewLine
        '        strSql &= ", Device_ShipWorkDate = '" & strWkdate & "' " & Environment.NewLine
        '        strSql &= ", Device_FinishedGoods = 1 " & " " & Environment.NewLine

        '        strSql &= ", Cellopt_WIPOwnerOld = Cellopt_WIPOwner " & Environment.NewLine
        '        strSql &= ", Cellopt_WIPOwner = 5 " & " " & Environment.NewLine        ' Ready Toship
        '        strSql &= ", Cellopt_WIPEntryDt = now() " & Environment.NewLine

        '        strSql &= "WHERE tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
        '        strSql &= "AND tdevice.Device_ID = tcellopt.Device_ID " & Environment.NewLine
        '        strSql &= "AND tpallett.Pallett_id = " & iPalletID.ToString

        '        Return Me._objDataProc.ExecuteNonQuery(strSql)
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Function

        '******************************************************************
        Public Function GetCustIDByWOID(ByVal iWOID As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "SELECT Cust_ID " & Environment.NewLine
                strSql &= "FROM tworkorder " & Environment.NewLine
                strSql &= "INNER JOIN tlocation ON tworkorder.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strSql &= "WHERE tworkorder.WO_ID = " & iWOID & Environment.NewLine
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetDCPallet(ByVal strPallet As String, ByVal icustID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT DISTINCT tpallett.* " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "WHERE tpallett.Pallett_Name = '" & strPallet & "' " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function IsAQLPassed(ByVal iDeviceID As Integer) As Boolean
            Dim strSql As String = ""

            Try
                strSql = "SELECT count(*) as cnt " & Environment.NewLine
                strSql &= "FROM tqc " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & " " & Environment.NewLine
                strSql &= "AND tqc.QCtype_ID = 4 AND tqc.QCResult_ID = 1 " & Environment.NewLine
                If Me._objDataProc.GetIntValue(strSql) > 0 Then Return True Else Return False
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************


#End Region

#Region "Dock Shipping"
        '******************************************************************
        Public Function GetPalletWaitingShipment() As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT Distinct if(Cust_Name2 is null, Cust_Name1, CONCAT(Cust_Name1, ' ', Cust_Name2)) as 'Customer'" & Environment.NewLine
                strSql &= ", Pallett_Name as 'Box Name', count(*) as 'Qty', Pallett_ShipDate as 'Prod Completion Date' " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "INNER JOIN tdevice ON tpallett.Pallett_ID = tdevice.Pallett_ID " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN tcustomer ON tpallett.Cust_ID = tcustomer.Cust_ID " & Environment.NewLine
                strSql &= "WHERE tpallett.pkslip_ID is null AND Pallet_invalid = 0 " & Environment.NewLine
                strSql &= "AND tmodel.Prod_ID = 9 " & Environment.NewLine
                'strSql &= "AND tcustomer.PCo_ID = " & DriveCam.PARENTCOMP_ID & Environment.NewLine
                strSql &= "AND tpallett.Pallett_ShipDate is not null AND tpallett.Pallett_BulkShipped = 1 " & Environment.NewLine
                strSql &= "AND tpallett.Pallett_ID <> " & DriveCam.RUR_SCRAP_PALLETID & Environment.NewLine
                strSql &= "AND tdevice.Device_Invoice = 1 " & Environment.NewLine
                strSql &= "GROUP BY tdevice.Pallett_ID " & Environment.NewLine
                strSql &= "ORDER BY Customer, Pallett_Name  " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetDriveCamDockShipmentUpdatedToday() As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT DISTINCT tpackingslip.pkslip_ID as 'Packing ID' " & Environment.NewLine
                strSql &= ", if(Cust_Name2 is null, Cust_Name1, CONCAT(Cust_Name1, ' ', Cust_Name2)) as 'Customer' " & Environment.NewLine
                strSql &= ", tpallett.Pallett_Name as 'Box Name' " & Environment.NewLine
                strSql &= ", tpallett.Pallett_QTY as 'Qty' " & Environment.NewLine
                strSql &= ", tpackingslip.pkslip_TrackNo as 'Tracking #' " & Environment.NewLine
                strSql &= ", tpackingslip.pkslip_DockShipDate as 'Dock Ship Date' " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "INNER JOIN tdevice ON tpallett.Pallett_ID = tdevice.Pallett_ID " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN tcustomer ON tpallett.Cust_ID = tcustomer.Cust_ID " & Environment.NewLine
                strSql &= "INNER JOIN tpackingslip ON tpallett.pkslip_ID = tpackingslip.pkslip_ID " & Environment.NewLine
                strSql &= "WHERE date_format(tpackingslip.pkSlip_DSUpdateDate, '%Y-%m-%d') = date_format(now(), '%Y-%m-%d') " & Environment.NewLine
                strSql &= "AND tmodel.Prod_ID = 9 " & Environment.NewLine
                strSql &= "ORDER BY tpackingslip.pkslip_ID " & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetDriveCamePallet(ByVal strPalletName As String) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT DISTINCT tpallett.*, tcustomer.Pay_ID " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "INNER JOIN tdevice ON tpallett.pallett_ID = tdevice.Pallett_ID " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN tcustomer ON tpallett.Cust_ID = tcustomer.Cust_ID " & Environment.NewLine
                'strSql &= "WHERE tcustomer.PCo_ID = " & DriveCam.PARENTCOMP_ID & Environment.NewLine
                strSql &= "WHERE tpallett.Pallett_Name = '" & strPalletName & "' " & Environment.NewLine
                strSql &= "AND tmodel.Prod_ID = 9 " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetNoInvoiceFlagCount(ByVal strPalletIDs As Integer) As Integer
            Dim strSql As String = ""
            Try
                strSql = "SELECT count(*) as cnt " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "WHERE pallett_ID in ( " & strPalletIDs & ") " & Environment.NewLine
                strSql &= "AND Device_Invoice = 0 " & Environment.NewLine
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function CreateDetailManifestReport() As Integer
            Dim strSql As String = ""
            Dim strReplaceChar As String = ""
            Dim dt, dt1 As DataTable
            Dim R1, R2 As DataRow
            Dim i As Integer = 0
            Dim objRpt As ReportDocument
            Dim strRptName As String = "DriveCam Credit Card Summary Invoice Push.rpt"
            Dim strReportLoc As String = PSS.Data.ConfigFile.GetBaseReportPath()

            Try
                'strReportLoc = "C:\Documents and Settings\languyen\Desktop\"

                strSql = "SELECT DISTINCT tdevice.Pallett_ID, Pallett_Name " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tpallett on tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                strSql &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strSql &= "INNER JOIN tcustomer ON tlocation.Cust_ID = tcustomer.Cust_ID " & Environment.NewLine
                strSql &= "WHERE (tpallett.pkslip_ID is null or tpallett.pkslip_ID = 0) " & Environment.NewLine
                strSql &= "AND Device_DateShip is not null " & Environment.NewLine
                strSql &= "AND tcustomer.PCo_ID = " & DriveCam.PARENTCOMP_ID & Environment.NewLine
                strSql &= "AND Device_Invoice = 1 " & Environment.NewLine
                'strSql &= "AND tdevice.Pallett_ID = 144055 " & Environment.NewLine
                'strSql &= "AND (BillwCode_ID <> 1592 or (BillCode_ID = 1592 and RUR_ReturnToCust = 1 )) " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    For Each R1 In dt.Rows
                        If Me.GetNoInvoiceFlagCount(R1("Pallett_ID")) > 0 Then
                            MessageBox.Show("Box name " & R1("Pallett_Name") & " contains units without invoice flag.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            Generic.DisposeDT(dt1)
                            strSql = "SELECT BillCode_Desc " & Environment.NewLine
                            strSql &= ", Prod_Desc " & Environment.NewLine
                            strSql &= ", tcustomer.Cust_ID " & Environment.NewLine
                            strSql &= ", Cust_Name1 " & Environment.NewLine
                            strSql &= ", Cust_Name2 " & Environment.NewLine
                            strSql &= ", tdevice.Device_ID " & Environment.NewLine
                            strSql &= ", Device_SN " & Environment.NewLine
                            strSql &= ", Device_OldSN " & Environment.NewLine
                            strSql &= ", Device_ManufWrty " & Environment.NewLine
                            strSql &= ", Device_PSSWrty " & Environment.NewLine
                            strSql &= ", Device_LaborCharge " & Environment.NewLine
                            strSql &= ", tdevice.Pallett_ID " & Environment.NewLine
                            strSql &= ", Ship_ID " & Environment.NewLine
                            strSql &= ", Sum(DBill_InvoiceAmt) as  DBill_InvoiceAmt" & Environment.NewLine
                            strSql &= ", tdevicebill.BillCode_ID " & Environment.NewLine
                            strSql &= ", Max(lbillcodes.BillCode_Rule) as BillCode_Rule " & Environment.NewLine
                            strSql &= ", Loc_Name " & Environment.NewLine
                            strSql &= ", Model_Desc " & Environment.NewLine
                            strSql &= ", Pallett_Name " & Environment.NewLine
                            strSql &= ", RUR_ReturnToCust " & Environment.NewLine
                            strSql &= ", tworkorder.Prod_ID " & Environment.NewLine
                            strSql &= ", lcctype.CCType_Desc as CCType_Desc " & Environment.NewLine
                            strSql &= ", tdrivecamdata.CreditCard_Num as CreditCard_Num " & Environment.NewLine
                            strSql &= ", CreditCard_AuthCode as CreditCard_AuthCode " & Environment.NewLine
                            strSql &= ", 'xx/xx' as CreditCard_ExpDate " & Environment.NewLine
                            strSql &= "FROM tdevice " & Environment.NewLine
                            strSql &= "INNER JOIN tdrivecamdata ON tdevice.Device_ID = tdrivecamdata.Device_ID " & Environment.NewLine
                            strSql &= "INNER JOIN lcctype ON tdrivecamdata.CCardType_ID = lcctype.CCType_ID " & Environment.NewLine
                            strSql &= "INNER JOIN tpallett ON tdevice.pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                            strSql &= "INNER JOIN tcellopt ON tdevice.Device_ID = tcellopt.Device_ID " & Environment.NewLine
                            strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                            strSql &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                            strSql &= "INNER JOIN tcustomer ON tlocation.Cust_ID = tcustomer.Cust_ID " & Environment.NewLine
                            strSql &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                            strSql &= "INNER JOIN lproduct ON tworkorder.Prod_ID = lproduct.Prod_ID " & Environment.NewLine
                            strSql &= "INNER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID " & Environment.NewLine
                            strSql &= "INNER JOIN lbillcodes ON tdevicebill.Billcode_ID = lbillcodes.Billcode_ID " & Environment.NewLine
                            strSql &= "WHERE tdevice.Pallett_ID = " & R1("Pallett_ID") & Environment.NewLine
                            strSql &= "AND tcustomer.PCo_ID = " & DriveCam.PARENTCOMP_ID & Environment.NewLine
                            strSql &= "AND Device_Invoice = 1 " & Environment.NewLine
                            strSql &= "Group by tdevice.Device_ID "
                            'strSql &= "AND (BillwCode_ID <> 1592 or (BillCode_ID = 1592 and RUR_ReturnToCust = 1 )) " & Environment.NewLine
                            dt1 = Me._objDataProc.GetDataTable(strSql)

                            For Each R2 In dt1.Rows
                                For i = 1 To R2("CreditCard_Num").ToString.Trim.Length - 4 : strReplaceChar &= "x" : Next i
                                R2.BeginEdit()
                                R2("CreditCard_Num") = strReplaceChar & Mid(R2("CreditCard_Num").ToString.Trim, R2("CreditCard_Num").ToString.Trim.Length - 3, 4)
                                strReplaceChar = ""
                                For i = 1 To R2("CreditCard_AuthCode").ToString.Trim.Length : strReplaceChar &= "x" : Next i
                                R2("CreditCard_AuthCode") = strReplaceChar
                                R2.EndEdit()
                            Next R2
                            dt1.AcceptChanges()

                            objRpt = New ReportDocument()

                            With objRpt
                                .Load(strReportLoc & strRptName)
                                .SetDataSource(dt1)
                                .PrintToPrinter(1, True, 0, 0)
                            End With
                        End If
                    Next R1
                Else
                    MessageBox.Show("No data found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

                Return dt.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************


#End Region

#Region "Admin"
        '******************************************************************
        Public Function GetHoldUnits() As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT if(Cust_Name2 is null, Cust_Name1, CONCAT(Cust_Name1, ' ', Cust_Name2)) as 'Customer'" & Environment.NewLine
                strSql &= ", WO_CustWO as 'Wo Name' " & Environment.NewLine
                strSql &= ", tworkorder.WO_ID as 'Wo ID' " & Environment.NewLine
                strSql &= ", Device_SN as 'S/N' " & Environment.NewLine
                strSql &= ", Cellopt_WIPEntryDt as 'Hold Date' " & Environment.NewLine
                strSql &= ", if(Loc_Phone is null, '', Loc_Phone) as 'Phone' " & Environment.NewLine
                strSql &= ", if(Loc_Email is null, '', Loc_Email) as 'Email' " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strSql &= "INNER JOIN tcustomer ON tlocation.Cust_ID = tcustomer.Cust_ID " & Environment.NewLine
                strSql &= "INNER JOIN tcellopt ON tdevice.Device_ID = tcellopt.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                strSql &= "WHERE Device_DateShip is null " & Environment.NewLine
                'strSql &= "AND tcustomer.PCo_ID = " & DriveCam.PARENTCOMP_ID & Environment.NewLine
                strSql &= "AND tworkorder.Prod_ID = " & DriveCam.PRODID & Environment.NewLine
                strSql &= "AND tcellopt.Cellopt_WIPOwner = 6 " & Environment.NewLine
                strSql &= "ORDER BY Customer, 'Wo Name', 'S/N' " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetApprovedUnApprovedUntis() As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT if(Cust_Name2 is null, Cust_Name1, CONCAT(Cust_Name1, ' ', Cust_Name2)) as 'Customer'" & Environment.NewLine
                strSql &= ", WO_CustWO as 'Wo Name' " & Environment.NewLine
                strSql &= ", tworkorder.WO_ID as 'Wo ID' " & Environment.NewLine
                strSql &= ", Device_SN as 'S/N' " & Environment.NewLine
                strSql &= ", if(OnHoldDate is null, '', OnHoldDate) as 'On Hold Date' " & Environment.NewLine
                strSql &= ", if(ReleaseFrHoldDate is null, '', ReleaseFrHoldDate) as 'Approved Date' " & Environment.NewLine
                strSql &= ", if(ReleaseFrHoldDate is not null, if(CompactFlashApproved = 1, 'YES','NO'), '') as 'CF Approved?' " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strSql &= "INNER JOIN tcustomer ON tlocation.Cust_ID = tcustomer.Cust_ID " & Environment.NewLine
                strSql &= "INNER JOIN tdrivecamdata ON tdevice.Device_ID = tdrivecamdata.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                strSql &= "WHERE Device_DateShip is null " & Environment.NewLine
                'strSql &= "AND tcustomer.PCo_ID = " & DriveCam.PARENTCOMP_ID & Environment.NewLine
                strSql &= "AND tworkorder.Prod_ID = " & DriveCam.PRODID & Environment.NewLine
                strSql &= "AND tdrivecamdata.ReleaseFrHoldDate is not null " & Environment.NewLine
                strSql &= "ORDER BY Customer, 'Wo Name', 'S/N' " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function UpdateCFlashApproveStatus(ByVal strSN As String, _
                                                  ByVal iStatus As Integer, _
                                                  ByVal iUsrID As Integer, _
                                                  ByRef iDeviceID As Integer) As Boolean
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim booResult As Boolean = False
            Dim i As Integer = 0

            Try
                strSql = "SELECT Cellopt_WIPOwner " & Environment.NewLine
                strSql &= ", tdevice.Device_ID " & Environment.NewLine
                strSql &= ", Device_SN as 'S/N' " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tcellopt ON tdevice.Device_ID = tcellopt.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN tdrivecamdata ON tdevice.Device_ID = tdrivecamdata.Device_ID " & Environment.NewLine
                strSql &= "WHERE Device_SN = '" & strSN & "'" & Environment.NewLine
                strSql &= "AND (Device_DateShip is null or Device_DateShip = '' or Device_DateShip = '0000-00-00 00:00:00' )" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count = 0 Then
                    MessageBox.Show("S/N does not exist in WIP.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dt.Rows.Count > 1 Then
                    MessageBox.Show("S/N does not exist more than one in WIP.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    If dt.Rows(0)("Cellopt_WIPOwner") <> 6 Then
                        MessageBox.Show("S/N is not on hold.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        strSql = "UPDATE tdrivecamdata, tcellopt" & Environment.NewLine
                        strSql &= "SET ReleaseFrHoldDate = now() " & Environment.NewLine
                        strSql &= ", ReleaseUsrID = " & iUsrID & Environment.NewLine
                        strSql &= ", CompactFlashApproved = " & iStatus & Environment.NewLine
                        strSql &= ", Cellopt_WIPEntryDt = now(), Cellopt_WIPOwnerOld = Cellopt_WIPOwner, Cellopt_WIPOwner = 3 " & Environment.NewLine
                        strSql &= "WHERE tdrivecamdata.Device_ID = tcellopt.Device_ID " & Environment.NewLine
                        strSql &= "AND tdrivecamdata.Device_ID = " & dt.Rows(0)("Device_ID")
                        i = Me._objDataProc.ExecuteNonQuery(strSql)
                        If i > 0 Then
                            booResult = True
                            iDeviceID = dt.Rows(0)("Device_ID")
                        End If
                    End If
                End If

                Return booResult
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetDriveCamTobeInvoicingUnits() As DataTable
            Dim strSql, strDeviceIDs As String
            Dim dt, dtPartsServicesCost As DataTable
            Dim R1 As DataRow

            Try
                strDeviceIDs = ""

                strSql = "SELECT if(Cust_Name2 is null, Cust_Name1, CONCAT(Cust_Name1, ' ', Cust_Name2)) as 'Customer'" & Environment.NewLine
                strSql &= ", Pallett_Name as 'Box Name' " & Environment.NewLine
                strSql &= ", tdevice.Pallett_ID as 'Pallett_ID' " & Environment.NewLine
                strSql &= ", Device_SN as 'S/N' " & Environment.NewLine
                strSql &= ", Device_DateShip as 'Prod Completion' " & Environment.NewLine
                strSql &= ", Device_LaborCharge as 'Labor' " & Environment.NewLine
                strSql &= ", 0 as 'Parts/Services' " & Environment.NewLine
                strSql &= ", tdevice.Device_ID " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strSql &= "INNER JOIN tcustomer ON tlocation.Cust_ID = tcustomer.Cust_ID " & Environment.NewLine
                strSql &= "INNER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                strSql &= "WHERE tdevice.pallett_ID <> 144029 AND tdevice.Pallett_ID is not null " & Environment.NewLine
                strSql &= "AND tcustomer.PCo_ID = " & DriveCam.PARENTCOMP_ID & Environment.NewLine
                strSql &= "AND Device_Invoice = 0 " & Environment.NewLine
                strSql &= "AND Device_DateShip is not null " & Environment.NewLine
                strSql &= "ORDER By Customer, 'Box Name', 'S/N' " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    For Each R1 In dt.Rows
                        If strDeviceIDs.Trim.Length > 0 Then strDeviceIDs &= ","
                        strDeviceIDs &= R1("Device_ID")
                    Next R1

                    strSql = "SELECT Sum(DBill_InvoiceAmt) as 'PartsServicesCost', Device_ID " & Environment.NewLine
                    strSql &= "FROM tdevicebill " & Environment.NewLine
                    strSql &= "WHERE Device_ID IN ( " & strDeviceIDs & " ) " & Environment.NewLine
                    strSql &= "GROUP BY Device_ID" & Environment.NewLine
                    dtPartsServicesCost = Me._objDataProc.GetDataTable(strSql)

                    For Each R1 In dt.Rows
                        R1.BeginEdit()
                        R1("Parts/Services") = dtPartsServicesCost.Select("Device_ID = " & R1("Device_ID"))(0)("PartsServicesCost")
                        R1.EndEdit()
                    Next R1
                End If
                dt.Columns.Remove("Device_ID")
                dt.AcceptChanges()

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
                Generic.DisposeDT(dtPartsServicesCost)
            End Try
        End Function

        '******************************************************************
        Public Function CreateInvoiceReport(ByVal strFrShipDate As String, _
                                            ByVal strToShipDate As String, _
                                            ByVal iUsrID As Integer) As Integer
            Dim strSql, strDecriptMsg As String
            Dim dt, dt1, dtCC As DataTable
            Dim R1 As DataRow
            Dim i As Integer = 0
            Dim objRpt As ReportDocument
            Dim strRptName As String = "DriveCam Credit Card Invoice Push.rpt"
            Dim strReportLoc As String = PSS.Data.ConfigFile.GetBaseReportPath()
            Dim strCCType, strCCNo, strCCSecurityCode, strCCExpDate As String
            Dim iCCID As Integer = 0

            Try
                'strReportLoc = "C:\Documents and Settings\languyen\Desktop\"

                strSql = "SELECT DISTINCT tdevice.Pallett_ID, tlocation.Cust_ID " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strSql &= "INNER JOIN tcustomer ON tlocation.Cust_ID = tcustomer.Cust_ID " & Environment.NewLine
                strSql &= "WHERE tdevice.Pallett_ID <> 144029 AND Pallett_ID is not null " & Environment.NewLine
                strSql &= "AND tcustomer.PCo_ID = " & DriveCam.PARENTCOMP_ID & Environment.NewLine
                strSql &= "AND Device_Invoice = 0 " & Environment.NewLine
                strSql &= "AND Device_ShipWorkDate between '" & strFrShipDate & "' AND '" & strToShipDate & "' " & Environment.NewLine
                'strSql &= "AND (BillwCode_ID <> 1592 or (BillCode_ID = 1592 and RUR_ReturnToCust = 1 )) " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    For Each R1 In dt.Rows
                        Generic.DisposeDT(dt1)
                        Generic.DisposeDT(dtCC)
                        strCCType = "" : strCCNo = "" : strCCSecurityCode = "" : strCCExpDate = ""
                        iCCID = 0

                        'Get Credit Card Info
                        strSql = "SELECT tcreditcard.CCardType_ID " & Environment.NewLine
                        strSql &= ", lcctype.CCType_Desc " & Environment.NewLine
                        strSql &= ", tcreditcard.CreditCard_Num " & Environment.NewLine
                        strSql &= ", tcreditcard.CreditCard_AuthCode " & Environment.NewLine
                        strSql &= ", tcreditcard.CreditCard_ExpDate " & Environment.NewLine
                        strSql &= "FROM tcreditcard " & Environment.NewLine
                        strSql &= "INNER JOIN lcctype ON tcreditcard.CCardType_ID = lcctype.CCType_ID " & Environment.NewLine
                        strSql &= "WHERE tcreditcard.Cust_ID = " & R1("Cust_ID") & Environment.NewLine
                        strSql &= "ORDER BY tcreditcard.CreditCard_ID DESC " & Environment.NewLine
                        dtCC = Me._objDataProc.GetDataTable(strSql)

                        If dtCC.Rows.Count > 0 Then
                            strDecriptMsg = ""
                            If Not IsDBNull(dtCC.Rows(0)("CCType_Desc")) Then strCCType = dtCC.Rows(0)("CCType_Desc")
                            If Not IsDBNull(dtCC.Rows(0)("CreditCard_Num")) Then
                                strCCNo = dtCC.Rows(0)("CreditCard_Num")
                                strCCNo = EncDec.Rijndael.Decrypt(strCCNo, strDecriptMsg)
                            End If

                            If Not IsDBNull(dtCC.Rows(0)("CreditCard_AuthCode")) Then
                                strCCSecurityCode = dtCC.Rows(0)("CreditCard_AuthCode")
                                strCCSecurityCode = EncDec.Rijndael.Decrypt(strCCSecurityCode, strDecriptMsg)
                            End If

                            If Not IsDBNull(dtCC.Rows(0)("CreditCard_ExpDate")) Then strCCExpDate = dtCC.Rows(0)("CreditCard_ExpDate")
                            iCCID = dtCC.Rows(0)("CCardType_ID")

                            'Replace credit card # with X except last 4 digits
                            strCCNo = Right(strCCNo, 4).PadLeft(strCCNo.Length, "x")
                            strCCSecurityCode = "x".PadLeft(strCCSecurityCode.Length, "x")
                        End If

                        strSql = "SELECT BillCode_Desc " & Environment.NewLine
                        strSql &= ", Prod_Desc " & Environment.NewLine
                        strSql &= ", tcustomer.Cust_ID " & Environment.NewLine
                        strSql &= ", Cust_Name1 " & Environment.NewLine
                        strSql &= ", Cust_Name2 " & Environment.NewLine
                        strSql &= ", tdevice.Device_ID " & Environment.NewLine
                        strSql &= ", Device_SN " & Environment.NewLine
                        strSql &= ", Device_OldSN " & Environment.NewLine
                        strSql &= ", Device_ManufWrty " & Environment.NewLine
                        strSql &= ", Device_PSSWrty " & Environment.NewLine
                        strSql &= ", Device_LaborCharge " & Environment.NewLine
                        strSql &= ", tdevice.Pallett_ID " & Environment.NewLine
                        strSql &= ", Ship_ID " & Environment.NewLine
                        strSql &= ", IF(DBill_InvoiceAmt IS NULL, 0.00, DBill_InvoiceAmt ) as DBill_InvoiceAmt " & Environment.NewLine
                        strSql &= ", IF(tdevicebill.BillCode_ID IS NULL, 0, tdevicebill.BillCode_ID) AS BillCode_ID " & Environment.NewLine
                        strSql &= ", IF(lbillcodes.BillCode_Rule, 0, lbillcodes.BillCode_Rule) AS BillCode_Rule " & Environment.NewLine
                        strSql &= ", Loc_Name " & Environment.NewLine
                        strSql &= ", Model_Desc " & Environment.NewLine
                        strSql &= ", Pallett_Name " & Environment.NewLine
                        strSql &= ", RUR_ReturnToCust " & Environment.NewLine
                        strSql &= ", tworkorder.Prod_ID " & Environment.NewLine
                        strSql &= ", '" & strCCType & "' as CCType_Desc " & Environment.NewLine
                        strSql &= ", '" & strCCNo & "' as CreditCard_Num " & Environment.NewLine
                        strSql &= ", '" & strCCSecurityCode & "' as CreditCard_AuthCode " & Environment.NewLine
                        strSql &= ", '" & strCCExpDate & "' as CreditCard_ExpDate " & Environment.NewLine
                        strSql &= ", IF(tworkorder.PO_ID > 0, tworkorder.PO_ID, '') as BillingPOID " & Environment.NewLine
                        strSql &= "FROM tdevice " & Environment.NewLine
                        strSql &= "INNER JOIN tpallett ON tdevice.pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                        strSql &= "INNER JOIN tcellopt ON tdevice.Device_ID = tcellopt.Device_ID " & Environment.NewLine
                        strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                        strSql &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                        strSql &= "INNER JOIN tcustomer ON tlocation.Cust_ID = tcustomer.Cust_ID " & Environment.NewLine
                        strSql &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                        strSql &= "INNER JOIN lproduct ON tworkorder.Prod_ID = lproduct.Prod_ID " & Environment.NewLine
                        strSql &= "LEFT OUTER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID AND DBill_InvoiceAmt > 0 " & Environment.NewLine
                        strSql &= "LEFT OUTER JOIN lbillcodes ON tdevicebill.Billcode_ID = lbillcodes.Billcode_ID " & Environment.NewLine
                        strSql &= "WHERE tdevice.Pallett_ID = " & R1("Pallett_ID") & Environment.NewLine
                        strSql &= "AND tdevice.Pallett_ID is not null " & Environment.NewLine
                        strSql &= "AND tcustomer.PCo_ID = " & DriveCam.PARENTCOMP_ID & Environment.NewLine
                        strSql &= "AND Device_Invoice = 0 " & Environment.NewLine
                        strSql &= "AND Device_ShipWorkDate between '" & strFrShipDate & "' AND '" & strToShipDate & "' " & Environment.NewLine
                        'strSql &= "AND (BillwCode_ID <> 1592 or (BillCode_ID = 1592 and RUR_ReturnToCust = 1 )) " & Environment.NewLine
                        dt1 = Me._objDataProc.GetDataTable(strSql)

                        objRpt = New ReportDocument()

                        With objRpt
                            .Load(strReportLoc & strRptName)
                            .SetDataSource(dt1)
                            .PrintToPrinter(1, True, 0, 0)
                        End With

                        strSql = "UPDATE " & Environment.NewLine
                        strSql &= "tdevice, tdrivecamdata " & Environment.NewLine
                        strSql &= "SET Device_Invoice = 1 " & Environment.NewLine
                        strSql &= ", InvoicingDT = now(), InvoicingUsrID = " & iUsrID & Environment.NewLine
                        strSql &= ", CCardType_ID = " & iCCID & Environment.NewLine
                        strSql &= ", CreditCard_Num = '" & strCCNo & "'" & Environment.NewLine
                        strSql &= ", CreditCard_AuthCode = '" & strCCSecurityCode & "'" & Environment.NewLine
                        strSql &= ", CreditCard_ExpDate = '" & strCCExpDate & "'" & Environment.NewLine
                        strSql &= "WHERE tdevice.Device_ID = tdrivecamdata.Device_ID " & Environment.NewLine
                        strSql &= "AND tdevice.Pallett_ID = " & R1("Pallett_ID") & Environment.NewLine
                        strSql &= "AND Device_Invoice = 0 " & Environment.NewLine
                        strSql &= "AND Device_ShipWorkDate between '" & strFrShipDate & "' AND '" & strToShipDate & "' " & Environment.NewLine
                        'strSql &= "AND (BillwCode_ID <> 1592 or (BillCode_ID = 1592 and RUR_ReturnToCust = 1 )) " & Environment.NewLine
                        i += Me._objDataProc.ExecuteNonQuery(strSql)

                    Next R1
                Else
                    MessageBox.Show("No data for selected ship.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function ReprintInvoiceReport(ByVal strPalletName As String) As Integer
            Dim strSql, strDecriptMsg As String
            Dim dt, dt1, dtCC As DataTable
            Dim i As Integer = 0
            Dim objRpt As ReportDocument
            Dim strRptName As String = "DriveCam Credit Card Invoice Push.rpt"
            Dim strReportLoc As String = PSS.Data.ConfigFile.GetBaseReportPath()
            Dim strCCType, strCCNo, strCCSecurityCode, strCCExpDate As String
            Dim iCCID As Integer = 0

            Try
                strSql = "SELECT DISTINCT tpallett.Pallett_ID, tpallett.Cust_ID, Cust_InvoiceDetail, Pay_ID " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "INNER JOIN tcustomer ON tpallett.Cust_ID = tcustomer.Cust_ID " & Environment.NewLine
                strSql &= "WHERE Pallett_name = '" & strPalletName & "'" & Environment.NewLine
                'strSql &= "AND (BillwCode_ID <> 1592 or (BillCode_ID = 1592 and RUR_ReturnToCust = 1 )) " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count = 0 Then
                    Throw New Exception("Box Name does not exist.")
                ElseIf dt.Rows.Count > 1 Then
                    Throw New Exception("Box Name existed more than one.")
                ElseIf dt.Rows(0)("Cust_InvoiceDetail") = 1 Or dt.Rows(0)("Pay_ID") = 1 Then
                    Throw New Exception("Credit card invoice is not allowed for this customer.")
                Else
                    strSql = "SELECT count(*) as cnt FROM tdevice WHERE Pallett_ID = " & dt.Rows(0)("Pallett_ID") & " AND Device_Invoice = 0" & Environment.NewLine
                    If Me._objDataProc.GetIntValue(strSql) > 0 Then Throw New Exception("Unit(s) in this box have not yet invoiced. Please run invoicing report instead of reprint.")

                    strCCType = "" : strCCNo = "" : strCCSecurityCode = "" : strCCExpDate = ""
                    iCCID = 0

                    'Get Credit Card Info
                    strSql = "SELECT tcreditcard.CCardType_ID " & Environment.NewLine
                    strSql &= ", lcctype.CCType_Desc " & Environment.NewLine
                    strSql &= ", tcreditcard.CreditCard_Num " & Environment.NewLine
                    strSql &= ", tcreditcard.CreditCard_AuthCode " & Environment.NewLine
                    strSql &= ", tcreditcard.CreditCard_ExpDate " & Environment.NewLine
                    strSql &= "FROM tcreditcard " & Environment.NewLine
                    strSql &= "INNER JOIN lcctype ON tcreditcard.CCardType_ID = lcctype.CCType_ID " & Environment.NewLine
                    strSql &= "WHERE tcreditcard.Cust_ID = " & dt.Rows(0)("Cust_ID") & Environment.NewLine
                    strSql &= "ORDER BY tcreditcard.CreditCard_ID DESC " & Environment.NewLine
                    dtCC = Me._objDataProc.GetDataTable(strSql)

                    If dtCC.Rows.Count > 0 Then
                        If Not IsDBNull(dtCC.Rows(0)("CCType_Desc")) Then strCCType = dtCC.Rows(0)("CCType_Desc")
                        If Not IsDBNull(dtCC.Rows(0)("CreditCard_Num")) Then
                            strCCNo = dtCC.Rows(0)("CreditCard_Num")
                            strCCNo = EncDec.Rijndael.Decrypt(strCCNo, strDecriptMsg)
                        End If
                        If Not IsDBNull(dtCC.Rows(0)("CreditCard_AuthCode")) Then
                            strCCSecurityCode = dtCC.Rows(0)("CreditCard_AuthCode")
                            strCCSecurityCode = EncDec.Rijndael.Decrypt(strCCSecurityCode, strDecriptMsg)
                        End If
                        If Not IsDBNull(dtCC.Rows(0)("CreditCard_ExpDate")) Then strCCExpDate = dtCC.Rows(0)("CreditCard_ExpDate")
                        iCCID = dtCC.Rows(0)("CCardType_ID")

                        'Replace credit card # with X except last 4 digits
                        strCCNo = Right(strCCNo, 4).PadLeft(strCCNo.Length, "x")
                        strCCSecurityCode = "x".PadLeft(strCCSecurityCode.Length, "x")
                    End If

                    strSql = "SELECT BillCode_Desc " & Environment.NewLine
                    strSql &= ", Prod_Desc " & Environment.NewLine
                    strSql &= ", tcustomer.Cust_ID " & Environment.NewLine
                    strSql &= ", Cust_Name1 " & Environment.NewLine
                    strSql &= ", Cust_Name2 " & Environment.NewLine
                    strSql &= ", tdevice.Device_ID " & Environment.NewLine
                    strSql &= ", Device_SN " & Environment.NewLine
                    strSql &= ", Device_OldSN " & Environment.NewLine
                    strSql &= ", Device_ManufWrty " & Environment.NewLine
                    strSql &= ", Device_PSSWrty " & Environment.NewLine
                    strSql &= ", Device_LaborCharge " & Environment.NewLine
                    strSql &= ", tdevice.Pallett_ID " & Environment.NewLine
                    strSql &= ", Ship_ID " & Environment.NewLine
                    strSql &= ", IF(DBill_InvoiceAmt IS NULL, 0.00, DBill_InvoiceAmt ) as DBill_InvoiceAmt " & Environment.NewLine
                    strSql &= ", IF(tdevicebill.BillCode_ID IS NULL, 0, tdevicebill.BillCode_ID) AS BillCode_ID " & Environment.NewLine
                    strSql &= ", IF(lbillcodes.BillCode_Rule, 0, lbillcodes.BillCode_Rule) AS BillCode_Rule " & Environment.NewLine
                    strSql &= ", Loc_Name " & Environment.NewLine
                    strSql &= ", Model_Desc " & Environment.NewLine
                    strSql &= ", Pallett_Name " & Environment.NewLine
                    strSql &= ", RUR_ReturnToCust " & Environment.NewLine
                    strSql &= ", tworkorder.Prod_ID " & Environment.NewLine
                    strSql &= ", '" & strCCType & "' as CCType_Desc " & Environment.NewLine
                    strSql &= ", '" & strCCNo & "' as CreditCard_Num " & Environment.NewLine
                    strSql &= ", '" & strCCSecurityCode & "' as CreditCard_AuthCode " & Environment.NewLine
                    strSql &= ", '" & strCCExpDate & "' as CreditCard_ExpDate " & Environment.NewLine
                    strSql &= ", IF(tworkorder.PO_ID > 0, tworkorder.PO_ID, '') as BillingPOID " & Environment.NewLine
                    strSql &= "FROM tdevice " & Environment.NewLine
                    strSql &= "INNER JOIN tpallett ON tdevice.pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                    strSql &= "INNER JOIN tcellopt ON tdevice.Device_ID = tcellopt.Device_ID " & Environment.NewLine
                    strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                    strSql &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                    strSql &= "INNER JOIN tcustomer ON tlocation.Cust_ID = tcustomer.Cust_ID " & Environment.NewLine
                    strSql &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                    strSql &= "INNER JOIN lproduct ON tworkorder.Prod_ID = lproduct.Prod_ID " & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID AND DBill_InvoiceAmt > 0 " & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN lbillcodes ON tdevicebill.Billcode_ID = lbillcodes.Billcode_ID " & Environment.NewLine
                    strSql &= "WHERE tdevice.Pallett_ID = " & dt.Rows(0)("Pallett_ID") & Environment.NewLine
                    strSql &= "AND tdevice.Pallett_ID is not null " & Environment.NewLine
                    dt1 = Me._objDataProc.GetDataTable(strSql)

                    objRpt = New ReportDocument()

                    With objRpt
                        .Load(strReportLoc & strRptName)
                        .SetDataSource(dt1)
                        .PrintToPrinter(1, True, 0, 0)
                    End With
                End If

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************

#End Region

#Region "Billing"

        '******************************************************************
        Public Shared Function GetRURCodesQuery(ByVal iMcodeID As Integer) As String
            Dim strSql As String = ""
            Try
                strSql = "Select Dcode_ID, Concat(Dcode_Sdesc, '-',Dcode_LDesc) as Dcode_Desc from lcodesdetail where MCode_ID = " & iMcodeID & " and Dcode_Inactive = 0 order by Dcode_LDesc"
                Return strSql
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
#End Region




    End Class
End Namespace