<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MysteryDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MysteryDialog))
        Me.mysteryPanel = New System.Windows.Forms.Panel()
        Me.btnNo = New System.Windows.Forms.Button()
        Me.btnYes = New System.Windows.Forms.Button()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.mystery = New System.Windows.Forms.PictureBox()
        Me.mysteryPanel.SuspendLayout()
        CType(Me.mystery, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mysteryPanel
        '
        Me.mysteryPanel.BackColor = System.Drawing.Color.Transparent
        Me.mysteryPanel.Controls.Add(Me.btnNo)
        Me.mysteryPanel.Controls.Add(Me.btnYes)
        Me.mysteryPanel.Controls.Add(Me.lblMessage)
        Me.mysteryPanel.Controls.Add(Me.mystery)
        Me.mysteryPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mysteryPanel.Location = New System.Drawing.Point(0, 0)
        Me.mysteryPanel.Name = "mysteryPanel"
        Me.mysteryPanel.Size = New System.Drawing.Size(397, 359)
        Me.mysteryPanel.TabIndex = 121
        '
        'btnNo
        '
        Me.btnNo.BackColor = System.Drawing.Color.White
        Me.btnNo.Font = New System.Drawing.Font("Gotham Bold", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNo.Location = New System.Drawing.Point(253, 259)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.Size = New System.Drawing.Size(90, 37)
        Me.btnNo.TabIndex = 123
        Me.btnNo.Text = "No"
        Me.btnNo.UseVisualStyleBackColor = False
        '
        'btnYes
        '
        Me.btnYes.BackColor = System.Drawing.Color.White
        Me.btnYes.Font = New System.Drawing.Font("Gotham Bold", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnYes.Location = New System.Drawing.Point(147, 259)
        Me.btnYes.Name = "btnYes"
        Me.btnYes.Size = New System.Drawing.Size(90, 37)
        Me.btnYes.TabIndex = 121
        Me.btnYes.Text = "Yes"
        Me.btnYes.UseVisualStyleBackColor = False
        '
        'lblMessage
        '
        Me.lblMessage.Font = New System.Drawing.Font("Gotham Bold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.White
        Me.lblMessage.Location = New System.Drawing.Point(106, 69)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(268, 189)
        Me.lblMessage.TabIndex = 122
        Me.lblMessage.Text = "You've landed on the Mystery Wedge. The back either contains a bankrupt or a $10," &
    "000 prize. Do you want to reveal the mystery?"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'mystery
        '
        Me.mystery.BackColor = System.Drawing.Color.Transparent
        Me.mystery.Image = Global.WheelOfFortune.My.Resources.Resources.Mystery_2014
        Me.mystery.Location = New System.Drawing.Point(12, 60)
        Me.mystery.Name = "mystery"
        Me.mystery.Size = New System.Drawing.Size(100, 214)
        Me.mystery.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.mystery.TabIndex = 121
        Me.mystery.TabStop = False
        '
        'MysteryDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.WheelOfFortune.My.Resources.Resources.WheelSonyTVCity
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(397, 359)
        Me.Controls.Add(Me.mysteryPanel)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MysteryDialog"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mystery"
        Me.TopMost = True
        Me.mysteryPanel.ResumeLayout(False)
        CType(Me.mystery, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents mysteryPanel As Panel
    Friend WithEvents btnNo As Button
    Friend WithEvents btnYes As Button
    Friend WithEvents lblMessage As Label
    Friend WithEvents mystery As PictureBox
End Class
