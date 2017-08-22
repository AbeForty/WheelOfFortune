<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WheelSpinnerTest
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WheelSpinnerTest))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btnSpin = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'btnSpin
        '
        Me.btnSpin.Location = New System.Drawing.Point(195, 456)
        Me.btnSpin.Name = "btnSpin"
        Me.btnSpin.Size = New System.Drawing.Size(75, 23)
        Me.btnSpin.TabIndex = 0
        Me.btnSpin.Text = "SPIN"
        Me.btnSpin.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(303, 462)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Label1"
        '
        'WheelSpinnerTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(482, 491)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSpin)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "WheelSpinnerTest"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Timer1 As Timer
    Friend WithEvents btnSpin As Button
    Friend WithEvents Label1 As Label
End Class
