Imports System.Data.SqlClient

Public Class frmCustomizer
    Public currentRound As WheelController.PuzzleType
    Public currentPuzzle As String
    Dim bonusRoundIndex = 0
    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        preview()
        If cboRound.SelectedItem = Nothing Then
            Exit Sub
        End If
        frmPuzzleBoard.Show()
        WheelController.round = currentRound
        WheelController.previewMode = True
        WheelController.previewPlay = False
        frmPuzzleBoard.btnPreview.Show()
        'frmPuzzleBoard.CategoryStrip1.Show()
        frmPuzzleBoard.btnSolve.Hide()
        frmPuzzleBoard.wheelTilt.Hide()
    End Sub
    Private Sub btnPlay_Click(sender As Object, e As EventArgs) Handles btnPlay.Click
        preview()
        If cboRound.SelectedItem = Nothing Then
            Exit Sub
        End If
        frmPuzzleBoard.Show()
        WheelController.round = currentRound
        WheelController.previewMode = True
        WheelController.previewPlay = True
        frmPuzzleBoard.btnPreview.Show()
        VariableTesting.Show()
        'frmPuzzleBoard.CategoryStrip1.Show()
    End Sub
    Private Sub preview()
        WheelController.virtualHost = False
        If cboCategory.SelectedItem = Nothing Then
            MsgBox("Please select a category.", vbCritical, "Wheel of Fortune")
            Exit Sub
        End If
        If cboCategory.SelectedItem.ToString() <> "CROSSWORD" Or cboPack.Text.ToUpper = "DISNEY WHEEL OF FORTUNE" Then
            WheelController.crosswordStatus = 0
            If cboRound.SelectedItem = Nothing Then
                MsgBox("Please select the round number.", vbCritical, "Wheel of Fortune")
                Exit Sub
            ElseIf cboRound.SelectedItem.ToString = "TOSS-UP 1" Then
                currentRound = WheelController.PuzzleType.TU1
                '    WheelController.loadPuzzle(WheelController.PuzzleType.TU1, WheelController.wheelMode.Classic, True)
            ElseIf cboRound.SelectedItem.ToString = "TOSS-UP 2" Then
                currentRound = WheelController.PuzzleType.TU2
                ' WheelController.loadPuzzle(WheelController.PuzzleType.TU2, WheelController.wheelMode.Classic, True)
            ElseIf cboRound.SelectedItem.ToString = "TOSS-UP 3" Then
                currentRound = WheelController.PuzzleType.TU3
                '  WheelController.loadPuzzle(WheelController.PuzzleType.TU3, WheelController.wheelMode.Classic, True)
            ElseIf cboRound.SelectedItem.ToString = "ROUND 1" Then
                currentRound = WheelController.PuzzleType.R1
                ' WheelController.loadPuzzle(WheelController.PuzzleType.R1, WheelController.wheelMode.Classic, True)
            ElseIf cboRound.SelectedItem.ToString = "ROUND 2" Then
                currentRound = WheelController.PuzzleType.R2
                ' WheelController.loadPuzzle(WheelController.PuzzleType.R2, WheelController.wheelMode.Classic, True)
            ElseIf cboRound.SelectedItem.ToString = "ROUND 3" Then
                currentRound = WheelController.PuzzleType.R3
                ' WheelController.loadPuzzle(WheelController.PuzzleType.R3, WheelController.wheelMode.Classic, True)
            ElseIf cboRound.SelectedItem.ToString = "ROUND 4" Then
                currentRound = WheelController.PuzzleType.R4
                'WheelController.loadPuzzle(WheelController.PuzzleType.R4, WheelController.wheelMode.Classic, True)
            ElseIf cboRound.SelectedItem.ToString = "ROUND 5" Then
                currentRound = WheelController.PuzzleType.R5
                ' WheelController.loadPuzzle(WheelController.PuzzleType.R5, WheelController.wheelMode.Classic, True)
            ElseIf cboRound.SelectedItem.ToString = "ROUND 6" Then
                currentRound = WheelController.PuzzleType.R6
                '  WheelController.loadPuzzle(WheelController.PuzzleType.R6, WheelController.wheelMode.Classic, True)
            ElseIf cboRound.SelectedItem.ToString = "ROUND 7" Then
                currentRound = WheelController.PuzzleType.R7
                ' WheelController.loadPuzzle(WheelController.PuzzleType.R7, WheelController.wheelMode.Classic, True)
            ElseIf cboRound.SelectedItem.ToString = "ROUND 8" Then
                currentRound = WheelController.PuzzleType.R8
                'WheelController.loadPuzzle(WheelController.PuzzleType.R8, WheelController.wheelMode.Classic, True)
            ElseIf cboRound.SelectedItem.ToString = "ROUND 9" Then
                currentRound = WheelController.PuzzleType.R9
                ' WheelController.loadPuzzle(WheelController.PuzzleType.R9, WheelController.wheelMode.Classic, True)
            ElseIf cboRound.SelectedItem.ToString = "BONUS ROUND OPTION 1" Or cboRound.SelectedItem.ToString = "BONUS ROUND OPTION 2" Or cboRound.SelectedItem.ToString = "BONUS ROUND OPTION 3" Then
                currentRound = WheelController.PuzzleType.BR
                'WheelController.loadPuzzle(WheelController.PuzzleType.BR, WheelController.wheelMode.Classic, True)
            End If
        Else
            WheelController.crosswordStatus = 1
            If cboRound.SelectedItem = Nothing Then
                MsgBox("Please select the round number.", vbCritical, "Wheel of Fortune")
                Exit Sub
            ElseIf cboRound.SelectedItem.ToString = "ROUND 1" Then
                currentRound = WheelController.PuzzleType.R1
                'WheelController.loadPuzzle(WheelController.PuzzleType.R1, WheelController.wheelMode.Classic, True)
            ElseIf cboRound.SelectedItem.ToString = "ROUND 2" Then
                currentRound = WheelController.PuzzleType.R2
                'WheelController.loadPuzzle(WheelController.PuzzleType.R2, WheelController.wheelMode.Classic, True)
            ElseIf cboRound.SelectedItem.ToString = "ROUND 3" Then
                currentRound = WheelController.PuzzleType.R3
                'WheelController.loadPuzzle(WheelController.PuzzleType.R3, WheelController.wheelMode.Classic, True)
            End If
        End If
        If cboRound.SelectedItem = Nothing Then
            MsgBox("Please select the round number.", vbCritical, "Wheel of Fortune")
            Exit Sub
        Else
        End If
    End Sub
    Private Sub cboPack_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboPack.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If Not cboPack.Items.Contains(cboPack.Text) Then
                If Not cboPack.Text.ToUpper = "DISNEY WHEEL OF FORTUNE" Then
                    cboPack.Items.Add(cboPack.Text)
                Else
                    MsgBox("Disney Wheel of Fortune is a special bonus pack. You may not modify or overwrite it.", vbExclamation, "Wheel of Fortune")
                End If
            End If
        End If
    End Sub
    Private Function checkIfExists() As Boolean
        If cboPack.Text.ToUpper = "DISNEY WHEEL OF FORTUNE" Then
            MsgBox("Disney Wheel of Fortune is a special bonus pack. You may not modify or overwrite it.", vbExclamation, "Wheel of Fortune")
            Exit Function
        End If
        Dim connPuzzle As SqlConnection
        connPuzzle = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" & Application.StartupPath & "\WheelPuzzles.mdf;Integrated Security=True")
        Dim strSQL As String
        strSQL = "SELECT * FROM PUZZLE WHERE Puzzle = @Puzzle AND Type = @Type and RoundNumber = @RoundNumber and PackName = @PackName"
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
        ElseIf cboRound.SelectedItem.ToString = "BONUS ROUND OPTION 1" Or cboRound.SelectedItem.ToString = "BONUS ROUND OPTION 2" Or cboRound.SelectedItem.ToString = "BONUS ROUND OPTION 3" Then
            typeParam = New SqlParameter("@Type", 2)
            roundNumberParam = New SqlParameter("@RoundNumber", 1)
        End If
        Dim packNameParam As SqlParameter = New SqlParameter("@PackName", cboPack.Text)
        Dim puzzleParam As SqlParameter = New SqlParameter("@Puzzle", currentPuzzle)
        connPuzzle.Open()
        cmd = New SqlCommand(strSQL, connPuzzle)
        cmd.Parameters.Add(typeParam)
        cmd.Parameters.Add(roundNumberParam)
        cmd.Parameters.Add(packNameParam)
        cmd.Parameters.Add(puzzleParam)
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
        If My.Computer.Name <> "ACSURFACE" And My.Computer.Name <> "ACSURFACEPRO" Then
            strSQL = "SELECT * FROM PUZZLE WHERE PACKNAME != 'DISNEY WHEEL OF FORTUNE'"
        Else
            strSQL = "SELECT * FROM PUZZLE"
        End If
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader
        connPuzzle.Open()
        cmd = New SqlCommand(strSQL, connPuzzle)
        cmd.CommandType = CommandType.Text
        rdr = cmd.ExecuteReader()

        Do While rdr.Read()
            If Not cboPackSelect.Items.Contains(Trim(rdr("PackName")).ToString) Then
                cboPack.Items.Add(Trim(rdr("PackName")).ToString)
                cboPackSelect.Items.Add(Trim(rdr("PackName")).ToString)
            End If
        Loop
        connPuzzle.Close()
    End Sub
    Private Sub getPuzzles(packName As String)
        bonusRoundIndex = 0
        flpPuzzleList.Controls.Clear()
        'For Each puzzleDisplayControl As Control In flpPuzzleList.Controls
        '    flpPuzzleList.Controls.Remove(puzzleDisplayControl)
        'Next
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
                bonusRoundIndex += 1
                'MsgBox("Category: " & puzzleControl.category & " Puzzle: " & puzzleControl.puzzle & " Type: " & Trim(rdr("Type")) & " bonusRoundIndex: " & bonusRoundIndex)
                puzzleControl.round = "BONUS ROUND OPTION " & bonusRoundIndex
            Else
                puzzleControl.round = "ROUND " & Trim(rdr("RoundNumber"))
            End If
            flpPuzzleList.Controls.Add(puzzleControl)
        Loop
        connPuzzle.Close()
    End Sub
    Private Sub updatePuzzle()
        If cboPack.Text.ToUpper = "DISNEY WHEEL OF FORTUNE" Then
            MsgBox("Disney Wheel of Fortune is a special bonus pack. You may not modify or overwrite it.", vbExclamation, "Wheel of Fortune")
            Exit Sub
        End If
        Dim connPuzzle As SqlConnection
        connPuzzle = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" & Application.StartupPath & "\WheelPuzzles.mdf;Integrated Security=True")
        Dim strSQL As String
        strSQL = "UPDATE Puzzle Set Category = @Category, Puzzle = @Puzzle Where Puzzle = @oldPuzzle and Type = @Type and RoundNumber = @RoundNumber and PackName = @PackName and Crossword = @CrosswordStatus"
        Dim cmd As SqlCommand
        Dim categoryParam As SqlParameter
        Dim crosswordParam As SqlParameter
        If cboCategory.SelectedItem <> "CROSSWORD" Then
            If chk80sPuzzle.Checked = False Then
                categoryParam = New SqlParameter("@Category", cboCategory.SelectedItem.ToString)
                crosswordParam = New SqlParameter("@CrosswordStatus", 0)
            Else
                categoryParam = New SqlParameter("@Category", ("80's " & cboCategory.SelectedItem.ToString))
                crosswordParam = New SqlParameter("@CrosswordStatus", 0)
            End If
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
        ElseIf cboRound.SelectedItem.ToString = "BONUS ROUND OPTION 1" Or cboRound.SelectedItem.ToString = "BONUS ROUND OPTION 2" Or cboRound.SelectedItem.ToString = "BONUS ROUND OPTION 3" Then
            typeParam = New SqlParameter("@Type", 2)
            roundNumberParam = New SqlParameter("@RoundNumber", 1)
        End If
        Dim packNameParam As SqlParameter = New SqlParameter("@PackName", cboPack.Text)
        Dim oldPuzzleParam As SqlParameter = New SqlParameter("@oldPuzzle", currentPuzzle)
        connPuzzle.Open()
        cmd = New SqlCommand(strSQL, connPuzzle)
        cmd.Parameters.Add(categoryParam)
        cmd.Parameters.Add(puzzleParam)
        cmd.Parameters.Add(typeParam)
        cmd.Parameters.Add(roundNumberParam)
        cmd.Parameters.Add(packNameParam)
        cmd.Parameters.Add(crosswordParam)
        cmd.Parameters.Add(oldPuzzleParam)
        cmd.CommandType = CommandType.Text
        cmd.ExecuteNonQuery()
        connPuzzle.Close()
        getPuzzles(cboPack.SelectedItem.ToString())
    End Sub
    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        If cboPack.Text.ToUpper = "DISNEY WHEEL OF FORTUNE" Then
            MsgBox("Disney Wheel of Fortune is a special bonus pack. You may not modify or overwrite it.", vbExclamation, "Wheel of Fortune")
            Exit Sub
        End If
        If cboPack.Text = "" Then
            MsgBox("Please enter or select a pack.", vbCritical, "Wheel of Fortune")
            Exit Sub
        End If
        If currentPuzzle = Nothing Then
            currentPuzzle = txtPuzzle.Text
        Else

        End If
        If cboCategory.SelectedItem = "CROSSWORD" And WheelController.validateCrossword(txtPuzzle.Text) = True Then
        ElseIf cboCategory.SelectedItem = "CROSSWORD" And WheelController.validateCrossword(txtPuzzle.Text) = False Then
            MsgBox("The crossword does not match the correct format. Please try again.", vbCritical, "Wheel of Fortune")
            Exit Sub
        End If
        If checkIfExists() = False Then
            Dim connPuzzle As SqlConnection
            connPuzzle = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" & Application.StartupPath & "\WheelPuzzles.mdf;Integrated Security=True")
            Dim strSQL As String
            strSQL = "INSERT INTO PUZZLE VALUES (@Category, @Puzzle, @Type, @RoundNumber, @PackName, @CrosswordStatus)"
            Dim cmd As SqlCommand
            Dim categoryParam As SqlParameter
            Dim crosswordParam As SqlParameter
            If cboCategory.SelectedItem <> "CROSSWORD" Then
                If chk80sPuzzle.Checked = False Then
                    categoryParam = New SqlParameter("@Category", cboCategory.SelectedItem.ToString)
                    crosswordParam = New SqlParameter("@CrosswordStatus", 0)
                Else
                    categoryParam = New SqlParameter("@Category", ("80's " & cboCategory.SelectedItem.ToString))
                    crosswordParam = New SqlParameter("@CrosswordStatus", 0)
                End If
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
            ElseIf cboRound.SelectedItem.ToString = "BONUS ROUND OPTION 1" Or cboRound.SelectedItem.ToString = "BONUS ROUND OPTION 2" Or cboRound.SelectedItem.ToString = "BONUS ROUND OPTION 3" Then
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
        currentPuzzle = Nothing
    End Sub

    Private Sub frmCustomizer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getPackNames()
        chkCrosswordModify.Checked = True
        chkCrosswordModify.ForeColor = Color.White
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub frmCustomizer_Closing(sender As Object, e As EventArgs) Handles MyBase.Closing
        frmMain.Show()
    End Sub

    Private Sub cboPackSelect_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPackSelect.SelectedIndexChanged
        If cboPackSelect.SelectedItem.ToString = "CREATE NEW PACK" Or cboPackSelect.SelectedItem.ToString = "CREATE SINGLE PUZZLE" Or cboPackSelect.Text.ToUpper = "DISNEY WHEEL OF FORTUNE" Then
            pnlPackSelect.Hide()
            If cboPackSelect.SelectedItem.ToString = "CREATE SINGLE PUZZLE" Or cboPackSelect.Text.ToUpper = "DISNEY WHEEL OF FORTUNE" Then
                If cboPackSelect.SelectedItem.ToString = "CREATE SINGLE PUZZLE" Then
                    cboPack.Items.Add("SINGLE PUZZLE")
                    cboPack.SelectedItem = "SINGLE PUZZLE"
                ElseIf cboPackSelect.SelectedItem.ToString <> "CREATE NEW PACK" Then
                    getPuzzles(cboPackSelect.SelectedItem.ToString())
                    cboPack.SelectedItem = cboPackSelect.SelectedItem
                    txtPuzzle.Enabled = False
                    txtCrosswordClue.Enabled = False
                    cboCategory.Enabled = False
                    cboRound.Enabled = False
                End If
                btnCreate.Enabled = False
            Else
                btnCreate.Enabled = True
            End If
        Else
            pnlPackSelect.Hide()
            getPuzzles(cboPackSelect.SelectedItem.ToString())
            cboPack.SelectedItem = cboPackSelect.SelectedItem
            btnCreate.Enabled = True
            txtPuzzle.Enabled = True
            txtCrosswordClue.Enabled = True
            cboCategory.Enabled = True
            cboRound.Enabled = True
        End If
    End Sub
    Private Sub cboCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCategory.SelectedIndexChanged
        If CType(sender, ComboBox).SelectedItem = "CROSSWORD" And cboPack.Text.ToUpper <> "DISNEY WHEEL OF FORTUNE" Then
            txtCrosswordClue.Show()
            txtPuzzle.ReadOnly = True
            chkCrosswordModify.Checked = False
        ElseIf CType(sender, ComboBox).SelectedItem = "CROSSWORD" And cboPack.Text.ToUpper = "DISNEY WHEEL OF FORTUNE" Then
            CType(sender, ComboBox).Enabled = False
            txtCrosswordClue.Show()
            txtPuzzle.Enabled = True
            chkCrosswordModify.Checked = True
        Else
            txtCrosswordClue.Hide()
            txtCrosswordClue.Clear()
            txtPuzzle.ReadOnly = False
            txtPuzzle.Enabled = True
            chkCrosswordModify.Checked = True
            chkCrosswordModify.ForeColor = Color.White
        End If
    End Sub

    Private Sub txtPuzzle_Click(sender As Object, e As EventArgs) Handles txtPuzzle.Click
        If cboCategory.SelectedItem = "CROSSWORD" And txtPuzzle.ReadOnly <> False And cboPack.Text.ToUpper <> "DISNEY WHEEL OF FORTUNE" Then
            frmCrosswordCustomizer.Show()
        End If
    End Sub

    Private Sub chkCrosswordModify_Click(sender As Object, e As EventArgs) Handles chkCrosswordModify.Click
        If CType(sender, CheckBox).Checked = True Then
            If cboCategory.SelectedItem = "CROSSWORD" And cboPack.Text.ToUpper <> "DISNEY WHEEL OF FORTUNE" Then
                Dim result As Integer = MessageBox.Show("You shouldn't need to manually edit a crossword puzzle. Crossword puzzles should only be modified if the format doesn't match. Are you sure you want to edit the crossword puzzle?", "Wheel of Fortune", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.No Then
                    txtPuzzle.ReadOnly = True
                    CType(sender, CheckBox).Checked = False
                ElseIf result = DialogResult.Yes Then
                    txtPuzzle.ReadOnly = False
                End If
            End If
        Else
            If cboCategory.SelectedItem = "CROSSWORD" And cboPack.Text.ToUpper <> "DISNEY WHEEL OF FORTUNE" Then
                txtPuzzle.ReadOnly = True
            Else
                CType(sender, CheckBox).Checked = True
            End If
        End If
    End Sub

    Private Sub cboPack_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPack.SelectedIndexChanged
        If CType(sender, ComboBox).SelectedItem <> "SINGLE PUZZLE" Then
            cboPack.Items.Remove("SINGLE PUZZLE")
            getPuzzles(cboPack.SelectedItem.ToString())
            If cboPack.Text.ToUpper = "DISNEY WHEEL OF FORTUNE" Then
                btnCreate.Enabled = False
                txtPuzzle.Enabled = False
                txtCrosswordClue.Enabled = False
                cboCategory.Enabled = False
                cboRound.Enabled = False
            Else
                txtPuzzle.Enabled = True
                txtCrosswordClue.Enabled = True
                cboCategory.Enabled = True
                cboRound.Enabled = True
                btnCreate.Enabled = True
            End If
        Else
            flpPuzzleList.Controls.Clear()
        End If
    End Sub
End Class