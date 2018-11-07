Public Class frmAudio
    Private Sub frmAudio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub
    Public Sub playSpeedUp(value As Boolean)
        If value = True Then
            wheelWMP.URL = Application.StartupPath & "\Resources" & "\speedup_new.wav"
            wheelWMP.Ctlcontrols.play()
        Else
            wheelWMP.Ctlcontrols.stop()
        End If
    End Sub
    Public Sub playRSTLNE(value As Boolean)
        If value = True Then
            wheelWMP.URL = Application.StartupPath & "\Resources" & "\R S T L N E new.wav"
            My.Computer.Audio.Stop()
            wheelWMP.Ctlcontrols.play()
        Else
            wheelWMP.Ctlcontrols.stop()
        End If
    End Sub
    Public Sub playAudClap(value As Boolean)
        If value = True Then
            wheelWMP.URL = Application.StartupPath & "\Resources" & "\aud_clap" & WheelController.GetRandomPlayer(1, 6) & ".wav"
            wheelWMP.Ctlcontrols.play()
        Else
            wheelWMP.Ctlcontrols.stop()
        End If
    End Sub
    Public Sub playAudDisapp(value As Boolean)
        If value = True Then
            wheelWMP.URL = Application.StartupPath & "\Resources" & "\aud_disapp" & WheelController.GetRandomPlayer(1, 4) & ".wav"
            wheelWMP.Ctlcontrols.play()
        Else
            wheelWMP.Ctlcontrols.stop()
        End If
    End Sub
    Public Sub playAudCheer(value As Boolean)
        If value = True Then
            wheelWMP.URL = Application.StartupPath & "\Resources" & "\aud_cheer" & WheelController.GetRandomPlayer(1, 3) & ".wav"
            wheelWMP.Ctlcontrols.play()
        Else
            wheelWMP.Ctlcontrols.stop()
        End If
    End Sub
    Public Sub playExpress(value As Boolean)
        If value = True Then
            wheelWMP.URL = Application.StartupPath & "\Resources" & "\music_express.wav"
            wheelWMP.Ctlcontrols.play()
        Else
            wheelWMP.Ctlcontrols.stop()
        End If
    End Sub
End Class