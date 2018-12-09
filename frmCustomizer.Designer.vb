<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCustomizer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCustomizer))
        Me.pnlCreator = New System.Windows.Forms.Panel()
        Me.chk80sPuzzle = New System.Windows.Forms.CheckBox()
        Me.btnPlay = New System.Windows.Forms.Button()
        Me.chkCrosswordModify = New System.Windows.Forms.CheckBox()
        Me.txtCrosswordClue = New System.Windows.Forms.TextBox()
        Me.flpPuzzleList = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnClose = New System.Windows.Forms.PictureBox()
        Me.lblInstructions = New System.Windows.Forms.Label()
        Me.btnPreview = New System.Windows.Forms.Button()
        Me.cboRound = New System.Windows.Forms.ComboBox()
        Me.lblRound = New System.Windows.Forms.Label()
        Me.btnCreate = New System.Windows.Forms.Button()
        Me.pboxBoard = New System.Windows.Forms.PictureBox()
        Me.cboPack = New System.Windows.Forms.ComboBox()
        Me.lblPack = New System.Windows.Forms.Label()
        Me.lblPuzzle = New System.Windows.Forms.Label()
        Me.cboCategory = New System.Windows.Forms.ComboBox()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.txtPuzzle = New System.Windows.Forms.TextBox()
        Me.lblCreatorTitle = New System.Windows.Forms.Label()
        Me.pnlPackSelect = New System.Windows.Forms.Panel()
        Me.cboPackSelect = New System.Windows.Forms.ComboBox()
        Me.lblPackSelect = New System.Windows.Forms.Label()
        Me.toolTipCrosswordClue = New System.Windows.Forms.ToolTip(Me.components)
        Me.toolTipPuzzle = New System.Windows.Forms.ToolTip(Me.components)
        Me.pnlCreator.SuspendLayout()
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pboxBoard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPackSelect.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlCreator
        '
        Me.pnlCreator.BackColor = System.Drawing.Color.Black
        Me.pnlCreator.Controls.Add(Me.chk80sPuzzle)
        Me.pnlCreator.Controls.Add(Me.btnPlay)
        Me.pnlCreator.Controls.Add(Me.chkCrosswordModify)
        Me.pnlCreator.Controls.Add(Me.txtCrosswordClue)
        Me.pnlCreator.Controls.Add(Me.flpPuzzleList)
        Me.pnlCreator.Controls.Add(Me.btnClose)
        Me.pnlCreator.Controls.Add(Me.lblInstructions)
        Me.pnlCreator.Controls.Add(Me.btnPreview)
        Me.pnlCreator.Controls.Add(Me.cboRound)
        Me.pnlCreator.Controls.Add(Me.lblRound)
        Me.pnlCreator.Controls.Add(Me.btnCreate)
        Me.pnlCreator.Controls.Add(Me.pboxBoard)
        Me.pnlCreator.Controls.Add(Me.cboPack)
        Me.pnlCreator.Controls.Add(Me.lblPack)
        Me.pnlCreator.Controls.Add(Me.lblPuzzle)
        Me.pnlCreator.Controls.Add(Me.cboCategory)
        Me.pnlCreator.Controls.Add(Me.lblCategory)
        Me.pnlCreator.Controls.Add(Me.txtPuzzle)
        Me.pnlCreator.Controls.Add(Me.lblCreatorTitle)
        Me.pnlCreator.Location = New System.Drawing.Point(245, 271)
        Me.pnlCreator.Name = "pnlCreator"
        Me.pnlCreator.Size = New System.Drawing.Size(1505, 576)
        Me.pnlCreator.TabIndex = 0
        '
        'chk80sPuzzle
        '
        Me.chk80sPuzzle.AutoSize = True
        Me.chk80sPuzzle.Font = New System.Drawing.Font("Gotham Bold", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk80sPuzzle.ForeColor = System.Drawing.Color.White
        Me.chk80sPuzzle.Location = New System.Drawing.Point(514, 312)
        Me.chk80sPuzzle.Name = "chk80sPuzzle"
        Me.chk80sPuzzle.Size = New System.Drawing.Size(122, 21)
        Me.chk80sPuzzle.TabIndex = 18
        Me.chk80sPuzzle.Text = "80's PUZZLE"
        Me.chk80sPuzzle.UseVisualStyleBackColor = True
        '
        'btnPlay
        '
        Me.btnPlay.Font = New System.Drawing.Font("Gotham Bold", 7.8!)
        Me.btnPlay.Location = New System.Drawing.Point(1219, 451)
        Me.btnPlay.Name = "btnPlay"
        Me.btnPlay.Size = New System.Drawing.Size(133, 65)
        Me.btnPlay.TabIndex = 17
        Me.btnPlay.Text = "PLAY"
        Me.btnPlay.UseVisualStyleBackColor = True
        '
        'chkCrosswordModify
        '
        Me.chkCrosswordModify.AutoSize = True
        Me.chkCrosswordModify.Font = New System.Drawing.Font("Gotham Bold", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCrosswordModify.ForeColor = System.Drawing.Color.White
        Me.chkCrosswordModify.Location = New System.Drawing.Point(517, 406)
        Me.chkCrosswordModify.Name = "chkCrosswordModify"
        Me.chkCrosswordModify.Size = New System.Drawing.Size(239, 21)
        Me.chkCrosswordModify.TabIndex = 16
        Me.chkCrosswordModify.Text = "MANUALLY MODIFY PUZZLE"
        Me.chkCrosswordModify.UseVisualStyleBackColor = True
        '
        'txtCrosswordClue
        '
        Me.txtCrosswordClue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCrosswordClue.Font = New System.Drawing.Font("Gotham Bold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCrosswordClue.Location = New System.Drawing.Point(514, 273)
        Me.txtCrosswordClue.MaxLength = 52
        Me.txtCrosswordClue.Name = "txtCrosswordClue"
        Me.txtCrosswordClue.Size = New System.Drawing.Size(386, 33)
        Me.txtCrosswordClue.TabIndex = 15
        Me.toolTipCrosswordClue.SetToolTip(Me.txtCrosswordClue, "Enter your clue for the crossword such as ""SEEING RED,"" ""BABY ________"", etc. tha" &
        "t creates a theme for all of the words.")
        Me.txtCrosswordClue.Visible = False
        '
        'flpPuzzleList
        '
        Me.flpPuzzleList.AutoScroll = True
        Me.flpPuzzleList.Dock = System.Windows.Forms.DockStyle.Left
        Me.flpPuzzleList.Location = New System.Drawing.Point(0, 0)
        Me.flpPuzzleList.Name = "flpPuzzleList"
        Me.flpPuzzleList.Size = New System.Drawing.Size(503, 576)
        Me.flpPuzzleList.TabIndex = 14
        '
        'btnClose
        '
        Me.btnClose.Image = Global.WheelOfFortune.My.Resources.Resources.Delete
        Me.btnClose.Location = New System.Drawing.Point(1449, 19)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(34, 32)
        Me.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnClose.TabIndex = 13
        Me.btnClose.TabStop = False
        '
        'lblInstructions
        '
        Me.lblInstructions.AutoSize = True
        Me.lblInstructions.Font = New System.Drawing.Font("Gotham Bold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInstructions.ForeColor = System.Drawing.Color.White
        Me.lblInstructions.Location = New System.Drawing.Point(510, 79)
        Me.lblInstructions.Name = "lblInstructions"
        Me.lblInstructions.Size = New System.Drawing.Size(842, 38)
        Me.lblInstructions.TabIndex = 12
        Me.lblInstructions.Text = "CREATE YOUR OWN PUZZLES BELOW." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "PLEASE ENTER PUZZLES FOR ALL ROUNDS AS CONTESTANT" &
    "S MAY SOLVE PUZZLES QUICKLY." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnPreview
        '
        Me.btnPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPreview.Font = New System.Drawing.Font("Gotham Bold", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPreview.ForeColor = System.Drawing.Color.Black
        Me.btnPreview.Location = New System.Drawing.Point(1050, 451)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(133, 65)
        Me.btnPreview.TabIndex = 5
        Me.btnPreview.Text = "PREVIEW"
        Me.btnPreview.UseVisualStyleBackColor = True
        '
        'cboRound
        '
        Me.cboRound.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRound.Font = New System.Drawing.Font("Gotham Bold", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRound.FormattingEnabled = True
        Me.cboRound.Items.AddRange(New Object() {"TOSS-UP 1", "TOSS-UP 2", "ROUND 1", "ROUND 2", "ROUND 3", "TOSS-UP 3", "ROUND 4", "ROUND 5", "ROUND 6", "ROUND 7", "ROUND 8", "ROUND 9", "TIEBREAKER TOSS-UP", "BONUS ROUND OPTION 1", "BONUS ROUND OPTION 2", "BONUS ROUND OPTION 3"})
        Me.cboRound.Location = New System.Drawing.Point(516, 460)
        Me.cboRound.Name = "cboRound"
        Me.cboRound.Size = New System.Drawing.Size(386, 29)
        Me.cboRound.TabIndex = 4
        '
        'lblRound
        '
        Me.lblRound.AutoSize = True
        Me.lblRound.Font = New System.Drawing.Font("Gotham Bold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRound.ForeColor = System.Drawing.Color.White
        Me.lblRound.Location = New System.Drawing.Point(513, 432)
        Me.lblRound.Name = "lblRound"
        Me.lblRound.Size = New System.Drawing.Size(74, 19)
        Me.lblRound.TabIndex = 9
        Me.lblRound.Text = "ROUND"
        '
        'btnCreate
        '
        Me.btnCreate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCreate.Font = New System.Drawing.Font("Gotham Bold", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreate.ForeColor = System.Drawing.Color.Black
        Me.btnCreate.Location = New System.Drawing.Point(609, 497)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(152, 65)
        Me.btnCreate.TabIndex = 6
        Me.btnCreate.Text = "CREATE/UPDATE"
        Me.btnCreate.UseVisualStyleBackColor = True
        '
        'pboxBoard
        '
        Me.pboxBoard.Image = Global.WheelOfFortune.My.Resources.Resources.WheelPuzzleBoard
        Me.pboxBoard.Location = New System.Drawing.Point(950, 198)
        Me.pboxBoard.Name = "pboxBoard"
        Me.pboxBoard.Size = New System.Drawing.Size(497, 202)
        Me.pboxBoard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pboxBoard.TabIndex = 7
        Me.pboxBoard.TabStop = False
        '
        'cboPack
        '
        Me.cboPack.Font = New System.Drawing.Font("Gotham Bold", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPack.FormattingEnabled = True
        Me.cboPack.Location = New System.Drawing.Point(514, 165)
        Me.cboPack.Name = "cboPack"
        Me.cboPack.Size = New System.Drawing.Size(386, 29)
        Me.cboPack.TabIndex = 1
        '
        'lblPack
        '
        Me.lblPack.AutoSize = True
        Me.lblPack.Font = New System.Drawing.Font("Gotham Bold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPack.ForeColor = System.Drawing.Color.White
        Me.lblPack.Location = New System.Drawing.Point(510, 134)
        Me.lblPack.Name = "lblPack"
        Me.lblPack.Size = New System.Drawing.Size(58, 19)
        Me.lblPack.TabIndex = 5
        Me.lblPack.Text = "PACK"
        '
        'lblPuzzle
        '
        Me.lblPuzzle.AutoSize = True
        Me.lblPuzzle.Font = New System.Drawing.Font("Gotham Bold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPuzzle.ForeColor = System.Drawing.Color.White
        Me.lblPuzzle.Location = New System.Drawing.Point(515, 342)
        Me.lblPuzzle.Name = "lblPuzzle"
        Me.lblPuzzle.Size = New System.Drawing.Size(79, 19)
        Me.lblPuzzle.TabIndex = 4
        Me.lblPuzzle.Text = "PUZZLE"
        '
        'cboCategory
        '
        Me.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCategory.Font = New System.Drawing.Font("Gotham Bold", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Items.AddRange(New Object() {"AROUND THE HOUSE", "BEFORE & AFTER", "CHARACTER", "CHARACTERS", "CLASSIC TV", "COLLEGE LIFE", "EVENT", "EVENTS", "FAMILY", "FOOD & DRINK", "FUN & GAMES", "HEADLINE", "IN THE KITCHEN", "LANDMARK", "LANDMARKS", "LIVING THING", "LIVING THINGS", "MOVIE QUOTE", "MOVIE TITLE", "OCCUPATION", "ON THE MAP", "PEOPLE", "PERSON", "PHRASE", "PLACE", "PLACES", "PROPER NAME", "QUOTATION", "RHYME TIME", "SAME LETTER", "SAME NAME", "SHOW BIZ", "SONG/ARTIST", "SONG LYRICS", "SONG TITLE", "STAR & ROLE", "THE 60's", "THE 70's", "THE 80's", "THE 90's", "THING", "THINGS", "TITLE", "TITLE/AUTHOR", "TV TITLE", "WHAT ARE YOU DOING?", "WHAT ARE YOU WEARING?", "CROSSWORD"})
        Me.cboCategory.Location = New System.Drawing.Point(514, 238)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(386, 29)
        Me.cboCategory.TabIndex = 2
        '
        'lblCategory
        '
        Me.lblCategory.AutoSize = True
        Me.lblCategory.Font = New System.Drawing.Font("Gotham Bold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategory.ForeColor = System.Drawing.Color.White
        Me.lblCategory.Location = New System.Drawing.Point(510, 207)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(108, 19)
        Me.lblCategory.TabIndex = 2
        Me.lblCategory.Text = "CATEGORY"
        '
        'txtPuzzle
        '
        Me.txtPuzzle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPuzzle.Font = New System.Drawing.Font("Helvetica-Condensed-Black-Se", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPuzzle.Location = New System.Drawing.Point(517, 369)
        Me.txtPuzzle.Name = "txtPuzzle"
        Me.txtPuzzle.Size = New System.Drawing.Size(385, 31)
        Me.txtPuzzle.TabIndex = 3
        Me.toolTipPuzzle.SetToolTip(Me.txtPuzzle, resources.GetString("txtPuzzle.ToolTip"))
        '
        'lblCreatorTitle
        '
        Me.lblCreatorTitle.AutoSize = True
        Me.lblCreatorTitle.Font = New System.Drawing.Font("Gotham Bold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreatorTitle.ForeColor = System.Drawing.Color.White
        Me.lblCreatorTitle.Location = New System.Drawing.Point(509, 33)
        Me.lblCreatorTitle.Name = "lblCreatorTitle"
        Me.lblCreatorTitle.Size = New System.Drawing.Size(241, 28)
        Me.lblCreatorTitle.TabIndex = 0
        Me.lblCreatorTitle.Text = "PUZZLE CREATOR"
        '
        'pnlPackSelect
        '
        Me.pnlPackSelect.BackColor = System.Drawing.Color.Black
        Me.pnlPackSelect.Controls.Add(Me.cboPackSelect)
        Me.pnlPackSelect.Controls.Add(Me.lblPackSelect)
        Me.pnlPackSelect.Location = New System.Drawing.Point(245, 271)
        Me.pnlPackSelect.Name = "pnlPackSelect"
        Me.pnlPackSelect.Size = New System.Drawing.Size(1502, 576)
        Me.pnlPackSelect.TabIndex = 15
        '
        'cboPackSelect
        '
        Me.cboPackSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPackSelect.Font = New System.Drawing.Font("Gotham Bold", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPackSelect.FormattingEnabled = True
        Me.cboPackSelect.Items.AddRange(New Object() {"CREATE NEW PACK", "CREATE SINGLE PUZZLE"})
        Me.cboPackSelect.Location = New System.Drawing.Point(509, 281)
        Me.cboPackSelect.Name = "cboPackSelect"
        Me.cboPackSelect.Size = New System.Drawing.Size(402, 42)
        Me.cboPackSelect.TabIndex = 1
        '
        'lblPackSelect
        '
        Me.lblPackSelect.AutoSize = True
        Me.lblPackSelect.Font = New System.Drawing.Font("Gotham Bold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPackSelect.ForeColor = System.Drawing.Color.White
        Me.lblPackSelect.Location = New System.Drawing.Point(528, 242)
        Me.lblPackSelect.Name = "lblPackSelect"
        Me.lblPackSelect.Size = New System.Drawing.Size(341, 28)
        Me.lblPackSelect.TabIndex = 0
        Me.lblPackSelect.Text = "SELECT A PACK TO BEGIN"
        '
        'toolTipCrosswordClue
        '
        Me.toolTipCrosswordClue.ToolTipTitle = "Crossword Clue"
        '
        'toolTipPuzzle
        '
        Me.toolTipPuzzle.ToolTipTitle = "Puzzle"
        '
        'frmCustomizer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.WheelOfFortune.My.Resources.Resources.WheelBoardBKG
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1942, 1102)
        Me.Controls.Add(Me.pnlPackSelect)
        Me.Controls.Add(Me.pnlCreator)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCustomizer"
        Me.Text = "Customizer"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlCreator.ResumeLayout(False)
        Me.pnlCreator.PerformLayout()
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pboxBoard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPackSelect.ResumeLayout(False)
        Me.pnlPackSelect.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlCreator As Panel
    Friend WithEvents btnCreate As Button
    Friend WithEvents pboxBoard As PictureBox
    Friend WithEvents cboPack As ComboBox
    Friend WithEvents lblPack As Label
    Friend WithEvents lblPuzzle As Label
    Friend WithEvents cboCategory As ComboBox
    Friend WithEvents lblCategory As Label
    Friend WithEvents txtPuzzle As TextBox
    Friend WithEvents lblCreatorTitle As Label
    Friend WithEvents cboRound As ComboBox
    Friend WithEvents lblRound As Label
    Friend WithEvents btnPreview As Button
    Friend WithEvents lblInstructions As Label
    Friend WithEvents btnClose As PictureBox
    Friend WithEvents flpPuzzleList As FlowLayoutPanel
    Friend WithEvents pnlPackSelect As Panel
    Friend WithEvents cboPackSelect As ComboBox
    Friend WithEvents lblPackSelect As Label
    Friend WithEvents txtCrosswordClue As TextBox
    Friend WithEvents toolTipCrosswordClue As ToolTip
    Friend WithEvents toolTipPuzzle As ToolTip
    Friend WithEvents chkCrosswordModify As CheckBox
    Friend WithEvents btnPlay As Button
    Friend WithEvents chk80sPuzzle As CheckBox
End Class
