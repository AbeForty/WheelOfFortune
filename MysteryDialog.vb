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
                For Each myPlayer As Player In WheelController.Player1List
                    myPlayer.addCardsOrWedges(Player.Wedges.Mystery, True)
                Next
                frmPuzzleBoard.mysteryReveal.Image = My.Resources.Mystery_10000_2014
            ElseIf frmScore.lblCurrentValue.Text = "Mystery 1" And WheelController.mysteryStatus = False And WheelController.mystery2value = True AndAlso WheelController.mysteryReveal = True Then
                WheelController.bankrupt()
                frmPuzzleBoard.mysteryReveal.Image = My.Resources.Mystery_2014_Bankrupt
            ElseIf frmScore.lblCurrentValue.Text = "Mystery 2" And WheelController.mysteryStatus = False And WheelController.mystery2value = True AndAlso WheelController.mysteryReveal = True Then
                For Each myPlayer As Player In WheelController.Player1List
                    myPlayer.addCardsOrWedges(Player.Wedges.Mystery, True)
                Next
                frmPuzzleBoard.mysteryReveal.Image = My.Resources.Mystery_10000_2014
            ElseIf frmScore.lblCurrentValue.Text = "Mystery 2" And WheelController.mysteryStatus = False And WheelController.mystery2value = False AndAlso WheelController.mysteryReveal = True Then
                WheelController.bankrupt()
                frmPuzzleBoard.mysteryReveal.Image = My.Resources.Mystery_2014_Bankrupt
            End If
        ElseIf WheelController.currentPlayer = 2 Then
            If frmScore.lblCurrentValue.Text = "Mystery 1" And WheelController.mysteryStatus = False And WheelController.mystery2value = False AndAlso WheelController.mysteryReveal = True Then
                For Each myPlayer As Player In WheelController.Player2List
                    myPlayer.addCardsOrWedges(Player.Wedges.Mystery, True)
                Next
                frmPuzzleBoard.mysteryReveal.Image = My.Resources.Mystery_10000_2014
            ElseIf frmScore.lblCurrentValue.Text = "Mystery 1" And WheelController.mysteryStatus = False And WheelController.mystery2value = True AndAlso WheelController.mysteryReveal = True Then
                WheelController.bankrupt()
                frmPuzzleBoard.mysteryReveal.Image = My.Resources.Mystery_2014_Bankrupt
            ElseIf frmScore.lblCurrentValue.Text = "Mystery 2" And WheelController.mysteryStatus = False And WheelController.mystery2value = True AndAlso WheelController.mysteryReveal = True Then
                For Each myPlayer As Player In WheelController.Player2List
                    myPlayer.addCardsOrWedges(Player.Wedges.Mystery, True)
                Next
                frmPuzzleBoard.mysteryReveal.Image = My.Resources.Mystery_10000_2014
            ElseIf frmScore.lblCurrentValue.Text = "Mystery 2" And WheelController.mysteryStatus = False And WheelController.mystery2value = False AndAlso WheelController.mysteryReveal = True Then
                WheelController.bankrupt()
                frmPuzzleBoard.mysteryReveal.Image = My.Resources.Mystery_2014_Bankrupt
            End If
        ElseIf WheelController.currentPlayer = 3 Then
            If frmScore.lblCurrentValue.Text = "Mystery 1" And WheelController.mysteryStatus = False And WheelController.mystery2value = False AndAlso WheelController.mysteryReveal = True Then
                For Each myPlayer As Player In WheelController.Player3List
                    myPlayer.addCardsOrWedges(Player.Wedges.Mystery, True)
                Next
                frmPuzzleBoard.mysteryReveal.Image = My.Resources.Mystery_10000_2014
            ElseIf frmScore.lblCurrentValue.Text = "Mystery 1" And WheelController.mysteryStatus = False And WheelController.mystery2value = True AndAlso WheelController.mysteryReveal = True Then
                WheelController.bankrupt()
                frmPuzzleBoard.mysteryReveal.Image = My.Resources.Mystery_2014_Bankrupt
            ElseIf frmScore.lblCurrentValue.Text = "Mystery 2" And WheelController.mysteryStatus = False And WheelController.mystery2value = True AndAlso WheelController.mysteryReveal = True Then
                For Each myPlayer As Player In WheelController.Player3List
                    myPlayer.addCardsOrWedges(Player.Wedges.Mystery, True)
                Next
                frmPuzzleBoard.mysteryReveal.Image = My.Resources.Mystery_10000_2014
            ElseIf frmScore.lblCurrentValue.Text = "Mystery 2" And WheelController.mysteryStatus = False And WheelController.mystery2value = False AndAlso WheelController.mysteryReveal = True Then
                WheelController.bankrupt()
                frmPuzzleBoard.mysteryReveal.Image = My.Resources.Mystery_2014_Bankrupt
            End If
        End If
        If frmScore.lblCurrentValue.Text = "Mystery 1" Then
            WheelController.wheelWedges(58) = 600
            WheelController.wheelWedges(59) = 600
            WheelController.wheelWedges(60) = 600
            WheelController.mystery1Status = True
            WheelController.loadMysteryWheel()
        ElseIf frmScore.lblCurrentValue.Text = "Mystery 2" Then
            WheelController.wheelWedges(22) = 700
            WheelController.wheelWedges(23) = 700
            WheelController.wheelWedges(24) = 700
            WheelController.mystery2Status = True
            WheelController.loadMysteryWheel()
        End If
        WheelController.mysteryStatus = True
        Me.Close()
    End Sub

    Private Sub btnNo_Click(sender As Object, e As EventArgs) Handles btnNo.Click
        WheelController.spinResult = 1000
        WheelController.mysteryReveal = False
        Dim currentPlayerValue
        If frmScore.pnlScore.Controls("lblPlayer" & WheelController.currentPlayer).Text.Replace("$", "") = "" Then
            currentPlayerValue = 0
        Else
            currentPlayerValue = CInt(CType(frmScore.pnlScore.Controls("lblPlayer" & WheelController.currentPlayer), Label).Text.Replace("$", ""))
        End If
        'currentPlayerValue -= WheelController.moneyValue
        If WheelController.currentPlayer = 1 Then
            'currentPlayerValue = CInt(frmScore.lblPlayer1.Text.Replace("$", ""))
            currentPlayerValue += WheelController.moneyValue
            frmScore.lblPlayer1.Text = FormatCurrency(currentPlayerValue, 0)
        ElseIf WheelController.currentPlayer = 2 Then
                'currentPlayerValue = CInt(frmScore.lblPlayer2.Text.Replace("$", ""))
                currentPlayerValue += WheelController.moneyValue
                frmScore.lblPlayer2.Text = FormatCurrency(currentPlayerValue, 0)
            ElseIf WheelController.currentPlayer = 3 Then
                'currentPlayerValue = CInt(frmScore.lblPlayer3.Text.Replace("$", ""))
                currentPlayerValue += WheelController.moneyValue
            frmScore.lblPlayer3.Text = FormatCurrency(currentPlayerValue, 0)
        End If
        Close()
    End Sub

    Private Sub MysteryDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim currentPlayerValue
        If frmScore.pnlScore.Controls("lblPlayer" & WheelController.currentPlayer).Text.Replace("$", "") = "" Then
            currentPlayerValue = 0
        Else
            currentPlayerValue = CInt(CType(frmScore.pnlScore.Controls("lblPlayer" & WheelController.currentPlayer), Label).Text.Replace("$", ""))
        End If
        currentPlayerValue += WheelController.moneyValue
        'If WheelController.currentPlayer = 1 Then
        '    If frmScore.lblPlayer1.Text.Replace("$", "") = "" Then
        '        currentPlayerValue = 0
        '    Else
        '        currentPlayerValue = CInt(frmScore.lblPlayer1.Text.Replace("$", ""))
        '    End If
        '    currentPlayerValue -= WheelController.moneyValue
        'ElseIf WheelController.currentPlayer = 2 Then
        '    If frmScore.lblPlayer2.Text.Replace("$", "") = "" Then
        '        currentPlayerValue = 0
        '    Else
        '        currentPlayerValue = CInt(frmScore.lblPlayer2.Text.Replace("$", ""))
        '    End If
        '    currentPlayerValue -= WheelController.moneyValue
        'ElseIf WheelController.currentPlayer = 3 Then
        '    If frmScore.lblPlayer3.Text.Replace("$", "") = "" Then
        '        currentPlayerValue = 0
        '    Else
        '        currentPlayerValue = CInt(frmScore.lblPlayer3.Text.Replace("$", ""))
        '    End If
        '    currentPlayerValue -= WheelController.moneyValue
        'End If
        If currentPlayerValue.ToString() = "" Then
            currentPlayerValue = 0
        End If
        Dim total = currentPlayerValue
        If WheelController.virtualHost = True Then
            Dim SAPI
            SAPI = CreateObject("SAPI.spvoice")
            If WheelController.letterControlList.Count > 1 Then
                If total > 0 Then
                    SAPI.Speak("All right. You get " & (WheelController.spinResult * WheelController.letterControlList.Count) & "for the " & WheelController.currentLetter & "'s. You'd be risking " & total.ToString() & " dollars to see if there's 10,000 dollars back there. It's a 50 50 chance. What do you want to do?")
                Else
                    SAPI.Speak("All right. You get " & (WheelController.spinResult * WheelController.letterControlList.Count) & "for the " & WheelController.currentLetter & "'s. You wouldn't be risking anything to see if there's 10,000 dollars back there. It's a 50 50 chance. What do you want to do?")
                End If
            ElseIf WheelController.letterControlList.Count = 1 Then
                If total > 0 Then
                    SAPI.Speak("All right. You get " & (WheelController.spinResult * WheelController.letterControlList.Count) & "for the " & WheelController.currentLetter & ". You'd be risking " & total.ToString() & " dollars to see if there's 10,000 dollars back there. It's a 50 50 chance. What do you want to do?")
                Else
                    SAPI.Speak("All right. You get " & (WheelController.spinResult * WheelController.letterControlList.Count) & "for the " & WheelController.currentLetter & ". You wouldn't be risking anything to see if there's 10,000 dollars back there. It's a 50 50 chance. What do you want to do?")
                End If
            Else
            End If
        End If
    End Sub
End Class
