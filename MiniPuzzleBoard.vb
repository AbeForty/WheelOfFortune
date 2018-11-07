Public Class MiniPuzzleBoard
    Dim puzzleLetterLocationList As New SortedList(Of Integer, Integer)
    Dim highestValue As Integer = 0
    Dim highestXValue As Integer = 0
    Dim highestControl As Control
    Public rightControlDetermined As Boolean = False
    Private Sub PuzzleBoard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tmrCheckRevealed.Start()
    End Sub
    Public Sub clearLetterList()
        puzzleLetterLocationList.Clear()
    End Sub
    Private Sub tmrCheckRevealed_Tick(sender As Object, e As EventArgs) Handles tmrCheckRevealed.Tick
        If WheelController.puzzleLoaded = True And rightControlDetermined = False Then
            For Each myControl As Control In Controls
                If myControl.Visible = True Then
                    puzzleLetterLocationList.Add(myControl.Name.Replace("PuzzleBoardLetter", ""), myControl.Location.X)
                End If
            Next
            Dim indexOfMax = puzzleLetterLocationList.IndexOfValue(puzzleLetterLocationList.Values.Max)
            CType(Controls("PuzzleBoardLetter" & puzzleLetterLocationList.Keys.Item(indexOfMax)), PuzzleBoardLetter).tossUpStatus = True
            rightControlDetermined = True
        End If
    End Sub
End Class
