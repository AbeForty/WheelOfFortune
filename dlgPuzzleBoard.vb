Public Class dlgPuzzleBoard
    Private Sub dlgPuzzleBoard_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - Me.Width, Screen.PrimaryScreen.WorkingArea.Height - Me.Height)
        For Each letterControl As PuzzleBoardLetter In frmPuzzleBoard.PuzzleBoard1.Controls
            If letterControl.Visible = True Then
                MiniPuzzleBoard1.Controls(letterControl.Name).Show()
                CType(MiniPuzzleBoard1.Controls(letterControl.Name), PuzzleBoardLetter).letterBehind = letterControl.letterBehind
                If letterControl.btnLetter.BackgroundImage IsNot Nothing OrElse letterControl.btnLetter.BackColor = Color.Blue Then
                    CType(MiniPuzzleBoard1.Controls(letterControl.Name), PuzzleBoardLetter).revealLetter()
                Else
                End If
            ElseIf letterControl.Visible = False Then
                MiniPuzzleBoard1.Controls(letterControl.Name).Hide()
            End If
        Next
    End Sub
End Class