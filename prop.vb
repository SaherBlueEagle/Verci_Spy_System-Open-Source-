Public Class prop
    Public yy As String = "|BlueEagle|"
    Public sock As Integer

    Dim RichTextBox2 As New RichTextBox
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick

        On Error Resume Next

        Dim aa As String = TextBox4.Text
        Dim aa1 As String = TextBox4.Text
        RichTextBox2.Text = aa.LastIndexOf(".")


        Dim xx1 As String = TextBox4.Text
        RichTextBox2.Text = xx1.Substring(RichTextBox2.Text)

        Timer1.Enabled = False
        TextBox1.Text = RichTextBox2.Text
        If TextBox1.Text = ".vbs" Then
            PictureBox2.Image = My.Resources.wscript_1.ToBitmap
            TextBox7.Text = "Microsoft ® Windows Based Script Host"
        ElseIf TextBox1.Text = ".vbe" Then
            PictureBox2.Image = My.Resources.wscript_1.ToBitmap
            TextBox7.Text = "Microsoft ® Windows Based Script Host"
        ElseIf TextBox1.Text = ".js" Then
            PictureBox2.Image = My.Resources.wscript_1.ToBitmap
            TextBox7.Text = "Microsoft ® Windows Based Script Host"

        ElseIf TextBox1.Text = ".rar" Then
            PictureBox2.Image = My.Resources.Icon_2
            TextBox7.Text = "WinRAR archiver"
        ElseIf TextBox1.Text = ".zip" Then
            PictureBox2.Image = My.Resources.Icon_2
            TextBox7.Text = "WinRAR archiver"
        ElseIf TextBox1.Text = ".png" Then
            PictureBox2.Image = My.Resources.imge_3
            TextBox7.Text = "Windows Photo Viewer"
        ElseIf TextBox1.Text = ".ico" Then
            PictureBox2.Image = My.Resources.imge_3
            TextBox7.Text = "Windows Photo Viewer"
        ElseIf TextBox1.Text = ".bmp" Then
            PictureBox2.Image = My.Resources.imge_3
            TextBox7.Text = "Windows Photo Viewer"
        ElseIf TextBox1.Text = ".jpg" Then
            PictureBox2.Image = My.Resources.imge_3
            TextBox7.Text = "Windows Photo Viewer"
        ElseIf TextBox1.Text = ".gif" Then
            PictureBox2.Image = My.Resources.imge_3
            TextBox7.Text = "Windows Photo Viewer"
        ElseIf TextBox1.Text = ".txt" Then
            PictureBox2.Image = My.Resources.Icon_4
            TextBox7.Text = "Notepad"
        ElseIf TextBox1.Text = ".rtf" Then
            PictureBox2.Image = My.Resources.Icon_4
            TextBox7.Text = "Notepad"
        ElseIf TextBox1.Text = ".ini" Then
            PictureBox2.Image = My.Resources.Icon_4
            TextBox7.Text = "Notepad"
        ElseIf TextBox1.Text = ".log" Then
            PictureBox2.Image = My.Resources.Icon_4
            TextBox7.Text = "Notepad"
        ElseIf TextBox1.Text = ".log" Then
            PictureBox2.Image = My.Resources.Icon_4
            TextBox7.Text = "Notepad"
        ElseIf TextBox1.Text = ".pif" Then
            PictureBox2.Image = My.Resources.OD
            TextBox7.Text = " MS-DOS‬‬ ‎(.pif)‎"
        ElseIf TextBox1.Text = ".lnk" Then
            PictureBox2.Image = My.Resources.OD
            TextBox7.Text = "(.lnk)‎"
        ElseIf TextBox1.Text = "-1" Then
            PictureBox2.Image = My.Resources.Fx
            TextBox7.Text = "(Folder Explorer)‎"
            TextBox1.Text = "File folder"
        End If

    End Sub


    Private Sub CheckBox2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then

            CheckBox1.Checked = False
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then

            CheckBox2.Checked = False
        End If
    End Sub



    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub prop_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub
End Class