Imports System.Data.SqlClient

Public Class Player
    Public Property total As Integer = 0
    Private wedgeCardList As New SortedList(Of Wedges, Boolean)
    Private wedgeRoundList As New SortedList(Of Wedges, WheelController.PuzzleType)
    Public Property contestantName As String
    Public Property contestantID As Integer
    Public Property currentScore As Integer = 0
    Public Property playerNumber As Integer
    Dim firstLoad = True
    Public Enum Wedges
        Wild = 1
        Mystery = 2
        Million = 3
        HalfCar1 = 4
        HalfCar2 = 5
        Prize = 6
        Gift = 7
    End Enum
    Public Sub New(contestantID As Integer, playerNumber As Integer, contestantName As String, currentScore As Integer, total As Integer)
        Me.contestantName = contestantName
        Me.contestantID = contestantID
        Me.total = total
        Me.playerNumber = playerNumber
        Me.currentScore = currentScore
        addCardsOrWedges(Wedges.HalfCar1, False)
        addCardsOrWedges(Wedges.HalfCar2, False)
        addCardsOrWedges(Wedges.Million, False)
        addCardsOrWedges(Wedges.Mystery, False)
        addCardsOrWedges(Wedges.Wild, False)
        addCardsOrWedges(Wedges.Gift, False)
        addCardsOrWedges(Wedges.Prize, False)
        wedgeRoundList.Add(Wedges.HalfCar1, Nothing)
        wedgeRoundList.Add(Wedges.HalfCar2, Nothing)
        wedgeRoundList.Add(Wedges.Million, Nothing)
        wedgeRoundList.Add(Wedges.Mystery, Nothing)
        wedgeRoundList.Add(Wedges.Wild, Nothing)
        wedgeRoundList.Add(Wedges.Gift, Nothing)
        wedgeRoundList.Add(Wedges.Prize, Nothing)
        firstLoad = False
    End Sub
    Public Sub New(contestantID As Integer, playerNumber As Integer, contestantName As String)
        Me.contestantName = contestantName
        Me.contestantID = contestantID
        addCardsOrWedges(Wedges.HalfCar1, False)
        addCardsOrWedges(Wedges.HalfCar2, False)
        addCardsOrWedges(Wedges.Million, False)
        addCardsOrWedges(Wedges.Mystery, False)
        addCardsOrWedges(Wedges.Wild, False)
        addCardsOrWedges(Wedges.Gift, False)
        addCardsOrWedges(Wedges.Prize, False)
        wedgeRoundList.Add(Wedges.HalfCar1, Nothing)
        wedgeRoundList.Add(Wedges.HalfCar2, Nothing)
        wedgeRoundList.Add(Wedges.Million, Nothing)
        wedgeRoundList.Add(Wedges.Mystery, Nothing)
        wedgeRoundList.Add(Wedges.Wild, Nothing)
        wedgeRoundList.Add(Wedges.Gift, Nothing)
        wedgeRoundList.Add(Wedges.Prize, Nothing)
    End Sub
    Public Sub New(playerNumber As Integer, contestantName As String)
        Me.contestantName = contestantName
        addCardsOrWedges(Wedges.HalfCar1, False)
        addCardsOrWedges(Wedges.HalfCar2, False)
        addCardsOrWedges(Wedges.Million, False)
        addCardsOrWedges(Wedges.Mystery, False)
        addCardsOrWedges(Wedges.Wild, False)
        addCardsOrWedges(Wedges.Gift, False)
        addCardsOrWedges(Wedges.Prize, False)
        wedgeRoundList.Add(Wedges.HalfCar1, Nothing)
        wedgeRoundList.Add(Wedges.HalfCar2, Nothing)
        wedgeRoundList.Add(Wedges.Million, Nothing)
        wedgeRoundList.Add(Wedges.Mystery, Nothing)
        wedgeRoundList.Add(Wedges.Wild, Nothing)
        wedgeRoundList.Add(Wedges.Gift, Nothing)
        wedgeRoundList.Add(Wedges.Prize, Nothing)
    End Sub
    Public Sub New()
        addCardsOrWedges(Wedges.HalfCar1, False)
        addCardsOrWedges(Wedges.HalfCar2, False)
        addCardsOrWedges(Wedges.Million, False)
        addCardsOrWedges(Wedges.Mystery, False)
        addCardsOrWedges(Wedges.Wild, False)
        addCardsOrWedges(Wedges.Gift, False)
        addCardsOrWedges(Wedges.Prize, False)
        wedgeRoundList.Add(Wedges.HalfCar1, Nothing)
        wedgeRoundList.Add(Wedges.HalfCar2, Nothing)
        wedgeRoundList.Add(Wedges.Million, Nothing)
        wedgeRoundList.Add(Wedges.Mystery, Nothing)
        wedgeRoundList.Add(Wedges.Wild, Nothing)
        wedgeRoundList.Add(Wedges.Gift, Nothing)
        wedgeRoundList.Add(Wedges.Prize, Nothing)
    End Sub
    Public Sub addCardsOrWedges(wedge As Wedges, status As Boolean)
        wedgeCardList(wedge) = status
        If firstLoad = False Then
            If status = True Then
                Dim connPuzzle As SqlConnection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" & Application.StartupPath & "\WheelPuzzles.mdf;Integrated Security=True")
                wedgeRoundList(wedge) = WheelController.round
                If WheelController.quickGame = False Then
                    Dim strSQLCheck As String = "Select * From WedgePlayer WHERE PlayerID = @PlayerID and WedgeID = @WedgeID and GameID = @GameID and Round = @Round"
                    Dim strSQLCheckRdr As SqlDataReader
                    Dim cmdCheck As SqlCommand
                    Dim playerIDParam As SqlParameter = New SqlParameter("@PlayerID", contestantID)
                    Dim wedgeIDParam As SqlParameter = New SqlParameter("@WedgeID", CType(wedge, Integer))
                    Dim gameIDParam As SqlParameter = New SqlParameter("@GameID", WheelController.gameID)
                    Dim roundParam As SqlParameter = New SqlParameter("@Round", WheelController.round.ToString())
                    connPuzzle.Open()
                    cmdCheck = New SqlCommand(strSQLCheck, connPuzzle)
                    cmdCheck.Parameters.Add(playerIDParam)
                    cmdCheck.Parameters.Add(wedgeIDParam)
                    cmdCheck.Parameters.Add(gameIDParam)
                    cmdCheck.Parameters.Add(roundParam)
                    cmdCheck.CommandType = CommandType.Text
                    strSQLCheckRdr = cmdCheck.ExecuteReader()
                    If strSQLCheckRdr.HasRows = True Then
                        connPuzzle.Close()
                        Dim strSQLUpdate As String = "Update WedgePlayer Set PlayerID = @PlayerID and WedgeID = @WedgeID and GameID = @GameID and Round = @Round Where PlayerID = @PlayerID and WedgeID = @WedgeID and GameID = @GameID and Round = @Round"
                        Dim cmdUpdate As SqlCommand
                        Dim playerIDUpdateParam As SqlParameter = New SqlParameter("@PlayerID", contestantID)
                        Dim wedgeIDUpdateParam As SqlParameter = New SqlParameter("@WedgeID", CType(wedge, Integer))
                        Dim gameIDUpdateParam As SqlParameter = New SqlParameter("@GameID", WheelController.gameID)
                        Dim roundUpdateParam As SqlParameter = New SqlParameter("@Round", WheelController.round.ToString())
                        connPuzzle.Open()
                        cmdUpdate = New SqlCommand(strSQLUpdate, connPuzzle)
                        cmdUpdate.Parameters.Add(playerIDUpdateParam)
                        cmdUpdate.Parameters.Add(wedgeIDUpdateParam)
                        cmdUpdate.Parameters.Add(gameIDUpdateParam)
                        cmdUpdate.Parameters.Add(roundUpdateParam)
                        cmdUpdate.CommandType = CommandType.Text
                        cmdUpdate.ExecuteNonQuery()
                        connPuzzle.Close()
                    Else
                        connPuzzle.Close()
                        Dim strSQLInsert As String = "INSERT INTO WedgePlayer Values(@PlayerID, @WedgeID, @GameID, @Round)"
                        Dim cmdInsert As SqlCommand
                        Dim playerIDInsertParam As SqlParameter = New SqlParameter("@PlayerID", contestantID)
                        Dim wedgeIDInsertParam As SqlParameter = New SqlParameter("@WedgeID", CType(wedge, Integer))
                        Dim gameIDInsertParam As SqlParameter = New SqlParameter("@GameID", WheelController.gameID)
                        Dim roundInsertParam As SqlParameter = New SqlParameter("@Round", WheelController.round.ToString())
                        connPuzzle.Open()
                        cmdInsert = New SqlCommand(strSQLInsert, connPuzzle)
                        cmdInsert.Parameters.Add(playerIDInsertParam)
                        cmdInsert.Parameters.Add(wedgeIDInsertParam)
                        cmdInsert.Parameters.Add(gameIDInsertParam)
                        cmdInsert.Parameters.Add(roundInsertParam)
                        cmdInsert.CommandType = CommandType.Text
                        cmdInsert.ExecuteNonQuery()
                        connPuzzle.Close()
                    End If
                End If
            Else
                If WheelController.quickGame = False Then
                    Dim connPuzzle As SqlConnection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" & Application.StartupPath & "\WheelPuzzles.mdf;Integrated Security=True")
                    Dim strSQLDelete As String = "DELETE FROM WedgePlayer WHERE PlayerID = @PlayerID and WedgeID = @WedgeID and GameID = @GameID and Round = @Round"
                    Dim cmdDelete As SqlCommand
                    Dim playerIDDeleteParam As SqlParameter = New SqlParameter("@PlayerID", contestantID)
                    Dim wedgeIDDeleteParam As SqlParameter = New SqlParameter("@WedgeID", CType(wedge, Integer))
                    Dim gameIDDeleteParam As SqlParameter = New SqlParameter("@GameID", WheelController.gameID)
                    Dim roundDeleteParam As SqlParameter = New SqlParameter("@Round", WheelController.round.ToString())
                    connPuzzle.Open()
                    cmdDelete = New SqlCommand(strSQLDelete, connPuzzle)
                    cmdDelete.Parameters.Add(playerIDDeleteParam)
                    cmdDelete.Parameters.Add(wedgeIDDeleteParam)
                    cmdDelete.Parameters.Add(gameIDDeleteParam)
                    cmdDelete.Parameters.Add(roundDeleteParam)
                    cmdDelete.CommandType = CommandType.Text
                    cmdDelete.ExecuteNonQuery()
                    connPuzzle.Close()
                End If
            End If
        End If
        'If wedge = Wedges.Gift Then
        '    wedgeCardList.Add("Gift", status)
        'ElseIf wedge = Wedges.HalfCar1 Then
        '    wedgeCardList.Add("HarCar1", status)
        'ElseIf wedge = Wedges.HalfCar2 Then
        '    wedgeCardList.Add("HarCar2", status)
        'ElseIf wedge = Wedges.Million Then
        '    wedgeCardList.Add("Million", status)
        'ElseIf wedge = Wedges.Mystery Then
        '    wedgeCardList.Add("Mystery", status)
        'ElseIf wedge = Wedges.Prize Then
        '    wedgeCardList.Add("Prize", status)
        'ElseIf wedge = Wedges.Wild Then
        '    wedgeCardList.Add("Wild", status)
        'End If
    End Sub
    Public Function getWedges(wedge As Wedges) As Boolean
        Return wedgeCardList(wedge)
    End Function
    Public Function getWedgeRound(wedge As Wedges) As WheelController.PuzzleType
        If wedgeRoundList.ContainsKey(wedge) Then
            Return wedgeRoundList(wedge)
        Else
            Return Nothing
        End If
    End Function
    Public Sub savePlayer()
        Dim connPuzzle As SqlConnection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" & Application.StartupPath & "\WheelPuzzles.mdf;Integrated Security=True")
        Dim strNewSQL As String
        strNewSQL = "UPDATE GamePlayer Set Total = @total, RoundWinnings = @RoundWinnings WHERE Contestant_ID = @Contestant_ID and Game_ID = @Game_ID"
        Dim contestantcmd As SqlCommand
        Dim contestantIDParam As SqlParameter
        Dim totalParam As SqlParameter
        Dim roundWinningsParam As SqlParameter
        Dim gameParam As SqlParameter = New SqlParameter("@Game_ID", WheelController.gameID)
        contestantIDParam = New SqlParameter("@Contestant_ID", contestantID)
        totalParam = New SqlParameter("@total", total)
        roundWinningsParam = New SqlParameter("@RoundWinnings", currentScore)
        connPuzzle.Open()
        contestantcmd = New SqlCommand(strNewSQL, connPuzzle)
        contestantcmd.Parameters.Add(contestantIDParam)
        contestantcmd.Parameters.Add(gameParam)
        contestantcmd.Parameters.Add(totalParam)
        contestantcmd.Parameters.Add(roundWinningsParam)
        contestantcmd.CommandType = CommandType.Text
        contestantcmd.ExecuteNonQuery()
        connPuzzle.Close()
        If WheelController.round = WheelController.PuzzleType.BR Then
            Dim strContestantSQL As String
            strContestantSQL = "UPDATE Contestant Set Winnings += @Winnings WHERE Id = @Contestant_ID"
            Dim contestantFinalcmd As SqlCommand
            Dim contestantIDFinalParam As SqlParameter
            Dim winningsParam As SqlParameter
            contestantIDFinalParam = New SqlParameter("@Contestant_ID", contestantID)
            winningsParam = New SqlParameter("@Winnings", total)
            connPuzzle.Open()
            contestantFinalcmd = New SqlCommand(strContestantSQL, connPuzzle)
            contestantFinalcmd.Parameters.Add(contestantIDFinalParam)
            contestantFinalcmd.Parameters.Add(winningsParam)
            contestantFinalcmd.CommandType = CommandType.Text
            contestantFinalcmd.ExecuteNonQuery()
            connPuzzle.Close()
        End If
    End Sub
End Class
