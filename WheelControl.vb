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
        wmpWheel.Ctlcontrols.currentPosition = trkWheel.Value
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
                If spinTimer = spinStrength - 15 Then
                tmrSpinTest.Interval = 300
            End If

            spinTimer += 1
            trkWheel.Value += 1
        Else
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
                        WheelController.spinResult = 500&
                    ElseIf WheelController.wheelWedges.Item(trkWheel.Value) = "Prize" Then
                        WheelController.spinResult = 500
                    ElseIf WheelController.wheelWedges.Item(trkWheel.Value) = "Gift" Then
                        WheelController.spinResult = 500
                    Else
                        WheelController.spinResult = WheelController.wheelWedges.Item(trkWheel.Value)
                        spinResult = WheelController.wheelWedges.Item(trkWheel.Value)
                    End If
                    spinResult = WheelController.wheelWedges.Item(trkWheel.Value)
                    frmScore.lblCurrentValue.Text = spinResult
                ElseIf WheelController.finalSpin = True Then
                    If Not IsNumeric(WheelController.wheelWedges.Item(trkWheel.Value)) Then
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
                frmScore.disableRSTLNE()
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
        If frmPuzzleBoard.round <> WheelController.PuzzleType.BR Then
            spinStrength = pbarWheel.Value * 4
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
            wheelCover.Show()
            firstSpin = False
        Else
        End If
        spinPaused = True
        frmScore.spun = True
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
