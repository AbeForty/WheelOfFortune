Imports System.ComponentModel
Imports System.Data.SqlClient
Public Class frmNewGame
    Dim numOfPlayers = 0
    Dim loadGame As Boolean = False
    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getPackNames()
        If WheelController.packName <> "" Then
            cboPack.SelectedItem = WheelController.packName
            btnStartGame.Enabled = False
            btnQuickStart.Enabled = False
            lblSettings.Text = "MODIFY GAME"
        Else
            btnStartGame.Enabled = True
            btnQuickStart.Enabled = True
            lblSettings.Text = "NEW GAME"
        End If
        pboxWheelBoard.Parent = pboxSet
        'My.Computer.Audio.Play(My.Resources.puzzle_reveal, AudioPlayMode.Background)
        txtPlayer1.Text = WheelController.player1Name
        NameTag1.contestantName = WheelController.player1Name
        NameTag1.contestantID = WheelController.player1.ContestantID
        txtPlayer2.Text = WheelController.player2Name
        NameTag2.contestantName = WheelController.player2Name
        NameTag2.contestantID = WheelController.player2.ContestantID
        txtPlayer3.Text = WheelController.player3Name
        NameTag3.contestantName = WheelController.player3Name
        NameTag3.contestantID = WheelController.player3.ContestantID
        For i As Integer = 1 To 3
            If CType(pnlNewGame.Controls("NameTag" & i), NameTag).contestantID <> Nothing Then
                numOfPlayers += 1
            End If
        Next
        Try
            numPlayers.Value = numOfPlayers
        Catch ex As Exception
        End Try
        dlgPauseMenu.Hide()
        frmScore.Hide()
        Me.BringToFront()
        If WheelController.virtualHost = True Then
            chkVirtualHost.Checked = True
        Else
            chkVirtualHost.Checked = False
        End If
        If WheelController.teams = True Then
            chkTeams.Checked = True
        Else
            chkTeams.Checked = False
        End If
        If WheelController.typeToSolve = True Then
            chkTypeToSolve.Checked = True
        Else
            chkTypeToSolve.Checked = False
        End If
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

    Private Sub btnStartGame_Click(sender As Object, e As EventArgs) Handles btnStartGame.Click
        createGame()
        startGame()
    End Sub

    Private Sub btnQuickStart_Click(sender As Object, e As EventArgs) Handles btnQuickStart.Click
        startGame()
    End Sub

    Private Sub chkTeams_CheckedChanged(sender As Object, e As EventArgs) Handles chkTeams.CheckedChanged
        If CType(sender, CheckBox).Checked = True Then
            WheelController.teams = True
        Else
            WheelController.teams = False
        End If
    End Sub

    Private Sub numPlayers_ValueChanged(sender As Object, e As EventArgs) Handles numPlayers.ValueChanged
        WheelController.numberOfPlayers = numPlayers.Value
    End Sub

    Private Sub cboPuzzleBoardStyle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPuzzleBoardStyle.SelectedIndexChanged
        If cboPuzzleBoardStyle.SelectedItem.ToString = "Modern" Then
            WheelController.boardStyleEnum = WheelController.boardStyle.Modern
            WheelController.puzzleBoardName = "PuzzleBoard1"
        ElseIf cboPuzzleBoardStyle.SelectedItem.ToString = "Classic" Then
            WheelController.boardStyleEnum = WheelController.boardStyle.Classic
            WheelController.puzzleBoardName = "PuzzleBoard2"
        End If
    End Sub

    Private Sub frmSettings_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If frmPuzzleBoard.Visible = False And loadGame = False Then
            frmMain.Show()
        ElseIf frmPuzzleBoard.Visible = True Then
            dlgPauseMenu.Show()
            frmScore.Show()
        End If
    End Sub

    Private Sub chkVirtualHost_CheckedChanged(sender As Object, e As EventArgs) Handles chkVirtualHost.CheckedChanged
        If CType(sender, CheckBox).Checked = True Then
            WheelController.virtualHost = True
        Else
            WheelController.virtualHost = False
        End If
    End Sub

    Private Sub chkTypeToSolve_CheckedChanged(sender As Object, e As EventArgs) Handles chkTypeToSolve.CheckedChanged
        If CType(sender, CheckBox).Checked = True Then
            WheelController.typeToSolve = True
        Else
            WheelController.typeToSolve = False
        End If
    End Sub
    Private Sub getPackNames()
        Try
            Dim connPuzzle As SqlConnection
            connPuzzle = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" & Application.StartupPath & "\WheelPuzzles.mdf;Integrated Security=True")
            Dim strSQL As String
            strSQL = "SELECT * FROM PUZZLE"
            Dim cmd As SqlCommand
            Dim rdr As SqlDataReader
            connPuzzle.Open()
            cmd = New SqlCommand(strSQL, connPuzzle)
            cmd.CommandType = CommandType.Text
            rdr = cmd.ExecuteReader()
            Do While rdr.Read()
                If Not cboPack.Items.Contains(Trim(rdr("PackName").ToString)) Then
                    cboPack.Items.Add(Trim(rdr("PackName")).ToString)
                Else
                End If
            Loop
            connPuzzle.Close()
            'cboPack.Items.Add("RANDOM")
            cboPack.Items.Add("TODAY'S WHEEL EPISODE")
            cboPack.Items.Add("FLASHBACK")
        Catch ex As Exception
            MsgBox("An error occurred while loading pack names.", vbCritical, "WHEEL OF FORTUNE")
        End Try
    End Sub
    Private Sub startGame()
        numOfPlayers = 0
        For i As Integer = 1 To 3
            If CType(pnlNewGame.Controls("NameTag" & i), NameTag).contestantID <> Nothing Then
                numOfPlayers += 1
            End If
        Next
        Try
            numPlayers.Value = numOfPlayers
        Catch ex As Exception
            MsgBox("Please select at least one player.", vbCritical, "WHEEL OF FORTUNE")
            Exit Sub
        End Try
        Try
            loadGame = True
            For i As Integer = 1 To numOfPlayers
                If i = 1 Then
                    WheelController.player1.ContestantID = CType(pnlNewGame.Controls("NameTag" & i), NameTag).contestantID
                    WheelController.player1Name = CType(pnlNewGame.Controls("NameTag" & i), NameTag).contestantName
                ElseIf i = 2 Then
                    WheelController.player2.ContestantID = CType(pnlNewGame.Controls("NameTag" & i), NameTag).contestantID
                    WheelController.player2Name = CType(pnlNewGame.Controls("NameTag" & i), NameTag).contestantName
                ElseIf i = 3 Then
                    WheelController.player3.ContestantID = CType(pnlNewGame.Controls("NameTag" & i), NameTag).contestantID
                    WheelController.player3Name = CType(pnlNewGame.Controls("NameTag" & i), NameTag).contestantName
                End If
            Next
            If cboPack.SelectedItem <> Nothing And cboPack.SelectedItem <> "TODAY'S WHEEL EPISODE" And cboPack.SelectedItem <> "FLASHBACK" And cboPack.SelectedItem.ToString.Contains("DISNEY WHEEL OF FORTUNE") = False And cboPack.SelectedItem <> "RANDOM" Then
                'Me.DialogResult = System.Windows.Forms.DialogResult.OK
                WheelController.packName = cboPack.SelectedItem.ToString
                WheelController.puzzleMode = WheelController.wheelMode.Classic
                WheelController.season = 36
                My.Computer.Audio.Stop()
                frmMain.Close()
                IntroScreen.Show()
                Me.Close()
            ElseIf cboPack.SelectedItem.ToString.Contains("DISNEY WHEEL OF FORTUNE") Then
                'Me.DialogResult = System.Windows.Forms.DialogResult.OK
                WheelController.puzzleMode = WheelController.wheelMode.Disney
                WheelController.packName = cboPack.SelectedItem.ToString
                WheelController.season = 36
                My.Computer.Audio.Stop()
                frmMain.Close()
                IntroScreen.Show()
                Me.Close()
            ElseIf cboPack.SelectedItem = "RANDOM" Then
                'Me.DialogResult = System.Windows.Forms.DialogResult.OK
                WheelController.puzzleMode = WheelController.wheelMode.Random
                WheelController.packName = cboPack.SelectedItem.ToString
                WheelController.season = 36
                My.Computer.Audio.Stop()
                frmMain.Close()
                IntroScreen.Show()
                Me.Close()
                'MsgBox("Random mode not implemented yet.", vbExclamation, "Wheel of Fortune")
            ElseIf cboPack.SelectedItem = "TODAY'S WHEEL EPISODE" Then
                If My.Computer.Network.IsAvailable = True Then
                    WheelController.packName = cboPack.SelectedItem.ToString
                    WheelController.puzzleMode = WheelController.wheelMode.Daily
                    WheelController.season = 36
                    'Dim gotPuzzles = False
                    'Do Until gotPuzzles = True
                    frmDailyPuzzleTest.Show()
                    'WheelController.getDailyPuzzles()
                    'Loop
                Else
                    MsgBox("This feature requires an active internet connection. Please try again.", vbExclamation, "Wheel of Fortune")
                End If
            ElseIf cboPack.SelectedItem = "FLASHBACK" Then
                WheelController.packName = cboPack.SelectedItem.ToString
                WheelController.puzzleMode = WheelController.wheelMode.Compendium
                My.Computer.Audio.Stop()
                frmMain.Close()
                IntroScreen.Show()
                Me.Close()
            Else
                MsgBox("Please select a pack before clicking OK.", vbExclamation, "Wheel of Fortune")
            End If
        Catch ex As Exception
            MsgBox("An error occurred while creating your quick game.", vbCritical, "WHEEL OF FORTUNE")
            Exit Sub
        End Try
    End Sub
    Private Sub createGame()
        Try
            If cboPack.SelectedItem = Nothing Then
                MsgBox("Please select a pack.", vbCritical, "Wheel of Fortune")
                Exit Sub
            End If
            Dim connPuzzle As SqlConnection
            connPuzzle = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" & Application.StartupPath & "\WheelPuzzles.mdf;Integrated Security=True")
            Dim strSQL As String
            strSQL = "INSERT INTO GAMES output INSERTED.ID VALUES (@PackName, @VirtualHost, @TypeToSolve, @RoundNumber, @Puzzle, @Teams, @created_at)"
            Dim cmd As SqlCommand
            Dim puzzleParam As SqlParameter = New SqlParameter("@Puzzle", "")
            Dim virtualHostParam As SqlParameter
            If chkVirtualHost.Checked = False Then
                virtualHostParam = New SqlParameter("@VirtualHost", 0)
            Else
                virtualHostParam = New SqlParameter("@VirtualHost", 1)
            End If
            Dim typeToSolveParam As SqlParameter
            If chkTypeToSolve.Checked = False Then
                typeToSolveParam = New SqlParameter("@TypeToSolve", 0)
            Else
                typeToSolveParam = New SqlParameter("@TypeToSolve", 1)
            End If
            Dim teamsParam As SqlParameter
            If chkTeams.Checked = False Then
                teamsParam = New SqlParameter("@Teams", 0)
            Else
                teamsParam = New SqlParameter("@Teams", 1)
            End If
            Dim roundNumberParam As SqlParameter = New SqlParameter("@RoundNumber", "TU1")
            Dim packNameParam As SqlParameter = New SqlParameter("@PackName", cboPack.SelectedItem.ToString)
            Dim createdAtParam As SqlParameter = New SqlParameter("@created_at", DateTime.Now)
            connPuzzle.Open()
            cmd = New SqlCommand(strSQL, connPuzzle)
            cmd.Parameters.Add(packNameParam)
            cmd.Parameters.Add(virtualHostParam)
            cmd.Parameters.Add(typeToSolveParam)
            cmd.Parameters.Add(roundNumberParam)
            cmd.Parameters.Add(teamsParam)
            cmd.Parameters.Add(puzzleParam)
            cmd.Parameters.Add(createdAtParam)
            cmd.CommandType = CommandType.Text
            Dim gameID = Integer.Parse(cmd.ExecuteScalar())
            WheelController.gameID = gameID
            connPuzzle.Close()
            For i As Integer = 1 To 3
                If CType(pnlNewGame.Controls("NameTag" & i), NameTag).contestantID <> Nothing Then
                    numOfPlayers += 1
                End If
            Next
            Try
                numPlayers.Value = numOfPlayers
            Catch ex As Exception
                MsgBox("Please select at least one player.", vbCritical, "WHEEL OF FORTUNE")
                Exit Sub
            End Try
            For i As Integer = 1 To numOfPlayers
                Dim strNewSQL As String
                strNewSQL = "INSERT INTO GamePlayer VALUES (@Contestant_ID, @Game_ID, @total, @RoundWinnings)"
                Dim contestantcmd As SqlCommand
                Dim contestantIDParam As SqlParameter = New SqlParameter("@Contestant_ID", CType(pnlNewGame.Controls("NameTag" & i), NameTag).contestantID)
                Dim gameIDParam As SqlParameter = New SqlParameter("@Game_ID", gameID)
                Dim totalParam As SqlParameter = New SqlParameter("@total", 0)
                Dim roundWinningsParam As SqlParameter = New SqlParameter("@RoundWinnings", 0)
                connPuzzle.Open()
                contestantcmd = New SqlCommand(strNewSQL, connPuzzle)
                contestantcmd.Parameters.Add(contestantIDParam)
                contestantcmd.Parameters.Add(gameIDParam)
                contestantcmd.Parameters.Add(totalParam)
                contestantcmd.Parameters.Add(roundWinningsParam)
                contestantcmd.CommandType = CommandType.Text
                contestantcmd.ExecuteNonQuery()
                connPuzzle.Close()
            Next
        Catch ex As Exception
            MsgBox("An error occurred while creating your game save. Starting game without saving.", vbCritical, "WHEEL OF FORTUNE")
            startGame()
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub NameTag_Click(sender As Object, e As EventArgs) Handles NameTag1.Click, NameTag2.Click, NameTag3.Click

    End Sub

    Private Sub cboPack_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboPack.SelectedValueChanged
        If cboPack.SelectedItem = "FLASHBACK" Then
            If My.Computer.Network.IsAvailable = True Then
                WheelController.packName = cboPack.SelectedItem.ToString
                WheelController.puzzleMode = WheelController.wheelMode.Compendium
                'Dim gotPuzzles = False
                'Do Until gotPuzzles = True
                frmCompendium.Show()
                'WheelController.getDailyPuzzles()
                'Loop
            Else
                MsgBox("This feature requires an active internet connection. Please try again.", vbExclamation, "Wheel of Fortune")
            End If
        End If
    End Sub

    'Private Sub pboxWheelBoard_DoubleClick(sender As Object, e As EventArgs) Handles pboxWheelBoard.DoubleClick
    '    cboPack.Items.Add("RANDOM")
    '    cboPack.SelectedItem = "RANDOM"
    'End Sub
End Class
