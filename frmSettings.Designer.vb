<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSettings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSettings))
        Me.pnlSettings = New System.Windows.Forms.Panel()
        Me.numPlayers = New System.Windows.Forms.NumericUpDown()
        Me.lblNumOfPlayers = New System.Windows.Forms.Label()
        Me.chkTeams = New System.Windows.Forms.CheckBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.lblSettings = New System.Windows.Forms.Label()
        Me.txtPlayer3 = New System.Windows.Forms.TextBox()
        Me.txtPlayer2 = New System.Windows.Forms.TextBox()
        Me.txtPlayer1 = New System.Windows.Forms.TextBox()
        Me.NameTag3 = New WheelOfFortune.NameTag()
        Me.NameTag2 = New WheelOfFortune.NameTag()
        Me.NameTag1 = New WheelOfFortune.NameTag()
        Me.pboxLogo = New System.Windows.Forms.PictureBox()
        Me.pnlSettings.SuspendLayout()
        CType(Me.numPlayers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pboxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlSettings
        '
        Me.pnlSettings.BackColor = System.Drawing.Color.SeaGreen
        Me.pnlSettings.Controls.Add(Me.numPlayers)
        Me.pnlSettings.Controls.Add(Me.lblNumOfPlayers)
        Me.pnlSettings.Controls.Add(Me.chkTeams)
        Me.pnlSettings.Controls.Add(Me.btnOK)
        Me.pnlSettings.Controls.Add(Me.lblSettings)
        Me.pnlSettings.Controls.Add(Me.txtPlayer3)
        Me.pnlSettings.Controls.Add(Me.txtPlayer2)
        Me.pnlSettings.Controls.Add(Me.txtPlayer1)
        Me.pnlSettings.Controls.Add(Me.NameTag3)
        Me.pnlSettings.Controls.Add(Me.NameTag2)
        Me.pnlSettings.Controls.Add(Me.NameTag1)
        Me.pnlSettings.Location = New System.Drawing.Point(538, 300)
        Me.pnlSettings.Name = "pnlSettings"
        Me.pnlSettings.Size = New System.Drawing.Size(903, 580)
        Me.pnlSettings.TabIndex = 1
        '
        'numPlayers
        '
        Me.numPlayers.Font = New System.Drawing.Font("Gotham Bold", 10.0!)
        Me.numPlayers.Location = New System.Drawing.Point(551, 167)
        Me.numPlayers.Maximum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.numPlayers.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numPlayers.Name = "numPlayers"
        Me.numPlayers.Size = New System.Drawing.Size(50, 26)
        Me.numPlayers.TabIndex = 10
        Me.numPlayers.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'lblNumOfPlayers
        '
        Me.lblNumOfPlayers.AutoSize = True
        Me.lblNumOfPlayers.Font = New System.Drawing.Font("Gotham Bold", 13.0!)
        Me.lblNumOfPlayers.ForeColor = System.Drawing.Color.White
        Me.lblNumOfPlayers.Location = New System.Drawing.Point(268, 167)
        Me.lblNumOfPlayers.Name = "lblNumOfPlayers"
        Me.lblNumOfPlayers.Size = New System.Drawing.Size(266, 25)
        Me.lblNumOfPlayers.TabIndex = 9
        Me.lblNumOfPlayers.Text = "NUMBER OF PLAYERS"
        '
        'chkTeams
        '
        Me.chkTeams.AutoSize = True
        Me.chkTeams.Font = New System.Drawing.Font("Gotham Book", 15.0!, System.Drawing.FontStyle.Bold)
        Me.chkTeams.ForeColor = System.Drawing.Color.White
        Me.chkTeams.Location = New System.Drawing.Point(265, 391)
        Me.chkTeams.Name = "chkTeams"
        Me.chkTeams.Size = New System.Drawing.Size(371, 31)
        Me.chkTeams.TabIndex = 8
        Me.chkTeams.Text = "EACH PLAYER IS A TEAM"
        Me.chkTeams.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.White
        Me.btnOK.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.HotTrack
        Me.btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOK.Font = New System.Drawing.Font("Gotham Bold", 13.0!)
        Me.btnOK.Location = New System.Drawing.Point(395, 509)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(104, 41)
        Me.btnOK.TabIndex = 7
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'lblSettings
        '
        Me.lblSettings.AutoSize = True
        Me.lblSettings.Font = New System.Drawing.Font("Gotham Bold", 16.0!)
        Me.lblSettings.ForeColor = System.Drawing.Color.White
        Me.lblSettings.Location = New System.Drawing.Point(21, 27)
        Me.lblSettings.Name = "lblSettings"
        Me.lblSettings.Size = New System.Drawing.Size(153, 31)
        Me.lblSettings.TabIndex = 6
        Me.lblSettings.Text = "SETTINGS"
        '
        'txtPlayer3
        '
        Me.txtPlayer3.Font = New System.Drawing.Font("Gotham Bold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlayer3.Location = New System.Drawing.Point(596, 301)
        Me.txtPlayer3.Name = "txtPlayer3"
        Me.txtPlayer3.Size = New System.Drawing.Size(179, 30)
        Me.txtPlayer3.TabIndex = 5
        '
        'txtPlayer2
        '
        Me.txtPlayer2.Font = New System.Drawing.Font("Gotham Bold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlayer2.Location = New System.Drawing.Point(336, 301)
        Me.txtPlayer2.Name = "txtPlayer2"
        Me.txtPlayer2.Size = New System.Drawing.Size(179, 30)
        Me.txtPlayer2.TabIndex = 4
        '
        'txtPlayer1
        '
        Me.txtPlayer1.Font = New System.Drawing.Font("Gotham Bold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlayer1.Location = New System.Drawing.Point(87, 301)
        Me.txtPlayer1.Name = "txtPlayer1"
        Me.txtPlayer1.Size = New System.Drawing.Size(179, 30)
        Me.txtPlayer1.TabIndex = 3
        '
        'NameTag3
        '
        Me.NameTag3.BackColor = System.Drawing.Color.Transparent
        Me.NameTag3.BackgroundImage = CType(resources.GetObject("NameTag3.BackgroundImage"), System.Drawing.Image)
        Me.NameTag3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.NameTag3.contestantName = "NAME"
        Me.NameTag3.Location = New System.Drawing.Point(608, 241)
        Me.NameTag3.Name = "NameTag3"
        Me.NameTag3.Size = New System.Drawing.Size(150, 48)
        Me.NameTag3.TabIndex = 2
        '
        'NameTag2
        '
        Me.NameTag2.BackColor = System.Drawing.Color.Transparent
        Me.NameTag2.BackgroundImage = CType(resources.GetObject("NameTag2.BackgroundImage"), System.Drawing.Image)
        Me.NameTag2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.NameTag2.contestantName = "NAME"
        Me.NameTag2.Location = New System.Drawing.Point(349, 241)
        Me.NameTag2.Name = "NameTag2"
        Me.NameTag2.Size = New System.Drawing.Size(150, 48)
        Me.NameTag2.TabIndex = 1
        '
        'NameTag1
        '
        Me.NameTag1.BackColor = System.Drawing.Color.Transparent
        Me.NameTag1.BackgroundImage = CType(resources.GetObject("NameTag1.BackgroundImage"), System.Drawing.Image)
        Me.NameTag1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.NameTag1.contestantName = "NAME"
        Me.NameTag1.Location = New System.Drawing.Point(97, 241)
        Me.NameTag1.Name = "NameTag1"
        Me.NameTag1.Size = New System.Drawing.Size(150, 48)
        Me.NameTag1.TabIndex = 0
        '
        'pboxLogo
        '
        Me.pboxLogo.BackColor = System.Drawing.Color.Transparent
        Me.pboxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pboxLogo.Image = Global.WheelOfFortune.My.Resources.Resources.WheelLogo
        Me.pboxLogo.Location = New System.Drawing.Point(677, 34)
        Me.pboxLogo.Name = "pboxLogo"
        Me.pboxLogo.Size = New System.Drawing.Size(606, 243)
        Me.pboxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pboxLogo.TabIndex = 0
        Me.pboxLogo.TabStop = False
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.HotTrack
        Me.BackgroundImage = Global.WheelOfFortune.My.Resources.Resources.wof_twitter_skin_2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1932, 1092)
        Me.Controls.Add(Me.pnlSettings)
        Me.Controls.Add(Me.pboxLogo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSettings"
        Me.Text = "Wheel of Fortune"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlSettings.ResumeLayout(False)
        Me.pnlSettings.PerformLayout()
        CType(Me.numPlayers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pboxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlSettings As Panel
    Friend WithEvents lblSettings As Label
    Friend WithEvents txtPlayer3 As TextBox
    Friend WithEvents txtPlayer2 As TextBox
    Friend WithEvents txtPlayer1 As TextBox
    Friend WithEvents NameTag3 As NameTag
    Friend WithEvents NameTag2 As NameTag
    Friend WithEvents NameTag1 As NameTag
    Friend WithEvents btnOK As Button
    Friend WithEvents chkTeams As CheckBox
    Friend WithEvents pboxLogo As PictureBox
    Friend WithEvents numPlayers As NumericUpDown
    Friend WithEvents lblNumOfPlayers As Label
End Class
