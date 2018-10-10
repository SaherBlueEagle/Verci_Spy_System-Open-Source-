<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class netstat
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(netstat))
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.buttonClos = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RefreshNetworkInformationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Andalus", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label4.Location = New System.Drawing.Point(726, 4)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 24)
        Me.Label4.TabIndex = 73
        Me.Label4.Text = "Saher Blue Eagle"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Andalus", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label3.Location = New System.Drawing.Point(1, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(698, 37)
        Me.Label3.TabIndex = 74
        Me.Label3.Text = "       Remote Connections Viewer  Compuer : "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Andalus", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(37, 531)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 24)
        Me.Label1.TabIndex = 75
        Me.Label1.Text = "Versi Spy System"
        '
        'buttonClos
        '
        Me.buttonClos.BackColor = System.Drawing.Color.Transparent
        Me.buttonClos.Image = CType(resources.GetObject("buttonClos.Image"), System.Drawing.Image)
        Me.buttonClos.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.buttonClos.Location = New System.Drawing.Point(666, 4)
        Me.buttonClos.Name = "buttonClos"
        Me.buttonClos.Size = New System.Drawing.Size(33, 25)
        Me.buttonClos.TabIndex = 76
        '
        'Timer1
        '
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Everaldo-Crystal-Clear-App-internet-connection-tools.ico")
        Me.ImageList1.Images.SetKeyName(1, "Fatcow-Farm-Fresh-Network-adapter.ico")
        Me.ImageList1.Images.SetKeyName(2, "1484113668_16.ico")
        Me.ImageList1.Images.SetKeyName(3, "address_book_40px_572639_easyicon.net.ico")
        Me.ImageList1.Images.SetKeyName(4, "IP Address-48.png")
        Me.ImageList1.Images.SetKeyName(5, "Icons-Land-Vista-Hardware-Devices-Ethernet-Cable.ico")
        Me.ImageList1.Images.SetKeyName(6, "1449772058_mail-send-receive.ico")
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RefreshNetworkInformationToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(228, 39)
        '
        'RefreshNetworkInformationToolStripMenuItem
        '
        Me.RefreshNetworkInformationToolStripMenuItem.AutoSize = False
        Me.RefreshNetworkInformationToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue
        Me.RefreshNetworkInformationToolStripMenuItem.BackgroundImage = CType(resources.GetObject("RefreshNetworkInformationToolStripMenuItem.BackgroundImage"), System.Drawing.Image)
        Me.RefreshNetworkInformationToolStripMenuItem.ForeColor = System.Drawing.Color.DodgerBlue
        Me.RefreshNetworkInformationToolStripMenuItem.Image = CType(resources.GetObject("RefreshNetworkInformationToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RefreshNetworkInformationToolStripMenuItem.Name = "RefreshNetworkInformationToolStripMenuItem"
        Me.RefreshNetworkInformationToolStripMenuItem.Size = New System.Drawing.Size(260, 35)
        Me.RefreshNetworkInformationToolStripMenuItem.Text = "Refresh Network Information"
        '
        'ListView2
        '
        Me.ListView2.BackColor = System.Drawing.Color.White
        Me.ListView2.BackgroundImage = CType(resources.GetObject("ListView2.BackgroundImage"), System.Drawing.Image)
        Me.ListView2.BackgroundImageTiled = True
        Me.ListView2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListView2.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ListView2.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView2.ForeColor = System.Drawing.Color.Lime
        Me.ListView2.LargeImageList = Me.ImageList1
        Me.ListView2.Location = New System.Drawing.Point(6, 39)
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(860, 489)
        Me.ListView2.SmallImageList = Me.ImageList1
        Me.ListView2.TabIndex = 78
        Me.ListView2.UseCompatibleStateImageBehavior = False
        Me.ListView2.View = System.Windows.Forms.View.List
        '
        'netstat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SaddleBrown
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(873, 561)
        Me.Controls.Add(Me.ListView2)
        Me.Controls.Add(Me.buttonClos)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "netstat"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "netstat"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents buttonClos As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RefreshNetworkInformationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListView2 As System.Windows.Forms.ListView
End Class
