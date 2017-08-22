Public Class frmAudio
    Private Sub frmAudio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Computer.Audio.Play(My.Resources.R_S_T_L_N_E, AudioPlayMode.Background)
    End Sub
End Class