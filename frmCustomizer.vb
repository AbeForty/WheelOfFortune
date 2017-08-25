Imports System.Data.SqlClient

Public Class frmCustomizer
    Public currentRound As WheelController.PuzzleType
    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        frmPuzzleBoard.Show()
        If cboCategory.SelectedItem.ToString() <> "CROSSWORD" Then
            If cboRound.SelectedItem.ToString = "TOSS-UP 1" Then
                currentRound = WheelController.PuzzleType.TU1
                WheelController.loadPuzzle(WheelController.PuzzleType.TU1, True)
            ElseIf cboRound.SelectedItem.ToString = "TOSS-UP 2" Then
                currentRound = WheelController.PuzzleType.TU2
                WheelController.loadPuzzle(WheelController.PuzzleType.TU2, True)
            ElseIf cboRound.SelectedItem.ToString = "TOSS-UP 3" Then
                currentRound = WheelController.PuzzleType.TU3
                WheelController.loadPuzzle(WheelController.PuzzleType.TU3, True)
            ElseIf cboRound.SelectedItem.ToString = "ROUND 1" Then
                currentRound = WheelController.PuzzleType.R1
                WheelController.loadPuzzle(WheelController.PuzzleType.R1, True)
            ElseIf cboRound.SelectedItem.ToString = "ROUND 2" Then
                currentRound = WheelController.PuzzleType.R2
                WheelController.loadPuzzle(WheelController.PuzzleType.R2, True)
            ElseIf cboRound.SelectedItem.ToString = "ROUND 3" Then
                currentRound = WheelController.PuzzleType.R3
                WheelController.loadPuzzle(WheelController.PuzzleType.R3, True)
            ElseIf cboRound.SelectedItem.ToString = "ROUND 4" Then
                currentRound = WheelController.PuzzleType.R4
                WheelController.loadPuzzle(WheelController.PuzzleType.R4, True)
            ElseIf cboRound.SelectedItem.ToString = "ROUND 5" Then
                currentRound = WheelController.PuzzleType.R5
                WheelController.loadPuzzle(WheelController.PuzzleType.R5, True)
            ElseIf cboRound.SelectedItem.ToString = "ROUND 6" Then
                currentRound = WheelController.PuzzleType.R6
                WheelController.loadPuzzle(WheelController.PuzzleType.R6, True)
            ElseIf cboRound.SelectedItem.ToString = "ROUND 7" Then
                currentRound = WheelController.PuzzleType.R7
                WheelController.loadPuzzle(WheelController.PuzzleType.R7, True)
            ElseIf cboRound.SelectedItem.ToString = "ROUND 8" Then
                currentRound = WheelController.PuzzleType.R8
                WheelController.loadPuzzle(WheelController.PuzzleType.R8, True)
            ElseIf cboRound.SelectedItem.ToString = "ROUND 9" Then
                currentRound = WheelController.PuzzleType.R9
                WheelController.loadPuzzle(WheelController.PuzzleType.R9, True)
            ElseIf cboRound.SelectedItem.ToString = "BONUS ROUND" Then
                currentRound = WheelController.PuzzleType.BR
                WheelController.loadPuzzle(WheelController.PuzzleType.BR, True)
            ElseIf cboRound.SelectedItem.ToString = Nothing Then
                MsgBox("Please select the round number.", vbCritical, "Wheel of Fortune")
            End If
        Else
            If cboRound.SelectedItem.ToString = "ROUND 1" Then
                currentRound = WheelController.PuzzleType.R1
                WheelController.crosswordStatus = 1
                WheelController.loadPuzzle(WheelController.PuzzleType.R1, True)
            ElseIf cboRound.SelectedItem.ToString = "ROUND 2" Then
                currentRound = WheelController.PuzzleType.R2
                WheelController.crosswordStatus = 1
                WheelController.loadPuzzle(WheelController.PuzzleType.R2, True)
            ElseIf cboRound.SelectedItem.ToString = "ROUND 3" Then
                currentRound = WheelController.PuzzleType.R3
                WheelController.crosswordStatus = 1
                WheelController.loadPuzzle(WheelController.PuzzleType.R3, True)
            ElseIf cboRound.SelectedItem.ToString = Nothing Then
                MsgBox("Please select the round number.", vbCritical, "Wheel of Fortune")
            End If
        End If
        frmPuzzleBoard.round = currentRound
        frmPuzzleBoard.previewMode = True
        frmPuzzleBoard.btnPreview.Show()
        frmPuzzleBoard.pnlCategory.Show()
        frmPuzzleBoard.btnSolve.Hide()
        frmPuzzleBoard.wheelTilt.Hide()
    End Sub

    Private Sub cboPack_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboPack.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If Not cboPack.Items.Contains(cboPack.Text) Then
                cboPack.Items.Add(cboPack.Text)
            End If
        End If
    End Sub
    Private Function checkIfExists() As Boolean
        Dim connPuzzle As SqlConnection
        connPuzzle = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" & Application.StartupPath & "\WheelPuzzles.mdf;Integrated Security=True")
        Dim strSQL As String
        strSQL = "SELECT * FROM PUZZLE WHERE Type = @Type and RoundNumber = @RoundNumber and PackName = @PackName"
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader
        Dim typeParam As SqlParameter
        Dim roundNumberParam As SqlParameter
        If cboRound.SelectedItem.ToString = "TOSS-UP 1" Then
            typeParam = New SqlParameter("@Type", 0)
            roundNumberParam = New SqlParameter("@RoundNumber", 1)
        ElseIf cboRound.SelectedItem.ToString = "TOSS-UP 2" Then
            typeParam = New SqlParameter("@Type", 0)
            roundNumberParam = New SqlParameter("@RoundNumber", 2)
        ElseIf cboRound.SelectedItem.ToString = "TOSS-UP 3" Then
            typeParam = New SqlParameter("@Type", 0)
            roundNumberParam = New SqlParameter("@RoundNumber", 3)
        ElseIf cboRound.SelectedItem.ToString = "ROUND 1" Then
            typeParam = New SqlParameter("@Type", 1)
            roundNumberParam = New SqlParameter("@RoundNumber", 1)
        ElseIf cboRound.SelectedItem.ToString = "ROUND 2" Then
            typeParam = New SqlParameter("@Type", 1)
            roundNumberParam = New SqlParameter("@RoundNumber", 2)
        ElseIf cboRound.SelectedItem.ToString = "ROUND 3" Then
            typeParam = New SqlParameter("@Type", 1)
            roundNumberParam = New SqlParameter("@RoundNumber", 3)
        ElseIf cboRound.SelectedItem.ToString = "ROUND 4" Then
            typeParam = New SqlParameter("@Type", 1)
            roundNumberParam = New SqlParameter("@RoundNumber", 4)
        ElseIf cboRound.SelectedItem.ToString = "ROUND 5" Then
            typeParam = New SqlParameter("@Type", 1)
            roundNumberParam = New SqlParameter("@RoundNumber", 5)
        ElseIf cboRound.SelectedItem.ToString = "ROUND 6" Then
            typeParam = New SqlParameter("@Type", 1)
            roundNumberParam = New SqlParameter("@RoundNumber", 6)
        ElseIf cboRound.SelectedItem.ToString = "ROUND 7" Then
            typeParam = New SqlParameter("@Type", 1)
            roundNumberParam = New SqlParameter("@RoundNumber", 7)
        ElseIf cboRound.SelectedItem.ToString = "ROUND 8" Then
            typeParam = New SqlParameter("@Type", 1)
            roundNumberParam = New SqlParameter("@RoundNumber", 8)
        ElseIf cboRound.SelectedItem.ToString = "ROUND 9" Then
            typeParam = New SqlParameter("@Type", 1)
            roundNumberParam = New SqlParameter("@RoundNumber", 9)
        ElseIf cboRound.SelectedItem.ToString = "TIEBREAKER TOSS-UP" Then
            typeParam = New SqlParameter("@Type", 0)
            roundNumberParam = New SqlParameter("@RoundNumber", 4)
        ElseIf cboRound.SelectedItem.ToString = "BONUS ROUND" Then
            typeParam = New SqlParameter("@Type", 2)
            roundNumberParam = New SqlParameter("@RoundNumber", 1)
        End If
        Dim packNameParam As SqlParameter = New SqlParameter("@PackName", cboPack.Text)
        connPuzzle.Open()
        cmd = New SqlCommand(strSQL, connPuzzle)
        cmd.Parameters.Add(typeParam)
        cmd.Parameters.Add(roundNumberParam)
        cmd.Parameters.Add(packNameParam)
        cmd.CommandType = CommandType.Text
        rdr = cmd.ExecuteReader()

        If rdr.HasRows Then
            Return True
        Else
            Return False
        End If

        connPuzzle.Close()
        Return False
    End Function
    Private Sub getPackNames()
        Dim connPuzzle As SqlConnection
        connPuzzle = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" & Application.StartupPath & "\WheelPuzzles.mdf;Integrated Security=True")
        Dim strSQL As String
        strSQL = "SELECT * FROM PUZZLE"
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader
        connPuzzle.Open()
        cmd = New SqlCommand(strSQL, connPuzzle)
        cmd.CommandType = CommandType.Text
        rdr = cmd.ExecuteReader()
        Do While rdr.Read()
            If Not cboPack.Items.Contains(Trim(rdr("PackName")).ToString) Then
                cboPack.Items.Add(Trim(rdr("PackName")).ToString)
                cboPackSelect.Items.Add(Trim(rdr("PackName")).ToString)
            End If
        Loop
        connPuzzle.Close()
    End Sub
    Private Sub getPuzzles(packName As String)
        For Each puzzleDisplayControl As Control In flpPuzzleList.Controls
            flpPuzzleList.Controls.Remove(puzzleDisplayControl)
        Next
        Dim connPuzzle As SqlConnection
        connPuzzle = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" & Application.StartupPath & "\WheelPuzzles.mdf;Integrated Security=True")
        Dim strSQL As String
        strSQL = "SELECT * FROM PUZZLE WHERE PackName = @PackName"
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader
        Dim packNameParam As New SqlParameter("@PackName", packName)
        connPuzzle.Open()
        cmd = New SqlCommand(strSQL, connPuzzle)
        cmd.Parameters.Add(packNameParam)
        cmd.CommandType = CommandType.Text
        rdr = cmd.ExecuteReader()
        Do While rdr.Read()
            Dim puzzleControl As New puzzleDisplay
            puzzleControl.category = Trim(rdr("Category"))
            puzzleControl.puzzle = Trim(rdr("Puzzle"))
            If Trim(rdr("Type")) = 0 Then
                If Trim(rdr("RoundNumber")) = 1 Then
                    puzzleControl.round = "TOSS-UP 1"
                ElseIf Trim(rdr("RoundNumber")) = 2 Then
                    puzzleControl.round = "TOSS-UP 2"
                ElseIf Trim(rdr("RoundNumber")) = 3 Then
                    puzzleControl.round = "TOSS-UP 3"
                ElseIf Trim(rdr("RoundNumber")) = 4 Then
                    puzzleControl.round = "TIEBREAKER TOSS-UP"
                End If
            ElseIf Trim(rdr("Type")) = 2 Then
                puzzleControl.round = "BONUS ROUND"
            Else
                puzzleControl.round = "ROUND " & Trim(rdr("RoundNumber"))
            End If
            flpPuzzleList.Controls.Add(puzzleControl)
        Loop
        connPuzzle.Close()
    End Sub
    Private Sub updatePuzzle()
        Dim connPuzzle As SqlConnection
        connPuzzle = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" & Application.StartupPath & "\WheelPuzzles.mdf;Integrated Security=True")
        Dim strSQL As String
        strSQL = "UPDATE Puzzle Set Category = @Category, Puzzle= @Puzzle Where Type = @Type and RoundNumber = @RoundNumber and PackName = @PackName and Crossword = @CrosswordStatus"
        Dim cmd As SqlCommand
        Dim categoryParam As SqlParameter
        Dim crosswordParam As SqlParameter
        If cboCategory.SelectedItem <> "CROSSWORD" Then
            categoryParam = New SqlParameter("@Category", cboCategory.SelectedItem.ToString)
            crosswordParam = New SqlParameter("@CrosswordStatus", 0)
        Else
            If cboRound.SelectedItem = "ROUND 1" Or cboRound.SelectedItem = "ROUND 2" Or cboRound.SelectedItem = "ROUND 3" Then
                categoryParam = New SqlParameter("@Category", txtCrosswordClue.Text)
                crosswordParam = New SqlParameter("@CrosswordStatus", 1)
            Else
                MsgBox("Crosswords are only allowed on rounds 1, 2, and 3.", vbCritical, "Wheel of Fortune")
                Exit Sub
            End If
        End If
        Dim puzzleParam As SqlParameter = New SqlParameter("@Puzzle", txtPuzzle.Text)
        Dim typeParam As SqlParameter
        Dim roundNumberParam As SqlParameter

        If cboRound.SelectedItem.ToString = "TOSS-UP 1" Then
            typeParam = New SqlParameter("@Type", 0)
            roundNumberParam = New SqlParameter("@RoundNumber", 1)
        ElseIf cboRound.SelectedItem.ToString = "TOSS-UP 2" Then
            typeParam = New SqlParameter("@Type", 0)
            roundNumberParam = New SqlParameter("@RoundNumber", 2)
        ElseIf cboRound.SelectedItem.ToString = "TOSS-UP 3" Then
            typeParam = New SqlParameter("@Type", 0)
            roundNumberParam = New SqlParameter("@RoundNumber", 3)
        ElseIf cboRound.SelectedItem.ToString = "ROUND 1" Then
            typeParam = New SqlParameter("@Type", 1)
            roundNumberParam = New SqlParameter("@RoundNumber", 1)
        ElseIf cboRound.SelectedItem.ToString = "ROUND 2" Then
            typeParam = New SqlParameter("@Type", 1)
            roundNumberParam = New SqlParameter("@RoundNumber", 2)
        ElseIf cboRound.SelectedItem.ToString = "ROUND 3" Then
            typeParam = New SqlParameter("@Type", 1)
            roundNumberParam = New SqlParameter("@RoundNumber", 3)
        ElseIf cboRound.SelectedItem.ToString = "ROUND 4" Then
            typeParam = New SqlParameter("@Type", 1)
            roundNumberParam = New SqlParameter("@RoundNumber", 4)
        ElseIf cboRound.SelectedItem.ToString = "ROUND 5" Then
            typeParam = New SqlParameter("@Type", 1)
            roundNumberParam = New SqlParameter("@RoundNumber", 5)
        ElseIf cboRound.SelectedItem.ToString = "ROUND 6" Then
            typeParam = New SqlParameter("@Type", 1)
            roundNumberParam = New SqlParameter("@RoundNumber", 6)
        ElseIf cboRound.SelectedItem.ToString = "ROUND 7" Then
            typeParam = New SqlParameter("@Type", 1)
            roundNumberParam = New SqlParameter("@RoundNumber", 7)
        ElseIf cboRound.SelectedItem.ToString = "ROUND 7" Then
            typeParam = New SqlParameter("@Type", 1)
            roundNumberParam = New SqlParameter("@RoundNumber", 7)
        ElseIf cboRound.SelectedItem.ToString = "ROUND 8" Then
            typeParam = New SqlParameter("@Type", 1)
            roundNumberParam = New SqlParameter("@RoundNumber", 8)
        ElseIf cboRound.SelectedItem.ToString = "ROUND 9" Then
            typeParam = New SqlParameter("@Type", 1)
            roundNumberParam = New SqlParameter("@RoundNumber", 9)
        ElseIf cboRound.SelectedItem.ToString = "TIEBREAKER TOSS-UP" Then
            typeParam = New SqlParameter("@Type", 0)
            roundNumberParam = New SqlParameter("@RoundNumber", 4)
        ElseIf cboRound.SelectedItem.ToString = "BONUS ROUND" Then
            typeParam = New SqlParameter("@Type", 2)
            roundNumberParam = New SqlParameter("@RoundNumber", 1)
        End If
        Dim packNameParam As SqlParameter = New SqlParameter("@PackName", cboPack.Text)
        connPuzzle.Open()
        cmd = New SqlCommand(strSQL, connPuzzle)
        cmd.Parameters.Add(categoryParam)
        cmd.Parameters.Add(puzzleParam)
        cmd.Parameters.Add(typeParam)
        cmd.Parameters.Add(roundNumberParam)
        cmd.Parameters.Add(packNameParam)
        cmd.Parameters.Add(crosswordParam)
        cmd.CommandType = CommandType.Text
        cmd.ExecuteNonQuery()
        connPuzzle.Close()
        getPuzzles(cboPack.SelectedItem.ToString())
    End Sub
    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        If checkIfExists() = False Then
            Dim connPuzzle As SqlConnection
            connPuzzle = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" & Application.StartupPath & "\WheelPuzzles.mdf;Integrated Security=True")
            Dim strSQL As String
            strSQL = "INSERT INTO PUZZLE VALUES (@Category, @Puzzle, @Type, @RoundNumber, @PackName, @CrosswordStatus)"
            Dim cmd As SqlCommand
            Dim categoryParam As SqlParameter
            Dim crosswordParam As SqlParameter
            If cboCategory.SelectedItem <> "CROSSWORD" Then
                categoryParam = New SqlParameter("@Category", cboCategory.SelectedItem.ToString)
                crosswordParam = New SqlParameter("@CrosswordStatus", 0)
            Else
                If cboRound.SelectedItem = "ROUND 1" Or cboRound.SelectedItem = "ROUND 2" Or cboRound.SelectedItem = "ROUND 3" Then
                    categoryParam = New SqlParameter("@Category", txtCrosswordClue.Text)
                    crosswordParam = New SqlParameter("@CrosswordStatus", 1)
                Else
                    MsgBox("Crosswords are only allowed on rounds 1, 2, and 3.", vbCritical, "Wheel of Fortune")
                    Exit Sub
                End If
            End If
                Dim puzzleParam As SqlParameter = New SqlParameter("@Puzzle", txtPuzzle.Text)
            Dim typeParam As SqlParameter
            Dim roundNumberParam As SqlParameter
            If cboRound.SelectedItem.ToString = "TOSS-UP 1" Then
                typeParam = New SqlParameter("@Type", 0)
                roundNumberParam = New SqlParameter("@RoundNumber", 1)
            ElseIf cboRound.SelectedItem.ToString = "TOSS-UP 2" Then
                typeParam = New SqlParameter("@Type", 0)
                roundNumberParam = New SqlParameter("@RoundNumber", 2)
            ElseIf cboRound.SelectedItem.ToString = "TOSS-UP 3" Then
                typeParam = New SqlParameter("@Type", 0)
                roundNumberParam = New SqlParameter("@RoundNumber", 3)
            ElseIf cboRound.SelectedItem.ToString = "ROUND 1" Then
                typeParam = New SqlParameter("@Type", 1)
                roundNumberParam = New SqlParameter("@RoundNumber", 1)
            ElseIf cboRound.SelectedItem.ToString = "ROUND 2" Then
                typeParam = New SqlParameter("@Type", 1)
                roundNumberParam = New SqlParameter("@RoundNumber", 2)
            ElseIf cboRound.SelectedItem.ToString = "ROUND 3" Then
                typeParam = New SqlParameter("@Type", 1)
                roundNumberParam = New SqlParameter("@RoundNumber", 3)
            ElseIf cboRound.SelectedItem.ToString = "ROUND 4" Then
                typeParam = New SqlParameter("@Type", 1)
                roundNumberParam = New SqlParameter("@RoundNumber", 4)
            ElseIf cboRound.SelectedItem.ToString = "ROUND 5" Then
                typeParam = New SqlParameter("@Type", 1)
                roundNumberParam = New SqlParameter("@RoundNumber", 5)
            ElseIf cboRound.SelectedItem.ToString = "ROUND 6" Then
                typeParam = New SqlParameter("@Type", 1)
                roundNumberParam = New SqlParameter("@RoundNumber", 6)
            ElseIf cboRound.SelectedItem.ToString = "ROUND 7" Then
                typeParam = New SqlParameter("@Type", 1)
                roundNumberParam = New SqlParameter("@RoundNumber", 7)
            ElseIf cboRound.SelectedItem.ToString = "ROUND 7" Then
                typeParam = New SqlParameter("@Type", 1)
                roundNumberParam = New SqlParameter("@RoundNumber", 7)
            ElseIf cboRound.SelectedItem.ToString = "ROUND 8" Then
                typeParam = New SqlParameter("@Type", 1)
                roundNumberParam = New SqlParameter("@RoundNumber", 8)
            ElseIf cboRound.SelectedItem.ToString = "ROUND 9" Then
                typeParam = New SqlParameter("@Type", 1)
                roundNumberParam = New SqlParameter("@RoundNumber", 9)
            ElseIf cboRound.SelectedItem.ToString = "TIEBREAKER TOSS-UP" Then
                typeParam = New SqlParameter("@Type", 0)
                roundNumberParam = New SqlParameter("@RoundNumber", 4)
            ElseIf cboRound.SelectedItem.ToString = "BONUS ROUND" Then
                typeParam = New SqlParameter("@Type", 2)
                roundNumberParam = New SqlParameter("@RoundNumber", 1)
            End If
            Dim packNameParam As SqlParameter = New SqlParameter("@PackName", cboPack.Text)
            connPuzzle.Open()
            cmd = New SqlCommand(strSQL, connPuzzle)
            cmd.Parameters.Add(categoryParam)
            cmd.Parameters.Add(puzzleParam)
            cmd.Parameters.Add(typeParam)
            cmd.Parameters.Add(roundNumberParam)
            cmd.Parameters.Add(packNameParam)
            cmd.Parameters.Add(crosswordParam)
            cmd.CommandType = CommandType.Text
            cmd.ExecuteNonQuery()
            connPuzzle.Close()
        Else
            Dim result As Integer = MessageBox.Show("The round already has a puzzle. Would you like to replace the puzzle?", "Wheel of Fortune", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.No Then
                Exit Sub
            ElseIf result = DialogResult.Yes Then
                updatePuzzle()
            End If
        End If
        getPuzzles(cboPack.Text)
        txtCrosswordClue.Hide()
    End Sub

    Private Sub frmCustomizer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getPackNames()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub cboPackSelect_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPackSelect.SelectedIndexChanged
        If cboPackSelect.SelectedItem.ToString = "CREATE NEW PACK" Then
            pnlPackSelect.Hide()
        Else
            pnlPackSelect.Hide()
            getPuzzles(cboPackSelect.SelectedItem.ToString())
            cboPack.SelectedItem = cboPackSelect.SelectedItem
        End If
    End Sub

    Private Sub cboCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCategory.SelectedIndexChanged
        If CType(sender, ComboBox).SelectedItem = "CROSSWORD" Then
            txtCrosswordClue.Show()
        End If
    End Sub
End Class