Public Class frmScore

    Private Sub frmScore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NameTag1.contestantName = WheelController.player1Name
        NameTag2.contestantName = WheelController.player2Name
        NameTag3.contestantName = WheelController.player3Name
        If WheelController.numberOfPlayers = 3 Then
            NameTag1.Show()
            NameTag2.Show()
            NameTag3.Show()
        ElseIf WheelController.numberOfPlayers = 2 Then
            NameTag1.Show()
            NameTag2.Show()
            NameTag3.Hide()
        Else
            NameTag1.Show()
            NameTag2.Hide()
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
        ElseIf ((e.KeyChar <> ChrW(Keys.Space)) And Char.IsLetter(e.KeyChar.ToString)) Then
            WheelController.backspace = False
            If usedLetterBoard.Controls("btn" & e.KeyChar.ToString).Enabled = True Then
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
        'If wheelWedges.Item(frmPuzzleBoard.WheelSpinControl1.trkWheel.Value) = "1/2 Car" Then
        'If frmPuzzleBoard.WheelSpinControl1.trkWheel.Value = 7 Or frmPuzzleBoard.WheelSpinControl1.trkWheel.Value = 8 Or frmPuzzleBoard.WheelSpinControl1.trkWheel.Value = 9 Then
        '        If halfCar1Status = True Then
        '            wheelWedges(7) = "500"
        '            wheelWedges(8) = "500"
        '            wheelWedges(9) = "500"
        '        Else
        '        End If
        '    ElseIf frmPuzzleBoard.WheelSpinControl1.trkWheel.Value = 37 Or frmPuzzleBoard.WheelSpinControl1.trkWheel.Value = 38 Or frmPuzzleBoard.WheelSpinControl1.trkWheel.Value = 39 Then
        '        If halfCar2Status = True Then
        '            wheelWedges(37) = "500"
        '            wheelWedges(38) = "500"
        '            wheelWedges(39) = "500"
        '        Else
        '        End If
        '    End If
        'ElseIf wheelWedges.Item(frmPuzzleBoard.WheelSpinControl1.trkWheel.Value) = "Gift" Then
        '    If frmPuzzleBoard.WheelSpinControl1.trkWheel.Value = 52 Or frmPuzzleBoard.WheelSpinControl1.trkWheel.Value = 53 Or frmPuzzleBoard.WheelSpinControl1.trkWheel.Value = 54 Then
        '        If giftStatus = True Then
        '            wheelWedges(52) = "500"
        '            wheelWedges(53) = "500"
        '            wheelWedges(54) = "500"
        '        Else
        '        End If
        '    End If
        'ElseIf wheelWedges.Item(frmPuzzleBoard.WheelSpinControl1.trkWheel.Value) = "Prize" Then
        '    If frmPuzzleBoard.WheelSpinControl1.trkWheel.Value = 13 Or frmPuzzleBoard.WheelSpinControl1.trkWheel.Value = 14 Or frmPuzzleBoard.WheelSpinControl1.trkWheel.Value = 15 Then
        '        If prizeStatus = True Then
        '            wheelWedges(13) = "500"
        '            wheelWedges(14) = "500"
        '            wheelWedges(15) = "500"
        '        Else
        '        End If
        '    End If
        'ElseIf wheelWedges.Item(frmPuzzleBoard.WheelSpinControl1.trkWheel.Value) = "Million" Then
        '    If frmPuzzleBoard.WheelSpinControl1.trkWheel.Value = 47 Then
        '        If millionStatus = True Then
        '            wheelWedges(46) = "500"
        '            wheelWedges(47) = "500"
        '            wheelWedges(48) = "500"
        '        Else
        '        End If

        '    End If
        'ElseIf wheelWedges.Item(frmPuzzleBoard.WheelSpinControl1.trkWheel.Value) = "Wild" Then
        '    If frmPuzzleBoard.WheelSpinControl1.trkWheel.Value = 67 Or frmPuzzleBoard.WheelSpinControl1.trkWheel.Value = 68 Or frmPuzzleBoard.WheelSpinControl1.trkWheel.Value = 69 Then
        '        If wildCardStatus = True Then
        '            wheelWedges(67) = "500"
        '            wheelWedges(68) = "500"
        '            wheelWedges(69) = "500"
        '        Else
        '        End If
        '    End If
        'End If

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
        'timeStart = DateTime.Now.Second
        'For Each lettersControls As Control In frmPuzzleBoard.Instance.Controls
        '    If lettersControls.GetType() Is GetType(PuzzleBoardLetter) Then
        '        CType(lettersControls, PuzzleBoardLetter).revealLetter()
        '    End If
        'Next
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
            tmrSolveFailed.Start()
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
            My.Computer.Audio.Play(My.Resources.Buzzer, AudioPlayMode.Background)
            usedLetterBoard.Enabled = True
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
            WheelController.player1Score = CInt(lblPlayer1.Text.Replace("$", ""))
        Else
            WheelController.player1Score = 0
        End If
    End Sub
    Private Sub lblPlayer2_TextChanged(sender As Object, e As EventArgs) Handles lblPlayer2.TextChanged
        If lblPlayer2.Text <> "" Then
            WheelController.player2Score = CInt(lblPlayer2.Text.Replace("$", ""))
        Else
            WheelController.player2Score = 0
        End If
    End Sub
    Private Sub lblPlayer3_TextChanged(sender As Object, e As EventArgs) Handles lblPlayer3.TextChanged
        If lblPlayer3.Text <> "" Then
            WheelController.player3Score = CInt(lblPlayer3.Text.Replace("$", ""))
        Else
            WheelController.player3Score = 0
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
