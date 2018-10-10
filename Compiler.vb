Public Class Compiler
    Public sock As Integer
    Private Sub Compiler_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.AllowTransparency = True
        Me.TransparencyKey = Me.BackColor
        Timer1.Start()
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



#End Region
    Dim Curr As Double = 0.0

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If Curr < 506 Then '50.7
            Curr += 50.7
            Me.Size = New Size(Me.Width, Curr)
        Else
            Timer1.Stop()
            LoadSend()
            Reforge()
        End If
    End Sub
    Sub Reforge() '636 --> 300 --> 318
        Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Size.Width / 2 - Me.Width / 2, Screen.PrimaryScreen.WorkingArea.Size.Height / 2 - 253)

        Me.Refresh()
    End Sub
    Private Sub LoadSend()
        Me.Refresh()
    End Sub
    Private Sub CompileCode()
        If SkyDarkCombo1.SelectedItem.ToString.Contains(".vbs") Then
            Main.S.Send(sock, "script" & Main.Yy & TextBox8.Text & Main.Yy & ".vbs")
        ElseIf SkyDarkCombo1.SelectedItem.ToString.Contains(".bat") Then
            Main.S.Send(sock, "script" & Main.Yy & TextBox8.Text & Main.Yy & ".bat")
        ElseIf SkyDarkCombo1.SelectedItem.ToString.Contains(".html") Then
            Main.S.Send(sock, "script" & Main.Yy & TextBox8.Text & Main.Yy & ".html")
        Else
            MsgBox("Please Choose a Type", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        CompileCode()
    End Sub
End Class