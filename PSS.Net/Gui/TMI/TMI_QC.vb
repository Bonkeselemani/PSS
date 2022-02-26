Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui
    Public Class TMI_QC
        Inherits System.Windows.Forms.Form

        Public _strScreenName As String = ""
        Public _iMenuCust As Integer = 0
        Public _iSelectedQCTypeID As Integer

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strScreenName As String, ByVal iCustID As Integer, ByVal iQCTypeID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _strScreenName = strScreenName
            _iMenuCust = iCustID
            _iSelectedQCTypeID = iQCTypeID
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
            components = New System.ComponentModel.Container()
            Me.Text = "TMI_QC"
        End Sub

#End Region

    End Class
End Namespace