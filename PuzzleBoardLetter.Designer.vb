<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PuzzleBoardLetter
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.btnLetter = New System.Windows.Forms.Button()
        Me.retroLetter = New System.Windows.Forms.PictureBox()
        CType(Me.retroLetter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnLetter
        '
        Me.btnLetter.BackColor = System.Drawing.Color.White
        Me.btnLetter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnLetter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnLetter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLetter.Font = New System.Drawing.Font("Helvetica-Condensed-Black-Se", 25.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLetter.Location = New System.Drawing.Point(0, 0)
        Me.btnLetter.Name = "btnLetter"
        Me.btnLetter.Size = New System.Drawing.Size(53, 73)
        Me.btnLetter.TabIndex = 1
        Me.btnLetter.UseMnemonic = False
        Me.btnLetter.UseVisualStyleBackColor = False
        '
        'retroLetter
        '
        Me.retroLetter.BackColor = System.Drawing.Color.White
        Me.retroLetter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.retroLetter.Location = New System.Drawing.Point(0, 0)
        Me.retroLetter.Name = "retroLetter"
        Me.retroLetter.Size = New System.Drawing.Size(53, 73)
        Me.retroLetter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.retroLetter.TabIndex = 2
        Me.retroLetter.TabStop = False
        '
        'PuzzleBoardLetter
        '
        Me.BackColor = System.Drawing.Color.Transparent
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.retroLetter)
        Me.Controls.Add(Me.btnLetter)
        Me.Name = "PuzzleBoardLetter"
        Me.Size = New System.Drawing.Size(53, 73)
        CType(Me.retroLetter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnLetter As Button
    Friend WithEvents retroLetter As PictureBox
End Class
