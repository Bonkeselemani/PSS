
Namespace Gui.MotorolaSubcontract
    Public Class frmShipPartialPalletts
        Inherits System.Windows.Forms.Form
        Private objMotoSubcontract_Biz As PSS.Data.Buisness.MotorolaSubcontract_Biz
        Private objMotoSubContShipping As frmMotoSubContShipping
        Private ObjUtilib As MyLib.Utility
        Private iWO_ID As Integer
        'Private iErrFlag As Integer = 0
        Private R1 As DataRow
        Private iPallett_ID As Integer = 0

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal iWOID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            iWO_ID = iWOID
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        Friend WithEvents lstOverpacks As System.Windows.Forms.ListBox
        Friend WithEvents txtOverpack As System.Windows.Forms.TextBox
        Friend WithEvents btnPrint As System.Windows.Forms.Button
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents cmdCancel As System.Windows.Forms.Button
        Friend WithEvents btnClear As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmShipPartialPalletts))
            Me.lstOverpacks = New System.Windows.Forms.ListBox()
            Me.txtOverpack = New System.Windows.Forms.TextBox()
            Me.btnPrint = New System.Windows.Forms.Button()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.cmdCancel = New System.Windows.Forms.Button()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            '
            'lstOverpacks
            '
            Me.lstOverpacks.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.lstOverpacks.BackColor = System.Drawing.Color.SkyBlue
            Me.lstOverpacks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lstOverpacks.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lstOverpacks.ForeColor = System.Drawing.Color.Black
            Me.lstOverpacks.Location = New System.Drawing.Point(156, 85)
            Me.lstOverpacks.Name = "lstOverpacks"
            Me.lstOverpacks.Size = New System.Drawing.Size(157, 223)
            Me.lstOverpacks.TabIndex = 1
            '
            'txtOverpack
            '
            Me.txtOverpack.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.txtOverpack.BackColor = System.Drawing.Color.SkyBlue
            Me.txtOverpack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtOverpack.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtOverpack.ForeColor = System.Drawing.Color.Black
            Me.txtOverpack.Location = New System.Drawing.Point(156, 56)
            Me.txtOverpack.Name = "txtOverpack"
            Me.txtOverpack.Size = New System.Drawing.Size(157, 21)
            Me.txtOverpack.TabIndex = 0
            Me.txtOverpack.Text = ""
            '
            'btnPrint
            '
            Me.btnPrint.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.btnPrint.BackColor = System.Drawing.Color.Transparent
            Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPrint.ForeColor = System.Drawing.Color.White
            Me.btnPrint.Location = New System.Drawing.Point(156, 324)
            Me.btnPrint.Name = "btnPrint"
            Me.btnPrint.Size = New System.Drawing.Size(157, 32)
            Me.btnPrint.TabIndex = 2
            Me.btnPrint.Text = "Print"
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(145, 33)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(113, 21)
            Me.Label1.TabIndex = 39
            Me.Label1.Text = "Overpack IDs :"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmdCancel
            '
            Me.cmdCancel.BackColor = System.Drawing.Color.Transparent
            Me.cmdCancel.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdCancel.ForeColor = System.Drawing.Color.White
            Me.cmdCancel.Location = New System.Drawing.Point(344, 208)
            Me.cmdCancel.Name = "cmdCancel"
            Me.cmdCancel.Size = New System.Drawing.Size(88, 32)
            Me.cmdCancel.TabIndex = 3
            Me.cmdCancel.Text = "Cancel"
            '
            'btnClear
            '
            Me.btnClear.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnClear.BackColor = System.Drawing.Color.Transparent
            Me.btnClear.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClear.ForeColor = System.Drawing.Color.White
            Me.btnClear.Location = New System.Drawing.Point(344, 152)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnClear.Size = New System.Drawing.Size(88, 32)
            Me.btnClear.TabIndex = 44
            Me.btnClear.Text = "Clear List"
            '
            'frmShipPartialPalletts
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Bitmap)
            Me.ClientSize = New System.Drawing.Size(464, 395)
            Me.ControlBox = False
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnClear, Me.cmdCancel, Me.Label1, Me.lstOverpacks, Me.txtOverpack, Me.btnPrint})
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "frmShipPartialPalletts"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Ship Partial Palletts (Cell Administration)"
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmShipPartialPalletts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Me.txtOverpack.Focus()
            Me.txtOverpack.BackColor = System.Drawing.Color.Yellow
        End Sub

        '***************************************************************************
        'This event fires when a device is scanned in
        '***************************************************************************
        Private Sub txtOverpack_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOverpack.KeyDown
            Dim dt As DataTable
            Try
                If e.KeyValue = 13 Then

                    Dim i As Integer
                    'Dim R1 As DataRow
                    '***************************************
                    If Not IsNumeric(Me.txtOverpack.Text) Then
                        MsgBox("Please enter a numeric value for Overpack ID.", MsgBoxStyle.Information, "Ship Partial Palletts")
                        Exit Sub
                    End If
                    '***************************************
                    'check for duplicates in list, if exists exit sub
                    For i = 0 To Me.lstOverpacks.Items.Count - 1
                        If Me.lstOverpacks.Items(i) = UCase(lstOverpacks.Text) Then
                            MsgBox("This Overpack is already scanned in. Try another one.", MsgBoxStyle.Information, "Shipping partial Palletts")
                            Me.txtOverpack.Text = ""
                            Me.txtOverpack.Focus()
                            Me.txtOverpack.ForeColor = System.Drawing.Color.Yellow
                            Exit Sub
                        End If
                    Next
                    '***************************************
                    objMotoSubcontract_Biz = New PSS.Data.Buisness.MotorolaSubcontract_Biz()
                    dt = objMotoSubcontract_Biz.GetOverpackInfo(CInt(Me.txtOverpack.Text))

                    For Each R1 In dt.Rows      'There will be only one row.
                        If iPallett_ID = 0 Then
                            iPallett_ID = R1("Pallett_ID")
                        Else
                            If R1("Pallett_ID") <> iPallett_ID Then
                                MsgBox("Please scan in the Overpacks that belong to the same Pallett as the previous one.", MsgBoxStyle.Information, "Ship Partial Palletts")
                                Me.txtOverpack.Text = ""
                                Exit Sub
                            End If
                        End If

                        If IsDBNull(R1("Overpack_Shipdate")) Then
                            MsgBox("The Overpack you have just scanned in is not shipped yet. Can't move to the new pallett.", MsgBoxStyle.Information, "Ship Partial Palletts")
                            Me.txtOverpack.Text = ""
                            Exit Sub
                        End If

                        If Not IsDBNull(R1("Pallett_Shipdate")) Then
                            MsgBox("Pallett for the overpack you just scanned in has already been shipped. Can't change palletts now.", MsgBoxStyle.Information, "Ship Partial Palletts")
                            Me.txtOverpack.Text = ""
                            Exit Sub
                        End If
                        '***************************************

                    Next

                    '***************************************
                    'If everything is fine then add this Device_SN to the list box
                    Me.lstOverpacks.Items.Add(UCase(Trim(Me.txtOverpack.Text)))
                    Me.txtOverpack.Text = ""
                    Me.txtOverpack.Focus()
                    Me.txtOverpack.BackColor = System.Drawing.Color.Yellow
                End If
            Catch ex As Exception
                MsgBox("frmMotoSubContShipping.txtDevice_KeyDown: " & ex.Message.ToString, MsgBoxStyle.Critical, "Motorola Sub-contract Shipping")
            Finally
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If

                If Not IsNothing(objMotoSubcontract_Biz) Then
                    objMotoSubcontract_Biz = Nothing
                End If
            End Try
        End Sub

        Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
            Cursor.Current = Cursors.WaitCursor
            Me.btnPrint.Enabled = False

            If Me.lstOverpacks.Items.Count = 0 Then
                MsgBox("Please scan in Overpacks to ship.", MsgBoxStyle.Information, "Ship Partial Palletts")
                Me.btnPrint.Enabled = True
                Cursor.Current = Cursors.Default
                Exit Sub
            End If

            Dim dt As DataTable
            Dim iLOC_ID As Integer
            Dim i As Integer
            Dim strOverpackIds As String = ""
            Dim iPallett_ID As Integer

            Try
                objMotoSubcontract_Biz = New PSS.Data.Buisness.MotorolaSubcontract_Biz()
                '*******************************************
                'First get the LOC_ID
                dt = objMotoSubcontract_Biz.GetLOCID(iWO_ID)
                For Each R1 In dt.Rows      'There may be more than one row. Just take the first one to get the LOC_ID
                    iLOC_ID = R1("Loc_ID")
                    Exit For
                Next

                If IsDBNull(iLOC_ID) Or CStr(iLOC_ID) = "" Then
                    MsgBox("There are no already created palletts for this work order. Operation aborted.", MsgBoxStyle.Information, "Ship Partial Palletts")
                    Me.btnPrint.Enabled = True
                    Cursor.Current = Cursors.Default
                    Exit Sub
                End If
                '*******************************************
                'Create a new Pallett
                iPallett_ID = objMotoSubcontract_Biz.CreateNewPallett(iWO_ID, iLOC_ID)
                '*******************************************
                'Loop through the list items and build a string of Overpackids
                strOverpackIds = ""
                For i = 0 To Me.lstOverpacks.Items.Count - 1
                    If i <> Me.lstOverpacks.Items.Count - 1 Then
                        strOverpackIds = strOverpackIds & Trim(Me.lstOverpacks.Items(i)) & ", "
                    Else
                        strOverpackIds = strOverpackIds & Trim(Me.lstOverpacks.Items(i))
                    End If
                Next
                '*******************************************
                'Unassing the old Pallett
                i = 0
                i = objMotoSubcontract_Biz.UnassignPallett(strOverpackIds)
                '*******************************************
                'Assign the new Pallett
                i = 0
                i = objMotoSubcontract_Biz.AssignPallett(iPallett_ID, strOverpackIds)
                '*******************************************
                'Assign the Newly created Pallett a ship date
                Dim strPallettShipDate As String

                Try
                    ObjUtilib = New MyLib.Utility()
                    strPallettShipDate = ObjUtilib.FormatDate_YYYYMMDD_HHMMSS(Now())
                    i = objMotoSubcontract_Biz.AssignShipDateToPallett(iPallett_ID, strPallettShipDate)
                Catch ex As Exception
                    MsgBox("frmMotoSubContShipping.BtnPrint_Click.AssignShipDateToPallett: " & ex.Message.ToString)
                Finally
                    ObjUtilib = Nothing
                End Try

                '*******************************************
                'Print Pallet Manifest
                Dim strFormula As String
                objMotoSubContShipping = New frmMotoSubContShipping(0)   'Sending 0 for nothing. No reason.
                strFormula = "{tpallett.Pallett_ID} = " & iPallett_ID
                i = objMotoSubContShipping.Print("Default on WCCELLULAR", True, "Ship_Manifest_Pallett.rpt", strFormula, 2)
                strFormula = ""
                '*******************************************
                'Cleanup the list box
                Me.lstOverpacks.Items.Clear()
                Me.txtOverpack.Text = ""
                Me.txtOverpack.Focus()
                Me.txtOverpack.BackColor = System.Drawing.Color.Yellow
                '*******************************************
            Catch ex As Exception
                MsgBox("frmShipPartialPalletts.BtnPrint_Click: " & ex.Message.ToString)
            Finally

                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If

                If Not IsNothing(objMotoSubcontract_Biz) Then
                    objMotoSubcontract_Biz = Nothing
                End If

                Me.btnPrint.Enabled = True
                Cursor.Current = Cursors.Default
            End Try

        End Sub

        Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
            Me.Close()
            Me.Dispose()
        End Sub

        Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
            Me.lstOverpacks.Items.Clear()
        End Sub
    End Class
End Namespace
