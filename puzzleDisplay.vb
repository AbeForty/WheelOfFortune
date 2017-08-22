Public Class puzzleDisplay
    Public Property category As String
        Get
            Return lblCategory.Text
        End Get
        Set(value As String)
            lblCategory.Text = value
        End Set
    End Property
    Public Property puzzle As String
        Get
            Return lblPuzzle.Text
        End Get
        Set(value As String)
            lblPuzzle.Text = value
        End Set
    End Property
    Public Property round As String
        Get
            Return lblRound.Text
        End Get
        Set(value As String)
            lblRound.Text = value
        End Set
    End Property

    Private Sub pboxEdit_Click(sender As Object, e As EventArgs) Handles pboxEdit.Click
        If frmCustomizer.cboCategory.Items.Contains(lblCategory.Text) Then
            frmCustomizer.cboCategory.SelectedItem = lblCategory.Text
        Else
            frmCustomizer.cboCategory.SelectedItem = "CROSSWORD"
            frmCustomizer.txtCrosswordClue.Show()
            frmCustomizer.txtCrosswordClue.Text = lblCategory.Text
        End If
        frmCustomizer.txtPuzzle.Text = lblPuzzle.Text
        frmCustomizer.cboRound.Text = lblRound.Text
    End Sub
End Class
