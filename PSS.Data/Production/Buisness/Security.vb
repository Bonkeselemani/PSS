Imports System.Text
Imports eInfoDesigns.dbProvider.MySqlClient
Imports PSS.Data.Production
Imports System.Windows.Forms
Namespace Buisness

    Public Class Security
        'Private _objDataProc As DBQuery.DataProc
        Private _objDataProc As MySql4.DataProc

        Public Sub New()
            Try
                'Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Me._objDataProc = New MySql4.DataProc(ConfigFile.GetConnectionInfo)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Function GetShiftDetail(ByVal iShiftID As Integer) As DataRow
            Dim strSql As String

            Try
                strSql = "SELECT * " & Environment.NewLine
                strSql &= "FROM tshift " & Environment.NewLine
                strSql &= "WHERE shift_id = " & iShiftID.ToString

                Return _objDataProc.GetDataRow(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

		Public Function DoesUserHaveSpecialPerm(ByVal user_id As Integer, ByVal special_permission As String) As Boolean
			' CHECKS TO SEE IF THE USER HAS SPECIAL PERMISSION.
			Dim _retval As Boolean = False
			Dim _usp_id As Integer = 0
			Dim _sb As New StringBuilder()
			Try
				_sb.Append("SELECT usp_id ")
				_sb.Append("FROM security.tuser_special_perms usp ")
				_sb.Append("INNER JOIN security.tspecial_perms sp ON usp.sp_id = sp.sp_id ")
				_sb.Append("WHERE ")
				_sb.Append("usp.user_id = " & user_id.ToString() & " ")
				_sb.Append("AND ")
				_sb.Append("sp.sp_na = '" & special_permission & "'; ")
				_usp_id = _objDataProc.GetIntValue(_sb.ToString)
				Return (_usp_id > 0)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Public Function GetPSSWeekDay(ByVal strWeekDay As String) As DataRow
			Dim strSql As String

			Try
				strSql = "SELECT * " & Environment.NewLine
				strSql &= "FROM lweekday " & Environment.NewLine
				strSql &= "WHERE weekday = '" & strWeekDay & "'"

				Return Me._objDataProc.GetDataRow(strSql)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Public Function GetPermData(ByVal userID As Integer, ByVal screen As String) As Integer
			Dim strSql As String

			Try
				strSql = "SELECT MAX(security.tpermissions.level_id) " & Environment.NewLine
				strSql &= "FROM ((security.tgroup " & Environment.NewLine
				strSql &= "INNER JOIN security.rusertogroup ON security.tgroup.group_id = security.rusertogroup.group_id) " & Environment.NewLine
				strSql &= "INNER JOIN security.tscreen ON security.tpermissions.screen_id = security.tscreen.screen_id) " & Environment.NewLine
				strSql &= "INNER JOIN security.tpermissions ON security.tgroup.group_id = security.tpermissions.group_id " & Environment.NewLine
				strSql &= "WHERE security.rusertogroup.user_id = " & userID & " AND security.tscreen.screen_sysname = '" & screen & "'"

				Return Me._objDataProc.GetIntValue(strSql)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Public Function GetPermissionAndSecurityData(Optional ByVal iUserID As Integer = 0, _
		   Optional ByVal iGroupID As Integer = 0, _
		   Optional ByVal iScreenID As Integer = 0, _
		   Optional ByVal strUserName As String = "", _
		   Optional ByVal iEmpNo As Integer = 0, _
		   Optional ByVal bUserInactive As Boolean = False, _
		   Optional ByVal strGroupDesc As String = "", _
		   Optional ByVal strScreenDesc As String = "", _
		   Optional ByVal strScreenSysName As String = "") As DataTable
			Dim strSql As String
			Dim dt As DataTable
			Dim row As DataRow

			Dim strDecryErr As String = ""
			Dim strDecrypted As String = ""
			Dim strS As String = ""

			Try
				strSql = "SELECT C.user_id,C.user_name,C.user_pass,'' AS user_pass_Decrypt,C.user_fullname,C.EmployeeNo,C.QCStamp" & Environment.NewLine
				strSql &= " ,C.tech_id,C.shift_id,C.is_user_refurber,C.user_inactive" & Environment.NewLine
				strSql &= " ,C.ExemptFlag,C.OTFlag,C.AdminUser,C.LastLogonMachine,C.group_id AS 'LOB_Group_ID'" & Environment.NewLine
				strSql &= " ,C.TechRate,C.GlobalAccess,C.AccountLockOut_PwAttempted_id,C.PwLog_id,C.PwEncryDecryFlag" & Environment.NewLine
				strSql &= " ,D.*,E.*" & Environment.NewLine
				strSql &= " FROM security.tpermissions A" & Environment.NewLine
				strSql &= " INNER JOIN security.rusertogroup B ON A.group_ID=B.group_ID" & Environment.NewLine
				strSql &= " INNER JOIN security.tusers C ON B.user_ID=C.user_ID" & Environment.NewLine
				strSql &= " INNER JOIN security.tgroup D ON D.group_ID=B.group_ID" & Environment.NewLine
				strSql &= " INNER JOIN security.tscreen E ON E.screen_ID=A.screen_ID" & Environment.NewLine
				strSql &= " WHERE C.user_id > 0" & iUserID & Environment.NewLine

				If iUserID > 0 Then strSql &= " AND C.user_id=" & iUserID & Environment.NewLine
				If iGroupID > 0 Then strSql &= " AND A.Group_ID=" & iGroupID & Environment.NewLine
				If iScreenID > 0 Then strSql &= " AND E.screen_ID=" & iScreenID & Environment.NewLine
				If strUserName.Trim.Length > 0 Then strSql &= " AND C.user_Name='" & strUserName & "'" & Environment.NewLine
				If iEmpNo > 0 Then strSql &= " AND C.EmployeeNo=" & iEmpNo & Environment.NewLine
				If bUserInactive Then
					strSql &= " AND C.user_inactive=1" & Environment.NewLine
				Else
					strSql &= " AND C.user_inactive=0" & Environment.NewLine
				End If
				If strGroupDesc.Trim.Length > 0 Then strSql &= " AND D.group_desc='" & strGroupDesc & "'" & Environment.NewLine
				If strScreenDesc.Trim.Length > 0 Then strSql &= " AND E.screen_desc='" & strScreenDesc & "'" & Environment.NewLine
				If strScreenSysName.Trim.Length > 0 Then strSql &= " AND E.screen_sysname='" & strScreenSysName & "'" & Environment.NewLine

				dt = Me._objDataProc.GetDataTable(strSql)
				For Each row In dt.Rows
					strDecrypted = "" : strS = ""
					strS = row("user_pass")
					strDecrypted = EncDec.Rijndael.Decrypt(strS.Trim, strDecryErr)
					If strDecryErr.Trim.Length = 0 Then
						row.BeginEdit()
						row("user_pass_Decrypt") = strDecrypted
						row.AcceptChanges()
					Else
						Throw New Exception(strDecryErr)
					End If
				Next

				Return dt
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Public Function GetLoginData(ByVal username As String, ByVal userpass As String) As DataRow
			Dim strSql As String
			Dim strEncryptedPW As String = ""
			Dim strEncErr As String = ""
			Dim dt As New DataTable()
			Dim row As DataRow
			Dim iPwEncryDecryFlag As Integer = 0

			Try

				strSql = "SELECT * " & Environment.NewLine
				strSql &= "FROM security.tusers " & Environment.NewLine
				strSql &= "WHERE user_name = '" & username.Replace("'", "''") & "' " & Environment.NewLine
				dt = Me._objDataProc.GetDataTable(strSql)

				If dt.Rows.Count > 0 Then
					iPwEncryDecryFlag = dt.Rows(0).Item("PwEncryDecryFlag")
					If iPwEncryDecryFlag = 1 Then
						strEncryptedPW = EncDec.Rijndael.Encrypt(userpass, strEncErr)
						If strEncErr.Trim.Length = 0 Then
							strSql = "SELECT * " & Environment.NewLine
							strSql &= "FROM security.tusers " & Environment.NewLine
							strSql &= "WHERE user_name = '" & username.Replace("'", "''") & "' " & Environment.NewLine
							strSql &= "AND user_pass = '" & strEncryptedPW.Replace("'", "''") & "'"

							'Return Me._objDataProc.GetDataRow(strSql)
							dt = Me._objDataProc.GetDataTable(strSql)
							For Each row In dt.Rows
								row.BeginEdit() : row("user_pass") = userpass : row.AcceptChanges()
								Return row
							Next
						Else
							Throw New Exception("Function GetLoginData Encrpytion Error: " & strEncErr)
						End If
					Else
						strSql = "SELECT * " & Environment.NewLine
						strSql &= "FROM security.tusers " & Environment.NewLine
						strSql &= "WHERE user_name = '" & username.Replace("'", "''") & "' " & Environment.NewLine
						strSql &= "AND user_pass = '" & userpass.Replace("'", "''") & "'"
						'Return Me._objDataProc.GetDataRow(strSql)
						dt = Me._objDataProc.GetDataTable(strSql)
						If dt.Rows.Count > 0 Then
							For Each row In dt.Rows							'should be one row 
								Return row
							Next
						Else
							Throw New Exception("Function GetLoginData: No user data for '" & username & "'")
						End If
					End If
				End If

			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'*************************************************************************
		Public Function GetLoginDatatable(ByVal username As String, ByVal userpass As String) As DataTable
			Dim strSql As String
			Dim strEncryptedPW As String = ""
			Dim strEncErr As String = ""
			Dim dt As DataTable
			Dim row As DataRow
			Dim iPwEncryDecryFlag As Integer = 0

			Try

				strSql = "SELECT * " & Environment.NewLine
				strSql &= "FROM security.tusers " & Environment.NewLine
				strSql &= "WHERE user_name = '" & username.Replace("'", "''") & "' " & Environment.NewLine
				dt = Me._objDataProc.GetDataTable(strSql)

				If dt.Rows.Count > 0 Then
					iPwEncryDecryFlag = dt.Rows(0).Item("PwEncryDecryFlag")
					If iPwEncryDecryFlag = 1 Then
						strEncryptedPW = EncDec.Rijndael.Encrypt(userpass, strEncErr)
						If strEncErr.Trim.Length = 0 Then
							strSql = "SELECT * " & Environment.NewLine
							strSql &= "FROM security.tusers " & Environment.NewLine
							strSql &= "WHERE user_name = '" & username.Replace("'", "''") & "' " & Environment.NewLine
							strSql &= "AND user_pass = '" & strEncryptedPW.Replace("'", "''") & "'"

							dt = Me._objDataProc.GetDataTable(strSql)
							For Each row In dt.Rows
								row.BeginEdit() : row("user_pass") = userpass : row.AcceptChanges()
							Next
							Return dt
						Else
							Throw New Exception("Function GetLoginData Encrpytion Error: " & strEncErr)
						End If
					Else
						strSql = "SELECT * " & Environment.NewLine
						strSql &= "FROM security.tusers " & Environment.NewLine
						strSql &= "WHERE user_name = '" & username.Replace("'", "''") & "' " & Environment.NewLine
						strSql &= "AND user_pass = '" & userpass.Replace("'", "''") & "'"
						'Return Me._objDataProc.GetDataRow(strSql)
						dt = Me._objDataProc.GetDataTable(strSql)
						Return dt
					End If
				End If


			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'**************************************************************************
		Public Function GetLoginDatatableByUserID(ByVal iUserID As Integer) As DataTable
			Dim strSql As String
			Dim dt As DataTable
			Dim strEncDecErr As String = ""
			Dim strDecryptedPW As String = ""
			Dim row As DataRow
			Dim iPwEncryDecryFlag As Integer = 0

			Try
				strSql = "SELECT * " & Environment.NewLine
				strSql &= "FROM security.tusers " & Environment.NewLine
				strSql &= "WHERE user_id = " & iUserID & ";" & Environment.NewLine

				dt = Me._objDataProc.GetDataTable(strSql)
				For Each row In dt.Rows
					iPwEncryDecryFlag = row("PwEncryDecryFlag")
					If iPwEncryDecryFlag = 1 Then
						strDecryptedPW = EncDec.Rijndael.Decrypt(row("user_pass"), strEncDecErr)
						row.BeginEdit() : row("user_pass") = strDecryptedPW : row.AcceptChanges()
					End If
				Next
				Return dt
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'Public Shared Function GetShiftInfo(ByVal iShiftID As Integer) As DataRow
		'    Dim strSql As String = "SELECT * from tshift where shift_id = " & iShiftID & ";"
		'    Return GetDataTable(strSql).Rows(0)
		'End Function

		'Private Shared Function GetDataTable(ByVal [string] As String, _
		'                                     Optional ByVal strDB As String = "security") As DataTable
		'    _conn = Connection.GetConnection(strDB)
		'    '_conn = Connection.GetConnection("Security", 1)   'Pass 1 for replication database connectivity.
		'    Dim _cmd As New MySqlCommand([string], _conn)
		'    Dim _da As New MySqlDataAdapter()
		'    _da.SelectCommand = _cmd
		'    Dim _dt As New DataTable()
		'    _da.Fill(_dt)
		'    _da.Dispose()
		'    _da = Nothing
		'    '//Craig Haney
		'    _conn.Close()
		'    _conn.Dispose()
		'    '//Craig Haney
		'    Return _dt
		'End Function

		'***************************************************
		'This resets the Last Logon machine for a given user
		'***************************************************
		Public Function ResetLastLogonMachine(ByVal iUserID As Integer, _
		  Optional ByVal strHost As String = "") As Integer
			Dim strSql As String
			Dim i As Integer = 0

			Try
				If strHost = "" Then
					strSql = "UPDATE security.tusers " & Environment.NewLine
					strSql &= "SET LastLogonMachine = NULL " & Environment.NewLine
					strSql &= "WHERE user_id = " & iUserID.ToString
				Else
					strSql = "UPDATE security.tusers " & Environment.NewLine
					strSql &= "SET LastLogonMachine = NULL " & Environment.NewLine
					strSql &= "WHERE LastLogonMachine = '" & strHost & "'"

					i = Me._objDataProc.ExecuteNonQuery(strSql)

					strSql = "UPDATE security.tusers " & Environment.NewLine
					strSql &= "SET LastLogonMachine = '" & Trim(strHost) & "' " & Environment.NewLine
					strSql &= "WHERE user_id = " & iUserID.ToString
				End If

				Return Me._objDataProc.ExecuteNonQuery(strSql)
			Catch ex As Exception
				'Throw New Exception("Buisness.Misc.ResetLastLogonMachine(): " & Environment.NewLine & ex.Message.ToString)
				Throw ex
			End Try

		End Function

		Public Function IsCellular(ByVal iGroupID As Integer) As Boolean
			' Check if the group ID is a cellular group
			Dim strSql As String = ""
			Dim dt As DataTable = Nothing
			Dim dr As DataRow = Nothing
			Dim bIsCellular = False

			Try
				strSql &= "SELECT Group_ID " & Environment.NewLine
				strSql &= "FROM production.lgroups " & Environment.NewLine
				strSql &= "WHERE UPPER(Group_Desc) LIKE 'CELLULAR%'"

				dt = Me._objDataProc.GetDataTable(strSql)

				If Not IsNothing(dt) Then
					If dt.Rows.Count > 0 Then
						For Each dr In dt.Rows
							If dr("Group_ID") = iGroupID Then
								bIsCellular = True

								Exit For
							End If
						Next
					End If
				End If

				Return bIsCellular
			Catch ex As Exception
				Throw ex
			Finally
				dr = Nothing

				If Not IsNothing(dt) Then
					dt.Dispose()
					dt = Nothing
				End If
			End Try
		End Function

		Public Function UpdateAccessPrevileges(ByVal iUser_ID As Integer,
		 ByVal lstCtrl As CheckedListBox) _
		 As Integer
			'Dim objMisc As New PSS.Data.Production.Misc()
			Dim i As Integer = 0
			Dim j As Integer = 0
			Dim k As Integer = 0
			Dim dt1, dt2, dtAllGroups_And_Assignments As DataTable
			Dim R1, R2 As DataRow
			Dim strSql As String = ""
			Dim strDelGrpIDs As String = ""


			Try
				'*******************************************************
				'Get all Grouls and Assigned info from security.rusertogroup and tgroups
				strSql = "SELECT security.tgroup.group_id,  security.tgroup.group_desc, security.rusertogroup.user_id " & Environment.NewLine
				strSql &= "FROM security.tgroup " & Environment.NewLine
				strSql &= "LEFT JOIN security.rusertogroup ON security.rusertogroup.group_id = security.tgroup.group_id"

				dt1 = Me._objDataProc.GetDataTable(strSql)

				'*******************************************************
				'Loop through list control and get the checked groups and 
				'build the deletable groups

				For i = 0 To lstCtrl.Items.Count - 1
					For j = 0 To lstCtrl.CheckedItems.Count - 1
						If lstCtrl.Items.Item(i) = lstCtrl.CheckedItems.Item(j) Then
							k = 1
							Exit For
						End If
					Next j

					If k = 0 Then
						For Each R1 In dt1.Rows

							If Trim(R1("group_desc")) = Trim(lstCtrl.Items.Item(i)) Then
								If Trim(strDelGrpIDs) = "" Then
									strDelGrpIDs &= R1("group_id")
								Else
									strDelGrpIDs &= "," & R1("group_id")
								End If

								Exit For
							End If

						Next R1
					End If

					'Re-initialise loop variables
					k = 0
				Next i

				'*******************************************************
				'Delete Groups unassigned for the user
				If strDelGrpIDs <> "" Then
					strSql = "DELETE FROM security.rusertogroup " & Environment.NewLine
					strSql &= "WHERE user_id = " & iUser_ID.ToString & " " & Environment.NewLine
					strSql &= "AND group_id IN (" & strDelGrpIDs & ")"

					i = Me._objDataProc.ExecuteNonQuery(strSql)
				End If

				'*******************************************************
				'Get all Checked groups and see which ones need to be 
				'inserted in the database 
				k = 0
				For j = 0 To lstCtrl.CheckedItems.Count - 1
					For Each R1 In dt1.Rows
						If Not IsDBNull(R1("user_id")) Then
							If Trim(R1("group_desc")) = Trim(lstCtrl.CheckedItems.Item(j)) And R1("user_id") = iUser_ID Then
								k = 1
								Exit For
							End If
						End If
					Next R1

					If k = 0 Then
						For Each R1 In dt1.Rows
							If Trim(R1("group_desc")) = Trim(lstCtrl.CheckedItems.Item(j)) Then
								strSql = "INSERT INTO security.rusertogroup (" & Environment.NewLine
								strSql &= "user_id, " & Environment.NewLine
								strSql &= "group_id " & Environment.NewLine
								strSql &= ") VALUES ( " & Environment.NewLine
								strSql &= iUser_ID.ToString & ", " & Environment.NewLine
								strSql &= R1("group_id") & ")"

								i += Me._objDataProc.ExecuteNonQuery(strSql)

								Exit For
							End If
						Next R1
					End If

					'Re-initialise loop variables
					k = 0
				Next j



				'*******************************************************
				Return i
			Catch ex As Exception
				Throw ex
			Finally
				If Not IsNothing(dt1) Then
					dt1.Dispose()
					dt1 = Nothing
				End If
				If Not IsNothing(dt2) Then
					dt2.Dispose()
					dt2 = Nothing
				End If
			End Try
		End Function


		Public Function CopyUserAccessPrevileges(ByVal fromUser_ID As Integer, ByVal toUser_ID As Integer) _
		  As Integer
			'Dim objMisc As New PSS.Data.Production.Misc()
			Dim i As Integer = 0
			Dim dtFromUser As DataTable
			Dim dr As DataRow
			Dim strSql As String = ""

			Try
				'*******************************************************
				'Get fromUser access previledges list
				strSql = "SELECT * FROM security.rusertogroup Where user_id = " & fromUser_ID
				dtFromUser = Me._objDataProc.GetDataTable(strSql)

				'*******************************************************
				'Clear toUser_ID 
				strSql = "DELETE FROM security.rusertogroup " & Environment.NewLine
				strSql &= "WHERE user_id = " & toUser_ID.ToString & " " & Environment.NewLine
				i = Me._objDataProc.ExecuteNonQuery(strSql)

				'*******************************************************
				'Copy fromUser to toUser 
				For Each dr In dtFromUser.Rows

					strSql = "INSERT INTO security.rusertogroup (" & Environment.NewLine
					strSql &= "user_id, " & Environment.NewLine
					strSql &= "group_id " & Environment.NewLine
					strSql &= ") VALUES ( " & Environment.NewLine
					strSql &= toUser_ID.ToString & ", " & Environment.NewLine
					strSql &= dr("group_id") & ")"
					Me._objDataProc.ExecuteNonQuery(strSql)
					i = i + 1

				Next dr
				Return i

			Catch ex As Exception
				Throw ex
			Finally
				If Not IsNothing(dtFromUser) Then
					dtFromUser.Dispose()
					dtFromUser = Nothing
				End If

			End Try
		End Function

		'*****************************************************************
		Public Function CopyUsedrAccessPrevileges(ByVal fromUser_ID As Integer, ByVal toUser_ID As Integer)

		End Function

		'*****************************************************************
		Public Function getRuleItems() As ArrayList
			Dim arrLstRuleItems As New ArrayList()

			arrLstRuleItems.Add("UpperLetter".ToUpper)
			arrLstRuleItems.Add("LowerLetter".ToUpper)
			arrLstRuleItems.Add("NumericNumber".ToUpper)
			arrLstRuleItems.Add("SpecialCharacter".ToUpper)
			arrLstRuleItems.Add("PasswordLength".ToUpper)
			arrLstRuleItems.Add("PasswordExpireDays".ToUpper)
			arrLstRuleItems.Add("ReuseLastPWMonths".ToUpper)
			arrLstRuleItems.Add("AccoutLockoutTimes".ToUpper)
			arrLstRuleItems.Add("AccountResetMinutes".ToUpper)

			Return arrLstRuleItems
		End Function

		'*****************************************************************
		Public Function IsRuleItemMatched() As Boolean
			Dim arrLstRuleItems As ArrayList = getRuleItems()
			Dim strSql As String = "", strS As String = ""
			Dim dt As DataTable
			Dim row As DataRow

			Try

				strSql = "SELECT * from security.tpasswordrules;" & Environment.NewLine

				dt = Me._objDataProc.GetDataTable(strSql)

				If Not dt.Rows.Count > 0 Then
					Return False
				Else
					For Each row In dt.Rows
						strS = row("RuleItem")
						If Not arrLstRuleItems.Contains(strS.Trim.ToUpper) Then
							Return False
						End If
					Next
				End If

				Return True

			Catch ex As Exception
				Throw ex
			Finally
				dt = Nothing
			End Try

		End Function


		'*****************************************************************
		Public Function getPasswordRuleData() As DataTable
			Dim strSql As String = ""
			Try

				strSql = "SELECT * from security.tpasswordrules;" & Environment.NewLine

				Return Me._objDataProc.GetDataTable(strSql)

			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'*****************************************************************
		Public Function getUserID(ByVal strUserName As String) As Integer
			Dim strSql As String = ""
			Dim dt As DataTable

			Try

				strSql = "select * from security.tusers where trim(user_name)='" & strUserName.Replace("'", "''") & "'" & Environment.NewLine

				dt = Me._objDataProc.GetDataTable(strSql)

				If Not dt.Rows.Count > 0 Then
					Return 0
				ElseIf dt.Rows.Count = 1 Then
					Return dt.Rows(0).Item("user_id")
				Else
					Throw New Exception("Duplicate user name!")
				End If

			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'*****************************************************************
		Public Function getUserName(ByVal iUserID As Integer) As String
			Dim strSql As String = ""
			Dim dt As DataTable

			Try

				strSql = "select * from security.tusers where user_id=" & iUserID & ";" & Environment.NewLine

				dt = Me._objDataProc.GetDataTable(strSql)

				If Not dt.Rows.Count > 0 Then
					Return ""
				Else
					Return dt.Rows(0).Item("user_name")
				End If

			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'*****************************************************************
		Public Function IsUserActive(ByVal iUserID As Integer) As Boolean
			Dim strSql As String = ""
			Dim dt As DataTable

			Try

				strSql = "select * from security.tusers where user_id=" & iUserID & ";" & Environment.NewLine

				dt = Me._objDataProc.GetDataTable(strSql)

				If Not dt.Rows.Count > 0 Then
					Return False
				Else
					If dt.Rows(0).Item("user_inactive") = 1 Then
						Return False
					Else
						Return True
					End If
				End If

			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'*****************************************************************
		Public Function IsUserExist(ByVal strUserName As String) As Boolean
			Dim strSql As String = ""
			Dim dt As DataTable

			Try

				strSql = "select * from security.tusers where trim(user_name)='" & strUserName.Replace("'", "''") & "'" & Environment.NewLine

				dt = Me._objDataProc.GetDataTable(strSql)

				If Not dt.Rows.Count > 0 Then
					Return False
				Else
					Return True
				End If

			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'*****************************************************************
		Public Function getPasswordLogData(ByVal iUserID As Integer) As DataTable
			Dim strSql As String = ""
			Dim dt As DataTable
			Dim row As DataRow
			Dim strDecryptedPW As String = ""
			Dim strEncDecErr As String = ""
			Dim iPwEncryDecryFlag As Integer = 0

			Try

				strSql = "SELECT * FROM security.tusers_pwlog where user_ID=" & iUserID & " ORDER BY PwLog_ID DESC;" & Environment.NewLine

				dt = Me._objDataProc.GetDataTable(strSql)
				For Each row In dt.Rows
					iPwEncryDecryFlag = row("PwEncryDecryFlag")
					If iPwEncryDecryFlag = 1 Then
						strDecryptedPW = EncDec.Rijndael.Decrypt(row("Pw_Used"), strEncDecErr)
						row.BeginEdit() : row("Pw_Used") = strDecryptedPW : row.AcceptChanges()
					End If
				Next

				Return dt

			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'*****************************************************************
		Public Function getPasswordLogData(ByVal iUserID As Integer, ByVal strBeginDTime As String, ByVal strEndDTime As String) As DataTable
			Dim strSql As String = ""
			Dim dt As DataTable
			Dim row As DataRow
			Dim strDecryptedPW As String = ""
			Dim strDecDecErr As String = ""
			Dim iPwEncryDecryFlag As Integer = 0

			Try

				strSql = "SELECT * FROM security.tusers_pwlog where user_ID=" & iUserID & Environment.NewLine
				strSql &= " AND PwUsed_Date BETWEEN '" & strBeginDTime & "' AND '" & strEndDTime & "'" & Environment.NewLine
				strSql &= " ORDER BY PwLog_ID DESC;" & Environment.NewLine

				dt = Me._objDataProc.GetDataTable(strSql)
				For Each row In dt.Rows
					iPwEncryDecryFlag = row("PwEncryDecryFlag")
					If iPwEncryDecryFlag = 1 Then
						strDecryptedPW = EncDec.Rijndael.Decrypt(row("Pw_Used"), strDecDecErr)
						row.BeginEdit() : row("Pw_Used") = strDecryptedPW : row.AcceptChanges()
					End If
				Next

				Return dt

			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'*****************************************************************
		Public Function getPasswordAttemptedData(ByVal iUserID As Integer) As DataTable
			Dim strSql As String = ""
			Dim dt As DataTable
			Dim row As DataRow
			Dim strDecryptedPW As String = ""
			Dim strDecDecErr As String = ""
			Dim iPwEncryDecryFlag As Integer = 0

			Try

				strSql = "SELECT * FROM security.tusers_pwattemptedlog WHERE user_ID=" & iUserID & " ORDER BY PwAttempted_Datetime DESC;" & Environment.NewLine

				dt = Me._objDataProc.GetDataTable(strSql)
				For Each row In dt.Rows
					iPwEncryDecryFlag = row("PwEncryDecryFlag")
					If iPwEncryDecryFlag = 1 Then
						strDecryptedPW = EncDec.Rijndael.Decrypt(row("Pw_Attempted"), strDecDecErr)
						row.BeginEdit() : row("Pw_Attempted") = strDecryptedPW : row.AcceptChanges()
					End If
				Next

				Return dt

			Catch ex As Exception
				Throw ex
			End Try
		End Function


		'*****************************************************************
		Public Function SavePasswordAndPWLog(ByVal iUserID As Integer, ByVal strPwUsed As String) As Integer
			Dim strSql As String = ""
			Dim strDateTime As String = Generic.MySQLServerDateTime(1)
			Dim i As Integer = 0
			Dim iPwLogID As Integer = 0
			Dim strEncDecErr As String = ""
			Dim strEncryptedPW As String = ""

			Try
				strEncryptedPW = EncDec.Rijndael.Encrypt(strPwUsed, strEncDecErr)
				If strEncDecErr.Trim.Length = 0 Then strPwUsed = strEncryptedPW

				strSql = "INSERT INTO security.tusers_pwlog (user_id,Pw_Used,PwUsed_Date,PwEncryDecryFlag)  " & Environment.NewLine
				strSql &= " Values (" & iUserID & ",'" & strPwUsed.Replace("'", "''") & "','" & strDateTime & "',1);"
				i = Me._objDataProc.ExecuteNonQuery(strSql)

				strSql = "SELECT LAST_INSERT_ID();"
				iPwLogID = Me._objDataProc.GetIntValue(strSql)

				If iPwLogID > 0 Then
					strSql = "UPDATE security.tusers set user_pass='" & strPwUsed.Replace("'", "''") & "'" & Environment.NewLine
					strSql &= ",PwLog_ID=" & iPwLogID & ",PwEncryDecryFlag=1 WHERE User_ID=" & iUserID & ";" & Environment.NewLine
					i += Me._objDataProc.ExecuteNonQuery(strSql)
				Else
					i = 0
				End If

				Return i

			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'*****************************************************************
		Public Function SavePasswordAttemptedLog(ByVal iUserID As Integer, ByVal strPwAttempted As String, _
		  ByVal strSessionID As String, ByVal strComputerName As String, _
		  ByVal strWinUser As String, ByVal bAccountLocked As Boolean, _
		  ByVal bClearHistory As Boolean) As Integer
			Dim strSql As String = ""
			Dim strDateTime As String = Generic.MySQLServerDateTime(1)
			Dim i As Integer = 0
			Dim iPwAttemptedID As Integer = 0
			Dim stEncriptMsg As String = ""
			Dim strEncryptedPW As String = ""


			Try
				strEncryptedPW = EncDec.Rijndael.Encrypt(strPwAttempted, stEncriptMsg)
				If stEncriptMsg.Trim.Length = 0 Then strPwAttempted = strEncryptedPW

				If bAccountLocked Then
					strSql = "INSERT INTO security.tusers_pwattemptedlog (user_id,Pw_Attempted,PwAttempted_Datetime,SessionID,ComputerName,WindowUser,PwEncryDecryFlag)  " & Environment.NewLine
					strSql &= " Values (" & iUserID & ",'" & strPwAttempted.Replace("'", "''") & "','" & strDateTime & "','" & strSessionID.Replace("'", "''") & "','" & _
					strComputerName.Replace("'", "''") & "','" & strWinUser.Replace("'", "''") & "',1);"
					i = Me._objDataProc.ExecuteNonQuery(strSql)

					strSql = "SELECT LAST_INSERT_ID();"
					iPwAttemptedID = Me._objDataProc.GetIntValue(strSql)

					If iPwAttemptedID > 0 Then
						strSql = "UPDATE security.tusers set AccountLockOut_PwAttempted_id=" & iPwAttemptedID & Environment.NewLine
						strSql &= " WHERE User_ID=" & iUserID & ";" & Environment.NewLine
						i += Me._objDataProc.ExecuteNonQuery(strSql)
					Else
						i = 0
					End If
				Else
					strSql = "INSERT INTO security.tusers_pwattemptedlog (user_id,Pw_Attempted,PwAttempted_Datetime,SessionID,ComputerName,WindowUser,PwEncryDecryFlag)   " & Environment.NewLine
					strSql &= " Values (" & iUserID & ",'" & strPwAttempted.Replace("'", "''") & "','" & strDateTime & "','" & strSessionID.Replace("'", "''") & "','" & _
					 strComputerName.Replace("'", "''") & "','" & strWinUser.Replace("'", "''") & "',1);"
					i = Me._objDataProc.ExecuteNonQuery(strSql)
				End If

				If bClearHistory Then
					'Keep history only for current day
					strSql = "DELETE FROM security.tusers_pwattemptedlog" & Environment.NewLine
					strSql &= " WHERE user_id =" & iUserID & " AND PwAttempted_Datetime < '" & Format(Now, "yyyy-MM-dd") & "';"
					Me._objDataProc.ExecuteNonQuery(strSql)
				End If

				Return i

			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'*************************************************************************
		Public Function UnlockUserLogin(ByVal iUserID As Integer) As Integer
			Dim strSql As String

			Try
				strSql = "UPDATE security.tusers set AccountLockOut_PwAttempted_id=0" & Environment.NewLine
				strSql &= " WHERE User_ID=" & iUserID & ";" & Environment.NewLine
				Return Me._objDataProc.ExecuteNonQuery(strSql)


			Catch ex As Exception
				Throw ex
			End Try
		End Function
	End Class

End Namespace
