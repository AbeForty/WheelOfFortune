<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCompendium
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCompendium))
        Me.pnlSettings = New System.Windows.Forms.Panel()
        Me.btnClose = New System.Windows.Forms.PictureBox()
        Me.splNewGame = New System.Windows.Forms.SplitContainer()
        Me.pnlNewGame = New System.Windows.Forms.Panel()
        Me.wbCompendium = New System.Windows.Forms.WebBrowser()
        Me.cboDate = New System.Windows.Forms.ComboBox()
        Me.lblPackSelect = New System.Windows.Forms.Label()
        Me.numSeason = New System.Windows.Forms.NumericUpDown()
        Me.lblNumOfPlayers = New System.Windows.Forms.Label()
        Me.btnStartGame = New System.Windows.Forms.Button()
        Me.lstPuzzle = New System.Windows.Forms.ListBox()
        Me.pboxSet = New System.Windows.Forms.PictureBox()
        Me.lblSettings = New System.Windows.Forms.Label()
        Me.pnlSettings.SuspendLayout()
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.splNewGame, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splNewGame.Panel1.SuspendLayout()
        Me.splNewGame.Panel2.SuspendLayout()
        Me.splNewGame.SuspendLayout()
        Me.pnlNewGame.SuspendLayout()
        CType(Me.numSeason, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pboxSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlSettings
        '
        Me.pnlSettings.BackColor = System.Drawing.Color.Black
        Me.pnlSettings.Controls.Add(Me.btnClose)
        Me.pnlSettings.Controls.Add(Me.splNewGame)
        Me.pnlSettings.Controls.Add(Me.lblSettings)
        Me.pnlSettings.Location = New System.Drawing.Point(181, 121)
        Me.pnlSettings.Name = "pnlSettings"
        Me.pnlSettings.Size = New System.Drawing.Size(1538, 884)
        Me.pnlSettings.TabIndex = 1
        '
        'btnClose
        '
        Me.btnClose.Image = Global.WheelOfFortune.My.Resources.Resources.Delete
        Me.btnClose.Location = New System.Drawing.Point(1484, 13)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(34, 32)
        Me.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnClose.TabIndex = 16
        Me.btnClose.TabStop = False
        '
        'splNewGame
        '
        Me.splNewGame.Location = New System.Drawing.Point(19, 80)
        Me.splNewGame.Name = "splNewGame"
        '
        'splNewGame.Panel1
        '
        Me.splNewGame.Panel1.Controls.Add(Me.pnlNewGame)
        '
        'splNewGame.Panel2
        '
        Me.splNewGame.Panel2.Controls.Add(Me.lstPuzzle)
        Me.splNewGame.Panel2.Controls.Add(Me.pboxSet)
        Me.splNewGame.Size = New System.Drawing.Size(1465, 754)
        Me.splNewGame.SplitterDistance = 746
        Me.splNewGame.TabIndex = 15
        '
        'pnlNewGame
        '
        Me.pnlNewGame.Controls.Add(Me.wbCompendium)
        Me.pnlNewGame.Controls.Add(Me.cboDate)
        Me.pnlNewGame.Controls.Add(Me.lblPackSelect)
        Me.pnlNewGame.Controls.Add(Me.numSeason)
        Me.pnlNewGame.Controls.Add(Me.lblNumOfPlayers)
        Me.pnlNewGame.Controls.Add(Me.btnStartGame)
        Me.pnlNewGame.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlNewGame.Location = New System.Drawing.Point(0, 0)
        Me.pnlNewGame.Name = "pnlNewGame"
        Me.pnlNewGame.Size = New System.Drawing.Size(746, 754)
        Me.pnlNewGame.TabIndex = 16
        '
        'wbCompendium
        '
        Me.wbCompendium.Location = New System.Drawing.Point(250, 481)
        Me.wbCompendium.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbCompendium.Name = "wbCompendium"
        Me.wbCompendium.ScriptErrorsSuppressed = True
        Me.wbCompendium.Size = New System.Drawing.Size(250, 192)
        Me.wbCompendium.TabIndex = 17
        Me.wbCompendium.Visible = False
        '
        'cboDate
        '
        Me.cboDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDate.Font = New System.Drawing.Font("Gotham Bold", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDate.FormattingEnabled = True
        Me.cboDate.Location = New System.Drawing.Point(178, 326)
        Me.cboDate.Name = "cboDate"
        Me.cboDate.Size = New System.Drawing.Size(402, 42)
        Me.cboDate.TabIndex = 16
        '
        'lblPackSelect
        '
        Me.lblPackSelect.AutoSize = True
        Me.lblPackSelect.Font = New System.Drawing.Font("Gotham Bold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPackSelect.ForeColor = System.Drawing.Color.White
        Me.lblPackSelect.Location = New System.Drawing.Point(318, 284)
        Me.lblPackSelect.Name = "lblPackSelect"
        Me.lblPackSelect.Size = New System.Drawing.Size(82, 28)
        Me.lblPackSelect.TabIndex = 15
        Me.lblPackSelect.Text = "DATE"
        '
        'numSeason
        '
        Me.numSeason.Font = New System.Drawing.Font("Gotham Bold", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numSeason.Location = New System.Drawing.Point(408, 225)
        Me.numSeason.Maximum = New Decimal(New Integer() {33, 0, 0, 0})
        Me.numSeason.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numSeason.Name = "numSeason"
        Me.numSeason.Size = New System.Drawing.Size(68, 37)
        Me.numSeason.TabIndex = 10
        Me.numSeason.Value = New Decimal(New Integer() {33, 0, 0, 0})
        '
        'lblNumOfPlayers
        '
        Me.lblNumOfPlayers.AutoSize = True
        Me.lblNumOfPlayers.Font = New System.Drawing.Font("Gotham Bold", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumOfPlayers.ForeColor = System.Drawing.Color.White
        Me.lblNumOfPlayers.Location = New System.Drawing.Point(257, 228)
        Me.lblNumOfPlayers.Name = "lblNumOfPlayers"
        Me.lblNumOfPlayers.Size = New System.Drawing.Size(146, 32)
        Me.lblNumOfPlayers.TabIndex = 9
        Me.lblNumOfPlayers.Text = "SEASON:"
        '
        'btnStartGame
        '
        Me.btnStartGame.BackColor = System.Drawing.Color.White
        Me.btnStartGame.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnStartGame.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnStartGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStartGame.Font = New System.Drawing.Font("Gotham Bold", 13.0!)
        Me.btnStartGame.Location = New System.Drawing.Point(221, 404)
        Me.btnStartGame.Name = "btnStartGame"
        Me.btnStartGame.Size = New System.Drawing.Size(302, 41)
        Me.btnStartGame.TabIndex = 7
        Me.btnStartGame.Text = "LOAD PUZZLES"
        Me.btnStartGame.UseVisualStyleBackColor = False
        '
        'lstPuzzle
        '
        Me.lstPuzzle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstPuzzle.FormattingEnabled = True
        Me.lstPuzzle.ItemHeight = 16
        Me.lstPuzzle.Location = New System.Drawing.Point(0, 0)
        Me.lstPuzzle.Name = "lstPuzzle"
        Me.lstPuzzle.Size = New System.Drawing.Size(715, 754)
        Me.lstPuzzle.TabIndex = 1
        Me.lstPuzzle.Visible = False
        '
        'pboxSet
        '
        Me.pboxSet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pboxSet.Image = Global.WheelOfFortune.My.Resources.Resources.WheelBoardRetro
        Me.pboxSet.Location = New System.Drawing.Point(0, 0)
        Me.pboxSet.Name = "pboxSet"
        Me.pboxSet.Size = New System.Drawing.Size(715, 754)
        Me.pboxSet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pboxSet.TabIndex = 0
        Me.pboxSet.TabStop = False
        '
        'lblSettings
        '
        Me.lblSettings.AutoSize = True
        Me.lblSettings.Font = New System.Drawing.Font("Gotham Bold", 16.0!)
        Me.lblSettings.ForeColor = System.Drawing.Color.White
        Me.lblSettings.Location = New System.Drawing.Point(21, 27)
        Me.lblSettings.Name = "lblSettings"
        Me.lblSettings.Size = New System.Drawing.Size(282, 31)
        Me.lblSettings.TabIndex = 6
        Me.lblSettings.Text = "FLASHBACK MODE"
        '
        'frmCompendium
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
        Me.Name = "frmCompendium"
        Me.Text = "Wheel of Fortune"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlSettings.ResumeLayout(False)
        Me.pnlSettings.PerformLayout()
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splNewGame.Panel1.ResumeLayout(False)
        Me.splNewGame.Panel2.ResumeLayout(False)
        CType(Me.splNewGame, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splNewGame.ResumeLayout(False)
        Me.pnlNewGame.ResumeLayout(False)
        Me.pnlNewGame.PerformLayout()
        CType(Me.numSeason, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pboxSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlSettings As Panel
    Friend WithEvents lblSettings As Label
    Friend WithEvents btnStartGame As Button
    Friend WithEvents numSeason As NumericUpDown
    Friend WithEvents lblNumOfPlayers As Label
    Friend WithEvents splNewGame As SplitContainer
    Friend WithEvents pnlNewGame As Panel
    Friend WithEvents pboxSet As PictureBox
    Friend WithEvents cboDate As ComboBox
    Friend WithEvents lblPackSelect As Label
    Friend WithEvents btnClose As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents wbCompendium As WebBrowser
    Friend WithEvents lstPuzzle As ListBox
End Class
