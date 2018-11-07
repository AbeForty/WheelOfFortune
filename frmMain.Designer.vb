<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.btnPlay = New System.Windows.Forms.Button()
        Me.btnSettings = New System.Windows.Forms.Button()
        Me.pboxLogo = New System.Windows.Forms.PictureBox()
        Me.wheelIcon = New System.Windows.Forms.Panel()
        Me.btnCustomize = New System.Windows.Forms.Button()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pboxWheelAnim = New System.Windows.Forms.PictureBox()
        CType(Me.pboxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pboxWheelAnim, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnPlay
        '
        Me.btnPlay.BackColor = System.Drawing.Color.White
        Me.btnPlay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnPlay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPlay.Font = New System.Drawing.Font("Gotham Bold", 15.0!, System.Drawing.FontStyle.Bold)
        Me.btnPlay.ForeColor = System.Drawing.Color.Black
        Me.btnPlay.Location = New System.Drawing.Point(1626, 337)
        Me.btnPlay.Name = "btnPlay"
        Me.btnPlay.Size = New System.Drawing.Size(249, 83)
        Me.btnPlay.TabIndex = 2
        Me.btnPlay.Text = "PLAY"
        Me.btnPlay.UseVisualStyleBackColor = False
        '
        'btnSettings
        '
        Me.btnSettings.BackColor = System.Drawing.Color.White
        Me.btnSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSettings.Font = New System.Drawing.Font("Gotham Bold", 15.0!, System.Drawing.FontStyle.Bold)
        Me.btnSettings.ForeColor = System.Drawing.Color.Black
        Me.btnSettings.Location = New System.Drawing.Point(1626, 528)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(249, 83)
        Me.btnSettings.TabIndex = 3
        Me.btnSettings.Text = "CONTESTANTS"
        Me.btnSettings.UseVisualStyleBackColor = False
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
        Me.pboxLogo.Visible = False
        '
        'wheelIcon
        '
        Me.wheelIcon.BackColor = System.Drawing.Color.Transparent
        Me.wheelIcon.BackgroundImage = Global.WheelOfFortune.My.Resources.Resources.Wheel
        Me.wheelIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.wheelIcon.Location = New System.Drawing.Point(722, 390)
        Me.wheelIcon.Name = "wheelIcon"
        Me.wheelIcon.Size = New System.Drawing.Size(258, 252)
        Me.wheelIcon.TabIndex = 5
        Me.wheelIcon.Visible = False
        '
        'btnCustomize
        '
        Me.btnCustomize.BackColor = System.Drawing.Color.White
        Me.btnCustomize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnCustomize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnCustomize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCustomize.Font = New System.Drawing.Font("Gotham Bold", 15.0!, System.Drawing.FontStyle.Bold)
        Me.btnCustomize.ForeColor = System.Drawing.Color.Black
        Me.btnCustomize.Location = New System.Drawing.Point(1626, 433)
        Me.btnCustomize.Name = "btnCustomize"
        Me.btnCustomize.Size = New System.Drawing.Size(249, 83)
        Me.btnCustomize.TabIndex = 6
        Me.btnCustomize.Text = "CUSTOMIZE"
        Me.btnCustomize.UseVisualStyleBackColor = False
        '
        'btnHelp
        '
        Me.btnHelp.BackColor = System.Drawing.Color.White
        Me.btnHelp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnHelp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHelp.Font = New System.Drawing.Font("Gotham Bold", 15.0!, System.Drawing.FontStyle.Bold)
        Me.btnHelp.ForeColor = System.Drawing.Color.Black
        Me.btnHelp.Location = New System.Drawing.Point(1626, 624)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(249, 83)
        Me.btnHelp.TabIndex = 7
        Me.btnHelp.Text = "HELP"
        Me.btnHelp.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Location = New System.Drawing.Point(811, 303)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(346, 417)
        Me.Panel1.TabIndex = 8
        Me.Panel1.Visible = False
        '
        'pboxWheelAnim
        '
        Me.pboxWheelAnim.BackColor = System.Drawing.Color.Transparent
        Me.pboxWheelAnim.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pboxWheelAnim.Image = Global.WheelOfFortune.My.Resources.Resources.WheelSeason35LogoAnim
        Me.pboxWheelAnim.Location = New System.Drawing.Point(0, 0)
        Me.pboxWheelAnim.Name = "pboxWheelAnim"
        Me.pboxWheelAnim.Size = New System.Drawing.Size(1932, 1092)
        Me.pboxWheelAnim.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pboxWheelAnim.TabIndex = 9
        Me.pboxWheelAnim.TabStop = False
        Me.pboxWheelAnim.Visible = False
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BackgroundImage = Global.WheelOfFortune.My.Resources.Resources.WheelSeason35BKG
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1932, 1092)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnCustomize)
        Me.Controls.Add(Me.pboxLogo)
        Me.Controls.Add(Me.btnSettings)
        Me.Controls.Add(Me.wheelIcon)
        Me.Controls.Add(Me.btnPlay)
        Me.Controls.Add(Me.pboxWheelAnim)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.Text = "Wheel of Fortune"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.pboxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pboxWheelAnim, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnPlay As Button
    Friend WithEvents btnSettings As Button
    Friend WithEvents pboxLogo As PictureBox
    Friend WithEvents wheelIcon As Panel
    Friend WithEvents btnCustomize As Button
    Friend WithEvents btnHelp As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents pboxWheelAnim As PictureBox
End Class
