Public Class WheelSpinnerTest
    Private Angle As Single = 100
    Private NextIncrement As Single = 1
    Private Randomizer As New Random(Now.Millisecond)
    Private SliceColors As New List(Of Color)
    Private SlicesOnWheel As Integer = 24
    Private Velocity As Single = 0
    Private WheelRadius As Integer = 300
    Private WheelLocation As New Point(50, 50)
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
        g.Clear(Color.LightBlue)
        Dim sliceAngle As Single = CSng(360 / SlicesOnWheel)
        Dim rect As New Rectangle(WheelLocation, New Size(WheelRadius, WheelRadius))
        Dim curveWidth As Integer = CInt(WheelRadius - (WheelRadius / (2.0! * 0.9)))
        Dim rect2 As New Rectangle(rect.Left + curveWidth, rect.Top + curveWidth, rect.Width - curveWidth * 2, rect.Height - curveWidth * 2)
        Dim inc As UInteger = UInteger.MaxValue \ 360
        For I As Single = 0 To 359 Step sliceAngle
            g.FillPie(New SolidBrush(SliceColors(CInt(I / sliceAngle))), rect, I + NormalizeAngle(Angle), sliceAngle)
            g.DrawPie(Pens.White, rect, I + NormalizeAngle(Angle), sliceAngle)
        Next
        'g.FillEllipse(Brushes.Black, rect2)
        'g.DrawEllipse(Pens.White, rect2)
        g.DrawEllipse(Pens.White, rect)
        g.DrawImage(My.Resources.Wheel, rect)
        MyBase.OnPaint(e)
    End Sub
    Private Sub btnSpin_Click(sender As Object, e As EventArgs) Handles btnSpin.Click
        If Timer1.Enabled = False Then
            Velocity = Randomizer.Next(100, 125)
            NextIncrement = Velocity
        End If
        Timer1.Enabled = Not Timer1.Enabled
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim int5 As Integer = 5
        Dim int3 As Integer = 3
        int5 &= int3
        MsgBox(int5)
        Me.DoubleBuffered = True
        Timer1.Interval = 75
        SliceColors.Add(Color.Black)
        SliceColors.Add(Color.LightBlue)
        SliceColors.Add(Color.SeaGreen)
        SliceColors.Add(Color.Yellow)
        SliceColors.Add(Color.Red)
        SliceColors.Add(Color.LightBlue)
        SliceColors.Add(Color.Orange)
        SliceColors.Add(Color.Violet)
        SliceColors.Add(Color.Yellow)
        SliceColors.Add(Color.Black)
        SliceColors.Add(Color.Green)
        SliceColors.Add(Color.Black)
        SliceColors.Add(Color.Green)
        SliceColors.Add(Color.Red)
        SliceColors.Add(Color.Blue)
        SliceColors.Add(Color.SeaGreen)
        SliceColors.Add(Color.Pink)
        SliceColors.Add(Color.Black)
        SliceColors.Add(Color.Purple)
        SliceColors.Add(Color.SkyBlue)
        SliceColors.Add(Color.Aqua)
        SliceColors.Add(Color.White)
        SliceColors.Add(Color.Red)
        SliceColors.Add(Color.Blue)
        SliceColors.Add(Color.Pink)
        SliceColors.Add(Color.SeaGreen)
        SliceColors.Add(Color.Orange)
        SliceColors.Add(Color.Gray)
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Angle = NormalizeAngle(Angle + NextIncrement)
        NextIncrement -= NextIncrement * 0.1!
        If NextIncrement <= 0.005 Then
            Timer1.Enabled = False
        End If
        Me.Text = Angle.ToString
        Me.Invalidate()
    End Sub
    Public Function NormalizeAngle(value As Single) As Single
        If value > 360 Then
            Do
                value -= 360
            Loop Until value <= 360
        End If
        If value < -360 Then
            Do
                value += 360
            Loop Until value >= -360
        End If
        If value = 360 Then value = 0
        Return value
    End Function
End Class