Public Class clsPuzzle
    Dim categoryString As String
    Dim puzzleString As String
    Dim puzzleTypeInteger As Integer
    Dim crosswordStatusInt As Integer
    Public Property category As String
        Get
            Return categoryString
        End Get
        Set(value As String)
            categoryString = value
        End Set
    End Property
    Public Property puzzle As String
        Get
            Return puzzleString
        End Get
        Set(value As String)
            puzzleString = value
        End Set
    End Property
    Public Property puzzleTypeInt As Integer
        Get
            Return puzzleTypeInteger
        End Get
        Set(value As Integer)
            puzzleTypeInteger = value
        End Set
    End Property
    Public Property crosswordStatus As Integer
        Get
            Return crosswordStatusInt
        End Get
        Set(value As Integer)
            crosswordStatusInt = value
        End Set
    End Property
End Class
