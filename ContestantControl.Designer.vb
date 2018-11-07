<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ContestantControl
    Inherits System.Windows.Forms.Form
    'UserControl overrides dispose to clean up the component list.
    '<System.Diagnostics.DebuggerNonUserCode()> _
    'Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    '    Try
    '        If disposing AndAlso components IsNot Nothing Then
    '            components.Dispose()
    '        End If
    '    Finally
    '        MyBase.Dispose(disposing)
    '    End Try
    'End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ContestantControl))
        Me.flpContestants = New System.Windows.Forms.FlowLayoutPanel()
        Me.SuspendLayout()
        '
        'flpContestants
        '
        Me.flpContestants.AutoScroll = True
        Me.flpContestants.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.flpContestants.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpContestants.Location = New System.Drawing.Point(0, 0)
        Me.flpContestants.Name = "flpContestants"
        Me.flpContestants.Size = New System.Drawing.Size(413, 407)
        Me.flpContestants.TabIndex = 33
        '
        'ContestantControl
        '
        Me.ClientSize = New System.Drawing.Size(413, 407)
        Me.Controls.Add(Me.flpContestants)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ContestantControl"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents flpContestants As FlowLayoutPanel
End Class
