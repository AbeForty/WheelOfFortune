Imports System.ComponentModel
<DefaultEvent("Click")>
Public Class BonusCardEnvelope
    Dim revealedValue As Boolean
    Dim moneyValueEnum As MoneyValueType
    Enum MoneyValueType
        M34000
        M35000
        M40000
        M45000
        M50000
        M100000
        M1000000
        Car
    End Enum
    Public Property revealed As Boolean
        Get
            Return revealedValue
        End Get
        Set(value As Boolean)
            If value = False Then
                revealedValue = False
                Width = 317
                Height = 150
                BackgroundImage = My.Resources.WOF_RearFolded
            ElseIf value = True Then
                revealedValue = True
                Width = 317
                Height = 272
                If frmScore.lblControllerSpinResult.Text = 34000 Then
                    BackgroundImage = My.Resources.WOF_34_000
                ElseIf frmScore.lblControllerSpinResult.Text = 35000 Then
                    BackgroundImage = My.Resources.WOF_35_000
                ElseIf frmScore.lblControllerSpinResult.Text = 40000 Then
                    BackgroundImage = My.Resources.WOF_40_000
                ElseIf frmScore.lblControllerSpinResult.Text = 45000 Then
                    BackgroundImage = My.Resources.WOF_45_000
                ElseIf frmScore.lblControllerSpinResult.Text = 50000 Then
                    BackgroundImage = My.Resources.WOF_50_000
                ElseIf frmScore.lblControllerSpinResult.Text = 100000 Then
                    BackgroundImage = My.Resources.WOF_100_000
                ElseIf frmScore.lblControllerSpinResult.Text = 1000000 Then
                    BackgroundImage = My.Resources.WOF_One_Million_2
                ElseIf frmScore.lblControllerSpinResult.Text = 33000 Then
                    BackgroundImage = My.Resources.WOF_CAR
                Else
                    BackgroundImage = My.Resources.WOF_35_000
                End If

            End If
        End Set
    End Property
    Public Property moneyValue As MoneyValueType
        Get
            Return moneyValueEnum
        End Get
        Set(value As MoneyValueType)
            moneyValueEnum = value
            If revealedValue = True Then
                If frmScore.lblControllerSpinResult.Text = 35000 Then
                    BackgroundImage = My.Resources.WOF_34_000
                ElseIf frmScore.lblControllerSpinResult.Text = 35000 Then
                    BackgroundImage = My.Resources.WOF_35_000
                ElseIf frmScore.lblControllerSpinResult.Text = 40000 Then
                    BackgroundImage = My.Resources.WOF_40_000
                ElseIf frmScore.lblControllerSpinResult.Text = 45000 Then
                    BackgroundImage = My.Resources.WOF_45_000
                ElseIf frmScore.lblControllerSpinResult.Text = 50000 Then
                    BackgroundImage = My.Resources.WOF_50_000
                ElseIf frmScore.lblControllerSpinResult.Text = 100000 Then
                    BackgroundImage = My.Resources.WOF_100_000
                ElseIf frmScore.lblControllerSpinResult.Text = 1000000 Then
                    BackgroundImage = My.Resources.WOF_One_Million_2
                ElseIf frmScore.lblControllerSpinResult.Text = 25000 Then
                    BackgroundImage = My.Resources.WOF_CAR
                Else
                    BackgroundImage = My.Resources.WOF_35_000
                End If
            ElseIf revealedValue = False Then
                BackgroundImage = My.Resources.WOF_RearFolded
            End If
        End Set
    End Property

    Private Sub BonusCardEnvelope_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        If revealed = False Then
            revealed = True
        Else
            revealed = False
            If frmScore.lblControllerSpinResult.Text <> 1000000 And frmScore.Million.Visible = True Then
                For Each item As KeyValuePair(Of Integer, String) In WheelController.wheelWedges
                    If item.Value = "100000" Or item.Value = "1000000" Then
                        frmPuzzleBoard.WheelSpinControl1.Show()
                        frmPuzzleBoard.WheelSpinControl1.stopSpin()
                        frmPuzzleBoard.WheelSpinControl1.wmpWheel.Ctlcontrols.currentPosition = item.Key
                        'MsgBox(item.Key)
                        Me.BackgroundImage = My.Resources.WOF_One_Million_2
                        Width = 317
                        Height = 272
                        Me.Show()
                        Me.BringToFront()
                        Exit For
                    End If
                Next
            End If
        End If
    End Sub
End Class
