﻿Public Class frmHelp
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        If frmScore.Visible = True Then
            WheelController.startTime = DateTime.Now.Minute
            frmPuzzleBoard.tmrCheckFinalSpin.Start()
        End If
        Close()
    End Sub

    Private Sub frmHelp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BringToFront()
    End Sub
End Class