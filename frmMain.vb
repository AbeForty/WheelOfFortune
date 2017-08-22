Public Class frmMain
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.firstRun = True Then
            frmHelp.ShowDialog()
            My.Settings.firstRun = False
        Else

        End If
    End Sub

    Private Sub btnPlay_Click(sender As Object, e As EventArgs) Handles btnPlay.Click
        My.Computer.Audio.Play(My.Resources.Ding, AudioPlayMode.Background)
        dlgSelectPack.Show()
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        My.Computer.Audio.Play(My.Resources.Ding, AudioPlayMode.Background)
        frmSettings.Show()
    End Sub

    Private Sub btnCustomize_Click(sender As Object, e As EventArgs) Handles btnCustomize.Click
        My.Computer.Audio.Play(My.Resources.Ding, AudioPlayMode.Background)
        frmCustomizer.Show()
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        My.Computer.Audio.Play(My.Resources.Ding, AudioPlayMode.Background)
        frmHelp.ShowDialog()
    End Sub
End Class
