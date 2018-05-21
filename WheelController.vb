Imports System.Data.SqlClient
'Imports SpeechLib
Imports System.IO
Imports System.Reflection
Public MustInherit Class WheelController
#Region "Load Instance Variables"
    Public Shared wheelWedges As New SortedList(Of Integer, String)
    Public Shared category As String
    Public Shared puzzle As String
    Private Shared puzzleTypeInt As Integer
    Public Shared currentPlayer As Integer
    Public Shared spinResult As Integer
    Public Shared aEnabled As Boolean = True
    Public Shared eEnabled As Boolean = True
    Public Shared iEnabled As Boolean = True
    Public Shared oEnabled As Boolean = True
    Public Shared uEnabled As Boolean = True
    Public Shared wildCardStatus As Boolean = False
    Public Shared millionStatus As Boolean = False
    Public Shared prizeStatus As Boolean = False
    Public Shared giftStatus As Boolean = False
    Public Shared halfCar1Status As Boolean = False
    Public Shared halfCar2Status As Boolean = False
    Public Shared carAwarded As Boolean = False
    Public Shared mysteryStatus As Boolean = False
    Public Shared expressStatus As Boolean = False
    Public Shared mystery2value As Boolean
    Public Shared mysteryReveal As Boolean
    Private Shared tossUpLetters As New SortedList(Of Integer, String)
    Public Shared tossUpLetterList As New List(Of String)
    Public Shared tossUpLetterControlList As New List(Of Integer)
    Public Shared selectedBonusLetters As New List(Of String)
    Public Shared tossUpStarted As Boolean = False
    Private Shared keyNumber As New List(Of Integer)
    Public Shared currentPuzzleBoardLetter As String
    Public Shared roundType As New PuzzleType
    Private Shared tossUpRandom As New Random
    Public Shared letterControlList As New List(Of Integer)
    Private Shared letterControlSortedList1 As New SortedList(Of Integer, String)
    Private Shared letterControlSortedList2 As New SortedList(Of Integer, String)
    Private Shared letterControlSortedList3 As New SortedList(Of Integer, String)
    Private Shared letterControlSortedList4 As New SortedList(Of Integer, String)
    Public Shared letterControlTappedList As New List(Of Integer)
    Public Shared bonusCategoriesList As New List(Of String)
    Public Shared bonusCategoriesListPrelim As New List(Of String)
    Public Shared previousValue As String
    Public Shared player1Name As String = "PLAYER 1"
    Public Shared player2Name As String = "PLAYER 2"
    Public Shared player3Name As String = "PLAYER 3"
    Public Shared packName As String = ""
    Public Shared startTime As Integer
    Public Shared timeLeft As Integer = 15
    Public Shared finalSpin As Boolean = False
    Public Shared finalSpinQueued As Boolean = False
    Public Shared numberOfPlayers As Integer = 3
    Public Shared teams As Boolean = False
    Public Shared finalSpinSpun As Boolean = False
    Public Shared bonusSolved As Boolean = True
    Public Shared sameLetter As String
    Public Shared numberOfTurns As Integer = 10
    Public Shared crosswordStatus As Integer
    Public Shared puzzleLoaded As Boolean = False
    Public Shared moneyValue As Integer
    Public Shared currentLetter As String
    Public Shared turnTaken As Boolean = False
    Public Shared spun As Boolean = False
    Private Shared isVowel As Boolean = False
    Public Shared wildUsed As Boolean = False
    Public Shared timeStart As Integer
    Public Shared player1 As New Player
    Public Shared player2 As New Player
    Public Shared player3 As New Player
    Public Shared bonusRoundPlayer As Player
    Public Shared puzzleString As String
    Public Shared noMoreVowelsShown As Boolean = False
    Public Shared noMoreConsonantsShown As Boolean = False
    Public Shared prizePuzzleStatus As Boolean = False
    Public Shared player1Score As Integer
    Public Shared player2Score As Integer
    Public Shared player3Score As Integer
    'Private Shared bonusSolved As Boolean = True
    Public Shared round As New PuzzleType
    Public Shared revealed As Boolean = False
    Private Shared bonusRevealed As Boolean = False
    Private Shared bonusRSTLNERevealed As Boolean = False
    Public Shared previewMode As Boolean = False
    Public Shared player1RingIn As Boolean = False
    Public Shared player2RingIn As Boolean = False
    Public Shared player3RingIn As Boolean = False
    Public Shared allRungIn As Boolean = False
    Public Shared puzzleSolved = False
    Public Shared tossUpRevealTimeStart As Integer
    Public Shared boardStyleEnum As boardStyle = boardStyle.Modern
    Public Shared puzzleBoardName = "PuzzleBoard1"
    Public Shared bonusPuzzleRevealed As Boolean = False
    Public Shared currentPlayerObject As Player
    Public Shared puzzleMode As wheelMode
    Public Shared categoryListPrelim As New List(Of clsPuzzle)
    Public Shared categoryList As New List(Of clsPuzzle)
    Private Shared bonusVowelsEnabled = False
    Private Shared vowelModeEnabled = False
    Private Shared lettersSelected = False
    Public Shared isNoLetters = False
    Private Shared houseMinimumMet As Boolean = False
    Private Shared puzzleSolver As Integer
    Private Shared SAPI As SpeechLib.SpVoice
    Private Shared selectedVowel As String = ""
    Public Shared virtualHost = False
    Private Shared trillonOffset = 0
    Private Shared trillonPreset = 0
    Public Shared previewPlay = False
    Public Shared pauseMenuLoaded = False
    Public Shared solveMode = False
    Public Shared solveAttempt As String = ""
    Public Shared currentSolveLetter As Integer = 0
    Public Shared currentSolveIndex As Integer = 0
    Public Shared previousSolveLetter As Integer = 0
    Private Shared lastLetter As Integer = 0
    Private Shared solveSortedList As New SortedList(Of Integer, String)
    Public Shared solveTypedList As New List(Of Integer)
    Public Shared typeToSolve As Boolean = False
    Public Shared backspace As Boolean = False
    Public Shared gameID As Integer = 0
    Private Shared letterList As New List(Of String)
    Private Shared letterSortedList As New SortedList(Of String, Integer)
    Public Shared fromGameLoad As Boolean = False
    Public Shared solved = False
    Public Shared tossUpIntroComplete = False
#End Region
    Public Enum PuzzleType
        TU1
        TU2
        R1
        R2
        R3
        TU3
        R4
        R5
        R6
        R7
        R8
        R9
        TBTU
        BR
    End Enum
    Public Enum boardStyle
        Modern
        Classic
    End Enum
    Public Enum wheelMode
        Classic
        Disney
        Random
    End Enum
#Region "Reset Players"
    Public Shared Sub resetPlayers()
        frmScore.lblPlayer1.Text = ""
        frmScore.lblPlayer2.Text = ""
        frmScore.lblPlayer3.Text = ""
        player1.total = 0
        player2.total = 0
        player3.total = 0
    End Sub
#End Region
#Region "Check for Symbols"
    Public Shared Function checkForSymbols(letter As String) As Boolean
        If letter = "'" Or letter = "?" Or letter = "." Or letter = "!" Or letter = "-" Or letter = "/" Or letter = ":" Or letter = "\" Or letter = "&" Then
            Return True
        Else
            Return False
        End If
    End Function
#End Region
#Region "Load Wheel Spin Video"
    Private Shared Sub loadWheel(round As PuzzleType)
        If round = PuzzleType.TU1 Then
            If millionStatus = True Then
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelZoomR1.mp4"
            Else
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelZoomR1Million.mp4"
            End If
            frmPuzzleBoard.wheelTilt.Image = My.Resources.WheelTiltedSmall
            frmPuzzleBoard.WheelSpinControl1.wheelCover.BackgroundImage = My.Resources.wheelCoverHD
            frmPuzzleBoard.WheelSpinControl1.resetWheel()
            frmPuzzleBoard.WheelSpinControl1.firstSpin = True
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.stop()
        ElseIf round = PuzzleType.TU2 Then
            If millionStatus = True Then
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelZoomR1.mp4"
            Else
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelZoomR1Million.mp4"
            End If
            frmPuzzleBoard.wheelTilt.Image = My.Resources.WheelTiltedSmall
            frmPuzzleBoard.WheelSpinControl1.wheelCover.BackgroundImage = My.Resources.wheelCoverHD
            frmPuzzleBoard.WheelSpinControl1.resetWheel()
            frmPuzzleBoard.WheelSpinControl1.firstSpin = True
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.stop()
        ElseIf round = PuzzleType.R1 Then
            If millionStatus = True Then
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelZoomR1.mp4"
            Else
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelZoomR1Million.mp4"
            End If
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.currentPosition = 1
            frmPuzzleBoard.wheelTilt.Image = My.Resources.WheelTiltedSmall
            frmPuzzleBoard.WheelSpinControl1.wheelCover.BackgroundImage = My.Resources.wheelCoverHD
            frmPuzzleBoard.WheelSpinControl1.resetWheel()
            frmPuzzleBoard.WheelSpinControl1.firstSpin = True
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.pause()
        ElseIf round = PuzzleType.R2 Then
            If millionStatus = True Then
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelZoomR2.mp4"
            Else
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelZoomR2Million.mp4"
            End If
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.currentPosition = 1
            frmPuzzleBoard.wheelTilt.Image = My.Resources.WheelTiltedSmallR2
            frmPuzzleBoard.WheelSpinControl1.wheelCover.BackgroundImage = My.Resources.wheelCoverHDR2
            frmPuzzleBoard.WheelSpinControl1.resetWheel()
            frmPuzzleBoard.WheelSpinControl1.firstSpin = True
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.pause()
        ElseIf round = PuzzleType.R3 Then
            If millionStatus = True Then
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelZoomR3.mp4"
            Else
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelZoomR3Million.mp4"
            End If
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.currentPosition = 1
            frmPuzzleBoard.wheelTilt.Image = My.Resources.WheelTiltedSmallR3
            frmPuzzleBoard.WheelSpinControl1.wheelCover.BackgroundImage = My.Resources.wheelCoverHDR3
            frmPuzzleBoard.WheelSpinControl1.resetWheel()
            frmPuzzleBoard.WheelSpinControl1.firstSpin = True
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.pause()
        ElseIf round = PuzzleType.TU3 Then
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelZoomR4.mp4"
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.currentPosition = 1
            frmPuzzleBoard.wheelTilt.Image = My.Resources.WheelTiltedSmallR4
            frmPuzzleBoard.WheelSpinControl1.wheelCover.BackgroundImage = My.Resources.wheelCoverHDR4
            frmPuzzleBoard.WheelSpinControl1.resetWheel()
            frmPuzzleBoard.WheelSpinControl1.firstSpin = True
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.pause()
        ElseIf round = PuzzleType.R4 Then
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelZoomR4.mp4"
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.currentPosition = 1
            frmPuzzleBoard.wheelTilt.Image = My.Resources.WheelTiltedSmallR4
            frmPuzzleBoard.WheelSpinControl1.wheelCover.BackgroundImage = My.Resources.wheelCoverHDR4
            frmPuzzleBoard.WheelSpinControl1.resetWheel()
            frmPuzzleBoard.WheelSpinControl1.firstSpin = True
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.pause()
        ElseIf round = PuzzleType.R5 Then
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelZoomR4.mp4"
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.currentPosition = 1
            frmPuzzleBoard.wheelTilt.Image = My.Resources.WheelTiltedSmallR4
            frmPuzzleBoard.WheelSpinControl1.wheelCover.BackgroundImage = My.Resources.wheelCoverHDR4
            frmPuzzleBoard.WheelSpinControl1.resetWheel()
            frmPuzzleBoard.WheelSpinControl1.firstSpin = True
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.pause()
        ElseIf round = PuzzleType.R6 Then
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelZoomR4.mp4"
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.currentPosition = 1
            frmPuzzleBoard.wheelTilt.Image = My.Resources.WheelTiltedSmallR4
            frmPuzzleBoard.WheelSpinControl1.wheelCover.BackgroundImage = My.Resources.wheelCoverHDR4
            frmPuzzleBoard.WheelSpinControl1.resetWheel()
            frmPuzzleBoard.WheelSpinControl1.firstSpin = True
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.pause()
        ElseIf round = PuzzleType.R7 Then
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelZoomR4.mp4"
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.currentPosition = 1
            frmPuzzleBoard.wheelTilt.Image = My.Resources.WheelTiltedSmallR4
            frmPuzzleBoard.WheelSpinControl1.wheelCover.BackgroundImage = My.Resources.wheelCoverHDR4
            frmPuzzleBoard.WheelSpinControl1.resetWheel()
            frmPuzzleBoard.WheelSpinControl1.firstSpin = True
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.pause()
        ElseIf round = PuzzleType.R8 Then
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelZoomR4.mp4"
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.currentPosition = 1
            frmPuzzleBoard.wheelTilt.Image = My.Resources.WheelTiltedSmallR4
            frmPuzzleBoard.WheelSpinControl1.wheelCover.BackgroundImage = My.Resources.wheelCoverHDR4
            frmPuzzleBoard.WheelSpinControl1.resetWheel()
            frmPuzzleBoard.WheelSpinControl1.firstSpin = True
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.pause()
        ElseIf round = PuzzleType.R9 Then
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelZoomR4.mp4"
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.currentPosition = 1
            frmPuzzleBoard.wheelTilt.Image = My.Resources.WheelTiltedSmallR4
            frmPuzzleBoard.WheelSpinControl1.wheelCover.BackgroundImage = My.Resources.wheelCoverHDR4
            frmPuzzleBoard.WheelSpinControl1.resetWheel()
            frmPuzzleBoard.WheelSpinControl1.firstSpin = True
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.pause()
        ElseIf round = PuzzleType.TBTU Then
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelZoomR4.mp4"
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.currentPosition = 1
            frmPuzzleBoard.wheelTilt.Image = My.Resources.WheelTiltedSmallR4
            frmPuzzleBoard.WheelSpinControl1.wheelCover.BackgroundImage = My.Resources.wheelCoverHDR4
            frmPuzzleBoard.WheelSpinControl1.resetWheel()
            frmPuzzleBoard.WheelSpinControl1.firstSpin = True
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.pause()
        ElseIf round = PuzzleType.BR Then
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources\WheelSpinBonus.mp4"
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.currentPosition = 1
            frmPuzzleBoard.wheelTilt.Image = My.Resources.WheelTiltedSmallBonusCards
            frmPuzzleBoard.WheelSpinControl1.wheelCover.BackgroundImage = My.Resources.BonusWheel
            frmPuzzleBoard.WheelSpinControl1.resetWheel()
            frmPuzzleBoard.WheelSpinControl1.firstSpin = True
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.pause()
        End If
    End Sub
#End Region
#Region "Check Vowels"
    Public Shared Sub checkVowels()
        If letterControlList.Count = 0 Then
            If Not puzzleString.Contains("A") And Not puzzleString.Contains("E") And Not puzzleString.Contains("I") And Not puzzleString.Contains("O") And Not puzzleString.Contains("U") Then
                If noMoreVowelsShown = False Then
                    frmPuzzleBoard.noMoreVowels.Show()
                    My.Computer.Audio.Play(My.Resources.snd_no_more_vowels, AudioPlayMode.Background)
                    noMoreVowelsShown = True
                    enableVowels(False)
                    frmScore.tmrCheckVowels.Stop()
                    If virtualHost = True Then
                        Dim vowelMessage = GetRandomPlayer(0, 4)
                        If vowelMessage = 0 Then

                            SAPI.Speak("The vowels, they are gone.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                        ElseIf vowelMessage = 1 Then

                            SAPI.Speak("That's it for the vowels.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                        ElseIf vowelMessage = 2 Then

                            SAPI.Speak("No more vowels.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                        Else

                            SAPI.Speak("That's the last of the vowels.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                        End If

                    Else
                    End If
                End If
            ElseIf GetConsonants(puzzleString) = 0 Then
                If noMoreConsonantsShown = False Then
                    My.Computer.Audio.Play(My.Resources.snd_vowels_only, AudioPlayMode.Background)
                    enableConsonants(False)
                    frmPuzzleBoard.wheelTilt.Enabled = False
                    frmScore.tmrCheckVowels.Stop()
                    frmPuzzleBoard.btnWild.Enabled = False
                    If virtualHost = True Then
                        SAPI.Speak("The rest of the letters are vowels.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                    End If
                Else
                End If
            End If
        End If
    End Sub
#End Region
#Region "Load Bonus Categories"
    Public Shared Sub loadBonusCategories(mode As wheelMode)
        Dim connPuzzle As SqlConnection
        connPuzzle = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" & Application.StartupPath & "\WheelPuzzles.mdf;Integrated Security=True")
        Dim strSQL
        roundType = round
        round = PuzzleType.BR
        If mode = wheelMode.Classic Then
            strSQL = "Select * From Puzzle WHERE Type = 2 and RoundNumber =1 and PackName =  @PackName"
        ElseIf mode = wheelMode.Disney Then
            strSQL = "Select * From Puzzle WHERE LEN(puzzle) <=28 and PackName =  'Disney Wheel of Fortune'"
        ElseIf mode = wheelMode.Random Then
            strSQL = "Select * From Puzzle WHERE Type = 2 and RoundNumber =1"
        End If
        Dim drProduct As SqlDataReader
        Dim cmdProduct As SqlCommand
        Dim packNameParam As SqlParameter = New SqlParameter("@PackName", packName)
        connPuzzle.Open()
        cmdProduct = New SqlCommand(strSQL, connPuzzle)
        If mode = wheelMode.Classic Then
            cmdProduct.Parameters.Add(packNameParam)
        Else
        End If
        drProduct = cmdProduct.ExecuteReader(CommandBehavior.CloseConnection)
        While drProduct.Read()
            bonusCategoriesListPrelim.Add(Trim(drProduct("Category")))
            If mode = wheelMode.Disney Then
                Dim myPuzzle As New clsPuzzle
                myPuzzle.category = Trim(drProduct("Category"))
                myPuzzle.puzzle = Trim(drProduct("Puzzle"))
                myPuzzle.puzzleTypeInt = CInt(Trim(drProduct("Type")))
                myPuzzle.crosswordStatus = CInt(Trim(drProduct("Crossword")))
                categoryListPrelim.Add(myPuzzle)
            End If
        End While
        If mode = wheelMode.Classic Then
            For Each item In bonusCategoriesListPrelim
                bonusCategoriesList.Add(item)
            Next
        ElseIf mode = wheelMode.Disney Or mode = wheelMode.Random Then
            Dim randomCatNumbers As New List(Of Integer)
            For randomCatList As Integer = 1 To bonusCategoriesListPrelim.Count
                randomCatNumbers.Add(randomCatList)
            Next
            If mode = wheelMode.Disney Then
                For i As Integer = 1 To 3
                    Dim newPuzzle = (categoryListPrelim(getRandomIndex(randomCatNumbers)))
                    Dim newPuzzleList = categoryList.Where(Function(p) p.category = newPuzzle.category)
                    Do Until newPuzzleList.Count = 0
                        newPuzzle = (categoryListPrelim(getRandomIndex(randomCatNumbers)))
                    Loop
                    If newPuzzleList.Count = 0 Then
                        categoryList.Add(newPuzzle)
                    End If
                Next
            ElseIf mode = wheelMode.Random Then
                For i As Integer = 1 To 3
                    bonusCategoriesList.Add(bonusCategoriesListPrelim(getRandomIndex(randomCatNumbers)))
                Next
            End If
        End If
    End Sub
#End Region
#Region "Get Random Index"
    Public Shared Function getRandomIndex(ByRef passedList As List(Of Integer)) As Integer
        Return GetRandomPlayer(1, passedList.Count)
    End Function
#End Region
#Region "Load Puzzle"
    Public Shared Sub loadPuzzle(round As PuzzleType, mode As wheelMode, preview As Boolean)
        frmScore.lblPlayer1.Text = ""
        frmScore.lblPlayer2.Text = ""
        frmScore.lblPlayer3.Text = ""
        solveMode = False
        solveAttempt = ""
        solveSortedList.Clear()
        lastLetter = 0
        'solveSortedList.Clear()
        'solveTypedList.Clear()
        If (round = PuzzleType.TU1 Or round = PuzzleType.TU2 Or round = PuzzleType.TU3 Or round = PuzzleType.TBTU) And preview = False Then
            If virtualHost = True Then
                tossUpIntroComplete = False
            Else
                tossUpIntroComplete = True
            End If
            If numberOfPlayers = 3 Then
                frmPuzzleBoard.btnRedRingIn.Show()
                frmPuzzleBoard.btnYellowRingIn.Show()
                frmPuzzleBoard.btnBlueRingIn.Show()
                player3RingIn = True
            ElseIf numberOfPlayers = 2 Then
                frmPuzzleBoard.btnRedRingIn.Show()
                frmPuzzleBoard.btnYellowRingIn.Show()
                frmPuzzleBoard.btnBlueRingIn.Hide()
                player3RingIn = True
            ElseIf numberOfPlayers = 1 Then
                frmPuzzleBoard.btnRedRingIn.Show()
                frmPuzzleBoard.btnYellowRingIn.Hide()
                player2RingIn = True
                frmPuzzleBoard.btnBlueRingIn.Hide()
                player3RingIn = True
            End If
            player1RingIn = True
            player2RingIn = True
            player3RingIn = True
            frmScore.usedLetterBoard.Enabled = False
            frmPuzzleBoard.btnSolve.Enabled = False
        Else
            frmPuzzleBoard.btnRedRingIn.Hide()
            frmPuzzleBoard.btnYellowRingIn.Hide()
            frmPuzzleBoard.btnBlueRingIn.Hide()
            player1RingIn = True
            player2RingIn = True
            player3RingIn = True
        End If
        frmPuzzleBoard.btnRedRingIn.Enabled = False
        frmPuzzleBoard.btnYellowRingIn.Enabled = False
        frmPuzzleBoard.btnBlueRingIn.Enabled = False
        If Not SAPI Is Nothing Then
            SAPI.SynchronousSpeakTimeout = 1000
        End If
        letterControlSortedList1.Clear()
        letterControlSortedList2.Clear()
        letterControlSortedList3.Clear()
        letterControlSortedList4.Clear()
        numberOfTurns = 10
        frmScore.lblNumberOfTurns.Text = "10"
        For Each lettersControls As Control In frmPuzzleBoard.PuzzleBoard1.Controls
            If lettersControls.GetType() Is GetType(PuzzleBoardLetter) Then
                CType(lettersControls, PuzzleBoardLetter).Hide()
                CType(lettersControls, PuzzleBoardLetter).letterRevealed = False
            End If
        Next
        Dim TheseAreYourWords As String()
        Dim myWords As New List(Of String)
        If preview = False Then
            Dim connPuzzle As SqlConnection
            connPuzzle = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" & Application.StartupPath & "\WheelPuzzles.mdf;Integrated Security=True")
            Dim strSQL
            roundType = round
            loadWheel(round)
            If mode = wheelMode.Classic Then
                If round = PuzzleType.TU1 Then
                    strSQL = "Select * From Puzzle WHERE Type = 0 and RoundNumber =1 and PackName =  @PackName"
                ElseIf round = PuzzleType.TU2 Then
                    strSQL = "Select * From Puzzle WHERE Type = 0 and RoundNumber =2 and PackName =  @PackName"
                ElseIf round = PuzzleType.R1 Then
                    strSQL = "Select * From Puzzle WHERE Type = 1 and RoundNumber =1 and PackName =  @PackName"
                ElseIf round = PuzzleType.R2 Then
                    strSQL = "Select * From Puzzle WHERE Type = 1 and RoundNumber =2 and PackName =  @PackName"
                ElseIf round = PuzzleType.R3 Then
                    strSQL = "Select * From Puzzle WHERE Type = 1 and RoundNumber =3 and PackName =  @PackName"
                ElseIf round = PuzzleType.TU3 Then
                    strSQL = "Select * From Puzzle WHERE Type = 0 and RoundNumber =3 and PackName =  @PackName"
                ElseIf round = PuzzleType.R4 Then
                    strSQL = "Select * From Puzzle WHERE Type = 1 and RoundNumber =4 and PackName =  @PackName"
                ElseIf round = PuzzleType.R5 Then
                    strSQL = "Select * From Puzzle WHERE Type = 1 and RoundNumber =5 and PackName =  @PackName"
                ElseIf round = PuzzleType.R6 Then
                    strSQL = "Select * From Puzzle WHERE Type = 1 and RoundNumber =6 and PackName =  @PackName"
                ElseIf round = PuzzleType.R7 Then
                    strSQL = "Select * From Puzzle WHERE Type = 1 and RoundNumber =7 and PackName =  @PackName"
                ElseIf round = PuzzleType.R8 Then
                    strSQL = "Select * From Puzzle WHERE Type = 1 and RoundNumber =8 and PackName =  @PackName"
                ElseIf round = PuzzleType.R9 Then
                    strSQL = "Select * From Puzzle WHERE Type = 1 and RoundNumber =9 and PackName =  @PackName"
                ElseIf round = PuzzleType.TBTU Then
                    strSQL = "Select * From Puzzle WHERE Type = 0 and RoundNumber = 4 and PackName =  @PackName"
                ElseIf round = PuzzleType.BR And mode <> wheelMode.Disney Then
                    strSQL = "Select * From Puzzle WHERE Category =  @Category and Type = 2 and RoundNumber =1 and PackName = @PackName"
                ElseIf round = PuzzleType.BR And mode = wheelMode.Disney Then
                End If
                Dim categoryParam As SqlParameter = New SqlParameter("@Category", category)
                Dim packNameParam As SqlParameter = New SqlParameter("@PackName", packName)
                Dim drProduct As SqlDataReader
                Dim cmdProduct As SqlCommand
                connPuzzle.Open()
                cmdProduct = New SqlCommand(strSQL, connPuzzle)
                If round = PuzzleType.BR Then
                    cmdProduct.Parameters.Add(categoryParam)
                End If
                cmdProduct.Parameters.Add(packNameParam)
                drProduct = cmdProduct.ExecuteReader(CommandBehavior.CloseConnection)
                If drProduct.Read() Then
                    category = Trim(drProduct("Category"))
                    puzzle = Trim(drProduct("Puzzle"))
                    puzzleTypeInt = CInt(Trim(drProduct("Type")))
                    crosswordStatus = CInt(Trim(drProduct("Crossword")))
                End If
            ElseIf mode = wheelMode.Disney Then
                strSQL = "Select * From Puzzle WHERE Type = 1 and PackName = 'Disney Wheel of Fortune'"
                If round <> PuzzleType.BR Then
                    If categoryListPrelim.Count = 0 Then
                        Dim categoryParam As SqlParameter = New SqlParameter("@Category", category)
                        Dim drProduct As SqlDataReader
                        Dim cmdProduct As SqlCommand
                        connPuzzle.Open()
                        cmdProduct = New SqlCommand(strSQL, connPuzzle)
                        If round = PuzzleType.BR Then
                            cmdProduct.Parameters.Add(categoryParam)
                        End If
                        drProduct = cmdProduct.ExecuteReader(CommandBehavior.CloseConnection)
                        While drProduct.Read()
                            Dim myPuzzle As New clsPuzzle
                            myPuzzle.category = Trim(drProduct("Category"))
                            myPuzzle.puzzle = Trim(drProduct("Puzzle"))
                            myPuzzle.puzzleTypeInt = CInt(Trim(drProduct("Type")))
                            myPuzzle.crosswordStatus = CInt(Trim(drProduct("Crossword")))
                            categoryListPrelim.Add(myPuzzle)
                        End While
                    End If
                    Dim myNewPuzzle = categoryListPrelim(GetRandomPlayer(1, categoryListPrelim.Count))
                    categoryListPrelim.Remove(myNewPuzzle)
                    category = myNewPuzzle.category
                    puzzle = myNewPuzzle.puzzle
                    puzzleTypeInt = myNewPuzzle.puzzleTypeInt
                    crosswordStatus = myNewPuzzle.crosswordStatus
                Else
                End If
            ElseIf mode = wheelMode.Random Then
                If round = PuzzleType.TU1 Or round = PuzzleType.TU2 Or round = PuzzleType.TU3 Then
                    strSQL = "Select * From Puzzle WHERE Type = 0 and PackName != 'Disney Wheel of Fortune'"

                End If
            End If
        ElseIf preview = True Then
            If frmCustomizer.cboCategory.SelectedItem <> "CROSSWORD" Then
                category = frmCustomizer.cboCategory.SelectedItem.ToString
            Else
                category = frmCustomizer.txtCrosswordClue.Text.ToUpper
            End If
            puzzle = frmCustomizer.txtPuzzle.Text.ToUpper
        End If
        TheseAreYourWords = puzzle.Split(" ")
        For Each item As String In TheseAreYourWords
            'If Not item = TheseAreYourWords.Last Then
            myWords.Add(item & " ")
            'Else
            '    myWords.Add(item)
            'End If
        Next
        If category = "SAME LETTER" Then
            sameLetter = puzzle.Substring(0, 1)
        End If
        puzzleString = puzzle
        Dim numberOfLengths As Integer = 0
        Dim numberOfLengths2 As Integer = 0
        Dim numberOfLengths3 As Integer = 0
        Dim numberOfLengths4 As Integer = 0
        Dim row1 As Boolean = False
        Dim row2 As Boolean = False
        Dim row3 As Boolean = False
        Dim row4 As Boolean = False
        Dim wordCount = 0
        Dim wordLengths As New List(Of Integer)
        If crosswordStatus = 0 Then
            If puzzle.Length <= 14 And myWords.Count >= 1 Then
                For Each word As String In myWords
                    If ((puzzle.Length + 1 - (numberOfLengths)) > (numberOfLengths)) And ((word.Replace(" ", "").Length <= 10 - numberOfLengths And row2 = False And ((myWords.Count - myWords.IndexOf(word) >= 2))) Or (myWords.Count = 1 And row2 = False)) Then
                        row1 = True
                        For myLetter = 0 To word.Length - 1
                            If word.Chars(myLetter).ToString() <> " " Then
                                letterControlSortedList2.Add(((numberOfLengths) + 13), word.Chars(myLetter).ToString())
                                'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & (numberOfLengths + 14)), PuzzleBoardLetter).Show()
                                'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & (numberOfLengths + 14)), PuzzleBoardLetter).letterBehind = word.Chars(myLetter).ToString()
                                'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & (numberOfLengths + 14)), PuzzleBoardLetter).btnLetter.BackgroundImage = My.Resources.PremiereLetterRevealTurn
                                'If word.Chars(myLetter).ToString() = "'" Or word.Chars(myLetter).ToString() = "?" Or word.Chars(myLetter).ToString() = "." Or word.Chars(myLetter).ToString() = "!" Or word.Chars(myLetter).ToString() = "-" Or word.Chars(myLetter).ToString() = "/" Or word.Chars(myLetter).ToString() = ":" Or word.Chars(myLetter).ToString() = "\" Or word.Chars(myLetter).ToString() = "&" Then
                                '    letterControlSortedList2.Add((numberOfLengths + 13), word.Chars(myLetter).ToString())
                                '    'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & (numberOfLengths + 14)), PuzzleBoardLetter).revealLetter()
                                'End If
                                numberOfLengths += 1
                            ElseIf word.Chars(myLetter).ToString() = " " Then
                                letterControlSortedList2.Add((((numberOfLengths) + 13)), word.Chars(myLetter).ToString())
                                'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((numberOfLengths + 14))), PuzzleBoardLetter).Hide()
                                numberOfLengths += 1
                            End If
                        Next
                    ElseIf ((puzzle.Length + 1 - (numberOfLengths)) = (numberOfLengths)) Or ((word.Replace(" ", "").Length >= 10 - numberOfLengths) And row1 = True And row2 = False) Or ((word.Replace(" ", "").Length <= 10 - numberOfLengths) And row1 = True And row2 = False) Or (word.Replace(" ", "").Length <= 13 - numberOfLengths2 And row2 = True And row3 = False) Then
                        'PETER PAN
                        'PAN
                        row2 = True
                        For myLetter = 0 To word.Length - 1
                            If word.Chars(myLetter).ToString() <> " " Then
                                letterControlSortedList3.Add((27 + (numberOfLengths2)), word.Chars(myLetter).ToString())
                                'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((27 + (numberOfLengths2 )))), PuzzleBoardLetter).Show()
                                'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((27 + (numberOfLengths2 )))), PuzzleBoardLetter).letterBehind = word.Chars(myLetter).ToString()
                                'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((27 + (numberOfLengths2 )))), PuzzleBoardLetter).btnLetter.BackgroundImage = My.Resources.PremiereLetterRevealTurn
                                'If word.Chars(myLetter).ToString() = "'" Or word.Chars(myLetter).ToString() = "?" Or word.Chars(myLetter).ToString() = "." Or word.Chars(myLetter).ToString() = "!" Or word.Chars(myLetter).ToString() = "-" Or word.Chars(myLetter).ToString() = "/" Or word.Chars(myLetter).ToString() = ":" Or word.Chars(myLetter).ToString() = "\" Or word.Chars(myLetter).ToString() = "&" Then
                                '    letterControlSortedList3.Add((27 + (numberOfLengths2)), word.Chars(myLetter).ToString())
                                '    'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((27 + (numberOfLengths2 )))), PuzzleBoardLetter).revealLetter()
                                'End If
                                numberOfLengths2 += 1
                            ElseIf word.Chars(myLetter).ToString() = " " Then
                                letterControlSortedList3.Add((27 + (numberOfLengths2)), word.Chars(myLetter).ToString())
                                'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((27 + (numberOfLengths2 )))), PuzzleBoardLetter).Hide()
                                numberOfLengths2 += 1
                            End If
                        Next
                    End If
                Next
            ElseIf puzzle.Length <= 28 Then
                For Each word As String In myWords
                    wordCount += 1
                    'If puzzle.length - numberOfLengths = numberOfLengths Then
                    If ((puzzle.Length + 1 - (numberOfLengths)) > (numberOfLengths)) And (word.Replace(" ", "").Length <= 14 - numberOfLengths And row2 = False And ((wordCount <= 2) Or (wordCount = 3 And ((word.Length >= 5) Or ((numberOfLengths + word.Length < 13) And ((myWords.Count - myWords.IndexOf(word)) > 2)))))) Then
                        row1 = True
                        For myLetter = 0 To word.Length - 1
                            If word.Chars(myLetter).ToString() <> " " Then
                                letterControlSortedList2.Add(((numberOfLengths) + 13), word.Chars(myLetter).ToString())
                                'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & (numberOfLengths + 14)), PuzzleBoardLetter).Show()
                                'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & (numberOfLengths + 14)), PuzzleBoardLetter).letterBehind = word.Chars(myLetter).ToString()
                                'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & (numberOfLengths + 14)), PuzzleBoardLetter).btnLetter.BackgroundImage = My.Resources.PremiereLetterRevealTurn                            
                                'If word.Chars(myLetter).ToString() = "'" Or word.Chars(myLetter).ToString() = "?" Or word.Chars(myLetter).ToString() = "." Or word.Chars(myLetter).ToString() = "!" Or word.Chars(myLetter).ToString() = "-" Or word.Chars(myLetter).ToString() = "/" Or word.Chars(myLetter).ToString() = ":" Or word.Chars(myLetter).ToString() = "\" Or word.Chars(myLetter).ToString() = "&" Then
                                '    letterControlSortedList2.Add((numberOfLengths + 13), word.Chars(myLetter).ToString())
                                '    'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & (numberOfLengths + 14)), PuzzleBoardLetter).revealLetter()
                                'End If
                                numberOfLengths += 1
                            ElseIf word.Chars(myLetter).ToString() = " " Then
                                letterControlSortedList2.Add(((numberOfLengths) + 13), word.Chars(myLetter).ToString())
                                'CType(frmPuzzleBoard.Controls(puzzleBoardName).controls("puzzleboardletter" & ((numberOfLengths + 14))), PuzzleBoardLetter).Hide()
                                numberOfLengths += 1
                            End If
                        Next
                        'ElseIf word.Replace(" ", "").Length = 14 - numberOfLengths And row2 = False Then
                        '    Dim letterList As New SortedList(Of Integer, String)
                        '    For Each item As KeyValuePair(Of Integer, String) In letterControlSortedList
                        '        letterList.Add(item.Key, item.Value)
                        '    Next
                        '    For Each item As KeyValuePair(Of Integer, String) In letterList
                        '        If item.Key < 26 And item.Key > 13 Then
                        '            Dim oldKey = Integer.Parse(item.Key)
                        '            Dim oldValue = item.Value
                        '            letterControlSortedList.Remove(item.Key)
                        '            letterControlSortedList.Add((oldKey - 1), oldValue)
                        '        End If
                        '    Next
                        '    numberOfLengths += 1
                        '    For myLetter = 0 To word.Length - 1
                        '        letterControlSortedList.Add(((numberOfLengths)), word.Chars(myLetter).ToString())
                        '        If word.Chars(myLetter).ToString() = "'" Or word.Chars(myLetter).ToString() = "?" Or word.Chars(myLetter).ToString() = "." Or word.Chars(myLetter).ToString() = "!" Or word.Chars(myLetter).ToString() = "-" Or word.Chars(myLetter).ToString() = "/" Or word.Chars(myLetter).ToString() = ":" Or word.Chars(myLetter).ToString() = "\" Or word.Chars(myLetter).ToString() = "&" Then
                        '            letterControlSortedList.Add(((numberOfLengths)), word.Chars(myLetter).ToString())
                        '            'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((27 + (numberOfLengths2)))), PuzzleBoardLetter).revealLetter()
                        '        End If
                        '        numberOfLengths2 += 1
                        '    Next
                    ElseIf ((puzzle.Length + 1 - (numberOfLengths)) = (numberOfLengths)) Or (word.Replace(" ", "").Length >= 14 - numberOfLengths And row1 = True And row2 = False) Or (word.Replace(" ", "").Length <= 14 - numberOfLengths And row1 = True And row2 = False And wordCount > 2) Or (word.Replace(" ", "").Length <= 14 - numberOfLengths2 And row2 = True And row3 = False) Then
                        wordCount = 0
                        row2 = True
                        For myLetter = 0 To word.Length - 1

                            'If frmPuzzleBoard.PuzzleBoard1.PuzzleBoardLetter13.Visible = False Then
                            If word.Chars(myLetter).ToString() <> " " Then
                                letterControlSortedList3.Add((27 + (numberOfLengths2)), word.Chars(myLetter).ToString())
                                'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((27 + (numberOfLengths2 )))), PuzzleBoardLetter).Show()
                                'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((27 + (numberOfLengths2 )))), PuzzleBoardLetter).letterBehind = word.Chars(myLetter).ToString()
                                'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((27 + (numberOfLengths2 )))), PuzzleBoardLetter).btnLetter.BackgroundImage = My.Resources.PremiereLetterRevealTurn
                                'If word.Chars(myLetter).ToString() = "'" Or word.Chars(myLetter).ToString() = "?" Or word.Chars(myLetter).ToString() = "." Or word.Chars(myLetter).ToString() = "!" Or word.Chars(myLetter).ToString() = "-" Or word.Chars(myLetter).ToString() = "/" Or word.Chars(myLetter).ToString() = ":" Or word.Chars(myLetter).ToString() = "\" Or word.Chars(myLetter).ToString() = "&" Then
                                '    letterControlSortedList3.Add((27 + (numberOfLengths2)), word.Chars(myLetter).ToString())
                                '    'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((27 + (numberOfLengths2 )))), PuzzleBoardLetter).revealLetter()
                                'End If
                                numberOfLengths2 += 1
                            ElseIf word.Chars(myLetter).ToString() = " " Then
                                letterControlSortedList3.Add((27 + (numberOfLengths2)), word.Chars(myLetter).ToString())
                                'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((27 + (numberOfLengths2 )))), PuzzleBoardLetter).Hide()
                                numberOfLengths2 += 1
                            End If
                            'Else
                            '    If word.Chars(myLetter).ToString() <> " " Then
                            '        letterControlSortedList.Add((27 + (numberOfLengths2)), word.Chars(myLetter).ToString())
                            '        'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((27 + (numberOfLengths2)))), PuzzleBoardLetter).Show()
                            '        'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((27 + (numberOfLengths2)))), PuzzleBoardLetter).letterBehind = word.Chars(myLetter).ToString()
                            '        'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((27 + (numberOfLengths2 )))), PuzzleBoardLetter).btnLetter.BackgroundImage = My.Resources.PremiereLetterRevealTurn
                            '        frmPuzzleBoard.ListBox1.Items.Add(word.Chars(myLetter).ToString())
                            '        frmPuzzleBoard.ListBox2.Items.Add("PuzzleBoardLetter" & (27 + (numberOfLengths2)))
                            '        If word.Chars(myLetter).ToString() = "'" Or word.Chars(myLetter).ToString() = "?" Or word.Chars(myLetter).ToString() = "." Or word.Chars(myLetter).ToString() = "!" Or word.Chars(myLetter).ToString() = "-" Or word.Chars(myLetter).ToString() = "/" Or word.Chars(myLetter).ToString() = ":" Or word.Chars(myLetter).ToString() = "\" Or word.Chars(myLetter).ToString() = "&" Then
                            '            letterControlSortedList.Add((27 + (numberOfLengths2)), word.Chars(myLetter).ToString())
                            '            'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((27 + (numberOfLengths2)))), PuzzleBoardLetter).revealLetter()
                            '        End If
                            '        numberOfLengths2 += 1
                            '        frmPuzzleBoard.ListBox3.Items.Add(numberOfLengths2)
                            '    ElseIf word.Chars(myLetter).ToString() = " " Then
                            '        letterControlSortedList.Add((27 + (numberOfLengths2)), word.Chars(myLetter).ToString())
                            '        'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((27 + (numberOfLengths2)))), PuzzleBoardLetter).Hide()
                            '        numberOfLengths2 += 1
                            '    End If
                            'End If
                        Next
                        'ElseIf word.Replace(" ", "").Length = 14 - numberOfLengths2 And row2 = False Then
                        '    Dim letterList As New SortedList(Of Integer, String)
                        '    For Each item As KeyValuePair(Of Integer, String) In letterControlSortedList
                        '        letterList.Add(item.Key, item.Value)
                        '    Next
                        '    For Each item As KeyValuePair(Of Integer, String) In letterList
                        '        If item.Key < 40 And item.Key > 27 Then
                        '            Dim oldKey = Integer.Parse(item.Key)
                        '            Dim oldValue = item.Value
                        '            letterControlSortedList.Remove(item.Key)
                        '            letterControlSortedList.Add((oldKey - 1), oldValue)
                        '        End If
                        '    Next
                        '    numberOfLengths2 += 1
                        '    For myLetter = 0 To word.Length - 1
                        '        letterControlSortedList.Add((27 + (numberOfLengths2)), word.Chars(myLetter).ToString())
                        '        If word.Chars(myLetter).ToString() = "'" Or word.Chars(myLetter).ToString() = "?" Or word.Chars(myLetter).ToString() = "." Or word.Chars(myLetter).ToString() = "!" Or word.Chars(myLetter).ToString() = "-" Or word.Chars(myLetter).ToString() = "/" Or word.Chars(myLetter).ToString() = ":" Or word.Chars(myLetter).ToString() = "\" Or word.Chars(myLetter).ToString() = "&" Then
                        '            letterControlSortedList.Add((27 + (numberOfLengths2)), word.Chars(myLetter).ToString())
                        '            'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((27 + (numberOfLengths2)))), PuzzleBoardLetter).revealLetter()
                        '        End If
                        '        numberOfLengths2 += 1
                        '    Next
                    ElseIf word.Replace(" ", "").Length > 14 - numberOfLengths2 And row2 = True And row3 = False Or (word.Replace(" ", "").Length <= 14 - numberOfLengths3 And row3 = True And row4 = False) Then
                        wordCount = 0
                        row3 = True
                        For myLetter = 0 To word.Length - 1

                            If word.Chars(myLetter).ToString() <> " " Then
                                letterControlSortedList4.Add((41 + (numberOfLengths3)), word.Chars(myLetter).ToString())
                                'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((40 + (numberOfLengths3 )))), PuzzleBoardLetter).Show()
                                'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((40 + (numberOfLengths3 )))), PuzzleBoardLetter).letterBehind = word.Chars(myLetter).ToString()
                                'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((40 + (numberOfLengths3 )))), PuzzleBoardLetter).btnLetter.BackgroundImage = My.Resources.PremiereLetterRevealTurn
                                'If word.Chars(myLetter).ToString() = "'" Or word.Chars(myLetter).ToString() = "?" Or word.Chars(myLetter).ToString() = "." Or word.Chars(myLetter).ToString() = "!" Or word.Chars(myLetter).ToString() = "-" Or word.Chars(myLetter).ToString() = "/" Or word.Chars(myLetter).ToString() = ":" Or word.Chars(myLetter).ToString() = "\" Or word.Chars(myLetter).ToString() = "&" Then
                                '    letterControlSortedList4.Add((40 + (numberOfLengths3)), word.Chars(myLetter).ToString())
                                '    'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((40 + (numberOfLengths3 )))), PuzzleBoardLetter).revealLetter()
                                'End If
                                numberOfLengths3 += 1
                            ElseIf word.Chars(myLetter).ToString() = " " Then
                                letterControlSortedList4.Add((41 + (numberOfLengths3)), word.Chars(myLetter).ToString())
                                'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((40 + (numberOfLengths3 )))), PuzzleBoardLetter).Hide()
                                numberOfLengths3 += 1
                            End If
                        Next
                        'ElseIf word.Replace(" ", "").Length >= 13 - numberOfLengths3 And row3 = True And row4 = False Or (word.Replace(" ", "").Length <= 13 - numberOfLengths4 And row4 = True) Then
                        '    row4 = True
                        '    For myLetter = 0 To word.Length - 1
                        '        If word.Chars(myLetter).ToString() <> " " Then
                        '            CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((40 + (numberOfLengths4 )))), PuzzleBoardLetter).Show()
                        '            CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((40 + (numberOfLengths4 )))), PuzzleBoardLetter).letterBehind = word.Chars(myLetter).ToString()
                        '            'CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & ((40 + (numberOfLengths4 )))), PuzzleBoardLetter).revealLetter()
                        '            frmPuzzleBoard.ListBox1.Items.Add(word.Chars(myLetter).ToString())
                        '            frmPuzzleBoard.ListBox2.Items.Add("PuzzleBoardLetter" & (numberOfLengths4 + (41 - (12 - numberOfLengths4))))
                        '            If word.Chars(myLetter).ToString() = "'" Or word.Chars(myLetter).ToString() = "?" Or word.Chars(myLetter).ToString() = "." Or word.Chars(myLetter).ToString() = "!" Or word.Chars(myLetter).ToString() = "-" Or word.Chars(myLetter).ToString() = "/" Or word.Chars(myLetter).ToString() = ":" Or word.Chars(myLetter).ToString() = "\" Or word.Chars(myLetter).ToString() = "&" Then
                        '                CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((40 + (numberOfLengths4 )))), PuzzleBoardLetter).revealLetter()
                        '            End If
                        '            numberOfLengths4 += 1
                        '            frmPuzzleBoard.ListBox3.Items.Add(numberOfLengths4)
                        '        ElseIf word.Chars(myLetter).ToString() = " " Then
                        '            CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((40 + (numberOfLengths4 )))), PuzzleBoardLetter).Hide()
                        '            numberOfLengths4 += 1
                        '        End If
                        '    Next
                        'For myLetter = 0 To word.Length - 1
                        '    If word.Chars(myLetter).ToString() <> " " Then
                        '        CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & (numberOfLengths4 + (41 - (12 - numberOfLengths3)))), PuzzleBoardLetter).Show()
                        '        CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & (numberOfLengths4 + (41 - (12 - numberOfLengths3)))), PuzzleBoardLetter).letterBehind = word.Chars(myLetter).ToString()
                        '        CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & (numberOfLengths4 + (41 - (12 - numberOfLengths3)))), PuzzleBoardLetter).revealLetter()
                        '        frmPuzzleBoard.ListBox1.Items.Add(word.Chars(myLetter).ToString())
                        '        frmPuzzleBoard.ListBox2.Items.Add("PuzzleBoardLetter" & (numberOfLengths4 + (41 - (12 - numberOfLengths3))))
                        '        numberOfLengths4 += 1
                        '        frmPuzzleBoard.ListBox3.Items.Add(numberOfLengths4)
                        '    ElseIf word.Chars(myLetter).ToString() = " " Then
                        '        CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((40 + (numberOfLengths4 )))), PuzzleBoardLetter).Hide()
                        '        numberOfLengths4 += 1
                        '    End If
                        'Next
                    End If
                Next
            ElseIf puzzle.Length > 28 Then
                For Each word As String In myWords
                    If word.Replace(" ", "").Length <= 12 - numberOfLengths And row2 = False Then
                        row1 = True
                        For myLetter = 0 To word.Length - 1
                            If word.Chars(myLetter).ToString() <> " " Then
                                letterControlSortedList1.Add(((numberOfLengths)), word.Chars(myLetter).ToString())
                                'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & (numberOfLengths )), PuzzleBoardLetter).Show()
                                'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & (numberOfLengths )), PuzzleBoardLetter).letterBehind = word.Chars(myLetter).ToString()
                                'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & (numberOfLengths )), PuzzleBoardLetter).btnLetter.BackgroundImage = My.Resources.PremiereLetterRevealTurn
                                'If word.Chars(myLetter).ToString() = "'" Or word.Chars(myLetter).ToString() = "?" Or word.Chars(myLetter).ToString() = "." Or word.Chars(myLetter).ToString() = "!" Or word.Chars(myLetter).ToString() = "-" Or word.Chars(myLetter).ToString() = "/" Or word.Chars(myLetter).ToString() = ":" Or word.Chars(myLetter).ToString() = "\" Or word.Chars(myLetter).ToString() = "&" Then
                                '    letterControlSortedList1.Add(((numberOfLengths)), word.Chars(myLetter).ToString())
                                '    'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & (numberOfLengths )), PuzzleBoardLetter).revealLetter()
                                'End If
                                numberOfLengths += 1
                            ElseIf word.Chars(myLetter).ToString() = " " Then
                                letterControlSortedList1.Add(((numberOfLengths)), word.Chars(myLetter).ToString())
                                'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((numberOfLengths ))), PuzzleBoardLetter).Hide()
                                numberOfLengths += 1
                            End If
                        Next
                    ElseIf (word.Replace(" ", "").Length > 12 - numberOfLengths And row1 = True And row2 = False) Or (word.Replace(" ", "").Length <= 13 - numberOfLengths2 And row2 = True And row3 = False) Then
                        row2 = True
                        For myLetter = 0 To word.Length - 1
                            If word.Chars(myLetter).ToString() <> " " Then
                                letterControlSortedList2.Add((13 + (numberOfLengths2)), word.Chars(myLetter).ToString())
                                'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((13 + (numberOfLengths2 )))), PuzzleBoardLetter).Show()
                                'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((13 + (numberOfLengths2 )))), PuzzleBoardLetter).letterBehind = word.Chars(myLetter).ToString()
                                'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((13 + (numberOfLengths2 )))), PuzzleBoardLetter).btnLetter.BackgroundImage = My.Resources.PremiereLetterRevealTurn
                                'If word.Chars(myLetter).ToString() = "'" Or word.Chars(myLetter).ToString() = "?" Or word.Chars(myLetter).ToString() = "." Or word.Chars(myLetter).ToString() = "!" Or word.Chars(myLetter).ToString() = "-" Or word.Chars(myLetter).ToString() = "/" Or word.Chars(myLetter).ToString() = ":" Or word.Chars(myLetter).ToString() = "\" Or word.Chars(myLetter).ToString() = "&" Then
                                '    letterControlSortedList2.Add((13 + (numberOfLengths2)), word.Chars(myLetter).ToString())
                                '    'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((13 + (numberOfLengths2 )))), PuzzleBoardLetter).revealLetter()
                                'End If
                                numberOfLengths2 += 1
                            ElseIf word.Chars(myLetter).ToString() = " " Then
                                letterControlSortedList2.Add((13 + (numberOfLengths2)), word.Chars(myLetter).ToString())
                                'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((13 + (numberOfLengths2 )))), PuzzleBoardLetter).Hide()
                                numberOfLengths2 += 1
                            End If
                        Next
                    ElseIf word.Replace(" ", "").Length > 13 - numberOfLengths2 And row2 = True And row3 = False Or (word.Replace(" ", "").Length <= 13 - numberOfLengths3 And row3 = True And row4 = False) Then
                        row3 = True
                        For myLetter = 0 To word.Length - 1
                            If word.Chars(myLetter).ToString() <> " " Then
                                letterControlSortedList3.Add((27 + (numberOfLengths3)), word.Chars(myLetter).ToString())
                                'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((27 + (numberOfLengths3 )))), PuzzleBoardLetter).Show()
                                'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((27 + (numberOfLengths3 )))), PuzzleBoardLetter).letterBehind = word.Chars(myLetter).ToString()
                                'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((27 + (numberOfLengths3 )))), PuzzleBoardLetter).btnLetter.BackgroundImage = My.Resources.PremiereLetterRevealTurn
                                'If word.Chars(myLetter).ToString() = "'" Or word.Chars(myLetter).ToString() = "?" Or word.Chars(myLetter).ToString() = "." Or word.Chars(myLetter).ToString() = "!" Or word.Chars(myLetter).ToString() = "-" Or word.Chars(myLetter).ToString() = "/" Or word.Chars(myLetter).ToString() = ":" Or word.Chars(myLetter).ToString() = "\" Or word.Chars(myLetter).ToString() = "&" Then
                                '    'letterControlSortedList.Add((27 + (numberOfLengths3 )), word.Chars(myLetter).ToString())
                                '    CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((27 + (numberOfLengths3)))), PuzzleBoardLetter).revealLetter()
                                'End If
                                numberOfLengths3 += 1
                            ElseIf word.Chars(myLetter).ToString() = " " Then
                                letterControlSortedList3.Add((27 + (numberOfLengths3)), word.Chars(myLetter).ToString())
                                'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((27 + (numberOfLengths3 )))), PuzzleBoardLetter).Hide()
                                numberOfLengths3 += 1
                            End If
                        Next
                    ElseIf word.Replace(" ", "").Length > 13 - numberOfLengths3 And row3 = True And row4 = False Or (word.Replace(" ", "").Length <= 12 - numberOfLengths4 And row4 = True) Then
                        row4 = True
                        Try
                            For myLetter = 0 To word.Length - 1
                                If word.Chars(myLetter).ToString() <> " " Then
                                    letterControlSortedList4.Add((41 + (numberOfLengths4)), word.Chars(myLetter).ToString())
                                    'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((40 + (numberOfLengths4 )))), PuzzleBoardLetter).Show()
                                    'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((40 + (numberOfLengths4 )))), PuzzleBoardLetter).letterBehind = word.Chars(myLetter).ToString()
                                    'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((40 + (numberOfLengths4 )))), PuzzleBoardLetter).btnLetter.BackgroundImage = My.Resources.PremiereLetterRevealTurn
                                    'CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & ((40 + (numberOfLengths4 )))), PuzzleBoardLetter).revealLetter()
                                    'If word.Chars(myLetter).ToString() = "'" Or word.Chars(myLetter).ToString() = "?" Or word.Chars(myLetter).ToString() = "." Or word.Chars(myLetter).ToString() = "!" Or word.Chars(myLetter).ToString() = "-" Or word.Chars(myLetter).ToString() = "/" Or word.Chars(myLetter).ToString() = ":" Or word.Chars(myLetter).ToString() = "\" Or word.Chars(myLetter).ToString() = "&" Then
                                    '    letterControlSortedList4.Add((40 + (numberOfLengths4)), word.Chars(myLetter).ToString())
                                    '    'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((40 + (numberOfLengths4 )))), PuzzleBoardLetter).revealLetter()
                                    'End If
                                    numberOfLengths4 += 1
                                ElseIf word.Chars(myLetter).ToString() = " " Then
                                    letterControlSortedList4.Add((41 + (numberOfLengths4)), word.Chars(myLetter).ToString())
                                    'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((40 + (numberOfLengths4 )))), PuzzleBoardLetter).Hide()
                                    numberOfLengths4 += 1
                                End If
                            Next
                        Catch ex As Exception
                            MsgBox("The puzzle you entered is too long. Please try again.", vbCritical, "Wheel of Fortune")
                        End Try
                    End If
                Next
            End If
            trillonOffset = 0
            If (letterControlSortedList1.Count = 13 Or letterControlSortedList1.Count = 12) Or (letterControlSortedList4.Count = 13 Or letterControlSortedList4.Count = 12) Then
                trillonOffset = 1
            End If
            If letterControlSortedList4.Count > 1 And letterControlSortedList1.Count = 0 Then
                trillonPreset = 14
            Else
                trillonPreset = 0
            End If
            'If letterControlSortedList1.Count = 0 And letterControlSortedList4.Count <> 13 Then
            If (letterControlSortedList1.Count <> 13 And letterControlSortedList1.Count <> 12) And (letterControlSortedList4.Count <> 13 And letterControlSortedList4.Count <> 12) And letterControlSortedList2.Count <> 15 And letterControlSortedList3.Count <> 15 Then
                trillonOffset = Math.Ceiling((12 - letterControlSortedList1.Count) / 2)
                Dim max = letterControlSortedList1.Count
                If letterControlSortedList2.Count > max And letterControlSortedList2.Count <> 15 Then
                    max = letterControlSortedList2.Count
                    If max = 14 Then
                        If letterControlSortedList4.Count > 1 And letterControlSortedList1.Count = 0 Then
                            trillonOffset = Math.Ceiling((12 - letterControlSortedList2.Count) / 2) + 1
                        Else
                            trillonOffset = Math.Ceiling((14 - letterControlSortedList2.Count) / 2) + 1
                        End If
                    Else
                        trillonOffset = Math.Ceiling((14 - letterControlSortedList2.Count) / 2)
                    End If
                End If
                If letterControlSortedList3.Count > max And letterControlSortedList3.Count <> 15 Then
                    max = letterControlSortedList3.Count
                    If max = 14 Then
                        trillonOffset = Math.Ceiling((14 - letterControlSortedList3.Count) / 2) + 1
                    Else
                        trillonOffset = Math.Ceiling((14 - letterControlSortedList3.Count) / 2)
                    End If
                End If
                If letterControlSortedList4.Count > max And letterControlSortedList4.Count <> 13 Then
                    max = letterControlSortedList4.Count
                    If letterControlSortedList4.Count > 1 And letterControlSortedList1.Count = 0 Then
                        trillonOffset = Math.Ceiling((14 - letterControlSortedList4.Count) / 2)
                    Else
                        trillonOffset = Math.Ceiling((12 - letterControlSortedList4.Count) / 2)
                    End If

                End If
            End If
            For Each item As KeyValuePair(Of Integer, String) In letterControlSortedList1
                loadTrillonOffset(item, trillonPreset, trillonOffset, letterControlSortedList1.Count)
                'If item.Key = letterControlSortedList1.Last.Key Then
                '    lastLetter = item.Key - 1
                'End If
            Next
            For Each item As KeyValuePair(Of Integer, String) In letterControlSortedList2
                If letterControlSortedList2.Count <> 15 Then
                    loadTrillonOffset(item, trillonPreset, trillonOffset, letterControlSortedList1.Count)
                Else
                    loadTrillonOffset(item, trillonPreset, 0, letterControlSortedList1.Count)
                End If
                'If item.Key = letterControlSortedList2.Last.Key Then
                '    lastLetter = item.Key - 1
                'End If
            Next
            For Each item As KeyValuePair(Of Integer, String) In letterControlSortedList3
                If letterControlSortedList3.Count <> 15 Then
                    loadTrillonOffset(item, trillonPreset, trillonOffset, letterControlSortedList1.Count)
                Else
                    loadTrillonOffset(item, trillonPreset, 0, letterControlSortedList1.Count)
                End If
                'If item.Key = letterControlSortedList3.Last.Key Then
                '    lastLetter = item.Key - 1
                'End If
            Next
            If Not (letterControlSortedList4.Count > 1 And letterControlSortedList1.Count = 0) Then
                trillonOffset -= 1
            End If
            For Each item As KeyValuePair(Of Integer, String) In letterControlSortedList4
                If letterControlSortedList4.Count = 13 Or trillonOffset = 1 Then
                    loadTrillonOffset(item, trillonPreset, (trillonOffset), letterControlSortedList1.Count)
                    'End If
                Else
                    loadTrillonOffset(item, trillonPreset, (trillonOffset), letterControlSortedList1.Count)
                End If
                'If item.Key = letterControlSortedList4.Last.Key Then
                '    lastLetter = item.Key - 1
                'End If
            Next
        Else
            frmPuzzleBoard.logoCrossword.Show()
            Try
                For Each word As String In myWords
                    'word.Replace(" ", "")
                    Dim puzzleBoardLetterInteger As Integer
                    Dim myChars() As Char = word.ToCharArray()
                    puzzleBoardLetterInteger = Nothing
                    For Each ch As Char In myChars
                        If Char.IsDigit(ch) Then
                            puzzleBoardLetterInteger &= ch
                        End If
                    Next
                    If myWords.Last.Contains(puzzleBoardLetterInteger) Then
                        lastLetter = puzzleBoardLetterInteger
                    End If
                    For myLetter = 0 To word.Length - 1
                        Dim letter
                        If word.Chars(myLetter).ToString() <> " " And Not Char.IsDigit(word.Chars(myLetter)) Then
                            letter = word.Chars(myLetter).ToString().Replace(puzzleBoardLetterInteger, "")
                            CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & puzzleBoardLetterInteger), PuzzleBoardLetter).letterBehind = letter
                            CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & puzzleBoardLetterInteger), PuzzleBoardLetter).Show()
                            'CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & puzzleBoardLetterInteger), PuzzleBoardLetter).btnLetter.BackgroundImage = My.Resources.PremiereLetterRevealTurn
                            puzzleBoardLetterInteger = Nothing
                        End If
                    Next
                Next
            Catch ex As Exception
                MsgBox("The crossword puzzle is invalid, please go to the customizer and re-enter the puzzle. Remember to follow the crossword format exactly as mistakes will cause the crossword to not load.", vbCritical, "Wheel of Fortune")
            End Try
        End If
        'For i As Integer = 1 To lastLetter
        '    If CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & i), PuzzleBoardLetter).Visible = True Then
        '        solveTypedList.Add(i)
        '    End If
        'Next
        'For Each myLetterControl As PuzzleBoardLetter In frmPuzzleBoard.PuzzleBoard1.Controls
        '    If myLetterControl.Visible = True Then
        '        solveTypedList.Add(myLetterControl.Name.Replace("PuzzleBoardLetter", ""))
        '    End If
        'Next
        For Each item As KeyValuePair(Of Integer, String) In solveSortedList
            If item.Key = solveSortedList.Last.Key Then

            End If
        Next
        puzzleLoaded = True
        revealCategory()
    End Sub
    Public Shared Sub loadTrillonOffset(item As KeyValuePair(Of Integer, String), trillonPreset As Integer, trillonOffset As Integer, row1Count As Integer)
        If item.Key >= 13 And item.Key <= 26 And letterControlSortedList1.Count = 0 And letterControlSortedList4.Count > 0 Then
            trillonPreset = 13
        End If
        If trillonOffset > 1 Then
            If item.Value = "'" Or item.Value = "?" Or item.Value = "." Or item.Value = "!" Or item.Value = "-" Or item.Value = "/" Or item.Value = ":" Or item.Value = "\" Or item.Value = "&" Then
                CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((item.Key - trillonPreset) + trillonOffset)), PuzzleBoardLetter).Show()
                CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((item.Key - trillonPreset) + trillonOffset)), PuzzleBoardLetter).letterBehind = item.Value
                CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((item.Key - trillonPreset) + trillonOffset)), PuzzleBoardLetter).revealLetter()
            ElseIf item.Value = " " Then
                If item.Key <> 53 Then
                    CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((item.Key - trillonPreset) + trillonOffset)), PuzzleBoardLetter).Hide()
                End If
            Else
                CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((item.Key - trillonPreset) + trillonOffset)), PuzzleBoardLetter).Show()
                CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((item.Key - trillonPreset) + trillonOffset)), PuzzleBoardLetter).letterBehind = item.Value
                'solveTypedList.Add((item.Key - trillonPreset) + trillonOffset)
            End If
        Else
            If item.Value = "'" Or item.Value = "?" Or item.Value = "." Or item.Value = "!" Or item.Value = "-" Or item.Value = "/" Or item.Value = ":" Or item.Value = "\" Or item.Value = "&" Then
                If item.Key <= 40 Then
                    CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((item.Key - trillonPreset) + 1)), PuzzleBoardLetter).Show()
                    CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((item.Key - trillonPreset) + 1)), PuzzleBoardLetter).letterBehind = item.Value
                    CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((item.Key - trillonPreset) + 1)), PuzzleBoardLetter).revealLetter()
                Else
                    CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & (item.Key - trillonPreset)), PuzzleBoardLetter).Show()
                    CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & (item.Key - trillonPreset)), PuzzleBoardLetter).letterBehind = item.Value
                    CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & (item.Key - trillonPreset)), PuzzleBoardLetter).revealLetter()
                End If
            ElseIf item.Value = " " Then
                If item.Key <> 53 And (item.Key + 1) <> 53 Then
                    CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((item.Key - trillonPreset) + trillonOffset)), PuzzleBoardLetter).Hide()
                Else

                End If
            Else
                If item.Key <= 40 And trillonOffset <> 0 Then
                    CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((item.Key - trillonPreset) + 1)), PuzzleBoardLetter).Show()
                    CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((item.Key - trillonPreset) + 1)), PuzzleBoardLetter).letterBehind = item.Value
                    'solveTypedList.Add((item.Key - trillonPreset) + 1)
                Else
                    CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((item.Key - trillonPreset) + trillonOffset)), PuzzleBoardLetter).Show()
                    CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((item.Key - trillonPreset) + trillonOffset)), PuzzleBoardLetter).letterBehind = item.Value
                    'solveTypedList.Add((item.Key - trillonPreset) + trillonOffset)
                    '    CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & item.Key), PuzzleBoardLetter).Show()
                    '    CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & item.Key), PuzzleBoardLetter).letterBehind = item.Value
                End If
            End If
        End If
    End Sub
#End Region
#Region "Load Bonus Round"
    Public Shared Sub loadBonusRound()
        If round = PuzzleType.BR Then
            frmPuzzleBoard.lblRSTLNE.Show()
            loadRSTLNE()
            frmAudio.Show()
            frmAudio.playRSTLNE(True)
        Else
            Exit Sub
        End If
    End Sub
#End Region
#Region "Reveal Bonus Round"
    Public Shared Sub revealBonusRound()
        If round = PuzzleType.BR And bonusRevealed = False And bonusRSTLNERevealed = False Then
            frmPuzzleBoard.revealBonus()
            bonusRevealed = True
        ElseIf round = PuzzleType.BR And bonusRevealed = True And bonusRSTLNERevealed = False Then
            frmAudio.Show()
            loadBonusRound()
            bonusRSTLNERevealed = True
            frmScore.usedLetterBoard.Enabled = True
            frmPuzzleBoard.wheelTilt.Enabled = False
        ElseIf bonusPuzzleRevealed = True Then
            frmScore.BonusCardEnvelope1.Show()
        End If
    End Sub
#End Region
#Region "Load RSTLNE in Puzzle"
    Public Shared Sub loadRSTLNE()
        If virtualHost = True Then
            SAPI = CreateObject("SAPI.spvoice")
            SAPI.Speak("R, S, T, L, N, E. Are there any of those in the puzzle?")
        End If
        For Each letterControl As Control In frmPuzzleBoard.Controls(puzzleBoardName).Controls
            If letterControl.GetType() Is GetType(PuzzleBoardLetter) Then
                If CType(letterControl, PuzzleBoardLetter).letterBehind = "R" Or CType(letterControl, PuzzleBoardLetter).letterBehind = "S" Or CType(letterControl, PuzzleBoardLetter).letterBehind = "T" Or CType(letterControl, PuzzleBoardLetter).letterBehind = "L" Or CType(letterControl, PuzzleBoardLetter).letterBehind = "N" Or CType(letterControl, PuzzleBoardLetter).letterBehind = "E" Then
                    letterControlList.Add(letterControl.Name.Replace("PuzzleBoardLetter", ""))
                    'CType(letterControl, PuzzleBoardLetter).displayBlueBKG()
                    'CType(letterControl, PuzzleBoardLetter).playDing()
                    For Each selectedLetters As Button In frmScore.usedLetterBoard.Controls
                        If selectedLetters.Text = "R" Or selectedLetters.Text = "S" Or selectedLetters.Text = "T" Or selectedLetters.Text = "L" Or selectedLetters.Text = "N" Or selectedLetters.Text = "E" Then
                            selectedLetters.Enabled = False
                        End If
                    Next
                End If
            End If
        Next
        timeStart = DateTime.Now.Second
        frmScore.tmrLetterReveal.Start()
    End Sub
#End Region
#Region "Load Letters in Bonus Round"
    Public Shared Sub loadBonusLetters()
        For Each letterControl As Control In frmPuzzleBoard.Controls(puzzleBoardName).Controls
            If letterControl.GetType() Is GetType(PuzzleBoardLetter) Then
                'If selectedBonusLetters.Contains(CType(letterControl, PuzzleBoardLetter).letterBehind) Then
                For Each letter As String In selectedBonusLetters
                    If CType(letterControl, PuzzleBoardLetter).letterBehind = letter Then
                        letterControlList.Add(letterControl.Name.Replace("PuzzleBoardLetter", ""))
                        'CType(letterControl, PuzzleBoardLetter).displayBlueBKG()
                        'CType(letterControl, PuzzleBoardLetter).playDing()
                        'For Each selectedLetters As Button In frmScore.usedLetterBoard.Controls
                        '    selectedLetters.Enabled = False
                        'Next
                    End If
                Next
            End If
            'End If
        Next
        'If round = PuzzleType.BR And letterControlList.Count > 0 Then
        '    showUsedLettersInBonus()
        'End If
        'previousValue = "Lose A Turn"
        'showUsedLettersInBonus()
        timeStart = DateTime.Now.Second
        frmScore.tmrLetterReveal.Start()
        'showUsedLettersInBonus()
        'frmScore.bonusTimer()
    End Sub
#End Region
#Region "Cancel Solve"
    Public Shared Sub cancelSolve()
        For Each myLetter As PuzzleBoardLetter In frmPuzzleBoard.PuzzleBoard1.Controls
            If myLetter.letterRevealed = False Then
                myLetter.btnLetter.BackgroundImage = Nothing
                myLetter.btnLetter.BackColor = Color.White
            End If
        Next
        isNoLetters = True
        If round <> PuzzleType.TU1 And round <> PuzzleType.TU2 And round <> PuzzleType.TU3 And round <> PuzzleType.TBTU And round <> PuzzleType.BR Then
            LoseATurn()
        ElseIf round = PuzzleType.BR Then
            frmPuzzleBoard.tmrBonus.Start()
            frmScore.wmpBonus.Ctlcontrols.play()
            frmPuzzleBoard.Enabled = True
            frmPuzzleBoard.btnSolve.Enabled = True
        Else
            If currentPlayer = 1 Then
                frmPuzzleBoard.btnRedRingIn.Enabled = False
                frmPuzzleBoard.btnYellowRingIn.Enabled = True
                frmPuzzleBoard.btnBlueRingIn.Enabled = True
            ElseIf currentPlayer = 2 Then
                frmPuzzleBoard.btnRedRingIn.Enabled = True
                frmPuzzleBoard.btnYellowRingIn.Enabled = True
                frmPuzzleBoard.btnBlueRingIn.Enabled = True
            ElseIf currentPlayer = 3 Then
                frmPuzzleBoard.btnRedRingIn.Enabled = True
                frmPuzzleBoard.btnYellowRingIn.Enabled = True
                frmPuzzleBoard.btnBlueRingIn.Enabled = False
            End If
            If numberOfPlayers <> 1 Then
                startTossUp()
                frmPuzzleBoard.tmrTossUpRingIn.Start()
            End If
            currentPlayer = Nothing
            currentPlayerObject = Nothing
        End If
        solveMode = False
        If numberOfPlayers <> 1 Then
            solveAttempt = ""
        ElseIf numberOfPlayers = 1 And numberOfTurns = 0 Then
            solveAttempt = puzzle
        End If
        solveSortedList.Clear()
        solveTypedList.Clear()
        frmPuzzleBoard.btnSolvePass.Hide()
        My.Computer.Audio.Play(My.Resources.Buzzer, AudioPlayMode.Background)
        If (round = PuzzleType.TU1 Or round = PuzzleType.TU2 Or round = PuzzleType.TU3 Or round = PuzzleType.TBTU) And numberOfPlayers <> 1 Then
            My.Computer.Audio.Play(My.Resources.toss_up_new, AudioPlayMode.BackgroundLoop)
        ElseIf (round = PuzzleType.TU1 Or round = PuzzleType.TU2 Or round = PuzzleType.TU3 Or round = PuzzleType.TBTU) And numberOfPlayers = 1 Then
            solveAttempt = puzzle
        End If
    End Sub
#End Region
#Region "Load Letters"
    Public Shared Sub loadLetters(ByRef btn As Button)
        frmPuzzleBoard.btnSolve.Enabled = True
        turnTaken = False
        'If finalSpin = True Then
        '    previousValue = ""
        'End If
        Dim playerScore
        If currentPlayer > 0 Then
            playerScore = frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text.Replace("$", "")
            If playerScore = "" Then
                playerScore = 0
            End If
        Else
            playerScore = 0
        End If
        If solveMode = True Then
            frmPuzzleBoard.btnSolve.Enabled = False
            solveAttempt = ""
            If CType(frmPuzzleBoard.PuzzleBoard1.Controls("PuzzleBoardLetter" & currentSolveLetter), PuzzleBoardLetter).letterRevealed = False Then
                CType(frmPuzzleBoard.PuzzleBoard1.Controls("PuzzleBoardLetter" & currentSolveLetter), PuzzleBoardLetter).revealLetter(btn.Text)
            End If
            'letterBehind = LetterTypeControl.currentLetter
            'letter = LetterTypeControl.currentLetter
            'btnLetter.BackColor = Color.White
            If lastLetter = 0 Then
                For Each myLetterControl As PuzzleBoardLetter In frmPuzzleBoard.PuzzleBoard1.Controls
                    If myLetterControl.letterRevealed = False And myLetterControl.Visible = True Then
                        If CInt(myLetterControl.Name.Replace("PuzzleBoardLetter", "")) > lastLetter Then
                            lastLetter = CInt(myLetterControl.Name.Replace("PuzzleBoardLetter", ""))
                        End If
                    ElseIf CInt(myLetterControl.Name.Replace("PuzzleBoardLetter", "")) > lastLetter And myLetterControl.Visible = True Then
                        If CInt(myLetterControl.Name.Replace("PuzzleBoardLetter", "")) > lastLetter Then
                            lastLetter = CInt(myLetterControl.Name.Replace("PuzzleBoardLetter", ""))
                        End If
                    ElseIf CInt(myLetterControl.Name.Replace("PuzzleBoardLetter", "")) > lastLetter And myLetterControl.Visible = False Then
                        Continue For
                    End If
                Next
            End If
            'If firstLetter = 0 Or lastLetter = 0 Then
            '    For Each myLetterControl As PuzzleBoardLetter In frmPuzzleBoard.PuzzleBoard1.Controls
            '        If myLetterControl.letterRevealed = False And myLetterControl.Visible = True Then
            '            If firstLetter = 0 Then
            '                If CInt(myLetterControl.Name.Replace("PuzzleBoardLetter", "")) > firstLetter And firstLetter = 0 Then
            '                    firstLetter = CInt(myLetterControl.Name.Replace("PuzzleBoardLetter", ""))
            '                End If
            '            Else
            '                If CInt(myLetterControl.Name.Replace("PuzzleBoardLetter", "")) > lastLetter Then
            '                    lastLetter = CInt(myLetterControl.Name.Replace("PuzzleBoardLetter", ""))
            '                End If
            '            End If
            '        ElseIf CInt(myLetterControl.Name.Replace("PuzzleBoardLetter", "")) > lastLetter And firstLetter <> 0 And myLetterControl.Visible = True Then
            '            If CInt(myLetterControl.Name.Replace("PuzzleBoardLetter", "")) > lastLetter Then
            '                lastLetter = CInt(myLetterControl.Name.Replace("PuzzleBoardLetter", ""))
            '            End If
            '        ElseIf CInt(myLetterControl.Name.Replace("PuzzleBoardLetter", "")) > lastLetter And firstLetter <> 0 And myLetterControl.Visible = False Then
            '            Continue For
            '        End If
            '    Next
            'End If
            For Each myLetter As PuzzleBoardLetter In frmPuzzleBoard.PuzzleBoard1.Controls
                If myLetter.letterRevealed = False And myLetter.Visible = True Then
                    'If IsNothing(myLetter.btnLetter.BackgroundImage) = False And myLetter.Name.Replace("PuzzleBoardLetter", "") <> currentSolveLetter Then
                    '    solveSortedList(myLetter.Name.Replace("PuzzleBoardLetter", "")) = myLetter.letterBehind
                    'Else
                    If IsNothing(myLetter.btnLetter.BackgroundImage) = False And myLetter.Name.Replace("PuzzleBoardLetter", "") = currentSolveLetter Then
                        solveSortedList(myLetter.Name.Replace("PuzzleBoardLetter", "")) = btn.Text
                    End If
                    'ElseIf myLetter.Visible = False And CInt(myLetter.Name.Replace("PuzzleBoardLetter", "")) > firstLetter And CInt(myLetter.Name.Replace("PuzzleBoardLetter", "")) < lastLetter Then
                    '    'solveAttempt &= " "
                ElseIf myLetter.letterRevealed = True Then
                    solveSortedList(myLetter.Name.Replace("PuzzleBoardLetter", "")) = myLetter.letterBehind
                End If
            Next
            For Each item As KeyValuePair(Of Integer, String) In solveSortedList
                If crosswordStatus = 0 Then
                    solveAttempt &= item.Value
                Else
                    If item.Key <> solveSortedList.Last.Key Then
                        solveAttempt &= item.Value & item.Key & " "
                    Else
                        solveAttempt &= item.Value & item.Key
                    End If
                End If
            Next
            'If currentSolveIndex < solveTypedList.Count - 1 Then
            '    currentSolveIndex += 1
            '    currentSolveLetter = solveTypedList(currentSolveIndex)
            '    If CType(frmPuzzleBoard.PuzzleBoard1.Controls("PuzzleBoardLetter" & currentSolveLetter), PuzzleBoardLetter).Visible = True And CType(frmPuzzleBoard.PuzzleBoard1.Controls("PuzzleBoardLetter" & currentSolveLetter), PuzzleBoardLetter).letterRevealed = False Then
            '        CType(frmPuzzleBoard.PuzzleBoard1.Controls("PuzzleBoardLetter" & currentSolveLetter), PuzzleBoardLetter).btnLetter.BackColor = SystemColors.HotTrack
            '    End If
            'End If
            If currentSolveLetter < lastLetter Then
                previousSolveLetter = currentSolveLetter
                For i As Integer = currentSolveLetter To lastLetter
                    If i + 1 <> 53 Then
                        If CType(frmPuzzleBoard.PuzzleBoard1.Controls("PuzzleBoardLetter" & i + 1), PuzzleBoardLetter).Visible = True And CType(frmPuzzleBoard.PuzzleBoard1.Controls("PuzzleBoardLetter" & i + 1), PuzzleBoardLetter).letterRevealed = False Then
                            currentSolveLetter = i + 1
                            CType(frmPuzzleBoard.PuzzleBoard1.Controls("PuzzleBoardLetter" & currentSolveLetter), PuzzleBoardLetter).btnLetter.BackColor = Color.FromArgb(19, 28, 255)
                            Exit For
                            'ElseIf CType(frmPuzzleBoard.PuzzleBoard1.Controls("PuzzleBoardLetter" & i + 1), PuzzleBoardLetter).letterRevealed = True Then
                            '    currentSolveLetter = i + 1
                            '    CType(frmPuzzleBoard.PuzzleBoard1.Controls("PuzzleBoardLetter" & currentSolveLetter), PuzzleBoardLetter).btnLetter.BackColor = SystemColors.HotTrack
                            '    Exit For
                        Else
                            Continue For
                        End If
                    Else
                        Exit For
                    End If
                Next
            End If
            'MsgBox(finalString)
            If solveAttempt.Replace(" ", "").Length = puzzle.Replace(" ", "").Length Then
                frmPuzzleBoard.btnSolve.Enabled = True
            End If
            frmScore.usedLetterBoard.Enabled = True
        ElseIf ((previousValue = "Bankrupt" Or previousValue = "Lose A Turn") And CInt(playerScore) < 250) Or (previousValue = "Lose A Turn" And finalSpin = True) Or round = PuzzleType.TU1 Or round = PuzzleType.TU2 Or round = PuzzleType.TU3 Or round = PuzzleType.TBTU Then

        Else
            If round <> PuzzleType.BR Then
                frmScore.usedLetterBoard.Enabled = False
            Else
                frmScore.usedLetterBoard.Enabled = True
                'showUsedLettersInBonus()
                'previousValue = "Lose A Turn"
            End If
            currentLetter = btn.Text
            If finalSpin = False And GetConsonants(puzzleString) > 0 Then
                spun = False
                frmPuzzleBoard.wheelTilt.Enabled = True
            ElseIf round = PuzzleType.BR Then
                frmScore.usedLetterBoard.Enabled = True
                'showUsedLettersInBonus()
                'previousValue = "Lose A Turn"
            Else
                frmScore.usedLetterBoard.Enabled = False
                frmPuzzleBoard.wheelTilt.Enabled = False
            End If
            If roundType <> PuzzleType.BR Then
                If currentLetter = "A" Or currentLetter = "E" Or currentLetter = "I" Or currentLetter = "O" Or currentLetter = "U" Then
                    isVowel = True
                    'If currentPlayer = 1 Then
                    If frmScore.lblCurrentValue.Text = "Free Play" Or finalSpin = True Then
                    ElseIf CInt(playerScore) >= 250 Then
                        Dim currentPlayerValue = CInt(frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text.Replace("$", ""))
                        currentPlayerValue -= 250
                        If currentPlayerValue <> 0 Then
                            frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text = FormatCurrency(currentPlayerValue, 0)
                        Else
                            frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text = ""
                        End If
                    Else
                            frmScore.usedLetterBoard.Enabled = True
                        Exit Sub
                    End If
                    'ElseIf currentPlayer = 2 Then
                    '    If frmScore.lblCurrentValue.Text = "Free Play" Or finalSpin = True Then
                    '    ElseIf CInt(frmScore.lblPlayer2.Text.Replace("$", "")) >= 250 Then
                    '        Dim currentPlayerValue = CInt(frmScore.lblPlayer2.Text.Replace("$", ""))
                    '        currentPlayerValue -= 250
                    '        frmScore.lblPlayer2.Text = FormatCurrency(currentPlayerValue, 0)
                    '    Else
                    '        frmScore.usedLetterBoard.Enabled = True
                    '        Exit Sub
                    '    End If
                    'ElseIf currentPlayer = 3 Then
                    '    If frmScore.lblCurrentValue.Text = "Free Play" Or finalSpin = True Then
                    '    ElseIf CInt(frmScore.lblPlayer3.Text.Replace("$", "")) >= 250 Then
                    '        Dim currentPlayerValue = CInt(frmScore.lblPlayer3.Text.Replace("$", ""))
                    '        currentPlayerValue -= 250
                    '        frmScore.lblPlayer3.Text = FormatCurrency(currentPlayerValue, 0)
                    '    Else
                    '        frmScore.usedLetterBoard.Enabled = True
                    '        Exit Sub
                    '    End If
                    'End If
                Else
                    If frmScore.lblCurrentValue.Text = "0" And wildUsed = False And expressStatus = False And finalSpin = False Then
                        frmScore.usedLetterBoard.Enabled = True
                        Exit Sub
                    Else
                    End If
                End If
                If puzzle.Contains(currentLetter) Then
                    For Each letterControl As Control In frmPuzzleBoard.Controls(puzzleBoardName).Controls
                        If letterControl.GetType() Is GetType(PuzzleBoardLetter) Then
                            If CType(letterControl, PuzzleBoardLetter).letterBehind = currentLetter Then
                                letterControlList.Add(letterControl.Name.Replace("PuzzleBoardLetter", ""))
                                letterControlTappedList.Add(letterControl.Name.Replace("PuzzleBoardLetter", ""))
                                solveTypedList.Remove(letterControl.Name.Replace("PuzzleBoardLetter", ""))
                            End If
                        End If
                    Next
                    moneyValue = spinResult * letterControlList.Count
                    If finalSpin = True Then
                        previousValue = "Lose A Turn"
                    End If
                    frmScore.notifyBar.Text = revealNumberOfLetters()
                ElseIf Not puzzle.Contains(currentLetter) Then
                    If frmScore.lblCurrentValue.Text <> "Free Play" Then
                        frmScore.notifyBar.Text = revealNumberOfLetters()
                        isNoLetters = True
                        LoseATurn()
                        frmScore.usedLetterBoard.Enabled = True
                        If finalSpin = True Then
                            previousValue = ""
                        Else
                        End If
                    Else
                        frmScore.notifyBar.Text = revealNumberOfLetters()
                        isNoLetters = True
                        If virtualHost = True Then
                            SAPI.Speak("Because of the free play wedge, you don't lose your turn.")
                        End If
                        frmScore.usedLetterBoard.Enabled = True
                    End If
                    If finalSpin = True Then
                        previousValue = ""
                        btn.Enabled = False
                    ElseIf expressStatus = True Then
                        spinResult = 0
                        bankrupt()
                        btn.Enabled = False
                        frmPuzzleBoard.logoExpress.Hide()
                        frmPuzzleBoard.wheelTilt.Enabled = True
                        expressStatus = False
                    ElseIf expressStatus = False Or finalSpin = False Then
                        spinResult = 0
                        btn.Enabled = False
                    End If
                End If
                disableCurrentVowel()
                timeStart = DateTime.Now.Second
                frmScore.tmrLetterReveal.Start()
                If frmScore.lblCurrentValue.Text = "Mystery 1" And mysteryStatus = False Or frmScore.lblCurrentValue.Text = "Mystery 2" And mysteryStatus = False Then
                    If letterControlList.Count > 0 Then
                        MysteryDialog.ShowDialog()
                    Else
                    End If
                End If
                If frmScore.lblCurrentValue.Text = "Express" And expressStatus = False Then
                    If letterControlList.Count > 0 Then
                        ExpressDialog.ShowDialog()
                    Else
                    End If
                End If
                'If currentPlayer = 1 Then
                If isVowel = False And Not frmScore.lblCurrentValue.Text = "Mystery 1" AndAlso isVowel = False And Not frmScore.lblCurrentValue.Text = "Mystery 2" And Not frmScore.lblCurrentValue.Text = "Million" And Not frmScore.lblCurrentValue.Text = "Gift" And Not frmScore.lblCurrentValue.Text = "Prize" Then
                    Dim currentPlayerValue = CType(frmScore.pnlScore.Controls("lblPlayer" & currentPlayer), Label).Text.Replace("$", "")
                    If currentPlayerValue = "" Then
                        currentPlayerValue = 0
                    Else
                        currentPlayerValue = CInt(CType(frmScore.pnlScore.Controls("lblPlayer" & currentPlayer), Label).Text.Replace("$", ""))
                    End If
                    currentPlayerValue += spinResult * letterControlList.Count
                    If currentPlayerValue = 0 Then
                        frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text = ""
                    Else
                        frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text = FormatCurrency(currentPlayerValue, 0)
                    End If
                Else
                    btn.Enabled = False
                End If
                If currentLetter = sameLetter And category = "SAME LETTER" Then
                    Dim currentPlayer1Value = CInt(frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text.Replace("$", ""))
                    If currentPlayer1Value = "" Then
                        currentPlayer1Value = 0
                    End If
                    currentPlayer1Value += 1000
                    frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text = ""
                    If virtualHost = True Then
                        SAPI.Speak("That's the Same Letter. You get an extra $1,000.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                    End If
                End If
                'ElseIf currentPlayer = 2 Then
                '    If isVowel = False And Not frmScore.lblCurrentValue.Text = "Mystery 1" AndAlso isVowel = False And Not frmScore.lblCurrentValue.Text = "Mystery 2" Then
                '        Dim currentPlayerValue = CInt(frmScore.lblPlayer2.Text.Replace("$", ""))
                '        currentPlayerValue += spinResult * letterControlList.Count
                '        frmScore.lblPlayer2.Text = FormatCurrency(currentPlayerValue, 0)
                '        If currentLetter = sameLetter And category = "SAME LETTER" Then
                '            Dim currentPlayer2Value = CInt(frmScore.lblPlayer2.Text.Replace("$", ""))
                '            currentPlayer2Value += 1000
                '            frmScore.lblPlayer2.Text = FormatCurrency(currentPlayer2Value, 0)
                '        End If
                '    Else
                '        btn.Enabled = False
                '    End If
                'ElseIf currentPlayer = 3 Then
                '    If isVowel = False And Not frmScore.lblCurrentValue.Text = "Mystery 1" AndAlso isVowel = False And Not frmScore.lblCurrentValue.Text = "Mystery 2" Then
                '        Dim currentPlayerValue = CInt(frmScore.lblPlayer3.Text.Replace("$", ""))
                '        currentPlayerValue += spinResult * letterControlList.Count
                '        frmScore.lblPlayer3.Text = FormatCurrency(currentPlayerValue, 0)
                '        If currentLetter = sameLetter And category = "SAME LETTER" Then
                '            Dim currentPlayer3Value = CInt(frmScore.lblPlayer3.Text.Replace("$", ""))
                '            currentPlayer3Value += 1000
                '            frmScore.lblPlayer3.Text = FormatCurrency(currentPlayer3Value, 0)
                '        End If
                '    Else
                '        btn.Enabled = False
                '    End If
                'End If
                If puzzle.Contains(btn.Text) Then
                    If frmScore.lblCurrentValue.Text = "1/2 Car" And halfCar1Status = False Or frmScore.lblCurrentValue.Text = "1/2 Car" And halfCar2Status = False Then
                        If frmScore.halfcar1.Visible = False And frmScore.halfcar2.Visible = False Or frmScore.halfcar2.Visible = True Then
                            'SAPI = CreateObject("SAPI.spvoice")
                            If virtualHost = True Then
                                SAPI.Speak("Pick up the half car.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                                If round = PuzzleType.R3 And Not (currentPlayerObject.getWedges(Player.Wedges.HalfCar1) And currentPlayerObject.getWedges(Player.Wedges.HalfCar2)) Then
                                    SAPI.Speak("It's the last round to get the other half.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                                End If
                            End If
                            currentPlayerObject.addCardsOrWedges(Player.Wedges.HalfCar1, True)
                            halfCar1Status = True
                            wheelWedges(7) = 500
                            wheelWedges(8) = 500
                            wheelWedges(9) = 500
                            frmScore.halfcar1.Show()
                            frmScore.lblCurrentValue.Text = 0
                            spinResult = 0
                            isVowel = False
                        ElseIf frmScore.halfcar1.Visible = True And frmScore.halfcar2.Visible = False Then
                            'SAPI = CreateObject("SAPI.spvoice")
                            If virtualHost = True Then
                                SAPI.Speak("Pick up the half car.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                                'If round = PuzzleType.R3 And Not (currentPlayerObject.getWedges(Player.Wedges.HalfCar1) And currentPlayerObject.getWedges(Player.Wedges.HalfCar2)) Then
                                '    SAPI.Speak("It's the last round to get the other half.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                                'End If
                            End If
                            currentPlayerObject.addCardsOrWedges(Player.Wedges.HalfCar2, True)
                            halfCar2Status = True
                            wheelWedges(37) = 500
                            wheelWedges(38) = 500
                            wheelWedges(39) = 500
                            frmScore.halfcar2.Show()
                            frmScore.lblCurrentValue.Text = 0
                            spinResult = 0
                            isVowel = False
                        End If
                    End If
                    If frmScore.lblCurrentValue.Text = "Million" And millionStatus = False Then
                        'SAPI = CreateObject("SAPI.spvoice")
                        If virtualHost = True Then
                            SAPI.Speak("Pick up the million dollars. You still have a long way to go. Don't let it distract you. You can't spend any of that million.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                        End If
                        currentPlayerObject.addCardsOrWedges(Player.Wedges.Million, True)
                        wheelWedges(46) = "500"
                        wheelWedges(47) = "500"
                        wheelWedges(48) = "500"
                        millionStatus = True
                        frmScore.Million.Show()
                    End If
                    If frmScore.lblCurrentValue.Text = "Wild" And wildCardStatus = False Then
                        'SAPI = CreateObject("SAPI.spvoice")
                        If virtualHost = True Then
                            SAPI.Speak("Pick up the Wild card.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                        End If
                        currentPlayerObject.addCardsOrWedges(Player.Wedges.Wild, True)
                        frmPuzzleBoard.btnWild.Show()
                        wheelWedges(67) = "500"
                        wheelWedges(68) = "500"
                        wheelWedges(69) = "500"
                        wildCardStatus = True
                        frmScore.Wild.Show()
                    End If
                    If frmScore.lblCurrentValue.Text = "Gift" And giftStatus = False Then
                        If virtualHost = True Then
                            'SAPI = CreateObject("SAPI.spvoice")
                            SAPI.Speak("Pick up the gift tag. It's a thousand dollars courtesy of our sponsor.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                        End If
                        currentPlayerObject.addCardsOrWedges(Player.Wedges.Gift, True)
                        wheelWedges(52) = "500"
                        wheelWedges(53) = "500"
                        wheelWedges(54) = "500"
                        giftStatus = True
                        frmScore.Gift.Show()
                    End If
                    If frmScore.lblCurrentValue.Text = "Prize" And prizeStatus = False Then
                        If virtualHost = True Then
                            'SAPI = CreateObject("SAPI.spvoice")
                            SAPI.Speak("Pick up the trip. It's worth over $10,000.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                        End If
                        currentPlayerObject.addCardsOrWedges(Player.Wedges.Prize, True)
                        wheelWedges(13) = "500"
                        wheelWedges(14) = "500"
                        wheelWedges(15) = "500"
                        prizeStatus = True
                        frmScore.Prize.Show()
                    End If
                    '    ElseIf currentPlayer = 2 And puzzle.Contains(btn.Text) Then
                    '        If frmScore.lblCurrentValue.Text = "1/2 Car" And halfCar1Status = False Or frmScore.lblCurrentValue.Text = "1/2 Car" And halfCar2Status = False Then
                    '            If frmScore.halfcar1.Visible = False And frmScore.halfcar2.Visible = False Or frmScore.halfcar2.Visible = True Then
                    '                player2.addCardsOrWedges(Player.Wedges.HalfCar1, True)
                    '                halfCar1Status = True
                    '                wheelWedges(7) = 500
                    '                wheelWedges(8) = 500
                    '                wheelWedges(9) = 500
                    '                frmScore.halfcar1.Show()
                    '                frmScore.lblCurrentValue.Text = 0
                    '                spinResult = 0
                    '                isVowel = False
                    '            ElseIf frmScore.halfcar1.Visible = True And frmScore.halfcar2.Visible = False Then
                    '                player2.addCardsOrWedges(Player.Wedges.HalfCar2, True)
                    '                halfCar2Status = True
                    '                wheelWedges(37) = 500
                    '                wheelWedges(38) = 500
                    '                wheelWedges(39) = 500
                    '                frmScore.halfcar2.Show()
                    '                frmScore.lblCurrentValue.Text = 0
                    '                spinResult = 0
                    '                isVowel = False
                    '            End If
                    '        End If
                    '        If frmScore.lblCurrentValue.Text = "Million" And millionStatus = False Then
                    '            player2.addCardsOrWedges(Player.Wedges.Million, True)
                    '            millionStatus = True
                    '            frmScore.Million.Show()
                    '        End If
                    '        If frmScore.lblCurrentValue.Text = "Wild" And wildCardStatus = False Then
                    '            player2.addCardsOrWedges(Player.Wedges.Wild, True)
                    '            wildCardStatus = True
                    '            frmPuzzleBoard.btnWild.Show()
                    '            frmScore.Wild.Show()
                    '        End If
                    '        If frmScore.lblCurrentValue.Text = "Gift" And giftStatus = False Then
                    '            player2.addCardsOrWedges(Player.Wedges.Gift, True)
                    '            giftStatus = True
                    '            frmScore.Gift.Show()
                    '        End If
                    '        If frmScore.lblCurrentValue.Text = "Prize" And prizeStatus = False Then
                    '            player2.addCardsOrWedges(Player.Wedges.Prize, True)
                    '            prizeStatus = True
                    '            frmScore.Prize.Show()
                    '        End If
                    '    ElseIf currentPlayer = 3 And puzzle.Contains(btn.Text) Then
                    '        If frmScore.lblCurrentValue.Text = "1/2 Car" And halfCar1Status = False Or frmScore.lblCurrentValue.Text = "1/2 Car" And halfCar2Status = False Then
                    '            If frmScore.halfcar1.Visible = False And frmScore.halfcar2.Visible = False Or frmScore.halfcar2.Visible = True Then
                    '                player3.addCardsOrWedges(Player.Wedges.HalfCar1, True)
                    '                halfCar1Status = True
                    '                wheelWedges(7) = 500
                    '                wheelWedges(8) = 500
                    '                wheelWedges(9) = 500
                    '                frmScore.halfcar1.Show()
                    '                frmScore.lblCurrentValue.Text = 0
                    '                spinResult = 0
                    '                isVowel = False
                    '            ElseIf frmScore.halfcar1.Visible = True And frmScore.halfcar2.Visible = False Then
                    '                player3.addCardsOrWedges(Player.Wedges.HalfCar2, True)
                    '                halfCar2Status = True
                    '                wheelWedges(37) = 500
                    '                wheelWedges(38) = 500
                    '                wheelWedges(39) = 500
                    '                frmScore.halfcar2.Show()
                    '                frmScore.lblCurrentValue.Text = 0
                    '                spinResult = 0
                    '                isVowel = False
                    '            End If
                    '        End If
                    '        If frmScore.lblCurrentValue.Text = "Million" And millionStatus = False Then
                    '            player3.addCardsOrWedges(Player.Wedges.Million, True)
                    '            millionStatus = True
                    '            frmScore.Million.Show()
                    '        End If
                    '        If frmScore.lblCurrentValue.Text = "Wild" And wildCardStatus = False Then
                    '            player3.addCardsOrWedges(Player.Wedges.Wild, True)
                    '            wildCardStatus = True
                    '            frmPuzzleBoard.btnWild.Show()
                    '            frmScore.Wild.Show()
                    '        End If
                    '        If frmScore.lblCurrentValue.Text = "Gift" And giftStatus = False Then
                    '            player3.addCardsOrWedges(Player.Wedges.Gift, True)
                    '            giftStatus = True
                    '            frmScore.Gift.Show()
                    '        End If
                    '        If frmScore.lblCurrentValue.Text = "Prize" And prizeStatus = False Then
                    '            player3.addCardsOrWedges(Player.Wedges.Prize, True)
                    '            prizeStatus = True
                    '            frmScore.Prize.Show()
                    '        End If
                End If
                btn.Enabled = False
            Else
                frmPuzzleBoard.lblChosenLetters.Text &= " " & btn.Text
                If selectedBonusLetters.Count <= 4 And bonusRoundPlayer.getWedges(Player.Wedges.Wild) = False OrElse selectedBonusLetters.Count <= 5 And bonusRoundPlayer.getWedges(Player.Wedges.Wild) = True Then
                    selectedBonusLetters.Add(btn.Text)
                    btn.Enabled = False
                    If currentLetter = "A" Or currentLetter = "E" Or currentLetter = "I" Or currentLetter = "O" Or currentLetter = "U" Then
                        If currentLetter = "A" Then
                            aEnabled = False
                        ElseIf currentLetter = "E" Then
                            eEnabled = False
                        ElseIf currentLetter = "I" Then
                            iEnabled = False
                        ElseIf currentLetter = "O" Then
                            oEnabled = False
                        ElseIf currentLetter = "U" Then
                            uEnabled = False
                        End If
                        selectedVowel = currentLetter
                    End If
                ElseIf selectedBonusLetters.Count = 4 And bonusRoundPlayer.getWedges(Player.Wedges.Wild) = False OrElse selectedBonusLetters.Count = 5 And bonusRoundPlayer.getWedges(Player.Wedges.Wild) = True Then
                    btn.Enabled = False
                    frmScore.btnBonusTimerStart.Show()
                ElseIf selectedBonusLetters.Count = 4 And bonusRoundPlayer.getWedges(Player.Wedges.Wild) = True Then
                    If virtualHost = True Then
                        SAPI.Speak("Because of this Wild card, you can pick an extra consonant.")
                    End If
                End If
            End If
            'If currentPlayer = 1 Then
            Dim myValue = frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text.Replace("$", "")
            If myValue = "" Then
                myValue = 0
            End If
            If CInt(myValue) >= 250 Or finalSpinSpun = True Or bonusVowelsEnabled = True Then
                If round <> PuzzleType.BR Then
                    enableVowels(True)
                Else
                    enableBonusVowels(True)
                End If
            Else
                If round <> PuzzleType.BR Then
                    enableVowels(False)
                ElseIf round = PuzzleType.BR And lettersSelected = True Then
                    previousValue = "Lose A Turn"
                    vowelModeEnabled = True
                    'showUsedLettersInBonus()
                End If
            End If
            'ElseIf currentPlayer = 2 Then
            '    If CInt(frmScore.lblPlayer2.Text.Replace("$", "")) >= 250 Or finalSpinSpun = True Then
            '        enableVowels(True)
            '    Else
            '        enableVowels(False)
            '    End If
            'ElseIf currentPlayer = 3 Then
            '    If CInt(frmScore.lblPlayer3.Text.Replace("$", "")) >= 250 Or finalSpinSpun = True Then
            '        enableVowels(True)
            '    Else
            '        enableVowels(False)
            '    End If
            'End If
            Dim letterSelected = btn.Text
            puzzleString = puzzleString.Replace(letterSelected, "")
            If finalSpin = True And Not puzzle.Contains(currentLetter) Then
                previousValue = ""
            End If
            If finalSpin = False And expressStatus = False Then
                frmScore.lblCurrentValue.Text = 0
            End If
            isVowel = False
        End If
        If System.Text.RegularExpressions.Regex.IsMatch(Trim(puzzleString), "^[0-9 ]+$") Or Trim(puzzleString) = "" Then
            enableConsonants(False)
            enableVowels(False)
            If virtualHost = True Then
                SAPI.Speak("Tell me what's up there.")
            End If
            solveAttempt = puzzle
            solved = True
        Else
        End If
    End Sub
    Public Shared Sub backspaceLetter()
        For i As Integer = lastLetter To 1 Step -1
            CType(frmPuzzleBoard.PuzzleBoard1.Controls("PuzzleBoardLetter" & i), PuzzleBoardLetter).btnLetter.BackColor = Color.White
        Next
        For i As Integer = currentSolveLetter To 1 Step -1
            If CType(frmPuzzleBoard.PuzzleBoard1.Controls("PuzzleBoardLetter" & i - 1), PuzzleBoardLetter).Visible = True And CType(frmPuzzleBoard.PuzzleBoard1.Controls("PuzzleBoardLetter" & i - 1), PuzzleBoardLetter).letterRevealed = False Then
                CType(frmPuzzleBoard.PuzzleBoard1.Controls("PuzzleBoardLetter" & i), PuzzleBoardLetter).btnLetter.BackColor = Color.White
                'CType(frmPuzzleBoard.PuzzleBoard1.Controls("PuzzleBoardLetter" & i), PuzzleBoardLetter).btnLetter.BackgroundImage = Nothing
                currentSolveLetter = i - 1
                CType(frmPuzzleBoard.PuzzleBoard1.Controls("PuzzleBoardLetter" & i - 1), PuzzleBoardLetter).btnLetter.BackgroundImage = Nothing
                CType(frmPuzzleBoard.PuzzleBoard1.Controls("PuzzleBoardLetter" & i - 1), PuzzleBoardLetter).btnLetter.BackColor = Color.FromArgb(19, 28, 255)
                Exit For
                'ElseIf CType(frmPuzzleBoard.PuzzleBoard1.Controls("PuzzleBoardLetter" & i + 1), PuzzleBoardLetter).letterRevealed = True Then
                '    currentSolveLetter = i + 1
                '    CType(frmPuzzleBoard.PuzzleBoard1.Controls("PuzzleBoardLetter" & currentSolveLetter), PuzzleBoardLetter).btnLetter.BackColor = SystemColors.HotTrack
                '    Exit For
            Else
                Continue For
            End If
        Next
    End Sub
#End Region
#Region "Disable Current Vowel"
    Public Shared Sub disableCurrentVowel()
        If currentLetter = "A" Then
            aEnabled = False
        ElseIf currentLetter = "E" Then
            eEnabled = False
        ElseIf currentLetter = "I" Then
            iEnabled = False
        ElseIf currentLetter = "O" Then
            oEnabled = False
        ElseIf currentLetter = "U" Then
            uEnabled = False
        End If
    End Sub
#End Region
#Region "Check Player"
    Public Shared Sub checkPlayer()
        frmScore.lblControllerSpinResult.Text = spinResult
        If frmScore.lblCurrentValue.Text = "Free Play" Then
            frmPuzzleBoard.btnSolve.Enabled = True
        End If
        If currentPlayer = 1 Then
            'frmScore.NameTag1.lblName.Text = player1Name
            frmScore.usedLetterBoard.BackColor = Color.Red
            frmScore.player1LeftArrow.Show()
            frmScore.player1RightArrow.Show()
            frmScore.player2LeftArrow.Hide()
            frmScore.player2RightArrow.Hide()
            frmScore.player3LeftArrow.Hide()
            frmScore.player3RightArrow.Hide()
            Dim myPlayer1Score = frmScore.lblPlayer1.Text.Replace("$", "")
            If myPlayer1Score = "" Then
                myPlayer1Score = 0
            End If
            If CInt(myPlayer1Score) >= 250 And solveMode = False And spun = False And noMoreVowelsShown = False Or frmScore.lblCurrentValue.Text = "Free Play" And noMoreVowelsShown = False Or finalSpin = True Or bonusVowelsEnabled = True Then
                If round <> PuzzleType.BR Then
                    enableVowels(True)
                Else
                    enableBonusVowels(True)
                End If
            ElseIf solveMode = True Then
                If round <> PuzzleType.BR Then
                    enableVowels(True)
                Else
                    enableBonusVowels(True)
                End If
            Else
                If round <> PuzzleType.BR Then
                    enableVowels(False)
                ElseIf lettersSelected = True Then
                    previousValue = "Lose A Turn"
                    vowelModeEnabled = True
                    'showUsedLettersInBonus()
                End If
            End If
            If player1.getWedges(Player.Wedges.HalfCar1) = True Then
                frmScore.halfcar1.Show()
            ElseIf player1.getWedges(Player.Wedges.HalfCar1) = False Then
                frmScore.halfcar1.Hide()
            End If
            If player1.getWedges(Player.Wedges.HalfCar2) = True Then
                frmScore.halfcar2.Show()
            ElseIf player1.getWedges(Player.Wedges.HalfCar2) = False Then
                frmScore.halfcar2.Hide()
            End If
            If player1.getWedges(Player.Wedges.Million) = True Then
                frmScore.Million.Show()
            ElseIf player1.getWedges(Player.Wedges.Million) = False Then
                frmScore.Million.Hide()
            End If
            If player1.getWedges(Player.Wedges.Wild) = True Then
                frmScore.Wild.Show()
                If round <> PuzzleType.BR Then
                    frmPuzzleBoard.btnWild.Show()
                Else
                    frmPuzzleBoard.btnWild.Hide()
                End If
            ElseIf player1.getWedges(Player.Wedges.Wild) = False Then
                frmScore.Wild.Hide()
                frmPuzzleBoard.btnWild.Hide()
            End If
            If player1.getWedges(Player.Wedges.Gift) = True Then
                frmScore.Gift.Show()
            ElseIf player1.getWedges(Player.Wedges.Gift) = False Then
                frmScore.Gift.Hide()
            End If
            If player1.getWedges(Player.Wedges.Prize) = True Then
                frmScore.Prize.Show()
            ElseIf player1.getWedges(Player.Wedges.Prize) = False Then
                frmScore.Prize.Hide()
            End If
            If player1.getWedges(Player.Wedges.Mystery) = True Then
                frmScore.Mystery.Show()
            ElseIf player1.getWedges(Player.Wedges.Mystery) = False Then
                frmScore.Mystery.Hide()
            End If
        ElseIf currentPlayer = 2 Then
            'frmScore.NameTag1.lblName.Text = player2Name
            frmScore.usedLetterBoard.BackColor = Color.Gold
            frmScore.player1LeftArrow.Hide()
            frmScore.player1RightArrow.Hide()
            frmScore.player2LeftArrow.Show()
            frmScore.player2RightArrow.Show()
            frmScore.player3LeftArrow.Hide()
            frmScore.player3RightArrow.Hide()
            Dim myPlayer2Score = frmScore.lblPlayer2.Text.Replace("$", "")
            If myPlayer2Score = "" Then
                myPlayer2Score = 0
            End If
            If CInt(myPlayer2Score) >= 250 And solveMode = False And spun = False And noMoreVowelsShown = False Or frmScore.lblCurrentValue.Text = "Free Play" And noMoreVowelsShown = False Or finalSpin = True Or bonusVowelsEnabled = True Then
                If round <> PuzzleType.BR Then
                    enableVowels(True)
                Else
                    enableBonusVowels(True)
                End If
            ElseIf solveMode = True Then
                If round <> PuzzleType.BR Then
                    enableVowels(True)
                Else
                    enableBonusVowels(True)
                End If
            Else
                If round <> PuzzleType.BR Then
                    enableVowels(False)
                ElseIf lettersSelected = True Then
                    previousValue = "Lose A Turn"
                    vowelModeEnabled = True
                    'showUsedLettersInBonus()
                End If
            End If
            If player2.getWedges(Player.Wedges.HalfCar1) = True Then
                frmScore.halfcar1.Show()
            ElseIf player2.getWedges(Player.Wedges.HalfCar1) = False Then
                frmScore.halfcar1.Hide()
            End If
            If player2.getWedges(Player.Wedges.HalfCar2) = True Then
                frmScore.halfcar2.Show()
            ElseIf player2.getWedges(Player.Wedges.HalfCar2) = False Then
                frmScore.halfcar2.Hide()
            End If
            If player2.getWedges(Player.Wedges.Million) = True Then
                frmScore.Million.Show()
            ElseIf player2.getWedges(Player.Wedges.Million) = False Then
                frmScore.Million.Hide()
            End If
            If player2.getWedges(Player.Wedges.Wild) = True Then
                frmScore.Wild.Show()
                If round <> PuzzleType.BR Then
                    frmPuzzleBoard.btnWild.Show()
                Else
                    frmPuzzleBoard.btnWild.Hide()
                End If
            ElseIf player2.getWedges(Player.Wedges.Wild) = False Then
                frmScore.Wild.Hide()
                frmPuzzleBoard.btnWild.Hide()
            End If
            If player2.getWedges(Player.Wedges.Gift) = True Then
                frmScore.Gift.Show()
            ElseIf player2.getWedges(Player.Wedges.Gift) = False Then
                frmScore.Gift.Hide()
            End If
            If player2.getWedges(Player.Wedges.Prize) = True Then
                frmScore.Prize.Show()
            ElseIf player2.getWedges(Player.Wedges.Prize) = False Then
                frmScore.Prize.Hide()
            End If
            If player2.getWedges(Player.Wedges.Mystery) = True Then
                frmScore.Mystery.Show()
            ElseIf player2.getWedges(Player.Wedges.Mystery) = False Then
                frmScore.Mystery.Hide()
            End If
        ElseIf currentPlayer = 3 Then
            'frmScore.NameTag1.lblName.Text = player3Name
            frmScore.usedLetterBoard.BackColor = Color.FromArgb(0, 45, 192)
            frmScore.player1LeftArrow.Hide()
            frmScore.player1RightArrow.Hide()
            frmScore.player2LeftArrow.Hide()
            frmScore.player2RightArrow.Hide()
            frmScore.player3LeftArrow.Show()
            frmScore.player3RightArrow.Show()
            Dim myPlayer3Score = frmScore.lblPlayer3.Text.Replace("$", "")
            If myPlayer3Score = "" Then
                myPlayer3Score = 0
            End If
            If CInt(myPlayer3Score) >= 250 And solveMode = False And spun = False And noMoreVowelsShown = False Or frmScore.lblCurrentValue.Text = "Free Play" And noMoreVowelsShown = False Or finalSpin = True Or bonusVowelsEnabled = True Then
                If round <> PuzzleType.BR Then
                    enableVowels(True)
                Else
                    enableBonusVowels(True)
                End If
            ElseIf solveMode = True Then
                If round <> PuzzleType.BR Then
                    enableVowels(True)
                Else
                    enableBonusVowels(True)
                End If
            Else
                If round <> PuzzleType.BR Then
                    enableVowels(False)
                ElseIf lettersSelected = True Then
                    'showUsedLettersInBonus()
                    vowelModeEnabled = True
                    previousValue = "Lose A Turn"
                End If
            End If
            If player3.getWedges(Player.Wedges.HalfCar1) = True Then
                frmScore.halfcar1.Show()
            ElseIf player3.getWedges(Player.Wedges.HalfCar1) = False Then
                frmScore.halfcar1.Hide()
            End If
            If player3.getWedges(Player.Wedges.HalfCar2) = True Then
                frmScore.halfcar2.Show()
            ElseIf player3.getWedges(Player.Wedges.HalfCar2) = False Then
                frmScore.halfcar2.Hide()
            End If
            If player3.getWedges(Player.Wedges.Million) = True Then
                frmScore.Million.Show()
            ElseIf player3.getWedges(Player.Wedges.Million) = False Then
                frmScore.Million.Hide()
            End If
            If player3.getWedges(Player.Wedges.Wild) = True Then
                frmScore.Wild.Show()
                If round <> PuzzleType.BR Then
                    frmPuzzleBoard.btnWild.Show()
                Else
                    frmPuzzleBoard.btnWild.Hide()
                End If
            ElseIf player3.getWedges(Player.Wedges.Wild) = False Then
                frmScore.Wild.Hide()
                frmPuzzleBoard.btnWild.Hide()
            End If
            If player3.getWedges(Player.Wedges.Gift) = True Then
                frmScore.Gift.Show()
            ElseIf player3.getWedges(Player.Wedges.Gift) = False Then
                frmScore.Gift.Hide()
            End If
            If player3.getWedges(Player.Wedges.Prize) = True Then
                frmScore.Prize.Show()
            ElseIf player3.getWedges(Player.Wedges.Prize) = False Then
                frmScore.Prize.Hide()
            End If
            If player3.getWedges(Player.Wedges.Mystery) = True Then
                frmScore.Mystery.Show()
            ElseIf player3.getWedges(Player.Wedges.Mystery) = False Then
                frmScore.Mystery.Hide()
            End If
        Else
            frmScore.player1LeftArrow.Hide()
            frmScore.player1RightArrow.Hide()
            frmScore.player2LeftArrow.Hide()
            frmScore.player2RightArrow.Hide()
            frmScore.player3LeftArrow.Hide()
            frmScore.player3RightArrow.Hide()
        End If
        If roundType = PuzzleType.BR Then
            If (selectedBonusLetters.Count = 3 And bonusRoundPlayer.getWedges(Player.Wedges.Wild) = False) And lettersSelected = False Then
                If bonusVowelsEnabled = False Then
                    enableBonusVowels(True)
                    'vowelModeEnabled = True
                End If
            ElseIf (selectedBonusLetters.Count = 3 And bonusRoundPlayer.getWedges(Player.Wedges.Wild) = True) And lettersSelected = False Then
                If bonusVowelsEnabled = False Then
                    enableBonusVowels(True)
                    'vowelModeEnabled = True
                End If
            ElseIf (selectedBonusLetters.Count = 4 And bonusRoundPlayer.getWedges(Player.Wedges.Wild) = True) And lettersSelected = False Then
                frmPuzzleBoard.pboxWild.Show()
                SAPI.Speak("Because of this Wild card, you can pick an extra consonant.")
                showUsedLettersInBonus()
                If bonusVowelsEnabled = True Then
                    enableBonusVowels(False)
                    vowelModeEnabled = False
                End If
            ElseIf (selectedBonusLetters.Count < 3) And lettersSelected = False Then
                If bonusVowelsEnabled = True Then
                    enableBonusVowels(False)
                    vowelModeEnabled = False
                End If
            ElseIf (selectedBonusLetters.Count = 4 And bonusRoundPlayer.getWedges(Player.Wedges.Wild) = False Or selectedBonusLetters.Count = 5 And bonusRoundPlayer.getWedges(Player.Wedges.Wild) = True) And lettersSelected = False Then
                'enableBonusVowels(True)
                'bonusVowelsEnabled = True
                loadBonusLetters()
                lettersSelected = True
                'vowelModeEnabled = True
                showUsedLettersInBonus()
                frmPuzzleBoard.pboxWild.Hide()
                previousValue = "Lose A Turn"
                frmScore.btnBonusTimerStart.Show()
                selectedBonusLetters.Clear()
                frmScore.usedLetterBoard.Controls("btn" & selectedVowel).Enabled = False
                'If bonusVowelsEnabled = False Then
                '    enableBonusVowels(True)
                'End If
            End If
        End If
    End Sub
#End Region
#Region "Load Toss Up"
    Public Shared Sub loadTossUp()
        If round = PuzzleType.TU1 Then
            frmPuzzleBoard.pboxTossUp.Image = My.Resources.Toss_Up_1000
        ElseIf round = PuzzleType.TU2 Then
            frmPuzzleBoard.pboxTossUp.Image = My.Resources.Toss_Up_2000
        ElseIf round = PuzzleType.TU3 Then
            frmPuzzleBoard.pboxTossUp.Image = My.Resources.Toss_Up_3000
        ElseIf round = PuzzleType.TBTU Then
            frmPuzzleBoard.pboxTossUp.Image = My.Resources.Toss_Up_1000
        End If
        'frmPuzzleBoard.pboxTossUp.Show()
        My.Computer.Audio.Play(My.Resources.toss_up_reveal, AudioPlayMode.Background)
        tossUpRevealTimeStart = DateTime.Now.Second
        frmPuzzleBoard.tmrTossUpReveal.Start()
    End Sub
#End Region
#Region "Check Ring-in"
    Public Shared Sub checkRingIn()
        If My.Computer.Keyboard.CtrlKeyDown And player1RingIn = False Then
            player1RingIn = True
            My.Computer.Audio.Play(My.Resources.Ding, AudioPlayMode.Background)
            currentPlayer = 1
            frmPuzzleBoard.btnYellowRingIn.Enabled = False
            frmPuzzleBoard.btnBlueRingIn.Enabled = False
            frmPuzzleBoard.tmrTossUpRingIn.Stop()
            frmPuzzleBoard.tmrTossUp.Stop()
            If typeToSolve = True Then
                If previewMode = False Then
                    solvePuzzle(False)
                Else
                    solvePuzzle(True)
                End If
            End If
        ElseIf My.Computer.Keyboard.AltKeyDown And player2RingIn = False Then
                player2RingIn = True
                My.Computer.Audio.Play(My.Resources.Ding, AudioPlayMode.Background)
                currentPlayer = 2
                frmPuzzleBoard.btnRedRingIn.Enabled = False
                frmPuzzleBoard.btnBlueRingIn.Enabled = False
            frmPuzzleBoard.tmrTossUpRingIn.Stop()
            frmPuzzleBoard.tmrTossUp.Stop()
            If typeToSolve = True Then
                If previewMode = False Then
                    solvePuzzle(False)
                Else
                    solvePuzzle(True)
                End If
            End If
        ElseIf My.Computer.Keyboard.ShiftKeyDown And player3RingIn = False Then
                player3RingIn = True
            My.Computer.Audio.Play(My.Resources.Ding, AudioPlayMode.Background)
            currentPlayer = 3
            frmPuzzleBoard.btnYellowRingIn.Enabled = False
            frmPuzzleBoard.btnRedRingIn.Enabled = False
            frmPuzzleBoard.tmrTossUpRingIn.Stop()
            frmPuzzleBoard.tmrTossUp.Stop()
            If typeToSolve = True Then
                If previewMode = False Then
                    solvePuzzle(False)
                Else
                    solvePuzzle(True)
                End If
            End If
        End If
            If player1RingIn = True And player2RingIn = True And player3RingIn = True And Not numberOfPlayers = 1 Then
            allRungIn = True
            For Each lettersControls As Control In frmPuzzleBoard.Controls(puzzleBoardName).Controls
                If lettersControls.GetType() Is GetType(PuzzleBoardLetter) Then
                    CType(lettersControls, PuzzleBoardLetter).revealLetter()
                End If
            Next
            currentPlayer = Nothing
            'tmrTossUp.Stop()
            'tmrTossUpRingIn.Stop()
        End If
    End Sub
#End Region
#Region "Reset Puzzle"
    Public Shared Sub resetPuzzle()
        'solveAttempt = ""
        'solveSortedList.Clear()
        letterSortedList.Clear()
        letterList.Clear()
        Dim numberOfPrizes = 0
        noMoreVowelsShown = False
        noMoreConsonantsShown = False
        SAPI = CreateObject("SAPI.spvoice")
        Dim otherPrizes = False
        Dim currentPlayerWinner As Player
        If currentPlayerObject Is Nothing Then
        ElseIf Not currentPlayerObject Is Nothing And round <> PuzzleType.BR Then
            revealPuzzleWinner()
            For i As Integer = 1 To 3
                If i = 1 Then
                    currentPlayerWinner = player1
                ElseIf i = 2 Then
                    currentPlayerWinner = player2
                ElseIf i = 3 Then
                    currentPlayerWinner = player3
                End If
                If currentPlayer = 1 Then
                    frmScore.pnlScore.Controls("lblPlayer2").Text = ""
                    frmScore.pnlScore.Controls("lblPlayer3").Text = ""
                ElseIf currentPlayer = 2 Then
                    frmScore.pnlScore.Controls("lblPlayer1").Text = ""
                    frmScore.pnlScore.Controls("lblPlayer3").Text = ""
                ElseIf currentPlayer = 3 Then
                    frmScore.pnlScore.Controls("lblPlayer1").Text = ""
                    frmScore.pnlScore.Controls("lblPlayer2").Text = ""
                End If
                If puzzleSolver = i And currentPlayerWinner.getWedges(Player.Wedges.HalfCar1) = True And currentPlayerWinner.getWedges(Player.Wedges.HalfCar2) = True Then
                    Dim currentValue = frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text + 25000
                    frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text = FormatCurrency(currentValue, 0)
                    currentPlayerWinner.total += 25000
                    If numberOfPrizes = 0 Then
                        If virtualHost = True Then
                            SAPI.Speak("You just won a brand new car that is worth $25,000!", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                            carAwarded = True
                        End If
                        houseMinimumMet = True
                    Else
                        If virtualHost = True Then
                            SAPI.Speak("You also just won a brand new car that is worth $25,000!", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                            carAwarded = True
                        End If
                    End If
                    player1.addCardsOrWedges(Player.Wedges.HalfCar1, False)
                    player1.addCardsOrWedges(Player.Wedges.HalfCar2, False)
                    player2.addCardsOrWedges(Player.Wedges.HalfCar1, False)
                    player2.addCardsOrWedges(Player.Wedges.HalfCar2, False)
                    player3.addCardsOrWedges(Player.Wedges.HalfCar1, False)
                    player3.addCardsOrWedges(Player.Wedges.HalfCar2, False)
                End If
                If puzzleSolver <> i And currentPlayerWinner.getWedgeRound(Player.Wedges.HalfCar1) = round Then
                    currentPlayerWinner.addCardsOrWedges(Player.Wedges.HalfCar1, False)
                ElseIf puzzleSolver <> i And currentPlayerWinner.getWedgeRound(Player.Wedges.HalfCar2) = round Then
                    currentPlayerWinner.addCardsOrWedges(Player.Wedges.HalfCar2, False)
                End If
                If puzzleSolver = i And currentPlayerWinner.getWedgeRound(Player.Wedges.Million) = round And currentPlayerWinner.getWedges(Player.Wedges.Million) = True Then
                    If numberOfPrizes = 0 Then
                        If virtualHost = True Then
                            SAPI.Speak("You are one step closer to winning the million dollars.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                        End If
                    Else
                        If virtualHost = True Then
                            SAPI.Speak("You are also one step closer to winning the million dollars.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                        End If
                    End If
                    numberOfPrizes += 1
                ElseIf puzzleSolver <> i And currentPlayerWinner.getWedgeRound(Player.Wedges.Million) = round And currentPlayerWinner.getWedges(Player.Wedges.Million) = True Then
                    currentPlayerWinner.addCardsOrWedges(Player.Wedges.Million, False)
                    If virtualHost = True Then
                        SAPI.Speak("Unfortunately, the million dollar wedge is out of play tonight.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                    End If
                Else
                End If
                If puzzleSolver = i And currentPlayerWinner.getWedgeRound(Player.Wedges.Gift) = round And currentPlayerWinner.getWedges(Player.Wedges.Gift) = True Then
                    Dim currentValue = frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text + 1000
                    frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text = FormatCurrency(currentValue, 0)
                    currentPlayerWinner.total += 1000
                    If numberOfPrizes = 0 Then
                        If virtualHost = True Then
                            SAPI.Speak("You picked up a gift worth $1,000.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                        End If
                        houseMinimumMet = True
                    Else

                    End If
                    numberOfPrizes += 1
                    currentPlayerWinner.addCardsOrWedges(Player.Wedges.Gift, False)
                ElseIf currentPlayerWinner.getWedgeRound(Player.Wedges.Gift) = round And currentPlayerWinner.getWedges(Player.Wedges.Million) = True Then
                    currentPlayerWinner.addCardsOrWedges(Player.Wedges.Gift, False)
                Else
                End If
                If currentPlayerWinner.getWedges(Player.Wedges.Mystery) = True And puzzleSolver = i And currentPlayerWinner.getWedges(Player.Wedges.Mystery) = True Then
                    Dim currentValue = frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text + 10000
                    frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text = FormatCurrency(currentValue, 0)
                    currentPlayerWinner.total += 10000
                    currentPlayerWinner.addCardsOrWedges(Player.Wedges.Mystery, False)
                    numberOfPrizes += 1
                    houseMinimumMet = True
                Else
                End If
                currentPlayerWinner.addCardsOrWedges(Player.Wedges.Mystery, False)
                If puzzleSolver = i And currentPlayerWinner.getWedgeRound(Player.Wedges.Prize) = round And currentPlayerWinner.getWedges(Player.Wedges.Prize) = True Then
                    Dim currentValue = frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text + 11000
                    frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text = FormatCurrency(currentValue, 0)
                    currentPlayerWinner.total += 11000
                    If numberOfPrizes = 0 Then
                        If virtualHost = True Then
                            SAPI.Speak("You won a great trip worth $11,000.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                        End If
                    Else
                        If virtualHost = True Then
                            SAPI.Speak("You also won a great trip worth $11,000.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                        End If
                    End If
                    currentPlayerWinner.addCardsOrWedges(Player.Wedges.Prize, False)
                    numberOfPrizes += 1
                    houseMinimumMet = True
                ElseIf currentPlayerWinner.getWedgeRound(Player.Wedges.Prize) = round And currentPlayerWinner.getWedges(Player.Wedges.Million) = True Then
                    currentPlayerWinner.addCardsOrWedges(Player.Wedges.Prize, False)
                Else
                End If
                If puzzleSolver = i And round = PuzzleType.R3 Then
                    Dim currentValue = frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text + 15000
                    frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text = FormatCurrency(currentValue, 0)
                    currentPlayerWinner.total += 15000
                    If virtualHost = True Then
                        SAPI.Speak("Don't forget that this was also a prize puzzle. You won a great trip that is worth over $15,000.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                    End If
                    player1.addCardsOrWedges(Player.Wedges.HalfCar1, False)
                    player1.addCardsOrWedges(Player.Wedges.HalfCar2, False)
                    player2.addCardsOrWedges(Player.Wedges.HalfCar1, False)
                    player2.addCardsOrWedges(Player.Wedges.HalfCar2, False)
                    player3.addCardsOrWedges(Player.Wedges.HalfCar1, False)
                    player3.addCardsOrWedges(Player.Wedges.HalfCar2, False)
                    numberOfPrizes += 1
                    houseMinimumMet = True
                End If
                If puzzleSolver = i And currentPlayerWinner.getWedgeRound(Player.Wedges.Wild) = round And currentPlayerWinner.getWedges(Player.Wedges.Wild) = True Then
                    numberOfPrizes += 1
                End If
                If numberOfPrizes < 2 Then
                Else
                    If virtualHost = True And puzzleSolver = i Then
                        SAPI.Speak("You also picked up a few other prizes along the way.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                        'otherPrizes = True
                    End If
                End If
                If puzzleSolver = i Then
                    If houseMinimumMet = False And round <> PuzzleType.TU1 And round <> PuzzleType.TU2 And round <> PuzzleType.TU3 Then
                        If teams = False Then
                            If virtualHost = True Then
                                SAPI.Speak("You didn't meet the house minimum. So we upped your score to one thousand dollars.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                            End If
                        Else
                            If virtualHost = True Then
                                SAPI.Speak("You didn't meet the house minimum. So we upped your score to two thousand dollars.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                            End If
                        End If
                    End If
                End If
            Next
            frmScore.lblPlayer1Total.Show()
            frmScore.lblPlayer1Total.Text = FormatCurrency(player1.total, 0)
            frmScore.lblPlayer2Total.Show()
            frmScore.lblPlayer2Total.Text = FormatCurrency(player2.total, 0)
            frmScore.lblPlayer3Total.Show()
            frmScore.lblPlayer3Total.Text = FormatCurrency(player3.total, 0)
            frmPuzzleBoard.ListBox1.Items.Clear()
            frmPuzzleBoard.ListBox2.Items.Clear()
            frmPuzzleBoard.ListBox3.Items.Clear()
            If virtualHost = True Then
                SAPI.Speak("You're up to " & frmScore.pnlScore.Controls("lblPlayer" & currentPlayer & "Total").Text, SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
            End If
        End If
        If round = PuzzleType.BR Then
            If bonusSolved = True Then
                If wheelWedges.Item(frmPuzzleBoard.WheelSpinControl1.trkBonusWheel.Value) <> "Car" Then
                    bonusRoundPlayer.total += wheelWedges.Item(frmPuzzleBoard.WheelSpinControl1.trkBonusWheel.Value)
                Else
                    bonusRoundPlayer.total += 35000
                End If
                frmScore.lblPlayer1Total.Show()
                frmScore.lblPlayer1Total.Text = FormatCurrency(player1.total, 0)
                frmScore.lblPlayer2Total.Show()
                frmScore.lblPlayer2Total.Text = FormatCurrency(player2.total, 0)
                frmScore.lblPlayer3Total.Show()
                frmScore.lblPlayer3Total.Text = FormatCurrency(player3.total, 0)
            End If
        End If
        'If currentPlayer = 1 And player1.getWedges(Player.Wedges.HalfCar1) = True Or currentPlayer = 1 And player1.getWedges(Player.Wedges.HalfCar2) = True Then
        'Else
        '    player1.addCardsOrWedges(Player.Wedges.HalfCar1, False)
        '    player1.addCardsOrWedges(Player.Wedges.HalfCar2, False)
        'End If
        'If currentPlayer = 2 And player1.getWedges(Player.Wedges.HalfCar1) = True Or currentPlayer = 2 And player1.getWedges(Player.Wedges.HalfCar2) = True Then
        'Else
        '    player2.addCardsOrWedges(Player.Wedges.HalfCar1, False)
        '    player2.addCardsOrWedges(Player.Wedges.HalfCar2, False)
        'End If
        'If currentPlayer = 3 And player1.getWedges(Player.Wedges.HalfCar1) = True Or currentPlayer = 3 And player1.getWedges(Player.Wedges.HalfCar2) = True Then
        'Else
        '    player3.addCardsOrWedges(Player.Wedges.HalfCar1, False)
        '    player3.addCardsOrWedges(Player.Wedges.HalfCar2, False)
        'End If
        'If currentPlayer = 1 Then
        '    If player1.getWedges(Player.Wedges.Gift) = True Then
        '        player1.total += 1000
        '        player1.addCardsOrWedges(Player.Wedges.Gift, False)
        '    End If
        '    If player1.getWedges(Player.Wedges.Mystery) = True And currentPlayer = 1 Then
        '        player1.total += 10000
        '        player1.addCardsOrWedges(Player.Wedges.Mystery, False)
        '    End If
        '    If player1.getWedges(Player.Wedges.Prize) = True And currentPlayer = 1 Then
        '        player1.total += 10000
        '        player1.addCardsOrWedges(Player.Wedges.Prize, False)
        '    End If
        '    If player1.getWedges(Player.Wedges.Prize) = True And currentPlayer = 1 Then
        '        player1.total += 10000
        '        player1.addCardsOrWedges(Player.Wedges.Prize, False)
        '    End If
        '    If player1.getWedges(Player.Wedges.HalfCar1) = True Then
        '        player1.addCardsOrWedges(Player.Wedges.HalfCar1, True)
        '    End If
        '    If player1.getWedges(Player.Wedges.HalfCar2) = True Then
        '        player1.addCardsOrWedges(Player.Wedges.HalfCar2, True)
        '    End If
        '    If player1.getWedges(Player.Wedges.HalfCar1) = True And player1.getWedges(Player.Wedges.HalfCar2) = True Then
        '        player1.total += 24000
        '        player1.addCardsOrWedges(Player.Wedges.HalfCar1, False)
        '        player1.addCardsOrWedges(Player.Wedges.HalfCar2, False)
        '        player2.addCardsOrWedges(Player.Wedges.HalfCar1, False)
        '        player2.addCardsOrWedges(Player.Wedges.HalfCar2, False)
        '        player3.addCardsOrWedges(Player.Wedges.HalfCar1, False)
        '        player3.addCardsOrWedges(Player.Wedges.HalfCar2, False)
        '        halfCar1Status = True
        '        halfCar2Status = True
        '        carAwarded = True
        '    End If
        '    'If prizePuzzleStatus = True Then
        '    '    player1.total += 10000
        '    'End If
        'ElseIf currentPlayer = 2 Then
        '    If player2.getWedges(Player.Wedges.Gift) = True Then
        '        player2.total += 1000
        '        player2.addCardsOrWedges(Player.Wedges.Gift, False)
        '    End If
        '    If player2.getWedges(Player.Wedges.Mystery) = True And currentPlayer = 2 Then
        '        player2.total += 10000
        '        player2.addCardsOrWedges(Player.Wedges.Mystery, False)
        '    End If
        '    If player2.getWedges(Player.Wedges.Prize) = True And currentPlayer = 2 Then
        '        player2.total += 10000
        '        player2.addCardsOrWedges(Player.Wedges.Prize, False)
        '    End If
        '    If player2.getWedges(Player.Wedges.HalfCar1) = True Then
        '        player2.addCardsOrWedges(Player.Wedges.HalfCar1, True)
        '    End If
        '    If player2.getWedges(Player.Wedges.HalfCar2) = True Then
        '        player2.addCardsOrWedges(Player.Wedges.HalfCar2, True)
        '    End If
        '    If player2.getWedges(Player.Wedges.HalfCar1) = True And player2.getWedges(Player.Wedges.HalfCar2) = True Then
        '        player2.total += 24000
        '        player1.addCardsOrWedges(Player.Wedges.HalfCar1, False)
        '        player1.addCardsOrWedges(Player.Wedges.HalfCar2, False)
        '        player2.addCardsOrWedges(Player.Wedges.HalfCar1, False)
        '        player2.addCardsOrWedges(Player.Wedges.HalfCar2, False)
        '        player3.addCardsOrWedges(Player.Wedges.HalfCar1, False)
        '        player3.addCardsOrWedges(Player.Wedges.HalfCar2, False)
        '        halfCar1Status = True
        '        halfCar2Status = True
        '        carAwarded = True
        '    End If
        '    'If prizePuzzleStatus = True Then
        '    '    player2.total += 10000
        '    'End If
        'ElseIf currentPlayer = 3 Then
        '    If player3.getWedges(Player.Wedges.Gift) = True Then
        '        player3.total += 1000
        '        player3.addCardsOrWedges(Player.Wedges.Gift, False)
        '    End If
        '    If player3.getWedges(Player.Wedges.Mystery) = True And currentPlayer = 3 Then
        '        player3.total += 10000
        '        player3.addCardsOrWedges(Player.Wedges.Mystery, False)
        '    End If
        '    If player3.getWedges(Player.Wedges.Prize) = True And currentPlayer = 3 Then
        '        player3.total += 10000
        '        player3.addCardsOrWedges(Player.Wedges.Prize, False)
        '    End If
        '    If player3.getWedges(Player.Wedges.HalfCar1) = True Then
        '        player3.addCardsOrWedges(Player.Wedges.HalfCar1, True)
        '    End If
        '    If player3.getWedges(Player.Wedges.HalfCar2) = True Then
        '        player3.addCardsOrWedges(Player.Wedges.HalfCar2, True)
        '    End If
        '    If player3.getWedges(Player.Wedges.HalfCar1) = True And player3.getWedges(Player.Wedges.HalfCar2) = True Then
        '        player3.total += 24000
        '        player1.addCardsOrWedges(Player.Wedges.HalfCar1, False)
        '        player1.addCardsOrWedges(Player.Wedges.HalfCar2, False)
        '        player2.addCardsOrWedges(Player.Wedges.HalfCar1, False)
        '        player2.addCardsOrWedges(Player.Wedges.HalfCar2, False)
        '        player3.addCardsOrWedges(Player.Wedges.HalfCar1, False)
        '        player3.addCardsOrWedges(Player.Wedges.HalfCar2, False)
        '        halfCar1Status = True
        '        halfCar2Status = True
        '        carAwarded = True
        '    End If
        '    'If prizePuzzleStatus = True Then
        '    '    player3.total += 10000
        '    'End If
        'End If
        aEnabled = True
        eEnabled = True
        iEnabled = True
        oEnabled = True
        uEnabled = True
        frmScore.btnB.Enabled = True
        frmScore.btnC.Enabled = True
        frmScore.btnD.Enabled = True
        frmScore.btnF.Enabled = True
        frmScore.btnG.Enabled = True
        frmScore.btnH.Enabled = True
        frmScore.btnJ.Enabled = True
        frmScore.btnK.Enabled = True
        frmScore.btnL.Enabled = True
        frmScore.btnM.Enabled = True
        frmScore.btnN.Enabled = True
        frmScore.btnP.Enabled = True
        frmScore.btnQ.Enabled = True
        frmScore.btnR.Enabled = True
        frmScore.btnS.Enabled = True
        frmScore.btnT.Enabled = True
        frmScore.btnV.Enabled = True
        frmScore.btnW.Enabled = True
        frmScore.btnX.Enabled = True
        frmScore.btnY.Enabled = True
        frmScore.btnZ.Enabled = True
        puzzleString = puzzle
    End Sub
#End Region
#Region "Enable Consonants"
    Public Shared Sub enableConsonants(value As Boolean)
        If value = False Then
            frmScore.btnB.Enabled = False
            frmScore.btnC.Enabled = False
            frmScore.btnD.Enabled = False
            frmScore.btnF.Enabled = False
            frmScore.btnG.Enabled = False
            frmScore.btnH.Enabled = False
            frmScore.btnJ.Enabled = False
            frmScore.btnK.Enabled = False
            frmScore.btnL.Enabled = False
            frmScore.btnM.Enabled = False
            frmScore.btnN.Enabled = False
            frmScore.btnP.Enabled = False
            frmScore.btnQ.Enabled = False
            frmScore.btnR.Enabled = False
            frmScore.btnS.Enabled = False
            frmScore.btnT.Enabled = False
            frmScore.btnV.Enabled = False
            frmScore.btnW.Enabled = False
            frmScore.btnX.Enabled = False
            frmScore.btnY.Enabled = False
            frmScore.btnZ.Enabled = False
        Else
            frmScore.btnB.Enabled = True
            frmScore.btnC.Enabled = True
            frmScore.btnD.Enabled = True
            frmScore.btnF.Enabled = True
            frmScore.btnG.Enabled = True
            frmScore.btnH.Enabled = True
            frmScore.btnJ.Enabled = True
            frmScore.btnK.Enabled = True
            frmScore.btnL.Enabled = True
            frmScore.btnM.Enabled = True
            frmScore.btnN.Enabled = True
            frmScore.btnP.Enabled = True
            frmScore.btnQ.Enabled = True
            frmScore.btnR.Enabled = True
            frmScore.btnS.Enabled = True
            frmScore.btnT.Enabled = True
            frmScore.btnV.Enabled = True
            frmScore.btnW.Enabled = True
            frmScore.btnX.Enabled = True
            frmScore.btnY.Enabled = True
            frmScore.btnZ.Enabled = True
            If round <> PuzzleType.BR Then

            Else
                disableRSTLNE()
            End If
        End If
    End Sub
#End Region
#Region "Enable Vowels"
    Public Shared Sub enableVowels(value As Boolean)
        If value = True Then
            If aEnabled = True Then
                frmScore.btnA.Enabled = True
                'frmScore.btnA.FlatStyle = FlatStyle.Flat
            Else
                frmScore.btnA.Enabled = False
                ' frmScore.btnA.FlatStyle = FlatStyle.System
            End If
            If eEnabled = True Then
                frmScore.btnE.Enabled = True
                '  frmScore.btnE.FlatStyle = FlatStyle.Flat
            Else
                frmScore.btnE.Enabled = False
                '     frmScore.btnE.FlatStyle = FlatStyle.System
            End If
            If iEnabled = True Then
                frmScore.btnI.Enabled = True
                '     frmScore.btnI.FlatStyle = FlatStyle.Flat
            Else
                frmScore.btnI.Enabled = False
                '       frmScore.btnI.FlatStyle = FlatStyle.System
            End If
            If oEnabled = True Then
                frmScore.btnO.Enabled = True
                '        frmScore.btnO.FlatStyle = FlatStyle.Flat
            Else
                frmScore.btnO.Enabled = False
                '         frmScore.btnO.FlatStyle = FlatStyle.System
            End If
            If uEnabled = True Then
                frmScore.btnU.Enabled = True
                '        frmScore.btnU.FlatStyle = FlatStyle.Flat
            Else
                frmScore.btnU.Enabled = False
                '        frmScore.btnU.FlatStyle = FlatStyle.System
            End If
        ElseIf value = False Then
            frmScore.btnA.Enabled = False
            frmScore.btnE.Enabled = False
            frmScore.btnI.Enabled = False
            frmScore.btnO.Enabled = False
            frmScore.btnU.Enabled = False
        End If
    End Sub
#End Region
#Region "Enable Bonus Vowels"
    Public Shared Sub enableBonusVowels(value As Boolean)
        If value = True Then
            If aEnabled = True Then
                frmScore.btnA.Enabled = True
            Else
                frmScore.btnA.Enabled = False
            End If
            If iEnabled = True Then
                frmScore.btnI.Enabled = True
            Else
                frmScore.btnI.Enabled = False
            End If
            If oEnabled = True Then
                frmScore.btnO.Enabled = True
            Else
                frmScore.btnO.Enabled = False
            End If
            If uEnabled = True Then
                frmScore.btnU.Enabled = True
            Else
                frmScore.btnU.Enabled = False
            End If
            bonusVowelsEnabled = True
            If selectedBonusLetters.Count = 3 And bonusRoundPlayer.getWedges(Player.Wedges.Wild) = False Then
                disableConsonants()
            ElseIf selectedBonusLetters.Count = 3 And bonusRoundPlayer.getWedges(Player.Wedges.Wild) = True Then
                disableConsonants()
            ElseIf selectedBonusLetters.Count = 4 And bonusRoundPlayer.getWedges(Player.Wedges.Wild) = True Then
                showUsedLettersInBonus()
            ElseIf selectedBonusLetters.Count < 3 Then

            ElseIf selectedBonusLetters.Count = 4 And bonusRoundPlayer.getWedges(Player.Wedges.Wild) = False Or selectedBonusLetters.Count = 5 And bonusRoundPlayer.getWedges(Player.Wedges.Wild) = True Then
                showUsedLettersInBonus()
            End If
        ElseIf value = False Then
            frmScore.btnA.Enabled = False
            frmScore.btnE.Enabled = False
            frmScore.btnI.Enabled = False
            frmScore.btnO.Enabled = False
            frmScore.btnU.Enabled = False
            bonusVowelsEnabled = False
        End If
    End Sub
#End Region
#Region "Disable Consonants"
    Public Shared Sub disableConsonants()
        frmScore.btnB.Enabled = False
        frmScore.btnC.Enabled = False
        frmScore.btnD.Enabled = False
        frmScore.btnE.Enabled = False
        frmScore.btnF.Enabled = False
        frmScore.btnG.Enabled = False
        frmScore.btnH.Enabled = False
        frmScore.btnJ.Enabled = False
        frmScore.btnK.Enabled = False
        frmScore.btnM.Enabled = False
        frmScore.btnP.Enabled = False
        frmScore.btnQ.Enabled = False
        frmScore.btnV.Enabled = False
        frmScore.btnW.Enabled = False
        frmScore.btnX.Enabled = False
        frmScore.btnY.Enabled = False
        frmScore.btnZ.Enabled = False
    End Sub
#End Region
#Region "Show Used Letters in Bonus"
    Public Shared Sub showUsedLettersInBonus()
        frmScore.btnB.Enabled = True
        frmScore.btnC.Enabled = True
        frmScore.btnD.Enabled = True
        frmScore.btnF.Enabled = True
        frmScore.btnG.Enabled = True
        frmScore.btnH.Enabled = True
        frmScore.btnJ.Enabled = True
        frmScore.btnK.Enabled = True
        frmScore.btnM.Enabled = True
        frmScore.btnP.Enabled = True
        frmScore.btnQ.Enabled = True
        frmScore.btnV.Enabled = True
        frmScore.btnW.Enabled = True
        frmScore.btnX.Enabled = True
        frmScore.btnY.Enabled = True
        frmScore.btnZ.Enabled = True
        'If vowelModeEnabled = True Then
        'frmScore.btnA.Enabled = True
        'frmScore.btnI.Enabled = True
        'frmScore.btnO.Enabled = True
        'frmScore.btnU.Enabled = True
        'End If
        disableRSTLNE()
        For Each letter As String In selectedBonusLetters
            frmScore.usedLetterBoard.Controls("btn" & letter).Enabled = False
        Next
        'If selectedBonusLetters.Count = 4 And bonusRoundPlayer.getWedges(Player.Wedges.Wild) = True Then

        'Else
        'End If
    End Sub
#End Region
#Region "Disable RSTLNE"
    Public Shared Sub disableRSTLNE()
        frmScore.btnR.Enabled = False
        frmScore.btnS.Enabled = False
        frmScore.btnT.Enabled = False
        frmScore.btnL.Enabled = False
        frmScore.btnN.Enabled = False
        frmScore.btnE.Enabled = False
    End Sub
#End Region
#Region "Check for Consonants"
    Public Shared Function GetConsonants(ByVal input As String) As Integer
        Return input.ToLower.Count(Function(c) "qwrtypsdfghjklmnbvcxz".Contains(c))
    End Function
#End Region
#Region "Reveal Letters on Puzzleboard"
    Public Shared Sub revealLetters()
        For my2i As Integer = 1 To letterControlList.Count
            If DateTime.Now.Second = convertTime(timeStart) Then
                Dim randomNumber = GetRandomRegular()
                CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & letterControlList(randomNumber)), PuzzleBoardLetter).displayBlueBKG()
                If finalSpin <> True Then
                    CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & letterControlList(randomNumber)), PuzzleBoardLetter).playDing()
                Else
                End If
                frmPuzzleBoard.ListBox4.Items.Add(randomNumber & CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & letterControlList(randomNumber)), PuzzleBoardLetter).letterBehind)
                letterControlList.Remove(letterControlList(randomNumber))
                timeStart = DateTime.Now.Second
            End If
        Next
        If letterControlList.Count = 0 Then
            If round = PuzzleType.BR And frmPuzzleBoard.lblChosenLetters.Visible = False Then
                frmAudio.playRSTLNE(False)
                enableVowels(False)
                My.Computer.Audio.Play(My.Resources.choose_letters_new, AudioPlayMode.BackgroundLoop)
                frmPuzzleBoard.lblChosenLetters.Text = ""
                frmPuzzleBoard.lblChosenLetters.Show()
                If virtualHost = True Then

                    SAPI.Speak("Now, we are going to need three consonants and a vowel.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                End If
            End If
            frmScore.tmrLetterReveal.Stop()
        ElseIf round = PuzzleType.BR And letterControlList.Count > 0 Then

        End If
    End Sub
#End Region
#Region "Solve Puzzle"
    Public Shared Sub solvePuzzle(preview As Boolean)
        If solveMode = False And revealed = False And typeToSolve = True And solved = False Then
            If round = PuzzleType.BR Then
                frmScore.wmpBonus.Ctlcontrols.pause()
                frmPuzzleBoard.tmrBonus.Stop()
                frmPuzzleBoard.bonusTimeStart = DateTime.Now.Second - frmPuzzleBoard.bonusTimeStart
            End If
            solveMode = True
            For Each myLetterControl As PuzzleBoardLetter In frmPuzzleBoard.PuzzleBoard1.Controls
                If myLetterControl.letterRevealed = False And myLetterControl.Visible = True Then
                    'myLetterControl.btnLetter.BackgroundImage = Nothing
                    myLetterControl.btnLetter.BackColor = Color.FromArgb(19, 28, 255)
                    currentSolveLetter = CInt(myLetterControl.Name.Replace("PuzzleBoardLetter", ""))
                    Exit For
                End If
            Next
            frmPuzzleBoard.btnSolvePass.Show()
            frmScore.usedLetterBoard.Enabled = True
        Else
            frmPuzzleBoard.btnSolvePass.Hide()
            currentSolveLetter = 0
            solveMode = False
            lastLetter = 0
            If solveAttempt.Replace(" ", "") = puzzle.Replace(" ", "") Or typeToSolve = False Then
                solved = False
                puzzleSolver = currentPlayer
                frmAudio.playSpeedUp(False)
                For Each lettersControls As Control In dlgPuzzleBoard.MiniPuzzleBoard1.Controls
                    If lettersControls.GetType() Is GetType(PuzzleBoardLetter) Then
                        CType(lettersControls, PuzzleBoardLetter).letterBehind = ""
                        CType(lettersControls, PuzzleBoardLetter).BackgroundImage = Nothing
                        CType(lettersControls, PuzzleBoardLetter).Hide()
                    End If
                Next
                expressStatus = False
                If round <> PuzzleType.BR Then
                    spinResult = 0
                Else
                End If
                puzzleLoaded = False
                frmPuzzleBoard.Controls(puzzleBoardName).clearLetterList()
                frmPuzzleBoard.Controls(puzzleBoardName).rightControlDetermined = False
                frmScore.btnBonusTimerStart.Hide()
                frmPuzzleBoard.btnWild.Enabled = True
                puzzleSolved = True
                frmScore.lstMessages.Items.Clear()
                frmScore.notifyBar.Text = Nothing
                frmPuzzleBoard.tmrTossUp.Stop()
                frmPuzzleBoard.wheelTilt.Enabled = False
                frmPuzzleBoard.WheelSpinControl1.firstSpin = True
                If preview = False Then
                    frmPuzzleBoard.btnSpinner.Enabled = True
                    If revealed = False Then
                        For Each lettersControls As Control In frmPuzzleBoard.Controls(puzzleBoardName).Controls
                            If lettersControls.GetType() Is GetType(PuzzleBoardLetter) Then
                                CType(lettersControls, PuzzleBoardLetter).revealLetter()
                                'CType(lettersControls, PuzzleBoardLetter).tossUpStatus = False
                            End If
                        Next
                        If round = PuzzleType.TU1 Or round = PuzzleType.TBTU Then
                            'If currentPlayer = 1 Then
                            If currentPlayerObject IsNot Nothing Then
                                Dim currentValue = frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text
                                If currentValue = "" Then
                                    currentValue = 0
                                    currentValue += 1000
                                End If
                                frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text = FormatCurrency(currentValue, 0)
                                currentPlayerObject.total += 1000
                            End If
                            'ElseIf currentPlayer = 2 Then
                            '    player2.total += 1000
                            'ElseIf currentPlayer = 3 Then
                            '    player3.total += 1000
                            'End If
                        ElseIf round = PuzzleType.TU2 Then
                            If currentPlayerObject IsNot Nothing Then
                                Dim currentValue = frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text
                                If currentValue = "" Then
                                    currentValue = 0
                                    currentValue += 2000
                                End If
                                frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text = FormatCurrency(currentValue, 0)
                                currentPlayerObject.total += 2000
                                'ElseIf currentPlayer = 2 Then
                                '    player2.total += 2000
                                'ElseIf currentPlayer = 3 Then
                                '    player3.total += 2000
                            Else
                                currentPlayer = GetRandomPlayer(1, numberOfPlayers + 1)
                                If currentPlayer = 1 Then
                                    currentPlayerObject = player1
                                ElseIf currentPlayer = 2 Then
                                    currentPlayerObject = player2
                                ElseIf currentPlayer = 3 Then
                                    currentPlayerObject = player3
                                End If
                            End If
                        ElseIf round = PuzzleType.TU3 Then
                            If currentPlayerObject IsNot Nothing Then
                                Dim currentValue = frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text
                                If currentValue = "" Then
                                    currentValue = 0
                                    currentValue += 3000
                                End If
                                frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text = FormatCurrency(currentValue, 0)
                                currentPlayerObject.total += 3000
                                'ElseIf currentPlayer = 2 Then
                                '    player2.total += 3000
                                'ElseIf currentPlayer = 3 Then
                                '    player3.total += 3000
                            Else
                                currentPlayer = GetRandomPlayer(1, numberOfPlayers + 1)
                                If currentPlayer = 1 Then
                                    currentPlayerObject = player1
                                ElseIf currentPlayer = 2 Then
                                    currentPlayerObject = player2
                                ElseIf currentPlayer = 3 Then
                                    currentPlayerObject = player3
                                End If
                            End If
                        ElseIf round = PuzzleType.BR Then
                            If bonusSolved = False Then
                            Else
                                'resetPuzzle()
                            End If
                        Else

                        End If
                        Dim player1Score As Integer = WheelController.player1Score
                        Dim player2Score As Integer = WheelController.player2Score
                        Dim player3Score As Integer = WheelController.player3Score
                        If numberOfTurns > 0 And round <> PuzzleType.TU1 And round <> PuzzleType.TU2 And round <> PuzzleType.TU3 And round <> PuzzleType.TBTU And round <> PuzzleType.BR Then
                            If currentPlayer = 1 Then
                                If teams = False Then
                                    If player1Score > 1000 Then
                                        player1.total += player1Score
                                        houseMinimumMet = True
                                    Else
                                        Dim currentValue = frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text
                                        If currentValue = "" Then
                                            currentValue = 0
                                            currentValue = currentValue + 1000
                                        End If
                                        frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text = FormatCurrency(currentValue, 0)
                                        player1.total += 1000
                                        houseMinimumMet = False
                                    End If
                                Else
                                    If player1Score > 2000 Then
                                        player1.total += player1Score
                                        houseMinimumMet = True
                                    Else
                                        Dim currentValue = frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text
                                        If currentValue = "" Then
                                            currentValue = 0
                                            currentValue = currentValue + 2000
                                        End If
                                        frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text = FormatCurrency(currentValue, 0)
                                        player1.total += 2000
                                        houseMinimumMet = False
                                    End If
                                End If
                            ElseIf currentPlayer = 2 Then
                                If teams = False Then
                                    If player2Score > 1000 Then
                                        player2.total += player2Score
                                        houseMinimumMet = True
                                    Else
                                        Dim currentValue = frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text
                                        If currentValue = "" Then
                                            currentValue = 0
                                            currentValue = currentValue + 1000
                                        End If
                                        frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text = FormatCurrency(currentValue, 0)
                                        player2.total += 1000
                                        houseMinimumMet = False
                                    End If
                                Else
                                    If player2Score > 2000 Then
                                        player2.total += player2Score
                                        houseMinimumMet = True
                                    Else
                                        Dim currentValue = frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text
                                        If currentValue = "" Then
                                            currentValue = 0
                                        Else
                                            currentValue = CInt(frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text) + 2000
                                        End If
                                        frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text = FormatCurrency(currentValue, 0)
                                        player2.total += 2000
                                        houseMinimumMet = False
                                    End If
                                End If
                            ElseIf currentPlayer = 3 Then
                                If teams = False Then
                                    If player3Score > 1000 Then
                                        player3.total += player3Score
                                        houseMinimumMet = True
                                    Else
                                        Dim currentValue = frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text
                                        If currentValue = "" Then
                                            currentValue = 0
                                        Else
                                            currentValue = CInt(frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text) + 1000
                                        End If
                                        frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text = FormatCurrency(currentValue, 0)
                                        player3.total += 1000
                                        houseMinimumMet = False
                                    End If
                                Else
                                    If player3Score > 2000 Then
                                        player3.total += player3Score
                                        houseMinimumMet = True
                                    Else
                                        Dim currentValue = frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text
                                        If currentValue = "" Then
                                            currentValue = 0
                                        Else
                                            currentValue = CInt(frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text) + 2000
                                        End If
                                        frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text = FormatCurrency(currentValue, 0)
                                        player3.total += 2000
                                        houseMinimumMet = False
                                    End If
                                End If
                            End If
                        End If
                        If round = PuzzleType.TU1 Or round = PuzzleType.TU2 Or round = PuzzleType.TU3 Then
                            If tossUpLetterControlList.Count = 0 Or allRungIn = True Then
                                'My.Computer.Audio.Play(My.Resources.double_buzz, AudioPlayMode.Background)
                            Else
                                My.Computer.Audio.Play(My.Resources.toss_up_solved, AudioPlayMode.WaitToComplete)
                                resetPuzzle()

                            End If
                        ElseIf round = PuzzleType.BR Then
                            If bonusSolved = False Then
                                'frmScore.BonusCardEnvelope1.Show()
                                My.Computer.Audio.Play(My.Resources.music_bonus_lose_vamp, AudioPlayMode.Background)
                                bonusPuzzleRevealed = True
                            Else
                                My.Computer.Audio.Play(My.Resources.music_bonus_win_vamp_new, AudioPlayMode.Background)
                                If virtualHost = True Then
                                    SAPI.Speak("Congratulations on solving the bonus round! " & CType(frmScore.Controls("NameTag" & currentPlayer), NameTag).lblName.Text & " Here's what you won.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                                End If
                                resetPuzzle()
                                'frmScore.BonusCardEnvelope1.Show()
                                bonusPuzzleRevealed = True
                            End If
                            If gameID <> 0 Then
                                saveToDB()
                            End If
                        ElseIf numberOfTurns = 0 Then
                            My.Computer.Audio.Play(My.Resources.bankrupt, AudioPlayMode.WaitToComplete)
                            My.Computer.Audio.Play(My.Resources.double_buzz, AudioPlayMode.Background)
                            'numberOfTurns = 0
                            'frmScore.lblNumberOfTurns.Text = 0
                            If virtualHost = True Then
                                SAPI.Speak("Here is the puzzle solution.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                            End If
                            revealed = True
                            'frmPuzzleBoard.tmrCheckTurns.Start()
                            Exit Sub
                        Else
                            My.Computer.Audio.Play(My.Resources.puzzle_solved_new, AudioPlayMode.WaitToComplete)
                            resetPuzzle()
                            currentPlayer = GetRandomPlayer(1, numberOfPlayers + 1)
                        End If
                        If currentPlayer = 1 Then
                            currentPlayerObject = player1
                        ElseIf currentPlayer = 2 Then
                            currentPlayerObject = player2
                        ElseIf currentPlayer = 3 Then
                            currentPlayerObject = player3
                        End If
                        player1RingIn = False
                        player2RingIn = False
                        player3RingIn = False
                        allRungIn = False
                        revealed = True
                        Exit Sub
                    Else
                        If revealed = True Then
                            solveAttempt = ""
                            frmPuzzleBoard.logoCrossword.Hide()
                            frmPuzzleBoard.logoExpress.Hide()
                            frmScore.lblPlayer1Total.Hide()
                            frmScore.lblPlayer2Total.Hide()
                            frmScore.lblPlayer3Total.Hide()
                            For Each lettersControls As Control In frmPuzzleBoard.Controls(puzzleBoardName).Controls
                                If lettersControls.GetType() Is GetType(PuzzleBoardLetter) Then
                                    CType(lettersControls, PuzzleBoardLetter).letterBehind = ""
                                    CType(lettersControls, PuzzleBoardLetter).Hide()
                                End If
                            Next
                            If round = PuzzleType.TU1 Then
                                'frmPuzzleBoard.btnRedRingIn.Enabled = True
                                'frmPuzzleBoard.btnYellowRingIn.Enabled = True
                                'frmPuzzleBoard.btnBlueRingIn.Enabled = True
                                tossUpLetterControlList.Clear()
                                frmPuzzleBoard.tmrTossUpRingIn.Stop()
                                round = PuzzleType.TU2
                                frmPuzzleBoard.CategoryStrip1.Hide()
                                loadTossUp()
                                frmPuzzleBoard.tmrTossUpReveal.Start()
                                puzzleSolved = False
                                wheelLoad(PuzzleType.TU2)
                                loadPuzzle(PuzzleType.TU2, puzzleMode, False)
                                tossUpStarted = False
                                currentPlayer = Nothing
                                currentPlayerObject = Nothing
                                frmScore.tmrCheckVowels.Stop()
                            ElseIf round = PuzzleType.TU2 Then
                                tossUpLetterControlList.Clear()
                                frmPuzzleBoard.tmrTossUpRingIn.Stop()
                                'frmPuzzleBoard.btnRedRingIn.Hide()
                                'frmPuzzleBoard.btnYellowRingIn.Hide()
                                'frmPuzzleBoard.btnBlueRingIn.Hide()
                                puzzleSolved = False
                                round = PuzzleType.R1
                                wheelLoad(PuzzleType.R1)
                                loadPuzzle(PuzzleType.R1, puzzleMode, False)
                                tossUpStarted = True
                                frmScore.usedLetterBoard.Enabled = True
                                frmPuzzleBoard.wheelTilt.Enabled = True
                                frmScore.tmrCheckVowels.Start()
                            ElseIf round = PuzzleType.R1 Then
                                puzzleSolved = False
                                round = PuzzleType.R2
                                wheelLoad(PuzzleType.R2)
                                loadPuzzle(PuzzleType.R2, puzzleMode, False)
                                frmScore.tmrCheckVowels.Start()
                                frmPuzzleBoard.wheelTilt.Enabled = True

                            ElseIf round = PuzzleType.R2 Then
                                puzzleSolved = False
                                round = PuzzleType.R3
                                wheelLoad(PuzzleType.R3)
                                loadPuzzle(PuzzleType.R3, puzzleMode, False)
                                frmScore.tmrCheckVowels.Start()
                                frmPuzzleBoard.wheelTilt.Enabled = True
                                prizePuzzleStatus = True

                            ElseIf round = PuzzleType.R3 Then
                                'frmPuzzleBoard.btnRedRingIn.Show()
                                'frmPuzzleBoard.btnYellowRingIn.Show()
                                'frmPuzzleBoard.btnBlueRingIn.Show()
                                'If numberOfPlayers = 2 Then
                                '    frmPuzzleBoard.btnBlueRingIn.Hide()
                                '    player3RingIn = True
                                'ElseIf numberOfPlayers = 1 Then
                                '    frmPuzzleBoard.btnYellowRingIn.Hide()
                                '    player2RingIn = True
                                '    frmPuzzleBoard.btnBlueRingIn.Hide()
                                '    player3RingIn = True
                                'End If
                                prizePuzzleStatus = False
                                frmPuzzleBoard.CategoryStrip1.Hide()
                                round = PuzzleType.TU3
                                loadTossUp()
                                frmPuzzleBoard.tmrTossUpReveal.Start()
                                puzzleSolved = False
                                wheelLoad(PuzzleType.TU3)
                                loadPuzzle(PuzzleType.TU3, puzzleMode, False)
                                tossUpStarted = False
                                frmScore.usedLetterBoard.Enabled = False
                                frmPuzzleBoard.wheelTilt.Enabled = False
                                currentPlayer = Nothing
                                currentPlayerObject = Nothing
                                frmPuzzleBoard.btnWild.Hide()
                                frmPuzzleBoard.logoExpress.Hide()
                                frmScore.tmrCheckVowels.Stop()
                                frmPuzzleBoard.btnRedRingIn.Enabled = True
                                frmPuzzleBoard.btnYellowRingIn.Enabled = True
                                frmPuzzleBoard.btnBlueRingIn.Enabled = True

                            ElseIf round = PuzzleType.TU3 Then
                                tossUpLetterControlList.Clear()
                                puzzleSolved = False
                                frmPuzzleBoard.tmrTossUpRingIn.Stop()
                                'frmPuzzleBoard.btnRedRingIn.Hide()
                                'frmPuzzleBoard.btnYellowRingIn.Hide()
                                'frmPuzzleBoard.btnBlueRingIn.Hide()
                                round = PuzzleType.R4
                                wheelLoad(PuzzleType.R4)
                                loadPuzzle(PuzzleType.R4, puzzleMode, False)
                                frmScore.lblPlayer1Total.Text = FormatCurrency(player1.total, 0)
                                frmScore.lblPlayer2Total.Text = FormatCurrency(player2.total, 0)
                                frmScore.lblPlayer3Total.Text = FormatCurrency(player3.total, 0)
                                tossUpStarted = True
                                frmScore.usedLetterBoard.Enabled = True
                                frmPuzzleBoard.wheelTilt.Enabled = True
                                frmScore.tmrCheckVowels.Start()

                            ElseIf round = PuzzleType.R4 Then
                                If finalSpin = False Then
                                    puzzleSolved = False
                                    round = PuzzleType.R5
                                    wheelLoad(PuzzleType.R5)
                                    loadPuzzle(PuzzleType.R5, puzzleMode, False)
                                    frmScore.tmrCheckVowels.Start()
                                    frmPuzzleBoard.wheelTilt.Enabled = True
                                Else
                                    checkBonusRoundWinner()
                                End If
                            ElseIf round = PuzzleType.R5 Then
                                If finalSpin = False Then
                                    puzzleSolved = False
                                    round = PuzzleType.R6
                                    wheelLoad(PuzzleType.R6)
                                    loadPuzzle(PuzzleType.R6, puzzleMode, False)
                                    frmScore.tmrCheckVowels.Start()
                                    frmPuzzleBoard.wheelTilt.Enabled = True
                                Else
                                    checkBonusRoundWinner()
                                End If
                            ElseIf round = PuzzleType.R6 Then
                                If finalSpin = False Then
                                    puzzleSolved = False
                                    round = PuzzleType.R7
                                    wheelLoad(PuzzleType.R7)
                                    loadPuzzle(PuzzleType.R7, puzzleMode, False)
                                    frmScore.tmrCheckVowels.Start()
                                    frmPuzzleBoard.wheelTilt.Enabled = True

                                Else
                                    checkBonusRoundWinner()
                                End If
                            ElseIf round = PuzzleType.R7 Then
                                If finalSpin = False Then
                                    puzzleSolved = False
                                    round = PuzzleType.R8
                                    wheelLoad(PuzzleType.R8)
                                    loadPuzzle(PuzzleType.R8, puzzleMode, False)
                                    frmScore.tmrCheckVowels.Start()
                                    frmPuzzleBoard.wheelTilt.Enabled = True

                                Else
                                    checkBonusRoundWinner()
                                End If
                            ElseIf round = PuzzleType.R8 Then
                                If finalSpin = False Then
                                    puzzleSolved = False
                                    round = PuzzleType.R9
                                    wheelLoad(PuzzleType.R9)
                                    loadPuzzle(PuzzleType.R9, puzzleMode, False)
                                    frmScore.tmrCheckVowels.Start()
                                    frmPuzzleBoard.wheelTilt.Enabled = True

                                Else
                                    checkBonusRoundWinner()
                                End If
                            ElseIf round = PuzzleType.R9 Then
                                checkBonusRoundWinner()
                            ElseIf round = PuzzleType.TBTU Then
                                checkBonusRound()
                            End If
                            For Each lettersControls As Control In frmPuzzleBoard.Controls(puzzleBoardName).Controls
                                If lettersControls.GetType() Is GetType(PuzzleBoardLetter) Then
                                    If CType(lettersControls, PuzzleBoardLetter).letterBehind = "'" Or CType(lettersControls, PuzzleBoardLetter).letterBehind = "?" Or CType(lettersControls, PuzzleBoardLetter).letterBehind = "." Or CType(lettersControls, PuzzleBoardLetter).letterBehind = "!" Or CType(lettersControls, PuzzleBoardLetter).letterBehind = "-" Or CType(lettersControls, PuzzleBoardLetter).letterBehind = "/" Or CType(lettersControls, PuzzleBoardLetter).letterBehind = ":" Or CType(lettersControls, PuzzleBoardLetter).letterBehind = "\" Or CType(lettersControls, PuzzleBoardLetter).letterBehind = "&" Then
                                        CType(lettersControls, PuzzleBoardLetter).revealLetter()
                                    Else
                                        CType(lettersControls, PuzzleBoardLetter).btnLetter.BackgroundImage = Nothing
                                        CType(lettersControls, PuzzleBoardLetter).btnLetter.Text = ""
                                    End If
                                End If
                            Next
                            If round <> PuzzleType.BR Then
                                frmPuzzleBoard.CategoryStrip1.lblCategory.Text = category
                            Else
                                frmPuzzleBoard.CategoryStrip1.lblCategory.Text = ""
                                frmPuzzleBoard.CategoryStrip1.Hide()
                                frmPuzzleBoard.lblChosenLetters.Hide()
                                frmPuzzleBoard.lblRSTLNE.Hide()
                                frmScore.BonusCardEnvelope1.Hide()
                                frmScore.usedLetterBoard.Enabled = False
                                frmPuzzleBoard.btnSolve.Enabled = False
                                For Each letterController As Control In frmPuzzleBoard.Controls(puzzleBoardName).Controls
                                    If letterController.GetType() Is GetType(PuzzleBoardLetter) Then
                                        CType(letterController, PuzzleBoardLetter).Hide()
                                    End If
                                Next
                            End If
                            revealed = False
                        End If
                    End If
                ElseIf preview = True Then
                    For Each lettersControls As Control In frmPuzzleBoard.Controls(puzzleBoardName).Controls
                        If lettersControls.GetType() Is GetType(PuzzleBoardLetter) Then
                            CType(lettersControls, PuzzleBoardLetter).revealLetter()
                        End If
                    Next

                    If revealed = True And previewPlay = True Then
                        currentPlayer = Nothing
                        currentPlayerObject = Nothing
                        frmScore.Close()
                        frmPuzzleBoard.Close()
                        frmCustomizer.Show()
                    ElseIf revealed = False And previewPlay = True Then
                        If round = PuzzleType.TU1 Or round = PuzzleType.TU2 Or round = PuzzleType.TU3 Then
                            My.Computer.Audio.Play(My.Resources.toss_up_solved, AudioPlayMode.WaitToComplete)
                            resetPuzzle()
                        ElseIf round = PuzzleType.BR Then
                            My.Computer.Audio.Play(My.Resources.music_bonus_win_vamp_new, AudioPlayMode.BackgroundLoop)
                            resetPuzzle()
                        Else
                            My.Computer.Audio.Play(My.Resources.puzzle_solved_new, AudioPlayMode.WaitToComplete)
                            resetPuzzle()
                        End If
                        revealed = True
                    End If
                End If
                houseMinimumMet = False
            Else
                cancelSolve()
            End If
        End If
    End Sub
    Public Shared Sub revealPuzzleWinner()
        If virtualHost = True Then
            Dim solveMessage = GetRandomPlayer(0, 2)
            If solveMessage = 0 Then
                SAPI = CreateObject("SAPI.spvoice")
                SAPI.Speak("Good job " & CType(frmScore.Controls("NameTag" & currentPlayer), NameTag).lblName.Text & " You solved the puzzle.")
            Else
                SAPI = CreateObject("SAPI.spvoice")
                SAPI.Speak("Congratulations " & CType(frmScore.Controls("NameTag" & currentPlayer), NameTag).lblName.Text & " on solving the puzzle.")
            End If
            'If round = PuzzleType.TU1 Then
            '    SAPI = CreateObject("SAPI.spvoice")
            '    SAPI.Speak("You get the thousand dollars.")
            If round = PuzzleType.TU2 Then
                SAPI = CreateObject("SAPI.spvoice")
                SAPI.Speak("You get the $2,000 and you'll be spinning first.")
            ElseIf round = PuzzleType.TU3 Then
                SAPI = CreateObject("SAPI.spvoice")
                SAPI.Speak("You get the $3,000 and you'll spin first.")
            End If
        End If
    End Sub
    Public Shared Sub revealCategory()
        If virtualHost = True Then
            If round = PuzzleType.TU1 Then
                If virtualHost = True Then
                    SAPI.Speak("Welcome to Wheel of Fortune. All right, everybody grab those signaling devices. It's time for the first toss-up of the night. It's worth $1,000. And the category is..." & category, SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                    checkTossUpIntro()
                End If
            ElseIf round = PuzzleType.TU2 Then
                If virtualHost = True Then
                    SAPI.Speak("Our second toss-up of the night is worth $2,000. The category is..." & category, SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                    checkTossUpIntro()
                End If
            ElseIf round = PuzzleType.R1 Then
                If crosswordStatus = 0 Then
                    If virtualHost = True Then
                        If numberOfPlayers > 1 Then
                            SAPI.Speak("And the category for our first puzzle of the night is..." & category & " , " & CType(frmScore.Controls("NameTag" & currentPlayer), NameTag).lblName.Text & ", you won the right to give the first spin.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                        Else
                            SAPI.Speak("And the category for our first puzzle of the night is..." & category & " , " & CType(frmScore.Controls("NameTag" & currentPlayer), NameTag).lblName.Text & ", you get ten turns per round. The round ends when you run out of turns or correctly solve the puzzle. Go ahead and spin the wheel.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                        End If
                    End If
                Else
                    Dim underscoreString = returnUnderscore(category)
                    If virtualHost = True Then
                        If underscoreString <> "" Then
                            SAPI.Speak("It's time for one of our Wheel of Fortune crosswords. And the clue is..." & category.Replace(underscoreString, "blank") & " , " & CType(frmScore.Controls("NameTag" & currentPlayer), NameTag).lblName.Text & ", it's your turn to spin.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                        Else
                            SAPI.Speak("It's time for one of our Wheel of Fortune crosswords. And the clue is..." & category & " , " & CType(frmScore.Controls("NameTag" & currentPlayer), NameTag).lblName.Text & ", it's your turn to spin.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                        End If
                    End If
                End If
            ElseIf round = PuzzleType.R2 Then
                If crosswordStatus = 0 Then
                    If virtualHost = True Then
                        SAPI.Speak("And the category for our second round is..." & category & " , " & CType(frmScore.Controls("NameTag" & currentPlayer), NameTag).lblName.Text & ", it's your turn to spin.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                    End If
                Else
                    Dim underscoreString = returnUnderscore(category)
                    If virtualHost = True Then
                        If underscoreString <> "" Then
                            SAPI.Speak("It's time for one of our Wheel of Fortune crosswords. And the clue is..." & category.Replace(underscoreString, "blank") & " , " & CType(frmScore.Controls("NameTag" & currentPlayer), NameTag).lblName.Text & ", it's your turn to spin.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                        Else
                            SAPI.Speak("It's time for one of our Wheel of Fortune crosswords. And the clue is..." & category & " , " & CType(frmScore.Controls("NameTag" & currentPlayer), NameTag).lblName.Text & ", it's your turn to spin.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                        End If
                    End If
                End If
            ElseIf round = PuzzleType.R3 Then
                If crosswordStatus = 0 Then
                    If virtualHost = True Then
                        SAPI.Speak("And the category for our third puzzle of the night is..." & category + " That sound means it's also our Prize Puzzle round." & " , " & CType(frmScore.Controls("NameTag" & currentPlayer), NameTag).lblName.Text & ", go ahead and spin it.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                    End If
                Else
                    Dim underscoreString = returnUnderscore(category)
                    If virtualHost = True Then
                        If underscoreString <> "" Then
                            SAPI.Speak("It's time for one of our Wheel of Fortune crosswords. And the clue is..." & category.Replace(underscoreString, "blank") & " , " & CType(frmScore.Controls("NameTag" & currentPlayer), NameTag).lblName.Text & ", go ahead and spin it.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                        Else
                            SAPI.Speak("It's time for one of our Wheel of Fortune crosswords. And the clue is..." & category & " , " & CType(frmScore.Controls("NameTag" & currentPlayer), NameTag).lblName.Text & ", go ahead and spin it.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                        End If
                    End If
                End If
            ElseIf round = PuzzleType.TU3 Then
                If virtualHost = True Then
                    SAPI.Speak("And the category for our third toss-up of the night is..." & category, SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                    checkTossUpIntro()
                End If
            ElseIf round = PuzzleType.R4 Then
                If virtualHost = True Then
                    SAPI.Speak("And the category for our fourth round of the night is..." & category & " , " & CType(frmScore.Controls("NameTag" & currentPlayer), NameTag).lblName.Text & ", spin that wheel.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                End If
            ElseIf round = PuzzleType.R5 Then
                If virtualHost = True Then
                    SAPI.Speak("We have time for another round. The category for our next round is..." & category & " , " & CType(frmScore.Controls("NameTag" & currentPlayer), NameTag).lblName.Text & ", it's your turn.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                End If
            ElseIf round = PuzzleType.R6 Then
                If virtualHost = True Then
                    SAPI.Speak("We are blowing through these puzzles. The category for our next round is..." & category & " , " & CType(frmScore.Controls("NameTag" & currentPlayer), NameTag).lblName.Text & ", it's your turn to spin.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                End If
            ElseIf round = PuzzleType.R7 Then
                If virtualHost = True Then
                    SAPI.Speak("The category for our next round is..." & category & " , " & CType(frmScore.Controls("NameTag" & currentPlayer), NameTag).lblName.Text & ", it's your turn to spin.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                End If
            ElseIf round = PuzzleType.R8 Then
                If virtualHost = True Then
                    SAPI.Speak("The category for our next round is..." & category & " , " & CType(frmScore.Controls("NameTag" & currentPlayer), NameTag).lblName.Text & ", it's your turn to spin.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                End If
            ElseIf round = PuzzleType.R9 Then
                If virtualHost = True Then
                    SAPI.Speak("The category for our next round is..." & category & " , " & CType(frmScore.Controls("NameTag" & currentPlayer), NameTag).lblName.Text & ", it's your turn to spin.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                End If
            ElseIf round = PuzzleType.TBTU Then
                If virtualHost = True Then
                    SAPI.Speak("We currently have a tie. We are going to have a tiebreaker toss-up to determmine who goes onto the bonus round. The category is..." & category, SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                End If
            End If
        End If
        'If Not SAPI Is Nothing Then
        '    Do
        '        If round = PuzzleType.R3 Then
        '            If SAPI.Status.RunningState = SpeechLib.SpeechRunState.SRSEDone Then
        '                My.Computer.Audio.Play(My.Resources.prize_puzzle_reveal, AudioPlayMode.Background)
        '                Exit Do
        '            End If
        '        Else
        '            If SAPI.Status.RunningState = SpeechLib.SpeechRunState.SRSEDone Then
        '                My.Computer.Audio.Play(My.Resources.puzzle_reveal, AudioPlayMode.Background)
        '                Exit Do
        '            End If
        '        End If
        '    Loop
        'Else
        If round = PuzzleType.R3 Then
            My.Computer.Audio.Play(My.Resources.prize_puzzle_reveal, AudioPlayMode.Background)
        Else
            My.Computer.Audio.Play(My.Resources.puzzle_reveal, AudioPlayMode.Background)
        End If
        'End If
    End Sub
    Private Shared Sub checkTossUpIntro()
        Do
            If Not SAPI Is Nothing Then
                If SAPI.Status.RunningState = SpeechLib.SpeechRunState.SRSEDone Then
                    tossUpIntroComplete = True
                    Exit Do
                End If
            End If
        Loop
    End Sub
    Private Shared Function returnUnderscore(category As String) As String
        Dim underscoreString = ""
        For Each underscore As Char In category
            If underscore = "_" Then
                underscoreString &= underscore.ToString()
            End If
        Next
        Return underscoreString
    End Function
    Public Shared Sub checkBonusRoundWinner()

        If CInt(player1.total) = 0 Then
            player1.total += 1000
        ElseIf CInt(player2.total) = 0 Then
            player2.total += 1000
        ElseIf CInt(player3.total) = 0 Then
            player3.total += 1000
        End If
        If CInt(player1.total) > CInt(player2.total) And CInt(player1.total) > CInt(player3.total) Then
            currentPlayer = 1
            bonusRoundPlayer = player1
            checkBonusRound()
        ElseIf CInt(player2.total) > CInt(player1.total) And CInt(player2.total) > CInt(player3.total) Then
            currentPlayer = 2
            bonusRoundPlayer = player2
            checkBonusRound()
        ElseIf CInt(player3.total) > CInt(player1.total) And CInt(player3.total) > CInt(player2.total) Then
            currentPlayer = 3
            bonusRoundPlayer = player3
            checkBonusRound()
        Else
            'If spun = True Then
            'frmPuzzleBoard.btnRedRingIn.Enabled = True
            'frmPuzzleBoard.btnYellowRingIn.Enabled = True
            'frmPuzzleBoard.btnBlueRingIn.Enabled = True
            frmPuzzleBoard.wheelTilt.Enabled = False
            frmPuzzleBoard.btnWild.Hide()
            frmScore.usedLetterBoard.Enabled = False
            tossUpLetterControlList.Clear()
            frmPuzzleBoard.tmrTossUpRingIn.Stop()
            round = PuzzleType.TBTU
            frmPuzzleBoard.CategoryStrip1.Hide()
            loadTossUp()
            frmPuzzleBoard.tmrTossUpReveal.Start()
            'My.Computer.Audio.Play(My.Resources.puzzle_reveal, AudioPlayMode.Background)
            puzzleSolved = False
            wheelLoad(PuzzleType.TBTU)
            loadPuzzle(PuzzleType.TBTU, puzzleMode, False)
            tossUpStarted = False
            currentPlayer = Nothing
            frmScore.tmrCheckVowels.Stop()
            Exit Sub
            'Else
            'End If
        End If
    End Sub
    Public Shared Sub checkBonusRound()
        frmScore.lblPlayer1.Text = ""
        frmScore.lblPlayer2.Text = ""
        frmScore.lblPlayer3.Text = ""
        loadBonusCategories(puzzleMode)
        If puzzleMode = wheelMode.Disney Then
            For i As Integer = 0 To categoryList.Count - 1
                CType(frmScore.flpBonusCategories.Controls("CategoryStrip" & (i + 1)), CategoryStrip).lblCategory.Text = categoryList(i).category
            Next
        Else
            For i As Integer = 0 To bonusCategoriesList.Count - 1
                CType(frmScore.flpBonusCategories.Controls("CategoryStrip" & (i + 1)), CategoryStrip).lblCategory.Text = bonusCategoriesList(i)
            Next
        End If
        frmScore.flpBonusCategories.Show()
        frmScore.lblNumberOfTurns.Hide()
        frmPuzzleBoard.wheelTilt.Enabled = True
        frmPuzzleBoard.btnRedRingIn.Hide()
        frmPuzzleBoard.btnYellowRingIn.Hide()
        frmPuzzleBoard.btnBlueRingIn.Hide()
        puzzleSolved = False
        frmPuzzleBoard.CategoryStrip1.Hide()
        round = PuzzleType.BR
        wheelLoad(PuzzleType.BR)
        frmPuzzleBoard.CategoryStrip1.Text = ""
        frmPuzzleBoard.btnSpinner.BackgroundImage = My.Resources.BonusWheel
        frmPuzzleBoard.wheelTilt.Show()
        frmPuzzleBoard.wheelTilt.Image = My.Resources.WheelTiltedSmallBonusCards
        frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelSpinBonus.mp4"
        frmPuzzleBoard.wheelTilt.Image = My.Resources.WheelTiltedSmallBonusCards
        frmPuzzleBoard.WheelSpinControl1.wheelCover.BackgroundImage = My.Resources.wheelCoverHDBonus
        frmPuzzleBoard.WheelSpinControl1.firstSpin = True
        frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.stop()
        frmScore.tmrCheckVowels.Stop()
        frmScore.tmrFinalSpin.Stop()
        finalSpin = False
        finalSpinSpun = False
        frmScore.usedLetterBoard.Enabled = False
        frmScore.lblCurrentValue.Hide()
        frmScore.lblControllerSpinResult.Hide()
        frmPuzzleBoard.btnSolve.Enabled = False
        frmPuzzleBoard.PuzzleBoard1.Enabled = False
        If virtualHost = True Then
            SAPI = CreateObject("SAPI.spvoice")
            SAPI.Speak("Congratulations, " & CType(frmScore.Controls("NameTag" & currentPlayer), NameTag).lblName.Text & " You're the big winner. You'll be moving on to the bonus round. You can pick from three categories tonight.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
        End If
        If virtualHost = True Then
            For i As Integer = 0 To 2
                SAPI.Speak(CType(frmScore.flpBonusCategories.Controls("CategoryStrip" & (i + 1)), CategoryStrip).lblCategory.Text, SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
            Next
        End If
    End Sub
#End Region
#Region "Save Progress to DB"
    Private Shared Sub saveToDB()
        Dim roundString As String = ""
        Dim finalSpin As Integer = 0
        If revealed = True Then
            If round = PuzzleType.TU1 Then
                roundString = "TU2"
            ElseIf round = PuzzleType.TU2 Then
                roundString = "R1"
            ElseIf round = PuzzleType.R1 Then
                roundString = "R2"
            ElseIf round = PuzzleType.R2 Then
                roundString = "R3"
            ElseIf round = PuzzleType.R3 Then
                roundString = "TU3"
            ElseIf round = PuzzleType.TU3 Then
                roundString = "R4"
            ElseIf round = PuzzleType.R4 And Not finalSpin = True Then
                roundString = "R5"
            ElseIf round = PuzzleType.R5 And Not finalSpin = True Then
                roundString = "R6"
            ElseIf round = PuzzleType.R6 And Not finalSpin = True Then
                roundString = "R7"
            ElseIf round = PuzzleType.R7 And Not finalSpin = True Then
                roundString = "R8"
            ElseIf round = PuzzleType.R8 And Not finalSpin = True Then
                roundString = "R9"
            ElseIf round = PuzzleType.R9 Or finalSpin = True Then
                roundString = "BR"
            End If
        Else
            If round = PuzzleType.TU1 Then
                roundString = "TU1"
            ElseIf round = PuzzleType.TU2 Then
                roundString = "TU2"
            ElseIf round = PuzzleType.R1 Then
                roundString = "R1"
            ElseIf round = PuzzleType.R2 Then
                roundString = "R2"
            ElseIf round = PuzzleType.R3 Then
                roundString = "R3"
            ElseIf round = PuzzleType.TU3 Then
                roundString = "TU3"
            ElseIf round = PuzzleType.R4 Then
                roundString = "R4"
            ElseIf round = PuzzleType.R5 Then
                roundString = "R5"
            ElseIf round = PuzzleType.R6 Then
                roundString = "R6"
            ElseIf round = PuzzleType.R7 Then
                roundString = "R7"
            ElseIf round = PuzzleType.R8 Then
                roundString = "R8"
            ElseIf round = PuzzleType.R9 Then
                roundString = "R9"
            ElseIf round = PuzzleType.BR Then
                roundString = "BR"
            End If
            If finalSpin = True Then
                finalSpin = 1
            End If
        End If
        Dim connPuzzle As SqlConnection
        connPuzzle = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" & Application.StartupPath & "\WheelPuzzles.mdf;Integrated Security=True")
        Dim strSQL As String
        strSQL = "Update GAMES Set PackName = @PackName, VirtualHost = @VirtualHost, TypeToSolve = @TypeToSolve, RoundNumber = @RoundNumber, Puzzle = @Puzzle, Team = @Teams WHERE Id = @GameId"
        Dim cmd As SqlCommand
        Dim puzzleParam As SqlParameter = New SqlParameter("@Puzzle", "")
        Dim virtualHostParam As SqlParameter
        If virtualHost = False Then
            virtualHostParam = New SqlParameter("@VirtualHost", 0)
        Else
            virtualHostParam = New SqlParameter("@VirtualHost", 1)
        End If
        Dim typeToSolveParam As SqlParameter
        If typeToSolve = False Then
            typeToSolveParam = New SqlParameter("@TypeToSolve", 0)
        Else
            typeToSolveParam = New SqlParameter("@TypeToSolve", 1)
        End If
        Dim teamsParam As SqlParameter
        If teams = False Then
            teamsParam = New SqlParameter("@Teams", 0)
        Else
            teamsParam = New SqlParameter("@Teams", 1)
        End If
        Dim roundNumberParam As SqlParameter = New SqlParameter("@RoundNumber", "TU1")
        Dim packNameParam As SqlParameter = New SqlParameter("@PackName", packName)
        Dim gameIDParam As SqlParameter = New SqlParameter("@GameId", gameID)
        connPuzzle.Open()
        cmd = New SqlCommand(strSQL, connPuzzle)
        cmd.Parameters.Add(packNameParam)
        cmd.Parameters.Add(virtualHostParam)
        cmd.Parameters.Add(typeToSolveParam)
        cmd.Parameters.Add(roundNumberParam)
        cmd.Parameters.Add(teamsParam)
        cmd.Parameters.Add(puzzleParam)
        cmd.Parameters.Add(gameIDParam)
        cmd.CommandType = CommandType.Text
        'Dim gameID = Integer.Parse(cmd.ExecuteScalar())
        connPuzzle.Close()
        For i As Integer = 1 To 3
            Dim strNewSQL As String
            strNewSQL = "UPDATE GamePlayer Set Total = @total, RoundWinnings = @RoundWinnings WHERE Contestant_ID = @Contestant_ID and Game_ID = @Game_ID"
            Dim contestantcmd As SqlCommand
            Dim contestantIDParam As SqlParameter
            Dim totalParam As SqlParameter
            Dim roundWinningsParam As SqlParameter
            Dim gameParam As SqlParameter = New SqlParameter("@Game_ID", gameID)
            If i = 1 Then
                contestantIDParam = New SqlParameter("@Contestant_ID", player1.ContestantID)
                totalParam = New SqlParameter("@total", player1.total)
                roundWinningsParam = New SqlParameter("@RoundWinnings", player1Score)
            ElseIf i = 2 Then
                contestantIDParam = New SqlParameter("@Contestant_ID", player2.ContestantID)
                totalParam = New SqlParameter("@total", player2.total)
                roundWinningsParam = New SqlParameter("@RoundWinnings", player2Score)
            ElseIf i = 3 Then
                contestantIDParam = New SqlParameter("@Contestant_ID", player3.ContestantID)
                totalParam = New SqlParameter("@total", player3.total)
                roundWinningsParam = New SqlParameter("@RoundWinnings", player3Score)
            End If
            connPuzzle.Open()
            contestantcmd = New SqlCommand(strNewSQL, connPuzzle)
            contestantcmd.Parameters.Add(contestantIDParam)
            contestantcmd.Parameters.Add(gameParam)
            contestantcmd.Parameters.Add(totalParam)
            contestantcmd.Parameters.Add(roundWinningsParam)
            contestantcmd.CommandType = CommandType.Text
            contestantcmd.ExecuteNonQuery()
            connPuzzle.Close()
            If round = PuzzleType.BR Then
                Dim strContestantSQL As String
                strContestantSQL = "UPDATE Contestant Set Winnings += @Winnings WHERE Id = @Contestant_ID"
                Dim contestantFinalcmd As SqlCommand
                Dim contestantIDFinalParam As SqlParameter
                Dim winningsParam As SqlParameter
                If i = 1 Then
                    contestantIDFinalParam = New SqlParameter("@Contestant_ID", player1.ContestantID)
                    winningsParam = New SqlParameter("@Winnings", player1.total)
                ElseIf i = 2 Then
                    contestantIDFinalParam = New SqlParameter("@Contestant_ID", player2.ContestantID)
                    winningsParam = New SqlParameter("@Winnings", player2.total)
                ElseIf i = 3 Then
                    contestantIDFinalParam = New SqlParameter("@Contestant_ID", player3.ContestantID)
                    winningsParam = New SqlParameter("@Winnings", player3.total)
                End If
                connPuzzle.Open()
                contestantFinalcmd = New SqlCommand(strContestantSQL, connPuzzle)
                contestantFinalcmd.Parameters.Add(contestantIDFinalParam)
                contestantFinalcmd.Parameters.Add(winningsParam)
                contestantFinalcmd.CommandType = CommandType.Text
                contestantFinalcmd.ExecuteNonQuery()
                connPuzzle.Close()
            End If
        Next
    End Sub
#End Region
#Region "Random Number Generator Toss-Up"
    Public Shared Function GetRandom() As Integer
        ' by making Generator static, we preserve the same instance '
        ' (i.e., do not create new instances with the same seed over and over) '
        ' between calls '
        Static Generator As Random = New System.Random()
        Return Generator.Next(tossUpLetterControlList.Count)
    End Function
#End Region
#Region "Random Number Generator Regular"
    Public Shared Function GetRandomRegular() As Integer
        ' by making Generator static, we preserve the same instance '
        ' (i.e., do not create new instances with the same seed over and over) '
        ' between calls '
        Static Generator As Random = New System.Random()
        Return Generator.Next(letterControlList.Count)
    End Function
#End Region
#Region "Random Number Generator Wheel"
    Public Shared Function GetRandomWheel() As Integer
        ' by making Generator static, we preserve the same instance '
        ' (i.e., do not create new instances with the same seed over and over) '
        ' between calls '
        Static Generator As Random = New System.Random()
        Return Generator.Next(1, 4)
    End Function
    Public Shared Function GetRandomBonusWheel(Min As Integer, Max As Integer) As Integer
        ' by making Generator static, we preserve the same instance '
        ' (i.e., do not create new instances with the same seed over and over) '
        ' between calls '
        Static Generator As Random = New System.Random()
        Return Generator.Next(Min, Max)
    End Function
#End Region
#Region "Random Number Generator Player"
    Public Shared Function GetRandomPlayer(Min As Integer, Max As Integer) As Integer
        ' by making Generator static, we preserve the same instance '
        ' (i.e., do not create new instances with the same seed over and over) '
        ' between calls '
        Static Generator As Random = New System.Random()
        Return Generator.Next(Min, Max)
    End Function
#End Region
#Region "Seconds Converter"
    Public Shared Function convertTime(time As Integer) As Integer
        'Dim i As Integer = 1
        If time = 59 Then
            Return 0
        Else
            Return time + 1
        End If
    End Function
#End Region
#Region "Seconds Converter 2"
    Public Shared Function convertTimeToSeconds(time As Integer) As Integer
        'Dim i As Integer = 1
        If time >= 60 Then
            Return time - 60
        Else
            Return time
        End If
    End Function
#End Region
#Region "Seconds Converter for Toss-Up Reveal"
    Public Shared Function convertTimeTossUpReveal(time As Integer) As Integer
        'Dim i As Integer = 1
        If time = 59 Then
            Return 1
        Else
            Return time + 2
        End If
    End Function
#End Region
#Region "Load Letters in Toss-Up"
    Public Shared Sub startTossUp()
        My.Computer.Audio.Play(My.Resources.toss_up_new, AudioPlayMode.BackgroundLoop)
        'Dim letterInTossUp As Integer = 1
        If tossUpLetters.Count > 0 Then
            tossUpLetters.Clear()
        End If
        If tossUpLetterControlList.Count = 0 Then
            For Each item As Control In frmPuzzleBoard.PuzzleBoard1.Controls
                'If letterControl.GetType() Is GetType(PuzzleBoardLetter) Then
                '    If CType(letterControl, PuzzleBoardLetter).letterBehind <> "" Then
                If item.Visible = True And checkForSymbols(CType(item, PuzzleBoardLetter).letterBehind) = False And CType(item, PuzzleBoardLetter).letterBehind <> " " Then
                    tossUpLetterControlList.Add(item.Name.ToString.Replace("PuzzleBoardLetter", ""))
                End If
                '    End If
                'End If
            Next
            'For Each item As KeyValuePair(Of Integer, String) In letterControlSortedList1
            '    'If letterControl.GetType() Is GetType(PuzzleBoardLetter) Then
            '    '    If CType(letterControl, PuzzleBoardLetter).letterBehind <> "" Then
            '    If item.Value <> " " Then
            '        tossUpLetterControlList.Add(item.Key.ToString.Replace("PuzzleBoardLetter", ""))
            '    End If
            '    '    End If
            '    'End If
            'Next
            'For Each item As KeyValuePair(Of Integer, String) In letterControlSortedList2
            '    'If letterControl.GetType() Is GetType(PuzzleBoardLetter) Then
            '    '    If CType(letterControl, PuzzleBoardLetter).letterBehind <> "" Then
            '    'If letterControlSortedList2.Count = 14 Then
            '    If item.Value <> " " Then
            '        tossUpLetterControlList.Add((item.Key + trillonOffset).ToString.Replace("PuzzleBoardLetter", ""))
            '    End If
            '    'Else
            '    '    If item.Value <> " " Then
            '    '        tossUpLetterControlList.Add(item.Key.ToString.Replace("PuzzleBoardLetter", ""))
            '    '    End If
            '    'End If
            '    'End If
            '    'End If
            'Next
            'For Each item As KeyValuePair(Of Integer, String) In letterControlSortedList3
            '    'If letterControl.GetType() Is GetType(PuzzleBoardLetter) Then
            '    '    If CType(letterControl, PuzzleBoardLetter).letterBehind <> "" Then
            '    'If letterControlSortedList3.Count = 14 Then
            '    If item.Value <> " " Then
            '            tossUpLetterControlList.Add((item.Key + trillonOffset).ToString.Replace("PuzzleBoardLetter", ""))
            '        End If
            '    'Else
            '    '    If item.Value <> " " Then
            '    '        tossUpLetterControlList.Add(item.Key.ToString.Replace("PuzzleBoardLetter", ""))
            '    '    End If
            '    'End If
            '    '    End If
            '    'End If
            'Next
            'For Each item As KeyValuePair(Of Integer, String) In letterControlSortedList4
            '    'If letterControl.GetType() Is GetType(PuzzleBoardLetter) Then
            '    '    If CType(letterControl, PuzzleBoardLetter).letterBehind <> "" Then
            '    If item.Value <> " " Then
            '        tossUpLetterControlList.Add(item.Key.ToString.Replace("PuzzleBoardLetter", ""))
            '    End If
            '    '    End If
            '    'End If
            'Next
        End If
        frmPuzzleBoard.timeStart = DateTime.Now.Second
        frmPuzzleBoard.tmrTossUp.Start()
        'frmPuzzleBoard.tossUp()

        'For i As Integer = 0 To puzzle.Length - 1
        '    If puzzle(i).ToString() <> " " Then
        '        tossUpLetters.Add(i + 1, puzzle(i).ToString)
        '        keyNumber.Add(i + 1)
        '    End If
        '    'letterInTossUp += 1
        '    '        End If
        '    '    End If
        '    'Next
        'Next
        'For letterI As Integer = 0 To keyNumber.Count
        '    'For Each letterControl As Control In frmPuzzleBoard.Controls
        '    '    If letterControl.GetType() Is GetType(PuzzleBoardLetter) Then
        '    '        If CType(letterControl, PuzzleBoardLetter).letterBehind <> "" Then
        '    If lastProgressValue = frmPuzzleBoard.pbarTossUp.Value - 25 Or frmPuzzleBoard.pbarTossUp.Value = 0 Then
        '        For Each item As Integer In keyNumber
        '            Dim randomLetter = tossUpRandom.Next(keyNumber.Count)
        '            Dim randomLetterKey = keyNumber(randomLetter)
        '            'For myi = 1 To frmPuzzleBoard.trkTossUp.Maximum
        '            '    'While i <= TrackBar1.Maximum
        '            'frmPuzzleBoard.trkTossUp.Value = myi
        '            '    'End While
        '            'Next
        '            'For Each letterControl As Control In frmPuzzleBoard.Controls
        '            '    If letterControl.GetType() Is GetType(PuzzleBoardLetter) Then
        '            '        Try
        '            '            If CType(letterControl, PuzzleBoardLetter).letterBehind = tossUpLetters(randomLetter) AndAlso tossUpLetters(randomLetter) <> " " Then
        '            If tossUpLetters(randomLetterKey) <> " " Then
        '                If puzzle.Length <= 28 Then
        '                    CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & (randomLetter + 13).ToString()), PuzzleBoardLetter).letterPicture.Image = FadeBitmap(My.Resources.Wild_Card, 0.5)
        '                    'CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & (randomLetter + 13).ToString()), PuzzleBoardLetter).letterPicture.Show()
        '                    tossUpLetterList.Add("PuzzleBoardLetter" & (randomLetterKey + 13).ToString())
        '                    'CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & (randomLetterKey) + 13), PuzzleBoardLetter).revealLetter()
        '                    'tossUpLetterList.Add(CType(letterControl, PuzzleBoardLetter))
        '                    'CType(letterControl, PuzzleBoardLetter).revealLetter()
        '                    'keyNumber.Remove(randomLetterKey)
        '                    For myI = 1 To 25
        '                    frmPuzzleBoard.pbarTossUp.Value += 1
        '                    Next
        '                frmPuzzleBoard.frmScore.lblProgress.Text = frmPuzzleBoard.pbarTossUp.Value.ToString() & "/" & frmPuzzleBoard.pbarTossUp.Maximum.ToString() & "/ i=" & letterI & "LetterID=" & item.ToString()
        '                    currentPuzzleBoardLetter = "PuzzleBoardLetter" & (randomLetterKey + 13)
        '                frmPuzzleBoard.PerformLayout()
        '                    'Dim decAmnt As Integer = tossUpLetters.Keys(0)
        '                    'For tossUpKey As Integer = 0 To tossUpLetters.Count
        '                    '    Dim oldKey As Integer = tossUpLetters.Keys(i)
        '                    '    Dim val As String = tossUpLetters(oldKey)
        '                    '    Dim newKey As Integer = oldKey - decAmnt
        '                    '    tossUpLetters.Remove(oldKey)
        '                    '    tossUpLetters.Add(newKey, val)
        '                    'Next
        '                    'For Each tossUpKey As KeyValuePair(Of Integer, String) In tossUpLetters

        '                    'Next
        '                    'Exit For
        '                ElseIf puzzle.Length > 28 Then
        '                    CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & (randomLetter + 1).ToString()), PuzzleBoardLetter).letterPicture.Image = FadeBitmap(My.Resources.Wild_Card, 0.5)
        '                    'CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & (randomLetter + 1).ToString()), PuzzleBoardLetter).letterPicture.Show()
        '                    'CType(letterControl, PuzzleBoardLetter).revealLetter()
        '                    tossUpLetterList.Add("PuzzleBoardLetter" & (randomLetterKey + 1).ToString())
        '                    'CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & (randomLetterKey) + 1), PuzzleBoardLetter).revealLetter()
        '                    'tossUpLetterList.Add(CType(letterControl, PuzzleBoardLetter))
        '                    'keyNumber.Remove(randomLetterKey)
        '                    For myI = 1 To 25
        '                    frmPuzzleBoard.pbarTossUp.Value += 1
        '                    Next
        '                frmPuzzleBoard.frmScore.lblProgress.Text = frmPuzzleBoard.pbarTossUp.Value.ToString() & "/" & frmPuzzleBoard.pbarTossUp.Maximum.ToString() & "/ i=" & letterI & "LetterID=" & item.ToString()
        '                    currentPuzzleBoardLetter = "PuzzleBoardLetter" & (randomLetterKey) + 1
        '                frmPuzzleBoard.PerformLayout()
        '                    'lastProgressValue += 25
        '                    'Dim decAmnt As Integer = tossUpLetters.Keys(0)
        '                    'For tossUpKey As Integer = 0 To tossUpLetters.Count
        '                    '    Dim oldKey As Integer = tossUpLetters.Keys(i)
        '                    '    Dim val As String = tossUpLetters(oldKey)
        '                    '    Dim newKey As Integer = oldKey - decAmnt
        '                    '    tossUpLetters.Remove(oldKey)
        '                    '    tossUpLetters.Add(newKey, val)
        '                    'Next
        '                    'For Each tossUpKey As KeyValuePair(Of Integer, String) In tossUpLetters

        '                    'Next
        '                    'Exit For
        '                End If
        '            End If
        '            'Else
        '        Next
        '    End If
        '                Catch ex As Exception
        '                End Try
        'End If
        'End If
        'Next
        '    Next
        'End If
        'If round = PuzzleType.TU1 Or round = PuzzleType.TU2 Or round = PuzzleType.TU3 Then
        '    For i As Integer = 0 To puzzle.Count - 1
        '        If Not puzzle.Chars(i).ToString() = " " OrElse Not puzzle.Chars(i).ToString() = "" Then
        '            tossUpLettersRevealed.Add(puzzle.Chars(i).ToString())
        '        End If
        '    Next
        'End If
    End Sub
#End Region
#Region "Bankrupt"
    Public Shared Sub bankrupt()
        spinResult = 0
        previousValue = "Bankrupt"
        frmPuzzleBoard.logoExpress.Hide()
        spun = False
        My.Computer.Audio.Play(My.Resources.bankrupt, AudioPlayMode.Background)
        If virtualHost = True Then
            SAPI = CreateObject("SAPI.spvoice")
            SAPI.Speak("The bankrupt got you. Better luck next time.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
        End If
        If currentPlayer = 1 Then
            frmScore.lblPlayer1.Text = ""
            player1.addCardsOrWedges(Player.Wedges.Gift, False)
            player1.addCardsOrWedges(Player.Wedges.HalfCar1, False)
            player1.addCardsOrWedges(Player.Wedges.HalfCar2, False)
            player1.addCardsOrWedges(Player.Wedges.Million, False)
            player1.addCardsOrWedges(Player.Wedges.Mystery, False)
            player1.addCardsOrWedges(Player.Wedges.Prize, False)
            player1.addCardsOrWedges(Player.Wedges.Wild, False)
        ElseIf currentPlayer = 2 Then
            frmScore.lblPlayer2.Text = ""
            player2.addCardsOrWedges(Player.Wedges.Gift, False)
            player2.addCardsOrWedges(Player.Wedges.HalfCar1, False)
            player2.addCardsOrWedges(Player.Wedges.HalfCar2, False)
            player2.addCardsOrWedges(Player.Wedges.Million, False)
            player2.addCardsOrWedges(Player.Wedges.Mystery, False)
            player2.addCardsOrWedges(Player.Wedges.Prize, False)
            player2.addCardsOrWedges(Player.Wedges.Wild, False)
        ElseIf currentPlayer = 3 Then
            frmScore.lblPlayer3.Text = ""
            player3.addCardsOrWedges(Player.Wedges.Gift, False)
            player3.addCardsOrWedges(Player.Wedges.HalfCar1, False)
            player3.addCardsOrWedges(Player.Wedges.HalfCar2, False)
            player3.addCardsOrWedges(Player.Wedges.Million, False)
            player3.addCardsOrWedges(Player.Wedges.Mystery, False)
            player3.addCardsOrWedges(Player.Wedges.Prize, False)
            player3.addCardsOrWedges(Player.Wedges.Wild, False)
        End If
        LoseATurn()
    End Sub
#End Region
#Region "Lose a Turn"
    Public Shared Sub LoseATurn()
        If previousValue <> "Bankrupt" And finalSpin = False Then
            If isNoLetters = False Then
                If virtualHost = True Then
                    If numberOfPlayers > 1 Then
                        SAPI.Speak("You're sitting on a Lose a Turn. Maybe it'll come back to you.")
                    Else
                        SAPI.Speak("You're sitting on a Lose a Turn.")
                    End If
                End If
                End If
            previousValue = "Lose A Turn"
            spun = False
        ElseIf finalSpin = True Then
            spun = True
            previousValue = ""
        Else

        End If
        If frmPuzzleBoard.WheelSpinControl1.trkWheel.Maximum - frmPuzzleBoard.WheelSpinControl1.trkWheel.Value < 7 And Not currentPlayer = 3 And numberOfPlayers > 1 Then
            Dim spinAmountRemaining As Integer = frmPuzzleBoard.WheelSpinControl1.trkWheel.Maximum - frmPuzzleBoard.WheelSpinControl1.trkWheel.Value
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.currentPosition += spinAmountRemaining
            frmPuzzleBoard.WheelSpinControl1.trkWheel.Value += spinAmountRemaining
            If frmPuzzleBoard.WheelSpinControl1.trkWheel.Value = 1 Then
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.currentPosition += (7 - spinAmountRemaining)
                frmPuzzleBoard.WheelSpinControl1.trkWheel.Value += (7 - spinAmountRemaining)
            End If
        ElseIf frmPuzzleBoard.WheelSpinControl1.trkWheel.Maximum - frmPuzzleBoard.WheelSpinControl1.trkWheel.Value >= 7 And Not currentPlayer = 3 And numberOfPlayers > 1 Then
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.currentPosition += 7
            frmPuzzleBoard.WheelSpinControl1.trkWheel.Value += 7
        ElseIf frmPuzzleBoard.WheelSpinControl1.trkWheel.Value - frmPuzzleBoard.WheelSpinControl1.trkWheel.Minimum < 14 And currentPlayer = 3 And numberOfPlayers = 3 Then
            Dim spinAmountRemaining As Integer = 14 - (frmPuzzleBoard.WheelSpinControl1.trkWheel.Value - frmPuzzleBoard.WheelSpinControl1.trkWheel.Minimum)
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.currentPosition = 72 - spinAmountRemaining
            frmPuzzleBoard.WheelSpinControl1.trkWheel.Value = 72 - spinAmountRemaining
            'If frmPuzzleBoard.WheelSpinControl1.trkWheel.Value = 1 Then
            'frmPuzzleBoard.WheelSpinControl1.trkWheel.Value = 72 - spinAmountRemaining
            'frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.currentPosition = 72 - spinAmountRemaining
            'End If
        ElseIf frmPuzzleBoard.WheelSpinControl1.trkWheel.Value - frmPuzzleBoard.WheelSpinControl1.trkWheel.Minimum >= 14 And currentPlayer = 3 And numberOfPlayers = 3 Then
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.currentPosition -= 14
            frmPuzzleBoard.WheelSpinControl1.trkWheel.Value -= 14
        End If
        If previousValue = "Bankrupt" Or previousValue = "Lose A Turn" And finalSpin = False Then
            spinResult = 0
        ElseIf finalSpin = True Then
            spun = True
        Else
        End If
        If currentPlayer <= 2 And numberOfPlayers <> 1 Then
            If currentPlayer = 2 And numberOfPlayers = 2 Then
                currentPlayer = 1
                currentPlayerObject = player1
            ElseIf currentPlayer = 1 Then
                currentPlayer = 2
                currentPlayerObject = player2
            ElseIf currentPlayer = 2 And numberOfPlayers = 3 Then
                currentPlayer = 3
                currentPlayerObject = player3
            End If
        ElseIf currentPlayer > 2 And numberOfPlayers <> 1 Then
            currentPlayer = 1
            currentPlayerObject = player1
        ElseIf numberOfPlayers = 1 Then
            If numberOfTurns >= 1 Then
                numberOfTurns -= 1
                If numberOfTurns = 0 Then
                    'solveAttempt = puzzle
                    solved = True
                End If
            End If

        End If
            If GetConsonants(puzzleString) = 0 Then
            frmPuzzleBoard.wheelTilt.Enabled = False
        Else
            frmPuzzleBoard.wheelTilt.Enabled = True
        End If
        frmPuzzleBoard.btnSolve.Enabled = True
        If virtualHost = True Then
            If numberOfPlayers > 1 Then
                SAPI.Speak(CType(frmScore.Controls("NameTag" & currentPlayer), NameTag).lblName.Text & " Go ahead.")
            ElseIf numberOfPlayers = 1 And numberOfTurns > 1 Then
                SAPI.Speak(CType(frmScore.Controls("NameTag" & currentPlayer), NameTag).lblName.Text & " You just lost a turn. You have " & numberOfTurns & " turns remaining")
            ElseIf numberOfPlayers = 1 And numberOfTurns = 1 Then
                SAPI.Speak(CType(frmScore.Controls("NameTag" & currentPlayer), NameTag).lblName.Text & " You just lost a turn. You have " & numberOfTurns & " turn remaining")
            ElseIf numberOfPlayers = 1 And numberOfTurns = 0 Then
                SAPI.Speak(CType(frmScore.Controls("NameTag" & currentPlayer), NameTag).lblName.Text & " You are out of turns. I'm sorry this is the end of the round.")
            End If
        End If
    End Sub
#End Region
#Region "Reveal Number of Letters"
    Public Shared Function revealNumberOfLetters() As String
        letterSortedList.Clear()
        letterList.Clear()
        ''Dim controlList As New List(Of Integer)
        ''Dim letterSortedList As New SortedList(Of String, Integer)
        ''Dim letterRevealedList As New List(Of String)
        For Each myControl As Control In frmPuzzleBoard.PuzzleBoard1.Controls
            If myControl.GetType() Is GetType(PuzzleBoardLetter) Then
                If letterControlList.Contains(myControl.Name.Replace("PuzzleBoardLetter", "")) Then
                    letterList.Add(CType(myControl, PuzzleBoardLetter).letterBehind)
                Else
                End If
            Else
            End If
        Next
        ''For Each letter As String In letterList
        'Dim groups = letterList.GroupBy(Function(value) value)
        'For Each grp In groups
        '    For i As Integer = 1 To groups.Count
        For i As Integer = 0 To letterList.Count - 1
            If Not letterSortedList.ContainsKey(letterList(i)) Then
                letterSortedList.Add(letterList(i), 1)
            Else
                letterSortedList(letterList(i)) += 1
            End If
        Next
        If letterSortedList.Count > 0 And revealed = False Then
            For Each item As KeyValuePair(Of String, Integer) In letterSortedList
                If item.Value = 1 Then
                    If virtualHost = True Then
                        SAPI.Speak("There is one " & item.Key & ".", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                    End If
                    Return "There is one " & item.Key & "."
                ElseIf item.Value > 1 Then
                    If item.Key <> "U" Then
                        If virtualHost = True Then
                            SAPI.Speak("There are " & item.Value & " " & item.Key & "'s.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                        End If
                        Return "There are " & item.Value & " " & item.Key & "'s."
                    ElseIf item.Key = "U" Then
                        If virtualHost = True Then
                            SAPI.Speak("There are " & item.Value & " You's.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                        End If
                        Return "There are " & item.Value & " " & item.Key & "'s."
                    End If
                End If
            Next
        ElseIf revealed = True Then
            letterSortedList.Clear()
            letterList.Clear()
        Else
            If finalSpin = False Then
                My.Computer.Audio.Play(My.Resources.Buzzer, AudioPlayMode.Background)
            End If
            If currentLetter <> "U" Then
                If virtualHost = True Then
                    SAPI.Speak("There are no " & currentLetter & "'s.")
                End If
                Return "There are no " & currentLetter & "'s."
            ElseIf currentLetter = "U" Then
                If virtualHost = True Then
                    SAPI.Speak("There are no You's.")
                End If
                Return "There are no " & currentLetter & "'s."
            End If
        End If
        'If letterControlList.Count = 1 Then
        '    If virtualHost = True Then
        '        SAPI.Speak("There is one " & currentLetter & ".", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
        '    End If
        '    Return "There is one " & currentLetter & "."
        'ElseIf letterControlList.Count > 1 Then
        '    If currentLetter <> "U" Then
        '        If virtualHost = True Then
        '            SAPI.Speak("There are " & letterControlList.Count & " " & currentLetter & "'s.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
        '        End If
        '        Return "There are " & letterControlList.Count & " " & currentLetter & "'s."
        '    ElseIf currentLetter = "U" Then
        '        If virtualHost = True Then
        '            SAPI.Speak("There are " & letterControlList.Count & " You's.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
        '        End If
        '        Return "There are " & letterControlList.Count & " " & currentLetter & "'s."
        '    End If
        'Else
        '    If finalSpin = False Then
        '        My.Computer.Audio.Play(My.Resources.Buzzer, AudioPlayMode.Background)
        '    End If
        '    If currentLetter <> "U" Then
        '        If virtualHost = True Then
        '            SAPI.Speak("There are no " & currentLetter & "'s.")
        '        End If
        '        Return "There are no " & currentLetter & "'s."
        '    ElseIf currentLetter = "U" Then
        '        If virtualHost = True Then
        '            SAPI.Speak("There are no You's.")
        '        End If
        '        Return "There are no " & currentLetter & "'s."
        '    End If
        'End If
        '    Next
        'Next
        'Next
    End Function
#End Region
#Region "Load Wedges onto the Wheel"
    Public Shared Sub wheelLoad(round As PuzzleType)
        Dim bonusWheel As New List(Of String) From {"35000", "35000", "Car", "35000", "35000", "45000", "35000", "Car", "35000", "35000", "Car", "35000", "35000", "40000", "35000", "Car", "35000", "35000", "35000", "100000", "35000", "Car", "50000", "Car"}
        halfCar1Status = False
        halfCar2Status = False
        If round = PuzzleType.R1 Then
            wheelWedges.Clear()
            wheelWedges.Add(0, "2500")
            wheelWedges.Add(1, "Bankrupt")
            wheelWedges.Add(2, "Bankrupt")
            wheelWedges.Add(3, "Bankrupt")
            wheelWedges.Add(4, "900")
            wheelWedges.Add(5, "900")
            wheelWedges.Add(6, "900")
            wheelWedges.Add(7, "500")
            wheelWedges.Add(8, "500")
            wheelWedges.Add(9, "500")
            wheelWedges.Add(10, "650")
            wheelWedges.Add(11, "650")
            wheelWedges.Add(12, "650")
            wheelWedges.Add(13, "Prize")
            wheelWedges.Add(14, "Prize")
            wheelWedges.Add(15, "Prize")
            wheelWedges.Add(16, "800")
            wheelWedges.Add(17, "800")
            wheelWedges.Add(18, "800")
            wheelWedges.Add(19, "Lose a Turn")
            wheelWedges.Add(20, "Lose a Turn")
            wheelWedges.Add(21, "Lose a Turn")
            wheelWedges.Add(22, "700")
            wheelWedges.Add(23, "700")
            wheelWedges.Add(24, "700")
            wheelWedges.Add(25, "Free Play")
            wheelWedges.Add(26, "Free Play")
            wheelWedges.Add(27, "Free Play")
            wheelWedges.Add(28, "650")
            wheelWedges.Add(29, "650")
            wheelWedges.Add(30, "650")
            wheelWedges.Add(31, "Bankrupt")
            wheelWedges.Add(32, "Bankrupt")
            wheelWedges.Add(33, "Bankrupt")
            wheelWedges.Add(34, "900")
            wheelWedges.Add(35, "900")
            wheelWedges.Add(36, "900")
            wheelWedges.Add(37, "500")
            wheelWedges.Add(38, "500")
            wheelWedges.Add(39, "500")
            wheelWedges.Add(40, "550")
            wheelWedges.Add(41, "550")
            wheelWedges.Add(42, "550")
            wheelWedges.Add(43, "600")
            wheelWedges.Add(44, "600")
            wheelWedges.Add(45, "600")
            wheelWedges.Add(46, "Bankrupt")
            wheelWedges.Add(47, "Million")
            wheelWedges.Add(48, "Bankrupt")
            wheelWedges.Add(49, "700")
            wheelWedges.Add(50, "700")
            wheelWedges.Add(51, "700")
            wheelWedges.Add(52, "Gift")
            wheelWedges.Add(53, "Gift")
            wheelWedges.Add(54, "Gift")
            wheelWedges.Add(55, "800")
            wheelWedges.Add(56, "800")
            wheelWedges.Add(57, "800")
            wheelWedges.Add(58, "600")
            wheelWedges.Add(59, "600")
            wheelWedges.Add(60, "600")
            wheelWedges.Add(61, "700")
            wheelWedges.Add(62, "700")
            wheelWedges.Add(63, "700")
            wheelWedges.Add(64, "900")
            wheelWedges.Add(65, "900")
            wheelWedges.Add(66, "900")
            wheelWedges.Add(67, "Wild")
            wheelWedges.Add(68, "Wild")
            wheelWedges.Add(69, "Wild")
            wheelWedges.Add(70, "2500")
            wheelWedges.Add(71, "2500")
        ElseIf round = PuzzleType.R2 Then
#Region "Load Mystery Wedges"
            Dim RandGen As New Random
            Dim RandBool As Boolean
            RandBool = RandGen.Next(0, 2).ToString
            If RandBool = True Then
                mystery2value = True
            ElseIf RandBool = False Then
                mystery2value = False
            End If
#End Region
            wheelWedges.Clear()
            wheelWedges.Add(0, "3500")
            wheelWedges.Add(1, "Bankrupt")
            wheelWedges.Add(2, "Bankrupt")
            wheelWedges.Add(3, "Bankrupt")
            wheelWedges.Add(4, "900")
            wheelWedges.Add(5, "900")
            wheelWedges.Add(6, "900")
            If carAwarded = True Then
                wheelWedges.Add(7, "500")
                wheelWedges.Add(8, "500")
                wheelWedges.Add(9, "500")
            Else
                wheelWedges.Add(7, "1/2 Car")
                wheelWedges.Add(8, "1/2 Car")
                wheelWedges.Add(9, "1/2 Car")
            End If
            wheelWedges.Add(10, "650")
            wheelWedges.Add(11, "650")
            wheelWedges.Add(12, "650")
            If prizeStatus = False Then
                wheelWedges.Add(13, "Prize")
                wheelWedges.Add(14, "Prize")
                wheelWedges.Add(15, "Prize")
            Else
                wheelWedges.Add(13, "500")
                wheelWedges.Add(14, "500")
                wheelWedges.Add(15, "500")
            End If
            wheelWedges.Add(16, "800")
            wheelWedges.Add(17, "800")
            wheelWedges.Add(18, "800")
            wheelWedges.Add(19, "Lose a Turn")
            wheelWedges.Add(20, "Lose a Turn")
            wheelWedges.Add(21, "Lose a Turn")
            wheelWedges.Add(22, "Mystery 2")
            wheelWedges.Add(23, "Mystery 2")
            wheelWedges.Add(24, "Mystery 2")
            wheelWedges.Add(25, "Free Play")
            wheelWedges.Add(26, "Free Play")
            wheelWedges.Add(27, "Free Play")
            wheelWedges.Add(28, "650")
            wheelWedges.Add(29, "650")
            wheelWedges.Add(30, "650")
            wheelWedges.Add(31, "Bankrupt")
            wheelWedges.Add(32, "Bankrupt")
            wheelWedges.Add(33, "Bankrupt")
            wheelWedges.Add(34, "900")
            wheelWedges.Add(35, "900")
            wheelWedges.Add(36, "900")
            If carAwarded = False Then
                wheelWedges.Add(37, "1/2 Car")
                wheelWedges.Add(38, "1/2 Car")
                wheelWedges.Add(39, "1/2 Car")
            Else
                wheelWedges.Add(37, "500")
                wheelWedges.Add(38, "500")
                wheelWedges.Add(39, "500")
            End If
            wheelWedges.Add(40, "550")
            wheelWedges.Add(41, "550")
            wheelWedges.Add(42, "550")
            wheelWedges.Add(43, "600")
            wheelWedges.Add(44, "600")
            wheelWedges.Add(45, "600")
            If millionStatus = False Then
                wheelWedges.Add(46, "Bankrupt")
                wheelWedges.Add(47, "Million")
                wheelWedges.Add(48, "Bankrupt")
            Else
                wheelWedges.Add(46, "500")
                wheelWedges.Add(47, "500")
                wheelWedges.Add(48, "500")
            End If
            wheelWedges.Add(49, "700")
            wheelWedges.Add(50, "700")
            wheelWedges.Add(51, "700")
            If giftStatus = False Then
                wheelWedges.Add(52, "Gift")
                wheelWedges.Add(53, "Gift")
                wheelWedges.Add(54, "Gift")
            Else
                wheelWedges.Add(52, "500")
                wheelWedges.Add(53, "500")
                wheelWedges.Add(54, "500")
            End If
            wheelWedges.Add(55, "800")
            wheelWedges.Add(56, "800")
            wheelWedges.Add(57, "800")
            wheelWedges.Add(58, "Mystery 1")
            wheelWedges.Add(59, "Mystery 1")
            wheelWedges.Add(60, "Mystery 1")
            wheelWedges.Add(61, "700")
            wheelWedges.Add(62, "700")
            wheelWedges.Add(63, "700")
            wheelWedges.Add(64, "900")
            wheelWedges.Add(65, "900")
            wheelWedges.Add(66, "900")
            If wildCardStatus = False Then
                wheelWedges.Add(67, "Wild")
                wheelWedges.Add(68, "Wild")
                wheelWedges.Add(69, "Wild")
            Else
                wheelWedges.Add(67, "500")
                wheelWedges.Add(68, "500")
                wheelWedges.Add(69, "500")
            End If
            wheelWedges.Add(70, "3500")
            wheelWedges.Add(71, "3500")
        ElseIf round = PuzzleType.R3 Then
            wheelWedges.Clear()
            wheelWedges.Add(0, "3500")
            wheelWedges.Add(1, "Bankrupt")
            wheelWedges.Add(2, "Bankrupt")
            wheelWedges.Add(3, "Bankrupt")
            wheelWedges.Add(4, "900")
            wheelWedges.Add(5, "900")
            wheelWedges.Add(6, "900")
            If carAwarded = True Then
                wheelWedges.Add(7, "500")
                wheelWedges.Add(8, "500")
                wheelWedges.Add(9, "500")
            Else
                wheelWedges.Add(7, "1/2 Car")
                wheelWedges.Add(8, "1/2 Car")
                wheelWedges.Add(9, "1/2 Car")
            End If
            wheelWedges.Add(10, "650")
            wheelWedges.Add(11, "650")
            wheelWedges.Add(12, "650")
            wheelWedges.Add(13, "500")
            wheelWedges.Add(14, "500")
            wheelWedges.Add(15, "500")
            wheelWedges.Add(16, "800")
            wheelWedges.Add(17, "800")
            wheelWedges.Add(18, "800")
            wheelWedges.Add(19, "Lose a Turn")
            wheelWedges.Add(20, "Lose a Turn")
            wheelWedges.Add(21, "Lose a Turn")
            wheelWedges.Add(22, "700")
            wheelWedges.Add(23, "700")
            wheelWedges.Add(24, "700")
            wheelWedges.Add(25, "Free Play")
            wheelWedges.Add(26, "Free Play")
            wheelWedges.Add(27, "Free Play")
            wheelWedges.Add(28, "650")
            wheelWedges.Add(29, "650")
            wheelWedges.Add(30, "650")
            wheelWedges.Add(31, "Bankrupt")
            wheelWedges.Add(32, "Bankrupt")
            wheelWedges.Add(33, "Bankrupt")
            wheelWedges.Add(34, "900")
            wheelWedges.Add(35, "900")
            wheelWedges.Add(36, "900")
            If carAwarded = False Then
                wheelWedges.Add(37, "1/2 Car")
                wheelWedges.Add(38, "1/2 Car")
                wheelWedges.Add(39, "1/2 Car")
            Else
                wheelWedges.Add(37, "500")
                wheelWedges.Add(38, "500")
                wheelWedges.Add(39, "500")
            End If
            wheelWedges.Add(40, "550")
            wheelWedges.Add(41, "550")
            wheelWedges.Add(42, "550")
            wheelWedges.Add(43, "600")
            wheelWedges.Add(44, "600")
            wheelWedges.Add(45, "600")
            If millionStatus = False Then
                wheelWedges.Add(46, "Bankrupt")
                wheelWedges.Add(47, "Million")
                wheelWedges.Add(48, "Bankrupt")
            Else
                wheelWedges.Add(46, "500")
                wheelWedges.Add(47, "500")
                wheelWedges.Add(48, "500")
            End If
            wheelWedges.Add(49, "700")
            wheelWedges.Add(50, "700")
            wheelWedges.Add(51, "700")
            If giftStatus = False Then
                wheelWedges.Add(52, "Gift")
                wheelWedges.Add(53, "Gift")
                wheelWedges.Add(54, "Gift")
            Else
                wheelWedges.Add(52, "500")
                wheelWedges.Add(53, "500")
                wheelWedges.Add(54, "500")
            End If
            wheelWedges.Add(55, "800")
            wheelWedges.Add(56, "800")
            wheelWedges.Add(57, "800")
            wheelWedges.Add(58, "600")
            wheelWedges.Add(59, "600")
            wheelWedges.Add(60, "600")
            wheelWedges.Add(61, "Express")
            wheelWedges.Add(62, "Express")
            wheelWedges.Add(63, "Express")
            wheelWedges.Add(64, "900")
            wheelWedges.Add(65, "900")
            wheelWedges.Add(66, "900")
            If wildCardStatus = False Then
                wheelWedges.Add(67, "Wild")
                wheelWedges.Add(68, "Wild")
                wheelWedges.Add(69, "Wild")
            Else
                wheelWedges.Add(67, "500")
                wheelWedges.Add(68, "500")
                wheelWedges.Add(69, "500")
            End If
            wheelWedges.Add(70, "3500")
            wheelWedges.Add(71, "3500")
        ElseIf round = PuzzleType.BR Then
            wheelWedges.Clear()
            Dim wedgeRandom As New Random
            Dim bonusWheelCount = bonusWheel.Count
            'Dim currentWedge = wedgeRandom.Next(bonusWheelCount)
            For i As Integer = 0 To 47 Step 2
                Dim currentWedge = GetRandomBonusWheel(0, bonusWheel.IndexOf(bonusWheel.Last))
                If currentWedge = "100000" Then
                    If player1.getWedges(Player.Wedges.Million) Or player2.getWedges(Player.Wedges.Million) Or player3.getWedges(Player.Wedges.Million) Then
                        wheelWedges.Add(i, "1000000")
                        wheelWedges.Add(i + 1, "1000000")
                    Else
                        wheelWedges.Add(i, "100000")
                        wheelWedges.Add(i + 1, "100000")
                    End If
                Else
                    wheelWedges.Add(i, bonusWheel(currentWedge))
                    wheelWedges.Add(i + 1, bonusWheel(currentWedge))
                End If
                bonusWheel.RemoveAt(currentWedge)
            Next
            '            wheelWedges.Add(1, "35000")
            '            wheelWedges.Add(2, "35000")
            '            wheelWedges.Add(3, "35000")
            '            wheelWedges.Add(4, "35000")
            '            wheelWedges.Add(5, "35000")
            '            wheelWedges.Add(6, "35000")
            '            wheelWedges.Add(7, "Car")
            '            wheelWedges.Add(8, "Car")
            '            wheelWedges.Add(9, "50000")
            '            wheelWedges.Add(10, "50000")
            '            wheelWedges.Add(11, "35000")
            '            wheelWedges.Add(12, "35000")
            '            wheelWedges.Add(13, "Car")
            '            wheelWedges.Add(14, "Car")
            '            wheelWedges.Add(15, "35000")
            '            wheelWedges.Add(16, "35000")
            '            wheelWedges.Add(17, "45000")
            '            wheelWedges.Add(18, "45000")
            '            wheelWedges.Add(19, "35000")
            '            wheelWedges.Add(20, "35000")
            '            wheelWedges.Add(21, "40000")
            '            wheelWedges.Add(22, "40000")
            '            wheelWedges.Add(23, "35000")
            '            wheelWedges.Add(24, "35000")
            '            wheelWedges.Add(25, "35000")
            '            wheelWedges.Add(26, "35000")
            '            wheelWedges.Add(27, "35000")
            '            wheelWedges.Add(28, "35000")
            '            wheelWedges.Add(29, "Car")
            '            wheelWedges.Add(29, "Car")
            '            wheelWedges.Add(30, "40000")
            '            wheelWedges.Add(31, "40000")
            '            wheelWedges.Add(32, "35000")
            '            wheelWedges.Add(33, "35000")
            '            wheelWedges.Add(34, "35000")
            '            wheelWedges.Add(35, "35000")
            '#Region "Load Million on Bonus Wheel"
            '            If frmScore.player1.getWedges(Player.Wedges.Million) Or frmScore.player2.getWedges(Player.Wedges.Million) Or frmScore.player3.getWedges(Player.Wedges.Million) Then
            '                wheelWedges.Add(36, "1000000")
            '                wheelWedges.Add(37, "1000000")
            '            Else
            '                wheelWedges.Add(36, "100000")
            '                    wheelWedges.Add(37, "100000")
            '                End If
            '#End Region
            '                wheelWedges.Add(38, "35000")
            '                wheelWedges.Add(39, "35000")
            '                wheelWedges.Add(40, "50000")
            '                wheelWedges.Add(41, "50000")
            '                wheelWedges.Add(42, "35000")
            '                wheelWedges.Add(43, "35000")
            '                wheelWedges.Add(44, "35000")
            '                wheelWedges.Add(45, "35000")
            '                wheelWedges.Add(46, "35000")
            '                wheelWedges.Add(47, "35000")
        Else
            wheelWedges.Clear()
            wheelWedges.Add(0, "5000")
            wheelWedges.Add(1, "Bankrupt")
            wheelWedges.Add(2, "Bankrupt")
            wheelWedges.Add(3, "Bankrupt")
            wheelWedges.Add(4, "900")
            wheelWedges.Add(5, "900")
            wheelWedges.Add(6, "900")
            wheelWedges.Add(7, "500")
            wheelWedges.Add(8, "500")
            wheelWedges.Add(9, "500")
            wheelWedges.Add(10, "650")
            wheelWedges.Add(11, "650")
            wheelWedges.Add(12, "650")
            wheelWedges.Add(13, "500")
            wheelWedges.Add(14, "500")
            wheelWedges.Add(15, "500")
            wheelWedges.Add(16, "800")
            wheelWedges.Add(17, "800")
            wheelWedges.Add(18, "800")
            wheelWedges.Add(19, "Lose a Turn")
            wheelWedges.Add(20, "Lose a Turn")
            wheelWedges.Add(21, "Lose a Turn")
            wheelWedges.Add(22, "700")
            wheelWedges.Add(23, "700")
            wheelWedges.Add(24, "700")
            wheelWedges.Add(25, "Free Play")
            wheelWedges.Add(26, "Free Play")
            wheelWedges.Add(27, "Free Play")
            wheelWedges.Add(28, "650")
            wheelWedges.Add(29, "650")
            wheelWedges.Add(30, "650")
            wheelWedges.Add(31, "Bankrupt")
            wheelWedges.Add(32, "Bankrupt")
            wheelWedges.Add(33, "Bankrupt")
            wheelWedges.Add(34, "900")
            wheelWedges.Add(35, "900")
            wheelWedges.Add(36, "900")
            wheelWedges.Add(37, "500")
            wheelWedges.Add(38, "500")
            wheelWedges.Add(39, "500")
            wheelWedges.Add(40, "550")
            wheelWedges.Add(41, "550")
            wheelWedges.Add(42, "550")
            wheelWedges.Add(43, "600")
            wheelWedges.Add(44, "600")
            wheelWedges.Add(45, "600")
            wheelWedges.Add(46, "500")
            wheelWedges.Add(47, "500")
            wheelWedges.Add(48, "500")
            wheelWedges.Add(49, "700")
            wheelWedges.Add(50, "700")
            wheelWedges.Add(51, "700")
            wheelWedges.Add(52, "500")
            wheelWedges.Add(53, "500")
            wheelWedges.Add(54, "500")
            wheelWedges.Add(55, "800")
            wheelWedges.Add(56, "800")
            wheelWedges.Add(57, "800")
            wheelWedges.Add(58, "600")
            wheelWedges.Add(59, "600")
            wheelWedges.Add(60, "600")
            wheelWedges.Add(61, "700")
            wheelWedges.Add(62, "700")
            wheelWedges.Add(63, "700")
            wheelWedges.Add(64, "900")
            wheelWedges.Add(65, "900")
            wheelWedges.Add(66, "900")
            wheelWedges.Add(67, "500")
            wheelWedges.Add(68, "500")
            wheelWedges.Add(69, "500")
            wheelWedges.Add(70, "5000")
            wheelWedges.Add(71, "5000")
        End If
    End Sub
#End Region
#Region "Validate Crossword Puzzle"
    Public Shared Function validateCrossword(puzzle As String) As Boolean
        Dim TheseAreYourWords As String()
        Dim myWords As New List(Of String)
        TheseAreYourWords = puzzle.Split(" ")
        For Each item As String In TheseAreYourWords
            If Not item = TheseAreYourWords.Last Then
                myWords.Add(item & " ")
            Else
                myWords.Add(item)
            End If
        Next
        Try
            For Each word As String In myWords
                'word.Replace(" ", "")
                Dim puzzleBoardLetterInteger As Integer
                Dim myChars() As Char = word.ToCharArray()
                puzzleBoardLetterInteger = Nothing
                For Each ch As Char In myChars
                    If Char.IsDigit(ch) Then
                        puzzleBoardLetterInteger &= ch
                    End If
                Next
                If puzzleBoardLetterInteger > 52 Then
                    Return False
                    Exit Function
                End If
                'For myLetter = 0 To word.Length - 1
                '    Dim letter
                '    If word.Chars(myLetter).ToString() <> " " And Not Char.IsDigit(word.Chars(myLetter)) Then
                '        letter = word.Chars(myLetter).ToString().Replace(puzzleBoardLetterInteger, "")
                '        CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & puzzleBoardLetterInteger), PuzzleBoardLetter).letterBehind = letter
                '        CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & puzzleBoardLetterInteger), PuzzleBoardLetter).Show()
                '        CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & puzzleBoardLetterInteger), PuzzleBoardLetter).btnLetter.BackgroundImage = My.Resources.PremiereLetterRevealTurn
                '        puzzleBoardLetterInteger = Nothing
                '    End If
                'Next
            Next
        Catch ex As Exception
            Return False
            Exit Function
        End Try
        Return True
    End Function
#End Region
End Class
