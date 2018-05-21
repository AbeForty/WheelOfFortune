Public Class LetterTypeControl
    Public currentLetter As String
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btn_Click(sender As Object, e As EventArgs) Handles btnA.Click, btnB.Click, btnC.Click, btnD.Click, btnE.Click, btnF.Click, btnG.Click, btnH.Click, btnI.Click, btnJ.Click, btnK.Click, btnL.Click, btnM.Click, btnN.Click, btnO.Click, btnP.Click, btnQ.Click, btnR.Click, btnS.Click, btnT.Click, btnU.Click, btnV.Click, btnW.Click, btnX.Click, btnY.Click, btnZ.Click, btnAmp.Click, btnExclaim.Click, btnPeriod.Click, btnColon.Click, btnDash.Click, btnApos.Click
        DialogResult = DialogResult.OK
        currentLetter = CType(sender, Button).Text
        'CType(SourceControl, PuzzleBoardLetter).letterBehind = CType(sender, Button).Text
        'CType(SourceControl, PuzzleBoardLetter).revealLetter()
    End Sub

    Private Sub btnBlank_Click(sender As Object, e As EventArgs) Handles btnBlank.Click
        DialogResult = DialogResult.OK
        currentLetter = " "
        'CType(SourceControl, PuzzleBoardLetter).letterBehind = CType(sender, Button).Text
        'CType(SourceControl, PuzzleBoardLetter).Hide()
        '715
    End Sub
End Class
