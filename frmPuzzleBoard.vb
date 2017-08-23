Public Class frmPuzzleBoard
    Dim bonusSolved As Boolean = True
    Public round As New WheelController.PuzzleType
    Dim revealed As Boolean = False
    Dim bonusRevealed As Boolean = False
    Dim bonusRSTLNERevealed As Boolean = False
    Public previewMode As Boolean = False
    Public lastProgressValue As Integer = -200
    Dim player1RingIn As Boolean = False
    Dim player2RingIn As Boolean = False
    Dim player3RingIn As Boolean = False
    Dim allRungIn As Boolean = False
    Private Sub frmPuzzleBoard_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        For Each letterController As Control In Controls
            If letterController.GetType() Is GetType(PuzzleBoardLetter) Then
                CType(letterController, PuzzleBoardLetter).Hide()
            End If
        Next
        frmScore.resetPuzzle()
        If previewMode = False Then
            btnRedRingIn.Show()
            btnYellowRingIn.Show()
            btnBlueRingIn.Show()
            loadTossUp()
            lblCategory.Parent = bkgCategory
            WheelController.wheelLoad(WheelController.PuzzleType.TU1)
            round = WheelController.PuzzleType.TU1
            If WheelController.numberOfPlayers = 2 Then
                btnBlueRingIn.Hide()
                player3RingIn = True
            ElseIf WheelController.numberOfPlayers = 1 Then
                frmScore.lblNumberOfTurns.Show()
                tmrCheckTurns.Start()
                btnYellowRingIn.Hide()
                player2RingIn = True
                btnBlueRingIn.Hide()
                player3RingIn = True
            End If
            If round <> WheelController.PuzzleType.BR Then
                WheelController.loadPuzzle(round, False)
                My.Computer.Audio.Play(My.Resources.puzzle_reveal, AudioPlayMode.Background)
                lblCategory.Text = WheelController.category
            Else
                lblCategory.Text = ""
            End If
            frmScore.Show()
            frmScore.usedLetterBoard.Enabled = False
            wheelTilt.Enabled = False
        Else
            lblCategory.Parent = bkgCategory
            WheelController.wheelLoad(WheelController.PuzzleType.R1)
            round = WheelController.PuzzleType.R1
            If round <> WheelController.PuzzleType.BR Then
                WheelController.loadPuzzle(frmCustomizer.currentRound, True)
                My.Computer.Audio.Play(My.Resources.puzzle_reveal, AudioPlayMode.Background)
                lblCategory.Text = WheelController.category
            Else
                lblCategory.Text = ""
            End If
            solvePuzzle(True)
        End If
    End Sub
    Private Sub frmPuzzleBoard_FormClosing(sender As Object, e As EventArgs) Handles MyBase.FormClosing
        If previewMode = False Then
            Application.Exit()
        Else
        End If
    End Sub
    Private Sub frmPuzzleBoard_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        If round = WheelController.PuzzleType.BR And bonusRevealed = False And bonusRSTLNERevealed = False Then
            revealBonus()
            bonusRevealed = True
        ElseIf round = WheelController.PuzzleType.BR And bonusRevealed = True And bonusRSTLNERevealed = False Then
            frmAudio.Show()
            WheelController.loadBonusRound()
            bonusRSTLNERevealed = True
            frmScore.usedLetterBoard.Enabled = True
            wheelTilt.Enabled = False
        Else
        End If
    End Sub

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
        For Each lettersControls As Control In Controls
            If lettersControls.GetType() Is GetType(PuzzleBoardLetter) Then
                CType(lettersControls, PuzzleBoardLetter).revealLetter()
            End If
        Next
        My.Computer.Audio.Play(My.Resources.music_bonus_win_vamp_intro, AudioPlayMode.Background)
    End Sub

    Private Sub SolveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SolveToolStripMenuItem.Click
        solvePuzzle(False)
    End Sub
    Private Sub loadTossUp()
        pboxTossUp.Show()
        If round = WheelController.PuzzleType.TU1 Then
            pboxTossUp.Image = My.Resources.Toss_Up_1000
        ElseIf round = WheelController.PuzzleType.TU2 Then
            pboxTossUp.Image = My.Resources.Toss_Up_2000
        ElseIf round = WheelController.PuzzleType.TU3 Then
            pboxTossUp.Image = My.Resources.Toss_Up_3000
        ElseIf round = WheelController.PuzzleType.TBTU Then
            pboxTossUp.Image = My.Resources.Toss_Up_1000
        End If
        tossUpRevealTimeStart = DateTime.Now.Second
        tmrTossUpReveal.Start()
    End Sub
    Private Sub btnWild_Click(sender As Object, e As EventArgs) Handles btnWild.Click
        frmScore.wildUsed = True
        frmScore.spun = True
        btnWild.Hide()
        frmScore.player1.addCardsOrWedges(Player.Wedges.Wild, False)
        frmScore.player2.addCardsOrWedges(Player.Wedges.Wild, False)
        frmScore.player3.addCardsOrWedges(Player.Wedges.Wild, False)
    End Sub
    Dim puzzleSolved = False
    Public Sub solvePuzzle(preview As Boolean)
        frmScore.btnBonusTimerStart.Hide()
        btnWild.Enabled = True
        puzzleSolved = True
        frmScore.lstMessages.Items.Clear()
        frmScore.notifyBar.Text = Nothing
        tmrTossUp.Stop()
        wheelTilt.Enabled = False
        If preview = False Then
            frmScore.resetPuzzle()
            btnSpinner.Enabled = True
            If revealed = False Then
                For Each lettersControls As Control In Controls
                    If lettersControls.GetType() Is GetType(PuzzleBoardLetter) Then
                        CType(lettersControls, PuzzleBoardLetter).revealLetter()
                    End If
                Next
                If round = WheelController.PuzzleType.TU1 Or round = WheelController.PuzzleType.TBTU Then
                    If WheelController.currentPlayer = 1 Then
                        frmScore.player1.total += 1000
                    ElseIf WheelController.currentPlayer = 2 Then
                        frmScore.player2.total += 1000
                    ElseIf WheelController.currentPlayer = 3 Then
                        frmScore.player3.total += 1000
                    End If
                ElseIf round = WheelController.PuzzleType.TU2 Then
                    If WheelController.currentPlayer = 1 Then
                        frmScore.player1.total += 2000
                    ElseIf WheelController.currentPlayer = 2 Then
                        frmScore.player2.total += 2000
                    ElseIf WheelController.currentPlayer = 3 Then
                        frmScore.player3.total += 2000
                    Else
                        WheelController.currentPlayer = WheelController.GetRandomPlayer(1, WheelController.numberOfPlayers + 1)
                    End If
                ElseIf round = WheelController.PuzzleType.TU3 Then
                    If WheelController.currentPlayer = 1 Then
                        frmScore.player1.total += 3000
                    ElseIf WheelController.currentPlayer = 2 Then
                        frmScore.player2.total += 3000
                    ElseIf WheelController.currentPlayer = 3 Then
                        frmScore.player3.total += 3000
                    Else
                        WheelController.currentPlayer = WheelController.GetRandomPlayer(1, WheelController.numberOfPlayers + 1)
                    End If
                ElseIf round = WheelController.PuzzleType.BR Then
                    If bonusSolved = False Then
                    Else
                        If WheelController.wheelWedges.Item(WheelSpinControl1.trkBonusWheel.Value) <> "Car" Then
                            frmScore.bonusRoundPlayer.total += WheelController.wheelWedges.Item(WheelSpinControl1.trkBonusWheel.Value)
                        Else
                            frmScore.bonusRoundPlayer.total += 25000
                        End If
                    End If
                Else
                    If round = WheelController.PuzzleType.R3 Then
                        If WheelController.currentPlayer = 1 Then
                            frmScore.player1.total += 10000
                        ElseIf WheelController.currentPlayer = 2 Then
                            frmScore.player2.total += 10000
                        ElseIf WheelController.currentPlayer = 3 Then
                            frmScore.player3.total += 10000
                        End If
                    End If
                    Dim player1Score As Integer = frmScore.player1Score
                    Dim player2Score As Integer = frmScore.player2Score
                    Dim player3Score As Integer = frmScore.player3Score
                    If WheelController.currentPlayer = 1 And Not WheelController.numberOfTurns = 0 Then
                        If WheelController.teams = False Then
                            If player1Score > 1000 Then
                                frmScore.player1.total += player1Score
                            Else
                                frmScore.player1.total += 1000
                            End If
                        Else
                            If player1Score > 2000 Then
                                frmScore.player1.total += player1Score
                            Else
                                frmScore.player1.total += 2000
                            End If
                        End If
                    ElseIf WheelController.currentPlayer = 2 Then
                        If WheelController.teams = False Then
                            If player2Score > 1000 Then
                                frmScore.player2.total += player2Score
                            Else
                                frmScore.player2.total += 1000
                            End If
                        Else
                            If player2Score > 2000 Then
                                frmScore.player2.total += player2Score
                            Else
                                frmScore.player2.total += 2000
                            End If
                        End If
                    ElseIf WheelController.currentPlayer = 3 Then
                        If WheelController.teams = False Then
                            If player3Score > 1000 Then
                                frmScore.player3.total += player3Score
                            Else
                                frmScore.player3.total += 1000
                            End If
                        Else
                            If player3Score > 2000 Then
                                frmScore.player3.total += player3Score
                            Else
                                frmScore.player3.total += 2000
                            End If
                        End If
                    End If

                    WheelController.currentPlayer = WheelController.GetRandomPlayer(1, WheelController.numberOfPlayers + 1)
                End If
                frmScore.lblPlayer1.Text = FormatCurrency("0", 0)
                frmScore.lblPlayer2.Text = FormatCurrency("0", 0)
                frmScore.lblPlayer3.Text = FormatCurrency("0", 0)
                frmScore.lblPlayer1Total.Show()
                frmScore.lblPlayer1Total.Text = FormatCurrency(frmScore.player1.total, 0)
                frmScore.lblPlayer2Total.Show()
                frmScore.lblPlayer2Total.Text = FormatCurrency(frmScore.player2.total, 0)
                frmScore.lblPlayer3Total.Show()
                frmScore.lblPlayer3Total.Text = FormatCurrency(frmScore.player3.total, 0)
                ListBox1.Items.Clear()
                ListBox2.Items.Clear()
                ListBox3.Items.Clear()
                If round = WheelController.PuzzleType.TU1 Or round = WheelController.PuzzleType.TU2 Or round = WheelController.PuzzleType.TU3 Then
                    If WheelController.tossUpLetterControlList.Count = 0 Or allRungIn = True Then
                        My.Computer.Audio.Play(My.Resources.double_buzz, AudioPlayMode.Background)
                    Else
                        My.Computer.Audio.Play(My.Resources.puzzle_solved_new, AudioPlayMode.WaitToComplete)
                    End If
                ElseIf round = WheelController.PuzzleType.BR Then
                    If bonusSolved = False Then
                        frmScore.BonusCardEnvelope1.Show()
                    Else
                        My.Computer.Audio.Play(My.Resources.puzzle_solved_new, AudioPlayMode.WaitToComplete)
                        frmScore.BonusCardEnvelope1.Show()
                    End If
                ElseIf WheelController.numberOfTurns = 0 Then
                    My.Computer.Audio.Play(My.Resources.double_buzz, AudioPlayMode.WaitToComplete)
                    tmrCheckTurns.Start()
                Else
                    My.Computer.Audio.Play(My.Resources.puzzle_solved_new, AudioPlayMode.WaitToComplete)
                End If
                player1RingIn = False
                player2RingIn = False
                player3RingIn = False
                allRungIn = False
                revealed = True
                WheelController.numberOfTurns = 10
                Exit Sub
            Else
                If revealed = True Then
                    logoCrossword.Hide()
                    logoExpress.Hide()
                    frmScore.lblPlayer1Total.Hide()
                    frmScore.lblPlayer2Total.Hide()
                    frmScore.lblPlayer3Total.Hide()
                    For Each lettersControls As Control In Controls
                        If lettersControls.GetType() Is GetType(PuzzleBoardLetter) Then
                            CType(lettersControls, PuzzleBoardLetter).letterBehind = ""
                        End If
                    Next
                    If round = WheelController.PuzzleType.TU1 Then
                        btnRedRingIn.Enabled = True
                        btnYellowRingIn.Enabled = True
                        btnBlueRingIn.Enabled = True
                        If WheelController.numberOfPlayers = 2 Then
                            btnRedRingIn.Show()
                            btnYellowRingIn.Show()
                            btnBlueRingIn.Hide()
                            player3RingIn = True
                        ElseIf WheelController.numberOfPlayers = 1 Then
                            btnRedRingIn.Show()
                            btnYellowRingIn.Hide()
                            player2RingIn = True
                            btnBlueRingIn.Hide()
                            player3RingIn = True
                        End If
                        WheelController.tossUpLetterControlList.Clear()
                        tmrTossUpRingIn.Stop()
                        round = WheelController.PuzzleType.TU2
                        pnlCategory.Hide()
                        loadTossUp()
                        tmrTossUpReveal.Start()
                        My.Computer.Audio.Play(My.Resources.puzzle_reveal, AudioPlayMode.Background)
                        puzzleSolved = False
                        WheelController.wheelLoad(WheelController.PuzzleType.TU2)
                        WheelController.loadPuzzle(WheelController.PuzzleType.TU2, False)
                        WheelController.tossUpStarted = False
                        WheelController.currentPlayer = Nothing
                        frmScore.tmrCheckVowels.Stop()
                    ElseIf round = WheelController.PuzzleType.TU2 Then
                        WheelController.tossUpLetterControlList.Clear()
                        tmrTossUpRingIn.Stop()
                        btnRedRingIn.Hide()
                        btnYellowRingIn.Hide()
                        btnBlueRingIn.Hide()
                        puzzleSolved = False
                        My.Computer.Audio.Play(My.Resources.puzzle_reveal, AudioPlayMode.Background)
                        round = WheelController.PuzzleType.R1
                        WheelController.wheelLoad(WheelController.PuzzleType.R1)
                        WheelController.loadPuzzle(WheelController.PuzzleType.R1, False)
                        WheelController.tossUpStarted = True
                        frmScore.usedLetterBoard.Enabled = True
                        wheelTilt.Enabled = True
                        frmScore.tmrCheckVowels.Start()
                    ElseIf round = WheelController.PuzzleType.R1 Then
                        puzzleSolved = False
                        My.Computer.Audio.Play(My.Resources.puzzle_reveal, AudioPlayMode.Background)
                        round = WheelController.PuzzleType.R2
                        WheelController.wheelLoad(WheelController.PuzzleType.R2)
                        WheelController.loadPuzzle(WheelController.PuzzleType.R2, False)
                        frmScore.tmrCheckVowels.Start()
                        wheelTilt.Enabled = True
                    ElseIf round = WheelController.PuzzleType.R2 Then
                        puzzleSolved = False
                        My.Computer.Audio.Play(My.Resources.prize_puzzle_reveal, AudioPlayMode.Background)
                        round = WheelController.PuzzleType.R3
                        WheelController.wheelLoad(WheelController.PuzzleType.R3)
                        WheelController.loadPuzzle(WheelController.PuzzleType.R3, False)
                        frmScore.tmrCheckVowels.Start()
                        wheelTilt.Enabled = True
                        frmScore.prizePuzzleStatus = True
                    ElseIf round = WheelController.PuzzleType.R3 Then
                        btnRedRingIn.Show()
                        btnYellowRingIn.Show()
                        btnBlueRingIn.Show()
                        If WheelController.numberOfPlayers = 2 Then
                            btnBlueRingIn.Hide()
                            player3RingIn = True
                        ElseIf WheelController.numberOfPlayers = 1 Then
                            btnYellowRingIn.Hide()
                            player2RingIn = True
                            btnBlueRingIn.Hide()
                            player3RingIn = True
                        End If
                        frmScore.prizePuzzleStatus = False
                        pnlCategory.Hide()
                        round = WheelController.PuzzleType.TU3
                        loadTossUp()
                        tmrTossUpReveal.Start()
                        puzzleSolved = False
                        My.Computer.Audio.Play(My.Resources.puzzle_reveal, AudioPlayMode.Background)
                        WheelController.wheelLoad(WheelController.PuzzleType.TU3)
                        WheelController.loadPuzzle(WheelController.PuzzleType.TU3, False)
                        WheelController.tossUpStarted = False
                        frmScore.usedLetterBoard.Enabled = False
                        wheelTilt.Enabled = False
                        WheelController.currentPlayer = Nothing
                        btnWild.Hide()
                        logoExpress.Hide()
                        frmScore.tmrCheckVowels.Stop()
                        btnRedRingIn.Enabled = True
                        btnYellowRingIn.Enabled = True
                        btnBlueRingIn.Enabled = True
                    ElseIf round = WheelController.PuzzleType.TU3 Then
                        WheelController.tossUpLetterControlList.Clear()
                        puzzleSolved = False
                        tmrTossUpRingIn.Stop()
                        btnRedRingIn.Hide()
                        btnYellowRingIn.Hide()
                        btnBlueRingIn.Hide()
                        My.Computer.Audio.Play(My.Resources.puzzle_reveal, AudioPlayMode.Background)
                        round = WheelController.PuzzleType.R4
                        WheelController.wheelLoad(WheelController.PuzzleType.R4)
                        WheelController.loadPuzzle(WheelController.PuzzleType.R4, False)
                        frmScore.lblPlayer1Total.Text = FormatCurrency(frmScore.player1.total, 0)
                        frmScore.lblPlayer2Total.Text = FormatCurrency(frmScore.player2.total, 0)
                        frmScore.lblPlayer3Total.Text = FormatCurrency(frmScore.player3.total, 0)
                        WheelController.tossUpStarted = True
                        frmScore.usedLetterBoard.Enabled = True
                        wheelTilt.Enabled = True
                        frmScore.tmrCheckVowels.Start()
                    ElseIf round = WheelController.PuzzleType.R4 Then
                        If WheelController.finalSpin = True Then
                            loadBonusRound()
                        ElseIf WheelController.finalSpin = False Then
                            puzzleSolved = False
                            My.Computer.Audio.Play(My.Resources.puzzle_reveal, AudioPlayMode.Background)
                            round = WheelController.PuzzleType.R5
                            WheelController.wheelLoad(WheelController.PuzzleType.R5)
                            WheelController.loadPuzzle(WheelController.PuzzleType.R5, False)
                            frmScore.tmrCheckVowels.Start()
                            wheelTilt.Enabled = True
                        End If
                    ElseIf round = WheelController.PuzzleType.R5 Then
                        If WheelController.finalSpin = False Then
                            puzzleSolved = False
                            My.Computer.Audio.Play(My.Resources.puzzle_reveal, AudioPlayMode.Background)
                            round = WheelController.PuzzleType.R6
                            WheelController.wheelLoad(WheelController.PuzzleType.R6)
                            WheelController.loadPuzzle(WheelController.PuzzleType.R6, False)
                            frmScore.tmrCheckVowels.Start()
                            wheelTilt.Enabled = True
                        Else
                            loadBonusRound()
                        End If
                    ElseIf round = WheelController.PuzzleType.R6 Then
                        If WheelController.finalSpin = False Then
                            puzzleSolved = False
                            My.Computer.Audio.Play(My.Resources.puzzle_reveal, AudioPlayMode.Background)
                            round = WheelController.PuzzleType.R7
                            WheelController.wheelLoad(WheelController.PuzzleType.R7)
                            WheelController.loadPuzzle(WheelController.PuzzleType.R7, False)
                            frmScore.tmrCheckVowels.Start()
                            wheelTilt.Enabled = True
                        Else
                            loadBonusRound()
                        End If
                    ElseIf round = WheelController.PuzzleType.R7 Then
                        If WheelController.finalSpin = False Then
                            puzzleSolved = False
                            My.Computer.Audio.Play(My.Resources.puzzle_reveal, AudioPlayMode.Background)
                            round = WheelController.PuzzleType.R8
                            WheelController.wheelLoad(WheelController.PuzzleType.R8)
                            WheelController.loadPuzzle(WheelController.PuzzleType.R8, False)
                            frmScore.tmrCheckVowels.Start()
                            wheelTilt.Enabled = True
                        Else
                            loadBonusRound()
                        End If
                    ElseIf round = WheelController.PuzzleType.R8 Then
                        If WheelController.finalSpin = False Then
                            puzzleSolved = False
                            My.Computer.Audio.Play(My.Resources.puzzle_reveal, AudioPlayMode.Background)
                            round = WheelController.PuzzleType.R9
                            WheelController.wheelLoad(WheelController.PuzzleType.R9)
                            WheelController.loadPuzzle(WheelController.PuzzleType.R9, False)
                            frmScore.tmrCheckVowels.Start()
                            wheelTilt.Enabled = True
                        Else
                            loadBonusRound()
                        End If
                    ElseIf round = WheelController.PuzzleType.R9 Then
                        loadBonusRound()
                    ElseIf round = WheelController.PuzzleType.TBTU Then
                        loadBonusRound()
                    End If
                    For Each lettersControls As Control In Controls
                        If lettersControls.GetType() Is GetType(PuzzleBoardLetter) Then
                            If CType(lettersControls, PuzzleBoardLetter).letterBehind = "'" Or CType(lettersControls, PuzzleBoardLetter).letterBehind = "?" Or CType(lettersControls, PuzzleBoardLetter).letterBehind = "." Or CType(lettersControls, PuzzleBoardLetter).letterBehind = "!" Or CType(lettersControls, PuzzleBoardLetter).letterBehind = "-" Or CType(lettersControls, PuzzleBoardLetter).letterBehind = "/" Or CType(lettersControls, PuzzleBoardLetter).letterBehind = ":" Or CType(lettersControls, PuzzleBoardLetter).letterBehind = "\" Or CType(lettersControls, PuzzleBoardLetter).letterBehind = "&" Then
                                CType(lettersControls, PuzzleBoardLetter).revealLetter()
                            Else
                                CType(lettersControls, PuzzleBoardLetter).btnLetter.Text = ""
                            End If
                        End If
                    Next
                    If round <> WheelController.PuzzleType.BR Then
                        lblCategory.Text = WheelController.category
                    Else
                        lblCategory.Text = ""
                        pnlCategory.Hide()
                        lblChosenLetters.Hide()
                        lblRSTLNE.Hide()
                        frmScore.BonusCardEnvelope1.Hide()
                        frmScore.usedLetterBoard.Enabled = False
                        btnSolve.Enabled = False
                        For Each letterController As Control In Controls
                            If letterController.GetType() Is GetType(PuzzleBoardLetter) Then
                                CType(letterController, PuzzleBoardLetter).Hide()
                            End If
                        Next
                    End If
                    revealed = False
                End If
            End If
        ElseIf preview = True Then
            btnSpinner.Enabled = False
            For Each lettersControls As Control In Controls
                If lettersControls.GetType() Is GetType(PuzzleBoardLetter) Then
                    CType(lettersControls, PuzzleBoardLetter).revealLetter()
                End If
            Next
        End If
    End Sub
    Private Sub loadBonusRound()
        If CInt(frmScore.player1.total) > CInt(frmScore.player2.total) And CInt(frmScore.player1.total) > CInt(frmScore.player3.total) Then
            WheelController.currentPlayer = 1
            frmScore.bonusRoundPlayer = frmScore.player1
        ElseIf CInt(frmScore.player2.total) > CInt(frmScore.player1.total) And CInt(frmScore.player2.total) > CInt(frmScore.player3.total) Then
            WheelController.currentPlayer = 2
            frmScore.bonusRoundPlayer = frmScore.player2
        ElseIf CInt(frmScore.player3.total) > CInt(frmScore.player1.total) And CInt(frmScore.player3.total) > CInt(frmScore.player2.total) Then
            WheelController.currentPlayer = 3
            frmScore.bonusRoundPlayer = frmScore.player3
        Else
            btnRedRingIn.Enabled = True
            btnYellowRingIn.Enabled = True
            btnBlueRingIn.Enabled = True
            wheelTilt.Enabled = False
            frmScore.usedLetterBoard.Enabled = False
            WheelController.tossUpLetterControlList.Clear()
            tmrTossUpRingIn.Stop()
            round = WheelController.PuzzleType.TBTU
            pnlCategory.Hide()
            loadTossUp()
            tmrTossUpReveal.Start()
            My.Computer.Audio.Play(My.Resources.puzzle_reveal, AudioPlayMode.Background)
            puzzleSolved = False
            WheelController.wheelLoad(WheelController.PuzzleType.TBTU)
            WheelController.loadPuzzle(WheelController.PuzzleType.TBTU, False)
            WheelController.tossUpStarted = False
            WheelController.currentPlayer = Nothing
            frmScore.tmrCheckVowels.Stop()
            Exit Sub
        End If
        frmScore.lblNumberOfTurns.Hide()
        wheelTilt.Enabled = True
        btnRedRingIn.Hide()
        btnYellowRingIn.Hide()
        btnBlueRingIn.Hide()
        puzzleSolved = False
        pnlCategory.Hide()
        round = WheelController.PuzzleType.BR
        WheelController.wheelLoad(WheelController.PuzzleType.BR)
        lblCategory.Text = ""
        btnSpinner.BackgroundImage = My.Resources.BonusWheel
        wheelTilt.Show()
        wheelTilt.Image = My.Resources.WheelTiltedSmallBonusCards
        WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelSpinBonus.mp4"
        wheelTilt.Image = My.Resources.WheelTiltedSmallBonusCards
        WheelSpinControl1.wheelCover.BackgroundImage = My.Resources.wheelCoverHDBonus
        WheelSpinControl1.firstSpin = True
        WheelSpinControl1.wmpWheel.Ctlcontrols.stop()
        frmScore.tmrCheckVowels.Stop()
        frmScore.tmrFinalSpin.Stop()
        WheelController.finalSpin = False
        WheelController.finalSpinSpun = False
        frmScore.usedLetterBoard.Enabled = False
        frmScore.lblCurrentValue.Hide()
        frmScore.lblControllerSpinResult.Hide()
        btnSolve.Enabled = False
    End Sub
    Private Sub btnSolve_Click(sender As Object, e As EventArgs) Handles btnSolve.Click
        solvePuzzle(False)
    End Sub

    Private Sub BonusRoundRevealToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BonusRoundRevealToolStripMenuItem.Click
        If round = WheelController.PuzzleType.BR Then
            revealBonus()
        Else
        End If
    End Sub
    Private Sub revealBonus()
        My.Computer.Audio.Play(My.Resources.puzzle_reveal, AudioPlayMode.Background)
        WheelController.loadPuzzle(round, False)
        pnlCategory.Show()
        lblCategory.Text = WheelController.category
    End Sub

    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        frmCustomizer.Show()
        Me.Close()
    End Sub

    Private Sub wheelTilt_Click(sender As Object, e As EventArgs) Handles wheelTilt.Click
        frmScore.turnTaken = True
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
                CType(Controls("PuzzleBoardLetter" & WheelController.tossUpLetterControlList(randomNumber)), PuzzleBoardLetter).revealLetter()
                ListBox4.Items.Add(randomNumber & CType(Controls("PuzzleBoardLetter" & WheelController.tossUpLetterControlList(randomNumber)), PuzzleBoardLetter).letterBehind)
                WheelController.tossUpLetterControlList.Remove(WheelController.tossUpLetterControlList(randomNumber))
                timeStart = DateTime.Now.Second
            End If
        Next
        If WheelController.tossUpLetterControlList.Count = 0 Or allRungIn = True Then
            tmrTossUp.Stop()
            My.Computer.Audio.Play(My.Resources.double_buzz, AudioPlayMode.Background)
        End If
    End Sub
    Dim tossUpRevealTimeStart As Integer
    Private Sub tmrTossUpReveal_Tick(sender As Object, e As EventArgs) Handles tmrTossUpReveal.Tick
        pnlCategory.Show()
        If DateTime.Now.Second = WheelController.convertTimeTossUpReveal(tossUpRevealTimeStart) Then
            pboxTossUp.Hide()
            tmrTossUpReveal.Stop()
        End If
    End Sub
    Public bonusTimeStart As Integer
    Private Sub tmrBonus_Tick(sender As Object, e As EventArgs) Handles tmrBonus.Tick
        If DateTime.Now.Second = WheelController.convertTime(bonusTimeStart + 9) Then
            bonusSolved = False
            solvePuzzle(True)
            frmScore.BonusCardEnvelope1.Show()
            'frmScore.timeStart = DateTime.Now.Second
            'frmScore.tmrSolveFailed.Start()
            tmrBonus.Stop()
        End If
    End Sub

    Private Sub tmrTossUpRingIn_Tick(sender As Object, e As EventArgs) Handles tmrTossUpRingIn.Tick
        If My.Computer.Keyboard.CtrlKeyDown And player1RingIn = False Then
            player1RingIn = True
            My.Computer.Audio.Play(My.Resources.Ding, AudioPlayMode.Background)
            WheelController.currentPlayer = 1
            btnYellowRingIn.Enabled = False
            btnBlueRingIn.Enabled = False
            tmrTossUpRingIn.Stop()
            tmrTossUp.Stop()
        ElseIf My.Computer.Keyboard.AltKeyDown And player2RingIn = False Then
            player2RingIn = True
            My.Computer.Audio.Play(My.Resources.Ding, AudioPlayMode.Background)
            WheelController.currentPlayer = 2
            btnRedRingIn.Enabled = False
            btnBlueRingIn.Enabled = False
            tmrTossUpRingIn.Stop()
            tmrTossUp.Stop()
        ElseIf My.Computer.Keyboard.ShiftKeyDown And player3RingIn = False Then
            player3RingIn = True
            My.Computer.Audio.Play(My.Resources.Ding, AudioPlayMode.Background)
            WheelController.currentPlayer = 3
            btnYellowRingIn.Enabled = False
            btnRedRingIn.Enabled = False
            tmrTossUpRingIn.Stop()
            tmrTossUp.Stop()
        End If
        If player1RingIn = True And player2RingIn = True And player3RingIn = True And Not WheelController.numberOfPlayers = 1 Then
            allRungIn = True
            For Each lettersControls As Control In Controls
                If lettersControls.GetType() Is GetType(PuzzleBoardLetter) Then
                    CType(lettersControls, PuzzleBoardLetter).revealLetter()
                End If
            Next
            WheelController.currentPlayer = Nothing
            'tmrTossUp.Stop()
            'tmrTossUpRingIn.Stop()
        End If
    End Sub

    Private Sub btnRedRingIn_Click(sender As Object, e As EventArgs) Handles btnRedRingIn.Click
        If player1RingIn = True Then
            If Not WheelController.numberOfPlayers = 1 Then
                WheelController.startTossUp()
                WheelController.currentPlayer = Nothing
                tmrTossUpRingIn.Start()
                btnYellowRingIn.Enabled = True
                btnBlueRingIn.Enabled = True
            Else
                allRungIn = True
                For Each lettersControls As Control In Controls
                    If lettersControls.GetType() Is GetType(PuzzleBoardLetter) Then
                        CType(lettersControls, PuzzleBoardLetter).revealLetter()
                    End If
                Next
                WheelController.currentPlayer = Nothing
                My.Computer.Audio.Play(My.Resources.double_buzz, AudioPlayMode.Background)
            End If
        ElseIf player1RingIn = False Then
                player1RingIn = True
            My.Computer.Audio.Play(My.Resources.Ding, AudioPlayMode.Background)
            WheelController.currentPlayer = 1
            btnYellowRingIn.Enabled = False
            btnBlueRingIn.Enabled = False
            tmrTossUpRingIn.Stop()
            tmrTossUp.Stop()
        End If
    End Sub

    Private Sub btnYellowRingIn_Click(sender As Object, e As EventArgs) Handles btnYellowRingIn.Click
        If player2RingIn = True Then
            WheelController.startTossUp()
            WheelController.currentPlayer = Nothing
            tmrTossUpRingIn.Start()
            btnRedRingIn.Enabled = True
            btnBlueRingIn.Enabled = True
        ElseIf player2RingIn = False Then
            player2RingIn = True
            My.Computer.Audio.Play(My.Resources.Ding, AudioPlayMode.Background)
            WheelController.currentPlayer = 2
            btnRedRingIn.Enabled = False
            btnBlueRingIn.Enabled = False
            tmrTossUpRingIn.Stop()
            tmrTossUp.Stop()
        End If
    End Sub

    Private Sub btnBlueRingIn_Click(sender As Object, e As EventArgs) Handles btnBlueRingIn.Click
        If player3RingIn = True Then
            WheelController.startTossUp()
            WheelController.currentPlayer = Nothing
            tmrTossUpRingIn.Start()
            btnYellowRingIn.Enabled = True
            btnRedRingIn.Enabled = True
        ElseIf player3RingIn = False Then
            player3RingIn = True
            My.Computer.Audio.Play(My.Resources.Ding, AudioPlayMode.Background)
            WheelController.currentPlayer = 3
            btnYellowRingIn.Enabled = False
            btnRedRingIn.Enabled = False
            tmrTossUpRingIn.Stop()
            tmrTossUp.Stop()
        End If
    End Sub

    Private Sub pboxTossUp_Click(sender As Object, e As EventArgs) Handles pboxTossUp.Click
        pboxTossUp.Hide()
    End Sub

    Private Sub tmrCheckFinalSpin_Tick(sender As Object, e As EventArgs) Handles tmrCheckFinalSpin.Tick
        If DateTime.Now.Minute = WheelController.convertTime(WheelController.startTime + 19) And round <> WheelController.PuzzleType.TU1 And round <> WheelController.PuzzleType.TU2 And round <> WheelController.PuzzleType.TU3 Then
            If puzzleSolved = False And frmScore.turnTaken = False Then
                frmFinalSpin.Show()
                WheelController.previousValue = ""
                WheelController.finalSpin = True
                tmrCheckFinalSpin.Stop()
            Else
                WheelController.finalSpinQueued = True
            End If
        ElseIf WheelController.finalSpinQueued = True And puzzleSolved = False And frmScore.turnTaken = False Then
            frmFinalSpin.Show()
            WheelController.finalSpin = True
            WheelController.previousValue = ""
            tmrCheckFinalSpin.Stop()
        End If
    End Sub

    Private Sub tmrCheckTurns_Tick(sender As Object, e As EventArgs) Handles tmrCheckTurns.Tick
        frmScore.lblNumberOfTurns.Text = WheelController.numberOfTurns
        If WheelController.numberOfTurns = 0 Then
            tmrCheckTurns.Stop()
            My.Computer.Audio.Play(My.Resources.bankrupt, AudioPlayMode.WaitToComplete)
            solvePuzzle(False)
        End If
    End Sub
End Class