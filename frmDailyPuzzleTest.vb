Public Class frmDailyPuzzleTest
    Dim numberOfTries As Integer = 0
    Private Sub frmDailyPuzzleTest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        wbPuzzle.Navigate("www.wheeloffortunesolutions.com/bonuspuzzle.html")
    End Sub
    Private Sub getDailyPuzzles()
        Try
            If wbPuzzle.ReadyState = WebBrowserReadyState.Complete Or wbPuzzle.ReadyState = WebBrowserReadyState.Loaded Then
                lblDownloadingPuzzles.Text = "Extracting Puzzles..."
                Dim tossUpNumber = 1
                Dim roundNumber = 1
                Dim trillonNumber = 0
                For Each item As HtmlElement In wbPuzzle.Document.GetElementsByTagName("Table")
                    For Each subitem As HtmlElement In item.Children
                        For Each subitem2 As HtmlElement In subitem.Children
                            Dim puzzleList As New List(Of String)
                            For Each subitem3 As HtmlElement In subitem2.GetElementsByTagName("Th")
                                If subitem3.InnerText.Contains("Tossup") Then
                                    puzzleList.Add("TU" & tossUpNumber)
                                    tossUpNumber += 1
                                ElseIf subitem3.InnerText.Contains("Wheel Spin Puzzle") Then
                                    puzzleList.Add("R" & roundNumber)
                                    roundNumber += 1
                                ElseIf subitem3.InnerText.Contains("Bonus") Then
                                    puzzleList.Add("BR")
                                End If
                            Next
                            For Each subitem4 As HtmlElement In subitem2.GetElementsByTagName("Div")
                                puzzleList.Add(subitem4.InnerText.ToUpper)
                            Next
                            If subitem2.GetElementsByTagName("Table").Count = 0 Then
                                For Each subitem5 As HtmlElement In subitem2.GetElementsByTagName("Strong")
                                    puzzleList.Add(subitem5.InnerText)
                                Next
                            Else
                                Dim crosswordString = ""
                                Dim currentRow = 1
                                For Each subitem5 As HtmlElement In subitem2.GetElementsByTagName("Table")
                                    For Each subitem6 As HtmlElement In subitem5.GetElementsByTagName("Tr")
                                        For Each subitem7 As HtmlElement In subitem6.GetElementsByTagName("Td")
                                            If subitem7.InnerText <> "" Then
                                                crosswordString &= subitem7.InnerText & trillonNumber & " "
                                            End If
                                            trillonNumber += 1
                                        Next
                                        If currentRow = 2 Then
                                            trillonNumber += 1
                                        End If
                                        currentRow += 1
                                    Next
                                Next
                                puzzleList.Add(crosswordString)
                            End If
                            If puzzleList.Count > 0 Then
                                Dim newListViewItem As New ListViewItem
                                newListViewItem.Text = puzzleList(0)
                                For i As Integer = 1 To 2
                                    Dim newSubViewItem As New ListViewItem.ListViewSubItem
                                    newSubViewItem.Text = puzzleList(i)
                                    newListViewItem.SubItems.Add(newSubViewItem)
                                Next
                                lstViewPuzzle.Items.Add(newListViewItem)
                            Else
                            End If
                        Next
                    Next
                Next
            Else
                lblDownloadingPuzzles.Text = "Waiting for server..."
            End If
        Catch ex As Exception
            MsgBox("Today's puzzles failed to load. The server may be experiencing issues.", vbExclamation, "Wheel of Fortune")
        End Try
    End Sub
    Private Sub loadDailyPuzzles()
        Try
            If wbPuzzle.ReadyState = WebBrowserReadyState.Complete Or wbPuzzle.ReadyState = WebBrowserReadyState.Loaded Then
                lblDownloadingPuzzles.Text = "Extracting Puzzles..."
                Dim tossUpNumber = 1
                Dim roundNumber = 1
                Dim trillonNumber = 0
                Dim roundString = ""
                For Each item As HtmlElement In wbPuzzle.Document.GetElementsByTagName("Table")
                    For Each subitem As HtmlElement In item.Children
                        For Each subitem2 As HtmlElement In subitem.Children
                            Dim puzzleList As New List(Of String)
                            For Each subitem3 As HtmlElement In subitem2.GetElementsByTagName("Th")
                                If subitem3.InnerText.Contains("Tossup") Then
                                    puzzleList.Add("TU" & tossUpNumber)
                                    roundString = "TU" & tossUpNumber
                                    tossUpNumber += 1
                                ElseIf subitem3.InnerText.Contains("Wheel Spin Puzzle") Then
                                    puzzleList.Add("R" & roundNumber)
                                    roundString = "R" & roundNumber
                                    roundNumber += 1
                                    WheelController.highestRoundString = roundString
                                ElseIf subitem3.InnerText.Contains("Bonus") Then
                                    puzzleList.Add("BR")
                                    roundString = "BR"
                                End If
                            Next
                            For Each subitem4 As HtmlElement In subitem2.GetElementsByTagName("Div")
                                puzzleList.Add(subitem4.InnerText.ToUpper)
                            Next
                            If subitem2.GetElementsByTagName("Table").Count = 0 Then
                                For Each subitem5 As HtmlElement In subitem2.GetElementsByTagName("Strong")
                                    puzzleList.Add(subitem5.InnerText)
                                Next
                            Else
                                Dim crosswordString = ""
                                Dim currentRow = 1
                                For Each subitem5 As HtmlElement In subitem2.GetElementsByTagName("Table")
                                    For Each subitem6 As HtmlElement In subitem5.GetElementsByTagName("Tr")
                                        For Each subitem7 As HtmlElement In subitem6.GetElementsByTagName("Td")
                                            If subitem7.InnerText <> "" Then
                                                'If trillonNumber < 14 Then
                                                crosswordString &= subitem7.InnerText & trillonNumber & " "
                                                'ElseIf trillonNumber >= 14 And trillonNumber < 42 Then
                                                '    crosswordString &= subitem7.InnerText & trillonNumber - 1 & " "
                                                'Else
                                                '    crosswordString &= subitem7.InnerText & trillonNumber & " "
                                                'End If
                                            End If
                                            'If (trillonNumber = 13 Or trillonNumber = 27 Or trillonNumber = 41) And subitem7.InnerText = "" Then
                                            'Else
                                            trillonNumber += 1
                                            'End If
                                        Next
                                        If currentRow = 2 Then
                                            trillonNumber += 1
                                        End If
                                        currentRow += 1
                                    Next
                                Next
                                puzzleList.Add(crosswordString)
                            End If
                            If puzzleList.Count > 0 Then
                                '    Dim newListViewItem As New ListViewItem
                                '    newListViewItem.Text = puzzleList(0)
                                '    For i As Integer = 1 To 2
                                '        Dim newSubViewItem As New ListViewItem.ListViewSubItem
                                '        newSubViewItem.Text = puzzleList(i)
                                '        newListViewItem.SubItems.Add(newSubViewItem)
                                '    Next
                                '    lstViewPuzzle.Items.Add(newListViewItem)
                                WheelController.dailyPuzzleList.Add(puzzleList)
                            Else
                            End If
                        Next
                    Next
                Next
                lblDownloadingPuzzles.Text = "Done"
                My.Computer.Audio.Stop()
                frmMain.Close()
                frmNewGame.Close()
                IntroScreen.Show()
                Me.Close()
                'ElseIf (wbPuzzle.ReadyState = WebBrowserReadyState.Interactive Or wbPuzzle.ReadyState = WebBrowserReadyState.Uninitialized) And numberOfTries < 5 Then
                '    lblDownloadingPuzzles.Text = "The operation timed out. Trying again."
                '    numberOfTries += 1
                '    wbPuzzle.Refresh()
                'ElseIf numberOfTries = 5 Then
                '    lblDownloadingPuzzles.Text = "Refreshed too many times. Closing..."
                '    Me.Close()
            Else
                lblDownloadingPuzzles.Text = "Waiting for server..."
            End If
        Catch ex As Exception
            MsgBox("Today's puzzles failed to load. The server may be experiencing issues.", vbExclamation, "Wheel of Fortune")
        End Try
    End Sub
    Private Sub btnGetPuzzles_Click(sender As Object, e As EventArgs) Handles btnGetPuzzles.Click
    End Sub
    Private Sub wbPuzzle_ProgressChanged(sender As Object, e As WebBrowserProgressChangedEventArgs) Handles wbPuzzle.ProgressChanged
        pbarPuzzleLoad.Value = e.CurrentProgress
        pbarPuzzleLoad.Maximum = e.MaximumProgress
    End Sub
    Private Sub wbPuzzle_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles wbPuzzle.DocumentCompleted
        'getDailyPuzzles()
        loadDailyPuzzles()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class