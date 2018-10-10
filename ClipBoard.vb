Public Class ClipBoard
    'Normal : 377
    Dim currH As Double = 0.0
    'Norm Loc : 37; 28
    Public sock As Integer
    Dim clipimage As String = Environment.GetFolderPath(Environment.SpecialFolder.Templates) & "\" + "SetClipImage.jpg"
    Private Sub getClip()
        Main.S.Send(sock, "getcli")
    End Sub
    Private Sub setClipboard(ByVal Setter As String)
        Main.S.Send(sock, "setcli" & Main.Yy & Setter)
    End Sub
    Private Sub ClipBoard_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.AllowTransparency = True
        Me.TransparencyKey = Me.BackColor
        Me.GroupBox1.Visible = False
        Me.GroupBox2.Visible = False
        Timer1.Start()
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Me.GroupBox1.Visible = False
        Me.GroupBox2.Visible = True
        Me.GroupBox3.Visible = False
        currH = 0.0
        GroupBox2.Location = New Point(37, 28)
        Timer2.Start()
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        Me.GroupBox1.Visible = True
        Me.GroupBox2.Visible = False
        Me.GroupBox3.Visible = False
        currH = 0.0
        GroupBox1.Location = New Point(37, 28)
        Timer3.Start()
    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        If currH < 376 Then '377
            currH += 37.7
            GroupBox2.Size = New Size(351, currH)
        Else
            Timer2.Stop()

        End If

    End Sub

    Private Sub Timer3_Tick(sender As System.Object, e As System.EventArgs) Handles Timer3.Tick
        If currH < 376 Then '377
            currH += 37.7
            GroupBox1.Size = New Size(351, currH)
        Else
            Timer3.Stop()

        End If
    End Sub

    Private Sub Button5_MouseHover(sender As System.Object, e As System.EventArgs) Handles Button5.MouseHover
        Button5.ForeColor = Color.Lime

    End Sub

    Private Sub Button4_MouseLeave(sender As System.Object, e As System.EventArgs) Handles Button4.MouseLeave

        Button4.ForeColor = Color.Snow
    End Sub
    Private Sub Button4_MouseHover(sender As System.Object, e As System.EventArgs) Handles Button4.MouseHover

        Button4.ForeColor = Color.Lime
    End Sub

    Private Sub Button5_MouseLeave(sender As System.Object, e As System.EventArgs) Handles Button5.MouseLeave
        Button5.ForeColor = Color.Snow

    End Sub
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If currH < 436 Then '437
            currH += 43.7
            Me.Size = New Size(422, currH)
        Else
            Timer1.Stop()
            currH = 0.0
            Reforge()
            Exit Sub
        End If
    End Sub
    Sub Reforge()
        Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Size.Width / 2 - Me.Width / 2, Screen.PrimaryScreen.WorkingArea.Size.Height / 2 - 215)

        Me.Refresh()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        OpenFileDialog1.ShowDialog()
        OpenFileDialog1.Filter = "Bitmap|*.bmp|JPEG|*.jpg"
        If OpenFileDialog1.FileName.Length > 0 Then
            PictureBox2.Image = Image.FromFile(OpenFileDialog1.FileName)
            PictureBox2.Image.Save(clipimage)
        Else
            MsgBox("No Image Selected", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        If PictureBox2.Image Is Nothing Then
            MsgBox("No Image Selected", MsgBoxStyle.Critical)
            Exit Sub
        Else
            Main.S.Send(sock, "setcliimg" & Main.Yy & Convert.ToBase64String(IO.File.ReadAllBytes(clipimage)))
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        setClipboard(TextBox2.Text)
    End Sub

    Private Sub Button15_Click(sender As System.Object, e As System.EventArgs) Handles Button15.Click
        getClip()
    End Sub

    Private Sub buttonClos_Click(sender As System.Object, e As System.EventArgs) Handles buttonClos.Click
        Me.Close()
    End Sub

    Private Sub Label7_Click(sender As System.Object, e As System.EventArgs) Handles Label7.Click
        Me.GroupBox1.Visible = False
        Me.GroupBox2.Visible = False
        Me.GroupBox3.Visible = True
    End Sub
End Class