Public Class ExpressDialog

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnYes_Click(sender As Object, e As EventArgs) Handles btnYes.Click
        frmPuzzleBoard.logoExpress.Show()
        frmPuzzleBoard.btnSpinner.Enabled = False
        frmPuzzleBoard.wheelTilt.Enabled = False
        WheelController.expressStatus = True
        WheelController.spinResult = 1000
        frmAudio.playExpress(True)
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

    Private Sub ExpressDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If WheelController.virtualHost = True Then
            Dim SAPI
            SAPI = CreateObject("SAPI.spvoice")
            SAPI.Speak("All right. Here's the situation. You can hop on the Express and keep calling consonants or buy vowels without spinning. Each consonant would be worth $1000. If you miss a letter, it's a bankrupt. Do you want to hop onto the Express?")
        End If
    End Sub
End Class
