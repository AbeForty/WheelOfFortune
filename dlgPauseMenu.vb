Public Class dlgPauseMenu
    Private Sub dlgPauseMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BringToFront()
        WheelController.pauseMenuLoaded = True
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        frmHelp.ShowDialog()
    End Sub

    Private Sub btnResume_Click(sender As Object, e As EventArgs) Handles btnResume.Click
        WheelController.startTime = DateTime.Now.Minute
        frmPuzzleBoard.tmrCheckFinalSpin.Start()
        WheelController.pauseMenuLoaded = False
        Close()
    End Sub

    Private Sub btnMain_Click(sender As Object, e As EventArgs) Handles btnMain.Click
        Application.Restart()
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        frmNewGame.ShowDialog()
    End Sub
End Class