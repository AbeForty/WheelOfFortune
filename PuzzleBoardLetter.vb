Imports System.ComponentModel
<DefaultEvent("Click")>
Public Class PuzzleBoardLetter
    Dim letter As String
    Public letterRevealed As Boolean = False
    Dim isTossUpButton As Boolean = False
    Public Property letterBehind As String
        Get
            Return letter
        End Get
        Set(value As String)
            letter = value
        End Set
    End Property
    Public Property tossUpStatus As Boolean
        Get
            Return isTossUpButton
        End Get
        Set(value As Boolean)
            isTossUpButton = value
        End Set
    End Property
    Public Sub displayBlueBKG()
        btnLetter.BackColor = SystemColors.HotTrack
    End Sub
    Public Sub playDing()
        My.Computer.Audio.Play(My.Resources.Ding, AudioPlayMode.Background)
    End Sub
    Public Sub revealLetter()
        'MsgBox("Hello " & letter)
        letterRevealed = True
        btnLetter.Text = letter
        btnLetter.ForeColor = Color.Black
        btnLetter.BackColor = Color.White
    End Sub
    Private Sub btnLetter_Click(sender As Object, e As EventArgs) Handles btnLetter.Click
        'MsgBox(Me.Name)
        'playDing()
        'revealLetter()
        If btnLetter.BackColor = SystemColors.HotTrack Then
            revealLetter()
            WheelController.letterControlTappedList.Remove(Name.Replace("PuzzleBoardLetter", ""))
            If WheelController.letterControlTappedList.Count = 0 Then
                'If WheelController.finalSpin = True Then
                'Else
                frmScore.usedLetterBoard.Enabled = True
                'End If
                If WheelController.finalSpinSpun = True Then
                    frmScore.timeStart = DateTime.Now.Second
                    frmScore.tmrFinalSpin.Start()
                End If
            End If
            If WheelController.roundType = WheelController.PuzzleType.BR Then
                frmScore.numberOfUntappedLetters -= 1
            End If
        ElseIf frmPuzzleBoard.round = WheelController.PuzzleType.TU1 And isTossUpButton = True Or frmPuzzleBoard.round = WheelController.PuzzleType.TU2 And isTossUpButton = True Or frmPuzzleBoard.round = WheelController.PuzzleType.TU3 And isTossUpButton = True Or frmPuzzleBoard.round = WheelController.PuzzleType.TBTU And isTossUpButton = True Then
            If frmPuzzleBoard.round = WheelController.PuzzleType.TU1 Then
                WheelController.startTime = DateTime.Now.Minute
                frmPuzzleBoard.tmrCheckFinalSpin.Start()
            End If
            '    frmPuzzleBoard.btnRedRingIn.Show()
            'frmPuzzleBoard.btnYellowRingIn.Show()
            'frmPuzzleBoard.btnBlueRingIn.Show()
            frmPuzzleBoard.tmrTossUpRingIn.Start()
            If WheelController.tossUpStarted = False Then
                playDing()
                revealLetter()
                WheelController.startTossUp()
                WheelController.tossUpStarted = True
            Else
            End If
        End If
    End Sub
End Class
