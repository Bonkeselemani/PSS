Imports System.Timers

Namespace Core

    Public Class UpdateListner

        Private WithEvents checkup As Timer

        Public Sub New()
            checkup = New Timer(600000)

        End Sub

        Public Sub Run()
            checkup.Start()
        End Sub

        Private Sub checkup_Elapsed(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs) Handles checkup.Elapsed
            '// code for forcing an update should go here.
        End Sub
    End Class

End Namespace
