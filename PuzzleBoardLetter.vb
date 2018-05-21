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
        btnLetter.BackColor = Color.FromArgb(19, 28, 255)
    End Sub
    Public Sub playDing()
        My.Computer.Audio.Play(My.Resources.Ding, AudioPlayMode.Background)
    End Sub
    Public Sub revealLetter()
        'MsgBox("Hello " & letter)
        letterRevealed = True
        If letter = "A" Then
            btnLetter.BackgroundImage = My.Resources.a
        ElseIf letter = "B" Then
            btnLetter.BackgroundImage = My.Resources.b
        ElseIf letter = "C" Then
            btnLetter.BackgroundImage = My.Resources.c
        ElseIf letter = "D" Then
            btnLetter.BackgroundImage = My.Resources.d
        ElseIf letter = "E" Then
            btnLetter.BackgroundImage = My.Resources.e
        ElseIf letter = "F" Then
            btnLetter.BackgroundImage = My.Resources.f
        ElseIf letter = "G" Then
            btnLetter.BackgroundImage = My.Resources.g
        ElseIf letter = "H" Then
            btnLetter.BackgroundImage = My.Resources.h
        ElseIf letter = "I" Then
            btnLetter.BackgroundImage = My.Resources.i
        ElseIf letter = "J" Then
            btnLetter.BackgroundImage = My.Resources.j
        ElseIf letter = "K" Then
            btnLetter.BackgroundImage = My.Resources.k
        ElseIf letter = "L" Then
            btnLetter.BackgroundImage = My.Resources.l
        ElseIf letter = "M" Then
            btnLetter.BackgroundImage = My.Resources.m
        ElseIf letter = "N" Then
            btnLetter.BackgroundImage = My.Resources.n
        ElseIf letter = "O" Then
            btnLetter.BackgroundImage = My.Resources.o
        ElseIf letter = "P" Then
            btnLetter.BackgroundImage = My.Resources.p
        ElseIf letter = "Q" Then
            btnLetter.BackgroundImage = My.Resources.q
        ElseIf letter = "R" Then
            btnLetter.BackgroundImage = My.Resources.r
        ElseIf letter = "S" Then
            btnLetter.BackgroundImage = My.Resources.s
        ElseIf letter = "T" Then
            btnLetter.BackgroundImage = My.Resources.t
        ElseIf letter = "U" Then
            btnLetter.BackgroundImage = My.Resources.u
        ElseIf letter = "V" Then
            btnLetter.BackgroundImage = My.Resources.v
        ElseIf letter = "W" Then
            btnLetter.BackgroundImage = My.Resources.w
        ElseIf letter = "X" Then
            btnLetter.BackgroundImage = My.Resources.x
        ElseIf letter = "Y" Then
            btnLetter.BackgroundImage = My.Resources.y
        ElseIf letter = "Z" Then
            btnLetter.BackgroundImage = My.Resources.z
        ElseIf letter = "'" Then
            btnLetter.BackgroundImage = My.Resources.apos
        ElseIf letter = "." Then
            btnLetter.BackgroundImage = My.Resources.period
        ElseIf letter = "!" Then
            btnLetter.BackgroundImage = My.Resources.exclaim
        ElseIf letter = "-" Then
            btnLetter.BackgroundImage = My.Resources.dash
        ElseIf letter = "&" Then
            btnLetter.BackgroundImage = My.Resources._and
        ElseIf letter = ":" Then
            btnLetter.BackgroundImage = My.Resources.colon
        ElseIf letter = ";" Then
            btnLetter.BackgroundImage = My.Resources.semicolon
        ElseIf letter = "?" Then
            btnLetter.BackgroundImage = My.Resources.question
        ElseIf letter = " " Then
            btnLetter.BackgroundImage = Nothing
        End If
        If letter <> " " Then
            btnLetter.ForeColor = Color.Black
            btnLetter.BackColor = Color.White
        Else
            btnLetter.BackColor = Color.Transparent
            BackColor = Color.Transparent
        End If
    End Sub
    Public Sub revealLetter(letter)
        'MsgBox("Hello " & letter)
        If letter = "A" Then
            btnLetter.BackgroundImage = My.Resources.a
        ElseIf letter = "B" Then
            btnLetter.BackgroundImage = My.Resources.b
        ElseIf letter = "C" Then
            btnLetter.BackgroundImage = My.Resources.c
        ElseIf letter = "D" Then
            btnLetter.BackgroundImage = My.Resources.d
        ElseIf letter = "E" Then
            btnLetter.BackgroundImage = My.Resources.e
        ElseIf letter = "F" Then
            btnLetter.BackgroundImage = My.Resources.f
        ElseIf letter = "G" Then
            btnLetter.BackgroundImage = My.Resources.g
        ElseIf letter = "H" Then
            btnLetter.BackgroundImage = My.Resources.h
        ElseIf letter = "I" Then
            btnLetter.BackgroundImage = My.Resources.i
        ElseIf letter = "J" Then
            btnLetter.BackgroundImage = My.Resources.j
        ElseIf letter = "K" Then
            btnLetter.BackgroundImage = My.Resources.k
        ElseIf letter = "L" Then
            btnLetter.BackgroundImage = My.Resources.l
        ElseIf letter = "M" Then
            btnLetter.BackgroundImage = My.Resources.m
        ElseIf letter = "N" Then
            btnLetter.BackgroundImage = My.Resources.n
        ElseIf letter = "O" Then
            btnLetter.BackgroundImage = My.Resources.o
        ElseIf letter = "P" Then
            btnLetter.BackgroundImage = My.Resources.p
        ElseIf letter = "Q" Then
            btnLetter.BackgroundImage = My.Resources.q
        ElseIf letter = "R" Then
            btnLetter.BackgroundImage = My.Resources.r
        ElseIf letter = "S" Then
            btnLetter.BackgroundImage = My.Resources.s
        ElseIf letter = "T" Then
            btnLetter.BackgroundImage = My.Resources.t
        ElseIf letter = "U" Then
            btnLetter.BackgroundImage = My.Resources.u
        ElseIf letter = "V" Then
            btnLetter.BackgroundImage = My.Resources.v
        ElseIf letter = "W" Then
            btnLetter.BackgroundImage = My.Resources.w
        ElseIf letter = "X" Then
            btnLetter.BackgroundImage = My.Resources.x
        ElseIf letter = "Y" Then
            btnLetter.BackgroundImage = My.Resources.y
        ElseIf letter = "Z" Then
            btnLetter.BackgroundImage = My.Resources.z
        End If
    End Sub
    Private Sub btnLetter_Click(sender As Object, e As EventArgs) Handles btnLetter.Click
        letterClick()
    End Sub
    Private Sub letterClick()
        retroLetter.Image = My.Resources.PremiereLetterTurn
        retroLetter.Hide()
        'MsgBox(Me.Name)
        'playDing()
        'revealLetter()
        If WheelController.solveMode = True And letterRevealed = False Then
            For Each puzzleLetter As PuzzleBoardLetter In CType(Parent, PuzzleBoard).Controls
                puzzleLetter.btnLetter.BackColor = Color.White
            Next
            btnLetter.BackColor = Color.FromArgb(19, 28, 255)
            WheelController.currentSolveLetter = Name.Replace("PuzzleBoardLetter", "")
        End If
        If btnLetter.BackColor = Color.FromArgb(19, 28, 255) And Not WheelController.solveMode = True Then
            revealLetter()
            WheelController.letterControlTappedList.Remove(Name.Replace("PuzzleBoardLetter", ""))
            If WheelController.letterControlTappedList.Count = 0 Then
                'If finalSpin = True Then
                'Else
                frmScore.usedLetterBoard.Enabled = True
                'End If
                If WheelController.finalSpinSpun = True Then
                    WheelController.timeStart = DateTime.Now.Second
                    frmScore.tmrFinalSpin.Start()
                End If
            End If

        ElseIf WheelController.round = WheelController.PuzzleType.TU1 And isTossUpButton = True Or WheelController.round = WheelController.PuzzleType.TU2 And isTossUpButton = True Or WheelController.round = WheelController.PuzzleType.TU3 And isTossUpButton = True Or WheelController.round = WheelController.PuzzleType.TBTU And isTossUpButton = True Then
            If WheelController.round = WheelController.PuzzleType.TU1 Then
                WheelController.startTime = DateTime.Now.Minute
                frmPuzzleBoard.tmrCheckFinalSpin.Start()
            End If
            frmPuzzleBoard.btnRedRingIn.Enabled = True
            frmPuzzleBoard.btnYellowRingIn.Enabled = True
            frmPuzzleBoard.btnBlueRingIn.Enabled = True
            WheelController.player1RingIn = False
            WheelController.player2RingIn = False
            WheelController.player3RingIn = False
            frmPuzzleBoard.tmrTossUpRingIn.Start()
            If WheelController.tossUpStarted = False And WheelController.tossUpIntroComplete = True Then
                playDing()
                revealLetter()
                WheelController.startTossUp()
                WheelController.tossUpStarted = True
                WheelController.solveTypedList.Remove(Name.Replace("PuzzleBoardLetter", ""))
                If WheelController.typeToSolve = False Then
                    frmPuzzleBoard.btnSolve.Enabled = True
                End If
            Else
            End If
        ElseIf TypeOf (Parent) Is CrosswordPuzzleBoard Then
            Dim finalString = ""
            If LetterTypeControl.ShowDialog() = DialogResult.OK Then
                letterBehind = LetterTypeControl.currentLetter
                letter = LetterTypeControl.currentLetter
                revealLetter()
                CType(Parent, CrosswordPuzzleBoard).puzzleLetterLocationList(Name.Replace("PuzzleBoardLetter", "")) = LetterTypeControl.currentLetter
                'btnLetter.BackColor = Color.White
            End If
            For Each letterGroup As KeyValuePair(Of Integer, String) In CType(Parent, CrosswordPuzzleBoard).puzzleLetterLocationList
                If letterGroup.Value <> " " And letterGroup.Value <> "" And letterGroup.Value <> Nothing Then
                    'MsgBox("Key: " & letterGroup.Key & " Value: " & letterGroup.Value)
                    finalString &= (letterGroup.Value & letterGroup.Key & " ")
                End If
            Next
            'MsgBox(finalString)
            frmCustomizer.txtPuzzle.Text = finalString
        End If
    End Sub

    Private Sub retroLetter_Click(sender As Object, e As EventArgs) Handles retroLetter.Click
        letterClick()
    End Sub

    Private Sub PuzzleBoardLetter_Load(sender As Object, e As EventArgs) Handles Me.Load
        If WheelController.boardStyleEnum = WheelController.boardStyle.Modern Then
            retroLetter.Hide()
        ElseIf WheelController.boardStyleEnum = WheelController.boardStyle.Classic Then
            retroLetter.Show()
        End If
    End Sub
End Class
