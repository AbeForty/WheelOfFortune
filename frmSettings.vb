Public Class frmSettings
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'My.Computer.Audio.Play(My.Resources.puzzle_reveal, AudioPlayMode.Background)
        txtPlayer1.Text = WheelController.player1Name
        NameTag1.contestantName = WheelController.player1Name
        txtPlayer2.Text = WheelController.player2Name
        NameTag2.contestantName = WheelController.player2Name
        txtPlayer3.Text = WheelController.player3Name
        NameTag3.contestantName = WheelController.player3Name
    End Sub

    Private Sub txtPlayer1_TextChanged(sender As Object, e As EventArgs) Handles txtPlayer1.TextChanged
        NameTag1.contestantName = txtPlayer1.Text.ToUpper
        WheelController.player1Name = txtPlayer1.Text.ToUpper
    End Sub

    Private Sub txtPlayer2_TextChanged(sender As Object, e As EventArgs) Handles txtPlayer2.TextChanged
        NameTag2.contestantName = txtPlayer2.Text.ToUpper
        WheelController.player2Name = txtPlayer2.Text.ToUpper
    End Sub

    Private Sub txtPlayer3_TextChanged(sender As Object, e As EventArgs) Handles txtPlayer3.TextChanged
        NameTag3.contestantName = txtPlayer3.Text.ToUpper
        WheelController.player3Name = txtPlayer3.Text.ToUpper
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        My.Computer.Audio.Play(My.Resources.Ding, AudioPlayMode.Background)
        Me.Close()
    End Sub

    Private Sub chkTeams_CheckedChanged(sender As Object, e As EventArgs) Handles chkTeams.CheckedChanged
        If chkTeams.Checked = True Then
            WheelController.teams = True
        Else
            WheelController.teams = False
        End If
    End Sub

    Private Sub numPlayers_ValueChanged(sender As Object, e As EventArgs) Handles numPlayers.ValueChanged
        WheelController.numberOfPlayers = numPlayers.Value
    End Sub
End Class
