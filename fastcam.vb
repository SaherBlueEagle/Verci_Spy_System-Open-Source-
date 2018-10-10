Public Class fastcam

    Private Sub fastcam_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Size.Width - (Notify.Width + Me.Width), Screen.PrimaryScreen.WorkingArea.Size.Height - (218 + 247))

    End Sub

    Private Sub buttonClos_Click(sender As System.Object, e As System.EventArgs) Handles buttonClos.Click
        Me.Close()
    End Sub
End Class