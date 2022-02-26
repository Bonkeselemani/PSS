
Option Explicit On 

Imports PSS.Data.Buisness
Imports System.Text

Namespace Gui.VV
    Public Class frmVivint_BuildAQLOBA_Lot
        Inherits System.Windows.Forms.Form


        Private _iCust_ID As Integer = 0
        Private _strScreenName As String = ""
        Private _strRptName As String = ""
        Private _objVivint As PSS.Data.Buisness.VV.Vivint
        Private _objVivint_BuildLot As PSS.Data.Buisness.VV.Vivint_BuildAQLOBA_Lot
        Private _iPallett_ID As Integer = 0
        Private _iUserID As Integer = PSS.Core.Global.ApplicationUser.IDuser
        Private _strUser As String = PSS.Core.Global.ApplicationUser.User

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strScreenName As String, ByVal iCust_ID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._iCust_ID = iCust_ID
            Me._strScreenName = strScreenName
            Me._objVivint = New PSS.Data.Buisness.VV.Vivint()
            Me._objVivint_BuildLot = New PSS.Data.Buisness.VV.Vivint_BuildAQLOBA_Lot()

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
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            '
            'frmVivint_BuildAQLOBA_Lot
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(576, 590)
            Me.Name = "frmVivint_BuildAQLOBA_Lot"
            Me.Text = "frmVivint_BuildAQLOBA_Lot"

        End Sub

#End Region

    End Class
End Namespace