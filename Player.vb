Public Class Player
    Private playerTotal As Integer = 0
    Private wedgeCardList As New SortedList(Of Wedges, Boolean)
    Private contestantNameString As String
    Public Enum Wedges
        Mystery
        Million
        Wild
        Gift
        Prize
        HalfCar1
        HalfCar2
    End Enum
    Public Sub New()
        addCardsOrWedges(Wedges.HalfCar1, False)
        addCardsOrWedges(Wedges.HalfCar2, False)
        addCardsOrWedges(Wedges.Million, False)
        addCardsOrWedges(Wedges.Mystery, False)
        addCardsOrWedges(Wedges.Wild, False)
        addCardsOrWedges(Wedges.Gift, False)
        addCardsOrWedges(Wedges.Prize, False)
    End Sub
    Public Property total
        Get
            Return playerTotal
        End Get
        Set(value)
            playerTotal = value
        End Set
    End Property
    Public Property contestantName As String
        Get
            Return contestantNameString
        End Get
        Set(value As String)
            contestantNameString = value
        End Set
    End Property
    Public Sub addCardsOrWedges(wedge As Wedges, status As Boolean)
        wedgeCardList(wedge) = status
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
End Class
