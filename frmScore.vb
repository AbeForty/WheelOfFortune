Public Class frmScore

    Private Sub frmScore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If WheelController.Player1List.Count > 0 Then
            NameTag1.contestantName = WheelController.Player1List(0).contestantName
            NameTag1.Show()
        Else
            NameTag1.Hide()
        End If
        If WheelController.Player2List.Count > 0 Then
            NameTag2.contestantName = WheelController.Player2List(0).contestantName
            NameTag2.Show()
        Else
            NameTag2.Hide()
        End If
        If WheelController.Player3List.Count > 0 Then
            NameTag3.contestantName = WheelController.Player3List(0).contestantName
            NameTag3.Show()
        Else
            NameTag3.Hide()
        End If
        tmrCheckPlayer.Start()
    End Sub
    Private Sub frmScore_FormClosing(sender As Object, e As EventArgs) Handles MyBase.FormClosing
        If WheelController.previewMode = False Then
            If WheelController.pauseMenuLoaded = False Then
                Application.Exit()
            End If
        Else
        End If
    End Sub
    Private Sub frmScore_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If (e.KeyChar.ToString = ChrW(Keys.Back)) Then
            If WheelController.typeToSolve = True Then
                If WheelController.previousSolveLetter <> 0 Then
                    WheelController.backspace = True
                    WheelController.backspaceLetter()
                    'CType(frmPuzzleBoard.PuzzleBoard1.Controls("PuzzleBoardLetter" & WheelController.currentSolveLetter), PuzzleBoardLetter).btnLetter.BackColor = Color.White
                    'WheelController.currentSolveLetter = WheelController.previousSolveLetter
                    ''WheelController.currentSolveLetter = WheelController.solveTypedList(WheelController.currentSolveIndex - 1)
                    'CType(frmPuzzleBoard.PuzzleBoard1.Controls("PuzzleBoardLetter" & WheelController.currentSolveLetter), PuzzleBoardLetter).btnLetter.BackgroundImage = Nothing
                    'CType(frmPuzzleBoard.PuzzleBoard1.Controls("PuzzleBoardLetter" & WheelController.currentSolveLetter), PuzzleBoardLetter).btnLetter.BackColor = SystemColors.HotTrack
                End If
            End If
        ElseIf ((e.KeyChar <> ChrW(Keys.Space)) And Char.IsLetter(e.KeyChar.ToString))  Then
            WheelController.backspace = False
            If usedLetterBoard.Controls("btn" & e.KeyChar.ToString).Enabled = True Or (WheelController.puzzle.Contains(e.KeyChar.ToString) And usedLetterBoard.Controls("btn" & e.KeyChar.ToString).Enabled = False) Then
                WheelController.loadLetters(usedLetterBoard.Controls("btn" & e.KeyChar.ToString))
            End If
        ElseIf e.KeyChar = ChrW(Keys.Space) And Not wheelcontroller.revealed = True And WheelController.round <> WheelController.PuzzleType.TU1 And WheelController.round <> WheelController.PuzzleType.TU2 And WheelController.round <> WheelController.PuzzleType.TU3 And WheelController.round <> WheelController.PuzzleType.TBTU Then
            WheelController.backspace = False
            WheelController.turnTaken = True
            frmPuzzleBoard.btnSolve.Enabled = False
            frmPuzzleBoard.WheelSpinControl1.Show()
        End If
    End Sub

    Private Sub quitBTN_Click(sender As Object, e As EventArgs) Handles quitBTN.Click
        Application.Exit()
    End Sub
    Private Sub btnLetter_EnabledChanged(sender As Object, e As EventArgs) Handles btnA.EnabledChanged, btnB.EnabledChanged, btnC.EnabledChanged, btnD.EnabledChanged, btnE.EnabledChanged, btnF.EnabledChanged, btnG.EnabledChanged, btnH.EnabledChanged, btnI.EnabledChanged, btnJ.EnabledChanged, btnK.EnabledChanged, btnL.EnabledChanged, btnM.EnabledChanged, btnN.EnabledChanged, btnO.EnabledChanged, btnP.EnabledChanged, btnQ.EnabledChanged, btnR.EnabledChanged, btnS.EnabledChanged, btnT.EnabledChanged, btnU.EnabledChanged, btnV.EnabledChanged, btnW.EnabledChanged, btnX.EnabledChanged, btnY.EnabledChanged, btnZ.EnabledChanged
        If CType(sender, Button).Enabled = True And Not WheelController.selectedBonusLetters.Contains(CType(sender, Button).Text.Replace("btn", "")) Then
            CType(sender, Button).FlatStyle = FlatStyle.Flat
        ElseIf CType(sender, Button).Enabled = False Or WheelController.selectedBonusLetters.Contains(CType(sender, Button).Text.Replace("btn", "")) Then
            CType(sender, Button).FlatStyle = FlatStyle.System
        End If
    End Sub
    Private Sub btnLetter_Click(sender As Object, e As EventArgs) Handles btnA.Click, btnB.Click, btnC.Click, btnD.Click, btnE.Click, btnF.Click, btnG.Click, btnH.Click, btnI.Click, btnJ.Click, btnK.Click, btnL.Click, btnM.Click, btnN.Click, btnO.Click, btnP.Click, btnQ.Click, btnR.Click, btnS.Click, btnT.Click, btnU.Click, btnV.Click, btnW.Click, btnX.Click, btnY.Click, btnZ.Click
        WheelController.loadLetters(CType(sender, Button))
    End Sub
    Private Sub tmrCheckPlayer_Tick(sender As Object, e As EventArgs) Handles tmrCheckPlayer.Tick
        WheelController.checkPlayer()
    End Sub
    Public Sub bonusTimer()
        WheelController.previousValue = "Lose A Turn"
        'My.Computer.Audio.Play(My.Resources.clock_new, AudioPlayMode.Background)
        wmpBonus.URL = Application.StartupPath & "\Resources\clock_new.wav"
        frmPuzzleBoard.tmrBonus.Start()
        For Each control In Controls
            If TypeOf (control) Is PuzzleBoardLetter Then
                If CType(control, PuzzleBoardLetter).btnLetter.Text = "" Then
                    WheelController.letterControlList.Add(CType(control, PuzzleBoardLetter).Name.Replace("PuzzleBoardLetter", ""))
                End If
            End If
        Next
    End Sub

    Private Sub btnBonusTimerStart_Click(sender As Object, e As EventArgs) Handles btnBonusTimerStart.Click
        wmpBonus.URL = Application.StartupPath & "\Resources\clock_new.wav"
        If WheelController.virtualHost = True Then
            Dim SAPI
            SAPI = CreateObject("SAPI.spvoice")
            SAPI.Speak("You have 10 seconds. Good luck.")
        End If
        usedLetterBoard.Enabled = True
        frmPuzzleBoard.btnSolve.Enabled = True
        frmPuzzleBoard.bonusTimeStart = DateTime.Now.Second
        bonusTimer()
        CType(sender, Button).Hide()
        'tmrBonusTimer.Start()
    End Sub
    Private Sub tmrBonusTimer_Tick(sender As Object, e As EventArgs) Handles tmrBonusTimer.Tick
        If DateTime.Now.Second = WheelController.convertTime(WheelController.timeStart + 9) Then
            tmrBonusTimer.Stop()
            WheelController.timeStart = DateTime.Now.Second
            'tmrSolveFailed.Start()
        End If
    End Sub
    Private Sub tmrLetterReveal_Tick(sender As Object, e As EventArgs) Handles tmrLetterReveal.Tick
        WheelController.revealLetters()
    End Sub
    Private Sub tmrFinalSpin_Tick(sender As Object, e As EventArgs) Handles tmrFinalSpin.Tick
        If DateTime.Now.Second = WheelController.convertTime(WheelController.timeStart + 3) And WheelController.finalSpin = True And WheelController.solveMode = False Then
            tmrFinalSpin.Stop()
            WheelController.LoseATurn()
            WheelController.previousValue = ""
            WheelController.finalSpinTimesUp = True
            My.Computer.Audio.Play(My.Resources.Buzzer, AudioPlayMode.Background)
            usedLetterBoard.Enabled = True
            WheelController.numberOfTurns += 1
        End If
    End Sub
    'Private Sub tmrSolveFailed_Tick(sender As Object, e As EventArgs) Handles tmrSolveFailed.Tick
    '    For my2i As Integer = 1 To letterControlList.Count
    '        If DateTime.Now.Second = convertTime(timeStart) Then
    '            Dim randomNumber = GetRandomRegular()
    '            CType(frmPuzzleBoard.PuzzleBoard1.Controls("PuzzleBoardLetter" & letterControlList(randomNumber)), PuzzleBoardLetter).revealLetter()
    '            frmPuzzleBoard.ListBox4.Items.Add(randomNumber & CType(frmPuzzleBoard.PuzzleBoard1.Controls("PuzzleBoardLetter" & letterControlList(randomNumber)), PuzzleBoardLetter).letterBehind)
    '            letterControlList.Remove(letterControlList(randomNumber))
    '            timeStart = DateTime.Now.Second
    '        End If
    '    Next
    '    If letterControlList.Count = 0 Then
    '        tmrSolveFailed.Stop()
    '        BonusCardEnvelope1.Show()
    '    End If
    'End Sub

    Private Sub tmrCheckVowels_Tick(sender As Object, e As EventArgs) Handles tmrCheckVowels.Tick
        WheelController.checkVowels()
    End Sub

    Private Sub btnLoseATurn_Click(sender As Object, e As EventArgs) Handles btnLoseATurn.Click
        WheelController.isNoLetters = True
        WheelController.LoseATurn()
    End Sub

    Private Sub lblPlayer3_DoubleClick(sender As Object, e As EventArgs) Handles lblPlayer3.DoubleClick
        If lblPlayer1Total.Visible = False Then
            lblPlayer1Total.Show()
            lblPlayer2Total.Show()
            lblPlayer3Total.Show()
        Else
            lblPlayer1Total.Hide()
            lblPlayer2Total.Hide()
            lblPlayer3Total.Hide()
        End If
    End Sub

    Private Sub lblplayer2_DoubleClick(sender As Object, e As EventArgs) Handles lblPlayer2.DoubleClick
        If lblPlayer1Total.Visible = False Then
            lblPlayer1Total.Show()
            lblPlayer2Total.Show()
            lblPlayer3Total.Show()
        Else
            lblPlayer1Total.Hide()
            lblPlayer2Total.Hide()
            lblPlayer3Total.Hide()
        End If
    End Sub

    Private Sub lblplayer1_DoubleClick(sender As Object, e As EventArgs) Handles lblPlayer1.DoubleClick
        If lblPlayer1Total.Visible = False Then
            lblPlayer1Total.Show()
            lblPlayer2Total.Show()
            lblPlayer3Total.Show()
        Else
            lblPlayer1Total.Hide()
            lblPlayer2Total.Hide()
            lblPlayer3Total.Hide()
        End If
    End Sub

    Private Sub lblPlayer1_TextChanged(sender As Object, e As EventArgs) Handles lblPlayer1.TextChanged
        If lblPlayer1.Text <> "" Then
            For Each myPlayer As Player In WheelController.Player1List
                myPlayer.currentScore = CInt(lblPlayer1.Text.Replace("$", ""))
            Next
        Else
            For Each myPlayer As Player In WheelController.Player1List
                myPlayer.currentScore = 0
            Next
        End If
    End Sub
    Private Sub lblPlayer2_TextChanged(sender As Object, e As EventArgs) Handles lblPlayer2.TextChanged
        If lblPlayer2.Text <> "" Then
            For Each myPlayer As Player In WheelController.Player2List
                myPlayer.currentScore = CInt(lblPlayer2.Text.Replace("$", ""))
            Next
        Else
            For Each myPlayer As Player In WheelController.Player2List
                myPlayer.currentScore = 0
            Next
        End If
    End Sub
    Private Sub lblPlayer3_TextChanged(sender As Object, e As EventArgs) Handles lblPlayer3.TextChanged
        If lblPlayer3.Text <> "" Then
            For Each myPlayer As Player In WheelController.Player3List
                myPlayer.currentScore = CInt(lblPlayer3.Text.Replace("$", ""))
            Next
        Else
            For Each myPlayer As Player In WheelController.Player3List
                myPlayer.currentScore = 0
            Next
        End If
    End Sub
    Private Sub lblPlayer1Total_TextChanged(sender As Object, e As EventArgs) Handles lblPlayer1Total.TextChanged
        If lblPlayer1Total.Text <> "" Then
            For Each myPlayer As Player In WheelController.Player1List
                myPlayer.total = CInt(lblPlayer1Total.Text.Replace("$", ""))
            Next
        Else
            For Each myPlayer As Player In WheelController.Player1List
                myPlayer.total = 0
            Next
        End If
    End Sub
    Private Sub lblPlayer2Total_TextChanged(sender As Object, e As EventArgs) Handles lblPlayer2Total.TextChanged
        If lblPlayer2Total.Text <> "" Then
            For Each myPlayer As Player In WheelController.Player2List
                myPlayer.total = CInt(lblPlayer2Total.Text.Replace("$", ""))
            Next
        Else
            For Each myPlayer As Player In WheelController.Player2List
                myPlayer.total = 0
            Next
        End If
    End Sub
    Private Sub lblPlayer3Total_TextChanged(sender As Object, e As EventArgs) Handles lblPlayer3Total.TextChanged
        If lblPlayer3Total.Text <> "" Then
            For Each myPlayer As Player In WheelController.Player3List
                myPlayer.total = CInt(lblPlayer3Total.Text.Replace("$", ""))
            Next
        Else
            For Each myPlayer As Player In WheelController.Player3List
                myPlayer.total = 0
            Next
        End If
    End Sub

    Private Sub lstDownArrow_Click(sender As Object, e As EventArgs) Handles lstDownArrow.Click
        If lstMessages.Visible = False Then
            lstMessages.Show()
        ElseIf lstMessages.Visible = True Then
            lstMessages.Hide()
        End If
    End Sub

    Private Sub notifyBar_TextChanged(sender As Object, e As EventArgs) Handles notifyBar.TextChanged
        lstMessages.Items.Add(notifyBar.Text)
    End Sub

    Private Sub notifyBar_Click(sender As Object, e As EventArgs) Handles notifyBar.Click
        If lstMessages.Visible = False Then
            lstMessages.Show()
        ElseIf lstMessages.Visible = True Then
            lstMessages.Hide()
        End If
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        WheelController.timeLeft = (WheelController.timeLeft - (DateTime.Now.Minute - WheelController.startTime))
        frmPuzzleBoard.tmrCheckFinalSpin.Stop()
        frmHelp.ShowDialog()
    End Sub

    Private Sub btnPause_Click(sender As Object, e As EventArgs) Handles btnPause.Click
        WheelController.timeLeft = (WheelController.timeLeft - (DateTime.Now.Minute - WheelController.startTime))
        frmPuzzleBoard.tmrCheckFinalSpin.Stop()
        dlgPauseMenu.ShowDialog()
    End Sub

    Private Sub lblPlayerTotal_TextChanged(sender As Object, e As EventArgs) Handles lblPlayer1Total.TextChanged, lblPlayer2Total.TextChanged, lblPlayer3Total.TextChanged
        If CType(sender, Label).Text = "$0" Then
            CType(sender, Label).Text = ""
        End If
    End Sub

    'Public flashTimeStart As Integer
    'Private Sub tmrCurrentPlayerFlash_Tick(sender As Object, e As EventArgs) Handles tmrCurrentPlayerFlash.Tick
    'frmPuzzleBoard.lblWMPTime.Text = DateTime.Now.Second & "," & letterControlList.Count
    '    '& "," & timeStart - 1
    '    If DateTime.Now.Second = convertTime(flashTimeStart + 2) Then
    '        If currentPlayer = 1 Then
    '            If player1LeftArrow.Visible = True Then
    '                player1LeftArrow.Hide()
    '                player1RightArrow.Hide()
    '            ElseIf player1LeftArrow.Visible = False Then
    '                player1LeftArrow.Show()
    '                player1RightArrow.Show()
    '            End If
    '        ElseIf currentPlayer = 2 Then
    '            If player2LeftArrow.Visible = True Then
    '                player2LeftArrow.Hide()
    '                player2RightArrow.Hide()
    '            ElseIf player2LeftArrow.Visible = False Then
    '                player2LeftArrow.Show()
    '                player2RightArrow.Show()
    '            End If
    '        ElseIf currentPlayer = 3 Then
    '            If player3LeftArrow.Visible = True Then
    '                player3LeftArrow.Hide()
    '                player3RightArrow.Hide()
    '            ElseIf player3LeftArrow.Visible = False Then
    '                player3LeftArrow.Show()
    '                player3RightArrow.Show()
    '            End If
    '        End If
    '        timeStart = DateTime.Now.Second
    '        'stopWatchtimer.Restart()
    '        'Next
    '    End If
    'End Sub
End Class
