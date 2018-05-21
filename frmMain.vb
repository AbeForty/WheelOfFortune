Public Class frmMain
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Computer.Audio.Play(My.Resources.wof_theme, AudioPlayMode.BackgroundLoop)
        'If My.Settings.productKey = "" OrElse My.Settings.computerName = "" Then
        '    frmActivation.Show()
        '    Me.Close()
        'End If

        If My.Settings.firstRun = True Then
            frmHelp.ShowDialog()
            My.Settings.firstRun = False
        Else

        End If
    End Sub

    Private Sub btnPlay_Click(sender As Object, e As EventArgs) Handles btnPlay.Click
        'My.Computer.Audio.Play(My.Resources.Ding, AudioPlayMode.Background)
        frmNewGame.Show()
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        'My.Computer.Audio.Play(My.Resources.Ding, AudioPlayMode.Background)
        frmContestantManager.Show()
        Me.Hide()
    End Sub

    Private Sub btnCustomize_Click(sender As Object, e As EventArgs) Handles btnCustomize.Click
        'My.Computer.Audio.Play(My.Resources.Ding, AudioPlayMode.Background)
        frmCustomizer.Show()
        Me.Hide()
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        'My.Computer.Audio.Play(My.Resources.Ding, AudioPlayMode.Background)
        frmHelp.ShowDialog()
    End Sub
    Private Sub frmMain_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Me.Visible = False Then
            My.Computer.Audio.Stop()
        Else
            My.Computer.Audio.Play(My.Resources.wof_theme, AudioPlayMode.BackgroundLoop)
        End If
    End Sub
End Class
