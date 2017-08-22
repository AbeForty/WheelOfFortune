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
        Me.SuspendLayout()
        '
        'btnLetter
        '
        Me.btnLetter.BackColor = System.Drawing.Color.White
        Me.btnLetter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnLetter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLetter.Font = New System.Drawing.Font("Helvetica-Condensed-Black-Se", 25.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLetter.Location = New System.Drawing.Point(0, 0)
        Me.btnLetter.Name = "btnLetter"
        Me.btnLetter.Size = New System.Drawing.Size(41, 53)
        Me.btnLetter.TabIndex = 1
        Me.btnLetter.UseMnemonic = False
        Me.btnLetter.UseVisualStyleBackColor = False
        '
        'PuzzleBoardLetter
        '
        Me.Controls.Add(Me.btnLetter)
        Me.Name = "PuzzleBoardLetter"
        Me.Size = New System.Drawing.Size(41, 53)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnLetter As Button
End Class
