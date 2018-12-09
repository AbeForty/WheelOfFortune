Imports System.Data.SqlClient
Public Class frmLoadGame
    Dim numOfPlayers As Integer
    Private Sub getPreviousGames()
        Try
            Dim connPuzzle As SqlConnection
            connPuzzle = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\WheelPuzzles.mdf;Integrated Security=True")
            Dim strSQL As String
            strSQL = "SELECT * FROM Games WHERE Final = 0"
            Dim cmd As SqlCommand
            Dim rdr As SqlDataReader
            connPuzzle.Open()
            cmd = New SqlCommand(strSQL, connPuzzle)
            cmd.CommandType = CommandType.Text
            rdr = cmd.ExecuteReader()
            If rdr.HasRows() Then
            Else
                MsgBox("You don't have any unfinished saved games.", vbInformation, "WHEEL OF FORTUNE")
                frmNewGame.Show()
                Me.Close()
                Exit Sub
            End If
            Do While rdr.Read()
                cboGame.Items.Add(Trim(rdr("Id")).ToString & "|" & Trim(rdr("PackName")).ToString & "|" & Trim(rdr("created_at")).ToString)
            Loop
            connPuzzle.Close()
        Catch ex As Exception
            MsgBox("Saved Games failed to load.", vbCritical, "WHEEL OF FORTUNE")
            frmNewGame.Show()
            Me.Close()
        End Try
    End Sub
    Private Sub dlgSelectPack_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pnlLoadGame.Top = (Me.ClientSize.Height / 2) - (pnlLoadGame.Height / 2)
        pnlLoadGame.Left = (Me.ClientSize.Width / 2) - (pnlLoadGame.Width / 2)
        getPreviousGames()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        frmNewGame.Show()
        Me.Close()
    End Sub
    Private Sub btnResumeGame_Click(sender As Object, e As EventArgs) Handles btnResumeGame.Click
        If cboGame.SelectedItem <> Nothing Then
            Dim gameInfo = cboGame.SelectedItem.ToString.Split("|")
            WheelController.gameID = gameInfo(0)
            Dim connClues As SqlConnection
            connClues = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\WheelPuzzles.mdf;Integrated Security=True")
            Dim strSQL As String = "SELECT * FROM GamePlayer, Contestant WHERE Game_ID = @GameID and GamePlayer.Contestant_ID = Contestant.Id"
            Dim rdr As SqlDataReader
            Dim cmd As SqlCommand
            connClues.Open()
            cmd = New SqlCommand(strSQL, connClues)
            Dim gameIDParam As SqlParameter = New SqlParameter("@GameID", gameInfo(0))
            cmd.Parameters.Add(gameIDParam)
            cmd.CommandType = CommandType.Text
            rdr = cmd.ExecuteReader()
            Do While rdr.Read()
                Dim myNewPlayer As Player = New Player(rdr("Contestant_ID"), rdr("PlayerNumber"), Trim(rdr("Name")), rdr("RoundWinnings"), rdr("Total"))
                If rdr("PlayerNumber") = 1 Then
                    WheelController.Player1List.Add(myNewPlayer)
                    If myNewPlayer.currentScore <> 0 Then
                        frmScore.lblPlayer1.Text = FormatCurrency(myNewPlayer.currentScore, 0, , TriState.False)
                    End If
                    If myNewPlayer.total <> 0 Then
                        frmScore.lblPlayer1Total.Text = FormatCurrency(myNewPlayer.total, 0, , TriState.False)
                    Else
                        frmScore.lblPlayer1Total.Text = FormatCurrency(0, 0, , TriState.False)
                    End If
                ElseIf rdr("PlayerNumber") = 2 Then
                    WheelController.Player2List.Add(myNewPlayer)
                    If myNewPlayer.currentScore <> 0 Then
                        frmScore.lblPlayer2.Text = FormatCurrency(myNewPlayer.currentScore, 0, , TriState.False)
                    End If
                    If myNewPlayer.total <> 0 Then
                        frmScore.lblPlayer2Total.Text = FormatCurrency(myNewPlayer.total, 0, , TriState.False)
                    Else
                        frmScore.lblPlayer2Total.Text = FormatCurrency(0, 0, , TriState.False)
                    End If
                ElseIf rdr("PlayerNumber") = 3 Then
                    WheelController.Player3List.Add(myNewPlayer)
                    If myNewPlayer.currentScore <> 0 Then
                        frmScore.lblPlayer3.Text = FormatCurrency(myNewPlayer.currentScore, 0, , TriState.False)
                    End If
                    If myNewPlayer.total <> 0 Then
                        frmScore.lblPlayer3Total.Text = FormatCurrency(myNewPlayer.total, 0, , TriState.False)
                    Else
                        frmScore.lblPlayer3Total.Text = FormatCurrency(0, 0, , TriState.False)
                    End If
                End If
            Loop
            connClues.Close()
            Dim strRoundSQL As String = "SELECT * FROM Games WHERE [Games].Id = @GameID"
            Dim roundrdr As SqlDataReader
            Dim cmdRound As SqlCommand
            connClues.Open()
            cmdRound = New SqlCommand(strRoundSQL, connClues)
            Dim gameID3Param As SqlParameter = New SqlParameter("@GameID", gameInfo(0))
            cmdRound.Parameters.Add(gameID3Param)
            cmdRound.CommandType = CommandType.Text
            roundrdr = cmdRound.ExecuteReader()
            Dim puzzleID As Integer = Nothing
            Do While roundrdr.Read()
                If roundrdr("VirtualHost") = 0 Then
                    WheelController.virtualHost = False
                ElseIf roundrdr("VirtualHost") = 1 Then
                    WheelController.virtualHost = True
                End If
                If roundrdr("TypeToSolve") = 0 Then
                    WheelController.typeToSolve = False
                ElseIf roundrdr("TypeToSolve") = 1 Then
                    WheelController.typeToSolve = True
                End If
                WheelController.timeLeft = roundrdr("finalSpinTime")
                puzzleID = roundrdr("PuzzleID")
                WheelController.currentPlayer = roundrdr("CurrentPlayer")
                WheelController.puzzleString = roundrdr("PuzzleString")
                WheelController.round = CType([Enum].Parse(GetType(WheelController.PuzzleType), roundrdr("Round")), WheelController.PuzzleType)
            Loop
            connClues.Close()
            WheelController.packName = gameInfo(1)
            WheelController.quickGame = False
            WheelController.loadGame = True
            WheelController.currentLoadGame = True
            If gameInfo(1) = "TODAY'S WHEEL EPISODE" Then
                WheelController.puzzleMode = WheelController.wheelMode.Daily
                frmDailyPuzzleTest.Show()
                Exit Sub
            ElseIf gameInfo(1).Contains("DISNEY") Then
                WheelController.puzzleMode = WheelController.wheelMode.Disney
            End If
            frmMain.Close()
                IntroScreen.Show()
                Me.Close()
            Else
                MsgBox("No game selected. Please select a game.", vbExclamation, "WHEEL OF FORTUNE")
        End If
    End Sub

    Private Sub frmLoadGame_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
    End Sub
End Class