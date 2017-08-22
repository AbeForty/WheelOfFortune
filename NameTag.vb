Public Class NameTag
    Public Property contestantName As String
        Get
            Return lblName.Text
        End Get
        Set(value As String)
            lblName.Text = value
        End Set
    End Property
End Class
