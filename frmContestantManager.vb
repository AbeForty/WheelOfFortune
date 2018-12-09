Imports System.ComponentModel
Imports System.Data.SqlClient
Public Class frmContestantManager
    Private Sub frmContestantManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getContestantNames(False)
    End Sub

    Private Sub btnStartGame_Click(sender As Object, e As EventArgs)
        'startGame()
    End Sub

    Private Sub btnQuickStart_Click(sender As Object, e As EventArgs)
        'startGame()
    End Sub

    Private Sub chkTeams_CheckedChanged(sender As Object, e As EventArgs)
        If CType(sender, CheckBox).Checked = True Then
            WheelController.teams = True
        Else
            WheelController.teams = False
        End If
    End Sub

    Private Sub frmSettings_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If frmPuzzleBoard.Visible = False Then
            frmMain.Show()
        Else
            dlgPauseMenu.Show()
            frmScore.Show()
        End If
    End Sub
    Private Sub getContestantNames(demo As Boolean)
        Dim connPuzzle As SqlConnection
        connPuzzle = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" & Application.StartupPath & "\WheelPuzzles.mdf;Integrated Security=True")
        Dim strSQL As String
        If demo = False Then
            strSQL = "SELECT * FROM Contestant WHERE Demo = 0"
        Else
            strSQL = "SELECT * FROM Contestant WHERE Demo = 1"
        End If
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader
        connPuzzle.Open()
        cmd = New SqlCommand(strSQL, connPuzzle)
        cmd.CommandType = CommandType.Text
        rdr = cmd.ExecuteReader()
        Do While rdr.Read()
            Dim newContestant = New ContestantDisplay
            newContestant.ContestantID = Trim(rdr("Id"))
            newContestant.ContestantName = Trim(rdr("Name")).ToString
            newContestant.Total = Trim(rdr("Winnings")).ToString
            flpContestants.Controls.Add(newContestant)
        Loop
        connPuzzle.Close()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub lblNewContestant_Click(sender As Object, e As EventArgs) Handles lblNewContestant.Click
        flpContestants.Controls.Add(New ContestantDisplay)
    End Sub

    Private Sub chkDemo_CheckedChanged(sender As Object, e As EventArgs) Handles chkDemo.CheckedChanged
        flpContestants.Controls.Clear()
        If CType(sender, CheckBox).Checked = True Then
            getContestantNames(True)
        Else
            getContestantNames(False)
            flpStatistics.Controls.Clear()
            lblNoGames.Show()
            lblSelectContestant.Show()
        End If
    End Sub
End Class
