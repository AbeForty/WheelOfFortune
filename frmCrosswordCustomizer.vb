Imports System.Data.SqlClient

Public Class frmCrosswordCustomizer
    Public currentRound As WheelController.PuzzleType
    Public currentPuzzle As String

    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        Me.Close()
    End Sub
End Class