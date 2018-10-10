<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Registry_Editor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Registry_Editor))
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("HKEY_CLASSES_ROOT")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("HKEY_CURRENT_USER")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("HKEY_LOCAL_MACHINE")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("HKEY_USERS")
        Me.crgk = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateKeyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteKeyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.crg = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RefreshToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewValueToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.l1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.RGk = New System.Windows.Forms.TreeView()
        Me.RGLIST = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.buttonClos = New System.Windows.Forms.Label()
        Me.pr = New System.Windows.Forms.ProgressBar()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.crgk.SuspendLayout()
        Me.crg.SuspendLayout()
        Me.SuspendLayout()
        '
        'crgk
        '
        Me.crgk.BackgroundImage = CType(resources.GetObject("crgk.BackgroundImage"), System.Drawing.Image)
        Me.crgk.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RefreshToolStripMenuItem, Me.CreateKeyToolStripMenuItem, Me.DeleteKeyToolStripMenuItem})
        Me.crgk.Name = "crgk"
        Me.crgk.Size = New System.Drawing.Size(128, 109)
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.AutoSize = False
        Me.RefreshToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.RefreshToolStripMenuItem.BackgroundImage = CType(resources.GetObject("RefreshToolStripMenuItem.BackgroundImage"), System.Drawing.Image)
        Me.RefreshToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Highlight
        Me.RefreshToolStripMenuItem.Image = CType(resources.GetObject("RefreshToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(260, 35)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'CreateKeyToolStripMenuItem
        '
        Me.CreateKeyToolStripMenuItem.AutoSize = False
        Me.CreateKeyToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.CreateKeyToolStripMenuItem.BackgroundImage = CType(resources.GetObject("CreateKeyToolStripMenuItem.BackgroundImage"), System.Drawing.Image)
        Me.CreateKeyToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Highlight
        Me.CreateKeyToolStripMenuItem.Image = CType(resources.GetObject("CreateKeyToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CreateKeyToolStripMenuItem.Name = "CreateKeyToolStripMenuItem"
        Me.CreateKeyToolStripMenuItem.Size = New System.Drawing.Size(260, 35)
        Me.CreateKeyToolStripMenuItem.Text = "CreateKey"
        '
        'DeleteKeyToolStripMenuItem
        '
        Me.DeleteKeyToolStripMenuItem.AutoSize = False
        Me.DeleteKeyToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.DeleteKeyToolStripMenuItem.BackgroundImage = CType(resources.GetObject("DeleteKeyToolStripMenuItem.BackgroundImage"), System.Drawing.Image)
        Me.DeleteKeyToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Highlight
        Me.DeleteKeyToolStripMenuItem.Image = CType(resources.GetObject("DeleteKeyToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DeleteKeyToolStripMenuItem.Name = "DeleteKeyToolStripMenuItem"
        Me.DeleteKeyToolStripMenuItem.Size = New System.Drawing.Size(260, 35)
        Me.DeleteKeyToolStripMenuItem.Text = "DeleteKey"
        '
        'crg
        '
        Me.crg.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RefreshToolStripMenuItem1, Me.EditToolStripMenuItem, Me.NewValueToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.crg.Name = "crg"
        Me.crg.Size = New System.Drawing.Size(127, 144)
        '
        'RefreshToolStripMenuItem1
        '
        Me.RefreshToolStripMenuItem1.AutoSize = False
        Me.RefreshToolStripMenuItem1.BackColor = System.Drawing.Color.White
        Me.RefreshToolStripMenuItem1.BackgroundImage = CType(resources.GetObject("RefreshToolStripMenuItem1.BackgroundImage"), System.Drawing.Image)
        Me.RefreshToolStripMenuItem1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.RefreshToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.Highlight
        Me.RefreshToolStripMenuItem1.Image = CType(resources.GetObject("RefreshToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.RefreshToolStripMenuItem1.Name = "RefreshToolStripMenuItem1"
        Me.RefreshToolStripMenuItem1.Size = New System.Drawing.Size(260, 35)
        Me.RefreshToolStripMenuItem1.Text = "Refresh"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.AutoSize = False
        Me.EditToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.EditToolStripMenuItem.BackgroundImage = CType(resources.GetObject("EditToolStripMenuItem.BackgroundImage"), System.Drawing.Image)
        Me.EditToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.EditToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Highlight
        Me.EditToolStripMenuItem.Image = CType(resources.GetObject("EditToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(260, 35)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'NewValueToolStripMenuItem
        '
        Me.NewValueToolStripMenuItem.AutoSize = False
        Me.NewValueToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.NewValueToolStripMenuItem.BackgroundImage = CType(resources.GetObject("NewValueToolStripMenuItem.BackgroundImage"), System.Drawing.Image)
        Me.NewValueToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.NewValueToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Highlight
        Me.NewValueToolStripMenuItem.Image = CType(resources.GetObject("NewValueToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NewValueToolStripMenuItem.Name = "NewValueToolStripMenuItem"
        Me.NewValueToolStripMenuItem.Size = New System.Drawing.Size(260, 35)
        Me.NewValueToolStripMenuItem.Text = "NewValue"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.AutoSize = False
        Me.DeleteToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.DeleteToolStripMenuItem.BackgroundImage = CType(resources.GetObject("DeleteToolStripMenuItem.BackgroundImage"), System.Drawing.Image)
        Me.DeleteToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.DeleteToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Highlight
        Me.DeleteToolStripMenuItem.Image = CType(resources.GetObject("DeleteToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(260, 35)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'l1
        '
        Me.l1.ImageStream = CType(resources.GetObject("l1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.l1.TransparentColor = System.Drawing.Color.Transparent
        Me.l1.Images.SetKeyName(0, "R_1.png")
        Me.l1.Images.SetKeyName(1, "R_3.png")
        Me.l1.Images.SetKeyName(2, "R_2.png")
        '
        'Timer2
        '
        '
        'RGk
        '
        Me.RGk.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.RGk.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RGk.ContextMenuStrip = Me.crgk
        Me.RGk.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RGk.ForeColor = System.Drawing.Color.DodgerBlue
        Me.RGk.ImageIndex = 0
        Me.RGk.ImageList = Me.l1
        Me.RGk.LineColor = System.Drawing.Color.DodgerBlue
        Me.RGk.Location = New System.Drawing.Point(7, 47)
        Me.RGk.Name = "RGk"
        TreeNode1.ImageIndex = -2
        TreeNode1.Name = "HKEY_CLASSES_ROOT"
        TreeNode1.Text = "HKEY_CLASSES_ROOT"
        TreeNode2.ImageIndex = -2
        TreeNode2.Name = "HKEY_CURRENT_USER"
        TreeNode2.Text = "HKEY_CURRENT_USER"
        TreeNode3.ImageIndex = -2
        TreeNode3.Name = "HKEY_LOCAL_MACHINE"
        TreeNode3.Text = "HKEY_LOCAL_MACHINE"
        TreeNode4.ImageIndex = -2
        TreeNode4.Name = "HKEY_USERS"
        TreeNode4.Text = "HKEY_USERS"
        Me.RGk.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3, TreeNode4})
        Me.RGk.SelectedImageIndex = 0
        Me.RGk.Size = New System.Drawing.Size(277, 571)
        Me.RGk.TabIndex = 17
        '
        'RGLIST
        '
        Me.RGLIST.BackColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.RGLIST.BackgroundImage = CType(resources.GetObject("RGLIST.BackgroundImage"), System.Drawing.Image)
        Me.RGLIST.BackgroundImageTiled = True
        Me.RGLIST.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RGLIST.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.RGLIST.ContextMenuStrip = Me.crg
        Me.RGLIST.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RGLIST.ForeColor = System.Drawing.Color.DodgerBlue
        Me.RGLIST.Location = New System.Drawing.Point(290, 47)
        Me.RGLIST.Name = "RGLIST"
        Me.RGLIST.Size = New System.Drawing.Size(628, 560)
        Me.RGLIST.SmallImageList = Me.l1
        Me.RGLIST.TabIndex = 18
        Me.RGLIST.UseCompatibleStateImageBehavior = False
        Me.RGLIST.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Name"
        Me.ColumnHeader1.Width = 203
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Type"
        Me.ColumnHeader2.Width = 148
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Value"
        Me.ColumnHeader3.Width = 144
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Andalus", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label4.Location = New System.Drawing.Point(769, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(121, 26)
        Me.Label4.TabIndex = 59
        Me.Label4.Text = "Saher Blue Eagle"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Andalus", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(41, 621)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 26)
        Me.Label1.TabIndex = 60
        Me.Label1.Text = "Verci Spy System"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Andalus", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label2.Location = New System.Drawing.Point(37, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(663, 26)
        Me.Label2.TabIndex = 61
        Me.Label2.Text = "Registry Editor  Computer : "
        '
        'buttonClos
        '
        Me.buttonClos.BackColor = System.Drawing.Color.Transparent
        Me.buttonClos.Image = CType(resources.GetObject("buttonClos.Image"), System.Drawing.Image)
        Me.buttonClos.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.buttonClos.Location = New System.Drawing.Point(706, 7)
        Me.buttonClos.Name = "buttonClos"
        Me.buttonClos.Size = New System.Drawing.Size(33, 25)
        Me.buttonClos.TabIndex = 62
        '
        'pr
        '
        Me.pr.Location = New System.Drawing.Point(290, 621)
        Me.pr.Name = "pr"
        Me.pr.Size = New System.Drawing.Size(600, 19)
        Me.pr.TabIndex = 63
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Andalus", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label3.Location = New System.Drawing.Point(208, 616)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 26)
        Me.Label3.TabIndex = 64
        Me.Label3.Text = "Progress"
        '
        'Registry_Editor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Crimson
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(926, 10)
        Me.Controls.Add(Me.RGk)
        Me.Controls.Add(Me.pr)
        Me.Controls.Add(Me.buttonClos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.RGLIST)
        Me.Controls.Add(Me.Label3)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Registry_Editor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "s"
        Me.crgk.ResumeLayout(False)
        Me.crg.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents crgk As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CreateKeyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteKeyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents crg As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RefreshToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewValueToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents l1 As System.Windows.Forms.ImageList
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents RGk As System.Windows.Forms.TreeView
    Friend WithEvents RGLIST As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents buttonClos As System.Windows.Forms.Label
    Friend WithEvents pr As System.Windows.Forms.ProgressBar
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
