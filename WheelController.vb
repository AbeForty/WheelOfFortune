Imports System.Data.SqlClient
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
    Public Shared letterControlTappedList As New List(Of Integer)
    Public Shared previousValue As String
    Public Shared player1Name As String = "PLAYER 1"
    Public Shared player2Name As String = "PLAYER 2"
    Public Shared player3Name As String = "PLAYER 3"
    Public Shared packName As String = "TEST"
    Public Shared startTime As Integer
    Public Shared finalSpin As Boolean = False
    Public Shared finalSpinQueued As Boolean = False
    Public Shared numberOfPlayers As Integer = 3
    Public Shared teams As Boolean = False
    Public Shared finalSpinSpun As Boolean = False
    Public Shared bonusSolved As Boolean = False
    Public Shared sameLetter As String
    Public Shared numberOfTurns As Integer = 10
    Public Shared crosswordStatus As Integer
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
    '#Region "Load Wheel Spin Video"
    '    Private Shared Sub loadWheel(round As PuzzleType)
    '        Dim aPath As String = Path.GetDirectoryName(Assembly.GetExecutingAssembly.GetModules()(0).FullyQualifiedName)
    '        Dim myStream As Stream
    '        myStream = Assembly.GetExecutingAssembly.GetManifestResourceStream("WheelSpin.mp4")
    '        Dim myFileStream As New FileStream("WheelSpinR1.mp4", FileMode.Create)
    '        Dim myFileBinary As New BinaryWriter(myFileStream)
    '        Try
    '            Dim myByte As Byte = myStream.ReadByte
    '            While Not myByte = -1
    '                myFileBinary.Write(myByte)
    '                myByte = myStream.ReadByte
    '            End While
    '        Catch ex As Exception
    '        Finally
    '            myFileStream.Close()
    '        End Try
    '        'If frmPuzzleBoard.round = PuzzleType.R1 Then
    '        'frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Path.Combine(aPath, "WheelSpinR1.mp4")

    '        'End If
    '    End Sub
    '#End Region
#Region "Load Puzzle"
    Public Shared Sub loadPuzzle(round As PuzzleType, preview As Boolean)
        For Each lettersControls As Control In frmPuzzleBoard.Controls
            If lettersControls.GetType() Is GetType(PuzzleBoardLetter) Then
                CType(lettersControls, PuzzleBoardLetter).Hide()
            End If
        Next
        Dim TheseAreYourWords As String()
        Dim myWords As New List(Of String)
        If preview = False Then
            Dim connPuzzle As SqlConnection
            connPuzzle = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" & Application.StartupPath & "\WheelPuzzles.mdf;Integrated Security=True")
            Dim strSQL
            roundType = round
            If round = PuzzleType.TU1 Then
                strSQL = "Select * From Puzzle WHERE Type = 0 and RoundNumber =1 and PackName = '" & packName & "'"
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelSpinR1.mp4"
                frmPuzzleBoard.wheelTilt.Image = My.Resources.WheelTiltedSmall
                frmPuzzleBoard.WheelSpinControl1.wheelCover.BackgroundImage = My.Resources.wheelCoverHD
                frmPuzzleBoard.WheelSpinControl1.resetWheel()
                frmPuzzleBoard.WheelSpinControl1.firstSpin = True
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.stop()
            ElseIf round = PuzzleType.TU2 Then
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelSpinR1.mp4"
                frmPuzzleBoard.wheelTilt.Image = My.Resources.WheelTiltedSmall
                frmPuzzleBoard.WheelSpinControl1.wheelCover.BackgroundImage = My.Resources.wheelCoverHD
                frmPuzzleBoard.WheelSpinControl1.resetWheel()
                frmPuzzleBoard.WheelSpinControl1.firstSpin = True
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.stop()
                strSQL = "Select * From Puzzle WHERE Type = 0 and RoundNumber =2 and PackName = '" & packName & "'"
            ElseIf round = PuzzleType.R1 Then
                strSQL = "Select * From Puzzle WHERE Type = 1 and RoundNumber =1 and PackName = '" & packName & "'"
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelSpinR1.mp4"
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.currentPosition = 1
                frmPuzzleBoard.wheelTilt.Image = My.Resources.WheelTiltedSmall
                frmPuzzleBoard.WheelSpinControl1.wheelCover.BackgroundImage = My.Resources.wheelCoverHD
                frmPuzzleBoard.WheelSpinControl1.resetWheel()
                frmPuzzleBoard.WheelSpinControl1.firstSpin = True
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.pause()
            ElseIf round = PuzzleType.R2 Then
                strSQL = "Select * From Puzzle WHERE Type = 1 and RoundNumber =2 and PackName = '" & packName & "'"
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelSpinR2.mp4"
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.currentPosition = 1
                frmPuzzleBoard.wheelTilt.Image = My.Resources.WheelTiltedSmallR2
                frmPuzzleBoard.WheelSpinControl1.wheelCover.BackgroundImage = My.Resources.wheelCoverHDR2
                frmPuzzleBoard.WheelSpinControl1.resetWheel()
                frmPuzzleBoard.WheelSpinControl1.firstSpin = True
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.pause()
            ElseIf round = PuzzleType.R3 Then
                strSQL = "Select * From Puzzle WHERE Type = 1 and RoundNumber =3 and PackName = '" & packName & "'"
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelSpinR3.mp4"
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.currentPosition = 1
                frmPuzzleBoard.wheelTilt.Image = My.Resources.WheelTiltedSmallR3
                frmPuzzleBoard.WheelSpinControl1.wheelCover.BackgroundImage = My.Resources.wheelCoverHDR3
                frmPuzzleBoard.WheelSpinControl1.resetWheel()
                frmPuzzleBoard.WheelSpinControl1.firstSpin = True
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.pause()
            ElseIf round = PuzzleType.TU3 Then
                strSQL = "Select * From Puzzle WHERE Type = 0 and RoundNumber =3 and PackName = '" & packName & "'"
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelSpinR4.mp4"
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.currentPosition = 1
                frmPuzzleBoard.wheelTilt.Image = My.Resources.WheelTiltedSmallR4
                frmPuzzleBoard.WheelSpinControl1.wheelCover.BackgroundImage = My.Resources.wheelCoverHDR4
                frmPuzzleBoard.WheelSpinControl1.resetWheel()
                frmPuzzleBoard.WheelSpinControl1.firstSpin = True
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.pause()
            ElseIf round = PuzzleType.R4 Then
                strSQL = "Select * From Puzzle WHERE Type = 1 and RoundNumber =4 and PackName = '" & packName & "'"
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelSpinR4.mp4"
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.currentPosition = 1
                frmPuzzleBoard.wheelTilt.Image = My.Resources.WheelTiltedSmallR4
                frmPuzzleBoard.WheelSpinControl1.wheelCover.BackgroundImage = My.Resources.wheelCoverHDR4
                frmPuzzleBoard.WheelSpinControl1.resetWheel()
                frmPuzzleBoard.WheelSpinControl1.firstSpin = True
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.pause()
            ElseIf round = PuzzleType.R5 Then
                strSQL = "Select * From Puzzle WHERE Type = 1 and RoundNumber =5 and PackName = '" & packName & "'"
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelSpinR4.mp4"
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.currentPosition = 1
                frmPuzzleBoard.wheelTilt.Image = My.Resources.WheelTiltedSmallR4
                frmPuzzleBoard.WheelSpinControl1.wheelCover.BackgroundImage = My.Resources.wheelCoverHDR4
                frmPuzzleBoard.WheelSpinControl1.resetWheel()
                frmPuzzleBoard.WheelSpinControl1.firstSpin = True
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.pause()
            ElseIf round = PuzzleType.R6 Then
                strSQL = "Select * From Puzzle WHERE Type = 1 and RoundNumber =6 and PackName = '" & packName & "'"
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelSpinR4.mp4"
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.currentPosition = 1
                frmPuzzleBoard.wheelTilt.Image = My.Resources.WheelTiltedSmallR4
                frmPuzzleBoard.WheelSpinControl1.wheelCover.BackgroundImage = My.Resources.wheelCoverHDR4
                frmPuzzleBoard.WheelSpinControl1.resetWheel()
                frmPuzzleBoard.WheelSpinControl1.firstSpin = True
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.pause()
            ElseIf round = PuzzleType.R7 Then
                strSQL = "Select * From Puzzle WHERE Type = 1 and RoundNumber =7 and PackName = '" & packName & "'"
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelSpinR4.mp4"
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.currentPosition = 1
                frmPuzzleBoard.wheelTilt.Image = My.Resources.WheelTiltedSmallR4
                frmPuzzleBoard.WheelSpinControl1.wheelCover.BackgroundImage = My.Resources.wheelCoverHDR4
                frmPuzzleBoard.WheelSpinControl1.resetWheel()
                frmPuzzleBoard.WheelSpinControl1.firstSpin = True
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.pause()
            ElseIf round = PuzzleType.R8 Then
                strSQL = "Select * From Puzzle WHERE Type = 1 and RoundNumber =8 and PackName = '" & packName & "'"
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelSpinR4.mp4"
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.currentPosition = 1
                frmPuzzleBoard.wheelTilt.Image = My.Resources.WheelTiltedSmallR4
                frmPuzzleBoard.WheelSpinControl1.wheelCover.BackgroundImage = My.Resources.wheelCoverHDR4
                frmPuzzleBoard.WheelSpinControl1.resetWheel()
                frmPuzzleBoard.WheelSpinControl1.firstSpin = True
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.pause()
            ElseIf round = PuzzleType.R9 Then
                strSQL = "Select * From Puzzle WHERE Type = 1 and RoundNumber =9 and PackName = '" & packName & "'"
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelSpinR4.mp4"
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.currentPosition = 1
                frmPuzzleBoard.wheelTilt.Image = My.Resources.WheelTiltedSmallR4
                frmPuzzleBoard.WheelSpinControl1.wheelCover.BackgroundImage = My.Resources.wheelCoverHDR4
                frmPuzzleBoard.WheelSpinControl1.resetWheel()
                frmPuzzleBoard.WheelSpinControl1.firstSpin = True
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.pause()
            ElseIf round = PuzzleType.TBTU Then
                strSQL = "Select * From Puzzle WHERE Type = 0 and RoundNumber = 4 and PackName = '" & packName & "'"
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.URL = Application.StartupPath & "\Resources" & "\WheelSpinR4.mp4"
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.currentPosition = 1
                frmPuzzleBoard.wheelTilt.Image = My.Resources.WheelTiltedSmallR4
                frmPuzzleBoard.WheelSpinControl1.wheelCover.BackgroundImage = My.Resources.wheelCoverHDR4
                frmPuzzleBoard.WheelSpinControl1.resetWheel()
                frmPuzzleBoard.WheelSpinControl1.firstSpin = True
                frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.pause()
            ElseIf round = PuzzleType.BR Then
                strSQL = "Select * From Puzzle WHERE Type = 2 and RoundNumber =1 and PackName = '" & packName & "'"
            End If
            Dim drProduct As SqlDataReader
            Dim cmdProduct As SqlCommand
            connPuzzle.Open()
            cmdProduct = New SqlCommand(strSQL, connPuzzle)
            drProduct = cmdProduct.ExecuteReader(CommandBehavior.CloseConnection)
            If drProduct.Read() Then
                category = Trim(drProduct("Category"))
                puzzle = Trim(drProduct("Puzzle"))
                puzzleTypeInt = CInt(Trim(drProduct("Type")))
                crosswordStatus = CInt(Trim(drProduct("Crossword")))
            End If
        ElseIf preview = True Then
            If frmCustomizer.cboCategory.SelectedItem <> "CROSSWORD" Then
                category = frmCustomizer.cboCategory.SelectedItem.ToString.ToUpper
            Else
                category = frmCustomizer.txtCrosswordClue.Text.ToUpper
            End If
            puzzle = frmCustomizer.txtPuzzle.Text.ToUpper
            End If
        TheseAreYourWords = puzzle.Split(" ")
        For Each item As String In TheseAreYourWords
            If Not item = TheseAreYourWords.Last Then
                myWords.Add(item & " ")
            Else
                myWords.Add(item)
            End If
        Next
        If category = "SAME LETTER" Then
            sameLetter = puzzle.Substring(0, 1)
        End If
        frmScore.puzzleString = puzzle
        Dim numberOfLengths As Integer = 0
        Dim numberOfLengths2 As Integer = 0
        Dim numberOfLengths3 As Integer = 0
        Dim numberOfLengths4 As Integer = 0
        Dim row1 As Boolean = False
        Dim row2 As Boolean = False
        Dim row3 As Boolean = False
        Dim row4 As Boolean = False
        Dim wordLengths As New List(Of Integer)
        If crosswordStatus = 0 Then
            If puzzle.Length < 14 Then
                For Each word As String In myWords
                    If word.Replace(" ", "").Length <= 8 - numberOfLengths And row2 = False Then
                        row1 = True
                        For myLetter = 0 To word.Length - 1
                            If word.Chars(myLetter).ToString() <> " " Then
                                CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & (numberOfLengths + 14)), PuzzleBoardLetter).Show()
                                CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & (numberOfLengths + 14)), PuzzleBoardLetter).letterBehind = word.Chars(myLetter).ToString()
                                frmPuzzleBoard.ListBox1.Items.Add(word.Chars(myLetter).ToString())
                                frmPuzzleBoard.ListBox2.Items.Add("PuzzleBoardLetter" & (numberOfLengths + 14))
                                If word.Chars(myLetter).ToString() = "'" Or word.Chars(myLetter).ToString() = "?" Or word.Chars(myLetter).ToString() = "." Or word.Chars(myLetter).ToString() = "!" Or word.Chars(myLetter).ToString() = "-" Or word.Chars(myLetter).ToString() = "/" Or word.Chars(myLetter).ToString() = ":" Or word.Chars(myLetter).ToString() = "\" Or word.Chars(myLetter).ToString() = "&" Then
                                    CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & (numberOfLengths + 14)), PuzzleBoardLetter).revealLetter()
                                End If
                                numberOfLengths += 1
                                frmPuzzleBoard.ListBox3.Items.Add(numberOfLengths)
                            ElseIf word.Chars(myLetter).ToString() = " " Then
                                CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & ((numberOfLengths + 14))), PuzzleBoardLetter).Hide()
                                numberOfLengths += 1
                            End If
                        Next
                    ElseIf (word.Replace(" ", "").Length >= 8 - numberOfLengths And row1 = True And row2 = False) Or (word.Replace(" ", "").Length <= 13 - numberOfLengths2 And row2 = True And row3 = False) Then
                        row2 = True
                        For myLetter = 0 To word.Length - 1
                            If word.Chars(myLetter).ToString() <> " " Then
                                CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & ((27 + (numberOfLengths2 + 1)))), PuzzleBoardLetter).Show()
                                CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & ((27 + (numberOfLengths2 + 1)))), PuzzleBoardLetter).letterBehind = word.Chars(myLetter).ToString()
                                frmPuzzleBoard.ListBox1.Items.Add(word.Chars(myLetter).ToString())
                                frmPuzzleBoard.ListBox2.Items.Add("PuzzleBoardLetter" & (27 + (numberOfLengths2 + 1)))
                                If word.Chars(myLetter).ToString() = "'" Or word.Chars(myLetter).ToString() = "?" Or word.Chars(myLetter).ToString() = "." Or word.Chars(myLetter).ToString() = "!" Or word.Chars(myLetter).ToString() = "-" Or word.Chars(myLetter).ToString() = "/" Or word.Chars(myLetter).ToString() = ":" Or word.Chars(myLetter).ToString() = "\" Or word.Chars(myLetter).ToString() = "&" Then
                                    CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & ((27 + (numberOfLengths2 + 1)))), PuzzleBoardLetter).revealLetter()
                                End If
                                numberOfLengths2 += 1
                                frmPuzzleBoard.ListBox3.Items.Add(numberOfLengths2)
                            ElseIf word.Chars(myLetter).ToString() = " " Then
                                CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & ((27 + (numberOfLengths2 + 1)))), PuzzleBoardLetter).Hide()
                                numberOfLengths2 += 1
                            End If
                        Next
                    End If
                Next
            ElseIf puzzle.Length <= 28 Then
                For Each word As String In myWords
                    If word.Replace(" ", "").Length <= 12 - numberOfLengths And row2 = False Then
                        row1 = True
                        For myLetter = 0 To word.Length - 1
                            If word.Chars(myLetter).ToString() <> " " Then
                                CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & (numberOfLengths + 14)), PuzzleBoardLetter).Show()
                                CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & (numberOfLengths + 14)), PuzzleBoardLetter).letterBehind = word.Chars(myLetter).ToString()
                                frmPuzzleBoard.ListBox1.Items.Add(word.Chars(myLetter).ToString())
                                frmPuzzleBoard.ListBox2.Items.Add("PuzzleBoardLetter" & (numberOfLengths + 14))
                                If word.Chars(myLetter).ToString() = "'" Or word.Chars(myLetter).ToString() = "?" Or word.Chars(myLetter).ToString() = "." Or word.Chars(myLetter).ToString() = "!" Or word.Chars(myLetter).ToString() = "-" Or word.Chars(myLetter).ToString() = "/" Or word.Chars(myLetter).ToString() = ":" Or word.Chars(myLetter).ToString() = "\" Or word.Chars(myLetter).ToString() = "&" Then
                                    CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & (numberOfLengths + 14)), PuzzleBoardLetter).revealLetter()
                                End If
                                numberOfLengths += 1
                                frmPuzzleBoard.ListBox3.Items.Add(numberOfLengths)
                            ElseIf word.Chars(myLetter).ToString() = " " Then
                                CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & ((numberOfLengths + 14))), PuzzleBoardLetter).Hide()
                                numberOfLengths += 1
                            End If
                        Next
                    ElseIf (word.Replace(" ", "").Length >= 12 - numberOfLengths And row1 = True And row2 = False) Or (word.Replace(" ", "").Length <= 13 - numberOfLengths2 And row2 = True And row3 = False) Then
                        row2 = True
                        For myLetter = 0 To word.Length - 1
                            If word.Chars(myLetter).ToString() <> " " Then
                                CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & ((27 + (numberOfLengths2 + 1)))), PuzzleBoardLetter).Show()
                                CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & ((27 + (numberOfLengths2 + 1)))), PuzzleBoardLetter).letterBehind = word.Chars(myLetter).ToString()
                                frmPuzzleBoard.ListBox1.Items.Add(word.Chars(myLetter).ToString())
                                frmPuzzleBoard.ListBox2.Items.Add("PuzzleBoardLetter" & (27 + (numberOfLengths2 + 1)))
                                If word.Chars(myLetter).ToString() = "'" Or word.Chars(myLetter).ToString() = "?" Or word.Chars(myLetter).ToString() = "." Or word.Chars(myLetter).ToString() = "!" Or word.Chars(myLetter).ToString() = "-" Or word.Chars(myLetter).ToString() = "/" Or word.Chars(myLetter).ToString() = ":" Or word.Chars(myLetter).ToString() = "\" Or word.Chars(myLetter).ToString() = "&" Then
                                    CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & ((27 + (numberOfLengths2 + 1)))), PuzzleBoardLetter).revealLetter()
                                End If
                                numberOfLengths2 += 1
                                frmPuzzleBoard.ListBox3.Items.Add(numberOfLengths2)
                            ElseIf word.Chars(myLetter).ToString() = " " Then
                                CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & ((27 + (numberOfLengths2 + 1)))), PuzzleBoardLetter).Hide()
                                numberOfLengths2 += 1
                            End If
                        Next
                    ElseIf word.Replace(" ", "").Length >= 12 - numberOfLengths2 And row2 = True And row3 = False Or (word.Replace(" ", "").Length <= 13 - numberOfLengths3 And row3 = True And row4 = False) Then
                        row3 = True
                        For myLetter = 0 To word.Length - 1
                            If word.Chars(myLetter).ToString() <> " " Then
                                CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & ((40 + (numberOfLengths3 + 1)))), PuzzleBoardLetter).Show()
                                CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & ((40 + (numberOfLengths3 + 1)))), PuzzleBoardLetter).letterBehind = word.Chars(myLetter).ToString()
                                frmPuzzleBoard.ListBox1.Items.Add(word.Chars(myLetter).ToString())
                                frmPuzzleBoard.ListBox2.Items.Add("PuzzleBoardLetter" & (40 + (numberOfLengths3 + 1)))
                                If word.Chars(myLetter).ToString() = "'" Or word.Chars(myLetter).ToString() = "?" Or word.Chars(myLetter).ToString() = "." Or word.Chars(myLetter).ToString() = "!" Or word.Chars(myLetter).ToString() = "-" Or word.Chars(myLetter).ToString() = "/" Or word.Chars(myLetter).ToString() = ":" Or word.Chars(myLetter).ToString() = "\" Or word.Chars(myLetter).ToString() = "&" Then
                                    CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & ((40 + (numberOfLengths3 + 1)))), PuzzleBoardLetter).revealLetter()
                                End If
                                numberOfLengths3 += 1
                                frmPuzzleBoard.ListBox3.Items.Add(numberOfLengths3)
                            ElseIf word.Chars(myLetter).ToString() = " " Then
                                CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & ((40 + (numberOfLengths3 + 1)))), PuzzleBoardLetter).Hide()
                                numberOfLengths3 += 1
                            End If
                        Next
                        'ElseIf word.Replace(" ", "").Length >= 13 - numberOfLengths3 And row3 = True And row4 = False Or (word.Replace(" ", "").Length <= 13 - numberOfLengths4 And row4 = True) Then
                        '    row4 = True
                        '    For myLetter = 0 To word.Length - 1
                        '        If word.Chars(myLetter).ToString() <> " " Then
                        '            CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & ((40 + (numberOfLengths4 + 1)))), PuzzleBoardLetter).Show()
                        '            CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & ((40 + (numberOfLengths4 + 1)))), PuzzleBoardLetter).letterBehind = word.Chars(myLetter).ToString()
                        '            'CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & ((40 + (numberOfLengths4 + 1)))), PuzzleBoardLetter).revealLetter()
                        '            frmPuzzleBoard.ListBox1.Items.Add(word.Chars(myLetter).ToString())
                        '            frmPuzzleBoard.ListBox2.Items.Add("PuzzleBoardLetter" & (numberOfLengths4 + (41 - (12 - numberOfLengths4))))
                        '            If word.Chars(myLetter).ToString() = "'" Or word.Chars(myLetter).ToString() = "?" Or word.Chars(myLetter).ToString() = "." Or word.Chars(myLetter).ToString() = "!" Or word.Chars(myLetter).ToString() = "-" Or word.Chars(myLetter).ToString() = "/" Or word.Chars(myLetter).ToString() = ":" Or word.Chars(myLetter).ToString() = "\" Or word.Chars(myLetter).ToString() = "&" Then
                        '                CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & ((40 + (numberOfLengths4 + 1)))), PuzzleBoardLetter).revealLetter()
                        '            End If
                        '            numberOfLengths4 += 1
                        '            frmPuzzleBoard.ListBox3.Items.Add(numberOfLengths4)
                        '        ElseIf word.Chars(myLetter).ToString() = " " Then
                        '            CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & ((40 + (numberOfLengths4 + 1)))), PuzzleBoardLetter).Hide()
                        '            numberOfLengths4 += 1
                        '        End If
                        '    Next
                        'For myLetter = 0 To word.Length - 1
                        '    If word.Chars(myLetter).ToString() <> " " Then
                        '        CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & (numberOfLengths4 + (41 - (12 - numberOfLengths3)))), PuzzleBoardLetter).Show()
                        '        CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & (numberOfLengths4 + (41 - (12 - numberOfLengths3)))), PuzzleBoardLetter).letterBehind = word.Chars(myLetter).ToString()
                        '        CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & (numberOfLengths4 + (41 - (12 - numberOfLengths3)))), PuzzleBoardLetter).revealLetter()
                        '        frmPuzzleBoard.ListBox1.Items.Add(word.Chars(myLetter).ToString())
                        '        frmPuzzleBoard.ListBox2.Items.Add("PuzzleBoardLetter" & (numberOfLengths4 + (41 - (12 - numberOfLengths3))))
                        '        numberOfLengths4 += 1
                        '        frmPuzzleBoard.ListBox3.Items.Add(numberOfLengths4)
                        '    ElseIf word.Chars(myLetter).ToString() = " " Then
                        '        CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & ((40 + (numberOfLengths4 + 1)))), PuzzleBoardLetter).Hide()
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
                                CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & (numberOfLengths + 1)), PuzzleBoardLetter).Show()
                                CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & (numberOfLengths + 1)), PuzzleBoardLetter).letterBehind = word.Chars(myLetter).ToString()
                                frmPuzzleBoard.ListBox1.Items.Add(word.Chars(myLetter).ToString())
                                frmPuzzleBoard.ListBox2.Items.Add("PuzzleBoardLetter" & (numberOfLengths + 1))
                                If word.Chars(myLetter).ToString() = "'" Or word.Chars(myLetter).ToString() = "?" Or word.Chars(myLetter).ToString() = "." Or word.Chars(myLetter).ToString() = "!" Or word.Chars(myLetter).ToString() = "-" Or word.Chars(myLetter).ToString() = "/" Or word.Chars(myLetter).ToString() = ":" Or word.Chars(myLetter).ToString() = "\" Or word.Chars(myLetter).ToString() = "&" Then
                                    CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & (numberOfLengths + 1)), PuzzleBoardLetter).revealLetter()
                                End If
                                numberOfLengths += 1
                                frmPuzzleBoard.ListBox3.Items.Add(numberOfLengths)
                            ElseIf word.Chars(myLetter).ToString() = " " Then
                                CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & ((numberOfLengths + 1))), PuzzleBoardLetter).Hide()
                                numberOfLengths += 1
                            End If
                        Next
                    ElseIf (word.Replace(" ", "").Length > 12 - numberOfLengths And row1 = True And row2 = False) Or (word.Replace(" ", "").Length <= 13 - numberOfLengths2 And row2 = True And row3 = False) Then
                        row2 = True
                        For myLetter = 0 To word.Length - 1
                            If word.Chars(myLetter).ToString() <> " " Then
                                CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & ((13 + (numberOfLengths2 + 1)))), PuzzleBoardLetter).Show()
                                CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & ((13 + (numberOfLengths2 + 1)))), PuzzleBoardLetter).letterBehind = word.Chars(myLetter).ToString()
                                frmPuzzleBoard.ListBox1.Items.Add(word.Chars(myLetter).ToString())
                                frmPuzzleBoard.ListBox2.Items.Add("PuzzleBoardLetter" & (numberOfLengths2 + (14 - (12 - numberOfLengths))))
                                If word.Chars(myLetter).ToString() = "'" Or word.Chars(myLetter).ToString() = "?" Or word.Chars(myLetter).ToString() = "." Or word.Chars(myLetter).ToString() = "!" Or word.Chars(myLetter).ToString() = "-" Or word.Chars(myLetter).ToString() = "/" Or word.Chars(myLetter).ToString() = ":" Or word.Chars(myLetter).ToString() = "\" Or word.Chars(myLetter).ToString() = "&" Then
                                    CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & ((13 + (numberOfLengths2 + 1)))), PuzzleBoardLetter).revealLetter()
                                End If
                                numberOfLengths2 += 1
                                frmPuzzleBoard.ListBox3.Items.Add(numberOfLengths2)
                            ElseIf word.Chars(myLetter).ToString() = " " Then
                                CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & ((13 + (numberOfLengths2 + 1)))), PuzzleBoardLetter).Hide()
                                numberOfLengths2 += 1
                            End If
                        Next
                    ElseIf word.Replace(" ", "").Length > 13 - numberOfLengths2 And row2 = True And row3 = False Or (word.Replace(" ", "").Length <= 13 - numberOfLengths3 And row3 = True And row4 = False) Then
                        row3 = True
                        For myLetter = 0 To word.Length - 1
                            If word.Chars(myLetter).ToString() <> " " Then
                                CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & ((27 + (numberOfLengths3 + 1)))), PuzzleBoardLetter).Show()
                                CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & ((27 + (numberOfLengths3 + 1)))), PuzzleBoardLetter).letterBehind = word.Chars(myLetter).ToString()
                                frmPuzzleBoard.ListBox1.Items.Add(word.Chars(myLetter).ToString())
                                frmPuzzleBoard.ListBox2.Items.Add("PuzzleBoardLetter" & (numberOfLengths3 + (28 - (14 - numberOfLengths2))))
                                If word.Chars(myLetter).ToString() = "'" Or word.Chars(myLetter).ToString() = "?" Or word.Chars(myLetter).ToString() = "." Or word.Chars(myLetter).ToString() = "!" Or word.Chars(myLetter).ToString() = "-" Or word.Chars(myLetter).ToString() = "/" Or word.Chars(myLetter).ToString() = ":" Or word.Chars(myLetter).ToString() = "\" Or word.Chars(myLetter).ToString() = "&" Then
                                    CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & ((27 + (numberOfLengths3 + 1)))), PuzzleBoardLetter).revealLetter()
                                End If
                                numberOfLengths3 += 1
                                frmPuzzleBoard.ListBox3.Items.Add(numberOfLengths3)
                            ElseIf word.Chars(myLetter).ToString() = " " Then
                                CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & ((27 + (numberOfLengths3 + 1)))), PuzzleBoardLetter).Hide()
                                numberOfLengths3 += 1
                            End If
                        Next
                    ElseIf word.Replace(" ", "").Length > 13 - numberOfLengths3 And row3 = True And row4 = False Or (word.Replace(" ", "").Length <= 12 - numberOfLengths4 And row4 = True) Then
                        row4 = True
                        Try
                            For myLetter = 0 To word.Length - 1
                                If word.Chars(myLetter).ToString() <> " " Then
                                    CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & ((40 + (numberOfLengths4 + 1)))), PuzzleBoardLetter).Show()
                                    CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & ((40 + (numberOfLengths4 + 1)))), PuzzleBoardLetter).letterBehind = word.Chars(myLetter).ToString()
                                    'CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & ((40 + (numberOfLengths4 + 1)))), PuzzleBoardLetter).revealLetter()
                                    frmPuzzleBoard.ListBox1.Items.Add(word.Chars(myLetter).ToString())
                                    frmPuzzleBoard.ListBox2.Items.Add("PuzzleBoardLetter" & (numberOfLengths4 + (41 - (12 - numberOfLengths4))))
                                    If word.Chars(myLetter).ToString() = "'" Or word.Chars(myLetter).ToString() = "?" Or word.Chars(myLetter).ToString() = "." Or word.Chars(myLetter).ToString() = "!" Or word.Chars(myLetter).ToString() = "-" Or word.Chars(myLetter).ToString() = "/" Or word.Chars(myLetter).ToString() = ":" Or word.Chars(myLetter).ToString() = "\" Or word.Chars(myLetter).ToString() = "&" Then
                                        CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & ((40 + (numberOfLengths4 + 1)))), PuzzleBoardLetter).revealLetter()
                                    End If
                                    numberOfLengths4 += 1
                                    frmPuzzleBoard.ListBox3.Items.Add(numberOfLengths4)
                                ElseIf word.Chars(myLetter).ToString() = " " Then
                                    CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & ((40 + (numberOfLengths4 + 1)))), PuzzleBoardLetter).Hide()
                                    numberOfLengths4 += 1
                                End If
                            Next
                        Catch ex As Exception
                            MsgBox("The puzzle you entered is too long. Please try again.", vbCritical, "Wheel of Fortune")
                        End Try
                    End If
                Next
            End If
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
                    For myLetter = 0 To word.Length - 1
                        Dim letter
                        If word.Chars(myLetter).ToString() <> " " And Not Char.IsDigit(word.Chars(myLetter)) Then
                            letter = word.Chars(myLetter).ToString().Replace(puzzleBoardLetterInteger, "")
                            CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & puzzleBoardLetterInteger), PuzzleBoardLetter).letterBehind = letter
                            CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & puzzleBoardLetterInteger), PuzzleBoardLetter).Show()
                            puzzleBoardLetterInteger = Nothing
                        End If
                    Next
                Next
            Catch ex As Exception
                MsgBox("The crossword puzzle is invalid, please go to the customizer and re-enter the puzzle. Remember to follow the crossword format exactly as mistakes will cause the crossword to not load.", vbCritical, "Wheel of Fortune")
            End Try
        End If
    End Sub
#End Region
#Region "Load Bonus Round"
    Public Shared Sub loadBonusRound()
        frmPuzzleBoard.lblRSTLNE.Show()
        loadRSTLNE()
    End Sub
#End Region
#Region "Load RSTLNE in Puzzle"
    Public Shared Sub loadRSTLNE()
        For Each letterControl As Control In frmPuzzleBoard.Controls
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
        frmScore.timeStart = DateTime.Now.Second
        frmScore.tmrLetterReveal.Start()
        My.Computer.Audio.Play(My.Resources.R_S_T_L_N_E, AudioPlayMode.BackgroundLoop)
    End Sub
#End Region
#Region "Load Letters in Bonus Round"
    Public Shared Sub loadBonusLetters()
        For Each letterControl As Control In frmPuzzleBoard.Controls
            If letterControl.GetType() Is GetType(PuzzleBoardLetter) Then
                'If selectedBonusLetters.Contains(CType(letterControl, PuzzleBoardLetter).letterBehind) Then
                For Each letter As String In selectedBonusLetters
                    If CType(letterControl, PuzzleBoardLetter).letterBehind = letter Then
                        letterControlList.Add(letterControl.Name.Replace("PuzzleBoardLetter", ""))
                        'CType(letterControl, PuzzleBoardLetter).displayBlueBKG()
                        'CType(letterControl, PuzzleBoardLetter).playDing()
                        For Each selectedLetters As Button In frmScore.usedLetterBoard.Controls
                            selectedLetters.Enabled = False
                        Next
                    End If
                Next
            End If
            'End If
        Next
        frmScore.timeStart = DateTime.Now.Second
        frmScore.tmrLetterReveal.Start()
        'frmScore.bonusTimer()
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
            For Each item In frmPuzzleBoard.ListBox2.Items
                'If letterControl.GetType() Is GetType(PuzzleBoardLetter) Then
                '    If CType(letterControl, PuzzleBoardLetter).letterBehind <> "" Then
                tossUpLetterControlList.Add(item.ToString.Replace("PuzzleBoardLetter", ""))
                '    End If
                'End If
            Next
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
        '                    CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & (randomLetter + 13).ToString()), PuzzleBoardLetter).letterPicture.Image = FadeBitmap(My.Resources.Wild_Card, 0.5)
        '                    'CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & (randomLetter + 13).ToString()), PuzzleBoardLetter).letterPicture.Show()
        '                    tossUpLetterList.Add("PuzzleBoardLetter" & (randomLetterKey + 13).ToString())
        '                    'CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & (randomLetterKey) + 13), PuzzleBoardLetter).revealLetter()
        '                    'tossUpLetterList.Add(CType(letterControl, PuzzleBoardLetter))
        '                    'CType(letterControl, PuzzleBoardLetter).revealLetter()
        '                    'keyNumber.Remove(randomLetterKey)
        '                    For myI = 1 To 25
        '                    frmPuzzleBoard.pbarTossUp.Value += 1
        '                    Next
        '                frmPuzzleBoard.lblProgress.Text = frmPuzzleBoard.pbarTossUp.Value.ToString() & "/" & frmPuzzleBoard.pbarTossUp.Maximum.ToString() & "/ i=" & letterI & "LetterID=" & item.ToString()
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
        '                    CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & (randomLetter + 1).ToString()), PuzzleBoardLetter).letterPicture.Image = FadeBitmap(My.Resources.Wild_Card, 0.5)
        '                    'CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & (randomLetter + 1).ToString()), PuzzleBoardLetter).letterPicture.Show()
        '                    'CType(letterControl, PuzzleBoardLetter).revealLetter()
        '                    tossUpLetterList.Add("PuzzleBoardLetter" & (randomLetterKey + 1).ToString())
        '                    'CType(frmPuzzleBoard.Controls("PuzzleBoardLetter" & (randomLetterKey) + 1), PuzzleBoardLetter).revealLetter()
        '                    'tossUpLetterList.Add(CType(letterControl, PuzzleBoardLetter))
        '                    'keyNumber.Remove(randomLetterKey)
        '                    For myI = 1 To 25
        '                    frmPuzzleBoard.pbarTossUp.Value += 1
        '                    Next
        '                frmPuzzleBoard.lblProgress.Text = frmPuzzleBoard.pbarTossUp.Value.ToString() & "/" & frmPuzzleBoard.pbarTossUp.Maximum.ToString() & "/ i=" & letterI & "LetterID=" & item.ToString()
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
        frmScore.spun = False
        My.Computer.Audio.Play(My.Resources.bankrupt, AudioPlayMode.Background)
        If currentPlayer = 1 Then
            frmScore.lblPlayer1.Text = FormatCurrency(0, 0)
            frmScore.player1.addCardsOrWedges(Player.Wedges.Gift, False)
            frmScore.player1.addCardsOrWedges(Player.Wedges.HalfCar1, False)
            frmScore.player1.addCardsOrWedges(Player.Wedges.HalfCar2, False)
            frmScore.player1.addCardsOrWedges(Player.Wedges.Million, False)
            frmScore.player1.addCardsOrWedges(Player.Wedges.Mystery, False)
            frmScore.player1.addCardsOrWedges(Player.Wedges.Prize, False)
            frmScore.player1.addCardsOrWedges(Player.Wedges.Wild, False)
        ElseIf currentPlayer = 2 Then
            frmScore.lblPlayer2.Text = FormatCurrency(0, 0)
            frmScore.player2.addCardsOrWedges(Player.Wedges.Gift, False)
            frmScore.player2.addCardsOrWedges(Player.Wedges.HalfCar1, False)
            frmScore.player2.addCardsOrWedges(Player.Wedges.HalfCar2, False)
            frmScore.player2.addCardsOrWedges(Player.Wedges.Million, False)
            frmScore.player2.addCardsOrWedges(Player.Wedges.Mystery, False)
            frmScore.player2.addCardsOrWedges(Player.Wedges.Prize, False)
            frmScore.player2.addCardsOrWedges(Player.Wedges.Wild, False)
        ElseIf currentPlayer = 3 Then
            frmScore.lblPlayer3.Text = FormatCurrency(0, 0)
            frmScore.player3.addCardsOrWedges(Player.Wedges.Gift, False)
            frmScore.player3.addCardsOrWedges(Player.Wedges.HalfCar1, False)
            frmScore.player3.addCardsOrWedges(Player.Wedges.HalfCar2, False)
            frmScore.player3.addCardsOrWedges(Player.Wedges.Million, False)
            frmScore.player3.addCardsOrWedges(Player.Wedges.Mystery, False)
            frmScore.player3.addCardsOrWedges(Player.Wedges.Prize, False)
            frmScore.player3.addCardsOrWedges(Player.Wedges.Wild, False)
        End If
        LoseATurn()
    End Sub
#End Region
#Region "Lose a Turn"
    Public Shared Sub LoseATurn()
        If previousValue <> "Bankrupt" Or finalSpin = False Then
            previousValue = "Lose A Turn"
            frmScore.spun = False
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
        If finalSpin = False Then
            spinResult = 0
        Else
        End If
        If currentPlayer <= 2 And numberOfPlayers <> 1 Then
            If currentPlayer = 2 And numberOfPlayers = 2 Then
                currentPlayer = 1
            Else
                currentPlayer += 1
            End If
        ElseIf currentPlayer > 2 And numberOfPlayers <> 1 Then
            currentPlayer = 1
        ElseIf numberOfPlayers = 1 Then
            numberOfTurns -= 1
        End If
        frmPuzzleBoard.wheelTilt.Enabled = True
        frmPuzzleBoard.btnSolve.Enabled = True
    End Sub
#End Region
#Region "Reveal Number of Letters"
    Public Shared Function revealNumberOfLetters() As String
        'Dim letterList As New List(Of String)
        ''Dim controlList As New List(Of Integer)
        ''Dim letterSortedList As New SortedList(Of String, Integer)
        ''Dim letterRevealedList As New List(Of String)
        'For Each myControl As Control In frmPuzzleBoard.Controls
        '    If myControl.GetType() Is GetType(PuzzleBoardLetter) Then
        '        If letterControlList.Contains(myControl.Name.Replace("PuzzleBoardLetter", "")) Then
        '            letterList.Add(CType(myControl, PuzzleBoardLetter).letterBehind)
        '        Else
        '        End If
        '    Else
        '    End If
        'Next
        ''For Each letter As String In letterList
        'Dim groups = letterList.GroupBy(Function(value) value)
        'For Each grp In groups
        '    For i As Integer = 1 To groups.Count
        If letterControlList.Count = 1 Then
            Return "There is one " & frmScore.currentLetter & "."
        ElseIf letterControlList.Count > 1 Then
            Return "There are " & letterControlList.Count & " " & frmScore.currentLetter & "'s."
        Else
            Return "There are no " & frmScore.currentLetter & "'s."
        End If
        '    Next
        'Next
        'Next
    End Function
#End Region
#Region "Load Wedges onto the Wheel"
    Private Shared bonusWheel As New List(Of String) From {"34000", "34000", "34000", "34000", "34000", "34000", "34000", "34000", "34000", "34000", "34000", "34000", "34000", "34000", "40000", "45000", "50000", "100000", "Car", "Car", "Car", "Car", "Car", "Car"}
    Public Shared Sub wheelLoad(round As PuzzleType)
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
            wheelWedges.Add(7, "1/2 Car")
            wheelWedges.Add(8, "1/2 Car")
            wheelWedges.Add(9, "1/2 Car")
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
            wheelWedges.Add(37, "1/2 Car")
            wheelWedges.Add(38, "1/2 Car")
            wheelWedges.Add(39, "1/2 Car")
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
            If halfCar1Status = True And halfCar2Status = True Then
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
            If halfCar1Status = True And halfCar2Status = True Then
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
            If halfCar1Status = True And halfCar2Status = True Then
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
            If halfCar1Status = True And halfCar2Status = True Then
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
                    If frmScore.player1.getWedges(Player.Wedges.Million) Or frmScore.player2.getWedges(Player.Wedges.Million) Or frmScore.player3.getWedges(Player.Wedges.Million) Then
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
            '            wheelWedges.Add(1, "34000")
            '            wheelWedges.Add(2, "34000")
            '            wheelWedges.Add(3, "34000")
            '            wheelWedges.Add(4, "34000")
            '            wheelWedges.Add(5, "34000")
            '            wheelWedges.Add(6, "34000")
            '            wheelWedges.Add(7, "Car")
            '            wheelWedges.Add(8, "Car")
            '            wheelWedges.Add(9, "50000")
            '            wheelWedges.Add(10, "50000")
            '            wheelWedges.Add(11, "34000")
            '            wheelWedges.Add(12, "34000")
            '            wheelWedges.Add(13, "Car")
            '            wheelWedges.Add(14, "Car")
            '            wheelWedges.Add(15, "34000")
            '            wheelWedges.Add(16, "34000")
            '            wheelWedges.Add(17, "45000")
            '            wheelWedges.Add(18, "45000")
            '            wheelWedges.Add(19, "34000")
            '            wheelWedges.Add(20, "34000")
            '            wheelWedges.Add(21, "40000")
            '            wheelWedges.Add(22, "40000")
            '            wheelWedges.Add(23, "34000")
            '            wheelWedges.Add(24, "34000")
            '            wheelWedges.Add(25, "34000")
            '            wheelWedges.Add(26, "34000")
            '            wheelWedges.Add(27, "34000")
            '            wheelWedges.Add(28, "34000")
            '            wheelWedges.Add(29, "Car")
            '            wheelWedges.Add(29, "Car")
            '            wheelWedges.Add(30, "40000")
            '            wheelWedges.Add(31, "40000")
            '            wheelWedges.Add(32, "34000")
            '            wheelWedges.Add(33, "34000")
            '            wheelWedges.Add(34, "34000")
            '            wheelWedges.Add(35, "34000")
            '#Region "Load Million on Bonus Wheel"
            '            If frmScore.player1.getWedges(Player.Wedges.Million) Or frmScore.player2.getWedges(Player.Wedges.Million) Or frmScore.player3.getWedges(Player.Wedges.Million) Then
            '                wheelWedges.Add(36, "1000000")
            '                wheelWedges.Add(37, "1000000")
            '            Else
            '                wheelWedges.Add(36, "100000")
            '                    wheelWedges.Add(37, "100000")
            '                End If
            '#End Region
            '                wheelWedges.Add(38, "34000")
            '                wheelWedges.Add(39, "34000")
            '                wheelWedges.Add(40, "50000")
            '                wheelWedges.Add(41, "50000")
            '                wheelWedges.Add(42, "34000")
            '                wheelWedges.Add(43, "34000")
            '                wheelWedges.Add(44, "34000")
            '                wheelWedges.Add(45, "34000")
            '                wheelWedges.Add(46, "34000")
            '                wheelWedges.Add(47, "34000")
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
            wheelWedges.Add(55, "650")
            wheelWedges.Add(56, "650")
            wheelWedges.Add(57, "650")
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
End Class
