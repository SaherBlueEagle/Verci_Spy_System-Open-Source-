<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ServiceController
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ServiceController))
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.StopServiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RunServiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshServicesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer4 = New System.Windows.Forms.Timer(Me.components)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LoaderX = New System.Windows.Forms.Timer(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.buttonClos = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StopServiceToolStripMenuItem, Me.RunServiceToolStripMenuItem, Me.RefreshServicesToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(159, 109)
        '
        'StopServiceToolStripMenuItem
        '
        Me.StopServiceToolStripMenuItem.AutoSize = False
        Me.StopServiceToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.StopServiceToolStripMenuItem.BackgroundImage = CType(resources.GetObject("StopServiceToolStripMenuItem.BackgroundImage"), System.Drawing.Image)
        Me.StopServiceToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.StopServiceToolStripMenuItem.ForeColor = System.Drawing.Color.DodgerBlue
        Me.StopServiceToolStripMenuItem.Image = CType(resources.GetObject("StopServiceToolStripMenuItem.Image"), System.Drawing.Image)
        Me.StopServiceToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.StopServiceToolStripMenuItem.Name = "StopServiceToolStripMenuItem"
        Me.StopServiceToolStripMenuItem.Size = New System.Drawing.Size(260, 35)
        Me.StopServiceToolStripMenuItem.Text = "Stop Service"
        '
        'RunServiceToolStripMenuItem
        '
        Me.RunServiceToolStripMenuItem.AutoSize = False
        Me.RunServiceToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.RunServiceToolStripMenuItem.BackgroundImage = CType(resources.GetObject("RunServiceToolStripMenuItem.BackgroundImage"), System.Drawing.Image)
        Me.RunServiceToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.RunServiceToolStripMenuItem.ForeColor = System.Drawing.Color.DodgerBlue
        Me.RunServiceToolStripMenuItem.Image = CType(resources.GetObject("RunServiceToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RunServiceToolStripMenuItem.Name = "RunServiceToolStripMenuItem"
        Me.RunServiceToolStripMenuItem.Size = New System.Drawing.Size(260, 35)
        Me.RunServiceToolStripMenuItem.Text = "Run Service"
        '
        'RefreshServicesToolStripMenuItem
        '
        Me.RefreshServicesToolStripMenuItem.AutoSize = False
        Me.RefreshServicesToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.RefreshServicesToolStripMenuItem.BackgroundImage = CType(resources.GetObject("RefreshServicesToolStripMenuItem.BackgroundImage"), System.Drawing.Image)
        Me.RefreshServicesToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.RefreshServicesToolStripMenuItem.ForeColor = System.Drawing.Color.DodgerBlue
        Me.RefreshServicesToolStripMenuItem.Image = CType(resources.GetObject("RefreshServicesToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RefreshServicesToolStripMenuItem.Name = "RefreshServicesToolStripMenuItem"
        Me.RefreshServicesToolStripMenuItem.Size = New System.Drawing.Size(260, 35)
        Me.RefreshServicesToolStripMenuItem.Text = "Refresh Services"
        '
        'Timer3
        '
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        '
        'Timer4
        '
        Me.Timer4.Enabled = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "151.png")
        Me.ImageList1.Images.SetKeyName(1, "152.png")
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label2.Location = New System.Drawing.Point(93, 411)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 19)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "-"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label1.Location = New System.Drawing.Point(5, 411)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 19)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Services : "
        '
        'ListView1
        '
        Me.ListView1.BackColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.ListView1.BackgroundImage = CType(resources.GetObject("ListView1.BackgroundImage"), System.Drawing.Image)
        Me.ListView1.BackgroundImageTiled = True
        Me.ListView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.ListView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ListView1.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.ForeColor = System.Drawing.SystemColors.Highlight
        Me.ListView1.LargeImageList = Me.ImageList1
        Me.ListView1.Location = New System.Drawing.Point(5, 34)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(781, 374)
        Me.ListView1.SmallImageList = Me.ImageList1
        Me.ListView1.TabIndex = 20
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Service Status"
        Me.ColumnHeader1.Width = 222
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Service name"
        Me.ColumnHeader2.Width = 156
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Service Type"
        Me.ColumnHeader3.Width = 193
        '
        'LoaderX
        '
        Me.LoaderX.Enabled = True
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Andalus", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label3.Location = New System.Drawing.Point(1, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(590, 26)
        Me.Label3.TabIndex = 63
        Me.Label3.Text = "       Services Controller  Computer : "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Andalus", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label4.Location = New System.Drawing.Point(655, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 24)
        Me.Label4.TabIndex = 62
        Me.Label4.Text = "Saher Blue Eagle"
        '
        'buttonClos
        '
        Me.buttonClos.BackColor = System.Drawing.Color.Transparent
        Me.buttonClos.Image = CType(resources.GetObject("buttonClos.Image"), System.Drawing.Image)
        Me.buttonClos.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.buttonClos.Location = New System.Drawing.Point(597, 4)
        Me.buttonClos.Name = "buttonClos"
        Me.buttonClos.Size = New System.Drawing.Size(33, 25)
        Me.buttonClos.TabIndex = 61
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Andalus", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label5.Location = New System.Drawing.Point(31, 429)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(115, 24)
        Me.Label5.TabIndex = 64
        Me.Label5.Text = "Verci Spy System"
        '
        'ServiceController
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Crimson
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(792, 50)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.buttonClos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ListView1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ServiceController"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ServiceController"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents StopServiceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RunServiceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshServicesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer3 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents Timer4 As System.Windows.Forms.Timer
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents LoaderX As System.Windows.Forms.Timer
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents buttonClos As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
