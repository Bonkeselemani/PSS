Option Explicit On 

Imports System
Imports System.Data
Imports System.Text
Imports System.IO
Imports System.Windows.Forms
Imports MySql.Data

Namespace Buisness.TracFoneFulfillmentKit
    Public Class TFFK_BYOP_EDI
        Private _objDataProc As mySQL5
        Private _iEDI864_Outbound_SetID As Integer = 1
        Private _strEDI864_Outbound_Path As String = ""
        Private _strEDI864_Outbound_MailTo As String = ""
        Private _strEDI864_Outbound_MailToErr As String = ""
        Private _strMailFrom As String = ""
        Private _strMailPW As String = ""
        Private _strSMTPServer As String = ""

        Private _dtSIM As DataTable
        Private _dtAltSIM As DataTable
        Private _dtOtherComponents As DataTable
        Private _iKP_ID As Integer = 0
        Private _strWIP_Number As String = ""
        Private _strKitting_Number As String = ""

        Private _strLineEndChar As String = "~" & Environment.NewLine
        'ISA*00*          *00*          *12*9724623970     *12*3056402063     *181113*1351*U*00403*100000893*0*P*>
        Private _strISA As String = "ISA*00*          *00*          *12*9724623970     *12*3056402063     *yyMMdd*HHmm*U*00403*000000000*0*P*>" & Me._strLineEndChar
        'GS*TX*9724623970*3056402063*20181113*1351*200000893*X*004030
        Private _strGS As String = "GS*TX*9724623970*3056402063*yyyyMMdd*HHmm*000000000*X*004030" & Me._strLineEndChar
        'ST*864*300001119
        Private _strST As String = "ST*864*"

        'MSG*R7C,PSSI_IO,1,PWW.A405A502.RA,PSS_SALABL,,TF5151928,27-Mar-2019,,,K00511,,,,1100001010554,10,015114009515620~
        Private strR7C As String = "MSG*R7C,PSSI_IO,M_Qty,M_Model,PSS_SALABL,,TF_WIP,DTime,,,Kit_Number,,,,1100001010554,10" & Me._strLineEndChar
        'MSG*R7I,K00505,PWW.A405A502.RA,TWALA405DCP,2,15~
        Private strR7I As String = "MSG*R7I,Kit_Number,M_Model,C_Model,C_Qty,15" & Me._strLineEndChar
        'MSG*R7S,PSSI_IO,015114009515620,,1,TWALA405DCP,20~
        Private strR7S As String = "MSG*R7S,PSSI_IO,SN,,S_Qty,S_Model,20" & Me._strLineEndChar

        Private _strISA_ID As String = ""
        Private _strGS_ID As String = ""
        Private _strST_ID As String = ""

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
        Public Property dtSIM() As DataTable
            Get
                Return Me._dtSIM
            End Get
            Set(ByVal value As DataTable)
                Me._dtSIM = value
            End Set
        End Property

        Public Property dtAltSIM() As DataTable
            Get
                Return Me._dtAltSIM
            End Get
            Set(ByVal value As DataTable)
                Me._dtAltSIM = value
            End Set
        End Property

        Public Property dtOtherComponents() As DataTable
            Get
                Return Me._dtOtherComponents
            End Get
            Set(ByVal value As DataTable)
                Me._dtOtherComponents = value
            End Set
        End Property

        Public Property strWIP_Number() As String
            Get
                Return Me._strWIP_Number
            End Get
            Set(ByVal value As String)
                Me._strWIP_Number = value
            End Set
        End Property

        Public Property strKittingNumber() As String
            Get
                Return Me._strKitting_Number
            End Get
            Set(ByVal value As String)
                Me._strKitting_Number = value
            End Set
        End Property

        Public Property iKP_ID() As Integer
            Get
                Return Me._iKP_ID
            End Get
            Set(ByVal value As Integer)
                Me._iKP_ID = value
            End Set
        End Property
#End Region

        Private Function getSMTPServer() As String
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim row
            Try
                'SMTPID, Server, AttachmentSizeLimitMB
                strSql = "SELECT * FROM reports.smtp;"
                dt = Me._objDataProc.GetDataTable(strSql)
                For Each row In dt.Rows
                    Me._strSMTPServer = Convert.ToString(row("Server")).Trim
                    Exit For
                Next
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        Public Function getOutbound864Setup() As DataTable
            Dim strSql As String = ""
            Try
                'ESet_ID, ESet_Desc, EDI_Direction, EDI_Type, File_Path, EmailAddresses, Exception_EmailTo, EmailFromID, EmailFromPW, Active
                strSql = "SELECT * FROM edi.ttffk_edi_setup" & Environment.NewLine
                strSql &= " WHERE ESet_ID= " & Me._iEDI864_Outbound_SetID & " AND  EDI_Direction ='Outbound' AND EDI_type='864';" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function IsOutbound864Setup() As Boolean
            Dim dt As DataTable
            Dim row
            Try
                'ESet_ID, ESet_Desc, EDI_Direction, EDI_Type, File_Path, EmailAddresses, Exception_EmailTo, EmailFromID, EmailFromPW, Active
                dt = Me.getOutbound864Setup

                If dt.Rows.Count = 0 Then
                    MessageBox.Show("No set up data for outbound 864.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    For Each row In dt.Rows
                        Me._strEDI864_Outbound_Path = Convert.ToString(row("File_Path")).Trim
                        Me._strEDI864_Outbound_MailTo = Convert.ToString(row("EmailAddresses")).Trim
                        Me._strEDI864_Outbound_MailToErr = Convert.ToString(row("Exception_EmailTo")).Trim
                        Me._strMailFrom = Convert.ToString(row("EmailFromID")).Trim
                        Me._strMailPW = Convert.ToString(row("EmailFromPW")).Trim
                        Return True
                        Exit For
                    Next
                End If
                Return False
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Private Function getGUID() As String
            Dim strGUID As String = ""
            strGUID = System.Guid.NewGuid.ToString()
            Return strGUID
        End Function

        Private Function getEDI864_FileName(ByVal iKP_ID As Integer) As String
            Try
                Return "864_" & Format(Now, "yyyyMMddHHmmss") & "_" & iKP_ID.ToString & ".x12"
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Private Function getEDI864_ID(ByVal strEDI_Tag_ISA_GS_ST As String, ByVal strFileName As String) As String
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim row As DataRow
            Dim strGUID As String = ""
            Dim strPreFix As String = ""
            Dim strID_Name As String = ""
            Dim iID As Integer = 0
            Dim i As Integer = 0

            Try
                'ESet_ID, EDI_Tag, ID, ID_Name, EDI_FileName, GUID
                Select Case strEDI_Tag_ISA_GS_ST.Trim.ToUpper
                    Case "ISA".ToUpper
                        strPreFix = "6"
                    Case "GS".ToUpper
                        strPreFix = "7"
                    Case "ST".ToUpper
                        strPreFix = "8"
                End Select
                strGUID = Me.getGUID.Trim.Replace("'", "''")
                strEDI_Tag_ISA_GS_ST = strEDI_Tag_ISA_GS_ST.Trim.Replace("'", "''")

                strSql = "INSERT INTO edi.ttffk_edi_IDs (ESet_ID, EDI_Tag, EDI_FileName, GUID) " & Environment.NewLine
                strSql &= " VALUES (" & Me._iEDI864_Outbound_SetID & ",'" & strEDI_Tag_ISA_GS_ST & "','" & strFileName & "','" & strGUID & "');" & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                strSql = "SELECT * FROM edi.ttffk_edi_IDs WHERE GUID ='" & strGUID & "';"
                dt = Me._objDataProc.GetDataTable(strSql)
                For Each row In dt.Rows 'must be 1 row
                    iID = row("ID")
                    strID_Name = strPreFix & iID.ToString.PadLeft(8, "0")
                    strSql = "UPDATE edi.ttffk_edi_IDs SET ID_Name = '" & strID_Name & "' WHERE GUID ='" & strGUID & "';"
                    i += Me._objDataProc.ExecuteNonQuery(strSql)
                    Exit For
                Next

            Catch ex As Exception
                Throw ex
            End Try

            Return strID_Name
        End Function


        Public Function GenerateOutbound_EDI864() As Boolean
            Dim strFileName As String = ""
            Dim strISA_ID As String = ""
            Dim strGS_ID As String = ""
            Dim strST_ID As String = ""
            Dim strISA_Date As String = Format(Now, "yyMMdd")
            Dim strTime As String = Format(Now, "HHmm")
            Dim strGS_Date As String = Format(Now, "yyyyMMdd")
            Dim strDate As String = Format(Now, "dd-MMM-yyyy")
            Dim strOutput As String = ""
            Dim iST_SE_LineCount As Integer = 0

            Dim iC_Qty As Integer = 0
            Dim iS_Qty As Integer = 0
            Dim row As DataRow
            Dim strMasterItem As String = ""
            Dim strC_Model As String = ""
            Dim strS_Model As String = ""
            Dim strSN As String = ""

            Dim strPathFileName As String = ""

            'ISA*00*          *00*          *12*9724623970     *12*3056402063     *181113*1351*U*00403*100000893*0*P*>
            'Private _strISA As String = "ISA*00*          *00*          *12*9724623970     *12*3056402063     *yyMMdd*HHmm*U*00403*000000000*0*P*>" & Me._strLineEndChar
            'GS*TX*9724623970*3056402063*20181113*1351*200000893*X*004030
            '  Private _strGS As String = "GS*TX*9724623970*3056402063*yyyyMMdd*HHmm*000000000*X*004030" & Me._strLineEndChar
            'ST*864*300001119
            'Private _strST As String = "ST*864*"

            'MSG*R7C,PSSI_IO,1,PWW.A405A502.RA,PSS_SALABL,,TF5151928,27-Mar-2019,,,K00511,,,,1100001010554,10,015114009515620~
            'Private strR7C As String = "MSG*R7C,PSSI_IO,M_Qty,M_Model,PSS_SALABL,,TF_WIP,DTime,,,Kit_Number,,,,1100001010554,10" & Me._strLineEndChar
            'MSG*R7I,K00505,PWW.A405A502.RA,TWALA405DCP,2,15~
            'Private strR7I As String = "MSG*R7I,Kit_Number,M_Model,C_Model,C_Qty,15" & Me._strLineEndChar
            'MSG*R7S,PSSI_IO,015114009515620,,1,TWALA405DCP,20~
            'Private strR7S As String =  "MSG*R7S,PSSI_IO,SN,,S_Qty,S_Model,20" & Me._strLineEndChar

            Try
                strFileName = getEDI864_FileName(Me._iKP_ID)
                strISA_ID = Me.getEDI864_ID("ISA", strFileName)
                strGS_ID = Me.getEDI864_ID("GS", strFileName)
                strST_ID = Me.getEDI864_ID("ST", strFileName)

                ' MessageBox.Show(strISA_ID & "  " & strGS_ID & " " & strST_ID)

                'Header
                Me._strISA = Me._strISA.Replace("000000000", strISA_ID).Replace("yyMMdd", strISA_Date).Replace("HHmm", strTime)
                Me._strGS = Me._strGS.Replace("000000000", strGS_ID).Replace("yyyyMMdd", strGS_Date).Replace("HHmm", strTime)
                Me._strST = Me._strST & strST_ID & Me._strLineEndChar
                strOutput = Me._strISA & Me._strGS & Me._strST
                iST_SE_LineCount += 1

                'Sub-header
                strOutput &= "BMG*00*WORK ORDER TRANSACTION" & Me._strLineEndChar
                strOutput &= "MIT*R7C*WIP ASSEMBLY COMPLETION" & Me._strLineEndChar
                strOutput &= "N1*WH**UL*1100001010554" & Me._strLineEndChar
                iST_SE_LineCount += 3

                'Kitting_Setup, Master_Item, UPC, ItemUPC, Component, SN, Qty, Master_Desc, Component_Desc, Master_Model_ID, Component_Model_ID, Component_Type
                ', KMSet_ID, KDSet_ID, KASet_ID, WI_ID, WR_ID, OrderBy, IsKeySIM, SIM_Qty, Alt_SIM_Qty, Collateral_Qty, PackQtyPerCarton, MaxCartonQtyPerPallet, HasItemUPC

                'R7C
                For Each row In Me._dtSIM.Rows
                    strMasterItem = Convert.ToString(row("Master_Item"))
                    Exit For
                Next
                strR7C = strR7C.Replace("M_Qty", "1").Replace("M_Model", strMasterItem).Replace("TF_WIP", Me._strWIP_Number).Replace("DTime", strDate).Replace("Kit_Number", Me._strKitting_Number)
                strOutput &= strR7C '& Me._strLineEndChar
                iST_SE_LineCount += 1

                'R7I
                For Each row In Me._dtOtherComponents.Rows
                    strC_Model = Convert.ToString(row("Component")) : iC_Qty = Convert.ToInt32(row("Qty"))
                    strOutput &= strR7I.Replace("Kit_Number", Me._strKitting_Number).Replace("M_Model", strMasterItem).Replace("C_Model", strC_Model).Replace("C_Qty", iC_Qty.ToString)
                    ' strOutput &= strR7I '& Me._strLineEndChar
                    iST_SE_LineCount += 1
                Next

                'R7S
                For Each row In Me._dtSIM.Rows
                    strS_Model = Convert.ToString(row("Component")) : iS_Qty = Convert.ToInt32(row("Qty"))
                    strSN = Convert.ToString(row("SN"))
                    strOutput &= strR7S.Replace("SN", strSN).Replace("S_Qty", iS_Qty.ToString).Replace("S_Model", strS_Model)
                    'strOutput &= strR7S '& Me._strLineEndChar
                    iST_SE_LineCount += 1
                Next
                For Each row In Me._dtAltSIM.Rows
                    strS_Model = Convert.ToString(row("Component")) : iS_Qty = Convert.ToInt32(row("Qty"))
                    strSN = Convert.ToString(row("SN"))
                    strOutput &= strR7S.Replace("SN", strSN).Replace("S_Qty", iS_Qty.ToString).Replace("S_Model", strS_Model)
                    'strOutput &= strR7S '& Me._strLineEndChar
                    iST_SE_LineCount += 1
                Next

                'End
                iST_SE_LineCount += 1
                strOutput &= "SE*" & iST_SE_LineCount.ToString & "*" & strST_ID & Me._strLineEndChar
                strOutput &= "GE*1*" & strGS_ID & Me._strLineEndChar
                strOutput &= "IEA*1*" & strISA_ID

                'Save 864 EDI file
                If IsOutbound864Setup() Then
                    'debug--------------------------
                    'strPathFileName = Me._strEDI864_Outbound_Path & "\debug\" & strFileName
                    'production---------------------
                    strPathFileName = Me._strEDI864_Outbound_Path & "\" & strFileName
                    SaveTextFile(strPathFileName, strOutput)
                    Return True
                End If
                Return False
            Catch ex As Exception
                Throw ex
            End Try

        End Function

        Public Function SaveTextFile(ByVal strPathFileName As String, ByVal strText As String) As Boolean
            Dim path As String = strPathFileName ' "c:\temp\MyTest.txt"
            ' Create or overwrite the file.
            Dim fs As FileStream = File.Create(path)

            ' Add text to the file.
            Dim info As Byte() = New UTF8Encoding(True).GetBytes(strText)
            fs.Write(info, 0, info.Length)
            fs.Close()
            Return True
        End Function

    End Class
End Namespace
