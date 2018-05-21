Imports System.ComponentModel
<DefaultEvent("Click")>
Public Class WheelSpinControl
    Dim wheelTypeEnum As WheelType
    Dim SpinStart As Boolean = False
    Dim spinTimer As Integer
    Dim spinStrength As Integer
    Dim spinResult As String
    Dim spinPaused As Boolean = True
    Public firstSpin As Boolean = True
    Dim SAPI
    Enum WheelType
        R1
        R2
        R3
        R4
        BR
    End Enum
    Private Sub spinWheel(length As Integer)
        My.Computer.Audio.Play(My.Resources.wheelspinlong, AudioPlayMode.Background)
        tmrSpinTest.Start()
    End Sub
    Private Sub trkWheel_ValueChanged(sender As Object, e As EventArgs) Handles trkWheel.ValueChanged
        'If wmpWheel.URL = Application.StartupPath & "\Resources\WheelZoomR1.mp4" Or wmpWheel.URL = Application.StartupPath & "\Resources\WheelZoomR2.mp4" Or wmpWheel.URL = Application.StartupPath & "\Resources\WheelZoomR3.mp4" Or wmpWheel.URL = Application.StartupPath & "\Resources\WheelZoomR4.mp4" Then
        '    wmpWheel.Ctlcontrols.currentPosition = trkWheel.Value
        'Else
        wmpWheel.Ctlcontrols.currentPosition = trkWheel.Value
        lblWMPTime.Text = spinStrength & "/" & spinTimer & "/" & trkWheel.Value & "/" & wmpWheel.Ctlcontrols.currentPosition & "/" & (spinStrength - (0.25 * spinStrength))
        lblRandomNumber.Text = tmrSpinTest.Interval
        'End If
        If trkWheel.Value = trkWheel.Maximum Then
            trkWheel.Value = 0
        End If
    End Sub
    Private Sub trkBonusWheel_ValueChanged(sender As Object, e As EventArgs) Handles trkBonusWheel.ValueChanged
        wmpWheel.Ctlcontrols.currentPosition = trkBonusWheel.Value
        If trkBonusWheel.Value = trkBonusWheel.Maximum Then
            trkBonusWheel.Value = 0
        End If
    End Sub

    Private Sub tmrSpinTest_Tick(sender As Object, e As EventArgs) Handles tmrSpinTest.Tick
        If WheelController.round <> WheelController.PuzzleType.BR Then
            If spinTimer < spinStrength Then
                'If spinTimer = spinStrength - (0.25 * spinStrength) Then
                '    If WheelController.round = WheelController.PuzzleType.R1 Then
                '        wmpWheel.URL = Application.StartupPath & "\Resources\WheelZoomR1.mp4"
                '    ElseIf WheelController.round = WheelController.PuzzleType.R2 Then
                '        wmpWheel.URL = Application.StartupPath & "\Resources\WheelZoomR2.mp4"
                '    ElseIf WheelController.round = WheelController.PuzzleType.R3 Then
                '        wmpWheel.URL = Application.StartupPath & "\Resources\WheelZoomR3.mp4"
                '    ElseIf WheelController.round = WheelController.PuzzleType.BR Then
                '    Else
                '        wmpWheel.URL = Application.StartupPath & "\Resources\WheelZoomR4.mp4"
                '    End If
                'End If
                If spinTimer = spinStrength - (0.25 * spinStrength) Then
                    tmrSpinTest.Interval = 300
                End If
                'If spinTimer = spinStrength - 25 Then
                '    tmrSpinTest.Interval = 300
                'End If
                spinTimer += 1
                trkWheel.Value += 1
            Else
                firstSpin = False
                frmScore.usedLetterBoard.Enabled = True
                'If spinTimer = spinStrength - 1 Then
                'wmpWheel.Ctlcontrols.pause()
                'Else
                'End If
                spinTimer = spinStrength
                spinPaused = False
                tmrSpinTest.Stop()
                wmpWheel.Ctlcontrols.pause()
                If WheelController.finalSpin = False Then
                    If WheelController.wheelWedges.Item(trkWheel.Value) = "Bankrupt" Then
                        WheelController.bankrupt()
                    ElseIf WheelController.wheelWedges.Item(trkWheel.Value) = "Lose a Turn" Then
                        WheelController.isNoLetters = False
                        WheelController.LoseATurn()
                    ElseIf WheelController.wheelWedges.Item(trkWheel.Value) = "Mystery 1" Or WheelController.wheelWedges.Item(trkWheel.Value) = "Mystery 2" Then
                        If WheelController.mysteryStatus = False Then
                            My.Computer.Audio.Play(My.Resources.snd_mystery_wedge, AudioPlayMode.Background)
                            WheelController.spinResult = 1000
                        ElseIf WheelController.mysteryStatus = True Then
                            WheelController.spinResult = 1000
                        End If
                    ElseIf WheelController.wheelWedges.Item(trkWheel.Value) = "Million" Then
                        WheelController.spinResult = 500
                    ElseIf WheelController.wheelWedges.Item(trkWheel.Value) = "Free Play" Then
                        WheelController.spinResult = 500
                    ElseIf WheelController.wheelWedges.Item(trkWheel.Value) = "Express" Then
                        My.Computer.Audio.Play(My.Resources.snd_express, AudioPlayMode.Background)
                        WheelController.spinResult = 1000
                    ElseIf WheelController.wheelWedges.Item(trkWheel.Value) = "1/2 Car" Then
                        My.Computer.Audio.Play(My.Resources.halfcar, AudioPlayMode.Background)
                        WheelController.spinResult = 500
                    ElseIf WheelController.wheelWedges.Item(trkWheel.Value) = "Wild" Then
                        WheelController.spinResult = 500
                    ElseIf WheelController.wheelWedges.Item(trkWheel.Value) = "Prize" Then
                        WheelController.spinResult = 500
                    ElseIf WheelController.wheelWedges.Item(trkWheel.Value) = "Gift" Then
                        WheelController.spinResult = 500
                    Else
                        spinResult = WheelController.wheelWedges.Item(trkWheel.Value)
                        WheelController.spinResult = WheelController.wheelWedges.Item(trkWheel.Value)
                    End If
                    spinResult = WheelController.wheelWedges.Item(trkWheel.Value)
                    frmScore.lblCurrentValue.Text = spinResult
                    If WheelController.previousValue <> "Lose A Turn" And WheelController.previousValue <> "Bankrupt" Then
                        readDollarAmount()
                    End If
                ElseIf WheelController.finalSpin = True Then
                    If Not IsNumeric(WheelController.wheelWedges.Item(trkWheel.Value)) Then
                        Spin()
                    Else
                        WheelController.finalSpinSpun = True
                        spinResult = WheelController.wheelWedges.Item(trkWheel.Value) + 1000
                        WheelController.spinResult = spinResult
                        frmScore.lblCurrentValue.Text = WheelController.spinResult
                        frmPuzzleBoard.wheelTilt.Enabled = False
                        readDollarAmount()
                        frmAudio.Show()
                        frmAudio.playSpeedUp(True)
                    End If
                End If
            End If
        ElseIf WheelController.round = WheelController.PuzzleType.BR Then
            If spinTimer < spinStrength Then
                spinTimer += 1
                trkBonusWheel.Value += 1
                If spinTimer = spinStrength - (0.25 * spinStrength) Then
                    tmrSpinTest.Interval = 300
                End If
            Else
                spinTimer = spinStrength
                spinPaused = False
                wmpWheel.Ctlcontrols.pause()
                If WheelController.wheelWedges.Item(trkBonusWheel.Value) <> "Car" Then
                    WheelController.spinResult = WheelController.wheelWedges.Item(trkBonusWheel.Value)
                    WheelController.spinResult = WheelController.wheelWedges.Item(trkBonusWheel.Value)
                Else
                    WheelController.spinResult = 25000
                    WheelController.spinResult = 25000
                End If
                frmScore.lblCurrentValue.Text = WheelController.spinResult
                WheelController.disableRSTLNE()
                frmPuzzleBoard.PuzzleBoard1.Enabled = True
                tmrSpinTest.Stop()
            End If
            frmPuzzleBoard.wheelTilt.Enabled = False
        End If
        'End If
    End Sub
    Private Sub btnStopSpin_Click(sender As Object, e As EventArgs)
        stopSpin()
    End Sub
    Public Sub stopSpin()
        If WheelController.round <> WheelController.PuzzleType.BR Then
            spinStrength = pbarWheel.Value * 2
        Else
            spinStrength = pbarWheel.Value * 1.5
        End If
        spinWheel(spinStrength)
        tmrSpinner.Stop()
        pbarWheel.Hide()
        btnStopSpin.Hide()
        wheelCover.Hide()
        wmpWheel.Ctlcontrols.play()
        tmrSpinTest.Interval = 1
    End Sub
    Private Sub tmrSpinner_Tick(sender As Object, e As EventArgs) Handles tmrSpinner.Tick
        If SpinStart = False Then
            pbarWheel.Increment(10)
            If pbarWheel.Value = 100 Then
                SpinStart = True
            End If
        ElseIf SpinStart = True Then
            pbarWheel.Increment(-10)
            If pbarWheel.Value = 0 Then
                SpinStart = False
            End If
        End If
    End Sub
    Public Sub Spin()
        Me.Show()
        frmScore.usedLetterBoard.Enabled = False
        frmPuzzleBoard.wheelTilt.Enabled = False
        WheelController.previousValue = ""
        If firstSpin = True Then
            'wheelCover.Show()
        Else
            'wheelCover.Hide()
        End If
        spinPaused = True
        WheelController.spun = True
        wmpWheel.Show()
        wmpWheel.Ctlcontrols.pause()
        pbarWheel.Show()
        spinTimer = 0
        If pbarWheel.Value = 0 Then
            SpinStart = False
            tmrSpinner.Start()
        Else
            SpinStart = False
            pbarWheel.Value = 0
            tmrSpinner.Start()
        End If
    End Sub

    Private Sub wmpWheel_ClickEvent(sender As Object, e As AxWMPLib._WMPOCXEvents_ClickEvent) Handles wmpWheel.ClickEvent
        startSpin()
    End Sub
    Private Sub startSpin()
        If pbarWheel.Visible = True Then
            stopSpin()
        Else
            Me.Hide()
            frmScore.Show()
            dlgPuzzleBoard.Close()
            If WheelController.round = WheelController.PuzzleType.R1 And WheelController.millionStatus = True Then
                wmpWheel.URL = Application.StartupPath & "\Resources\WheelZoomR1.mp4"
            ElseIf WheelController.round = WheelController.PuzzleType.R1 And WheelController.millionStatus = False Then
                wmpWheel.URL = Application.StartupPath & "\Resources\WheelZoomR1Million.mp4"
            ElseIf WheelController.round = WheelController.PuzzleType.R2 And WheelController.millionStatus = True Then
                wmpWheel.URL = Application.StartupPath & "\Resources\WheelZoomR2.mp4"
            ElseIf WheelController.round = WheelController.PuzzleType.R2 And WheelController.millionStatus = False Then
                wmpWheel.URL = Application.StartupPath & "\Resources\WheelZoomR2Million.mp4"
            ElseIf WheelController.round = WheelController.PuzzleType.R3 And WheelController.millionStatus = True Then
                wmpWheel.URL = Application.StartupPath & "\Resources\WheelZoomR3.mp4"
            ElseIf WheelController.round = WheelController.PuzzleType.R3 And WheelController.millionStatus = False Then
                wmpWheel.URL = Application.StartupPath & "\Resources\WheelZoomR3Million.mp4"
            ElseIf WheelController.round = WheelController.PuzzleType.BR Then
                wmpWheel.URL = Application.StartupPath & "\Resources\WheelSpinBonus.mp4"
            Else
                wmpWheel.URL = Application.StartupPath & "\Resources\WheelZoomR4.mp4"
            End If
        End If
    End Sub
    Private Sub WheelSpinControl_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible = True Then
            dlgPuzzleBoard.Show()
            WheelController.previousValue = ""
            wheelCover.Hide()
            If firstSpin = True Then
                'wmpWheel.Ctlcontrols.stop()
                wmpWheel.Ctlcontrols.currentPosition = 0
                wmpWheel.Ctlcontrols.pause()
                firstSpin = False
            End If
            If WheelController.round = WheelController.PuzzleType.BR Then
                firstSpin = True
                If WheelController.bonusPuzzleRevealed = False Then
                    If WheelController.virtualHost = True Then
                        Dim SAPI
                        SAPI = CreateObject("SAPI.spvoice")
                        If WheelController.bonusRoundPlayer.getWedges(Player.Wedges.Million) = False Then
                            SAPI.Speak(CType(frmScore.Controls("NameTag" & WheelController.currentPlayer), NameTag).lblName.Text & " Go ahead and spin the wheel.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                        Else
                            SAPI.Speak(CType(frmScore.Controls("NameTag" & WheelController.currentPlayer), NameTag).lblName.Text & " Because you have this million dollar wedge, we replaced the 100,000 dollar envelope with the million dollars. Go ahead and spin the wheel.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                        End If
                    End If
                    wmpWheel.Ctlcontrols.currentPosition = 0
                    wmpWheel.Ctlcontrols.pause()
                    firstSpin = False
                Else
                    If WheelController.bonusRoundPlayer.getWedges(Player.Wedges.Million) = True Then
                        If WheelController.virtualHost = True Then
                            Dim SAPI
                            SAPI = CreateObject("SAPI.spvoice")
                            SAPI.Speak("Here is the location of the million dollar envelope.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                        End If
                    End If
                End If
            End If
            If WheelController.finalSpin = True Then
                If WheelController.virtualHost = True Then
                    Dim SAPI
                    SAPI = CreateObject("SAPI.spvoice")
                    SAPI.Speak("I'm going to give the wheel a final spin. Ask you to give me a letter. If it is in the puzzle you have three seconds to solve it. Vowels worth nothing. Consonants will be worth 1000 plus whatever I land on.")
                End If
            End If
            frmScore.Hide()
            Spin()
        Else

        End If
    End Sub

    Private Sub wheelCover_Click(sender As Object, e As EventArgs) Handles wheelCover.Click
        stopSpin()
    End Sub

    Private Sub tmrFinalSpinDisable_Tick(sender As Object, e As EventArgs) Handles tmrFinalSpinDisable.Tick
        If WheelController.finalSpinSpun = True Then
            frmPuzzleBoard.wheelTilt.Enabled = False
        End If
    End Sub

    Private Sub WheelSpinControl_Load(sender As Object, e As EventArgs) Handles Me.Load
        tmrFinalSpinDisable.Start()
    End Sub
    Public Sub resetWheel()
        trkWheel.Value = 0
    End Sub
    Private Sub readDollarAmount()
        If WheelController.finalSpin = False And Not WheelController.round = WheelController.PuzzleType.BR Then
            Try
                Integer.Parse(spinResult)
                If spinResult < 2500 Then
                    If spinResult.Contains("50") And spinResult <> "500" Then
                        If WheelController.virtualHost = True Then
                            SAPI = CreateObject("SAPI.spvoice")
                            SAPI.Speak(spinResult.Chars(0) & " ,50", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                        End If
                    Else
                        If WheelController.virtualHost = True Then
                            SAPI = CreateObject("SAPI.spvoice")
                            SAPI.Speak(spinResult, SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                        End If
                    End If
                Else
                    If WheelController.virtualHost = True Then
                        SAPI = CreateObject("SAPI.spvoice")
                        SAPI.Speak("A chance to score big here. All right. Let's have a letter.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                    End If
                End If
            Catch ex As Exception
                If spinResult.Contains("Mystery") And WheelController.mysteryStatus = False Or spinResult = "Express" Then
                    If WheelController.virtualHost = True Then
                        Dim SAPI
                        SAPI = CreateObject("SAPI.spvoice")
                        SAPI.Speak("All right. Let's have a letter.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                    End If
                ElseIf spinResult.Contains("Mystery") And WheelController.mysteryStatus = True Then
                    If WheelController.virtualHost = True Then
                        Dim SAPI
                        SAPI = CreateObject("SAPI.spvoice")
                        SAPI.Speak("That's just a $1,000 space now.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                    End If
                Else
                End If
            End Try
        Else
            Integer.Parse(spinResult)
            If spinResult - 1000 < 2500 Then
                If (spinResult - 1000).ToString.Contains("50") And (spinResult - 1000).ToString <> "500" Then
                    If WheelController.virtualHost = True Then
                        SAPI = CreateObject("SAPI.spvoice")
                        SAPI.Speak(spinResult.Chars(0) & " ,50", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                    End If
                Else
                    If WheelController.virtualHost = True Then
                        SAPI = CreateObject("SAPI.spvoice")
                        SAPI.Speak(spinResult - 1000, SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                    End If
                End If
                If WheelController.virtualHost = True Then
                    SAPI.Speak("All right. " & (spinResult) & "for every consonant we find. Remember vowels are worth nothing and the category is " & WheelController.category, SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                    SAPI.Speak(CType(frmScore.Controls("NameTag" & WheelController.currentPlayer), NameTag).lblName.Text & " Give me a letter.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                End If
            Else
                If WheelController.virtualHost = True Then
                    SAPI = CreateObject("SAPI.spvoice")
                    SAPI.Speak("A chance for someone to score big. All right. " & "$" & (spinResult) & "for every consonant we find. Remember vowels are worth nothing. Don't forget, the category is " & WheelController.category, SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                End If
            End If
        End If
    End Sub

    Private Sub WheelSpinControl_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = ChrW(Keys.Space) Then
            startSpin()
        End If
    End Sub
End Class
