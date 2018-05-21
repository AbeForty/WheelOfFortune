Public Class frmActivation
    Private Sub GenerateString(ByVal Control As Control)

        Dim ListChars As New List(Of String)({
"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", _
  "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", _
 "U", "V", "W", "X", "Y", "Z", _
"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"})
        Dim RandNumb As New Random

        Dim random1 As String = ListChars(RandNumb.Next(0, ListChars.Count - 1))

        Dim random2 As String = ListChars(RandNumb.Next(0, ListChars.Count - 1))

        Dim random3 As String = ListChars(RandNumb.Next(0, ListChars.Count - 1))

        Dim random4 As String = ListChars(RandNumb.Next(0, ListChars.Count - 1))

        Dim random5 As String = ListChars(RandNumb.Next(0, ListChars.Count - 1))
        Dim random6 As String = ListChars(RandNumb.Next(0, ListChars.Count - 1))

        Dim random7 As String = ListChars(RandNumb.Next(0, ListChars.Count - 1))

        Dim random8 As String = ListChars(RandNumb.Next(0, ListChars.Count - 1))
        Dim random9 As String = ListChars(RandNumb.Next(0, ListChars.Count - 1))
        Dim random10 As String = ListChars(RandNumb.Next(0, ListChars.Count - 1))
        Dim random11 As String = ListChars(RandNumb.Next(0, ListChars.Count - 1))
        Dim random12 As String = ListChars(RandNumb.Next(0, ListChars.Count - 1))
        Dim random13 As String = ListChars(RandNumb.Next(0, ListChars.Count - 1))
        Dim random14 As String = ListChars(RandNumb.Next(0, ListChars.Count - 1))
        Dim random15 As String = ListChars(RandNumb.Next(0, ListChars.Count - 1))
        Dim random16 As String = ListChars(RandNumb.Next(0, ListChars.Count - 1))
        Dim random17 As String = ListChars(RandNumb.Next(0, ListChars.Count - 1))
        Dim random18 As String = ListChars(RandNumb.Next(0, ListChars.Count - 1))
        Dim random19 As String = ListChars(RandNumb.Next(0, ListChars.Count - 1))
        Dim random20 As String = ListChars(RandNumb.Next(0, ListChars.Count - 1))
        Dim random21 As String = ListChars(RandNumb.Next(0, ListChars.Count - 1))
        Dim random22 As String = ListChars(RandNumb.Next(0, ListChars.Count - 1))
        Dim random23 As String = ListChars(RandNumb.Next(0, ListChars.Count - 1))
        Dim random24 As String = ListChars(RandNumb.Next(0, ListChars.Count - 1))
        Dim random25 As String = ListChars(RandNumb.Next(0, ListChars.Count - 1))
        Dim History As New List(Of String)

        Dim GeneratedString As String = random1 & random2 & random3 & random4 & random5 & "-" & random6 & random7 & random8 & random9 & random10 & "-" & random11 & random12 & random13 & random14 & random15 & "-" & random16 & random17 & random18 & random19 & random20 & "-" & random21 & random22 & random23 & random24 & random25
        GeneratedString = random1 & random2 & random3 & random4 & random5 & "-" & random6 & random7 & random8 & random9 & random10 & "-" & random11 & random12 & random13 & random14 & random15 & "-" & random16 & random17 & random18 & random19 & random20 & "-" & random21 & random22 & random23 & random24 & random25
        Control.Text = GeneratedString
        My.Settings.productKey = GeneratedString
        My.Settings.computerName = My.Computer.Name
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        GenerateString(txtKey)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtKey.BackColor = Color.FromKnownColor(KnownColor.Control)
        txtKey.ForeColor = Color.DeepSkyBlue
        txtKey.ReadOnly = True
        'Button3.ForeColor = Color.Gray
        Timer1.Start()
    End Sub

    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        txtKey.Copy()
        MsgBox("Product key has been copied to your clipboard", vbInformation, "Activation")
    End Sub


    Private Sub txtKey_DoubleClick(sender As Object, e As EventArgs) Handles txtKey.DoubleClick
        txtKey.Copy()
        MsgBox("Product key has been copied to your clipboard", vbInformation, "Activation")
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If txtKey.Text = "" Then
            btnCopy.Enabled = False
            btnCopy.ForeColor = Color.Gray
        ElseIf Not txtKey.Text = "" Then
            btnCopy.Enabled = True
            btnCopy.ForeColor = Color.DeepSkyBlue
        End If
    End Sub

    Private Sub btnCopy_EnabledChanged(sender As Object, e As EventArgs) Handles btnCopy.EnabledChanged
        btnCopy.ForeColor = Color.DeepSkyBlue
    End Sub
End Class
