<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Choose_Port
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Choose_Port))
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.njrat = New System.Windows.Forms.RadioButton()
        Me.spybyte = New System.Windows.Forms.RadioButton()
        Me.sblj = New System.Windows.Forms.RadioButton()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.BackgroundImage = CType(resources.GetObject("Panel4.BackgroundImage"), System.Drawing.Image)
        Me.Panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel4.Controls.Add(Me.Button3)
        Me.Panel4.Location = New System.Drawing.Point(400, 44)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(104, 26)
        Me.Panel4.TabIndex = 41
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.Snow
        Me.Button3.Location = New System.Drawing.Point(0, 0)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(104, 26)
        Me.Button3.TabIndex = 0
        Me.Button3.Text = "Ok"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Andalus", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label4.Location = New System.Drawing.Point(12, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 26)
        Me.Label4.TabIndex = 42
        Me.Label4.Text = "Choose Server Port"
        '
        'njrat
        '
        Me.njrat.AutoSize = True
        Me.njrat.BackColor = System.Drawing.Color.Transparent
        Me.njrat.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.njrat.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.njrat.Location = New System.Drawing.Point(174, 6)
        Me.njrat.Name = "njrat"
        Me.njrat.Size = New System.Drawing.Size(127, 22)
        Me.njrat.TabIndex = 43
        Me.njrat.TabStop = True
        Me.njrat.Text = "1177  (Nj-RAT)"
        Me.njrat.UseVisualStyleBackColor = False
        '
        'spybyte
        '
        Me.spybyte.AutoSize = True
        Me.spybyte.BackColor = System.Drawing.Color.Transparent
        Me.spybyte.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.spybyte.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.spybyte.Location = New System.Drawing.Point(174, 56)
        Me.spybyte.Name = "spybyte"
        Me.spybyte.Size = New System.Drawing.Size(157, 22)
        Me.spybyte.TabIndex = 44
        Me.spybyte.TabStop = True
        Me.spybyte.Text = "6740 (Spy Byte Pal)"
        Me.spybyte.UseVisualStyleBackColor = False
        '
        'sblj
        '
        Me.sblj.AutoSize = True
        Me.sblj.BackColor = System.Drawing.Color.Transparent
        Me.sblj.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sblj.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.sblj.Location = New System.Drawing.Point(174, 30)
        Me.sblj.Name = "sblj"
        Me.sblj.Size = New System.Drawing.Size(137, 22)
        Me.sblj.TabIndex = 45
        Me.sblj.TabStop = True
        Me.sblj.Text = "54148 (sblj-RAT)"
        Me.sblj.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Andalus", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(26, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 22)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "Verci Spy System"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Andalus", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label2.Location = New System.Drawing.Point(388, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 22)
        Me.Label2.TabIndex = 47
        Me.Label2.Text = "Saher Blue Eagle"
        '
        'Choose_Port
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(521, 89)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.sblj)
        Me.Controls.Add(Me.spybyte)
        Me.Controls.Add(Me.njrat)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Panel4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Choose_Port"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Choose_Port"
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.Color.White
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents njrat As System.Windows.Forms.RadioButton
    Friend WithEvents spybyte As System.Windows.Forms.RadioButton
    Friend WithEvents sblj As System.Windows.Forms.RadioButton
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
