<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StatsControl
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblWinnings = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.lblPackName = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblWinnings)
        Me.Panel2.Controls.Add(Me.lblDate)
        Me.Panel2.Controls.Add(Me.lblPackName)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1001, 41)
        Me.Panel2.TabIndex = 24
        '
        'lblWinnings
        '
        Me.lblWinnings.AutoSize = True
        Me.lblWinnings.Font = New System.Drawing.Font("Gotham Bold", 13.0!)
        Me.lblWinnings.ForeColor = System.Drawing.Color.White
        Me.lblWinnings.Location = New System.Drawing.Point(735, 6)
        Me.lblWinnings.Name = "lblWinnings"
        Me.lblWinnings.Size = New System.Drawing.Size(133, 25)
        Me.lblWinnings.TabIndex = 20
        Me.lblWinnings.Text = "WINNINGS"
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Gotham Bold", 13.0!)
        Me.lblDate.ForeColor = System.Drawing.Color.White
        Me.lblDate.Location = New System.Drawing.Point(442, 6)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(75, 25)
        Me.lblDate.TabIndex = 19
        Me.lblDate.Text = "DATE"
        '
        'lblPackName
        '
        Me.lblPackName.AutoSize = True
        Me.lblPackName.Font = New System.Drawing.Font("Gotham Bold", 13.0!)
        Me.lblPackName.ForeColor = System.Drawing.Color.White
        Me.lblPackName.Location = New System.Drawing.Point(3, 6)
        Me.lblPackName.Name = "lblPackName"
        Me.lblPackName.Size = New System.Drawing.Size(151, 25)
        Me.lblPackName.TabIndex = 18
        Me.lblPackName.Text = "PACK NAME"
        '
        'StatsControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.Panel2)
        Me.Name = "StatsControl"
        Me.Size = New System.Drawing.Size(1001, 41)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblWinnings As Label
    Friend WithEvents lblDate As Label
    Friend WithEvents lblPackName As Label
End Class
