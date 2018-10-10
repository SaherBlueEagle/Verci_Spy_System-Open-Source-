Public Class ProcessManager
    Dim state As Integer
    Dim time As Integer
    Public sock As Integer
    Dim maximized As Boolean
#Region "Drag"

    Dim posX As Integer
    Dim posY As Integer
    Dim drag As Boolean

    Private Sub Header_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) 'Handles Label3.MouseDoubleClick
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
    ''Repeated
    Private Sub Label1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseDown
        If e.Button = MouseButtons.Left Then
            drag = True
            posX = Cursor.Position.X - Me.Left
            posY = Cursor.Position.Y - Me.Top
        End If
    End Sub

    Private Sub Label1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label2.MouseUp
        drag = False
    End Sub

    Private Sub Label1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label2.MouseMove
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
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        On Error Resume Next
        'Dim KeyIndex As Integer
        'KeyIndex = 1


        For Each Process As ListViewItem In ListView1.Items


            If Process.Text.Contains("csrss") Then
 
            ElseIf Process.Text.Contains("svchost") Then

            ElseIf Process.Text.Contains("System") Then
                Process.BackColor = Color.Red
            ElseIf Process.Text.Contains("winlogon") Then
                Process.ImageIndex = 1
                Process.BackColor = Color.Red
                'Dim aa = ListView1.View = (KeyIndex = 1)
            ElseIf Process.Text.Contains("lsm") Then

            ElseIf Process.Text.Contains("wininit") Then

            ElseIf Process.Text.Contains("IntelTechnologyAccessService") Then


            ElseIf Process.Text.Contains("SearchIndexer") Then

            ElseIf Process.Text.Contains("services") Then

            ElseIf Process.Text.Contains("explorer") Then
                Process.ImageIndex = 2
                'Process.BackColor = Color.LightSteelBlue
            ElseIf Process.Text.Contains("chrome") Then
                Process.ImageIndex = 3
            ElseIf Process.Text.Contains("notepad") Then
                Process.ImageIndex = 4
            ElseIf Process.Text.Contains("cmd") Then
                Process.ImageIndex = 5
            ElseIf Process.Text.Contains("conhost") Then
                Process.ImageIndex = 5
            ElseIf Process.Text.Contains("firefox") Then
                Process.ImageIndex = 6
            ElseIf Process.Text.Contains("regedit") Then
                Process.ImageIndex = 7
            ElseIf Process.Text.Contains("WinRAR") Then
                Process.ImageIndex = 8
            ElseIf Process.Text.Contains("iexplore") Then
                Process.ImageIndex = 9
            ElseIf Process.Text.Contains("Skype") Then
                Process.ImageIndex = 10
            ElseIf Process.Text.Contains("smss") Then

            ElseIf Process.Text.Contains("ProcessHacker") Then
                Process.ImageIndex = 11
            ElseIf Process.Text.Contains("taskmgr") Then
                Process.ImageIndex = 11
            ElseIf Process.Text.Contains("Process") Then
                Process.ImageIndex = 11
            ElseIf Process.Text.Contains("Spark") Then
                Process.ImageIndex = 12
            ElseIf Process.Text.Contains("procexp") Then
                Process.ImageIndex = 13
            ElseIf Process.Text.Contains("procexp64") Then
                Process.ImageIndex = 13
            ElseIf Process.Text.Contains("HWorks32") Then
                Process.ImageIndex = 14
            ElseIf Process.Text.Contains("Maxthon") Then
                Process.ImageIndex = 15
            ElseIf Process.Text.Contains("wordpad") Then
                Process.ImageIndex = 16

            End If

        Next




    End Sub



    Private Sub Processmanager_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Me.AllowTransparency = True
        Me.TransparencyKey = Me.BackColor

        Timer1.Start()



    End Sub

    Private Sub KillProcessToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles KillProcessToolStripMenuItem.Click
        Dim allprocess As String = ""
        For Each item As ListViewItem In ListView1.SelectedItems
            allprocess += (item.Text & "ProcessSplit")
        Next
        Main.S.Send(sock, "KillProcess" & Main.Yy & allprocess)

        ListView1.Items.Clear()
        Main.S.Send(sock, "GetProcesses")
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RefreshToolStripMenuItem.Click




        ListView1.Items.Clear()
        Main.S.Send(sock, "GetProcesses")
        '    Threading.Thread.Sleep(100)

        Timer2.Enabled = True

    End Sub

    Private Sub RestartProcessToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RestartProcessToolStripMenuItem.Click
        Dim allprocess As String = ""
        For Each item As ListViewItem In ListView1.SelectedItems
            allprocess += (item.Text & "ProcessSplit")
        Next
        Main.S.Send(sock, "RestProcess" & Main.Yy & allprocess)
        ListView1.Items.Clear()
        Main.S.Send(sock, "GetProcesses")
    End Sub

    Private Sub SuspendToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SuspendToolStripMenuItem.Click
        Dim allprocess As String = ""
        For Each item As ListViewItem In ListView1.SelectedItems
            allprocess += (item.Text & "ProcessSplit")
        Next
        Main.S.Send(sock, "SProcess" & Main.Yy & allprocess)
        ListView1.Items.Clear()
        Main.S.Send(sock, "GetProcesses")
    End Sub

    Private Sub ResumeProcessToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ResumeProcessToolStripMenuItem.Click
        Dim allprocess As String = ""
        For Each item As ListViewItem In ListView1.SelectedItems
            allprocess += (item.Text & "ProcessSplit")
        Next
        Main.S.Send(sock, "SProcessr" & Main.Yy & allprocess)
        Main.S.Send(sock, "GetProcesses")
    End Sub
    Dim currH As Double = 0.0
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If currH < 651 Then
            currH += 65.2
            Me.Size = New Size(Me.Width, currH)
        Else
            Timer1.Stop()
            Timer2.Enabled = True
            Main.S.Send(sock, "GetProcesses")
        End If
    End Sub
End Class