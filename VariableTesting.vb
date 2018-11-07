Public Class VariableTesting
    Private Sub tmrCheckVariables_Tick(sender As Object, e As EventArgs) Handles tmrCheckVariables.Tick
        lblStartTime.Text = "Start Time: " & WheelController.startTime
        lblCurrentTime.Text = "Current Time: " & DateTime.Now.Minute
        lblTimeLeft.Text = "Time Left: " & WheelController.timeLeft
        lblTimeToStop.Text = "Time to Stop: " & (WheelController.convertTimeToSeconds(WheelController.startTime + WheelController.timeLeft))
    End Sub
    Private Sub VariableTesting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tmrCheckVariables.Start()
    End Sub
End Class