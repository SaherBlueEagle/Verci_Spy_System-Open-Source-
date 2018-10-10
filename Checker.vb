Public Class Checker
    Dim Currh As Double = 0.0
    Dim per As Integer = 0
    Dim per_Reverse As Integer = 100
    Public offical As Boolean = True
  
    Dim currentCount As Integer
        Private Sub Checker_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.AllowTransparency = True
        Me.TransparencyKey = Me.BackColor
        Me.Size = New Size(Me.Width, 0)
      
        Timer1.Start()
    End Sub
    Dim Lisencse_Counter As Integer = 30

    '704; 101
    Private Function Check_If_TrialModified() As Boolean
        Return False
    End Function
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If Currh < 100 Then

            Currh += 10.1
            Me.Size = New Size(Me.Width, Currh)
        Else
            Timer1.Stop()


 

            Main.Show()
        Loadx.Start()
        End If
    End Sub
 
#Region "Drag"

    Dim posX As Integer
    Dim posY As Integer
    Dim drag As Boolean



    Private Sub Header_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label7.MouseDown
        If e.Button = MouseButtons.Left Then
            drag = True
            posX = Cursor.Position.X - Me.Left
            posY = Cursor.Position.Y - Me.Top
        End If
    End Sub

    Private Sub Header_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label7.MouseUp
        drag = False
    End Sub

    Private Sub Header_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label7.MouseMove
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
            Dim text As String = "Checking"
            Dim textSize = g.MeasureString(text, fnt)
            Dim textPoint As New Point(CInt(rect.Left + (rect.Width / 2) - (textSize.Width / 2)), CInt(rect.Top + (rect.Height / 2) - (textSize.Height / 2)))
            'now we have all the values draw the text
            ' g.DrawString(text, fnt, Brushes.Lime, textPoint)
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
    Private Sub Load_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel4.Paint
        If Currh < 100 Then
        Else
            DrawLoad(e.Graphics, New Rectangle(2, 3, 70, 70), per) '37; 405
            DrawReverse(e.Graphics, New Rectangle(12, 13, 50, 50), per_Reverse) '37; 405
        End If
    End Sub

    Private Sub Loadx_Tick(sender As System.Object, e As System.EventArgs) Handles Loadx.Tick
        Label3.Text = per

        If per = 100 Then
            per = 0
            Me.Close()
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
    Private Function CheckUniqueID() As Boolean
        On Error Resume Next
        'Serial Key checker 
        Return True

    End Function
 
End Class