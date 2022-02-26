Option Explicit On 

Imports System.Web.Mail

Namespace Gui.MainWin

    Public Enum TaskTypes As Integer 'Creat task IDs
        TF_DAILY_SPECIAL_BILLING = 1
        TF_UPDATE_FR_BILLING_BY_DAILY_DOCK_SHIP_DATE = 2
    End Enum

    Public Class ModTasks

        '******************************************************************************************************************
        Public Shared Function RunTasks(ByVal emTaskTypeID As TaskTypes) As Integer
            Const iUserID As Integer = 1488 : Const strUserName As String = "scheduletasks" : Const strUserPw As String = "scheduletasks"
            Dim strToday, strLogsFileLoc As String

            Try
                Core.Global.ApplicationUser = New PSS.Rules.Security(strUserName, strUserPw)
                Core.Global.ApplicationUser.Login()

                strToday = Data.Buisness.Generic.MySQLServerDateTime(1)
                strLogsFileLoc = "\\phq-file\Public\Public\IT\ScheduledTasksApp\PSS\" & "\Logs.txt"

                Select Case emTaskTypeID
                    Case TaskTypes.TF_DAILY_SPECIAL_BILLING
                        RunTFSpecialBillingByDailyProduce(TaskTypes.TF_DAILY_SPECIAL_BILLING.ToString, strLogsFileLoc)
                    Case TaskTypes.TF_UPDATE_FR_BILLING_BY_DAILY_DOCK_SHIP_DATE
                        RunUpdateTFFRateBillingByDailyDockShip(TaskTypes.TF_UPDATE_FR_BILLING_BY_DAILY_DOCK_SHIP_DATE.ToString)
                    Case Else
                        Throw New Exception("Command line argument " & emTaskTypeID & " does not exist in the TaskTypes.")
                End Select
            Catch ex As Exception
                'Open the file
                FileOpen(1, strLogsFileLoc, OpenMode.Append)
                PrintLine(1, "--------------------------------------------")
                PrintLine(1, TaskTypes.TF_DAILY_SPECIAL_BILLING.ToString & " Date:" & Convert.ToDateTime(strToday).ToString("MM/dd/yyyy hh:mm:ss"))
                PrintLine(1, "ERROR: " & ex.ToString())
                Reset()
            End Try
        End Function

        '******************************************************************************************************************
        Private Shared Function RunTFSpecialBillingByDailyProduce(ByVal strTaskName As String, ByVal strLogsFileLoc As String) As Integer
            Dim constDockShipDate As Boolean = False : Const strLOB As String = "Tracfone"
            Dim strEmailFr, strEmailTo, strEmailCC, strEmailBCC, strSmtpSvr, strSubj, strBody, _
                strOnErrEmailFr, strOnErrEmailTo, strOnErrEmailCC, strOnErrEmailBCC, strToday As String
            Dim drTaskInfo As DataRow
            Dim i As Integer
            Dim objTFBilling As New Gui.TracFone.TFBilling()

            Try
                strEmailFr = "" : strEmailTo = "" : strEmailCC = "" : strEmailBCC = "" : strSmtpSvr = ""
                strSubj = "" : strBody = "" : strOnErrEmailFr = "" : strOnErrEmailTo = "" : strOnErrEmailCC = "" : strOnErrEmailBCC = ""

                drTaskInfo = PSS.Data.Buisness.Generic.GetTasksEmailInfo(strTaskName, strLOB, True)
                If Not IsNothing(drTaskInfo) Then
                    PSS.Data.Buisness.Generic.ParseEmailAddress(drTaskInfo("Addresses"), strEmailFr, strEmailTo, strEmailCC, strEmailBCC)
                    PSS.Data.Buisness.Generic.ParseEmailAddress(drTaskInfo("ErrorAddresses"), strOnErrEmailFr, strOnErrEmailTo, strOnErrEmailCC, strOnErrEmailBCC)
                    strSubj = drTaskInfo("Subject").ToString.Trim
                    strBody = drTaskInfo("Body").ToString.Trim
                    strSmtpSvr = drTaskInfo("SmtpServer").ToString.Trim
                End If

                strToday = Data.Buisness.Generic.MySQLServerDateTime(1)
                i = objTFBilling.SpecialBilling_ByDateRange(constDockShipDate, Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, Convert.ToDateTime(strToday).ToString("yyyy-MM-dd"), Convert.ToDateTime(strToday).ToString("yyyy-MM-dd"))
            Catch ex As Exception
                'Open the file
                FileOpen(1, strLogsFileLoc, OpenMode.Append)
                PrintLine(1, "--------------------------------------------")
                PrintLine(1, strTaskName & " Date:" & Convert.ToDateTime(strToday).ToString("MM/dd/yyyy hh:mm:ss"))
                PrintLine(1, "ERROR: " & ex.ToString())
                Reset()
            Finally
                objTFBilling = Nothing
            End Try
        End Function

        '******************************************************************************************************************
        Private Shared Function RunUpdateTFFRateBillingByDailyDockShip(ByVal strTaskName As String) As Integer
            Const strLOB As String = "Tracfone" : Const strDataDateType As String = "DOCK SHIP DATE"
            Dim dteToday As DateTime = Nothing
            Dim strErrMsg, strDateStart, strDateEnd As String
            Dim drTaskInfo As DataRow
            Dim objTFBilling As Gui.TracFone.TFBilling
            Dim objBizTFBilling As Data.Buisness.TracFone.TFBillingData
            Dim iTaskInfoID, iErrFlag As Integer

            Try
                'Set default value for variables
                strErrMsg = "" : strDateStart = "" : strDateEnd = ""
                iTaskInfoID = 0 : iErrFlag = 0

                'Define date range
                dteToday = CDate(Data.Buisness.Generic.MySQLServerDateTime(1))
                strDateStart = dteToday.ToString("yyyy-MM-dd") : strDateEnd = dteToday.ToString("yyyy-MM-dd")
                'strDateStart = "2015-01-01" : strDateEnd = "2015-01-31"

                'initialize object
                objBizTFBilling = New Data.Buisness.TracFone.TFBillingData()
                objTFBilling = New Gui.TracFone.TFBilling()

                'Get Task information
                drTaskInfo = PSS.Data.Buisness.Generic.GetTasksEmailInfo(strTaskName, strLOB, True)

                If IsNothing(drTaskInfo) Then ' thow error if task not found
                    strErrMsg = "System cannot find task ID for Update TF Flat Rate Billing."
                    iErrFlag = 1
                Else 'Update FR Billing
                    iTaskInfoID = CInt(drTaskInfo("ReportInfoID"))
                    strErrMsg = objTFBilling.UpdateFlatRateBilling_ByDailyDockShipDate(Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, strDateStart, strDateEnd)
                End If

                'Save Task Result
                If strErrMsg.Trim.Length > 0 Then
                    objBizTFBilling.SaveStatusOfUpdTFFlatRateBilling(strErrMsg, iTaskInfoID, strTaskName, iErrFlag, strDateStart, strDateEnd, strDataDateType)
                End If

            Catch ex As Exception
                'Save Task Result when errors occur
                iErrFlag = 1
                objBizTFBilling.SaveStatusOfUpdTFFlatRateBilling(ex.Message, iTaskInfoID, strTaskName, iErrFlag, strDateStart, strDateEnd, strDataDateType)
            Finally
                objTFBilling = Nothing : objBizTFBilling = Nothing
            End Try
        End Function


        '******************************************************************************************************************

    End Class
End Namespace