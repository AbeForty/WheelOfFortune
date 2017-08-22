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
                ElseIf frmScore.lblControllerSpinResult.Text = 40000 Then
                    BackgroundImage = My.Resources.WOF_40_000
                ElseIf frmScore.lblControllerSpinResult.Text = 45000 Then
                    BackgroundImage = My.Resources.WOF_45_000
                ElseIf frmScore.lblControllerSpinResult.Text = 50000 Then
                    BackgroundImage = My.Resources.WOF_50_000
                ElseIf frmScore.lblControllerSpinResult.Text = 100000 Then
                    BackgroundImage = My.Resources.WOF_100_000
                ElseIf frmScore.lblControllerSpinResult.Text = 100000 Then
                    BackgroundImage = My.Resources.WOF_One_Million_2
                ElseIf frmScore.lblControllerSpinResult.Text = "Car" Then
                    BackgroundImage = My.Resources.WOF_45_000
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
                If frmScore.lblControllerSpinResult.Text = 34000 Then
                    BackgroundImage = My.Resources.WOF_34_000
                ElseIf frmScore.lblControllerSpinResult.Text = 40000 Then
                    BackgroundImage = My.Resources.WOF_40_000
                ElseIf frmScore.lblControllerSpinResult.Text = 45000 Then
                    BackgroundImage = My.Resources.WOF_45_000
                ElseIf frmScore.lblControllerSpinResult.Text = 50000 Then
                    BackgroundImage = My.Resources.WOF_50_000
                ElseIf frmScore.lblControllerSpinResult.Text = 100000 Then
                    BackgroundImage = My.Resources.WOF_100_000
                ElseIf frmScore.lblControllerSpinResult.Text = 100000 Then
                    BackgroundImage = My.Resources.WOF_One_Million_2
                ElseIf frmScore.lblControllerSpinResult.Text = "Car" Then
                    BackgroundImage = My.Resources.WOF_45_000
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
        End If
    End Sub
End Class
