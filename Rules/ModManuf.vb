Imports PSS.Data

Namespace Rules

    Public Class ModManuf

#Region "Model"
        Public Shared Function PopulateModels() As DataTable
            Return Buisness.ModManuf.GetModels()
        End Function

        Public Shared Function DoModelAdd(ByVal manuf As Integer) As Boolean
            Dim win As New PSS.Gui.Model(0)
            win.ShowDialog()
        End Function

        Public Shared Function InsertModel(ByVal model As String, ByVal tier As Integer, ByVal flat As Integer, _
                                                    ByVal manuf As Integer, ByVal prod As Integer, ByVal asc As Integer, ByVal iRptGrp As Integer, _
                                                    ByVal iAPCCode As Integer, ByVal iGSM As Integer, ByVal iModelType As Integer, ByVal strModel_MotoSku As String, ByVal iAutoBill As Integer, ByVal iAccessoryCategory As Integer) As Integer
            Try
                Return Buisness.ModManuf.InsertModel(model, tier, flat, manuf, prod, asc, iRptGrp, iAPCCode, iGSM, iModelType, strModel_MotoSku, iAutoBill, iAccessoryCategory, PSS.Core.[Global].ApplicationUser.IDuser)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function DeleteModel(ByVal model_id As Integer) As Boolean
            If MsgBox("Are you sure you wish to delete this Model?", MsgBoxStyle.YesNo, "Delete Model") = MsgBoxResult.Yes Then
                Return Buisness.ModManuf.DeleteModel(model_id)
            End If
        End Function

        Public Shared Function UpdateModel(ByVal model As Integer) As Boolean
            Dim win As New PSS.Gui.Model(model)
            win.ShowDialog()
        End Function


        Public Shared Function DoUpdateModel(ByVal model_id As Integer, ByVal model As String, ByVal tier As Integer, ByVal flat As Integer, _
                                                    ByVal manuf As Integer, ByVal prod As Integer, ByVal asc As Integer, ByVal iRptGrp_ID As Integer, _
                                                    ByVal iAPCCode As Integer, ByVal iGSM As Integer, ByVal iModelType As Integer, ByVal iAutoBill As Integer, ByVal iAccessoryCategory As Integer)

            Buisness.ModManuf.UpdateModel(model_id, model, tier, flat, manuf, prod, asc, iRptGrp_ID, iAPCCode, iGSM, iModelType, iAutoBill, iAccessoryCategory, PSS.Core.[Global].ApplicationUser.IDuser)
        End Function

        Public Shared Function GetModel(ByVal id As Integer) As DataTable
            Return Buisness.ModManuf.GetModel(id)
        End Function

        Public Shared Sub UpdateModelFamily(ByVal iModelID As Integer, ByVal iModelFamilyID As Integer)

        End Sub
#End Region

#Region "Manufacture"
        Public Shared Function PopulateManufs() As DataTable
            Return Buisness.ModManuf.GetManufs()
        End Function

        '********************************************************************************************************************************
        'Fix duplicate on 2011-06-30
        Public Shared Function DoManufAdd() As Boolean
            Dim response As String = InputBox("Please type the name of the manufacture you wish to add", "Add Manufacture")
            Try
                If Len(response) > 0 Then
                    response = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(response)
                    If Buisness.ModManuf.IsManufExisted(response) = True Then
                        MessageBox.Show("Manufacture is already existed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    Else
                        If MsgBox("Are you sure you wish to add " & response & "?", MsgBoxStyle.YesNo, "Add Manufacture") = MsgBoxResult.Yes Then
                            Buisness.ModManuf.InsertManuf(Trim(response))
                            Return True
                        Else
                            Return False
                        End If
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************************************************************************
        Public Shared Function DeleteManuf(ByVal manuf_id As Integer) As Boolean
            If MsgBox("Are you sure you wish to delete this Manufacture?", MsgBoxStyle.YesNo, "Delete Manufacture") = MsgBoxResult.Yes Then
                Return Buisness.ModManuf.DeleteManuf(manuf_id)
            End If
        End Function

        Public Shared Function UpdateManuf(ByVal manuf_id As Integer) As Boolean
            Dim response As String = InputBox("Please type the new name of the manufacture.", "Update Manufacture")
            If Len(response) > 0 Then
                response = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(response)
                If MsgBox("Are you sure you want to rename to " & response & "?", MsgBoxStyle.YesNo, "Update Manufacture") = MsgBoxResult.Yes Then
                    Buisness.ModManuf.UpdateManuf(manuf_id, Trim(response))
                    Return True
                End If
            End If
            Return False
        End Function
#End Region

#Region "Product Group"
        Public Shared Function GetProductGroups() As DataTable
            Return Buisness.ModManuf.GetProductGroupsLong
        End Function
        Public Shared Function GetProductGroup(ByVal id As Integer) As DataRow
            Return Buisness.ModManuf.LoadProductGroup(id)
        End Function
        '******************************************************
        'This code is added by Asif on 12/04/2003
        '******************************************************
        Public Shared Function GetReportGroups() As DataTable
            Return Buisness.ModManuf.GetReportGroupsLong
        End Function
        Public Shared Function GetReportGroup(ByVal id As Integer) As DataRow
            Return Buisness.ModManuf.LoadReportGroup(id)
        End Function
        Public Shared Function InsertReportGroup(ByVal Desc As String, ByVal Prod As Integer)
            Buisness.ModManuf.InsertReportGroup(Desc, Prod)
        End Function
        Public Shared Function UpdateReportGroup(ByVal id As Integer, ByVal strDesc As String, ByVal iProd As Integer)
            Buisness.ModManuf.UpdateReportGroup(id, strDesc, iProd)
        End Function
        Public Shared Function DeleteReportGroup(ByVal id As Integer)
            If MsgBox("Are you sure you want to delete this Report Group?", MsgBoxStyle.YesNo, "Delete") = MsgBoxResult.Yes Then
                Buisness.ModManuf.DeleteReportGroup(id)
            End If
        End Function
        '******************************************************
        Public Shared Function InsertProductGroup(ByVal SDesc As String, ByVal LDesc As String, ByVal Prod As Integer)
            Buisness.ModManuf.InsertProductGroup(SDesc, LDesc, Prod)
        End Function
        Public Shared Function UpdateProductGroup(ByVal id As Integer, ByVal SDesc As String, ByVal LDesc As String, ByVal Prod As Integer)
            Buisness.ModManuf.UpdateProductGroup(id, SDesc, LDesc, Prod)
        End Function
        Public Shared Function DeleteProductGroup(ByVal id As Integer)
            If MsgBox("Are you sure you want to delete this product group?", MsgBoxStyle.YesNo, "Delete") = MsgBoxResult.Yes Then
                Buisness.ModManuf.DeleteProductGroup(id)
            End If
        End Function
#End Region

        Public Shared Function GetMapped() As System.Data.DataView
            Try
                Return Buisness.ModManuf.GetModelsMapped.DefaultView
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function GetModelsMapped() As System.Data.DataTable
            Try
                Return Buisness.ModManuf.GetModelsMapped
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        'Public Shared Function GetProdGrps(Optional ByVal iModel_ID As Integer = 0) As DataTable
        Public Shared Function GetProdGrps(Optional ByVal iProd_ID As Integer = 0) As DataTable
            'Return Buisness.ModManuf.GetProductGroups(iModel_ID)       'Commented by Asif on 12/08/2003
            Return Buisness.ModManuf.GetProductGroups(iProd_ID)
        End Function

        '***************************************************
        'Added by Asif on 12/03/2003
        '***************************************************
        Public Shared Function GetRptGrps(ByVal iProd_ID As Integer) As DataTable
            Return Buisness.ModManuf.GetReportGroups(iProd_ID)
        End Function
        '***************************************************

        Public Shared Function GetProducts() As DataTable
            Return Buisness.ModManuf.GetProducts
        End Function

        Public Shared Function GetASC(ByVal iProd_ID As Integer) As DataTable
            Return Buisness.ModManuf.GetASC(iProd_ID)
        End Function

        Public Shared Function GetModelFamily(ByVal iModelID As Integer) As String
            Return Buisness.ModManuf.GetModelFamily(iModelID)
        End Function

#Region "ModelFamilies"
        Public Shared Function GetModelFamilies() As DataTable
            Try
                Return Buisness.ModManuf.LoadModelFamilies
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function GetModelCountForModelFamily(ByVal iModelFamilyID As Integer) As Integer
            Dim dt As DataTable
            Dim iCount As Integer = 0
            Dim strModelIDs() As String

            Try
                dt = Buisness.ModManuf.GetModelIDSetForModelFamily(iModelFamilyID)
                strModelIDs = Convert.ToString(dt.Rows(0)(0)).Split(",")

                If strModelIDs.Length > 0 Then iCount = strModelIDs.Length

                Return iCount
            Catch ex As Exception
                Throw ex
            Finally
                dt.Dispose()
                dt = Nothing
            End Try
        End Function

        Public Shared Sub DeleteModelFamily(ByVal iModelFamilyID As Integer)
            Try
                Buisness.ModManuf.DeleteModelFamily(iModelFamilyID)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
#End Region

#Region "AddEditModelFamily"
        Public Shared Function GetCustomers() As DataTable
            Try
                Return Buisness.ModManuf.GetCustomers
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function CheckExisitingModelFamilies(ByVal strModelFamily As String) As Boolean
            Dim bExists As Boolean = False
            Dim dt As DataTable

            Try
                dt = Buisness.ModManuf.CheckExisitingModelFamilies(strModelFamily)

                If dt.Rows.Count > 0 Then bExists = dt.Rows(0)(0) <> 0

                Return bExists
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Sub AddNewModelFamily(ByVal strModelFamily As String)
            Try
                Buisness.ModManuf.AddNewModelFamily(strModelFamily)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub UpdateModelFamily(ByVal strOldModelFamily As String, ByVal strNewModelFamily As String)
            Try
                Buisness.ModManuf.UpdateModelFamily(strOldModelFamily, strNewModelFamily)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
#End Region
    End Class

End Namespace
