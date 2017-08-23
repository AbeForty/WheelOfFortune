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
        wmpWheel.Ctlcontrols.currentPosition = trkWheel.Value - 1
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
        If frmPuzzleBoard.round <> WheelController.PuzzleType.BR Then
            If spinTimer < spinStrength Then
                If spinTimer = spinStrength - (0.25 * spinStrength) Then
                    If frmPuzzleBoard.round = WheelController.PuzzleType.R1 Then
                        wmpWheel.URL = Application.StartupPath & "\Resources\WheelZoomR1.mp4"
                    ElseIf frmPuzzleBoard.round = WheelController.PuzzleType.R2 Then
                        wmpWheel.URL = Application.StartupPath & "\Resources\WheelZoomR2.mp4"
                    ElseIf frmPuzzleBoard.round = WheelController.PuzzleType.R3 Then
                        wmpWheel.URL = Application.StartupPath & "\Resources\WheelZoomR3.mp4"
                    ElseIf frmPuzzleBoard.round = WheelController.PuzzleType.BR Then
                    Else
                        wmpWheel.URL = Application.StartupPath & "\Resources\WheelZoomR4.mp4"
                    End If
                End If
                spinTimer += 1
                trkWheel.Value += 1
            Else
                spinTimer = spinStrength
                spinPaused = False
                wmpWheel.Ctlcontrols.pause()
                tmrSpinTest.Stop()
                If WheelController.finalSpin = False Then
                    If WheelController.wheelWedges.Item(trkWheel.Value) = "Bankrupt" Then
                        WheelController.bankrupt()
                    ElseIf WheelController.wheelWedges.Item(trkWheel.Value) = "Lose a Turn" Then
                        WheelController.LoseATurn()
                    ElseIf WheelController.wheelWedges.Item(trkWheel.Value) = "Mystery 1" Or WheelController.wheelWedges.Item(trkWheel.Value) = "Mystery 2" Then
                        'mystery2Box.Image = My.Resources.Mystery_2014
                        'mystery2Box.Show()
                        If WheelController.mysteryStatus = False Then
                            My.Computer.Audio.Play(My.Resources.snd_mystery_wedge, AudioPlayMode.Background)
                        ElseIf WheelController.mysteryStatus = True Then
                            WheelController.spinResult = 1000
                        End If
                    ElseIf WheelController.wheelWedges.Item(trkWheel.Value) = "Million" Then
                        WheelController.spinResult = 500
                        'mystery2Box.Image = My.Resources.MDW_Front
                        'mystery2Box.Show()
                    ElseIf WheelController.wheelWedges.Item(trkWheel.Value) = "Free Play" Then
                        WheelController.spinResult = 500
                    ElseIf WheelController.wheelWedges.Item(trkWheel.Value) = "Express" Then
                        My.Computer.Audio.Play(My.Resources.snd_express, AudioPlayMode.Background)
                        WheelController.spinResult = 1000
                    ElseIf WheelController.wheelWedges.Item(trkWheel.Value) = "1/2 Car" Then
                        My.Computer.Audio.Play(My.Resources.halfcar, AudioPlayMode.Background)
                        WheelController.spinResult = 500
                        'halfCar2Box.Show()
                    ElseIf WheelController.wheelWedges.Item(trkWheel.Value) = "Wild" Then
                        WheelController.spinResult = 500&
                    ElseIf WheelController.wheelWedges.Item(trkWheel.Value) = "Prize" Then
                        WheelController.spinResult = 500
                        'mystery2Box.Image = My.Resources.Prize
                        'mystery2Box.Show()
                    ElseIf WheelController.wheelWedges.Item(trkWheel.Value) = "Gift" Then
                        WheelController.spinResult = 500
                        'giftTagBox.Show()
                    Else
                        WheelController.spinResult = WheelController.wheelWedges.Item(trkWheel.Value)
                        spinResult = WheelController.wheelWedges.Item(trkWheel.Value)
                    End If
                    spinResult = WheelController.wheelWedges.Item(trkWheel.Value)
                    frmScore.lblCurrentValue.Text = spinResult
                    If WheelController.wheelWedges.Item(trkWheel.Value) = "1/2 Car" Then
                        If trkWheel.Value = 7 Or trkWheel.Value = 8 Or trkWheel.Value = 9 Then
                            If WheelController.halfCar1Status = True Then
                                WheelController.wheelWedges(7) = "500"
                                WheelController.wheelWedges(8) = "500"
                                WheelController.wheelWedges(9) = "500"
                            Else
                                'halfCar2Box.Show()
                            End If
                        ElseIf trkWheel.Value = 37 Or trkWheel.Value = 38 Or trkWheel.Value = 39 Then
                            If WheelController.halfCar2Status = True Then
                                WheelController.wheelWedges(37) = "500"
                                WheelController.wheelWedges(38) = "500"
                                WheelController.wheelWedges(39) = "500"
                            Else
                                'halfCar2Box.Show()
                            End If
                        End If
                    ElseIf WheelController.wheelWedges.Item(trkWheel.Value) = "Gift" Then
                        If trkWheel.Value = 52 Or trkWheel.Value = 53 Or trkWheel.Value = 54 Then
                            If WheelController.giftStatus = True Then
                                WheelController.wheelWedges(52) = "500"
                                WheelController.wheelWedges(53) = "500"
                                WheelController.wheelWedges(54) = "500"
                            Else
                                'halfCar2Box.Show()
                            End If
                        End If
                    ElseIf WheelController.wheelWedges.Item(trkWheel.Value) = "Prize" Then
                        If trkWheel.Value = 13 Or trkWheel.Value = 14 Or trkWheel.Value = 15 Then
                            If WheelController.prizeStatus = True Then
                                WheelController.wheelWedges(13) = "500"
                                WheelController.wheelWedges(14) = "500"
                                WheelController.wheelWedges(15) = "500"
                            Else
                                'halfCar2Box.Show()
                            End If
                        End If
                    ElseIf WheelController.wheelWedges.Item(trkWheel.Value) = "Million" Then
                        If trkWheel.Value = 47 Then
                            If WheelController.millionStatus = True Then
                                WheelController.wheelWedges(46) = "500"
                                WheelController.wheelWedges(47) = "500"
                                WheelController.wheelWedges(48) = "500"
                            Else
                                'halfCar2Box.Show()
                            End If

                        End If
                    ElseIf WheelController.wheelWedges.Item(trkWheel.Value) = "WIld" Then
                        If trkWheel.Value = 67 Or trkWheel.Value = 68 Or trkWheel.Value = 69 Then
                            If WheelController.wildCardStatus = True Then
                                WheelController.wheelWedges(67) = "500"
                                WheelController.wheelWedges(68) = "500"
                                WheelController.wheelWedges(69) = "500"
                            Else
                                'halfCar2Box.Show()
                            End If
                        End If
                    End If
                ElseIf WheelController.finalSpin = True Then
                    If WheelController.wheelWedges.Item(trkWheel.Value) = "Bankrupt" Or WheelController.wheelWedges.Item(trkWheel.Value) = "Lose a Turn" Or WheelController.wheelWedges.Item(trkWheel.Value) = "Free Play" Then
                        Spin()
                    Else
                        WheelController.finalSpinSpun = True
                        spinResult = WheelController.wheelWedges.Item(trkWheel.Value) + 1000
                        WheelController.spinResult = spinResult
                        frmScore.lblCurrentValue.Text = spinResult
                        frmPuzzleBoard.wheelTilt.Enabled = False
                    End If
                End If
            End If
        ElseIf frmPuzzleBoard.round = WheelController.PuzzleType.BR Then
            If spinTimer < spinStrength Then
                spinTimer += 1
                trkBonusWheel.Value += 1
            Else
                spinTimer = spinStrength
                spinPaused = False
                wmpWheel.Ctlcontrols.pause()
                If WheelController.wheelWedges.Item(trkBonusWheel.Value) <> "Car" Then
                    WheelController.spinResult = WheelController.wheelWedges.Item(trkBonusWheel.Value)
                    spinResult = WheelController.wheelWedges.Item(trkBonusWheel.Value)
                Else
                    WheelController.spinResult = 25000
                    spinResult = 25000
                End If
                frmScore.lblCurrentValue.Text = spinResult
                tmrSpinTest.Stop()
            End If
            frmPuzzleBoard.wheelTilt.Enabled = False
        End If
    End Sub
    Private Sub btnStopSpin_Click(sender As Object, e As EventArgs)
        stopSpin()
    End Sub
    Public Sub stopSpin()
        If frmPuzzleBoard.round <> WheelController.PuzzleType.BR Then
            spinStrength = pbarWheel.Value * 4
        Else
            spinStrength = pbarWheel.Value * 2
        End If
        spinWheel(spinStrength)
        tmrSpinner.Stop()
        pbarWheel.Hide()
        btnStopSpin.Hide()
        wheelCover.Hide()
        wmpWheel.Ctlcontrols.play()
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
        frmPuzzleBoard.wheelTilt.Enabled = False
        WheelController.previousValue = ""
        If firstSpin = True Then
            wheelCover.Show()
            firstSpin = False
        Else
        End If
        spinPaused = True
        frmScore.spun = True
        wmpWheel.Show()
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
        If pbarWheel.Visible = True Then
            stopSpin()
        Else
            Me.Hide()
            frmScore.Show()
            If frmPuzzleBoard.round = WheelController.PuzzleType.R1 Then
                wmpWheel.URL = Application.StartupPath & "\Resources\WheelSpinR1.mp4"
            ElseIf frmPuzzleBoard.round = WheelController.PuzzleType.R2 Then
                wmpWheel.URL = Application.StartupPath & "\Resources\WheelSpinR2.mp4"
            ElseIf frmPuzzleBoard.round = WheelController.PuzzleType.R3 Then
                wmpWheel.URL = Application.StartupPath & "\Resources\WheelSpinR3.mp4"
            ElseIf frmPuzzleBoard.round = WheelController.PuzzleType.BR Then

            Else
                wmpWheel.URL = Application.StartupPath & "\Resources\WheelSpinR4.mp4"
            End If
            wmpWheel.Ctlcontrols.pause()
        End If
    End Sub

    Private Sub WheelSpinControl_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible = True Then
            WheelController.previousValue = ""
            wheelCover.Hide()
            If firstSpin = True Then
                wmpWheel.Ctlcontrols.stop()
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
End Class
