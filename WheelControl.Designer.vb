<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class WheelSpinControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WheelSpinControl))
        Me.wmpWheel = New AxWMPLib.AxWindowsMediaPlayer()
        Me.btnStopSpin = New System.Windows.Forms.Button()
        Me.pbarWheel = New System.Windows.Forms.ProgressBar()
        Me.tmrSpinner = New System.Windows.Forms.Timer(Me.components)
        Me.tmrSpinTest = New System.Windows.Forms.Timer(Me.components)
        Me.trkWheel = New System.Windows.Forms.TrackBar()
        Me.trkBonusWheel = New System.Windows.Forms.TrackBar()
        Me.wheelCover = New System.Windows.Forms.Panel()
        Me.tmrFinalSpinDisable = New System.Windows.Forms.Timer(Me.components)
        CType(Me.wmpWheel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trkWheel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trkBonusWheel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'wmpWheel
        '
        Me.wmpWheel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wmpWheel.Enabled = True
        Me.wmpWheel.Location = New System.Drawing.Point(0, 0)
        Me.wmpWheel.Name = "wmpWheel"
        Me.wmpWheel.OcxState = CType(resources.GetObject("wmpWheel.OcxState"), System.Windows.Forms.AxHost.State)
        Me.wmpWheel.Size = New System.Drawing.Size(1902, 1092)
        Me.wmpWheel.TabIndex = 199
        Me.wmpWheel.Visible = False
        '
        'btnStopSpin
        '
        Me.btnStopSpin.Location = New System.Drawing.Point(1655, 562)
        Me.btnStopSpin.Name = "btnStopSpin"
        Me.btnStopSpin.Size = New System.Drawing.Size(46, 48)
        Me.btnStopSpin.TabIndex = 201
        Me.btnStopSpin.Text = "X"
        Me.btnStopSpin.UseVisualStyleBackColor = True
        Me.btnStopSpin.Visible = False
        '
        'pbarWheel
        '
        Me.pbarWheel.Location = New System.Drawing.Point(1655, 562)
        Me.pbarWheel.Name = "pbarWheel"
        Me.pbarWheel.Size = New System.Drawing.Size(213, 47)
        Me.pbarWheel.TabIndex = 200
        Me.pbarWheel.Visible = False
        '
        'tmrSpinner
        '
        '
        'tmrSpinTest
        '
        Me.tmrSpinTest.Interval = 1
        '
        'trkWheel
        '
        Me.trkWheel.Location = New System.Drawing.Point(18, 922)
        Me.trkWheel.Maximum = 72
        Me.trkWheel.Name = "trkWheel"
        Me.trkWheel.Size = New System.Drawing.Size(505, 56)
        Me.trkWheel.TabIndex = 202
        Me.trkWheel.Visible = False
        '
        'trkBonusWheel
        '
        Me.trkBonusWheel.Location = New System.Drawing.Point(18, 860)
        Me.trkBonusWheel.Maximum = 48
        Me.trkBonusWheel.Minimum = 1
        Me.trkBonusWheel.Name = "trkBonusWheel"
        Me.trkBonusWheel.Size = New System.Drawing.Size(505, 56)
        Me.trkBonusWheel.TabIndex = 212
        Me.trkBonusWheel.Value = 1
        Me.trkBonusWheel.Visible = False
        '
        'wheelCover
        '
        Me.wheelCover.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.wheelCover.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wheelCover.Location = New System.Drawing.Point(0, 0)
        Me.wheelCover.Name = "wheelCover"
        Me.wheelCover.Size = New System.Drawing.Size(1902, 1092)
        Me.wheelCover.TabIndex = 213
        Me.wheelCover.Visible = False
        '
        'tmrFinalSpinDisable
        '
        '
        'WheelSpinControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.trkBonusWheel)
        Me.Controls.Add(Me.trkWheel)
        Me.Controls.Add(Me.btnStopSpin)
        Me.Controls.Add(Me.pbarWheel)
        Me.Controls.Add(Me.wheelCover)
        Me.Controls.Add(Me.wmpWheel)
        Me.Name = "WheelSpinControl"
        Me.Size = New System.Drawing.Size(1902, 1092)
        CType(Me.wmpWheel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trkWheel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trkBonusWheel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents wmpWheel As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents btnStopSpin As Button
    Friend WithEvents pbarWheel As ProgressBar
    Friend WithEvents tmrSpinner As Timer
    Friend WithEvents tmrSpinTest As Timer
    Friend WithEvents trkWheel As TrackBar
    Friend WithEvents trkBonusWheel As TrackBar
    Friend WithEvents wheelCover As Panel
    Friend WithEvents tmrFinalSpinDisable As Timer
End Class
