<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class dlgPauseMenu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgPauseMenu))
        Me.pnlInstructions = New System.Windows.Forms.Panel()
        Me.btnSettings = New System.Windows.Forms.Button()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.btnMain = New System.Windows.Forms.Button()
        Me.btnResume = New System.Windows.Forms.Button()
        Me.pboxLogo = New System.Windows.Forms.PictureBox()
        Me.lblInstructions = New System.Windows.Forms.Label()
        Me.pnlInstructions.SuspendLayout()
        CType(Me.pboxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlInstructions
        '
        Me.pnlInstructions.BackColor = System.Drawing.Color.SeaGreen
        Me.pnlInstructions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlInstructions.Controls.Add(Me.btnSettings)
        Me.pnlInstructions.Controls.Add(Me.btnHelp)
        Me.pnlInstructions.Controls.Add(Me.btnMain)
        Me.pnlInstructions.Controls.Add(Me.btnResume)
        Me.pnlInstructions.Controls.Add(Me.pboxLogo)
        Me.pnlInstructions.Controls.Add(Me.lblInstructions)
        Me.pnlInstructions.Location = New System.Drawing.Point(413, 198)
        Me.pnlInstructions.Name = "pnlInstructions"
        Me.pnlInstructions.Size = New System.Drawing.Size(1107, 696)
        Me.pnlInstructions.TabIndex = 1
        '
        'btnSettings
        '
        Me.btnSettings.BackColor = System.Drawing.Color.White
        Me.btnSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSettings.Font = New System.Drawing.Font("Gotham Bold", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSettings.Location = New System.Drawing.Point(445, 377)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(215, 49)
        Me.btnSettings.TabIndex = 27
        Me.btnSettings.TabStop = False
        Me.btnSettings.Text = "SETTINGS "
        Me.btnSettings.UseVisualStyleBackColor = False
        '
        'btnHelp
        '
        Me.btnHelp.BackColor = System.Drawing.Color.White
        Me.btnHelp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnHelp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHelp.Font = New System.Drawing.Font("Gotham Bold", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHelp.Location = New System.Drawing.Point(445, 447)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(215, 49)
        Me.btnHelp.TabIndex = 26
        Me.btnHelp.TabStop = False
        Me.btnHelp.Text = "HELP"
        Me.btnHelp.UseVisualStyleBackColor = False
        '
        'btnMain
        '
        Me.btnMain.BackColor = System.Drawing.Color.White
        Me.btnMain.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnMain.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMain.Font = New System.Drawing.Font("Gotham Bold", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMain.Location = New System.Drawing.Point(445, 518)
        Me.btnMain.Name = "btnMain"
        Me.btnMain.Size = New System.Drawing.Size(215, 49)
        Me.btnMain.TabIndex = 25
        Me.btnMain.TabStop = False
        Me.btnMain.Text = "MAIN MENU"
        Me.btnMain.UseVisualStyleBackColor = False
        '
        'btnResume
        '
        Me.btnResume.BackColor = System.Drawing.Color.White
        Me.btnResume.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnResume.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnResume.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnResume.Font = New System.Drawing.Font("Gotham Bold", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResume.Location = New System.Drawing.Point(445, 308)
        Me.btnResume.Name = "btnResume"
        Me.btnResume.Size = New System.Drawing.Size(215, 49)
        Me.btnResume.TabIndex = 24
        Me.btnResume.TabStop = False
        Me.btnResume.Text = "RESUME"
        Me.btnResume.UseVisualStyleBackColor = False
        '
        'pboxLogo
        '
        Me.pboxLogo.BackColor = System.Drawing.Color.Transparent
        Me.pboxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pboxLogo.Image = Global.WheelOfFortune.My.Resources.Resources.WheelLogo
        Me.pboxLogo.Location = New System.Drawing.Point(307, 32)
        Me.pboxLogo.Name = "pboxLogo"
        Me.pboxLogo.Size = New System.Drawing.Size(492, 187)
        Me.pboxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pboxLogo.TabIndex = 23
        Me.pboxLogo.TabStop = False
        '
        'lblInstructions
        '
        Me.lblInstructions.AutoSize = True
        Me.lblInstructions.Font = New System.Drawing.Font("Open Sans", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInstructions.ForeColor = System.Drawing.Color.White
        Me.lblInstructions.Location = New System.Drawing.Point(478, 239)
        Me.lblInstructions.Name = "lblInstructions"
        Me.lblInstructions.Size = New System.Drawing.Size(149, 45)
        Me.lblInstructions.TabIndex = 1
        Me.lblInstructions.Text = "PAUSED"
        '
        'dlgPauseMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDark
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1932, 1092)
        Me.Controls.Add(Me.pnlInstructions)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "dlgPauseMenu"
        Me.ShowInTaskbar = False
        Me.Text = "Paused"
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.SystemColors.ControlDark
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlInstructions.ResumeLayout(False)
        Me.pnlInstructions.PerformLayout()
        CType(Me.pboxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlInstructions As Panel
    Friend WithEvents lblInstructions As Label
    Friend WithEvents btnHelp As Button
    Friend WithEvents btnMain As Button
    Friend WithEvents btnResume As Button
    Friend WithEvents pboxLogo As PictureBox
    Friend WithEvents btnSettings As Button
End Class
