Imports System.Windows.Forms

Public Class MysteryDialog

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnYes_Click(sender As Object, e As EventArgs) Handles btnYes.Click
        frmPuzzleBoard.mysteryReveal.Show()
        WheelController.mysteryReveal = True
        If WheelController.currentPlayer = 1 Then
            If frmScore.lblCurrentValue.Text = "Mystery 1" And WheelController.mysteryStatus = False And WheelController.mystery2value = False AndAlso WheelController.mysteryReveal = True Then
                frmScore.player1.addCardsOrWedges(Player.Wedges.Mystery, True)
                frmPuzzleBoard.mysteryReveal.Image = My.Resources.Mystery_10000_2014
            ElseIf frmScore.lblCurrentValue.Text = "Mystery 1" And WheelController.mysteryStatus = False And WheelController.mystery2value = True AndAlso WheelController.mysteryReveal = True Then
                WheelController.bankrupt()
                frmPuzzleBoard.mysteryReveal.Image = My.Resources.Mystery_2014_Bankrupt
            ElseIf frmScore.lblCurrentValue.Text = "Mystery 2" And WheelController.mysteryStatus = False And WheelController.mystery2value = True AndAlso WheelController.mysteryReveal = True Then
                frmScore.player1.addCardsOrWedges(Player.Wedges.Mystery, True)
                frmPuzzleBoard.mysteryReveal.Image = My.Resources.Mystery_10000_2014
            ElseIf frmScore.lblCurrentValue.Text = "Mystery 2" And WheelController.mysteryStatus = False And WheelController.mystery2value = False AndAlso WheelController.mysteryReveal = True Then
                WheelController.bankrupt()
                frmPuzzleBoard.mysteryReveal.Image = My.Resources.Mystery_2014_Bankrupt
            End If
        ElseIf WheelController.currentPlayer = 2 Then
            If frmScore.lblCurrentValue.Text = "Mystery 1" And WheelController.mysteryStatus = False And WheelController.mystery2value = False AndAlso WheelController.mysteryReveal = True Then
                frmScore.player2.addCardsOrWedges(Player.Wedges.Mystery, True)
                frmPuzzleBoard.mysteryReveal.Image = My.Resources.Mystery_10000_2014
            ElseIf frmScore.lblCurrentValue.Text = "Mystery 1" And WheelController.mysteryStatus = False And WheelController.mystery2value = True AndAlso WheelController.mysteryReveal = True Then
                WheelController.bankrupt()
                frmPuzzleBoard.mysteryReveal.Image = My.Resources.Mystery_2014_Bankrupt
            ElseIf frmScore.lblCurrentValue.Text = "Mystery 2" And WheelController.mysteryStatus = False And WheelController.mystery2value = True AndAlso WheelController.mysteryReveal = True Then
                frmScore.player2.addCardsOrWedges(Player.Wedges.Mystery, True)
                frmPuzzleBoard.mysteryReveal.Image = My.Resources.Mystery_10000_2014
            ElseIf frmScore.lblCurrentValue.Text = "Mystery 2" And WheelController.mysteryStatus = False And WheelController.mystery2value = False AndAlso WheelController.mysteryReveal = True Then
                WheelController.bankrupt()
                frmPuzzleBoard.mysteryReveal.Image = My.Resources.Mystery_2014_Bankrupt
            End If
        ElseIf WheelController.currentPlayer = 3 Then
            If frmScore.lblCurrentValue.Text = "Mystery 1" And WheelController.mysteryStatus = False And WheelController.mystery2value = False AndAlso WheelController.mysteryReveal = True Then
                frmScore.player3.addCardsOrWedges(Player.Wedges.Mystery, True)
                frmPuzzleBoard.mysteryReveal.Image = My.Resources.Mystery_10000_2014
            ElseIf frmScore.lblCurrentValue.Text = "Mystery 1" And WheelController.mysteryStatus = False And WheelController.mystery2value = True AndAlso WheelController.mysteryReveal = True Then
                WheelController.bankrupt()
                frmPuzzleBoard.mysteryReveal.Image = My.Resources.Mystery_2014_Bankrupt
            ElseIf frmScore.lblCurrentValue.Text = "Mystery 2" And WheelController.mysteryStatus = False And WheelController.mystery2value = True AndAlso WheelController.mysteryReveal = True Then
                frmScore.player3.addCardsOrWedges(Player.Wedges.Mystery, True)
                frmPuzzleBoard.mysteryReveal.Image = My.Resources.Mystery_10000_2014
            ElseIf frmScore.lblCurrentValue.Text = "Mystery 2" And WheelController.mysteryStatus = False And WheelController.mystery2value = False AndAlso WheelController.mysteryReveal = True Then
                WheelController.bankrupt()
                frmPuzzleBoard.mysteryReveal.Image = My.Resources.Mystery_2014_Bankrupt
            End If
        End If
        If frmScore.lblCurrentValue.Text = "Mystery 1" Then
            WheelController.wheelWedges(59) = 600
            WheelController.wheelWedges(60) = 600
            WheelController.wheelWedges(61) = 600
        ElseIf frmScore.lblCurrentValue.Text = "Mystery 2" Then
            WheelController.wheelWedges(23) = 700
            WheelController.wheelWedges(24) = 700
            WheelController.wheelWedges(25) = 700
        End If
        WheelController.mysteryStatus = True
        Me.Close()
    End Sub

    Private Sub btnNo_Click(sender As Object, e As EventArgs) Handles btnNo.Click
        WheelController.spinResult = 1000
        WheelController.mysteryReveal = False
        If WheelController.currentPlayer = 1 Then
            Dim currentPlayerValue = CInt(frmScore.lblPlayer1.Text.Replace("$", ""))
            currentPlayerValue += WheelController.spinResult
        ElseIf WheelController.currentPlayer = 2 Then
            Dim currentPlayerValue = CInt(frmScore.lblPlayer2.Text.Replace("$", ""))
            currentPlayerValue += WheelController.spinResult
        ElseIf WheelController.currentPlayer = 3 Then
            Dim currentPlayerValue = CInt(frmScore.lblPlayer3.Text.Replace("$", ""))
            currentPlayerValue += WheelController.spinResult
        End If
        Close()
    End Sub

    Private Sub MysteryDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If WheelController.currentPlayer = 1 Then
            Dim currentPlayerValue = CInt(frmScore.lblPlayer1.Text.Replace("$", ""))
            currentPlayerValue -= WheelController.spinResult
        ElseIf WheelController.currentPlayer = 2 Then
            Dim currentPlayerValue = CInt(frmScore.lblPlayer2.Text.Replace("$", ""))
            currentPlayerValue -= WheelController.spinResult
        ElseIf WheelController.currentPlayer = 3 Then
            Dim currentPlayerValue = CInt(frmScore.lblPlayer3.Text.Replace("$", ""))
            currentPlayerValue -= WheelController.spinResult
        End If
    End Sub
End Class
