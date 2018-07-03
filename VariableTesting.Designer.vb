<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VariableTesting
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VariableTesting))
        Me.tmrCheckVariables = New System.Windows.Forms.Timer(Me.components)
        Me.lblStartTime = New System.Windows.Forms.Label()
        Me.lblCurrentTime = New System.Windows.Forms.Label()
        Me.lblTimeLeft = New System.Windows.Forms.Label()
        Me.lblTimeToStop = New System.Windows.Forms.Label()
        Me.lblPlayState = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'tmrCheckVariables
        '
        '
        'lblStartTime
        '
        Me.lblStartTime.AutoSize = True
        Me.lblStartTime.Location = New System.Drawing.Point(22, 24)
        Me.lblStartTime.Name = "lblStartTime"
        Me.lblStartTime.Size = New System.Drawing.Size(75, 17)
        Me.lblStartTime.TabIndex = 0
        Me.lblStartTime.Text = "[startTime]"
        '
        'lblCurrentTime
        '
        Me.lblCurrentTime.AutoSize = True
        Me.lblCurrentTime.Location = New System.Drawing.Point(22, 68)
        Me.lblCurrentTime.Name = "lblCurrentTime"
        Me.lblCurrentTime.Size = New System.Drawing.Size(92, 17)
        Me.lblCurrentTime.TabIndex = 1
        Me.lblCurrentTime.Text = "[currentTime]"
        '
        'lblTimeLeft
        '
        Me.lblTimeLeft.AutoSize = True
        Me.lblTimeLeft.Location = New System.Drawing.Point(22, 111)
        Me.lblTimeLeft.Name = "lblTimeLeft"
        Me.lblTimeLeft.Size = New System.Drawing.Size(66, 17)
        Me.lblTimeLeft.TabIndex = 2
        Me.lblTimeLeft.Text = "[timeLeft]"
        '
        'lblTimeToStop
        '
        Me.lblTimeToStop.AutoSize = True
        Me.lblTimeToStop.Location = New System.Drawing.Point(22, 152)
        Me.lblTimeToStop.Name = "lblTimeToStop"
        Me.lblTimeToStop.Size = New System.Drawing.Size(88, 17)
        Me.lblTimeToStop.TabIndex = 3
        Me.lblTimeToStop.Text = "[timeToStop]"
        '
        'lblPlayState
        '
        Me.lblPlayState.AutoSize = True
        Me.lblPlayState.Location = New System.Drawing.Point(22, 192)
        Me.lblPlayState.Name = "lblPlayState"
        Me.lblPlayState.Size = New System.Drawing.Size(75, 17)
        Me.lblPlayState.TabIndex = 4
        Me.lblPlayState.Text = "[playState]"
        '
        'VariableTesting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(288, 244)
        Me.Controls.Add(Me.lblPlayState)
        Me.Controls.Add(Me.lblTimeToStop)
        Me.Controls.Add(Me.lblTimeLeft)
        Me.Controls.Add(Me.lblCurrentTime)
        Me.Controls.Add(Me.lblStartTime)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "VariableTesting"
        Me.ShowInTaskbar = False
        Me.Text = "Variable Testing"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tmrCheckVariables As Timer
    Friend WithEvents lblStartTime As Label
    Friend WithEvents lblCurrentTime As Label
    Friend WithEvents lblTimeLeft As Label
    Friend WithEvents lblTimeToStop As Label
    Friend WithEvents lblPlayState As Label
End Class
