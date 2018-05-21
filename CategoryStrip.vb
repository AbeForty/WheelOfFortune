Public Class CategoryStrip
    Public Property wheelLogoVisible As Boolean
        Get
            Return wheelLogoMini.Visible
        End Get
        Set(value As Boolean)
            wheelLogoMini.Visible = value
        End Set
    End Property
    Private Sub CategoryStrip_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblCategory.Parent = bkgCategory
        wheelLogoMini.Parent = bkgCategory
        wheelLogoMini.BringToFront()
    End Sub

    Private Sub lblCategory_Click(sender As Object, e As EventArgs) Handles lblCategory.Click
        WheelController.category = CType(sender, Label).Text
        If WheelController.puzzleMode = WheelController.wheelMode.Disney Then
            For Each item In WheelController.categoryList
                If item.category = CType(sender, Label).Text Then
                    WheelController.puzzle = item.puzzle
                    WheelController.crosswordStatus = item.crosswordStatus
                End If
            Next
        End If
        If Not frmScore.CategoryStrip1.Visible = False Then
            frmScore.CategoryStrip1.Hide()
            frmScore.CategoryStrip2.lblCategory.Text = WheelController.category
            frmScore.CategoryStrip3.Hide()
        Else
            frmScore.flpBonusCategories.Hide()
        End If
    End Sub
End Class
