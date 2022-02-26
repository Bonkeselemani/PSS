Option Explicit On 
Imports PDF417Lib
Imports PSS.Data.Buisness
Imports System.Text

Namespace Gui.CP
    Public Class frmCoolPad_SPecialBuildBox
        Inherits System.Windows.Forms.Form

        Private _iMenuCustID As Integer = 0
        Private _iMenuLocID As Integer = 0
        Private _strScreenName As String = ""
        Private _strUserName As String = PSS.Core.Global.ApplicationUser.User
        Private _iShiftID As Integer = PSS.Core.Global.ApplicationUser.IDShift
        Private _strWorkDate As String = PSS.Core.Global.ApplicationUser.Workdate
        Private _objCoolPad_BoxShip As PSS.Data.Buisness.CP.CoolPad_BoxShip
        Private _objCoolPad As PSS.Data.Buisness.CP.CoolPad
        Private _objCoolPad_SP As PSS.Data.Buisness.CP.CoolPad_SpecialProject
        Private _iPallett_ID As Integer = 0
        Private _strCountryCode As String = ""

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal iCust_ID As Integer, ByVal iLoc_ID As Integer, ByVal strScreenName As String)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call

            Me._iMenuCustID = iCust_ID
            Me._iMenuLocID = iLoc_ID
            Me._strScreenName = strScreenName
            Me._objCoolPad_BoxShip = New PSS.Data.Buisness.CP.CoolPad_BoxShip()
            Me._objCoolPad = New PSS.Data.Buisness.CP.CoolPad()
            Me._objCoolPad_SP = New PSS.Data.Buisness.CP.CoolPad_SpecialProject()

        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                Try
                    Me._objCoolPad = Nothing
                    Me._objCoolPad_SP = Nothing
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
            'frmCoolPad_SPecialBuildBox
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(704, 534)
            Me.Name = "frmCoolPad_SPecialBuildBox"
            Me.Text = "frmCoolPad_SPecialBuildBox"

        End Sub

#End Region

    End Class
End Namespace