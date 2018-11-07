<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCrosswordCustomizer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCrosswordCustomizer))
        Me.toolTipCrosswordClue = New System.Windows.Forms.ToolTip(Me.components)
        Me.toolTipPuzzle = New System.Windows.Forms.ToolTip(Me.components)
        Me.CrosswordPuzzleBoard1 = New WheelOfFortune.CrosswordPuzzleBoard()
        Me.btnPreview = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'toolTipCrosswordClue
        '
        Me.toolTipCrosswordClue.ToolTipTitle = "Crossword Clue"
        '
        'toolTipPuzzle
        '
        Me.toolTipPuzzle.ToolTipTitle = "Puzzle"
        '
        'CrosswordPuzzleBoard1
        '
        Me.CrosswordPuzzleBoard1.BackColor = System.Drawing.Color.Transparent
        Me.CrosswordPuzzleBoard1.BackgroundImage = CType(resources.GetObject("CrosswordPuzzleBoard1.BackgroundImage"), System.Drawing.Image)
        Me.CrosswordPuzzleBoard1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CrosswordPuzzleBoard1.Location = New System.Drawing.Point(581, 251)
        Me.CrosswordPuzzleBoard1.Name = "CrosswordPuzzleBoard1"
        Me.CrosswordPuzzleBoard1.Size = New System.Drawing.Size(877, 333)
        Me.CrosswordPuzzleBoard1.TabIndex = 0
        '
        'btnPreview
        '
        Me.btnPreview.Font = New System.Drawing.Font("Gotham Bold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPreview.Location = New System.Drawing.Point(538, 687)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(998, 100)
        Me.btnPreview.TabIndex = 193
        Me.btnPreview.Text = "CLICK ANY TRILLON TO DEFINE ITS LETTER." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "CLICK HERE TO CLOSE THE CROSSWORD CUSTOM" &
    "IZER."
        Me.btnPreview.UseVisualStyleBackColor = True
        '
        'frmCrosswordCustomizer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.WheelOfFortune.My.Resources.Resources.WheelBoard
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1942, 1102)
        Me.Controls.Add(Me.btnPreview)
        Me.Controls.Add(Me.CrosswordPuzzleBoard1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCrosswordCustomizer"
        Me.Text = "Customizer"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents toolTipCrosswordClue As ToolTip
    Friend WithEvents toolTipPuzzle As ToolTip
    Friend WithEvents CrosswordPuzzleBoard1 As CrosswordPuzzleBoard
    Friend WithEvents btnPreview As Button
End Class
