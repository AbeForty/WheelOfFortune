Public Class TeamDisplay
    Public Property enableClick As Boolean = True
    Public Property playerNumber As Integer
    Private Sub flpContestants_ControlRemoved(sender As Object, e As ControlEventArgs) Handles flpContestants.ControlRemoved
        If flpContestants.Controls.Count = 0 Then
            lblNoContestants.Show()
            frmNewGame.btnStartGame.Enabled = False
        End If
    End Sub

    Private Sub flpContestants_ControlAdded(sender As Object, e As ControlEventArgs) Handles flpContestants.ControlAdded
        lblNoContestants.Hide()
        frmNewGame.checkNumPlayers()
        'If JeopardyController.numberOfPlayers >= 3 Then
        '    frmNewGame.btnSaveGame.Enabled = True
        '    frmNewGame.btnQuickStart.Enabled = True
        'End If
    End Sub

    Private Sub lblAddToTeam_Click(sender As Object, e As EventArgs) Handles lblAddToTeam.Click
        If ParentForm Is frmNewGame Then
            If enableClick = True Then
                If ContestantControl.ShowDialog() = DialogResult.OK Then
                    'CType(CType(sender, Label).Parent, NameTag)
                    If WheelController.checkID(ContestantControl.contestantID) = False Then
                        'If chkDemo.Checked = False Then
                        '    ContestantControl.demo = False
                        'Else
                        '    ContestantControl.demo = True
                        'End If
                        Dim newContestantControl As New ContestantDisplay
                        newContestantControl.ContestantID = ContestantControl.contestantID
                        newContestantControl.ContestantName = ContestantControl.contestantName
                        newContestantControl.Total = ContestantControl.score
                        flpContestants.Controls.Add(newContestantControl)
                        Dim newPlayer As New Player(ContestantControl.contestantID, playerNumber, ContestantControl.contestantName)
                        Select Case playerNumber
                            Case 1
                                WheelController.Player1List.Add(newPlayer)
                            Case 2
                                WheelController.Player2List.Add(newPlayer)
                            Case 3
                                WheelController.Player3List.Add(newPlayer)
                        End Select
                        'frmNewGame.lblQuickGame.Hide()
                        frmNewGame.txtPlayer1.Hide()
                        frmNewGame.txtPlayer2.Hide()
                        frmNewGame.txtPlayer3.Hide()
                        WheelController.numberOfPlayersTotal += 1
                    Else
                        MsgBox("This contestant already exists on a team. Please choose another contestant.", vbCritical, "WHEEL OF FORTUNE")
                    End If
                    'ContestantID = ContestantControl.contestantID
                    'Text = ContestantControl.contestantName
                    'Dim numOfPlayers As Integer
                    'For i As Integer = 1 To 3
                    '    'If CType(frmNewGame.pnlNewGame.Controls("NameTag" & i), NameTag).contestantID <> Nothing Then
                    '    '    numOfPlayers += 1
                    '    'End If
                    'Next
                    'Try
                    '    'frmNewGame.numPlayers.Value = numOfPlayers
                    'Catch ex As Exception

                    'End Try
                End If
            End If
        End If
    End Sub

    Private Sub TeamDisplay_Load(sender As Object, e As EventArgs) Handles Me.Load
        If WheelController.teamDisplayInt < 3 Then
            WheelController.teamDisplayInt += 1
            playerNumber = WheelController.teamDisplayInt
            'playerNumber = convertDisplayInt(WheelController.teamDisplayInt)
        End If
        Select Case playerNumber
            Case 1
                BackColor = Color.FromArgb(204, 0, 0)
            Case 2
                BackColor = Color.Gold
            Case 3
                BackColor = Color.FromArgb(0, 45, 192)
        End Select
    End Sub
    Private Function convertDisplayInt(int As Integer)
        If int = 1 Then
            Return 3
        ElseIf int = 2 Then
            Return 2
        ElseIf int = 3 Then
            Return 1
        Else
            Return 0
        End If
    End Function
End Class
