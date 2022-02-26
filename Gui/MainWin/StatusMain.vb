Imports System.Windows.Forms

Namespace Gui.MainWin

    Public Class StatusBar
        Inherits System.Windows.Forms.StatusBar

        Protected Shared pnlInfo As New StatusBarPanel()

        Public Sub New()
            MyBase.New()

            InitializeComponent()

        End Sub

        Public Sub InitializeComponent()
            Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Dock = DockStyle.Bottom
            Me.ShowPanels = True
            pnlInfo.AutoSize = StatusBarPanelAutoSize.Spring
            Me.Panels.Add(pnlInfo)

            SetStatusText("Ready")
        End Sub

        Public Shared Function SetStatusText(ByVal Value As String)
            pnlInfo.Text = " " & Value
        End Function



    End Class

End Namespace
