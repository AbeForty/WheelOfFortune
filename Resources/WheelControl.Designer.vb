<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WheelControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WheelControl))
        Me.wheelImage = New System.Windows.Forms.PictureBox()
        CType(Me.wheelImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'wheelImage
        '
        Me.wheelImage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wheelImage.Location = New System.Drawing.Point(0, 0)
        Me.wheelImage.Name = "wheelImage"
        Me.wheelImage.Size = New System.Drawing.Size(1902, 1092)
        Me.wheelImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.wheelImage.TabIndex = 0
        Me.wheelImage.TabStop = False
        '
        'WheelControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.wheelImage)
        Me.Name = "WheelControl"
        Me.Size = New System.Drawing.Size(1902, 1092)
        CType(Me.wheelImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents wheelImage As PictureBox
End Class
