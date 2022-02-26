Option Explicit On 

Imports PSS.Data.Buisness
Imports System.Text

Namespace Gui.Cp
    Public Class frmCoolPadSpecialReceiving
        Inherits System.Windows.Forms.Form
        Private _iWB_ID As Integer = 0
        Private _strRecvBoxName As String = ""
        Private _iRecID_Seed As Integer = 0
        Private _iMenuCustID As Integer = 0
        Private _iMenuLocID As Integer = 0
        Private _strScreenName As String = ""
        Private _strUserName As String = PSS.Core.Global.ApplicationUser.User
        Private _iShiftID As Integer = PSS.Core.Global.ApplicationUser.IDShift
        Private _strWorkDate As String = PSS.Core.Global.ApplicationUser.Workdate
        Private _objCoolPad As PSS.Data.Buisness.CP.CoolPad
        Private _objCoolPad_Receiving As PSS.Data.Buisness.CP.CoolPad_Receiving
        Private _RecvCoolPadDT As DataTable
        Private _objCoolpad_SP As PSS.Data.Buisness.CP.CoolPad_SpecialProject
        Private _iRecID As Integer = 0
        Private _iUserID As Integer = PSS.Core.Global.ApplicationUser.IDuser
        Private _strUser As String = PSS.Core.Global.ApplicationUser.User

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal iCust_ID As Integer, ByVal iLoc_ID As Integer, ByVal strScreenName As String)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._iMenuCustID = iCust_ID
            Me._iMenuLocID = iLoc_ID
            Me._strScreenName = strScreenName

            Me._objCoolPad = New PSS.Data.Buisness.CP.CoolPad()
            Me._objCoolPad_Receiving = New PSS.Data.Buisness.CP.CoolPad_Receiving()
            Me._objCoolpad_SP = New PSS.Data.Buisness.CP.CoolPad_SpecialProject()
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                Try
                    Me._objCoolPad = Nothing
                    Me._objCoolPad_Receiving = Nothing
                    Me._objCoolpad_SP = Nothing
                Catch ex As Exception
                End Try
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
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            '
            'frmCoolPadSpecialReceiving
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(920, 670)
            Me.Name = "frmCoolPadSpecialReceiving"
            Me.Text = "frmCoolPadSpecialReceiving"

        End Sub

#End Region

    End Class
End Namespace
