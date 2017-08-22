Public Class frmScore
    Public player1 As New Player
    Public player2 As New Player
    Public player3 As New Player
    Public player1Score As Integer
    Public player2Score As Integer
    Public player3Score As Integer
    Public puzzleString As String
    Public noMoreVowelsShown As Boolean = False
    Public noMoreConsonantsShown As Boolean = False
    Public bonusRoundPlayer As Player
    Public wildUsed As Boolean = False
    Public numberOfUntappedLetters As Integer = 0
    Public spun As Boolean = False
    Public currentLetter As String
    Public turnTaken As Boolean = False
    Public prizePuzzleStatus As Boolean = False
    Private Sub frmScore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NameTag1.contestantName = WheelController.player1Name
        NameTag2.contestantName = WheelController.player2Name
        NameTag3.contestantName = WheelController.player3Name
        tmrCheckPlayer.Start()
    End Sub
    Private Sub frmScore_FormClosing(sender As Object, e As EventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    Private Sub quitBTN_Click(sender As Object, e As EventArgs) Handles quitBTN.Click
        Application.Exit()
    End Sub
    Public Sub enableVowels(value As Boolean)
        If value = True Then
            If WheelController.aEnabled = True Then
                btnA.Enabled = True
            Else
                btnA.Enabled = False
            End If
            If WheelController.eEnabled = True Then
                btnE.Enabled = True
            Else
                btnE.Enabled = False
            End If
            If WheelController.iEnabled = True Then
                btnI.Enabled = True
            Else
                btnI.Enabled = False
            End If
            If WheelController.oEnabled = True Then
                btnO.Enabled = True
            Else
                btnO.Enabled = False
            End If
            If WheelController.uEnabled = True Then
                btnU.Enabled = True
            Else
                btnU.Enabled = False
            End If
        ElseIf value = False Then
            btnA.Enabled = False
            btnE.Enabled = False
            btnI.Enabled = False
            btnO.Enabled = False
            btnU.Enabled = False
        End If
    End Sub
    Private Sub enableBonusVowels(value As Boolean)
        If value = True Then
            If WheelController.aEnabled = True Then
                btnA.Enabled = True
            Else
                btnA.Enabled = False
            End If
            If WheelController.iEnabled = True Then
                btnI.Enabled = True
            Else
                btnI.Enabled = False
            End If
            If WheelController.oEnabled = True Then
                btnO.Enabled = True
            Else
                btnO.Enabled = False
            End If
            If WheelController.uEnabled = True Then
                btnU.Enabled = True
            Else
                btnU.Enabled = False
            End If
            btnB.Enabled = False
            btnC.Enabled = False
            btnD.Enabled = False
            btnE.Enabled = False
            btnF.Enabled = False
            btnG.Enabled = False
            btnH.Enabled = False
            btnJ.Enabled = False
            btnK.Enabled = False
            btnM.Enabled = False
            btnP.Enabled = False
            btnQ.Enabled = False
            btnV.Enabled = False
            btnW.Enabled = False
            btnX.Enabled = False
            btnY.Enabled = False
            btnZ.Enabled = False
        ElseIf value = False Then
            btnA.Enabled = False
            btnE.Enabled = False
            btnI.Enabled = False
            btnO.Enabled = False
            btnU.Enabled = False
        End If
    End Sub
    Public Sub resetPuzzle()
        noMoreVowelsShown = False
        noMoreConsonantsShown = False
        If WheelController.currentPlayer = 1 And player1.getWedges(Player.Wedges.HalfCar1) = True Or WheelController.currentPlayer = 1 And player1.getWedges(Player.Wedges.HalfCar2) = True Then
        Else
            player1.addCardsOrWedges(Player.Wedges.HalfCar1, False)
            player1.addCardsOrWedges(Player.Wedges.HalfCar2, False)
        End If
        If WheelController.currentPlayer = 2 And player1.getWedges(Player.Wedges.HalfCar1) = True Or WheelController.currentPlayer = 2 And player1.getWedges(Player.Wedges.HalfCar2) = True Then
        Else
            player2.addCardsOrWedges(Player.Wedges.HalfCar1, False)
            player2.addCardsOrWedges(Player.Wedges.HalfCar2, False)
        End If
        If WheelController.currentPlayer = 3 And player1.getWedges(Player.Wedges.HalfCar1) = True Or WheelController.currentPlayer = 3 And player1.getWedges(Player.Wedges.HalfCar2) = True Then
        Else
            player3.addCardsOrWedges(Player.Wedges.HalfCar1, False)
            player3.addCardsOrWedges(Player.Wedges.HalfCar2, False)
        End If
        If WheelController.currentPlayer = 1 Then
            If player1.getWedges(Player.Wedges.Gift) = True Then
                player1.total += 1000
                player1.addCardsOrWedges(Player.Wedges.Gift, False)
            End If
            If player1.getWedges(Player.Wedges.Mystery) = True And WheelController.currentPlayer = 1 Then
                player1.total += 10000
                player1.addCardsOrWedges(Player.Wedges.Mystery, False)
            End If
            If player1.getWedges(Player.Wedges.Prize) = True And WheelController.currentPlayer = 1 Then
                player1.total += 10000
                player1.addCardsOrWedges(Player.Wedges.Prize, False)
            End If
            If player1.getWedges(Player.Wedges.Prize) = True And WheelController.currentPlayer = 1 Then
                player1.total += 10000
                player1.addCardsOrWedges(Player.Wedges.Prize, False)
            End If
            If player1.getWedges(Player.Wedges.HalfCar1) = True Then
                player1.addCardsOrWedges(Player.Wedges.HalfCar1, True)
            End If
            If player1.getWedges(Player.Wedges.HalfCar2) = True Then
                player1.addCardsOrWedges(Player.Wedges.HalfCar2, True)
            End If
            If player1.getWedges(Player.Wedges.HalfCar1) = True And player1.getWedges(Player.Wedges.HalfCar2) = True Then
                player1.total += 19000
            End If
            'If prizePuzzleStatus = True Then
            '    player1.total += 10000
            'End If
        ElseIf WheelController.currentPlayer = 2 Then
            If player2.getWedges(Player.Wedges.Gift) = True Then
                player2.total += 1000
                player2.addCardsOrWedges(Player.Wedges.Gift, False)
            End If
            If player2.getWedges(Player.Wedges.Mystery) = True And WheelController.currentPlayer = 2 Then
                player2.total += 10000
                player2.addCardsOrWedges(Player.Wedges.Mystery, False)
            End If
            If player2.getWedges(Player.Wedges.Prize) = True And WheelController.currentPlayer = 2 Then
                player2.total += 10000
                player2.addCardsOrWedges(Player.Wedges.Prize, False)
            End If
            If player2.getWedges(Player.Wedges.HalfCar1) = True Then
                player2.addCardsOrWedges(Player.Wedges.HalfCar1, True)
            End If
            If player2.getWedges(Player.Wedges.HalfCar2) = True Then
                player2.addCardsOrWedges(Player.Wedges.HalfCar2, True)
            End If
            If player2.getWedges(Player.Wedges.HalfCar1) = True And player2.getWedges(Player.Wedges.HalfCar2) = True Then
                player2.total += 19000
            End If
            'If prizePuzzleStatus = True Then
            '    player2.total += 10000
            'End If
        ElseIf WheelController.currentPlayer = 3 Then
            If player3.getWedges(Player.Wedges.Gift) = True Then
                player3.total += 1000
                player3.addCardsOrWedges(Player.Wedges.Gift, False)
            End If
            If player3.getWedges(Player.Wedges.Mystery) = True And WheelController.currentPlayer = 3 Then
                player3.total += 10000
                player3.addCardsOrWedges(Player.Wedges.Mystery, False)
            End If
            If player3.getWedges(Player.Wedges.Prize) = True And WheelController.currentPlayer = 3 Then
                player3.total += 10000
                player3.addCardsOrWedges(Player.Wedges.Prize, False)
            End If
            If player3.getWedges(Player.Wedges.HalfCar1) = True Then
                player3.addCardsOrWedges(Player.Wedges.HalfCar1, True)
            End If
            If player3.getWedges(Player.Wedges.HalfCar2) = True Then
                player3.addCardsOrWedges(Player.Wedges.HalfCar2, True)
            End If
            If player3.getWedges(Player.Wedges.HalfCar1) = True And player3.getWedges(Player.Wedges.HalfCar2) = True Then
                player3.total += 19000
            End If
            'If prizePuzzleStatus = True Then
            '    player3.total += 10000
            'End If
        End If
        WheelController.aEnabled = True
        WheelController.eEnabled = True
        WheelController.iEnabled = True
        WheelController.oEnabled = True
        WheelController.uEnabled = True
        btnB.Enabled = True
        btnC.Enabled = True
        btnD.Enabled = True
        btnF.Enabled = True
        btnG.Enabled = True
        btnH.Enabled = True
        btnJ.Enabled = True
        btnK.Enabled = True
        btnL.Enabled = True
        btnM.Enabled = True
        btnN.Enabled = True
        btnP.Enabled = True
        btnQ.Enabled = True
        btnR.Enabled = True
        btnS.Enabled = True
        btnT.Enabled = True
        btnV.Enabled = True
        btnW.Enabled = True
        btnX.Enabled = True
        btnY.Enabled = True
        btnZ.Enabled = True
        puzzleString = WheelController.puzzle
    End Sub
    Dim isVowel As Boolean = False
    Private Sub btnLetter_Click(sender As Object, e As EventArgs) Handles btnA.Click, btnB.Click, btnC.Click, btnD.Click, btnE.Click, btnF.Click, btnG.Click, btnH.Click, btnI.Click, btnJ.Click, btnK.Click, btnL.Click, btnM.Click, btnN.Click, btnO.Click, btnP.Click, btnQ.Click, btnR.Click, btnS.Click, btnT.Click, btnU.Click, btnV.Click, btnW.Click, btnX.Click, btnY.Click, btnZ.Click
        frmPuzzleBoard.btnSolve.Enabled = True
        turnTaken = False
        If WheelController.previousValue = "Bankrupt" Or WheelController.previousValue = "Lose A Turn" Then

        Else
            currentLetter = CType(sender, Button).Text
            If WheelController.finalSpin = False Then
                spun = False
                frmPuzzleBoard.wheelTilt.Enabled = True
            Else
                usedLetterBoard.Enabled = False
                frmPuzzleBoard.wheelTilt.Enabled = False
            End If
            If WheelController.roundType <> WheelController.PuzzleType.BR Then
                If CType(sender, Button).Text = "A" Or CType(sender, Button).Text = "E" Or CType(sender, Button).Text = "I" Or CType(sender, Button).Text = "O" Or CType(sender, Button).Text = "U" Then
                    If CType(sender, Button).Text = "A" Then
                        WheelController.aEnabled = False
                    ElseIf CType(sender, Button).Text = "E" Then
                        WheelController.eEnabled = False
                    ElseIf CType(sender, Button).Text = "I" Then
                        WheelController.iEnabled = False
                    ElseIf CType(sender, Button).Text = "O" Then
                        WheelController.oEnabled = False
                    ElseIf CType(sender, Button).Text = "U" Then
                        WheelController.uEnabled = False
                    End If
                    isVowel = True
                    If WheelController.currentPlayer = 1 Then
                        If lblCurrentValue.Text = "Free Play" Or WheelController.finalSpin = True Then
                        ElseIf CInt(lblPlayer1.Text.Replace("$", "")) > 250 Then
                            Dim currentPlayerValue = CInt(lblPlayer1.Text.Replace("$", ""))
                            currentPlayerValue -= 250
                            lblPlayer1.Text = FormatCurrency(currentPlayerValue, 0)
                        Else

                            Exit Sub
                        End If
                    ElseIf WheelController.currentPlayer = 2 Then
                        If lblCurrentValue.Text = "Free Play" Or WheelController.finalSpin = True Then
                        ElseIf CInt(lblPlayer2.Text.Replace("$", "")) > 250 Then
                            Dim currentPlayerValue = CInt(lblPlayer2.Text.Replace("$", ""))
                            currentPlayerValue -= 250
                            lblPlayer2.Text = FormatCurrency(currentPlayerValue, 0)
                        Else
                            Exit Sub
                        End If
                    ElseIf WheelController.currentPlayer = 3 Then
                        If lblCurrentValue.Text = "Free Play" Or WheelController.finalSpin = True Then
                        ElseIf CInt(lblPlayer3.Text.Replace("$", "")) > 250 Then
                            Dim currentPlayerValue = CInt(lblPlayer3.Text.Replace("$", ""))
                            currentPlayerValue -= 250
                            lblPlayer3.Text = FormatCurrency(currentPlayerValue, 0)
                        Else
                            Exit Sub
                        End If
                    End If
                Else
                    If lblCurrentValue.Text = "0" And wildUsed = False And WheelController.expressStatus = False And WheelController.finalSpin = False Then
                        Exit Sub
                    Else
                    End If
                End If
                If WheelController.puzzle.Contains(currentLetter) Then
                    For Each letterControl As Control In frmPuzzleBoard.Controls
                        If letterControl.GetType() Is GetType(PuzzleBoardLetter) Then
                            If CType(letterControl, PuzzleBoardLetter).letterBehind = currentLetter Then
                                WheelController.letterControlList.Add(letterControl.Name.Replace("PuzzleBoardLetter", ""))
                                WheelController.letterControlTappedList.Add(letterControl.Name.Replace("PuzzleBoardLetter", ""))
                            End If
                        End If
                    Next
                    If lblCurrentValue.Text = "Mystery 1" And WheelController.mysteryStatus = False Or lblCurrentValue.Text = "Mystery 2" And WheelController.mysteryStatus = False Then
                        MysteryDialog.ShowDialog()
                    End If
                    If lblCurrentValue.Text = "Express" Then
                        ExpressDialog.ShowDialog()
                    End If
                End If
                notifyBar.Text = WheelController.revealNumberOfLetters()
                    timeStart = DateTime.Now.Second
                tmrLetterReveal.Start()
                If WheelController.currentPlayer = 1 Then
                        If isVowel = False And Not lblCurrentValue.Text = "Mystery 1" AndAlso isVowel = False And Not lblCurrentValue.Text = "Mystery 2" Then
                            Dim currentPlayerValue = CInt(lblPlayer1.Text.Replace("$", ""))
                            currentPlayerValue += WheelController.spinResult * WheelController.letterControlList.Count
                        lblPlayer1.Text = FormatCurrency(currentPlayerValue, 0)
                        If currentLetter = WheelController.sameLetter And WheelController.category = "SAME LETTER" Then
                            Dim currentPlayer1Value = CInt(lblPlayer1.Text.Replace("$", ""))
                            currentPlayer1Value += 1000
                            lblPlayer1.Text = FormatCurrency(currentPlayer1Value, 0)
                        End If
                    Else
                            CType(sender, Button).Enabled = False
                        End If
                    ElseIf WheelController.currentPlayer = 2 Then
                        If isVowel = False And Not lblCurrentValue.Text = "Mystery 1" AndAlso isVowel = False And Not lblCurrentValue.Text = "Mystery 2" Then
                            Dim currentPlayerValue = CInt(lblPlayer2.Text.Replace("$", ""))
                            currentPlayerValue += WheelController.spinResult * WheelController.letterControlList.Count
                        lblPlayer2.Text = FormatCurrency(currentPlayerValue, 0)
                        If currentLetter = WheelController.sameLetter And WheelController.category = "SAME LETTER" Then
                            Dim currentPlayer2Value = CInt(lblPlayer2.Text.Replace("$", ""))
                            currentPlayer2Value += 1000
                            lblPlayer2.Text = FormatCurrency(currentPlayer2Value, 0)
                        End If
                    Else
                            CType(sender, Button).Enabled = False
                        End If
                    ElseIf WheelController.currentPlayer = 3 Then
                        If isVowel = False And Not lblCurrentValue.Text = "Mystery 1" AndAlso isVowel = False And Not lblCurrentValue.Text = "Mystery 2" Then
                            Dim currentPlayerValue = CInt(lblPlayer3.Text.Replace("$", ""))
                            currentPlayerValue += WheelController.spinResult * WheelController.letterControlList.Count
                        lblPlayer3.Text = FormatCurrency(currentPlayerValue, 0)
                        If currentLetter = WheelController.sameLetter And WheelController.category = "SAME LETTER" Then
                            Dim currentPlayer3Value = CInt(lblPlayer3.Text.Replace("$", ""))
                            currentPlayer3Value += 1000
                            lblPlayer3.Text = FormatCurrency(currentPlayer3Value, 0)
                        End If
                    Else
                            CType(sender, Button).Enabled = False
                        End If
                    End If
                    If WheelController.currentPlayer = 1 And WheelController.puzzle.Contains(CType(sender, Button).Text) Then
                        If lblCurrentValue.Text = "1/2 Car" And WheelController.halfCar1Status = False Or lblCurrentValue.Text = "1/2 Car" And WheelController.halfCar2Status = False Then
                            If halfcar1.Visible = False And halfcar2.Visible = False Or halfcar2.Visible = True Then
                                player1.addCardsOrWedges(Player.Wedges.HalfCar1, True)
                                WheelController.halfCar1Status = True
                                halfcar1.Show()
                                lblCurrentValue.Text = 0
                                WheelController.spinResult = 0
                                isVowel = False
                            ElseIf halfcar1.Visible = True And halfcar2.Visible = False Then
                                player1.addCardsOrWedges(Player.Wedges.HalfCar2, True)
                                WheelController.halfCar2Status = True
                                halfcar2.Show()
                                lblCurrentValue.Text = 0
                                WheelController.spinResult = 0
                                isVowel = False
                            End If
                        End If
                        If lblCurrentValue.Text = "Million" And WheelController.millionStatus = False Then
                            player1.addCardsOrWedges(Player.Wedges.Million, True)
                            WheelController.millionStatus = True
                            Million.Show()
                        End If
                        If lblCurrentValue.Text = "Wild" And WheelController.wildCardStatus = False Then
                            player1.addCardsOrWedges(Player.Wedges.Wild, True)
                            frmPuzzleBoard.btnWild.Show()
                            WheelController.wildCardStatus = True
                            Wild.Show()
                        End If
                        If lblCurrentValue.Text = "Gift" And WheelController.giftStatus = False Then
                            player1.addCardsOrWedges(Player.Wedges.Gift, True)
                            WheelController.giftStatus = True
                            Gift.Show()
                        End If
                        If lblCurrentValue.Text = "Prize" And WheelController.prizeStatus = False Then
                            player1.addCardsOrWedges(Player.Wedges.Prize, True)
                            WheelController.prizeStatus = True
                            Prize.Show()
                        End If
                    ElseIf WheelController.currentPlayer = 2 And WheelController.puzzle.Contains(CType(sender, Button).Text) Then
                        If lblCurrentValue.Text = "1/2 Car" And WheelController.halfCar1Status = False Or lblCurrentValue.Text = "1/2 Car" And WheelController.halfCar2Status = False Then
                            If halfcar1.Visible = False And halfcar2.Visible = False Or halfcar2.Visible = True Then
                                player2.addCardsOrWedges(Player.Wedges.HalfCar1, True)
                                WheelController.halfCar1Status = True
                                halfcar1.Show()
                                lblCurrentValue.Text = 0
                                WheelController.spinResult = 0
                                isVowel = False
                            ElseIf halfcar1.Visible = True And halfcar2.Visible = False Then
                                player2.addCardsOrWedges(Player.Wedges.HalfCar2, True)
                                WheelController.halfCar2Status = True
                                halfcar2.Show()
                                lblCurrentValue.Text = 0
                                WheelController.spinResult = 0
                                isVowel = False
                            End If
                        End If
                        If lblCurrentValue.Text = "Million" And WheelController.millionStatus = False Then
                            player2.addCardsOrWedges(Player.Wedges.Million, True)
                            WheelController.millionStatus = True
                            Million.Show()
                        End If
                        If lblCurrentValue.Text = "Wild" And WheelController.wildCardStatus = False Then
                            player2.addCardsOrWedges(Player.Wedges.Wild, True)
                            WheelController.wildCardStatus = True
                            frmPuzzleBoard.btnWild.Show()
                            Wild.Show()
                        End If
                        If lblCurrentValue.Text = "Gift" And WheelController.giftStatus = False Then
                            player2.addCardsOrWedges(Player.Wedges.Gift, True)
                            WheelController.giftStatus = True
                            Gift.Show()
                        End If
                        If lblCurrentValue.Text = "Prize" And WheelController.prizeStatus = False Then
                            player2.addCardsOrWedges(Player.Wedges.Prize, True)
                            WheelController.prizeStatus = True
                            Prize.Show()
                        End If
                    ElseIf WheelController.currentPlayer = 3 And WheelController.puzzle.Contains(CType(sender, Button).Text) Then
                        If lblCurrentValue.Text = "1/2 Car" And WheelController.halfCar1Status = False Or lblCurrentValue.Text = "1/2 Car" And WheelController.halfCar2Status = False Then
                            If halfcar1.Visible = False And halfcar2.Visible = False Or halfcar2.Visible = True Then
                                player3.addCardsOrWedges(Player.Wedges.HalfCar1, True)
                                WheelController.halfCar1Status = True
                                halfcar1.Show()
                                lblCurrentValue.Text = 0
                                WheelController.spinResult = 0
                                isVowel = False
                            ElseIf halfcar1.Visible = True And halfcar2.Visible = False Then
                                player3.addCardsOrWedges(Player.Wedges.HalfCar2, True)
                                WheelController.halfCar2Status = True
                                halfcar2.Show()
                                lblCurrentValue.Text = 0
                                WheelController.spinResult = 0
                                isVowel = False
                            End If
                        End If
                        If lblCurrentValue.Text = "Million" And WheelController.millionStatus = False Then
                            player3.addCardsOrWedges(Player.Wedges.Million, True)
                            WheelController.millionStatus = True
                            Million.Show()
                        End If
                        If lblCurrentValue.Text = "Wild" And WheelController.wildCardStatus = False Then
                            player3.addCardsOrWedges(Player.Wedges.Wild, True)
                            WheelController.wildCardStatus = True
                            frmPuzzleBoard.btnWild.Show()
                            Wild.Show()
                        End If
                        If lblCurrentValue.Text = "Gift" And WheelController.giftStatus = False Then
                            player3.addCardsOrWedges(Player.Wedges.Gift, True)
                            WheelController.giftStatus = True
                            Gift.Show()
                        End If
                        If lblCurrentValue.Text = "Prize" And WheelController.prizeStatus = False Then
                            player3.addCardsOrWedges(Player.Wedges.Prize, True)
                            WheelController.prizeStatus = True
                            Prize.Show()
                        End If
                    End If
                    If Not WheelController.puzzle.Contains(currentLetter) Then
                        If lblCurrentValue.Text <> "Free Play" Then
                            WheelController.LoseATurn()
                            usedLetterBoard.Enabled = True
                        Else
                        End If
                        If WheelController.expressStatus = False Or WheelController.finalSpin = False Then
                            My.Computer.Audio.Play(My.Resources.Buzzer, AudioPlayMode.Background)
                            WheelController.spinResult = 0
                            CType(sender, Button).Enabled = False
                        ElseIf WheelController.expressStatus = True Then
                            WheelController.spinResult = 0
                            WheelController.bankrupt()
                            CType(sender, Button).Enabled = False
                            frmPuzzleBoard.logoExpress.Hide()
                            frmPuzzleBoard.wheelTilt.Enabled = True
                            WheelController.expressStatus = False
                        ElseIf WheelController.finalSpin = True Then
                            My.Computer.Audio.Play(My.Resources.Buzzer, AudioPlayMode.Background)
                            CType(sender, Button).Enabled = False
                        End If
                    End If
                    CType(sender, Button).Enabled = False
                Else
                    frmPuzzleBoard.lblChosenLetters.Text &= " " & CType(sender, Button).Text
                    If WheelController.selectedBonusLetters.Count <= 4 And bonusRoundPlayer.getWedges(Player.Wedges.Wild) = False OrElse WheelController.selectedBonusLetters.Count <= 5 And bonusRoundPlayer.getWedges(Player.Wedges.Wild) = True Then
                        WheelController.selectedBonusLetters.Add(CType(sender, Button).Text)
                        CType(sender, Button).Enabled = False
                    ElseIf WheelController.selectedBonusLetters.Count = 4 And bonusRoundPlayer.getWedges(Player.Wedges.Wild) = False OrElse WheelController.selectedBonusLetters.Count = 5 And bonusRoundPlayer.getWedges(Player.Wedges.Wild) = True Then
                        CType(sender, Button).Enabled = False
                        btnBonusTimerStart.Show()
                    Else
                    End If
                End If
                If WheelController.currentPlayer = 1 Then
                    If CInt(lblPlayer1.Text.Replace("$", "")) >= 250 Or WheelController.finalSpinSpun = True Then
                        enableVowels(True)
                    Else
                        enableVowels(False)
                    End If
                ElseIf WheelController.currentPlayer = 2 Then
                    If CInt(lblPlayer2.Text.Replace("$", "")) >= 250 Or WheelController.finalSpinSpun = True Then
                        enableVowels(True)
                    Else
                        enableVowels(False)
                    End If
                ElseIf WheelController.currentPlayer = 3 Then
                    If CInt(lblPlayer3.Text.Replace("$", "")) >= 250 Or WheelController.finalSpinSpun = True Then
                        enableVowels(True)
                    Else
                        enableVowels(False)
                    End If
                End If
            Dim letterSelected = CType(sender, Button).Text
            puzzleString = puzzleString.Replace(letterSelected, "")
            If WheelController.finalSpin = False Or WheelController.expressStatus = False Then
                    lblCurrentValue.Text = 0
                Else
                End If
                isVowel = False
            End If
    End Sub
    Public Sub enableConsonants(value As Boolean)
        If value = False Then
            btnB.Enabled = False
            btnC.Enabled = False
            btnD.Enabled = False
            btnF.Enabled = False
            btnG.Enabled = False
            btnH.Enabled = False
            btnJ.Enabled = False
            btnK.Enabled = False
            btnL.Enabled = False
            btnM.Enabled = False
            btnN.Enabled = False
            btnP.Enabled = False
            btnQ.Enabled = False
            btnR.Enabled = False
            btnS.Enabled = False
            btnT.Enabled = False
            btnV.Enabled = False
            btnW.Enabled = False
            btnX.Enabled = False
            btnY.Enabled = False
            btnZ.Enabled = False
        Else
            btnB.Enabled = True
            btnC.Enabled = True
            btnD.Enabled = True
            btnF.Enabled = True
            btnG.Enabled = True
            btnH.Enabled = True
            btnJ.Enabled = True
            btnK.Enabled = True
            btnL.Enabled = True
            btnM.Enabled = True
            btnN.Enabled = True
            btnP.Enabled = True
            btnQ.Enabled = True
            btnR.Enabled = True
            btnS.Enabled = True
            btnT.Enabled = True
            btnV.Enabled = True
            btnW.Enabled = True
            btnX.Enabled = True
            btnY.Enabled = True
            btnZ.Enabled = True
        End If
    End Sub
    Private Function GetConsonants(ByVal input As String) As Integer
        Return input.ToLower.Count(Function(c) "qwrtypsdfghjklmnbvcxz".Contains(c))
    End Function
    Private Sub tmrCheckPlayer_Tick(sender As Object, e As EventArgs) Handles tmrCheckPlayer.Tick
        lblControllerSpinResult.Text = WheelController.spinResult
        If lblCurrentValue.Text = "Free Play" Then
            frmPuzzleBoard.btnSolve.Enabled = True
        End If
        If WheelController.currentPlayer = 1 Then
            usedLetterBoard.BackColor = Color.Red
            player1LeftArrow.Show()
            player1RightArrow.Show()
            player2LeftArrow.Hide()
            player2RightArrow.Hide()
            player3LeftArrow.Hide()
            player3RightArrow.Hide()
            If CInt(lblPlayer1.Text.Replace("$", "")) >= 250 And spun = False And noMoreVowelsShown = False Or lblCurrentValue.Text = "Free Play" And noMoreVowelsShown = False Or WheelController.finalSpin = True Then
                enableVowels(True)
            Else
                enableVowels(False)
            End If
            If player1.getWedges(Player.Wedges.HalfCar1) = True Then
                halfcar1.Show()
            ElseIf player1.getWedges(Player.Wedges.HalfCar1) = False Then
                halfcar1.Hide()
            End If
            If player1.getWedges(Player.Wedges.HalfCar2) = True Then
                halfcar2.Show()
            ElseIf player1.getWedges(Player.Wedges.HalfCar2) = False Then
                halfcar2.Hide()
            End If
            If player1.getWedges(Player.Wedges.Million) = True Then
                Million.Show()
            ElseIf player1.getWedges(Player.Wedges.Million) = False Then
                Million.Hide()
            End If
            If player1.getWedges(Player.Wedges.Wild) = True Then
                Wild.Show()
                frmPuzzleBoard.btnWild.Show()
            ElseIf player1.getWedges(Player.Wedges.Wild) = False Then
                Wild.Hide()
                frmPuzzleBoard.btnWild.Hide()
            End If
            If player1.getWedges(Player.Wedges.Gift) = True Then
                Gift.Show()
            ElseIf player1.getWedges(Player.Wedges.Gift) = False Then
                Gift.Hide()
            End If
            If player1.getWedges(Player.Wedges.Prize) = True Then
                Prize.Show()
            ElseIf player1.getWedges(Player.Wedges.Prize) = False Then
                Prize.Hide()
            End If
            If player1.getWedges(Player.Wedges.Mystery) = True Then
                Mystery.Show()
            ElseIf player1.getWedges(Player.Wedges.Mystery) = False Then
                Mystery.Hide()
            End If
        ElseIf WheelController.currentPlayer = 2 Then
            usedLetterBoard.BackColor = Color.Gold
            player1LeftArrow.Hide()
            player1RightArrow.Hide()
            player2LeftArrow.Show()
            player2RightArrow.Show()
            player3LeftArrow.Hide()
            player3RightArrow.Hide()
            If CInt(lblPlayer2.Text.Replace("$", "")) >= 250 And spun = False And noMoreVowelsShown = False Or lblCurrentValue.Text = "Free Play" And noMoreVowelsShown = False Or WheelController.finalSpin = True Then
                enableVowels(True)
            Else
                enableVowels(False)
            End If
            If player2.getWedges(Player.Wedges.HalfCar1) = True Then
                halfcar1.Show()
            ElseIf player2.getWedges(Player.Wedges.HalfCar1) = False Then
                halfcar1.Hide()
            End If
            If player2.getWedges(Player.Wedges.HalfCar2) = True Then
                halfcar2.Show()
            ElseIf player2.getWedges(Player.Wedges.HalfCar2) = False Then
                halfcar2.Hide()
            End If
            If player2.getWedges(Player.Wedges.Million) = True Then
                Million.Show()
            ElseIf player2.getWedges(Player.Wedges.Million) = False Then
                Million.Hide()
            End If
            If player2.getWedges(Player.Wedges.Wild) = True Then
                Wild.Show()
                frmPuzzleBoard.btnWild.Show()
            ElseIf player2.getWedges(Player.Wedges.Wild) = False Then
                Wild.Hide()
                frmPuzzleBoard.btnWild.Hide()
            End If
            If player2.getWedges(Player.Wedges.Gift) = True Then
                Gift.Show()
            ElseIf player2.getWedges(Player.Wedges.Gift) = False Then
                Gift.Hide()
            End If
            If player2.getWedges(Player.Wedges.Prize) = True Then
                Prize.Show()
            ElseIf player2.getWedges(Player.Wedges.Prize) = False Then
                Prize.Hide()
            End If
            If player2.getWedges(Player.Wedges.Mystery) = True Then
                Mystery.Show()
            ElseIf player2.getWedges(Player.Wedges.Mystery) = False Then
                Mystery.Hide()
            End If
        ElseIf WheelController.currentPlayer = 3 Then
            usedLetterBoard.BackColor = Color.FromArgb(0, 45, 192)
            player1LeftArrow.Hide()
            player1RightArrow.Hide()
            player2LeftArrow.Hide()
            player2RightArrow.Hide()
            player3LeftArrow.Show()
            player3RightArrow.Show()
            If CInt(lblPlayer3.Text.Replace("$", "")) >= 250 And spun = False And noMoreVowelsShown = False Or lblCurrentValue.Text = "Free Play" And noMoreVowelsShown = False Or WheelController.finalSpin = True Then
                enableVowels(True)
            Else
                enableVowels(False)
            End If
            If player3.getWedges(Player.Wedges.HalfCar1) = True Then
                halfcar1.Show()
            ElseIf player3.getWedges(Player.Wedges.HalfCar1) = False Then
                halfcar1.Hide()
            End If
            If player3.getWedges(Player.Wedges.HalfCar2) = True Then
                halfcar2.Show()
            ElseIf player3.getWedges(Player.Wedges.HalfCar2) = False Then
                halfcar2.Hide()
            End If
            If player3.getWedges(Player.Wedges.Million) = True Then
                Million.Show()
            ElseIf player3.getWedges(Player.Wedges.Million) = False Then
                Million.Hide()
            End If
            If player3.getWedges(Player.Wedges.Wild) = True Then
                Wild.Show()
                frmPuzzleBoard.btnWild.Show()
            ElseIf player3.getWedges(Player.Wedges.Wild) = False Then
                Wild.Hide()
                frmPuzzleBoard.btnWild.Hide()
            End If
            If player3.getWedges(Player.Wedges.Gift) = True Then
                Gift.Show()
            ElseIf player3.getWedges(Player.Wedges.Gift) = False Then
                Gift.Hide()
            End If
            If player3.getWedges(Player.Wedges.Prize) = True Then
                Prize.Show()
            ElseIf player3.getWedges(Player.Wedges.Prize) = False Then
                Prize.Hide()
            End If
            If player3.getWedges(Player.Wedges.Mystery) = True Then
                Mystery.Show()
            ElseIf player3.getWedges(Player.Wedges.Mystery) = False Then
                Mystery.Hide()
            End If
        Else
            player1LeftArrow.Hide()
            player1RightArrow.Hide()
            player2LeftArrow.Hide()
            player2RightArrow.Hide()
            player3LeftArrow.Hide()
            player3RightArrow.Hide()
        End If
        If WheelController.roundType = WheelController.PuzzleType.BR Then
            If WheelController.selectedBonusLetters.Count = 3 And bonusRoundPlayer.getWedges(Player.Wedges.Wild) = False Then
                enableBonusVowels(True)
            ElseIf WheelController.selectedBonusLetters.Count = 3 And bonusRoundPlayer.getWedges(Player.Wedges.Wild) = True Then
                enableBonusVowels(False)
            ElseIf WheelController.selectedBonusLetters.Count = 4 And bonusRoundPlayer.getWedges(Player.Wedges.Wild) = True Then
                enableBonusVowels(True)
            ElseIf WheelController.selectedBonusLetters.Count < 3 Then
                enableBonusVowels(False)
            ElseIf WheelController.selectedBonusLetters.Count = 4 And bonusRoundPlayer.getWedges(Player.Wedges.Wild) = False Or WheelController.selectedBonusLetters.Count = 5 And bonusRoundPlayer.getWedges(Player.Wedges.Wild) = True Then
                WheelController.loadBonusLetters()
                btnBonusTimerStart.Show()
                WheelController.selectedBonusLetters.Clear()
                enableBonusVowels(False)
            End If
        End If
    End Sub
    Public Sub bonusTimer()
        My.Computer.Audio.Play(My.Resources.clock_new, AudioPlayMode.Background)
        frmPuzzleBoard.tmrBonus.Start()
        'timeStart = DateTime.Now.Second
        'For Each lettersControls As Control In frmPuzzleBoard.Instance.Controls
        '    If lettersControls.GetType() Is GetType(PuzzleBoardLetter) Then
        '        CType(lettersControls, PuzzleBoardLetter).revealLetter()
        '    End If
        'Next
    End Sub

    Private Sub btnBonusTimerStart_Click(sender As Object, e As EventArgs) Handles btnBonusTimerStart.Click
        frmPuzzleBoard.btnSolve.Enabled = True
        frmPuzzleBoard.bonusTimeStart = DateTime.Now.Second
        bonusTimer()
        'tmrBonusTimer.Start()
        'For Each control In frmPuzzleBoard.Controls
        '    If TypeOf (control) Is PuzzleBoardLetter Then
        '        If CType(control, PuzzleBoardLetter).btnLetter.Text = "" Then
        '            WheelController.letterControlList.Add(CType(control, PuzzleBoardLetter).Name.Replace("PuzzleBoardLetter", ""))
        '        End If
        '    End If
        'Next
    End Sub
    Private Sub tmrBonusTimer_Tick(sender As Object, e As EventArgs) Handles tmrBonusTimer.Tick
        If DateTime.Now.Second = WheelController.convertTime(timeStart + 9) Then
            tmrBonusTimer.Stop()
            timeStart = DateTime.Now.Second
            tmrSolveFailed.Start()
        End If
    End Sub
    Public timeStart As Integer
    Private Sub tmrLetterReveal_Tick(sender As Object, e As EventArgs) Handles tmrLetterReveal.Tick
        For my2i As Integer = 1 To WheelController.letterControlList.Count
            If DateTime.Now.Second = WheelController.convertTime(timeStart) Then
                Dim randomNumber = WheelController.GetRandomRegular()
                CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & WheelController.letterControlList(randomNumber)), PuzzleBoardLetter).displayBlueBKG()
                CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & WheelController.letterControlList(randomNumber)), PuzzleBoardLetter).playDing()
                frmPuzzleBoard.ListBox4.Items.Add(randomNumber & CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & WheelController.letterControlList(randomNumber)), PuzzleBoardLetter).letterBehind)
                WheelController.letterControlList.Remove(WheelController.letterControlList(randomNumber))
                timeStart = DateTime.Now.Second
            End If
        Next
        If WheelController.letterControlList.Count = 0 Then
            If frmPuzzleBoard.round = WheelController.PuzzleType.BR And frmPuzzleBoard.lblChosenLetters.Visible = False Then
                My.Computer.Audio.Play(My.Resources.Choose_letters, AudioPlayMode.BackgroundLoop)
                frmPuzzleBoard.lblChosenLetters.Text = ""
                frmPuzzleBoard.lblChosenLetters.Show()
            Else
            End If
            tmrLetterReveal.Stop()
        End If
    End Sub
    Private Sub tmrFinalSpin_Tick(sender As Object, e As EventArgs) Handles tmrFinalSpin.Tick
        If DateTime.Now.Second = WheelController.convertTime(timeStart + 3) And WheelController.finalSpin = True Then
            tmrFinalSpin.Stop()
            WheelController.LoseATurn()
            My.Computer.Audio.Play(My.Resources.Buzzer, AudioPlayMode.Background)
            usedLetterBoard.Enabled = True
        End If
    End Sub
    Private Sub tmrSolveFailed_Tick(sender As Object, e As EventArgs) Handles tmrSolveFailed.Tick
        For my2i As Integer = 1 To WheelController.letterControlList.Count
            If DateTime.Now.Second = WheelController.convertTime(timeStart) Then
                Dim randomNumber = WheelController.GetRandomRegular()
                CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & WheelController.letterControlList(randomNumber)), PuzzleBoardLetter).revealLetter()
                frmPuzzleBoard.ListBox4.Items.Add(randomNumber & CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & WheelController.letterControlList(randomNumber)), PuzzleBoardLetter).letterBehind)
                WheelController.letterControlList.Remove(WheelController.letterControlList(randomNumber))
                timeStart = DateTime.Now.Second
            End If
        Next
        If WheelController.letterControlList.Count = 0 Then
            tmrSolveFailed.Stop()
        End If
    End Sub

    Private Sub tmrCheckVowels_Tick(sender As Object, e As EventArgs) Handles tmrCheckVowels.Tick
        If WheelController.letterControlList.Count = 0 Then
            If Not puzzleString.Contains("A") And Not puzzleString.Contains("E") And Not puzzleString.Contains("I") And Not puzzleString.Contains("O") And Not puzzleString.Contains("U") Then
                If noMoreVowelsShown = False Then
                    frmPuzzleBoard.noMoreVowels.Show()
                    My.Computer.Audio.Play(My.Resources.snd_no_more_vowels, AudioPlayMode.Background)
                    noMoreVowelsShown = True
                    enableVowels(False)
                    tmrCheckVowels.Stop()
                Else
                End If
            ElseIf GetConsonants(puzzleString) = 0 Then
                If noMoreConsonantsShown = False Then
                    My.Computer.Audio.Play(My.Resources.snd_vowels_only, AudioPlayMode.Background)
                    enableConsonants(False)
                    frmPuzzleBoard.wheelTilt.Enabled = False
                    tmrCheckVowels.Stop()
                    frmPuzzleBoard.btnWild.Enabled = False
                Else
                End If
            End If
        End If
    End Sub

    Private Sub btnLoseATurn_Click(sender As Object, e As EventArgs) Handles btnLoseATurn.Click
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

    Private Sub lblPlayer2_DoubleClick(sender As Object, e As EventArgs) Handles lblPlayer2.DoubleClick
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

    Private Sub lblPlayer1_DoubleClick(sender As Object, e As EventArgs) Handles lblPlayer1.DoubleClick
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
        player1Score = CInt(lblPlayer1.Text.Replace("$", ""))
    End Sub
    Private Sub lblPlayer2_TextChanged(sender As Object, e As EventArgs) Handles lblPlayer2.TextChanged
        player2Score = CInt(lblPlayer2.Text.Replace("$", ""))
    End Sub
    Private Sub lblPlayer3_TextChanged(sender As Object, e As EventArgs) Handles lblPlayer3.TextChanged
        player3Score = CInt(lblPlayer3.Text.Replace("$", ""))
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
        frmHelp.ShowDialog()
    End Sub

    'Public flashTimeStart As Integer
    'Private Sub tmrCurrentPlayerFlash_Tick(sender As Object, e As EventArgs) Handles tmrCurrentPlayerFlash.Tick
    'frmPuzzleBoard.lblWMPTime.Text = DateTime.Now.Second & "," & WheelController.letterControlList.Count
    '    '& "," & timeStart - 1
    '    If DateTime.Now.Second = WheelController.convertTime(flashTimeStart + 2) Then
    '        If WheelController.currentPlayer = 1 Then
    '            If player1LeftArrow.Visible = True Then
    '                player1LeftArrow.Hide()
    '                player1RightArrow.Hide()
    '            ElseIf player1LeftArrow.Visible = False Then
    '                player1LeftArrow.Show()
    '                player1RightArrow.Show()
    '            End If
    '        ElseIf WheelController.currentPlayer = 2 Then
    '            If player2LeftArrow.Visible = True Then
    '                player2LeftArrow.Hide()
    '                player2RightArrow.Hide()
    '            ElseIf player2LeftArrow.Visible = False Then
    '                player2LeftArrow.Show()
    '                player2RightArrow.Show()
    '            End If
    '        ElseIf WheelController.currentPlayer = 3 Then
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
