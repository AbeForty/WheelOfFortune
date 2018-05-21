<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class dlgPuzzleBoard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgPuzzleBoard))
        Me.MiniPuzzleBoard1 = New WheelOfFortune.MiniPuzzleBoard()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.DisableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelloToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MiniPuzzleBoard1
        '
        Me.MiniPuzzleBoard1.BackColor = System.Drawing.Color.Transparent
        Me.MiniPuzzleBoard1.BackgroundImage = CType(resources.GetObject("MiniPuzzleBoard1.BackgroundImage"), System.Drawing.Image)
        Me.MiniPuzzleBoard1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.MiniPuzzleBoard1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MiniPuzzleBoard1.Location = New System.Drawing.Point(0, 0)
        Me.MiniPuzzleBoard1.Name = "MiniPuzzleBoard1"
        Me.MiniPuzzleBoard1.Size = New System.Drawing.Size(462, 183)
        Me.MiniPuzzleBoard1.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DisableToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(437, 28)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'DisableToolStripMenuItem
        '
        Me.DisableToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelloToolStripMenuItem})
        Me.DisableToolStripMenuItem.Name = "DisableToolStripMenuItem"
        Me.DisableToolStripMenuItem.Size = New System.Drawing.Size(71, 24)
        Me.DisableToolStripMenuItem.Text = "Disable"
        '
        'HelloToolStripMenuItem
        '
        Me.HelloToolStripMenuItem.Name = "HelloToolStripMenuItem"
        Me.HelloToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.HelloToolStripMenuItem.Size = New System.Drawing.Size(173, 26)
        Me.HelloToolStripMenuItem.Text = "Hello"
        '
        'dlgPuzzleBoard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(462, 183)
        Me.Controls.Add(Me.MiniPuzzleBoard1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "dlgPuzzleBoard"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Puzzle Board"
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.SystemColors.Control
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MiniPuzzleBoard1 As MiniPuzzleBoard
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents DisableToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelloToolStripMenuItem As ToolStripMenuItem
End Class
