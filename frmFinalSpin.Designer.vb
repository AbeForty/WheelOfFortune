<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFinalSpin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFinalSpin))
        Me.wmpFinalSpin = New AxWMPLib.AxWindowsMediaPlayer()
        CType(Me.wmpFinalSpin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'wmpFinalSpin
        '
        Me.wmpFinalSpin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wmpFinalSpin.Enabled = True
        Me.wmpFinalSpin.Location = New System.Drawing.Point(0, 0)
        Me.wmpFinalSpin.Name = "wmpFinalSpin"
        Me.wmpFinalSpin.OcxState = CType(resources.GetObject("wmpFinalSpin.OcxState"), System.Windows.Forms.AxHost.State)
        Me.wmpFinalSpin.Size = New System.Drawing.Size(1902, 1092)
        Me.wmpFinalSpin.TabIndex = 0
        '
        'frmFinalSpin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1902, 1092)
        Me.Controls.Add(Me.wmpFinalSpin)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmFinalSpin"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Final Spin"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.wmpFinalSpin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents wmpFinalSpin As AxWMPLib.AxWindowsMediaPlayer
End Class
