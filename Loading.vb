Public Class Loading
    Dim per As Integer = 0
    Dim per_Reverse As Integer = 100
    Dim currH As Integer = 0
    Public BackdoorFinished As Boolean = False : Public RansomFinished As Boolean = False : Public downloaderFinished As Boolean = False : Public wormFinished As Boolean = False
    Private Sub Loading_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.AllowTransparency = True
        Me.TransparencyKey = Me.BackColor
        On Error Resume Next
        
        Timer1.Start()
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
        Using fnt As New Font(Me.Font.FontFamily, 10)
            Dim text As String = "Loading"
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

    Private Sub Loadx_Tick(sender As System.Object, e As System.EventArgs) Handles Loadx.Tick
        Label3.Text = per
        If Label3.Text.Equals("100") Then
            Loadx.Stop()
            Timer2.Start()
        End If
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
        Me.Refresh()
    End Sub

    Private Sub Load_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel4.Paint
        If currH = 135 Then

            DrawLoad(e.Graphics, New Rectangle(3, 3, 100, 100), per) '37; 405
            DrawReverse(e.Graphics, New Rectangle(13, 13, 80, 80), per_Reverse) '37; 405
        End If
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If Me.Height = 135 Then
            Timer1.Stop()
            Loadx.Start()

            Exit Sub
        Else
            currH += 9
            Me.Size = New Size(724, currH)
            Me.Refresh()
            Me.StartPosition = FormStartPosition.CenterScreen
        End If
    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        If Me.Height = 5 Then
            Label3.Visible = False
            Label4.Visible = False
            Loadx.Stop()
            Timer2.Stop()

            If BackdoorFinished Then
                backdoorbuilder.Show()
            End If

            If RansomFinished Then
                IO.File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\VerciRansomBuilder.exe", My.Resources.SaherBlueEagleRansomwareBuilder)
                Try
                    System.Diagnostics.Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\VerciRansomBuilder.exe")
                    RansomFinished = False
                Catch ex As Exception
                    MsgBox("Failure , System File Writer Failed to start Ransomware Builder", MsgBoxStyle.Critical)
                End Try

            End If
            If downloaderFinished Then
                Downloader.Show()
            End If
            If wormFinished Then
                worm_builder.Show()
            End If
            Me.Close()
            Exit Sub
        Else
            currH -= 5
            Me.Size = New Size(724, currH)
            Me.Refresh()
            Me.StartPosition = FormStartPosition.CenterScreen
        End If
    End Sub
End Class