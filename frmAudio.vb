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
            wheelWMP.Ctlcontrols.play()
        Else
            wheelWMP.Ctlcontrols.stop()
        End If
    End Sub
End Class