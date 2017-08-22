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
        Me.lblRandomNumber = New System.Windows.Forms.Label()
        Me.lblWMPTime = New System.Windows.Forms.Label()
        Me.giftTagBox = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.halfCar1Box = New System.Windows.Forms.PictureBox()
        Me.halfCar2Box = New System.Windows.Forms.PictureBox()
        Me.mystery2Box = New System.Windows.Forms.PictureBox()
        Me.wildCardBox = New System.Windows.Forms.PictureBox()
        Me.tmrFinalSpinDisable = New System.Windows.Forms.Timer(Me.components)
        CType(Me.wmpWheel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trkWheel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trkBonusWheel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.wheelCover.SuspendLayout()
        CType(Me.giftTagBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.halfCar1Box, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.halfCar2Box, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mystery2Box, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.wildCardBox, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.trkWheel.Minimum = 1
        Me.trkWheel.Name = "trkWheel"
        Me.trkWheel.Size = New System.Drawing.Size(505, 56)
        Me.trkWheel.TabIndex = 202
        Me.trkWheel.Value = 1
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
        Me.wheelCover.Controls.Add(Me.lblRandomNumber)
        Me.wheelCover.Controls.Add(Me.lblWMPTime)
        Me.wheelCover.Controls.Add(Me.giftTagBox)
        Me.wheelCover.Controls.Add(Me.PictureBox1)
        Me.wheelCover.Controls.Add(Me.halfCar1Box)
        Me.wheelCover.Controls.Add(Me.halfCar2Box)
        Me.wheelCover.Controls.Add(Me.mystery2Box)
        Me.wheelCover.Controls.Add(Me.wildCardBox)
        Me.wheelCover.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wheelCover.Location = New System.Drawing.Point(0, 0)
        Me.wheelCover.Name = "wheelCover"
        Me.wheelCover.Size = New System.Drawing.Size(1902, 1092)
        Me.wheelCover.TabIndex = 213
        Me.wheelCover.Visible = False
        '
        'lblRandomNumber
        '
        Me.lblRandomNumber.AutoSize = True
        Me.lblRandomNumber.BackColor = System.Drawing.Color.Black
        Me.lblRandomNumber.Font = New System.Drawing.Font("Gotham Book", 18.0!)
        Me.lblRandomNumber.ForeColor = System.Drawing.Color.Transparent
        Me.lblRandomNumber.Location = New System.Drawing.Point(23, 801)
        Me.lblRandomNumber.Name = "lblRandomNumber"
        Me.lblRandomNumber.Size = New System.Drawing.Size(261, 32)
        Me.lblRandomNumber.TabIndex = 214
        Me.lblRandomNumber.Text = "RandomNumber"
        Me.lblRandomNumber.Visible = False
        '
        'lblWMPTime
        '
        Me.lblWMPTime.AutoSize = True
        Me.lblWMPTime.BackColor = System.Drawing.Color.Black
        Me.lblWMPTime.Font = New System.Drawing.Font("Gotham Book", 18.0!)
        Me.lblWMPTime.ForeColor = System.Drawing.Color.Transparent
        Me.lblWMPTime.Location = New System.Drawing.Point(100, 769)
        Me.lblWMPTime.Name = "lblWMPTime"
        Me.lblWMPTime.Size = New System.Drawing.Size(89, 32)
        Me.lblWMPTime.TabIndex = 213
        Me.lblWMPTime.Text = "Time"
        Me.lblWMPTime.Visible = False
        '
        'giftTagBox
        '
        Me.giftTagBox.BackColor = System.Drawing.Color.Transparent
        Me.giftTagBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.giftTagBox.Image = CType(resources.GetObject("giftTagBox.Image"), System.Drawing.Image)
        Me.giftTagBox.Location = New System.Drawing.Point(1296, 534)
        Me.giftTagBox.Name = "giftTagBox"
        Me.giftTagBox.Size = New System.Drawing.Size(86, 131)
        Me.giftTagBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.giftTagBox.TabIndex = 210
        Me.giftTagBox.TabStop = False
        Me.giftTagBox.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(1103, 293)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(324, 176)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 209
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'halfCar1Box
        '
        Me.halfCar1Box.BackColor = System.Drawing.Color.Transparent
        Me.halfCar1Box.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.halfCar1Box.Image = CType(resources.GetObject("halfCar1Box.Image"), System.Drawing.Image)
        Me.halfCar1Box.Location = New System.Drawing.Point(915, 905)
        Me.halfCar1Box.Name = "halfCar1Box"
        Me.halfCar1Box.Size = New System.Drawing.Size(155, 95)
        Me.halfCar1Box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.halfCar1Box.TabIndex = 212
        Me.halfCar1Box.TabStop = False
        Me.halfCar1Box.Visible = False
        '
        'halfCar2Box
        '
        Me.halfCar2Box.BackColor = System.Drawing.Color.Transparent
        Me.halfCar2Box.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.halfCar2Box.Image = CType(resources.GetObject("halfCar2Box.Image"), System.Drawing.Image)
        Me.halfCar2Box.Location = New System.Drawing.Point(619, 137)
        Me.halfCar2Box.Name = "halfCar2Box"
        Me.halfCar2Box.Size = New System.Drawing.Size(167, 152)
        Me.halfCar2Box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.halfCar2Box.TabIndex = 211
        Me.halfCar2Box.TabStop = False
        Me.halfCar2Box.Visible = False
        '
        'mystery2Box
        '
        Me.mystery2Box.BackColor = System.Drawing.Color.Transparent
        Me.mystery2Box.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.mystery2Box.Image = CType(resources.GetObject("mystery2Box.Image"), System.Drawing.Image)
        Me.mystery2Box.Location = New System.Drawing.Point(453, 559)
        Me.mystery2Box.Name = "mystery2Box"
        Me.mystery2Box.Size = New System.Drawing.Size(333, 243)
        Me.mystery2Box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.mystery2Box.TabIndex = 208
        Me.mystery2Box.TabStop = False
        Me.mystery2Box.Visible = False
        '
        'wildCardBox
        '
        Me.wildCardBox.BackColor = System.Drawing.Color.Transparent
        Me.wildCardBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.wildCardBox.Image = CType(resources.GetObject("wildCardBox.Image"), System.Drawing.Image)
        Me.wildCardBox.Location = New System.Drawing.Point(1042, 63)
        Me.wildCardBox.Name = "wildCardBox"
        Me.wildCardBox.Size = New System.Drawing.Size(138, 155)
        Me.wildCardBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.wildCardBox.TabIndex = 209
        Me.wildCardBox.TabStop = False
        Me.wildCardBox.Visible = False
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
        Me.wheelCover.ResumeLayout(False)
        Me.wheelCover.PerformLayout()
        CType(Me.giftTagBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.halfCar1Box, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.halfCar2Box, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mystery2Box, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.wildCardBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents wmpWheel As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents btnStopSpin As Button
    Friend WithEvents pbarWheel As ProgressBar
    Friend WithEvents tmrSpinner As Timer
    Friend WithEvents tmrSpinTest As Timer
    Friend WithEvents trkWheel As TrackBar
    Friend WithEvents wildCardBox As PictureBox
    Friend WithEvents mystery2Box As PictureBox
    Friend WithEvents halfCar2Box As PictureBox
    Friend WithEvents trkBonusWheel As TrackBar
    Friend WithEvents wheelCover As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents giftTagBox As PictureBox
    Friend WithEvents halfCar1Box As PictureBox
    Friend WithEvents lblRandomNumber As Label
    Friend WithEvents lblWMPTime As Label
    Friend WithEvents tmrFinalSpinDisable As Timer
End Class
