Public Class Process_Watcher
    Dim Curr As Double = 0.0
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
        Me.Refresh()
    End Sub

    Private Sub Header_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label3.MouseUp
        drag = False
        Me.Refresh()
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

    Private Sub Process_Watcher_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.AllowTransparency = True
        Me.TransparencyKey = Me.BackColor
        Timer1.Start()
    End Sub
    '433
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If Curr < 432 Then
            Curr += 43.3
            Me.Size = New Size(Me.Width, Curr)

        Else
            Timer1.Stop()
            loader()
            Me.Refresh()
        End If

    End Sub
    Sub loader()
        Main.S.Send(sock, "pdataready")
    End Sub

    Private Sub RunServiceToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RunServiceToolStripMenuItem.Click
        Main.S.Send(sock, "pdataRefresh")
    End Sub

    Private Sub StopServiceToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles StopServiceToolStripMenuItem.Click
        If ListView1.SelectedItems.Count = 1 Then
            Dim pname = ListView1.SelectedItems(0).Text + ".exe"
            Main.S.Send(sock, "endpdata" & Main.Yy & pname)
        Else
            MsgBox("Please Select one process to kill it`s Socket")
        End If
    End Sub

    Private Sub ForceProcessKillToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ForceProcessKillToolStripMenuItem.Click
        If ListView1.SelectedItems.Count = 1 Then
            Dim pname = ListView1.SelectedItems(0).Text
            Main.S.Send(sock, "endpdata" & Main.Yy & pname)
        Else
            MsgBox("Please Select one process to kill it`s Socket")
        End If
    End Sub
End Class