Imports EncDec
Imports System
Imports System.Collections
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms
Imports System.Xml

Public Class ConfigFile
    Private Shared strConfigFile As String = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile

    Const _strConfigNodeName As String = "configuration"
    Const _strConnectionNodeName As String = "connection"
    Const _strUseAttributeName = "use"
    Const _strUseAttributeConnectionName = "name"
    Const _strPasswordNodeName As String = "password"
    Const _strPathsNodeName As String = "paths"
    Const _strReportNodeName As String = "report"
    Const _strBaseNodeName As String = "base"
    Const _strCrystalReportsNodeName = "CrystalReports"
    Const _strPrintDateFormatNodeName = "PrintDateFormat"
    Const _strPrintTimeFormatNodeName = "PrintTimeFormat"
    Const _strBarcodePrinterNodeName = "BarcodePrinterName"

    Private Shared _server As String

    Public Sub New()

    End Sub

    Private Shared Function LoadXMLDocument() As XmlDocument
        Dim doc As XmlDocument

        ' Load config file 
        Try
            doc = New XmlDocument()

            doc.Load(strConfigFile)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End Try

        Return doc
    End Function

    Public Shared Function GetConnectionInfo() As ArrayList
        Dim doc As XmlDocument
        Dim xmllstNode As XmlNodeList
        Dim objConnInfo() As Object
        Dim i, j, k, iParentNodeIndex, iChildNodeIndex As Integer
        Dim arrlstConnInfo As ArrayList
        Dim arrlstNodeValues As ArrayList
        Dim strNodeName, strEncPW, strDecPW, strErr As String

        Try

            doc = LoadXMLDocument()
            xmllstNode = doc.GetElementsByTagName(_strConfigNodeName)

            If xmllstNode.Count > 0 Then
                iParentNodeIndex = -1
                iChildNodeIndex = -1

                For i = 0 To xmllstNode.Count - 1
                    If xmllstNode(i).HasChildNodes Then
                        For j = 0 To xmllstNode(i).ChildNodes.Count - 1
                            If xmllstNode(i).ChildNodes(j).Name = _strConnectionNodeName Then
                                For k = 0 To xmllstNode(i).ChildNodes(j).Attributes.Count - 1
                                    If xmllstNode(i).ChildNodes(j).Attributes(k).Name.Equals(_strUseAttributeName) Then
                                        If xmllstNode(i).ChildNodes(j).Attributes(k).Value.Equals("1") Then
                                            iParentNodeIndex = i
                                            iChildNodeIndex = j

                                            Exit For
                                        End If
                                    End If
                                Next
                            End If

                            If iParentNodeIndex > -1 And iChildNodeIndex > -1 Then Exit For
                        Next j
                    End If

                    If iParentNodeIndex > -1 And iChildNodeIndex > -1 Then Exit For
                Next i

                'PASSED

                If iParentNodeIndex > -1 And iChildNodeIndex > -1 Then
                    arrlstConnInfo = New ArrayList(xmllstNode(iParentNodeIndex).ChildNodes(iChildNodeIndex).ChildNodes.Count)

                    For i = 0 To xmllstNode(iParentNodeIndex).ChildNodes(iChildNodeIndex).ChildNodes.Count - 1
                        arrlstNodeValues = New ArrayList(2)
                        strNodeName = xmllstNode(iParentNodeIndex).ChildNodes(iChildNodeIndex).ChildNodes(i).Name.ToLower
                        arrlstNodeValues.Add(strNodeName)

                        If strNodeName = _strPasswordNodeName Then
                            strEncPW = xmllstNode(iParentNodeIndex).ChildNodes(iChildNodeIndex).ChildNodes(i).InnerText
                            strErr = ""

                            If strEncPW.Trim.Length > 0 Then
                                strDecPW = EncDec.Rijndael.Decrypt(strEncPW, strErr)

                                If strErr.Length > 0 Then
                                    strDecPW = ""

                                    MessageBox.Show("An error occurred while attempting to decrypt the user password: " & strErr, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                                End If
                            Else
                                strDecPW = ""
                            End If

                            arrlstNodeValues.Add(strDecPW)
                        Else
                            arrlstNodeValues.Add(xmllstNode(iParentNodeIndex).ChildNodes(iChildNodeIndex).ChildNodes(i).InnerText)
                            If strNodeName = "server" Then
                                _server = xmllstNode(iParentNodeIndex).ChildNodes(iChildNodeIndex).ChildNodes(i).InnerText
                            End If
                        End If

                        arrlstConnInfo.Add(arrlstNodeValues)
                    Next

                Else
                    MessageBox.Show("Unable to locate a 'connection' tag with the 'use' attribute set to 1 in the configuration file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                End If
            Else
                MessageBox.Show("Unable to locate any 'connection' tags in the configuration file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End If

            'PASSED

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End Try

        Return arrlstConnInfo
    End Function

    Public Shared Function GetBaseReportPath() As String
        Dim strBaseReportPath As String = ""
        Dim doc As XmlDocument
        Dim xmllstNode As XmlNodeList
        Dim xmlPathNode, xmlReportNode As XmlNode
        Dim i, j, k, l As Integer
        Dim bFound As Boolean = False

        Try
            doc = LoadXMLDocument()
            xmllstNode = doc.GetElementsByTagName(_strConfigNodeName)

            If xmllstNode.Count > 0 Then
                For i = 0 To xmllstNode.Count - 1
                    If xmllstNode(i).HasChildNodes Then
                        For j = 0 To xmllstNode(i).ChildNodes.Count - 1
                            If xmllstNode(i).ChildNodes(j).Name = _strPathsNodeName Then
                                xmlPathNode = xmllstNode(i).ChildNodes(j)

                                If xmlPathNode.HasChildNodes Then
                                    For k = 0 To xmlPathNode.ChildNodes.Count - 1
                                        If xmlPathNode.ChildNodes(k).Name = _strReportNodeName Then
                                            xmlReportNode = xmlPathNode.ChildNodes(k)

                                            If xmlReportNode.HasChildNodes Then
                                                For l = 0 To xmlReportNode.ChildNodes.Count - 1
                                                    If xmlReportNode.ChildNodes(l).Name = _strBaseNodeName Then
                                                        ' Phew!
                                                        strBaseReportPath = xmlReportNode.ChildNodes(l).InnerText
                                                        bFound = True

                                                        Exit For
                                                    End If
                                                Next l
                                            End If
                                        End If

                                        If bFound Then Exit For
                                    Next k
                                End If
                            End If

                            If bFound Then Exit For
                        Next j
                    End If

                    If bFound Then Exit For
                Next i
            End If

            If Not bFound Then MessageBox.Show("Unable to locate the base report path in the configuration file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End Try

        Return strBaseReportPath
    End Function

    Public Shared Function GetCRPrintDateFormat() As String
        Dim strCRPrintDateFormat As String = "ddd, MMM d, yyyy"
        Dim doc As XmlDocument
        Dim xmllstNode As XmlNodeList
        Dim i, j As Integer
        Dim bFound As Boolean = False

        Try
            doc = LoadXMLDocument()
            xmllstNode = doc.GetElementsByTagName(_strCrystalReportsNodeName)

            If xmllstNode.Count > 0 Then
                For i = 0 To xmllstNode.Count - 1
                    If xmllstNode(i).HasChildNodes Then
                        For j = 0 To xmllstNode(i).ChildNodes.Count - 1
                            If xmllstNode(i).ChildNodes(j).Name = _strPrintDateFormatNodeName Then
                                strCRPrintDateFormat = xmllstNode(i).ChildNodes(j).InnerText
                                bFound = True

                                Exit For
                            End If
                        Next j
                    End If

                    If bFound Then Exit For
                Next i
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End Try

        Return strCRPrintDateFormat
    End Function

    Public Shared Function GetCRPrintTimeFormat() As String
        Dim strCRPrintTimeFormat As String = "h:mm tt"
        Dim doc As XmlDocument
        Dim xmllstNode As XmlNodeList
        Dim i, j As Integer
        Dim bFound As Boolean = False

        Try
            doc = LoadXMLDocument()
            xmllstNode = doc.GetElementsByTagName(_strCrystalReportsNodeName)

            If xmllstNode.Count > 0 Then
                For i = 0 To xmllstNode.Count - 1
                    If xmllstNode(i).HasChildNodes Then
                        For j = 0 To xmllstNode(i).ChildNodes.Count - 1
                            If xmllstNode(i).ChildNodes(j).Name = _strPrintTimeFormatNodeName Then
                                strCRPrintTimeFormat = xmllstNode(i).ChildNodes(j).InnerText
                                bFound = True

                                Exit For
                            End If
                        Next j
                    End If

                    If bFound Then Exit For
                Next i
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End Try

        Return strCRPrintTimeFormat
    End Function

    Public Shared Function GetBarcodePrinterName() As String
        Dim strBarcodePrinterName As String = ""
        Dim doc As XmlDocument
        Dim xmllstNode As XmlNodeList
        Dim i, j As Integer
        Dim bFound As Boolean = False

        Try
            doc = LoadXMLDocument()
            xmllstNode = doc.GetElementsByTagName(_strCrystalReportsNodeName)

            If xmllstNode.Count > 0 Then
                For i = 0 To xmllstNode.Count - 1
                    If xmllstNode(i).HasChildNodes Then
                        For j = 0 To xmllstNode(i).ChildNodes.Count - 1
                            If xmllstNode(i).ChildNodes(j).Name = _strBarcodePrinterNodeName Then
                                strBarcodePrinterName = xmllstNode(i).ChildNodes(j).InnerText
                                bFound = True

                                Exit For
                            End If
                        Next j
                    End If

                    If bFound Then Exit For
                Next i
            End If

            Return strBarcodePrinterName
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End Try
    End Function

    Public Shared ReadOnly Property Server() As String
        Get
            Return _server
        End Get
    End Property

End Class
