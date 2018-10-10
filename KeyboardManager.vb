Public Class KeyboardManager
    Public sock As Integer
 
#Region "Drag"

    Dim posX As Integer
    Dim posY As Integer
    Dim drag As Boolean

    Private Sub Header_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Header.MouseDoubleClick
        If e.Button = MouseButtons.Left Then
           
        End If
    End Sub

    Private Sub Header_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Header.MouseDown
        If e.Button = MouseButtons.Left Then
            drag = True
            posX = Cursor.Position.X - Me.Left
            posY = Cursor.Position.Y - Me.Top
        End If
    End Sub

    Private Sub Header_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Header.MouseUp
        drag = False
    End Sub

    Private Sub Header_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Header.MouseMove
        If drag Then
            Me.Top = Cursor.Position.Y - posY
            Me.Left = Cursor.Position.X - posX
        End If
        Me.Cursor = Cursors.Default
    End Sub
    ''Repeated
    Private Sub Label1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseDown
        If e.Button = MouseButtons.Left Then
            drag = True
            posX = Cursor.Position.X - Me.Left
            posY = Cursor.Position.Y - Me.Top
        End If
    End Sub

    Private Sub Label1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseUp
        drag = False
    End Sub

    Private Sub Label1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseMove
        If drag Then
            Me.Top = Cursor.Position.Y - posY
            Me.Left = Cursor.Position.X - posX
        End If
        Me.Cursor = Cursors.Default
    End Sub
    ''Repeated
    Private Sub Label2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label2.MouseDown
        If e.Button = MouseButtons.Left Then
            drag = True
            posX = Cursor.Position.X - Me.Left
            posY = Cursor.Position.Y - Me.Top
        End If
    End Sub

    Private Sub Label2_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label2.MouseUp
        drag = False
    End Sub

    Private Sub Label2_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label2.MouseMove
        If drag Then
            Me.Top = Cursor.Position.Y - posY
            Me.Left = Cursor.Position.X - posX
        End If
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub buttonClos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonClos.Click
        Me.Close()
    End Sub



#End Region
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If CheckBox1.Checked = True Then
            Main.S.Send(sock, "A" & "|BlueEagle|" & TextBox1.Text)
        End If
        If e.KeyChar = Chr(Keys.Enter) Then
            RichTextBox1.Text += TextBox1.Text & vbNewLine

            Main.S.Send(sock, "A" & "|BlueEagle|" & TextBox1.Text)
            TextBox1.Clear()
            TextBox1.Text = ""
        End If
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        TextBox2.Text += 1
        If TextBox2.Text = 5 Then RichTextBox1.Text += "K"
        'Keyboards Succeeded Connected ...

        If TextBox2.Text = 7 Then RichTextBox1.Text += "e"
        If TextBox2.Text = 9 Then RichTextBox1.Text += "y"
        If TextBox2.Text = 11 Then RichTextBox1.Text += "b"
        If TextBox2.Text = 13 Then RichTextBox1.Text += "o"
        If TextBox2.Text = 15 Then RichTextBox1.Text += "a"
        If TextBox2.Text = 17 Then RichTextBox1.Text += "r"
        If TextBox2.Text = 19 Then RichTextBox1.Text += "d"
        'If TextBox2.Text = 21 Then RichTextBox1.Text += "s"
        If TextBox2.Text = 23 Then RichTextBox1.Text += " "
        If TextBox2.Text = 25 Then RichTextBox1.Text += "S"
        If TextBox2.Text = 27 Then RichTextBox1.Text += "u"
        If TextBox2.Text = 29 Then RichTextBox1.Text += "c"
        If TextBox2.Text = 31 Then RichTextBox1.Text += "c"
        If TextBox2.Text = 33 Then RichTextBox1.Text += "e"
        If TextBox2.Text = 35 Then RichTextBox1.Text += "e"
        If TextBox2.Text = 37 Then RichTextBox1.Text += "d"
        If TextBox2.Text = 39 Then RichTextBox1.Text += "e"
        If TextBox2.Text = 41 Then RichTextBox1.Text += "d"
        If TextBox2.Text = 43 Then RichTextBox1.Text += " "
        If TextBox2.Text = 45 Then RichTextBox1.Text += "C"
        If TextBox2.Text = 47 Then RichTextBox1.Text += "o"
        If TextBox2.Text = 49 Then RichTextBox1.Text += "n"
        If TextBox2.Text = 51 Then RichTextBox1.Text += "n"
        If TextBox2.Text = 53 Then RichTextBox1.Text += "e"
        If TextBox2.Text = 55 Then RichTextBox1.Text += "c"
        If TextBox2.Text = 57 Then RichTextBox1.Text += "t"
        If TextBox2.Text = 59 Then RichTextBox1.Text += "e"
        If TextBox2.Text = 61 Then RichTextBox1.Text += "d"
        If TextBox2.Text = 63 Then RichTextBox1.Text += " "
        If TextBox2.Text = 65 Then RichTextBox1.Text += "."
        If TextBox2.Text = 67 Then RichTextBox1.Text += "."
        If TextBox2.Text = 69 Then RichTextBox1.Text += "."
        If TextBox2.Text = 71 Then RichTextBox1.Text += vbNewLine
        If TextBox2.Text = 74 Then Timer1.Enabled = False

    End Sub

    Private Sub KeyboardManager_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.AllowTransparency = True
        Me.TransparencyKey = Me.BackColor
        Label4.Text = "IP Address : " & Main.S.IP(sock)
        Timer1.Start()
    End Sub
End Class