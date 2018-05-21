<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class puzzleDisplay
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.lblPuzzle = New System.Windows.Forms.Label()
        Me.lblRound = New System.Windows.Forms.Label()
        Me.pboxEdit = New System.Windows.Forms.PictureBox()
        CType(Me.pboxEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblCategory
        '
        Me.lblCategory.AutoEllipsis = True
        Me.lblCategory.Font = New System.Drawing.Font("Gotham Bold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategory.Location = New System.Drawing.Point(16, 17)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(441, 28)
        Me.lblCategory.TabIndex = 0
        Me.lblCategory.Text = "CATEGORY"
        Me.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblCategory.UseMnemonic = False
        '
        'lblPuzzle
        '
        Me.lblPuzzle.AutoEllipsis = True
        Me.lblPuzzle.Font = New System.Drawing.Font("Helvetica-Condensed-Black-Se", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPuzzle.Location = New System.Drawing.Point(21, 54)
        Me.lblPuzzle.Name = "lblPuzzle"
        Me.lblPuzzle.Size = New System.Drawing.Size(436, 29)
        Me.lblPuzzle.TabIndex = 1
        Me.lblPuzzle.Text = "PUZZLE"
        Me.lblPuzzle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPuzzle.UseMnemonic = False
        '
        'lblRound
        '
        Me.lblRound.AutoSize = True
        Me.lblRound.Font = New System.Drawing.Font("Gotham Bold", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRound.Location = New System.Drawing.Point(20, 83)
        Me.lblRound.Name = "lblRound"
        Me.lblRound.Size = New System.Drawing.Size(84, 22)
        Me.lblRound.TabIndex = 3
        Me.lblRound.Text = "ROUND"
        Me.lblRound.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblRound.UseMnemonic = False
        '
        'pboxEdit
        '
        Me.pboxEdit.Image = Global.WheelOfFortune.My.Resources.Resources.editOptions
        Me.pboxEdit.Location = New System.Drawing.Point(28, 109)
        Me.pboxEdit.Name = "pboxEdit"
        Me.pboxEdit.Size = New System.Drawing.Size(34, 40)
        Me.pboxEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pboxEdit.TabIndex = 4
        Me.pboxEdit.TabStop = False
        '
        'puzzleDisplay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.Controls.Add(Me.pboxEdit)
        Me.Controls.Add(Me.lblRound)
        Me.Controls.Add(Me.lblPuzzle)
        Me.Controls.Add(Me.lblCategory)
        Me.ForeColor = System.Drawing.Color.White
        Me.Name = "puzzleDisplay"
        Me.Size = New System.Drawing.Size(468, 161)
        CType(Me.pboxEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblCategory As Label
    Friend WithEvents lblPuzzle As Label
    Friend WithEvents lblRound As Label
    Friend WithEvents pboxEdit As PictureBox
End Class
