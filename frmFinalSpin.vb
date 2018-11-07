Public Class frmFinalSpin
    Private Sub frmFinalSpin_Load(sender As Object, e As EventArgs) Handles Me.Load
        wmpFinalSpin.URL = Application.StartupPath & "\Resources\FinalSpinCut.mp4"
        My.Computer.Audio.Play(My.Resources.finalspin, AudioPlayMode.Background)
    End Sub
    Private Sub frmFinalSpin_FormClosing(sender As Object, e As EventArgs) Handles Me.FormClosing
        frmPuzzleBoard.WheelSpinControl1.Show()
    End Sub

    Private Sub wmpFinalSpin_PlayStateChange(sender As Object, e As AxWMPLib._WMPOCXEvents_PlayStateChangeEvent) Handles wmpFinalSpin.PlayStateChange
        If wmpFinalSpin.playState = WMPLib.WMPPlayState.wmppsStopped Then
            Me.Close()
        End If
    End Sub
End Class