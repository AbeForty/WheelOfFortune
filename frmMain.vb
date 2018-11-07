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
        If My.Settings.animationOn = True Then
            pboxWheelAnim.Show()
        Else
            pboxWheelAnim.Hide()
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

    Private Sub pboxWheelAnim_DoubleClick(sender As Object, e As EventArgs) Handles pboxWheelAnim.DoubleClick
        CType(sender, PictureBox).Hide()
        My.Settings.animationOn = False
    End Sub

    Private Sub frmMain_DoubleClick(sender As Object, e As EventArgs) Handles Me.DoubleClick
        pboxWheelAnim.Show()
        My.Settings.animationOn = True
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        My.Computer.Audio.Stop()
    End Sub
End Class
