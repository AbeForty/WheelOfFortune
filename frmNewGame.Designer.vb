<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNewGame
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNewGame))
        Me.pnlSettings = New System.Windows.Forms.Panel()
        Me.lblLoadGame = New System.Windows.Forms.LinkLabel()
        Me.btnClose = New System.Windows.Forms.PictureBox()
        Me.lblSettings = New System.Windows.Forms.Label()
        Me.pnlNewGame = New System.Windows.Forms.Panel()
        Me.txtPlayer3 = New System.Windows.Forms.TextBox()
        Me.NameTag3 = New WheelOfFortune.NameTag()
        Me.txtPlayer2 = New System.Windows.Forms.TextBox()
        Me.NameTag2 = New WheelOfFortune.NameTag()
        Me.NameTag1 = New WheelOfFortune.NameTag()
        Me.txtPlayer1 = New System.Windows.Forms.TextBox()
        Me.lblPackSelect = New System.Windows.Forms.Label()
        Me.btnQuickStart = New System.Windows.Forms.Button()
        Me.numPlayers = New System.Windows.Forms.NumericUpDown()
        Me.chkTypeToSolve = New System.Windows.Forms.CheckBox()
        Me.lblNumOfPlayers = New System.Windows.Forms.Label()
        Me.chkVirtualHost = New System.Windows.Forms.CheckBox()
        Me.TeamDisplay1 = New WheelOfFortune.TeamDisplay()
        Me.lblPuzzleBoardStyle = New System.Windows.Forms.Label()
        Me.TeamDisplay2 = New WheelOfFortune.TeamDisplay()
        Me.cboPuzzleBoardStyle = New System.Windows.Forms.ComboBox()
        Me.TeamDisplay3 = New WheelOfFortune.TeamDisplay()
        Me.btnStartGame = New System.Windows.Forms.Button()
        Me.cboPack = New System.Windows.Forms.ComboBox()
        Me.pnlSettings.SuspendLayout()
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlNewGame.SuspendLayout()
        CType(Me.numPlayers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlSettings
        '
        Me.pnlSettings.BackColor = System.Drawing.Color.Black
        Me.pnlSettings.Controls.Add(Me.lblLoadGame)
        Me.pnlSettings.Controls.Add(Me.btnClose)
        Me.pnlSettings.Controls.Add(Me.lblSettings)
        Me.pnlSettings.Controls.Add(Me.pnlNewGame)
        Me.pnlSettings.Location = New System.Drawing.Point(181, 121)
        Me.pnlSettings.Name = "pnlSettings"
        Me.pnlSettings.Size = New System.Drawing.Size(1538, 884)
        Me.pnlSettings.TabIndex = 1
        '
        'lblLoadGame
        '
        Me.lblLoadGame.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblLoadGame.AutoSize = True
        Me.lblLoadGame.Font = New System.Drawing.Font("Gotham Bold", 16.0!)
        Me.lblLoadGame.LinkColor = System.Drawing.Color.White
        Me.lblLoadGame.Location = New System.Drawing.Point(1247, 21)
        Me.lblLoadGame.Name = "lblLoadGame"
        Me.lblLoadGame.Size = New System.Drawing.Size(187, 31)
        Me.lblLoadGame.TabIndex = 19
        Me.lblLoadGame.TabStop = True
        Me.lblLoadGame.Text = "LOAD GAME"
        Me.lblLoadGame.VisitedLinkColor = System.Drawing.Color.White
        '
        'btnClose
        '
        Me.btnClose.Image = Global.WheelOfFortune.My.Resources.Resources.Delete
        Me.btnClose.Location = New System.Drawing.Point(1484, 21)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(34, 32)
        Me.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnClose.TabIndex = 16
        Me.btnClose.TabStop = False
        '
        'lblSettings
        '
        Me.lblSettings.AutoSize = True
        Me.lblSettings.Font = New System.Drawing.Font("Gotham Bold", 16.0!)
        Me.lblSettings.ForeColor = System.Drawing.Color.White
        Me.lblSettings.Location = New System.Drawing.Point(21, 27)
        Me.lblSettings.Name = "lblSettings"
        Me.lblSettings.Size = New System.Drawing.Size(174, 31)
        Me.lblSettings.TabIndex = 6
        Me.lblSettings.Text = "NEW GAME"
        '
        'pnlNewGame
        '
        Me.pnlNewGame.Controls.Add(Me.txtPlayer3)
        Me.pnlNewGame.Controls.Add(Me.NameTag3)
        Me.pnlNewGame.Controls.Add(Me.txtPlayer2)
        Me.pnlNewGame.Controls.Add(Me.NameTag2)
        Me.pnlNewGame.Controls.Add(Me.NameTag1)
        Me.pnlNewGame.Controls.Add(Me.txtPlayer1)
        Me.pnlNewGame.Controls.Add(Me.lblPackSelect)
        Me.pnlNewGame.Controls.Add(Me.btnQuickStart)
        Me.pnlNewGame.Controls.Add(Me.numPlayers)
        Me.pnlNewGame.Controls.Add(Me.chkTypeToSolve)
        Me.pnlNewGame.Controls.Add(Me.lblNumOfPlayers)
        Me.pnlNewGame.Controls.Add(Me.chkVirtualHost)
        Me.pnlNewGame.Controls.Add(Me.TeamDisplay1)
        Me.pnlNewGame.Controls.Add(Me.lblPuzzleBoardStyle)
        Me.pnlNewGame.Controls.Add(Me.TeamDisplay2)
        Me.pnlNewGame.Controls.Add(Me.cboPuzzleBoardStyle)
        Me.pnlNewGame.Controls.Add(Me.TeamDisplay3)
        Me.pnlNewGame.Controls.Add(Me.btnStartGame)
        Me.pnlNewGame.Controls.Add(Me.cboPack)
        Me.pnlNewGame.Location = New System.Drawing.Point(19, 80)
        Me.pnlNewGame.Name = "pnlNewGame"
        Me.pnlNewGame.Size = New System.Drawing.Size(1465, 754)
        Me.pnlNewGame.TabIndex = 17
        '
        'txtPlayer3
        '
        Me.txtPlayer3.Font = New System.Drawing.Font("Gotham Bold", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtPlayer3.Location = New System.Drawing.Point(962, 532)
        Me.txtPlayer3.Name = "txtPlayer3"
        Me.txtPlayer3.Size = New System.Drawing.Size(444, 35)
        Me.txtPlayer3.TabIndex = 5
        Me.txtPlayer3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'NameTag3
        '
        Me.NameTag3.BackColor = System.Drawing.Color.Transparent
        Me.NameTag3.BackgroundImage = CType(resources.GetObject("NameTag3.BackgroundImage"), System.Drawing.Image)
        Me.NameTag3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.NameTag3.contestantID = 0
        Me.NameTag3.contestantName = "NAME"
        Me.NameTag3.enableClick = True
        Me.NameTag3.Location = New System.Drawing.Point(1086, 12)
        Me.NameTag3.Name = "NameTag3"
        Me.NameTag3.score = 0
        Me.NameTag3.Size = New System.Drawing.Size(150, 48)
        Me.NameTag3.TabIndex = 2
        Me.NameTag3.Visible = False
        '
        'txtPlayer2
        '
        Me.txtPlayer2.Font = New System.Drawing.Font("Gotham Bold", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtPlayer2.Location = New System.Drawing.Point(512, 532)
        Me.txtPlayer2.Name = "txtPlayer2"
        Me.txtPlayer2.Size = New System.Drawing.Size(444, 35)
        Me.txtPlayer2.TabIndex = 4
        Me.txtPlayer2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'NameTag2
        '
        Me.NameTag2.BackColor = System.Drawing.Color.Transparent
        Me.NameTag2.BackgroundImage = CType(resources.GetObject("NameTag2.BackgroundImage"), System.Drawing.Image)
        Me.NameTag2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.NameTag2.contestantID = 0
        Me.NameTag2.contestantName = "NAME"
        Me.NameTag2.enableClick = True
        Me.NameTag2.Location = New System.Drawing.Point(821, 12)
        Me.NameTag2.Name = "NameTag2"
        Me.NameTag2.score = 0
        Me.NameTag2.Size = New System.Drawing.Size(150, 48)
        Me.NameTag2.TabIndex = 1
        Me.NameTag2.Visible = False
        '
        'NameTag1
        '
        Me.NameTag1.BackColor = System.Drawing.Color.Transparent
        Me.NameTag1.BackgroundImage = CType(resources.GetObject("NameTag1.BackgroundImage"), System.Drawing.Image)
        Me.NameTag1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.NameTag1.contestantID = 0
        Me.NameTag1.contestantName = "NAME"
        Me.NameTag1.enableClick = True
        Me.NameTag1.Location = New System.Drawing.Point(569, 12)
        Me.NameTag1.Name = "NameTag1"
        Me.NameTag1.score = 0
        Me.NameTag1.Size = New System.Drawing.Size(150, 48)
        Me.NameTag1.TabIndex = 0
        Me.NameTag1.Visible = False
        '
        'txtPlayer1
        '
        Me.txtPlayer1.Font = New System.Drawing.Font("Gotham Bold", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtPlayer1.Location = New System.Drawing.Point(62, 532)
        Me.txtPlayer1.Name = "txtPlayer1"
        Me.txtPlayer1.Size = New System.Drawing.Size(444, 35)
        Me.txtPlayer1.TabIndex = 3
        Me.txtPlayer1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblPackSelect
        '
        Me.lblPackSelect.AutoSize = True
        Me.lblPackSelect.Font = New System.Drawing.Font("Gotham Bold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPackSelect.ForeColor = System.Drawing.Color.White
        Me.lblPackSelect.Location = New System.Drawing.Point(15, 24)
        Me.lblPackSelect.Name = "lblPackSelect"
        Me.lblPackSelect.Size = New System.Drawing.Size(83, 28)
        Me.lblPackSelect.TabIndex = 15
        Me.lblPackSelect.Text = "PACK"
        '
        'btnQuickStart
        '
        Me.btnQuickStart.BackColor = System.Drawing.Color.White
        Me.btnQuickStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnQuickStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnQuickStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnQuickStart.Font = New System.Drawing.Font("Gotham Bold", 13.0!)
        Me.btnQuickStart.Location = New System.Drawing.Point(768, 683)
        Me.btnQuickStart.Name = "btnQuickStart"
        Me.btnQuickStart.Size = New System.Drawing.Size(212, 41)
        Me.btnQuickStart.TabIndex = 17
        Me.btnQuickStart.Text = "QUICK START"
        Me.btnQuickStart.UseVisualStyleBackColor = False
        '
        'numPlayers
        '
        Me.numPlayers.Font = New System.Drawing.Font("Gotham Bold", 15.0!)
        Me.numPlayers.Location = New System.Drawing.Point(276, 74)
        Me.numPlayers.Maximum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.numPlayers.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numPlayers.Name = "numPlayers"
        Me.numPlayers.Size = New System.Drawing.Size(1166, 35)
        Me.numPlayers.TabIndex = 10
        Me.numPlayers.Value = New Decimal(New Integer() {3, 0, 0, 0})
        Me.numPlayers.Visible = False
        '
        'chkTypeToSolve
        '
        Me.chkTypeToSolve.AutoSize = True
        Me.chkTypeToSolve.Font = New System.Drawing.Font("Gotham Book", 15.0!, System.Drawing.FontStyle.Bold)
        Me.chkTypeToSolve.ForeColor = System.Drawing.Color.White
        Me.chkTypeToSolve.Location = New System.Drawing.Point(732, 582)
        Me.chkTypeToSolve.Name = "chkTypeToSolve"
        Me.chkTypeToSolve.Size = New System.Drawing.Size(430, 31)
        Me.chkTypeToSolve.TabIndex = 14
        Me.chkTypeToSolve.Text = "SOLVE BY TYPING SOLUTION"
        Me.chkTypeToSolve.UseVisualStyleBackColor = True
        '
        'lblNumOfPlayers
        '
        Me.lblNumOfPlayers.AutoSize = True
        Me.lblNumOfPlayers.Font = New System.Drawing.Font("Gotham Bold", 13.0!)
        Me.lblNumOfPlayers.ForeColor = System.Drawing.Color.White
        Me.lblNumOfPlayers.Location = New System.Drawing.Point(15, 79)
        Me.lblNumOfPlayers.Name = "lblNumOfPlayers"
        Me.lblNumOfPlayers.Size = New System.Drawing.Size(238, 25)
        Me.lblNumOfPlayers.TabIndex = 9
        Me.lblNumOfPlayers.Text = "NUMBER OF TEAMS"
        Me.lblNumOfPlayers.Visible = False
        '
        'chkVirtualHost
        '
        Me.chkVirtualHost.AutoSize = True
        Me.chkVirtualHost.Font = New System.Drawing.Font("Gotham Book", 15.0!, System.Drawing.FontStyle.Bold)
        Me.chkVirtualHost.ForeColor = System.Drawing.Color.White
        Me.chkVirtualHost.Location = New System.Drawing.Point(330, 582)
        Me.chkVirtualHost.Name = "chkVirtualHost"
        Me.chkVirtualHost.Size = New System.Drawing.Size(354, 31)
        Me.chkVirtualHost.TabIndex = 13
        Me.chkVirtualHost.Text = "ENABLE VIRTUAL HOST"
        Me.chkVirtualHost.UseVisualStyleBackColor = True
        '
        'TeamDisplay1
        '
        Me.TeamDisplay1.BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TeamDisplay1.enableClick = True
        Me.TeamDisplay1.Location = New System.Drawing.Point(62, 119)
        Me.TeamDisplay1.Name = "TeamDisplay1"
        Me.TeamDisplay1.playerNumber = 1
        Me.TeamDisplay1.Size = New System.Drawing.Size(444, 407)
        Me.TeamDisplay1.TabIndex = 18
        '
        'lblPuzzleBoardStyle
        '
        Me.lblPuzzleBoardStyle.AutoSize = True
        Me.lblPuzzleBoardStyle.Enabled = False
        Me.lblPuzzleBoardStyle.Font = New System.Drawing.Font("Gotham Bold", 13.0!)
        Me.lblPuzzleBoardStyle.ForeColor = System.Drawing.Color.White
        Me.lblPuzzleBoardStyle.Location = New System.Drawing.Point(470, 639)
        Me.lblPuzzleBoardStyle.Name = "lblPuzzleBoardStyle"
        Me.lblPuzzleBoardStyle.Size = New System.Drawing.Size(270, 25)
        Me.lblPuzzleBoardStyle.TabIndex = 12
        Me.lblPuzzleBoardStyle.Text = "PUZZLEBOARD STYLE"
        Me.lblPuzzleBoardStyle.Visible = False
        '
        'TeamDisplay2
        '
        Me.TeamDisplay2.BackColor = System.Drawing.Color.Gold
        Me.TeamDisplay2.enableClick = True
        Me.TeamDisplay2.Location = New System.Drawing.Point(512, 119)
        Me.TeamDisplay2.Name = "TeamDisplay2"
        Me.TeamDisplay2.playerNumber = 2
        Me.TeamDisplay2.Size = New System.Drawing.Size(444, 407)
        Me.TeamDisplay2.TabIndex = 19
        '
        'cboPuzzleBoardStyle
        '
        Me.cboPuzzleBoardStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPuzzleBoardStyle.Enabled = False
        Me.cboPuzzleBoardStyle.Font = New System.Drawing.Font("Gotham Bold", 7.8!)
        Me.cboPuzzleBoardStyle.FormattingEnabled = True
        Me.cboPuzzleBoardStyle.Items.AddRange(New Object() {"MODERN", "CLASSIC"})
        Me.cboPuzzleBoardStyle.Location = New System.Drawing.Point(758, 639)
        Me.cboPuzzleBoardStyle.Name = "cboPuzzleBoardStyle"
        Me.cboPuzzleBoardStyle.Size = New System.Drawing.Size(207, 24)
        Me.cboPuzzleBoardStyle.TabIndex = 11
        Me.cboPuzzleBoardStyle.Visible = False
        '
        'TeamDisplay3
        '
        Me.TeamDisplay3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TeamDisplay3.enableClick = True
        Me.TeamDisplay3.Location = New System.Drawing.Point(962, 119)
        Me.TeamDisplay3.Name = "TeamDisplay3"
        Me.TeamDisplay3.playerNumber = 3
        Me.TeamDisplay3.Size = New System.Drawing.Size(444, 407)
        Me.TeamDisplay3.TabIndex = 20
        '
        'btnStartGame
        '
        Me.btnStartGame.BackColor = System.Drawing.Color.White
        Me.btnStartGame.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnStartGame.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnStartGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStartGame.Font = New System.Drawing.Font("Gotham Bold", 13.0!)
        Me.btnStartGame.Location = New System.Drawing.Point(444, 683)
        Me.btnStartGame.Name = "btnStartGame"
        Me.btnStartGame.Size = New System.Drawing.Size(302, 41)
        Me.btnStartGame.TabIndex = 7
        Me.btnStartGame.Text = "START SAVED GAME"
        Me.btnStartGame.UseVisualStyleBackColor = False
        '
        'cboPack
        '
        Me.cboPack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPack.Font = New System.Drawing.Font("Gotham Bold", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPack.FormattingEnabled = True
        Me.cboPack.Location = New System.Drawing.Point(119, 15)
        Me.cboPack.Name = "cboPack"
        Me.cboPack.Size = New System.Drawing.Size(1323, 42)
        Me.cboPack.TabIndex = 16
        '
        'frmNewGame
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.HotTrack
        Me.BackgroundImage = Global.WheelOfFortune.My.Resources.Resources.WheelBoardBKG
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1932, 1092)
        Me.Controls.Add(Me.pnlSettings)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmNewGame"
        Me.Text = "Wheel of Fortune"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlSettings.ResumeLayout(False)
        Me.pnlSettings.PerformLayout()
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlNewGame.ResumeLayout(False)
        Me.pnlNewGame.PerformLayout()
        CType(Me.numPlayers, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents btnStartGame As Button
    Friend WithEvents TeamDisplay1 As TeamDisplay
    Friend WithEvents numPlayers As NumericUpDown
    Friend WithEvents lblNumOfPlayers As Label
    Friend WithEvents lblPuzzleBoardStyle As Label
    Friend WithEvents cboPuzzleBoardStyle As ComboBox
    Friend WithEvents chkVirtualHost As CheckBox
    Friend WithEvents chkTypeToSolve As CheckBox
    Friend WithEvents cboPack As ComboBox
    Friend WithEvents lblPackSelect As Label
    Friend WithEvents btnQuickStart As Button
    Friend WithEvents btnClose As PictureBox
    Friend WithEvents pnlNewGame As Panel
    Friend WithEvents TeamDisplay2 As TeamDisplay
    Friend WithEvents TeamDisplay3 As TeamDisplay
    Friend WithEvents lblLoadGame As LinkLabel
End Class
