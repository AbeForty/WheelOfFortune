Imports System.Data.SqlClient

Public Class ContestantControl
    Public contestantID As Integer
    Public contestantName As String
    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ContestantControl_Load(sender As Object, e As EventArgs) Handles Me.Load
        flpContestants.Controls.Clear()
        Dim connPuzzle As SqlConnection
        connPuzzle = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" & Application.StartupPath & "\WheelPuzzles.mdf;Integrated Security=True")
        Dim strSQL As String
        strSQL = "SELECT * FROM Contestant"
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader
        connPuzzle.Open()
        cmd = New SqlCommand(strSQL, connPuzzle)
        cmd.CommandType = CommandType.Text
        rdr = cmd.ExecuteReader()
        Do While rdr.Read()
            Dim newNameStache As New ContestantDisplay
            newNameStache.ContestantID = Trim(rdr("Id"))
            newNameStache.NameTag1.contestantID = Trim(rdr("Id"))
            newNameStache.ContestantName = Trim(rdr("Name")).ToString
            newNameStache.Total = Trim(rdr("Winnings")).ToString
            flpContestants.Controls.Add(newNameStache)
        Loop
        connPuzzle.Close()
    End Sub
End Class
