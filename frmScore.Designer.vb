<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmScore
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmScore))
        Me.pnlScore = New System.Windows.Forms.Panel()
        Me.lblNumberOfTurns = New System.Windows.Forms.Label()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.lstDownArrow = New System.Windows.Forms.PictureBox()
        Me.notifyBar = New System.Windows.Forms.Label()
        Me.lblPlayer3Total = New System.Windows.Forms.Label()
        Me.lblPlayer2Total = New System.Windows.Forms.Label()
        Me.lblPlayer1Total = New System.Windows.Forms.Label()
        Me.lblControllerSpinResult = New System.Windows.Forms.Label()
        Me.btnBonusTimerStart = New System.Windows.Forms.Button()
        Me.Gift = New System.Windows.Forms.PictureBox()
        Me.Wild = New System.Windows.Forms.PictureBox()
        Me.Million = New System.Windows.Forms.PictureBox()
        Me.Prize = New System.Windows.Forms.PictureBox()
        Me.Mystery = New System.Windows.Forms.PictureBox()
        Me.halfcar2 = New System.Windows.Forms.PictureBox()
        Me.halfcar1 = New System.Windows.Forms.PictureBox()
        Me.player3RightArrow = New System.Windows.Forms.PictureBox()
        Me.player3LeftArrow = New System.Windows.Forms.PictureBox()
        Me.player2RightArrow = New System.Windows.Forms.PictureBox()
        Me.player2LeftArrow = New System.Windows.Forms.PictureBox()
        Me.player1RightArrow = New System.Windows.Forms.PictureBox()
        Me.player1LeftArrow = New System.Windows.Forms.PictureBox()
        Me.txtRecognition = New System.Windows.Forms.TextBox()
        Me.lblPlayer2 = New System.Windows.Forms.Label()
        Me.lblPlayer1 = New System.Windows.Forms.Label()
        Me.quitBTN = New System.Windows.Forms.Button()
        Me.txtCurrentPlayer = New System.Windows.Forms.TextBox()
        Me.lblCurrentValue = New System.Windows.Forms.Label()
        Me.lblPlayer3 = New System.Windows.Forms.Label()
        Me.btnA = New System.Windows.Forms.Button()
        Me.btnB = New System.Windows.Forms.Button()
        Me.btnC = New System.Windows.Forms.Button()
        Me.btnD = New System.Windows.Forms.Button()
        Me.btnE = New System.Windows.Forms.Button()
        Me.usedLetterBoard = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnF = New System.Windows.Forms.Button()
        Me.btnG = New System.Windows.Forms.Button()
        Me.btnH = New System.Windows.Forms.Button()
        Me.btnI = New System.Windows.Forms.Button()
        Me.btnJ = New System.Windows.Forms.Button()
        Me.btnK = New System.Windows.Forms.Button()
        Me.btnL = New System.Windows.Forms.Button()
        Me.btnM = New System.Windows.Forms.Button()
        Me.btnN = New System.Windows.Forms.Button()
        Me.btnO = New System.Windows.Forms.Button()
        Me.btnP = New System.Windows.Forms.Button()
        Me.btnQ = New System.Windows.Forms.Button()
        Me.btnR = New System.Windows.Forms.Button()
        Me.btnS = New System.Windows.Forms.Button()
        Me.btnT = New System.Windows.Forms.Button()
        Me.btnU = New System.Windows.Forms.Button()
        Me.btnV = New System.Windows.Forms.Button()
        Me.btnW = New System.Windows.Forms.Button()
        Me.btnX = New System.Windows.Forms.Button()
        Me.btnY = New System.Windows.Forms.Button()
        Me.btnZ = New System.Windows.Forms.Button()
        Me.btnLoseATurn = New System.Windows.Forms.Button()
        Me.tmrCheckPlayer = New System.Windows.Forms.Timer(Me.components)
        Me.AxWindowsMediaPlayer1 = New AxWMPLib.AxWindowsMediaPlayer()
        Me.tmrLetterReveal = New System.Windows.Forms.Timer(Me.components)
        Me.tmrBonusLetterReveal = New System.Windows.Forms.Timer(Me.components)
        Me.tmrSolveFailed = New System.Windows.Forms.Timer(Me.components)
        Me.tmrCurrentPlayerFlash = New System.Windows.Forms.Timer(Me.components)
        Me.tmrCheckVowels = New System.Windows.Forms.Timer(Me.components)
        Me.lstMessages = New System.Windows.Forms.ListBox()
        Me.tmrFinalSpin = New System.Windows.Forms.Timer(Me.components)
        Me.BonusCardEnvelope1 = New WheelOfFortune.BonusCardEnvelope()
        Me.NameTag3 = New WheelOfFortune.NameTag()
        Me.NameTag2 = New WheelOfFortune.NameTag()
        Me.NameTag1 = New WheelOfFortune.NameTag()
        Me.tmrBonusTimer = New System.Windows.Forms.Timer(Me.components)
        Me.pnlScore.SuspendLayout()
        CType(Me.lstDownArrow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gift, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Wild, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Million, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Prize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Mystery, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.halfcar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.halfcar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.player3RightArrow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.player3LeftArrow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.player2RightArrow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.player2LeftArrow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.player1RightArrow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.player1LeftArrow, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.usedLetterBoard.SuspendLayout()
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlScore
        '
        Me.pnlScore.BackColor = System.Drawing.Color.ForestGreen
        Me.pnlScore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlScore.Controls.Add(Me.lblNumberOfTurns)
        Me.pnlScore.Controls.Add(Me.btnHelp)
        Me.pnlScore.Controls.Add(Me.lstDownArrow)
        Me.pnlScore.Controls.Add(Me.notifyBar)
        Me.pnlScore.Controls.Add(Me.lblPlayer3Total)
        Me.pnlScore.Controls.Add(Me.lblPlayer2Total)
        Me.pnlScore.Controls.Add(Me.lblPlayer1Total)
        Me.pnlScore.Controls.Add(Me.lblControllerSpinResult)
        Me.pnlScore.Controls.Add(Me.btnBonusTimerStart)
        Me.pnlScore.Controls.Add(Me.Gift)
        Me.pnlScore.Controls.Add(Me.Wild)
        Me.pnlScore.Controls.Add(Me.Million)
        Me.pnlScore.Controls.Add(Me.Prize)
        Me.pnlScore.Controls.Add(Me.Mystery)
        Me.pnlScore.Controls.Add(Me.halfcar2)
        Me.pnlScore.Controls.Add(Me.halfcar1)
        Me.pnlScore.Controls.Add(Me.player3RightArrow)
        Me.pnlScore.Controls.Add(Me.player3LeftArrow)
        Me.pnlScore.Controls.Add(Me.player2RightArrow)
        Me.pnlScore.Controls.Add(Me.player2LeftArrow)
        Me.pnlScore.Controls.Add(Me.player1RightArrow)
        Me.pnlScore.Controls.Add(Me.player1LeftArrow)
        Me.pnlScore.Controls.Add(Me.txtRecognition)
        Me.pnlScore.Controls.Add(Me.lblPlayer2)
        Me.pnlScore.Controls.Add(Me.lblPlayer1)
        Me.pnlScore.Controls.Add(Me.quitBTN)
        Me.pnlScore.Controls.Add(Me.txtCurrentPlayer)
        Me.pnlScore.Controls.Add(Me.lblCurrentValue)
        Me.pnlScore.Controls.Add(Me.lblPlayer3)
        Me.pnlScore.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlScore.Location = New System.Drawing.Point(0, 0)
        Me.pnlScore.Name = "pnlScore"
        Me.pnlScore.Size = New System.Drawing.Size(1932, 129)
        Me.pnlScore.TabIndex = 30
        '
        'lblNumberOfTurns
        '
        Me.lblNumberOfTurns.AutoSize = True
        Me.lblNumberOfTurns.Font = New System.Drawing.Font("Segoe UI Light", 25.0!)
        Me.lblNumberOfTurns.ForeColor = System.Drawing.Color.White
        Me.lblNumberOfTurns.Location = New System.Drawing.Point(15, 60)
        Me.lblNumberOfTurns.Name = "lblNumberOfTurns"
        Me.lblNumberOfTurns.Size = New System.Drawing.Size(75, 57)
        Me.lblNumberOfTurns.TabIndex = 49
        Me.lblNumberOfTurns.Text = "##"
        Me.lblNumberOfTurns.Visible = False
        '
        'btnHelp
        '
        Me.btnHelp.BackgroundImage = Global.WheelOfFortune.My.Resources.Resources.wof_logo
        Me.btnHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnHelp.Location = New System.Drawing.Point(1830, 42)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(46, 46)
        Me.btnHelp.TabIndex = 48
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'lstDownArrow
        '
        Me.lstDownArrow.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.lstDownArrow.Image = Global.WheelOfFortune.My.Resources.Resources.DownChevron
        Me.lstDownArrow.Location = New System.Drawing.Point(1715, 47)
        Me.lstDownArrow.Name = "lstDownArrow"
        Me.lstDownArrow.Size = New System.Drawing.Size(37, 37)
        Me.lstDownArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.lstDownArrow.TabIndex = 47
        Me.lstDownArrow.TabStop = False
        '
        'notifyBar
        '
        Me.notifyBar.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.notifyBar.Font = New System.Drawing.Font("Gotham Book", 10.0!, System.Drawing.FontStyle.Bold)
        Me.notifyBar.ForeColor = System.Drawing.Color.White
        Me.notifyBar.Location = New System.Drawing.Point(1479, 39)
        Me.notifyBar.Name = "notifyBar"
        Me.notifyBar.Size = New System.Drawing.Size(281, 55)
        Me.notifyBar.TabIndex = 28
        Me.notifyBar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.notifyBar.UseMnemonic = False
        '
        'lblPlayer3Total
        '
        Me.lblPlayer3Total.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblPlayer3Total.Font = New System.Drawing.Font("Gotham Bold", 10.0!)
        Me.lblPlayer3Total.ForeColor = System.Drawing.Color.White
        Me.lblPlayer3Total.Location = New System.Drawing.Point(1168, 95)
        Me.lblPlayer3Total.Name = "lblPlayer3Total"
        Me.lblPlayer3Total.Size = New System.Drawing.Size(278, 34)
        Me.lblPlayer3Total.TabIndex = 45
        Me.lblPlayer3Total.Text = "$0"
        Me.lblPlayer3Total.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblPlayer3Total.UseMnemonic = False
        Me.lblPlayer3Total.Visible = False
        '
        'lblPlayer2Total
        '
        Me.lblPlayer2Total.BackColor = System.Drawing.Color.Gold
        Me.lblPlayer2Total.Font = New System.Drawing.Font("Gotham Bold", 10.0!)
        Me.lblPlayer2Total.ForeColor = System.Drawing.Color.White
        Me.lblPlayer2Total.Location = New System.Drawing.Point(870, 95)
        Me.lblPlayer2Total.Name = "lblPlayer2Total"
        Me.lblPlayer2Total.Size = New System.Drawing.Size(278, 34)
        Me.lblPlayer2Total.TabIndex = 44
        Me.lblPlayer2Total.Text = "$0"
        Me.lblPlayer2Total.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblPlayer2Total.UseMnemonic = False
        Me.lblPlayer2Total.Visible = False
        '
        'lblPlayer1Total
        '
        Me.lblPlayer1Total.BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblPlayer1Total.Font = New System.Drawing.Font("Gotham Bold", 10.0!)
        Me.lblPlayer1Total.ForeColor = System.Drawing.Color.White
        Me.lblPlayer1Total.Location = New System.Drawing.Point(575, 95)
        Me.lblPlayer1Total.Name = "lblPlayer1Total"
        Me.lblPlayer1Total.Size = New System.Drawing.Size(278, 34)
        Me.lblPlayer1Total.TabIndex = 43
        Me.lblPlayer1Total.Text = "$0"
        Me.lblPlayer1Total.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblPlayer1Total.UseMnemonic = False
        Me.lblPlayer1Total.Visible = False
        '
        'lblControllerSpinResult
        '
        Me.lblControllerSpinResult.AutoSize = True
        Me.lblControllerSpinResult.Font = New System.Drawing.Font("Segoe UI Light", 10.0!)
        Me.lblControllerSpinResult.ForeColor = System.Drawing.Color.White
        Me.lblControllerSpinResult.Location = New System.Drawing.Point(20, 8)
        Me.lblControllerSpinResult.Name = "lblControllerSpinResult"
        Me.lblControllerSpinResult.Size = New System.Drawing.Size(82, 23)
        Me.lblControllerSpinResult.TabIndex = 42
        Me.lblControllerSpinResult.Text = "PointValue"
        '
        'btnBonusTimerStart
        '
        Me.btnBonusTimerStart.BackgroundImage = Global.WheelOfFortune.My.Resources.Resources.BlueArrow
        Me.btnBonusTimerStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBonusTimerStart.Location = New System.Drawing.Point(25, 61)
        Me.btnBonusTimerStart.Name = "btnBonusTimerStart"
        Me.btnBonusTimerStart.Size = New System.Drawing.Size(60, 55)
        Me.btnBonusTimerStart.TabIndex = 34
        Me.btnBonusTimerStart.UseVisualStyleBackColor = True
        Me.btnBonusTimerStart.Visible = False
        '
        'Gift
        '
        Me.Gift.Image = Global.WheelOfFortune.My.Resources.Resources.Gift_Tag
        Me.Gift.Location = New System.Drawing.Point(505, 70)
        Me.Gift.Name = "Gift"
        Me.Gift.Size = New System.Drawing.Size(64, 41)
        Me.Gift.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Gift.TabIndex = 41
        Me.Gift.TabStop = False
        Me.Gift.Visible = False
        '
        'Wild
        '
        Me.Wild.Image = Global.WheelOfFortune.My.Resources.Resources.Wild_Card
        Me.Wild.Location = New System.Drawing.Point(514, 3)
        Me.Wild.Name = "Wild"
        Me.Wild.Size = New System.Drawing.Size(44, 57)
        Me.Wild.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Wild.TabIndex = 39
        Me.Wild.TabStop = False
        Me.Wild.Visible = False
        '
        'Million
        '
        Me.Million.Image = Global.WheelOfFortune.My.Resources.Resources.MDW_Back
        Me.Million.Location = New System.Drawing.Point(412, 7)
        Me.Million.Name = "Million"
        Me.Million.Size = New System.Drawing.Size(87, 109)
        Me.Million.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Million.TabIndex = 40
        Me.Million.TabStop = False
        Me.Million.Visible = False
        '
        'Prize
        '
        Me.Prize.Image = Global.WheelOfFortune.My.Resources.Resources.Prize
        Me.Prize.Location = New System.Drawing.Point(324, 7)
        Me.Prize.Name = "Prize"
        Me.Prize.Size = New System.Drawing.Size(87, 109)
        Me.Prize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Prize.TabIndex = 39
        Me.Prize.TabStop = False
        Me.Prize.Visible = False
        '
        'Mystery
        '
        Me.Mystery.Image = Global.WheelOfFortune.My.Resources.Resources.Mystery_10000_2014
        Me.Mystery.Location = New System.Drawing.Point(236, 7)
        Me.Mystery.Name = "Mystery"
        Me.Mystery.Size = New System.Drawing.Size(87, 109)
        Me.Mystery.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Mystery.TabIndex = 38
        Me.Mystery.TabStop = False
        Me.Mystery.Visible = False
        '
        'halfcar2
        '
        Me.halfcar2.Image = Global.WheelOfFortune.My.Resources.Resources.Half_Car
        Me.halfcar2.Location = New System.Drawing.Point(108, 66)
        Me.halfcar2.Name = "halfcar2"
        Me.halfcar2.Size = New System.Drawing.Size(116, 57)
        Me.halfcar2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.halfcar2.TabIndex = 37
        Me.halfcar2.TabStop = False
        Me.halfcar2.Visible = False
        '
        'halfcar1
        '
        Me.halfcar1.Image = Global.WheelOfFortune.My.Resources.Resources.Half_Car
        Me.halfcar1.Location = New System.Drawing.Point(108, 3)
        Me.halfcar1.Name = "halfcar1"
        Me.halfcar1.Size = New System.Drawing.Size(116, 57)
        Me.halfcar1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.halfcar1.TabIndex = 33
        Me.halfcar1.TabStop = False
        Me.halfcar1.Visible = False
        '
        'player3RightArrow
        '
        Me.player3RightArrow.BackColor = System.Drawing.Color.White
        Me.player3RightArrow.Location = New System.Drawing.Point(1435, 27)
        Me.player3RightArrow.Name = "player3RightArrow"
        Me.player3RightArrow.Size = New System.Drawing.Size(11, 68)
        Me.player3RightArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.player3RightArrow.TabIndex = 36
        Me.player3RightArrow.TabStop = False
        Me.player3RightArrow.Visible = False
        '
        'player3LeftArrow
        '
        Me.player3LeftArrow.BackColor = System.Drawing.Color.White
        Me.player3LeftArrow.Location = New System.Drawing.Point(1168, 27)
        Me.player3LeftArrow.Name = "player3LeftArrow"
        Me.player3LeftArrow.Size = New System.Drawing.Size(11, 68)
        Me.player3LeftArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.player3LeftArrow.TabIndex = 35
        Me.player3LeftArrow.TabStop = False
        Me.player3LeftArrow.Visible = False
        '
        'player2RightArrow
        '
        Me.player2RightArrow.BackColor = System.Drawing.Color.White
        Me.player2RightArrow.Location = New System.Drawing.Point(1137, 27)
        Me.player2RightArrow.Name = "player2RightArrow"
        Me.player2RightArrow.Size = New System.Drawing.Size(11, 68)
        Me.player2RightArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.player2RightArrow.TabIndex = 36
        Me.player2RightArrow.TabStop = False
        Me.player2RightArrow.Visible = False
        '
        'player2LeftArrow
        '
        Me.player2LeftArrow.BackColor = System.Drawing.Color.White
        Me.player2LeftArrow.Location = New System.Drawing.Point(870, 27)
        Me.player2LeftArrow.Name = "player2LeftArrow"
        Me.player2LeftArrow.Size = New System.Drawing.Size(11, 68)
        Me.player2LeftArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.player2LeftArrow.TabIndex = 35
        Me.player2LeftArrow.TabStop = False
        Me.player2LeftArrow.Visible = False
        '
        'player1RightArrow
        '
        Me.player1RightArrow.BackColor = System.Drawing.Color.White
        Me.player1RightArrow.Location = New System.Drawing.Point(842, 27)
        Me.player1RightArrow.Name = "player1RightArrow"
        Me.player1RightArrow.Size = New System.Drawing.Size(11, 68)
        Me.player1RightArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.player1RightArrow.TabIndex = 34
        Me.player1RightArrow.TabStop = False
        Me.player1RightArrow.Visible = False
        '
        'player1LeftArrow
        '
        Me.player1LeftArrow.BackColor = System.Drawing.Color.White
        Me.player1LeftArrow.Image = Global.WheelOfFortune.My.Resources.Resources.CurrentPlayerLeftSide
        Me.player1LeftArrow.Location = New System.Drawing.Point(575, 27)
        Me.player1LeftArrow.Name = "player1LeftArrow"
        Me.player1LeftArrow.Size = New System.Drawing.Size(11, 68)
        Me.player1LeftArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.player1LeftArrow.TabIndex = 33
        Me.player1LeftArrow.TabStop = False
        Me.player1LeftArrow.Visible = False
        '
        'txtRecognition
        '
        Me.txtRecognition.Font = New System.Drawing.Font("Segoe UI", 16.0!)
        Me.txtRecognition.Location = New System.Drawing.Point(1454, 42)
        Me.txtRecognition.Name = "txtRecognition"
        Me.txtRecognition.ReadOnly = True
        Me.txtRecognition.Size = New System.Drawing.Size(326, 43)
        Me.txtRecognition.TabIndex = 29
        Me.txtRecognition.Visible = False
        '
        'lblPlayer2
        '
        Me.lblPlayer2.BackColor = System.Drawing.Color.Gold
        Me.lblPlayer2.Font = New System.Drawing.Font("Gotham Bold", 16.0!)
        Me.lblPlayer2.ForeColor = System.Drawing.Color.White
        Me.lblPlayer2.Location = New System.Drawing.Point(870, 27)
        Me.lblPlayer2.Name = "lblPlayer2"
        Me.lblPlayer2.Size = New System.Drawing.Size(278, 68)
        Me.lblPlayer2.TabIndex = 17
        Me.lblPlayer2.Text = "$0"
        Me.lblPlayer2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblPlayer2.UseMnemonic = False
        '
        'lblPlayer1
        '
        Me.lblPlayer1.BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblPlayer1.Font = New System.Drawing.Font("Gotham Bold", 16.0!)
        Me.lblPlayer1.ForeColor = System.Drawing.Color.White
        Me.lblPlayer1.Location = New System.Drawing.Point(575, 27)
        Me.lblPlayer1.Name = "lblPlayer1"
        Me.lblPlayer1.Size = New System.Drawing.Size(278, 68)
        Me.lblPlayer1.TabIndex = 10
        Me.lblPlayer1.Text = "$0"
        Me.lblPlayer1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblPlayer1.UseMnemonic = False
        '
        'quitBTN
        '
        Me.quitBTN.BackgroundImage = Global.WheelOfFortune.My.Resources.Resources.Delete
        Me.quitBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.quitBTN.Location = New System.Drawing.Point(1882, 42)
        Me.quitBTN.Name = "quitBTN"
        Me.quitBTN.Size = New System.Drawing.Size(46, 46)
        Me.quitBTN.TabIndex = 27
        Me.quitBTN.UseVisualStyleBackColor = True
        '
        'txtCurrentPlayer
        '
        Me.txtCurrentPlayer.Location = New System.Drawing.Point(108, 54)
        Me.txtCurrentPlayer.Name = "txtCurrentPlayer"
        Me.txtCurrentPlayer.ReadOnly = True
        Me.txtCurrentPlayer.Size = New System.Drawing.Size(88, 22)
        Me.txtCurrentPlayer.TabIndex = 24
        Me.txtCurrentPlayer.Visible = False
        '
        'lblCurrentValue
        '
        Me.lblCurrentValue.AutoSize = True
        Me.lblCurrentValue.Font = New System.Drawing.Font("Segoe UI Light", 10.0!)
        Me.lblCurrentValue.ForeColor = System.Drawing.Color.White
        Me.lblCurrentValue.Location = New System.Drawing.Point(20, 33)
        Me.lblCurrentValue.Name = "lblCurrentValue"
        Me.lblCurrentValue.Size = New System.Drawing.Size(19, 23)
        Me.lblCurrentValue.TabIndex = 25
        Me.lblCurrentValue.Text = "0"
        '
        'lblPlayer3
        '
        Me.lblPlayer3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblPlayer3.Font = New System.Drawing.Font("Gotham Bold", 16.0!)
        Me.lblPlayer3.ForeColor = System.Drawing.Color.White
        Me.lblPlayer3.Location = New System.Drawing.Point(1168, 27)
        Me.lblPlayer3.Name = "lblPlayer3"
        Me.lblPlayer3.Size = New System.Drawing.Size(278, 68)
        Me.lblPlayer3.TabIndex = 21
        Me.lblPlayer3.Text = "$0"
        Me.lblPlayer3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblPlayer3.UseMnemonic = False
        '
        'btnA
        '
        Me.btnA.BackColor = System.Drawing.Color.White
        Me.btnA.Enabled = False
        Me.btnA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnA.Font = New System.Drawing.Font("Helvetica-Condensed-Black-Se", 25.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnA.ForeColor = System.Drawing.Color.Black
        Me.btnA.Location = New System.Drawing.Point(3, 3)
        Me.btnA.Name = "btnA"
        Me.btnA.Size = New System.Drawing.Size(63, 64)
        Me.btnA.TabIndex = 0
        Me.btnA.Text = "A"
        Me.btnA.UseVisualStyleBackColor = False
        '
        'btnB
        '
        Me.btnB.BackColor = System.Drawing.Color.White
        Me.btnB.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnB.Font = New System.Drawing.Font("Helvetica-Condensed-Black-Se", 25.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnB.ForeColor = System.Drawing.Color.Black
        Me.btnB.Location = New System.Drawing.Point(72, 3)
        Me.btnB.Name = "btnB"
        Me.btnB.Size = New System.Drawing.Size(63, 64)
        Me.btnB.TabIndex = 1
        Me.btnB.Text = "B"
        Me.btnB.UseVisualStyleBackColor = False
        '
        'btnC
        '
        Me.btnC.BackColor = System.Drawing.Color.White
        Me.btnC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnC.Font = New System.Drawing.Font("Helvetica-Condensed-Black-Se", 25.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnC.ForeColor = System.Drawing.Color.Black
        Me.btnC.Location = New System.Drawing.Point(141, 3)
        Me.btnC.Name = "btnC"
        Me.btnC.Size = New System.Drawing.Size(63, 64)
        Me.btnC.TabIndex = 2
        Me.btnC.Text = "C"
        Me.btnC.UseVisualStyleBackColor = False
        '
        'btnD
        '
        Me.btnD.BackColor = System.Drawing.Color.White
        Me.btnD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnD.Font = New System.Drawing.Font("Helvetica-Condensed-Black-Se", 25.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnD.ForeColor = System.Drawing.Color.Black
        Me.btnD.Location = New System.Drawing.Point(210, 3)
        Me.btnD.Name = "btnD"
        Me.btnD.Size = New System.Drawing.Size(63, 64)
        Me.btnD.TabIndex = 3
        Me.btnD.Text = "D"
        Me.btnD.UseVisualStyleBackColor = False
        '
        'btnE
        '
        Me.btnE.BackColor = System.Drawing.Color.White
        Me.btnE.Enabled = False
        Me.btnE.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnE.Font = New System.Drawing.Font("Helvetica-Condensed-Black-Se", 25.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnE.ForeColor = System.Drawing.Color.Black
        Me.btnE.Location = New System.Drawing.Point(279, 3)
        Me.btnE.Name = "btnE"
        Me.btnE.Size = New System.Drawing.Size(63, 64)
        Me.btnE.TabIndex = 4
        Me.btnE.Text = "E"
        Me.btnE.UseVisualStyleBackColor = False
        '
        'usedLetterBoard
        '
        Me.usedLetterBoard.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.usedLetterBoard.Controls.Add(Me.btnA)
        Me.usedLetterBoard.Controls.Add(Me.btnB)
        Me.usedLetterBoard.Controls.Add(Me.btnC)
        Me.usedLetterBoard.Controls.Add(Me.btnD)
        Me.usedLetterBoard.Controls.Add(Me.btnE)
        Me.usedLetterBoard.Controls.Add(Me.btnF)
        Me.usedLetterBoard.Controls.Add(Me.btnG)
        Me.usedLetterBoard.Controls.Add(Me.btnH)
        Me.usedLetterBoard.Controls.Add(Me.btnI)
        Me.usedLetterBoard.Controls.Add(Me.btnJ)
        Me.usedLetterBoard.Controls.Add(Me.btnK)
        Me.usedLetterBoard.Controls.Add(Me.btnL)
        Me.usedLetterBoard.Controls.Add(Me.btnM)
        Me.usedLetterBoard.Controls.Add(Me.btnN)
        Me.usedLetterBoard.Controls.Add(Me.btnO)
        Me.usedLetterBoard.Controls.Add(Me.btnP)
        Me.usedLetterBoard.Controls.Add(Me.btnQ)
        Me.usedLetterBoard.Controls.Add(Me.btnR)
        Me.usedLetterBoard.Controls.Add(Me.btnS)
        Me.usedLetterBoard.Controls.Add(Me.btnT)
        Me.usedLetterBoard.Controls.Add(Me.btnU)
        Me.usedLetterBoard.Controls.Add(Me.btnV)
        Me.usedLetterBoard.Controls.Add(Me.btnW)
        Me.usedLetterBoard.Controls.Add(Me.btnX)
        Me.usedLetterBoard.Controls.Add(Me.btnY)
        Me.usedLetterBoard.Controls.Add(Me.btnZ)
        Me.usedLetterBoard.Controls.Add(Me.btnLoseATurn)
        Me.usedLetterBoard.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.usedLetterBoard.Location = New System.Drawing.Point(0, 1022)
        Me.usedLetterBoard.Name = "usedLetterBoard"
        Me.usedLetterBoard.Size = New System.Drawing.Size(1932, 70)
        Me.usedLetterBoard.TabIndex = 32
        '
        'btnF
        '
        Me.btnF.BackColor = System.Drawing.Color.White
        Me.btnF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnF.Font = New System.Drawing.Font("Helvetica-Condensed-Black-Se", 25.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnF.ForeColor = System.Drawing.Color.Black
        Me.btnF.Location = New System.Drawing.Point(348, 3)
        Me.btnF.Name = "btnF"
        Me.btnF.Size = New System.Drawing.Size(63, 64)
        Me.btnF.TabIndex = 5
        Me.btnF.Text = "F"
        Me.btnF.UseVisualStyleBackColor = False
        '
        'btnG
        '
        Me.btnG.BackColor = System.Drawing.Color.White
        Me.btnG.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnG.Font = New System.Drawing.Font("Helvetica-Condensed-Black-Se", 25.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnG.ForeColor = System.Drawing.Color.Black
        Me.btnG.Location = New System.Drawing.Point(417, 3)
        Me.btnG.Name = "btnG"
        Me.btnG.Size = New System.Drawing.Size(63, 64)
        Me.btnG.TabIndex = 6
        Me.btnG.Text = "G"
        Me.btnG.UseVisualStyleBackColor = False
        '
        'btnH
        '
        Me.btnH.BackColor = System.Drawing.Color.White
        Me.btnH.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnH.Font = New System.Drawing.Font("Helvetica-Condensed-Black-Se", 25.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnH.ForeColor = System.Drawing.Color.Black
        Me.btnH.Location = New System.Drawing.Point(486, 3)
        Me.btnH.Name = "btnH"
        Me.btnH.Size = New System.Drawing.Size(63, 64)
        Me.btnH.TabIndex = 7
        Me.btnH.Text = "H"
        Me.btnH.UseVisualStyleBackColor = False
        '
        'btnI
        '
        Me.btnI.BackColor = System.Drawing.Color.White
        Me.btnI.Enabled = False
        Me.btnI.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnI.Font = New System.Drawing.Font("Helvetica-Condensed-Black-Se", 25.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnI.ForeColor = System.Drawing.Color.Black
        Me.btnI.Location = New System.Drawing.Point(555, 3)
        Me.btnI.Name = "btnI"
        Me.btnI.Size = New System.Drawing.Size(63, 64)
        Me.btnI.TabIndex = 8
        Me.btnI.Text = "I"
        Me.btnI.UseVisualStyleBackColor = False
        '
        'btnJ
        '
        Me.btnJ.BackColor = System.Drawing.Color.White
        Me.btnJ.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnJ.Font = New System.Drawing.Font("Helvetica-Condensed-Black-Se", 25.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnJ.ForeColor = System.Drawing.Color.Black
        Me.btnJ.Location = New System.Drawing.Point(624, 3)
        Me.btnJ.Name = "btnJ"
        Me.btnJ.Size = New System.Drawing.Size(63, 64)
        Me.btnJ.TabIndex = 9
        Me.btnJ.Text = "J"
        Me.btnJ.UseVisualStyleBackColor = False
        '
        'btnK
        '
        Me.btnK.BackColor = System.Drawing.Color.White
        Me.btnK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnK.Font = New System.Drawing.Font("Helvetica-Condensed-Black-Se", 25.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnK.ForeColor = System.Drawing.Color.Black
        Me.btnK.Location = New System.Drawing.Point(693, 3)
        Me.btnK.Name = "btnK"
        Me.btnK.Size = New System.Drawing.Size(63, 64)
        Me.btnK.TabIndex = 10
        Me.btnK.Text = "K"
        Me.btnK.UseVisualStyleBackColor = False
        '
        'btnL
        '
        Me.btnL.BackColor = System.Drawing.Color.White
        Me.btnL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnL.Font = New System.Drawing.Font("Helvetica-Condensed-Black-Se", 25.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnL.ForeColor = System.Drawing.Color.Black
        Me.btnL.Location = New System.Drawing.Point(762, 3)
        Me.btnL.Name = "btnL"
        Me.btnL.Size = New System.Drawing.Size(63, 64)
        Me.btnL.TabIndex = 11
        Me.btnL.Text = "L"
        Me.btnL.UseVisualStyleBackColor = False
        '
        'btnM
        '
        Me.btnM.BackColor = System.Drawing.Color.White
        Me.btnM.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnM.Font = New System.Drawing.Font("Helvetica-Condensed-Black-Se", 25.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnM.ForeColor = System.Drawing.Color.Black
        Me.btnM.Location = New System.Drawing.Point(831, 3)
        Me.btnM.Name = "btnM"
        Me.btnM.Size = New System.Drawing.Size(63, 64)
        Me.btnM.TabIndex = 12
        Me.btnM.Text = "M"
        Me.btnM.UseVisualStyleBackColor = False
        '
        'btnN
        '
        Me.btnN.BackColor = System.Drawing.Color.White
        Me.btnN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnN.Font = New System.Drawing.Font("Helvetica-Condensed-Black-Se", 25.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnN.ForeColor = System.Drawing.Color.Black
        Me.btnN.Location = New System.Drawing.Point(900, 3)
        Me.btnN.Name = "btnN"
        Me.btnN.Size = New System.Drawing.Size(63, 64)
        Me.btnN.TabIndex = 13
        Me.btnN.Text = "N"
        Me.btnN.UseVisualStyleBackColor = False
        '
        'btnO
        '
        Me.btnO.BackColor = System.Drawing.Color.White
        Me.btnO.Enabled = False
        Me.btnO.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnO.Font = New System.Drawing.Font("Helvetica-Condensed-Black-Se", 25.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnO.ForeColor = System.Drawing.Color.Black
        Me.btnO.Location = New System.Drawing.Point(969, 3)
        Me.btnO.Name = "btnO"
        Me.btnO.Size = New System.Drawing.Size(63, 64)
        Me.btnO.TabIndex = 14
        Me.btnO.Text = "O"
        Me.btnO.UseVisualStyleBackColor = False
        '
        'btnP
        '
        Me.btnP.BackColor = System.Drawing.Color.White
        Me.btnP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnP.Font = New System.Drawing.Font("Helvetica-Condensed-Black-Se", 25.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnP.ForeColor = System.Drawing.Color.Black
        Me.btnP.Location = New System.Drawing.Point(1038, 3)
        Me.btnP.Name = "btnP"
        Me.btnP.Size = New System.Drawing.Size(63, 64)
        Me.btnP.TabIndex = 15
        Me.btnP.Text = "P"
        Me.btnP.UseVisualStyleBackColor = False
        '
        'btnQ
        '
        Me.btnQ.BackColor = System.Drawing.Color.White
        Me.btnQ.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnQ.Font = New System.Drawing.Font("Helvetica-Condensed-Black-Se", 25.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQ.ForeColor = System.Drawing.Color.Black
        Me.btnQ.Location = New System.Drawing.Point(1107, 3)
        Me.btnQ.Name = "btnQ"
        Me.btnQ.Size = New System.Drawing.Size(63, 64)
        Me.btnQ.TabIndex = 16
        Me.btnQ.Text = "Q"
        Me.btnQ.UseVisualStyleBackColor = False
        '
        'btnR
        '
        Me.btnR.BackColor = System.Drawing.Color.White
        Me.btnR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnR.Font = New System.Drawing.Font("Helvetica-Condensed-Black-Se", 25.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnR.ForeColor = System.Drawing.Color.Black
        Me.btnR.Location = New System.Drawing.Point(1176, 3)
        Me.btnR.Name = "btnR"
        Me.btnR.Size = New System.Drawing.Size(63, 64)
        Me.btnR.TabIndex = 17
        Me.btnR.Text = "R"
        Me.btnR.UseVisualStyleBackColor = False
        '
        'btnS
        '
        Me.btnS.BackColor = System.Drawing.Color.White
        Me.btnS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnS.Font = New System.Drawing.Font("Helvetica-Condensed-Black-Se", 25.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnS.ForeColor = System.Drawing.Color.Black
        Me.btnS.Location = New System.Drawing.Point(1245, 3)
        Me.btnS.Name = "btnS"
        Me.btnS.Size = New System.Drawing.Size(63, 64)
        Me.btnS.TabIndex = 18
        Me.btnS.Text = "S"
        Me.btnS.UseVisualStyleBackColor = False
        '
        'btnT
        '
        Me.btnT.BackColor = System.Drawing.Color.White
        Me.btnT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnT.Font = New System.Drawing.Font("Helvetica-Condensed-Black-Se", 25.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnT.ForeColor = System.Drawing.Color.Black
        Me.btnT.Location = New System.Drawing.Point(1314, 3)
        Me.btnT.Name = "btnT"
        Me.btnT.Size = New System.Drawing.Size(63, 64)
        Me.btnT.TabIndex = 33
        Me.btnT.Text = "T"
        Me.btnT.UseVisualStyleBackColor = False
        '
        'btnU
        '
        Me.btnU.BackColor = System.Drawing.Color.White
        Me.btnU.Enabled = False
        Me.btnU.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnU.Font = New System.Drawing.Font("Helvetica-Condensed-Black-Se", 25.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnU.ForeColor = System.Drawing.Color.Black
        Me.btnU.Location = New System.Drawing.Point(1383, 3)
        Me.btnU.Name = "btnU"
        Me.btnU.Size = New System.Drawing.Size(63, 64)
        Me.btnU.TabIndex = 34
        Me.btnU.Text = "U"
        Me.btnU.UseVisualStyleBackColor = False
        '
        'btnV
        '
        Me.btnV.BackColor = System.Drawing.Color.White
        Me.btnV.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnV.Font = New System.Drawing.Font("Helvetica-Condensed-Black-Se", 25.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnV.ForeColor = System.Drawing.Color.Black
        Me.btnV.Location = New System.Drawing.Point(1452, 3)
        Me.btnV.Name = "btnV"
        Me.btnV.Size = New System.Drawing.Size(63, 64)
        Me.btnV.TabIndex = 35
        Me.btnV.Text = "V"
        Me.btnV.UseVisualStyleBackColor = False
        '
        'btnW
        '
        Me.btnW.BackColor = System.Drawing.Color.White
        Me.btnW.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnW.Font = New System.Drawing.Font("Helvetica-Condensed-Black-Se", 25.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnW.ForeColor = System.Drawing.Color.Black
        Me.btnW.Location = New System.Drawing.Point(1521, 3)
        Me.btnW.Name = "btnW"
        Me.btnW.Size = New System.Drawing.Size(63, 64)
        Me.btnW.TabIndex = 33
        Me.btnW.Text = "W"
        Me.btnW.UseVisualStyleBackColor = False
        '
        'btnX
        '
        Me.btnX.BackColor = System.Drawing.Color.White
        Me.btnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnX.Font = New System.Drawing.Font("Helvetica-Condensed-Black-Se", 25.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnX.ForeColor = System.Drawing.Color.Black
        Me.btnX.Location = New System.Drawing.Point(1590, 3)
        Me.btnX.Name = "btnX"
        Me.btnX.Size = New System.Drawing.Size(63, 64)
        Me.btnX.TabIndex = 33
        Me.btnX.Text = "X"
        Me.btnX.UseVisualStyleBackColor = False
        '
        'btnY
        '
        Me.btnY.BackColor = System.Drawing.Color.White
        Me.btnY.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnY.Font = New System.Drawing.Font("Helvetica-Condensed-Black-Se", 25.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnY.ForeColor = System.Drawing.Color.Black
        Me.btnY.Location = New System.Drawing.Point(1659, 3)
        Me.btnY.Name = "btnY"
        Me.btnY.Size = New System.Drawing.Size(63, 64)
        Me.btnY.TabIndex = 36
        Me.btnY.Text = "Y"
        Me.btnY.UseVisualStyleBackColor = False
        '
        'btnZ
        '
        Me.btnZ.BackColor = System.Drawing.Color.White
        Me.btnZ.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnZ.Font = New System.Drawing.Font("Helvetica-Condensed-Black-Se", 25.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnZ.ForeColor = System.Drawing.Color.Black
        Me.btnZ.Location = New System.Drawing.Point(1728, 3)
        Me.btnZ.Name = "btnZ"
        Me.btnZ.Size = New System.Drawing.Size(63, 64)
        Me.btnZ.TabIndex = 37
        Me.btnZ.Text = "Z"
        Me.btnZ.UseVisualStyleBackColor = False
        '
        'btnLoseATurn
        '
        Me.btnLoseATurn.BackgroundImage = Global.WheelOfFortune.My.Resources.Resources.NameTag
        Me.btnLoseATurn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnLoseATurn.Font = New System.Drawing.Font("Gotham Bold", 7.8!)
        Me.btnLoseATurn.ForeColor = System.Drawing.Color.White
        Me.btnLoseATurn.Location = New System.Drawing.Point(3, 73)
        Me.btnLoseATurn.Name = "btnLoseATurn"
        Me.btnLoseATurn.Size = New System.Drawing.Size(154, 64)
        Me.btnLoseATurn.TabIndex = 38
        Me.btnLoseATurn.Text = "SKIP PLAYER"
        Me.btnLoseATurn.UseVisualStyleBackColor = True
        '
        'tmrCheckPlayer
        '
        '
        'AxWindowsMediaPlayer1
        '
        Me.AxWindowsMediaPlayer1.Enabled = True
        Me.AxWindowsMediaPlayer1.Location = New System.Drawing.Point(616, 397)
        Me.AxWindowsMediaPlayer1.Name = "AxWindowsMediaPlayer1"
        Me.AxWindowsMediaPlayer1.OcxState = CType(resources.GetObject("AxWindowsMediaPlayer1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxWindowsMediaPlayer1.Size = New System.Drawing.Size(39, 43)
        Me.AxWindowsMediaPlayer1.TabIndex = 33
        Me.AxWindowsMediaPlayer1.Visible = False
        '
        'tmrLetterReveal
        '
        '
        'tmrSolveFailed
        '
        '
        'tmrCheckVowels
        '
        '
        'lstMessages
        '
        Me.lstMessages.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.lstMessages.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstMessages.Font = New System.Drawing.Font("Gotham Book", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lstMessages.ForeColor = System.Drawing.Color.White
        Me.lstMessages.FormattingEnabled = True
        Me.lstMessages.ItemHeight = 18
        Me.lstMessages.Location = New System.Drawing.Point(1481, 94)
        Me.lstMessages.Name = "lstMessages"
        Me.lstMessages.Size = New System.Drawing.Size(277, 180)
        Me.lstMessages.TabIndex = 46
        Me.lstMessages.Visible = False
        '
        'tmrFinalSpin
        '
        '
        'BonusCardEnvelope1
        '
        Me.BonusCardEnvelope1.BackgroundImage = CType(resources.GetObject("BonusCardEnvelope1.BackgroundImage"), System.Drawing.Image)
        Me.BonusCardEnvelope1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BonusCardEnvelope1.Location = New System.Drawing.Point(831, 375)
        Me.BonusCardEnvelope1.moneyValue = WheelOfFortune.BonusCardEnvelope.MoneyValueType.M34000
        Me.BonusCardEnvelope1.Name = "BonusCardEnvelope1"
        Me.BonusCardEnvelope1.revealed = False
        Me.BonusCardEnvelope1.Size = New System.Drawing.Size(317, 150)
        Me.BonusCardEnvelope1.TabIndex = 37
        Me.BonusCardEnvelope1.Visible = False
        '
        'NameTag3
        '
        Me.NameTag3.BackColor = System.Drawing.Color.Transparent
        Me.NameTag3.BackgroundImage = CType(resources.GetObject("NameTag3.BackgroundImage"), System.Drawing.Image)
        Me.NameTag3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.NameTag3.contestantName = "NAME"
        Me.NameTag3.Location = New System.Drawing.Point(1239, 135)
        Me.NameTag3.Name = "NameTag3"
        Me.NameTag3.Size = New System.Drawing.Size(150, 48)
        Me.NameTag3.TabIndex = 36
        '
        'NameTag2
        '
        Me.NameTag2.BackColor = System.Drawing.Color.Transparent
        Me.NameTag2.BackgroundImage = CType(resources.GetObject("NameTag2.BackgroundImage"), System.Drawing.Image)
        Me.NameTag2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.NameTag2.contestantName = "NAME"
        Me.NameTag2.Location = New System.Drawing.Point(935, 135)
        Me.NameTag2.Name = "NameTag2"
        Me.NameTag2.Size = New System.Drawing.Size(150, 48)
        Me.NameTag2.TabIndex = 35
        '
        'NameTag1
        '
        Me.NameTag1.BackColor = System.Drawing.Color.Transparent
        Me.NameTag1.BackgroundImage = CType(resources.GetObject("NameTag1.BackgroundImage"), System.Drawing.Image)
        Me.NameTag1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.NameTag1.contestantName = "NAME"
        Me.NameTag1.Location = New System.Drawing.Point(637, 134)
        Me.NameTag1.Name = "NameTag1"
        Me.NameTag1.Size = New System.Drawing.Size(150, 48)
        Me.NameTag1.TabIndex = 34
        '
        'tmrBonusTimer
        '
        '
        'frmScore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.ForestGreen
        Me.ClientSize = New System.Drawing.Size(1932, 1092)
        Me.Controls.Add(Me.lstMessages)
        Me.Controls.Add(Me.BonusCardEnvelope1)
        Me.Controls.Add(Me.NameTag3)
        Me.Controls.Add(Me.NameTag2)
        Me.Controls.Add(Me.NameTag1)
        Me.Controls.Add(Me.AxWindowsMediaPlayer1)
        Me.Controls.Add(Me.usedLetterBoard)
        Me.Controls.Add(Me.pnlScore)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmScore"
        Me.ShowInTaskbar = False
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.Color.ForestGreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlScore.ResumeLayout(False)
        Me.pnlScore.PerformLayout()
        CType(Me.lstDownArrow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gift, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Wild, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Million, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Prize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Mystery, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.halfcar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.halfcar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.player3RightArrow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.player3LeftArrow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.player2RightArrow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.player2LeftArrow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.player1RightArrow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.player1LeftArrow, System.ComponentModel.ISupportInitialize).EndInit()
        Me.usedLetterBoard.ResumeLayout(False)
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlScore As Panel
    Friend WithEvents txtRecognition As TextBox
    Friend WithEvents notifyBar As Label
    Friend WithEvents lblPlayer2 As Label
    Friend WithEvents lblPlayer1 As Label
    Friend WithEvents quitBTN As Button
    Friend WithEvents txtCurrentPlayer As TextBox
    Friend WithEvents lblCurrentValue As Label
    Friend WithEvents lblPlayer3 As Label
    Friend WithEvents btnA As Button
    Friend WithEvents btnB As Button
    Friend WithEvents btnC As Button
    Friend WithEvents btnD As Button
    Friend WithEvents btnE As Button
    Friend WithEvents usedLetterBoard As FlowLayoutPanel
    Friend WithEvents btnF As Button
    Friend WithEvents btnG As Button
    Friend WithEvents btnH As Button
    Friend WithEvents btnI As Button
    Friend WithEvents btnJ As Button
    Friend WithEvents btnK As Button
    Friend WithEvents btnL As Button
    Friend WithEvents btnM As Button
    Friend WithEvents btnN As Button
    Friend WithEvents btnO As Button
    Friend WithEvents btnP As Button
    Friend WithEvents btnQ As Button
    Friend WithEvents btnR As Button
    Friend WithEvents btnS As Button
    Friend WithEvents btnT As Button
    Friend WithEvents btnU As Button
    Friend WithEvents btnV As Button
    Friend WithEvents btnW As Button
    Friend WithEvents btnX As Button
    Friend WithEvents btnY As Button
    Friend WithEvents btnZ As Button
    Friend WithEvents player1LeftArrow As PictureBox
    Friend WithEvents player3RightArrow As PictureBox
    Friend WithEvents player3LeftArrow As PictureBox
    Friend WithEvents player2RightArrow As PictureBox
    Friend WithEvents player2LeftArrow As PictureBox
    Friend WithEvents player1RightArrow As PictureBox
    Friend WithEvents tmrCheckPlayer As Timer
    Friend WithEvents halfcar1 As PictureBox
    Friend WithEvents Gift As PictureBox
    Friend WithEvents Wild As PictureBox
    Friend WithEvents Million As PictureBox
    Friend WithEvents Prize As PictureBox
    Friend WithEvents Mystery As PictureBox
    Friend WithEvents halfcar2 As PictureBox
    Friend WithEvents AxWindowsMediaPlayer1 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents btnBonusTimerStart As Button
    Friend WithEvents lblControllerSpinResult As Label
    Friend WithEvents tmrLetterReveal As Timer
    Friend WithEvents tmrBonusLetterReveal As Timer
    Friend WithEvents tmrSolveFailed As Timer
    Friend WithEvents lblPlayer3Total As Label
    Friend WithEvents lblPlayer2Total As Label
    Friend WithEvents lblPlayer1Total As Label
    Friend WithEvents tmrCurrentPlayerFlash As Timer
    Friend WithEvents NameTag1 As NameTag
    Friend WithEvents NameTag2 As NameTag
    Friend WithEvents NameTag3 As NameTag
    Friend WithEvents tmrCheckVowels As Timer
    Friend WithEvents btnLoseATurn As Button
    Friend WithEvents BonusCardEnvelope1 As BonusCardEnvelope
    Friend WithEvents lstMessages As ListBox
    Friend WithEvents lstDownArrow As PictureBox
    Friend WithEvents tmrFinalSpin As Timer
    Friend WithEvents btnHelp As Button
    Friend WithEvents tmrBonusTimer As Timer
    Friend WithEvents lblNumberOfTurns As Label
End Class
