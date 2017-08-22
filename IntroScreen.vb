﻿Public Class IntroScreen
    Private Sub IntroScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AxWindowsMediaPlayer1.URL = Application.StartupPath & "\Resources" & "\WheelIntroSeason34.mp4"
        AxWindowsMediaPlayer1.uiMode = "none"
        Timer1.Start()
        AxWindowsMediaPlayer1.settings.volume = 100
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsStopped Then
            frmPuzzleBoard.Show()
            frmPuzzleBoard.previewMode = False
            Me.Close()
        End If
    End Sub
End Class