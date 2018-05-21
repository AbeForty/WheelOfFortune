Public Class StatsControl
    Public Property packName As String
        Get
            Return lblPackName.Text
        End Get
        Set(value As String)
            lblPackName.Text = value
        End Set
    End Property
    Public Property datePlayed As String
        Get
            Return lblDate.Text
        End Get
        Set(value As String)
            lblDate.Text = value
        End Set
    End Property
    Public Property winnings As String
        Get
            Return lblWinnings.Text
        End Get
        Set(value As String)
            lblWinnings.Text = value
        End Set
    End Property
End Class
