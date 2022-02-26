Imports System
Imports System.Windows.Forms

Imports Crownwood.Magic.Menus
Imports Crownwood.Magic.Controls.TabControl

Namespace Gui.MainWin

    Public Class WorkArea
        Inherits Crownwood.Magic.Controls.TabControl

        Protected mnuContext As New PopupMenu()

        Public Sub New()
            MyBase.New()

            InitializeComponent()
        End Sub

        Private Sub InitializeComponent()
            Me.ShrinkPagesToFit = True
            Me.IDEPixelBorder = True
            Me.Dock = DockStyle.Fill
            Me.Appearance = VisualAppearance.MultiForm
            Me.ContextPopupMenu = mnuContext

            mnuContext.MenuCommands.Add(New MenuCommand("Close", New EventHandler(AddressOf WorkArea_ClosePressed)))
        End Sub

        Private Sub WorkArea_ClosePressed(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.ClosePressed
            If Me.TabPages.Count > 0 Then
                Try
                    Dim page As Crownwood.Magic.Controls.TabPage = Me.TabPages.Item(Me.TabIndex)
                    Me.TabPages.RemoveAt(Me.SelectedIndex)
                Catch
                End Try
            End If
        End Sub
    End Class

End Namespace
