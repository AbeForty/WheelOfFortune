<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CategoryStrip
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
        Me.pnlCategory = New System.Windows.Forms.Panel()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.bkgCategory = New System.Windows.Forms.PictureBox()
        Me.wheelLogoMini = New System.Windows.Forms.PictureBox()
        Me.pnlCategory.SuspendLayout()
        CType(Me.bkgCategory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.wheelLogoMini, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlCategory
        '
        Me.pnlCategory.BackColor = System.Drawing.Color.Transparent
        Me.pnlCategory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlCategory.Controls.Add(Me.lblCategory)
        Me.pnlCategory.Controls.Add(Me.bkgCategory)
        Me.pnlCategory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCategory.Location = New System.Drawing.Point(0, 0)
        Me.pnlCategory.Name = "pnlCategory"
        Me.pnlCategory.Size = New System.Drawing.Size(907, 45)
        Me.pnlCategory.TabIndex = 1
        '
        'lblCategory
        '
        Me.lblCategory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCategory.Font = New System.Drawing.Font("Gotham Bold", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategory.ForeColor = System.Drawing.Color.White
        Me.lblCategory.Location = New System.Drawing.Point(0, 0)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(907, 45)
        Me.lblCategory.TabIndex = 0
        Me.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblCategory.UseMnemonic = False
        '
        'bkgCategory
        '
        Me.bkgCategory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bkgCategory.Image = Global.WheelOfFortune.My.Resources.Resources.CategoryBarRemastered
        Me.bkgCategory.Location = New System.Drawing.Point(0, 0)
        Me.bkgCategory.Name = "bkgCategory"
        Me.bkgCategory.Size = New System.Drawing.Size(907, 45)
        Me.bkgCategory.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.bkgCategory.TabIndex = 1
        Me.bkgCategory.TabStop = False
        '
        'wheelLogoMini
        '
        Me.wheelLogoMini.BackColor = System.Drawing.Color.Transparent
        Me.wheelLogoMini.Image = Global.WheelOfFortune.My.Resources.Resources.WheelLogoMini
        Me.wheelLogoMini.Location = New System.Drawing.Point(18, 9)
        Me.wheelLogoMini.Name = "wheelLogoMini"
        Me.wheelLogoMini.Size = New System.Drawing.Size(78, 28)
        Me.wheelLogoMini.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.wheelLogoMini.TabIndex = 212
        Me.wheelLogoMini.TabStop = False
        '
        'CategoryStrip
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.wheelLogoMini)
        Me.Controls.Add(Me.pnlCategory)
        Me.Name = "CategoryStrip"
        Me.Size = New System.Drawing.Size(907, 45)
        Me.pnlCategory.ResumeLayout(False)
        CType(Me.bkgCategory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.wheelLogoMini, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlCategory As Panel
    Friend WithEvents lblCategory As Label
    Friend WithEvents bkgCategory As PictureBox
    Friend WithEvents wheelLogoMini As PictureBox
End Class
