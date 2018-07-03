<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDailyPuzzleTest
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
        Me.roundHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.categoryHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.puzzleHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstViewPuzzle = New System.Windows.Forms.ListView()
        Me.flpGetPuzzles = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnGetPuzzles = New System.Windows.Forms.Button()
        Me.wbPuzzle = New System.Windows.Forms.WebBrowser()
        Me.pbarPuzzleLoad = New System.Windows.Forms.ProgressBar()
        Me.lblDownloadingPuzzles = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.PreventCloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelloToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.flpGetPuzzles.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'roundHeader
        '
        Me.roundHeader.Text = "Round"
        Me.roundHeader.Width = 119
        '
        'categoryHeader
        '
        Me.categoryHeader.Text = "Category"
        Me.categoryHeader.Width = 116
        '
        'puzzleHeader
        '
        Me.puzzleHeader.Text = "Puzzle"
        Me.puzzleHeader.Width = 567
        '
        'lstViewPuzzle
        '
        Me.lstViewPuzzle.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.roundHeader, Me.categoryHeader, Me.puzzleHeader})
        Me.lstViewPuzzle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lstViewPuzzle.FullRowSelect = True
        Me.lstViewPuzzle.Location = New System.Drawing.Point(0, 0)
        Me.lstViewPuzzle.Name = "lstViewPuzzle"
        Me.lstViewPuzzle.Size = New System.Drawing.Size(415, 555)
        Me.lstViewPuzzle.TabIndex = 0
        Me.lstViewPuzzle.UseCompatibleStateImageBehavior = False
        Me.lstViewPuzzle.View = System.Windows.Forms.View.Details
        Me.lstViewPuzzle.Visible = False
        '
        'flpGetPuzzles
        '
        Me.flpGetPuzzles.Controls.Add(Me.btnGetPuzzles)
        Me.flpGetPuzzles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpGetPuzzles.Location = New System.Drawing.Point(0, 555)
        Me.flpGetPuzzles.Name = "flpGetPuzzles"
        Me.flpGetPuzzles.Size = New System.Drawing.Size(415, 0)
        Me.flpGetPuzzles.TabIndex = 1
        Me.flpGetPuzzles.Visible = False
        '
        'btnGetPuzzles
        '
        Me.btnGetPuzzles.Location = New System.Drawing.Point(3, 3)
        Me.btnGetPuzzles.Name = "btnGetPuzzles"
        Me.btnGetPuzzles.Size = New System.Drawing.Size(818, 32)
        Me.btnGetPuzzles.TabIndex = 0
        Me.btnGetPuzzles.Text = "Get Today's Puzzles"
        Me.btnGetPuzzles.UseVisualStyleBackColor = True
        '
        'wbPuzzle
        '
        Me.wbPuzzle.Location = New System.Drawing.Point(3, 0)
        Me.wbPuzzle.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbPuzzle.Name = "wbPuzzle"
        Me.wbPuzzle.ScriptErrorsSuppressed = True
        Me.wbPuzzle.Size = New System.Drawing.Size(411, 111)
        Me.wbPuzzle.TabIndex = 2
        Me.wbPuzzle.Url = New System.Uri("http://www.wheeloffortunesolutions.com/bonuspuzzle.html", System.UriKind.Absolute)
        '
        'pbarPuzzleLoad
        '
        Me.pbarPuzzleLoad.Location = New System.Drawing.Point(138, 36)
        Me.pbarPuzzleLoad.Name = "pbarPuzzleLoad"
        Me.pbarPuzzleLoad.Size = New System.Drawing.Size(127, 23)
        Me.pbarPuzzleLoad.TabIndex = 3
        '
        'lblDownloadingPuzzles
        '
        Me.lblDownloadingPuzzles.BackColor = System.Drawing.Color.Transparent
        Me.lblDownloadingPuzzles.Font = New System.Drawing.Font("Gotham Bold", 7.8!)
        Me.lblDownloadingPuzzles.Location = New System.Drawing.Point(2, 13)
        Me.lblDownloadingPuzzles.Name = "lblDownloadingPuzzles"
        Me.lblDownloadingPuzzles.Size = New System.Drawing.Size(412, 17)
        Me.lblDownloadingPuzzles.TabIndex = 4
        Me.lblDownloadingPuzzles.Text = "Loading Puzzles..."
        Me.lblDownloadingPuzzles.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PreventCloseToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(415, 28)
        Me.MenuStrip1.TabIndex = 5
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'PreventCloseToolStripMenuItem
        '
        Me.PreventCloseToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelloToolStripMenuItem})
        Me.PreventCloseToolStripMenuItem.Name = "PreventCloseToolStripMenuItem"
        Me.PreventCloseToolStripMenuItem.Size = New System.Drawing.Size(110, 24)
        Me.PreventCloseToolStripMenuItem.Text = "Prevent Close"
        '
        'HelloToolStripMenuItem
        '
        Me.HelloToolStripMenuItem.Name = "HelloToolStripMenuItem"
        Me.HelloToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.HelloToolStripMenuItem.Size = New System.Drawing.Size(173, 26)
        Me.HelloToolStripMenuItem.Text = "Hello"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnCancel)
        Me.Panel1.Controls.Add(Me.pbarPuzzleLoad)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(413, 132)
        Me.Panel1.TabIndex = 6
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(167, 65)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmDailyPuzzleTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(415, 134)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblDownloadingPuzzles)
        Me.Controls.Add(Me.flpGetPuzzles)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.wbPuzzle)
        Me.Controls.Add(Me.lstViewPuzzle)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDailyPuzzleTest"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Loading Puzzles..."
        Me.TopMost = True
        Me.flpGetPuzzles.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents roundHeader As ColumnHeader
    Friend WithEvents categoryHeader As ColumnHeader
    Friend WithEvents puzzleHeader As ColumnHeader
    Friend WithEvents lstViewPuzzle As ListView
    Friend WithEvents flpGetPuzzles As FlowLayoutPanel
    Friend WithEvents btnGetPuzzles As Button
    Friend WithEvents wbPuzzle As WebBrowser
    Friend WithEvents pbarPuzzleLoad As ProgressBar
    Friend WithEvents lblDownloadingPuzzles As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents PreventCloseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelloToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnCancel As Button
End Class
