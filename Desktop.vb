Public Class Desktop
    Public F As Main
    Public Sock As Integer
    Public Sz As Size
    Dim op As New Point(1, 1)
    Dim ee As System.Windows.Forms.KeyEventArgs
    Dim currH As Double = 0.0

#Region "Drag"

    Dim posX As Integer
    Dim posY As Integer
    Dim drag As Boolean

    Private Sub Header_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Header.MouseDoubleClick
        If e.Button = MouseButtons.Left Then
            If maximized Then
                Me.WindowState = FormWindowState.Normal
                maximized = False
            Else
                Me.WindowState = FormWindowState.Maximized
                maximized = True
            End If
        End If
    End Sub

    Private Sub Header_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Header.MouseDown
        If e.Button = MouseButtons.Left Then
            drag = True
            posX = Cursor.Position.X - Me.Left
            posY = Cursor.Position.Y - Me.Top
        End If
    End Sub

    Private Sub Header_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Header.MouseUp
        drag = False
    End Sub

    Private Sub Header_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Header.MouseMove
        If drag Then
            Me.Top = Cursor.Position.Y - posY
            Me.Left = Cursor.Position.X - posX
        End If
        Me.Cursor = Cursors.Default
    End Sub
    ''Repeated
    Private Sub Label1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseDown
        If e.Button = MouseButtons.Left Then
            drag = True
            posX = Cursor.Position.X - Me.Left
            posY = Cursor.Position.Y - Me.Top
        End If
    End Sub

    Private Sub Label1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseUp
        drag = False
    End Sub

    Private Sub Label1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseMove
        If drag Then
            Me.Top = Cursor.Position.Y - posY
            Me.Left = Cursor.Position.X - posX
        End If
        Me.Cursor = Cursors.Default
    End Sub
    ''Repeated
    Private Sub Label2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label2.MouseDown
        If e.Button = MouseButtons.Left Then
            drag = True
            posX = Cursor.Position.X - Me.Left
            posY = Cursor.Position.Y - Me.Top
        End If
    End Sub

    Private Sub Label2_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label2.MouseUp
        drag = False
    End Sub

    Private Sub Label2_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label2.MouseMove
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

#Region "Resize"

    Dim onFullScreen As Boolean
    Dim maximized As Boolean
    Dim on_MinimumSize As Boolean
    Dim minimumWidth As Short = 350
    Dim minimumHeight As Short = 26
    Dim borderSpace As Short = 20
    Dim borderDiameter As Short = 3

    Dim onBorderRight As Boolean
    Dim onBorderLeft As Boolean
    Dim onBorderTop As Boolean
    Dim onBorderBottom As Boolean
    Dim onCornerTopRight As Boolean
    Dim onCornerTopLeft As Boolean
    Dim onCornerBottomRight As Boolean
    Dim onCornerBottomLeft As Boolean

    Dim movingRight As Boolean
    Dim movingLeft As Boolean
    Dim movingTop As Boolean
    Dim movingBottom As Boolean
    Dim movingCornerTopRight As Boolean
    Dim movingCornerTopLeft As Boolean
    Dim movingCornerBottomRight As Boolean
    Dim movingCornerBottomLeft As Boolean

    Private Sub Borderless_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If onBorderRight Then movingRight = True Else movingRight = False
            If onBorderLeft Then movingLeft = True Else movingLeft = False
            If onBorderTop Then movingTop = True Else movingTop = False
            If onBorderBottom Then movingBottom = True Else movingBottom = False
            If onCornerTopRight Then movingCornerTopRight = True Else movingCornerTopRight = False
            If onCornerTopLeft Then movingCornerTopLeft = True Else movingCornerTopLeft = False
            If onCornerBottomRight Then movingCornerBottomRight = True Else movingCornerBottomRight = False
            If onCornerBottomLeft Then movingCornerBottomLeft = True Else movingCornerBottomLeft = False
        End If
    End Sub

    Private Sub Borderless_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        stopResizer()
    End Sub

    Private Sub Borderless_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If onFullScreen Or maximized Then Exit Sub

        If Me.Width <= minimumWidth Then Me.Width = (minimumWidth + 5) : on_MinimumSize = True
        If Me.Height <= minimumHeight Then Me.Height = (minimumHeight + 5) : on_MinimumSize = True
        If on_MinimumSize Then stopResizer() Else startResizer()


        If (Cursor.Position.X > (Me.Location.X + Me.Width) - borderDiameter) _
            And (Cursor.Position.Y > (Me.Location.Y + borderSpace)) _
            And (Cursor.Position.Y < ((Me.Location.Y + Me.Height) - borderSpace)) Then
            Me.Cursor = Cursors.SizeWE
            onBorderRight = True

        ElseIf (Cursor.Position.X < (Me.Location.X + borderDiameter)) _
            And (Cursor.Position.Y > (Me.Location.Y + borderSpace)) _
            And (Cursor.Position.Y < ((Me.Location.Y + Me.Height) - borderSpace)) Then
            Me.Cursor = Cursors.SizeWE
            onBorderLeft = True

        ElseIf (Cursor.Position.Y < (Me.Location.Y + borderDiameter)) _
            And (Cursor.Position.X > (Me.Location.X + borderSpace)) _
            And (Cursor.Position.X < ((Me.Location.X + Me.Width) - borderSpace)) Then
            Me.Cursor = Cursors.SizeNS
            onBorderTop = True

        ElseIf (Cursor.Position.Y > ((Me.Location.Y + Me.Height) - borderDiameter)) _
            And (Cursor.Position.X > (Me.Location.X + borderSpace)) _
            And (Cursor.Position.X < ((Me.Location.X + Me.Width) - borderSpace)) Then
            Me.Cursor = Cursors.SizeNS
            onBorderBottom = True

        ElseIf (Cursor.Position.X = ((Me.Location.X + Me.Width) - 1)) _
            And (Cursor.Position.Y = Me.Location.Y) Then
            Me.Cursor = Cursors.SizeNESW
            onCornerTopRight = True

        ElseIf (Cursor.Position.X = Me.Location.X) _
            And (Cursor.Position.Y = Me.Location.Y) Then
            Me.Cursor = Cursors.SizeNWSE
            onCornerTopLeft = True

        ElseIf (Cursor.Position.X = ((Me.Location.X + Me.Width) - 1)) _
            And (Cursor.Position.Y = ((Me.Location.Y + Me.Height) - 1)) Then
            Me.Cursor = Cursors.SizeNWSE
            onCornerBottomRight = True

        ElseIf (Cursor.Position.X = Me.Location.X) _
            And (Cursor.Position.Y = ((Me.Location.Y + Me.Height) - 1)) Then
            Me.Cursor = Cursors.SizeNESW
            onCornerBottomLeft = True

        Else
            onBorderRight = False
            onBorderLeft = False
            onBorderTop = False
            onBorderBottom = False
            onCornerTopRight = False
            onCornerTopLeft = False
            onCornerBottomRight = False
            onCornerBottomLeft = False
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub startResizer()
        Select Case True

            Case movingRight
                Me.Width = (Cursor.Position.X - Me.Location.X)

            Case movingLeft
                Me.Width = ((Me.Width + Me.Location.X) - Cursor.Position.X)
                Me.Location = New Point(Cursor.Position.X, Me.Location.Y)

            Case movingTop
                Me.Height = ((Me.Height + Me.Location.Y) - Cursor.Position.Y)
                Me.Location = New Point(Me.Location.X, Cursor.Position.Y)

            Case movingBottom
                Me.Height = (Cursor.Position.Y - Me.Location.Y)

            Case movingCornerTopRight
                Me.Width = (Cursor.Position.X - Me.Location.X)
                Me.Height = ((Me.Location.Y - Cursor.Position.Y) + Me.Height)
                Me.Location = New Point(Me.Location.X, Cursor.Position.Y)

            Case movingCornerTopLeft
                Me.Width = ((Me.Width + Me.Location.X) - Cursor.Position.X)
                Me.Location = New Point(Cursor.Position.X, Me.Location.Y)
                Me.Height = ((Me.Height + Me.Location.Y) - Cursor.Position.Y)
                Me.Location = New Point(Me.Location.X, Cursor.Position.Y)

            Case movingCornerBottomRight
                Me.Size = New Point((Cursor.Position.X - Me.Location.X), (Cursor.Position.Y - Me.Location.Y))

            Case movingCornerBottomLeft
                Me.Width = ((Me.Width + Me.Location.X) - Cursor.Position.X)
                Me.Height = (Cursor.Position.Y - Me.Location.Y)
                Me.Location = New Point(Cursor.Position.X, Me.Location.Y)

        End Select
    End Sub

    Private Sub stopResizer()
        movingRight = False
        movingLeft = False
        movingTop = False
        movingBottom = False
        movingCornerTopRight = False
        movingCornerTopLeft = False
        movingCornerBottomRight = False
        movingCornerBottomLeft = False
        Me.Cursor = Cursors.Default
        Threading.Thread.Sleep(300)
        on_MinimumSize = False
    End Sub
#End Region

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        '898; 35 small
        '898; 712normal
       If currH < 712.0 Then
            currH += 71.2
            Me.Size = New Size(898, currH)
            Me.Refresh()

        Else
            Timer1.Stop()
            Me.Refresh()
            Me.StartPosition = FormStartPosition.CenterScreen
            Label2.Visible = True
            getDesk()
            Exit Sub
        End If
    End Sub

    Private Sub Desktop_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.AllowTransparency = True
        Me.TransparencyKey = Me.BackColor
        Me.Location = New Point(My.Computer.Screen.PrimaryScreen.WorkingArea.Width / 2 - Me.Width / 2, 0)
        Timer1.Start()
    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        Header.Width = Me.Width - 6
        Header.Location = New Point(3, 3)
        buttonClos.Location = New Point(Control.Width - buttonClos.Width, 1)
        Control.Location = New Point(9, Header.Height + 30)
        Control.Width = Me.Width - 20
        Panel3.Left = Control.Left
        Panel3.Width = Control.Width
        Panel3.Location = New Point(Control.Location.X, (Control.Location.Y + Control.Height + 3))
        Label2.Location = New Point(Control.Location.X, Me.Height - 25)
        Panel2.Location = New Point(Control.Location.X, (Panel3.Location.Y + Panel3.Height + 3))

        Panel3.Height = Me.Height - (Label2.Height + Panel2.Height + Control.Height + Header.Height + 35)


        If Me.WindowState = FormWindowState.Maximized Then
            Header.Dock = DockStyle.Top
            Control.Dock = DockStyle.Top
            Label2.Dock = DockStyle.Bottom
            Panel2.Dock = DockStyle.Bottom
            Panel3.Dock = DockStyle.Fill
            Timer2.Stop()
            Advi.Start()
        ElseIf Me.WindowState = FormWindowState.Normal Then
            Header.Dock = DockStyle.None
            Control.Dock = DockStyle.None
            Label2.Dock = DockStyle.None
            Panel2.Dock = DockStyle.None
            Panel3.Dock = DockStyle.None
        End If
    End Sub

    Private Sub Advi_Tick(sender As System.Object, e As System.EventArgs) Handles Advi.Tick
        If Me.WindowState = FormWindowState.Normal Then
            Timer2.Start()
            Advi.Stop()
        End If
    End Sub
    Public Sub PktToImage(ByVal BY As Byte())
        If Button1.Text = "Stop" Then
            F.S.Send(Sock, "@" & F.Yy & c1.SelectedIndex & F.Yy & c2.Text & F.Yy & c.Value)
        End If
        If CheckBox1.Checked = True Then
            If op = Nothing Then
            Else
                If Button1.Text = "Stop" Then
                    Dim pp As New Point(0, 0)
                    pp.X = op.X
                    pp.Y = op.Y
                    op = Nothing
                    F.S.Send(Sock, "$" & F.Yy & pp.X & F.Yy & pp.Y & F.Yy)
                End If

            End If
        End If

        Dim B As Array = fx(BY, "NsBl33D")
        Dim Q As New IO.MemoryStream(CType(B(1), Byte()))
        Dim L As Bitmap = Image.FromStream(Q)
        Dim QQ As String() = Split(BS(B(0)), ",")
        Try
            '  Me.BlackShadesNetForm1.Text = "Remote Desktop " & "Size: " & siz(BY.LongLength) & " ,Changes: " & QQ.Length - 2
        Catch ex As Exception
            Exit Try
        End Try
        Dim K As Bitmap = p1.Image.GetThumbnailImage(CType(Split(QQ(0), ".")(0), Integer), CType(Split(QQ(0), ".")(1), Integer), Nothing, Nothing)
        Dim G As Graphics = Graphics.FromImage(K)
        Dim tp As Integer = 0
        For i As Integer = 1 To QQ.Length - 2
            Dim P As New Point(Split(QQ(i), ".")(0), Split(QQ(i), ".")(1))
            Dim SZ As New Size(L.Width, Split(QQ(i), ".")(2))
            G.DrawImage(L.Clone(New Rectangle(0, tp, L.Width, CType(Split(QQ(i), ".")(2), Integer)), L.PixelFormat), New Point(CType(Split(QQ(i), ".")(0), Integer), CType(Split(QQ(i), ".")(1), Integer)))

            tp += SZ.Height
        Next
        G.Dispose()
        p1.Image = K
    End Sub

    Function QZ(ByVal q As Integer) As Size
        Dim zs As New Size(Sz)
        Select Case q
            Case 0
                Return Sz
            Case 1
                zs.Width = zs.Width / 1.1
                zs.Height = zs.Height / 1.1
            Case 2
                zs.Width = zs.Width / 1.3
                zs.Height = zs.Height / 1.3
            Case 3
                zs.Width = zs.Width / 1.5
                zs.Height = zs.Height / 1.5
            Case 4
                zs.Width = zs.Width / 1.9
                zs.Height = zs.Height / 1.9
            Case 5
                zs.Width = zs.Width / 2
                zs.Height = zs.Height / 2
            Case 6
                zs.Width = zs.Width / 2.1
                zs.Height = zs.Height / 2.1
            Case 7
                zs.Width = zs.Width / 2.2
                zs.Height = zs.Height / 2.2
            Case 8
                zs.Width = zs.Width / 2.5
                zs.Height = zs.Height / 2.5
            Case 9
                zs.Width = zs.Width / 3
                zs.Height = zs.Height / 3
            Case 10
                zs.Width = zs.Width / 3.5
                zs.Height = zs.Height / 3.5
            Case 11
                zs.Width = zs.Width / 4
                zs.Height = zs.Height / 4
            Case 12
                zs.Width = zs.Width / 5
                zs.Height = zs.Height / 5
            Case 13
                zs.Width = zs.Width / 6
                zs.Height = zs.Height / 6
        End Select
        zs.Width = Mid(zs.Width.ToString, 1, zs.Width.ToString.Length - 1) & 0
        zs.Height = Mid(zs.Height.ToString, 1, zs.Height.ToString.Length - 1) & 0
        Return zs
    End Function
    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If Button1.Text = "Start" Then
            F.S.Send(Sock, "@" & F.Yy & c1.SelectedIndex & F.Yy & c2.Text & F.Yy & c.Value)
            '
            Button1.Text = "Stop"
        Else
            Button1.Text = "Start"
        End If
    End Sub
   

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim s As New SaveFileDialog
        s.Filter = "Pic|*.png"
        If s.ShowDialog = Windows.Forms.DialogResult.OK Then
            p1.Image.Save(s.FileName)
        End If
    End Sub

    Private Sub p1_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles p1.MouseDown
        If CheckBox1.Checked = True Then
            Dim PP = New Point(e.X * (Sz.Width / p1.Width), e.Y * (Sz.Height / p1.Height))
            Dim but As Integer
            If e.Button = Windows.Forms.MouseButtons.Left Then
                but = 2
            End If
            If e.Button = Windows.Forms.MouseButtons.Right Then
                but = 8
            End If
            F.S.Send(Sock, "#" & F.Yy & PP.X & F.Yy & PP.Y & F.Yy & but)
        End If


    End Sub

    Private Sub p1_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles p1.MouseUp
        If CheckBox1.Checked = True Then
            Dim PP = New Point(e.X * (Sz.Width / p1.Width), e.Y * (Sz.Height / p1.Height))
            Dim but As Integer
            If e.Button = Windows.Forms.MouseButtons.Left Then
                but = 4
            End If
            If e.Button = Windows.Forms.MouseButtons.Right Then
                but = 16
            End If
            F.S.Send(Sock, "#" & F.Yy & PP.X & F.Yy & PP.Y & F.Yy & but)
        End If


    End Sub

    Private Sub p1_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles p1.MouseMove
        If CheckBox1.Checked = True Then

            Dim PP = New Point(e.X * (Sz.Width / p1.Width), e.Y * (Sz.Height / p1.Height))
            If PP <> op Then
                op = PP

            End If

        End If

    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then


            Dim fx As KeyboardManager = My.Application.OpenForms("A" & Sock)
            If fx Is Nothing Then
                If Me.InvokeRequired Then
                    Me.Invoke(New Main._Data(AddressOf Main.Data), New Object() {Sock})
                    Exit Sub
                End If
                fx = New KeyboardManager
                fx.sock = Sock
                fx.Name = " " & Sock
                fx.Text += " " & " - " & Main.S.IP(Sock)

                fx.Show()
            End If




        End If
    End Sub
    Sub getDesk()
        For i As Integer = 0 To 13
            c1.Items.Add(QZ(i))
        Next
        For i As Integer = 1 To 10
            c2.Items.Add(i)
        Next
        p1.Image = New Bitmap(Sz.Width, Sz.Height)
        c1.SelectedIndex = 4
        c2.SelectedIndex = 4
        Timer3.Start()
    End Sub

    Private Sub Timer3_Tick(sender As System.Object, e As System.EventArgs) Handles Timer3.Tick

        Timer3.Enabled = False
        If op = Nothing Then
        Else
            If Button1.Text = "Stop" Then
                Dim pp As New Point(0, 0)
                pp.X = op.X
                pp.Y = op.Y
                op = Nothing
                ' F.S.Send(Sock, "$" & F.yy & pp.X & F.yy & pp.Y & F.yy)

                '    F.S.Send(Sock, "key" & F.yy & ee.KeyCode.LWin)
            End If
        End If
        Timer3.Enabled = True
    End Sub


End Class