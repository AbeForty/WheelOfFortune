<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ContestantDisplay
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ContestantDisplay))
        Me.NameTag1 = New WheelOfFortune.NameTag()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.txtPlayer = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.PictureBox()
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NameTag1
        '
        Me.NameTag1.BackColor = System.Drawing.Color.Transparent
        Me.NameTag1.BackgroundImage = CType(resources.GetObject("NameTag1.BackgroundImage"), System.Drawing.Image)
        Me.NameTag1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.NameTag1.contestantID = 0
        Me.NameTag1.contestantName = "NAME"
        Me.NameTag1.Location = New System.Drawing.Point(13, 21)
        Me.NameTag1.Name = "NameTag1"
        Me.NameTag1.Size = New System.Drawing.Size(150, 48)
        Me.NameTag1.TabIndex = 0
        '
        'lblTotal
        '
        Me.lblTotal.Font = New System.Drawing.Font("Gotham Bold", 16.0!)
        Me.lblTotal.ForeColor = System.Drawing.Color.White
        Me.lblTotal.Location = New System.Drawing.Point(169, 0)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(255, 90)
        Me.lblTotal.TabIndex = 7
        Me.lblTotal.Text = "$0"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPlayer
        '
        Me.txtPlayer.Font = New System.Drawing.Font("Gotham Bold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlayer.Location = New System.Drawing.Point(169, 29)
        Me.txtPlayer.Name = "txtPlayer"
        Me.txtPlayer.Size = New System.Drawing.Size(241, 33)
        Me.txtPlayer.TabIndex = 23
        Me.txtPlayer.Visible = False
        '
        'btnClose
        '
        Me.btnClose.Image = Global.WheelOfFortune.My.Resources.Resources.Delete
        Me.btnClose.Location = New System.Drawing.Point(402, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(24, 23)
        Me.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnClose.TabIndex = 24
        Me.btnClose.TabStop = False
        Me.btnClose.Visible = False
        '
        'ContestantDisplay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.txtPlayer)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.NameTag1)
        Me.Name = "ContestantDisplay"
        Me.Size = New System.Drawing.Size(426, 90)
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents NameTag1 As NameTag
    Friend WithEvents lblTotal As Label
    Friend WithEvents txtPlayer As TextBox
    Friend WithEvents btnClose As PictureBox
End Class
