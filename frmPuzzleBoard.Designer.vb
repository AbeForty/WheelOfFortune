<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPuzzleBoard
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPuzzleBoard))
        Me.btnSpinStopTest = New System.Windows.Forms.Button()
        Me.wheelMenu = New System.Windows.Forms.MenuStrip()
        Me.ControlsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SpinToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfirmSpinToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuyAVowelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SolveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WildCardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MysteryRevealToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MysteryStayToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BonusRoundSolveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BonusRoundRevealToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSolve = New System.Windows.Forms.Button()
        Me.btnWild = New System.Windows.Forms.Button()
        Me.mysteryReveal = New System.Windows.Forms.PictureBox()
        Me.noMoreVowels = New System.Windows.Forms.PictureBox()
        Me.lblRSTLNE = New System.Windows.Forms.Label()
        Me.lblChosenLetters = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.ListBox3 = New System.Windows.Forms.ListBox()
        Me.logoExpress = New System.Windows.Forms.PictureBox()
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.btnPreview = New System.Windows.Forms.Button()
        Me.wheelTilt = New System.Windows.Forms.PictureBox()
        Me.tmrTossUp = New System.Windows.Forms.Timer(Me.components)
        Me.btnRedRingIn = New System.Windows.Forms.Button()
        Me.btnYellowRingIn = New System.Windows.Forms.Button()
        Me.btnBlueRingIn = New System.Windows.Forms.Button()
        Me.tmrTossUpRingIn = New System.Windows.Forms.Timer(Me.components)
        Me.ListBox4 = New System.Windows.Forms.ListBox()
        Me.pboxTossUp = New System.Windows.Forms.PictureBox()
        Me.tmrTossUpReveal = New System.Windows.Forms.Timer(Me.components)
        Me.tmrBonus = New System.Windows.Forms.Timer(Me.components)
        Me.tmrCheckFinalSpin = New System.Windows.Forms.Timer(Me.components)
        Me.btnSpinner = New System.Windows.Forms.Button()
        Me.WheelSpinControl1 = New WheelOfFortune.WheelSpinControl()
        Me.tmrCheckTurns = New System.Windows.Forms.Timer(Me.components)
        Me.logoCrossword = New System.Windows.Forms.PictureBox()
        Me.pboxWild = New System.Windows.Forms.PictureBox()
        Me.PuzzleBoard1 = New WheelOfFortune.PuzzleBoard()
        Me.CategoryStrip1 = New WheelOfFortune.CategoryStrip()
        Me.btnSolvePass = New System.Windows.Forms.Button()
        Me.wheelMenu.SuspendLayout()
        CType(Me.mysteryReveal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.noMoreVowels, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.logoExpress, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.wheelTilt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pboxTossUp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.logoCrossword, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pboxWild, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSpinStopTest
        '
        Me.btnSpinStopTest.Location = New System.Drawing.Point(701, 853)
        Me.btnSpinStopTest.Name = "btnSpinStopTest"
        Me.btnSpinStopTest.Size = New System.Drawing.Size(75, 23)
        Me.btnSpinStopTest.TabIndex = 3
        Me.btnSpinStopTest.Text = "Stop"
        Me.btnSpinStopTest.UseVisualStyleBackColor = True
        Me.btnSpinStopTest.Visible = False
        '
        'wheelMenu
        '
        Me.wheelMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.wheelMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ControlsToolStripMenuItem})
        Me.wheelMenu.Location = New System.Drawing.Point(0, 0)
        Me.wheelMenu.Name = "wheelMenu"
        Me.wheelMenu.Size = New System.Drawing.Size(1902, 28)
        Me.wheelMenu.TabIndex = 8
        Me.wheelMenu.Text = "MenuStrip1"
        Me.wheelMenu.Visible = False
        '
        'ControlsToolStripMenuItem
        '
        Me.ControlsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SpinToolStripMenuItem, Me.ConfirmSpinToolStripMenuItem, Me.BuyAVowelToolStripMenuItem, Me.SolveToolStripMenuItem, Me.WildCardToolStripMenuItem, Me.MysteryRevealToolStripMenuItem, Me.MysteryStayToolStripMenuItem, Me.BonusRoundSolveToolStripMenuItem, Me.BonusRoundRevealToolStripMenuItem})
        Me.ControlsToolStripMenuItem.Name = "ControlsToolStripMenuItem"
        Me.ControlsToolStripMenuItem.Size = New System.Drawing.Size(76, 24)
        Me.ControlsToolStripMenuItem.Text = "Controls"
        '
        'SpinToolStripMenuItem
        '
        Me.SpinToolStripMenuItem.Name = "SpinToolStripMenuItem"
        Me.SpinToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SpinToolStripMenuItem.Size = New System.Drawing.Size(299, 26)
        Me.SpinToolStripMenuItem.Text = "Spin"
        '
        'ConfirmSpinToolStripMenuItem
        '
        Me.ConfirmSpinToolStripMenuItem.Name = "ConfirmSpinToolStripMenuItem"
        Me.ConfirmSpinToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.Space), System.Windows.Forms.Keys)
        Me.ConfirmSpinToolStripMenuItem.Size = New System.Drawing.Size(299, 26)
        Me.ConfirmSpinToolStripMenuItem.Text = "Confirm Spin"
        '
        'BuyAVowelToolStripMenuItem
        '
        Me.BuyAVowelToolStripMenuItem.Name = "BuyAVowelToolStripMenuItem"
        Me.BuyAVowelToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.BuyAVowelToolStripMenuItem.Size = New System.Drawing.Size(299, 26)
        Me.BuyAVowelToolStripMenuItem.Text = "Buy a Vowel"
        '
        'SolveToolStripMenuItem
        '
        Me.SolveToolStripMenuItem.Name = "SolveToolStripMenuItem"
        Me.SolveToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.SolveToolStripMenuItem.Size = New System.Drawing.Size(299, 26)
        Me.SolveToolStripMenuItem.Text = "Solve"
        '
        'WildCardToolStripMenuItem
        '
        Me.WildCardToolStripMenuItem.Name = "WildCardToolStripMenuItem"
        Me.WildCardToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.W), System.Windows.Forms.Keys)
        Me.WildCardToolStripMenuItem.Size = New System.Drawing.Size(299, 26)
        Me.WildCardToolStripMenuItem.Text = "Wild Card"
        '
        'MysteryRevealToolStripMenuItem
        '
        Me.MysteryRevealToolStripMenuItem.Name = "MysteryRevealToolStripMenuItem"
        Me.MysteryRevealToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.M), System.Windows.Forms.Keys)
        Me.MysteryRevealToolStripMenuItem.Size = New System.Drawing.Size(299, 26)
        Me.MysteryRevealToolStripMenuItem.Text = "Mystery Reveal"
        '
        'MysteryStayToolStripMenuItem
        '
        Me.MysteryStayToolStripMenuItem.Name = "MysteryStayToolStripMenuItem"
        Me.MysteryStayToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.MysteryStayToolStripMenuItem.Size = New System.Drawing.Size(299, 26)
        Me.MysteryStayToolStripMenuItem.Text = "Mystery Stay"
        '
        'BonusRoundSolveToolStripMenuItem
        '
        Me.BonusRoundSolveToolStripMenuItem.Name = "BonusRoundSolveToolStripMenuItem"
        Me.BonusRoundSolveToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.BonusRoundSolveToolStripMenuItem.Size = New System.Drawing.Size(299, 26)
        Me.BonusRoundSolveToolStripMenuItem.Text = "Bonus Round Solve"
        '
        'BonusRoundRevealToolStripMenuItem
        '
        Me.BonusRoundRevealToolStripMenuItem.Name = "BonusRoundRevealToolStripMenuItem"
        Me.BonusRoundRevealToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Alt) _
            Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.BonusRoundRevealToolStripMenuItem.Size = New System.Drawing.Size(299, 26)
        Me.BonusRoundRevealToolStripMenuItem.Text = "Bonus Round Reveal"
        '
        'btnSolve
        '
        Me.btnSolve.BackgroundImage = Global.WheelOfFortune.My.Resources.Resources.WheelPuzzleBoard
        Me.btnSolve.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnSolve.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSolve.Location = New System.Drawing.Point(1676, 306)
        Me.btnSolve.Name = "btnSolve"
        Me.btnSolve.Size = New System.Drawing.Size(182, 175)
        Me.btnSolve.TabIndex = 118
        Me.btnSolve.UseVisualStyleBackColor = True
        '
        'btnWild
        '
        Me.btnWild.BackgroundImage = Global.WheelOfFortune.My.Resources.Resources.Wild_Card
        Me.btnWild.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnWild.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnWild.Location = New System.Drawing.Point(1676, 487)
        Me.btnWild.Name = "btnWild"
        Me.btnWild.Size = New System.Drawing.Size(182, 175)
        Me.btnWild.TabIndex = 119
        Me.btnWild.UseVisualStyleBackColor = True
        Me.btnWild.Visible = False
        '
        'mysteryReveal
        '
        Me.mysteryReveal.BackColor = System.Drawing.Color.Transparent
        Me.mysteryReveal.Image = Global.WheelOfFortune.My.Resources.Resources.Mystery_2014
        Me.mysteryReveal.Location = New System.Drawing.Point(913, 251)
        Me.mysteryReveal.Name = "mysteryReveal"
        Me.mysteryReveal.Size = New System.Drawing.Size(162, 359)
        Me.mysteryReveal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.mysteryReveal.TabIndex = 124
        Me.mysteryReveal.TabStop = False
        Me.mysteryReveal.Visible = False
        '
        'noMoreVowels
        '
        Me.noMoreVowels.BackColor = System.Drawing.Color.Transparent
        Me.noMoreVowels.Image = Global.WheelOfFortune.My.Resources.Resources.nomorevowels
        Me.noMoreVowels.Location = New System.Drawing.Point(879, 631)
        Me.noMoreVowels.Name = "noMoreVowels"
        Me.noMoreVowels.Size = New System.Drawing.Size(285, 133)
        Me.noMoreVowels.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.noMoreVowels.TabIndex = 125
        Me.noMoreVowels.TabStop = False
        Me.noMoreVowels.Visible = False
        '
        'lblRSTLNE
        '
        Me.lblRSTLNE.AutoSize = True
        Me.lblRSTLNE.BackColor = System.Drawing.Color.Transparent
        Me.lblRSTLNE.Font = New System.Drawing.Font("Gotham Bold", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblRSTLNE.ForeColor = System.Drawing.Color.White
        Me.lblRSTLNE.Location = New System.Drawing.Point(574, 674)
        Me.lblRSTLNE.Name = "lblRSTLNE"
        Me.lblRSTLNE.Size = New System.Drawing.Size(183, 34)
        Me.lblRSTLNE.TabIndex = 126
        Me.lblRSTLNE.Text = "R S T L N E"
        Me.lblRSTLNE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblRSTLNE.Visible = False
        '
        'lblChosenLetters
        '
        Me.lblChosenLetters.BackColor = System.Drawing.Color.Transparent
        Me.lblChosenLetters.Font = New System.Drawing.Font("Gotham Bold", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblChosenLetters.ForeColor = System.Drawing.Color.White
        Me.lblChosenLetters.Location = New System.Drawing.Point(1298, 674)
        Me.lblChosenLetters.Name = "lblChosenLetters"
        Me.lblChosenLetters.Size = New System.Drawing.Size(215, 34)
        Me.lblChosenLetters.TabIndex = 127
        Me.lblChosenLetters.Text = "LETTERS"
        Me.lblChosenLetters.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblChosenLetters.Visible = False
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 16
        Me.ListBox1.Location = New System.Drawing.Point(23, 474)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(298, 84)
        Me.ListBox1.TabIndex = 185
        Me.ListBox1.Visible = False
        '
        'ListBox2
        '
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.ItemHeight = 16
        Me.ListBox2.Location = New System.Drawing.Point(23, 564)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(298, 84)
        Me.ListBox2.TabIndex = 186
        Me.ListBox2.Visible = False
        '
        'ListBox3
        '
        Me.ListBox3.FormattingEnabled = True
        Me.ListBox3.ItemHeight = 16
        Me.ListBox3.Location = New System.Drawing.Point(23, 654)
        Me.ListBox3.Name = "ListBox3"
        Me.ListBox3.Size = New System.Drawing.Size(298, 84)
        Me.ListBox3.TabIndex = 187
        Me.ListBox3.Visible = False
        '
        'logoExpress
        '
        Me.logoExpress.BackColor = System.Drawing.Color.Transparent
        Me.logoExpress.Image = Global.WheelOfFortune.My.Resources.Resources.ExpressLogo
        Me.logoExpress.Location = New System.Drawing.Point(577, 563)
        Me.logoExpress.Name = "logoExpress"
        Me.logoExpress.Size = New System.Drawing.Size(87, 53)
        Me.logoExpress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.logoExpress.TabIndex = 188
        Me.logoExpress.TabStop = False
        Me.logoExpress.Visible = False
        '
        'lblProgress
        '
        Me.lblProgress.AutoSize = True
        Me.lblProgress.BackColor = System.Drawing.Color.Transparent
        Me.lblProgress.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProgress.ForeColor = System.Drawing.Color.White
        Me.lblProgress.Location = New System.Drawing.Point(543, 168)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(0, 32)
        Me.lblProgress.TabIndex = 191
        '
        'btnPreview
        '
        Me.btnPreview.Font = New System.Drawing.Font("Gotham Bold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPreview.Location = New System.Drawing.Point(528, 676)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(998, 100)
        Me.btnPreview.TabIndex = 192
        Me.btnPreview.Text = "YOU ARE VIEWING A PREVIEW OF YOUR PUZZLE." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "CLICK HERE TO CLOSE THE PREVIEW."
        Me.btnPreview.UseVisualStyleBackColor = True
        Me.btnPreview.Visible = False
        '
        'wheelTilt
        '
        Me.wheelTilt.BackColor = System.Drawing.Color.Transparent
        Me.wheelTilt.Image = Global.WheelOfFortune.My.Resources.Resources.WheelTiltedSmallR1Million
        Me.wheelTilt.Location = New System.Drawing.Point(1, 758)
        Me.wheelTilt.Name = "wheelTilt"
        Me.wheelTilt.Size = New System.Drawing.Size(2082, 239)
        Me.wheelTilt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.wheelTilt.TabIndex = 193
        Me.wheelTilt.TabStop = False
        '
        'tmrTossUp
        '
        '
        'btnRedRingIn
        '
        Me.btnRedRingIn.BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnRedRingIn.Font = New System.Drawing.Font("Gotham Bold", 13.0!)
        Me.btnRedRingIn.ForeColor = System.Drawing.Color.White
        Me.btnRedRingIn.Location = New System.Drawing.Point(635, 802)
        Me.btnRedRingIn.Name = "btnRedRingIn"
        Me.btnRedRingIn.Size = New System.Drawing.Size(144, 120)
        Me.btnRedRingIn.TabIndex = 198
        Me.btnRedRingIn.Text = "Solve" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(CTRL)"
        Me.btnRedRingIn.UseVisualStyleBackColor = False
        Me.btnRedRingIn.Visible = False
        '
        'btnYellowRingIn
        '
        Me.btnYellowRingIn.BackColor = System.Drawing.Color.Gold
        Me.btnYellowRingIn.Font = New System.Drawing.Font("Gotham Bold", 13.0!)
        Me.btnYellowRingIn.ForeColor = System.Drawing.Color.Black
        Me.btnYellowRingIn.Location = New System.Drawing.Point(879, 802)
        Me.btnYellowRingIn.Name = "btnYellowRingIn"
        Me.btnYellowRingIn.Size = New System.Drawing.Size(144, 120)
        Me.btnYellowRingIn.TabIndex = 199
        Me.btnYellowRingIn.Text = "Solve" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(ALT)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnYellowRingIn.UseVisualStyleBackColor = False
        Me.btnYellowRingIn.Visible = False
        '
        'btnBlueRingIn
        '
        Me.btnBlueRingIn.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnBlueRingIn.Font = New System.Drawing.Font("Gotham Bold", 13.0!)
        Me.btnBlueRingIn.ForeColor = System.Drawing.Color.White
        Me.btnBlueRingIn.Location = New System.Drawing.Point(1129, 801)
        Me.btnBlueRingIn.Name = "btnBlueRingIn"
        Me.btnBlueRingIn.Size = New System.Drawing.Size(144, 120)
        Me.btnBlueRingIn.TabIndex = 200
        Me.btnBlueRingIn.Text = "Solve" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(SHIFT)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnBlueRingIn.UseVisualStyleBackColor = False
        Me.btnBlueRingIn.Visible = False
        '
        'tmrTossUpRingIn
        '
        '
        'ListBox4
        '
        Me.ListBox4.FormattingEnabled = True
        Me.ListBox4.ItemHeight = 16
        Me.ListBox4.Location = New System.Drawing.Point(23, 744)
        Me.ListBox4.Name = "ListBox4"
        Me.ListBox4.Size = New System.Drawing.Size(298, 116)
        Me.ListBox4.TabIndex = 202
        Me.ListBox4.Visible = False
        '
        'pboxTossUp
        '
        Me.pboxTossUp.BackColor = System.Drawing.Color.Transparent
        Me.pboxTossUp.Image = Global.WheelOfFortune.My.Resources.Resources.Toss_Up_1000
        Me.pboxTossUp.Location = New System.Drawing.Point(759, 188)
        Me.pboxTossUp.Name = "pboxTossUp"
        Me.pboxTossUp.Size = New System.Drawing.Size(460, 412)
        Me.pboxTossUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pboxTossUp.TabIndex = 203
        Me.pboxTossUp.TabStop = False
        Me.pboxTossUp.Visible = False
        '
        'tmrTossUpReveal
        '
        '
        'tmrBonus
        '
        '
        'tmrCheckFinalSpin
        '
        '
        'btnSpinner
        '
        Me.btnSpinner.BackgroundImage = CType(resources.GetObject("btnSpinner.BackgroundImage"), System.Drawing.Image)
        Me.btnSpinner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSpinner.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSpinner.Location = New System.Drawing.Point(332, 319)
        Me.btnSpinner.Name = "btnSpinner"
        Me.btnSpinner.Size = New System.Drawing.Size(182, 175)
        Me.btnSpinner.TabIndex = 4
        Me.btnSpinner.UseVisualStyleBackColor = True
        Me.btnSpinner.Visible = False
        '
        'WheelSpinControl1
        '
        Me.WheelSpinControl1.BackColor = System.Drawing.Color.Transparent
        Me.WheelSpinControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WheelSpinControl1.Location = New System.Drawing.Point(0, 0)
        Me.WheelSpinControl1.Name = "WheelSpinControl1"
        Me.WheelSpinControl1.Size = New System.Drawing.Size(1902, 1092)
        Me.WheelSpinControl1.TabIndex = 204
        Me.WheelSpinControl1.Visible = False
        '
        'tmrCheckTurns
        '
        '
        'logoCrossword
        '
        Me.logoCrossword.BackColor = System.Drawing.Color.Transparent
        Me.logoCrossword.Image = Global.WheelOfFortune.My.Resources.Resources.CLUE
        Me.logoCrossword.Location = New System.Drawing.Point(577, 572)
        Me.logoCrossword.Name = "logoCrossword"
        Me.logoCrossword.Size = New System.Drawing.Size(122, 38)
        Me.logoCrossword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.logoCrossword.TabIndex = 206
        Me.logoCrossword.TabStop = False
        Me.logoCrossword.Visible = False
        '
        'pboxWild
        '
        Me.pboxWild.BackColor = System.Drawing.Color.Transparent
        Me.pboxWild.Image = Global.WheelOfFortune.My.Resources.Resources.Wild_Card
        Me.pboxWild.Location = New System.Drawing.Point(1454, 667)
        Me.pboxWild.Name = "pboxWild"
        Me.pboxWild.Size = New System.Drawing.Size(55, 65)
        Me.pboxWild.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pboxWild.TabIndex = 207
        Me.pboxWild.TabStop = False
        Me.pboxWild.Visible = False
        '
        'PuzzleBoard1
        '
        Me.PuzzleBoard1.BackColor = System.Drawing.Color.Transparent
        Me.PuzzleBoard1.BackgroundImage = Global.WheelOfFortune.My.Resources.Resources.WheelPuzzleBoard
        Me.PuzzleBoard1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PuzzleBoard1.Location = New System.Drawing.Point(582, 245)
        Me.PuzzleBoard1.Name = "PuzzleBoard1"
        Me.PuzzleBoard1.Size = New System.Drawing.Size(877, 332)
        Me.PuzzleBoard1.TabIndex = 208
        '
        'CategoryStrip1
        '
        Me.CategoryStrip1.BackColor = System.Drawing.Color.Transparent
        Me.CategoryStrip1.Location = New System.Drawing.Point(582, 616)
        Me.CategoryStrip1.Name = "CategoryStrip1"
        Me.CategoryStrip1.Size = New System.Drawing.Size(907, 45)
        Me.CategoryStrip1.TabIndex = 209
        Me.CategoryStrip1.wheelLogoVisible = True
        '
        'btnSolvePass
        '
        Me.btnSolvePass.BackgroundImage = Global.WheelOfFortune.My.Resources.Resources.PassSolve
        Me.btnSolvePass.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnSolvePass.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSolvePass.Location = New System.Drawing.Point(332, 319)
        Me.btnSolvePass.Name = "btnSolvePass"
        Me.btnSolvePass.Size = New System.Drawing.Size(182, 175)
        Me.btnSolvePass.TabIndex = 210
        Me.btnSolvePass.UseVisualStyleBackColor = True
        Me.btnSolvePass.Visible = False
        '
        'frmPuzzleBoard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.WheelOfFortune.My.Resources.Resources.WheelBoard
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1902, 1092)
        Me.Controls.Add(Me.WheelSpinControl1)
        Me.Controls.Add(Me.btnSolvePass)
        Me.Controls.Add(Me.CategoryStrip1)
        Me.Controls.Add(Me.pboxTossUp)
        Me.Controls.Add(Me.pboxWild)
        Me.Controls.Add(Me.ListBox4)
        Me.Controls.Add(Me.btnBlueRingIn)
        Me.Controls.Add(Me.btnYellowRingIn)
        Me.Controls.Add(Me.btnRedRingIn)
        Me.Controls.Add(Me.btnPreview)
        Me.Controls.Add(Me.lblProgress)
        Me.Controls.Add(Me.logoCrossword)
        Me.Controls.Add(Me.logoExpress)
        Me.Controls.Add(Me.ListBox3)
        Me.Controls.Add(Me.ListBox2)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.lblChosenLetters)
        Me.Controls.Add(Me.lblRSTLNE)
        Me.Controls.Add(Me.btnWild)
        Me.Controls.Add(Me.btnSolve)
        Me.Controls.Add(Me.btnSpinner)
        Me.Controls.Add(Me.btnSpinStopTest)
        Me.Controls.Add(Me.noMoreVowels)
        Me.Controls.Add(Me.wheelTilt)
        Me.Controls.Add(Me.mysteryReveal)
        Me.Controls.Add(Me.PuzzleBoard1)
        Me.Controls.Add(Me.wheelMenu)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.wheelMenu
        Me.Name = "frmPuzzleBoard"
        Me.Text = "Wheel of Fortune"
        Me.TransparencyKey = System.Drawing.Color.DarkOrange
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.wheelMenu.ResumeLayout(False)
        Me.wheelMenu.PerformLayout()
        CType(Me.mysteryReveal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.noMoreVowels, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.logoExpress, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.wheelTilt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pboxTossUp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.logoCrossword, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pboxWild, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSpinStopTest As Button
    Friend WithEvents wheelMenu As MenuStrip
    Friend WithEvents ControlsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SpinToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BuyAVowelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SolveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WildCardToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MysteryRevealToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MysteryStayToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConfirmSpinToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnSolve As Button
    Friend WithEvents btnWild As Button
    Friend WithEvents mysteryReveal As PictureBox
    Friend WithEvents noMoreVowels As PictureBox
    Friend WithEvents lblRSTLNE As Label
    Friend WithEvents lblChosenLetters As Label
    Friend WithEvents BonusRoundSolveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BonusRoundRevealToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents ListBox2 As ListBox
    Friend WithEvents ListBox3 As ListBox
    Friend WithEvents logoExpress As PictureBox
    Friend WithEvents lblProgress As Label
    Friend WithEvents btnPreview As Button
    Friend WithEvents wheelTilt As PictureBox
    Friend WithEvents tmrTossUp As Timer
    Friend WithEvents btnRedRingIn As Button
    Friend WithEvents btnYellowRingIn As Button
    Friend WithEvents btnBlueRingIn As Button
    Friend WithEvents tmrTossUpRingIn As Timer
    Friend WithEvents ListBox4 As ListBox
    Friend WithEvents pboxTossUp As PictureBox
    Friend WithEvents tmrTossUpReveal As Timer
    Friend WithEvents tmrBonus As Timer
    Friend WithEvents tmrCheckFinalSpin As Timer
    Friend WithEvents btnSpinner As Button
    Friend WithEvents WheelSpinControl1 As WheelSpinControl
    Friend WithEvents tmrCheckTurns As Timer
    Friend WithEvents logoCrossword As PictureBox
    Friend WithEvents pboxWild As PictureBox
    Friend WithEvents PuzzleBoard1 As PuzzleBoard
    Friend WithEvents CategoryStrip1 As CategoryStrip
    Friend WithEvents btnSolvePass As Button
    'Friend WithEvents PuzzleBoardLetter53 As PuzzleBoardLetter
    'Friend WithEvents PuzzleBoardLetter54 As PuzzleBoardLetter
    'Friend WithEvents PuzzleBoardLetter55 As PuzzleBoardLetter
    'Friend WithEvents PuzzleBoardLetter56 As PuzzleBoardLetter
    'Friend WithEvents PuzzleBoardLetter57 As PuzzleBoardLetter
    'Friend WithEvents PuzzleBoardLetter58 As PuzzleBoardLetter
    'Friend WithEvents PuzzleBoardLetter59 As PuzzleBoardLetter
    'Friend WithEvents PuzzleBoardLetter60 As PuzzleBoardLetter
    'Friend WithEvents PuzzleBoardLetter61 As PuzzleBoardLetter
    'Friend WithEvents PuzzleBoardLetter62 As PuzzleBoardLetter
    'Friend WithEvents PuzzleBoardLetter63 As PuzzleBoardLetter
    'Friend WithEvents PuzzleBoardLetter64 As PuzzleBoardLetter
End Class
