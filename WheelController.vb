﻿#Region "Imports"
Imports System.Data.SqlClient
#End Region
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
    Public Shared numberOfPlayers As Integer = 0
    Public Shared numberOfPlayersTotal As Integer = 0
    Public Shared teamDisplayInt As Integer = 0
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
    'Public Shared player1 As New Player
    'Public Shared player2 As New Player
    'Public Shared player3 As New Player
    Public Shared Player1List As New List(Of Player)
    Public Shared Player2List As New List(Of Player)
    Public Shared Player3List As New List(Of Player)
    Public Shared bonusRoundPlayer As List(Of Player)
    'Public Shared bonusRoundPlayer As Player
    Public Shared puzzleString As String
    Public Shared noMoreVowelsShown As Boolean = False
    Public Shared noMoreConsonantsShown As Boolean = False
    Public Shared prizePuzzleStatus As Boolean = False
    'Public Shared player1Score As Integer
    'Public Shared player2Score As Integer
    'Public Shared player3Score As Integer
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
    Public Shared currentPlayerObject As List(Of Player)
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
    Public Shared dailyPuzzleList As New List(Of List(Of String))
    Private Shared roundString = ""
    Public Shared highestRoundString = ""
    Public Shared finalSpinTimesUp = False
    Public Shared season As Integer = 36
    Public Shared mystery1Status As Boolean = False
    Public Shared mystery2Status As Boolean = False
    Public Shared puzzleID As Integer
    Private Shared loadGameLetterRevealList As New List(Of String)
    Public Shared quickGame As Boolean = True
    Public Shared loadGame As Boolean = False
    Public Shared currentLoadGame As Boolean = False
    Private Shared tossUpSolved = False
    Public Shared checkVowelRunning = False
#End Region
#Region "Enum Types"
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
        Daily
        Compendium
    End Enum
#End Region
#Region "Reset Players"
    Public Shared Sub resetPlayers()
        frmScore.lblPlayer1.Text = ""
        frmScore.lblPlayer2.Text = ""
        frmScore.lblPlayer3.Text = ""
        For Each myPlayer As Player In Player1List
            myPlayer.total = 0
        Next
        For Each myPlayer As Player In Player2List
            myPlayer.total = 0
        Next
        For Each myPlayer As Player In Player3List
            myPlayer.total = 0
        Next
    End Sub
#End Region
#Region "Team Play Methods"
    Public Shared Sub clearTeams()
        Player1List.Clear()
        Player2List.Clear()
        Player3List.Clear()
    End Sub
    Public Shared Function checkID(ID As Integer) As Boolean
        For Each player As Player In Player1List
            If player.contestantID = ID Then
                Return True
            End If
        Next
        For Each player As Player In Player2List
            If player.contestantID = ID Then
                Return True
            End If
        Next
        For Each player As Player In Player3List
            If player.contestantID = ID Then
                Return True
            End If
        Next
        Return False
    End Function
    Public Shared Sub removeByID(ID As Integer)
        For Each player As Player In Player1List
            If player.contestantID = ID Then
                Player1List.Remove(player)
                Exit For
            End If
        Next
        For Each player As Player In Player2List
            If player.contestantID = ID Then
                Player2List.Remove(player)
                Exit For
            End If
        Next
        For Each player As Player In Player3List
            If player.contestantID = ID Then
                Player3List.Remove(player)
                Exit For
            End If
        Next
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
        If round = PuzzleType.TU1 Or round = PuzzleType.TU2 Or round = PuzzleType.R1 Then
            If millionStatus = True Then
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelZoomR1.mp4"
            Else
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelZoomR1Million.mp4"
            End If
            frmPuzzleBoard.wheelTilt.Image = My.Resources.WheelTiltedSmallR1Million
            frmPuzzleBoard.WheelSpinControl1.resetWheel()
            frmPuzzleBoard.WheelSpinControl1.firstSpin = True
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.pause()
        ElseIf round = PuzzleType.R2 Then
            If millionStatus = True Then
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelZoomR2Mystery1Mystery2.mp4"
                frmPuzzleBoard.wheelTilt.Image = My.Resources.WheelTiltedSmallR2Mystery1Mystery2
            Else
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelZoomR2Mystery1Mystery2Million.mp4"
                frmPuzzleBoard.wheelTilt.Image = My.Resources.WheelTiltedSmallR2Mystery1Mystery2Million
            End If
            frmPuzzleBoard.WheelSpinControl1.resetWheel()
            frmPuzzleBoard.WheelSpinControl1.firstSpin = True
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.pause()
        ElseIf round = PuzzleType.R3 Then
            If millionStatus = True Then
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelZoomR3.mp4"
                frmPuzzleBoard.wheelTilt.Image = My.Resources.WheelTiltedSmallR3
            Else
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelZoomR3Million.mp4"
                frmPuzzleBoard.wheelTilt.Image = My.Resources.WheelTiltedSmallR3Million
            End If
            frmPuzzleBoard.WheelSpinControl1.resetWheel()
            frmPuzzleBoard.WheelSpinControl1.firstSpin = True
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.pause()
        ElseIf round = PuzzleType.TU3 Then
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelZoomR4.mp4"
            frmPuzzleBoard.wheelTilt.Image = My.Resources.WheelTiltedSmallR4
            frmPuzzleBoard.WheelSpinControl1.resetWheel()
            frmPuzzleBoard.WheelSpinControl1.firstSpin = True
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.pause()
        ElseIf round = PuzzleType.R4 Then
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelZoomR4.mp4"
            frmPuzzleBoard.wheelTilt.Image = My.Resources.WheelTiltedSmallR4
            frmPuzzleBoard.WheelSpinControl1.resetWheel()
            frmPuzzleBoard.WheelSpinControl1.firstSpin = True
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.pause()
        ElseIf round = PuzzleType.R5 Or round = PuzzleType.R6 Or round = PuzzleType.R7 Or round = PuzzleType.R8 Or round = PuzzleType.R9 Or round = puzzleType.TBTU Then
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelZoomR4.mp4"
            frmPuzzleBoard.wheelTilt.Image = My.Resources.WheelTiltedSmallR4
            frmPuzzleBoard.WheelSpinControl1.firstSpin = True
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.pause()
        ElseIf round = PuzzleType.BR Then
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources\WheelSpinBonus.mp4"
            frmPuzzleBoard.wheelTilt.Image = My.Resources.WheelTiltedSmallBonusCards
            frmPuzzleBoard.WheelSpinControl1.wheelCover.BackgroundImage = My.Resources.BonusWheel
            frmPuzzleBoard.WheelSpinControl1.resetWheel()
            frmPuzzleBoard.WheelSpinControl1.firstSpin = True
            frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.pause()
        End If

    End Sub
    Public Shared Sub loadMysteryWheel()
        If round = PuzzleType.R2 Then
            If mystery1Status = True Then
                If millionStatus = True Then
                    frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelZoomR2Mystery2.mp4"
                    frmPuzzleBoard.wheelTilt.Image = My.Resources.WheelTiltedSmallR2Mystery2
                Else
                    frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelZoomR2Mystery2Million.mp4"
                    frmPuzzleBoard.wheelTilt.Image = My.Resources.WheelTiltedSmallR2Mystery2Million
                End If
            End If
            If mystery2Status = True Then
                If millionStatus = True Then
                    frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelZoomR2Mystery1.mp4"
                    frmPuzzleBoard.wheelTilt.Image = My.Resources.WheelTiltedSmallR2Mystery1
                Else
                    frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelZoomR2Mystery1Million.mp4"
                    frmPuzzleBoard.wheelTilt.Image = My.Resources.WheelTiltedSmallR2Mystery1Million
                End If
            End If
        End If
    End Sub
    Public Shared Sub loadMillionWheel()
        If round = PuzzleType.TU1 Or round = PuzzleType.TU2 Or round = PuzzleType.R1 Then
            If millionStatus = True Then
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelZoomR1.mp4"
                frmPuzzleBoard.wheelTilt.Image = My.Resources.WheelTiltedSmallR1
            Else
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelZoomR1Million.mp4"
                frmPuzzleBoard.wheelTilt.Image = My.Resources.WheelTiltedSmallR1Million
            End If
        ElseIf round = PuzzleType.R2 Then
            loadMysteryWheel()
        ElseIf round = PuzzleType.R3 Then
            If millionStatus = True Then
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelZoomR3.mp4"
                frmPuzzleBoard.wheelTilt.Image = My.Resources.WheelTiltedSmallR3
            Else
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelZoomR3Million.mp4"
                frmPuzzleBoard.wheelTilt.Image = My.Resources.WheelTiltedSmallR3Million
            End If
        End If
    End Sub
#End Region
#Region "Check Vowels"
    Public Shared Sub checkVowels()
        checkVowelRunning = True
        'If round <> PuzzleType.TU1 And round <> PuzzleType.TU2 And round <> PuzzleType.TU3 And round <> PuzzleType.TBTU And round <> PuzzleType.BR Then
        If letterControlList.Count = 0 Then
            If Not puzzleString.Contains("A") And Not puzzleString.Contains("E") And Not puzzleString.Contains("I") And Not puzzleString.Contains("O") And Not puzzleString.Contains("U") Then
                If noMoreVowelsShown = False Then
                    frmPuzzleBoard.noMoreVowels.Show()
                    My.Computer.Audio.Play(My.Resources.snd_no_more_vowels, AudioPlayMode.Background)
                    noMoreVowelsShown = True
                    enableVowels(False)
                    frmScore.tmrCheckVowels.Stop()
                    checkVowelRunning = False
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
                    checkVowelRunning = False
                    frmPuzzleBoard.btnWild.Enabled = False
                    If virtualHost = True Then
                        SAPI.Speak("The rest of the letters are vowels.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                    End If
                Else
                End If
            End If
        End If
        'End If
    End Sub
#End Region
#Region "Load Bonus Categories"
    Public Shared Sub loadBonusCategories(mode As wheelMode)
        If mode <> wheelMode.Daily And mode <> wheelMode.Compendium Then
            Dim connPuzzle As SqlConnection
            connPuzzle = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" & Application.StartupPath & "\WheelPuzzles.mdf;Integrated Security=True")
            Dim strSQL
            roundType = round
            round = PuzzleType.BR
            If mode = wheelMode.Classic Then
                strSQL = "Select * From Puzzle WHERE Type = 2 and RoundNumber = 1 and PackName =  @PackName"
            ElseIf mode = wheelMode.Disney Then
                strSQL = "Select * From Puzzle WHERE LEN(puzzle) <=28 and PackName =  @PackName"
            ElseIf mode = wheelMode.Random Then
                strSQL = "Select * From Puzzle WHERE Type = 2 and RoundNumber = 1"
            End If
            Dim drProduct As SqlDataReader
            Dim cmdProduct As SqlCommand
            Dim packNameParam As SqlParameter = New SqlParameter("@PackName", packName)
            connPuzzle.Open()
            cmdProduct = New SqlCommand(strSQL, connPuzzle)
            If mode = wheelMode.Classic Or mode = wheelMode.Disney Then
                cmdProduct.Parameters.Add(packNameParam)
            Else
            End If
            drProduct = cmdProduct.ExecuteReader(CommandBehavior.CloseConnection)
            While drProduct.Read()
                bonusCategoriesListPrelim.Add(Trim(drProduct("Category")))
                If mode = wheelMode.Disney Or mode = wheelMode.Random Then
                    Dim myPuzzle As New clsPuzzle
                    myPuzzle.category = Trim(drProduct("Category"))
                    myPuzzle.puzzle = Trim(drProduct("Puzzle"))
                    myPuzzle.puzzleTypeInt = CInt(Trim(drProduct("Type")))
                    myPuzzle.crosswordStatus = CInt(Trim(drProduct("Crossword")))
                    categoryListPrelim.Add(myPuzzle)
                End If
            End While
        End If
        If mode = wheelMode.Classic Then
            For Each item In bonusCategoriesListPrelim
                bonusCategoriesList.Add(item)
            Next
        ElseIf mode = wheelMode.Disney Or mode = wheelMode.Random Then
            Dim randomCatNumbers As New List(Of Integer)
            For randomCatList As Integer = 1 To bonusCategoriesListPrelim.Count
                randomCatNumbers.Add(randomCatList)
            Next
            'If mode = wheelMode.Disney Or mode = wheelMode.Random Then
            For i As Integer = 1 To 3
                Dim newPuzzle = (categoryListPrelim(getRandomIndex(randomCatNumbers)))
                Dim newPuzzleList = categoryList.Where(Function(p) p.category.Contains(newPuzzle.category))
                Do Until newPuzzleList.Count = 0
                    newPuzzle = (categoryListPrelim(getRandomIndex(randomCatNumbers)))
                Loop
                If newPuzzleList.Count = 0 Then
                    categoryList.Add(newPuzzle)
                End If
            Next
            Dim hello As String = ""
            'ElseIf mode = wheelMode.Random Then
            'For i As Integer = 1 To 3
            '    Dim newPuzzle = (categoryListPrelim(getRandomIndex(randomCatNumbers)))
            '    Dim newPuzzleList = categoryList.Where(Function(p) p.category.Contains(newPuzzle.category))
            '    Do Until newPuzzleList.Count = 0
            '        newPuzzle = (categoryListPrelim(getRandomIndex(randomCatNumbers)))
            '    Loop
            '    If newPuzzleList.Count = 0 Then
            '        categoryList.Add(newPuzzle)
            '    End If
            'bonusCategoriesList.Add(bonusCategoriesListPrelim(getRandomIndex(randomCatNumbers)))
            'Next
            'End If
        ElseIf mode = wheelMode.Daily Or mode = wheelMode.Compendium Then

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
        frmScore.tmrCheckVowels.Start()
        tossUpSolved = False
        'Try
        If currentLoadGame = False Then
            frmScore.lblPlayer1.Text = ""
            frmScore.lblPlayer2.Text = ""
            frmScore.lblPlayer3.Text = ""
            solveAttempt = ""
            solveSortedList.Clear()
        End If
        puzzleString = ""
        solveMode = False
        letterControlList.Clear()
        lastLetter = 0
        'solveSortedList.Clear()
        'solveTypedList.Clear()
        If (round = PuzzleType.TU1 Or round = PuzzleType.TU2 Or round = PuzzleType.TU3 Or round = PuzzleType.TBTU) And preview = False Then
            If virtualHost = True Then
                tossUpIntroComplete = False
            Else
                tossUpIntroComplete = True
            End If
            If Player1List.Count > 0 Then
                frmPuzzleBoard.btnRedRingIn.Show()
            Else
                frmPuzzleBoard.btnRedRingIn.Hide()
                player1RingIn = True
            End If
            If Player2List.Count > 0 Then
                frmPuzzleBoard.btnYellowRingIn.Show()
            Else
                frmPuzzleBoard.btnYellowRingIn.Hide()
                player2RingIn = True
            End If
            If Player3List.Count > 0 Then
                frmPuzzleBoard.btnBlueRingIn.Show()
            Else
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
                ElseIf round = PuzzleType.BR And mode <> wheelMode.Disney And mode <> wheelMode.Random Then
                    strSQL = "Select * From Puzzle WHERE Category =  @Category and Type = 2 and RoundNumber = 1 and PackName = @PackName"
                ElseIf round = PuzzleType.BR And mode = wheelMode.Disney Or round = PuzzleType.BR And mode = wheelMode.Random Then
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
                strSQL = "Select * From Puzzle WHERE Type = 1 and PackName = @packName"
                If round <> PuzzleType.BR Then
                    If categoryListPrelim.Count = 0 Then
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
                        While drProduct.Read()
                            Dim myPuzzle As New clsPuzzle
                            myPuzzle.ID = Trim(drProduct("Id"))
                            myPuzzle.category = Trim(drProduct("Category"))
                            myPuzzle.puzzle = Trim(drProduct("Puzzle"))
                            myPuzzle.puzzleTypeInt = CInt(Trim(drProduct("Type")))
                            myPuzzle.crosswordStatus = CInt(Trim(drProduct("Crossword")))
                            categoryListPrelim.Add(myPuzzle)
                        End While
                    End If
                    Dim myNewPuzzle = categoryListPrelim(GetRandomPlayer(1, categoryListPrelim.Count))
                    categoryListPrelim.Remove(myNewPuzzle)
                    puzzleID = myNewPuzzle.ID
                    category = myNewPuzzle.category
                    puzzle = myNewPuzzle.puzzle
                    puzzleTypeInt = myNewPuzzle.puzzleTypeInt
                    crosswordStatus = myNewPuzzle.crosswordStatus
                Else
                End If
            ElseIf mode = wheelMode.Random Then
                If round = PuzzleType.TU1 Or round = PuzzleType.TU2 Or round = PuzzleType.TU3 Or round = PuzzleType.TBTU Or round = PuzzleType.BR Or round = PuzzleType.R1 Or round = PuzzleType.R2 Then
                    strSQL = "Select * From Puzzle WHERE Type = 0 and PackName != 'Disney Wheel of Fortune' and PackName != 'Disney Wheel of Fortune 2' and Type = @type"
                Else
                    strSQL = "Select * From Puzzle WHERE Type = 0 and PackName != 'Disney Wheel of Fortune' and PackName != 'Disney Wheel of Fortune 2' and Type = @type and CrosswordStatus = 0"
                End If
                Dim roundTypeNumber As Integer
                If round = PuzzleType.TU1 Or round = PuzzleType.TU2 Or round = PuzzleType.TU3 Or round = PuzzleType.TBTU Then
                    roundTypeNumber = 0
                ElseIf (round <> PuzzleType.TU1 Or round <> PuzzleType.TU2 Or round <> PuzzleType.TU3 Or round <> PuzzleType.TBTU) And round <> PuzzleType.BR Then
                    roundTypeNumber = 1
                Else
                    roundTypeNumber = 2
                End If
                If round <> PuzzleType.BR Then
                    If categoryListPrelim.Count = 0 Then
                        Dim categoryParam As SqlParameter = New SqlParameter("@Category", category)
                        Dim roundParam As SqlParameter = New SqlParameter("@type", roundTypeNumber)
                        Dim drProduct As SqlDataReader
                        Dim cmdProduct As SqlCommand
                        connPuzzle.Open()
                        cmdProduct = New SqlCommand(strSQL, connPuzzle)
                        If round = PuzzleType.BR Then
                            cmdProduct.Parameters.Add(categoryParam)
                        End If
                        cmdProduct.Parameters.Add(roundParam)
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
            ElseIf mode = wheelMode.Daily Then
                For Each puzzleListItem As List(Of String) In dailyPuzzleList
                    If puzzleListItem(0) = roundString Then
                        If roundString = highestRoundString Then
                            finalSpinQueued = True
                        End If
                        category = puzzleListItem(1)
                        puzzle = puzzleListItem(2)
                        If System.Text.RegularExpressions.Regex.IsMatch(puzzleListItem(2), "\d+") Then
                            crosswordStatus = 1
                        Else
                            crosswordStatus = 0
                        End If
                        Exit For
                    End If
                Next
            ElseIf mode = wheelMode.Compendium Then
                For Each puzzleListItem As List(Of String) In dailyPuzzleList
                    If puzzleListItem(3) = roundString Then
                        If roundString = highestRoundString Then
                            finalSpinQueued = True
                        End If
                        category = puzzleListItem(1)
                        puzzle = puzzleListItem(0)
                        'If System.Text.RegularExpressions.Regex.IsMatch(puzzleListItem(2), "\d+") Then
                        '    crosswordStatus = 1
                        'Else
                        crosswordStatus = 0
                        'End If
                        Exit For
                    End If
                Next
            End If
        ElseIf preview = True Then
            If frmCustomizer.cboCategory.SelectedItem <> "CROSSWORD" Then
                If frmCustomizer.chk80sPuzzle.Checked = False Then
                    category = frmCustomizer.cboCategory.SelectedItem.ToString
                Else
                    category = "80's " & frmCustomizer.cboCategory.SelectedItem.ToString
                End If
            Else
                category = frmCustomizer.txtCrosswordClue.Text.ToUpper
            End If
            puzzle = frmCustomizer.txtPuzzle.Text.ToUpper
        End If
        Try
            TheseAreYourWords = puzzle.Split(" ")
        Catch ex As Exception
            MsgBox("Error occurred while loading the puzzle.", vbCritical, "Wheel of Fortune")
            Exit Sub
        End Try
        Dim maxLength As Integer = 0
        Dim index As Integer = 0
        Dim comboMaxLength As Integer = 0
        Dim longWordLength As Integer = 0
        For Each item As String In TheseAreYourWords
            'If Not item = TheseAreYourWords.Last Then
            If item.Length >= maxLength Then
                maxLength = item.Length
                longWordLength = item.Length
            Else
                If (index + 1) < TheseAreYourWords.Length And Not (TheseAreYourWords.Length Mod 2 = 0) And Not ((puzzle.Length + 1) Mod 2 = 0 And puzzle(((puzzle.Length + 1) / 2) - 1) = " ") Then
                    If TheseAreYourWords(index).Length + TheseAreYourWords(index + 1).Length <= maxLength Then
                        comboMaxLength += 1
                    End If
                End If
            End If
            If Not item = TheseAreYourWords.Last Then
                If TheseAreYourWords(Array.IndexOf(TheseAreYourWords, item) + 1) = "&" Then
                    myWords.Add(item & " & ")
                ElseIf Not TheseAreYourWords(Array.IndexOf(TheseAreYourWords, item) + 1) = "&" And Not item = "&" Then
                    myWords.Add(item & " ")
                End If
            Else
                myWords.Add(item & " ")
            End If
            index += 1
            'Else
            '    myWords.Add(item)
            'End If
        Next
        'GRILLED CORN ON THE COB
        Dim threeRowPuzzle As Boolean = False
        Dim midpoint = 0
        Dim evenWordLength1 = 0
        Dim evenWordLength2 = 0
        If myWords.Count Mod 2 = 0 Or (puzzle.Length) Mod 2 = 0 Or (puzzle.Length + 1) Mod 2 = 0 Or ((puzzle.Length + 1) Mod 2 = 0 And puzzle(((puzzle.Length + 1) / 2) - 1) = " ") Then
            If myWords.Count Mod 2 = 0 Or (puzzle.Length) Mod 2 = 0 Or ((puzzle.Length + 1) Mod 2 = 0 And Not puzzle(((puzzle.Length + 1) / 2) - 1) = " ") And Not ((puzzle.Length + 1) Mod 2 = 0 And puzzle(((puzzle.Length + 1) / 2) - 1) = " ") Then
                If (puzzle.Length) Mod 2 = 0 Or (puzzle.Length + 1) Mod 2 = 0 Or myWords.Count Mod 2 = 0 Then
                    midpoint = puzzle.Length / 2
                    If puzzle(midpoint - 1) = " " Or puzzle(midpoint) = " " Then
                        evenWordLength1 = midpoint
                    Else
                        For i As Integer = 0 To myWords.Count - 1
                            If evenWordLength1 < midpoint Then
                                If (evenWordLength1 + myWords(i).Length) <= midpoint + 4 And evenWordLength1 + myWords(i).Length <= 14 Then
                                    evenWordLength1 += myWords(i).Length
                                Else
                                    Exit For
                                End If
                            Else
                                Exit For
                            End If
                        Next
                    End If
                    evenWordLength2 = puzzle.Length - evenWordLength1
                    'ElseIf (puzzle.Length - 1) Mod 2 = 0 Then
                    '    midpoint = (puzzle.Length + 1) / 2
                    '    If puzzle(midpoint) = " " Then
                    '        evenWordLength1 = midpoint
                    '        evenWordLength2 = midpoint
                    '    End If
                Else
                    midpoint = Math.Floor(myWords.Count / 2)
                    For i As Integer = 0 To (midpoint) - 1
                        evenWordLength1 += myWords(i).Length
                    Next
                    For i As Integer = ((midpoint)) To myWords.Count - 1
                        If i <> myWords.Count - 1 Then
                            evenWordLength2 += myWords(i).Length
                        Else
                            evenWordLength2 += myWords(i).Length - 1
                        End If
                    Next

                End If
                If evenWordLength1 > 14 Or evenWordLength2 > 14 Then
                    threeRowPuzzle = True
                End If
            ElseIf (puzzle.Length + 1) Mod 2 = 0 And puzzle(((puzzle.Length + 1) / 2) - 1) = " " Then
                midpoint = (puzzle.Length + 1) / 2
                evenWordLength1 = midpoint
                evenWordLength2 = midpoint
            End If
            '8, 15
            If evenWordLength2 >= evenWordLength1 And (evenWordLength2 - evenWordLength1 <= 4 And evenWordLength2 - evenWordLength1 > 0) Then
                maxLength = evenWordLength2
            Else
                maxLength = evenWordLength1
            End If
        Else
            threeRowPuzzle = True
            'maxLength -= 4
        End If
        'If comboMaxLength = 0 Then
        'If myWords.Count Mod 2 = 0 Or (puzzle.Length) Mod 2 = 0 Or ((puzzle.Length + 1) Mod 2 = 0) Then
        If (13 - maxLength >= 4) And (maxLength < 13 And (evenWordLength2 - evenWordLength1 >= 4 Or evenWordLength1 - evenWordLength2 >= 4)) Then
            If 13 - maxLength >= 5 Then
                maxLength = 13
            Else
                maxLength += 4
            End If
        Else
        End If
        'Else
        '    maxLength += 4
        'End If
        'End If
        'If myWords.Count Mod 2 = 0 And maxLength Then
        '    maxLength = 0
        '    Dim halfLength = puzzle.Length / 2
        '    Dim midwayPoint = myWords.Count / 2
        '    'Dim wordSum As Integer = 0
        '    'Dim threeRowPuzzle As Boolean = False
        '    For i As Integer = 0 To midwayPoint - 1
        '        maxLength += myWords(i).Length
        '    Next
        '    'If wordSum > halfLength  And (puzzle.Length - wordSum) > halfLength  Then
        '    '    threeRowPuzzle = True
        '    'End If
        'End If
        If category = "SAME LETTER" Or (category = "BEFORE & AFTER" And myWords.Count <= 4 And checkTwoLetterWord(myWords) = False) Then
            If category = "SAME LETTER" Then
                sameLetter = puzzle.Substring(0, 1)
            End If
            'If puzzle.Contains("&") = False Then
            threeRowPuzzle = True
            'End If
        End If
        'VENUS & SERENA WILLIAMS
        'HUNCHBACK OF THE NOTRE DAME
        'FOR EACH WORD IN PUZZLE 
        'PUZZLE.LENGTH
        If String.IsNullOrEmpty(puzzleString) Then
            puzzleString = puzzle
        End If
        Dim numberOfLengths As Integer = 0
        Dim numberOfLengths2 As Integer = 0
        Dim numberOfLengths3 As Integer = 0
        Dim numberOfLengths4 As Integer = 0
        Dim row1 As Boolean = False
        Dim row2 As Boolean = False
        Dim row3 As Boolean = False
        Dim row4 As Boolean = False
        Dim firstInstanceTwoLetter As Boolean = True
        Dim wordCount = 0
        Dim wordLengths As New List(Of Integer)
        Dim lastWordMatch As Boolean = False
        If crosswordStatus = 0 Then
            If puzzle.Length <= 14 And myWords.Count >= 1 And threeRowPuzzle = False Then
                For Each word As String In myWords
                    If ((puzzle.Length + 1 - (numberOfLengths)) > (numberOfLengths)) And ((word.Replace(" ", "").Length <= 10 - numberOfLengths And row2 = False And ((myWords.Count - myWords.IndexOf(word) >= 2))) Or (myWords.Count = 1 And row2 = False)) Then
                        row1 = True
                        For myLetter = 0 To word.Length - 1
                            If word.Chars(myLetter).ToString() <> " " Then
                                letterControlSortedList2.Add(((numberOfLengths) + 13), word.Chars(myLetter).ToString())
                                numberOfLengths += 1
                            ElseIf word.Chars(myLetter).ToString() = " " Then
                                letterControlSortedList2.Add((((numberOfLengths) + 13)), word.Chars(myLetter).ToString())
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
                                numberOfLengths2 += 1
                            ElseIf word.Chars(myLetter).ToString() = " " Then
                                letterControlSortedList3.Add((27 + (numberOfLengths2)), word.Chars(myLetter).ToString())
                                numberOfLengths2 += 1
                            End If
                        Next
                    End If
                Next
            ElseIf puzzle.Length <= 28 And threeRowPuzzle = False Then
                For Each word As String In myWords
                    wordCount += 1
                    If ((word.Replace(" ", "").Length <= (maxLength) - numberOfLengths And row2 = False)) Then
                        row1 = True
                        For myLetter = 0 To word.Length - 1
                            If word.Chars(myLetter).ToString() <> " " Then
                                letterControlSortedList2.Add(((numberOfLengths) + 13), word.Chars(myLetter).ToString())
                                numberOfLengths += 1
                            ElseIf word.Chars(myLetter).ToString() = " " Then
                                letterControlSortedList2.Add(((numberOfLengths) + 13), word.Chars(myLetter).ToString())
                                numberOfLengths += 1
                            End If
                        Next
                    ElseIf ((puzzle.Length + 1 - (numberOfLengths)) = (numberOfLengths)) Or (word.Replace(" ", "").Length >= (maxLength) - numberOfLengths And row1 = True And row2 = False) Or (word.Replace(" ", "").Length <= (maxLength) - numberOfLengths And row1 = True And row2 = False) Or (word.Replace(" ", "").Length <= (maxLength) - numberOfLengths2 And row2 = True And row3 = False) Then
                        wordCount = 0
                        row2 = True
                        For myLetter = 0 To word.Length - 1
                            If word.Chars(myLetter).ToString() <> " " Then
                                letterControlSortedList3.Add((27 + (numberOfLengths2)), word.Chars(myLetter).ToString())
                                numberOfLengths2 += 1
                            ElseIf word.Chars(myLetter).ToString() = " " Then
                                letterControlSortedList3.Add((27 + (numberOfLengths2)), word.Chars(myLetter).ToString())
                                numberOfLengths2 += 1
                            End If
                        Next
                    ElseIf word.Replace(" ", "").Length > (maxLength) - numberOfLengths2 And row2 = True And row3 = False Or (word.Replace(" ", "").Length <= (maxLength) - numberOfLengths3 And row3 = True And row4 = False) Then
                        wordCount = 0
                        row3 = True
                        For myLetter = 0 To word.Length - 1
                            If word.Chars(myLetter).ToString() <> " " Then
                                letterControlSortedList4.Add((41 + (numberOfLengths3)), word.Chars(myLetter).ToString())
                                numberOfLengths3 += 1
                            ElseIf word.Chars(myLetter).ToString() = " " Then
                                letterControlSortedList4.Add((41 + (numberOfLengths3)), word.Chars(myLetter).ToString())
                                numberOfLengths3 += 1
                            End If
                        Next

                    End If
                Next
            ElseIf puzzle.Length > 28 Or threeRowPuzzle = True Then
                For Each word As String In myWords
                    Dim pastCount = 0
                    If (numberOfLengths > 0) Then
                        pastCount += numberOfLengths
                    End If
                    If (numberOfLengths2 > 0) Then
                        pastCount += numberOfLengths2
                    End If
                    If (numberOfLengths3 > 0) Then
                        pastCount += numberOfLengths3
                    End If
                    If (numberOfLengths4 > 0) Then
                        pastCount += numberOfLengths4
                    End If

                    If (category = "SAME LETTER" Or (category = "BEFORE & AFTER" And myWords.Count <= 4) And puzzle.Contains("&") = False) Then
                        maxLength = word.Length
                    Else
                        If (word.Length - 1 = longWordLength Or lastWordMatch = True) And Not maxLength = 13 And (pastCount > (puzzle.Length - (numberOfLengths + numberOfLengths2 + numberOfLengths3 + numberOfLengths4))) > 0 Then
                            maxLength = longWordLength
                            If word.Length - 1 = longWordLength Then
                                lastWordMatch = True
                            Else
                                lastWordMatch = False
                            End If
                        Else
                            If row2 = False Or row4 = True Then
                                maxLength = 12
                                lastWordMatch = False
                            Else
                                maxLength = 13
                                lastWordMatch = False
                            End If
                        End If
                    End If
                    If word.Replace(" ", "").Length <= 2 And firstInstanceTwoLetter = False And row2 = True Then
                        firstInstanceTwoLetter = True
                    ElseIf word.Replace(" ", "").Length <= 2 And firstInstanceTwoLetter = True And row2 = True Then
                        firstInstanceTwoLetter = False
                        If row1 = True And row2 = False And row3 = False And row4 = False Then
                            row2 = True
                        ElseIf row1 = True And row2 = True And row3 = False And row4 = False Then
                            row3 = True
                        ElseIf row1 = True And row2 = True And row3 = True And row4 = False Then
                            row4 = True
                        End If
                    End If
                    If (word.Replace(" ", "").Length <= (maxLength) - numberOfLengths And Not (word.Replace(" ", "").Length <= 2 And numberOfLengths <> 0 And category = "BEFORE & AFTER") And row2 = False) Then
                        row1 = True
                        For myLetter = 0 To word.Length - 1
                            If word.Chars(myLetter).ToString() <> " " Then
                                letterControlSortedList1.Add(((numberOfLengths)), word.Chars(myLetter).ToString())
                                numberOfLengths += 1
                            ElseIf word.Chars(myLetter).ToString() = " " Then
                                letterControlSortedList1.Add(((numberOfLengths)), word.Chars(myLetter).ToString())
                                numberOfLengths += 1
                            End If
                        Next
                    ElseIf (((word.Replace(" ", "").Length > (maxLength) - numberOfLengths Or (word.Replace(" ", "").Length <= 2 And firstInstanceTwoLetter = True And category = "BEFORE & AFTER")) And row1 = True And row2 = False) Or (word.Replace(" ", "").Length <= (maxLength) - numberOfLengths2 And row2 = True And row3 = False)) Then
                        row2 = True
                        For myLetter = 0 To word.Length - 1
                            If word.Chars(myLetter).ToString() <> " " Then
                                letterControlSortedList2.Add((13 + (numberOfLengths2)), word.Chars(myLetter).ToString())
                                numberOfLengths2 += 1
                            ElseIf word.Chars(myLetter).ToString() = " " Then
                                letterControlSortedList2.Add((13 + (numberOfLengths2)), word.Chars(myLetter).ToString())
                                numberOfLengths2 += 1
                            End If
                        Next
                    ElseIf ((word.Replace(" ", "").Length > (maxLength) - numberOfLengths2 Or (word.Replace(" ", "").Length <= 2 And firstInstanceTwoLetter = True And category = "BEFORE & AFTER")) And row2 = True And row3 = False) Or (word.Replace(" ", "").Length <= (maxLength) - numberOfLengths3 And row3 = True And row4 = False) Then
                        row3 = True
                        For myLetter = 0 To word.Length - 1
                            If word.Chars(myLetter).ToString() <> " " Then
                                letterControlSortedList3.Add((27 + (numberOfLengths3)), word.Chars(myLetter).ToString())
                                numberOfLengths3 += 1
                            ElseIf word.Chars(myLetter).ToString() = " " Then
                                letterControlSortedList3.Add((27 + (numberOfLengths3)), word.Chars(myLetter).ToString())
                                numberOfLengths3 += 1
                            End If
                        Next
                    ElseIf ((word.Replace(" ", "").Length > (maxLength) - numberOfLengths3 Or (word.Replace(" ", "").Length <= 2 And firstInstanceTwoLetter = True And category = "BEFORE & AFTER")) And row3 = True And row4 = False) Or (word.Replace(" ", "").Length <= (maxLength) - numberOfLengths4 And row4 = True) Then
                        row4 = True
                        Try
                            For myLetter = 0 To word.Length - 1
                                If word.Chars(myLetter).ToString() <> " " Then
                                    letterControlSortedList4.Add((41 + (numberOfLengths4)), word.Chars(myLetter).ToString())
                                    numberOfLengths4 += 1
                                ElseIf word.Chars(myLetter).ToString() = " " Then
                                    letterControlSortedList4.Add((41 + (numberOfLengths4)), word.Chars(myLetter).ToString())
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
            If (letterControlSortedList1.Count <> 13 And letterControlSortedList1.Count <> 12) And (letterControlSortedList4.Count <> 13 And letterControlSortedList4.Count <> 12) And letterControlSortedList2.Count <> 15 And letterControlSortedList3.Count <> 15 Then
                trillonOffset = Math.Ceiling((14 - letterControlSortedList1.Count) / 2)
                Dim max = letterControlSortedList1.Count
                If letterControlSortedList2.Count <> 15 Then
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
            Next
            For Each item As KeyValuePair(Of Integer, String) In letterControlSortedList2
                If letterControlSortedList2.Count <> 15 Then
                    loadTrillonOffset(item, trillonPreset, trillonOffset, letterControlSortedList1.Count)
                Else
                    loadTrillonOffset(item, trillonPreset, 0, letterControlSortedList1.Count)
                End If
            Next
            For Each item As KeyValuePair(Of Integer, String) In letterControlSortedList3
                If letterControlSortedList3.Count <> 15 Then
                    loadTrillonOffset(item, trillonPreset, trillonOffset, letterControlSortedList1.Count)
                Else
                    loadTrillonOffset(item, trillonPreset, 0, letterControlSortedList1.Count)
                End If
            Next
            If Not (letterControlSortedList4.Count > 1 And letterControlSortedList1.Count = 0) Then
                trillonOffset -= 1
            End If
            For Each item As KeyValuePair(Of Integer, String) In letterControlSortedList4
                If letterControlSortedList4.Count = 13 Or trillonOffset = 1 Then
                    loadTrillonOffset(item, trillonPreset, (trillonOffset), letterControlSortedList1.Count)
                Else
                    loadTrillonOffset(item, trillonPreset, (trillonOffset), letterControlSortedList1.Count)
                End If
            Next
        Else
            frmPuzzleBoard.logoCrossword.Show()
            Try
                For Each word As String In myWords
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
                            puzzleBoardLetterInteger = Nothing
                        End If
                    Next
                Next
            Catch ex As Exception
                MsgBox("The crossword puzzle is invalid, please go to the customizer and re-enter the puzzle. Remember to follow the crossword format exactly as mistakes will cause the crossword to not load.", vbCritical, "Wheel of Fortune")
            End Try
        End If
        For Each item As KeyValuePair(Of Integer, String) In solveSortedList
            If item.Key = solveSortedList.Last.Key Then

            End If
        Next
        puzzleLoaded = True
        revealCategory()
        If quickGame = False Then
            saveToDB()
        End If
    End Sub
    Public Shared Sub loadTrillonOffset(item As KeyValuePair(Of Integer, String), trillonPreset As Integer, trillonOffset As Integer, row1Count As Integer)
        If item.Key >= 13 And item.Key <= 26 And letterControlSortedList1.Count = 0 And letterControlSortedList4.Count > 0 Then
            trillonPreset = 13
        End If
        If trillonOffset > 1 Then
            If item.Value.Replace(" ", "") = "'" Or item.Value.Replace(" ", "") = "?" Or item.Value.Replace(" ", "") = "." Or item.Value.Replace(" ", "") = "!" Or item.Value.Replace(" ", "") = "-" Or item.Value.Replace(" ", "") = "/" Or item.Value.Replace(" ", "") = ":" Or item.Value.Replace(" ", "") = "\" Or item.Value.Replace(" ", "") = "&" Then
                CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((item.Key - trillonPreset) + trillonOffset)), PuzzleBoardLetter).Show()
                CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((item.Key - trillonPreset) + trillonOffset)), PuzzleBoardLetter).letterBehind = item.Value.Replace(" ", "")
                CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((item.Key - trillonPreset) + trillonOffset)), PuzzleBoardLetter).revealLetter()
            ElseIf item.Value = " " Then
                If item.Key <> 53 And (item.Key + 1) <> 53 Then
                    CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((item.Key - trillonPreset) + trillonOffset)), PuzzleBoardLetter).Hide()
                End If
            Else
                CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((item.Key - trillonPreset) + trillonOffset)), PuzzleBoardLetter).Show()
                CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((item.Key - trillonPreset) + trillonOffset)), PuzzleBoardLetter).letterBehind = item.Value
                'solveTypedList.Add((item.Key - trillonPreset) + trillonOffset)
            End If
        Else
            If item.Value.Replace(" ", "") = "'" Or item.Value.Replace(" ", "") = "?" Or item.Value.Replace(" ", "") = "." Or item.Value.Replace(" ", "") = "!" Or item.Value.Replace(" ", "") = "-" Or item.Value.Replace(" ", "") = "/" Or item.Value.Replace(" ", "") = ":" Or item.Value.Replace(" ", "") = "\" Or item.Value.Replace(" ", "") = "&" Then
                If item.Key <= 40 And trillonOffset >= 1 Then
                    CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((item.Key - trillonPreset) + 1)), PuzzleBoardLetter).Show()
                    CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((item.Key - trillonPreset) + 1)), PuzzleBoardLetter).letterBehind = item.Value.Replace(" ", "")
                    CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & ((item.Key - trillonPreset) + 1)), PuzzleBoardLetter).revealLetter()
                Else
                    CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & (item.Key - trillonPreset)), PuzzleBoardLetter).Show()
                    CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & (item.Key - trillonPreset)), PuzzleBoardLetter).letterBehind = item.Value.Replace(" ", "")
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
#Region "Return String Without Punctuation"
    Public Shared Function removePunctuation(str As String)
        Return str.Replace("'", "").Replace("?", "").Replace(".", "").Replace("!", "").Replace("-", "").Replace("/", "").Replace(":", "").Replace("\", "").Replace(" &", "")
    End Function
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
        frmPuzzleBoard.btnSolve.Enabled = False
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
                player1RingIn = True
            ElseIf currentPlayer = 2 Then
                player2RingIn = True
            ElseIf currentPlayer = 3 Then
                player3RingIn = True
            End If
            If player1RingIn = True Then
                frmPuzzleBoard.btnRedRingIn.Enabled = False
            ElseIf player1RingIn = False Then
                frmPuzzleBoard.btnRedRingIn.Enabled = True
            End If
            If player2RingIn = True Then
                frmPuzzleBoard.btnYellowRingIn.Enabled = False
            ElseIf player2RingIn = False Then
                frmPuzzleBoard.btnYellowRingIn.Enabled = True
            End If
            If player3RingIn = True Then
                frmPuzzleBoard.btnBlueRingIn.Enabled = False
            ElseIf player3RingIn = False Then
                frmPuzzleBoard.btnBlueRingIn.Enabled = True
            End If
            If numberOfPlayers <> 1 And (round = PuzzleType.TU1 Or round = PuzzleType.TU2 Or round = PuzzleType.TU3 Or round = PuzzleType.TBTU) And (player1RingIn = False Or player2RingIn = False Or player3RingIn = False) And allRungIn = False Then
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
        If (round = PuzzleType.TU1 Or round = PuzzleType.TU2 Or round = PuzzleType.TU3 Or round = PuzzleType.TBTU) And numberOfPlayers <> 1 And (player1RingIn = False Or player2RingIn = False Or player3RingIn = False Or allRungIn = True) And tossUpLetterControlList.Count > 0 Then
            My.Computer.Audio.Play(My.Resources.toss_up_new, AudioPlayMode.BackgroundLoop)
        ElseIf (round = PuzzleType.TU1 Or round = PuzzleType.TU2 Or round = PuzzleType.TU3 Or round = PuzzleType.TBTU) And numberOfPlayers = 1 Then
            'solveAttempt = puzzle
            'solved = True
            tossUpSolved = True
        End If
    End Sub
#End Region
#Region "Load Letters from Puzzle String"
    Public Shared Sub loadLettersFromPuzzleString()
        loadPuzzle(round, puzzleMode, False)
        If puzzle <> puzzleString Then
            Dim currentPuzzleArray As Char() = puzzle.ToCharArray()
            For Each letter As Char In currentPuzzleArray
                If Not puzzleString.Contains(letter) Then
                    If Not loadGameLetterRevealList.Contains(letter.ToString()) Then
                        loadGameLetterRevealList.Add(letter.ToString())
                    End If
                End If
            Next
            If loadGameLetterRevealList.Count <> 0 Then
                For i As Integer = 0 To loadGameLetterRevealList.Count - 1
                    For Each boardLetter As PuzzleBoardLetter In frmPuzzleBoard.Controls(puzzleBoardName).Controls
                        If boardLetter.letterBehind = loadGameLetterRevealList(i).ToString() Then
                            Select Case loadGameLetterRevealList(i).ToString()
                                Case "A"
                                    aEnabled = False
                                Case "E"
                                    eEnabled = False
                                Case "I"
                                    iEnabled = False
                                Case "O"
                                    oEnabled = False
                                Case "U"
                                    uEnabled = False
                            End Select
                            If Not (round = PuzzleType.TU1 Or round = PuzzleType.TU2 Or round = PuzzleType.TU3 Or round = PuzzleType.TBTU) Then
                                CType(frmScore.usedLetterBoard.Controls("btn" & loadGameLetterRevealList(i).ToString()), Button).Enabled = False
                            End If
                            boardLetter.revealLetter()
                            boardLetter.letterRevealed = True
                        End If
                    Next
                Next
            End If
        End If
        If round = PuzzleType.TU1 Or round = PuzzleType.TU2 Or round = PuzzleType.TU3 Or round = PuzzleType.TBTU Then
            If Player1List.Count > 0 Then
                frmPuzzleBoard.btnRedRingIn.Show()
            End If
            If Player2List.Count > 0 Then
                frmPuzzleBoard.btnYellowRingIn.Show()
            End If
            If Player3List.Count > 0 Then
                frmPuzzleBoard.btnBlueRingIn.Show()
            End If
        End If
        addToSolve()
        loadGameLetterRevealList.Clear()
    End Sub
#End Region
#Region "Add to Solve List"
    Public Shared Sub addToSolve(btn As Button)
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
    End Sub
    Public Shared Sub addToSolve()
        For Each myLetter As PuzzleBoardLetter In frmPuzzleBoard.PuzzleBoard1.Controls
            If myLetter.letterRevealed = True Then
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
    End Sub
#End Region
#Region "Load Letters"
    Public Shared Sub loadLetters(ByRef btn As Button)
        If round <> PuzzleType.BR Then
            frmPuzzleBoard.btnSolve.Enabled = True
        End If
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
            addToSolve(btn)
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
                    If finalSpin = True Then
                        If virtualHost = True Then
                            SAPI.Speak("Vowels are worth nothing, but they can be really helpful.")
                        End If
                    End If
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
                        finalSpinTimesUp = True
                    End If
                    If frmScore.lblCurrentValue.Text = "Mystery 1" And mysteryStatus = False Or frmScore.lblCurrentValue.Text = "Mystery 2" And mysteryStatus = False Then
                        MysteryDialog.ShowDialog()
                    End If
                    If frmScore.lblCurrentValue.Text = "Express" And expressStatus = False Then
                        ExpressDialog.ShowDialog()
                    End If
                    frmScore.notifyBar.Text = revealNumberOfLetters()
                ElseIf Not puzzle.Contains(currentLetter) Then
                    If frmScore.lblCurrentValue.Text <> "Free Play" Then
                        If finalSpin = True Then
                            previousValue = ""
                            finalSpinTimesUp = False
                            frmScore.usedLetterBoard.Enabled = True
                            frmScore.notifyBar.Text = revealNumberOfLetters()
                            LoseATurn()
                            btn.Enabled = False
                        ElseIf expressStatus = True Then
                            spinResult = 0
                            bankrupt()
                            btn.Enabled = False
                            frmPuzzleBoard.logoExpress.Hide()
                            frmPuzzleBoard.wheelTilt.Enabled = True
                            frmAudio.playExpress(False)
                            expressStatus = False
                        ElseIf expressStatus = False Or finalSpin = False Then
                            spinResult = 0
                            btn.Enabled = False
                            frmScore.notifyBar.Text = revealNumberOfLetters()
                            isNoLetters = True
                            LoseATurn()
                            frmScore.usedLetterBoard.Enabled = True
                            If finalSpin = True Then
                                previousValue = ""
                            Else
                            End If
                        End If
                    Else
                        frmScore.notifyBar.Text = revealNumberOfLetters()
                        isNoLetters = True
                        If virtualHost = True Then
                            SAPI.Speak("Because of the free play wedge, you don't lose your turn.")
                        End If
                        frmScore.usedLetterBoard.Enabled = True
                    End If

                End If
                disableCurrentVowel()
                timeStart = DateTime.Now.Second
                frmScore.tmrLetterReveal.Start()
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
                    If currentPlayer1Value.ToString() = "" Then
                        currentPlayer1Value = 0
                    End If
                    currentPlayer1Value += 1000
                    frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text = FormatCurrency(currentPlayer1Value, 0)
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
                                If round = PuzzleType.R3 And Not (currentPlayerObject(0).getWedges(Player.Wedges.HalfCar1) And currentPlayerObject(0).getWedges(Player.Wedges.HalfCar2)) Then
                                    SAPI.Speak("It's the last round to get the other half.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                                End If
                            End If
                            For Each myPlayer As Player In currentPlayerObject
                                myPlayer.addCardsOrWedges(Player.Wedges.HalfCar1, True)
                            Next
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
                            For Each myPlayer As Player In currentPlayerObject
                                myPlayer.addCardsOrWedges(Player.Wedges.HalfCar2, True)
                            Next
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
                        For Each myPlayer As Player In currentPlayerObject
                            myPlayer.addCardsOrWedges(Player.Wedges.Million, True)
                        Next
                        wheelWedges(46) = "500"
                        wheelWedges(47) = "500"
                        wheelWedges(48) = "500"
                        millionStatus = True
                        frmScore.Million.Show()
                        loadMillionWheel()
                    End If
                    If frmScore.lblCurrentValue.Text = "Wild" And wildCardStatus = False Then
                        'SAPI = CreateObject("SAPI.spvoice")
                        If virtualHost = True Then
                            SAPI.Speak("Pick up the Wild card.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                        End If
                        For Each myPlayer As Player In currentPlayerObject
                            myPlayer.addCardsOrWedges(Player.Wedges.Wild, True)
                        Next
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
                        For Each myPlayer As Player In currentPlayerObject
                            myPlayer.addCardsOrWedges(Player.Wedges.Gift, True)
                        Next
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
                        For Each myPlayer As Player In currentPlayerObject
                            myPlayer.addCardsOrWedges(Player.Wedges.Prize, True)
                        Next
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
                If selectedBonusLetters.Count <= 4 And bonusRoundPlayer(0).getWedges(Player.Wedges.Wild) = False OrElse selectedBonusLetters.Count <= 5 And bonusRoundPlayer(0).getWedges(Player.Wedges.Wild) = True Then
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
                ElseIf selectedBonusLetters.Count = 4 And bonusRoundPlayer(0).getWedges(Player.Wedges.Wild) = False OrElse selectedBonusLetters.Count = 5 And bonusRoundPlayer(0).getWedges(Player.Wedges.Wild) = True Then
                    btn.Enabled = False
                    frmScore.btnBonusTimerStart.Show()
                ElseIf selectedBonusLetters.Count = 4 And bonusRoundPlayer(0).getWedges(Player.Wedges.Wild) = True Then
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
                finalSpinTimesUp = False
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
        If quickGame = False Then
            saveToDB()
        End If
    End Sub
    Public Shared Sub backspaceLetter()
        For i As Integer = lastLetter To 1 Step -1
            CType(frmPuzzleBoard.PuzzleBoard1.Controls("PuzzleBoardLetter" & i), PuzzleBoardLetter).btnLetter.BackColor = Color.White
        Next
        Try
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
        Catch ex As Exception
        End Try
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
            frmScore.flpUsedLetterBoard.BackColor = Color.Red
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
            If Player1List.Count > 0 Then
                If Player1List(0).getWedges(Player.Wedges.HalfCar1) = True Then
                    frmScore.halfcar1.Show()
                ElseIf Player1List(0).getWedges(Player.Wedges.HalfCar1) = False Then
                    frmScore.halfcar1.Hide()
                End If
                If Player1List(0).getWedges(Player.Wedges.HalfCar2) = True Then
                    frmScore.halfcar2.Show()
                ElseIf Player1List(0).getWedges(Player.Wedges.HalfCar2) = False Then
                    frmScore.halfcar2.Hide()
                End If
                If Player1List(0).getWedges(Player.Wedges.Million) = True Then
                    frmScore.Million.Show()
                ElseIf Player1List(0).getWedges(Player.Wedges.Million) = False Then
                    frmScore.Million.Hide()
                End If
                If Player1List(0).getWedges(Player.Wedges.Wild) = True Then
                    frmScore.Wild.Show()
                    If round <> PuzzleType.BR Then
                        frmPuzzleBoard.btnWild.Show()
                    Else
                        frmPuzzleBoard.btnWild.Hide()
                    End If
                ElseIf Player1List(0).getWedges(Player.Wedges.Wild) = False Then
                    frmScore.Wild.Hide()
                    frmPuzzleBoard.btnWild.Hide()
                End If
                If Player1List(0).getWedges(Player.Wedges.Gift) = True Then
                    frmScore.Gift.Show()
                ElseIf Player1List(0).getWedges(Player.Wedges.Gift) = False Then
                    frmScore.Gift.Hide()
                End If
                If Player1List(0).getWedges(Player.Wedges.Prize) = True Then
                    frmScore.Prize.Show()
                ElseIf Player1List(0).getWedges(Player.Wedges.Prize) = False Then
                    frmScore.Prize.Hide()
                End If
                If Player1List(0).getWedges(Player.Wedges.Mystery) = True Then
                    frmScore.Mystery.Show()
                ElseIf Player1List(0).getWedges(Player.Wedges.Mystery) = False Then
                    frmScore.Mystery.Hide()
                End If
            End If
        ElseIf currentPlayer = 2 Then
            'frmScore.NameTag1.lblName.Text = player2Name
            frmScore.usedLetterBoard.BackColor = Color.Gold
            frmScore.flpUsedLetterBoard.BackColor = Color.Gold
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
            If Player2List.Count > 0 Then
                If Player2List(0).getWedges(Player.Wedges.HalfCar1) = True Then
                    frmScore.halfcar1.Show()
                ElseIf Player2List(0).getWedges(Player.Wedges.HalfCar1) = False Then
                    frmScore.halfcar1.Hide()
                End If
                If Player2List(0).getWedges(Player.Wedges.HalfCar2) = True Then
                    frmScore.halfcar2.Show()
                ElseIf Player2List(0).getWedges(Player.Wedges.HalfCar2) = False Then
                    frmScore.halfcar2.Hide()
                End If
                If Player2List(0).getWedges(Player.Wedges.Million) = True Then
                    frmScore.Million.Show()
                ElseIf Player2List(0).getWedges(Player.Wedges.Million) = False Then
                    frmScore.Million.Hide()
                End If
                If Player2List(0).getWedges(Player.Wedges.Wild) = True Then
                    frmScore.Wild.Show()
                    If round <> PuzzleType.BR Then
                        frmPuzzleBoard.btnWild.Show()
                    Else
                        frmPuzzleBoard.btnWild.Hide()
                    End If
                ElseIf Player2List(0).getWedges(Player.Wedges.Wild) = False Then
                    frmScore.Wild.Hide()
                    frmPuzzleBoard.btnWild.Hide()
                End If
                If Player2List(0).getWedges(Player.Wedges.Gift) = True Then
                    frmScore.Gift.Show()
                ElseIf Player2List(0).getWedges(Player.Wedges.Gift) = False Then
                    frmScore.Gift.Hide()
                End If
                If Player2List(0).getWedges(Player.Wedges.Prize) = True Then
                    frmScore.Prize.Show()
                ElseIf Player2List(0).getWedges(Player.Wedges.Prize) = False Then
                    frmScore.Prize.Hide()
                End If
                If Player2List(0).getWedges(Player.Wedges.Mystery) = True Then
                    frmScore.Mystery.Show()
                ElseIf Player2List(0).getWedges(Player.Wedges.Mystery) = False Then
                    frmScore.Mystery.Hide()
                End If
            End If
        ElseIf currentPlayer = 3 Then
            'frmScore.NameTag1.lblName.Text = player3Name
            frmScore.usedLetterBoard.BackColor = Color.FromArgb(0, 45, 192)
                frmScore.flpUsedLetterBoard.BackColor = Color.FromArgb(0, 45, 192)
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
            If Player3List.Count > 0 Then
                If Player3List(0).getWedges(Player.Wedges.HalfCar1) = True Then
                    frmScore.halfcar1.Show()
                ElseIf Player3List(0).getWedges(Player.Wedges.HalfCar1) = False Then
                    frmScore.halfcar1.Hide()
                End If
                If Player3List(0).getWedges(Player.Wedges.HalfCar2) = True Then
                    frmScore.halfcar2.Show()
                ElseIf Player3List(0).getWedges(Player.Wedges.HalfCar2) = False Then
                    frmScore.halfcar2.Hide()
                End If
                If Player3List(0).getWedges(Player.Wedges.Million) = True Then
                    frmScore.Million.Show()
                ElseIf Player3List(0).getWedges(Player.Wedges.Million) = False Then
                    frmScore.Million.Hide()
                End If
                If Player3List(0).getWedges(Player.Wedges.Wild) = True Then
                    frmScore.Wild.Show()
                    If round <> PuzzleType.BR Then
                        frmPuzzleBoard.btnWild.Show()
                    Else
                        frmPuzzleBoard.btnWild.Hide()
                    End If
                ElseIf Player3List(0).getWedges(Player.Wedges.Wild) = False Then
                    frmScore.Wild.Hide()
                    frmPuzzleBoard.btnWild.Hide()
                End If
                If Player3List(0).getWedges(Player.Wedges.Gift) = True Then
                    frmScore.Gift.Show()
                ElseIf Player3List(0).getWedges(Player.Wedges.Gift) = False Then
                    frmScore.Gift.Hide()
                End If
                If Player3List(0).getWedges(Player.Wedges.Prize) = True Then
                    frmScore.Prize.Show()
                ElseIf Player3List(0).getWedges(Player.Wedges.Prize) = False Then
                    frmScore.Prize.Hide()
                End If
                If Player3List(0).getWedges(Player.Wedges.Mystery) = True Then
                    frmScore.Mystery.Show()
                ElseIf Player3List(0).getWedges(Player.Wedges.Mystery) = False Then
                    frmScore.Mystery.Hide()
                End If
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
            If (selectedBonusLetters.Count = 3 And bonusRoundPlayer(0).getWedges(Player.Wedges.Wild) = False) And lettersSelected = False Then
                If bonusVowelsEnabled = False Then
                    enableBonusVowels(True)
                    'vowelModeEnabled = True
                End If
            ElseIf (selectedBonusLetters.Count = 3 And bonusRoundPlayer(0).getWedges(Player.Wedges.Wild) = True) And lettersSelected = False Then
                If bonusVowelsEnabled = False Then
                    enableBonusVowels(True)
                    'vowelModeEnabled = True
                End If
            ElseIf (selectedBonusLetters.Count = 4 And bonusRoundPlayer(0).getWedges(Player.Wedges.Wild) = True) And lettersSelected = False Then
                frmPuzzleBoard.pboxWild.Show()
                'SAPI.Speak("Because of this Wild card, you can pick an extra consonant.")
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
            ElseIf (selectedBonusLetters.Count = 4 And bonusRoundPlayer(0).getWedges(Player.Wedges.Wild) = False Or selectedBonusLetters.Count = 5 And bonusRoundPlayer(0).getWedges(Player.Wedges.Wild) = True) And lettersSelected = False Then
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
            currentPlayerObject = Player1List
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
            currentPlayerObject = Player2List
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
            currentPlayerObject = Player3List
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
        setAllRingIn()
    End Sub
    Public Shared Sub setAllRingIn()
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
        Dim currentPlayerWinner As List(Of Player)
        If currentPlayerObject Is Nothing Then
        ElseIf Not currentPlayerObject Is Nothing And round <> PuzzleType.BR Then
            revealPuzzleWinner()
            For i As Integer = 1 To 3
                If i = 1 Then
                    If Player1List.Count > 0 Then
                        currentPlayerWinner = Player1List
                    End If
                ElseIf i = 2 Then
                    If Player2List.Count > 0 Then
                        currentPlayerWinner = Player2List
                    End If
                ElseIf i = 3 Then
                    If Player3List.Count > 0 Then
                        currentPlayerWinner = Player3List
                    End If
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
                If puzzleSolver = i And currentPlayerWinner(0).getWedges(Player.Wedges.HalfCar1) = True And currentPlayerWinner(0).getWedges(Player.Wedges.HalfCar2) = True Then
                    Dim currentValue = frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text + 25000
                    frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text = FormatCurrency(currentValue, 0)
                    For Each myPlayer As Player In currentPlayerWinner
                        myPlayer.total += 25000
                    Next
                    carAwarded = True
                    If numberOfPrizes = 0 Then
                        If virtualHost = True Then
                            SAPI.Speak("You just won a brand new car that is worth $25,000!", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                        End If
                        houseMinimumMet = True
                    Else
                        If virtualHost = True Then
                            SAPI.Speak("You also just won a brand new car that is worth $25,000!", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                        End If
                    End If
                    For Each myPlayer As Player In Player1List
                        myPlayer.addCardsOrWedges(Player.Wedges.HalfCar1, False)
                        myPlayer.addCardsOrWedges(Player.Wedges.HalfCar2, False)
                    Next
                    For Each myPlayer As Player In Player2List
                        myPlayer.addCardsOrWedges(Player.Wedges.HalfCar1, False)
                        myPlayer.addCardsOrWedges(Player.Wedges.HalfCar2, False)
                    Next
                    For Each myPlayer As Player In Player3List
                        myPlayer.addCardsOrWedges(Player.Wedges.HalfCar1, False)
                        myPlayer.addCardsOrWedges(Player.Wedges.HalfCar2, False)
                    Next
                    'player2.addCardsOrWedges(Player.Wedges.HalfCar1, False)
                    'player2.addCardsOrWedges(Player.Wedges.HalfCar2, False)
                    'player3.addCardsOrWedges(Player.Wedges.HalfCar1, False)
                    'player3.addCardsOrWedges(Player.Wedges.HalfCar2, False)
                End If
                If puzzleSolver <> i And currentPlayerWinner(0).getWedgeRound(Player.Wedges.HalfCar1) = round Then
                    For Each myPlayer As Player In currentPlayerWinner
                        myPlayer.addCardsOrWedges(Player.Wedges.HalfCar1, False)
                    Next
                ElseIf puzzleSolver <> i And currentPlayerWinner(0).getWedgeRound(Player.Wedges.HalfCar2) = round Then
                    For Each myPlayer As Player In currentPlayerWinner
                        myPlayer.addCardsOrWedges(Player.Wedges.HalfCar2, False)
                    Next
                End If
                If puzzleSolver = i And currentPlayerWinner(0).getWedgeRound(Player.Wedges.Million) = round And currentPlayerWinner(0).getWedges(Player.Wedges.Million) = True Then
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
                ElseIf puzzleSolver <> i And currentPlayerWinner(0).getWedgeRound(Player.Wedges.Million) = round And currentPlayerWinner(0).getWedges(Player.Wedges.Million) = True Then
                    For Each myPlayer As Player In currentPlayerWinner
                        myPlayer.addCardsOrWedges(Player.Wedges.Million, False)
                    Next
                    If virtualHost = True Then
                        SAPI.Speak("Unfortunately, the million dollar wedge is out of play tonight.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                    End If
                Else
                End If
                If puzzleSolver = i And currentPlayerWinner(0).getWedgeRound(Player.Wedges.Gift) = round And currentPlayerWinner(0).getWedges(Player.Wedges.Gift) = True Then
                    Dim currentValue = frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text + 1000
                    frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text = FormatCurrency(currentValue, 0)
                    For Each myPlayer As Player In currentPlayerWinner
                        myPlayer.total += 1000
                    Next
                    If numberOfPrizes = 0 Then
                        If virtualHost = True Then
                            SAPI.Speak("You picked up a gift worth $1,000.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                        End If
                        houseMinimumMet = True
                    Else
                    End If
                    numberOfPrizes += 1
                    For Each myPlayer As Player In currentPlayerWinner
                        myPlayer.addCardsOrWedges(Player.Wedges.Gift, False)
                    Next
                ElseIf currentPlayerWinner(0).getWedgeRound(Player.Wedges.Gift) = round And currentPlayerWinner(0).getWedges(Player.Wedges.Million) = True Then
                    For Each myPlayer As Player In currentPlayerWinner
                        myPlayer.addCardsOrWedges(Player.Wedges.Gift, False)
                    Next
                Else
                End If
                If currentPlayerWinner(0).getWedges(Player.Wedges.Mystery) = True And puzzleSolver = i And currentPlayerWinner(0).getWedges(Player.Wedges.Mystery) = True Then
                    Dim currentValue = frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text + 10000
                    frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text = FormatCurrency(currentValue, 0)
                    For Each myPlayer As Player In currentPlayerWinner
                        myPlayer.total += 10000
                        myPlayer.addCardsOrWedges(Player.Wedges.Mystery, False)
                    Next
                    numberOfPrizes += 1
                    houseMinimumMet = True
                Else
                End If
                For Each myPlayer As Player In currentPlayerWinner
                    myPlayer.addCardsOrWedges(Player.Wedges.Mystery, False)
                Next
                If puzzleSolver = i And currentPlayerWinner(0).getWedgeRound(Player.Wedges.Prize) = round And currentPlayerWinner(0).getWedges(Player.Wedges.Prize) = True Then
                    Dim currentValue = frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text + 11000
                    frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text = FormatCurrency(currentValue, 0)
                    For Each myPlayer As Player In currentPlayerWinner
                        myPlayer.total += 11000
                    Next
                    If numberOfPrizes = 0 Then
                        If virtualHost = True Then
                            SAPI.Speak("You won a great trip worth $11,000.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                        End If
                    Else
                        If virtualHost = True Then
                            SAPI.Speak("You also won a great trip worth $11,000.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                        End If
                    End If
                    For Each myPlayer As Player In currentPlayerWinner
                        myPlayer.addCardsOrWedges(Player.Wedges.Prize, False)
                    Next
                    numberOfPrizes += 1
                    houseMinimumMet = True
                ElseIf currentPlayerWinner(0).getWedgeRound(Player.Wedges.Prize) = round And currentPlayerWinner(0).getWedges(Player.Wedges.Million) = True Then
                    For Each myPlayer As Player In currentPlayerWinner
                        myPlayer.addCardsOrWedges(Player.Wedges.Prize, False)
                    Next
                Else
                End If
                If puzzleSolver = i And round = PuzzleType.R3 Then
                    Dim currentValue = frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text + 15000
                    frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text = FormatCurrency(currentValue, 0)
                    For Each myPlayer As Player In currentPlayerWinner
                        myPlayer.total += 15000
                    Next
                    If virtualHost = True Then
                        SAPI.Speak("Don't forget that this was also a prize puzzle. You won a great trip that is worth over $15,000.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                    End If
                    For Each myPlayer As Player In Player1List
                        myPlayer.addCardsOrWedges(Player.Wedges.HalfCar1, False)
                        myPlayer.addCardsOrWedges(Player.Wedges.HalfCar2, False)
                    Next
                    For Each myPlayer As Player In Player2List
                        myPlayer.addCardsOrWedges(Player.Wedges.HalfCar1, False)
                        myPlayer.addCardsOrWedges(Player.Wedges.HalfCar2, False)
                    Next
                    For Each myPlayer As Player In Player3List
                        myPlayer.addCardsOrWedges(Player.Wedges.HalfCar1, False)
                        myPlayer.addCardsOrWedges(Player.Wedges.HalfCar2, False)
                    Next
                    numberOfPrizes += 1
                    houseMinimumMet = True
                End If
                If puzzleSolver = i And currentPlayerWinner(0).getWedgeRound(Player.Wedges.Wild) = round And currentPlayerWinner(0).getWedges(Player.Wedges.Wild) = True Then
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
            If Player1List.Count > 0 Then
                frmScore.lblPlayer1Total.Show()
                frmScore.lblPlayer1Total.Text = FormatCurrency(Player1List(0).total, 0)
            End If
            If Player2List.Count > 0 Then
                frmScore.lblPlayer2Total.Show()
                frmScore.lblPlayer2Total.Text = FormatCurrency(Player2List(0).total, 0)
            End If
            If Player3List.Count > 0 Then
                frmScore.lblPlayer3Total.Show()
                frmScore.lblPlayer3Total.Text = FormatCurrency(Player3List(0).total, 0)
            End If
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
                    For Each myPlayer As Player In bonusRoundPlayer
                        myPlayer.total += wheelWedges.Item(frmPuzzleBoard.WheelSpinControl1.trkBonusWheel.Value)
                    Next
                Else
                    For Each myPlayer As Player In bonusRoundPlayer
                        myPlayer.total += 35000
                    Next
                End If
                If Player1List.Count > 0 Then
                    frmScore.lblPlayer1Total.Show()
                    frmScore.lblPlayer1Total.Text = FormatCurrency(Player1List(0).total, 0)
                End If
                If Player2List.Count > 0 Then
                    frmScore.lblPlayer2Total.Show()
                    frmScore.lblPlayer2Total.Text = FormatCurrency(Player2List(0).total, 0)
                End If
                If Player3List.Count > 0 Then
                    frmScore.lblPlayer3Total.Show()
                    frmScore.lblPlayer3Total.Text = FormatCurrency(Player3List(0).total, 0)
                End If
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
        puzzleString = puzzle
    End Sub
#End Region
#Region "Re-Enable All Letters"
    Private Shared Sub reEnableLetters()
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
            If selectedBonusLetters.Count = 3 And bonusRoundPlayer(0).getWedges(Player.Wedges.Wild) = False Then
                disableConsonants()
            ElseIf selectedBonusLetters.Count = 3 And bonusRoundPlayer(0).getWedges(Player.Wedges.Wild) = True Then
                disableConsonants()
            ElseIf selectedBonusLetters.Count = 4 And bonusRoundPlayer(0).getWedges(Player.Wedges.Wild) = True Then
                showUsedLettersInBonus()
            ElseIf selectedBonusLetters.Count < 3 Then

            ElseIf selectedBonusLetters.Count = 4 And bonusRoundPlayer(0).getWedges(Player.Wedges.Wild) = False Or selectedBonusLetters.Count = 5 And bonusRoundPlayer(0).getWedges(Player.Wedges.Wild) = True Then
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
                If bonusSolved <> False Then
                    CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & letterControlList(randomNumber)), PuzzleBoardLetter).displayBlueBKG()
                    If finalSpin <> True Then
                        CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & letterControlList(randomNumber)), PuzzleBoardLetter).playDing()
                    Else
                    End If
                ElseIf round = PuzzleType.BR And bonusSolved = False Then
                    CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & letterControlList(randomNumber)), PuzzleBoardLetter).revealLetter()
                End If
                frmPuzzleBoard.ListBox4.Items.Add(randomNumber & CType(frmPuzzleBoard.Controls(puzzleBoardName).Controls("PuzzleBoardLetter" & letterControlList(randomNumber)), PuzzleBoardLetter).letterBehind)
                letterControlList.Remove(letterControlList(randomNumber))
                timeStart = DateTime.Now.Second
            End If
        Next
        If letterControlList.Count = 0 Then
            If round = PuzzleType.BR And frmPuzzleBoard.lblChosenLetters.Visible = False Then
                frmPuzzleBoard.btnSolve.Enabled = False
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
        If solveMode = False And revealed = False And typeToSolve = True And solved = False And tossUpSolved = False And bonusSolved = True Then
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
            If removePunctuation(solveAttempt.Replace(" ", "")) = removePunctuation(puzzle.Replace(" ", "")) Or typeToSolve = False Or bonusSolved = False Or tossUpSolved = False Then
                If removePunctuation(solveAttempt.Replace(" ", "")) = removePunctuation(puzzle.Replace(" ", "")) Then
                    tossUpSolved = True
                Else
                    tossUpSolved = False
                    If player1RingIn = True And player2RingIn = True And player3RingIn = True Or revealed = True Then
                    Else
                        cancelSolve()
                        Exit Sub
                    End If
                End If
                frmScore.wmpBonus.Ctlcontrols.stop()
                solved = False
                puzzleSolver = currentPlayer
                frmAudio.playSpeedUp(False)
                frmAudio.playExpress(False)
                frmAudio.playAudClap(True)
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
                        If bonusSolved <> False Then
                            For Each lettersControls As Control In frmPuzzleBoard.Controls(puzzleBoardName).Controls
                                If lettersControls.GetType() Is GetType(PuzzleBoardLetter) Then
                                    CType(lettersControls, PuzzleBoardLetter).revealLetter()
                                    'CType(lettersControls, PuzzleBoardLetter).tossUpStatus = False
                                End If
                            Next
                        ElseIf round = PuzzleType.BR And bonusSolved = False Then
                            frmAudio.playAudDisapp(True)
                            startTossUp()
                                'For Each lettersControls As Control In frmPuzzleBoard.Controls(puzzleBoardName).Controls
                                '    If lettersControls.GetType() Is GetType(PuzzleBoardLetter) And CType(lettersControls, PuzzleBoardLetter).letterRevealed = False And Not String.IsNullOrEmpty(CType(lettersControls, PuzzleBoardLetter).letterBehind) And puzzleString.Contains(CType(lettersControls, PuzzleBoardLetter).letterBehind) Then
                                '        letterControlList.Add(lettersControls.Name.Replace("PuzzleBoardLetter", ""))
                                '        letterControlTappedList.Add(lettersControls.Name.Replace("PuzzleBoardLetter", ""))
                                '        solveTypedList.Remove(lettersControls.Name.Replace("PuzzleBoardLetter", ""))
                                '        'CType(lettersControls, PuzzleBoardLetter).tossUpStatus = False
                                '    End If
                                'Next
                                timeStart = DateTime.Now.Second
                                frmScore.tmrLetterReveal.Start()
                            End If
                        If round = PuzzleType.TU1 Or round = PuzzleType.TBTU Then
                            'If currentPlayer = 1 Then
                            If currentPlayerObject IsNot Nothing And tossUpSolved = True Then
                                Dim currentValue = frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text
                                If currentValue = "" Then
                                    currentValue = 0
                                    currentValue += 1000
                                End If
                                frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text = FormatCurrency(currentValue, 0)
                                For Each myPlayer As Player In currentPlayerObject
                                    myPlayer.total += 1000
                                Next
                            Else
                                My.Computer.Audio.Play(My.Resources.Buzzer, AudioPlayMode.Background)
                                frmAudio.playAudDisapp(True)
                            End If
                            'ElseIf currentPlayer = 2 Then
                            '    player2.total += 1000
                            'ElseIf currentPlayer = 3 Then
                            '    player3.total += 1000
                            'End If
                        ElseIf round = PuzzleType.TU2 Then
                            If currentPlayerObject IsNot Nothing And tossUpSolved = True Then
                                Dim currentValue = frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text
                                If currentValue = "" Then
                                    currentValue = 0
                                    currentValue += 2000
                                End If
                                frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text = FormatCurrency(currentValue, 0)
                                For Each myPlayer As Player In currentPlayerObject
                                    myPlayer.total += 2000
                                Next
                                'ElseIf currentPlayer = 2 Then
                                '    player2.total += 2000
                                'ElseIf currentPlayer = 3 Then
                                '    player3.total += 2000
                            Else
                                My.Computer.Audio.Play(My.Resources.Buzzer, AudioPlayMode.Background)
                                frmAudio.playAudDisapp(True)
                                currentPlayer = GetRandomPlayer(1, numberOfPlayers + 1)
                                If currentPlayer = 1 Then
                                    currentPlayerObject = Player1List
                                ElseIf currentPlayer = 2 Then
                                    currentPlayerObject = Player2List
                                ElseIf currentPlayer = 3 Then
                                    currentPlayerObject = Player3List
                                End If
                            End If
                        ElseIf round = PuzzleType.TU3 Then
                            If currentPlayerObject IsNot Nothing And tossUpSolved = True Then
                                Dim currentValue = frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text
                                If currentValue = "" Then
                                    currentValue = 0
                                    currentValue += 3000
                                End If
                                frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text = FormatCurrency(currentValue, 0)
                                For Each myPlayer As Player In currentPlayerObject
                                    myPlayer.total += 3000
                                Next
                                'ElseIf currentPlayer = 2 Then
                                '    player2.total += 3000
                                'ElseIf currentPlayer = 3 Then
                                '    player3.total += 3000
                            Else
                                My.Computer.Audio.Play(My.Resources.Buzzer, AudioPlayMode.Background)
                                frmAudio.playAudDisapp(True)
                                currentPlayer = GetRandomPlayer(1, numberOfPlayers + 1)
                                If currentPlayer = 1 Then
                                    currentPlayerObject = Player1List
                                ElseIf currentPlayer = 2 Then
                                    currentPlayerObject = Player2List
                                ElseIf currentPlayer = 3 Then
                                    currentPlayerObject = Player3List
                                End If
                            End If
                        ElseIf round = PuzzleType.BR Then
                            If bonusSolved = False Then
                            Else
                                'resetPuzzle()
                            End If
                        Else

                        End If
                        Dim player1Score As Integer
                        Dim player2Score As Integer
                        Dim player3Score As Integer
                        If Player1List.Count > 0 Then
                            player1Score = Player1List(0).currentScore
                        End If
                        If Player2List.Count > 0 Then
                            player2Score = Player2List(0).currentScore
                        End If
                        If Player3List.Count > 0 Then
                            player3Score = Player3List(0).currentScore
                        End If
                        If numberOfTurns > 0 And round <> PuzzleType.TU1 And round <> PuzzleType.TU2 And round <> PuzzleType.TU3 And round <> PuzzleType.TBTU And round <> PuzzleType.BR Then
                            If currentPlayer = 1 Then
                                If teams = False Then
                                    If player1Score > 1000 Then
                                        For Each myPlayer As Player In Player1List
                                            myPlayer.total += player1Score
                                        Next
                                        houseMinimumMet = True
                                    Else
                                        Dim currentValue = frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text
                                        If currentValue = "" Then
                                            currentValue = 0
                                            currentValue = currentValue + 1000
                                        End If
                                        frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text = FormatCurrency(currentValue, 0)
                                        For Each myPlayer As Player In Player1List
                                            myPlayer.total += 1000
                                        Next
                                        houseMinimumMet = False
                                    End If
                                Else
                                    If player1Score > 2000 Then
                                        For Each myPlayer As Player In Player1List
                                            myPlayer.total += player1Score
                                        Next
                                        houseMinimumMet = True
                                    Else
                                        Dim currentValue = frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text
                                        If currentValue = "" Then
                                            currentValue = 0
                                            currentValue = currentValue + 2000
                                        End If
                                        frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text = FormatCurrency(currentValue, 0)
                                        For Each myPlayer As Player In Player1List
                                            myPlayer.total += 2000
                                        Next
                                        houseMinimumMet = False
                                    End If
                                End If
                            ElseIf currentPlayer = 2 Then
                                If teams = False Then
                                    If player2Score > 1000 Then
                                        For Each myPlayer As Player In Player2List
                                            myPlayer.total += player2Score
                                        Next
                                        houseMinimumMet = True
                                    Else
                                        Dim currentValue = frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text
                                        If currentValue = "" Then
                                            currentValue = 0
                                            currentValue = currentValue + 1000
                                        End If
                                        frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text = FormatCurrency(currentValue, 0)
                                        For Each myPlayer As Player In Player2List
                                            myPlayer.total += 1000
                                        Next
                                        houseMinimumMet = False
                                    End If
                                Else
                                    If player2Score > 2000 Then
                                        For Each myPlayer As Player In Player2List
                                            myPlayer.total += player2Score
                                        Next
                                        houseMinimumMet = True
                                    Else
                                        Dim currentValue = frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text
                                        If currentValue = "" Then
                                            currentValue = 0
                                        Else
                                            currentValue = CInt(frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text) + 2000
                                        End If
                                        frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text = FormatCurrency(currentValue, 0)
                                        For Each myPlayer As Player In Player2List
                                            myPlayer.total += 2000
                                        Next
                                        houseMinimumMet = False
                                    End If
                                End If
                            ElseIf currentPlayer = 3 Then
                                If teams = False Then
                                    If player3Score > 1000 Then
                                        For Each myPlayer As Player In Player3List
                                            myPlayer.total += player3Score
                                        Next
                                        houseMinimumMet = True
                                    Else
                                        Dim currentValue = frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text
                                        If currentValue = "" Then
                                            currentValue = 0
                                        Else
                                            currentValue = CInt(frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text) + 1000
                                        End If
                                        frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text = FormatCurrency(currentValue, 0)
                                        For Each myPlayer As Player In Player3List
                                            myPlayer.total += 1000
                                        Next
                                        houseMinimumMet = False
                                    End If
                                Else
                                    If player3Score > 2000 Then
                                        For Each myPlayer As Player In Player3List
                                            myPlayer.total += player3Score
                                        Next
                                        houseMinimumMet = True
                                    Else
                                        Dim currentValue = frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text
                                        If currentValue = "" Then
                                            currentValue = 0
                                        Else
                                            currentValue = CInt(frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text) + 2000
                                        End If
                                        frmScore.pnlScore.Controls("lblPlayer" & currentPlayer).Text = FormatCurrency(currentValue, 0)
                                        For Each myPlayer As Player In Player3List
                                            myPlayer.total += 2000
                                        Next
                                        houseMinimumMet = False
                                    End If
                                End If
                            End If
                        End If
                        Dim playDisapp = True
                        If round = PuzzleType.TU1 Or round = PuzzleType.TU2 Or round = PuzzleType.TU3 Then
                            If tossUpLetterControlList.Count = 0 Or allRungIn = True Then
                                'My.Computer.Audio.Play(My.Resources.double_buzz, AudioPlayMode.Background)
                                'resetPuzzle()
                                'reEnableLetters()
                            Else
                                If tossUpSolved = True Then
                                    My.Computer.Audio.Play(My.Resources.toss_up_solved, AudioPlayMode.WaitToComplete)
                                    playDisapp = False
                                End If
                                resetPuzzle()
                                reEnableLetters()
                            End If
                        ElseIf round = PuzzleType.BR Then
                            If bonusSolved = False Then
                                'frmScore.BonusCardEnvelope1.Show()
                                My.Computer.Audio.Play(My.Resources.music_bonus_lose_vamp, AudioPlayMode.Background)
                                bonusPuzzleRevealed = True
                                frmPuzzleBoard.wheelTilt.Enabled = False
                            Else
                                My.Computer.Audio.Play(My.Resources.music_bonus_win_vamp_new, AudioPlayMode.Background)
                                If virtualHost = True Then
                                    SAPI.Speak("Congratulations on solving the bonus round! " & CType(frmScore.Controls("NameTag" & currentPlayer), NameTag).lblName.Text & " Here's what you won.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                                End If
                                resetPuzzle()
                                reEnableLetters()
                                'frmScore.BonusCardEnvelope1.Show()
                                bonusPuzzleRevealed = True
                                frmPuzzleBoard.wheelTilt.Enabled = False
                            End If
                        ElseIf numberOfTurns = 0 Then
                            My.Computer.Audio.Play(My.Resources.bankrupt, AudioPlayMode.WaitToComplete)
                            frmAudio.playAudDisapp(True)
                            My.Computer.Audio.Play(My.Resources.double_buzz, AudioPlayMode.Background)
                            'numberOfTurns = 0
                            'frmScore.lblNumberOfTurns.Text = 0
                            If virtualHost = True Then
                                SAPI.Speak("Here is the puzzle solution.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                            End If
                            revealed = True
                            reEnableLetters()
                            'frmPuzzleBoard.tmrCheckTurns.Start()
                            Exit Sub
                        Else
                            frmAudio.playAudClap(True)
                            My.Computer.Audio.Play(My.Resources.puzzle_solved_new, AudioPlayMode.WaitToComplete)
                            playDisapp = False
                            resetPuzzle()
                            reEnableLetters()
                            currentPlayer = GetRandomPlayer(1, numberOfPlayers + 1)
                        End If
                        If currentPlayer = 1 Then
                            currentPlayerObject = Player1List
                        ElseIf currentPlayer = 2 Then
                            currentPlayerObject = Player2List
                        ElseIf currentPlayer = 3 Then
                            currentPlayerObject = Player3List
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
                                checkVowelRunning = False
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
                                If season >= 18 Then
                                    If highestRoundString <> "R3" Then
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
                                        checkVowelRunning = False
                                        frmPuzzleBoard.btnRedRingIn.Enabled = False
                                        frmPuzzleBoard.btnYellowRingIn.Enabled = False
                                        frmPuzzleBoard.btnBlueRingIn.Enabled = False
                                    Else
                                        checkBonusRoundWinner()
                                    End If
                                Else
                                    If highestRoundString <> "R3" Then
                                        tossUpLetterControlList.Clear()
                                        puzzleSolved = False
                                        frmPuzzleBoard.tmrTossUpRingIn.Stop()
                                        'frmPuzzleBoard.btnRedRingIn.Hide()
                                        'frmPuzzleBoard.btnYellowRingIn.Hide()
                                        'frmPuzzleBoard.btnBlueRingIn.Hide()
                                        round = PuzzleType.R4
                                        wheelLoad(PuzzleType.R4)
                                        loadPuzzle(PuzzleType.R4, puzzleMode, False)
                                        frmScore.lblPlayer1Total.Text = FormatCurrency(Player1List(0).total, 0)
                                        frmScore.lblPlayer2Total.Text = FormatCurrency(Player2List(0).total, 0)
                                        frmScore.lblPlayer3Total.Text = FormatCurrency(Player3List(0).total, 0)
                                        tossUpStarted = True
                                        frmScore.usedLetterBoard.Enabled = True
                                        frmPuzzleBoard.wheelTilt.Enabled = True
                                        frmScore.tmrCheckVowels.Start()
                                    Else
                                        checkBonusRoundWinner()
                                    End If
                                End If

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
                                If Player1List.Count > 0 Then
                                    frmScore.lblPlayer1Total.Text = FormatCurrency(Player1List(0).total, 0)
                                End If
                                If Player2List.Count > 0 Then
                                    frmScore.lblPlayer2Total.Text = FormatCurrency(Player2List(0).total, 0)
                                End If
                                If Player3List.Count > 0 Then
                                    frmScore.lblPlayer3Total.Text = FormatCurrency(Player3List(0).total, 0)
                                End If
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
                        'puzzleString = ""
                        If quickGame = False Then
                                saveToDB()
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
                            reEnableLetters()
                        ElseIf round = PuzzleType.BR Then
                            My.Computer.Audio.Play(My.Resources.music_bonus_win_vamp_new, AudioPlayMode.BackgroundLoop)
                            frmPuzzleBoard.wheelTilt.Enabled = False
                            resetPuzzle()
                            reEnableLetters()
                        Else
                            My.Computer.Audio.Play(My.Resources.puzzle_solved_new, AudioPlayMode.WaitToComplete)
                            resetPuzzle()
                            reEnableLetters()
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
                        SAPI.Speak("And the category for our third puzzle of the night is..." & category & " That sound means it's also our Prize Puzzle round." & " , " & CType(frmScore.Controls("NameTag" & currentPlayer), NameTag).lblName.Text & ", go ahead and spin it.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
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
                    SAPI.Speak("And the category for our fourth round of the night is..." & category)
                    If finalSpin = False And finalSpinQueued = False Then
                        SAPI.Speak(CType(frmScore.Controls("NameTag" & currentPlayer), NameTag).lblName.Text & ", spin that wheel.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                    End If
                End If
            ElseIf round = PuzzleType.R5 Then
                If virtualHost = True Then
                    SAPI.Speak("We have time for another round. The category for our next round is..." & category)
                    If finalSpin = False And finalSpinQueued = False Then
                        SAPI.Speak(CType(frmScore.Controls("NameTag" & currentPlayer), NameTag).lblName.Text & ", it's your turn.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                    End If
                End If
            ElseIf round = PuzzleType.R6 Then
                If virtualHost = True Then
                    SAPI.Speak("We are blowing through these puzzles. The category for our next round is..." & category)
                    If finalSpin = False And finalSpinQueued = False Then
                        SAPI.Speak(CType(frmScore.Controls("NameTag" & currentPlayer), NameTag).lblName.Text & ", it's your turn to spin.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                    End If
                End If
            ElseIf round = PuzzleType.R7 Then
                If virtualHost = True Then
                    SAPI.Speak("The category for our next round is..." & category)
                    If finalSpin = False And finalSpinQueued = False Then
                        SAPI.Speak(CType(frmScore.Controls("NameTag" & currentPlayer), NameTag).lblName.Text & ", it's your turn to spin.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                    End If
                End If
            ElseIf round = PuzzleType.R8 Then
                If virtualHost = True Then
                    SAPI.Speak("The category for our next round is..." & category)
                    If finalSpin = False And finalSpinQueued = False Then
                        SAPI.Speak(CType(frmScore.Controls("NameTag" & currentPlayer), NameTag).lblName.Text & ", it's your turn to spin.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                    End If
                End If
            ElseIf round = PuzzleType.R9 Then
                If virtualHost = True Then
                    SAPI.Speak("The category for our next round is..." & category)
                    If finalSpin = False And finalSpinQueued = False Then
                        SAPI.Speak(CType(frmScore.Controls("NameTag" & currentPlayer), NameTag).lblName.Text & ", it's your turn to spin.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                    End If
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
        Dim player1Total As Integer
        Dim player2Total As Integer
        Dim player3Total As Integer
        If Player1List.Count > 0 Then
            player1Total = Player1List(0).total
            If CInt(Player1List(0).total) = 0 Then
                For Each myPlayer In Player1List
                    myPlayer.total += 1000
                Next
            End If
        Else
            player1Total = 0
        End If
        If Player2List.Count > 0 Then
            player2Total = Player2List(0).total
            If CInt(Player2List(0).total) = 0 Then
                For Each myPlayer In Player2List
                    myPlayer.total += 1000
                Next
            End If
        Else
            player2Total = 0
        End If
        If Player3List.Count > 0 Then
            player3Total = Player3List(0).total
            If CInt(Player3List(0).total) = 0 Then
                For Each myPlayer In Player3List
                    myPlayer.total += 1000
                Next
            End If
        Else
            player3Total = 0
        End If

        If player1Total > player2Total And player1Total > player3Total Then
            currentPlayer = 1
            bonusRoundPlayer = Player1List
            checkBonusRound()
        ElseIf player2Total > player1Total And player2Total > player3Total Then
            currentPlayer = 2
            bonusRoundPlayer = Player2List
            checkBonusRound()
        ElseIf player3Total > player1Total And player3Total > player2Total Then
            currentPlayer = 3
            bonusRoundPlayer = Player3List
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
            checkVowelRunning = False
        End If
    End Sub
    Public Shared Sub checkBonusRound()
        frmScore.lblPlayer1.Text = ""
        frmScore.lblPlayer2.Text = ""
        frmScore.lblPlayer3.Text = ""
        loadBonusCategories(puzzleMode)
        If puzzleMode = wheelMode.Disney Or puzzleMode = wheelMode.Random Then
            For i As Integer = 0 To categoryList.Count - 1
                CType(frmScore.flpBonusCategories.Controls("CategoryStrip" & (i + 1)), CategoryStrip).lblCategory.Text = categoryList(i).category
            Next
        ElseIf puzzleMode = wheelMode.Classic Then
            For i As Integer = 0 To bonusCategoriesList.Count - 1
                CType(frmScore.flpBonusCategories.Controls("CategoryStrip" & (i + 1)), CategoryStrip).lblCategory.Text = bonusCategoriesList(i)
            Next
        ElseIf puzzleMode = wheelMode.Daily Or puzzleMode = wheelMode.Compendium Then
            For Each puzzleListItem As List(Of String) In dailyPuzzleList
                If puzzleListItem(0) = "BR" Then
                    category = puzzleListItem(1)
                    puzzle = puzzleListItem(2)
                    Exit For
                End If
            Next
        End If
        If puzzleMode <> wheelMode.Daily And puzzleMode <> wheelMode.Compendium Then
            frmScore.flpBonusCategories.Show()
        End If
        frmScore.lblNumberOfTurns.Hide()
        frmPuzzleBoard.btnSolve.Enabled = False
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
        checkVowelRunning = False
        frmScore.tmrFinalSpin.Stop()
        finalSpin = False
        finalSpinSpun = False
        frmScore.usedLetterBoard.Enabled = False
        frmScore.lblCurrentValue.Hide()
        frmScore.lblControllerSpinResult.Hide()
        frmPuzzleBoard.btnSolve.Enabled = False
        frmPuzzleBoard.PuzzleBoard1.Enabled = False
        If virtualHost = True Then
            If puzzleMode = wheelMode.Classic Or puzzleMode = wheelMode.Disney Or puzzleMode = wheelMode.Random Then
                SAPI.Speak("Congratulations, " & CType(frmScore.Controls("NameTag" & currentPlayer), NameTag).lblName.Text & " You're the big winner. You'll be moving on to the bonus round. You can pick from three categories tonight.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
            Else
                SAPI.Speak("Congratulations, " & CType(frmScore.Controls("NameTag" & currentPlayer), NameTag).lblName.Text & " You're the big winner. You'll be moving on to the bonus round.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
            End If
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
        Dim connPuzzle As SqlConnection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" & Application.StartupPath & "\WheelPuzzles.mdf;Integrated Security=True")
        Dim strSQL As String
        strSQL = "Update GAMES Set PackName = @PackName, VirtualHost = @VirtualHost, TypeToSolve = @TypeToSolve, Round = @RoundNumber, PuzzleID = @Puzzle, PuzzleString = @PuzzleString, Teams = @Teams, Final = @Final, CurrentPlayer = @CurrentPlayer, finalSpinTime = @finalSpinTime WHERE Id = @GameId"
        Dim cmd As SqlCommand
        Dim puzzleParam As SqlParameter = New SqlParameter("@Puzzle", puzzleID)
        Dim puzzleStringParam As SqlParameter = New SqlParameter("@PuzzleString", puzzleString)
        Dim finalSpinParam As SqlParameter = New SqlParameter("@finalSpinTime", timeLeft)
        Dim finalParam As SqlParameter
        If round = PuzzleType.BR Then
            finalParam = New SqlParameter("@Final", 1)
        Else
            finalParam = New SqlParameter("@Final", 0)
        End If
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
        Dim currentPlayerParam As SqlParameter = New SqlParameter("@CurrentPlayer", currentPlayer)
        Dim roundNumberParam As SqlParameter = New SqlParameter("@RoundNumber", round.ToString())
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
        cmd.Parameters.Add(puzzleStringParam)
        cmd.Parameters.Add(currentPlayerParam)
        cmd.Parameters.Add(gameIDParam)
        cmd.Parameters.Add(finalParam)
        cmd.Parameters.Add(finalSpinParam)
        cmd.CommandType = CommandType.Text
        cmd.ExecuteNonQuery()
        'Dim gameID = Integer.Parse(cmd.ExecuteScalar())
        connPuzzle.Close()
        If Player1List.Count > 0 Then
            For Each myPlayer As Player In Player1List
                myPlayer.savePlayer()
            Next
        End If
        If Player2List.Count > 0 Then
            For Each myPlayer As Player In Player2List
                myPlayer.savePlayer()
            Next
        End If
        If Player3List.Count > 0 Then
            For Each myPlayer As Player In Player3List
                myPlayer.savePlayer()
            Next
        End If
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
        If round <> PuzzleType.BR Then
            My.Computer.Audio.Play(My.Resources.toss_up_new, AudioPlayMode.BackgroundLoop)
        End If
        'Dim letterInTossUp As Integer = 1
        If tossUpLetters.Count > 0 Then
            tossUpLetters.Clear()
        End If
        If tossUpLetterControlList.Count = 0 Then
            For Each item As Control In frmPuzzleBoard.PuzzleBoard1.Controls
                'If letterControl.GetType() Is GetType(PuzzleBoardLetter) Then
                '    If CType(letterControl, PuzzleBoardLetter).letterBehind <> "" Then
                If item.Visible = True And checkForSymbols(CType(item, PuzzleBoardLetter).letterBehind) = False And CType(item, PuzzleBoardLetter).letterBehind <> " " And CType(item, PuzzleBoardLetter).letterRevealed = False Then
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
        frmAudio.playAudDisapp(True)
        spinResult = 0
        previousValue = "Bankrupt"
        frmPuzzleBoard.logoExpress.Hide()
        spun = False
        My.Computer.Audio.Play(My.Resources.bankrupt, AudioPlayMode.Background)
        If virtualHost = True Then
            If expressStatus = False Then
                SAPI = CreateObject("SAPI.spvoice")
                SAPI.Speak("The bankrupt got you. Better luck next time.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
            Else
                SAPI.Speak("That is the end of the train ride.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
            End If
        End If
            If currentPlayer = 1 Then
            frmScore.lblPlayer1.Text = ""
            For Each myPlayer In Player1List
                myPlayer.addCardsOrWedges(Player.Wedges.Gift, False)
                myPlayer.addCardsOrWedges(Player.Wedges.HalfCar1, False)
                myPlayer.addCardsOrWedges(Player.Wedges.HalfCar2, False)
                myPlayer.addCardsOrWedges(Player.Wedges.Million, False)
                myPlayer.addCardsOrWedges(Player.Wedges.Mystery, False)
                myPlayer.addCardsOrWedges(Player.Wedges.Prize, False)
                myPlayer.addCardsOrWedges(Player.Wedges.Wild, False)
            Next
        ElseIf currentPlayer = 2 Then
            frmScore.lblPlayer2.Text = ""
            For Each myPlayer In Player2List
                myPlayer.addCardsOrWedges(Player.Wedges.Gift, False)
                myPlayer.addCardsOrWedges(Player.Wedges.HalfCar1, False)
                myPlayer.addCardsOrWedges(Player.Wedges.HalfCar2, False)
                myPlayer.addCardsOrWedges(Player.Wedges.Million, False)
                myPlayer.addCardsOrWedges(Player.Wedges.Mystery, False)
                myPlayer.addCardsOrWedges(Player.Wedges.Prize, False)
                myPlayer.addCardsOrWedges(Player.Wedges.Wild, False)
            Next
        ElseIf currentPlayer = 3 Then
                frmScore.lblPlayer3.Text = ""
            For Each myPlayer In Player3List
                myPlayer.addCardsOrWedges(Player.Wedges.Gift, False)
                myPlayer.addCardsOrWedges(Player.Wedges.HalfCar1, False)
                myPlayer.addCardsOrWedges(Player.Wedges.HalfCar2, False)
                myPlayer.addCardsOrWedges(Player.Wedges.Million, False)
                myPlayer.addCardsOrWedges(Player.Wedges.Mystery, False)
                myPlayer.addCardsOrWedges(Player.Wedges.Prize, False)
                myPlayer.addCardsOrWedges(Player.Wedges.Wild, False)
            Next
        End If
        LoseATurn()
    End Sub
#End Region
#Region "Lose a Turn"
    Public Shared Sub LoseATurn()
        If finalSpin = False Then
            frmAudio.playAudDisapp(True)
        End If
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
                currentPlayerObject = Player1List
            ElseIf currentPlayer = 1 Then
                currentPlayer = 2
                currentPlayerObject = Player2List
            ElseIf currentPlayer = 2 And numberOfPlayers = 3 Then
                currentPlayer = 3
                currentPlayerObject = Player3List
            End If
        ElseIf currentPlayer > 2 And numberOfPlayers <> 1 Then
            currentPlayer = 1
            currentPlayerObject = Player1List
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
            ElseIf numberOfPlayers = 1 And numberOfTurns > 1 And finalSpinTimesUp = False Then
                SAPI.Speak(CType(frmScore.Controls("NameTag" & currentPlayer), NameTag).lblName.Text & " You just lost a turn. You have " & numberOfTurns & " turns remaining")
            ElseIf numberOfPlayers = 1 And numberOfTurns = 1 And finalSpinTimesUp = False Then
                SAPI.Speak(CType(frmScore.Controls("NameTag" & currentPlayer), NameTag).lblName.Text & " You just lost a turn. You have " & numberOfTurns & " turn remaining")
            ElseIf numberOfPlayers = 1 And numberOfTurns = 0 Then
                SAPI.Speak(CType(frmScore.Controls("NameTag" & currentPlayer), NameTag).lblName.Text & " You are out of turns. I'm sorry this is the end of the round.")
            End If
        End If
    End Sub
#End Region
#Region "Reveal Number of Letters"
    Public Shared Function revealNumberOfLetters() As String
        frmPuzzleBoard.btnSolve.Enabled = False
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
            If finalSpin = False Then
                frmAudio.playAudClap(True)
            End If
            For Each item As KeyValuePair(Of String, Integer) In letterSortedList
                If item.Value = 1 Then
                    If virtualHost = True Then
                        Try
                            SAPI.Speak("There is one " & item.Key & ".", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                        Catch ex As Exception
                        End Try
                    End If
                    Return "There is one " & item.Key & "."
                ElseIf item.Value > 1 Then
                    If item.Key <> "U" Then
                        If virtualHost = True Then
                            Try
                                SAPI.Speak("There are " & item.Value & " " & item.Key & "'s.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                            Catch ex As Exception
                            End Try
                        End If
                        Return "There are " & item.Value & " " & item.Key & "'s."
                    ElseIf item.Key = "U" Then
                        If virtualHost = True Then
                            Try
                                SAPI.Speak("There are " & item.Value & " You's.", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync)
                            Catch ex As Exception
                            End Try
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
                frmAudio.playAudDisapp(True)
            End If
            If currentLetter <> "U" Then
                If virtualHost = True Then
                    Try
                        SAPI.Speak("There are no " & currentLetter & "'s.")
                    Catch ex As Exception
                    End Try
                End If
                Return "There are no " & currentLetter & "'s."
            ElseIf currentLetter = "U" Then
                If virtualHost = True Then
                    Try
                        SAPI.Speak("There are no You's.")
                    Catch ex As Exception
                    End Try
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
        Dim bonusWheel As New List(Of String) From {"36000", "36000", "Car", "36000", "36000", "45000", "36000", "Car", "36000", "36000", "Car", "36000", "36000", "40000", "36000", "Car", "36000", "36000", "36000", "100000", "36000", "Car", "50000", "Car"}
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
            wheelWedges.Add(34, "600")
            wheelWedges.Add(35, "600")
            wheelWedges.Add(36, "600")
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
            wheelWedges.Add(55, "650")
            wheelWedges.Add(56, "650")
            wheelWedges.Add(57, "650")
            wheelWedges.Add(58, "600")
            wheelWedges.Add(59, "600")
            wheelWedges.Add(60, "600")
            wheelWedges.Add(61, "700")
            wheelWedges.Add(62, "700")
            wheelWedges.Add(63, "700")
            wheelWedges.Add(64, "600")
            wheelWedges.Add(65, "600")
            wheelWedges.Add(66, "600")
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
            wheelWedges.Add(34, "600")
            wheelWedges.Add(35, "600")
            wheelWedges.Add(36, "600")
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
            wheelWedges.Add(55, "650")
            wheelWedges.Add(56, "650")
            wheelWedges.Add(57, "650")
            wheelWedges.Add(58, "Mystery 1")
            wheelWedges.Add(59, "Mystery 1")
            wheelWedges.Add(60, "Mystery 1")
            wheelWedges.Add(61, "700")
            wheelWedges.Add(62, "700")
            wheelWedges.Add(63, "700")
            wheelWedges.Add(64, "600")
            wheelWedges.Add(65, "600")
            wheelWedges.Add(66, "600")
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
            wheelWedges.Add(34, "600")
            wheelWedges.Add(35, "600")
            wheelWedges.Add(36, "600")
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
            wheelWedges.Add(55, "650")
            wheelWedges.Add(56, "650")
            wheelWedges.Add(57, "650")
            wheelWedges.Add(58, "600")
            wheelWedges.Add(59, "600")
            wheelWedges.Add(60, "600")
            wheelWedges.Add(61, "Express")
            wheelWedges.Add(62, "Express")
            wheelWedges.Add(63, "Express")
            wheelWedges.Add(64, "600")
            wheelWedges.Add(65, "600")
            wheelWedges.Add(66, "600")
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
                    If Player1List(0).getWedges(Player.Wedges.Million) Or Player2List(0).getWedges(Player.Wedges.Million) Or Player3List(0).getWedges(Player.Wedges.Million) Then
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
            wheelWedges.Add(34, "600")
            wheelWedges.Add(35, "600")
            wheelWedges.Add(36, "600")
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
            wheelWedges.Add(55, "650")
            wheelWedges.Add(56, "650")
            wheelWedges.Add(57, "650")
            wheelWedges.Add(58, "600")
            wheelWedges.Add(59, "600")
            wheelWedges.Add(60, "600")
            wheelWedges.Add(61, "700")
            wheelWedges.Add(62, "700")
            wheelWedges.Add(63, "700")
            wheelWedges.Add(64, "600")
            wheelWedges.Add(65, "600")
            wheelWedges.Add(66, "600")
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
#Region "Check If Two Letter Word Present in List"
    Private Shared Function checkTwoLetterWord(wordList As List(Of String)) As Boolean
        For Each word As String In wordList
            If word = wordList.First() Then
                Continue For
            End If
            If word.Trim().Length <= 2 Then
                Return True
            End If
        Next
        Return False
    End Function
#End Region
End Class
