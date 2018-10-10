Public Class ClientScreen
    Public x, y As Integer
    Dim x2, y2 As Integer
    Sub showscreen()
        y2 = Me.Location.Y
        x2 = Me.Location.X
        screenshower.Start()
    End Sub

    Private Sub screenshower_Tick(sender As System.Object, e As System.EventArgs) Handles screenshower.Tick
      
    End Sub

   
    Private Sub ClientScreen_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Location = New Point(x, y)

        showscreen()
    End Sub
End Class