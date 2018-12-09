<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TeamDisplay
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
        Me.lblNoContestants = New System.Windows.Forms.Label()
        Me.flpContestants = New System.Windows.Forms.FlowLayoutPanel()
        Me.flpActions = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblAddToTeam = New System.Windows.Forms.Label()
        Me.chkDemo = New System.Windows.Forms.CheckBox()
        Me.flpActions.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblNoContestants
        '
        Me.lblNoContestants.BackColor = System.Drawing.Color.Transparent
        Me.lblNoContestants.Font = New System.Drawing.Font("Gotham Bold", 15.0!)
        Me.lblNoContestants.ForeColor = System.Drawing.Color.White
        Me.lblNoContestants.Location = New System.Drawing.Point(63, 133)
        Me.lblNoContestants.Name = "lblNoContestants"
        Me.lblNoContestants.Size = New System.Drawing.Size(312, 163)
        Me.lblNoContestants.TabIndex = 38
        Me.lblNoContestants.Text = "NO CONTESTANTS HAVE BEEN ADDED TO THIS TEAM YET. CLICK ADD TO TEAM ABOVE TO ADD O" &
    "NE."
        Me.lblNoContestants.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'flpContestants
        '
        Me.flpContestants.AutoScroll = True
        Me.flpContestants.BackColor = System.Drawing.Color.Transparent
        Me.flpContestants.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpContestants.Location = New System.Drawing.Point(0, 34)
        Me.flpContestants.Name = "flpContestants"
        Me.flpContestants.Size = New System.Drawing.Size(444, 373)
        Me.flpContestants.TabIndex = 36
        '
        'flpActions
        '
        Me.flpActions.BackColor = System.Drawing.Color.Transparent
        Me.flpActions.Controls.Add(Me.lblAddToTeam)
        Me.flpActions.Controls.Add(Me.chkDemo)
        Me.flpActions.Dock = System.Windows.Forms.DockStyle.Top
        Me.flpActions.Location = New System.Drawing.Point(0, 0)
        Me.flpActions.Name = "flpActions"
        Me.flpActions.Size = New System.Drawing.Size(444, 34)
        Me.flpActions.TabIndex = 39
        '
        'lblAddToTeam
        '
        Me.lblAddToTeam.BackColor = System.Drawing.Color.Transparent
        Me.lblAddToTeam.Font = New System.Drawing.Font("Gotham Bold", 12.0!)
        Me.lblAddToTeam.ForeColor = System.Drawing.Color.White
        Me.lblAddToTeam.Location = New System.Drawing.Point(3, 0)
        Me.lblAddToTeam.Name = "lblAddToTeam"
        Me.lblAddToTeam.Size = New System.Drawing.Size(195, 34)
        Me.lblAddToTeam.TabIndex = 39
        Me.lblAddToTeam.Text = "+ ADD TO TEAM"
        Me.lblAddToTeam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDemo
        '
        Me.chkDemo.AutoSize = True
        Me.chkDemo.Font = New System.Drawing.Font("Gotham Bold", 12.0!)
        Me.chkDemo.ForeColor = System.Drawing.Color.White
        Me.chkDemo.Location = New System.Drawing.Point(204, 3)
        Me.chkDemo.Name = "chkDemo"
        Me.chkDemo.Size = New System.Drawing.Size(95, 27)
        Me.chkDemo.TabIndex = 40
        Me.chkDemo.Text = "DEMO"
        Me.chkDemo.UseVisualStyleBackColor = True
        Me.chkDemo.Visible = False
        '
        'TeamDisplay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(121, Byte), Integer))
        Me.Controls.Add(Me.lblNoContestants)
        Me.Controls.Add(Me.flpContestants)
        Me.Controls.Add(Me.flpActions)
        Me.DoubleBuffered = True
        Me.Name = "TeamDisplay"
        Me.Size = New System.Drawing.Size(444, 407)
        Me.flpActions.ResumeLayout(False)
        Me.flpActions.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblNoContestants As Label
    Friend WithEvents flpContestants As FlowLayoutPanel
    Friend WithEvents flpActions As FlowLayoutPanel
    Friend WithEvents lblAddToTeam As Label
    Friend WithEvents chkDemo As CheckBox
End Class
