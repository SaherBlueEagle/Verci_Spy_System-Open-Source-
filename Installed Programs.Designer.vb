<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Installed_Programs
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Installed_Programs))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.buttonClos = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.UninstallToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'buttonClos
        '
        Me.buttonClos.BackColor = System.Drawing.Color.Transparent
        Me.buttonClos.Image = CType(resources.GetObject("buttonClos.Image"), System.Drawing.Image)
        Me.buttonClos.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.buttonClos.Location = New System.Drawing.Point(690, 7)
        Me.buttonClos.Name = "buttonClos"
        Me.buttonClos.Size = New System.Drawing.Size(33, 25)
        Me.buttonClos.TabIndex = 62
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Andalus", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label3.Location = New System.Drawing.Point(1, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(722, 26)
        Me.Label3.TabIndex = 64
        Me.Label3.Text = "       Remote Installed Programs  Compuer : "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Andalus", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label4.Location = New System.Drawing.Point(748, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 24)
        Me.Label4.TabIndex = 65
        Me.Label4.Text = "Saher Blue Eagle"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Andalus", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(33, 603)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 24)
        Me.Label1.TabIndex = 66
        Me.Label1.Text = "Verci Spy System"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "shell32_41.ico")
        Me.ImageList1.Images.SetKeyName(1, "gv34werf2qweas.png")
        Me.ImageList1.Images.SetKeyName(2, "1484366699_shield_accept.ico")
        Me.ImageList1.Images.SetKeyName(3, "Oxygen-Icons.org-Oxygen-Apps-system-software-update.ico")
        Me.ImageList1.Images.SetKeyName(4, "Treetog-I-Set-Program-Default.ico")
        Me.ImageList1.Images.SetKeyName(5, "shell32_310.ico")
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UninstallToolStripMenuItem, Me.RefreshToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(124, 76)
        '
        'UninstallToolStripMenuItem
        '
        Me.UninstallToolStripMenuItem.AutoSize = False
        Me.UninstallToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.UninstallToolStripMenuItem.BackgroundImage = CType(resources.GetObject("UninstallToolStripMenuItem.BackgroundImage"), System.Drawing.Image)
        Me.UninstallToolStripMenuItem.ForeColor = System.Drawing.Color.DodgerBlue
        Me.UninstallToolStripMenuItem.Image = CType(resources.GetObject("UninstallToolStripMenuItem.Image"), System.Drawing.Image)
        Me.UninstallToolStripMenuItem.Name = "UninstallToolStripMenuItem"
        Me.UninstallToolStripMenuItem.Size = New System.Drawing.Size(260, 36)
        Me.UninstallToolStripMenuItem.Text = "Uninstall "
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.AutoSize = False
        Me.RefreshToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.RefreshToolStripMenuItem.BackgroundImage = CType(resources.GetObject("RefreshToolStripMenuItem.BackgroundImage"), System.Drawing.Image)
        Me.RefreshToolStripMenuItem.ForeColor = System.Drawing.Color.DodgerBlue
        Me.RefreshToolStripMenuItem.Image = CType(resources.GetObject("RefreshToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(260, 36)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'ListView1
        '
        Me.ListView1.BackColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.ListView1.BackgroundImage = CType(resources.GetObject("ListView1.BackgroundImage"), System.Drawing.Image)
        Me.ListView1.BackgroundImageTiled = True
        Me.ListView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader14, Me.ColumnHeader15, Me.ColumnHeader16})
        Me.ListView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ListView1.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.ForeColor = System.Drawing.Color.Lime
        Me.ListView1.FullRowSelect = True
        Me.ListView1.LargeImageList = Me.ImageList1
        Me.ListView1.Location = New System.Drawing.Point(6, 44)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(884, 548)
        Me.ListView1.SmallImageList = Me.ImageList1
        Me.ListView1.TabIndex = 68
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Program Name"
        Me.ColumnHeader11.Width = 328
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Publisher"
        Me.ColumnHeader12.Width = 173
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "Install Date"
        Me.ColumnHeader13.Width = 86
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "Size "
        Me.ColumnHeader14.Width = 117
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "Version"
        Me.ColumnHeader15.Width = 126
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "Silent Uninstall Path"
        Me.ColumnHeader16.Width = 212
        '
        'Installed_Programs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SlateBlue
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(899, 636)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.buttonClos)
        Me.Controls.Add(Me.Label3)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Installed_Programs"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Installed_Programs"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents buttonClos As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents UninstallToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
End Class
