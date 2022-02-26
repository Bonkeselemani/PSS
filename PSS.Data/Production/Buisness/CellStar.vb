Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.OleDb
Imports System.IO
Imports System.Xml
Imports PSS.Data
Imports System.Drawing.Printing

Namespace Buisness

    Public Class CellStar
        Private objMisc As Production.Misc
        Public MyFilePath As String = ""
        Private Const MyPath As String = "P:\Dept\Cellstar\cellstar_wip_xml\Current\Closed\"

        '***************************************************
        Public Sub New()
            objMisc = New Production.Misc()
        End Sub
        '***************************************************
        Protected Overrides Sub Finalize()
            objMisc = Nothing
            MyBase.Finalize()
        End Sub
        '***************************************************

        Public Function loadAdvanceShipNotice(ByVal strFilePath As String, _
                                              ByVal iMachineGroup As Integer, _
                                              ByRef strNewPartNumbers As String, _
                                              ByRef dtRejectReason As DataTable) As Integer

            Dim i As Integer = 0
            Dim strSQL As String = ""

            Dim strASN_Number As String = ""
            Dim strEnterprise_Code As String = ""
            Dim strTimeStamp As String = ""
            Dim strRepairOrderNumber As String = ""
            Dim strESN As String = ""
            Dim strModel As String = ""
            Dim strItemNumber As String = ""
            Dim strItemDescription As String = ""
            Dim strAccountNumber As String = ""
            Dim strPreviousRepairOrderNumber As String

            Dim iQTY As Integer = 0

            Dim m_xmld As XmlDocument
            Dim m_nodelist As XmlNodeList
            Dim m_node As XmlNode

            Dim dt1, dtInsert As DataTable
            Dim r As DataRow
            Dim iModel As Integer
            Dim blnWarehouse As Boolean
            Dim R1 As DataRow
            Dim strFields As String = ""
            Dim strValues As String = ""
            Dim strFileName As String = ""
            Dim strPartNum As String = ""


            Try
                i = InStrRev(strFilePath, "\", -1)
                strFileName = Mid(strFilePath, i + 1)
                i = 0

                '*************************
                '1:: instantiate XML object
                '*************************
                m_xmld = New XmlDocument()
                m_xmld.Load(strFilePath)

                System.Windows.Forms.Application.DoEvents()
                '******************************************
                '//Get Header Information
                '//This should be only one record 
                '******************************************
                m_nodelist = m_xmld.SelectNodes("/AdvanceShipNotice")
                For Each m_node In m_nodelist
                    strASN_Number = Trim(m_node.ChildNodes.Item(0).InnerText)
                    strEnterprise_Code = Trim(m_node.ChildNodes.Item(1).InnerText)
                    If IsNumeric(Trim(m_node.ChildNodes.Item(2).InnerText)) Then
                        iQTY = CInt(Trim(m_node.ChildNodes.Item(2).InnerText))
                    Else
                        iQTY = 0
                    End If
                    strTimeStamp = Trim(m_node.ChildNodes.Item(3).InnerText)
                Next

                ''*******************************
                ''2:: validate Enterprise field
                ''*******************************
                'If strEnterprise_Code = "" Then
                '    'create new row for reject report
                '    R1 = dtRejectReason.NewRow()
                '    R1("EnterpriseCode") = strEnterprise_Code
                '    R1("Could not Receive Reason") = "Enterprise Code is missing"
                '    R1("File Name") = strFileName
                '    dtRejectReason.Rows.Add(R1)
                '    R1 = Nothing
                '    dtRejectReason.AcceptChanges()
                '    Return 0
                'End If

                System.Windows.Forms.Application.DoEvents()

                'create a new row storing data for insert
                dtInsert = Me.CreateCSAdvanceRecdt()

                '************************************
                '3:://Get Detail Information from XML
                '************************************
                m_nodelist = m_xmld.SelectNodes("/AdvanceShipNotice/ASNItem")
                For Each m_node In m_nodelist
                    'validate requirement fields
                    strRepairOrderNumber = Trim(m_node.ChildNodes.Item(0).InnerText)
                    strESN = Trim(m_node.ChildNodes.Item(1).InnerText)
                    strModel = Trim(m_node.ChildNodes.Item(2).InnerText)
                    strItemNumber = Trim(m_node.ChildNodes.Item(3).InnerText)
                    strItemDescription = Trim(m_node.ChildNodes.Item(4).InnerText)
                    strAccountNumber = Trim(m_node.ChildNodes.Item(5).InnerText)
                    strPreviousRepairOrderNumber = ""

                    If strRepairOrderNumber = "" Or strESN = "" Or strItemNumber = "" Then
                        'create new row for reject report
                        R1 = dtRejectReason.NewRow()
                        R1("RepairOrderNumber") = strRepairOrderNumber
                        R1("ESN") = strESN
                        R1("ItemNumber") = strItemNumber
                        R1("EnterpriseCode") = strEnterprise_Code

                        If strRepairOrderNumber = "" Then
                            R1("Could not Receive Reason") = "RepairOrderNumber is missing" & Environment.NewLine
                        End If
                        If strESN = "" Then
                            R1("Could not Receive Reason") &= "ESN is missing" & Environment.NewLine
                        End If
                        If strItemNumber = "" Then
                            R1("Could not Receive Reason") &= "ItemNumber is missing" & Environment.NewLine
                        End If

                        R1("File Name") = strFileName
                        dtRejectReason.Rows.Add(R1)
                        R1 = Nothing
                        dtRejectReason.AcceptChanges()
                    Else
                        'create new row insert datable
                        R1 = dtInsert.NewRow()
                        If IsNumeric(strASN_Number) Then
                            R1("csin_ASNNum") = CInt(strASN_Number)
                        Else
                            R1("csin_ASNNum") = 0
                        End If

                        R1("csin_EnterpriseCode") = strEnterprise_Code
                        R1("csin_Qty") = iQTY
                        R1("csin_Timestamp") = strTimeStamp
                        R1("csin_RepairOrderNum") = strRepairOrderNumber
                        R1("csin_ESN") = strESN
                        R1("csin_Model") = strModel
                        R1("csin_ItemNum") = strItemNumber
                        R1("csin_ItemDesc") = strItemDescription
                        R1("csin_AcctNum") = strAccountNumber
                        R1("csin_PrevRepairOrderNum") = strPreviousRepairOrderNumber
                        dtInsert.Rows.Add(R1)
                        R1 = Nothing
                        dtInsert.AcceptChanges()
                    End If
                Next m_node


                '**********************************
                '4::write xml data into database
                '**********************************
                For Each R1 In dtInsert.Rows
                    If Not IsNothing(dt1) Then
                        dt1.Dispose()
                        dt1 = Nothing
                    End If
                    '*********************************************
                    'Check if record already existed in database
                    '*********************************************
                    strSQL = "SELECT count(*) as cnt FROM cstincomingdata  " & Environment.NewLine
                    strSQL &= "WHERE flgReceived = 0 and Device_ID = 0 " & Environment.NewLine
                    strSQL &= "AND csin_ESN =  '" & R1("csin_ESN") & "';"

                    Me.objMisc._SQL = strSQL
                    dt1 = Me.objMisc.GetDataTable

                    If dt1.Rows(0)("cnt") = 0 Then
                        '************************************
                        'insert into cstincomingdata
                        '************************************
                        strFields = "csin_ASNNum, " & Environment.NewLine
                        strFields &= "csin_EnterpriseCode, " & Environment.NewLine
                        strFields &= "csin_Qty, " & Environment.NewLine
                        strFields &= "csin_Timestamp, " & Environment.NewLine
                        strFields &= "csin_RepairOrderNum, " & Environment.NewLine
                        strFields &= "csin_ESN, " & Environment.NewLine
                        strFields &= "csin_Model, " & Environment.NewLine
                        strFields &= "csin_ItemNum, " & Environment.NewLine
                        strFields &= "csin_ItemDesc, " & Environment.NewLine
                        strFields &= "csin_AcctNum, " & Environment.NewLine
                        strFields &= "csin_PrevRepairOrderNum "

                        strValues = R1("csin_ASNNum") & ", " & Environment.NewLine
                        strValues &= "'" & R1("csin_EnterpriseCode") & "', " & Environment.NewLine
                        strValues &= R1("csin_Qty") & ", " & Environment.NewLine
                        strValues &= "'" & R1("csin_Timestamp") & "', " & Environment.NewLine
                        strValues &= "'" & R1("csin_RepairOrderNum") & "', " & Environment.NewLine
                        strValues &= "'" & R1("csin_ESN") & "', " & Environment.NewLine
                        strValues &= "'" & R1("csin_Model") & "', " & Environment.NewLine
                        strValues &= "'" & R1("csin_ItemNum") & "', " & Environment.NewLine
                        strValues &= "'" & R1("csin_ItemDesc") & "', " & Environment.NewLine
                        strValues &= "'" & R1("csin_AcctNum") & "', " & Environment.NewLine
                        strValues &= "'" & R1("csin_PrevRepairOrderNum") & "' "


                        strSQL = "INSERT INTO cstincomingdata " & Environment.NewLine
                        strSQL &= "(" & Environment.NewLine
                        strSQL &= strFields & Environment.NewLine
                        strSQL &= ")" & Environment.NewLine
                        strSQL &= "VALUES " & Environment.NewLine
                        strSQL &= "(" & Environment.NewLine
                        strSQL &= strValues & Environment.NewLine
                        strSQL &= ");" & Environment.NewLine

                        Me.objMisc._SQL = strSQL
                        i += Me.objMisc.ExecuteNonQuery

                        '********************************************************
                        'insert into warehousepallet and warehousereceive
                        '********************************************************
                        System.Windows.Forms.Application.DoEvents()

                        If Not IsNothing(dt1) Then
                            dt1.Dispose()
                            dt1 = Nothing
                        End If

                        strSQL = "Select * FROM cs_partmap where part_number = " & R1("csin_ItemNum") & ";"
                        Me.objMisc._SQL = strSQL
                        dt1 = Me.objMisc.GetDataTable

                        If dt1.Rows.Count = 0 Then
                            iModel = 0
                            If strPartNum <> R1("csin_ItemNum") Then
                                strPartNum = R1("csin_ItemNum")
                                strNewPartNumbers &= R1("csin_ItemNum") & Environment.NewLine
                            End If
                        Else
                            r = dt1.Rows(0)
                            If Not IsDBNull(r("model_id")) Then
                                iModel = r("model_id")
                            Else
                                iModel = 0
                            End If
                        End If

                        blnWarehouse = load2Warehouse(R1("csin_RepairOrderNum"), R1("csin_ESN"), iMachineGroup, iModel)
                    End If
                    '********************************************************

                Next R1

                Return i
            Catch ex As Exception
                MsgBox("ERR occur in file: '" & strFileName & "' ::" & ex.ToString)
            Finally
                m_xmld = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                If Not IsNothing(dtInsert) Then
                    dtInsert.Dispose()
                    dtInsert = Nothing
                End If
            End Try
        End Function


        Public Function CreateCSAdvanceRecdt() As DataTable
            Dim dtNewTable As DataTable
            Dim ColNew As DataColumn

            Try
                dtNewTable = New DataTable()    'Create new datatable

                ColNew = New DataColumn("csin_EnterpriseCode")
                ColNew.DataType = System.Type.GetType("System.String")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("csin_ASNNum")
                ColNew.DataType = System.Type.GetType("System.Int32")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("csin_Qty")
                ColNew.DataType = System.Type.GetType("System.Int32")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("csin_Timestamp")
                ColNew.DataType = System.Type.GetType("System.String")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("csin_RepairOrderNum")
                ColNew.DataType = System.Type.GetType("System.String")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("csin_ESN")
                ColNew.DataType = System.Type.GetType("System.String")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("csin_Model")
                ColNew.DataType = System.Type.GetType("System.String")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("csin_ItemNum")
                ColNew.DataType = System.Type.GetType("System.String")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("csin_ItemDesc")
                ColNew.DataType = System.Type.GetType("System.String")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("csin_AcctNum")
                ColNew.DataType = System.Type.GetType("System.String")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("csin_PrevRepairOrderNum")
                ColNew.DataType = System.Type.GetType("System.String")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                Return dtNewTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function CreateCSAdvanceRecXML_RejectRptDt() As DataTable
            Dim dtNewTable As DataTable
            Dim ColNew As DataColumn

            Try
                dtNewTable = New DataTable()    'Create new datatable

                'ColNew = New DataColumn("EnterpriseCode")
                'ColNew.DataType = System.Type.GetType("System.String")
                'dtNewTable.Columns.Add(ColNew)
                'ColNew.Dispose()
                'ColNew = Nothing

                ColNew = New DataColumn("RepairOrderNumber")
                ColNew.DataType = System.Type.GetType("System.String")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("ESN")
                ColNew.DataType = System.Type.GetType("System.String")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                'ColNew = New DataColumn("Model")
                'ColNew.DataType = System.Type.GetType("System.String")
                'dtNewTable.Columns.Add(ColNew)
                'ColNew.Dispose()
                'ColNew = Nothing

                ColNew = New DataColumn("ItemNumber")
                ColNew.DataType = System.Type.GetType("System.String")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                'ColNew = New DataColumn("ItemDescription")
                'ColNew.DataType = System.Type.GetType("System.String")
                'dtNewTable.Columns.Add(ColNew)
                'ColNew.Dispose()
                'ColNew = Nothing

                'ColNew = New DataColumn("AccountNumber")
                'ColNew.DataType = System.Type.GetType("System.String")
                'dtNewTable.Columns.Add(ColNew)
                'ColNew.Dispose()
                'ColNew = Nothing

                ColNew = New DataColumn("Could not Receive Reason")
                ColNew.DataType = System.Type.GetType("System.String")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("File Name")
                ColNew.DataType = System.Type.GetType("System.String")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                Return dtNewTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************
        'use in loadAdvanceShipNotice function above
        '*******************************************************************
        Public Function load2Warehouse(ByVal tRepairOrderNumber As String, ByVal tESN As String, ByVal mParentGroupID As Integer, ByVal mModel As Integer) As Boolean
            Dim strSQL As String
            Dim WHPalletID As Long = 0
            Dim iGroup_id As Integer = 8
            Dim i As Integer = 0
            Dim dt1 As DataTable
            Dim R1 As DataRow

            If Len(Trim(tRepairOrderNumber)) > 0 And Len(Trim(tESN)) > 0 Then
                '//Data is OK for loading
            Else
                MsgBox("Not enough data provided to load to warehouse", MsgBoxStyle.OKOnly, "ERROR")
                Return False
            End If

            '//Load data to twarehousepallet
            strSQL = "INSERT INTO twarehousepallet " & _
            "(WHPallet_Number, " & _
            "WHDateLoaded, " & _
            "Model_ID, " & _
            "Cust_ID, " & _
            "WHP_CountedQty) " & _
            "VALUES " & _
            "('" & tRepairOrderNumber & "', " & _
            "'" & FormatDate(Now) & "', " & _
            mModel & ", " & _
            "2113, 1);"

            Me.objMisc._SQL = strSQL
            i = Me.objMisc.ExecuteNonQuery


            System.Windows.Forms.Application.DoEvents()

            'Get whpallet_id
            strSQL = "SELECT * FROM twarehousepallet WHERE WHPallet_Number = '" & tRepairOrderNumber & "' order by whpallet_id desc;"
            Me.objMisc._SQL = strSQL
            dt1 = Me.objMisc.GetDataTable

            If dt1.Rows.Count > 0 Then
                R1 = dt1.Rows(0)
                WHPalletID = R1("WHPallet_id")
            Else
                Throw New Exception("Error while insert new entry in twarehousepallet for pallet '" & tRepairOrderNumber & "'.")
            End If

            System.Windows.Forms.Application.DoEvents()

            '//Load data to twarehousepalletload
            strSQL = "INSERT INTO twarehousepalletload " & _
            "(WHP_BinLocation, " & _
            "WHP_PieceIdentifier, " & _
            "WHP_DateLoaded, " & _
            "WHP_RcvdFlag, " & _
            "WHP_TraigeWIPEntryDt, " & _
            "WHPallet_ID) " & _
            "VALUES " & _
            "('" & tRepairOrderNumber & "', " & _
            "'" & tESN & "', " & _
            "'" & FormatDate(Now) & "', " & _
            iGroup_id & ", " & _
            "'" & FormatDate(Now) & "', " & _
            WHPalletID & ");"

            Me.objMisc._SQL = strSQL
            i = Me.objMisc.ExecuteNonQuery

            If i = 0 Then
                MsgBox("ERROR")
                Return False
            End If
        End Function

        '**************************************************************
        'Print Brightpoint Part Numbers to be setup in PSS Database.rpt
        '**************************************************************
        Public Sub PrintCS_NewPartNumber_Rpt(ByVal strPartNumberList As String)

            'Dim ps As New PrinterSettings()
            'Dim rptApp As New CRAXDRT.Application()
            'Dim rpt As CRAXDRT.Report
            Dim i As Integer = 0
            Dim strRptPath As String = "R:\PSSInet_Reports_Prod\Cellstar Part Numbers to be setup in PSS Database.rpt"
            Dim objRpt As ReportDocument

            Try
                objRpt = New ReportDocument()

                With objRpt
                    .Load(strRptPath)
                    .SetParameterValue("Part Number", strPartNumberList)
                    .PrintToPrinter(1, True, 0, 0)
                End With

                'ps.DefaultPageSettings.Landscape = True
                'rpt = rptApp.OpenReport(strRptPath)
                'rpt.ParameterFields.GetItemByName("Part Number").AddCurrentValue(strPartNumberList)

                'rpt.PrintOut(False, 1)

            Catch ex As Exception
                Throw ex
                'Finally
                'If Not IsNothing(ps) Then
                '    ps = Nothing
                'End If
                'If Not IsNothing(rpt) Then
                '    rpt = Nothing
                'End If
                'If Not IsNothing(rptApp) Then
                '    rptApp = Nothing
                'End If
            End Try
        End Sub

        '**************************************************************
        'This function called from a hiding button on frmAdminCellstar
        '**************************************************************
        Public Sub createCloseReportReplace()

            Dim ds As PSS.Data.Production.Joins
            Dim strSQL As String
            Dim x, xParts, xWork, xPF, xRS As Integer
            Dim r, rParts, rWork, rPF, rRS As DataRow
            Dim dtParts As DataTable
            Dim dtWork As DataTable
            Dim dtPF As DataTable
            Dim dtRepairStatus As DataTable
            Dim mRepairStatus As String

            Dim blnProblemFound As Boolean
            Dim blnWorkPerformed As Boolean
            Dim blnUpdate As Boolean

            '//Define strFilename
            Dim strFilename As String = "240383" & DatePart(DateInterval.Year, Now()) & "-" & DatePart(DateInterval.Month, Now()) & "-" & DatePart(DateInterval.Day, Now()) & "T" & Format(Now(), "HHmmss") & "000.xml"
            MsgBox(strFilename)

            Dim myWriter As System.Xml.XmlTextWriter
            myWriter = New System.Xml.XmlTextWriter("c:\cellstar_wip_xml\Current\Closed\" & strFilename, Nothing)

            myWriter.Indentation = 4
            myWriter.IndentChar = " "
            myWriter.Formatting = myWriter.Indentation

            '//Get a list of all closed devices where ship date > '2006-08-24 00:00:00'
            'strSQL = "SELECT * FROM tdevice INNER JOIN cstincomingdata ON tdevice.device_SN = cstincomingdata.csin_ESN WHERE Loc_ID = 2636 AND tdevice.device_dateship is not null AND cstincomingdata.closedstatussent = 0"
            '//New November 2, 2006
            strSQL = "SELECT cstincomingdata.*, tdevice.*, tworkorder.wo_custwo FROM " & _
            "tdevice INNER JOIN tworkorder on cstincomingdata.csin_RepairOrderNum = tworkorder.wo_custwo " & _
            "inner join cstincomingdata on tdevice.device_oldsn = cstincomingdata.csin_esn and tworkorder.wo_custwo = cstincomingdata.csin_repairordernum " & _
            "WHERE tdevice.Loc_ID = 2636 AND tdevice.device_dateship is not null AND cstincomingdata.closedstatussent = 0"
            '//New November 2, 2006

            Dim dtDevices As DataTable = ds.OrderEntrySelect(strSQL)

            If dtDevices.Rows.Count > 0 Then
                '//There are devices to record

                myWriter.WriteStartDocument()
                myWriter.WriteStartElement("RepairUpdateStatus")

                For x = 0 To dtDevices.Rows.Count - 1
                    '//Device Header Data
                    r = dtDevices.Rows(x)

                    '//writer header values
                    myWriter.WriteStartElement("RepairItem")
                    myWriter.WriteElementString("InvoiceNumber", r("csin_RepairOrderNum"))
                    Try
                        If Len(Trim(r("csin_RepESN"))) > 0 Then
                            myWriter.WriteElementString("ESN", r("Device_OldSn"))
                        Else
                            myWriter.WriteElementString("ESN", r("csin_ESN"))
                        End If
                    Catch ex As Exception
                        myWriter.WriteElementString("ESN", r("csin_ESN"))
                    End Try
                    myWriter.WriteElementString("RepairStatus", "Out")
                    myWriter.WriteElementString("RepairStatusTimestamp", FormatDate(Now))
                    'myWriter.WriteElementString("RepairStatusTimestamp", r("Device_DateShip"))

                    myWriter.WriteElementString("ServiceCenterID", "0001")

                    '//Verify proper service code to use
                    mRepairStatus = ""
                    '//RUR Status
                    strSQL = "SELECT lbillcodes.billcode_id, lbillcodes.billcode_rule FROM tdevice " & _
                    "INNER JOIN tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
                    "INNER JOIN lbillcodes ON tdevicebill.billcode_id = lbillcodes.billcode_id " & _
                    "WHERE tdevice.device_id = " & r("Device_ID")
                    dtRepairStatus = ds.OrderEntrySelect(strSQL)

                    For xRS = 0 To dtRepairStatus.Rows.Count - 1
                        rRS = dtRepairStatus.Rows(xRS)
                        'RUR
                        If rRS("billcode_rule") = 1 Or rRS("billcode_rule") = 2 Then
                            mRepairStatus = "0"
                            Exit For
                        End If
                        'No Trouble Found
                        If rRS("billcode_id") = 541 Or rRS("billcode_id") = 533 Then
                            mRepairStatus = "5"
                            Exit For
                        End If
                        'Flashing
                        If rRS("billcode_id") = 1010 Then
                            mRepairStatus = "6"
                            Exit For
                        End If
                        'Cancelled
                        If rRS("billcode_id") = 466 Then
                            mRepairStatus = "7"
                            Exit For
                        End If
                    Next

                    If Len(Trim(mRepairStatus)) > 0 Then
                        myWriter.WriteElementString("RepairServiceLevel", mRepairStatus)
                    Else
                        myWriter.WriteElementString("RepairServiceLevel", r("Device_LaborLevel"))
                    End If
                    'mRepairStatus = ""
                    '//Verify proper service code to use

                    '//Get Parts Data (Multiple entries)
                    strSQL = "SELECT PSPrice_Number, PSPrice_Desc, Dbill_InvoiceAmt, Device_ManufWrty, Device_LaborCharge, Device_PSSWrty FROM tdevice INNER JOIN tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
                    "INNER JOIN tpsmap ON tdevicebill.billcode_id = tpsmap.billcode_id AND tdevice.model_id = tpsmap.model_id " & _
                    "INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.psprice_id " & _
                    "INNER JOIN lbillcodes ON tdevicebill.billcode_id = lbillcodes.billcode_id " & _
                    "WHERE lbillcodes.billtype_id = 2 " & _
                    "AND tdevice.device_id = " & r("Device_ID")

                    dtParts = ds.OrderEntrySelect(strSQL)
                    If dtParts.Rows.Count > 0 Then
                        myWriter.WriteStartElement("PartsConsumed")
                        For xParts = 0 To dtParts.Rows.Count - 1
                            rParts = dtParts.Rows(xParts)
                            myWriter.WriteStartElement("Parts")
                            myWriter.WriteElementString("PartNumber", rParts("PSPrice_Number"))
                            myWriter.WriteElementString("PartDescription", rParts("PSPrice_Desc"))
                            myWriter.WriteElementString("PartCost", rParts("DBill_InvoiceAmt"))
                            myWriter.WriteElementString("PartWarranty", rParts("Device_ManufWrty"))
                            myWriter.WriteElementString("PartQty", "1")
                            myWriter.WriteEndElement() '//from parts
                        Next
                        myWriter.WriteEndElement()
                    End If

                    '//Assign Labor Amount

                    'If Len(Trim(mRepairStatus)) > 0 Then
                    'myWriter.WriteElementString("LaborCost", "3.00")
                    'Else
                    '    Try
                    'rParts = dtParts.Rows(0)
                    'myWriter.WriteElementString("LaborCost", rParts("Device_LaborCharge"))
                    '    Catch ex As Exception
                    '    End Try
                    'End If

                    If Trim(mRepairStatus) = "0" Then
                        myWriter.WriteElementString("LaborCost", "3.00")
                    Else
                        Try
                            rParts = dtParts.Rows(0)
                            myWriter.WriteElementString("LaborCost", rParts("Device_LaborCharge"))
                        Catch ex As Exception
                        End Try
                    End If



                    '//Work Performed Section
                    strSQL = "select distinct dcode_sdesc, dcode_ldesc from " & _
                    "tdevice inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
                    "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
                    "left outer join tbillmap on tlocation.cust_id = tbillmap.cust_id AND " & _
                    "tdevice.model_id = tbillmap.model_id AND " & _
                    "tdevicebill.billcode_id = tbillmap.billcode_id " & _
                    "inner join lcodesdetail on tbillmap.bmap_repairaction = lcodesdetail.dcode_id " & _
                    "where tdevice.device_id = " & r("Device_ID")

                    dtWork = ds.OrderEntrySelect(strSQL)

                    blnWorkPerformed = False

                    If dtWork.Rows.Count > 0 Then
                        For xWork = 0 To dtWork.Rows.Count - 1
                            rWork = dtWork.Rows(xWork)
                            myWriter.WriteStartElement("WorkPerformed")
                            myWriter.WriteStartElement("Work")
                            myWriter.WriteElementString("WorkCode", rWork("Dcode_Sdesc"))
                            myWriter.WriteElementString("WorkDescription", rWork("Dcode_Ldesc"))
                            myWriter.WriteEndElement()
                            myWriter.WriteEndElement()
                            blnWorkPerformed = True
                        Next
                    End If

                    If Len(Trim(mRepairStatus)) > 0 Then
                        If mRepairStatus = 0 Then
                            myWriter.WriteStartElement("WorkPerformed")
                            myWriter.WriteStartElement("Work")
                            myWriter.WriteElementString("WorkCode", "BER")
                            myWriter.WriteElementString("WorkDescription", "Beyond Economical Repair")
                            myWriter.WriteEndElement()
                            myWriter.WriteEndElement()
                            blnWorkPerformed = True
                        End If
                        If mRepairStatus = 5 Then
                            myWriter.WriteStartElement("WorkPerformed")
                            myWriter.WriteStartElement("Work")
                            myWriter.WriteElementString("WorkCode", "NTF")
                            myWriter.WriteElementString("WorkDescription", "No Trouble Found")
                            myWriter.WriteEndElement()
                            myWriter.WriteEndElement()
                            blnWorkPerformed = True
                        End If
                        If mRepairStatus = 6 Then
                            myWriter.WriteStartElement("WorkPerformed")
                            myWriter.WriteStartElement("Work")
                            myWriter.WriteElementString("WorkCode", "WDN")
                            myWriter.WriteElementString("WorkDescription", "Device Wipedown")
                            myWriter.WriteEndElement()
                            myWriter.WriteEndElement()
                            blnWorkPerformed = True
                        End If
                        If mRepairStatus = 7 Then
                            myWriter.WriteStartElement("WorkPerformed")
                            myWriter.WriteStartElement("Work")
                            myWriter.WriteElementString("WorkCode", "CNLD")
                            myWriter.WriteElementString("WorkDescription", "Cancelled by Brightpoint")
                            myWriter.WriteEndElement()
                            myWriter.WriteEndElement()
                            blnWorkPerformed = True
                        End If
                    End If

                    If blnWorkPerformed = False Then
                        MsgBox("Device: " & r("csin_ESN") & "on WorkOrder: " & r("csin_RepairOrderNum") & " has no work performed (" & x & ", " & dtDevices.Rows.Count & ")", MsgBoxStyle.Critical, "ERROR")
                        Exit Sub
                    End If

                    '//Problem Found Section
                    strSQL = "select distinct dcode_sdesc, dcode_ldesc from " & _
                    "tdevice inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
                    "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
                    "left outer join tbillmap on tlocation.cust_id = tbillmap.cust_id AND " & _
                    "tdevice.model_id = tbillmap.model_id AND " & _
                    "tdevicebill.billcode_id = tbillmap.billcode_id " & _
                    "inner join lcodesdetail on tbillmap.bmap_problemfound = lcodesdetail.dcode_id " & _
                    "where tdevice.device_id = " & r("Device_ID")

                    blnProblemFound = False

                    dtPF = ds.OrderEntrySelect(strSQL)

                    Try
                        If dtPF.Rows.Count > 0 Then
                            For xPF = 0 To dtPF.Rows.Count - 1
                                rPF = dtPF.Rows(xPF)
                                myWriter.WriteStartElement("ProblemFound")
                                myWriter.WriteStartElement("Problem")
                                myWriter.WriteElementString("ProblemCode", rPF("Dcode_Sdesc"))
                                myWriter.WriteElementString("ProblemDescription", rPF("Dcode_Ldesc"))
                                myWriter.WriteEndElement()
                                myWriter.WriteEndElement()
                                blnProblemFound = True
                            Next
                        ElseIf mRepairStatus = 0 Then
                            myWriter.WriteStartElement("ProblemFound")
                            myWriter.WriteStartElement("Problem")
                            myWriter.WriteElementString("ProblemCode", "RUR")
                            myWriter.WriteElementString("ProblemDescription", "UNIT UNREPAIRABLE")
                            myWriter.WriteEndElement()
                            myWriter.WriteEndElement()
                            blnProblemFound = True
                        ElseIf mRepairStatus = 5 Then
                            myWriter.WriteStartElement("ProblemFound")
                            myWriter.WriteStartElement("Problem")
                            myWriter.WriteElementString("ProblemCode", "NTF")
                            myWriter.WriteElementString("ProblemDescription", "NO TROUBLE FOUND")
                            myWriter.WriteEndElement()
                            myWriter.WriteEndElement()
                            blnProblemFound = True
                        ElseIf mRepairStatus = 6 Then
                            myWriter.WriteStartElement("ProblemFound")
                            myWriter.WriteStartElement("Problem")
                            myWriter.WriteElementString("ProblemCode", "WDN")
                            myWriter.WriteElementString("ProblemDescription", "WIPEDOWN REQUESTED")
                            myWriter.WriteEndElement()
                            myWriter.WriteEndElement()
                            blnProblemFound = True
                        ElseIf mRepairStatus = 7 Then
                            myWriter.WriteStartElement("ProblemFound")
                            myWriter.WriteStartElement("Problem")
                            myWriter.WriteElementString("ProblemCode", "CLD")
                            myWriter.WriteElementString("ProblemDescription", "Brightpoint REQUESTED CANCELLATION")
                            myWriter.WriteEndElement()
                            myWriter.WriteEndElement()
                            blnProblemFound = True
                        End If
                    Catch ex As Exception
                        'This is normal device
                    End Try

                    If blnProblemFound = False Then
                        MsgBox("Device: " & r("csin_ESN") & "on WorkOrder: " & r("csin_RepairOrderNum") & " has no problem found", MsgBoxStyle.Critical, "ERROR")
                        Exit Sub
                    End If

                    '//Warranty Item - Device
                    Try
                        myWriter.WriteElementString("Warranty", rParts("Device_PSSWrty"))
                    Catch ex As Exception
                        '//New October 11, 2006
                        Dim dtPSSwrty As DataTable
                        dtPSSwrty = ds.OrderEntrySelect("SELECT Device_PSSWrty FROM tdevice WHERE Device_ID = " & r("Device_ID"))
                        Dim rPSSwrty As DataRow
                        rPSSwrty = dtPSSwrty.Rows(0)
                        myWriter.WriteElementString("Warranty", rPSSwrty("Device_PSSWrty"))
                        '//New October 11, 2006
                    End Try

                    'Try
                    'If Len(Trim(r("Device_OLDSN"))) > 0 Then
                    '    myWriter.WriteElementString("ReplacementESN", r("Device_SN"))
                    'End If
                    'Catch EX As Exception
                    'End Try

                    'Try
                    'If Len(Trim(r("csin_RepESN"))) > 0 Then
                    '    myWriter.WriteElementString("ReplacementESN", r("csin_RepEsn"))
                    'End If
                    'Catch EX As Exception
                    'End Try
                    Try
                        If Len(Trim(r("Device_SN"))) > 0 Then
                            myWriter.WriteElementString("ReplacementESN", r("Device_sn"))
                        End If
                    Catch EX As Exception
                    End Try


                    myWriter.WriteEndElement()
                    mRepairStatus = ""
                    blnWorkPerformed = False
                    blnProblemFound = False

                    '//New January 4, 2007
                    '//Update cstincomingdata per each serial number
                    strSQL = "UPDATE cstincomingdata  SET cstincomingdata.ClosedStatusSent = 9 WHERE csin_esn = '" & r("Device_oldSN") & "' AND csin_RepairOrderNum = '" & r("Wo_CustWO") & "'"
                    blnUpdate = ds.OrderEntryUpdateDelete(strSQL)
                    If blnUpdate = False Then
                        MsgBox("Error updating closed status.")
                    End If
                    '//New January 4, 2007
                Next

                myWriter.WriteEndElement()
                myWriter.WriteEndDocument()
                myWriter.Flush()

            End If

            'strSQL = "UPDATE tdevice, cstincomingdata  SET cstincomingdata.ClosedStatusSent = 9 WHERE tdevice.device_SN = cstincomingdata.csin_ESN and Loc_ID = 2636 AND tdevice.device_dateship is not null AND ClosedStatusSent = 0"
            'Dim blnUpdate As Boolean
            'blnUpdate = ds.OrderEntryUpdateDelete(strSQL)
            'If blnUpdate = False Then
            'MsgBox("Error updating closed status.")
            'End If
        End Sub

        '*****************************************************************
        'Brightpoint Close File
        '******************************************************************
        Public Function createCloseReport(ByVal strStartDt As String, _
                                    ByVal strEndDt As String, _
                                    Optional ByVal strDeviceIDs As String = "") As Integer

            Dim ds As PSS.Data.Production.Joins
            Dim strSQL As String
            Dim x, xParts, xRS As Integer
            Dim r, rParts, rWork, rPF, rRS As DataRow
            Dim dtParts As DataTable
            Dim dtWork As DataTable
            Dim dtPF As DataTable
            Dim dtRepairStatus As DataTable
            Dim mRepairStatus As String

            Dim blnProblemFound As Boolean
            Dim blnWorkPerformed As Boolean
            Dim blnUpdate As Boolean
            Dim blnResetFlag As Boolean
            Dim j As Integer = 0

            '***********************
            '//Define strFilename
            '***********************
            Dim strFilename As String = "240383" & DatePart(DateInterval.Year, Now()) & "-" & DatePart(DateInterval.Month, Now()) & "-" & DatePart(DateInterval.Day, Now()) & "T" & Format(Now(), "HHmmss") & "000.xml"
            Dim myWriter As System.Xml.XmlTextWriter
            'myWriter = New System.Xml.XmlTextWriter("c:\cellstar_wip_xml\Current\Closed\" & strFilename, Nothing)
            'MyFilePath = MyPath & strFilename
            MyFilePath = "P:\Dept\Cellstar\Brightpoint\RepairFiles\" & strFilename

            '****************************************
            '//New January 4, 2007
            '//Perform reset of flags that may have been updated incorrectly
            '****************************************
            strSQL = "UPDATE cstincomingdata, tdevice, tworkorder set cstincomingdata.closedstatussent = 0 WHERE cstincomingdata.csin_RepairOrderNum = tworkorder.wo_custwo " & _
            "AND tdevice.device_sn = cstincomingdata.csin_esn " & _
            "and tworkorder.wo_custwo = cstincomingdata.csin_repairordernum " & _
            "and tdevice.Loc_ID = 2636 " & _
            "and cstincomingdata.closedstatussent <> 0 " & _
            "and tdevice.device_dateship is null " & _
            "and tdevice.wo_id = tworkorder.wo_id "

            blnResetFlag = ds.OrderEntryUpdateDelete(strSQL)

            If blnResetFlag = False Then
                MsgBox("Reset Flag Failure. Exiting...", MsgBoxStyle.Critical, "ERROR")
                Exit Function
            End If
            '//New January 4, 2007

            '****************************************
            'Get all records for report
            '****************************************
            strSQL = "select  csin_RepairOrderNum, csin_ESN, csin_RepESN, " & Environment.NewLine
            strSQL &= "tdevice.*, tworkorder.wo_custwo, Cellopt_WIPOwner " & Environment.NewLine
            strSQL &= "from cstincomingdata " & Environment.NewLine
            strSQL &= "inner join tdevice on cstincomingdata.Device_ID = tdevice.Device_ID " & Environment.NewLine
            strSQL &= "inner join tworkorder on tdevice.WO_ID = tworkorder.wo_ID " & Environment.NewLine
            strSQL &= "inner join tcellopt on tcellopt.device_id = tdevice.device_id " & Environment.NewLine
            strSQL &= "WHERE tdevice.Loc_ID = 2636 " & Environment.NewLine
            strSQL &= "AND tcellopt.Cellopt_WIPOwner in (7, 74) " & Environment.NewLine
            strSQL &= "AND csin_EnterpriseCode in ('DOB', 'DBR') " & Environment.NewLine

            If Trim(strDeviceIDs) <> "" Then
                strSQL &= " AND tdevice.Device_ID in (" & strDeviceIDs & ");"
            Else
                'strSQL &= " AND tdevice.device_dateship is not null AND cstincomingdata.closedstatussent = 0;"
                'strSQL &= " AND tdevice.Device_ShipWorkDate >= '" & strStartDt & "' and tdevice.Device_ShipWorkDate <= '" & strEndDt & "' AND cstincomingdata.closedstatussent = 0;"
                strSQL &= " AND tdevice.Device_ShipWorkDate >= '" & strStartDt & "' and tdevice.Device_ShipWorkDate <= '" & strEndDt & "';"
            End If

            Dim dtDevices As DataTable = ds.OrderEntrySelect(strSQL)

            '*************************************
            'Lan added on 08/01/2007
            'Validate Labor Level and Laborcharge
            '*************************************
            If strDeviceIDs <> "" Then
                For Each r In dtDevices.Rows
                    If IsDBNull(r("Device_LaborLevel_AutoBilled")) Or IsDBNull(r("Device_LaborCharge_AutoBilled")) Then
                        MsgBox("Device_SN: " & r("Device_SN") & " did not go through special billing. Please check it again.", MsgBoxStyle.Critical, "ERROR")
                        Exit Function
                    End If
                Next r
            End If
            r = Nothing
            '*************************************

            If dtDevices.Rows.Count > 0 Then
                '//There are devices to record

                '*********************************** 
                'Lan move this section from top on 08/01/2007
                ' XML file only get create when there is record(s) in dtDevices 
                '*********************************** 
                'myWriter = New System.Xml.XmlTextWriter("P:\Dept\Cellstar\cellstar_wip_xml\Current\Closed\" & strFilename, Nothing)
                myWriter = New System.Xml.XmlTextWriter(MyFilePath, Nothing)

                myWriter.Indentation = 4
                myWriter.IndentChar = " "
                myWriter.Formatting = myWriter.Indentation
                '*********************************** 

                myWriter.WriteStartDocument()
                myWriter.WriteStartElement("RepairUpdateStatus")

                For x = 0 To dtDevices.Rows.Count - 1
                    '//Device Header Data
                    r = dtDevices.Rows(x)

                    'Lan added this condition on 04/13/07
                    If IsDBNull(r("csin_RepairOrderNum")) = False And IsDBNull(r("csin_ESN")) = False Then
                        If Trim(r("csin_RepairOrderNum")) <> "" And Trim(r("csin_ESN")) <> "" Then

                            '*************************
                            '//writer header values
                            '*************************
                            myWriter.WriteStartElement("RepairItem")
                            myWriter.WriteElementString("InvoiceNumber", r("csin_RepairOrderNum"))

                            '*************************
                            '//writer ESN
                            '*************************
                            Try
                                If Not IsDBNull(r("csin_RepESN")) Then
                                    myWriter.WriteElementString("ESN", r("Device_OldSn"))
                                Else
                                    myWriter.WriteElementString("ESN", r("csin_ESN"))
                                End If
                            Catch ex As Exception
                                myWriter.WriteElementString("ESN", r("csin_ESN"))
                            End Try

                            '*************************
                            '//writer Repair status
                            '*************************
                            myWriter.WriteElementString("RepairStatus", "Out")
                            myWriter.WriteElementString("RepairStatusTimestamp", FormatDate(Now))
                            'myWriter.WriteElementString("RepairStatusTimestamp", r("Device_DateShip"))

                            '***************************
                            '//writer service center ID
                            '***************************
                            myWriter.WriteElementString("ServiceCenterID", "0001")

                            '*************************************
                            '//Verify proper service code to use
                            '*************************************
                            mRepairStatus = ""
                            '//RUR Status
                            strSQL = "SELECT lbillcodes.billcode_id, lbillcodes.billcode_rule " & Environment.NewLine
                            strSQL &= ", lbillcodes.billtype_id, PSPrice_Number, PSPrice_Desc, Dbill_InvoiceAmt, Device_ManufWrty, Device_LaborCharge, Device_LaborCharge_AutoBilled, Device_PSSWrty " & Environment.NewLine
                            strSQL &= "FROM tdevice " & Environment.NewLine
                            strSQL &= "INNER JOIN tdevicebill_563 on tdevice.device_id = tdevicebill_563.device_id " & Environment.NewLine
                            strSQL &= "INNER JOIN lbillcodes ON tdevicebill_563.billcode_id = lbillcodes.billcode_id " & Environment.NewLine
                            '***************************************
                            'Lan combine this query and query below
                            '***************************************
                            strSQL &= "INNER JOIN tpsmap ON tdevicebill_563.billcode_id = tpsmap.billcode_id AND tdevice.model_id = tpsmap.model_id " & Environment.NewLine
                            strSQL &= "INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.psprice_id " & Environment.NewLine
                            '***************************************
                            strSQL &= "WHERE tdevice.device_id = " & r("Device_ID")
                            dtRepairStatus = ds.OrderEntrySelect(strSQL)

                            For xRS = 0 To dtRepairStatus.Rows.Count - 1
                                rRS = dtRepairStatus.Rows(xRS)
                                'RUR
                                If rRS("billcode_rule") = 1 Or rRS("billcode_rule") = 2 Then
                                    mRepairStatus = "0"
                                    Exit For
                                End If
                                'No Trouble Found, '255:No Part
                                If rRS("billcode_id") = 541 Or rRS("billcode_id") = 533 Or rRS("billcode_id") = 255 Then
                                    mRepairStatus = "5"
                                    Exit For
                                End If
                                'Flashing Wipe-Down Pass
                                If rRS("billcode_id") = 1010 Then
                                    mRepairStatus = "6"
                                    Exit For
                                End If

                                'Cancelled
                                If rRS("billcode_id") = 1053 Then
                                    mRepairStatus = "7"
                                    Exit For
                                End If
                            Next

                            If Len(Trim(mRepairStatus)) > 0 Then
                                myWriter.WriteElementString("RepairServiceLevel", mRepairStatus)
                            Else
                                'myWriter.WriteElementString("RepairServiceLevel", r("Device_LaborLevel"))
                                myWriter.WriteElementString("RepairServiceLevel", r("Device_LaborLevel_AutoBilled"))
                            End If

                            '*************************************
                            '//Get Parts Data (Multiple entries)
                            '*************************************
                            rParts = Nothing
                            If Trim(mRepairStatus) = "" Then
                                For Each rParts In dtRepairStatus.Rows
                                    If rParts("billtype_id") = 2 Then
                                        If Not IsDBNull(rParts("PSPrice_Number")) And Not IsDBNull(rParts("PSPrice_Desc")) And Not IsDBNull(rParts("DBill_InvoiceAmt")) Then
                                            myWriter.WriteStartElement("Parts")
                                            myWriter.WriteElementString("PartNumber", rParts("PSPrice_Number"))
                                            myWriter.WriteElementString("PartDescription", rParts("PSPrice_Desc"))
                                            myWriter.WriteElementString("PartCost", rParts("DBill_InvoiceAmt"))
                                            myWriter.WriteElementString("PartWarranty", rParts("Device_ManufWrty"))
                                            myWriter.WriteElementString("PartQty", "1")
                                            myWriter.WriteEndElement() '//from parts
                                        End If
                                    End If
                                Next rParts
                            End If

                            '***************************
                            'Write labor cost
                            '***************************
                            If Trim(mRepairStatus) = "0" Then
                                myWriter.WriteElementString("LaborCost", "3.00")
                            Else
                                myWriter.WriteElementString("LaborCost", r("Device_LaborCharge_AutoBilled"))
                            End If

                            '*************************************
                            '//Work Performed Section
                            '*************************************
                            blnWorkPerformed = False

                            If Trim(mRepairStatus) <> "" Then
                                If mRepairStatus = 0 Then
                                    myWriter.WriteStartElement("WorkPerformed")
                                    myWriter.WriteStartElement("Work")
                                    myWriter.WriteElementString("WorkCode", "BER")
                                    myWriter.WriteElementString("WorkDescription", "Beyond Economical Repair")
                                    myWriter.WriteEndElement()
                                    myWriter.WriteEndElement()
                                    blnWorkPerformed = True
                                End If
                                If mRepairStatus = 5 Then
                                    myWriter.WriteStartElement("WorkPerformed")
                                    myWriter.WriteStartElement("Work")
                                    myWriter.WriteElementString("WorkCode", "NTF")
                                    myWriter.WriteElementString("WorkDescription", "No Trouble Found")
                                    myWriter.WriteEndElement()
                                    myWriter.WriteEndElement()
                                    blnWorkPerformed = True
                                End If
                                If mRepairStatus = 6 Then
                                    myWriter.WriteStartElement("WorkPerformed")
                                    myWriter.WriteStartElement("Work")
                                    myWriter.WriteElementString("WorkCode", "WDN")
                                    myWriter.WriteElementString("WorkDescription", "Device Wipedown")
                                    myWriter.WriteEndElement()
                                    myWriter.WriteEndElement()
                                    blnWorkPerformed = True
                                End If
                                If mRepairStatus = 7 Then
                                    myWriter.WriteStartElement("WorkPerformed")
                                    myWriter.WriteStartElement("Work")
                                    myWriter.WriteElementString("WorkCode", "CNLD")
                                    myWriter.WriteElementString("WorkDescription", "Cancelled by Brightpoint")
                                    myWriter.WriteEndElement()
                                    myWriter.WriteEndElement()
                                    blnWorkPerformed = True
                                End If
                            Else
                                strSQL = "select distinct dcode_sdesc, dcode_ldesc" & Environment.NewLine
                                strSQL &= "from tdevice " & Environment.NewLine
                                strSQL &= "inner join tdevicebill_563 on tdevice.device_id = tdevicebill_563.device_id " & Environment.NewLine
                                strSQL &= "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & Environment.NewLine
                                strSQL &= "left outer join tbillmap on tlocation.cust_id = tbillmap.cust_id AND " & Environment.NewLine
                                strSQL &= " tdevice.model_id = tbillmap.model_id AND " & Environment.NewLine
                                strSQL &= " tdevicebill_563.billcode_id = tbillmap.billcode_id " & Environment.NewLine
                                strSQL &= "inner join lcodesdetail on tbillmap.bmap_repairaction = lcodesdetail.dcode_id " & Environment.NewLine
                                strSQL &= "where tdevice.device_id = " & r("Device_ID")

                                dtWork = ds.OrderEntrySelect(strSQL)
                                If dtWork.Rows.Count > 0 Then
                                    For Each rWork In dtWork.Rows
                                        If Not IsDBNull(rWork("Dcode_Sdesc")) And Not IsDBNull(rWork("Dcode_Ldesc")) Then
                                            myWriter.WriteStartElement("WorkPerformed")
                                            myWriter.WriteStartElement("Work")
                                            myWriter.WriteElementString("WorkCode", rWork("Dcode_Sdesc"))
                                            myWriter.WriteElementString("WorkDescription", rWork("Dcode_Ldesc"))
                                            myWriter.WriteEndElement()
                                            myWriter.WriteEndElement()
                                            blnWorkPerformed = True
                                        End If
                                    Next rWork
                                End If
                            End If

                            If blnWorkPerformed = False Then
                                MsgBox("Device: " & r("csin_ESN") & " on WorkOrder: " & r("csin_RepairOrderNum") & " has no work performed (" & x & ", " & dtDevices.Rows.Count & ")", MsgBoxStyle.Critical, "ERROR")
                                Exit Function
                            End If

                            '*************************************
                            '//Problem Found Section
                            '*************************************
                            blnProblemFound = False

                            If Trim(mRepairStatus) <> "" Then
                                If mRepairStatus = 0 Then
                                    myWriter.WriteStartElement("ProblemFound")
                                    myWriter.WriteStartElement("Problem")
                                    myWriter.WriteElementString("ProblemCode", "RUR")
                                    myWriter.WriteElementString("ProblemDescription", "UNIT UNREPAIRABLE")
                                    myWriter.WriteEndElement()
                                    myWriter.WriteEndElement()
                                    blnProblemFound = True
                                ElseIf mRepairStatus = 5 Then
                                    myWriter.WriteStartElement("ProblemFound")
                                    myWriter.WriteStartElement("Problem")
                                    myWriter.WriteElementString("ProblemCode", "NTF")
                                    myWriter.WriteElementString("ProblemDescription", "NO TROUBLE FOUND")
                                    myWriter.WriteEndElement()
                                    myWriter.WriteEndElement()
                                    blnProblemFound = True
                                ElseIf mRepairStatus = 6 Then
                                    myWriter.WriteStartElement("ProblemFound")
                                    myWriter.WriteStartElement("Problem")
                                    myWriter.WriteElementString("ProblemCode", "WDN")
                                    myWriter.WriteElementString("ProblemDescription", "WIPEDOWN REQUESTED")
                                    myWriter.WriteEndElement()
                                    myWriter.WriteEndElement()
                                    blnProblemFound = True
                                ElseIf mRepairStatus = 7 Then
                                    myWriter.WriteStartElement("ProblemFound")
                                    myWriter.WriteStartElement("Problem")
                                    myWriter.WriteElementString("ProblemCode", "CLD")
                                    myWriter.WriteElementString("ProblemDescription", "BRIGHTPOINT REQUESTED CANCELLATION")
                                    myWriter.WriteEndElement()
                                    myWriter.WriteEndElement()
                                    blnProblemFound = True
                                End If
                            Else
                                strSQL = "select distinct dcode_sdesc, dcode_ldesc " & Environment.NewLine
                                strSQL &= "FROM tdevice " & Environment.NewLine
                                strSQL &= "INNER JOIN tdevicebill_563 on tdevice.device_id = tdevicebill_563.device_id " & Environment.NewLine
                                strSQL &= "INNER JOIN tlocation on tdevice.loc_id = tlocation.loc_id " & Environment.NewLine
                                strSQL &= "LEFT OUTER JOIN tbillmap on tlocation.cust_id = tbillmap.cust_id AND " & Environment.NewLine
                                strSQL &= " tdevice.model_id = tbillmap.model_id AND " & Environment.NewLine
                                strSQL &= " tdevicebill_563.billcode_id = tbillmap.billcode_id " & Environment.NewLine
                                strSQL &= "INNER JOIN lcodesdetail on tbillmap.bmap_problemfound = lcodesdetail.dcode_id " & Environment.NewLine
                                strSQL &= "WHERE tdevice.device_id = " & r("Device_ID")

                                dtPF = ds.OrderEntrySelect(strSQL)
                                rPF = Nothing
                                If dtPF.Rows.Count > 0 Then
                                    For Each rPF In dtPF.Rows
                                        If Not IsDBNull(rPF("Dcode_Sdesc")) And Not IsDBNull(rPF("Dcode_Ldesc")) Then
                                            myWriter.WriteStartElement("ProblemFound")
                                            myWriter.WriteStartElement("Problem")
                                            myWriter.WriteElementString("ProblemCode", rPF("Dcode_Sdesc"))
                                            myWriter.WriteElementString("ProblemDescription", rPF("Dcode_Ldesc"))
                                            myWriter.WriteEndElement()
                                            myWriter.WriteEndElement()
                                            blnProblemFound = True
                                        End If
                                    Next rPF
                                End If
                            End If

                            If blnProblemFound = False Then
                                MsgBox("Device: " & r("csin_ESN") & "on WorkOrder: " & r("csin_RepairOrderNum") & " has no problem found", MsgBoxStyle.Critical, "ERROR")
                                Exit Function
                            End If

                            '*************************************
                            '//Warranty Item - Device
                            '*************************************
                            Try
                                '//January 5, 2007
                                myWriter.WriteElementString("Warranty", r("Device_PSSWrty"))
                                '//January 5, 2007
                            Catch ex As Exception
                                '//New October 11, 2006
                                Dim dtPSSwrty As DataTable
                                dtPSSwrty = ds.OrderEntrySelect("SELECT Device_PSSWrty FROM tdevice WHERE Device_ID = " & r("Device_ID"))
                                Dim rPSSwrty As DataRow
                                rPSSwrty = dtPSSwrty.Rows(0)
                                myWriter.WriteElementString("Warranty", rPSSwrty("Device_PSSWrty"))
                                '//New October 11, 2006
                            End Try

                            '*************************************
                            'Write replace ESN
                            '*************************************
                            Try
                                If Len(Trim(r("csin_RepESN"))) > 0 Then
                                    If Not IsDBNull(r("csin_RepEsn")) Then
                                        myWriter.WriteElementString("ReplacementESN", r("csin_RepEsn"))
                                    End If
                                End If
                            Catch EX As Exception
                            End Try

                            myWriter.WriteEndElement()
                            mRepairStatus = ""
                            blnWorkPerformed = False
                            blnProblemFound = False

                            '''''*************************************
                            '''''//New January 4, 2007
                            '''''//Update cstincomingdata per each serial number
                            '''''*************************************
                            ''''If Trim(strDeviceIDs) = "" And r("Cellopt_WIPOwner") = 7 Then
                            ''''    strSQL = "UPDATE cstincomingdata SET cstincomingdata.ClosedStatusSent = 9 WHERE Device_ID = " & r("Device_ID") & ";"
                            ''''    blnUpdate = ds.OrderEntryUpdateDelete(strSQL)
                            ''''    If blnUpdate = False Then
                            ''''        MsgBox("Error updating closed status.")
                            ''''    End If
                            ''''End If
                            '''''//New January 4, 2007
                            '''''*************************************

                        End If  'check csin_RepairOrderNum And csin_ESN is not blank
                    End If  'check csin_RepairOrderNum And csin_ESN is not null
                Next x

                myWriter.WriteEndElement()
                myWriter.WriteEndDocument()
                myWriter.Close()

                MsgBox("XML report has completely created.")
            End If

            Return j
        End Function


        '*****************************************************************
        'current use
        '******************************************************************
        Private Function FormatDate(ByVal valStartDate As Date) As String

            FormatDate = ""

            Dim vMnth As String
            Dim vDay As String
            Dim vYear As String

            Dim vHour As String
            Dim vMinute As String
            Dim vSecond As String

            Dim valDate As Date
            valDate = valStartDate

            vMnth = DatePart(DateInterval.Month, valDate)
            vDay = DatePart(DateInterval.Day, valDate)
            If Len(vDay) < 2 Then vDay = "0" & vDay
            If Len(vMnth) < 2 Then vMnth = "0" & vMnth
            vYear = DatePart(DateInterval.Year, valDate)

            vHour = DatePart(DateInterval.Hour, valDate)
            vMinute = DatePart(DateInterval.Minute, valDate)
            vSecond = DatePart(DateInterval.Second, valDate)

            FormatDate = vYear & "-" & vMnth & "-" & vDay & " " & vHour & ":" & vMinute & ":" & vSecond

        End Function

        '*****************************************************************
        Public Function GetUnMapBillcodesInfo(ByVal iCust_ID As Integer, _
                                              ByVal strStarDt As String, _
                                              ByVal strEndDt As String) As DataTable
            Dim strSql As String

            Try
                strSql = "select distinct lbillcodes.BillCode_ID, lbillcodes.BillCode_Desc, tdevice.Model_ID, tmodel.Model_Desc " & Environment.NewLine
                strSql &= "from tdevice, cstincomingdata, tcellopt " & Environment.NewLine
                strSql &= "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & Environment.NewLine
                strSql &= "inner join tmodel on tdevice.model_id = tmodel.model_id " & Environment.NewLine
                strSql &= "inner join tdevicebill_563 on tdevice.device_id = tdevicebill_563.Device_ID " & Environment.NewLine
                strSql &= "inner join lbillcodes on tdevicebill_563.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
                strSql &= "left outer join tbillmap on tdevicebill_563.BillCode_ID = tbillmap.BillCode_ID " & Environment.NewLine
                strSql &= "and tbillmap.model_id = tdevice.model_id and tbillmap.Cust_Id = 2113 " & Environment.NewLine
                strSql &= "where tdevice.Device_ID = cstincomingdata.Device_ID and tdevice.Device_ID = tcellopt.Device_ID " & Environment.NewLine
                ''Filter Wipe Down model
                'strSql &= "and tmodel.Model_Type = 0 " & Environment.NewLine
                'Filter out RUR, NER... billcodes
                strSql &= "and BillCode_Rule not in (1,2) " & Environment.NewLine
                'Filter 541,533:NTF, Wipe 1010:Down and 1053:Customer Cancel, 255:No Part
                strSql &= "and lbillcodes.billcode_id not in (541,533,1010,1053,255) " & Environment.NewLine
                strSql &= "and tbillmap.BMap_ID is null " & Environment.NewLine
                strSql &= "and tdevice.Device_ShipWorkDate >= '" & strStarDt & "' " & Environment.NewLine
                strSql &= "and tdevice.Device_ShipWorkDate <= '" & strEndDt & "' " & Environment.NewLine
                strSql &= "and tlocation.cust_id = " & iCust_ID & Environment.NewLine
                strSql &= "and tcellopt.Cellopt_WIPOwner = 7;"

                Me.objMisc._SQL = strSql
                Return Me.objMisc.GetDataTable

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************


    End Class

End Namespace
