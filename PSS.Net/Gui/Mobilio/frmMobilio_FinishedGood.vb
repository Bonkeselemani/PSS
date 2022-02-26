Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui
    Public Class frmMobilio_FinishedGood
        Inherits System.Windows.Forms.Form

        Private _iMenuCustID As Integer = 0
        Private _objMFGoods As Mobilio_PutAway_FinishedGoods

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal iCustID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _iMenuCustID = iCustID
            _objMFGoods = New Mobilio_PutAway_FinishedGoods()
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
            'frmMobilio_ItemRec
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(292, 266)
            Me.Name = "frmMobilio_ItemRec"
            Me.Text = "frmMobilio_FinishedGood.vb"

        End Sub

#End Region

        '***********************************************************************************************************************************

    End Class
End Namespace