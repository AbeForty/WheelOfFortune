Public Class frmCompendium
    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dlgPauseMenu.Hide()
        frmScore.Hide()
        Me.BringToFront()
        loadDates()
    End Sub

    Private Sub btnStartGame_Click(sender As Object, e As EventArgs) Handles btnStartGame.Click
        If cboDate.SelectedItem <> Nothing Then
            loadCompendiumPuzzles()
        Else
            MsgBox("Please select a date.", vbCritical, "Wheel of Fortune")
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub loadDates()
        cboDate.Items.Clear()
        lstPuzzle.Items.Clear()
        wbCompendium.Navigate("https://sites.google.com/site/wheeloffortunepuzzlecompendium/home/compendium/season-" & numSeason.Value & "-compendium")
    End Sub

    Private Sub wbCompendium_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles wbCompendium.DocumentCompleted
        Dim int As Integer = 0
        For i As Integer = 5 To wbCompendium.Document.GetElementsByTagName("Table")(2).GetElementsByTagName("tr").Item(0).GetElementsByTagName("td").Count
            lstPuzzle.Items.Add(wbCompendium.Document.GetElementsByTagName("Table")(2).GetElementsByTagName("tr").Item(int).GetElementsByTagName("td").Item(i).InnerText)
            If wbCompendium.Document.GetElementsByTagName("Table")(2).GetElementsByTagName("tr").Item(int).GetElementsByTagName("td").Item(i).InnerText.Contains("/") And Not Trim(wbCompendium.Document.GetElementsByTagName("Table")(2).GetElementsByTagName("tr").Item(int).GetElementsByTagName("td").Item(i).InnerText) = "Song/Artist" And Not Trim(wbCompendium.Document.GetElementsByTagName("Table")(2).GetElementsByTagName("tr").Item(int).GetElementsByTagName("td").Item(i).InnerText) = "Title/Author" Then
                If Not cboDate.Items.Contains(Trim(wbCompendium.Document.GetElementsByTagName("Table")(2).GetElementsByTagName("tr").Item(int).GetElementsByTagName("td").Item(i).InnerText)) Then
                    cboDate.Items.Add(Trim(wbCompendium.Document.GetElementsByTagName("Table")(2).GetElementsByTagName("tr").Item(int).GetElementsByTagName("td").Item(i).InnerText))
                End If
            End If
        Next
        'lstPuzzle.DataSource = wbCompendium.Document.GetElementsByTagName("Table")(2).GetElementsByTagName("tr")
        'MsgBox("Hello")
    End Sub
    Private Sub loadCompendiumPuzzles()
        Try
            If wbCompendium.ReadyState = WebBrowserReadyState.Complete Or wbCompendium.ReadyState = WebBrowserReadyState.Loaded Then
                'Dim tossUpNumber = 1
                Dim roundNumber = 1
                'Dim trillonNumber = 1
                'Dim roundString = ""
                Dim listIndex As Integer = 0
                Dim puzzleList As New List(Of String)
                Dim allPuzzleList As New List(Of List(Of String))
                For Each item As String In lstPuzzle.Items
                    If item.Contains("(") Or item.Contains(")") Then
                        item.Replace(item.Substring(item.IndexOf("(")), "")
                    End If
                    If Trim(item) = "T1" Or Trim(item) = "T2" Or Trim(item) = "T3" Then
                        puzzleList.Add(Trim(item.Replace("T", "TU")).ToUpper)
                    ElseIf Trim(item) = "BR" Then
                        puzzleList.Add(Trim(item.Replace("*", "").Replace("&amp;", "&")).Replace("^", "").ToUpper)
                    Else
                        puzzleList.Add(Trim(item.Replace("*", "").Replace("&amp;", "&")).Replace("^", "").ToUpper)
                        roundNumber += 1
                    End If
                    listIndex += 1
                    If puzzleList.Count > 0 And listIndex Mod 4 = 0 Then
                        Dim puzzleListFinal As New List(Of String)
                        For Each strItem As String In puzzleList
                            puzzleListFinal.Add(strItem)
                        Next
                        allPuzzleList.Add(puzzleListFinal)
                        puzzleList.Clear()
                    Else
                    End If
                Next
                For Each item As List(Of String) In allPuzzleList
                    If Trim(item(2)) = Trim(cboDate.SelectedItem.ToString().Replace("*", "")) Then
                        If Trim(item(0)).Contains("(") Or Trim(item(0)).Contains(")") Then
                            item(0) = item(0).Replace(item(0).Substring(item(0).IndexOf("(")), "").Replace(vbCrLf, "")
                        End If
                        WheelController.dailyPuzzleList.Add(item)
                    End If
                Next
                For Each item As List(Of String) In WheelController.dailyPuzzleList
                    If Trim(item(3)) <> "BR" Then
                        roundNumber += 1
                        WheelController.highestRoundString = Trim(item(3))
                    Else
                        Exit For
                    End If
                Next
                WheelController.season = numSeason.Value
                'My.Computer.Audio.Stop()
                'frmMain.Close()
                'IntroScreen.Show()
                'frmNewGame.Close()
                Me.Close()
            Else

            End If
        Catch ex As Exception
            MsgBox("An error occurred while loading puzzles.", vbCritical, "Wheel of Fortune")
        End Try
    End Sub

    Private Sub lstPuzzle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstPuzzle.SelectedIndexChanged
        MsgBox(CType(sender, ListBox).SelectedIndex)
    End Sub

    Private Sub numSeason_ValueChanged(sender As Object, e As EventArgs) Handles numSeason.ValueChanged
        loadDates()
    End Sub
End Class
