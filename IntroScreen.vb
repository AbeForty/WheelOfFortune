Public Class IntroScreen
    Private Sub IntroScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        introWMP.URL = Application.StartupPath & "\Resources" & "\WheelIntroSeason35.mp4"
        introWMP.uiMode = "none"
        Timer1.Start()
        introWMP.settings.volume = 100
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If introWMP.playState = WMPLib.WMPPlayState.wmppsStopped Then
            frmPuzzleBoard.Show()
            WheelController.previewMode = False
            Me.Close()
        End If
    End Sub
End Class