Public Class frmPuzzleBoard
    Private Sub frmPuzzleBoard_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        For Each letterController As Control In Controls(WheelController.puzzleBoardName).Controls
            If letterController.GetType() Is GetType(PuzzleBoardLetter) Then
                CType(letterController, PuzzleBoardLetter).Hide()
            End If
        Next
        'MsgBox(pboxTossUp.Parent.Name)
        If WheelController.previewMode = False Then
            If WheelController.currentLoadGame = True Then
                WheelController.loadLettersFromPuzzleString()
                WheelController.wheelLoad(WheelController.round)
                frmScore.tmrCheckVowels.Start()
            Else
                WheelController.resetPlayers()
                WheelController.resetPuzzle()
                WheelController.previewPlay = False
                'btnRedRingIn.Show()
                'btnYellowRingIn.Show()
                'btnBlueRingIn.Show()
                WheelController.loadTossUp()
                If WheelController.season >= 18 Then
                    WheelController.wheelLoad(WheelController.PuzzleType.TU1)
                    WheelController.round = WheelController.PuzzleType.TU1
                    frmScore.usedLetterBoard.Enabled = False
                    wheelTilt.Enabled = False
                Else
                    WheelController.wheelLoad(WheelController.PuzzleType.R1)
                    WheelController.round = WheelController.PuzzleType.R1
                    WheelController.currentPlayer = 1
                End If
            End If
            If WheelController.numberOfPlayers = 2 Then
                btnBlueRingIn.Hide()
                WheelController.player3RingIn = True
            ElseIf WheelController.numberOfPlayers = 1 Then
                frmScore.lblNumberOfTurns.Show()
                tmrCheckTurns.Start()
                btnYellowRingIn.Hide()
                WheelController.player2RingIn = True
                btnBlueRingIn.Hide()
                WheelController.player3RingIn = True
            End If
            If WheelController.round <> WheelController.PuzzleType.BR Then
                frmScore.Show()
                If WheelController.currentLoadGame = False Then
                    WheelController.loadPuzzle(WheelController.round, WheelController.puzzleMode, False)
                End If
                'My.Computer.Audio.Play(My.Resources.puzzle_reveal, AudioPlayMode.Background)
                CategoryStrip1.lblCategory.Text = WheelController.category
            Else
                CategoryStrip1.lblCategory.Text = ""
            End If
        Else
            WheelController.wheelLoad(frmCustomizer.currentRound)
            WheelController.round = frmCustomizer.currentRound
            If WheelController.round <> WheelController.PuzzleType.BR Then
                WheelController.loadPuzzle(frmCustomizer.currentRound, WheelController.puzzleMode, True)
                'My.Computer.Audio.Play(My.Resources.puzzle_reveal, AudioPlayMode.Background)
                CategoryStrip1.lblCategory.Text = WheelController.category
            Else
                frmScore.lblControllerSpinResult.Hide()
                frmScore.lblCurrentValue.Hide()
                WheelController.loadPuzzle(WheelController.PuzzleType.BR, WheelController.puzzleMode, True)
                WheelController.bonusRoundPlayer = WheelController.Player1List
                'My.Computer.Audio.Play(My.Resources.puzzle_reveal, AudioPlayMode.Background)
                CategoryStrip1.lblCategory.Text = WheelController.category
                WheelController.revealBonusRound()
            End If
            If WheelController.previewPlay = False Then
                WheelController.solvePuzzle(True)
            Else
                frmScore.Show()
                WheelController.currentPlayer = 1
                WheelController.currentPlayerObject = WheelController.Player1List
                WheelController.wheelLoad(frmCustomizer.currentRound)
                frmScore.tmrCheckVowels.Start()
            End If
        End If
        WheelController.currentLoadGame = False
    End Sub
    Private Sub frmPuzzleBoard_FormClosing(sender As Object, e As EventArgs) Handles MyBase.FormClosing
        My.Computer.Audio.Stop()
        If WheelController.previewMode = False Then
            If WheelController.pauseMenuLoaded = False Then
                Application.Exit()
            End If
        Else
        End If
    End Sub

    Private Sub PuzzleBoard1_Click(sender As Object, e As EventArgs) Handles PuzzleBoard1.Click
        WheelController.revealBonusRound()
    End Sub
    'Private Sub PuzzleBoard2_Click(sender As Object, e As EventArgs) Handles PuzzleBoard2.Click
    '    WheelController.revealBonusRound()
    'End Sub

    Private Sub SpinToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SpinToolStripMenuItem.Click
        WheelSpinControl1.Spin()
    End Sub

    Private Sub ConfirmSpinToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConfirmSpinToolStripMenuItem.Click
        WheelSpinControl1.stopSpin()
    End Sub
    Private Sub mysteryReveal_Click(sender As Object, e As EventArgs) Handles mysteryReveal.Click
        mysteryReveal.Hide()
    End Sub

    Private Sub noMoreVowels_Click(sender As Object, e As EventArgs) Handles noMoreVowels.Click
        noMoreVowels.Hide()
    End Sub

    Private Sub BonusRoundSolveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BonusRoundSolveToolStripMenuItem.Click
        For Each lettersControls As Control In Controls(WheelController.puzzleBoardName).Controls
            If lettersControls.GetType() Is GetType(PuzzleBoardLetter) Then
                CType(lettersControls, PuzzleBoardLetter).revealLetter()
            End If
        Next
        My.Computer.Audio.Play(My.Resources.music_bonus_win_vamp_intro, AudioPlayMode.Background)
    End Sub

    Private Sub SolveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SolveToolStripMenuItem.Click
        If WheelController.previewMode = False Then
            WheelController.solvePuzzle(False)
        Else
            WheelController.solvePuzzle(True)
        End If
    End Sub
    Private Sub btnWild_Click(sender As Object, e As EventArgs) Handles btnWild.Click
        WheelController.wildUsed = True
        WheelController.spun = True
        btnWild.Hide()
        For Each myPlayer As Player In WheelController.Player1List
            myPlayer.addCardsOrWedges(Player.Wedges.Wild, False)
        Next
        For Each myPlayer As Player In WheelController.Player2List
            myPlayer.addCardsOrWedges(Player.Wedges.Wild, False)
        Next
        For Each myPlayer As Player In WheelController.Player3List
            myPlayer.addCardsOrWedges(Player.Wedges.Wild, False)
        Next
    End Sub

    Private Sub btnSolve_Click(sender As Object, e As EventArgs) Handles btnSolve.Click
        If WheelController.previewMode = False Then
            WheelController.solvePuzzle(False)
        Else
            WheelController.solvePuzzle(True)
        End If
    End Sub

    Private Sub BonusRoundRevealToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BonusRoundRevealToolStripMenuItem.Click
        If WheelController.round = WheelController.PuzzleType.BR Then
            revealBonus()
        Else
        End If
    End Sub
    Public Sub revealBonus()
        My.Computer.Audio.Play(My.Resources.puzzle_reveal, AudioPlayMode.Background)
        WheelController.loadPuzzle(WheelController.PuzzleType.BR, WheelController.puzzleMode, False)
        CategoryStrip1.Show()
        CategoryStrip1.lblCategory.Text = WheelController.category
        If WheelController.virtualHost = True Then
            If WheelController.puzzleMode = WheelController.wheelMode.Classic Or WheelController.puzzleMode = WheelController.wheelMode.Disney Or WheelController.puzzleMode = WheelController.wheelMode.Random Then
                Dim SAPI
                SAPI = CreateObject("SAPI.spvoice")
                SAPI.Speak("The category you chose for the bonus round is..." + WheelController.category)
            Else
                Dim SAPI
                SAPI = CreateObject("SAPI.spvoice")
                SAPI.Speak("The category for the bonus round is..." + WheelController.category)
            End If
        End If
    End Sub

    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        WheelController.Player1List.Clear()
        WheelController.bonusRoundPlayer = Nothing
        WheelController.currentPlayer = Nothing
        WheelController.currentPlayerObject = Nothing
        frmScore.tmrCheckVowels.Stop()
        WheelController.checkVowelRunning = False
        frmCustomizer.Show()
        frmScore.Close()
        Me.Close()
    End Sub

    Private Sub wheelTilt_Click(sender As Object, e As EventArgs) Handles wheelTilt.Click
        WheelController.turnTaken = True
        btnSolve.Enabled = False
        WheelSpinControl1.Show()
    End Sub
    Private Sub btnLoseATurn_Click(sender As Object, e As EventArgs)
        WheelController.LoseATurn()
    End Sub
    Public timeStart As Integer

    Private Sub tmrTossUp_Tick(sender As Object, e As EventArgs) Handles tmrTossUp.Tick
        For my2i As Integer = 1 To WheelController.tossUpLetterControlList.Count
            If DateTime.Now.Second = WheelController.convertTime(timeStart) Then
                Dim randomNumber = WheelController.GetRandom()
                CType(Controls(WheelController.puzzleBoardName).Controls("PuzzleBoardLetter" & WheelController.tossUpLetterControlList(randomNumber)), PuzzleBoardLetter).revealLetter()
                ListBox4.Items.Add(randomNumber & CType(Controls(WheelController.puzzleBoardName).Controls("PuzzleBoardLetter" & WheelController.tossUpLetterControlList(randomNumber)), PuzzleBoardLetter).letterBehind)
                WheelController.tossUpLetterControlList.Remove(WheelController.tossUpLetterControlList(randomNumber))
                timeStart = DateTime.Now.Second
                WheelController.solveTypedList.Remove(randomNumber)
            End If
        Next
        If WheelController.round <> WheelController.PuzzleType.BR Then
            If WheelController.tossUpLetterControlList.Count = 0 Or WheelController.allRungIn = True Then
                tmrTossUp.Stop()
                My.Computer.Audio.Play(My.Resources.double_buzz, AudioPlayMode.Background)
                WheelController.solveAttempt = WheelController.puzzle
            End If
        End If
    End Sub
    Private Sub tmrTossUpReveal_Tick(sender As Object, e As EventArgs) Handles tmrTossUpReveal.Tick
        CategoryStrip1.Show()
        If DateTime.Now.Second = WheelController.convertTimeTossUpReveal(WheelController.tossUpRevealTimeStart) Then
            pboxTossUp.Hide()
            tmrTossUpReveal.Stop()
        End If
    End Sub
    Public bonusTimeStart As Integer
    Private Sub tmrBonus_Tick(sender As Object, e As EventArgs) Handles tmrBonus.Tick
        If DateTime.Now.Second = WheelController.convertTime(bonusTimeStart + 9) Then
            WheelController.bonusSolved = False
            WheelController.solvePuzzle(False)
            'frmScore.BonusCardEnvelope1.Show()
            'frmScore.timeStart = DateTime.Now.Second
            'frmScore.tmrSolveFailed.Start()
            tmrBonus.Stop()
        End If
    End Sub

    Private Sub tmrTossUpRingIn_Tick(sender As Object, e As EventArgs) Handles tmrTossUpRingIn.Tick
        WheelController.checkRingIn()
    End Sub

    Private Sub btnRedRingIn_Click(sender As Object, e As EventArgs) Handles btnRedRingIn.Click
        If WheelController.player1RingIn = True Then
            If Not WheelController.numberOfPlayers = 1 Then
                If WheelController.typeToSolve = True Then
                    If WheelController.previewMode = False Then
                        WheelController.solvePuzzle(False)
                    Else
                        WheelController.solvePuzzle(True)
                    End If
                Else
                    WheelController.cancelSolve()
                End If
            Else
                WheelController.allRungIn = True
                For Each lettersControls As Control In Controls(WheelController.puzzleBoardName).Controls
                    If lettersControls.GetType() Is GetType(PuzzleBoardLetter) Then
                        CType(lettersControls, PuzzleBoardLetter).revealLetter()
                    End If
                Next
                WheelController.currentPlayer = Nothing
                WheelController.currentPlayerObject = Nothing
                My.Computer.Audio.Play(My.Resources.double_buzz, AudioPlayMode.Background)
            End If
        ElseIf WheelController.player1RingIn = False Then
            My.Computer.Audio.Play(My.Resources.Ding, AudioPlayMode.Background)
            If WheelController.virtualHost = True Then
                Dim SAPI
                SAPI = CreateObject("SAPI.spvoice")
                SAPI.Speak(frmScore.NameTag1.lblName.Text)
            End If
            WheelController.player1RingIn = True
            WheelController.currentPlayer = 1
            WheelController.currentPlayerObject = WheelController.Player1List
            btnYellowRingIn.Enabled = False
            btnBlueRingIn.Enabled = False
            tmrTossUpRingIn.Stop()
            tmrTossUp.Stop()
            If WheelController.typeToSolve = True Then
                If WheelController.previewMode = False Then
                    WheelController.solvePuzzle(False)
                Else
                    WheelController.solvePuzzle(True)
                End If
            End If
        End If
    End Sub

    Private Sub btnYellowRingIn_Click(sender As Object, e As EventArgs) Handles btnYellowRingIn.Click
        If WheelController.player2RingIn = True Then
            If WheelController.typeToSolve = True Then
                If WheelController.previewMode = False Then
                    WheelController.solvePuzzle(False)
                Else
                    WheelController.solvePuzzle(True)
                End If
            Else
                WheelController.cancelSolve()
            End If
        ElseIf WheelController.player2RingIn = False Then
            My.Computer.Audio.Play(My.Resources.Ding, AudioPlayMode.Background)
            If WheelController.virtualHost = True Then
                Dim SAPI
                SAPI = CreateObject("SAPI.spvoice")
                SAPI.Speak(frmScore.NameTag2.lblName.Text)
            End If
            WheelController.player2RingIn = True
            WheelController.currentPlayer = 2
            WheelController.currentPlayerObject = WheelController.Player2List
            btnRedRingIn.Enabled = False
            btnBlueRingIn.Enabled = False
            tmrTossUpRingIn.Stop()
            tmrTossUp.Stop()
            If WheelController.typeToSolve = True Then
                If WheelController.previewMode = False Then
                    WheelController.solvePuzzle(False)
                Else
                    WheelController.solvePuzzle(True)
                End If
            End If
        End If
    End Sub

    Private Sub btnBlueRingIn_Click(sender As Object, e As EventArgs) Handles btnBlueRingIn.Click
        If WheelController.player3RingIn = True Then
            If WheelController.typeToSolve = True Then
                If WheelController.previewMode = False Then
                    WheelController.solvePuzzle(False)
                Else
                    WheelController.solvePuzzle(True)
                End If
            Else
                WheelController.cancelSolve()
            End If
        ElseIf WheelController.player3RingIn = False Then
            WheelController.player3RingIn = True
            My.Computer.Audio.Play(My.Resources.Ding, AudioPlayMode.Background)
            If WheelController.virtualHost = True Then
                Dim SAPI
                SAPI = CreateObject("SAPI.spvoice")
                SAPI.Speak(frmScore.NameTag3.lblName.Text)
            End If
            WheelController.currentPlayer = 3
            WheelController.currentPlayerObject = WheelController.Player3List
            btnYellowRingIn.Enabled = False
            btnRedRingIn.Enabled = False
            tmrTossUpRingIn.Stop()
            tmrTossUp.Stop()
            If WheelController.typeToSolve = True Then
                If WheelController.previewMode = False Then
                    WheelController.solvePuzzle(False)
                Else
                    WheelController.solvePuzzle(True)
                End If
            End If
        End If
    End Sub

    Private Sub pboxTossUp_Click(sender As Object, e As EventArgs) Handles pboxTossUp.Click
        pboxTossUp.Hide()
    End Sub

    Private Sub tmrCheckFinalSpin_Tick(sender As Object, e As EventArgs) Handles tmrCheckFinalSpin.Tick
        If WheelController.round <> WheelController.PuzzleType.BR Then
            'DateTime.Now.Minute = WheelController.convertTime(WheelController.startTime + 14)
            If DateTime.Now.Minute = (WheelController.convertTimeToSeconds(WheelController.startTime + WheelController.timeLeft)) And WheelController.letterControlTappedList.Count = 0 And WheelController.round <> WheelController.PuzzleType.TU1 And WheelController.round <> WheelController.PuzzleType.TU2 And WheelController.round <> WheelController.PuzzleType.TU3 And WheelController.round <> WheelController.PuzzleType.R1 And WheelController.round <> WheelController.PuzzleType.R2 And WheelController.round <> WheelController.PuzzleType.R3 Then
                If WheelController.puzzleSolved = False And WheelController.solveMode = False And WheelController.turnTaken = False And WheelController.noMoreConsonantsShown = False Then
                    frmFinalSpin.Show()
                    WheelController.previousValue = ""
                    WheelController.finalSpin = True
                    frmScore.usedLetterBoard.Enabled = False
                    tmrCheckFinalSpin.Stop()
                    If WheelController.virtualHost = True Then
                        Dim SAPI
                        SAPI = CreateObject("SAPI.spvoice")
                        SAPI.Speak("That sound means time is running short.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                    End If
                Else
                    WheelController.finalSpinQueued = True
                End If
            ElseIf WheelController.finalSpinQueued = True And WheelController.letterControlTappedList.Count = 0 And WheelController.puzzleSolved = False And WheelController.solveMode = False And WheelController.turnTaken = False Then
                frmFinalSpin.Show()
                WheelController.finalSpin = True
                WheelController.previousValue = ""
                frmScore.usedLetterBoard.Enabled = False
                tmrCheckFinalSpin.Stop()
                If WheelController.virtualHost = True Then
                    Dim SAPI
                    SAPI = CreateObject("SAPI.spvoice")
                    SAPI.Speak("That sound means time is running short.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                End If
            End If
            ElseIf WheelController.round = WheelController.PuzzleType.BR Then
            tmrCheckFinalSpin.Stop()
        End If
    End Sub

    Private Sub tmrCheckTurns_Tick(sender As Object, e As EventArgs) Handles tmrCheckTurns.Tick
        frmScore.lblNumberOfTurns.Text = WheelController.numberOfTurns
        If WheelController.numberOfTurns = 0 Then
            tmrCheckTurns.Stop()
            'My.Computer.Audio.Play(My.Resources.bankrupt, AudioPlayMode.WaitToComplete)
            WheelController.solvePuzzle(False)
        End If
    End Sub

    Private Sub frmPuzzleBoard_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If (e.KeyChar.ToString = ChrW(Keys.Back)) Then
            If WheelController.typeToSolve = True Then
                If WheelController.previousSolveLetter <> 0 Then
                    WheelController.backspaceLetter()
                    'CType(PuzzleBoard1.Controls("PuzzleBoardLetter" & WheelController.currentSolveLetter), PuzzleBoardLetter).btnLetter.BackColor = Color.White
                    ''WheelController.currentSolveLetter = WheelController.previousSolveLetter
                    ''WheelController.currentSolveLetter = WheelController.solveTypedList(WheelController.currentSolveIndex - 1)
                    'CType(PuzzleBoard1.Controls("PuzzleBoardLetter" & WheelController.currentSolveLetter), PuzzleBoardLetter).btnLetter.BackgroundImage = Nothing
                    'CType(PuzzleBoard1.Controls("PuzzleBoardLetter" & WheelController.currentSolveLetter), PuzzleBoardLetter).btnLetter.BackColor = SystemColors.HotTrack
                End If
            End If
        ElseIf ((e.KeyChar.ToString <> ChrW(Keys.Space)) And Char.IsLetter(e.KeyChar.ToString)) Then
            If frmScore.usedLetterBoard.Controls("btn" & e.KeyChar.ToString).Enabled = True Or (WheelController.puzzle.Contains(e.KeyChar.ToString) And frmScore.usedLetterBoard.Controls("btn" & e.KeyChar.ToString).Enabled = False) Then
                WheelController.backspace = False
                WheelController.loadLetters(frmScore.usedLetterBoard.Controls("btn" & e.KeyChar.ToString))
            End If
        ElseIf e.KeyChar = ChrW(Keys.Space) And Not wheelcontroller.revealed = True And WheelController.round <> WheelController.PuzzleType.TU1 And WheelController.round <> WheelController.PuzzleType.TU2 And WheelController.round <> WheelController.PuzzleType.TU3 And WheelController.round <> WheelController.PuzzleType.TBTU Then
            WheelController.backspace = False
            WheelController.turnTaken = True
            btnSolve.Enabled = False
            WheelSpinControl1.Show()
        End If
        'If e.KeyChar = ChrW(Keys.A) Then
        '    WheelController.loadLetters(frmScore.btnA)
        'ElseIf e.KeyChar = ChrW(Keys.B) Then
        '    WheelController.loadLetters(frmScore.btnB)
        'ElseIf e.KeyChar = ChrW(Keys.C) Then
        '    WheelController.loadLetters(frmScore.btnC)
        'End If
    End Sub

    Private Sub btnSolvePass_Click(sender As Object, e As EventArgs) Handles btnSolvePass.Click
        WheelController.cancelSolve()
    End Sub
End Class