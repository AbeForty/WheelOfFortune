<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAudio
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAudio))
        Me.wheelWMP = New AxWMPLib.AxWindowsMediaPlayer()
        Me.wheelWMP2 = New AxWMPLib.AxWindowsMediaPlayer()
        CType(Me.wheelWMP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.wheelWMP2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'wheelWMP
        '
        Me.wheelWMP.Enabled = True
        Me.wheelWMP.Location = New System.Drawing.Point(84, 115)
        Me.wheelWMP.Name = "wheelWMP"
        Me.wheelWMP.OcxState = CType(resources.GetObject("wheelWMP.OcxState"), System.Windows.Forms.AxHost.State)
        Me.wheelWMP.Size = New System.Drawing.Size(82, 45)
        Me.wheelWMP.TabIndex = 0
        Me.wheelWMP.Visible = False
        '
        'wheelWMP2
        '
        Me.wheelWMP2.Enabled = True
        Me.wheelWMP2.Location = New System.Drawing.Point(84, 166)
        Me.wheelWMP2.Name = "wheelWMP2"
        Me.wheelWMP2.OcxState = CType(resources.GetObject("wheelWMP2.OcxState"), System.Windows.Forms.AxHost.State)
        Me.wheelWMP2.Size = New System.Drawing.Size(82, 45)
        Me.wheelWMP2.TabIndex = 1
        Me.wheelWMP2.Visible = False
        '
        'frmAudio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(282, 253)
        Me.Controls.Add(Me.wheelWMP2)
        Me.Controls.Add(Me.wheelWMP)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAudio"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.TransparencyKey = System.Drawing.SystemColors.Control
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        CType(Me.wheelWMP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.wheelWMP2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents wheelWMP As AxWindowsMediaPlayer
    Friend WithEvents wheelWMP2 As AxWindowsMediaPlayer
End Class
