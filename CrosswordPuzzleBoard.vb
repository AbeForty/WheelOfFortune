Public Class CrosswordPuzzleBoard
    Public puzzleLetterLocationList As New SortedList(Of Integer, String)
    Private Sub PuzzleBoard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'tmrCheckRevealed.Start()
        Try
            Dim TheseAreYourWords = frmCustomizer.txtPuzzle.Text.Split(" ")
            Dim myWords As New List(Of String)
            For Each item As String In TheseAreYourWords
                If Not item = TheseAreYourWords.Last Then
                    myWords.Add(item & " ")
                Else
                    myWords.Add(item)
                End If
            Next
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
                        puzzleLetterLocationList(puzzleBoardLetterInteger) = letter
                        CType(Controls("PuzzleBoardLetter" & puzzleBoardLetterInteger), PuzzleBoardLetter).letterBehind = letter
                        CType(Controls("PuzzleBoardLetter" & puzzleBoardLetterInteger), PuzzleBoardLetter).revealLetter()
                        puzzleBoardLetterInteger = Nothing
                    End If
                Next
            Next
        Catch ex As Exception
            MsgBox("The crossword puzzle is invalid, please go to the customizer and re-enter the puzzle. Remember to follow the crossword format exactly as mistakes will cause the crossword to not load.", vbCritical, "Wheel of Fortune")
        End Try
        For Each letterControl As PuzzleBoardLetter In Me.Controls
            letterControl.BackColor = Color.Transparent
            letterControl.btnLetter.BackColor = Color.Transparent
        Next
    End Sub
    Public Sub clearLetterList()
        puzzleLetterLocationList.Clear()
    End Sub
    Private Sub btn_Click(sender As Object, e As EventArgs) Handles PuzzleBoardLetter1.Click, PuzzleBoardLetter2.Click, PuzzleBoardLetter3.Click, PuzzleBoardLetter4.Click, PuzzleBoardLetter5.Click, PuzzleBoardLetter6.Click, PuzzleBoardLetter7.Click, PuzzleBoardLetter8.Click, PuzzleBoardLetter9.Click, PuzzleBoardLetter10.Click, PuzzleBoardLetter11.Click, PuzzleBoardLetter12.Click, PuzzleBoardLetter13.Click, PuzzleBoardLetter14.Click, PuzzleBoardLetter15.Click, PuzzleBoardLetter16.Click, PuzzleBoardLetter17.Click, PuzzleBoardLetter18.Click, PuzzleBoardLetter19.Click, PuzzleBoardLetter20.Click, PuzzleBoardLetter21.Click, PuzzleBoardLetter22.Click, PuzzleBoardLetter23.Click, PuzzleBoardLetter24.Click, PuzzleBoardLetter25.Click, PuzzleBoardLetter26.Click, PuzzleBoardLetter27.Click, PuzzleBoardLetter28.Click, PuzzleBoardLetter29.Click, PuzzleBoardLetter30.Click, PuzzleBoardLetter31.Click, PuzzleBoardLetter32.Click, PuzzleBoardLetter33.Click, PuzzleBoardLetter34.Click, PuzzleBoardLetter35.Click, PuzzleBoardLetter36.Click, PuzzleBoardLetter37.Click, PuzzleBoardLetter38.Click, PuzzleBoardLetter39.Click, PuzzleBoardLetter40.Click, PuzzleBoardLetter41.Click, PuzzleBoardLetter42.Click, PuzzleBoardLetter43.Click, PuzzleBoardLetter44.Click, PuzzleBoardLetter45.Click, PuzzleBoardLetter46.Click, PuzzleBoardLetter47.Click, PuzzleBoardLetter48.Click, PuzzleBoardLetter49.Click, PuzzleBoardLetter50.Click, PuzzleBoardLetter51.Click, PuzzleBoardLetter52.Click
        'Dim finalString = ""
        'If LetterTypeControl.ShowDialog() = DialogResult.OK Then
        '    CType(sender, PuzzleBoardLetter).letterBehind = LetterTypeControl.currentLetter
        '    CType(sender, PuzzleBoardLetter).revealLetter()
        '    puzzleLetterLocationList(CType(sender, PuzzleBoardLetter).Name.Replace("PuzzleBoardLetter", "")) = LetterTypeControl.currentLetter
        '    CType(sender, PuzzleBoardLetter).btnLetter.BackColor = Color.White
        'End If
        'For Each letterGroup As KeyValuePair(Of Integer, String) In puzzleLetterLocationList
        '    finalString &= (letterGroup.Value & letterGroup.Key & " ")
        'Next
        'frmCustomizer.txtPuzzle.Text = finalString
    End Sub
End Class

